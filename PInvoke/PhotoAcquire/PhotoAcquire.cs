#nullable enable
using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

/// <summary>Enums and interfaces from the Windows Photo Acquisition API.</summary>
public static partial class PhotoAcquisition
{
	public static readonly HRESULT PAQ_ERR = HRESULT.Make(true, HRESULT.FacilityCode.FACILITY_ITF, 0xA001);
	public static readonly PROPERTYKEY PKEY_PhotoAcquire_CameraSequenceNumber = new(new(0x00f23377, 0x7ac6, 0x4b7a, 0x84, 0x43, 0x34, 0x5e, 0x73, 0x1f, 0xa5, 0x7a), 7);    // VT_LPWSTR
	public static readonly PROPERTYKEY PKEY_PhotoAcquire_DuplicateDetectionID = new(new(0x00f23377, 0x7ac6, 0x4b7a, 0x84, 0x43, 0x34, 0x5e, 0x73, 0x1f, 0xa5, 0x7a), 10);    // VT_I4
	public static readonly PROPERTYKEY PKEY_PhotoAcquire_FinalFilename = new(new(0x00f23377, 0x7ac6, 0x4b7a, 0x84, 0x43, 0x34, 0x5e, 0x73, 0x1f, 0xa5, 0x7a), 3);    // VT_LPWSTR
	public static readonly PROPERTYKEY PKEY_PhotoAcquire_GroupTag = new(new(0x00f23377, 0x7ac6, 0x4b7a, 0x84, 0x43, 0x34, 0x5e, 0x73, 0x1f, 0xa5, 0x7a), 4);    // VT_LPWSTR
	public static readonly PROPERTYKEY PKEY_PhotoAcquire_IntermediateFile = new(new(0x00f23377, 0x7ac6, 0x4b7a, 0x84, 0x43, 0x34, 0x5e, 0x73, 0x1f, 0xa5, 0x7a), 8);    // VT_LPWSTR
	public static readonly PROPERTYKEY PKEY_PhotoAcquire_OriginalFilename = new(new(0x00f23377, 0x7ac6, 0x4b7a, 0x84, 0x43, 0x34, 0x5e, 0x73, 0x1f, 0xa5, 0x7a), 6);    // VT_LPWSTR
	public static readonly PROPERTYKEY PKEY_PhotoAcquire_RelativePathname = new(new(0x00f23377, 0x7ac6, 0x4b7a, 0x84, 0x43, 0x34, 0x5e, 0x73, 0x1f, 0xa5, 0x7a), 2); // VT_LPWSTR
	public static readonly PROPERTYKEY PKEY_PhotoAcquire_SkipImport = new(new(0x00f23377, 0x7ac6, 0x4b7a, 0x84, 0x43, 0x34, 0x5e, 0x73, 0x1f, 0xa5, 0x7a), 9);    // VT_BOOL
	public static readonly PROPERTYKEY PKEY_PhotoAcquire_TransferResult = new(new(0x00f23377, 0x7ac6, 0x4b7a, 0x84, 0x43, 0x34, 0x5e, 0x73, 0x1f, 0xa5, 0x7a), 5);    // VT_SCODE

