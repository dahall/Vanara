using Vanara.Extensions;

namespace Vanara.PInvoke;

public static partial class ClfsW32
{
	/// <summary/>
	public const ulong CLFS_LOG_SIZE_MAXIMUM = unchecked((ulong)-1L);

	/// <summary/>
	public const ulong CLFS_LOG_SIZE_MINIMUM = 0UL;

	/// <summary/>
	public const uint CLFS_MGMT_NUM_POLICIES = (uint)CLFS_MGMT_POLICY_TYPE.ClfsMgmtPolicyInvalid;

	/// <summary>The version of a given policy structure. See CLFS_MGMT_POLICY.</summary>
	public const uint CLFS_MGMT_POLICY_VERSION = 0x01;

	/// <summary>The types of notifications given to either the callback proxy or to readers of notifications.</summary>
	[PInvokeData("clfsmgmt.h", MSDNShortId = "NS:clfsmgmt._CLFS_MGMT_NOTIFICATION")]
	public enum CLFS_MGMT_NOTIFICATION_TYPE
	{
		/// <summary>The notification to advance the log tail. For more information, see LOG_TAIL_ADVANCE_CALLBACK.</summary>
		ClfsMgmtAdvanceTailNotification = 0,

		/// <summary>The notification that a call to HandleLogFull is complete. For more information, see LOG_FULL_HANDLER_CALLBACK.</summary>
		ClfsMgmtLogFullHandlerNotification,

		/// <summary>The notification that the log is unpinned. For more information, see LOG_UNPINNED_CALLBACK.</summary>
		ClfsMgmtLogUnpinnedNotification,

		/// <summary>
		/// The notification that a nonzero number of bytes has been written to the log. For more information, see
		/// RegisterForLogWriteNotification. <c>Windows Server 2003 R2 and Windows Vista before SP1:</c> This value is not supported.
		/// </summary>
		ClfsMgmtLogWriteNotification
	}

	/// <summary>The <c>CLFS_MGMT_POLICY_TYPE</c> enumeration lists the valid policy types.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmt/ne-clfsmgmt-clfs_mgmt_policy_type typedef enum _CLFS_MGMT_POLICY_TYPE {
	// ClfsMgmtPolicyMaximumSize = 0x0, ClfsMgmtPolicyMinimumSize, ClfsMgmtPolicyNewContainerSize, ClfsMgmtPolicyGrowthRate,
	// ClfsMgmtPolicyLogTail, ClfsMgmtPolicyAutoShrink, ClfsMgmtPolicyAutoGrow, ClfsMgmtPolicyNewContainerPrefix,
	// ClfsMgmtPolicyNewContainerSuffix, ClfsMgmtPolicyNewContainerExtension, ClfsMgmtPolicyInvalid } CLFS_MGMT_POLICY_TYPE, *PCLFS_MGMT_POLICY_TYPE;
	[PInvokeData("clfsmgmt.h", MSDNShortId = "NE:clfsmgmt._CLFS_MGMT_POLICY_TYPE")]
	public enum CLFS_MGMT_POLICY_TYPE : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x0</para>
		/// <para>Specifies the maximum size of the log.</para>
		/// </summary>
		ClfsMgmtPolicyMaximumSize,

		/// <summary>Specifies the minimum size of the log.</summary>
		ClfsMgmtPolicyMinimumSize,

		/// <summary>Specifies the size of a new container.</summary>
		ClfsMgmtPolicyNewContainerSize,

		/// <summary>Controls the rate of growth of the log.</summary>
		ClfsMgmtPolicyGrowthRate,

		/// <summary>
		/// <para>Controls the amount of space that</para>
		/// <para>LOG_TAIL_ADVANCE_CALLBACK</para>
		/// <para>requests.</para>
		/// </summary>
		ClfsMgmtPolicyLogTail,

		/// <summary>Controls the percentage of containers that are removed if the log is set to autogrow.</summary>
		ClfsMgmtPolicyAutoShrink,

