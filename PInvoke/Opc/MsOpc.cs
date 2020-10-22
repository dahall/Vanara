using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.Extensions.Reflection;
using Vanara.InteropServices;
using static Vanara.PInvoke.Crypt32;
using static Vanara.PInvoke.UrlMon;

namespace Vanara.PInvoke
{
	/// <summary>Interfaces from the Microsoft Packaging API for Open Packaging.</summary>
	public static partial class Opc
	{
		/// <summary>Describes the canonicalization method to be applied to XML markup.</summary>
		/// <remarks>
		/// <para>For more information about XML canonicalization, see the W3C Recommendation, Canonical XML Version 1.0 (http://go.microsoft.com/fwlink/p/?linkid=125240).</para>
		/// <para>
		/// For more information about canonicalization and packages, see the ECMA-376 OpenXML, 1st Edition, Part 2: Open Packaging
		/// Conventions (OPC).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/ne-msopc-opc_canonicalization_method typedef enum
		// __MIDL___MIDL_itf_msopc_0001_0076_0001 { OPC_CANONICALIZATION_NONE, OPC_CANONICALIZATION_C14N,
		// OPC_CANONICALIZATION_C14N_WITH_COMMENTS } OPC_CANONICALIZATION_METHOD;
		[PInvokeData("msopc.h", MSDNShortId = "f8401d12-da2e-4b35-b473-ebe3d1f91abd")]
		public enum OPC_CANONICALIZATION_METHOD
		{
			/// <summary>No canonicalization method is applied.</summary>
			OPC_CANONICALIZATION_NONE,

			/// <summary>The C14N canonicalization method that removes comments is applied.</summary>
			OPC_CANONICALIZATION_C14N,

			/// <summary>The C14N canonicalization method that preserves comments is applied.</summary>
			OPC_CANONICALIZATION_C14N_WITH_COMMENTS
		}

		/// <summary>Describes the storage location of a certificate that is used in signing.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/ne-msopc-opc_certificate_embedding_option typedef enum
		// __MIDL___MIDL_itf_msopc_0001_0076_0004 { OPC_CERTIFICATE_IN_CERTIFICATE_PART, OPC_CERTIFICATE_IN_SIGNATURE_PART,
		// OPC_CERTIFICATE_NOT_EMBEDDED } OPC_CERTIFICATE_EMBEDDING_OPTION;
		[PInvokeData("msopc.h", MSDNShortId = "4292a53b-33a2-431c-806a-7e8c96ecce40")]
		public enum OPC_CERTIFICATE_EMBEDDING_OPTION
		{
			/// <summary>The certificate is stored in a part specific to the certificate.</summary>
			OPC_CERTIFICATE_IN_CERTIFICATE_PART,

			/// <summary>The certificate is encoded within the signature markup in the Signature part.</summary>
			OPC_CERTIFICATE_IN_SIGNATURE_PART,

			/// <summary>The certificate is not stored in the package.</summary>
			OPC_CERTIFICATE_NOT_EMBEDDED,
		}

		/// <summary>Describes ways to compress part content.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/ne-msopc-opc_compression_options typedef enum
		// __MIDL___MIDL_itf_msopc_0000_0002_0002 { OPC_COMPRESSION_NONE, OPC_COMPRESSION_NORMAL, OPC_COMPRESSION_MAXIMUM,
		// OPC_COMPRESSION_FAST, OPC_COMPRESSION_SUPERFAST } OPC_COMPRESSION_OPTIONS;
		[PInvokeData("msopc.h", MSDNShortId = "bc821e84-fd18-449c-89d0-a261f43f8971")]
		public enum OPC_COMPRESSION_OPTIONS
		{
			/// <summary>Compression is turned off.</summary>
			OPC_COMPRESSION_NONE = -1,

			/// <summary>Compression is optimized for a balance between size and performance.</summary>
			OPC_COMPRESSION_NORMAL = 0,

			/// <summary>Compression is optimized for size.</summary>
			OPC_COMPRESSION_MAXIMUM,

			/// <summary>Compression is optimized for performance.</summary>
			OPC_COMPRESSION_FAST,

			/// <summary>Compression is optimized for high performance.</summary>
			OPC_COMPRESSION_SUPERFAST,
		}

		/// <summary>
		/// Describes the read settings for caching package components and validating them against ECMA-376 OpenXML, 1st Edition, Part 2:
		/// Open Packaging Conventions (OPC) conformance requirements.
		/// </summary>
		/// <remarks>
		/// <para>
		/// If both the <c>OPC_CACHE_ON_ACCESS</c> and <c>OPC_VALIDATE_ON_LOAD</c> read flags are set, all package components are
		/// decompressed and cached when a package is loaded.
		/// </para>
		/// <para>
		/// The Packaging APIs do not use the OPC core properties feature; therefore, the core properties requirements listed in Table H-9
		/// of the OPC are not validated by the Packaging APIs. For more information about OPC conformance requirements, see 1st edition,
		/// Part 2: Open Packaging Conventions in ECMA-376 OpenXML (http://go.microsoft.com/fwlink/p/?linkid=123375).
		/// </para>
		/// <para>
		/// <c>Important</c> Parts may be repeatedly read from the stream at any time, regardless of which read flags are set. For example,
		/// when a package is saved, previously accessed relationships in a Relationships part in the original package may be accessed again
		/// to preserve markup compatibility.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/ne-msopc-opc_read_flags typedef enum
		// __MIDL___MIDL_itf_msopc_0000_0002_0004 { OPC_READ_DEFAULT, OPC_VALIDATE_ON_LOAD, OPC_CACHE_ON_ACCESS } OPC_READ_FLAGS;
		[PInvokeData("msopc.h", MSDNShortId = "f7d21dac-c606-4a6a-9d6a-cf6f8ec4dbb5")]
		public enum OPC_READ_FLAGS
		{
			/// <summary>
			/// Validate a package component against OPC conformance requirements when the component is accessed. For more information about
			/// OPC conformance validation, see Remarks.When validation is performed on access, OPC validation errors can be returned by any method.
			/// </summary>
			OPC_READ_DEFAULT,

			/// <summary>
			/// Validate all package components against OPC conformance requirements when a package is loaded. For more information about
			/// OPC conformance validation, see Remarks.If this setting is enabled, performance costs for loading and validating package
			/// components are paid when the package is first loaded.
			/// </summary>
			OPC_VALIDATE_ON_LOAD,

			/// <summary>
			/// Cache decompressed package component data as a temp file when accessing the component for the first time. When a package
			/// component is accessed repeatedly, this caching reduces overhead because the component data is decompressed one time for the
			/// first read instead of once for every read operation.
			/// </summary>
			OPC_CACHE_ON_ACCESS,
		}

		/// <summary>
		/// Describes how to interpret the selectionCriterion parameter of the IOpcRelationshipSelector::GetSelectionCriterion method.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/ne-msopc-opc_relationship_selector typedef enum
		// __MIDL___MIDL_itf_msopc_0001_0076_0002 { OPC_RELATIONSHIP_SELECT_BY_ID, OPC_RELATIONSHIP_SELECT_BY_TYPE } OPC_RELATIONSHIP_SELECTOR;
		[PInvokeData("msopc.h", MSDNShortId = "5532aab1-850e-4de8-a470-c55fb4c2f8c4")]
		public enum OPC_RELATIONSHIP_SELECTOR
		{
			/// <summary>The selectionCriterion parameter is a relationship identifier.</summary>
			OPC_RELATIONSHIP_SELECT_BY_ID,

			/// <summary>The selectionCriterion parameter is a relationship type.</summary>
			OPC_RELATIONSHIP_SELECT_BY_TYPE,
		}

		/// <summary>
		/// Describes whether a reference represented by the IOpcSignatureRelationshipReference interface refers to all or a subset of
		/// relationships represented as relationship objects in a relationship set object.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/ne-msopc-opc_relationships_signing_option typedef enum
		// __MIDL___MIDL_itf_msopc_0001_0076_0003 { OPC_RELATIONSHIP_SIGN_USING_SELECTORS, OPC_RELATIONSHIP_SIGN_PART } OPC_RELATIONSHIPS_SIGNING_OPTION;
		[PInvokeData("msopc.h", MSDNShortId = "b6a83730-459a-4119-a013-7d670e659c32")]
		public enum OPC_RELATIONSHIPS_SIGNING_OPTION
		{
			/// <summary>
			/// The reference refers to a subset of relationships represented as relationship objects and identified using the
			/// IOpcRelationshipSelectorSet interface.
			/// </summary>
			OPC_RELATIONSHIP_SIGN_USING_SELECTORS,

			/// <summary>
			/// The reference refers to all of the relationships represented as relationship objects in the relationship set object.
			/// </summary>
			OPC_RELATIONSHIP_SIGN_PART,
		}

		/// <summary>
		/// Describes how to interpret the signingTime parameter, which is a record of when a signature was created, of the
		/// IOpcDigitalSignature::GetSigningTime method.
		/// </summary>
		/// <remarks>
		/// <para>The following table provides descriptions of placeholder values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Placeholder</term>
		/// <term>Description</term>
		/// <term>Example</term>
		/// </listheader>
		/// <item>
		/// <term>YYYY</term>
		/// <term>Four-digit year.</term>
		/// <term>2010</term>
		/// </item>
		/// <item>
		/// <term>MM</term>
		/// <term>Two-digit month with a leading zero. Possible values: 01–12.</term>
		/// <term>03</term>
		/// </item>
		/// <item>
		/// <term>DD</term>
		/// <term>Two-digit day of month with a leading zero. Possible values: 01–31.</term>
		/// <term>09</term>
		/// </item>
		/// <item>
		/// <term>hh</term>
		/// <term>Two-digit hour, 24-hour time with a leading zero. Possible values: 00–23.</term>
		/// <term>18</term>
		/// </item>
		/// <item>
		/// <term>mm</term>
		/// <term>Two-digit minute with a leading zero. Possible values: 00–59.</term>
		/// <term>45</term>
		/// </item>
		/// <item>
		/// <term>ss</term>
		/// <term>Two-digit second with a leading zero. Possible values: 00–59.</term>
		/// <term>32</term>
		/// </item>
		/// <item>
		/// <term>s</term>
		/// <term>One digit representing the decimal fraction of a second.</term>
		/// <term>3</term>
		/// </item>
		/// <item>
		/// <term>TZD</term>
		/// <term>Time zone designator with a leading zero. Possible values: Z, +hh:mm, -hh:mm.</term>
		/// <term>-08:00</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/ne-msopc-opc_signature_time_format typedef enum
		// __MIDL___MIDL_itf_msopc_0001_0076_0005 { OPC_SIGNATURE_TIME_FORMAT_MILLISECONDS, OPC_SIGNATURE_TIME_FORMAT_SECONDS,
		// OPC_SIGNATURE_TIME_FORMAT_MINUTES, OPC_SIGNATURE_TIME_FORMAT_DAYS, OPC_SIGNATURE_TIME_FORMAT_MONTHS,
		// OPC_SIGNATURE_TIME_FORMAT_YEARS } OPC_SIGNATURE_TIME_FORMAT;
		[PInvokeData("msopc.h", MSDNShortId = "9b8ff585-5795-48ce-b2fd-a49e3d34ccb9")]
		public enum OPC_SIGNATURE_TIME_FORMAT
		{
			/// <summary>
			/// The format is the complete date with hours, minutes, and seconds expressed as a decimal fraction.Syntax:
			/// YYYY-MM-DDThh:mm:ss.sTZDA value of "2010-03-09T18:45:32.3-08:00" would represent 6:45:32.3 P.M. on March 9, 2010 Pacific Time.
			/// </summary>
			OPC_SIGNATURE_TIME_FORMAT_MILLISECONDS,

			/// <summary>
			/// The format is the complete date with hours, minutes, and seconds.Syntax: YYYY-MM-DDThh:mm:ssTZDA value of
			/// "2010-03-09T18:45:32-08:00" would represent 6:45:32 P.M. on March 9, 2010 Pacific Time.
			/// </summary>
			OPC_SIGNATURE_TIME_FORMAT_SECONDS,

			/// <summary>
			/// The format is the complete date with hours and minutes.Syntax: YYYY-MM-DDThh:mmTZDA value of "2010-03-09T18:45-08:00" would
			/// represent 6:45 P.M. on March 9, 2010 Pacific Time.
			/// </summary>
			OPC_SIGNATURE_TIME_FORMAT_MINUTES,

			/// <summary>The format is the complete date.Syntax: YYYY-MM-DDA value of "2010-03-09" would represent March 9, 2010.</summary>
			OPC_SIGNATURE_TIME_FORMAT_DAYS,

			/// <summary>The format is the year and month.Syntax: YYYY-MMA value of "2010-03" would represent March, 2010.</summary>
			OPC_SIGNATURE_TIME_FORMAT_MONTHS,

			/// <summary>The format is the year.Syntax: YYYYA value of "2010" would represent 2010.</summary>
			OPC_SIGNATURE_TIME_FORMAT_YEARS,
		}

		/// <summary>Indicates the status of the signature.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/ne-msopc-opc_signature_validation_result typedef enum
		// OPC_SIGNATURE_VALIDATION_RESULT { OPC_SIGNATURE_VALID, OPC_SIGNATURE_INVALID } ;
		[PInvokeData("msopc.h", MSDNShortId = "991e0620-d674-4c2c-b0d8-18d7fdd031fb")]
		public enum OPC_SIGNATURE_VALIDATION_RESULT
		{
			/// <summary>
			/// The signature is valid.Signature validation using the provided certificate succeeded; signed package components have not
			/// been altered.
			/// </summary>
			OPC_SIGNATURE_VALID,

			/// <summary>
			/// The signature is not valid.Signature markup or signed package components might have been altered. Alternatively, the
			/// signature might not exist in the current package.
			/// </summary>
			OPC_SIGNATURE_INVALID = -1,
		}

		/// <summary>Describes the read/write status of a stream.</summary>
		/// <remarks><c>Important</c> Reading and writing to the same package is not recommended and may result in undefined behavior.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/ne-msopc-opc_stream_io_mode typedef enum
		// __MIDL___MIDL_itf_msopc_0000_0002_0003 { OPC_STREAM_IO_READ, OPC_STREAM_IO_WRITE } OPC_STREAM_IO_MODE;
		[PInvokeData("msopc.h", MSDNShortId = "cf72ddcf-5472-451f-bfa8-94f549dc9246")]
		public enum OPC_STREAM_IO_MODE
		{
			/// <summary>Creates a read-only stream for loading an existing package.</summary>
			OPC_STREAM_IO_READ = 1,

			/// <summary>Creates a write-only stream for saving a new package.</summary>
			OPC_STREAM_IO_WRITE,
		}

		/// <summary>Indicates the target mode of a relationship.</summary>
		/// <remarks>
		/// <para>
		/// If the relationship's target mode is <c>OPC_URI_TARGET_MODE_INTERNAL</c> the URI of the target part is relative to the URI of
		/// the source of the relationship.
		/// </para>
		/// <para>To get the URI of the target of the relationship, call the IOpcRelationship::GetTargetUri method.</para>
		/// <para>
		/// For more information about relationships, see the Open Packaging Conventions Fundamentals and the ECMA-376 OpenXML, 1st Edition,
		/// Part 2: Open Packaging Conventions (OPC).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/ne-msopc-opc_uri_target_mode typedef enum
		// __MIDL___MIDL_itf_msopc_0000_0002_0001 { OPC_URI_TARGET_MODE_INTERNAL, OPC_URI_TARGET_MODE_EXTERNAL } OPC_URI_TARGET_MODE;
		[PInvokeData("msopc.h", MSDNShortId = "af052aa3-db7a-47de-938c-32895b8735e9")]
		public enum OPC_URI_TARGET_MODE
		{
			/// <summary>The target of the relationship is a part inside the package.</summary>
			OPC_URI_TARGET_MODE_INTERNAL,

			/// <summary>The target of the relationship is a resource outside of the package.</summary>
			OPC_URI_TARGET_MODE_EXTERNAL,
		}

		/// <summary>Describes the encoding method that is used by the serialization object to produce the package.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/ne-msopc-opc_write_flags typedef enum
		// __MIDL___MIDL_itf_msopc_0000_0002_0005 { OPC_WRITE_DEFAULT, OPC_WRITE_FORCE_ZIP32 } OPC_WRITE_FLAGS;
		[PInvokeData("msopc.h", MSDNShortId = "12006b4a-98e1-4761-bce3-32b83b54a2cb")]
		public enum OPC_WRITE_FLAGS
		{
			/// <summary>Use Zip64 encoding. The minimum software version for extracting a package with Zip64 encoding is 4.5.</summary>
			OPC_WRITE_DEFAULT,

			/// <summary>
			/// Force Zip32 encoding. The minimum software version for extracting a package with Zip32 encoding is 2.0.If one or more of the
			/// following Zip32 limitations are violated, the package write will fail:
			/// </summary>
			OPC_WRITE_FORCE_ZIP32,
		}

