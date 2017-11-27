using System;

// ReSharper disable InconsistentNaming ReSharper disable FieldCanBeMadeReadOnly.Global ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	/// <summary>Access flags.</summary>
	[Flags]
	public enum ACCESS_MASK : uint
	{
		/// <summary>The right to delete the object.</summary>
		DELETE = 0x00010000,

		/// <summary>
		/// The right to read the information in the object's security descriptor, not including the information in the system access control list (SACL).
		/// </summary>
		READ_CONTROL = 0x00020000,

		/// <summary>The right to modify the discretionary access control list (DACL) in the object's security descriptor.</summary>
		WRITE_DAC = 0x00040000,

		/// <summary>The right to change the owner in the object's security descriptor.</summary>
		WRITE_OWNER = 0x00080000,

		/// <summary>
		/// The right to use the object for synchronization. This enables a thread to wait until the object is in the signaled state. Some object types do not
		/// support this access right.
		/// </summary>
		SYNCHRONIZE = 0x00100000,

		/// <summary>Combines DELETE, READ_CONTROL, WRITE_DAC, and WRITE_OWNER access.</summary>
		STANDARD_RIGHTS_REQUIRED = 0x000F0000,

		/// <summary>Currently defined to equal READ_CONTROL.</summary>
		STANDARD_RIGHTS_READ = 0x00020000,

		/// <summary>Currently defined to equal READ_CONTROL.</summary>
		STANDARD_RIGHTS_WRITE = 0x00020000,

		/// <summary>Currently defined to equal READ_CONTROL.</summary>
		STANDARD_RIGHTS_EXECUTE = 0x00020000,

		/// <summary>Combines DELETE, READ_CONTROL, WRITE_DAC, WRITE_OWNER, and SYNCHRONIZE access.</summary>
		STANDARD_RIGHTS_ALL = 0x001F0000,

		/// <summary>The specific rights all</summary>
		SPECIFIC_RIGHTS_ALL = 0x0000FFFF,

		/// <summary>
		/// Controls the ability to get or set the SACL in an object's security descriptor. The system grants this access right only if the SE_SECURITY_NAME
		/// privilege is enabled in the access token of the requesting thread.
		/// </summary>
		ACCESS_SYSTEM_SECURITY = 0x01000000,

		/// <summary>Request that the object be opened with all the access rights that are valid for the caller.</summary>
		MAXIMUM_ALLOWED = 0x02000000,

		/// <summary>Read access.</summary>
		GENERIC_READ = 0x80000000,

		/// <summary>Write access.</summary>
		GENERIC_WRITE = 0x40000000,

		/// <summary>Execute access.</summary>
		GENERIC_EXECUTE = 0x20000000,

		/// <summary>All possible access rights.</summary>
		GENERIC_ALL = 0x10000000
	}
}