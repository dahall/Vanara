using System.Data;
using System.Runtime.CompilerServices;

namespace Vanara.PInvoke;

public static partial class Hid
{
	/// <summary>
	/// Callback routine that the translate usage routine uses to return the mapped scan codes to the caller of the translate usage routine.
	/// </summary>
	/// <param name="Context">
	/// Pointer to the context of the caller of the translate usage routine. The translate usage routine passes the InsertCodesContext
	/// pointer to the InsertCodesProcedure routine.
	/// </param>
	/// <param name="NewScanCodes">
	/// Pointer to the first byte of a scan code that the translate usage routine returns to the caller of the translate usage routine.
	/// </param>
	/// <param name="Length">Specifies the length, in bytes, of the scan code. A scan code cannot exceed four bytes.</param>
	/// <returns></returns>
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_TranslateUsagesToI8042ScanCodes")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate bool PHIDP_INSERT_SCANCODES([In] IntPtr Context, [In, SizeDef(nameof(Length))] IntPtr NewScanCodes, uint Length);

	/// <summary>Identifies the key direction for the specified change usage list.</summary>
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_TranslateUsagesToI8042ScanCodes")]
	public enum HIDP_KEYBOARD_DIRECTION
	{
		/// <summary>
		/// Specifies a break direction (key up). The changed usage list contains the usages set to OFF that were previously set to ON (which
		/// corresponds to the keys that were previously down, but are now up).
		/// </summary>
		HidP_Keyboard_Break,

		/// <summary>
		/// Specifies a make direction (key down). The changed usage list contains the usages set to ON that were previously set to OFF
		/// (which corresponds to the keys that were previously up, but now are down).
		/// </summary>
		HidP_Keyboard_Make
	}

	/// <summary>
	/// This value can be used to differentiate between two fields that may have the same UsagePage and Usage but exist in different collections.
	/// </summary>
	public enum HIDP_LINK_COLLECTION : ushort
	{
		/// <summary>Specifies that the first button array found matching the UsagePage and Usage will be returned, regardless of location.</summary>
		HIDP_LINK_COLLECTION_UNSPECIFIED = 0,

		/// <summary>Specifies that the first button array found in the root collection matching the UsagePage and Usage will be returned.</summary>
		HIDP_LINK_COLLECTION_ROOT = ushort.MaxValue
	}

	/// <summary>The HIDP_REPORT_TYPE enumeration type is used to specify a HID report type.</summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/ne-hidpi-_hidp_report_type typedef enum _HIDP_REPORT_TYPE {
	// HidP_Input, HidP_Output, HidP_Feature } HIDP_REPORT_TYPE;
	[PInvokeData("hidpi.h", MSDNShortId = "NE:hidpi._HIDP_REPORT_TYPE")]
	public enum HIDP_REPORT_TYPE
	{
		/// <summary>Indicates an input report.</summary>
		HidP_Input,

		/// <summary>Indicates an output report.</summary>
		HidP_Output,

		/// <summary>Indicates a feature report.</summary>
		HidP_Feature,
	}

