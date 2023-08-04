namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Undocumented.</summary>
	[ComImport, Guid("abad189d-9fa3-4278-b3ca-8ca448a88dcb"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAppActivationUIInfo
	{
		/// <summary/>
		[PreserveSig]
		HRESULT GetMonitor(out HMONITOR value);

		/// <summary/>
		[PreserveSig]
		HRESULT GetInvokePoint(out POINT value);

		/// <summary/>
		[PreserveSig]
		HRESULT GetShowCommand(out int value);

		/// <summary/>
		[PreserveSig]
		HRESULT GetShowUI([MarshalAs(UnmanagedType.Bool)] out bool value);

		/// <summary/>
		[PreserveSig]
		HRESULT GetKeyState(out uint value);
	}
}