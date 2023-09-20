using Vanara.PInvoke;
using static Vanara.PInvoke.WinINet;

namespace Vanara.Network;

/// <summary>Provides access to proxy settings for an internet connection.</summary>
/// <seealso cref="System.IDisposable"/>
public class InternetProxyOptions : IDisposable
{
	private SafeHINTERNET hInet = SafeHINTERNET.Null;

	/// <summary>
	/// Initializes a new instance of the <see cref="InternetProxyOptions"/> class that provides access to system options for the local machine.
	/// </summary>
	public InternetProxyOptions() { }

	/// <summary>
	/// Initializes a new instance of the <a onclick="return false;" href="InternetProxyOptions"
	/// originaltag="see">InternetProxyOptions</a> class by creating a session with options.
	/// </summary>
	/// <param name="agentName">
	/// String that specifies the name of the application or entity calling the functions. This name is used as the user agent in the
	/// HTTP protocol.
	/// </param>
	/// <param name="manualProxyUrl">
	/// String that specifies the name of the proxy server(s) to use. Do not use an empty string, because it will be used as the proxy
	/// name. Only CERN type proxies (HTTP only) and the TIS FTP gateway (FTP only) are recognized.
	/// </param>
	/// <param name="proxyBypassEntries">
	/// An optional list of host names or IP addresses, or both, that should not be routed through the proxy. The list can contain
	/// wildcards. Do not use an empty string, because it will be used as a proxy bypass. If this parameter specifies the
	/// "&lt;local&gt;" macro, the function bypasses the proxy for any host name that does not contain a period.
	/// <para>
	/// By default, the proxy will bypass requests that use the host names "localhost", "loopback", "127.0.0.1", or "[::1]". This
	/// behavior exists because a remote proxy server typically will not resolve these addresses properly.
	/// </para>
	/// </param>
	/// <param name="offline">
	/// If <see langword="true"/>, does not make network requests. All entities are returned from the cache. If the requested item is
	/// not in the cache, a suitable error is returned.
	/// </param>
	/// <param name="asyncOnly">If <see langword="true"/>, makes only asynchronous requests.</param>
	public InternetProxyOptions(string agentName, string manualProxyUrl, string[]? proxyBypassEntries = null, bool offline = false, bool asyncOnly = false)
	{
		InternetApiFlags flags = 0;
		if (offline) flags |= InternetApiFlags.INTERNET_FLAG_OFFLINE;
		if (asyncOnly) flags |= InternetApiFlags.INTERNET_FLAG_ASYNC;
		hInet = InternetOpen(agentName, InternetOpenType.INTERNET_OPEN_TYPE_PROXY, manualProxyUrl, proxyBypassEntries is null ? null : string.Join(";", proxyBypassEntries), flags);
		Win32Error.ThrowLastErrorIfInvalid(hInet);
	}

	//public int DisplayInternetControlPanel(HWND windowHandle) => LaunchInternetControlPanel(windowHandle);

	/// <summary>Gets or sets a value indicating whether the connection automatically detects settings.</summary>
	/// <value><see langword="true"/> if the connection automatically detects settings; otherwise, <see langword="false"/>.</value>
	public bool AutomaticallyDetectSettings
	{
		get => HasProxyFlag(PER_CONN_FLAGS.PROXY_TYPE_AUTO_DETECT);
		set => SetOptionFlag(PER_CONN_FLAGS.PROXY_TYPE_AUTO_DETECT, value);
	}

	/// <summary>Gets a value indicating whether this session has any proxy set.</summary>
	/// <value><see langword="true"/> if this session has a proxy set; otherwise, <see langword="false"/>.</value>
	public bool HasProxy => AutomaticallyDetectSettings || SetupScriptUrl != null || ManualProxyUrl != null;

	/// <summary>Gets or sets a string containing the proxy server.</summary>
	public string? ManualProxyUrl
	{
		get => HasProxyFlag(PER_CONN_FLAGS.PROXY_TYPE_PROXY) ? GetOption<string>(INTERNET_PER_CONN_OPTION_ID.INTERNET_PER_CONN_PROXY_SERVER) : null;
		set
		{
			SetOptionString(INTERNET_PER_CONN_OPTION_ID.INTERNET_PER_CONN_PROXY_SERVER, value);
			SetOptionFlag(PER_CONN_FLAGS.PROXY_TYPE_PROXY, value != null);
		}
	}

