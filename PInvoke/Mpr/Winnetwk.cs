using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Items from the mpr.dll</summary>
	public static class Mpr
	{
		/// <summary>The scope of the enumeration.</summary>
		public enum NETRESOURCEScope : uint
		{
			/// <summary>Enumerate currently connected resources. The dwUsage member cannot be specified.</summary>
			RESOURCE_CONNECTED = 0x00000001,

			/// <summary>Enumerate all resources on the network. The dwUsage member is specified.</summary>
			RESOURCE_GLOBALNET = 0x00000002,

			/// <summary>Enumerate remembered (persistent) connections. The dwUsage member cannot be specified.</summary>
			RESOURCE_REMEMBERED = 0x00000003,

			/// <summary>Enumerate recent connections. The dwUsage member cannot be specified.</summary>
			RESOURCE_RECENT = 0x00000004,

			/// <summary>?</summary>
			RESOURCE_CONTEXT = 0x00000005,
		}

		/// <summary>The type of resource.</summary>
		public enum NETRESOURCEType : uint
		{
			/// <summary>All resources.</summary>
			RESOURCETYPE_ANY = 0x00000000,

			/// <summary>Disk resources.</summary>
			RESOURCETYPE_DISK = 0x00000001,

			/// <summary>Print resources.</summary>
			RESOURCETYPE_PRINT = 0x00000002,

			/// <summary>Reserved resources.</summary>
			RESOURCETYPE_RESERVED = 0x00000008,

			/// <summary>Neither a disk or print resource.</summary>
			RESOURCETYPE_UNKNOWN = 0xFFFFFFFF,
		}

		/// <summary>A set of bit flags describing how the resource can be used.</summary>
		[Flags]
		public enum NETRESOURCEUsage : uint
		{
			/// <summary>The resource is a connectable resource; the name pointed to by the lpRemoteName member can be passed to the WNetAddConnection function to make a network connection.</summary>
			RESOURCEUSAGE_CONNECTABLE = 0x00000001,

			/// <summary>The resource is a container resource; the name pointed to by the lpRemoteName member can be passed to the WNetOpenEnum function to enumerate the resources in the container.</summary>
			RESOURCEUSAGE_CONTAINER = 0x00000002,

			/// <summary>The resource is not a local device.</summary>
			RESOURCEUSAGE_NOLOCALDEVICE = 0x00000004,

			/// <summary>The resource is a sibling. This value is not used by Windows.</summary>
			RESOURCEUSAGE_SIBLING = 0x00000008,

			/// <summary>The resource must be attached. This value specifies that a function to enumerate resource this should fail if the caller is not authenticated, even if the network permits enumeration without authentication.</summary>
			RESOURCEUSAGE_ATTACHED = 0x00000010,

			/// <summary>All valid values.</summary>
			RESOURCEUSAGE_ALL = (RESOURCEUSAGE_CONNECTABLE | RESOURCEUSAGE_CONTAINER | RESOURCEUSAGE_ATTACHED),

			/// <summary>Reserved</summary>
			RESOURCEUSAGE_RESERVED = 0x80000000
		}

		/// <summary>The display options for the network object in a network browsing user interface.</summary>
		public enum NETRESOURCEDisplayType : uint
		{
			/// <summary>The method used to display the object does not matter.</summary>
			RESOURCEDISPLAYTYPE_GENERIC = 0x00000000,

			/// <summary>The object should be displayed as a domain.</summary>
			RESOURCEDISPLAYTYPE_DOMAIN = 0x00000001,

			/// <summary>The object should be displayed as a server.</summary>
			RESOURCEDISPLAYTYPE_SERVER = 0x00000002,

			/// <summary>The object should be displayed as a share.</summary>
			RESOURCEDISPLAYTYPE_SHARE = 0x00000003,

			/// <summary>The object should be displayed as a file.</summary>
			RESOURCEDISPLAYTYPE_FILE = 0x00000004,

			/// <summary>The object should be displayed as a group.</summary>
			RESOURCEDISPLAYTYPE_GROUP = 0x00000005,

			/// <summary>The object should be displayed as a network.</summary>
			RESOURCEDISPLAYTYPE_NETWORK = 0x00000006,

			/// <summary>The object should be displayed as a logical root for the entire network.</summary>
			RESOURCEDISPLAYTYPE_ROOT = 0x00000007,

			/// <summary>The object should be displayed as a administrative share.</summary>
			RESOURCEDISPLAYTYPE_SHAREADMIN = 0x00000008,

			/// <summary>The object should be displayed as a directory.</summary>
			RESOURCEDISPLAYTYPE_DIRECTORY = 0x00000009,

			/// <summary>The object should be displayed as a tree. This display type was used for a NetWare Directory Service (NDS) tree by the NetWare Workstation service supported on Windows XP and earlier.</summary>
			RESOURCEDISPLAYTYPE_TREE = 0x0000000A,

			/// <summary>The object should be displayed as a Netware Directory Service container. This display type was used by the NetWare Workstation service supported on Windows XP and earlier.</summary>
			RESOURCEDISPLAYTYPE_NDSCONTAINER = 0x0000000B,
		}

		/// <summary>The NETRESOURCE structure contains information about a network resource.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NETRESOURCE
		{
			/// <summary>The scope of the enumeration.</summary>
			public NETRESOURCEScope dwScope;

			/// <summary>The type of resource.</summary>
			public NETRESOURCEType dwType;

			/// <summary>The display options for the network object in a network browsing user interface.</summary>
			public NETRESOURCEDisplayType dwDisplayType;

			/// <summary>A set of bit flags describing how the resource can be used. Note that this member can be specified only if the dwScope member is equal to RESOURCE_GLOBALNET.</summary>
			public NETRESOURCEUsage dwUsage;

			/// <summary>If the dwScope member is equal to RESOURCE_CONNECTED or RESOURCE_REMEMBERED, this member is a pointer to a null-terminated character string that specifies the name of a local device. This member is NULL if the connection does not use a device.</summary>
			public StrPtrAuto lpLocalName;

			/// <summary>If the entry is a network resource, this member is a pointer to a null-terminated character string that specifies the remote network name.
			/// <para>If the entry is a current or persistent connection, lpRemoteName member points to the network name associated with the name pointed to by the lpLocalName member.</para>
			/// <para>The string can be MAX_PATH characters in length, and it must follow the network provider's naming conventions.</para></summary>
			public StrPtrAuto lpRemoteName;

			/// <summary>A pointer to a NULL-terminated string that contains a comment supplied by the network provider.</summary>
			public StrPtrAuto lpComment;

			/// <summary>A pointer to a NULL-terminated string that contains the name of the provider that owns the resource. This member can be NULL if the provider name is unknown. To retrieve the provider name, you can call the WNetGetProviderName function.</summary>
			public StrPtrAuto lpProvider;
		}
	}
}