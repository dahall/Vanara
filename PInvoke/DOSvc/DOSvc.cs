using System.Collections.Generic;
using System.Linq;
using Vanara.Extensions.Reflection;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.OleAut32;

namespace Vanara.PInvoke;

/// <summary>Items from the dosvc.dll supporting Delivery Optimization.</summary>
public static partial class DOSvc
{
	/// <summary/>
	public const string DecryptionInfo_AlgorithmName = "AlgorithmName";

	/// <summary/>
	public const string DecryptionInfo_ChainingMode = "ChainingMode";

	/// <summary/>
	public const string DecryptionInfo_EncryptionBufferSize = "EncryptionBufferSize";

	/// <summary/>
	public const string DecryptionInfo_KeyData = "KeyData";

	/// <summary/>
	public const ulong DO_LENGTH_TO_EOF = unchecked((ulong)-1L);

	/// <summary/>
	public const string IntegrityCheckInfo_HashOfHashes = "HashOfHashes";

	/// <summary/>
	public const string IntegrityCheckInfo_PiecesHashFileDigest = "PiecesHashFileDigest";

	/// <summary/>
	public const string IntegrityCheckInfo_PiecesHashFileDigestAlgorithm = "PiecesHashFileDigestAlgorithm";

	/// <summary/>
	public const string IntegrityCheckInfo_PiecesHashFileUrl = "PiecesHashFileUrl";

	/// <summary>
	/// The DeliveryOptimizationFileProperty enumeration specifies the ID of an optional property for the Delivery Optimization file. This
	/// enumeration is used in the IDeliveryOptimizationFile2 interface where the property value of type VARIANT is passed
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/delivery_optimization/deliveryoptimizationfileproperty typedef enum
	// _DeliveryOptimizationFileProperty { DOFilePropertyId_DecryptionInfo, DOFilePropertyId_IntegrityCheckInfo,
	// DOFilePropertyId_IntegrityCheckMandatory, DOFilePropertyId_DownloadSinkInterface, DOFilePropertyId_DownloadSinkFilePath,
	// DOFilePropertyId_DownloadSinkMemoryStream, DOFilePropertyId_TotalSizeBytes } DOFilePropertyId;
	[PInvokeData("Deliveryoptimization.h")]
	public enum DeliveryOptimizationFileProperty
	{
		/// <summary>
		/// The DOFilePropertyId_DecryptionInfo property ID sets decryption information in the form of a JSON string.
		/// DOFilePropertyId_DecryptionInfo is a Write only property of type VT_BSTR.
		/// </summary>
		DOFilePropertyId_DecryptionInfo,

		/// <summary>
		/// The DOFilePropertyId_IntegrityCheckInfo property ID sets the piece hash file (PHF) location, which is used by Delivery
		/// Optimization to perform runtime integrity checks on the downloaded content. DOFilePropertyId_IntegrityCheckInfo is a Write only
		/// property of type VT_BSTR.
		/// </summary>
		DOFilePropertyId_IntegrityCheckInfo,

		/// <summary>
		/// The DOFilePropertyId_IntegrityCheckMandatory property ID sets a boolean flag indicating whether usage of the PHF is mandatory. If
		/// TRUE, the download will be aborted once the integrity check is failed. DOFilePropertyId_IntegrityCheckMandatory is a Read/Write
		/// property of type VT_BOOL.
		/// </summary>
		DOFilePropertyId_IntegrityCheckMandatory,

		/// <summary>
		/// The DOFilePropertyId_DownloadSinkFilePath property ID sets a fully qualified file system location where Delivery Optimization
		/// should store the downloaded pieces. DOFilePropertyId_DownloadSinkFilePath is of type VT_BSTR.
		/// </summary>
		DOFilePropertyId_DownloadSinkFilePath,

		/// <summary>The DOFilePropertyId_DownloadSinkMemoryStream property ID is deprecated. Do not use.</summary>
		DOFilePropertyId_DownloadSinkMemoryStream,

		/// <summary>
		/// The DOFilePropertyId_TotalSizeBytes property ID specifies the total download size. DOFilePropertyId_TotalSizeBytes is of type VT_UI8.
		/// </summary>
		DOFilePropertyId_TotalSizeBytes,
	}

	/// <summary>
	/// The <c>DODownloadCostPolicy</c> enumeration specifies the ID of cost policies options associated with the
	/// <c>DODownloadProperty_CostPolicy</c> property.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/ne-deliveryoptimization-dodownloadcostpolicy typedef enum
	// _DODownloadCostPolicy { DODownloadCostPolicy_Always, DODownloadCostPolicy_Unrestricted, DODownloadCostPolicy_Standard,
	// DODownloadCostPolicy_NoRoaming, DODownloadCostPolicy_NoSurcharge, DODownloadCostPolicy_NoCellular } DODownloadCostPolicy;
	[PInvokeData("deliveryoptimization.h", MSDNShortId = "NE:deliveryoptimization._DODownloadCostPolicy")]
	public enum DODownloadCostPolicy
	{
		/// <summary>Download runs regardless of the cost.</summary>
		DODownloadCostPolicy_Always,

		/// <summary>Download runs unless imposes costs or traffic limits.</summary>
		DODownloadCostPolicy_Unrestricted,

