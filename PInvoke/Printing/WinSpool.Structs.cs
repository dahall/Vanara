using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke;

public static partial class WinSpool
{
	/// <summary>
	/// The <c>ADDJOB_INFO_1</c> structure identifies a print job as well as the directory and file in which an application can store
	/// that job.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/addjob-info-1 typedef struct _ADDJOB_INFO_1 { LPTSTR Path; DWORD JobId;
	// } ADDJOB_INFO_1, *PADDJOB_INFO_1;
	[PInvokeData("winspool.h", MSDNShortId = "de915932-11a7-47e8-9be9-edab76d94189")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct ADDJOB_INFO_1
	{
		/// <summary>
		/// Pointer to a null-terminated string that contains the path and file name that the application can use to store the print job.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string Path;

		/// <summary>A handle to the print job.</summary>
		public uint JobId;
	}

	/// <summary>Represents a printer driver on which other printer drivers depend.</summary>
	/// <remarks>This structure can represent a manufacturer's base driver on which the drivers for various printer models are dependent.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/core-printer-driver typedef struct _CORE_PRINTER_DRIVER { GUID
	// CoreDriverGUID; FILETIME ftDriverDate; DWORDLONG dwlDriverVersion; TCHAR szPackageID[MAX_PATH]; } CORE_PRINTER_DRIVER, *PCORE_PRINTER_DRIVER;
	[PInvokeData("winspool.h", MSDNShortId = "b03f9ac1-7ad2-4aee-b496-e1ee15ba7d38")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct CORE_PRINTER_DRIVER
	{
		/// <summary>The GUID of the core printer driver.</summary>
		public Guid CoreDriverGUID;

		/// <summary>The date and time of the latest version of the core printer driver.</summary>
		public FILETIME ftDriverDate;

		/// <summary>The version ID of the latest version of the core printer driver.</summary>
		public ulong dwlDriverVersion;

		/// <summary>The path to the driver package that contains the core printer driver.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string szPackageID;
	}

	/// <summary>The <c>DATATYPES_INFO_1</c> structure contains information about the data type used to record a print job.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/datatypes-info-1 typedef struct _DATATYPES_INFO_1 { LPTSTR pName; }
	// DATATYPES_INFO_1, *PDATATYPES_INFO_1;
	[PInvokeData("winspool.h", MSDNShortId = "6169006c-12d4-4608-865c-732f04107f9f")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DATATYPES_INFO_1
	{
		/// <summary>Pointer to a null-terminated string that identifies the data type used to record a print job.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pName;
	}

	/// <summary>The <c>DOC_INFO_1</c> structure describes a document that will be printed.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/doc-info-1 typedef struct _DOC_INFO_1 { LPTSTR pDocName; LPTSTR
	// pOutputFile; LPTSTR pDatatype; } DOC_INFO_1;
	[PInvokeData("winspool.h", MSDNShortId = "142d988b-dd74-4312-8b27-331a7ec70344")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DOC_INFO_1
	{
		/// <summary>Pointer to a null-terminated string that specifies the name of the document.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDocName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of an output file. To print to a printer, set this to <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pOutputFile;

		/// <summary>Pointer to a null-terminated string that identifies the type of data used to record the document.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDatatype;
	}

	/// <summary>The <c>DOC_INFO_2</c> structure describes a document that will be printed.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/doc-info-2 typedef struct _DOC_INFO_2 { LPTSTR pDocName; LPTSTR
	// pOutputFile; LPTSTR pDatatype; DWORD dwMode; DWORD JobId; } DOC_INFO_2, *PDOC_INFO_2;
	[PInvokeData("winspool.h", MSDNShortId = "d62333f3-cc39-4c9b-8fb3-02a2d24bbbad")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DOC_INFO_2
	{
		/// <summary>Pointer to a null-terminated string that specifies the name of the document.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDocName;

		/// <summary>Pointer to a null-terminated string that specifies the name of an output file.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pOutputFile;

		/// <summary>Pointer to a null-terminated string that identifies the type of data used to record the document.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDatatype;

		/// <summary>
		/// Informs the print spooler of the nature of the data to follow. If this value is zero, the print spooler treats the data sent
		/// by subsequent calls to <c>WritePrinter</c> as a normal print job (whether or not it is spooled depends on the printer
		/// property). If this value is DI_CHANNEL, only a communications channel is opened. In this case, the data passed into
		/// subsequent calls to <c>WritePrinter</c> is sent to the printer or subsequent calls to <c>ReadPrinter</c> retrieve data from
		/// the printer. This mode remains effective until <c>EndDoc</c> is called.
		/// </summary>
		public uint dwMode;

		/// <summary>Reserved for internal use; should be zero.</summary>
		public uint JobId;
	}

	/// <summary>The <c>DOC_INFO_3</c> structure describes a document that will be printed.</summary>
	/// <remarks>
	/// The DI_MEMORYMAP_WRITE setting in <c>DOC_INFO_3</c> is an optimization. This allows GDI to map spool files in the application
	/// and speed up the recording.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/doc-info-3 typedef struct _DOC_INFO_3 { LPTSTR pDocName; LPTSTR
	// pOutputFile; LPTSTR pDatatype; DWORD dwFlags; } DOC_INFO_3, *PDOC_INFO_3;
	[PInvokeData("winspool.h", MSDNShortId = "6e7b6727-da04-4f67-af77-6b51c68a4eb3")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DOC_INFO_3
	{
		/// <summary>Pointer to a null-terminated string that specifies the name of the document.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDocName;

		/// <summary>Pointer to a null-terminated string that specifies the name of an output file.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pOutputFile;

		/// <summary>Pointer to a null-terminated string that identifies the type of data used to record the document.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDatatype;

		/// <summary>
		/// <para>Flags. Currently, it can be <c>NULL</c> or the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DI_MEMORYMAP_WRITE</term>
		/// <term>Causes StartDocPrinter to not use AddJob and ScheduleJob for local printing.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwFlags;
	}

	/// <summary>The <c>DRIVER_INFO_1</c> structure identifies a printer driver.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/driver-info-1 typedef struct _DRIVER_INFO_1 { LPTSTR pName; }
	// DRIVER_INFO_1, *PDRIVER_INFO_1;
	[PInvokeData("winspool.h", MSDNShortId = "9435192b-3eba-4937-8cd3-bff4e9eb84d3")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DRIVER_INFO_1
	{
		/// <summary>Pointer to a null-terminated string that specifies the name of a printer driver.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pName;
	}

	/// <summary>
	/// The <c>DRIVER_INFO_2</c> structure identifies a printer driver, the driver version number, the environment for which the driver
	/// was written, the name of the file in which the driver is stored, and so on.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/driver-info-2 typedef struct _DRIVER_INFO_2 { DWORD cVersion; LPTSTR
	// pName; LPTSTR pEnvironment; LPTSTR pDriverPath; LPTSTR pDataFile; LPTSTR pConfigFile; } DRIVER_INFO_2, *PDRIVER_INFO_2;
	[PInvokeData("winspool.h", MSDNShortId = "cca1227d-69b9-44df-8dac-384c2f8843ae")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DRIVER_INFO_2
	{
		/// <summary>The operating system version for which the driver was written. The supported value is 3.</summary>
		public uint cVersion;

		/// <summary>A pointer to a null-terminated string that specifies the name of the driver (for example, "QMS 810").</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pName;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the environment for which the driver was written (for example, Windows
		/// x86, Windows IA64, and Windows x64).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pEnvironment;

		/// <summary>
		/// A pointer to null-terminated string that specifies a file name or full path and file name for the file that contains the
		/// device driver (for example, "c:\drivers\pscript.dll").
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDriverPath;

		/// <summary>
		/// A pointer to a null-terminated string that specifies a file name or a full path and file name for the file that contains
		/// driver data (for example, "c:\drivers\Qms810.ppd").
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDataFile;

		/// <summary>
		/// A pointer to a null-terminated string that specifies a file name or a full path and file name for the device-driver's
		/// configuration .dll (for example, "c:\drivers\Pscrptui.dll").
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pConfigFile;
	}

	/// <summary>The <c>DRIVER_INFO_3</c> structure contains printer driver information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/driver-info-3 typedef struct _DRIVER_INFO_3 { DWORD cVersion; LPTSTR
	// pName; LPTSTR pEnvironment; LPTSTR pDriverPath; LPTSTR pDataFile; LPTSTR pConfigFile; LPTSTR pHelpFile; LPTSTR pDependentFiles;
	// LPTSTR pMonitorName; LPTSTR pDefaultDataType; } DRIVER_INFO_3, *PDRIVER_INFO_3;
	[PInvokeData("winspool.h", MSDNShortId = "ccf87319-0bcf-4f71-8de3-0190459d2b0e")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DRIVER_INFO_3
	{
		/// <summary>
		/// The operating system version for which the driver was written. The supported values are 3 and 4, which represent the V3 and
		/// V4 drivers, respectively.
		/// </summary>
		public uint cVersion;

		/// <summary>A pointer to a null-terminated string that specifies the name of the driver (for example, "QMS 810").</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pName;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the environment for which the driver was written (for example, Windows
		/// x86, Windows IA64, and Windows x64).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pEnvironment;

		/// <summary>
		/// A pointer to a null-terminated string that specifies a file name or full path and file name for the file that contains the
		/// device driver (for example, "C:\DRIVERS\Pscript.dll").
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDriverPath;

		/// <summary>
		/// A pointer to a null-terminated string that specifies a file name or a full path and file name for the file that contains
		/// driver data (for example, "C:\DRIVERS\Qms810.ppd").
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDataFile;

		/// <summary>
		/// A pointer to a null-terminated string that specifies a file name or a full path and file name for the device driver's
		/// configuration dynamic-link library (for example, "C:\DRIVERS\Pscrptui.dll").
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pConfigFile;

		/// <summary>
		/// A pointer to a null-terminated string that specifies a file name or a full path and file name for the device driver's help file.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pHelpFile;

		/// <summary>
		/// A pointer to a MultiSZ buffer that contains a sequence of null-terminated strings. Each null-terminated string in the buffer
		/// contains the name of a file the driver depends on. The sequence of strings is terminated by an empty, zero-length string. If
		/// <c>pDependentFiles</c> is not <c>NULL</c> and does not contain any file names, it will point to a buffer that contains two
		/// empty strings.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDependentFiles;

		/// <summary>
		/// A pointer to a null-terminated string that specifies a language monitor (for example, "PJL monitor"). This member can be
		/// <c>NULL</c> and should be specified only for printers capable of bidirectional communication.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pMonitorName;

		/// <summary>A pointer to a null-terminated string that specifies the default data type of the print job (for example, "EMF").</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDefaultDataType;
	}

	/// <summary>The <c>DRIVER_INFO_4</c> structure contains printer driver information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/driver-info-4 typedef struct _DRIVER_INFO_4 { DWORD cVersion; LPTSTR
	// pName; LPTSTR pEnvironment; LPTSTR pDriverPath; LPTSTR pDataFile; LPTSTR pConfigFile; LPTSTR pHelpFile; LPTSTR pDependentFiles;
	// LPTSTR pMonitorName; LPTSTR pDefaultDataType; LPTSTR pszzPreviousNames; } DRIVER_INFO_4, *PDRIVER_INFO_4;
	[PInvokeData("winspool.h", MSDNShortId = "63000de6-74e7-4427-98d7-7bbd2dd61080")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DRIVER_INFO_4
	{
		/// <summary>The operating system version for which the driver was written. The supported value is 3.</summary>
		public uint cVersion;

		/// <summary>Pointer to a null-terminated string that specifies the name of the driver (for example, "QMS 810").</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the environment for which the driver was written (for example, Windows
		/// x86, Windows IA64, and Windows x64).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pEnvironment;

		/// <summary>
		/// Pointer to a null-terminated string that specifies a file name or full path and file name for the file that contains the
		/// device driver (for example, C:\DRIVERS\Pscript.dll).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDriverPath;

		/// <summary>
		/// Pointer to a null-terminated string that specifies a file name or a full path and file name for the file that contains
		/// driver data (for example, C:\DRIVERS\Qms810.ppd).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDataFile;

		/// <summary>
		/// Pointer to a null-terminated string that specifies a file name or a full path and file name for the device driver's
		/// configuration dynamic-link library (for example, C:\DRIVERS\Pscrptui.dll).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pConfigFile;

		/// <summary>
		/// Pointer to a null-terminated string that specifies a file name or a full path and file name for the device driver's help file.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pHelpFile;

		/// <summary>
		/// A pointer to a MultiSZ buffer that contains a sequence of null-terminated strings. Each null-terminated string in the buffer
		/// contains the name of a file the driver depends on. The sequence of strings is terminated by an empty, zero-length string. If
		/// <c>pDependentFiles</c> is not <c>NULL</c> and does not contain any file names, it will point to a buffer that contains two
		/// empty strings.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDependentFiles;

		/// <summary>
		/// A pointer to a null-terminated string that specifies a language monitor (for example, PJL monitor). This member can be
		/// <c>NULL</c> and should be specified only for printers capable of bidirectional communication.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pMonitorName;

		/// <summary>A pointer to a null-terminated string that specifies the default data type of the print job (for example, EMF).</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDefaultDataType;

		/// <summary>
		/// A pointer to a null-terminated string that specifies previous printer driver names that are compatible with this driver. For
		/// example, OldName1\0OldName2\0\0.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszzPreviousNames;
	}

	/// <summary>The <c>DRIVER_INFO_5</c> structure contains printer driver information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/driver-info-5 typedef struct _DRIVER_INFO_5 { DWORD cVersion; LPTSTR
	// pName; LPTSTR pEnvironment; LPTSTR pDriverPath; LPTSTR pDataFile; LPTSTR pConfigFile; DWORD dwDriverAttributes; DWORD
	// dwConfigVersion; DWORD dwDriverVersion; } DRIVER_INFO_5, *PDRIVER_INFO_5;
	[PInvokeData("winspool.h", MSDNShortId = "6fb63a9f-5227-46a3-97dc-8de1968e9d63")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DRIVER_INFO_5
	{
		/// <summary>The operating system version for which the driver was written. The supported value is 3.</summary>
		public uint cVersion;

		/// <summary>Pointer to a null-terminated string that specifies the name of the driver (for example, QMS 810).</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the environment for which the driver was written (for example, Windows
		/// x86, Windows IA64, and Windows x64).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pEnvironment;

		/// <summary>
		/// Pointer to a null-terminated string that specifies a file name or a full path and file name for the file that contains the
		/// device driver (for example, C:\DRIVERS\Pscript.dll).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDriverPath;

		/// <summary>
		/// Pointer to a null-terminated string that specifies a file name or a full path and file name for the file that contains
		/// driver data (for example, C:\DRIVERS\Qms810.ppd).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDataFile;

		/// <summary>
		/// Pointer to a null-terminated string that specifies a file name or a full path and file name for the device driver's
		/// configuration dynamic-link library (for example, C:\DRIVERS\Pscrptui.dll).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pConfigFile;

		/// <summary>Driver attributes, like UMPD/KMPD.</summary>
		public uint dwDriverAttributes;

		/// <summary>
		/// Number of times the configuration file for this driver has been upgraded or downgraded since the last spooler restart.
		/// </summary>
		public uint dwConfigVersion;

		/// <summary>Number of times the driver file for this driver has been upgraded or downgraded since the last spooler restart.</summary>
		public uint dwDriverVersion;
	}

	/// <summary>The <c>DRIVER_INFO_6</c> structure contains printer driver information.</summary>
	/// <remarks>
	/// <para>The strings for these members are contained in the .inf file that is used to add the driver.</para>
	/// <para>
	/// If you call <c>AddPrinterDriver</c> or <c>AddPrinterDriverEx</c> with Level not equal to 6, and then you call
	/// <c>GetPrinterDriver</c> or <c>EnumPrinterDrivers</c> with Level equal to 6, the <c>DRIVER_INFO_6</c> structure is returned with
	/// <c>pszMfgName</c>, <c>pszOEMUrl</c>, <c>pszHardwareID</c>, and <c>pszProvider</c> set to <c>NULL</c>, <c>dwlDriverVersion</c>
	/// set to 0, and <c>ftDriverDate</c> set to (0,0).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/driver-info-6 typedef struct _DRIVER_INFO_6 { DWORD cVersion; LPTSTR
	// pName; LPTSTR pEnvironment; LPTSTR pDriverPath; LPTSTR pDataFile; LPTSTR pConfigFile; LPTSTR pHelpFile; LPTSTR pDependentFiles;
	// LPTSTR pMonitorName; LPTSTR pDefaultDataType; LPTSTR pszzPreviousNames; FILETIME ftDriverDate; DWORDLONG dwlDriverVersion; LPTSTR
	// pszMfgName; LPTSTR pszOEMUrl; LPTSTR pszHardwareID; LPTSTR pszProvider; } DRIVER_INFO_6, *PDRIVER_INFO_6, *LPDRIVER_INFO_6;
	[PInvokeData("winspool.h", MSDNShortId = "9771cbb5-caaa-4b7d-9a96-d24234440bac")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DRIVER_INFO_6
	{
		/// <summary>The operating system version for which the driver was written. The supported value is 3.</summary>
		public uint cVersion;

		/// <summary>Pointer to a null-terminated string that specifies the name of the driver (for example, QMS 810).</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the environment for which the driver was written (for example, Windows NT
		/// x86, Windows IA64, and Windows x64.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pEnvironment;

		/// <summary>
		/// Pointer to a null-terminated string that specifies a file name or a full path and file name for the file that contains the
		/// device driver (for example, C:\DRIVERS\Pscript.dll).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDriverPath;

		/// <summary>
		/// Pointer to a null-terminated string that specifies a file name or a full path and file name for the file that contains
		/// driver data (for example, C:\DRIVERS\Qms810.ppd).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDataFile;

		/// <summary>
		/// Pointer to a null-terminated string that specifies a file name or a full path and file name for the device driver's
		/// configuration dynamic-link library (for example, C:\DRIVERS\Pscrptui.dll).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pConfigFile;

		/// <summary>
		/// Pointer to a null-terminated string that specifies a file name or a full path and file name for the device driver's help
		/// file (for example, C:\DRIVERS\Pscrptui.hlp).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pHelpFile;

		/// <summary>
		/// A pointer to a MultiSZ buffer that contains a sequence of null-terminated strings. Each null-terminated string in the buffer
		/// contains the name of a file the driver depends on. The sequence of strings is terminated by an empty, zero-length string. If
		/// <c>pDependentFiles</c> is not <c>NULL</c> and does not contain any file names, it will point to a buffer that contains two
		/// empty strings.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDependentFiles;

		/// <summary>
		/// A pointer to a null-terminated string that specifies a language monitor (for example, "PJL monitor"). This member can be
		/// <c>NULL</c> and should be specified only for printers capable of bidirectional communication.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pMonitorName;

		/// <summary>A pointer to a null-terminated string that specifies the default data type of the print job (for example, "EMF").</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDefaultDataType;

		/// <summary>
		/// A pointer to a null-terminated string that specifies previous printer driver names that are compatible with this driver. For
		/// example, OldName1\0OldName2\0\0.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszzPreviousNames;

		/// <summary>The date of the driver package, as coded in the driver files.</summary>
		public FILETIME ftDriverDate;

		/// <summary>Version number of the driver. This comes out of the version structure of the driver.</summary>
		public ulong dwlDriverVersion;

		/// <summary>Pointer to a null-terminated string that specifies the manufacturer's name.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszMfgName;

		/// <summary>Pointer to a null-terminated string that specifies the URL for the manufacturer.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszOEMUrl;

		/// <summary>Pointer to a null-terminated string that specifies the hardware ID for the printer driver.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszHardwareID;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the provider of the printer driver (for example, "Microsoft Windows 2000")
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszProvider;
	}

	/// <summary>Contains printer driver information.</summary>
	/// <remarks>The strings for these members are contained in the .inf file that is used to add the driver.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/driver-info-8 typedef struct _DRIVER_INFO_8 { DWORD cVersion; LPTSTR
	// pName; LPTSTR pEnvironment; LPTSTR pDriverPath; LPTSTR pDataFile; LPTSTR pConfigFile; LPTSTR pHelpFile; LPTSTR pDependentFiles;
	// LPTSTR pMonitorName; LPTSTR pDefaultDataType; LPTSTR pszzPreviousNames; FILETIME ftDriverDate; DWORDLONG dwlDriverVersion; LPTSTR
	// pszMfgName; LPTSTR pszOEMUrl; LPTSTR pszHardwareID; LPTSTR pszProvider; LPTSTR pszPrintProcessor; LPTSTR pszVendorSetup; LPTSTR
	// pszzColorProfiles; LPTSTR pszInfPath; DWORD dwPrinterDriverAttributes; LPTSTR pszzCoreDriverDependencies; FILETIME
	// ftMinInboxDriverVerDate; DWORDLONG dwlMinInboxDriverVerVersion; } DRIVER_INFO_8, *PDRIVER_INFO_8, *LPDRIVER_INFO_8;
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DRIVER_INFO_8
	{
		/// <summary>The operating system version for which the driver was written. The supported value is 3.</summary>
		public uint cVersion;

		/// <summary>A pointer to a null-terminated string that specifies the name of the driver (for example, QMS 810).</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pName;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the environment for which the driver was written (for example, Windows
		/// x86, Windows IA64, and Windows x64.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pEnvironment;

		/// <summary>
		/// A pointer to a null-terminated string that specifies a file name or a full path and file name for the file that contains the
		/// device driver (for example, C:\DRIVERS\Pscript.dll).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDriverPath;

		/// <summary>
		/// A pointer to a null-terminated string that specifies a file name or a full path and file name for the file that contains
		/// driver data (for example, C:\DRIVERS\Qms810.ppd).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDataFile;

		/// <summary>
		/// A pointer to a null-terminated string that specifies a file name or a full path and file name for the device driver's
		/// configuration dynamic-link library (for example, C:\DRIVERS\Pscrptui.dll).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pConfigFile;

		/// <summary>
		/// A pointer to a null-terminated string that specifies a file name or a full path and file name for the device driver's help
		/// file (for example, C:\DRIVERS\Pscrptui.hlp).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pHelpFile;

		/// <summary>
		/// A pointer to a MultiSZ buffer that contains a sequence of null-terminated strings. Each null-terminated string in the buffer
		/// contains the name of a file the driver depends on. The sequence of strings is terminated by an empty, zero-length string. If
		/// <c>pDependentFiles</c> is not <c>NULL</c> and does not contain any file names, it will point to a buffer that contains two
		/// empty strings.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDependentFiles;

		/// <summary>
		/// A pointer to a null-terminated string that specifies a language monitor (for example, "PJL monitor"). This member can be
		/// <c>NULL</c> and should be specified only for printers capable of bidirectional communication.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pMonitorName;

		/// <summary>A pointer to a null-terminated string that specifies the default data type of the print job (for example, "EMF").</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDefaultDataType;

		/// <summary>
		/// A pointer to a null-terminated string that specifies previous printer driver names that are compatible with this driver. For
		/// example, OldName1\0OldName2\0\0.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszzPreviousNames;

		/// <summary>The date of the driver package, as coded in the driver files.</summary>
		public FILETIME ftDriverDate;

		/// <summary>The version number of the driver. This comes from the version structure of the driver.</summary>
		public ulong dwlDriverVersion;

		/// <summary>A pointer to a null-terminated string that specifies the manufacturer's name.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszMfgName;

		/// <summary>A pointer to a null-terminated string that specifies the URL for the manufacturer.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszOEMUrl;

		/// <summary>A pointer to a null-terminated string that specifies the hardware ID for the printer driver.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszHardwareID;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the provider of the printer driver (for example, "Microsoft Windows 2000").
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszProvider;

		/// <summary>A pointer to a null-terminated string that specifies the print processor (for example, "WinPrint").</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszPrintProcessor;

		/// <summary>A pointer to a null-terminated string that specifies the vendor's driver setup DLL and entry point.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszVendorSetup;

		/// <summary>A pointer to a null-terminated string that specifies the color profiles associated with the driver.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszzColorProfiles;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the path to the driver's .inf file in the driver store. (See Remarks.)
		/// This must be <c>NULL</c> if the DRIVER_INFO_8 is being passed to <c>AddPrinterDriver</c> or <c>AddPrinterDriverEx</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszInfPath;

		/// <summary>
		/// <para>
		/// Attribute flags for printer drivers. This must be 0 if the DRIVER_INFO_8 is being passed to <c>AddPrinterDriver</c> or
		/// <c>AddPrinterDriverEx</c>. Otherwise, it can be any combination of the following flags:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag name/value</term>
		/// <term>Meaning</term>
		/// <term>Minimum OS</term>
		/// </listheader>
		/// <item>
		/// <term>PRINTER_DRIVER_PACKAGE_AWARE 0x00000001</term>
		/// <term>The printer driver is part of a driver package.</term>
		/// <term>Windows Vista</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_DRIVER_XPS 0x00000002</term>
		/// <term>
		/// The printer driver supports the Microsoft XPS format described in the XML Paper Specification: Overview, and also in Product
		/// Behavior, section &lt;27&gt;.
		/// </term>
		/// <term>Windows 8 Windows Server 2012</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_DRIVER_SANDBOX_ENABLED 0x00000004</term>
		/// <term>
		/// The printer driver is compatible with printer driver isolation. For more information, see Product Behavior, section &lt;28&gt;.
		/// </term>
		/// <term>Windows 7 Windows Server 2008 R2</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_DRIVER_CLASS 0x00000008</term>
		/// <term>The printer driver is a class printer driver.</term>
		/// <term>Windows 8 Windows Server 2012</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_DRIVER_DERIVED 0x00000010</term>
		/// <term>The printer driver is a derived printer driver.</term>
		/// <term>Windows 8 Windows Server 2012</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_DRIVER_NOT_SHAREABLE 0x00000020</term>
		/// <term>Printers using this printer driver cannot be shared.</term>
		/// <term>Windows 8 Windows Server 2012</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_DRIVER_CATEGORY_FAX 0x00000040</term>
		/// <term>The printer driver is intended for use with fax printers.</term>
		/// <term>Windows 8 Windows Server 2012</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_DRIVER_CATEGORY_FILE 0x00000080</term>
		/// <term>The printer driver is intended for use with file printers.</term>
		/// <term>Windows 8 Windows Server 2012</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_DRIVER_CATEGORY_VIRTUAL 0x00000100</term>
		/// <term>The printer driver is intended for use with virtual printers.</term>
		/// <term>Windows 8 Windows Server 2012</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_DRIVER_CATEGORY_SERVICE 0x00000200</term>
		/// <term>The printer driver is intended for use with service printers.</term>
		/// <term>Windows 8 Windows Server 2012</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_DRIVER_SOFT_RESET_REQUIRED 0x00000400</term>
		/// <term>
		/// Printers that use this printer driver should follow the guidelines outlined in the USB Device Class Definition. For more
		/// information, see Product Behavior, section &lt;36&gt;
		/// </term>
		/// <term>Windows 8 Windows Server 2012</term>
		/// </item>
		/// </list>
		/// </summary>
		public PrinterDriverAttributes dwPrinterDriverAttributes;

		/// <summary>
		/// A pointer to a null-terminated multi-string that specifies all the core printer drivers that the driver depends on. This
		/// must be <c>NULL</c> if the <c>DRIVER_INFO_8</c> is being passed to <c>AddPrinterDriver</c> or <c>AddPrinterDriverEx</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszzCoreDriverDependencies;

		/// <summary>The earliest allowed date of any drivers that shipped with Windows and on which this driver depends.</summary>
		public FILETIME ftMinInboxDriverVerDate;

		/// <summary>The earliest allowed version of any drivers that shipped with Windows and on which this driver depends.</summary>
		public ulong dwlMinInboxDriverVerVersion;
	}

	/// <summary>
	/// The <c>FORM_INFO_1</c> structure contains information about a print form. The information includes the print form's origin, its
	/// name, its dimensions, and the dimensions of its printable area.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/form-info-1 typedef struct _FORM_INFO_1 { DWORD Flags; LPTSTR pName;
	// SIZEL Size; RECTL ImageableArea; } FORM_INFO_1, *PFORM_INFO_1;
	[PInvokeData("winspool.h", MSDNShortId = "1c42ea6c-82cf-463c-bc67-44a8d8c4a1e7")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct FORM_INFO_1
	{
		/// <summary>
		/// <para>The form properties. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FORM_USER</term>
		/// <term>If this bit flag is set, the form has been defined by the user. Forms with this flag set are defined in the registry.</term>
		/// </item>
		/// <item>
		/// <term>FORM_BUILTIN</term>
		/// <term>
		/// If this bit-flag is set, the form is part of the spooler. Form definitions with this flag set do not appear in the registry.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FORM_PRINTER</term>
		/// <term>If this bit flag is set, the form is associated with a certain printer, and its definition appears in the registry.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FormFlags Flags;

		/// <summary>Pointer to a null-terminated string that specifies the name of the form. The form name cannot exceed 31 characters.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pName;

		/// <summary>The width and height, in thousandths of millimeters, of the form.</summary>
		public SIZE Size;

		/// <summary>The width and height, in thousandths of millimeters, of the form.</summary>
		public RECT ImageableArea;
	}

	/// <summary>Contains information about a localizable print form.</summary>
	/// <remarks>
	/// <para>On a call to <c>AddForm</c> or <c>SetForm</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If <c>StringType</c> is STRING_NONE, both <c>pMuiDll</c> and <c>pDisplayName</c> must be <c>NULL</c> and both
	/// <c>dwResourceId</c> and <c>wLangId</c> must be 0.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If <c>StringType</c> is STRING_MUIDLL, <c>pDisplayName</c> must be <c>NULL</c> and <c>wLangId</c> must be 0.</term>
	/// </item>
	/// <item>
	/// <term>If <c>StringType</c> is STRING_LANGPAIR, <c>pMuiDll</c> must be <c>NULL</c> and <c>dwResourceId</c> must be 0.</term>
	/// </item>
	/// </list>
	/// <para>For a <c>FORM_INFO_2</c> returned by a call to <c>GetForm</c> or <c>EnumForms</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If <c>StringType</c> is both STRING_MUIDLL and STRING_LANGPAIR, <c>pMuiDll</c>, <c>pDisplayName</c>, <c>dwResourceId</c>, and
	/// <c>wLangId</c> will all have valid values.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If <c>StringType</c> is STRING_MUIDLL only, <c>pMuiDll</c> and <c>dwResourceId</c> will have valid values. <c>pDisplayName</c>
	/// will be <c>NULL</c> and <c>wLangId</c> will be 0.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If <c>StringType</c> is STRING_LANGPAIR only, <c>pDisplayName</c> and <c>wLangId</c> will have valid values. <c>pMuiDll</c> will
	/// be <c>NULL</c> and <c>dwResourceId</c> will be 0.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/form-info-2 typedef struct _FORM_INFO_2 { DWORD Flags; LPTSTR pName;
	// SIZEL Size; RECTL ImageableArea; LPCSTR pKeyword; DWORD StringType; LPCTSTR pMuiDll; DWORD dwResourceId; LPCTSTR pDisplayName;
	// LANGID wLangId; } FORM_INFO_2, *PFORM_INFO_2;
	[PInvokeData("winspool.h", MSDNShortId = "5cc11a77-2b9d-44a4-88de-6ed0b7460bc8")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct FORM_INFO_2
	{
		/// <summary>
		/// <para>
		/// The form properties. The following values are defined, but only one can be set. When the <c>FORM_INFO_2</c> is returned by
		/// <c>GetForm</c> or <c>EnumForms</c>, <c>Flags</c> is set to the current value in the forms database.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FORM_USER</term>
		/// <term>If this bit flag is set, the form has been defined by the user. Forms with this flag set are defined in the registry.</term>
		/// </item>
		/// <item>
		/// <term>FORM_BUILTIN</term>
		/// <term>
		/// If this bit-flag is set, the form is part of the spooler. Form definitions with this flag set do not appear in the registry.
		/// Built-in forms cannot be modified, so this flag should not be set when the structure is passed to AddForm or SetForm.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FORM_PRINTER</term>
		/// <term>If this bit flag is set, the form is associated with a certain printer, and its definition appears in the registry.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FormFlags Flags;

		/// <summary>A pointer to a null-terminated string that specifies the name of the form. The form name cannot exceed 31 characters.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pName;

		/// <summary>The width and height of the form in thousandths of millimeters.</summary>
		public SIZE Size;

		/// <summary>The width and height, in thousandths of millimeters, of the area of the page on which the printer can print.</summary>
		public RECT ImageableArea;

		/// <summary>
		/// A pointer to a non-localizable string identifier of the form. When passed to <c>AddForm</c> or <c>SetForm</c>, this gives
		/// the caller a means of identifying the form in all locales.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pKeyword;

		/// <summary>
		/// <para>
		/// Specifies how a localized display name for the form is obtained at runtime. The following values are defined. Only one can
		/// be set in any given call to <c>AddForm</c> or <c>SetForm</c>. Both STRING_MUIDLL and STRING_LANGPAIR can be set in the
		/// <c>FORM_INFO_2</c> (s) returned by <c>GetForm</c> or <c>EnumForms</c>. See Remarks.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STRING_NONE</term>
		/// <term>There is no localized display name.</term>
		/// </item>
		/// <item>
		/// <term>STRING_MUIDLL</term>
		/// <term>
		/// The display name is extracted from the Multilingual User Interface localized resources DLL specified in pMuiDll. The ID is
		/// in the dwResourceId member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STRING_LANGPAIR</term>
		/// <term>The display name and language ID are provided directly by pDisplayName and the language is specified by wLangId.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FormStringType StringType;

		/// <summary>The Multilingual User Interface localized resource DLL that contains the localized display name.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pMuiDll;

		/// <summary>The resource ID of the form's display name in <c>pMuiDll</c>.</summary>
		public uint dwResourceId;

		/// <summary>The form's display name in the language specified by <c>wLangId</c>.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDisplayName;

		/// <summary>The language of the <c>pDisplayName</c>.</summary>
		public ushort wLangId;
	}

	/// <summary>Provides a handle to a printer.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HPRINTER : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HPRINTER"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HPRINTER(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HPRINTER"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HPRINTER NULL => new HPRINTER(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HPRINTER"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HPRINTER h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HPRINTER"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HPRINTER(IntPtr h) => new HPRINTER(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HPRINTER h1, HPRINTER h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HPRINTER h1, HPRINTER h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HPRINTER h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a printer change notification.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HPRINTERCHANGENOTIFICATION : IHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HPRINTERCHANGENOTIFICATION"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HPRINTERCHANGENOTIFICATION(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HPRINTERCHANGENOTIFICATION"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HPRINTERCHANGENOTIFICATION NULL => new HPRINTERCHANGENOTIFICATION(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HPRINTERCHANGENOTIFICATION"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HPRINTERCHANGENOTIFICATION h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HPRINTERCHANGENOTIFICATION"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HPRINTERCHANGENOTIFICATION(IntPtr h) => new HPRINTERCHANGENOTIFICATION(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HPRINTERCHANGENOTIFICATION h1, HPRINTERCHANGENOTIFICATION h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HPRINTERCHANGENOTIFICATION h1, HPRINTERCHANGENOTIFICATION h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HPRINTERCHANGENOTIFICATION h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a spool file.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HSPOOLFILE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HSPOOLFILE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HSPOOLFILE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HSPOOLFILE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HSPOOLFILE NULL => new HSPOOLFILE(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HSPOOLFILE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HSPOOLFILE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HSPOOLFILE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HSPOOLFILE(IntPtr h) => new HSPOOLFILE(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HSPOOLFILE h1, HSPOOLFILE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HSPOOLFILE h1, HSPOOLFILE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HSPOOLFILE h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>
	/// The <c>JOB_INFO_1</c> structure specifies print-job information such as the job-identifier value, the name of the printer for
	/// which the job is spooled, the name of the machine that created the print job, the name of the user that owns the print job, and
	/// so on.
	/// </summary>
	/// <remarks>
	/// Port monitors that do not support TrueEndOfJob will set the job as JOB_STATUS_PRINTED right after the job is submitted to the printer.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/job-info-1 typedef struct _JOB_INFO_1 { DWORD JobId; LPTSTR
	// pPrinterName; LPTSTR pMachineName; LPTSTR pUserName; LPTSTR pDocument; LPTSTR pDatatype; LPTSTR pStatus; DWORD Status; DWORD
	// Priority; DWORD Position; DWORD TotalPages; DWORD PagesPrinted; SYSTEMTIME Submitted; } JOB_INFO_1, *PJOB_INFO_1;
	[PInvokeData("winspool.h", MSDNShortId = "d42ada89-6bc7-4006-81d9-dbcc0347edd3")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct JOB_INFO_1
	{
		/// <summary>A job identifier.</summary>
		public uint JobId;

		/// <summary>A pointer to a null-terminated string that specifies the name of the printer for which the job is spooled.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pPrinterName;

		/// <summary>A pointer to a null-terminated string that specifies the name of the machine that created the print job.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pMachineName;

		/// <summary>A pointer to a null-terminated string that specifies the name of the user that owns the print job.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pUserName;

		/// <summary>A pointer to a null-terminated string that specifies the name of the print job (for example, "MS-WORD: Review.doc").</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDocument;

		/// <summary>A pointer to a null-terminated string that specifies the type of data used to record the print job.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDatatype;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the status of the print job. This member should be checked prior to
		/// Status and, if pStatus is <c>NULL</c>, the status is defined by the contents of the Status member.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pStatus;

		/// <summary>
		/// <para>
		/// The job status. The value of this member can be zero or a combination of one or more of the following values. A value of
		/// zero indicates that the print queue was paused after the document finished spooling.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>JOB_STATUS_BLOCKED_DEVQ</term>
		/// <term>The driver cannot print the job.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_COMPLETE</term>
		/// <term>Windows XP and later: Job is sent to the printer, but the job may not be printed yet. See Remarks for more information.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_DELETED</term>
		/// <term>Job has been deleted.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_DELETING</term>
		/// <term>Job is being deleted.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_ERROR</term>
		/// <term>An error is associated with the job.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_OFFLINE</term>
		/// <term>Printer is offline.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_PAPEROUT</term>
		/// <term>Printer is out of paper.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_PAUSED</term>
		/// <term>Job is paused.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_PRINTED</term>
		/// <term>Job has printed.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_PRINTING</term>
		/// <term>Job is printing.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_RESTART</term>
		/// <term>Job has been restarted.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_RETAINED</term>
		/// <term>
		/// Windows Vista and later: Job has been retained in the print queue and cannot be deleted. This can be caused by the
		/// following: 1) The job was manually retained by a call to SetJob and the spooler is waiting for the job to be released. 2)
		/// The job has not finished printing and must finish printing before it can be automatically deleted. See SetJob for more
		/// information about print job commands.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_SPOOLING</term>
		/// <term>Job is spooling.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_USER_INTERVENTION</term>
		/// <term>Printer has an error that requires the user to do something.</term>
		/// </item>
		/// </list>
		/// </summary>
		public JOB_STATUS Status;

		/// <summary>
		/// <para>
		/// The job priority. This member can be one of the following values or in the range between 1 through 99 (MIN_PRIORITY through MAX_PRIORITY).
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MIN_PRIORITY</term>
		/// <term>Minimum priority.</term>
		/// </item>
		/// <item>
		/// <term>MAX_PRIORITY</term>
		/// <term>Maximum priority.</term>
		/// </item>
		/// <item>
		/// <term>DEF_PRIORITY</term>
		/// <term>Default priority.</term>
		/// </item>
		/// </list>
		/// </summary>
		public JOB_PRIORITY Priority;

		/// <summary>The job's position in the print queue.</summary>
		public uint Position;

		/// <summary>
		/// The total number of pages that the document contains. This value may be zero if the print job does not contain page
		/// delimiting information.
		/// </summary>
		public uint TotalPages;

		/// <summary>
		/// The number of pages that have printed. This value may be zero if the print job does not contain page delimiting information.
		/// </summary>
		public uint PagesPrinted;

		/// <summary>
		/// <para>A <c>SYSTEMTIME</c> structure that specifies the time that this document was spooled.</para>
		/// <para>
		/// This time value is in Universal Time Coordinate (UTC) format. You should convert it to a local time value before displaying
		/// it. You can use the <c>FileTimeToLocalFileTime</c> function to perform the conversion.
		/// </para>
		/// </summary>
		public SYSTEMTIME Submitted;
	}

	/// <summary>The <c>JOB_INFO_2</c> structure describes a full set of values associated with a job.</summary>
	/// <remarks>
	/// Port monitors that do not support TrueEndOfJob will set the job as JOB_STATUS_PRINTED right after the job is submitted to the printer.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/job-info-2 typedef struct _JOB_INFO_2 { DWORD JobId; LPTSTR
	// pPrinterName; LPTSTR pMachineName; LPTSTR pUserName; LPTSTR pDocument; LPTSTR pNotifyName; LPTSTR pDatatype; LPTSTR
	// pPrintProcessor; LPTSTR pParameters; LPTSTR pDriverName; LPDEVMODE pDevMode; LPTSTR pStatus; PSECURITY_DESCRIPTOR
	// pSecurityDescriptor; DWORD Status; DWORD Priority; DWORD Position; DWORD StartTime; DWORD UntilTime; DWORD TotalPages; DWORD
	// Size; SYSTEMTIME Submitted; DWORD Time; DWORD PagesPrinted; } JOB_INFO_2, *PJOB_INFO_2;
	[PInvokeData("winspool.h", MSDNShortId = "0cc61e35-4ac9-47bd-bb0d-ff43854bdee5")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct JOB_INFO_2
	{
		/// <summary>A job identifier value.</summary>
		public uint JobId;

		/// <summary>A pointer to a null-terminated string that specifies the name of the printer for which the job is spooled.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pPrinterName;

		/// <summary>A pointer to a null-terminated string that specifies the name of the machine that created the print job.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pMachineName;

		/// <summary>A pointer to a null-terminated string that specifies the name of the user who owns the print job.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pUserName;

		/// <summary>A pointer to a null-terminated string that specifies the name of the print job (for example, "MS-WORD: Review.doc").</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDocument;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the name of the user who should be notified when the job has been
		/// printed or when an error occurs while printing the job.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pNotifyName;

		/// <summary>A pointer to a null-terminated string that specifies the type of data used to record the print job.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDatatype;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the name of the print processor that should be used to print the job.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pPrintProcessor;

		/// <summary>A pointer to a null-terminated string that specifies print-processor parameters.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pParameters;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the name of the printer driver that should be used to process the print job.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDriverName;

		/// <summary>
		/// A pointer to a <c>DEVMODE</c> structure that contains device-initialization and environment data for the printer driver.
		/// </summary>
		public IntPtr pDevMode;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the status of the print job. This member should be checked prior to
		/// <c>Status</c> and, if <c>pStatus</c> is <c>NULL</c>, the status is defined by the contents of the Status member.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pStatus;

		/// <summary>
		/// The value of this member is <c>NULL</c>. Retrieval and setting of document security descriptors is not supported in this release.
		/// </summary>
		public PSECURITY_DESCRIPTOR pSecurityDescriptor;

		/// <summary>
		/// <para>The job status. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>JOB_STATUS_BLOCKED_DEVQ</term>
		/// <term>The driver cannot print the job.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_DELETED</term>
		/// <term>Job has been deleted.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_DELETING</term>
		/// <term>Job is being deleted.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_ERROR</term>
		/// <term>An error is associated with the job.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_OFFLINE</term>
		/// <term>Printer is offline.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_PAPEROUT</term>
		/// <term>Printer is out of paper.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_PAUSED</term>
		/// <term>Job is paused.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_PRINTED</term>
		/// <term>Job has printed.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_PRINTING</term>
		/// <term>Job is printing.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_RESTART</term>
		/// <term>Job has been restarted.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_SPOOLING</term>
		/// <term>Job is spooling.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_USER_INTERVENTION</term>
		/// <term>Printer has an error that requires the user to do something.</term>
		/// </item>
		/// </list>
		/// <para>In Windows XP and later versions of Windows, the following values can also be used:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>JOB_STATUS_COMPLETE</term>
		/// <term>The job is sent to the printer, but may not be printed yet. See Remarks for more information.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_RETAINED</term>
		/// <term>The job has been retained in the print queue following printing.</term>
		/// </item>
		/// </list>
		/// </summary>
		public JOB_STATUS Status;

		/// <summary>
		/// <para>
		/// The job priority. This member can be one of the following values or in the range between 1 through 99 (MIN_PRIORITY through MAX_PRIORITY).
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MIN_PRIORITY</term>
		/// <term>Minimum priority.</term>
		/// </item>
		/// <item>
		/// <term>MAX_PRIORITY</term>
		/// <term>Maximum priority.</term>
		/// </item>
		/// <item>
		/// <term>DEF_PRIORITY</term>
		/// <term>Default priority.</term>
		/// </item>
		/// </list>
		/// </summary>
		public JOB_PRIORITY Priority;

		/// <summary>The job's position in the print queue.</summary>
		public uint Position;

		/// <summary>The earliest time that the job can be printed.</summary>
		public uint StartTime;

		/// <summary>The latest time that the job can be printed.</summary>
		public uint UntilTime;

		/// <summary>
		/// The number of pages required for the job. This value may be zero if the print job does not contain page delimiting information.
		/// </summary>
		public uint TotalPages;

		/// <summary>The size, in bytes, of the job.</summary>
		public uint Size;

		/// <summary>
		/// <para>A <c>SYSTEMTIME</c> structure that specifies the time when the job was submitted.</para>
		/// <para>
		/// This time value is in Universal Time Coordinate (UTC) format. You should convert it to a local time value before displaying
		/// it. You can use the <c>FileTimeToLocalFileTime</c> function to perform the conversion.
		/// </para>
		/// </summary>
		public SYSTEMTIME Submitted;

		/// <summary>The total time, in milliseconds, that has elapsed since the job began printing.</summary>
		public uint Time;

		/// <summary>
		/// The number of pages that have printed. This value may be zero if the print job does not contain page delimiting information.
		/// </summary>
		public uint PagesPrinted;

		/// <summary>A <c>DEVMODE</c> structure that contains device-initialization and environment data for the printer driver.</summary>
		public DEVMODE DevMode => pDevMode.ToStructure<DEVMODE>();
	}

	/// <summary>The <c>JOB_INFO_3</c> structure is used to link together a set of print jobs.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/job-info-3 typedef struct _JOB_INFO_3 { DWORD JobId; DWORD NextJobId;
	// DWORD Reserved; } JOB_INFO_3, *PJOB_INFO_3;
	[PInvokeData("winspool.h", MSDNShortId = "a110f555-dc33-450c-ae77-ea26f0f69448")]
	[StructLayout(LayoutKind.Sequential)]
	public struct JOB_INFO_3
	{
		/// <summary>The print job identifier.</summary>
		public uint JobId;

		/// <summary>The print job identifier for the next print job in the linked set of print jobs.</summary>
		public uint NextJobId;

		/// <summary>This value is reserved for future use. You must set it to zero.</summary>
		public uint Reserved;
	}

	/// <summary>
	/// Describes a full set of values associated with a job and supports large spool files with sizes expressed with 64 bits.
	/// </summary>
	/// <remarks>
	/// Port monitors that do not support TrueEndOfJob will set the job as JOB_STATUS_PRINTED immediately after the job is submitted to
	/// the printer.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/job-info-4 typedef struct _JOB_INFO_4 { DWORD JobId; LPTSTR
	// pPrinterName; LPTSTR pMachineName; LPTSTR pUserName; LPTSTR pDocument; LPTSTR pNotifyName; LPTSTR pDatatype; LPTSTR
	// pPrintProcessor; LPTSTR pParameters; LPTSTR pDriverName; LPDEVMODE pDevMode; LPTSTR pStatus; PSECURITY_DESCRIPTOR
	// pSecurityDescriptor; DWORD Status; DWORD Priority; DWORD Position; DWORD StartTime; DWORD UntilTime; DWORD TotalPages; DWORD
	// Size; SYSTEMTIME Submitted; DWORD Time; DWORD PagesPrinted; LONG SizeHigh; } JOB_INFO_4, *PJOB_INFO_4;
	[PInvokeData("winspool.h", MSDNShortId = "90932ae2-ea9e-43bc-9a1d-c68223f6d0ee")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct JOB_INFO_4
	{
		/// <summary>A job identifier value.</summary>
		public uint JobId;

		/// <summary>A pointer to a null-terminated string that specifies the name of the printer for which the job is spooled.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pPrinterName;

		/// <summary>A pointer to a null-terminated string that specifies the name of the machine that created the print job.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pMachineName;

		/// <summary>A pointer to a null-terminated string that specifies the name of the user who owns the print job.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pUserName;

		/// <summary>A pointer to a null-terminated string that specifies the name of the print job (for example, "MS-WORD: Review.doc").</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDocument;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the name of the user who should be notified when the job has been
		/// printed, or when an error occurs while printing the job.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pNotifyName;

		/// <summary>A pointer to a null-terminated string that specifies the type of data used to record the print job.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDatatype;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the name of the print processor that should be used to print the job.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pPrintProcessor;

		/// <summary>A pointer to a null-terminated string that specifies print-processor parameters.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pParameters;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the name of the printer driver that should be used to process the print job.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDriverName;

		/// <summary>
		/// A pointer to a <c>DEVMODE</c> structure that contains device-initialization and environment data for the printer driver.
		/// </summary>
		public IntPtr pDevMode;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the status of the print job. This member should be checked prior to
		/// <c>Status</c> and, if <c>pStatus</c> is <c>NULL</c>, the status is defined by the contents of the Status member.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pStatus;

		/// <summary>
		/// The value of this member is <c>NULL</c>. Retrieval and setting of document security descriptors is not supported in this release.
		/// </summary>
		public PSECURITY_DESCRIPTOR pSecurityDescriptor;

		/// <summary>
		/// <para>The job status. This member can be one or more of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>JOB_STATUS_BLOCKED_DEVQ</term>
		/// <term>The driver cannot print the job.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_DELETED</term>
		/// <term>Job has been deleted.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_DELETING</term>
		/// <term>Job is being deleted.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_ERROR</term>
		/// <term>An error is associated with the job.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_OFFLINE</term>
		/// <term>Printer is offline.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_PAPEROUT</term>
		/// <term>Printer is out of paper.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_PAUSED</term>
		/// <term>Job is paused.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_PRINTED</term>
		/// <term>Job has printed.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_PRINTING</term>
		/// <term>Job is printing.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_RESTART</term>
		/// <term>Job has been restarted.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_SPOOLING</term>
		/// <term>Job is spooling.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_USER_INTERVENTION</term>
		/// <term>Printer has an error that requires the user to do something.</term>
		/// </item>
		/// </list>
		/// <para>In Windows XP and later versions of Windows, the following values can also be used:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>JOB_STATUS_COMPLETE</term>
		/// <term>The job is sent to the printer, but may not be printed yet. See Remarks for more information.</term>
		/// </item>
		/// <item>
		/// <term>JOB_STATUS_RETAINED</term>
		/// <term>The job has been retained in the print queue following printing.</term>
		/// </item>
		/// </list>
		/// </summary>
		public JOB_STATUS Status;

		/// <summary>
		/// <para>
		/// The job priority. This member can be one of the following values, or in the range between 1 through 99 (MIN_PRIORITY through MAX_PRIORITY).
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MIN_PRIORITY</term>
		/// <term>Minimum priority.</term>
		/// </item>
		/// <item>
		/// <term>MAX_PRIORITY</term>
		/// <term>Maximum priority.</term>
		/// </item>
		/// <item>
		/// <term>DEF_PRIORITY</term>
		/// <term>Default priority.</term>
		/// </item>
		/// </list>
		/// </summary>
		public JOB_PRIORITY Priority;

		/// <summary>The job's position in the print queue.</summary>
		public uint Position;

		/// <summary>The earliest time that the job can be printed.</summary>
		public uint StartTime;

		/// <summary>The latest time that the job can be printed.</summary>
		public uint UntilTime;

		/// <summary>
		/// The number of pages required for the job. This value may be zero if the print job does not contain page delimiting information.
		/// </summary>
		public uint TotalPages;

		/// <summary>The lower four bytes of the size, in bytes, of the job. See also the <c>SizeHigh</c> member below.</summary>
		public uint Size;

		/// <summary>
		/// <para>A <c>SYSTEMTIME</c> structure that specifies the time when the job was submitted.</para>
		/// <para>
		/// This time value is in Universal Time Coordinate (UTC) format. You should convert it to a local time value before displaying
		/// it. You can use the <c>FileTimeToLocalFileTime</c> function to perform the conversion.
		/// </para>
		/// </summary>
		public SYSTEMTIME Submitted;

		/// <summary>The total time, in milliseconds, that has elapsed since the job began printing.</summary>
		public uint Time;

		/// <summary>
		/// The number of pages that have printed. This value may be zero if the print job does not contain page delimiting information.
		/// </summary>
		public uint PagesPrinted;

		/// <summary>The higher four bytes of the size, in bytes, of the job. See also the <c>Size</c> member above.</summary>
		public int SizeHigh;

		/// <summary>A <c>DEVMODE</c> structure that contains device-initialization and environment data for the printer driver.</summary>
		public DEVMODE DevMode => pDevMode.ToStructure<DEVMODE>();
	}

	/// <summary>The <c>MONITOR_INFO_1</c> structure identifies an installed monitor.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/monitor-info-1 typedef struct _MONITOR_INFO_1 { LPTSTR pName; }
	// MONITOR_INFO_1, *PMONITOR_INFO_1;
	[PInvokeData("winspool.h", MSDNShortId = "7a4660bd-5df8-49dd-92f6-9574f451f10d")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct MONITOR_INFO_1
	{
		/// <summary>A pointer to a null-terminated string that identifies an installed monitor.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pName;
	}

	/// <summary>The <c>MONITOR_INFO_2</c> structure identifies a monitor.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/monitor-info-2 typedef struct _MONITOR_INFO_2 { LPTSTR pName; LPTSTR
	// pEnvironment; LPTSTR pDLLName; } MONITOR_INFO_2, *PMONITOR_INFO_2;
	[PInvokeData("winspool.h", MSDNShortId = "4dd1ca15-6983-403e-8159-1a6d35a88162")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct MONITOR_INFO_2
	{
		/// <summary>A pointer to a null-terminated string that is the name of the monitor.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pName;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the environment for which the monitor was written (for example, Windows
		/// NT x86, Windows IA64, Windows x64).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pEnvironment;

		/// <summary>A pointer to a null-terminated string that is the name of the monitor DLL.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDLLName;
	}

	/// <summary>The <c>PORT_INFO_1</c> structure identifies a supported printer port.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/port-info-1 typedef struct _PORT_INFO_1 { LPTSTR pName; } PORT_INFO_1, *PPORT_INFO_1;
	[PInvokeData("winspool.h", MSDNShortId = "e474fe9c-e554-406a-a5bf-de07f9a72b32")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PORT_INFO_1
	{
		/// <summary>Pointer to a null-terminated string that identifies a supported printer port (for example, "LPT1:").</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pName;
	}

	/// <summary>The <c>PORT_INFO_2</c> structure identifies a supported printer port.</summary>
	/// <remarks>
	/// <para>
	/// Use the <c>PORT_INFO_2</c> structure when calling <c>EnumPorts</c> if there are multiple monitors installed that support the
	/// same ports.
	/// </para>
	/// <para>
	/// The <c>fPortType</c> member can be queried to determine information about the port. Note that port settings do not influence
	/// printer attributes (as returned by the <c>Attributes</c> member of <c>PRINTER_INFO_2</c>).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/port-info-2 typedef struct _PORT_INFO_2 { LPTSTR pPortName; LPTSTR
	// pMonitorName; LPTSTR pDescription; DWORD fPortType; DWORD Reserved; } PORT_INFO_2, *PPORT_INFO_2;
	[PInvokeData("winspool.h", MSDNShortId = "93675294-61d4-40e4-b84c-f252978e0285")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PORT_INFO_2
	{
		/// <summary>Pointer to a null-terminated string that identifies a supported printer port (for example, "LPT1:").</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pPortName;

		/// <summary>
		/// Pointer to a null-terminated string that identifies an installed monitor (for example, "PJL monitor"). This can be <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pMonitorName;

		/// <summary>
		/// Pointer to a null-terminated string that describes the port in more detail (for example, if <c>pPortName</c> is "LPT1:",
		/// <c>pDescription</c> is "printer port"). This can be <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDescription;

		/// <summary>Bitmask describing the type of port. This member can be a combination of the following values:</summary>
		public PORT_TYPE fPortType;

		/// <summary>Reserved; must be zero.</summary>
		public uint Reserved;
	}

	/// <summary>The <c>PORT_INFO_3</c> structure specifies the status value of a printer port.</summary>
	/// <remarks>
	/// When you set a printer port status value with the severity value PORT_STATUS_TYPE_ERROR, the print spooler stops sending jobs to
	/// the port. The print spooler does not resume sending jobs to the port until another <c>SetPort</c> call is made to clear the status.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/port-info-3 typedef struct _PORT_INFO_3 { DWORD dwStatus; LPTSTR
	// pszStatus; DWORD dwSeverity; } PORT_INFO_3, *PPORT_INFO_3;
	[PInvokeData("winspool.h", MSDNShortId = "0939353f-284b-4dbb-89a2-04918c934430")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PORT_INFO_3
	{
		/// <summary>
		/// <para>The new port status value. This value is used only if the <c>pszStatus</c> member is <c>NULL</c>.</para>
		/// <para>This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Clears the printer port status.</term>
		/// </item>
		/// <item>
		/// <term>PORT_STATUS_OFFLINE</term>
		/// <term>The port's printer is offline.</term>
		/// </item>
		/// <item>
		/// <term>PORT_STATUS_PAPER_JAM</term>
		/// <term>The port's printer has a paper jam.</term>
		/// </item>
		/// <item>
		/// <term>PORT_STATUS_PAPER_OUT</term>
		/// <term>The port's printer is out of paper.</term>
		/// </item>
		/// <item>
		/// <term>PORT_STATUS_OUTPUT_BIN_FULL</term>
		/// <term>The port's printer's output bin is full.</term>
		/// </item>
		/// <item>
		/// <term>PORT_STATUS_PAPER_PROBLEM</term>
		/// <term>The port's printer has a paper problem.</term>
		/// </item>
		/// <item>
		/// <term>PORT_STATUS_NO_TONER</term>
		/// <term>The port's printer is out of toner.</term>
		/// </item>
		/// <item>
		/// <term>PORT_STATUS_DOOR_OPEN</term>
		/// <term>The door of the port's printer is open.</term>
		/// </item>
		/// <item>
		/// <term>PORT_STATUS_USER_INTERVENTION</term>
		/// <term>The port's printer requires user intervention.</term>
		/// </item>
		/// <item>
		/// <term>PORT_STATUS_OUT_OF_MEMORY</term>
		/// <term>The port's printer is out of memory.</term>
		/// </item>
		/// <item>
		/// <term>PORT_STATUS_TONER_LOW</term>
		/// <term>The port's printer is low on toner.</term>
		/// </item>
		/// <item>
		/// <term>PORT_STATUS_WARMING_UP</term>
		/// <term>The port's printer is warming up.</term>
		/// </item>
		/// <item>
		/// <term>PORT_STATUS_POWER_SAVE</term>
		/// <term>The port's printer is in a power-conservation mode.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PORT_STATUS dwStatus;

		/// <summary>
		/// Pointer to a new printer port status value string to set. Use this member if there is no suitable status value among those
		/// listed for <c>dwStatus</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszStatus;

		/// <summary>
		/// <para>The severity of the port status value.</para>
		/// <para>This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PORT_STATUS_TYPE_ERROR</term>
		/// <term>The port status value indicates an error.</term>
		/// </item>
		/// <item>
		/// <term>PORT_STATUS_TYPE_WARNING</term>
		/// <term>The port status value is a warning.</term>
		/// </item>
		/// <item>
		/// <term>PORT_STATUS_TYPE_INFO</term>
		/// <term>The port status value is informational.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PORT_STATUS_TYPE dwSeverity;
	}

	/// <summary>Contains the execution context of the printer driver that calls <c>GetPrintExecutionData</c>.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/print-execution-data typedef struct _PRINT_EXECUTION_DATA {
	// PRINT_EXECUTION_CONTEXT context; DWORD clientAppPID; } PRINT_EXECUTION_DATA;
	[PInvokeData("winspool.h", MSDNShortId = "1fd25ed9-6f28-48f9-8132-d48fffc956ec")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PRINT_EXECUTION_DATA
	{
		/// <summary>The <c>PRINT_EXECUTION_CONTEXT</c> value that represents the current execution context of the printer driver.</summary>
		public PRINT_EXECUTION_CONTEXT context;

		/// <summary>
		/// If the value of <c>context</c> is <c>PRINT_EXECUTION_CONTEXT_WOW64</c>, <c>clientAppPID</c> identifies the client
		/// application on whose behalf the splwow64.exe process loaded the printer driver. If the value of <c>context</c> is not
		/// <c>PRINT_EXECUTION_CONTEXT_WOW64</c>, <c>clientAppPID</c> is zero.
		/// </summary>
		public uint clientAppPID;
	}

	/// <summary>Represents information about a connection to a printer.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-connection-info-1 typedef struct _PRINTER_CONNECTION_INFO_1 {
	// DWORD dwFlags; LPTSTR pszDriverName; } PRINTER_CONNECTION_INFO_1, *PPRINTER_CONNECTION_INFO_1;
	[PInvokeData("winspool.h", MSDNShortId = "afac3f91-74eb-46f7-94b4-d37b2b8a32a4")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PRINTER_CONNECTION_INFO_1
	{
		/// <summary>
		/// <para>The following values are defined:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PRINTER_CONNECTION_MISMATCH (0x00000020)</term>
		/// <term>
		/// If this bit-flag is set, the printer connection is mismatched. The user can supply a local print driver as pszDriverName and
		/// use it to do the rendering instead of using the driver installed on the server printer to which the user is connected.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PRINTER_CONNECTION_NO_UI (0x00000040)</term>
		/// <term>
		/// If this bit-flag is set then this call cannot display a dialog box. If a dialog box must be displayed to install a printer
		/// driver from the server and this bit-flag is set, the printer driver will not be installed, the printer connection will not
		/// be added, and the call will fail. Windows 7: In Windows 7 and later versions of Windows, if this flag is set and the user is
		/// running in elevated mode, the Do you trust this printer? dialog will not be shown.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public PRINTER_CONNECTION_FLAGS dwFlags;

		/// <summary>A pointer to the name of the driver.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszDriverName;
	}

	/// <summary>
	/// The <c>PRINTER_ENUM_VALUES</c> structure specifies the value name, type, and data for a printer configuration value returned by
	/// the <c>EnumPrinterDataEx</c> function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-enum-values typedef struct _PRINTER_ENUM_VALUES { LPTSTR
	// pValueName; DWORD cbValueName; DWORD dwType; LPBYTE pData; DWORD cbData; } PRINTER_ENUM_VALUES, *PPRINTER_ENUM_VALUES;
	[PInvokeData("winspool.h", MSDNShortId = "87eb1452-0d9d-46bd-8af8-0542a11a929b")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PRINTER_ENUM_VALUES
	{
		/// <summary>Pointer to a null-terminated string that specifies the name of the retrieved value.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pValueName;

		/// <summary>The number of bytes in the pValueName member, including the terminating NULL character.</summary>
		public uint cbValueName;

		/// <summary>
		/// A code indicating the type of data pointed to by the pData member. For a list of the possible type codes, see Registry Value Types.
		/// </summary>
		public REG_VALUE_TYPE dwType;

		/// <summary>Pointer to a buffer containing the data for the retrieved value.</summary>
		public IntPtr pData;

		/// <summary>The number of bytes retrieved in the pData buffer.</summary>
		public uint cbData;
	}

	/// <summary>The <c>PRINTER_INFO_1</c> structure specifies general printer information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-info-1 typedef struct _PRINTER_INFO_1 { DWORD Flags; LPTSTR
	// pDescription; LPTSTR pName; LPTSTR pComment; } PRINTER_INFO_1, *PPRINTER_INFO_1;
	[PInvokeData("winspool.h", MSDNShortId = "0b0e2d0e-2625-4cab-a8f9-536185479443")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PRINTER_INFO_1
	{
		/// <summary>
		/// <para>Specifies information about the returned data. Following are the values for this member.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PRINTER_ENUM_EXPAND</term>
		/// <term>
		/// A print provider can set this flag as a hint to a calling application to enumerate this object further if default expansion
		/// is enabled. For example, when domains are enumerated, a print provider might indicate the user's domain by setting this flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ENUM_CONTAINER</term>
		/// <term>
		/// If this flag is set, the printer object may contain enumerable objects. For example, the object may be a print server that
		/// contains printers.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ENUM_ICON1</term>
		/// <term>
		/// Indicates that, where appropriate, an application should display an icon identifying the object as a top-level network name,
		/// such as Microsoft Windows Network.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ENUM_ICON2</term>
		/// <term>Indicates that, where appropriate, an application should display an icon that identifies the object as a network domain.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ENUM_ICON3</term>
		/// <term>Indicates that, where appropriate, an application should display an icon that identifies the object as a print server.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ENUM_ICON4</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ENUM_ICON5</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ENUM_ICON6</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ENUM_ICON7</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ENUM_ICON8</term>
		/// <term>Indicates that, where appropriate, an application should display an icon that identifies the object as a printer.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PRINTER_ENUM Flags;

		/// <summary>Pointer to a null-terminated string that describes the contents of the structure.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDescription;

		/// <summary>Pointer to a null-terminated string that names the contents of the structure.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pName;

		/// <summary>Pointer to a null-terminated string that contains additional data describing the structure.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pComment;
	}

	/// <summary>The <c>PRINTER_INFO_2</c> structure specifies detailed printer information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-info-2 typedef struct _PRINTER_INFO_2 { LPTSTR pServerName;
	// LPTSTR pPrinterName; LPTSTR pShareName; LPTSTR pPortName; LPTSTR pDriverName; LPTSTR pComment; LPTSTR pLocation; LPDEVMODE
	// pDevMode; LPTSTR pSepFile; LPTSTR pPrintProcessor; LPTSTR pDatatype; LPTSTR pParameters; PSECURITY_DESCRIPTOR
	// pSecurityDescriptor; DWORD Attributes; DWORD Priority; DWORD DefaultPriority; DWORD StartTime; DWORD UntilTime; DWORD Status;
	// DWORD cJobs; DWORD AveragePPM; } PRINTER_INFO_2, *PPRINTER_INFO_2;
	[PInvokeData("winspool.h", MSDNShortId = "944cbfcd-9edf-4b60-a45c-9bb1839f8141")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PRINTER_INFO_2
	{
		/// <summary>
		/// A pointer to a null-terminated string identifying the server that controls the printer. If this string is <c>NULL</c>, the
		/// printer is controlled locally.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pServerName;

		/// <summary>A pointer to a null-terminated string that specifies the name of the printer.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pPrinterName;

		/// <summary>
		/// A pointer to a null-terminated string that identifies the share point for the printer. (This string is used only if the
		/// PRINTER_ATTRIBUTE_SHARED constant was set for the <c>Attributes</c> member.)
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pShareName;

		/// <summary>
		/// A pointer to a null-terminated string that identifies the port(s) used to transmit data to the printer. If a printer is
		/// connected to more than one port, the names of each port must be separated by commas (for example, "LPT1:,LPT2:,LPT3:").
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pPortName;

		/// <summary>A pointer to a null-terminated string that specifies the name of the printer driver.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDriverName;

		/// <summary>A pointer to a null-terminated string that provides a brief description of the printer.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pComment;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the physical location of the printer (for example, "Bldg. 38, Room 1164").
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pLocation;

		/// <summary>
		/// A pointer to a <c>DEVMODE</c> structure that defines default printer data such as the paper orientation and the resolution.
		/// </summary>
		public IntPtr pDevMode;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the name of the file used to create the separator page. This page is
		/// used to separate print jobs sent to the printer.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pSepFile;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the name of the print processor used by the printer. You can use the
		/// <c>EnumPrintProcessors</c> function to obtain a list of print processors installed on a server.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pPrintProcessor;

		/// <summary>
		/// A pointer to a null-terminated string that specifies the data type used to record the print job. You can use the
		/// <c>EnumPrintProcessorDatatypes</c> function to obtain a list of data types supported by a specific print processor.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDatatype;

		/// <summary>A pointer to a null-terminated string that specifies the default print-processor parameters.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pParameters;

		/// <summary>A pointer to a <c>SECURITY_DESCRIPTOR</c> structure for the printer. This member may be <c>NULL</c>.</summary>
		public PSECURITY_DESCRIPTOR pSecurityDescriptor;

		/// <summary>
		/// <para>The printer attributes. This member can be any reasonable combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_DIRECT</term>
		/// <term>Job is sent directly to the printer (it is not spooled).</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_DO_COMPLETE_FIRST</term>
		/// <term>
		/// If set and printer is set for print-while-spooling, any jobs that have completed spooling are scheduled to print before jobs
		/// that have not completed spooling.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_ENABLE_DEVQ</term>
		/// <term>
		/// If set, DevQueryPrint is called. DevQueryPrint may fail if the document and printer setups do not match. Setting this flag
		/// causes mismatched documents to be held in the queue.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_HIDDEN</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_KEEPPRINTEDJOBS</term>
		/// <term>If set, jobs are kept after they are printed. If unset, jobs are deleted.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_LOCAL</term>
		/// <term>Printer is a local printer.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_NETWORK</term>
		/// <term>Printer is a network printer connection.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_PUBLISHED</term>
		/// <term>Indicates whether the printer is published in the directory service.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_QUEUED</term>
		/// <term>
		/// If set, the printer spools and starts printing after the last page is spooled. If not set and PRINTER_ATTRIBUTE_DIRECT is
		/// not set, the printer spools and prints while spooling.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_RAW_ONLY</term>
		/// <term>Indicates that only raw data type print jobs can be spooled.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_SHARED</term>
		/// <term>Printer is shared.</term>
		/// </item>
		/// </list>
		/// <para>In Windows XP and later versions of Windows, the following value can also be used.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_FAX</term>
		/// <term>
		/// If set, printer is a fax printer. This can only be set by AddPrinter, but it can be retrieved by EnumPrinters and GetPrinter.
		/// </term>
		/// </item>
		/// </list>
		/// <para>In Windows Vista and later versions of Windows, the following values can also be used.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_FRIENDLY_NAME</term>
		/// <term>A computer has connected to this printer and given it a friendly name.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_MACHINE</term>
		/// <term>Printer is a per-machine connection.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_PUSHED_USER</term>
		/// <term>The printer was installed by using the Push Printer Connections user policy.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_PUSHED_MACHINE</term>
		/// <term>The printer was installed by using the Push Printer Connections computer policy.</term>
		/// </item>
		/// </list>
		/// <para>In Windows Server 2003, the following value can also be used.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_TS</term>
		/// <term>Indicates the printer is currently connected through a terminal server.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PRINTER_ATTRIBUTE Attributes;

		/// <summary>A priority value that the spooler uses to route print jobs.</summary>
		public uint Priority;

		/// <summary>The default priority value assigned to each print job.</summary>
		public uint DefaultPriority;

		/// <summary>
		/// The earliest time at which the printer will print a job. This value is expressed as minutes elapsed since 12:00 AM GMT
		/// (Greenwich Mean Time).
		/// </summary>
		public uint StartTime;

		/// <summary>
		/// The latest time at which the printer will print a job. This value is expressed as minutes elapsed since 12:00 AM GMT
		/// (Greenwich Mean Time).
		/// </summary>
		public uint UntilTime;

		/// <summary>
		/// <para>The printer status. This member can be any reasonable combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PRINTER_STATUS_BUSY</term>
		/// <term>The printer is busy.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_DOOR_OPEN</term>
		/// <term>The printer door is open.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_ERROR</term>
		/// <term>The printer is in an error state.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_INITIALIZING</term>
		/// <term>The printer is initializing.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_IO_ACTIVE</term>
		/// <term>The printer is in an active input/output state</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_MANUAL_FEED</term>
		/// <term>The printer is in a manual feed state.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_NO_TONER</term>
		/// <term>The printer is out of toner.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_NOT_AVAILABLE</term>
		/// <term>The printer is not available for printing.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_OFFLINE</term>
		/// <term>The printer is offline.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_OUT_OF_MEMORY</term>
		/// <term>The printer has run out of memory.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_OUTPUT_BIN_FULL</term>
		/// <term>The printer's output bin is full.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_PAGE_PUNT</term>
		/// <term>The printer cannot print the current page.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_PAPER_JAM</term>
		/// <term>Paper is jammed in the printer</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_PAPER_OUT</term>
		/// <term>The printer is out of paper.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_PAPER_PROBLEM</term>
		/// <term>The printer has a paper problem.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_PAUSED</term>
		/// <term>The printer is paused.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_PENDING_DELETION</term>
		/// <term>The printer is being deleted.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_POWER_SAVE</term>
		/// <term>The printer is in power save mode.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_PRINTING</term>
		/// <term>The printer is printing.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_PROCESSING</term>
		/// <term>The printer is processing a print job.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_SERVER_UNKNOWN</term>
		/// <term>The printer status is unknown.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_TONER_LOW</term>
		/// <term>The printer is low on toner.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_USER_INTERVENTION</term>
		/// <term>The printer has an error that requires the user to do something.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_WAITING</term>
		/// <term>The printer is waiting.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_WARMING_UP</term>
		/// <term>The printer is warming up.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PRINTER_STATUS Status;

		/// <summary>The number of print jobs that have been queued for the printer.</summary>
		public uint cJobs;

		/// <summary>The average number of pages per minute that have been printed on the printer.</summary>
		public uint AveragePPM;

		/// <summary>A <c>DEVMODE</c> structure that contains device-initialization and environment data for the printer driver.</summary>
		public DEVMODE DevMode => pDevMode.ToStructure<DEVMODE>();
	}

	/// <summary>The <c>PRINTER_INFO_3</c> structure specifies printer security information.</summary>
	/// <remarks>
	/// The <c>PRINTER_INFO_3</c> structure lets an application get and set a printer's security descriptor. The caller may do so even
	/// if it lacks specific printer permissions, as long as it has the standard rights described in <c>SetPrinter</c> and
	/// <c>GetPrinter</c>. Thus, an application may temporarily deny all access to a printer, while allowing the owner of the printer to
	/// have access to the printer's discretionary ACL.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-info-3 typedef struct _PRINTER_INFO_3 { PSECURITY_DESCRIPTOR
	// pSecurityDescriptor; } PRINTER_INFO_3, *PPRINTER_INFO_3;
	[PInvokeData("winspool.h", MSDNShortId = "527d635d-2d75-4b56-bab7-e95c9919a8fb")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PRINTER_INFO_3
	{
		/// <summary>Pointer to a <c>SECURITY_DESCRIPTOR</c> structure that specifies a printer's security information.</summary>
		public PSECURITY_DESCRIPTOR pSecurityDescriptor;
	}

	/// <summary>
	/// <para>The <c>PRINTER_INFO_4</c> structure specifies general printer information.</para>
	/// <para>
	/// The structure can be used to retrieve minimal printer information on a call to <c>EnumPrinters</c>. Such a call is a fast and
	/// easy way to retrieve the names and attributes of all locally installed printers on a system and all remote printer connections
	/// that a user has established.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>PRINTER_INFO_4</c> structure provides an easy and extremely fast way to retrieve the names of the printers installed on a
	/// local machine, as well as the remote connections that a user has established. When <c>EnumPrinters</c> is called with a
	/// <c>PRINTER_INFO_4</c> data structure, that function queries the registry for the specified information, then returns
	/// immediately. This differs from the behavior of <c>EnumPrinters</c> when called with other levels of <c>PRINTER_INFO_xxx</c> data
	/// structures. In particular, when <c>EnumPrinters</c> is called with a level 2 ( <c>PRINTER_INFO_2</c> ) data structure, it
	/// performs an <c>OpenPrinter</c> call on each remote connection. If a remote connection is down, if the remote server no longer
	/// exists, or if the remote printer no longer exists, the function must wait for RPC to time out and consequently fail the
	/// <c>OpenPrinter</c> call. This can take a while. Passing a <c>PRINTER_INFO_4</c> structure lets an application retrieve a bare
	/// minimum of required information; if more detailed information is desired, a subsequent <c>EnumPrinter</c> level 2 call can be made.
	/// </para>
	/// <para><c>Attributes</c> can also contain values that are defined in the <c>Attributes</c> field of <c>PRINTER_INFO_2</c>.</para>
	/// <para>
	/// Some printer configurations, such as printer connections to some non-Windows-based print servers, might return both
	/// <c>PRINTER_ATTRIBUTE_LOCAL</c> and <c>PRINTER_ATTRIBUTE_NETWORK</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-info-4 typedef struct _PRINTER_INFO_4 { LPTSTR pPrinterName;
	// LPTSTR pServerName; DWORD Attributes; } PRINTER_INFO_4, *PPRINTER_INFO_4;
	[PInvokeData("winspool.h", MSDNShortId = "81bd0eab-dc1e-4cf1-8f63-3686f1711c1f")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PRINTER_INFO_4
	{
		/// <summary>Pointer to a null-terminated string that specifies the name of the printer (local or remote).</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pPrinterName;

		/// <summary>Pointer to a null-terminated string that is the name of the server.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pServerName;

		/// <summary>
		/// <para>Specifies information about the returned data.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_LOCAL</term>
		/// <term>The printer is a local printer.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_NETWORK</term>
		/// <term>The printer is a remote printer.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PRINTER_ATTRIBUTE Attributes;
	}

	/// <summary>The <c>PRINTER_INFO_5</c> structure specifies detailed printer information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-info-5 typedef struct _PRINTER_INFO_5 { LPTSTR pPrinterName;
	// LPTSTR pPortName; DWORD Attributes; DWORD DeviceNotSelectedTimeout; DWORD TransmissionRetryTimeout; } PRINTER_INFO_5, *PPRINTER_INFO_5;
	[PInvokeData("winspool.h", MSDNShortId = "c8599f2e-3b7c-4fde-a340-ca7d3ddaa106")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PRINTER_INFO_5
	{
		/// <summary>A pointer to a null-terminated string that specifies the name of the printer.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pPrinterName;

		/// <summary>
		/// A pointer to a null-terminated string that identifies the port(s) used to transmit data to the printer. If a printer is
		/// connected to more than one port, the names of each port must be separated by commas (for example, "LPT1:,LPT2:,LPT3:").
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pPortName;

		/// <summary>
		/// <para>The printer attributes. This member can be any reasonable combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_DIRECT</term>
		/// <term>Job is sent directly to the printer (it is not spooled).</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_DO_COMPLETE_FIRST</term>
		/// <term>
		/// If set and printer is set for print-while-spooling, any jobs that have completed spooling are scheduled to print before jobs
		/// that have not completed spooling.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_ENABLE_DEVQ</term>
		/// <term>
		/// If set, DevQueryPrint is called. DevQueryPrint may fail if the document and printer setups do not match. Setting this flag
		/// causes mismatched documents to be held in the queue.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_HIDDEN</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_KEEPPRINTEDJOBS</term>
		/// <term>If set, jobs are kept after they are printed. If unset, jobs are deleted.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_LOCAL</term>
		/// <term>Printer is a local printer.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_NETWORK</term>
		/// <term>Printer is a network printer connection.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_PUBLISHED</term>
		/// <term>Indicates whether the printer is published in the directory service.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_QUEUED</term>
		/// <term>
		/// If set, the printer spools and starts printing after the last page is spooled. If not set and PRINTER_ATTRIBUTE_DIRECT is
		/// not set, the printer spools and prints while spooling.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_RAW_ONLY</term>
		/// <term>Indicates that only raw data type print jobs can be spooled.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_SHARED</term>
		/// <term>Printer is shared.</term>
		/// </item>
		/// </list>
		/// <para>In Windows XP and later versions of Windows, the following value can also be used.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_FAX</term>
		/// <term>
		/// If set, printer is a fax printer. This can only be set by AddPrinter, but it can be retrieved by EnumPrinters and GetPrinter.
		/// </term>
		/// </item>
		/// </list>
		/// <para>In Windows Vista and later versions of Windows, the following values can also be used.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_FRIENDLY_NAME</term>
		/// <term>A computer has connected to this printer and given it a friendly name.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_MACHINE</term>
		/// <term>Printer is a per-machine connection.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_PUSHED_USER</term>
		/// <term>The printer was installed by using the Push Printer Connections user policy.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ATTRIBUTE_PUSHED_MACHINE</term>
		/// <term>The printer was installed by using the Push Printer Connections computer policy.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PRINTER_ATTRIBUTE Attributes;

		/// <summary>This value is not used.</summary>
		public uint DeviceNotSelectedTimeout;

		/// <summary>This value is not used.</summary>
		public uint TransmissionRetryTimeout;
	}

	/// <summary>The <c>PRINTER_INFO_6</c> specifies the status value of a printer.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-info-6 typedef struct _PRINTER_INFO_6 { DWORD dwStatus; }
	// PRINTER_INFO_6, *PPRINTER_INFO_6;
	[PInvokeData("winspool.h", MSDNShortId = "f26fe75b-7c97-47ad-892f-d9e40331fa5d")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PRINTER_INFO_6
	{
		/// <summary>
		/// <para>The printer status. This member can be any reasonable combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PRINTER_STATUS_BUSY</term>
		/// <term>The printer is busy.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_DOOR_OPEN</term>
		/// <term>The printer door is open.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_ERROR</term>
		/// <term>Not used.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_INITIALIZING</term>
		/// <term>The printer is initializing.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_IO_ACTIVE</term>
		/// <term>The printer is in an active input/output state</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_MANUAL_FEED</term>
		/// <term>The printer is in a manual feed state.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_NO_TONER</term>
		/// <term>The printer is out of toner.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_NOT_AVAILABLE</term>
		/// <term>The printer is not available for printing.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_OFFLINE</term>
		/// <term>The printer is offline.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_OUT_OF_MEMORY</term>
		/// <term>The printer has run out of memory.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_OUTPUT_BIN_FULL</term>
		/// <term>The printer's output bin is full.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_PAGE_PUNT</term>
		/// <term>The printer cannot print the current page.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_PAPER_JAM</term>
		/// <term>Paper is jammed in the printer</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_PAPER_OUT</term>
		/// <term>The printer is out of paper.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_PAPER_PROBLEM</term>
		/// <term>The printer has a paper problem.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_PAUSED</term>
		/// <term>The printer is paused.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_PENDING_DELETION</term>
		/// <term>The printer is pending deletion as a result of a call to the DeletePrinter function.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_POWER_SAVE</term>
		/// <term>The printer is in power save mode.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_PRINTING</term>
		/// <term>The printer is printing.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_PROCESSING</term>
		/// <term>The printer is processing a command from the SetPrinter function.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_SERVER_UNKNOWN</term>
		/// <term>The printer status is unknown.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_TONER_LOW</term>
		/// <term>The printer is low on toner.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_USER_INTERVENTION</term>
		/// <term>The printer has an error that requires the user to do something.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_WAITING</term>
		/// <term>The printer is waiting.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_STATUS_WARMING_UP</term>
		/// <term>The printer is warming up.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PRINTER_STATUS dwStatus;
	}

	/// <summary>
	/// The <c>PRINTER_INFO_7</c> structure specifies directory services printer information. Use this structure with the
	/// <c>SetPrinter</c> function to publish a printer's data in the directory service (DS), or to update or remove a printer's
	/// published data from the DS. Use this structure with the <c>GetPrinter</c> function to determine whether a printer is published
	/// in the DS.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>PRINTER_INFO_7</c> structure is used in a <c>SetPrinter</c> call to publish printer information to the directory service.
	/// The published data includes all values and data for the specified printer found under the SPLDS_SPOOLER_KEY, SPLDS_DRIVER_KEY,
	/// or SPLDS_USER_KEY keys created by <c>SetPrinterDataEx</c>.
	/// </para>
	/// <para>
	/// For <c>SetPrinter</c>, pszObjectGUID should be set to <c>NULL</c>. For <c>GetPrinter</c>, pszObjectGUID returns the GUID of the
	/// directory services print queue object associated with a published printer. You can use this GUID with Active Directory Services
	/// Interface (ADSI) methods to retrieve published data for the printer. However, the recommended method for retrieving published
	/// data is to call the <c>GetPrinterDataEx</c> function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-info-7 typedef struct _PRINTER_INFO_7 { LPTSTR pszObjectGUID;
	// DWORD dwAction; } PRINTER_INFO_7, *PPRINTER_INFO_7;
	[PInvokeData("winspool.h", MSDNShortId = "9443855e-df7d-41a1-a0df-5649a97b2915")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PRINTER_INFO_7
	{
		/// <summary>
		/// <para>
		/// A pointer to a null-terminated string containing the GUID of the directory service print queue object associated with a
		/// published printer. Use the <c>GetPrinter</c> function to retrieve this GUID.
		/// </para>
		/// <para>Before calling <c>SetPrinter</c>, set <c>pszObjectGUID</c> to <c>NULL</c>.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszObjectGUID;

		/// <summary>
		/// <para>
		/// Indicates the action for the <c>SetPrinter</c> function to perform. For the <c>GetPrinter</c> function, this member
		/// indicates whether the specified printer is published. This member can be a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DSPRINT_PENDING 0x80000000</term>
		/// <term>
		/// GetPrinter: Indicates that the system is attempting to complete a publish or unpublish operation started by a SetPrinter
		/// call. SetPrinter: This value is not valid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DSPRINT_PUBLISH 0x00000001</term>
		/// <term>SetPrinter: Publishes the printer's data in the DS. GetPrinter: Indicates the printer is published.</term>
		/// </item>
		/// <item>
		/// <term>DSPRINT_REPUBLISH 0x00000008</term>
		/// <term>
		/// SetPrinter: The DS data for the printer is unpublished and then published again, refreshing all properties in the published
		/// printer. Re-publishing also changes the GUID of the published printer. GetPrinter: Never returns this value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DSPRINT_UNPUBLISH 0x00000004</term>
		/// <term>SetPrinter: Removes the printer's published data from the DS. GetPrinter: Indicates the printer is not published.</term>
		/// </item>
		/// <item>
		/// <term>DSPRINT_UPDATE 0x00000002</term>
		/// <term>SetPrinter: Updates the printer's published data in the DS. GetPrinter: Never returns this value.</term>
		/// </item>
		/// </list>
		/// </summary>
		public DSPRINT dwAction;
	}

	/// <summary>The <c>PRINTER_INFO_8</c> structure specifies the global default printer settings.</summary>
	/// <remarks>
	/// The global defaults are set by the administrator of a printer that can be used by anyone. In contrast, the per-user defaults
	/// will affect a particular user or anyone else who uses the profile. For per-user defaults, use <c>PRINTER_INFO_9</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-info-8 typedef struct _PRINTER_INFO_8 { LPDEVMODE pDevMode; }
	// PRINTER_INFO_8, *PPRINTER_INFO_8;
	[PInvokeData("winspool.h", MSDNShortId = "98f26a45-5302-4358-bed6-691d9bc37554")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PRINTER_INFO_8
	{
		/// <summary>
		/// A pointer to a <c>DEVMODE</c> structure that defines the global default printer data such as the paper orientation and the resolution.
		/// </summary>
		public IntPtr pDevMode;

		/// <summary>A <c>DEVMODE</c> structure that contains device-initialization and environment data for the printer driver.</summary>
		public DEVMODE DevMode => pDevMode.ToStructure<DEVMODE>();
	}

	/// <summary>The <c>PRINTER_INFO_9</c> structure specifies the per-user default printer settings.</summary>
	/// <remarks>
	/// The per-user defaults will affect only a particular user or anyone who uses the profile. In contrast, the global defaults are
	/// set by the administrator of a printer that can be used by anyone. For global defaults, use <c>PRINTER_INFO_8</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-info-9 typedef struct _PRINTER_INFO_9 { LPDEVMODE pDevMode; }
	// PRINTER_INFO_9, *PPRINTER_INFO_9;
	[PInvokeData("winspool.h", MSDNShortId = "8bafb995-f31c-46e3-a950-45e240c678aa")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PRINTER_INFO_9
	{
		/// <summary>
		/// A pointer to a <c>DEVMODE</c> structure that defines the per-user default printer data such as the paper orientation and the
		/// resolution. The <c>DEVMODE</c> is stored in the user's registry.
		/// </summary>
		public IntPtr pDevMode;

		/// <summary>A <c>DEVMODE</c> structure that contains device-initialization and environment data for the printer driver.</summary>
		public DEVMODE DevMode => pDevMode.ToStructure<DEVMODE>();
	}

	/// <summary>
	/// The <c>PRINTER_NOTIFY_INFO</c> structure contains printer information returned by the <c>FindNextPrinterChangeNotification</c>
	/// function. The function returns this information after a wait operation on a printer change notification object has been satisfied.
	/// </summary>
	/// <remarks>
	/// If the <c>Flags</c> member has the PRINTER_NOTIFY_INFO_DISCARDED bit set, this indicates that an overflow or error occurred, and
	/// notifications may have been lost. In this case, you must call <c>FindNextPrinterChangeNotification</c> and specify the
	/// PRINTER_NOTIFY_OPTIONS_REFRESH flag to retrieve all current information. Until you request this refresh operation, the system
	/// will not send additional notifications for this change notification object.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-notify-info typedef struct _PRINTER_NOTIFY_INFO { DWORD Version;
	// DWORD Flags; DWORD Count; PRINTER_NOTIFY_INFO_DATA aData[1]; } PRINTER_NOTIFY_INFO, *PPRINTER_NOTIFY_INFO;
	[PInvokeData("winspool.h", MSDNShortId = "c104fabe-edf5-426e-859b-694811975623")]
	[StructLayout(LayoutKind.Sequential)]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<PRINTER_NOTIFY_INFO>), nameof(Count))]
	public struct PRINTER_NOTIFY_INFO
	{
		/// <summary>The version of this structure. Set this member to 2.</summary>
		public uint Version;

		/// <summary>
		/// A bit flag that indicates the state of the notification structure. If the PRINTER_NOTIFY_INFO_DISCARDED bit is set, it
		/// indicates that some notifications had to be discarded.
		/// </summary>
		public uint Flags;

		/// <summary>The number of <c>PRINTER_NOTIFY_INFO_DATA</c> elements in the <c>aData</c> array.</summary>
		public uint Count;

		/// <summary>
		/// An array of <c>PRINTER_NOTIFY_INFO_DATA</c> structures. Each element of the array identifies a single job or printer
		/// information field, and provides the current data for that field.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public PRINTER_NOTIFY_INFO_DATA[] aData;
	}

	/// <summary>
	/// <para>
	/// The <c>PRINTER_NOTIFY_INFO_DATA</c> structure identifies a job or printer information field and provides the current data for
	/// that field.
	/// </para>
	/// <para>
	/// The <c>FindNextPrinterChangeNotification</c> function returns a <c>PRINTER_NOTIFY_INFO</c> structure, which contains an array of
	/// <c>PRINTER_NOTIFY_INFO_DATA</c> structures.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>If the <c>Type</c> member specifies PRINTER_NOTIFY_TYPE, the <c>Field</c> member can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Field</term>
	/// <term>Type of data</term>
	/// <term>Value</term>
	/// </listheader>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_SERVER_NAME</term>
	/// <term>Not supported.</term>
	/// <term>0x00</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_PRINTER_NAME</term>
	/// <term>pBuf is a pointer to a null-terminated string containing the name of the printer.</term>
	/// <term>0x01</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_SHARE_NAME</term>
	/// <term>pBuf is a pointer to a null-terminated string that identifies the share point for the printer.</term>
	/// <term>0x02</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_PORT_NAME</term>
	/// <term>
	/// pBuf is a pointer to a null-terminated string containing the name of the port that the print jobs will be printed to. If
	/// "Printer Pooling" is selected, this is a comma separated list of ports.
	/// </term>
	/// <term>0x03</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_DRIVER_NAME</term>
	/// <term>pBuf is a pointer to a null-terminated string containing the name of the printer's driver.</term>
	/// <term>0x04</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_COMMENT</term>
	/// <term>
	/// pBuf is a pointer to a null-terminated string containing the new comment string, which is typically a brief description of the printer.
	/// </term>
	/// <term>0x05</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_LOCATION</term>
	/// <term>
	/// pBuf is a pointer to a null-terminated string containing the new physical location of the printer (for example, "Bldg. 38, Room 1164").
	/// </term>
	/// <term>0x06</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_DEVMODE</term>
	/// <term>pBuf is a pointer to a DEVMODE structure that defines default printer data such as the paper orientation and the resolution.</term>
	/// <term>0x07</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_SEPFILE</term>
	/// <term>
	/// pBuf is a pointer to a null-terminated string that specifies the name of the file used to create the separator page. This page
	/// is used to separate print jobs sent to the printer.
	/// </term>
	/// <term>0x08</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_PRINT_PROCESSOR</term>
	/// <term>pBuf is a pointer to a null-terminated string that specifies the name of the print processor used by the printer.</term>
	/// <term>0x09</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_PARAMETERS</term>
	/// <term>pBuf is a pointer to a null-terminated string that specifies the default print-processor parameters.</term>
	/// <term>0x0A</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_DATATYPE</term>
	/// <term>pBuf is a pointer to a null-terminated string that specifies the data type used to record the print job.</term>
	/// <term>0x0B</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_SECURITY_DESCRIPTOR</term>
	/// <term>
	/// pBuf is a pointer to a SECURITY_DESCRIPTOR structure for the printer. The pointer may be NULL if there is no security descriptor.
	/// </term>
	/// <term>0x0C</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_ATTRIBUTES</term>
	/// <term>
	/// adwData [0] specifies the printer attributes, which can be one of the following values: PRINTER_ATTRIBUTE_QUEUED
	/// PRINTER_ATTRIBUTE_DIRECT PRINTER_ATTRIBUTE_DEFAULT PRINTER_ATTRIBUTE_SHARED
	/// </term>
	/// <term>0x0D</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_PRIORITY</term>
	/// <term>adwData [0] specifies a priority value that the spooler uses to route print jobs.</term>
	/// <term>0x0E</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_DEFAULT_PRIORITY</term>
	/// <term>adwData [0] specifies the default priority value assigned to each print job.</term>
	/// <term>0x0F</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_START_TIME</term>
	/// <term>
	/// adwData [0] specifies the earliest time at which the printer will print a job. (This value is specified in minutes elapsed since
	/// 12:00 A.M.)
	/// </term>
	/// <term>0x10</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_UNTIL_TIME</term>
	/// <term>
	/// adwData [0] specifies the latest time at which the printer will print a job. (This value is specified in minutes elapsed since
	/// 12:00 A.M.)
	/// </term>
	/// <term>0x11</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_STATUS</term>
	/// <term>adwData [0] specifies the printer status. For a list of possible values, see the PRINTER_INFO_2 structure.</term>
	/// <term>0x12</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_STATUS_STRING</term>
	/// <term>Not supported.</term>
	/// <term>0x13</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_CJOBS</term>
	/// <term>adwData [0] specifies the number of print jobs that have been queued for the printer.</term>
	/// <term>0x14</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_AVERAGE_PPM</term>
	/// <term>adwData [0] specifies the average number of pages per minute that have been printed on the printer.</term>
	/// <term>0x15</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_TOTAL_PAGES</term>
	/// <term>Not supported.</term>
	/// <term>0x16</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_PAGES_PRINTED</term>
	/// <term>Not supported.</term>
	/// <term>0x17</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_TOTAL_BYTES</term>
	/// <term>Not supported.</term>
	/// <term>0x18</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_BYTES_PRINTED</term>
	/// <term>Not supported.</term>
	/// <term>0x19</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_OBJECT_GUID</term>
	/// <term>This is set if the object GUID changes.</term>
	/// <term>0x1A</term>
	/// </item>
	/// <item>
	/// <term>PRINTER_NOTIFY_FIELD_FRIENDLY_NAME</term>
	/// <term>This is set if the printer connection is renamed.</term>
	/// <term>0x1B</term>
	/// </item>
	/// </list>
	/// <para>If the <c>Type</c> member specifies JOB_NOTIFY_TYPE, the <c>Field</c> member can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Field</term>
	/// <term>Type of data</term>
	/// <term>Value</term>
	/// </listheader>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_PRINTER_NAME</term>
	/// <term>pBuf is a pointer to a null-terminated string containing the name of the printer for which the job is spooled.</term>
	/// <term>0x00</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_MACHINE_NAME</term>
	/// <term>pBuf is a pointer to a null-terminated string that specifies the name of the machine that created the print job.</term>
	/// <term>0x01</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_PORT_NAME</term>
	/// <term>
	/// pBuf is a pointer to a null-terminated string that identifies the port(s) used to transmit data to the printer. If a printer is
	/// connected to more than one port, the names of the ports are separated by commas (for example, "LPT1:,LPT2:,LPT3:").
	/// </term>
	/// <term>0x02</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_USER_NAME</term>
	/// <term>pBuf is a pointer to a null-terminated string that specifies the name of the user who sent the print job.</term>
	/// <term>0x03</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_NOTIFY_NAME</term>
	/// <term>
	/// pBuf is a pointer to a null-terminated string that specifies the name of the user who should be notified when the job has been
	/// printed or when an error occurs while printing the job.
	/// </term>
	/// <term>0x04</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_DATATYPE</term>
	/// <term>pBuf is a pointer to a null-terminated string that specifies the type of data used to record the print job.</term>
	/// <term>0x05</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_PRINT_PROCESSOR</term>
	/// <term>pBuf is a pointer to a null-terminated string that specifies the name of the print processor to be used to print the job.</term>
	/// <term>0x06</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_PARAMETERS</term>
	/// <term>pBuf is a pointer to a null-terminated string that specifies print-processor parameters.</term>
	/// <term>0x07</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_DRIVER_NAME</term>
	/// <term>
	/// pBuf is a pointer to a null-terminated string that specifies the name of the printer driver that should be used to process the
	/// print job.
	/// </term>
	/// <term>0x08</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_DEVMODE</term>
	/// <term>pBuf is a pointer to a DEVMODE structure that contains device-initialization and environment data for the printer driver.</term>
	/// <term>0x09</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_STATUS</term>
	/// <term>adwData [0] specifies the job status. For a list of possible values, see the JOB_INFO_2 structure.</term>
	/// <term>0x0A</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_STATUS_STRING</term>
	/// <term>pBuf is a pointer to a null-terminated string that specifies the status of the print job.</term>
	/// <term>0x0B</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_SECURITY_DESCRIPTOR</term>
	/// <term>Not supported.</term>
	/// <term>0x0C</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_DOCUMENT</term>
	/// <term>pBuf is a pointer to a null-terminated string that specifies the name of the print job (for example, "MS-WORD: Review.doc").</term>
	/// <term>0x0D</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_PRIORITY</term>
	/// <term>adwData [0] specifies the job priority.</term>
	/// <term>0x0E</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_POSITION</term>
	/// <term>adwData [0] specifies the job's position in the print queue.</term>
	/// <term>0x0F</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_SUBMITTED</term>
	/// <term>pBuf is a pointer to a SYSTEMTIME structure that specifies the time when the job was submitted.</term>
	/// <term>0x10</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_START_TIME</term>
	/// <term>
	/// adwData [0] specifies the earliest time that the job can be printed. (This value is specified in minutes elapsed since 12:00 A.M.)
	/// </term>
	/// <term>0x11</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_UNTIL_TIME</term>
	/// <term>
	/// adwData [0] specifies the latest time that the job can be printed. (This value is specified in minutes elapsed since 12:00 A.M.)
	/// </term>
	/// <term>0x12</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_TIME</term>
	/// <term>adwData [0] specifies the total time, in seconds, that has elapsed since the job began printing.</term>
	/// <term>0x13</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_TOTAL_PAGES</term>
	/// <term>adwData [0] specifies the size, in pages, of the job.</term>
	/// <term>0x14</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_PAGES_PRINTED</term>
	/// <term>adwData [0] specifies the number of pages that have printed.</term>
	/// <term>0x15</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_TOTAL_BYTES</term>
	/// <term>adwData [0] specifies the size, in bytes, of the job.</term>
	/// <term>0x16</term>
	/// </item>
	/// <item>
	/// <term>JOB_NOTIFY_FIELD_BYTES_PRINTED</term>
	/// <term>
	/// adwData [0] specifies the number of bytes that have been printed on this job. For this field, the change notification object is
	/// signaled when bytes are sent to the printer.
	/// </term>
	/// <term>0x17</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-notify-info-data typedef struct _PRINTER_NOTIFY_INFO_DATA { WORD
	// Type; WORD Field; DWORD Reserved; DWORD Id; union { DWORD adwData[2]; struct { DWORD cbBuf; LPVOID pBuf; } Data; } NotifyData; }
	// PRINTER_NOTIFY_INFO_DATA, *PPRINTER_NOTIFY_INFO_DATA; ;
	[PInvokeData("winspool.h", MSDNShortId = "7a7b9e01-32e0-47f8-a5b1-5f7e6a663714")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PRINTER_NOTIFY_INFO_DATA
	{
		/// <summary>
		/// <para>Indicates the type of information provided. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>JOB_NOTIFY_TYPE 0x01</term>
		/// <term>Indicates that the Field member specifies a JOB_NOTIFY_FIELD_* constant.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_NOTIFY_TYPE 0x00</term>
		/// <term>Indicates that the Field member specifies a PRINTER_NOTIFY_FIELD_* constant.</term>
		/// </item>
		/// </list>
		/// </summary>
		public NOTIFY_TYPE Type;

		/// <summary>Indicates the field that changed. For a list of possible values, see the Remarks section.</summary>
		public ushort Field;

		/// <summary>Reserved.</summary>
		public uint Reserved;

		/// <summary>
		/// Indicates the job identifier if the <c>Type</c> member specifies JOB_NOTIFY_TYPE. If the <c>Type</c> member specifies
		/// PRINTER_NOTIFY_TYPE, this member is undefined.
		/// </summary>
		public uint Id;

		/// <summary>
		/// A union of data information based on the <c>Type</c> and <c>Field</c> members. For a description of the type of data
		/// associated with each field, see the Remarks section.
		/// </summary>
		public NOTIFYDATA NotifyData;

		/// <summary>
		/// A union of data information based on the <c>Type</c> and <c>Field</c> members. For a description of the type of data
		/// associated with each field, see the Remarks section.
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct NOTIFYDATA
		{
			/// <summary>
			/// The first item in an array of two DWORD values. For information fields that use only a single DWORD, the data is in this field.
			/// </summary>
			[FieldOffset(0)]
			public uint adwData0;

			/// <summary>The second item in an array of two DWORD values.</summary>
			[FieldOffset(4)]
			public uint adwData1;

			/// <summary>Contains variable length data.</summary>
			[FieldOffset(0)]
			public DATA Data;

			/// <summary>Contains variable length data.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct DATA
			{
				/// <summary>Indicates the size, in bytes, of the buffer pointed to by pBuf.</summary>
				public uint cbBuf;

				/// <summary>Pointer to a buffer that contains the field's current data.</summary>
				public IntPtr pBuf;
			}
		}
	}

	/// <summary>
	/// The <c>PRINTER_NOTIFY_OPTIONS</c> structure specifies options for a change notification object that monitors a printer or print server.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Use this structure with the <c>FindFirstPrinterChangeNotification</c> function to specify the set of printer or job information
	/// fields to monitor for change.
	/// </para>
	/// <para>
	/// Use this structure with the <c>FindNextPrinterChangeNotification</c> function to request the current data for all monitored
	/// printer and job information fields. In this case, the <c>Flags</c> member specifies the PRINTER_NOTIFY_OPTIONS_REFRESH flag, and
	/// the function ignores the other structure members.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-notify-options typedef struct _PRINTER_NOTIFY_OPTIONS { DWORD
	// Version; DWORD Flags; DWORD Count; PPRINTER_NOTIFY_OPTIONS_TYPE pTypes; } PRINTER_NOTIFY_OPTIONS, *PPRINTER_NOTIFY_OPTIONS;
	[PInvokeData("", MSDNShortId = "712c546d-dbb3-4f78-b14e-fbb8619b57f9")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PRINTER_NOTIFY_OPTIONS
	{
		/// <summary>The version of this structure. Set this member to 2.</summary>
		public uint Version;

		/// <summary>
		/// A bit flag. If you set the PRINTER_NOTIFY_OPTIONS_REFRESH flag in a call to the <c>FindNextPrinterChangeNotification</c>
		/// function, the function provides current data for all monitored printer information fields. The
		/// <c>FindFirstPrinterChangeNotification</c> function ignores the <c>Flags</c> member.
		/// </summary>
		public PRINTER_NOTIFY_OPTIONS_FLAG Flags;

		/// <summary>The number of elements in the <c>pTypes</c> array.</summary>
		public uint Count;

		/// <summary>
		/// A pointer to an array of <c>PRINTER_NOTIFY_OPTIONS_TYPE</c> structures. Use one element of this array to specify the printer
		/// information fields to monitor, and one element to specify the job information fields to monitor. You can monitor either
		/// printer information, job information, or both.
		/// </summary>
		public IntPtr pTypes;
	}

	/// <summary>
	/// <para>
	/// The <c>PRINTER_NOTIFY_OPTIONS_TYPE</c> structure specifies the set of printer or job information fields to be monitored by a
	/// printer change notification object.
	/// </para>
	/// <para>
	/// A call to the <c>FindFirstPrinterChangeNotification</c> function specifies a <c>PRINTER_NOTIFY_OPTIONS</c> structure, which
	/// contains an array of <c>PRINTER_NOTIFY_OPTIONS_TYPE</c> structures.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-notify-options-type typedef struct _PRINTER_NOTIFY_OPTIONS_TYPE
	// { WORD Type; WORD Reserved0; DWORD Reserved1; DWORD Reserved2; DWORD Count; PWORD pFields; } PRINTER_NOTIFY_OPTIONS_TYPE, *PPRINTER_NOTIFY_OPTIONS_TYPE;
	[PInvokeData("winspool.h", MSDNShortId = "1009f892-d3a8-4887-99b4-a35d1268eeb4")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PRINTER_NOTIFY_OPTIONS_TYPE
	{
		/// <summary>
		/// <para>The type to be watched. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>JOB_NOTIFY_TYPE 0x01</term>
		/// <term>Indicates that the fields specified in the pFields array are JOB_NOTIFY_FIELD_* constants.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_NOTIFY_TYPE 0x00</term>
		/// <term>Indicates that the fields specified in the pFields array are PRINTER_NOTIFY_FIELD_* constants.</term>
		/// </item>
		/// </list>
		/// </summary>
		public NOTIFY_TYPE Type;

		/// <summary>Reserved.</summary>
		public ushort Reserved0;

		/// <summary>Reserved.</summary>
		public uint Reserved1;

		/// <summary>Reserved.</summary>
		public uint Reserved2;

		/// <summary>The number of elements in the <c>pFields</c> array.</summary>
		public uint Count;

		/// <summary>
		/// A pointer to an array of values. Each element of the array specifies a job or printer information field of interest. For a
		/// list of supported printer and job information fields, see the <c>PRINTER_NOTIFY_INFO_DATA</c> structure.
		/// </summary>
		public IntPtr pFields;
	}

	/// <summary>Represents printer options.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-options typedef struct _PRINTER_OPTIONS { UINT cbSize; DWORD
	// dwFlags; } PRINTER_OPTIONS, *PPRINTER_OPTIONS;
	[PInvokeData("winspool.h", MSDNShortId = "7cc3d10c-8bc2-4899-b083-63d802ee16e7")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PRINTER_OPTIONS
	{
		/// <summary>The size of the <c>PRINTER_OPTIONS</c> structure.</summary>
		public uint cbSize;

		/// <summary>
		/// A set of <c>PRINTER_OPTION_FLAGS</c> that specifies how the handle to a printer returned by <c>OpenPrinter2</c> will be used
		/// by other functions.
		/// </summary>
		public PRINTER_OPTION_FLAGS dwFlags;

		/// <summary>An instance with the size preset.</summary>
		public static readonly PRINTER_OPTIONS Default = new PRINTER_OPTIONS { cbSize = 8 };
	}

	/// <summary>
	/// The <c>PRINTPROCESSOR_CAPS_1</c> structure is the format for the printer capability information that is returned by the
	/// <c>GetPrinterData</c> function in the buffer specified by the pData variable.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Values for all structure members are supplied by the <c>GetPrintProcessorCapabilities</c> function, which is documented in the
	/// Windows Driver Kit (WDK).
	/// </para>
	/// <para>
	/// The spooler calls a print processor's <c>GetPrintProcessorCapabilities</c> function when an application calls
	/// <c>GetPrinterData</c>, specifying a value name with a format of PrintProcCaps_datatype, where datatype is the name of an input
	/// data type.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printprocessor-caps-1 typedef struct _PRINTPROCESSOR_CAPS_1 { DWORD
	// dwLevel; DWORD dwNupOptions; DWORD dwPageOrderFlags; DWORD dwNumberOfCopies; } PRINTPROCESSOR_CAPS_1, *PPRINTPROCESSOR_CAPS_1;
	[PInvokeData("winspool.h", MSDNShortId = "43c568ff-ccc9-4873-b159-ede09b4a7e51")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PRINTPROCESSOR_CAPS_1
	{
		/// <summary>The structure's version number. This value must be 1.</summary>
		public uint dwLevel;

		/// <summary>
		/// A bit mask representing the various numbers of document pages the printer can print on a physical page. The least
		/// significant bit represents 1 document page per page, the next bit represents 2 document pages per page, and so on. For
		/// example, 0x0000810B indicates the printer supports 1, 2, 4, 9, and 16 document pages per physical page.
		/// </summary>
		public uint dwNupOptions;

		/// <summary>The order in which pages will be printed. This value can be NORMAL_PRINT, REVERSE_PRINT, or BOOKLET_PRINT.</summary>
		public uint dwPageOrderFlags;

		/// <summary>The maximum number of copies the printer can handle.</summary>
		public uint dwNumberOfCopies;
	}

	/// <summary>Represents printer capability information.</summary>
	/// <remarks>
	/// <para>
	/// Values for all structure members are supplied by the <c>GetPrintProcessorCapabilities</c> function which is documented in the
	/// Windows Driver Kit.
	/// </para>
	/// <para>
	/// When an application calls <c>GetPrinterData</c>, the spooler calls a print processor's <c>GetPrintProcessorCapabilities</c>
	/// function and specifies a value name that has a format of **PrintProcCaps_**datatype, where datatype is the name of an input data type.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printprocessor-caps-2 typedef struct _PRINTPROCESSOR_CAPS_2 { DWORD
	// dwLevel; DWORD dwNupOptions; DWORD dwPageOrderFlags; DWORD dwNumberOfCopies; DWORD dwNupDirectionCaps; DWORD dwNupBorderCaps;
	// DWORD dwBookletHandlingCaps; DWORD dwDuplexHandlingCaps; DWORD dwScalingCaps; } PRINTPROCESSOR_CAPS_2, *PPRINTPROCESSOR_CAPS_2;
	[PInvokeData("winspool.h", MSDNShortId = "70120739-a4e0-4b87-ac7a-40a42fb509ee")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PRINTPROCESSOR_CAPS_2
	{
		/// <summary>A value that indicates the structure's version number.</summary>
		public uint dwLevel;

		/// <summary>
		/// A bit mask representing the various numbers of document pages the printer can print on a single side of a physical sheet.
		/// The least significant bit represents one document page per side, the next bit represents 2 document pages per side, and so
		/// on. For example, 0x0000810B indicates the printer supports 1, 2, 4, 9, and 16 document pages per physical side.
		/// </summary>
		public uint dwNupOptions;

		/// <summary>
		/// A flag value that indicates the order in which pages will be printed. It can be <c>NORMAL_PRINT</c>, <c>REVERSE_PRINT</c>,
		/// or <c>BOOKLET_PRINT</c>.
		/// </summary>
		public uint dwPageOrderFlags;

		/// <summary>The maximum number of copies the printer can handle.</summary>
		public uint dwNumberOfCopies;

		/// <summary>
		/// <para>
		/// The available patterns when multiple document pages are printed on the same side of a sheet of paper. The possible flags are
		/// the following:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PPCAPS_RIGHT_THEN_DOWN</term>
		/// <term>Pages appear in rows from right to left, each subsequent row below its predecessor.</term>
		/// </item>
		/// <item>
		/// <term>PPCAPS_DOWN_THEN_RIGHT</term>
		/// <term>Pages appear in columns from top to bottom, each subsequent column to the right of its predecessor.</term>
		/// </item>
		/// <item>
		/// <term>PPCAPS_LEFT_THEN_DOWN</term>
		/// <term>Pages appear in rows from left to right, each subsequent row below its predecessor.</term>
		/// </item>
		/// <item>
		/// <term>PPCAPS_DOWN_THEN_LEFT</term>
		/// <term>Pages appear in columns from top to bottom, each subsequent column to the left of its predecessor.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PPCAPS_DIRECTION dwNupDirectionCaps;

		/// <summary>
		/// Can be only PPCAPS_BORDER_PRINT, indicating that, when multiple document pages are being printed on a single side of a
		/// physical sheet, the printer can be told whether or not to print a border around the imageable area of each document page.
		/// </summary>
		public PPCAPS_BORDER dwNupBorderCaps;

		/// <summary>Can only be PPCAPS_BOOKLET_EDGE, indicating that the printer can print booklet style.</summary>
		public PPCAPS_EDGE dwBookletHandlingCaps;

		/// <summary>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PPCAPS_REVERSE_PAGES_FOR_REVERSE_DUPLEX</term>
		/// <term>
		/// When printing in reverse order and duplexing, the processor can print swap the order of each pair of pages, so instead of
		/// printing in order 4,3,2,1, they will print in the order 3,4,1,2.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PPCAPS_DONT_SEND_EXTRA_PAGES_FOR_DUPLEX</term>
		/// <term>
		/// When duplexing, the Print Processor can be told not to send an extra page when there is an odd number of document pages. The
		/// processor will honor the value as best as it can, but in cases where preventing an extra blank page would cause improper
		/// output, the extra pages may still be sent.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public PPCAPS_DUPLEX dwDuplexHandlingCaps;

		/// <summary>Can only be PPCAPS_SQUARE_SCALING, indicating that the printer can scale the page image.</summary>
		public PPCAPS_SCALING dwScalingCaps;
	}

	/// <summary>The <c>PRINTPROCESSOR_INFO_1</c> structure specifies the name of an installed print processor.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printprocessor-info-1 typedef struct _PRINTPROCESSOR_INFO_1 { LPTSTR
	// pName; } PRINTPROCESSOR_INFO_1, *PPRINTPROCESSOR_INFO_1;
	[PInvokeData("winspool.h", MSDNShortId = "49b272c8-156b-4996-b3fd-92cde831f4ae")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PRINTPROCESSOR_INFO_1
	{
		/// <summary>Pointer to a null-terminated string that specifies the name of an installed print processor.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pName;
	}

	/// <summary>The <c>PROVIDOR_INFO_1</c> structure identifies a print provider.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/providor-info-1 typedef struct _PROVIDOR_INFO_1 { LPTSTR pName; LPTSTR
	// pEnvironment; LPTSTR pDLLName; } PROVIDOR_INFO_1, *PPROVIDOR_INFO_1;
	[PInvokeData("winspool.h", MSDNShortId = "0eff115a-b3d2-4c8f-b820-46e7f62dd295")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PROVIDOR_INFO_1
	{
		/// <summary>Pointer to a null-terminated string that is the name of the print provider.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pName;

		/// <summary>
		/// Pointer to a null-terminated environment string specifying the environment the provider dynamic-link library (DLL) is
		/// designed to run in.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pEnvironment;

		/// <summary>Pointer to a null-terminated string that is the name of the provider .dll.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pDLLName;
	}

	/// <summary>The <c>PROVIDOR_INFO_2</c> structure appends a print provider to the print provider order list.</summary>
	/// <remarks>
	/// This structure is used when calling <c>AddPrintProvidor</c>, level 2, to add the specified print provider to the end of the
	/// print provider order list. The provider is immediately used for routing if the call succeeds.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/providor-info-2 typedef struct _PROVIDOR_INFO_2 { LPTSTR pOrder; }
	// PROVIDOR_INFO_2, *PPROVIDOR_INFO_2;
	[PInvokeData("winspool.h", MSDNShortId = "840523ca-22d0-460f-81fb-e0a9e2d4f5d6")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PROVIDOR_INFO_2
	{
		/// <summary>Pointer to a null-terminated string that specifies the name of the print provider.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pOrder;
	}

	/// <summary>
	/// The <c>PRINTER_DEFAULTS</c> structure specifies the default data type, environment, initialization data, and access rights for a printer.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/printer-defaults typedef struct _PRINTER_DEFAULTS { LPTSTR pDatatype;
	// LPDEVMODE pDevMode; ACCESS_MASK DesiredAccess; } PRINTER_DEFAULTS, *PPRINTER_DEFAULTS;
	[PInvokeData("winspool.h", MSDNShortId = "df29c3a6-b1d1-4d40-887d-5ffc032a5871")]
	public class PRINTER_DEFAULTS
	{
		/// <summary>
		/// <para>
		/// Specifies desired access rights for a printer. The <c>OpenPrinter</c> function uses this member to set access rights to the
		/// printer. These rights can affect the operation of the <c>SetPrinter</c> and <c>DeletePrinter</c> functions. The access
		/// rights can be one of the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PRINTER_ACCESS_ADMINISTER</term>
		/// <term>To perform administrative tasks, such as those provided by SetPrinter.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ACCESS_USE</term>
		/// <term>To perform basic printing operations.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ACCESS_MANAGE_LIMITED</term>
		/// <term>
		/// To perform administrative tasks, such as those provided by SetPrinter and SetPrinterData. This value is available starting
		/// from Windows 8.1.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PRINTER_ALL_ACCESS</term>
		/// <term>
		/// To perform all administrative tasks and basic printing operations except for SYNCHRONIZE (see Standard Access Rights ).
		/// </term>
		/// </item>
		/// <item>
		/// <term>generic security values, such as WRITE_DAC</term>
		/// <term>To allow specific control access rights. See Standard Access Rights.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ACCESS_MASK DesiredAccess;

		/// <summary>Pointer to a null-terminated string that specifies the default data type for a printer.</summary>
		public string pDatatype;

		/// <summary>A <c>DEVMODE</c> structure that identifies the default environment and initialization data for a printer.</summary>
		public DEVMODE? pDevMode;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HPRINTER"/> that is disposed using <see cref="ClosePrinter"/>.</summary>
	public class SafeHPRINTER : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHPRINTER"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHPRINTER(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHPRINTER"/> class.</summary>
		private SafeHPRINTER() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHPRINTER"/> to <see cref="HPRINTER"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HPRINTER(SafeHPRINTER h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => ClosePrinter(handle);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HPRINTERCHANGENOTIFICATION"/> that is disposed using <see cref="FindClosePrinterChangeNotification"/>.</summary>
	public class SafeHPRINTERCHANGENOTIFICATION : SafeHANDLE, ISyncHandle
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SafeHPRINTERCHANGENOTIFICATION"/> class and assigns an existing handle.
		/// </summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHPRINTERCHANGENOTIFICATION(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHPRINTERCHANGENOTIFICATION"/> class.</summary>
		private SafeHPRINTERCHANGENOTIFICATION() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHPRINTERCHANGENOTIFICATION"/> to <see cref="HPRINTERCHANGENOTIFICATION"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HPRINTERCHANGENOTIFICATION(SafeHPRINTERCHANGENOTIFICATION h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => FindClosePrinterChangeNotification(handle);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HSPOOLFILE"/> that is disposed using <see cref="CloseSpoolFileHandle"/>.</summary>
	public class SafeHSPOOLFILE : SafeHANDLE
	{
		private readonly HPRINTER hPrinter;

		/// <summary>Initializes a new instance of the <see cref="SafeHSPOOLFILE"/> class and assigns an existing handle.</summary>
		/// <param name="hPrinter">The open printer handle.</param>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHSPOOLFILE(HPRINTER hPrinter, IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) => this.hPrinter = hPrinter;

		/// <summary>Initializes a new instance of the <see cref="SafeHSPOOLFILE"/> class.</summary>
		private SafeHSPOOLFILE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHSPOOLFILE"/> to <see cref="HFILE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFILE(SafeHSPOOLFILE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="SafeHSPOOLFILE"/> to <see cref="HSPOOLFILE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HSPOOLFILE(SafeHSPOOLFILE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => CloseSpoolFileHandle(hPrinter, handle);
	}

	/// <summary>
	/// Represents the system allocated pointer to <see cref="PRINTER_NOTIFY_INFO"/> created by the
	/// <see cref="FindNextPrinterChangeNotification(HPRINTERCHANGENOTIFICATION, out PRINTER_CHANGE, in PRINTER_NOTIFY_OPTIONS, out SafePRINTER_NOTIFY_INFO)"/> function.
	/// </summary>
	/// <seealso cref="Vanara.PInvoke.SafeHANDLE"/>
	public class SafePRINTER_NOTIFY_INFO : SafeHANDLE
	{
		private SafePRINTER_NOTIFY_INFO() : base()
		{
		}

		/// <summary>Performs an implicit conversion from <see cref="SafePRINTER_NOTIFY_INFO"/> to <see cref="PRINTER_NOTIFY_INFO"/>.</summary>
		/// <param name="h">The h.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PRINTER_NOTIFY_INFO(SafePRINTER_NOTIFY_INFO h) => h.IsInvalid ? default : h.handle.ToStructure<PRINTER_NOTIFY_INFO>();

		/// <summary>
		/// Internal method that actually releases the handle. This is called by <see cref="M:Vanara.PInvoke.SafeHANDLE.ReleaseHandle"/>
		/// for valid handles and afterwards zeros the handle.
		/// </summary>
		/// <returns><c>true</c> to indicate successful release of the handle; <c>false</c> otherwise.</returns>
		protected override bool InternalReleaseHandle() => FreePrinterNotifyInfo(handle);
	}

	internal class PRINTER_DEFAULTS_Marshaler : ICustomMarshaler
	{
		/// <summary>Gets the instance.</summary>
		/// <param name="_">The cookie.</param>
		/// <returns>An instance of this class.</returns>
		public static ICustomMarshaler GetInstance(string _) => new PRINTER_DEFAULTS_Marshaler();

		public void CleanUpManagedData(object ManagedObj) => throw new NotImplementedException();

		public void CleanUpNativeData(IntPtr pNativeData) => Marshal.FreeCoTaskMem(pNativeData);

		public int GetNativeDataSize() => -1;

		public IntPtr MarshalManagedToNative(object ManagedObj)
		{
			if (!(ManagedObj is PRINTER_DEFAULTS pd)) throw new ArgumentException("Type of managed object must be PRINTER_DEFAULTS.");

			var sz = IntPtr.Size * 2 + 4 + StringHelper.GetByteCount(pd.pDatatype) + (pd.pDevMode?.dmSize ?? 0);
			var mem = new SafeCoTaskMemHandle(sz);
			using (var str = new NativeMemoryStream(mem))
			{
				str.WriteReference(pd.pDatatype);
				str.WriteReferenceObject(pd.pDevMode.HasValue ? (object)pd.pDevMode.Value : null);
				str.Write((uint)pd.DesiredAccess);
			}

			return mem.TakeOwnership();
		}

		public object MarshalNativeToManaged(IntPtr pNativeData) => throw new NotImplementedException();
	}

	/*
	DOCEVENT_CREATEDPRE
		DOCEVENT_ESCAPE
		DOCEVENT_CREATEDPRE
		DOCEVENT_FILTER
		*/
}