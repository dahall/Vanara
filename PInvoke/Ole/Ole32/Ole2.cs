using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>Specify the role and creation context for the embedding helper.</summary>
		[PInvokeData("ole2.h", MSDNShortId = "5c67b513-0692-4e0a-beab-8b514089699c")]
		[Flags]
		public enum EMBDHLP
		{
			/// <summary>
			/// Creates an embedding helper that can be used with DLL object applications; specifically, the helper exposes the caching
			/// features of the default object handler.
			/// </summary>
			EMBDHLP_INPROC_HANDLER = 0x0000,

			/// <summary>Creates an embedding helper that is to be used as part of an in-process server. pCF cannot be NULL.</summary>
			EMBDHLP_INPROC_SERVER = 0x0001,

			/// <summary>Creates the secondary object using pCF immediately; if pCF is NULL, the standard proxy manager is used.</summary>
			EMBDHLP_CREATENOW = 0x00000000,

			/// <summary>
			/// Delays creation of the secondary object until it is needed (when the helper is put into the running state) to enhance speed
			/// and memory use. pCF must not be NULL. The EMBDHLP_INPROC_HANDLER flag cannot be used with this flag.
			/// </summary>
			EMBDHLP_DELAYCREATE = 0x00010000,
		}

		/// <summary>Flags for OleCreateEx.</summary>
		[PInvokeData("ole2.h", MSDNShortId = "11f2703c-b596-4cb9-855a-d8cf4b947fae")]
		[Flags]
		public enum OLECREATE
		{
			/// <summary/>
			OLECREATE_LEAVERUNNING = 1
		}

		/// <summary>Retrieves a pointer to the OLE implementation of IDataAdviseHolder on the data advise holder object.</summary>
		/// <param name="ppDAHolder">
		/// Address of an IDataAdviseHolder pointer variable that receives the interface pointer to the new advise holder object.
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory for the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Call <c>CreateDataAdviseHolder</c> in your implementation of IDataObject::DAdvise to get a pointer to the OLE implementation of
		/// IDataAdviseHolder interface. With this pointer, you can then complete the implementation of <c>IDataObject::DAdvise</c> by
		/// calling the IDataAdviseHolder::Advise method, which creates an advisory connection between the calling object and the data object.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-createdataadviseholder HRESULT CreateDataAdviseHolder(
		// LPDATAADVISEHOLDER *ppDAHolder );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "a2114f2f-106a-4a26-ba94-1b40af90a0f3")]
		public static extern HRESULT CreateDataAdviseHolder(out IDataAdviseHolder ppDAHolder);

		/// <summary>
		/// Creates an advise holder object for managing compound document notifications. It returns a pointer to the object's OLE
		/// implementation of the IOleAdviseHolder interface.
		/// </summary>
		/// <param name="ppOAHolder">
		/// Address of IOleAdviseHolder pointer variable that receives the interface pointer to the new advise holder object.
		/// </param>
		/// <returns>This function returns S_OK on success and supports the standard return value E_OUTOFMEMORY.</returns>
		/// <remarks>
		/// The function <c>CreateOleAdviseHolder</c> creates an instance of an advise holder, which supports the OLE implementation of the
		/// IOleAdviseHolder interface. The methods of this interface are intended to be used to implement the advisory methods of
		/// IOleObject, and, when advisory connections have been set up with objects supporting an advisory sink, to send notifications of
		/// changes in the object to the advisory sink. The advise holder returned by <c>CreateOleAdviseHolder</c> will suffice for the great
		/// majority of applications. The OLE-provided implementation does not, however, support IOleAdviseHolder::EnumAdvise, so if you need
		/// to use this method, you will need to implement your own advise holder.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-createoleadviseholder HRESULT CreateOleAdviseHolder(
		// LPOLEADVISEHOLDER *ppOAHolder );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "f76e074e-6814-4735-9417-d5970e73089f")]
		public static extern HRESULT CreateOleAdviseHolder(out IOleAdviseHolder ppOAHolder);

		/// <summary>
		/// <para>Carries out an OLE drag and drop operation.</para>
		/// <para><c>Note</c> You must call OleInitialize before calling this function.</para>
		/// </summary>
		/// <param name="pDataObj">Pointer to the IDataObject interface on a data object that contains the data being dragged.</param>
		/// <param name="pDropSource">
		/// Pointer to an implementation of the IDropSource interface, which is used to communicate with the source during the drag operation.
		/// </param>
		/// <param name="dwOKEffects">
		/// Effects the source allows in the OLE drag-and-drop operation. Most significant is whether it permits a move. The dwOKEffect and
		/// pdwEffect parameters obtain values from the DROPEFFECT enumeration. For a list of values, see <c>DROPEFFECT</c>.
		/// </param>
		/// <param name="pdwEffect">
		/// Pointer to a value that indicates how the OLE drag-and-drop operation affected the source data. The pdwEffect parameter is set
		/// only if the operation is not canceled.
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>DRAGDROP_S_DROP</term>
		/// <term>The OLE drag-and-drop operation was successful.</term>
		/// </item>
		/// <item>
		/// <term>DRAGDROP_S_CANCEL</term>
		/// <term>The OLE drag-and-drop operation was canceled.</term>
		/// </item>
		/// <item>
		/// <term>E_UNSPEC</term>
		/// <term>Unexpected error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you are developing an application that can act as a data source for an OLE drag-and-drop operation, you must call
		/// <c>DoDragDrop</c> when you detect that the user has started an OLE drag-and-drop operation.
		/// </para>
		/// <para>
		/// The <c>DoDragDrop</c> function enters a loop in which it calls various methods in the IDropSource and IDropTarget interfaces.
		/// (For a successful drag-and-drop operation, the application acting as the data source must also implement <c>IDropSource</c>,
		/// while the target application must implement <c>IDropTarget</c>.)
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// The <c>DoDragDrop</c> function determines the window under the current cursor location. It then checks to see if this window is a
		/// valid drop target.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the window is a valid drop target, <c>DoDragDrop</c> calls IDropTarget::DragEnter. This method supplies an effect code
		/// indicating what would happen if the drop actually occurred. For a list of valid drop effects, see the DROPEFFECT enumeration.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>DoDragDrop</c> calls IDropSource::GiveFeedback with the effect code so that the drop source interface can provide appropriate
		/// visual feedback to the user. The pDropSource pointer passed into <c>DoDragDrop</c> specifies the appropriate IDropSource interface.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>DoDragDrop</c> tracks mouse cursor movements and changes in the keyboard or mouse button state.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If there is a change in the keyboard or mouse button state, <c>DoDragDrop</c> calls IDropSource::QueryContinueDrag and determines
		/// whether to continue the drag, to drop the data, or to cancel the operation based on the return value.
		/// </term>
		/// </item>
		/// </list>
		/// <para><c>DoDragDrop</c> does not support invoking drag and drop support when you handle touch or pen input.</para>
		/// <para>
		/// To support touch or pen input, do not call <c>DoDragDrop</c> from your touch handler. Instead, call <c>DoDragDrop</c> from your
		/// handler for those mouse messages that the system synthesizes upon touch input.
		/// </para>
		/// <para>
		/// The application can identify synthesized messages by calling the GetMessageExtraInfo function. For more information about using
		/// <c>GetMessageExtraInfo</c> to distinguish between mouse input and Windows Touch input, see Troubleshooting Applications.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-dodragdrop HRESULT DoDragDrop( IN LPDATAOBJECT pDataObj, IN
		// LPDROPSOURCE pDropSource, IN DWORD dwOKEffects, OUT LPDWORD pdwEffect );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "095172ac-9e08-4797-b9da-41a4e5a61315")]
		public static extern HRESULT DoDragDrop([In] IDataObject pDataObj, [In] IDropSource pDropSource, [In] DROPEFFECT dwOKEffects, out DROPEFFECT pdwEffect);

		/// <summary>Determines whether the specified keystroke maps to an accelerator in the specified accelerator table.</summary>
		/// <param name="hAccel">A handle to the accelerator table.</param>
		/// <param name="cAccelEntries">The number of entries in the accelerator table.</param>
		/// <param name="lpMsg">A pointer to the keystroke message to be translated.</param>
		/// <param name="lpwCmd">
		/// A pointer to a variable to receive the corresponding command identifier if there is an accelerator for the keystroke. This
		/// parameter may be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// If the message is for the object application, the return value is <c>TRUE</c>. If the message is not for the object and should be
		/// forwarded to the container, the return value is <c>FALSE</c>.
		/// </returns>
		/// <remarks>
		/// <para>
		/// While an object is active in-place, the object always has first chance to translate the keystrokes into accelerators. If the
		/// keystroke corresponds to one of its accelerators, the object must not call the OleTranslateAccelerator function â€” even if its
		/// call to the TranslateAccelerator function fails. Failure to process keystrokes in this manner can lead to inconsistent behavior.
		/// </para>
		/// <para>
		/// If the keystroke is not one of the object's accelerators, then the object must call OleTranslateAccelerator to let the container
		/// try its accelerator translation.
		/// </para>
		/// <para>
		/// The object's server can call <c>IsAccelerator</c> to determine if the accelerator message belongs to it. Some servers do
		/// accelerator translation on their own and do not call TranslateAccelerator. Those applications will not call <c>IsAccelerator</c>,
		/// because they already have the information.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-isaccelerator BOOL IsAccelerator( IN HACCEL hAccel, IN int
		// cAccelEntries, IN LPMSG lpMsg, OUT WORD *lpwCmd );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "2d09f81a-b422-4379-89c8-d50992ebb24c")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsAccelerator(HACCEL hAccel, int cAccelEntries, in MSG lpMsg, out ushort lpwCmd);

		/// <summary>
		/// The <c>OleConvertIStorageToOLESTREAM</c> function converts the specified storage object from OLE 2 structured storage to the OLE
		/// 1 storage object model but does not include the presentation data. This is one of several compatibility functions.
		/// </summary>
		/// <param name="pstg">Pointer to the IStorage interface on the storage object to be converted to an OLE 1 storage.</param>
		/// <param name="lpolestream">
		/// Pointer to an OLE 1 stream structure where the persistent representation of the object is saved using the OLE 1 storage model.
		/// </param>
		/// <returns>This function supports the standard return value E_INVALIDARG, in addition to the following:</returns>
		/// <remarks>
		/// <para>
		/// This function converts an OLE 2 storage object to OLE 1 format. The <c>OLESTREAM</c> structure code implemented for OLE 1 must be available.
		/// </para>
		/// <para>
		/// On entry, the stream to which lpolestm points should be created and positioned just as it would be for an OleSaveToStream call.
		/// On exit, the stream contains the persistent representation of the object using OLE 1 storage.
		/// </para>
		/// <para>
		/// <c>Note</c> Paintbrush objects are dealt with differently from other objects because their native data is in device-independent
		/// bitmap (DIB) format. When Paintbrush objects are converted using <c>OleConvertIStorageToOLESTREAM</c>, no presentation data is
		/// added to the <c>OLESTREAM</c> structure. To include presentation data, use the OleConvertIStorageToOLESTREAMEx function instead.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oleconvertistoragetoolestream HRESULT
		// OleConvertIStorageToOLESTREAM( IN LPSTORAGE pstg, OUT LPOLESTREAM lpolestream );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "d100d32a-6559-4a7c-a0ae-780bc9d82611")]
		public static extern HRESULT OleConvertIStorageToOLESTREAM([In] IStorage pstg, out OLESTREAM lpolestream);

		/// <summary>
		/// The <c>OleConvertIStorageToOLESTREAMEx</c> function converts the specified storage object from OLE 2 structured storage to the
		/// OLE 1 storage object model, including the presentation data. This is one of several functions included in Structured Storage to
		/// ensure compatibility between OLE1 and OLE2.
		/// </summary>
		/// <param name="pstg">Pointer to the IStorage interface on the storage object to be converted to an OLE 1 storage.</param>
		/// <param name="cfFormat">
		/// Format of the presentation data. May be <c>NULL</c>, in which case the lWidth, lHeight, dwSize, and pmedium parameters are ignored.
		/// </param>
		/// <param name="lWidth">Width of the object presentation data in HIMETRIC units.</param>
		/// <param name="lHeight">Height of the object presentation data in HIMETRIC units.</param>
		/// <param name="dwSize">Size of the data, in bytes, to be converted.</param>
		/// <param name="pmedium">Pointer to the STGMEDIUM structure for the serialized data to be converted.</param>
		/// <param name="polestm">
		/// Pointer to a stream where the persistent representation of the object is saved using the OLE 1 storage model.
		/// </param>
		/// <returns>This function supports the standard return value E_INVALIDARG, in addition to the following:</returns>
		/// <remarks>
		/// <para>
		/// The <c>OleConvertIStorageToOLESTREAMEx</c> function converts an OLE 2 storage object to OLE 1 format. It differs from the
		/// OleConvertIStorageToOLESTREAM function in that the <c>OleConvertIStorageToOLESTREAMEx</c> function also passes the presentation
		/// data to the OLE 1 storage object, whereas the <c>OleConvertIStorageToOLESTREAM</c> function does not.
		/// </para>
		/// <para>
		/// Because <c>OleConvertIStorageToOLESTREAMEx</c> can specify which presentation data to convert, it can be used by applications
		/// that do not use OLE default caching resources but do use OLE's conversion resources.
		/// </para>
		/// <para>
		/// The value of the <c>tymed</c> member of STGMEDIUM must be either TYMED_HGLOBAL or TYMED_ISTREAM; refer to the TYMED enumeration
		/// for more information. The medium is not released by the <c>OleConvertIStorageToOLESTREAMEx</c> function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oleconvertistoragetoolestreamex HRESULT
		// OleConvertIStorageToOLESTREAMEx( IN LPSTORAGE pstg, IN CLIPFORMAT cfFormat, IN LONG lWidth, IN LONG lHeight, IN DWORD dwSize, IN
		// LPSTGMEDIUM pmedium, OUT LPOLESTREAM polestm );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "a6026b71-4223-40ab-b209-44531480db57")]
		public static extern HRESULT OleConvertIStorageToOLESTREAMEx([In] IStorage pstg, CLIPFORMAT cfFormat, int lWidth, int lHeight, uint dwSize, in STGMEDIUM pmedium, out OLESTREAM polestm);

		/// <summary>
		/// <para>
		/// The <c>OleConvertOLESTREAMToIStorage</c> function converts the specified object from the OLE 1 storage model to an OLE 2
		/// structured storage object without specifying presentation data.
		/// </para>
		/// <para><c>Note</c> This is one of several compatibility functions.</para>
		/// </summary>
		/// <param name="lpolestream">
		/// A pointer to a stream that contains the persistent representation of the object in the OLE 1 storage format.
		/// </param>
		/// <param name="pstg">A pointer to the IStorage interface on the OLE 2 structured storage object.</param>
		/// <param name="ptd">
		/// A pointer to the DVTARGETDEVICE structure that specifies the target device for which the OLE 1 object is rendered.
		/// </param>
		/// <returns>This function supports the standard return value <c>E_INVALIDARG</c>, in addition to the following:</returns>
		/// <remarks>
		/// <para>
		/// This function converts an OLE 1 object to an OLE 2 structured storage object. Use this function to update OLE 1 objects to OLE 2
		/// objects when a new version of the object application supports OLE 2.
		/// </para>
		/// <para>
		/// On entry, the lpolestm parameter should be created and positioned just as it would be for an OleLoadFromStream function call. On
		/// exit, the lpolestm parameter is positioned just as it would be on exit from an <c>OleLoadFromStream</c> function, and the pstg
		/// parameter contains the uncommitted persistent representation of the OLE 2 storage object.
		/// </para>
		/// <para>
		/// For OLE 1 objects that use native data for their presentation, the <c>OleConvertOLESTREAMToIStorage</c> function returns
		/// <c>CONVERT10_S_NO_PRESENTATION</c>. On receiving this return value, callers should call IOleObject::Update to get the
		/// presentation data so it can be written to storage.
		/// </para>
		/// <para>
		/// Applications that do not use the OLE default caching resources, but use the conversion resources, can use an alternate function,
		/// OleConvertOLESTREAMToIStorageEx, which can specify the presentation data to convert. In the
		/// <c>OleConvertOLESTREAMToIStorageEx</c> function, the presentation data read from the <c>OLESTREAM</c> structure is passed out and
		/// the newly created OLE 2 storage object does not contain a presentation stream.
		/// </para>
		/// <para>The following procedure describes the conversion process using <c>OleConvertOLESTREAMToIStorage</c>.</para>
		/// <para><c>Converting an OLE 1 object to an OLE 2 storage object</c></para>
		/// <list type="number">
		/// <item>
		/// <term>Create a root IStorage object by calling the StgCreateDocfile function (..., &amp;pstg).</term>
		/// </item>
		/// <item>
		/// <term>Open the OLE 1 file (using OpenFile or another OLE 1 technique).</term>
		/// </item>
		/// <item>
		/// <term>Read from the file, using the OLE 1 procedure for reading files, until an OLE object is found.</term>
		/// </item>
		/// <item>
		/// <term>Allocate an IStorage object from the root <c>IStorage</c> created in Step 1.</term>
		/// </item>
		/// <item>
		/// <term>Repeat Step 3 until the file is completely read.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oleconvertolestreamtoistorage HRESULT
		// OleConvertOLESTREAMToIStorage( IN LPOLESTREAM lpolestream, OUT LPSTORAGE pstg, IN const DVTARGETDEVICE *ptd );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "8fed879c-5f97-4450-8259-da9643dd828c")]
		public static extern HRESULT OleConvertOLESTREAMToIStorage(in OLESTREAM lpolestream, out IStorage pstg, in DVTARGETDEVICE ptd);

		/// <summary>
		/// The <c>OleConvertOLESTREAMToIStorageEx</c> function converts the specified object from the OLE 1 storage model to an OLE 2
		/// structured storage object including presentation data. This is one of several compatibility functions.
		/// </summary>
		/// <param name="polestm">
		/// Pointer to the stream that contains the persistent representation of the object in the OLE 1 storage format.
		/// </param>
		/// <param name="pstg">Pointer to the OLE 2 structured storage object.</param>
		/// <param name="pcfFormat">
		/// Pointer to where the format of the presentation data is returned. May be <c>NULL</c>, indicating the absence of presentation data.
		/// </param>
		/// <param name="plwWidth">Pointer to where the width value (in HIMETRIC) of the presentation data is returned.</param>
		/// <param name="plHeight">Pointer to where the height value (in HIMETRIC) of the presentation data is returned.</param>
		/// <param name="pdwSize">Pointer to where the size in bytes of the converted data is returned.</param>
		/// <param name="pmedium">Pointer to where the STGMEDIUM structure for the converted serialized data is returned.</param>
		/// <returns>This function returns HRESULT.</returns>
		/// <remarks>
		/// <para>
		/// This function converts an OLE 1 object to an OLE 2 structured storage object. You can use this function to update OLE 1 objects
		/// to OLE 2 objects when a new version of the object application supports OLE 2.
		/// </para>
		/// <para>
		/// This function differs from the OleConvertOLESTREAMToIStorage function in that the presentation data read from the
		/// <c>OLESTREAM</c> structure is passed out and the newly created OLE 2 storage object does not contain a presentation stream.
		/// </para>
		/// <para>
		/// Since this function can specify which presentation data to convert, it can be used by applications that do not use OLE's default
		/// caching resources but do use the conversion resources.
		/// </para>
		/// <para>
		/// The <c>tymed</c> member of STGMEDIUM can only be TYMED_NULL or TYMED_ISTREAM. If it is TYMED_NULL, the data will be returned in a
		/// global handle through the <c>hGlobal</c> member of <c>STGMEDIUM</c>, otherwise data will be written into the <c>pstm</c> member
		/// of this structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oleconvertolestreamtoistorageex HRESULT
		// OleConvertOLESTREAMToIStorageEx( IN LPOLESTREAM polestm, OUT LPSTORAGE pstg, OUT CLIPFORMAT *pcfFormat, OUT LONG *plwWidth, OUT
		// LONG *plHeight, OUT DWORD *pdwSize, OUT LPSTGMEDIUM pmedium );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "2e77fa0e-1d98-4c59-8d3c-65bd7235ec8f")]
		public static extern HRESULT OleConvertOLESTREAMToIStorageEx(in OLESTREAM polestm, out IStorage pstg, out CLIPFORMAT pcfFormat, out int plwWidth, out int plHeight, out uint pdwSize, out STGMEDIUM pmedium);

		/// <summary>
		/// Creates an embedded object identified by a CLSID. You use it typically to implement the menu item that allows the end user to
		/// insert a new object.
		/// </summary>
		/// <param name="rclsid">CLSID of the embedded object that is to be created.</param>
		/// <param name="riid">
		/// Reference to the identifier of the interface, usually IID_IOleObject (defined in the OLE headers as the interface identifier for
		/// IOleObject), through which the caller communicates with the new object.
		/// </param>
		/// <param name="renderopt">
		/// Value from the enumeration OLERENDER, indicating the locally cached drawing capabilities the newly created object is to have. The
		/// OLERENDER value chosen affects the possible values for the pFormatEtc parameter.
		/// </param>
		/// <param name="pFormatEtc">
		/// Depending on which OLERENDER flag is used as the value of <paramref name="renderopt"/>, this is a pointer to an FORMATETC
		/// enumeration value. For restrictions, see the OLERENDER enumeration.
		/// <para>This parameter, along with the <paramref name="renderopt"/> parameter, specifies what the new object can cache initially.</para>
		/// </param>
		/// <param name="pClientSite">
		/// If you want OleCreate to call IOleObject::SetClientSite, pClientSite is the pointer to the IOleClientSite interface on the container.
		/// <para>The value can be NULL, in which case you must specifically call IOleClientSite::SetClientSite before attempting operations.</para>
		/// </param>
		/// <param name="pStg">
		/// Pointer to an instance of the IStorage interface on the storage object.
		/// <para>This parameter cannot be NULL.</para>
		/// </param>
		/// <param name="ppvObj">
		/// Pointer to the pointer variable that receives the interface pointer requested in <paramref name="riid"/>.
		/// <para>Upon successful return, *ppvObject contains the requested interface pointer.</para>
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success and supports the standard return value E_OUTOFMEMORY.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory for the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>OleCreate</c> function creates a new embedded object, and is typically called to implement the menu item Insert New
		/// Object. When <c>OleCreate</c> returns, the object it has created is blank (contains no data), unless <paramref name="renderopt"/>
		/// is OLERENDER_DRAW or OLERENDER_FORMAT, and is loaded. Containers typically then call the OleRun function or IOleObject::DoVerb to
		/// show the object for initial editing.
		/// </para>
		/// <para>
		/// The <paramref name="rclsid"/> parameter specifies the CLSID of the requested object. CLSIDs of registered objects are stored in
		/// the system registry. When an application user selects Insert Object, a selection box allows the user to select the type of object
		/// desired from those in the registry. When <c>OleCreate</c> is used to implement the Insert Object menu item, the CLSID associated
		/// with the selected item is assigned to the <paramref name="rclsid"/> parameter of <c>OleCreate</c>.
		/// </para>
		/// <para>
		/// The <paramref name="riid"/> parameter specifies the interface the client will use to communicate with the new object. Upon
		/// successful return, the ppvObject parameter holds a pointer to the requested interface.
		/// </para>
		/// <para>
		/// The created object's cache contains information that allows a presentation of a contained object when the container is opened.
		/// Information about what should be cached is passed in the <paramref name="renderopt"/> and pFormatetc values. When
		/// <c>OleCreate</c> returns, the created object's cache is not necessarily filled. Instead, the cache is filled the first time the
		/// object enters the running state. The caller can add additional cache control with a call to IOleCache::Cache after the return of
		/// <c>OleCreate</c> and before the object is run. If <paramref name="renderopt"/> is OLERENDER_DRAW or OLERENDER_FORMAT,
		/// <c>OleCreate</c> requires that the object support the IOleCache interface. There is no such requirement for any other value of <paramref name="renderopt"/>.
		/// </para>
		/// <para>
		/// If pClientSite is non- <c>NULL</c>, <c>OleCreate</c> calls IOleObject::SetClientSite through the pClientSite pointer.
		/// IOleClientSite is the primary interface by which an object requests services from its container. If pClientSite is <c>NULL</c>,
		/// you must make a specific call to <c>IOleObject::SetClientSite</c> before attempting any operations.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreate HRESULT OleCreate( IN REFCLSID rclsid, IN REFIID riid,
		// IN DWORD renderopt, IN LPFORMATETC pFormatEtc, IN LPOLECLIENTSITE pClientSite, IN LPSTORAGE pStg, OUT LPVOID *ppvObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "00b7edd2-8e2e-4e0a-91a6-d966f6c8d456")]
		public static extern HRESULT OleCreate(in Guid rclsid, in Guid riid, OLERENDER renderopt, in FORMATETC pFormatEtc, [In, Optional] IOleClientSite pClientSite, [In] IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

		/// <summary>
		/// Creates a new instance of the default embedding handler. This instance is initialized so it creates a local server when the
		/// embedded object enters the running state.
		/// </summary>
		/// <param name="clsid">CLSID identifying the OLE server to be loaded when the embedded object enters the running state.</param>
		/// <param name="pUnkOuter">
		/// Pointer to the controlling IUnknown interface if the handler is to be aggregated; <c>NULL</c> if it is not to be aggregated.
		/// </param>
		/// <param name="riid">
		/// Reference to the identifier of the interface, usually IID_IOleObject, through which the caller will communicate with the handler.
		/// </param>
		/// <param name="lplpObj">
		/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObj contains the
		/// requested interface pointer on the newly created handler.
		/// </param>
		/// <returns>This function returns NOERROR on success and supports the standard return value E_OUTOFMEMORY.</returns>
		/// <remarks>
		/// <para>
		/// <c>OleCreateDefaultHandler</c> creates a new instance of the default embedding handler, initialized so it creates a local server
		/// identified by the clsid parameter when the embedded object enters the running state. If you are writing a handler and want to use
		/// the services of the default handler, call <c>OleCreateDefaultHandler</c>. OLE also calls it internally when the CLSID specified
		/// in an object creation call is not registered.
		/// </para>
		/// <para>
		/// If the given class does not have a special handler, a call to <c>OleCreateDefaultHandler</c> produces the same results as a call
		/// to the CoCreateInstance function with the class context parameter assigned the value CLSCTX_INPROC_HANDLER.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreatedefaulthandler HRESULT OleCreateDefaultHandler( IN
		// REFCLSID clsid, IN LPUNKNOWN pUnkOuter, IN REFIID riid, OUT LPVOID *lplpObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "ffe87012-b000-4ed7-b0b2-78ffdc794d3b")]
		public static extern HRESULT OleCreateDefaultHandler(in Guid clsid, [MarshalAs(UnmanagedType.IUnknown), Optional] object pUnkOuter, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object lplpObj);

		/// <summary>
		/// Creates an OLE embedding helper object using application-supplied code aggregated with pieces of the OLE default object handler.
		/// This helper object can be created and used in a specific context and role, as determined by the caller.
		/// </summary>
		/// <param name="clsid">CLSID of the class to be helped.</param>
		/// <param name="pUnkOuter">
		/// If the embedding helper is to be aggregated, pointer to the outer object's controlling IUnknown interface. If it is not to be
		/// aggregated, although this is rare, the value should be <c>NULL</c>.
		/// </param>
		/// <param name="flags">
		/// DWORD containing flags that specify the role and creation context for the embedding helper. For legal values, see the following
		/// Remarks section.
		/// </param>
		/// <param name="pCF">
		/// Pointer to the IClassFactory interface on the class object the function uses to create the secondary object. In some situations,
		/// this value may be <c>NULL</c>. For more information, see the following Remarks section.
		/// </param>
		/// <param name="riid">Reference to the identifier of the interface desired by the caller.</param>
		/// <param name="lplpObj">
		/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObj contains the
		/// requested interface pointer on the newly created embedding helper.
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory for the operation.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>The provided interface identifier is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>OleCreateEmbeddingHelper</c> function creates an object that supports the same interface implementations found in the
		/// default handler, but which has additional hooks that allow it to be used more generally than just as a handler object. The
		/// following two calls produce the same result:
		/// </para>
		/// <para>
		/// The embedding helper is aggregatable; pUnkOuter is the controlling IUnknown of the aggregate of which the embedding helper is to
		/// be a part. It is used to create a new instance of the OLE default handler, which can be used to support objects in various roles.
		/// The caller passes a pointer to its IClassFactory implementation to <c>OleCreateEmbeddingHelper</c>. This object and the default
		/// handler are then aggregated to create the new embedding helper object.
		/// </para>
		/// <para>The <c>OleCreateEmbeddingHelper</c> function is usually used to support one of the following implementations:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// An EXE object application that is being used as both a container and a server, and which supports inserting objects into itself.
		/// For this case, <c>CreateEmbeddingHelper</c> allows the object to support the interfaces usually supported only in the handler. To
		/// accomplish this, the application must first register its CLSID for different contexts, making two registration calls to the
		/// CoRegisterClassObject function, rather than one, as follows:
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// A custom in-process object handler, in which case, the DLL creates the embedding helper by passing in a pointer to a private
		/// implementation of IClassFactory in pCF.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The flags parameter indicates how the embedding helper is to be used and how and when the embedding helper is initialized. The
		/// values for flags are obtained by OR-ing together values from the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Values for flags Parameter</term>
		/// <term>Purpose</term>
		/// </listheader>
		/// <item>
		/// <term>EMBDHLP_INPROC_HANDLER</term>
		/// <term>
		/// Creates an embedding helper that can be used with DLL object applications; specifically, the helper exposes the caching features
		/// of the default object handler.
		/// </term>
		/// </item>
		/// <item>
		/// <term>EMBDHLP_INPROC_SERVER</term>
		/// <term>Creates an embedding helper that is to be used as part of an in-process server. pCF cannot be NULL.</term>
		/// </item>
		/// <item>
		/// <term>EMBDHLP_CREATENOW</term>
		/// <term>Creates the secondary object using pCF immediately; if pCF is NULL, the standard proxy manager is used.</term>
		/// </item>
		/// <item>
		/// <term>EMBDHLP_DELAYCREATE</term>
		/// <term>
		/// Delays creation of the secondary object until it is needed (when the helper is put into the running state) to enhance speed and
		/// memory use. pCF must not be NULL. The EMBDHLP_INPROC_HANDLER flag cannot be used with this flag.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreateembeddinghelper HRESULT OleCreateEmbeddingHelper( IN
		// REFCLSID clsid, IN LPUNKNOWN pUnkOuter, IN DWORD flags, IN LPCLASSFACTORY pCF, IN REFIID riid, OUT LPVOID *lplpObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "5c67b513-0692-4e0a-beab-8b514089699c")]
		public static extern HRESULT OleCreateEmbeddingHelper(in Guid clsid, [MarshalAs(UnmanagedType.IUnknown), Optional] object pUnkOuter, EMBDHLP flags, [Optional] IClassFactory pCF, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object lplpObj);

		/// <summary>
		/// Extends OleCreate functionality by supporting more efficient instantiation of objects in containers requiring caching of multiple
		/// presentation formats or data, instead of the single format supported by <c>OleCreate</c>.
		/// </summary>
		/// <param name="rclsid">Identifies the class of the object to create.</param>
		/// <param name="riid">Reference to the identifier of the interface of the object to return.</param>
		/// <param name="dwFlags">This value can be 0 or OLECREATE_LEAVERUNNING (0x00000001).</param>
		/// <param name="renderopt">Value taken from the OLERENDER enumeration.</param>
		/// <param name="cFormats">
		/// When <paramref name="renderopt"/> is OLERENDER_FORMAT, indicates the number of FORMATETC structures in the rgFormatEtc array,
		/// which must be at least one. In all other cases, this parameter must be zero.
		/// </param>
		/// <param name="rgAdvf">
		/// When <paramref name="renderopt"/> is OLERENDER_FORMAT, points to an array of cFormats DWORD elements, each of which is a
		/// combination of values from the ADVF enumeration. Each element of this array is passed in as the <paramref name="rgAdvf"/>
		/// parameter to a call to either IOleCache::Cache or IDataObject::DAdvise, depending on whether pAdviseSink is <c>NULL</c> or non-
		/// <c>NULL</c> (see below). In all other cases, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="rgFormatEtc">
		/// When <paramref name="renderopt"/> is OLERENDER_FORMAT, points to an array of cFormats FORMATETC structures. When pAdviseSink is
		/// <c>NULL</c>, each element of this array is passed as the pFormatEtc parameter to a call to the object's IOleCache::Cache. This
		/// populates the data and presentation cache managed by the objects in-process handler (typically the default handler) with
		/// presentation or other cacheable data. When pAdviseSink is non- <c>NULL</c>, each element of this array is passed as the
		/// pFormatEtc parameter to a call to IDataObject::DAdvise. This allows the caller (typically an OLE Container) to do its own caching
		/// or processing of data received from the object. In all other cases, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="lpAdviseSink">
		/// When <paramref name="renderopt"/> is OLERENDER_FORMAT, may be either a valid IAdviseSink pointer, indicating custom caching or
		/// processing of data advises, or <c>NULL</c>, indicating default caching of data formats. In all other cases, this parameter must
		/// be <c>NULL</c>.
		/// </param>
		/// <param name="rgdwConnection">
		/// Location to return the array of dwConnection values returned when the pAdviseSink interface is registered for each advisory
		/// connection using IDataObject::DAdvise, or <c>NULL</c> if the returned advisory connections are not needed. Must be <c>NULL</c>,
		/// if pAdviseSink is <c>NULL</c>.
		/// </param>
		/// <param name="pClientSite">
		/// Pointer to the primary interface through which the object will request services from its container. This parameter may be
		/// <c>NULL</c>, in which case it is the caller's responsibility to establish the client site as soon as possible using IOleObject::SetClientSite.
		/// </param>
		/// <param name="pStg">
		/// Pointer to the storage to use for the object and any default data or presentation caching established for it. This parameter may
		/// not be <c>NULL</c>.
		/// </param>
		/// <param name="ppvObj">
		/// Address of output pointer variable that receives the interface pointer requested in <paramref name="riid"/>. Upon successful
		/// return, *ppvObj contains the requested interface pointer on the newly created object.
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
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The following call to OleCreate:</para>
		/// <para>is equivalent to the following call to OleCreateEx:</para>
		/// <para>
		/// Existing instantiation functions, (OleCreate, OleCreateFromFile, OleCreateFromData, OleCreateLink, OleCreateLinkToFile, and
		/// OleCreateLinkFromData) create only a single presentation or data format cache in the default cache location (within the
		/// '\001OlePresXXX' streams of the passed-in IStorage), during instantiation. Plus, these caches must be created when the object
		/// next enters the running state. Since most applications require caching at least two presentations (screen and printer) and may
		/// require caching data in a different format or location from the handler, applications must typically launch and shut down the
		/// object server multiple times in order to prime their data caches during object creation, i.e., Insert Object, Insert Object from
		/// File, and Paste Object.
		/// </para>
		/// <para>
		/// Extended versions of these creation functions solve this problem. <c>OleCreateEx</c>, OleCreateFromFileEx, OleCreateFromDataEx,
		/// OleCreateLinkEx, OleCreateLinkToFileEx, and OleCreateLinkFromDataEx contain the following new parameters: dwFlags to indicate
		/// additional options, cFormats to indicate how many formats to cache, rgAdvf, from the ADVF enumeration, to specify the advise
		/// flags for each format to be cached, pAdviseSink to indicate whether presentation (default-handler) or data (non-default-handler)
		/// caching is required, rgdwConnection to return IDataObject::DAdvise cookies, and pFormatEtc, an array of formats rather than a
		/// single format.
		/// </para>
		/// <para>
		/// Containers requiring that multiple presentations be cached on their behalf by the object's handler can simply call these
		/// functions and specify the number of formats in cFormats, the ADVF flags for each format in rgAdvf, and the set of formats in
		/// pFormatEtc. These containers pass <c>NULL</c> for pAdviseSink.
		/// </para>
		/// <para>
		/// Containers performing all their own data- or presentation-caching perform these same steps, but pass a non- <c>NULL</c>
		/// pAdviseSink. They perform their own caching or manipulation of the object or data during IAdviseSink::OnDataChange. Typically
		/// such containers never establish the advisory connections with ADVF_NODATA, although they are not prevented from doing so.
		/// </para>
		/// <para>
		/// These new functions are for OLE Compound Documents. Using these functions, applications can avoid the repeated launching and
		/// initialization steps required by the current functions. They are targeted at OLE Compound Document container applications that
		/// use default data- and presentation-caching, and also at applications that provide their own caching and data transfer from the
		/// underlying IDataObject::DAdvise support.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreateex HRESULT OleCreateEx( IN REFCLSID rclsid, IN REFIID
		// riid, IN DWORD dwFlags, IN DWORD renderopt, IN ULONG cFormats, IN DWORD *rgAdvf, IN LPFORMATETC rgFormatEtc, IN IAdviseSink
		// *lpAdviseSink, OUT DWORD *rgdwConnection, IN LPOLECLIENTSITE pClientSite, IN LPSTORAGE pStg, OUT LPVOID *ppvObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "11f2703c-b596-4cb9-855a-d8cf4b947fae")]
		public static extern HRESULT OleCreateEx(in Guid rclsid, in Guid riid, OLECREATE dwFlags, OLERENDER renderopt, uint cFormats, [In, Optional] ADVF[] rgAdvf, [In, Optional] FORMATETC[] rgFormatEtc,
			[Optional] IAdviseSink lpAdviseSink, [Out, Optional] uint[] rgdwConnection, [Optional] IOleClientSite pClientSite, IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

		/// <summary>
		/// Creates an embedded object from a data transfer object retrieved either from the clipboard or as part of an OLE drag-and-drop
		/// operation. It is intended to be used to implement a paste from an OLE drag-and-drop operation.
		/// </summary>
		/// <param name="pSrcDataObj">
		/// Pointer to the IDataObject interface on the data transfer object that holds the data from which the object is created.
		/// </param>
		/// <param name="riid">
		/// Reference to the identifier of the interface the caller later uses to communicate with the new object (usually IID_IOleObject,
		/// defined in the OLE headers as the interface identifier for IOleObject).
		/// </param>
		/// <param name="renderopt">
		/// Value from the enumeration OLERENDER that indicates the locally cached drawing or data-retrieval capabilities the newly created
		/// object is to have. Additional considerations are described in the following Remarks section.
		/// </param>
		/// <param name="pFormatEtc">
		/// Pointer to a value from the enumeration OLERENDER that indicates the locally cached drawing or data-retrieval capabilities the
		/// newly created object is to have. The <c>OLERENDER</c> value chosen affects the possible values for the pFormatEtc parameter.
		/// </param>
		/// <param name="pClientSite">
		/// Pointer to an instance of IOleClientSite, the primary interface through which the object will request services from its
		/// container. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="pStg">Pointer to the IStorage interface on the storage object. This parameter may not be <c>NULL</c>.</param>
		/// <param name="ppvObj">
		/// Address of pointer variable that receives the interface pointer requested in <paramref name="riid"/>. Upon successful return,
		/// *ppvObj contains the requested interface pointer on the newly created object.
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLE_E_STATIC</term>
		/// <term>Indicates OLE can create only a static object.</term>
		/// </item>
		/// <item>
		/// <term>DV_E_FORMATETC</term>
		/// <term>No acceptable formats are available for object creation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>OleCreateFromData</c> function creates an embedded object from a data transfer object supporting the IDataObject
		/// interface. The data object in this case is either the type retrieved from the clipboard with a call to the OleGetClipboard
		/// function or is part of an OLE drag-and-drop operation (the data object is passed to a call to IDropTarget::Drop).
		/// </para>
		/// <para>
		/// If either the FileName or FileNameW clipboard format (CF_FILENAME) is present in the data transfer object, and CF_EMBEDDEDOBJECT
		/// or CF_EMBEDSOURCE do not exist, <c>OleCreateFromData</c> first attempts to create a package containing the indicated file.
		/// Generally, it takes the first available format.
		/// </para>
		/// <para>
		/// If <c>OleCreateFromData</c> cannot create a package, it tries to create an object using the CF_EMBEDDEDOBJECT format. If that
		/// format is not available, <c>OleCreateFromData</c> tries to create it with the CF_EMBEDSOURCE format. If neither of these formats
		/// is available and the data transfer object supports the IPersistStorage interface, <c>OleCreateFromData</c> calls the object's
		/// IPersistStorage::Save to have the object save itself.
		/// </para>
		/// <para>
		/// If an existing linked object is selected, then copied, it appears on the clipboard as just another embeddable object.
		/// Consequently, a paste operation that invokes <c>OleCreateFromData</c> may create a linked object. After the paste operation, the
		/// container should call the QueryInterface function, requesting IID_IOleLink (defined in the OLE headers as the interface
		/// identifier for IOleLink), to determine if a linked object was created.
		/// </para>
		/// <para>
		/// Use the <paramref name="renderopt"/> and pFormatetc parameters to control the caching capability of the newly created object. For
		/// general information about using the interaction of these parameters to determine what is to be cached, refer to the OLERENDER
		/// enumeration. There are, however, some additional specific effects of these parameters on the way <c>OleCreateFromData</c>
		/// initializes the cache.
		/// </para>
		/// <para>
		/// When <c>OleCreateFromData</c> uses either the CF_EMBEDDEDOBJECT or the CF_EMBEDSOURCE clipboard format to create the embedded
		/// object, the main difference between the two is where the cache-initialization data is stored:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// CF_EMBEDDEDOBJECT indicates that the source is an existing embedded object. It already has in its cache the appropriate data, and
		/// OLE uses this data to initialize the cache of the new object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// CF_EMBEDSOURCE indicates that the source data object contains the cache-initialization information in formats other than
		/// CF_EMBEDSOURCE. <c>OleCreateFromData</c> uses these to initialize the cache of the newly embedded object.
		/// </term>
		/// </item>
		/// </list>
		/// <para>The <paramref name="renderopt"/> values affect cache initialization as follows.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLERENDER_DRAW &amp; OLERENDER_FORMAT</term>
		/// <term>
		/// If the presentation information to be cached is currently present in the appropriate cache-initialization pool, it is used.
		/// (Appropriate locations are in the source data object cache for CF_EMBEDDEDOBJECT, and in the other formats in the source data
		/// object for CF_EMBEDSOURCE.) If the information is not present, the cache is initially empty, but will be filled the first time
		/// the object is run. No other formats are cached in the newly created object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OLERENDER_NONE</term>
		/// <term>
		/// Nothing is to be cached in the newly created object. If the source has the CF_EMBEDDEDOBJECT format, any existing cached data
		/// that has been copied is removed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OLERENDER_ASIS</term>
		/// <term>
		/// If the source has the CF_EMBEDDEDOBJECT format, the cache of the new object is to contain the same cache data as the source
		/// object. For CF_EMBEDSOURCE, nothing is to be cached in the newly created object. This option should be used by more sophisticated
		/// containers. After this call, such containers would call IOleCache::Cache and IOleCache::Uncache to set up exactly what is to be
		/// cached. For CF_EMBEDSOURCE, they would then also call IOleCache::InitCache.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreatefromdata HRESULT OleCreateFromData( IN LPDATAOBJECT
		// pSrcDataObj, IN REFIID riid, IN DWORD renderopt, IN LPFORMATETC pFormatEtc, IN LPOLECLIENTSITE pClientSite, IN LPSTORAGE pStg, OUT
		// LPVOID *ppvObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "aa5e997e-60d4-472d-9c81-5359c277bde3")]
		public static extern HRESULT OleCreateFromData(IDataObject pSrcDataObj, in Guid riid, OLERENDER renderopt, in FORMATETC pFormatEtc, [Optional] IOleClientSite pClientSite, IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

		/// <summary>
		/// Extends OleCreateFromData functionality by supporting more efficient instantiation of objects in containers requiring caching of
		/// multiple formats of presentation or data, instead of the single format supported by <c>OleCreateFromData</c>.
		/// </summary>
		/// <param name="pSrcDataObj">Pointer to the data transfer object holding the new data used to create the new object. (see OleCreateFromData).</param>
		/// <param name="riid">Reference to the identifier of the interface of the object to return.</param>
		/// <param name="dwFlags">This parameter can be 0 or OLECREATE_LEAVERUNNING (0x00000001).</param>
		/// <param name="renderopt">Value taken from the OLERENDER enumeration.</param>
		/// <param name="cFormats">
		/// When <paramref name="renderopt"/> is OLERENDER_FORMAT, indicates the number of FORMATETC structures in the rgFormatEtc array,
		/// which must be at least one. In all other cases, this parameter must be zero.
		/// </param>
		/// <param name="rgAdvf">
		/// When <paramref name="renderopt"/> is OLERENDER_FORMAT, points to an array of <c>DWORD</c> elements, each of which is a
		/// combination of values from the ADVF enumeration. Each element of this array is passed in as the <paramref name="rgAdvf"/>
		/// parameter to a call to either IOleCache::Cache or IDataObject::DAdvise, depending on whether pAdviseSink is <c>NULL</c> or non-
		/// <c>NULL</c> (see below). In all other cases, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="rgFormatEtc">
		/// When <paramref name="renderopt"/> is OLERENDER_FORMAT, points to an array of FORMATETC structures. When pAdviseSink is
		/// <c>NULL</c>, each element of this array is passed as the pFormatEtc parameter to a call to the object's IOleCache::Cache. This
		/// populates the data and presentation cache managed by the object's in-process handler (typically the default handler) with
		/// presentation or other cacheable data. When pAdviseSink is non- <c>NULL</c>, each element of this array is passed as the
		/// pFormatEtc parameter to a call to IDataObject::DAdvise. This allows the caller (typically an OLE Container) to do its own caching
		/// or processing of data received from the object.
		/// </param>
		/// <param name="lpAdviseSink">
		/// When <paramref name="renderopt"/> is OLERENDER_FORMAT, may be either a valid IAdviseSink pointer, indicating custom caching or
		/// processing of data advises, or <c>NULL</c>, indicating default caching of data formats.
		/// </param>
		/// <param name="rgdwConnection">
		/// Location to return the array of dwConnection values returned when the IAdviseSink interface is registered for each advisory
		/// connection using IDataObject::DAdvise, or <c>NULL</c> if the returned advisory connections are not needed. This parameter must be
		/// <c>NULL</c> if pAdviseSink is <c>NULL</c>.
		/// </param>
		/// <param name="pClientSite">
		/// Pointer to the primary interface through which the object will request services from its container. This parameter may be
		/// <c>NULL</c>, in which case it is the caller's responsibility to establish the client site as soon as possible using IOleObject::SetClientSite.
		/// </param>
		/// <param name="pStg">
		/// Pointer to the storage to use for the object and any default data or presentation caching established for it.
		/// </param>
		/// <param name="ppvObj">
		/// Address of output pointer variable that receives the interface pointer requested in <paramref name="riid"/>. Upon successful
		/// return, *ppvObj contains the requested interface pointer on the newly created object.
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
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The following call to OleCreateFromData:</para>
		/// <para>is equivalent to the following call to <c>OleCreateFromDataEx</c>:</para>
		/// <para>
		/// Existing instantiation functions (OleCreate, OleCreateFromFile, OleCreateFromData, OleCreateLink, OleCreateLinkToFile, and
		/// OleCreateLinkFromData) create only a single presentation or data format cache in the default cache location (within the
		/// '\001OlePresXXX' streams of the passed-in IStorage) during instantiation. Plus, these caches must be created when the object next
		/// enters the running state. Because most applications require caching at least two presentations (screen and printer) and may
		/// require caching data in a different format or location from the handler, applications must typically launch and shut down the
		/// object server multiple times in order to prime their data caches during object creation, i.e., Insert Object, Insert Object from
		/// File, and Paste Object.
		/// </para>
		/// <para>
		/// Extended versions of these creation functions solve this problem. OleCreateEx, OleCreateFromFileEx, <c>OleCreateFromDataEx</c>,
		/// OleCreateLinkEx, OleCreateLinkToFileEx, and OleCreateLinkFromDataEx, contain the following new parameters: dwFlags to indicate
		/// additional options, cFormats to indicate how many formats to cache, rgAdvf, from the ADVF enumeration, to specify the advise
		/// flags for each format to be cached, pAdviseSink to indicate whether presentation (default-handler) or data (non-default-handler)
		/// caching is required, rgdwConnection to return IDataObject::DAdvise cookies, and rgFormatEtc, an array of formats rather than a
		/// single format.
		/// </para>
		/// <para>
		/// Containers requiring that multiple presentations be cached on their behalf by the object's handler can simply call these
		/// functions and specify the number of formats in cFormats, the ADVF flags for each format in rgAdvf, and the set of formats in
		/// rgFormatEtc. These containers pass <c>NULL</c> for pAdviseSink.
		/// </para>
		/// <para>
		/// Containers performing all their own data- or presentation-caching perform these same steps, but pass a non- <c>NULL</c>
		/// pAdviseSink. They perform their own caching or manipulation of the object or data during IAdviseSink::OnDataChange. Typically,
		/// such containers never establish the advisory connections with ADVF_NODATA, although they are not prevented from doing so.
		/// </para>
		/// <para>
		/// These new functions are for OLE Compound Documents. Using these functions, applications can avoid the repeated launching and
		/// initialization steps required by the current functions. They are targeted at OLE Compound Document container applications that
		/// use default data- and presentation-caching, and also at applications that provide their own caching and data transfer from the
		/// underlying IDataObject::DAdvise support.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreatefromdataex HRESULT OleCreateFromDataEx( IN LPDATAOBJECT
		// pSrcDataObj, IN REFIID riid, IN DWORD dwFlags, IN DWORD renderopt, IN ULONG cFormats, IN DWORD *rgAdvf, IN LPFORMATETC
		// rgFormatEtc, IN IAdviseSink *lpAdviseSink, OUT DWORD *rgdwConnection, IN LPOLECLIENTSITE pClientSite, IN LPSTORAGE pStg, OUT
		// LPVOID *ppvObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "10091a24-6a50-4eb2-a518-b92a572daa6c")]
		public static extern HRESULT OleCreateFromDataEx(IDataObject pSrcDataObj, in Guid riid, OLECREATE dwFlags, OLERENDER renderopt, uint cFormats, [In, Optional] ADVF[] rgAdvf, [In, Optional] FORMATETC[] rgFormatEtc,
			[Optional] IAdviseSink lpAdviseSink, [Out, Optional] uint[] rgdwConnection, [Optional] IOleClientSite pClientSite, IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

		/// <summary>Creates an embedded object from the contents of a named file.</summary>
		/// <param name="rclsid">This parameter is reserved and must be CLSID_NULL.</param>
		/// <param name="lpszFileName">Pointer to the name of the file from which the new object should be initialized.</param>
		/// <param name="riid">Reference to the identifier of the interface of the object to return.</param>
		/// <param name="renderopt">Value taken from the OLERENDER enumeration.</param>
		/// <param name="lpFormatEtc">
		/// Depending on which OLERENDER flag is used as the value of <paramref name="renderopt"/>, this is a pointer to an FORMATETC
		/// enumeration value. For restrictions, see the OLERENDER enumeration.
		/// <para>This parameter, along with the <paramref name="renderopt"/> parameter, specifies what the new object can cache initially.</para>
		/// </param>
		/// <param name="pClientSite">
		/// Pointer to the primary interface through which the object will request services from its container. This parameter may be
		/// <c>NULL</c>, in which case it is the caller's responsibility to establish the client site as soon as possible using IOleObject::SetClientSite.
		/// </param>
		/// <param name="pStg">
		/// Pointer to the storage to use for the object and any default data or presentation caching established for it.
		/// </param>
		/// <param name="ppvObj">
		/// Address of output pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObj
		/// contains the requested interface pointer on the newly created object.
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STG_E_FILENOTFOUND</term>
		/// <term>File not bound.</term>
		/// </item>
		/// <item>
		/// <term>OLE_E_CANT_BINDTOSOURCE</term>
		/// <term>Not able to bind to source.</term>
		/// </item>
		/// <item>
		/// <term>STG_E_MEDIUMFULL</term>
		/// <term>The medium is full.</term>
		/// </item>
		/// <item>
		/// <term>DV_E_TYMED</term>
		/// <term>Invalid TYMED.</term>
		/// </item>
		/// <item>
		/// <term>DV_E_LINDEX</term>
		/// <term>Invalid LINDEX.</term>
		/// </item>
		/// <item>
		/// <term>DV_E_FORMATETC</term>
		/// <term>Invalid FORMATETC structure.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>OleCreateFromFile</c> function creates a new embedded object from the contents of a named file. If the ProgID in the
		/// registration database contains the PackageOnFileDrop key, it creates a package. If not, the function calls the GetClassFile
		/// function to get the CLSID associated with the lpszFileName parameter, and then creates an OLE 2-embedded object associated with
		/// that CLSID. The rclsid parameter of <c>OleCreateFromFile</c> will always be ignored, and should be set to CLSID_NULL.
		/// </para>
		/// <para>
		/// As for other OleCreateXxx functions, the newly created object is not shown to the user for editing, which requires a DoVerb
		/// operation. It is used to implement insert file operations.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreatefromfile HRESULT OleCreateFromFile( IN REFCLSID rclsid,
		// IN LPCOLESTR lpszFileName, IN REFIID riid, IN DWORD renderopt, IN LPFORMATETC lpFormatEtc, IN LPOLECLIENTSITE pClientSite, IN
		// LPSTORAGE pStg, OUT LPVOID *ppvObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "98c63646-6617-46b6-8c3e-82d1c4d0adb6")]
		public static extern HRESULT OleCreateFromFile(in Guid rclsid, [MarshalAs(UnmanagedType.LPWStr)] string lpszFileName, in Guid riid, OLERENDER renderopt, in FORMATETC lpFormatEtc, [Optional] IOleClientSite pClientSite, IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

		/// <summary>
		/// Extends OleCreateFromFile functionality by supporting more efficient instantiation of objects in containers requiring caching of
		/// multiple presentation formats or data, instead of the single format supported by <c>OleCreateFromFile</c>.
		/// </summary>
		/// <param name="rclsid">This parameter is reserved and must be CLSID_NULL.</param>
		/// <param name="lpszFileName">Pointer to the name of the file from which the new object should be initialized.</param>
		/// <param name="riid">Reference to the identifier of the interface of the object to return.</param>
		/// <param name="dwFlags">This parameter can be 0 or OLECREATE_LEAVERUNNING (0x00000001).</param>
		/// <param name="renderopt">Value taken from the OLERENDER enumeration.</param>
		/// <param name="cFormats">
		/// When renderopt is OLERENDER_FORMAT, indicates the number of FORMATETC structures in the rgFormatEtc array, which must be at least
		/// one. In all other cases, this parameter must be zero.
		/// </param>
		/// <param name="rgAdvf">
		/// When renderopt is OLERENDER_FORMAT, points to an array of <c>DWORD</c> elements, each of which is a combination of values from
		/// the ADVF enumeration. Each element of this array is passed in as the advf parameter to a call to either IOleCache::Cache or
		/// IDataObject::DAdvise, depending on whether pAdviseSink is <c>NULL</c> or non- <c>NULL</c> (see below). In all other cases, this
		/// parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="rgFormatEtc">
		/// When renderopt is OLERENDER_FORMAT, points to an array of FORMATETC structures. When pAdviseSink is <c>NULL</c>, each element of
		/// this array is passed as the pFormatEtc parameter to a call to the object's IOleCache::Cache. This populates the data and
		/// presentation cache managed by the objects in-process handler (typically the default handler) with presentation or other cacheable
		/// data. When pAdviseSink is non- <c>NULL</c>, each element of this array is passed as the pFormatEtc parameter to a call to
		/// IDataObject::DAdvise. This allows the caller (typically an OLE Container) to do its own caching or processing of data received
		/// from the object.
		/// </param>
		/// <param name="lpAdviseSink">
		/// When renderopt is OLERENDER_FORMAT, may be either a valid IAdviseSink pointer, indicating custom caching or processing of data
		/// advises, or <c>NULL</c>, indicating default caching of data formats.
		/// </param>
		/// <param name="rgdwConnection">
		/// Location to return the array of dwConnection values returned when the pAdviseSink interface is registered for each advisory
		/// connection using IDataObject::DAdvise, or <c>NULL</c> if the returned advisory connections are not needed. This parameter must be
		/// <c>NULL</c> if pAdviseSink is <c>NULL</c>.
		/// </param>
		/// <param name="pClientSite">
		/// Pointer to the primary interface through which the object will request services from its container. This parameter may be
		/// <c>NULL</c>, in which case it is the caller's responsibility to establish the client site as soon as possible using IOleObject::SetClientSite.
		/// </param>
		/// <param name="pStg">
		/// Pointer to the storage to use for the object and any default data or presentation caching established for it.
		/// </param>
		/// <param name="ppvObj">
		/// Address of output pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObj
		/// contains the requested interface pointer on the newly created object.
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
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The following call to OleCreateFromFile:</para>
		/// <para>is equivalent to the following call to <c>OleCreateFromFileEx</c>:</para>
		/// <para>
		/// Existing instantiation functions (OleCreate, OleCreateFromFile, OleCreateFromData, OleCreateLink, OleCreateLinkToFile, and
		/// OleCreateLinkFromData) create only a single presentation or data format cache in the default cache location (within the
		/// '\001OlePresXXX' streams of the passed-in IStorage), during instantiation. Plus, these caches must be created when the object
		/// next enters the running state. Because most applications require caching at least two presentations (screen and printer) and may
		/// require caching data in a different format or location from the handler, applications must typically launch and shut down the
		/// object server multiple times in order to prime their data caches during object creation, i.e., Insert Object, Insert Object from
		/// File, and Paste Object.
		/// </para>
		/// <para>
		/// Extended versions of these creation functions solve this problem. OleCreateEx, <c>OleCreateFromFileEx</c>, OleCreateFromDataEx,
		/// OleCreateLinkEx, OleCreateLinkToFileEx, and OleCreateLinkFromDataEx, contain the following new parameters: dwFlags to indicate
		/// additional options, cFormats to indicate how many formats to cache, rgAdvf, from the ADVF enumeration, to specify the advise
		/// flags for each format to be cached, pAdviseSink to indicate whether presentation (default-handler) or data (non-default-handler)
		/// caching is required, rgdwConnection to return IDataObject::DAdvise cookies, and rgFormatEtc, an array of formats rather than a
		/// single format.
		/// </para>
		/// <para>
		/// Containers requiring that multiple presentations be cached on their behalf by the object's handler can simply call these
		/// functions and specify the number of formats in cFormats, the ADVF flags for each format in rgAdvf, and the set of formats in
		/// rgFormatEtc. These containers pass <c>NULL</c> for pAdviseSink.
		/// </para>
		/// <para>
		/// Containers performing all their own data- or presentation-caching perform these same steps, but pass a non- <c>NULL</c>
		/// pAdviseSink. They perform their own caching or manipulation of the object or data during IAdviseSink::OnDataChange. Typically,
		/// such containers never establish the advisory connections with ADVF_NODATA, although they are not prevented from doing so.
		/// </para>
		/// <para>
		/// These new functions are for OLE Compound Documents. Using these functions, applications can avoid the repeated launching and
		/// initialization steps required by the current functions. They are targeted at OLE Compound Document container applications that
		/// use default data- and presentation-caching, and also at applications that provide their own caching and data transfer from the
		/// underlying IDataObject::DAdvise support.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreatefromfileex HRESULT OleCreateFromFileEx( IN REFCLSID
		// rclsid, IN LPCOLESTR lpszFileName, IN REFIID riid, IN DWORD dwFlags, IN DWORD renderopt, IN ULONG cFormats, IN DWORD *rgAdvf, IN
		// LPFORMATETC rgFormatEtc, IN IAdviseSink *lpAdviseSink, OUT DWORD *rgdwConnection, IN LPOLECLIENTSITE pClientSite, IN LPSTORAGE
		// pStg, OUT LPVOID *ppvObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "a75bb031-6e4a-4440-82f3-6a6f9417c62b")]
		public static extern HRESULT OleCreateFromFileEx(in Guid rclsid, [MarshalAs(UnmanagedType.LPWStr)] string lpszFileName, in Guid riid, OLECREATE dwFlags, OLERENDER renderopt, uint cFormats, [In, Optional] ADVF[] rgAdvf, [In, Optional] FORMATETC[] rgFormatEtc,
			[Optional] IAdviseSink lpAdviseSink, [Out, Optional] uint[] rgdwConnection, [Optional] IOleClientSite pClientSite, IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

		/// <summary>Creates an OLE compound-document linked object.</summary>
		/// <param name="pmkLinkSrc">
		/// Pointer to the IMoniker interface on the moniker that can be used to locate the source of the linked object.
		/// </param>
		/// <param name="riid">
		/// Reference to the identifier of the interface the caller later uses to communicate with the new object (usually IID_IOleObject,
		/// defined in the OLE headers as the interface identifier for IOleObject).
		/// </param>
		/// <param name="renderopt">
		/// Specifies a value from the enumeration OLERENDER that indicates the locally cached drawing or data-retrieval capabilities the
		/// newly created object is to have. Additional considerations are described in the Remarks section below.
		/// </param>
		/// <param name="lpFormatEtc">
		/// Pointer to a value from the enumeration OLERENDER that indicates the locally cached drawing or data-retrieval capabilities the
		/// newly created object is to have. The <c>OLERENDER</c> value chosen affects the possible values for the lpFormatEtc parameter.
		/// </param>
		/// <param name="pClientSite">
		/// Pointer to an instance of IOleClientSite, the primary interface through which the object will request services from its
		/// container. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="pStg">Pointer to the IStorage interface on the storage object. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="ppvObj">
		/// Address of pointer variable that receives the interface pointer requested in <paramref name="riid"/>. Upon successful return,
		/// *ppvObj contains the requested interface pointer on the newly created object.
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLE_E_CANT_BINDTOSOURCE</term>
		/// <term>Not able to bind to source.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>Call <c>OleCreateLink</c> to allow a container to create a link to an object.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreatelink HRESULT OleCreateLink( IN LPMONIKER pmkLinkSrc, IN
		// REFIID riid, IN DWORD renderopt, IN LPFORMATETC lpFormatEtc, IN LPOLECLIENTSITE pClientSite, IN LPSTORAGE pStg, OUT LPVOID *ppvObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "ef52dc37-aa63-47f3-a04f-f9d22178690f")]
		public static extern HRESULT OleCreateLink(IMoniker pmkLinkSrc, in Guid riid, OLERENDER renderopt, in FORMATETC lpFormatEtc, [Optional] IOleClientSite pClientSite, IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

		/// <summary>
		/// Extends <c>OleCreateLink</c> functionality by supporting more efficient instantiation of objects in containers requiring caching
		/// of multiple formats of presentations or data, instead of the single format supported by OleCreateLink.
		/// </summary>
		/// <param name="pmkLinkSrc">Pointer to a moniker to the object to create a link to.</param>
		/// <param name="riid">Reference to the identifier of the interface of the object to return.</param>
		/// <param name="dwFlags">This parameter can be 0 or OLECREATE_LEAVERUNNING (0x00000001).</param>
		/// <param name="renderopt">Value taken from the OLERENDER enumeration.</param>
		/// <param name="cFormats">
		/// When renderopt is OLERENDER_FORMAT, indicates the number of FORMATETC structures in the rgFormatEtc array, which must be at least
		/// one. In all other cases, this parameter must be zero.
		/// </param>
		/// <param name="rgAdvf">
		/// When renderopt is OLERENDER_FORMAT, points to an array of <c>DWORD</c> elements, each of which is a combination of values from
		/// the ADVF enumeration. Each element of this array is passed in as the advf parameter to a call to either IOleCache::Cache or
		/// IDataObject::DAdvise, depending on whether pAdviseSink is <c>NULL</c> or non- <c>NULL</c> (see below). In all other cases, this
		/// parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="rgFormatEtc">
		/// When renderopt is OLERENDER_FORMAT, points to an array of FORMATETC structures. When pAdviseSink is <c>NULL</c>, each element of
		/// this array is passed as the pFormatEtc parameter to a call to the object's IOleCache::Cache. This populates the data and
		/// presentation cache managed by the objects in-process handler (typically the default handler) with presentation or other cacheable
		/// data. When pAdviseSink is non- <c>NULL</c>, each element of this array is passed as the pFormatEtc parameter to a call to
		/// IDataObject::DAdvise. This allows the caller (typically an OLE Container) to do its own caching or processing of data received
		/// from the object.
		/// </param>
		/// <param name="lpAdviseSink">
		/// When renderopt is OLERENDER_FORMAT, may be either a valid IAdviseSink pointer, indicating custom caching or processing of data
		/// advises, or <c>NULL</c>, indicating default caching of data formats.
		/// </param>
		/// <param name="rgdwConnection">
		/// Location to return the array of dwConnection values returned when the IAdviseSink interface is registered for each advisory
		/// connection using IDataObject::DAdvise, or <c>NULL</c> if the returned advisory connections are not needed. This parameter must be
		/// <c>NULL</c> if pAdviseSink is <c>NULL</c>.
		/// </param>
		/// <param name="pClientSite">
		/// Pointer to the primary interface through which the object will request services from its container. This parameter can be
		/// <c>NULL</c>, in which case it is the caller's responsibility to establish the client site as soon as possible using IOleObject::SetClientSite.
		/// </param>
		/// <param name="pStg">
		/// Pointer to the storage to use for the object and any default data or presentation caching established for it.
		/// </param>
		/// <param name="ppvObj">
		/// Address of output pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObj
		/// contains the requested interface pointer on the newly created object.
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
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The following call to OleCreateLink:</para>
		/// <para>is equivalent to the following call to <c>OleCreateLinkEx</c>:</para>
		/// <para>
		/// Existing instantiation functions (OleCreate, OleCreateFromFile, OleCreateFromData, OleCreateLink, OleCreateLinkToFile, and
		/// OleCreateLinkFromData) create only a single presentation or data format cache in the default cache location (within the
		/// '\001OlePresXXX' streams of the passed-in IStorage) during instantiation. Plus, these caches must be created when the object next
		/// enters the running state. Because most applications require caching in at least two presentations (screen and printer) and may
		/// require caching data in a different format or location from the handler, applications must typically launch and shut down the
		/// object server multiple times in order to prime their data caches during object creation, i.e., Insert Object, Insert Object from
		/// File, and Paste Object.
		/// </para>
		/// <para>
		/// Extended versions of these creation functions solve this problem. OleCreateEx, OleCreateFromFileEx, OleCreateFromDataEx,
		/// <c>OleCreateLinkEx</c>, OleCreateLinkToFileEx, and OleCreateLinkFromDataEx, contain the following new parameters: dwFlags to
		/// indicate additional options, cFormats to indicate how many formats to cache, rgAdvf, from the ADVF enumeration, to specify the
		/// advise flags for each format to be cached, pAdviseSink to indicate whether presentation (default-handler) or data
		/// (non-default-handler) caching is required, rgdwConnection to return IDataObject::DAdvise cookies, and rgFormatEtc, an array of
		/// formats rather than a single format.
		/// </para>
		/// <para>
		/// Containers requiring that multiple presentations be cached on their behalf by the object's handler can simply call these
		/// functions and specify the number of formats in cFormats, the ADVF flags for each format in rgAdvf, and the set of formats in
		/// rgFormatEtc. These containers pass <c>NULL</c> for pAdviseSink.
		/// </para>
		/// <para>
		/// Containers performing all their own data- or presentation-caching perform these same steps, but pass a non- <c>NULL</c>
		/// pAdviseSink. They perform their own caching or manipulation of the object or data during IAdviseSink::OnDataChange. Typically,
		/// such containers never establish the advisory connections with ADVF_NODATA, although they are not prevented from doing so.
		/// </para>
		/// <para>
		/// These new functions are for OLE Compound Documents. Using these functions, applications can avoid the repeated launching and
		/// initialization steps required by the current functions. They are targeted at OLE Compound Document container applications that
		/// use default data- and presentation-caching, and also at applications that provide their own caching and data transfer from the
		/// underlying IDataObject::DAdvise support.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreatelinkex HRESULT OleCreateLinkEx( IN LPMONIKER pmkLinkSrc,
		// IN REFIID riid, IN DWORD dwFlags, IN DWORD renderopt, IN ULONG cFormats, IN DWORD *rgAdvf, IN LPFORMATETC rgFormatEtc, IN
		// IAdviseSink *lpAdviseSink, OUT DWORD *rgdwConnection, IN LPOLECLIENTSITE pClientSite, IN LPSTORAGE pStg, OUT LPVOID *ppvObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "b43acd14-3cf8-45da-8c2c-f2f6dc2ada78")]
		public static extern HRESULT OleCreateLinkEx(IMoniker pmkLinkSrc, in Guid riid, OLECREATE dwFlags, OLERENDER renderopt, uint cFormats, [In, Optional] ADVF[] rgAdvf, [In, Optional] FORMATETC[] rgFormatEtc,
			[Optional] IAdviseSink lpAdviseSink, [Out, Optional] uint[] rgdwConnection, [Optional] IOleClientSite pClientSite, IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

		/// <summary>
		/// Creates a linked object from a data transfer object retrieved either from the clipboard or as part of an OLE drag-and-drop operation.
		/// </summary>
		/// <param name="pSrcDataObj">
		/// Pointer to the IDataObject interface on the data transfer object from which the linked object is to be created.
		/// </param>
		/// <param name="riid">
		/// Reference to the identifier of interface the caller later uses to communicate with the new object (usually IID_IOleObject,
		/// defined in the OLE headers as the interface identifier for IOleObject).
		/// </param>
		/// <param name="renderopt">
		/// Value from the enumeration OLERENDER that indicates the locally cached drawing or data-retrieval capabilities the newly created
		/// object is to have. Additional considerations are described in the following Remarks section.
		/// </param>
		/// <param name="pFormatEtc">
		/// Pointer to a value from the enumeration OLERENDER that indicates the locally cached drawing or data-retrieval capabilities the
		/// newly created object is to have. The <c>OLERENDER</c> value chosen affects the possible values for the pFormatEtc parameter.
		/// </param>
		/// <param name="pClientSite">
		/// Pointer to an instance of IOleClientSite, the primary interface through which the object will request services from its
		/// container. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="pStg">Pointer to the IStorage interface on the storage object. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="ppvObj">
		/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, ppvObj contains the
		/// requested interface pointer on the newly created object.
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>CLIPBRD_E_CANT_OPEN</term>
		/// <term>Not able to open the clipboard.</term>
		/// </item>
		/// <item>
		/// <term>OLE_E_CANT_GETMONIKER</term>
		/// <term>Not able to extract the object's moniker.</term>
		/// </item>
		/// <item>
		/// <term>OLE_E_CANT_BINDTOSOURCE</term>
		/// <term>Not able to bind to source. Binding is necessary to get the cache's initialization data.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>OleCreateLinkFromData</c> function is used to implement either a paste-link or a drag-link operation. Its operation is
		/// similar to that of the OleCreateFromData function, except that it creates a link, and looks for different data formats. If the
		/// CF_LINKSOURCE format is not present, and either the FileName or FileNameW clipboard format is present in the data transfer
		/// object, <c>OleCreateLinkFromData</c> creates a package containing the link to the indicated file.
		/// </para>
		/// <para>
		/// You use the renderopt and pFormatetc parameters to control the caching capability of the newly created object. For general
		/// information on how to determine what is to be cached, refer to the OLERENDER enumeration for a description of the interaction
		/// between renderopt and pFormatetc. There are, however, some additional specific effects of these parameters on the way
		/// <c>OleCreateLinkFromData</c> initializes the cache, as follows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLERENDER_DRAW, OLERENDER_FORMAT</term>
		/// <term>
		/// If the presentation information is in the other formats in the source data object, this information is used. If the information
		/// is not present, the cache is initially empty, but will be filled the first time the object is run. No other formats are cached in
		/// the newly created object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OLERENDER_NONE, OLERENDER_ASIS</term>
		/// <term>Nothing is to be cached in the newly created object.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreatelinkfromdata HRESULT OleCreateLinkFromData( IN
		// LPDATAOBJECT pSrcDataObj, IN REFIID riid, IN DWORD renderopt, IN LPFORMATETC pFormatEtc, IN LPOLECLIENTSITE pClientSite, IN
		// LPSTORAGE pStg, OUT LPVOID *ppvObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "3eda0cf5-c33d-43cf-ba8a-02a4f6383adc")]
		public static extern HRESULT OleCreateLinkFromData(IDataObject pSrcDataObj, in Guid riid, OLERENDER renderopt, in FORMATETC pFormatEtc, [Optional] IOleClientSite pClientSite, IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

		/// <summary>
		/// Extends OleCreateLinkFromData functionality by supporting more efficient instantiation of objects in containers requiring caching
		/// of multiple formats of presentations or data, instead of the single format supported by <c>OleCreateLinkFromData</c>.
		/// </summary>
		/// <param name="pSrcDataObj">Pointer to the data object to create a link object from.</param>
		/// <param name="riid">Reference to the identifier of the interface of the object to return.</param>
		/// <param name="dwFlags">This parameter can be 0 or OLECREATE_LEAVERUNNING (0x00000001).</param>
		/// <param name="renderopt">Value taken from the OLERENDER enumeration.</param>
		/// <param name="cFormats">
		/// When renderopt is OLERENDER_FORMAT, indicates the number of FORMATETC structures in the rgFormatEtc array, which must be at least
		/// one. In all other cases, this parameter must be zero.
		/// </param>
		/// <param name="rgAdvf">
		/// When renderopt is OLERENDER_FORMAT, points to an array of <c>DWORD</c> elements, each of which is a combination of values from
		/// the ADVF enumeration. Each element of this array is passed in as the advf parameter to a call to either IOleCache::Cache or
		/// IDataObject::DAdvise, depending on whether pAdviseSink is <c>NULL</c> or non- <c>NULL</c> (see below). In all other cases, this
		/// parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="rgFormatEtc">
		/// When renderopt is OLERENDER_FORMAT, points to an array of FORMATETC structures. When pAdviseSink is <c>NULL</c>, each element of
		/// this array is passed as the pFormatEtc parameter to a call to the object's IOleCache::Cache. This populates the data and
		/// presentation cache managed by the objects in-process handler (typically the default handler) with presentation or other cacheable
		/// data. When pAdviseSink is non- <c>NULL</c>, each element of this array is passed as the pFormatEtc parameter to a call to
		/// IDataObject::DAdvise. This allows the caller (typically an OLE Container) to do its own caching or processing of data received
		/// from the object.
		/// </param>
		/// <param name="lpAdviseSink">
		/// When renderopt is OLERENDER_FORMAT, may be either a valid IAdviseSink pointer, indicating custom caching or processing of data
		/// advises, or <c>NULL</c>, indicating default caching of data formats.
		/// </param>
		/// <param name="rgdwConnection">
		/// Location to return the array of dwConnection values returned when the pAdviseSink interface is registered for each advisory
		/// connection using IDataObject::DAdvise, or <c>NULL</c> if the returned advisory connections are not needed. This parameter must be
		/// <c>NULL</c> if pAdviseSink is <c>NULL</c>.
		/// </param>
		/// <param name="pClientSite">
		/// Pointer to the primary interface through which the object will request services from its container. This parameter can be
		/// <c>NULL</c>, in which case it is the caller's responsibility to establish the client site as soon as possible using IOleObject::SetClientSite.
		/// </param>
		/// <param name="pStg">
		/// Pointer to the storage to use for the object and any default data or presentation caching established for it.
		/// </param>
		/// <param name="ppvObj">
		/// Address of output pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObj
		/// contains the requested interface pointer on the newly created object.
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
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The following call to OleCreateLinkFromData:</para>
		/// <para>is equivalent to the following call to <c>OleCreateLinkFromDataEx</c>:</para>
		/// <para>
		/// Existing instantiation functions (OleCreate, OleCreateFromFile, OleCreateFromData, OleCreateLink, OleCreateLinkToFile, and
		/// OleCreateLinkFromData), create only a single presentation or data format cache in the default cache location (within the
		/// '\001OlePresXXX' streams of the passed-in IStorage) during instantiation. Plus, these caches must be created when the object next
		/// enters the running state. Because most applications require caching at least two presentations (screen and printer) and may
		/// require caching data in a different format or location from the handler, applications must typically launch and shut down the
		/// object server multiple times in order to prime their data caches during object creation, i.e., Insert Object, Insert Object from
		/// File, and Paste Object.
		/// </para>
		/// <para>
		/// Extended versions of these creation functions solve this problem. OleCreateEx, OleCreateFromFileEx, OleCreateFromDataEx,
		/// OleCreateLinkEx, OleCreateLinkToFileEx, and <c>OleCreateLinkFromDataEx</c>, contain the following new parameters: dwFlags to
		/// indicate additional options, cFormats to indicate how many formats to cache, rgAdvf, from the ADVF enumeration, to specify the
		/// advise flags for each format to be cached, pAdviseSink to indicate whether presentation (default-handler) or data
		/// (non-default-handler) caching is required, rgdwConnection to return IDataObject::DAdvise cookies, and rgFormatEtc, an array of
		/// formats rather than a single format.
		/// </para>
		/// <para>
		/// Containers requiring that multiple presentations be cached on their behalf by the object's handler can simply call these
		/// functions and specify the number of formats in cFormats, the ADVF flags for each format in rgAdvf, and the set of formats in
		/// rgFormatEtc. These containers pass <c>NULL</c> for pAdviseSink.
		/// </para>
		/// <para>
		/// Containers performing all their own data- or presentation-caching perform these same steps, but pass a non- <c>NULL</c>
		/// pAdviseSink. They perform their own caching or manipulation of the object or data during IAdviseSink::OnDataChange. Typically
		/// such containers never establish the advisory connections with ADVF_NODATA, although they are not prevented from doing so.
		/// </para>
		/// <para>
		/// These new functions are for OLE Compound Documents. Using these functions, applications can avoid the repeated launching and
		/// initialization steps required by the current functions. They are targeted at OLE Compound Document container applications that
		/// use default data- and presentation-caching, and also at applications that provide their own caching and data transfer from the
		/// underlying IDataObject::DAdvise support.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreatelinkfromdataex HRESULT OleCreateLinkFromDataEx( IN
		// LPDATAOBJECT pSrcDataObj, IN REFIID riid, IN DWORD dwFlags, IN DWORD renderopt, IN ULONG cFormats, IN DWORD *rgAdvf, IN
		// LPFORMATETC rgFormatEtc, IN IAdviseSink *lpAdviseSink, OUT IN DWORD *rgdwConnection, IN LPOLECLIENTSITE pClientSite, IN LPSTORAGE
		// pStg, OUT LPVOID *ppvObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "f486dc73-3cb9-4839-931a-91cc3a5837d3")]
		public static extern HRESULT OleCreateLinkFromDataEx(IDataObject pSrcDataObj, in Guid riid, OLECREATE dwFlags, OLERENDER renderopt, uint cFormats, [In, Optional] ADVF[] rgAdvf, [In, Optional] FORMATETC[] rgFormatEtc,
			[Optional] IAdviseSink lpAdviseSink, [Out, Optional] uint[] rgdwConnection, [Optional] IOleClientSite pClientSite, IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

		/// <summary>Creates an object that is linked to a file.</summary>
		/// <param name="lpszFileName">Pointer to a string naming the source file to be linked to.</param>
		/// <param name="riid">
		/// Reference to the identifier of the interface the caller later uses to communicate with the new object (usually IID_IOleObject,
		/// defined in the OLE headers as the interface identifier for IOleObject).
		/// </param>
		/// <param name="renderopt">
		/// Value from the enumeration OLERENDER that indicates the locally cached drawing or data-retrieval capabilities the newly created
		/// object is to have. Additional considerations are described in the following Remarks section.
		/// </param>
		/// <param name="lpFormatEtc">
		/// Pointer to a value from the enumeration OLERENDER that indicates the locally cached drawing or data-retrieval capabilities the
		/// newly created object is to have. The <c>OLERENDER</c> value chosen affects the possible values for the pFormatEtc parameter.
		/// </param>
		/// <param name="pClientSite">
		/// Pointer to an instance of IOleClientSite, the primary interface through which the object will request services from its
		/// container. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="pStg">Pointer to the IStorage interface on the storage object. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="ppvObj">
		/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObj contains the
		/// requested interface pointer on the newly created object.
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STG_E_FILENOTFOUND</term>
		/// <term>The file name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>OLE_E_CANT_BINDTOSOURCE</term>
		/// <term>Not able to bind to source.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The <c>OleCreateLinkToFile</c> function differs from the OleCreateLink function because it can create links both to files that
		/// are not aware of OLE, as well as to those that are using the Windows Packager.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreatelinktofile HRESULT OleCreateLinkToFile( IN LPCOLESTR
		// lpszFileName, IN REFIID riid, IN DWORD renderopt, IN LPFORMATETC lpFormatEtc, IN LPOLECLIENTSITE pClientSite, IN LPSTORAGE pStg,
		// OUT LPVOID *ppvObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "06b013db-0554-4dbc-b19d-28314fb4fee0")]
		public static extern HRESULT OleCreateLinkToFile([MarshalAs(UnmanagedType.LPWStr)] string lpszFileName, in Guid riid, OLERENDER renderopt, in FORMATETC lpFormatEtc, [Optional] IOleClientSite pClientSite, IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

		/// <summary>
		/// Extends OleCreateLinkToFile functionality by supporting more efficient instantiation of objects in containers requiring caching
		/// of multiple formats of presentations or data, instead of the single format supported by <c>OleCreateLinkToFile</c>.
		/// </summary>
		/// <param name="lpszFileName">Pointer to the name of the file to create a link to.</param>
		/// <param name="riid">Reference to the identifier of the interface of the object to return.</param>
		/// <param name="dwFlags">This parameter can be 0 or OLECREATE_LEAVERUNNING (0x00000001).</param>
		/// <param name="renderopt">Value taken from the OLERENDER enumeration.</param>
		/// <param name="cFormats">
		/// When renderopt is OLERENDER_FORMAT, indicates the number of FORMATETC structures in the rgFormatEtc array, which must be at least
		/// one. In all other cases, this parameter must be zero.
		/// </param>
		/// <param name="rgAdvf">
		/// When renderopt is OLERENDER_FORMAT, points to an array of <c>DWORD</c> elements, each of which is a combination of values from
		/// the ADVF enumeration. Each element of this array is passed in as the advf parameter to a call to either IOleCache::Cache or
		/// IDataObject::DAdvise, depending on whether pAdviseSink is <c>NULL</c> or non- <c>NULL</c> (see below). In all other cases, this
		/// parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="rgFormatEtc">
		/// When renderopt is OLERENDER_FORMAT, points to an array of FORMATETC structures. When pAdviseSink is <c>NULL</c>, each element of
		/// this array is passed as the pFormatEtc parameter to a call to the object's IOleCache::Cache. This populates the data and
		/// presentation cache managed by the objects in-process handler (typically the default handler) with presentation or other cacheable
		/// data. When pAdviseSink is non- <c>NULL</c>, each element of this array is passed as the pFormatEtc parameter to a call to
		/// IDataObject::DAdvise. This allows the caller (typically an OLE Container) to do its own caching or processing of data received
		/// from the object.
		/// </param>
		/// <param name="lpAdviseSink">
		/// When renderopt is OLERENDER_FORMAT, may be either a valid IAdviseSink pointer, indicating custom caching or processing of data
		/// advises, or <c>NULL</c>, indicating default caching of data formats.
		/// </param>
		/// <param name="rgdwConnection">
		/// Location to return the array of dwConnection values returned when the IAdviseSink interface is registered for each advisory
		/// connection using IDataObject::DAdvise, or <c>NULL</c> if the returned advisory connections are not needed. This parameter must be
		/// <c>NULL</c> if pAdviseSink is <c>NULL</c>.
		/// </param>
		/// <param name="pClientSite">
		/// Pointer to the primary interface through which the object will request services from its container. This parameter may be
		/// <c>NULL</c>, in which case it is the caller's responsibility to establish the client site as soon as possible using IOleObject::SetClientSite.
		/// </param>
		/// <param name="pStg">
		/// Pointer to the storage to use for the object and any default data or presentation caching established for it.
		/// </param>
		/// <param name="ppvObj">
		/// Address of output pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObj
		/// contains the requested interface pointer on the newly created object.
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
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The following call to OleCreateLinkToFile:</para>
		/// <para>is equivalent to the following call to <c>OleCreateLinkToFileEx</c>:</para>
		/// <para>
		/// Existing instantiation functions (OleCreate, OleCreateFromFile, OleCreateFromData, OleCreateLink, OleCreateLinkToFile, and
		/// OleCreateLinkFromData) create only a single presentation or data format cache in the default cache location (within the
		/// '\001OlePresXXX' streams of the passed-in IStorage) during instantiation. Plus, these caches must be created when the object next
		/// enters the running state. Because most applications require caching at least two presentations (screen and printer) and may
		/// require caching data in a different format or location from the handler, applications must typically launch and shut down the
		/// object server multiple times in order to prime their data caches during object creation, i.e., Insert Object, Insert Object from
		/// File, and Paste Object.
		/// </para>
		/// <para>
		/// Extended versions of these creation functions solve this problem. OleCreateEx, OleCreateFromFileEx, OleCreateFromDataEx,
		/// OleCreateLinkEx, <c>OleCreateLinkToFileEx</c>, and OleCreateLinkFromDataEx, contain the following new parameters: dwFlags to
		/// indicate additional options, cFormats to indicate how many formats to cache, rgAdvf, from the ADVF enumeration, to specify the
		/// advise flags for each format to be cached, pAdviseSink to indicate whether presentation (default-handler) or data
		/// (non-default-handler) caching is required, rgdwConnection to return IDataObject::DAdvise cookies, and rgFormatEtc, an array of
		/// formats rather than a single format.
		/// </para>
		/// <para>
		/// Containers requiring that multiple presentations be cached on their behalf by the object's handler can simply call these
		/// functions and specify the number of formats in cFormats, the ADVF flags for each format in rgAdvf, and the set of formats in
		/// rgFormatEtc. These containers pass <c>NULL</c> for pAdviseSink.
		/// </para>
		/// <para>
		/// Containers performing all their own data- or presentation-caching perform these same steps, but pass a non- <c>NULL</c>
		/// pAdviseSink. They perform their own caching or manipulation of the object or data during IAdviseSink::OnDataChange. Typically,
		/// such containers never establish the advisory connections with ADVF_NODATA, although they are not prevented from doing so.
		/// </para>
		/// <para>
		/// These new functions are for OLE Compound Documents. Using these functions, applications can avoid the repeated launching and
		/// initialization steps required by the current functions. They are targeted at OLE Compound Document container applications that
		/// use default data- and presentation-caching, and also at applications that provide their own caching and data transfer from the
		/// underlying IDataObject::DAdvise support.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreatelinktofileex HRESULT OleCreateLinkToFileEx( IN LPCOLESTR
		// lpszFileName, IN REFIID riid, IN DWORD dwFlags, IN DWORD renderopt, IN ULONG cFormats, IN DWORD *rgAdvf, IN LPFORMATETC
		// rgFormatEtc, IN IAdviseSink *lpAdviseSink, OUT DWORD *rgdwConnection, IN LPOLECLIENTSITE pClientSite, IN LPSTORAGE pStg, OUT
		// LPVOID *ppvObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "9a333bac-8ee3-4941-8e4b-78a2befceff8")]
		public static extern HRESULT OleCreateLinkToFileEx([MarshalAs(UnmanagedType.LPWStr)] string lpszFileName, in Guid riid, OLECREATE dwFlags, OLERENDER renderopt, uint cFormats, [In, Optional] ADVF[] rgAdvf, [In, Optional] FORMATETC[] rgFormatEtc,
			[Optional] IAdviseSink lpAdviseSink, [Out, Optional] uint[] rgdwConnection, [Optional] IOleClientSite pClientSite, IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

		/// <summary>
		/// Creates and returns an OLE menu descriptor (that is, an OLE-provided data structure that describes the menus) for OLE to use when
		/// dispatching menu messages and commands.
		/// </summary>
		/// <param name="hmenuCombined">Handle to the combined menu created by the object.</param>
		/// <param name="lpMenuWidths">Pointer to an array of six <c>LONG</c> values giving the number of menus in each group.</param>
		/// <returns>Returns the handle to the descriptor, or <c>NULL</c> if insufficient memory is available.</returns>
		/// <remarks>
		/// The <c>OleCreateMenuDescriptor</c> function can be called by the object to create a descriptor for the composite menu. OLE then
		/// uses this descriptor to dispatch menu messages and commands. To free the shared menu descriptor when it is no longer needed, the
		/// container should call the companion helper function, OleDestroyMenuDescriptor.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreatemenudescriptor HOLEMENU OleCreateMenuDescriptor( IN HMENU
		// hmenuCombined, IN LPOLEMENUGROUPWIDTHS lpMenuWidths );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "b4a6b3f1-aee9-4b68-8ffe-24bd497db0a0")]
		public static extern HOLEMENU OleCreateMenuDescriptor(HMENU hmenuCombined, in OLEMENUGROUPWIDTHS lpMenuWidths);

		/// <summary>
		/// <para>Creates a static object, that contains only a representation, with no native data, from a data transfer object.</para>
		/// <para><c>Note</c> The OLESTREAM to IStorage conversion functions also convert static objects.</para>
		/// </summary>
		/// <param name="pSrcDataObj">
		/// Pointer to the IDataObject interface on the data transfer object that holds the data from which the object will be created.
		/// </param>
		/// <param name="iid">
		/// Reference to the identifier of the interface with which the caller is to communicate with the new object (usually IID_IOleObject,
		/// defined in the OLE headers as the interface identifier for IOleObject).
		/// </param>
		/// <param name="renderopt">
		/// Value from the enumeration OLERENDER indicating the locally cached drawing or data-retrieval capabilities that the container
		/// wants in the newly created component. It is an error to pass the render options OLERENDER_NONE or OLERENDER_ASIS to this function.
		/// </param>
		/// <param name="pFormatEtc">
		/// Depending on which of the OLERENDER flags is used as the value of renderopt, may be a pointer to one of the FORMATETC enumeration
		/// values. Refer to the <c>OLERENDER</c> enumeration for restrictions.
		/// </param>
		/// <param name="pClientSite">
		/// Pointer to an instance of IOleClientSite, the primary interface through which the object will request services from its
		/// container. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="pStg">Pointer to the IStorage interface for storage for the object. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="ppvObj">
		/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObj contains the
		/// requested interface pointer on the newly created object.
		/// </param>
		/// <returns>This function returns S_OK on success.</returns>
		/// <remarks>
		/// <para>
		/// The <c>OleCreateStaticFromData</c> function can convert any object, as long as it provides an IDataObject interface, to a static
		/// object. It is useful in implementing the Convert To Picture option for OLE linking or embedding.
		/// </para>
		/// <para>
		/// Static objects can be created only if the source supports one of the OLE-rendered clipboard formats: CF_METAFILEPICT, CF_DIB, or
		/// CF_ BITMAP, and CF_ENHMETAFILE.
		/// </para>
		/// <para>
		/// You can also call <c>OleCreateStaticFromData</c> to paste a static object from the clipboard. To determine whether an object is
		/// static, call the OleQueryCreateFromData function, which returns OLE_S_STATIC if one of CF_METAFILEPICT, CF_DIB, CF_BITMAP, or
		/// CF_ENHMETAFILE is present and an OLE format is not present. This indicates that you should call <c>OleCreateStaticFromData</c>
		/// rather than the OleCreateFromData function to create the object.
		/// </para>
		/// <para>
		/// The new static object is of class CLSID_StaticMetafile in the case of CF_METAFILEPICT, CLSID_StaticDib in the case of CF_DIB or
		/// CF_BITMAP, or CLSID_Picture_EnhMetafile in the case of CF_ENHMETAFILE. The static object sets the OLEMISC_STATIC and
		/// OLE_CANTLINKINSIDE bits returned from IOleObject::GetMiscStatus. The static object will have the aspect DVASPECT_CONTENT and a
		/// LINDEX of -1.
		/// </para>
		/// <para>
		/// The pSrcDataObject is still valid after <c>OleCreateStaticFromData</c> returns. It is the caller's responsibility to free
		/// pSrcDataObject â€” OLE does not release it.
		/// </para>
		/// <para>There cannot be more than one presentation stream in a static object.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olecreatestaticfromdata HRESULT OleCreateStaticFromData( IN
		// LPDATAOBJECT pSrcDataObj, IN REFIID iid, IN DWORD renderopt, IN LPFORMATETC pFormatEtc, IN LPOLECLIENTSITE pClientSite, IN
		// LPSTORAGE pStg, OUT LPVOID *ppvObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "847d82f5-149d-48a4-a228-f5551a07a790")]
		public static extern HRESULT OleCreateStaticFromData(IDataObject pSrcDataObj, in Guid iid, OLERENDER renderopt, in FORMATETC pFormatEtc, [Optional] IOleClientSite pClientSite, IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

		/// <summary>Called by the container to free the shared menu descriptor allocated by the OleCreateMenuDescriptor function.</summary>
		/// <param name="holemenu">Handle to the shared menu descriptor that was returned by the OleCreateMenuDescriptor function.</param>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oledestroymenudescriptor HRESULT OleDestroyMenuDescriptor( IN
		// HOLEMENU holemenu );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "dc347d39-a7bb-4bbf-8957-c3fbcff461bf")]
		public static extern HRESULT OleDestroyMenuDescriptor(HOLEMENU holemenu);

		/// <summary>Automatically converts an object to a new class if automatic conversion for that object class is set in the registry.</summary>
		/// <param name="pStg">A pointer to the IStorage interface on the storage object to be converted.</param>
		/// <param name="pClsidNew">
		/// A pointer to the new CLSID for the object being converted. If there was no automatic conversion, this may be the same as the
		/// original class.
		/// </param>
		/// <returns>
		/// <para>
		/// This function can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>No conversion is needed or a conversion was successfully completed.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_KEYMISSING</term>
		/// <term>The function cannot read a key from the registry.</term>
		/// </item>
		/// </list>
		/// <para>
		/// This function can also return any of the error values returned by the OleGetAutoConvert function. When accessing storage and
		/// stream objects, see the IStorage::OpenStorage and IStorage::OpenStream methods for possible errors. When it is not possible to
		/// determine the existing CLSID or when it is not possible to update the storage object with new information, see the IStream
		/// interface for other error return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>OleDoAutoConvert</c> automatically converts an object if automatic conversion has previously been specified in the registry by
		/// the OleSetAutoConvert function. Object conversion means that the object is permanently associated with a new CLSID. Automatic
		/// conversion is typically specified by the setup program for a new version of an object application, so that objects created by its
		/// older versions can be automatically updated.
		/// </para>
		/// <para>The storage object must be in the unloaded state when <c>OleDoAutoConvert</c> is called.</para>
		/// <para>
		/// A container application that supports object conversion should call <c>OleDoAutoConvert</c> each time it loads an object. If the
		/// container uses the OleLoad helper function, it need not call <c>OleDoAutoConvert</c> explicitly because <c>OleLoad</c> calls it internally.
		/// </para>
		/// <para>
		/// <c>OleDoAutoConvert</c> first determines whether any conversion is required by calling the OleGetAutoConvert function, which, if
		/// no conversion is required, returns S_OK. If the object requires conversion, <c>OleDoAutoConvert</c> modifies and converts the
		/// storage object by activating the new object application. The new object application reads the existing data format, but saves the
		/// object in the new native format for the object application.
		/// </para>
		/// <para>
		/// If the object to be automatically converted is an OLE 1 object, the ItemName string is stored in a stream called
		/// "\1Ole10ItemName." If this stream does not exist, the object's item name is <c>NULL</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oledoautoconvert HRESULT OleDoAutoConvert( IN LPSTORAGE pStg, OUT
		// LPCLSID pClsidNew );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "fe470f8a-b2f0-48a4-a270-77420bd1472a")]
		public static extern HRESULT OleDoAutoConvert(IStorage pStg, out Guid pClsidNew);

		/// <summary>Enables drawing objects more easily. You can use it instead of calling IViewObject::Draw directly.</summary>
		/// <param name="pUnknown">Points to the view object that is to be drawn.</param>
		/// <param name="dwAspect">
		/// Specifies how the object is to be represented. Representations include content, an icon, a thumbnail, or a printed document.
		/// Valid values are taken from the enumeration DVASPECT. See DVASPECT for more information.
		/// </param>
		/// <param name="hdcDraw">Specifies the device context on which to draw. Cannot be a metafile device context.</param>
		/// <param name="lprcBounds">
		/// Points to a RECT structure specifying the rectangle in which the object should be drawn. This parameter is converted to a RECTL
		/// structure and passed to IViewObject::Draw.
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLE_E_BLANK</term>
		/// <term>No data to draw from.</term>
		/// </item>
		/// <item>
		/// <term>E_ABORT</term>
		/// <term>The draw operation was aborted.</term>
		/// </item>
		/// <item>
		/// <term>VIEW_E_DRAW</term>
		/// <term>No data to draw from.</term>
		/// </item>
		/// <item>
		/// <term>OLE_E_INVALIDRECT</term>
		/// <term>The rectangle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory for the operation.</term>
		/// </item>
		/// <item>
		/// <term>DV_E_NOIVIEWOBJECT</term>
		/// <term>The object doesn't support the IViewObject interface.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The OleDraw helper function calls the QueryInterface method for the object specified (pUnk), asking for an IViewObject interface
		/// on that object. Then, <c>OleDraw</c> converts the RECT structure to a RECTL structure, and calls IViewObject::Draw as follows:
		/// </para>
		/// <para>Do not use this function to draw into a metafile because it does not specify the parameter required for drawing into metafiles.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oledraw HRESULT OleDraw( IN LPUNKNOWN pUnknown, IN DWORD dwAspect,
		// IN HDC hdcDraw, IN LPCRECT lprcBounds );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "c45c6746-59ea-43bb-9f2b-2182d7a3fc7a")]
		public static extern HRESULT OleDraw([MarshalAs(UnmanagedType.IUnknown)] object pUnknown, DVASPECT dwAspect, HDC hdcDraw, in RECT lprcBounds);

		/// <summary>
		/// Duplicates the data found in the specified handle and returns a handle to the duplicated data. The source data is in a clipboard
		/// format. Use this function to help implement some of the data transfer interfaces such as IDataObject.
		/// </summary>
		/// <param name="hSrc">Handle of the source data.</param>
		/// <param name="cfFormat">Clipboard format of the source data.</param>
		/// <param name="uiFlags">
		/// Flags to be used to allocate global memory for the copied data. These flags are passed to GlobalAlloc. If the value of uiFlags is
		/// <c>NULL</c>, GMEM_MOVEABLE is used as a default flag.
		/// </param>
		/// <returns>On success the HANDLE to the source data is returned; on failure a <c>NULL</c> value is returned.</returns>
		/// <remarks>
		/// The CF_METAFILEPICT, CF_PALETTE, or CF_BITMAP formats receive special handling. They are GDI handles and a new GDI object must be
		/// created instead of just copying the bytes. All other formats are duplicated byte-wise.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oleduplicatedata HANDLE OleDuplicateData( IN HANDLE hSrc, IN
		// CLIPFORMAT cfFormat, IN UINT uiFlags );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "c4ba0b54-e9e1-4c05-b4f8-ce5390cada17")]
		public static extern HANDLE OleDuplicateData(HANDLE hSrc, CLIPFORMAT cfFormat, Kernel32.GMEM uiFlags);

		/// <summary>
		/// Carries out the clipboard shutdown sequence. It also releases the IDataObject pointer that was placed on the clipboard by the
		/// OleSetClipboard function.
		/// </summary>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>CLIPBRD_E_CANT_OPEN</term>
		/// <term>The Windows OpenClipboard function used within OleFlushClipboard failed.</term>
		/// </item>
		/// <item>
		/// <term>CLIPBRD_E_CANT_CLOSE</term>
		/// <term>The Windows CloseClipboard function used within OleFlushClipboard failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>OleFlushClipboard</c> renders the data from a data object onto the clipboard and releases the IDataObject pointer to the data
		/// object. While the application that put the data object on the clipboard is running, the clipboard holds only a pointer to the
		/// data object, thus saving memory. If you are writing an application that acts as the source of a clipboard operation, you can call
		/// the <c>OleFlushClipboard</c> function when your application is closed, such as when the user exits from your application. Calling
		/// <c>OleFlushClipboard</c> enables pasting and paste-linking of OLE objects after application shutdown.
		/// </para>
		/// <para>
		/// Before calling <c>OleFlushClipboard</c>, you can easily determine if your data is still on the clipboard with a call to the
		/// OleIsCurrentClipboard function.
		/// </para>
		/// <para>
		/// <c>OleFlushClipboard</c> leaves all formats offered by the data transfer object, including the OLE 1 compatibility formats, on
		/// the clipboard so they are available after application shutdown. In addition to OLE 1 compatibility formats, these include all
		/// formats offered on a global handle medium (all except for TYMED_FILE) and formatted with a <c>NULL</c> target device. For
		/// example, if a data-source application offers a particular clipboard format (say cfFOO) on an IStorage object, and calls the
		/// <c>OleFlushClipboard</c> function, the storage object is copied into memory and the hglobal memory handle is put on the clipboard.
		/// </para>
		/// <para>
		/// To retrieve the information on the clipboard, you can call the OleGetClipboard function from another application, which creates a
		/// default data object, and the hglobal from the clipboard again becomes a storage object. Furthermore, the FORMATETC enumerator and
		/// the IDataObject::QueryGetData method would all correctly indicate that the original clipboard format (cfFOO) is again available
		/// on a TYMED_ISTORAGE.
		/// </para>
		/// <para>
		/// To empty the clipboard, call the OleSetClipboard function specifying a <c>NULL</c> value for its parameter. The application
		/// should call this when it closes if there is no need to leave data on the clipboard after shutdown, or if data will be placed on
		/// the clipboard using the standard Windows clipboard functions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oleflushclipboard HRESULT OleFlushClipboard( );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "18291a91-be7d-42ec-a44a-d1bbfb017c6e")]
		public static extern HRESULT OleFlushClipboard();

		/// <summary>
		/// Determines whether the registry is set for objects of a specified CLSID to be automatically converted to another CLSID, and if
		/// so, retrieves the new CLSID.
		/// </summary>
		/// <param name="clsidOld">The CLSID for the object.</param>
		/// <param name="pClsidNew">
		/// A pointer to a variable to receive the new CLSID, if any. If auto-conversion for clsidOld is not set in the registry, clsidOld is
		/// returned. The pClsidNew parameter is never <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// This function can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>A value was successfully returned through the pclsidNew parameter.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_CLASSNOTREG</term>
		/// <term>The CLSID is not properly registered in the registry.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_READREGDB</term>
		/// <term>Error reading from the registry.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_KEYMISSING</term>
		/// <term>Auto-convert is not active or there was no registry entry for the clsidOld parameter.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>OleGetAutoConvert</c> returns the <c>AutoConvertTo</c> entry in the registry for the specified object. The
		/// <c>AutoConvertTo</c> subkey specifies whether objects of a given CLSID are to be automatically converted to a new CLSID. This is
		/// usually used to convert files created by older versions of an application to the current version. If there is no
		/// <c>AutoConvertTo</c> entry, this function returns the value of clsidOld.
		/// </para>
		/// <para>
		/// The OleDoAutoConvert function calls <c>OleGetAutoConvert</c> to determine whether the object specified is to be converted. A
		/// container application that supports object conversion should call <c>OleDoAutoConvert</c> each time it loads an object. If the
		/// container uses the OleLoad helper function, it need not call <c>OleDoAutoConvert</c> explicitly because <c>OleLoad</c> calls it internally.
		/// </para>
		/// <para>
		/// To set up automatic conversion of a given class, you can call the OleSetAutoConvert function (typically in the setup program of
		/// an application installation). This function uses the <c>AutoConvertTo</c> subkey to tag a class of objects for automatic
		/// conversion to a different class of objects. This is a subkey of the CLSID key.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olegetautoconvert HRESULT OleGetAutoConvert( IN REFCLSID clsidOld,
		// OUT LPCLSID pClsidNew );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "f84e578a-d2ed-4b7b-9b7c-5d63f12d5781")]
		public static extern HRESULT OleGetAutoConvert(in Guid clsidOld, out Guid pClsidNew);

		/// <summary>Retrieves a data object that you can use to access the contents of the clipboard.</summary>
		/// <param name="ppDataObj">Address of IDataObject pointer variable that receives the interface pointer to the clipboard data object.</param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>CLIPBRD_E_CANT_OPEN</term>
		/// <term>The OpenClipboard function used within OleFlushClipboard failed.</term>
		/// </item>
		/// <item>
		/// <term>CLIPBRD_E_CANT_CLOSE</term>
		/// <term>The CloseClipboard function used within OleFlushClipboard failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para><c>Caution</c> Clipboard data is not trusted. Parse the data carefully before using it in your application.</para>
		/// <para>
		/// If you are writing an application that can accept data from the clipboard, call the <c>OleGetClipboard</c> function to get a
		/// pointer to the IDataObject interface that you can use to retrieve the contents of the clipboard.
		/// </para>
		/// <para><c>OleGetClipboard</c> handles three cases:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The application that placed data on the clipboard with the OleSetClipboard function is still running.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The application that placed data on the clipboard with the OleSetClipboard function has subsequently called the OleFlushClipboard function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>There is data from a non-OLE application on the clipboard.</term>
		/// </item>
		/// </list>
		/// <para>
		/// In the first case, the clipboard data object returned by <c>OleGetClipboard</c> may forward calls as necessary to the original
		/// data object placed on the clipboard and, thus, can potentially make RPC calls.
		/// </para>
		/// <para>
		/// In the second case, OLE creates a default data object and returns it to the user. Because the data on the clipboard originated
		/// from an OleSetClipboard call, the OLE-provided data object contains more accurate information about the type of data on the
		/// clipboard. In particular, the original medium (TYMED) on which the data was offered is known. Thus, if a data-source application
		/// offers a particular clipboard format, for example cfFOO, on a storage object and calls the OleFlushClipboard function, the
		/// storage object is copied into memory and the hglobal memory handle is put on the clipboard. Then, when the <c>OleGetClipboard</c>
		/// function creates its default data object, the hglobal from the clipboard again becomes an IStorage object. Furthermore, the
		/// FORMATETC enumerator and the IDataObject::QueryGetData method would all correctly indicate that the original clipboard format
		/// (cfFOO) is again available on a TYMED_ISTORAGE.
		/// </para>
		/// <para>
		/// In the third case, OLE still creates a default data object, but there is no special information about the data in the clipboard
		/// formats (particularly for application-defined Clipboard formats). Thus, if an hGlobal-based storage medium were put on the
		/// clipboard directly by a call to the SetClipboardData function, the FORMATETC enumerator and the IDataObject::QueryGetData method
		/// would not indicate that the data was available on a storage medium. A call to the IDataObject::GetData method for TYMED_ISTORAGE
		/// would succeed, however. Because of these limitations, it is strongly recommended that OLE-aware applications interact with the
		/// clipboard using the OLE clipboard functions.
		/// </para>
		/// <para>
		/// The clipboard data object created by the <c>OleGetClipboard</c> function has a fairly extensive IDataObject implementation. The
		/// OLE-provided data object can convert OLE 1 clipboard format data into the representation expected by an OLE 2 caller. Also, any
		/// structured data is available on any structured or flat medium, and any flat data is available on any flat medium. However, GDI
		/// objects (such as metafiles and bitmaps) are only available on their respective mediums.
		/// </para>
		/// <para>
		/// Note that the tymed member of the FORMATETC structure used in the <c>FORMATETC</c> enumerator contains the union of supported
		/// mediums. Applications looking for specific information (such as whether CF_TEXT is available on TYMED_HGLOBAL) should do the
		/// appropriate bitmasking when checking this value.
		/// </para>
		/// <para>
		/// If you call the <c>OleGetClipboard</c> function, you should only hold on to the returned IDataObject for a very short time. It
		/// consumes resources in the application that offered it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olegetclipboard HRESULT OleGetClipboard( LPDATAOBJECT *ppDataObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "c5e7badb-339b-48d5-8c9a-3950e2ffe6bf")]
		public static extern HRESULT OleGetClipboard(out IDataObject ppDataObj);

		/// <summary>
		/// <para>
		/// Enables Windows Information Protection enlightened applications to retrieve an IDataObject from the OLE Clipboard accompanied by
		/// Windows Information Protection information about the data and the source application. This information allows the enlightened
		/// application to take over responsibility for applying Windows Information Protection policy, including flying any appropriate UI
		/// prompts, and auditing cases where the user explicitly approves copying enterprise data into a personal context.
		/// </para>
		/// <para>
		/// If the calling application is not enlightened, or is configured as "unallowed" to access enterprise data, then this call behaves
		/// exactly like OleGetClipboard - applying policy before deciding what IDataObject to return, and supplying empty strings as output.
		/// </para>
		/// </summary>
		/// <param name="dataObject">
		/// Address of IDataObject pointer variable that receives the interface pointer to the clipboard data object.
		/// </param>
		/// <param name="dataEnterpriseId">
		/// The enterprise id of the application that set the clipboard data. If the data is personal, this will be an empty string.
		/// </param>
		/// <param name="sourceDescription">The description of the application that set the clipboard.</param>
		/// <param name="targetDescription">The description of the caller's application to be used in auditing.</param>
		/// <param name="dataDescription">The description of the data object to be used in auditing.</param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>CLIPBRD_E_CANT_OPEN</term>
		/// <term>The OpenClipboard function used within OleFlushClipboard failed.</term>
		/// </item>
		/// <item>
		/// <term>CLIPBRD_E_CANT_CLOSE</term>
		/// <term>The CloseClipboard function used within OleFlushClipboard failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para><c>Caution</c> Clipboard data is not trusted. Parse the data carefully before using it in your application.</para>
		/// <para>
		/// If you are writing an application that can accept data from the clipboard, call the <c>OleGetClipboardWithEnterpriseInfo</c>
		/// function to get a pointer to the IDataObject interface that you can use to retrieve the contents of the clipboard.
		/// </para>
		/// <para><c>OleGetClipboardWithEnterpriseInfo</c> handles three cases:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The application that placed data on the clipboard with the OleSetClipboard function is still running.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The application that placed data on the clipboard with the OleSetClipboard function has subsequently called the OleFlushClipboard function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>There is data from a non-OLE application on the clipboard.</term>
		/// </item>
		/// </list>
		/// <para>
		/// In the first case, the clipboard data object returned by <c>OleGetClipboardWithEnterpriseInfo</c> may forward calls as necessary
		/// to the original data object placed on the clipboard and, thus, can potentially make RPC calls.
		/// </para>
		/// <para>
		/// In the second case, OLE creates a default data object and returns it to the user. Because the data on the clipboard originated
		/// from an OleSetClipboard call, the OLE-provided data object contains more accurate information about the type of data on the
		/// clipboard. In particular, the original medium (TYMED) on which the data was offered is known. Thus, if a data-source application
		/// offers a particular clipboard format, for example cfFOO, on a storage object and calls the OleFlushClipboard function, the
		/// storage object is copied into memory and the hglobal memory handle is put on the clipboard. Then, when the
		/// <c>OleGetClipboardWithEnterpriseInfo</c> function creates its default data object, the hglobal from the clipboard again becomes
		/// an IStorage object. Furthermore, the FORMATETC enumerator and the IDataObject::QueryGetData method would all correctly indicate
		/// that the original clipboard format (cfFOO) is again available on a TYMED_ISTORAGE.
		/// </para>
		/// <para>
		/// In the third case, OLE still creates a default data object, but there is no special information about the data in the clipboard
		/// formats (particularly for application-defined Clipboard formats). Thus, if an hGlobal-based storage medium were put on the
		/// clipboard directly by a call to the SetClipboardData function, the FORMATETC enumerator and the IDataObject::QueryGetData method
		/// would not indicate that the data was available on a storage medium. A call to the IDataObject::GetData method for TYMED_ISTORAGE
		/// would succeed, however. Because of these limitations, it is strongly recommended that OLE-aware applications interact with the
		/// clipboard using the OLE clipboard functions.
		/// </para>
		/// <para>
		/// The clipboard data object created by the <c>OleGetClipboardWithEnterpriseInfo</c> function has a fairly extensive IDataObject
		/// implementation. The OLE-provided data object can convert OLE 1 clipboard format data into the representation expected by an OLE 2
		/// caller. Also, any structured data is available on any structured or flat medium, and any flat data is available on any flat
		/// medium. However, GDI objects (such as metafiles and bitmaps) are only available on their respective mediums.
		/// </para>
		/// <para>
		/// Note that the tymed member of the FORMATETC structure used in the <c>FORMATETC</c> enumerator contains the union of supported
		/// mediums. Applications looking for specific information (such as whether CF_TEXT is available on TYMED_HGLOBAL) should do the
		/// appropriate bitmasking when checking this value.
		/// </para>
		/// <para>
		/// If you call the <c>OleGetClipboardWithEnterpriseInfo</c> function, you should only hold on to the returned IDataObject for a very
		/// short time. It consumes resources in the application that offered it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olegetclipboardwithenterpriseinfo HRESULT
		// OleGetClipboardWithEnterpriseInfo( IDataObject **dataObject, PWSTR *dataEnterpriseId, PWSTR *sourceDescription, PWSTR
		// *targetDescription, PWSTR *dataDescription );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("ole2.h", MSDNShortId = "1DAD2A9A-EDA2-49D2-90F7-2A9022988177")]
		public static extern HRESULT OleGetClipboardWithEnterpriseInfo(out IDataObject dataObject, out StrPtrUni dataEnterpriseId, out StrPtrUni sourceDescription, out StrPtrUni targetDescription, out StrPtrUni dataDescription);

		/// <summary>Returns a handle to a metafile containing an icon and a string label for the specified CLSID.</summary>
		/// <param name="rclsid">The CLSID for which the icon and string are to be requested.</param>
		/// <param name="lpszLabel">A pointer to the label for the icon.</param>
		/// <param name="fUseTypeAsLabel">Indicates whether to use the user type string in the CLSID as the icon label.</param>
		/// <returns>
		/// If the function succeeds, the return value is a handle to a metafile that contains and icon and label for the specified CLSID.
		/// Otherwise, the function returns <c>NULL</c>.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olegeticonofclass HGLOBAL OleGetIconOfClass( IN REFCLSID rclsid,
		// LPOLESTR lpszLabel, IN BOOL fUseTypeAsLabel );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "88ac1c14-b5a8-4100-9fa5-d7af35052b48")]
		public static extern SafeHGlobalHandle OleGetIconOfClass(in Guid rclsid, [Optional, MarshalAs(UnmanagedType.LPWStr)] string lpszLabel, [MarshalAs(UnmanagedType.Bool)] bool fUseTypeAsLabel);

		/// <summary>Returns a handle to a metafile containing an icon and string label for the specified file name.</summary>
		/// <param name="lpszPath">A pointer to a file for which the icon and string are to be requested.</param>
		/// <param name="fUseFileAsLabel">Indicates whether to use the file name as the icon label.</param>
		/// <returns>
		/// If the function succeeds, the return value is a handle to a metafile that contains and icon and label for the specified file. If
		/// there is no CLSID in the registration database for the file, then the function returns the string "Document". If lpszPath is
		/// <c>NULL</c>, the function returns <c>NULL</c>.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olegeticonoffile HGLOBAL OleGetIconOfFile( LPOLESTR lpszPath, IN
		// BOOL fUseFileAsLabel );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "2fa9cd75-4dc6-45a3-aa62-e82bd28289a5")]
		public static extern SafeHGlobalHandle OleGetIconOfFile([MarshalAs(UnmanagedType.LPWStr)] string lpszPath, [MarshalAs(UnmanagedType.Bool)] bool fUseFileAsLabel);

		/// <summary>
		/// Initializes the COM library on the current apartment, identifies the concurrency model as single-thread apartment (STA), and
		/// enables additional functionality described in the Remarks section below. Applications must initialize the COM library before they
		/// can call COM library functions other than CoGetMalloc and memory allocation functions.
		/// </summary>
		/// <param name="pvReserved">This parameter is reserved and must be <c>NULL</c>.</param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The COM library is already initialized on this apartment.</term>
		/// </item>
		/// <item>
		/// <term>OLE_E_WRONGCOMPOBJ</term>
		/// <term>The versions of COMPOBJ.DLL and OLE2.DLL on your machine are incompatible with each other.</term>
		/// </item>
		/// <item>
		/// <term>RPC_E_CHANGED_MODE</term>
		/// <term>
		/// A previous call to CoInitializeEx specified the concurrency model for this apartment as multithread apartment (MTA). This could
		/// also mean that a change from neutral threaded apartment to single threaded apartment occurred.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Applications that use the following functionality must call <c>OleInitialize</c> before calling any other function in the COM library:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Clipboard</term>
		/// </item>
		/// <item>
		/// <term>Drag and Drop</term>
		/// </item>
		/// <item>
		/// <term>Object linking and embedding (OLE)</term>
		/// </item>
		/// <item>
		/// <term>In-place activation</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>OleInitialize</c> calls CoInitializeEx internally to initialize the COM library on the current apartment. Because OLE
		/// operations are not thread-safe, <c>OleInitialize</c> specifies the concurrency model as single-thread apartment.
		/// </para>
		/// <para>
		/// Once the concurrency model for an apartment is set, it cannot be changed. A call to <c>OleInitialize</c> on an apartment that was
		/// previously initialized as multithreaded will fail and return RPC_E_CHANGED_MODE.
		/// </para>
		/// <para>
		/// You need to initialize the COM library on an apartment before you call any of the library functions except CoGetMalloc, to get a
		/// pointer to the standard allocator, and the memory allocation functions.
		/// </para>
		/// <para>
		/// Typically, the COM library is initialized on an apartment only once. Subsequent calls will succeed, as long as they do not
		/// attempt to change the concurrency model of the apartment, but will return S_FALSE. To close the COM library gracefully, each
		/// successful call to <c>OleInitialize</c>, including those that return S_FALSE, must be balanced by a corresponding call to OleUninitialize.
		/// </para>
		/// <para>
		/// Because there is no way to control the order in which in-process servers are loaded or unloaded, do not call <c>OleInitialize</c>
		/// or OleUninitialize from the DllMain function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oleinitialize
		// HRESULT OleInitialize( IN LPVOID pvReserved );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "9a13e7a0-f2e2-466b-98f5-38d5972fa391")]
		public static extern HRESULT OleInitialize([Optional] IntPtr pvReserved);

		/// <summary>
		/// Determines whether the data object pointer previously placed on the clipboard by the OleSetClipboard function is still on the clipboard.
		/// </summary>
		/// <param name="pDataObj">
		/// Pointer to the IDataObject interface on the data object containing clipboard data of interest, which the caller previously placed
		/// on the clipboard.
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The specified pointer is not on the clipboard.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <c>OleIsCurrentClipboard</c> only works for the data object used in the OleSetClipboard function. It cannot be called by the
		/// consumer of the data object to determine if the object that was on the clipboard at the previous OleGetClipboard call is still on
		/// the clipboard.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oleiscurrentclipboard HRESULT OleIsCurrentClipboard( IN
		// LPDATAOBJECT pDataObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "12844504-ef47-4a4d-b31b-f765e0f2ace6")]
		public static extern HRESULT OleIsCurrentClipboard(IDataObject pDataObj);

		/// <summary>Determines whether a compound document object is currently in the running state.</summary>
		/// <param name="pObject">Pointer to the IOleObject interface on the object of interest.</param>
		/// <returns>The return value is <c>TRUE</c> if the object is running; otherwise, it is <c>FALSE</c>.</returns>
		/// <remarks>
		/// You can use <c>OleIsRunning</c> and IRunnableObject::IsRunning interchangeably. <c>OleIsRunning</c> queries the object for a
		/// pointer to the IRunnableObject interface and calls its <c>IRunnableObject::IsRunning</c> method. If successful, the function
		/// returns the results of the call to <c>IRunnableObject::IsRunning</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oleisrunning BOOL OleIsRunning( IN LPOLEOBJECT pObject );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "9392666f-c269-4667-aeac-67c68bcc5f06")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool OleIsRunning(IOleObject pObject);

		/// <summary>Loads into memory an object nested within a specified storage object.</summary>
		/// <param name="pStg">Pointer to the IStorage interface on the storage object from which to load the specified object.</param>
		/// <param name="riid">
		/// Reference to the identifier of the interface that the caller wants to use to communicate with the object after it is loaded.
		/// </param>
		/// <param name="pClientSite">Pointer to the IOleClientSite interface on the client site object being loaded.</param>
		/// <param name="ppvObj">
		/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObj contains the
		/// requested interface pointer on the newly loaded object.
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
		/// </list>
		/// <para>Additionally, this function can return any of the error values returned by the IPersistStorage::Load method.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// OLE containers load objects into memory by calling this function. When calling the <c>OleLoad</c> function, the container
		/// application passes in a pointer to the open storage object in which the nested object is stored. Typically, the nested object to
		/// be loaded is a child storage object to the container's root storage object. Using the OLE information stored with the object, the
		/// object handler (usually, the default handler) attempts to load the object. On completion of the <c>OleLoad</c> function, the
		/// object is said to be in the loaded state with its object application not running.
		/// </para>
		/// <para>
		/// Some applications load all of the object's native data. Containers often defer loading the contained objects until required to do
		/// so. For example, until an object is scrolled into view and needs to be drawn, it does not need to be loaded.
		/// </para>
		/// <para>The <c>OleLoad</c> function performs the following steps:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>If necessary, performs an automatic conversion of the object (see the OleDoAutoConvert function).</term>
		/// </item>
		/// <item>
		/// <term>Gets the CLSID from the open storage object by calling the IStorage::Stat method.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Calls the CoCreateInstance function to create an instance of the handler. If the handler code is not available, the default
		/// handler is used (see the OleCreateDefaultHandler function).
		/// </term>
		/// </item>
		/// <item>
		/// <term>Calls the IOleObject::SetClientSite method with the pClientSite parameter to inform the object of its client site.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Calls the QueryInterface method for the IPersistStorage interface. If successful, the IPersistStorage::Load method is invoked for
		/// the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Queries and returns the interface identified by the riid parameter.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oleload HRESULT OleLoad( IN LPSTORAGE pStg, IN REFIID riid, IN
		// LPOLECLIENTSITE pClientSite, OUT LPVOID *ppvObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "f2d8bb2e-5bd1-4991-a80c-ed06bfd5c9f9")]
		public static extern HRESULT OleLoad(IStorage pStg, in Guid riid, IOleClientSite pClientSite, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

		/// <summary>Locks an already running object into its running state or unlocks it from its running state.</summary>
		/// <param name="pUnknown">Pointer to the IUnknown interface on the object, which the function uses to query for a pointer to IRunnableObject.</param>
		/// <param name="fLock"><c>TRUE</c> locks the object into its running state. <c>FALSE</c> unlocks the object from its running state.</param>
		/// <param name="fLastUnlockCloses">
		/// <c>TRUE</c> specifies that if the connection being released is the last external lock on the object, the object should close.
		/// <c>FALSE</c> specifies that the object should remain open until closed by the user or another process.
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory for the operation.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>OleLockRunning</c> function saves you the trouble of calling the IRunnableObject::LockRunning method. You can use
		/// <c>OleLockRunning</c> and <c>IRunnableObject::LockRunning</c> interchangeably. With the IUnknown pointer passed in with the
		/// pUnknown parameter, <c>OleLockRunning</c> queries for an IRunnableObject pointer. If successful, it calls
		/// <c>IRunnableObject::LockRunning</c> and returns the results of the call.
		/// </para>
		/// <para>For more information on using this function, see IRunnableObject::LockRunning.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olelockrunning HRESULT OleLockRunning( IN LPUNKNOWN pUnknown, IN
		// BOOL fLock, IN BOOL fLastUnlockCloses );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "84941a59-6880-4824-b4b9-cd1b52d2bffb")]
		public static extern HRESULT OleLockRunning([MarshalAs(UnmanagedType.IUnknown)] object pUnknown, [MarshalAs(UnmanagedType.Bool)] bool fLock, [MarshalAs(UnmanagedType.Bool)] bool fLastUnlockCloses);

		/// <summary>Creates a metafile in which the specified icon and label are drawn.</summary>
		/// <param name="hIcon">
		/// Handle to the icon that is to be drawn into the metafile. This parameter can be <c>NULL</c>. If hIcon is <c>NULL</c>, this
		/// function returns <c>NULL</c> without creating a metafile.
		/// </param>
		/// <param name="lpszLabel">
		/// The icon label. This parameter can be <c>NULL</c>. If lpszLabel is <c>NULL</c>, the resulting metafile will not include a label.
		/// </param>
		/// <param name="lpszSourceFile">
		/// The path and file name of the icon file. This string can be obtained through the user interface or from the registration
		/// database. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="iIconIndex">
		/// The location of the icon within the file named by lpszSourceFile, expressed as an offset in bytes from the beginning of file.
		/// </param>
		/// <returns>
		/// <para>
		/// A global handle to a METAFILEPICT structure containing the icon and label. The metafile uses the MM_ANISOTROPIC mapping mode.
		/// </para>
		/// <para>
		/// If an error occurs, the returned handle is <c>NULL</c>. In this case, the caller can call GetLastError to obtain further information.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>This function is called by OleGetIconOfFile and OleGetIconOfClass.</para>
		/// <para>
		/// If lpszSourceFile is not <c>NULL</c> and iIconIndex is not 0, the name of the source file passed in lpszSourceFile and the index
		/// passed by iIconIndex are added to the created metafile as a comment record.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olemetafilepictfromiconandlabel HGLOBAL
		// OleMetafilePictFromIconAndLabel( IN HICON hIcon, LPOLESTR lpszLabel, LPOLESTR lpszSourceFile, IN UINT iIconIndex );
		[DllImport(Lib.Ole32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "627a79eb-46dd-4df7-a0d6-cab37b73387a")]
		public static extern SafeHGlobalHandle OleMetafilePictFromIconAndLabel(HICON hIcon, [MarshalAs(UnmanagedType.LPWStr), Optional] string lpszLabel, [MarshalAs(UnmanagedType.LPWStr), Optional] string lpszSourceFile, [In] uint iIconIndex);

		/// <summary>Increments or decrements an external reference that keeps an object in the running state.</summary>
		/// <param name="pUnknown">Pointer to the IUnknown interface on the object that is to be locked or unlocked.</param>
		/// <param name="fVisible">
		/// Whether the object is visible. If <c>TRUE</c>, OLE increments the reference count to hold the object visible and alive regardless
		/// of external or internal IUnknown::AddRef and IUnknown::Release operations, registrations, or revocation. If <c>FALSE</c>, OLE
		/// releases its hold (decrements the reference count) and the object can be closed.
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory for the operation.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The <c>OleNoteObjectVisible</c> function calls the CoLockObjectExternal function. It is provided as a separate function to
		/// reinforce the need to lock an object when it becomes visible to the user and to release the object when it becomes invisible.
		/// This creates a strong lock on behalf of the user to ensure that the object cannot be closed by its container while it is visible.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olenoteobjectvisible HRESULT OleNoteObjectVisible( IN LPUNKNOWN
		// pUnknown, IN BOOL fVisible );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "f140f068-3115-4389-b67b-6d41d12f7525")]
		public static extern HRESULT OleNoteObjectVisible([MarshalAs(UnmanagedType.IUnknown)] object pUnknown, [MarshalAs(UnmanagedType.Bool)] bool fVisible);

		/// <summary>
		/// Checks whether a data object has one of the formats that would allow it to become an embedded object through a call to either the
		/// OleCreateFromData or OleCreateStaticFromData function.
		/// </summary>
		/// <param name="pSrcDataObject">Pointer to the IDataObject interface on the data transfer object to be queried.</param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>No formats are present that support either embedded- or static-object creation.</term>
		/// </item>
		/// <item>
		/// <term>OLE_S_STATIC</term>
		/// <term>Formats that support static-object creation are present.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When an application retrieves a data transfer object through a call to the OleGetClipboard function, the application should call
		/// <c>OleQueryCreateFromData</c> as part of the process of deciding to enable or disable the <c>Edit/Paste</c> or <c>Edit/Paste
		/// Special...</c> commands. It tests for the presence of the following formats in the data object:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>CF_EMBEDDEDOBJECT</term>
		/// </item>
		/// <item>
		/// <term>CF_EMBEDSOURCE</term>
		/// </item>
		/// <item>
		/// <term>cfFileName</term>
		/// </item>
		/// <item>
		/// <term>CF_METAFILEPICT</term>
		/// </item>
		/// <item>
		/// <term>CF_DIB</term>
		/// </item>
		/// <item>
		/// <term>CF_BITMAP</term>
		/// </item>
		/// <item>
		/// <term>CF_ENHMETAFILE</term>
		/// </item>
		/// </list>
		/// <para>
		/// Determining that the data object has one of these formats does not absolutely guarantee that the object creation will succeed,
		/// but is intended to help the process.
		/// </para>
		/// <para>
		/// If <c>OleQueryCreateFromData</c> finds one of the CF_METAFILEPICT, CF_BITMAP, CF_DIB, or CF_ENHMETAFILE formats and none of the
		/// other formats, it returns OLE_S_STATIC, indicating that you should call the OleCreateStaticFromData function to create the
		/// embedded object.
		/// </para>
		/// <para>
		/// If <c>OleQueryCreateFromData</c> finds one of the other formats (CF_EMBEDDEDOBJECT, CF_EMBEDSOURCE, or cfFileName), even in
		/// combination with the static formats, it returns S_OK, indicating that you should call the OleCreateFromData function to create
		/// the embedded object.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olequerycreatefromdata HRESULT OleQueryCreateFromData( IN
		// LPDATAOBJECT pSrcDataObject );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "58fffb8c-9726-4801-84ce-6fb670b865c8")]
		public static extern HRESULT OleQueryCreateFromData([In] IDataObject pSrcDataObject);

		/// <summary>
		/// Determines whether an OLE linked object (rather than an OLE embedded object) can be created from a clipboard data object.
		/// </summary>
		/// <param name="pSrcDataObject">
		/// Pointer to the IDataObject interface on the clipboard data object from which the object is to be created.
		/// </param>
		/// <returns>Returns S_OK if the OleCreateLinkFromData function can be used to create the linked object; otherwise S_FALSE.</returns>
		/// <remarks>
		/// The <c>OleQueryLinkFromData</c> function is similar to the OleQueryCreateFromData function, but determines whether an OLE linked
		/// object (rather than an OLE embedded object) can be created from the clipboard data object. If the return value is S_OK, the
		/// application can then attempt to create the object with a call to OleCreateLinkFromData. A successful return from
		/// <c>OleQueryLinkFromData</c> does not, however, guarantee the successful creation of a link.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olequerylinkfromdata HRESULT OleQueryLinkFromData( IN LPDATAOBJECT
		// pSrcDataObject );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "9ebdcd7f-06c1-4464-a66c-4d134a6b5d36")]
		public static extern HRESULT OleQueryLinkFromData(IDataObject pSrcDataObject);

		/// <summary>
		/// Creates an enumeration object that can be used to enumerate data formats that an OLE object server has registered in the system
		/// registry. An object application or object handler calls this function when it must enumerate those formats. Developers of custom
		/// DLL object applications use this function to emulate the behavior of the default object handler.
		/// </summary>
		/// <param name="clsid">CLSID of the class whose formats are being requested.</param>
		/// <param name="dwDirection">
		/// Indicates whether to enumerate formats that can be passed to IDataObject::GetData or formats that can be passed to
		/// IDataObject::SetData. Possible values are taken from the enumeration DATADIR.
		/// </param>
		/// <param name="ppenum">Address of IEnumFORMATETC pointer variable that receives the interface pointer to the enumeration object.</param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory for the operation.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_CLASSNOTREG</term>
		/// <term>There is no CLSID registered for the class object.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_READREGDB</term>
		/// <term>There was an error reading the registry.</term>
		/// </item>
		/// <item>
		/// <term>OLE_E_REGDB_KEY</term>
		/// <term>The DataFormats/GetSet key is missing from the registry.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Object applications can ask OLE to create an enumeration object for FORMATETC structures to enumerate supported data formats in
		/// one of two ways. One way is to call <c>OleRegEnumFormatEtc</c>. The other is to return OLE_S_USEREG in response to calls by the
		/// default object handler to IDataObject::EnumFormatEtc. OLE_S_USEREG instructs the default handler to call
		/// <c>OleRegEnumFormatEtc</c>. Because DLL object applications cannot return OLE_S_USEREG, they must call <c>OleRegEnumFormatEtc</c>
		/// rather than delegating the job to the object handler. With the supplied IEnumFORMATETC pointer to the object, you can call the
		/// standard enumeration object methods to do the enumeration.
		/// </para>
		/// <para>
		/// The <c>OleRegEnumFormatEtc</c> function and its sibling functions, OleRegGetUserType, OleRegGetMiscStatus, and OleRegEnumVerbs,
		/// provide a way for developers of custom DLL object applications to emulate the behavior of OLE's default object handler in getting
		/// information about objects from the registry. By using these functions, you avoid the considerable work of writing your own, and
		/// the pitfalls inherent in working directly in the registry. In addition, you get future enhancements and optimizations of these
		/// functions without having to code them yourself.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oleregenumformatetc HRESULT OleRegEnumFormatEtc( IN REFCLSID
		// clsid, IN DWORD dwDirection, LPENUMFORMATETC *ppenum );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "6caebc68-a136-40f2-92d8-7f8003c18e5c")]
		public static extern HRESULT OleRegEnumFormatEtc(in Guid clsid, DATADIR dwDirection, out IEnumFORMATETC ppenum);

		/// <summary>
		/// Supplies an enumeration of the registered verbs for the specified class. Developers of custom DLL object applications use this
		/// function to emulate the behavior of the default object handler.
		/// </summary>
		/// <param name="clsid">Class identifier whose verbs are being requested.</param>
		/// <param name="ppenum">Address of IEnumOLEVERB* pointer variable that receives the interface pointer to the new enumeration object.</param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLEOBJ_E_NOVERBS</term>
		/// <term>No verbs are registered for the class.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_CLASSNOTREG</term>
		/// <term>No CLSID is registered for the class object.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_READREGDB</term>
		/// <term>An error occurred reading the registry.</term>
		/// </item>
		/// <item>
		/// <term>OLE_E_REGDB_KEY</term>
		/// <term>The DataFormats/GetSet key is missing from the registry.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Object applications can ask OLE to create an enumeration object for OLEVERB structures to enumerate supported verbs in one of two
		/// ways. One way is to call <c>OleRegEnumVerbs</c>. The other way is to return OLE_S_USEREG in response to calls by the default
		/// object handler to IOleObject::EnumVerbs. OLE_S_USEREG instructs the default handler to call <c>OleRegEnumVerbs</c>. Because DLL
		/// object applications cannot return OLE_S_USEREG, they must call <c>OleRegEnumVerbs</c> rather than delegating the job to the
		/// object handler. With the supplied IEnumOLEVERB pointer to the object, you can call the standard enumeration object methods to do
		/// the enumeration.
		/// </para>
		/// <para>
		/// The <c>OleRegEnumVerbs</c> function and its sibling functions, OleRegGetUserType, OleRegGetMiscStatus, and OleRegEnumFormatEtc,
		/// provide a way for developers of custom DLL object applications to emulate the behavior of OLE's default object handler in getting
		/// information about objects from the registry. By using these functions, you avoid the considerable work of writing your own, and
		/// the pitfalls inherent in working directly in the registry. In addition, you get future enhancements and optimizations of these
		/// functions without having to code them yourself.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oleregenumverbs HRESULT OleRegEnumVerbs( IN REFCLSID clsid,
		// LPENUMOLEVERB *ppenum );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "25cd0876-90b6-4fa3-b180-ffa0c3b51497")]
		public static extern HRESULT OleRegEnumVerbs(in Guid clsid, out IEnumOLEVERB ppenum);

		/// <summary>
		/// <para>Returns miscellaneous information about the presentation and behaviors supported by the specified CLSID from the registry.</para>
		/// <para>This function is used by developers of custom DLL object applications to emulate the behavior of the OLE default handler.</para>
		/// </summary>
		/// <param name="clsid">The CLSID of the class for which status information is to be requested.</param>
		/// <param name="dwAspect">
		/// The presentation aspect of the class for which information is requested. Possible values are taken from the DVASPECT enumeration.
		/// </param>
		/// <param name="pdwStatus">A pointer to the variable that receives the status information.</param>
		/// <returns>
		/// <para>This function can return the standard return value E_OUTOFMEMORY, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The status information was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_CLASSNOTREG</term>
		/// <term>No CLSID is registered for the class object.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_READREGDB</term>
		/// <term>There was an error reading from the registry.</term>
		/// </item>
		/// <item>
		/// <term>OLE_E_REGDB_KEY</term>
		/// <term>The GetMiscStatus key is missing from the registry.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Object applications can ask OLE to get miscellaneous status information in one of two ways. One way is to call
		/// <c>OleRegGetMiscStatus</c>. The other is to return OLE_S_USEREG in response to calls by the default object handler to
		/// IOleObject::GetMiscStatus. OLE_S_USEREG instructs the default handler to call <c>OleRegGetMiscStatus</c>. Because DLL object
		/// applications cannot return OLE_S_USEREG, they must call <c>OleRegGetMiscStatus</c> rather than delegating the job to the object handler.
		/// </para>
		/// <para>
		/// <c>OleRegGetMiscStatus</c> and its sibling functions, OleRegGetUserType, OleRegEnumFormatEtc, and OleRegEnumVerbs, provide a way
		/// for developers of custom DLL object applications to emulate the behavior of OLE's default object handler in getting information
		/// about objects from the registry. By using these functions, you avoid the considerable work of writing your own, and the pitfalls
		/// inherent in working directly in the registry. In addition, you get future enhancements and optimizations of these functions
		/// without having to code them yourself.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olereggetmiscstatus HRESULT OleRegGetMiscStatus( IN REFCLSID
		// clsid, IN DWORD dwAspect, OUT DWORD *pdwStatus );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "3166955f-4f7a-4904-a7fb-ebdfb8e56baf")]
		public static extern HRESULT OleRegGetMiscStatus(in Guid clsid, DVASPECT dwAspect, out uint pdwStatus);

		/// <summary>
		/// <para>Gets the user type of the specified class from the registry.</para>
		/// <para>Developers of custom DLL object applications use this function to emulate the behavior of the OLE default handler.</para>
		/// </summary>
		/// <param name="clsid">The CLSID of the class for which the user type is to be requested.</param>
		/// <param name="dwFormOfType">The form of the user-presentable string. Possible values are taken from the enumeration USERCLASSTYPE.</param>
		/// <param name="pszUserType">A pointer to a string that receives the user type.</param>
		/// <returns>
		/// <para>This function can return the standard return value E_OUTOFMEMORY, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The user type was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_CLASSNOTREG</term>
		/// <term>No CLSID is registered for the class object.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_READREGDB</term>
		/// <term>There was an error reading from the registry.</term>
		/// </item>
		/// <item>
		/// <term>OLE_E_REGDB_KEY</term>
		/// <term>The ProgID = MainUserTypeName and CLSID = MainUserTypeName keys are missing from the registry.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Object applications can ask OLE to get the user type name of a specified class in one of two ways. One way is to call
		/// <c>OleRegGetUserType</c>. The other is to return OLE_S_USEREG in response to calls by the default object handler to
		/// IOleObject::GetUserType. OLE_S_USEREG instructs the default handler to call <c>OleRegGetUserType</c>. Because DLL object
		/// applications cannot return OLE_S_USEREG, they must call <c>OleRegGetUserType</c>, rather than delegating the job to the object handler.
		/// </para>
		/// <para>
		/// The <c>OleRegGetUserType</c> function and its sibling functions, OleRegGetMiscStatus, OleRegEnumFormatEtc, and OleRegEnumVerbs,
		/// provide a way for developers of custom DLL object applications to emulate the behavior of OLE's default object handler in getting
		/// information about objects from the registry. By using these functions, you avoid the considerable work of writing your own, and
		/// the pitfalls inherent in working directly in the registry. In addition, you get future enhancements and optimizations of these
		/// functions without having to code them yourself.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olereggetusertype HRESULT OleRegGetUserType( IN REFCLSID clsid, IN
		// DWORD dwFormOfType, LPOLESTR *pszUserType );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "492a4084-494e-4d78-8f3a-853ec486a2d6")]
		public static extern HRESULT OleRegGetUserType(in Guid clsid, USERCLASSTYPE dwFormOfType, [MarshalAs(UnmanagedType.LPWStr)] out string pszUserType);

		/// <summary>Puts an OLE compound document object into the running state.</summary>
		/// <param name="pUnknown">
		/// Pointer to the IUnknown interface on the object, with which it will query for a pointer to the IRunnableObject interface, and
		/// then call its Run method.
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLE_E_CLASSDIFF</term>
		/// <term>The source of an OLE link has been converted to a different class.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>OleRun</c> function puts an object in the running state. The implementation of <c>OleRun</c> was changed in OLE 2.01 to
		/// coincide with the publication of the IRunnableObject interface. You can use <c>OleRun</c> and IRunnableObject::Run
		/// interchangeably. <c>OleRun</c> queries the object for a pointer to <c>IRunnableObject</c>. If successful, the function returns
		/// the results of calling the <c>IRunnableObject::Run</c> method.
		/// </para>
		/// <para>For more information on using this function, see IRunnableObject::Run.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olerun HRESULT OleRun( IN LPUNKNOWN pUnknown );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "9035f996-b163-4855-aa9d-184b77072ead")]
		public static extern HRESULT OleRun([In, MarshalAs(UnmanagedType.IUnknown)] object pUnknown);

		/// <summary>Saves an object opened in transacted mode into the specified storage object.</summary>
		/// <param name="pPS">Pointer to the IPersistStorage interface on the object to be saved.</param>
		/// <param name="pStg">
		/// Pointer to the IStorage interface on the destination storage object to which the object indicated in pPS is to be saved.
		/// </param>
		/// <param name="fSameAsLoad">
		/// <c>TRUE</c> indicates that pStg is the same storage object from which the object was loaded or created; <c>FALSE</c> indicates
		/// that pStg was loaded or created from a different storage object.
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STGMEDIUM_E_FULL</term>
		/// <term>
		/// The object could not be saved due to lack of disk space. This function can also return any of the error values returned by the
		/// IPersistStorage::Save method.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>OleSave</c> helper function handles the common situation in which an object is open in transacted mode and is then to be
		/// saved into the specified storage object which uses the OLE-provided compound file implementation. Transacted mode means that
		/// changes to the object are buffered until either of the IStorage::Commit or IStorage::Revert is called. Callers can handle other
		/// situations by calling the IPersistStorage and IStorage interfaces directly.
		/// </para>
		/// <para><c>OleSave</c> does the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Calls the IPersist::GetClassID method to get the CLSID of the object.</term>
		/// </item>
		/// <item>
		/// <term>Writes the CLSID to the storage object using the WriteClassStg function.</term>
		/// </item>
		/// <item>
		/// <term>Calls the IPersistStorage::Save method to save the object.</term>
		/// </item>
		/// <item>
		/// <term>If there were no errors on the save; calls the IStorage::Commit method to commit the changes.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> Static objects are saved into a stream called CONTENTS. Static metafile objects get saved in "placeable metafile
		/// format" and static DIB data gets saved in "DIB file format." These formats are defined to be the OLE standards for metafile and
		/// DIB. All data transferred using an IStream interface or a file (that is, via IDataObject::GetDataHere) must be in these formats.
		/// Also, all objects whose default file format is a metafile or DIB must write their data into a CONTENTS stream using these
		/// standard formats.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olesave HRESULT OleSave( LPPERSISTSTORAGE pPS, LPSTORAGE pStg,
		// BOOL fSameAsLoad );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "b8d8e1af-05a3-42f5-8672-910a2606e613")]
		public static extern HRESULT OleSave(IPersistStorage pPS, IStorage pStg, [MarshalAs(UnmanagedType.Bool)] bool fSameAsLoad);

		/// <summary>Saves an object with the IPersistStream interface on it to the specified stream.</summary>
		/// <param name="pPStm"/>
		/// <param name="pStm"/>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STGMEDIUM_E_FULL</term>
		/// <term>The object could not be saved due to lack of disk space.</term>
		/// </item>
		/// <item>
		/// <term>OLE_E_BLANK</term>
		/// <term>The pPStm parameter is NULL.</term>
		/// </item>
		/// </list>
		/// <para>
		/// This function can also return any of the error values returned by the WriteClassStm function or the IPersistStream::Save method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function simplifies saving an object that implements the IPersistStream interface to a stream. In this stream, the object's
		/// CLSID precedes its data. When the stream is retrieved, the CLSID permits the proper code to be associated with the data. The
		/// <c>OleSaveToStream</c> function does the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Calls the IPersist::GetClassID method to get the object's CLSID.</term>
		/// </item>
		/// <item>
		/// <term>Writes the CLSID to the stream with the WriteClassStm function.</term>
		/// </item>
		/// <item>
		/// <term>Calls the IPersistStream::Save method with fClearDirty set to <c>TRUE</c>, which clears the dirty bit in the object.</term>
		/// </item>
		/// </list>
		/// <para>The companion helper, OleLoadFromStream, loads objects saved in this way.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olesavetostream HRESULT OleSaveToStream( IN LPPERSISTSTREAM pPStm,
		// IN LPSTREAM pStm );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "0085c6a8-1a94-4379-9937-c8d792d130da")]
		public static extern HRESULT OleSaveToStream([In] IPersistStream pPStm, [In] IStream pStm);

		/// <summary>Specifies a CLSID for automatic conversion to a different class when an object of that class is loaded.</summary>
		/// <param name="clsidOld">The CLSID of the object class to be converted.</param>
		/// <param name="clsidNew">
		/// The CLSID of the object class that should replace clsidOld. This new CLSID replaces any existing auto-conversion information in
		/// the registry for clsidOld. If this value is CLSID_NULL, any existing auto-conversion information for clsidOld is removed from the registry.
		/// </param>
		/// <returns>
		/// <para>
		/// This function can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The object was tagged successfully.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_CLASSNOTREG</term>
		/// <term>The CLSID is not properly registered in the registry.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_READREGDB</term>
		/// <term>Error reading from the registry.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_WRITEREGDB</term>
		/// <term>Error writing to the registry.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_KEYMISSING</term>
		/// <term>Cannot read a key from the registry.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>OleSetAutoConvert</c> goes to the system registry, finds the <c>AutoConvertTo</c> subkey under the CLSID specified by
		/// clsidOld, and sets it to clsidNew. This function does not validate whether an appropriate registry entry for clsidNew currently
		/// exists. These entries appear in the registry as subkeys of the CLSID key.
		/// </para>
		/// <para>
		/// Object conversion means that the object's data is permanently associated with a new CLSID. Automatic conversion is typically
		/// specified in the setup program of a new version of an object application, so objects created by its older versions can be
		/// automatically updated to the new version.
		/// </para>
		/// <para>
		/// For example, it may be necessary to convert spreadsheets that were created with earlier versions of a spreadsheet application to
		/// the new version. The spreadsheet objects from earlier versions have different CLSIDs than the new version. For each earlier
		/// version that you want automatically updated, you would call <c>OleSetAutoConvert</c> in the setup program, specifying the CLSID
		/// of the old version, and that of the new one. Then, whenever a user loads an object from a previous version, it would be
		/// automatically updated. To support automatic conversion of objects, a server that supports conversion must be prepared to manually
		/// convert objects that have the format of an earlier version of the server. Automatic conversion relies internally on this
		/// manual-conversion support.
		/// </para>
		/// <para>
		/// Before setting the desired <c>AutoConvertTo</c> value, setup programs should also call <c>OleSetAutoConvert</c> to remove any
		/// existing conversion for the new class, by specifying the new class as the clsidOld parameter, and setting the clsidNew parameter
		/// to CLSID_NULL.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olesetautoconvert HRESULT OleSetAutoConvert( IN REFCLSID clsidOld,
		// IN REFCLSID clsidNew );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "39abf385-962a-4b20-b319-501c8130e050")]
		public static extern HRESULT OleSetAutoConvert(in Guid clsidOld, in Guid clsidNew);

		/// <summary>
		/// Places a pointer to a specific data object onto the clipboard. This makes the data object accessible to the OleGetClipboard function.
		/// </summary>
		/// <param name="pDataObj">
		/// Pointer to the IDataObject interface on the data object from which the data to be placed on the clipboard can be obtained. This
		/// parameter can be <c>NULL</c>; in which case the clipboard is emptied.
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>CLIPBRD_E_CANT_OPEN</term>
		/// <term>The OpenClipboard function used within OleSetClipboard failed.</term>
		/// </item>
		/// <item>
		/// <term>CLIPBRD_E_CANT_EMPTY</term>
		/// <term>The EmptyClipboard function used within OleSetClipboard failed.</term>
		/// </item>
		/// <item>
		/// <term>CLIPBRD_E_CANT_CLOSE</term>
		/// <term>The CloseClipboard function used within OleSetClipboard failed.</term>
		/// </item>
		/// <item>
		/// <term>CLIPBRD_E_CANT_SET</term>
		/// <term>The SetClipboardData function used within OleSetClipboard failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>If you are writing an application that can act as the source of a clipboard operation, you must do the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Create a data object (on which is the IDataObject interface) for the data being copied or cut to the clipboard. This object
		/// should be the same object used in OLE drag-and-drop operations.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Call <c>OleSetClipboard</c> to place the IDataObject pointer onto the clipboard, so it is accessible to the OleGetClipboard
		/// function. <c>OleSetClipboard</c> also calls the IUnknown::AddRef method on your data object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If you wish, release the data object after you have placed it on the clipboard to free the IUnknown::AddRef counter in your application.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the user is cutting data (deleting it from the document and putting it on to the clipboard), remove the data from the document.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// All formats are offered on the clipboard using delayed rendering (the clipboard contains only a pointer to the data object unless
		/// a call to OleFlushClipboard renders the data onto the clipboard). The formats necessary for OLE 1 compatibility are synthesized
		/// from the OLE 2 formats that are present and are also put on the clipboard.
		/// </para>
		/// <para>
		/// The <c>OleSetClipboard</c> function assigns ownership of the clipboard to an internal OLE window handle. The reference count of
		/// the data object is increased by 1, to enable delayed rendering. The reference count is decreased by a call to the
		/// OleFlushClipboard function or by a subsequent call to <c>OleSetClipboard</c> specifying <c>NULL</c> as the parameter value (which
		/// clears the clipboard).
		/// </para>
		/// <para>
		/// When an application opens the clipboard (either directly or indirectly by calling the OpenClipboard function), the clipboard
		/// cannot be used by any other application until it is closed. If the clipboard is currently open by another application,
		/// <c>OleSetClipboard</c> fails. The internal OLE window handle satisfies WM_RENDERFORMAT messages by delegating them to the
		/// IDataObject implementation on the data object that is on the clipboard.
		/// </para>
		/// <para>
		/// Specifying <c>NULL</c> as the parameter value for <c>OleSetClipboard</c> empties the current clipboard. If the contents of the
		/// clipboard are the result of a previous <c>OleSetClipboard</c> call and the clipboard has been released, the IDataObject pointer
		/// that was passed to the previous call is released. The clipboard owner should use this as a signal that the data it previously
		/// offered is no longer on the clipboard.
		/// </para>
		/// <para>
		/// If you need to leave the data on the clipboard after your application is closed, you should call OleFlushClipboard rather than
		/// calling <c>OleSetClipboard</c> with a <c>NULL</c> parameter value.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olesetclipboard HRESULT OleSetClipboard( IN LPDATAOBJECT pDataObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "741def10-d2b5-4395-8049-1eba2e29b0e8")]
		public static extern HRESULT OleSetClipboard([In] IDataObject pDataObj);

		/// <summary>
		/// Notifies an object that it is embedded in an OLE container, which ensures that reference counting is done correctly for
		/// containers that support links to embedded objects.
		/// </summary>
		/// <param name="pUnknown">Pointer to the IUnknown interface of the object.</param>
		/// <param name="fContained"><c>TRUE</c> if the object is an embedded object; <c>FALSE</c> otherwise.</param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory for the operation.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The <c>OleSetContainedObject</c> function notifies an object that it is embedded in an OLE container. The implementation of
		/// <c>OleSetContainedObject</c> was changed in OLE 2.01 to coincide with the publication of the IRunnableObject interface. You can
		/// use <c>OleSetContainedObject</c> and the IRunnableObject::SetContainedObject method interchangeably. The
		/// <c>OleSetContainedObject</c> function queries the object for a pointer to the <c>IRunnableObject</c> interface. If successful,
		/// the function returns the results of calling <c>IRunnableObject::SetContainedObject</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olesetcontainedobject HRESULT OleSetContainedObject( IN LPUNKNOWN
		// pUnknown, IN BOOL fContained );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "154aa6f0-3c02-4139-8c8e-c2112b015fe0")]
		public static extern HRESULT OleSetContainedObject([In, MarshalAs(UnmanagedType.IUnknown)] object pUnknown, [MarshalAs(UnmanagedType.Bool)] bool fContained);

		/// <summary>Installs or removes OLE dispatching code from the container's frame window.</summary>
		/// <param name="holemenu">
		/// Handle to the composite menu descriptor returned by the OleCreateMenuDescriptor function. If <c>NULL</c>, the dispatching code is unhooked.
		/// </param>
		/// <param name="hwndFrame">Handle to the container's frame window where the in-place composite menu is to be installed.</param>
		/// <param name="hwndActiveObject">
		/// Handle to the object's in-place activation window. OLE dispatches menu messages and commands to this window.
		/// </param>
		/// <param name="lpFrame">Pointer to the IOleInPlaceFrame interface on the container's frame window.</param>
		/// <param name="lpActiveObj">Pointer to the IOleInPlaceActiveObject interface on the active in-place object.</param>
		/// <returns>This function returns S_OK on success.</returns>
		/// <remarks>
		/// <para>
		/// The container should call <c>OleSetMenuDescriptor</c> to install the dispatching code on hwndFrame when the object calls the
		/// IOleInPlaceFrame::SetMenu method, or to remove the dispatching code by passing <c>NULL</c> as the value for holemenu to <c>OleSetMenuDescriptor</c>.
		/// </para>
		/// <para>
		/// If both the lpFrame and lpActiveObj parameters are non- <c>NULL</c>, OLE installs the context-sensitive help F1 message filter
		/// for the application. Otherwise, the application must supply its own message filter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olesetmenudescriptor HRESULT OleSetMenuDescriptor( IN HOLEMENU
		// holemenu, IN HWND hwndFrame, IN HWND hwndActiveObject, IN LPOLEINPLACEFRAME lpFrame, IN LPOLEINPLACEACTIVEOBJECT lpActiveObj );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "c80fe36d-5093-4814-83a9-0c11c5a7cf5f")]
		public static extern HRESULT OleSetMenuDescriptor([In] HOLEMENU holemenu, [In] HWND hwndFrame, [In] HWND hwndActiveObject, [In] IOleInPlaceFrame lpFrame, [In] IOleInPlaceActiveObject lpActiveObj);

		/// <summary>
		/// Called by the object application, allows an object's container to translate accelerators according to the container's accelerator table.
		/// </summary>
		/// <param name="lpFrame">Pointer to the IOleInPlaceFrame interface to which the keystroke might be sent.</param>
		/// <param name="lpFrameInfo">Pointer to an OLEINPLACEFRAMEINFO structure containing the accelerator table obtained from the container.</param>
		/// <param name="lpmsg">Pointer to an MSG structure containing the keystroke.</param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The object should continue processing this message.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Object servers call <c>OleTranslateAccelerator</c> to allow the object's container to translate accelerator keystrokes according
		/// to the container's accelerator table, pointed to by lpFrameInfo. While a contained object is the active object, the object's
		/// server always has first chance at translating any messages received. If this is not desired, the server calls
		/// <c>OleTranslateAccelerator</c> to give the object's container a chance. If the keyboard input matches an accelerator found in the
		/// container-provided accelerator table, <c>OleTranslateAccelerator</c> passes the message and its command identifier on to the
		/// container through the IOleInPlaceFrame::TranslateAccelerator method. This method returns S_OK if the keystroke is consumed;
		/// otherwise it returns S_FALSE.
		/// </para>
		/// <para>
		/// Accelerator tables for containers should be defined so they will work properly with object applications that do their own
		/// accelerator keystroke translations. These tables should take the form:
		/// </para>
		/// <para>
		/// This is the most common way to describe keyboard accelerators. Failure to do so can result in keystrokes being lost or sent to
		/// the wrong object during an in-place session.
		/// </para>
		/// <para>Objects can call the IsAccelerator function to see whether the accelerator keystroke belongs to the object or the container.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-oletranslateaccelerator HRESULT OleTranslateAccelerator( IN
		// LPOLEINPLACEFRAME lpFrame, IN LPOLEINPLACEFRAMEINFO lpFrameInfo, IN LPMSG lpmsg );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "c590efef-7f03-4ae6-a35f-eff2fc4da3d9")]
		public static extern HRESULT OleTranslateAccelerator([In] IOleInPlaceFrame lpFrame, in OLEINPLACEFRAMEINFO lpFrameInfo, in MSG lpmsg);

		/// <summary>
		/// Closes the COM library on the apartment, releases any class factories, other COM objects, or servers held by the apartment,
		/// disables RPC on the apartment, and frees any resources the apartment maintains.
		/// </summary>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Ole2.h", MSDNShortId = "ms691326")]
		public static extern void OleUninitialize();

		/// <summary>
		/// The <c>ReadFmtUserTypeStg</c> function returns the clipboard format and user type previously saved with the WriteFmtUserTypeStg function.
		/// </summary>
		/// <param name="pstg">Pointer to the IStorage interface on the storage object from which the information is to be read.</param>
		/// <param name="pcf">
		/// Pointer to where the clipboard format is to be written on return. It can be <c>NULL</c>, indicating the format is of no interest
		/// to the caller.
		/// </param>
		/// <param name="lplpszUserType">
		/// Address of <c>LPWSTR</c> pointer variable that receives a pointer to the null-terminated Unicode user-type string. The caller can
		/// specify <c>NULL</c> for this parameter, which indicates that the user type is of no interest. This function allocates memory for
		/// the string. The caller is responsible for freeing the memory with CoTaskMemFree.
		/// </param>
		/// <returns>
		/// <para>This function supports the standard return values E_FAIL, E_INVALIDARG, and E_OUTOFMEMORY, in addition to the following:</para>
		/// <para>This function also returns any of the error values returned by the ISequentialStream::Read method.</para>
		/// </returns>
		/// <remarks>
		/// <c>ReadFmtUserTypeStg</c> returns the clipboard format and the user type string from the specified storage object. The
		/// WriteClassStg function must have been called before calling the <c>ReadFmtUserTypeStg</c> function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-readfmtusertypestg HRESULT ReadFmtUserTypeStg( IN LPSTORAGE pstg,
		// OUT CLIPFORMAT *pcf, LPOLESTR *lplpszUserType );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "6f26550d-c094-4150-b8ef-2da1d052c1ff")]
		public static extern HRESULT ReadFmtUserTypeStg([In] IStorage pstg, out CLIPFORMAT pcf, [MarshalAs(UnmanagedType.LPWStr)] out string lplpszUserType);

		/// <summary>
		/// Registers the specified window as one that can be the target of an OLE drag-and-drop operation and specifies the IDropTarget
		/// instance to use for drop operations.
		/// </summary>
		/// <param name="hwnd">Handle to a window that can be a target for an OLE drag-and-drop operation.</param>
		/// <param name="pDropTarget">
		/// Pointer to the IDropTarget interface on the object that is to be the target of a drag-and-drop operation in a specified window.
		/// This interface is used to communicate OLE drag-and-drop information for that window.
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>DRAGDROP_E_INVALIDHWND</term>
		/// <term>Invalid handle returned in the hwnd parameter.</term>
		/// </item>
		/// <item>
		/// <term>DRAGDROP_E_ALREADYREGISTERED</term>
		/// <term>The specified window has already been registered as a drop target.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory for the operation.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> If you use CoInitialize or CoInitializeEx instead of OleInitialize to initialize COM, <c>RegisterDragDrop</c> will
		/// always return an E_OUTOFMEMORY error.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If your application can accept dropped objects during OLE drag-and-drop operations, you must call the <c>RegisterDragDrop</c>
		/// function. Do this whenever one of your application windows is available as a potential drop target, i.e., when the window appears
		/// unobscured on the screen.
		/// </para>
		/// <para>
		/// The application thread that calls the <c>RegisterDragDrop</c> function must be pumping messages, presumably by calling the
		/// GetMessage function with a <c>NULL</c> hWnd parameter, because OLE creates windows on the thread that need messages processed. If
		/// this requirement is not met, any application that drags an object over the window that is registered as a drop target will hang
		/// until the target application closes.
		/// </para>
		/// <para>
		/// The <c>RegisterDragDrop</c> function only registers one window at a time, so you must call it for each application window capable
		/// of accepting dropped objects.
		/// </para>
		/// <para>
		/// As the mouse passes over unobscured portions of the target window during an OLE drag-and-drop operation, the DoDragDrop function
		/// calls the specified IDropTarget::DragOver method for the current window. When a drop operation actually occurs in a given window,
		/// the <c>DoDragDrop</c> function calls IDropTarget::Drop.
		/// </para>
		/// <para>The <c>RegisterDragDrop</c> function also calls the IUnknown::AddRef method on the IDropTarget pointer.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-registerdragdrop HRESULT RegisterDragDrop( IN HWND hwnd, IN
		// LPDROPTARGET pDropTarget );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "00726271-4436-41f5-b7cc-666cd77216bc")]
		public static extern HRESULT RegisterDragDrop([In] HWND hwnd, [In] IDropTarget pDropTarget);

		/// <summary>Frees the specified storage medium.</summary>
		/// <param name="pMedium">Pointer to the storage medium that is to be freed.</param>
		[DllImport(Lib.Ole32, ExactSpelling = true)]
		[PInvokeData("Ole2.h", MSDNShortId = "ms693491")]
		public static extern void ReleaseStgMedium(in STGMEDIUM pMedium);

		/// <summary>Revokes the registration of the specified application window as a potential target for OLE drag-and-drop operations.</summary>
		/// <param name="hwnd">Handle to a window previously registered as a target for an OLE drag-and-drop operation.</param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>DRAGDROP_E_NOTREGISTERED</term>
		/// <term>An attempt was made to revoke a drop target that has not been registered.</term>
		/// </item>
		/// <item>
		/// <term>DRAGDROP_E_INVALIDHWND</term>
		/// <term>Invalid handle returned in the hwnd parameter.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory for the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When your application window is no longer available as a potential target for an OLE drag-and-drop operation, you must call <c>RevokeDragDrop</c>.
		/// </para>
		/// <para>This function calls the IUnknown::Release method for your drop target interface.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-revokedragdrop HRESULT RevokeDragDrop( IN HWND hwnd );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "c0fa963c-ed06-426c-8ffc-31b02f083a23")]
		public static extern HRESULT RevokeDragDrop([In] HWND hwnd);

		/// <summary>
		/// The <c>SetConvertStg</c> function sets the convert bit in a storage object to indicate that the object is to be converted to a
		/// new class when it is opened. The setting can be retrieved with a call to the GetConvertStg function.
		/// </summary>
		/// <param name="pStg">IStorage pointer to the storage object in which to set the conversion bit.</param>
		/// <param name="fConvert">
		/// If <c>TRUE</c>, sets the conversion bit for the object to indicate the object is to be converted when opened. If <c>FALSE</c>,
		/// clears the conversion bit.
		/// </param>
		/// <returns>
		/// See the IStorage::CreateStream, IStorage::OpenStream, ISequentialStream::Read, and ISequentialStream::Write methods for possible
		/// storage and stream access errors.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SetConvertStg</c> function determines the status of the convert bit in a contained object. It is called by both the
		/// container application and the server in the process of converting an object from one class to another. When a user specifies
		/// through a <c>Convert To</c> dialog (which the container produces with a call to the OleUIConvert function) that an object is to
		/// be converted, the container must take the following steps:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Unload the object if it is currently loaded.</term>
		/// </item>
		/// <item>
		/// <term>Call WriteClassStg to write the new CLSID to the object storage.</term>
		/// </item>
		/// <item>
		/// <term>Call WriteFmtUserTypeStg to write the new user-type name and the existing main format to the storage.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Call <c>SetConvertStg</c> with the fConvert parameter set to <c>TRUE</c> to indicate that the object has been tagged for
		/// conversion to a new class the next time it is loaded.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Just before the object is loaded, call OleDoAutoConvert to handle any needed object conversion, unless you call OleLoad, which
		/// calls it internally.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// When an object is initialized from a storage object and the server is the destination of a convert-to operation, the object
		/// server should do the following:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Call the GetConvertStg function to retrieve the value of the conversion bit.</term>
		/// </item>
		/// <item>
		/// <term>If the bit is set, the server reads the data out of the object according to the format associated with the new CLSID.</term>
		/// </item>
		/// <item>
		/// <term>
		/// When the object is asked to save itself, the object should call the WriteFmtUserTypeStg function using the normal native format
		/// and user type of the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The object should then call <c>SetConvertStg</c> with the fConvert parameter set to <c>FALSE</c> to reset the object's conversion bit.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-setconvertstg HRESULT SetConvertStg( IN LPSTORAGE pStg, IN BOOL
		// fConvert );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "98c8fd20-6384-4656-941c-1f24d9a4d4a9")]
		public static extern HRESULT SetConvertStg([In] IStorage pStg, [MarshalAs(UnmanagedType.Bool)] bool fConvert);

		/// <summary>The <c>WriteFmtUserTypeStg</c> function writes a clipboard format and user type to the storage object.</summary>
		/// <param name="pstg">IStorage pointer to the storage object where the information is to be written.</param>
		/// <param name="cf">
		/// Specifies the clipboard format that describes the structure of the native area of the storage object. The format tag includes the
		/// policy for the names of streams and substorages within this storage object and the rules for interpreting data within those streams.
		/// </param>
		/// <param name="lpszUserType">
		/// Pointer to a null-terminated Unicode string that specifies the object's current user type. The user type value, itself, cannot be
		/// <c>NULL</c>. This is the type returned by the IOleObject::GetUserType method. If this function is transported to a remote machine
		/// where the object class does not exist, this persistently stored user type can be shown to the user in dialog boxes.
		/// </param>
		/// <returns>This function returns HRESULT.</returns>
		/// <remarks>
		/// <para>
		/// The <c>WriteFmtUserTypeStg</c> function must be called in an object's implementation of the IPersistStorage::Save method. It must
		/// also be called by document-level objects that use structured storage for their persistent representation in their save sequence.
		/// </para>
		/// <para>To read the information saved, applications call the ReadFmtUserTypeStg function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-writefmtusertypestg HRESULT WriteFmtUserTypeStg( IN LPSTORAGE
		// pstg, IN CLIPFORMAT cf, LPOLESTR lpszUserType );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ole2.h", MSDNShortId = "ef60493c-164e-4633-a248-05c4afade937")]
		public static extern HRESULT WriteFmtUserTypeStg([In] IStorage pstg, CLIPFORMAT cf, [MarshalAs(UnmanagedType.LPWStr)] string lpszUserType);

		/// <summary>Provides a handle to a menu descriptor.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HOLEMENU : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HOLEMENU"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HOLEMENU(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HOLEMENU"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HOLEMENU NULL => new HOLEMENU(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HOLEMENU"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HOLEMENU h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HOLEMENU"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HOLEMENU(IntPtr h) => new HOLEMENU(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HOLEMENU h1, HOLEMENU h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HOLEMENU h1, HOLEMENU h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HOLEMENU h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to an OLE 1 stream.</summary>
		[PInvokeData("ole2.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct OLESTREAM
		{
			/// <summary>A pointer to an OLESTREAMVTBL instance.</summary>
			public IntPtr lpstbl;
		}
	}
}