using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke;

public static partial class OleAut32
{
	/// <summary>The desired color depth for the icon or cursor.</summary>
	[PInvokeData("olectl.h", MSDNShortId = "39a2c814-97f6-4157-8884-8b3f268d3f7f")]
	[Flags]
	public enum LoadPictureFlag
	{
		/// <summary>Selects the best color depth to use for the current display.</summary>
		LP_DEFAULT = 0,

		/// <summary>Creates a monochrome picture to display on a monitor.</summary>
		LP_MONOCHROME = 1,

		/// <summary>Creates a 16-color picture to display on a monitor.</summary>
		LP_VGACOLOR = 2,

		/// <summary>Creates a 256-color picture to display on a monitor.</summary>
		LP_COLOR = 4
	}

	/// <summary>
	/// Describe the type of a picture object as returned by <c>IPicture::get_Type</c>, as well as to describe the type of picture in
	/// the <c>picType</c> member of the <c>PICTDESC</c> structure that is passed to <c>OleCreatePictureIndirect</c>.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/com/pictype-constants
	[PInvokeData("olectl.h", MSDNShortId = "79f10687-f0eb-4b5e-a1a9-9186dbd0b51f")]
	public enum PICTYPE
	{
		/// <summary>
		/// The picture object is currently uninitialized. This value is only valid as a return value from IPicture::get_Type and is not
		/// valid with the PICTDESC structure.
		/// </summary>
		PICTYPE_UNINITIALIZED = -1,

		/// <summary>
		/// A new picture object is to be created without an initialized state. This value is valid only in the PICTDESC structure.
		/// </summary>
		PICTYPE_NONE = 0,

		/// <summary>
		/// The picture type is a bitmap. When this value occurs in the PICTDESC structure, it means that the bmp field of that
		/// structure contains the relevant initialization parameters.
		/// </summary>
		PICTYPE_BITMAP = 1,

		/// <summary>
		/// The picture type is a metafile. When this value occurs in the PICTDESC structure, it means that the wmf field of that
		/// structure contains the relevant initialization parameters.
		/// </summary>
		PICTYPE_METAFILE = 2,

		/// <summary>
		/// The picture type is an icon. When this value occurs in the PICTDESC structure, it means that the icon field of that
		/// structure contains the relevant initialization parameters.
		/// </summary>
		PICTYPE_ICON = 3,

		/// <summary>
		/// The picture type is an enhanced metafile. When this value occurs in the PICTDESC structure, it means that the emf field of
		/// that structure contains the relevant initialization parameters.
		/// </summary>
		PICTYPE_ENHMETAFILE = 4,
	}

	/// <summary>
	/// Creates and initializes a standard font object using an initial description of the font's properties in a FONTDESC structure.
	/// The function returns an interface pointer to the new font object specified by caller in the riid parameter. A QueryInterface
	/// call is part of this call. The caller is responsible for calling Release through the interface pointer returned.
	/// </summary>
	/// <param name="lpFontDesc">
	/// Address of a caller-allocated, FONTDESC structure containing the initial state of the font. This value must not be <c>NULL</c>.
	/// </param>
	/// <param name="riid">Reference to the identifier of the interface describing the type of interface pointer to return in lplpvObj.</param>
	/// <param name="lplpvObj">
	/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, this parameter
	/// contains the requested interface pointer on the newly created font object. If successful, the caller is responsible to call
	/// Release through this interface pointer when the new object is no longer needed. If unsuccessful, the value of is set to <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_NOINTERFACE</term>
	/// <term>The provided interface identifier is invalid.</term>
	/// </item>
	/// <item>
	/// <term>E_UNEXPECTED</term>
	/// <term>An unexpected error has occurred.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory for the operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The address in pFontDesc or ppvObj is not valid. Note that if pFontDesc is set to NULL, the function returns NO_ERROR.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/olectl/nf-olectl-olecreatefontindirect WINOLECTLAPI OleCreateFontIndirect(
	// LPFONTDESC lpFontDesc, REFIID riid, LPVOID *lplpvObj );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("olectl.h", MSDNShortId = "9ab384d6-fc21-4152-a0cf-744948f2f72c")]
	public static extern HRESULT OleCreateFontIndirect(in FONTDESC lpFontDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? lplpvObj);

