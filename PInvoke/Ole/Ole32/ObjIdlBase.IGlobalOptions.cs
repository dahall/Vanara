namespace Vanara.PInvoke;

public static partial class Ole32
{
	/// <summary>Identifies process-global options that you can set or query by using the IGlobalOptions interface.</summary>
	/// <remarks>
	/// The unmarshaling policy option <c>COMGLB_UNMARSHALING_POLICY</c> takes values from the GLOBALOPT_UNMARSHALING_POLICY_VALUES enumeration.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/ne-objidlbase-globalopt_properties typedef enum tagGLOBALOPT_PROPERTIES
	// { COMGLB_EXCEPTION_HANDLING, COMGLB_APPID, COMGLB_RPC_THREADPOOL_SETTING, COMGLB_RO_SETTINGS, COMGLB_UNMARSHALING_POLICY,
	// COMGLB_PROPERTIES_RESERVED1, COMGLB_PROPERTIES_RESERVED2, COMGLB_PROPERTIES_RESERVED3 } GLOBALOPT_PROPERTIES;
	[PInvokeData("objidlbase.h", MSDNShortId = "NE:objidlbase.tagGLOBALOPT_PROPERTIES")]
	public enum GLOBALOPT_PROPERTIES
	{
		/// <summary>
		/// Defines COM exception-handling behavior.
		/// <para>
		/// By default, the COM runtime handles fatal exceptions raised during method invocations by returning the RPC_E_SERVERFAULT error
		/// code to the client. An application disables this behavior to allow exceptions to propagate to WER, which creates application
		/// process dumps and terminates the application. This prevents possible data corruption and allows an application vendor to debug
		/// the dumps.
		/// </para>
		/// <note type="note">Even if COM runtime exception handling is disabled, exceptions might not propagate to WER if there is another
		/// application-level exception handler in the process that handles the exception.</note>
		/// <para>For new applications, it is recommended that the COMGLB_EXCEPTION_HANDLING property be set to COMGLB_EXCEPTION_DONOT_HANDLE_ANY.</para>
		/// </summary>
		[CorrespondingType(typeof(GLOBALOPT_EH_VALUES))]
		COMGLB_EXCEPTION_HANDLING = 1,

		/// <summary>Sets the AppID for the process. This is the only supported property on Windows XP.</summary>
		[CorrespondingType(typeof(Guid))]
		COMGLB_APPID,

		/// <summary>
		/// <para>Sets the thread-pool behavior of the RPC runtime in the process.</para>
		/// <para>Possible values for the COMGLB_RPC_THREADPOOL_SETTING property in the Set method are:</para>
		/// <list type="bullet">
		/// <item>COMGLB_RPC_THREADPOOL_SETTING_PRIVATE_POOL: Instructs RPC to use a dedicated private thread pool.</item>
		/// </list>
		/// <para>Possible values for the COMGLB_RPC_THREADPOOL_SETTING property in the Query method are:</para>
		/// <list type="bullet">
		/// <item>COMGLB_RPC_THREADPOOL_SETTING_PRIVATE_POOL: RPC uses a dedicated private thread pool.</item>
		/// <item>COMGLB_RPC_THREADPOOL_SETTING_DEFAULT_POOL: RPC uses the system default thread pool.</item>
		/// </list>
		/// <para>
		/// RPC uses the system thread pool by default in Windows 7. Since the system thread pool is shared by multiple components in the
		/// process, COM and RPC operations may behave incorrectly if the thread pool state is corrupted by a component.
		/// </para>
		/// <para>
		/// The COMGLB_RPC_THREADPOOL_SETTING property can be used to change the RPC thread pool behavior. Changing the default behavior will
		/// incur a performance penalty since this causes RPC to use an extra thread. Therefore, care should be exercised when changing this
		/// setting. It is recommended that this setting is changed only for application compatibility reasons.
		/// </para>
		/// <note type="note">This property must be set immediately after COM is initialized in the process. If this property is set after
		/// performing any operations that cause COM to initialize the RPC channel (for example, marshaling or unmarshalling object
		/// references), the Set method will fail.</note>
		/// <para><strong>Note</strong> This property is only supported in Windows 7 and later versions of Windows.</para>
		/// </summary>
		[CorrespondingType(typeof(GLOBALOPT_RPCTP_VALUES))]
		COMGLB_RPC_THREADPOOL_SETTING,

		/// <summary>
		/// <para>Used for miscellaneous settings.</para>
		/// <para><strong>Note</strong> This property is only supported in Windows 8 and later versions of Windows.</para>
		/// </summary>
		[CorrespondingType(typeof(GLOBALOPT_RO_FLAGS), CorrespondingAction.Get)]
		COMGLB_RO_SETTINGS,