	/// <summary><b>HidP_GetButtonArray</b> returns an array of <c>HIDP_BUTTON_ARRAY_DATA</c> structures for the specified report.</summary>
	/// <param name="ReportType">A value from the <c>HIDP_REPORT_TYPE</c> enum.</param>
	/// <param name="UsagePage">The usage page to which the given usage refers.</param>
	/// <param name="LinkCollection">
	/// (Optional) This value can be used to differentiate between two fields that may have the same UsagePage and Usage but exist in
	/// different collections. If the LinkCollection value is <b>HIDP_LINK_COLLECTION_UNSPECIFIED</b>, the first button array found matching
	/// the UsagePage and Usage will be returned, regardless of location. If the LinkCollection value is <b>HIDP_LINK_COLLECTION_ROOT</b>,
	/// the first button array found in the root collection matching the UsagePage and Usage will be returned.
	/// </param>
	/// <param name="Usage">The usage whose buttons <b>HidP_GetButtonArray</b> will retrieve.</param>
	/// <param name="ButtonData">
	/// An array of <b>HIDP_BUTTON_ARRAY_DATA</b> structures where the data of buttons set to <c>ON</c> will be placed. The number of
	/// elements required is the ReportCount field of the <c>HIDP_BUTTON_CAPS</c> for this control. This buffer is provided by the caller.
	/// </param>
	/// <param name="ButtonDataLength">
	/// As input, this parameter specifies the length of the ButtonData parameter in number of array elements, not number of bytes. As
	/// output, if HIDP_STATUS_SUCCESS is returned, this value is set to indicate how many of those array elements were filled in by the
	/// function. The maximum number of <b>HIDP_BUTTON_ARRAY_DATA</b> structures that can be returned is determined by
	/// HIDP_BUTTON_CAPS.ReportCount. If HIDP_STATUS_BUFFER_TOO_SMALL is returned, this value contains the number of array elements needed to
	/// successfully complete the request.
	/// </param>
	/// <param name="PreparsedData">The pre-parsed data returned by the <c>HIDCLASS</c>.</param>
	/// <param name="Report">
	/// The report packet. The first byte must be the ReportId. This will be correctly set if the report is read from the system.
	/// </param>
	/// <param name="ReportLength">Length of the given report packet in bytes.</param>
	/// <returns>
	/// <para><b>HidP_GetButtonArray</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>HIDP_STATUS_SUCCESS</description>
	/// <description>Successfully retrieved the buttons from the report packet</description>
	/// </item>
	/// <item>
	/// <description>HIDP_STATUS_INVALID_REPORT_TYPE</description>
	/// <description>The <c>ReportType</c> parameter is not valid</description>
	/// </item>
	/// <item>
	/// <description>HIDP_STATUS_INVALID_PREPARSED_DATA</description>
	/// <description>The <c>PreparsedData</c> parameter is not valid</description>
	/// </item>
	/// <item>
	/// <description>HIDP_STATUS_INVALID_REPORT_LENGTH</description>
	/// <description>
	/// The length of the report packet is not equal to the length specified in the <b>HIDP_CAPS</b> structure for the given <c>ReportType</c>
	/// </description>
	/// </item>
	/// <item>
	/// <description>HIDP_STATUS_NOT_BUTTON_ARRAY</description>
	/// <description>The control specified is not a button array</description>
	/// </item>
	/// <item>
	/// <description>HIDP_STATUS_BUFFER_TOO_SMALL</description>
	/// <description>The size of the passed in buffer in which to return the array is too small</description>
	/// </item>
	/// <item>
	/// <description>HIDP_STATUS_INCOMPATIBLE_REPORT_ID</description>
	/// <description>
	/// The specified usage page, usage and link collection exists in a report with a different report ID than the report being passed in
	/// </description>
	/// </item>
	/// <item>
	/// <description>HIDP_STATUS_USAGE_NOT_FOUND</description>
	/// <description>The usage page, usage, and link collection combination does not exist in any reports for this <c>ReportType</c></description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller should use <c>HidP_GetVersion</c> to determine if this function is available. <b>HidP_GetButtonArray</b> is only available
	/// if <b>HidP_GetVersion</b> returns a value of two or greater. Version two of the API corresponds to Windows 11.
	/// </para>
	/// <para>
	/// A button array occurs when the last usage in the sequence of usages describing a main item, must be repeated because there are less
	/// usages defined than the ReportCount declared for the given main item. In this case, a single <b>HIDP_BUTTON_CAPS</b> is allocated for
	/// that usage and the ReportCount of the <b>HIDP_BUTTON_CAPS</b> is set to reflect the number of fields to which the usage refers.
	/// </para>
	/// <para>
	/// A <b>HIDP_BUTTON_CAPS</b> that describes a button array will always have ReportCount greater than one. If ReportCount equals one,
	/// then it is not a button array and cannot be used with <b>HidP_GetButtonArray</b>. See <c>HidP_GetUsages</c> instead.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getbuttonarray NTSTATUS HidP_GetButtonArray(
	// HIDP_REPORT_TYPE ReportType, USAGE UsagePage, USHORT LinkCollection, USAGE Usage, PHIDP_BUTTON_ARRAY_DATA ButtonData, PUSHORT
	// ButtonDataLength, PHIDP_PREPARSED_DATA PreparsedData, PCHAR Report, ULONG ReportLength );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_GetButtonArray")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_GetButtonArray(HIDP_REPORT_TYPE ReportType, USAGE UsagePage, [Optional] HIDP_LINK_COLLECTION LinkCollection,
		USAGE Usage, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5), SizeDef(nameof(ButtonDataLength), SizingMethod.Query)] HIDP_BUTTON_ARRAY_DATA[] ButtonData,
		ref ushort ButtonDataLength, PHIDP_PREPARSED_DATA PreparsedData, [In, SizeDef(nameof(ReportLength))] IntPtr Report, uint ReportLength);

	/// <summary>
	/// The <b>HidP_GetButtonCaps</b> routine returns a <c>button capability array</c> that describes all the HID control buttons in a
	/// <c>top-level collection</c> for a specified type of HID report.
	/// </summary>
	/// <param name="ReportType">Specifies a <c>HIDP_REPORT_TYPE</c> enumerator value that identifies the report type.</param>
	/// <param name="ButtonCaps">
	/// Pointer to a caller-allocated buffer that the routine uses to return a button capability array for the specified report type.
	/// </param>
	/// <param name="ButtonCapsLength">
	/// Specifies the length on input, in array elements, of the buffer provided at <i>ButtonCaps</i>. On output, this parameter is set to
	/// the actual number of elements that the routine returns.
	/// </param>
	/// <param name="PreparsedData">Pointer to a top-level collection's <c>preparsed data</c>.</param>
	/// <returns>
	/// <para><b>HidP_GetButtonCaps</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The routine successfully returned the capability data.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The preparsed data is not valid.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><b>HidP_GetButtonCaps</b> returns the capability of all buttons in a top level collection for a specified report type.</para>
	/// <para>
	/// <i>ButtonCapsLength</i> should be set to the value of the <b>Number</b><i>Xxx</i><b>ButtonCaps</b> member of the <c>HIDP_CAPS</c>
	/// structure returned by <c>HidP_GetCaps</c>, where <i>Xxx</i> specifies the report type.
	/// </para>
	/// <para>To obtain a subset of button capabilities, selected by <c>usage</c>, <c>usage page</c>, or <c>link collection</c>, use <c>HidP_GetSpecificButtonCaps</c>.</para>
	/// <para>For more information about a collection's capability, see <c>Obtaining Collection Information</c>.</para>
	/// <para>See also <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getbuttoncaps NTSTATUS HidP_GetButtonCaps( [in]
	// HIDP_REPORT_TYPE ReportType, [out] PHIDP_BUTTON_CAPS ButtonCaps, [in, out] PUSHORT ButtonCapsLength, [in] PHIDP_PREPARSED_DATA
	// PreparsedData );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_GetButtonCaps")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_GetButtonCaps([In] HIDP_REPORT_TYPE ReportType,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2), SizeDef(nameof(ButtonCapsLength), SizingMethod.Query)] HIDP_BUTTON_CAPS[] ButtonCaps,
		ref ushort ButtonCapsLength, [In] PHIDP_PREPARSED_DATA PreparsedData);

	/// <summary>The <b>HidP_GetButtons</b> macro is a mnemonic alias for the <c><b>HidP_GetUsages</b></c> function.</summary>
	/// <param name="Rty">Specifies a <c><b>HIDP_REPORT_TYPE</b></c> enumerator value that identifies the report type.</param>
	/// <param name="UPa">
	/// Specifies the <c>usage page</c> of the button usages. The routine only returns information about buttons on this usage page.
	/// </param>
	/// <param name="LCo">
	/// Specifies the <c>link collection</c> of the button usages. If LCo is nonzero, the routine only returns information about the buttons
	/// that this link collection contains; otherwise, if LCo is zero, the routine returns information about all the buttons in the
	/// <c>top-level collection</c> associated with Ppd.
	/// </param>
	/// <param name="ULi">
	/// Pointer to a caller-allocated buffer that the routine uses to return the usages of all buttons that are set to ON and belong to the
	/// usage page specified by UPa.
	/// </param>
	/// <param name="ULe">
	/// Specifies, on input, the length, in array elements, of the ULi buffer. Specifies, on output, the number of buttons that are set to ON
	/// on the specified usage page.
	/// </param>
	/// <param name="Ppd">Pointer to a top-level collection's <c>pre-parsed data</c>.</param>
	/// <param name="Rep">Pointer to a report.</param>
	/// <param name="RLe">Specifies the length, in bytes, of the report located at Rep.</param>
	/// <returns>None</returns>
	/// <remarks>See <c><b>HidP_GetUsages</b></c> for return value details.</remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getbuttons #define HidP_GetButtons(Rty, UPa, LCo,
	// ULi, ULe, Ppd, Rep, RLe) \ HidP_GetUsages(Rty, UPa, LCo, ULi, ULe, Ppd, Rep, RLe)
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_GetButtons")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static NTStatus HidP_GetButtons([In] HIDP_REPORT_TYPE Rty, [In] USAGE UPa,
		HIDP_LINK_COLLECTION LCo, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4), SizeDef(nameof(ULe), SizingMethod.Query)] USAGE[] ULi, ref uint ULe,
		[In] PHIDP_PREPARSED_DATA Ppd, [Out, SizeDef(nameof(RLe))] IntPtr Rep, uint RLe) => HidP_GetUsages(Rty, UPa, LCo, ULi, ref ULe, Ppd, Rep, RLe);

	/// <summary>The <b>HidP_GetButtonsEx</b> macro is a mnemonic alias for the <c><b>HidP_GetUsagesEx</b></c> function.</summary>
	/// <param name="Rty">Specifies a <c><b>HIDP_REPORT_TYPE</b></c> enumerator value that identifies the report type.</param>
	/// <param name="LCo">
	/// Specifies the <c>link collection</c> of the button usages. If LCo is nonzero, the routine only returns information about the buttons
	/// that this link collection contains; otherwise, if LCo is zero, the routine returns information about all the buttons in the
	/// <c>top-level collection</c> associated with Ppd.
	/// </param>
	/// <param name="BLi">
	/// Pointer to a caller-allocated buffer that routine uses to return the usage and <c>usage page</c> identifiers for each button that is
	/// set to ON (1).
	/// </param>
	/// <param name="ULe">
	/// Specifies, on input, the length, in array elements, of the BLi buffer. Specifies, on output, the number usages that are currently set
	/// to ON in the specified report.
	/// </param>
	/// <param name="Ppd">Pointer to a top-level collection's <c>pre-parsed data</c>.</param>
	/// <param name="Rep">Pointer to a report that contains button data.</param>
	/// <param name="RLe">Specifies the length, in bytes, of the report located at Rep.</param>
	/// <returns>None</returns>
	/// <remarks>See <c><b>HidP_GetUsagesEx</b></c> for return value details.</remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getbuttonsex #define HidP_GetButtonsEx(Rty, LCo,
	// BLi, ULe, Ppd, Rep, RLe) \ HidP_GetUsagesEx(Rty, LCo, BLi, ULe, Ppd, Rep, RLe)
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_GetButtonsEx")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static NTStatus HidP_GetButtonsEx([In] HIDP_REPORT_TYPE Rty, HIDP_LINK_COLLECTION LCo,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3), SizeDef(nameof(ULe), SizingMethod.Query)] USAGE_AND_PAGE[] BLi, ref uint ULe, [In] PHIDP_PREPARSED_DATA Ppd,
			[Out, SizeDef(nameof(RLe))] IntPtr Rep, uint RLe) => HidP_GetUsagesEx(Rty, LCo, BLi, ref ULe, Ppd, Rep, RLe);

	/// <summary>The <b>HidP_GetCaps</b> routine returns a <c>top-level collection's</c>  <c>HIDP_CAPS</c> structure.</summary>
	/// <param name="PreparsedData">Pointer to a top-level collection's <c>preparsed data</c>.</param>
	/// <param name="Capabilities">Pointer to a caller-allocated buffer that the routine uses to return a collection's HIDP_CAPS structure.</param>
	/// <returns>
	/// <para><b>HidP_GetCaps</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The routine successfully returned the collection capability information.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The specified preparsed data is invalid.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For more information about a collection's capability, see <c>Obtaining Collection Information</c>.</para>
	/// <para>See also <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getcaps NTSTATUS HidP_GetCaps( [in]
	// PHIDP_PREPARSED_DATA PreparsedData, [out] PHIDP_CAPS Capabilities );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_GetCaps")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_GetCaps([In] PHIDP_PREPARSED_DATA PreparsedData, out HIDP_CAPS Capabilities);

	/// <summary>
	/// The <b>HidP_GetData</b> routine returns, for a specified report, an array of <c>HIDP_DATA</c> structures that identify the <c>data
	/// indices</c> of all HID control buttons that are currently set to ON (1), and the data indices and data associated with all HID
	/// control values.
	/// </summary>
	/// <param name="ReportType">Specifies a <c>HIDP_REPORT_TYPE</c> enumerator value that indicates the type of HID report located at <i>Report</i>.</param>
	/// <param name="DataList">
	/// Specifies a caller-allocated array of HIDP_DATA structures that the routine uses to return information about all the buttons that are
	/// currently set to ON and the data associated with values.
	/// </param>
	/// <param name="DataLength">
	/// Specifies, on input, the number of structures that the caller-allocated <i>DataList</i> array holds. Specifies, on output, the number
	/// of controls for which the routine can return data, which includes all buttons that are currently set to ON and all control values.
	/// </param>
	/// <param name="PreparsedData">
	/// Pointer to the <c>preparsed data</c> of the top-level collection associated with the HID report located at <i>Report</i>.
	/// </param>
	/// <param name="Report">Pointer to a HID report.</param>
	/// <param name="ReportLength">
	/// Specifies the size, in bytes, of the HID report located at <i>Report</i>, which must be equal to the report length for the specified
	/// report type returned by <c>HidP_GetCaps</c> in the collection's <c>HIDP_CAPS</c> structure.
	/// </param>
	/// <returns>
	/// <para><b>HidP_GetData</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>All the control data was successfully returned.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_TYPE</b></description>
	/// <description>The report type specified by <i>ReportType</i> is not valid</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The preparsed data specified by <i>PreparsedData</i> is not valid</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_LENGTH</b></description>
	/// <description>
	/// The size, in bytes, of the HID report is not equal to the length specified in the collection's <c>HIDP_CAPS</c> structure for the
	/// specified report type.
	/// </description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_REPORT_DOES_NOT_EXIST</b></description>
	/// <description>The top-level collection does not have a report of the specified type.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_BUFFER_TOO_SMALL</b></description>
	/// <description>
	/// The <i>DataList</i> array is too small to describe all the buttons, currently set to ON, and all the values in the HID report.
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// User-mode applications and kernel-mode drivers call <c>HidP_MaxDataListLength</c> to determine the maximum possible number of
	/// HIDP_DATA structures that <b>HidP_GetData</b> can return.
	/// </para>
	/// <para><b>HidP_GetData</b> does not return data for <c>usage value arrays</c>.</para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getdata NTSTATUS HidP_GetData( [in]
	// HIDP_REPORT_TYPE ReportType, [out] PHIDP_DATA DataList, [in, out] PULONG DataLength, [in] PHIDP_PREPARSED_DATA PreparsedData, [in]
	// PCHAR Report, [in] ULONG ReportLength );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_GetData")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_GetData([In] HIDP_REPORT_TYPE ReportType,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2), SizeDef(nameof(DataLength), SizingMethod.Query)] HIDP_DATA[] DataList,
		ref uint DataLength, [In] PHIDP_PREPARSED_DATA PreparsedData, [In, SizeDef(nameof(ReportLength))] IntPtr Report, uint ReportLength);

	/// <summary>The <b>HidP_GetExtendedAttributes</b> routine returns the extended attributes of a HID control.</summary>
	/// <param name="ReportType">
	/// Specifies a <c>HIDP_REPORT_TYPE</c> enumerator value that indicates the type of HID report associated with the HID control specified
	/// by <i>DataIndex</i>.
	/// </param>
	/// <param name="DataIndex">Specifies the <c>data index</c> of the HID control.</param>
	/// <param name="PreparsedData">
	/// Specifies the <c>preparsed data</c> for the <c>top-level collection</c> that contains the specified control.
	/// </param>
	/// <param name="Attributes">
	/// Pointer to a caller-allocated buffer that the routine uses to return the extended attributes of the control specified by <i>DataIndex</i>.
	/// </param>
	/// <param name="LengthAttributes">
	/// Specifies the size, in bytes, of the <i>Attributes</i> buffer (which must be greater than or equal to sizeof(HIDP_EXTENDED_ATTRIBUTES).
	/// </param>
	/// <returns>
	/// <para><b>HidP_GetExtendedAttributes</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The routine successfully returned all the control's extended attribute information.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_BUFFER_TOO_SMALL</b></description>
	/// <description>The <i>Attribute</i> buffer was not large enough to hold all the extended attribute information.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_DATA_INDEX_NOT_FOUND</b></description>
	/// <description>The specified data index is not valid.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>HidP_GetExtendedAttributes</b> returns a variable length <c>HIDP_EXTENDED_ATTRIBUTES</c> structure in the <i>Attribute</i> buffer.
	/// The extended attributes structure contains, in consecutive order, the fixed length members ( <b>NumGlobalUnknowns</b>,
	/// <b>Reserved</b>, and <b>GlobalUnknowns</b>) followed by a variable length array of <c>HIDP_UNKNOWN_TOKEN</c> structures. The first
	/// member of the unknown token array is located at (PHIDP_UNKNOWN_TOKEN*)&amp;( <i>Attributes</i>-&gt; <b>Data</b>).
	/// </para>
	/// <para>
	/// The routine returns as many bytes of the extended attribute information as the <i>Attribute</i> buffer can hold. If the buffer is too
	/// small, the routine truncates the information it returns. To determine the number of unknown tokens in the variable length array, a
	/// caller can first use the <i>Attributes</i> buffer to return the value of the <b>NumGlobalUnknowns</b> member of the extended
	/// attributes information.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getextendedattributes NTSTATUS
	// HidP_GetExtendedAttributes( [in] HIDP_REPORT_TYPE ReportType, [in] USHORT DataIndex, [in] PHIDP_PREPARSED_DATA PreparsedData, [out]
	// PHIDP_EXTENDED_ATTRIBUTES Attributes, [in, out] PULONG LengthAttributes );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_GetExtendedAttributes")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_GetExtendedAttributes([In] HIDP_REPORT_TYPE ReportType, ushort DataIndex,
		[In] PHIDP_PREPARSED_DATA PreparsedData, [Out, SizeDef(nameof(LengthAttributes), SizingMethod.Bytes | SizingMethod.Query)] ManagedStructPointer<HIDP_EXTENDED_ATTRIBUTES> Attributes,
		ref uint LengthAttributes);

	/// <summary>The <b>HidP_GetLinkCollectionNodes</b> routine returns a <c>top-level collection's</c>  <c>link collection array</c>.</summary>
	/// <param name="LinkCollectionNodes">
	/// Pointer to a caller-allocated array of HIDP_LINK_COLLECTION_NODE structures in which <b>HidP_GetLinkCollectionNodes</b> returns a
	/// top-level collection's link collection array.
	/// </param>
	/// <param name="LinkCollectionNodesLength">
	/// Specifies, on input, the length, in array elements, of the <i>LinkCollectionNodes</i> buffer. On output, the routine sets
	/// <i>LinkCollectionNodesLength</i> to the number of entries in the array that it set.
	/// </param>
	/// <param name="PreparsedData">
	/// Pointer to the preparsed data of the top-level collection for which this routine returns a link collection array.
	/// </param>
	/// <returns>
	/// <para><b>HidP_GetLinkCollectionNodes</b> returns one of the following status codes:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The routine successfully returned the specified collection's link collection array.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The preparsed data is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_BUFFER_TOO_SMALL</b></description>
	/// <description>The <i>LinkCollectionNodes</i> buffer is too small to hold the entire link collection array.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The required length of the <i>LinkCollectionNodes</i> buffer is specified by the <b>NumberLinkCollectionNodes</b> member of a
	/// collection's <c>HIDP_CAPS</c> structure.
	/// </para>
	/// <para>
	/// If <b>HidP_GetLinkCollectionNodes</b> returns the status value HIDP_STATUS_BUFFER_TOO_SMALL, it also sets
	/// <i>LinkCollectionNodesLength</i> to the length, in array elements, required to hold the link collection nodes information.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getlinkcollectionnodes NTSTATUS
	// HidP_GetLinkCollectionNodes( [out] PHIDP_LINK_COLLECTION_NODE LinkCollectionNodes, [in, out] PULONG LinkCollectionNodesLength, [in]
	// PHIDP_PREPARSED_DATA PreparsedData );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_GetLinkCollectionNodes")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_GetLinkCollectionNodes([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1),
		SizeDef(nameof(LinkCollectionNodesLength), SizingMethod.Query)] HIDP_LINK_COLLECTION_NODE[] LinkCollectionNodes,
		ref uint LinkCollectionNodesLength, [In] PHIDP_PREPARSED_DATA PreparsedData);

	/// <summary>
	/// The <b>HidP_GetScaledUsageValue</b> routine returns the signed and scaled result of a HID control value extracted from a HID report.
	/// </summary>
	/// <param name="ReportType">
	/// Specifies a <b>HIDP_REPORT_TYPE</b> enumerator value that identifies the type of HID report that contains the <c>HID usage</c> value.
	/// </param>
	/// <param name="UsagePage">Specifies the usage page of the value to extract.</param>
	/// <param name="LinkCollection">
	/// Specifies the link collection identifier of the value to extract. A LinkCollection value of zero identifies the top-level collection.
	/// </param>
	/// <param name="Usage">Specifies the usage of the value to extract.</param>
	/// <param name="UsageValue">Pointer to the buffer in which the routine returns the signed and scaled value.</param>
	/// <param name="PreparsedData">
	/// Pointer to the <c>preparsed data</c> of the <c>top-level collection</c> that generated the report located at Report.
	/// </param>
	/// <param name="Report">Pointer to the report that contains the usage.</param>
	/// <param name="ReportLength">Specifies the length, in bytes, of the report located at Report.</param>
	/// <returns>
	/// <para><b>HidP_GetScaledUsageValue</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The routine successfully returned the value.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_TYPE</b></description>
	/// <description>The specified report type is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_LENGTH</b></description>
	/// <description>The specified report length is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_BAD_LOG_PHY_VALUES</b></description>
	/// <description>
	/// The collection returned an illegal logical or physical value. To extract the value returned by the collection, call <c>HidP_GetUsageValue</c>.
	/// </description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_NULL</b></description>
	/// <description>
	/// The current state of the scaled value from the collection is less than the logical minimum or is greater than the logical maximum,
	/// and the scaled value has a <b>NULL</b> state.
	/// </description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_VALUE_OUT_OF_RANGE</b></description>
	/// <description>
	/// The current state of the scaled value data from the collection is less than the logical minimum or is greater than the logical maximum.
	/// </description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_USAGE_NOT_FOUND</b></description>
	/// <description>
	/// The specified usage, usage page, or link collection cannot be found in any report supported by the specified top-level collection.
	/// </description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INCOMPATIBLE_REPORT_ID</b></description>
	/// <description>
	/// The specified value is not contained in the specified report, but is contained in another report supported by the specified top-level collection.
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Scaled values refer to the adjusted output of raw HID data, which are modified based on specific parameters such as sensitivity and
	/// the range of the device. This adjustment allows for more meaningful interpretation of the data in relation to the device's intended use.
	/// </para>
	/// <para>
	/// For further understanding of how HID reports are interpreted and the significance of scaled values, see <c>Interpreting HID Reports</c>.
	/// </para>
	/// <para>The caller-allocated buffers supplied at PreparsedData, UsageValue, and Report must be allocated from nonpaged pool.</para>
	/// <para>
	/// User-mode applications and kernel-mode drivers must use <b><c>HidP_GetUsageValueArray</c></b> to extract data for a <c>usage value array</c>.
	/// </para>
	/// <para>
	/// If the routine returns status HIDP_STATUS_BAD_LOG_PHY_VALUES, an application or driver can call <b><c>HidP_GetUsageValue</c></b> to
	/// extract the raw usage data.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getscaledusagevalue NTSTATUS
	// HidP_GetScaledUsageValue( [in] HIDP_REPORT_TYPE ReportType, [in] USAGE UsagePage, [in] USHORT LinkCollection, [in] USAGE Usage, [out]
	// PLONG UsageValue, [in] PHIDP_PREPARSED_DATA PreparsedData, [in] PCHAR Report, [in] ULONG ReportLength );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_GetScaledUsageValue")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_GetScaledUsageValue([In] HIDP_REPORT_TYPE ReportType, [In] USAGE UsagePage,
		HIDP_LINK_COLLECTION LinkCollection, [In] USAGE Usage, out int UsageValue, [In] PHIDP_PREPARSED_DATA PreparsedData,
		[In, SizeDef(nameof(ReportLength))] IntPtr Report, uint ReportLength);

	/// <summary>
	/// The <b>HidP_GetSpecificButtonCaps</b> routine returns a <c>button capability array</c> that describes all HID control buttons in a
	/// <c>top-level collection</c> that meet a specified selection criteria.
	/// </summary>
	/// <param name="ReportType">Specifies a <c>HIDP_REPORT_TYPE</c> enumerator value that identifies the report type.</param>
	/// <param name="UsagePage">
	/// Specifies a usage page as a search criteria. If <i>UsagePage</i> is nonzero, only buttons that specify this usage page are returned.
	/// </param>
	/// <param name="LinkCollection">
	/// Specifies a <c>link collection</c> as a search criteria. If <i>LinkCollection</i> is nonzero, only buttons that are part of this link
	/// collection are returned.
	/// </param>
	/// <param name="Usage">
	/// Specifies a <c>HID usage</c> as a search criteria. If <i>Usage</i> is nonzero, only buttons that specify this usage will be returned.
	/// </param>
	/// <param name="ButtonCaps">
	/// Pointer to a caller-allocated buffer in which the routine returns a button capability array for the specified report type.
	/// </param>
	/// <param name="ButtonCapsLength">
	/// Specifies the length on input, in array elements, of the buffer provided at <i>ButtonCaps</i>. On output, this parameter is set to
	/// the number of elements that the routine actually returned.
	/// </param>
	/// <param name="PreparsedData">Pointer to a <c>top-level collection's</c>  <c>preparsed data</c>.</param>
	/// <returns>
	/// <para><b>HidP_GetSpecificButtonCaps</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The routine successfully returned the capability data.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The preparsed data is not valid.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The required size of the <i>ButtonCaps</i> array is specified by the <b>Number</b><i>Xxx</i><b>ButtonCaps</b> members of a top-level
	/// collection's <c>HIDP_CAPS</c> structure.
	/// </para>
	/// <para>
	/// When calling <b>HidP_GetSpecificButtonCaps</b>, specifying zero for <i>UsagePage</i>, <i>Usage</i>, and <i>LinkCollection</i> is
	/// equivalent to calling <b>HidP_GetButtonCaps</b>.
	/// </para>
	/// <para>For more information about a collection's capability, see <c>Obtaining Collection Information</c>.</para>
	/// <para>See also <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getspecificbuttoncaps NTSTATUS
	// HidP_GetSpecificButtonCaps( [in] HIDP_REPORT_TYPE ReportType, [in] USAGE UsagePage, [in] USHORT LinkCollection, [in] USAGE Usage,
	// [out] PHIDP_BUTTON_CAPS ButtonCaps, [in, out] PUSHORT ButtonCapsLength, [in] PHIDP_PREPARSED_DATA PreparsedData );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_GetSpecificButtonCaps")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_GetSpecificButtonCaps([In] HIDP_REPORT_TYPE ReportType, [In] USAGE UsagePage,
		HIDP_LINK_COLLECTION LinkCollection, [In] USAGE Usage, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] HIDP_BUTTON_CAPS[] ButtonCaps,
		ref ushort ButtonCapsLength, [In] PHIDP_PREPARSED_DATA PreparsedData);

	/// <summary>
	/// The <b>HidP_GetSpecificValueCaps</b> routine returns a <c>value capability array</c> that describes all HID control values that meet
	/// a specified selection criteria.
	/// </summary>
	/// <param name="ReportType">Specifies a <c>HIDP_REPORT_TYPE</c> enumerator value that identifies the report type.</param>
	/// <param name="UsagePage">
	/// Specifies a usage page as a search criteria. If <i>UsagePage</i> is nonzero, only values that specify this usage page are returned.
	/// </param>
	/// <param name="LinkCollection">
	/// Specifies a <c>link collection</c> as a search criteria. If <i>LinkCollection</i> is nonzero, only values that are part of this link
	/// collection are returned.
	/// </param>
	/// <param name="Usage">
	/// Specifies a <c>HID usage</c> as a search criteria. If <i>Usage</i> is nonzero, only values that specify this usage will be returned.
	/// </param>
	/// <param name="ValueCaps">
	/// Pointer to a caller-allocated buffer in which the routine returns a value capability array for the specified report type.
	/// </param>
	/// <param name="ValueCapsLength">
	/// Specifies the length on input, in array elements, of the buffer provided at <i>ValueCaps</i>. On output, this parameter is set to the
	/// number of elements that routine actually returns.
	/// </param>
	/// <param name="PreparsedData">Pointer to a <c>top-level collection's</c>  <c>preparsed data</c>.</param>
	/// <returns>
	/// <para><b>HidP_GetSpecificValueCaps</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>NT Status Value</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description><b>0x00110000</b></description>
	/// <description>The routine successfully returned the capability data.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description><b>0xc0110001</b></description>
	/// <description>The preparsed data is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_USAGE_NOT_FOUND</b></description>
	/// <description><b>0xc0110004</b></description>
	/// <description>The usage does not exist in any report of the specified report type.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The required size of the <i>ValueCaps</i> buffer is specified by the <b>Number</b><i>Xxx</i><b>ValueCaps</b> members of a top-level
	/// collection's <c>HIDP_CAPS</c> structure.
	/// </para>
	/// <para>
	/// When calling <b>HidP_GetSpecificValueCaps</b>, specifying zero for <i>UsagePage</i>, <i>Usage</i>, and <i>LinkCollection</i> is
	/// equivalent to calling <b>HidP_GetValueCaps</b>.
	/// </para>
	/// <para>For more information about a collection's capability, see <c>Obtaining Collection Information</c>.</para>
	/// <para>See also <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getspecificvaluecaps NTSTATUS
	// HidP_GetSpecificValueCaps( [in] HIDP_REPORT_TYPE ReportType, [in] USAGE UsagePage, [in] USHORT LinkCollection, [in] USAGE Usage, [out]
	// PHIDP_VALUE_CAPS ValueCaps, [in, out] PUSHORT ValueCapsLength, [in] PHIDP_PREPARSED_DATA PreparsedData );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_GetSpecificValueCaps")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_GetSpecificValueCaps([In] HIDP_REPORT_TYPE ReportType, [In] USAGE UsagePage,
		HIDP_LINK_COLLECTION LinkCollection, [In] USAGE Usage, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] HIDP_VALUE_CAPS[] ValueCaps,
		ref ushort ValueCapsLength, [In] PHIDP_PREPARSED_DATA PreparsedData);

	/// <summary>
	/// The <b>HidP_GetUsages</b> routine returns a list of all the HID control button <c>usages</c> that are on a specified <c>usage
	/// page</c> and are set to ON in a HID report.
	/// </summary>
	/// <param name="ReportType">Specifies a <c>HIDP_REPORT_TYPE</c> enumerator value that identifies the report type.</param>
	/// <param name="UsagePage">
	/// Specifies the <c>usage page</c> of the button usages. The routine only returns information about buttons on this usage page.
	/// </param>
	/// <param name="LinkCollection">
	/// Specifies the <c>link collection</c> of the button usages. If LinkCollection is nonzero, the routine only returns information about
	/// the buttons that this link collection contains; otherwise, if LinkCollection is zero, the routine returns information about all the
	/// buttons in the <c>top-level collection</c> associated with PreparsedData.
	/// </param>
	/// <param name="UsageList">
	/// Pointer to a caller-allocated buffer that the routine uses to return the usages of all buttons that are set to ON and belong to the
	/// usage page specified by UsagePage.
	/// </param>
	/// <param name="UsageLength">
	/// Specifies, on input, the length, in array elements, of the UsageList buffer. Specifies, on output, the number of buttons that are set
	/// to ON on the specified usage page.
	/// </param>
	/// <param name="PreparsedData">Pointer to a top-level collection's <c>preparsed data</c>.</param>
	/// <param name="Report">Pointer to a report.</param>
	/// <param name="ReportLength">Specifies the length, in bytes, of the report located at Report.</param>
	/// <returns>
	/// <para><b>HidP_GetUsages</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The routine successfully returned all button usages set to ON.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_LENGTH</b></description>
	/// <description>The report length is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_TYPE</b></description>
	/// <description>The specified report type is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_BUFFER_TOO_SMALL</b></description>
	/// <description>
	/// The <c>UsageList</c> buffer is too small to hold all the usages that are currently set to ON on the specified usage page.
	/// </description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INCOMPATIBLE_REPORT_ID</b></description>
	/// <description>
	/// The collection contains buttons on the specified usage page in a report of the specified type, but there are no such usages in the
	/// specified report.
	/// </description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The preparsed data is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_USAGE_NOT_FOUND</b></description>
	/// <description>
	/// The collection does not contain any buttons on the specified usage page in any report of the specified report type.
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// User-mode applications and kernel-mode drivers call <c>HidP_MaxUsageListLength</c> to determine the maximum number of buttons that
	/// can be returned for specified report type. Alternatively, applications or drivers can call <b>HidP_GetUsages</b> and set
	/// (*UsageLength) to zero to return the required length in UsageLength. In other words, UsageLength should be a valid pointer that
	/// points to a ULONG value <b>0</b> to get the required length.
	/// </para>
	/// <para>
	/// Applications or drivers determine the required report length from the Xxx <b>ReportByteLength</b> members in a top-level collection's
	/// <c>HIDP_CAPS</c> structure.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getusages NTSTATUS HidP_GetUsages( [in]
	// HIDP_REPORT_TYPE ReportType, [in] USAGE UsagePage, [in] USHORT LinkCollection, [out] PUSAGE UsageList, [in, out] PULONG UsageLength,
	// [in] PHIDP_PREPARSED_DATA PreparsedData, [out] PCHAR Report, [in] ULONG ReportLength );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_GetUsages")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_GetUsages([In] HIDP_REPORT_TYPE ReportType, [In] USAGE UsagePage,
		HIDP_LINK_COLLECTION LinkCollection, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] USAGE[] UsageList, ref uint UsageLength,
		[In] PHIDP_PREPARSED_DATA PreparsedData, [Out, SizeDef(nameof(ReportLength))] IntPtr Report, uint ReportLength);

	/// <summary>
	/// The <b>HidP_GetUsagesEx</b> routine returns a list of the all the HID control button <c>usages</c> that are set to ON in a HID report.
	/// </summary>
	/// <param name="ReportType">Specifies a <c>HIDP_REPORT_TYPE</c> enumerator value that identifies the report type.</param>
	/// <param name="LinkCollection">
	/// Specifies the <c>link collection</c> of the button usages. If LinkCollection is nonzero, the routine only returns information about
	/// the buttons that this link collection contains; otherwise, if LinkCollection is zero, the routine returns information about all the
	/// buttons in the <c>top-level collection</c> associated with PreparsedData.
	/// </param>
	/// <param name="ButtonList">
	/// Pointer to a caller-allocated buffer that routine uses to return the usage and <c>usage page</c> identifiers for each button that is
	/// set to ON (1).
	/// </param>
	/// <param name="UsageLength">
	/// Specifies, on input, the length, in array elements, of the ButtonList buffer. Specifies, on output, the number usages that are
	/// currently set to ON in the specified report.
	/// </param>
	/// <param name="PreparsedData">Pointer to a top-level collection's <c>preparsed data</c>.</param>
	/// <param name="Report">Pointer to a report that contains button data.</param>
	/// <param name="ReportLength">Specifies the length, in bytes, of the report located at Report.</param>
	/// <returns>
	/// <para><b>HidP_GetUsagesEx</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The routine successfully returned all button usages set to ON.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_LENGTH</b></description>
	/// <description>The report length is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_TYPE</b></description>
	/// <description>The specified report type is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_BUFFER_TOO_SMALL</b></description>
	/// <description>The <c>UsageList</c> buffer is too small to hold all the usages currently set to ON in the specified report.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INCOMPATIBLE_REPORT_ID</b></description>
	/// <description>
	/// The collection contains buttons in a report of the specified type, but there are no such usages in the specified report.
	/// </description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The preparsed data is not valid.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// User-mode applications and kernel-mode drivers call <c>HidP_MaxUsageListLength</c> to determine the maximum number of buttons that be
	/// returned for specified report type. Alternatively, applications or drivers can call <b>HidP_GetUsagesEx</b> and set (*UsageLength) to
	/// zero to return the required length in UsageLength. In other words, UsageLength should be a valid pointer that points to a ULONG value
	/// <b>0</b> to get the required length.
	/// </para>
	/// <para>
	/// Applications or drivers determine the required report length from the Xxx <b>ReportByteLength</b> members in a top-level collection's
	/// <c>HIDP_CAPS</c> structure.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getusagesex NTSTATUS HidP_GetUsagesEx( [in]
	// HIDP_REPORT_TYPE ReportType, [in] USHORT LinkCollection, [in, out] PUSAGE_AND_PAGE ButtonList, [in, out] ULONG *UsageLength, [in]
	// PHIDP_PREPARSED_DATA PreparsedData, [in] PCHAR Report, [in] ULONG ReportLength );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_GetUsagesEx")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_GetUsagesEx([In] HIDP_REPORT_TYPE ReportType, HIDP_LINK_COLLECTION LinkCollection,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] USAGE_AND_PAGE[] ButtonList, ref uint UsageLength, [In] PHIDP_PREPARSED_DATA PreparsedData,
		[Out, SizeDef(nameof(ReportLength))] IntPtr Report, uint ReportLength);

	/// <summary>
	/// The <b>HidP_GetUsageValue</b> routine extracts the data associated with a HID control value that matches the selection criteria in a
	/// HID report.
	/// </summary>
	/// <param name="ReportType">Specifies a <c>HIDP_REPORT_TYPE</c> enumerator value that identifies the report type.</param>
	/// <param name="UsagePage">Specifies the value's <c>usage page</c>.</param>
	/// <param name="LinkCollection">
	/// Specifies the <c>link collection</c> that contains the value. If <i>LinkCollection</i> is nonzero, the routine only searches for the
	/// usage in this link collection; otherwise, if <i>LinkCollection</i> is zero, the routine searches for the usage in the <c>top-level
	/// collection</c> associated with <i>PreparsedData</i>.
	/// </param>
	/// <param name="Usage">Specifies the usage of the value.</param>
	/// <param name="UsageValue">Pointer to a buffer in which the routine returns the value data.</param>
	/// <param name="PreparsedData">Pointer to a top-level collection's <c>preparsed data</c>.</param>
	/// <param name="Report">Pointer to a report that contains values.</param>
	/// <param name="ReportLength">Specifies the length, in bytes, of the report located at <i>Report</i>.</param>
	/// <returns>
	/// <para><b>HidP_GetUsageValue</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The routine successfully returned the value data.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_LENGTH</b></description>
	/// <description>The report length is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_TYPE</b></description>
	/// <description>The specified report type is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INCOMPATIBLE_REPORT_ID</b></description>
	/// <description>
	/// The collection contains a value on the specified usage page in a report of the specified type, but there are no such usages in the
	/// specified report.
	/// </description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The preparsed data is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_USAGE_NOT_FOUND</b></description>
	/// <description>The collection does not contain a value on the specified usage page in any report of the specified report type.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>HidP_GetUsageValue</b> does not sign or scale the value. To extract a signed value, use <b>HidP_GetScaledUsageValue</b>. To
	/// manually assign the sign bit, the position of the sign bit can be determined from the information in a value's <c>HIDP_VALUE_CAPS</c> structure.
	/// </para>
	/// <para>
	/// <b>HidP_GetUsageValue</b> is designed to extract a usage value for a usage whose report count is 1. If the specified usage has a
	/// report count greater than 1, the usage is part of a <c>usage value array</c>. <b>HidP_GetUsageValue</b> only returns the first data
	/// item in a usage value array. To extract all data items in a usage value array, use <c>HidP_GetUsageValueArray</c>.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getusagevalue NTSTATUS HidP_GetUsageValue( [in]
	// HIDP_REPORT_TYPE ReportType, [in] USAGE UsagePage, [in] USHORT LinkCollection, [in] USAGE Usage, [out] PULONG UsageValue, [in]
	// PHIDP_PREPARSED_DATA PreparsedData, [in] PCHAR Report, [in] ULONG ReportLength );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_GetUsageValue")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_GetUsageValue([In] HIDP_REPORT_TYPE ReportType, [In] USAGE UsagePage,
		HIDP_LINK_COLLECTION LinkCollection, [In] USAGE Usage, out uint UsageValue, [In] PHIDP_PREPARSED_DATA PreparsedData,
		[In, SizeDef(nameof(ReportLength))] IntPtr Report, uint ReportLength);

	/// <summary>
	/// The <b>HidP_GetUsageValueArray</b> routine extracts the data associated with a HID control <c>usage value array</c> from a HID report.
	/// </summary>
	/// <param name="ReportType">Specifies a <c>HIDP_REPORT_TYPE</c> enumerator value that identifies the report type.</param>
	/// <param name="UsagePage">Specifies the <c>usage page</c> of the usage value array.</param>
	/// <param name="LinkCollection">
	/// Specifies the <c>link collection</c> that contains the usage value array. If LinkCollection is nonzero, the routine only searches for
	/// a usage value array in this link collection; otherwise, if LinkCollection is zero, the routine searches for a usage value array in
	/// the <c>top-level collection</c> associated with PreparsedData.
	/// </param>
	/// <param name="Usage">Specifies the usage of the usage value array.</param>
	/// <param name="UsageValue">
	/// Pointer to a caller-allocated buffer in which the routine returns the data associated with the usage value array.
	/// </param>
	/// <param name="UsageValueByteLength">Specifies the length, in bytes, of the buffer at UsageValue.</param>
	/// <param name="PreparsedData">Pointer to a top-level collection's <c>preparsed data</c>.</param>
	/// <param name="Report">Pointer to a report that contains values.</param>
	/// <param name="ReportLength">Specifies the length, in bytes, of the report located at Report.</param>
	/// <returns>
	/// <para><b>HidP_GetUsageValueArray</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The routine successfully returned the value's data.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_LENGTH</b></description>
	/// <description>The report length is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_TYPE</b></description>
	/// <description>The specified report type is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_NOT_VALUE_ARRAY</b></description>
	/// <description>The requested usage is not a usage value array.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_BUFFER_TOO_SMALL</b></description>
	/// <description>The <c>UsageValue</c> buffer is too small to hold the requested usage.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INCOMPATIBLE_REPORT_ID</b></description>
	/// <description>
	/// The collection contains a usage value array on the specified usage page in a report of the specified type, but there are no such
	/// usages in the specified report.
	/// </description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The preparsed data is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_USAGE_NOT_FOUND</b></description>
	/// <description>
	/// The collection does not contain a usage value array on the specified usage page in any report of the specified report type.
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The required size, in bytes, of UsageValueByteLength is determined by multiplying together the <b>BitSize</b> and <b>ReportCount</b>
	/// members of the usage value array's <c>HIDP_VALUE_CAPS</c> structure, and rounding the result up to the nearest byte.
	/// </para>
	/// <para>
	/// <b>HidP_GetUsageValueArray</b> sets the UsageValue buffer in little-endian order, beginning with the least significant bit of the
	/// usage's data. The data is not byte-aligned, and is shifted such that the least significant bit of the data is located at the first
	/// bit of the UsageValue buffer.
	/// </para>
	/// <para>
	/// <b>HidP_GetUsageValueArray</b> is designed to extract all the usage values for a usage whose report count is greater than 1. To
	/// extract a usage whose report count is equal to 1, use <b>HidP_GetUsageValue</b>.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getusagevaluearray NTSTATUS
	// HidP_GetUsageValueArray( [in] HIDP_REPORT_TYPE ReportType, [in] USAGE UsagePage, [in] USHORT LinkCollection, [in] USAGE Usage, [in,
	// out] PCHAR UsageValue, [in] USHORT UsageValueByteLength, [in] PHIDP_PREPARSED_DATA PreparsedData, [in] PCHAR Report, [in] ULONG
	// ReportLength );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_GetUsageValueArray")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_GetUsageValueArray([In] HIDP_REPORT_TYPE ReportType, [In] USAGE UsagePage,
		HIDP_LINK_COLLECTION LinkCollection, [In] USAGE Usage, [In, Out, SizeDef(nameof(UsageValueByteLength))] IntPtr UsageValue,
		ushort UsageValueByteLength, [In] PHIDP_PREPARSED_DATA PreparsedData, [In, SizeDef(nameof(ReportLength))] IntPtr Report, uint ReportLength);

	/// <summary>
	/// The <b>HidP_GetValueCaps</b> routine returns a <c>value capability array</c> that describes all the HID control values in a
	/// <c>top-level collection</c> for a specified type of HID report.
	/// </summary>
	/// <param name="ReportType">Specifies a <c>HIDP_REPORT_TYPE</c> enumerator value that identifies the report type.</param>
	/// <param name="ValueCaps">
	/// Pointer to a caller-allocated buffer in which the routine returns a value capability array for the specified report type.
	/// </param>
	/// <param name="ValueCapsLength">
	/// Specifies the length, on input, in array elements, of the <i>ValueCaps</i> buffer. On output, the routine sets <i>ValueCapsLength</i>
	/// to the number of elements that the it actually returns.
	/// </param>
	/// <param name="PreparsedData">Pointer to a top-level collection's <c>preparsed data</c>.</param>
	/// <returns>
	/// <para><b>HidP_GetValueCaps</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The routine successfully returned the capability data.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The preparsed data is not valid.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The correct length for <i>ValueCapsLength</i> is specified by the <b>Number</b><i>Xxx</i><b>ValueCaps</b> members of a top-level
	/// collection's <c>HIDP_CAPS</c> structure.
	/// </para>
	/// <para>For more information about a collection's capability, see <c>Obtaining Collection Information</c>.</para>
	/// <para>See also <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getvaluecaps NTSTATUS HidP_GetValueCaps( [in]
	// HIDP_REPORT_TYPE ReportType, [out] PHIDP_VALUE_CAPS ValueCaps, [in, out] PUSHORT ValueCapsLength, [in] PHIDP_PREPARSED_DATA
	// PreparsedData );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_GetValueCaps")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_GetValueCaps([In] HIDP_REPORT_TYPE ReportType, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] HIDP_VALUE_CAPS[] ValueCaps,
		ref ushort ValueCapsLength, [In] PHIDP_PREPARSED_DATA PreparsedData);

	/// <summary>The <b>HidP_GetVersion</b> function is a header-only implementation that returns the HID API version.</summary>
	/// <param name="Version">The version of the HID API.</param>
	/// <returns>
	/// <b>HidP_GetVersion</b> returns STATUS_SUCCESS if the call was successful. Otherwise, it returns an <c>NTSTATUS</c> error code.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Call <b>HidP_GetVersion</b> at runtime before using <c>HidP_GetButtonArray</c> or <c>HidP_SetButtonArray</c>. The
	/// <b>HidP_GetButtonArray</b> and <b>HidP_SetButtonArray</b> functions are only available on operating systems where
	/// <b>HidP_GetVersion</b> returns a value of two or greater. Version two of the API corresponds to Windows 11.
	/// </para>
	/// <para><b>HidP_GetVersion</b> is safe to call on down-level systems because it is a header-only implementation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_getversion NTSTATUS HidP_GetVersion( [out] ULONG
	// *Version );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_GetVersion")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_GetVersion(out uint Version);

	/// <summary>The <b>HidP_InitializeReportForID</b> routine initializes a HID report.</summary>
	/// <param name="ReportType">Specifies a <c>HIDP_REPORT_TYPE</c> enumerator that indicates the type of HID report located at <i>Report</i>.</param>
	/// <param name="ReportID">Specifies a report ID.</param>
	/// <param name="PreparsedData">
	/// Pointer to the <c>preparsed data</c> of the <c>top-level collection</c> associated with the HID report located at <i>Report</i>.
	/// </param>
	/// <param name="Report">Pointer to the caller-allocated buffer containing the HID report that <b>HidP_InitializeReportForID</b> initializes.</param>
	/// <param name="ReportLength">
	/// Specifies the size, in bytes, of the HID report located at <i>Report</i>. <i>ReportLength</i> must be equal to the collection's
	/// report length for the specified report type, as specified by the <i>Xxx</i><b>ReportByteLength</b> members of a collection's
	/// <c>HIDP_CAPS</c> structure.
	/// </param>
	/// <returns>
	/// <para><b>HidP_InitializeReportForID</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The report was successfully initialized.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The preparsed data is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_LENGTH</b></description>
	/// <description>The specified length of the report is not equal to the collection's report length for the specified report type.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_TYPE</b></description>
	/// <description>The report type is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_REPORT_DOES_NOT_EXIST</b></description>
	/// <description>The specified report ID is not valid.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Initializing a HID report sets all control data to zero or a control's <i>null value</i>, as defined by the USB HID standard.
	/// (Sending or receiving a null value indicates that the current value of a control should not be modified.)
	/// </para>
	/// <para><b>HidP_InitializeReportForID</b> does the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Sets to zero the bitfields of all buttons and values without null values.</description>
	/// </item>
	/// <item>
	/// <description>Sets the bitfield of all controls with null values to their corresponding null value.</description>
	/// </item>
	/// </list>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_initializereportforid NTSTATUS
	// HidP_InitializeReportForID( [in] HIDP_REPORT_TYPE ReportType, [in] UCHAR ReportID, [in] PHIDP_PREPARSED_DATA PreparsedData, [out]
	// PCHAR Report, [in] ULONG ReportLength );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_InitializeReportForID")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_InitializeReportForID([In] HIDP_REPORT_TYPE ReportType, byte ReportID,
		[In] PHIDP_PREPARSED_DATA PreparsedData, [In, SizeDef(nameof(ReportLength))] IntPtr Report, uint ReportLength);

	/// <summary>
	/// The <b>HidP_MaxDataListLength</b> routine returns the maximum number of <c>HIDP_DATA</c> structures that <c>HidP_GetData</c> can
	/// return for a specified type of HID report and a specified <c>top-level collection</c>.
	/// </summary>
	/// <param name="ReportType">Specifies a <c>HIDP_REPORT_TYPE</c> enumerator value that indicates the report type.</param>
	/// <param name="PreparsedData">Pointer to a top-level collection's <c>preparsed data</c>.</param>
	/// <returns>
	/// If successful, <b>HidP_MaxDataListLength</b> returns the maximum number of <c>HIDP_DATA</c> structures that <c>HidP_GetData</c> might
	/// return for a specified type of HID report and a specified <c>top-level collection</c>. Otherwise, the routine returns zero, which
	/// indicates that either the report type or the preparsed data is not valid.
	/// </returns>
	/// <remarks>
	/// <para>
	/// User-mode applications or kernel-mode drivers call <b>HidP_MaxDataListLength</b> to determine the maximum number of <c>HIDP_DATA</c>
	/// structures that <b>HidP_GetData</b> can return.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_maxdatalistlength ULONG HidP_MaxDataListLength(
	// [in] HIDP_REPORT_TYPE ReportType, [in] PHIDP_PREPARSED_DATA PreparsedData );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_MaxDataListLength")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern uint HidP_MaxDataListLength([In] HIDP_REPORT_TYPE ReportType, [In] PHIDP_PREPARSED_DATA PreparsedData);

	/// <summary>
	/// The <b>HidP_MaxUsageListLength</b> routine returns the maximum number of <c>HID usages</c> that <c>HidP_GetUsages</c> can return for
	/// a specified type of HID report and a specified <c>top-level collection</c>.
	/// </summary>
	/// <param name="ReportType">Specifies a <c>HIDP_REPORT_TYPE</c> enumerator value that indicates the report type.</param>
	/// <param name="UsagePage">
	/// Specifies a <c>usage page</c> as a search criteria. If <i>UsagePage</i> is zero, the routine returns the number of all the buttons in
	/// the collection.
	/// </param>
	/// <param name="PreparsedData">Pointer to a top-level collection's <c>preparsed data</c>.</param>
	/// <returns>
	/// If successful, <b>HidP_MaxUsageListLength</b> returns the maximum number of <c>HID usages</c> that <c>HidP_GetUsages</c> can return
	/// for a specified type of HID report and a specified <c>top-level collection</c>. If the specified preparsed data or report type is not
	/// valid, the routine returns zero.
	/// </returns>
	/// <remarks>For more information, see <c>HID Collections</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_maxusagelistlength ULONG HidP_MaxUsageListLength(
	// [in] HIDP_REPORT_TYPE ReportType, [in] USAGE UsagePage, [in] PHIDP_PREPARSED_DATA PreparsedData );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_MaxUsageListLength")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern uint HidP_MaxUsageListLength([In] HIDP_REPORT_TYPE ReportType, [In] USAGE UsagePage, [In] PHIDP_PREPARSED_DATA PreparsedData);

	/// <summary>The <b>HidP_SetButtonArray</b> function sets the state of buttons via an array of <c>HIDP_BUTTON_ARRAY_DATA</c> structures.</summary>
	/// <param name="ReportType">A value of either <b>HidP_Output</b> or <b>HidP_Feature</b> from the <c>HIDP_REPORT_TYPE</c> enum.</param>
	/// <param name="UsagePage">The usage page to which the given usage refers.</param>
	/// <param name="LinkCollection">
	/// (Optional) This value can be used to differentiate between two fields that may have the same UsagePage and Usage but exist in
	/// different collections. If the value is HIDP_LINK_COLLECTION_UNSPECIFIED, the first found button array matching the UsagePage and
	/// Usage will be returned, regardless of location. If the value is HIDP_LINK_COLLECTION_ROOT, the first found button array, in the root
	/// collection, matching the UsagePage and Usage will be returned.
	/// </param>
	/// <param name="Usage">The usage whose button array <b>HidP_SetButtonArray</b> will set.</param>
	/// <param name="ButtonData">The buffer with the values to set into the button array.</param>
	/// <param name="ButtonDataLength">Number of elements in the ButtonData buffer.</param>
	/// <param name="PreparsedData">The parsed data returned from <c>HIDCLASS</c>.</param>
	/// <param name="Report">The report packet. The first byte must be the ReportId.</param>
	/// <param name="ReportLength">Length of the given report packet in bytes.</param>
	/// <returns>
	/// <para><b>HidP_SetButtonArray</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>HIDP_STATUS_SUCCESS</description>
	/// <description>The button array in the report packet was set successfully</description>
	/// </item>
	/// <item>
	/// <description>HIDP_STATUS_INVALID_REPORT_TYPE</description>
	/// <description><c>ReportType</c> is not valid</description>
	/// </item>
	/// <item>
	/// <description>HIDP_STATUS_INVALID_PREPARSED_DATA</description>
	/// <description><c>PreparsedData</c> is not valid</description>
	/// </item>
	/// <item>
	/// <description>HIDP_STATUS_INVALID_REPORT_LENGTH</description>
	/// <description>
	/// The length of the report packet is not equal to the length specified in the <b>HIDP_CAPS</b> structure for the given <c>ReportType</c>
	/// </description>
	/// </item>
	/// <item>
	/// <description>HIDP_STATUS_REPORT_DOES_NOT_EXIST</description>
	/// <description>There are no reports on this device for the given <c>ReportType</c></description>
	/// </item>
	/// <item>
	/// <description>HIDP_STATUS_NOT_BUTTON_ARRAY</description>
	/// <description>The control specified is not a button array</description>
	/// </item>
	/// <item>
	/// <description>HIDP_STATUS_INCOMPATIBLE_REPORT_ID</description>
	/// <description>
	/// The specified usage page, usage, and link collection exists in a report with a different report ID than the report being passed in
	/// </description>
	/// </item>
	/// <item>
	/// <description>HIDP_STATUS_USAGE_NOT_FOUND</description>
	/// <description>The usage page, usage, and link collection combination does not exist in any reports for this <c>ReportType</c></description>
	/// </item>
	/// <item>
	/// <description>HIDP_STATUS_DATA_INDEX_OUT_OF_RANGE</description>
	/// <description>
	/// The <c>ArrayIndex</c> for one of the supplied <b>HIDP_BUTTON_ARRAY_DATA</b> structures is outside the valid range for this button array
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>HidP_SetButtonArray</b> sets the state of buttons for the first button array found, within the specified LinkCollection, with the
	/// supplied Usage for the specified Report.
	/// </para>
	/// <para>
	/// The caller should use <c>HidP_GetVersion</c> to determine if this function is available. <b>HidP_SetButtonArray</b> is only available
	/// if <b>HidP_GetVersion</b> returns a value of two or greater. Version two of the API corresponds to Windows 11.
	/// </para>
	/// <para>
	/// A button array occurs when the last usage in the sequence of usages describing a main item, must be repeated because there are less
	/// usages defined than the ReportCount declared for the given main item. In this case, a single <c>HIDP_BUTTON_CAPS</c> is allocated for
	/// that usage and the ReportCount of the <b>HIDP_BUTTON_CAPS</b> is set to reflect the number of fields the usage refers.
	/// </para>
	/// <para>
	/// A <b>HIDP_BUTTON_CAPS</b> that describes a button array, will always have ReportCount greater than one. If ReportCount equals one,
	/// then it is not a button array and cannot be used with <b>HidP_SetButtonArray</b>. For more information, see <c>HidP_SetUsages</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_setbuttonarray NTSTATUS HidP_SetButtonArray(
	// HIDP_REPORT_TYPE ReportType, USAGE UsagePage, USHORT LinkCollection, USAGE Usage, PHIDP_BUTTON_ARRAY_DATA ButtonData, USHORT
	// ButtonDataLength, PHIDP_PREPARSED_DATA PreparsedData, PCHAR Report, ULONG ReportLength );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_SetButtonArray")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_SetButtonArray(HIDP_REPORT_TYPE ReportType, USAGE UsagePage, HIDP_LINK_COLLECTION LinkCollection,
		USAGE Usage, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] HIDP_BUTTON_ARRAY_DATA[] ButtonData, ushort ButtonDataLength,
		[In] PHIDP_PREPARSED_DATA PreparsedData, [In, SizeDef(nameof(ReportLength))] IntPtr Report, uint ReportLength);

	/// <summary>The <b>HidP_SetButtons</b> macro is a mnemonic alias for the <c><b>HidP_SetUsages</b></c> function.</summary>
	/// <param name="Rty">Specifies a <c><b>HIDP_REPORT_TYPE</b></c> enumerator value that indicates the type of report located at Rep.</param>
	/// <param name="Up">Specifies the <c>usage page</c> for the usages specified by ULi.</param>
	/// <param name="Lco">
	/// Specifies the <c>link collection</c> that contains the usages. If Lco is nonzero, the routine only sets the usages, if they exist, in
	/// this link collection. If Lco is zero, the routine sets the first usage for each specified usage in the <c>top-level collection</c>
	/// associated with Ppd.
	/// </param>
	/// <param name="ULi">Pointer to the array of usages.</param>
	/// <param name="ULe">Specifies, on input, the number of usages in ULi. See the Remarks section for information about the output value.</param>
	/// <param name="Ppd">Pointer to the <c>pre-parsed data</c> of the top-level collection associated with the report located at Rep.</param>
	/// <param name="Rep">Pointer to a report.</param>
	/// <param name="Rle">
	/// Specifies the size, in bytes, of the report located at Rep, which must be equal to the report length for the specified report type
	/// that <c><b>HidP_GetCaps</b></c> returns in a collection's <c><b>HIDP_CAPS</b></c> structure.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>See <c><b>HidP_SetUsages</b></c> for return value details.</remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_setbuttons #define HidP_SetButtons(Rty, Up, Lco,
	// ULi, ULe, Ppd, Rep, Rle) \ HidP_SetUsages(Rty, Up, Lco, ULi, ULe, Ppd, Rep, Rle)
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_SetButtons")]
	public static NTStatus HidP_SetButtons([In] HIDP_REPORT_TYPE Rty, [In] USAGE Up,
		HIDP_LINK_COLLECTION Lco, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] USAGE[] ULi,
		ref uint ULe, [In] PHIDP_PREPARSED_DATA Ppd, [In, SizeDef(nameof(Rle))] IntPtr Rep,
		uint Rle) => HidP_SetUsages(Rty, Up, Lco, ULi, ref ULe, Ppd, Rep, Rle);

	/// <summary>The <b>HidP_SetData</b> routine sets a specified set of HID control button and value usages in a HID report.</summary>
	/// <param name="ReportType">Specifies a <c>HIDP_REPORT_TYPE</c> enumerator value that indicates the type of HID report located at <i>Report</i>.</param>
	/// <param name="DataList">
	/// Pointer to a caller-allocated array of <c>HIDP_DATA</c> structures that specify which buttons and usage values to set.
	/// </param>
	/// <param name="DataLength">
	/// Specifies, on input, the number of members in the <i>DataList</i> array. For information about the output value, see the Remarks section.
	/// </param>
	/// <param name="PreparsedData">Pointer to a top-level's <c>preparsed data</c>.</param>
	/// <param name="Report">Pointer to a HID report.</param>
	/// <param name="ReportLength">
	/// Specifies the size, in bytes, of the HID report located at <i>Report</i>, which must be equal to the report length for the specified
	/// report type that <c>HidP_GetCaps</c> returns in a collection's <c>HIDP_CAPS</c> structure.
	/// </param>
	/// <returns>
	/// <para><b>HidP_SetData</b> returns HIDP_STATUS_SUCCESS if it successfully sets all the control data specified by <i>DataList</i>.</para>
	/// <para><b>HidP_SetData</b> returns one of the following status values if one of the input parameters is not valid:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The preparsed data specified by <i>PreparsedData</i> is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_LENGTH</b></description>
	/// <description>
	/// The size, in bytes, of the HID report is not equal to the length specified in the collection's <c>HIDP_CAPS</c> structure for the
	/// specified report type.
	/// </description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_TYPE</b></description>
	/// <description><i>ReportType</i> is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_REPORT_DOES_NOT_EXIST</b></description>
	/// <description>The collection does not contain a report of the specified type.</description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>HidP_SetData returns one of the following error values if one of the specified button or usage values could not be set:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_BUFFER_TOO_SMALL</b></description>
	/// <description>A button in an array was not set to ON (1) because all the array fields are already used to index other buttons.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_BUTTON_NOT_PRESSED</b></description>
	/// <description>A DataList member specifies to set a button OFF (zero), but the button is already set to OFF.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_DATA_INDEX_NOT_FOUND</b></description>
	/// <description>The data index of a DataList member is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INCOMPATIBLE_REPORT_ID</b></description>
	/// <description>A button or usage value is contained in a report, but it is not in the specified report.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_IS_VALUE_ARRAY</b></description>
	/// <description>A data index specifies a <c>usage value array</c>.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Except for usage value arrays, a user-mode application or kernel-mode driver can use <b>HidP_SetData</b> to set buttons and usage
	/// values in a report. To set a usage value array, an application or driver must use <c>HidP_SetUsageValueArray</c>.
	/// </para>
	/// <para><b>HidP_SetData</b> sets the output value of <i>DataLength</i> as follows:</para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_setdata NTSTATUS HidP_SetData( [in]
	// HIDP_REPORT_TYPE ReportType, [in, out] PHIDP_DATA DataList, [in, out] PULONG DataLength, [in] PHIDP_PREPARSED_DATA PreparsedData, [in]
	// PCHAR Report, [in] ULONG ReportLength );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_SetData")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_SetData([In] HIDP_REPORT_TYPE ReportType,
		[In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] HIDP_DATA[] DataList, ref uint DataLength,
		[In] PHIDP_PREPARSED_DATA PreparsedData, [In, SizeDef(nameof(ReportLength))] IntPtr Report, uint ReportLength);

	/// <summary>
	/// The <b>HidP_SetScaledUsageValue</b> routine converts a signed and scaled physical number to a <c>HID usage's</c> logical value, and
	/// sets the usage value in a specified HID report.
	/// </summary>
	/// <param name="ReportType">
	/// Specifies a <b><c>HIDP_REPORT_TYPE</c></b> enumerator value that indicates the type of HID report located at Report.
	/// </param>
	/// <param name="UsagePage">Specifies the <c>usage page</c> of a usage.</param>
	/// <param name="LinkCollection">
	/// Specifies the <c>link collection</c> that contains the usage. If LinkCollection is nonzero, the routine only sets the usage, if one
	/// exists, in this link collection. If LinkCollection is zero, the routine sets the first usage it finds in the <c>top-level
	/// collection</c> associated with PreparsedData.
	/// </param>
	/// <param name="Usage">Specifies the usage.</param>
	/// <param name="UsageValue">Specifies the signed and scaled physical number, which the routine converts to the usage's logical value.</param>
	/// <param name="PreparsedData">Pointer to a top-level's <c>preparsed data</c>.</param>
	/// <param name="Report">Pointer to a HID report.</param>
	/// <param name="ReportLength">
	/// Specifies the size, in bytes, of the HID report located at Report, which must be equal to the report length for the specified report
	/// type that <b><c>HidP_GetCaps</c></b> returns in a collection's <b><c>HIDP_CAPS</c></b> structure.
	/// </param>
	/// <returns>
	/// <para><b>HidP_SetScaledUsageValue</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The routine successfully set the usage value.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_BAD_LOG_PHY_VALUES</b></description>
	/// <description>The usage has an illegal logical or physical range that prevents scaling.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_VALUE_OUT_OF_RANGE</b></description>
	/// <description>The specified physical value is out-of-range and the usage does not have null value.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_LENGTH</b></description>
	/// <description>The report length is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_TYPE</b></description>
	/// <description>The specified report type is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INCOMPATIBLE_REPORT_ID</b></description>
	/// <description>The usage does not exist in the specified report, but it does exist in a different report of the specified type.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The preparsed data is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_USAGE_NOT_FOUND</b></description>
	/// <description>The usage does not exist in any report of the specified report type.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_NULL</b></description>
	/// <description>The specified physical value is out-of-range, the usage has a null value, and the routine set the null value.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Scaled values refer to the adjusted output of raw HID data, which are modified based on specific parameters such as sensitivity and
	/// the range of the device. This adjustment allows for more meaningful interpretation of the data in relation to the device's intended use.
	/// </para>
	/// <para>
	/// For further understanding of how HID reports are interpreted and the significance of scaled values, see <c>Interpreting HID Reports</c>.
	/// </para>
	/// <para><b>HidP_SetScaledUsageValue</b> sets the sign bit.</para>
	/// <para>
	/// If the routine returns HIDP_STATUS_INCOMPATIBLE_REPORT_ID, the specified report does contain the usage. However, a user-mode
	/// application or kernel-mode driver can set the usage in a zero-initialized report. See <c>Initializing HID Reports</c>.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_setscaledusagevalue NTSTATUS
	// HidP_SetScaledUsageValue( [in] HIDP_REPORT_TYPE ReportType, [in] USAGE UsagePage, [in] USHORT LinkCollection, [in] USAGE Usage, [in]
	// LONG UsageValue, [in] PHIDP_PREPARSED_DATA PreparsedData, [in, out] PCHAR Report, [in] ULONG ReportLength );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_SetScaledUsageValue")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_SetScaledUsageValue([In] HIDP_REPORT_TYPE ReportType, [In] USAGE UsagePage,
		HIDP_LINK_COLLECTION LinkCollection, [In] USAGE Usage, int UsageValue, [In] PHIDP_PREPARSED_DATA PreparsedData,
		[In, Out, SizeDef(nameof(ReportLength))] IntPtr Report, uint ReportLength);

	/// <summary>The <b>HidP_SetUsages</b> routine sets specified HID control buttons ON (1) in a HID report.</summary>
	/// <param name="ReportType">Specifies a <c>HIDP_REPORT_TYPE</c> enumerator value that indicates the type of report located at <i>Report</i>.</param>
	/// <param name="UsagePage">Specifies the <c>usage page</c> for the usages specified by <i>UsageList</i>.</param>
	/// <param name="LinkCollection">
	/// Specifies the <c>link collection</c> that contains the usages. If <i>LinkCollection</i> is nonzero, the routine only sets the usages,
	/// if they exist, in this link collection. If <i>LinkCollection</i> is zero, the routine sets the first usage for each specified usage
	/// in the <c>top-level collection</c> associated with <i>PreparsedData</i>.
	/// </param>
	/// <param name="UsageList">Pointer to the array of usages.</param>
	/// <param name="UsageLength">
	/// Specifies, on input, the number of usages in <i>UsageList</i>. See the Remarks section for information about the output value.
	/// </param>
	/// <param name="PreparsedData">
	/// Pointer to the <c>preparsed data</c> of the top-level collection associated with the report located at <i>Report</i>.
	/// </param>
	/// <param name="Report">Pointer to a report.</param>
	/// <param name="ReportLength">
	/// Specifies the size, in bytes, of the report located at <i>Report</i>, which must be equal to the report length for the specified
	/// report type that <c>HidP_GetCaps</c> returns in a collection's <c>HIDP_CAPS</c> structure.
	/// </param>
	/// <returns>
	/// <para><b>HidP_SetUsages</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The routine successfully set the usage value.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_BUFFER_TOO_SMALL</b></description>
	/// <description>A usage in a button array cannot be set because the array is already fully set.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_LENGTH</b></description>
	/// <description>The report length is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_TYPE</b></description>
	/// <description>The specified report type is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INCOMPATIBLE_REPORT_ID</b></description>
	/// <description>A usage does not exist in the specified report, but it does exist in a different report of the specified type.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The preparsed data is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_USAGE_NOT_FOUND</b></description>
	/// <description>A usage does not exist in any report of the specified report type.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If <b>HidP_SetUsages</b> cannot set a usage in <i>UsageList</i>, the routine sets <i>UsageLength</i> to the index of the usage that
	/// could not be set, and returns a status value that indicates the error.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_setusages NTSTATUS HidP_SetUsages( [in]
	// HIDP_REPORT_TYPE ReportType, [in] USAGE UsagePage, [in] USHORT LinkCollection, [in, out] PUSAGE UsageList, [in, out] PULONG
	// UsageLength, [in] PHIDP_PREPARSED_DATA PreparsedData, [in] PCHAR Report, [in] ULONG ReportLength );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_SetUsages")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_SetUsages([In] HIDP_REPORT_TYPE ReportType, [In] USAGE UsagePage,
		HIDP_LINK_COLLECTION LinkCollection, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] USAGE[] UsageList,
		ref uint UsageLength, [In] PHIDP_PREPARSED_DATA PreparsedData, [In, SizeDef(nameof(ReportLength))] IntPtr Report,
		uint ReportLength);

	/// <summary>The <b>HidP_SetUsageValue</b> routine sets a HID control value in a specified HID report.</summary>
	/// <param name="ReportType">Specifies a <c>HIDP_REPORT_TYPE</c> enumerator value that indicates the type of HID report located at <i>Report</i>.</param>
	/// <param name="UsagePage">Specifies the <c>usage page</c> of a usage.</param>
	/// <param name="LinkCollection">
	/// Specifies the <c>link collection</c> that contains the usage. If <i>LinkCollection</i> is nonzero, the routine only sets the usage,
	/// if one exists, in this link collection. If <i>LinkCollection</i> is zero, the routine sets the first usage it finds in the
	/// <c>top-level collection</c> associated with <i>PreparsedData</i>.
	/// </param>
	/// <param name="Usage">Specifies the usage.</param>
	/// <param name="UsageValue">Specifies the usage value.</param>
	/// <param name="PreparsedData">Pointer to a top-level's <c>preparsed data</c>.</param>
	/// <param name="Report">Pointer to a HID report.</param>
	/// <param name="ReportLength">
	/// Specifies the size, in bytes, of the HID report located at <i>Report</i>, which must be equal to the report length for the specified
	/// report type that <c>HidP_GetCaps</c> returns in a collection's <c>HIDP_CAPS</c> structure.
	/// </param>
	/// <returns>
	/// <para><b>HidP_SetUsageValue</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The routine successfully set the usage value.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INCOMPATIBLE_REPORT_ID</b></description>
	/// <description>The usage does not exist in the specified report, but it does exist in a different report of the specified type.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The preparsed data is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_REPORT_DOES_NOT_EXIST</b></description>
	/// <description>There are no reports of the specified type.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_USAGE_NOT_FOUND</b></description>
	/// <description>The usage does not exist in any report of the specified report type.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_LENGTH</b></description>
	/// <description>The report length is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_TYPE</b></description>
	/// <description>The specified report type is not valid.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>HidP_SetUsageValue</b> routine does not sign the value. A user-mode application or kernel-mode driver must either sign the value,
	/// at the position provided in the <c>HIDP_VALUE_CAPS</c> structure for this value, or call <c>HidP_SetScaledUsageValue</c>.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_setusagevalue NTSTATUS HidP_SetUsageValue( [in]
	// HIDP_REPORT_TYPE ReportType, [in] USAGE UsagePage, [in] USHORT LinkCollection, [in] USAGE Usage, [in] ULONG UsageValue, [in]
	// PHIDP_PREPARSED_DATA PreparsedData, [in, out] PCHAR Report, [in] ULONG ReportLength );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_SetUsageValue")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_SetUsageValue([In] HIDP_REPORT_TYPE ReportType, [In] USAGE UsagePage,
		HIDP_LINK_COLLECTION LinkCollection, [In] USAGE Usage, uint UsageValue, [In] PHIDP_PREPARSED_DATA PreparsedData,
		[In, Out, SizeDef(nameof(ReportLength))] IntPtr Report, uint ReportLength);

	/// <summary>The <b>HidP_SetUsageValueArray</b> routine sets a HID control  <c>usage value array</c> in a specified HID report.</summary>
	/// <param name="ReportType">Specifies a <c>HIDP_REPORT_TYPE</c> enumerator value that indicates the type of HID report located at <i>Report</i>.</param>
	/// <param name="UsagePage">Specifies the <c>usage page</c> of a usage.</param>
	/// <param name="LinkCollection">
	/// Specifies the <c>link collection</c> that contains the usage. If <i>LinkCollection</i> is nonzero, the routine only sets the usage,
	/// if one exists, in this link collection. If <i>LinkCollection</i> is zero, the routine sets the first usage it finds in the
	/// <c>top-level collection</c> associated with <i>PreparsedData</i>.
	/// </param>
	/// <param name="Usage">Specifies the usage.</param>
	/// <param name="UsageValue">Pointer to a caller-allocated buffer that contains the data associated with the usage value array.</param>
	/// <param name="UsageValueByteLength">Specifies the length, in bytes, of the <i>UsageValue</i> buffer.</param>
	/// <param name="PreparsedData">Pointer to a top-level's <c>preparsed data</c>.</param>
	/// <param name="Report">Pointer to a HID report.</param>
	/// <param name="ReportLength">
	/// Specifies the size, in bytes, of the HID report located at <i>Report</i>, which must be equal to the report length for the specified
	/// report type that <c>HidP_GetCaps</c> returns in a collection's <c>HIDP_CAPS</c> structure.
	/// </param>
	/// <returns>
	/// <para><b>HidP_SetUsageValueArray</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The routine successfully set the usage value.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_LENGTH</b></description>
	/// <description>The report length is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_TYPE</b></description>
	/// <description>The specified report type is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_BUFFER_TOO_SMALL</b></description>
	/// <description>The size, in bytes, of the <i>UsageValue</i> buffer is too small.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INCOMPATIBLE_REPORT_ID</b></description>
	/// <description>The usage does not exist in the specified report, but it does exist in a different report of the specified type.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_NOT_VALUE_ARRAY</b></description>
	/// <description>The specified usage is not a usage value array.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The preparsed data is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_REPORT_DOES_NOT_EXIST</b></description>
	/// <description>There are no reports of the specified type.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_NOT_IMPLEMENTED</b></description>
	/// <description>The report size of data fields specified for the usage value array is not a multiple of eight bits.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_USAGE_NOT_FOUND</b></description>
	/// <description>The usage does not exist in any report of the specified report type.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The required size, in bytes, of the <i>UsageValue</i> buffer is determined by multiplying together the <b>BitSize</b> and
	/// <b>ReportCount</b> members of the usage value array's <c>HIDP_VALUE_CAPS</c> structure, and rounding the result up to the nearest byte.
	/// </para>
	/// <para><b>HidP_SetUsageValueArray</b> only supports usage value arrays where each data field of the array is a multiple of eight bits.</para>
	/// <para>The caller must set the <i>UsageValue</i> buffer exactly as it should occur in the report.</para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_setusagevaluearray NTSTATUS
	// HidP_SetUsageValueArray( [in] HIDP_REPORT_TYPE ReportType, [in] USAGE UsagePage, [in] USHORT LinkCollection, [in] USAGE Usage, [in]
	// PCHAR UsageValue, [in] USHORT UsageValueByteLength, [in] PHIDP_PREPARSED_DATA PreparsedData, [in, out] PCHAR Report, [in] ULONG
	// ReportLength );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_SetUsageValueArray")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_SetUsageValueArray([In] HIDP_REPORT_TYPE ReportType, [In] USAGE UsagePage,
		HIDP_LINK_COLLECTION LinkCollection, [In] USAGE Usage, [In, SizeDef(nameof(UsageValueByteLength))] IntPtr UsageValue,
		ushort UsageValueByteLength, [In] PHIDP_PREPARSED_DATA PreparsedData, [In, Out, SizeDef(nameof(ReportLength))] IntPtr Report, uint ReportLength);

	/// <summary>
	/// The <b>HidP_TranslateUsagesToI8042ScanCodes</b> routine maps a list of <c>HID usages</c> on the HID_USAGE_PAGE_KEYBOARD usage page to
	/// their respective PS/2 scan codes (Scan Code Set 1).
	/// </summary>
	/// <param name="ChangedUsageList">
	/// Pointer to a list of keyboard (button) usages. The translate usages routine interprets a zero as a delimiter that ends the usage list.
	/// </param>
	/// <param name="UsageListLength">Specifies the maximum possible number of usages in the changed usage list.</param>
	/// <param name="KeyAction">Identifies the key direction for the specified change usage list.
	/// <c>typedefenum_HIDP_KEYBOARD_DIRECTION {HidP_Keyboard_Break,HidP_Keyboard_Make&#xA;}HIDP_KEYBOARD_DIRECTION;</c>
	/// <para>HidP_Keyboard_Break</para>
	/// <para>
	/// Specifies a <i>break</i> direction (key up). The changed usage list contains the usages set to OFF that were previously set to ON
	/// (which corresponds to the keys that were previously down, but are now up).
	/// </para>
	/// <para>HidPKeyboard_Make</para>
	/// <para>
	/// Specifies a <i>make</i> direction (key down). The changed usage list contains the usages set to ON that were previously set to OFF
	/// (which corresponds to the keys that were previously up, but now are down).
	/// </para>
	/// </param>
	/// <param name="ModifierState">
	/// Pointer to a _HIDP_KEYBOARD_MODIFIER_STATE structure that the caller maintains for use by the translate usages routine. The modifier
	/// state structure identifies the state of the keyboard modifier keys.
	/// <c>typedefstruct_HIDP_KEYBOARD_MODIFIER_STATE {union {struct {ULONGLeftControl:1;ULONGLeftShift:1;ULONGLeftAlt:1;ULONGLeftGUI:1;ULONGRightControl:1;ULONGRightShift:1;ULONGRightAlt:1;ULONGRigthGUI:1;ULONGCapsLock:1;ULONGScollLock:1;ULONGNumLock:1;ULONGReserved:21;&#xA;      };ULONGul;&#xA;};</c>
	/// <para>Each member of the modifier state structure identifies whether the corresponding usage is set to ON (1) or OFF (zero).</para>
	/// <para>See the Remarks section for more information about how a modifier state structure is used with the translate usage routine.</para>
	/// </param>
	/// <param name="InsertCodesProcedure">
	/// Pointer to a caller-supplied PHIDP_INSERT_SCANCODES-typed callback routine that the translate usage routine uses to return the mapped
	/// scan codes to the caller of the translate usage routine.
	/// <c>typedef BOOLEAN (*PHIDP_INSERT_SCANCODES)(INPVOIDContext,INPCHARNewScanCodes,INULONGLength&#xA;    );</c>
	/// <para>Context</para>
	/// <para>
	/// Pointer to the context of the caller of the translate usage routine. The translate usage routine passes the <i>InsertCodesContext</i>
	/// pointer to the <i>InsertCodesProcedure</i> routine.
	/// </para>
	/// <para>NewScanCodes</para>
	/// <para>Pointer to the first byte of a scan code that the translate usage routine returns to the caller of the translate usage routine.</para>
	/// <para>Length</para>
	/// <para>Specifies the length, in bytes, of the scan code. A scan code cannot exceed four bytes.</para>
	/// </param>
	/// <param name="InsertCodesContext">
	/// Pointer to a caller-defined context that the translate usage routine passes to the <i>InsertCodesProcedure</i> routine.
	/// </param>
	/// <returns>
	/// <para><b>HidP_TranslateUsagesToI8042ScanCodes</b> returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_SUCCESS</b></description>
	/// <description>The translate usage routine successfully mapped all the valid usages in the changed usage list.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_I8042_TRANS_UNKNOWN</b></description>
	/// <description>A usage in the changed usage list mapped to an invalid keyboard scan code.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>HidP_TranslateUsagesToI8042ScanCodes</b> sequentially maps the keyboard button usages in the changed usage list in the order in
	/// which they occur in the list, beginning with the value at <i>ChangedUsageList.</i> After the translate usage routine successfully
	/// maps a usage, it uses the caller's <i>InsertCodesProcedure</i> routine to return the corresponding scan code to the caller. The
	/// translate usage routine continues to map the usages in the list until one of the following occurs: a usage value in the list is zero;
	/// it maps the number of usages that is specified by <i>UsageListLength</i>; a usage maps to an invalid keyboard scan code.
	/// </para>
	/// <para>
	/// <b>HidP_TranslateUsagesToI8042ScanCodes</b> is designed primarily to be used in a processing loop that repeatedly determines the
	/// current usage list (usages that are currently set to ON), compares them with a previous usage list (usages that were previously set
	/// to ON), and maps the difference between the current and previous usage lists to make scan codes and break scan codes. The following
	/// operations illustrate how to use the translate usages routine.
	/// </para>
	/// <para>Prior to beginning a processing loop, the processing code typically allocates and initializes the following data:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>A previous usage list, current usage list, break usage list, and a make usage list.
	/// <para>
	/// Each list is a zero-initialized array of usages. To ensure that the processing code maps all the usages that can change between
	/// consecutive HID input reports, the processing code must set the number of elements in each list to the maximum number of usages that
	/// <c>HidP_GetUsages</c> can return for the HID_USAGE_PAGE_KEYBOARD usage page. This number is obtained using <c>HidP_MaxUsageListLength</c>.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>A zero-initialized _HIDP_KEYBOARD_MODIFIER_STATE structure for use by the translate usages routine.
	/// <para>
	/// In the processing loop, the code must maintain this structure for use by the translate usages routine. The processing code can read
	/// the state of the modifier keys, but the code must not modify the structure. The translate usage routine uses this structure to
	/// maintain internal information about the state of the modifier keys.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// After initializing the required structures, each iteration of the processing loop typically includes the following sequence of operations:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <description>
	/// Call <b>HidP_GetUsages</b> to obtain the current usage list of usages that are set to ON. Set the <i>UsagePage</i> input parameter of
	/// the get usages routine to HID_USAGE_PAGE_KEYBOARD.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// Call <b>HidP_UsageListDifference</b> to compare the current usage list of usages to a previous usage list. The usage list difference
	/// routine returns a break usage list and a make usage list.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// Call the translate usage routine, setting <i>ChangedUsageList</i> to the break usage list, <i>KeyAction</i> to HidP_KeyboardBreak,
	/// and <i>ModifierState</i> to the structure that the processing code maintains for the translate usages routine. The translate usages
	/// routine uses the <i>InsertCodesProcedure</i> s callback routine to return the break scan codes to the processing loop.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// Call the translate usage routine, setting <i>ChangedUsageList</i> to the make usage list, <i>KeyAction</i> to HidP_KeyboardMake, and
	/// <i>ModifierState</i> to the structure that the processing code maintains for the translate usages routine. The translate usages
	/// routine uses the <i>InsertCodesProcedure</i> s callback routine to return the make scan codes to the processing loop.
	/// </description>
	/// </item>
	/// <item>
	/// <description>Update the previous usage list to the current usage list.</description>
	/// </item>
	/// </list>
	/// <para>
	/// For information about the mapping between HID usages and PS/2 keyboard scan codes, see the <c>key support and scan codes</c> website.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_translateusagestoi8042scancodes NTSTATUS
	// HidP_TranslateUsagesToI8042ScanCodes( [in] PUSAGE ChangedUsageList, [in] ULONG UsageListLength, [in] HIDP_KEYBOARD_DIRECTION
	// KeyAction, [in, out] PHIDP_KEYBOARD_MODIFIER_STATE ModifierState, [in] PHIDP_INSERT_SCANCODES InsertCodesProcedure, [in, optional]
	// PVOID InsertCodesContext );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_TranslateUsagesToI8042ScanCodes")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_TranslateUsagesToI8042ScanCodes([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] USAGE[] ChangedUsageList,
		uint UsageListLength, [In] HIDP_KEYBOARD_DIRECTION KeyAction, ref HIDP_KEYBOARD_MODIFIER_STATE ModifierState,
		[In] PHIDP_INSERT_SCANCODES InsertCodesProcedure, [In, Optional] IntPtr InsertCodesContext);

	/// <summary>The <b>HidP_UnsetButtons</b> macro is a mnemonic alias for the <c><b>HidP_UnsetUsages</b></c> function.</summary>
	/// <param name="Rty">Specifies a <c><b>HIDP_REPORT_TYPE</b></c> enumerator value that indicates the type of report located at Rep.</param>
	/// <param name="Up">Specifies the usage page of the usages specified by ULi.</param>
	/// <param name="Lco">
	/// Specifies the <c>link collection</c> that contains the usages. If Lco is nonzero, the routine only sets the usages, if they exist, in
	/// this link collection. If Lco is zero, the routine sets the first usage for each usage it finds in the <c>top-level collection</c>
	/// associated with Ppd.
	/// </param>
	/// <param name="ULi">Pointer to the array of usages to set to OFF.</param>
	/// <param name="ULe">Specifies, on input, the number of usages in ULi. See the Remarks section for information about the output value.</param>
	/// <param name="Ppd">Pointer to the <c>pre-parsed data</c> of the top-level collection associated with the report located at Rep.</param>
	/// <param name="Rep">Pointer to a report.</param>
	/// <param name="Rle">
	/// Specifies the size, in bytes, of the report located at Rep, which must be equal to the report length for the specified report type
	/// that <c><b>HidP_GetCaps</b></c> returns in a collection's <c><b>HIDP_CAPS</b></c> structure.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>See <c><b>HidP_UnsetUsages</b></c> for return value details.</remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_unsetbuttons #define HidP_UnsetButtons(Rty, Up,
	// Lco, ULi, ULe, Ppd, Rep, Rle) \ HidP_UnsetUsages(Rty, Up, Lco, ULi, ULe, Ppd, Rep, Rle)
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_UnsetButtons")]
	public static NTStatus HidP_UnsetButtons([In] HIDP_REPORT_TYPE Rty, [In] USAGE Up,
		[In, Optional] HIDP_LINK_COLLECTION Lco, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] USAGE[] ULi,
		ref uint ULe, [In] PHIDP_PREPARSED_DATA Ppd, [In, SizeDef(nameof(Rle))] IntPtr Rep, uint Rle) =>
		HidP_UnsetUsages(Rty, Up, Lco, ULi, ref ULe, Ppd, Rep, Rle);

	/// <summary>The <b>HidP_UnsetUsages</b> routine sets specified HID control button <c>usages</c> OFF (zero) in a HID report.</summary>
	/// <param name="ReportType">Specifies a <c>HIDP_REPORT_TYPE</c> enumerator value that indicates the type of report located at <i>Report</i>.</param>
	/// <param name="UsagePage">Specifies the usage page of the usages specified by <i>UsageList</i>.</param>
	/// <param name="LinkCollection">
	/// Specifies the <c>link collection</c> that contains the usages. If <i>LinkCollection</i> is nonzero, the routine only sets the usages,
	/// if they exist, in this link collection. If <i>LinkCollection</i> is zero, the routine sets the first usage for each usage it finds in
	/// the <c>top-level collection</c> associated with <i>PreparsedData</i>.
	/// </param>
	/// <param name="UsageList">Pointer to the array of usages to set to OFF.</param>
	/// <param name="UsageLength">
	/// Specifies, on input, the number of usages in <i>UsageList</i>. See the Remarks section for information about the output value.
	/// </param>
	/// <param name="PreparsedData">
	/// Pointer to the <c>preparsed data</c> of the top-level collection associated with the report located at <i>Report</i>.
	/// </param>
	/// <param name="Report">Pointer to a report.</param>
	/// <param name="ReportLength">
	/// Specifies the size, in bytes, of the report located at <i>Report</i>, which must be equal to the report length for the specified
	/// report type that <c>HidP_GetCaps</c> returns in a collection's <c>HIDP_CAPS</c> structure.
	/// </param>
	/// <returns>
	/// <para><b>HidP_UnsetUsages</b> returns HIDP_STATUS_SUCCESS if it successfully sets to OFF all the usages in <i>UsageList</i>.</para>
	/// <para><b>HidP_UnsetUsages</b> returns one of the following status values if one of the input parameters is not valid:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_PREPARSED_DATA</b></description>
	/// <description>The preparsed data specified by <i>PreparsedData</i> is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_LENGTH</b></description>
	/// <description>The report length is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INVALID_REPORT_TYPE</b></description>
	/// <description>The report type is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_REPORT_DOES_NOT_EXIST</b></description>
	/// <description>The collection does not contain a report of the specified type.</description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para><b>HidP_UnsetUsages</b> returns one of the following status values if it was not able to set to OFF one of the usages in <i>UsageList</i>:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>HIDP_STATUS_BUTTON_NOT_PRESSED</b></description>
	/// <description>A usage is already set to OFF.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_INCOMPATIBLE_REPORT_ID</b></description>
	/// <description>A usage is not contained in the specified report, but is contained in another report of the specified type.</description>
	/// </item>
	/// <item>
	/// <description><b>HIDP_STATUS_USAGE_NOT_FOUND</b></description>
	/// <description>The routine did not find a usage in any report of the specified type.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><b>HidP_UnsetUsages</b> sets <i>UsageLength</i> as follows:</para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_unsetusages NTSTATUS HidP_UnsetUsages( [in]
	// HIDP_REPORT_TYPE ReportType, [in] USAGE UsagePage, [in, optional] USHORT LinkCollection, [in, out] PUSAGE UsageList, [in, out] PULONG
	// UsageLength, [in] PHIDP_PREPARSED_DATA PreparsedData, [in] PCHAR Report, [in] ULONG ReportLength );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_UnsetUsages")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_UnsetUsages([In] HIDP_REPORT_TYPE ReportType, [In] USAGE UsagePage,
			[In, Optional] HIDP_LINK_COLLECTION LinkCollection, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] USAGE[] UsageList,
			ref uint UsageLength, [In] PHIDP_PREPARSED_DATA PreparsedData, [In, SizeDef(nameof(ReportLength))] IntPtr Report, uint ReportLength);

	/// <summary>
	/// The <b>HidP_UsageAndPageListDifference</b> function returns the difference between two lists of usages, as might be returned from
	/// <c><b>HidP_GetUsages</b></c>. In other words, it returns a list of usages that are in the current list but not the previous list as
	/// well as a list of usages that are in the previous list but not the current list.
	/// </summary>
	/// <param name="PreviousUsageList">The list of usages before.</param>
	/// <param name="CurrentUsageList">The list of usages now.</param>
	/// <param name="BreakUsageList"><paramref name="PreviousUsageList"/> minus <paramref name="CurrentUsageList"/></param>
	/// <param name="MakeUsageList"><paramref name="CurrentUsageList"/> minus <paramref name="PreviousUsageList"/></param>
	/// <param name="UsageListLength">
	/// Represents the length of the usage lists in array elements. If comparing two lists with a differing number of array elements, this
	/// value is the size of the larger of the two lists. Any zero found with a list indicates an early termination of the list and any
	/// usages found after the first zero are ignored.
	/// </param>
	/// <returns>
	/// <b>HidP_UsageAndPageListDifference</b> returns HIDP_STATUS_SUCCESS if the call was successful. Otherwise, it returns an
	/// <c><b>NTSTATUS</b></c> error code.
	/// </returns>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_usageandpagelistdifference NTSTATUS
	// HidP_UsageAndPageListDifference( [in, reads] PUSAGE_AND_PAGE PreviousUsageList, [in, reads] PUSAGE_AND_PAGE CurrentUsageList, [out,
	// writes] PUSAGE_AND_PAGE BreakUsageList, [out, writes] PUSAGE_AND_PAGE MakeUsageList, [in] ULONG UsageListLength );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_UsageAndPageListDifference")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_UsageAndPageListDifference([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] USAGE_AND_PAGE[] PreviousUsageList,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] USAGE_AND_PAGE[] CurrentUsageList,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] USAGE_AND_PAGE[] BreakUsageList,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] USAGE_AND_PAGE[] MakeUsageList, uint UsageListLength);

	/// <summary>The <b>HidP_UsageListDifference</b> routine returns the differences between two arrays of <c>HID usages</c>.</summary>
	/// <param name="PreviousUsageList">Pointer to a list of usages that the routine compares with the list of usages in <i>CurrentUsageList</i>.</param>
	/// <param name="CurrentUsageList">Pointer to a list of usages that the routine compares with the list of usages in <i>PreviousUsageList</i>.</param>
	/// <param name="BreakUsageList">
	/// Pointer to a caller-allocated buffer that, on return, contains a list of the usages that are in <i>PreviousUsageList</i>, but not in <i>CurrentUsageList</i>.
	/// </param>
	/// <param name="MakeUsageList">
	/// Pointer to a caller-allocated buffer that, on return, contains a list of the usages that are in <i>CurrentUsageList</i>, but not in <i>PreviousUsageList</i>.
	/// </param>
	/// <param name="UsageListLength">Specifies the length, in array elements, of the buffers provided at <i>CurrentUsageList</i> and <i>PreviousUsageList</i>.</param>
	/// <returns><b>HidP_UsageListDifference</b> returns HIDP_STATUS_SUCCESS.</returns>
	/// <remarks>
	/// <para>
	/// A user-mode application or kernel-mode driver can use this routine to compare two usage lists, for example, to determine the change
	/// in button state between two usage lists returned by two <c>HidP_GetButtons</c> calls.
	/// </para>
	/// <para>
	/// If the input usage lists have different lengths, an application or driver should set <i>UsageListLength</i> to the length of the
	/// larger list.
	/// </para>
	/// <para>
	/// The routine interprets a zero usage in an input usage list as a delimiter that ends the list. Any usages after a zero in a list are
	/// not processed. Unused usages in an output list are set to zero.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/nf-hidpi-hidp_usagelistdifference NTSTATUS
	// HidP_UsageListDifference( [in] PUSAGE PreviousUsageList, [in] PUSAGE CurrentUsageList, [out] PUSAGE BreakUsageList, [out] PUSAGE
	// MakeUsageList, [in] ULONG UsageListLength );
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_UsageListDifference")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_UsageListDifference([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] USAGE[] PreviousUsageList,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] USAGE[] CurrentUsageList,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] USAGE[] BreakUsageList,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] USAGE[] MakeUsageList, uint UsageListLength);

	/// <summary>The <b>HIDP_BUTTON_ARRAY_DATA</b> structure is used to get or set data for single button in a button array.</summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/ns-hidpi-hidp_button_array_data typedef struct
	// _HIDP_BUTTON_ARRAY_DATA { USHORT ArrayIndex; BOOLEAN On; } HIDP_BUTTON_ARRAY_DATA, *PHIDP_BUTTON_ARRAY_DATA;
	[PInvokeData("hidpi.h", MSDNShortId = "NS:hidpi._HIDP_BUTTON_ARRAY_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HIDP_BUTTON_ARRAY_DATA
	{
		/// <summary>
		/// The position of the button within the zero-based button array. The value will always be less than
		/// <c>HIDP_BUTTON_CAPS.ReportCount</c>. This is not an index of a button array within the parsed data.
		/// </summary>
		public ushort ArrayIndex;

		/// <summary><b>TRUE</b> when the button at the ArrayIndex within the button array is on. <b>FALSE</b> when the button is off.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool On;
	}

	/// <summary>
	/// The <b>HIDP_BUTTON_CAPS</b> structure contains information about the capability of a HID control button <c>usage</c> (or a set of
	/// buttons associated with a <c>usage range</c>).
	/// </summary>
	/// <remarks>
	/// <para>
	/// Clients obtain a <c>button capability array</c> by calling <c>HidP_GetButtonCaps</c> or <c>HidP_GetSpecificButtonCaps</c>. These
	/// routines return an array of HIDP_BUTTON_CAPS structures in a caller-allocated buffer. The required buffer length is specified in the
	/// <c>HIDP_CAPS</c> structure returned by <c>HidP_GetCaps</c>.
	/// </para>
	/// <para>For information about the capabilities of HID control values, see <c>Collection Capability</c> and <c>Value Capability Arrays</c>.</para>
	/// <para>
	/// When a report descriptor declares an input, output, or feature main item with fewer usage declarations than the ReportCount, then the
	/// last usage applies to all remaining unspecified count in that main item. As an example, you might have data that required many fields
	/// to describe, possibly buffered bytes. In this case, only one value cap structure is allocated for these associated fields, all with
	/// the same usage, and ReportCount reflects the number of fields involved. Normally ReportCount is one. To access all of the fields in
	/// such a value structure would require using <c>HidP_GetUsageValueArray</c> and <c>HidP_SetUsageValueArray</c>. The
	/// <c>HidP_GetUsageValue</c> and <c>HidP_SetScaledUsageValue</c> functions will also work. However, these functions only work with the
	/// first field of the structure.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/ns-hidpi-_hidp_button_caps typedef struct _HIDP_BUTTON_CAPS {
	// USAGE UsagePage; UCHAR ReportID; BOOLEAN IsAlias; USHORT BitField; USHORT LinkCollection; USAGE LinkUsage; USAGE LinkUsagePage;
	// BOOLEAN IsRange; BOOLEAN IsStringRange; BOOLEAN IsDesignatorRange; BOOLEAN IsAbsolute; USHORT ReportCount; USHORT Reserved2; ULONG
	// Reserved[9]; union { struct { USAGE UsageMin; USAGE UsageMax; USHORT StringMin; USHORT StringMax; USHORT DesignatorMin; USHORT
	// DesignatorMax; USHORT DataIndexMin; USHORT DataIndexMax; } Range; struct { USAGE Usage; USAGE Reserved1; USHORT StringIndex; USHORT
	// Reserved2; USHORT DesignatorIndex; USHORT Reserved3; USHORT DataIndex; USHORT Reserved4; } NotRange; }; } HIDP_BUTTON_CAPS, *PHIDP_BUTTON_CAPS;
	[PInvokeData("hidpi.h", MSDNShortId = "NS:hidpi._HIDP_BUTTON_CAPS")]
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct HIDP_BUTTON_CAPS
	{
		/// <summary>Specifies the <c>usage page</c> for a usage or usage range.</summary>
		[FieldOffset(0)]
		public USAGE UsagePage;

		/// <summary>Specifies the report ID of the HID report that contains the usage or usage range.</summary>
		[FieldOffset(2)]
		public byte ReportID;

		/// <summary>
		/// Indicates, if <b>TRUE</b>, that a button has a set of <c>aliased usages</c>. Otherwise, if <b>IsAlias</b> is <b>FALSE</b>, the
		/// button has only one usage.
		/// </summary>
		[FieldOffset(3)]
		[MarshalAs(UnmanagedType.U1)]
		public bool IsAlias;

		/// <summary>Contains the data fields (one or two bytes) associated with an input, output, or feature main item.</summary>
		[FieldOffset(4)]
		public ushort BitField;

		/// <summary>
		/// Specifies the index of the <c>link collection</c> in a <c>top-level collection's</c>  <c>link collection array</c> that contains
		/// the usage or usage range. If <b>LinkCollection</b> is zero, the usage or usage range is contained in the top-level collection.
		/// </summary>
		[FieldOffset(6)]
		public HIDP_LINK_COLLECTION LinkCollection;

		/// <summary>
		/// Specifies the usage of the link collection that contains the usage or usage range. If <b>LinkCollection</b> is zero,
		/// <b>LinkUsage</b> specifies the usage of the top-level collection.
		/// </summary>
		[FieldOffset(8)]
		public USAGE LinkUsage;

		/// <summary>
		/// Specifies the usage page of the link collection that contains the usage or usage range. If <b>LinkCollection</b> is zero,
		/// <b>LinkUsagePage</b> specifies the usage page of the top-level collection.
		/// </summary>
		[FieldOffset(10)]
		public USAGE LinkUsagePage;

		/// <summary>
		/// Specifies, if <b>TRUE</b>, that the structure describes a usage range. Otherwise, if <b>IsRange</b> is <b>FALSE</b>, the
		/// structure describes a single usage.
		/// </summary>
		[FieldOffset(12)]
		[MarshalAs(UnmanagedType.U1)]
		public bool IsRange;

		/// <summary>
		/// Specifies, if <b>TRUE</b>, that the usage or usage range has a set of string descriptors. Otherwise, if <b>IsStringRange</b> is
		/// <b>FALSE</b>, the usage or usage range has zero or one string descriptor.
		/// </summary>
		[FieldOffset(13)]
		[MarshalAs(UnmanagedType.U1)]
		public bool IsStringRange;

		/// <summary>
		/// Specifies, if <b>TRUE</b>, that the usage or usage range has a set of designators. Otherwise, if <b>IsDesignatorRange</b> is
		/// <b>FALSE</b>, the usage or usage range has zero or one designator.
		/// </summary>
		[FieldOffset(14)]
		[MarshalAs(UnmanagedType.U1)]
		public bool IsDesignatorRange;

		/// <summary>
		/// Specifies, if <b>TRUE</b>, that the button usage or usage range provides absolute data. Otherwise, if <b>IsAbsolute</b> is
		/// <b>FALSE</b>, the button data is the change in state from the previous value.
		/// </summary>
		[FieldOffset(15)]
		[MarshalAs(UnmanagedType.U1)]
		public bool IsAbsolute;

		/// <summary>
		/// HID defined report count. Available starting with API version 2.0. Call the <c>HIDP_GetVersion</c> function to get the API version.
		/// </summary>
		[FieldOffset(16)]
		public ushort ReportCount;

		/// <summary>Reserved for internal system use.</summary>
		[FieldOffset(18)]
		public ushort Reserved2;

		/// <summary>Reserved for internal system use.</summary>
		[FieldOffset(20)]
		public unsafe fixed uint Reserved[9];

		/// <summary>
		/// Specifies, if <b>IsRange</b> is <b>TRUE</b>, information about a usage range. Otherwise, if <b>IsRange</b> is <b>FALSE</b>,
		/// <b>NotRange</b> contains information about a single usage.
		/// </summary>
		[FieldOffset(56)]
		public RangeUnion Range;

		/// <summary>
		/// Specifies, if <b>IsRange</b> is <b>FALSE</b>, information about a single usage. Otherwise, if <b>IsRange</b> is <b>TRUE</b>,
		/// <b>Range</b> contains information about a usage range.
		/// </summary>
		[FieldOffset(56)]
		public NotRangeUnion NotRange;

		/// <summary>
		/// Specifies, if <b>IsRange</b> is <b>TRUE</b>, information about a usage range. Otherwise, if <b>IsRange</b> is <b>FALSE</b>,
		/// <b>NotRange</b> contains information about a single usage.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct RangeUnion
		{
			/// <summary>Indicates the inclusive lower bound of usage range whose inclusive upper bound is specified by <b>Range.UsageMax</b>.</summary>
			public USAGE UsageMin;

			/// <summary>Indicates the inclusive upper bound of a usage range whose inclusive lower bound is indicated by <b>Range.UsageMin</b>.</summary>
			public USAGE UsageMax;

			/// <summary>
			/// Indicates the inclusive lower bound of a range of string descriptors (specified by string minimum and string maximum
			/// items) whose inclusive upper bound is indicated by <b>Range.StringMax</b>.
			/// </summary>
			public ushort StringMin;

			/// <summary>
			/// Indicates the inclusive upper bound of a range of string descriptors (specified by string minimum and string maximum
			/// items) whose inclusive lower bound is indicated by <b>Range.StringMin</b>.
			/// </summary>
			public ushort StringMax;

			/// <summary>
			/// Indicates the inclusive lower bound of a range of designators (specified by designator minimum and designator maximum
			/// items) whose inclusive lower bound is indicated by <b>Range.DesignatorMax</b>.
			/// </summary>
			public ushort DesignatorMin;

			/// <summary>
			/// Indicates the inclusive upper bound of a range of designators (specified by designator minimum and designator maximum
			/// items) whose inclusive lower bound is indicated by <b>Range.DesignatorMin</b>.
			/// </summary>
			public ushort DesignatorMax;

			/// <summary>
			/// Indicates the inclusive lower bound of a sequential range of <c>data indices</c> that correspond, one-to-one and in the
			/// same order, to the usages specified by the usage range <b>Range.UsageMin</b> to <b>Range.UsageMax</b>.
			/// </summary>
			public ushort DataIndexMin;

			/// <summary>
			/// Indicates the inclusive upper bound of a sequential range of data indices that correspond, one-to-one and in the same
			/// order, to the usages specified by the usage range <b>Range.UsageMin</b> to <b>Range.UsageMax</b>.
			/// </summary>
			public ushort DataIndexMax;
		}

		/// <summary>
		/// Specifies, if <b>IsRange</b> is <b>FALSE</b>, information about a single usage. Otherwise, if <b>IsRange</b> is <b>TRUE</b>,
		/// <b>Range</b> contains information about a usage range.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct NotRangeUnion
		{
			/// <summary>Indicates a <c>usage ID</c>.</summary>
			public USAGE Usage;

			/// <summary>Reserved for internal system use.</summary>
			public USAGE Reserved1;

			/// <summary>Indicates a string descriptor ID for the usage specified by <b>NotRange.Usage</b>.</summary>
			public ushort StringIndex;

			/// <summary>Reserved for internal system use.</summary>
			public ushort Reserved2;

			/// <summary>Indicates a designator ID for the usage specified by <b>NotRange.Usage</b>.</summary>
			public ushort DesignatorIndex;

			/// <summary>Reserved for internal system use.</summary>
			public ushort Reserved3;

			/// <summary>Indicates the data index of the usage specified by <b>NotRange.Usage</b>.</summary>
			public ushort DataIndex;

			/// <summary>Reserved for internal system use.</summary>
			public ushort Reserved4;
		}
	}

	/// <summary>The HIDP_CAPS structure contains information about a top-level <c>collection's capability</c>.</summary>
	/// <remarks>
	/// Callers of the <c>HIDClass support routines</c> use the information provided in this structure when a called routine requires, as
	/// input, the size of a report type, the number of link collection nodes, the number of control capabilities, or the number of data indices.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/ns-hidpi-_hidp_caps typedef struct _HIDP_CAPS { USAGE Usage;
	// USAGE UsagePage; USHORT InputReportByteLength; USHORT OutputReportByteLength; USHORT FeatureReportByteLength; USHORT Reserved[17];
	// USHORT NumberLinkCollectionNodes; USHORT NumberInputButtonCaps; USHORT NumberInputValueCaps; USHORT NumberInputDataIndices; USHORT
	// NumberOutputButtonCaps; USHORT NumberOutputValueCaps; USHORT NumberOutputDataIndices; USHORT NumberFeatureButtonCaps; USHORT
	// NumberFeatureValueCaps; USHORT NumberFeatureDataIndices; } HIDP_CAPS, *PHIDP_CAPS;
	[PInvokeData("hidpi.h", MSDNShortId = "NS:hidpi._HIDP_CAPS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HIDP_CAPS
	{
		/// <summary>Specifies a <c>top-level collection's</c>  <c>usage ID</c>.</summary>
		public USAGE Usage;

		/// <summary>Specifies the top-level collection's <c>usage page</c>.</summary>
		public USAGE UsagePage;

		/// <summary>
		/// Specifies the maximum size, in bytes, of all the input reports. Includes the report ID, which is prepended to the report data. If
		/// report ID is not used, the ID value is zero.
		/// </summary>
		public ushort InputReportByteLength;

		/// <summary>
		/// Specifies the maximum size, in bytes, of all the output reports. Includes the report ID, which is prepended to the report data.
		/// If report ID is not used, the ID value is zero.
		/// </summary>
		public ushort OutputReportByteLength;

		/// <summary>
		/// Specifies the maximum length, in bytes, of all the feature reports. Includes the report ID, which is prepended to the report
		/// data. If report ID is not used, the ID value is zero.
		/// </summary>
		public ushort FeatureReportByteLength;

		/// <summary>Reserved for internal system use.</summary>
		public unsafe fixed ushort Reserved[17];

		/// <summary>
		/// Specifies the number of <c>HIDP_LINK_COLLECTION_NODE</c> structures that are returned for this top-level collection by <c>HidP_GetLinkCollectionNodes</c>.
		/// </summary>
		public ushort NumberLinkCollectionNodes;

		/// <summary>Specifies the number of input <c>HIDP_BUTTON_CAPS</c> structures that <c>HidP_GetButtonCaps</c> returns.</summary>
		public ushort NumberInputButtonCaps;

		/// <summary>Specifies the number of input <c>HIDP_VALUE_CAPS</c> structures that <c>HidP_GetValueCaps</c> returns.</summary>
		public ushort NumberInputValueCaps;

		/// <summary>Specifies the number of <c>data indices</c> assigned to buttons and values in all input reports.</summary>
		public ushort NumberInputDataIndices;

		/// <summary>Specifies the number of output HIDP_BUTTON_CAPS structures that <b>HidP_GetButtonCaps</b> returns.</summary>
		public ushort NumberOutputButtonCaps;

		/// <summary>Specifies the number of output HIDP_VALUE_CAPS structures that <b>HidP_GetValueCaps</b> returns.</summary>
		public ushort NumberOutputValueCaps;

		/// <summary>Specifies the number of data indices assigned to buttons and values in all output reports.</summary>
		public ushort NumberOutputDataIndices;

		/// <summary>Specifies the total number of feature HIDP_BUTTONS_CAPS structures that <b>HidP_GetButtonCaps</b> returns.</summary>
		public ushort NumberFeatureButtonCaps;

		/// <summary>Specifies the total number of feature HIDP_VALUE_CAPS structures that <b>HidP_GetValueCaps</b> returns.</summary>
		public ushort NumberFeatureValueCaps;

		/// <summary>Specifies the number of data indices assigned to buttons and values in all feature reports.</summary>
		public ushort NumberFeatureDataIndices;
	}

	/// <summary>The HIDP_DATA structure contains information about a HID control's <c>data index</c> and value in a HID report.</summary>
	/// <remarks>See <c>Extracting and Setting Control Data by Data Indices</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/ns-hidpi-_hidp_data typedef struct _HIDP_DATA { USHORT DataIndex;
	// USHORT Reserved; union { ULONG RawValue; BOOLEAN On; }; } HIDP_DATA, *PHIDP_DATA;
	[PInvokeData("hidpi.h", MSDNShortId = "NS:hidpi._HIDP_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HIDP_DATA
	{
		/// <summary>Specifies the data index of a control.</summary>
		public ushort DataIndex;

		/// <summary>Reserved for internal system use only.</summary>
		public ushort Reserved;

		/// <summary>Contains the binary data extracted from a report if the control is a value.</summary>
		public uint RawValue;

		/// <summary>
		/// Specifies, if <b>TRUE</b> and the control is a button, that the button is set to ON (1). Otherwise, if <b>On</b> is <b>FALSE</b>
		/// and the control is a button, the button is set to OFF (zero).
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool On;
	}

	/// <summary>
	/// The HIDP_EXTENDED_ATTRIBUTES structure contains information about the global items specified for a HID control that the HID parser
	/// did not recognize.
	/// </summary>
	/// <remarks>The HIDP_EXTENDED_ATTRIBUTES structure is designed to be used with <b>HidP_GetExtendedAttributes</b>.</remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/ns-hidpi-_hidp_extended_attributes typedef struct
	// _HIDP_EXTENDED_ATTRIBUTES { UCHAR NumGlobalUnknowns; UCHAR Reserved[3]; PHIDP_UNKNOWN_TOKEN GlobalUnknowns; ULONG Data[1]; }
	// HIDP_EXTENDED_ATTRIBUTES, *PHIDP_EXTENDED_ATTRIBUTES;
	[PInvokeData("hidpi.h", MSDNShortId = "NS:hidpi._HIDP_EXTENDED_ATTRIBUTES")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<HIDP_EXTENDED_ATTRIBUTES>), nameof(NumGlobalUnknowns))]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HIDP_EXTENDED_ATTRIBUTES
	{
		/// <summary>Specifies the number of <c>HIDP_UNKNOWN_TOKEN</c> structures in the list specified by <b>Data</b>.</summary>
		public byte NumGlobalUnknowns;

		/// <summary>Reserved for internal system use only.</summary>
		public unsafe fixed byte Reserved[3];

		/// <summary>Reserved for internal system use only.</summary>
		public ArrayPointer<HIDP_UNKNOWN_TOKEN> GlobalUnknowns;

		/// <summary>
		/// Specifies the memory location where <c>HidP_GetExtendedAttributes</c> returns a variable length array of
		/// <c>HIDP_UNKNOWN_TOKEN</c> structures.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public uint[] Data;
	}

	/// <summary>For use by the translate usages routine. The modifier state structure identifies the state of the keyboard modifier keys.</summary>
	[PInvokeData("hidpi.h", MSDNShortId = "NF:hidpi.HidP_TranslateUsagesToI8042ScanCodes")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HIDP_KEYBOARD_MODIFIER_STATE
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public uint ul;
		public bool LeftControl { readonly get => BitHelper.GetBit(ul, 0); set => BitHelper.SetBit(ref ul, 0, value); }
		public bool LeftShift { readonly get => BitHelper.GetBit(ul, 1); set => BitHelper.SetBit(ref ul, 1, value); }
		public bool LeftAlt { readonly get => BitHelper.GetBit(ul, 2); set => BitHelper.SetBit(ref ul, 2, value); }
		public bool LeftGUI { readonly get => BitHelper.GetBit(ul, 3); set => BitHelper.SetBit(ref ul, 3, value); }
		public bool RightControl { readonly get => BitHelper.GetBit(ul, 4); set => BitHelper.SetBit(ref ul, 4, value); }
		public bool RightShift { readonly get => BitHelper.GetBit(ul, 5); set => BitHelper.SetBit(ref ul, 5, value); }
		public bool RightAlt { readonly get => BitHelper.GetBit(ul, 6); set => BitHelper.SetBit(ref ul, 6, value); }
		public bool RigthGUI { readonly get => BitHelper.GetBit(ul, 7); set => BitHelper.SetBit(ref ul, 7, value); }
		public bool CapsLock { readonly get => BitHelper.GetBit(ul, 8); set => BitHelper.SetBit(ref ul, 8, value); }
		public bool ScollLock { readonly get => BitHelper.GetBit(ul, 9); set => BitHelper.SetBit(ref ul, 9, value); }
		public bool NumLock { readonly get => BitHelper.GetBit(ul, 10); set => BitHelper.SetBit(ref ul, 10, value); }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	}

	/// <summary>
	/// The HIDP_LINK_COLLECTION_NODE structure contains information about a <c>link collection</c> in a <c>top-level collection's</c> 
	/// <c>link collection array</c>.
	/// </summary>
	/// <remarks>
	/// The <c>HidP_GetLinkCollectionNodes</c> routine returns a top-level collection's link collection array. The indices specified in a
	/// link collection node are indices in the collection's link collection array.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/ns-hidpi-_hidp_link_collection_node typedef struct
	// _HIDP_LINK_COLLECTION_NODE { USAGE LinkUsage; USAGE LinkUsagePage; USHORT Parent; USHORT NumberOfChildren; USHORT NextSibling; USHORT
	// FirstChild; ULONG CollectionType : 8; ULONG IsAlias : 1; ULONG Reserved : 23; PVOID UserContext; } HIDP_LINK_COLLECTION_NODE, *PHIDP_LINK_COLLECTION_NODE;
	[PInvokeData("hidpi.h", MSDNShortId = "NS:hidpi._HIDP_LINK_COLLECTION_NODE")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HIDP_LINK_COLLECTION_NODE
	{
		/// <summary>Specifies the <c>usage ID</c> of a top-level collection.</summary>
		public USAGE LinkUsage;

		/// <summary>Specifies the <c>usage page</c> of the collection.</summary>
		public USAGE LinkUsagePage;

		/// <summary>Specifies the index of the collection's parent collection. If the collection has no parent, <b>Parent</b> is zero.</summary>
		public ushort Parent;

		/// <summary>Specifies the number of child collections that the collection contains.</summary>
		public ushort NumberOfChildren;

		/// <summary>
		/// Specifies the index of the collection's immediate sibling. If the collection has no sibling, <b>NextSibling</b> is zero.
		/// </summary>
		public ushort NextSibling;

		/// <summary>
		/// Specifies the index of the collection's first child collection. If the collection has no children, <b>FirstChild</b> is zero.
		/// </summary>
		public ushort FirstChild;

		private BitField<uint> _bitfield;

		/// <summary>Specifies the type of collection item.</summary>
		public byte CollectionType { readonly get => (byte)_bitfield[new Range(0, 8)]; set => _bitfield[new Range(0, 8)] = value; }

		/// <summary>
		/// Specifies, if <b>TRUE</b>, that this collection is an <c>aliased collection</c>. Otherwise, if <b>FALSE</b>, the collection is
		/// not aliased.
		/// </summary>
		public bool IsAlias { readonly get => _bitfield[8]; set => _bitfield[8] = value; }

		/// <summary>Pointer to application-specific information.</summary>
		public IntPtr UserContext;
	}

	/// <summary>The HIDP_UNKNOWN_TOKEN structure contains information about a global item that the HID parser did not recognize.</summary>
	/// <remarks>
	/// HIDP_UNKNOWN_TOKEN is designed to be used with the <c>HIDP_EXTENDED_ATTRIBUTES</c> structure. <c>HidP_GetExtendedAttributes</c>
	/// returns a HIDP_EXTENDED_ATTRIBUTES structure, which contains a variable length array of <b>HIDP_UNKNOWN_TOKEN</b> structures.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/ns-hidpi-_hidp_unknown_token typedef struct _HIDP_UNKNOWN_TOKEN {
	// UCHAR Token; UCHAR Reserved[3]; ULONG BitField; } HIDP_UNKNOWN_TOKEN, *PHIDP_UNKNOWN_TOKEN;
	[PInvokeData("hidpi.h", MSDNShortId = "NS:hidpi._HIDP_UNKNOWN_TOKEN")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HIDP_UNKNOWN_TOKEN
	{
		/// <summary>Specifies the one-byte prefix of a global item.</summary>
		public byte Token;

		/// <summary>Reserved for internal system use.</summary>
		public unsafe fixed byte Reserved[3];

		/// <summary>Specifies the data part of the global item.</summary>
		public uint BitField;
	}

	/// <summary>
	/// The HIDP_VALUE_CAPS structure contains information that describes the capability of a set of HID control values (either a single
	/// usage or a <c>usage range</c>).
	/// </summary>
	/// <remarks>
	/// <para>
	/// Clients obtain a <c>value capability array</c> by calling <c>HidP_GetValueCaps</c> or <c>HidP_GetSpecificValueCaps</c>. These
	/// routines return an array of HIDP_VALUE_CAPS structures in a caller-allocated buffer. The required buffer length is specified in the
	/// <c>HIDP_CAPS</c> structure returned by <c>HidP_GetCaps</c>.
	/// </para>
	/// <para>For information about the capabilities of HID control values, see <c>Collection Capability</c> and <c>Value Capability Arrays</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/ns-hidpi-_hidp_value_caps typedef struct _HIDP_VALUE_CAPS { USAGE
	// UsagePage; UCHAR ReportID; BOOLEAN IsAlias; USHORT BitField; USHORT LinkCollection; USAGE LinkUsage; USAGE LinkUsagePage; BOOLEAN
	// IsRange; BOOLEAN IsStringRange; BOOLEAN IsDesignatorRange; BOOLEAN IsAbsolute; BOOLEAN HasNull; UCHAR Reserved; USHORT BitSize; USHORT
	// ReportCount; USHORT Reserved2[5]; ULONG UnitsExp; ULONG Units; LONG LogicalMin; LONG LogicalMax; LONG PhysicalMin; LONG PhysicalMax;
	// union { struct { USAGE UsageMin; USAGE UsageMax; USHORT StringMin; USHORT StringMax; USHORT DesignatorMin; USHORT DesignatorMax;
	// USHORT DataIndexMin; USHORT DataIndexMax; } Range; struct { USAGE Usage; USAGE Reserved1; USHORT StringIndex; USHORT Reserved2; USHORT
	// DesignatorIndex; USHORT Reserved3; USHORT DataIndex; USHORT Reserved4; } NotRange; }; } HIDP_VALUE_CAPS, *PHIDP_VALUE_CAPS;
	[PInvokeData("hidpi.h", MSDNShortId = "NS:hidpi._HIDP_VALUE_CAPS")]
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct HIDP_VALUE_CAPS
	{
		/// <summary>Specifies the usage page of the usage or usage range.</summary>
		[FieldOffset(0)]
		public USAGE UsagePage;

		/// <summary>Specifies the report ID of the HID report that contains the usage or usage range.</summary>
		[FieldOffset(2)]
		public byte ReportID;

		/// <summary>
		/// Indicates, if <b>TRUE</b>, that the usage is member of a set of aliased usages. Otherwise, if <b>IsAlias</b> is <b>FALSE</b>, the
		/// value has only one usage.
		/// </summary>
		[FieldOffset(3)]
		[MarshalAs(UnmanagedType.U1)]
		public bool IsAlias;

		/// <summary>Contains the data fields (one or two bytes) associated with an input, output, or feature main item.</summary>
		[FieldOffset(4)]
		public ushort BitField;

		/// <summary>
		/// Specifies the index of the <c>link collection</c> in a <c>top-level collection's</c> link collection array that contains the
		/// usage or usage range. If <b>LinkCollection</b> is zero, the usage or usage range is contained in the top-level collection.
		/// </summary>
		[FieldOffset(6)]
		public HIDP_LINK_COLLECTION LinkCollection;

		/// <summary>
		/// Specifies the usage of the link collection that contains the usage or usage range. If <b>LinkCollection</b> is zero,
		/// <b>LinkUsage</b> specifies the usage of the top-level collection.
		/// </summary>
		[FieldOffset(8)]
		public USAGE LinkUsage;

		/// <summary>
		/// Specifies the usage page of the link collection that contains the usage or usage range. If <b>LinkCollection</b> is zero,
		/// <b>LinkUsagePage</b> specifies the usage page of the top-level collection.
		/// </summary>
		[FieldOffset(10)]
		public USAGE LinkUsagePage;

		/// <summary>
		/// Specifies, if <b>TRUE</b>, that the structure describes a usage range. Otherwise, if <b>IsRange</b> is <b>FALSE</b>, the
		/// structure describes a single usage.
		/// </summary>
		[FieldOffset(12)]
		[MarshalAs(UnmanagedType.U1)]
		public bool IsRange;

		/// <summary>
		/// Specifies, if <b>TRUE</b>, that the usage or usage range has a set of string descriptors. Otherwise, if <b>IsStringRange</b> is
		/// <b>FALSE</b>, the usage or usage range has zero or one string descriptor.
		/// </summary>
		[FieldOffset(13)]
		[MarshalAs(UnmanagedType.U1)]
		public bool IsStringRange;

		/// <summary>
		/// Specifies, if <b>TRUE</b>, that the usage or usage range has a set of designators. Otherwise, if <b>IsDesignatorRange</b> is
		/// <b>FALSE</b>, the usage or usage range has zero or one designator.
		/// </summary>
		[FieldOffset(14)]
		[MarshalAs(UnmanagedType.U1)]
		public bool IsDesignatorRange;

		/// <summary>
		/// Specifies, if <b>TRUE</b>, that the usage or usage range provides absolute data. Otherwise, if <b>IsAbsolute</b> is <b>FALSE</b>,
		/// the value is the change in state from the previous value.
		/// </summary>
		[FieldOffset(15)]
		[MarshalAs(UnmanagedType.U1)]
		public bool IsAbsolute;

		/// <summary>
		/// Specifies, if <b>TRUE</b>, that the usage supports a <b>NULL</b> value, which indicates that the data is not valid and should be
		/// ignored. Otherwise, if <b>HasNull</b> is <b>FALSE</b>, the usage does not have a <b>NULL</b> value.
		/// </summary>
		[FieldOffset(16)]
		[MarshalAs(UnmanagedType.U1)]
		public bool HasNull;

		/// <summary>Reserved for internal system use.</summary>
		[FieldOffset(17)]
		public byte Reserved;

		/// <summary>
		/// Specifies the size, in bits, of a usage's data field in a report. If <b>ReportCount</b> is greater than one, each usage has a
		/// separate data field of this size.
		/// </summary>
		[FieldOffset(18)]
		public ushort BitSize;

		/// <summary>Specifies the number of usages that this structure describes.</summary>
		[FieldOffset(20)]
		public ushort ReportCount;

		/// <summary>Reserved for internal system use.</summary>
		[FieldOffset(22)]
		public unsafe fixed ushort Reserved2[5];

		/// <summary>Specifies the usage's exponent, as described by the USB HID standard.</summary>
		[FieldOffset(32)]
		public uint UnitsExp;

		/// <summary>Specifies the usage's units, as described by the USB HID Standard.</summary>
		[FieldOffset(36)]
		public uint Units;

		/// <summary>Specifies a usage's signed lower bound.</summary>
		[FieldOffset(40)]
		public int LogicalMin;

		/// <summary>Specifies a usage's signed upper bound.</summary>
		[FieldOffset(44)]
		public int LogicalMax;

		/// <summary>Specifies a usage's signed lower bound after scaling is applied to the logical minimum value.</summary>
		[FieldOffset(48)]
		public int PhysicalMin;

		/// <summary>Specifies a usage's signed upper bound after scaling is applied to the logical maximum value.</summary>
		[FieldOffset(52)]
		public int PhysicalMax;

		/// <summary>
		/// Specifies, if <b>IsRange</b> is <b>TRUE</b>, information about a usage range. Otherwise, if <b>IsRange</b> is <b>FALSE</b>,
		/// <b>NotRange</b> contains information about a single usage.
		/// </summary>
		[FieldOffset(56)]
		public RangeUnion Range;

		/// <summary>
		/// Specifies, if <b>IsRange</b> is <b>FALSE</b>, information about a single usage. Otherwise, if <b>IsRange</b> is <b>TRUE</b>,
		/// <b>Range</b> contains information about a usage range.
		/// </summary>
		[FieldOffset(56)]
		public NotRangeUnion NotRange;

		/// <summary>
		/// Specifies, if <b>IsRange</b> is <b>TRUE</b>, information about a usage range. Otherwise, if <b>IsRange</b> is <b>FALSE</b>,
		/// <b>NotRange</b> contains information about a single usage.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct RangeUnion
		{
			/// <summary>Indicates the inclusive lower bound of usage range whose inclusive upper bound is specified by <b>Range.UsageMax</b>.</summary>
			public USAGE UsageMin;

			/// <summary>Indicates the inclusive upper bound of a usage range whose inclusive lower bound is indicated by <b>Range.UsageMin</b>.</summary>
			public USAGE UsageMax;

			/// <summary>
			/// Indicates the inclusive lower bound of a range of string descriptors (specified by string minimum and string maximum
			/// items) whose inclusive upper bound is indicated by <b>Range.StringMax</b>.
			/// </summary>
			public ushort StringMin;

			/// <summary>
			/// Indicates the inclusive upper bound of a range of string descriptors (specified by string minimum and string maximum
			/// items) whose inclusive lower bound is indicated by <b>Range.StringMin</b>.
			/// </summary>
			public ushort StringMax;

			/// <summary>
			/// Indicates the inclusive lower bound of a range of designators (specified by designator minimum and designator maximum
			/// items) whose inclusive lower bound is indicated by <b>Range.DesignatorMax</b>.
			/// </summary>
			public ushort DesignatorMin;

			/// <summary>
			/// Indicates the inclusive upper bound of a range of designators (specified by designator minimum and designator maximum
			/// items) whose inclusive lower bound is indicated by <b>Range.DesignatorMin</b>.
			/// </summary>
			public ushort DesignatorMax;

			/// <summary>
			/// Indicates the inclusive lower bound of a sequential range of <c>data indices</c> that correspond, one-to-one and in the
			/// same order, to the usages specified by the usage range <b>Range.UsageMin</b> to <b>Range.UsageMax</b>.
			/// </summary>
			public ushort DataIndexMin;

			/// <summary>
			/// Indicates the inclusive upper bound of a sequential range of data indices that correspond, one-to-one and in the same
			/// order, to the usages specified by the usage range <b>Range.UsageMin</b> to <b>Range.UsageMax</b>.
			/// </summary>
			public ushort DataIndexMax;
		}

		/// <summary>
		/// Specifies, if <b>IsRange</b> is <b>FALSE</b>, information about a single usage. Otherwise, if <b>IsRange</b> is <b>TRUE</b>,
		/// <b>Range</b> contains information about a usage range.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct NotRangeUnion
		{
			/// <summary>Indicates a <c>usage ID</c>.</summary>
			public USAGE Usage;

			/// <summary>Reserved for internal system use.</summary>
			public USAGE Reserved1;

			/// <summary>Indicates a string descriptor ID for the usage specified by <b>NotRange.Usage</b>.</summary>
			public ushort StringIndex;

			/// <summary>Reserved for internal system use.</summary>
			public ushort Reserved2;

			/// <summary>Indicates a designator ID for the usage specified by <b>NotRange.Usage</b>.</summary>
			public ushort DesignatorIndex;

			/// <summary>Reserved for internal system use.</summary>
			public ushort Reserved3;

			/// <summary>Indicates the data index of the usage specified by <b>NotRange.Usage</b>.</summary>
			public ushort DataIndex;

			/// <summary>Reserved for internal system use.</summary>
			public ushort Reserved4;
		}
	}

	/// <summary>Pointer to a top-level collection's <c>preparsed data</c>.</summary>
	[AutoHandle]
	public partial struct PHIDP_PREPARSED_DATA { }

	/// <summary>Pointer to a device report descriptor.</summary>
	[AutoHandle]
	public partial struct PHIDP_REPORT_DESCRIPTOR { }

	/// <summary>The USAGE_AND_PAGE structure specifies the <c>usage page</c> and <c>usage ID</c> of a HID control.</summary>
	/// <remarks>
	/// <para>
	/// The <b>HidP_IsSameUsageAndPage</b> macro determines if two <c>extended usages</c>, represented by <b>USAGE_AND_PAGE</b> structures,
	/// are equal.
	/// </para>
	/// <para>BOOLEAN HidP_IsSameUsageAndPage( USAGE_AND_PAGE u1, USAGE_AND_PAGE u2 );</para>
	/// <para><i>u1</i></para>
	/// <para><b>USAGE_AND_PAGE</b></para>
	/// <para>Specifies an extended usage</para>
	/// <para><i>u2</i></para>
	/// <para><b>USAGE_AND_PAGE</b></para>
	/// <para>Specifies an extended usage</para>
	/// <para><b>Return Value</b></para>
	/// <para><b>BOOLEAN</b></para>
	/// <para><b>HidP_IsSameUsageAndPage</b> returns one of the following status values:</para>
	/// <para><b>TRUE</b></para>
	/// <para>Usage <i>u1</i> is the same as usage <i>u2</i>.</para>
	/// <para><b>FALSE</b></para>
	/// <para>Usage <i>u1</i> is different than usage <i>u2</i>.</para>
	/// <para>
	/// As defined by the USB HID standard, an extended usage is a 32-bit unsigned value. The high-order 16 bits specify the <c>usage
	/// page</c>, and lower-order 16 bits specify the <c>usage ID</c>.
	/// </para>
	/// <para>For more information, see <c>HID Collections</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/ns-hidpi-_usage_and_page typedef struct _USAGE_AND_PAGE { USAGE
	// Usage; USAGE UsagePage; } USAGE_AND_PAGE, *PUSAGE_AND_PAGE;
	[PInvokeData("hidpi.h", MSDNShortId = "NS:hidpi._USAGE_AND_PAGE")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct USAGE_AND_PAGE
	{
		/// <summary>Specifies a usage ID within the usage page specified by <b>UsagePage</b>.</summary>
		public USAGE Usage;

		/// <summary>Specifies a usage page.</summary>
		public USAGE UsagePage;
	}
}