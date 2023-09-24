using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

public static partial class MsftEdit
{
	/// <summary/>
	public const uint REO_READWRITEMASK = 0x000007FF;

	/// <summary>A clipboard operation flag.</summary>
	[PInvokeData("richole.h", MSDNShortId = "NN:richole.IRichEditOleCallback")]
	public enum RECO
	{
		/// <summary>Paste from the clipboard.</summary>
		RECO_PASTE = 0x00000000,

		/// <summary>Drop operation (drag-and-drop).</summary>
		RECO_DROP = 0x00000001,

		/// <summary>Copy to the clipboard.</summary>
		RECO_COPY = 0x00000002,

		/// <summary>Cut to the clipboard.</summary>
		RECO_CUT = 0x00000003,

		/// <summary>Drag operation.</summary>
		RECO_DRAG = 0x00000004,
	}

	/// <summary>Object status flag.</summary>
	[PInvokeData("richole.h")]
	[Flags]
	public enum REO : uint
	{
		/// <summary>Align the object with the right side of the view. This value is ignored if REO_WRAPTEXTAROUND is not specified.</summary>
		REO_ALIGNTORIGHT = 0x00000100,

		/// <summary>The object sits below the baseline of the surrounding text; the default is to sit on the baseline.</summary>
		REO_BELOWBASELINE = 0x00000002,

		/// <summary>The object is new. This value gives the object an opportunity to save nothing and be deleted from the control automatically.</summary>
		REO_BLANK = 0x00000010,

		/// <summary>The object can display itself in a rotated position.</summary>
		REO_CANROTATE = 0x00000080,

		/// <summary>The object is rendered before the creation and realization of a half-tone palette. Applies to 32-bit platforms only.</summary>
		REO_DONTNEEDPALETTE = 0x00000020,

		/// <summary>The object always determines its extents and may change despite the modify flag being turned off.</summary>
		REO_DYNAMICSIZE = 0x00000008,

		/// <summary>
		/// The rich edit control retrieved the metafile from the object to correctly determine the object's extents. This flag can be read
		/// but not set.
		/// </summary>
		REO_GETMETAFILE = 0x00400000,

		/// <summary>
		/// The object is currently highlighted to indicate selection. Occurs when focus is in the control and REO_SELECTED is set. This flag
		/// can be read but not set.
		/// </summary>
		REO_HILITED = 0x01000000,

		/// <summary>The object is currently inplace active. This flag can be read but not set.</summary>
		REO_INPLACEACTIVE = 0x02000000,

		/// <summary>The object is to be drawn entirely inverted when selected; the default is to be drawn with a border.</summary>
		REO_INVERTEDSELECT = 0x00000004,

		/// <summary>The object is a link. This flag can be read but not set.</summary>
		REO_LINK = 0x80000000,

		/// <summary>The object is a link and is believed to be available. This flag can be read but not set.</summary>
		REO_LINKAVAILABLE = 0x00800000,

		/// <summary>The reo null</summary>
		REO_NULL = 0x00000000,

		/// <summary>The object is currently open in its server. This flag can be read but not set.</summary>
		REO_OPEN = 0x04000000,

		/// <summary>The owner draws the selected object.</summary>
		REO_OWNERDRAWSELECT = 0x00000040,

		/// <summary>The object may be resized.</summary>
		REO_RESIZABLE = 0x00000001,

		/// <summary>The object is currently selected in the rich edit control. This flag can be read but not set.</summary>
		REO_SELECTED = 0x08000000,

		/// <summary>The object is a static object. This flag can be read but not set.</summary>
		REO_STATIC = 0x40000000,

		/// <summary>Use the object as the background picture.</summary>
		REO_USEASBACKGROUND = 0x00000400,

		/// <summary>Wrap text around the object.</summary>
		REO_WRAPTEXTAROUND = 0x00000200,
	}

	/// <summary>Operation flags that specify which interfaces to return in the structure.</summary>
	[PInvokeData("richole.h", MSDNShortId = "NN:richole.IRichEditOle")]
	[Flags]
	public enum REO_GETOBJ
	{
		/// <summary>Get no interfaces.</summary>
		REO_GETOBJ_NO_INTERFACES = 0x00000000,

		/// <summary>Get object interface.</summary>
		REO_GETOBJ_POLEOBJ = 0x00000001,

		/// <summary>Get storage interface.</summary>
		REO_GETOBJ_PSTG = 0x00000002,

		/// <summary>Get site interface.</summary>
		REO_GETOBJ_POLESITE = 0x00000004,

		/// <summary>Get all interfaces.</summary>
		REO_GETOBJ_ALL_INTERFACES = 0x00000007,
	}