	/// <summary>Creates a new picture object initialized according to a PICTDESC structure.</summary>
	/// <param name="lpPictDesc">
	/// Pointer to a caller-allocated structure containing the initial state of the picture. The specified structure can be <c>NULL</c>
	/// to create an uninitialized object, in the event the picture needs to initialize via IPersistStream::Load.
	/// </param>
	/// <param name="riid">Reference to the identifier of the interface describing the type of interface pointer to return in lplpvObj.</param>
	/// <param name="fOwn">
	/// If <c>TRUE</c>, the picture object is to destroy its picture when the object is destroyed. If <c>FALSE</c>, the caller is
	/// responsible for destroying the picture.
	/// </param>
	/// <param name="lplpvObj">
	/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, this parameter
	/// contains the requested interface pointer on the newly created object. If the call is successful, the caller is responsible for
	/// calling Release through this interface pointer when the new object is no longer needed. If the call fails, the value is set to <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_NOINTERFACE</term>
	/// <term>The object does not support the interface specified in riid.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The address in pPictDesc or lplpvObj is not valid. For example, it may be NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The fOwn parameter indicates whether the picture is to own the GDI picture handle for the picture it contains, so that the
	/// picture object will destroy its picture when the object itself is destroyed. The function returns an interface pointer to the
	/// new picture object specified by the caller in the riid parameter. A QueryInterface is built into this call. The caller is
	/// responsible for calling Release through the interface pointer returned.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/olectl/nf-olectl-olecreatepictureindirect WINOLECTLAPI
	// OleCreatePictureIndirect( LPPICTDESC lpPictDesc, REFIID riid, BOOL fOwn, LPVOID *lplpvObj );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true), SuppressAutoGen]
	[PInvokeData("olectl.h", MSDNShortId = "fb021348-07d4-4974-a71e-abb1b8d760c4")]
	public static extern HRESULT OleCreatePictureIndirect(in PICTDESC lpPictDesc, in Guid riid, [MarshalAs(UnmanagedType.Bool)] bool fOwn,
		[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? lplpvObj);

	/// <summary>Creates a new picture object initialized according to a PICTDESC structure.</summary>
	/// <param name="lpPictDesc">
	/// Pointer to a caller-allocated structure containing the initial state of the picture. The specified structure can be <c>NULL</c>
	/// to create an uninitialized object, in the event the picture needs to initialize via IPersistStream::Load.
	/// </param>
	/// <param name="riid">Reference to the identifier of the interface describing the type of interface pointer to return in lplpvObj.</param>
	/// <param name="fOwn">
	/// If <c>TRUE</c>, the picture object is to destroy its picture when the object is destroyed. If <c>FALSE</c>, the caller is
	/// responsible for destroying the picture.
	/// </param>
	/// <param name="lplpvObj">
	/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, this parameter
	/// contains the requested interface pointer on the newly created object. If the call is successful, the caller is responsible for
	/// calling Release through this interface pointer when the new object is no longer needed. If the call fails, the value is set to <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_NOINTERFACE</term>
	/// <term>The object does not support the interface specified in riid.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The address in pPictDesc or lplpvObj is not valid. For example, it may be NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The fOwn parameter indicates whether the picture is to own the GDI picture handle for the picture it contains, so that the
	/// picture object will destroy its picture when the object itself is destroyed. The function returns an interface pointer to the
	/// new picture object specified by the caller in the riid parameter. A QueryInterface is built into this call. The caller is
	/// responsible for calling Release through the interface pointer returned.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/olectl/nf-olectl-olecreatepictureindirect WINOLECTLAPI
	// OleCreatePictureIndirect( LPPICTDESC lpPictDesc, REFIID riid, BOOL fOwn, LPVOID *lplpvObj );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("olectl.h", MSDNShortId = "fb021348-07d4-4974-a71e-abb1b8d760c4")]
	public static extern HRESULT OleCreatePictureIndirect([In, Optional] IntPtr lpPictDesc, in Guid riid, [MarshalAs(UnmanagedType.Bool)] bool fOwn,
		[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? lplpvObj);

	/// <summary>
	/// Invokes a new property frame, that is, a property sheet dialog box, whose parent is hwndOwner, where the dialog is positioned at
	/// the point (x,y) in the parent window and has the caption lpszCaption.
	/// </summary>
	/// <param name="hwndOwner">Handle to the parent window of the resulting property sheet dialog box.</param>
	/// <param name="x">Reserved. Horizontal position for the dialog box relative to hwndOwner.</param>
	/// <param name="y">Reserved. Vertical position for the dialog box relative to hwndOwner.</param>
	/// <param name="lpszCaption">Pointer to the string used for the caption of the dialog box.</param>
	/// <param name="cObjects">Number of object pointers passed in ppUnk.</param>
	/// <param name="ppUnk">
	/// An array of IUnknown pointers on the objects for which this property sheet is being invoked. The number of elements in the array
	/// is specified by cObjects. These pointers are passed to each property page through IPropertyPage::SetObjects.
	/// </param>
	/// <param name="cPages">Number of property pages specified in pPageCIsID.</param>
	/// <param name="pPageClsID">Array of size cPages containing the CLSIDs of each property page to display in the property sheet.</param>
	/// <param name="lcid">Locale identifier to use for the property sheet. Property pages can retrieve this identifier through IPropertyPageSite::GetLocaleID.</param>
	/// <param name="dwReserved">Reserved for future use; must be zero.</param>
	/// <param name="pvReserved">Reserved for future use; must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>This function supports the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The dialog box was invoked and operated successfully.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The address in lpszCaption, ppUnk, or pPageCIsID is not valid. For example, any one of them may be NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The property pages to be displayed are identified with pPageClsID, which is an array of cPages CLSID values. The objects that
	/// are affected by this property sheet are identified in ppUnk, an array of size cObjects containing IUnknown pointers.
	/// </para>
	/// <para>This function always creates a modal dialog box and does not return until the dialog box is closed.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/olectl/nf-olectl-olecreatepropertyframe WINOLECTLAPI OleCreatePropertyFrame(
	// HWND hwndOwner, UINT x, UINT y, LPCOLESTR lpszCaption, ULONG cObjects, LPUNKNOWN *ppUnk, ULONG cPages, LPCLSID pPageClsID, LCID
	// lcid, DWORD dwReserved, LPVOID pvReserved );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("olectl.h", MSDNShortId = "06f75ac2-3ee6-4209-83cf-a4e5244a18bd")]
	public static extern HRESULT OleCreatePropertyFrame(HWND hwndOwner, [Optional] uint x, [Optional] uint y, [MarshalAs(UnmanagedType.LPWStr)] string lpszCaption, uint cObjects,
		[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] ppUnk, uint cPages, [In, MarshalAs(UnmanagedType.LPArray)] Guid[] pPageClsID,
		LCID lcid, [Optional] uint dwReserved, [Optional] IntPtr pvReserved);

	/// <summary>
	/// Creates a property frame, that is, a property sheet dialog box, based on a structure (OCPFIPARAMS) that contains the parameters,
	/// rather than specifying separate parameters as when calling OleCreatePropertyFrame.
	/// </summary>
	/// <param name="lpParams">Pointer to the caller-allocated structure containing the creation parameters for the dialog box.</param>
	/// <returns>
	/// <para>This function supports the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The dialog box was invoked and operated successfully.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The address in lpParams is not valid. For example, it may be NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Besides <c>cbStructSize</c> (the size of the structure) and <c>dispIDInitialProperty</c>, all of the members of the OCPFIPARAMS
	/// structure have the same semantics as the parameters for OleCreatePropertyFrame. When dispIDInitialProperty is DISPID_UNKNOWN,
	/// the behavior of the two functions is identical.
	/// </para>
	/// <para>
	/// Working in conjunction with IPerPropertyBrowsing and IPropertyPage2, dispIDInitialProperty allows the caller to specify which
	/// single property should be highlighted when the dialog box is made visible. This feature is not available when using
	/// OleCreatePropertyFrame. To determine the page and property to show initially, the property frame will do the following:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>Call <c>(*ppUnk)-&gt;QueryInterface(IID_IPerPropertyBrowsing, ...)</c> to get an interface pointer to the first object.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Call <c>IPerPropertyBrowsing::MapPropertyToPage(dispIDInitialProperty, ...)</c> to determine which page CLSID contains the
	/// property to be highlighted. All objects for which this frame is being invoked must support the set of properties displayed in
	/// the frame.
	/// </term>
	/// </item>
	/// <item>
	/// <term>When the dialog box is created, the property page with the CLSID retrieved in Step 2 is activated with <c>IPropertyPage::Activate</c>.</term>
	/// </item>
	/// <item>
	/// <term>The property frame queries the active page for IPropertyPage2.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If successful, the frame calls <c>IPropertyPage2::EditProperty(dispIDInitialProperty)</c> to highlight the correct field in that
	/// dialog box.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/olectl/nf-olectl-olecreatepropertyframeindirect WINOLECTLAPI
	// OleCreatePropertyFrameIndirect( LPOCPFIPARAMS lpParams );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("olectl.h", MSDNShortId = "ccd01d38-2d8e-4509-b44f-fef6ff718558")]
	public static extern HRESULT OleCreatePropertyFrameIndirect(in OCPFIPARAMS lpParams);

	/// <summary>Converts an icon to a cursor.</summary>
	/// <param name="hinstExe">This parameter is ignored.</param>
	/// <param name="hIcon">A handle to the icon to be converted.</param>
	/// <returns>
	/// The function returns a handle to the new cursor object. The caller is responsible for deleting this cursor with the
	/// DestroyCursor function. If the conversion could not be completed, the return value is <c>NULL</c>.
	/// </returns>
	/// <remarks>This function calls the CopyCursor function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/olectl/nf-olectl-oleicontocursor void OleIconToCursor( HINSTANCE hinstExe,
	// HICON hIcon );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("olectl.h", MSDNShortId = "f5de0b9e-6e3d-424c-aeeb-1c272606aea0")]
	public static extern HCURSOR OleIconToCursor([Optional] HINSTANCE hinstExe, HICON hIcon);

	/// <summary>
	/// Creates a new picture object and initializes it from the contents of a stream. This is equivalent to calling
	/// OleCreatePictureIndirect with <c>NULL</c> as the first parameter, followed by a call to IPersistStream::Load.
	/// </summary>
	/// <param name="lpstream">Pointer to the stream that contains the picture's data.</param>
	/// <param name="lSize">The number of bytes that should be read from the stream, or zero if the entire stream should be read.</param>
	/// <param name="fRunmode">
	/// The opposite of the initial value of the KeepOriginalFormat property. If <c>TRUE</c>, KeepOriginalFormat is set to <c>FALSE</c>
	/// and vice-versa.
	/// </param>
	/// <param name="riid">Reference to the identifier of the interface describing the type of interface pointer to return in ppvObj.</param>
	/// <param name="lplpvObj">
	/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObj contains the
	/// requested interface pointer on the storage of the object identified by the moniker. If *ppvObj is non- <c>NULL</c>, this
	/// function calls IUnknown::AddRef on the interface; it is the caller's responsibility to call IUnknown::Release. If an error
	/// occurs, *ppvObj is set to <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_NOINTERFACE</term>
	/// <term>The object does not support the specified interface.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The stream is not valid. For example, it may be NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The stream must be in BMP (bitmap), WMF (metafile), or ICO (icon) format. A picture object created using <c>OleLoadPicture</c>
	/// always has ownership of its internal resources (fOwn== <c>TRUE</c> is implied).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/olectl/nf-olectl-oleloadpicture WINOLECTLAPI OleLoadPicture( LPSTREAM
	// lpstream, LONG lSize, BOOL fRunmode, REFIID riid, LPVOID *lplpvObj );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("olectl.h", MSDNShortId = "de1847cd-ecc0-4941-9dbc-a60b8ef0b1c1")]
	public static extern HRESULT OleLoadPicture(IStream lpstream, int lSize, [MarshalAs(UnmanagedType.Bool)] bool fRunmode, in Guid riid,
		[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object? lplpvObj);

	/// <summary>
	/// Creates a new picture object and initializes it from the contents of a stream. This is equivalent to calling
	/// OleCreatePictureIndirect with <c>NULL</c> as the first parameter, followed by a call to IPersistStream::Load.
	/// </summary>
	/// <param name="lpstream">Pointer to the stream that contains the picture's data.</param>
	/// <param name="lSize">The number of bytes that should be read from the stream, or zero if the entire stream should be read.</param>
	/// <param name="fRunmode">
	/// The opposite of the initial value of the KeepOriginalFormat property. If <c>TRUE</c>, KeepOriginalFormat is set to <c>FALSE</c>
	/// and vice versa.
	/// </param>
	/// <param name="riid">Reference to the identifier of the interface describing the type of interface pointer to return in ppvObj.</param>
	/// <param name="xSizeDesired">
	/// Desired width of icon or cursor. Valid values are 16, 32, and 48. Pass LP_DEFAULT to both size parameters to use system default size.
	/// </param>
	/// <param name="ySizeDesired">
	/// Desired height of icon or cursor. Valid values are 16, 32, and 48. Pass LP_DEFAULT to both size parameters to use system default size.
	/// </param>
	/// <param name="dwFlags">
	/// Desired color depth for icon or cursor. Values are LP_MONOCHROME (monochrome), LP_VGACOLOR (16 colors), LP_COLOR (256 colors),
	/// or LP_DEFAULT (selects best depth for current display).
	/// </param>
	/// <param name="lplpvObj">
	/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObj contains the
	/// requested interface pointer on the storage of the object identified by the moniker. If *ppvObj is non- <c>NULL</c>, this
	/// function calls IUnknown::AddRef on the interface; it is the caller's responsibility to call IUnknown::Release. If an error
	/// occurs, *ppvObj is set to <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_NOINTERFACE</term>
	/// <term>The object does not support the interface specified in riid.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The address in pPictDesc or ppvObj is not valid. For example, it may be NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The stream must be in BMP (bitmap), WMF (metafile), or ICO (icon) format. A picture object created using <c>OleLoadPictureEx</c>
	/// always has ownership of its internal resources (fOwn== <c>TRUE</c> is implied).
	/// </para>
	/// <para>In addition to allowing specification of icon or cursor size, <c>OleLoadPictureEx</c> supports loading of color cursors.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/olectl/nf-olectl-oleloadpictureex WINOLECTLAPI OleLoadPictureEx( LPSTREAM
	// lpstream, LONG lSize, BOOL fRunmode, REFIID riid, DWORD xSizeDesired, DWORD ySizeDesired, DWORD dwFlags, LPVOID *lplpvObj );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("olectl.h", MSDNShortId = "c903096f-f15f-4a36-8efc-20cf7102e77d")]
	public static extern HRESULT OleLoadPictureEx(IStream lpstream, int lSize, [MarshalAs(UnmanagedType.Bool)] bool fRunmode, in Guid riid,
		uint xSizeDesired, uint ySizeDesired, uint dwFlags, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object? lplpvObj);

	/// <summary>Creates an <c>IPictureDisp</c> object from a picture file on disk.</summary>
	/// <param name="varFileName">The path and name of the picture file to load.</param>
	/// <param name="lplpdispPicture">The location that receives a pointer to the <c>IPictureDisp</c> object.</param>
	/// <returns>
	/// <para>This method returns standard COM error codes in addition to the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The method completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>CTL_E_INVALIDPICTURE</term>
	/// <term>Invalid picture file.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>Recognized graphic formats include bitmap (.bmp), JPEG (.jpg), GIF (.gif), and PGN (.png) files.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/olectl/nf-olectl-oleloadpicturefile WINOLECTLAPI OleLoadPictureFile( VARIANT
	// varFileName, LPDISPATCH *lplpdispPicture );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("olectl.h", MSDNShortId = "ecfbf297-88fa-42bf-afa7-f7884be17b15")]
	public static extern HRESULT OleLoadPictureFile([MarshalAs(UnmanagedType.Struct)] object varFileName, [MarshalAs(UnmanagedType.IDispatch)] out dynamic lplpdispPicture);

	/// <summary>Loads a picture from a file.</summary>
	/// <param name="varFileName">The path and name of the picture file to load.</param>
	/// <param name="xSizeDesired">The desired length for the picture to be displayed.</param>
	/// <param name="ySizeDesired">The desired height for the picture to be displayed.</param>
	/// <param name="dwFlags">
	/// <para>
	/// The desired color depth for the icon or cursor. Together with the desired size it is used to select the best matching image.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LP_MONOCHROME</term>
	/// <term>Creates a monochrome picture to display on a monitor.</term>
	/// </item>
	/// <item>
	/// <term>LP_VGACOLOR</term>
	/// <term>Creates a 16-color picture to display on a monitor.</term>
	/// </item>
	/// <item>
	/// <term>LP_COLOR</term>
	/// <term>Creates a 256-color picture to display on a monitor.</term>
	/// </item>
	/// <item>
	/// <term>LP_DEFAULT</term>
	/// <term>Selects the best color depth to use for the current display.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lplpdispPicture">The location that receives a pointer to the picture.</param>
	/// <returns>
	/// <para>This method returns standard COM error codes in addition to the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The method completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_PARAMNOTFOUND</term>
	/// <term>varFileName is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>Recognized graphic formats include bitmap (.bmp), JPEG (.jpg), GIF (.gif), and PGN (.png) files.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/olectl/nf-olectl-oleloadpicturefileex WINOLECTLAPI OleLoadPictureFileEx(
	// VARIANT varFileName, DWORD xSizeDesired, DWORD ySizeDesired, DWORD dwFlags, LPDISPATCH *lplpdispPicture );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("olectl.h", MSDNShortId = "39a2c814-97f6-4157-8884-8b3f268d3f7f")]
	public static extern HRESULT OleLoadPictureFileEx([MarshalAs(UnmanagedType.Struct)] object varFileName, uint xSizeDesired, uint ySizeDesired, LoadPictureFlag dwFlags, [MarshalAs(UnmanagedType.IDispatch)] out dynamic lplpdispPicture);

	/// <summary>
	/// Creates a new picture object and initializes it from the contents of a stream. This is equivalent to calling
	/// OleCreatePictureIndirect(NULL, ...) followed by IPersistStream::Load.
	/// </summary>
	/// <param name="szURLorPath">The path or URL to the file you want to open.</param>
	/// <param name="punkCaller">Points to IUnknown for COM aggregation.</param>
	/// <param name="dwReserved">Reserved.</param>
	/// <param name="clrReserved">The color you want to reserve to be transparent.</param>
	/// <param name="riid">Reference to the identifier of the interface describing the type of interface pointer to return in ppvRet.</param>
	/// <param name="ppvRet">
	/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvRet contains the
	/// requested interface pointer on the storage of the object identified by the moniker. If *ppvRet is non- <c>NULL</c>, this
	/// function calls IUnknown::AddRef on the interface; it is the caller's responsibility to call IUnknown::Release. If an error
	/// occurs, *ppvRet is set to <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>This function supports the standard return values E_OUTOFMEMORY and E_UNEXPECTED, as well as the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The dialog box was created successfully.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>Unable to load picture stream.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>The address in ppvRet is NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_NOINTERFACE</term>
	/// <term>The object does not support the interface specified in riid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>The stream must be in BMP (bitmap), JPEG, WMF (metafile), ICO (icon), or GIF format.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/olectl/nf-olectl-oleloadpicturepath WINOLECTLAPI OleLoadPicturePath( LPOLESTR
	// szURLorPath, LPUNKNOWN punkCaller, DWORD dwReserved, OLE_COLOR clrReserved, REFIID riid, LPVOID *ppvRet );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("olectl.h", MSDNShortId = "08bad900-815a-4b6d-b977-92d5fdd7d9e8")]
	public static extern HRESULT OleLoadPicturePath([MarshalAs(UnmanagedType.LPWStr)] string szURLorPath, [MarshalAs(UnmanagedType.IUnknown)] object? punkCaller,
		[Optional] uint dwReserved, uint clrReserved, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object? ppvRet);

	/// <summary>Saves a picture to a file.</summary>
	/// <param name="lpdispPicture">Points to the <c>IPictureDisp</c> picture object.</param>
	/// <param name="bstrFileName">The name of the file to save the picture to.</param>
	/// <returns>
	/// <para>This method returns standard COM error codes in addition to the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The method completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>CTL_E_INVALIDPROPERTYVALUE</term>
	/// <term>lpdispPicture is NULL.</term>
	/// </item>
	/// <item>
	/// <term>CTL_E_FILENOTFOUND</term>
	/// <term>bstrFileName cannot be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/olectl/nf-olectl-olesavepicturefile WINOLECTLAPI OleSavePictureFile(
	// LPDISPATCH lpdispPicture, BSTR bstrFileName );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("olectl.h", MSDNShortId = "ac46d390-9e08-4f79-a621-60ea75f4acff")]
	public static extern HRESULT OleSavePictureFile([In, MarshalAs(UnmanagedType.Interface)] object lpdispPicture, [MarshalAs(UnmanagedType.BStr)] string bstrFileName);

	/// <summary>Converts an <c>OLE_COLOR</c> type to a <c>COLORREF</c>.</summary>
	/// <param name="clr">The OLE color to be converted into a <c>COLORREF</c>.</param>
	/// <param name="hpal">Palette used as a basis for the conversion.</param>
	/// <param name="lpcolorref">
	/// Pointer to the caller's variable that receives the converted <c>COLORREF</c> result. This parameter can be <c>NULL</c>,
	/// indicating that the caller wants only to verify that a converted color exists.
	/// </param>
	/// <returns>
	/// <para>This function supports the standard return values E_INVALIDARG and E_UNEXPECTED, as well as the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The color was translated successfully.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The following table describes the color conversion.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>OLE_COLOR</term>
	/// <term>hPal</term>
	/// <term>COLORREF</term>
	/// </listheader>
	/// <item>
	/// <term>invalid</term>
	/// <term/>
	/// <term>Undefined (E_INVALIDARG)</term>
	/// </item>
	/// <item>
	/// <term>0x800000xx, xx is not a valid GetSysColor index</term>
	/// <term/>
	/// <term>Undefined (E_INVALIDARG)</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>invalid</term>
	/// <term>Undefined (E_INVALIDARG)</term>
	/// </item>
	/// <item>
	/// <term>0x0100iiii, iiii is not a valid palette index</term>
	/// <term>valid palette</term>
	/// <term>Undefined (E_INVALIDARG)</term>
	/// </item>
	/// <item>
	/// <term>0x800000xx, xx is a valid GetSysColor index</term>
	/// <term>NULL</term>
	/// <term>0x00bbggrr</term>
	/// </item>
	/// <item>
	/// <term>0x0100iiii, iiii is a valid palette index</term>
	/// <term>NULL</term>
	/// <term>0x0100iiii</term>
	/// </item>
	/// <item>
	/// <term>0x02bbggrr (palette relative)</term>
	/// <term>NULL</term>
	/// <term>0x02bbggrr</term>
	/// </item>
	/// <item>
	/// <term>0x00bbggrr</term>
	/// <term>NULL</term>
	/// <term>0x00bbggrr</term>
	/// </item>
	/// <item>
	/// <term>0x800000xx, xx is a valid GetSysColor index</term>
	/// <term>valid palette</term>
	/// <term>0x00bbggrr</term>
	/// </item>
	/// <item>
	/// <term>0x0100iiii, iiii is a valid palette index in hPal</term>
	/// <term>valid palette</term>
	/// <term>0x0100iiii</term>
	/// </item>
	/// <item>
	/// <term>0x02bbggrr (palette relative)</term>
	/// <term>valid palette</term>
	/// <term>0x02bbggrr</term>
	/// </item>
	/// <item>
	/// <term>0x00bbggrr</term>
	/// <term>valid palette</term>
	/// <term>0x02bbggrr</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/olectl/nf-olectl-oletranslatecolor WINOLECTLAPI OleTranslateColor( OLE_COLOR
	// clr, HPALETTE hpal, COLORREF *lpcolorref );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("olectl.h", MSDNShortId = "f4b407c3-e88a-47b4-bb43-8f691629d2f3")]
	public static extern HRESULT OleTranslateColor(uint clr, HPALETTE hpal, out COLORREF lpcolorref);

	/// <summary>Contains parameters used to create a font object through the OleCreateFontIndirect function.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/olectl/ns-olectl-fontdesc typedef struct tagFONTDESC { UINT cbSizeofstruct;
	// LPOLESTR lpstrName; CY cySize; SHORT sWeight; SHORT sCharset; BOOL fItalic; BOOL fUnderline; BOOL fStrikethrough; } FONTDESC, *LPFONTDESC;
	[PInvokeData("olectl.h", MSDNShortId = "c677b0ba-fd52-40e8-b7c3-b80a01c9fb26")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FONTDESC
	{
		/// <summary>The size of the structure, in bytes.</summary>
		public uint cbSizeofstruct;

		/// <summary>
		/// <para>Pointer to an OLESTR that specifies the caller-owned string specifying the font name.</para>
		/// <para>cySize</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string lpstrName;

		/// <summary>
		/// Initial point size of the font. Use the <c>int64</c> member of the CY structure and scale your font size (in points) by 10000.
		/// </summary>
		public long cySize;

		/// <summary>
		/// Initial weight of the font. If the weight is below 550 (the average of FW_NORMAL, 400, and FW_BOLD, 700), then the
		/// <c>Bold</c> property is also initialized to <c>FALSE</c>. If the weight is above 550, the <c>Bold</c> property is set to <c>TRUE</c>.
		/// </summary>
		public short sWeight;

		/// <summary>Initial character set of the font.</summary>
		public short sCharset;

		/// <summary>Initial italic state of the font.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fItalic;

		/// <summary>Initial underline state of the font.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fUnderline;

		/// <summary>Initial strikethrough state of the font.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fStrikethrough;
	}

	/// <summary>Contains parameters used to invoke a property sheet dialog box through the OleCreatePropertyFrameIndirect function.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/olectl/ns-olectl-ocpfiparams typedef struct tagOCPFIPARAMS { ULONG
	// cbStructSize; HWND hWndOwner; int x; int y; LPCOLESTR lpszCaption; ULONG cObjects; LPUNKNOWN *lplpUnk; ULONG cPages; CLSID
	// *lpPages; LCID lcid; DISPID dispidInitialProperty; } OCPFIPARAMS, *LPOCPFIPARAMS;
	[PInvokeData("olectl.h", MSDNShortId = "d65d8239-495c-4eee-bd9c-8e803fd09a06")]
	[StructLayout(LayoutKind.Sequential)]
	public struct OCPFIPARAMS
	{
		/// <summary>The size of the structure, in bytes.</summary>
		public uint cbStructSize;

		/// <summary>Handle to the parent window of the resulting property sheet dialog box.</summary>
		public HWND hWndOwner;

		/// <summary>Horizontal position for the dialog box relative to <c>hWndOwner</c>, in pixels.</summary>
		public int x;

		/// <summary>Vertical position for the dialog box relative to <c>hWndOwner</c>, in pixels.</summary>
		public int y;

		/// <summary>Pointer to an OLESTR that contains the caption of the dialog.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string lpszCaption;

		/// <summary>Number of object pointers passed in <c>lplpUnk</c>.</summary>
		public uint cObjects;

		/// <summary>
		/// Array of IUnknown pointers on the objects for which this property sheet is being invoked. The number of elements in the
		/// array is specified by <c>cObjects</c>. These pointers are passed to each property page through IPropertyPage::SetObjects.
		/// </summary>
		public IntPtr lplpUnk;

		/// <summary>Number of property pages specified in <c>lpPages</c>.</summary>
		public uint cPages;

		/// <summary>
		/// Pointer to an array of size <c>cPages</c> containing the CLSIDs of each property page to display in the property sheet.
		/// </summary>
		public IntPtr lpPages;

		/// <summary>Locale identifier for the property sheet. This value will be returned through IPropertyPageSite::GetLocaleID.</summary>
		public LCID lcid;

		/// <summary>Property that is highlighted when the dialog box is made visible.</summary>
		public int dispidInitialProperty;
	}

	/// <summary>Contains parameters to create a picture object through the OleCreatePictureIndirect function.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/olectl/ns-olectl-pictdesc typedef struct tagPICTDESC { UINT cbSizeofstruct;
	// UINT picType; union { struct { HBITMAP hbitmap; HPALETTE hpal; } bmp; struct { HMETAFILE hmeta; int xExt; int yExt; } wmf; struct
	// { HICON hicon; } icon; struct { HENHMETAFILE hemf; } emf; }; } PICTDESC, *LPPICTDESC;
	[PInvokeData("olectl.h", MSDNShortId = "eb1f1de7-dcfe-4c1c-8737-f5ab4d7977d6")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PICTDESC
	{
		/// <summary>The size of the structure, in bytes.</summary>
		public uint cbSizeofstruct;

		/// <summary>
		/// Type of picture described by this structure, which can be any value from the PICTYPE enumeration. This selects the arm of
		/// the union that corresponds to one of the picture type structures below.
		/// </summary>
		public PICTYPE picType;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct PICTDEC_UNION
		{
			/// <summary/>
			[FieldOffset(0)]
			public BMP bmp;

			/// <summary/>
			[FieldOffset(0)]
			public WMF wmf;

			/// <summary/>
			[FieldOffset(0)]
			public ICON icon;

			/// <summary/>
			[FieldOffset(0)]
			public EMF emf;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct BMP
			{
				/// <summary>The <c>HBITMAP</c> handle identifying the bitmap assigned to the picture object.</summary>
				public HBITMAP hbitmap;

				/// <summary>The <c>HPALETTE</c> handle identifying the color palette for the bitmap.</summary>
				public HPALETTE hpal;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct WMF
			{
				/// <summary>The <c>HMETAFILE</c> handle identifying the metafile assigned to the picture object.</summary>
				public HMETAFILE hmeta;

				/// <summary>Horizontal extent of the metafile in TWIPS units.</summary>
				public int xExt;

				/// <summary>Vertical extent of the metafile in TWIPS units.</summary>
				public int yExt;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct ICON
			{
				/// <summary>The <c>HICON</c> handle identifying the icon assigned to the picture object.</summary>
				public HICON hicon;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct EMF
			{
				/// <summary>The <c>HENHMETAFILE</c> handle identifying the enhanced metafile assigned to the picture object.</summary>
				public HENHMETAFILE hemf;
			}
		}
	}
}