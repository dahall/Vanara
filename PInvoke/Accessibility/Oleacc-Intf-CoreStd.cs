#if NETSTANDARD || NETCOREAPP2_1 || NETCOREAPP2_0
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Vanara.PInvoke;

namespace Accessibility;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
/// <summary>
/// The IAccessibleHandler and all of its exposed members are part of a managed wrapper for the Component Object Model (COM) accessibility interface.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 4, Pack = 4)]
public struct __MIDL_IWinTypes_0009
{
	[FieldOffset(0)]
	public int hInproc;
	[FieldOffset(0)]
	public int hRemote;
}

/// <summary>
/// The IAccessibleHandler and all of its exposed members are part of a managed wrapper for the Component Object Model (COM) accessibility interface.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct _RemotableHandle
{
	/// <summary>
	/// The IAccessibleHandler and all of its exposed members are part of a managed wrapper for the Component Object Model (COM)
	/// accessibility interface.
	/// </summary>
	public int fContext;

	/// <summary>
	/// The IAccessibleHandler and all of its exposed members are part of a managed wrapper for the Component Object Model (COM)
	/// accessibility interface.
	/// </summary>
	public __MIDL_IWinTypes_0009 u;
}

/// <summary>
/// The AnnoScope and all of its exposed members are part of a managed wrapper for the Component Object Model (COM) accessibility interface.
/// </summary>
// https://learn.microsoft.com/en-us/dotnet/api/accessibility.annoscope?view=windowsdesktop-8.0
public enum AnnoScope
{
	ANNO_THIS,
	ANNO_CONTAINER
}

/// <summary>
/// The CAccPropServices and all of its exposed members are part of a managed wrapper for the Component Object Model (COM) IAccPropServices interface.
/// </summary>
/// <remarks>For more information, see the Microsoft Active Accessibility documentation.</remarks>
// https://learn.microsoft.com/en-us/dotnet/api/accessibility.caccpropservices?view=windowsdesktop-7.0
[ComImport, Guid("6E26E776-04F0-495D-80E4-3330352E3169"), CoClass(typeof(CAccPropServicesClass))]
public interface CAccPropServices : IAccPropServices
{
}

