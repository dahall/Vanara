using System;
using System.IO;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

public static partial class AMSI
{
	/// <summary>Represents a stream to be scanned.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nn-amsi-iamsistream
	[PInvokeData("amsi.h", MSDNShortId = "NN:amsi.IAmsiStream")]
	[ComImport, Guid("3e47f2e5-81d4-4d3b-897f-545096770373"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAmsiStream
	{
		/// <summary>Returns a requested attribute from the stream.</summary>
		/// <param name="attribute">Specifies the type of attribute to be returned. See Remarks.</param>
		/// <param name="dataSize">The size of the output buffer, <c>data</c>, in bytes.</param>
		/// <param name="data">Buffer to receive the requested attribute. <c>data</c> must be set to its size in bytes.</param>
		/// <param name="retData">
		/// The number of bytes returned in <c>data</c>. If this method returns <c>E_NOT_SUFFICIENT_BUFFER</c>, <c>retData</c> contains
		/// the number of bytes required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>The attribute is not supported.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOT_SUFFICIENT_BUFFER</c></term>
		/// <term>
		/// The size of the output buffer, as indicated by <c>data</c>, is not large enough. <c>retData</c> contains the number of bytes required.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more argument is invalid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOT_VALID_STATE</c></term>
		/// <term>The object is not initialized.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Depending on the attribute requested in <c>attribute</c>, the following data should be copied to <c>data</c>:</para>
		/// <list type="table">
		/// <listheader>
		/// <term><c>attribute</c></term>
		/// <term><c>data</c></term>
		/// </listheader>
		/// <item>
		/// <term><c>AMSI_ATTRIBUTE_APP_NAME</c></term>
		/// <term>The name, version, or GUID string of the calling application, copied from a <c>LPWSTR</c>.</term>
		/// </item>
		/// <item>
		/// <term><c>AMSI_ATTRIBUTE_CONTENT_NAME</c></term>
		/// <term>The filename, URL, unique script ID, or similar of the content, copied from a <c>LPWSTR</c>.</term>
		/// </item>
		/// <item>
		/// <term><c>AMSI_ATTRIBUTE_CONTENT_SIZE</c></term>
		/// <term>The size of the input, as a <c>ULONGLONG</c>.</term>
		/// </item>
		/// <item>
		/// <term><c>AMSI_ATTRIBUTE_CONTENT_ADDRESS</c></term>
		/// <term>The memory address if the content is fully loaded into memory.</term>
		/// </item>
		/// <item>
		/// <term><c>AMSI_ATTRIBUTE_SESSION</c></term>
		/// <term>
		/// Session is used to associate different scan calls, such as if the contents to be scanned belong to the same original script.
		/// Return <c>nullptr</c> if the content is self-contained.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-iamsistream-getattribute HRESULT GetAttribute( [in]
		// AMSI_ATTRIBUTE attribute, [in] ULONG dataSize, [out] unsigned char *data, [out] ULONG *retData );
		[PreserveSig]
		HRESULT GetAttribute(AMSI_ATTRIBUTE attribute, uint dataSize, [Out] IntPtr data, out uint retData);

		/// <summary>Requests a buffer-full of content to be read.</summary>
		/// <param name="position">The zero-based index into the content at which the read is to begin.</param>
		/// <param name="size">The number of bytes to read from the content.</param>
		/// <param name="buffer">Buffer into which the content is to be read.</param>
		/// <param name="readSize">The number of bytes read into <c>buffer</c>.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more argument is invalid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOT_VALID_STATE</c></term>
		/// <term>The object is not initialized.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-iamsistream-read HRESULT Read( [in] ULONGLONG position, [in]
		// ULONG size, [out] unsigned char *buffer, [out] ULONG *readSize );
		[PreserveSig]
		HRESULT Read(ulong position, uint size, [Out] IntPtr buffer, out uint readSize);
	}

	/// <summary>Represents the antimalware product.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nn-amsi-iantimalware
	[PInvokeData("amsi.h", MSDNShortId = "NN:amsi.IAntimalware")]
	[ComImport, Guid("82d29c2e-f062-44e6-b5c9-3d9a2f24a2df"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(CAntimalware))]
	public interface IAntimalware
	{
		/// <summary>Scan a stream of content.</summary>
		/// <param name="stream">The IAmsiStream stream to be scanned.</param>
		/// <param name="result">The result of the scan. See AMSI_RESULT.</param>
		/// <param name="provider">The IAntimalwareProvider provider of the antimalware product.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more argument is invalid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOT_VALID_STATE</c></term>
		/// <term>The object is not initialized.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-iantimalware-scan HRESULT Scan( [in] IAmsiStream *stream,
		// [out] AMSI_RESULT *result, [out] IAntimalwareProvider **provider );
		[PreserveSig]
		HRESULT Scan([In] IAmsiStream stream, out AMSI_RESULT result, out IAntimalwareProvider provider);

		/// <summary>Closes the session.</summary>
		/// <param name="session">
		/// <para>Type: ULONGLONG</para>
		/// <para>The id/handle of the session to close.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-iantimalware-closesession void CloseSession( [in] ULONGLONG
		// session );
		[PreserveSig]
		void CloseSession(ulong session);
	}

	/// <summary>Represents the antimalware product.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nn-amsi-iantimalware2
	[PInvokeData("amsi.h", MSDNShortId = "NN:amsi.IAntimalware2")]
	[ComImport, Guid("301035b5-2d42-4f56-8c65-2dcaa7fb3cdc"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(CAntimalware))]
	public interface IAntimalware2 : IAntimalware
	{
		/// <summary>Scan a stream of content.</summary>
		/// <param name="stream">The IAmsiStream stream to be scanned.</param>
		/// <param name="result">The result of the scan. See AMSI_RESULT.</param>
		/// <param name="provider">The IAntimalwareProvider provider of the antimalware product.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more argument is invalid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOT_VALID_STATE</c></term>
		/// <term>The object is not initialized.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-iantimalware-scan HRESULT Scan( [in] IAmsiStream *stream,
		// [out] AMSI_RESULT *result, [out] IAntimalwareProvider **provider );
		[PreserveSig]
		new HRESULT Scan([In] IAmsiStream stream, out AMSI_RESULT result, out IAntimalwareProvider provider);

		/// <summary>Closes the session.</summary>
		/// <param name="session">
		/// <para>Type: ULONGLONG</para>
		/// <para>The id/handle of the session to close.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-iantimalware-closesession void CloseSession( [in] ULONGLONG
		// session );
		[PreserveSig]
		new void CloseSession(ulong session);

		/// <summary>
		/// Sends to the antimalware product a notification of an arbitrary operation. The notification doesn't imply the request of an
		/// antivirus scan. Rather, <c>IAntimalware2::Notify</c> is designed to provide a quick and lightweight mechanism to communicate
		/// to the antimalware product that an event has taken place. In general, the antimalware product should process the
		/// notification, and return to the caller as quickly as possible.
		/// </summary>
		/// <param name="buffer">
		/// <para>Type: <c>PVOID</c></para>
		/// <para>The buffer that contains the notification data.</para>
		/// </param>
		/// <param name="length">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The length, in bytes, of the data to be read from buffer.</para>
		/// </param>
		/// <param name="contentName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The filename, URL, unique script ID, or similar of the content being scanned.</para>
		/// </param>
		/// <param name="appName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The name of the application sending the AMSI notification.</para>
		/// </param>
		/// <param name="pResult">
		/// <para>Type: <c>AMSI_RESULT*</c></para>
		/// <para>The result of the scan.</para>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more arguments is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_NOT_VALID_STATE</term>
		/// <term>The object isn't initialized.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-iantimalware2-notify HRESULT Notify( PVOID buffer, ULONG
		// length, LPCWSTR contentName, LPCWSTR appName, AMSI_RESULT *pResult );
		[PreserveSig]
		HRESULT Notify([In] IntPtr buffer, uint length, [MarshalAs(UnmanagedType.LPWStr)] string contentName,
			[MarshalAs(UnmanagedType.LPWStr)] string appName, out AMSI_RESULT pResult);
	}

	/// <summary>Represents the provider of the antimalware product.</summary>
	/// <remarks>
	/// <para>
	/// As of Windows 10, version 1903, Windows has added a way to enable Authenticode signing checks for providers. The feature is
	/// disabled by default, for both 32-bit and 64-bit processes. If you are creating a provider for test purposes, then you can enable
	/// or disable sign checks by setting the following Windows Registry value appropriately. The value is a DWORD.
	/// </para>
	/// <para>
	/// <code>Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\AMSI\FeatureBits</code>
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Behavior</term>
	/// </listheader>
	/// <item>
	/// <term>0x1</term>
	/// <term>The signing check is disabled. This is the default behavior. You can also use this value, temporarily, while testing.</term>
	/// </item>
	/// <item>
	/// <term>0x2</term>
	/// <term>The check for Authenticode signing is enabled.</term>
	/// </item>
	/// </list>
	/// <para>Deleting the registry value altogether behaves as if the value 0x1 were present.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>As a provider, you must use the
	/// <code>/ac</code>
	/// switch (with the SignTool) to cross-sign with an Authenticode certificate. Once you've signed your binary, you can then verify it
	/// by using the SignTool and the
	/// <code>/kp</code>
	/// option. If the SignTool returns no error, then your binary is properly signed.
	/// </para>
	/// </para>
	/// <para>
	/// <para>Important</para>
	/// <para>
	/// Even though the Windows Registry value is not protected by the operating system, your computer's antivirus provider might protect
	/// the value, thus making it write-protected.
	/// </para>
	/// </para>
	/// <para>
	/// To check whether or not your provider is loading, you can view code integrity events. Be sure to enable verbose logging of code
	/// integrity diagnostic events. The event IDs to look for are 3040 and 3041. Here are some examples.
	/// </para>
	/// <para>
	/// <code>Log Name: Microsoft-Windows-CodeIntegrity/Verbose Source: Microsoft-Windows-CodeIntegrity Date: M/DD/YYYY H:MM:SS PM Event ID: 3040 Task Category: (14) Level: Verbose Keywords: User: [DOMAIN_NAME]\Administrator Computer: [COMPUTER_NAME] Description: Code Integrity started retrieving the cached data of [PATH_AND_FILENAME] file. Event Xml: &lt;Event xmlns="http://schemas.microsoft.com/win/2004/08/events/event"&gt; &lt;System&gt; &lt;Provider Name="Microsoft-Windows-CodeIntegrity" Guid="{4ee76bd8-3cf4-44a0-a0ac-3937643e37a3}" /&gt; &lt;EventID&gt;3040&lt;/EventID&gt; &lt;Version&gt;0&lt;/Version&gt; &lt;Level&gt;5&lt;/Level&gt; &lt;Task&gt;14&lt;/Task&gt; &lt;Opcode&gt;1&lt;/Opcode&gt; &lt;Keywords&gt;0x4000000000000000&lt;/Keywords&gt; &lt;TimeCreated SystemTime="YYYY-MM-DDT02:26:48.875954700Z" /&gt; &lt;EventRecordID&gt;7&lt;/EventRecordID&gt; &lt;Correlation /&gt; &lt;Execution ProcessID="4972" ThreadID="7752" ProcessorID="1" KernelTime="14" UserTime="2" /&gt; &lt;Channel&gt;Microsoft-Windows-CodeIntegrity/Verbose&lt;/Channel&gt; &lt;Computer&gt;[COMPUTER_NAME]&lt;/Computer&gt; &lt;Security UserID="[USER_SID]" /&gt; &lt;/System&gt; &lt;EventData&gt; &lt;Data Name="FileNameLength"&gt;40&lt;/Data&gt; &lt;Data Name="FileNameBuffer"&gt;[PATH_AND_FILENAME]&lt;/Data&gt; &lt;/EventData&gt; &lt;/Event&gt;</code>
	/// </para>
	/// <para>
	/// <code>Log Name: Microsoft-Windows-CodeIntegrity/Verbose Source: Microsoft-Windows-CodeIntegrity Date: M/DD/YYYY H:MM:SS PM Event ID: 3041 Task Category: (14) Level: Verbose Keywords: User: [DOMAIN_NAME]\Administrator Computer: [COMPUTER_NAME] Description: Code Integrity completed retrieval of file cache. Status 0xC0000225. Event Xml: &lt;Event xmlns="http://schemas.microsoft.com/win/2004/08/events/event"&gt; &lt;System&gt; &lt;Provider Name="Microsoft-Windows-CodeIntegrity" Guid="{4ee76bd8-3cf4-44a0-a0ac-3937643e37a3}" /&gt; &lt;EventID&gt;3041&lt;/EventID&gt; &lt;Version&gt;2&lt;/Version&gt; &lt;Level&gt;5&lt;/Level&gt; &lt;Task&gt;14&lt;/Task&gt; &lt;Opcode&gt;2&lt;/Opcode&gt; &lt;Keywords&gt;0x4000000000000000&lt;/Keywords&gt; &lt;TimeCreated SystemTime="YYYY-MM-DDT02:26:48.875964700Z" /&gt; &lt;EventRecordID&gt;8&lt;/EventRecordID&gt; &lt;Correlation /&gt; &lt;Execution ProcessID="4972" ThreadID="7752" ProcessorID="1" KernelTime="14" UserTime="2" /&gt; &lt;Channel&gt;Microsoft-Windows-CodeIntegrity/Verbose&lt;/Channel&gt; &lt;Computer&gt;[COMPUTER_NAME]&lt;/Computer&gt; &lt;Security UserID="[USER_SID]" /&gt; &lt;/System&gt; &lt;EventData&gt; &lt;Data Name="Status"&gt;0xc0000225&lt;/Data&gt; &lt;Data Name="CachedFlags"&gt;0x0&lt;/Data&gt; &lt;Data Name="CacheSource"&gt;0&lt;/Data&gt; &lt;Data Name="CachedPolicy"&gt;0&lt;/Data&gt; &lt;/EventData&gt; &lt;/Event&gt;</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nn-amsi-iantimalwareprovider
	[PInvokeData("amsi.h", MSDNShortId = "NN:amsi.IAntimalwareProvider")]
	[ComImport, Guid("b2cabfe3-fe04-42b1-a5df-08d483d4d125"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAntimalwareProvider
	{
		/// <summary>Scan a stream of content.</summary>
		/// <param name="stream">The IAmsiStream stream to be scanned.</param>
		/// <param name="result">The result of the scan. See AMSI_RESULT.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more argument is invalid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOT_VALID_STATE</c></term>
		/// <term>The object is not initialized.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-iantimalwareprovider-scan HRESULT Scan( [in] IAmsiStream
		// *stream, [out] AMSI_RESULT *result );
		[PreserveSig]
		HRESULT Scan(IAmsiStream stream, out AMSI_RESULT result);

		/// <summary>Closes the session.</summary>
		/// <param name="session">
		/// <para>Type: ULONGLONG</para>
		/// <para>The id/handle of the session to close.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-iantimalwareprovider-closesession void CloseSession( [in]
		// ULONGLONG session );
		[PreserveSig]
		void CloseSession(ulong session);

		/// <summary>The name of the antimalware provider to be displayed.</summary>
		/// <param name="displayName">A pointer to a <c>LPWSTR</c> that contains the display name.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>The argument is invalid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOT_VALID_STATE</c></term>
		/// <term>The object is not initialized.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-iantimalwareprovider-displayname HRESULT DisplayName( [out]
		// LPWSTR *displayName );
		[PreserveSig]
		HRESULT DisplayName([MarshalAs(UnmanagedType.LPWStr)] out string displayName);
	}

	/// <summary>Represents the provider of the antimalware product.</summary>
	/// <remarks>See <c>Remarks</c> in the IAntimalwareProvider interface topic.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nn-amsi-iantimalwareprovider2
	[PInvokeData("amsi.h", MSDNShortId = "NN:amsi.IAntimalwareProvider2")]
	[ComImport, Guid("7c1e6570-3f73-4e0f-8ad4-98b94cd3290f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAntimalwareProvider2 : IAntimalwareProvider
	{
		/// <summary>Scan a stream of content.</summary>
		/// <param name="stream">The IAmsiStream stream to be scanned.</param>
		/// <param name="result">The result of the scan. See AMSI_RESULT.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more argument is invalid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOT_VALID_STATE</c></term>
		/// <term>The object is not initialized.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-iantimalwareprovider-scan HRESULT Scan( [in] IAmsiStream
		// *stream, [out] AMSI_RESULT *result );
		[PreserveSig]
		new HRESULT Scan(IAmsiStream stream, out AMSI_RESULT result);

		/// <summary>Closes the session.</summary>
		/// <param name="session">
		/// <para>Type: ULONGLONG</para>
		/// <para>The id/handle of the session to close.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-iantimalwareprovider-closesession void CloseSession( [in]
		// ULONGLONG session );
		[PreserveSig]
		new void CloseSession(ulong session);

		/// <summary>The name of the antimalware provider to be displayed.</summary>
		/// <param name="displayName">A pointer to a <c>LPWSTR</c> that contains the display name.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>The argument is invalid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOT_VALID_STATE</c></term>
		/// <term>The object is not initialized.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-iantimalwareprovider-displayname HRESULT DisplayName( [out]
		// LPWSTR *displayName );
		[PreserveSig]
		new HRESULT DisplayName([MarshalAs(UnmanagedType.LPWStr)] out string displayName);

		/// <summary>
		/// Sends to the antimalware provider a notification of an arbitrary operation. The notification doesn't imply the request of an
		/// antivirus scan. Rather, <c>IAntimalwareProvider2::Notify</c> is designed to provide a quick and lightweight mechanism to
		/// communicate to the antimalware provider that an event has taken place. In general, the antimalware provider should process
		/// the notification, and return to the caller as quickly as possible.
		/// </summary>
		/// <param name="buffer">
		/// <para>Type: <c>PVOID</c></para>
		/// <para>The buffer that contains the notification data.</para>
		/// </param>
		/// <param name="length">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The length, in bytes, of the data to be read from buffer.</para>
		/// </param>
		/// <param name="contentName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The filename, URL, unique script ID, or similar of the content being scanned.</para>
		/// </param>
		/// <param name="appName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The name of the application sending the AMSI notification.</para>
		/// </param>
		/// <param name="pResult">
		/// <para>Type: <c>AMSI_RESULT*</c></para>
		/// <para>The result of the scan.</para>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more arguments is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_NOT_VALID_STATE</term>
		/// <term>The object isn't initialized.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/amsi/nf-amsi-iantimalwareprovider2-notify HRESULT Notify( PVOID buffer,
		// ULONG length, LPCWSTR contentName, LPCWSTR appName, AMSI_RESULT *pResult );
		[PreserveSig]
		HRESULT Notify(IntPtr buffer, uint length, [MarshalAs(UnmanagedType.LPWStr)] string contentName,
			[MarshalAs(UnmanagedType.LPWStr)] string appName, out AMSI_RESULT pResult);
	}

	/// <summary>Memory based stream that implements IAmsiStream.</summary>
	/// <seealso cref="System.IO.MemoryStream"/>
	/// <seealso cref="Vanara.PInvoke.AMSI.IAmsiStream"/>
	public class AmsiStream : NativeMemoryStream, IAmsiStream
	{
		private static readonly HRESULT E_INSUFF_BUFFER = HRESULT.HRESULT_FROM_WIN32(Win32Error.ERROR_INSUFFICIENT_BUFFER);

		/// <summary>Initializes a new instance of the <see cref="AmsiStream"/> class.</summary>
		public AmsiStream() : base()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="AmsiStream"/> class with an initial capacity.</summary>
		/// <param name="capacity">The capacity.</param>
		public AmsiStream(int capacity) : base(capacity)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="AmsiStream"/> class and inserts the contents of a buffer.</summary>
		/// <param name="buffer">The buffer to copy.</param>
		/// <param name="writable">if set to <see langword="true"/>, the stream is read-write; if <see langword="false"/>, it is read-only.</param>
		public AmsiStream(byte[] buffer, bool writable) : base(new SafeCoTaskMemHandle(buffer), access: writable ? FileAccess.ReadWrite : FileAccess.Read)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="AmsiStream"/> class with file information.</summary>
		/// <param name="file">The file information.</param>
		/// <param name="writable">if set to <see langword="true"/>, the stream is read-write; if <see langword="false"/>, it is read-only.</param>
		public AmsiStream(FileInfo file, bool writable) : this(file is null ? null : File.ReadAllBytes(file.FullName), writable) => ContentName = file.FullName;

		/// <summary>Initializes a new instance of the <see cref="AmsiStream"/> class.</summary>
		/// <param name="mem">The memory allocator used to create and extend the native memory.</param>
		/// <param name="writable">if set to <see langword="true"/>, the stream is read-write; if <see langword="false"/>, it is read-only.</param>
		public AmsiStream(SafeAllocatedMemoryHandle mem, bool writable) : this(mem.GetBytes(), writable)
		{
		}

		/// <summary>Gets or sets the name, version, or GUID string of the calling application.</summary>
		public string AppName { get; set; }

		/// <summary>Gets or sets the filename, URL, unique script ID, or similar of the content.</summary>
		public string ContentName { get; set; }

		/// <summary>
		/// Gets or sets the session is used to associate different scan calls, such as if the contents to be scanned belong to the
		/// sample original script.
		/// </summary>
		public IntPtr Session { get; set; }

		HRESULT IAmsiStream.GetAttribute(AMSI_ATTRIBUTE attribute, uint dataSize, IntPtr data, out uint retData)
		{
			byte[] bytes = attribute switch
			{
				AMSI_ATTRIBUTE.AMSI_ATTRIBUTE_APP_NAME => StringHelper.GetBytes(AppName, true, CharSet.Unicode),
				AMSI_ATTRIBUTE.AMSI_ATTRIBUTE_CONTENT_NAME => StringHelper.GetBytes(ContentName, true, CharSet.Unicode),
				AMSI_ATTRIBUTE.AMSI_ATTRIBUTE_CONTENT_SIZE => BitConverter.GetBytes((ulong)Length),
				AMSI_ATTRIBUTE.AMSI_ATTRIBUTE_CONTENT_ADDRESS => IntPtr.Size == 8 ? BitConverter.GetBytes(Pointer.ToInt64()) : BitConverter.GetBytes(Pointer.ToInt32()),
				AMSI_ATTRIBUTE.AMSI_ATTRIBUTE_SESSION => IntPtr.Size == 8 ? BitConverter.GetBytes(Session.ToInt64()) : BitConverter.GetBytes(Session.ToInt32()),
				_ => null,
			};
			if (bytes is not null)
			{
				retData = (uint)bytes.Length;
				if (bytes.Length > dataSize)
					return E_INSUFF_BUFFER;

				Marshal.Copy(bytes, 0, data, bytes.Length);
				return HRESULT.S_OK;
			}
			retData = 0;
			return HRESULT.E_NOTIMPL;
		}

		HRESULT IAmsiStream.Read(ulong position, uint size, IntPtr buffer, out uint readSize)
		{
			readSize = 0;
			if (buffer == IntPtr.Zero || (long)position > Length)
			{
				return HRESULT.E_INVALIDARG;
			}

			long bytesToRead = Math.Min(Length - (long)position, size);
			if (bytesToRead > 0)
			{
				Pointer.Offset((long)position).CopyTo(buffer, bytesToRead);
			}

			readSize = (uint)bytesToRead;
			return HRESULT.S_OK;
		}
	}

	/// <summary>CLSID_Antimalware</summary>
	[ComImport, Guid("fdb00e52-a214-4aa1-8fba-4357bb0072ec"), ClassInterface(ClassInterfaceType.None)]
	public class CAntimalware { }
}