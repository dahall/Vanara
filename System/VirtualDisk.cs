using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.VirtDisk;

namespace Vanara.IO
{
	/// <summary>Class that represents a virtual disk and allows for performing actions on it. This wraps most of the methods found in virtdisk.h.</summary>
	/// <seealso cref="System.IDisposable"/>
	public class VirtualDisk : IDisposable
	{
		private static readonly bool IsPreWin8 = Environment.OSVersion.Version < new Version(6, 2);
		private VirtualDiskMetadata metadata;
		private readonly OPEN_VIRTUAL_DISK_VERSION ver;

		private VirtualDisk(SafeVIRTUAL_DISK_HANDLE handle, OPEN_VIRTUAL_DISK_VERSION version)
		{
			if (handle == null || handle.IsInvalid) throw new ArgumentNullException(nameof(handle));
			Handle = handle;
			ver = version;
		}

		/// <summary>Represents the format of the virtual disk.</summary>
		public enum DeviceType : uint
		{
			/// <summary>Device type is unknown or not valid.</summary>
			Unknown = VIRTUAL_STORAGE_TYPE_DEVICE_TYPE.VIRTUAL_STORAGE_TYPE_DEVICE_UNKNOWN,

			/// <summary>
			/// CD or DVD image file device type. (.iso file)
			/// <para><c>Windows 7 and Windows Server 2008 R2:</c> This value is not supported before Windows 8 and Windows Server 2012.</para>
			/// </summary>
			Iso = VIRTUAL_STORAGE_TYPE_DEVICE_TYPE.VIRTUAL_STORAGE_TYPE_DEVICE_ISO,

			/// <summary>Virtual hard disk device type. (.vhd file)</summary>
			Vhd = VIRTUAL_STORAGE_TYPE_DEVICE_TYPE.VIRTUAL_STORAGE_TYPE_DEVICE_VHD,

			/// <summary>
			/// VHDX format virtual hard disk device type. (.vhdx file)
			/// <para><c>Windows 7 and Windows Server 2008 R2:</c> This value is not supported before Windows 8 and Windows Server 2012.</para>
			/// </summary>
			Vhdx = VIRTUAL_STORAGE_TYPE_DEVICE_TYPE.VIRTUAL_STORAGE_TYPE_DEVICE_VHDX,

			/// <summary></summary>
			VhdSet = VIRTUAL_STORAGE_TYPE_DEVICE_TYPE.VIRTUAL_STORAGE_TYPE_DEVICE_VHDSET
		}

		/// <summary>Represents the subtype of a virtual disk.</summary>
		public enum Subtype : uint
		{
			Fixed = 2,
			Dynamic = 3,
			Differencing = 4
		}

		/// <summary>Indicates whether this virtual disk is currently attached.</summary>
		public bool Attached { get; private set; }

		/// <summary>Block size of the VHD, in bytes.</summary>
		public uint BlockSize => GetInformation<uint>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_SIZE, 16);

