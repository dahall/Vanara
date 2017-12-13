using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	// TODO: Ready this class for library
	internal static class WinInetHelper
	{
		private static IntPtr VarPtr(object e)
		{
			var GC = GCHandle.Alloc(e, GCHandleType.Pinned);
			var gc = GC.AddrOfPinnedObject();
			GC.Free();
			return gc;
		}

		public static bool SetInternetProxy(bool enableProxy, string proxyServerString, string proxyBypass,
			bool autoDetectSettings, bool useAutoConfigureScript, string autoConfigureScript)
		{
			var options = new InternetPerConnectionOption[4];
			options[0].option = PerConnectionOption.INTERNET_PER_CONNECTION_FLAGS;
			if (autoDetectSettings)
			{
				options[0].value.valueInt |= (int)PerConnectionFlags.PROXY_TYPE_AUTO_DETECT;
			}
			if (useAutoConfigureScript)
			{
				options[0].value.valueInt |= (int)PerConnectionFlags.PROXY_TYPE_AUTO_PROXY_URL;
			}
			if (enableProxy)
			{
				options[0].value.valueInt |= (int)PerConnectionFlags.PROXY_TYPE_PROXY;
			}
			else
			{
				options[0].value.valueInt |= (int)PerConnectionFlags.PROXY_TYPE_DIRECT;
			}

			options[1].option = PerConnectionOption.INTERNET_PER_CONNECTION_AUTOCONFIG_URL;
			options[1].value.valueInt = Marshal.StringToHGlobalAuto(autoConfigureScript).ToInt32();

			options[2].option = PerConnectionOption.INTERNET_PER_CONNECTION_PROXY_SERVER;
			options[2].value.valueInt = Marshal.StringToHGlobalAuto(proxyServerString).ToInt32();

			options[3].option = PerConnectionOption.INTERNET_PER_CONNECTION_PROXY_BYPASS;
			options[3].value.valueInt = Marshal.StringToHGlobalAuto(proxyBypass).ToInt32();
			// Marshal.StringToCoTaskMemAuto(proxyBypass);


			return CallInternetSetOption(options);
		}

		public static bool SetAutoConfigURL(string autoConfigScriptURL)
		{
			var options = new InternetPerConnectionOption[1];
			options[0] = new InternetPerConnectionOption();
			options[0].option = PerConnectionOption.INTERNET_PER_CONNECTION_AUTOCONFIG_URL;
			options[0].value.valueInt = Marshal.StringToHGlobalAuto(autoConfigScriptURL).ToInt32();
			return CallInternetSetOption(options);
		}

		public static bool SwitchAutoDetectProxy(bool newValue)
		{
			return SwitchInternetProxy(PerConnectionFlags.PROXY_TYPE_AUTO_DETECT, newValue);
		}

		public static bool SwitchAutoConfigProxy(bool newValue)
		{
			return SwitchInternetProxy(PerConnectionFlags.PROXY_TYPE_AUTO_PROXY_URL, newValue);
		}

		public static bool SwitchUseProxy(bool newValue)
		{
			return SwitchInternetProxy(PerConnectionFlags.PROXY_TYPE_PROXY, newValue);
		}

		private static bool SwitchInternetProxy(PerConnectionFlags proxyFlagToSet, bool enableProxy)
		{
			var currentOption = GetInternetConnectionOption(PerConnectionOption.INTERNET_PER_CONNECTION_FLAGS);

			if (enableProxy)
			{
				//To add this setting do a bitwise OR against the current value
				//(compare the value bit by bit if either of the values has that bit set leave it set)
				//this will essentially turn on this portion of the proxy flag.
				currentOption.value.valueInt |= (int)proxyFlagToSet;
			}
			else
			{
				//To remove this setting do a bitwise XOR against the current value
				//(compare the value bit by bit if one and only one of the two has that bit set leave it set)
				//this will essentially turn off this portion of the proxy flags.
				currentOption.value.valueInt ^= (int)proxyFlagToSet;
			}

			var options = new InternetPerConnectionOption[1];
			options[0] = currentOption;
			return CallInternetSetOption(options);
		}

		public static bool IsAnyProxy() { return IsUseProxy() | IsAutoDetectProxy() | IsAutoConfigProxy(); }

		public static bool IsUseProxy() { return CheckProxyFlag(PerConnectionFlags.PROXY_TYPE_PROXY); }

		public static bool IsAutoDetectProxy() { return CheckProxyFlag(PerConnectionFlags.PROXY_TYPE_AUTO_DETECT); }

		public static bool IsAutoConfigProxy() { return CheckProxyFlag(PerConnectionFlags.PROXY_TYPE_AUTO_PROXY_URL); }

		private static bool CheckProxyFlag(PerConnectionFlags proxyFlagToCheck)
		{
			var returnOption = GetInternetConnectionOption(PerConnectionOption.INTERNET_PER_CONNECTION_FLAGS);

			// Since this returns an int that contains the value of many flags
			// we need to AND the value against what we're looking for and 
			// then compare it against our value if it returns true it was set.
			var andValue = returnOption.value.valueInt & (int)proxyFlagToCheck;
			return andValue == (int)proxyFlagToCheck;
		}

		public static string GetAutoConfigURL()
		{
			return GetProxyString(PerConnectionOption.INTERNET_PER_CONNECTION_AUTOCONFIG_URL);
		}

		public static string GetProxyServerURL()
		{
			return GetProxyString(PerConnectionOption.INTERNET_PER_CONNECTION_PROXY_SERVER);
		}

		public static string GetBypassProxy()
		{
			return GetProxyString(PerConnectionOption.INTERNET_PER_CONNECTION_PROXY_BYPASS);
		}

		private static string GetProxyString(PerConnectionOption optionToCheck)
		{
			var returnOption = GetInternetConnectionOption(optionToCheck);
			var proxyInfo = Marshal.PtrToStringAuto(returnOption.value.valuePtr);
			return proxyInfo;
		}

		private static bool CallInternetSetOption(InternetPerConnectionOption[] options)
		{
			var optionList = new InternetPerConnectionOptionList();
			optionList.size = Marshal.SizeOf(optionList);
			optionList.connection = IntPtr.Zero; //Default Connection
			optionList.optionCount = options.Length;
			optionList.optionError = 0;
			optionList.options = VarPtr(options);


			var optionListSize = Marshal.SizeOf(optionList);
			var optionListPtr = Marshal.AllocCoTaskMem(optionListSize);
			Marshal.StructureToPtr(optionList, optionListPtr, true);

			bool iReturn;
			iReturn = WinInet.InternetSetOption(IntPtr.Zero, (int)InternetOption.INTERNET_OPTION_PER_CONNECTION_OPTION, optionListPtr,
				Marshal.SizeOf(optionList));
			if (iReturn == false)
			{
				var exception = new Win32Exception(Marshal.GetLastWin32Error());
				throw exception;
			}
			iReturn = InternetOptionSettingsChanged();
			//if (iReturn == true)
			//{
			//    iReturn = InternetOptionRefresh();
			//}

			// free the COM memory
			Marshal.FreeCoTaskMem(optionListPtr);

			return iReturn;
		}

		private static InternetPerConnectionOption GetInternetConnectionOption(PerConnectionOption pco)
		{
			//Allocate the list and option.
			var perConnOptList = new InternetPerConnectionOptionList();
			var ico = new InternetPerConnectionOption();
			//pin the option structure
			var gch = GCHandle.Alloc(ico, GCHandleType.Pinned);
			//initialize the option for the data we want
			ico.option = pco;
			//Initialize the option list for the default connection or LAN.
			var listSize = Marshal.SizeOf(perConnOptList);
			perConnOptList.size = listSize;
			perConnOptList.connection = IntPtr.Zero;
			perConnOptList.optionCount = 1;
			perConnOptList.optionError = 0;
			// figure out sizes & offsets
			var icoSize = Marshal.SizeOf(ico);
			var optionTotalSize = icoSize;
			// alloc enough memory for the option
			perConnOptList.options =
				Marshal.AllocCoTaskMem(icoSize);

			var icoOffset = (long)perConnOptList.options + icoSize;
			// Make pointer from the structure
			var optionListPtr = perConnOptList.options;
			Marshal.StructureToPtr(ico, optionListPtr, false);

			//Make the query
			if (InternetQueryOption(
				IntPtr.Zero,
				(int)InternetOption.INTERNET_OPTION_PER_CONNECTION_OPTION, //75
				ref perConnOptList,
				ref listSize))
			{
				//retrieve the value
				ico =
					(InternetPerConnectionOption)Marshal.PtrToStructure(perConnOptList.options,
						typeof(InternetPerConnectionOption));
			}
			// free the COM memory
			Marshal.FreeCoTaskMem(perConnOptList.options);
			//unpin the structs
			gch.Free();

			return ico;
		}

		public static bool InternetOptionSettingsChanged()
		{
			return WinInet.InternetSetOption(IntPtr.Zero, (int)InternetOption.INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
		}

		public static bool InternetOptionRefresh()
		{
			return WinInet.InternetSetOption(IntPtr.Zero, (int)InternetOption.INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
		}

		public static int DisplayInternetControlPanel(IntPtr windowHandle)
		{
			return LaunchInternetControlPanel(windowHandle);
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private struct INTERNET_PER_CONNECTION_OPTION
		{
			public readonly int option;
			public readonly int valueInt;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private struct INTERNET_PER_CONNECTION_OPTION_LIST
		{
			[MarshalAs(UnmanagedType.U4)] public readonly int size;
			[MarshalAs(UnmanagedType.LPTStr)] public readonly string connection;
			[MarshalAs(UnmanagedType.U4)] public readonly int optionCount;
			[MarshalAs(UnmanagedType.U4)] public readonly int optionError;
			[MarshalAs(UnmanagedType.LPArray)] public readonly INTERNET_PER_CONNECTION_OPTION[] options;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private struct InternetPerConnectionOptionList
		{
			public int size; // size of the INTERNET_PER_CONNECTION_OPTION_LIST struct
			public IntPtr connection; // connection name to set/query options
			public int optionCount; // number of options to set/query
			public int optionError; // on error, which option failed
			//[MarshalAs(UnmanagedType.LPArray)]
			//public InternetPerConnectionOption[] options;
			public IntPtr options;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private struct InternetPerConnectionOption
		{
			private static readonly int Size;
			public PerConnectionOption option;
			public InternetPerConnectionOptionValue value;
			static InternetPerConnectionOption() { Size = Marshal.SizeOf(typeof(InternetPerConnectionOption)); }

			// Nested Types
			[StructLayout(LayoutKind.Explicit)]
			public struct InternetPerConnectionOptionValue
			{
				// Fields
				[FieldOffset(0)] public readonly FILETIME m_FileTime;
				[FieldOffset(0)] public int valueInt;
				[FieldOffset(0)] public readonly IntPtr valuePtr;
			}
		}

		//
		// options manifests for Internet{Query|Set}Option
		//
		private enum InternetOption
		{
			INTERNET_OPTION_CALLBACK = 1,
			INTERNET_OPTION_CONNECT_TIMEOUT = 2,
			INTERNET_OPTION_CONNECT_RETRIES = 3,
			INTERNET_OPTION_CONNECT_BACKOFF = 4,
			INTERNET_OPTION_SEND_TIMEOUT = 5,
			INTERNET_OPTION_CONTROL_SEND_TIMEOUT = INTERNET_OPTION_SEND_TIMEOUT,
			INTERNET_OPTION_RECEIVE_TIMEOUT = 6,
			INTERNET_OPTION_CONTROL_RECEIVE_TIMEOUT = INTERNET_OPTION_RECEIVE_TIMEOUT,
			INTERNET_OPTION_DATA_SEND_TIMEOUT = 7,
			INTERNET_OPTION_DATA_RECEIVE_TIMEOUT = 8,
			INTERNET_OPTION_HANDLE_TYPE = 9,
			INTERNET_OPTION_LISTEN_TIMEOUT = 11,
			INTERNET_OPTION_READ_BUFFER_SIZE = 12,
			INTERNET_OPTION_WRITE_BUFFER_SIZE = 13,

			INTERNET_OPTION_ASYNC_ID = 15,
			INTERNET_OPTION_ASYNC_PRIORITY = 16,

			INTERNET_OPTION_PARENT_HANDLE = 21,
			INTERNET_OPTION_KEEP_CONNECTION = 22,
			INTERNET_OPTION_REQUEST_FLAGS = 23,
			INTERNET_OPTION_EXTENDED_ERROR = 24,

			INTERNET_OPTION_OFFLINE_MODE = 26,
			INTERNET_OPTION_CACHE_STREAM_HANDLE = 27,
			INTERNET_OPTION_USERNAME = 28,
			INTERNET_OPTION_PASSWORD = 29,
			INTERNET_OPTION_ASYNC = 30,
			INTERNET_OPTION_SECURITY_FLAGS = 31,
			INTERNET_OPTION_SECURITY_CERTIFICATE_STRUCT = 32,
			INTERNET_OPTION_DATAFILE_NAME = 33,
			INTERNET_OPTION_URL = 34,
			INTERNET_OPTION_SECURITY_CERTIFICATE = 35,
			INTERNET_OPTION_SECURITY_KEY_BITNESS = 36,
			INTERNET_OPTION_REFRESH = 37,
			INTERNET_OPTION_PROXY = 38,
			INTERNET_OPTION_SETTINGS_CHANGED = 39,
			INTERNET_OPTION_VERSION = 40,
			INTERNET_OPTION_USER_AGENT = 41,
			INTERNET_OPTION_END_BROWSER_SESSION = 42,
			INTERNET_OPTION_PROXY_USERNAME = 43,
			INTERNET_OPTION_PROXY_PASSWORD = 44,
			INTERNET_OPTION_CONTEXT_VALUE = 45,
			INTERNET_OPTION_CONNECT_LIMIT = 46,
			INTERNET_OPTION_SECURITY_SELECT_CLIENT_CERT = 47,
			INTERNET_OPTION_POLICY = 48,
			INTERNET_OPTION_DISCONNECTED_TIMEOUT = 49,
			INTERNET_OPTION_CONNECTED_STATE = 50,
			INTERNET_OPTION_IDLE_STATE = 51,
			INTERNET_OPTION_OFFLINE_SEMANTICS = 52,
			INTERNET_OPTION_SECONDARY_CACHE_KEY = 53,
			INTERNET_OPTION_CALLBACK_FILTER = 54,
			INTERNET_OPTION_CONNECT_TIME = 55,
			INTERNET_OPTION_SEND_THROUGHPUT = 56,
			INTERNET_OPTION_RECEIVE_THROUGHPUT = 57,
			INTERNET_OPTION_REQUEST_PRIORITY = 58,
			INTERNET_OPTION_HTTP_VERSION = 59,
			INTERNET_OPTION_RESET_URLCACHE_SESSION = 60,
			INTERNET_OPTION_ERROR_MASK = 62,
			INTERNET_OPTION_FROM_CACHE_TIMEOUT = 63,
			INTERNET_OPTION_BYPASS_EDITED_ENTRY = 64,
			INTERNET_OPTION_DIAGNOSTIC_SOCKET_INFO = 67,
			INTERNET_OPTION_CODEPAGE = 68,
			INTERNET_OPTION_CACHE_TIMESTAMPS = 69,
			INTERNET_OPTION_DISABLE_AUTODIAL = 70,
			INTERNET_OPTION_MAX_CONNS_PER_SERVER = 73,
			INTERNET_OPTION_MAX_CONNS_PER_1_0_SERVER = 74,
			INTERNET_OPTION_PER_CONNECTION_OPTION = 75,
			INTERNET_OPTION_DIGEST_AUTH_UNLOAD = 76,
			INTERNET_OPTION_IGNORE_OFFLINE = 77,
			INTERNET_OPTION_IDENTITY = 78,
			INTERNET_OPTION_REMOVE_IDENTITY = 79,
			INTERNET_OPTION_ALTER_IDENTITY = 80,
			INTERNET_OPTION_SUPPRESS_BEHAVIOR = 81,
			INTERNET_OPTION_AUTODIAL_MODE = 82,
			INTERNET_OPTION_AUTODIAL_CONNECTION = 83,
			INTERNET_OPTION_CLIENT_CERT_CONTEXT = 84,
			INTERNET_OPTION_AUTH_FLAGS = 85,
			INTERNET_OPTION_COOKIES_3RD_PARTY = 86,
			INTERNET_OPTION_DISABLE_PASSPORT_AUTH = 87,
			INTERNET_OPTION_SEND_UTF8_SERVERNAME_TO_PROXY = 88,
			INTERNET_OPTION_EXEMPT_CONNECTION_LIMIT = 89,
			INTERNET_OPTION_ENABLE_PASSPORT_AUTH = 90,

			INTERNET_OPTION_HIBERNATE_INACTIVE_WORKER_THREADS = 91,
			INTERNET_OPTION_ACTIVATE_WORKER_THREADS = 92,
			INTERNET_OPTION_RESTORE_WORKER_THREAD_DEFAULTS = 93,
			INTERNET_OPTION_SOCKET_SEND_BUFFER_LENGTH = 94,
			INTERNET_OPTION_PROXY_SETTINGS_CHANGED = 95,

			INTERNET_OPTION_DATAFILE_EXT = 96,

			INTERNET_FIRST_OPTION = INTERNET_OPTION_CALLBACK,
			INTERNET_LAST_OPTION = INTERNET_OPTION_DATAFILE_EXT
		}

		//
		// Options used in INTERNET_PER_CONNECTION_OPTON struct
		//
		private enum PerConnectionOption
		{
			INTERNET_PER_CONNECTION_FLAGS = 1,
			// Sets or retrieves the connection type. The Value member will contain one or more of the values from PerConnectionFlags 
			INTERNET_PER_CONNECTION_PROXY_SERVER = 2, // Sets or retrieves a string containing the proxy servers.  
			INTERNET_PER_CONNECTION_PROXY_BYPASS = 3,
			// Sets or retrieves a string containing the URLs that do not use the proxy server.  
			INTERNET_PER_CONNECTION_AUTOCONFIG_URL = 4,
			// Sets or retrieves a string containing the URL to the automatic configuration script.  
			INTERNET_PER_CONNECTION_AUTODISCOVERY_FLAGS = 5
			//, // Sets or retrieves the automatic discovery settings. The Value member will contain one or more of the values from PerConnAutoDiscoveryFlags 
			//INTERNET_PER_CONNECTION_AUTOCONFIG_SECONDARY_URL = 6, // Chained autoconfig URL. Used when the primary autoconfig URL points to an INS file that sets a second autoconfig URL for proxy information.  
			//INTERNET_PER_CONNECTION_AUTOCONFIG_RELOAD_DELAY_MINS = 7, // Minutes until automatic refresh of autoconfig URL by autodiscovery.  
			//INTERNET_PER_CONNECTION_AUTOCONFIG_LAST_DETECT_TIME = 8, // Read only option. Returns the time the last known good autoconfig URL was found using autodiscovery.  
			//INTERNET_PER_CONNECTION_AUTOCONFIG_LAST_DETECT_URL = 9  // Read only option. Returns the last known good URL found using autodiscovery.  
		}

		//
		// PER_CONNECTION_FLAGS
		//
		[Flags]
		private enum PerConnectionFlags
		{
			PROXY_TYPE_DIRECT = 0x00000001, // direct to net
			PROXY_TYPE_PROXY = 0x00000002, // via named proxy
			PROXY_TYPE_AUTO_PROXY_URL = 0x00000004, // autoproxy URL
			PROXY_TYPE_AUTO_DETECT = 0x00000008 // use autoproxy detection
		}

		//
		// PER_CONNECTION_AUTODISCOVERY_FLAGS
		//
		[Flags]
		private enum PerConnAutoDiscoveryFlags
		{
			AUTO_PROXY_FLAG_USER_SET = 0x00000001, // user changed this setting
			AUTO_PROXY_FLAG_ALWAYS_DETECT = 0x00000002, // force detection even when its not needed
			AUTO_PROXY_FLAG_DETECTION_RUN = 0x00000004, // detection has been run
			AUTO_PROXY_FLAG_MIGRATED = 0x00000008, // migration has just been done
			AUTO_PROXY_FLAG_DONT_CACHE_PROXY_RESULT = 0x00000010, // don't cache result of host=proxy name
			AUTO_PROXY_FLAG_CACHE_INIT_RUN = 0x00000020, // don't initalize and run unless URL expired
			AUTO_PROXY_FLAG_DETECTION_SUSPECT = 0x00000040 // if we're on a LAN & Modem, with only one IP, bad?!?
		}
	}
}