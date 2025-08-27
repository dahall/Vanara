namespace Vanara.PInvoke;

public static partial class WindowsDriverFramework
{
	/// <summary>
	/// The WDF_TRI_STATE enumeration type defines three values that the framework uses for some structure members and function parameters.
	/// </summary>
	/// <remarks>The WDF_TRI_STATE enumeration type is available in version 1.0 and later versions of KMDF.</remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdftypes/ne-wdftypes-_wdf_tri_state typedef enum _WDF_TRI_STATE {
	// WdfFalse = FALSE, WdfTrue = TRUE, WdfUseDefault = 2 } WDF_TRI_STATE, *PWDF_TRI_STATE;
	[PInvokeData("wdftypes.h", MSDNShortId = "NE:wdftypes._WDF_TRI_STATE")]
	public enum WDF_TRI_STATE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>FALSE</para>
		/// <para>The meaning of this enumerator is specific to its use as a structure member or function parameter.</para>
		/// </summary>
		WdfFalse,

		/// <summary>
		/// <para>Value:</para>
		/// <para>TRUE</para>
		/// <para>The meaning of this enumerator is specific to its use as a structure member or function parameter.</para>
		/// </summary>
		WdfTrue,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The meaning of this enumerator is specific to its use as a structure member or function parameter.</para>
		/// </summary>
		WdfUseDefault,
	}

	/// <summary>The WDFDEVICE_INIT structure is an opaque structure that is defined and allocated by the framework.</summary>
	[AutoHandle]
	public partial struct PWDFDEVICE_INIT { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFCHILDLIST { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFCMRESLIST { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFCOLLECTION { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFCOMMONBUFFER { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFCOMPANIONTARGET { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFCONTEXT { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFDEVICE { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFDMAENABLER { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFDMATRANSACTION { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFDPC { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFDRIVER { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFFILEOBJECT { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFINTERRUPT { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFIORESLIST { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFIORESREQLIST { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFIOTARGET { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFKEY { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFLOOKASIDE { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFMEMORY { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFOBJECT { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFQUEUE { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFREQUEST { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFSPINLOCK { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFSTRING { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFTIMER { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFUSBDEVICE { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFUSBINTERFACE { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFUSBPIPE { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFWAITLOCK { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFWMIINSTANCE { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFWMIPROVIDER { }

	/// <summary>Device handle</summary>
	[AutoHandle]
	public partial struct WDFWORKITEM { }
}