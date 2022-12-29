## Assembly report for Vanara.PInvoke.PhotoAcquire.dll
PInvoke API (methods, structures and constants) imported from Windows Photo Acquisition.
### Enumerations
Enum | Description | Values
---- | ---- | ----
[Vanara.PInvoke.PhotoAcquisition.DEVICE_SELECTION_DEVICE_TYPE](https://github.com/dahall/Vanara/search?l=C%23&q=DEVICE_SELECTION_DEVICE_TYPE) | The enumeration type indicates the type of a selected device. | DST_UNKNOWN_DEVICE, DST_WPD_DEVICE, DST_WIA_DEVICE, DST_STI_DEVICE, DSF_TWAIN_DEVICE, DST_FS_DEVICE, DST_DV_DEVICE
[Vanara.PInvoke.PhotoAcquisition.DSF](https://github.com/dahall/Vanara/search?l=C%23&q=DSF) |  | DSF_WPD_DEVICES, DSF_WIA_CAMERAS, DSF_WIA_SCANNERS, DSF_STI_DEVICES, DSF_TWAIN_DEVICES, DSF_FS_DEVICES, DSF_DV_DEVICES, DSF_ALL_DEVICES, DSF_CPL_MODE, DSF_SHOW_OFFLINE
[Vanara.PInvoke.PhotoAcquisition.ERROR_ADVISE_MESSAGE_TYPE](https://github.com/dahall/Vanara/search?l=C%23&q=ERROR_ADVISE_MESSAGE_TYPE) | The enumeration type indicates the type of error values that can be passed to the <c>nMessageType</c> parameter of IPhotoAcquireProgressCB::ErrorAdvise. | PHOTOACQUIRE_ERROR_SKIPRETRYCANCEL, PHOTOACQUIRE_ERROR_RETRYCANCEL, PHOTOACQUIRE_ERROR_YESNO, PHOTOACQUIRE_ERROR_OK
[Vanara.PInvoke.PhotoAcquisition.ERROR_ADVISE_RESULT](https://github.com/dahall/Vanara/search?l=C%23&q=ERROR_ADVISE_RESULT) | The enumeration type indicates the type of error values that can be assigned to the <c>pnErrorAdviseResult</c> parameter of IPhotoAcquireProgressCB::ErrorAdvise. | PHOTOACQUIRE_RESULT_YES, PHOTOACQUIRE_RESULT_NO, PHOTOACQUIRE_RESULT_OK, PHOTOACQUIRE_RESULT_SKIP, PHOTOACQUIRE_RESULT_SKIP_ALL, PHOTOACQUIRE_RESULT_RETRY, PHOTOACQUIRE_RESULT_ABORT
[Vanara.PInvoke.PhotoAcquisition.PAPS](https://github.com/dahall/Vanara/search?l=C%23&q=PAPS) | Specifies a double word value indicating whether this method is being called before or after processing an item. | PAPS_PRESAVE, PAPS_POSTSAVE, PAPS_CLEANUP
[Vanara.PInvoke.PhotoAcquisition.PHOTOACQ](https://github.com/dahall/Vanara/search?l=C%23&q=PHOTOACQ) | Photo acquire flags. | PHOTOACQ_RUN_DEFAULT, PHOTOACQ_NO_GALLERY_LAUNCH, PHOTOACQ_DISABLE_AUTO_ROTATE, PHOTOACQ_DISABLE_PLUGINS, PHOTOACQ_DISABLE_GROUP_TAG_PROMPT, PHOTOACQ_DISABLE_DB_INTEGRATION, PHOTOACQ_DELETE_AFTER_ACQUIRE, PHOTOACQ_DISABLE_DUPLICATE_DETECTION, PHOTOACQ_ENABLE_THUMBNAIL_CACHING, PHOTOACQ_DISABLE_METADATA_WRITE, PHOTOACQ_DISABLE_THUMBNAIL_PROGRESS, PHOTOACQ_DISABLE_SETTINGS_LINK, PHOTOACQ_ABORT_ON_SETTINGS_UPDATE, PHOTOACQ_IMPORT_VIDEO_AS_MULTIPLE_FILES
[Vanara.PInvoke.PhotoAcquisition.PROGRESS_DIALOG_CHECKBOX_ID](https://github.com/dahall/Vanara/search?l=C%23&q=PROGRESS_DIALOG_CHECKBOX_ID) | The enumeration type indicates the check box on the IPhotoProgressDialog object. | PROGRESS_DIALOG_CHECKBOX_ID_DEFAULT
[Vanara.PInvoke.PhotoAcquisition.PROGRESS_DIALOG_IMAGE_TYPE](https://github.com/dahall/Vanara/search?l=C%23&q=PROGRESS_DIALOG_IMAGE_TYPE) | The enumeration type indicates the image type set in IPhotoProgressDialog::SetImage. | PROGRESS_DIALOG_ICON_SMALL, PROGRESS_DIALOG_ICON_LARGE, PROGRESS_DIALOG_ICON_THUMBNAIL, PROGRESS_DIALOG_BITMAP_THUMBNAIL
[Vanara.PInvoke.PhotoAcquisition.USER_INPUT_STRING_TYPE](https://github.com/dahall/Vanara/search?l=C%23&q=USER_INPUT_STRING_TYPE) | The enumeration type indicates the type of string to obtain from the user in IPhotoAcquireProgressCB::GetUserInput. | USER_INPUT_DEFAULT, USER_INPUT_PATH_ELEMENT
### Interfaces
Interface | Description
---- | ----
[Vanara.PInvoke.PhotoAcquisition.IPhotoAcquire](https://github.com/dahall/Vanara/search?l=C%23&q=IPhotoAcquire) | The interface provides methods for acquiring photos from a device.
[Vanara.PInvoke.PhotoAcquisition.IPhotoAcquireDeviceSelectionDialog](https://github.com/dahall/Vanara/search?l=C%23&q=IPhotoAcquireDeviceSelectionDialog) | Provides a dialog box for selecting the device to acquire images from.
[Vanara.PInvoke.PhotoAcquisition.IPhotoAcquireItem](https://github.com/dahall/Vanara/search?l=C%23&q=IPhotoAcquireItem) | The interface provides methods for working with items as they are acquired from a device.
[Vanara.PInvoke.PhotoAcquisition.IPhotoAcquireOptionsDialog](https://github.com/dahall/Vanara/search?l=C%23&q=IPhotoAcquireOptionsDialog) | The interface is used to display an options dialog box in which the user can select photo acquisition settings such as file name formats, as well as whether or not to rotate images, to prompt for a tag name, or to erase photos from the camera after importing.
[Vanara.PInvoke.PhotoAcquisition.IPhotoAcquirePlugin](https://github.com/dahall/Vanara/search?l=C%23&q=IPhotoAcquirePlugin) | Implement the interface when you want to create a plug-in to run alongside the Windows Vista user interface (UI) for image acquisition. Registry settings are required to enable the plug-in.
[Vanara.PInvoke.PhotoAcquisition.IPhotoAcquireProgressCB](https://github.com/dahall/Vanara/search?l=C%23&q=IPhotoAcquireProgressCB) | The interface may be implemented if you wish to do extra processing at various stages in the acquisition process.
[Vanara.PInvoke.PhotoAcquisition.IPhotoAcquireSettings](https://github.com/dahall/Vanara/search?l=C%23&q=IPhotoAcquireSettings) | The interface is used to work with image acquisition settings, such as file name format.
[Vanara.PInvoke.PhotoAcquisition.IPhotoAcquireSource](https://github.com/dahall/Vanara/search?l=C%23&q=IPhotoAcquireSource) | The interface is used for acquisition of items from a device.
[Vanara.PInvoke.PhotoAcquisition.IPhotoProgressActionCB](https://github.com/dahall/Vanara/search?l=C%23&q=IPhotoProgressActionCB) | Implement this interface to get process from an `Vanara.PInvoke.PhotoAcquisition.IPhotoProgressDialog`.
[Vanara.PInvoke.PhotoAcquisition.IPhotoProgressDialog](https://github.com/dahall/Vanara/search?l=C%23&q=IPhotoProgressDialog) | Provides the progress dialog box that may be displayed when enumerating or importing images. The dialog box is modal and runs in its own thread.
[Vanara.PInvoke.PhotoAcquisition.IUserInputString](https://github.com/dahall/Vanara/search?l=C%23&q=IUserInputString) | The <c>IUserInputString</c> interface represents the object created when asking the user for a string—for example, when obtaining the name of a tag.
### Classes
Class | Description
---- | ----
[Vanara.PInvoke.PhotoAcquisition.PhotoAcquire](https://github.com/dahall/Vanara/search?l=C%23&q=PhotoAcquire) | CLSID_PhotoAcquire
[Vanara.PInvoke.PhotoAcquisition.PhotoAcquireDeviceSelectionDialog](https://github.com/dahall/Vanara/search?l=C%23&q=PhotoAcquireDeviceSelectionDialog) | CLSID_PhotoAcquireDeviceSelectionDialog
[Vanara.PInvoke.PhotoAcquisition.PhotoAcquireOptionsDialog](https://github.com/dahall/Vanara/search?l=C%23&q=PhotoAcquireOptionsDialog) | CLSID_PhotoAcquireOptionsDialog
[Vanara.PInvoke.PhotoAcquisition](https://github.com/dahall/Vanara/search?l=C%23&q=PhotoAcquisition) | Enums and interfaces from the Windows Photo Acquisition API.
[Vanara.PInvoke.PhotoAcquisition.PhotoProgressDialog](https://github.com/dahall/Vanara/search?l=C%23&q=PhotoProgressDialog) | CLSID_PhotoProgressDialog
