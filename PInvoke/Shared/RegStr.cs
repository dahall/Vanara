using System;

namespace Vanara.PInvoke
{
	/// <summary>A device's configuration flags</summary>
	[PInvokeData("regstr.h")]
	[Flags]
	public enum CONFIGFLAG : uint
	{
		/// <summary>Set if disabled</summary>
		CONFIGFLAG_DISABLED = 0x00000001,

		/// <summary>Set if a present hardware enum device deleted</summary>
		CONFIGFLAG_REMOVED = 0x00000002,

		/// <summary>Set if the devnode was manually installed</summary>
		CONFIGFLAG_MANUAL_INSTALL = 0x00000004,

		/// <summary>Set if skip the boot config</summary>
		CONFIGFLAG_IGNORE_BOOT_LC = 0x00000008,

		/// <summary>Load this devnode when in net boot</summary>
		CONFIGFLAG_NET_BOOT = 0x00000010,

		/// <summary>Redo install</summary>
		CONFIGFLAG_REINSTALL = 0x00000020,

		/// <summary>Failed the install</summary>
		CONFIGFLAG_FAILEDINSTALL = 0x00000040,

		/// <summary>Can't stop/remove a single child</summary>
		CONFIGFLAG_CANTSTOPACHILD = 0x00000080,

		/// <summary>Can remove even if rom.</summary>
		CONFIGFLAG_OKREMOVEROM = 0x00000100,

		/// <summary>Don't remove at exit.</summary>
		CONFIGFLAG_NOREMOVEEXIT = 0x00000200,

		/// <summary>Complete install for devnode running 'raw'</summary>
		CONFIGFLAG_FINISH_INSTALL = 0x00000400,

		/// <summary>This devnode requires a forced config</summary>
		CONFIGFLAG_NEEDS_FORCED_CONFIG = 0x00000800,

		/// <summary>This is the remote boot network card</summary>
		CONFIGFLAG_NETBOOT_CARD = 0x00001000,

		/// <summary>This device has a partial logconfig</summary>
		CONFIGFLAG_PARTIAL_LOG_CONF = 0x00002000,

		/// <summary>Set if unsafe removals should be ignored</summary>
		CONFIGFLAG_SUPPRESS_SURPRISE = 0x00004000,

		/// <summary>Set if hardware should be tested for logo failures</summary>
		CONFIGFLAG_VERIFY_HARDWARE = 0x00008000,

		/// <summary>Show the finish install wizard pages for the installed device.</summary>
		CONFIGFLAG_FINISHINSTALL_UI = 0x00010000,

		/// <summary>Call installer with DIF_FINISHINSTALL_ACTION in client context.</summary>
		CONFIGFLAG_FINISHINSTALL_ACTION = 0x00020000,

		/// <summary>Configured devnode during boot phase</summary>
		CONFIGFLAG_BOOT_DEVICE = 0x00040000,

		/// <summary>Device needs additional class configuration to start</summary>
		CONFIGFLAG_NEEDS_CLASS_CONFIG = 0x00080000,
	}
}