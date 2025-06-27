#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System.Collections;
using Vanara.Collections;
using static Vanara.PInvoke.TAPI2;

namespace Vanara.PInvoke;

public static partial class TAPI3
{
	/// <summary>
	/// The <b>IEnumACDGroup</b> interface provides COM-standard enumeration methods for the <c>ITACDGroup</c> interface. The
	/// <c>ITAgentHandler::EnumerateACDGroups</c> method returns a pointer to <b>IEnumACDGroup</b>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3cc/nn-tapi3cc-ienumacdgroup
	[PInvokeData("tapi3cc.h", MSDNShortId = "NN:tapi3cc.IEnumACDGroup")]
	[ComImport, Guid("5AFC3157-4BCC-11D1-BF80-00805FC147D3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumACDGroup : ICOMEnum<ITACDGroup>
	{
		/// <summary>The <b>Next</b> method gets the next specified number of elements in the enumeration sequence.</summary>
		/// <param name="celt">Number of elements requested.</param>
		/// <param name="ppElements">Pointer to <c>ITACDGroup</c> list of pointers returned.</param>
		/// <param name="pceltFetched">Pointer to number of elements actually supplied. May be <b>NULL</b> if <i>celt</i> is one.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><b>S_OK</b></description>
		/// <description>Method returned <i>celt</i> number of elements.</description>
		/// </item>
		/// <item>
		/// <description><b>S_FALSE</b></description>
		/// <description>Number of elements remaining was less than <i>celt</i>.</description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b></description>
		/// <description>Insufficient memory exists to perform the operation.</description>
		/// </item>
		/// <item>
		/// <description><b>E_POINTER</b></description>
		/// <description>The <i>ppElements</i> parameter is not a valid pointer.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// TAPI calls the <b>AddRef</b> method on the <c>ITACDGroup</c> interface returned by <b>IEnumACDGroup::Next</b>. The application
		/// must call <b>Release</b> on the <b>ITACDGroup</b> interface to free resources associated with it.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3/nf-tapi3-ienumacdgroup-next HRESULT Next( [in] ULONG celt, [out]
		// ITACDGroup **ppElements, [in, out] ULONG *pceltFetched );
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ITACDGroup[]? ppElements, out uint pceltFetched);

		/// <summary>The <b>Reset</b> method resets the enumeration sequence to the beginning.</summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><b>S_OK</b></description>
		/// <description>Method succeeded.</description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b></description>
		/// <description>Insufficient memory exists to perform the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3/nf-tapi3-ienumacdgroup-reset HRESULT Reset();
		void Reset();

		/// <summary>The <b>Skip</b> method skips over the next specified number of elements in the enumeration sequence.</summary>
		/// <param name="celt">Number of elements to skip.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><b>S_OK</b></description>
		/// <description>Number of elements skipped was <i>celt</i>.</description>
		/// </item>
		/// <item>
		/// <description><b>S_FALSE</b></description>
		/// <description>Number of elements skipped was not <i>celt</i>.</description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b></description>
		/// <description>Insufficient memory exists to perform the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3cc/nf-tapi3cc-ienumacdgroup-skip HRESULT Skip( [in] ULONG celt );
		[PreserveSig]
		HRESULT Skip([In] uint celt);

		/// <summary>The <b>Clone</b> method creates another enumerator that contains the same enumeration state as the current one.</summary>
		/// <returns>Pointer to new <c>IEnumACDGroup</c> interface.</returns>
		/// <remarks>
		/// TAPI calls the <b>AddRef</b> method on the <c>IEnumACDGroup</c> interface returned by <b>IEnumACDGroup::Clone</b>. The
		/// application must call <b>Release</b> on the <b>IEnumACDGroup</b> interface to free resources associated with it.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3/nf-tapi3-ienumacdgroup-clone HRESULT Clone( [out] IEnumACDGroup **ppEnum );
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumACDGroup Clone();
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("1666FCA1-9363-11D0-835C-00AA003CCABD")]
	public interface IEnumAddress : ICOMEnum<ITAddress>
	{
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ITAddress[]? ppElements, out uint pceltFetched);

		void Reset();

		[PreserveSig]
		HRESULT Skip([In] uint celt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumAddress Clone();
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("587E8C28-9802-11D1-A0A4-00805FC147D3")]
	public interface IEnumAgentHandler : ICOMEnum<ITAgentHandler>
	{
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ITAgentHandler[]? ppElements, out uint pceltFetched);

		void Reset();

		[PreserveSig]
		HRESULT Skip([In] uint celt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumAgentHandler Clone();
	}

	[ComImport, Guid("5AFC314E-4BCC-11D1-BF80-00805FC147D3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumAgentSession : ICOMEnum<ITAgentSession>
	{
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ITAgentSession[]? ppElements, out uint pceltFetched);

		void Reset();

		[PreserveSig]
		HRESULT Skip([In] uint celt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumAgentSession Clone();
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("35372049-0BC6-11D2-A033-00C04FB6809F")]
	public interface IEnumBstr : ICOMEnum<string>
	{
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] string[]? ppElements, out uint pceltFetched);

		void Reset();

		[PreserveSig]
		HRESULT Skip([In] uint celt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumBstr Clone();
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("AE269CF6-935E-11D0-835C-00AA003CCABD")]
	public interface IEnumCall : ICOMEnum<ITCallInfo>
	{
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ITCallInfo[]? ppElements, out uint pceltFetched);

		void Reset();

		[PreserveSig]
		HRESULT Skip([In] uint celt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumCall Clone();
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("A3C15450-5B92-11D1-8F4E-00C04FB6809F")]
	public interface IEnumCallHub : ICOMEnum<ITCallHub>
	{
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ITCallHub[]? ppElements, out uint pceltFetched);

		void Reset();

		[PreserveSig]
		HRESULT Skip([In] uint celt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumCallHub Clone();
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0C4D8F02-8DDB-11D1-A09E-00805FC147D3")]
	public interface IEnumCallingCard : ICOMEnum<ITCallingCard>
	{
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ITCallingCard[]? ppElements, out uint pceltFetched);

		void Reset();

		[PreserveSig]
		HRESULT Skip([In] uint celt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumCallingCard Clone();
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0C4D8F01-8DDB-11D1-A09E-00805FC147D3")]
	public interface IEnumLocation : ICOMEnum<ITLocationInfo>
	{
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ITLocationInfo[]? ppElements, out uint pceltFetched);

		void Reset();

		[PreserveSig]
		HRESULT Skip([In] uint celt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumLocation Clone();
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("F15B7669-4780-4595-8C89-FB369C8CF7AA")]
	public interface IEnumPhone : ICOMEnum<ITPhone>
	{
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ITPhone[]? ppElements, out uint pceltFetched);

		void Reset();

		[PreserveSig]
		HRESULT Skip([In] uint celt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumPhone Clone();
	}

	[ComImport, Guid("E9586A80-89E6-4CFF-931D-478D5751F4C0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumPluggableSuperclassInfo : ICOMEnum<ITPluggableTerminalSuperclassInfo>
	{
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ITPluggableTerminalSuperclassInfo[]? ppElements, out uint pceltFetched);

		void Reset();

		[PreserveSig]
		HRESULT Skip([In] uint celt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumPluggableSuperclassInfo Clone();
	}

	[ComImport, Guid("4567450C-DBEE-4E3F-AAF5-37BF9EBF5E29"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumPluggableTerminalClassInfo : ICOMEnum<ITPluggableTerminalClassInfo>
	{
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ITPluggableTerminalClassInfo[]? ppElements, out uint pceltFetched);

		void Reset();

		[PreserveSig]
		HRESULT Skip([In] uint celt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumPluggableTerminalClassInfo Clone();
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5AFC3158-4BCC-11D1-BF80-00805FC147D3")]
	public interface IEnumQueue : ICOMEnum<ITQueue>
	{
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ITQueue[]? ppElements, out uint pceltFetched);

		void Reset();

		[PreserveSig]
		HRESULT Skip([In] uint celt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumQueue Clone();
	}

	[ComImport, Guid("EE3BD606-3868-11D2-A045-00C04FB6809F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumStream : ICOMEnum<ITStream>
	{
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ITStream[]? ppElements, out uint pceltFetched);

		void Reset();

		[PreserveSig]
		HRESULT Skip([In] uint celt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumStream Clone();
	}

	[ComImport, Guid("EE3BD609-3868-11D2-A045-00C04FB6809F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumSubStream : ICOMEnum<ITSubStream>
	{
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ITSubStream[]? ppElements, out uint pceltFetched);

		void Reset();

		[PreserveSig]
		HRESULT Skip([In] uint celt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumSubStream Clone();
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("AE269CF4-935E-11D0-835C-00AA003CCABD")]
	public interface IEnumTerminal : ICOMEnum<ITTerminal>
	{
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ITTerminal[]? ppElements, out uint pceltFetched);

		void Reset();

		[PreserveSig]
		HRESULT Skip([In] uint celt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumTerminal Clone();
	}

	[ComImport, Guid("AE269CF5-935E-11D0-835C-00AA003CCABD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumTerminalClass : ICOMEnum<Guid>
	{
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] Guid[]? ppElements, out uint pceltFetched);

		void Reset();

		[PreserveSig]
		HRESULT Skip([In] uint celt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumTerminalClass Clone();
	}

	[ComImport, Guid("00000100-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumUnknown : ICOMEnum<object>
	{
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] object[]? ppElements, out uint pceltFetched);

		void Reset();

		[PreserveSig]
		HRESULT Skip([In] uint celt);

		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumUnknown Clone();
	}

	[ComImport, Guid("5AFC3148-4BCC-11D1-BF80-00805FC147D3")]
	public interface ITACDGroup
	{
		[DispId(1)]
		string? Name
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(2)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumQueue? EnumerateQueues();

		[DispId(3)]
		object Queues
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}
	}

	[ComImport, Guid("297F3032-BD11-11D1-A0A7-00805FC147D3")]
	public interface ITACDGroupEvent
	{
		[DispId(1)]
		ITACDGroup? Group
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		ACDGROUP_EVENT Event
		{
			[DispId(2)]
			get;
		}
	}

	/// <summary>
	/// <para>
	/// The <b>ITAddress</b> interface is the base interface for the Address object. Applications use this interface to get information about
	/// and use the <c>Address object</c>.
	/// </para>
	/// <para>
	/// The <c>ITAddress2</c> interface derives from the <b>ITAddress</b> interface. <b>ITAddress2</b> adds methods to the Address object in
	/// order to support phone devices. The <c>IEnumAddress::Next</c> and <c>ITTapi::get_Addresses</c> methods create the <b>ITAddress</b> interface.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nn-tapi3if-itaddress
	[PInvokeData("tapi3if.h", MSDNShortId = "NN:tapi3if.ITAddress")]
	[ComImport, Guid("B1EFC386-9355-11D0-835C-00AA003CCABD")]
	public interface ITAddress
	{
		/// <summary>Gets the current state of the address.</summary>
		[DispId(65537)]
		ADDRESS_STATE State
		{
			[DispId(65537)]
			get;
		}

		/// <summary>Gets or sets the displayable name of the address.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itaddress-get_addressname
		[DispId(65538)]
		string AddressName
		{
			[DispId(65538)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// Gets the name of the Telephony Service Provider (TSP) that supports this address: for example, Unimdm.tsp for the Unimodem
		/// service provider or H323.tsp for the H323 service provider.
		/// </summary>
		[DispId(65539)]
		string ServiceProviderName
		{
			[DispId(65539)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets a pointer to the TAPI object that owns this address.</summary>
		[DispId(65540)]
		ITTAPI TAPIObject
		{
			[DispId(65540)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>CreateCall</b> method creates a new Call object that can be used to make an outgoing call and returns a pointer to the
		/// object's <c>ITBasicCallControl</c> interface. The newly created call is in the CS_IDLE <c>state</c> and has no media or terminals selected.
		/// </para>
		/// <para>
		/// Acceptable input values for call address, address type, and media types are specific to the telephony service provider that
		/// supports the current address. For information on TSPs shipped with Windows 2000, see <c>About The Telephony Service Provider
		/// (TSP)</c>. For third party TSPs, see the documentation provided by the vender.
		/// </para>
		/// </summary>
		/// <param name="pDestAddress">
		/// This <b>BSTR</b> string contains a destination address. The format is provider-specific. This pointer can be <b>NULL</b> for
		/// non-dialed addresses (such as with a hot phone) or when all dialing is performed using <c>ITBasicCallControl::Dial</c>.
		/// <b>NULL</b> in combination with a <b>NULL</b><i>pGroupID</i> in <c>ITBasicCallControl::Pickup</c> results in a group pickup.
		/// Service providers that have inverse multiplexing capabilities can allow an application to specify multiple addresses at once.
		/// </param>
		/// <param name="lAddressType">
		/// Contains an <c>address type</c> constant, such as LINEADDRESSTYPE_PHONENUMBER, which describes the format of the address. The
		/// value must be valid for this address. Use <c>ITAddressCapabilities::get_AddressCapability</c> with <i>AddressCap</i> set to
		/// AC_ADDRESSTYPES to verify the value.
		/// </param>
		/// <param name="lMediaTypes">Identifies the <c>media type</c> or types that will be involved in the call session.</param>
		/// <returns>Pointer to <c>ITBasicCallControl</c> interface.</returns>
		/// <remarks>
		/// <para>
		/// When the address type is LINEADDRESSTYPE_SDP, the application should call the <c>ITSDP::get_IsValid</c> method on
		/// <i>pDestAddress</i> to verify that the SDP information contained is properly constructed according to RFC 2327.
		/// </para>
		/// <para>
		/// Calls used as consultation calls, such as during a conference, transfer, or forward operation, must be created using this method.
		/// </para>
		/// <note>This method is not precisely the same as <c>lineMakeCall</c> in TAPI 2. It supplies TAPI with much of the same information,
		/// but parallel operations are not performed until <c>ITBasicCallControl::Connect</c> is called.</note>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itaddress-createcall HRESULT CreateCall( [in] BSTR
		// pDestAddress, [in] long lAddressType, [in] long lMediaTypes, [out] ITBasicCallControl **ppCall );
		[DispId(65541)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ITBasicCallControl CreateCall([In, MarshalAs(UnmanagedType.BStr)] string pDestAddress, [In] LINEADDRESSTYPE lAddressType, [In] TAPIMEDIATYPE lMediaTypes);

		/// <summary>Creates a collection of calls currently active on the address.</summary>
		[DispId(65542)]
		object Calls
		{
			[DispId(65542)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>The <b>EnumerateCalls</b> method enumerates calls on the current address.</summary>
		/// <returns>Pointer to an <c>IEnumCall</c> interface.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itaddress-enumeratecalls HRESULT EnumerateCalls( [out]
		// IEnumCall **ppCallEnum );
		[DispId(65543)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumCall EnumerateCalls();

		/// <summary>
		/// Gets the string which can be used to connect to this address. The string corresponds to the destination address string that
		/// another application would use to connect to this address, such as a phone number or an e-mail name.
		/// </summary>
		[DispId(65544)]
		string DialableAddress
		{
			[DispId(65544)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The <b>CreateForwardInfoObject</b> method creates the forwarding information object and returns an <c>ITForwardInformation</c>
		/// interface pointer. This interface exposes methods that allow an application to control aspects of how a call is forwarded, such
		/// as whether internal calls will be handled differently than external calls.
		/// </summary>
		/// <returns>Pointer to <c>ITForwardInformation</c> interface.</returns>
		/// <remarks>
		/// <para>The application must set information on a newly created <c>ITForwardInformation</c> object before the object can be used.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itaddress-createforwardinfoobject HRESULT
		// CreateForwardInfoObject( [out] ITForwardInformation **ppForwardInfo );
		[DispId(65546)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ITForwardInformation CreateForwardInfoObject();

		/// <summary>
		/// The Forward method forwards calls destined for the address according to the forwarding instructions contained in
		/// <c>ITForwardInformation</c>. If <i>pForwardInfo</i> is set to <b>NULL</b>, forwarding is canceled.
		/// </summary>
		/// <param name="pForwardInfo">Pointer to <c>ITForwardInformation</c> interface, or set to <b>NULL</b> to cancel forwarding.</param>
		/// <param name="pCall">
		/// Pointer to <c>ITBasicCallControl</c> interface for the consultation call, if required by the telephony environment. May be
		/// <b>NULL</b> if not required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><b>S_OK</b></description>
		/// <description>Method succeeded.</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b></description>
		/// <description>The address does not support forwarding, or <i>pCall</i> does not point to a valid call.</description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b></description>
		/// <description>Insufficient memory exists to perform the operation.</description>
		/// </item>
		/// <item>
		/// <description><b>E_POINTER</b></description>
		/// <description>The <i>pForwardInfo</i> or <i>pCall</i> parameter is not a valid pointer.</description>
		/// </item>
		/// <item>
		/// <description><b>TAPI_E_TIMEOUT</b></description>
		/// <description>The operation failed because the TAPI 3 DLL timed it out. The timeout interval is two minutes.</description>
		/// </item>
		/// <item>
		/// <description><b>LINEERR_</b></description>
		/// <description>See <c>LineForward</c> for error codes returned from this TAPI 2.1 function.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The information in <i>pForwardInfo</i> overrides any previous forwarding instructions.</para>
		/// <para>If <c>ITAddress::put_DoNotDisturb</c> is called with <i>fDoNotDisturb</i> set to VARIANT_FALSE, all forwarding is canceled.</para>
		/// <para>
		/// An application can determine whether non- <b>NULL</b> consultation call is required by calling
		/// <c>ITAddressCapabilities::get_AddressCapability</c> (AC_ADDRESSCAPFLAGS, <i>plCapability</i>) and checking whether the flag
		/// LINEADDRCAPFLAGS_FWDCONSULT, a member of <c>LINEADDRCAPFLAGS_ Constants</c>, has been set in <i>plCapability</i>. If it is set, a
		/// non- <b>NULL</b> value is required for the <i>pCall</i> parameter of the Forward method.
		/// </para>
		/// <para>The Forward method is, in part, a COM wrapper for the TAPI 2.1 <c>LineForward</c> function.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itaddress-forward HRESULT Forward( [in]
		// ITForwardInformation *pForwardInfo, [in] ITBasicCallControl *pCall );
		[DispId(65547)]
		[PreserveSig]
		HRESULT Forward([In, MarshalAs(UnmanagedType.Interface)] ITForwardInformation pForwardInfo, [In, MarshalAs(UnmanagedType.Interface)] ITBasicCallControl pCall);

		/// <summary>Gets a pointer to the current forwarding information object.</summary>
		[DispId(65548)]
		ITForwardInformation CurrentForwardInfo
		{
			[DispId(65548)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>Gets or sets a value indicating whether the address has a message waiting.</summary>
		[DispId(65550)]
		bool MessageWaiting
		{
			[DispId(65550)]
			[param: In]
			set;
			[DispId(65550)]
			get;
		}

		/// <summary>
		/// Gets or sets the current status of the do not disturb feature on the address. The do not disturb feature may not be available on
		/// all addresses.
		/// </summary>
		[DispId(65551)]
		bool DoNotDisturb
		{
			[DispId(65551)]
			[param: In]
			set;
			[DispId(65551)]
			get;
		}
	}

	[ComImport, Guid("B0AE5D9B-BE51-46C9-B0F7-DFA8A22A8BC4")]
	public interface ITAddress2 : ITAddress
	{
		/// <summary>Gets the current state of the address.</summary>
		[DispId(65537)]
		new ADDRESS_STATE State
		{
			[DispId(65537)]
			get;
		}

		/// <summary>Gets or sets the displayable name of the address.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itaddress-get_addressname
		[DispId(65538)]
		new string AddressName
		{
			[DispId(65538)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// Gets the name of the Telephony Service Provider (TSP) that supports this address: for example, Unimdm.tsp for the Unimodem
		/// service provider or H323.tsp for the H323 service provider.
		/// </summary>
		[DispId(65539)]
		new string ServiceProviderName
		{
			[DispId(65539)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets a pointer to the TAPI object that owns this address.</summary>
		[DispId(65540)]
		new ITTAPI TAPIObject
		{
			[DispId(65540)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>CreateCall</b> method creates a new Call object that can be used to make an outgoing call and returns a pointer to the
		/// object's <c>ITBasicCallControl</c> interface. The newly created call is in the CS_IDLE <c>state</c> and has no media or terminals selected.
		/// </para>
		/// <para>
		/// Acceptable input values for call address, address type, and media types are specific to the telephony service provider that
		/// supports the current address. For information on TSPs shipped with Windows 2000, see <c>About The Telephony Service Provider
		/// (TSP)</c>. For third party TSPs, see the documentation provided by the vender.
		/// </para>
		/// </summary>
		/// <param name="pDestAddress">
		/// This <b>BSTR</b> string contains a destination address. The format is provider-specific. This pointer can be <b>NULL</b> for
		/// non-dialed addresses (such as with a hot phone) or when all dialing is performed using <c>ITBasicCallControl::Dial</c>.
		/// <b>NULL</b> in combination with a <b>NULL</b><i>pGroupID</i> in <c>ITBasicCallControl::Pickup</c> results in a group pickup.
		/// Service providers that have inverse multiplexing capabilities can allow an application to specify multiple addresses at once.
		/// </param>
		/// <param name="lAddressType">
		/// Contains an <c>address type</c> constant, such as LINEADDRESSTYPE_PHONENUMBER, which describes the format of the address. The
		/// value must be valid for this address. Use <c>ITAddressCapabilities::get_AddressCapability</c> with <i>AddressCap</i> set to
		/// AC_ADDRESSTYPES to verify the value.
		/// </param>
		/// <param name="lMediaTypes">Identifies the <c>media type</c> or types that will be involved in the call session.</param>
		/// <returns>Pointer to <c>ITBasicCallControl</c> interface.</returns>
		/// <remarks>
		/// <para>
		/// When the address type is LINEADDRESSTYPE_SDP, the application should call the <c>ITSDP::get_IsValid</c> method on
		/// <i>pDestAddress</i> to verify that the SDP information contained is properly constructed according to RFC 2327.
		/// </para>
		/// <para>
		/// Calls used as consultation calls, such as during a conference, transfer, or forward operation, must be created using this method.
		/// </para>
		/// <note>This method is not precisely the same as <c>lineMakeCall</c> in TAPI 2. It supplies TAPI with much of the same information,
		/// but parallel operations are not performed until <c>ITBasicCallControl::Connect</c> is called.</note>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itaddress-createcall HRESULT CreateCall( [in] BSTR
		// pDestAddress, [in] long lAddressType, [in] long lMediaTypes, [out] ITBasicCallControl **ppCall );
		[DispId(65541)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new ITBasicCallControl CreateCall([In, MarshalAs(UnmanagedType.BStr)] string pDestAddress, [In] LINEADDRESSTYPE lAddressType, [In] TAPIMEDIATYPE lMediaTypes);

		/// <summary>Creates a collection of calls currently active on the address.</summary>
		[DispId(65542)]
		new object Calls
		{
			[DispId(65542)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>The <b>EnumerateCalls</b> method enumerates calls on the current address.</summary>
		/// <returns>Pointer to an <c>IEnumCall</c> interface.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itaddress-enumeratecalls HRESULT EnumerateCalls( [out]
		// IEnumCall **ppCallEnum );
		[DispId(65543)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IEnumCall EnumerateCalls();

		/// <summary>
		/// Gets the string which can be used to connect to this address. The string corresponds to the destination address string that
		/// another application would use to connect to this address, such as a phone number or an e-mail name.
		/// </summary>
		[DispId(65544)]
		new string DialableAddress
		{
			[DispId(65544)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The <b>CreateForwardInfoObject</b> method creates the forwarding information object and returns an <c>ITForwardInformation</c>
		/// interface pointer. This interface exposes methods that allow an application to control aspects of how a call is forwarded, such
		/// as whether internal calls will be handled differently than external calls.
		/// </summary>
		/// <returns>Pointer to <c>ITForwardInformation</c> interface.</returns>
		/// <remarks>
		/// <para>The application must set information on a newly created <c>ITForwardInformation</c> object before the object can be used.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itaddress-createforwardinfoobject HRESULT
		// CreateForwardInfoObject( [out] ITForwardInformation **ppForwardInfo );
		[DispId(65546)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new ITForwardInformation CreateForwardInfoObject();

		/// <summary>
		/// The Forward method forwards calls destined for the address according to the forwarding instructions contained in
		/// <c>ITForwardInformation</c>. If <i>pForwardInfo</i> is set to <b>NULL</b>, forwarding is canceled.
		/// </summary>
		/// <param name="pForwardInfo">Pointer to <c>ITForwardInformation</c> interface, or set to <b>NULL</b> to cancel forwarding.</param>
		/// <param name="pCall">
		/// Pointer to <c>ITBasicCallControl</c> interface for the consultation call, if required by the telephony environment. May be
		/// <b>NULL</b> if not required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><b>S_OK</b></description>
		/// <description>Method succeeded.</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b></description>
		/// <description>The address does not support forwarding, or <i>pCall</i> does not point to a valid call.</description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b></description>
		/// <description>Insufficient memory exists to perform the operation.</description>
		/// </item>
		/// <item>
		/// <description><b>E_POINTER</b></description>
		/// <description>The <i>pForwardInfo</i> or <i>pCall</i> parameter is not a valid pointer.</description>
		/// </item>
		/// <item>
		/// <description><b>TAPI_E_TIMEOUT</b></description>
		/// <description>The operation failed because the TAPI 3 DLL timed it out. The timeout interval is two minutes.</description>
		/// </item>
		/// <item>
		/// <description><b>LINEERR_</b></description>
		/// <description>See <c>LineForward</c> for error codes returned from this TAPI 2.1 function.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The information in <i>pForwardInfo</i> overrides any previous forwarding instructions.</para>
		/// <para>If <c>ITAddress::put_DoNotDisturb</c> is called with <i>fDoNotDisturb</i> set to VARIANT_FALSE, all forwarding is canceled.</para>
		/// <para>
		/// An application can determine whether non- <b>NULL</b> consultation call is required by calling
		/// <c>ITAddressCapabilities::get_AddressCapability</c> (AC_ADDRESSCAPFLAGS, <i>plCapability</i>) and checking whether the flag
		/// LINEADDRCAPFLAGS_FWDCONSULT, a member of <c>LINEADDRCAPFLAGS_ Constants</c>, has been set in <i>plCapability</i>. If it is set, a
		/// non- <b>NULL</b> value is required for the <i>pCall</i> parameter of the Forward method.
		/// </para>
		/// <para>The Forward method is, in part, a COM wrapper for the TAPI 2.1 <c>LineForward</c> function.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itaddress-forward HRESULT Forward( [in]
		// ITForwardInformation *pForwardInfo, [in] ITBasicCallControl *pCall );
		[DispId(65547)]
		[PreserveSig]
		new HRESULT Forward([In, MarshalAs(UnmanagedType.Interface)] ITForwardInformation pForwardInfo, [In, MarshalAs(UnmanagedType.Interface)] ITBasicCallControl pCall);

		/// <summary>Gets a pointer to the current forwarding information object.</summary>
		[DispId(65548)]
		new ITForwardInformation CurrentForwardInfo
		{
			[DispId(65548)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>Gets or sets a value indicating whether the address has a message waiting.</summary>
		[DispId(65550)]
		new bool MessageWaiting
		{
			[DispId(65550)]
			[param: In]
			set;
			[DispId(65550)]
			get;
		}

		/// <summary>
		/// Gets or sets the current status of the do not disturb feature on the address. The do not disturb feature may not be available on
		/// all addresses.
		/// </summary>
		[DispId(65551)]
		new bool DoNotDisturb
		{
			[DispId(65551)]
			[param: In]
			set;
			[DispId(65551)]
			get;
		}

		[DispId(65552)]
		object Phones
		{
			[DispId(65552)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(65553)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumPhone EnumeratePhones();

		[DispId(65554)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ITPhone GetPhoneFromTerminal([In, MarshalAs(UnmanagedType.Interface)] ITTerminal pTerminal);

		[DispId(65556)]
		object PreferredPhones
		{
			[DispId(65556)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(65557)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumPhone EnumeratePreferredPhones();

		[DispId(65555)]
		bool EventFilter
		{
			[DispId(65555)]
			get;
			[DispId(65555)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>DeviceSpecific</b> method enables service providers to provide access to features not offered by other TAPI functions. The
		/// meaning of the extensions are device specific, and taking advantage of these extensions requires the application to be fully
		/// aware of them.
		/// </para>
		/// <para>
		/// This method is provided for C and C++ applications. Automation client applications, such as those written in Visual Basic, must
		/// use the <c>DeviceSpecificVariant</c> method.
		/// </para>
		/// </summary>
		/// <param name="pCall">Pointer to the <c>ITCallInfo</c> interface of the call object.</param>
		/// <param name="pParams">
		/// Pointer to a memory area used to hold a parameter block. The format of this parameter block is device specific; TAPI passes its
		/// contents between the application and the service provider.
		/// </param>
		/// <param name="dwSize">Size, in bytes, of the parameter block area.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><b>S_OK</b></description>
		/// <description>Method succeeded.</description>
		/// </item>
		/// <item>
		/// <description><b>E_POINTER</b></description>
		/// <description>The <i>pParams</i> or <i>pCall</i> parameter is not a valid pointer.</description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b></description>
		/// <description>Insufficient memory exists to perform the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itaddress2-devicespecific HRESULT DeviceSpecific( [in]
		// ITCallInfo *pCall, [in] BYTE *pParams, [in] DWORD dwSize );
		[DispId(65558)]
		[PreserveSig]
		HRESULT DeviceSpecific([In, MarshalAs(UnmanagedType.Interface)] ITCallInfo pCall, [In] IntPtr pParams, [In] uint dwSize);

		[DispId(65559)]
		[PreserveSig]
		HRESULT DeviceSpecificVariant([In, MarshalAs(UnmanagedType.Interface)] ITCallInfo pCall, [In, MarshalAs(UnmanagedType.Struct)] object varDevSpecificByteArray);

		/// <summary>
		/// The <b>NegotiateExtVersion</b> method allows an application to negotiate an extension version to use with the specified line
		/// device. This method need not be called if the application does not support provider-specific extensions.
		/// </summary>
		/// <param name="lLowVersion">
		/// Least recent extension version of the extension identifier returned by <b>NegotiateExtVersion</b> that the application is
		/// compliant with. The high-order word is the major version number; the low-order word is the minor version number.
		/// </param>
		/// <param name="lHighVersion">
		/// Most recent extension version of the extension identifier returned by <b>NegotiateExtVersion</b> that the application is
		/// compliant with. The high-order word is the major version number; the low-order word is the minor version number.
		/// </param>
		/// <returns>
		/// Pointer to a <b>long</b> that contains the extension version number that was negotiated. If negotiation succeeds, this number is
		/// in the range between <i>lLowVersion</i> and <i>lHighVersion</i>.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itaddress2-negotiateextversion HRESULT NegotiateExtVersion(
		// [in] long lLowVersion, [in] long lHighVersion, [out] long *plExtVersion );
		[DispId(65560)]
		int NegotiateExtVersion([In] int lLowVersion, [In] int lHighVersion);
	}

	[ComImport, Guid("8DF232F5-821B-11D1-BB5C-00C04FB6809F")]
	public interface ITAddressCapabilities
	{
		[DispId(131073)]
		int AddressCapability
		{
			[DispId(131073)]
			get;
		}

		[DispId(131074)]
		string AddressCapabilityString
		{
			[DispId(131074)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(131075)]
		object CallTreatments
		{
			[DispId(131075)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(131076)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumBstr EnumerateCallTreatments();

		[DispId(131077)]
		object CompletionMessages
		{
			[DispId(131077)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(131078)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumBstr EnumerateCompletionMessages();

		[DispId(131079)]
		object DeviceClasses
		{
			[DispId(131079)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(131080)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumBstr EnumerateDeviceClasses();
	}

	[ComImport, Guid("3ACB216B-40BD-487A-8672-5CE77BD7E3A3")]
	public interface ITAddressDeviceSpecificEvent
	{
		[DispId(1)]
		ITAddress Address
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		ITCallInfo Call
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(3)]
		int lParam1
		{
			get;
		}

		[DispId(4)]
		int lParam2
		{
			get;
		}

		[DispId(5)]
		int lParam3
		{
			get;
		}
	}

	[ComImport, Guid("831CE2D1-83B5-11D1-BB5C-00C04FB6809F")]
	public interface ITAddressEvent
	{
		[DispId(1)]
		ITAddress Address
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		ADDRESS_EVENT Event
		{
			get;
		}

		[DispId(3)]
		ITTerminal Terminal
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	[ComImport, Guid("0C4D8F03-8DDB-11D1-A09E-00805FC147D3")]
	public interface ITAddressTranslation
	{
		/// <summary>
		/// The <b>TranslateAddress</b> method creates the address translation information interface. The primary goal of the
		/// <b>TranslateAddress</b> method is to obtain the <i>pDestAddress</i> string ( <c>dialable address</c>) needed as a parameter for
		/// <c>ITAddress::CreateCall</c>. The <b>TranslateAddress</b> method returns the dialable address indirectly, as one of the
		/// properties of an <c>ITAddressTranslationInfo</c> object.
		/// </summary>
		/// <param name="pAddressToTranslate">Pointer to <b>BSTR</b> containing address that requires translation.</param>
		/// <param name="lCard">Calling card used for translation.</param>
		/// <param name="lTranslateOptions">Indicator of translation options, see <c>LINETRANSLATEOPTION__Constants</c>.</param>
		/// <returns>Pointer to newly created <c>ITAddressTranslationInfo</c> interface.</returns>
		/// <remarks>
		///   <para>
		/// The application must use <c>SysAllocString</c> to allocate memory for <i>pAddressToTranslate</i> and use <c>SysFreeString</c> to
		/// free the memory when the variable is no longer needed.
		/// </para>
		///   <para>The <b>TranslateAddress</b> method is a COM wrapper for the TAPI 2.1 <c>LineTranslateAddress</c> function.</para>
		///   <para>
		/// TAPI calls the <b>AddRef</b> method on the <c>ITAddressTranslationInfo</c> interface returned by <b>TranslateAddress</b>. The
		/// application must call <b>Release</b> on the <b>ITAddressTranslationInfo</b> interface to free resources associated with it.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itaddresstranslation-translateaddress HRESULT
		// TranslateAddress( [in] BSTR pAddressToTranslate, [in] long lCard, [in] long lTranslateOptions, [out] ITAddressTranslationInfo
		// **ppTranslated );
		[DispId(262145)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ITAddressTranslationInfo TranslateAddress([In, MarshalAs(UnmanagedType.BStr)] string pAddressToTranslate, [In] int lCard, [In] LINETRANSLATEOPTION lTranslateOptions);

		[DispId(262146)]
		[PreserveSig]
		HRESULT TranslateDialog([In] long hwndOwner, [In, MarshalAs(UnmanagedType.BStr)] string pAddressIn);

		[DispId(262147)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumLocation EnumerateLocations();

		[DispId(262148)]
		object Locations
		{
			[DispId(262148)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(262149)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumCallingCard EnumerateCallingCards();

		[DispId(262150)]
		object CallingCards
		{
			[DispId(262150)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}
	}

	[ComImport, Guid("AFC15945-8D40-11D1-A09E-00805FC147D3")]
	public interface ITAddressTranslationInfo
	{
		[DispId(1)]
		string DialableString
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(2)]
		string DisplayableString
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(3)]
		int CurrentCountryCode
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		int DestinationCountryCode
		{
			[DispId(4)]
			get;
		}

		[DispId(5)]
		LINETRANSLATERESULT TranslationResults
		{
			[DispId(5)]
			get;
		}
	}

	[ComImport, Guid("5770ECE5-4B27-11D1-BF80-00805FC147D3")]
	public interface ITAgent
	{
		[DispId(1)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumAgentSession EnumerateAgentSessions();

		[DispId(2)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ITAgentSession CreateSession([In, MarshalAs(UnmanagedType.Interface)] ITACDGroup pACDGroup, [In, MarshalAs(UnmanagedType.Interface)] ITAddress pAddress);

		[DispId(3)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ITAgentSession CreateSessionWithPIN([In, MarshalAs(UnmanagedType.Interface)] ITACDGroup pACDGroup, [In, MarshalAs(UnmanagedType.Interface)] ITAddress pAddress, [In, MarshalAs(UnmanagedType.BStr)] string pPIN);

		[DispId(4)]
		string ID
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(5)]
		string User
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(6)]
		AGENT_STATE State
		{
			[DispId(6)]
			get;
			[DispId(6)]
			[param: In]
			set;
		}

		[DispId(7)]
		int MeasurementPeriod
		{
			[DispId(7)]
			get;
			[DispId(7)]
			[param: In]
			set;
		}

		[DispId(8)]
		decimal OverallCallRate
		{
			[DispId(8)]
#pragma warning disable CS0618 // Type or member is obsolete
			[return: MarshalAs(UnmanagedType.Currency)]
#pragma warning restore CS0618 // Type or member is obsolete
			get;
		}

		[DispId(9)]
		int NumberOfACDCalls
		{
			[DispId(9)]
			get;
		}

		[DispId(10)]
		int NumberOfIncomingCalls
		{
			[DispId(10)]
			get;
		}

		[DispId(11)]
		int NumberOfOutgoingCalls
		{
			[DispId(11)]
			get;
		}

		[DispId(12)]
		int TotalACDTalkTime
		{
			[DispId(12)]
			get;
		}

		[DispId(13)]
		int TotalACDCallTime
		{
			[DispId(13)]
			get;
		}

		[DispId(14)]
		int TotalWrapUpTime
		{
			[DispId(14)]
			get;
		}

		[DispId(15)]
		object AgentSessions
		{
			[DispId(15)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}
	}

	[ComImport, Guid("5AFC314A-4BCC-11D1-BF80-00805FC147D3")]
	public interface ITAgentEvent
	{
		[DispId(1)]
		ITAgent Agent
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		AGENT_EVENT Event
		{
			[DispId(2)]
			get;
		}
	}

	[ComImport, Guid("587E8C22-9802-11D1-A0A4-00805FC147D3")]
	public interface ITAgentHandler
	{
		[DispId(1)]
		string Name
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(2)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ITAgent CreateAgent();

		[DispId(3)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ITAgent CreateAgentWithID([In, MarshalAs(UnmanagedType.BStr)] string pID, [In, MarshalAs(UnmanagedType.BStr)] string pPIN);

		[DispId(4)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumACDGroup EnumerateACDGroups();

		[DispId(5)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumAddress EnumerateUsableAddresses();

		[DispId(6)]
		object ACDGroups
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(7)]
		object UsableAddresses
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}
	}

	[ComImport, Guid("297F3034-BD11-11D1-A0A7-00805FC147D3")]
	public interface ITAgentHandlerEvent
	{
		[DispId(1)]
		ITAgentHandler AgentHandler
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		AGENTHANDLER_EVENT Event
		{
			[DispId(2)]
			get;
		}
	}

	[ComImport, Guid("5AFC3147-4BCC-11D1-BF80-00805FC147D3")]
	public interface ITAgentSession
	{
		[DispId(1)]
		ITAgent Agent
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		ITAddress Address
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(3)]
		ITACDGroup ACDGroup
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(4)]
		AGENT_SESSION_STATE State
		{
			[DispId(4)]
			get;
			[DispId(4)]
			[param: In]
			set;
		}

		[DispId(5)]
		DateTime SessionStartTime
		{
			[DispId(5)]
			get;
		}

		[DispId(6)]
		int SessionDuration
		{
			[DispId(6)]
			get;
		}

		[DispId(7)]
		int NumberOfCalls
		{
			[DispId(7)]
			get;
		}

		[DispId(8)]
		int TotalTalkTime
		{
			[DispId(8)]
			get;
		}

		[DispId(9)]
		int AverageTalkTime
		{
			[DispId(9)]
			get;
		}

		[DispId(10)]
		int TotalCallTime
		{
			[DispId(10)]
			get;
		}

		[DispId(11)]
		int AverageCallTime
		{
			[DispId(11)]
			get;
		}

		[DispId(12)]
		int TotalWrapUpTime
		{
			[DispId(12)]
			get;
		}

		[DispId(13)]
		int AverageWrapUpTime
		{
			[DispId(13)]
			get;
		}

		[DispId(14)]
		decimal ACDCallRate
		{
			[DispId(14)]
#pragma warning disable CS0618 // Type or member is obsolete
			[return: MarshalAs(UnmanagedType.Currency)]
#pragma warning restore CS0618 // Type or member is obsolete
			get;
		}

		[DispId(15)]
		int LongestTimeToAnswer
		{
			[DispId(15)]
			get;
		}

		[DispId(16)]
		int AverageTimeToAnswer
		{
			[DispId(16)]
			get;
		}
	}

	[ComImport, Guid("5AFC314B-4BCC-11D1-BF80-00805FC147D3")]
	public interface ITAgentSessionEvent
	{
		[DispId(1)]
		ITAgentSession Session
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		AGENT_SESSION_EVENT Event
		{
			[DispId(2)]
			get;
		}
	}

	[ComImport, Guid("EE016A02-4FA9-467C-933F-5A15B12377D7")]
	public interface ITASRTerminalEvent
	{
		[DispId(1)]
		ITTerminal Terminal
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		ITCallInfo Call
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(3)]
		HRESULT Error
		{
			get;
		}
	}

	[ComImport, Guid("1EE1AF0E-6159-4A61-B79B-6A4BA3FC9DFC")]
	public interface ITAutomatedPhoneControl
	{
		[DispId(131073)]
		[PreserveSig]
		HRESULT StartTone([In] PHONE_TONE Tone, [In] int lDuration);

		[DispId(131074)]
		[PreserveSig]
		HRESULT StopTone();

		[DispId(131075)]
		PHONE_TONE Tone
		{
			[DispId(131075)]
			get;
		}

		[DispId(131076)]
		[PreserveSig]
		HRESULT StartRinger([In] int lRingMode, [In] int lDuration);

		[DispId(131077)]
		[PreserveSig]
		HRESULT StopRinger();

		[DispId(131078)]
		bool Ringer
		{
			[DispId(131078)]
			get;
		}

		[DispId(131079)]
		bool PhoneHandlingEnabled
		{
			[DispId(131079)]
			[param: In]
			set;
			[DispId(131079)]
			get;
		}

		[DispId(131080)]
		int AutoEndOfNumberTimeout
		{
			[DispId(131080)]
			[param: In]
			set;
			[DispId(131080)]
			get;
		}

		[DispId(131081)]
		bool AutoDialtone
		{
			[DispId(131081)]
			[param: In]
			set;
			[DispId(131081)]
			get;
		}

		[DispId(131082)]
		bool AutoStopTonesOnOnHook
		{
			[DispId(131082)]
			[param: In]
			set;
			[DispId(131082)]
			get;
		}

		[DispId(131083)]
		bool AutoStopRingOnOffHook
		{
			[DispId(131083)]
			[param: In]
			set;
			[DispId(131083)]
			get;
		}

		[DispId(131084)]
		bool AutoKeypadTones
		{
			[DispId(131084)]
			[param: In]
			set;
			[DispId(131084)]
			get;
		}

		[DispId(131085)]
		int AutoKeypadTonesMinimumDuration
		{
			[DispId(131085)]
			[param: In]
			set;
			[DispId(131085)]
			get;
		}

		[DispId(131086)]
		bool AutoVolumeControl
		{
			[DispId(131086)]
			[param: In]
			set;
			[DispId(131086)]
			get;
		}

		[DispId(131087)]
		int AutoVolumeControlStep
		{
			[DispId(131087)]
			[param: In]
			set;
			[DispId(131087)]
			get;
		}

		[DispId(131088)]
		int AutoVolumeControlRepeatDelay
		{
			[DispId(131088)]
			[param: In]
			set;
			[DispId(131088)]
			get;
		}

		[DispId(131089)]
		int AutoVolumeControlRepeatPeriod
		{
			[DispId(131089)]
			[param: In]
			set;
			[DispId(131089)]
			get;
		}

		[DispId(131090)]
		[PreserveSig]
		HRESULT SelectCall([In, MarshalAs(UnmanagedType.Interface)] ITCallInfo pCall, [In] bool fSelectDefaultTerminals);

		[DispId(131091)]
		[PreserveSig]
		HRESULT UnselectCall([In, MarshalAs(UnmanagedType.Interface)] ITCallInfo pCall);

		[DispId(131092)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumCall EnumerateSelectedCalls();

		[DispId(131093)]
		object SelectedCalls
		{
			[DispId(131093)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}
	}

	[ComImport, Guid("B1EFC38D-9355-11D0-835C-00AA003CCABD")]
	public interface ITBasicAudioTerminal
	{
		[DispId(1)]
		int Volume
		{
			[DispId(1)]
			[param: In]
			set;
			[DispId(1)]
			get;
		}

		[DispId(2)]
		int Balance
		{
			[DispId(2)]
			[param: In]
			set;
			[DispId(2)]
			get;
		}
	}

	[ComImport, Guid("B1EFC389-9355-11D0-835C-00AA003CCABD")]
	public interface ITBasicCallControl
	{
		[DispId(131075)]
		[PreserveSig]
		HRESULT Connect([In] bool fSync);

		[DispId(131076)]
		[PreserveSig]
		HRESULT Answer();

		[DispId(131077)]
		[PreserveSig]
		HRESULT Disconnect([In] DISCONNECT_CODE code);

		[DispId(131078)]
		[PreserveSig]
		HRESULT Hold([In] bool fHold);

		[DispId(131079)]
		[PreserveSig]
		HRESULT HandoffDirect([In, MarshalAs(UnmanagedType.BStr)] string pApplicationName);

		[DispId(131080)]
		[PreserveSig]
		HRESULT HandoffIndirect([In] TAPIMEDIATYPE lMediaType);

		[DispId(131081)]
		[PreserveSig]
		HRESULT Conference([In, MarshalAs(UnmanagedType.Interface)] ITBasicCallControl pCall, [In] bool fSync);

		[DispId(131082)]
		[PreserveSig]
		HRESULT Transfer([In, MarshalAs(UnmanagedType.Interface)] ITBasicCallControl pCall, [In] bool fSync);

		[DispId(131083)]
		[PreserveSig]
		HRESULT BlindTransfer([In, MarshalAs(UnmanagedType.BStr)] string pDestAddress);

		[DispId(131084)]
		[PreserveSig]
		HRESULT SwapHold([In, MarshalAs(UnmanagedType.Interface)] ITBasicCallControl pCall);

		[DispId(131085)]
		[PreserveSig]
		HRESULT ParkDirect([In, MarshalAs(UnmanagedType.BStr)] string pParkAddress);

		[DispId(131086)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string ParkIndirect();

		[DispId(131087)]
		[PreserveSig]
		HRESULT Unpark();

		[DispId(131088)]
		[PreserveSig]
		HRESULT SetQOS([In] TAPIMEDIATYPE lMediaType, [In] QOS_SERVICE_LEVEL ServiceLevel);

		[DispId(131091)]
		[PreserveSig]
		HRESULT Pickup([In, MarshalAs(UnmanagedType.BStr)] string pGroupID);

		[DispId(131092)]
		[PreserveSig]
		HRESULT Dial([In, MarshalAs(UnmanagedType.BStr)] string pDestAddress);

		[DispId(131093)]
		[PreserveSig]
		HRESULT Finish([In] FINISH_MODE finishMode);

		[DispId(131094)]
		[PreserveSig]
		HRESULT RemoveFromConference();
	}

	[ComImport, Guid("161A4A56-1E99-4B3F-A46A-168F38A5EE4C")]
	public interface ITBasicCallControl2 : ITBasicCallControl
	{
		[DispId(131075)]
		new void Connect([In] bool fSync);

		[DispId(131076)]
		new void Answer();

		[DispId(131077)]
		new void Disconnect([In] DISCONNECT_CODE code);

		[DispId(131078)]
		new void Hold([In] bool fHold);

		[DispId(131079)]
		new void HandoffDirect([In, MarshalAs(UnmanagedType.BStr)] string pApplicationName);

		[DispId(131080)]
		new void HandoffIndirect([In] TAPIMEDIATYPE lMediaType);

		[DispId(131081)]
		new void Conference([In, MarshalAs(UnmanagedType.Interface)] ITBasicCallControl pCall, [In] bool fSync);

		[DispId(131082)]
		new void Transfer([In, MarshalAs(UnmanagedType.Interface)] ITBasicCallControl pCall, [In] bool fSync);

		[DispId(131083)]
		new void BlindTransfer([In, MarshalAs(UnmanagedType.BStr)] string pDestAddress);

		[DispId(131084)]
		new void SwapHold([In, MarshalAs(UnmanagedType.Interface)] ITBasicCallControl pCall);

		[DispId(131085)]
		new void ParkDirect([In, MarshalAs(UnmanagedType.BStr)] string pParkAddress);

		[DispId(131086)]
		[return: MarshalAs(UnmanagedType.BStr)]
		new string ParkIndirect();

		[DispId(131087)]
		new void Unpark();

		[DispId(131088)]
		new void SetQOS([In] TAPIMEDIATYPE lMediaType, [In] QOS_SERVICE_LEVEL ServiceLevel);

		[DispId(131091)]
		new void Pickup([In, MarshalAs(UnmanagedType.BStr)] string pGroupID);

		[DispId(131092)]
		new void Dial([In, MarshalAs(UnmanagedType.BStr)] string pDestAddress);

		[DispId(131093)]
		new void Finish([In] FINISH_MODE finishMode);

		[DispId(131094)]
		new void RemoveFromConference();

		[DispId(131095)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ITTerminal RequestTerminal([In, MarshalAs(UnmanagedType.BStr)] string bstrTerminalClassGUID, [In] TAPIMEDIATYPE lMediaType, [In] TERMINAL_DIRECTION Direction);

		[DispId(131096)]
		[PreserveSig]
		HRESULT SelectTerminalOnCall([In, MarshalAs(UnmanagedType.Interface)] ITTerminal pTerminal);

		[DispId(131097)]
		[PreserveSig]
		HRESULT UnselectTerminalOnCall([In, MarshalAs(UnmanagedType.Interface)] ITTerminal pTerminal);
	}

	[ComImport, Guid("A3C1544E-5B92-11D1-8F4E-00C04FB6809F")]
	public interface ITCallHub
	{
		[DispId(1)]
		[PreserveSig]
		HRESULT Clear();

		[DispId(2)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumCall EnumerateCalls();

		[DispId(3)]
		object Calls
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(4)]
		int NumCalls
		{
			[DispId(4)]
			get;
		}

		[DispId(5)]
		CALLHUB_STATE State
		{
			[DispId(5)]
			get;
		}
	}

	[ComImport, Guid("A3C15451-5B92-11D1-8F4E-00C04FB6809F")]
	public interface ITCallHubEvent
	{
		[DispId(1)]
		CALLHUB_EVENT Event
		{
			get;
		}

		[DispId(2)]
		ITCallHub CallHub
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(3)]
		ITCallInfo Call
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	[ComImport, Guid("350F85D1-1227-11D3-83D4-00C04FB6809F")]
	public interface ITCallInfo
	{
		[DispId(65537)]
		ITAddress Address
		{
			[DispId(65537)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(65538)]
		CALL_STATE CallState
		{
			[DispId(65538)]
			get;
		}

		[DispId(65539)]
		CALL_PRIVILEGE Privilege
		{
			[DispId(65539)]
			get;
		}

		[DispId(65540)]
		ITCallHub CallHub
		{
			[DispId(65540)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(65541)]
		int CallInfoLong
		{
			[DispId(65541)]
			get;
			[DispId(65541)]
			[param: In]
			set;
		}

		[DispId(65542)]
		string CallInfoString
		{
			[DispId(65542)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(65542)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(65543)]
		object CallInfoBuffer
		{
			[DispId(65543)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(65543)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Struct)]
			set;
		}

		[DispId(65544)]
		[PreserveSig]
		HRESULT GetCallInfoBuffer([In] CALLINFO_BUFFER CallInfoBuffer, out uint pdwSize, [Out] IntPtr ppCallInfoBuffer);

		[DispId(65545)]
		[PreserveSig]
		HRESULT SetCallInfoBuffer([In] CALLINFO_BUFFER CallInfoBuffer, [In] uint dwSize, [In] IntPtr pCallInfoBuffer);

		[DispId(65546)]
		[PreserveSig]
		HRESULT ReleaseUserUserInfo();
	}

	[ComImport, Guid("94D70CA6-7AB0-4DAA-81CA-B8F8643FAEC1")]
	public interface ITCallInfo2 : ITCallInfo
	{
		[DispId(65537)]
		new ITAddress Address
		{
			[DispId(65537)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(65538)]
		new CALL_STATE CallState
		{
			[DispId(65538)]
			get;
		}

		[DispId(65539)]
		new CALL_PRIVILEGE Privilege
		{
			[DispId(65539)]
			get;
		}

		[DispId(65540)]
		new ITCallHub CallHub
		{
			[DispId(65540)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(65541)]
		new int CallInfoLong
		{
			[DispId(65541)]
			get;
			[DispId(65541)]
			[param: In]
			set;
		}

		[DispId(65542)]
		new string CallInfoString
		{
			[DispId(65542)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(65542)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(65543)]
		new object CallInfoBuffer
		{
			[DispId(65543)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(65543)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Struct)]
			set;
		}

		[DispId(65544)]
		[PreserveSig]
		new HRESULT GetCallInfoBuffer([In] CALLINFO_BUFFER CallInfoBuffer, out uint pdwSize, [Out] IntPtr ppCallInfoBuffer);

		[DispId(65545)]
		[PreserveSig]
		new HRESULT SetCallInfoBuffer([In] CALLINFO_BUFFER CallInfoBuffer, [In] uint dwSize, [In] IntPtr pCallInfoBuffer);

		[DispId(65546)]
		new void ReleaseUserUserInfo();

		[DispId(65547)]
		bool EventFilter
		{
			[DispId(65547)]
			get;
			[DispId(65547)]
			[param: In]
			set;
		}
	}

	[ComImport, Guid("5D4B65F9-E51C-11D1-A02F-00C04FB6809F")]
	public interface ITCallInfoChangeEvent
	{
		[DispId(1)]
		ITCallInfo Call
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		CALLINFOCHANGE_CAUSE Cause
		{
			get;
		}

		[DispId(3)]
		int CallbackInstance
		{
			get;
		}
	}

	[ComImport, Guid("0C4D8F00-8DDB-11D1-A09E-00805FC147D3")]
	public interface ITCallingCard
	{
		[DispId(1)]
		int PermanentCardID
		{
			[DispId(1)]
			get;
		}

		[DispId(2)]
		int NumberOfDigits
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		LINETRANSLATEOPTION Options
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		string CardName
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(5)]
		string SameAreaDialingRule
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(6)]
		string LongDistanceDialingRule
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(7)]
		string InternationalDialingRule
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	[ComImport, Guid("FF36B87F-EC3A-11D0-8EE4-00C04FB6809F")]
	public interface ITCallMediaEvent
	{
		[DispId(1)]
		ITCallInfo Call
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		CALL_MEDIA_EVENT Event
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		HRESULT Error
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		ITTerminal Terminal
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(5)]
		ITStream Stream
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(6)]
		CALL_MEDIA_EVENT_CAUSE Cause
		{
			[DispId(6)]
			get;
		}
	}

	[ComImport, Guid("895801DF-3DD6-11D1-8F30-00C04FB6809F")]
	public interface ITCallNotificationEvent
	{
		[DispId(1)]
		ITCallInfo Call
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		CALL_NOTIFICATION_EVENT Event
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		int CallbackInstance
		{
			[DispId(3)]
			get;
		}
	}

	[ComImport, Guid("62F47097-95C9-11D0-835D-00AA003CCABD")]
	public interface ITCallStateEvent
	{
		[DispId(1)]
		ITCallInfo Call
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		CALL_STATE State
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		CALL_STATE_EVENT_CAUSE Cause
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		int CallbackInstance
		{
			[DispId(4)]
			get;
		}
	}

	[ComImport, Guid("5EC5ACF2-9C02-11D0-8362-00AA003CCABD")]
	public interface ITCollection : IEnumerable
	{
		[DispId(1610743808)]
		int Count
		{
			[DispId(1610743808)]
			get;
		}

		[DispId(0)]
		object this[[In] int Index]
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();
	}

	[ComImport, Guid("E6DDDDA5-A6D3-48FF-8737-D32FC4D95477")]
	public interface ITCollection2 : ITCollection
	{
		[DispId(1610743808)]
		new int Count
		{
			[DispId(1610743808)]
			get;
		}

		[DispId(0)]
		new object this[[In] int Index]
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();

		[DispId(1)]
		void Add([In] int Index, [In, MarshalAs(UnmanagedType.Struct)] in object pVariant);

		[DispId(2)]
		void Remove([In] int Index);
	}

	[ComImport, Guid("357AD764-B3C6-4B2A-8FA5-0722827A9254")]
	public interface ITCustomTone
	{
		[DispId(1)]
		int Frequency
		{
			[DispId(1)]
			get;
			[DispId(1)]
			[param: In]
			set;
		}

		[DispId(2)]
		int CadenceOn
		{
			[DispId(2)]
			get;
			[DispId(2)]
			[param: In]
			set;
		}

		[DispId(3)]
		int CadenceOff
		{
			[DispId(3)]
			get;
			[DispId(3)]
			[param: In]
			set;
		}

		[DispId(4)]
		int Volume
		{
			[DispId(4)]
			get;
			[DispId(4)]
			[param: In]
			set;
		}
	}

	[ComImport, Guid("961F79BD-3097-49DF-A1D6-909B77E89CA0")]
	public interface ITDetectTone
	{
		[DispId(1)]
		int AppSpecific
		{
			[DispId(1)]
			get;
			[DispId(1)]
			[param: In]
			set;
		}

		[DispId(2)]
		int Duration
		{
			[DispId(2)]
			get;
			[DispId(2)]
			[param: In]
			set;
		}

		[DispId(3)]
		int Frequency
		{
			[DispId(3)]
			get;
			[DispId(3)]
			[param: In]
			set;
		}
	}

	[ComImport, Guid("80D3BFAC-57D9-11D2-A04A-00C04FB6809F")]
	public interface ITDigitDetectionEvent
	{
		[DispId(1)]
		ITCallInfo Call
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		byte Digit
		{
			get;
		}

		[DispId(3)]
		TAPI_DIGITMODE DigitMode
		{
			get;
		}

		[DispId(4)]
		int TickCount
		{
			get;
		}

		[DispId(5)]
		int CallbackInstance
		{
			get;
		}
	}

	[ComImport, Guid("80D3BFAD-57D9-11D2-A04A-00C04FB6809F")]
	public interface ITDigitGenerationEvent
	{
		[DispId(1)]
		ITCallInfo Call
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		int GenerationTermination
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		int TickCount
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		int CallbackInstance
		{
			[DispId(4)]
			get;
		}
	}

	[ComImport, Guid("E52EC4C1-CBA3-441A-9E6A-93CB909E9724")]
	public interface ITDigitsGatheredEvent
	{
		[DispId(1)]
		ITCallInfo Call
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		string Digits
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(3)]
		TAPI_GATHERTERM GatherTermination
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		int TickCount
		{
			[DispId(4)]
			get;
		}

		[DispId(5)]
		int CallbackInstance
		{
			[DispId(5)]
			get;
		}
	}

	[ComImport, Guid("E9225295-C759-11D1-A02B-00C04FB6809F"), CoClass(typeof(DispatchMapper))]
	public interface ITDispatchMapper
	{
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object QueryDispatchInterface([In, MarshalAs(UnmanagedType.BStr)] string pIID, [In, MarshalAs(UnmanagedType.IDispatch)] object pInterfaceToMap);
	}

	[ComImport, Guid("E4A7FBAC-8C17-4427-9F55-9F589AC8AF00")]
	public interface ITFileTerminalEvent
	{
		[DispId(1)]
		ITTerminal Terminal
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		ITFileTrack Track
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(3)]
		ITCallInfo Call
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(4)]
		TERMINAL_MEDIA_STATE State
		{
			get;
		}

		[DispId(5)]
		FT_STATE_EVENT_CAUSE Cause
		{
			get;
		}

		[DispId(6)]
		HRESULT Error
		{
			get;
		}
	}

	[ComImport, Guid("31CA6EA9-C08A-4BEA-8811-8E9C1BA3EA3A")]
	public interface ITFileTrack
	{
		[DispId(65537)]
		StructPointer<AM_MEDIA_TYPE> Format
		{
			[DispId(65537)]
			get;
			[DispId(65537)]
			[param: In]
			set;
		}

		[DispId(65538)]
		ITTerminal ControllingTerminal
		{
			[DispId(65538)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(65539)]
		ITScriptableAudioFormat AudioFormatForScripting
		{
			[DispId(65539)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(65539)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		[DispId(65541)]
		ITScriptableAudioFormat EmptyAudioFormatForScripting
		{
			[DispId(65541)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	[ComImport, Guid("449F659E-88A3-11D1-BB5D-00C04FB6809F")]
	public interface ITForwardInformation
	{
		[DispId(1)]
		int NumRingsNoAnswer
		{
			[DispId(1)]
			[param: In]
			set;
			[DispId(1)]
			get;
		}

		[DispId(2)]
		void SetForwardType([In] LINEFORWARDMODE ForwardType, [In, MarshalAs(UnmanagedType.BStr)] string pDestAddress, [In, MarshalAs(UnmanagedType.BStr)] string pCallerAddress);

		[DispId(3)]
		string ForwardTypeDestination
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(4)]
		string ForwardTypeCaller
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(5)]
		void GetForwardType([In] LINEFORWARDMODE ForwardType, [MarshalAs(UnmanagedType.BStr)] out string ppDestinationAddress, [MarshalAs(UnmanagedType.BStr)] out string ppCallerAddress);

		[DispId(6)]
		void Clear();
	}

	[ComImport, Guid("5229B4ED-B260-4382-8E1A-5DF3A8A4CCC0")]
	public interface ITForwardInformation2 : ITForwardInformation
	{
		[DispId(1)]
		new int NumRingsNoAnswer
		{
			[DispId(1)]
			[param: In]
			set;
			[DispId(1)]
			get;
		}

		[DispId(2)]
		new void SetForwardType([In] LINEFORWARDMODE ForwardType, [In, MarshalAs(UnmanagedType.BStr)] string pDestAddress, [In, MarshalAs(UnmanagedType.BStr)] string pCallerAddress);

		[DispId(3)]
		new string ForwardTypeDestination
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(4)]
		new string ForwardTypeCaller
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(5)]
		new void GetForwardType([In] LINEFORWARDMODE ForwardType, [MarshalAs(UnmanagedType.BStr)] out string ppDestinationAddress, [MarshalAs(UnmanagedType.BStr)] out string ppCallerAddress);

		[DispId(6)]
		new void Clear();

		[DispId(7)]
		void SetForwardType2([In] LINEFORWARDMODE ForwardType, [In, MarshalAs(UnmanagedType.BStr)] string pDestAddress, [In] LINEADDRESSTYPE DestAddressType, [In, MarshalAs(UnmanagedType.BStr)] string pCallerAddress, [In] LINEADDRESSTYPE CallerAddressType);

		[DispId(8)]
		void GetForwardType2([In] LINEFORWARDMODE ForwardType, [MarshalAs(UnmanagedType.BStr)] out string ppDestinationAddress, out LINEADDRESSTYPE pDestAddressType, [MarshalAs(UnmanagedType.BStr)] out string ppCallerAddress, out LINEADDRESSTYPE pCallerAddressType);

		[DispId(9)]
		void GetForwardTypeDestinationAddressType([In] LINEFORWARDMODE ForwardType, out LINEADDRESSTYPE pDestAddressType);

		[DispId(10)]
		void GetForwardTypeCallerAddressType([In] LINEFORWARDMODE ForwardType, out LINEADDRESSTYPE pCallerAddressType);
	}

	/// <summary>
	/// <para>
	/// The <b>ITLegacyAddressMediaControl</b> interface is provided to support legacy applications that require direct access to a device
	/// and its configuration. It is exposed by the <c>Address Object</c> and can be created by calling <b>QueryInterface</b> on <c>ITAddress</c>.
	/// </para>
	/// <para>
	/// The <c>ITLegacyAddressMediaControl2</c> interface derives from the <b>ITLegacyAddressMediaControl</b> interface.
	/// <b>ITLegacyAddressMediaControl2</b> provides additional methods that allow the configuration of parameters related to line devices.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nn-tapi3if-itlegacyaddressmediacontrol
	[PInvokeData("tapi3if.h", MSDNShortId = "NN:tapi3if.ITLegacyAddressMediaControl")]
	[ComImport, Guid("AB493640-4C0B-11D2-A046-00C04FB6809F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITLegacyAddressMediaControl
	{
		/// <summary>
		/// <para>The <b>GetID</b> method returns a device identifier for the specified device class associated with the current address.</para>
		/// <para>
		/// This method is intended for C/C++ applications only. There is no corresponding method available for Visual Basic and scripting applications.
		/// </para>
		/// </summary>
		/// <param name="pDeviceClass">
		/// Pointer to <b>BSTR</b> containing <c>TAPI device class</c> for which configuration information is needed.
		/// </param>
		/// <param name="pdwSize">Length of device identifier returned.</param>
		/// <param name="ppDeviceID">Device identifier.</param>
		/// <remarks>
		/// <para>The application must call <c>ITTAPI::RegisterCallNotifications</c> prior to calling this method.</para>
		/// <para>The application must call the <c>CoTaskMemFree</c> function to free the memory allocated for the <i>ppDeviceID</i> parameter.</para>
		/// <para><b>TAPI 2.1 Cross-References:</b><c>lineGetDevConfig</c>, <c>lineSetDevConfig</c>, <c>lineGetID</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itlegacyaddressmediacontrol-getid HRESULT GetID( [in] BSTR
		// pDeviceClass, [out] DWORD *pdwSize, [out] BYTE **ppDeviceID );
		void GetID([In, MarshalAs(UnmanagedType.BStr)] string pDeviceClass, out uint pdwSize, out SafeCoTaskMemHandle ppDeviceID);

		/// <summary>
		/// The <b>GetDevConfig</b> method returns an opaque data structure. The exact contents are specific to the service provider and
		/// device class. The data structure specifies the configuration of a device associated with a particular line device. For example,
		/// the contents of this structure could specify data rate, character format, modulation schemes, and error control protocol settings
		/// for a datamodem device associated with the line.
		/// </summary>
		/// <param name="pDeviceClass">
		/// Pointer to <b>BSTR</b> containing <c>TAPI device class</c> for which configuration information is needed.
		/// </param>
		/// <param name="pdwSize">Pointer to size of configuration array.</param>
		/// <param name="ppDeviceConfig">Pointer to array of bytes containing device configuration information.</param>
		/// <remarks>
		/// <para>This method is a COM wrapper for the <c>LineGetDevConfig</c> TAPI 2.1 function.</para>
		/// <para>The <c>GetID</c> must be performed prior to calling this method.</para>
		/// <para>
		/// The application must call the <c>CoTaskMemFree</c> function to free the memory allocated for the <i>ppDeviceConfig</i> parameter.
		/// </para>
		/// <para><b>TAPI 2.1 Cross-References:</b><c>lineGetDevConfig</c>, <c>lineSetDevConfig</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itlegacyaddressmediacontrol-getdevconfig HRESULT
		// GetDevConfig( [in] BSTR pDeviceClass, [out] DWORD *pdwSize, [out] BYTE **ppDeviceConfig );
		void GetDevConfig([In, MarshalAs(UnmanagedType.BStr)] string pDeviceClass, out uint pdwSize, out SafeCoTaskMemHandle ppDeviceConfig);

		/// <summary>
		/// The <b>SetDevConfig</b> function allows the application to restore the configuration of a media stream device on a line device to
		/// a setup previously obtained using <c>GetDevConfig</c>.
		/// </summary>
		/// <param name="pDeviceClass">
		/// Pointer to <b>BSTR</b> containing <c>TAPI device class</c> for which configuration information is needed.
		/// </param>
		/// <param name="dwSize">Size of configuration array.</param>
		/// <param name="pDeviceConfig">
		/// Pointer to the array of bytes containing device configuration information obtained by a call to <c>GetDevConfig</c>.
		/// </param>
		/// <remarks>
		/// <para>This method is a COM wrapper for the <c>lineSetDevConfig</c> TAPI 2.1 function.</para>
		/// <para>The <c>GetID</c> must be performed prior to calling this method.</para>
		/// <para><b>TAPI 2.1 Cross-References:</b><c>lineGetDevConfig</c>, <c>lineSetDevConfig</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itlegacyaddressmediacontrol-setdevconfig HRESULT
		// SetDevConfig( [in] BSTR pDeviceClass, [in] DWORD dwSize, [in] BYTE *pDeviceConfig );
		void SetDevConfig([In, MarshalAs(UnmanagedType.BStr)] string pDeviceClass, [In] uint dwSize, [In] IntPtr pDeviceConfig);
	}

	[ComImport, Guid("B0EE512B-A531-409E-9DD9-4099FE86C738"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITLegacyAddressMediaControl2 : ITLegacyAddressMediaControl
	{
		/// <summary>
		/// <para>The <b>GetID</b> method returns a device identifier for the specified device class associated with the current address.</para>
		/// <para>
		/// This method is intended for C/C++ applications only. There is no corresponding method available for Visual Basic and scripting applications.
		/// </para>
		/// </summary>
		/// <param name="pDeviceClass">
		/// Pointer to <b>BSTR</b> containing <c>TAPI device class</c> for which configuration information is needed.
		/// </param>
		/// <param name="pdwSize">Length of device identifier returned.</param>
		/// <param name="ppDeviceID">Device identifier.</param>
		/// <remarks>
		/// <para>The application must call <c>ITTAPI::RegisterCallNotifications</c> prior to calling this method.</para>
		/// <para>The application must call the <c>CoTaskMemFree</c> function to free the memory allocated for the <i>ppDeviceID</i> parameter.</para>
		/// <para><b>TAPI 2.1 Cross-References:</b><c>lineGetDevConfig</c>, <c>lineSetDevConfig</c>, <c>lineGetID</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itlegacyaddressmediacontrol-getid HRESULT GetID( [in] BSTR
		// pDeviceClass, [out] DWORD *pdwSize, [out] BYTE **ppDeviceID );
		new void GetID([In, MarshalAs(UnmanagedType.BStr)] string pDeviceClass, out uint pdwSize, out SafeCoTaskMemHandle ppDeviceID);

		/// <summary>
		/// The <b>GetDevConfig</b> method returns an opaque data structure. The exact contents are specific to the service provider and
		/// device class. The data structure specifies the configuration of a device associated with a particular line device. For example,
		/// the contents of this structure could specify data rate, character format, modulation schemes, and error control protocol settings
		/// for a datamodem device associated with the line.
		/// </summary>
		/// <param name="pDeviceClass">
		/// Pointer to <b>BSTR</b> containing <c>TAPI device class</c> for which configuration information is needed.
		/// </param>
		/// <param name="pdwSize">Pointer to size of configuration array.</param>
		/// <param name="ppDeviceConfig">Pointer to array of bytes containing device configuration information.</param>
		/// <remarks>
		/// <para>This method is a COM wrapper for the <c>LineGetDevConfig</c> TAPI 2.1 function.</para>
		/// <para>The <c>GetID</c> must be performed prior to calling this method.</para>
		/// <para>
		/// The application must call the <c>CoTaskMemFree</c> function to free the memory allocated for the <i>ppDeviceConfig</i> parameter.
		/// </para>
		/// <para><b>TAPI 2.1 Cross-References:</b><c>lineGetDevConfig</c>, <c>lineSetDevConfig</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itlegacyaddressmediacontrol-getdevconfig HRESULT
		// GetDevConfig( [in] BSTR pDeviceClass, [out] DWORD *pdwSize, [out] BYTE **ppDeviceConfig );
		new void GetDevConfig([In, MarshalAs(UnmanagedType.BStr)] string pDeviceClass, out uint pdwSize, out SafeCoTaskMemHandle ppDeviceConfig);

		/// <summary>
		/// The <b>SetDevConfig</b> function allows the application to restore the configuration of a media stream device on a line device to
		/// a setup previously obtained using <c>GetDevConfig</c>.
		/// </summary>
		/// <param name="pDeviceClass">
		/// Pointer to <b>BSTR</b> containing <c>TAPI device class</c> for which configuration information is needed.
		/// </param>
		/// <param name="dwSize">Size of configuration array.</param>
		/// <param name="pDeviceConfig">
		/// Pointer to the array of bytes containing device configuration information obtained by a call to <c>GetDevConfig</c>.
		/// </param>
		/// <remarks>
		/// <para>This method is a COM wrapper for the <c>lineSetDevConfig</c> TAPI 2.1 function.</para>
		/// <para>The <c>GetID</c> must be performed prior to calling this method.</para>
		/// <para><b>TAPI 2.1 Cross-References:</b><c>lineGetDevConfig</c>, <c>lineSetDevConfig</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itlegacyaddressmediacontrol-setdevconfig HRESULT
		// SetDevConfig( [in] BSTR pDeviceClass, [in] DWORD dwSize, [in] BYTE *pDeviceConfig );
		new void SetDevConfig([In, MarshalAs(UnmanagedType.BStr)] string pDeviceClass, [In] uint dwSize, [In] IntPtr pDeviceConfig);

		[PreserveSig]
		HRESULT ConfigDialog([In] HWND hwndOwner, [In, MarshalAs(UnmanagedType.BStr)] string pDeviceClass);

		/// <summary>
		/// The <b>ConfigDialogEdit</b> method causes the provider of the specified line device to display a dialog box to allow the user to
		/// configure parameters related to the line device. The configuration data is passed in and out of this method by the application.
		/// (The data is the same as that retrieved by the <c>ITLegacyAddressMediaControl::GetDevConfig</c> method and set by the
		/// <c>ITLegacyAddressMediaControl::SetDevConfig</c> method.)
		/// </summary>
		/// <param name="hwndOwner">
		/// A handle to a window to which the dialog box is to be attached. Can be <b>NULL</b> to indicate that a window created by the
		/// method should have no owner window.
		/// </param>
		/// <param name="pDeviceClass">
		/// Pointer to a <b>BSTR</b> that specifies a device class name. This device class allows the application to select a specific
		/// subscreen of configuration information applicable to that device class. This parameter is optional and can be left <b>NULL</b> or
		/// empty, in which case the highest level configuration is selected.
		/// </param>
		/// <param name="dwSizeIn">Pointer to the size of the configuration data pointed to by the <i>pDeviceConfigIn</i> parameter.</param>
		/// <param name="pDeviceConfigIn">Pointer to an array of bytes containing device configuration data to edit.</param>
		/// <param name="pdwSizeOut">Pointer to the size of the configuration data pointed to by the <i>ppDeviceConfigOut</i> parameter.</param>
		/// <param name="ppDeviceConfigOut">Pointer to an array of bytes containing edited device configuration data.</param>
		/// <returns>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
		/// <remarks>
		/// This method translates to a TAPI 2. <i>x</i><c>lineConfigDialogEdit</c> call. The
		/// <c>ITLegacyAddressMediaControl2::ConfigDialog</c> method translates to a <c>lineConfigDialog</c> call. These methods differ in
		/// their source of parameters to edit and the result of the editing on an active connection. For a discussion about these
		/// differences, see <c>lineConfigDialogEdit</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itlegacyaddressmediacontrol2-configdialogedit HRESULT
		// ConfigDialogEdit( [in] HWND hwndOwner, [in] BSTR pDeviceClass, [in] DWORD dwSizeIn, [in] BYTE *pDeviceConfigIn, [out] DWORD
		// *pdwSizeOut, [out] BYTE **ppDeviceConfigOut );
		[PreserveSig]
		HRESULT ConfigDialogEdit([In] HWND hwndOwner, [In, MarshalAs(UnmanagedType.BStr)] string pDeviceClass, [In] uint dwSizeIn,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pDeviceConfigIn, out uint pdwSizeOut, out SafeCoTaskMemHandle ppDeviceConfigOut);
	}

	[ComImport, Guid("D624582F-CC23-4436-B8A5-47C625C8045D")]
	public interface ITLegacyCallMediaControl
	{
		[DispId(196609)]
		[PreserveSig]
		HRESULT DetectDigits([In] TAPI_DIGITMODE DigitMode);

		[DispId(196610)]
		[PreserveSig]
		HRESULT GenerateDigits([In, MarshalAs(UnmanagedType.BStr)] string pDigits, [In] TAPI_DIGITMODE DigitMode);

		/// <summary>
		/// <para>The <b>GetID</b> method gets the identifier for the device associated with the current call.</para>
		/// <para>
		/// This method is intended for C/C++ applications. Visual Basic and scripting applications should use the
		/// <c>ITLegacyCallMediaControl2::GetIDAsVariant</c> method.
		/// </para>
		/// </summary>
		/// <param name="pDeviceClass">Pointer to <b>BSTR</b> representing the <c>TAPI device class</c>.</param>
		/// <param name="pdwSize">Size in bytes of device identifier.</param>
		/// <param name="ppDeviceID">Device identifier.</param>
		/// <remarks>
		/// <para>The application must call <c>ITTAPI::RegisterCallNotifications</c> prior to calling this method.</para>
		/// <para>
		/// The application must use <c>SysAllocString</c> to allocate memory for the <i>pDeviceClass</i> parameter and use
		/// <c>SysFreeString</c> to free the memory when the variable is no longer needed.
		/// </para>
		/// <para>The application must call the <c>CoTaskMemFree</c> function to free the memory allocated for the <i>ppDeviceID</i> parameter.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itlegacycallmediacontrol-getid HRESULT GetID( [in] BSTR
		// pDeviceClass, [out] DWORD *pdwSize, [out] BYTE **ppDeviceID );
		[DispId(196611)]
		void GetID([In, MarshalAs(UnmanagedType.BStr)] string pDeviceClass, out uint pdwSize, out IntPtr ppDeviceID);

		[DispId(196612)]
		[PreserveSig]
		HRESULT SetMediaType([In] TAPIMEDIATYPE lMediaType);

		[DispId(196613)]
		[PreserveSig]
		HRESULT MonitorMedia([In] TAPIMEDIATYPE lMediaType);
	}

	[ComImport, Guid("57CA332D-7BC2-44F1-A60C-936FE8D7CE73")]
	public interface ITLegacyCallMediaControl2 : ITLegacyCallMediaControl
	{
		[DispId(196609)]
		[PreserveSig]
		new HRESULT DetectDigits([In] TAPI_DIGITMODE DigitMode);

		[DispId(196610)]
		[PreserveSig]
		new HRESULT GenerateDigits([In, MarshalAs(UnmanagedType.BStr)] string pDigits, [In] TAPI_DIGITMODE DigitMode);

		/// <summary>
		/// <para>The <b>GetID</b> method gets the identifier for the device associated with the current call.</para>
		/// <para>
		/// This method is intended for C/C++ applications. Visual Basic and scripting applications should use the
		/// <c>ITLegacyCallMediaControl2::GetIDAsVariant</c> method.
		/// </para>
		/// </summary>
		/// <param name="pDeviceClass">Pointer to <b>BSTR</b> representing the <c>TAPI device class</c>.</param>
		/// <param name="pdwSize">Size in bytes of device identifier.</param>
		/// <param name="ppDeviceID">Device identifier.</param>
		/// <remarks>
		/// <para>The application must call <c>ITTAPI::RegisterCallNotifications</c> prior to calling this method.</para>
		/// <para>
		/// The application must use <c>SysAllocString</c> to allocate memory for the <i>pDeviceClass</i> parameter and use
		/// <c>SysFreeString</c> to free the memory when the variable is no longer needed.
		/// </para>
		/// <para>The application must call the <c>CoTaskMemFree</c> function to free the memory allocated for the <i>ppDeviceID</i> parameter.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itlegacycallmediacontrol-getid HRESULT GetID( [in] BSTR
		// pDeviceClass, [out] DWORD *pdwSize, [out] BYTE **ppDeviceID );
		[DispId(196611)]
		new void GetID([In, MarshalAs(UnmanagedType.BStr)] string pDeviceClass, out uint pdwSize, out IntPtr ppDeviceID);

		[DispId(196612)]
		[PreserveSig]
		new HRESULT SetMediaType([In] TAPIMEDIATYPE lMediaType);

		[DispId(196613)]
		[PreserveSig]
		new HRESULT MonitorMedia([In] TAPIMEDIATYPE lMediaType);

		[DispId(196614)]
		[PreserveSig]
		HRESULT GenerateDigits2([In, MarshalAs(UnmanagedType.BStr)] string pDigits, [In] TAPI_DIGITMODE DigitMode, [In] int lDuration);

		[DispId(196615)]
		[PreserveSig]
		HRESULT GatherDigits([In] TAPI_DIGITMODE DigitMode, [In] int lNumDigits, [In, MarshalAs(UnmanagedType.BStr)] string pTerminationDigits, [In] int lFirstDigitTimeout, [In] int lInterDigitTimeout);

		[DispId(196616)]
		[PreserveSig]
		HRESULT DetectTones([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TAPI_DETECTTONE[]? pToneList, [In, Optional] int lNumTones);

		[DispId(196617)]
		[PreserveSig]
		HRESULT DetectTonesByCollection([In, MarshalAs(UnmanagedType.Interface)] ITCollection2 pDetectToneCollection);

		[DispId(196618)]
		[PreserveSig]
		HRESULT GenerateTone([In] TAPI_TONEMODE ToneMode, [In] int lDuration);

		[DispId(196619)]
		[PreserveSig]
		HRESULT GenerateCustomTones([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TAPI_CUSTOMTONE[] pToneList, [In] int lNumTones, [In] int lDuration);

		[DispId(196620)]
		[PreserveSig]
		HRESULT GenerateCustomTonesByCollection([In, MarshalAs(UnmanagedType.Interface)] ITCollection2 pCustomToneCollection, [In] int lDuration);

		[DispId(196621)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ITDetectTone CreateDetectToneObject();

		[DispId(196622)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ITCustomTone CreateCustomToneObject();

		[DispId(196623)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetIDAsVariant([In, MarshalAs(UnmanagedType.BStr)] string bstrDeviceClass);
	}

	[ComImport, Guid("207823EA-E252-11D2-B77E-0080C7135381")]
	public interface ITLegacyWaveSupport
	{
		[DispId(1610743808)]
		void IsFullDuplex(out FULLDUPLEX_SUPPORT pSupport);
	}

	[ComImport, Guid("0C4D8EFF-8DDB-11D1-A09E-00805FC147D3")]
	public interface ITLocationInfo
	{
		[DispId(1)]
		int PermanentLocationID
		{
			[DispId(1)]
			get;
		}

		[DispId(2)]
		int CountryCode
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		int CountryID
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		LINELOCATIONOPTION Options
		{
			[DispId(4)]
			get;
		}

		[DispId(5)]
		int PreferredCardID
		{
			[DispId(5)]
			get;
		}

		[DispId(6)]
		string LocationName
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(7)]
		string CityCode
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(8)]
		string LocalAccessCode
		{
			[DispId(8)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(9)]
		string LongDistanceAccessCode
		{
			[DispId(9)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(10)]
		string TollPrefixList
		{
			[DispId(10)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(11)]
		string CancelCallWaitingCode
		{
			[DispId(11)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	[ComImport, Guid("C445DDE8-5199-4BC7-9807-5FFB92E42E09")]
	public interface ITMediaControl
	{
		[DispId(131073)]
		[PreserveSig]
		HRESULT Start();

		[DispId(131074)]
		[PreserveSig]
		HRESULT Stop();

		[DispId(131075)]
		[PreserveSig]
		HRESULT Pause();

		[DispId(131076)]
		TERMINAL_MEDIA_STATE MediaState
		{
			[DispId(131076)]
			get;
		}
	}

	[ComImport, Guid("627E8AE6-AE4C-4A69-BB63-2AD625404B77")]
	public interface ITMediaPlayback
	{
		[DispId(262145)]
		object PlayList
		{
			[DispId(262145)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Struct)]
			set;
			[DispId(262145)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}
	}

	[ComImport, Guid("F5DD4592-5476-4CC1-9D4D-FAD3EEFE7DB2")]
	public interface ITMediaRecord
	{
		[DispId(196609)]
		string FileName
		{
			[DispId(196609)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
			[DispId(196609)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	[ComImport, Guid("B1EFC384-9355-11D0-835C-00AA003CCABD")]
	public interface ITMediaSupport
	{
		[DispId(196609)]
		TAPIMEDIATYPE MediaTypes
		{
			[DispId(196609)]
			get;
		}

		[DispId(196610)]
		bool QueryMediaType([In] TAPIMEDIATYPE lMediaType);
	}

	[ComImport, Guid("FE040091-ADE8-4072-95C9-BF7DE8C54B44")]
	public interface ITMultiTrackTerminal
	{
		[DispId(65537)]
		object TrackTerminals
		{
			[DispId(65537)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(65538)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumTerminal EnumerateTrackTerminals();

		[DispId(65539)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ITTerminal CreateTrackTerminal([In] TAPIMEDIATYPE MediaType, [In] TERMINAL_DIRECTION TerminalDirection);

		[DispId(65540)]
		TAPIMEDIATYPE MediaTypesInUse
		{
			[DispId(65540)]
			get;
		}

		[DispId(65541)]
		TERMINAL_DIRECTION DirectionsInUse
		{
			[DispId(65541)]
			get;
		}

		[DispId(65542)]
		void RemoveTrackTerminal([In, MarshalAs(UnmanagedType.Interface)] ITTerminal pTrackTerminalToRemove);
	}

	[ComImport, Guid("09D48DB4-10CC-4388-9DE7-A8465618975A")]
	public interface ITPhone
	{
		[DispId(65537)]
		[PreserveSig]
		HRESULT Open([In] PHONE_PRIVILEGE Privilege);

		[DispId(65538)]
		[PreserveSig]
		HRESULT Close();

		[DispId(65539)]
		object Addresses
		{
			[DispId(65539)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(65540)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumAddress EnumerateAddresses();

		[DispId(65541)]
		PHONECAPS_LONG PhoneCapsLong
		{
			[DispId(65541)]
			get;
		}

		[DispId(65542)]
		string PhoneCapsString
		{
			[DispId(65542)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(65543)]
		object Terminals
		{
			[DispId(65543)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(65544)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumTerminal EnumerateTerminals([In, MarshalAs(UnmanagedType.Interface)] ITAddress pAddress);

		[DispId(65545)]
		PHONE_BUTTON_MODE ButtonMode
		{
			[DispId(65545)]
			get;
			[DispId(65545)]
			[param: In]
			set;
		}

		[DispId(65546)]
		PHONE_BUTTON_FUNCTION ButtonFunction
		{
			[DispId(65546)]
			get;
			[DispId(65546)]
			[param: In]
			set;
		}

		[DispId(65547)]
		string ButtonText
		{
			[DispId(65547)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(65547)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(65548)]
		PHONE_BUTTON_STATE ButtonState
		{
			[DispId(65548)]
			get;
		}

		[DispId(65549)]
		PHONE_HOOK_SWITCH_STATE HookSwitchState
		{
			[DispId(65549)]
			get;
			[DispId(65549)]
			[param: In]
			set;
		}

		[DispId(65550)]
		int RingMode
		{
			[DispId(65550)]
			[param: In]
			set;
			[DispId(65550)]
			get;
		}

		[DispId(65551)]
		int RingVolume
		{
			[DispId(65551)]
			[param: In]
			set;
			[DispId(65551)]
			get;
		}

		[DispId(65552)]
		PHONE_PRIVILEGE Privilege
		{
			[DispId(65552)]
			get;
		}

		[DispId(65553)]
		[PreserveSig]
		HRESULT GetPhoneCapsBuffer([In] PHONECAPS_BUFFER pcbCaps, out uint pdwSize, out IntPtr ppPhoneCapsBuffer);

		[DispId(65554)]
		object PhoneCapsBuffer
		{
			[DispId(65554)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(65555)]
		PHONE_LAMP_MODE LampMode
		{
			[DispId(65555)]
			get;
			[DispId(65555)]
			[param: In]
			set;
		}

		[DispId(65556)]
		string Display
		{
			[DispId(65556)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(65557)]
		[PreserveSig]
		HRESULT SetDisplay([In] int lRow, [In] int lColumn, [In, MarshalAs(UnmanagedType.BStr)] string bstrDisplay);

		[DispId(65558)]
		object PreferredAddresses
		{
			[DispId(65558)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(65559)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumAddress EnumeratePreferredAddresses();

		[DispId(65560)]
		[PreserveSig]
		HRESULT DeviceSpecific([In] IntPtr pParams, [In] uint dwSize);

		[DispId(65561)]
		[PreserveSig]
		HRESULT DeviceSpecificVariant([In, MarshalAs(UnmanagedType.Struct)] object varDevSpecificByteArray);

		[DispId(65562)]
		int NegotiateExtVersion([In] int lLowVersion, [In] int lHighVersion);
	}

	[ComImport, Guid("63FFB2A6-872B-4CD3-A501-326E8FB40AF7")]
	public interface ITPhoneDeviceSpecificEvent
	{
		[DispId(1)]
		ITPhone Phone
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		int lParam1
		{
			get;
		}

		[DispId(3)]
		int lParam2
		{
			get;
		}

		[DispId(4)]
		int lParam3
		{
			get;
		}
	}

	[ComImport, Guid("8F942DD8-64ED-4AAF-A77D-B23DB0837EAD")]
	public interface ITPhoneEvent
	{
		[DispId(1)]
		ITPhone Phone
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		PHONE_EVENT Event
		{
			get;
		}

		[DispId(3)]
		PHONE_BUTTON_STATE ButtonState
		{
			get;
		}

		[DispId(4)]
		PHONE_HOOK_SWITCH_STATE HookSwitchState
		{
			get;
		}

		[DispId(5)]
		PHONE_HOOK_SWITCH_DEVICE HookSwitchDevice
		{
			get;
		}

		[DispId(6)]
		int RingMode
		{
			get;
		}

		[DispId(7)]
		int ButtonLampId
		{
			get;
		}

		[DispId(8)]
		string NumberGathered
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(9)]
		ITCallInfo Call
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	[ComImport, Guid("41757F4A-CF09-4B34-BC96-0A79D2390076")]
	public interface ITPluggableTerminalClassInfo
	{
		[DispId(1)]
		string Name
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(2)]
		string Company
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(3)]
		string Version
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(4)]
		string TerminalClass
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(5)]
		string CLSID
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(6)]
		TERMINAL_DIRECTION Direction
		{
			[DispId(6)]
			get;
		}

		[DispId(7)]
		TAPIMEDIATYPE MediaTypes
		{
			[DispId(7)]
			get;
		}
	}

	[ComImport, Guid("6D54E42C-4625-4359-A6F7-631999107E05")]
	public interface ITPluggableTerminalSuperclassInfo
	{
		[DispId(1)]
		string Name
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(2)]
		string CLSID
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	[ComImport, Guid("0E269CD0-10D4-4121-9C22-9C85D625650D")]
	public interface ITPrivateEvent
	{
		[DispId(1)]
		ITAddress Address
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		ITCallInfo Call
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(3)]
		ITCallHub CallHub
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(4)]
		int EventCode
		{
			[DispId(4)]
			get;
		}

		[DispId(5)]
		object EventInterface
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
		}
	}

	[ComImport, Guid("CFA3357C-AD77-11D1-BB68-00C04FB6809F")]
	public interface ITQOSEvent
	{
		[DispId(1)]
		ITCallInfo Call
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(3)]
		QOS_EVENT Event
		{
			get;
		}

		[DispId(4)]
		TAPIMEDIATYPE MediaType
		{
			get;
		}
	}

	[ComImport, Guid("5AFC3149-4BCC-11D1-BF80-00805FC147D3")]
	public interface ITQueue
	{
		[DispId(1)]
		int MeasurementPeriod
		{
			[DispId(1)]
			get;
			[DispId(1)]
			[param: In]
			set;
		}

		[DispId(2)]
		int TotalCallsQueued
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		int CurrentCallsQueued
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		int TotalCallsAbandoned
		{
			[DispId(4)]
			get;
		}

		[DispId(5)]
		int TotalCallsFlowedIn
		{
			[DispId(5)]
			get;
		}

		[DispId(6)]
		int TotalCallsFlowedOut
		{
			[DispId(6)]
			get;
		}

		[DispId(7)]
		int LongestEverWaitTime
		{
			[DispId(7)]
			get;
		}

		[DispId(8)]
		int CurrentLongestWaitTime
		{
			[DispId(8)]
			get;
		}

		[DispId(9)]
		int AverageWaitTime
		{
			[DispId(9)]
			get;
		}

		[DispId(10)]
		int FinalDisposition
		{
			[DispId(10)]
			get;
		}

		[DispId(11)]
		string Name
		{
			[DispId(11)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	[ComImport, Guid("297F3033-BD11-11D1-A0A7-00805FC147D3")]
	public interface ITQueueEvent
	{
		[DispId(1)]
		ITQueue Queue
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		ACDQUEUE_EVENT Event
		{
			[DispId(2)]
			get;
		}
	}

	[ComImport, Guid("AC48FFDF-F8C4-11D1-A030-00C04FB6809F")]
	public interface ITRequest
	{
		[PreserveSig]
		HRESULT MakeCall([In, MarshalAs(UnmanagedType.BStr)] string pDestAddress, [In, MarshalAs(UnmanagedType.BStr)] string pAppName, [In, MarshalAs(UnmanagedType.BStr)] string pCalledParty, [In, MarshalAs(UnmanagedType.BStr)] string pComment);
	}

	[ComImport, Guid("AC48FFDE-F8C4-11D1-A030-00C04FB6809F")]
	public interface ITRequestEvent
	{
		[DispId(1)]
		int RegistrationInstance
		{
			get;
		}

		[DispId(2)]
		int RequestMode
		{
			get;
		}

		[DispId(3)]
		string DestAddress
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(5)]
		string AppName
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(6)]
		string CalledParty
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(7)]
		string Comment
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	[ComImport, Guid("B87658BD-3C59-4F64-BE74-AEDE3E86A81E")]
	public interface ITScriptableAudioFormat
	{
		[DispId(1)]
		int Channels
		{
			[DispId(1)]
			get;
			[DispId(1)]
			[param: In]
			set;
		}

		[DispId(2)]
		int SamplesPerSec
		{
			[DispId(2)]
			get;
			[DispId(2)]
			[param: In]
			set;
		}

		[DispId(3)]
		int AvgBytesPerSec
		{
			[DispId(3)]
			get;
			[DispId(3)]
			[param: In]
			set;
		}

		[DispId(4)]
		int BlockAlign
		{
			[DispId(4)]
			get;
			[DispId(4)]
			[param: In]
			set;
		}

		[DispId(5)]
		int BitsPerSample
		{
			[DispId(5)]
			get;
			[DispId(5)]
			[param: In]
			set;
		}

		[DispId(6)]
		int FormatTag
		{
			[DispId(6)]
			get;
			[DispId(6)]
			[param: In]
			set;
		}
	}

	[ComImport, Guid("A86B7871-D14C-48E6-922E-A8D15F984800")]
	public interface ITStaticAudioTerminal
	{
		[DispId(1)]
		int WaveId
		{
			[DispId(1)]
			get;
		}
	}

	[ComImport, Guid("EE3BD605-3868-11D2-A045-00C04FB6809F")]
	public interface ITStream
	{
		[DispId(1)]
		TAPIMEDIATYPE MediaType
		{
			[DispId(1)]
			get;
		}

		[DispId(2)]
		TERMINAL_DIRECTION Direction
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		string Name
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(4)]
		[PreserveSig]
		HRESULT StartStream();

		[DispId(5)]
		[PreserveSig]
		HRESULT PauseStream();

		[DispId(6)]
		[PreserveSig]
		HRESULT StopStream();

		[DispId(7)]
		[PreserveSig]
		HRESULT SelectTerminal([In, MarshalAs(UnmanagedType.Interface)] ITTerminal pTerminal);

		[DispId(8)]
		[PreserveSig]
		HRESULT UnselectTerminal([In, MarshalAs(UnmanagedType.Interface)] ITTerminal pTerminal);

		[DispId(9)]
		void EnumerateTerminals([MarshalAs(UnmanagedType.Interface)] out IEnumTerminal ppEnumTerminal);

		[DispId(10)]
		object Terminals
		{
			[DispId(10)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}
	}

	[ComImport, Guid("EE3BD604-3868-11D2-A045-00C04FB6809F")]
	public interface ITStreamControl
	{
		[DispId(262145)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ITStream CreateStream([In] TAPIMEDIATYPE lMediaType, [In] TERMINAL_DIRECTION td);

		[DispId(262146)]
		[PreserveSig]
		HRESULT RemoveStream([In, MarshalAs(UnmanagedType.Interface)] ITStream pStream);

		[DispId(262147)]
		void EnumerateStreams([MarshalAs(UnmanagedType.Interface)] out IEnumStream ppEnumStream);

		[DispId(262148)]
		object Streams
		{
			[DispId(262148)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}
	}

	[ComImport, Guid("EE3BD608-3868-11D2-A045-00C04FB6809F")]
	public interface ITSubStream
	{
		[DispId(1)]
		[PreserveSig]
		HRESULT StartSubStream();

		[DispId(2)]
		[PreserveSig]
		HRESULT PauseSubStream();

		[DispId(3)]
		[PreserveSig]
		HRESULT StopSubStream();

		[DispId(4)]
		[PreserveSig]
		HRESULT SelectTerminal([In, MarshalAs(UnmanagedType.Interface)] ITTerminal pTerminal);

		[DispId(5)]
		[PreserveSig]
		HRESULT UnselectTerminal([In, MarshalAs(UnmanagedType.Interface)] ITTerminal pTerminal);

		[DispId(6)]
		[PreserveSig]
		HRESULT EnumerateTerminals([MarshalAs(UnmanagedType.Interface)] out IEnumTerminal ppEnumTerminal);

		[DispId(7)]
		object Terminals
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(8)]
		ITStream Stream
		{
			[DispId(8)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	[ComImport, Guid("EE3BD607-3868-11D2-A045-00C04FB6809F")]
	public interface ITSubStreamControl
	{
		[DispId(1)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ITSubStream CreateSubStream();

		[DispId(2)]
		[PreserveSig]
		HRESULT RemoveSubStream([In, MarshalAs(UnmanagedType.Interface)] ITSubStream pSubStream);

		[DispId(3)]
		[PreserveSig]
		HRESULT EnumerateSubStreams([MarshalAs(UnmanagedType.Interface)] out IEnumSubStream ppEnumSubStream);

		[DispId(4)]
		object SubStreams
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}
	}

	/// <summary>
	/// <para>
	/// The <b>ITTAPI</b> interface is the base interface for the TAPI object. The TAPI object is created by <b>CoCreateInstance</b>. For
	/// information on <b>CoCreateInstance</b>, see documentation on COM. All other TAPI 3 objects are created by TAPI 3 itself.
	/// </para>
	/// <para>
	/// <b>ITTAPI</b> methods are provided to initialize a TAPI session, enumerate available addresses, register for CallHub and CallEvent
	/// notifications, and shut down a TAPI session.
	/// </para>
	/// <para>
	/// The <c>ITTAPI2</c> interface derives from the <b>ITTAPI</b> interface. It adds additional methods on the TAPI object to support phone devices.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nn-tapi3if-ittapi
	[PInvokeData("tapi3if.h", MSDNShortId = "NN:tapi3if.ITTAPI")]
	[ComImport, Guid("B1EFC382-9355-11D0-835C-00AA003CCABD"), CoClass(typeof(TAPI))]
	public interface ITTAPI
	{
		/// <summary>
		/// The <b>Initialize</b> method initializes TAPI. This method must be called before calling any other TAPI 3 method. The application
		/// must call the <c>Shutdown</c> method when ending a TAPI session.
		/// </summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><b>S_OK</b></description>
		/// <description>Method succeeded.</description>
		/// </item>
		/// <item>
		/// <description><b>S_FALSE</b></description>
		/// <description>TAPI has already been initialized.</description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b></description>
		/// <description>Insufficient memory exists to perform the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-initialize HRESULT Initialize();
		[DispId(65549)]
		[PreserveSig]
		HRESULT Initialize();

		/// <summary>The <b>Shutdown</b> method shuts down a TAPI session.</summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><b>S_OK</b></description>
		/// <description>Method succeeded.</description>
		/// </item>
		/// <item>
		/// <description><b>S_FALSE</b></description>
		/// <description>TAPI session has already been shut down.</description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b></description>
		/// <description>Insufficient memory exists to perform the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>One reason why <b>Shutdown</b> might fail is if <c>Initialize</c> was not previously called successfully.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-shutdown HRESULT Shutdown();
		[DispId(65550)]
		[PreserveSig]
		HRESULT Shutdown();

		/// <summary>
		/// The <b>get_Addresses</b> method creates a collection of addresses that are currently available. Provided for Automation client
		/// applications, such as those written in Visual Basic. C and C++ applications must use the <c>EnumerateAddresses</c> method.
		/// </summary>
		/// <value>Pointer to a <b>VARIANT</b> containing an <c>ITCollection</c> of <c>ITAddress</c> interface pointers (address objects).</value>
		/// <remarks>
		/// TAPI calls the <b>Addref</b> method on the <c>ITAddress</c> interface returned by <b>ITTAPI::get_Addesses</b>. The application
		/// must call <b>Release</b> on the <b>ITAddress</b> interface to free resources associated with it.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-get_addresses HRESULT get_Addresses( [out] VARIANT
		// *pVariant );
		[DispId(65537)]
		object Addresses
		{
			[DispId(65537)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>EnumerateAddresses</b> method enumerates the addresses that are currently available. Provided for C and C++ applications.
		/// Automation client applications, such as those written in Visual Basic, must use the <c>get_Addresses</c> method.
		/// </summary>
		/// <returns>Pointer to the <c>IEnumAddress</c> interface.</returns>
		/// <remarks>
		/// <para>
		/// An application typically uses this enumeration to check the capabilities of each address and determine which are useful for
		/// current purposes.
		/// </para>
		/// <para>
		/// If an expected address is not found, this may indicate that the appropriate service provider has not been installed or is not
		/// working correctly.
		/// </para>
		/// <para>
		/// TAPI calls the <b>Addref</b> method on the <c>IEnumAddress</c> interface returned by <b>ITTAPI::EnumerateAddresses</b>. The
		/// application must call the <b>Release</b> method on the <b>IEnumAddress</b> interface to free resources associated with it.
		/// </para>
		/// <para>
		/// If an address is created or removed during a TAPI session, the application will be notified through the
		/// <c>ITTAPIEventNotification</c> interface. If an address has been created, such as by installing a Plug and Play device, the
		/// <c>ITTAPIEventNotification::Event</c> returns the <b>TE_ADDRESSCREATE</b> member of the <c>TAPIOBJECT_EVENT</c> enum. If an
		/// address is removed, <b>ITTAPIEventNotification::Event</b> returns <b>TE_ADDRESSREMOVE</b>. Calling <b>EnumerateAddresses</b>
		/// after these events will reflect the current addresses.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-enumerateaddresses HRESULT EnumerateAddresses( [out]
		// IEnumAddress **ppEnumAddress );
		[DispId(65538)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumAddress EnumerateAddresses();

		/// <summary>
		/// <para>
		/// The <b>RegisterCallNotifications</b> method sets which new call notifications an application will receive. The application must
		/// call the method for each address, indicating media type or types it can handle, and specifying the privileges it requests.
		/// </para>
		/// <para>An application that will make only outgoing calls does not need to call this method.</para>
		/// <para>The <c>ITTAPIEventNotification</c> outgoing interface must be registered prior to calling this method.</para>
		/// <para>
		/// If both owner and monitor privileges are needed for an address, this method should be called only once, with both <i>fMonitor</i>
		/// and <i>fOwner</i> set to <b>TRUE</b>.
		/// </para>
		/// </summary>
		/// <param name="pAddress">Pointer to <c>ITAddress</c> interface.</param>
		/// <param name="fMonitor">
		/// Boolean value indicating whether the application will monitor calls. VARIANT_TRUE indicates that the application will monitor
		/// calls; VARIANT_FALSE that it will not.
		/// </param>
		/// <param name="fOwner">
		/// Boolean value indicating whether the application will own incoming calls. VARIANT_TRUE indicates that the application will own
		/// incoming calls; VARIANT_FALSE indicates that it will not.
		/// </param>
		/// <param name="lMediaTypes"><c>Media types</c> that can be handled by the application.</param>
		/// <param name="lCallbackInstance">
		/// Callback instance to be used by the TAPI 3 DLL. Can be the gulAdvise value returned by <c>IConnectionPoint::Advise</c> during
		/// registration of the <c>ITTAPIEventNotification</c> outgoing interface.
		/// </param>
		/// <returns>On success, the returned value that is used by <c>ITTAPI::UnregisterNotifications</c>.</returns>
		/// <remarks>
		/// <para>
		/// If multiple calls of this method are used on one address, the information about participant calls from a call hub may be
		/// confusing if a call that is already being monitored by the application is handed off to it.
		/// </para>
		/// <para>
		/// The <b>RegisterCallNotifications</b> method registers the application as having an interest in monitoring calls or receiving
		/// ownership of calls that are of the specified media types. These call privileges are set in the <i>fMonitor</i> and <i>fOwner</i>
		/// parameters. An application can specify multiple flags to handle multiple media types. Conflicts can arise if multiple
		/// applications register for the same address and media type. These conflicts are resolved by a priority scheme in which the user
		/// assigns relative priorities to the applications. Users can set application priorities by calling the
		/// <c>ITTAPI::SetApplicationPriority</c> function. Only the highest priority application for a given media type will receive
		/// ownership (unsolicited) of a call of that media type. Ownership can be received when an incoming call first arrives or when a
		/// call is handed off. The <c>ITBasicCallControl::HandoffDirect</c> and <c>ITBasicCallControl::HandoffIndirect</c> functions are
		/// called to hand off ownership of a call to another application. If the user does not assign priorities to the application, and
		/// multiple applications open the same line device, by default, the application that called <b>RegisterCallNotifications</b> first
		/// will have the highest priority.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-registercallnotifications HRESULT
		// RegisterCallNotifications( [in] ITAddress *pAddress, [in] VARIANT_BOOL fMonitor, [in] VARIANT_BOOL fOwner, [in] long lMediaTypes,
		// [in] long lCallbackInstance, [out] long *plRegister );
		[DispId(65539)]
		int RegisterCallNotifications([In, MarshalAs(UnmanagedType.Interface)] ITAddress pAddress, [In] bool fMonitor,
			[In] bool fOwner, [In] TAPIMEDIATYPE lMediaTypes, [In] int lCallbackInstance);

		/// <summary>
		/// The <b>UnregisterNotifications</b> method removes any incoming call notification registrations that have been performed using <c>ITTAPI::RegisterCallNotifications</c>.
		/// </summary>
		/// <param name="lRegister">The value returned by the <c>RegisterCallNotifications</c> method in the <i>plRegister</i> parameter.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><b>S_OK</b></description>
		/// <description>Method succeeded.</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b></description>
		/// <description>The TAPI object has not yet been initialized or the <i>lRegister</i> parameter is not valid.</description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b></description>
		/// <description>Insufficient memory exists to perform the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-unregisternotifications HRESULT
		// UnregisterNotifications( [in] long lRegister );
		[DispId(65540)]
		[PreserveSig]
		HRESULT UnregisterNotifications([In] int lRegister);

		/// <summary>
		/// The <b>get_CallHubs</b> method creates a collection of the currently available call hubs. Provided for Automation client
		/// applications, such as those written in Visual Basic. C and C++ applications must use the <c>EnumerateCallHubs</c> method.
		/// </summary>
		/// <value>Pointer to <b>VARIANT</b> containing an <c>ITCollection</c> of <c>ITCallHub</c> interface pointers (CallHub objects).</value>
		/// <remarks>
		/// TAPI calls the <b>Addref</b> method on the <c>ITCallHub</c> interface returned by <b>ITTAPI::get_CallHubs</b>. The application
		/// must call <b>Release</b> on the <b>ITCallHub</b> interface to free resources associated with it.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-get_callhubs HRESULT get_CallHubs( [out] VARIANT
		// *pVariant );
		[DispId(65541)]
		object CallHubs
		{
			[DispId(65541)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>EnumerateCallHubs</b> method enumerates the currently available call hubs. Provided for C and C++ applications. Automation
		/// client applications, such as those written in Visual Basic, must use the <c>get_Callhubs</c> method.
		/// </summary>
		/// <returns>Pointer to the <c>IEnumCallHub</c> interface.</returns>
		/// <remarks>
		/// TAPI calls the <b>Addref</b> method on the <c>IEnumCallHub</c> interface returned by <b>ITTAPI::EnumerateCallHubs</b>. The
		/// application must call <b>Release</b> on the <b>IEnumCallHub</b> interface to free resources associated with it.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-enumeratecallhubs HRESULT EnumerateCallHubs( [out]
		// IEnumCallHub **ppEnumCallHub );
		[DispId(65542)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumCallHub EnumerateCallHubs();

		/// <summary>The <b>SetCallHubTracking</b> method enables or disables CallHub tracking.</summary>
		/// <param name="pAddresses">Pointer to a <b>VARIANT</b> containing a <b>SAFEARRAY</b> of <c>ITAddress</c> interface pointers.</param>
		/// <param name="bTracking">VARIANT_TRUE to enable tracking, VARIANT_FALSE to disable.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-setcallhubtracking HRESULT SetCallHubTracking( [in]
		// VARIANT pAddresses, [in] VARIANT_BOOL bTracking );
		[DispId(65543)]
		void SetCallHubTracking([In, MarshalAs(UnmanagedType.Struct, SafeArraySubType = VarEnum.VT_DISPATCH)] object pAddresses, [In] bool bTracking);

		/// <summary>This method is not implemented and will return E_NOTIMPL.</summary>
		/// <param name="ppEnumUnknown">This method is not implemented.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-enumerateprivatetapiobjects HRESULT
		// EnumeratePrivateTAPIObjects( [out] IEnumUnknown **ppEnumUnknown );
		[DispId(65544)]
		void EnumeratePrivateTAPIObjects([MarshalAs(UnmanagedType.Interface)] out IEnumUnknown ppEnumUnknown);

		/// <summary>This method is not implemented and will return E_NOTIMPL.</summary>
		/// <value>This method is not implemented.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-get_privatetapiobjects HRESULT
		// get_PrivateTAPIObjects( [out] VARIANT *pVariant );
		[DispId(65545)]
		object PrivateTAPIObjects
		{
			[DispId(65545)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>RegisterRequestRecipient</b> method registers an application instance as being the proper one to handle assisted telephony requests.
		/// </summary>
		/// <param name="lRegistrationInstance">Pointer to registration instance.</param>
		/// <param name="lRequestMode">Request mode.</param>
		/// <param name="fEnable">
		/// VARIANT_TRUE indicates that the caller wants to register as the handler; VARIANT_FALSE that it wants to unregister as the handler.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-registerrequestrecipient HRESULT
		// RegisterRequestRecipient( [in] long lRegistrationInstance, [in] long lRequestMode, [in] VARIANT_BOOL fEnable );
		[DispId(65546)]
		void RegisterRequestRecipient([In] int lRegistrationInstance, [In] int lRequestMode, [In] bool fEnable);

		/// <summary>The <b>SetAssistedTelephonyPriority</b> method sets the application priority to handle assisted telephony requests.</summary>
		/// <param name="pAppFilename">Pointer to a <b>BSTR</b> containing the name of the application.</param>
		/// <param name="fPriority">Set to VARIANT_FALSE to disable, VARIANT_TRUE to enable.</param>
		/// <remarks>
		/// The application must use <c>SysAllocString</c> to allocate memory for the <i>pAppFilename</i> parameter and use
		/// <c>SysFreeString</c> to free the memory when the variable is no longer needed.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-setassistedtelephonypriority HRESULT
		// SetAssistedTelephonyPriority( [in] BSTR pAppFilename, [in] VARIANT_BOOL fPriority );
		[DispId(65547)]
		void SetAssistedTelephonyPriority([In, MarshalAs(UnmanagedType.BStr)] string pAppFilename, [In] bool fPriority);

		/// <summary>
		/// The <b>SetApplicationPriority</b> method allows an application to set its priority in the handoff priority list for a particular
		/// media type or Assisted Telephony request mode, or to remove itself from the priority list.
		/// </summary>
		/// <param name="pAppFilename">Pointer to <b>BSTR</b> containing name of application.</param>
		/// <param name="lMediaType">Media associated with application.</param>
		/// <param name="fPriority">
		/// The new priority for the application. If the value VARIANT_FALSE is passed, the application is removed from the priority list for
		/// the specified media or request mode (if it was already not present, no error is generated). If the value VARIANT_TRUE is passed,
		/// the application is inserted as the highest-priority application for the media or request mode (and removed from a lower-priority
		/// position, if it was already in the list).
		/// </param>
		/// <remarks>
		/// <para>
		/// The application must use <c>SysAllocString</c> to allocate memory for the <i>pAppFilename</i> parameter and use
		/// <c>SysFreeString</c> to free the memory when the variable is no longer needed.
		/// </para>
		/// <para>
		/// The Priorities that are set with <b>SetApplicationPriority</b> will persist across reboots of the system or restarts of tapisrv.
		/// The <c>ITTAPI::RegisterCallNotifications</c> function opens the line with no specified call priorities. By default, the highest
		/// priority application will be the one that first called <b>ITTAPI::RegisterCallNotifications</b>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-setapplicationpriority HRESULT
		// SetApplicationPriority( [in] BSTR pAppFilename, [in] long lMediaType, [in] VARIANT_BOOL fPriority );
		[DispId(65548)]
		void SetApplicationPriority([In, MarshalAs(UnmanagedType.BStr)] string pAppFilename, [In] TAPIMEDIATYPE lMediaType,
			[In] bool fPriority);

		/// <summary>Gets or sets the current event filter mask. The mask is a series of ORed members of the <c>TAPI_EVENT</c> enumeration.</summary>
		/// <value>The event filter mask.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-get_eventfilter HRESULT get_EventFilter( [out] long
		// *plFilterMask );
		[DispId(65551)]
		TAPI_EVENT EventFilter
		{
			[DispId(65551)]
			[param: In]
			set;
			[DispId(65551)]
			get;
		}
	}

	/// <summary>
	/// The <b>ITTAPI2</b> interface derives from the <c>ITTAPI</c> interface. It adds additional methods on the TAPI object to support phone devices.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nn-tapi3if-ittapi2
	[PInvokeData("tapi3if.h", MSDNShortId = "NN:tapi3if.ITTAPI2")]
	[ComImport, Guid("54FBDC8C-D90F-4DAD-9695-B373097F094B"), CoClass(typeof(TAPI))]
	public interface ITTAPI2 : ITTAPI
	{
		/// <summary>
		/// The <b>Initialize</b> method initializes TAPI. This method must be called before calling any other TAPI 3 method. The application
		/// must call the <c>Shutdown</c> method when ending a TAPI session.
		/// </summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><b>S_OK</b></description>
		/// <description>Method succeeded.</description>
		/// </item>
		/// <item>
		/// <description><b>S_FALSE</b></description>
		/// <description>TAPI has already been initialized.</description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b></description>
		/// <description>Insufficient memory exists to perform the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-initialize HRESULT Initialize();
		[DispId(65549)]
		[PreserveSig]
		new HRESULT Initialize();

		/// <summary>The <b>Shutdown</b> method shuts down a TAPI session.</summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><b>S_OK</b></description>
		/// <description>Method succeeded.</description>
		/// </item>
		/// <item>
		/// <description><b>S_FALSE</b></description>
		/// <description>TAPI session has already been shut down.</description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b></description>
		/// <description>Insufficient memory exists to perform the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>One reason why <b>Shutdown</b> might fail is if <c>Initialize</c> was not previously called successfully.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-shutdown HRESULT Shutdown();
		[DispId(65550)]
		[PreserveSig]
		new HRESULT Shutdown();

		/// <summary>
		/// The <b>get_Addresses</b> method creates a collection of addresses that are currently available. Provided for Automation client
		/// applications, such as those written in Visual Basic. C and C++ applications must use the <c>EnumerateAddresses</c> method.
		/// </summary>
		/// <value>Pointer to a <b>VARIANT</b> containing an <c>ITCollection</c> of <c>ITAddress</c> interface pointers (address objects).</value>
		/// <remarks>
		/// TAPI calls the <b>Addref</b> method on the <c>ITAddress</c> interface returned by <b>ITTAPI::get_Addesses</b>. The application
		/// must call <b>Release</b> on the <b>ITAddress</b> interface to free resources associated with it.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-get_addresses HRESULT get_Addresses( [out] VARIANT
		// *pVariant );
		[DispId(65537)]
		new object Addresses
		{
			[DispId(65537)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>EnumerateAddresses</b> method enumerates the addresses that are currently available. Provided for C and C++ applications.
		/// Automation client applications, such as those written in Visual Basic, must use the <c>get_Addresses</c> method.
		/// </summary>
		/// <returns>Pointer to the <c>IEnumAddress</c> interface.</returns>
		/// <remarks>
		/// <para>
		/// An application typically uses this enumeration to check the capabilities of each address and determine which are useful for
		/// current purposes.
		/// </para>
		/// <para>
		/// If an expected address is not found, this may indicate that the appropriate service provider has not been installed or is not
		/// working correctly.
		/// </para>
		/// <para>
		/// TAPI calls the <b>Addref</b> method on the <c>IEnumAddress</c> interface returned by <b>ITTAPI::EnumerateAddresses</b>. The
		/// application must call the <b>Release</b> method on the <b>IEnumAddress</b> interface to free resources associated with it.
		/// </para>
		/// <para>
		/// If an address is created or removed during a TAPI session, the application will be notified through the
		/// <c>ITTAPIEventNotification</c> interface. If an address has been created, such as by installing a Plug and Play device, the
		/// <c>ITTAPIEventNotification::Event</c> returns the <b>TE_ADDRESSCREATE</b> member of the <c>TAPIOBJECT_EVENT</c> enum. If an
		/// address is removed, <b>ITTAPIEventNotification::Event</b> returns <b>TE_ADDRESSREMOVE</b>. Calling <b>EnumerateAddresses</b>
		/// after these events will reflect the current addresses.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-enumerateaddresses HRESULT EnumerateAddresses( [out]
		// IEnumAddress **ppEnumAddress );
		[DispId(65538)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IEnumAddress EnumerateAddresses();

		/// <summary>
		/// <para>
		/// The <b>RegisterCallNotifications</b> method sets which new call notifications an application will receive. The application must
		/// call the method for each address, indicating media type or types it can handle, and specifying the privileges it requests.
		/// </para>
		/// <para>An application that will make only outgoing calls does not need to call this method.</para>
		/// <para>The <c>ITTAPIEventNotification</c> outgoing interface must be registered prior to calling this method.</para>
		/// <para>
		/// If both owner and monitor privileges are needed for an address, this method should be called only once, with both <i>fMonitor</i>
		/// and <i>fOwner</i> set to <b>TRUE</b>.
		/// </para>
		/// </summary>
		/// <param name="pAddress">Pointer to <c>ITAddress</c> interface.</param>
		/// <param name="fMonitor">
		/// Boolean value indicating whether the application will monitor calls. VARIANT_TRUE indicates that the application will monitor
		/// calls; VARIANT_FALSE that it will not.
		/// </param>
		/// <param name="fOwner">
		/// Boolean value indicating whether the application will own incoming calls. VARIANT_TRUE indicates that the application will own
		/// incoming calls; VARIANT_FALSE indicates that it will not.
		/// </param>
		/// <param name="lMediaTypes"><c>Media types</c> that can be handled by the application.</param>
		/// <param name="lCallbackInstance">
		/// Callback instance to be used by the TAPI 3 DLL. Can be the gulAdvise value returned by <c>IConnectionPoint::Advise</c> during
		/// registration of the <c>ITTAPIEventNotification</c> outgoing interface.
		/// </param>
		/// <returns>On success, the returned value that is used by <c>ITTAPI::UnregisterNotifications</c>.</returns>
		/// <remarks>
		/// <para>
		/// If multiple calls of this method are used on one address, the information about participant calls from a call hub may be
		/// confusing if a call that is already being monitored by the application is handed off to it.
		/// </para>
		/// <para>
		/// The <b>RegisterCallNotifications</b> method registers the application as having an interest in monitoring calls or receiving
		/// ownership of calls that are of the specified media types. These call privileges are set in the <i>fMonitor</i> and <i>fOwner</i>
		/// parameters. An application can specify multiple flags to handle multiple media types. Conflicts can arise if multiple
		/// applications register for the same address and media type. These conflicts are resolved by a priority scheme in which the user
		/// assigns relative priorities to the applications. Users can set application priorities by calling the
		/// <c>ITTAPI::SetApplicationPriority</c> function. Only the highest priority application for a given media type will receive
		/// ownership (unsolicited) of a call of that media type. Ownership can be received when an incoming call first arrives or when a
		/// call is handed off. The <c>ITBasicCallControl::HandoffDirect</c> and <c>ITBasicCallControl::HandoffIndirect</c> functions are
		/// called to hand off ownership of a call to another application. If the user does not assign priorities to the application, and
		/// multiple applications open the same line device, by default, the application that called <b>RegisterCallNotifications</b> first
		/// will have the highest priority.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-registercallnotifications HRESULT
		// RegisterCallNotifications( [in] ITAddress *pAddress, [in] VARIANT_BOOL fMonitor, [in] VARIANT_BOOL fOwner, [in] long lMediaTypes,
		// [in] long lCallbackInstance, [out] long *plRegister );
		[DispId(65539)]
		new int RegisterCallNotifications([In, MarshalAs(UnmanagedType.Interface)] ITAddress pAddress, [In] bool fMonitor,
			[In] bool fOwner, [In] TAPIMEDIATYPE lMediaTypes, [In] int lCallbackInstance);

		/// <summary>
		/// The <b>UnregisterNotifications</b> method removes any incoming call notification registrations that have been performed using <c>ITTAPI::RegisterCallNotifications</c>.
		/// </summary>
		/// <param name="lRegister">The value returned by the <c>RegisterCallNotifications</c> method in the <i>plRegister</i> parameter.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><b>S_OK</b></description>
		/// <description>Method succeeded.</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b></description>
		/// <description>The TAPI object has not yet been initialized or the <i>lRegister</i> parameter is not valid.</description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b></description>
		/// <description>Insufficient memory exists to perform the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-unregisternotifications HRESULT
		// UnregisterNotifications( [in] long lRegister );
		[DispId(65540)]
		[PreserveSig]
		new HRESULT UnregisterNotifications([In] int lRegister);

		/// <summary>
		/// The <b>get_CallHubs</b> method creates a collection of the currently available call hubs. Provided for Automation client
		/// applications, such as those written in Visual Basic. C and C++ applications must use the <c>EnumerateCallHubs</c> method.
		/// </summary>
		/// <value>Pointer to <b>VARIANT</b> containing an <c>ITCollection</c> of <c>ITCallHub</c> interface pointers (CallHub objects).</value>
		/// <remarks>
		/// TAPI calls the <b>Addref</b> method on the <c>ITCallHub</c> interface returned by <b>ITTAPI::get_CallHubs</b>. The application
		/// must call <b>Release</b> on the <b>ITCallHub</b> interface to free resources associated with it.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-get_callhubs HRESULT get_CallHubs( [out] VARIANT
		// *pVariant );
		[DispId(65541)]
		new object CallHubs
		{
			[DispId(65541)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>EnumerateCallHubs</b> method enumerates the currently available call hubs. Provided for C and C++ applications. Automation
		/// client applications, such as those written in Visual Basic, must use the <c>get_Callhubs</c> method.
		/// </summary>
		/// <returns>Pointer to the <c>IEnumCallHub</c> interface.</returns>
		/// <remarks>
		/// TAPI calls the <b>Addref</b> method on the <c>IEnumCallHub</c> interface returned by <b>ITTAPI::EnumerateCallHubs</b>. The
		/// application must call <b>Release</b> on the <b>IEnumCallHub</b> interface to free resources associated with it.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-enumeratecallhubs HRESULT EnumerateCallHubs( [out]
		// IEnumCallHub **ppEnumCallHub );
		[DispId(65542)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IEnumCallHub EnumerateCallHubs();

		/// <summary>The <b>SetCallHubTracking</b> method enables or disables CallHub tracking.</summary>
		/// <param name="pAddresses">Pointer to a <b>VARIANT</b> containing a <b>SAFEARRAY</b> of <c>ITAddress</c> interface pointers.</param>
		/// <param name="bTracking">VARIANT_TRUE to enable tracking, VARIANT_FALSE to disable.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-setcallhubtracking HRESULT SetCallHubTracking( [in]
		// VARIANT pAddresses, [in] VARIANT_BOOL bTracking );
		[DispId(65543)]
		new void SetCallHubTracking([In, MarshalAs(UnmanagedType.Struct, SafeArraySubType = VarEnum.VT_DISPATCH)] object pAddresses, [In] bool bTracking);

		/// <summary>This method is not implemented and will return E_NOTIMPL.</summary>
		/// <param name="ppEnumUnknown">This method is not implemented.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-enumerateprivatetapiobjects HRESULT
		// EnumeratePrivateTAPIObjects( [out] IEnumUnknown **ppEnumUnknown );
		[DispId(65544)]
		new void EnumeratePrivateTAPIObjects([MarshalAs(UnmanagedType.Interface)] out IEnumUnknown ppEnumUnknown);

		/// <summary>This method is not implemented and will return E_NOTIMPL.</summary>
		/// <value>This method is not implemented.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-get_privatetapiobjects HRESULT
		// get_PrivateTAPIObjects( [out] VARIANT *pVariant );
		[DispId(65545)]
		new object PrivateTAPIObjects
		{
			[DispId(65545)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>RegisterRequestRecipient</b> method registers an application instance as being the proper one to handle assisted telephony requests.
		/// </summary>
		/// <param name="lRegistrationInstance">Pointer to registration instance.</param>
		/// <param name="lRequestMode">Request mode.</param>
		/// <param name="fEnable">
		/// VARIANT_TRUE indicates that the caller wants to register as the handler; VARIANT_FALSE that it wants to unregister as the handler.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-registerrequestrecipient HRESULT
		// RegisterRequestRecipient( [in] long lRegistrationInstance, [in] long lRequestMode, [in] VARIANT_BOOL fEnable );
		[DispId(65546)]
		new void RegisterRequestRecipient([In] int lRegistrationInstance, [In] int lRequestMode, [In] bool fEnable);

		/// <summary>The <b>SetAssistedTelephonyPriority</b> method sets the application priority to handle assisted telephony requests.</summary>
		/// <param name="pAppFilename">Pointer to a <b>BSTR</b> containing the name of the application.</param>
		/// <param name="fPriority">Set to VARIANT_FALSE to disable, VARIANT_TRUE to enable.</param>
		/// <remarks>
		/// The application must use <c>SysAllocString</c> to allocate memory for the <i>pAppFilename</i> parameter and use
		/// <c>SysFreeString</c> to free the memory when the variable is no longer needed.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-setassistedtelephonypriority HRESULT
		// SetAssistedTelephonyPriority( [in] BSTR pAppFilename, [in] VARIANT_BOOL fPriority );
		[DispId(65547)]
		new void SetAssistedTelephonyPriority([In, MarshalAs(UnmanagedType.BStr)] string pAppFilename, [In] bool fPriority);

		/// <summary>
		/// The <b>SetApplicationPriority</b> method allows an application to set its priority in the handoff priority list for a particular
		/// media type or Assisted Telephony request mode, or to remove itself from the priority list.
		/// </summary>
		/// <param name="pAppFilename">Pointer to <b>BSTR</b> containing name of application.</param>
		/// <param name="lMediaType">Media associated with application.</param>
		/// <param name="fPriority">
		/// The new priority for the application. If the value VARIANT_FALSE is passed, the application is removed from the priority list for
		/// the specified media or request mode (if it was already not present, no error is generated). If the value VARIANT_TRUE is passed,
		/// the application is inserted as the highest-priority application for the media or request mode (and removed from a lower-priority
		/// position, if it was already in the list).
		/// </param>
		/// <remarks>
		/// <para>
		/// The application must use <c>SysAllocString</c> to allocate memory for the <i>pAppFilename</i> parameter and use
		/// <c>SysFreeString</c> to free the memory when the variable is no longer needed.
		/// </para>
		/// <para>
		/// The Priorities that are set with <b>SetApplicationPriority</b> will persist across reboots of the system or restarts of tapisrv.
		/// The <c>ITTAPI::RegisterCallNotifications</c> function opens the line with no specified call priorities. By default, the highest
		/// priority application will be the one that first called <b>ITTAPI::RegisterCallNotifications</b>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-setapplicationpriority HRESULT
		// SetApplicationPriority( [in] BSTR pAppFilename, [in] long lMediaType, [in] VARIANT_BOOL fPriority );
		[DispId(65548)]
		new void SetApplicationPriority([In, MarshalAs(UnmanagedType.BStr)] string pAppFilename, [In] TAPIMEDIATYPE lMediaType,
			[In] bool fPriority);

		/// <summary>Gets or sets the current event filter mask. The mask is a series of ORed members of the <c>TAPI_EVENT</c> enumeration.</summary>
		/// <value>The event filter mask.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi-get_eventfilter HRESULT get_EventFilter( [out] long
		// *plFilterMask );
		[DispId(65551)]
		new TAPI_EVENT EventFilter
		{
			[DispId(65551)]
			get;
			[DispId(65551)]
			[param: In]
			set;
		}

		/// <summary>
		/// The get_Phones method enumerates the phone objects corresponding to the phone devices. If there are no phones available that can
		/// be used with the address, this method produces an empty collection and returns S_OK.
		/// </summary>
		/// <value>Pointer to a VARIANT containing an ITCollection of ITPhone interface pointers.</value>
		[DispId(65552)]
		object Phones
		{
			[DispId(65552)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>EnumeratePhones</b> method enumerates the phone objects corresponding to the phone devices. If there are no phones
		/// available that can be used with the address, this method produces an empty enumeration and returns S_OK.
		/// </para>
		/// <para>
		/// This method is intended for C/C++ applications. Visual Basic and scripting applications must use the <c>get_Phones</c> method.
		/// </para>
		/// </summary>
		/// <returns>Pointer to an <c>IEnumPhone</c> interface.</returns>
		/// <remarks>
		/// TAPI calls the <b>AddRef</b> method on the <c>IEnumPhone</c> interface returned by <b>ITTAPI2::EnumeratePhones</b>. The
		/// application must call <b>Release</b> on the <b>IEnumPhone</b> interface to free resources associated with it.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi2-enumeratephones HRESULT EnumeratePhones( [out]
		// IEnumPhone **ppEnumPhone );
		[DispId(65553)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumPhone EnumeratePhones();

		/// <summary>
		/// <para>
		/// The <b>CreateEmptyCollectionObject</b> method creates an empty collection object. The collection can be filled with
		/// <c>ITDetectTone</c> or <c>ITCustomTone</c> objects for use with the <c>DetectTonesByCollection</c> method or the
		/// <c>GenerateCustomTonesByCollection</c> method, respectively.
		/// </para>
		/// <para>This method is intended for Visual Basic and scripting applications.</para>
		/// </summary>
		/// <returns>Pointer to an <c>ITCollection2</c> interface on the new collection object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapi2-createemptycollectionobject HRESULT
		// CreateEmptyCollectionObject( [out] ITCollection2 **ppCollection );
		[DispId(65554)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ITCollection2 CreateEmptyCollectionObject();
	}

	[ComImport, Guid("5AFC3154-4BCC-11D1-BF80-00805FC147D3")]
	public interface ITTAPICallCenter
	{
		[DispId(131073)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumAgentHandler EnumerateAgentHandlers();

		[DispId(131074)]
		object AgentHandlers
		{
			[DispId(131074)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}
	}

	/// <summary>
	/// <para>
	/// The <b>ITTAPIEventNotification</b> interface is an outgoing interface that allows an application to control the processing of event
	/// information. The application must implement this interface: it must create a COM object that supports this interface, and then
	/// register it using the COM standard <c>IConnectionPointContainer</c> and <c>IConnectionPoint</c> interfaces.
	/// </para>
	/// <para>
	/// The <c>ITTAPIEventNotification::Event</c> method of this interface is called by TAPI in response to an event. Typically, the
	/// application implements a set of switch statements that use the value of a <c>TAPI_EVENT</c> enumerator to determine the response to
	/// the event.
	/// </para>
	/// <para>
	/// After registration of this interface, the application calls <c>ITTAPI::put_EventFilter</c> to specify which events it must receive.
	/// If this method is not called, the application will not receive any events.
	/// </para>
	/// <para>
	/// The application may then call <c>ITTAPI::RegisterCallNotifications</c> to notify TAPI of addresses and media types for which the
	/// application will accept incoming call sessions.
	/// </para>
	/// <para>Please refer to the <c>Event</c> overview for additional information on event handling.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nn-tapi3if-ittapieventnotification
	[PInvokeData("tapi3if.h", MSDNShortId = "NN:tapi3if.ITTAPIEventNotification")]
	[ComImport, Guid("EDDB9426-3B91-11D1-8F30-00C04FB6809F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITTAPIEventNotification
	{
		/// <summary>
		/// The <b>Event</b> method is called by TAPI to determine the response to an asynchronous event notification. The application
		/// implements a set of case statements that use <i>TapiEvent</i> to determine the type of event being signaled, then calls
		/// <b>IUnknown::QueryInterface</b> on <i>pEvent</i> to obtain the appropriate event interface pointer. Each event defined by TAPI 3
		/// has an interface associated with it. The specific events handled depend on the needs of the application.
		/// </summary>
		/// <param name="TapiEvent"><c>TAPI_EVENT</c> indicator of the event.</param>
		/// <param name="pEvent">Pointer to an <b>IDispatch</b> interface of the object associated with this event.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><b>S_OK</b></description>
		/// <description>Method succeeded.</description>
		/// </item>
		/// <item>
		/// <description><b>E_POINTER</b></description>
		/// <description>The <i>pEvent</i> parameter is not a valid pointer.</description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b></description>
		/// <description>Insufficient memory exists to perform the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// You must call the <c>ITTAPI::put_EventFilter</c> method to set the event filter mask and enable reception of events. If you do
		/// not call <b>ITTAPI::put_EventFilter</b>, your application will not receive any events.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapieventnotification-event HRESULT Event( [in]
		// TAPI_EVENT TapiEvent, [in] IDispatch *pEvent );
		[PreserveSig]
		HRESULT Event([In] TAPI_EVENT TapiEvent, [In, MarshalAs(UnmanagedType.IDispatch)] object pEvent);
	}

	/// <summary>
	/// <para>
	/// The <b>ITTAPIObjectEvent</b> interface contains methods that retrieve the description of TAPI object events. When the application's
	/// implementation of the <c>ITTAPIEventNotification::Event</c> method indicates a <c>TAPI_EVENT</c> equal to <b>TE_TAPIOBJECT</b>, the
	/// method's <i>pEvent</i> parameter is an <c>IDispatch</c> pointer for the <b>ITTAPIObjectEvent</b> interface. The methods of this
	/// interface can be used to retrieve information concerning the TAPI object change that has occurred.
	/// </para>
	/// <para>
	/// <b>Note</b>  You must call the <c>ITTAPI::put_EventFilter</c> method and set an event filter mask that includes the
	/// <b>TE_TAPIOBJECT</b> event to enable reception of TAPI object events. If you do not call <b>ITTAPI::put_EventFilter</b>, your
	/// application will not receive any events. For more information, see the <c>Events</c> overview.
	/// </para>
	/// <para></para>
	/// <para>
	/// The <c>ITTAPIObjectEvent2</c> interface is an extension of the <b>ITTAPIObjectEvent</b> interface. <b>ITTAPIObjectEvent2</b> exposes
	/// an additional method that returns a pointer to an <c>ITPhone</c> interface on the phone object that caused the TAPI object event.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nn-tapi3if-ittapiobjectevent
	[PInvokeData("tapi3if.h", MSDNShortId = "NN:tapi3if.ITTAPIObjectEvent")]
	[ComImport, Guid("F4854D48-937A-11D1-BB58-00C04FB6809F")]
	public interface ITTAPIObjectEvent
	{
		/// <summary>The <b>get_TAPIObject</b> method gets a pointer to the <c>TAPI object</c> on which the event occurred.</summary>
		/// <value>Pointer to an <c>ITTAPI</c> interface of the TAPI object on which the event occurred.</value>
		/// <remarks>
		/// TAPI calls the <b>AddRef</b> method on the <c>ITTAPI</c> interface returned by <b>ITTAPIObjectEvent::get_TAPIObject</b>. The
		/// application must call <b>Release</b> on the <b>ITTAPI</b> interface to free resources associated with it.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapiobjectevent-get_tapiobject HRESULT get_TAPIObject(
		// [out] ITTAPI **ppTAPIObject );
		[DispId(1)]
		ITTAPI TAPIObject
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// The <b>get_Event</b> method gets information concerning an asynchronous event notification. The application uses
		/// <c>TAPIOBJECT_EVENT</c> to determine what type of event is being signaled.
		/// </summary>
		/// <value><c>TAPIOBJECT_EVENT</c> indicator of the event.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapiobjectevent-get_event HRESULT get_Event( [out]
		// TAPIOBJECT_EVENT *pEvent );
		[DispId(2)]
		TAPIOBJECT_EVENT Event
		{
			[DispId(2)]
			get;
		}

		/// <summary>The <b>get_Address</b> method gets a pointer to the Address object on which the event occurred.</summary>
		/// <value>Pointer to an <c>ITAddress</c> interface pointer.</value>
		/// <remarks>
		/// TAPI calls the <b>AddRef</b> method on the <c>ITAddress</c> interface returned by <b>ITTAPIObjectEvent::get_Address</b>. The
		/// application must call <b>Release</b> on the <b>ITAddress</b> interface to free resources associated with it.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapiobjectevent-get_address HRESULT get_Address( [out]
		// ITAddress **ppAddress );
		[DispId(3)]
		ITAddress Address
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>get_CallbackInstance</b> method gets a pointer to the callback instance associated with the event.</summary>
		/// <value>Pointer to the callback instance returned by <c>ITTAPI::RegisterCallNotifications</c>.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapiobjectevent-get_callbackinstance HRESULT
		// get_CallbackInstance( [out] long *plCallbackInstance );
		[DispId(4)]
		int CallbackInstance
		{
			[DispId(4)]
			get;
		}
	}

	/// <summary>
	/// <para>
	/// The <b>ITTAPIObjectEvent2</b> interface is an extension of the <c>ITTAPIObjectEvent</c> interface. <b>ITTAPIObjectEvent2</b> exposes
	/// an additional method that returns a pointer to an <c>ITPhone</c> interface on the phone object that caused the TAPI object event.
	/// </para>
	/// <para>
	/// When the application's implementation of the <c>ITTAPIEventNotification::Event</c> method indicates a <c>TAPI_EVENT</c> equal to
	/// <b>TE_TAPIOBJECT</b>, the method's <i>pEvent</i> parameter is an <b>IDispatch</b> pointer for the <b>ITTAPIObjectEvent2</b> interface.
	/// </para>
	/// <para>
	/// <b>Note</b>  You must call the <c>ITTAPI::put_EventFilter</c> method and set an event filter mask that includes the
	/// <b>TE_TAPIOBJECT</b> event to enable reception of TAPI object events. If you do not call <b>ITTAPI::put_EventFilter</b>, your
	/// application will not receive any events. For more information, see the <c>Events</c> overview.
	/// </para>
	/// <para></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nn-tapi3if-ittapiobjectevent2?redirectedfrom=MSDN
	[PInvokeData("tapi3if.h", MSDNShortId = "NN:tapi3if.ITTAPIObjectEvent2")]
	[ComImport, Guid("359DDA6E-68CE-4383-BF0B-169133C41B46")]
	public interface ITTAPIObjectEvent2 : ITTAPIObjectEvent
	{
		/// <summary>The <b>get_TAPIObject</b> method gets a pointer to the <c>TAPI object</c> on which the event occurred.</summary>
		/// <value>Pointer to an <c>ITTAPI</c> interface of the TAPI object on which the event occurred.</value>
		/// <remarks>
		/// TAPI calls the <b>AddRef</b> method on the <c>ITTAPI</c> interface returned by <b>ITTAPIObjectEvent::get_TAPIObject</b>. The
		/// application must call <b>Release</b> on the <b>ITTAPI</b> interface to free resources associated with it.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapiobjectevent-get_tapiobject HRESULT get_TAPIObject(
		// [out] ITTAPI **ppTAPIObject );
		[DispId(1)]
		new ITTAPI TAPIObject
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// The <b>get_Event</b> method gets information concerning an asynchronous event notification. The application uses
		/// <c>TAPIOBJECT_EVENT</c> to determine what type of event is being signaled.
		/// </summary>
		/// <value><c>TAPIOBJECT_EVENT</c> indicator of the event.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapiobjectevent-get_event HRESULT get_Event( [out]
		// TAPIOBJECT_EVENT *pEvent );
		[DispId(2)]
		new TAPIOBJECT_EVENT Event
		{
			[DispId(2)]
			get;
		}

		/// <summary>The <b>get_Address</b> method gets a pointer to the Address object on which the event occurred.</summary>
		/// <value>Pointer to an <c>ITAddress</c> interface pointer.</value>
		/// <remarks>
		/// TAPI calls the <b>AddRef</b> method on the <c>ITAddress</c> interface returned by <b>ITTAPIObjectEvent::get_Address</b>. The
		/// application must call <b>Release</b> on the <b>ITAddress</b> interface to free resources associated with it.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapiobjectevent-get_address HRESULT get_Address( [out]
		// ITAddress **ppAddress );
		[DispId(3)]
		new ITAddress Address
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>get_CallbackInstance</b> method gets a pointer to the callback instance associated with the event.</summary>
		/// <value>Pointer to the callback instance returned by <c>ITTAPI::RegisterCallNotifications</c>.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-ittapiobjectevent-get_callbackinstance HRESULT
		// get_CallbackInstance( [out] long *plCallbackInstance );
		[DispId(4)]
		new int CallbackInstance
		{
			[DispId(4)]
			get;
		}

		[DispId(5)]
		ITPhone Phone
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	[ComImport, Guid("B1EFC38A-9355-11D0-835C-00AA003CCABD")]
	public interface ITTerminal
	{
		[DispId(1)]
		string Name
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(2)]
		TERMINAL_STATE State
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		TERMINAL_TYPE TerminalType
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		string TerminalClass
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(5)]
		TAPIMEDIATYPE MediaType
		{
			[DispId(5)]
			get;
		}

		[DispId(6)]
		TERMINAL_DIRECTION Direction
		{
			[DispId(6)]
			get;
		}
	}

	[ComImport, Guid("B1EFC385-9355-11D0-835C-00AA003CCABD")]
	public interface ITTerminalSupport
	{
		[DispId(393217)]
		object StaticTerminals
		{
			[DispId(393217)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(393218)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumTerminal EnumerateStaticTerminals();

		[DispId(393219)]
		object DynamicTerminalClasses
		{
			[DispId(393219)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(393220)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumTerminalClass EnumerateDynamicTerminalClasses();

		[DispId(393221)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ITTerminal CreateTerminal([In, MarshalAs(UnmanagedType.BStr)] string pTerminalClass, [In] TAPIMEDIATYPE lMediaType,
			[In] TERMINAL_DIRECTION Direction);

		[DispId(393222)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ITTerminal GetDefaultStaticTerminal([In] TAPIMEDIATYPE lMediaType, [In] TERMINAL_DIRECTION Direction);
	}

	[ComImport, Guid("F3EB39BC-1B1F-4E99-A0C0-56305C4DD591")]
	public interface ITTerminalSupport2 : ITTerminalSupport
	{
		[DispId(393217)]
		new object StaticTerminals
		{
			[DispId(393217)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(393218)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IEnumTerminal EnumerateStaticTerminals();

		[DispId(393219)]
		new object DynamicTerminalClasses
		{
			[DispId(393219)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(393220)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IEnumTerminalClass EnumerateDynamicTerminalClasses();

		[DispId(393221)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new ITTerminal CreateTerminal([In, MarshalAs(UnmanagedType.BStr)] string pTerminalClass, [In] TAPIMEDIATYPE lMediaType, [In] TERMINAL_DIRECTION Direction);

		[DispId(393222)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new ITTerminal GetDefaultStaticTerminal([In] TAPIMEDIATYPE lMediaType, [In] TERMINAL_DIRECTION Direction);

		[DispId(393223)]
		object PluggableSuperclasses
		{
			[DispId(393223)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(393224)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumPluggableSuperclassInfo EnumeratePluggableSuperclasses();

		[DispId(393225)]
		object PluggableTerminalClasses
		{
			[DispId(393225)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(393226)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumPluggableTerminalClassInfo EnumeratePluggableTerminalClasses([In] Guid iidTerminalSuperclass,
			[In] TAPIMEDIATYPE lMediaType);
	}

	[ComImport, Guid("407E0FAF-D047-4753-B0C6-8E060373FECD")]
	public interface ITToneDetectionEvent
	{
		[DispId(1)]
		ITCallInfo Call
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		int AppSpecific
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		int TickCount
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		int CallbackInstance
		{
			[DispId(4)]
			get;
		}
	}

	[ComImport, Guid("E6F56009-611F-4945-BBD2-2D0CE5612056")]
	public interface ITToneTerminalEvent
	{
		[DispId(1)]
		ITTerminal Terminal
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		ITCallInfo Call
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(3)]
		HRESULT Error
		{
			get;
		}
	}

	[ComImport, Guid("D964788F-95A5-461D-AB0C-B9900A6C2713")]
	public interface ITTTSTerminalEvent
	{
		[DispId(1)]
		ITTerminal Terminal
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		ITCallInfo Call
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(3)]
		HRESULT Error
		{
			get;
		}
	}

	/// <summary>
	/// The <b>ConfigDialogEdit</b> method causes the provider of the specified line device to display a dialog box to allow the user to
	/// configure parameters related to the line device. The configuration data is passed in and out of this method by the application. (The
	/// data is the same as that retrieved by the <c>ITLegacyAddressMediaControl::GetDevConfig</c> method and set by the
	/// <c>ITLegacyAddressMediaControl::SetDevConfig</c> method.)
	/// </summary>
	/// <param name="mctrl">The <see cref="ITLegacyAddressMediaControl2"/> instance.</param>
	/// <param name="hwndOwner">A handle to a window to which the dialog box is to be attached. Can be <b>NULL</b> to indicate that a window created by the method
	/// should have no owner window.</param>
	/// <param name="pDeviceClass">Pointer to a <b>BSTR</b> that specifies a device class name. This device class allows the application to select a specific subscreen
	/// of configuration information applicable to that device class. This parameter is optional and can be left <b>NULL</b> or empty, in
	/// which case the highest level configuration is selected.</param>
	/// <param name="pDeviceConfigIn">Pointer to an array of bytes containing device configuration data to edit.</param>
	/// <param name="ppDeviceConfigOut">Pointer to an array of bytes containing edited device configuration data.</param>
	/// <returns>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
	/// <remarks>
	/// This method translates to a TAPI 2. <i>x</i><c>lineConfigDialogEdit</c> call. The <c>ITLegacyAddressMediaControl2::ConfigDialog</c>
	/// method translates to a <c>lineConfigDialog</c> call. These methods differ in their source of parameters to edit and the result of the
	/// editing on an active connection. For a discussion about these differences, see <c>lineConfigDialogEdit</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itlegacyaddressmediacontrol2-configdialogedit HRESULT
	// ConfigDialogEdit( [in] HWND hwndOwner, [in] BSTR pDeviceClass, [in] DWORD dwSizeIn, [in] BYTE *pDeviceConfigIn, [out] DWORD
	// *pdwSizeOut, [out] BYTE **ppDeviceConfigOut );
	public static HRESULT ConfigDialogEdit(this ITLegacyAddressMediaControl2 mctrl, [In] HWND hwndOwner, string pDeviceClass,
		[In] byte[] pDeviceConfigIn, out byte[] ppDeviceConfigOut)
	{
		var hr = mctrl.ConfigDialogEdit(hwndOwner, pDeviceClass, (uint)pDeviceConfigIn.Length, pDeviceConfigIn, out var pdwSizeOut, out var ppDeviceConfigOutHandle);
		if (hr.Succeeded)
		{
			ppDeviceConfigOutHandle.DangerousOverrideSize(pdwSizeOut);
			ppDeviceConfigOut = ppDeviceConfigOutHandle.GetBytes();
		}
		else
			ppDeviceConfigOut = [];
		return hr;
	}

	/// <summary>
	/// The <b>GetDevConfig</b> method returns an opaque data structure. The exact contents are specific to the service provider and device
	/// class. The data structure specifies the configuration of a device associated with a particular line device. For example, the contents
	/// of this structure could specify data rate, character format, modulation schemes, and error control protocol settings for a datamodem
	/// device associated with the line.
	/// </summary>
	/// <param name="mctrl">The <see cref="ITLegacyAddressMediaControl"/> instance.</param>
	/// <param name="pDeviceClass">Pointer to <b>BSTR</b> containing <c>TAPI device class</c> for which configuration information is needed.</param>
	/// <returns>Array of bytes containing device configuration information.</returns>
	/// <remarks>
	/// <para>This method is a COM wrapper for the <c>LineGetDevConfig</c> TAPI 2.1 function.</para>
	/// <para>The <c>GetID</c> must be performed prior to calling this method.</para>
	/// <para><b>TAPI 2.1 Cross-References:</b><c>lineGetDevConfig</c>, <c>lineSetDevConfig</c></para>
	/// </remarks>
	public static byte[] GetDevConfig(this ITLegacyAddressMediaControl mctrl, [In, MarshalAs(UnmanagedType.BStr)] string pDeviceClass)
	{
		mctrl.GetDevConfig(pDeviceClass, out var pdwSize, out var ppDeviceConfig);
		ppDeviceConfig.DangerousOverrideSize(pdwSize);
		return ppDeviceConfig.GetBytes();
	}

	/// <summary>
	/// <para>The <b>GetID</b> method returns a device identifier for the specified device class associated with the current address.</para>
	/// <para>
	/// This method is intended for C/C++ applications only. There is no corresponding method available for Visual Basic and scripting applications.
	/// </para>
	/// </summary>
	/// <param name="mctrl">The <see cref="ITLegacyAddressMediaControl"/> instance.</param>
	/// <param name="pDeviceClass">Pointer to <b>BSTR</b> containing <c>TAPI device class</c> for which configuration information is needed.</param>
	/// <returns>Device identifier.</returns>
	/// <remarks>
	/// <para>The application must call <c>ITTAPI::RegisterCallNotifications</c> prior to calling this method.</para>
	/// <para><b>TAPI 2.1 Cross-References:</b><c>lineGetDevConfig</c>, <c>lineSetDevConfig</c>, <c>lineGetID</c></para>
	/// </remarks>
	public static byte[] GetID(this ITLegacyAddressMediaControl mctrl, [In, MarshalAs(UnmanagedType.BStr)] string pDeviceClass)
	{
		mctrl.GetID(pDeviceClass, out var pdwSize, out var ppDeviceID);
		ppDeviceID.DangerousOverrideSize(pdwSize);
		return ppDeviceID.GetBytes();
	}

	/// <summary>
	/// <para>The <b>GetID</b> method gets the identifier for the device associated with the current call.</para>
	/// <para>
	/// This method is intended for C/C++ applications. Visual Basic and scripting applications should use the
	/// <c>ITLegacyCallMediaControl2::GetIDAsVariant</c> method.
	/// </para>
	/// </summary>
	/// <param name="mctrl">The <see cref="ITLegacyCallMediaControl"/> instance.</param>
	/// <param name="pDeviceClass">Pointer to <b>BSTR</b> representing the <c>TAPI device class</c>.</param>
	/// <returns></returns>
	/// <remarks>
	/// <para>The application must call <c>ITTAPI::RegisterCallNotifications</c> prior to calling this method.</para>
	/// <para>
	/// The application must use <c>SysAllocString</c> to allocate memory for the <i>pDeviceClass</i> parameter and use <c>SysFreeString</c>
	/// to free the memory when the variable is no longer needed.
	/// </para>
	/// <para>The application must call the <c>CoTaskMemFree</c> function to free the memory allocated for the <i>ppDeviceID</i> parameter.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tapi3if/nf-tapi3if-itlegacycallmediacontrol-getid HRESULT GetID( [in] BSTR
	// pDeviceClass, [out] DWORD *pdwSize, [out] BYTE **ppDeviceID );
	public static byte[] GetID(this ITLegacyCallMediaControl mctrl, string pDeviceClass)
	{
		mctrl.GetID(pDeviceClass, out var pd, out var ppDeviceID);
		using SafeCoTaskMemHandle mem = new(ppDeviceID, pd, true);
		return mem.GetBytes();
	}

	/// <summary>The <b>SetCallHubTracking</b> method enables or disables CallHub tracking.</summary>
	/// <param name="itapi">The <see cref="ITTAPI"/> instance.</param>
	/// <param name="pAddresses">Pointer to a <b>VARIANT</b> containing a <b>SAFEARRAY</b> of <c>ITAddress</c> interface pointers.</param>
	/// <param name="bTracking">VARIANT_TRUE to enable tracking, VARIANT_FALSE to disable.</param>
	public static void SetCallHubTracking(this ITTAPI itapi, ITAddress[] pAddresses, [In] bool bTracking) =>
		itapi.SetCallHubTracking(pAddresses, bTracking);

	/// <summary>
	/// The <b>SetDevConfig</b> function allows the application to restore the configuration of a media stream device on a line device to a
	/// setup previously obtained using <c>GetDevConfig</c>.
	/// </summary>
	/// <param name="mctrl">The <see cref="ITLegacyAddressMediaControl"/> instance.</param>
	/// <param name="pDeviceClass">Pointer to <b>BSTR</b> containing <c>TAPI device class</c> for which configuration information is needed.</param>
	/// <param name="pDeviceConfig">Array of bytes containing device configuration information obtained by a call to <c>GetDevConfig</c>.</param>
	/// <remarks>
	/// <para>This method is a COM wrapper for the <c>lineSetDevConfig</c> TAPI 2.1 function.</para>
	/// <para>The <c>GetID</c> must be performed prior to calling this method.</para>
	/// <para><b>TAPI 2.1 Cross-References:</b><c>lineGetDevConfig</c>, <c>lineSetDevConfig</c></para>
	/// </remarks>
	public static void SetDevConfig(this ITLegacyAddressMediaControl mctrl, string pDeviceClass, byte[] pDeviceConfig)
	{
		using SafeCoTaskMemHandle mem = new(pDeviceConfig);
		mctrl.SetDevConfig(pDeviceClass, mem.Size, mem);
	}

	/// <summary>
	/// <para>The <b>AM_MEDIA_TYPE</b> structure describes the format of a media sample.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// When two pins connect, they negotiate a media type, which is defined by an <b>AM_MEDIA_TYPE</b> structure. The media type describes
	/// the format of the data that the filters will exchange. If the filters do not agree on a media type, they cannot connect.
	/// </para>
	/// <para>
	/// The stream type is specified by two <b>GUIDs</b>, called the major type and the subtype. The major type defines the general category,
	/// such as video, audio, or byte stream. The subtype defines a narrower category within the major type. For example, video subtypes
	/// include 8-bit, 16-bit, 24-bit, and 32-bit RGB.
	/// </para>
	/// <para>
	/// The <b>AM_MEDIA_TYPE</b> structure is followed by a variable-length block of data that contains format-specific information. The
	/// <b>pbFormat</b> member points to this block, called the format block. The layout of the format block depends on the type of data in
	/// the stream, and is specified by the <b>formattype</b> member. The format block might be NULL. Check the <b>cbFormat</b> member to
	/// determine the size. Cast the <b>pbFormat</b> member to access the format block. For example:
	/// </para>
	/// <code language="cpp">if (pmt-&gt;formattype == FORMAT_VideoInfo)
	///{
	///  // Check the buffer size.
	///  if (pmt-&gt;cbFormat &gt;= sizeof(VIDEOINFOHEADER))
	///  {
	///    VIDEOINFOHEADER *pVih =
	///      reinterpret_cast&lt;VIDEOINFOHEADER*&gt;(pmt-&gt;pbFormat);
	///    /* Access VIDEOINFOHEADER members through pVih. */
	///  }
	///}</code>
	/// <para>
	/// In some situations, you can set the format block to NULL and the format type to GUID_NULL, resulting in a partial media type. This
	/// enables you to specify a range of possible formats. For example, you can specify 24-bit RGB (MEDIASUBTYPE_RGB24) without giving an
	/// exact width or height.
	/// </para>
	/// <para>To obtain detailed information about a specified media type for debugging purposes, use the <c>DisplayType</c> method.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/previous-versions/ms779120(v=vs.85)
	[PInvokeData("Dshow.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AM_MEDIA_TYPE
	{
		/// <summary>
		/// Globally unique identifier (GUID) that specifies the major type of the media sample. For a list of possible major types, see
		/// <c>Media Types</c>.
		/// </summary>
		public Guid majortype;

		/// <summary>
		/// GUID that specifies the subtype of the media sample. For a list of possible subtypes, see <c>Media Types</c>. For some formats,
		/// the value might be MEDIASUBTYPE_None, which means the format does not require a subtype.
		/// </summary>
		public Guid subtype;

		/// <summary>
		/// If TRUE, samples are of a fixed size. This field is informational only. For audio, it is generally set to TRUE. For video, it is
		/// usually TRUE for uncompressed video and FALSE for compressed video.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bFixedSizeSamples;

		/// <summary>
		/// If TRUE, samples are compressed using temporal (interframe) compression. A value of TRUE indicates that not all frames are key
		/// frames. This field is informational only.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bTemporalCompression;

		/// <summary>Size of the sample in bytes. For compressed data, the value can be zero.</summary>
		public uint lSampleSize;

		/// <summary>
		/// <para>
		/// GUID that specifies the structure used for the format block. The <b>pbFormat</b> member points to the corresponding format
		/// structure. Format types include the following:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><b>Format type</b></description>
		/// <description><b>Format structure</b></description>
		/// </listheader>
		/// <item>
		/// <description>FORMAT_DvInfo</description>
		/// <description><c><b>DVINFO</b></c></description>
		/// </item>
		/// <item>
		/// <description>FORMAT_MPEG2Video</description>
		/// <description><c><b>MPEG2VIDEOINFO</b></c></description>
		/// </item>
		/// <item>
		/// <description>FORMAT_MPEGStreams</description>
		/// <description><c><b>AM_MPEGSYSTEMTYPE</b></c></description>
		/// </item>
		/// <item>
		/// <description>FORMAT_MPEGVideo</description>
		/// <description><c><b>MPEG1VIDEOINFO</b></c></description>
		/// </item>
		/// <item>
		/// <description>FORMAT_None</description>
		/// <description>None.</description>
		/// </item>
		/// <item>
		/// <description>FORMAT_VideoInfo</description>
		/// <description><c><b>VIDEOINFOHEADER</b></c></description>
		/// </item>
		/// <item>
		/// <description>FORMAT_VideoInfo2</description>
		/// <description><c><b>VIDEOINFOHEADER2</b></c></description>
		/// </item>
		/// <item>
		/// <description>FORMAT_WaveFormatEx</description>
		/// <description><c><b>WAVEFORMATEX</b></c></description>
		/// </item>
		/// <item>
		/// <description>GUID_NULL</description>
		/// <description>None</description>
		/// </item>
		/// </list>
		/// </summary>
		public Guid formattype;

		/// <summary>Not used.</summary>
		public IntPtr pUnk;

		/// <summary>Size of the format block, in bytes.</summary>
		public uint cbFormat;

		/// <summary>
		/// Pointer to the format block. The structure type is specified by the <b>formattype</b> member. The format structure must be
		/// present, unless <b>formattype</b> is GUID_NULL or FORMAT_None.
		/// </summary>
		public IntPtr pbFormat;
	}

	/// <summary>CLSID_DispatchMapper</summary>
	[ComImport, Guid("E9225296-C759-11d1-A02B-00C04FB6809F"), ClassInterface(ClassInterfaceType.None)]
	public class DispatchMapper { }

	/// <summary>CLSID_RequestMakeCall</summary>
	[ComImport, Guid("AC48FFE0-F8C4-11d1-A030-00C04FB6809F"), ClassInterface(ClassInterfaceType.None)]
	public class RequestMakeCall { }

	/// <summary>CLSID_TAPI</summary>
	[ComImport, Guid("21D6D48E-A88B-11D0-83DD-00AA003CCABD"), ClassInterface(ClassInterfaceType.None)]
	public class TAPI { }
}