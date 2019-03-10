using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using Vanara.Extensions;
using Vanara.Security;
using static Vanara.PInvoke.NetApi32;

namespace Vanara
{
	/// <summary>Offline settings for a shared folder.</summary>
	public enum ShareOfflineSettings
	{
		/// <summary>Only the files and programs that users specify are available offline.</summary>
		OnlySpecified = SHI1005_FLAGS.CSC_CACHE_MANUAL_REINT,

		/// <summary>All files and programs that users open from the shared folder are automatically available offline.</summary>
		All = SHI1005_FLAGS.CSC_CACHE_AUTO_REINT,

		/// <summary>
		/// All files and programs that users open from the shared folder are automatically available offline and are cached for performance.
		/// </summary>
		AllOptimized = SHI1005_FLAGS.CSC_CACHE_VDO,

		/// <summary>No files or programs from the shared folder are available offline.</summary>
		None = SHI1005_FLAGS.CSC_CACHE_NONE,
	}

	/// <summary>Represents a shared device on a computer.</summary>
	/// <seealso cref="Vanara.INamedEntity"/>
	public class SharedDevice : INamedEntity
	{
		private readonly WindowsIdentity identity;
		private readonly string target;
		private STYPE type = (STYPE)uint.MaxValue;

		internal SharedDevice(string target, string netname, WindowsIdentity accessIdentity)
		{
			identity = accessIdentity;
			this.target = target;
			Name = netname;
		}

		/// <summary>Gets or sets an optional comment about the shared resource.</summary>
		/// <value>The resource description.</value>
		public string Description
		{
			get => GetInfo<SHARE_INFO_1>().shi1_remark;
			set => SetInfo(new SHARE_INFO_1004 { shi1004_remark = value });
		}

		/// <summary>Gets a value indicating whether this instance is communication device.</summary>
		/// <value><see langword="true"/> if this instance is communication device; otherwise, <see langword="false"/>.</value>
		public bool IsCommDevice => (Type & STYPE.STYPE_MASK) == STYPE.STYPE_DEVICE;

		/// <summary>Gets a value indicating whether this instance is disk drive.</summary>
		/// <value><see langword="true"/> if this instance is disk drive; otherwise, <see langword="false"/>.</value>
		public bool IsDiskVolume => (Type & STYPE.STYPE_MASK) == STYPE.STYPE_DISKTREE;

		/// <summary>Gets a value indicating whether this instance is Interprocess Communication.</summary>
		/// <value><see langword="true"/> if this instance is Interprocess Communication; otherwise, <see langword="false"/>.</value>
		public bool IsIPC => (Type & STYPE.STYPE_MASK) == STYPE.STYPE_IPC;

		/// <summary>Gets a value indicating whether this instance is a print queue.</summary>
		/// <value><see langword="true"/> if this instance is a print queue; otherwise, <see langword="false"/>.</value>
		public bool IsPrintQueue => (Type & STYPE.STYPE_MASK) == STYPE.STYPE_PRINTQ;

		/// <summary>
		/// Gets a value indicating a special share reserved for interprocess communication (IPC$) or remote administration of the server
		/// (ADMIN$). Can also refer to administrative shares such as C$, D$, E$, and so forth.
		/// </summary>
		/// <value><see langword="true"/> if this instance is special; otherwise, <see langword="false"/>.</value>
		public bool IsSpecial => Type.IsFlagSet(STYPE.STYPE_SPECIAL);

		/// <summary>Gets a value indicating whether this instance is temporary.</summary>
		/// <value><see langword="true"/> if this instance is temporary; otherwise, <see langword="false"/>.</value>
		public bool IsTemporary => Type.IsFlagSet(STYPE.STYPE_TEMPORARY);

		/// <summary>Gets the share name of a resource.</summary>
		/// <value>Returns a <see cref="string"/> value.</value>
		public string Name { get; }

