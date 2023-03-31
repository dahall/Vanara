using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Ole32
{
	/// <summary>Represents all the options supported for the interface identified by riid in IObjectSafety methods.</summary>
	[PInvokeData("Objsafe.h")]
	[Flags]
	public enum INTERFACEUSE : uint
	{
		/// <summary>Indicates that the caller of the interface identified by riid might be untrusted.</summary>
		INTERFACESAFE_FOR_UNTRUSTED_CALLER = 0x00000001,// Caller of interface may be untrusted")

		/// <summary>Indicates that the data passed into the interface identified by riid might be untrusted.</summary>
		INTERFACESAFE_FOR_UNTRUSTED_DATA = 0x00000002,// Data passed into interface may be untrusted")

		/// <summary>Indicates that the caller of the interface identified by riid knows to use IDispatchEx.</summary>
		INTERFACE_USES_DISPEX = 0x00000004,// Object knows to use IDispatchEx")

		/// <summary>Indicates that the data passed into the interface identified by riid knows to use IInternetHostSecurityManager.</summary>
		INTERFACE_USES_SECURITY_MANAGER = 0x00000008, // Object knows to use IInternetHostSecurityManager")
	}

	/// <summary>Provides methods to get and set safety options.</summary>
	/// <remarks>
	/// <para>
	/// The <c>IObjectSafety</c> interface should be implemented by objects that have interfaces which support "untrusted" clients, such
	/// as scripts. It allows the owner of the object to specify which interfaces must be protected from "untrusted" use.
	/// </para>
	/// <para>Examples of interfaces that might be protected in this way are:
	/// <code>IID_IDispatch</code>
	/// (safe for automating with untrusted automation client or script),
	/// <code>IID_IPersist</code>
	/// (safe for initializing with untrusted data), and
	/// <code>IID_IActiveScript</code>
	/// (safe for running untrusted scripts).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa768224(v=vs.85)
	[PInvokeData("Objsafe.h")]
	[ComImport, Guid("CB5BDC81-93C1-11CF-8F20-00805F2CD064"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IObjectSafety
	{
		/// <summary>
		/// This method retrieves the safety options supported by an object as well as the safety options that are currently set for
		/// that object.
		/// </summary>
		/// <param name="riid">Interface identifier for a given object.</param>
		/// <param name="pdwSupportedOptions">
		/// Address of a <c>DWORD</c> containing options supported for the interface identified by riid.
		/// </param>
		/// <param name="pdwEnabledOptions">
		/// Address of a <c>DWORD</c> containing options currently enabled for the interface identified by riid.
		/// </param>
		/// <returns>
		/// Returns S_OK if successful, or E_NOINTERFACE if the riid parameter specifies an interface that is unknown to the object.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method returns a set of bits in the pdwSupportedOptions parameter for each capability that the control knows about, and
		/// a set of bits in the pdwEnabledOptions parameter for each capability for which the control is currently safe.
		/// </para>
		/// <para>
		/// For example, a control might say that it knows about INTERFACESAFE_FOR_UNTRUSTED_DATA and
		/// INTERFACESAFE_FOR_UNTRUSTED_CALLER, and that it is currently safe only for INTERFACESAFE_FOR_UNTRUSTED_DATA.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/embedded/ms882879(v=msdn.10)
		[PreserveSig]
		HRESULT GetInterfaceSafetyOptions(in Guid riid, out INTERFACEUSE pdwSupportedOptions, out INTERFACEUSE pdwEnabledOptions);

		/// <summary>This method makes an object safe for initialization or scripting.</summary>
		/// <param name="riid">Interface identifier for the object to be made safe.</param>
		/// <param name="dwOptionSetMask">Options to be changed.</param>
		/// <param name="dwEnabledOptions">Settings for the options that are to be changed.</param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The object is safe for loading.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>The riid parameter specifies an interface that is unknown to the object.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The dwOptionSetMask parameter specifies an option that is not supported by the object.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A control client, such as Internet Explorer, calls this method prior to loading a control to determine whether the control
		/// is safe for scripting or initialization.
		/// </para>
		/// <para>
		/// If this method returns E_FAIL, its client displays the user interface for the user to confirm whether the action should be allowed.
		/// </para>
		/// <para>This method takes an interface (either IDispatch for scripting or IPersist for initialization).</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/embedded/ms882881(v=msdn.10)
		[PreserveSig]
		HRESULT SetInterfaceSafetyOptions(in Guid riid, INTERFACEUSE dwOptionSetMask, INTERFACEUSE dwEnabledOptions);
	}
}