		/// <summary>
		/// Defines the policy that's applied in the CoUnmarshalInterface function.
		/// <para><strong>Note</strong> This property is only supported in Windows 7 and later versions of Windows.</para>
		/// </summary>
		[CorrespondingType(typeof(GLOBALOPT_UNMARSHALING_POLICY_VALUES))]
		COMGLB_UNMARSHALING_POLICY,

		/// <summary/>
		COMGLB_PROPERTIES_RESERVED1,

		/// <summary/>
		COMGLB_PROPERTIES_RESERVED2,

		/// <summary/>
		COMGLB_PROPERTIES_RESERVED3,
	}

	/// <summary>Values supporting <see cref="GLOBALOPT_PROPERTIES.COMGLB_EXCEPTION_HANDLING"/>.</summary>
	[PInvokeData("objidl.h")]
	public enum GLOBALOPT_EH_VALUES
	{
		/// <summary>This is the default behavior. This setting causes the COM runtime to handle fatal exceptions.</summary>
		COMGLB_EXCEPTION_HANDLE,

		/// <summary>Alias for COMGLB_EXCEPTION_DONOT_HANDLE. Supported in Windows 7 and later.</summary>
		COMGLB_EXCEPTION_DONOT_HANDLE_FATAL = 1,

		/// <summary>This causes the COM runtime not to handle fatal exceptions.</summary>
		COMGLB_EXCEPTION_DONOT_HANDLE = COMGLB_EXCEPTION_DONOT_HANDLE_FATAL,

		/// <summary>
		/// When set and a fatal exception occurs in a COM method, this causes the COM runtime to not handle the exception.
		/// <para>
		/// When set and a non-fatal exception occurs in a COM method, this causes the COM runtime to create a Windows Error Reporting (WER)
		/// dump and terminate the process.Supported in Windows 7 and later.
		/// </para>
		/// </summary>
		COMGLB_EXCEPTION_DONOT_HANDLE_ANY = 2
	}

	/// <summary>Values supporting <see cref="GLOBALOPT_PROPERTIES.COMGLB_RPC_THREADPOOL_SETTING"/>.</summary>
	[PInvokeData("objidl.h")]
	public enum GLOBALOPT_RPCTP_VALUES
	{
		/// <summary>RPC uses the system default thread pool.</summary>
		COMGLB_RPC_THREADPOOL_SETTING_DEFAULT_POOL,

		/// <summary>Instructs RPC to use a dedicated private thread pool.</summary>
		COMGLB_RPC_THREADPOOL_SETTING_PRIVATE_POOL = 1
	}

	/// <summary>Values supporting <see cref="GLOBALOPT_PROPERTIES.COMGLB_RO_SETTINGS"/>.</summary>
	[PInvokeData("objidl.h")]
	[Flags]
	public enum GLOBALOPT_RO_FLAGS
	{
		/// <summary>Remove touch messages from the message queue in the STA modal loop.</summary>
		COMGLB_STA_MODALLOOP_REMOVE_TOUCH_MESSAGES = 0x1,

		/// <summary>Input messages are removed in the STA modal loop when the thread's message queue is attached.</summary>
		COMGLB_STA_MODALLOOP_SHARED_QUEUE_REMOVE_INPUT_MESSAGES = 0x2,

		/// <summary>Input messages aren't removed in the STA modal loop when the thread's message queue is attached.</summary>
		COMGLB_STA_MODALLOOP_SHARED_QUEUE_DONOT_REMOVE_INPUT_MESSAGES = 0x4,

		/// <summary>
		/// Indicates that stubs in the current process are subjected to fast stub rundown behavior, which means that stubs are run down on
		/// termination of the client process, instead of waiting for normal cleanup timeouts to expire.
		/// </summary>
		COMGLB_FAST_RUNDOWN = 0x8,

		/// <summary>Reserved for future use.</summary>
		COMGLB_RESERVED1 = 0x10,

		/// <summary>Reserved for future use.</summary>
		COMGLB_RESERVED2 = 0x20,

		/// <summary>Reserved for future use.</summary>
		COMGLB_RESERVED3 = 0x40,

		/// <summary>
		/// Pointer input messages aren't removed in the STA modal loop when the thread's message queue is attached but are temporarily
		/// masked to avoid deadlocks arising from the attached queue.
		/// </summary>
		COMGLB_STA_MODALLOOP_SHARED_QUEUE_REORDER_POINTER_MESSAGES = 0x80,

		/// <summary>Reserved for future use.</summary>
		COMGLB_RESERVED4 = 0x100,

