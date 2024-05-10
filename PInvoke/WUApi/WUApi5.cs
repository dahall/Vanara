namespace Vanara.PInvoke;

/// <summary>PInvoke API (methods, structures and constants) imported from Windows Update API.</summary>
public static partial class WUApi
{
	/// <summary>Contains the properties that are available only from a Windows driver update.</summary>
	/// <remarks>None of the IWindowsDriverUpdateEntry properties are expected to return any errors (other than E_POINTER if <c>NULL</c> is passed to the property).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iwindowsdriverupdateentry
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IWindowsDriverUpdateEntry")]
	[ComImport, Guid("ED8BFE40-A60B-42EA-9652-817DFCFA23EC")]
	public interface IWindowsDriverUpdateEntry
	{
		/// <summary>
		/// <para>The <c>DriverClass</c> property retrieves the class of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdateentry-get_driverclass
		// HRESULT get_DriverClass( BSTR *retval );
		[DispId(1610809345)]
		string? DriverClass
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the hardware or the compatible identifier that the Windows driver update must match to be installable.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdateentry-get_driverhardwareid
		// HRESULT get_DriverHardwareID( BSTR *retval );
		[DispId(1610809346)]
		string? DriverHardwareID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809346)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant name of the manufacturer of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdateentry-get_drivermanufacturer
		// HRESULT get_DriverManufacturer( BSTR *retval );
		[DispId(1610809347)]
		string? DriverManufacturer
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809347)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant model name of the device for which the Windows driver update is intended.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdateentry-get_drivermodel
		// HRESULT get_DriverModel( BSTR *retval );
		[DispId(1610809348)]
		string? DriverModel
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809348)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant name of the provider of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdateentry-get_driverprovider
		// HRESULT get_DriverProvider( BSTR *retval );
		[DispId(1610809349)]
		string? DriverProvider
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809349)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the driver version date of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdateentry-get_driververdate
		// HRESULT get_DriverVerDate( DATE *retval );
		[DispId(1610809350)]
		DateTime DriverVerDate
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809350)]
			get;
		}

		/// <summary>
		/// <para>Gets the problem number of the matching device for the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdateentry-get_deviceproblemnumber
		// HRESULT get_DeviceProblemNumber( LONG *retval );
		[DispId(1610809351)]
		int DeviceProblemNumber
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809351)]
			get;
		}

		/// <summary>
		/// <para>Gets the status of the matching device for the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdateentry-get_devicestatus
		// HRESULT get_DeviceStatus( LONG *retval );
		[DispId(1610809352)]
		int DeviceStatus
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809352)]
			get;
		}
	}

	/// <summary>Contains a collection of driver update entries associated with a driver update. All of the properties have the standard collection semantics.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iwindowsdriverupdateentrycollection
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IWindowsDriverUpdateEntryCollection")]
	[ComImport, Guid("0D521700-A372-4BEF-828B-3D00C10ADEBD")]
	public interface IWindowsDriverUpdateEntryCollection : IEnumerable
	{
		/// <summary>
		/// <para>Gets an IWindowsDriverUpdateEntry interface in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="index" />
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdateentrycollection-get_item
		// HRESULT get_Item( LONG index, IWindowsDriverUpdateEntry **retval );
		[DispId(0)]
		IWindowsDriverUpdateEntry this[[In] int index]
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an IEnumVARIANT interface that is used to enumerate the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdateentrycollection-get__newenum
		// HRESULT get__NewEnum( IUnknown **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();

		/// <summary>
		/// <para>Gets the number of elements contained in the collection</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdateentrycollection-get_count
		// HRESULT get_Count( LONG *retval );
		[DispId(1610743809)]
		int Count
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}
	}

	/// <summary>Retrieves information about the version of Windows Update Agent (WUA).</summary>
	/// <remarks>
	/// <para>The <c>IWindowsUpdateAgentInfo</c> interface may require you to update WUA. For more information, see Updating Windows Update Agent.</para>
	/// <para>You can create an instance of this interface by using the WindowsUpdateAgentInfo coclass. Use the Microsoft.Update.AgentInfo program identifier to create the object.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iwindowsupdateagentinfo
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IWindowsUpdateAgentInfo")]
	[ComImport, Guid("85713FA1-7796-4FA2-BE3B-E2D6124DD373"), CoClass(typeof(WindowsUpdateAgentInfo))]
	public interface IWindowsUpdateAgentInfo
	{
		/// <summary>Retrieves version information about Windows Update Agent (WUA).</summary>
		/// <param name="varInfoIdentifier">
		/// <para>A literal string value that specifies the type of information that the <c>retval</c> parameter returns. The following table lists the current possible string values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>ApiMajorVersion</c></description>
		/// <description>Retrieves the current major version of WUA.</description>
		/// </listheader>
		/// <item>
		/// <description><c>ApiMinorVersion</c></description>
		/// <description>Retrieves the current minor version of WUA.</description>
		/// </item>
		/// <item>
		/// <description><c>ProductVersionString</c></description>
		/// <description>Retrieves the file version of the Wuapi.dll file in string format.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>Returns the major version of the WUA API as a <c>LONG</c> value within the <c>VARIANT</c> variable if the value of the <c>varInfoIdentifier</c> parameter is <c>ApiMajorVersion</c>.</description>
		/// </item>
		/// <item>
		/// <description>Returns the minor version of the WUA API as a <c>LONG</c> value within the <c>VARIANT</c> variable if the value of <c>varInfoIdentifier</c> is <c>ApiMinorVersion</c>.</description>
		/// </item>
		/// <item>
		/// <description>Returns the file version of the Wuapi.dll file as a <c>BSTR</c> value within the <c>VARIANT</c> variable if the value of <c>varInfoIdentifier</c> is <c>ProductVersionString</c>.</description>
		/// </item>
		/// </list>
		/// <para><c>Note</c>  The format of a returned string is as follows: "<c>&lt;Windows-major-version&gt;</c>.<c>&lt;Windows-minor-version&gt;</c>.<c>&lt;build&gt;</c>.<c>&lt;update&gt;</c>".</para>
		/// </returns>
		/// <remarks>
		/// <para>The IWindowsUpdateAgentInfo interface may require you to update WUA. For more information, see Updating Windows Update Agent.</para>
		/// <para>The major version is incremented one time for each release if a change occurs in the interfaces of the WUA API. The minor version is incremented one time for each release if a change occurs in the existing interfaces of the WUA API.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsupdateagentinfo-getinfo
		// HRESULT GetInfo( [in] VARIANT varInfoIdentifier, [out] VARIANT *retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetInfo([In, MarshalAs(UnmanagedType.Struct)] object varInfoIdentifier);
	}

	/// <summary>
	/// CLSID_AutomaticUpdates
	/// </summary>
	[ComImport, Guid("BFE18E9C-6D87-4450-B37C-E02F0B373803"), ClassInterface(ClassInterfaceType.None)]
	public class AutomaticUpdates { }

	/// <summary>
	/// CLSID_InstallationAgent
	/// </summary>
	[ComImport, Guid("317E92FC-1679-46FD-A0B5-F08914DD8623"), ClassInterface(ClassInterfaceType.None)]
	public class InstallationAgent { }

	/// <summary>
	/// CLSID_StringCollection
	/// </summary>
	[ComImport, Guid("72C97D74-7C3B-40AE-B77D-ABDB22EBA6FB"), ClassInterface(ClassInterfaceType.None)]
	public class StringCollection { }

	/// <summary>
	/// CLSID_SystemInformation
	/// </summary>
	[ComImport, Guid("C01B9BA0-BEA7-41BA-B604-D0A36F469133"), ClassInterface(ClassInterfaceType.None)]
	public class SystemInformation { }

	/// <summary>
	/// CLSID_UpdateCollection
	/// </summary>
	[ComImport, Guid("13639463-00DB-4646-803D-528026140D88"), ClassInterface(ClassInterfaceType.None)]
	public class UpdateCollection { }

	/// <summary>
	/// CLSID_UpdateDownloader
	/// </summary>
	[ComImport, Guid("5BAF654A-5A07-4264-A255-9FF54C7151E7"), ClassInterface(ClassInterfaceType.None)]
	public class UpdateDownloader { }

	/// <summary>
	/// CLSID_UpdateInstaller
	/// </summary>
	[ComImport, Guid("D2E0FE7F-D23E-48E1-93C0-6FA8CC346474"), ClassInterface(ClassInterfaceType.None)]
	public class UpdateInstaller { }

	/// <summary>
	/// CLSID_UpdateSearcher
	/// </summary>
	[ComImport, Guid("B699E5E8-67FF-4177-88B0-3684A3388BFB"), ClassInterface(ClassInterfaceType.None)]
	public class UpdateSearcher { }

	/// <summary>
	/// CLSID_UpdateServiceManager
	/// </summary>
	[ComImport, Guid("F8D253D9-89A4-4DAA-87B6-1168369F0B21"), ClassInterface(ClassInterfaceType.None)]
	public class UpdateServiceManager { }

	/// <summary>
	/// CLSID_UpdateSession
	/// </summary>
	[ComImport, Guid("4CB43D7F-7EEE-4906-8698-60DA1C38F2FE"), ClassInterface(ClassInterfaceType.None)]
	public class UpdateSession { }

	/// <summary>
	/// CLSID_WebProxy
	/// </summary>
	[ComImport, Guid("650503CF-9108-4DDC-A2CE-6C2341E1C582"), ClassInterface(ClassInterfaceType.None)]
	public class WebProxy { }

	/// <summary>
	/// CLSID_WindowsUpdateAgentInfo
	/// </summary>
	[ComImport, Guid("C2E88C2F-6F5B-4AAA-894B-55C847AD3A2D"), ClassInterface(ClassInterfaceType.None)]
	public class WindowsUpdateAgentInfo { }
}