		/// <summary>The device identifier.</summary>
		public DeviceType DiskType => (DeviceType)GetInformation<uint>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_VIRTUAL_STORAGE_TYPE);

		/// <summary>Whether RCT is turned on. TRUE if RCT is turned on; otherwise FALSE.</summary>
		public bool Enabled => GetInformation<bool>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_CHANGE_TRACKING_STATE);

		/// <summary>The fragmentation level of the virtual disk.</summary>
		public uint FragmentationPercentage => GetInformation<uint>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_FRAGMENTATION);

		/// <summary>Gets the safe handle for the current virtual disk.</summary>
		private SafeVIRTUAL_DISK_HANDLE Handle { get; set; }

		/// <summary>Unique identifier of the VHD.</summary>
		public Guid Identifier
		{
			get => GetInformation<Guid>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_IDENTIFIER);
			set
			{
				var si = new SET_VIRTUAL_DISK_INFO { Version = SET_VIRTUAL_DISK_INFO_VERSION.SET_VIRTUAL_DISK_INFO_IDENTIFIER, UniqueIdentifier = value };
				SetVirtualDiskInformation(Handle, si).ThrowIfFailed();
			}
		}

		/// <summary>Indicates whether the virtual disk is 4 KB aligned.</summary>
		public bool Is4kAligned => GetInformation<bool>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_IS_4K_ALIGNED);

		/// <summary>
		/// Indicates whether the virtual disk is currently mounted and in use. TRUE if the virtual disk is currently mounted and in use; otherwise FALSE.
		/// </summary>
		public bool IsLoaded => GetInformation<bool>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_IS_LOADED);

		/// <summary>Indicates whether the physical disk is remote.</summary>
		public bool IsRemote => GetInformation<bool>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PHYSICAL_DISK, 8);

		/// <summary>The logical sector size of the physical disk.</summary>
		public uint LogicalSectorSize => GetInformation<uint>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PHYSICAL_DISK);

		/// <summary>Gets the metadata associated with this virtual disk. Currently on VHDX files support metadata.</summary>
		/// <value>The metadata.</value>
		public VirtualDiskMetadata Metadata => metadata ?? (metadata = new VirtualDiskMetadata(this));

		/// <summary>
		/// The change tracking identifier for the change that identifies the state of the virtual disk that you want to use as the basis of comparison to
		/// determine whether the NewerChanges member reports new changes.
		/// </summary>
		public string MostRecentId => GetInformation<string>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_CHANGE_TRACKING_STATE, 8);

		/// <summary>
		/// Whether the virtual disk has changed since the change identified by the MostRecentId member occurred. TRUE if the virtual disk has changed since the
		/// change identified by the MostRecentId member occurred; otherwise FALSE.
		/// </summary>
		public bool NewerChanges => GetInformation<bool>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_CHANGE_TRACKING_STATE, 4);

		/// <summary>The path of the parent backing store, if it can be resolved.</summary>
		public string ParentBackingStore
		{
			get
			{
				var parentResolved = GetInformation<bool>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PARENT_LOCATION);
				//return pl.ParentResolved ? Marshal.PtrToStringUni(pl.ParentLocationBuffer) : null;
				return parentResolved ? GetInformation<string>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PARENT_LOCATION, 4) : null;
			}
		}

		/// <summary>Unique identifier of the parent disk backing store.</summary>
		public Guid ParentIdentifier => GetInformation<Guid>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PARENT_IDENTIFIER);

		/// <summary>The path of the parent backing store, if it can be resolved.</summary>
		public string ParentPaths
		{
			get
			{
				var parentResolved = GetInformation<bool>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PARENT_LOCATION);
				//return pl.ParentResolved ? Marshal.PtrToStringUni(pl.ParentLocationBuffer) : null;
				return !parentResolved ? GetInformation<string>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PARENT_LOCATION, 4) : null;
			}
		}

		/// <summary>Internal time stamp of the parent disk backing store.</summary>
		public uint ParentTimeStamp => GetInformation<uint>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PARENT_TIMESTAMP);

		/// <summary>Retrieves the path to the physical device object that contains a virtual hard disk (VHD) or CD or DVD image file (ISO).</summary>
		public string PhysicalPath
		{
			get
			{
				var sz = 64;
				StringBuilder sb;
				Win32Error err;
				do
				{
					sb = new StringBuilder(sz *= 4);
					err = GetVirtualDiskPhysicalPath(Handle, ref sz, sb);
				} while (err == Win32Error.ERROR_INSUFFICIENT_BUFFER);
				err.ThrowIfFailed();
				return sb.ToString();
			}
		}

		/// <summary>The physical sector size of the physical disk.</summary>
		public uint PhysicalSectorSize
		{
			get => GetInformation<uint>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PHYSICAL_DISK, 4);
			set
			{
				var si = new SET_VIRTUAL_DISK_INFO { Version = SET_VIRTUAL_DISK_INFO_VERSION.SET_VIRTUAL_DISK_INFO_PHYSICAL_SECTOR_SIZE, VhdPhysicalSectorSize = value };
				SetVirtualDiskInformation(Handle, si).ThrowIfFailed();
			}
		}

		/// <summary>Physical size of the VHD on disk, in bytes.</summary>
		public ulong PhysicalSize => GetInformation<ulong>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_SIZE, 8);

		/// <summary>Provider-specific subtype.</summary>
		public Subtype ProviderSubtype => (Subtype)GetInformation<uint>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PROVIDER_SUBTYPE);

		/// <summary>Sector size of the VHD, in bytes.</summary>
		public uint SectorSize => GetInformation<uint>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_SIZE, 20);

		/// <summary>The smallest safe minimum size of the virtual disk.</summary>
		public ulong SmallestSafeVirtualSize => GetInformation<ulong>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_SMALLEST_SAFE_VIRTUAL_SIZE);

		/// <summary>Vendor-unique identifier.</summary>
		public Guid VendorId => GetInformation<Guid>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_VIRTUAL_STORAGE_TYPE, 4);

		/// <summary>The physical sector size of the virtual disk.</summary>
		public uint VhdPhysicalSectorSize => GetInformation<uint>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_VHD_PHYSICAL_SECTOR_SIZE);

		/// <summary>The identifier that is uniquely created when a user first creates the virtual disk to attempt to uniquely identify that virtual disk.</summary>
		public Guid VirtualDiskId
		{
			get => GetInformation<Guid>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_VIRTUAL_DISK_ID);
			set
			{
				var si = new SET_VIRTUAL_DISK_INFO { Version = SET_VIRTUAL_DISK_INFO_VERSION.SET_VIRTUAL_DISK_INFO_VIRTUAL_DISK_ID, VirtualDiskId = value };
				SetVirtualDiskInformation(Handle, si).ThrowIfFailed();
			}
		}

		/// <summary>Virtual size of the VHD, in bytes.</summary>
		public ulong VirtualSize => GetInformation<ulong>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_SIZE);

		/// <summary>Creates a virtual hard disk (VHD) image file.</summary>
		/// <param name="path">A valid file path that represents the path to the new virtual disk image file.</param>
		/// <param name="param">A reference to a valid CREATE_VIRTUAL_DISK_PARAMETERS structure that contains creation parameter data.</param>
		/// <param name="flags">Creation flags, which must be a valid combination of the CREATE_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="mask">The VIRTUAL_DISK_ACCESS_MASK value to use when opening the newly created virtual disk file.</param>
		/// <param name="securityDescriptor">
		/// An optional pointer to a SECURITY_DESCRIPTOR to apply to the virtual disk image file. If this parameter is IntPtr.Zero, the parent directory's
		/// security descriptor will be used.
		/// </param>
		/// <returns>If successful, returns a valid <see cref="VirtualDisk"/> instance for the newly created virtual disk.</returns>
		public static VirtualDisk Create(string path, ref CREATE_VIRTUAL_DISK_PARAMETERS param, CREATE_VIRTUAL_DISK_FLAG flags = CREATE_VIRTUAL_DISK_FLAG.CREATE_VIRTUAL_DISK_FLAG_NONE, VIRTUAL_DISK_ACCESS_MASK mask = VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE, PSECURITY_DESCRIPTOR securityDescriptor = default)
		{
			if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));
			var stType = new VIRTUAL_STORAGE_TYPE();
			CreateVirtualDisk(stType, path, mask, securityDescriptor, flags, 0, param, IntPtr.Zero, out var handle).ThrowIfFailed();
			return new VirtualDisk(handle, (OPEN_VIRTUAL_DISK_VERSION)param.Version);
		}

		/// <summary>Creates a virtual hard disk (VHD) image file, either using default parameters or using an existing VHD or physical disk.</summary>
		/// <param name="path">A valid file path that represents the path to the new virtual disk image file.</param>
		/// <param name="size">The maximum virtual size, in bytes, of the virtual disk object. Must be a multiple of 512.</param>
		/// <param name="dynamic">
		/// <c>true</c> to grow the disk dynamically as content is added; <c>false</c> to pre-allocate all physical space necessary for the size of the virtual disk.
		/// </param>
		/// <param name="access">
		/// An optional FileSecurity instance to apply to the attached virtual disk. If this parameter is <c>null</c>, the security descriptor of the virtual
		/// disk image file is used. Ensure that the security descriptor that AttachVirtualDisk applies to the attached virtual disk grants the write attributes
		/// permission for the user, or that the security descriptor of the virtual disk image file grants the write attributes permission for the user if you
		/// specify <c>null</c> for this parameter. If the security descriptor does not grant write attributes permission for a user, Shell displays the
		/// following error when the user accesses the attached virtual disk: The Recycle Bin is corrupted. Do you want to empty the Recycle Bin for this drive?
		/// </param>
		/// <returns>If successful, returns a valid <see cref="VirtualDisk"/> instance for the newly created virtual disk.</returns>
		public static VirtualDisk Create(string path, ulong size, bool dynamic = true, FileSecurity access = null) => Create(path, size, dynamic, 0, 0, access);

		/// <summary>Creates a virtual hard disk (VHD) image file, either using default parameters or using an existing VHD or physical disk.</summary>
		/// <param name="path">A valid file path that represents the path to the new virtual disk image file.</param>
		/// <param name="size">The maximum virtual size, in bytes, of the virtual disk object. Must be a multiple of 512.</param>
		/// <param name="dynamic">
		/// <c>true</c> to grow the disk dynamically as content is added; <c>false</c> to pre-allocate all physical space necessary for the size of the virtual disk.
		/// </param>
		/// <param name="blockSize">
		/// Internal size of the virtual disk object blocks, in bytes. For VHDX this must be a multiple of 1 MB between 1 and 256 MB. For VHD 1 this must be set
		/// to one of the following values: 0 (default), 0x80000 (512K), or 0x200000 (2MB)
		/// </param>
		/// <param name="logicalSectorSize">
		/// Internal size of the virtual disk object sectors. For VHDX must be set to 512 (0x200) or 4096 (0x1000). For VHD 1 must be set to 512.
		/// </param>
		/// <param name="access">
		/// An optional FileSecurity instance to apply to the attached virtual disk. If this parameter is <c>null</c>, the security descriptor of the virtual
		/// disk image file is used. Ensure that the security descriptor that AttachVirtualDisk applies to the attached virtual disk grants the write attributes
		/// permission for the user, or that the security descriptor of the virtual disk image file grants the write attributes permission for the user if you
		/// specify <c>null</c> for this parameter. If the security descriptor does not grant write attributes permission for a user, Shell displays the
		/// following error when the user accesses the attached virtual disk: The Recycle Bin is corrupted. Do you want to empty the Recycle Bin for this drive?
		/// </param>
		/// <returns>If successful, returns a valid <see cref="VirtualDisk"/> instance for the newly created virtual disk.</returns>
		public static VirtualDisk Create(string path, ulong size, bool dynamic, uint blockSize = 0, uint logicalSectorSize = 0, FileSecurity access = null)
		{
			if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));

			var mask = IsPreWin8 ? VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_CREATE : VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE;
			var sd = FileSecToSd(access);
			var param = new CREATE_VIRTUAL_DISK_PARAMETERS(size, IsPreWin8 ? 1U : 2U, blockSize, logicalSectorSize);
			var flags = dynamic ? CREATE_VIRTUAL_DISK_FLAG.CREATE_VIRTUAL_DISK_FLAG_NONE : CREATE_VIRTUAL_DISK_FLAG.CREATE_VIRTUAL_DISK_FLAG_FULL_PHYSICAL_ALLOCATION;
			return Create(path, ref param, flags, mask, sd);
		}

		/// <summary>Creates a virtual hard disk (VHD) image file, either using default parameters or using an existing VHD or physical disk.</summary>
		/// <param name="path">A valid string that represents the path to the new virtual disk image file.</param>
		/// <param name="parentPath"></param>
		/// <param name="access">
		/// An optional pointer to a FileSecurity instance to apply to the attached virtual disk. If this parameter is NULL, the security descriptor of the
		/// virtual disk image file is used. Ensure that the security descriptor that AttachVirtualDisk applies to the attached virtual disk grants the write
		/// attributes permission for the user, or that the security descriptor of the virtual disk image file grants the write attributes permission for the
		/// user if you specify NULL for this parameter.If the security descriptor does not grant write attributes permission for a user, Shell displays the
		/// following error when the user accesses the attached virtual disk: The Recycle Bin is corrupted.Do you want to empty the Recycle Bin for this drive?
		/// </param>
		/// <returns></returns>
		public static VirtualDisk CreateDifferencing(string path, string parentPath, FileSecurity access = null)
		{
			//if (access == null) access = GetFileSecurity();
			if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));
			if (string.IsNullOrEmpty(parentPath)) throw new ArgumentNullException(nameof(parentPath));

			// If this is V2 (>=Win8), then let the file extension determine type, otherwise, it has to be a VHD
			var mask = IsPreWin8 ? VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_CREATE : VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE;
			var sd = FileSecToSd(access);
			var param = new CREATE_VIRTUAL_DISK_PARAMETERS { Version = IsPreWin8 ? CREATE_VIRTUAL_DISK_VERSION.CREATE_VIRTUAL_DISK_VERSION_1 : CREATE_VIRTUAL_DISK_VERSION.CREATE_VIRTUAL_DISK_VERSION_2 };
			var pp = new SafeCoTaskMemString(parentPath);
			if (IsPreWin8)
				param.Version1.ParentPath = (IntPtr)pp;
			else
				param.Version2.ParentPath = (IntPtr)pp;
			return Create(path, ref param, CREATE_VIRTUAL_DISK_FLAG.CREATE_VIRTUAL_DISK_FLAG_NONE, mask, sd);
		}

		/// <summary>Creates a virtual hard disk (VHD) image file, either using default parameters or using an existing VHD or physical disk.</summary>
		/// <param name="path">A valid file path that represents the path to the new virtual disk image file.</param>
		/// <param name="sourcePath">
		/// A fully qualified path to pre-populate the new virtual disk object with block data from an existing disk. This path may refer to a virtual disk or a
		/// physical disk.
		/// </param>
		/// <returns>If successful, returns a valid <see cref="VirtualDisk"/> instance for the newly created virtual disk.</returns>
		public static VirtualDisk CreateFromSource(string path, string sourcePath)
		{
			if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));
			if (string.IsNullOrEmpty(sourcePath)) throw new ArgumentNullException(nameof(sourcePath));

			var param = new CREATE_VIRTUAL_DISK_PARAMETERS(0, IsPreWin8 ? 1U : 2U);
			var mask = IsPreWin8 ? VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_CREATE : VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE;
			var sp = new SafeCoTaskMemString(sourcePath);
			if (IsPreWin8)
				param.Version1.SourcePath = (IntPtr)sp;
			else
				param.Version2.SourcePath = (IntPtr)sp;
			return Create(path, ref param, CREATE_VIRTUAL_DISK_FLAG.CREATE_VIRTUAL_DISK_FLAG_NONE, mask);
		}

		/// <summary>
		/// Detach a virtual disk that was previously attached with the ATTACH_VIRTUAL_DISK_FLAG_PERMANENT_LIFETIME flag or calling
		/// <see cref="Attach(bool, bool, bool, FileSecurity)"/> and setting autoDetach to <c>false</c>.
		/// </summary>
		/// <param name="path">A valid path to the virtual disk image to detach.</param>
		public static void Detach(string path)
		{
			try
			{
				var vd = Open(path, OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NONE, null, VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_DETACH);
				vd.Detach();
			}
			catch { }
		}

		/// <summary>Gets the list of all the loopback mounted virtual disks.</summary>
		/// <returns>An enumeration of all the loopback mounted virtual disks physical paths.</returns>
		public static IEnumerable<string> GetAllAttachedVirtualDiskPaths()
		{
			uint sz = 0;
			var sb = new SafeCoTaskMemHandle(0);
			Win32Error err;
			do
			{
				err = GetAllAttachedVirtualDiskPhysicalPaths(ref sz, (IntPtr)sb);
				if (err.Succeeded) break;
				if (err != Win32Error.ERROR_INSUFFICIENT_BUFFER) err.ThrowIfFailed();
				sb.Size = (int)sz;
			} while (err == Win32Error.ERROR_INSUFFICIENT_BUFFER);
			return sb.Size <= 1 ? new string[0] : sb.ToStringEnum(CharSet.Unicode);
		}

		/// <summary>Creates an instance of a Virtual Disk from a file.</summary>
		/// <param name="path">A valid path to the virtual disk image to open.</param>
		/// <param name="flags">A valid combination of values of the OPEN_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="param">A valid OPEN_VIRTUAL_DISK_PARAMETERS structure.</param>
		/// <param name="mask">A valid VIRTUAL_DISK_ACCESS_MASK value.</param>
		public static VirtualDisk Open(string path, OPEN_VIRTUAL_DISK_FLAG flags = OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NONE, OPEN_VIRTUAL_DISK_PARAMETERS param = null, VIRTUAL_DISK_ACCESS_MASK mask = VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE)
		{
			if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));
			var stType = new VIRTUAL_STORAGE_TYPE();
			Debug.WriteLine($"OpenVD: mask={mask}; flags={flags}; param={param}");
			OpenVirtualDisk(stType, path, mask, flags, param, out var hVhd).ThrowIfFailed();
			return new VirtualDisk(hVhd, param?.Version ?? (IsPreWin8 ? OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_1 : OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_2));
		}

		/// <summary>Creates an instance of a Virtual Disk from a file.</summary>
		/// <param name="path">A valid path to the virtual disk image to open.</param>
		/// <param name="readOnly">If TRUE, indicates the file backing store is to be opened as read-only.</param>
		/// <param name="getInfoOnly">If TRUE, indicates the handle is only to be used to get information on the virtual disk.</param>
		/// <param name="noParents">
		/// Open the VHD file (backing store) without opening any differencing-chain parents. Used to correct broken parent links. This flag is not supported for
		/// ISO virtual disks.
		/// </param>
		public static VirtualDisk Open(string path, bool readOnly, bool getInfoOnly = false, bool noParents = false)
		{
			if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));
			var mask = VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE;
			var flags = OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NONE;
			if (noParents) flags |= OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS;
			OPEN_VIRTUAL_DISK_PARAMETERS param;
			var isIso = Path.GetExtension(path).Equals(".iso", StringComparison.InvariantCultureIgnoreCase);
			if (isIso && (!readOnly || noParents)) throw new NotSupportedException();
			if (isIso || IsPreWin8)
			{
				param = new OPEN_VIRTUAL_DISK_PARAMETERS(0); // make v1 instance
				if (readOnly) mask |= VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_READ;
				if (getInfoOnly) mask |= VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_GET_INFO;
			}
			else
				param = new OPEN_VIRTUAL_DISK_PARAMETERS(readOnly, getInfoOnly);
			return Open(path, flags, param, mask);
		}

		/// <summary>Attaches a virtual hard disk (VHD) or CD or DVD image file (ISO) by locating an appropriate VHD provider to accomplish the attachment.</summary>
		/// <param name="flags">A valid combination of values of the ATTACH_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="param">A reference to a valid ATTACH_VIRTUAL_DISK_PARAMETERS structure that contains attachment parameter data.</param>
		/// <param name="securityDescriptor">
		/// An optional pointer to a SECURITY_DESCRIPTOR to apply to the attached virtual disk. If this parameter is NULL, the security descriptor of the virtual
		/// disk image file is used.
		/// <para>
		/// Ensure that the security descriptor that AttachVirtualDisk applies to the attached virtual disk grants the write attributes permission for the user,
		/// or that the security descriptor of the virtual disk image file grants the write attributes permission for the user if you specify NULL for this
		/// parameter. If the security descriptor does not grant write attributes permission for a user, Shell displays the following error when the user
		/// accesses the attached virtual disk: The Recycle Bin is corrupted. Do you want to empty the Recycle Bin for this drive?
		/// </para>
		/// </param>
		public void Attach(ATTACH_VIRTUAL_DISK_FLAG flags, ref ATTACH_VIRTUAL_DISK_PARAMETERS param, PSECURITY_DESCRIPTOR securityDescriptor)
		{
			AdvApi32.ConvertSecurityDescriptorToStringSecurityDescriptor(securityDescriptor, AdvApi32.SDDL_REVISION.SDDL_REVISION_1, (SECURITY_INFORMATION)7, out var ssd, out var _);
			Debug.WriteLine($"AttachVD: flags={flags}; sddl={ssd}, param={param.Version},{param.Version1.Reserved}");
			AttachVirtualDisk(Handle, securityDescriptor, flags, 0, param, IntPtr.Zero).ThrowIfFailed();
			if (!flags.IsFlagSet(ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_PERMANENT_LIFETIME)) Attached = true;
		}

		/// <summary>Attaches a virtual hard disk (VHD) or CD or DVD image file (ISO) by locating an appropriate VHD provider to accomplish the attachment.</summary>
		/// <param name="readOnly">Attach the virtual disk as read-only.</param>
		/// <param name="autoDetach">
		/// If <c>false</c>, decouple the virtual disk lifetime from that of the VirtualDisk. The virtual disk will be attached until the Detach function is
		/// called, even if all open instances of the virtual disk are disposed.
		/// </param>
		/// <param name="noDriveLetter">No drive letters are assigned to the disk's volumes.</param>
		/// <param name="access">
		/// An optional pointer to a FileSecurity instance to apply to the attached virtual disk. If this parameter is NULL, the security descriptor of the
		/// virtual disk image file is used. Ensure that the security descriptor that AttachVirtualDisk applies to the attached virtual disk grants the write
		/// attributes permission for the user, or that the security descriptor of the virtual disk image file grants the write attributes permission for the
		/// user if you specify NULL for this parameter.If the security descriptor does not grant write attributes permission for a user, Shell displays the
		/// following error when the user accesses the attached virtual disk: The Recycle Bin is corrupted.Do you want to empty the Recycle Bin for this drive?
		/// </param>
		public void Attach(bool readOnly = false, bool autoDetach = true, bool noDriveLetter = false, FileSecurity access = null)
		{
			//if (access == null) access = GetWorldFullFileSecurity();
			var flags = readOnly ? ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_READ_ONLY : 0;
			if (!autoDetach) flags |= ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_PERMANENT_LIFETIME;
			if (noDriveLetter) flags |= ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_NO_DRIVE_LETTER;
			var param = ATTACH_VIRTUAL_DISK_PARAMETERS.Default;
			var sd = FileSecToSd(access);
			Attach(flags, ref param, sd);
		}

		/// <summary>Closes the instance of the virtual disk.</summary>
		public void Close() { Dispose(); }

		/// <summary>Reduces the size of a virtual hard disk (VHD) backing store file.</summary>
		public void Compact()
		{
			var param = COMPACT_VIRTUAL_DISK_PARAMETERS.Default;
			CompactVirtualDisk(Handle, COMPACT_VIRTUAL_DISK_FLAG.COMPACT_VIRTUAL_DISK_FLAG_NONE, param, IntPtr.Zero).ThrowIfFailed();
		}

		/// <summary>
		/// Detaches a virtual hard disk (VHD) or CD or DVD image file (ISO) by locating an appropriate virtual disk provider to accomplish the operation.
		/// </summary>
		public void Detach()
		{
			if (!Attached) return;
			DetachVirtualDisk(Handle, DETACH_VIRTUAL_DISK_FLAG.DETACH_VIRTUAL_DISK_FLAG_NONE, 0).ThrowIfFailed();
			Attached = false;
		}

		/// <inheritdoc/>
		public virtual void Dispose()
		{
			if (Attached) Detach();
			Handle.Dispose();
		}

		/// <summary>Increases the size of a fixed or dynamic virtual hard disk (VHD).</summary>
		/// <param name="newSize">New size, in bytes, for the expansion request.</param>
		public void Expand(ulong newSize)
		{
			if (ver < OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_2) throw new NotSupportedException(@"Expansion is only available to virtual disks opened under version 2 or higher.");
			var param = new EXPAND_VIRTUAL_DISK_PARAMETERS(newSize);
			ExpandVirtualDisk(Handle, EXPAND_VIRTUAL_DISK_FLAG.EXPAND_VIRTUAL_DISK_FLAG_NONE, param, IntPtr.Zero).ThrowIfFailed();
		}

		/// <summary>Merges a child virtual hard disk (VHD) in a differencing chain with parent disks in the chain.</summary>
		/// <param name="sourceDepth">Depth from the leaf from which to begin the merge. The leaf is at depth 1.</param>
		/// <param name="targetDepth">Depth from the leaf to target the merge. The leaf is at depth 1.</param>
		public void Merge(uint sourceDepth, uint targetDepth)
		{
			var param = new MERGE_VIRTUAL_DISK_PARAMETERS(sourceDepth, targetDepth);
			MergeVirtualDisk(Handle, MERGE_VIRTUAL_DISK_FLAG.MERGE_VIRTUAL_DISK_FLAG_NONE, param, IntPtr.Zero).ThrowIfFailed();
		}

		/// <summary>Merges a child virtual hard disk (VHD) in a differencing chain with its immediate parent disk in the chain.</summary>
		public void MergeWithParent()
		{
			var param = new MERGE_VIRTUAL_DISK_PARAMETERS(1);
			MergeVirtualDisk(Handle, MERGE_VIRTUAL_DISK_FLAG.MERGE_VIRTUAL_DISK_FLAG_NONE, param, IntPtr.Zero).ThrowIfFailed();
		}

		/// <summary>Resizes a virtual disk.</summary>
		/// <param name="newSize">
		/// New size, in bytes, for the expansion request. Setting this value to '0' will shrink the disk to the smallest safe virtual size possible without
		/// truncating past any existing partitions.
		/// </param>
		public void Resize(ulong newSize)
		{
			if (ver < OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_2) throw new NotSupportedException(@"Expansion is only available to virtual disks opened under version 2 or higher.");
			var flags = newSize == 0 ? RESIZE_VIRTUAL_DISK_FLAG.RESIZE_VIRTUAL_DISK_FLAG_RESIZE_TO_SMALLEST_SAFE_VIRTUAL_SIZE : RESIZE_VIRTUAL_DISK_FLAG.RESIZE_VIRTUAL_DISK_FLAG_NONE;
			var param = new RESIZE_VIRTUAL_DISK_PARAMETERS(newSize);
			ResizeVirtualDisk(Handle, flags, param, IntPtr.Zero).ThrowIfFailed();
		}

		/// <summary>
		/// Resizes a virtual disk without checking the virtual disk's partition table to ensure that this truncation is safe. <note type="warning">This method
		/// can cause unrecoverable data loss; use with care.</note>
		/// </summary>
		/// <param name="newSize">New size, in bytes, for the expansion request.</param>
		public void UnsafeResize(ulong newSize)
		{
			if (ver < OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_2) throw new NotSupportedException(@"Expansion is only available to virtual disks opened under version 2 or higher.");
			var flags = RESIZE_VIRTUAL_DISK_FLAG.RESIZE_VIRTUAL_DISK_FLAG_ALLOW_UNSAFE_VIRTUAL_SIZE;
			var param = new RESIZE_VIRTUAL_DISK_PARAMETERS(newSize);
			ResizeVirtualDisk(Handle, flags, param, IntPtr.Zero).ThrowIfFailed();
		}

		/// <summary>Creates a virtual hard disk (VHD) image file, either using default parameters or using an existing VHD or physical disk.</summary>
		/// <param name="path">A valid file path that represents the path to the new virtual disk image file.</param>
		/// <param name="sourcePath">
		/// A fully qualified path to pre-populate the new virtual disk object with block data from an existing disk. This path may refer to a virtual disk or a
		/// physical disk.
		/// </param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the operation. This value can be <c>null</c> to disable cancellation.</param>
		/// <param name="progress">
		/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable progress reporting.
		/// </param>
		/// <returns>If successful, returns a valid <see cref="VirtualDisk"/> instance for the newly created virtual disk.</returns>
		// TODO: Get async CreateFromSource working. Problem: passing new handle back to calling thread causes exceptions.
		private async static Task<VirtualDisk> CreateFromSource(string path, string sourcePath, CancellationToken cancellationToken, IProgress<int> progress)
		{
			if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));
			if (string.IsNullOrEmpty(sourcePath)) throw new ArgumentNullException(nameof(sourcePath));

			var param = new CREATE_VIRTUAL_DISK_PARAMETERS(0, IsPreWin8 ? 1U : 2U);
			var h = IntPtr.Zero;
			var b = await RunAsync(cancellationToken, progress, VIRTUAL_DISK_HANDLE.NULL, (ref NativeOverlapped vhdOverlap) =>
				{
					var sp = new SafeCoTaskMemString(sourcePath);
					var stType = new VIRTUAL_STORAGE_TYPE();
					var mask = IsPreWin8 ? VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_CREATE : VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE;
					if (IsPreWin8)
						param.Version1.SourcePath = (IntPtr)sp;
					else
						param.Version2.SourcePath = (IntPtr)sp;
					var flags = CREATE_VIRTUAL_DISK_FLAG.CREATE_VIRTUAL_DISK_FLAG_NONE;
					var err = CreateVirtualDisk(stType, path, mask, PSECURITY_DESCRIPTOR.NULL, flags, 0, param, ref vhdOverlap, out var hVhd);
					if (err.Succeeded)
					{
						h = hVhd.DangerousGetHandle();
						hVhd.SetHandleAsInvalid();
					}
					return err;
				}
			);