		/// <summary>Reserved for future use.</summary>
		COMGLB_RESERVED5 = 0x200,

		/// <summary>Reserved for future use.</summary>
		COMGLB_RESERVED6 = 0x400
	}

	/// <summary>Values supporting <see cref="GLOBALOPT_PROPERTIES.COMGLB_UNMARSHALING_POLICY"/>.</summary>
	[PInvokeData("objidl.h")]
	public enum GLOBALOPT_UNMARSHALING_POLICY_VALUES
	{
		/// <summary>
		/// Unmarshaling behavior is the same as versions before than Windows 8. EOAC_NO_CUSTOM_MARSHAL restrictions apply if this flag is
		/// set in CoInitializeSecurity. Otherwise, there are no restrictions. This is the default for processes that aren't in the app container.
		/// </summary>
		COMGLB_UNMARSHALING_POLICY_NORMAL,

		/// <summary>
		/// Unmarshaling allows only a system-trusted list of hardened unmarshalers and unmarshalers allowed per-process by the
		/// CoAllowUnmarshalerCLSID function. This is the default for processes in the app container.
		/// </summary>
		COMGLB_UNMARSHALING_POLICY_STRONG = 1,

		/// <summary>
		/// Unmarshaling data whose source is app container allows only a system-trusted list of hardened unmarshalers and unmarshalers
		/// allowed per-process by the CoAllowUnmarshalerCLSID function. Unmarshaling behavior for data with a source that's not app
		/// container is unchanged from previous versions.
		/// </summary>
		COMGLB_UNMARSHALING_POLICY_HYBRID = 2
	}