		/// <summary>Indicates if the log should automatically shrink or grow.</summary>
		ClfsMgmtPolicyAutoGrow,

		/// <summary>Controls the prefix given to a new container.</summary>
		ClfsMgmtPolicyNewContainerPrefix,

		/// <summary>Controls the suffix given to a new container.</summary>
		ClfsMgmtPolicyNewContainerSuffix,

		/// <summary>Controls the extension given to a new container.</summary>
		ClfsMgmtPolicyNewContainerExtension,

		/// <summary/>
		ClfsMgmtPolicyInvalid,
	}

	/// <summary>The <c>CLFS_MGMT_NOTIFICATION</c> structure specifies information about the notifications that the client receives.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmt/ns-clfsmgmt-clfs_mgmt_notification typedef struct _CLFS_MGMT_NOTIFICATION
	// { CLFS_MGMT_NOTIFICATION_TYPE Notification; CLFS_LSN Lsn; USHORT LogIsPinned; } CLFS_MGMT_NOTIFICATION, *PCLFS_MGMT_NOTIFICATION;
	[PInvokeData("clfsmgmt.h", MSDNShortId = "NS:clfsmgmt._CLFS_MGMT_NOTIFICATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CLFS_MGMT_NOTIFICATION
	{
		/// <summary>
		/// <para>The type of notification to receive. The following values are valid.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>ClfsMgmtAdvanceTailNotification</c> 0</term>
		/// <term>The notification to advance the log tail. For more information, see LOG_TAIL_ADVANCE_CALLBACK.</term>
		/// </item>
		/// <item>
		/// <term><c>ClfsMgmtLogFullHandlerNotification</c> 1</term>
		/// <term>The notification that a call to HandleLogFull is complete. For more information, see LOG_FULL_HANDLER_CALLBACK.</term>
		/// </item>
		/// <item>
		/// <term><c>ClfsMgmtLogUnpinnedNotification</c> 2</term>
		/// <term>The notification that the log is unpinned. For more information, see LOG_UNPINNED_CALLBACK.</term>
		/// </item>
		/// <item>
		/// <term><c>ClfsMgmtLogWriteNotification</c> 3</term>
		/// <term>
		/// The notification that a nonzero number of bytes has been written to the log. For more information, see
		/// RegisterForLogWriteNotification. <c>Windows Server 2003 R2 and Windows Vista before SP1:</c> This value is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public CLFS_MGMT_NOTIFICATION_TYPE Notification;

		/// <summary>
		/// If <c>Notification</c> is <c>ClfsMgmtAdvanceTailNotification</c>, <c>Lsn</c> specifies the target log sequence number (LSN) the
		/// client should advance the log tail to.
		/// </summary>
		public CLS_LSN Lsn;

		private ushort _LogIsPinned;

		/// <summary>
		/// If <c>Notification</c> is <c>ClfsMgmtLogUnpinnedNotification</c>, <c>LogIsPinned</c> indicates that the log is pinned. This
		/// member is <c>TRUE</c> if the log is pinned.
		/// </summary>
		public bool LogIsPinned { get => _LogIsPinned != 0; set => _LogIsPinned = value ? (ushort)1U : (ushort)0U; }
	}

	/// <summary>
	/// The <c>CLFS_MGMT_POLICY</c> structure specifies a Common Log File System (CLFS) management policy. The <c>PolicyType</c> member
	/// specifies the members used for a policy.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsmgmt/ns-clfsmgmt-clfs_mgmt_policy typedef struct _CLFS_MGMT_POLICY { ULONG
	// Version; ULONG LengthInBytes; ULONG PolicyFlags; CLFS_MGMT_POLICY_TYPE PolicyType; union { struct { ULONG Containers; } MaximumSize;
	// struct { ULONG Containers; } MinimumSize; struct { ULONG SizeInBytes; } NewContainerSize; struct { ULONG AbsoluteGrowthInContainers;
	// ULONG RelativeGrowthPercentage; } GrowthRate; struct { ULONG MinimumAvailablePercentage; ULONG MinimumAvailableContainers; } LogTail;
	// struct { ULONG Percentage; } AutoShrink; struct { ULONG Enabled; } AutoGrow; struct { USHORT PrefixLengthInBytes; WCHAR
	// PrefixString[1]; } NewContainerPrefix; struct { ULONGLONG NextContainerSuffix; } NewContainerSuffix; struct { USHORT
	// ExtensionLengthInBytes; WCHAR ExtensionString[1]; } NewContainerExtension; } PolicyParameters; } CLFS_MGMT_POLICY, *PCLFS_MGMT_POLICY;
	[PInvokeData("clfsmgmt.h", MSDNShortId = "NS:clfsmgmt._CLFS_MGMT_POLICY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CLFS_MGMT_POLICY
	{
		/// <summary>
		/// <para>Specifies the version of the log manager headers that the application is compiled with.</para>
		/// <para>Set this to CLFS_MGMT_POLICY_VERSION.</para>
		/// </summary>
		public uint Version;

		/// <summary>Specifies the length of the entire structure.</summary>
		public uint LengthInBytes;

		/// <summary>Reserved. Specify zero.</summary>
		public uint PolicyFlags;

		/// <summary>Specifies the members used for a specific policy. Valid values are specified by CLFS_MGMT_POLICY_TYPE.</summary>
		public CLFS_MGMT_POLICY_TYPE PolicyType;

		/// <summary>Specifies the specific policy this structure describes.</summary>
		public POLICYPARAMETERS PolicyParameters;

		/// <summary>Specifies the specific policy this structure describes.</summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct POLICYPARAMETERS
		{
			const int strLen = 266;

			/// <summary>Specifies the maximum size of a log.</summary>
			[FieldOffset(0)]
			public MAXIMUMSIZE MaximumSize;

			/// <summary>Specifies the minimum size of a log.</summary>
			[FieldOffset(0)]
			public MINIMUMSIZE MinimumSize;

			/// <summary>Controls the size of a new container.</summary>
			[FieldOffset(0)]
			public NEWCONTAINERSIZE NewContainerSize;

			/// <summary>
			/// Controls the rate of growth of a log. The growth rate can be either a relative percentage or an absolute number of containers
			/// added, but not both. Valid values are zero (0) and greater. Specify zero (0) to indicate that the log is not to grow in size.
			/// </summary>
			[FieldOffset(0)]
			public GROWTHRATE GrowthRate;

			/// <summary>
			/// Controls the amount of space that LOG_TAIL_ADVANCE_CALLBACK requests. The value is either a relative percentage or an
			/// absolute number of bytes, but not both. The value is always rounded up to the nearest container. Specify zero to indicate
			/// that no action is taken to advance the base log tail.
			/// </summary>
			[FieldOffset(0)]
			public LOGTAIL LogTail;

			/// <summary>
			/// Controls the timing of the log-shrinking feature. This value represents the percent of free space that must exist to trigger
			/// the auto-shrink operation. The log cannot be shrunk to a size smaller than the value specified by the
			/// <c>ClfsMgmtPolicyMinimumSize</c> policy.
			/// </summary>
			[FieldOffset(0)]
			public AUTOSHRINK AutoShrink;

			/// <summary>
			/// Controls the auto-grow feature. If auto-grow is enabled, the log grows according to the value of the <c>GrowthRate</c>
			/// member, and is limited by the value of the <c>MaximumSize</c> member when the log reaches a state where one or no containers
			/// are free.
			/// </summary>
			[FieldOffset(0)]
			public AUTOGROW AutoGrow;

			/// <summary>Controls the prefix that is given to a new container.</summary>
			[FieldOffset(0)]
			public NEWCONTAINERPREFIX NewContainerPrefix;

			/// <summary>Controls the suffix that is given to a new container.</summary>
			[FieldOffset(0)]
			public NEWCONTAINERSUFFIX NewContainerSuffix;

			/// <summary>Controls the extension that is given to a new container.</summary>
			[FieldOffset(0)]
			public NEWCONTAINEREXTENSION NewContainerExtension;

			/// <summary>Specifies the maximum size of a log.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct MAXIMUMSIZE
			{
				/// <summary>Specifies the maximum size of the log as a number of containers. There is no default maximum value.</summary>
				public uint Containers;
			}

			/// <summary>Specifies the minimum size of a log.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct MINIMUMSIZE
			{
				/// <summary>Specifies the minimum size of the log as a number of containers. The minimum size is two (2) containers.</summary>
				public uint Containers;
			}

			/// <summary>Controls the size of a new container.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct NEWCONTAINERSIZE
			{
				/// <summary>Specifies the size, in bytes, of any new containers created.</summary>
				public uint SizeInBytes;
			}

			/// <summary>
			/// Controls the rate of growth of a log. The growth rate can be either a relative percentage or an absolute number of containers
			/// added, but not both. Valid values are zero (0) and greater. Specify zero (0) to indicate that the log is not to grow in size.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct GROWTHRATE
			{
				/// <summary>Specifies the growth rate as an absolute number of containers. The default value of this member is two (2).</summary>
				public uint AbsoluteGrowthInContainers;

				/// <summary>Specifies the growth rate as a relative percentage. There is no default value for this member.</summary>
				public uint RelativeGrowthPercentage;
			}

			/// <summary>
			/// Controls the amount of space that LOG_TAIL_ADVANCE_CALLBACK requests. The value is either a relative percentage or an
			/// absolute number of bytes, but not both. The value is always rounded up to the nearest container. Specify zero to indicate
			/// that no action is taken to advance the base log tail.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct LOGTAIL
			{
				/// <summary>
				/// Specifies the amount of space that is requested as a percentage of the entire log. The minimum amount requested frees up
				/// space in a container.
				/// </summary>
				public uint MinimumAvailablePercentage;

				/// <summary>Specifies the amount of space that is requested as an absolute number of containers.</summary>
				public uint MinimumAvailableContainers;
			}

			/// <summary>
			/// Controls the timing of the log-shrinking feature. This value represents the percent of free space that must exist to trigger
			/// the auto-shrink operation. The log cannot be shrunk to a size smaller than the value specified by the
			/// <c>ClfsMgmtPolicyMinimumSize</c> policy.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct AUTOSHRINK
			{
				/// <summary>Specifies the percentage to shrink the log by. There is no default value.</summary>
				public uint Percentage;
			}

			/// <summary>
			/// Controls the auto-grow feature. If auto-grow is enabled, the log grows according to the value of the <c>GrowthRate</c>
			/// member, and is limited by the value of the <c>MaximumSize</c> member when the log reaches a state where one or no containers
			/// are free.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct AUTOGROW
			{
				/// <summary>
				/// Specifies whether the auto-grow policy is enabled. Specify zero to disable the auto-grow policy. The default is disabled.
				/// </summary>
				[MarshalAs(UnmanagedType.Bool)]
				public bool Enabled;
			}

			/// <summary>Controls the prefix that is given to a new container.</summary>
			[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
			public struct NEWCONTAINERPREFIX
			{
				/// <summary>Specifies the length of <c>PrefixString</c>.</summary>
				public ushort PrefixLengthInBytes;

				// Complete hack to get this structure to hold 266 characters
				private char _PrefixString;
				private uint pad01, pad02, pad03, pad04, pad05, pad06, pad07, pad08, pad09, pad10, pad11, pad12, pad13, pad14, pad15, pad16, pad17, pad18, pad19, pad20, pad21, pad22, pad23, pad24, pad25, pad26, pad27, pad28, pad29, pad30, pad31, pad32, pad33, pad34, pad35, pad36, pad37, pad38, pad39, pad40, pad41, pad42, pad43, pad44, pad45, pad46, pad47, pad48, pad49, pad50, pad51, pad52, pad53, pad54, pad55, pad56, pad57, pad58, pad59, pad60, pad61, pad62, pad63, pad64, pad65, pad66;

				/// <summary>
				/// <para>
				/// Specifies the prefix string. This string should include a full path to the directory where the containers are created,
				/// and a prefix for the container name.
				/// </para>
				/// <para>
				/// The default path to the container is the directory that contains the base log. The default value is "Container". The log
				/// container is created with the name &lt;Name of Log&gt;&lt;Default Prefix&gt;&lt;Number&gt;.
				/// </para>
				/// <para><c>Note</c> The Common Log File System (CLFS) determines the value of &lt;Number&gt;.</para>
				/// </summary>
				public string PrefixString
				{
					get { unsafe { fixed (char* c = &_PrefixString) { return new string(c, 0, PrefixLengthInBytes / 2); } } }
					set
					{
						unsafe
						{
							fixed (char* c = &_PrefixString)
							{
								var b = StringHelper.GetBytes(value?.Substring(0, Math.Min(value.Length, strLen)), false, CharSet.Unicode);
								PrefixLengthInBytes = (ushort)b.Length;
								Marshal.Copy(b, 0, (IntPtr)c, b.Length);
							}
						}
					}
				}
			}

			/// <summary>Controls the suffix that is given to a new container.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct NEWCONTAINERSUFFIX
			{
				/// <summary>Specifies the suffix given to a new container.</summary>
				public ulong NextContainerSuffix;
			}

			/// <summary>Controls the extension that is given to a new container.</summary>
			[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
			public struct NEWCONTAINEREXTENSION
			{
				/// <summary>Specifies the length of <c>ExtensionString</c>.</summary>
				public ushort ExtensionLengthInBytes;

				// Complete hack to get this structure to hold 266 characters
				private char _ExtensionString;
				private uint pad01, pad02, pad03, pad04, pad05, pad06, pad07, pad08, pad09, pad10, pad11, pad12, pad13, pad14, pad15, pad16, pad17, pad18, pad19, pad20, pad21, pad22, pad23, pad24, pad25, pad26, pad27, pad28, pad29, pad30, pad31, pad32, pad33, pad34, pad35, pad36, pad37, pad38, pad39, pad40, pad41, pad42, pad43, pad44, pad45, pad46, pad47, pad48, pad49, pad50, pad51, pad52, pad53, pad54, pad55, pad56, pad57, pad58, pad59, pad60, pad61, pad62, pad63, pad64, pad65, pad66;

				/// <summary>Specifies the extension given to the container file.</summary>
				public string ExtensionString
				{
					get { unsafe { fixed (char* c = &_ExtensionString) { return new string(c, 0, ExtensionLengthInBytes / 2); } } }
					set
					{
						unsafe {
							fixed (char* c = &_ExtensionString) {
								var b = StringHelper.GetBytes(value?.Substring(0, Math.Min(value.Length, strLen - 1)), false, CharSet.Unicode);
								ExtensionLengthInBytes = (ushort)b.Length;
								Marshal.Copy(b, 0, (IntPtr)c, b.Length);
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CLFS_MGMT_POLICY"/> struct with a policy type, version and length. The user is
		/// expected to fill out the policy union structure.
		/// </summary>
		/// <param name="type">The policy type.</param>
		public CLFS_MGMT_POLICY(CLFS_MGMT_POLICY_TYPE type) : this()
		{
			Version = CLFS_MGMT_POLICY_VERSION;
			LengthInBytes = (uint)Marshal.SizeOf(this);
			PolicyType = type;
		}
	}
}