/// <summary>
/// The CAccPropServicesClass and all of its exposed members are part of a managed wrapper for the Component Object Model (COM)
/// IAccPropServices interface.
/// </summary>
/// <remarks>For more information, see the Microsoft Active Accessibility documentation.</remarks>
// https://learn.microsoft.com/en-us/dotnet/api/accessibility.caccpropservicesclass?view=windowsdesktop-7.0
[ComImport, Guid("B5F8350B-0548-48B1-A6EE-88BD00B4A5E7"), ClassInterface(ClassInterfaceType.None)]
public class CAccPropServicesClass : IAccPropServices, CAccPropServices
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void ClearHmenuProps([In, ComAliasName("Accessibility.wireHMENU")] ref _RemotableHandle hmenu, [In] uint idChild, [In] ref Guid paProps, [In] int cProps);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void ClearHwndProps([In, ComAliasName("Accessibility.wireHWND")] ref _RemotableHandle hwnd, [In] uint idObject, [In] uint idChild, [In] ref Guid paProps, [In] int cProps);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void ClearProps([In] ref byte pIDString, [In] uint dwIDStringLen, [In] ref Guid paProps, [In] int cProps);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void ComposeHmenuIdentityString([In, ComAliasName("Accessibility.wireHMENU")] ref _RemotableHandle hmenu, [In] uint idChild, [Out] IntPtr ppIDString, out uint pdwIDStringLen);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void ComposeHwndIdentityString([In, ComAliasName("Accessibility.wireHWND")] ref _RemotableHandle hwnd, [In] uint idObject, [In] uint idChild, [Out] IntPtr ppIDString, out uint pdwIDStringLen);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void DecomposeHmenuIdentityString([In] ref byte pIDString, [In] uint dwIDStringLen, [Out, ComAliasName("Accessibility.wireHMENU")] IntPtr phmenu, out uint pidChild);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void DecomposeHwndIdentityString([In] ref byte pIDString, [In] uint dwIDStringLen, [Out, ComAliasName("Accessibility.wireHWND")] IntPtr phwnd, out uint pidObject, out uint pidChild);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetHmenuProp([In, ComAliasName("Accessibility.wireHMENU")] ref _RemotableHandle hmenu, [In] uint idChild, [In] Guid idProp, [In, MarshalAs(UnmanagedType.Struct)] object var);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetHmenuPropServer([In, ComAliasName("Accessibility.wireHMENU")] ref _RemotableHandle hmenu, [In] uint idChild, [In] ref Guid paProps, [In] int cProps, [In, MarshalAs(UnmanagedType.Interface)] IAccPropServer pServer, [In] AnnoScope AnnoScope);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetHmenuPropStr([In, ComAliasName("Accessibility.wireHMENU")] ref _RemotableHandle hmenu, [In] uint idChild, [In] Guid idProp, [In, MarshalAs(UnmanagedType.LPWStr)] string str);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetHwndProp([In, ComAliasName("Accessibility.wireHWND")] ref _RemotableHandle hwnd, [In] uint idObject, [In] uint idChild, [In] Guid idProp, [In, MarshalAs(UnmanagedType.Struct)] object var);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetHwndPropServer([In, ComAliasName("Accessibility.wireHWND")] ref _RemotableHandle hwnd, [In] uint idObject, [In] uint idChild, [In] ref Guid paProps, [In] int cProps, [In, MarshalAs(UnmanagedType.Interface)] IAccPropServer pServer, [In] AnnoScope AnnoScope);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetHwndPropStr([In, ComAliasName("Accessibility.wireHWND")] ref _RemotableHandle hwnd, [In] uint idObject, [In] uint idChild, [In] Guid idProp, [In, MarshalAs(UnmanagedType.LPWStr)] string str);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetPropServer([In] ref byte pIDString, [In] uint dwIDStringLen, [In] ref Guid paProps, [In] int cProps, [In, MarshalAs(UnmanagedType.Interface)] IAccPropServer pServer, [In] AnnoScope AnnoScope);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	public virtual extern void SetPropValue([In] ref byte pIDString, [In] uint dwIDStringLen, [In] Guid idProp, [In, MarshalAs(UnmanagedType.Struct)] object var);
}

