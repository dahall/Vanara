using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke;

/// <summary>Items defined in DocumentTarget.idl.</summary>
// https://docs.microsoft.com/en-us/windows/win32/api/documenttarget/
public static partial class DocumentTarget
{
	/// <summary/>
	public static readonly Guid ID_DOCUMENTPACKAGETARGET_MSXPS = new Guid(0x9cae40a8, 0xded1, 0x41c9, 0xa9, 0xfd, 0xd7, 0x35, 0xef, 0x33, 0xae, 0xda);
	/// <summary/>
	public static readonly Guid ID_DOCUMENTPACKAGETARGET_OPENXPS = new Guid(0x0056bb72, 0x8c9c, 0x4612, 0xbd, 0x0f, 0x93, 0x01, 0x2a, 0x87, 0x09, 0x9d);
	/// <summary/>
	public static readonly Guid ID_DOCUMENTPACKAGETARGET_OPENXPS_WITH_3D = new Guid(0x63dbd720, 0x8b14, 0x4577, 0xb0, 0x74, 0x7b, 0xb1, 0x1b, 0x59, 0x6d, 0x28);

	/// <summary>The PrintDocumentPackageCompletion enumeration specifies the status of the print operation.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/documenttarget/ne-documenttarget-printdocumentpackagecompletion typedef enum
	// PrintDocumentPackageCompletion { PrintDocumentPackageCompletion_InProgress, PrintDocumentPackageCompletion_Completed,
	// PrintDocumentPackageCompletion_Canceled, PrintDocumentPackageCompletion_Failed } ;
	[PInvokeData("documenttarget.h", MSDNShortId = "E8E1F5D3-8CA2-406A-B969-7F5C6F13E064")]
	public enum PrintDocumentPackageCompletion
	{
		/// <summary>The print job is running.</summary>
		PrintDocumentPackageCompletion_InProgress,

		/// <summary>The print operation completed without error.</summary>
		PrintDocumentPackageCompletion_Completed,

		/// <summary>The print operation was canceled.</summary>
		PrintDocumentPackageCompletion_Canceled,

		/// <summary>The print operation failed.</summary>
		PrintDocumentPackageCompletion_Failed
	}

	/// <summary>Represents the progress of the print job.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/documenttarget/nn-documenttarget-iprintdocumentpackagestatusevent
	[PInvokeData("documenttarget.h", MSDNShortId = "A2178E6A-04AD-4024-A083-5C76A5F60743")]
	[ComImport, Guid("ED90C8AD-5C34-4D05-A1EC-0E8A9B3AD7AF")]
	public interface IPrintDocumentPackageStatusEvent
	{
		/// <summary>Updates the status of the package when the print job in progress raises an event, or the job completes.</summary>
		/// <param name="packageStatus">The status update.</param>
		/// <returns>
		/// If the <c>PackageStatusUpdated</c> method completes successfully, it returns an S_OK. Otherwise it returns an appropriate
		/// HRESULT error code.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/documenttarget/nf-documenttarget-iprintdocumentpackagestatusevent-packagestatusupdated
		// HRESULT PackageStatusUpdated( PrintDocumentPackageStatus *packageStatus );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1)]
		void PackageStatusUpdated(in PrintDocumentPackageStatus packageStatus);
	}

	/// <summary>
	/// Allows users to enumerate the supported package target types and to create one with a given type ID.
	/// <c>IPrintDocumentPackageTarget</c> also supports the tracking of the package printing progress and cancelling.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/documenttarget/nn-documenttarget-iprintdocumentpackagetarget
	[PInvokeData("documenttarget.h", MSDNShortId = "0F63C626-DB58-4952-BBB3-7E3901429C35")]
	[ComImport, Guid("1B8EFEC4-3019-4C27-964E-367202156906"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(PrintDocumentPackageTarget))]
	public interface IPrintDocumentPackageTarget
	{
		/// <summary>Enumerates the supported target types.</summary>
		/// <param name="targetCount">The number of supported target types.</param>
		/// <param name="targetTypes">The array of supported target types. An array of GUIDs.</param>
		/// <remarks>
		/// In the case of a multi-format driver, the first GUID returned in the targetTypes array is the XPS format preferred by the driver.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/documenttarget/nf-documenttarget-iprintdocumentpackagetarget-getpackagetargettypes
		// HRESULT GetPackageTargetTypes( UINT32 *targetCount, GUID **targetTypes );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetPackageTargetTypes(out uint targetCount, out Guid[] targetTypes);

