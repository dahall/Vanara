using Microsoft.Win32.SafeHandles;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

/// <summary>Provides a handle to an accelerator table.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HACCEL : IUserHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HACCEL"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HACCEL(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HACCEL"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HACCEL NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HACCEL"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HACCEL h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HACCEL"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HACCEL(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HACCEL"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HACCEL hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HACCEL h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a generic handle.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HANDLE : IHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HANDLE"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HANDLE NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HANDLE"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HANDLE h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HANDLE"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HANDLE(IntPtr h) => new(h);

	/// <summary>Performs an implicit conversion from <see cref="HANDLE"/> to <see cref="SafeHandle"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HANDLE(SafeHandle h) => new(h.DangerousGetHandle());

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HANDLE"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HANDLE hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HANDLE h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a bitmap.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HBITMAP : IGraphicsObjectHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HBITMAP"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HBITMAP(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HBITMAP"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HBITMAP NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HBITMAP"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HBITMAP h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HBITMAP"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HBITMAP(IntPtr h) => new(h);

	/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HBITMAP"/>.</summary>
	/// <param name="h">The pointer to a GDI handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HBITMAP(HGDIOBJ h) => new((IntPtr)h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HBITMAP"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HBITMAP hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HBITMAP h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to drawing brush.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HBRUSH : IGraphicsObjectHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HBRUSH"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HBRUSH(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HBRUSH"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HBRUSH NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HBRUSH"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HBRUSH h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HBRUSH"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HBRUSH(IntPtr h) => new(h);

	/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HBRUSH"/>.</summary>
	/// <param name="h">The pointer to a GDI handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HBRUSH(HGDIOBJ h) => new((IntPtr)h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HBRUSH"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HBRUSH hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HBRUSH h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a color space.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HCOLORSPACE : IGraphicsObjectHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HCOLORSPACE"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HCOLORSPACE(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HCOLORSPACE"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HCOLORSPACE NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HCOLORSPACE"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HCOLORSPACE h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HCOLORSPACE"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HCOLORSPACE(IntPtr h) => new(h);

	/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HCOLORSPACE"/>.</summary>
	/// <param name="h">The pointer to a GDI handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HCOLORSPACE(HGDIOBJ h) => new((IntPtr)h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HCOLORSPACE"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HCOLORSPACE hMem) => hMem.IsNull;

	/// <summary>Implements the operator !=.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(HCOLORSPACE h1, HCOLORSPACE h2) => !(h1 == h2);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(HCOLORSPACE h1, HCOLORSPACE h2) => h1.Equals(h2);

	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is HCOLORSPACE h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to cursor.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HCURSOR : IGraphicsObjectHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HCURSOR"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HCURSOR(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HCURSOR"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HCURSOR NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HCURSOR"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HCURSOR h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HCURSOR"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HCURSOR(IntPtr h) => new(h);

	/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HCURSOR"/>.</summary>
	/// <param name="h">The pointer to a GDI handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HCURSOR(HGDIOBJ h) => new((IntPtr)h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HCURSOR"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HCURSOR hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HCURSOR h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a graphic device context.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HDC : IHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HDC"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HDC(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HDC"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HDC NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HDC"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HDC h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HDC"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HDC(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HDC"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HDC hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HDC h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a desktop.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HDESK : IKernelHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HDESK"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HDESK(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HDESK"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HDESK NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HDESK"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HDESK h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HDESK"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HDESK(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HDESK"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HDESK hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HDESK h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a DPA.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HDPA : IKernelHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HDPA"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HDPA(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HDPA"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HDPA NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HDPA"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HDPA h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HDPA"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HDPA(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HDPA"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HDPA hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HDPA h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a Windows drop operation.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HDROP : IShellHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HDROP"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HDROP(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HDROP"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HDROP NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HDROP"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HDROP h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HDROP"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HDROP(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HDROP"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HDROP hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HDROP h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a DSA.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HDSA : IKernelHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HDSA"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HDSA(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HDSA"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HDSA NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HDSA"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HDSA h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HDSA"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HDSA(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HDSA"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HDSA hMem) => hMem.IsNull;

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

	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is HDSA h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a deferred windows position.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HDWP : IUserHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HDWP"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HDWP(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HDWP"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HDWP NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HDWP"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HDWP h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HDWP"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HDWP(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HDWP"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HDWP hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HDWP h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to an enhanced metafile.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HENHMETAFILE : IHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HENHMETAFILE"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HENHMETAFILE(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HENHMETAFILE"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HENHMETAFILE NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HENHMETAFILE"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HENHMETAFILE h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HENHMETAFILE"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HENHMETAFILE(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HENHMETAFILE"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HENHMETAFILE hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HENHMETAFILE h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a sync event.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HEVENT : ISyncHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HEVENT"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HEVENT(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HEVENT"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HEVENT NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HEVENT"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HEVENT h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HEVENT"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HEVENT(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HEVENT"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HEVENT hMem) => hMem.IsNull;

	/// <summary>Implements the operator !=.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(HEVENT h1, HEVENT h2) => !(h1 == h2);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(HEVENT h1, HEVENT h2) => h1.Equals(h2);

	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is HEVENT h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a file.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HFILE : ISyncHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HFILE"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HFILE(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HFILE"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HFILE NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Represents an invalid handle.</summary>
	public static readonly HFILE INVALID_HANDLE_VALUE = new IntPtr(-1);

	/// <summary>Gets a value indicating whether this instance is an invalid handle (INVALID_HANDLE_VALUE).</summary>
	public bool IsInvalid => handle == INVALID_HANDLE_VALUE;

	/// <summary>Performs an implicit conversion from <see cref="SafeFileHandle"/> to <see cref="HFILE"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HFILE(SafeFileHandle h) => new(h?.DangerousGetHandle() ?? IntPtr.Zero);

	/// <summary>Performs an explicit conversion from <see cref="HFILE"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HFILE h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFILE"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HFILE(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HFILE"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HFILE hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HFILE h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a font.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HFONT : IGraphicsObjectHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HFONT"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HFONT(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HFONT"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HFONT NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HFONT"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HFONT h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFONT"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HFONT(IntPtr h) => new(h);

	/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HFONT"/>.</summary>
	/// <param name="h">The pointer to a GDI handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HFONT(HGDIOBJ h) => new((IntPtr)h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HFONT"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HFONT hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HFONT h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a graphic device object.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HGDIOBJ : IGraphicsObjectHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HGDIOBJ"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HGDIOBJ(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HGDIOBJ"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HGDIOBJ NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HGDIOBJ"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HGDIOBJ h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HGDIOBJ"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HGDIOBJ(IntPtr h) => new(h);

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

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HGDIOBJ"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HGDIOBJ hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HGDIOBJ h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to an icon.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HICON : IUserHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HICON"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HICON(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HICON"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HICON NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HICON"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HICON h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HICON"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HICON(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HICON"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HICON hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HICON h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a Windows image list.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HIMAGELIST : IShellHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HIMAGELIST"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HIMAGELIST(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HIMAGELIST"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HIMAGELIST NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HIMAGELIST"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HIMAGELIST h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HIMAGELIST"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HIMAGELIST(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HIMAGELIST"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HIMAGELIST hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HIMAGELIST h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a module or library instance.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HINSTANCE : IKernelHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HINSTANCE"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HINSTANCE(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HINSTANCE"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HINSTANCE NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HINSTANCE"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HINSTANCE h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HINSTANCE"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HINSTANCE(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HINSTANCE"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HINSTANCE hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HINSTANCE h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a Windows registry key.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HKEY : IKernelHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HKEY"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HKEY(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HKEY"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HKEY NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>
	/// Registry entries subordinate to this key define types (or classes) of documents and the properties associated with those types.
	/// Shell and COM applications use the information stored under this key.
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
	/// environment variables, data about program groups, colors, printers, network connections, and application preferences. This key
	/// makes it easier to establish the current user's settings; the key maps to the current user's branch in HKEY_USERS. In
	/// HKEY_CURRENT_USER, software vendors store the current user-specific preferences to be used within their applications. Microsoft,
	/// for example, creates the HKEY_CURRENT_USER\Software\Microsoft key for its applications to use, with each application creating its
	/// own subkey under the Microsoft key.
	/// </summary>
	public static readonly HKEY HKEY_CURRENT_USER = new(new IntPtr(unchecked((int)0x80000001)));

	/// <summary></summary>
	public static readonly HKEY HKEY_DYN_DATA = new(new IntPtr(unchecked((int)0x80000006)));

	/// <summary>
	/// Registry entries subordinate to this key define the physical state of the computer, including data about the bus type, system
	/// memory, and installed hardware and software. It contains subkeys that hold current configuration data, including Plug and Play
	/// information (the Enum branch, which includes a complete list of all hardware that has ever been on the system), network logon
	/// preferences, network security information, software-related information (such as server names and the location of the server),
	/// and other system information.
	/// </summary>
	public static readonly HKEY HKEY_LOCAL_MACHINE = new(new IntPtr(unchecked((int)0x80000002)));

	/// <summary>
	/// Registry entries subordinate to this key allow you to access performance data. The data is not actually stored in the registry;
	/// the registry functions cause the system to collect the data from its source.
	/// </summary>
	public static readonly HKEY HKEY_PERFORMANCE_DATA = new(new IntPtr(unchecked((int)0x80000004)));

	/// <summary>
	/// Registry entries subordinate to this key define the default user configuration for new users on the local computer and the user
	/// configuration for the current user.
	/// </summary>
	public static readonly HKEY HKEY_USERS = new(new IntPtr(unchecked((int)0x80000003)));

	/// <summary>Performs an explicit conversion from <see cref="HKEY"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HKEY h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HKEY"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HKEY(IntPtr h) => new(h);

	/// <summary>Performs an implicit conversion from <see cref="HKEY"/> to <see cref="SafeRegistryHandle"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HKEY(SafeRegistryHandle h) => new(h.DangerousGetHandle());

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HKEY"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HKEY hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HKEY h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a menu.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HMENU : IUserHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HMENU"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HMENU(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HMENU"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HMENU NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HMENU"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HMENU h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HMENU"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HMENU(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HMENU"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HMENU hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HMENU h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a metafile.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HMETAFILE : IHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HMETAFILE"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HMETAFILE(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HMETAFILE"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HMETAFILE NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HMETAFILE"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HMETAFILE h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HMETAFILE"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HMETAFILE(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HMETAFILE"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HMETAFILE hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HMETAFILE h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a monitor.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HMONITOR : IKernelHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HMONITOR"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HMONITOR(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HMONITOR"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HMONITOR NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HMONITOR"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HMONITOR h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HMONITOR"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HMONITOR(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HMONITOR"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HMONITOR hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HMONITOR h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a palette.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HPALETTE : IGraphicsObjectHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HPALETTE"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HPALETTE(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HPALETTE"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HPALETTE NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HPALETTE"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HPALETTE h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HPALETTE"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HPALETTE(IntPtr h) => new(h);

	/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HPALETTE"/>.</summary>
	/// <param name="h">The pointer to a GDI handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HPALETTE(HGDIOBJ h) => new((IntPtr)h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HPALETTE"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HPALETTE hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HPALETTE h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a drawing pen.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HPEN : IGraphicsObjectHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HPEN"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HPEN(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HPEN"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HPEN NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HPEN"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HPEN h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HPEN"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HPEN(IntPtr h) => new(h);

	/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HPEN"/>.</summary>
	/// <param name="h">The pointer to a GDI handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HPEN(HGDIOBJ h) => new((IntPtr)h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HPEN"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HPEN hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HPEN h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a process.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HPROCESS : ISyncHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HPROCESS"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HPROCESS(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HPROCESS"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HPROCESS NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HPROCESS"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HPROCESS h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HPROCESS"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HPROCESS(IntPtr h) => new(h);

	/// <summary>Performs an implicit conversion from <see cref="HPROCESS"/> to <see cref="Process"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HPROCESS(Process h) => new(h.Handle);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HPROCESS"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HPROCESS hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HPROCESS h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a Windows property sheet.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HPROPSHEET : IUserHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HPROPSHEET"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HPROPSHEET(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HPROPSHEET"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HPROPSHEET NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HPROPSHEET"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HPROPSHEET h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HPROPSHEET"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HPROPSHEET(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HPROPSHEET"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HPROPSHEET hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HPROPSHEET h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a property sheet page.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HPROPSHEETPAGE : IUserHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HPROPSHEETPAGE"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HPROPSHEETPAGE(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HPROPSHEETPAGE"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HPROPSHEETPAGE NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HPROPSHEETPAGE"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HPROPSHEETPAGE h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HPROPSHEETPAGE"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HPROPSHEETPAGE(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HPROPSHEETPAGE"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HPROPSHEETPAGE hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HPROPSHEETPAGE h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a drawing region.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HRGN : IGraphicsObjectHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HRGN"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HRGN(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HRGN"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HRGN NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HRGN"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HRGN h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HRGN"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HRGN(IntPtr h) => new(h);

	/// <summary>Performs an implicit conversion from <see cref="HGDIOBJ"/> to <see cref="HRGN"/>.</summary>
	/// <param name="h">The pointer to a GDI handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HRGN(HGDIOBJ h) => new((IntPtr)h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HRGN"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HRGN hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HRGN h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a file mapping object.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HSECTION : IHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HSECTION"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HSECTION(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HSECTION"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HSECTION NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HSECTION"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HSECTION h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HSECTION"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HSECTION(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HSECTION"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HSECTION hMem) => hMem.IsNull;

	/// <summary>Implements the operator !=.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(HSECTION h1, HSECTION h2) => !(h1 == h2);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(HSECTION h1, HSECTION h2) => h1.Equals(h2);

	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is HSECTION h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a blocking task.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HTASK : IHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HTASK"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HTASK(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HTASK"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HTASK NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HTASK"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HTASK h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HTASK"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HTASK(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HTASK"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HTASK hMem) => hMem.IsNull;

	/// <summary>Implements the operator !=.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(HTASK h1, HTASK h2) => !(h1 == h2);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(HTASK h1, HTASK h2) => h1.Equals(h2);

	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is HTASK h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a Windows theme.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HTHEME : IHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HTHEME"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HTHEME(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HTHEME"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HTHEME NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HTHEME"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HTHEME h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HTHEME"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HTHEME(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HTHEME"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HTHEME hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HTHEME h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a thread.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HTHREAD : ISyncHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HTHREAD"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HTHREAD(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HTHREAD"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HTHREAD NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HTHREAD"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HTHREAD h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HTHREAD"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HTHREAD(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HTHREAD"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HTHREAD hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HTHREAD h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a Windows thumbnail.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HTHUMBNAIL : IShellHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HTHUMBNAIL"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HTHUMBNAIL(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HTHUMBNAIL"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HTHUMBNAIL NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HTHUMBNAIL"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HTHUMBNAIL h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HTHUMBNAIL"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HTHUMBNAIL(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HTHUMBNAIL"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HTHUMBNAIL hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HTHUMBNAIL h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to an access token.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HTOKEN : IKernelHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HTOKEN"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HTOKEN(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HTOKEN"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HTOKEN NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HTOKEN"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HTOKEN h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HTOKEN"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HTOKEN(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HTOKEN"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HTOKEN hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HTOKEN h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a windows station.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HWINSTA : IKernelHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HWINSTA"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HWINSTA(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HWINSTA"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HWINSTA NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HWINSTA"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HWINSTA h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HWINSTA"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HWINSTA(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HWINSTA"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HWINSTA hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HWINSTA h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a window or dialog.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct HWND : IUserHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HWND"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HWND(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HWND"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HWND NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>
	/// Places the window at the bottom of the Z order. If the hWnd parameter identifies a topmost window, the window loses its topmost
	/// status and is placed at the bottom of all other windows.
	/// </summary>
	public static HWND HWND_BOTTOM = new IntPtr(1);

	/// <summary>
	/// Used by <c>SendMessage</c> and <c>PostMessage</c> to send a message to all top-level windows in the system, including disabled or
	/// invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.
	/// </summary>
	public static HWND HWND_BROADCAST = new IntPtr(0xffff);

	/// <summary>Use as parent in CreateWindow or CreateWindowEx call to indicate a message-only window.</summary>
	public static HWND HWND_MESSAGE = new IntPtr(-3);

	/// <summary>
	/// Places the window above all non-topmost windows (that is, behind all topmost windows). This flag has no effect if the window is
	/// already a non-topmost window.
	/// </summary>
	public static HWND HWND_NOTOPMOST = new IntPtr(-2);

	/// <summary>Places the window at the top of the Z order.</summary>
	public static HWND HWND_TOP = new IntPtr(0);

	/// <summary>Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated.</summary>
	public static HWND HWND_TOPMOST = new IntPtr(-1);

	/// <summary>Performs an explicit conversion from <see cref="HWND"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HWND h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HWND"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HWND(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="HWND"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HWND hMem) => hMem.IsNull;

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
	public override bool Equals(object obj) => obj is HWND h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a pointer to an access control entry.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct PACE : ISecurityObject
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="PACE"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public PACE(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="PACE"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static PACE NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="PACE"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(PACE h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PACE"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator PACE(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="PACE"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(PACE hMem) => hMem.IsNull;

	/// <summary>Implements the operator !=.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(PACE h1, PACE h2) => !(h1 == h2);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(PACE h1, PACE h2) => h1.Equals(h2);

	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is PACE h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to an access control list.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct PACL : ISecurityObject
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="PACL"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public PACL(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="PACL"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static PACL NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="PACL"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(PACL h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PACL"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator PACL(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="PACL"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(PACL hMem) => hMem.IsNull;

	/// <summary>Implements the operator !=.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(PACL h1, PACL h2) => !(h1 == h2);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(PACL h1, PACL h2) => h1.Equals(h2);

	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is PACL h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a security descriptor.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct PSECURITY_DESCRIPTOR : ISecurityObject
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="PSECURITY_DESCRIPTOR"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public PSECURITY_DESCRIPTOR(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="PSECURITY_DESCRIPTOR"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static PSECURITY_DESCRIPTOR NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="PSECURITY_DESCRIPTOR"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(PSECURITY_DESCRIPTOR h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PSECURITY_DESCRIPTOR"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator PSECURITY_DESCRIPTOR(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="PSECURITY_DESCRIPTOR"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(PSECURITY_DESCRIPTOR hMem) => hMem.IsNull;

	/// <summary>Implements the operator !=.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(PSECURITY_DESCRIPTOR h1, PSECURITY_DESCRIPTOR h2) => !(h1 == h2);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(PSECURITY_DESCRIPTOR h1, PSECURITY_DESCRIPTOR h2) => h1.Equals(h2);

	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is PSECURITY_DESCRIPTOR h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

/// <summary>Provides a handle to a security identifier.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}")]
public struct PSID : ISecurityObject
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="PSID"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public PSID(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="PSID"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static PSID NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="PSID"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(PSID h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PSID"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator PSID(IntPtr h) => new(h);

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="PSID"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(PSID hMem) => hMem.IsNull;

	/// <summary>Implements the operator !=.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(PSID h1, PSID h2) => !(h1 == h2);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(PSID h1, PSID h2) => h1.Equals(h2);

	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is PSID h && handle == h.handle;

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public IntPtr DangerousGetHandle() => handle;
}