	/// <summary>Sets and queries global properties of the Component Object Model (COM) runtime.</summary>
	/// <remarks>
	/// <para>The following global properties of the COM runtime can be set and queried with this interface.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Values</term>
	/// </listheader>
	/// <item>
	/// <description>COMGLB_APPID</description>
	/// <description>The AppID for the process. This is the only supported property on Windows XP.</description>
	/// </item>
	/// <item>
	/// <description>COMGLB_EXCEPTION_HANDLING</description>
	/// <description>
	/// <para>Possible values for the COMGLB_EXCEPTION_HANDLING property are:</para>
	/// <list type="bullet">
	/// <item>COMGLB_EXCEPTION_HANDLE: This is the default behavior. This setting causes the COM runtime to handle fatal exceptions.</item>
	/// <item>COMGLB_EXCEPTION_DONOT_HANDLE: This causes the COM runtime not to handle fatal exceptions.</item>
	/// <item>COMGLB_EXCEPTION_DONOT_HANDLE_FATAL: Alias for COMGLB_EXCEPTION_DONOT_HANDLE. Supported in Windows 7 and later.</item>
	/// <item>
	/// COMGLB_EXCEPTION_DONOT_HANDLE_ANY: When set and a fatal exception occurs in a COM method, this causes the COM runtime to not handle
	/// the exception. <br/> When set and a non-fatal exception occurs in a COM method, this causes the COM runtime to create a Windows Error
	/// Reporting (WER) dump and terminate the process. Supported in Windows 7 and later.
	/// </item>
	/// </list>
	/// <para>
	/// By default, the COM runtime handles fatal exceptions raised during method invocations by returning the RPC_E_SERVERFAULT error code
	/// to the client. An application disables this behavior to allow exceptions to propagate to WER, which creates application process dumps
	/// and terminates the application. This prevents possible data corruption and allows an application vendor to debug the dumps.
	/// </para>
	/// <para>
	/// <note type="note">Even if COM runtime exception handling is disabled, exceptions might not propagate to WER if there is another
	/// application-level exception handler in the process that handles the exception.</note>
	/// </para>
	/// <para>For new applications, it is recommended that the COMGLB_EXCEPTION_HANDLING property be set to COMGLB_EXCEPTION_DONOT_HANDLE_ANY.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>COMGLB_RPC_THREADPOOL_SETTING</description>
	/// <description>
	/// <para>Possible values for the COMGLB_RPC_THREADPOOL_SETTING property in the Set method are:</para>
	/// <list type="bullet">
	/// <item>COMGLB_RPC_THREADPOOL_SETTING_PRIVATE_POOL: Instructs RPC to use a dedicated private thread pool.</item>
	/// </list>
	/// <para>Possible values for the COMGLB_RPC_THREADPOOL_SETTING property in the Query method are:</para>
	/// <list type="bullet">
	/// <item>COMGLB_RPC_THREADPOOL_SETTING_PRIVATE_POOL: RPC uses a dedicated private thread pool.</item>
	/// <item>COMGLB_RPC_THREADPOOL_SETTING_DEFAULT_POOL: RPC uses the system default thread pool.</item>
	/// </list>
	/// <para>
	/// RPC uses the system thread pool by default in WindowsÂ 7. Since the system thread pool is shared by multiple components in the
	/// process, COM and RPC operations may behave incorrectly if the thread pool state is corrupted by a component. The
	/// COMGLB_RPC_THREADPOOL_SETTING property can be used to change the RPC thread pool behavior. Changing the default behavior will incur a
	/// performance penalty since this causes RPC to use an extra thread. Therefore, care should be exercised when changing this setting. It
	/// is recommended that this setting is changed only for application compatibility reasons.
	/// </para>
	/// <para><br/></para>
	/// <para>
	/// <note type="note">This property must be set immediately after COM is initialized in the process. If this property is set after
	/// performing any operations that cause COM to initialize the RPC channel (for example, marshaling or unmarshalling object references),
	/// the Set method will fail.</note>
	/// </para>
	/// <para><br/></para>
	/// <para><strong>Note:</strong> This property is only supported in WindowsÂ 7 and later versions of Windows.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>COMGLB_RO_SETTINGS</description>
	/// <description>
	/// <para>Possible values for the COMGLB_RO_SETTINGS property are:</para>
	/// <list type="bullet">
	/// <item>
	/// COMGLB_FAST_RUNDOWN: Indicates that stubs in the current process are subjected to fast stub rundown behavior, which means that stubs
	/// are run down on termination of the client process, instead of waiting for normal cleanup timeouts to expire.
	/// </item>
	/// <item>COMGLB_STA_MODALLOOP_REMOVE_TOUCH_MESSAGES: Remove touch messages from the message queue in the STA modal loop.</item>
	/// <item>
	/// COMGLB_STA_MODALLOOP_SHARED_QUEUE_REMOVE_INPUT_MESSAGES: Input messages are removed in the STA modal loop when the thread's message
	/// queue is attached.
	/// </item>
	/// <item>
	/// COMGLB_STA_MODALLOOP_SHARED_QUEUE_DONOT_REMOVE_INPUT_MESSAGES: Input messages aren't removed in the STA modal loop when the thread's
	/// message queue is attached.
	/// </item>
	/// <item>
	/// COMGLB_STA_MODALLOOP_SHARED_QUEUE_REORDER_POINTER_MESSAGES: Pointer input messages aren't removed in the STA modal loop when the
	/// thread's message queue is attached but are temporarily masked to avoid deadlocks arising from the attached queue.
	/// </item>
	/// <item>COMGLB_RESERVED1: Reserved for future use.</item>
	/// <item>COMGLB_RESERVED2: Reserved for future use.</item>
	/// <item>COMGLB_RESERVED3: Reserved for future use.</item>
	/// </list>
	/// <para><strong>Note</strong> This property is only supported in WindowsÂ 8 and later versions of Windows.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>COMGLB_UNMARSHALING_POLICY</description>
	/// <description>
	/// <para>Possible values for the COMGLB_UNMARSHALING_POLICY property are:</para>
	/// <list type="bullet">
	/// <item>
	/// COMGLB_UNMARSHALING_POLICY_NORMAL: Unmarshaling behavior is the same as versions before than Windows 8. EOAC_NO_CUSTOM_MARSHAL
	/// restrictions apply if this flag is set in CoInitializeSecurity. Otherwise, there are no restrictions. This is the default for
	/// processes that aren't in the app container.
	/// </item>
	/// <item>
	/// COMGLB_UNMARSHALING_POLICY_STRONG: Unmarshaling allows only a system-trusted list of hardened unmarshalers and unmarshalers allowed
	/// per-process by the CoAllowUnmarshalerCLSID function. This is the default for processes in the app container.
	/// </item>
	/// <item>
	/// COMGLB_UNMARSHALING_POLICY_HYBRID: Unmarshaling data whose source is app container allows only a system-trusted list of hardened
	/// unmarshalers and unmarshalers allowed per-process by the CoAllowUnmarshalerCLSID function. Unmarshaling behavior for data with a
	/// source that's not app container is unchanged from previous versions.
	/// </item>
	/// </list>
	/// <para><font color="#333333"><strong>Note</strong></font> This property is only supported in WindowsÂ 8 and later versions of Windows.</para>
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// It's important for applications that detect crashes and other exceptions that might be generated while executing inbound COM calls,
	/// for example a call on a local server or when executing the IDropTarget::Drop method, to set COMGLB_EXCEPTION_HANDLING to
	/// COMGLB_EXCEPTION_DONOT_HANDLE to disable COM behavior of catching exceptions. Failure to do this can lead to corrupt process state,
	/// for example locks held when these exceptions are thrown are abandoned, and the process could enter an inconsistent state.
	/// </para>
	/// <para>All such applications should execute this code at startup.</para>
	/// <para>
	/// <span id="cbc_1" codelanguage="CSharp" x-lang="CSharp"></span><div class="highlight-title"><span tabindex="0"
	/// class="highlight-copycode"></span> C#</div><div class="code"><pre xml:space="preserve">IGlobalOptions *pGlobalOptions; <br/> hr =
	/// CoCreateInstance(CLSID_GlobalOptions, NULL, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&amp;pGlobalOptions)); <br/> if (SUCCEEDED(hr)) <br/>{
	/// <br/> hr = pGlobalOptions-&gt;Set(COMGLB_EXCEPTION_HANDLING, COMGLB_EXCEPTION_DONOT_HANDLE); <br/> pGlobalOptions-&gt;Release(); <br/>}</pre></div>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-iglobaloptions
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IGlobalOptions")]
	[ComImport, Guid("0000015B-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(GlobalOptions))]
	public interface IGlobalOptions
	{
		/// <summary>Sets the specified global property of the COM runtime.</summary>
		/// <param name="dwProperty">
		/// The global property of the COM runtime. For a list of properties that can be set with this method, see IGlobalOptions.
		/// </param>
		/// <param name="dwValue">The value of the property.</param>
		/// <returns>The return value is S_OK if the property was set successfully.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iglobaloptions-set HRESULT Set( GLOBALOPT_PROPERTIES
		// dwProperty, ULONG_PTR dwValue );
		[PreserveSig]
		HRESULT Set([In] GLOBALOPT_PROPERTIES dwProperty, [In] IntPtr dwValue);

		/// <summary>Queries the specified global property of the COM runtime.</summary>
		/// <param name="dwProperty">
		/// The global property of the COM runtime. For a list of properties that can be set with this method, see IGlobalOptions.
		/// </param>
		/// <param name="pdwValue">The value of the property.</param>
		/// <returns>The return value is S_OK if the property is queried successfully.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-iglobaloptions-query HRESULT Query(
		// GLOBALOPT_PROPERTIES dwProperty, ULONG_PTR *pdwValue );
		[PreserveSig]
		HRESULT Query([In] GLOBALOPT_PROPERTIES dwProperty, out IntPtr pdwValue);
	}

	/// <summary>Sets the specified global property of the COM runtime.</summary>
	/// <typeparam name="T">The set value type.</typeparam>
	/// <param name="pgo">The <see cref="IGlobalOptions"/> instance.</param>
	/// <param name="dwProperty">
	/// The global property of the COM runtime. For a list of properties that can be set with this method, see IGlobalOptions.
	/// </param>
	/// <param name="dwValue">The value of the property.</param>
	/// <returns>The return value is S_OK if the property was set successfully.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iglobaloptions-set HRESULT Set( GLOBALOPT_PROPERTIES dwProperty,
	// ULONG_PTR dwValue );
	public static HRESULT Set<T>(this IGlobalOptions pgo, [In] GLOBALOPT_PROPERTIES dwProperty, [In] T dwValue) where T : struct, Enum =>
		pgo.Set(dwProperty, (IntPtr)Convert.ToInt32(dwValue));

	/// <summary>Queries the specified global property of the COM runtime.</summary>
	/// <typeparam name="T">The query value type.</typeparam>
	/// <param name="pgo">The <see cref="IGlobalOptions"/> instance.</param>
	/// <param name="dwProperty">
	/// The global property of the COM runtime. For a list of properties that can be set with this method, see IGlobalOptions.
	/// </param>
	/// <param name="pdwValue">The value of the property.</param>
	/// <returns>The return value is S_OK if the property is queried successfully.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-iglobaloptions-query HRESULT Query(
	// GLOBALOPT_PROPERTIES dwProperty, ULONG_PTR *pdwValue );
	public static HRESULT Query<T>(this IGlobalOptions pgo, [In] GLOBALOPT_PROPERTIES dwProperty, out T pdwValue) where T : struct, Enum
	{
		var hr = pgo.Query(dwProperty, out var p);
		pdwValue = hr.Succeeded ? (T)Enum.ToObject(typeof(T), p.ToInt32()) : default;
		return hr;
	}

	/// <summary>Class object for IGlobalOptions (CLSID_GlobalOptions).</summary>
	[ComImport, Guid("0000034B-0000-0000-C000-000000000046"), ClassInterface(ClassInterfaceType.None)]
	public class GlobalOptions { }
}