		/// <summary>Download runs unless neither subject to a surcharge nor near exhaustion.</summary>
		DODownloadCostPolicy_Standard,

		/// <summary>Download runs unless that connectivity is subject to roaming surcharges.</summary>
		DODownloadCostPolicy_NoRoaming,

		/// <summary>Download runs unless subject to a surcharge.</summary>
		DODownloadCostPolicy_NoSurcharge,

		/// <summary>Download runs unless network is on cellular.</summary>
		DODownloadCostPolicy_NoCellular,
	}

	/// <summary>
	/// The <c>DODownloadProperty</c> enumeration specifies the ID of properties for the Delivery Optimization download operation. This
	/// enumeration is used by the <c>IDODownload</c> interface, and carried out by a VARIANT value, where the type of value is contained.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/ne-deliveryoptimization-dodownloadproperty typedef enum
	// _DODownloadProperty { DODownloadProperty_Id, DODownloadProperty_Uri, DODownloadProperty_ContentId, DODownloadProperty_DisplayName,
	// DODownloadProperty_LocalPath, DODownloadProperty_HttpCustomHeaders, DODownloadProperty_CostPolicy, DODownloadProperty_SecurityFlags,
	// DODownloadProperty_CallbackFreqPercent, DODownloadProperty_CallbackFreqSeconds, DODownloadProperty_NoProgressTimeoutSeconds,
	// DODownloadProperty_ForegroundPriority, DODownloadProperty_BlockingMode, DODownloadProperty_CallbackInterface,
	// DODownloadProperty_StreamInterface, DODownloadProperty_SecurityContext, DODownloadProperty_NetworkToken,
	// DODownloadProperty_CorrelationVector, DODownloadProperty_DecryptionInfo, DODownloadProperty_IntegrityCheckInfo,
	// DODownloadProperty_IntegrityCheckMandatory, DODownloadProperty_TotalSizeBytes, DODownloadProperty_DisallowOnCellular,
	// DODownloadProperty_HttpCustomAuthHeaders, DODownloadProperty_HttpAllowSecureToNonSecureRedirect, DODownloadProperty_NonVolatile } DODownloadProperty;
	[PInvokeData("deliveryoptimization.h", MSDNShortId = "NE:deliveryoptimization._DODownloadProperty")]
	public enum DODownloadProperty
	{
		/// <summary>Read-only. Use this property to get the ID that uniquely identifies the download. VARIANT type is VT_BSTR.</summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		DODownloadProperty_Id,

