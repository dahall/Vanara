using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>The MULTIPLE_TRUSTEE_OPERATION enumeration contains values that indicate whether a TRUSTEE structure is an impersonation trustee.</summary>
		[PInvokeData("AccCtrl.h", MSDNShortId = "aa379284")]
		public enum MULTIPLE_TRUSTEE_OPERATION
		{
			/// <summary>The trustee is not an impersonation trustee.</summary>
			NO_MULTIPLE_TRUSTEE,
			/// <summary>
			/// The trustee is an impersonation trustee. The pMultipleTrustee member of the TRUSTEE structure points to a trustee for a server that can
			/// impersonate the client trustee.
			/// </summary>
			TRUSTEE_IS_IMPERSONATE
		}

		/// <summary>
		/// The SE_OBJECT_TYPE enumeration contains values that correspond to the types of Windows objects that support security. The functions, such as
		/// GetSecurityInfo and SetSecurityInfo, that set and retrieve the security information of an object, use these values to indicate the type of object.
		/// </summary>
		[PInvokeData("AccCtrl.h", MSDNShortId = "aa379593")]
		public enum SE_OBJECT_TYPE
		{
			/// <summary>Unknown object type.</summary>
			SE_UNKNOWN_OBJECT_TYPE = 0,
			/// <summary>Indicates a file or directory. The name string that identifies a file or directory object can be in one of the following formats:
			/// <list type="bullet">
			/// <listItem><para>A relative path, such as FileName.dat or ..\FileName</para></listItem>
			/// <listItem><para>An absolute path, such as FileName.dat, C:\DirectoryName\FileName.dat, or G:\RemoteDirectoryName\FileName.dat.</para></listItem>
			/// <listItem><para>A UNC name, such as \\ComputerName\ShareName\FileName.dat.</para></listItem>
			/// </list>
			///</summary>
			SE_FILE_OBJECT,
			/// <summary>Indicates a Windows service. A service object can be a local service, such as ServiceName, or a remote service, such as \\ComputerName\ServiceName.</summary>
			SE_SERVICE,
			/// <summary>Indicates a printer. A printer object can be a local printer, such as PrinterName, or a remote printer, such as \\ComputerName\PrinterName.</summary>
			SE_PRINTER,
			/// <summary>
			/// Indicates a registry key. A registry key object can be in the local registry, such as CLASSES_ROOT\SomePath or in a remote registry, such as \\ComputerName\CLASSES_ROOT\SomePath.
			/// <para>
			/// The names of registry keys must use the following literal strings to identify the predefined registry keys: "CLASSES_ROOT", "CURRENT_USER",
			/// "MACHINE", and "USERS".
			/// </para>
			/// </summary>
			SE_REGISTRY_KEY,
			/// <summary>Indicates a network share. A share object can be local, such as ShareName, or remote, such as \\ComputerName\ShareName.</summary>
			SE_LMSHARE,
			/// <summary>
			/// Indicates a local kernel object. The GetSecurityInfo and SetSecurityInfo functions support all types of kernel objects. The GetNamedSecurityInfo
			/// and SetNamedSecurityInfo functions work only with the following kernel objects: semaphore, event, mutex, waitable timer, and file mapping.
			/// </summary>
			SE_KERNEL_OBJECT,
			/// <summary>
			/// Indicates a window station or desktop object on the local computer. You cannot use GetNamedSecurityInfo and SetNamedSecurityInfo with these
			/// objects because the names of window stations or desktops are not unique.
			/// </summary>
			SE_WINDOW_OBJECT,
			/// <summary>
			/// Indicates a directory service object or a property set or property of a directory service object. The name string for a directory service object
			/// must be in X.500 form, for example:
			/// <para>CN=SomeObject,OU=ou2,OU=ou1,DC=DomainName,DC=CompanyName,DC=com,O=internet</para>
			/// </summary>
			SE_DS_OBJECT,
			/// <summary>Indicates a directory service object and all of its property sets and properties.</summary>
			SE_DS_OBJECT_ALL,
			/// <summary>Indicates a provider-defined object.</summary>
			SE_PROVIDER_DEFINED_OBJECT,
			/// <summary>Indicates a WMI object.</summary>
			SE_WMIGUID_OBJECT,
			/// <summary>Indicates an object for a registry entry under WOW64.</summary>
			SE_REGISTRY_WOW64_32KEY
		}

		/// <summary>
		/// The TRUSTEE_FORM enumeration contains values that indicate the type of data pointed to by the ptstrName member of the <see cref="TRUSTEE"/> structure.
		/// </summary>
		[PInvokeData("AccCtrl.h", MSDNShortId = "aa379638")]
		public enum TRUSTEE_FORM
		{
			/// <summary>The ptstrName member is a pointer to a security identifier (SID) that identifies the trustee.</summary>
			TRUSTEE_IS_SID,
			/// <summary>The ptstrName member is a pointer to a null-terminated string that identifies the trustee.</summary>
			TRUSTEE_IS_NAME,
			/// <summary>Indicates a trustee form that is not valid.</summary>
			TRUSTEE_BAD_FORM,
			/// <summary>
			/// The ptstrName member is a pointer to an OBJECTS_AND_SID structure that contains the SID of the trustee and the GUIDs of the object types in an
			/// object-specific access control entry (ACE).
			/// </summary>
			TRUSTEE_IS_OBJECTS_AND_SID,
			/// <summary>
			/// The ptstrName member is a pointer to an OBJECTS_AND_NAME structure that contains the name of the trustee and the names of the object types in an
			/// object-specific ACE.
			/// </summary>
			TRUSTEE_IS_OBJECTS_AND_NAME
		}

		/// <summary>The TRUSTEE_TYPE enumeration contains values that indicate the type of trustee identified by a <see cref="TRUSTEE"/> structure.</summary>
		[PInvokeData("AccCtrl.h", MSDNShortId = "aa379639")]
		public enum TRUSTEE_TYPE
		{
			/// <summary>The trustee type is unknown, but it may be valid.</summary>
			TRUSTEE_IS_UNKNOWN,
			/// <summary>Indicates a user.</summary>
			TRUSTEE_IS_USER,
			/// <summary>Indicates a group.</summary>
			TRUSTEE_IS_GROUP,
			/// <summary>Indicates a domain.</summary>
			TRUSTEE_IS_DOMAIN,
			/// <summary>Indicates an alias.</summary>
			TRUSTEE_IS_ALIAS,
			/// <summary>Indicates a well-known group.</summary>
			TRUSTEE_IS_WELL_KNOWN_GROUP,
			/// <summary>Indicates a deleted account.</summary>
			TRUSTEE_IS_DELETED,
			/// <summary>Indicates a trustee type that is not valid.</summary>
			TRUSTEE_IS_INVALID,
			/// <summary>Indicates a computer.</summary>
			TRUSTEE_IS_COMPUTER
		}

		/// <summary>Provides information about an object's inherited access control entry (ACE).</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		[PInvokeData("AccCtrl.h", MSDNShortId = "aa378845")]
		public struct INHERITED_FROM
		{
			/// <summary>
			/// Number of levels, or generations, between the object and the ancestor. Set this to zero for an explicit ACE. If the ancestor cannot be determined
			/// for the inherited ACE, set this member to –1.
			/// </summary>
			public int GenerationGap;

			/// <summary>Name of the ancestor from which the ACE was inherited. For an explicit ACE, set this to <c>null</c>.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string AncestorName;

			/// <summary>Initializes a new instance of the <see cref="INHERITED_FROM"/> structure.</summary>
			/// <param name="generationGap">The generation gap.</param>
			/// <param name="ancestorName">Name of the ancestor.</param>
			public INHERITED_FROM(int generationGap, string ancestorName)
			{
				GenerationGap = generationGap;
				AncestorName = ancestorName;
			}

			/// <summary>Returns a <see cref="System.String" /> that represents this instance.</summary>
			/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
			public override string ToString() => $"{AncestorName} : 0x{GenerationGap:X}";

			/// <summary>ACE is explicit.</summary>
			public static readonly INHERITED_FROM Explicit = new INHERITED_FROM(0, null);

			/// <summary>ACE inheritance cannot be determined.</summary>
			public static readonly INHERITED_FROM Indeterminate = new INHERITED_FROM(-1, null);
		}

		/// <summary>
		/// The TRUSTEE structure identifies the user account, group account, or logon session to which an access control entry (ACE) applies. The structure can
		/// use a name or a security identifier (SID) to identify the trustee.
		/// <para>
		/// Access control functions, such as SetEntriesInAcl and GetExplicitEntriesFromAcl, use this structure to identify the logon account associated with the
		/// access control or audit control information in an EXPLICIT_ACCESS structure.
		/// </para>
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
		[PInvokeData("AccCtrl.h", MSDNShortId = "aa379636")]
		public sealed class TRUSTEE : IDisposable
		{
			/// <summary>
			/// A pointer to a TRUSTEE structure that identifies a server account that can impersonate the user identified by the ptstrName member. This member
			/// is not currently supported and must be NULL.
			/// </summary>
			public IntPtr pMultipleTrustee;
			/// <summary>A value of the MULTIPLE_TRUSTEE_OPERATION enumeration type. Currently, this member must be NO_MULTIPLE_TRUSTEE.</summary>
			public MULTIPLE_TRUSTEE_OPERATION MultipleTrusteeOperation;
			/// <summary>A value from the TRUSTEE_FORM enumeration type that indicates the type of data pointed to by the ptstrName member.</summary>
			public TRUSTEE_FORM TrusteeForm;
			/// <summary>
			/// A value from the TRUSTEE_TYPE enumeration type that indicates whether the trustee is a user account, a group account, or an unknown account type.
			/// </summary>
			public TRUSTEE_TYPE TrusteeType;
			/// <summary>
			/// A pointer to a buffer that identifies the trustee and, optionally, contains information about object-specific ACEs. The type of data depends on
			/// the value of the TrusteeForm member. This member can be one of the following values.
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <description>Meaning</description>
			/// </listheader>
			/// <item>
			/// <term>TRUSTEE_IS_NAME</term>
			/// <description>A pointer to a null-terminated string that contains the name of the trustee.</description>
			/// </item>
			/// <item>
			/// <term>TRUSTEE_IS_OBJECTS_AND_NAME</term>
			/// <description>
			/// A pointer to an OBJECTS_AND_NAME structure that contains the name of the trustee and the names of the object types in an object-specific ACE.
			/// </description>
			/// </item>
			/// <item>
			/// <term>TRUSTEE_IS_OBJECTS_AND_SID</term>
			/// <description>
			/// A pointer to an OBJECTS_AND_SID structure that contains the SID of the trustee and the GUIDs of the object types in an object-specific ACE.
			/// </description>
			/// </item>
			/// <item>
			/// <term>TRUSTEE_IS_SID</term>
			/// <description>Pointer to the SID of the trustee.</description>
			/// </item>
			/// </list>
			/// </summary>
			public IntPtr ptstrName;

			/// <summary>Initializes a new instance of the <see cref="TRUSTEE"/> class.</summary>
			/// <param name="sid">The sid.</param>
			public TRUSTEE(PSID sid = null)
			{
				if (sid != null) Sid = sid;
			}

			/// <summary>Initializes a new instance of the <see cref="TRUSTEE"/> class.</summary>
			/// <param name="name">The name of the trustee in one of the following formats:
			/// <list type="bullet">
			/// <listItem>A fully qualified name, such as "g:\remotedir\abc".</listItem>
			/// <listItem>A domain account, such as "domain1\xyz".</listItem>
			/// <listItem>One of the predefined group names, such as "EVERYONE" or "GUEST".</listItem>
			/// <listItem>One of the following special names: "CREATOR GROUP", "CREATOR OWNER", "CURRENT_USER".</listItem>
			/// </list>
			/// </param>
			public TRUSTEE(string name)
			{
				Name = name;
			}

			void IDisposable.Dispose()
			{
				if (ptstrName != IntPtr.Zero) Marshal.FreeHGlobal(ptstrName);
			}

			/// <summary>Gets or sets the name of the trustee.</summary>
			/// <value>A trustee name can have any of the following formats:
			/// <list type="bullet">
			/// <listItem>A fully qualified name, such as "g:\remotedir\abc".</listItem>
			/// <listItem>A domain account, such as "domain1\xyz".</listItem>
			/// <listItem>One of the predefined group names, such as "EVERYONE" or "GUEST".</listItem>
			/// <listItem>One of the following special names: "CREATOR GROUP", "CREATOR OWNER", "CURRENT_USER".</listItem>
			/// </list>
			/// </value>
			public string Name
			{
				get => TrusteeForm == TRUSTEE_FORM.TRUSTEE_IS_NAME ? Marshal.PtrToStringAuto(ptstrName) : null;
				set { ((IDisposable)this).Dispose(); TrusteeForm = TRUSTEE_FORM.TRUSTEE_IS_NAME; ptstrName = Marshal.StringToHGlobalAuto(value); }
			}

			/// <summary>Gets or sets the sid for the trustee</summary>
			/// <value>The Sid.</value>
			public PSID Sid
			{
				get => TrusteeForm == TRUSTEE_FORM.TRUSTEE_IS_SID ? PSID.CreateFromPtr(ptstrName) : null;
				set
				{
					((IDisposable)this).Dispose();
					TrusteeForm = TRUSTEE_FORM.TRUSTEE_IS_SID;
					var b = value.GetBinaryForm();
					ptstrName = Marshal.AllocHGlobal(b.Length);
					Marshal.Copy(b, 0, ptstrName, b.Length);
				}
			}
		}
	}
}