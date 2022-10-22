using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Provides functionality for desktop apps to opt in to the focus tracking mechanism used in Windows Store apps.</summary>
	/// <remarks>
	/// <para><c>Warning</c>
	/// <para></para>
	/// <c>IInputPanelConfiguration</c> will not work in Windows 10.
	/// </para>
	/// <para>
	/// Implement the <c>IInputPanelConfiguration</c> interface if your Desktop client processes need to leverage the invoking and dismissing
	/// semantics of the touch keyboard and handwriting input panel.
	/// </para>
	/// <para>
	/// The <c>IInputPanelConfiguration</c> interface enables your app to opt in to the focus tracking mechanism for Windows Store apps.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/inputpanelconfiguration/nn-inputpanelconfiguration-iinputpanelconfiguration
	[PInvokeData("inputpanelconfiguration.h", MSDNShortId = "NN:inputpanelconfiguration.IInputPanelConfiguration")]
	[ComImport, Guid("41C81592-514C-48BD-A22E-E6AF638521A6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(InputPanelConfiguration))]
	public interface IInputPanelConfiguration
	{
		/// <summary>
		/// Enables a client process to opt-in to the focus tracking mechanism for Windows Store apps that controls the invoking and
		/// dismissing semantics of the touch keyboard.
		/// </summary>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <c>Note</c>
		/// <para></para>
		/// This method will not work in Windows 10. A user can manually configure settings through the notification center or through the
		/// <c>Typing</c> settings to enable pulling up a touch keyboard automatically when focusing on an edit control.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/inputpanelconfiguration/nf-inputpanelconfiguration-iinputpanelconfiguration-enablefocustracking
		// HRESULT EnableFocusTracking();
		[PreserveSig]
		HRESULT EnableFocusTracking();
	}

	/// <summary>Enables Windows Store apps to opt out of the automatic invocation behavior.</summary>
	/// <remarks>
	/// Clients can request that the touch keyboard and handwriting input panel check to see that a user tapped in the edit control with
	/// focus before invoking.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/inputpanelconfiguration/nn-inputpanelconfiguration-iinputpanelinvocationconfiguration
	[PInvokeData("inputpanelconfiguration.h", MSDNShortId = "NN:inputpanelconfiguration.IInputPanelInvocationConfiguration")]
	[ComImport, Guid("A213F136-3B45-4362-A332-EFB6547CD432"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IInputPanelInvocationConfiguration
	{
		/// <summary>Requires an explicit user tap in an edit field before the touch keyboard invokes.</summary>
		/// <returns>The <c>RequireTouchInEditControl</c> method always returns <c>S_OK</c>.</returns>
		/// <remarks>
		/// <para>
		/// When the <c>RequireTouchInEditControl</c> method is called, all future focus changes require an explicit user tap in an edit
		/// field before the touch keyboard invokes. You can call the <c>RequireTouchInEditControl</c> method multiple times, but there's no
		/// way to undo the setting.
		/// </para>
		/// <para>
		/// This setting applies for any focus event that takes place to a window that is running in the process that called it. The
		/// <c>RequireTouchInEditControl</c> method doesn't affect owned windows in another process that have an ownership chain to the
		/// current process that called <c>RequireTouchInEditControl</c>.
		/// </para>
		/// <para>
		/// The <c>RequireTouchInEditControl</c> method always returns <c>S_OK</c>. If this API is used, then the <c>IsUIBusy</c> property
		/// has no effect. The two interaction models are essentially mutually exclusive.
		/// </para>
		/// <para>The following code shows how to call the <c>RequireTouchInEditControl</c> method.</para>
		/// <para>
		/// <code>#include &lt;inputpanelconfiguration.h&gt;
		/// #include &lt;inputpanelconfiguration_i.c&gt;
		/// 
		/// IInputPanelInvocationConfiguration *pInputPanelInvocationConfiguration;
		/// CoCreateInstance(CLSID_InputPanelConfiguration, NULL, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&amp;pInputPanelInvocationConfiguration));
		/// pInputPanelInvocationConfiguration-&gt;RequireTouchInEditControl();</code>
		/// </para>
		/// <para>
		/// <c>Note</c> Calling Release before the app finishes drawing UI can cause undefined behavior. If the touch keyboard isn't already
		/// running, calling <c>Release</c> could cause tiptsf.dll to be unloaded, because there are no more references to the dll. If this
		/// occurs, the state set by the <c>RequireTouchInEditControl</c> method is lost.
		/// </para>
		/// <para>
		/// If you need to delay the invocation of the touch keyboard until a later time, like when animations or direct manipulation have
		/// completed, use the <c>IsUIBusy</c> custom UI automation property. For more info, see Registering Custom Properties, Events, and
		/// Control Patterns.
		/// </para>
		/// <para>
		/// When you set <c>IsUIBusy</c> to <c>True</c>, the touch keyboard doesn't change visual state based on focus changes within the
		/// app. It's still able to change visual state based on overriding user action, like using a physical keyboard or manual dismissal.
		/// </para>
		/// <para>
		/// When you set <c>IsUIBusy</c> to <c>False</c>, the touch keyboard resumes its default behavior and queries synchronously for the
		/// control that has focus.
		/// </para>
		/// <para>The following code shows how to register the <c>IsUIBusy</c> custom UI automation property.</para>
		/// <para>
		/// <code>/* 03391bea-6681-474b-955c-60f664397ac6 */
		/// DEFINE_GUID( GUID_UIBusy, 0x03391bea, 0x6681, 0x474b, 0x95, 0x5c, 0x60, 0xf6, 0x64, 0x39, 0x7a, 0xc6);
		/// UIAutomationPropertyInfo customPropertyInfo = { GUID_UIBusy, L"IsUIBusy", UIAutomationType_Bool };
		/// CComPtr&lt;IUIAutomationRegistrar&gt; spRegistrar;
		/// hr = spRegistrar.CoCreateInstance( CLSID_CUIAutomationRegistrar, nullptr, CLSCTX_INPROC_SERVER);
		/// if (SUCCEEDED(hr)) {
		///    PATTERNID customPropertyId;
		///    hr = spRegistrar-&gt;RegisterProperty(&amp;customPropertyInfo, &amp;customPropertyId);
		/// }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/inputpanelconfiguration/nf-inputpanelconfiguration-iinputpanelinvocationconfiguration-requiretouchineditcontrol
		// HRESULT RequireTouchInEditControl();
		[PreserveSig]
		HRESULT RequireTouchInEditControl();
	}

	/// <summary>CLSID_InputPanelConfiguration</summary>
	[ComImport, Guid("2853ADD3-F096-4C63-A78F-7FA3EA837FB7"), ClassInterface(ClassInterfaceType.None)]
	public class InputPanelConfiguration { }
}