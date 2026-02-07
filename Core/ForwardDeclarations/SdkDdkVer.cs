namespace Vanara.PInvoke;

/// <summary>NTDDI version constants</summary>
[PInvokeData("sdkddkver.h")]
public enum NTDDI : uint
{
	/// <summary/>
	NTDDI_WIN2K = 0x05000000,

	/// <summary/>
	NTDDI_WIN2KSP1 = 0x05000100,

	/// <summary/>
	NTDDI_WIN2KSP2 = 0x05000200,

	/// <summary/>
	NTDDI_WIN2KSP3 = 0x05000300,

	/// <summary/>
	NTDDI_WIN2KSP4 = 0x05000400,

	/// <summary/>
	NTDDI_WINXP = 0x05010000,

	/// <summary/>
	NTDDI_WINXPSP1 = 0x05010100,

	/// <summary/>
	NTDDI_WINXPSP2 = 0x05010200,

	/// <summary/>
	NTDDI_WINXPSP3 = 0x05010300,

	/// <summary/>
	NTDDI_WINXPSP4 = 0x05010400,

	/// <summary/>
	NTDDI_WS03 = 0x05020000,

	/// <summary/>
	NTDDI_WS03SP1 = 0x05020100,

	/// <summary/>
	NTDDI_WS03SP2 = 0x05020200,

	/// <summary/>
	NTDDI_WS03SP3 = 0x05020300,

	/// <summary/>
	NTDDI_WS03SP4 = 0x05020400,

	/// <summary/>
	NTDDI_WIN6 = 0x06000000,

	/// <summary/>
	NTDDI_WIN6SP1 = 0x06000100,

	/// <summary/>
	NTDDI_WIN6SP2 = 0x06000200,

	/// <summary/>
	NTDDI_WIN6SP3 = 0x06000300,

	/// <summary/>
	NTDDI_WIN6SP4 = 0x06000400,

	/// <summary/>
	NTDDI_VISTA = NTDDI_WIN6,

	/// <summary/>
	NTDDI_VISTASP1 = NTDDI_WIN6SP1,

	/// <summary/>
	NTDDI_VISTASP2 = NTDDI_WIN6SP2,

	/// <summary/>
	NTDDI_VISTASP3 = NTDDI_WIN6SP3,

	/// <summary/>
	NTDDI_VISTASP4 = NTDDI_WIN6SP4,

	/// <summary/>
	NTDDI_LONGHORN = NTDDI_VISTA,

	/// <summary/>
	NTDDI_WS08 = NTDDI_WIN6SP1,

	/// <summary/>
	NTDDI_WS08SP2 = NTDDI_WIN6SP2,

	/// <summary/>
	NTDDI_WS08SP3 = NTDDI_WIN6SP3,

	/// <summary/>
	NTDDI_WS08SP4 = NTDDI_WIN6SP4,

	/// <summary/>
	NTDDI_WIN7 = 0x06010000,

	/// <summary/>
	NTDDI_WIN8 = 0x06020000,

	/// <summary/>
	NTDDI_WINBLUE = 0x06030000,

	/// <summary/>
	NTDDI_WINTHRESHOLD = 0x0A000000,

	/// <summary/>
	NTDDI_WIN10 = 0x0A000000,

	/// <summary/>
	NTDDI_WIN10_TH2 = 0x0A000001,

	/// <summary/>
	NTDDI_WIN10_RS1 = 0x0A000002,

	/// <summary/>
	NTDDI_WIN10_RS2 = 0x0A000003,

	/// <summary/>
	NTDDI_WIN10_RS3 = 0x0A000004,

	/// <summary/>
	NTDDI_WIN10_RS4 = 0x0A000005,

	/// <summary/>
	NTDDI_WIN10_RS5 = 0x0A000006,

	/// <summary/>
	NTDDI_WIN10_19H1 = 0x0A000007,
}

/// <summary>_WIN32_WINNT version constants</summary>
[PInvokeData("sdkddkver.h")]
public enum WIN32_WINNT : ushort
{
	/// <summary/>
	_WIN32_WINNT_NT4 = 0x0400,

	/// <summary/>
	_WIN32_WINNT_WIN2K = 0x0500,

	/// <summary/>
	_WIN32_WINNT_WINXP = 0x0501,

	/// <summary/>
	_WIN32_WINNT_WS03 = 0x0502,

	/// <summary/>
	_WIN32_WINNT_WIN6 = 0x0600,

	/// <summary/>
	_WIN32_WINNT_VISTA = 0x0600,

	/// <summary/>
	_WIN32_WINNT_WS08 = 0x0600,

	/// <summary/>
	_WIN32_WINNT_LONGHORN = 0x0600,

	/// <summary/>
	_WIN32_WINNT_WIN7 = 0x0601,

	/// <summary/>
	_WIN32_WINNT_WIN8 = 0x0602,

	/// <summary/>
	_WIN32_WINNT_WINBLUE = 0x0603,

	/// <summary/>
	_WIN32_WINNT_WINTHRESHOLD = 0x0A00,

	/// <summary/>
	_WIN32_WINNT_WIN10 = 0x0A00,
}