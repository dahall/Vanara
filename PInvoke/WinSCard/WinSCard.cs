global using System;
global using System.Runtime.InteropServices;
global using Vanara.InteropServices;

using System.Linq;

using SCARDCONTEXT = System.UIntPtr;

namespace Vanara.PInvoke;

/// <summary>
/// Provides the definitions and symbols necessary for an Application or Smart Card Service Provider to access the Smartcard Subsystem from WinSCard.dll.
/// </summary>
public static partial class WinSCard
{
	/// <summary>
	/// Group used when no group name is provided when listing readers. Returns a list of all readers, regardless of what group or groups the
	/// readers are in.
	/// </summary>
	public const string SCARD_ALL_READERS = "SCard$AllReaders\000";

	/// <summary>Value used to indicate that memory for a return value should be allocated by the function and freed using <see cref="SCardFreeMemory"/>.</summary>
	public const uint SCARD_AUTOALLOCATE = unchecked((uint)-1);

	/// <summary>Default group to which all readers are added when introduced into the system.</summary>
	public const string SCARD_DEFAULT_READERS = "SCard$DefaultReaders\000";

	/// <summary>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </summary>
	public const string SCARD_LOCAL_READERS = "SCard$LocalReaders\000";

	/// <summary>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </summary>
	public const string SCARD_SYSTEM_READERS = "SCard$SystemReaders\000";

	private const string Lib_Scarddlg = "scarddlg.dll";
	private const string Lib_Winscard = "winscard.dll";

	/// <summary>A card verify routine delegate.</summary>
	/// <param name="hSCardContext">The card context passed in the parameter block.</param>
	/// <param name="hcard">The card handle.</param>
	/// <param name="pvUserData">Pointer to user data passed in the parameter block.</param>
	/// <returns>
	/// If the card is rejected by the verify routine, <see langword="false"/> is returned, and the card will be disconnected. If the card is
	/// accepted by the verify routine, <see langword="true"/> is returned.
	/// </returns>
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
	public delegate bool LPOCNCHKPROC([In] SCARDCONTEXT hSCardContext, [In] SCARDHANDLE hcard, [In] IntPtr pvUserData);