		/// <summary>Gets or sets the offline settings associated with a disk volume share.</summary>
		/// <value>The offline settings.</value>
		public ShareOfflineSettings OfflineSettings
		{
			get => (ShareOfflineSettings)(GetInfo<SHARE_INFO_1005>().shi1005_flags & SHI1005_FLAGS.CSC_MASK_EXT);
			set
			{
				var i = GetInfo<SHARE_INFO_1005>();
				i.shi1005_flags = i.shi1005_flags & ~SHI1005_FLAGS.CSC_MASK | (SHI1005_FLAGS)value;
				SetInfo(i);
			}
		}

		/// <summary>
		/// Gets or sets the local path for the shared resource. For disks, this is the path being shared. For print queues, this is the name
		/// of the print queue being shared.
		/// </summary>
		/// <value>
		/// Returns a <see cref="string"/> value. If the caller does not have rights to get this information, this property returns <see cref="string.Empty"/>.
		/// </value>
		public string Path
		{
			get
			{
				try { return GetInfo<SHARE_INFO_2>().shi2_path; } catch { return string.Empty; }
			}
			set
			{
				var i = GetInfo<SHARE_INFO_2>();
				i.shi2_path = value;
				SetInfo(i);
			}
		}

		/// <summary>Gets or sets the permissions of the shared resource.</summary>
		/// <value>
		/// The access permissions for the share. If the caller does not have rights to get this information, this property returns <see langword="null"/>.
		/// </value>
		public RawSecurityDescriptor Permissions
		{
			get
			{
				try { return GetInfo<SHARE_INFO_502>().shi502_security_descriptor.ToManaged(); } catch { return null; }
			}
			set
			{
				var i = GetInfo<SHARE_INFO_502>();
				i.shi502_security_descriptor = value.ToNative();
				SetInfo(i);
			}
		}

		/// <summary>
		/// Gets or sets the maximum number of concurrent connections that the shared resource can accommodate. The number of connections is
		/// unlimited if the value specified in this member is –1.
		/// </summary>
		/// <value>The maximum number of concurrent connections.</value>
		public int UserLimit
		{
			get
			{
				try { return unchecked((int)GetInfo<SHARE_INFO_2>().shi2_max_uses); } catch { return -1; }
			}
			set
			{
				var i = GetInfo<SHARE_INFO_2>();
				i.shi2_max_uses = unchecked((uint)value);
				SetInfo(i);
			}
		}

		/// <summary>Gets the shared resource's permissions for servers running with share-level security.</summary>
		/// <value>Returns a <see cref="ShareLevelAccess"/> value.</value>
		private ShareLevelAccess Access => GetInfo<SHARE_INFO_2>().shi2_permissions;

		private STYPE Type => (uint)type == uint.MaxValue ? type = GetInfo<SHARE_INFO_1>().shi1_type : type;

		/// <summary>Creates the disk volume share.</summary>
		/// <param name="target">
		/// A string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this parameter is
		/// <see langword="null"/>, the local computer is used.
		/// </param>
		/// <param name="name">The share name of a resource.</param>
		/// <param name="comment">An optional comment about the shared resource.</param>
		/// <param name="path">
		/// The local path for the shared resource. For disks, this is the path being shared. For print queues, this is the name of the print
		/// queue being shared.
		/// </param>
		/// <returns>On success, a new instance of <see cref="SharedDevice"/> represented a newly created shared disk.</returns>
		public static SharedDevice CreateDiskVolumeShare(string target, string name, string comment, string path) =>
			Create(target, name, comment, path, STYPE.STYPE_DISKTREE, null);

		/// <summary>Creates the specified target.</summary>
		/// <param name="target">A string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this parameter is
		/// <see langword="null" />, the local computer is used.</param>
		/// <param name="name">The share name of a resource.</param>
		/// <param name="comment">An optional comment about the shared resource.</param>
		/// <param name="path">The local path for the shared resource. For disks, this is the path being shared. For print queues, this is the name of the print
		/// queue being shared.</param>
		/// <param name="type">A combination of values that specify the type of the shared resource.</param>
		/// <param name="identity">The identity.</param>
		/// <returns>
		/// On success, a new instance of <see cref="SharedDevice" /> represented a newly created shared resource.
		/// </returns>
		internal static SharedDevice Create(string target, string name, string comment, string path, STYPE type, WindowsIdentity identity)
		{
			identity.Run(() => NetShareAdd(target, new SHARE_INFO_2 { shi2_netname = name, shi2_remark = comment, shi2_path = path, shi2_max_uses = unchecked((uint)-1), shi2_type = type }));
			return new SharedDevice(target, name, identity);
		}