		/// <summary>
		/// <para>Use this property to set or get the remote URI path of the resource to download. This property is required only if</para>
		/// <para>DODownloadProperty_ContentId</para>
		/// <para>isn't provided. VARIANT type is VT_BSTR.</para>
		/// </summary>
		[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
		DODownloadProperty_Uri,

		/// <summary>
		/// <para>Use this property to set or get the download unique content ID. This property is required only if</para>
		/// <para>DODownloadProperty_Uri</para>
		/// <para>isn't provided. VARIANT type is VT_BSTR.</para>
		/// </summary>
		[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
		DODownloadProperty_ContentId,

		/// <summary>Optional. Use this property to set or get the download display name. VARIANT type is VT_BSTR.</summary>
		[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
		DODownloadProperty_DisplayName,

		/// <summary>
		/// <para>
		/// Use this property to set or get the local path name to save the download file. If the path does not exist, Delivery Optimization
		/// will attempt to create it under the caller's privileges. This property is required only if
		/// </para>
		/// <para>DODownloadProperty_StreamInterface</para>
		/// <para>wasn’t provided. VARIANT type is VT_BSTR.</para>
		/// </summary>
		[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
		DODownloadProperty_LocalPath,

		/// <summary>
		/// Optional. Use this property to set or get custom HTTP request headers. Delivery Optimization will include these headers during
		/// HTTP file request operations. The headers must already be formatted as standard HTTP headers. VARIANT type is VT_BSTR.
		/// </summary>
		[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
		DODownloadProperty_HttpCustomHeaders,

		/// <summary>
		/// <para>Optional. Use this property to set or get one of the</para>
		/// <para>DODownloadCostPolicy</para>
		/// <para>enumeration values. VARIANT type is VT_UI4.</para>
		/// </summary>
		[CorrespondingType(typeof(DODownloadCostPolicy), CorrespondingAction.GetSet)]
		DODownloadProperty_CostPolicy,

		/// <summary>
		/// <para>Optional write-only. Use this property to set or get the standard WinHTTP security flags (</para>
		/// <para>WINHTTP_OPTION_SECURITY_FLAGS</para>
		/// <para>). VARIANT type is VT_UI4.</para>
		/// <para>The following flags are supported:</para>
		/// <para>*</para>
		/// <para>SECURITY_FLAG_IGNORE_CERT_CN_INVALID</para>
		/// <para>. Allows an invalid common name in a certificate.</para>
		/// <para>*</para>
		/// <para>SECURITY_FLAG_IGNORE_CERT_DATE_INVALID</para>
		/// <para>. Allows an invalid certificate date.</para>
		/// <para>*</para>
		/// <para>SECURITY_FLAG_IGNORE_UNKNOWN_CA</para>
		/// <para>. Allows an invalid certificate authority.</para>
		/// <para>*</para>
		/// <para>SECURITY_FLAG_IGNORE_CERT_WRONG_USAGE</para>
		/// <para>. Allows the identity of a server to be established with a non-server certificate.</para>
		/// <para>*</para>
		/// <para>WINHTTP_ENABLE_SSL_REVOCATION</para>
		/// <para>. Allows SSL revocation. If this flag is set, the above flags will be ignored.</para>
		/// </summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
		DODownloadProperty_SecurityFlags,

		/// <summary>Optional. Use this property to set or get callback frequency based on download percentage. VARIANT type is VT_UI4.</summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
		DODownloadProperty_CallbackFreqPercent,

		/// <summary>
		/// Optional. Use this property to set or get callback frequency based on download time. The default is every one second. VARIANT
		/// type is VT_UI4.
		/// </summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
		DODownloadProperty_CallbackFreqSeconds,

		/// <summary>
		/// Optional. Use this property to set or get the download timeout length for no progress. The minimum accepted value is 60 seconds
		/// of no download activity. VARIANT type is VT_UI4.
		/// </summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
		DODownloadProperty_NoProgressTimeoutSeconds,

		/// <summary>
		/// Optional. Use this property to set or get the current download priority. VARIANT_TRUE value will bring the download to the
		/// foreground with higher priority. The default is background priority. VARIANT type is VT_BOOL.
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.GetSet)]
		DODownloadProperty_ForegroundPriority,

		/// <summary>
		/// <para>Optional. Use this property to set or get the current download blocking mode. VARIANT_TRUE value will cause</para>
		/// <para>IDODownload::Start</para>
		/// <para>to block until download is complete or error has occurred. The default is nonblocking mode. VARIANT type is VT_BOOL.</para>
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.GetSet)]
		DODownloadProperty_BlockingMode,

		/// <summary>
		/// <para>Optional. Use this property to set or get the pointer to</para>
		/// <para>IDODownloadStatusCallback</para>
		/// <para>interface used for download callbacks. VARIANT type is VT_UNKNOWN.</para>
		/// </summary>
		[CorrespondingType(typeof(IDODownloadStatusCallback), CorrespondingAction.GetSet)]
		DODownloadProperty_CallbackInterface,

		/// <summary>
		/// Optional. Use this property to set or get the pointer to IStream interface used for stream download type. VARIANT type is VT_UNKNOWN.
		/// </summary>
		[CorrespondingType(typeof(System.Runtime.InteropServices.ComTypes.IStream), CorrespondingAction.GetSet)]
		[CorrespondingType(typeof(IStreamV), CorrespondingAction.GetSet)]
		DODownloadProperty_StreamInterface,

		/// <summary>
		/// Optional write-only. Use this property to set the certificate context to be used during HTTP request operations. The value must
		/// consist of serialized bytes of CERT_CONTEXT. VARIANT type is (VT_ARRAY | VT_UI1).
		/// </summary>
		[CorrespondingType(typeof(byte[]), CorrespondingAction.Set)]
		DODownloadProperty_SecurityContext,

		/// <summary>
		/// Optional write-only. Use this property to set the network token to be used during HTTP operations. VARIANT_TRUE value will cause
		/// Delivery Optimization to capture the caller's identity token and VARIANT_FALSE will clear the existing token. The default is the
		/// token of the logged-on user. VARIANT type is VT_BOOL.
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Set)]
		DODownloadProperty_NetworkToken,

		/// <summary>Optional. Sets a specific correlation vector for telemetry purposes. VARIANT type is VT_BSTR.</summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Set)]
		DODownloadProperty_CorrelationVector,

		/// <summary>Optional write-only. Sets decryption information in the form of a JSON string. VARIANT type is VT_BSTR.</summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Set)]
		DODownloadProperty_DecryptionInfo,

		/// <summary>
		/// Optional write-only. Sets the piece hash file (PHF) location, which is used by Delivery Optimization to perform runtime integrity
		/// checks on the downloaded content. VARIANT type is VT_BSTR.
		/// </summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Set)]
		DODownloadProperty_IntegrityCheckInfo,

