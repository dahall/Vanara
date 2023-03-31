using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>
	/// Called by AutoPlay. Exposes methods that get dynamic information regarding a registered handler prior to displaying it to the user.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Prior to this interface, when an application registered a handler and was displayed in the autoplay prompt, the handler was
	/// always shown as long as the content type (for example, mp3 or avi) associated with that handler was found on the media device.
	/// The same icon and action string were always displayed.
	/// </para>
	/// <para>
	/// If a handler implements this interface prior to showing the handler, AutoPlay will first call IDynamicHWHandler::GetDynamicInfo
	/// to determine if this handler is to be presented to the user. If you want to show the handler, you may specify a different action
	/// string than the one supplied by the static handler registration under <c>HKLM</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-idynamichwhandler
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IDynamicHWHandler")]
	[ComImport, Guid("DC2601D7-059E-42fc-A09D-2AFD21B6D5F7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDynamicHWHandler
	{
		/// <summary>Called by the system to determine whether a particular handler will be shown before the AutoPlay dialog is displayed.</summary>
		/// <param name="pszDeviceID">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a string that indicates the device path or drive root.</para>
		/// </param>
		/// <param name="dwContentType">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The content type.</para>
		/// </param>
		/// <param name="ppszAction">
		/// <para>Type: <c>LPWSTR*</c></para>
		/// <para>A pointer to the new action string, or <c>NULL</c> if the default action string is to be used.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if this handler is to be displayed, S_FALSE if it is to be hidden, or an error value otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To register a dynamic handler, add a REG_SZ named "DynamicHWHandlerCLSID" and assign it the CLSID of your IDynamicHWHandler implementation.
		/// </para>
		/// <para>Example:</para>
		/// <para>
		/// <c>HKLM</c><c>Software</c><c>Microsoft</c><c>Windows</c><c>CurrentVersion</c><c>Explorer</c><c>AutoplayHandlers</c><c>Handlers</c><c>YourHandler</c><c>DynamicHWHandlerCLSID</c>
		/// = [REG_SZ] {xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-idynamichwhandler-getdynamicinfo HRESULT
		// GetDynamicInfo( LPCWSTR pszDeviceID, DWORD dwContentType, LPWSTR *ppszAction );
		[PreserveSig]
		HRESULT GetDynamicInfo([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceID, uint dwContentType, out StrPtrUni ppszAction);
	}

	/// <summary>Called by AutoPlay to implement the handling of registered media types.</summary>
	/// <remarks>
	/// <para>Developers supporting this interface must expose it in a Component Object Model (COM) server.</para>
	/// <para>
	/// All applications registered as AutoPlay media handlers must implement this interface. Handlers that implement this interface
	/// should return quickly from calls to IHWEventHandler::HandleEvent and IHWEventHandler2::HandleEventWithHWND so they won't block
	/// the AutoPlay dialog from closing. Additionally, if a local server must be launched for the creation of this handler, it should
	/// not block the CreateInstance call; it should return as soon as possible.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-ihweventhandler
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IHWEventHandler")]
	[ComImport, Guid("C1FB73D0-EC3A-4ba2-B512-8CDB9187B6D1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IHWEventHandler
	{
		/// <summary>Initializes an object that contains an implementation of the IHWEventHandler interface.</summary>
		/// <param name="pszParams">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a string buffer that contains the string from the following registry value.</para>
		/// <para>
		/// <c>HKEY_LOCAL_MACHINE</c><c>Software</c><c>Microsoft</c><c>Windows</c><c>CurrentVersion</c><c>Explorer</c><c>AutoPlayHandlers</c><c>Handlers</c>
		/// HandlerName <c>InitCmdLine</c> = string
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>This method receives the registry string stored in the InitCmdLine value under the</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ihweventhandler-initialize HRESULT Initialize(
		// LPCWSTR pszParams );
		[PreserveSig]
		HRESULT Initialize([MarshalAs(UnmanagedType.LPWStr)] string pszParams);

		/// <summary>Handles AutoPlay device events for which there is no content of the type the application is registered to handle.</summary>
		/// <param name="pszDeviceID">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a string buffer that contains the device ID.</para>
		/// </param>
		/// <param name="pszAltDeviceID">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>
		/// A pointer to a string buffer that contains the alternate device ID. The alternate device ID is more human-readable than the
		/// primary device ID.
		/// </para>
		/// </param>
		/// <param name="pszEventType">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>
		/// A pointer to a string buffer that contains the event type. The event types include DeviceArrival, DeviceRemoval,
		/// MediaArrival, and MediaRemoval.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The event types are not C/C++ language constants; they are literal text strings.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ihweventhandler-handleevent HRESULT HandleEvent(
		// LPCWSTR pszDeviceID, LPCWSTR pszAltDeviceID, LPCWSTR pszEventType );
		[PreserveSig]
		HRESULT HandleEvent([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceID,
			[MarshalAs(UnmanagedType.LPWStr)] string pszAltDeviceID,
			[MarshalAs(UnmanagedType.LPWStr)] string pszEventType);

		/// <summary>Not implemented.</summary>
		/// <param name="pszDeviceID">This parameter is unused.</param>
		/// <param name="pszAltDeviceID">This parameter is unused.</param>
		/// <param name="pszEventType">This parameter is unused.</param>
		/// <param name="pszContentTypeHandler">This parameter is unused.</param>
		/// <param name="pdataobject">This parameter is unused.</param>
		/// <returns>This method does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ihweventhandler-handleeventwithcontent HRESULT
		// HandleEventWithContent( LPCWSTR pszDeviceID, LPCWSTR pszAltDeviceID, LPCWSTR pszEventType, LPCWSTR pszContentTypeHandler,
		// IDataObject *pdataobject );
		[PreserveSig]
		HRESULT HandleEventWithContent([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceID,
			[MarshalAs(UnmanagedType.LPWStr)] string pszAltDeviceID,
			[MarshalAs(UnmanagedType.LPWStr)] string pszEventType,
			[MarshalAs(UnmanagedType.LPWStr)] string pszContentTypeHandler,
			IDataObject pdataobject);
	}

	/// <summary>Extends the IHWEventHandler interface to address User Account Control (UAC) elevation for device handlers.</summary>
	/// <remarks>
	/// <para>This interface also provides the methods of the IHWEventHandler interface, from which it inherits.</para>
	/// <para>
	/// Handlers that implement this interface should return quickly from calls to IHWEventHandler::HandleEvent and
	/// IHWEventHandler2::HandleEventWithHWND so they do not block the AutoPlay dialog from closing. Also, if a local server must be
	/// launched for the creation of this handler, it should not block the CreateInstance call; it should return as soon as possible.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-ihweventhandler2
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IHWEventHandler2")]
	[ComImport, Guid("CFCC809F-295D-42e8-9FFC-424B33C487E6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IHWEventHandler2 : IHWEventHandler
	{
		/// <summary>Initializes an object that contains an implementation of the IHWEventHandler interface.</summary>
		/// <param name="pszParams">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a string buffer that contains the string from the following registry value.</para>
		/// <para>
		/// <c>HKEY_LOCAL_MACHINE</c><c>Software</c><c>Microsoft</c><c>Windows</c><c>CurrentVersion</c><c>Explorer</c><c>AutoPlayHandlers</c><c>Handlers</c>
		/// HandlerName <c>InitCmdLine</c> = string
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>This method receives the registry string stored in the InitCmdLine value under the</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ihweventhandler-initialize HRESULT Initialize(
		// LPCWSTR pszParams );
		[PreserveSig]
		new HRESULT Initialize([MarshalAs(UnmanagedType.LPWStr)] string pszParams);

		/// <summary>Handles AutoPlay device events for which there is no content of the type the application is registered to handle.</summary>
		/// <param name="pszDeviceID">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a string buffer that contains the device ID.</para>
		/// </param>
		/// <param name="pszAltDeviceID">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>
		/// A pointer to a string buffer that contains the alternate device ID. The alternate device ID is more human-readable than the
		/// primary device ID.
		/// </para>
		/// </param>
		/// <param name="pszEventType">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>
		/// A pointer to a string buffer that contains the event type. The event types include DeviceArrival, DeviceRemoval,
		/// MediaArrival, and MediaRemoval.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The event types are not C/C++ language constants; they are literal text strings.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ihweventhandler-handleevent HRESULT HandleEvent(
		// LPCWSTR pszDeviceID, LPCWSTR pszAltDeviceID, LPCWSTR pszEventType );
		[PreserveSig]
		new HRESULT HandleEvent([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceID,
			[MarshalAs(UnmanagedType.LPWStr)] string pszAltDeviceID,
			[MarshalAs(UnmanagedType.LPWStr)] string pszEventType);

		/// <summary>Not implemented.</summary>
		/// <param name="pszDeviceID">This parameter is unused.</param>
		/// <param name="pszAltDeviceID">This parameter is unused.</param>
		/// <param name="pszEventType">This parameter is unused.</param>
		/// <param name="pszContentTypeHandler">This parameter is unused.</param>
		/// <param name="pdataobject">This parameter is unused.</param>
		/// <returns>This method does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ihweventhandler-handleeventwithcontent HRESULT
		// HandleEventWithContent( LPCWSTR pszDeviceID, LPCWSTR pszAltDeviceID, LPCWSTR pszEventType, LPCWSTR pszContentTypeHandler,
		// IDataObject *pdataobject );
		[PreserveSig]
		new HRESULT HandleEventWithContent([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceID,
			[MarshalAs(UnmanagedType.LPWStr)] string pszAltDeviceID,
			[MarshalAs(UnmanagedType.LPWStr)] string pszEventType,
			[MarshalAs(UnmanagedType.LPWStr)] string pszContentTypeHandler,
			IDataObject pdataobject);

		/// <summary>
		/// Handles AutoPlay device events that contain content types that the application is not registered to handle. This method
		/// provides a handle to the owner window so that UI can be displayed if the process requires elevated privileges.
		/// </summary>
		/// <param name="pszDeviceID">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a string buffer that contains the device ID.</para>
		/// </param>
		/// <param name="pszAltDeviceID">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>
		/// A pointer to a string buffer that contains the alternate device ID. The alternate device ID is more human-readable than the
		/// primary device ID.
		/// </para>
		/// </param>
		/// <param name="pszEventType">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>
		/// A pointer to a string buffer that contains the event type. The event types include DeviceArrival, DeviceRemoval,
		/// MediaArrival, and MediaRemoval.
		/// </para>
		/// </param>
		/// <param name="hwndOwner">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the AutoPlay dialog that was displayed.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When a handler is invoked and requires immediate privilege elevation in a new process, it requires an active parent window
		/// handle to display its consent UI. IHWEventHandler::HandleEvent cannot give a handle, so only a blinking taskbar appears.
		/// <c>IHWEventHandler2::HandleEventWithHWND</c> provides the HWND and enables the UI to be displayed.
		/// </para>
		/// <para>
		/// Note that if the handler was launched by default instead of by direct user action, the HWND is not active and the dialog is
		/// not shown in the foreground.
		/// </para>
		/// <para>The event types are not C/C++ language constants; they are literal text strings.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ihweventhandler2-handleeventwithhwnd HRESULT
		// HandleEventWithHWND( LPCWSTR pszDeviceID, LPCWSTR pszAltDeviceID, LPCWSTR pszEventType, HWND hwndOwner );
		[PreserveSig]
		HRESULT HandleEventWithHWND([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceID,
			[MarshalAs(UnmanagedType.LPWStr)] string pszAltDeviceID,
			[MarshalAs(UnmanagedType.LPWStr)] string pszEventType,
			HWND hwndOwner);
	}

	/// <summary>
	/// Exposes a method that programmatically overrides AutoPlay or AutoRun. This allows you to customize the location and type of
	/// content that is launched when media is inserted.
	/// </summary>
	/// <remarks>
	/// <para>
	/// <c>Note</c><c>IQueryCancelAutoPlay</c> is intended only for use by user-launched applications that are currently running. It
	/// should not be handled by invisible or background service applications to prevent the normal AutoPlay/AutoRun feature from being
	/// invoked. Giving the user a choice of what happens when media and devices are inserted into the system is a key feature of the
	/// platform. This feature is designed specifically to improve and personalize the user experience and should not be inhibited by
	/// background services.
	/// </para>
	/// <para>
	/// A valid use of <c>IQueryCancelAutoPlay</c> is illustrated in the following scenario: Assume that you have, through AutoPlay,
	/// previously designated application A to handle video camera events. For video editing, however, you prefer application B. You
	/// open application B, begin editing some previously filmed video, and then decide to add some new content to the video being
	/// edited. Application B's import function prompts you to turn on the video camera so that the new content can be accessed.
	/// Normally, this video device activation would trigger the launch of the device-associated application A. Fortunately, using
	/// <c>IQueryCancelAutoPlay</c>, application B has canceled AutoPlay processing of video camera events while you are editing video
	/// content. In this case, the cancellation of Autoplay by application B has created a better user experience.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-iquerycancelautoplay
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IQueryCancelAutoPlay")]
	[ComImport, Guid("DDEFE873-6997-4e68-BE26-39B633ADBE12"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IQueryCancelAutoPlay
	{
		/// <summary>Determines whether to play media inserted by a user and if so using what restrictions.</summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The drive letter in the form <c>D:\</c></para>
		/// </param>
		/// <param name="dwContentType">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The type of content as specified by the following flags.</para>
		/// <para>ARCONTENT_AUTORUNINF (0x00000002)</para>
		/// <para>Use the Autorun.inf file. This is the traditional AutoRun behavior.</para>
		/// <para>ARCONTENT_AUDIOCD (0x00000004)</para>
		/// <para>AutoRun audio CDs.</para>
		/// <para>ARCONTENT_DVDMOVIE (0x00000008)</para>
		/// <para>AutoRun DVDs.</para>
		/// <para>ARCONTENT_BLANKCD (0x00000010)</para>
		/// <para>AutoPlay blank CD-Rs and CD-RWs.</para>
		/// <para>ARCONTENT_BLANKDVD (0x00000020)</para>
		/// <para>AutoPlay blank DVD-Rs and DVD-RAMs.</para>
		/// <para>ARCONTENT_UNKNOWNCONTENT (0x00000040)</para>
		/// <para>AutoRun if the media is formatted and the content does not fall under a type covered by one of the other flags.</para>
		/// <para>ARCONTENT_AUTOPLAYPIX (0x00000080)</para>
		/// <para>AutoPlay if the content consists of file types defined as pictures, such as .bmp and .jpg files.</para>
		/// <para>ARCONTENT_AUTOPLAYMUSIC (0x00000100)</para>
		/// <para>AutoPlay if the content consists of file types defined as music, such as MP3 files.</para>
		/// <para>ARCONTENT_AUTOPLAYVIDEO (0x00000200)</para>
		/// <para>AutoPlay if the content consists of file types defined as video files.</para>
		/// <para>ARCONTENT_VCD (0x00000400)</para>
		/// <para><c>Introduced in Windows Vista</c>. AutoPlay video CDs (VCDs).</para>
		/// <para>ARCONTENT_SVCD (0x00000800)</para>
		/// <para><c>Introduced in Windows Vista</c>. AutoPlay Super Video CD (SVCD) media.</para>
		/// <para>ARCONTENT_DVDAUDIO (0x00001000)</para>
		/// <para><c>Introduced in Windows Vista</c>. AutoPlay DVD-Audio media.</para>
		/// <para>ARCONTENT_BLANKBD (0x00002000)</para>
		/// <para>AutoPlay blank recordable high definition DVD media in the Blu-ray Disc™ format (BD-R or BD-RW). Note: Prior to Windows 7, this value was defined to specify non-recordable media in the HD DVD format.</para>
		/// <para>ARCONTENT_BLURAY (0x00004000)</para>
		/// <para><c>Introduced in Windows Vista</c>. AutoPlay high definition DVD media in the Blu-ray Disc™ format.</para>
		/// <para>ARCONTENT_CAMERASTORAGE (0x00008000)</para>
		/// <para><c>Introduced in Windows 8</c>.</para>
		/// <para>ARCONTENT_CUSTOMEVENT (0x00010000)</para>
		/// <para><c>Introduced in Windows 8</c>.</para>
		/// <para>ARCONTENT_NONE (0x00000000)</para>
		/// <para><c>Introduced in Windows Vista</c>. AutoPlay empty but formatted media.</para>
		/// <para>ARCONTENT_MASK (0x0001FFFE)</para>
		/// <para><c>Introduced in Windows Vista</c>. A mask that denotes valid ARCONTENT flag values for media types. This mask does not include ARCONTENT_PHASE values.</para>
		/// <para>ARCONTENT_PHASE_UNKNOWN (0x00000000)</para>
		/// <para><c>Introduced in Windows Vista</c>. AutoPlay is searching the media. The phase of the search (presniff, sniffing, or final) is unknown.</para>
		/// <para>ARCONTENT_PHASE_PRESNIFF (0x10000000)</para>
		/// <para><c>Introduced in Windows Vista</c>. The contents of the media are known before the media is searched, due to the media type; for instance, audio CDs and DVD movies.</para>
		/// <para>ARCONTENT_PHASE_SNIFFING (0x20000000)</para>
		/// <para><c>Introduced in Windows Vista</c>. AutoPlay is currently searching the media. Any results reported during this phase should be considered a partial list as more content types might still be found.</para>
		/// <para>ARCONTENT_PHASE_FINAL (0x40000000)</para>
		/// <para><c>Introduced in Windows Vista</c>. AutoPlay has finished searching the media. Results reported are final.</para>
		/// <para>ARCONTENT_PHASE_MASK (0x70000000)</para>
		/// <para><c>Introduced in Windows Vista</c>. A mask that denotes valid ARCONTENT_PHASE values.</para>
		/// </param>
		/// <param name="pszLabel">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The media label.</para>
		/// </param>
		/// <param name="dwSerialNumber">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The media serial number.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK to allow AutoRun or S_FALSE to cancel AutoRun.</para>
		/// </returns>
		/// <remarks>
		/// <para>Applications register an instance of the IQueryCancelAutoPlay interface in the running object table (ROT). Before the Shell starts AutoRun or AutoPlay, when the user inserts new media, it checks the ROT for a component implementing <c>IQueryCancelAutoPlay</c>. If it finds one, the Shell calls that implementation's <c>IQueryCancelAutoPlay::AllowAutoPlay</c> method to determine whether it should proceed, and using what restrictions.</para>
		/// <para>Upon presentation of media, the Shell searches the ROT for a component implementing IQueryCancelAutoPlay. If one is found, the class identifier (CLSID) of that component's moniker is extracted. The presence of a ROT registration informs the Shell that the component might want to cancel AutoRun or AutoPlay. For confirmation, the Shell must also find a registry key for that same CLSID at the following location:</para>
		/// <para><code> &lt;pre xml:space="preserve"&gt;&lt;b&gt;HKEY_LOCAL_MACHINE&lt;/b&gt; </code></para>
		/// <para><c>SOFTWARE</c> <c>Microsoft</c> <c>Windows</c> <c>Current Version</c> <c>Explorer</c> <c>AutoplayHandlers</c> <c>CancelAutoplay</c> <c>CLSID</c> The component's CLSIDThis value is added by the application or hardware, usually at installation time. It isn't assigned a data value.</para>
		/// <para><c>Note</c> The CLSID entered as a value under this key should not be encased in curly brackets.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iquerycancelautoplay-allowautoplay
		// HRESULT AllowAutoPlay( LPCWSTR pszPath, DWORD dwContentType, LPCWSTR pszLabel, DWORD dwSerialNumber );
		[PreserveSig]
		HRESULT AllowAutoPlay([MarshalAs(UnmanagedType.LPWStr)] string pszPath, ARCONTENT dwContentType, [MarshalAs(UnmanagedType.LPWStr)] string pszLabel, uint dwSerialNumber);
	}

	/// <summary>
	/// Exposes a method that provides a simple, standard mechanism for objects to query a client for permission to continue an
	/// operation. Clients of IUserNotification, for example, must pass an implementation of <c>IQueryContinue</c> to the
	/// IUserNotification::Show method.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iquerycontinue
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IQueryContinue")]
	[ComImport, Guid("7307055c-b24a-486b-9f25-163e597a28a9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IQueryContinue
	{
		/// <summary>Returns <c>S_OK</c> if the operation associated with the current instance of this interface should continue.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns <c>S_OK</c> if the calling application should continue, <c>S_FALSE</c> if not.</para>
		/// </returns>
		/// <remarks>
		/// In typical usage, a pointer to an IQueryContinue interface is passed to a method of another object. That object, in turn,
		/// runs this method periodically to determine whether to continue its actions. For example, if a user clicks a cancel button,
		/// this method will start returning <c>S_FALSE</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iquerycontinue-querycontinue HRESULT QueryContinue();
		[PreserveSig]
		HRESULT QueryContinue();
	}

	/// <summary>
	/// <para>
	/// Exposes methods that set notification information and then display that notification to the user in a balloon that appears in
	/// conjunction with the notification area of the taskbar.
	/// </para>
	/// <para>
	/// <c>Note</c><c>IUserNotification2</c> does not inherit from IUserNotification. <c>IUserNotification2</c> differs from
	/// <c>IUserNotification</c> only in its Show method, which adds an additional parameter for a callback interface to communicate
	/// with the notification. Otherwise the two interfaces are identical in form and function. CLSID_UserNotification implements both
	/// versions of <c>Show</c> as an overload.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>When to Implement</para>
	/// <para>An implementation of this interface is provided in Windows as CLSID_UserNotification.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-iusernotification2
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IUserNotification2")]
	[ComImport, Guid("215913CC-57EB-4FAB-AB5A-E5FA7BEA2A6C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUserNotification2
	{
		/// <summary>Sets the information to be displayed in a balloon notification.</summary>
		/// <param name="pszTitle">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a Unicode string that specifies the title of the notification.</para>
		/// </param>
		/// <param name="pszText">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a Unicode string that specifies the text to be displayed in the body of the balloon.</para>
		/// </param>
		/// <param name="dwInfoFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>One or more of the following values that indicate an icon to display in the notification balloon.</para>
		/// <para>NIIF_NONE (0x00000000)</para>
		/// <para>0x00000000. Do not display an icon.</para>
		/// <para>NIIF_INFO (0x00000001)</para>
		/// <para>0x00000001. Display an information icon.</para>
		/// <para>NIIF_WARNING (0x00000002)</para>
		/// <para>0x00000002. Display a warning icon.</para>
		/// <para>NIIF_ERROR (0x00000003)</para>
		/// <para>0x00000003. Display an error icon.</para>
		/// <para>NIIF_USER (0x00000004)</para>
		/// <para>0x00000004. <c>Windows XP SP2 and later</c>. Use the icon identified in <c>hIcon</c> in the notification balloon.</para>
		/// <para>NIIF_NOSOUND (0x00000010)</para>
		/// <para>
		/// 0x00000010. <c>Windows XP and later</c>. Do not play the associated sound. This value applies only to balloon notifications
		/// and not to standard user notifications.
		/// </para>
		/// <para>NIIF_LARGE_ICON (0x00000010)</para>
		/// <para>
		/// 0x00000010. <c>Windows Vista and later</c>. The large version of the icon should be used as the icon in the notification
		/// balloon. This corresponds to the icon with dimensions SM_CXICON x SM_CYICON. If this flag is not set, the icon with
		/// dimensions XM_CXSMICON x SM_CYSMICON is used.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>This flag can be used with all stock icons.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Applications that use older customized icons (NIIF_USER with <c>hIcon</c>) must provide a new SM_CXICON x SM_CYICON version
		/// in the tray icon specified in the <c>hIcon</c> member of the NOTIFYICONDATA structure. These icons are scaled down when they
		/// are displayed in the notification area.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// New customized icons (NIIF_USER with <c>hBalloonIcon</c>) must supply an SM_CXICON x SM_CYICON version in the supplied icon
		/// ( <c>hBalloonIcon</c>).
		/// </term>
		/// </item>
		/// </list>
		/// <para>NIIF_RESPECT_QUIET_TIME (0x00000080)</para>
		/// <para>
		/// 0x00000080. <c>Windows 7 and later</c>. Do not display the notification balloon if the current user is in "quiet time",
		/// which is the first hour after a new user logs into his or her account for the first time. During this time, most
		/// notifications should not be sent or shown. This lets a user become accustomed to a new computer system without those
		/// distractions. Quiet time also occurs for each user after an operating system upgrade or clean installation. A notification
		/// sent with this flag during quiet time is not queued; it is simply dismissed unshown. The application can resend the
		/// notification later if it is still valid at that time.
		/// </para>
		/// <para>
		/// Because an application cannot predict when it might encounter quiet time, we recommended that this flag always be set on all
		/// appropriate notifications by any application that means to honor quiet time.
		/// </para>
		/// <para>If the current user is not in quiet time, this flag has no effect.</para>
		/// <para>NIIF_ICON_MASK (0x0000000F)</para>
		/// <para>0x0000000F. <c>Windows XP</c> (Shell32.dll version 6.0 <c>) and later</c>. Reserved.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iusernotification2-setballooninfo HRESULT
		// SetBalloonInfo( LPCWSTR pszTitle, LPCWSTR pszText, DWORD dwInfoFlags );
		[PreserveSig]
		HRESULT SetBalloonInfo([MarshalAs(UnmanagedType.LPWStr)] string pszTitle, [MarshalAs(UnmanagedType.LPWStr)] string pszText, NIIF dwInfoFlags);

		/// <summary>Specifies the conditions for trying to display user information when the first attempt fails.</summary>
		/// <param name="dwShowTime">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The amount of time, in milliseconds, to display the user information.</para>
		/// </param>
		/// <param name="dwInterval">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The interval of time, in milliseconds, between attempts to display the user information.</para>
		/// </param>
		/// <param name="cRetryCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of times the system should try to display the user information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iusernotification2-setballoonretry HRESULT
		// SetBalloonRetry( DWORD dwShowTime, DWORD dwInterval, UINT cRetryCount );
		[PreserveSig]
		HRESULT SetBalloonRetry(uint dwShowTime, uint dwInterval, uint cRetryCount);

		/// <summary>Sets the notification area icon associated with specific user information.</summary>
		/// <param name="hIcon">
		/// <para>Type: <c>HICON</c></para>
		/// <para>A handle to the icon.</para>
		/// </param>
		/// <param name="pszToolTip">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>
		/// A pointer to a string that contains the tooltip text to display for the specified icon. This value can be <c>NULL</c>,
		/// although it is not recommended.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iusernotification2-seticoninfo HRESULT SetIconInfo(
		// HICON hIcon, LPCWSTR pszToolTip );
		[PreserveSig]
		HRESULT SetIconInfo(HICON hIcon, [MarshalAs(UnmanagedType.LPWStr)] string pszToolTip);

		/// <summary>Displays the user information in a balloon-style tooltip.</summary>
		/// <param name="pqc">
		/// <para>Type: <c>IQueryContinue*</c></para>
		/// <para>
		/// An IQueryContinue interface pointer, used to determine whether the notification display can continue or should stop (for
		/// example, if the user closes the notification). This value can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwContinuePollInterval">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The length of time, in milliseconds, to display user information.</para>
		/// </param>
		/// <param name="pSink">
		/// <para>Type: <c>IUserNotificationCallback*</c></para>
		/// <para>
		/// A pointer to an IUserNotificationCallback interface, used to handle mouse click and hover actions on the notification area
		/// icon and within the notification itself. This value can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iusernotification2-show HRESULT Show( IQueryContinue
		// *pqc, DWORD dwContinuePollInterval, IUserNotificationCallback *pSink );
		HRESULT Show(IQueryContinue pqc, uint dwContinuePollInterval, IUserNotificationCallback pSink);

		/// <summary>Plays a sound in conjunction with the notification.</summary>
		/// <param name="pszSoundName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated Unicode string that specifies the alias of the sound file to play.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The string pointed to by pszSoundName contains an alias for a system event found in the registry or the Win.ini file; for
		/// instance, "SystemExit".
		/// </para>
		/// <para>
		/// The specified sound is played asynchronously and the method returns immediately after beginning the sound. To stop an
		/// asynchronous waveform sound, call <c>IUserNotification2::PlaySound</c> with pszSoundName set to <c>NULL</c>.
		/// </para>
		/// <para>
		/// The specified sound event will yield to another sound event that is already playing. If a sound cannot be played because the
		/// resource needed to play that sound is busy, the method immediately returns S_FALSE without playing the requested sound.
		/// </para>
		/// <para>If the specified sound cannot be found, <c>IUserNotification2::PlaySound</c> uses the system default sound.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iusernotification2-playsound HRESULT PlaySound(
		// LPCWSTR pszSoundName );
		[PreserveSig]
		HRESULT PlaySound([MarshalAs(UnmanagedType.LPWStr)] string pszSoundName);
	}

	/// <summary>
	/// Exposes a method for the handling of a mouse click or shortcut menu access in a notification balloon. Used with IUserNotification2::Show.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-iusernotificationcallback
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IUserNotificationCallback")]
	[ComImport, Guid("19108294-0441-4AFF-8013-FA0A730B0BEA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUserNotificationCallback
	{
		/// <summary>
		/// Called when the user clicks the balloon. The application may respond with an action that is suitable for the balloon being clicked.
		/// </summary>
		/// <param name="pt">
		/// <para>Type: <c>POINT*</c></para>
		/// <para>
		/// Takes a pointer to the POINT structure which, upon method return, points to the position of the mouse in screen space where
		/// the mouse click occurred.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iusernotificationcallback-onballoonuserclick HRESULT
		// OnBalloonUserClick( POINT *pt );
		[PreserveSig]
		HRESULT OnBalloonUserClick(ref POINT pt);

		/// <summary>
		/// Called when the user clicks the icon in the notification area. The applications may launch some customary UI in response.
		/// </summary>
		/// <param name="pt">
		/// <para>Type: <c>POINT*</c></para>
		/// <para>
		/// Takes a pointer to the POINT structure which, when the method returns, points to the position of the mouse in the screen
		/// space where the mouse click occurred.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iusernotificationcallback-onleftclick HRESULT
		// OnLeftClick( POINT *pt );
		[PreserveSig]
		HRESULT OnLeftClick(ref POINT pt);

		/// <summary>
		/// Called when the user right-clicks (or presses SHIFT+F10) the icon in the notification area. The application should show its
		/// context menu in response.
		/// </summary>
		/// <param name="pt">
		/// <para>Type: <c>POINT*</c></para>
		/// <para>
		/// When returned by the method, takes a pointer to the POINT structure at the position of the mouse in the screen space where
		/// the click occurred.
		/// </para>
		/// <para>In the case where user presses SHIFT+F10, the pointer points to the center of the icon in the screen space.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iusernotificationcallback-oncontextmenu HRESULT
		// OnContextMenu( POINT *pt );
		[PreserveSig]
		HRESULT OnContextMenu(ref POINT pt);
	}
}