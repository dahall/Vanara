using System;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class WinSpool
	{
		/// <summary>Indicates that some notifications had to be discarded.</summary>
		public const uint PRINTER_NOTIFY_INFO_DISCARDED = 0x01;

		/// <summary>Printer, job and print server access rights.</summary>
		[PInvokeData("winspool.h")]
		[Flags]
		public enum AccessRights : uint
		{
			/// <summary>Printing-specific authorization to cancel, pause, resume, or restart the job ([MS-DTYP] ACCESS_MASK Bit 27).</summary>
			JOB_ACCESS_ADMINISTER = 0x00000010,
			/// <summary>Printing-specific read rights for the spool file ([MS-DTYP] ACCESS_MASK Bit 26).<127></summary>
			JOB_ACCESS_READ = 0x00000020,
			/// <summary>Access rights for jobs combining RC (Read Control) of ACCESS_MASK with printing-specific JOB_ACCESS_ADMINISTER.
			/// <para>This value MUST NOT be passed over the wire. If it is, the server SHOULD return ERROR_ACCESS_DENIED.</para></summary>
			JOB_EXECUTE = ACCESS_MASK.STANDARD_RIGHTS_EXECUTE | JOB_ACCESS_ADMINISTER,
			/// <summary>Access rights for jobs combining RC (Read Control) of ACCESS_MASK with printing-specific JOB_ACCESS_READ.</summary>
			JOB_READ = ACCESS_MASK.STANDARD_RIGHTS_READ | JOB_ACCESS_READ,
			/// <summary>Access rights for jobs combining RC (Read Control) of ACCESS_MASK with printing-specific JOB_ACCESS_ADMINISTER.
			/// <para>This value MUST NOT be passed over the wire. If it is, the server SHOULD return ERROR_ACCESS_DENIED.</para></summary>
			JOB_WRITE = ACCESS_MASK.STANDARD_RIGHTS_WRITE | JOB_ACCESS_ADMINISTER,
			/// <summary>Access rights for printers to perform all administrative tasks and basic printing operations except SYNCHRONIZE ([MS-DTYP] ACCESS_MASK Bit 'SY'). Combines STANDARD_RIGHTS_REQUIRED (ACCESS_MASK Bits 'RC', 'DE', 'WD', 'WO'), JOB_ACCESS_ADMINISTER (ACCESS_MASK Bit 27), and JOB_ACCESS_READ (ACCESS_MASK Bit 26).</summary>
			JOB_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED | JOB_ACCESS_ADMINISTER | JOB_ACCESS_READ,
			/// <summary>Printing-specific access rights for printers to perform administrative tasks ([MS-DTYP] ACCESS_MASK Bit 29).</summary>
			PRINTER_ACCESS_ADMINISTER = 0x00000004,
			/// <summary>Printing-specific access rights for printers to perform basic printing operations ([MS-DTYP] ACCESS_MASK Bit 28).</summary>
			PRINTER_ACCESS_USE = 0x00000008,
			/// <summary>Printing-specific access rights for printers to perform printer data management operations ([MS-DTYP] ACCESS_MASK Bit 25).<128></summary>
			PRINTER_ACCESS_MANAGE_LIMITED = 0x00000040,
			/// <summary>Access rights for printers to perform all administrative tasks and basic printing operations except synchronization. Combines WO (Write Owner), WD (Write DACL), RC (Read Control), and DE (Delete) of ACCESS_MASK with printing-specific PRINTER_ACCESS_ADMINISTER and printing-specific PRINTER_ACCESS_USE.</summary>
			PRINTER_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED | PRINTER_ACCESS_ADMINISTER | PRINTER_ACCESS_USE,
			/// <summary>Access rights for printers combining RC (Read Control) of ACCESS_MASK with printing-specific PRINTER_ACCESS_USE.</summary>
			PRINTER_EXECUTE = ACCESS_MASK.STANDARD_RIGHTS_EXECUTE | PRINTER_ACCESS_USE,
			/// <summary>Access rights for printers combining RC (Read Control) of ACCESS_MASK with printing-specific PRINTER_ACCESS_USE.</summary>
			PRINTER_READ = ACCESS_MASK.STANDARD_RIGHTS_READ | PRINTER_ACCESS_USE,
			/// <summary>Access rights for printers combining RC (Read Control) of ACCESS_MASK with printing-specific PRINTER_ACCESS_USE.</summary>
			PRINTER_WRITE = ACCESS_MASK.STANDARD_RIGHTS_WRITE | PRINTER_ACCESS_USE,
			/// <summary>Printing-specific access rights to administer print servers ([MS-DTYP] ACCESS_MASK Bit 31).</summary>
			SERVER_ACCESS_ADMINISTER = 0x00000001,
			/// <summary>Printing-specific access rights to enumerate print servers ([MS-DTYP] ACCESS_MASK Bit 30).</summary>
			SERVER_ACCESS_ENUMERATE = 0x00000002,
			/// <summary>Access rights for print servers to perform all administrative tasks and basic printing operations except synchronization. Combines WO (Write Owner), WD (Write DACL), RC (Read Control), and DE (Delete) of ACCESS_MASK with printing-specific SERVER_ACCESS_ADMINISTER and printing-specific SERVER_ACCESS_ENUMERATE.</summary>
			SERVER_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED | SERVER_ACCESS_ADMINISTER | SERVER_ACCESS_ENUMERATE,
			/// <summary>Access rights for print servers combining RC (Read Control) of ACCESS_MASK with printing-specific SERVER_ACCESS_ENUMERATE.</summary>
			SERVER_EXECUTE = ACCESS_MASK.STANDARD_RIGHTS_EXECUTE | SERVER_ACCESS_ENUMERATE,
			/// <summary>Access rights for print servers combining RC (Read Control) of ACCESS_MASK with printing-specific SERVER_ACCESS_ENUMERATE.</summary>
			SERVER_READ = ACCESS_MASK.STANDARD_RIGHTS_READ | SERVER_ACCESS_ENUMERATE,
			/// <summary>Access rights for print servers combining RC (Read Control) of ACCESS_MASK with printing-specific SERVER_ACCESS_ADMINISTER and printing-specific SERVER_ACCESS_ENUMERATE.</summary>
			SERVER_WRITE = ACCESS_MASK.STANDARD_RIGHTS_WRITE | SERVER_ACCESS_ADMINISTER | SERVER_ACCESS_ENUMERATE,
		}

		/// <summary>Specifies additional information about the print job.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "329bf0d9-399b-4f64-a029-361ef7558aeb")]
		public enum DI
		{
			/// <summary>Applications that use banding should set this flag for optimal performance during printing.</summary>
			DI_APPBANDING = 0x00000001,

			/// <summary>The application will use raster operations that involve reading from the destination surface.</summary>
			DI_ROPS_READ_DESTINATION = 0x00000002
		}

		/// <summary>Device mode flags.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "e89a2f6f-2bac-4369-b526-f8e15028698b")]
		[Flags]
		public enum DM
		{
			/// <summary>
			/// When used, the DocumentProperties function returns the number of bytes required by the printer driver's DEVMODE data structure.
			/// </summary>
			DM_SIZEOF = 0,

			/// <summary><see cref="DM_OUT_DEFAULT"/></summary>
			DM_UPDATE = 1,

			/// <summary><see cref="DM_OUT_BUFFER"/></summary>
			DM_COPY = 2,

			/// <summary><see cref="DM_IN_PROMPT"/></summary>
			DM_PROMPT = 4,

			/// <summary><see cref="DM_IN_BUFFER"/></summary>
			DM_MODIFY = 8,

			/// <summary>No description available.</summary>
			DM_OUT_DEFAULT = DM_UPDATE,

			/// <summary>
			/// Output value. The function writes the printer driver's current print settings, including private data, to the DEVMODE data
			/// structure specified by the pDevModeOutput parameter. The caller must allocate a buffer sufficiently large to contain the
			/// information. If the bit DM_OUT_BUFFER sets is clear, the pDevModeOutput parameter can be NULL. This value is also defined as <see cref="DM_COPY"/>.
			/// </summary>
			DM_OUT_BUFFER = DM_COPY,

			/// <summary>
			/// Input value. The function presents the printer driver's Print Setup property sheet and then changes the settings in the
			/// printer's DEVMODE data structure to those values specified by the user. This value is also defined as <see cref="DM_PROMPT"/>.
			/// </summary>
			DM_IN_PROMPT = DM_PROMPT,

			/// <summary>
			/// Input value. Before prompting, copying, or updating, the function merges the printer driver's current print settings with
			/// the settings in the DEVMODE structure specified by the pDevModeInput parameter. The function updates the structure only for
			/// those members specified by the DEVMODE structure's dmFields member. This value is also defined as <see cref="DM_MODIFY"/>.
			/// In cases of conflict during the merge, the settings in the DEVMODE structure specified by pDevModeInput override the printer
			/// driver's current print settings.
			/// </summary>
			DM_IN_BUFFER = DM_MODIFY,
		}

		/// <summary>An escape code that identifies the event to be handled.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "1250116e-55c7-470f-97f6-36f27a31a841")]
		public enum DOCUMENTEVENT
		{
			/// <summary>GDI is about to process a call to its CreateDC or CreateIC function.</summary>
			//[CorrespondingType(typeof(DOCEVENT_CREATEDPRE), CorrespondingAction.Set)]
			[CorrespondingType(typeof(DEVMODE), CorrespondingAction.Get)]
			DOCUMENTEVENT_CREATEDCPRE = 1,

			/// <summary>
			/// GDI has just processed a call to its CreateDC or CreateIC function.
			/// <para>This escape code should not be used unless there has been a previous call to DocumentEvent with iEsc set to DOCUMENTEVENT_CREATEDCPRE.</para>
			/// </summary>
			[CorrespondingType(typeof(DEVMODE), CorrespondingAction.Set)]
			DOCUMENTEVENT_CREATEDCPOST = 2,

			/// <summary>GDI is about to process a call to its ResetDC function.</summary>
			[CorrespondingType(typeof(DEVMODE), CorrespondingAction.GetSet)]
			DOCUMENTEVENT_RESETDCPRE = 3,

			/// <summary>
			/// GDI has just processed a call to its ResetDC function.
			/// <para>This escape code should not be used unless there has been a previous call to DocumentEvent with iEsc set to DOCUMENTEVENT_RESETDCPRE.</para>
			/// </summary>
			[CorrespondingType(typeof(DEVMODE), CorrespondingAction.Set)]
			DOCUMENTEVENT_RESETDCPOST = 4,

			/// <summary>GDI is about to process a call to its StartDoc function.</summary>
			[CorrespondingType(typeof(DOCINFO), CorrespondingAction.Set)]
			DOCUMENTEVENT_STARTDOC = 5,

			/// <summary>GDI is about to process a call to its StartDoc function.</summary>
			[CorrespondingType(typeof(DOCINFO), CorrespondingAction.Set)]
			DOCUMENTEVENT_STARTDOCPRE = 5,

			/// <summary>GDI is about to process a call to its StartPage function.</summary>
			DOCUMENTEVENT_STARTPAGE = 6,

			/// <summary>GDI is about to process a call to its EndPage function.</summary>
			DOCUMENTEVENT_ENDPAGE = 7,

			/// <summary>GDI is about to process a call to its EndDoc function.</summary>
			DOCUMENTEVENT_ENDDOC = 8,

			/// <summary>GDI is about to process a call to its EndDoc function.</summary>
			DOCUMENTEVENT_ENDDOCPRE = 8,

			/// <summary>GDI is about to process a call to its AbortDoc function.</summary>
			DOCUMENTEVENT_ABORTDOC = 9,

			/// <summary>GDI is about to process a call to its DeleteDC function.</summary>
			DOCUMENTEVENT_DELETEDC = 10,

			/// <summary>GDI is about to process a call to its ExtEscape function.</summary>
			//[CorrespondingType(typeof(DOCEVENT_ESCAPE), CorrespondingAction.Set)]
			DOCUMENTEVENT_ESCAPE = 11,

			/// <summary>GDI has just processed a call to its EndDoc function.</summary>
			DOCUMENTEVENT_ENDDOCPOST = 12,

			/// <summary>GDI has just processed a call to its StartDoc function.</summary>
			[CorrespondingType(typeof(int), CorrespondingAction.Set)]
			DOCUMENTEVENT_STARTDOCPOST = 13,

			/// <summary>
			/// The DOCUMENTEVENT_QUERYFILTER event represents an opportunity for the spooler to query the driver for a list of the
			/// DOCUMENTEVENT_ XXX events to which the driver will respond. This event is issued just prior to a call to DocumentEvent that
			/// passes the DOCUMENTEVENT_CREATEDCPRE event.
			/// </summary>
			//[CorrespondingType(typeof(DOCEVENT_CREATEDPRE), CorrespondingAction.Set)]
			//[CorrespondingType(typeof(DOCEVENT_FILTER), CorrespondingAction.Get)]
			DOCUMENTEVENT_QUERYFILTER = 14,
		}

		/// <summary>
		/// Indicates the action for the <c>SetPrinter</c> function to perform. For the <c>GetPrinter</c> function, this member indicates
		/// whether the specified printer is published.
		/// </summary>
		[PInvokeData("winspool.h", MSDNShortId = "9443855e-df7d-41a1-a0df-5649a97b2915")]
		[Flags]
		public enum DSPRINT : uint
		{
			/// <summary>
			/// GetPrinter: Indicates that the system is attempting to complete a publish or unpublish operation started by a SetPrinter call.
			/// <para>SetPrinter: This value is not valid.</para>
			/// </summary>
			DSPRINT_PENDING = 0x80000000,

			/// <summary>
			/// SetPrinter: Publishes the printer's data in the DS.
			/// <para>GetPrinter: Indicates the printer is published.</para>
			/// </summary>
			DSPRINT_PUBLISH = 0x00000001,

			/// <summary>
			/// SetPrinter: The DS data for the printer is unpublished and then published again, refreshing all properties in the published
			/// printer. Re-publishing also changes the GUID of the published printer.
			/// <para>GetPrinter: Never returns this value.</para>
			/// </summary>
			DSPRINT_REPUBLISH = 0x00000008,

			/// <summary>
			/// SetPrinter: Removes the printer's published data from the DS.
			/// <para>GetPrinter: Indicates the printer is not published.</para>
			/// </summary>
			DSPRINT_UNPUBLISH = 0x00000004,

			/// <summary>
			/// SetPrinter: Updates the printer's published data in the DS.
			/// <para>GetPrinter: Never returns this value.</para>
			/// </summary>
			DSPRINT_UPDATE = 0x00000002,
		}

		/// <summary>
		/// <para>The <c>EPrintPropertyType</c> enumeration defines the data types for different printing properties.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/openspecs/windows_protocols/ms-par/9c30d688-be09-4a19-9e41-cb21a55f3884
		[PInvokeData("winspool.h")]
		public enum EPrintPropertyType
		{
			/// <summary>The data type is <c>string</c>.</summary>
			kPropertyTypeString = 1,

			/// <summary>The data type is a 32-bit signed integer.</summary>
			kPropertyTypeInt32,

			/// <summary>The data type is a 64-bit signed integer.</summary>
			kPropertyTypeInt64,

			/// <summary>The data type is a <c>BYTE</c>.</summary>
			kPropertyTypeByte,

			/// <summary>The data type is <c>SYSTEMTIME_CONTAINER</c>, as specified in [MS-RPRN] section <c>2.2.1.2.16</c>.</summary>
			kPropertyTypeTime,

			/// <summary>The data type is <c>DEVMODE_CONTAINER</c>, as specified in [MS-RPRN] section <c>2.2.1.2.1</c>.</summary>
			kPropertyTypeDevMode,

			/// <summary>The data type is <c>SECURITY_CONTAINER</c>, as specified in [MS-RPRN] section <c>2.2.1.2.13</c>.</summary>
			kPropertyTypeSD,

			/// <summary>The data type is <c>NOTIFY_REPLY_CONTAINER</c>, as specified in section <c>2.2.7</c>.</summary>
			kPropertyTypeNotificationReply,

			/// <summary>The data type is <c>NOTIFY_OPTIONS_CONTAINER</c>, as specified in section <c>2.2.6</c>.</summary>
			kPropertyTypeNotificationOptions
		}

		/// <summary>Specifies whether an XPS print job is in the spooling or the rendering phase.</summary>
		/// <remarks>This enumeration is primarily used as a parameter for the <c>ReportJobProcessingProgress</c> function.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/printdocs/eprintxpsjoboperation typedef enum tagEPrintXPSJobOperation {
		// kJobProduction, kJobConsumption } EPrintXPSJobOperation;
		[PInvokeData("Winspool.h", MSDNShortId = "14871d29-59e4-45a2-9697-12550c58396c")]
		public enum EPrintXPSJobOperation
		{
			/// <summary>The XPS job is spooling.</summary>
			kJobProduction = 1,

			/// <summary>The XPS job is rendering.</summary>
			kJobConsumption,
		}

		/// <summary>Specifies what the spooler is currently doing as it processes an XPS print job.</summary>
		/// <remarks>
		/// <para>This enumeration is primarily used as a parameter for the <c>ReportJobProcessingProgress</c> function.</para>
		/// <para>These values can refer to either the spooling or the rendering phase of a print job.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/printdocs/eprintxpsjobprogress typedef enum tagEPrintXPSJobProgress {
		// kAddingDocumentSequence, kDocumentSequenceAdded, kAddingFixedDocument, kFixedDocumentAdded, kAddingFixedPage, kFixedPageAdded,
		// kResourceAdded, kFontAdded, kImageAdded, kXpsDocumentCommitted } EPrintXPSJobProgress;
		[PInvokeData("Winspool.h", MSDNShortId = "4fa5b749-e4f9-4f08-97b5-e58f82d0b485")]
		public enum EPrintXPSJobProgress
		{
			/// <summary>A document sequence is about to be added to the XPS job.</summary>
			kAddingDocumentSequence,

			/// <summary>A document sequence has been added to the XPS job.</summary>
			kDocumentSequenceAdded,

			/// <summary>A fixed document is about to be added to the XPS job.</summary>
			kAddingFixedDocument,

			/// <summary>A fixed document has been added to the XPS job.</summary>
			kFixedDocumentAdded,

			/// <summary>A page is about to be added to the XPS job.</summary>
			kAddingFixedPage,

			/// <summary>A page has been added to the XPS job.</summary>
			kFixedPageAdded,

			/// <summary>A resource had been added to the XPS job.</summary>
			kResourceAdded,

			/// <summary>A font has been added to the XPS job.</summary>
			kFontAdded,

			/// <summary>An image has been added to the XPS job.</summary>
			kImageAdded,

			/// <summary>The data for the XPS job has been committed.</summary>
			kXpsDocumentCommitted,
		}

		/// <summary>The form properties.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "1c42ea6c-82cf-463c-bc67-44a8d8c4a1e7")]
		public enum FormFlags
		{
			/// <summary>
			/// If this bit flag is set, the form has been defined by the user. Forms with this flag set are defined in the registry.
			/// </summary>
			FORM_USER,

			/// <summary>
			/// If this bit-flag is set, the form is part of the spooler. Form definitions with this flag set do not appear in the registry.
			/// </summary>
			FORM_BUILTIN,

			/// <summary>If this bit flag is set, the form is associated with a certain printer, and its definition appears in the registry.</summary>
			FORM_PRINTER
		}

		/// <summary>Specifies how a localized display name for the form is obtained at runtime.</summary>
		[PInvokeData("winspool.h")]
		[Flags]
		public enum FormStringType
		{
			/// <summary>There is no localized display name.</summary>
			STRING_NONE = 0x00000001,

			/// <summary>
			/// The display name is extracted from the Multilingual User Interface localized resources DLL specified in pMuiDll. The ID is
			/// in the dwResourceId member.
			/// </summary>
			STRING_MUIDLL = 0x00000002,

			/// <summary>The display name and language ID are provided directly by pDisplayName and the language is specified by wLangId.</summary>
			STRING_LANGPAIR = 0x00000004
		}

		/// <summary>The print job operation to perform.</summary>
		[PInvokeData("winspool.h")]
		public enum JOB_CONTROL
		{
			/// <summary>Pause the print job.</summary>
			JOB_CONTROL_PAUSE = 1,

			/// <summary>Resume a paused print job.</summary>
			JOB_CONTROL_RESUME = 2,

			/// <summary>Do not use. To delete a print job, use JOB_CONTROL_DELETE.</summary>
			JOB_CONTROL_CANCEL = 3,

			/// <summary>Restart the print job. A job can only be restarted if it was printing.</summary>
			JOB_CONTROL_RESTART = 4,

			/// <summary>Delete the print job.</summary>
			JOB_CONTROL_DELETE = 5,

			/// <summary>Used by port monitors to end the print job.</summary>
			JOB_CONTROL_SENT_TO_PRINTER = 6,

			/// <summary>Used by language monitors to end the print job.</summary>
			JOB_CONTROL_LAST_PAGE_EJECTED = 7,

			/// <summary>Windows Vista and later: Keep the job in the queue after it prints.</summary>
			JOB_CONTROL_RETAIN = 8,

			/// <summary>Windows Vista and later: Release the print job.</summary>
			JOB_CONTROL_RELEASE = 9,
		}

		/// <summary>
		/// Possible values for <see cref="PRINTER_NOTIFY_INFO_DATA.Field"/> when <see cref="PRINTER_NOTIFY_INFO_DATA.Type"/> is <see cref="NOTIFY_TYPE.JOB_NOTIFY_TYPE"/>.
		/// </summary>
		[PInvokeData("winspool.h", MSDNShortId = "7a7b9e01-32e0-47f8-a5b1-5f7e6a663714")]
		public enum JOB_NOTIFY_FIELD : ushort
		{
			/// <summary>pBuf is a pointer to a null-terminated string containing the name of the printer for which the job is spooled.</summary>
			JOB_NOTIFY_FIELD_PRINTER_NAME = 0x00,

			/// <summary>
			/// pBuf is a pointer to a null-terminated string that specifies the name of the machine that created the print job.
			/// </summary>
			JOB_NOTIFY_FIELD_MACHINE_NAME = 0x01,

			/// <summary>
			/// pBuf is a pointer to a null-terminated string that identifies the port(s) used to transmit data to the printer. If a printer
			/// is connected to more than one port, the names of the ports are separated by commas (for example, "LPT1:,LPT2:,LPT3:").
			/// </summary>
			JOB_NOTIFY_FIELD_PORT_NAME = 0x02,

			/// <summary>pBuf is a pointer to a null-terminated string that specifies the name of the user who sent the print job.</summary>
			JOB_NOTIFY_FIELD_USER_NAME = 0x03,

			/// <summary>
			/// pBuf is a pointer to a null-terminated string that specifies the name of the user who should be notified when the job has
			/// been printed or when an error occurs while printing the job.
			/// </summary>
			JOB_NOTIFY_FIELD_NOTIFY_NAME = 0x04,

			/// <summary>pBuf is a pointer to a null-terminated string that specifies the type of data used to record the print job.</summary>
			JOB_NOTIFY_FIELD_DATATYPE = 0x05,

			/// <summary>
			/// pBuf is a pointer to a null-terminated string that specifies the name of the print processor to be used to print the job.
			/// </summary>
			JOB_NOTIFY_FIELD_PRINT_PROCESSOR = 0x06,

			/// <summary>pBuf is a pointer to a null-terminated string that specifies print-processor parameters.</summary>
			JOB_NOTIFY_FIELD_PARAMETERS = 0x07,

			/// <summary>
			/// pBuf is a pointer to a null-terminated string that specifies the name of the printer driver that should be used to process
			/// the print job.
			/// </summary>
			JOB_NOTIFY_FIELD_DRIVER_NAME = 0x08,

			/// <summary>
			/// pBuf is a pointer to a DEVMODE structure that contains device-initialization and environment data for the printer driver.
			/// </summary>
			JOB_NOTIFY_FIELD_DEVMODE = 0x09,

			/// <summary>adwData [0] specifies the job status. For a list of possible values, see the JOB_INFO_2 structure.</summary>
			JOB_NOTIFY_FIELD_STATUS = 0x0A,

			/// <summary>pBuf is a pointer to a null-terminated string that specifies the status of the print job.</summary>
			JOB_NOTIFY_FIELD_STATUS_STRING = 0x0B,

			/// <summary>Not supported.</summary>
			JOB_NOTIFY_FIELD_SECURITY_DESCRIPTOR = 0x0C,

			/// <summary>
			/// pBuf is a pointer to a null-terminated string that specifies the name of the print job (for example, "MS-WORD: Review.doc").
			/// </summary>
			JOB_NOTIFY_FIELD_DOCUMENT = 0x0D,

			/// <summary>adwData [0] specifies the job priority.</summary>
			JOB_NOTIFY_FIELD_PRIORITY = 0x0E,

			/// <summary>adwData [0] specifies the job's position in the print queue.</summary>
			JOB_NOTIFY_FIELD_POSITION = 0x0F,

			/// <summary>pBuf is a pointer to a SYSTEMTIME structure that specifies the time when the job was submitted.</summary>
			JOB_NOTIFY_FIELD_SUBMITTED = 0x10,

			/// <summary>
			/// adwData [0] specifies the earliest time that the job can be printed. (This value is specified in minutes elapsed since 12:00 A.M.)
			/// </summary>
			JOB_NOTIFY_FIELD_START_TIME = 0x11,

			/// <summary>
			/// adwData [0] specifies the latest time that the job can be printed. (This value is specified in minutes elapsed since 12:00 A.M.)
			/// </summary>
			JOB_NOTIFY_FIELD_UNTIL_TIME = 0x12,

			/// <summary>adwData [0] specifies the total time, in seconds, that has elapsed since the job began printing.</summary>
			JOB_NOTIFY_FIELD_TIME = 0x13,

			/// <summary>adwData [0] specifies the size, in pages, of the job.</summary>
			JOB_NOTIFY_FIELD_TOTAL_PAGES = 0x14,

			/// <summary>adwData [0] specifies the number of pages that have printed.</summary>
			JOB_NOTIFY_FIELD_PAGES_PRINTED = 0x15,

			/// <summary>adwData [0] specifies the size, in bytes, of the job.</summary>
			JOB_NOTIFY_FIELD_TOTAL_BYTES = 0x16,

			/// <summary>
			/// adwData [0] specifies the number of bytes that have been printed on this job. For this field, the change notification object
			/// is signaled when bytes are sent to the printer.
			/// </summary>
			JOB_NOTIFY_FIELD_BYTES_PRINTED = 0x17,

			/// <summary/>
			JOB_NOTIFY_FIELD_REMOTE_JOB_ID = 0x18,
		}

		/// <summary>The job priority.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "d42ada89-6bc7-4006-81d9-dbcc0347edd3")]
		public enum JOB_PRIORITY
		{
			/// <summary>No priority.</summary>
			NO_PRIORITY = 0,

			/// <summary>The maximum priority/</summary>
			MAX_PRIORITY = 99,

			/// <summary>The minimum priority.</summary>
			MIN_PRIORITY = 1,

			/// <summary>The default priority.</summary>
			DEF_PRIORITY = 1,
		}

		/// <summary>The job status.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "d42ada89-6bc7-4006-81d9-dbcc0347edd3")]
		public enum JOB_STATUS : uint
		{
			/// <summary>The job is paused.</summary>
			JOB_STATUS_PAUSED = 0x00000001,

			/// <summary>An error is associated with the job.</summary>
			JOB_STATUS_ERROR = 0x00000002,

			/// <summary>Job is being deleted.</summary>
			JOB_STATUS_DELETING = 0x00000004,

			/// <summary>The job is spooling.</summary>
			JOB_STATUS_SPOOLING = 0x00000008,

			/// <summary>The job is printing.</summary>
			JOB_STATUS_PRINTING = 0x00000010,

			/// <summary>Printer is offline.</summary>
			JOB_STATUS_OFFLINE = 0x00000020,

			/// <summary>Printer is out of paper.</summary>
			JOB_STATUS_PAPEROUT = 0x00000040,

			/// <summary>Job has printed.</summary>
			JOB_STATUS_PRINTED = 0x00000080,

			/// <summary>Job has been deleted.</summary>
			JOB_STATUS_DELETED = 0x00000100,

			/// <summary>The driver cannot print the job.</summary>
			JOB_STATUS_BLOCKED_DEVQ = 0x00000200,

			/// <summary>Printer has an error that requires the user to do something.</summary>
			JOB_STATUS_USER_INTERVENTION = 0x00000400,

			/// <summary>Job has been restarted.</summary>
			JOB_STATUS_RESTART = 0x00000800,

			/// <summary>
			/// Windows XP and later: Job is sent to the printer, but the job may not be printed yet.
			/// <para>See Remarks for more information.</para>
			/// </summary>
			JOB_STATUS_COMPLETE = 0x00001000,

			/// <summary>
			/// <para>
			/// Windows Vista and later: Job has been retained in the print queue and cannot be deleted. This can be caused by the following:
			/// </para>
			/// <list type="number">
			/// <item>The job was manually retained by a call to SetJob and the spooler is waiting for the job to be released.</item>
			/// <item>The job has not finished printing and must finish printing before it can be automatically deleted.</item>
			/// </list>
			/// <para>See SetJob for more information about print job commands.</para>
			/// </summary>
			JOB_STATUS_RETAINED = 0x00002000,

			/// <summary/>
			JOB_STATUS_RENDERING_LOCALLY = 0x00004000,
		}

		/// <summary>Indicates the type of information provided by <see cref="PRINTER_NOTIFY_INFO_DATA"/>.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "7a7b9e01-32e0-47f8-a5b1-5f7e6a663714")]
		public enum NOTIFY_TYPE : ushort
		{
			/// <summary>Indicates that the Field member specifies a JOB_NOTIFY_FIELD_* constant.</summary>
			JOB_NOTIFY_TYPE = 0x01,

			/// <summary>Indicates that the Field member specifies a PRINTER_NOTIFY_FIELD_* constant.</summary>
			PRINTER_NOTIFY_TYPE = 0x00,
		}

		/// <summary>The new port status.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "0939353f-284b-4dbb-89a2-04918c934430")]
		public enum PORT_STATUS
		{
			/// <summary>Clears the printer port status.</summary>
			PORT_STATUS_CLEAR = 0x00000000,

			/// <summary>The port’s printer is offline.</summary>
			PORT_STATUS_OFFLINE = 0x00000001,

			/// <summary>The port’s printer has a paper jam.</summary>
			PORT_STATUS_PAPER_JAM = 0x00000002,

			/// <summary>The port’s printer is out of paper.</summary>
			PORT_STATUS_PAPER_OUT = 0x00000003,

			/// <summary>The port’s printer's output bin is full.</summary>
			PORT_STATUS_OUTPUT_BIN_FULL = 0x00000004,

			/// <summary>The port’s printer has a paper problem.</summary>
			PORT_STATUS_PAPER_PROBLEM = 0x00000005,

			/// <summary>The port’s printer is out of toner.</summary>
			PORT_STATUS_NO_TONER = 0x00000006,

			/// <summary>The door of the port’s printer is open.</summary>
			PORT_STATUS_DOOR_OPEN = 0x00000007,

			/// <summary>The port’s printer requires user intervention.</summary>
			PORT_STATUS_USER_INTERVENTION = 0x00000008,

			/// <summary>The port’s printer is out of memory.</summary>
			PORT_STATUS_OUT_OF_MEMORY = 0x00000009,

			/// <summary>The port’s printer is low on toner.</summary>
			PORT_STATUS_TONER_LOW = 0x0000000A,

			/// <summary>The port’s printer is warming up.</summary>
			PORT_STATUS_WARMING_UP = 0x0000000B,

			/// <summary>The port’s printer is in a power-conservation mode.</summary>
			PORT_STATUS_POWER_SAVE = 0x0000000C,
		}

		/// <summary>The severity of the port status value.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "0939353f-284b-4dbb-89a2-04918c934430")]
		public enum PORT_STATUS_TYPE
		{
			/// <summary>The port status value indicates an error.</summary>
			PORT_STATUS_TYPE_ERROR = 0x00000001,

			/// <summary>The port status value is a warning.</summary>
			PORT_STATUS_TYPE_WARNING = 0x00000002,

			/// <summary>The port status value is informational.</summary>
			PORT_STATUS_TYPE_INFO = 0x00000003,
		}

		/// <summary>A bit field that specifies attributes of the printer port.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "93675294-61d4-40e4-b84c-f252978e0285")]
		[Flags]
		public enum PORT_TYPE
		{
			/// <summary>The port can be written to.</summary>
			PORT_TYPE_WRITE = 0x00000001,

			/// <summary>The port can be read from.</summary>
			PORT_TYPE_READ = 0x00000002,

			/// <summary>The port is a Terminal Services redirected port.</summary>
			PORT_TYPE_REDIRECTED = 0x00000004,

			/// <summary>The port is a network TCP/IP port.</summary>
			PORT_TYPE_NET_ATTACHED = 0x00000008,
		}

		/// <summary>Print processor border options.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "70120739-a4e0-4b87-ac7a-40a42fb509ee")]
		[Flags]
		public enum PPCAPS_BORDER
		{
			/// <summary>
			/// Indicates that when multiple document pages are being printed on a single side of a physical sheet, the printer can be told
			/// whether or not to print a border around the imageable area of each document page.
			/// </summary>
			PPCAPS_BORDER_PRINT = 0x00000001,
		}

		/// <summary>The available patterns when multiple document pages are printed on the same side of a sheet of paper.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "70120739-a4e0-4b87-ac7a-40a42fb509ee")]
		[Flags]
		public enum PPCAPS_DIRECTION
		{
			/// <summary>Pages appear in rows from right to left, each subsequent row below its predecessor.</summary>
			PPCAPS_RIGHT_THEN_DOWN = 0x00000001,

			/// <summary>Pages appear in columns from top to bottom, each subsequent column to the right of its predecessor.</summary>
			PPCAPS_DOWN_THEN_RIGHT = 0x00000001 << 1,

			/// <summary>Pages appear in rows from left to right, each subsequent row below its predecessor.</summary>
			PPCAPS_LEFT_THEN_DOWN = 0x00000001 << 2,

			/// <summary>Pages appear in columns from top to bottom, each subsequent column to the left of its predecessor.</summary>
			PPCAPS_DOWN_THEN_LEFT = 0x00000001 << 3,
		}

		/// <summary>Print processor duplux handling options.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "70120739-a4e0-4b87-ac7a-40a42fb509ee")]
		[Flags]
		public enum PPCAPS_DUPLEX
		{
			/// <summary>
			/// When printing in reverse order and duplexing, the processor can print swap the order of each pair of pages, so instead of
			/// printing in order 4,3,2,1, they will print in the order 3,4,1,2.
			/// </summary>
			PPCAPS_REVERSE_PAGES_FOR_REVERSE_DUPLEX = 0x00000001,

			/// <summary>
			/// When duplexing, the Print Processor can be told not to send an extra page when there is an odd number of document pages. The
			/// processor will honor the value as best as it can, but in cases where preventing an extra blank page would cause improper
			/// output, the extra pages may still be sent.
			/// </summary>
			PPCAPS_DONT_SEND_EXTRA_PAGES_FOR_DUPLEX = 0x00000002
		}

		/// <summary>Print processor booklet handling.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "70120739-a4e0-4b87-ac7a-40a42fb509ee")]
		[Flags]
		public enum PPCAPS_EDGE
		{
			/// <summary>Indicates that the printer can print booklet style.</summary>
			PPCAPS_BOOKLET_EDGE = 0x00000001,
		}

		/// <summary>Print processor scaling options.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "70120739-a4e0-4b87-ac7a-40a42fb509ee")]
		[Flags]
		public enum PPCAPS_SCALING
		{
			/// <summary>Indicates that the printer can scale the page image.</summary>
			PPCAPS_SQUARE_SCALING = 0x00000001,
		}

		/// <summary>Represents the execution context when <c>GetPrintExecutionData</c> is called.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/printdocs/print-execution-context typedef enum PRINT_EXECUTION_CONTEXT;
		[PInvokeData("Winspool.h", MSDNShortId = "b6c026b2-8519-45d3-9614-b502eec23cde")]
		public enum PRINT_EXECUTION_CONTEXT
		{
			/// <summary>The caller is running in an application.</summary>
			PRINT_EXECUTION_CONTEXT_APPLICATION = 0,

			/// <summary>The caller is running in the spooler service (spoolsv.exe).</summary>
			PRINT_EXECUTION_CONTEXT_SPOOLER_SERVICE = 1,

			/// <summary>The caller is running in the print isolation host (PrintIsolationHost.exe)</summary>
			PRINT_EXECUTION_CONTEXT_SPOOLER_ISOLATION_HOST = 2,

			/// <summary>The caller is running in the print filter pipeline (printfilterpipelinesvc.exe)</summary>
			PRINT_EXECUTION_CONTEXT_FILTER_PIPELINE = 3,

			/// <summary>The caller is running in splwow64.exe</summary>
			PRINT_EXECUTION_CONTEXT_WOW64 = 4,
		}

		/// <summary>The printer attributes.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "944cbfcd-9edf-4b60-a45c-9bb1839f8141")]
		[Flags]
		public enum PRINTER_ATTRIBUTE
		{
			/// <summary>Indicates the printer is the default printer in the system.</summary>
			PRINTER_ATTRIBUTE_DEFAULT = 0x00000004,

			/// <summary>Job is sent directly to the printer (it is not spooled).</summary>
			PRINTER_ATTRIBUTE_DIRECT = 0x00000002,

			/// <summary>If set and printer is set for print-while-spooling, any jobs that have completed spooling are scheduled to print
			/// before jobs that have not completed spooling.<185></summary>
			PRINTER_ATTRIBUTE_DO_COMPLETE_FIRST = 0x00000200,

			/// <summary>Indicates whether bidirectional communications are enabled for the printer.<186></summary>
			PRINTER_ATTRIBUTE_ENABLE_BIDI = 0x00000800,

			/// <summary>Setting this flag causes mismatched documents to be held in the queue.<187></summary>
			PRINTER_ATTRIBUTE_ENABLE_DEVQ = 0x00000080,

			/// <summary>If set, printer is a fax printer.</summary>
			PRINTER_ATTRIBUTE_FAX = 0x00004000,

			/// <summary>If set, jobs are kept after they are printed. If cleared, jobs are deleted.<188></summary>
			PRINTER_ATTRIBUTE_KEEPPRINTEDJOBS = 0x00000100,

			/// <summary>Printer is a local printer.</summary>
			PRINTER_ATTRIBUTE_LOCAL = 0x00000040,

			/// <summary>Printer is a network printer connection.</summary>
			PRINTER_ATTRIBUTE_NETWORK = 0x00000010,

			/// <summary>Indicates whether the printer is published in the directory service (DS).<189></summary>
			PRINTER_ATTRIBUTE_PUBLISHED = 0x00002000,

			/// <summary>
			/// If set, the printer spools and starts printing after the last page is spooled. If cleared, and PRINTER_ATTRIBUTE_DIRECT is
			/// not set, the printer spools and prints while spooling.
			/// </summary>
			PRINTER_ATTRIBUTE_QUEUED = 0x00000001,

			/// <summary>Indicates that only RAW data type print jobs MUST be spooled.<190></summary>
			PRINTER_ATTRIBUTE_RAW_ONLY = 0x00001000,

			/// <summary>Printer is shared.</summary>
			PRINTER_ATTRIBUTE_SHARED = 0x00000008,

			/// <summary>Printer is a redirected terminal server printer.</summary>
			PRINTER_ATTRIBUTE_TS = 0x00008000,

			/// <summary>Indicates whether the printer is currently connected. If the printer is not currently connected, print jobs
			/// continue to spool.<191></summary>
			PRINTER_ATTRIBUTE_WORK_OFFLINE = 0x00000400,

			/// <summary>Reserved.</summary>
			PRINTER_ATTRIBUTE_HIDDEN = 0x00000020,

			/// <summary>The printer was installed by using the Push Printer Connections user policy.</summary>
			PRINTER_ATTRIBUTE_PUSHED_USER = 0x00020000,

			/// <summary>The printer was installed by using the Push Printer Connections computer policy.</summary>
			PRINTER_ATTRIBUTE_PUSHED_MACHINE = 0x00040000,

			/// <summary>Printer is a per-machine connection.</summary>
			PRINTER_ATTRIBUTE_MACHINE = 0x00080000,

			/// <summary>A computer has connected to this printer and given it a friendly name.</summary>
			PRINTER_ATTRIBUTE_FRIENDLY_NAME = 0x00100000,

			/// <summary/>
			PRINTER_ATTRIBUTE_TS_GENERIC_DRIVER = 0x00200000,

			/// <summary/>
			PRINTER_ATTRIBUTE_PER_USER = 0x00400000,

			/// <summary/>
			PRINTER_ATTRIBUTE_ENTERPRISE_CLOUD = 0x00800000,
		}

		/// <summary>
		/// The conditions that will cause the change notification object to enter a signaled state. A change notification occurs when one
		/// or more of the specified conditions are met.
		/// </summary>
		[PInvokeData("", MSDNShortId = "4155ef5c-cd96-4960-919b-d9a495bb73a5")]
		[Flags]
		public enum PRINTER_CHANGE : uint
		{
			/// <summary>A printer was added to the server.</summary>
			PRINTER_CHANGE_ADD_PRINTER = 0x00000001,

			/// <summary>A printer was set.</summary>
			PRINTER_CHANGE_SET_PRINTER = 0x00000002,

			/// <summary>A printer was deleted.</summary>
			PRINTER_CHANGE_DELETE_PRINTER = 0x00000004,

			/// <summary>A printer connection has failed.</summary>
			PRINTER_CHANGE_FAILED_CONNECTION_PRINTER = 0x00000008,

			/// <summary>
			/// Notify of any changes to a printer. You can set this general flag or one or more of the following specific flags:
			/// PRINTER_CHANGE_ADD_PRINTER PRINTER_CHANGE_SET_PRINTER PRINTER_CHANGE_DELETE_PRINTER PRINTER_CHANGE_FAILED_CONNECTION_PRINTER
			/// </summary>
			PRINTER_CHANGE_PRINTER = 0x000000FF,

			/// <summary>A print job was sent to the printer.</summary>
			PRINTER_CHANGE_ADD_JOB = 0x00000100,

			/// <summary>A job was set.</summary>
			PRINTER_CHANGE_SET_JOB = 0x00000200,

			/// <summary>A job was deleted.</summary>
			PRINTER_CHANGE_DELETE_JOB = 0x00000400,

			/// <summary>Job data was written.</summary>
			PRINTER_CHANGE_WRITE_JOB = 0x00000800,

			/// <summary>
			/// Notify of any changes to a job. You can set this general flag or one or more of the following specific flags:
			/// PRINTER_CHANGE_ADD_JOB PRINTER_CHANGE_SET_JOB PRINTER_CHANGE_DELETE_JOB PRINTER_CHANGE_WRITE_JOB
			/// </summary>
			PRINTER_CHANGE_JOB = 0x0000FF00,

			/// <summary>A form was added to the server.</summary>
			PRINTER_CHANGE_ADD_FORM = 0x00010000,

			/// <summary>A form was set on the server.</summary>
			PRINTER_CHANGE_SET_FORM = 0x00020000,

			/// <summary>A form was deleted from the server.</summary>
			PRINTER_CHANGE_DELETE_FORM = 0x00040000,

			/// <summary>
			/// Notify of any changes to a form. You can set this general flag or one or more of the following specific flags:
			/// PRINTER_CHANGE_ADD_FORM PRINTER_CHANGE_SET_FORM PRINTER_CHANGE_DELETE_FORM
			/// </summary>
			PRINTER_CHANGE_FORM = 0x00070000,

			/// <summary>A port or monitor was added to the server.</summary>
			PRINTER_CHANGE_ADD_PORT = 0x00100000,

			/// <summary>A port was configured on the server.</summary>
			PRINTER_CHANGE_CONFIGURE_PORT = 0x00200000,

			/// <summary>A port or monitor was deleted from the server.</summary>
			PRINTER_CHANGE_DELETE_PORT = 0x00400000,

			/// <summary>
			/// Notify of any changes to a port. You can set this general flag or one or more of the following specific flags:
			/// PRINTER_CHANGE_ADD_PORT PRINTER_CHANGE_CONFIGURE_PORT PRINTER_CHANGE_DELETE_PORT
			/// </summary>
			PRINTER_CHANGE_PORT = 0x00700000,

			/// <summary>A print processor was added to the server.</summary>
			PRINTER_CHANGE_ADD_PRINT_PROCESSOR = 0x01000000,

			/// <summary>A print processor was deleted from the server.</summary>
			PRINTER_CHANGE_DELETE_PRINT_PROCESSOR = 0x04000000,

			/// <summary>
			/// Notify of any changes to a print processor. You can set this general flag or one or more of the following specific flags:
			/// PRINTER_CHANGE_ADD_PRINT_PROCESSOR PRINTER_CHANGE_DELETE_PRINT_PROCESSOR
			/// </summary>
			PRINTER_CHANGE_PRINT_PROCESSOR = 0x07000000,

			/// <summary>
			/// Windows 7: Notify of any changes to the server. This flag is not included in the changes monitored by setting the
			/// PRINTER_CHANGE_ALL value.
			/// </summary>
			PRINTER_CHANGE_SERVER = 0x08000000,

			/// <summary>A printer driver was added to the server.</summary>
			PRINTER_CHANGE_ADD_PRINTER_DRIVER = 0x10000000,

			/// <summary>A printer driver was set.</summary>
			PRINTER_CHANGE_SET_PRINTER_DRIVER = 0x20000000,

			/// <summary>A printer driver was deleted from the server.</summary>
			PRINTER_CHANGE_DELETE_PRINTER_DRIVER = 0x40000000,

			/// <summary>
			/// Notify of any changes to a printer driver. You can set this general flag or one or more of the following specific flags:
			/// PRINTER_CHANGE_ADD_PRINTER_DRIVER PRINTER_CHANGE_SET_PRINTER_DRIVER PRINTER_CHANGE_DELETE_PRINTER_DRIVER
			/// </summary>
			PRINTER_CHANGE_PRINTER_DRIVER = 0x70000000,

			/// <summary>The job timed out.</summary>
			PRINTER_CHANGE_TIMEOUT = 0x80000000,

			/// <summary>Notify if any of the preceding changes occur.</summary>
			PRINTER_CHANGE_ALL = 0x7F77FFFF,
		}

		/// <summary>Specifies the caching of a handle for a printer opened with <c>OpenPrinter2</c>.</summary>
		public enum PRINTER_CONNECTION_FLAGS
		{
			/// <summary>
			/// If this bit-flag is set, the printer connection is mismatched. The user can supply a local print driver as pszDriverName and
			/// use it to do the rendering instead of using the driver installed on the server printer to which the user is connected.
			/// </summary>
			PRINTER_CONNECTION_MISMATCH = 0x00000020,

			/// <summary>
			/// If this bit-flag is set then this call cannot display a dialog box. If a dialog box must be displayed to install a printer
			/// driver from the server and this bit-flag is set, the printer driver will not be installed, the printer connection will not
			/// be added, and the call will fail.
			/// <para>
			/// Windows 7: In Windows 7 and later versions of Windows, if this flag is set and the user is running in elevated mode, the Do
			/// you trust this printer? dialog will not be shown.
			/// </para>
			/// </summary>
			PRINTER_CONNECTION_NO_UI = 0x00000040,
		}

		public enum PRINTER_CONTROL
		{
			/// <summary>Pause the printer.</summary>
			PRINTER_CONTROL_PAUSE = 1,

			/// <summary>Resume a paused printer.</summary>
			PRINTER_CONTROL_RESUME = 2,

			/// <summary>Delete all print jobs in the printer.</summary>
			PRINTER_CONTROL_PURGE = 3,

			/// <summary>
			/// Set the printer status. Set the pPrinter parameter to a pointer to a DWORD value that specifies the new printer status.
			/// </summary>
			PRINTER_CONTROL_SET_STATUS = 4,
		}

		/// <summary>Specifies information about the returned data.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "0b0e2d0e-2625-4cab-a8f9-536185479443")]
		[Flags]
		public enum PRINTER_ENUM
		{
			/// <summary>Returns information about a default printer. Use <see cref="PRINTER_INFO_5"/>.</summary>
			PRINTER_ENUM_DEFAULT = 0x00000001,

			/// <summary>
			/// If the PRINTER_ENUM_NAME flag is not also passed, the function ignores the Name parameter, and enumerates the locally
			/// installed printers. If PRINTER_ENUM_NAME is also passed, the function enumerates the local printers on Name.
			/// </summary>
			PRINTER_ENUM_LOCAL = 0x00000002,

			/// <summary>The function enumerates the list of printers to which the user has made previous connections.</summary>
			PRINTER_ENUM_CONNECTIONS = 0x00000004,

			/// <summary>The function enumerates printers that are in the favorites list.</summary>
			PRINTER_ENUM_FAVORITE = 0x00000004,

			/// <summary>
			/// The function enumerates the printer identified by Name. This can be a server, a domain, or a print provider. If Name is
			/// NULL, the function enumerates available print providers.
			/// </summary>
			PRINTER_ENUM_NAME = 0x00000008,

			/// <summary>
			/// The function enumerates network printers and print servers in the computer's domain. This value is valid only if Level is 1.
			/// </summary>
			PRINTER_ENUM_REMOTE = 0x00000010,

			/// <summary>
			/// The function enumerates printers that have the shared attribute. Cannot be used in isolation; use an OR operation to combine
			/// with another PRINTER_ENUM type.
			/// </summary>
			PRINTER_ENUM_SHARED = 0x00000020,

			/// <summary>The function enumerates network printers in the computer's domain. This value is valid only if Level is 1.</summary>
			PRINTER_ENUM_NETWORK = 0x00000040,

			/// <summary>
			/// A print provider can set this flag as a hint to a calling application to enumerate this object further if default expansion
			/// is enabled. For example, when domains are enumerated, a print provider might indicate the user's domain by setting this flag.
			/// </summary>
			PRINTER_ENUM_EXPAND = 0x00004000,

			/// <summary>
			/// If this flag is set, the printer object may contain enumerable objects. For example, the object may be a print server that
			/// contains printers.
			/// </summary>
			PRINTER_ENUM_CONTAINER = 0x00008000,

			/// <summary>A mask value for all icon values.</summary>
			PRINTER_ENUM_ICONMASK = 0x00ff0000,

			/// <summary>
			/// Indicates that, where appropriate, an application should display an icon identifying the object as a top-level network name,
			/// such as Microsoft Windows Network.
			/// </summary>
			PRINTER_ENUM_ICON1 = 0x00010000,

			/// <summary>
			/// Indicates that, where appropriate, an application should display an icon that identifies the object as a network domain.
			/// </summary>
			PRINTER_ENUM_ICON2 = 0x00020000,

			/// <summary>
			/// Indicates that, where appropriate, an application should display an icon that identifies the object as a print server.
			/// </summary>
			PRINTER_ENUM_ICON3 = 0x00040000,

			/// <summary>Reserved.</summary>
			PRINTER_ENUM_ICON4 = 0x00080000,

			/// <summary>Reserved.</summary>
			PRINTER_ENUM_ICON5 = 0x00100000,

			/// <summary>Reserved.</summary>
			PRINTER_ENUM_ICON6 = 0x00200000,

			/// <summary>Reserved.</summary>
			PRINTER_ENUM_ICON7 = 0x00400000,

			/// <summary>Indicates that, where appropriate, an application should display an icon that identifies the object as a printer.</summary>
			PRINTER_ENUM_ICON8 = 0x00800000,

			/// <summary>Indicates that an application cannot display the printer object.</summary>
			PRINTER_ENUM_HIDE = 0x01000000,

			/// <summary>The function enumerates all print devices, including 3D printers.</summary>
			PRINTER_ENUM_CATEGORY_ALL = 0x02000000,

			/// <summary>The function enumerates only 3D printers.</summary>
			PRINTER_ENUM_CATEGORY_3D = 0x04000000,
		}

		/// <summary>The flag that determines the category of printers for which notifications will work.</summary>
		[PInvokeData("", MSDNShortId = "4155ef5c-cd96-4960-919b-d9a495bb73a5")]
		public enum PRINTER_NOTIFY_CATEGORY
		{
			/// <summary>FindNextPrinterChangeNotification returns notifications for 2D printers.</summary>
			PRINTER_NOTIFY_CATEGORY_2D = 0,

			/// <summary>FindNextPrinterChangeNotification returns notifications for both 2D and 3D printers.</summary>
			PRINTER_NOTIFY_CATEGORY_ALL = 0x001000,

			/// <summary>FindNextPrinterChangeNotification returns notifications only for 3D printers.</summary>
			PRINTER_NOTIFY_CATEGORY_3D = 0x002000,
		}

		/// <summary>
		/// Possible values for <see cref="PRINTER_NOTIFY_INFO_DATA.Field"/> when <see cref="PRINTER_NOTIFY_INFO_DATA.Type"/> is <see cref="NOTIFY_TYPE.PRINTER_NOTIFY_TYPE"/>.
		/// </summary>
		[PInvokeData("winspool.h", MSDNShortId = "7a7b9e01-32e0-47f8-a5b1-5f7e6a663714")]
		public enum PRINTER_NOTIFY_FIELD : ushort
		{
			/// <summary>Not supported.</summary>
			PRINTER_NOTIFY_FIELD_SERVER_NAME = 0x00,

			/// <summary>pBuf is a pointer to a null-terminated string containing the name of the printer.</summary>
			PRINTER_NOTIFY_FIELD_PRINTER_NAME = 0x01,

			/// <summary>pBuf is a pointer to a null-terminated string that identifies the share point for the printer.</summary>
			PRINTER_NOTIFY_FIELD_SHARE_NAME = 0x02,

			/// <summary>
			/// pBuf is a pointer to a null-terminated string containing the name of the port that the print jobs will be printed to. If
			/// "Printer Pooling" is selected, this is a comma separated list of ports.
			/// </summary>
			PRINTER_NOTIFY_FIELD_PORT_NAME = 0x03,

			/// <summary>pBuf is a pointer to a null-terminated string containing the name of the printer's driver.</summary>
			PRINTER_NOTIFY_FIELD_DRIVER_NAME = 0x04,

			/// <summary>
			/// pBuf is a pointer to a null-terminated string containing the new comment string, which is typically a brief description of
			/// the printer.
			/// </summary>
			PRINTER_NOTIFY_FIELD_COMMENT = 0x05,

			/// <summary>
			/// pBuf is a pointer to a null-terminated string containing the new physical location of the printer (for example, "Bldg. 38,
			/// Room 1164").
			/// </summary>
			PRINTER_NOTIFY_FIELD_LOCATION = 0x06,

			/// <summary>
			/// pBuf is a pointer to a DEVMODE structure that defines default printer data such as the paper orientation and the resolution.
			/// </summary>
			PRINTER_NOTIFY_FIELD_DEVMODE = 0x07,

			/// <summary>
			/// pBuf is a pointer to a null-terminated string that specifies the name of the file used to create the separator page. This
			/// page is used to separate print jobs sent to the printer.
			/// </summary>
			PRINTER_NOTIFY_FIELD_SEPFILE = 0x08,

			/// <summary>pBuf is a pointer to a null-terminated string that specifies the name of the print processor used by the printer.</summary>
			PRINTER_NOTIFY_FIELD_PRINT_PROCESSOR = 0x09,

			/// <summary>pBuf is a pointer to a null-terminated string that specifies the default print-processor parameters.</summary>
			PRINTER_NOTIFY_FIELD_PARAMETERS = 0x0A,

			/// <summary>pBuf is a pointer to a null-terminated string that specifies the data type used to record the print job.</summary>
			PRINTER_NOTIFY_FIELD_DATATYPE = 0x0B,

			/// <summary>
			/// pBuf is a pointer to a SECURITY_DESCRIPTOR structure for the printer. The pointer may be NULL if there is no security descriptor.
			/// </summary>
			PRINTER_NOTIFY_FIELD_SECURITY_DESCRIPTOR = 0x0C,

			/// <summary>
			/// adwData [0] specifies the printer attributes, which can be one of the following values: PRINTER_ATTRIBUTE_QUEUED,
			/// PRINTER_ATTRIBUTE_DIRECT, PRINTER_ATTRIBUTE_DEFAULT, PRINTER_ATTRIBUTE_SHARED
			/// </summary>
			PRINTER_NOTIFY_FIELD_ATTRIBUTES = 0x0D,

			/// <summary>adwData [0] specifies a priority value that the spooler uses to route print jobs.</summary>
			PRINTER_NOTIFY_FIELD_PRIORITY = 0x0E,

			/// <summary>adwData [0] specifies the default priority value assigned to each print job.</summary>
			PRINTER_NOTIFY_FIELD_DEFAULT_PRIORITY = 0x0F,

			/// <summary>
			/// adwData [0] specifies the earliest time at which the printer will print a job. (This value is specified in minutes elapsed
			/// since 12:00 A.M.)
			/// </summary>
			PRINTER_NOTIFY_FIELD_START_TIME = 0x10,

			/// <summary>
			/// adwData [0] specifies the latest time at which the printer will print a job. (This value is specified in minutes elapsed
			/// since 12:00 A.M.)
			/// </summary>
			PRINTER_NOTIFY_FIELD_UNTIL_TIME = 0x11,

			/// <summary>adwData [0] specifies the printer status. For a list of possible values, see the PRINTER_INFO_2 structure.</summary>
			PRINTER_NOTIFY_FIELD_STATUS = 0x12,

			/// <summary>Not supported.</summary>
			PRINTER_NOTIFY_FIELD_STATUS_STRING = 0x13,

			/// <summary>adwData [0] specifies the number of print jobs that have been queued for the printer.</summary>
			PRINTER_NOTIFY_FIELD_CJOBS = 0x14,

			/// <summary>adwData [0] specifies the average number of pages per minute that have been printed on the printer.</summary>
			PRINTER_NOTIFY_FIELD_AVERAGE_PPM = 0x15,

			/// <summary>Not supported.</summary>
			PRINTER_NOTIFY_FIELD_TOTAL_PAGES = 0x16,

			/// <summary>Not supported.</summary>
			PRINTER_NOTIFY_FIELD_PAGES_PRINTED = 0x17,

			/// <summary>Not supported.</summary>
			PRINTER_NOTIFY_FIELD_TOTAL_BYTES = 0x18,

			/// <summary>Not supported.</summary>
			PRINTER_NOTIFY_FIELD_BYTES_PRINTED = 0x19,

			/// <summary>This is set if the object GUID changes.</summary>
			PRINTER_NOTIFY_FIELD_OBJECT_GUID = 0x1A,

			/// <summary>This is set if the printer connection is renamed.</summary>
			PRINTER_NOTIFY_FIELD_FRIENDLY_NAME = 0x1B,

			/// <summary/>
			PRINTER_NOTIFY_FIELD_BRANCH_OFFICE_PRINTING = 0x1C,
		}

		/// <summary>Bit flags for <see cref="PRINTER_NOTIFY_OPTIONS"/>.</summary>
		[PInvokeData("", MSDNShortId = "712c546d-dbb3-4f78-b14e-fbb8619b57f9")]
		[Flags]
		public enum PRINTER_NOTIFY_OPTIONS_FLAG
		{
			/// <summary>Provides current data for all monitored printer information fields.</summary>
			PRINTER_NOTIFY_OPTIONS_REFRESH = 1
		}

		// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-option-flags typedef enum tagPRINTER_OPTION_FLAGS {
		// PRINTER_OPTION_NO_CACHE, PRINTER_OPTION_CACHE, PRINTER_OPTION_CLIENT_CHANGE } PRINTER_OPTION_FLAGS;
		[PInvokeData("Winspool.h", MSDNShortId = "e5a62322-723c-490d-8de1-f74dcac9e22d")]
		[Flags]
		public enum PRINTER_OPTION_FLAGS
		{
			/// <summary>The handle is not cached. All functions applied to a handle returned by OpenPrinter2 will go to the remote computer.</summary>
			PRINTER_OPTION_NO_CACHE = 1,

			/// <summary>The handle is cached. All functions applied to a handle returned by OpenPrinter2 will go to the local cache.</summary>
			PRINTER_OPTION_CACHE = 2,

			/// <summary>The handle returned by OpenPrinter2 can be used by SetPrinter to rename the printer connection.</summary>
			PRINTER_OPTION_CLIENT_CHANGE = 4,

			/// <summary></summary>
			PRINTER_OPTION_NO_CLIENT_DATA = 8,
		}

		/// <summary>The printer status.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "944cbfcd-9edf-4b60-a45c-9bb1839f8141")]
		public enum PRINTER_STATUS
		{
			/// <summary>The printer is busy.</summary>
			PRINTER_STATUS_BUSY = 0x00000200,

			/// <summary>The printer door is open.</summary>
			PRINTER_STATUS_DOOR_OPEN = 0x00400000,

			/// <summary>The printer is in an error state.</summary>
			PRINTER_STATUS_ERROR = 0x00000002,

			/// <summary>The printer is initializing.</summary>
			PRINTER_STATUS_INITIALIZING = 0x00008000,

			/// <summary>The printer is in an active input or output state.</summary>
			PRINTER_STATUS_IO_ACTIVE = 0x00000100,

			/// <summary>The printer is in a manual feed state.</summary>
			PRINTER_STATUS_MANUAL_FEED = 0x00000020,

			/// <summary>The printer is not available for printing.</summary>
			PRINTER_STATUS_NOT_AVAILABLE = 0x00001000,

			/// <summary>The printer is out of toner.</summary>
			PRINTER_STATUS_NO_TONER = 0x00040000,

			/// <summary>The printer is offline.</summary>
			PRINTER_STATUS_OFFLINE = 0x00000080,

			/// <summary>The printer's output bin is full.</summary>
			PRINTER_STATUS_OUTPUT_BIN_FULL = 0x00000800,

			/// <summary>The printer has run out of memory.</summary>
			PRINTER_STATUS_OUT_OF_MEMORY = 0x00200000,

			/// <summary>The printer cannot print the current page.</summary>
			PRINTER_STATUS_PAGE_PUNT = 0x00080000,

			/// <summary>Paper is stuck in the printer.</summary>
			PRINTER_STATUS_PAPER_JAM = 0x00000008,

			/// <summary>The printer is out of paper.</summary>
			PRINTER_STATUS_PAPER_OUT = 0x00000010,

			/// <summary>The printer has an unspecified paper problem.</summary>
			PRINTER_STATUS_PAPER_PROBLEM = 0x00000040,

			/// <summary>The printer is paused.</summary>
			PRINTER_STATUS_PAUSED = 0x00000001,

			/// <summary>
			/// The printer is being deleted as a result of a client's call to RpcDeletePrinter. No new jobs can be submitted on existing
			/// printer objects for that printer.
			/// </summary>
			PRINTER_STATUS_PENDING_DELETION = 0x00000004,

			/// <summary>The printer is in power-save mode.<182></summary>
			PRINTER_STATUS_POWER_SAVE = 0x01000000,

			/// <summary>The printer is printing.</summary>
			PRINTER_STATUS_PRINTING = 0x00000400,

			/// <summary>The printer is processing a print job.</summary>
			PRINTER_STATUS_PROCESSING = 0x00004000,

			/// <summary>The printer is offline.<183></summary>
			PRINTER_STATUS_SERVER_OFFLINE = 0x02000000,

			/// <summary>The printer status is unknown.<184></summary>
			PRINTER_STATUS_SERVER_UNKNOWN = 0x00800000,

			/// <summary>The printer is low on toner.</summary>
			PRINTER_STATUS_TONER_LOW = 0x00020000,

			/// <summary>The printer has an error that requires the user to do something.</summary>
			PRINTER_STATUS_USER_INTERVENTION = 0x00100000,

			/// <summary>The printer is waiting.</summary>
			PRINTER_STATUS_WAITING = 0x00002000,

			/// <summary>The printer is warming up.</summary>
			PRINTER_STATUS_WARMING_UP = 0x00010000,

			/// <summary>The printer driver needs an update.</summary>
			PRINTER_STATUS_DRIVER_UPDATE_NEEDED = 0x04000000,
		}

		/// <summary>Attribute flags for printer drivers.</summary>
		[PInvokeData("winspool.h", MSDNShortId = "6237def2-ffd4-4d93-b3a4-56f225793457")]
		[Flags]
		public enum PrinterDriverAttributes
		{
			/// <summary>The printer driver is part of a driver package. Windows Vista</summary>
			PRINTER_DRIVER_PACKAGE_AWARE = 0x00000001,

			/// <summary>The printer driver supports the Microsoft XPS format described in the XML Paper Specification: Overview, and also
			/// in Product Behavior, section <27>. Windows 8, Windows Server 2012</summary>
			PRINTER_DRIVER_XPS = 0x00000002,

			/// <summary>The printer driver is compatible with printer driver isolation. For more information, see Product Behavior, section
			/// <28>. Windows 7, Windows Server 2008 R2</summary>
			PRINTER_DRIVER_SANDBOX_ENABLED = 0x00000004,

			/// <summary>The printer driver is a class printer driver. Windows 8, Windows Server 2012</summary>
			PRINTER_DRIVER_CLASS = 0x00000008,

			/// <summary>The printer driver is a derived printer driver. Windows 8, Windows Server 2012</summary>
			PRINTER_DRIVER_DERIVED = 0x00000010,

			/// <summary>Printers using this printer driver cannot be shared. Windows 8, Windows Server 2012</summary>
			PRINTER_DRIVER_NOT_SHAREABLE = 0x00000020,

			/// <summary>The printer driver is intended for use with fax printers. Windows 8, Windows Server 2012</summary>
			PRINTER_DRIVER_CATEGORY_FAX = 0x00000040,

			/// <summary>The printer driver is intended for use with file printers. Windows 8, Windows Server 2012</summary>
			PRINTER_DRIVER_CATEGORY_FILE = 0x00000080,

			/// <summary>The printer driver is intended for use with virtual printers. Windows 8, Windows Server 2012</summary>
			PRINTER_DRIVER_CATEGORY_VIRTUAL = 0x00000100,

			/// <summary>The printer driver is intended for use with service printers. Windows 8, Windows Server 2012</summary>
			PRINTER_DRIVER_CATEGORY_SERVICE = 0x00000200,

			/// <summary>Printers that use this printer driver should follow the guidelines outlined in the USB Device Class Definition. For
			/// more information, see Product Behavior, section <36> Windows 8, Windows Server 2012</summary>
			PRINTER_DRIVER_SOFT_RESET_REQUIRED = 0x00000400,
		}
	}
}