	/// <summary>Gets or sets an array of URLs that do not use the proxy server.</summary>
	public string[]? ProxyBypassEntries
	{
		get => GetOption<string>(INTERNET_PER_CONN_OPTION_ID.INTERNET_PER_CONN_PROXY_BYPASS)?.Split(new[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
		set => SetOptionString(INTERNET_PER_CONN_OPTION_ID.INTERNET_PER_CONN_PROXY_BYPASS, value is null ? null : string.Join(";", value));
	}

	/// <summary>Gets or sets a string containing the URL to the automatic configuration script.</summary>
	public string? SetupScriptUrl
	{
		get => HasProxyFlag(PER_CONN_FLAGS.PROXY_TYPE_AUTO_PROXY_URL) ? GetOption<string>(INTERNET_PER_CONN_OPTION_ID.INTERNET_PER_CONN_AUTOCONFIG_URL) : null;
		set
		{
			SetOptionString(INTERNET_PER_CONN_OPTION_ID.INTERNET_PER_CONN_AUTOCONFIG_URL, value);
			SetOptionFlag(PER_CONN_FLAGS.PROXY_TYPE_AUTO_PROXY_URL, value != null);
		}
	}

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose() => hInet?.Dispose();

	/// <summary>
	/// Notifies the system that the registry settings have been changed so that it verifies the settings on the next call to InternetConnect.
	/// </summary>
	public void NotifyInternetOptionSettingsChanged() => Win32Error.ThrowLastErrorIfFalse(InternetSetOption(hInet, InternetOptionFlags.INTERNET_OPTION_SETTINGS_CHANGED));

	/// <summary>Causes the proxy data to be reread from the registry for a handle.</summary>
	public bool RefreshProxyData() => InternetSetOption(hInet, InternetOptionFlags.INTERNET_OPTION_REFRESH);

	private T GetOption<T>(INTERNET_PER_CONN_OPTION_ID pco)
	{
		var getType = typeof(T);
		if (getType.IsEnum) getType = typeof(uint);
		if (!CorrespondingTypeAttribute.CanGet(pco, getType))
			throw new InvalidOperationException("Invalid output type specified.");

		var ico = new INTERNET_PER_CONN_OPTION { dwOption = pco };
		using var pIco = new SafeCoTaskMemStruct<INTERNET_PER_CONN_OPTION>(ico, Marshal.SizeOf(typeof(INTERNET_PER_CONN_OPTION)) + (Kernel32.MAX_PATH * StringHelper.GetCharSize()));

		var perConnOptList = INTERNET_PER_CONN_OPTION_LIST.Default;
		perConnOptList.dwOptionCount = 1;
		perConnOptList.pOptions = pIco;
		using var pPerConnOptList = SafeCoTaskMemHandle.CreateFromStructure(perConnOptList);
		int size = pPerConnOptList.Size + pIco.Size;

		Win32Error.ThrowLastErrorIfFalse(InternetQueryOption(hInet, InternetOptionFlags.INTERNET_OPTION_PER_CONNECTION_OPTION, pPerConnOptList, ref size));
		ico = pIco.Value;
		if (getType == typeof(string))
			return (T)(object)ico.Value.pszValue.ToString();
		if (getType == typeof(FILETIME))
			return (T)(object)ico.Value.ftValue;
		return (T)(object)ico.Value.dwValue;
	}

	private bool HasProxyFlag(PER_CONN_FLAGS proxyFlagToCheck) => GetOption<PER_CONN_FLAGS>(INTERNET_PER_CONN_OPTION_ID.INTERNET_PER_CONN_FLAGS).IsFlagSet(proxyFlagToCheck);

	private void SetOptionFlag(PER_CONN_FLAGS flagToSet, bool enable)
	{
		var currentFlags = GetOption<PER_CONN_FLAGS>(INTERNET_PER_CONN_OPTION_ID.INTERNET_PER_CONN_FLAGS);
		var option = new INTERNET_PER_CONN_OPTION { dwOption = INTERNET_PER_CONN_OPTION_ID.INTERNET_PER_CONN_FLAGS };
		option.Value.dwValue = (uint)currentFlags.SetFlags(flagToSet, enable);
		SetOptions(new[] { option });
	}

	private void SetOptions(INTERNET_PER_CONN_OPTION[] options)
	{
		using var pOptions = new PinnedObject(options);
		var optionList = new INTERNET_PER_CONN_OPTION_LIST
		{
			dwSize = (uint)Marshal.SizeOf(typeof(INTERNET_PER_CONN_OPTION_LIST)),
			dwOptionCount = (uint)options.Length,
			pOptions = pOptions
		};
		Win32Error.ThrowLastErrorIfFalse(InternetSetOption(hInet, InternetOptionFlags.INTERNET_OPTION_PER_CONNECTION_OPTION, optionList));
		NotifyInternetOptionSettingsChanged();
	}

	private void SetOptionString(INTERNET_PER_CONN_OPTION_ID optionId, string? value)
	{
		using var pProxy = new SafeCoTaskMemString(value, CharSet.Auto);
		var option = new INTERNET_PER_CONN_OPTION { dwOption = optionId };
		option.Value.pszValue = (IntPtr)pProxy;
		SetOptions(new[] { option });
	}
}