		/// <summary>A read-only enumerator of pointers to CERT_CONTEXT structures.</summary>
		/// <remarks>
		/// <para>
		/// When an enumerator is created, the current position precedes the first pointer of the enumerator. To set the current position to
		/// the first pointer, call the MoveNextmethod after the enumerator is created.
		/// </para>
		/// <para>Changes to the set will invalidate the enumerator and all subsequent calls to it will fail.</para>
		/// <para>
		/// To get an <c>IOpcCertificateEnumerator</c> interface pointer, call the IOpcCertificateSet::GetEnumerator or
		/// IOpcDigitalSignature::GetCertificateEnumerator method.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopccertificateenumerator
		[PInvokeData("msopc.h")]
		[ComImport, Guid("85131937-8f24-421f-b439-59ab24d140b8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcCertificateEnumerator
		{
			/// <summary>Moves the current position of the enumerator to the next CERT_CONTEXT structure.</summary>
			/// <param name="hasNext">
			/// <para>A Boolean value that indicates the status of the CERT_CONTEXT structure at the current position.</para>
			/// <para>The value of hasNext is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The current position of the enumerator has been advanced to the next pointer and that pointer is valid.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been advanced past the end of the collection and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasNext parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_NEXT 0x80510051</term>
			/// <term>The current position is already past the last item of the enumerator.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopccertificateenumerator-movenext HRESULT MoveNext( BOOL
			// *hasNext );
			[PreserveSig]
			HRESULT MoveNext([MarshalAs(UnmanagedType.Bool)] out bool hasNext);

			/// <summary>Moves the current position of the enumerator to the previous CERT_CONTEXT structure.</summary>
			/// <param name="hasPrevious">
			/// <para>A Boolean value that indicates the status of the CERT_CONTEXT structure at the current position.</para>
			/// <para>The value of hasPrevious is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>
			/// The current position of the enumerator has been moved to the previous pointer in the collection, and that pointer is valid.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been moved past the beginning of the collection and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasPrevious parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_PREVIOUS 0x80510052</term>
			/// <term>The current position already precedes the first item of the enumerator.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopccertificateenumerator-moveprevious HRESULT
			// MovePrevious( BOOL *hasPrevious );
			[PreserveSig]
			HRESULT MovePrevious([MarshalAs(UnmanagedType.Bool)] out bool hasPrevious);

			/// <summary>Gets the CERT_CONTEXT structure at the current position of the enumerator.</summary>
			/// <param name="certificate">
			/// A pointer to a CERT_CONTEXT structure. If the method succeeds, call the CertFreeCertificateContext function to free the
			/// memory of the structure.
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The partReference parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_INVALID_POSITION 0x80510053</term>
			/// <term>The enumerator cannot perform this operation from its current position.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_EXTERNAL_SIGNATURE 0x8051001E</term>
			/// <term>
			/// A relationship whose target is a Signature part has the external target mode; Signature parts must be inside of the package.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_INVALID_CERTIFICATE_RELATIONSHIP 0x8051001D</term>
			/// <term>
			/// A relationship of type digital signature certificate has the external target mode. For more information about this
			/// relationship type, see the OPC.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_INVALID_RELATIONSHIP_TRANSFORM_XML 0x80510021</term>
			/// <term>
			/// A Transform element that indicates the use of the relationships transform and the selection criteria for the transform does
			/// not conform to the schema specified in the OPC.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_MISSING_CERTIFICATE_PART 0x80510056</term>
			/// <term>
			/// The part that contains the certificate and is the target of a relationship of type digital signature certificate does not
			/// exist. For more information about this relationship type, see the OPC.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_SIGNATURE_PROPERTY_MISSING_TARGET 0x80510045</term>
			/// <term>The SignatureProperty element is missing the required Target attribute.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_UNEXPECTED_CONTENT_TYPE 0x80510005</term>
			/// <term>
			/// Either the content type of a part differed from the expected content type (specified in the OPC, ECMA-376 Part 2), or the
			/// part content did not match the part's content type.
			/// </term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// If the certificate represented by the CERT_CONTEXT structure is corrupted or is not an X.509 certificate, this method will
			/// return an error; further, the signing policy used by the caller dictates whether the signature will still be validated.
			/// After this kind of error is returned, calls to the MoveNext or MovePrevious method will continue to iterate through the enumerator.
			/// </para>
			/// <para>
			/// When an enumerator is created, the current position precedes the first pointer of the enumerator. To set the current
			/// position to the first pointer, call the MoveNextmethod after the enumerator is created.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopccertificateenumerator-getcurrent HRESULT GetCurrent(
			// const CERT_CONTEXT **certificate );
			[PreserveSig]
			HRESULT GetCurrent(out IntPtr certificate);

			/// <summary>Creates a copy of the current IOpcCertificateEnumerator interface pointer and all its descendants.</summary>
			/// <returns>A pointer to a copy of the IOpcCertificateEnumerator interface pointer.</returns>
			/// <remarks>
			/// <para>The copy has a current position and set that are identical to the current enumerator.</para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopccertificateenumerator-clone HRESULT Clone(
			// IOpcCertificateEnumerator **copy );
			IOpcCertificateEnumerator Clone();
		}

		/// <summary>An unordered set of certificates to be used with a signature.</summary>
		/// <remarks>
		/// <para>
		/// Do not add the certificate that will be passed to the IOpcDigitalSignature::Sign method (the signer certificate) to this
		/// certificate set.
		/// </para>
		/// <para>Certificates that are in a certificate chain are added to the package by calling the Add method.</para>
		/// <para>To access an <c>IOpcCertificateSet</c> interface pointer, call the IOpcSigningOptions::GetCertificateSet method.</para>
		/// <para>When a signature is generated, certificates that were added to the package by calling Add are associated with the signature.</para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopccertificateset
		[PInvokeData("msopc.h")]
		[ComImport, Guid("56ea4325-8e2d-4167-b1a4-e486d24c8fa7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcCertificateSet
		{
			/// <summary>Adds a certificate to the set.</summary>
			/// <param name="certificate">A CERT_CONTEXT structure that contains the certificate to be added.</param>
			/// <remarks>
			/// <para>Certificates that are in a certificate chain are added to the package by calling the <c>Add</c> method.</para>
			/// <para>
			/// When a signature is generated, certificates that were added to the package by calling <c>Add</c> are associated with the signature.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopccertificateset-add HRESULT Add( const CERT_CONTEXT
			// *certificate );
			void Add(in CERT_CONTEXT certificate);

			/// <summary>Removes a specified certificate from the set.</summary>
			/// <param name="certificate">A CERT_CONTEXT structure that contains the certificate to be removed.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopccertificateset-remove HRESULT Remove( const
			// CERT_CONTEXT *certificate );
			void Remove(in CERT_CONTEXT certificate);

			/// <summary>Gets an enumerator of certificates in the set.</summary>
			/// <returns>A pointer to an IOpcCertificateEnumerator interface of certificates in the set.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopccertificateset-getenumerator HRESULT GetEnumerator(
			// IOpcCertificateEnumerator **certificateEnumerator );
			IOpcCertificateEnumerator GetEnumerator();
		}

		/// <summary>Represents a package digital signature.</summary>
		/// <remarks>
		/// <para>
		/// To generate a signature and create an <c>IOpcDigitalSignature</c> interface pointer, call the IOpcDigitalSignatureManager::Sign method.
		/// </para>
		/// <para>
		/// To access generated signature by using an <c>IOpcDigitalSignature</c> interface pointer, call the
		/// IOpcDigitalSignatureEnumerator::GetCurrent method.
		/// </para>
		/// <para>
		/// When a signature is generated, this information is serialized in the XML markup of the signature (signature markup). The
		/// signature markup that results is stored in a signature part.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcdigitalsignature
		[PInvokeData("msopc.h")]
		[ComImport, Guid("52ab21dd-1cd0-4949-bc80-0c1232d00cb4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcDigitalSignature
		{
			/// <summary>Gets the prefix and namespace mapping of the <c>Signature</c> element of the signature markup.</summary>
			/// <param name="prefixes">
			/// A pointer to a buffer of XML prefix strings. If the method succeeds, call the CoTaskMemFree function to free the memory of
			/// each string in the buffer and then to free the memory of the buffer itself.
			/// </param>
			/// <param name="namespaces">
			/// A pointer to a buffer of XML namespace strings. If the method succeeds, call the CoTaskMemFree function to free the memory
			/// of each string in the buffer and then to free the memory of the buffer itself.
			/// </param>
			/// <param name="count">The size of the prefixes and namespaces buffers.</param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The prefixes parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The namespaces parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The count parameter is NULL.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>The prefixes and namespaces buffers are mapped to each other by index.</para>
			/// <para>
			/// This method allocates memory used by the buffers returned in prefixes and namespaces and the strings contained in each buffer.
			/// </para>
			/// <para>Examples</para>
			/// <para>The following code shows how to use CoTaskMemFree to free the memory of the buffers and the strings they contain.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignature-getnamespaces HRESULT GetNamespaces(
			// LPWSTR **prefixes, LPWSTR **namespaces, UINT32 *count );
			void GetNamespaces([MarshalAs(UnmanagedType.LPWStr)] out string prefixes, [MarshalAs(UnmanagedType.LPWStr)] out string namespaces, out uint count);

			/// <summary>Gets the value of the <c>Id</c> attribute from the <c>Signature</c> element of the signature markup.</summary>
			/// <returns>
			/// <para>A pointer to the <c>Id</c> attribute value of the signature markup <c>Signature</c> element.</para>
			/// <para>If the <c>Signature</c> element does not have an <c>Id</c> attribute value, signatureId will be the empty string.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The <c>Id</c> attribute of the <c>Signature</c> element is optional. If this method is not called, the <c>Signature</c>
			/// element will not have the <c>Id</c> attribute.
			/// </para>
			/// <para>To set the signature Id before the signature is generated, call the IOpcSigningOptions::SetSignatureId method.</para>
			/// <para>To access the Id before the signature is generated, call the IOpcSigningOptions::GetSignatureId. method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignature-getsignatureid HRESULT GetSignatureId(
			// LPWSTR *signatureId );
			[return: MarshalAs(UnmanagedType.LPWStr)] 
			string GetSignatureId();

			/// <summary>Gets the part name of the part that contains the signature markup.</summary>
			/// <returns>
			/// An IOpcPartUri interface pointer that represents the part name of the signature part that contains the signature markup.
			/// </returns>
			/// <remarks>
			/// <para>
			/// To set the part name of this signature part before the signature is generated, call the
			/// IOpcSigningOptions::SetSignaturePartName method. To access the signature part name before the signature is generated, call
			/// the IOpcSigningOptions::GetSignaturePartName.
			/// </para>
			/// <para>The signature part that stores signature markup is specific to the signature.</para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignature-getsignaturepartname HRESULT
			// GetSignaturePartName( IOpcPartUri **signaturePartName );
			IOpcPartUri GetSignaturePartName();

			/// <summary>
			/// Gets the signature method used to calculate the value in the <c>SignatureValue</c> element of the signature markup.
			/// </summary>
			/// <returns>A pointer to the signature method.</returns>
			/// <remarks>
			/// <para>To set the signature method before the signature is generated, call the IOpcSigningOptions::SetSignatureMethod method.</para>
			/// <para>
			/// To access the signature method before the signature is generated, call the IOpcSigningOptions::GetSignatureMethod. To access
			/// the signature method after the signature is generated, call the <c>IOpcDigitalSignature::GetSignatureMethod</c> method. Both
			/// methods retrieve the value that was set by IOpcSigningOptions::SetSignatureMethod.
			/// </para>
			/// <para>
			/// <c>Important</c> A valid signature method must be set before the signature is generated by calling the
			/// IOpcDigitalSignatureManager::Sign method.
			/// </para>
			/// <para>
			/// When a signature is generated it is serialized as signature markup. The signature method is used to calculate the value in
			/// the <c>SignatureValue</c> element in the signature markup.
			/// </para>
			/// <para>
			/// When a signature is validated, the signature method is used to recalculate that value, and the recalculated value is
			/// compared to the value in the <c>SignatureValue</c> element in the signature markup.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignature-getsignaturemethod HRESULT
			// GetSignatureMethod( LPWSTR *signatureMethod );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetSignatureMethod();

			/// <summary>Gets the canonicalization method that was applied to the <c>SignedInfo</c> element of the serialized signature.</summary>
			/// <returns>
			/// An OPC_CANONICALIZATION_METHOD value that specifies the canonicalization method that was applied to the <c>SignedInfo</c>
			/// element of the signature markup when the signature was generated.
			/// </returns>
			/// <remarks>
			/// <para>
			/// When using the APIs to generate a signature, the C14N canonicalization method that removes comments is applied to the
			/// <c>SignedInfo</c> element. This method corresponds to the <c>OPC_CANONICALIZATION_C14N</c> enum value.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignature-getcanonicalizationmethod HRESULT
			// GetCanonicalizationMethod( OPC_CANONICALIZATION_METHOD *canonicalizationMethod );
			OPC_CANONICALIZATION_METHOD GetCanonicalizationMethod();

			/// <summary>Gets the decoded value in the <c>SignatureValue</c> element of the signature markup.</summary>
			/// <param name="signatureValue">
			/// A pointer to a buffer that contains the decoded value in the <c>SignatureValue</c> element of the signature markup.
			/// </param>
			/// <param name="count">The size of the signatureHashValue buffer.</param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>At least one of the signatureValue, and count parameters is NULL.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The <c>SignatureValue</c> element contains a base-64 encoded value that was computed by applying the signature method to the
			/// <c>SignedInfo</c> element of the signature markup. To get the signature method, call the GetSignatureMethod method.
			/// </para>
			/// <para>
			/// When using the APIs to generate a signature, set the signature method by calling the IOpcSigningOptions::SetSignatureMethod method.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignature-getsignaturevalue HRESULT
			// GetSignatureValue( UINT8 **signatureValue, UINT32 *count );
			void GetSignatureValue(out SafeCoTaskMemHandle signatureValue, out uint count);

			/// <summary>
			/// Gets an enumerator of IOpcSignaturePartReference interface pointers, which represent references to parts that have been signed.
			/// </summary>
			/// <returns>
			/// A pointer to an enumerator of IOpcSignaturePartReference interface pointers, which represent references to parts that have
			/// been signed.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignature-getsignaturepartreferenceenumerator
			// HRESULT GetSignaturePartReferenceEnumerator( IOpcSignaturePartReferenceEnumerator **partReferenceEnumerator );
			IOpcSignaturePartReferenceEnumerator GetSignaturePartReferenceEnumerator();

			/// <summary>
			/// Gets an enumerator of IOpcSignatureRelationshipReference interface pointers, which represent references to relationships
			/// that have been signed.
			/// </summary>
			/// <returns>
			/// A pointer to an enumerator of IOpcSignatureRelationshipReference interface pointers, which represent references to
			/// relationships that have been signed.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignature-getsignaturerelationshipreferenceenumerator
			// HRESULT GetSignatureRelationshipReferenceEnumerator( IOpcSignatureRelationshipReferenceEnumerator
			// **relationshipReferenceEnumerator );
			IOpcSignatureRelationshipReferenceEnumerator GetSignatureRelationshipReferenceEnumerator();

			/// <summary>Gets a string that indicates the time at which the signature was generated.</summary>
			/// <returns>A pointer to a string that indicates the time at which the signature was generated.</returns>
			/// <remarks>
			/// <para>To get the format of the signingTime string, call the GetTimeFormat method.</para>
			/// <para><c>Caution</c> This is not a trusted time stamp.</para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignature-getsigningtime HRESULT GetSigningTime(
			// LPWSTR *signingTime );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetSigningTime();

			/// <summary>Gets the format of the string returned by the GetSigningTime method.</summary>
			/// <returns>An OPC_SIGNATURE_TIME_FORMAT value that describes the format of the string returned by GetSigningTime.</returns>
			/// <remarks>
			/// <para>
			/// To access a string that indicates the time at which the current package signature was generated, call the GetSigningTime method.
			/// </para>
			/// <para>
			/// To set the format of the signing time string before the signature is generated, call the IOpcSigningOptions::SetTimeFormat
			/// method. To access the format before the signature is generated, call the IOpcSigningOptions::GetTimeFormat method.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignature-gettimeformat HRESULT GetTimeFormat(
			// OPC_SIGNATURE_TIME_FORMAT *timeFormat );
			OPC_SIGNATURE_TIME_FORMAT GetTimeFormat();

			/// <summary>
			/// Gets an IOpcSignatureReference interface pointer that represents the reference to the package-specific <c>Object</c> element
			/// that has been signed.
			/// </summary>
			/// <returns>
			/// An IOpcSignatureReference interface pointer that represents the reference to the package-specific <c>Object</c> element that
			/// has been signed.
			/// </returns>
			/// <remarks>
			/// <para>
			/// The IOpcSignatureReference interface pointer received in the packageObjectReference parameter represents the
			/// <c>Reference</c> element that has the <c>URI</c> attribute value set to "#idPackageObject". The <c>URI</c> attribute value
			/// of this element is the <c>Id</c> attribute value of the package-specific <c>Object</c> element, prefixed with a pound sign ("#").
			/// </para>
			/// <para>
			/// When the signature is generated and serialized as signature markup, the reference and the referenced package-specific
			/// <c>Object</c> element are signed. The following markup shows the package-specific <c>Reference</c> element and the
			/// package-specific <c>Object</c> element in the resultant signature markup.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignature-getpackageobjectreference HRESULT
			// GetPackageObjectReference( IOpcSignatureReference **packageObjectReference );
			IOpcSignatureReference GetPackageObjectReference();

			/// <summary>Gets an enumerator of certificates that are used in the signature.</summary>
			/// <returns>A pointer to an enumerator of pointers to CERT_CONTEXT structures that are used in the signature.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignature-getcertificateenumerator HRESULT
			// GetCertificateEnumerator( IOpcCertificateEnumerator **certificateEnumerator );
			IOpcCertificateEnumerator GetCertificateEnumerator();

			/// <summary>
			/// Gets an enumerator of the IOpcSignatureReference interface pointers that represent references to application-specific XML
			/// elements that have been signed.
			/// </summary>
			/// <returns>
			/// A pointer to an enumerator of IOpcSignatureReference interface pointers. An <c>IOpcSignatureReference</c> interface pointer
			/// represents a reference to an application-specific XML element that has been signed.
			/// </returns>
			/// <remarks>
			/// <para>
			/// To access the signed XML Element by using an IOpcSignatureCustomObject interface pointer, call the
			/// IOpcSignatureCustomObjectEnumerator::GetCurrent method. To access the markup of the signed XML element, call the
			/// IOpcSignatureCustomObject::GetXml method.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignature-getcustomreferenceenumerator HRESULT
			// GetCustomReferenceEnumerator( IOpcSignatureReferenceEnumerator **customReferenceEnumerator );
			IOpcSignatureReferenceEnumerator GetCustomReferenceEnumerator();

			/// <summary>
			/// Gets an enumerator of IOpcSignatureCustomObject interface pointers that represent application-specific <c>Object</c>
			/// elements in the signature markup.
			/// </summary>
			/// <returns>A pointer to an enumerator of IOpcSignatureCustomObject interface pointers.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignature-getcustomobjectenumerator HRESULT
			// GetCustomObjectEnumerator( IOpcSignatureCustomObjectEnumerator **customObjectEnumerator );
			IOpcSignatureCustomObjectEnumerator GetCustomObjectEnumerator();

			/// <summary>Gets the signature markup.</summary>
			/// <param name="signatureXml">A pointer to a buffer that contains the signature markup.</param>
			/// <param name="count">The size of the signatureXml buffer.</param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>At least one of the digestValue, and count parameters is NULL.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method allocates memory used by the buffer returned in signatureXml. If the method succeeds, call the CoTaskMemFree
			/// function to free the memory.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignature-getsignaturexml HRESULT
			// GetSignatureXml( UINT8 **signatureXml, UINT32 *count );
			void GetSignatureXml(out SafeCoTaskMemHandle signatureXml, out uint count);
		}

		/// <summary>A read-only enumerator of IOpcDigitalSignature interface pointers.</summary>
		/// <remarks>
		/// <para>
		/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first pointer
		/// of the enumerator, call the MoveNextmethod after creating the enumerator.
		/// </para>
		/// <para>Changes to the set will invalidate the enumerator and all subsequent calls to it will fail.</para>
		/// <para>
		/// To get an <c>IOpcDigitalSignatureEnumerator</c> interface pointer, call the IOpcDigitalSignatureManager::GetSignatureEnumerator method.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcdigitalsignatureenumerator
		[PInvokeData("msopc.h", MSDNShortId = "73fd0e47-7503-470d-b649-e4b2ba492bf1")]
		[ComImport, Guid("967b6882-0ba3-4358-b9e7-b64c75063c5e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcDigitalSignatureEnumerator
		{
			/// <summary>Moves the current position of the enumerator to the next IOpcDigitalSignature interface pointer.</summary>
			/// <param name="hasNext">
			/// <para>A Boolean value that indicates the status of the IOpcDigitalSignature interface pointer at the current position.</para>
			/// <para>The value of hasNext is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The current position of the enumerator has been advanced to the next pointer and that pointer is valid.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been advanced past the end of the collection and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasNext parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_NEXT 0x80510051</term>
			/// <term>The current position is already past the last item of the enumerator.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignatureenumerator-movenext HRESULT MoveNext(
			// BOOL *hasNext );
			[PreserveSig]
			HRESULT MoveNext([MarshalAs(UnmanagedType.Bool)] out bool hasNext);

			/// <summary>Moves the current position of the enumerator to the previous IOpcDigitalSignature interface pointer.</summary>
			/// <param name="hasPrevious">
			/// <para>A Boolean value that indicates the status of the IOpcDigitalSignature interface pointer at the current position.</para>
			/// <para>The value of hasPrevious is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>
			/// The current position of the enumerator has been moved to the previous pointer in the collection, and that pointer is valid.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been moved past the beginning of the collection and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasPrevious parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_PREVIOUS 0x80510052</term>
			/// <term>The current position already precedes the first item of the enumerator.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignatureenumerator-moveprevious HRESULT
			// MovePrevious( BOOL *hasPrevious );
			[PreserveSig]
			HRESULT MovePrevious([MarshalAs(UnmanagedType.Bool)] out bool hasPrevious);

			/// <summary>Gets the IOpcDigitalSignature interface pointer at the current position of the enumerator.</summary>
			/// <param name="certificate">An IOpcDigitalSignature interface pointer.</param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The partReference parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_INVALID_POSITION 0x80510053</term>
			/// <term>The enumerator cannot perform this operation from its current position.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_DUPLICATE_PACKAGE_OBJECT_REFERENCES 0x8051002D</term>
			/// <term>
			/// The signature markup contains more than one Reference element that refers to the package Object element, but only one such
			/// Reference is allowed.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_DUPLICATE_SIGNATURE_PROPERTY_ELEMENT 0x80510028</term>
			/// <term>The signature markup contains more than one SignatureProperty element that has the same Id attribute.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_EXTERNAL_SIGNATURE_REFERENCE 0x8051002F</term>
			/// <term>
			/// A Reference element in the signature markup indicates an object that is external to the package. Reference elements must
			/// point to parts or Object elements that are internal.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_INVALID_CANONICALIZATION_METHOD 0x80510022</term>
			/// <term>An unsupported canonicalization method was requested or used in a signature.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_INVALID_SIGNATURE_COUNT 0x8051002B</term>
			/// <term>A Signature part does not contain the signature markup for exactly one signature.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_INVALID_SIGNATURE_XML 0x8051002A</term>
			/// <term>
			/// The signature markup in a Signature part does not conform to the schema specified in the OPC or XML-Signature Syntax and
			/// Processing (http://go.microsoft.com/fwlink/p/?linkid=132847).
			/// </term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_MISSING_CANONICALIZATION_TRANSFORM 0x80510032</term>
			/// <term>A relationships transform must be followed by a canonicalization method.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_MISSING_PACKAGE_OBJECT_REFERENCE 0x8051002E</term>
			/// <term>The signature markup is missing a Reference to the package-specific Object element.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_MISSING_SIGNATURE_ALGORITHM 0x8051002C</term>
			/// <term>The signature markup does not specify signature method algorithm.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_MISSING_SIGNATURE_PART 0x80510020</term>
			/// <term>The specified Signature part does not exist in the package.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_MISSING_SIGNATURE_PROPERTIES_ELEMENT 0x80510026</term>
			/// <term>The SignatureProperties element was not found in the signature markup.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_MISSING_SIGNATURE_PROPERTY_ELEMENT 0x80510027</term>
			/// <term>The SignatureProperty child element of the SignatureProperties element was not found.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_MISSING_SIGNATURE_TIME_PROPERTY 0x80510029</term>
			/// <term>
			/// The SignatureProperty element with the Id attribute value of "idSignatureTime" does not exist or is not correctly constructed.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_MULTIPLE_RELATIONSHIP_TRANSFORMS 0x80510031</term>
			/// <term>
			/// More than one relationships transform is specified for a Reference element, but only one relationships transform is allowed.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_REFERENCE_MISSING_CONTENT_TYPE 0x80510030</term>
			/// <term>
			/// The URI attribute value of a Reference element in the signature markup does not include the content type of the referenced part.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_SIGNATURE_REFERENCE_MISSING_URI 0x80510043</term>
			/// <term>The URI attribute is required for a Reference element but is missing.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_UNEXPECTED_CONTENT_TYPE 0x80510005</term>
			/// <term>
			/// Either the content type of a part differed from the expected content type (specified in the OPC, ECMA-376 Part 2), or the
			/// part content did not match the part's content type.
			/// </term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first
			/// pointer of the enumerator, call the MoveNextmethod after creating the enumerator.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignatureenumerator-getcurrent HRESULT
			// GetCurrent( IOpcDigitalSignature **digitalSignature );
			[PreserveSig]
			HRESULT GetCurrent(out IOpcDigitalSignature certificate);

			/// <summary>Creates a copy of the current IOpcDigitalSignatureEnumerator interface pointer and all its descendants.</summary>
			/// <returns>A pointer to a copy of the IOpcDigitalSignatureEnumerator interface pointer.</returns>
			/// <remarks>
			/// <para>The copy has a current position and set that are identical to the current enumerator.</para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignatureenumerator-clone HRESULT Clone(
			// IOpcDigitalSignatureEnumerator **copy );
			IOpcDigitalSignatureEnumerator Clone();
		}

		/// <summary>
		/// Provides access to Packaging Digital Signature Interfaces for a package that is represented by Packaging API objects. These
		/// interface methods are called to generate a signature, or to access and validate existing signatures in the package.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Before the Sign method is called to generate a signature, the IOpcSigningOptions::SetDefaultDigestMethod and
		/// IOpcSigningOptions::SetSignatureMethod methods must be called.
		/// </para>
		/// <para>
		/// To create an <c>IOpcDigitalSignatureManager</c> interface pointer, call the IOpcFactory::CreateDigitalSignatureManager method.
		/// </para>
		/// <para>
		/// <c>Important</c> If the package is modified while the Sign method is being executed, the method may fail or generate an
		/// inconsistent signature. To avoid corruption of the package, use the APIs to save the package prior to calling <c>Sign</c>. For
		/// information about how to save a package, see Saving a Package.
		/// </para>
		/// <para>
		/// The Validate method checks that the specified signature (signed entities and the signature markup) has not been altered since
		/// the signature was generated, but does not validate the identity of the signer.
		/// </para>
		/// <para><c>Important</c> The caller must validate the identity of the signer.</para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>IOpcSigningOptions For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcdigitalsignaturemanager
		[PInvokeData("msopc.h", MSDNShortId = "13e8a7b9-1d25-421b-bc81-adc495e6d9c7")]
		[ComImport, Guid("d5e62a0b-696d-462f-94df-72e33cef2659"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcDigitalSignatureManager
		{
			/// <summary>Gets an IOpcPartUri interface pointer that represents the part name of the Digital Signature Origin part.</summary>
			/// <returns>An IOpcPartUri interface pointer, or <c>NULL</c> if the Digital Signature Origin part does not exist.</returns>
			/// <remarks>
			/// <para>
			/// When using the APIs to generate a signature, set the Digital Signature Origin part name by calling the
			/// SetSignatureOriginPartName method.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignaturemanager-getsignatureoriginpartname
			// HRESULT GetSignatureOriginPartName( IOpcPartUri **signatureOriginPartName );
			IOpcPartUri GetSignatureOriginPartName();

			/// <summary>
			/// Sets the part name of the Digital Signature Origin part to the name represented by a specified IOpcPartUri interface pointer.
			/// </summary>
			/// <param name="signatureOriginPartName">
			/// A pointer to an IOpcPartUri interface pointer that represents the desired part name for the Digital Signature Origin part.
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DS_SIGNATURE_ORIGIN_EXISTS 0x80510054</term>
			/// <term>A Digital Signature Origin part already exists in the package and cannot be renamed.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_DUPLICATE_PART 0x8051000B</term>
			/// <term>A part with the specified part name already exists in the current package.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// If the Digital Signature Origin part exists or if the part name that is in the signatureOriginPartName parameter is being
			/// used for another part, this method will fail.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignaturemanager-setsignatureoriginpartname
			// HRESULT SetSignatureOriginPartName( IOpcPartUri *signatureOriginPartName );
			[PreserveSig]
			HRESULT SetSignatureOriginPartName(IOpcPartUri signatureOriginPartName);

			/// <summary>Gets an enumerator of IOpcDigitalSignature interface pointers, which represent package signatures.</summary>
			/// <returns>A pointer to an enumerator of IOpcDigitalSignature interface pointers, which represent package signatures.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignaturemanager-getsignatureenumerator HRESULT
			// GetSignatureEnumerator( IOpcDigitalSignatureEnumerator **signatureEnumerator );
			IOpcDigitalSignatureEnumerator GetSignatureEnumerator();

			/// <summary>Removes from the package a specified signature part that stores signature markup.</summary>
			/// <param name="signaturePartName">
			/// An IOpcPartUri interface pointer that represents the part name of the signature part to be removed.
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The signaturePartName parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_NO_SUCH_PART 0x80510018</term>
			/// <term>The specified part does not exist.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>If the specified signature part does not exist, this method will fail.</para>
			/// <para>If a part is removed from a package, it will not be saved when the package is saved.</para>
			/// <para>
			/// If a removed part is the source of one or more relationships, those relationships will not be saved when the package is saved.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignaturemanager-removesignature HRESULT
			// RemoveSignature( IOpcPartUri *signaturePartName );
			[PreserveSig]
			HRESULT RemoveSignature(IOpcPartUri signaturePartName);

			/// <summary>Creates an IOpcSigningOptions interface pointer.</summary>
			/// <returns>A pointer to an IOpcSigningOptions interface pointer.</returns>
			/// <remarks>
			/// <para>
			/// This method creates an IOpcSigningOptions interface pointer that is required to set the properties of a signature to be generated
			/// </para>
			/// <para>
			/// To generate a signature, call the IOpcDigitalSignatureManager::Sign method with the signingOptions parameter value set to an
			/// IOpcSigningOptions interface pointer that is retrieved by the <c>CreateSigningOptions</c> method.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignaturemanager-createsigningoptions HRESULT
			// CreateSigningOptions( IOpcSigningOptions **signingOptions );
			IOpcSigningOptions CreateSigningOptions();

			/// <summary>Validates a specified package signature using a specified certificate.</summary>
			/// <param name="signature">An IOpcDigitalSignature interface pointer that represents the signature to be validated.</param>
			/// <param name="certificate">
			/// A pointer to a CERT_CONTEXT structure that contains a certificate that is used to validate the signature.
			/// </param>
			/// <param name="validationResult">A value that describes the result of the validation check.</param>
			/// <remarks>
			/// <para>
			/// This method does not perform security checks on an X.509 Public Key Infrastructure Certificate; the caller must perform the
			/// checks for revocation, expiration, certificate chain, and all other necessary checks.
			/// </para>
			/// <para>
			/// This method checks that the specified signature (signed entities and the signature markup) has not been altered since the
			/// signature was generated, but does not validate the identity of the signer.
			/// </para>
			/// <para><c>Important</c> The caller must validate the identity of the signer.</para>
			/// <para>If there are errors in a package signature, some of these errors may not be exposed until this method is called.</para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignaturemanager-validate HRESULT Validate(
			// IOpcDigitalSignature *signature, const CERT_CONTEXT *certificate, OPC_SIGNATURE_VALIDATION_RESULT *validationResult );
			void Validate(IOpcDigitalSignature signature, in CERT_CONTEXT certificate, out OPC_SIGNATURE_VALIDATION_RESULT validationResult);

			/// <summary>
			/// Signs the package by generating a signature by using the specified certificate and IOpcSigningOptions interface pointer. The
			/// resultant signature is represented by an IOpcDigitalSignature interface pointer.
			/// </summary>
			/// <param name="certificate">A pointer to a CERT_CONTEXT structure that contains the certificate.</param>
			/// <param name="signingOptions">An IOpcSigningOptions interface pointer that is used to generate the signature.</param>
			/// <returns>A new IOpcDigitalSignature interface pointer that represents the signature.</returns>
			/// <remarks>
			/// <para>
			/// This method uses Packaging objects to make changes to a package. The resultant changes are not saved until the package
			/// itself is saved.
			/// </para>
			/// <para>
			/// Before this method is called to generate a signature, call the IOpcSigningOptions::SetDefaultDigestMethod and
			/// IOpcSigningOptions::SetSignatureMethod methods.
			/// </para>
			/// <para>
			/// To create an IOpcSigningOptions interface pointer, which is required by this method, call the CreateSigningOptions method.
			/// </para>
			/// <para>
			/// <c>Important</c> If the package is modified while this method is being executed, <c>Sign</c> may fail or generate an
			/// inconsistent signature. To avoid corruption of the package, use the APIs to save the package prior to calling <c>Sign</c>.
			/// For information about how to save a package, see Saving a Package.
			/// </para>
			/// <para>This method may create the following parts and relationships:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>The Digital Signature Origin part</term>
			/// </item>
			/// <item>
			/// <term>The package relationship of the digital signature origin relationship type</term>
			/// </item>
			/// <item>
			/// <term>One signature part that contains signature markup</term>
			/// </item>
			/// <item>
			/// <term>One or more part that contains a certificate</term>
			/// </item>
			/// <item>
			/// <term>One relationship that targets a signature part and that has the Digital Signature Origin part as its source</term>
			/// </item>
			/// <item>
			/// <term>
			/// One or more relationship that targets a signature part that contains a certificate and that has another signature part as
			/// its source
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// If <c>Sign</c> fails, any of the above parts and relationships may be represented, in the package, by Packaging objects. If
			/// the method returns the <c>OPC_E_DS_SIGNATURE_METHOD_NOT_SET</c> or <c>OPC_E_DS_DEFAULT_DIGEST_METHOD_NOT_SET</c> error code,
			/// the package has not been altered.
			/// </para>
			/// <para>
			/// If <c>Sign</c> is successful, digest values are calculated for signed enitities, and the generated signature is serialized
			/// as signature markup. Possible signed entities include the <c>Signature</c> element, references, parts, relationships, and
			/// package-specific and application-specific <c>Object</c> elements.
			/// </para>
			/// <para>
			/// Errors that are introduced into a package signature when the caller is using the IOpcSigningOptions interface to set
			/// signature information may not be exposed until <c>Sign</c> is called.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignaturemanager-sign HRESULT Sign( const
			// CERT_CONTEXT *certificate, IOpcSigningOptions *signingOptions, IOpcDigitalSignature **digitalSignature );
			IOpcDigitalSignature Sign(in CERT_CONTEXT certificate, IOpcSigningOptions signingOptions);

			/// <summary>Replaces the existing signature markup that is stored in a specified signature part.</summary>
			/// <param name="signaturePartName">
			/// An IOpcPartUri interface pointer that represents the part name of the signature part that stores the existing signature markup.
			/// </param>
			/// <param name="newSignatureXml">A buffer that contains the signature markup that will replace the existing markup.</param>
			/// <param name="count">The size of the newSignatureXml buffer.</param>
			/// <returns>
			/// A pointer to a new IOpcDigitalSignature interface that represents the signature derived from the signature markup that is
			/// passed in newSignatureXml.
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method does not validate the signature that is derived from the new signature markup that is in the newSignatureXml parameter.
			/// </para>
			/// <para>
			/// The caller must confirm that the new signature markup, which replaces the existing signature markup in the specified
			/// signature part, will not break the signature.
			/// </para>
			/// <para>
			/// This method changes the existing signature markup; certificates and relationships that have the specified signature part as
			/// their source are preserved.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcdigitalsignaturemanager-replacesignaturexml HRESULT
			// ReplaceSignatureXml( IOpcPartUri *signaturePartName, const UINT8 *newSignatureXml, UINT32 count, IOpcDigitalSignature
			// **digitalSignature );
			IOpcDigitalSignature ReplaceSignatureXml(IOpcPartUri signaturePartName, [In] byte[] newSignatureXml, uint count);
		}

		/// <summary>
		/// Creates Packaging API objects and provides support for saving and loading packages. Objects that are created by
		/// <c>IOpcFactory</c> interface methods provide support for creating, populating, modifying, and digitally signing packages.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Do not use a stream to serialize package data when the same stream is being used to deserialize a package; attempting to do so
		/// may result in undefined behavior.
		/// </para>
		/// <para>
		/// To use the Packaging API, the package must map to a ZIP archive as specified in the ECMA-376 OpenXML, 1st Edition, Part 2: Open
		/// Packaging Conventions (OPC).
		/// </para>
		/// <para>
		/// To create a factory that implements the <c>IOpcFactory</c> interface, call the CoCreateInstance function. This factory is not
		/// tied to any particular package or Packaging API object, and it can be used for the lifetime of the application. For example code
		/// that shows how to create a factory implementing <c>IOpcFactory</c>, see the Getting Started with the Packaging API.
		/// </para>
		/// <para>IOpcFactory Support on Previous Versions of Windows</para>
		/// <para>
		/// If an application attempts to an unsupported <c>IOpcFactory</c> method, the E_NOTIMPL error code will be returned. For more
		/// information, see Getting Started with the Packaging API, and Platform Update for Windows Vista.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcfactory
		[PInvokeData("msopc.h", MSDNShortId = "0a265a0a-c109-4afc-a0ad-d3ee31757aa1")]
		[ComImport, Guid("6d0b4446-cd73-4ab3-94f4-8ccdf6116154"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(OpcFactory))]
		public interface IOpcFactory
		{
			/// <summary>Creates an OPC URI object that represents the root of a package.</summary>
			/// <returns>A pointer to the IOpcUri interface of the OPC URI object that represents the URI of the root of a package.</returns>
			/// <remarks>
			/// <para>The URI of the root of a package is always represented as "/".</para>
			/// <para>Support on Previous Windows Versions</para>
			/// <para>
			/// The behavior and performance of this method is the same on all supported Windows versions. For more information, see Getting
			/// Started with the Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcfactory-createpackagerooturi HRESULT
			// CreatePackageRootUri( IOpcUri **rootUri );
			IOpcUri CreatePackageRootUri();

			/// <summary>Creates a part URI object that represents a part name.</summary>
			/// <param name="pwzUri">A URI that represents the location of a part relative to the root of the package that contains it.</param>
			/// <param name="partUri">
			/// <para>
			/// A pointer to the IOpcPartUri interface of the part URI object. This object represents the part name derived from the URI
			/// passed in pwzUri.
			/// </para>
			/// <para>Part names must conform to the syntax specified in the OPC.</para>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>At least one of the pwzUri and partUri parameters is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_NONCONFORMING_URI 0x80510001</term>
			/// <term>A part name cannot be the empty string "".</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_NONCONFORMING_URI 0x80510001</term>
			/// <term>A part name cannot be a '/'.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_NONCONFORMING_URI 0x80510001</term>
			/// <term>A part name cannot begin with "//".</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_NONCONFORMING_URI 0x80510001</term>
			/// <term>A part name cannot end with a '/'.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_NONCONFORMING_URI 0x80510001</term>
			/// <term>A part name cannot end with a '.'.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_NONCONFORMING_URI 0x80510001</term>
			/// <term>A part name cannot have any segments that end with a '.'.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_NONCONFORMING_URI 0x80510001</term>
			/// <term>
			/// A part name cannot have fragment component. A fragment component is preceded by a '#' character, as described in RFC 3986:
			/// URI Generic Syntax.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OPC_E_NONCONFORMING_URI 0x80510001</term>
			/// <term>
			/// A part name cannot be the name of a Relationships part that indicates another Relationships part as the source of the
			/// relationships contained therein.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OPC_E_RELATIVE_URI_REQUIRED 0x80510002</term>
			/// <term>
			/// A part name cannot be an absolute URI. An absolute URI begins with a schema component followed by a ":", as described in RFC
			/// 3986: URI Generic Syntax.
			/// </term>
			/// </item>
			/// <item>
			/// <term>CreateUri function error</term>
			/// <term>An HRESULT error code from the CreateUri function.</term>
			/// </item>
			/// <item>
			/// <term>WinINet error</term>
			/// <term>An HRESULT error code from a WinINet API.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>Support on Previous Windows Versions</para>
			/// <para>
			/// The behavior and performance of this method is the same on all supported Windows versions. For more information, see Getting
			/// Started with the Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcfactory-createparturi HRESULT CreatePartUri( LPCWSTR
			// pwzUri, IOpcPartUri **partUri );
			[PreserveSig]
			HRESULT CreatePartUri([MarshalAs(UnmanagedType.LPWStr)] string pwzUri, out IOpcPartUri partUri);

			/// <summary>
			/// Creates a stream over a file. This method is a simplified wrapper for a call to the CreateFile function. <c>CreateFile</c>
			/// parameters that are not exposed through this method use their default values. For more information, see <c>CreateFile</c>.
			/// </summary>
			/// <param name="filename">The name of the file over which the stream is created.</param>
			/// <param name="ioMode">The value that describes the read/write status of the stream to be created.</param>
			/// <param name="securityAttributes">
			/// For information about the SECURITY_ATTRIBUTES structure in this parameter, see the CreateFile function.
			/// </param>
			/// <param name="dwFlagsAndAttributes">
			/// <para>The settings and attributes of the file. For most files, <c>FILE_ATTRIBUTE_NORMAL</c> can be used.</para>
			/// <para>For more information about this parameter, see CreateFile.</para>
			/// </param>
			/// <param name="stream">A pointer to the IStream interface of the stream.</param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>The value passed in the ioMode parameter is not a valid OPC_STREAM_IO_MODE enumeration value.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>At least one of the filename and stream parameters is NULL.</term>
			/// </item>
			/// <item>
			/// <term>CreateFile function error</term>
			/// <term>An HRESULT error code from the CreateFile function.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Do not use a stream to serialize package data when the same stream is being used to deserialize a package, because the
			/// attempt may result in undefined behavior.
			/// </para>
			/// <para>
			/// For information about using this method when loading or saving a package, see the Loading a Package or Saving a Package
			/// programming task.
			/// </para>
			/// <para>Support on Previous Windows Versions</para>
			/// <para>
			/// The behavior and performance of this method is the same on all supported Windows versions. For more information, see Getting
			/// Started with the Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcfactory-createstreamonfile HRESULT CreateStreamOnFile(
			// LPCWSTR filename, OPC_STREAM_IO_MODE ioMode, LPSECURITY_ATTRIBUTES securityAttributes, DWORD dwFlagsAndAttributes, IStream
			// **stream );
			[PreserveSig]
			HRESULT CreateStreamOnFile([MarshalAs(UnmanagedType.LPWStr)] string filename, OPC_STREAM_IO_MODE ioMode, [Optional] SECURITY_ATTRIBUTES securityAttributes, FileFlagsAndAttributes dwFlagsAndAttributes, out IStream stream);

			/// <summary>Creates a package object that represents an empty package.</summary>
			/// <returns>A pointer to the IOpcPackage interface of the package object that represents an empty package.</returns>
			/// <remarks>
			/// <para>Support on Previous Versions of Windows</para>
			/// <para>
			/// This method is not supported on versions of Windows prior to Windows 7. For more information, see Getting Started with the
			/// Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcfactory-createpackage HRESULT CreatePackage(
			// IOpcPackage **package );
			IOpcPackage CreatePackage();

			/// <summary>
			/// Deserializes package data from a stream and creates a package object to represent the package being read. While a Packaging
			/// API object obtained from the package object, or the package object itself, is still in use, the stream may be used to access
			/// package data.
			/// </summary>
			/// <param name="stream">
			/// <para>A pointer to the IStream interface of the stream.</para>
			/// <para>
			/// The stream must be readable, seekable, have size, and must contain package data. Additionally, if the stream is not
			/// clonable, it will be buffered and read sequentially, incurring overhead.
			/// </para>
			/// </param>
			/// <param name="flags">
			/// The value that specifies the read settings for caching package components and validating them against OPC conformance requirements.
			/// </param>
			/// <param name="package">
			/// A pointer to the IOpcPackage interface of the package object that represents the package being read through the stream.
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>The value passed in the flags parameter is not a valid OPC_READ_FLAGS enumeration value.</term>
			/// </item>
			/// <item>
			/// <term>E_NOTIMPL</term>
			/// <term>This method is not implemented for this version of Windows.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>At least one of the stream and package parameters is NULL.</term>
			/// </item>
			/// <item>
			/// <term>IStream interface error</term>
			/// <term>An HRESULT error code from the IStream interface.</term>
			/// </item>
			/// <item>
			/// <term>Package Consumption error</term>
			/// <term>An HRESULT error code from the Package Consumption Error Group.</term>
			/// </item>
			/// <item>
			/// <term>Part URI error</term>
			/// <term>An HRESULT error code from the Part URI Error Group.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Do not use a stream to serialize package data when the same stream is being used to deserialize a package, because the
			/// attempt may result in undefined behavior.
			/// </para>
			/// <para>
			/// The Packaging APIs can interact with packages that map a ZIP archive as specified in the OPC, and that are based on either
			/// Zip32 (ZIP 2.0) or Zip64 (ZIP 4.5) encoding.
			/// </para>
			/// <para>For information about how to use this method to load a package, see the Loading a Package programming task.</para>
			/// <para>Support on Previous Versions of Windows</para>
			/// <para>
			/// This method is not supported on versions of Windows prior to Windows 7. For more information, see Getting Started with the
			/// Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcfactory-readpackagefromstream HRESULT
			// ReadPackageFromStream( IStream *stream, OPC_READ_FLAGS flags, IOpcPackage **package );
			[PreserveSig]
			HRESULT ReadPackageFromStream(IStream stream, OPC_READ_FLAGS flags, out IOpcPackage package);

			/// <summary>Serializes a package that is represented by a package object.</summary>
			/// <param name="package">A pointer to the IOpcPackage interface of the package object that contains data to be serialized.</param>
			/// <param name="flags">The value that describes the encoding method used in serialization.</param>
			/// <param name="stream">A pointer to the IStream interface of the stream where the package object data will be written.</param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>The value passed in the flags parameter is not a valid OPC_WRITE_FLAGS enumeration value.</term>
			/// </item>
			/// <item>
			/// <term>E_NOTIMPL</term>
			/// <term>This method is not implemented for this version of Windows.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>At least one of the stream and package parameters is NULL.</term>
			/// </item>
			/// <item>
			/// <term>IStream interface error</term>
			/// <term>An HRESULT error code from the IStream interface.</term>
			/// </item>
			/// <item>
			/// <term>Package Consumption error</term>
			/// <term>An HRESULT error code from the Package Consumption Error Group.</term>
			/// </item>
			/// <item>
			/// <term>Part URI error</term>
			/// <term>An HRESULT error code from the Part URI Error Group.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Do not use a stream to serialize package data when the same stream is being used to deserialize a package, because the
			/// attempt may result in undefined behavior.
			/// </para>
			/// <para>
			/// For information about how to use this method to save a package that is represented as a package object, see the Saving a
			/// Package programming task.
			/// </para>
			/// <para>Support on Previous Versions of Windows</para>
			/// <para>
			/// This method is not supported on versions of Windows prior to Windows 7. For more information, see Getting Started with the
			/// Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcfactory-writepackagetostream HRESULT
			// WritePackageToStream( IOpcPackage *package, OPC_WRITE_FLAGS flags, IStream *stream );
			[PreserveSig]
			HRESULT WritePackageToStream(IOpcPackage package, OPC_WRITE_FLAGS flags, IStream stream);

			/// <summary>Creates a digital signature manager object for a package object.</summary>
			/// <param name="package">
			/// A pointer to the IOpcPackage interface of the package object to associate with the digital signature manager object.
			/// </param>
			/// <returns>
			/// <para>
			/// A pointer to the IOpcDigitalSignatureManager interface of the digital signature manager object that is created for use with
			/// the package object.
			/// </para>
			/// <para>
			/// A digital signature manager object provides access to the Packaging API's digital signature interfaces and methods. These
			/// can be used to sign the package represented by the package object or to validate the signatures in a package that has
			/// already been signed.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// If a package is modified while Packaging Digital Signature Interfaces are being used to sign the package, signing may fail
			/// or result in an inconsistent signature or package.
			/// </para>
			/// <para>Support on Previous Versions of Windows</para>
			/// <para>
			/// This method is not supported on versions of Windows prior to Windows 7. For more information, see Getting Started with the
			/// Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcfactory-createdigitalsignaturemanager HRESULT
			// CreateDigitalSignatureManager( IOpcPackage *package, IOpcDigitalSignatureManager **signatureManager );
			IOpcDigitalSignatureManager CreateDigitalSignatureManager(IOpcPackage package);
		}

		/// <summary>Represents a package and provides methods to access the package's parts and relationships.</summary>
		/// <remarks>
		/// <para>To get a pointer to this interface, call either the IOpcFactory::CreatePackage or IOpcFactory::ReadPackageFromStream method.</para>
		/// <para>
		/// Package relationships serve as an entry point to the package by links from the package to target resources. The target of a
		/// package relationship is often an important part described in the ECMA-376 OpenXML, 1st Edition, Part 2: Open Packaging
		/// Conventions (OPC) or by the package format designer.
		/// </para>
		/// <para>
		/// For example, a package relationship can provide access to the Core Properties part that stores package metadata, or to a part
		/// containing format-specific data, where the part and data are described by the package designer. The Main Document part of the
		/// word processing OpenXML format is one such format-specific part. For more information about this part, see Part 1: Fundamentals
		/// in ECMA-376 OpenXML (http://go.microsoft.com/fwlink/p/?linkid=123375).
		/// </para>
		/// <para>
		/// The definitive way to find a part of interest is by using a relationship type. Several steps are required; for details, see the
		/// Parts Overview and the Finding the Core Properties Part how-to task.
		/// </para>
		/// <para>For more information about packages, see the Open Packaging Conventions Fundamentals and the OPC.</para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcpackage
		[PInvokeData("msopc.h", MSDNShortId = "e7052dd2-c910-41d8-a58a-8f3e68e09dd0")]
		[ComImport, Guid("42195949-3B79-4fc8-89C6-FC7FB979EE70"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcPackage
		{
			/// <summary>Gets a part set object that contains IOpcPart interface pointers.</summary>
			/// <returns>
			/// A pointer to the IOpcPartSet interface of the part set object that contains IOpcPart interface pointers to part objects.
			/// </returns>
			/// <remarks>
			/// <para>The IOpcPart interface is only used to represent parts in the package that are not Relationships parts.</para>
			/// <para>
			/// For more information about packages, parts, relationships, and the interfaces that represent them, see the Open Packaging
			/// Conventions Fundamentals and the ECMA-376 OpenXML, 1st Edition, Part 2: Open Packaging Conventions (OPC).
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcpackage-getpartset HRESULT GetPartSet( IOpcPartSet
			// **partSet );
			IOpcPartSet GetPartSet();

			/// <summary>Gets a relationship set object that represents the Relationships part that stores package relationships.</summary>
			/// <returns>
			/// A pointer to the IOpcRelationshipSet interface of the relationship set object. The set represents the Relationships part
			/// that stores package relationships.
			/// </returns>
			/// <remarks>
			/// <para>The Package relationships represented in the set provide the entry point to a package for an application.</para>
			/// <para>
			/// For more information about packages, parts, relationships, and the interfaces that represent them, see the Open Packaging
			/// Conventions Fundamentals and the ECMA-376 OpenXML, 1st Edition, Part 2: Open Packaging Conventions (OPC).
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcpackage-getrelationshipset HRESULT GetRelationshipSet(
			// IOpcRelationshipSet **relationshipSet );
			IOpcRelationshipSet GetRelationshipSet();
		}

		/// <summary>Represents a part that contains data and is not a Relationships part.</summary>
		/// <remarks>
		/// <para>
		/// To create a part object to represent a part, call the IOpcPartSet::CreatePart method. To get a pointer to the interface of a
		/// part object that represents an existing part, call the IOpcPartSet::GetPart or IOpcPartEnumerator::GetCurrent method.
		/// </para>
		/// <para>A Relationships part cannot be represented by an implementation of the <c>IOpcPart</c> interface.</para>
		/// <para>For more information about parts, see the Open Packaging Conventions Fundamentals and the OPC.</para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcpart
		[PInvokeData("msopc.h", MSDNShortId = "e6a40f30-03d1-4c93-a5e0-563b4c6588b4")]
		[ComImport, Guid("42195949-3B79-4fc8-89C6-FC7FB979EE71"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcPart
		{
			/// <summary>
			/// Gets a relationship set object that represents the Relationships part that stores relationships that have the part as their source.
			/// </summary>
			/// <returns>
			/// A pointer to a relationship set object that represents the Relationships part that stores all relationships that have the
			/// part as their source.
			/// </returns>
			/// <remarks>
			/// <para>
			/// The definitive way to find a part of interest is by using a relationship type to find the relationship that has the part of
			/// interest as its target. The target's URI can then be resolved to a part name which is used to access the part.
			/// </para>
			/// <para>
			/// For more information about using the relationship type to find a relationship and then a part of interest, see
			/// IOpcRelationshipSet and IOpcRelationship.
			/// </para>
			/// <para>
			/// For more information about parts and relationships, see the Open Packaging Conventions Fundamentals and the ECMA-376
			/// OpenXML, 1st Edition, Part 2: Open Packaging Conventions (OPC).
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcpart-getrelationshipset HRESULT GetRelationshipSet(
			// IOpcRelationshipSet **relationshipSet );
			IOpcRelationshipSet GetRelationshipSet();

			/// <summary>Gets a stream that provides read/write access to part content.</summary>
			/// <returns>A pointer to the IStream interface of a stream that provides read and write access to part content.</returns>
			/// <remarks>
			/// <para>
			/// For more information about parts, see the Open Packaging Conventions Fundamentals and the ECMA-376 OpenXML, 1st Edition,
			/// Part 2: Open Packaging Conventions (OPC).
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcpart-getcontentstream HRESULT GetContentStream( IStream
			// **stream );
			IStream GetContentStream();

			/// <summary>Gets a part URI object that represents the part name.</summary>
			/// <returns>
			/// <para>A pointer to the IOpcPartUri interface of the part URI object that represents the part name.</para>
			/// <para>Part names conform to specific syntax specified in the OPC.</para>
			/// </returns>
			/// <remarks>
			/// <para>For more information about parts, see the Open Packaging Conventions Fundamentals and the OPC.</para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcpart-getname HRESULT GetName( IOpcPartUri **name );
			IOpcPartUri GetName();

			/// <summary>Gets the media type of part content.</summary>
			/// <returns>The media type of part content, as specified by the package format designer and adhering to RFC 2616: HTTP/1.1.</returns>
			/// <remarks>
			/// <para>
			/// For more information about parts, see the Open Packaging Conventions Fundamentals and the ECMA-376 OpenXML, 1st Edition,
			/// Part 2: Open Packaging Conventions (OPC).
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcpart-getcontenttype HRESULT GetContentType( LPWSTR
			// *contentType );
			[return: MarshalAs(UnmanagedType.LPWStr)] 
			string GetContentType();

			/// <summary>Gets a value that describes the way part content is compressed.</summary>
			/// <returns>A value that describes the way part content is compressed.</returns>
			/// <remarks>
			/// <para>
			/// For more information about parts, see the Open Packaging Conventions Fundamentals and the ECMA-376 OpenXML, 1st Edition,
			/// Part 2: Open Packaging Conventions (OPC).
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcpart-getcompressionoptions HRESULT
			// GetCompressionOptions( OPC_COMPRESSION_OPTIONS *compressionOptions );
			OPC_COMPRESSION_OPTIONS GetCompressionOptions();
		}

		/// <summary>A read-only enumerator of IOpcPart interface pointers.</summary>
		/// <remarks>
		/// <para>To get a pointer to this interface, call the IOpcPartSet::GetEnumerator method.</para>
		/// <para>
		/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first pointer
		/// of the enumerator, call the MoveNextmethod after creating the enumerator.
		/// </para>
		/// <para><c>Note</c> Changes to the enumerator's underlying set will invalidate the enumerator, and all subsequent calls will fail.</para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcpartenumerator
		[PInvokeData("msopc.h")]
		[ComImport, Guid("42195949-3B79-4fc8-89C6-FC7FB979EE75"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcPartEnumerator
		{
			/// <summary>Moves the current position of the enumerator to the next IOpcPart interface pointer.</summary>
			/// <param name="hasNext">
			/// <para>A Boolean value that indicates the status of the IOpcPart interface pointer at the current position.</para>
			/// <para>The value of hasNext is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The current position of the enumerator has been advanced to the next pointer and that pointer is valid.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been advanced past the end of the collection and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasNext parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_NEXT 0x80510051</term>
			/// <term>The current position is already past the last item of the enumerator.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first
			/// pointer of the enumerator, call the <c>MoveNext</c> method after creating the enumerator.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcpartenumerator-movenext HRESULT MoveNext( BOOL *hasNext );
			[PreserveSig]
			HRESULT MoveNext([MarshalAs(UnmanagedType.Bool)] out bool hasNext);

			/// <summary>Moves the current position of the enumerator to the previous IOpcPart interface pointer.</summary>
			/// <param name="hasPrevious">
			/// <para>A Boolean value that indicates the status of the IOpcPart interface pointer at the current position.</para>
			/// <para>The value of hasPrevious is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>
			/// The current position of the enumerator has been moved to the previous pointer in the collection, and that pointer is valid.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been moved past the beginning of the collection and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasPrevious parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_PREVIOUS 0x80510052</term>
			/// <term>The current position already precedes the first item of the enumerator.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first
			/// pointer of the enumerator, call the MoveNextmethod after creating the enumerator.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcpartenumerator-moveprevious HRESULT MovePrevious( BOOL
			// *hasPrevious );
			[PreserveSig]
			HRESULT MovePrevious([MarshalAs(UnmanagedType.Bool)] out bool hasPrevious);

			/// <summary>Gets the IOpcPart interface pointer at the current position of the enumerator.</summary>
			/// <param name="part">An IOpcPart interface pointer.</param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The partReference parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_INVALID_POSITION 0x80510053</term>
			/// <term>The enumerator cannot perform this operation from its current position.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first
			/// pointer of the enumerator, call the MoveNextmethod after creating the enumerator.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcpartenumerator-getcurrent HRESULT GetCurrent( IOpcPart
			// **part );
			[PreserveSig]
			HRESULT GetCurrent(out IOpcPart part);

			/// <summary>Creates a copy of the current enumerator and all its descendants.</summary>
			/// <returns>A pointer to the IOpcPartEnumerator interface of the new enumerator.</returns>
			/// <remarks>
			/// <para>
			/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first
			/// pointer of the enumerator, call the MoveNextmethod after creating the enumerator.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcpartenumerator-clone HRESULT Clone( IOpcPartEnumerator
			// **copy );
			IOpcPartEnumerator Clone();
		}

		/// <summary>
		/// An unordered set of IOpcPart interface pointers to part objects that represent the parts in a package that are not Relationships parts.
		/// </summary>
		/// <remarks>
		/// <para>
		/// To retrieve the IOpcPart interface pointer of the part object that represents a specific part, call the PartExists method and
		/// pass in the part name to confirm that the part is represented in the set. If it is, call the GetPart method and pass in the part
		/// name to retrieve the <c>IOpcPart</c> interface pointer.
		/// </para>
		/// <para>The CreatePart method cannot create a part object that represents a Relationships part.</para>
		/// <para>
		/// When a package that is represented as a package object is serialized, only the parts that are represented by part objects with
		/// IOpcPart interface pointers included in the set are serialized with the package.
		/// </para>
		/// <para>
		/// If a part is not represented by a part object in the set when the package is serialized, that part will not be serialized with
		/// the package.
		/// </para>
		/// <para>
		/// When a part object is created and a pointer to it is added to the set, the part it represents is serialized when the package is serialized.
		/// </para>
		/// <para>
		/// When an IOpcPart interface pointer is deleted from the set, the part it represents is not serialized when the package is serialized.
		/// </para>
		/// <para>
		/// An IOpcPart provides access to the properties of the part. For details about these properties, see the Parts Overview and <c>IOpcPart</c>.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcpartset
		[PInvokeData("msopc.h")]
		[ComImport, Guid("42195949-3B79-4fc8-89C6-FC7FB979EE73"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcPartSet
		{
			/// <summary>Gets a part object, which represents a specified part, in the set.</summary>
			/// <param name="name">A pointer to the IOpcPartUri interface of the part URI object that represents the part name of a part.</param>
			/// <returns>A pointer to the IOpcPart of the part object that represents the part that has the specified part name.</returns>
			/// <remarks>
			/// <para>
			/// To retrieve the IOpcPart interface pointer of the part object that represents a specific part, call the PartExists method
			/// and pass in the part name to confirm that the part is represented in the set. If it is, call the <c>GetPart</c> method and
			/// pass in the part name to retrieve the <c>IOpcPart</c> interface pointer.
			/// </para>
			/// <para>
			/// If the part URI object represents the part name of a Relationships part, this method will fail because Relationships parts
			/// are not included in the set.
			/// </para>
			/// <para>
			/// The IOpcPart interface provides access to the properties of a part. For details about these properties, see the Parts
			/// Overview and IOpcPart.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcpartset-getpart HRESULT GetPart( IOpcPartUri *name,
			// IOpcPart **part );
			IOpcPart GetPart(IOpcPartUri name);

			/// <summary>Creates a part object that represents a part and adds a pointer to the object's IOpcPart interface to the set.</summary>
			/// <param name="name">
			/// <para>A pointer to the IOpcPartUri interface of a part URI object that represents the part name of the part.</para>
			/// <para>
			/// To create a part URI object (which implements the IOpcPartUri interface) to represent the part name of the part, call the
			/// IOpcFactory::CreatePartUri method.
			/// </para>
			/// </param>
			/// <param name="contentType">The media type of part content.</param>
			/// <param name="compressionOptions">A value that describes the way to compress the part content of the part.</param>
			/// <returns>
			/// <para>A pointer to the new IOpcPart that represents the part.</para>
			/// <para>This parameter cannot be <c>NULL</c>.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When a part object is created and a pointer to it is added to the set, the part it represents is serialized when the package
			/// is serialized.
			/// </para>
			/// <para>This method cannot create a part object that represents a Relationships part.</para>
			/// <para>
			/// If part content is compressed prior to the creation of the part object, pass the <c>OPC_COMPRESSION_NONE</c> value in the
			/// compressionOptions parameter.
			/// </para>
			/// <para>Part content that is already compressed will not compress significantly more.</para>
			/// <para>
			/// An IOpcPart provides access to the properties of a part. For details about these properties, see the Parts Overview and the
			/// IOpcPart topic.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcpartset-createpart HRESULT CreatePart( IOpcPartUri
			// *name, LPCWSTR contentType, OPC_COMPRESSION_OPTIONS compressionOptions, IOpcPart **part );
			IOpcPart CreatePart(IOpcPartUri name, [MarshalAs(UnmanagedType.LPWStr)] string contentType, OPC_COMPRESSION_OPTIONS compressionOptions);

			/// <summary>Deletes the IOpcPart interface pointer of a specified part object from the set.</summary>
			/// <param name="name">A pointer to the IOpcPartUri interface of the part URI object that represents the part name.</param>
			/// <remarks>
			/// <para>
			/// When an IOpcPart interface pointer is deleted from the set, the part it represents is not serialized when the package is
			/// serialized. Additionally, if the represented part is the source of one or more relationships, those relationships are not
			/// saved with the package when the package object is written.
			/// </para>
			/// <para>
			/// The data contained in a deleted part object is accessible until the package object that contains the deleted part object is
			/// released. Additionally, a Relationship whose source is the part that is represented by the deleted part object also remains
			/// accessible until the package object that contains the deleted part object is released. However, these relationships will not
			/// be saved when the package is saved.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcpartset-deletepart HRESULT DeletePart( IOpcPartUri
			// *name );
			void DeletePart(IOpcPartUri name);

			/// <summary>Gets a value that indicates whether a specified part is represented as a part object in the set.</summary>
			/// <param name="name">A pointer to an IOpcPartUri that represents the part name of the part.</param>
			/// <returns>
			/// <para>One of the following values:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>A part that has the specified part name is represented in the set.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>A part that has the specified part name is not represented in the set.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// To retrieve the IOpcPart interface pointer of the part object that represents a specific part, call the <c>PartExists</c>
			/// method and pass in the part name to confirm that the part is represented in the set. If it is, call the GetPart method and
			/// pass in the part name to retrieve the <c>IOpcPart</c> interface pointer.
			/// </para>
			/// <para>
			/// If the represented part name is the name of a Relationships part, partExists is receives <c>FALSE</c> because Relationships
			/// parts are not included in the set.
			/// </para>
			/// <para>If a part is represented in the set, the part exists in the package being read or the package to be written.</para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcpartset-partexists HRESULT PartExists( IOpcPartUri
			// *name, BOOL *partExists );
			[return: MarshalAs(UnmanagedType.Bool)]
			bool PartExists(IOpcPartUri name);

			/// <summary>Gets an enumerator of IOpcPart interface pointers in the set.</summary>
			/// <returns>A pointer to the IOpcPartEnumerator interface of the enumerator of IOpcPart interface pointers in the set.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcpartset-getenumerator HRESULT GetEnumerator(
			// IOpcPartEnumerator **partEnumerator );
			IOpcPartEnumerator GetEnumerator();
		}

		/// <summary>
		/// Represents the part name of a part. If the part is a Relationships part, it is represented by the IOpcRelationshipSet interface;
		/// otherwise, it is represented by the IOpcPart interface.
		/// </summary>
		/// <remarks>
		/// <para>Support on Previous Windows Versions</para>
		/// <para>
		/// The behavior and performance of this interface is the same on all supported Windows versions. For more information, see Getting
		/// Started with the Packaging API, and Platform Update for Windows Vista.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcparturi
		[PInvokeData("msopc.h", MSDNShortId = "81123212-7a32-4833-b81f-8454a544327d")]
		[ComImport, Guid("7D3BABE7-88B2-46BA-85CB-4203CB016C87"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcPartUri : IOpcUri
		{
			/// <summary>Returns the specified Uniform Resource Identifier (URI) property value in a new <c>BSTR</c>.</summary>
			/// <param name="uriProp">
			/// <para>[in]</para>
			/// <para>A value from the <c>Uri_PROPERTY</c> enumeration.</para>
			/// </param>
			/// <param name="pbstrProperty">
			/// <para>[out]</para>
			/// <para>Address of a <c>BSTR</c> that receives the property value.</para>
			/// </param>
			/// <param name="dwFlags">
			/// <para>[in]</para>
			/// <para>One of the following property-specific flags, or zero.</para>
			/// <para><c>Uri_DISPLAY_NO_FRAGMENT</c> (0x00000001)</para>
			/// <para><c>Uri_PROPERTY_DISPLAY_URI</c>: Exclude the fragment portion of the URI, if any.</para>
			/// <para><c>Uri_PUNYCODE_IDN_HOST</c> (0x00000002)</para>
			/// <para>
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DOMAIN</c>, <c>Uri_PROPERTY_HOST</c>: If the URI is an IDN, always display
			/// the hostname encoded as punycode.
			/// </para>
			/// <para><c>Uri_DISPLAY_IDN_HOST</c> (0x00000004)</para>
			/// <para>
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DOMAIN</c>, <c>Uri_PROPERTY_HOST</c>: Display the hostname in punycode or
			/// Unicode as it would appear in the <c>Uri_PROPERTY_DISPLAY_URI</c> property.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para><c>IUri::GetPropertyBSTR</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// The uriProp parameter must be a string property. This method will fail if the specified property isn't a <c>BSTR</c> property.
			/// </para>
			/// <para>
			/// The pbstrProperty parameter will be set to a new <c>BSTR</c> containing the value of the specified string property. The
			/// caller should use SysFreeString to free the string.
			/// </para>
			/// <para>This method will return and set pbstrProperty to an empty string if the URI doesn't contain the specified property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775026(v=vs.85)
			// HRESULT GetPropertyBSTR( [in] Uri_PROPERTY uriProp, [out] BSTR *pbstrProperty, [in] DWORD dwFlags );
			new void GetPropertyBSTR([In] Uri_PROPERTY uriProp, [MarshalAs(UnmanagedType.BStr)] out string pbstrProperty, [In] Uri_DISPLAY dwFlags);

			/// <summary>
			/// Returns the string length of the specified Uniform Resource Identifier (URI) property. Call this function if you want the
			/// length but don't necessarily want to create a new <c>BSTR</c>.
			/// </summary>
			/// <param name="uriProp">
			/// <para>[in]</para>
			/// <para>A value from the <c>Uri_PROPERTY</c> enumeration.</para>
			/// </param>
			/// <param name="pcchProperty">
			/// <para>[out]</para>
			/// <para>
			/// Address of a <c>DWORD</c> that is set to the length of the value of the string property excluding the <c>NULL</c> terminator.
			/// </para>
			/// </param>
			/// <param name="dwFlags">
			/// <para>[in]</para>
			/// <para>One of the following property-specific flags, or zero.</para>
			/// <para><c>Uri_DISPLAY_NO_FRAGMENT</c> (0x00000001)</para>
			/// <para><c>Uri_PROPERTY_DISPLAY_URI</c>: Exclude the fragment portion of the URI, if any.</para>
			/// <para><c>Uri_PUNYCODE_IDN_HOST</c> (0x00000002)</para>
			/// <para>
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DOMAIN</c>, <c>Uri_PROPERTY_HOST</c>: If the URI is an IDN, always display
			/// the hostname encoded as punycode.
			/// </para>
			/// <para><c>Uri_DISPLAY_IDN_HOST</c> (0x00000004)</para>
			/// <para>
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DOMAIN</c>, <c>Uri_PROPERTY_HOST</c>: Display the hostname in punycode or
			/// Unicode as it would appear in the <c>Uri_PROPERTY_DISPLAY_URI</c> property.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para><c>IUri::GetPropertyLength</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// The uriProp parameter must be a string property. This method will fail if the specified property isn't a <c>BSTR</c> property.
			/// </para>
			/// <para>This method will return and set pcchProperty to if the URI doesn't contain the specified property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775028(v=vs.85)
			// HRESULT GetPropertyLength( [in] Uri_PROPERTY uriProp, [out] DWORD *pcchProperty, [in] DWORD dwFlags );
			new void GetPropertyLength([In] Uri_PROPERTY uriProp, out uint pcchProperty, [In] Uri_DISPLAY dwFlags);

			/// <summary>Returns the specified numeric Uniform Resource Identifier (URI) property value.</summary>
			/// <param name="uriProp">
			/// <para>[in]</para>
			/// <para>A value from the <c>Uri_PROPERTY</c> enumeration.</para>
			/// </param>
			/// <param name="pdwProperty">Address of a DWORD that is set to the value of the specified property.</param>
			/// <param name="dwFlags">Property-specific flags. Must be set to 0.</param>
			/// <remarks>
			/// <para><c>IUri::GetPropertyDWORD</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// The uriProp parameter must be a numeric property. This method will fail if the specified property isn't a <c>DWORD</c> property.
			/// </para>
			/// <para>This method will return and set pdwProperty to if the specified property doesn't exist in the URI.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775027(v=vs.85)
			// HRESULT GetPropertyDWORD( [in] Uri_PROPERTY uriProp, [out] DWORD *pdwProperty, [in] DWORD dwFlags );
			new void GetPropertyDWORD([In] Uri_PROPERTY uriProp, out uint pdwProperty, [In] uint dwFlags);

			/// <summary>Determines if the specified property exists in the Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a BOOL value. Set to TRUE if the specified property exists in the URI.</returns>
			/// <remarks><c>IUri::HasProperty</c> was introduced in Windows Internet Explorer 7.</remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775036(v=vs.85)
			// HRESULT HasProperty( [in] Uri_PROPERTY uriProp, [out] BOOL *pfHasProperty );
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool HasProperty([In] Uri_PROPERTY uriProp);

			/// <summary>Returns the entire canonicalized Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetAbsoluteUri</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c> property.
			/// </para>
			/// <para>This property is not defined for relative URIs.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775013%28v%3dvs.85%29
			// HRESULT GetAbsoluteUri( [out] BSTR *pbstrAbsoluteUri );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetAbsoluteUri();

			/// <summary>Returns the user name, password, domain, and port.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetAuthority</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_AUTHORITY</c> property.
			/// </para>
			/// <para>
			/// If user name and password are not specified, the separator characters (: and @) are removed. The trailing colon is also
			/// removed if the port number is not specified or is the default for the protocol scheme.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775014(v=vs.85)
			// HRESULT GetAuthority( [out] BSTR *pbstrAuthority );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetAuthority();

			/// <summary>Returns a Uniform Resource Identifier (URI) that can be used for display purposes.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetDisplayUri</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// The display URI combines protocol scheme, fully qualified domain name, port number (if not the default for the scheme), full
			/// resource path, query string, and fragment.
			/// </para>
			/// <para>
			/// <c>Note</c> The display URI may have additional formatting applied to it, such that the string produced by
			/// <c>IUri::GetDisplayUri</c> isn't necessarily a valid URI. For this reason, and since the userinfo is not present, the
			/// display URI should be used for viewing only; it should not be used for edit by the user, or as a form of transfer for URIs
			/// inside or between applications.
			/// </para>
			/// <para>
			/// If the scheme is known (for example, http, ftp, or file) then the display URI will hide credentials. However, if the URI
			/// uses an unknown scheme and supplies user name and password, the display URI will also contain the user name and password.
			/// </para>
			/// <para>
			/// <c>Security Warning:</c> Storing sensitive information as clear text in a URI is not recommended. According to RFC3986:
			/// Uniform Resource Identifier (URI), Generic Syntax, Section 7.5, "A password appearing within the userinfo component is
			/// deprecated and should be considered an error except in those rare cases where the 'password' parameter is intended to be public."
			/// </para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_DISPLAY_URI</c> property and no flags.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775015(v=vs.85)
			// HRESULT GetDisplayUri( [out] BSTR *pbstrDisplayString );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetDisplayUri();

			/// <summary>Returns the domain name (including top-level domain) only.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetDomain</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the <c>Uri_PROPERTY_DOMAIN</c> property.
			/// </para>
			/// <para>
			/// If the URL contains only a plain hostname (for example, "http://example/") or a public suffix (for example,
			/// "http://co.uk/"), then <c>IUri::GetDomain</c> returns <c>NULL</c>. Use <c>IUri::GetHost</c> instead.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775016(v=vs.85)
			// HRESULT GetDomain( [out] BSTR *pbstrDomain );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetDomain();

			/// <summary>Returns the file name extension of the resource.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetExtension</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_EXTENSION</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775017(v=vs.85)
			// HRESULT GetExtension( [out] BSTR *pbstrExtension );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetExtension();

			/// <summary>Returns the text following a fragment marker (#), including the fragment marker itself.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetFragment</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_FRAGMENT</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775018(v=vs.85)
			// HRESULT GetFragment( [out] BSTR *pbstrFragment );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetFragment();

			/// <summary>Returns the fully qualified domain name.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetHost</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the <c>Uri_PROPERTY_HOST</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775019(v=vs.85)
			// HRESULT GetHost( [out] BSTR *pbstrHost );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetHost();

			/// <summary>Returns the password, as parsed from the Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetPassword</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// <c>Security Warning:</c> Storing sensitive information as clear text in a URI is not recommended. According to RFC3986:
			/// Uniform Resource Identifier (URI), Generic Syntax, Section 7.5, "A password appearing within the userinfo component is
			/// deprecated and should be considered an error except in those rare cases where the 'password' parameter is intended to be public."
			/// </para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_PASSWORD</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775021(v=vs.85)
			// HRESULT GetPassword( [out] BSTR *pbstrPassword );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetPassword();

			/// <summary>Returns the path and resource name.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetPath</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the <c>Uri_PROPERTY_PATH</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775022(v=vs.85)
			// HRESULT GetPath( [out] BSTR *pbstrPath );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetPath();

			/// <summary>Returns the path, resource name, and query string.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetPathAndQuery</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_PATH_AND_QUERY</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775023(v=vs.85)
			// HRESULT GetPathAndQuery( [out] BSTR *pbstrPathAndQuery );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetPathAndQuery();

			/// <summary>Returns the query string.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetQuery</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the <c>Uri_PROPERTY_QUERY</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775029(v=vs.85)
			// HRESULT GetQuery( [out] BSTR *pbstrQuery );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetQuery();

			/// <summary>Returns the entire original Uniform Resource Identifier (URI) input string.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetRawUri</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_RAW_URI</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775030(v=vs.85)
			// HRESULT GetRawUri( [out] BSTR *pbstrRawUri );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetRawUri();

			/// <summary>Returns the protocol scheme name.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetSchemeName</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_SCHEME_NAME</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775032(v=vs.85)
			// HRESULT GetSchemeName( [out] BSTR *pbstrSchemeName );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetSchemeName();

			/// <summary>Returns the user name and password, as parsed from the Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetUserInfo</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// <c>Security Warning:</c> Storing sensitive information as clear text in a URI is not recommended. According to RFC3986:
			/// Uniform Resource Identifier (URI), Generic Syntax, Section 7.5, "A password appearing within the userinfo component is
			/// deprecated and should be considered an error except in those rare cases where the 'password' parameter is intended to be public."
			/// </para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_USER_INFO</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775033(v=vs.85)
			// HRESULT GetUserInfo( [out] BSTR *pbstrUserInfo );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetUserInfo();

			/// <summary>Returns the user name as parsed from the Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_USER_NAME</c> property.
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775034(v=vs.85)
			// HRESULT GetUserName( [out] BSTR *pbstrUserName );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetUserName();

			/// <summary>Returns a value from the <c>Uri_HOST_TYPE</c> enumeration.</summary>
			/// <returns>Address of a DWORD that receives a value from the Uri_HOST_TYPE enumeration.</returns>
			/// <remarks>
			/// <para><c>IUri::GetHostType</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyDWORD</c> with the
			/// <c>Uri_PROPERTY_HOST_TYPE</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775020(v=vs.85)
			// HRESULT GetHostType( [out] DWORD *pdwHostType );
			new Uri_HOST_TYPE GetHostType();

			/// <summary>Returns the port number.</summary>
			/// <returns>Address of a DWORD that receives the port number value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetPort</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyDWORD</c> with the <c>Uri_PROPERTY_PORT</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775024(v=vs.85)
			// HRESULT GetPort( [out] DWORD *pdwPort );
			new uint GetPort();

			/// <summary>Returns a value from the URL_SCHEME enumeration.</summary>
			/// <returns>Address of a DWORD that receives a value from the URL_SCHEME enumeration.</returns>
			/// <remarks>
			/// <para><c>IUri::GetScheme</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyDWORD</c> with the
			/// <c>Uri_PROPERTY_SCHEME</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775031(v=vs.85)
			// HRESULT GetScheme( [out] DWORD *pdwScheme );
			new URL_SCHEME GetScheme();

			/// <summary>This method is not implemented.</summary>
			/// <returns/>
			new URLZONE GetZone();

			/// <summary>Returns a bitmap of flags that indicate which Uniform Resource Identifier (URI) properties have been set.</summary>
			/// <returns>
			/// <para>[out]</para>
			/// <para>Address of a <c>DWORD</c> that receives a combination of the following flags:</para>
			/// <para><c>Uri_HAS_ABSOLUTE_URI</c> (0x00000000)</para>
			/// <para><c>Uri_PROPERTY_ABSOLUTE_URI</c> exists.</para>
			/// <para><c>Uri_HAS_AUTHORITY</c> (0x00000001)</para>
			/// <para><c>Uri_PROPERTY_AUTHORITY</c> exists.</para>
			/// <para><c>Uri_HAS_DISPLAY_URI</c> (0x00000002)</para>
			/// <para><c>Uri_PROPERTY_DISPLAY_URI</c> exists.</para>
			/// <para><c>Uri_HAS_DOMAIN</c> (0x00000004)</para>
			/// <para><c>Uri_PROPERTY_DOMAIN</c> exists.</para>
			/// <para><c>Uri_HAS_EXTENSION</c> (0x00000008)</para>
			/// <para><c>Uri_PROPERTY_EXTENSION</c> exists.</para>
			/// <para><c>Uri_HAS_FRAGMENT</c> (0x00000010)</para>
			/// <para><c>Uri_PROPERTY_FRAGMENT</c> exists.</para>
			/// <para><c>Uri_HAS_HOST</c> (0x00000020)</para>
			/// <para><c>Uri_PROPERTY_HOST</c> exists.</para>
			/// <para><c>Uri_HAS_HOST_TYPE</c> (0x00004000)</para>
			/// <para><c>Uri_PROPERTY_HOST_TYPE</c> exists.</para>
			/// <para><c>Uri_HAS_PASSWORD</c> (0x00000040)</para>
			/// <para><c>Uri_PROPERTY_PASSWORD</c> exists.</para>
			/// <para><c>Uri_HAS_PATH</c> (0x00000080)</para>
			/// <para><c>Uri_PROPERTY_PATH</c> exists.</para>
			/// <para><c>Uri_HAS_PATH_AND_QUERY</c> (0x00001000)</para>
			/// <para><c>Uri_PROPERTY_PATH_AND_QUERY</c> exists.</para>
			/// <para><c>Uri_HAS_PORT</c> (0x00008000)</para>
			/// <para><c>Uri_PROPERTY_PORT</c> exists.</para>
			/// <para><c>Uri_HAS_QUERY</c> (0x00000100)</para>
			/// <para><c>Uri_PROPERTY_QUERY</c> exists.</para>
			/// <para><c>Uri_HAS_RAW_URI</c> (0x00000200)</para>
			/// <para><c>Uri_PROPERTY_RAW_URI</c> exists.</para>
			/// <para><c>Uri_HAS_SCHEME</c> (0x00010000)</para>
			/// <para><c>Uri_PROPERTY_SCHEME</c> exists.</para>
			/// <para><c>Uri_HAS_SCHEME_NAME</c> (0x00000400)</para>
			/// <para><c>Uri_PROPERTY_SCHEME_NAME</c> exists.</para>
			/// <para><c>Uri_HAS_USER_NAME</c> (0x00000800)</para>
			/// <para><c>Uri_PROPERTY_USER_NAME</c> exists.</para>
			/// <para><c>Uri_HAS_USER_INFO</c> (0x00002000)</para>
			/// <para><c>Uri_PROPERTY_USER_INFO</c> exists.</para>
			/// <para><c>Uri_HAS_ZONE</c> (0x00020000)</para>
			/// <para><c>Uri_PROPERTY_ZONE</c> exists.</para>
			/// </returns>
			/// <remarks><c>IUri::GetProperties</c> was introduced in Windows Internet Explorer 7.</remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775025(v=vs.85)
			// HRESULT GetProperties( [out] LPDWORD pdwFlags );
			new Uri_HAS GetProperties();

			/// <summary>Compares the logical content of two <c>IUri</c> objects.</summary>
			/// <returns>Address of a BOOL that is set to TRUE if the logical content of pUri is the same.</returns>
			/// <remarks>
			/// <para><c>IUri::IsEqual</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>The comparison is case-insensitive. Comparing an <c>IUri</c> to itself will always return <c>TRUE</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775037(v=vs.85)
			// HRESULT IsEqual( [in] IUri *pUri, [out] BOOL *pfEqual );
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool IsEqual([In] IUri pUri);

			/// <summary>
			/// Gets the part name of the Relationships part that stores relationships that have the source URI represented by the current
			/// OPC URI object.
			/// </summary>
			/// <returns>
			/// A pointer to the IOpcPartUri interface of the part URI object that represents the part name of the Relationships part. The
			/// source URI of the relationships stored in this Relationships part is represented by the current OPC URI object.
			/// </returns>
			/// <remarks>
			/// <para>The following table shows Relationships part URIs for some OPC URIs.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>OPC URI</term>
			/// <term>Relationships Part Name</term>
			/// <term>Return Value</term>
			/// </listheader>
			/// <item>
			/// <term>/mydoc/images/picture.jpg</term>
			/// <term>/mydoc/images/_rels/picture.jpg.rels</term>
			/// <term>S_OK</term>
			/// </item>
			/// <item>
			/// <term>/</term>
			/// <term>/_rels/.rels</term>
			/// <term>S_OK</term>
			/// </item>
			/// <item>
			/// <term>/mydoc/images/_rels/picture.jpg.rels</term>
			/// <term>Undefined</term>
			/// <term>OPC_E_NONCONFORMING_URI</term>
			/// </item>
			/// </list>
			/// <para>Support on Previous Windows Versions</para>
			/// <para>
			/// The behavior and performance of this method is the same on all supported Windows versions. For more information, see Getting
			/// Started with the Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcuri-getrelationshipsparturi HRESULT
			// GetRelationshipsPartUri( IOpcPartUri **relationshipPartUri );
			new IOpcPartUri GetRelationshipsPartUri();

			/// <summary>Forms a relative URI for a specified part, relative to the URI represented by the current OPC URI object.</summary>
			/// <param name="targetPartUri">
			/// A pointer to the IOpcPartUri interface of the part URI object that represents the part name from which the relative URI is formed.
			/// </param>
			/// <returns>A pointer to the IUri interface of the URI of the part, relative to the current OPC URI object.</returns>
			/// <remarks>
			/// <para>Example input and output:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Input IOpcPartUri represents</term>
			/// <term>Current IOpcUri represents</term>
			/// <term>Returned relative IUri represents</term>
			/// </listheader>
			/// <item>
			/// <term>/mydoc/markup/page.xml</term>
			/// <term>/mydoc/markup/picture.jpg</term>
			/// <term>picture.jpg</term>
			/// </item>
			/// <item>
			/// <term>/mydoc/markup/page.xml</term>
			/// <term>/mydoc/picture.jpg</term>
			/// <term>../picture.jpg</term>
			/// </item>
			/// <item>
			/// <term>/mydoc/markup/page.xml</term>
			/// <term>/mydoc/images/pictures.jpg</term>
			/// <term>../images/pictures.jpg</term>
			/// </item>
			/// </list>
			/// <para>Support on Previous Windows Versions</para>
			/// <para>
			/// The behavior and performance of this method is the same on all supported Windows versions. For more information, see Getting
			/// Started with the Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcuri-getrelativeuri HRESULT GetRelativeUri( IOpcPartUri
			// *targetPartUri, IUri **relativeUri );
			new IUri GetRelativeUri([In] IOpcPartUri targetPartUri);

			/// <summary>
			/// Forms the part name of the part that is referenced by the specified relative URI. The specified relative URI of the part is
			/// resolved against the URI represented as the current OPC URI object.
			/// </summary>
			/// <param name="relativeUri">
			/// <para>A pointer to the IUri interface of the relative URI of the part.</para>
			/// <para>
			/// To form the part URI object that represents the part name, this input URI is resolved against the URI represented as the
			/// current OPC URI object. Therefore, the input URI must be relative to the URI represented by the current OPC URI object.
			/// </para>
			/// <para>
			/// This URI may include a fragment component; however, the fragment will be ignored and will not be included in the part name
			/// to be formed. A fragment component is preceded by a '#', as described in RFC 3986: URI Generic Syntax.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>A pointer to the IOpcPartUri interface of the part URI object that represents the part name.</para>
			/// <para>
			/// The part URI object is formed by resolving the relative URI in relativeUri against the URI represented by the current OPC
			/// URI object.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>Example input and output:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Input relative IUri</term>
			/// <term>Current IOpcUri</term>
			/// <term>Formed IOpcPartUri</term>
			/// </listheader>
			/// <item>
			/// <term>picture.jpg</term>
			/// <term>/mydoc/markup/page.xml</term>
			/// <term>/mydoc/markup/picture.jpg</term>
			/// </item>
			/// <item>
			/// <term>../picture.jpg</term>
			/// <term>/mydoc/markup/page.xml</term>
			/// <term>/mydoc/picture.jpg</term>
			/// </item>
			/// <item>
			/// <term>../../images/picture.jpg</term>
			/// <term>/mydoc/page.xml</term>
			/// <term>/images/picture.jpg</term>
			/// </item>
			/// </list>
			/// <para>
			/// For information about how to use this method to help resolve a part name, see Resolving a Part Name from a Target URI.
			/// </para>
			/// <para>Support on Previous Windows Versions</para>
			/// <para>
			/// The behavior and performance of this method is the same on all supported Windows versions. For more information, see Getting
			/// Started with the Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcuri-combineparturi HRESULT CombinePartUri( IUri
			// *relativeUri, IOpcPartUri **combinedUri );
			new IOpcPartUri CombinePartUri([In] IUri relativeUri);

			/// <summary>
			/// Returns an integer that indicates whether the URIs represented by the current part URI object and a specified part URI
			/// object are equivalent.
			/// </summary>
			/// <param name="partUri">
			/// A pointer to the IOpcPartUri interface of the part URI object to compare with the current part URI object.
			/// </param>
			/// <returns>
			/// <para>Receives an integer that indicates whether the two part URI objects are equivalent.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>&lt;0</term>
			/// <term>The current part URI object is less than the input part URI object that is passed in partUri.</term>
			/// </item>
			/// <item>
			/// <term>0</term>
			/// <term>The current part URI object is equivalent to the input part URI object that is passed in partUri.</term>
			/// </item>
			/// <item>
			/// <term>&gt;0</term>
			/// <term>The current part URI object is greater than the input part URI object that is passed in partUri.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>Support on Previous Windows Versions</para>
			/// <para>
			/// The behavior and performance of this method is the same on all supported Windows versions. For more information, see Getting
			/// Started with the Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcparturi-compareparturi HRESULT ComparePartUri(
			// IOpcPartUri *partUri, INT32 *comparisonResult );
			int ComparePartUri([In] IOpcPartUri partUri);

			/// <summary>
			/// Gets the source URI of the relationships that are stored in a Relationships part. The current part URI object represents the
			/// part name of that Relationships part.
			/// </summary>
			/// <returns>
			/// A pointer to the IOpcUri interface of the OPC URI object that represents the URI of the source of the relationships stored
			/// in the Relationships part.
			/// </returns>
			/// <remarks>
			/// <para>
			/// If the current part URI object represents the part name of the Relationships part that stores package relationships
			/// ("/_rels/.rels"), the OPC URI object returned in sourceUri will represent the package root ("/").
			/// </para>
			/// <para>
			/// If the current part URI object is not the part name of a Relationships part, this method fails with the
			/// <c>OPC_E_RELATIONSHIP_URI_REQUIRED</c> error. The syntax for Relationship part names is specified in the OPC.
			/// </para>
			/// <para>The following table shows possible current part URIs and the source URI that would be returned by this method.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Current Part URI</term>
			/// <term>Current Part URI Description</term>
			/// <term>Source URI</term>
			/// <term>Source URI Description</term>
			/// <term>Return Value</term>
			/// </listheader>
			/// <item>
			/// <term>/mydoc/_rels/picture.jpg.rels</term>
			/// <term>The part name of a Relationships part</term>
			/// <term>/mydoc/picture.jpg</term>
			/// <term>
			/// The part name of the part that is the source of the relationships stored in the Relationships part that is represented by
			/// the current part URI object
			/// </term>
			/// <term>S_OK</term>
			/// </item>
			/// <item>
			/// <term>/_rels/.rels</term>
			/// <term>The part name of a Relationships part</term>
			/// <term>/</term>
			/// <term>
			/// The package root; the source of the relationships stored in the Relationships part that is represented by the current part
			/// URI object
			/// </term>
			/// <term>S_OK</term>
			/// </item>
			/// <item>
			/// <term>/mydoc/image/chart1.jpg</term>
			/// <term>The part name of a part that is not a Relationships part</term>
			/// <term>Undefined</term>
			/// <term>Undefined</term>
			/// <term>OPC_E_RELATIONSHIP_URI_REQUIRED</term>
			/// </item>
			/// <item>
			/// <term>/_rels/a.jpg</term>
			/// <term>The part name of a part that is not a Relationships part</term>
			/// <term>Undefined</term>
			/// <term>Undefined</term>
			/// <term>OPC_E_RELATIONSHIP_URI_REQUIRED</term>
			/// </item>
			/// </list>
			/// <para>Support on Previous Windows Versions</para>
			/// <para>
			/// The behavior and performance of this method is the same on all supported Windows versions. For more information, see Getting
			/// Started with the Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcparturi-getsourceuri HRESULT GetSourceUri( IOpcUri
			// **sourceUri );
			IOpcUri GetSourceUri();

			/// <summary>
			/// Returns a value that indicates whether the current part URI object represents the part name of a Relationships part.
			/// </summary>
			/// <returns>
			/// <para>Receives a value that indicates whether the current part URI object represents the part name of a Relationships part.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The current part URI object represents the part name of a Relationships part.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current part URI object does not represent the part name of a Relationships part.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>Support on Previous Windows Versions</para>
			/// <para>
			/// The behavior and performance of this method is the same on all supported Windows versions. For more information, see Getting
			/// Started with the Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcparturi-isrelationshipsparturi HRESULT
			// IsRelationshipsPartUri( BOOL *isRelationshipUri );
			[return: MarshalAs(UnmanagedType.Bool)]
			bool IsRelationshipsPartUri();
		}

		/// <summary>
		/// Represents a relationship, which is a link between a source, which is a part or the package, and a target. The relationship's
		/// target can be a part or external resource.
		/// </summary>
		/// <remarks>
		/// <para>
		/// To create a relationship object to represent a relationship, call the IOpcRelationshipSet::CreateRelationship method. To get a
		/// pointer to the interface of a relationship object that represents an existing relationship, call the
		/// IOpcRelationshipSet::GetRelationship or IOpcRelationshipEnumerator::GetCurrent method.
		/// </para>
		/// <para>Example relationship markup for a relationship that targets a part:</para>
		/// <para>
		/// Using the relationship type ( <c>Type</c> attribute of the <c>Relationship</c> element) is the definitive way find a part in a
		/// package. For more information about why the relationship type is used, see the Parts Overview. For an example of to use the
		/// relationship type to find a part, see Finding the Core Properties Part.
		/// </para>
		/// <para>
		/// Valid identifiers for relationships conform to the restrictions for <c>xsd:ID</c>, which are documented in section 3.3.8 ID of
		/// the W3C Recommendation, XML Schema Part 2: Datatypes Second Edition (http://go.microsoft.com/fwlink/p/?linkid=126664).
		/// </para>
		/// <para>
		/// <c>IOpcRelationship</c> interface methods provide access to relationship properties for a relationship (which is represented by
		/// a relationship object). The methods, associated properties and descriptions are listed in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Method</term>
		/// <term>Property</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GetId</term>
		/// <term>Relationship identifier</term>
		/// <term>The unique, arbitrary identifier of a relationship that is local to the package.</term>
		/// </item>
		/// <item>
		/// <term>GetRelationshipType</term>
		/// <term>Relationship type</term>
		/// <term>The qualified name of a relationship defined by the package designer.</term>
		/// </item>
		/// <item>
		/// <term>GetSourceUri</term>
		/// <term>Source URI</term>
		/// <term>The URI of the relationship's source. The source URI can be the URI of the package or of a part.</term>
		/// </item>
		/// <item>
		/// <term>GetTargetMode</term>
		/// <term>Target mode</term>
		/// <term>Indicates whether the relationship's target is internal or external to the package.</term>
		/// </item>
		/// <item>
		/// <term>GetTargetUri</term>
		/// <term>Target URI</term>
		/// <term>The URI of the relationship's target.</term>
		/// </item>
		/// </list>
		/// <para>
		/// For more information about relationships, see the Open Packaging Conventions Fundamentals and the ECMA-376 OpenXML, 1st Edition,
		/// Part 2: Open Packaging Conventions (OPC).
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcrelationship
		[PInvokeData("msopc.h")]
		[ComImport, Guid("42195949-3B79-4fc8-89C6-FC7FB979EE72"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcRelationship
		{
			/// <summary>Gets the unique identifier of the relationship.</summary>
			/// <returns>
			/// <para>The identifier of the relationship.</para>
			/// <para>The identifier of a relationship is arbitrary and local to the package, and, therefore, .</para>
			/// <para>
			/// Valid identifiers conform to the restrictions for <c>xsd:ID</c>, which are documented in section 3.3.8 ID of the W3C
			/// Recommendation, XML Schema Part 2: Datatypes Second Edition (http://go.microsoft.com/fwlink/p/?linkid=126664).
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The identifier of a relationship is not useful for finding relationships because it is arbitrary and local to the package.
			/// </para>
			/// <para>The definitive way to find a part of interest is by using a relationship type.</para>
			/// <para>
			/// Finding a part requires several steps. For detailed information about finding a part, see Finding the Core Properties Part.
			/// </para>
			/// <para>
			/// For more information about relationships, see the Open Packaging Conventions Fundamentals and the ECMA-376 OpenXML, 1st
			/// Edition, Part 2: Open Packaging Conventions (OPC).
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationship-getid HRESULT GetId( LPWSTR
			// *relationshipIdentifier );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetId();

			/// <summary>Gets the relationship type.</summary>
			/// <returns>
			/// <para>
			/// Receives the relationship type, which is the qualified name of the relationship, as defined by the package format designer
			/// or the OPC.
			/// </para>
			/// <para>For more information about relationship types see Remarks.</para>
			/// </returns>
			/// <remarks>
			/// <para>The definitive way to find a part of interest is by using a relationship type.</para>
			/// <para>
			/// Finding a part of interest requires several steps. For detailed information about finding a part, see Finding the Core
			/// Properties Part.
			/// </para>
			/// <para>
			/// For more information about relationships, relationship types and a list of relationship types defined by the OPC, see the
			/// Open Packaging Conventions Fundamentals and the OPC.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationship-getrelationshiptype HRESULT
			// GetRelationshipType( LPWSTR *relationshipType );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetRelationshipType();

			/// <summary>Gets the URI of the relationship source.</summary>
			/// <returns>A pointer to the IOpcUri interface of the OPC URI object that represents the URI of the relationship source.</returns>
			/// <remarks>
			/// <para>If the source of a relationship is the package itself, the URI in sourceUri represents the package root: "/".</para>
			/// <para>
			/// If the relationship target is a part, form the part name by calling the IOpcUri::CombinePartUri method from the IOpcUri
			/// interface pointer received in sourceUri. Use the relative URI received in the targetUri parameter of the GetTargetUri method
			/// as the input parameter of the <c>IOpcUri::CombinePartUri</c> call. For an example, see Resolving a Part Name from a Target URI.
			/// </para>
			/// <para>
			/// For more information about relationships, see the Open Packaging Conventions Fundamentals and the ECMA-376 OpenXML, 1st
			/// Edition, Part 2: Open Packaging Conventions (OPC).
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationship-getsourceuri HRESULT GetSourceUri( IOpcUri
			// **sourceUri );
			IOpcUri GetSourceUri();

			/// <summary>Gets the URI of the relationship target.</summary>
			/// <returns>
			/// <para>A pointer to the IUri interface of the URI that represents the URI of the relationship's target.</para>
			/// <para>
			/// If the relationship target is internal, the target is a part and the URI of the target is relative to the URI of the source part.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>The definitive way to find a part of interest is by using a relationship type.</para>
			/// <para>
			/// Finding a part of interest requires several steps. For detailed information about finding a part, see the Parts Overview and
			/// Finding the Core Properties Part.
			/// </para>
			/// <para>To determine whether the target of the relationship is internal or external, call the <c>GetTargetUri</c> method.</para>
			/// <para>If the relationship target is internal, the target is a part.</para>
			/// <para>If the relationship target is a part, the URI in targetUri is relative to the URI of the relationship source.</para>
			/// <para>
			/// If the relationship target is a part, form the part name by calling the IOpcUri::CombinePartUri method from the IOpcUri
			/// interface pointer received in sourceUri parameter of the GetSourceUri method. Use the relative URI received in targetUri as
			/// the input parameter of the <c>IOpcUri::CombinePartUri</c> call. For an example, see Resolving a Part Name from a Target URI.
			/// </para>
			/// <para>
			/// For more information about relationships, see the Open Packaging Conventions Fundamentals and the ECMA-376 OpenXML, 1st
			/// Edition, Part 2: Open Packaging Conventions (OPC).
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationship-gettargeturi HRESULT GetTargetUri( IUri
			// **targetUri );
			IUri GetTargetUri();

			/// <summary>Gets a value that describes whether the relationship's target is internal or external to the package.</summary>
			/// <returns>
			/// <para>A value that describes whether the relationship's target is internal or external to the package.</para>
			/// <para>If the target of the relationship is internal, the target is a part.</para>
			/// <para>If the target of the relationship is external, the target is a resource outside of the package.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// If the relationship target is internal, the target is a part. The URI of the target is relative to the URI of the source part.
			/// </para>
			/// <para>To get the URI of the target of the relationship, call the IOpcRelationship::GetTargetUri method.</para>
			/// <para>The definitive way to find a part of interest is by using a relationship type.</para>
			/// <para>
			/// Finding a part of interest requires several steps. For detailed information about finding a part, see the Parts Overview and
			/// Finding the Core Properties Part.
			/// </para>
			/// <para>
			/// For more information about relationships, see the Open Packaging Conventions Fundamentals and the ECMA-376 OpenXML, 1st
			/// Edition, Part 2: Open Packaging Conventions (OPC).
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationship-gettargetmode HRESULT GetTargetMode(
			// OPC_URI_TARGET_MODE *targetMode );
			OPC_URI_TARGET_MODE GetTargetMode();
		}

		/// <summary>A read-only enumerator of IOpcRelationship interface pointers.</summary>
		/// <remarks>
		/// <para>
		/// To get a pointer to this interface, call either the IOpcRelationshipSet::GetEnumerator or the
		/// IOpcRelationshipSet::GetEnumeratorForType method.
		/// </para>
		/// <para>
		/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first pointer
		/// of the enumerator, call the MoveNextmethod after creating the enumerator.
		/// </para>
		/// <para><c>Note</c> Changes to the set will invalidate the enumerator, and all subsequent calls will fail.</para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcrelationshipenumerator
		[PInvokeData("msopc.h")]
		[ComImport, Guid("42195949-3B79-4fc8-89C6-FC7FB979EE76"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcRelationshipEnumerator
		{
			/// <summary>Moves the current position of the enumerator to the next IOpcRelationship interface pointer.</summary>
			/// <param name="hasNext">
			/// <para>A Boolean value that indicates the status of the IOpcRelationship interface pointer at the current position.</para>
			/// <para>The value of hasNext is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The current position of the enumerator has been advanced to the next pointer and that pointer is valid.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been advanced past the end of the collection and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasNext parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_NEXT 0x80510051</term>
			/// <term>The current position is already past the last item of the enumerator.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first
			/// pointer of the enumerator, call the <c>MoveNext</c> method after creating the enumerator.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipenumerator-movenext HRESULT MoveNext( BOOL
			// *hasNext );
			[PreserveSig]
			HRESULT MoveNext([MarshalAs(UnmanagedType.Bool)] out bool hasNext);

			/// <summary>Moves the current position of the enumerator to the previous IOpcRelationship interface pointer.</summary>
			/// <param name="hasPrevious">
			/// <para>A Boolean value that indicates the status of the IOpcRelationship interface pointer at the current position.</para>
			/// <para>The value of hasPrevious is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>
			/// The current position of the enumerator has been moved to the previous pointer in the collection, and that pointer is valid.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been moved past the beginning of the enumerator and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasPrevious parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_PREVIOUS 0x80510052</term>
			/// <term>The current position already precedes the first item of the enumerator.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first
			/// pointer of the enumerator, call the MoveNextmethod after creating the enumerator.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipenumerator-moveprevious HRESULT
			// MovePrevious( BOOL *hasPrevious );
			[PreserveSig]
			HRESULT MovePrevious([MarshalAs(UnmanagedType.Bool)] out bool hasPrevious);

			/// <summary>Gets the IOpcRelationship interface pointer at the current position of the enumerator.</summary>
			/// <param name="relationship">An IOpcRelationship interface pointer.</param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The partReference parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_INVALID_POSITION 0x80510053</term>
			/// <term>The enumerator cannot perform this operation from its current position.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first
			/// pointer of the enumerator, call the MoveNextmethod after creating the enumerator.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipenumerator-getcurrent HRESULT GetCurrent(
			// IOpcRelationship **relationship );
			[PreserveSig]
			HRESULT GetCurrent(out IOpcRelationship relationship);

			/// <summary>Creates a copy of the current enumerator and all its descendants.</summary>
			/// <returns>A pointer to the IOpcRelationshipEnumerator interface of the new enumerator.</returns>
			/// <remarks>
			/// <para>
			/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first
			/// pointer of the enumerator, call the MoveNextmethod after creating the enumerator.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipenumerator-clone HRESULT Clone(
			// IOpcRelationshipEnumerator **copy );
			IOpcRelationshipEnumerator Clone();
		}

		/// <summary>Represents how to select, from a Relationships part, the relationships to be referenced for signing.</summary>
		/// <remarks>
		/// <para>To create an <c>IOpcRelationshipSelector</c> interface pointer, call the IOpcRelationshipSelectorSet::Create method.</para>
		/// <para>To access an <c>IOpcRelationshipSelector</c>, call the IOpcRelationshipSelectorEnumerator::GetCurrent method.</para>
		/// <para>
		/// Use the <c>IOpcRelationshipSelector</c> interface methods to select relationships for signing. A relationship is selected if its
		/// type or identifier matches the string that is retrieved by calling the GetSelectionCriterion method. This string is either a
		/// relationship type or a relationship identifier. Call the GetSelectorType method to get an OPC_RELATIONSHIP_SELECTOR value to
		/// determine whether the string is a relationship type or an identifier. To access these relationship properties, call the
		/// IOpcRelationship::GetRelationshipType and IOpcRelationship::GetId methods.
		/// </para>
		/// <para>
		/// The following table shows how OPC_RELATIONSHIP_SELECTOR values map to the relationship type and relationship identifier properties.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>OPC_RELATIONSHIP_SELECTOR Value</term>
		/// <term>Relationship Property</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OPC_RELATIONSHIP_SELECT_BY_TYPE</term>
		/// <term>Relationship type</term>
		/// <term>Selects relationships that have a relationship type that matches selectionCriterion string.</term>
		/// </item>
		/// <item>
		/// <term>OPC_RELATIONSHIP_SELECT_BY_ID</term>
		/// <term>Relationship identifier</term>
		/// <term>Selects relationships that have a relationship identifier that matches selectionCriterion string.</term>
		/// </item>
		/// </list>
		/// <para>
		/// When a signature is generated, the relationship selection information provided by the interface is serialized in the XML markup
		/// of the signature (signature markup). In signature markup, this information is represented by the <c>RelationshipReference</c>
		/// and <c>RelationshipGroupReference</c> elements, which are specified in section 12. Digital Signatures in the ECMA-376 OpenXML,
		/// 1st Edition, Part 2: Open Packaging Conventions (OPC). The following table shows how the elements map to relationship properties
		/// and to OPC_RELATIONSHIP_SELECTOR values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Package signature element</term>
		/// <term>Relationship Property</term>
		/// <term>OPC_RELATIONSHIP_SELECTOR Value</term>
		/// </listheader>
		/// <item>
		/// <term>RelationshipGroupReference</term>
		/// <term>Relationship type</term>
		/// <term>OPC_RELATIONSHIP_SELECT_BY_TYPE</term>
		/// </item>
		/// <item>
		/// <term>RelationshipReference</term>
		/// <term>Relationship identifier</term>
		/// <term>OPC_RELATIONSHIP_SELECT_BY_ID</term>
		/// </item>
		/// </list>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcrelationshipselector
		[PInvokeData("msopc.h")]
		[ComImport, Guid("f8f26c7f-b28f-4899-84c8-5d5639ede75f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcRelationshipSelector
		{
			/// <summary>Gets a value that describes how relationships are selected to be referenced for signing.</summary>
			/// <returns>
			/// A value that describes which IOpcRelationship interface property will be compared to the string returned by the
			/// GetSelectionCriterion method.
			/// </returns>
			/// <remarks>
			/// <para>
			/// The following table shows how OPC_RELATIONSHIP_SELECTOR values map to the relationship type and relationship identifier properties.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>OPC_RELATIONSHIP_SELECTOR Value</term>
			/// <term>Relationship Property</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>OPC_RELATIONSHIP_SELECT_BY_TYPE</term>
			/// <term>Relationship type</term>
			/// <term>Selects relationships that have a relationship type that matches selectionCriterion string.</term>
			/// </item>
			/// <item>
			/// <term>OPC_RELATIONSHIP_SELECT_BY_ID</term>
			/// <term>Relationship identifier</term>
			/// <term>Selects relationships that have a relationship identifier that matches selectionCriterion string.</term>
			/// </item>
			/// </list>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipselector-getselectortype HRESULT
			// GetSelectorType( OPC_RELATIONSHIP_SELECTOR *selector );
			OPC_RELATIONSHIP_SELECTOR GetSelectorType();

			/// <summary>Gets a string that is used to select relationships to be referenced for signing.</summary>
			/// <returns>A string used to select relationships to be referenced for signing.</returns>
			/// <remarks>
			/// <para>
			/// Use the IOpcRelationshipSelector interface methods to select relationships for signing. A relationship is selected if its
			/// type or identifier matches the string that is retrieved by calling the <c>GetSelectionCriterion</c> method. This string is
			/// either a relationship type or a relationship identifier. Call the GetSelectorType method to get an OPC_RELATIONSHIP_SELECTOR
			/// value to determine whether the string is a relationship type or an identifier. To access these relationship properties, call
			/// the IOpcRelationship::GetRelationshipType and IOpcRelationship::GetId methods.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipselector-getselectioncriterion HRESULT
			// GetSelectionCriterion( LPWSTR *selectionCriterion );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetSelectionCriterion();
		}

		/// <summary>A read-only enumerator of IOpcRelationshipSelector interface pointers.</summary>
		/// <remarks>
		/// <para>When an enumerator is created, the current position precedes the first pointer.</para>
		/// <para>To set the current position to the first pointer of the enumerator, call the MoveNextmethod after creating the enumerator.</para>
		/// <para>Changes to the set will invalidate the enumerator, and all subsequent calls to it will fail.</para>
		/// <para>
		/// To get an <c>IOpcRelationshipSelectorEnumerator</c> interface pointer, call the IOpcRelationshipSelectorSet::GetEnumerator or
		/// IOpcSignatureRelationshipReference::GetRelationshipSelectorEnumerator method.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcrelationshipselectorenumerator
		[PInvokeData("msopc.h")]
		[ComImport, Guid("5e50a181-a91b-48ac-88d2-bca3d8f8c0b1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcRelationshipSelectorEnumerator
		{
			/// <summary>Moves the current position of the enumerator to the next IOpcRelationshipSelectorinterface pointer.</summary>
			/// <param name="hasNext">
			/// <para>A Boolean value that indicates the status of the IOpcRelationshipSelector interface pointer at the current position.</para>
			/// <para>The value of hasNext is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The current position of the enumerator has been advanced to the next pointer and that pointer is valid.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been advanced past the end of the collection and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasNext parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_NEXT 0x80510051</term>
			/// <term>The current position is already past the last item of the enumerator.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipselectorenumerator-movenext HRESULT
			// MoveNext( BOOL *hasNext );
			[PreserveSig]
			HRESULT MoveNext([MarshalAs(UnmanagedType.Bool)] out bool hasNext);

			/// <summary>Moves the current position of the enumerator to the previous IOpcRelationshipSelectorinterface pointer.</summary>
			/// <param name="hasPrevious">
			/// <para>A Boolean value that indicates the status of the IOpcRelationshipSelectorinterface pointer at the current position.</para>
			/// <para>The value of hasPrevious is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>
			/// The current position of the enumerator has been moved to the previous pointer in the collection, and that pointer is valid.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been moved past the beginning of the collection and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasPrevious parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_PREVIOUS 0x80510052</term>
			/// <term>The current position already precedes the first item of the enumerator.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipselectorenumerator-moveprevious HRESULT
			// MovePrevious( BOOL *hasPrevious );
			[PreserveSig]
			HRESULT MovePrevious([MarshalAs(UnmanagedType.Bool)] out bool hasPrevious);

			/// <summary>Gets the IOpcRelationshipSelector interface pointer at the current position of the enumerator.</summary>
			/// <param name="relationshipSelector">An IOpcRelationshipSelector interface pointer .</param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The partReference parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_INVALID_POSITION 0x80510053</term>
			/// <term>The enumerator cannot perform this operation from its current position.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>When an enumerator is created, the current position precedes the first pointer.</para>
			/// <para>To set the current position to the first pointer of the enumerator, call the MoveNextmethod after creating the enumerator.</para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipselectorenumerator-getcurrent HRESULT
			// GetCurrent( IOpcRelationshipSelector **relationshipSelector );
			[PreserveSig]
			HRESULT GetCurrent(out IOpcRelationshipSelector relationshipSelector);

			/// <summary>Creates a copy of the current IOpcRelationshipSelectorEnumeratorinterface pointer and all its descendants.</summary>
			/// <returns>A pointer to a copy of the IOpcRelationshipSelectorEnumeratorinterface pointer.</returns>
			/// <remarks>
			/// <para>The copy has a current position and set that are identical to the current enumerator.</para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipselectorenumerator-clone HRESULT Clone(
			// IOpcRelationshipSelectorEnumerator **copy );
			IOpcRelationshipSelectorEnumerator Clone();
		}

		/// <summary>
		/// An unordered set of IOpcRelationshipSelector interface pointers that represent the selection criteria that is used to identify
		/// relationships for signing. The subset is selected from the relationships stored in a Relationships part.
		/// </summary>
		/// <remarks>
		/// <para>Use the methods of the IOpcRelationshipSelector interface pointers in the set to select relationships for signing.</para>
		/// <para>
		/// To create an <c>IOpcRelationshipSelectorSet</c> interface pointer, call the
		/// IOpcSignatureRelationshipReference::CreateRelationshipSelectorSet method.
		/// </para>
		/// <para>
		/// When an IOpcRelationshipSelector interface pointer is created and added to the set, the criterion it provides access to is saved
		/// when the package is saved.
		/// </para>
		/// <para>
		/// When an IOpcRelationshipSelector interface pointer is deleted from the set, the criterion it provides access to is not saved
		/// when the package is saved.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcrelationshipselectorset
		[PInvokeData("msopc.h")]
		[ComImport, Guid("6e34c269-a4d3-47c0-b5c4-87ff2b3b6136"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcRelationshipSelectorSet
		{
			/// <summary>
			/// Creates an IOpcRelationshipSelector interface pointer to represent how a subset of relationships are selected to be signed,
			/// and adds the new pointer to the set.
			/// </summary>
			/// <param name="selector">A value that describes how to interpret the string that is passed in selectionCriterion.</param>
			/// <param name="selectionCriterion">A string that is interpreted to yield a criterion.</param>
			/// <returns>
			/// <para>
			/// A new IOpcRelationshipSelector interface pointer that represents how relationships are selected from a Relationships part.
			/// </para>
			/// <para>This parameter can be <c>NULL</c> if a pointer to the new interface is not needed.</para>
			/// </returns>
			/// <remarks>
			/// <para>Use the methods of the IOpcRelationshipSelector interface pointers in the set to select relationships for signing.</para>
			/// <para>
			/// When an IOpcRelationshipSelector interface pointer is created and added to the set, the criterion it provides access to is
			/// saved when the package is saved.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipselectorset-create HRESULT Create(
			// OPC_RELATIONSHIP_SELECTOR selector, LPCWSTR selectionCriterion, IOpcRelationshipSelector **relationshipSelector );
			IOpcRelationshipSelector Create(OPC_RELATIONSHIP_SELECTOR selector, [MarshalAs(UnmanagedType.LPWStr)] string selectionCriterion);

			/// <summary>Deletes a specified IOpcRelationshipSelector interface pointer from the set.</summary>
			/// <param name="relationshipSelector">An IOpcRelationshipSelector interface pointer to be deleted.</param>
			/// <remarks>
			/// <para>
			/// When an IOpcRelationshipSelector interface pointer is deleted from the set, the criterion it provides access to is not saved
			/// when the package is saved.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipselectorset-delete HRESULT Delete(
			// IOpcRelationshipSelector *relationshipSelector );
			void Delete(IOpcRelationshipSelector relationshipSelector);

			/// <summary>Gets an enumerator of IOpcRelationshipSelector interface pointers in the set.</summary>
			/// <returns>A pointer to an enumerator of the IOpcRelationshipSelector interface pointers in the set.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipselectorset-getenumerator HRESULT
			// GetEnumerator( IOpcRelationshipSelectorEnumerator **relationshipSelectorEnumerator );
			IOpcRelationshipSelectorEnumerator GetEnumerator();
		}

		/// <summary>Represents a Relationships part as an unordered set of IOpcRelationship interface pointers to relationship objects.</summary>
		/// <remarks>
		/// <para>
		/// When a relationship object is created and a pointer to it is added to the set, the relationship it represents is saved when the
		/// package is saved.
		/// </para>
		/// <para>
		/// When an IOpcRelationship interface pointer is deleted from the set, the relationship it represents is not saved when the package
		/// is saved.
		/// </para>
		/// <para>If a relationship is represented in the set, the relationship is stored in the Relationships part represented as the set.</para>
		/// <para>For how to form the part name for the target of a relationship, see Resolving a Part Name from a Target URI.</para>
		/// <para>
		/// For more information about relationships, see Open Packaging Conventions Fundamentals and the ECMA-376 OpenXML, 1st Edition,
		/// Part 2: Open Packaging Conventions (OPC).
		/// </para>
		/// <para>
		/// The IOpcRelationship interface provides access to relationship properties. For details about these properties, see the
		/// Relationships Overview and IOpcRelationship.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcrelationshipset
		[PInvokeData("msopc.h")]
		[ComImport, Guid("42195949-3B79-4fc8-89C6-FC7FB979EE74"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcRelationshipSet
		{
			/// <summary>Gets a relationship object from the set that represents a specified relationship.</summary>
			/// <param name="relationshipIdentifier">The unique identifier of a relationship.</param>
			/// <returns>
			/// A pointer to the IOpcRelationship interface of the relationship object that represents the relationship that has the
			/// specified identifier.
			/// </returns>
			/// <remarks>
			/// <para>
			/// The IOpcRelationship interface provides access to relationship properties. For details about these properties, see the
			/// Relationships Overview and IOpcRelationship.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipset-getrelationship HRESULT
			// GetRelationship( LPCWSTR relationshipIdentifier, IOpcRelationship **relationship );
			IOpcRelationship GetRelationship([MarshalAs(UnmanagedType.LPWStr)] string relationshipIdentifier);

			/// <summary>
			/// Creates a relationship object that represents a specified relationship, then adds to the set a pointer to the object's
			/// IOpcRelationship interface.
			/// </summary>
			/// <param name="relationshipIdentifier">
			/// <para>
			/// A unique identifier of the relationship to be represented as the relationship object. To use a randomly generated
			/// identifier, pass <c>NULL</c> to this parameter.
			/// </para>
			/// <para>
			/// Valid identifiers conform to the restrictions for <c>xsd:ID</c>, which are documented in section 3.3.8 ID of the W3C
			/// Recommendation, XML Schema Part 2: Datatypes Second Edition (http://go.microsoft.com/fwlink/p/?linkid=126664).
			/// </para>
			/// </param>
			/// <param name="relationshipType">
			/// The relationship type that defines the role of the relationship to be represented as the relationship object.
			/// </param>
			/// <param name="targetUri">
			/// <para>A URI to the target of the relationship to be represented as the relationship object.</para>
			/// <para>
			/// If the value in targetMode is <c>OPC_URI_TARGET_MODE_INTERNAL</c>, target is a part and the URI must be relative to the
			/// source of the relationship.
			/// </para>
			/// <para>
			/// If the value in targetMode is <c>OPC_URI_TARGET_MODE_EXTERNAL</c>, target is a resource outside of the package and the URI
			/// may be absolute or relative to the location of the package.
			/// </para>
			/// <para>For more information about the URI of a relationship's target, see the OPC.</para>
			/// </param>
			/// <param name="targetMode">
			/// A value that indicates whether the target of the relationship to be represented as the relationship object is internal or
			/// external to the package.
			/// </param>
			/// <returns>
			/// <para>A pointer to the IOpcRelationship interface of the relationship object that represents the relationship.</para>
			/// <para>This parameter can be <c>NULL</c> if a pointer to the new object is not needed.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When a relationship object is created and a pointer to it is added to the set, the relationship it represents is saved when
			/// the package is saved.
			/// </para>
			/// <para>
			/// The IOpcRelationship interface provides access to relationship properties. For details about these properties, see the
			/// Relationships Overview and IOpcRelationship.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipset-createrelationship HRESULT
			// CreateRelationship( LPCWSTR relationshipIdentifier, LPCWSTR relationshipType, IUri *targetUri, OPC_URI_TARGET_MODE
			// targetMode, IOpcRelationship **relationship );
			IOpcRelationship CreateRelationship([Optional, MarshalAs(UnmanagedType.LPWStr)] string relationshipIdentifier, [MarshalAs(UnmanagedType.LPWStr)] string relationshipType, IUri targetUri, OPC_URI_TARGET_MODE targetMode);

			/// <summary>Deletes a specified IOpcRelationship interface pointer from the set.</summary>
			/// <param name="relationshipIdentifier">
			/// <para>The unique identifier of a relationship.</para>
			/// <para>
			/// The IOpcRelationship interface pointer to be deleted is the pointer to the relationship object that represents the
			/// relationship the specified identifier.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para>
			/// When an IOpcRelationship interface pointer is deleted from the set, the relationship it represents is not saved when the
			/// package is saved.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipset-deleterelationship HRESULT
			// DeleteRelationship( LPCWSTR relationshipIdentifier );
			void DeleteRelationship([MarshalAs(UnmanagedType.LPWStr)] string relationshipIdentifier);

			/// <summary>
			/// Gets a value that indicates whether a specified relationship is represented as a relationship object in the set.
			/// </summary>
			/// <param name="relationshipIdentifier">The unique identifier of a relationship.</param>
			/// <returns>
			/// <para>One of the following values:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>A relationship that has the identifier specified in relationshipIdentifier is represented in the set.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>A relationship that has the identifier specified in relationshipIdentifier is not represented in the set.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// If a relationship is represented in the set, the relationship is stored in the Relationships part represented by that set.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipset-relationshipexists HRESULT
			// RelationshipExists( LPCWSTR relationshipIdentifier, BOOL *relationshipExists );
			[return: MarshalAs(UnmanagedType.Bool)]
			bool RelationshipExists([MarshalAs(UnmanagedType.LPWStr)] string relationshipIdentifier);

			/// <summary>Gets an enumerator of IOpcRelationship interface pointers in the set.</summary>
			/// <returns>
			/// A pointer to the IOpcRelationshipEnumerator interface of the enumerator of IOpcRelationship interface pointers in the set.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipset-getenumerator HRESULT GetEnumerator(
			// IOpcRelationshipEnumerator **relationshipEnumerator );
			IOpcRelationshipEnumerator GetEnumerator();

			/// <summary>
			/// Gets an enumerator of the IOpcRelationship interface pointers in the set that point to representations of relationships that
			/// have a specified relationship type.
			/// </summary>
			/// <param name="relationshipType">The relationship type used to identify IOpcRelationship interface pointers to be enumerated.</param>
			/// <returns>
			/// A pointer to the IOpcRelationshipEnumerator interface of the enumerator of the IOpcRelationship interface pointers in the
			/// set that point to representations of relationships that have a specified relationship type.
			/// </returns>
			/// <remarks>
			/// <para>For information about forming the part name for the target of a relationship, see the IOpcRelationship topic.</para>
			/// <para>
			/// The IOpcRelationship interface provides access to relationship properties. For details about these properties, see the
			/// Relationships Overview and IOpcRelationship.
			/// </para>
			/// <para>
			/// For more information about relationships, see Open Packaging Conventions Fundamentals and the ECMA-376 OpenXML, 1st Edition,
			/// Part 2: Open Packaging Conventions (OPC).
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipset-getenumeratorfortype HRESULT
			// GetEnumeratorForType( LPCWSTR relationshipType, IOpcRelationshipEnumerator **relationshipEnumerator );
			IOpcRelationshipEnumerator GetEnumeratorForType([MarshalAs(UnmanagedType.LPWStr)] string relationshipType);

			/// <summary>Gets a read-only stream that contains the part content of the Relationships part represented by the set.</summary>
			/// <returns>
			/// <para>
			/// A pointer to the IStream interface of the read-only stream that contains the part content of the Relationships part
			/// represented by the set.
			/// </para>
			/// <para>
			/// If the relationships stored in the Relationships part have not been modified, part content can include markup compatibility
			/// data that is not otherwise accessible through the relationship objects in the set.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Calling this method will parse and validate all the relationships in the relationships markup. If the Relationships part
			/// contains invalid relationships markup, the markup cannot be retrieved by this method.
			/// </para>
			/// <para>
			/// For more information about markup compatibility and packages, see Part 5: Markup Compatibility in ECMA-376 OpenXML (http://go.microsoft.com/fwlink/p/?linkid=123375).
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcrelationshipset-getrelationshipscontentstream HRESULT
			// GetRelationshipsContentStream( IStream **contents );
			IStream GetRelationshipsContentStream();
		}

		/// <summary>Represents an application-specific <c>Object</c> element that has been or will be signed.</summary>
		/// <remarks>
		/// <para>
		/// An <c>IOpcSignatureCustomObject</c> interface pointer provides access to the XML markup of the <c>Object</c> element it
		/// represents. To access the XML markup of the <c>Object</c> element, call the IOpcSignatureCustomObject::GetXml method.
		/// </para>
		/// <para>
		/// Serialized application-specific <c>Object</c> elements in signature markup can be added, removed, or modified by replacing the
		/// signature markup.
		/// </para>
		/// <para>
		/// To replace signature markup, call the IOpcDigitalSignatureManager::ReplaceSignatureXml method. The caller must ensure that
		/// addition, deletion, or modification of application-specific <c>Object</c> elements does not break the signature.
		/// </para>
		/// <para>
		/// To sign an application-specific <c>Object</c> element or a child of the element, create a reference to the element to be signed.
		/// Create the reference by calling the IOpcSignatureReferenceSet::Create method with the referenceUri parameter value set to "#"
		/// followed by the <c>Id</c> attribute value of the referenced element. For example, if the <c>Id</c> attribute of the referenced
		/// element is "Application", set referenceUri to "#Application".
		/// </para>
		/// <para>To create an <c>IOpcSignatureCustomObject</c> interface pointer, call the IOpcSignatureCustomObjectSet::Create method.</para>
		/// <para>
		/// To access an <c>IOpcSignatureCustomObject</c> interface pointer, call the IOpcSignatureCustomObjectEnumerator::GetCurrent method.
		/// </para>
		/// <para>When a signature is generated, the markup of application-specific <c>Object</c> element is included in the signature markup.</para>
		/// <para>Application-specific <c>Object</c> elements are not required for package signatures.</para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcsignaturecustomobject
		[PInvokeData("msopc.h")]
		[ComImport, Guid("5d77a19e-62c1-44e7-becd-45da5ae51a56"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcSignatureCustomObject
		{
			/// <summary>Gets the XML markup of an application-specific <c>Object</c> element.</summary>
			/// <param name="xmlMarkup">
			/// <para>
			/// A pointer to a buffer that contains the XML markup of an <c>Object</c> element and includes the opening and closing
			/// <c>Object</c> tags.
			/// </para>
			/// <para>In the buffer, XML markup is preceded by a byte order mark that corresponds to the encoding of the markup.</para>
			/// <para>Supported encodings and</para>
			/// <para>byte order mark</para>
			/// <para>values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Encoding</term>
			/// <term>Description</term>
			/// <term>Byte order mark</term>
			/// </listheader>
			/// <item>
			/// <term>UTF8</term>
			/// <term>UTF-8</term>
			/// <term>EF BB BF</term>
			/// </item>
			/// <item>
			/// <term>UTF16LE</term>
			/// <term>UTF-16, little endian</term>
			/// <term>FF FE</term>
			/// </item>
			/// <item>
			/// <term>UTF16BE</term>
			/// <term>UTF-16, big endian</term>
			/// <term>FE FF</term>
			/// </item>
			/// </list>
			/// <para>For an example of a buffer with a byte order mark, see the Remarks section.</para>
			/// </param>
			/// <param name="count">A pointer to the size of the xmlMarkup buffer.</param>
			/// <remarks>
			/// <para>
			/// This method allocates memory used by the buffer returned in xmlMarkup. If the method succeeds, call the CoTaskMemFree
			/// function to free the memory.
			/// </para>
			/// <para>
			/// Serialized application-specific <c>Object</c> elements in signature markup can be added, removed, or modified by replacing
			/// the signature markup.
			/// </para>
			/// <para>
			/// To replace signature markup, call the IOpcDigitalSignatureManager::ReplaceSignatureXml method. The caller must ensure that
			/// addition, deletion, or modification of application-specific <c>Object</c> elements does not break the signature.
			/// </para>
			/// <para>
			/// To sign an application-specific <c>Object</c> element or a child of that element, create a reference to the XML element to
			/// be signed. Create the reference by calling the IOpcSignatureReferenceSet::Create method with the referenceUri parameter
			/// value set to "#" followed by the <c>Id</c> attribute value of the referenced element. For example, if the <c>Id</c>
			/// attribute of the referenced element is "Application", set referenceUri to "#Application".
			/// </para>
			/// <para>The following table shows a byte order mark at the beginning of an xmlMarkup buffer that contains "&lt;Object Id="id1"&gt;&lt;/Object&gt;":</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Buffer Byte Index</term>
			/// <term>0</term>
			/// <term>1</term>
			/// <term>2</term>
			/// <term>3</term>
			/// <term>4</term>
			/// <term>5</term>
			/// <term>6</term>
			/// <term>7</term>
			/// <term>...</term>
			/// </listheader>
			/// <item>
			/// <term>UTF8 Value</term>
			/// <term>EF</term>
			/// <term>BB</term>
			/// <term>BF</term>
			/// <term>'&lt;'</term>
			/// <term>'O'</term>
			/// <term>'b'</term>
			/// <term>'j'</term>
			/// <term>'e'</term>
			/// <term>...</term>
			/// </item>
			/// <item>
			/// <term>UTF16LE Value</term>
			/// <term>FF</term>
			/// <term>FE</term>
			/// <term>'&lt;'</term>
			/// <term>00</term>
			/// <term>'O'</term>
			/// <term>00</term>
			/// <term>'b'</term>
			/// <term>00</term>
			/// <term>...</term>
			/// </item>
			/// </list>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturecustomobject-getxml HRESULT GetXml( UINT8
			// **xmlMarkup, UINT32 *count );
			void GetXml(out SafeCoTaskMemHandle xmlMarkup, out uint count);
		}

		/// <summary>A read-only enumerator of IOpcSignatureCustomObject interface pointers.</summary>
		/// <remarks>
		/// <para>
		/// When an enumerator is created, the current position precedes the first pointer of the enumerator. To set the current position to
		/// the first pointer, call the MoveNextmethod after creating the enumerator.
		/// </para>
		/// <para>Changes to the set will invalidate the enumerator, and all subsequent calls to it will fail.</para>
		/// <para>
		/// To get an <c>IOpcSignatureCustomObjectEnumerator</c> interface pointer, call the IOpcDigitalSignature::GetCustomObjectEnumerator
		/// or IOpcSignatureCustomObjectSet::GetEnumerator method.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcsignaturecustomobjectenumerator
		[PInvokeData("msopc.h")]
		[ComImport, Guid("5ee4fe1d-e1b0-4683-8079-7ea0fcf80b4c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcSignatureCustomObjectEnumerator
		{
			/// <summary>Moves the current position of the enumerator to the next IOpcSignatureCustomObject interface pointer.</summary>
			/// <param name="hasNext">
			/// <para>A Boolean value that indicates the status of the IOpcSignatureCustomObject interface pointer at the current position.</para>
			/// <para>The value of hasNext is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The current position of the enumerator has been advanced to the next pointer and that pointer is valid.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been advanced past the end of the collection and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasNext parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_NEXT 0x80510051</term>
			/// <term>The current position is already past the last item of the enumerator.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturecustomobjectenumerator-movenext HRESULT
			// MoveNext( BOOL *hasNext );
			[PreserveSig]
			HRESULT MoveNext([MarshalAs(UnmanagedType.Bool)] out bool hasNext);

			/// <summary>Moves the current position of the enumerator to the previous IOpcSignatureCustomObjectinterface pointer.</summary>
			/// <param name="hasPrevious">
			/// <para>A Boolean value that indicates the status of the IOpcSignatureCustomObjectinterface pointer at the current position.</para>
			/// <para>The value of hasPrevious is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>
			/// The current position of the enumerator has been moved to the previous pointer in the collection, and that pointer is valid.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been moved past the beginning of the collection and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasPrevious parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_PREVIOUS 0x80510052</term>
			/// <term>The current position already precedes the first item of the enumerator.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturecustomobjectenumerator-moveprevious HRESULT
			// MovePrevious( BOOL *hasPrevious );
			[PreserveSig]
			HRESULT MovePrevious([MarshalAs(UnmanagedType.Bool)] out bool hasPrevious);

			/// <summary>Gets the IOpcSignatureCustomObject interface at the current position of the enumerator.</summary>
			/// <param name="customObject">An IOpcSignatureCustomObject interface pointer.</param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The partReference parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_INVALID_POSITION 0x80510053</term>
			/// <term>The enumerator cannot perform this operation from its current position.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When an enumerator is created, the current position precedes the first pointer of the enumerator. To set the current
			/// position to the first pointer, call the MoveNextmethod after creating the enumerator.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturecustomobjectenumerator-getcurrent HRESULT
			// GetCurrent( IOpcSignatureCustomObject **customObject );
			[PreserveSig]
			HRESULT GetCurrent(out IOpcSignatureCustomObject customObject);

			/// <summary>Creates a copy of the current IOpcSignatureCustomObjectEnumerator interface pointer and all its descendants.</summary>
			/// <returns>A pointer to a copy of the IOpcSignatureCustomObjectEnumeratorinterface pointer.</returns>
			/// <remarks>
			/// <para>The copy has a current position and set that are identical to the current enumerator.</para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturecustomobjectenumerator-clone HRESULT Clone(
			// IOpcSignatureCustomObjectEnumerator **copy );
			IOpcSignatureCustomObjectEnumerator Clone();
		}

		/// <summary>
		/// An unordered set of IOpcSignatureCustomObject interface pointers that contain the XML markup of application-specific
		/// <c>Object</c> elements.
		/// </summary>
		/// <remarks>
		/// <para>
		/// An IOpcSignatureCustomObject interface pointer provides access to the XML markup of the <c>Object</c> element it represents. To
		/// access the XML markup of the <c>Object</c> element, call the IOpcSignatureCustomObject::GetXml method.
		/// </para>
		/// <para>
		/// When an IOpcSignatureCustomObject interface pointer is created and added to the set, the <c>Object</c> it represents is saved
		/// when the package is saved.
		/// </para>
		/// <para>
		/// When an IOpcSignatureCustomObject interface pointer is deleted from the set, the <c>Object</c> it represents is not saved when
		/// the package is saved.
		/// </para>
		/// <para>To create an <c>IOpcSignatureCustomObjectSet</c> interface pointer, call the IOpcSigningOptions::GetCustomObjectSet method.</para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcsignaturecustomobjectset
		[PInvokeData("msopc.h")]
		[ComImport, Guid("8f792ac5-7947-4e11-bc3d-2659ff046ae1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcSignatureCustomObjectSet
		{
			/// <summary>
			/// Creates an IOpcSignatureCustomObject interface pointer to represent an application-specific <c>Object</c> element in the
			/// signature, and adds the new interface to the set.
			/// </summary>
			/// <param name="xmlMarkup">
			/// <para>A buffer that contains the XML markup for the <c>Object</c> element to be represented.</para>
			/// <para>This XML markup must include the opening <c>Object</c> and closing <c>/Object</c> tags.</para>
			/// <para>
			/// The encoding of the markup contained in xmlMarkup will be inferred. Inclusion of a byte order mark at the beginning of the
			/// buffer passed in xmlMarkup is optional.
			/// </para>
			/// <para>The following encodings and</para>
			/// <para>byte order mark</para>
			/// <para>values are supported:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Encoding</term>
			/// <term>Description</term>
			/// <term>Byte order mark</term>
			/// </listheader>
			/// <item>
			/// <term>UTF8</term>
			/// <term>UTF-8</term>
			/// <term>EF BB BF</term>
			/// </item>
			/// <item>
			/// <term>UTF16LE</term>
			/// <term>UTF-16, little endian</term>
			/// <term>FF FE</term>
			/// </item>
			/// <item>
			/// <term>UTF16BE</term>
			/// <term>UTF-16, big endian</term>
			/// <term>FE FF</term>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="count">The size of the xmlMarkup buffer.</param>
			/// <returns>
			/// <para>A new IOpcSignatureCustomObject interface pointer that represents the application-specific <c>Object</c> element.</para>
			/// <para>This parameter can be <c>NULL</c> if a pointer to the new interface is not needed.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// An IOpcSignatureCustomObject interface pointer provides access to the XML markup of the <c>Object</c> element it represents.
			/// To access the XML markup of the <c>Object</c> element, call the IOpcSignatureCustomObject::GetXml method.
			/// </para>
			/// <para>
			/// When an IOpcSignatureCustomObject interface pointer is created and added to the set, the <c>Object</c> it represents is
			/// saved when the package is saved.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturecustomobjectset-create HRESULT Create( const
			// UINT8 *xmlMarkup, UINT32 count, IOpcSignatureCustomObject **customObject );
			IOpcSignatureCustomObject Create([In] byte[] xmlMarkup, uint count);

			/// <summary>Deletes a specified IOpcSignatureCustomObject interface pointer from the set.</summary>
			/// <param name="customObject">An IOpcSignatureCustomObject interface pointer to be deleted.</param>
			/// <remarks>
			/// <para>
			/// When an IOpcSignatureCustomObject interface pointer is deleted from the set, the <c>Object</c> it represents is not saved
			/// when the package is saved.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturecustomobjectset-delete HRESULT Delete(
			// IOpcSignatureCustomObject *customObject );
			void Delete(IOpcSignatureCustomObject customObject);

			/// <summary>Gets an enumerator of IOpcSignatureCustomObject interface pointers in the set.</summary>
			/// <returns>A pointer to an enumerator of IOpcSignatureCustomObject interface pointers in the set.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturecustomobjectset-getenumerator HRESULT
			// GetEnumerator( IOpcSignatureCustomObjectEnumerator **customObjectEnumerator );
			IOpcSignatureCustomObjectEnumerator GetEnumerator();
		}

		/// <summary>Represents a reference to a part that has been or will be signed.</summary>
		/// <remarks>
		/// <para>
		/// Only parts that can be represented by the IOpcPart interface can be referenced by an <c>IOpcSignaturePartReference</c> interface
		/// pointer. Relationships parts are referenced for signing by a pointer to the IOpcSignatureRelationshipReference interface. To
		/// create an <c>IOpcSignatureRelationshipReference</c> interface pointer, call the IOpcSignatureRelationshipReferenceSet::Create method.
		/// </para>
		/// <para>To create an <c>IOpcSignaturePartReference</c> interface pointer, call the IOpcSignaturePartReferenceSet::Create method.</para>
		/// <para>
		/// To access an <c>IOpcSignaturePartReference</c> interface pointer, call the IOpcSignaturePartReferenceEnumerator::GetCurrent method.
		/// </para>
		/// <para>
		/// The interface provides methods to access information about the referenced part and the reference itself. When a signature is
		/// generated, this reference information is serialized in the XML markup of the signature (signature markup). In signature markup,
		/// the information is represented by a <c>Reference</c> element that has its <c>URI</c> attribute value set to the part name of the
		/// referenced part.
		/// </para>
		/// <para>
		/// The following markup shows that these <c>Reference</c> elements are children of the <c>Manifest</c> element in signature markup.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcsignaturepartreference
		[PInvokeData("msopc.h")]
		[ComImport, Guid("e24231ca-59f4-484e-b64b-36eeda36072c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcSignaturePartReference
		{
			/// <summary>Gets the part name of the referenced part.</summary>
			/// <returns>A pointer to an IOpcPartUri interface that represents the part name.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturepartreference-getpartname HRESULT GetPartName(
			// IOpcPartUri **partName );
			IOpcPartUri GetPartName();

			/// <summary>Gets the content type of the referenced part.</summary>
			/// <returns>The content type of the referenced part.</returns>
			/// <remarks>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturepartreference-getcontenttype HRESULT
			// GetContentType( LPWSTR *contentType );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetContentType();

			/// <summary>Gets the digest method to use on part content of the referenced part when the part is signed.</summary>
			/// <returns>The digest method to use on part content of the referenced part when the part is signed.</returns>
			/// <remarks>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturepartreference-getdigestmethod HRESULT
			// GetDigestMethod( LPWSTR *digestMethod );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetDigestMethod();

			/// <summary>Gets the digest value that is calculated for part content of the referenced part when the part is signed.</summary>
			/// <param name="digestValue">
			/// A pointer to a buffer that contains the digest value that is calculated using the specified digest method; the method is
			/// applied to part content of the referenced part when the part is signed.
			/// </param>
			/// <param name="count">
			/// <para>The size of the digestValue buffer.</para>
			/// <para>If the referenced part has not been signed yet, count is 0.</para>
			/// </param>
			/// <remarks>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturepartreference-getdigestvalue HRESULT
			// GetDigestValue( UINT8 **digestValue, UINT32 *count );
			void GetDigestValue(out SafeCoTaskMemHandle digestValue, out uint count);

			/// <summary>Gets the canonicalization method to use on part content of a referenced part when the part is signed.</summary>
			/// <returns>The canonicalization method to use on part content of a referenced part when the part is signed.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturepartreference-gettransformmethod HRESULT
			// GetTransformMethod( OPC_CANONICALIZATION_METHOD *transformMethod );
			OPC_CANONICALIZATION_METHOD GetTransformMethod();
		}

		/// <summary>A read-only enumerator of IOpcSignaturePartReference interface pointers.</summary>
		/// <remarks>
		/// <para>
		/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first pointer
		/// of the enumerator, call the MoveNextmethod after creating the enumerator.
		/// </para>
		/// <para>Changes to the set will invalidate the enumerator, and all subsequent calls to it will fail.</para>
		/// <para>
		/// To get an <c>IOpcSignaturePartReferenceEnumerator</c> interface pointer, call the IOpcSignaturePartReferenceSet::GetEnumerator
		/// or IOpcDigitalSignature::GetSignaturePartReferenceEnumerator method.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcsignaturepartreferenceenumerator
		[PInvokeData("msopc.h")]
		[ComImport, Guid("80eb1561-8c77-49cf-8266-459b356ee99a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcSignaturePartReferenceEnumerator
		{
			/// <summary>Moves the current position of the enumerator to the next IOpcSignaturePartReference interface pointer.</summary>
			/// <param name="hasNext">
			/// <para>A Boolean value that indicates the status of the IOpcSignaturePartReference interface pointer at the current position.</para>
			/// <para>The value of hasNext is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The current position of the enumerator has been advanced to the next pointer and that pointer is valid.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been advanced past the end of the collection and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasNext parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_NEXT 0x80510051</term>
			/// <term>The current position is already past the last item of the enumerator.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturepartreferenceenumerator-movenext HRESULT
			// MoveNext( BOOL *hasNext );
			[PreserveSig]
			HRESULT MoveNext([MarshalAs(UnmanagedType.Bool)] out bool hasNext);

			/// <summary>Moves the current position of the enumerator to the previous IOpcSignaturePartReference interface pointer.</summary>
			/// <param name="hasPrevious">
			/// <para>A Boolean value that indicates the status of the IOpcSignaturePartReference interface pointer at the current position.</para>
			/// <para>The value of hasPrevious is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>
			/// The current position of the enumerator has been moved to the previous pointer in the collection, and that pointer is valid.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been moved past the beginning of the collection and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasPrevious parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_PREVIOUS 0x80510052</term>
			/// <term>The current position already precedes the first item of the enumerator.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturepartreferenceenumerator-moveprevious HRESULT
			// MovePrevious( BOOL *hasPrevious );
			[PreserveSig]
			HRESULT MovePrevious([MarshalAs(UnmanagedType.Bool)] out bool hasPrevious);

			/// <summary>Gets the IOpcSignaturePartReference interface pointer at the current position of the enumerator.</summary>
			/// <param name="partReference">An IOpcSignaturePartReference interface pointer.</param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The partReference parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_INVALID_POSITION 0x80510053</term>
			/// <term>The enumerator cannot perform this operation from its current position.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first
			/// pointer of the enumerator, call the MoveNextmethod after creating the enumerator.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturepartreferenceenumerator-getcurrent HRESULT
			// GetCurrent( IOpcSignaturePartReference **partReference );
			[PreserveSig]
			HRESULT GetCurrent(out IOpcSignaturePartReference partReference);

			/// <summary>Creates a copy of the current IOpcSignaturePartReferenceEnumerator interface pointer and all its descendants.</summary>
			/// <returns>A pointer to a copy of the IOpcSignaturePartReferenceEnumerator interface pointer.</returns>
			/// <remarks>
			/// <para>The copy has a current position and set that are identical to the current enumerator.</para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturepartreferenceenumerator-clone HRESULT Clone(
			// IOpcSignaturePartReferenceEnumerator **copy );
			IOpcSignaturePartReferenceEnumerator Clone();
		}

		/// <summary>An unordered set of IOpcSignaturePartReference interface pointers that represent references to parts to be signed.</summary>
		/// <remarks>
		/// <para>
		/// Only parts that can be represented by the IOpcPart interface can be referenced by an IOpcSignaturePartReference interface
		/// pointer. Relationships parts are referenced for signing by a pointer to the IOpcSignatureRelationshipReference interface. To
		/// create an <c>IOpcSignatureRelationshipReference</c> interface pointer, call the IOpcSignatureRelationshipReferenceSet::Create method.
		/// </para>
		/// <para>
		/// When an IOpcSignaturePartReference interface pointer is created and added to the set, the reference it represents is saved when
		/// the package is saved.
		/// </para>
		/// <para>
		/// When an IOpcSignaturePartReference interface pointer is deleted from the set, the reference it represents is not saved when the
		/// package is saved.
		/// </para>
		/// <para>
		/// To create an <c>IOpcSignaturePartReferenceSet</c> interface pointer, call the IOpcSigningOptions::GetSignaturePartReferenceSet method.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcsignaturepartreferenceset
		[PInvokeData("msopc.h")]
		[ComImport, Guid("6c9fe28c-ecd9-4b22-9d36-7fdde670fec0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcSignaturePartReferenceSet
		{
			/// <summary>
			/// Creates an IOpcSignaturePartReference interface pointer that represents a reference to a part to be signed, and adds the new
			/// interface to the set.
			/// </summary>
			/// <param name="partUri">An IOpcPartUri that represents the part name of the part to be referenced.</param>
			/// <param name="digestMethod">
			/// The digest method to be used for part content of the part to be referenced. To use the default digest method, pass
			/// <c>NULL</c> to this parameter.
			/// </param>
			/// <param name="transformMethod">The canonicalization method used for part content of the part to be referenced.</param>
			/// <returns>
			/// <para>A new IOpcSignaturePartReference interface pointer that represents the reference to the part to be signed.</para>
			/// <para>This parameter can be <c>NULL</c> if a pointer to the new interface is not needed.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Only parts that can be represented by the IOpcPart interface can be referenced by an IOpcSignaturePartReference interface
			/// pointer. Relationships parts are referenced for signing by a pointer to the IOpcSignatureRelationshipReference interface. To
			/// create an <c>IOpcSignatureRelationshipReference</c> interface pointer, call the
			/// IOpcSignatureRelationshipReferenceSet::Create method.
			/// </para>
			/// <para>
			/// When an IOpcSignaturePartReference interface pointer is created and added to the set, the reference it represents is saved
			/// when the package is saved.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturepartreferenceset-create HRESULT Create(
			// IOpcPartUri *partUri, LPCWSTR digestMethod, OPC_CANONICALIZATION_METHOD transformMethod, IOpcSignaturePartReference
			// **partReference );
			IOpcSignaturePartReference Create(IOpcPartUri partUri, [Optional, MarshalAs(UnmanagedType.LPWStr)] string digestMethod, OPC_CANONICALIZATION_METHOD transformMethod);

			/// <summary>Deletes a specified IOpcSignaturePartReference interface pointer from the set.</summary>
			/// <param name="partReference">An IOpcSignaturePartReference interface pointer to be deleted.</param>
			/// <remarks>
			/// <para>
			/// When an IOpcSignaturePartReference interface pointer is deleted from the set, the reference it represents is not saved when
			/// the package is saved.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturepartreferenceset-delete HRESULT Delete(
			// IOpcSignaturePartReference *partReference );
			void Delete(IOpcSignaturePartReference partReference);

			/// <summary>Gets an enumerator of IOpcSignaturePartReference interface pointers in the set.</summary>
			/// <returns>A pointer to an enumerator of IOpcSignaturePartReference interface pointers in the set.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturepartreferenceset-getenumerator HRESULT
			// GetEnumerator( IOpcSignaturePartReferenceEnumerator **partReferenceEnumerator );
			IOpcSignaturePartReferenceEnumerator GetEnumerator();
		}

		/// <summary>
		/// Represents a reference to XML markup that has been or will be signed. This referenced XML markup is serialized in the signature
		/// markup when a signature is generated.
		/// </summary>
		/// <remarks>
		/// <para>
		/// To create an <c>IOpcSignatureReference</c> interface pointer, call the IOpcSignatureReferenceSet::Create method.
		/// <c>IOpcSignatureReferenceSet::Create</c> does not create the reference to the package-specific <c>Object</c> element; that
		/// reference is created automatically when the signature is generated.
		/// </para>
		/// <para>
		/// To access an <c>IOpcSignatureReference</c> interface pointer, call the IOpcSignatureReferenceEnumerator::GetCurrent method.
		/// <c>IOpcSignatureReferenceEnumerator::GetCurrent</c> does not access the reference to the package-specific <c>Object</c> element;
		/// call the IOpcDigitalSignature::GetPackageObjectReference method to access that reference.
		/// </para>
		/// <para>
		/// The interface provides methods to access information about the reference itself, and referenced XML element. The referenced
		/// element can be the package-specific <c>Object</c> element, an application-specific <c>Object</c> element, or a child element of
		/// an application-specific <c>Object</c>.
		/// </para>
		/// <para>
		/// When a signature is generated, this reference information is serialized in the XML markup of the signature (signature markup).
		/// In signature markup, the information is represented by a <c>Reference</c> element that has its <c>URI</c> attribute value set to
		/// "#" followed by the <c>Id</c> attribute value of the referenced element. For example, if the <c>Id</c> attribute of the
		/// referenced element is "Application" the <c>URI</c> attribute of the <c>Reference</c> element is set to "#Application" as shown
		/// in the following markup.
		/// </para>
		/// <para>The following signature markup shows a serialized reference to a signed, application-specific <c>Object</c> element.</para>
		/// <para>
		/// The following signature markup shows a serialized reference to a signed, child element of an application-specific <c>Object</c> element.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcsignaturereference
		[PInvokeData("msopc.h")]
		[ComImport, Guid("1b47005e-3011-4edc-be6f-0f65e5ab0342"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcSignatureReference
		{
			/// <summary>Gets the identifier for the reference.</summary>
			/// <returns>
			/// <para>An identifier for the reference.</para>
			/// <para>If the identifier is not set, referenceId will be the empty string, "".</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Providing an identifier for a reference is optional. If used, the identifier is serialized as the optional <c>Id</c>
			/// attribute of a <c>Reference</c> element in the signature markup.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturereference-getid HRESULT GetId( LPWSTR
			// *referenceId );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetId();

			/// <summary>Gets the URI of the referenced XML element.</summary>
			/// <returns>
			/// <para>A pointer to the URI of the referenced element.</para>
			/// <para>This URI represented by a string is "#" followed by the <c>Id</c> attribute value of the referenced element: "#&lt;elementIdValue&gt;".</para>
			/// <para>For examples, see the Remarks section.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The URI of the referenced element is serialized in the signature markup as the <c>URI</c> attribute of a <c>Reference</c> element.
			/// </para>
			/// <para>The following table shows two examples of the referenceUri parameter value represented as strings.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>referenceUri Value as String</term>
			/// <term>Referenced Element</term>
			/// <term>Element Description</term>
			/// </listheader>
			/// <item>
			/// <term>"#idMyCustomObject"</term>
			/// <term>"&lt;Object Id="idMyCustomObject"&gt;...&lt;/Object&gt;"</term>
			/// <term>An application-specific Object element.</term>
			/// </item>
			/// <item>
			/// <term>"#idMyElement"</term>
			/// <term>"&lt;Object&gt;&lt;MyElement Id="idMyElement"&gt;...&lt;/MyElement&gt;...&lt;/Object&gt;"</term>
			/// <term>A child element of an application-specific Object.</term>
			/// </item>
			/// </list>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturereference-geturi HRESULT GetUri( IUri
			// **referenceUri );
			IUri GetUri();

			/// <summary>Gets a string that indicates the type of the referenced XML element.</summary>
			/// <returns>
			/// <para>A string that indicates the type of the referenced XML element.</para>
			/// <para>If the type is not set, the type parameter will be the empty string "".</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Providing a type for the referenced XML element is optional. If used, the type of the referenced element is serialized in
			/// the signature markup as the optional <c>Type</c> attribute value of a <c>Reference</c> element.
			/// </para>
			/// <para>
			/// The caller can use the type of the referenced element to indicate whether the element is an <c>Object</c>,
			/// <c>SignatureProperty</c>, or <c>Manifest</c> element. This identification can aid the caller in processing the reference.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturereference-gettype HRESULT GetType( LPWSTR
			// *type );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetType();

			/// <summary>Gets the canonicalization method to use on the referenced XML element, when the element is signed.</summary>
			/// <returns>The canonicalization method to use on the referenced XML element, when the element is signed.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturereference-gettransformmethod HRESULT
			// GetTransformMethod( OPC_CANONICALIZATION_METHOD *transformMethod );
			OPC_CANONICALIZATION_METHOD GetTransformMethod();

			/// <summary>Gets the digest method to use on the referenced XML element, when the element is signed.</summary>
			/// <returns>The digest method to use on the referenced XML element.</returns>
			/// <remarks>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturereference-getdigestmethod HRESULT
			// GetDigestMethod( LPWSTR *digestMethod );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetDigestMethod();

			/// <summary>Gets the digest value that is calculated for the referenced XML element when the element is signed.</summary>
			/// <param name="digestValue">
			/// A pointer to a buffer that contains the digest value calculated using the specified digest method when the referenced XML
			/// element is signed.
			/// </param>
			/// <param name="count">If the referenced XML element has not been signed yet, count is 0.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturereference-getdigestvalue HRESULT
			// GetDigestValue( UINT8 **digestValue, UINT32 *count );
			void GetDigestValue(out SafeCoTaskMemHandle digestValue, out uint count);
		}

		/// <summary>A read-only enumerator of IOpcSignatureReference interface pointers.</summary>
		/// <remarks>
		/// <para>
		/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first pointer
		/// of the enumerator, call the MoveNextmethod after creating the enumerator.
		/// </para>
		/// <para>Changes to the set will invalidate the enumerator, and all subsequent calls to it will fail.</para>
		/// <para>
		/// To get an <c>IOpcSignatureReferenceEnumerator</c> interface pointer, call the IOpcSignatureReferenceSet::GetEnumerator or
		/// IOpcDigitalSignature::GetCustomReferenceEnumerator method.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcsignaturereferenceenumerator
		[PInvokeData("msopc.h")]
		[ComImport, Guid("cfa59a45-28b1-4868-969e-fa8097fdc12a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcSignatureReferenceEnumerator
		{
			/// <summary>Moves the current position of the enumerator to the next IOpcSignatureReference interface pointer.</summary>
			/// <param name="hasNext">
			/// <para>A Boolean value that indicates the status of the IOpcSignatureReference interface pointer at the current position.</para>
			/// <para>The value of hasNext is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The current position of the enumerator has been advanced to the next pointer and that pointer is valid.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been advanced past the end of the collection and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasNext parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_NEXT 0x80510051</term>
			/// <term>The current position is already past the last item of the enumerator.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturereferenceenumerator-movenext HRESULT MoveNext(
			// BOOL *hasNext );
			[PreserveSig]
			HRESULT MoveNext([MarshalAs(UnmanagedType.Bool)] out bool hasNext);

			/// <summary>Moves the current position of the enumerator to the previous IOpcSignatureReferenceinterface pointer.</summary>
			/// <param name="hasPrevious">
			/// <para>A Boolean value that indicates the status of the IOpcSignatureReference interface pointer at the current position.</para>
			/// <para>The value of hasPrevious is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>
			/// The current position of the enumerator has been moved to the previous pointer in the collection, and that pointer is valid.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been moved past the beginning of the collection and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasPrevious parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_PREVIOUS 0x80510052</term>
			/// <term>The current position already precedes the first item of the enumerator.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturereferenceenumerator-moveprevious HRESULT
			// MovePrevious( BOOL *hasPrevious );
			[PreserveSig]
			HRESULT MovePrevious([MarshalAs(UnmanagedType.Bool)] out bool hasPrevious);

			/// <summary>Gets the IOpcSignatureReference interface pointer at the current position of the enumerator.</summary>
			/// <param name="reference">An IOpcSignatureReference interface pointer.</param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The partReference parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_INVALID_POSITION 0x80510053</term>
			/// <term>The enumerator cannot perform this operation from its current position.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first
			/// pointer of the enumerator, call the MoveNextmethod after creating the enumerator.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturereferenceenumerator-getcurrent HRESULT
			// GetCurrent( IOpcSignatureReference **reference );
			[PreserveSig]
			HRESULT GetCurrent(out IOpcSignatureReference reference);

			/// <summary>Creates a copy of the current IOpcSignatureReferenceEnumerator interface pointer and all its descendants.</summary>
			/// <returns>A pointer to a copy of the IOpcSignatureReferenceEnumerator interface pointer.</returns>
			/// <remarks>
			/// <para>The copy has a current position and set that are identical to the current enumerator.</para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturereferenceenumerator-clone HRESULT Clone(
			// IOpcSignatureReferenceEnumerator **copy );
			IOpcSignatureReferenceEnumerator Clone();
		}

		/// <summary>
		/// An unordered set of IOpcSignatureReference interface pointers that represent references to XML elements to be signed. An XML
		/// element to be signed can be either an application-specific <c>Object</c> element or a child element.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The Create method creates a reference to an application-specific <c>Object</c> element or a child of an application-specific
		/// <c>Object</c> that is signed when the signature is generated. <c>Create</c> does not create the reference to the
		/// package-specific <c>Object</c> element to be signed; that reference is created automatically when the signature is generated.
		/// </para>
		/// <para>
		/// When an IOpcSignatureReference interface pointer is created and added to the set, the reference it represents is saved when the
		/// package is saved.
		/// </para>
		/// <para>
		/// When an IOpcSignatureReference interface pointer is deleted from the set, the reference it represents is not saved when the
		/// package is saved.
		/// </para>
		/// <para>To access an <c>IOpcSignatureReferenceSet</c> interface pointer, call the IOpcSigningOptions::GetCustomReferenceSet method.</para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcsignaturereferenceset
		[PInvokeData("msopc.h")]
		[ComImport, Guid("f3b02d31-ab12-42dd-9e2f-2b16761c3c1e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcSignatureReferenceSet
		{
			/// <summary>Creates an IOpcSignatureReference interface pointer that represents a reference to an XML element to be signed.</summary>
			/// <param name="referenceUri">
			/// <para>The URI of the referenced XML element.</para>
			/// <para>
			/// Set the value of this parameter to a URI that represents "#" followed by the <c>Id</c> attribute value of the referenced
			/// element: "#&lt;elementIdValue&gt;".
			/// </para>
			/// <para>For examples, see the Remarks section.</para>
			/// </param>
			/// <param name="referenceId">
			/// The <c>Id</c> attribute of the <c>Reference</c> element that represents the reference in signature markup. To omit the
			/// <c>Id</c> attribute, set this parameter value to <c>NULL</c>.
			/// </param>
			/// <param name="type">
			/// The <c>Type</c> attribute of the <c>Reference</c> element that represents the reference in signature markup. To omit the
			/// <c>Type</c> attribute, set this parameter value to <c>NULL</c>.
			/// </param>
			/// <param name="digestMethod">
			/// <para>
			/// The digest method to be used for the XML markup to be referenced. To use the default digest method, set this parameter value
			/// to <c>NULL</c>.
			/// </para>
			/// <para>
			/// <c>Important</c> The default digest method must be set by calling the IOpcSigningOptions::SetDefaultDigestMethod method
			/// before IOpcDigitalSignatureManager::Sign is called.
			/// </para>
			/// </param>
			/// <param name="transformMethod">The canonicalization method to be used for the XML markup to be referenced.</param>
			/// <returns>A new IOpcSignatureReference interface pointer that represents the reference to the XML element to be signed.</returns>
			/// <remarks>
			/// <para>
			/// This method creates a reference to an XML element that is signed when the signature is generated. The referenced element can
			/// be either an application-specific <c>Object</c> element or a child of an application-specific <c>Object</c>.
			/// </para>
			/// <para>
			/// To reference an XML element for signing, set the referenceUri parameter value to a URI that represents "#" followed by the
			/// <c>Id</c> attribute value of the referenced element, as shown in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>referenceUri Value as String</term>
			/// <term>Referenced Element</term>
			/// <term>Element Description</term>
			/// </listheader>
			/// <item>
			/// <term>"#idMyCustomObject"</term>
			/// <term>"&lt;Object Id="idMyCustomObject"&gt;...&lt;/Object&gt;"</term>
			/// <term>An application-specific Object element.</term>
			/// </item>
			/// <item>
			/// <term>"#idMyElement"</term>
			/// <term>"&lt;Object&gt;&lt;MyElement Id="idMyElement"&gt;...&lt;/MyElement&gt;...&lt;/Object&gt;"</term>
			/// <term>A child element of an application-specific Object.</term>
			/// </item>
			/// </list>
			/// <para>
			/// This method does not create the reference to the package-specific <c>Object</c> element to be signed; that reference is
			/// created automatically when the signature is generated.
			/// </para>
			/// <para>
			/// When an IOpcSignatureReference interface pointer is created and added to the set, the reference it represents is saved when
			/// the package is saved.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturereferenceset-create HRESULT Create( IUri
			// *referenceUri, LPCWSTR referenceId, LPCWSTR type, LPCWSTR digestMethod, OPC_CANONICALIZATION_METHOD transformMethod,
			// IOpcSignatureReference **reference );
			IOpcSignatureReference Create(IUri referenceUri, [MarshalAs(UnmanagedType.LPWStr)] string referenceId, [MarshalAs(UnmanagedType.LPWStr)] string type,
				[Optional, MarshalAs(UnmanagedType.LPWStr)] string digestMethod, OPC_CANONICALIZATION_METHOD transformMethod);

			/// <summary>Deletes a specified IOpcSignatureReference interface pointer from the set.</summary>
			/// <param name="reference">An IOpcSignatureReference interface pointer to be deleted.</param>
			/// <remarks>
			/// <para>
			/// When an IOpcSignatureReference interface pointer is deleted from the set, the reference it represents is not saved when the
			/// package is saved.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturereferenceset-delete HRESULT Delete(
			// IOpcSignatureReference *reference );
			void Delete(IOpcSignatureReference reference);

			/// <summary>Gets an enumerator of IOpcSignatureReference interface pointers in the set.</summary>
			/// <returns>A pointer to an enumerator of IOpcSignatureReference interface pointers in the set.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturereferenceset-getenumerator HRESULT
			// GetEnumerator( IOpcSignatureReferenceEnumerator **referenceEnumerator );
			IOpcSignatureReferenceEnumerator GetEnumerator();
		}

		/// <summary>Represents a reference to a Relationships part that contains relationships that have been or will be signed.</summary>
		/// <remarks>
		/// <para>
		/// To create an <c>IOpcSignatureRelationshipReference</c> interface pointer that represents a reference to a Relationships part,
		/// call the Create method. This reference will indicate whether all or a subset of the relationships in the Relationships part will
		/// be signed when the signature is generated.
		/// </para>
		/// <para>
		/// To access an <c>IOpcSignatureRelationshipReference</c> interface pointer, call the
		/// IOpcSignatureRelationshipReferenceEnumerator::GetCurrent method.
		/// </para>
		/// <para>
		/// Relationships that are not selected for signing can be removed, modified or added to the package without invalidating the
		/// signature. If a subset of relationships has been selected for signing and the subset is altered, the signature will be invalidated.
		/// </para>
		/// <para>
		/// The interface provides methods to access information about the referenced Relationships part, the selected relationships that
		/// have been or will be signed, and the reference itself. When a signature is generated, this reference information is serialized
		/// in the XML markup of the signature (signature markup). In signature markup, the information is represented by a <c>Reference</c>
		/// element that has a <c>URI</c> attribute value that identifies a Relationships part.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcsignaturerelationshipreference
		[PInvokeData("msopc.h")]
		[ComImport, Guid("57babac6-9d4a-4e50-8b86-e5d4051eae7c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcSignatureRelationshipReference
		{
			/// <summary>Gets the source URI of the relationships that are stored in the referenced Relationships part.</summary>
			/// <returns>A pointer to the source URI of the relationships that are stored in the referenced Relationships part.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturerelationshipreference-getsourceuri HRESULT
			// GetSourceUri( IOpcUri **sourceUri );
			IOpcUri GetSourceUri();

			/// <summary>Gets the digest method to use on relationship markup of the selected relationships.</summary>
			/// <returns>The digest method to use on relationship markup of the selected relationships when they are signed.</returns>
			/// <remarks>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturerelationshipreference-getdigestmethod HRESULT
			// GetDigestMethod( LPWSTR *digestMethod );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetDigestMethod();

			/// <summary>Gets the digest value calculated for the selected relationships when they are signed.</summary>
			/// <param name="digestValue">
			/// A pointer to a buffer that contains the digest value calculated using the specified digest method; the method is applied to
			/// the relationship markup of the selected relationships when they are signed.
			/// </param>
			/// <param name="count">
			/// <para>The size of the digestValue buffer.</para>
			/// <para>If the selected relationships have not been signed yet, count is 0.</para>
			/// </param>
			/// <remarks>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturerelationshipreference-getdigestvalue HRESULT
			// GetDigestValue( UINT8 **digestValue, UINT32 *count );
			void GetDigestValue(out SafeCoTaskMemHandle digestValue, out uint count);

			/// <summary>
			/// Gets the canonicalization method to use on the relationship markup of the selected relationships when they are signed.
			/// </summary>
			/// <returns>The canonicalization method to use on the relationship markup of the selected relationships when they are signed.</returns>
			/// <remarks>
			/// <para>All or a subset of the relationships in a referenced Relationships part can be signed.</para>
			/// <para>
			/// If a subset of is selected and the signature is generated by calling the IOpcDigitalSignatureManager::Sign method, the
			/// transform methods that are applied to relationship markup are the relationships transform followed by the
			/// <c>OPC_CANONICALIZATION_C14N</c> canonicalization method.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturerelationshipreference-gettransformmethod
			// HRESULT GetTransformMethod( OPC_CANONICALIZATION_METHOD *transformMethod );
			OPC_CANONICALIZATION_METHOD GetTransformMethod();

			/// <summary>
			/// Gets a value that describes whether all or a subset of relationships that are stored in the referenced Relationships part
			/// are selected.
			/// </summary>
			/// <returns>A value that describes whether all or a subset of relationships are selected.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturerelationshipreference-getrelationshipsigningoption
			// HRESULT GetRelationshipSigningOption( OPC_RELATIONSHIPS_SIGNING_OPTION *relationshipSigningOption );
			OPC_RELATIONSHIPS_SIGNING_OPTION GetRelationshipSigningOption();

			/// <summary>
			/// Gets an enumerator of IOpcRelationshipSelector interface pointers that represent the techniques used to select the subset of
			/// relationships in the referenced Relationships part.
			/// </summary>
			/// <returns>A pointer to an enumerator of IOpcRelationshipSelector interface pointers.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturerelationshipreference-getrelationshipselectorenumerator
			// HRESULT GetRelationshipSelectorEnumerator( IOpcRelationshipSelectorEnumerator **selectorEnumerator );
			IOpcRelationshipSelectorEnumerator GetRelationshipSelectorEnumerator();
		}

		/// <summary>A read-only enumerator of IOpcSignatureRelationshipReference interface pointers.</summary>
		/// <remarks>
		/// <para>
		/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first pointer
		/// of the enumerator, call the MoveNextmethod after creating the enumerator.
		/// </para>
		/// <para>Changes to the set will invalidate the enumerator and all subsequent calls to it will fail.</para>
		/// <para>
		/// To get an <c>IOpcSignatureRelationshipReferenceEnumerator</c> interface pointer, call the
		/// IOpcSignatureRelationshipReferenceSet::GetEnumerator or IOpcDigitalSignature::GetSignatureRelationshipReferenceEnumerator method.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcsignaturerelationshipreferenceenumerator
		[PInvokeData("msopc.h")]
		[ComImport, Guid("773ba3e4-f021-48e4-aa04-9816db5d3495"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcSignatureRelationshipReferenceEnumerator
		{
			/// <summary>Moves the current position of the enumerator to the next IOpcSignatureRelationshipReference interface pointer.</summary>
			/// <param name="hasNext">
			/// <para>
			/// A Boolean value that indicates the status of the IOpcSignatureRelationshipReference interface pointer at the current position.
			/// </para>
			/// <para>The value of hasNext is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The current position of the enumerator has been advanced to the next pointer and that pointer is valid.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been advanced past the end of the collection and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasNext parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_NEXT 0x80510051</term>
			/// <term>The current position is already past the last item of the enumerator.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturerelationshipreferenceenumerator-movenext
			// HRESULT MoveNext( BOOL *hasNext );
			[PreserveSig]
			HRESULT MoveNext([MarshalAs(UnmanagedType.Bool)] out bool hasNext);

			/// <summary>Moves the current position of the enumerator to the previous IOpcSignatureRelationshipReference interface pointer.</summary>
			/// <param name="hasPrevious">
			/// <para>
			/// A Boolean value that indicates the status of the IOpcSignatureRelationshipReference interface pointer at the current position.
			/// </para>
			/// <para>The value of hasPrevious is only valid when the method succeeds.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>
			/// The current position of the enumerator has been moved to the previous pointer in the collection, and that pointer is valid.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The current position of the enumerator has been moved past the beginning of the collection and is no longer valid.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The hasPrevious parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_CANNOT_MOVE_PREVIOUS 0x80510052</term>
			/// <term>The current position already precedes the first item of the enumerator.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturerelationshipreferenceenumerator-moveprevious
			// HRESULT MovePrevious( BOOL *hasPrevious );
			[PreserveSig]
			HRESULT MovePrevious([MarshalAs(UnmanagedType.Bool)] out bool hasPrevious);

			/// <summary>Gets the IOpcSignatureRelationshipReference interface pointer at the current position of the enumerator.</summary>
			/// <param name="relationshipReference">An IOpcSignatureRelationshipReference interface pointer.</param>
			/// <returns>
			/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code/value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The partReference parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_COLLECTION_CHANGED 0x80510050</term>
			/// <term>The enumerator is invalid because the underlying set has changed.</term>
			/// </item>
			/// <item>
			/// <term>OPC_E_ENUM_INVALID_POSITION 0x80510053</term>
			/// <term>The enumerator cannot perform this operation from its current position.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When an enumerator is created, the current position precedes the first pointer. To set the current position to the first
			/// pointer of the enumerator, call the MoveNextmethod after creating the enumerator.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturerelationshipreferenceenumerator-getcurrent
			// HRESULT GetCurrent( IOpcSignatureRelationshipReference **relationshipReference );
			[PreserveSig]
			HRESULT GetCurrent(out IOpcSignatureRelationshipReference relationshipReference);

			/// <summary>Creates a copy of the current IOpcSignatureRelationshipReferenceEnumerator interface pointer and all its descendants.</summary>
			/// <returns>A pointer to a copy of the IOpcSignatureRelationshipReferenceEnumerator interface pointer.</returns>
			/// <remarks>
			/// <para>The copy has a current position and set that are identical to the current enumerator.</para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturerelationshipreferenceenumerator-clone HRESULT
			// Clone( IOpcSignatureRelationshipReferenceEnumerator **copy );
			IOpcSignatureRelationshipReferenceEnumerator Clone();
		}

		/// <summary>
		/// An unordered set of IOpcSignatureRelationshipReference interface pointers that represent references to Relationships parts that
		/// contain relationships to be signed.
		/// </summary>
		/// <remarks>
		/// <para>
		/// To create an IOpcSignatureRelationshipReference interface pointer that represents a reference to a Relationships part, call the
		/// Create method. This reference will indicate whether all or a subset of the relationships in the Relationships part will be
		/// signed when the signature is generated.
		/// </para>
		/// <para>
		/// To access an <c>IOpcSignatureRelationshipReferenceSet</c> interface pointer, call the
		/// IOpcSigningOptions::GetSignatureRelationshipReferenceSet method.
		/// </para>
		/// <para>
		/// When an IOpcSignatureRelationshipReference interface pointer is created and added to the set, the reference it represents is
		/// saved when the package is saved.
		/// </para>
		/// <para>
		/// When an IOpcSignatureRelationshipReference interface pointer is deleted from the set, the reference it represents is not saved
		/// when the package is saved.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcsignaturerelationshipreferenceset
		[PInvokeData("msopc.h")]
		[ComImport, Guid("9f863ca5-3631-404c-828d-807e0715069b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcSignatureRelationshipReferenceSet
		{
			/// <summary>
			/// Creates an IOpcSignatureRelationshipReference interface pointer that represents a reference to a Relationships part, and
			/// adds the new interface pointer to the set. All or a subset of the relationships stored in the Relationships part to be
			/// referenced are selected for signing.
			/// </summary>
			/// <param name="sourceUri">
			/// An IOpcUri interface pointer that represents the source URI of the relationships to be selected for signing.
			/// </param>
			/// <param name="digestMethod">
			/// <para>
			/// The digest method to be used for the relationships to be selected. To use the default digest method, pass <c>NULL</c> in
			/// this parameter.
			/// </para>
			/// <para>
			/// <c>Important</c> The default digest method must be set by calling the IOpcSigningOptions::SetDefaultDigestMethod method
			/// before IOpcDigitalSignatureManager::Sign is called.
			/// </para>
			/// </param>
			/// <param name="relationshipSigningOption">
			/// <para>
			/// A value that indicates whether the relationships selected for signing include all or a subset of the relationships in the
			/// Relationships part to be referenced.
			/// </para>
			/// <para>For information about the effect of relationshipSigningOption values on other parameters, see Remarks.</para>
			/// </param>
			/// <param name="selectorSet">
			/// <para>
			/// An IOpcRelationshipSelectorSet interface pointer that can be used to identify a subset of relationships in the Relationships
			/// part to be selected for signing.
			/// </para>
			/// <para>If relationshipSigningOption is set to <c>OPC_RELATIONSHIP_SIGN_PART</c>, selectorSet is <c>NULL</c>.</para>
			/// <para>For information about selectorSet values, see Remarks.</para>
			/// </param>
			/// <param name="transformMethod">
			/// <para>A value that describes the canonicalization method to be applied to the relationship markup of the selected relationships.</para>
			/// <para>
			/// If relationshipSigningOption is set <c>OPC_RELATIONSHIP_SIGN_USING_SELECTORS</c>, the value of transformMethod is ignored.
			/// </para>
			/// <para>
			/// For more information about the transform methods to be applied when relationshipSigningOption is set to
			/// <c>OPC_RELATIONSHIP_SIGN_USING_SELECTORS</c>, see Remarks.
			/// </para>
			/// </param>
			/// <returns>A new IOpcSignatureRelationshipReference interface pointer that represents the referenced Relationships part.</returns>
			/// <remarks>
			/// <para>
			/// This method creates a reference to a Relationships part. All or a subset of the relationships that are stored in a
			/// referenced Relationships part can be signed when the signature is generated.
			/// </para>
			/// <para>
			/// To sign all of the relationships in a Relationships part, call this method with the relationshipSigningOption parameter
			/// value set to <c>OPC_RELATIONSHIP_SIGN_PART</c> and the selectorSet parameter value set to <c>NULL</c>.
			/// </para>
			/// <para>
			/// To sign a subset of the relationships in a Relationships part, call this method with the relationshipSigningOption parameter
			/// value set to <c>OPC_RELATIONSHIP_SIGN_USING_SELECTORS</c> and the selectorSet parameter value set to an
			/// IOpcRelationshipSelectorSet interface pointer. To create an <c>IOpcRelationshipSelectorSet</c> interface pointer, call the
			/// CreateRelationshipSelectorSet method.
			/// </para>
			/// <para>
			/// The following table summarizes the parameter values required by this method to create a reference that indicates whether all
			/// of the relationships or a subset of the relationships (which are stored in the Relationships part to be referenced) are to
			/// be signed.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Description</term>
			/// <term>relationshipSigningOption Value</term>
			/// <term>selectorSet Value</term>
			/// </listheader>
			/// <item>
			/// <term>Sign all of the relationships in the Relationships part</term>
			/// <term>OPC_RELATIONSHIP_SIGN_PART</term>
			/// <term>NULL</term>
			/// </item>
			/// <item>
			/// <term>Sign a subset of the relationships in the Relationships part</term>
			/// <term>OPC_RELATIONSHIP_SIGN_USING_SELECTORS</term>
			/// <term>An IOpcRelationshipSelectorSet interface pointer</term>
			/// </item>
			/// </list>
			/// <para>
			/// If a subset of relationships are to be signed, the specified transform method is ignored. Instead, when the signature is
			/// generated, the first transform applied is the Relationships Transform, and the second is the
			/// <c>OPC_CANONICALIZATION_C14N</c> canonicalization method.
			/// </para>
			/// <para>
			/// When an IOpcSignatureRelationshipReference interface pointer is created and added to the set, the reference it represents is
			/// saved when the package is saved.
			/// </para>
			/// <para>
			/// Relationships that will not be signed can be removed, modified or added to the package without invalidating the signature.
			/// If a subset of relationships has been selected for signing and the subset is altered, the signature will be invalidated.
			/// </para>
			/// <para>
			/// <c>Important</c> A selected subset could be altered if the relationship type of a relationship that is added to or modified
			/// in a referenced Relationships part matches a relationship type that was used to select one or more relationships in the subset.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturerelationshipreferenceset-create HRESULT
			// Create( IOpcUri *sourceUri, LPCWSTR digestMethod, OPC_RELATIONSHIPS_SIGNING_OPTION relationshipSigningOption,
			// IOpcRelationshipSelectorSet *selectorSet, OPC_CANONICALIZATION_METHOD transformMethod, IOpcSignatureRelationshipReference
			// **relationshipReference );
			IOpcSignatureRelationshipReference Create(IOpcUri sourceUri, [MarshalAs(UnmanagedType.LPWStr)] string digestMethod, OPC_RELATIONSHIPS_SIGNING_OPTION relationshipSigningOption,
				IOpcRelationshipSelectorSet selectorSet, OPC_CANONICALIZATION_METHOD transformMethod);

			/// <summary>
			/// Creates an IOpcRelationshipSelectorSet interface pointer that is used as the selectorSet parameter value of the Create method.
			/// </summary>
			/// <returns>A new IOpcRelationshipSelectorSet interface pointer.</returns>
			/// <remarks>
			/// <para>
			/// To select a subset of the relationships (which are stored in the Relationships part to be referenced) to be signed when the
			/// signature is generated, call the Create method with the relationshipSigningOption parameter value set to
			/// <c>OPC_RELATIONSHIP_SIGN_USING_SELECTORS</c> and the selectorSet parameter value set to the IOpcRelationshipSelectorSet
			/// interface pointer created by this method.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturerelationshipreferenceset-createrelationshipselectorset
			// HRESULT CreateRelationshipSelectorSet( IOpcRelationshipSelectorSet **selectorSet );
			IOpcRelationshipSelectorSet CreateRelationshipSelectorSet();

			/// <summary>Deletes a specified IOpcSignatureRelationshipReference interface pointer from the set.</summary>
			/// <param name="relationshipReference">An IOpcSignatureRelationshipReference interface pointer to be deleted.</param>
			/// <remarks>
			/// <para>
			/// When an IOpcSignatureRelationshipReference interface pointer is deleted from the set, the reference it represents is not
			/// saved when the package is saved.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturerelationshipreferenceset-delete HRESULT
			// Delete( IOpcSignatureRelationshipReference *relationshipReference );
			void Delete(IOpcSignatureRelationshipReference relationshipReference);

			/// <summary>Gets an enumerator of IOpcSignatureRelationshipReference interface pointers in the set.</summary>
			/// <returns>A pointer to an enumerator of IOpcSignatureRelationshipReference interface pointers in the set.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsignaturerelationshipreferenceset-getenumerator HRESULT
			// GetEnumerator( IOpcSignatureRelationshipReferenceEnumerator **relationshipReferenceEnumerator );
			IOpcSignatureRelationshipReferenceEnumerator GetEnumerator();
		}

		/// <summary>Provides methods to set and access information required to generate a signature.</summary>
		/// <remarks>
		/// <para>
		/// To generate a signature, call the IOpcDigitalSignatureManager::Sign method with the signingOptions parameter value set to an
		/// <c>IOpcSigningOptions</c> interface pointer.
		/// </para>
		/// <para>To create an <c>IOpcSigningOptions</c> interface pointer, call the IOpcDigitalSignatureManager::CreateSigningOptions method.</para>
		/// <para>
		/// The caller must set a default for the digest method and signature method before generating a signature. To set a default digest
		/// method, call the SetDefaultDigestMethod method. To set a signature method, call the SetSignatureMethod method.
		/// </para>
		/// <para>
		/// To get an IOpcSignatureCustomObjectSet interface pointer, call the GetCustomObjectSet method. The interface pointers in the set
		/// represent application-specific <c>Object</c> elements.
		/// </para>
		/// <para>
		/// To get an IOpcSignatureReferenceSet interface pointer, call the GetCustomReferenceSet method. The interface pointers in the set
		/// represent references to application-specific <c>Object</c> elements or their children that will be signed when the signature is generated.
		/// </para>
		/// <para>
		/// The default location of the certificate is <c>OPC_CERTIFICATE_IN_CERTIFICATE_PART</c>. To change this value, call the
		/// SetCertificateEmbeddingOption method.
		/// </para>
		/// <para>
		/// The default format of the signing time string is <c>OPC_SIGNATURE_TIME_FORMAT_MILLISECONDS</c>. To change the format of the
		/// signing time string, call the SetTimeFormat method.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcsigningoptions
		[PInvokeData("msopc.h")]
		[ComImport, Guid("50d2d6a5-7aeb-46c0-b241-43ab0e9b407e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcSigningOptions
		{
			/// <summary>Gets the value of the <c>Id</c> attribute from the <c>Signature</c> element.</summary>
			/// <returns>A pointer to the value of the <c>Id</c> attribute, or the empty string "" if there is no <c>Id</c>.</returns>
			/// <remarks>
			/// <para>The <c>Id</c> attribute of the <c>Signature</c> element is optional.</para>
			/// <para>To set the signature Id, call the IOpcSigningOptions::SetSignatureId method.</para>
			/// <para>
			/// To access the Id before the signature is generated, call the <c>IOpcSigningOptions::GetSignatureId</c>. To access the
			/// signature Id after the signature is generated, call the IOpcDigitalSignature::GetSignatureId method.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsigningoptions-getsignatureid HRESULT GetSignatureId(
			// LPWSTR *signatureId );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetSignatureId();

			/// <summary>Sets the value of the <c>Id</c> attribute of the <c>Signature</c> element.</summary>
			/// <param name="signatureId">The value of the <c>Id</c> attribute.</param>
			/// <remarks>
			/// <para>
			/// The <c>Id</c> attribute of the <c>Signature</c> element is optional. If this method is not called, the <c>Signature</c>
			/// element will not have the <c>Id</c> attribute.
			/// </para>
			/// <para>
			/// To access the Id before the signature is generated, call the IOpcSigningOptions::GetSignatureId. To access the signature Id
			/// after the signature is generated, call the IOpcDigitalSignature::GetSignatureId method.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsigningoptions-setsignatureid HRESULT SetSignatureId(
			// LPCWSTR signatureId );
			void SetSignatureId([MarshalAs(UnmanagedType.LPWStr)] string signatureId);

			/// <summary>
			/// Gets the signature method to use to calculate and encrypt the hash value of the <c>SignedInfo</c> element, which will be
			/// serialized as the <c>SignatureValue</c> element of the signature.
			/// </summary>
			/// <returns>
			/// A pointer to the signature method to use, or the empty string "" if no method has been set using the SetSignatureMethod method.
			/// </returns>
			/// <remarks>
			/// <para>To set the signature method, call the IOpcSigningOptions::SetSignatureMethod method.</para>
			/// <para>
			/// To access the signature method before the signature is generated, call the <c>IOpcSigningOptions::GetSignatureMethod</c>. To
			/// access the signature method after the signature is generated, call the IOpcDigitalSignature::GetSignatureMethod method.
			/// </para>
			/// <para>
			/// <c>Important</c> A valid signature method must be set before the signature is generated by calling the
			/// IOpcDigitalSignatureManager::Sign method.
			/// </para>
			/// <para>
			/// When a signature is generated it is serialized as signature markup. The signature method is used to calculate the value in
			/// the <c>SignatureValue</c> element in the signature markup.
			/// </para>
			/// <para>
			/// When a signature is validated, the signature method is used to recalculate that value, and the recalculated value is
			/// compared to the value in the <c>SignatureValue</c> element in the signature markup.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsigningoptions-getsignaturemethod HRESULT
			// GetSignatureMethod( LPWSTR *signatureMethod );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetSignatureMethod();

			/// <summary>
			/// Sets the signature method to use to calculate and encrypt the hash value of the <c>SignedInfo</c> element, which will be
			/// contained in the <c>SignatureValue</c> element of the signature.
			/// </summary>
			/// <param name="signatureMethod">The signature method to use.</param>
			/// <remarks>
			/// <para>
			/// To access the signature method before the signature is generated, call the IOpcSigningOptions::GetSignatureMethod. To access
			/// the signature method after the signature is generated, call the IOpcDigitalSignature::GetSignatureMethod method.
			/// </para>
			/// <para>
			/// <c>Important</c> A valid signature method must be set before the signature is generated by calling the
			/// IOpcDigitalSignatureManager::Sign method.
			/// </para>
			/// <para>
			/// When a signature is generated it is serialized as signature markup. The signature method is used to calculate the value in
			/// the <c>SignatureValue</c> element in the signature markup.
			/// </para>
			/// <para>
			/// When a signature is validated, the signature method is used to recalculate that value, and the recalculated value is
			/// compared to the value in the <c>SignatureValue</c> element in the signature markup.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsigningoptions-setsignaturemethod HRESULT
			// SetSignatureMethod( LPCWSTR signatureMethod );
			void SetSignatureMethod([MarshalAs(UnmanagedType.LPWStr)] string signatureMethod);

			/// <summary>Gets the default digest method that will be used to compute digest values for objects to be signed.</summary>
			/// <returns>
			/// A pointer to the default digest method, or the empty string "" if a default has not been set using the
			/// SetDefaultDigestMethod method.
			/// </returns>
			/// <remarks>
			/// <para>To set the default digest method, call the IOpcSigningOptions::SetDefaultDigestMethod method.</para>
			/// <para>
			/// <c>Important</c> The default digest method must be set before the signature is generated by calling the
			/// IOpcDigitalSignatureManager::Sign method.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsigningoptions-getdefaultdigestmethod HRESULT
			// GetDefaultDigestMethod( LPWSTR *digestMethod );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetDefaultDigestMethod();

			/// <summary>Sets the default digest method that will be used to compute digest values for objects to be signed.</summary>
			/// <param name="digestMethod">The default digest method.</param>
			/// <remarks>
			/// <para>To access the default digest method before the signature is generated, call the IOpcSigningOptions::GetDefaultDigestMethod.</para>
			/// <para>
			/// <c>Important</c> The default digest method for entities to be signed must be set before the signature is generated by
			/// calling the IOpcDigitalSignatureManager::Sign method.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsigningoptions-setdefaultdigestmethod HRESULT
			// SetDefaultDigestMethod( LPCWSTR digestMethod );
			void SetDefaultDigestMethod([MarshalAs(UnmanagedType.LPWStr)] string digestMethod);

			/// <summary>Gets a value that specifies the storage location in the package of the certificate to be used for the signature.</summary>
			/// <returns>A value that specifies the location of the certificate.</returns>
			/// <remarks>
			/// <para>
			/// The default location of the certificate is <c>OPC_CERTIFICATE_IN_CERTIFICATE_PART</c>. To change this value, call the
			/// IOpcSigningOptions::SetCertificateEmbeddingOption method.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsigningoptions-getcertificateembeddingoption HRESULT
			// GetCertificateEmbeddingOption( OPC_CERTIFICATE_EMBEDDING_OPTION *embeddingOption );
			OPC_CERTIFICATE_EMBEDDING_OPTION GetCertificateEmbeddingOption();

			/// <summary>Set the storage location of the certificate to be used for the signature.</summary>
			/// <param name="embeddingOption">The OPC_CERTIFICATE_EMBEDDING_OPTION value that describes the location of the certificate.</param>
			/// <remarks>
			/// <para>
			/// This method changes the location of the certificate from the default location, <c>OPC_CERTIFICATE_IN_CERTIFICATE_PART</c>,
			/// to a location that is specified by the caller.
			/// </para>
			/// <para>
			/// To access the value that describes the certificate location, call the IOpcSigningOptions::GetCertificateEmbeddingOption method.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsigningoptions-setcertificateembeddingoption HRESULT
			// SetCertificateEmbeddingOption( OPC_CERTIFICATE_EMBEDDING_OPTION embeddingOption );
			void SetCertificateEmbeddingOption(OPC_CERTIFICATE_EMBEDDING_OPTION embeddingOption);

			/// <summary>Gets the format of the string retrieved by the IOpcDigitalSignature::GetSigningTime method.</summary>
			/// <returns>The value that describes the format of the signingTime parameter of GetSigningTime.</returns>
			/// <remarks>
			/// <para>
			/// The default format of the signing time string is <c>OPC_SIGNATURE_TIME_FORMAT_MILLISECONDS</c>. To change the format of the
			/// signing time string, call the IOpcSigningOptions::SetTimeFormat method.
			/// </para>
			/// <para>
			/// To access the format of the signing time string after the signature has been generated, call the
			/// IOpcDigitalSignature::GetTimeFormat method.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsigningoptions-gettimeformat HRESULT GetTimeFormat(
			// OPC_SIGNATURE_TIME_FORMAT *timeFormat );
			OPC_SIGNATURE_TIME_FORMAT GetTimeFormat();

			/// <summary>Sets the format of the string retrieved by the IOpcDigitalSignature::GetSigningTime method.</summary>
			/// <param name="timeFormat">
			/// The value that describes the format of the string retrieved by the IOpcDigitalSignature::GetSigningTime method.
			/// </param>
			/// <remarks>
			/// <para>
			/// This method changes the format of the signing time string from the default format,
			/// <c>OPC_SIGNATURE_TIME_FORMAT_MILLISECONDS</c>, to a format that is specified by the caller.
			/// </para>
			/// <para>
			/// To access the format of the signing time string before the signature is generated, call the
			/// IOpcSigningOptions::GetTimeFormat method. To access the format after the signature has been generated, call the
			/// IOpcDigitalSignature::GetTimeFormat method.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsigningoptions-settimeformat HRESULT SetTimeFormat(
			// OPC_SIGNATURE_TIME_FORMAT timeFormat );
			void SetTimeFormat(OPC_SIGNATURE_TIME_FORMAT timeFormat);

			/// <summary>Gets an IOpcSignaturePartReferenceSet interface.</summary>
			/// <returns>An IOpcSignaturePartReferenceSet interface pointers.</returns>
			/// <remarks>
			/// <para>
			/// This method gets an IOpcSignaturePartReferenceSet interface pointer that provides methods enabling the creation and deletion
			/// of the IOpcSignaturePartReference interface pointers in the set. The <c>IOpcSignaturePartReference</c> interface pointers
			/// represent references to parts to be signed.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsigningoptions-getsignaturepartreferenceset HRESULT
			// GetSignaturePartReferenceSet( IOpcSignaturePartReferenceSet **partReferenceSet );
			IOpcSignaturePartReferenceSet GetSignaturePartReferenceSet();

			/// <summary>Gets an IOpcSignatureRelationshipReferenceSet interface pointer.</summary>
			/// <returns>An IOpcSignatureRelationshipReferenceSet interface pointer.</returns>
			/// <remarks>
			/// <para>
			/// This method gets an IOpcSignatureRelationshipReferenceSet interface pointer that provides methods enabling the creation and
			/// deletion of the IOpcSignaturePartReference interface pointers in the set. The IOpcSignatureRelationshipReference interface
			/// pointers represent references to Relationships parts that contain relationships to be signed.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsigningoptions-getsignaturerelationshipreferenceset
			// HRESULT GetSignatureRelationshipReferenceSet( IOpcSignatureRelationshipReferenceSet **relationshipReferenceSet );
			IOpcSignatureRelationshipReferenceSet GetSignatureRelationshipReferenceSet();

			/// <summary>Gets an IOpcSignatureCustomObjectSet interface.</summary>
			/// <returns>A pointer to an IOpcSignatureCustomObjectSet.</returns>
			/// <remarks>
			/// <para>
			/// This method gets an IOpcSignatureCustomObjectSet interface pointer that provides methods enabling the creation and deletion
			/// of the IOpcSignatureCustomObject interface pointers in the set. The <c>IOpcSignatureCustomObject</c> interface pointers
			/// represent application-specific <c>Object</c> elements which are serialized in the signature markup when the signature is generated.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsigningoptions-getcustomobjectset HRESULT
			// GetCustomObjectSet( IOpcSignatureCustomObjectSet **customObjectSet );
			IOpcSignatureCustomObjectSet GetCustomObjectSet();

			/// <summary>Gets an IOpcSignatureReferenceSet interface pointer.</summary>
			/// <returns>A pointer to an IOpcSignatureReferenceSet.</returns>
			/// <remarks>
			/// <para>
			/// This method gets an IOpcSignatureReferenceSet interface pointer that provides methods enabling the creation and deletion of
			/// the IOpcSignatureReference interface pointers in the set. The <c>IOpcSignatureReference</c> interface pointers represent
			/// references to XML elements to be signed.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsigningoptions-getcustomreferenceset HRESULT
			// GetCustomReferenceSet( IOpcSignatureReferenceSet **customReferenceSet );
			IOpcSignatureReferenceSet GetCustomReferenceSet();

			/// <summary>Gets an IOpcCertificateSet interface pointer.</summary>
			/// <returns>An IOpcCertificateSet interface pointer.</returns>
			/// <remarks>
			/// <para>
			/// This method gets a set that provides methods enabling the addition and removal of certificates from a certificate chain that
			/// will be associated with the signature when it is generated.
			/// </para>
			/// <para>
			/// Do not include the certificate use to generate the signature in this set. This certificate, the signer certificate, is
			/// required for signature generation. To generate the signature, call the IOpcDigitalSignatureManager::Sign method with the
			/// certificate parameter value set to a pointer to the signer certificate.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsigningoptions-getcertificateset HRESULT
			// GetCertificateSet( IOpcCertificateSet **certificateSet );
			IOpcCertificateSet GetCertificateSet();

			/// <summary>Gets the part name of the signature part where the signature markup will be stored.</summary>
			/// <returns>
			/// An IOpcPartUri interface pointer that represents the part name of the part where the signature markup is stored, or
			/// <c>NULL</c> if the part name has not been set by a call to the SetSignaturePartName method.
			/// </returns>
			/// <remarks>
			/// <para>
			/// To set the part name of the signature part that stores the signature markup, call the
			/// IOpcSigningOptions::SetSignaturePartName method.
			/// </para>
			/// <para>
			/// To access the signature part name after the signature is generated, call the IOpcDigitalSignature::GetSignaturePartName method.
			/// </para>
			/// <para>The signature part that stores signature markup is specific to the signature.</para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsigningoptions-getsignaturepartname HRESULT
			// GetSignaturePartName( IOpcPartUri **signaturePartName );
			IOpcPartUri GetSignaturePartName();

			/// <summary>Sets the part name of the signature part where the signature markup will be stored.</summary>
			/// <param name="signaturePartName">
			/// An IOpcPartUri interface pointer that represents the part name of the part where the signature markup is stored, or
			/// <c>NULL</c> to generate a part name when the signature is created.
			/// </param>
			/// <remarks>
			/// <para>
			/// Until the signature is generated, the part name of the signature part that stores the signature markup can be changed. To
			/// set a new part name, call this method with the signaturePartName parameter value set to an IOpcPartUri interface pointer
			/// that represents the new name. To clear an existing part name, set the signaturePartName parameter value to <c>NULL</c>.
			/// </para>
			/// <para>
			/// To access the signature part name before the signature is generated, call the IOpcSigningOptions::GetSignaturePartName. To
			/// access the signature part name after the signature is generated, call the IOpcDigitalSignature::GetSignaturePartName method.
			/// </para>
			/// <para>The signature part that stores signature markup is specific to the signature.</para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcsigningoptions-setsignaturepartname HRESULT
			// SetSignaturePartName( IOpcPartUri *signaturePartName );
			void SetSignaturePartName(IOpcPartUri signaturePartName);
		}

		/// <summary>Represents the URI of the package root or of a part that is relative to the package root.</summary>
		/// <remarks>
		/// <para>Support on Previous Windows Versions</para>
		/// <para>
		/// The behavior and performance of this interface is the same on all supported Windows versions. For more information, see the
		/// Getting Started with the Packaging API, and Platform Update for Windows Vista.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcuri
		[PInvokeData("msopc.h", MSDNShortId = "35ce7946-f7e7-4ac3-852f-e3fcca23d6d4")]
		[ComImport, Guid("BC9C1B9B-D62C-49EB-AEF0-3B4E0B28EBED"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpcUri : IUri
		{
			/// <summary>Returns the specified Uniform Resource Identifier (URI) property value in a new <c>BSTR</c>.</summary>
			/// <param name="uriProp">
			/// <para>[in]</para>
			/// <para>A value from the <c>Uri_PROPERTY</c> enumeration.</para>
			/// </param>
			/// <param name="pbstrProperty">
			/// <para>[out]</para>
			/// <para>Address of a <c>BSTR</c> that receives the property value.</para>
			/// </param>
			/// <param name="dwFlags">
			/// <para>[in]</para>
			/// <para>One of the following property-specific flags, or zero.</para>
			/// <para><c>Uri_DISPLAY_NO_FRAGMENT</c> (0x00000001)</para>
			/// <para><c>Uri_PROPERTY_DISPLAY_URI</c>: Exclude the fragment portion of the URI, if any.</para>
			/// <para><c>Uri_PUNYCODE_IDN_HOST</c> (0x00000002)</para>
			/// <para>
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DOMAIN</c>, <c>Uri_PROPERTY_HOST</c>: If the URI is an IDN, always display
			/// the hostname encoded as punycode.
			/// </para>
			/// <para><c>Uri_DISPLAY_IDN_HOST</c> (0x00000004)</para>
			/// <para>
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DOMAIN</c>, <c>Uri_PROPERTY_HOST</c>: Display the hostname in punycode or
			/// Unicode as it would appear in the <c>Uri_PROPERTY_DISPLAY_URI</c> property.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para><c>IUri::GetPropertyBSTR</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// The uriProp parameter must be a string property. This method will fail if the specified property isn't a <c>BSTR</c> property.
			/// </para>
			/// <para>
			/// The pbstrProperty parameter will be set to a new <c>BSTR</c> containing the value of the specified string property. The
			/// caller should use SysFreeString to free the string.
			/// </para>
			/// <para>This method will return and set pbstrProperty to an empty string if the URI doesn't contain the specified property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775026(v=vs.85)
			// HRESULT GetPropertyBSTR( [in] Uri_PROPERTY uriProp, [out] BSTR *pbstrProperty, [in] DWORD dwFlags );
			new void GetPropertyBSTR([In] Uri_PROPERTY uriProp, [MarshalAs(UnmanagedType.BStr)] out string pbstrProperty, [In] Uri_DISPLAY dwFlags);

			/// <summary>
			/// Returns the string length of the specified Uniform Resource Identifier (URI) property. Call this function if you want the
			/// length but don't necessarily want to create a new <c>BSTR</c>.
			/// </summary>
			/// <param name="uriProp">
			/// <para>[in]</para>
			/// <para>A value from the <c>Uri_PROPERTY</c> enumeration.</para>
			/// </param>
			/// <param name="pcchProperty">
			/// <para>[out]</para>
			/// <para>
			/// Address of a <c>DWORD</c> that is set to the length of the value of the string property excluding the <c>NULL</c> terminator.
			/// </para>
			/// </param>
			/// <param name="dwFlags">
			/// <para>[in]</para>
			/// <para>One of the following property-specific flags, or zero.</para>
			/// <para><c>Uri_DISPLAY_NO_FRAGMENT</c> (0x00000001)</para>
			/// <para><c>Uri_PROPERTY_DISPLAY_URI</c>: Exclude the fragment portion of the URI, if any.</para>
			/// <para><c>Uri_PUNYCODE_IDN_HOST</c> (0x00000002)</para>
			/// <para>
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DOMAIN</c>, <c>Uri_PROPERTY_HOST</c>: If the URI is an IDN, always display
			/// the hostname encoded as punycode.
			/// </para>
			/// <para><c>Uri_DISPLAY_IDN_HOST</c> (0x00000004)</para>
			/// <para>
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DOMAIN</c>, <c>Uri_PROPERTY_HOST</c>: Display the hostname in punycode or
			/// Unicode as it would appear in the <c>Uri_PROPERTY_DISPLAY_URI</c> property.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para><c>IUri::GetPropertyLength</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// The uriProp parameter must be a string property. This method will fail if the specified property isn't a <c>BSTR</c> property.
			/// </para>
			/// <para>This method will return and set pcchProperty to if the URI doesn't contain the specified property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775028(v=vs.85)
			// HRESULT GetPropertyLength( [in] Uri_PROPERTY uriProp, [out] DWORD *pcchProperty, [in] DWORD dwFlags );
			new void GetPropertyLength([In] Uri_PROPERTY uriProp, out uint pcchProperty, [In] Uri_DISPLAY dwFlags);

			/// <summary>Returns the specified numeric Uniform Resource Identifier (URI) property value.</summary>
			/// <param name="uriProp">
			/// <para>[in]</para>
			/// <para>A value from the <c>Uri_PROPERTY</c> enumeration.</para>
			/// </param>
			/// <param name="pdwProperty">Address of a DWORD that is set to the value of the specified property.</param>
			/// <param name="dwFlags">Property-specific flags. Must be set to 0.</param>
			/// <remarks>
			/// <para><c>IUri::GetPropertyDWORD</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// The uriProp parameter must be a numeric property. This method will fail if the specified property isn't a <c>DWORD</c> property.
			/// </para>
			/// <para>This method will return and set pdwProperty to if the specified property doesn't exist in the URI.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775027(v=vs.85)
			// HRESULT GetPropertyDWORD( [in] Uri_PROPERTY uriProp, [out] DWORD *pdwProperty, [in] DWORD dwFlags );
			new void GetPropertyDWORD([In] Uri_PROPERTY uriProp, out uint pdwProperty, [In] uint dwFlags);

			/// <summary>Determines if the specified property exists in the Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a BOOL value. Set to TRUE if the specified property exists in the URI.</returns>
			/// <remarks><c>IUri::HasProperty</c> was introduced in Windows Internet Explorer 7.</remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775036(v=vs.85)
			// HRESULT HasProperty( [in] Uri_PROPERTY uriProp, [out] BOOL *pfHasProperty );
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool HasProperty([In] Uri_PROPERTY uriProp);

			/// <summary>Returns the entire canonicalized Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetAbsoluteUri</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c> property.
			/// </para>
			/// <para>This property is not defined for relative URIs.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775013%28v%3dvs.85%29
			// HRESULT GetAbsoluteUri( [out] BSTR *pbstrAbsoluteUri );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetAbsoluteUri();

			/// <summary>Returns the user name, password, domain, and port.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetAuthority</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_AUTHORITY</c> property.
			/// </para>
			/// <para>
			/// If user name and password are not specified, the separator characters (: and @) are removed. The trailing colon is also
			/// removed if the port number is not specified or is the default for the protocol scheme.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775014(v=vs.85)
			// HRESULT GetAuthority( [out] BSTR *pbstrAuthority );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetAuthority();

			/// <summary>Returns a Uniform Resource Identifier (URI) that can be used for display purposes.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetDisplayUri</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// The display URI combines protocol scheme, fully qualified domain name, port number (if not the default for the scheme), full
			/// resource path, query string, and fragment.
			/// </para>
			/// <para>
			/// <c>Note</c> The display URI may have additional formatting applied to it, such that the string produced by
			/// <c>IUri::GetDisplayUri</c> isn't necessarily a valid URI. For this reason, and since the userinfo is not present, the
			/// display URI should be used for viewing only; it should not be used for edit by the user, or as a form of transfer for URIs
			/// inside or between applications.
			/// </para>
			/// <para>
			/// If the scheme is known (for example, http, ftp, or file) then the display URI will hide credentials. However, if the URI
			/// uses an unknown scheme and supplies user name and password, the display URI will also contain the user name and password.
			/// </para>
			/// <para>
			/// <c>Security Warning:</c> Storing sensitive information as clear text in a URI is not recommended. According to RFC3986:
			/// Uniform Resource Identifier (URI), Generic Syntax, Section 7.5, "A password appearing within the userinfo component is
			/// deprecated and should be considered an error except in those rare cases where the 'password' parameter is intended to be public."
			/// </para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_DISPLAY_URI</c> property and no flags.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775015(v=vs.85)
			// HRESULT GetDisplayUri( [out] BSTR *pbstrDisplayString );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetDisplayUri();

			/// <summary>Returns the domain name (including top-level domain) only.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetDomain</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the <c>Uri_PROPERTY_DOMAIN</c> property.
			/// </para>
			/// <para>
			/// If the URL contains only a plain hostname (for example, "http://example/") or a public suffix (for example,
			/// "http://co.uk/"), then <c>IUri::GetDomain</c> returns <c>NULL</c>. Use <c>IUri::GetHost</c> instead.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775016(v=vs.85)
			// HRESULT GetDomain( [out] BSTR *pbstrDomain );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetDomain();

			/// <summary>Returns the file name extension of the resource.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetExtension</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_EXTENSION</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775017(v=vs.85)
			// HRESULT GetExtension( [out] BSTR *pbstrExtension );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetExtension();

			/// <summary>Returns the text following a fragment marker (#), including the fragment marker itself.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetFragment</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_FRAGMENT</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775018(v=vs.85)
			// HRESULT GetFragment( [out] BSTR *pbstrFragment );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetFragment();

			/// <summary>Returns the fully qualified domain name.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetHost</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the <c>Uri_PROPERTY_HOST</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775019(v=vs.85)
			// HRESULT GetHost( [out] BSTR *pbstrHost );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetHost();

			/// <summary>Returns the password, as parsed from the Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetPassword</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// <c>Security Warning:</c> Storing sensitive information as clear text in a URI is not recommended. According to RFC3986:
			/// Uniform Resource Identifier (URI), Generic Syntax, Section 7.5, "A password appearing within the userinfo component is
			/// deprecated and should be considered an error except in those rare cases where the 'password' parameter is intended to be public."
			/// </para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_PASSWORD</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775021(v=vs.85)
			// HRESULT GetPassword( [out] BSTR *pbstrPassword );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetPassword();

			/// <summary>Returns the path and resource name.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetPath</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the <c>Uri_PROPERTY_PATH</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775022(v=vs.85)
			// HRESULT GetPath( [out] BSTR *pbstrPath );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetPath();

			/// <summary>Returns the path, resource name, and query string.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetPathAndQuery</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_PATH_AND_QUERY</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775023(v=vs.85)
			// HRESULT GetPathAndQuery( [out] BSTR *pbstrPathAndQuery );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetPathAndQuery();

			/// <summary>Returns the query string.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetQuery</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the <c>Uri_PROPERTY_QUERY</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775029(v=vs.85)
			// HRESULT GetQuery( [out] BSTR *pbstrQuery );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetQuery();

			/// <summary>Returns the entire original Uniform Resource Identifier (URI) input string.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetRawUri</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_RAW_URI</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775030(v=vs.85)
			// HRESULT GetRawUri( [out] BSTR *pbstrRawUri );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetRawUri();

			/// <summary>Returns the protocol scheme name.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetSchemeName</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_SCHEME_NAME</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775032(v=vs.85)
			// HRESULT GetSchemeName( [out] BSTR *pbstrSchemeName );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetSchemeName();

			/// <summary>Returns the user name and password, as parsed from the Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetUserInfo</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// <c>Security Warning:</c> Storing sensitive information as clear text in a URI is not recommended. According to RFC3986:
			/// Uniform Resource Identifier (URI), Generic Syntax, Section 7.5, "A password appearing within the userinfo component is
			/// deprecated and should be considered an error except in those rare cases where the 'password' parameter is intended to be public."
			/// </para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_USER_INFO</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775033(v=vs.85)
			// HRESULT GetUserInfo( [out] BSTR *pbstrUserInfo );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetUserInfo();

			/// <summary>Returns the user name as parsed from the Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_USER_NAME</c> property.
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775034(v=vs.85)
			// HRESULT GetUserName( [out] BSTR *pbstrUserName );
			[return: MarshalAs(UnmanagedType.BStr)]
			new string GetUserName();

			/// <summary>Returns a value from the <c>Uri_HOST_TYPE</c> enumeration.</summary>
			/// <returns>Address of a DWORD that receives a value from the Uri_HOST_TYPE enumeration.</returns>
			/// <remarks>
			/// <para><c>IUri::GetHostType</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyDWORD</c> with the
			/// <c>Uri_PROPERTY_HOST_TYPE</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775020(v=vs.85)
			// HRESULT GetHostType( [out] DWORD *pdwHostType );
			new Uri_HOST_TYPE GetHostType();

			/// <summary>Returns the port number.</summary>
			/// <returns>Address of a DWORD that receives the port number value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetPort</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyDWORD</c> with the <c>Uri_PROPERTY_PORT</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775024(v=vs.85)
			// HRESULT GetPort( [out] DWORD *pdwPort );
			new uint GetPort();

			/// <summary>Returns a value from the URL_SCHEME enumeration.</summary>
			/// <returns>Address of a DWORD that receives a value from the URL_SCHEME enumeration.</returns>
			/// <remarks>
			/// <para><c>IUri::GetScheme</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyDWORD</c> with the
			/// <c>Uri_PROPERTY_SCHEME</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775031(v=vs.85)
			// HRESULT GetScheme( [out] DWORD *pdwScheme );
			new URL_SCHEME GetScheme();

			/// <summary>This method is not implemented.</summary>
			/// <returns/>
			new URLZONE GetZone();

			/// <summary>Returns a bitmap of flags that indicate which Uniform Resource Identifier (URI) properties have been set.</summary>
			/// <returns>
			/// <para>[out]</para>
			/// <para>Address of a <c>DWORD</c> that receives a combination of the following flags:</para>
			/// <para><c>Uri_HAS_ABSOLUTE_URI</c> (0x00000000)</para>
			/// <para><c>Uri_PROPERTY_ABSOLUTE_URI</c> exists.</para>
			/// <para><c>Uri_HAS_AUTHORITY</c> (0x00000001)</para>
			/// <para><c>Uri_PROPERTY_AUTHORITY</c> exists.</para>
			/// <para><c>Uri_HAS_DISPLAY_URI</c> (0x00000002)</para>
			/// <para><c>Uri_PROPERTY_DISPLAY_URI</c> exists.</para>
			/// <para><c>Uri_HAS_DOMAIN</c> (0x00000004)</para>
			/// <para><c>Uri_PROPERTY_DOMAIN</c> exists.</para>
			/// <para><c>Uri_HAS_EXTENSION</c> (0x00000008)</para>
			/// <para><c>Uri_PROPERTY_EXTENSION</c> exists.</para>
			/// <para><c>Uri_HAS_FRAGMENT</c> (0x00000010)</para>
			/// <para><c>Uri_PROPERTY_FRAGMENT</c> exists.</para>
			/// <para><c>Uri_HAS_HOST</c> (0x00000020)</para>
			/// <para><c>Uri_PROPERTY_HOST</c> exists.</para>
			/// <para><c>Uri_HAS_HOST_TYPE</c> (0x00004000)</para>
			/// <para><c>Uri_PROPERTY_HOST_TYPE</c> exists.</para>
			/// <para><c>Uri_HAS_PASSWORD</c> (0x00000040)</para>
			/// <para><c>Uri_PROPERTY_PASSWORD</c> exists.</para>
			/// <para><c>Uri_HAS_PATH</c> (0x00000080)</para>
			/// <para><c>Uri_PROPERTY_PATH</c> exists.</para>
			/// <para><c>Uri_HAS_PATH_AND_QUERY</c> (0x00001000)</para>
			/// <para><c>Uri_PROPERTY_PATH_AND_QUERY</c> exists.</para>
			/// <para><c>Uri_HAS_PORT</c> (0x00008000)</para>
			/// <para><c>Uri_PROPERTY_PORT</c> exists.</para>
			/// <para><c>Uri_HAS_QUERY</c> (0x00000100)</para>
			/// <para><c>Uri_PROPERTY_QUERY</c> exists.</para>
			/// <para><c>Uri_HAS_RAW_URI</c> (0x00000200)</para>
			/// <para><c>Uri_PROPERTY_RAW_URI</c> exists.</para>
			/// <para><c>Uri_HAS_SCHEME</c> (0x00010000)</para>
			/// <para><c>Uri_PROPERTY_SCHEME</c> exists.</para>
			/// <para><c>Uri_HAS_SCHEME_NAME</c> (0x00000400)</para>
			/// <para><c>Uri_PROPERTY_SCHEME_NAME</c> exists.</para>
			/// <para><c>Uri_HAS_USER_NAME</c> (0x00000800)</para>
			/// <para><c>Uri_PROPERTY_USER_NAME</c> exists.</para>
			/// <para><c>Uri_HAS_USER_INFO</c> (0x00002000)</para>
			/// <para><c>Uri_PROPERTY_USER_INFO</c> exists.</para>
			/// <para><c>Uri_HAS_ZONE</c> (0x00020000)</para>
			/// <para><c>Uri_PROPERTY_ZONE</c> exists.</para>
			/// </returns>
			/// <remarks><c>IUri::GetProperties</c> was introduced in Windows Internet Explorer 7.</remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775025(v=vs.85)
			// HRESULT GetProperties( [out] LPDWORD pdwFlags );
			new Uri_HAS GetProperties();

			/// <summary>Compares the logical content of two <c>IUri</c> objects.</summary>
			/// <returns>Address of a BOOL that is set to TRUE if the logical content of pUri is the same.</returns>
			/// <remarks>
			/// <para><c>IUri::IsEqual</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>The comparison is case-insensitive. Comparing an <c>IUri</c> to itself will always return <c>TRUE</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775037(v=vs.85)
			// HRESULT IsEqual( [in] IUri *pUri, [out] BOOL *pfEqual );
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool IsEqual([In] IUri pUri);

			/// <summary>
			/// Gets the part name of the Relationships part that stores relationships that have the source URI represented by the current
			/// OPC URI object.
			/// </summary>
			/// <returns>
			/// A pointer to the IOpcPartUri interface of the part URI object that represents the part name of the Relationships part. The
			/// source URI of the relationships stored in this Relationships part is represented by the current OPC URI object.
			/// </returns>
			/// <remarks>
			/// <para>The following table shows Relationships part URIs for some OPC URIs.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>OPC URI</term>
			/// <term>Relationships Part Name</term>
			/// <term>Return Value</term>
			/// </listheader>
			/// <item>
			/// <term>/mydoc/images/picture.jpg</term>
			/// <term>/mydoc/images/_rels/picture.jpg.rels</term>
			/// <term>S_OK</term>
			/// </item>
			/// <item>
			/// <term>/</term>
			/// <term>/_rels/.rels</term>
			/// <term>S_OK</term>
			/// </item>
			/// <item>
			/// <term>/mydoc/images/_rels/picture.jpg.rels</term>
			/// <term>Undefined</term>
			/// <term>OPC_E_NONCONFORMING_URI</term>
			/// </item>
			/// </list>
			/// <para>Support on Previous Windows Versions</para>
			/// <para>
			/// The behavior and performance of this method is the same on all supported Windows versions. For more information, see Getting
			/// Started with the Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcuri-getrelationshipsparturi HRESULT
			// GetRelationshipsPartUri( IOpcPartUri **relationshipPartUri );
			IOpcPartUri GetRelationshipsPartUri();

			/// <summary>Forms a relative URI for a specified part, relative to the URI represented by the current OPC URI object.</summary>
			/// <param name="targetPartUri">
			/// A pointer to the IOpcPartUri interface of the part URI object that represents the part name from which the relative URI is formed.
			/// </param>
			/// <returns>A pointer to the IUri interface of the URI of the part, relative to the current OPC URI object.</returns>
			/// <remarks>
			/// <para>Example input and output:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Input IOpcPartUri represents</term>
			/// <term>Current IOpcUri represents</term>
			/// <term>Returned relative IUri represents</term>
			/// </listheader>
			/// <item>
			/// <term>/mydoc/markup/page.xml</term>
			/// <term>/mydoc/markup/picture.jpg</term>
			/// <term>picture.jpg</term>
			/// </item>
			/// <item>
			/// <term>/mydoc/markup/page.xml</term>
			/// <term>/mydoc/picture.jpg</term>
			/// <term>../picture.jpg</term>
			/// </item>
			/// <item>
			/// <term>/mydoc/markup/page.xml</term>
			/// <term>/mydoc/images/pictures.jpg</term>
			/// <term>../images/pictures.jpg</term>
			/// </item>
			/// </list>
			/// <para>Support on Previous Windows Versions</para>
			/// <para>
			/// The behavior and performance of this method is the same on all supported Windows versions. For more information, see Getting
			/// Started with the Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcuri-getrelativeuri HRESULT GetRelativeUri( IOpcPartUri
			// *targetPartUri, IUri **relativeUri );
			IUri GetRelativeUri([In] IOpcPartUri targetPartUri);

			/// <summary>
			/// Forms the part name of the part that is referenced by the specified relative URI. The specified relative URI of the part is
			/// resolved against the URI represented as the current OPC URI object.
			/// </summary>
			/// <param name="relativeUri">
			/// <para>A pointer to the IUri interface of the relative URI of the part.</para>
			/// <para>
			/// To form the part URI object that represents the part name, this input URI is resolved against the URI represented as the
			/// current OPC URI object. Therefore, the input URI must be relative to the URI represented by the current OPC URI object.
			/// </para>
			/// <para>
			/// This URI may include a fragment component; however, the fragment will be ignored and will not be included in the part name
			/// to be formed. A fragment component is preceded by a '#', as described in RFC 3986: URI Generic Syntax.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>A pointer to the IOpcPartUri interface of the part URI object that represents the part name.</para>
			/// <para>
			/// The part URI object is formed by resolving the relative URI in relativeUri against the URI represented by the current OPC
			/// URI object.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>Example input and output:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Input relative IUri</term>
			/// <term>Current IOpcUri</term>
			/// <term>Formed IOpcPartUri</term>
			/// </listheader>
			/// <item>
			/// <term>picture.jpg</term>
			/// <term>/mydoc/markup/page.xml</term>
			/// <term>/mydoc/markup/picture.jpg</term>
			/// </item>
			/// <item>
			/// <term>../picture.jpg</term>
			/// <term>/mydoc/markup/page.xml</term>
			/// <term>/mydoc/picture.jpg</term>
			/// </item>
			/// <item>
			/// <term>../../images/picture.jpg</term>
			/// <term>/mydoc/page.xml</term>
			/// <term>/images/picture.jpg</term>
			/// </item>
			/// </list>
			/// <para>
			/// For information about how to use this method to help resolve a part name, see Resolving a Part Name from a Target URI.
			/// </para>
			/// <para>Support on Previous Windows Versions</para>
			/// <para>
			/// The behavior and performance of this method is the same on all supported Windows versions. For more information, see Getting
			/// Started with the Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcuri-combineparturi HRESULT CombinePartUri( IUri
			// *relativeUri, IOpcPartUri **combinedUri );
			IOpcPartUri CombinePartUri([In] IUri relativeUri);
		}

		/// <summary>CoClass for IOpcFactory.</summary>
		[PInvokeData("msopc.h", MSDNShortId = "0a265a0a-c109-4afc-a0ad-d3ee31757aa1")]
		[ComImport, ClassInterface(ClassInterfaceType.None), Guid("6B2D6BA0-9F3E-4f27-920B-313CC426A39E")]
		public class OpcFactory { }

		/// <summary>Creates an <see cref="IEnumerator{T}"/> instance from one of the IOpcXXXEnumerator interface instances.</summary>
		/// <typeparam name="TEnum">
		/// The type of the enumerator interface. This interface must support the MoveNext, GetCurrent and Clone methods.
		/// </typeparam>
		/// <typeparam name="TElem">The type of the elemement interface returned as the parameter in TElem.GetCurrent.</typeparam>
		/// <seealso cref="IEnumerator{T}"/>
		public class OpcEnumerator<TEnum, TElem> : IEnumerator<TElem>
		{
			private MethodInfo getCurrent;
			private MethodInfo moveNext;
			private TEnum opcEnum;

			/// <summary>Initializes a new instance of the <see cref="OpcEnumerator{TEnum, TElem}"/> class.</summary>
			/// <param name="opcEnumerator">The opc enumerator.</param>
			/// <exception cref="ArgumentNullException">opcEnumerator</exception>
			/// <exception cref="ArgumentException">The type specified for TEnum is not a valid Opc Enumerator instance.</exception>
			public OpcEnumerator(TEnum opcEnumerator)
			{
				opcEnum = opcEnumerator ?? throw new ArgumentNullException(nameof(opcEnumerator));
				moveNext = typeof(TEnum).GetMethod("MoveNext");
				getCurrent = typeof(TEnum).GetMethod("GetCurrent");
				if (moveNext is null || getCurrent is null) throw new ArgumentException("The type specified for TEnum is not a valid Opc Enumerator instance.");
			}

			/// <summary>Gets the element in the collection at the current position of the enumerator.</summary>
			public TElem Current
			{
				get
				{
					var p = new object[] { default(TElem) };
					((HRESULT)getCurrent.Invoke(opcEnum, p)).ThrowIfFailed();
					return (TElem)p[0];
				}
			}

			/// <summary>Gets the element in the collection at the current position of the enumerator.</summary>
			object IEnumerator.Current => Current;

			/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
			public void Dispose() => Marshal.ReleaseComObject(opcEnum);

			/// <summary>Advances the enumerator to the next element of the collection.</summary>
			/// <returns>
			/// <see langword="true"/> if the enumerator was successfully advanced to the next element; <see langword="false"/> if the
			/// enumerator has passed the end of the collection.
			/// </returns>
			public bool MoveNext()
			{
				var p = new object[] { false };
				((HRESULT)moveNext.Invoke(opcEnum, p)).ThrowIfFailed();
				return (bool)p[0];
			}

			/// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
			public void Reset()
			{
				var clone = opcEnum.InvokeMethod<TEnum>("Clone");
				Marshal.ReleaseComObject(opcEnum);
				opcEnum = clone;
			}
		}
	}
}