	/// <summary>A card connect routine delegate.</summary>
	/// <param name="hSCardContext">The card context passed in the parameter block.</param>
	/// <param name="szReader">The name of the reader.</param>
	/// <param name="mszCards">The possible card names in the reader.</param>
	/// <param name="pvUserData">Pointer to user data passed in the parameter block.</param>
	/// <returns>If the connect function is successful, the card is left connected and initialized, and the card handle is returned.</returns>
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
	public delegate SCARDHANDLE LPOCNCONNPROC([In] SCARDCONTEXT hSCardContext, [In] string szReader, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")] string[] mszCards, [In] IntPtr pvUserData);

	/// <summary>A card disconnect routine delegate.</summary>
	/// <param name="hSCardContext">The card context passed in the parameter block.</param>
	/// <param name="hcard">The card handle.</param>
	/// <param name="pvUserData">Pointer to user data passed in the parameter block.</param>
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
	public delegate void LPOCNDSCPROC([In] SCARDCONTEXT hSCardContext, [In] SCARDHANDLE hcard, [In] IntPtr pvUserData);

	private delegate SCARD_RET SCardListCardsDelegate(IntPtr mszOut, ref uint pcch);

	/// <summary></summary>
	[PInvokeData("winscard.h", MSDNShortId = "NS:winscard.__unnamed_struct_4")]
	[Flags]
	public enum SC_DLG : uint
	{
		/// <summary>
		/// Display the dialog box only if the card being searched for by the calling application is not located and available for use in a
		/// reader. This allows the card to be found, connected (either through the internal dialog box mechanism or the user callback
		/// functions), and returned to the calling application.
		/// </summary>
		SC_DLG_MINIMAL_UI = 0x01,

		/// <summary>Force no display of the <c>Select Card</c> user interface (UI), regardless of search outcome.</summary>
		SC_DLG_NO_UI = 0x02,

		/// <summary>Force display of the <c>Select Card</c> UI, regardless of the search outcome.</summary>
		SC_DLG_FORCE_UI = 0x04,
	}

	/// <summary>Action to take on the card in the connected reader.</summary>
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardDisconnect")]
	public enum SCARD_ACTION
	{
		/// <summary>Do not do anything special.</summary>
		SCARD_LEAVE_CARD = 0,

		/// <summary>Reset the card.</summary>
		SCARD_RESET_CARD = 1,

		/// <summary>Power down the card.</summary>
		SCARD_UNPOWER_CARD = 2,

		/// <summary>Eject the card.</summary>
		SCARD_EJECT_CARD = 3,
	}

	/// <summary>The event to log.</summary>
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardAudit")]
	[Flags]
	public enum SCARD_AUDIT_CHV : uint
	{
		/// <summary>A smart card holder verification (CHV) attempt failed.</summary>
		SCARD_AUDIT_CHV_FAILURE = 0x0,

		/// <summary>A smart card holder verification (CHV) attempt succeeded.</summary>
		SCARD_AUDIT_CHV_SUCCESS = 0x1,
	}

	/// <summary></summary>
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardGetCardTypeProviderNameA")]
	public enum SCARD_PROVIDER
	{
		/// <summary>The function retrieves the name of the smart card's primary service provider as a GUID string.</summary>
		SCARD_PROVIDER_PRIMARY = 1,

		/// <summary>The function retrieves the name of the cryptographic service provider.</summary>
		SCARD_PROVIDER_CSP = 2,

		/// <summary>The function retrieves the name of the smart card key storage provider (KSP).</summary>
		SCARD_PROVIDER_KSP = 3,
	}

	/// <summary>Scope of the resource manager context.</summary>
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardEstablishContext")]
	public enum SCARD_SCOPE
	{
		/// <summary>Database operations are performed within the domain of the user.</summary>
		SCARD_SCOPE_USER = 0,

		/// <summary>Database operations are performed within the terminal session context.</summary>
		SCARD_SCOPE_TERMINAL = 1,

		/// <summary>
		/// Database operations are performed within the domain of the system. The calling application must have appropriate access
		/// permissions for any database actions.
		/// </summary>
		SCARD_SCOPE_SYSTEM = 2,
	}

	/// <summary>A flag that indicates whether other applications may form connections to the card.</summary>
	[PInvokeData("winscard.h", MSDNShortId = "NS:winscard.nf-winscard-scardconnecta")]
	public enum SCARD_SHARE : uint
	{
		/// <summary>This application is not willing to share the card with other applications.</summary>
		SCARD_SHARE_EXCLUSIVE = 1,

		/// <summary>This application is willing to share the card with other applications.</summary>
		SCARD_SHARE_SHARED = 2,

		/// <summary>
		/// This application is allocating the reader for its private use, and will be controlling it directly. No other applications are
		/// allowed access to it.
		/// </summary>
		SCARD_SHARE_DIRECT = 3,
	}

	/// <summary>State of the reader, as seen by the application.</summary>
	[PInvokeData("winscard.h", MSDNShortId = "NS:winscard.__unnamed_struct_0")]
	[Flags]
	public enum SCARD_STATE : uint
	{
		/// <summary>
		/// The application is unaware of the current state, and would like to know. The use of this value results in an immediate return
		/// from state transition monitoring services. This is represented by all bits set to zero.
		/// </summary>
		SCARD_STATE_UNAWARE = 0x00000000,

		/// <summary>
		/// The application is not interested in this reader, and it should not be considered during monitoring operations. If this bit value
		/// is set, all other bits are ignored.
		/// </summary>
		SCARD_STATE_IGNORE = 0x00000001,

		/// <summary>
		/// There is a difference between the state believed by the application, and the state known by the resource manager. When this bit
		/// is set, the application may assume a significant state change has occurred on this reader.
		/// </summary>
		SCARD_STATE_CHANGED = 0x00000002,

		/// <summary>
		/// The given reader name is not recognized by the resource manager. If this bit is set, then SCARD_STATE_CHANGED and
		/// SCARD_STATE_IGNORE will also be set.
		/// </summary>
		SCARD_STATE_UNKNOWN = 0x00000004,

		/// <summary>
		/// The application expects that this reader is not available for use. If this bit is set, then all the following bits are ignored.
		/// </summary>
		SCARD_STATE_UNAVAILABLE = 0x00000008,

		/// <summary>The application expects that there is no card in the reader. If this bit is set, all the following bits are ignored.</summary>
		SCARD_STATE_EMPTY = 0x00000010,

		/// <summary>The application expects that there is a card in the reader.</summary>
		SCARD_STATE_PRESENT = 0x00000020,

		/// <summary>
		/// The application expects that there is a card in the reader with an ATR that matches one of the target cards. If this bit is set,
		/// SCARD_STATE_PRESENT is assumed. This bit has no meaning to SCardGetStatusChange beyond SCARD_STATE_PRESENT.
		/// </summary>
		SCARD_STATE_ATRMATCH = 0x00000040,

		/// <summary>
		/// The application expects that the card in the reader is allocated for exclusive use by another application. If this bit is set,
		/// SCARD_STATE_PRESENT is assumed.
		/// </summary>
		SCARD_STATE_EXCLUSIVE = 0x00000080,

		/// <summary>
		/// The application expects that the card in the reader is in use by one or more other applications, but may be connected to in
		/// shared mode. If this bit is set, SCARD_STATE_PRESENT is assumed.
		/// </summary>
		SCARD_STATE_INUSE = 0x00000100,

		/// <summary>The application expects that there is an unresponsive card in the reader.</summary>
		SCARD_STATE_MUTE = 0x00000200,

		/// <summary>This implies that the card in the reader has not been powered up.</summary>
		SCARD_STATE_UNPOWERED = 0x00000400,
	}

	/// <summary>
	/// The <c>GetOpenCardName</c> function displays the smart card "select card" dialog box. Call the function SCardUIDlgSelectCard instead
	/// of <c>GetOpenCardName</c>. The <c>GetOpenCardName</c> function is maintained for backward compatibility with version 1.0 of the
	/// Microsoft Smart Card Base Components, but calls to <c>GetOpenCardName</c> are mapped to <c>SCardUIDlgSelectCard</c>.
	/// </summary>
	/// <param name="unnamedParam1">A pointer to the OPENCARDNAME structure for the "select card" dialog box.</param>
	/// <returns>
	/// <para>The function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines GetOpenCardName as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-getopencardnamea LONG GetOpenCardNameA( [in] LPOPENCARDNAMEA
	// unnamedParam1 );
	[DllImport(Lib_Scarddlg, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.GetOpenCardNameA")]
	public static extern SCARD_RET GetOpenCardName(in OPENCARDNAME unnamedParam1);

	/// <summary>
	/// The <c>SCardAccessStartedEvent</c> function returns an event handle when an event signals that the smart card resource manager is
	/// started. The event-object handle can be specified in a call to one of the wait functions.
	/// </summary>
	/// <returns>
	/// <para>The function returns an event HANDLE if it succeeds or <c>NULL</c> if it fails.</para>
	/// <para>If the function fails, the GetLastError function provides information on the cause of the failure.</para>
	/// </returns>
	/// <remarks>
	/// <para>The event-object handle returned can be specified in a call to one of the wait functions.</para>
	/// <para>
	/// Do not close the handle returned by this function. When you have finished using the handle, decrement the reference count by calling
	/// the SCardReleaseStartedEvent function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardaccessstartedevent HANDLE SCardAccessStartedEvent();
	[DllImport(Lib_Winscard, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardAccessStartedEvent")]
	public static extern HEVENT SCardAccessStartedEvent();

	/// <summary>The <c>SCardAddReaderToGroup</c> function adds a reader to a reader group.</summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context. The resource manager context is set by a previous call to SCardEstablishContext.
	/// This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szReaderName">Display name of the reader that you are adding.</param>
	/// <param name="szGroupName">
	/// <para>Display name of the group to which you are adding the reader.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_ALL_READERS</c> TEXT("SCard$AllReaders\000")</term>
	/// <term>
	/// Group used when no group name is provided when listing readers. Returns a list of all readers, regardless of what group or groups the
	/// readers are in.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_DEFAULT_READERS</c> TEXT("SCard$DefaultReaders\000")</term>
	/// <term>Default group to which all readers are added when introduced into the system.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_LOCAL_READERS</c> TEXT("SCard$LocalReaders\000")</term>
	/// <term>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_SYSTEM_READERS</c> TEXT("SCard$SystemReaders\000")</term>
	/// <term>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>SCardAddReaderToGroup</c> automatically creates the reader group specified if it does not already exist.</para>
	/// <para>
	/// The <c>SCardAddReaderToGroup</c> function is a database management function. For more information on other database management
	/// functions, see Smart Card Database Management Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example demonstrates how to add a smart card reader to a group. The example assumes that lReturn is an existing
	/// variable of type <c>LONG</c>, that <c>hContext</c> is a valid handle received from a previous call to the SCardEstablishContext
	/// function, and that "MyReader" and "MyReaderGroup" are known by the system through previous calls to the SCardIntroduceReader and
	/// SCardIntroduceReaderGroup functions, respectively.
	/// </para>
	/// <para>
	/// <code> lReturn = SCardAddReaderToGroup( hContext, L"MyReader", L"MyReaderGroup"); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardAddReaderToGroup\n");</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardAddReaderToGroup as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardaddreadertogroupa LONG SCardAddReaderToGroupA( [in]
	// SCARDCONTEXT hContext, [in] LPCSTR szReaderName, [in] LPCSTR szGroupName );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardAddReaderToGroupA")]
	public static extern SCARD_RET SCardAddReaderToGroup([In] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szReaderName, [MarshalAs(UnmanagedType.LPTStr)] string szGroupName);

	/// <summary>The <c>SCardAudit</c> function writes event messages to the Windows application log Microsoft-Windows-SmartCard-Audit/Authentication.</summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context. The resource manager context can be set by a previous call to the
	/// SCardEstablishContext function. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="dwEvent">
	/// <para>The event to log.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_AUDIT_CHV_FAILURE</c> 0x0</term>
	/// <term>A smart card holder verification (CHV) attempt failed.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_AUDIT_CHV_SUCCESS</c> 0x1</term>
	/// <term>A smart card holder verification (CHV) attempt succeeded.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is not redirected. An application calling the <c>SCardAudit</c> function from within a Remote Desktop session will log
	/// the event on the remote system.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// <code>// hContext was set by a previous call to SCardEstablishContext. lReturn = SCardAudit (hContext, SCARD_AUDIT_CHV_SUCCESS); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardAudit - %x\n", lReturn); // Take appropriate action }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardaudit LONG SCardAudit( [in] SCARDCONTEXT hContext, [in]
	// DWORD dwEvent );
	[DllImport(Lib_Winscard, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardAudit")]
	public static extern SCARD_RET SCardAudit([In] SCARDCONTEXT hContext, [In] SCARD_AUDIT_CHV dwEvent);

	/// <summary>
	/// <para>The <c>SCardBeginTransaction</c> function starts a transaction.</para>
	/// <para>
	/// The function waits for the completion of all other transactions before it begins. After the transaction starts, all other
	/// applications are blocked from accessing the smart card while the transaction is in progress.
	/// </para>
	/// </summary>
	/// <param name="hCard">A reference value obtained from a previous call to SCardConnect.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>SCARD_S_SUCCESS</c>.</para>
	/// <para>If the function fails, it returns an error code. For more information, see Smart Card Return Values.</para>
	/// <para>If another process or thread has reset the card, SCARD_W_RESET_CARD is returned as expected.</para>
	/// <para>
	/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This function
	/// returns <c>SCARD_S_SUCCESS</c> even if another process or thread has reset the card. To determine whether the card has been reset,
	/// call the SCardStatus function immediately after calling this function.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a transaction is held on the card for more than five seconds with no operations happening on that card, then the card is reset.
	/// Calling any of the Smart Card and Reader Access Functions or Direct Card Access Functions on the card that is transacted results in
	/// the timer being reset to continue allowing the transaction to be used.
	/// </para>
	/// <para>
	/// The <c>SCardBeginTransaction</c> function is a smart card and reader access function. For more information about other access
	/// functions, see Smart Card and Reader Access Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example demonstrates how to begin a smart card transaction. The example assumes that
	/// <code>lReturn</code>
	/// is an existing variable of type <c>LONG</c> and that
	/// <code>hCard</code>
	/// is a valid handle received from a previous call to SCardConnect.
	/// </para>
	/// <para>
	/// <code> lReturn = SCardBeginTransaction( hCard ); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardBeginTransaction\n");</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardbegintransaction LONG SCardBeginTransaction( [in]
	// SCARDHANDLE hCard );
	[DllImport(Lib_Winscard, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardBeginTransaction")]
	public static extern SCARD_RET SCardBeginTransaction([In] SCARDHANDLE hCard);

	/// <summary>
	/// <para>The <c>SCardCancel</c> function terminates all outstanding actions within a specific resource manager context.</para>
	/// <para>
	/// The only requests that you can cancel are those that require waiting for external action by the smart card or user. Any such
	/// outstanding action requests will terminate with a status indication that the action was canceled. This is especially useful to force
	/// outstanding SCardGetStatusChange calls to terminate.
	/// </para>
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context. The resource manager context is set by a previous call to SCardEstablishContext.
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SCardCancel</c> function is a smart card tracking function. For a description of other tracking functions, see Smart Card
	/// Tracking Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example cancels all outstanding actions in the specified context. The example assumes that lReturn is an existing
	/// variable of type <c>LONG</c> and that hContext is a valid handle received from a previous call to SCardEstablishContext.
	/// </para>
	/// <para>
	/// <code> lReturn = SCardCancel( hContext ); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardCancel\n");</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardcancel LONG SCardCancel( [in] SCARDCONTEXT hContext );
	[DllImport(Lib_Winscard, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardCancel")]
	public static extern SCARD_RET SCardCancel([In] SCARDCONTEXT hContext);

	/// <summary>
	/// The <c>SCardConnect</c> function establishes a connection (using a specific resource manager context) between the calling application
	/// and a smart card contained by a specific reader. If no card exists in the specified reader, an error is returned.
	/// </summary>
	/// <param name="hContext">
	/// A handle that identifies the resource manager context. The resource manager context is set by a previous call to SCardEstablishContext.
	/// </param>
	/// <param name="szReader">The name of the reader that contains the target card.</param>
	/// <param name="dwShareMode">
	/// <para>A flag that indicates whether other applications may form connections to the card.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_SHARE_SHARED</c></term>
	/// <term>This application is willing to share the card with other applications.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_SHARE_EXCLUSIVE</c></term>
	/// <term>This application is not willing to share the card with other applications.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_SHARE_DIRECT</c></term>
	/// <term>
	/// This application is allocating the reader for its private use, and will be controlling it directly. No other applications are allowed
	/// access to it.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwPreferredProtocols">
	/// <para>A bitmask of acceptable protocols for the connection. Possible values may be combined with the <c>OR</c> operation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_PROTOCOL_T0</c></term>
	/// <term>T=0 is an acceptable protocol.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_PROTOCOL_T1</c></term>
	/// <term>T=1 is an acceptable protocol.</term>
	/// </item>
	/// <item>
	/// <term><c>0</c></term>
	/// <term>
	/// This parameter may be zero only if <c>dwShareMode</c> is set to SCARD_SHARE_DIRECT. In this case, no protocol negotiation will be
	/// performed by the drivers until an IOCTL_SMARTCARD_SET_PROTOCOL control directive is sent with SCardControl.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phCard">A handle that identifies the connection to the smart card in the designated reader.</param>
	/// <param name="pdwActiveProtocol">
	/// <para>A flag that indicates the established active protocol.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_PROTOCOL_T0</c></term>
	/// <term>T=0 is the active protocol.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_PROTOCOL_T1</c></term>
	/// <term>T=1 is the active protocol.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_PROTOCOL_UNDEFINED</c></term>
	/// <term>
	/// SCARD_SHARE_DIRECT has been specified, so that no protocol negotiation has occurred. It is possible that there is no card in the reader.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_E_NOT_READY</c></term>
	/// <term>The reader was unable to connect to the card.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SCardConnect</c> function is a smart card and reader access function. For more information about other access functions, see
	/// Smart Card and Reader Access Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example creates a connection to a reader. The example assumes that <c>hContext</c> is a valid handle of type
	/// <c>SCARDCONTEXT</c> received from a previous call to SCardEstablishContext.
	/// </para>
	/// <para>
	/// <code>SCARDHANDLE hCardHandle; LONG lReturn; DWORD dwAP; lReturn = SCardConnect( hContext, (LPCTSTR)"Rainbow Technologies SCR3531 0", SCARD_SHARE_SHARED, SCARD_PROTOCOL_T0 | SCARD_PROTOCOL_T1, &amp;hCardHandle, &amp;dwAP ); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardConnect\n"); exit(1); // Or other appropriate action. } // Use the connection. // Display the active protocol. switch ( dwAP ) { case SCARD_PROTOCOL_T0: printf("Active protocol T0\n"); break; case SCARD_PROTOCOL_T1: printf("Active protocol T1\n"); break; case SCARD_PROTOCOL_UNDEFINED: default: printf("Active protocol unnegotiated or unknown\n"); break; } // Remember to disconnect (by calling SCardDisconnect). // ...</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardConnect as an alias which automatically selects the ANSI or Unicode version of this function based
	/// on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardconnecta LONG SCardConnectA( [in] SCARDCONTEXT hContext,
	// [in] LPCSTR szReader, [in] DWORD dwShareMode, [in] DWORD dwPreferredProtocols, [out] LPSCARDHANDLE phCard, [out] LPDWORD
	// pdwActiveProtocol );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardConnectA")]
	public static extern SCARD_RET SCardConnect([In] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szReader,
		[In] SCARD_SHARE dwShareMode, [In] SCARD_PROTOCOL dwPreferredProtocols, [Out] out SafeSCARDHANDLE phCard, out SCARD_PROTOCOL pdwActiveProtocol);

	/// <summary>
	/// The <c>SCardControl</c> function gives you direct control of the reader. You can call it any time after a successful call to
	/// SCardConnect and before a successful call to SCardDisconnect. The effect on the state of the reader depends on the control code.
	/// </summary>
	/// <param name="hCard">Reference value returned from SCardConnect.</param>
	/// <param name="dwControlCode">Control code for the operation. This value identifies the specific operation to be performed.</param>
	/// <param name="lpInBuffer">
	/// Pointer to a buffer that contains the data required to perform the operation. This parameter can be <c>NULL</c> if the
	/// <c>dwControlCode</c> parameter specifies an operation that does not require input data.
	/// </param>
	/// <param name="cbInBufferSize">Size, in bytes, of the buffer pointed to by <c>lpInBuffer</c>.</param>
	/// <param name="lpOutBuffer">
	/// Pointer to a buffer that receives the operation's output data. This parameter can be <c>NULL</c> if the <c>dwControlCode</c>
	/// parameter specifies an operation that does not produce output data.
	/// </param>
	/// <param name="cbOutBufferSize">Size, in bytes, of the buffer pointed to by <c>lpOutBuffer</c>.</param>
	/// <param name="lpBytesReturned">
	/// Pointer to a <c>DWORD</c> that receives the size, in bytes, of the data stored into the buffer pointed to by <c>lpOutBuffer</c>.
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SCardControl</c> function is a direct card access function. For more information on other direct access functions, see Direct
	/// Card Access Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example issues a control code. The example assumes that hCardHandle is a valid handle received from a previous call to
	/// SCardConnect and that dwControlCode is a variable of type <c>DWORD</c> previously initialized to a valid control code. This
	/// particular control code requires no input data and expects no output data.
	/// </para>
	/// <para>
	/// <code> lReturn = SCardControl( hCardHandle, dwControlCode, NULL, 0, NULL, 0, 0 ); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardControl\n");</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardcontrol LONG SCardControl( [in] SCARDHANDLE hCard, [in]
	// DWORD dwControlCode, [in] LPCVOID lpInBuffer, [in] DWORD cbInBufferSize, [out] LPVOID lpOutBuffer, [in] DWORD cbOutBufferSize, [out]
	// LPDWORD lpBytesReturned );
	[DllImport(Lib_Winscard, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardControl")]
	public static extern SCARD_RET SCardControl([In] SCARDHANDLE hCard, [In] uint dwControlCode, [In, Optional] IntPtr lpInBuffer, [In] uint cbInBufferSize,
		[Out, Optional] IntPtr lpOutBuffer, [In] uint cbOutBufferSize, out uint lpBytesReturned);

	/// <summary>
	/// The <c>SCardDisconnect</c> function terminates a connection previously opened between the calling application and a smart card in the
	/// target reader.
	/// </summary>
	/// <param name="hCard">Reference value obtained from a previous call to SCardConnect.</param>
	/// <param name="dwDisposition">
	/// <para>Action to take on the card in the connected reader on close.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_LEAVE_CARD</c></term>
	/// <term>Do not do anything special.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_RESET_CARD</c></term>
	/// <term>Reset the card.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_UNPOWER_CARD</c></term>
	/// <term>Power down the card.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_EJECT_CARD</c></term>
	/// <term>Eject the card.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If an application (which previously called SCardConnect) exits without calling <c>SCardDisconnect</c>, the card is automatically reset.
	/// </para>
	/// <para>
	/// The <c>SCardDisconnect</c> function is a smart card and reader access function. For more information on other access functions, see
	/// Smart Card and Reader Access Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example terminates the specified smart card connection. The example assumes that lReturn is a variable of type
	/// <c>LONG</c>, and that hCardHandle is a valid handle received from a previous call to SCardConnect.
	/// </para>
	/// <para>
	/// <code> lReturn = SCardDisconnect(hCardHandle, SCARD_LEAVE_CARD); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardDisconnect\n"); exit(1); // Or other appropriate action. }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scarddisconnect LONG SCardDisconnect( [in] SCARDHANDLE hCard,
	// [in] DWORD dwDisposition );
	[DllImport(Lib_Winscard, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardDisconnect")]
	public static extern SCARD_RET SCardDisconnect([In] SCARDHANDLE hCard, [In] SCARD_ACTION dwDisposition);

	/// <summary>
	/// The <c>SCardEndTransaction</c> function completes a previously declared transaction, allowing other applications to resume
	/// interactions with the card.
	/// </summary>
	/// <param name="hCard">
	/// Reference value obtained from a previous call to SCardConnect. This value would also have been used in an earlier call to SCardBeginTransaction.
	/// </param>
	/// <param name="dwDisposition">
	/// <para>Action to take on the card in the connected reader on close.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_EJECT_CARD</c></term>
	/// <term>Eject the card.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_LEAVE_CARD</c></term>
	/// <term>Do not do anything special.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_RESET_CARD</c></term>
	/// <term>Reset the card.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_UNPOWER_CARD</c></term>
	/// <term>Power down the card.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>SCARD_S_SUCCESS</c>.</para>
	/// <para>If the function fails, it returns an error code. For more information, see Smart Card Return Values. Possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_W_RESET_CARD</c> 0x80100068L</term>
	/// <term>
	/// The transaction was released. Any future communication with the card requires a call to the SCardReconnect function. <c>Windows
	/// Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> The transaction was not released. The application must
	/// immediately call the SCardDisconnect, SCardReconnect, or SCardReleaseContext function to avoid an existing transaction blocking other
	/// threads and processes from communicating with the smart card.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SCardEndTransaction</c> function is a smart card and reader access function. For more information on other access functions,
	/// see Smart Card and Reader Access Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example ends a smart card transaction. The example assumes that lReturn is a valid variable of type <c>LONG</c>, that
	/// hCard is a valid handle received from a previous call to the SCardConnect function, and that hCard was passed to a previous call to
	/// the SCardBeginTransaction function.
	/// </para>
	/// <para>
	/// <code> lReturn = SCardEndTransaction(hCard, SCARD_LEAVE_CARD); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardEndTransaction\n");</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardendtransaction LONG SCardEndTransaction( [in] SCARDHANDLE
	// hCard, [in] DWORD dwDisposition );
	[DllImport(Lib_Winscard, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardEndTransaction")]
	public static extern SCARD_RET SCardEndTransaction([In] SCARDHANDLE hCard, [In] SCARD_ACTION dwDisposition);

	/// <summary>
	/// The <c>SCardEstablishContext</c> function establishes the resource manager context (the scope) within which database operations are performed.
	/// </summary>
	/// <param name="dwScope">
	/// <para>Scope of the resource manager context. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_SCOPE_USER</c></term>
	/// <term>Database operations are performed within the domain of the user.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_SCOPE_SYSTEM</c></term>
	/// <term>
	/// Database operations are performed within the domain of the system. The calling application must have appropriate access permissions
	/// for any database actions.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvReserved1">
	/// Reserved for future use and must be <c>NULL</c>. This parameter will allow a suitably privileged management application to act on
	/// behalf of another user.
	/// </param>
	/// <param name="pvReserved2">Reserved for future use and must be <c>NULL</c>.</param>
	/// <param name="phContext">
	/// A handle to the established resource manager context. This handle can now be supplied to other functions attempting to do work within
	/// this context.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns SCARD_S_SUCCESS.</para>
	/// <para>If the function fails, it returns an error code. For more information, see Smart Card Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The context handle returned by <c>SCardEstablishContext</c> can be used by database query and management functions. For more
	/// information, see Smart Card Database Query Functions and Smart Card Database Management Functions.
	/// </para>
	/// <para>To release an established resource manager context, use SCardReleaseContext.</para>
	/// <para>
	/// If the client attempts a smart card operation in a remote session, such as a client session running on a terminal server, and the
	/// operating system in use does not support smart card redirection, this function returns ERROR_BROKEN_PIPE.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example establishes a resource manager context.</para>
	/// <para>
	/// <code>SCARDCONTEXT hSC; LONG lReturn; // Establish the context. lReturn = SCardEstablishContext(SCARD_SCOPE_USER, NULL, NULL, &amp;hSC); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardEstablishContext\n"); else { // Use the context as needed. When done, // free the context by calling SCardReleaseContext. // ... }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardestablishcontext LONG SCardEstablishContext( [in] DWORD
	// dwScope, [in] LPCVOID pvReserved1, [in] LPCVOID pvReserved2, [out] LPSCARDCONTEXT phContext );
	[DllImport(Lib_Winscard, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardEstablishContext")]
	public static extern SCARD_RET SCardEstablishContext([In] SCARD_SCOPE dwScope, [In, Optional] IntPtr pvReserved1, [In, Optional] IntPtr pvReserved2, out SCARDCONTEXT phContext);

	/// <summary>The <c>SCardForgetCardType</c> function removes an introduced smart card from the smart card subsystem.</summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context. The resource manager context is set by a previous call to SCardEstablishContext.
	/// This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szCardName">Display name of the card to be removed from the smart card database.</param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is not redirected, but calling the function <c>SCardForgetCardType</c> when inside a Remote Desktop session will not
	/// result in an error. It only means that the result will be from the remote computer instead of the local computer.
	/// </para>
	/// <para>
	/// The <c>SCardForgetCardType</c> function is a database management function. For more information about other database management
	/// functions, see Smart Card Database Management Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example removes the specified card type from the system. The example assumes that lReturn is a valid variable of type
	/// <c>LONG</c>, that <c>hContext</c> is a valid handle received from a previous call to the SCardEstablishContext function, and that
	/// "MyCardName" was previously introduced by a call to the SCardIntroduceCardType function.
	/// </para>
	/// <para>
	/// <code> lReturn = SCardForgetCardType(hContext, L"MyCardName"); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardForgetCardType\n");</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardForgetCardType as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardforgetcardtypea LONG SCardForgetCardTypeA( [in]
	// SCARDCONTEXT hContext, [in] LPCSTR szCardName );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardForgetCardTypeA")]
	public static extern SCARD_RET SCardForgetCardType([In] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szCardName);

	/// <summary>
	/// The <c>SCardForgetReader</c> function removes a previously introduced reader from control by the smart card subsystem. It is removed
	/// from the smart card database, including from any reader group that it may have been added to.
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context. The resource manager context is set by a previous call to SCardEstablishContext.
	/// This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szReaderName">Display name of the reader to be removed from the smart card database.</param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If the specified reader is the last member of a reader group, the reader group is automatically removed as well.</para>
	/// <para>
	/// The <c>SCardForgetReader</c> function is a database management function. For more information on other database management functions,
	/// see Smart Card Database Management Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example removes the display name of the specified card reader from the system. The example assumes that lReturn is a
	/// valid variable of type <c>LONG</c> and that hContext is a valid handle received from a previous call to the SCardEstablishContext function.
	/// </para>
	/// <para>
	/// <code> lReturn = SCardForgetReader(hContext, TEXT("MyReader")); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardForgetReader\n");</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardForgetReader as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardforgetreadera LONG SCardForgetReaderA( [in] SCARDCONTEXT
	// hContext, [in] LPCSTR szReaderName );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardForgetReaderA")]
	public static extern SCARD_RET SCardForgetReader([In] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szReaderName);

	/// <summary>
	/// The <c>SCardForgetReaderGroup</c> function removes a previously introduced smart card reader group from the smart card subsystem.
	/// Although this function automatically clears all readers from the group, it does not affect the existence of the individual readers in
	/// the database.
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context. The resource manager context is set by a previous call to SCardEstablishContext.
	/// This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szGroupName">
	/// <para>Display name of the reader group to be removed. System-defined reader groups cannot be removed from the database.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_ALL_READERS</c> TEXT("SCard$AllReaders\000")</term>
	/// <term>
	/// Group used when no group name is provided when listing readers. Returns a list of all readers, regardless of what group or groups the
	/// readers are in.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_DEFAULT_READERS</c> TEXT("SCard$DefaultReaders\000")</term>
	/// <term>Default group to which all readers are added when introduced into the system.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_LOCAL_READERS</c> TEXT("SCard$LocalReaders\000")</term>
	/// <term>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_SYSTEM_READERS</c> TEXT("SCard$SystemReaders\000")</term>
	/// <term>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SCardForgetReaderGroup</c> function is a database management function. For more information on other database management
	/// functions, see Smart Card Database Management Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to remove a reader group from the system. The example assumes that lReturn is an existing variable of
	/// type <c>LONG</c>, and that hContext is a valid handle to a resource manager context previously obtained from a call to the
	/// SCardEstablishContext function.
	/// </para>
	/// <para>
	/// <code> lReturn = SCardForgetReaderGroup(hContext, L"MyReaderGroup"); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardForgetReaderGroup\n");</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardForgetReaderGroup as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardforgetreadergroupa LONG SCardForgetReaderGroupA( [in]
	// SCARDCONTEXT hContext, [in] LPCSTR szGroupName );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardForgetReaderGroupA")]
	public static extern SCARD_RET SCardForgetReaderGroup([In] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szGroupName);

	/// <summary>
	/// The <c>SCardFreeMemory</c> function releases memory that has been returned from the resource manager using the SCARD_AUTOALLOCATE
	/// length designator.
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context returned from SCardEstablishContext, or <c>NULL</c> if the creating function also
	/// specified <c>NULL</c> for its <c>hContext</c> parameter. For more information, see Smart Card Database Query Functions.
	/// </param>
	/// <param name="pvMem">Memory block to be released.</param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardfreememory LONG SCardFreeMemory( [in] SCARDCONTEXT
	// hContext, [in] LPCVOID pvMem );
	[DllImport(Lib_Winscard, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardFreeMemory")]
	public static extern SCARD_RET SCardFreeMemory([In, Optional] SCARDCONTEXT hContext, [In] IntPtr pvMem);

	/// <summary>
	/// The <c>SCardGetAttrib</c> function retrieves the current reader attributes for the given handle. It does not affect the state of the
	/// reader, driver, or card.
	/// </summary>
	/// <param name="hCard">Reference value returned from SCardConnect.</param>
	/// <param name="dwAttrId">
	/// <para>
	/// Identifier for the attribute to get. The following table lists possible values for <c>dwAttrId</c>. These values are read-only. Note
	/// that vendors may not support all attributes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_ATTR_ATR_STRING</c></term>
	/// <term>Answer to reset (ATR) string.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CHANNEL_ID</c></term>
	/// <term><c>DWORD</c> encoded as 0x <c>DDDDCCCC</c>, where <c>DDDD</c> = data channel type and <c>CCCC</c> = channel number:</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CHARACTERISTICS</c></term>
	/// <term>
	/// <c>DWORD</c> indicating which mechanical characteristics are supported. If zero, no special characteristics are supported. Note that
	/// multiple bits can be set: All other values are reserved for future use (RFU).
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_BWT</c></term>
	/// <term>Current block waiting time.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_CLK</c></term>
	/// <term>Current clock rate, in kHz.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_CWT</c></term>
	/// <term>Current character waiting time.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_D</c></term>
	/// <term>Bit rate conversion factor.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_EBC_ENCODING</c></term>
	/// <term>Current error block control encoding. 0 = longitudinal redundancy check (LRC) 1 = cyclical redundancy check (CRC)</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_F</c></term>
	/// <term>Clock conversion factor.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_IFSC</c></term>
	/// <term>Current byte size for information field size card.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_IFSD</c></term>
	/// <term>Current byte size for information field size device.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_N</c></term>
	/// <term>Current guard time.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_PROTOCOL_TYPE</c></term>
	/// <term>
	/// <c>DWORD</c> encoded as 0x0 <c>rrrpppp</c> where <c>rrr</c> is RFU and should be 0x000. <c>pppp</c> encodes the current protocol
	/// type. Whichever bit has been set indicates which ISO protocol is currently in use. (For example, if bit zero is set, T=0 protocol is
	/// in effect.)
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_W</c></term>
	/// <term>Current work waiting time.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_DEFAULT_CLK</c></term>
	/// <term>Default clock rate, in kHz.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_DEFAULT_DATA_RATE</c></term>
	/// <term>Default data rate, in bps.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_DEVICE_FRIENDLY_NAME</c></term>
	/// <term>Reader's display name.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_DEVICE_IN_USE</c></term>
	/// <term>Reserved for future use.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_DEVICE_SYSTEM_NAME</c></term>
	/// <term>Reader's system name.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_DEVICE_UNIT</c></term>
	/// <term>
	/// Instance of this vendor's reader attached to the computer. The first instance will be device unit 0, the next will be unit 1 (if it
	/// is the same brand of reader) and so on. Two different brands of readers will both have zero for this value.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_ICC_INTERFACE_STATUS</c></term>
	/// <term>Single byte. Zero if smart card electrical contact is not active; nonzero if contact is active.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_ICC_PRESENCE</c></term>
	/// <term>
	/// Single byte indicating smart card presence: 0 = not present 1 = card present but not swallowed (applies only if reader supports smart
	/// card swallowing) 2 = card present (and swallowed if reader supports smart card swallowing) 4 = card confiscated.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_ICC_TYPE_PER_ATR</c></term>
	/// <term>Single byte indicating smart card type: 0 = unknown type 1 = 7816 Asynchronous 2 = 7816 Synchronous Other values RFU.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_MAX_CLK</c></term>
	/// <term>Maximum clock rate, in kHz.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_MAX_DATA_RATE</c></term>
	/// <term>Maximum data rate, in bps.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_MAX_IFSD</c></term>
	/// <term>Maximum bytes for information file size device.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_POWER_MGMT_SUPPORT</c></term>
	/// <term>Zero if device does not support power down while smart card is inserted. Nonzero otherwise.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_PROTOCOL_TYPES</c></term>
	/// <term>
	/// <c>DWORD</c> encoded as 0x0 <c>rrrpppp</c> where <c>rrr</c> is RFU and should be 0x000. <c>pppp</c> encodes the supported protocol
	/// types. A '1' in a given bit position indicates support for the associated ISO protocol, so if bits zero and one are set, both T=0 and
	/// T=1 protocols are supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_VENDOR_IFD_SERIAL_NO</c></term>
	/// <term>Vendor-supplied interface device serial number.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_VENDOR_IFD_TYPE</c></term>
	/// <term>Vendor-supplied interface device type (model designation of reader).</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_VENDOR_IFD_VERSION</c></term>
	/// <term>
	/// Vendor-supplied interface device version ( <c>DWORD</c> in the form 0x <c>MMmmbbbb</c> where <c>MM</c> = major version, <c>mm</c> =
	/// minor version, and <c>bbbb</c> = build number).
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_VENDOR_NAME</c></term>
	/// <term>Vendor name.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbAttr">
	/// Pointer to a buffer that receives the attribute whose ID is supplied in <c>dwAttrId</c>. If this value is <c>NULL</c>,
	/// <c>SCardGetAttrib</c> ignores the buffer length supplied in <c>pcbAttrLen</c>, writes the length of the buffer that would have been
	/// returned if this parameter had not been <c>NULL</c> to <c>pcbAttrLen</c>, and returns a success code.
	/// </param>
	/// <param name="pcbAttrLen">
	/// Length of the <c>pbAttr</c> buffer in bytes, and receives the actual length of the received attribute If the buffer length is
	/// specified as SCARD_AUTOALLOCATE, then <c>pbAttr</c> is converted to a pointer to a byte pointer, and receives the address of a block
	/// of memory containing the attribute. This block of memory must be deallocated with SCardFreeMemory.
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Attribute value not supported.</c></term>
	/// <term>ERROR_NOT_SUPPORTED.</term>
	/// </item>
	/// <item>
	/// <term><c>Other Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SCardGetAttrib</c> function is a direct card access function. For more information on other direct access functions, see
	/// Direct Card Access Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to retrieve an attribute for a card reader. The example assumes that hCardHandle is a valid handle
	/// obtained from a previous call to the SCardConnect function.
	/// </para>
	/// <para>
	/// <code>LPBYTE pbAttr = NULL; DWORD cByte = SCARD_AUTOALLOCATE; DWORD i; LONG lReturn; lReturn = SCardGetAttrib(hCardHandle, SCARD_ATTR_VENDOR_NAME, (LPBYTE)&amp;pbAttr, &amp;cByte); if ( SCARD_S_SUCCESS != lReturn ) { if ( ERROR_NOT_SUPPORTED == lReturn ) printf("Value not supported\n"); else { // Some other error occurred. printf("Failed SCardGetAttrib - %x\n", lReturn); exit(1); // Or other appropriate action } } else { // Output the bytes. for (i = 0; i &lt; cByte; i++) printf("%c", *(pbAttr+i)); printf("\n"); // Free the memory when done. // hContext was set earlier by SCardEstablishContext lReturn = SCardFreeMemory( hContext, pbAttr ); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardgetattrib LONG SCardGetAttrib( [in] SCARDHANDLE hCard,
	// [in] DWORD dwAttrId, [out] LPBYTE pbAttr, [in, out] LPDWORD pcbAttrLen );
	[DllImport(Lib_Winscard, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardGetAttrib")]
	public static extern SCARD_RET SCardGetAttrib([In] SCARDHANDLE hCard, [In] uint dwAttrId, [Out] IntPtr pbAttr, ref uint pcbAttrLen);

	/// <summary>
	/// The <c>SCardGetAttrib</c> function retrieves the current reader attributes for the given handle. It does not affect the state of the
	/// reader, driver, or card.
	/// </summary>
	/// <typeparam name="T">The type of the value to return.</typeparam>
	/// <param name="hCard">Reference value returned from SCardConnect.</param>
	/// <param name="dwAttrId">
	/// <para>
	/// Identifier for the attribute to get. The following table lists possible values for <c>dwAttrId</c>. These values are read-only. Note
	/// that vendors may not support all attributes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_ATTR_ATR_STRING</c></term>
	/// <term>Answer to reset (ATR) string.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CHANNEL_ID</c></term>
	/// <term><c>DWORD</c> encoded as 0x <c>DDDDCCCC</c>, where <c>DDDD</c> = data channel type and <c>CCCC</c> = channel number:</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CHARACTERISTICS</c></term>
	/// <term>
	/// <c>DWORD</c> indicating which mechanical characteristics are supported. If zero, no special characteristics are supported. Note that
	/// multiple bits can be set: All other values are reserved for future use (RFU).
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_BWT</c></term>
	/// <term>Current block waiting time.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_CLK</c></term>
	/// <term>Current clock rate, in kHz.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_CWT</c></term>
	/// <term>Current character waiting time.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_D</c></term>
	/// <term>Bit rate conversion factor.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_EBC_ENCODING</c></term>
	/// <term>Current error block control encoding. 0 = longitudinal redundancy check (LRC) 1 = cyclical redundancy check (CRC)</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_F</c></term>
	/// <term>Clock conversion factor.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_IFSC</c></term>
	/// <term>Current byte size for information field size card.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_IFSD</c></term>
	/// <term>Current byte size for information field size device.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_N</c></term>
	/// <term>Current guard time.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_PROTOCOL_TYPE</c></term>
	/// <term>
	/// <c>DWORD</c> encoded as 0x0 <c>rrrpppp</c> where <c>rrr</c> is RFU and should be 0x000. <c>pppp</c> encodes the current protocol
	/// type. Whichever bit has been set indicates which ISO protocol is currently in use. (For example, if bit zero is set, T=0 protocol is
	/// in effect.)
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_CURRENT_W</c></term>
	/// <term>Current work waiting time.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_DEFAULT_CLK</c></term>
	/// <term>Default clock rate, in kHz.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_DEFAULT_DATA_RATE</c></term>
	/// <term>Default data rate, in bps.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_DEVICE_FRIENDLY_NAME</c></term>
	/// <term>Reader's display name.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_DEVICE_IN_USE</c></term>
	/// <term>Reserved for future use.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_DEVICE_SYSTEM_NAME</c></term>
	/// <term>Reader's system name.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_DEVICE_UNIT</c></term>
	/// <term>
	/// Instance of this vendor's reader attached to the computer. The first instance will be device unit 0, the next will be unit 1 (if it
	/// is the same brand of reader) and so on. Two different brands of readers will both have zero for this value.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_ICC_INTERFACE_STATUS</c></term>
	/// <term>Single byte. Zero if smart card electrical contact is not active; nonzero if contact is active.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_ICC_PRESENCE</c></term>
	/// <term>
	/// Single byte indicating smart card presence: 0 = not present 1 = card present but not swallowed (applies only if reader supports smart
	/// card swallowing) 2 = card present (and swallowed if reader supports smart card swallowing) 4 = card confiscated.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_ICC_TYPE_PER_ATR</c></term>
	/// <term>Single byte indicating smart card type: 0 = unknown type 1 = 7816 Asynchronous 2 = 7816 Synchronous Other values RFU.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_MAX_CLK</c></term>
	/// <term>Maximum clock rate, in kHz.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_MAX_DATA_RATE</c></term>
	/// <term>Maximum data rate, in bps.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_MAX_IFSD</c></term>
	/// <term>Maximum bytes for information file size device.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_POWER_MGMT_SUPPORT</c></term>
	/// <term>Zero if device does not support power down while smart card is inserted. Nonzero otherwise.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_PROTOCOL_TYPES</c></term>
	/// <term>
	/// <c>DWORD</c> encoded as 0x0 <c>rrrpppp</c> where <c>rrr</c> is RFU and should be 0x000. <c>pppp</c> encodes the supported protocol
	/// types. A '1' in a given bit position indicates support for the associated ISO protocol, so if bits zero and one are set, both T=0 and
	/// T=1 protocols are supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_VENDOR_IFD_SERIAL_NO</c></term>
	/// <term>Vendor-supplied interface device serial number.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_VENDOR_IFD_TYPE</c></term>
	/// <term>Vendor-supplied interface device type (model designation of reader).</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_VENDOR_IFD_VERSION</c></term>
	/// <term>
	/// Vendor-supplied interface device version ( <c>DWORD</c> in the form 0x <c>MMmmbbbb</c> where <c>MM</c> = major version, <c>mm</c> =
	/// minor version, and <c>bbbb</c> = build number).
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_ATTR_VENDOR_NAME</c></term>
	/// <term>Vendor name.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>The attribute whose ID is supplied in <paramref name="dwAttrId"/>.</returns>
	/// <remarks>
	/// The <c>SCardGetAttrib</c> function is a direct card access function. For more information on other direct access functions, see
	/// Direct Card Access Functions.
	/// </remarks>
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardGetAttrib")]
	public static T SCardGetAttrib<T>([In] SCARDHANDLE hCard, [In] uint dwAttrId) where T : struct
	{
		uint len = SCARD_AUTOALLOCATE;
		IntPtr attrib = IntPtr.Zero;
		using var pAttrib = new PinnedObject(attrib);
		var ret = SCardGetAttrib(hCard, dwAttrId, pAttrib, ref len);
		try
		{
			ret.ThrowIfFailed();
			return len > 0 ? attrib.ToStructure<T>(len)! : default;
		}
		finally
		{
			SCardFreeMemory(hCard, attrib);
		}
	}

	/// <summary>
	/// The <c>SCardGetAttrib</c> function retrieves the current reader string attributes for the given handle. It does not affect the state of the
	/// reader, driver, or card.
	/// </summary>
	/// <param name="hCard">Reference value returned from SCardConnect.</param>
	/// <param name="dwAttrId"><para>
	/// Identifier for the attribute to get. The following table lists possible values for <c>dwAttrId</c>. These values are read-only. Note
	/// that vendors may not support all attributes.
	/// </para>
	/// <list type="table">
	///   <listheader>
	///     <term>Value</term>
	///     <term>Meaning</term>
	///   </listheader>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_ATR_STRING</c>
	///     </term>
	///     <term>Answer to reset (ATR) string.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_CHANNEL_ID</c>
	///     </term>
	///     <term>
	///       <c>DWORD</c> encoded as 0x <c>DDDDCCCC</c>, where <c>DDDD</c> = data channel type and <c>CCCC</c> = channel number:</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_CHARACTERISTICS</c>
	///     </term>
	///     <term>
	///       <c>DWORD</c> indicating which mechanical characteristics are supported. If zero, no special characteristics are supported. Note that
	/// multiple bits can be set: All other values are reserved for future use (RFU).
	/// </term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_CURRENT_BWT</c>
	///     </term>
	///     <term>Current block waiting time.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_CURRENT_CLK</c>
	///     </term>
	///     <term>Current clock rate, in kHz.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_CURRENT_CWT</c>
	///     </term>
	///     <term>Current character waiting time.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_CURRENT_D</c>
	///     </term>
	///     <term>Bit rate conversion factor.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_CURRENT_EBC_ENCODING</c>
	///     </term>
	///     <term>Current error block control encoding. 0 = longitudinal redundancy check (LRC) 1 = cyclical redundancy check (CRC)</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_CURRENT_F</c>
	///     </term>
	///     <term>Clock conversion factor.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_CURRENT_IFSC</c>
	///     </term>
	///     <term>Current byte size for information field size card.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_CURRENT_IFSD</c>
	///     </term>
	///     <term>Current byte size for information field size device.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_CURRENT_N</c>
	///     </term>
	///     <term>Current guard time.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_CURRENT_PROTOCOL_TYPE</c>
	///     </term>
	///     <term>
	///       <c>DWORD</c> encoded as 0x0 <c>rrrpppp</c> where <c>rrr</c> is RFU and should be 0x000. <c>pppp</c> encodes the current protocol
	/// type. Whichever bit has been set indicates which ISO protocol is currently in use. (For example, if bit zero is set, T=0 protocol is
	/// in effect.)
	/// </term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_CURRENT_W</c>
	///     </term>
	///     <term>Current work waiting time.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_DEFAULT_CLK</c>
	///     </term>
	///     <term>Default clock rate, in kHz.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_DEFAULT_DATA_RATE</c>
	///     </term>
	///     <term>Default data rate, in bps.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_DEVICE_FRIENDLY_NAME</c>
	///     </term>
	///     <term>Reader's display name.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_DEVICE_IN_USE</c>
	///     </term>
	///     <term>Reserved for future use.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_DEVICE_SYSTEM_NAME</c>
	///     </term>
	///     <term>Reader's system name.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_DEVICE_UNIT</c>
	///     </term>
	///     <term>
	/// Instance of this vendor's reader attached to the computer. The first instance will be device unit 0, the next will be unit 1 (if it
	/// is the same brand of reader) and so on. Two different brands of readers will both have zero for this value.
	/// </term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_ICC_INTERFACE_STATUS</c>
	///     </term>
	///     <term>Single byte. Zero if smart card electrical contact is not active; nonzero if contact is active.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_ICC_PRESENCE</c>
	///     </term>
	///     <term>
	/// Single byte indicating smart card presence: 0 = not present 1 = card present but not swallowed (applies only if reader supports smart
	/// card swallowing) 2 = card present (and swallowed if reader supports smart card swallowing) 4 = card confiscated.
	/// </term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_ICC_TYPE_PER_ATR</c>
	///     </term>
	///     <term>Single byte indicating smart card type: 0 = unknown type 1 = 7816 Asynchronous 2 = 7816 Synchronous Other values RFU.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_MAX_CLK</c>
	///     </term>
	///     <term>Maximum clock rate, in kHz.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_MAX_DATA_RATE</c>
	///     </term>
	///     <term>Maximum data rate, in bps.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_MAX_IFSD</c>
	///     </term>
	///     <term>Maximum bytes for information file size device.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_POWER_MGMT_SUPPORT</c>
	///     </term>
	///     <term>Zero if device does not support power down while smart card is inserted. Nonzero otherwise.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_PROTOCOL_TYPES</c>
	///     </term>
	///     <term>
	///       <c>DWORD</c> encoded as 0x0 <c>rrrpppp</c> where <c>rrr</c> is RFU and should be 0x000. <c>pppp</c> encodes the supported protocol
	/// types. A '1' in a given bit position indicates support for the associated ISO protocol, so if bits zero and one are set, both T=0 and
	/// T=1 protocols are supported.
	/// </term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_VENDOR_IFD_SERIAL_NO</c>
	///     </term>
	///     <term>Vendor-supplied interface device serial number.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_VENDOR_IFD_TYPE</c>
	///     </term>
	///     <term>Vendor-supplied interface device type (model designation of reader).</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_VENDOR_IFD_VERSION</c>
	///     </term>
	///     <term>
	/// Vendor-supplied interface device version ( <c>DWORD</c> in the form 0x <c>MMmmbbbb</c> where <c>MM</c> = major version, <c>mm</c> =
	/// minor version, and <c>bbbb</c> = build number).
	/// </term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>SCARD_ATTR_VENDOR_NAME</c>
	///     </term>
	///     <term>Vendor name.</term>
	///   </item>
	/// </list></param>
	/// <param name="charSet">The character set for the string.</param>
	/// <returns>The string attribute whose ID is supplied in <paramref name="dwAttrId" />.</returns>
	/// <remarks>
	/// The <c>SCardGetAttrib</c> function is a direct card access function. For more information on other direct access functions, see
	/// Direct Card Access Functions.
	/// </remarks>
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardGetAttrib")]
	public static string SCardGetAttribString([In] SCARDHANDLE hCard, [In] uint dwAttrId, CharSet charSet = CharSet.Auto)
	{
		uint len = SCARD_AUTOALLOCATE;
		IntPtr attrib = IntPtr.Zero;
		using var pAttrib = new PinnedObject(attrib);
		var ret = SCardGetAttrib(hCard, dwAttrId, pAttrib, ref len);
		try
		{
			ret.ThrowIfFailed();
			return len == 0 || attrib == IntPtr.Zero ? string.Empty : StringHelper.GetString(attrib, charSet, len)!;
		}
		finally
		{
			SCardFreeMemory(hCard, attrib);
		}
	}

	/// <summary>
	/// The <c>SCardGetCardTypeProviderName</c> function returns the name of the module (dynamic link library) that contains the provider for
	/// a given card name and provider type.
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context. The resource manager context can be set by a previous call to
	/// SCardEstablishContext. This value can be <c>NULL</c> if the call to <c>SCardGetCardTypeProviderName</c> is not directed to a specific context.
	/// </param>
	/// <param name="szCardName">Name of the card type with which this provider name is associated.</param>
	/// <param name="dwProviderId">
	/// <para>Identifier for the provider associated with this card type.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_PROVIDER_PRIMARY</c> 1</term>
	/// <term>The function retrieves the name of the smart card's primary service provider as a GUID string.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_PROVIDER_CSP</c> 2</term>
	/// <term>The function retrieves the name of the cryptographic service provider.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_PROVIDER_KSP</c> 3</term>
	/// <term>The function retrieves the name of the smart card key storage provider (KSP).</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_PROVIDER_CARD_MODULE</c> 0x80000001</term>
	/// <term>The function retrieves the name of the card module.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szProvider">String variable to receive the provider name upon successful completion of this function.</param>
	/// <param name="pcchProvider">
	/// <para>
	/// Pointer to <c>DWORD</c> value. On input, <c>pcchProvider</c> supplies the length of the <c>szProvider</c> buffer in characters. If
	/// this value is SCARD_AUTOALLOCATE, then <c>szProvider</c> is converted to a pointer to a byte pointer and receives the address of a
	/// block of memory containing the string. This block of memory must be deallocated by calling SCardFreeMemory.
	/// </para>
	/// <para>
	/// On output, this value represents the actual number of characters, including the <c>null</c> terminator, in the <c>szProvider</c> variable.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is not redirected, but calling the function when inside a Remote Desktop session will not result in an error. It only
	/// means that the result will be from the remote computer instead of the local computer.
	/// </para>
	/// <para>
	/// Upon successful completion of this function, the value in <c>szProvider</c> can be used as the third parameter in a call to CryptAcquireContext.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to retrieve the provider name for the specified reader context. The example assumes that hContext is
	/// a valid handle obtained from a previous call to the SCardEstablishContext function.
	/// </para>
	/// <para>
	/// <code>LPTSTR szProvider = NULL; LPTSTR szCardName = _T("WindowsCard"); DWORD chProvider = SCARD_AUTOALLOCATE; LONG lReturn = SCARD_S_SUCCESS; // Retrieve the provider name. // hContext was set by SCardEstablishContext. lReturn = SCardGetCardTypeProviderName(hContext, szCardName, SCARD_PROVIDER_CSP, (LPTSTR)&amp;szProvider, &amp;chProvider); if (SCARD_S_SUCCESS == lReturn) { BOOL fSts = TRUE; HCRYPTPROV hProv = NULL; // Acquire a Cryptographic operation context. fSts = CryptAcquireContext(&amp;hProv, NULL, szProvider, PROV_RSA_FULL, 0); // Perform Cryptographic operations with smart card // ... // Free memory allocated by SCardGetCardTypeProviderName. lReturn = SCardFreeMemory(hContext, szProvider); }</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardGetCardTypeProviderName as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardgetcardtypeprovidernamea LONG
	// SCardGetCardTypeProviderNameA( [in] SCARDCONTEXT hContext, [in] LPCSTR szCardName, [in] DWORD dwProviderId, [out] CHAR *szProvider,
	// [in, out] LPDWORD pcchProvider );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardGetCardTypeProviderNameA")]
	public static extern SCARD_RET SCardGetCardTypeProviderName([In, Optional] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szCardName, [In] SCARD_PROVIDER dwProviderId,
		[Out] StringBuilder szProvider, ref uint pcchProvider);

	/// <summary>
	/// The <c>SCardGetDeviceTypeId</c> function gets the device type identifier of the card reader for the given reader name. This function
	/// does not affect the state of the reader.
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context for the query. You can set the resource manager context by calling the
	/// SCardEstablishContext function. This parameter cannot be NULL.
	/// </param>
	/// <param name="szReaderName">Reader name. You can get this value by calling the SCardListReaders function.</param>
	/// <param name="pdwDeviceTypeId">
	/// The actual device type identifier. The list of reader types returned by this function are listed under <c>ReaderType</c> member in
	/// the SCARD_READER_CAPABILITIES structure.
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardGetDeviceTypeId as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardgetdevicetypeida LONG SCardGetDeviceTypeIdA( [in]
	// SCARDCONTEXT hContext, [in] LPCSTR szReaderName, [in, out] LPDWORD pdwDeviceTypeId );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardGetDeviceTypeIdA")]
	public static extern SCARD_RET SCardGetDeviceTypeId([In] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szReaderName, out SCARD_READER_TYPE pdwDeviceTypeId);

	/// <summary>
	/// <para>The <c>SCardGetProviderId</c> function returns the identifier (GUID) of the primary service provider for a given card.</para>
	/// <para>
	/// The caller supplies the name of a smart card (previously introduced to the system) and receives the registered identifier of the
	/// primary service provider GUID, if one exists.
	/// </para>
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context for the query. The resource manager context can be set by a previous call to
	/// SCardEstablishContext. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szCard">Name of the card defined to the system.</param>
	/// <param name="pguidProviderId">
	/// Identifier (GUID) of the primary service provider. This provider may be activated using COM, and will supply access to other services
	/// in the card.
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is not redirected, but calling the function when inside a Remote Desktop session will not result in an error. It only
	/// means that the result will be from the remote computer instead of the local computer.
	/// </para>
	/// <para>
	/// The <c>SCardGetProviderId</c> function is a database query function. For more information on other database query functions, see
	/// Smart Card Database Query Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to get the provider ID for the specified card. The example assumes that hContext is a valid handle
	/// obtained from a previous call to the SCardEstablishContext function and that "MyCardName" was introduced by a previous call to the
	/// SCardIntroduceCardType function.
	/// </para>
	/// <para>
	/// <code>GUID guidProv; LONG lReturn; lReturn = SCardGetProviderId(hContext, L"MyCardName", &amp;guidProv); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardGetProviderId - %x\n", lReturn); else { // Use the provider GUID as needed. // ... }</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardGetProviderId as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardgetproviderida LONG SCardGetProviderIdA( [in]
	// SCARDCONTEXT hContext, [in] LPCSTR szCard, [out] LPGUID pguidProviderId );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardGetProviderIdA")]
	public static extern SCARD_RET SCardGetProviderId([In] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szCard, out Guid pguidProviderId);

	/// <summary>
	/// The <c>SCardGetReaderDeviceInstanceId</c> function gets the device instance identifier of the card reader for the given reader name.
	/// This function does not affect the state of the reader.
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context for the query. You can set the resource manager context by a previous call to the
	/// SCardEstablishContext function. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szReaderName">Reader name. You can get this value by calling the SCardListReaders function.</param>
	/// <param name="szDeviceInstanceId">
	/// Buffer that receives the device instance ID of the reader. If this value is <c>NULL</c>, the function ignores the buffer length
	/// supplied in <c>cchDeviceInstanceId</c> parameter, writes the length of the buffer that would have been returned if this parameter had
	/// not been <c>NULL</c> to <c>cchDeviceInstanceId</c>, and returns a success code.
	/// </param>
	/// <param name="pcchDeviceInstanceId">
	/// Length, in characters, of the <c>szDeviceInstanceId</c> buffer, including the <c>NULL</c> terminator. If the buffer length is
	/// specified as SCARD_AUTOALLOCATE, then the <c>szDeviceInstanceId</c> parameter is converted to a pointer to a byte pointer, and
	/// receives the address of a block of memory containing the instance id. This block of memory must be deallocated with the
	/// SCardFreeMemory function.
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is not redirected. Calling the <c>SCardGetReaderDeviceInstanceId</c> function when inside a Remote Desktop session
	/// fails with the SCARD_E_READER_UNAVAILABLE error code.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// <code> LONG lReturn; LPTSTR szReaderName = "USB Smart Card Reader 0"; WCHAR szDeviceInstanceId[256]; DWORD cchDeviceInstanceId = 256; // Retrieve the reader's device instance ID. // hContext was set by a previous call to SCardEstablishContext. lReturn = SCardGetReaderDeviceInstanceId (hContext, szReaderName, szDeviceInstanceId, &amp;cchDeviceInstanceId); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardGetReaderDeviceInstanceId - %x\n", lReturn); // Take appropriate action. }</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardGetReaderDeviceInstanceId as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardgetreaderdeviceinstanceida LONG
	// SCardGetReaderDeviceInstanceIdA( [in] SCARDCONTEXT hContext, [in] LPCSTR szReaderName, [out, optional] LPSTR szDeviceInstanceId, [in,
	// out] LPDWORD pcchDeviceInstanceId );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardGetReaderDeviceInstanceIdA")]
	public static extern SCARD_RET SCardGetReaderDeviceInstanceId([In] SCARDCONTEXT hContext, [In, MarshalAs(UnmanagedType.LPTStr)] string szReaderName,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? szDeviceInstanceId, ref uint pcchDeviceInstanceId);

	/// <summary>
	/// The <c>SCardGetReaderIcon</c> function gets an icon of the smart card reader for a given reader's name. This function does not affect
	/// the state of the card reader.
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context for the query. You can set the resource manager context by a previous call to the
	/// SCardEstablishContext function. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szReaderName">Reader name. You can get this value by calling the SCardListReaders function.</param>
	/// <param name="pbIcon">
	/// Pointer to a buffer that contains a BLOB of the smart card reader icon as read from the icon file. If this value is <c>NULL</c>, the
	/// function ignores the buffer length supplied in the <c>pcbIcon</c> parameter, writes the length of the buffer that would have been
	/// returned to <c>pcbIcon</c> if this parameter had not been NULL, and returns a success code.
	/// </param>
	/// <param name="pcbIcon">
	/// Length, in characters, of the <c>pbIcon</c> buffer. This parameter receives the actual length of the received attribute. If the
	/// buffer length is specified as SCARD_AUTOALLOCATE, then <c>pbIcon</c> is converted from a pointer to a byte pointer and receives the
	/// address of a block of memory that contains the attribute. This block of memory must be deallocated with the SCardFreeMemory function.
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The icon should be 256 × 256 pixels with no alpha channel.</para>
	/// <para>Examples</para>
	/// <para>
	/// <code>PBYTE pbIcon = NULL; DWORD cbIcon = SCARD_AUTOALLOCATE; DWORD i; LONG lReturn; LPTSTR szReaderName = "USB Smart Card Reader 0"; // Retrieve the reader's icon. // hContext was set by a previous call to SCardEstablishContext. lReturn = SCardGetReaderIcon(hContext, szReaderName, (PBYTE)&amp;pbIcon, &amp;cbIcon); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardGetReaderIcon - %x\n", lReturn); // Take appropriate action. } else { // Free the memory when done. lReturn = SCardFreeMemory(hContext, pbIcon); }</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardGetReaderIcon as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardgetreadericona LONG SCardGetReaderIconA( [in]
	// SCARDCONTEXT hContext, [in] LPCSTR szReaderName, [out] LPBYTE pbIcon, [in, out] LPDWORD pcbIcon );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardGetReaderIconA")]
	public static extern SCARD_RET SCardGetReaderIcon([In] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szReaderName, [Out, Optional] IntPtr pbIcon, ref uint pcbIcon);

	/// <summary>
	/// <para>
	/// The <c>SCardGetStatusChange</c> function blocks execution until the current availability of the cards in a specific set of readers changes.
	/// </para>
	/// <para>
	/// The caller supplies a list of readers to be monitored by an SCARD_READERSTATE array and the maximum amount of time (in milliseconds)
	/// that it is willing to wait for an action to occur on one of the listed readers. Note that <c>SCardGetStatusChange</c> uses the
	/// user-supplied value in the <c>dwCurrentState</c> members of the <c>rgReaderStates</c> SCARD_READERSTATE array as the definition of
	/// the current state of the readers. The function returns when there is a change in availability, having filled in the
	/// <c>dwEventState</c> members of <c>rgReaderStates</c> appropriately.
	/// </para>
	/// </summary>
	/// <param name="hContext">
	/// A handle that identifies the resource manager context. The resource manager context is set by a previous call to the
	/// SCardEstablishContext function.
	/// </param>
	/// <param name="dwTimeout">
	/// The maximum amount of time, in milliseconds, to wait for an action. A value of zero causes the function to return immediately. A
	/// value of INFINITE causes this function never to time out.
	/// </param>
	/// <param name="rgReaderStates">
	/// <para>An array of SCARD_READERSTATE structures that specify the readers to watch, and that receives the result.</para>
	/// <para>
	/// To be notified of the arrival of a new smart card reader, set the <c>szReader</c> member of a SCARD_READERSTATE structure to
	/// "\\?PnP?\Notification", and set all of the other members of that structure to zero.
	/// </para>
	/// <para>
	/// <c>Important</c> Each member of each structure in this array must be initialized to zero and then set to specific values as
	/// necessary. If this is not done, the function will fail in situations that involve remote card readers.
	/// </para>
	/// </param>
	/// <param name="cReaders">The number of elements in the <c>rgReaderStates</c> array.</param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SCardGetStatusChange</c> function is a smart card tracking function. For more information about other tracking functions, see
	/// Smart Card Tracking Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>For information about how to call this function, see the example in SCardLocateCards.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardGetStatusChange as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardgetstatuschangea LONG SCardGetStatusChangeA( [in]
	// SCARDCONTEXT hContext, [in] DWORD dwTimeout, [in, out] LPSCARD_READERSTATEA rgReaderStates, [in] DWORD cReaders );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardGetStatusChangeA")]
	public static extern SCARD_RET SCardGetStatusChange([In] SCARDCONTEXT hContext, [In] uint dwTimeout,
		[In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] SCARD_READERSTATE[] rgReaderStates, [In] uint cReaders);

	/// <summary>
	/// The <c>SCardGetTransmitCount</c> function retrieves the number of transmit operations that have completed since the specified card
	/// reader was inserted.
	/// </summary>
	/// <param name="hCard">A handle to a smart card obtained from a previous call to SCardConnect.</param>
	/// <param name="pcTransmitCount">
	/// A pointer to the number of transmit operations that have completed since the specified card reader was inserted.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>SCARD_S_SUCCESS</c>.</para>
	/// <para>If the function fails, it returns an error code. For more information, see Smart Card Return Values.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardgettransmitcount LONG SCardGetTransmitCount( [in]
	// SCARDHANDLE hCard, [out] LPDWORD pcTransmitCount );
	[DllImport(Lib_Winscard, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardGetTransmitCount")]
	public static extern SCARD_RET SCardGetTransmitCount([In] SCARDHANDLE hCard, out uint pcTransmitCount);

	/// <summary>
	/// The <c>SCardIntroduceCardType</c> function introduces a smart card to the smart card subsystem (for the active user) by adding it to
	/// the smart card database.
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context. The resource manager context is set by a previous call to SCardEstablishContext.
	/// This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szCardName">Name by which the user can recognize the card.</param>
	/// <param name="pguidPrimaryProvider">Pointer to the identifier (GUID) for the smart card's primary service provider.</param>
	/// <param name="rgguidInterfaces">Array of identifiers (GUIDs) that identify the interfaces supported by the smart card.</param>
	/// <param name="dwInterfaceCount">Number of identifiers in the <c>rgguidInterfaces</c> array.</param>
	/// <param name="pbAtr">
	/// ATR string that can be used for matching purposes when querying the smart card database (for more information, see SCardListCards).
	/// The length of this string is determined by normal ATR parsing.
	/// </param>
	/// <param name="pbAtrMask">
	/// Optional bitmask to use when comparing the ATRs of smart cards to the ATR supplied in <c>pbAtr</c>. If this value is non-
	/// <c>NULL</c>, it must point to a string of bytes the same length as the ATR string supplied in <c>pbAtr</c>. When a given ATR string
	/// <c>A</c> is compared to the ATR supplied in <c>pbAtr</c>, it matches if and only if <c>A &amp; M</c> = <c>pbAtr</c>, where <c>M</c>
	/// is the supplied mask, and <c>&amp;</c> represents bitwise AND.
	/// </param>
	/// <param name="cbAtrLen">
	/// Length of the ATR and optional ATR mask. If this value is zero, then the length of the ATR is determined by normal ATR parsing. This
	/// value cannot be zero if a <c>pbAtr</c> value is supplied.
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is not redirected, but calling the function when inside a Remote Desktop session will not result in an error. It only
	/// means that the result will be from the remote computer instead of the local computer.
	/// </para>
	/// <para>
	/// The <c>SCardIntroduceCardType</c> function is a database management function. For more information on other database management
	/// functions, see Smart Card Database Management Functions.
	/// </para>
	/// <para>To remove a smart card, use SCardForgetCardType.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to introduce a card type. The example assumes that hContext is a valid handle obtained from a
	/// previous call to the SCardEstablishContext function.
	/// </para>
	/// <para>
	/// <code>GUID MyGuid = { 0xABCDEF00, 0xABCD, 0xABCD, 0xAA, 0xBB, 0xCC, 0xDD, 0xAA, 0xBB, 0xCC, 0xDD }; static const BYTE MyATR[] = { 0xaa, 0xbb, 0xcc, 0x00, 0xdd }; static const BYTE MyATRMask[] = { 0xff, 0xff, 0xff, 0x00, 0xff}; LONG lReturn; lReturn = SCardIntroduceCardType(hContext, L"MyCardName", &amp;MyGuid, NULL, // No interface array 0, // Interface count = 0 MyATR, MyATRMask, sizeof(MyATR)); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardIntroduceCardType\n");</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardIntroduceCardType as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardintroducecardtypea LONG SCardIntroduceCardTypeA( [in]
	// SCARDCONTEXT hContext, [in] LPCSTR szCardName, [in, optional] LPCGUID pguidPrimaryProvider, [in, optional] LPCGUID rgguidInterfaces,
	// [in] DWORD dwInterfaceCount, [in] LPCBYTE pbAtr, [in] LPCBYTE pbAtrMask, [in] DWORD cbAtrLen );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardIntroduceCardTypeA")]
	public static extern SCARD_RET SCardIntroduceCardType([In] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szCardName,
		in Guid pguidPrimaryProvider, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] Guid[]? rgguidInterfaces,
		[In] uint dwInterfaceCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] byte[] pbAtr,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] byte[]? pbAtrMask, [In] uint cbAtrLen);

	/// <summary>
	/// The <c>SCardIntroduceCardType</c> function introduces a smart card to the smart card subsystem (for the active user) by adding it to
	/// the smart card database.
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context. The resource manager context is set by a previous call to SCardEstablishContext.
	/// This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szCardName">Name by which the user can recognize the card.</param>
	/// <param name="pguidPrimaryProvider">Pointer to the identifier (GUID) for the smart card's primary service provider.</param>
	/// <param name="rgguidInterfaces">Array of identifiers (GUIDs) that identify the interfaces supported by the smart card.</param>
	/// <param name="dwInterfaceCount">Number of identifiers in the <c>rgguidInterfaces</c> array.</param>
	/// <param name="pbAtr">
	/// ATR string that can be used for matching purposes when querying the smart card database (for more information, see SCardListCards).
	/// The length of this string is determined by normal ATR parsing.
	/// </param>
	/// <param name="pbAtrMask">
	/// Optional bitmask to use when comparing the ATRs of smart cards to the ATR supplied in <c>pbAtr</c>. If this value is non-
	/// <c>NULL</c>, it must point to a string of bytes the same length as the ATR string supplied in <c>pbAtr</c>. When a given ATR string
	/// <c>A</c> is compared to the ATR supplied in <c>pbAtr</c>, it matches if and only if <c>A &amp; M</c> = <c>pbAtr</c>, where <c>M</c>
	/// is the supplied mask, and <c>&amp;</c> represents bitwise AND.
	/// </param>
	/// <param name="cbAtrLen">
	/// Length of the ATR and optional ATR mask. If this value is zero, then the length of the ATR is determined by normal ATR parsing. This
	/// value cannot be zero if a <c>pbAtr</c> value is supplied.
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is not redirected, but calling the function when inside a Remote Desktop session will not result in an error. It only
	/// means that the result will be from the remote computer instead of the local computer.
	/// </para>
	/// <para>
	/// The <c>SCardIntroduceCardType</c> function is a database management function. For more information on other database management
	/// functions, see Smart Card Database Management Functions.
	/// </para>
	/// <para>To remove a smart card, use SCardForgetCardType.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to introduce a card type. The example assumes that hContext is a valid handle obtained from a
	/// previous call to the SCardEstablishContext function.
	/// </para>
	/// <para>
	/// <code>GUID MyGuid = { 0xABCDEF00, 0xABCD, 0xABCD, 0xAA, 0xBB, 0xCC, 0xDD, 0xAA, 0xBB, 0xCC, 0xDD }; static const BYTE MyATR[] = { 0xaa, 0xbb, 0xcc, 0x00, 0xdd }; static const BYTE MyATRMask[] = { 0xff, 0xff, 0xff, 0x00, 0xff}; LONG lReturn; lReturn = SCardIntroduceCardType(hContext, L"MyCardName", &amp;MyGuid, NULL, // No interface array 0, // Interface count = 0 MyATR, MyATRMask, sizeof(MyATR)); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardIntroduceCardType\n");</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardIntroduceCardType as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardintroducecardtypea LONG SCardIntroduceCardTypeA( [in]
	// SCARDCONTEXT hContext, [in] LPCSTR szCardName, [in, optional] LPCGUID pguidPrimaryProvider, [in, optional] LPCGUID rgguidInterfaces,
	// [in] DWORD dwInterfaceCount, [in] LPCBYTE pbAtr, [in] LPCBYTE pbAtrMask, [in] DWORD cbAtrLen );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardIntroduceCardTypeA")]
	public static extern SCARD_RET SCardIntroduceCardType([In] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szCardName,
		[In, Optional] IntPtr pguidPrimaryProvider, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] Guid[]? rgguidInterfaces,
		[In] uint dwInterfaceCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] byte[] pbAtr,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] byte[]? pbAtrMask, [In] uint cbAtrLen);

	/// <summary>
	/// <para>The <c>SCardIntroduceReader</c> function introduces a new name for an existing smart card reader.</para>
	/// <para>
	/// <c>Note</c> Smart card readers are automatically introduced to the system; a smart card reader vendor's setup program can also
	/// introduce a smart card reader to the system.
	/// </para>
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context. The resource manager context is set by a previous call to SCardEstablishContext.
	/// This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szReaderName">Display name to be assigned to the reader.</param>
	/// <param name="szDeviceName">System name of the smart card reader, for example, "MyReader 01".</param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// All readers installed on the system are automatically introduced by their system name. Typically, <c>SCardIntroduceReader</c> is
	/// called only to change the name of an existing reader.
	/// </para>
	/// <para>
	/// The <c>SCardIntroduceReader</c> function is a database management function. For more information on other database management
	/// functions, see Smart Card Database Management Functions.
	/// </para>
	/// <para>To remove a reader, use SCardForgetReader.</para>
	/// <para>Examples</para>
	/// <para>The following example shows introducing a smart card reader.</para>
	/// <para>
	/// <code>// This example renames the reader name. // This is a two-step process (first add the new // name, then forget the old name). LPBYTE pbAttr = NULL; DWORD cByte = SCARD_AUTOALLOCATE; LONG lReturn; // Step 1: Add the new reader name. // The device name attribute is a necessary value. // hCardHandle was set by a previous call to SCardConnect. lReturn = SCardGetAttrib(hCardHandle, SCARD_ATTR_DEVICE_SYSTEM_NAME, (LPBYTE)&amp;pbAttr, &amp;cByte); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardGetAttrib\n"); exit(1); // Or other error action } // Add the reader name. // hContext was set earlier by SCardEstablishContext. lReturn = SCardIntroduceReader(hContext, TEXT("My New Reader Name"), (LPCTSTR)pbAttr ); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardIntroduceReader\n"); exit(1); // Or other error action } // Step 2: Forget the old reader name. lReturn = SCardForgetReader(hContext, (LPCTSTR)pbAttr ); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardForgetReader\n"); exit(1); // Or other error action } // Free the memory when done. lReturn = SCardFreeMemory( hContext, pbAttr );</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardIntroduceReader as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardintroducereadera LONG SCardIntroduceReaderA( [in]
	// SCARDCONTEXT hContext, [in] LPCSTR szReaderName, [in] LPCSTR szDeviceName );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardIntroduceReaderA")]
	public static extern SCARD_RET SCardIntroduceReader([In] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szReaderName, [MarshalAs(UnmanagedType.LPTStr)] string szDeviceName);

	/// <summary>
	/// The <c>SCardIntroduceReaderGroup</c> function introduces a reader group to the smart card subsystem. However, the reader group is not
	/// created until the group is specified when adding a reader to the smart card database.
	/// </summary>
	/// <param name="hContext">
	/// Supplies the handle that identifies the resource manager context. The resource manager context is set by a previous call to the
	/// SCardEstablishContext function. If this parameter is <c>NULL</c>, the scope of the resource manager is SCARD_SCOPE_SYSTEM.
	/// </param>
	/// <param name="szGroupName">
	/// <para>Supplies the display name to be assigned to the new reader group.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_ALL_READERS</c> TEXT("SCard$AllReaders\000")</term>
	/// <term>
	/// Group used when no group name is provided when listing readers. Returns a list of all readers, regardless of what group or groups the
	/// readers are in.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_DEFAULT_READERS</c> TEXT("SCard$DefaultReaders\000")</term>
	/// <term>Default group to which all readers are added when introduced into the system.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_LOCAL_READERS</c> TEXT("SCard$LocalReaders\000")</term>
	/// <term>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_SYSTEM_READERS</c> TEXT("SCard$SystemReaders\000")</term>
	/// <term>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SCardIntroduceReaderGroup</c> function is provided for PC/SC specification compatibility. Reader groups are not stored until a
	/// reader is added to the group.
	/// </para>
	/// <para>
	/// The <c>SCardIntroduceReaderGroup</c> function is a database management function. For a description of other database management
	/// functions, see Smart Card Database Management Functions.
	/// </para>
	/// <para>To remove a reader group, use SCardForgetReaderGroup.</para>
	/// <para>Examples</para>
	/// <para>The following example shows introducing a smart card reader group.</para>
	/// <para>
	/// <code>// Introduce the reader group. // lReturn is of type LONG. // hContext was set by a previous call to SCardEstablishContext. lReturn = SCardIntroduceReaderGroup(hContext, L"MyReaderGroup"); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardIntroduceReaderGroup\n");</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardIntroduceReaderGroup as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardintroducereadergroupa LONG SCardIntroduceReaderGroupA(
	// [in] SCARDCONTEXT hContext, [in] LPCSTR szGroupName );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardIntroduceReaderGroupA")]
	public static extern SCARD_RET SCardIntroduceReaderGroup([In, Optional] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szGroupName);

	/// <summary>The <c>SCardIsValidContext</c> function determines whether a smart card context handle is valid.</summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context. The resource manager context can be set by a previous call to SCardEstablishContext.
	/// </param>
	/// <returns>
	/// <para>This function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_S_SUCCESS</c></term>
	/// <term>The <c>hContext</c> parameter is valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The <c>hContext</c> parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>Other values</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Call this function to determine whether a smart card context handle is still valid. After a smart card context handle has been set by
	/// SCardEstablishContext, it may become not valid if the resource manager service has been shut down.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows determining whether a smart card context handle is valid.</para>
	/// <para>
	/// <code>// Check the smart card context handle. // hContext was set previously by SCardEstablishContext. LONG lReturn; lReturn = SCardIsValidContext(hContext); if ( SCARD_S_SUCCESS != lReturn ) { // Function failed; check return value. if ( ERROR_INVALID_HANDLE == lReturn ) printf("Handle is invalid\n"); else { // Some unexpected error occurred; report and bail out. printf("Failed SCardIsValidContext - %x\n", lReturn); exit(1); // Or other appropriate error action. } } else { // Handle is valid; proceed as needed. // ... }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardisvalidcontext LONG SCardIsValidContext( [in]
	// SCARDCONTEXT hContext );
	[DllImport(Lib_Winscard, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardIsValidContext")]
	public static extern SCARD_RET SCardIsValidContext([In] SCARDCONTEXT hContext);

	/// <summary>
	/// <para>
	/// The <c>SCardListCards</c> function searches the smart card database and provides a list of named cards previously introduced to the
	/// system by the user.
	/// </para>
	/// <para>
	/// The caller specifies an ATR string, a set of interface identifiers (GUIDs), or both. If both an ATR string and an identifier array
	/// are supplied, the cards returned will match the ATR string supplied and support the interfaces specified.
	/// </para>
	/// </summary>
	/// <param name="hContext">
	/// <para>
	/// Handle that identifies the resource manager context for the query. The resource manager context can be set by a previous call to SCardEstablishContext.
	/// </para>
	/// <para>If this parameter is set to <c>NULL</c>, the search for cards is not limited to any context.</para>
	/// </param>
	/// <param name="pbAtr">Address of an ATR string to compare to known cards, or <c>NULL</c> if no ATR matching is to be performed.</param>
	/// <param name="rgquidInterfaces">
	/// Array of identifiers (GUIDs), or <c>NULL</c> if no interface matching is to be performed. When an array is supplied, a card name will
	/// be returned only if all the specified identifiers are supported by the card.
	/// </param>
	/// <param name="cguidInterfaceCount">
	/// Number of entries in the <c>rgguidInterfaces</c> array. If <c>rgguidInterfaces</c> is <c>NULL</c>, then this value is ignored.
	/// </param>
	/// <param name="mszCards">
	/// Multi-string that lists the smart cards found. If this value is <c>NULL</c>, <c>SCardListCards</c> ignores the buffer length supplied
	/// in <c>pcchCards</c>, returning the length of the buffer that would have been returned if this parameter had not been <c>NULL</c> to
	/// <c>pcchCards</c> and a success code.
	/// </param>
	/// <param name="pcchCards">
	/// Length of the <c>mszCards</c> buffer in characters. Receives the actual length of the multi-string structure, including all trailing
	/// <c>null</c> characters. If the buffer length is specified as SCARD_AUTOALLOCATE, then <c>mszCards</c> is converted to a pointer to a
	/// byte pointer, and receives the address of a block of memory containing the multi-string structure. This block of memory must be
	/// deallocated with SCardFreeMemory.
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is not redirected, but calling the function when inside a Remote Desktop session will not result in an error. It only
	/// means that the result will be from the remote computer instead of the local computer.
	/// </para>
	/// <para>To return all smart cards introduced to the subsystem, set <c>pbAtr</c> and <c>rgguidInterfaces</c> to <c>NULL</c>.</para>
	/// <para>
	/// The <c>SCardListCards</c> function is a database query function. For more information on other database query functions, see Smart
	/// Card Database Query Functions.
	/// </para>
	/// <para>
	/// Calling this function should be done outside of a transaction. If an application begins a transaction with the SCardBeginTransaction
	/// function and then calls this function, it resets the <c>hCard</c> parameter (of type <c>SCARDHANDLE</c>) of the
	/// <c>SCardBeginTransaction</c> function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2008 R2 and Windows 7:</c> Calling this function within a transaction could result in your computer becoming unresponsive.
	/// </para>
	/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> Not applicable.</para>
	/// <para>Examples</para>
	/// <para>The following example shows listing of the smart cards.</para>
	/// <para>
	/// <code>LPTSTR pmszCards = NULL; LPTSTR pCard; LONG lReturn; DWORD cch = SCARD_AUTOALLOCATE; // Retrieve the list of cards. lReturn = SCardListCards(NULL, NULL, NULL, NULL, (LPTSTR)&amp;pmszCards, &amp;cch ); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardListCards\n"); exit(1); // Or other appropriate error action } // Do something with the multi string of cards. // Output the values. // A double-null terminates the list of values. pCard = pmszCards; while ( '\0' != *pCard ) { // Display the value. printf("%S\n", pCard ); // Advance to the next value. pCard = pCard + wcslen(pCard) + 1; } // Remember to free pmszCards (by calling SCardFreeMemory). // ...</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardListCards as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardlistcardsa LONG SCardListCardsA( [in] SCARDCONTEXT
	// hContext, [in, optional] LPCBYTE pbAtr, [in] LPCGUID rgquidInterfaces, [in] DWORD cguidInterfaceCount, [out] CHAR *mszCards, [in, out]
	// LPDWORD pcchCards );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardListCardsA")]
	public static extern SCARD_RET SCardListCards([In, Optional] SCARDCONTEXT hContext, [In, Optional, MarshalAs(UnmanagedType.LPArray)] byte[]? pbAtr,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] Guid[]? rgquidInterfaces, [In, Optional] uint cguidInterfaceCount,
		[Out, Optional] IntPtr mszCards, ref uint pcchCards);

	/// <summary>
	/// <para>
	/// The <c>SCardListCards</c> function searches the smart card database and provides a list of named cards previously introduced to the
	/// system by the user.
	/// </para>
	/// <para>
	/// The caller specifies an ATR string, a set of interface identifiers (GUIDs), or both. If both an ATR string and an identifier array
	/// are supplied, the cards returned will match the ATR string supplied and support the interfaces specified.
	/// </para>
	/// </summary>
	/// <param name="hContext">
	/// <para>
	/// Handle that identifies the resource manager context for the query. The resource manager context can be set by a previous call to SCardEstablishContext.
	/// </para>
	/// <para>If this parameter is set to <c>NULL</c>, the search for cards is not limited to any context.</para>
	/// </param>
	/// <param name="pbAtr">Address of an ATR string to compare to known cards, or <c>NULL</c> if no ATR matching is to be performed.</param>
	/// <param name="rgquidInterfaces">
	/// Array of identifiers (GUIDs), or <c>NULL</c> if no interface matching is to be performed. When an array is supplied, a card name will
	/// be returned only if all the specified identifiers are supported by the card.
	/// </param>
	/// <param name="mszCards">
	/// Multi-string that lists the smart cards found. If this value is <c>NULL</c>, <c>SCardListCards</c> ignores the buffer length supplied
	/// in <c>pcchCards</c>, returning the length of the buffer that would have been returned if this parameter had not been <c>NULL</c> to
	/// <c>pcchCards</c> and a success code.
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is not redirected, but calling the function when inside a Remote Desktop session will not result in an error. It only
	/// means that the result will be from the remote computer instead of the local computer.
	/// </para>
	/// <para>To return all smart cards introduced to the subsystem, set <c>pbAtr</c> and <c>rgguidInterfaces</c> to <c>NULL</c>.</para>
	/// <para>
	/// The <c>SCardListCards</c> function is a database query function. For more information on other database query functions, see Smart
	/// Card Database Query Functions.
	/// </para>
	/// <para>
	/// Calling this function should be done outside of a transaction. If an application begins a transaction with the SCardBeginTransaction
	/// function and then calls this function, it resets the <c>hCard</c> parameter (of type <c>SCARDHANDLE</c>) of the
	/// <c>SCardBeginTransaction</c> function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2008 R2 and Windows 7:</c> Calling this function within a transaction could result in your computer becoming unresponsive.
	/// </para>
	/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> Not applicable.</para>
	/// </remarks>
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardListCardsA")]
	public static SCARD_RET SCardListCards([In, Optional] SCARDCONTEXT hContext, [Optional] byte[]? pbAtr, [Optional] Guid[]? rgquidInterfaces, out string[] mszCards) =>
		ListSCardFunc((IntPtr p, ref uint c) => SCardListCards(hContext, pbAtr, rgquidInterfaces, (uint)(rgquidInterfaces?.Length ?? 0), p, ref c), out mszCards);

	/// <summary>
	/// <para>The <c>SCardListInterfaces</c> function provides a list of interfaces supplied by a given card.</para>
	/// <para>
	/// The caller supplies the name of a smart card previously introduced to the subsystem, and receives the list of interfaces supported by
	/// the card.
	/// </para>
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context for the query. The resource manager context can be set by a previous call to
	/// SCardEstablishContext. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szCard">Name of the smart card already introduced to the smart card subsystem.</param>
	/// <param name="pguidInterfaces">
	/// Array of interface identifiers (GUIDs) that indicate the interfaces supported by the smart card. If this value is <c>NULL</c>,
	/// <c>SCardListInterfaces</c> ignores the array length supplied in <c>pcguidInterfaces</c>, returning the size of the array that would
	/// have been returned if this parameter had not been <c>NULL</c> to <c>pcguidInterfaces</c> and a success code.
	/// </param>
	/// <param name="pcguidInterfaces">
	/// Size of the <c>pcguidInterfaces</c> array, and receives the actual size of the returned array. If the array size is specified as
	/// SCARD_AUTOALLOCATE, then <c>pcguidInterfaces</c> is converted to a pointer to a GUID pointer, and receives the address of a block of
	/// memory containing the array. This block of memory must be deallocated with SCardFreeMemory.
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is not redirected, but calling the function when attempting a Remote Desktop session will not result in an error. It
	/// only means that the result will be from the remote computer instead of the local computer.
	/// </para>
	/// <para>
	/// The <c>SCardListInterfaces</c> function is a database query function. For more information on other database query functions, see
	/// Smart Card Database Query Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows listing the interfaces for a smart card.</para>
	/// <para>
	/// <code>LPGUID pGuids = NULL; LONG lReturn; DWORD cGuid = SCARD_AUTOALLOCATE; // Retrieve the list of interfaces. lReturn = SCardListInterfaces(NULL, (LPCSTR) "MyCard", (LPGUID)&amp;pGuids, &amp;cGuid ); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardListInterfaces\n"); exit(1); // Or other appropriate action } if ( 0 != cGuid ) { // Do something with the array of Guids. // Remember to free pGuids when done (by SCardFreeMemory). // ... }</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardListInterfaces as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardlistinterfacesa LONG SCardListInterfacesA( [in]
	// SCARDCONTEXT hContext, [in] LPCSTR szCard, [out] LPGUID pguidInterfaces, [in, out] LPDWORD pcguidInterfaces );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardListInterfacesA")]
	public static extern SCARD_RET SCardListInterfaces([In] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szCard,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] Guid[]? pguidInterfaces, ref uint pcguidInterfaces);

	/// <summary>
	/// <para>The <c>SCardListInterfaces</c> function provides a list of interfaces supplied by a given card.</para>
	/// <para>
	/// The caller supplies the name of a smart card previously introduced to the subsystem, and receives the list of interfaces supported by
	/// the card.
	/// </para>
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context for the query. The resource manager context can be set by a previous call to
	/// SCardEstablishContext. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szCard">Name of the smart card already introduced to the smart card subsystem.</param>
	/// <param name="pguidInterfaces">
	/// Array of interface identifiers (GUIDs) that indicate the interfaces supported by the smart card. If this value is <c>NULL</c>,
	/// <c>SCardListInterfaces</c> ignores the array length supplied in <c>pcguidInterfaces</c>, returning the size of the array that would
	/// have been returned if this parameter had not been <c>NULL</c> to <c>pcguidInterfaces</c> and a success code.
	/// </param>
	/// <param name="pcguidInterfaces">
	/// Size of the <c>pcguidInterfaces</c> array, and receives the actual size of the returned array. If the array size is specified as
	/// SCARD_AUTOALLOCATE, then <c>pcguidInterfaces</c> is converted to a pointer to a GUID pointer, and receives the address of a block of
	/// memory containing the array. This block of memory must be deallocated with SCardFreeMemory.
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is not redirected, but calling the function when attempting a Remote Desktop session will not result in an error. It
	/// only means that the result will be from the remote computer instead of the local computer.
	/// </para>
	/// <para>
	/// The <c>SCardListInterfaces</c> function is a database query function. For more information on other database query functions, see
	/// Smart Card Database Query Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows listing the interfaces for a smart card.</para>
	/// <para>
	/// <code>LPGUID pGuids = NULL; LONG lReturn; DWORD cGuid = SCARD_AUTOALLOCATE; // Retrieve the list of interfaces. lReturn = SCardListInterfaces(NULL, (LPCSTR) "MyCard", (LPGUID)&amp;pGuids, &amp;cGuid ); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardListInterfaces\n"); exit(1); // Or other appropriate action } if ( 0 != cGuid ) { // Do something with the array of Guids. // Remember to free pGuids when done (by SCardFreeMemory). // ... }</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardListInterfaces as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardlistinterfacesa LONG SCardListInterfacesA( [in]
	// SCARDCONTEXT hContext, [in] LPCSTR szCard, [out] LPGUID pguidInterfaces, [in, out] LPDWORD pcguidInterfaces );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardListInterfacesA")]
	public static extern SCARD_RET SCardListInterfaces([In] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szCard,
		[Out, Optional] IntPtr pguidInterfaces, ref uint pcguidInterfaces);

	/// <summary>
	/// <para>The <c>SCardListInterfaces</c> function provides a list of interfaces supplied by a given card.</para>
	/// <para>
	/// The caller supplies the name of a smart card previously introduced to the subsystem, and receives the list of interfaces supported by
	/// the card.
	/// </para>
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context for the query. The resource manager context can be set by a previous call to
	/// SCardEstablishContext. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szCard">Name of the smart card already introduced to the smart card subsystem.</param>
	/// <param name="pguidInterfaces">Array of interface identifiers (GUIDs) that indicate the interfaces supported by the smart card.</param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is not redirected, but calling the function when attempting a Remote Desktop session will not result in an error. It
	/// only means that the result will be from the remote computer instead of the local computer.
	/// </para>
	/// <para>
	/// The <c>SCardListInterfaces</c> function is a database query function. For more information on other database query functions, see
	/// Smart Card Database Query Functions.
	/// </para>
	/// </remarks>
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardListInterfacesA")]
	public static SCARD_RET SCardListInterfaces([In] SCARDCONTEXT hContext, string szCard, out Guid[] pguidInterfaces) =>
		ListSCardFunc((IntPtr p, ref uint c) => SCardListInterfaces(hContext, szCard, p, ref c), out pguidInterfaces);

	/// <summary>
	/// The <c>SCardListReaderGroups</c> function provides the list of reader groups that have previously been introduced to the system.
	/// </summary>
	/// <param name="hContext">
	/// <para>
	/// Handle that identifies the resource manager context for the query. The resource manager context can be set by a previous call to SCardEstablishContext.
	/// </para>
	/// <para>If this parameter is set to <c>NULL</c>, the search for reader groups is not limited to any context.</para>
	/// </param>
	/// <param name="mszGroups">
	/// <para>
	/// Multi-string that lists the reader groups defined to the system and available to the current user on the current terminal. If this
	/// value is <c>NULL</c>, <c>SCardListReaderGroups</c> ignores the buffer length supplied in <c>pcchGroups</c>, writes the length of the
	/// buffer that would have been returned if this parameter had not been <c>NULL</c> to <c>pcchGroups</c>, and returns a success code.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_ALL_READERS</c> TEXT("SCard$AllReaders\000")</term>
	/// <term>
	/// Group used when no group name is provided when listing readers. Returns a list of all readers, regardless of what group or groups the
	/// readers are in.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_DEFAULT_READERS</c> TEXT("SCard$DefaultReaders\000")</term>
	/// <term>Default group to which all readers are added when introduced into the system.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_LOCAL_READERS</c> TEXT("SCard$LocalReaders\000")</term>
	/// <term>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_SYSTEM_READERS</c> TEXT("SCard$SystemReaders\000")</term>
	/// <term>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pcchGroups">
	/// Length of the <c>mszGroups</c> buffer in characters, and receives the actual length of the multi-string structure, including all
	/// trailing <c>null</c> characters. If the buffer length is specified as SCARD_AUTOALLOCATE, then <c>mszGroups</c> is converted to a
	/// pointer to a byte pointer, and receives the address of a block of memory containing the multi-string structure. This block of memory
	/// must be deallocated with SCardFreeMemory.
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A group is returned only if it contains at least one reader. This includes the group SCard$DefaultReaders. The group SCard$AllReaders
	/// cannot be returned, since it only exists implicitly.
	/// </para>
	/// <para>
	/// The <c>SCardListReaderGroups</c> function is a database query function. For more information on other database query functions, see
	/// Smart Card Database Query Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows listing the reader groups.</para>
	/// <para>
	/// <code>LPTSTR pmszReaderGroups = NULL; LPTSTR pReaderGroup; LONG lReturn; DWORD cch = SCARD_AUTOALLOCATE; // Retrieve the list the reader groups. // hSC was set by a previous call to SCardEstablishContext. lReturn = SCardListReaderGroups(hSC, (LPTSTR)&amp;pmszReaderGroups, &amp;cch ); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardListReaderGroups\n"); else { // Do something with the multi string of reader groups. // Output the values. // A double-null terminates the list of values. pReaderGroup = pmszReaderGroups; while ( '\0' != *pReaderGroup ) { // Display the value. printf("%S\n", pReaderGroup ); // Advance to the next value. pReaderGroup = pReaderGroup + wcslen((wchar_t *) pReaderGroup) + 1; } // Remember to free pmszReaderGroups by a call to SCardFreeMemory. // ... }</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardListReaderGroups as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardlistreadergroupsa LONG SCardListReaderGroupsA( [in]
	// SCARDCONTEXT hContext, [out] LPSTR mszGroups, [in, out] LPDWORD pcchGroups );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardListReaderGroupsA")]
	public static extern SCARD_RET SCardListReaderGroups([In, Optional] SCARDCONTEXT hContext, [Out] IntPtr mszGroups, ref uint pcchGroups);

	/// <summary>
	/// The <c>SCardListReaderGroups</c> function provides the list of reader groups that have previously been introduced to the system.
	/// </summary>
	/// <param name="hContext">
	/// <para>
	/// Handle that identifies the resource manager context for the query. The resource manager context can be set by a previous call to SCardEstablishContext.
	/// </para>
	/// <para>If this parameter is set to <c>NULL</c>, the search for reader groups is not limited to any context.</para>
	/// </param>
	/// <param name="mszGroups">
	/// <para>String array that lists the reader groups defined to the system and available to the current user on the current terminal.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_ALL_READERS</c> TEXT("SCard$AllReaders\000")</term>
	/// <term>
	/// Group used when no group name is provided when listing readers. Returns a list of all readers, regardless of what group or groups the
	/// readers are in.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_DEFAULT_READERS</c> TEXT("SCard$DefaultReaders\000")</term>
	/// <term>Default group to which all readers are added when introduced into the system.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_LOCAL_READERS</c> TEXT("SCard$LocalReaders\000")</term>
	/// <term>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_SYSTEM_READERS</c> TEXT("SCard$SystemReaders\000")</term>
	/// <term>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A group is returned only if it contains at least one reader. This includes the group SCard$DefaultReaders. The group SCard$AllReaders
	/// cannot be returned, since it only exists implicitly.
	/// </para>
	/// <para>
	/// The <c>SCardListReaderGroups</c> function is a database query function. For more information on other database query functions, see
	/// Smart Card Database Query Functions.
	/// </para>
	/// </remarks>
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardListReaderGroupsA")]
	public static SCARD_RET SCardListReaderGroups([In, Optional] SCARDCONTEXT hContext, out string[] mszGroups) =>
		ListSCardFunc((IntPtr p, ref uint c) => SCardListReaderGroups(hContext, p, ref c), out mszGroups);

	/// <summary>
	/// <para>The <c>SCardListReaders</c> function provides the list of readers within a set of named reader groups, eliminating duplicates.</para>
	/// <para>
	/// The caller supplies a list of reader groups, and receives the list of readers within the named groups. Unrecognized group names are
	/// ignored. This function only returns readers within the named groups that are currently attached to the system and available for use.
	/// </para>
	/// </summary>
	/// <param name="hContext">
	/// <para>
	/// Handle that identifies the resource manager context for the query. The resource manager context can be set by a previous call to SCardEstablishContext.
	/// </para>
	/// <para>If this parameter is set to <c>NULL</c>, the search for readers is not limited to any context.</para>
	/// </param>
	/// <param name="mszGroups">
	/// <para>
	/// Names of the reader groups defined to the system, as a multi-string. Use a <c>NULL</c> value to list all readers in the system (that
	/// is, the SCard$AllReaders group).
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_ALL_READERS</c> TEXT("SCard$AllReaders\000")</term>
	/// <term>
	/// Group used when no group name is provided when listing readers. Returns a list of all readers, regardless of what group or groups the
	/// readers are in.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_DEFAULT_READERS</c> TEXT("SCard$DefaultReaders\000")</term>
	/// <term>Default group to which all readers are added when introduced into the system.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_LOCAL_READERS</c> TEXT("SCard$LocalReaders\000")</term>
	/// <term>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_SYSTEM_READERS</c> TEXT("SCard$SystemReaders\000")</term>
	/// <term>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="mszReaders">
	/// Multi-string that lists the card readers within the supplied reader groups. If this value is <c>NULL</c>, <c>SCardListReaders</c>
	/// ignores the buffer length supplied in <c>pcchReaders</c>, writes the length of the buffer that would have been returned if this
	/// parameter had not been <c>NULL</c> to <c>pcchReaders</c>, and returns a success code.
	/// </param>
	/// <param name="pcchReaders">
	/// Length of the <c>mszReaders</c> buffer in characters. This parameter receives the actual length of the multi-string structure,
	/// including all trailing <c>null</c> characters. If the buffer length is specified as SCARD_AUTOALLOCATE, then <c>mszReaders</c> is
	/// converted to a pointer to a byte pointer, and receives the address of a block of memory containing the multi-string structure. This
	/// block of memory must be deallocated with SCardFreeMemory.
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c> 0 (0x0)</term>
	/// <term>SCARD_S_SUCCESS</term>
	/// </item>
	/// <item>
	/// <term><c>Group contains no readers</c> 2148532270 (0x8010002E)</term>
	/// <term>SCARD_E_NO_READERS_AVAILABLE</term>
	/// </item>
	/// <item>
	/// <term><c>Specified reader is not currently available for use</c> 2148532247 (0x80100017)</term>
	/// <term>SCARD_E_READER_UNAVAILABLE</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SCardListReaders</c> function is a database query function. For more information on other database query functions, see Smart
	/// Card Database Query Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows listing the readers.</para>
	/// <para>
	/// <code>LPTSTR pmszReaders = NULL; LPTSTR pReader; LONG lReturn, lReturn2; DWORD cch = SCARD_AUTOALLOCATE; // Retrieve the list the readers. // hSC was set by a previous call to SCardEstablishContext. lReturn = SCardListReaders(hSC, NULL, (LPTSTR)&amp;pmszReaders, &amp;cch ); switch( lReturn ) { case SCARD_E_NO_READERS_AVAILABLE: printf("Reader is not in groups.\n"); // Take appropriate action. // ... break; case SCARD_S_SUCCESS: // Do something with the multi string of readers. // Output the values. // A double-null terminates the list of values. pReader = pmszReaders; while ( '\0' != *pReader ) { // Display the value. printf("Reader: %S\n", pReader ); // Advance to the next value. pReader = pReader + wcslen((wchar_t *)pReader) + 1; } // Free the memory. lReturn2 = SCardFreeMemory( hSC, pmszReaders ); if ( SCARD_S_SUCCESS != lReturn2 ) printf("Failed SCardFreeMemory\n"); break; default: printf("Failed SCardListReaders\n"); // Take appropriate action. // ... break; }</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardListReaders as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardlistreadersa LONG SCardListReadersA( [in] SCARDCONTEXT
	// hContext, [in, optional] LPCSTR mszGroups, [out] LPSTR mszReaders, [in, out] LPDWORD pcchReaders );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardListReadersA")]
	public static extern SCARD_RET SCardListReaders([In, Optional] SCARDCONTEXT hContext,
		[In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")] string[]? mszGroups,
		[Out, Optional] IntPtr mszReaders, ref uint pcchReaders);

	/// <summary>
	/// <para>The <c>SCardListReaders</c> function provides the list of readers within a set of named reader groups, eliminating duplicates.</para>
	/// <para>
	/// The caller supplies a list of reader groups, and receives the list of readers within the named groups. Unrecognized group names are
	/// ignored. This function only returns readers within the named groups that are currently attached to the system and available for use.
	/// </para>
	/// </summary>
	/// <param name="hContext">
	/// <para>
	/// Handle that identifies the resource manager context for the query. The resource manager context can be set by a previous call to SCardEstablishContext.
	/// </para>
	/// <para>If this parameter is set to <c>NULL</c>, the search for readers is not limited to any context.</para>
	/// </param>
	/// <param name="mszGroups">
	/// <para>
	/// Names of the reader groups defined to the system, as a string array. Use a <c>NULL</c> value to list all readers in the system (that
	/// is, the SCard$AllReaders group).
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_ALL_READERS</c> TEXT("SCard$AllReaders\000")</term>
	/// <term>
	/// Group used when no group name is provided when listing readers. Returns a list of all readers, regardless of what group or groups the
	/// readers are in.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_DEFAULT_READERS</c> TEXT("SCard$DefaultReaders\000")</term>
	/// <term>Default group to which all readers are added when introduced into the system.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_LOCAL_READERS</c> TEXT("SCard$LocalReaders\000")</term>
	/// <term>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_SYSTEM_READERS</c> TEXT("SCard$SystemReaders\000")</term>
	/// <term>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="mszReaders">String array that lists the card readers within the supplied reader groups.</param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c> 0 (0x0)</term>
	/// <term>SCARD_S_SUCCESS</term>
	/// </item>
	/// <item>
	/// <term><c>Group contains no readers</c> 2148532270 (0x8010002E)</term>
	/// <term>SCARD_E_NO_READERS_AVAILABLE</term>
	/// </item>
	/// <item>
	/// <term><c>Specified reader is not currently available for use</c> 2148532247 (0x80100017)</term>
	/// <term>SCARD_E_READER_UNAVAILABLE</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SCardListReaders</c> function is a database query function. For more information on other database query functions, see Smart
	/// Card Database Query Functions.
	/// </para>
	/// </remarks>
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardListReadersA")]
	public static SCARD_RET SCardListReaders([In, Optional] SCARDCONTEXT hContext, [In, Optional] string[]? mszGroups, out string[]? mszReaders) =>
		ListSCardFunc((IntPtr p, ref uint c) => SCardListReaders(hContext, mszGroups, p, ref c), out mszReaders);

	/// <summary>
	/// The <c>SCardListReadersWithDeviceInstanceId</c> function gets the list of readers that have provided a device instance identifier.
	/// This function does not affect the state of the reader.
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context for the query. You can set the resource manager context by a previous call to the
	/// SCardEstablishContext function. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szDeviceInstanceId">
	/// Device instance ID of the reader. You can get this value by calling the SCardGetReaderDeviceInstanceId function with the reader name
	/// or by calling the SetupDiGetDeviceInstanceId function from the DDK.
	/// </param>
	/// <param name="mszReaders">
	/// A multi-string that contain the smart card readers within the supplied device instance identifier. If this value is <c>NULL</c>, then
	/// the function ignores the buffer length supplied in the <c>pcchReaders</c> parameter, writes the length of the buffer that would have
	/// been returned if this parameter had not been <c>NULL</c> to <c>pcchReaders</c>, and returns a success code.
	/// </param>
	/// <param name="pcchReaders">
	/// The length, in characters, of the <c>mszReaders</c> buffer. This parameter receives the actual length of the multiple-string
	/// structure, including all terminating null characters. If the buffer length is specified as SCARD_AUTOALLOCATE, then <c>mszReaders</c>
	/// is converted to a pointer to a byte pointer, and receives the address of a block of memory that contains the multiple-string
	/// structure. When you have finished using this memory, deallocated it by using the SCardFreeMemory function.
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is not redirected. Calling the <c>SCardListReadersWithDeviceInstanceId</c> function when inside a Remote Desktop
	/// session fails with the SCARD_E_READER_UNAVAILABLE error code.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// <code language="cpp"><![CDATA[szDeviceInstanceIdcchReaderNameLONG     lReturn, lReturn2;
	/// 
	/// LPTSTR   pmszReaders = NULL;
	/// LPTSTR   pReader = NULL;WCHAR
	/// DWORD    cchReaderName = SCARD_AUTOALLOCATE;
	/// 
	/// // Retrieve the reader’s name from it’s device instance ID
	/// // hContext was set by a previous call to SCardEstablishContext. 
	/// 
	/// // szDeviceInstanceId was obtained by calling SetupDiGetDeviceInstanceId
	/// lReturn = SCardListReadersWithDeviceInstanceId (hContext,
	///                          szDeviceInstanceId,
	///                          (LPTSTR)&pmszReaders,
	///                          &cchReaderName);
	/// 
	/// switch( lReturn )
	/// {
	///     case SCARD_E_NO_READERS_AVAILABLE:
	///         printf("No readers have the provided device instance ID.\n");
	///         // Take appropriate action.
	///         // ...
	///         break;
	/// 
	///     case SCARD_S_SUCCESS:
	///         // Do something with the multi string of readers.
	///         // Output the values.
	///         // A double-null terminates the list of values.
	///         pReader = pmszReaders;
	///         while ( '\0' != *pReader )
	///         {
	///             // Display the value.
	///             printf("Reader: %S\n", pReader );
	///             // Advance to the next value.
	///             pReader = pReader + wcslen((wchar_t *)pReader) + 1;
	///         }
	///         // Free the memory.
	///         lReturn2 = SCardFreeMemory( hContext,
	///                                    pmszReaders );
	///         if ( SCARD_S_SUCCESS != lReturn2 )
	///             printf("Failed SCardFreeMemory\n");
	///         break;
	/// 
	/// default:
	///         printf("Failed SCardListReaders\n");
	///         // Take appropriate action.
	///         // ...
	///         break;
	/// ]]></code></para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardListReadersWithDeviceInstanceId as an alias which automatically selects the ANSI or Unicode
	/// version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias
	/// with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardlistreaderswithdeviceinstanceida LONG
	// SCardListReadersWithDeviceInstanceIdA( [in] SCARDCONTEXT hContext, [in] LPCSTR szDeviceInstanceId, [out, optional] LPSTR mszReaders,
	// [in, out] LPDWORD pcchReaders );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardListReadersWithDeviceInstanceIdA")]
	public static extern SCARD_RET SCardListReadersWithDeviceInstanceId([In] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szDeviceInstanceId, [Out, Optional] IntPtr mszReaders, ref uint pcchReaders);

	/// <summary>
	/// The <c>SCardListReadersWithDeviceInstanceId</c> function gets the list of readers that have provided a device instance identifier.
	/// This function does not affect the state of the reader.
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context for the query. You can set the resource manager context by a previous call to the
	/// SCardEstablishContext function. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szDeviceInstanceId">
	/// Device instance ID of the reader. You can get this value by calling the SCardGetReaderDeviceInstanceId function with the reader name
	/// or by calling the SetupDiGetDeviceInstanceId function from the DDK.
	/// </param>
	/// <param name="mszReaders">A string array that contain the smart card readers within the supplied device instance identifier.</param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is not redirected. Calling the <c>SCardListReadersWithDeviceInstanceId</c> function when inside a Remote Desktop
	/// session fails with the SCARD_E_READER_UNAVAILABLE error code.
	/// </para>
	/// </remarks>
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardListReadersWithDeviceInstanceIdA")]
	public static SCARD_RET SCardListReadersWithDeviceInstanceId([In] SCARDCONTEXT hContext, string szDeviceInstanceId, out string[] mszReaders) =>
		ListSCardFunc((IntPtr p, ref uint c) => SCardListReadersWithDeviceInstanceId(hContext, szDeviceInstanceId, p, ref c), out mszReaders);

	/// <summary>
	/// The <c>SCardLocateCards</c> function searches the readers listed in the <c>rgReaderStates</c> parameter for a card with an ATR string
	/// that matches one of the card names specified in <c>mszCards</c>, returning immediately with the result.
	/// </summary>
	/// <param name="hContext">
	/// A handle that identifies the resource manager context. The resource manager context is set by a previous call to SCardEstablishContext.
	/// </param>
	/// <param name="mszCards">A multiple string that contains the names of the cards to search for.</param>
	/// <param name="rgReaderStates">
	/// An array of SCARD_READERSTATE structures that, on input, specify the readers to search and that, on output, receives the result.
	/// </param>
	/// <param name="cReaders">The number of elements in the <c>rgReaderStates</c> array.</param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This service is especially useful when used in conjunction with SCardGetStatusChange. If no matching cards are found by means of
	/// <c>SCardLocateCards</c>, the calling application may use <c>SCardGetStatusChange</c> to wait for card availability changes.
	/// </para>
	/// <para>
	/// The <c>SCardLocateCards</c> function is a smart card tracking function. For more information on other tracking functions, see Smart
	/// Card Tracking Functions.
	/// </para>
	/// <para>
	/// Calling this function should be done outside of a transaction. If an application begins a transaction with the SCardBeginTransaction
	/// function and then calls this function, it resets the <c>hCard</c> parameter (of type <c>SCARDHANDLE</c>) of the
	/// <c>SCardBeginTransaction</c> function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2008 R2 and Windows 7:</c> Calling this function within a transaction could result in your computer becoming unresponsive.
	/// </para>
	/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> Not applicable.</para>
	/// <para>Examples</para>
	/// <para>The following example shows locating smart cards.</para>
	/// <para>
	/// <code>// Copyright (C) Microsoft. All rights reserved. #include &lt;stdio.h&gt; #include &lt;winscard.h&gt; #include &lt;tchar.h&gt; #pragma comment(lib, "winscard.lib") HRESULT __cdecl main() { HRESULT hr = S_OK; LPTSTR szReaders, szRdr; DWORD cchReaders = SCARD_AUTOALLOCATE; DWORD dwI, dwRdrCount; SCARD_READERSTATE rgscState[MAXIMUM_SMARTCARD_READERS]; TCHAR szCard[MAX_PATH]; SCARDCONTEXT hSC; LONG lReturn; // Establish the card to watch for. // Multiple cards can be looked for, but // this sample looks for only one card. _tcscat_s ( szCard, MAX_PATH * sizeof(TCHAR), TEXT("GemSAFE")); szCard[lstrlen(szCard) + 1] = 0; // Double trailing zero. // Establish a context. lReturn = SCardEstablishContext(SCARD_SCOPE_USER, NULL, NULL, &amp;hSC ); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardEstablishContext\n"); exit(1); } // Determine which readers are available. lReturn = SCardListReaders(hSC, NULL, (LPTSTR)&amp;szReaders, &amp;cchReaders ); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardListReaders\n"); exit(1); } // Place the readers into the state array. szRdr = szReaders; for ( dwI = 0; dwI &lt; MAXIMUM_SMARTCARD_READERS; dwI++ ) { if ( 0 == *szRdr ) break; rgscState[dwI].szReader = szRdr; rgscState[dwI].dwCurrentState = SCARD_STATE_UNAWARE; szRdr += lstrlen(szRdr) + 1; } dwRdrCount = dwI; // If any readers are available, proceed. if ( 0 != dwRdrCount ) { for (;;) { // Look for the card. lReturn = SCardLocateCards(hSC, szCard, rgscState, dwRdrCount ); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardLocateCards\n"); exit(1); } // Look through the array of readers. for ( dwI=0; dwI &lt; dwRdrCount; dwI++) { if ( 0 != ( SCARD_STATE_ATRMATCH &amp; rgscState[dwI].dwEventState)) { _tprintf( TEXT("Card '%s' found in reader '%s'.\n"), szCard, rgscState[dwI].szReader ); SCardFreeMemory( hSC, szReaders ); return 0; // Context will be release automatically. } // Update the state. rgscState[dwI].dwCurrentState = rgscState[dwI].dwEventState; } // Card not found yet; wait until there is a change. lReturn = SCardGetStatusChange(hSC, INFINITE, // infinite wait rgscState, dwRdrCount ); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardGetStatusChange\n"); exit(1); } } // for (;;) } else printf("No readers available\n"); // Release the context. lReturn = SCardReleaseContext(hSC); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardReleaseContext\n"); exit(1); } SCardFreeMemory( hSC, szReaders ); return hr; }</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardLocateCards as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardlocatecardsa LONG SCardLocateCardsA( [in] SCARDCONTEXT
	// hContext, [in] LPCSTR mszCards, [in, out] LPSCARD_READERSTATEA rgReaderStates, [in] DWORD cReaders );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardLocateCardsA")]
	public static extern SCARD_RET SCardLocateCards([In] SCARDCONTEXT hContext, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")] string[] mszCards,
		[In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] SCARD_READERSTATE[] rgReaderStates, [In] uint cReaders);

	/// <summary>
	/// The <c>SCardLocateCardsByATR</c> function searches the readers listed in the <c>rgReaderStates</c> parameter for a card with a name
	/// that matches one of the card names contained in one of the SCARD_ATRMASK structures specified by the <c>rgAtrMasks</c> parameter.
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context. The resource manager context is set by a previous call to SCardEstablishContext.
	/// </param>
	/// <param name="rgAtrMasks">Array of SCARD_ATRMASK structures that contain the names of the cards for which to search.</param>
	/// <param name="cAtrs">Number of elements in the <c>rgAtrMasks</c> array.</param>
	/// <param name="rgReaderStates">Array of SCARD_READERSTATE structures that specify the readers to search, and receive the result.</param>
	/// <param name="cReaders">Number of elements in the <c>rgReaderStates</c> array.</param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>Error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This service is especially useful when used in conjunction with SCardGetStatusChange. If no matching cards are found by means of
	/// SCardLocateCards, the calling application may use <c>SCardGetStatusChange</c> to wait for card availability changes.
	/// </para>
	/// <para>
	/// The <c>SCardLocateCardsByATR</c> function is a smart card tracking function. For information about other tracking functions, see
	/// Smart Card Tracking Functions.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardLocateCardsByATR as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardlocatecardsbyatra LONG SCardLocateCardsByATRA( [in]
	// SCARDCONTEXT hContext, [in] LPSCARD_ATRMASK rgAtrMasks, [in] DWORD cAtrs, [in, out] LPSCARD_READERSTATEA rgReaderStates, [in] DWORD
	// cReaders );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardLocateCardsByATRA")]
	public static extern SCARD_RET SCardLocateCardsByATR([In] SCARDCONTEXT hContext, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] SCARD_ATRMASK[] rgAtrMasks,
		[In] uint cAtrs, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] SCARD_READERSTATE[] rgReaderStates, [In] uint cReaders);

	/// <summary>
	/// The <c>SCardReadCache</c> function retrieves the value portion of a name-value pair from the global cache maintained by the Smart
	/// Card Resource Manager.
	/// </summary>
	/// <param name="hContext">
	/// A handle that identifies the resource manager context. The resource manager context is set by a previous call to SCardEstablishContext.
	/// </param>
	/// <param name="CardIdentifier">
	/// A pointer to a value that uniquely identifies a smart card. The name-value pair that this function reads from the global cache is
	/// associated with this smart card.
	/// </param>
	/// <param name="FreshnessCounter">The current revision of the cached data.</param>
	/// <param name="LookupName">
	/// A pointer to a null-terminated string that contains the name portion of the name-value pair for which to retrieve the value portion.
	/// </param>
	/// <param name="Data">
	/// A pointer to an array of byte values that contain the value portion of the name-value pair specified by the <c>LookupName</c> parameter.
	/// </param>
	/// <param name="DataLen">A pointer to the size, in bytes, of the <c>Data</c> buffer.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>SCARD_S_SUCCESS</c>.</para>
	/// <para>If the function fails, it returns one of the following error codes. For more information, see Smart Card Return Values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_W_CACHE_ITEM_NOT_FOUND</c> 0x80100070</term>
	/// <term>The specified name-value pair was not found in the global cache.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_W_CACHE_ITEM_STALE</c> 0x80100071</term>
	/// <term>The specified name-value pair was older than requested and has been deleted from the cache.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardReadCache as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardreadcachea LONG SCardReadCacheA( [in] SCARDCONTEXT
	// hContext, [in] UUID *CardIdentifier, [in] DWORD FreshnessCounter, [in] LPSTR LookupName, [out] PBYTE Data, [out] DWORD *DataLen );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardReadCacheA")]
	public static extern SCARD_RET SCardReadCache([In] SCARDCONTEXT hContext, in Guid CardIdentifier, [In] uint FreshnessCounter,
		[In] SafeLPTSTR LookupName, [Out] IntPtr Data, out uint DataLen);

	/// <summary>
	/// The <c>SCardReconnect</c> function reestablishes an existing connection between the calling application and a smart card. This
	/// function moves a card handle from direct access to general access, or acknowledges and clears an error condition that is preventing
	/// further access to the card.
	/// </summary>
	/// <param name="hCard">Reference value obtained from a previous call to SCardConnect.</param>
	/// <param name="dwShareMode">
	/// <para>Flag that indicates whether other applications may form connections to this card.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_SHARE_SHARED</c></term>
	/// <term>This application will share this card with other applications.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_SHARE_EXCLUSIVE</c></term>
	/// <term>This application will not share this card with other applications.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwPreferredProtocols">
	/// <para>Bitmask of acceptable protocols for this connection. Possible values may be combined with the <c>OR</c> operation.</para>
	/// <para>
	/// The value of this parameter should include the current protocol. Attempting to reconnect with a protocol other than the current
	/// protocol will result in an error.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_PROTOCOL_T0</c></term>
	/// <term>T=0 is an acceptable protocol.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_PROTOCOL_T1</c></term>
	/// <term>T=1 is an acceptable protocol.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwInitialization">
	/// <para>Type of initialization that should be performed on the card.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_LEAVE_CARD</c></term>
	/// <term>Do not do anything special on reconnect.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_RESET_CARD</c></term>
	/// <term>Reset the card (Warm Reset).</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_UNPOWER_CARD</c></term>
	/// <term>Power down the card and reset it (Cold Reset).</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pdwActiveProtocol">
	/// <para>Flag that indicates the established active protocol.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_PROTOCOL_T0</c></term>
	/// <term>T=0 is the active protocol.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_PROTOCOL_T1</c></term>
	/// <term>T=1 is the active protocol.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SCardReconnect</c> is a smart card and reader access function. For information about other access functions, see Smart Card and
	/// Reader Access Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows reestablishing a connection.</para>
	/// <para>
	/// <code>DWORD dwAP; LONG lReturn; // Reconnect. // hCardHandle was set by a previous call to SCardConnect. lReturn = SCardReconnect(hCardHandle, SCARD_SHARE_SHARED, SCARD_PROTOCOL_T0 | SCARD_PROTOCOL_T1, SCARD_LEAVE_CARD, &amp;dwAP ); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardReconnect\n");</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardreconnect LONG SCardReconnect( [in] SCARDHANDLE hCard,
	// [in] DWORD dwShareMode, [in] DWORD dwPreferredProtocols, [in] DWORD dwInitialization, [out, optional] LPDWORD pdwActiveProtocol );
	[DllImport(Lib_Winscard, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardReconnect")]
	public static extern SCARD_RET SCardReconnect([In] SCARDHANDLE hCard, [In] SCARD_SHARE dwShareMode, [In] SCARD_PROTOCOL dwPreferredProtocols,
		[In] SCARD_ACTION dwInitialization, out SCARD_PROTOCOL pdwActiveProtocol);

	/// <summary>
	/// The <c>SCardReleaseContext</c> function closes an established resource manager context, freeing any resources allocated under that
	/// context, including SCARDHANDLE objects and memory allocated using the SCARD_AUTOALLOCATE length designator.
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context. The resource manager context is set by a previous call to SCardEstablishContext.
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardreleasecontext LONG SCardReleaseContext( [in]
	// SCARDCONTEXT hContext );
	[DllImport(Lib_Winscard, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardReleaseContext")]
	public static extern SCARD_RET SCardReleaseContext([In] SCARDCONTEXT hContext);

	/// <summary>
	/// The <c>SCardReleaseStartedEvent</c> function decrements the reference count for a handle acquired by a previous call to the
	/// SCardAccessStartedEvent function.
	/// </summary>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardreleasestartedevent void SCardReleaseStartedEvent();
	[DllImport(Lib_Winscard, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardReleaseStartedEvent")]
	public static extern void SCardReleaseStartedEvent();

	/// <summary>
	/// The <c>SCardRemoveReaderFromGroup</c> function removes a reader from an existing reader group. This function has no effect on the reader.
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context. The resource manager context is set by a previous call to SCardEstablishContext.
	/// This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szReaderName">Display name of the reader to be removed.</param>
	/// <param name="szGroupName">
	/// <para>Display name of the group from which the reader should be removed.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_ALL_READERS</c> TEXT("SCard$AllReaders\000")</term>
	/// <term>
	/// Group used when no group name is provided when listing readers. Returns a list of all readers, regardless of what group or groups the
	/// readers are in.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_DEFAULT_READERS</c> TEXT("SCard$DefaultReaders\000")</term>
	/// <term>Default group to which all readers are added when introduced into the system.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_LOCAL_READERS</c> TEXT("SCard$LocalReaders\000")</term>
	/// <term>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_SYSTEM_READERS</c> TEXT("SCard$SystemReaders\000")</term>
	/// <term>
	/// Unused legacy value. This is an internally managed group that cannot be modified by using any reader group APIs. It is intended to be
	/// used for enumeration only.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>When the last reader is removed from a group, the group is automatically forgotten.</para>
	/// <para>
	/// The <c>SCardRemoveReaderFromGroup</c> function is a database management function. For information about other database management
	/// functions, see Smart Card Database Management Functions.
	/// </para>
	/// <para>To add a reader to a reader group, use SCardAddReaderToGroup.</para>
	/// <para>Examples</para>
	/// <para>The following example shows how to remove a reader from the group.</para>
	/// <para>
	/// <code>// Remove a reader from the group. // lReturn is of type LONG. // hContext was set by a previous call to SCardEstablishContext. // The group is automatically forgotten if no readers remain in it. lReturn = SCardRemoveReaderFromGroup(hContext, L"MyReader", L"MyReaderGroup"); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardRemoveReaderFromGroup\n");</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardRemoveReaderFromGroup as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardremovereaderfromgroupa LONG SCardRemoveReaderFromGroupA(
	// [in] SCARDCONTEXT hContext, [in] LPCSTR szReaderName, [in] LPCSTR szGroupName );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardRemoveReaderFromGroupA")]
	public static extern SCARD_RET SCardRemoveReaderFromGroup([In] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szReaderName, [MarshalAs(UnmanagedType.LPTStr)] string szGroupName);

	/// <summary>
	/// The <c>SCardSetAttrib</c> function sets the given reader attribute for the given handle. It does not affect the state of the reader,
	/// reader driver, or smart card. Not all attributes are supported by all readers (nor can they be set at all times) as many of the
	/// attributes are under direct control of the transport protocol.
	/// </summary>
	/// <param name="hCard">Reference value returned from SCardConnect.</param>
	/// <param name="dwAttrId">
	/// <para>Identifier for the attribute to set. The values are write-only. Note that vendors may not support all attributes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_ATTR_SUPRESS_T1_IFS_REQUEST</c></term>
	/// <term>
	/// Suppress sending of T=1 IFSD packet from the reader to the card. (Can be used if the currently inserted card does not support an IFSD request.)
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbAttr">Pointer to a buffer that supplies the attribute whose ID is supplied in <c>dwAttrId</c>.</param>
	/// <param name="cbAttrLen">Length (in bytes) of the attribute value in the <c>pbAttr</c> buffer.</param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SCardSetAttrib</c> function is a direct card access function. For information about other direct access functions, see Direct
	/// Card Access Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows how to set an attribute.</para>
	/// <para>
	/// <code>// Set the attribute. // hCardHandle was set by a previous call to SCardConnect. // dwAttrID is a DWORD value, specifying the attribute ID. // pbAttr points to the buffer of the new value. // cByte is the count of bytes in the buffer. lReturn = SCardSetAttrib(hCardHandle, dwAttrID, (LPBYTE)pbAttr, cByte); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardSetAttrib\n");</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardsetattrib LONG SCardSetAttrib( [in] SCARDHANDLE hCard,
	// [in] DWORD dwAttrId, [in] LPCBYTE pbAttr, [in] DWORD cbAttrLen );
	[DllImport(Lib_Winscard, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardSetAttrib")]
	public static extern SCARD_RET SCardSetAttrib([In] SCARDHANDLE hCard, [In] uint dwAttrId, [In] IntPtr pbAttr, [In] uint cbAttrLen);

	/// <summary>
	/// The <c>SCardSetCardTypeProviderName</c> function specifies the name of the module (dynamic link library) containing the provider for
	/// a given card name and provider type.
	/// </summary>
	/// <param name="hContext">
	/// Handle that identifies the resource manager context. The resource manager context can be set by a previous call to
	/// SCardEstablishContext. This value can be <c>NULL</c> if the call to <c>SCardSetCardTypeProviderName</c> is not directed to a specific context.
	/// </param>
	/// <param name="szCardName">Name of the card type with which this provider name is associated.</param>
	/// <param name="dwProviderId">
	/// <para>Identifier for the provider associated with this card type.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_PROVIDER_PRIMARY</c> 1</term>
	/// <term>The function retrieves the name of the smart card's primary service provider as a GUID string.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_PROVIDER_CSP</c> 2</term>
	/// <term>The function retrieves the name of the cryptographic service provider (CSP).</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_PROVIDER_KSP</c> 3</term>
	/// <term>The function retrieves the name of the smart card key storage provider (KSP).</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_PROVIDER_CARD_MODULE</c> 0x80000001</term>
	/// <term>The function retrieves the name of the card module.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szProvider">A string that contains the provider name that is representing the CSP.</param>
	/// <returns>
	/// <para>This function returns different values depending on whether it succeeds or fails.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>Success</c></term>
	/// <term>SCARD_S_SUCCESS.</term>
	/// </item>
	/// <item>
	/// <term><c>Failure</c></term>
	/// <term>An error code. For more information, see Smart Card Return Values.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is not redirected, but calling the function when inside a Remote Desktop session will not result in an error. It only
	/// means that the result will be from the remote computer instead of the local computer.
	/// </para>
	/// <para>This function sets the provider name, while SCardGetCardTypeProviderName can be used to retrieve the provider name.</para>
	/// <para>Examples</para>
	/// <para>The following example shows how to specify the card type provider name.</para>
	/// <para>
	/// <code>LPTSTR szNewProvName = _T("My Provider Name"); LPTSTR szCardName = _T("WindowsCard"); LONG lReturn = SCARD_S_SUCCESS; // Set the card type provider name. // hContext was set by SCardEstablishContext. lReturn = SCardSetCardTypeProviderName(hContext, szCardName, SCARD_PROVIDER_CSP, szNewProvName); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardSetCardTypeProviderName - %x\n", lReturn); exit(1); }</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardSetCardTypeProviderName as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardsetcardtypeprovidernamea LONG
	// SCardSetCardTypeProviderNameA( [in] SCARDCONTEXT hContext, [in] LPCSTR szCardName, [in] DWORD dwProviderId, [in] LPCSTR szProvider );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardSetCardTypeProviderNameA")]
	public static extern SCARD_RET SCardSetCardTypeProviderName([In, Optional] SCARDCONTEXT hContext, [MarshalAs(UnmanagedType.LPTStr)] string szCardName, [In] SCARD_PROVIDER dwProviderId,
		[MarshalAs(UnmanagedType.LPTStr)] string szProvider);

	/// <summary>
	/// The <c>SCardStatus</c> function provides the current status of a smart card in a reader. You can call it any time after a successful
	/// call to SCardConnect and before a successful call to SCardDisconnect. It does not affect the state of the reader or reader driver.
	/// </summary>
	/// <param name="hCard">Reference value returned from SCardConnect.</param>
	/// <param name="mszReaderNames">List of display names (multiple string) by which the currently connected reader is known.</param>
	/// <param name="pcchReaderLen">
	/// <para>On input, supplies the length of the <c>szReaderName</c> buffer.</para>
	/// <para>
	/// On output, receives the actual length (in characters) of the reader name list, including the trailing <c>NULL</c> character. If this
	/// buffer length is specified as SCARD_AUTOALLOCATE, then <c>szReaderName</c> is converted to a pointer to a byte pointer, and it
	/// receives the address of a block of memory that contains the multiple-string structure.
	/// </para>
	/// </param>
	/// <param name="pdwState">
	/// <para>Current state of the smart card in the reader. Upon success, it receives one of the following state indicators.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_ABSENT</c></term>
	/// <term>There is no card in the reader.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_PRESENT</c></term>
	/// <term>There is a card in the reader, but it has not been moved into position for use.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_SWALLOWED</c></term>
	/// <term>There is a card in the reader in position for use. The card is not powered.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_POWERED</c></term>
	/// <term>Power is being provided to the card, but the reader driver is unaware of the mode of the card.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_NEGOTIABLE</c></term>
	/// <term>The card has been reset and is awaiting PTS negotiation.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_SPECIFIC</c></term>
	/// <term>The card has been reset and specific communication protocols have been established.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pdwProtocol">
	/// <para>Current protocol, if any. The returned value is meaningful only if the returned value of <c>pdwState</c> is SCARD_SPECIFICMODE.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_PROTOCOL_RAW</c></term>
	/// <term>The Raw Transfer protocol is in use.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_PROTOCOL_T0</c></term>
	/// <term>The ISO 7816/3 T=0 protocol is in use.</term>
	/// </item>
	/// <item>
	/// <term><c>SCARD_PROTOCOL_T1</c></term>
	/// <term>The ISO 7816/3 T=1 protocol is in use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbAtr">Pointer to a 32-byte buffer that receives the ATR string from the currently inserted card, if available.</param>
	/// <param name="pcbAtrLen">
	/// On input, supplies the length of the <c>pbAtr</c> buffer. On output, receives the number of bytes in the ATR string (32 bytes
	/// maximum). If this buffer length is specified as SCARD_AUTOALLOCATE, then <c>pbAtr</c> is converted to a pointer to a byte pointer,
	/// and it receives the address of a block of memory that contains the multiple-string structure.
	/// </param>
	/// <returns>
	/// <para>If the function successfully provides the current status of a smart card in a reader, the return value is SCARD_S_SUCCESS.</para>
	/// <para>If the function fails, it returns an error code. For more information, see Smart Card Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SCardStatus</c> function is a smart card and reader access function. For information about other access functions, see Smart
	/// Card and Reader Access Functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows how to determine the state of the smart card.</para>
	/// <para>
	/// <code>WCHAR szReader[200]; DWORD cch = 200; BYTE bAttr[32]; DWORD cByte = 32; DWORD dwState, dwProtocol; LONG lReturn; // Determine the status. // hCardHandle was set by an earlier call to SCardConnect. lReturn = SCardStatus(hCardHandle, szReader, &amp;cch, &amp;dwState, &amp;dwProtocol, (LPBYTE)&amp;bAttr, &amp;cByte); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardStatus\n"); exit(1); // or other appropriate action } // Examine retrieved status elements. // Look at the reader name and card state. printf("%S\n", szReader ); switch ( dwState ) { case SCARD_ABSENT: printf("Card absent.\n"); break; case SCARD_PRESENT: printf("Card present.\n"); break; case SCARD_SWALLOWED: printf("Card swallowed.\n"); break; case SCARD_POWERED: printf("Card has power.\n"); break; case SCARD_NEGOTIABLE: printf("Card reset and waiting PTS negotiation.\n"); break; case SCARD_SPECIFIC: printf("Card has specific communication protocols set.\n"); break; default: printf("Unknown or unexpected card state.\n"); break; }</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardStatus as an alias which automatically selects the ANSI or Unicode version of this function based
	/// on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardstatusa LONG SCardStatusA( [in] SCARDHANDLE hCard, [out]
	// LPSTR mszReaderNames, [in, out, optional] LPDWORD pcchReaderLen, [out, optional] LPDWORD pdwState, [out, optional] LPDWORD
	// pdwProtocol, [out] LPBYTE pbAtr, [in, out, optional] LPDWORD pcbAtrLen );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardStatusA")]
	public static extern SCARD_RET SCardStatus([In] SCARDHANDLE hCard, [Out][MarshalAs(UnmanagedType.LPTStr)] StringBuilder mszReaderNames, ref uint pcchReaderLen,
		out uint pdwState, out SCARD_PROTOCOL pdwProtocol, [Out] IntPtr pbAtr, ref uint pcbAtrLen);

	/// <summary>
	/// The <c>SCardTransmit</c> function sends a service request to the smart card and expects to receive data back from the card.
	/// </summary>
	/// <param name="hCard">A reference value returned from the SCardConnect function.</param>
	/// <param name="pioSendPci">
	/// <para>
	/// A pointer to the protocol header structure for the instruction. This buffer is in the format of an SCARD_IO_REQUEST structure,
	/// followed by the specific protocol control information (PCI).
	/// </para>
	/// <para>
	/// For the T=0, T=1, and Raw protocols, the PCI structure is constant. The smart card subsystem supplies a global T=0, T=1, or Raw PCI
	/// structure, which you can reference by using the symbols SCARD_PCI_T0, SCARD_PCI_T1, and SCARD_PCI_RAW respectively.
	/// </para>
	/// </param>
	/// <param name="pbSendBuffer">
	/// <para>A pointer to the actual data to be written to the card.</para>
	/// <para>For T=0, the data parameters are placed into the address pointed to by <c>pbSendBuffer</c> according to the following structure:</para>
	/// <para>
	/// The data sent to the card should immediately follow the send buffer. In the special case where no data is sent to the card and no
	/// data is expected in return, <c>bP3</c> is not sent.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Member</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c><c>bCla</c></c></term>
	/// <term>The T=0 instruction class.</term>
	/// </item>
	/// <item>
	/// <term><c><c>bIns</c></c></term>
	/// <term>An instruction code in the T=0 instruction class.</term>
	/// </item>
	/// <item>
	/// <term><c><c>bP1</c>, <c>bP2</c></c></term>
	/// <term>Reference codes that complete the instruction code.</term>
	/// </item>
	/// <item>
	/// <term><c><c>bP3</c></c></term>
	/// <term>The number of data bytes to be transmitted during the command, per ISO 7816-4, Section 8.2.1.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="cbSendLength">
	/// <para>The length, in bytes, of the <c>pbSendBuffer</c> parameter.</para>
	/// <para>
	/// For T=0, in the special case where no data is sent to the card and no data expected in return, this length must reflect that the
	/// <c>bP3</c> member is not being sent; the length should be
	/// <code>sizeof(CmdBytes) - sizeof(BYTE)</code>
	/// .
	/// </para>
	/// </param>
	/// <param name="pioRecvPci">
	/// Pointer to the protocol header structure for the instruction, followed by a buffer in which to receive any returned protocol control
	/// information (PCI) specific to the protocol in use. This parameter can be <c>NULL</c> if no PCI is returned.
	/// </param>
	/// <param name="pbRecvBuffer">
	/// <para>Pointer to any data returned from the card.</para>
	/// <para>
	/// For T=0, the data is immediately followed by the SW1 and SW2 status bytes. If no data is returned from the card, then this buffer
	/// will only contain the SW1 and SW2 status bytes.
	/// </para>
	/// </param>
	/// <param name="pcbRecvLength">
	/// <para>
	/// Supplies the length, in bytes, of the <c>pbRecvBuffer</c> parameter and receives the actual number of bytes received from the smart card.
	/// </para>
	/// <para>This value cannot be SCARD_AUTOALLOCATE because <c>SCardTransmit</c> does not support SCARD_AUTOALLOCATE.</para>
	/// <para>For T=0, the receive buffer must be at least two bytes long to receive the SW1 and SW2 status bytes.</para>
	/// </param>
	/// <returns>
	/// <para>If the function successfully sends a service request to the smart card, the return value is SCARD_S_SUCCESS.</para>
	/// <para>If the function fails, it returns an error code. For more information, see Smart Card Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SCardTransmit</c> function is a smart card and reader access function. For information about other access functions, see Smart
	/// Card and Reader Access Functions.
	/// </para>
	/// <para>
	/// For the T=0 protocol, the data received back are the SW1 and SW2 status codes, possibly preceded by response data. The following
	/// paragraphs provide information about the send and receive buffers used to transfer data and issue a command.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows sending a service request to the smart card.</para>
	/// <para>
	/// <code>// Transmit the request. // lReturn is of type LONG. // hCardHandle was set by a previous call to SCardConnect. // pbSend points to the buffer of bytes to send. // dwSend is the DWORD value for the number of bytes to send. // pbRecv points to the buffer for returned bytes. // dwRecv is the DWORD value for the number of returned bytes. lReturn = SCardTransmit(hCardHandle, SCARD_PCI_T0, pbSend, dwSend, NULL, pbRecv, &amp;dwRecv ); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardTransmit\n"); exit(1); // or other appropriate error action }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardtransmit LONG SCardTransmit( [in] SCARDHANDLE hCard, [in]
	// LPCSCARD_IO_REQUEST pioSendPci, [in] LPCBYTE pbSendBuffer, [in] DWORD cbSendLength, [in, out, optional] LPSCARD_IO_REQUEST pioRecvPci,
	// [out] LPBYTE pbRecvBuffer, [in, out] LPDWORD pcbRecvLength );
	[DllImport(Lib_Winscard, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardTransmit")]
	public static extern SCARD_RET SCardTransmit([In] SCARDHANDLE hCard, [In] IntPtr /*SCARD_IO_REQUEST*/ pioSendPci, [In] IntPtr pbSendBuffer, [In] uint cbSendLength,
		[In, Out, Optional] IntPtr /*SCARD_IO_REQUEST*/ pioRecvPci, [Out] IntPtr pbRecvBuffer, ref uint pcbRecvLength);

	/// <summary>The <c>SCardUIDlgSelectCard</c> function displays the smart card <c>Select Card</c> dialog box.</summary>
	/// <param name="unnamedParam1">Pointer to the OPENCARDNAME_EX structure for the <c>Select Card</c> dialog box.</param>
	/// <returns>
	/// <para>If the function successfully displays the <c>Select Card</c> dialog box, the return value is SCARD_S_SUCCESS.</para>
	/// <para>If the function fails, it returns an error code. For more information, see Smart Card Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SCardUIDlgSelectCard</c> function provides a method for connecting to a specific smart card. When called, this function
	/// performs a search for appropriate smart cards matching the OPENCARD_SEARCH_CRITERIA member specified by the <c>pDlgStruc</c>
	/// parameter. Depending on the <c>dwFlags</c> member of <c>pDlgStruc</c>, this function takes the following actions.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Action</term>
	/// </listheader>
	/// <item>
	/// <term>SC_DLG_FORCE_UI</term>
	/// <term>Connects to the card selected by the user from the smart card <c>Select Card</c> dialog box.</term>
	/// </item>
	/// <item>
	/// <term>SC_DLG_MINIMAL_UI</term>
	/// <term>
	/// Selects the smart card if only one smart card meets the criteria, or returns information about the user's selection if more than one
	/// smart card meets the criteria.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SC_DLG_NO_UI</term>
	/// <term>Selects the first available card.</term>
	/// </item>
	/// </list>
	/// <para>
	/// This function replaces GetOpenCardName. The <c>GetOpenCardName</c> function is maintained for backward compatibility with version 1.0
	/// of the Microsoft Smart Card Base Components.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows how to display the smart card <c>Select Card</c> dialog box.</para>
	/// <para>
	/// <code>SCARDCONTEXT hSC; OPENCARDNAME_EX dlgStruct; WCHAR szReader[256]; WCHAR szCard[256]; LONG lReturn; // Establish a context. // It will be assigned to the structure's hSCardContext field. lReturn = SCardEstablishContext(SCARD_SCOPE_USER, NULL, NULL, &amp;hSC ); if ( SCARD_S_SUCCESS != lReturn ) { printf("Failed SCardEstablishContext\n"); exit(1); } // Initialize the structure. memset(&amp;dlgStruct, 0, sizeof(dlgStruct)); dlgStruct.dwStructSize = sizeof(dlgStruct); dlgStruct.hSCardContext = hSC; dlgStruct.dwFlags = SC_DLG_FORCE_UI; dlgStruct.lpstrRdr = (LPSTR) szReader; dlgStruct.nMaxRdr = 256; dlgStruct.lpstrCard = (LPSTR) szCard; dlgStruct.nMaxCard = 256; dlgStruct.lpstrTitle = (LPSTR) "My Select Card Title"; // Display the select card dialog box. lReturn = SCardUIDlgSelectCard(&amp;dlgStruct); if ( SCARD_S_SUCCESS != lReturn ) printf("Failed SCardUIDlgSelectCard - %x\n", lReturn ); else printf("Reader: %S\nCard: %S\n", szReader, szCard ); // Release the context (by SCardReleaseContext - not shown here).</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardUIDlgSelectCard as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scarduidlgselectcarda LONG SCardUIDlgSelectCardA( [in]
	// LPOPENCARDNAMEA_EX unnamedParam1 );
	[DllImport(Lib_Scarddlg, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardUIDlgSelectCardA")]
	public static extern SCARD_RET SCardUIDlgSelectCard(in OPENCARDNAME_EX unnamedParam1);

	/// <summary>
	/// The <c>SCardWriteCache</c> function writes a name-value pair from a smart card to the global cache maintained by the Smart Card
	/// Resource Manager.
	/// </summary>
	/// <param name="hContext">
	/// A handle that identifies the resource manager context. The resource manager context is set by a previous call to SCardEstablishContext.
	/// </param>
	/// <param name="CardIdentifier">A pointer to a value that uniquely identifies the smart card from which the name-value pair was read.</param>
	/// <param name="FreshnessCounter">The current revision of the cached data.</param>
	/// <param name="LookupName">
	/// A pointer to a null-terminated string that contains the name portion of the name-value pair to write to the global cache.
	/// </param>
	/// <param name="Data">
	/// A pointer to an array of byte values that contain the value portion of the name-value pair to write to the global cache.
	/// </param>
	/// <param name="DataLen">The size, in bytes, of the <c>Data</c> buffer.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>SCARD_S_SUCCESS</c>.</para>
	/// <para>If the function fails, it returns one of the following error codes. For more information, see Smart Card Return Values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCARD_W_CACHE_ITEM_TOO_BIG</c> 0x80100072</term>
	/// <term>The size of the specified name-value pair exceeds the maximum size defined for the global cache.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCardWriteCache as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardwritecachea LONG SCardWriteCacheA( [in] SCARDCONTEXT
	// hContext, [in] UUID *CardIdentifier, [in] DWORD FreshnessCounter, [in] LPSTR LookupName, [in] PBYTE Data, [in] DWORD DataLen );
	[DllImport(Lib_Winscard, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winscard.h", MSDNShortId = "NF:winscard.SCardWriteCacheA")]
	public static extern SCARD_RET SCardWriteCache([In] SCARDCONTEXT hContext, in Guid CardIdentifier, [In] uint FreshnessCounter,
		[MarshalAs(UnmanagedType.LPTStr)] string LookupName, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] Data, [In] uint DataLen);

	private static SCARD_RET ListSCardFunc<T>(SCardListCardsDelegate d, out T[] msz)
	{
		msz = new T[0];
		uint cch = 0;
		SCARD_RET ret = d(default, ref cch);
		if (ret.Failed) return ret;
		using SafeCoTaskMemHandle ptr = new(Len(cch));
		ret = d(ptr, ref cch);
		if (ret.Succeeded)
			msz = typeof(T) == typeof(string) ? (T[])(object)ptr.ToStringEnum().ToArray() : ptr.ToArray<T>((int)cch);
		return ret;

		static int Len(uint cch) => typeof(T) == typeof(string) ? (1 + (int)cch) * Marshal.SystemDefaultCharSize : InteropExtensions.SizeOf<T>() * cch;
	}

	/// <summary>
	/// The <c>OPENCARD_SEARCH_CRITERIA</c> structure is used by the SCardUIDlgSelectCard function in order to recognize cards that meet the
	/// requirements set forth by the caller. You can, however, call <c>SCardUIDlgSelectCard</c> without using this structure.
	/// </summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines OPENCARD_SEARCH_CRITERIA as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/ns-winscard-opencard_search_criteriaa typedef struct { DWORD dwStructSize;
	// LPSTR lpstrGroupNames; DWORD nMaxGroupNames; LPCGUID rgguidInterfaces; DWORD cguidInterfaces; LPSTR lpstrCardNames; DWORD
	// nMaxCardNames; LPOCNCHKPROC lpfnCheck; LPOCNCONNPROCA lpfnConnect; LPOCNDSCPROC lpfnDisconnect; LPVOID pvUserData; DWORD dwShareMode;
	// DWORD dwPreferredProtocols; } OPENCARD_SEARCH_CRITERIAA, *POPENCARD_SEARCH_CRITERIAA, *LPOPENCARD_SEARCH_CRITERIAA;
	[PInvokeData("winscard.h", MSDNShortId = "NS:winscard.__unnamed_struct_2")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct OPENCARD_SEARCH_CRITERIA
	{
		/// <summary>The length, in bytes, of the structure. Must not be <c>NULL</c>.</summary>
		public uint dwStructSize;

		/// <summary>
		/// A pointer to a buffer containing null-terminated group name strings. The last string in the buffer must be terminated by two null
		/// characters. Each string is the name of a group of cards that is to be included in the search. If <c>lpstrGroupNames</c> is
		/// <c>NULL</c>, the default group (Scard$DefaultReaders) is searched.
		/// </summary>
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")]
		public string[]? lpstrGroupNames;

		/// <summary>The maximum number of bytes (ANSI version) or characters (Unicode version) in the <c>lpstrGroupNames</c> string.</summary>
		public uint nMaxGroupNames;

		/// <summary>Reserved for future use. An array of GUIDs that identifies the interfaces required. Set this member to <c>NULL</c>.</summary>
		public IntPtr rgguidInterfaces;

		/// <summary>Reserved for future use. The number of interfaces in the <c>rgguidInterfaces</c> array. Set this member to <c>NULL</c>.</summary>
		public uint cguidInterfaces;

		/// <summary>
		/// A pointer to a buffer that contains null-terminated card name strings. The last string in the buffer must be terminated by two
		/// null characters. Each string is the name of a card that is to be located.
		/// </summary>
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")]
		public string[] lpstrCardNames;

		/// <summary>The maximum number of bytes (ANSI version) or characters (Unicode version) in the <c>lpstrGroupNames</c> string.</summary>
		public uint nMaxCardNames;

		/// <summary>
		/// <para>
		/// A pointer to the caller's card verify routine. If no special card verification is required, this pointer is <c>NULL</c>. If the
		/// card is rejected by the verify routine, <c>FALSE</c> is returned, and the card will be disconnected. If the card is accepted by
		/// the verify routine, <c>TRUE</c> is returned.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LPOCNCHKPROC? lpfnCheck;

		/// <summary>
		/// <para>
		/// A pointer to the caller's card connect routine. If the caller needs to perform additional processing to connect to the card, this
		/// function pointer is set to the user's connect function. If the connect function is successful, the card is left connected and
		/// initialized, and the card handle is returned.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LPOCNCONNPROC? lpfnConnect;

		/// <summary>
		/// <para>A pointer to the caller's card disconnect routine.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LPOCNDSCPROC lpfnDisconnect;

		/// <summary>Void pointer to user data. This pointer is passed back to the caller on the Connect, Check, and Disconnect routines.</summary>
		public IntPtr pvUserData;

		/// <summary>
		/// If <c>lpfnConnect</c> is not <c>NULL</c>, the <c>dwShareMode</c> and <c>dwPreferredProtocols</c> members are ignored. If
		/// <c>lpfnConnect</c> is <c>NULL</c> and <c>dwShareMode</c> is nonzero, an internal call is made to SCardConnect that uses
		/// <c>dwShareMode</c> and <c>dwPreferredProtocols</c> as the parameter.
		/// </summary>
		public SCARD_SHARE dwShareMode;

		/// <summary>Used for internal connection as described in <c>dwShareMode</c>.</summary>
		public SCARD_PROTOCOL dwPreferredProtocols;
	}

	/// <summary>
	/// The <c>OPENCARDNAME</c> structure contains the information that the GetOpenCardName function uses to initialize a smart card
	/// <c>Select Card</c> dialog box. Calling SCardUIDlgSelectCard with OPENCARDNAME_EX is recommended over calling GetOpenCardName with
	/// <c>OPENCARDNAME</c>. <c>OPENCARDNAME</c> is provided for backward compatibility.
	/// </summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines OPENCARDNAME as an alias which automatically selects the ANSI or Unicode version of this function based
	/// on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/ns-winscard-opencardnamea typedef struct { DWORD dwStructSize; HWND
	// hwndOwner; SCARDCONTEXT hSCardContext; LPSTR lpstrGroupNames; DWORD nMaxGroupNames; LPSTR lpstrCardNames; DWORD nMaxCardNames; LPCGUID
	// rgguidInterfaces; DWORD cguidInterfaces; LPSTR lpstrRdr; DWORD nMaxRdr; LPSTR lpstrCard; DWORD nMaxCard; LPCSTR lpstrTitle; DWORD
	// dwFlags; LPVOID pvUserData; DWORD dwShareMode; DWORD dwPreferredProtocols; DWORD dwActiveProtocol; LPOCNCONNPROCA lpfnConnect;
	// LPOCNCHKPROC lpfnCheck; LPOCNDSCPROC lpfnDisconnect; SCARDHANDLE hCardHandle; } OPENCARDNAMEA, *POPENCARDNAMEA, *LPOPENCARDNAMEA;
	[PInvokeData("winscard.h", MSDNShortId = "NS:winscard.__unnamed_struct_8")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct OPENCARDNAME
	{
		/// <summary>Specifies the length, in bytes, of the structure. This member must not be <c>NULL</c>.</summary>
		public uint dwStructSize;

		/// <summary>
		/// The window that owns the dialog box. This member can be any valid window handle, or it can be <c>NULL</c> for desktop default.
		/// </summary>
		public HWND hwndOwner;

		/// <summary>
		/// The context used for communication with the smart card resource manager. Call SCardEstablishContext to set the resource manager
		/// context and SCardReleaseContext to release it. This member must not be <c>NULL</c>.
		/// </summary>
		public SCARDCONTEXT hSCardContext;

		/// <summary>
		/// A pointer to a buffer that contains null-terminated group name strings. The last string in the buffer must be terminated by two
		/// null characters. Each string is the name of a group of cards that is to be included in the search. If <c>lpstrGroupNames</c> is
		/// <c>NULL</c>, the default group (Scard$DefaultReaders) is searched.
		/// </summary>
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")]
		public string[]? lpstrGroupNames;

		/// <summary>The maximum number of bytes (ANSI version) or characters (Unicode version) in the <c>lpstrGroupNames</c> string.</summary>
		public uint nMaxGroupNames;

		/// <summary>
		/// A pointer to a buffer that contains null-terminated card name strings. The last string in the buffer must be terminated by two
		/// null characters. Each string is the name of a card that is to be located.
		/// </summary>
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")]
		public string[] lpstrCardNames;

		/// <summary>The maximum number of bytes (ANSI version) or characters (Unicode version) in the <c>lpstrCardNames</c> string.</summary>
		public uint nMaxCardNames;

		/// <summary>Reserved for future use. Set to <c>NULL</c>. An array of GUIDs that identify the interfaces required.</summary>
		public IntPtr rgguidInterfaces;

		/// <summary>Reserved for futures use. Set to <c>NULL</c>. The number of interfaces in the <c>rgguidInterfaces</c> array.</summary>
		public uint cguidInterfaces;

		/// <summary>
		/// If the card is located, the <c>lpstrRdr</c> buffer contains the name of the reader that contains the located card. The buffer
		/// should be at least 256 characters long.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpstrRdr;

		/// <summary>
		/// The size, in bytes (ANSI version) or characters (Unicode version), of the buffer pointed to by <c>lpstrRdr</c>. If the buffer is
		/// too small to contain the reader information, GetOpenCardName returns SCARD_E_NO_MEMORY and the required size of the buffer
		/// pointed to by <c>lpstrRdr</c>.
		/// </summary>
		public uint nMaxRdr;

		/// <summary>
		/// If the card is located, the <c>lpstrCard</c> buffer contains the name of the located card. The buffer should be at least 256
		/// characters long.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpstrCard;

		/// <summary>
		/// The size, in bytes (ANSI version) or characters (Unicode version), of the buffer pointed to by <c>lpstrCard</c>. If the buffer is
		/// too small to contain the card information, GetOpenCardName returns SCARD_E_NO_MEMORY and the required size of the buffer in <c>nMaxCard</c>.
		/// </summary>
		public uint nMaxCard;

		/// <summary>
		/// A pointer to a string to be placed in the title bar of the dialog box. If this member is <c>NULL</c>, the system uses the default
		/// title "Select Card:".
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpstrTitle;

		/// <summary>
		/// <para>
		/// A set of bit flags you can use to initialize the dialog box. When the dialog box returns, it sets these flags to indicate the
		/// input of the user. This member can be a combination of the following flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SC_DLG_MINIMAL_UI</c></term>
		/// <term>
		/// Displays the dialog box only if the card being searched for by the calling application is not located and available for use in a
		/// reader. This allows the card to be found, connected (either through the internal dialog box mechanism or the user callback
		/// functions), and returned to the calling application.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SC_DLG_NO_UI</c></term>
		/// <term>Force no display of the <c>Select Card</c> user interface (UI), regardless of search outcome.</term>
		/// </item>
		/// <item>
		/// <term><c>SC_DLG_FORCE_UI</c></term>
		/// <term>Force display of the <c>Select Card</c> UI, regardless of the search outcome.</term>
		/// </item>
		/// </list>
		/// </summary>
		public SC_DLG dwFlags;

		/// <summary>A void pointer to user data. This pointer is passed back to the caller on the Connect, Check, and Disconnect routines.</summary>
		public IntPtr pvUserData;

		/// <summary>
		/// <para>If <c>lpfnConnect</c> is not <c>NULL</c>, the <c>dwShareMode</c> and <c>dwPreferredProtocols</c> members are ignored.</para>
		/// <para>
		/// If <c>lpfnConnect</c> is <c>NULL</c> and <c>dwShareMode</c> is nonzero, then an internal call is made to SCardConnect that uses
		/// <c>dwShareMode</c> and <c>dwPreferredProtocols</c> as the <c>dwShareMode</c> and <c>dwPreferredProtocols</c> parameters. If the
		/// connect succeeds, <c>hCardHandle</c> is set to the handle returned by <c>hSCardConnect</c>.
		/// </para>
		/// <para>If <c>lpfnConnect</c> is <c>NULL</c> and <c>dwShareMode</c> is zero, the dialog box returns <c>hCardHandle</c> as <c>NULL</c>.</para>
		/// </summary>
		public SCARD_SHARE dwShareMode;

		/// <summary>Used for internal connection as described in <c>dwShareMode</c>.</summary>
		public SCARD_PROTOCOL dwPreferredProtocols;

		/// <summary>Returns the actual protocol in use when the dialog box makes a connection to a card.</summary>
		public SCARD_PROTOCOL dwActiveProtocol;

		/// <summary>
		/// <para>
		/// A pointer to the card connect routine of the caller. If the caller needs to perform additional processing to connect to the card,
		/// this function pointer is set to the connect function for the user. If the connect function is successful, the card is left
		/// connected and initialized, and the card handle is returned.
		/// </para>
		/// <para>The prototype for the connect routine is as follows.</para>
		/// </summary>
		public LPOCNCONNPROC? lpfnConnect;

		/// <summary>
		/// <para>A pointer to the card verify routine of the caller. If no special card verification is required, this pointer is <c>NULL</c>.</para>
		/// <para>If the card is rejected by the verify routine, <c>FALSE</c> is returned and the card is disconnected, as indicated by <c>lpfnDisconnect</c>.</para>
		/// <para>
		/// If the card is accepted by the verify routine, <c>TRUE</c> is returned. When the user accepts the card, all other cards currently
		/// connected will be disconnected, as indicated by <c>lpfnDisconnect</c>, and this card will be returned as the located card. The
		/// located card will remain connected.
		/// </para>
		/// <para>The prototype for the check routine is as follows.</para>
		/// </summary>
		public LPOCNCHKPROC? lpfnCheck;

		/// <summary>
		/// <para>A pointer to the card disconnect routine of the caller.</para>
		/// <para>The prototype for the disconnect routine is as follows.</para>
		/// </summary>
		public LPOCNDSCPROC lpfnDisconnect;

		/// <summary>
		/// <c>Note</c> When using <c>lpfnConnect</c>, <c>lpfnCheck</c>, and <c>lpfnDisconnect</c>, all three callback procedures should be
		/// present. Using these callbacks allows further verification that the calling application has found the appropriate card. This is
		/// the best way to ensure the appropriate card is selected.
		/// </summary>
		/// <summary>A handle of the connected card (either through an internal dialog box connect or an <c>lpfnConnect</c> callback).</summary>
		public SCARDHANDLE hCardHandle;
	}

	/// <summary>
	/// The <c>OPENCARDNAME_EX</c> structure contains the information that the SCardUIDlgSelectCard function uses to initialize a smart card
	/// <c>Select Card</c> dialog box.
	/// </summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines OPENCARDNAME_EX as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/ns-winscard-opencardname_exa typedef struct { DWORD dwStructSize;
	// SCARDCONTEXT hSCardContext; HWND hwndOwner; DWORD dwFlags; LPCSTR lpstrTitle; LPCSTR lpstrSearchDesc; HICON hIcon;
	// POPENCARD_SEARCH_CRITERIAA pOpenCardSearchCriteria; LPOCNCONNPROCA lpfnConnect; LPVOID pvUserData; DWORD dwShareMode; DWORD
	// dwPreferredProtocols; LPSTR lpstrRdr; DWORD nMaxRdr; LPSTR lpstrCard; DWORD nMaxCard; DWORD dwActiveProtocol; SCARDHANDLE hCardHandle;
	// } OPENCARDNAME_EXA, *POPENCARDNAME_EXA, *LPOPENCARDNAME_EXA;
	[PInvokeData("winscard.h", MSDNShortId = "NS:winscard.__unnamed_struct_4")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct OPENCARDNAME_EX
	{
		/// <summary>The length, in bytes, of the structure. The value of this member must not be <c>NULL</c>.</summary>
		public uint dwStructSize;

		/// <summary>
		/// The context used for communication with the smart card resource manager. Call SCardEstablishContext to set the resource manager
		/// context and SCardReleaseContext to release it. The value of this member must not be <c>NULL</c>.
		/// </summary>
		public SCARDCONTEXT hSCardContext;

		/// <summary>
		/// The window that owns the dialog box. This member can be any valid window handle, or it can be <c>NULL</c> for the desktop default.
		/// </summary>
		public HWND hwndOwner;

		/// <summary>
		/// <para>
		/// A set of bit flags that you can use to initialize the dialog box. When the dialog box returns, it sets these flags to indicate
		/// the user's input. This member can be one of the following flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SC_DLG_MINIMAL_UI</c></term>
		/// <term>
		/// Display the dialog box only if the card being searched for by the calling application is not located and available for use in a
		/// reader. This allows the card to be found, connected (either through the internal dialog box mechanism or the user callback
		/// functions), and returned to the calling application.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SC_DLG_NO_UI</c></term>
		/// <term>Force no display of the <c>Select Card</c> user interface (UI), regardless of search outcome.</term>
		/// </item>
		/// <item>
		/// <term><c>SC_DLG_FORCE_UI</c></term>
		/// <term>Force display of the <c>Select Card</c> UI, regardless of the search outcome.</term>
		/// </item>
		/// </list>
		/// </summary>
		public SC_DLG dwFlags;

		/// <summary>
		/// A pointer to a string to be placed in the title bar of the dialog box. If this member is <c>NULL</c>, the system uses the default
		/// title "Select Card:".
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpstrTitle;

		/// <summary>
		/// A pointer to a string to be displayed to the user as a prompt to insert the smart card. If this member is <c>NULL</c>, the system
		/// uses the default text "Please insert a smart card".
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpstrSearchDesc;

		/// <summary>
		/// A handle to an icon (32 x 32 pixels). You can specify a vendor-specific icon to display in the dialog box. If this value is
		/// <c>NULL</c>, a generic, smart card reader–loaded icon is displayed.
		/// </summary>
		public HICON hIcon;

		/// <summary>A pointer to the <see cref="OPENCARD_SEARCH_CRITERIA"/> structure to be used, or <c>NULL</c>, if one is not used.</summary>
		public IntPtr pOpenCardSearchCriteria;

		/// <summary>
		/// <para>
		/// A pointer to the caller's card connect routine. If the caller needs to perform additional processing to connect to the card, this
		/// function pointer is set to the user's connect function. If the connect function is successful, the card is left connected and
		/// initialized, and the card handle is returned.
		/// </para>
		/// <para>The prototype for the connect routine is as follows.</para>
		/// </summary>
		public LPOCNCONNPROC lpfnConnect;

		/// <summary>A void pointer to user data. This pointer is passed back to the caller on the Connect routine.</summary>
		public IntPtr pvUserData;

		/// <summary>
		/// If <c>lpfnConnect</c> is not <c>NULL</c>, the <c>dwShareMode</c> and <c>dwPreferredProtocols</c> members are ignored. If
		/// <c>lpfnConnect</c> is <c>NULL</c> and <c>dwShareMode</c> is nonzero, an internal call is made to SCardConnect that uses
		/// <c>dwShareMode</c> and <c>dwPreferredProtocols</c> as the <c>dwShareMode</c> and <c>dwPreferredProtocols</c> parameters. If the
		/// connect succeeds, <c>hCardHandle</c> is set to the handle returned by <c>SCardConnect</c>. If <c>lpfnConnect</c> is <c>NULL</c>
		/// and <c>dwShareMode</c> is zero, <c>hCardHandle</c> is set to <c>NULL</c>.
		/// </summary>
		public SCARD_SHARE dwShareMode;

		/// <summary>Used for internal connection as described in <c>dwShareMode</c>.</summary>
		public SCARD_PROTOCOL dwPreferredProtocols;

		/// <summary>
		/// If the card is located, the <c>lpstrRdr</c> buffer contains the name of the reader that contains the located card. The buffer
		/// should be at least 256 characters long.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpstrRdr;

		/// <summary>
		/// Size, in bytes (ANSI version) or characters (Unicode version), of the buffer pointed to by <c>lpstrRdr</c>. If the buffer is too
		/// small to contain the reader information, SCardUIDlgSelectCard returns SCARD_E_NO_MEMORY and the required size of the buffer
		/// pointed to by <c>lpstrRdr</c>.
		/// </summary>
		public uint nMaxRdr;

		/// <summary>
		/// If the card is located, the <c>lpstrCard</c> buffer contains the name of the located card. The buffer should be at least 256
		/// characters long.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpstrCard;

		/// <summary>
		/// Size, in bytes (ANSI version) or characters (Unicode version), of the buffer pointed to by <c>lpstrCard</c>. If the buffer is too
		/// small to contain the card information, SCardUIDlgSelectCard returns SCARD_E_NO_MEMORY and the required size of the buffer in <c>nMaxCard</c>.
		/// </summary>
		public uint nMaxCard;

		/// <summary>The actual protocol in use when the dialog box makes a connection to a card.</summary>
		public SCARD_PROTOCOL dwActiveProtocol;

		/// <summary>A handle of the connected card (either through an internal dialog box connect or an <c>lpfnConnect</c> callback).</summary>
		public SCARDHANDLE hCardHandle;
	}

	/// <summary>The <c>SCARD_ATRMASK</c> structure is used by the SCardLocateCardsByATR function to locate cards.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/ns-winscard-scard_atrmask typedef struct _SCARD_ATRMASK { DWORD cbAtr;
	// BYTE rgbAtr[36]; BYTE rgbMask[36]; } SCARD_ATRMASK, *PSCARD_ATRMASK, *LPSCARD_ATRMASK;
	[PInvokeData("winscard.h", MSDNShortId = "NS:winscard._SCARD_ATRMASK")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCARD_ATRMASK
	{
		/// <summary>The number of bytes in the ATR and the mask.</summary>
		public uint cbAtr;

		/// <summary>An array of <c>BYTE</c> values for the ATR of the card with extra alignment bytes.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
		public byte[] rgbAtr;

		/// <summary>An array of <c>BYTE</c> values for the mask for the ATR with extra alignment bytes.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
		public byte[] rgbMask;
	}

	/// <summary>The <c>SCARD_READERSTATE</c> structure is used by functions for tracking smart cards within readers.</summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The winscard.h header defines SCARD_READERSTATE as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winscard/ns-winscard-scard_readerstatea typedef struct { LPCSTR szReader; LPVOID
	// pvUserData; DWORD dwCurrentState; DWORD dwEventState; DWORD cbAtr; BYTE rgbAtr[36]; } SCARD_READERSTATEA, *PSCARD_READERSTATEA, *LPSCARD_READERSTATEA;
	[PInvokeData("winscard.h", MSDNShortId = "NS:winscard.__unnamed_struct_0")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct SCARD_READERSTATE
	{
		/// <summary>
		/// <para>A pointer to the name of the reader being monitored.</para>
		/// <para>
		/// Set the value of this member to "\\?PnP?\Notification" and the values of all other members to zero to be notified of the arrival
		/// of a new smart card reader.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string szReader;

		/// <summary>Not used by the smart card subsystem. This member is used by the application.</summary>
		public IntPtr pvUserData;

		/// <summary>
		/// <para>
		/// Current state of the reader, as seen by the application. This field can take on any of the following values, in combination, as a bitmask.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SCARD_STATE_UNAWARE</c></term>
		/// <term>
		/// The application is unaware of the current state, and would like to know. The use of this value results in an immediate return
		/// from state transition monitoring services. This is represented by all bits set to zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_IGNORE</c></term>
		/// <term>
		/// The application is not interested in this reader, and it should not be considered during monitoring operations. If this bit value
		/// is set, all other bits are ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_UNAVAILABLE</c></term>
		/// <term>
		/// The application expects that this reader is not available for use. If this bit is set, then all the following bits are ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_EMPTY</c></term>
		/// <term>The application expects that there is no card in the reader. If this bit is set, all the following bits are ignored.</term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_PRESENT</c></term>
		/// <term>The application expects that there is a card in the reader.</term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_ATRMATCH</c></term>
		/// <term>
		/// The application expects that there is a card in the reader with an ATR that matches one of the target cards. If this bit is set,
		/// SCARD_STATE_PRESENT is assumed. This bit has no meaning to SCardGetStatusChange beyond SCARD_STATE_PRESENT.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_EXCLUSIVE</c></term>
		/// <term>
		/// The application expects that the card in the reader is allocated for exclusive use by another application. If this bit is set,
		/// SCARD_STATE_PRESENT is assumed.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_INUSE</c></term>
		/// <term>
		/// The application expects that the card in the reader is in use by one or more other applications, but may be connected to in
		/// shared mode. If this bit is set, SCARD_STATE_PRESENT is assumed.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_MUTE</c></term>
		/// <term>The application expects that there is an unresponsive card in the reader.</term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_UNPOWERED</c></term>
		/// <term>This implies that the card in the reader has not been powered up.</term>
		/// </item>
		/// </list>
		/// </summary>
		public SCARD_STATE dwCurrentState;

		/// <summary>
		/// <para>
		/// Current state of the reader, as known by the smart card resource manager. This field can take on any of the following values, in
		/// combination, as a bitmask.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SCARD_STATE_IGNORE</c></term>
		/// <term>This reader should be ignored.</term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_CHANGED</c></term>
		/// <term>
		/// There is a difference between the state believed by the application, and the state known by the resource manager. When this bit
		/// is set, the application may assume a significant state change has occurred on this reader.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_UNKNOWN</c></term>
		/// <term>
		/// The given reader name is not recognized by the resource manager. If this bit is set, then SCARD_STATE_CHANGED and
		/// SCARD_STATE_IGNORE will also be set.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_UNAVAILABLE</c></term>
		/// <term>The actual state of this reader is not available. If this bit is set, then all the following bits are clear.</term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_EMPTY</c></term>
		/// <term>There is no card in the reader. If this bit is set, all the following bits will be clear.</term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_PRESENT</c></term>
		/// <term>There is a card in the reader.</term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_ATRMATCH</c></term>
		/// <term>
		/// There is a card in the reader with an ATR matching one of the target cards. If this bit is set, SCARD_STATE_PRESENT will also be
		/// set. This bit is only returned on the SCardLocateCards function.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_EXCLUSIVE</c></term>
		/// <term>
		/// The card in the reader is allocated for exclusive use by another application. If this bit is set, SCARD_STATE_PRESENT will also
		/// be set.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_INUSE</c></term>
		/// <term>
		/// The card in the reader is in use by one or more other applications, but may be connected to in shared mode. If this bit is set,
		/// SCARD_STATE_PRESENT will also be set.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_MUTE</c></term>
		/// <term>There is an unresponsive card in the reader.</term>
		/// </item>
		/// <item>
		/// <term><c>SCARD_STATE_UNPOWERED</c></term>
		/// <term>This implies that the card in the reader has not been powered up.</term>
		/// </item>
		/// </list>
		/// </summary>
		public SCARD_STATE dwEventState;

		/// <summary>Number of bytes in the returned ATR.</summary>
		public uint cbAtr;

		/// <summary>ATR of the inserted card, with extra alignment bytes.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
		public byte[] rgbAtr;
	}

	/// <summary>Provides a handle to a smartcard.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct SCARDHANDLE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="SCARDHANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public SCARDHANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="SCARDHANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static SCARDHANDLE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(SCARDHANDLE h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="SCARDHANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(SCARDHANDLE h) => h.handle;

		/// <summary>Performs an explicit conversion from <see cref="SCARDHANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator UIntPtr(SCARDHANDLE h) => h.handle.ToUIntPtr();

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="SCARDHANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SCARDHANDLE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(SCARDHANDLE h1, SCARDHANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(SCARDHANDLE h1, SCARDHANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is SCARDHANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="SCARDHANDLE"/> that is disposed using <see cref="SCardDisconnect"/>.</summary>
	public class SafeSCARDHANDLE : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeSCARDHANDLE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeSCARDHANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeSCARDHANDLE"/> class.</summary>
		private SafeSCARDHANDLE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeSCARDHANDLE"/> to <see cref="SCARDHANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SCARDHANDLE(SafeSCARDHANDLE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => SCardDisconnect(handle, SCARD_ACTION.SCARD_LEAVE_CARD).Succeeded;
	}
}