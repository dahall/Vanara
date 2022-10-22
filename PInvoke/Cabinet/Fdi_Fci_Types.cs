namespace Vanara.PInvoke
{
	public static partial class Cabinet
	{
		/// <summary>The <c>ERF</c> structure contains error information from FCI/FDI. The caller should not modify this structure.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/fdi_fci_types/ns-fdi_fci_types-erf typedef struct { int erfOper; int
		// erfType; BOOL fError; } ERF;
		[PInvokeData("fdi_fci_types.h", MSDNShortId = "ddbccad9-a68c-4be7-90dc-e3dd25f5cf3b")]
		public struct ERF
		{
			/// <summary>
			/// <para>An FCI/FDI error code.</para>
			/// <para>The following values are returned for FCI:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>FCIERR_NONE 0x00</term>
			/// <term>No Error.</term>
			/// </item>
			/// <item>
			/// <term>FCIERR_OPEN_SRC 0x01</term>
			/// <term>Failure opening the file to be stored in the cabinet.</term>
			/// </item>
			/// <item>
			/// <term>FCIERR_READ_SRC 0x02</term>
			/// <term>Failure reading the file to be stored in the cabinet.</term>
			/// </item>
			/// <item>
			/// <term>FCIERR_ALLOC_FAIL 0x03</term>
			/// <term>Out of memory in FCI.</term>
			/// </item>
			/// <item>
			/// <term>FCIERR_TEMP_FILE 0x04</term>
			/// <term>Could not create a temporary file.</term>
			/// </item>
			/// <item>
			/// <term>FCIERR_BAD_COMPR_TYPE 0x05</term>
			/// <term>Unknown compression type.</term>
			/// </item>
			/// <item>
			/// <term>FCIERR_CAB_FILE 0x06</term>
			/// <term>Could not create the cabinet file.</term>
			/// </item>
			/// <item>
			/// <term>FCIERR_USER_ABORT 0x07</term>
			/// <term>FCI aborted.</term>
			/// </item>
			/// <item>
			/// <term>FCIERR_MCI_FAIL 0x08</term>
			/// <term>Failure compressing data.</term>
			/// </item>
			/// <item>
			/// <term>FCIERR_CAB_FORMAT_LIMIT 0x09</term>
			/// <term>Data-size or file-count exceeded CAB format limits.</term>
			/// </item>
			/// </list>
			/// <para>The following values are returned for FDI:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>FDIERROR_NONE 0x00</term>
			/// <term>No error.</term>
			/// </item>
			/// <item>
			/// <term>FDIERROR_CABINET_NOT_FOUND 0x01</term>
			/// <term>The cabinet file was not found.</term>
			/// </item>
			/// <item>
			/// <term>FDIERROR_NOT_A_CABINET 0x02</term>
			/// <term>The cabinet file does not have the correct format.</term>
			/// </item>
			/// <item>
			/// <term>FDIERROR_UNKNOWN_CABINET_VERSION 0x03</term>
			/// <term>The cabinet file has an unknown version number.</term>
			/// </item>
			/// <item>
			/// <term>FDIERROR_CORRUPT_CABINET 0x04</term>
			/// <term>The cabinet file is corrupt.</term>
			/// </item>
			/// <item>
			/// <term>FDIERROR_ALLOC_FAIL 0x05</term>
			/// <term>Insufficient memory.</term>
			/// </item>
			/// <item>
			/// <term>FDIERROR_BAD_COMPR_TYPE 0x06</term>
			/// <term>Unknown compression type used in the cabinet folder.</term>
			/// </item>
			/// <item>
			/// <term>FDIERROR_MDI_FAIL 0x07</term>
			/// <term>Failure decompressing data from the cabinet file.</term>
			/// </item>
			/// <item>
			/// <term>FDIERROR_TARGET_FILE 0x08</term>
			/// <term>Failure writing to the target file.</term>
			/// </item>
			/// <item>
			/// <term>FDIERROR_RESERVE_MISMATCH 0x09</term>
			/// <term>The cabinets within a set do not have the same RESERVE sizes.</term>
			/// </item>
			/// <item>
			/// <term>FDIERROR_WRONG_CABINET 0x0A</term>
			/// <term>The cabinet returned by fdintNEXT_CABINET is incorrect.</term>
			/// </item>
			/// <item>
			/// <term>FDIERROR_USER_ABORT 0x0B</term>
			/// <term>FDI aborted.</term>
			/// </item>
			/// </list>
			/// </summary>
			public int erfOper;

			/// <summary>An optional error value filled in by FCI/FDI. For FCI, this is usually the C runtime errno value.</summary>
			public int erfType;

			/// <summary>A flag that indicates an error. If <c>TRUE</c>, an error is present.</summary>
			public BOOL fError;
		}
	}
}