/// <summary>Exposes methods and properties that make a user interface element and its children accessible to client applications.</summary>
// https://learn.microsoft.com/en-us/windows/win32/api/oleacc/nn-oleacc-iaccessible
[PInvokeData("oleacc.h", MSDNShortId = "NN:oleacc.IAccessible")]
[ComImport, Guid("618736E0-3C3D-11CF-810C-00AA00389B71"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
public interface IAccessible
{
	/// <summary>
	/// The <c>IAccessible::get_accParent</c> method retrieves the IDispatch of the object's parent. All objects support this property.
	/// </summary>
	/// <returns>
	/// <para>
	/// Receives the address of the parent object's IDispatch interface. If no parent exists or if the child cannot access its parent, the
	/// variable is set to <c>NULL</c>.
	/// </para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/oleacc/nf-oleacc-iaccessible-get_accparent HRESULT get_accParent( [out, retval]
	// IDispatch **ppdispParent );
	[DispId(-5000)]
	object accParent { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5000)] get; }

	[DispId(-5001)]
	int accChildCount { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5001)] get; }

	[return: MarshalAs(UnmanagedType.IDispatch)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5002)]
	object get_accChild(object varChild);

	[return: MarshalAs(UnmanagedType.BStr)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5003)]
	string get_accName(object varChild);

	[return: MarshalAs(UnmanagedType.BStr)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5004)]
	string get_accValue(object varChild);

	[return: MarshalAs(UnmanagedType.BStr)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5005)]
	string get_accDescription(object varChild);

	[return: MarshalAs(UnmanagedType.Struct)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5006)]
	object get_accRole(object varChild);

	[return: MarshalAs(UnmanagedType.Struct)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5007)]
	object get_accState(object varChild);

	[return: MarshalAs(UnmanagedType.BStr)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5008)]
	string get_accHelp(object varChild);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5009)]
	int get_accHelpTopic([MarshalAs(UnmanagedType.BStr)] ref string pszHelpFile, object varChild);

	[return: MarshalAs(UnmanagedType.BStr)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5010)]
	string get_accKeyboardShortcut(object varChild);

	[DispId(-5011)]
	object accFocus { [return: MarshalAs(UnmanagedType.Struct)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5011)] get; }

	[DispId(-5012)]
	object accSelection { [return: MarshalAs(UnmanagedType.Struct)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5012)] get; }

	[return: MarshalAs(UnmanagedType.BStr)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5013)]
	string get_accDefaultAction(object varChild);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5014)]
	void accSelect([In] int flagsSelect, [In, Optional, MarshalAs(UnmanagedType.Struct)] object varChild);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5015)]
	void accLocation(out int pxLeft, out int pyTop, out int pcxWidth, out int pcyHeight, [In, Optional, MarshalAs(UnmanagedType.Struct)] object varChild);

	[return: MarshalAs(UnmanagedType.Struct)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5016)]
	object accNavigate([In] int navDir, [In, Optional, MarshalAs(UnmanagedType.Struct)] object varStart);

	[return: MarshalAs(UnmanagedType.Struct)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5017)]
	object accHitTest([In] int xLeft, [In] int yTop);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5018)]
	void accDoDefaultAction([In, Optional, MarshalAs(UnmanagedType.Struct)] object varChild);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5003)]
	void put_accName(object varChild, [In, MarshalAs(UnmanagedType.BStr)] string szName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-5004)]
	void put_accValue(object varChild, [In, MarshalAs(UnmanagedType.BStr)] string szValue);
}

/// <summary>
/// The IAccessibleHandler and all of its exposed members are part of a managed wrapper for the Component Object Model (COM)
/// IAccessibleHandler interface.
/// </summary>
[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("03022430-ABC4-11D0-BDE2-00AA001A1953")]
public interface IAccessibleHandler
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void AccessibleObjectFromID([In] int hwnd, [In] int lObjectID, [MarshalAs(UnmanagedType.Interface)] out IAccessible pIAccessible);
}

/// <summary>Exposes a method that provides a unique identifier for an accessible element.</summary>
// https://learn.microsoft.com/en-us/windows/win32/api/oleacc/nn-oleacc-iaccidentity
[PInvokeData("oleacc.h", MSDNShortId = "NN:oleacc.IAccIdentity")]
[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("7852B78D-1CFD-41C1-A615-9C0C85960B5F")]
public interface IAccIdentity
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetIdentityString([In] uint dwIDChild, [Out] IntPtr ppIDString, out uint pdwIDStringLen);
}

/// <summary>Exposes a method that retrieves a property value for an accessible element.</summary>
// https://learn.microsoft.com/en-us/windows/win32/api/oleacc/nn-oleacc-iaccpropserver
[PInvokeData("oleacc.h", MSDNShortId = "NN:oleacc.IAccPropServer")]
[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("76C0DBBB-15E0-4E7B-B61B-20EEEA2001E0")]
public interface IAccPropServer
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetPropValue([In] ref byte pIDString, [In] uint dwIDStringLen, [In] Guid idProp, [MarshalAs(UnmanagedType.Struct)] out object pvarValue, out int pfHasProp);
}

