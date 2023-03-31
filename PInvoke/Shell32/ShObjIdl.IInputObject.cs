using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Exposes methods that change UI activation and process accelerators for a user input object contained in the Shell.</summary>
	[ComImport, Guid("68284fAA-6A48-11D0-8c78-00C04fd918b4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[PInvokeData("ShObjIdl_core.h")]
	public interface IInputObject
	{
		/// <summary>UI-activates or deactivates the object.</summary>
		/// <param name="fActivate">
		/// Indicates if the object is being activated or deactivated. If this value is nonzero, the object is being activated. If this
		/// value is zero, the object is being deactivated.
		/// </param>
		/// <param name="pMsg">
		/// A pointer to an MSG structure that contains the message that caused the activation change. This value may be NULL.
		/// </param>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		HRESULT UIActivateIO([In, MarshalAs(UnmanagedType.Bool)] bool fActivate, in MSG pMsg);

		/// <summary>Determines if one of the object's windows has the keyboard focus.</summary>
		/// <returns>Returns S_OK if one of the object's windows has the keyboard focus, or S_FALSE otherwise.</returns>
		[PreserveSig]
		HRESULT HasFocusIO();

		/// <summary>Enables the object to process keyboard accelerators.</summary>
		/// <param name="pMsg">The address of an MSG structure that contains the keyboard message that is being translated.</param>
		/// <returns>Returns S_OK if the accelerator was translated, or S_FALSE otherwise.</returns>
		[PreserveSig]
		HRESULT TranslateAcceleratorIO(in MSG pMsg);
	}

	/// <summary>Exposes a method that extends IInputObject by handling global accelerators.</summary>
	[ComImport, Guid("6915C085-510B-44cd-94AF-28DFA56CF92B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[PInvokeData("ShObjIdl_core.h")]
	public interface IInputObject2 : IInputObject
	{
		/// <summary>UI-activates or deactivates the object.</summary>
		/// <param name="fActivate">
		/// Indicates if the object is being activated or deactivated. If this value is nonzero, the object is being activated. If this
		/// value is zero, the object is being deactivated.
		/// </param>
		/// <param name="pMsg">
		/// A pointer to an MSG structure that contains the message that caused the activation change. This value may be NULL.
		/// </param>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		new HRESULT UIActivateIO([In, MarshalAs(UnmanagedType.Bool)] bool fActivate, in MSG pMsg);

		/// <summary>Determines if one of the object's windows has the keyboard focus.</summary>
		/// <returns>Returns S_OK if one of the object's windows has the keyboard focus, or S_FALSE otherwise.</returns>
		[PreserveSig]
		new HRESULT HasFocusIO();

		/// <summary>Enables the object to process keyboard accelerators.</summary>
		/// <param name="pMsg">The address of an MSG structure that contains the keyboard message that is being translated.</param>
		/// <returns>Returns S_OK if the accelerator was translated, or S_FALSE otherwise.</returns>
		[PreserveSig]
		new HRESULT TranslateAcceleratorIO(in MSG pMsg);

		/// <summary>
		/// Handles global accelerators so that input objects can respond to the keyboard even when they are not active in the UI.
		/// </summary>
		/// <param name="pMsg">A pointer to an MSG structure that contains a keyboard message.</param>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		HRESULT TranslateAcceleratorGlobal(in MSG pMsg);
	}

	/// <summary>Exposes a method that is used to communicate focus changes for a user input object contained in the Shell.</summary>
	[ComImport, Guid("F1DB8392-7331-11D0-8C99-00A0C92DBFE8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[PInvokeData("ShObjIdl_core.h")]
	public interface IInputObjectSite
	{
		/// <summary>Informs the browser that the focus has changed.</summary>
		/// <param name="punkObj">The address of the IUnknown interface of the object gaining or losing the focus.</param>
		/// <param name="fSetFocus">
		/// Indicates if the object has gained or lost the focus. If this value is nonzero, the object has gained the focus. If this
		/// value is zero, the object has lost the focus.
		/// </param>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		HRESULT OnFocusChangeIS([In, MarshalAs(UnmanagedType.IUnknown)] object punkObj, [In, MarshalAs(UnmanagedType.Bool)] bool fSetFocus);
	}
}