	/// <summary>The enumeration type indicates the type of a selected device.</summary>
	/// <remarks>This enumeration type is pointed to by the <c>pnDeviceType</c> parameter of IPhotoAcquireDeviceSelectionDialog::DoModal.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/ne-photoacquire-device_selection_device_type typedef enum
	// tagDEVICE_SELECTION_DEVICE_TYPE { DST_UNKNOWN_DEVICE = 0, DST_WPD_DEVICE = 0x1, DST_WIA_DEVICE = 0x2, DST_STI_DEVICE = 0x3,
	// DSF_TWAIN_DEVICE = 0x4, DST_FS_DEVICE = 0x5, DST_DV_DEVICE = 0x6 } DEVICE_SELECTION_DEVICE_TYPE;
	[PInvokeData("photoacquire.h", MSDNShortId = "NE:photoacquire.tagDEVICE_SELECTION_DEVICE_TYPE")]
	public enum DEVICE_SELECTION_DEVICE_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies that the type of the selected device is unknown.</para>
		/// </summary>
		DST_UNKNOWN_DEVICE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Specifies that the type of the selected device is Windows Portable Devices (WPD).</para>
		/// </summary>
		DST_WPD_DEVICE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Specifies that the type of the selected device is Windows Image Acquisition (WIA).</para>
		/// </summary>
		DST_WIA_DEVICE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x3</para>
		/// <para>Specifies that the type of the selected device is Still Image Architecture (STI).</para>
		/// </summary>
		DST_STI_DEVICE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>Not supported.</para>
		/// </summary>
		DSF_TWAIN_DEVICE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x5</para>
		/// <para>Specifies that the selected device is a removable drive in the file system.</para>
		/// </summary>
		DST_FS_DEVICE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x6</para>
		/// </summary>
		DST_DV_DEVICE,
	}

	/// <summary></summary>
	[Flags]
	public enum DSF : uint
	{
		/// <summary>Show devices of type Windows Portable Devices (WPD).</summary>
		DSF_WPD_DEVICES = 0x00000001,

		/// <summary>Show cameras of type Windows Image Acquisition (WIA).</summary>
		DSF_WIA_CAMERAS = 0x00000002,

		/// <summary>Show scanners of type Windows Image Acquisition (WIA).</summary>
		DSF_WIA_SCANNERS = 0x00000004,

		/// <summary>Show devices of type Still Image Architecture (STI).</summary>
		DSF_STI_DEVICES = 0x00000008,

		/// <summary/>
		DSF_TWAIN_DEVICES = 0x00000010,

		/// <summary>Show removable storage devices, such as CD drives or card readers.</summary>
		DSF_FS_DEVICES = 0x00000020,

		/// <summary>Show digital video camera devices.</summary>
		DSF_DV_DEVICES = 0x00000040,

		/// <summary>Show all devices.</summary>
		DSF_ALL_DEVICES = 0x0000FFFF,

		/// <summary/>
		DSF_CPL_MODE = 0x00010000,

		/// <summary>Show devices that are offline. Not supported by all device types.</summary>
		DSF_SHOW_OFFLINE = 0x00020000,
	}

	/// <summary>The enumeration type indicates the type of error values that can be passed to the <c>nMessageType</c> parameter of IPhotoAcquireProgressCB::ErrorAdvise.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/ne-photoacquire-error_advise_message_type typedef enum
	// tagERROR_ADVISE_MESSAGE_TYPE { PHOTOACQUIRE_ERROR_SKIPRETRYCANCEL = 0, PHOTOACQUIRE_ERROR_RETRYCANCEL = 1, PHOTOACQUIRE_ERROR_YESNO =
	// 2, PHOTOACQUIRE_ERROR_OK = 3 } ERROR_ADVISE_MESSAGE_TYPE;
	[PInvokeData("photoacquire.h", MSDNShortId = "NE:photoacquire.tagERROR_ADVISE_MESSAGE_TYPE")]
	public enum ERROR_ADVISE_MESSAGE_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies that the error that occurred requires a Skip, Retry, or Cancel response. The</para>
		/// <para>pnErrorAdviseResult</para>
		/// <para>parameter to</para>
		/// <para>IPhotoAcquireProgressDialogCB::ErrorAdvise</para>
		/// <para>must be one of the following:</para>
		/// <para>PHOTOACQUIRE_RESULT_SKIP</para>
		/// <para>,</para>
		/// <para>PHOTOACQUIRE_RESULT_SKIP_ALL</para>
		/// <para>,</para>
		/// <para>PHOTOACQUIRE_RESULT_RETRY</para>
		/// <para>, or</para>
		/// <para>PHOTOACQUIRE_RESULT_ABORT</para>
		/// <para>.</para>
		/// </summary>
		PHOTOACQUIRE_ERROR_SKIPRETRYCANCEL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Specifies that the error that occurred requires a Retry or Cancel response. The</para>
		/// <para>pnErrorAdviseResult</para>
		/// <para>parameter to</para>
		/// <para>IPhotoAcquireProgressDialogCB::ErrorAdvise</para>
		/// <para>must be one of the following:</para>
		/// <para>PHOTOACQUIRE_RESULT_RETRY</para>
		/// <para>or</para>
		/// <para>PHOTOACQUIRE_RESULT_ABORT</para>
		/// <para>.</para>
		/// </summary>
		PHOTOACQUIRE_ERROR_RETRYCANCEL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Specifies that the error that occurred requires a Yes or No response. The</para>
		/// <para>pnErrorAdviseResult</para>
		/// <para>parameter to</para>
		/// <para>IPhotoAcquireProgressDialogCB::ErrorAdvise</para>
		/// <para>must be one of the following:</para>
		/// <para>PHOTOACQUIRE_RESULT_YES</para>
		/// <para>or</para>
		/// <para>PHOTOACQUIRE_RESULT_NO</para>
		/// <para>.</para>
		/// </summary>
		PHOTOACQUIRE_ERROR_YESNO,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Specifies that the error that occurred requires an OK response. The</para>
		/// <para>pnErrorAdviseResult</para>
		/// <para>parameter to</para>
		/// <para>IPhotoAcquireProgressDialogCB::ErrorAdvise</para>
		/// <para>must be</para>
		/// <para>PHOTOACQUIRE_RESULT_OK</para>
		/// <para>.</para>
		/// </summary>
		PHOTOACQUIRE_ERROR_OK,
	}

	/// <summary>
	/// The enumeration type indicates the type of error values that can be assigned to the <c>pnErrorAdviseResult</c> parameter of IPhotoAcquireProgressCB::ErrorAdvise.
	/// </summary>
	/// <remarks>
	/// The type of response allowed is of type ERROR_ADVISE_MESSAGE_TYPE, and indicated by the <c>nMessageType</c> parameter of IPhotoAcquireProgressCB::ErrorAdvise.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/ne-photoacquire-error_advise_result typedef enum
	// tagERROR_ADVISE_RESULT { PHOTOACQUIRE_RESULT_YES = 0, PHOTOACQUIRE_RESULT_NO = 1, PHOTOACQUIRE_RESULT_OK = 2, PHOTOACQUIRE_RESULT_SKIP
	// = 3, PHOTOACQUIRE_RESULT_SKIP_ALL = 4, PHOTOACQUIRE_RESULT_RETRY = 5, PHOTOACQUIRE_RESULT_ABORT = 6 } ERROR_ADVISE_RESULT;
	[PInvokeData("photoacquire.h", MSDNShortId = "NE:photoacquire.tagERROR_ADVISE_RESULT")]
	public enum ERROR_ADVISE_RESULT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies a Yes response to an error dialog. Valid only if the</para>
		/// <para>nMessageType</para>
		/// <para>parameter to</para>
		/// <para>IPhotoAcquireProgressCB::ErrorAdvise</para>
		/// <para>is PHOTOACQUIRE_ERROR_YESNO.</para>
		/// </summary>
		PHOTOACQUIRE_RESULT_YES,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Specifies a No response to an error dialog. Valid only if the</para>
		/// <para>nMessageType</para>
		/// <para>parameter to</para>
		/// <para>IPhotoAcquireProgressCB::ErrorAdvise</para>
		/// <para>is PHOTOACQUIRE_ERROR_YESNO.</para>
		/// </summary>
		PHOTOACQUIRE_RESULT_NO,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Specifies an OK response to an error dialog. Valid only if the</para>
		/// <para>nMessageType</para>
		/// <para>parameter to</para>
		/// <para>IPhotoAcquireProgressCB::ErrorAdvise</para>
		/// <para>is PHOTOACQUIRE_ERROR_OK.</para>
		/// </summary>
		PHOTOACQUIRE_RESULT_OK,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Specifies a Skip response to an error dialog. Valid only if the</para>
		/// <para>nMessageType</para>
		/// <para>parameter to</para>
		/// <para>IPhotoAcquireProgressCB::ErrorAdvise</para>
		/// <para>is PHOTOACQUIRE_ERROR_SKIPRETRYCANCEL.</para>
		/// </summary>
		PHOTOACQUIRE_RESULT_SKIP,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Specifies a Skip All response to an error dialog. Valid only if the</para>
		/// <para>nMessageType</para>
		/// <para>parameter to</para>
		/// <para>IPhotoAcquireProgressCB::ErrorAdvise</para>
		/// <para>is PHOTOACQUIRE_ERROR_SKIPRETRYCANCEL.</para>
		/// </summary>
		PHOTOACQUIRE_RESULT_SKIP_ALL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Specifies a Retry response to an error dialog. Valid only if the</para>
		/// <para>nMessageType</para>
		/// <para>parameter to</para>
		/// <para>IPhotoAcquireProgressCB::ErrorAdvise</para>
		/// <para>is PHOTOACQUIRE_ERROR_SKIPRETRYCANCEL or PHOTOACQUIRE_ERROR_RETRYCANCEL.</para>
		/// </summary>
		PHOTOACQUIRE_RESULT_RETRY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Specifies a Cancel response to an error dialog. Valid only if the</para>
		/// <para>nMessageType</para>
		/// <para>parameter to</para>
		/// <para>IPhotoAcquireProgressCB::ErrorAdvise</para>
		/// <para>is PHOTOACQUIRE_ERROR_SKIPRETRYCANCEL or PHOTOACQUIRE_ERROR_RETRYCANCEL.</para>
		/// </summary>
		PHOTOACQUIRE_RESULT_ABORT,
	}

	/// <summary>Specifies a double word value indicating whether this method is being called before or after processing an item.</summary>
	[PInvokeData("photoacquire.h", MSDNShortId = "NN:photoacquire.IPhotoAcquirePlugin")]
	public enum PAPS : uint
	{
		/// <summary>
		/// Indicates that the method is being called before saving the acquired file. During PAPS_PRESAVE, pPhotoAcquireItem::GetProperty
		/// should be used to retrieve metadata from the original file, while new metadata to be written to the file should be added to pPropertyStore.
		/// </summary>
		PAPS_PRESAVE = 0x00000000,

		/// <summary>Indicates that the method is being called after saving the acquired file.</summary>
		PAPS_POSTSAVE = 0x00000001,

		/// <summary>Indicates that the user has canceled the acquire operation and any work done by the plug-in should be cleaned up.</summary>
		PAPS_CLEANUP = 0x00000002,
	}

	/// <summary>Photo acquire flags.</summary>
	[PInvokeData("photoacquire.h")]
	[Flags]
	public enum PHOTOACQ : uint
	{
		/// <summary/>
		PHOTOACQ_RUN_DEFAULT = 0x00000000,

		/// <summary>
		/// In versions of Windows that don't include Windows Photo Gallery, PHOTOACQ_NO_GALLERY_LAUNCH suppresses the explorer window
		/// launched after acquisition.
		/// </summary>
		PHOTOACQ_NO_GALLERY_LAUNCH = 0x00000001,

		/// <summary/>
		PHOTOACQ_DISABLE_AUTO_ROTATE = 0x00000002,

		/// <summary/>
		PHOTOACQ_DISABLE_PLUGINS = 0x00000004,

		/// <summary/>
		PHOTOACQ_DISABLE_GROUP_TAG_PROMPT = 0x00000008,

		/// <summary/>
		PHOTOACQ_DISABLE_DB_INTEGRATION = 0x00000010,

		/// <summary/>
		PHOTOACQ_DELETE_AFTER_ACQUIRE = 0x00000020,

		/// <summary/>
		PHOTOACQ_DISABLE_DUPLICATE_DETECTION = 0x00000040,

		/// <summary/>
		PHOTOACQ_ENABLE_THUMBNAIL_CACHING = 0x00000080,

		/// <summary/>
		PHOTOACQ_DISABLE_METADATA_WRITE = 0x00000100,

		/// <summary/>
		PHOTOACQ_DISABLE_THUMBNAIL_PROGRESS = 0x00000200,

		/// <summary/>
		PHOTOACQ_DISABLE_SETTINGS_LINK = 0x00000400,

		/// <summary/>
		PHOTOACQ_ABORT_ON_SETTINGS_UPDATE = 0x00000800,

		/// <summary/>
		PHOTOACQ_IMPORT_VIDEO_AS_MULTIPLE_FILES = 0x00001000,
	}

	/// <summary>The enumeration type indicates the check box on the IPhotoProgressDialog object.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/ne-photoacquire-progress_dialog_checkbox_id typedef enum
	// PROGRESS_DIALOG_CHECKBOX_ID { PROGRESS_DIALOG_CHECKBOX_ID_DEFAULT = 0 } PROGRESS_DIALOG_CHECKBOX_ID;
	[PInvokeData("photoacquire.h", MSDNShortId = "NE:photoacquire.PROGRESS_DIALOG_CHECKBOX_ID")]
	public enum PROGRESS_DIALOG_CHECKBOX_ID
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies PROGRESS_DIALOG_CHECKBOX_ID_DEFAULT .</para>
		/// </summary>
		PROGRESS_DIALOG_CHECKBOX_ID_DEFAULT,
	}

	/// <summary>The enumeration type indicates the image type set in IPhotoProgressDialog::SetImage.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/ne-photoacquire-progress_dialog_image_type typedef enum
	// tagPROGRESS_DIALOG_IMAGE_TYPE { PROGRESS_DIALOG_ICON_SMALL = 0, PROGRESS_DIALOG_ICON_LARGE = 0x1, PROGRESS_DIALOG_ICON_THUMBNAIL =
	// 0x2, PROGRESS_DIALOG_BITMAP_THUMBNAIL = 0x3 } PROGRESS_DIALOG_IMAGE_TYPE;
	[PInvokeData("photoacquire.h", MSDNShortId = "NE:photoacquire.tagPROGRESS_DIALOG_IMAGE_TYPE")]
	public enum PROGRESS_DIALOG_IMAGE_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies the small icon used in the title bar (normally 16 x 16 pixels).</para>
		/// </summary>
		PROGRESS_DIALOG_ICON_SMALL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Specifies the icon used to represent the progress dialog box in ALT+TAB key combination windows (normally 32 x 32 pixels).</para>
		/// </summary>
		PROGRESS_DIALOG_ICON_LARGE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Specifies an icon used in place of the thumbnail (up to 128 x 128 pixels).</para>
		/// </summary>
		PROGRESS_DIALOG_ICON_THUMBNAIL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x3</para>
		/// <para>Specifies a bitmap thumbnail (up to 128 x 128 pixels, although it will be scaled to fit if it is too large).</para>
		/// </summary>
		PROGRESS_DIALOG_BITMAP_THUMBNAIL,
	}

	/// <summary>The enumeration type indicates the type of string to obtain from the user in IPhotoAcquireProgressCB::GetUserInput.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/ne-photoacquire-user_input_string_type typedef enum
	// tagUSER_INPUT_STRING_TYPE { USER_INPUT_DEFAULT = 0, USER_INPUT_PATH_ELEMENT = 0x1 } USER_INPUT_STRING_TYPE;
	[PInvokeData("photoacquire.h", MSDNShortId = "NE:photoacquire.tagUSER_INPUT_STRING_TYPE")]
	public enum USER_INPUT_STRING_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Indicates that any string is allowed.</para>
		/// </summary>
		USER_INPUT_DEFAULT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Indicates that the string will not accept characters that are illegal in file or directory names (such as * or /).</para>
		/// </summary>
		USER_INPUT_PATH_ELEMENT,
	}

	/// <summary>The interface provides methods for acquiring photos from a device.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nn-photoacquire-iphotoacquire
	[PInvokeData("photoacquire.h", MSDNShortId = "NN:photoacquire.IPhotoAcquire")]
	[ComImport, Guid("00F23353-E31B-4955-A8AD-CA5EBF31E2CE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(PhotoAcquire))]
	public interface IPhotoAcquire
	{
		/// <summary>The method initializes an IPhotoAcquireSource object to pass to IPhotoAcquire::Acquire.</summary>
		/// <param name="pszDevice">A string containing the device name.</param>
		/// <returns>Returns the initialized photo source to acquire photos from.</returns>
		/// <remarks>
		/// <para>The IPhotoAcquireSource object created is used as the parameter for the Acquire method.</para>
		/// <para>If an error occurs in , <c>ppPhotoAcquireSource</c> is initialized to <c>NULL</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquire-createphotosource HRESULT
		// CreatePhotoSource( [in] LPCWSTR pszDevice, [out] IPhotoAcquireSource **ppPhotoAcquireSource );
		IPhotoAcquireSource? CreatePhotoSource([In, MarshalAs(UnmanagedType.LPWStr)] string pszDevice);

		/// <summary>The method acquires photos from a device.</summary>
		/// <param name="pPhotoAcquireSource">
		/// Pointer to an IPhotoAcquireSource object representing the device from which to acquire photos. Initialize this object by calling CreatePhotoSource.
		/// </param>
		/// <param name="fShowProgress">Flag that, when set to <see langword="true"/>, indicates that a progress dialog will be shown.</param>
		/// <param name="hWndParent">Handle to a parent window.</param>
		/// <param name="pszApplicationName">A string containing the application name.</param>
		/// <param name="pPhotoAcquireProgressCB">Pointer to an optional IPhotoAcquireProgressCB object.</param>
		/// <remarks>
		/// <para>
		/// To initialize the <c>pPhotoAcquireSource</c> parameter passed to , CreatePhotoSource should be called prior to calling .
		/// </para>
		/// <para>
		/// <c>pPhotoAcquireProgressCB</c> provides callback methods that allow you to apply further filtering or control as items are acquired.
		/// </para>
		/// <para>
		/// To verify that there are items in the device before acquisition, or to selectively acquire items from the device, call
		/// IPhotoAcquireSource::InitializeItemList to enumerate the items before calling .
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquire-acquire HRESULT Acquire( [in]
		// IPhotoAcquireSource *pPhotoAcquireSource, [in] BOOL fShowProgress, [in] HWND hWndParent, [in] LPCWSTR pszApplicationName, [in]
		// IPhotoAcquireProgressCB *pPhotoAcquireProgressCB );
		void Acquire([In, Optional, MarshalAs(UnmanagedType.Interface)] IPhotoAcquireSource pPhotoAcquireSource, [In, MarshalAs(UnmanagedType.Bool)] bool fShowProgress,
			[In, Optional] HWND hWndParent, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszApplicationName, [In, Optional, MarshalAs(UnmanagedType.Interface)] IPhotoAcquireProgressCB pPhotoAcquireProgressCB);

		/// <summary>
		/// The method retrieves an enumeration containing the paths of all files successfully transferred during the most recent call to Acquire.
		/// </summary>
		/// <returns>Returns an enumeration containing the paths to all the transferred files.</returns>
		/// <remarks>If the file transfer is aborted before any files are transferred, <c>ppEnumFilePaths</c> will be set to <c>NULL</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquire-enumresults HRESULT EnumResults(
		// [out] IEnumString **ppEnumFilePaths );
		IEnumString? EnumResults();
	}

	/// <summary>Provides a dialog box for selecting the device to acquire images from.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nn-photoacquire-iphotoacquiredeviceselectiondialog
	[PInvokeData("photoacquire.h", MSDNShortId = "NN:photoacquire.IPhotoAcquireDeviceSelectionDialog")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00F28837-55DD-4F37-AAF5-6855A9640467"), CoClass(typeof(PhotoAcquireDeviceSelectionDialog))]
	public interface IPhotoAcquireDeviceSelectionDialog
	{
		/// <summary>The method sets the title of the device selection dialog box.</summary>
		/// <param name="pszTitle">A string containing the title.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiredeviceselectiondialog-settitle
		// HRESULT SetTitle( [in] LPCWSTR pszTitle );
		void SetTitle([In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

		/// <summary>The method sets the text displayed in the dialog box that prompts the user to select a device.</summary>
		/// <param name="pszSubmitButtonText">A string containing the prompt.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiredeviceselectiondialog-setsubmitbuttontext
		// HRESULT SetSubmitButtonText( [in] LPCWSTR pszSubmitButtonText );
		void SetSubmitButtonText([In, MarshalAs(UnmanagedType.LPWStr)] string pszSubmitButtonText);

		/// <summary>The method displays a device selection dialog box. The function returns when the user selects a device using the modal dialog box.</summary>
		/// <param name="hWndParent">Handle to a parent window.</param>
		/// <param name="dwDeviceFlags">
		/// <para>Double word value containing a combination of device flags that indicate which type of devices to display. The device flags may be a combination of any of the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>DSF_WPD_DEVICES</c></term>
		/// <term>Show devices of type Windows Portable Devices (WPD).</term>
		/// </item>
		/// <item>
		/// <term><c>DSF_WIA_CAMERAS</c></term>
		/// <term>Show cameras of type Windows Image Acquisition (WIA).</term>
		/// </item>
		/// <item>
		/// <term><c>DSF_WIA_SCANNERS</c></term>
		/// <term>Show scanners of type Windows Image Acquisition (WIA).</term>
		/// </item>
		/// <item>
		/// <term><c>DSF_STI_DEVICES</c></term>
		/// <term>Show devices of type Still Image Architecture (STI).</term>
		/// </item>
		/// <item>
		/// <term><c>DSF_FS_DEVICES</c></term>
		/// <term>Show removable storage devices, such as CD drives or card readers.</term>
		/// </item>
		/// <item>
		/// <term><c>DSF_DV_DEVICES</c></term>
		/// <term>Show digital video camera devices.</term>
		/// </item>
		/// <item>
		/// <term><c>DSF_ALL_DEVICES</c></term>
		/// <term>Show all devices.</term>
		/// </item>
		/// <item>
		/// <term><c>DSF_SHOW_OFFLINE</c></term>
		/// <term>Show devices that are offline. Not supported by all device types.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pbstrDeviceId">Pointer to a string containing the ID of the selected device.</param>
		/// <param name="pnDeviceType">Pointer to the DEVICE_SELECTION_DEVICE_TYPE of the selected device.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiredeviceselectiondialog-domodal
		// HRESULT DoModal( [in] HWND hWndParent, [in] DWORD dwDeviceFlags, [out] BSTR *pbstrDeviceId, [out] DEVICE_SELECTION_DEVICE_TYPE *pnDeviceType );
		[PreserveSig]
		HRESULT DoModal([In] HWND hWndParent, [In] DSF dwDeviceFlags, [MarshalAs(UnmanagedType.BStr)] out string? pbstrDeviceId,
			out DEVICE_SELECTION_DEVICE_TYPE pnDeviceType);
	}

	/// <summary>The interface provides methods for working with items as they are acquired from a device.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nn-photoacquire-iphotoacquireitem
	[PInvokeData("photoacquire.h", MSDNShortId = "NN:photoacquire.IPhotoAcquireItem")]
	[ComImport, Guid("00F21C97-28BF-4C02-B842-5E4E90139A30"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPhotoAcquireItem
	{
		/// <summary>The method retrieves the file name for an item.</summary>
		/// <returns>Pointer to a string containing the name of the item.</returns>
		/// <remarks>
		/// The file name consists of the display name and the extension, even if the <c>Hide extensions for known file types</c> setting is
		/// checked in the Windows <c>Folder Options</c> dialog box.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireitem-getitemname HRESULT
		// GetItemName( [out] BSTR *pbstrItemName );
		[return: MarshalAs(UnmanagedType.BStr)]
		string? GetItemName();

		/// <summary>The method retrieves the thumbnail provided for an item.</summary>
		/// <param name="sizeThumbnail">Specifies the size of the thumbnail.</param>
		/// <returns>Specifies a handle to the thumbnail bitmap.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireitem-getthumbnail HRESULT
		// GetThumbnail( [in] SIZE sizeThumbnail, [out] HBITMAP *phbmpThumbnail );
		SafeHBITMAP? GetThumbnail([In] SIZE sizeThumbnail);

		/// <summary>The method retrieves the value of a property of an item.</summary>
		/// <param name="key">Specifies a key for the property.</param>
		/// <param name="pv">Pointer to a property variant containing the property value.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// For an item that is a shell object, this method will defer to the <c>IPropertyStore</c> object provided by the item if the
		/// property hasn't been set or updated using SetProperty.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireitem-getproperty HRESULT
		// GetProperty( [in] REFPROPERTYKEY key, [out] PROPVARIANT *pv );
		[PreserveSig]
		HRESULT GetProperty(in PROPERTYKEY key, [Out] PROPVARIANT pv);

		/// <summary>The method sets a property for an item.</summary>
		/// <param name="key">Specifies a key for the property to set.</param>
		/// <param name="pv">Pointer to a property variant containing the value to set the property to.</param>
		/// <remarks>The property is stored in memory, but is not written to the file.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireitem-setproperty HRESULT
		// SetProperty( [in] REFPROPERTYKEY key, [in] const PROPVARIANT *pv );
		void SetProperty(in PROPERTYKEY key, [In] PROPVARIANT pv);

		/// <summary>The method retrieves a read-only stream containing the contents of an item.</summary>
		/// <returns>Returns a stream object with the file contents.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireitem-getstream HRESULT GetStream(
		// [out] IStream **ppStream );
		IStream? GetStream();

		/// <summary>The method indicates whether an item may be deleted.</summary>
		/// <returns>Pointer to a flag that, when set to <see langword="true"/>, indicates that the item can be deleted.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireitem-candelete HRESULT CanDelete(
		// [out] BOOL *pfCanDelete );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool CanDelete();

		/// <summary>The method deletes an item.</summary>
		/// <remarks>To determine whether an item may be deleted, call CanDelete first.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireitem-delete HRESULT Delete();
		void Delete();

		/// <summary>The method retrieves the number of subitems contained in an item.</summary>
		/// <returns>Pointer to an integer containing the count of subitems.</returns>
		/// <remarks>If an error occurs, <c>pnCount</c> will be set to <c>NULL</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireitem-getsubitemcount HRESULT
		// GetSubItemCount( [out] UINT *pnCount );
		uint GetSubItemCount();

		/// <summary>The method retrieves a subitem of an item, given the index of the subitem.</summary>
		/// <param name="nItemIndex">Integer containing the index of the item.</param>
		/// <returns>Returns the IPhotoAcquireItem object at the given index.</returns>
		/// <remarks>If no item is found at the given index, <c>ppPhotoAcquireItem</c> is set to <c>NULL</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireitem-getsubitemat HRESULT
		// GetSubItemAt( [in] UINT nItemIndex, [out] IPhotoAcquireItem **ppPhotoAcquireItem );
		IPhotoAcquireItem? GetSubItemAt([In] uint nItemIndex);
	}

	/// <summary>The method retrieves the value of a property of an item.</summary>
	/// <param name="item">The <see cref="IPhotoAcquireItem"/> instance.</param>
	/// <param name="key">Specifies a key for the property.</param>
	/// <returns>The property value or <see langword="null"/> on error.</returns>
	/// <remarks>
	/// For an item that is a shell object, this method will defer to the <c>IPropertyStore</c> object provided by the item if the
	/// property hasn't been set or updated using SetProperty.
	/// </remarks>
	public static object? GetProperty(this IPhotoAcquireItem item, in PROPERTYKEY key)
	{
		if (item == null) throw new ArgumentNullException(nameof(item));
		using var pv = new PROPVARIANT();
		return item.GetProperty(key, pv).Succeeded ? pv.Value : null;
	}

	/// <summary>
	/// The interface is used to display an options dialog box in which the user can select photo acquisition settings such as file name
	/// formats, as well as whether or not to rotate images, to prompt for a tag name, or to erase photos from the camera after importing.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nn-photoacquire-iphotoacquireoptionsdialog
	[PInvokeData("photoacquire.h", MSDNShortId = "NN:photoacquire.IPhotoAcquireOptionsDialog")]
	[ComImport, Guid("00F2B3EE-BF64-47EE-89F4-4DEDD79643F2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(PhotoAcquireOptionsDialog))]
	public interface IPhotoAcquireOptionsDialog
	{
		/// <summary>Initializes the options dialog box and reads any saved options from the registry.</summary>
		/// <param name="pszRegistryRoot">
		/// (optional) A string containing the registry root of a custom location to read the acquisition settings from. If this parameter is
		/// set to <c>NULL</c>, the default location will be used.
		/// </param>
		/// <remarks>
		/// <para>must be called prior to calling Create or DoModal. Failure to do so will cause <c>Create</c> or <c>DoModal</c> to fail.</para>
		/// <para>If is called while the options dialog box is already displayed, an error will be returned.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireoptionsdialog-initialize HRESULT
		// Initialize( [in] LPCWSTR pszRegistryRoot );
		void Initialize([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszRegistryRoot);

		/// <summary>The method creates and displays a modeless instance of the photo options dialog box, hosted within a parent window.</summary>
		/// <param name="hWndParent">Handle to the parent window.</param>
		/// <returns>Specifies the created dialog box.</returns>
		/// <remarks>
		/// <para>The Initialize method should be called prior to the method.</para>
		/// <para>The parent window indicated by <c>hWndParent</c> provides <c>OK</c> and <c>Cancel</c> buttons to the new dialog box instance.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireoptionsdialog-create HRESULT Create(
		// [in] HWND hWndParent, [out] HWND *phWndDialog );
		HWND Create([In] HWND hWndParent);

		/// <summary>The method closes and destroys the modeless dialog box created with the Create method.</summary>
		/// <remarks>If you destroy the parent window, the child window will automatically be destroyed.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireoptionsdialog-destroy HRESULT Destroy();
		void Destroy();

		/// <summary>The method creates and displays the options dialog box as a modal dialog box.</summary>
		/// <param name="hWndParent">Handle to the dialog's parent window.</param>
		/// <returns>Specifies the code returned when the window is closed.</returns>
		/// <remarks>
		/// The modal dialog displayed by <c>DoModal</c> will have <c>OK</c> and <c>Cancel</c> buttons, whereas the <c>OK</c> and
		/// <c>Cancel</c> buttons of the modeless dialog displayed by Create must be provided by the parent window.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireoptionsdialog-domodal HRESULT
		// DoModal( [in] HWND hWndParent, [out] INT_PTR *ppnReturnCode );
		[return: MarshalAs(UnmanagedType.SysInt)]
		IntPtr DoModal([In] HWND hWndParent);

		/// <summary>
		/// The method saves acquisition settings from the options dialog box to the registry so that a subsequent instance of the dialog can
		/// be initialized with the same settings.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireoptionsdialog-savedata HRESULT SaveData();
		void SaveData();
	}

	/// <summary>
	/// Implement the interface when you want to create a plug-in to run alongside the Windows Vista user interface (UI) for image
	/// acquisition. Registry settings are required to enable the plug-in.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nn-photoacquire-iphotoacquireplugin
	[PInvokeData("photoacquire.h", MSDNShortId = "NN:photoacquire.IPhotoAcquirePlugin")]
	[ComImport, Guid("00f2dceb-ecb8-4f77-8e47-e7a987c83dd0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPhotoAcquirePlugin
	{
		/// <summary>
		/// The method provides extended functionality when the plug-in is initialized. The application provides the implementation of the method.
		/// </summary>
		/// <param name="pPhotoAcquireSource">Specifies the source from which photos are being acquired.</param>
		/// <param name="pPhotoAcquireProgressCB">Specifies the callback that will provide additional processing during acquisition.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not implemented</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireplugin-initialize HRESULT
		// Initialize( [in] IPhotoAcquireSource *pPhotoAcquireSource, [in] IPhotoAcquireProgressCB *pPhotoAcquireProgressCB );
		[PreserveSig]
		HRESULT Initialize([In, Optional] IPhotoAcquireSource pPhotoAcquireSource, [In, Optional] IPhotoAcquireProgressCB pPhotoAcquireProgressCB);

		/// <summary>
		/// The method provides additional functionality each time an item is processed. The application provides the implementation of the method.
		/// </summary>
		/// <param name="dwAcquireStage">
		/// <para>
		/// Specifies a double word value indicating whether this method is being called before or after processing an item. Must be one of:
		/// PAPS_PRESAVE, PAPS_POSTSAVE, or PAPS_CLEANUP.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PAPS_PRESAVE</term>
		/// <term>
		/// Indicates that the method is being called before saving the acquired file. During PAPS_PRESAVE, pPhotoAcquireItem::GetProperty
		/// should be used to retrieve metadata from the original file, while new metadata to be written to the file should be added to <c>pPropertyStore</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAPS_POSTSAVE</term>
		/// <term>Indicates that the method is being called after saving the acquired file.</term>
		/// </item>
		/// <item>
		/// <term>PAPS_CLEANUP</term>
		/// <term>Indicates that the user has canceled the acquire operation and any work done by the plug-in should be cleaned up.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pPhotoAcquireItem">Pointer to an IPhotoAcquireItem object for the item being processed.</param>
		/// <param name="pOriginalItemStream">
		/// Pointer to an <c>IStream</c> object for the original item. <c>NULL</c> if <c>dwAcquireStage</c> is PAPS_POSTSAVE.
		/// </param>
		/// <param name="pszFinalFilename">The file name of the destination of the item. <c>NULL</c> if <c>dwAcquireStage</c> is PAPS_PRESAVE.</param>
		/// <param name="pPropertyStore">The item's property store. <c>NULL</c> if <c>dwAcquireStage</c> is PAPS_POSTSAVE.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not implemented.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireplugin-processitem HRESULT
		// ProcessItem( [in] DWORD dwAcquireStage, [in] IPhotoAcquireItem *pPhotoAcquireItem, [in] IStream *pOriginalItemStream, [in] LPCWSTR
		// pszFinalFilename, [in] IPropertyStore *pPropertyStore );
		[PreserveSig]
		HRESULT ProcessItem(PAPS dwAcquireStage, [In, Optional] IPhotoAcquireItem pPhotoAcquireItem, [In, Optional] IStream pOriginalItemStream,
			string pszFinalFilename, [In, Optional] IPropertyStore pPropertyStore);

		/// <summary>
		/// Provides extended functionality when a transfer session is completed. The application provides the implementation of the
		/// <c>TransferComplete</c> method.
		/// </summary>
		/// <param name="hr">Specifies the result of the transfer operation.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not implemented</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireplugin-transfercomplete HRESULT
		// TransferComplete( [in] HRESULT hr );
		[PreserveSig]
		HRESULT TransferComplete(HRESULT hr);

		/// <summary>
		/// The method provides extended functionality when the configuration dialog is displayed. The application provides the
		/// implementation of the method.
		/// </summary>
		/// <param name="hWndParent">Specifies the handle to the configuration dialog window.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not implemented</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireplugin-displayconfiguredialog
		// HRESULT DisplayConfigureDialog( [in] HWND hWndParent );
		[PreserveSig]
		HRESULT DisplayConfigureDialog([In] HWND hWndParent);
	}

	/// <summary>The interface may be implemented if you wish to do extra processing at various stages in the acquisition process.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nn-photoacquire-iphotoacquireprogresscb
	[PInvokeData("photoacquire.h", MSDNShortId = "NN:photoacquire.IPhotoAcquireProgressCB")]
	[ComImport, Guid("00F2CE1E-935E-4248-892C-130F32C45CB4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPhotoAcquireProgressCB
	{
		/// <summary>
		/// The method provides extended functionality when a cancellation occurs during an acquisition session. The application provides the
		/// implementation of the method.
		/// </summary>
		/// <param name="pfCancelled">Pointer to a flag that, when set to <see langword="true"/>, indicates that the operation was canceled.</param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not implemented.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-cancelled HRESULT
		// Cancelled( [out] BOOL *pfCancelled );
		[PreserveSig]
		HRESULT Cancelled([MarshalAs(UnmanagedType.Bool)] out bool pfCancelled);

		/// <summary>
		/// <para>The method provides extended functionality when the enumeration of items to acquire begins.</para>
		/// <para>The application provides the implementation of the method.</para>
		/// </summary>
		/// <param name="pPhotoAcquireSource">Pointer to the IPhotoAcquireSource object that items are being enumerated from.</param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not implemented.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-startenumeration HRESULT
		// StartEnumeration( [in] IPhotoAcquireSource *pPhotoAcquireSource );
		[PreserveSig]
		HRESULT StartEnumeration([In, Optional, MarshalAs(UnmanagedType.Interface)] IPhotoAcquireSource pPhotoAcquireSource);

		/// <summary>
		/// The method provides extended functionality each time an item is found during enumeration of items from the device. This method
		/// can be used to exclude an item from the list of items to acquire. The application provides the implementation of the method.
		/// </summary>
		/// <param name="pPhotoAcquireItem">Pointer to the found IPhotoAcquireItem object.</param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>S_FALSE</c></term>
		/// <term>Exclude this item from the list of files to acquire.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Return S_FALSE to exclude the item from the results of the enumeration. This would allow the caller to exclude videos or camera
		/// raw files, for instance.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-founditem HRESULT
		// FoundItem( [in] IPhotoAcquireItem *pPhotoAcquireItem );
		[PreserveSig]
		HRESULT FoundItem([In, MarshalAs(UnmanagedType.Interface)] IPhotoAcquireItem pPhotoAcquireItem);

		/// <summary>
		/// The method provides extended functionality when enumeration of files from the image source is complete. The application provides
		/// the implementation of the method.
		/// </summary>
		/// <param name="hr">Specifies the result of the enumeration operation.</param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not yet implemented</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-endenumeration HRESULT
		// EndEnumeration( [in] HRESULT hr );
		[PreserveSig]
		HRESULT EndEnumeration(HRESULT hr);

		/// <summary>
		/// The method provides additional processing when transfer of items from the device begins. The application provides the
		/// implementation of the method.
		/// </summary>
		/// <param name="pPhotoAcquireSource">Pointer to the IPhotoAcquireSource from which items are being retrieved.</param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any Failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not implemented.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>Returning an error HRESULT other than E_NOTIMPL will cause acquisition to be aborted.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-starttransfer HRESULT
		// StartTransfer( [in] IPhotoAcquireSource *pPhotoAcquireSource );
		[PreserveSig]
		HRESULT StartTransfer([In, Optional, MarshalAs(UnmanagedType.Interface)] IPhotoAcquireSource pPhotoAcquireSource);

		/// <summary>
		/// The method provides extended functionality each time the transfer of an item begins. The application provides the implementation
		/// of the method.
		/// </summary>
		/// <param name="nItemIndex">Integer value containing the item index in the list of items to transfer.</param>
		/// <param name="pPhotoAcquireItem">Pointer to the IPhotoAcquireItem object that is to be transferred.</param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not implemented.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-startitemtransfer HRESULT
		// StartItemTransfer( [in] UINT nItemIndex, [in] IPhotoAcquireItem *pPhotoAcquireItem );
		[PreserveSig]
		HRESULT StartItemTransfer([In] uint nItemIndex, [In, Optional, MarshalAs(UnmanagedType.Interface)] IPhotoAcquireItem pPhotoAcquireItem);

		/// <summary>
		/// The method provides extended functionality when a destination directory is created during the acquisition process. The
		/// application provides the implementation of the method.
		/// </summary>
		/// <param name="pszDirectory">A string containing the directory.</param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not yet implemented.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-directorycreated HRESULT
		// DirectoryCreated( [in] LPCWSTR pszDirectory );
		[PreserveSig]
		HRESULT DirectoryCreated([In, MarshalAs(UnmanagedType.LPWStr)] string pszDirectory);

		/// <summary>
		/// The method provides extended functionality when the percentage of items transferred changes. The application provides the
		/// implementation of the method.
		/// </summary>
		/// <param name="fOverall">
		/// Flag that, when set to <see langword="true"/>, indicates that the value contained in <c>nPercent</c> is a percentage of the
		/// overall transfer progress, rather than a percentage of an individual item's progress.
		/// </param>
		/// <param name="nPercent">Integer value containing the percentage of items transferred.</param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not implemented.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-updatetransferpercent
		// HRESULT UpdateTransferPercent( [in] BOOL fOverall, [in] UINT nPercent );
		[PreserveSig]
		HRESULT UpdateTransferPercent([MarshalAs(UnmanagedType.Bool)] bool fOverall, [In] uint nPercent);

		/// <summary>
		/// The method provides extended functionality each time a file is transferred from the image source. The application provides the
		/// implementation of the method.
		/// </summary>
		/// <param name="nItemIndex">Integer value containing the item index.</param>
		/// <param name="pPhotoAcquireItem">Pointer to a photo acquire item object.</param>
		/// <param name="hr">Specifies the result of the transfer operation.</param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not yet implemented</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-enditemtransfer HRESULT
		// EndItemTransfer( [in] UINT nItemIndex, [in] IPhotoAcquireItem *pPhotoAcquireItem, [in] HRESULT hr );
		[PreserveSig]
		HRESULT EndItemTransfer([In] uint nItemIndex, [In, Optional, MarshalAs(UnmanagedType.Interface)] IPhotoAcquireItem pPhotoAcquireItem, HRESULT hr);

		/// <summary>
		/// The method provides extended functionality when the transfer of all files is complete. The application provides the
		/// implementation of the method.
		/// </summary>
		/// <param name="hr">Specifies the result of the transfer.</param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not yet implemented</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-endtransfer HRESULT
		// EndTransfer( [in] HRESULT hr );
		[PreserveSig]
		HRESULT EndTransfer(HRESULT hr);

		/// <summary>
		/// <para>The method provides extended functionality when deletion of items from the device begins.</para>
		/// <para>The implementation of is provided by the application.</para>
		/// </summary>
		/// <param name="pPhotoAcquireSource">Pointer to the IPhotoAcquireSource that items are being deleted from.</param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not yet implemented</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-startdelete HRESULT
		// StartDelete( [in] IPhotoAcquireSource *pPhotoAcquireSource );
		[PreserveSig]
		HRESULT StartDelete([In, Optional, MarshalAs(UnmanagedType.Interface)] IPhotoAcquireSource pPhotoAcquireSource);

		/// <summary>
		/// The method provides extended functionality each time the deletion of an individual item from the device begins. The application
		/// provides the implementation of the method.
		/// </summary>
		/// <param name="nItemIndex">Integer value containing the item index in the list of items to delete.</param>
		/// <param name="pPhotoAcquireItem">Pointer to the IPhotoAcquireItem object that is being deleted.</param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not implemented.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-startitemdelete HRESULT
		// StartItemDelete( [in] UINT nItemIndex, [in] IPhotoAcquireItem *pPhotoAcquireItem );
		[PreserveSig]
		HRESULT StartItemDelete([In] uint nItemIndex, [In, Optional, MarshalAs(UnmanagedType.Interface)] IPhotoAcquireItem pPhotoAcquireItem);

		/// <summary>
		/// The method provides extended functionality when the percentage of items deleted changes. The application provides the
		/// implementation of the method.
		/// </summary>
		/// <param name="nPercent">Integer value containing the percentage of items deleted.</param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not implemented</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-updatedeletepercent
		// HRESULT UpdateDeletePercent( [in] UINT nPercent );
		[PreserveSig]
		HRESULT UpdateDeletePercent([In] uint nPercent);

		/// <summary>
		/// The method provides extended functionality each time a file is deleted from the image source. The application provides the
		/// implementation of the method.
		/// </summary>
		/// <param name="nItemIndex">Integer value containing the item index.</param>
		/// <param name="pPhotoAcquireItem">Pointer to the deleted IPhotoAcquireItem object.</param>
		/// <param name="hr">Specifies the result of the delete operation.</param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>This method is not yet implemented</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-enditemdelete HRESULT
		// EndItemDelete( [in] UINT nItemIndex, [in] IPhotoAcquireItem *pPhotoAcquireItem, [in] HRESULT hr );
		[PreserveSig]
		HRESULT EndItemDelete([In] uint nItemIndex, [In, Optional, MarshalAs(UnmanagedType.Interface)] IPhotoAcquireItem pPhotoAcquireItem, HRESULT hr);

		/// <summary>
		/// The method provides extended functionality when deletion of files from the image source is complete. The application provides the
		/// implementation of the method.
		/// </summary>
		/// <param name="hr">Specifies the result of the delete operation.</param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not yet implemented</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-enddelete HRESULT
		// EndDelete( [in] HRESULT hr );
		[PreserveSig]
		HRESULT EndDelete(HRESULT hr);

		/// <summary>
		/// The method provides extended functionality when an acquisition session is completed. The application provides the implementation
		/// of the method.
		/// </summary>
		/// <param name="hr">Specifies the result of the acquisition.</param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not yet implemented</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-endsession HRESULT
		// EndSession( [in] HRESULT hr );
		[PreserveSig]
		HRESULT EndSession(HRESULT hr);

		/// <summary>The method returns a value indicating whether photos should be deleted after acquisition.</summary>
		/// <param name="pfDeleteAfterAcquire">
		/// Pointer to a flag that, when set to <see langword="true"/>, indicates that photos should be deleted after acquisition.
		/// </param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not yet implemented</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-getdeleteafteracquire
		// HRESULT GetDeleteAfterAcquire( [out] BOOL *pfDeleteAfterAcquire );
		[PreserveSig]
		HRESULT GetDeleteAfterAcquire([MarshalAs(UnmanagedType.Bool)] out bool pfDeleteAfterAcquire);

		/// <summary>
		/// The method provides custom error handling for errors that occur during acquisition. The application provides the implementation
		/// of the method.
		/// </summary>
		/// <param name="hr">Specifies the error that occurred.</param>
		/// <param name="pszErrorMessage">A string containing the error message.</param>
		/// <param name="nMessageType">
		/// <para>Integer value containing the message type. May be one of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>PHOTOACQUIRE_ERROR_SKIPRETRYCANCEL</c></term>
		/// <term>
		/// Specifies that the error that occurred requires a Skip, Retry, or Cancel response. The <c>pnErrorAdviseResult</c> parameter must
		/// be set to one of the following: <c>PHOTOACQUIRE_RESULT_SKIP</c>, <c>PHOTOACQUIRE_RESULT_SKIP_ALL</c>,
		/// <c>PHOTOACQUIRE_RESULT_RETRY</c>, or <c>PHOTOACQUIRE_RESULT_ABORT</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>PHOTOACQUIRE_ERROR_RETRYCANCEL</c></term>
		/// <term>
		/// Specifies that the error that occurred requires a Retry or Cancel response. The <c>pnErrorAdviseResult</c> parameter must be set
		/// to one of the following: <c>PHOTOACQUIRE_RESULT_RETRY</c> or <c>PHOTOACQUIRE_RESULT_ABORT</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>PHOTOACQUIRE_ERROR_YESNO</c></term>
		/// <term>
		/// Specifies that the error that occurred requires a Yes or No response. The <c>pnErrorAdviseResult</c> parameter must be set to one
		/// of the following: <c>PHOTOACQUIRE_RESULT_YES</c> or <c>PHOTOACQUIRE_RESULT_NO</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>PHOTOACQUIRE_ERROR_OK</c></term>
		/// <term>
		/// Specifies that the error that occurred requires an OK response. The <c>pnErrorAdviseResult</c> parameter must be set to <c>PHOTOACQUIRE_RESULT_OK</c>.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pnErrorAdviseResult">
		/// <para>
		/// Pointer to an integer value containing the error advise result. The result should be one of the acceptable types indicated by the
		/// <c>nMessageType</c> parameter, and must be one of the following:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>PHOTOACQUIRE_RESULT_YES</c></term>
		/// <term>Specifies a Yes response. Valid if <c>nMessageType</c> is <c>PHOTOACQUIRE_ERROR_YESNO</c>.</term>
		/// </item>
		/// <item>
		/// <term><c>PHOTOACQUIRE_RESULT_NO</c></term>
		/// <term>Specifies a No response. Valid if <c>nMessageType</c> is <c>PHOTOACQUIRE_ERROR_YESNO</c>.</term>
		/// </item>
		/// <item>
		/// <term><c>PHOTOACQUIRE_RESULT_OK</c></term>
		/// <term>Specifies an OK response. Valid if <c>nMessageType</c> is <c>PHOTOACQUIRE_ERROR_OK</c>.</term>
		/// </item>
		/// <item>
		/// <term><c>PHOTOACQUIRE_RESULT_SKIP</c></term>
		/// <term>Specifies a Skip response. Valid if <c>nMessageType</c> is <c>PHOTOACQUIRE_ERROR_SKIPRETRYCANCEL</c>.</term>
		/// </item>
		/// <item>
		/// <term><c>PHOTOACQUIRE_RESULT_SKIP_ALL</c></term>
		/// <term>Specifies a Skip All response. Valid if <c>nMessageType</c> is <c>PHOTOACQUIRE_ERROR_SKIPRETRYCANCEL</c>.</term>
		/// </item>
		/// <item>
		/// <term><c>PHOTOACQUIRE_RESULT_RETRY</c></term>
		/// <term>Specifies a Retry response. Valid if <c>nMessageType</c> is <c>PHOTOACQUIRE_ERROR_SKIPRETRYCANCEL</c> or <c>PHOTOACQUIRE_ERROR_RETRYCANCEL</c>.</term>
		/// </item>
		/// <item>
		/// <term><c>PHOTOACQUIRE_RESULT_ABORT</c></term>
		/// <term>Specifies a Cancel response. Valid if <c>nMessageType</c> is <c>PHOTOACQUIRE_ERROR_SKIPRETRYCANCEL</c> or <c>PHOTOACQUIRE_ERROR_RETRYCANCEL</c>.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The method is not yet implemented</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Normally, a message is displayed when an error occurs during image acquisition. If suppression of this message is desired,
		/// implement .
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-erroradvise HRESULT
		// ErrorAdvise( [in] HRESULT hr, [in] LPCWSTR pszErrorMessage, [in] ERROR_ADVISE_MESSAGE_TYPE nMessageType, [out] ERROR_ADVISE_RESULT
		// *pnErrorAdviseResult );
		[PreserveSig]
		HRESULT ErrorAdvise(HRESULT hr, [In, MarshalAs(UnmanagedType.LPWStr)] string pszErrorMessage, [In] ERROR_ADVISE_MESSAGE_TYPE nMessageType,
			out ERROR_ADVISE_RESULT pnErrorAdviseResult);

		/// <summary>
		/// The method overrides the default functionality that displays a message prompting the user for string input during acquisition.
		/// The application provides the implementation of the method.
		/// </summary>
		/// <param name="riidType">Specifies the interface ID of the prompt type. This may only be IID_IUserInputString.</param>
		/// <param name="pUnknown">Pointer to an object of the prompt class. Currently, this must be an IUserInputString object.</param>
		/// <param name="pPropVarResult">
		/// <para>
		/// Pointer to a property variant object representing the descriptive input to be obtained. Must be freed by the caller using PropVariantClear.
		/// </para>
		/// <para>
		/// If the application's implementation of returns a value other than E_NOTIMPL, the value of <c>pPropVarDefault</c> must be copied
		/// to the <c>pPropVarResult</c> parameter.
		/// </para>
		/// </param>
		/// <param name="pPropVarDefault">Pointer to a property variant object representing the default value of the input being requested.</param>
		/// <returns>
		/// <para>
		/// The method returns an <c>HRESULT</c>. Your implementation is not limited to the following return values. Any failing HRESULT
		/// other than E_NOTIMPL is fatal and will cause the transfer to abort.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>Return E_NOTIMPL if the default functionality is desired</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If this method is implemented, the implementation should copy the value of the <c>pPropVarDefault</c> argument to the
		/// <c>pPropVarResult</c> parameter.
		/// </para>
		/// <para>If this method returns an HRESULT other than E_NOTIMPL, the default dialog box that prompts the user will not be displayed.</para>
		/// <para>
		/// If the progress dialog box is suppressed in IPhotoAcquire::Acquire, this method must be implemented in order to assign a default
		/// value to the <c>pPropVarResult</c> parameter. Normally a value is supplied to <c>pPropVarResult</c> in the course of prompting
		/// the user with the default dialog, but when the dialog is suppressed, the application must copy the value of the
		/// <c>pPropVarDefault</c> argument to the <c>pPropVarResult</c> parameter.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquireprogresscb-getuserinput HRESULT
		// GetUserInput( [in] REFIID riidType, [in] IUnknown *pUnknown, [out] PROPVARIANT *pPropVarResult, [in] const PROPVARIANT
		// *pPropVarDefault );
		[PreserveSig]
		HRESULT GetUserInput(in Guid riidType, [In, Optional, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] object pUnknown,
			[Out] PROPVARIANT pPropVarResult, [In, Optional] PROPVARIANT pPropVarDefault);
	}

	/// <summary>The interface is used to work with image acquisition settings, such as file name format.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nn-photoacquire-iphotoacquiresettings
	[PInvokeData("photoacquire.h", MSDNShortId = "NN:photoacquire.IPhotoAcquireSettings")]
	[ComImport, Guid("00F2B868-DD67-487C-9553-049240767E91"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPhotoAcquireSettings
	{
		/// <summary>The method specifies a registry key from which to initialize settings.</summary>
		/// <param name="pszRegistryKey">A string containing the registry key.</param>
		/// <remarks>The structure of the registry has not yet been determined at this point.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresettings-initializefromregistry
		// HRESULT InitializeFromRegistry( [in] LPCWSTR pszRegistryKey );
		void InitializeFromRegistry([In, MarshalAs(UnmanagedType.LPWStr)] string pszRegistryKey);

		/// <summary>The method sets the photo acquire flags.</summary>
		/// <param name="dwPhotoAcquireFlags">Double word value containing the photo acquire flags.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresettings-setflags HRESULT SetFlags(
		// [in] DWORD dwPhotoAcquireFlags );
		void SetFlags([In] PHOTOACQ dwPhotoAcquireFlags);

		/// <summary>The method specifies a format string (template) that specifies the format of file names.</summary>
		/// <param name="pszTemplate">A string containing the format string.</param>
		/// <remarks>
		/// <para>Format strings contain a mix of path literals and tokens. A format string looks like the following:</para>
		/// <code language="none">$(MyPicturesFolder)\$(DateAcquired), $(EventName)\$(EventName) $(SequenceNumber).$(OriginalExtension)</code>
		/// <para>The token format looks like the following, where and are suppressed if the replacement for the yields a zero-length string:</para>
		/// <code language="none">$([OptionalPrefix]TokenIdentifier:SubToken[OptionalSuffix]|AlternateString)</code>
		/// <para>The caret ("^") is an escape character, so "^$" would yield "$" in the final path.</para>
		/// <para>
		/// Parentheses and brackets are not allowed as literals within tokens, but can be used outside of tokens. This means you cannot use
		/// "[", "]", "(", or ")" within the sub-token unless they are escaped with a caret ("^").
		/// </para>
		/// <para>There are a few different classes of tokens, including the following:</para>
		/// <para><c>SHGetSpecialFolder</c> variables such as the following. These must be the first token, and can only occur once, at most:</para>
		/// <list type="bullet">
		/// <item><c>MyPicturesFolder</c></item>
		/// <item><c>MyDocumentsFolder</c></item>
		/// </list>
		/// <para>Session variables such as the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <c>SequenceNumber</c> (The sequence number is used to avoid filename collisions; if it exists, it must be in the file name
		/// portion of the path.) -
		/// </item>
		/// <item><c>DateAcquired</c></item>
		/// <item><c>EventName</c></item>
		/// <item><c>UserName</c></item>
		/// <item><c>MachineName</c></item>
		/// </list>
		/// <para>File and metadata variables such as the following:</para>
		/// <list type="bullet">
		/// <item><c>DateTaken</c></item>
		/// <item><c>OriginalFilename</c></item>
		/// <item><c>OriginalExtension</c></item>
		/// <item><c>CameraModel</c></item>
		/// <item><c>Width</c></item>
		/// <item><c>Height</c></item>
		/// </list>
		/// <para>
		/// Since these tokens are not intended to be visible to users, they will not be localized. For example, <c>$(DateTaken)</c> will be
		/// the same on all versions of Microsoft Windows, regardless of locale or language settings.
		/// </para>
		/// <para>As an example, suppose <c>EventName</c> is "Meghan's Birthday" and the naming pattern is as follows:</para>
		/// <para>The resulting files would be named as follows:</para>
		/// <code language="none">$(MyPicturesFolder)\$(DateAcquired)$([, ]EventName)\$(EventName[ ])$(SequenceNumber).$(OriginalExtension)</code>
		/// <para>C:\Documents and Settings\shauniv\My Documents\My Pictures\2003-11-14, Meghan's Birthday\Meghan's Birthday 001.jpg</para>
		/// <para>C:\Documents and Settings\shauniv\My Documents\My Pictures\2003-11-14, Meghan's Birthday\Meghan's Birthday 002.jpg</para>
		/// <para>C:\Documents and Settings\shauniv\My Documents\My Pictures\2003-11-14, Meghan's Birthday\Meghan's Birthday 003.jpg</para>
		/// <para>C:\Documents and Settings\shauniv\My Documents\My Pictures\2003-11-14, Meghan's Birthday\Meghan's Birthday 004.jpg</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresettings-setoutputfilenametemplate
		// HRESULT SetOutputFilenameTemplate( [in] LPCWSTR pszTemplate );
		void SetOutputFilenameTemplate([In, MarshalAs(UnmanagedType.LPWStr)] string pszTemplate);

		/// <summary>The method sets a value indicating how wide sequential fields in filenames will be.</summary>
		/// <param name="dwWidth">Double word value containing the width of sequential fields.</param>
		/// <remarks>
		/// <para>
		/// If the value passed to is nonzero and the format string specified in SetOutputFileNameTemplate contains a sequential token, this
		/// method sets the width allotted for the sequential token. For example, given the template , if padding is set to 0, a file name
		/// might appear as
		/// </para>
		/// <para>If padding is set to 3, the file name may appear as</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresettings-setsequencepaddingwidth
		// HRESULT SetSequencePaddingWidth( [in] DWORD dwWidth );
		void SetSequencePaddingWidth([In] uint dwWidth);

		/// <summary>The method sets a value indicating whether zeros or spaces are used to pad sequential file names.</summary>
		/// <param name="fZeroPad">Flag that, if set to <see langword="true"/>, indicates that zeros pad sequential file names.</param>
		/// <remarks>
		/// <para>A file name padded with zeros might appear as</para>
		/// <para>The same file name without zero padding might appear as</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresettings-setsequencezeropadding
		// HRESULT SetSequenceZeroPadding( [in] BOOL fZeroPad );
		void SetSequenceZeroPadding([In, MarshalAs(UnmanagedType.Bool)] bool fZeroPad);

		/// <summary>The method sets the group tag for an acquisition session.</summary>
		/// <param name="pszGroupTag">A string containing the group tag.</param>
		/// <remarks>
		/// The group tag is stored as a keyword in each file's metadata. It is also used in the file name if the token is present in the
		/// format string passed to SetOutputFileNameTemplate.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresettings-setgrouptag HRESULT
		// SetGroupTag( [in] LPCWSTR pszGroupTag );
		void SetGroupTag([In, MarshalAs(UnmanagedType.LPWStr)] string pszGroupTag);

		/// <summary>The method sets the acquisition time explicitly.</summary>
		/// <param name="pftAcquisitionTime">Specifies the acquisition time.</param>
		/// <remarks>
		/// This method is typically used to force two sessions to show the same acquisition time. If not explicitly set, acquisition time
		/// defaults to the current machine time.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresettings-setacquisitiontime HRESULT
		// SetAcquisitionTime( [in] const FILETIME *pftAcquisitionTime );
		void SetAcquisitionTime(in FILETIME pftAcquisitionTime);

		/// <summary>The method retrieves the photo acquire flags.</summary>
		/// <returns>Pointer to a double word value containing the photo acquire flags.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresettings-getflags HRESULT GetFlags(
		// [out] DWORD *pdwPhotoAcquireFlags );
		PHOTOACQ GetFlags();

		/// <summary>The method retrieves a format string (template) that specifies the format of file names.</summary>
		/// <returns>Pointer to a string containing the format string.</returns>
		/// <remarks>Format strings contain a mix of path literals and tokens. A format string looks like the following:</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresettings-getoutputfilenametemplate
		// HRESULT GetOutputFilenameTemplate( [out] BSTR *pbstrTemplate );
		[return: MarshalAs(UnmanagedType.BStr)]
		string? GetOutputFilenameTemplate();

		/// <summary>The method retrieves a value indicating how wide sequential fields in file names will be.</summary>
		/// <returns>Pointer to a double word value containing the width of sequential fields.</returns>
		/// <remarks>
		/// <para>
		/// If the format string specified in SetOutputFileNameTemplate contains a sequential token, this method gets the width allotted for
		/// the sequential token.
		/// </para>
		/// <para>If the format string does not contain a sequential token, the value returned by this method is not defined.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresettings-getsequencepaddingwidth
		// HRESULT GetSequencePaddingWidth( [out] DWORD *pdwWidth );
		uint GetSequencePaddingWidth();

		/// <summary>The method retrieves a value that indicates whether zeros or spaces will be used to pad sequential file names.</summary>
		/// <returns>Pointer to a flag that, if set to <see langword="true"/>, indicates that zeros will pad sequential file names.</returns>
		/// <remarks>
		/// <para>A file name padded with zeros might appear as</para>
		/// <para>The same file name without zero padding might appear as</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresettings-getsequencezeropadding
		// HRESULT GetSequenceZeroPadding( [out] BOOL *pfZeroPad );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetSequenceZeroPadding();

		/// <summary>The method retrieves a tag string for the group of files being downloaded from the device.</summary>
		/// <returns>Pointer to a string containing the group tag.</returns>
		/// <remarks>
		/// The group tag is stored as a keyword in each file's metadata. It is also used in the file name if the token is present in the
		/// format string passed to SetOutputFileNameTemplate.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresettings-getgrouptag HRESULT
		// GetGroupTag( [out] BSTR *pbstrGroupTag );
		[return: MarshalAs(UnmanagedType.BStr)]
		string? GetGroupTag();

		/// <summary>The method retrieves the acquisition time of the current session.</summary>
		/// <returns>Specifies acquisition time.</returns>
		/// <remarks>If not set explicitly, the acquisition time defaults to the current machine time.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresettings-getacquisitiontime HRESULT
		// GetAcquisitionTime( [out] FILETIME *pftAcquisitionTime );
		FILETIME GetAcquisitionTime();
	}

	/// <summary>The interface is used for acquisition of items from a device.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nn-photoacquire-iphotoacquiresource
	[PInvokeData("photoacquire.h", MSDNShortId = "NN:photoacquire.IPhotoAcquireSource")]
	[ComImport, Guid("00F2C703-8613-4282-A53B-6EC59C5883AC"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPhotoAcquireSource
	{
		/// <summary>The method retrieves the name of the device, formatted for display.</summary>
		/// <returns>Pointer to a string containing the friendly name.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresource-getfriendlyname HRESULT
		// GetFriendlyName( [out] BSTR *pbstrFriendlyName );
		[return: MarshalAs(UnmanagedType.BStr)]
		string? GetFriendlyName();

		/// <summary>The method retrieves the icons that are used to represent the device.</summary>
		/// <param name="nSize">Integer value containing the size of the icon to retrieve.</param>
		/// <param name="phLargeIcon">Specifies the large icon used for the device.</param>
		/// <param name="phSmallIcon">Specifies the small icon used for the device.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresource-getdeviceicons HRESULT
		// GetDeviceIcons( [in] UINT nSize, [out] HICON *phLargeIcon, [out] HICON *phSmallIcon );
		void GetDeviceIcons([In] uint nSize, out SafeHICON? phLargeIcon, out SafeHICON? phSmallIcon);

		/// <summary>
		/// The InitializeItemList method enumerates transferable items on the device and passes each item to the optional progress callback,
		/// if it is supplied.
		/// </summary>
		/// <param name="fForceEnumeration">
		/// Flag that, if set to <see langword="true"/>, indicates that enumeration will be repeated even if the item list has already been
		/// initialized. If set to <c>FALSE</c>, this flag indicates that repeated calls to after the item list has already been initialized
		/// will not enumerate items again.
		/// </param>
		/// <param name="pPhotoAcquireProgressCB">Optional. Pointer to an IPhotoAcquireProgressCB object.</param>
		/// <param name="pnItemCount">Returns the number of items found.</param>
		/// <remarks>
		/// <para>If IPhotoAcquire::Acquire is called without first calling InitializeItemList, initialization of the item list is done implicitly.</para>
		/// <para>
		/// The first time the item list is initialized—either implicitly through IPhotoAcquire::Acquire or explicitly by calling
		/// InitializeItemList—each item is enumerated. During enumeration, if an IPhotoAcquireProgressCB object is passed to
		/// InitializeItemList, its implementation of StartEnumeration, FoundItem, and EndEnumeration may be used to apply further filtering
		/// or control to the list of items to be transferred.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresource-initializeitemlist HRESULT
		// InitializeItemList( [in] BOOL fForceEnumeration, [in] IPhotoAcquireProgressCB *pPhotoAcquireProgressCB, [out] UINT *pnItemCount );
		void InitializeItemList([In, MarshalAs(UnmanagedType.Bool)] bool fForceEnumeration,
			[In, Optional, MarshalAs(UnmanagedType.Interface)] IPhotoAcquireProgressCB pPhotoAcquireProgressCB, out uint pnItemCount);

		/// <summary>The method retrieves the number of items found by the InitializeItemList method.</summary>
		/// <returns>Pointer to an integer value containing the item count.</returns>
		/// <remarks>Before calling this method, call InitializeItemList to initialize the item list.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresource-getitemcount HRESULT
		// GetItemCount( [out] UINT *pnItemCount );
		uint GetItemCount();

		/// <summary>The method retrieves the IPhotoAcquireItem object at the given index in the list of items.</summary>
		/// <param name="nIndex">Integer value containing the index.</param>
		/// <returns>Pointer to the address of an IPhotoAcquireItem object.</returns>
		/// <remarks>Before calling this method, call InitializeItemList to initialize the item list.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresource-getitemat HRESULT GetItemAt(
		// [in] UINT nIndex, [out] IPhotoAcquireItem **ppPhotoAcquireItem );
		IPhotoAcquireItem? GetItemAt([In] uint nIndex);

		/// <summary>The method obtains an IPhotoAcquireSettings object for working with acquisition settings.</summary>
		/// <returns>Pointer to the address of a photo acquire settings object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresource-getphotoacquiresettings
		// HRESULT GetPhotoAcquireSettings( [out] IPhotoAcquireSettings **ppPhotoAcquireSettings );
		IPhotoAcquireSettings? GetPhotoAcquireSettings();

		/// <summary>The method retrieves the identifier (ID) of the device.</summary>
		/// <returns>Pointer to a string containing the device ID.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoacquiresource-getdeviceid HRESULT
		// GetDeviceId( [out] BSTR *pbstrDeviceId );
		[return: MarshalAs(UnmanagedType.BStr)]
		string? GetDeviceId();

		/// <summary>Binds to object.</summary>
		/// <param name="riid">The IID of the object to which to bind.</param>
		/// <returns>The interface instance requested.</returns>
		[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)]
		object? BindToObject(in Guid riid);
	}

	/// <summary>Implement this interface to get process from an <see cref="IPhotoProgressDialog"/>.</summary>
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00F242D0-B206-4E7D-B4C1-4755BCBB9C9F")]
	public interface IPhotoProgressActionCB
	{
		/// <summary>Does the action.</summary>
		/// <param name="hWndParent">The parent window handle.</param>
		/// <returns>S_OK on success.</returns>
		[PreserveSig]
		HRESULT DoAction(HWND hWndParent);
	}

	/// <summary>
	/// Provides the progress dialog box that may be displayed when enumerating or importing images. The dialog box is modal and runs in its
	/// own thread.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nn-photoacquire-iphotoprogressdialog
	[PInvokeData("photoacquire.h", MSDNShortId = "NN:photoacquire.IPhotoProgressDialog")]
	[ComImport, Guid("00F246F9-0750-4F08-9381-2CD8E906A4AE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(PhotoProgressDialog))]
	public interface IPhotoProgressDialog
	{
		/// <summary>The method creates and displays a progress dialog box that can be shown during image enumeration and acquisition.</summary>
		/// <param name="hWndParent">Handle of the parent window.</param>
		/// <remarks>
		/// <para>The dialog box that is created is modal, and runs in its own thread.</para>
		/// <para>To close the dialog, call Destroy.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoprogressdialog-create HRESULT Create( [in]
		// HWND hwndParent );
		void Create([In] HWND hWndParent);

		/// <summary>The method retrieves the handle to the progress dialog box.</summary>
		/// <returns>Specifies the handle to the progress dialog box.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoprogressdialog-getwindow HRESULT GetWindow(
		// [out] HWND *phwndProgressDialog );
		HWND GetWindow();

		/// <summary>The method closes and disposes of the progress dialog box shown during image enumeration and acquisition.</summary>
		/// <remarks>
		/// Calling is the only way to close the progress dialog box. If is not called, the dialog box will remain open. The dialog box is
		/// not automatically closed when the operation in progress completes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoprogressdialog-destroy HRESULT Destroy();
		void Destroy();

		/// <summary>The method sets the title of the progress dialog box.</summary>
		/// <param name="pszTitle">A string containing the title.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoprogressdialog-settitle HRESULT SetTitle(
		// [in] LPCWSTR pszTitle );
		void SetTitle([In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

		/// <summary>
		/// The method indicates whether to show the check box in the progress dialog box indicating whether to delete images after transfer.
		/// </summary>
		/// <param name="nCheckboxId">Integer containing the check box identifier (ID).</param>
		/// <param name="fShow">Flag that, when set to <see langword="true"/>, indicates that the check box will appear.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoprogressdialog-showcheckbox HRESULT
		// ShowCheckbox( [in] PROGRESS_DIALOG_CHECKBOX_ID nCheckboxId, [in] BOOL fShow );
		void ShowCheckbox([In] PROGRESS_DIALOG_CHECKBOX_ID nCheckboxId, [In, MarshalAs(UnmanagedType.Bool)] bool fShow);

		/// <summary>The method sets the text for the check box in the progress dialog box indicating whether to delete images after transfer.</summary>
		/// <param name="nCheckboxId">Integer containing the check box identifier (ID).</param>
		/// <param name="pszCheckboxText">A string containing the check box text.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoprogressdialog-setcheckboxtext HRESULT
		// SetCheckboxText( [in] PROGRESS_DIALOG_CHECKBOX_ID nCheckboxId, [in] LPCWSTR pszCheckboxText );
		void SetCheckboxText([In] PROGRESS_DIALOG_CHECKBOX_ID nCheckboxId, [In, MarshalAs(UnmanagedType.LPWStr)] string pszCheckboxText);

		/// <summary>The method sets the text for the check box in the progress dialog box indicating whether to delete images after transfer.</summary>
		/// <param name="nCheckboxId">Integer containing the check box identifier (ID).</param>
		/// <param name="fChecked">Flag that, when set to <see langword="true"/>, indicates that the check box will appear checked.</param>
		void SetCheckboxCheck([In] PROGRESS_DIALOG_CHECKBOX_ID nCheckboxId, [In, MarshalAs(UnmanagedType.Bool)] bool fChecked);

		/// <summary>The method sets the tooltip text for the check box in the progress dialog box.</summary>
		/// <param name="nCheckboxId">Integer containing the check box identifier (ID).</param>
		/// <param name="pszCheckboxTooltipText">A string containing the check box tooltip text.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoprogressdialog-setcheckboxtooltip HRESULT
		// SetCheckboxTooltip( [in] PROGRESS_DIALOG_CHECKBOX_ID nCheckboxId, [in] LPCWSTR pszCheckboxTooltipText );
		void SetCheckboxTooltip([In] PROGRESS_DIALOG_CHECKBOX_ID nCheckboxId, [In, MarshalAs(UnmanagedType.LPWStr)] string pszCheckboxTooltipText);

		/// <summary>
		/// The method indicates whether the check box in the progress dialog box (typically indicating whether to delete files after
		/// transfer) is selected.
		/// </summary>
		/// <param name="nCheckboxId">Integer value containing the check box identifier (ID).</param>
		/// <returns>Pointer to a flag that, if set to <see langword="true"/>, indicates that the check box is selected.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoprogressdialog-ischeckboxchecked HRESULT
		// IsCheckboxChecked( [in] PROGRESS_DIALOG_CHECKBOX_ID nCheckboxId, [out] BOOL *pfChecked );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsCheckboxChecked([In] PROGRESS_DIALOG_CHECKBOX_ID nCheckboxId);

		/// <summary>Sets the caption of the progress dialog box.</summary>
		/// <param name="pszTitle">A string containing the title of the progress dialog box.</param>
		/// <remarks>The caption text is displayed above the progress indicator bar in the dialog box.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoprogressdialog-setcaption HRESULT
		// SetCaption( [in] LPCWSTR pszTitle );
		void SetCaption([In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

		/// <summary>
		/// Sets either the thumbnail image displayed in the progress dialog box, the icon in the title bar of the progress dialog box, or
		/// the icon in ALT+TAB key combination windows.
		/// </summary>
		/// <param name="nImageType">
		/// <para>
		/// Integer value indicating the image type to set. Only one type of image type may be set at a time. The values passed to this
		/// parameter should not be considered a bit field and may not be combined with bitwise OR.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>PROGRESS_DIALOG_ICON_SMALL</c></term>
		/// <term>The small icon used in the title bar (normally 16 x 16 pixels).</term>
		/// </item>
		/// <item>
		/// <term><c>PROGRESS_DIALOG_ICON_LARGE</c></term>
		/// <term>The icon used to represent the progress dialog box in Alt-Tab windows (normally 32 x 32 pixels).</term>
		/// </item>
		/// <item>
		/// <term><c>PROGRESS_DIALOG_ICON_THUMBNAIL</c></term>
		/// <term>An icon used in place of the thumbnail (up to 128 x 128 pixels).</term>
		/// </item>
		/// <item>
		/// <term><c>PROGRESS_DIALOG_BITMAP_THUMBNAIL</c></term>
		/// <term>A bitmap thumbnail (up to 128 x 128 pixels, although it will be scaled to fit if it is too large).</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hIcon">Handle to an icon object.</param>
		/// <param name="hBitmap">Handle to a bitmap object representing the thumbnail image.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoprogressdialog-setimage HRESULT SetImage(
		// [in] PROGRESS_DIALOG_IMAGE_TYPE nImageType, [in] HICON hIcon, [in] HBITMAP hBitmap );
		void SetImage([In] PROGRESS_DIALOG_IMAGE_TYPE nImageType, [In, Optional] HICON hIcon, [In, Optional] HBITMAP hBitmap);

		/// <summary>The method sets a value indicating the completed portion of the current operation.</summary>
		/// <param name="nPercent">
		/// Integer value indicating the percentage of the operation that has completed. This value may be between 0 and 100 only.
		/// </param>
		/// <remarks>
		/// If you pass PROGRESS_INDETERMINATE to , the progress bar will not progress from left to right (from 0 to 100%), but will instead
		/// animate to indicate that an operation with an indeterminate end is taking place.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoprogressdialog-setpercentcomplete HRESULT
		// SetPercentComplete( [in] int nPercent );
		void SetPercentComplete([In] int nPercent);

		/// <summary>The method sets the text for the progress bar in the progress dialog box.</summary>
		/// <param name="pszProgressText">A string containing the progress text.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoprogressdialog-setprogresstext HRESULT
		// SetProgressText( [in] LPCWSTR pszProgressText );
		void SetProgressText([In, MarshalAs(UnmanagedType.LPWStr)] string pszProgressText);

		/// <summary>Sets the action link callback.</summary>
		/// <param name="pPhotoProgressActionCB">
		/// A reference to a <see cref="IPhotoProgressActionCB"/> derived class that responds to the action link click.
		/// </param>
		void SetActionLinkCallback([In, Optional, MarshalAs(UnmanagedType.Interface)] IPhotoProgressActionCB pPhotoProgressActionCB);

		/// <summary>The method sets the text for the action link in the progress dialog box.</summary>
		/// <param name="pszCaption">A string containing the action link text.</param>
		void SetActionLinkText([In, MarshalAs(UnmanagedType.LPWStr)] string pszCaption);

		/// <summary>The method indicates whether to show the action link in the progress dialog box.</summary>
		/// <param name="fShow">Flag that, when set to <see langword="true"/>, indicates that the action link will appear.</param>
		void ShowActionLink([In, MarshalAs(UnmanagedType.Bool)] bool fShow);

		/// <summary>The method indicates whether the operation has been canceled via the progress dialog box.</summary>
		/// <returns>Pointer to a flag that, if set to <see langword="true"/>, indicates the action has been canceled.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoprogressdialog-iscancelled HRESULT
		// IsCancelled( [out] BOOL *pfCancelled );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsCancelled();

		/// <summary>Retrieves descriptive information entered by the user, such as the tag name of the images to store.</summary>
		/// <param name="riidType">Specifies the interface identifier (ID) of the prompt type. Currently, the only supported value is IID_IUserInputString.</param>
		/// <param name="pUnknown">Pointer to an object of the prompt class. Currently, the only supported type is IUserInputString.</param>
		/// <param name="pPropVarResult">Pointer to a property variant that stores the user input. Must be freed by the caller using <c>ClearPropVariant</c>.</param>
		/// <param name="pPropVarDefault">Pointer to a property variant containing the default value to be used if no input is supplied.</param>
		/// <remarks>
		/// If the progress dialog box has been suppressed in IPhotoAcquire::Acquire, and IPhotoAcquireProgressCB::GetUserInput is either not
		/// implemented, or returns E_NOTIMPL, this method will return S_FALSE, and <c>pPropVarResult</c> will contain the value stored in
		/// the optional <c>pPropVarDefault</c> argument.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoprogressdialog-getuserinput HRESULT
		// GetUserInput( [in] REFIID riidType, [in] IUnknown *pUnknown, [out] PROPVARIANT *pPropVarResult, [in] const PROPVARIANT
		// *pPropVarDefault );
		[PreserveSig]
		HRESULT GetUserInput(in Guid riidType, [In, Optional, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] object pUnknown,
			[Out] PROPVARIANT pPropVarResult, [In, Optional] PROPVARIANT pPropVarDefault);
	}

	/// <summary>Retrieves descriptive information entered by the user, such as the tag name of the images to store.</summary>
	/// <param name="dlg">The <see cref="IPhotoProgressDialog"/> instance.</param>
	/// <param name="pUnknown">Pointer to an object of the prompt class. Currently, the only supported type is IUserInputString.</param>
	/// <param name="pPropVarDefault">The default value to be used if no input is supplied.</param>
	/// <returns>The user input value, or <see langword="null"/> on error.</returns>
	/// <exception cref="System.ArgumentNullException">dlg</exception>
	/// <remarks>
	/// If the progress dialog box has been suppressed in IPhotoAcquire::Acquire, and IPhotoAcquireProgressCB::GetUserInput is either not
	/// implemented, or returns E_NOTIMPL, this method will return S_FALSE, and <c>pPropVarResult</c> will contain the value stored in the
	/// optional <c>pPropVarDefault</c> argument.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iphotoprogressdialog-getuserinput HRESULT
	// GetUserInput( [in] REFIID riidType, [in] IUnknown *pUnknown, [out] PROPVARIANT *pPropVarResult, [in] const PROPVARIANT
	// *pPropVarDefault );
	[PreserveSig]
	public static string? GetUserInput(this IPhotoProgressDialog dlg, [In, Optional] IUserInputString pUnknown, [In, Optional] string? pPropVarDefault)
	{
		if (dlg == null) throw new ArgumentNullException(nameof(dlg));
		using PROPVARIANT res = new();
		using PROPVARIANT def = pPropVarDefault is null ? new() : new(pPropVarDefault, VarEnum.VT_BSTR);
		return dlg.GetUserInput(typeof(IUserInputString).GUID, pUnknown, res, def) == HRESULT.S_OK ? res.bstrVal : null;
	}

	/// <summary>
	/// The <c>IUserInputString</c> interface represents the object created when asking the user for a string—for example, when obtaining the
	/// name of a tag.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nn-photoacquire-iuserinputstring
	[PInvokeData("photoacquire.h", MSDNShortId = "NN:photoacquire.IUserInputString")]
	[ComImport, Guid("00f243a1-205b-45ba-ae26-abbc53aa7a6f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUserInputString
	{
		/// <summary>The method retrieves the text for the submit button.</summary>
		/// <param name="pbstrSubmitButtonText">Pointer to a string containing the submit button text.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_POINTER</c></term>
		/// <term>A <c>NULL</c> pointer was passed where a non- <c>NULL</c> pointer is expected.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iuserinputstring-getsubmitbuttontext HRESULT
		// GetSubmitButtonText( [out] BSTR *pbstrSubmitButtonText );
		[PreserveSig]
		HRESULT GetSubmitButtonText([MarshalAs(UnmanagedType.BStr)] out string? pbstrSubmitButtonText);

		/// <summary>The method retrieves the title of a prompt if the prompt is a modal dialog box.</summary>
		/// <param name="pbstrPromptTitle">Pointer to a string containing the title of the prompt.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_POINTER</c></term>
		/// <term>A <c>NULL</c> pointer was passed where a non- <c>NULL</c> pointer is expected.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iuserinputstring-getprompt HRESULT GetPrompt(
		// [out] BSTR *pbstrPromptTitle );
		[PreserveSig]
		HRESULT GetPrompt([MarshalAs(UnmanagedType.BStr)] out string? pbstrPromptTitle);

		/// <summary>
		/// The <c>GetStringId</c> method retrieves the unlocalized canonical name for the requested string. For example, when requesting a
		/// tag name, the canonical name might be "TagName".
		/// </summary>
		/// <param name="pbstrStringId">Pointer to a string containing the string identifier (ID).</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_POINTER</c></term>
		/// <term>A <c>NULL</c> pointer was passed where a non- <c>NULL</c> pointer is expected.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iuserinputstring-getstringid HRESULT GetStringId(
		// [out] BSTR *pbstrStringId );
		[PreserveSig]
		HRESULT GetStringId([MarshalAs(UnmanagedType.BStr)] out string? pbstrStringId);

		/// <summary>The method retrieves a value indicating the type of string to obtain from the user.</summary>
		/// <param name="pnStringType">
		/// <para>Pointer to an integer value containing the string type.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>USER_INPUT_DEFAULT</c></term>
		/// <term>Specifies that any string is allowed.</term>
		/// </item>
		/// <item>
		/// <term><c>USER_INPUT_PATH_ELEMENT</c></term>
		/// <term>Specifies that the string will not accept characters that are illegal in file or directory names (such as * or /).</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_POINTER</c></term>
		/// <term>A <c>NULL</c> pointer was passed where a non- <c>NULL</c> pointer is expected.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iuserinputstring-getstringtype HRESULT
		// GetStringType( [out] USER_INPUT_STRING_TYPE *pnStringType );
		[PreserveSig]
		HRESULT GetStringType(out USER_INPUT_STRING_TYPE pnStringType);

		/// <summary>The method retrieves the tooltip text displayed for a control.</summary>
		/// <param name="pbstrTooltipText">Pointer to a string containing the tooltip text.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_POINTER</c></term>
		/// <term>A <c>NULL</c> pointer was passed where a non- <c>NULL</c> pointer is expected.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iuserinputstring-gettooltiptext HRESULT
		// GetTooltipText( [out] BSTR *pbstrTooltipText );
		[PreserveSig]
		HRESULT GetTooltipText([MarshalAs(UnmanagedType.BStr)] out string? pbstrTooltipText);

		/// <summary>The method retrieves the maximum string length the user interface (UI) should allow.</summary>
		/// <param name="pcchMaxLength">Pointer to the size of the maximum string length in characters.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_POINTER</c></term>
		/// <term>A <c>NULL</c> pointer was passed where a non- <c>NULL</c> pointer is expected.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iuserinputstring-getmaxlength HRESULT
		// GetMaxLength( [out] UINT *pcchMaxLength );
		[PreserveSig]
		HRESULT GetMaxLength(out uint pcchMaxLength);

		/// <summary>The method retrieves the default string used to initialize an edit control (or equivalent).</summary>
		/// <param name="pbstrDefault">Pointer to a string containing the default value used to initialize the edit control.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_POINTER</c></term>
		/// <term>The pointer passed was <c>NULL</c>.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iuserinputstring-getdefault HRESULT GetDefault(
		// [out] BSTR *pbstrDefault );
		[PreserveSig]
		HRESULT GetDefault([MarshalAs(UnmanagedType.BStr)] out string? pbstrDefault);

		/// <summary>The method retrieves the number of items in the list of most recently used items.</summary>
		/// <param name="pnMruCount">Pointer to an integer value containing the number of items in the list of most recently used items.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_POINTER</c></term>
		/// <term>A <c>NULL</c> pointer was passed where a non- <c>NULL</c> pointer is expected.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>If an error occurs, <c>pnMruCount</c> will be set to 0.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iuserinputstring-getmrucount HRESULT GetMruCount(
		// [out] UINT *pnMruCount );
		[PreserveSig]
		HRESULT GetMruCount(out uint pnMruCount);

		/// <summary>The method retrieves the entry at the given index in the most recently used list.</summary>
		/// <param name="nIndex">Integer containing the index at which to retrieve the entry.</param>
		/// <param name="pbstrMruEntry">Pointer to a string containing the most recently used entry.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_POINTER</c></term>
		/// <term>A <c>NULL</c> pointer was passed where a non- <c>NULL</c> pointer is expected.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iuserinputstring-getmruentryat HRESULT
		// GetMruEntryAt( [in] UINT nIndex, [out] BSTR *pbstrMruEntry );
		[PreserveSig]
		HRESULT GetMruEntryAt(uint nIndex, [MarshalAs(UnmanagedType.BStr)] out string? pbstrMruEntry);

		/// <summary>The method retrieves the default image used to initialize an edit control.</summary>
		/// <param name="nSize">Integer containing the size of the image.</param>
		/// <param name="phBitmap">Pointer to the handle that specifies the image bitmap.</param>
		/// <param name="phIcon">Pointer to the handle that specifies the image icon.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_POINTER</c></term>
		/// <term>A <c>NULL</c> pointer was passed where a non- <c>NULL</c> pointer is expected.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/photoacquire/nf-photoacquire-iuserinputstring-getimage HRESULT GetImage( [in]
		// UINT nSize, [out] HBITMAP *phBitmap, [out] HICON *phIcon );
		[PreserveSig]
		HRESULT GetImage(uint nSize, out SafeHBITMAP? phBitmap, out SafeHICON? phIcon);
	}

	/// <summary>CLSID_PhotoAcquire</summary>
	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("00F26E02-E9F2-4A9F-9FDD-5A962FB26A98")]
	public class PhotoAcquire { }

	/// <summary>CLSID_PhotoAcquireAutoPlayDropTarget</summary>
	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("00F20EB5-8FD6-4D9D-B75E-36801766C8F1")]
	public class PhotoAcquireAutoPlayDropTarget : IDropTarget
	{
		/// <summary>Indicates whether a drop can be accepted, and, if so, the effect of the drop.</summary>
		/// <param name="pDataObj">
		/// A pointer to the IDataObject interface on the data object. This data object contains the data being transferred in the
		/// drag-and-drop operation. If the drop occurs, this data object will be incorporated into the target.
		/// </param>
		/// <param name="grfKeyState">
		/// The current state of the keyboard modifier keys on the keyboard. Possible values can be a combination of any of the flags
		/// MK_CONTROL, MK_SHIFT, MK_ALT, MK_BUTTON, MK_LBUTTON, MK_MBUTTON, and MK_RBUTTON.
		/// </param>
		/// <param name="pt">A POINTL structure containing the current cursor coordinates in screen coordinates.</param>
		/// <param name="pdwEffect">
		/// On input, pointer to the value of the pdwEffect parameter of the DoDragDrop function. On return, must contain one of the
		/// DROPEFFECT flags, which indicates what the result of the drop operation would be.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pdwEffect parameter is NULL on input.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There was insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You do not call <c>DragEnter</c> directly; instead the DoDragDrop function calls it to determine the effect of a drop the first
		/// time the user drags the mouse into the registered window of a drop target.
		/// </para>
		/// <para>
		/// To implement <c>DragEnter</c>, you must determine whether the target can use the data in the source data object by checking three things:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The format and medium specified by the data object</term>
		/// </item>
		/// <item>
		/// <term>The input value of pdwEffect</term>
		/// </item>
		/// <item>
		/// <term>The state of the modifier keys</term>
		/// </item>
		/// </list>
		/// <para>
		/// To check the format and medium, use the IDataObject pointer passed in the pDataObject parameter to call
		/// IDataObject::EnumFormatEtc so you can enumerate the FORMATETC structures the source data object supports. Then call
		/// IDataObject::QueryGetData to determine whether the data object can render the data on the target by examining the formats and
		/// medium specified for the data object.
		/// </para>
		/// <para>
		/// On entry to <c>IDropTarget::DragEnter</c>, the pdwEffect parameter is set to the effects given to the pdwOkEffect parameter of
		/// the DoDragDrop function. The <c>IDropTarget::DragEnter</c> method must choose one of these effects or disable the drop.
		/// </para>
		/// <para>The following modifier keys affect the result of the drop.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Key Combination</term>
		/// <term>User-Visible Feedback</term>
		/// <term>Drop Effect</term>
		/// </listheader>
		/// <item>
		/// <term>CTRL + SHIFT</term>
		/// <term>=</term>
		/// <term>DROPEFFECT_LINK</term>
		/// </item>
		/// <item>
		/// <term>CTRL</term>
		/// <term>+</term>
		/// <term>DROPEFFECT_COPY</term>
		/// </item>
		/// <item>
		/// <term>No keys or SHIFT</term>
		/// <term>None</term>
		/// <term>DROPEFFECT_MOVE</term>
		/// </item>
		/// </list>
		/// <para>
		/// On return, the method must write the effect, one of the DROPEFFECT flags, to the pdwEffect parameter. DoDragDrop then takes this
		/// parameter and writes it to its pdwEffect parameter. You communicate the effect of the drop back to the source through
		/// <c>DoDragDrop</c> in the pdwEffect parameter. The <c>DoDragDrop</c> function then calls IDropSource::GiveFeedback so that the
		/// source application can display the appropriate visual feedback to the user through the target window.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleidl/nf-oleidl-idroptarget-dragenter HRESULT DragEnter( IDataObject
		// *pDataObj, DWORD grfKeyState, POINTL pt, DWORD *pdwEffect );
		[PreserveSig]
		public virtual extern HRESULT DragEnter([In] IDataObject pDataObj, [In] MouseButtonState grfKeyState, [In] POINT pt, [In, Out] ref DROPEFFECT pdwEffect);

		/// <summary>
		/// Provides target feedback to the user and communicates the drop's effect to the DoDragDrop function so it can communicate the
		/// effect of the drop back to the source.
		/// </summary>
		/// <param name="grfKeyState">
		/// The current state of the keyboard modifier keys on the keyboard. Valid values can be a combination of any of the flags
		/// MK_CONTROL, MK_SHIFT, MK_ALT, MK_BUTTON, MK_LBUTTON, MK_MBUTTON, and MK_RBUTTON.
		/// </param>
		/// <param name="pt">A POINTL structure containing the current cursor coordinates in screen coordinates.</param>
		/// <param name="pdwEffect">
		/// On input, pointer to the value of the pdwEffect parameter of the DoDragDrop function. On return, must contain one of the
		/// DROPEFFECT flags, which indicates what the result of the drop operation would be.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pdwEffect value is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There was insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You do not call <c>DragOver</c> directly. The DoDragDrop function calls this method each time the user moves the mouse across a
		/// given target window. <c>DoDragDrop</c> exits the loop if the drag-and-drop operation is canceled, if the user drags the mouse out
		/// of the target window, or if the drop is completed.
		/// </para>
		/// <para>
		/// In implementing <c>IDropTarget::DragOver</c>, you must provide features similar to those in IDropTarget::DragEnter. You must
		/// determine the effect of dropping the data on the target by examining the FORMATETC defining the data object's formats and medium,
		/// along with the state of the modifier keys. The mouse position may also play a role in determining the effect of a drop. The
		/// following modifier keys affect the result of the drop.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Key Combination</term>
		/// <term>User-Visible Feedback</term>
		/// <term>Drop Effect</term>
		/// </listheader>
		/// <item>
		/// <term>CTRL + SHIFT</term>
		/// <term>=</term>
		/// <term>DROPEFFECT_LINK</term>
		/// </item>
		/// <item>
		/// <term>CTRL</term>
		/// <term>+</term>
		/// <term>DROPEFFECT_COPY</term>
		/// </item>
		/// <item>
		/// <term>No keys or SHIFT</term>
		/// <term>None</term>
		/// <term>DROPEFFECT_MOVE</term>
		/// </item>
		/// </list>
		/// <para>
		/// You communicate the effect of the drop back to the source through DoDragDrop in pdwEffect. The <c>DoDragDrop</c> function then
		/// calls IDropSource::GiveFeedback so the source application can display the appropriate visual feedback to the user.
		/// </para>
		/// <para>
		/// On entry to <c>IDropTarget::DragOver</c>, the pdwEffect parameter must be set to the allowed effects passed to the pdwOkEffect
		/// parameter of the DoDragDrop function. The <c>IDropTarget::DragOver</c> method must be able to choose one of these effects or
		/// disable the drop.
		/// </para>
		/// <para>
		/// Upon return, pdwEffect is set to one of the DROPEFFECT flags. This value is then passed to the pdwEffect parameter of DoDragDrop.
		/// Reasonable values are DROPEFFECT_COPY to copy the dragged data to the target, DROPEFFECT_LINK to create a link to the source
		/// data, or DROPEFFECT_MOVE to allow the dragged data to be permanently moved from the source application to the target.
		/// </para>
		/// <para>
		/// You may also wish to provide appropriate visual feedback in the target window. There may be some target feedback already
		/// displayed from a previous call to <c>IDropTarget::DragOver</c> or from the initial IDropTarget::DragEnter. If this feedback is no
		/// longer appropriate, you should remove it.
		/// </para>
		/// <para>
		/// For efficiency reasons, a data object is not passed in <c>IDropTarget::DragOver</c>. The data object passed in the most recent
		/// call to IDropTarget::DragEnter is available and can be used.
		/// </para>
		/// <para>
		/// When <c>IDropTarget::DragOver</c> has completed its operation, the DoDragDrop function calls IDropSource::GiveFeedback so the
		/// source application can display the appropriate visual feedback to the user.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// This function is called frequently during the DoDragDrop loop so it makes sense to optimize your implementation of the
		/// <c>DragOver</c> method as much as possible.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleidl/nf-oleidl-idroptarget-dragover HRESULT DragOver( DWORD grfKeyState,
		// POINTL pt, DWORD *pdwEffect );
		[PreserveSig]
		public virtual extern HRESULT DragOver([In] MouseButtonState grfKeyState, [In] POINT pt, [In, Out] ref DROPEFFECT pdwEffect);

		/// <summary>Removes target feedback and releases the data object.</summary>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>You do not call this method directly. The DoDragDrop function calls this method in either of the following cases:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>When the user drags the cursor out of a given target window.</term>
		/// </item>
		/// <item>
		/// <term>When the user cancels the current drag-and-drop operation.</term>
		/// </item>
		/// </list>
		/// <para>
		/// To implement <c>IDropTarget::DragLeave</c>, you must remove any target feedback that is currently displayed. You must also
		/// release any references you hold to the data transfer object.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleidl/nf-oleidl-idroptarget-dragleave HRESULT DragLeave( );
		[PreserveSig]
		public virtual extern HRESULT DragLeave();

		/// <summary>Incorporates the source data into the target window, removes target feedback, and releases the data object.</summary>
		/// <param name="pDataObj">A pointer to the IDataObject interface on the data object being transferred in the drag-and-drop operation.</param>
		/// <param name="grfKeyState">
		/// The current state of the keyboard modifier keys on the keyboard. Possible values can be a combination of any of the flags
		/// MK_CONTROL, MK_SHIFT, MK_ALT, MK_BUTTON, MK_LBUTTON, MK_MBUTTON, and MK_RBUTTON.
		/// </param>
		/// <param name="pt">A POINTL structure containing the current cursor coordinates in screen coordinates.</param>
		/// <param name="pdwEffect">
		/// On input, pointer to the value of the pdwEffect parameter of the DoDragDrop function. On return, must contain one of the
		/// DROPEFFECT flags, which indicates what the result of the drop operation would be.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pdwEffect parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You do not call this method directly. The DoDragDrop function calls this method when the user completes the drag-and-drop operation.
		/// </para>
		/// <para>
		/// In implementing <c>Drop</c>, you must incorporate the data object into the target. Use the formats available in IDataObject,
		/// available through pDataObj, along with the current state of the modifier keys to determine how the data is to be incorporated,
		/// such as linking or embedding.
		/// </para>
		/// <para>In addition to incorporating the data, you must also clean up as you do in the IDropTarget::DragLeave method:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Remove any target feedback that is currently displayed.</term>
		/// </item>
		/// <item>
		/// <term>Release any references to the data object.</term>
		/// </item>
		/// </list>
		/// <para>
		/// You also pass the effect of this operation back to the source application through DoDragDrop, so the source application can clean
		/// up after the drag-and-drop operation is complete:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Remove any source feedback that is being displayed.</term>
		/// </item>
		/// <item>
		/// <term>Make any necessary changes to the data, such as removing the data if the operation was a move.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleidl/nf-oleidl-idroptarget-drop HRESULT Drop( IDataObject *pDataObj, DWORD
		// grfKeyState, POINTL pt, DWORD *pdwEffect );
		[PreserveSig]
		public virtual extern HRESULT Drop([In] IDataObject pDataObj, [In] MouseButtonState grfKeyState, [In] POINT pt, [In, Out] ref DROPEFFECT pdwEffect);
	}

	/// <summary>CLSID_PhotoAcquireAutoPlayHWEventHandler</summary>
	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("00F2B433-44E4-4D88-B2B0-2698A0A91DBA")]
	public class PhotoAcquireAutoPlayHWEventHandler : IHWEventHandler
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
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ihweventhandler-initialize HRESULT Initialize( LPCWSTR
		// pszParams );
		[PreserveSig]
		public virtual extern HRESULT Initialize([MarshalAs(UnmanagedType.LPWStr)] string pszParams);

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
		/// A pointer to a string buffer that contains the event type. The event types include DeviceArrival, DeviceRemoval, MediaArrival,
		/// and MediaRemoval.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The event types are not C/C++ language constants; they are literal text strings.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ihweventhandler-handleevent HRESULT HandleEvent( LPCWSTR
		// pszDeviceID, LPCWSTR pszAltDeviceID, LPCWSTR pszEventType );
		[PreserveSig]
		public virtual extern HRESULT HandleEvent([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceID,
			[MarshalAs(UnmanagedType.LPWStr)] string pszAltDeviceID, [MarshalAs(UnmanagedType.LPWStr)] string pszEventType);

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
		public virtual extern HRESULT HandleEventWithContent([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceID,
			[MarshalAs(UnmanagedType.LPWStr)] string pszAltDeviceID, [MarshalAs(UnmanagedType.LPWStr)] string pszEventType,
			[MarshalAs(UnmanagedType.LPWStr)] string pszContentTypeHandler, IDataObject pdataobject);
	}

	/// <summary>CLSID_PhotoAcquireDeviceSelectionDialog</summary>
	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("00F29A34-B8A1-482C-BCF8-3AC7B0FE8F62")]
	public class PhotoAcquireDeviceSelectionDialog { }

	/// <summary>CLSID_PhotoAcquireOptionsDialog</summary>
	[ComImport, Guid("00F210A1-62F0-438B-9F7E-9618D72A1831"), ClassInterface(ClassInterfaceType.None)]
	public class PhotoAcquireOptionsDialog { }

	/// <summary>CLSID_PhotoProgressDialog</summary>
	[ComImport, Guid("00F24CA0-748F-4E8A-894F-0E0357C6799F"), ClassInterface(ClassInterfaceType.None)]
	public class PhotoProgressDialog { }
}