/// <summary>Exposes methods for annotating accessible elements and for manipulating identity strings.</summary>
// https://learn.microsoft.com/en-us/windows/win32/api/oleacc/nn-oleacc-iaccpropservices
[PInvokeData("oleacc.h", MSDNShortId = "NN:oleacc.IAccPropServices")]
[ComImport, Guid("6E26E776-04F0-495D-80E4-3330352E3169"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IAccPropServices
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetPropValue([In] ref byte pIDString, [In] uint dwIDStringLen, [In] Guid idProp, [In, MarshalAs(UnmanagedType.Struct)] object var);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetPropServer([In] ref byte pIDString, [In] uint dwIDStringLen, [In] ref Guid paProps, [In] int cProps, [In, MarshalAs(UnmanagedType.Interface)] IAccPropServer pServer, [In] AnnoScope AnnoScope);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void ClearProps([In] ref byte pIDString, [In] uint dwIDStringLen, [In] ref Guid paProps, [In] int cProps);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetHwndProp([In, ComAliasName("Accessibility.wireHWND")] ref _RemotableHandle hwnd, [In] uint idObject, [In] uint idChild, [In] Guid idProp, [In, MarshalAs(UnmanagedType.Struct)] object var);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetHwndPropStr([In, ComAliasName("Accessibility.wireHWND")] ref _RemotableHandle hwnd, [In] uint idObject, [In] uint idChild, [In] Guid idProp, [In, MarshalAs(UnmanagedType.LPWStr)] string str);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetHwndPropServer([In, ComAliasName("Accessibility.wireHWND")] ref _RemotableHandle hwnd, [In] uint idObject, [In] uint idChild, [In] ref Guid paProps, [In] int cProps, [In, MarshalAs(UnmanagedType.Interface)] IAccPropServer pServer, [In] AnnoScope AnnoScope);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void ClearHwndProps([In, ComAliasName("Accessibility.wireHWND")] ref _RemotableHandle hwnd, [In] uint idObject, [In] uint idChild, [In] ref Guid paProps, [In] int cProps);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void ComposeHwndIdentityString([In, ComAliasName("Accessibility.wireHWND")] ref _RemotableHandle hwnd, [In] uint idObject, [In] uint idChild, [Out] IntPtr ppIDString, out uint pdwIDStringLen);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void DecomposeHwndIdentityString([In] ref byte pIDString, [In] uint dwIDStringLen, [Out, ComAliasName("Accessibility.wireHWND")] IntPtr phwnd, out uint pidObject, out uint pidChild);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetHmenuProp([In, ComAliasName("Accessibility.wireHMENU")] ref _RemotableHandle hmenu, [In] uint idChild, [In] Guid idProp, [In, MarshalAs(UnmanagedType.Struct)] object var);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetHmenuPropStr([In, ComAliasName("Accessibility.wireHMENU")] ref _RemotableHandle hmenu, [In] uint idChild, [In] Guid idProp, [In, MarshalAs(UnmanagedType.LPWStr)] string str);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void SetHmenuPropServer([In, ComAliasName("Accessibility.wireHMENU")] ref _RemotableHandle hmenu, [In] uint idChild, [In] ref Guid paProps, [In] int cProps, [In, MarshalAs(UnmanagedType.Interface)] IAccPropServer pServer, [In] AnnoScope AnnoScope);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void ClearHmenuProps([In, ComAliasName("Accessibility.wireHMENU")] ref _RemotableHandle hmenu, [In] uint idChild, [In] ref Guid paProps, [In] int cProps);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void ComposeHmenuIdentityString([In, ComAliasName("Accessibility.wireHMENU")] ref _RemotableHandle hmenu, [In] uint idChild, [Out] IntPtr ppIDString, out uint pdwIDStringLen);
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void DecomposeHmenuIdentityString([In] ref byte pIDString, [In] uint dwIDStringLen, [Out, ComAliasName("Accessibility.wireHMENU")] IntPtr phmenu, out uint pidChild);
}
#endif