		private T GetInfo<T>() where T : struct => identity.Run(() => NetShareGetInfo<T>(target, Name));

		private void SetInfo<T>(T s) where T : struct => identity.Run(() => NetShareSetInfo<T>(target, Name, s));
	}

	/// <summary>Represents all the shared devices on a computers.</summary>
	public class SharedDevices : Collections.VirtualDictionary<string, SharedDevice>
	{
		private readonly string target = null;
		private readonly WindowsIdentity identity;

		/// <summary>Initializes a new instance of the <see cref="SharedDevices" /> class.</summary>
		/// <param name="serverName">Name of the computer from which to retrieve and manage the shared devices.</param>
		/// <param name="accessIdentity">The Windows identity used to access the shared device information. If this value <see langword="null"/>, the current identity is used.</param>
		public SharedDevices(string serverName = null, WindowsIdentity accessIdentity = null) : base(false)
		{
			target = serverName;
			identity = accessIdentity;
		}

		internal SharedDevices(Computer computer) : this(computer.Target, computer.Identity)
		{
		}

		/// <summary>Gets the number of elements contained in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.</summary>
		/// <value>The number of elements contained in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.</value>
		public override int Count
		{
			get
			{
				var h = 0U;
				var cnt = 0U;
				identity.Run(() => NetShareEnum(target, 0, out var _, MAX_PREFERRED_LENGTH, out cnt, out _, ref h).ThrowIfFailed());
				return (int)cnt;
			}
		}

		/// <summary>Gets an <see cref="T:System.Collections.Generic.ICollection`1"/> containing the keys of the <see cref="T:System.Collections.Generic.IDictionary`2"/>.</summary>
		/// <value>An <see cref="T:System.Collections.Generic.ICollection`1"/> containing the keys of the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/>.</value>
		public override ICollection<string> Keys => identity.Run(() => NetShareEnum<SHARE_INFO_0>(target).Select(i => i.shi0_netname).ToArray());

		/// <summary>Creates the specified target.</summary>
		/// <param name="name">The share name of a resource.</param>
		/// <param name="comment">An optional comment about the shared resource.</param>
		/// <param name="path">
		/// The local path for the shared resource. For disks, this is the path being shared. For print queues, this is the name of the print
		/// queue being shared.
		/// </param>
		/// <param name="type">A combination of values that specify the type of the shared resource.</param>
		/// <returns>On success, a new instance of <see cref="SharedDevice"/> represented a newly created shared resource.</returns>
		public SharedDevice Add(string name, string comment, string path, STYPE type = STYPE.STYPE_DISKTREE) => SharedDevice.Create(target, name, comment, path, type, identity);

		/// <summary>Removes the element with the specified key from the <see cref="T:System.Collections.Generic.IDictionary`2"/>.</summary>
		/// <param name="key">The key of the element to remove.</param>
		/// <returns>
		/// <see langword="true"/> if the element is successfully removed; otherwise, <see langword="false"/>. This method also returns false
		/// if key was not found in the original <see cref="T:System.Collections.Generic.IDictionary`2"/>.
		/// </returns>
		public override bool Remove(string key) => identity.Run(() => NetShareDel(target, key).Succeeded);

		/// <summary>Gets the value associated with the specified key.</summary>
		/// <param name="key">The key whose value to get.</param>
		/// <param name="value">
		/// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the
		/// type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.
		/// </param>
		/// <returns>
		/// <see langword="true"/> if the <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the key;
		/// otherwise, <see langword="false"/>.
		/// </returns>
		public override bool TryGetValue(string key, out SharedDevice value)
		{
			value = ContainsKey(key) ? new SharedDevice(target, key, identity) : null;
			return !(value is null);
		}
	}
}