		/// <summary>
		/// Optional. Sets a Boolean flag indicating whether usage of the piece hash file (PHF) is mandatory. If VARIANT_TRUE, the download
		/// will be aborted if the integrity check fails. VARIANT type is VT_BOOL.
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Set)]
		DODownloadProperty_IntegrityCheckMandatory,

		/// <summary>Optional. Specifies the total download size in bytes. VARIANT type is VT_UI8.</summary>
		[CorrespondingType(typeof(ulong), CorrespondingAction.GetSet)]
		DODownloadProperty_TotalSizeBytes,

		/// <summary>Don't download when on a cellular connection.</summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.GetSet)]
		DODownloadProperty_DisallowOnCellular,

		/// <summary>Custom HTTPS headers are used when challenged.</summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.GetSet)]
		DODownloadProperty_HttpCustomAuthHeaders,

		/// <summary>
		/// <para>Https-to-http redirection. Default is</para>
		/// <para>FALSE</para>
		/// <para>.</para>
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.GetSet)]
		DODownloadProperty_HttpAllowSecureToNonSecureRedirect,

		/// <summary>
		/// <para>Save download info to the Windows Registry. Default is</para>
		/// <para>FALSE</para>
		/// <para>for Delivery Optimization download jobs;</para>
		/// <para>TRUE</para>
		/// <para>for BITS-style jobs.</para>
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.GetSet)]
		DODownloadProperty_NonVolatile,
	}

	/// <summary>
	/// <para>Important</para>
	/// <para>
	/// The <c>DODownloadPropertyEx</c> enumeration is deprecated. Instead, use the DODownloadProperty enumeration with
	/// IDODownload::GetProperty and IDODownload::SetProperty.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/delivery_optimization/dodownloadinternal/ne-dodownloadinternal-dodownloadpropertyex
	// typedef enum _DODownloadPropertyEx { DODownloadPropertyEx_UpdateId = 0, DODownloadPropertyEx_CorrelationVector,
	// DODownloadPropertyEx_DecryptionInfo, DODownloadPropertyEx_IntegrityCheckInfo, DODownloadPropertyEx_IntegrityCheckMandatory,
	// DODownloadPropertyEx_TotalSizeBytes, DODownloadPropertyEx_TempLocalFileUsage } DODownloadPropertyEx;
	[PInvokeData("DODownloadInternal.h")]
	[Obsolete]
	public enum DODownloadPropertyEx
	{
		/// <summary>Reserved. Do not use.</summary>
		DODownloadPropertyEx_UpdateId,

		/// <summary>Optional. Sets a specific correlation vector for telemetry purposes. VARIANT type is VT_BSTR.</summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Set)]
		DODownloadPropertyEx_CorrelationVector,

		/// <summary>Reserved. Do not use.</summary>
		DODownloadPropertyEx_DecryptionInfo,

		/// <summary>
		/// Optional write-only. Sets the piece hash file (PHF) location, which is used by Delivery Optimization to perform runtime integrity
		/// checks on the downloaded content. VARIANT type is VT_BSTR.
		/// </summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Set)]
		DODownloadPropertyEx_IntegrityCheckInfo,

		/// <summary>
		/// Optional. Sets a boolean flag indicating whether usage of the piece hash file (PHF) is mandatory. If VARIANT_TRUE, the download
		/// will be aborted once the integrity check is failed. VARIANT type is VT_BOOL.
		/// </summary>
		[CorrespondingType(typeof(bool), CorrespondingAction.Set)]
		DODownloadPropertyEx_IntegrityCheckMandatory,

		/// <summary>Reserved. Do not use.</summary>
		DODownloadPropertyEx_TotalSizeBytes,

		/// <summary>Reserved. Do not use.</summary>
		DODownloadPropertyEx_TempLocalFileUsage,
	}

	/// <summary>
	/// The <c>DODownloadState</c> enumeration specifies the ID of the current download state, which is part of the <c>DO_DOWNLOAD_STATUS</c> structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/ne-deliveryoptimization-dodownloadstate typedef enum
	// _DODownloadState { DODownloadState_Created, DODownloadState_Transferring, DODownloadState_Transferred, DODownloadState_Finalized,
	// DODownloadState_Aborted, DODownloadState_Paused } DODownloadState;
	[PInvokeData("deliveryoptimization.h", MSDNShortId = "NE:deliveryoptimization._DODownloadState")]
	public enum DODownloadState
	{
		/// <summary>Download object is created but hasn't been started yet.</summary>
		DODownloadState_Created,

		/// <summary>Download is in progress.</summary>
		DODownloadState_Transferring,

		/// <summary>Download is transferred and can start again by downloading another portion of the file.</summary>
		DODownloadState_Transferred,

		/// <summary>Download is finalized and cannot be started again.</summary>
		DODownloadState_Finalized,

		/// <summary>Download was aborted.</summary>
		DODownloadState_Aborted,

		/// <summary>Download has been paused on demand or due to transient error.</summary>
		DODownloadState_Paused,
	}

	/// <summary>Defines the different download modes that Delivery Optimization uses.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/delivery_optimization/downloadmode typedef enum _DownloadMode { DownloadMode_CdnOnly =
	// 0, DownloadMode_Lan = 1, DownloadMode_Group = 2, DownloadMode_Internet = 3, DownloadMode_Simple = 99, DownloadMode_Bypass = 100 } DownloadMode;
	[PInvokeData("Deliveryoptimization.h")]
	public enum DownloadMode
	{
		/// <summary>
		/// This setting disables peer-to-peer caching but still allows Delivery Optimization to download content from Microsoft servers.
		/// This mode uses additional metadata provided by the Delivery Optimization cloud services for a peerless reliable and efficient
		/// download experience.
		/// </summary>
		DownloadMode_CdnOnly,

		/// <summary>This default operating mode for Delivery Optimization enables peer sharing on the same network.</summary>
		DownloadMode_Lan,

		/// <summary>
		/// When group mode is set, the group is automatically selected based on the device s Active Directory Domain Services (AD DS) site
		/// (Windows 10, version 1607) or the domain the device is authenticated to (Windows 10, version 1511). In group mode, peering occurs
		/// across internal subnets, between devices that belong to the same group, including devices in remote offices. You can use the
		/// GroupID option to create your own custom group independently of domains and AD DS sites. Group download mode is the recommended
		/// option for most organizations looking to achieve the best bandwidth optimization with Delivery Optimization.
		/// </summary>
		DownloadMode_Group,

		/// <summary>Enable Internet peer sources for Delivery Optimization.</summary>
		DownloadMode_Internet,

		/// <summary>
		/// Simple mode disables the use of Delivery Optimization cloud services completely (for offline environments). Delivery Optimization
		/// switches to this mode automatically when the Delivery Optimization cloud services are unavailable, unreachable or when the
		/// content file size is less than 10 MB. In this mode, Delivery Optimization provides a reliable download experience, with no
		/// peer-to-peer caching.
		/// </summary>
		DownloadMode_Simple,

		/// <summary>Bypass Delivery Optimization and use BITS, instead. For example, select this mode so that clients can use BranchCache.</summary>
		DownloadMode_Bypass,
	}

	/// <summary>Defines the status of a file within the delivery optimization client.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/delivery_optimization/swarmstatus typedef enum _SwarmStatus { SwarmStatus_Downloading =
	// 0, SwarmStatus_Complete = 1, SwarmStatus_Caching = 2, SwarmStatus_Paused = 3 } SwarmStatus;
	[PInvokeData("Deliveryoptimization.h")]
	public enum SwarmStatus
	{
		/// <summary>The file is downloading.</summary>
		SwarmStatus_Downloading,

		/// <summary>The file download is complete.</summary>
		SwarmStatus_Complete,

		/// <summary>The file is being cached.</summary>
		SwarmStatus_Caching,

		/// <summary>The file download is paused.</summary>
		SwarmStatus_Paused,
	}

	/// <summary>The <c>IDODownload</c> interface is used to start and manage a download.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/nn-deliveryoptimization-idodownload
	[PInvokeData("deliveryoptimization.h", MSDNShortId = "NN:deliveryoptimization.IDODownload")]
	[ComImport, Guid("FBBD7FC0-C147-4727-A38D-827EF071EE77"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDODownload
	{
		/// <summary>Starts or resumes a download, passing optional ranges as a pointer to <c>DO_DOWNLOAD_RANGES_INFO</c> structure.</summary>
		/// <param name="ranges">
		/// Optional. A pointer to a <c>DO_DOWNLOAD_RANGES_INFO</c> structure (to download only specific ranges of the file). Pass
		/// <c>IntPtr.Zero</c> to download the entire file.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/nf-deliveryoptimization-idodownload-start HRESULT Start(
		// const DO_DOWNLOAD_RANGES_INFO *ranges );
		void Start([In, Optional] IntPtr ranges);

		/// <summary>Pauses the download.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/nf-deliveryoptimization-idodownload-pause HRESULT Pause();
		void Pause();

		/// <summary>Aborts the download.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/nf-deliveryoptimization-idodownload-abort HRESULT Abort();
		void Abort();

		/// <summary>Finalizes the download. Once finalized, a download cannot be resumed by calling <c>Start</c>.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/nf-deliveryoptimization-idodownload-finalize HRESULT Finalize();
#pragma warning disable CS0465 // Introducing a 'Finalize' method can interfere with destructor invocation
		void Finalize();
#pragma warning restore CS0465 // Introducing a 'Finalize' method can interfere with destructor invocation

		/// <summary>Retrieves a pointer to a <c>DO_DOWNLOAD_STATUS</c> structure that reflects the current status of the download.</summary>
		/// <returns>A <c>DO_DOWNLOAD_STATUS</c> structure.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/nf-deliveryoptimization-idodownload-getstatus HRESULT
		// GetStatus( DO_DOWNLOAD_STATUS *status );
		DO_DOWNLOAD_STATUS GetStatus();

		/// <summary>Retrieves a pointer to a <c>VARIANT</c> that contains a specific download property.</summary>
		/// <param name="propId">The required property ID to get (of type <c>DODownloadProperty</c>).</param>
		/// <returns>The resulting property value, stored in a <c>VARIANT</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/nf-deliveryoptimization-idodownload-getproperty HRESULT
		// GetProperty( DODownloadProperty propId, VARIANT *propVal );
		object GetProperty([In] DODownloadProperty propId);

		/// <summary>
		/// Sets a download property. The method accepts a pointer to a <c>VARIANT</c> that contains a specific property to apply to the download.
		/// </summary>
		/// <param name="propId">The required property ID to set (of type <c>DODownloadProperty</c>).</param>
		/// <param name="propVal">The property value to set, stored in a <c>VARIANT</c>.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/nf-deliveryoptimization-idodownload-setproperty HRESULT
		// SetProperty( DODownloadProperty propId, const VARIANT *propVal );
		void SetProperty([In] DODownloadProperty propId, /*[MarshalAs(UnmanagedType.Struct)] object*/ in OleAut32.VARIANT propVal);
	}

	/// <summary>The <c>IDODownloadStatusCallback</c> interface is used to receive notifications about a download.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/nn-deliveryoptimization-idodownloadstatuscallback
	[PInvokeData("deliveryoptimization.h", MSDNShortId = "NN:deliveryoptimization.IDODownloadStatusCallback")]
	[ComImport, Guid("D166E8E3-A90E-4392-8E87-05E996D3747D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDODownloadStatusCallback
	{
		/// <summary>Delivery Optimization calls your implementation of this method any time a download status has changed.</summary>
		/// <param name="download">An pointer to the <c>IDODownload</c> interface whose status changed.</param>
		/// <param name="status">A pointer to a <c>DO_DOWNLOAD_STATUS</c> structure containing the download's status.</param>
		/// <returns>If the function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/nf-deliveryoptimization-idodownloadstatuscallback-onstatuschange
		// HRESULT OnStatusChange( IDODownload *download, const DO_DOWNLOAD_STATUS *status );
		[PreserveSig]
		HRESULT OnStatusChange([In] IDODownload download, in DO_DOWNLOAD_STATUS status);
	}

	/// <summary>The <c>IDOManager</c> interface is used to create a new download, and to enumerate existing downloads.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/nn-deliveryoptimization-idomanager
	[PInvokeData("deliveryoptimization.h", MSDNShortId = "NN:deliveryoptimization.IDOManager")]
	[ComImport, Guid("400E2D4A-1431-4C1A-A748-39CA472CFDB1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(DeliveryOptimization))]
	public interface IDOManager
	{
		/// <summary>Creates a new download.</summary>
		/// <returns>An <c>IDODownload</c> interface pointer.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/nf-deliveryoptimization-idomanager-createdownload HRESULT
		// CreateDownload( IDODownload **download );
		IDODownload CreateDownload();

		/// <summary>Retrieves an interface pointer to an enumerator object that is used to enumerate existing downloads.</summary>
		/// <param name="category">
		/// <para>
		/// Optional. The property name to be used as a category to enumerate. Passing <see langword="null"/> will retrieve all existing
		/// downloads. The following properties are supported as a category.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>DODownloadProperty_Id</c></term>
		/// </item>
		/// <item>
		/// <term><c>DODownloadProperty_Uri</c></term>
		/// </item>
		/// <item>
		/// <term><c>DODownloadProperty_ContentId</c></term>
		/// </item>
		/// <item>
		/// <term><c>DODownloadProperty_DisplayName</c></term>
		/// </item>
		/// <item>
		/// <term><c>DODownloadProperty_LocalPath</c></term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// An interface pointer to <c>IEnumUnknown</c>, which is used to enumerate existing downloads. The contents of the enumerator depend
		/// on the value of category. The downloads included in the enumeration interface are the ones that were previously created by the
		/// same caller to this function.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/nf-deliveryoptimization-idomanager-enumdownloads HRESULT
		// EnumDownloads( const DO_DOWNLOAD_ENUM_CATEGORY *category, IEnumUnknown **ppEnum );
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumUnknown EnumDownloads([In, Optional] IntPtr category);
	}

	/// <summary>Retrieves an interface pointer to an enumerator object that is used to enumerate existing downloads.</summary>
	/// <param name="mgr">The <see cref="IDOManager"/> instance.</param>
	/// <param name="category">
	/// <para>
	/// The property name to be used as a category to enumerate. Passing <see langword="null"/> will retrieve all existing downloads. The
	/// following properties are supported as a category.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>DODownloadProperty_Id</c></term>
	/// </item>
	/// <item>
	/// <term><c>DODownloadProperty_Uri</c></term>
	/// </item>
	/// <item>
	/// <term><c>DODownloadProperty_ContentId</c></term>
	/// </item>
	/// <item>
	/// <term><c>DODownloadProperty_DisplayName</c></term>
	/// </item>
	/// <item>
	/// <term><c>DODownloadProperty_LocalPath</c></term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// An interface pointer to <c>IEnumUnknown</c>, which is used to enumerate existing downloads. The contents of the enumerator depend on
	/// the value of category. The downloads included in the enumeration interface are the ones that were previously created by the same
	/// caller to this function.
	/// </returns>
	public static IEnumerable<IDODownload> EnumDownloads(this IDOManager mgr, DODownloadProperty? category = null)
	{
		var ienum = category.HasValue ? mgr.EnumDownloads(SafeCoTaskMemHandle.CreateFromStructure(new DO_DOWNLOAD_ENUM_CATEGORY() { Property = category.Value })) : mgr.EnumDownloads();
		return ienum.Enumerate<IDODownload>().WhereNotNull();
	}

	/// <summary>
	/// Sets a download property. The method accepts a pointer to a <c>VARIANT</c> that contains a specific property to apply to the download.
	/// </summary>
	/// <param name="download">The <see cref="IDODownload"/> instance.</param>
	/// <param name="propId">The required property ID to set (of type <c>DODownloadProperty</c>).</param>
	/// <param name="propVal">The property value to set, stored in a <c>VARIANT</c>.</param>
	public static void SetProperty(this IDODownload download, [In] DODownloadProperty propId, [In] object propVal)
	{
		switch (propId)
		{
			case DODownloadProperty.DODownloadProperty_CallbackInterface:
			case DODownloadProperty.DODownloadProperty_StreamInterface:
				var intf = CorrespondingTypeAttribute.GetCorrespondingTypes(propId, CorrespondingAction.Get).Where(propVal.GetType().InheritsFrom).FirstOrDefault() ??
					throw new ArgumentException($"Property {propId} requires a valid corresponding COM interface pointer.", nameof(propVal));
				var ptr = Marshal.GetComInterfaceForObject(propVal, intf);
				VARIANT v = new() { vt = VARTYPE.VT_UNKNOWN, byref = ptr };
				download.SetProperty(propId, v);
				break;
			default:
				download.SetProperty(propId, new VARIANT(propVal));
				break;
		}
	}

	/// <summary>Starts or resumes a download, passing ranges as a <c>DO_DOWNLOAD_RANGES_INFO</c> structure.</summary>
	/// <param name="i">The <see cref="IDODownload"/> instance.</param>
	/// <param name="ranges">A <c>DO_DOWNLOAD_RANGES_INFO</c> structure (to download only specific ranges of the file).</param>
	public static void Start(this IDODownload i, in DO_DOWNLOAD_RANGES_INFO ranges) => i.Start((SafeCoTaskMemStruct<DO_DOWNLOAD_RANGES_INFO>)ranges);

	/// <summary>Starts or resumes a download, passing ranges as a <c>DO_DOWNLOAD_RANGES_INFO</c> structure.</summary>
	/// <param name="i">The <see cref="IDODownload"/> instance.</param>
	/// <param name="ranges">A <c>DO_DOWNLOAD_RANGES_INFO</c> structure (to download only specific ranges of the file).</param>
	public static void Start(this IDODownload i, params DO_DOWNLOAD_RANGE[]? ranges)
	{
		if (ranges is null || ranges.Length == 0)
			i.Start(IntPtr.Zero);
		else
			i.Start(new DO_DOWNLOAD_RANGES_INFO() { RangeCount = (uint)ranges.Length, Ranges = ranges });
	}

	/// <summary>
	/// The <c>DO_DOWNLOAD_ENUM_CATEGORY</c> structure is used by <c>IDOManager::EnumDownloads</c> to filter the downloads enumeration by the
	/// specific property's value.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/ns-deliveryoptimization-do_download_enum_category typedef
	// struct _DO_DOWNLOAD_ENUM_CATEGORY { DODownloadProperty Property; LPCWSTR Value; } DO_DOWNLOAD_ENUM_CATEGORY;
	[PInvokeData("deliveryoptimization.h", MSDNShortId = "NS:deliveryoptimization._DO_DOWNLOAD_ENUM_CATEGORY")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DO_DOWNLOAD_ENUM_CATEGORY
	{
		/// <summary>
		/// <para>The property name to be used for the download enumeration. These properties are supported for enumeration purposes.</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>DODownloadProperty_Id</c></term>
		/// </item>
		/// <item>
		/// <term><c>DODownloadProperty_Uri</c></term>
		/// </item>
		/// <item>
		/// <term><c>DODownloadProperty_ContentId</c></term>
		/// </item>
		/// <item>
		/// <term><c>DODownloadProperty_DisplayName</c></term>
		/// </item>
		/// <item>
		/// <term><c>DODownloadProperty_LocalPath</c></term>
		/// </item>
		/// </list>
		/// </summary>
		public DODownloadProperty Property;

		/// <summary>The property's value.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Value;
	}

	/// <summary>
	/// The <c>DO_DOWNLOAD_RANGE</c> structure identifies a single range of bytes to download from a file. The <c>DO_DOWNLOAD_RANGE</c>
	/// structure is included within <c>DO_DOWNLOAD_RANGES_INFO</c> structure to provide an array of ranges to download.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/ns-deliveryoptimization-do_download_range typedef struct
	// _DO_DOWNLOAD_RANGE { UINT64 Offset; UINT64 Length; } DO_DOWNLOAD_RANGE;
	[PInvokeData("deliveryoptimization.h", MSDNShortId = "NS:deliveryoptimization._DO_DOWNLOAD_RANGE")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DO_DOWNLOAD_RANGE
	{
		/// <summary>Zero-based offset to the beginning of the range of bytes to download from a file.</summary>
		public ulong Offset;

		/// <summary>
		/// The length of the range, in bytes. Do not specify a zero-byte length. To indicate that the range extends to the end of the file,
		/// specify <c>DO_LENGTH_TO_EOF</c>.
		/// </summary>
		public ulong Length;
	}

	/// <summary>
	/// The <c>DO_DOWNLOAD_RANGES_INFO</c> structure identifies an array of ranges of bytes to download from a file. It is typically passed
	/// as an optional argument to the <see cref="IDODownload.Start"/> function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/ns-deliveryoptimization-do_download_ranges_info typedef struct
	// _DO_DOWNLOAD_RANGES_INFO { UINT RangeCount; DO_DOWNLOAD_RANGE Ranges[1]; } DO_DOWNLOAD_RANGES_INFO;
	[PInvokeData("deliveryoptimization.h", MSDNShortId = "NS:deliveryoptimization._DO_DOWNLOAD_RANGES_INFO")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DO_DOWNLOAD_RANGES_INFO>), nameof(RangeCount))]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DO_DOWNLOAD_RANGES_INFO
	{
		/// <summary>Number of elements in Ranges.</summary>
		public uint RangeCount;

		/// <summary>Array of one or more <c>DO_DOWNLOAD_RANGE</c> structures that specify the ranges to download.</summary>
		[MarshalAs(UnmanagedType.LPArray, SizeConst = 1)]
		public DO_DOWNLOAD_RANGE[] Ranges;
	}

	/// <summary>
	/// The <c>DO_DOWNLOAD_STATUS</c> structure is used to obtain the status of a specific download. It is obtained by calling the
	/// <c>IDODownload::GetStatus</c> function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/deliveryoptimization/ns-deliveryoptimization-do_download_status typedef struct
	// _DO_DOWNLOAD_STATUS { UINT64 BytesTotal; UINT64 BytesTransferred; DODownloadState State; HRESULT Error; HRESULT ExtendedError; } DO_DOWNLOAD_STATUS;
	[PInvokeData("deliveryoptimization.h", MSDNShortId = "NS:deliveryoptimization._DO_DOWNLOAD_STATUS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DO_DOWNLOAD_STATUS
	{
		/// <summary>The total number of bytes to download.</summary>
		public ulong BytesTotal;

		/// <summary>The number of bytes that have already been downloaded.</summary>
		public ulong BytesTransferred;

		/// <summary>The current download state as defined by the <c>DODownloadState</c> enumeration.</summary>
		public DODownloadState State;

		/// <summary>The error information (if it exists) that is associated with the current download.</summary>
		public HRESULT Error;

		/// <summary>The extended error information (if it exists) that is associated with the current download.</summary>
		public HRESULT ExtendedError;
	}

	/// <summary>Contains fields for download and upload statistics for a file.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/delivery_optimization/doswarmstats typedef struct _DOSwarmStats { LPWSTR fileId; LPWSTR
	// sourceURL; UINT64 fileSize; UINT64 totalBytesDownloaded; UINT64 bytesFromLanPeers; UINT64 bytesFromGroupPeers; UINT64
	// bytesFromInternetPeers; UINT64 bytesFromHttp; UINT64 bytesFromDoinc; UINT64 bytesToLanPeers; UINT64 bytesToGroupPeers; UINT64
	// bytesToInternetPeers; UINT httpConnectionCount; UINT doincConnectionCount; UINT lanConnectionCount; UINT groupConnectionCount; UINT
	// internetConnectionCount; UINT downloadDuration; DownloadMode downloadMode; SwarmStatus status; BOOL isBackground; } DOSwarmStats;
	[PInvokeData("Deliveryoptimization.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DOSwarmStats
	{
		/// <summary>Null-terminated string that was specified with the <c>AddFileWithRanges</c> call.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string fileId;

		/// <summary>Null-terminated string that contains the name of the file on the server (for example, https://&lt;server&gt;/&lt;path&gt;/file.ext).</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string sourceURL;

		/// <summary>Size of the file in bytes.</summary>
		public ulong fileSize;

		/// <summary>Total number of bytes transferred.</summary>
		public ulong totalBytesDownloaded;

		/// <summary>Number of bytes transferred from LAN peers.</summary>
		public ulong bytesFromLanPeers;

		/// <summary>Number of bytes transferred from group peers.</summary>
		public ulong bytesFromGroupPeers;

		/// <summary>Number of bytes transferred from Internet peers.</summary>
		public ulong bytesFromInternetPeers;

		/// <summary>Number of bytes transferred from http.</summary>
		public ulong bytesFromHttp;

		/// <summary>For internal use only.</summary>
		public ulong bytesFromDoinc;

		/// <summary>Number of bytes transferred to LAN peers.</summary>
		public ulong bytesToLanPeers;

		/// <summary>Number of bytes transferred to group peers.</summary>
		public ulong bytesToGroupPeers;

		/// <summary>Number of bytes transferred to Internet peers.</summary>
		public ulong bytesToInternetPeers;

		/// <summary>Count of http connections.</summary>
		public uint httpConnectionCount;

		/// <summary>For internal use only.</summary>
		public uint doincConnectionCount;

		/// <summary>Count of LAN connections.</summary>
		public uint lanConnectionCount;

		/// <summary>Count of group connections.</summary>
		public uint groupConnectionCount;

		/// <summary>Count of Internet connections.</summary>
		public uint internetConnectionCount;

		/// <summary>Duration of the file transfer in milliseconds.</summary>
		public uint downloadDuration;

		/// <summary>The download mode used, see <c>DownloadMode</c>.</summary>
		public DownloadMode downloadMode;

		/// <summary>The status of a file transfer, see <c>SwarmStatus</c>.</summary>
		public SwarmStatus status;

		/// <summary>True, if this is a background transfer.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool isBackground;
	}

	/// <summary>CLSID_DeliveryOptimization</summary>
	[ComImport, Guid("5b99fa76-721c-423c-adac-56d03c8a8007"), ClassInterface(ClassInterfaceType.None)]
	public class DeliveryOptimization { }

	//public interface IDeliveryOptimizationJob
	//public interface IDeliveryOptimizationFile
	//public interface IDODownloadInternal
	//public interface IEnumBackgroundCopyFiles
}