	/// <summary>
	/// <para>
	/// The <c>IRichEditOle</c> interface exposes the Component Object Model (COM) functionality of a rich edit control. The interface can be
	/// obtained by sending the EM_GETOLEINTERFACE message.
	/// </para>
	/// <para>This interface has the following methods.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richole/nn-richole-iricheditole
	[PInvokeData("richole.h", MSDNShortId = "NN:richole.IRichEditOle")]
	[ComImport, Guid("00020D00-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRichEditOle
	{
		/// <summary>
		/// Retrieves an IOleClientSite interface to be used when creating a new object. All objects inserted into a rich edit control must
		/// use client site interfaces returned by this function. A client site may be used with exactly one object.
		/// </summary>
		/// <param name="lplpolesite">
		/// <para>Type: <c>LPOLECLIENTSITE*</c></para>
		/// <para>The address of the IOleClientSite interface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns <c>S_OK</c> on success, or a failure code otherwise. <c>E_OUTOFMEMORY</c> is returned if memory could not be allocated
		/// for the client site.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditole-getclientsite HRESULT GetClientSite(
		// LPOLECLIENTSITE *lplpolesite );
		[PreserveSig]
		HRESULT GetClientSite(IOleClientSite lplpolesite);

		/// <summary>Returns the number of objects currently contained in a rich edit control.</summary>
		/// <returns>
		/// <para>Type: <c>LONG</c></para>
		/// <para>This method returns the number of objects.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditole-getobjectcount LONG GetObjectCount();
		[PreserveSig]
		int GetObjectCount();

		/// <summary>Returns the number of objects in a rich edit control that are links.</summary>
		/// <returns>
		/// <para>Type: <c>LONG</c></para>
		/// <para>This method returns the number of links.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditole-getlinkcount LONG GetLinkCount();
		[PreserveSig]
		int GetLinkCount();

		/// <summary>Retrieves information, stored in a REOBJECT structure, about an object in a rich edit control.</summary>
		/// <param name="iob">
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Zero-based index that specifies which object to return information about. If this parameter is <c>REO_IOB_USE_CP</c>, information
		/// about the object at the character position specified by the REOBJECT structure is returned.
		/// </para>
		/// </param>
		/// <param name="lpreobject">
		/// <para>Type: <c>REOBJECT*</c></para>
		/// <para>
		/// Structure that receives information about the object. The reference count of the interfaces returned in this structure has been
		/// incremented; it is the responsibility of the caller to use the Release method to decrement the count.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Operation flags that specify which interfaces to return in the structure. The <c>dwFlags</c> parameter can be a combination of
		/// the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>REO_GETOBJ_POLEOBJ</c></description>
		/// <description>Get object interface.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_GETOBJ_PSTG</c></description>
		/// <description>Get storage interface.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_GETOBJ_POLESITE</c></description>
		/// <description>Get site interface.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_GETOBJ_NO_INTERFACES</c></description>
		/// <description>Get no interfaces.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_GETOBJ_ALL_INTERFACES</c></description>
		/// <description>Get all interfaces.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns <c>S_OK</c> if successful, or an error value otherwise. <c>E_INVALIDARG</c> is returned if no buffer for the REOBJECT
		/// structure was given or if the <c>iob</c> value or character position is invalid.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditole-getobject HRESULT GetObject( LONG iob,
		// REOBJECT *lpreobject, DWORD dwFlags );
		[PreserveSig]
		HRESULT GetObject(int iob, ref REOBJECT lpreobject, REO_GETOBJ dwFlags);

		/// <summary>Inserts an object into a rich edit control.</summary>
		/// <param name="lpreobject">
		/// <para>Type: <c>REOBJECT*</c></para>
		/// <para>
		/// The object information and interfaces. The rich edit control automatically increments the reference count for the interfaces if
		/// it holds onto them, so the caller can safely release the interfaces if they are not needed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK on success, or a failure code otherwise. E_OUTOFMEMORY is returned if memory could not be allocated to insert the object.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If the <c>cp</c> member of the REOBJECT structure is REO_CP_SELECTION, the selection is replaced with the specified object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditole-insertobject HRESULT InsertObject( REOBJECT
		// *lpreobject );
		[PreserveSig]
		HRESULT InsertObject(in REOBJECT lpreobject);

		/// <summary>Converts an object to a new type. This call reloads the object but does not force an update; the caller must do this.</summary>
		/// <param name="iob">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Index of the object to convert. If this parameter is REO_IOB_SELECTION, the selected object is to be converted.</para>
		/// </param>
		/// <param name="rclsidNew">
		/// <para>Type: <c>REFCLSID</c></para>
		/// <para>Class identifier of the class to which the object is converted.</para>
		/// </param>
		/// <param name="lpstrUserTypeNew">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>User-visible type name of the class to which the object is converted.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK on success, or a failure code otherwise. E_INVALIDARG is returned if the index is invalid.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditole-convertobject HRESULT ConvertObject( LONG iob,
		// REFCLSID rclsidNew, LPCSTR lpstrUserTypeNew );
		[PreserveSig]
		HRESULT ConvertObject(int iob, in Guid rclsidNew, string lpstrUserTypeNew);

		/// <summary>
		/// Handles <c>Activate As</c> behavior by unloading all objects of the old class, telling OLE to treat those objects as objects of
		/// the new class, and reloading the objects. If objects cannot be reloaded, they are deleted.
		/// </summary>
		/// <param name="rclsid">
		/// <para>Type: <c>REFCLSID</c></para>
		/// <para>Class identifier of the old class.</para>
		/// </param>
		/// <param name="rclsidAs">
		/// <para>Type: <c>REFCLSID</c></para>
		/// <para>Class identifier of the new class.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK on success, or a failure code otherwise.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditole-activateas HRESULT ActivateAs( REFCLSID
		// rclsid, REFCLSID rclsidAs );
		[PreserveSig]
		HRESULT ActivateAs(in Guid rclsid, in Guid rclsidAs);

		/// <summary>
		/// Sets the host names to be given to objects as they are inserted to a rich edit control. The host names are used in the user
		/// interface of servers to describe the container context of opened objects.
		/// </summary>
		/// <param name="lpstrContainerApp">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>Null-terminated name of the container application.</para>
		/// </param>
		/// <param name="lpstrContainerObj">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>Null-terminated name of the container document or object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK on success, or a failure code otherwise. E_OUTOFMEMORY is returned if memory could not be allocated to remember the strings.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditole-sethostnames HRESULT SetHostNames( LPCSTR
		// lpstrContainerApp, LPCSTR lpstrContainerObj );
		[PreserveSig]
		HRESULT SetHostNames(string lpstrContainerApp, string lpstrContainerObj);

		/// <summary>
		/// Sets the value of the link-available bit in the object's flags. The link-available bit defaults to <c>TRUE</c>. It should be set
		/// to <c>FALSE</c> if any errors occur on the link which would indicate problems connecting to the linked object or application.
		/// When those problems are repaired, the bit should be set to <c>TRUE</c> again.
		/// </summary>
		/// <param name="iob">
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Index of object whose bit is to be set. If this parameter is REO_IOB_SELECTION, the bit on the selected object is to be set.
		/// </para>
		/// </param>
		/// <param name="fAvailable">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Value used in the set operation. The value can be <c>TRUE</c> or <c>FALSE</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK on success, or a failure code otherwise. E_INVALIDARG is returned if the index is invalid.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditole-setlinkavailable HRESULT SetLinkAvailable(
		// LONG iob, BOOL fAvailable );
		[PreserveSig]
		HRESULT SetLinkAvailable(int iob, bool fAvailable);

		/// <summary>
		/// Sets the aspect that a rich edit control uses to draw an object. This call does not change the drawing information cached in the
		/// object; this must be done by the caller. The call does cause the object to be redrawn.
		/// </summary>
		/// <param name="iob">
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Index of the object whose aspect is to be set. If this parameter is REO_IOB_SELECTION, the aspect of the selected object is to be set.
		/// </para>
		/// </param>
		/// <param name="dvaspect">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Aspect to use when drawing. The values are defined by OLE.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK on success, or a failure code otherwise. E_INVALIDARG is returned if the index is invalid.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditole-setdvaspect HRESULT SetDvaspect( LONG iob,
		// DWORD dvaspect );
		[PreserveSig]
		HRESULT SetDvaspect(int iob, DVASPECT dvaspect);

		/// <summary>
		/// Indicates when a rich edit control is to release its reference to the storage interface associated with the specified object.
		/// This call does not call the object's <c>IRichEditOle::HandsOffStorage</c> method; the caller must do that.
		/// </summary>
		/// <param name="iob">
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Index of the object whose storage is to be released. If this parameter is REO_IOB_SELECTION, the storage of the selected object
		/// is to be released.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK on success, or a failure code otherwise. E_INVALIDARG is returned if the index is invalid.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditole-handsoffstorage HRESULT HandsOffStorage( LONG
		// iob );
		[PreserveSig]
		HRESULT HandsOffStorage(int iob);

		/// <summary>
		/// Indicates when the most recent save operation has been completed and that the rich edit control should hold onto a different
		/// storage for the object.
		/// </summary>
		/// <param name="iob">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Index of the object whose storage is being specified. If this parameter is REO_IOB_SELECTION, the selected object is used.</para>
		/// </param>
		/// <param name="lpstg">
		/// <para>Type: <c>LPSTORAGE</c></para>
		/// <para>
		/// New storage for the object. If the storage is not <c>NULL</c>, the rich edit control releases any storage it is currently holding
		/// for the object and uses this new storage instead.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK on success, or a failure code otherwise. E_INVALIDARG is returned if the index is invalid.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditole-savecompleted HRESULT SaveCompleted( LONG iob,
		// LPSTORAGE lpstg );
		[PreserveSig]
		HRESULT SaveCompleted(int iob, IStorage lpstg);

		/// <summary>Indicates when a rich edit control is to deactivate the currently active in-place object, if any.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK on success, or a failure code otherwise. If there is no active in-place object, the method succeeds.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditole-inplacedeactivate HRESULT InPlaceDeactivate();
		[PreserveSig]
		HRESULT InPlaceDeactivate();

		/// <summary>
		/// Indicates if a rich edit control should transition into or out of context-sensitive help mode. A rich edit control calls the
		/// <c>IRichEditOle::ContextSensitiveHelp</c> method of any in-place object which is currently active if a state change is occurring.
		/// </summary>
		/// <param name="fEnterMode">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Indicator of whether the control is entering context-sensitive help mode ( <c>TRUE</c>) or leaving it ( <c>FALSE</c>).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK on success, or a failure code otherwise.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditole-contextsensitivehelp HRESULT
		// ContextSensitiveHelp( BOOL fEnterMode );
		[PreserveSig]
		HRESULT ContextSensitiveHelp(bool fEnterMode);

		/// <summary>Retrieves a clipboard object for a range in an edit control.</summary>
		/// <param name="lpchrg">
		/// <para>Type: <c>CHARRANGE*</c></para>
		/// <para>The range for which to create the clipboard object.</para>
		/// </param>
		/// <param name="reco">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Unused.</para>
		/// </param>
		/// <param name="lplpdataobj">
		/// <para>Type: <c>LPDATAOBJECT*</c></para>
		/// <para>The IDataObject interface of the clipboard object representing the range specified in the <c>lpchrg</c> parameter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns <c>S_OK</c> on success. If the method fails, it can return one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>There was an invalid argument.</description>
		/// </item>
		/// <item>
		/// <description><c>E_OUTOFMEMORY</c></description>
		/// <description>There was not enough memory to do the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditole-getclipboarddata HRESULT GetClipboardData(
		// CHARRANGE *lpchrg, DWORD reco, LPDATAOBJECT *lplpdataobj );
		[PreserveSig]
		HRESULT GetClipboardData(in CHARRANGE lpchrg, uint reco, out IDataObject lplpdataobj);

		/// <summary>Imports a clipboard object into a rich edit control, replacing the current selection.</summary>
		/// <param name="lpdataobj">
		/// <para>Type: <c>LPDATAOBJECT</c></para>
		/// <para>The clipboard object to import.</para>
		/// </param>
		/// <param name="cf">
		/// <para>Type: <c>CLIPFORMAT</c></para>
		/// <para>Clipboard format to use. A value of zero will use the best available format.</para>
		/// </param>
		/// <param name="hMetaPict">
		/// <para>Type: <c>HGLOBAL</c></para>
		/// <para>
		/// Handle to a metafile containing the icon view of an object. The handle is used only if the <c>DVASPECT_ICON</c> display aspect is
		/// required by a Paste Special operation.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns <c>S_OK</c> on success. If the method fails, it can return one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>There was an invalid argument.</description>
		/// </item>
		/// <item>
		/// <description><c>E_OUTOFMEMORY</c></description>
		/// <description>There was not enough memory to do the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditole-importdataobject HRESULT ImportDataObject(
		// LPDATAOBJECT lpdataobj, CLIPFORMAT cf, HGLOBAL hMetaPict );
		[PreserveSig]
		HRESULT ImportDataObject(IDataObject lpdataobj, ushort cf, IntPtr hMetaPict);
	}

	/// <summary>
	/// The <c>IRichEditOleCallback</c> interface is used by a rich text edit control to retrieve OLE-related information from its client. A
	/// rich edit control client is responsible for implementing this interface and assigning it to the control by using the
	/// EM_SETOLECALLBACK message.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richole/nn-richole-iricheditolecallback
	[PInvokeData("richole.h", MSDNShortId = "NN:richole.IRichEditOleCallback")]
	[ComImport, Guid("00020D03-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRichEditOleCallback
	{
		/// <summary>Provides storage for a new object pasted from the clipboard or read in from an Rich Text Format (RTF) stream.</summary>
		/// <param name="lplpstg">
		/// <para>Type: <c>LPSTORAGE*</c></para>
		/// <para>The address of the IStorage interface created for the new object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns <c>S_OK</c> on success. If the method fails, it can return one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>There was an invalid argument.</description>
		/// </item>
		/// <item>
		/// <description><c>E_OUTOFMEMORY</c></description>
		/// <description>There was not enough memory to do the operation.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method must be implemented to allow cut, copy, paste, drag, and drop operations of Component Object Model (COM) objects.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditolecallback-getnewstorage HRESULT GetNewStorage(
		// LPSTORAGE *lplpstg );
		[PreserveSig]
		HRESULT GetNewStorage(out IStorage lplpstg);

		/// <summary>Provides the application and document-level interfaces and information required to support in-place activation.</summary>
		/// <param name="lplpFrame">
		/// <para>Type: <c>LPOLEINPLACEFRAME*</c></para>
		/// <para>
		/// The address of the IOleInPlaceFrame interface that represents the frame window of a rich edit control client. Use the AddRef
		/// method to increment the reference count. The rich edit control releases the interface when it is no longer needed.
		/// </para>
		/// </param>
		/// <param name="lplpDoc">
		/// <para>Type: <c>LPOLEINPLACEUIWINDOW*</c></para>
		/// <para>
		/// The address of the IOleInPlaceUIWindow interface that represents the document window of the rich edit control client. An
		/// interface need not be returned if the frame and document windows are the same. Use the AddRef method to increment the reference
		/// count. The rich edit control releases the interface when it is no longer needed.
		/// </para>
		/// </param>
		/// <param name="lpFrameInfo">
		/// <para>Type: <c>LPOLEINPLACEFRAMEINFO</c></para>
		/// <para>The accelerator information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns <c>S_OK</c> on success. If the method fails, it can return the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>There was an invalid argument.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditolecallback-getinplacecontext HRESULT
		// GetInPlaceContext( LPOLEINPLACEFRAME *lplpFrame, LPOLEINPLACEUIWINDOW *lplpDoc, LPOLEINPLACEFRAMEINFO lpFrameInfo );
		[PreserveSig]
		HRESULT GetInPlaceContext(IOleInPlaceFrame lplpFrame, IOleInPlaceUIWindow lplpDoc, ref OLEINPLACEFRAMEINFO lpFrameInfo);

		/// <summary>
		/// Indicates whether or not the application is to display its container UI. The rich edit control looks ahead for double-clicks and
		/// defers the call if appropriate. Applications may defer hiding adornments until an IOleInPlaceUIWindow::SetBorderSpace call is received.
		/// </summary>
		/// <param name="fShow">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Show container UI flag. The value is <c>TRUE</c> if the container UI is displayed, and <c>FALSE</c> if it is not.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns <c>S_OK</c> on success. If the method fails, it can return the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>There was an invalid argument.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The <c>IRichEditOleCallback::ShowContainerUI</c> method is called by the IOleInPlaceSite::OnUIActivate and
		/// IOleInPlaceSite::OnUIDeactivate methods of the IOleInPlaceSite interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditolecallback-showcontainerui HRESULT
		// ShowContainerUI( BOOL fShow );
		[PreserveSig]
		HRESULT ShowContainerUI(bool fShow);

		/// <summary>
		/// Queries the application as to whether an object should be inserted. The member is called when pasting and when reading Rich Text
		/// Format (RTF).
		/// </summary>
		/// <param name="lpclsid">
		/// <para>Type: <c>LPCLSID</c></para>
		/// <para>Class identifier of the object to be inserted.</para>
		/// </param>
		/// <param name="lpstg">
		/// <para>Type: <c>LPSTORAGE</c></para>
		/// <para>Storage containing the object.</para>
		/// </param>
		/// <param name="cp">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Character position, at which the object will be inserted.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK on success. If the return value is not S_OK, the object was not inserted. If the method fails, it can return the
		/// following value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>There was an invalid argument.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditolecallback-queryinsertobject HRESULT
		// QueryInsertObject( LPCLSID lpclsid, LPSTORAGE lpstg, LONG cp );
		[PreserveSig]
		HRESULT QueryInsertObject(in Guid lpclsid, IStorage lpstg, int cp);

		/// <summary>
		/// Sends notification that an object is about to be deleted from a rich edit control. The object is not necessarily being released
		/// when this member is called.
		/// </summary>
		/// <param name="lpoleobj">
		/// <para>Type: <c>LPOLEOBJECT</c></para>
		/// <para>The object that is being deleted.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns <c>S_OK</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditolecallback-deleteobject HRESULT DeleteObject(
		// LPOLEOBJECT lpoleobj );
		[PreserveSig]
		HRESULT DeleteObject(IOleObject lpoleobj);

		/// <summary>During a paste operation or a drag event, determines if the data that is pasted or dragged should be accepted.</summary>
		/// <param name="lpdataobj">
		/// <para>Type: <c>LPDATAOBJECT</c></para>
		/// <para>The data object being pasted or dragged.</para>
		/// </param>
		/// <param name="lpcfFormat">
		/// <para>Type: <c>CLIPFORMAT*</c></para>
		/// <para>
		/// The clipboard format that will be used for the paste or drop operation. If the value pointed to by <c>lpcfFormat</c> is zero, the
		/// best available format will be used. If the callback changes the value pointed to by <c>lpcfFormat</c>, the rich edit control only
		/// uses that format and the operation will fail if the format is not available.
		/// </para>
		/// </param>
		/// <param name="reco">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A clipboard operation flag, which can be one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>RECO_DROP</c></description>
		/// <description>Drop operation (drag-and-drop).</description>
		/// </item>
		/// <item>
		/// <description><c>RECO_PASTE</c></description>
		/// <description>Paste from the clipboard.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="fReally">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Indicates whether the drag-drop is actually happening or if it is just a query. A nonzero value indicates the paste or drop is
		/// actually happening. A zero value indicates the operation is just a query, such as for EM_CANPASTE.
		/// </para>
		/// </param>
		/// <param name="hMetaPict">
		/// <para>Type: <c>HGLOBAL</c></para>
		/// <para>
		/// Handle to a metafile containing the icon view of an object if <c>DVASPECT_ICON</c> is being imposed on an object by a paste
		/// special operation.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns <c>S_OK</c> on success. See Remarks.</para>
		/// </returns>
		/// <remarks>
		/// On failure, the rich edit control refuses the data and terminates the operation. Otherwise, the control checks the data itself
		/// for acceptable formats. A success code other than <c>S_OK</c> means that the callback either checked the data itself (if
		/// <c>fReally</c> is <c>FALSE</c>) or imported the data itself (if <c>fReally</c> is <c>TRUE</c>). If the application returns a
		/// success code other than <c>S_OK</c>, the control does not check the read-only state of the edit control.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditolecallback-queryacceptdata HRESULT
		// QueryAcceptData( LPDATAOBJECT lpdataobj, CLIPFORMAT *lpcfFormat, DWORD reco, BOOL fReally, HGLOBAL hMetaPict );
		[PreserveSig]
		HRESULT QueryAcceptData(IDataObject lpdataobj, ref ushort lpcfFormat, RECO reco, bool fReally, IntPtr hMetaPict);

		/// <summary>
		/// Indicates if the application should transition into or out of context-sensitive help mode. This method should implement the
		/// functionality described for IOleWindow::ContextSensitiveHelp.
		/// </summary>
		/// <param name="fEnterMode">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// If <c>TRUE</c>, the application should enter context-sensitive help mode. If <c>FALSE</c>, the application should leave
		/// context-sensitive help mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns <c>S_OK</c> on success. If the method fails, it can be the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>There was an invalid argument.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditolecallback-contextsensitivehelp HRESULT
		// ContextSensitiveHelp( BOOL fEnterMode );
		[PreserveSig]
		HRESULT ContextSensitiveHelp(bool fEnterMode);

		/// <summary>Allows the client to supply its own clipboard object.</summary>
		/// <param name="lpchrg">
		/// <para>Type: <c>CHARRANGE*</c></para>
		/// <para>The clipboard object range.</para>
		/// </param>
		/// <param name="reco">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The clipboard operation flag can be one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>RECO_COPY</c></description>
		/// <description>Copy to the clipboard.</description>
		/// </item>
		/// <item>
		/// <description><c>RECO_CUT</c></description>
		/// <description>Cut to the clipboard.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lplpdataobj">
		/// <para>Type: <c>LPDATAOBJECT*</c></para>
		/// <para>
		/// Pointer to the pointer variable that receives the address of the IDataObject implementation representing the range specified in
		/// the <c>lpchrg</c> parameter. The value of <c>lplpdataobj</c> is ignored if an error is returned.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns <c>S_OK</c> on success. If the return value is <c>E_NOTIMPL</c>, the rich edit control created its own clipboard object.
		/// If the return value is a failure other than <c>E_NOTIMPL</c>, the operation failed.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditolecallback-getclipboarddata HRESULT
		// GetClipboardData( CHARRANGE *lpchrg, DWORD reco, LPDATAOBJECT *lplpdataobj );
		[PreserveSig]
		HRESULT GetClipboardData(in CHARRANGE lpchrg, RECO reco, out IDataObject lplpdataobj);

		/// <summary>Allows the client to specify the effects of a drop operation.</summary>
		/// <param name="fDrag">
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the query is for a IDropTarget::DragEnter or IDropTarget::DragOver. <c>FALSE</c> if the query is for IDropTarget::Drop.</para>
		/// </param>
		/// <param name="grfKeyState">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Key state as defined by OLE.</para>
		/// </param>
		/// <param name="pdwEffect">
		/// <para>Type: <c>LPDWORD</c></para>
		/// <para>
		/// The effect used by a rich edit control. When <c>fDrag</c> is <c>TRUE</c>, on return, its content is set to the effect allowable
		/// by the rich edit control. When <c>fDrag</c> is <c>FALSE</c>, on return, the variable is set to the effect to use.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns <c>S_OK</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditolecallback-getdragdropeffect HRESULT
		// GetDragDropEffect( BOOL fDrag, DWORD grfKeyState, LPDWORD pdwEffect );
		[PreserveSig]
		HRESULT GetDragDropEffect(bool fDrag, uint grfKeyState, out DROPEFFECT pdwEffect);

		/// <summary>Queries the application for a context menu to use on a right-click event.</summary>
		/// <param name="seltype">
		/// <para>Type: <c>WORD</c></para>
		/// <para>Selection type. The value, which specifies the contents of the new selection, can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>SEL_EMPTY</c></description>
		/// <description>The selection is empty.</description>
		/// </item>
		/// <item>
		/// <description><c>SEL_TEXT</c></description>
		/// <description>Text.</description>
		/// </item>
		/// <item>
		/// <description><c>SEL_OBJECT</c></description>
		/// <description>At least one COM object.</description>
		/// </item>
		/// <item>
		/// <description><c>SEL_MULTICHAR</c></description>
		/// <description>More than one character of text.</description>
		/// </item>
		/// <item>
		/// <description><c>SEL_MULTIOBJECT</c></description>
		/// <description>More than one COM object.</description>
		/// </item>
		/// <item>
		/// <description><c>GCM_RIGHTMOUSEDROP</c></description>
		/// <description>
		/// Indicates that a context menu for a right-mouse drag drop should be generated. The <c>lpoleobj</c> parameter is a pointer to the
		/// IDataObject interface for the object being dropped.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpoleobj">
		/// <para>Type: <c>LPOLEOBJECT</c></para>
		/// <para>
		/// Pointer to an interface. If the <c>seltype</c> parameter includes the <c>SEL_OBJECT</c> flag, <c>lpoleobj</c> is a pointer to the
		/// IOleObject interface for the first selected COM object. If <c>seltype</c> includes the <c>GCM_RIGHTMOUSEDROP</c> flag,
		/// <c>lpoleobj</c> is a pointer to an IDataObject interface. Otherwise, <c>lpoleobj</c> is <c>NULL</c>. If you hold on to the
		/// interface pointer, you must call the AddRef method to increment the object's reference count.
		/// </para>
		/// </param>
		/// <param name="lpchrg">
		/// <para>Type: <c>CHARRANGE*</c></para>
		/// <para>Pointer to a CHARRANGE structure containing the current selection.</para>
		/// </param>
		/// <param name="lphmenu">
		/// <para>Type: <c>HMENU*</c></para>
		/// <para>
		/// The handle of a context menu to use. This parameter is ignored if an error is returned. A rich edit control destroys the menu
		/// when it is finished with it so the client should not.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns <c>S_OK</c> on success. If the method fails, it can be the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>There was an invalid argument.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// When the user selects an item from the context window, a WM_COMMAND message is sent to the parent window of the rich edit control.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/richole/nf-richole-iricheditolecallback-getcontextmenu HRESULT GetContextMenu(
		// WORD seltype, LPOLEOBJECT lpoleobj, CHARRANGE *lpchrg, HMENU *lphmenu );
		[PreserveSig]
		HRESULT GetContextMenu(SEL seltype, IOleObject lpoleobj, ref CHARRANGE lpchrg, out HMENU lphmenu);
	}

	/// <summary>Contains information about an OLE or image object in a rich edit control.</summary>
	/// <remarks>
	/// An OLE or image object in a rich edit control occupies one character position in the plain text part of the in-memory backing store
	/// and have the value U+FFFC. They differ from "in-line objects" such as math objects. In-line objects occupy at least two character
	/// positions because they have an in-line object start delimiter (U+FDD0) and end delimiter (U+FDEF).
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richole/ns-richole-reobject typedef struct _reobject { DWORD cbStruct; LONG cp;
	// CLSID clsid; LPOLEOBJECT poleobj; LPSTORAGE pstg; LPOLECLIENTSITE polesite; SIZEL sizel; DWORD dvaspect; DWORD dwFlags; DWORD dwUser;
	// } REOBJECT;
	[PInvokeData("richole.h", MSDNShortId = "NS:richole._reobject")]
	[StructLayout(LayoutKind.Sequential)]
	public struct REOBJECT
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Structure size, in bytes.</para>
		/// </summary>
		public uint cbStruct;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>Character position of the object.</para>
		/// </summary>
		public int cp;

		/// <summary>
		/// <para>Type: <c>CLSID</c></para>
		/// <para>Class identifier of the object.</para>
		/// </summary>
		public Guid clsid;

		/// <summary>
		/// <para>Type: <c>LPOLEOBJECT</c></para>
		/// <para>An instance of the IOleObject interface for the object.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public IOleObject poleobj;

		/// <summary>
		/// <para>Type: <c>LPSTORAGE</c></para>
		/// <para>An instance of the IStorage interface. This is the storage object associated with the object.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public IStorage pstg;

		/// <summary>
		/// <para>Type: <c>LPOLECLIENTSITE</c></para>
		/// <para>
		/// An instance of the IOleClientSite interface. This is the object's client site in the rich edit control. This address must have
		/// been obtained from the GetClientSite method.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public IOleClientSite polesite;

		/// <summary>
		/// <para>Type: <c>SIZEL</c></para>
		/// <para>
		/// The size of the object. The unit of measure is 0.01 millimeters, which is a HIMETRIC measurement. For more information, see
		/// function GetMapMode. A 0, 0 on insertion indicates that an object is free to determine its size until the modify flag is turned off.
		/// </para>
		/// </summary>
		public SIZE sizel;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Display aspect used. See DVASPECT for an explanation of possible values.</para>
		/// </summary>
		public DVASPECT dvaspect;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Object status flag. It can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>REO_ALIGNTORIGHT</c></description>
		/// <description>Align the object with the right side of the view. This value is ignored if REO_WRAPTEXTAROUND is not specified.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_BELOWBASELINE</c></description>
		/// <description>The object sits below the baseline of the surrounding text; the default is to sit on the baseline.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_BLANK</c></description>
		/// <description>
		/// The object is new. This value gives the object an opportunity to save nothing and be deleted from the control automatically.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>REO_CANROTATE</c></description>
		/// <description>The object can display itself in a rotated position.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_DONTNEEDPALETTE</c></description>
		/// <description>
		/// The object is rendered before the creation and realization of a half-tone palette. Applies to 32-bit platforms only.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>REO_DYNAMICSIZE</c></description>
		/// <description>The object always determines its extents and may change despite the modify flag being turned off.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_GETMETAFILE</c></description>
		/// <description>
		/// The rich edit control retrieved the metafile from the object to correctly determine the object's extents. This flag can be read
		/// but not set.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>REO_HILITED</c></description>
		/// <description>
		/// The object is currently highlighted to indicate selection. Occurs when focus is in the control and <c>REO_SELECTED</c> is set.
		/// This flag can be read but not set.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>REO_INPLACEACTIVE</c></description>
		/// <description>The object is currently inplace active. This flag can be read but not set.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_INVERTEDSELECT</c></description>
		/// <description>The object is to be drawn entirely inverted when selected; the default is to be drawn with a border.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_LINK</c></description>
		/// <description>The object is a link. This flag can be read but not set.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_LINKAVAILABLE</c></description>
		/// <description>The object is a link and is believed to be available. This flag can be read but not set.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_OPEN</c></description>
		/// <description>The object is currently open in its server. This flag can be read but not set.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_OWNERDRAWSELECT</c></description>
		/// <description>The owner draws the selected object.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_RESIZABLE</c></description>
		/// <description>The object may be resized.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_SELECTED</c></description>
		/// <description>The object is currently selected in the rich edit control. This flag can be read but not set.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_STATIC</c></description>
		/// <description>The object is a static object. This flag can be read but not set.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_USEASBACKGROUND</c></description>
		/// <description>Use the object as the background picture.</description>
		/// </item>
		/// <item>
		/// <description><c>REO_WRAPTEXTAROUND</c></description>
		/// <description>Wrap text around the object.</description>
		/// </item>
		/// </list>
		/// </summary>
		public REO dwFlags;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Reserved for user-defined values.</para>
		/// </summary>
		public uint dwUser;
	}
}