		/// <summary>
		/// Retrieves the pointer to the specific document package target, which allows the client to add a document with the given
		/// target type. Clients can call this method multiple times but they always have to use the same target ID.
		/// </summary>
		/// <param name="guidTargetType">The target type GUID obtained from GetPackageTargetTypes.</param>
		/// <param name="riid">The identifier of the interface being requested.</param>
		/// <param name="ppvTarget">
		/// The requested document target interface. The returned pointer is a pointer to an IXpsDocumentPackageTarget interface.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/documenttarget/nf-documenttarget-iprintdocumentpackagetarget-getpackagetarget
		// HRESULT GetPackageTarget( REFGUID guidTargetType, REFIID riid, void **ppvTarget );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void GetPackageTarget(in Guid guidTargetType, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppvTarget);

		/// <summary>Cancels the current print job.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/documenttarget/nf-documenttarget-iprintdocumentpackagetarget-cancel
		// HRESULT Cancel();
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Cancel();
	}

	/// <summary>Used with IPrintDocumentPackageTarget for starting a print job.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/documenttarget/nn-documenttarget-iprintdocumentpackagetargetfactory
	[PInvokeData("documenttarget.h", MSDNShortId = "631FBF5E-1DDF-49A9-8E1E-201BC6996EA5")]
	[ComImport, Guid("d2959bf7-b31b-4a3d-9600-712eb1335ba4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(PrintDocumentPackageTargetFactory))]
	public interface IPrintDocumentPackageTargetFactory
	{
		/// <summary>Acts as the entry point for creating an IPrintDocumentPackageTarget object.</summary>
		/// <param name="printerName">The name of the target printer.</param>
		/// <param name="jobName">
		/// <para>The name to apply to the job.</para>
		/// <para><c>Note</c> Job name strings longer than 63 characters will be truncated to 63 characters and a terminating <c>NULL</c>.</para>
		/// </param>
		/// <param name="jobOutputStream">
		/// The job content. The application must set the seek pointer to the beginning before specifying the job output stream.
		/// </param>
		/// <param name="jobPrintTicketStream">
		/// A pointer to the <c>IStream</c> interface that is used by the caller to write the job-level print ticket that will be
		/// associated with this job.
		/// </param>
		/// <param name="docPackageTarget">The target output.</param>
		/// <returns>
		/// If the <c>CreateDocumentPackageTargetForPrintJob</c> method completes successfully, it returns an S_OK. Otherwise it returns
		/// the appropriate HRESULT error code.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/documenttarget/nf-documenttarget-iprintdocumentpackagetargetfactory-createdocumentpackagetargetforprintjob
		// HRESULT CreateDocumentPackageTargetForPrintJob( LPCWSTR printerName, LPCWSTR jobName, IStream *jobOutputStream, IStream
		// *jobPrintTicketStream, IPrintDocumentPackageTarget **docPackageTarget );
		[PreserveSig]
		HRESULT CreateDocumentPackageTargetForPrintJob([MarshalAs(UnmanagedType.LPWStr)] string printerName, [MarshalAs(UnmanagedType.LPWStr)] string jobName,
			IStream jobOutputStream, IStream jobPrintTicketStream, out IPrintDocumentPackageTarget docPackageTarget);
	}

	/// <summary>CLSID_PrintDocumentPackageTarget</summary>
	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("4842669e-9947-46ea-8ba2-d8cce432c2ca")]
	public class PrintDocumentPackageTarget { }

	/// <summary>CLSID_PrintDocumentPackageTargetFactory</summary>
	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("348ef17d-6c81-4982-92b4-ee188a43867a")]
	public class PrintDocumentPackageTargetFactory { }

	/// <summary>Defines a payload to be used by the PackageStatusUpdated method. This structure is a generic version of XPS_JOB_STATUS.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/documenttarget/ns-documenttarget-printdocumentpackagestatus typedef struct
	// __MIDL___MIDL_itf_documenttarget_0000_0001_0001 { UINT32 JobId; INT32 CurrentDocument; INT32 CurrentPage; INT32 CurrentPageTotal;
	// PrintDocumentPackageCompletion Completion; HRESULT PackageStatus; } PrintDocumentPackageStatus;
	[PInvokeData("documenttarget.h", MSDNShortId = "A499CB8D-B2E3-4343-A9AF-079C75EF1441")]
	public struct PrintDocumentPackageStatus
	{
		/// <summary>The completion status of the job.</summary>
		public PrintDocumentPackageCompletion Completion;

		/// <summary>The zero-based index of the most recently processed document.</summary>
		public int CurrentDocument;

		/// <summary>The zero-based index of the most recently processed page in the current document</summary>
		public int CurrentPage;

		/// <summary>A running total of the number of pages that have been processed by the print job.</summary>
		public int CurrentPageTotal;

		/// <summary>The job ID.</summary>
		public uint JobId;

		/// <summary>The error state of the job.</summary>
		public HRESULT PackageStatus;
	}
}