#if (NET20 || NET35)
			if (!b) throw new OperationCanceledExceptionEx(cancellationToken);
#else
			if (!b) throw new OperationCanceledException(cancellationToken);
#endif
			return new VirtualDisk(new SafeVIRTUAL_DISK_HANDLE(h), (OPEN_VIRTUAL_DISK_VERSION)param.Version);
		}

		/// <summary>Reduces the size of a virtual hard disk (VHD) backing store file.</summary>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the operation. This value can be <c>null</c> to disable cancellation.</param>
		/// <param name="progress">
		/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable progress reporting.
		/// </param>
		/// <returns><c>true</c> if operation completed without error or cancellation; <c>false</c> otherwise.</returns>
		public async Task<bool> Compact(CancellationToken cancellationToken, IProgress<int> progress)
		{
			return await RunAsync(cancellationToken, progress, Handle, (ref NativeOverlapped vhdOverlap) =>
				{
					var cParam = COMPACT_VIRTUAL_DISK_PARAMETERS.Default;
					return CompactVirtualDisk(Handle, COMPACT_VIRTUAL_DISK_FLAG.COMPACT_VIRTUAL_DISK_FLAG_NONE, cParam, ref vhdOverlap);
				}
			);
		}

		/// <summary>Increases the size of a fixed or dynamic virtual hard disk (VHD).</summary>
		/// <param name="newSize">New size, in bytes, for the expansion request.</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the operation. This value can be <c>null</c> to disable cancellation.</param>
		/// <param name="progress">
		/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable progress reporting.
		/// </param>
		/// <returns><c>true</c> if operation completed without error or cancellation; <c>false</c> otherwise.</returns>
		public async Task<bool> Expand(ulong newSize, CancellationToken cancellationToken, IProgress<int> progress)
		{
			return await RunAsync(cancellationToken, progress, Handle, (ref NativeOverlapped vhdOverlap) =>
				{
					if (ver < OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_2) throw new NotSupportedException(@"Expansion is only available to virtual disks opened under version 2 or higher.");
					var param = new EXPAND_VIRTUAL_DISK_PARAMETERS(newSize);
					return ExpandVirtualDisk(Handle, EXPAND_VIRTUAL_DISK_FLAG.EXPAND_VIRTUAL_DISK_FLAG_NONE, param, ref vhdOverlap);
				}
			);
		}

		/// <summary>Resizes a virtual disk.</summary>
		/// <param name="newSize">New size, in bytes, for the expansion request.</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the operation. This value can be <c>null</c> to disable cancellation.</param>
		/// <param name="progress">
		/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable progress reporting.
		/// </param>
		/// <returns><c>true</c> if operation completed without error or cancellation; <c>false</c> otherwise.</returns>
		public async Task<bool> Resize(ulong newSize, CancellationToken cancellationToken, IProgress<int> progress)
		{
			return await RunAsync(cancellationToken, progress, Handle, (ref NativeOverlapped vhdOverlap) =>
				{
					if (ver < OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_2) throw new NotSupportedException(@"Expansion is only available to virtual disks opened under version 2 or higher.");
					var param = new RESIZE_VIRTUAL_DISK_PARAMETERS(newSize);
					return ResizeVirtualDisk(Handle, RESIZE_VIRTUAL_DISK_FLAG.RESIZE_VIRTUAL_DISK_FLAG_NONE, param, ref vhdOverlap);
				}
			);
		}

		private async static Task<bool> GetProgress(VIRTUAL_DISK_HANDLE phVhd, NativeOverlapped reset, CancellationToken cancellationToken, IProgress<int> progress)
		{
			progress?.Report(0);
			while (true)
			{
				var perr = GetVirtualDiskOperationProgress(phVhd, ref reset, out var prog);
				perr.ThrowIfFailed();
				if (cancellationToken != null && cancellationToken.IsCancellationRequested) return false;
				switch (prog.OperationStatus)
				{
					case 0:
						progress?.Report(100);
						return true;

					case Win32Error.ERROR_IO_PENDING:
						progress?.Report((int)(prog.CurrentValue * 100 / prog.CompletionValue));
						break;

					default:
						new Win32Error((int)prog.OperationStatus).ThrowIfFailed();
						break;
				}
				if (prog.CurrentValue == prog.CompletionValue) return true;
#if NET40
				if (cancellationToken == null)
					await TaskEx.Delay(250);
				else
					await TaskEx.Delay(250, cancellationToken);
#else
				if (cancellationToken == null)
					await Task.Delay(250);
				else
					await Task.Delay(250, cancellationToken);
#endif
			}
		}

		private delegate Win32Error RunAsyncMethod(ref NativeOverlapped overlap);

		private static async Task<bool> RunAsync(CancellationToken cancellationToken, IProgress<int> progress, VIRTUAL_DISK_HANDLE hVhd, RunAsyncMethod method)
		{
			var vhdOverlapEvent = new ManualResetEvent(false);
			var vhdOverlap = new NativeOverlapped { EventHandle = vhdOverlapEvent.SafeWaitHandle.DangerousGetHandle() };
			var err = method(ref vhdOverlap);
			if (err != Win32Error.ERROR_IO_PENDING) err.ThrowIfFailed();
			return await GetProgress(hVhd, vhdOverlap, cancellationToken, progress);
		}

		/*private static async Task CompactVHD(string loc, CancellationToken cancellationToken, IProgress<Tuple<int, string>> progress)
		{
			var vhdOverlapEvent = new ManualResetEvent(false);
			var vhdOverlap = new NativeOverlapped { EventHandle = vhdOverlapEvent.SafeWaitHandle.DangerousGetHandle() };
			var cParam = COMPACT_VIRTUAL_DISK_PARAMETERS.Default;
			var taskComplete = false;

			// Perform file-system-aware compaction
			using (var vd = VirtualDisk.Open(loc))
			{
				vd.Attach(true);

				var err = CompactVirtualDisk(vd.Handle, COMPACT_VIRTUAL_DISK_FLAG.COMPACT_VIRTUAL_DISK_FLAG_NONE, ref cParam, ref vhdOverlap);
				if (err != Win32Error.ERROR_IO_PENDING) err.ThrowIfFailed();

				// Loop getting status
				taskComplete = await GetProgress(vd.Handle, 1);
			}

			// If first op fails, don't bother with the second
			if (!taskComplete) return;

			// Perform file-system-agnostic compaction
			vhdOverlapEvent.Reset();
			using (var vd = VirtualDisk.Open(loc))
			{
				var err = CompactVirtualDisk(vd.Handle, COMPACT_VIRTUAL_DISK_FLAG.COMPACT_VIRTUAL_DISK_FLAG_NONE, ref cParam, ref vhdOverlap);
				if (err != Win32Error.ERROR_IO_PENDING) err.ThrowIfFailed();

				// Loop getting status
				await GetProgress(vd.Handle, 2);
			}

			async Task<bool> GetProgress(HFILE phVhd, int step)
			{
				var prog = new VIRTUAL_DISK_PROGRESS();
				var start = step == 1 ? 0 : 50;
				var end = step == 1 ? 50 : 100;
				ReportProgress(start);
				while (true)
				{
					var perr = GetVirtualDiskOperationProgress(phVhd, ref vhdOverlap, ref prog);
					perr.ThrowIfFailed();
					if (cancellationToken.IsCancellationRequested) return false;
					switch (prog.OperationStatus)
					{
						case 0:
							ReportProgress(end);
							return true;

						case Win32Error.ERROR_IO_PENDING:
							ReportProgress(start + (int)(prog.CurrentValue * 50 / prog.CompletionValue));
							break;

						default:
							throw new Win32Exception((int)prog.OperationStatus);
					}
					if (prog.CurrentValue == prog.CompletionValue) return true;
					await Task.Delay(250, cancellationToken);
				}
			}

			void ReportProgress(int percent) { progress.Report(new Tuple<int, string>(percent, $"Compacting VHD volume \"{loc}\"")); }
		}*/

		private static SafePSECURITY_DESCRIPTOR FileSecToSd(FileSecurity sec)
		{
			return sec == null
				? SafePSECURITY_DESCRIPTOR.Null
				: ConvertStringSecurityDescriptorToSecurityDescriptor(sec.GetSecurityDescriptorSddlForm(AccessControlSections.All));
		}

		private T GetInformation<T>(GET_VIRTUAL_DISK_INFO_VERSION info, long offset = 0)
		{
			var sz = 32U;
			using (var mem = new SafeHGlobalHandle((int)sz))
			{
				Marshal.WriteInt32(mem.DangerousGetHandle(), (int)info);
				var err = GetVirtualDiskInformation(Handle, ref sz, (IntPtr)mem, out var req);
				if (err == Win32Error.ERROR_INSUFFICIENT_BUFFER)
				{
					mem.Size = (int)sz;
					Marshal.WriteInt32(mem.DangerousGetHandle(), (int)info);
					err = GetVirtualDiskInformation(Handle, ref sz, (IntPtr)mem, out req);
				}
				Debug.WriteLineIf(err.Succeeded, $"GetVirtualDiskInformation: Id={info.ToString().Remove(0, 22)}; Unk={Marshal.ReadInt32((IntPtr)mem, 4)}; Sz={req}; Bytes={string.Join(" ", mem.ToEnumerable<uint>((int)req / 4).Select(b => b.ToString("X8")).ToArray())}");
				err.ThrowIfFailed();

				if (typeof(T) == typeof(string))
				{
					if (mem.DangerousGetHandle().Offset(8 + offset).ToStructure<ushort>() == 0)
						return (T)(object)string.Empty;
					return (T)(object)Encoding.Unicode.GetString(mem.ToArray<byte>((int)sz), 8 + (int)offset, (int)sz - 8 - (int)offset).TrimEnd('\0');
				}

				var ms = new NativeMemoryStream(mem.DangerousGetHandle(), mem.Size) { Position = 8 + offset };
				return typeof(T) == typeof(bool) ? (T)Convert.ChangeType(ms.Read<uint>() != 0, typeof(bool)) : ms.Read<T>();
			}
		}

		/// <summary>Supports getting and setting metadata on a virtual disk.</summary>
		/// <seealso cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>
		public class VirtualDiskMetadata : IDictionary<Guid, SafeCoTaskMemHandle>
		{
			private readonly VirtualDisk parent;
			private readonly bool supported;

			/// <summary>Initializes a new instance of the <see cref="VirtualDiskMetadata"/> class.</summary>
			/// <param name="vhd">The VHD.</param>
			internal VirtualDiskMetadata(VirtualDisk vhd)
			{
				parent = vhd;
				supported = vhd.DiskType == DeviceType.Vhdx;
			}

			/// <summary>Gets a value indicating whether the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/> is read-only.</summary>
			public bool IsReadOnly => false;

			/// <summary>Gets an <see cref="ICollection{Guid}"/> containing the keys of the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>.</summary>
			public ICollection<Guid> Keys
			{
				get
				{
					if (!supported) return new Guid[0];
					if (parent.Handle.IsClosed) throw new InvalidOperationException("Virtual disk not valid.");
					uint count = 0;
					var err = EnumerateVirtualDiskMetadata(parent.Handle, ref count, IntPtr.Zero);
					if (err != Win32Error.ERROR_MORE_DATA && err != Win32Error.ERROR_INSUFFICIENT_BUFFER) err.ThrowIfFailed();
					if (count == 0) return new Guid[0];
					var mem = new SafeCoTaskMemHandle(Marshal.SizeOf(typeof(Guid)) * (int)count);
					EnumerateVirtualDiskMetadata(parent.Handle, ref count, (IntPtr)mem).ThrowIfFailed();
					return mem.ToArray<Guid>((int)count);
				}
			}

			/// <summary>Gets an <see cref="ICollection{SafeCoTaskMemHandle}"/> containing the values in the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>.</summary>
			public ICollection<SafeCoTaskMemHandle> Values => Keys.Select(k => this[k]).ToList();

			/// <summary>Gets the number of elements contained in the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>.</summary>
			public int Count => Keys.Count;

			/// <summary>Gets or sets the <see cref="SafeCoTaskMemHandle"/> with the specified key.</summary>
			/// <value>The <see cref="SafeCoTaskMemHandle"/>.</value>
			/// <param name="key">The key.</param>
			public SafeCoTaskMemHandle this[Guid key]
			{
				get
				{
					if (!supported) throw new PlatformNotSupportedException();
					if (parent.Handle.IsClosed) throw new InvalidOperationException("Virtual disk not valid.");
					uint sz = 0;
					var err = GetVirtualDiskMetadata(parent.Handle, key, ref sz, default);
					if (err != Win32Error.ERROR_MORE_DATA && err != Win32Error.ERROR_INSUFFICIENT_BUFFER) err.ThrowIfFailed();
					var ret = new SafeCoTaskMemHandle((int)sz);
					GetVirtualDiskMetadata(parent.Handle, key, ref sz, (IntPtr)ret).ThrowIfFailed();
					return ret;
				}
				set
				{
					if (!supported) throw new PlatformNotSupportedException();
					if (parent.Handle.IsClosed) throw new InvalidOperationException("Virtual disk not valid.");
					SetVirtualDiskMetadata(parent.Handle, key, (uint)value.Size, (IntPtr)value).ThrowIfFailed();
				}
			}

			/// <summary>Adds an element with the provided key and value to the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>.</summary>
			/// <param name="key">The object to use as the key of the element to add.</param>
			/// <param name="value">The object to use as the value of the element to add.</param>
			public void Add(Guid key, SafeCoTaskMemHandle value) => this[key] = value;

			/// <summary>Adds an item to the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>.</summary>
			/// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
			void ICollection<KeyValuePair<Guid, SafeCoTaskMemHandle>>.Add(KeyValuePair<Guid, SafeCoTaskMemHandle> item) => Add(item.Key, item.Value);

			/// <summary>Removes all items from the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>.</summary>
			/// <exception cref="NotImplementedException"></exception>
			void ICollection<KeyValuePair<Guid, SafeCoTaskMemHandle>>.Clear() => throw new PlatformNotSupportedException();

			/// <summary>Determines whether the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/> contains a specific value.</summary>
			/// <param name="item">The object to locate in the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>.</param>
			/// <returns>true if <paramref name="item"/> is found in the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>; otherwise, false.</returns>
			bool ICollection<KeyValuePair<Guid, SafeCoTaskMemHandle>>.Contains(KeyValuePair<Guid, SafeCoTaskMemHandle> item) => ContainsKey(item.Key) && this[item.Key].DangerousGetHandle() == item.Value.DangerousGetHandle();

			/// <summary>Determines whether the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/> contains an element with the specified key.</summary>
			/// <param name="key">The key to locate in the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>.</param>
			/// <returns>true if the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/> contains an element with the key; otherwise, false.</returns>
			public bool ContainsKey(Guid key) => Keys.Contains(key);

			/// <summary>
			/// Copies the elements of the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/> to an <see cref="T:System.Array"/>, starting at a particular
			/// <see cref="T:System.Array"/> index.
			/// </summary>
			/// <param name="array">
			/// The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from
			/// <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>. The <see cref="T:System.Array"/> must have zero-based indexing.
			/// </param>
			/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
			public void CopyTo(KeyValuePair<Guid, SafeCoTaskMemHandle>[] array, int arrayIndex)
			{
				var a = GetEnum().ToArray();
				Array.Copy(a, 0, array, arrayIndex, a.Length);
			}

			/// <summary>Returns an enumerator that iterates through the collection.</summary>
			/// <returns>A <see cref="IEnumerator{T}"/> that can be used to iterate through the collection.</returns>
			public IEnumerator<KeyValuePair<Guid, SafeCoTaskMemHandle>> GetEnumerator() => GetEnum().GetEnumerator();

			/// <summary>Removes the element with the specified key from the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>.</summary>
			/// <param name="key">The key of the element to remove.</param>
			/// <returns>
			/// true if the element is successfully removed; otherwise, false. This method also returns false if <paramref name="key"/> was not found in the
			/// original <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>.
			/// </returns>
			public bool Remove(Guid key)
			{
				if (!supported) throw new PlatformNotSupportedException();
				if (parent.Handle.IsClosed) throw new InvalidOperationException("Virtual disk not valid.");
				return DeleteVirtualDiskMetadata(parent.Handle, key).Succeeded;
			}

			/// <summary>Removes the first occurrence of a specific object from the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>.</summary>
			/// <param name="item">The object to remove from the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>.</param>
			/// <returns>
			/// true if <paramref name="item"/> was successfully removed from the <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>; otherwise, false. This
			/// method also returns false if <paramref name="item"/> is not found in the original <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>.
			/// </returns>
			bool ICollection<KeyValuePair<Guid, SafeCoTaskMemHandle>>.Remove(KeyValuePair<Guid, SafeCoTaskMemHandle> item) => Remove(item.Key);

			/// <summary>Gets the value associated with the specified key.</summary>
			/// <param name="key">The key whose value to get.</param>
			/// <param name="value">
			/// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the
			/// <paramref name="value"/> parameter. This parameter is passed uninitialized.
			/// </param>
			/// <returns>
			/// true if the object that implements <see cref="IDictionary{Guid, SafeCoTaskMemHandle}"/> contains an element with the specified key; otherwise, false.
			/// </returns>
			public bool TryGetValue(Guid key, out SafeCoTaskMemHandle value)
			{
				try { value = this[key]; return true; }
				catch { value = SafeCoTaskMemHandle.Null; return false; }
			}

			/// <summary>Returns an enumerator that iterates through a collection.</summary>
			/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

			private IEnumerable<KeyValuePair<Guid, SafeCoTaskMemHandle>> GetEnum() => Keys.Select(k => new KeyValuePair<Guid, SafeCoTaskMemHandle>(k, this[k]));
		}

		//private class VirtualDiskSnapshot
		//{
		//	private Guid id;
		//}
	}
}