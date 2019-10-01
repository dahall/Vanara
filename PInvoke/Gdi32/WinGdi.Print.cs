using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Gdi32
	{
		/*
		__Print Job Functions__
		AddJob
		The AddJob function adds a print job to the list of print jobs that can be scheduled by the print spooler. The function retrieves the name of the file you can use to store the job.
		ClosePrinter
		The ClosePrinter function closes the specified printer object.
		DocumentEvent
		The DocumentEvent function is an event handler for events associated with printing a document.
		DocumentProperties
		The DocumentProperties function retrieves or modifies printer initialization information or displays a printer-configuration property sheet for the specified printer.
		EndDocPrinter
		The EndDocPrinter function ends a print job for the specified printer.
		EndPagePrinter
		The EndPagePrinter function notifies the print spooler that the application is at the end of a page in a print job.
		EnumJobs
		The EnumJobs function retrieves information about a specified set of print jobs for a specified printer.
		GetJob
		The GetJob function retrieves information about a specified print job.
		OpenPrinter
		The OpenPrinter function retrieves a handle to the specified printer or print server or other types of handles in the print subsystem.
		OpenPrinter2
		Retrieves a handle to the specified printer, print server, or other types of handles in the print subsystem, while setting some of the printer options.
		ReportJobProcessingProgress
		Reports to the Print Spooler service whether an XPS print job is in the spooling or the rendering phase and what part of the processing is currently underway.
		ScheduleJob
		The ScheduleJob function requests that the print spooler schedule a specified print job for printing.
		SetJob
		The SetJob function pauses, resumes, cancels, or restarts a print job on a specified printer. You can also use the SetJob function to set print job parameters, such as the print job priority and the document name.
		StartDocPrinter
		The StartDocPrinter function notifies the print spooler that a document is to be spooled for printing.
		StartPagePrinter
		The StartPagePrinter function notifies the spooler that a page is about to be printed on the specified printer.

		__Printer User Interface Functions__
		AdvancedDocumentProperties
		The AdvancedDocumentProperties function displays a printer-configuration dialog box for the specified printer, allowing the user to configure that printer.
		ConfigurePort
		The ConfigurePort function displays the port-configuration dialog box for a port on the specified server.
		ConnectToPrinterDlg
		The ConnectToPrinterDlg function displays a dialog box that lets users browse and connect to printers on a network. If the user selects a printer, the function attempts to create a connection to it; if a suitable driver is not installed on the server, the user is given the option of creating a printer locally.
		PrinterProperties
		The PrinterProperties function displays a printer-properties property sheet for the specified printer.

		__Printer Functions__
		AbortPrinter
		The AbortPrinter function deletes a printer's spool file if the printer is configured for spooling.
		AddPrinter
		The AddPrinter function adds a printer to the list of supported printers for a specified server.
		AddPrinterConnection
		The AddPrinterConnection function adds a connection to the specified printer for the current user.
		AddPrinterConnection2
		Adds a connection to the specified printer for the current user and specifies connection details.
		DeletePrinter
		The DeletePrinter function deletes the specified printer object.
		DeletePrinterConnection
		The DeletePrinterConnection function deletes a connection to a printer that was established by a call to AddPrinterConnection or ConnectToPrinterDlg.
		DeletePrinterData
		The DeletePrinterData function deletes specified configuration data for a printer. A printer's configuration data consists of a set of named and typed values. The DeletePrinterData function deletes one of these values, specified by its value name.
		DeletePrinterDataEx
		The DeletePrinterDataEx function deletes a specified value from the configuration data for a printer. A printer's configuration data consists of a set of named and typed values stored in a hierarchy of registry keys. The function deletes a specified value under a specified key.
		DeletePrinterKey
		The DeletePrinterKey function deletes a specified key and all its subkeys for a specified printer.
		EnumPrinterData
		The EnumPrinterData function enumerates configuration data for a specified printer.
		EnumPrinterDataEx
		The EnumPrinterDataEx function enumerates all value names and data for a specified printer and key.
		EnumPrinterKey
		The EnumPrinterKey function enumerates the subkeys of a specified key for a specified printer.
		EnumPrinters
		The EnumPrinters function enumerates available printers, print servers, domains, or print providers.
		FlushPrinter
		The FlushPrinter function sends a buffer to the printer in order to clear it from a transient state.
		GetDefaultPrinter
		The GetDefaultPrinter function retrieves the printer name of the default printer for the current user on the local computer.
		GetPrinter
		The GetPrinter function retrieves information about a specified printer.
		GetPrinterData
		The GetPrinterData function retrieves configuration data for the specified printer or print server.
		GetPrinterDataEx
		The GetPrinterDataEx function retrieves configuration data for the specified printer or print server. GetPrinterDataEx can retrieve values stored by the SetPrinterData function. In addition, GetPrinterDataEx can retrieve values stored under a specified key by the SetPrinterDataEx function.
		IsValidDevmode
		The IsValidDevmode function verifies that the contents of a DEVMODE structure are valid.
		ReadPrinter
		The ReadPrinter function retrieves data from the specified printer.
		ResetPrinter
		The ResetPrinter function specifies the data type and device mode values to be used for printing documents submitted by the StartDocPrinter function. These values can be overridden by using the SetJob function after document printing has started.
		SetDefaultPrinter
		The SetDefaultPrinter function sets the printer name of the default printer for the current user on the local computer.
		SetPort
		The SetPort function sets the status associated with a printer port.
		SetPrinter
		The SetPrinter function sets the data for a specified printer or sets the state of the specified printer by pausing printing, resuming printing, or clearing all print jobs.
		SetPrinterData
		The SetPrinterData function sets the configuration data for a printer or print server.
		SetPrinterDataEx
		The SetPrinterDataEx function sets the configuration data for a printer or print server. The function stores the configuration data under the printer's registry key.
		WritePrinter
		The WritePrinter function notifies the print spooler that data should be written to the specified printer.

		__Printer Change Notification Functions__
		FindClosePrinterChangeNotification
		The FindClosePrinterChangeNotification function closes a change notification object created by calling the FindFirstPrinterChangeNotification function. The printer or print server associated with the change notification object will no longer be monitored by that object.
		FindFirstPrinterChangeNotification
		The FindFirstPrinterChangeNotification function creates a change notification object and returns a handle to the object. You can then use this handle in a call to one of the wait functions to monitor changes to the printer or print server.
		FindNextPrinterChangeNotification
		The FindNextPrinterChangeNotification function retrieves information about the most recent change notification for a change notification object associated with a printer or print server. Call this function when a wait operation on the change notification object is satisfied.
		FreePrinterNotifyInfo
		The FreePrinterNotifyInfo function frees a system-allocated buffer created by the FindNextPrinterChangeNotification function.

		__Printer Form Functions__
		AddForm
		The AddForm function adds a form to the list of available forms that can be selected for the specified printer.
		DeleteForm
		The DeleteForm function removes a form name from the list of supported forms.
		EnumForms
		The EnumForms function enumerates the forms supported by the specified printer.
		GetForm
		The GetForm function retrieves information about a specified form.
		SetForm
		The SetForm function sets the form information for the specified printer.

		__Print Spooler Functions__
		CloseSpoolFileHandle
		The CloseSpoolFileHandle function closes a handle to a spool file associated with the print job currently submitted by the application.
		CommitSpoolData
		The CommitSpoolData function notifies the print spooler that a specified amount of data has been written to a specified spool file and is ready to be rendered.
		GetPrintExecutionData
		The GetPrintExecutionData retrieves the current print context.
		GetSpoolFileHandle
		The GetSpoolFileHandle function retrieves a handle for the spool file associated with the job currently submitted by the application.
		*/
	}
}