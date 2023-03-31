using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Gdi32
{
	/*
	BRUSHOBJ_hGetColorTransform	The BRUSHOBJ_hGetColorTransform function retrieves the color transform for the specified brush.
	BRUSHOBJ_pvAllocRbrush	The BRUSHOBJ_pvAllocRbrush function allocates memory for the driver's realization of a specified brush.
	BRUSHOBJ_pvGetRbrush	The BRUSHOBJ_pvGetRbrush function retrieves a pointer to the driver's realization of a specified brush.
	BRUSHOBJ_ulGetBrushColor	The BRUSHOBJ_ulGetBrushColor function returns the RGB color of the specified solid brush.
	CLIPOBJ_bEnum	The CLIPOBJ_bEnum function enumerates a batch of rectangles from a specified clip region; a prior call to CLIPOBJ_cEnumStart determines the order of enumeration.
	CLIPOBJ_cEnumStart	The CLIPOBJ_cEnumStart function sets parameters for enumerating rectangles in a specified clip region.
	CLIPOBJ_ppoGetPath	The CLIPOBJ_ppoGetPath function creates a PATHOBJ structure that contains the outline of the specified clip region.
	DrvAlphaBlend	The DrvAlphaBlend function provides bit-block transfer capabilities with alpha blending.
	DrvAssertMode	The DrvAssertMode function sets the mode of the specified physical device to either the mode specified when the PDEV was initialized or to the default mode of the hardware.
	DrvBitBlt	The DrvBitBlt function provides general bit-block transfer capabilities between device-managed surfaces, between GDI-managed standard-format bitmaps, or between a device-managed surface and a GDI-managed standard-format bitmap.
	DrvCompletePDEV	The DrvCompletePDEV function stores the GDI handle of the physical device being created.
	DrvCopyBits	The DrvCopyBits function translates between device-managed raster surfaces and GDI standard-format bitmaps.
	DrvCreateDeviceBitmap	The DrvCreateDeviceBitmap function creates and manages bitmaps.
	DrvDeleteDeviceBitmap	The DrvDeleteDeviceBitmap function deletes a device bitmap created by DrvCreateDeviceBitmap.
	DrvDeriveSurface	The DrvDeriveSurface function derives a GDI surface from the specified DirectDraw surface.
	DrvDescribePixelFormat	The DrvDescribePixelFormat function describes the pixel format for a device-specified PDEV by writing a pixel format description to a PIXELFORMATDESCRIPTOR structure.
	DrvDestroyFont	The DrvDestroyFont function notifies the driver that a font realization is no longer needed and that the driver can now free any associated data structures it has allocated.
	DrvDisableDirectDraw	The DrvDisableDirectDraw function disables hardware for DirectDraw use.
	DrvDisableDriver	The DrvDisableDriver function is used by GDI to notify a driver that it no longer requires the driver and is ready to unload it.
	DrvDisablePDEV	The DrvDisablePDEV function is used by GDI to notify a driver that the specified PDEV is no longer needed.
	DrvDisableSurface	The DrvDisableSurface function is used by GDI to notify a driver that the surface created by DrvEnableSurface for the current device is no longer needed.
	DrvDitherColor	The DrvDitherColor function requests the device to create a brush dithered against a device palette.
	DrvDrawEscape	The DrvDrawEscape function is the entry point that serves more than one function call; the particular function depends on the value of the iEsc parameter.
	DrvEnableDirectDraw	The DrvEnableDirectDraw function enables hardware for DirectDraw use.
	DrvEnableDriver	The DrvEnableDriver function is the initial driver entry point exported by the driver DLL.
	DrvEnablePDEV	The DrvEnablePDEV function returns a description of the physical device's characteristics to GDI.
	DrvEnableSurface	The DrvEnableSurface function sets up a surface to be drawn on and associates it with a given physical device.
	DrvEndDoc	The DrvEndDoc function is called by GDI when it has finished sending a document to the driver for rendering.
	DrvEscape	The DrvEscape function is used for retrieving information from a device that is not available in a device-independent device driver interface; the particular query depends on the value of the iEsc parameter.
	DrvFillPath	The DrvFillPath function is an optional entry point to handle the filling of closed paths.
	DrvFontManagement	The DrvFontManagement function is an optional entry point provided for PostScript devices.
	DrvFree	The DrvFree function is used to notify the driver that the specified structure is no longer needed.
	DrvGetDirectDrawInfo	The DrvGetDirectDrawInfo function returns the capabilities of the graphics hardware.
	DrvGetGlyphMode	The DrvGetGlyphMode function tells GDI how to cache glyph information.
	DrvGetModes	The DrvGetModes function lists the modes supported by a given device.
	DrvGetTrueTypeFile	The DrvGetTrueTypeFile function accesses a memory-mapped TrueType font file.
	DrvGradientFill	The DrvGradientFill function shades the specified primitives.
	DrvIcmCheckBitmapBits	The DrvIcmCheckBitmapBits function checks whether the pixels in the specified bitmap lie within the device gamut of the specified transform.
	DrvIcmCreateColorTransform	The DrvIcmCreateColorTransform function creates an ICM color transform.
	DrvIcmDeleteColorTransform	The DrvIcmDeleteColorTransform function deletes the specified color transform.
	DrvIcmSetDeviceGammaRamp	The DrvIcmSetDeviceGammaRamp function sets the hardware gamma ramp of the specified display device.
	DrvLineTo	The DrvLineTo function draws a single, solid, integer-only cosmetic line.
	DrvLoadFontFile	The DrvLoadFontFile function receives information from GDI relating to loading and mapping font files.
	DrvMovePointer	The DrvMovePointer function moves the pointer to a new position and ensures that GDI does not interfere with the display of the pointer.
	DrvNextBand	The DrvNextBand function is called by GDI when it has finished drawing a band for a physical page, so the driver can send the next band to the printer.
	DrvNotify	The DrvNotify function allows a display driver to be notified about certain information by GDI.
	DrvPaint	The DrvPaint function is obsolete, and is no longer called by GDI in Windows 2000 and later. New drivers should implement one or more of DrvFillPath, DrvStrokePath, or DrvStrokeAndFillPath.
	DrvPlgBlt	The DrvPlgBlt function provides rotate bit-block transfer capabilities between combinations of device-managed and GDI-managed surfaces.
	DrvQueryAdvanceWidths	The DrvQueryAdvanceWidths function returns character advance widths for a specified set of glyphs.
	DrvQueryDeviceSupport	The DrvQueryDeviceSupport function returns requested device-specific information.
	DrvQueryDriverInfo	The DrvQueryDriverInfo function returns requested driver-specific information.
	DrvQueryFont	The DrvQueryFont function is used by GDI to get the IFIMETRICS structure for a given font.
	DrvQueryFontCaps	The DrvQueryFontCaps function defines the capabilities of the font driver.
	DrvQueryFontData	The DrvQueryFontData function retrieves information about a realized font.
	DrvQueryFontFile	The DrvQueryFontFile function provides font file information.
	DrvQueryFontTree	The DrvQueryFontTree function provides GDI with a pointer to a structure that defines one of the following:A mapping from Unicode to glyph handles, including glyph variantsA mapping of kerning pairs to kerning handles
	DrvQueryPerBandInfo	A printer graphics DLL's DrvQueryPerBandInfo function is called by GDI before it begins drawing a band for a physical page, so the driver can supply GDI with band-specific information.
	DrvQueryTrueTypeOutline	The DrvQueryTrueTypeOutline function retrieves glyph outlines in native TrueType format.
	DrvQueryTrueTypeTable	The DrvQueryTrueTypeTable function accesses specific tables in a TrueType font-description file.
	DrvRealizeBrush	The DrvRealizeBrush function requests that the driver realize a specified brush for a specified surface.
	DrvResetDevice	The DrvResetDevice function resets a device that is inoperable or unresponsive.
	DrvResetPDEV	The DrvResetPDEV function allows a graphics driver to transfer the state of the driver from an old PDEV structure to a new PDEV structure when a Win32 application calls ResetDC.
	DrvSaveScreenBits	The DrvSaveScreenBits function causes a display driver to save or restore a given rectangle of the displayed image.
	DrvSendPage	A printer graphics DLL's DrvSendPage function is called by GDI when it has finished drawing a physical page, so the driver can send the page to the printer.
	DrvSetPalette	The DrvSetPalette function requests that the driver realize the palette for a specified device.
	DrvSetPixelFormat	The DrvSetPixelFormat function sets the pixel format of a window.
	DrvSetPointerShape	The DrvSetPointerShape function is used to request the driver to take the pointer off the display, if the driver has drawn it there; to attempt to set a new pointer shape; and to put the new pointer on the display at a specified position.
	DrvStartBanding	The DrvStartBanding function is called by GDI when it is ready to start sending bands of a physical page to the driver for rendering.
	DrvStartDoc	The DrvStartDoc function is called by GDI when it is ready to start sending a document to the driver for rendering.
	DrvStartPage	The DrvStartPage function is called by GDI when it is ready to start sending the contents of a physical page to the driver for rendering.
	DrvStretchBlt	The DrvStretchBlt function provides stretching bit-block transfer capabilities between any combination of device-managed and GDI-managed surfaces.
	DrvStretchBltROP	The DrvStretchBltROP function performs a stretching bit-block transfer using a ROP.
	DrvStrokeAndFillPath	The DrvStrokeAndFillPath function strokes (outlines) and fills a path concurrently.
	DrvStrokePath	The DrvStrokePath function strokes (outlines) a path.
	DrvSwapBuffers	The DrvSwapBuffers function displays the contents of the window's associated hidden buffer on the specified surface.
	DrvSynchronize	The DrvSynchronize function informs the driver that GDI needs to access a device-managed surface. This function allows asynchronous drawing operations performed by a device's coprocessor to be coordinated with GDI accesses.
	DrvSynchronizeSurface	The DrvSynchronizeSurface function informs the driver that GDI needs to write to the specified surface. This function allows drawing operations performed by a device's coprocessor to be coordinated with GDI.
	DrvTextOut	The DrvTextOut function is the entry point from GDI that calls for the driver to render a set of glyphs at specified positions.
	DrvTransparentBlt	The DrvTransparentBlt function provides bit-block transfer capabilities with transparency.
	DrvUnloadFontFile	The DrvUnloadFontFile function informs a font driver that the specified font file is no longer needed.
	EngAcquireSemaphore	The EngAcquireSemaphore function acquires the resource associated with the semaphore for exclusive access by the calling thread.
	EngAllocMem	The EngAllocMem function allocates a block of memory and inserts a caller-supplied tag before the allocation.
	EngAllocPrivateUserMem	The EngAllocPrivateUserMem function allocates a block of user memory from the address space of a specified process and inserts a caller-supplied tag before the allocation.
	EngAllocUserMem	The EngAllocUserMem function allocates a block of memory from the address space of the current process and inserts a caller-supplied tag before the allocation.
	EngAlphaBlend	The EngAlphaBlend function provides bit-block transfer capabilities with alpha blending.
	EngAssociateSurface	The EngAssociateSurface function marks a given surface as belonging to a specified device.
	EngBitBlt	The EngBitBlt function provides general bit-block transfer capabilities either between device-managed surfaces, or between a device-managed surface and a GDI-managed standard format bitmap.
	EngBugCheckEx	The EngBugCheckEx function brings down the system in a controlled manner when the caller discovers an unrecoverable error that would corrupt the system if the caller continued to run.
	EngCheckAbort	The EngCheckAbort function enables a printer graphics DLL to determine if a print job should be terminated.
	EngClearEvent	The EngClearEvent function sets a specified event object to the nonsignaled state.
	EngComputeGlyphSet	The EngComputeGlyphSet function computes the glyph set supported on a device.
	EngControlSprites	The EngControlSprites function tears down or redraws sprites on the specified WNDOBJ area.
	EngCopyBits	The EngCopyBits function translates between device-managed raster surfaces and GDI standard-format bitmaps.
	EngCreateBitmap	The EngCreateBitmap function requests that GDI create and manage a bitmap.
	EngCreateClip	The EngCreateClip function creates a CLIPOBJ structure that the driver uses in callbacks.
	EngCreateDeviceBitmap	The EngCreateDeviceBitmap function requests GDI to create a handle for a device bitmap.
	EngCreateDeviceSurface	The EngCreateDeviceSurface function creates and returns a handle for a device surface that the driver will manage.
	EngCreateDriverObj	The EngCreateDriverObj function creates a DRIVEROBJ structure.
	EngCreateEvent	The EngCreateEvent function creates a synchronization event object that can be used to synchronize hardware access between a display driver and the video miniport driver.
	EngCreatePalette	The EngCreatePalette function sends a request to GDI to create an RGB palette.
	EngCreatePath	The EngCreatePath function allocates a path for the driver's temporary use.
	EngCreateSemaphore	The EngCreateSemaphore function creates a semaphore object.
	EngCreateWnd	The EngCreateWnd function creates a WNDOBJ structure for the window referenced by hwnd.
	EngDebugBreak	The EngDebugBreak function causes a breakpoint in the current process to occur.
	EngDebugPrint	The EngDebugPrint function prints the specified debug message to the kernel debugger.
	EngDeleteClip	The EngDeleteClip function deletes a CLIPOBJ structure allocated by EngCreateClip.
	EngDeleteDriverObj	The EngDeleteDriverObj function frees the handle used for tracking a device-managed resource.
	EngDeleteEvent	The EngDeleteEvent function deletes the specified event object.
	EngDeleteFile	The EngDeleteFile function deletes a file.
	EngDeletePalette	The EngDeletePalette function sends a request to GDI to delete the specified palette.
	EngDeletePath	The EngDeletePath function deletes a path previously allocated by EngCreatePath.
	EngDeleteSafeSemaphore	The EngDeleteSafeSemaphore function removes a reference to the specified safe semaphore.
	EngDeleteSemaphore	The EngDeleteSemaphore function deletes a semaphore object from the system's resource list.
	EngDeleteSurface	The EngDeleteSurface function deletes the specified surface.
	EngDeleteWnd	The EngDeleteWnd function deletes a WNDOBJ structure.
	EngDeviceIoControl	The EngDeviceIoControl function sends a control code to the specified video miniport driver, causing the device to perform the specified operation.
	EngDitherColor	The EngDitherColor function returns a standard 8x8 dither that approximates the specified RGB color.
	EngEnumForms	The EngEnumForms function enumerates the forms supported by the specified printer.
	EngEraseSurface	The EngEraseSurface function calls GDI to erase the surface; a given rectangle on the surface will be filled with the given color.
	EngFillPath	The EngFillPath function fills a path.
	EngFindImageProcAddress	The EngFindImageProcAddress function returns the address of a function within an executable module.
	EngFindResource	The EngFindResource function determines the location of a resource in a module.
	EngFntCacheAlloc	The EngFntCacheAlloc function allocates storage for a font that is to be stored in cached memory.
	EngFntCacheFault	The EngFntCacheFault function reports an error to the font engine if the font driver encountered an error reading from or writing to a font data cache.
	EngFntCacheLookUp	The EngFntCacheLookUp function retrieves the address of cached font file data.
	EngFreeMem	The EngFreeMem function deallocates a block of system memory.
	EngFreeModule	The EngFreeModule function unmaps a file from system memory.
	EngFreePrivateUserMem	The EngFreePrivateUserMem function deallocates a block of private user memory.
	EngFreeUserMem	The EngFreeUserMem function deallocates a block of user memory.
	EngGetCurrentCodePage	The EngGetCurrentCodePage function returns the system's default OEM and ANSI code pages.
	EngGetCurrentProcessId	The EngGetCurrentProcessId function identifies an application's current process.
	EngGetCurrentThreadId	The EngGetCurrentThreadId function identifies an application's current thread.
	EngGetDriverName	The EngGetDriverName function returns the name of the driver's DLL.
	EngGetFileChangeTime	The EngGetFileChangeTime function retrieves a file's last write time.
	EngGetFilePath	The EngGetFilePath function determines the file path associated with the specified font file.
	EngGetForm	The EngGetForm function gets the FORM_INFO_1 details for the specified form.
	EngGetLastError	The EngGetLastError function returns the last error code logged by GDI for the calling thread.
	EngGetPrinter	The EngGetPrinter function retrieves information about the specified printer.
	EngGetPrinterData	The EngGetPrinterData function retrieves configuration data for the specified printer.
	EngGetPrinterDataFileName	The EngGetPrinterDataFileName function retrieves the string name of the printer's data file.
	EngGetPrinterDriver	The EngGetPrinterDriver function retrieves driver data for the specified printer.
	EngGetProcessHandle	The EngGetProcessHandle function retrieves a handle to the current client process.
	EngGetType1FontList	The EngGetType1FontList function retrieves a list of PostScript Type 1 fonts that are installed both locally and remotely.
	EngGradientFill	The EngGradientFill function shades the specified primitives.
	EngHangNotification	The EngHangNotification function notifies the system that a specified device is inoperable or unresponsive.
	EngInitializeSafeSemaphore	The EngInitializeSafeSemaphore function initializes the specified safe semaphore.
	EngIsSemaphoreOwned	The EngIsSemaphoreOwned function determines whether any thread holds the specified semaphore.
	EngIsSemaphoreOwnedByCurrentThread	The EngIsSemaphoreOwnedByCurrentThread function determines whether the currently executing thread holds the specified semaphore.
	EngLineTo	The EngLineTo function draws a single, solid, integer-only cosmetic line.
	EngLoadImage	The EngLoadImage function loads the specified executable image into kernel-mode memory.
	EngLoadModule	The EngLoadModule function loads the specified data module into system memory for reading.
	EngLoadModuleForWrite	The EngLoadModuleForWrite function loads the specified executable module into system memory for writing.
	EngLockDirectDrawSurface	The EngLockDirectDrawSurface function locks the kernel-mode handle of a DirectDraw surface.
	EngLockDriverObj	The EngLockDriverObj function creates an exclusive lock on this object for the calling thread.
	EngLockSurface	The EngLockSurface function creates a user object for a given surface. This function gives drivers access to surfaces they create.
	EngLpkInstalled	The EngLpkInstalled function determines whether the language pack is installed on the system.
	EngMapEvent	The EngMapEvent function maps a user-mode event object to kernel mode.
	EngMapFile	The EngMapFile function creates or opens a file and maps it into system space.
	EngMapFontFile	The EngMapFontFile function is obsolete. Use EngMapFontFileFD instead.
	EngMapFontFileFD	The EngMapFontFileFD function maps a font file into system memory, if necessary, and returns a pointer to the base location of the font data in the file.
	EngMapModule	The EngMapModule function returns the address and size of a file that was loaded by EngLoadModule, EngLoadModuleForWrite, EngLoadImage, or EngMapFile.
	EngMarkBandingSurface	The EngMarkBandingSurface function marks the specified surface as a banding surface.
	EngModifySurface	The EngModifySurface function notifies GDI about the attributes of a surface that was created by the driver.
	EngMovePointer	The EngMovePointer function moves the engine-managed pointer on the device.
	EngMulDiv	The EngMulDiv function multiplies two 32-bit values and then divides the 64-bit result by a third 32-bit value.
	EngMultiByteToUnicodeN	The EngMultiByteToUnicodeN function converts the specified ANSI source string into a Unicode string using the current ANSI code page.
	EngMultiByteToWideChar	The EngMultiByteToWideChar function converts an ANSI source string into a wide character string using the specified code page.
	EngPaint	The EngPaint function causes GDI to paint a specified region.
	EngPlgBlt	The EngPlgBlt function causes GDI to perform a rotate bit-block transfer.
	EngProbeForRead	The EngProbeForRead function probes a structure for read accessibility.
	EngProbeForReadAndWrite	The EngProbeForReadAndWrite function probes a structure for read and write accessibility.
	EngQueryDeviceAttribute	The EngQueryDeviceAttribute function allows the driver to query the system about particular attributes of the device.
	EngQueryFileTimeStamp	The EngQueryFileTimeStamp function returns the time stamp of a file.
	EngQueryLocalTime	The EngQueryLocalTime function queries the local time.
	EngQueryPalette	The EngQueryPalette function queries the specified palette for its attributes.
	EngQueryPerformanceCounter	The EngQueryPerformanceCounter function queries the performance counter.
	EngQueryPerformanceFrequency	The EngQueryPerformanceFrequency function queries the frequency of the performance counter.
	EngQuerySystemAttribute	The EngQuerySystemAttribute function queries processor-specific or system-specific capabilities.
	EngReadStateEvent	The EngReadStateEvent function returns the current state of the specified event object:_signaled or nonsignaled.
	EngReleaseSemaphore	The EngReleaseSemaphore function releases the specified semaphore.
	EngRestoreFloatingPointState	The EngRestoreFloatingPointState function restores the Windows 2000 (and later) kernel floating-point state after the driver uses any floating-point or MMX hardware instructions.
	EngSaveFloatingPointState	The EngSaveFloatingPointState function saves the current Windows 2000 (and later) kernel floating-point state.
	EngSecureMem	The EngSecureMem function locks down the specified address range in memory.
	EngSetEvent	The EngSetEvent function sets the specified event object to the signaled state, and returns the event object's previous state.
	EngSetLastError	The EngSetLastError function causes GDI to report an error code, which can be retrieved by an application.
	EngSetPointerShape	The EngSetPointerShape function sets the pointer shape for the calling driver.
	EngSetPointerTag	The EngSetPointerTag function is obsolete for Windows 2000 and later operating system versions.
	EngSetPrinterData	The EngSetPrinterData function is obsolete in Windows 2000 and later. In earlier versions of Windows EngSetPrinterData sets the configuration data for the specified printer.
	EngSort	The EngSort function performs a quick-sort on the specified list.
	EngStretchBlt	The EngStretchBlt function causes GDI to do a stretching bit-block transfer.
	EngStretchBltROP	The EngStretchBltROP function performs a stretching bit-block transfer using a ROP.
	EngStrokeAndFillPath	The EngStrokeAndFillPath function causes GDI to fill a path and stroke it at the same time.
	EngStrokePath	The EngStrokePath function requests that GDI stroke a specified path.
	EngTextOut	The EngTextOut function causes GDI to render a set of glyphs at specified positions.
	EngTransparentBlt	The EngTransparentBlt function provides bit-block transfer capabilities with transparency.
	EngUnicodeToMultiByteN	The EngUnicodeToMultiByteN function converts the specified Unicode string into an ANSI string using the current ANSI code page.
	EngUnloadImage	The EngUnloadImage function unloads an image loaded by EngLoadImage.
	EngUnlockDirectDrawSurface	The EngUnlockDirectDrawSurface function releases the lock on the specified surface.
	EngUnlockDriverObj	The EngUnlockDriverObj function causes GDI to unlock the driver object.
	EngUnlockSurface	The EngUnlockSurface function causes GDI to unlock the surface.
	EngUnmapEvent	The EngUnmapEvent function cleans up the kernel-mode resources allocated for a mapped user-mode event.
	EngUnmapFile	The EngUnmapFile function unmaps the view of a file from system space.
	EngUnmapFontFile	The EngUnmapFontFile function is obsolete. Use EngUnmapFontFileFD instead.
	EngUnmapFontFileFD	The EngUnmapFontFileFD function unmaps the specified font file from system memory.
	EngUnsecureMem	The EngUnsecureMem function unlocks an address range that is locked down in memory.
	EngWaitForSingleObject	The EngWaitForSingleObject function puts the current thread of the display driver into a wait state until the specified event object is set to the signaled state, or until the wait times out.
	EngWideCharToMultiByte	The EngWideCharToMultiByte function converts a wide character string into an ANSI source string using the specified code page.
	EngWritePrinter	The EngWritePrinter function allows printer graphics DLLs to send a data stream to printer hardware.
	FLOATOBJ_Add	The FLOATOBJ_Add function adds the two FLOATOBJs, and returns with the result in the first parameter.
	FLOATOBJ_AddFloat	The FLOATOBJ_AddFloat function adds the value of type FLOATL to the FLOATOBJ, and returns with the result in the first parameter.
	FLOATOBJ_AddLong	The FLOATOBJ_AddLong function adds the value of type LONG to the FLOATOBJ, and returns with the result in the first parameter.
	FLOATOBJ_Div	The FLOATOBJ_Div function divides the two FLOATOBJs, and returns with the result in the first parameter.
	FLOATOBJ_DivFloat	The FLOATOBJ_DivFloat function divides the FLOATOBJ by the value of type FLOATL, and returns with the result in the first parameter.
	FLOATOBJ_DivLong	The FLOATOBJ_DivLong function divides the FLOATOBJ by the value of type LONG, and returns with the result in the first parameter.
	FLOATOBJ_Equal	The FLOATOBJ_Equal function determines whether the two FLOATOBJs are equal.
	FLOATOBJ_EqualLong	The FLOATOBJ_EqualLong function determines whether the FLOATOBJ and the value of type LONG are equal.
	FLOATOBJ_GetFloat	The FLOATOBJ_GetFloat function calculates and returns the FLOAT-equivalent value of the specified FLOATOBJ.
	FLOATOBJ_GetLong	The FLOATOBJ_GetLong function calculates and returns the LONG-equivalent value of the specified FLOATOBJ.
	FLOATOBJ_GreaterThan	The FLOATOBJ_GreaterThan function determines whether the first FLOATOBJ is greater than the second FLOATOBJ.
	FLOATOBJ_GreaterThanLong	The FLOATOBJ_GreaterThanLong function determines whether the FLOATOBJ is greater than the value of type LONG.
	FLOATOBJ_LessThan	The FLOATOBJ_LessThan function determines whether the first FLOATOBJ is less than the second FLOATOBJ.
	FLOATOBJ_LessThanLong	The FLOATOBJ_LessThanLong function determines whether the FLOATOBJ is less than the value of type LONG.
	FLOATOBJ_Mul	The FLOATOBJ_Mul function multiplies the two FLOATOBJs, and returns with the result in the first parameter.
	FLOATOBJ_MulFloat	The FLOATOBJ_MulFloat function multiplies the FLOATOBJ by the value of type FLOATL, and returns with the result in the first parameter.
	FLOATOBJ_MulLong	The FLOATOBJ_MulLong function multiplies the FLOATOBJ by the value of type LONG, and returns with the result in the first parameter.
	FLOATOBJ_Neg	The FLOATOBJ_Neg function negates the FLOATOBJ.
	FLOATOBJ_SetFloat	The FLOATOBJ_SetFloat function assigns the value of type FLOATL to the FLOATOBJ.
	FLOATOBJ_SetLong	The FLOATOBJ_SetLong function assigns the value of type LONG to the FLOATOBJ.
	FLOATOBJ_Sub	The FLOATOBJ_Sub function subtracts the second FLOATOBJ from the first, and returns with the result in the first parameter.
	FLOATOBJ_SubFloat	The FLOATOBJ_SubFloat function subtracts the value of type FLOATL from the FLOATOBJ, and returns with the result in the first parameter.
	FLOATOBJ_SubLong	The FLOATOBJ_SubLong function subtracts the value of type LONG from the FLOATOBJ, and returns with the result in the first parameter.
	FONTOBJ_cGetAllGlyphHandles	The FONTOBJ_cGetAllGlyphHandles function allows the device driver to find every glyph handle of a GDI font.
	FONTOBJ_cGetGlyphs	The FONTOBJ_cGetGlyphs function is a service to the font consumer that translates glyph handles into pointers to glyph data, which are valid until the next call to FONTOBJ_cGetGlyphs.
	FONTOBJ_pfdg	The FONTOBJ_pfdg function retrieves the pointer to the FD_GLYPHSET structure associated with the specified font.
	FONTOBJ_pifi	The FONTOBJ_pifi function retrieves the pointer to the IFIMETRICS structure associated with a specified font.
	FONTOBJ_pjOpenTypeTablePointer	The FONTOBJ_pjOpenTypeTablePointer function returns a pointer to a view of an OpenType table.
	FONTOBJ_pQueryGlyphAttrs	The FONTOBJ_pQueryGlyphAttrs function returns information about a font's glyphs.
	FONTOBJ_pvTrueTypeFontFile	The FONTOBJ_pvTrueTypeFontFile function retrieves a user-mode pointer to a view of a TrueType, OpenType, or Type1 font file.
	FONTOBJ_pwszFontFilePaths	The FONTOBJ_pwszFontFilePaths function retrieves the file path(s) associated with a font.
	FONTOBJ_pxoGetXform	The FONTOBJ_pxoGetXform function retrieves the notional-to-device transform for the specified font.
	FONTOBJ_vGetInfo	The FONTOBJ_vGetInfo function retrieves information about an associated font.
	HT_ComputeRGBGammaTable	The HT_ComputeRGBGammaTable function causes GDI to compute device red, green, and blue intensities based on gamma numbers.
	HT_Get8BPPFormatPalette	The HT_Get8BPPFormatPalette function returns a halftone palette for use on standard 8-bits per pixel device types.
	HT_Get8BPPMaskPalette	The HT_Get8BPPMaskPalette function returns a mask palette for an 8-bits-per-pixel device type.
	HTUI_DeviceColorAdjustment	The HTUI_DeviceColorAdjustment function can be used by graphics device drivers to display a dialog box that allows a user to adjust a device's halftoning properties.
	IsEqualGUID	Determines whether two GUIDs are equal.
	PALOBJ_cGetColors	The PALOBJ_cGetColors function copies RGB colors from an indexed palette.
	PATHOBJ_bCloseFigure	The PATHOBJ_bCloseFigure function closes an open figure in a path by drawing a line from the current position to the first point of the figure.
	PATHOBJ_bEnum	The PATHOBJ_bEnum function retrieves the next PATHDATA record from a specified path and enumerates the curves in the path.
	PATHOBJ_bEnumClipLines	The PATHOBJ_bEnumClipLines function enumerates clipped line segments from a given path.
	PATHOBJ_bMoveTo	The PATHOBJ_bMoveTo function sets the current position in a given path.
	PATHOBJ_bPolyBezierTo	The PATHOBJ_bPolyBezierTo function draws Bezier curves on a path.
	PATHOBJ_bPolyLineTo	The PATHOBJ_bPolyLineTo function draws lines from the current position in a path through the specified points.
	PATHOBJ_vEnumStart	The PATHOBJ_vEnumStart function notifies a given PATHOBJ structure that the driver will be calling PATHOBJ_bEnum to enumerate lines and/or curves in the path.
	PATHOBJ_vEnumStartClipLines	The PATHOBJ_vEnumStartClipLines function allows the driver to request lines to be clipped against a specified clip region.
	PATHOBJ_vGetBounds	The PATHOBJ_vGetBounds function retrieves the bounding rectangle for the specified path.
	STROBJ_bEnum	The STROBJ_bEnum function enumerates glyph identities and positions.
	STROBJ_bEnumPositionsOnly	The STROBJ_bEnumPositionsOnly function enumerates glyph identities and positions for a specified text string, but does not create cached glyph bitmaps.
	STROBJ_bGetAdvanceWidths	The STROBJ_bGetAdvanceWidths function retrieves an array of vectors specifying the probable widths of glyphs making up a specified string.
	STROBJ_dwGetCodePage	The STROBJ_dwGetCodePage function returns the code page associated with the specified STROBJ structure.
	STROBJ_fxBreakExtra	The STROBJ_fxBreakExtra function retrieves the amount of extra space to be added to each space character in a string when displaying and/or printing justified text.
	STROBJ_fxCharacterExtra	The STROBJ_fxCharacterExtra function retrieves the amount of extra space with which to augment each character's width in a string when displaying and/or printing it.
	STROBJ_vEnumStart	The STROBJ_vEnumStart function defines the form, or type, for data that will be returned from GDI in subsequent calls to STROBJ_bEnum.
	WNDOBJ_bEnum	The WNDOBJ_bEnum function obtains a batch of rectangles from the visible region of a window.
	WNDOBJ_cEnumStart	The WNDOBJ_cEnumStart function is a callback function that sets parameters for enumeration of rectangles in the visible region of a window.
	WNDOBJ_vSetConsumer	The WNDOBJ_vSetConsumer function sets a driver-defined value in the pvConsumer field of the specified WNDOBJ structure.
	XFORMOBJ_bApplyXform	The XFORMOBJ_bApplyXform function applies the given transform or its inverse to the given array of points.
	XFORMOBJ_iGetFloatObjXform	The XFORMOBJ_iGetFloatObjXform function downloads a FLOATOBJ transform to the driver.
	XFORMOBJ_iGetXform	The XFORMOBJ_iGetXform function downloads a transform to the driver.
	XLATEOBJ_cGetPalette	The XLATEOBJ_cGetPalette function retrieves RGB colors or the bitfields format from the specified palette.
	XLATEOBJ_hGetColorTransform	The XLATEOBJ_hGetColorTransform function returns the color transform for the specified translation object.
	XLATEOBJ_iXlate	The XLATEOBJ_iXlate function translates a color index of the source palette to the closest index in the destination palette.
	XLATEOBJ_piVector	The XLATEOBJ_piVector function retrieves a translation vector that the driver can use to translate source indices to destination indices.
	Callback functions
	Title	Description
	PFN_DrvQueryGlyphAttrs	The DrvQueryGlyphAttrs function returns information about a font's glyphs.
	Structures
	Title	Description
	BLENDOBJ	The BLENDOBJ structure controls blending by specifying the blending functions for source and destination bitmaps.
	BRUSHOBJ	The BRUSHOBJ structure contains three public members that describe a brush object.
	CIECHROMA	The CIECHROMA structure is used to describe the chromaticity coordinates, x and y, and the luminance, Y in CIE color space.
	CLIPLINE	The CLIPLINE structure gives the driver access to a portion of a line between two clip regions used for drawing.
	CLIPOBJ	The CLIPOBJ structure describes the clip region used when drawing.
	COLORINFO	The COLORINFO structure defines a device's colors in CIE coordinate space.
	DEVHTADJDATA	The DEVHTADJDATA structure is used as input to the HTUI_DeviceColorAdjustment function.
	DEVHTINFO	The DEVHTINFO structure is used as input to the HTUI_DeviceColorAdjustment function.
	DEVINFO	The DEVINFO structure provides information about the driver and its private PDEV to the graphics engine.
	DRIVEROBJ	The DRIVEROBJ structure is used to track a resource, allocated by a driver, that requires use GDI services.
	DRVENABLEDATA	The DRVENABLEDATA structure contains a pointer to an array of DRVFN structures and the graphics DDI version number of an NT-based operating system.
	DRVFN	The DRVFN structure is used by graphics drivers to provide GDI with pointers to the graphics DDI functions defined by the driver.
	ENG_TIME_FIELDS	The ENG_TIME_FIELDS structure is used by the EngQueryLocalTime function to return the local time.
	ENGSAFESEMAPHORE	The ENGSAFESEMAPHORE structure provides the driver with a thread-safe semaphore.
	ENUMRECTS	The ENUMRECTS structure is used by the CLIPOBJ_cEnumStart function to provide information about rectangles in a clip region for the CLIPOBJ_bEnum function.
	FD_DEVICEMETRICS	The FD_DEVICEMETRICS structure is used to provide device-specific font information to GDI if the iMode parameter of the driver-supplied DrvQueryFontData function is QFD_MAXEXTENTS.
	FD_GLYPHATTR	The FD_GLYPHATTR structure is used to specify the return value for the FONTOBJ_pQueryGlyphAttrs and DrvQueryGlyphAttrs functions.
	FD_GLYPHSET	The FD_GLYPHSET structure is used to define the mappings from Unicode characters to glyph handles.
	FD_KERNINGPAIR	The FD_KERNINGPAIR structure is used to store information about kerning pairs.
	FD_XFORM	The FD_XFORM structure describes an arbitrary two-dimensional font transform.
	FLOATOBJ	The FLOATOBJ structure is used to emulate a floating-point number.
	FLOATOBJ_XFORM	The FLOATOBJ_XFORM structure describes an arbitrary linear two-dimensional transform, such as for geometric wide lines.
	FONTDIFF	The FONTDIFF structure describes all of the characteristics that are different between a base font and one of its simulations.
	FONTINFO	The FONTINFO structure contains information regarding a specific font.
	FONTOBJ	The FONTOBJ structure is used to give a driver access to information about a particular instance of a font.
	FONTSIM	The FONTSIM structure contains offsets to one or more FONTDIFF structures describing bold, italic, and bold italic font simulations.
	GAMMARAMP	The GAMMARAMP structure is used by DrvIcmSetDeviceGammaRamp to set the hardware gamma ramp of a particular display device.
	GDIINFO	The GDIINFO structure describes the graphics capabilities of a given device.
	GLYPHBITS	The GLYPHBITS structure is used to define a glyph bitmap.
	GLYPHDATA	The GLYPHDATA structure contains information about an individual glyph.
	GLYPHDEF	The GLYPHDEF union identifies individual glyphs and provides either a pointer to a GLYPHBITS structure or a pointer to a PATHOBJ structure.
	GLYPHPOS	The GLYPHPOS structure is used by GDI to provide a graphics driver with a glyph's description and position.
	IFIEXTRA	The IFIEXTRA structure defines additional information for a given typeface that GDI can use.
	IFIMETRICS	The IFIMETRICS structure defines information for a given typeface that GDI can use.
	LINEATTRS	The LINEATTRS structure is used by a driver's line-drawing functions to determine line attributes.
	PALOBJ	The PALOBJ structure is a user object that represents an indexed color palette.
	PATHDATA	The PATHDATA structure describes all or part of a subpath.
	PATHOBJ	The PATHOBJ structure is used to describe a set of lines and Bezier curves that are to be stroked or filled.
	PERBANDINFO	The PERBANDINFO structure is used as input to a printer graphics DLL's DrvQueryPerBandInfo function.
	RUN	The RUN structure is used to describe a linear set of pixels that is not clipped by the CLIPLINE structure.
	STROBJ	The STROBJ class, or text string object, contains an enumeration of glyph handles and positions for the device driver.
	SURFOBJ	The SURFOBJ structure is the user object for a surface. A device driver usually calls methods on a surface object only when the surface object represents a GDI bitmap or a device-managed surface.
	TYPE1_FONT	The TYPE1_FONT structure contains the information necessary for a PostScript driver to access a Type1 font through GDI.
	WCRUN	The WCRUN structure describes a run of Unicode characters.
	WNDOBJ	The WNDOBJ structure allows the driver to keep track of the position, size, and visible client region changes of a window.
	XFORML	The FLOATOBJ_XFORM structure describes an arbitrary linear two-dimensional transform, such as for geometric wide lines.
	XLATEOBJ	The XLATEOBJ structure is used to translate color indexes from one palette to another.
	*/
}
 