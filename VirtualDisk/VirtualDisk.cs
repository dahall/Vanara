global using System.Threading;
global using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using Vanara.PInvoke;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.VirtDisk;

namespace Vanara.IO;

/// <summary>Class that represents a virtual disk and allows for performing actions on it. This wraps most of the methods found in virtdisk.h.</summary>
/// <seealso cref="System.IDisposable"/>
[DebuggerDisplay("[{ImagePath} - Attached={Attached}]")]
public partial class VirtualDisk : IDisposable, IHandle
{
	private static readonly bool IsPreWin8 = !PInvokeClient.Windows8.IsPlatformSupported();
	private readonly OPEN_VIRTUAL_DISK_VERSION ver;
	private VirtualDiskMetadata? metadata;

	private VirtualDisk(SafeVIRTUAL_DISK_HANDLE handle, OPEN_VIRTUAL_DISK_VERSION version, string imgPath)
	{
		if (handle is null || handle.IsInvalid)
		{
			throw new ArgumentNullException(nameof(handle));
		}

		Handle = handle;
		ImagePath = imgPath;
		ver = version;
	}

	private delegate Win32Error RunAsyncMethod(in NativeOverlapped overlap);

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

		/// <summary>
		/// VHD Set files (.vhds file) are a new shared Virtual Disk model for guest clusters in Windows Server 2016. VHD Set files support
		/// online resizing of shared virtual disks, support Hyper-V Replica, and can be included in application-consistent checkpoints.
		/// </summary>
		VhdSet = VIRTUAL_STORAGE_TYPE_DEVICE_TYPE.VIRTUAL_STORAGE_TYPE_DEVICE_VHDSET
	}

	/// <summary>Represents the subtype of a virtual disk.</summary>
	public enum Subtype : uint
	{
		/// <summary>Fixed.</summary>
		Fixed = 2,

		/// <summary>Dynamically expandable (sparse).</summary>
		Dynamic = 3,

		/// <summary>Differencing.</summary>
		Differencing = 4
	}

	/// <summary>Indicates whether this virtual disk is currently attached.</summary>
	public bool Attached => IsAttached(ImagePath);

	/// <summary>Block size of the VHD, in bytes.</summary>
	public uint BlockSize => GetInformation<uint>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_SIZE, 16);

	/// <summary>The device identifier.</summary>
	public DeviceType DiskType => (DeviceType)GetInformation<uint>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_VIRTUAL_STORAGE_TYPE);

	/// <summary>The fragmentation level of the virtual disk.</summary>
	public uint? FragmentationPercentage => IsChild ? null : GetInformation<uint>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_FRAGMENTATION);

	/// <summary>Unique identifier of the VHD.</summary>
	public Guid Identifier
	{
		get => GetInformation<Guid>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_IDENTIFIER);
		set
		{
			SET_VIRTUAL_DISK_INFO si = new(SET_VIRTUAL_DISK_INFO_VERSION.SET_VIRTUAL_DISK_INFO_IDENTIFIER) { UniqueIdentifier = value };
			SetVirtualDiskInformation(Handle, si).ThrowIfFailed();
		}
	}

	/// <summary>Gets the path of the image file provided when opening or creating this instance.</summary>
	/// <value>The image path.</value>
	public string ImagePath { get; private set; }

	/// <summary>Indicates whether the virtual disk is 4 KB aligned.</summary>
	public bool Is4kAligned => GetInformation<bool>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_IS_4K_ALIGNED);

	/// <summary>Gets a value indicating whether this virtual disk has a parent backing store.</summary>
	/// <value><see langword="true"/> if this instance has a parent backing store; otherwise, <see langword="false"/>.</value>
	public bool IsChild => ProviderSubtype == Subtype.Differencing;

	/// <summary>
	/// Indicates whether the virtual disk is currently mounted and in use. TRUE if the virtual disk is currently mounted and in use;
	/// otherwise FALSE.
	/// </summary>
	public bool IsLoaded => GetInformation<bool>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_IS_LOADED);

	/// <summary>Indicates whether the physical disk is remote.</summary>
	public bool IsRemote => GetInformation<bool>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PHYSICAL_DISK, 8);

	/// <summary>The logical sector size of the physical disk.</summary>
	public uint LogicalSectorSize => GetInformation<uint>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PHYSICAL_DISK);

	/// <summary>Gets the metadata associated with this virtual disk. Currently on VHDX files support metadata.</summary>
	/// <value>The metadata.</value>
	public VirtualDiskMetadata Metadata => metadata ??= new VirtualDiskMetadata(this);

	/// <summary>
	/// The change tracking identifier for the change that identifies the state of the virtual disk that you want to use as the basis of
	/// comparison to determine whether the NewerChanges member reports new changes.
	/// </summary>
	public string MostRecentId => GetInformation<string>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_CHANGE_TRACKING_STATE, 8);

	/// <summary>
	/// Whether the virtual disk has changed since the change identified by the MostRecentId member occurred. TRUE if the virtual disk has
	/// changed since the change identified by the MostRecentId member occurred; otherwise FALSE.
	/// </summary>
	public bool NewerChanges => GetInformation<bool>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_CHANGE_TRACKING_STATE, 4);

	/// <summary>The path of the parent backing store, if it can be resolved.</summary>
	public string? ParentBackingStore => IsChild ? GetInformation<string>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PARENT_LOCATION, 4) : null;

	/// <summary>Unique identifier of the parent disk backing store. If unattached, <see langword="null"/> is returned.</summary>
	public Guid? ParentIdentifier => IsChild ? GetInformation<Guid>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PARENT_IDENTIFIER) : null;

	/// <summary>
	/// If this is a child, contains the path of the parent backing store. If is a parent disk, contains all of the parent paths present in
	/// the search list. If unattached, <see langword="null"/> is returned.
	/// </summary>
	public string[]? ParentPaths
	{
		get
		{
			if (IsChild)
			{
				var pPath = GetInformation<string>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PARENT_LOCATION, 4);
				return !string.IsNullOrEmpty(pPath) ? new[] { pPath } : null;
			}
			if (Attached)
			{
				return GetInformation<string[]>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PARENT_LOCATION, 4);
			}
			return null;
		}
	}

	/// <summary>Internal time stamp of the parent disk backing store. If unattached, <see langword="null"/> is returned.</summary>
	public uint? ParentTimeStamp => IsChild ? GetInformation<uint>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PARENT_TIMESTAMP) : null;

	/// <summary>
	/// Retrieves the path to the physical device object that contains a virtual hard disk (VHD) or CD or DVD image file (ISO). If
	/// unattached, <see langword="null"/> is returned.
	/// </summary>
	public string? PhysicalPath
	{
		get
		{
			if (!Attached)
				return null;

			var sz = 64;
			StringBuilder sb = new(sz);
			Win32Error err;
			do
			{
				err = GetVirtualDiskPhysicalPath(Handle, ref sz, sb);
				if (err == Win32Error.ERROR_INSUFFICIENT_BUFFER)
					sb.Capacity *= 4;
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
			SET_VIRTUAL_DISK_INFO si = new(SET_VIRTUAL_DISK_INFO_VERSION.SET_VIRTUAL_DISK_INFO_PHYSICAL_SECTOR_SIZE) { VhdPhysicalSectorSize = value };
			SetVirtualDiskInformation(Handle, si).ThrowIfFailed();
		}
	}

	/// <summary>Physical size of the VHD on disk, in bytes.</summary>
	public ulong PhysicalSize => GetInformation<ulong>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_SIZE, 8);

	/// <summary>Provider-specific subtype.</summary>
	public Subtype ProviderSubtype => (Subtype)GetInformation<uint>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PROVIDER_SUBTYPE);

	/// <summary>Whether RCT is turned on. TRUE if RCT is turned on; otherwise FALSE.</summary>
	public bool ResilientChangeTrackingEnabled
	{
		get => GetInformation<bool>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_CHANGE_TRACKING_STATE);
		set
		{
			SET_VIRTUAL_DISK_INFO si = new(SET_VIRTUAL_DISK_INFO_VERSION.SET_VIRTUAL_DISK_INFO_CHANGE_TRACKING_STATE) { ChangeTrackingEnabled = value };
			SetVirtualDiskInformation(Handle, si).ThrowIfFailed();
		}
	}

	/// <summary>Sector size of the VHD, in bytes.</summary>
	public uint SectorSize => GetInformation<uint>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_SIZE, 20);

	/// <summary>The smallest safe minimum size of the virtual disk. If unattached, <see langword="null"/> is returned.</summary>
	public ulong? SmallestSafeVirtualSize => Attached ? GetInformation<ulong>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_SMALLEST_SAFE_VIRTUAL_SIZE) : null;

	/// <summary>Vendor-unique identifier.</summary>
	public Guid VendorId => GetInformation<Guid>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_VIRTUAL_STORAGE_TYPE, 4);

	/// <summary>The physical sector size of the virtual disk.</summary>
	public uint VhdPhysicalSectorSize => GetInformation<uint>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_VHD_PHYSICAL_SECTOR_SIZE);

	/// <summary>
	/// The identifier that is uniquely created when a user first creates the virtual disk to attempt to uniquely identify that virtual disk.
	/// </summary>
	public Guid VirtualDiskId
	{
		get => GetInformation<Guid>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_VIRTUAL_DISK_ID);
		set
		{
			SET_VIRTUAL_DISK_INFO si = new(SET_VIRTUAL_DISK_INFO_VERSION.SET_VIRTUAL_DISK_INFO_VIRTUAL_DISK_ID) { VirtualDiskId = value };
			SetVirtualDiskInformation(Handle, si).ThrowIfFailed();
		}
	}

	/// <summary>Virtual size of the VHD, in bytes.</summary>
	public ulong VirtualSize => GetInformation<ulong>(GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_SIZE);

	/// <summary>Gets the volume GUID paths for an attached virtual disk.</summary>
	public string[]? VolumeGuidPaths
	{
		get
		{
			if (!Attached || PhysicalPath is null)
				return null;

			var diskNo = GetDiskNumberFromDevicePath(PhysicalPath);
			return diskNo.HasValue ? GetVolumeGuidsFromDiskNumber(diskNo.Value).ToArray() : null;
		}
	}

	/// <summary>Gets the volume mount points for an attached virtual disk.</summary>
	public string[]? VolumeMountPoints
	{
		get
		{
			var volPath = VolumeGuidPaths?.FirstOrDefault();
			return volPath is null ? null : GetVolumeMountPoints(volPath);
		}
	}

	/// <summary>Gets the safe handle for the current virtual disk.</summary>
	private SafeVIRTUAL_DISK_HANDLE Handle { get; set; }

	/// <summary>Creates a virtual hard disk (VHD) image file.</summary>
	/// <param name="path">A valid file path that represents the path to the new virtual disk image file.</param>
	/// <param name="param">A reference to a valid CREATE_VIRTUAL_DISK_PARAMETERS structure that contains creation parameter data.</param>
	/// <param name="flags">Creation flags, which must be a valid combination of the CREATE_VIRTUAL_DISK_FLAG enumeration.</param>
	/// <param name="mask">The VIRTUAL_DISK_ACCESS_MASK value to use when opening the newly created virtual disk file.</param>
	/// <param name="securityDescriptor">
	/// An optional pointer to a SECURITY_DESCRIPTOR to apply to the virtual disk image file. If this parameter is IntPtr.Zero, the parent
	/// directory's security descriptor will be used.
	/// </param>
	/// <returns>If successful, returns a valid <see cref="VirtualDisk"/> instance for the newly created virtual disk.</returns>
	public static VirtualDisk Create(string path, in CREATE_VIRTUAL_DISK_PARAMETERS param, CREATE_VIRTUAL_DISK_FLAG flags = CREATE_VIRTUAL_DISK_FLAG.CREATE_VIRTUAL_DISK_FLAG_NONE, VIRTUAL_DISK_ACCESS_MASK mask = VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE, PSECURITY_DESCRIPTOR securityDescriptor = default)
	{
		if (string.IsNullOrEmpty(path))
		{
			throw new ArgumentNullException(nameof(path));
		}

		VIRTUAL_STORAGE_TYPE stType = new();
		CreateVirtualDisk(stType, path, mask, securityDescriptor, flags, 0, param, IntPtr.Zero, out SafeVIRTUAL_DISK_HANDLE handle).ThrowIfFailed();
		return new VirtualDisk(handle, (OPEN_VIRTUAL_DISK_VERSION)param.Version, path);
	}

	/// <summary>Creates a virtual hard disk (VHD) image file, either using default parameters or using an existing VHD or physical disk.</summary>
	/// <param name="path">A valid file path that represents the path to the new virtual disk image file.</param>
	/// <param name="size">The maximum virtual size, in bytes, of the virtual disk object. Must be a multiple of 512.</param>
	/// <param name="dynamic">
	/// <c>true</c> to grow the disk dynamically as content is added; <c>false</c> to pre-allocate all physical space necessary for the size
	/// of the virtual disk.
	/// </param>
	/// <param name="access">
	/// An optional FileSecurity instance to apply to the attached virtual disk. If this parameter is <c>null</c>, the security descriptor of
	/// the virtual disk image file is used. Ensure that the security descriptor that AttachVirtualDisk applies to the attached virtual disk
	/// grants the write attributes permission for the user, or that the security descriptor of the virtual disk image file grants the write
	/// attributes permission for the user if you specify <c>null</c> for this parameter. If the security descriptor does not grant write
	/// attributes permission for a user, Shell displays the following error when the user accesses the attached virtual disk: The Recycle
	/// Bin is corrupted. Do you want to empty the Recycle Bin for this drive?
	/// </param>
	/// <returns>If successful, returns a valid <see cref="VirtualDisk"/> instance for the newly created virtual disk.</returns>
	public static VirtualDisk Create(string path, ulong size, bool dynamic = true, FileSecurity? access = null) => Create(path, size, dynamic, 0, 0, access);

	/// <summary>Creates a virtual hard disk (VHD) image file, either using default parameters or using an existing VHD or physical disk.</summary>
	/// <param name="path">A valid file path that represents the path to the new virtual disk image file.</param>
	/// <param name="size">The maximum virtual size, in bytes, of the virtual disk object. Must be a multiple of 512.</param>
	/// <param name="dynamic">
	/// <c>true</c> to grow the disk dynamically as content is added; <c>false</c> to pre-allocate all physical space necessary for the size
	/// of the virtual disk.
	/// </param>
	/// <param name="blockSize">
	/// Internal size of the virtual disk object blocks, in bytes. For VHDX this must be a multiple of 1 MB between 1 and 256 MB. For VHD 1
	/// this must be set to one of the following values: 0 (default), 0x80000 (512K), or 0x200000 (2MB)
	/// </param>
	/// <param name="logicalSectorSize">
	/// Internal size of the virtual disk object sectors. For VHDX must be set to 512 (0x200) or 4096 (0x1000). For VHD 1 must be set to 512.
	/// </param>
	/// <param name="access">
	/// An optional FileSecurity instance to apply to the attached virtual disk. If this parameter is <c>null</c>, the security descriptor of
	/// the virtual disk image file is used. Ensure that the security descriptor that AttachVirtualDisk applies to the attached virtual disk
	/// grants the write attributes permission for the user, or that the security descriptor of the virtual disk image file grants the write
	/// attributes permission for the user if you specify <c>null</c> for this parameter. If the security descriptor does not grant write
	/// attributes permission for a user, Shell displays the following error when the user accesses the attached virtual disk: The Recycle
	/// Bin is corrupted. Do you want to empty the Recycle Bin for this drive?
	/// </param>
	/// <returns>If successful, returns a valid <see cref="VirtualDisk"/> instance for the newly created virtual disk.</returns>
	public static VirtualDisk Create(string path, ulong size, bool dynamic, uint blockSize = 0, uint logicalSectorSize = 0, FileSecurity? access = null)
	{
		if (string.IsNullOrEmpty(path))
		{
			throw new ArgumentNullException(nameof(path));
		}

		VIRTUAL_DISK_ACCESS_MASK mask = IsPreWin8 ? VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_CREATE : VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE;
		SafePSECURITY_DESCRIPTOR sd = FileSecToSd(access);
		CREATE_VIRTUAL_DISK_PARAMETERS param = new(size, IsPreWin8 ? 1U : 2U, blockSize, logicalSectorSize);
		CREATE_VIRTUAL_DISK_FLAG flags = dynamic ? CREATE_VIRTUAL_DISK_FLAG.CREATE_VIRTUAL_DISK_FLAG_NONE : CREATE_VIRTUAL_DISK_FLAG.CREATE_VIRTUAL_DISK_FLAG_FULL_PHYSICAL_ALLOCATION;
		return Create(path, param, flags, mask, sd);
	}

	/// <summary>Creates a virtual hard disk (VHD) image file.</summary>
	/// <param name="path">A valid file path that represents the path to the new virtual disk image file.</param>
	/// <param name="param">A reference to a valid CREATE_VIRTUAL_DISK_PARAMETERS structure that contains creation parameter data.</param>
	/// <param name="flags">Creation flags, which must be a valid combination of the CREATE_VIRTUAL_DISK_FLAG enumeration.</param>
	/// <param name="mask">The VIRTUAL_DISK_ACCESS_MASK value to use when opening the newly created virtual disk file.</param>
	/// <param name="storageType">A VIRTUAL_STORAGE_TYPE structure that contains the desired disk type and vendor information.</param>
	/// <param name="securityDescriptor">
	/// An optional pointer to a SECURITY_DESCRIPTOR to apply to the virtual disk image file. If this parameter is IntPtr.Zero, the parent
	/// directory's security descriptor will be used.
	/// </param>
	/// <param name="cancellationToken">
	/// A cancellation token that can be used to cancel the operation. This value can be <c>default</c> to disable cancellation.
	/// </param>
	/// <param name="progress">
	/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable
	/// progress reporting.
	/// </param>
	/// <returns>If successful, returns a valid <see cref="VirtualDisk"/> instance for the newly created virtual disk.</returns>
	public static async Task<VirtualDisk> CreateAsync(string path, CREATE_VIRTUAL_DISK_PARAMETERS param,
		CREATE_VIRTUAL_DISK_FLAG flags = CREATE_VIRTUAL_DISK_FLAG.CREATE_VIRTUAL_DISK_FLAG_NONE,
		VIRTUAL_DISK_ACCESS_MASK mask = VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE,
		VIRTUAL_STORAGE_TYPE storageType = default,
		PSECURITY_DESCRIPTOR securityDescriptor = default,
		CancellationToken cancellationToken = default, IProgress<int>? progress = default)
	{
		if (string.IsNullOrEmpty(path))
		{
			throw new ArgumentNullException(nameof(path));
		}

		return await Task.Run(() =>
		{
			NativeOverlapped vhdOverlap = new();
			CreateVirtualDisk(storageType, path, mask, securityDescriptor, flags, 0, param, vhdOverlap, out SafeVIRTUAL_DISK_HANDLE hVhd).ThrowUnless(Win32Error.ERROR_IO_PENDING);

			if (!GetProgress(hVhd, vhdOverlap, cancellationToken, progress))
				throw new OperationCanceledException(cancellationToken);

			return new VirtualDisk(hVhd, (OPEN_VIRTUAL_DISK_VERSION)param.Version, path);
		});
	}

	/// <summary>Creates a virtual hard disk (VHD) image file, either using default parameters or using an existing VHD or physical disk.</summary>
	/// <param name="path">A valid string that represents the path to the new virtual disk image file.</param>
	/// <param name="parentPath"></param>
	/// <param name="access">
	/// An optional pointer to a FileSecurity instance to apply to the attached virtual disk. If this parameter is NULL, the security
	/// descriptor of the virtual disk image file is used. Ensure that the security descriptor that AttachVirtualDisk applies to the attached
	/// virtual disk grants the write attributes permission for the user, or that the security descriptor of the virtual disk image file
	/// grants the write attributes permission for the user if you specify NULL for this parameter.If the security descriptor does not grant
	/// write attributes permission for a user, Shell displays the following error when the user accesses the attached virtual disk: The
	/// Recycle Bin is corrupted.Do you want to empty the Recycle Bin for this drive?
	/// </param>
	/// <returns></returns>
	public static VirtualDisk CreateDifferencing(string path, string parentPath, FileSecurity? access = null)
	{
		//if (access == null) access = GetFileSecurity();
		if (string.IsNullOrEmpty(path))
		{
			throw new ArgumentNullException(nameof(path));
		}

		if (string.IsNullOrEmpty(parentPath))
		{
			throw new ArgumentNullException(nameof(parentPath));
		}

		// If this is V2 (>=Win8), then let the file extension determine type, otherwise, it has to be a VHD
		VIRTUAL_DISK_ACCESS_MASK mask = IsPreWin8 ? VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_CREATE : VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE;
		SafePSECURITY_DESCRIPTOR sd = FileSecToSd(access);
		using SafeCoTaskMemString pp = new(parentPath);
		CREATE_VIRTUAL_DISK_PARAMETERS param = new(pp, default);
		return Create(path, param, CREATE_VIRTUAL_DISK_FLAG.CREATE_VIRTUAL_DISK_FLAG_NONE, mask, sd);
	}

	/// <summary>Creates a virtual hard disk (VHD) image file, either using default parameters or using an existing VHD or physical disk.</summary>
	/// <param name="path">A valid file path that represents the path to the new virtual disk image file.</param>
	/// <param name="sourcePath">
	/// A fully qualified path to pre-populate the new virtual disk object with block data from an existing disk. This path may refer to a
	/// virtual disk or a physical disk.
	/// </param>
	/// <returns>If successful, returns a valid <see cref="VirtualDisk"/> instance for the newly created virtual disk.</returns>
	public static VirtualDisk CreateFromSource(string path, string sourcePath)
	{
		if (string.IsNullOrEmpty(path))
		{
			throw new ArgumentNullException(nameof(path));
		}

		if (string.IsNullOrEmpty(sourcePath))
		{
			throw new ArgumentNullException(nameof(sourcePath));
		}

		VIRTUAL_DISK_ACCESS_MASK mask = IsPreWin8 ? VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_CREATE : VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE;
		using SafeCoTaskMemString sp = new(sourcePath);
		CREATE_VIRTUAL_DISK_PARAMETERS param = new(default, sp);
		return Create(path, param, CREATE_VIRTUAL_DISK_FLAG.CREATE_VIRTUAL_DISK_FLAG_NONE, mask);
	}

	/// <summary>Creates a virtual hard disk (VHD) image file, either using default parameters or using an existing VHD or physical disk.</summary>
	/// <param name="path">A valid file path that represents the path to the new virtual disk image file.</param>
	/// <param name="sourcePath">
	/// A fully qualified path to pre-populate the new virtual disk object with block data from an existing disk. This path may refer to a
	/// virtual disk or a physical disk.
	/// </param>
	/// <param name="cancellationToken">
	/// A cancellation token that can be used to cancel the operation. This value can be <c>default</c> to disable cancellation.
	/// </param>
	/// <param name="progress">
	/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable
	/// progress reporting.
	/// </param>
	/// <returns>If successful, returns a valid <see cref="VirtualDisk"/> instance for the newly created virtual disk.</returns>
	public static async Task<VirtualDisk> CreateFromSourceAsync(string path, string sourcePath, CancellationToken cancellationToken = default, IProgress<int>? progress = default)
	{
		if (string.IsNullOrEmpty(path))
		{
			throw new ArgumentNullException(nameof(path));
		}

		if (string.IsNullOrEmpty(sourcePath))
		{
			throw new ArgumentNullException(nameof(sourcePath));
		}

		VIRTUAL_STORAGE_TYPE stType = new();
		VIRTUAL_DISK_ACCESS_MASK mask = IsPreWin8 ? VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_CREATE : VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE;
		using SafeCoTaskMemString sp = new(sourcePath);
		CREATE_VIRTUAL_DISK_PARAMETERS param = new(default, sp);
		CREATE_VIRTUAL_DISK_FLAG flags = CREATE_VIRTUAL_DISK_FLAG.CREATE_VIRTUAL_DISK_FLAG_NONE;
		return await CreateAsync(path, param, flags, mask, stType, default, cancellationToken, progress);
	}

	/// <summary>
	/// Detach a virtual disk that was previously attached with the ATTACH_VIRTUAL_DISK_FLAG_PERMANENT_LIFETIME flag or calling <see
	/// cref="Attach(bool, bool, bool, FileSecurity)"/> and setting autoDetach to <c>false</c>.
	/// </summary>
	/// <param name="path">A valid path to the virtual disk image to detach.</param>
	public static void Detach(string path)
	{
		try
		{
			using VirtualDisk vd = Open(path, OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NONE, null, VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_DETACH);
			vd.Detach();
		}
		catch { }
	}

	/// <summary>Gets the list of all the loopback mounted virtual disks.</summary>
	/// <returns>An enumeration of all the loopback mounted virtual disks physical paths.</returns>
	public static IEnumerable<string> GetAllAttachedVirtualDiskPaths()
	{
		uint sz = 0;
		SafeCoTaskMemHandle sb = new(0);
		Win32Error err;
		do
		{
			err = GetAllAttachedVirtualDiskPhysicalPaths(ref sz, sb);
			if (err.Succeeded)
			{
				break;
			}

			if (err != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				err.ThrowIfFailed();
			}

			sb.Size = (int)sz;
		} while (err == Win32Error.ERROR_INSUFFICIENT_BUFFER);
		return sb.Size <= 1 ? new string[0] : sb.ToStringEnum(CharSet.Unicode);
	}

	/// <summary>
	/// Returns the relationships between virtual hard disks (VHDs) or CD or DVD image file (ISO) or the volumes contained within those disks
	/// and their parent disk or volume.
	/// </summary>
	/// <param name="handle">
	/// <para>
	/// A handle to a volume or root directory if the <c>Flags</c> parameter does not specify the
	/// <c>GET_STORAGE_DEPENDENCY_FLAG_DISK_HANDLE</c> flag. For information on how to open a volume or root directory, see the CreateFile function.
	/// </para>
	/// <para>
	/// If the <c>Flags</c> parameter specifies the <c>GET_STORAGE_DEPENDENCY_FLAG_DISK_HANDLE</c> flag, this handle should be a handle to a disk.
	/// </para>
	/// </param>
	/// <param name="flags">A valid combination of GET_STORAGE_DEPENDENCY_FLAG values.</param>
	/// <returns>An array of <see cref="STORAGE_DEPENDENCY_INFO_TYPE_2"/> structures with the requested information.</returns>
	/// <remarks>CD and DVD image files (ISO) are not supported before Windows 8 and Windows Server 2012.</remarks>
	public static STORAGE_DEPENDENCY_INFO_TYPE_2[] GetStorageDependencyInformation(IntPtr handle, GET_STORAGE_DEPENDENCY_FLAG flags)
	{
		using var mem = SafeCoTaskMemHandle.CreateFromStructure(new STORAGE_DEPENDENCY_INFO { Version = STORAGE_DEPENDENCY_INFO_VERSION.STORAGE_DEPENDENCY_INFO_VERSION_2 });
		Win32Error err = VirtDisk.GetStorageDependencyInformation(handle, flags, mem.Size, mem, out var sz);
		if (err == Win32Error.ERROR_INSUFFICIENT_BUFFER)
		{
			mem.Size = sz;
			err = VirtDisk.GetStorageDependencyInformation(handle, flags, mem.Size, mem, out sz);
		}
		err.ThrowIfFailed();
		// Get array at offset 8 from count at offset 4
		return mem.ToArray<STORAGE_DEPENDENCY_INFO_TYPE_2>(mem.ToStructure<int>(sizeof(int)), sizeof(uint) * 2);
	}

	/// <summary>Determines whether the specified virtual disk indicated by <paramref name="path"/> is currently attached.</summary>
	/// <param name="path">The path to the virtual disk image file.</param>
	/// <returns><see langword="true"/> if the specified path is attached; otherwise, <see langword="false"/>.</returns>
	public static bool IsAttached(string path) => GetAllAttachedVirtualDiskPaths().Any(s => s.Equals(path, StringComparison.InvariantCultureIgnoreCase));

	/// <summary>Creates an instance of a Virtual Disk from a file.</summary>
	/// <param name="path">A valid path to the virtual disk image to open.</param>
	/// <param name="flags">A valid combination of values of the OPEN_VIRTUAL_DISK_FLAG enumeration.</param>
	/// <param name="param">A valid OPEN_VIRTUAL_DISK_PARAMETERS structure.</param>
	/// <param name="mask">A valid VIRTUAL_DISK_ACCESS_MASK value.</param>
	public static VirtualDisk Open(string path, OPEN_VIRTUAL_DISK_FLAG flags = OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NONE, OPEN_VIRTUAL_DISK_PARAMETERS? param = null, VIRTUAL_DISK_ACCESS_MASK mask = VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE)
	{
		if (string.IsNullOrEmpty(path))
		{
			throw new ArgumentNullException(nameof(path));
		}

		Debug.WriteLine($"OpenVD: mask={mask}; flags={flags}; param={param}");
		OpenVirtualDisk(new VIRTUAL_STORAGE_TYPE(), path, mask, flags, param, out SafeVIRTUAL_DISK_HANDLE hVhd).ThrowIfFailed();
		return new VirtualDisk(hVhd, param?.Version ?? (IsPreWin8 ? OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_1 : OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_2), path);
	}

	/// <summary>Creates an instance of a Virtual Disk from a file.</summary>
	/// <param name="path">A valid path to the virtual disk image to open.</param>
	/// <param name="readOnly">If TRUE, indicates the file backing store is to be opened as read-only.</param>
	/// <param name="getInfoOnly">If TRUE, indicates the handle is only to be used to get information on the virtual disk.</param>
	/// <param name="noParents">
	/// Open the VHD file (backing store) without opening any differencing-chain parents. Used to correct broken parent links. This flag is
	/// not supported for ISO virtual disks.
	/// </param>
	public static VirtualDisk Open(string path, bool readOnly, bool getInfoOnly = false, bool noParents = false)
	{
		if (string.IsNullOrEmpty(path))
			throw new ArgumentNullException(nameof(path));

		OPEN_VIRTUAL_DISK_FLAG flags = OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NONE;
		if (noParents)
			flags |= OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS;

		var isIso = Path.GetExtension(path).Equals(".iso", StringComparison.InvariantCultureIgnoreCase);
		if (isIso && (!readOnly || noParents))
			throw new NotSupportedException();

		OPEN_VIRTUAL_DISK_PARAMETERS param;
		VIRTUAL_DISK_ACCESS_MASK mask = VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE;
		if (isIso || IsPreWin8)
		{
			param = new OPEN_VIRTUAL_DISK_PARAMETERS(0); // make v1 instance
			if (readOnly)
				mask |= VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_READ;

			if (getInfoOnly)
				mask |= VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_GET_INFO;
		}
		else
		{
			param = new OPEN_VIRTUAL_DISK_PARAMETERS(readOnly, getInfoOnly);
		}

		return Open(path, flags, param, mask);
	}

	/// <summary>Attaches a parent to a virtual disk opened with the OPEN_VIRTUAL_DISK_FLAG_CUSTOM_DIFF_CHAIN flag.</summary>
	/// <param name="parentPath">A valid path to the virtual hard disk image to add as a parent.</param>
	/// <remarks>
	/// This adds the specified parent virtual hard disk to the head of the differencing chain of the specified virtual hard disk. If the
	/// differencing chain extends beyond the parent, this function can be called repeatedly to add additional parents to the differencing chain.
	/// </remarks>
	public void AddParent(string parentPath) => AddVirtualDiskParent(Handle, parentPath).ThrowIfFailed();

	/// <summary>Applies a snapshot of the current virtual disk for VHD Set files.</summary>
	/// <param name="id">The ID of the new snapshot to be applied to the VHD set.</param>
	/// <param name="leafId">
	/// Indicates whether the current default leaf data should be retained as part of the apply operation. When <see cref="Guid.Empty"/> is
	/// specified, the apply operation will discard the current default leaf data. When a non-zero GUID is specified, the apply operation
	/// will convert the default leaf data into a writeable snapshot with the specified ID.
	/// </param>
	/// <param name="writeable"><see langword="true"/> to indicate that the snapshot to be applied was created as a writable snapshot type.</param>
	public void ApplySnapshot(Guid id, Guid leafId = default, bool writeable = false)
	{
		APPLY_SNAPSHOT_VHDSET_PARAMETERS param = new()
		{
			Version = APPLY_SNAPSHOT_VHDSET_VERSION.APPLY_SNAPSHOT_VHDSET_VERSION_1,
			Version1 = new() { SnapshotId = id, LeafSnapshotId = leafId }
		};
		ApplySnapshotVhdSet(Handle, param, writeable ? 0 : APPLY_SNAPSHOT_VHDSET_FLAG.APPLY_SNAPSHOT_VHDSET_FLAG_WRITEABLE).ThrowIfFailed();
	}

	/// <summary>
	/// Attaches a virtual hard disk (VHD) or CD or DVD image file (ISO) by locating an appropriate VHD provider to accomplish the attachment.
	/// </summary>
	/// <param name="flags">A valid combination of values of the ATTACH_VIRTUAL_DISK_FLAG enumeration.</param>
	/// <param name="param">A reference to a valid ATTACH_VIRTUAL_DISK_PARAMETERS structure that contains attachment parameter data.</param>
	/// <param name="securityDescriptor">
	/// An optional pointer to a SECURITY_DESCRIPTOR to apply to the attached virtual disk. If this parameter is NULL, the security
	/// descriptor of the virtual disk image file is used.
	/// <para>
	/// Ensure that the security descriptor that AttachVirtualDisk applies to the attached virtual disk grants the write attributes
	/// permission for the user, or that the security descriptor of the virtual disk image file grants the write attributes permission for
	/// the user if you specify NULL for this parameter. If the security descriptor does not grant write attributes permission for a user,
	/// Shell displays the following error when the user accesses the attached virtual disk: The Recycle Bin is corrupted. Do you want to
	/// empty the Recycle Bin for this drive?
	/// </para>
	/// </param>
	public void Attach(ATTACH_VIRTUAL_DISK_FLAG flags, ATTACH_VIRTUAL_DISK_PARAMETERS? param = null, PSECURITY_DESCRIPTOR securityDescriptor = default)
	{
		if (!securityDescriptor.IsNull && !securityDescriptor.IsValidSecurityDescriptor())
		{
			throw new ArgumentException("Invalid security descriptor.");
		}

		if (param.HasValue)
			AttachVirtualDisk(Handle, securityDescriptor, flags, 0, param.Value, IntPtr.Zero).ThrowIfFailed();
		else
			AttachVirtualDisk(Handle, securityDescriptor, flags, 0, IntPtr.Zero, IntPtr.Zero).ThrowIfFailed();
	}

	/// <summary>
	/// Attaches a virtual hard disk (VHD) or CD or DVD image file (ISO) by locating an appropriate VHD provider to accomplish the attachment.
	/// </summary>
	/// <param name="readOnly">Attach the virtual disk as read-only.</param>
	/// <param name="autoDetach">
	/// If <c>false</c>, decouple the virtual disk lifetime from that of the VirtualDisk. The virtual disk will be attached until the Detach
	/// function is called, even if all open instances of the virtual disk are disposed.
	/// </param>
	/// <param name="noDriveLetter">No drive letters are assigned to the disk's volumes.</param>
	/// <param name="access">
	/// An optional pointer to a FileSecurity instance to apply to the attached virtual disk. If this parameter is <see langword="null"/>,
	/// the security descriptor of the virtual disk image file is used. Ensure that the security descriptor that AttachVirtualDisk applies to
	/// the attached virtual disk grants the write attributes permission for the user, or that the security descriptor of the virtual disk
	/// image file grants the write attributes permission for the user if you specify <see langword="null"/> for this parameter. If the
	/// security descriptor does not grant write attributes permission for a user, Shell displays the following error when the user accesses
	/// the attached virtual disk: The Recycle Bin is corrupted. Do you want to empty the Recycle Bin for this drive?
	/// </param>
	public void Attach(bool readOnly = false, bool autoDetach = true, bool noDriveLetter = false, FileSecurity? access = null) =>
		Attach(noDriveLetter ? null : new[] { "*" }, readOnly, autoDetach, access);

	/// <summary>
	/// Attaches a virtual hard disk (VHD) or CD or DVD image file (ISO) by locating an appropriate VHD provider to accomplish the attachment.
	/// </summary>
	/// <param name="mountPoints">
	/// The user-mode paths to be associated with the volume. These may be a drive letter (for example, "X:\") or a directory on another
	/// volume (for example, "Y:\MountX\"). The string must end with a trailing backslash ('\'). Use "*" as the first and only entry to have
	/// the system assign a drive letter or <see langword="null"/> to leave the drive letter unassigned.
	/// </param>
	/// <param name="readOnly">Attach the virtual disk as read-only.</param>
	/// <param name="autoDetach">
	/// If <c>false</c>, decouple the virtual disk lifetime from that of the VirtualDisk. The virtual disk will be attached until the Detach
	/// function is called, even if all open instances of the virtual disk are disposed.
	/// </param>
	/// <param name="access">
	/// An optional pointer to a FileSecurity instance to apply to the attached virtual disk. If this parameter is <see langword="null"/>,
	/// the security descriptor of the virtual disk image file is used. Ensure that the security descriptor that AttachVirtualDisk applies to
	/// the attached virtual disk grants the write attributes permission for the user, or that the security descriptor of the virtual disk
	/// image file grants the write attributes permission for the user if you specify <see langword="null"/> for this parameter. If the
	/// security descriptor does not grant write attributes permission for a user, Shell displays the following error when the user accesses
	/// the attached virtual disk: The Recycle Bin is corrupted. Do you want to empty the Recycle Bin for this drive?
	/// </param>
	public void Attach(string[]? mountPoints, bool readOnly = false, bool autoDetach = true, FileSecurity? access = null)
	{
		if (mountPoints is not null && mountPoints.Length == 0)
			throw new ArgumentException("Mount points list cannot be empty.", nameof(mountPoints));
		if (mountPoints is not null && mountPoints[0] != "*" && mountPoints.Any(p => p == "*"))
			throw new ArgumentException("Mount points may only contain the '*' value as the first and only value.", nameof(mountPoints));

		ATTACH_VIRTUAL_DISK_FLAG flags = 0;
		if (mountPoints is null || (mountPoints.Length > 0 && mountPoints[0] != "*"))
			flags |= ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_NO_DRIVE_LETTER;
		if (readOnly)
			flags |= ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_READ_ONLY;
		if (!autoDetach)
			flags |= ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_PERMANENT_LIFETIME;
		if (access is null)
			flags |= ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_NO_SECURITY_DESCRIPTOR;

		using SafePSECURITY_DESCRIPTOR sd = FileSecToSd(access);
		Attach(flags, ATTACH_VIRTUAL_DISK_PARAMETERS.Default, sd);

		if (mountPoints is null || mountPoints[0] is "*")
			return;

		var vgp = VolumeGuidPaths ?? new string[0];
		if (mountPoints.Length > vgp.Length)
		{
			Detach();
			throw new ArgumentException("The number of mount points cannot be larger than the number of associated volumes.", nameof(mountPoints));
		}
		for (var i = 0; i < mountPoints.Length; i++)
			Win32Error.ThrowLastErrorIfFalse(SetVolumeMountPoint(mountPoints[i], vgp[i]));
	}

	/// <summary>
	/// Attaches a virtual hard disk (VHD) or CD or DVD image file (ISO) by locating an appropriate VHD provider to accomplish the attachment.
	/// </summary>
	/// <param name="flags">A valid combination of values of the ATTACH_VIRTUAL_DISK_FLAG enumeration.</param>
	/// <param name="param">A reference to a valid ATTACH_VIRTUAL_DISK_PARAMETERS structure that contains attachment parameter data.</param>
	/// <param name="securityDescriptor">
	/// An optional pointer to a SECURITY_DESCRIPTOR to apply to the attached virtual disk. If this parameter is NULL, the security
	/// descriptor of the virtual disk image file is used.
	/// <para>
	/// Ensure that the security descriptor that AttachVirtualDisk applies to the attached virtual disk grants the write attributes
	/// permission for the user, or that the security descriptor of the virtual disk image file grants the write attributes permission for
	/// the user if you specify NULL for this parameter. If the security descriptor does not grant write attributes permission for a user,
	/// Shell displays the following error when the user accesses the attached virtual disk: The Recycle Bin is corrupted. Do you want to
	/// empty the Recycle Bin for this drive?
	/// </para>
	/// </param>
	/// <param name="cancellationToken">
	/// A cancellation token that can be used to cancel the operation. This value can be <c>default</c> to disable cancellation.
	/// </param>
	/// <param name="progress">
	/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable
	/// progress reporting.
	/// </param>
	public async Task AttachAsync(ATTACH_VIRTUAL_DISK_FLAG flags, ATTACH_VIRTUAL_DISK_PARAMETERS? param = null, PSECURITY_DESCRIPTOR securityDescriptor = default,
		CancellationToken cancellationToken = default, IProgress<int>? progress = default)
	{
		if (!securityDescriptor.IsNull && !securityDescriptor.IsValidSecurityDescriptor())
			throw new ArgumentException("Invalid security descriptor.");

		await RunAsync(Handle, (in NativeOverlapped vhdOverlap) =>
			AttachVirtualDisk(Handle, securityDescriptor, flags, 0, param ?? ATTACH_VIRTUAL_DISK_PARAMETERS.Default, vhdOverlap), cancellationToken, progress);
	}

	/// <summary>
	/// Attaches a virtual hard disk (VHD) or CD or DVD image file (ISO) by locating an appropriate VHD provider to accomplish the attachment.
	/// </summary>
	/// <param name="readOnly">Attach the virtual disk as read-only.</param>
	/// <param name="autoDetach">
	/// If <c>false</c>, decouple the virtual disk lifetime from that of the VirtualDisk. The virtual disk will be attached until the Detach
	/// function is called, even if all open instances of the virtual disk are disposed.
	/// </param>
	/// <param name="noDriveLetter">No drive letters are assigned to the disk's volumes.</param>
	/// <param name="access">
	/// An optional pointer to a FileSecurity instance to apply to the attached virtual disk. If this parameter is <see langword="null"/>,
	/// the security descriptor of the virtual disk image file is used. Ensure that the security descriptor that AttachVirtualDisk applies to
	/// the attached virtual disk grants the write attributes permission for the user, or that the security descriptor of the virtual disk
	/// image file grants the write attributes permission for the user if you specify <see langword="null"/> for this parameter. If the
	/// security descriptor does not grant write attributes permission for a user, Shell displays the following error when the user accesses
	/// the attached virtual disk: The Recycle Bin is corrupted. Do you want to empty the Recycle Bin for this drive?
	/// </param>
	/// <param name="cancellationToken">
	/// A cancellation token that can be used to cancel the operation. This value can be <c>default</c> to disable cancellation.
	/// </param>
	/// <param name="progress">
	/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable
	/// progress reporting.
	/// </param>
	public async Task AttachAsync(bool readOnly = false, bool autoDetach = true, bool noDriveLetter = false, FileSecurity? access = null,
		CancellationToken cancellationToken = default, IProgress<int>? progress = default) =>
		await AttachAsync(noDriveLetter ? null : new[] { "*" }, readOnly, autoDetach, access, cancellationToken, progress);

	/// <summary>
	/// Attaches a virtual hard disk (VHD) or CD or DVD image file (ISO) by locating an appropriate VHD provider to accomplish the attachment.
	/// </summary>
	/// <param name="mountPoints">
	/// The user-mode path to be associated with the volume. This may be a drive letter (for example, "X:\") or a directory on another volume
	/// (for example, "Y:\MountX\"). The string must end with a trailing backslash ('\'). Use "*" to have the system assign a drive letter or
	/// <see langword="null"/> to leave the drive letter unassigned.
	/// </param>
	/// <param name="readOnly">Attach the virtual disk as read-only.</param>
	/// <param name="autoDetach">
	/// If <c>false</c>, decouple the virtual disk lifetime from that of the VirtualDisk. The virtual disk will be attached until the Detach
	/// function is called, even if all open instances of the virtual disk are disposed.
	/// </param>
	/// <param name="access">
	/// An optional pointer to a FileSecurity instance to apply to the attached virtual disk. If this parameter is <see langword="null"/>,
	/// the security descriptor of the virtual disk image file is used. Ensure that the security descriptor that AttachVirtualDisk applies to
	/// the attached virtual disk grants the write attributes permission for the user, or that the security descriptor of the virtual disk
	/// image file grants the write attributes permission for the user if you specify <see langword="null"/> for this parameter. If the
	/// security descriptor does not grant write attributes permission for a user, Shell displays the following error when the user accesses
	/// the attached virtual disk: The Recycle Bin is corrupted. Do you want to empty the Recycle Bin for this drive?
	/// </param>
	/// <param name="cancellationToken">
	/// A cancellation token that can be used to cancel the operation. This value can be <c>default</c> to disable cancellation.
	/// </param>
	/// <param name="progress">
	/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable
	/// progress reporting.
	/// </param>
	public async Task AttachAsync(string[]? mountPoints, bool readOnly = false, bool autoDetach = true, FileSecurity? access = null,
		CancellationToken cancellationToken = default, IProgress<int>? progress = default)
	{
		if (mountPoints is not null && mountPoints.Length == 0)
			throw new ArgumentException("Mount points list cannot be empty.", nameof(mountPoints));
		if (mountPoints is not null && mountPoints[0] != "*" && mountPoints.Any(p => p == "*"))
			throw new ArgumentException("Mount points may only contain the '*' value as the first and only value.", nameof(mountPoints));

		ATTACH_VIRTUAL_DISK_FLAG flags = 0;
		if (mountPoints is null || (mountPoints.Length > 0 && mountPoints[0] != "*"))
			flags |= ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_NO_DRIVE_LETTER;
		if (readOnly)
			flags |= ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_READ_ONLY;
		if (!autoDetach)
			flags |= ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_PERMANENT_LIFETIME;
		if (access is null)
			flags |= ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_NO_SECURITY_DESCRIPTOR;

		using SafePSECURITY_DESCRIPTOR sd = FileSecToSd(access);
		await AttachAsync(flags, ATTACH_VIRTUAL_DISK_PARAMETERS.Default, sd, cancellationToken, progress);

		if (mountPoints is null || mountPoints[0] is "*")
			return;

		var vgp = VolumeGuidPaths ?? new string[0];
		if (mountPoints.Length > vgp.Length)
		{
			Detach();
			throw new ArgumentException("The number of mount points cannot be larger than the number of associated volumes.", nameof(mountPoints));
		}
		for (var i = 0; i < mountPoints.Length; i++)
			Win32Error.ThrowLastErrorIfFalse(SetVolumeMountPoint(mountPoints[i], vgp[i]));
	}

	/// <summary>Breaks a previously initiated mirror operation and sets the mirror to be the active virtual disk.</summary>
	public void BreakMirror() => BreakMirrorVirtualDisk(Handle).ThrowIfFailed();

	/// <summary>Closes the instance of the virtual disk.</summary>
	public void Close() => Dispose();

	/// <summary>Reduces the size of a virtual hard disk (VHD) backing store file.</summary>
	public void Compact() => CompactVirtualDisk(Handle, COMPACT_VIRTUAL_DISK_FLAG.COMPACT_VIRTUAL_DISK_FLAG_NONE, COMPACT_VIRTUAL_DISK_PARAMETERS.Default, IntPtr.Zero).ThrowIfFailed();

	/// <summary>Reduces the size of a virtual hard disk (VHD) backing store file.</summary>
	/// <param name="cancellationToken">
	/// A cancellation token that can be used to cancel the operation. This value can be <c>default</c> to disable cancellation.
	/// </param>
	/// <param name="progress">
	/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable
	/// progress reporting.
	/// </param>
	/// <returns><c>true</c> if operation completed without error or cancellation; <c>false</c> otherwise.</returns>
	public async Task<bool> CompactAsync(CancellationToken cancellationToken = default, IProgress<int>? progress = default) =>
		await RunAsync(Handle, (in NativeOverlapped vhdOverlap) =>
			CompactVirtualDisk(Handle, COMPACT_VIRTUAL_DISK_FLAG.COMPACT_VIRTUAL_DISK_FLAG_NONE, COMPACT_VIRTUAL_DISK_PARAMETERS.Default, vhdOverlap), cancellationToken, progress);

	/// <summary>Returns the value of the handle field.</summary>
	/// <returns>An IntPtr representing the value of the handle field.</returns>
	public IntPtr DangerousGetHandle() => ((IHandle)Handle).DangerousGetHandle();

	/// <summary>Deletes a snapshot from a VHD Set file.</summary>
	/// <param name="id">The Snapshot Id in GUID format indicating which snapshot is to be deleted from the VHD Set.</param>
	/// <param name="persistReferencePoint">
	/// If set to <see langword="true"/>, a reference point should be persisted in the VHD Set after the snapshot is deleted..
	/// </param>
	/// <returns></returns>
	public void DeleteSnapshot(Guid id, bool persistReferencePoint = false)
	{
		DELETE_SNAPSHOT_VHDSET_PARAMETERS param = new()
		{
			Version = DELETE_SNAPSHOT_VHDSET_VERSION.DELETE_SNAPSHOT_VHDSET_VERSION_1,
			Version1 = new() { SnapshotId = id }
		};
		DeleteSnapshotVhdSet(Handle, param, persistReferencePoint ? 0 : DELETE_SNAPSHOT_VHDSET_FLAG.DELETE_SNAPSHOT_VHDSET_FLAG_PERSIST_RCT).ThrowIfFailed();
	}

	/// <summary>
	/// Detaches a virtual hard disk (VHD) or CD or DVD image file (ISO) by locating an appropriate virtual disk provider to accomplish the operation.
	/// </summary>
	public void Detach()
	{
		if (!Attached)
		{
			return;
		}

		DetachVirtualDisk(Handle, DETACH_VIRTUAL_DISK_FLAG.DETACH_VIRTUAL_DISK_FLAG_NONE, 0).ThrowIfFailed();
	}

	/// <inheritdoc/>
	public virtual void Dispose() => Handle.Dispose();

	/// <summary>Increases the size of a fixed or dynamic virtual hard disk (VHD).</summary>
	/// <param name="newSize">New size, in bytes, for the expansion request.</param>
	public void Expand(ulong newSize)
	{
		if (ver < OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_2)
		{
			throw new NotSupportedException(@"Expansion is only available to virtual disks opened under version 2 or higher.");
		}

		ExpandVirtualDisk(Handle, EXPAND_VIRTUAL_DISK_FLAG.EXPAND_VIRTUAL_DISK_FLAG_NONE, new EXPAND_VIRTUAL_DISK_PARAMETERS(newSize), IntPtr.Zero).ThrowIfFailed();
	}

	/// <summary>Increases the size of a fixed or dynamic virtual hard disk (VHD).</summary>
	/// <param name="newSize">New size, in bytes, for the expansion request.</param>
	/// <param name="cancellationToken">
	/// A cancellation token that can be used to cancel the operation. This value can be <c>default</c> to disable cancellation.
	/// </param>
	/// <param name="progress">
	/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable
	/// progress reporting.
	/// </param>
	/// <returns><c>true</c> if operation completed without error or cancellation; <c>false</c> otherwise.</returns>
	public async Task<bool> ExpandAsync(ulong newSize, CancellationToken cancellationToken = default, IProgress<int>? progress = default) =>
		await RunAsync(Handle, (in NativeOverlapped vhdOverlap) =>
			{
				if (ver < OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_2)
				{
					throw new NotSupportedException(@"Expansion is only available to virtual disks opened under version 2 or higher.");
				}

				EXPAND_VIRTUAL_DISK_PARAMETERS param = new(newSize);
				return ExpandVirtualDisk(Handle, EXPAND_VIRTUAL_DISK_FLAG.EXPAND_VIRTUAL_DISK_FLAG_NONE, param, vhdOverlap);
			}, cancellationToken, progress);

	/// <summary>Issues an embedded SCSI request directly to a virtual hard disk.</summary>
	/// <param name="param">A valid RAW_SCSI_VIRTUAL_DISK_PARAMETERS structure that contains snapshot deletion data.</param>
	/// <returns>A RAW_SCSI_VIRTUAL_DISK_RESPONSE structure that contains the results of processing the SCSI command.</returns>
	/// <exception cref="PlatformNotSupportedException">Only supported on Windows 10 and later.</exception>
	public RAW_SCSI_VIRTUAL_DISK_RESPONSE IssueSCSIRequest(in RAW_SCSI_VIRTUAL_DISK_PARAMETERS param)
	{
		if (!PInvokeClient.Windows10.IsPlatformSupported())
			throw new PlatformNotSupportedException("Only supported on Windows 10 and later.");

		RawSCSIVirtualDisk(Handle, param, RAW_SCSI_VIRTUAL_DISK_FLAG.RAW_SCSI_VIRTUAL_DISK_FLAG_NONE, out RAW_SCSI_VIRTUAL_DISK_RESPONSE resp).ThrowIfFailed();
		return resp;
	}

	/// <summary>Merges a child virtual hard disk (VHD) in a differencing chain with parent disks in the chain.</summary>
	/// <param name="sourceDepth">Depth from the leaf from which to begin the merge. The leaf is at depth 1.</param>
	/// <param name="targetDepth">Depth from the leaf to target the merge. The leaf is at depth 1.</param>
	public void Merge(uint sourceDepth, uint targetDepth)
	{
		MERGE_VIRTUAL_DISK_PARAMETERS param = new(sourceDepth, targetDepth);
		MergeVirtualDisk(Handle, MERGE_VIRTUAL_DISK_FLAG.MERGE_VIRTUAL_DISK_FLAG_NONE, param, IntPtr.Zero).ThrowIfFailed();
	}

	/// <summary>Asynchronously merges a child virtual hard disk (VHD) in a differencing chain with parent disks in the chain.</summary>
	/// <param name="sourceDepth">Depth from the leaf from which to begin the merge. The leaf is at depth 1.</param>
	/// <param name="targetDepth">Depth from the leaf to target the merge. The leaf is at depth 1.</param>
	/// <param name="cancellationToken">
	/// A cancellation token that can be used to cancel the operation. This value can be <c>default</c> to disable cancellation.
	/// </param>
	/// <param name="progress">
	/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable
	/// progress reporting.
	/// </param>
	public async Task MergeAsync(uint sourceDepth, uint targetDepth, CancellationToken cancellationToken = default, IProgress<int>? progress = default) =>
		await RunAsync(Handle, (in NativeOverlapped vhdOverlap) =>
		{
			MERGE_VIRTUAL_DISK_PARAMETERS param = new(sourceDepth, targetDepth);
			return MergeVirtualDisk(Handle, MERGE_VIRTUAL_DISK_FLAG.MERGE_VIRTUAL_DISK_FLAG_NONE, param, vhdOverlap);
		}, cancellationToken, progress);

	/// <summary>Merges a child virtual hard disk (VHD) in a differencing chain with its immediate parent disk in the chain.</summary>
	public void MergeWithParent()
	{
		MERGE_VIRTUAL_DISK_PARAMETERS param = new(1);
		MergeVirtualDisk(Handle, MERGE_VIRTUAL_DISK_FLAG.MERGE_VIRTUAL_DISK_FLAG_NONE, param, IntPtr.Zero).ThrowIfFailed();
	}

	/// <summary>
	/// Initiates a mirror operation for a virtual disk. Once the mirroring operation is initiated it will not complete until either CancelIo
	/// or CancelIoEx is called to cancel all I/O on the VirtualDiskHandle, leaving the original file as the current or
	/// BreakMirrorVirtualDisk is called to stop using the original file and only use the mirror.
	/// </summary>
	/// <param name="destPath">Fully qualified path where the mirrored virtual disk will be or is located.</param>
	/// <param name="cancellationToken">
	/// A cancellation token that can be used to cancel the operation. This value can be <c>default</c> to disable cancellation.
	/// </param>
	/// <param name="progress">
	/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable
	/// progress reporting.
	/// </param>
	/// <exception cref="NotSupportedException">@"Mirroring is only available to virtual disks opened under version 2 or higher.</exception>
	public async Task MirrorAsync(string destPath, CancellationToken cancellationToken = default, IProgress<int>? progress = default)
	{
		if (ver < OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_2)
			throw new NotSupportedException(@"Mirroring is only available to virtual disks opened under version 2 or higher.");

		await RunAsync(Handle, (in NativeOverlapped vhdOverlap) =>
		{
			MIRROR_VIRTUAL_DISK_FLAG flags = File.Exists(destPath) ? MIRROR_VIRTUAL_DISK_FLAG.MIRROR_VIRTUAL_DISK_FLAG_EXISTING_FILE : MIRROR_VIRTUAL_DISK_FLAG.MIRROR_VIRTUAL_DISK_FLAG_NONE;
			SafeCoTaskMemString pDest = new(destPath);
			MIRROR_VIRTUAL_DISK_PARAMETERS param = new() { Version = MIRROR_VIRTUAL_DISK_VERSION.MIRROR_VIRTUAL_DISK_VERSION_1, Version1 = new() { MirrorVirtualDiskPath = pDest } };
			return MirrorVirtualDisk(Handle, flags, param, vhdOverlap);
		}, cancellationToken, progress);
	}

	/// <summary>Modifies the internal contents of a virtual disk file. Can be used to set the active leaf, or to fix up snapshot entries.</summary>
	/// <param name="id">The Snapshot Id in GUID format indicating which snapshot is to have its path altered in the VHD Set.</param>
	/// <param name="newSnapshotFilePath">The new file path for the Snapshot indicated by <paramref name="id"/>.</param>
	/// <param name="writeable"><see langword="true"/> to indicate that the snapshot should be created as a writable snapshot type.</param>
	public void ModifySnapshotPath(Guid id, string newSnapshotFilePath, bool writeable = false)
	{
		using SafeCoTaskMemString pfp = new(newSnapshotFilePath);
		MODIFY_VHDSET_PARAMETERS param = new()
		{
			Version = MODIFY_VHDSET_VERSION.MODIFY_VHDSET_SNAPSHOT_PATH,
			Version1 = new() { SnapshotPath = new() { SnapshotId = id, SnapshotFilePath = (IntPtr)pfp } }
		};
		ModifyVhdSet(Handle, param, writeable ? 0 : MODIFY_VHDSET_FLAG.MODIFY_VHDSET_FLAG_WRITEABLE_SNAPSHOT).ThrowIfFailed();
	}

	/// <summary>
	/// Retrieves information about changes to the specified areas of a virtual hard disk (VHD) that are tracked by resilient change tracking (RCT).
	/// </summary>
	/// <param name="changeTrackingId">
	/// The change tracking identifier for the change that identifies the state of the virtual disk that you want to use as the basis of
	/// comparison to determine whether the specified area of the VHD has changed.
	/// </param>
	/// <param name="offset">
	/// The distance from the start of the VHD to the beginning of the area of the VHD that you want to check for changes, in bytes.
	/// </param>
	/// <param name="length">The length of the area of the VHD that you want to check for changes, in bytes.</param>
	/// <returns>
	/// An array of QUERY_CHANGES_VIRTUAL_DISK_RANGE structures that indicates the areas of the virtual disk within the area that the
	/// <paramref name="offset"/> and <paramref name="length"/> parameters specify that have changed since the change tracking identifier
	/// that the <paramref name="changeTrackingId"/> parameter specifies was sealed.
	/// </returns>
	public QUERY_CHANGES_VIRTUAL_DISK_RANGE[] QueryChanges(string changeTrackingId, ulong offset = 0, ulong length = ulong.MaxValue)
	{
		if (length + offset > VirtualSize)
			length = VirtualSize - offset;

		var cRanges = 42u;
		ulong cProcessed;
		QUERY_CHANGES_VIRTUAL_DISK_RANGE[] ranges;
		do
		{
			cRanges *= 4;
			ranges = new QUERY_CHANGES_VIRTUAL_DISK_RANGE[cRanges];
			QueryChangesVirtualDisk(Handle, changeTrackingId, offset, length, QUERY_CHANGES_VIRTUAL_DISK_FLAG.QUERY_CHANGES_VIRTUAL_DISK_FLAG_NONE,
				ranges, ref cRanges, out cProcessed).ThrowIfFailed();
		} while (cProcessed < length);
		Array.Resize(ref ranges, (int)cRanges);
		return ranges;
	}

	/// <summary>Resizes a virtual disk.</summary>
	/// <param name="newSize">
	/// New size, in bytes, for the expansion request. Setting this value to '0' will shrink the disk to the smallest safe virtual size
	/// possible without truncating past any existing partitions.
	/// </param>
	public void Resize(ulong newSize)
	{
		if (ver < OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_2)
		{
			throw new NotSupportedException(@"Expansion is only available to virtual disks opened under version 2 or higher.");
		}

		RESIZE_VIRTUAL_DISK_FLAG flags = newSize == 0 ? RESIZE_VIRTUAL_DISK_FLAG.RESIZE_VIRTUAL_DISK_FLAG_RESIZE_TO_SMALLEST_SAFE_VIRTUAL_SIZE : RESIZE_VIRTUAL_DISK_FLAG.RESIZE_VIRTUAL_DISK_FLAG_NONE;
		RESIZE_VIRTUAL_DISK_PARAMETERS param = new(newSize);
		ResizeVirtualDisk(Handle, flags, param, IntPtr.Zero).ThrowIfFailed();
	}

	/// <summary>Resizes a virtual disk.</summary>
	/// <param name="newSize">New size, in bytes, for the expansion request.</param>
	/// <param name="cancellationToken">
	/// A cancellation token that can be used to cancel the operation. This value can be <c>default</c> to disable cancellation.
	/// </param>
	/// <param name="progress">
	/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable
	/// progress reporting.
	/// </param>
	/// <returns><c>true</c> if operation completed without error or cancellation; <c>false</c> otherwise.</returns>
	public async Task<bool> ResizeAsync(ulong newSize, CancellationToken cancellationToken = default, IProgress<int>? progress = default)
	{
		if (ver < OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_2)
		{
			throw new NotSupportedException(@"Expansion is only available to virtual disks opened under version 2 or higher.");
		}

		return await RunAsync(Handle, (in NativeOverlapped vhdOverlap) =>
		{
			RESIZE_VIRTUAL_DISK_PARAMETERS param = new(newSize);
			return ResizeVirtualDisk(Handle, RESIZE_VIRTUAL_DISK_FLAG.RESIZE_VIRTUAL_DISK_FLAG_NONE, param, vhdOverlap);
		}, cancellationToken, progress);
	}

	/// <summary>Sets the active leaf of a virtual disk file.</summary>
	/// <param name="defaultFilePath">The file path for the default Snapshot of the Vhd Set.</param>
	/// <param name="writeable"><see langword="true"/> to indicate that the snapshot should be created as a writable snapshot type.</param>
	public void SetDefaultSnapshotPath(string defaultFilePath, bool writeable = false)
	{
		using SafeCoTaskMemString pfp = new(defaultFilePath);
		MODIFY_VHDSET_PARAMETERS param = new()
		{
			Version = MODIFY_VHDSET_VERSION.MODIFY_VHDSET_DEFAULT_SNAPSHOT_PATH,
			Version1 = new() { DefaultFilePath = (IntPtr)pfp }
		};
		ModifyVhdSet(Handle, param, writeable ? 0 : MODIFY_VHDSET_FLAG.MODIFY_VHDSET_FLAG_WRITEABLE_SNAPSHOT).ThrowIfFailed();
	}

	/// <summary>Sets the path to virtal hard disk's parent.</summary>
	/// <param name="path">The full path to the parent disk.</param>
	public void SetParentPath(string path)
	{
		using SafeCoTaskMemString pStr = new(path);
		SET_VIRTUAL_DISK_INFO si = new(SET_VIRTUAL_DISK_INFO_VERSION.SET_VIRTUAL_DISK_INFO_PARENT_PATH) { ParentFilePath = (IntPtr)pStr };
		SetVirtualDiskInformation(Handle, si).ThrowIfFailed();
	}

	/// <summary>Sets the path to virtal hard disk's parent and the child depth.</summary>
	/// <param name="path">The full path to the parent disk.</param>
	/// <param name="childDepth">Specifies the depth to the child from the leaf. The leaf itself is at depth 1.</param>
	public void SetParentPathAndDepth(string path, uint childDepth)
	{
		using SafeCoTaskMemString pStr = new(path);
		SET_VIRTUAL_DISK_INFO si = new(SET_VIRTUAL_DISK_INFO_VERSION.SET_VIRTUAL_DISK_INFO_PARENT_PATH_WITH_DEPTH)
		{ ParentPathWithDepthInfo = new() { ParentFilePath = (IntPtr)pStr, ChildDepth = childDepth } };
		SetVirtualDiskInformation(Handle, si).ThrowIfFailed();
	}

	/// <summary>Creates a snapshot of the current virtual disk for VHD Set files.</summary>
	/// <param name="id">The Id of the new Snapshot to be added to the Vhd Set.</param>
	/// <param name="writeable"><see langword="true"/> to indicate that the snapshot should be created as a writable snapshot type.</param>
	public void TakeSnapshot(Guid id, bool writeable = false)
	{
		TAKE_SNAPSHOT_VHDSET_PARAMETERS param = new()
		{
			Version = TAKE_SNAPSHOT_VHDSET_VERSION.TAKE_SNAPSHOT_VHDSET_VERSION_1,
			Version1 = new() { SnapshotId = id }
		};
		TakeSnapshotVhdSet(Handle, param, writeable ? 0 : TAKE_SNAPSHOT_VHDSET_FLAG.TAKE_SNAPSHOT_VHDSET_FLAG_WRITEABLE).ThrowIfFailed();
	}

	/// <summary>
	/// Resizes a virtual disk without checking the virtual disk's partition table to ensure that this truncation is safe. <note
	/// type="warning">This method can cause unrecoverable data loss; use with care.</note>
	/// </summary>
	/// <param name="newSize">New size, in bytes, for the expansion request.</param>
	public void UnsafeResize(ulong newSize)
	{
		if (ver < OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_2)
		{
			throw new NotSupportedException(@"Expansion is only available to virtual disks opened under version 2 or higher.");
		}

		RESIZE_VIRTUAL_DISK_FLAG flags = RESIZE_VIRTUAL_DISK_FLAG.RESIZE_VIRTUAL_DISK_FLAG_ALLOW_UNSAFE_VIRTUAL_SIZE;
		RESIZE_VIRTUAL_DISK_PARAMETERS param = new(newSize);
		ResizeVirtualDisk(Handle, flags, param, IntPtr.Zero).ThrowIfFailed();
	}

	private static SafePSECURITY_DESCRIPTOR FileSecToSd(FileSecurity? sec) => sec == null
				? SafePSECURITY_DESCRIPTOR.Null
				: ConvertStringSecurityDescriptorToSecurityDescriptor(sec.GetSecurityDescriptorSddlForm(AccessControlSections.All));

	private static uint? GetDiskNumberFromDevicePath(string devicePath)
	{
		using var hfile = OpenDrive(devicePath);
		return !hfile.IsInvalid && DeviceIoControl(hfile, IOControlCode.IOCTL_STORAGE_GET_DEVICE_NUMBER, out STORAGE_DEVICE_NUMBER output)
			? output.DeviceNumber : null;
	}

	private static bool GetProgress(VIRTUAL_DISK_HANDLE hVhd, in NativeOverlapped vhdOverlap, CancellationToken cancellationToken, IProgress<int>? progress)
	{
		progress?.Report(0);
		while (true)
		{
			if (cancellationToken.IsCancellationRequested)
				return false;

			GetVirtualDiskOperationProgress(hVhd, vhdOverlap, out VIRTUAL_DISK_PROGRESS prog).ThrowIfFailed();
			switch (prog.OperationStatus)
			{
				case 0:
					progress?.Report(100);
					return true;

				case Win32Error.ERROR_IO_PENDING:
					progress?.Report(Math.Min(100, (int)(prog.CurrentValue * 100 / prog.CompletionValue)));
					break;

				default:
					throw new Win32Error(prog.OperationStatus).GetException() ?? new Exception();
			}

			Task.Delay(100, cancellationToken);
		}
	}

	private static string? GetVolumeGuidFromDiskNumber(uint diskNo) => GetVolumeGuidsFromDiskNumber(diskNo).FirstOrDefault();

	private static IEnumerable<string> GetVolumeGuidsFromDiskNumber(uint diskNo) => EnumVolumes().Where(v =>
	{
		using var hfile = OpenDrive(v.TrimEnd('\\'));
		return !hfile.IsInvalid &&
			DeviceIoControl(hfile, IOControlCode.IOCTL_STORAGE_GET_DEVICE_NUMBER, out STORAGE_DEVICE_NUMBER output) &&
			output.DeviceNumber == diskNo;
	}).ToArray();

	/// <summary>Retrieves a list of drive letters and mounted folder paths for the specified volume.</summary>
	/// <param name="volumeName">A volume GUID path for the volume. A volume GUID path is of the form "\\?\Volume{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}\".</param>
	/// <returns>The list of drive letters and mounted folder paths.</returns>
	private static string[] GetVolumeMountPoints(string volumeName)
	{
		bool ret = GetVolumePathNamesForVolumeName(volumeName, IntPtr.Zero, 0, out var sz);
		var err = Win32Error.GetLastError();
		if (!ret && err != Win32Error.ERROR_MORE_DATA) throw err.GetException()!;
		if (ret) return new string[0];
		using var mem = new SafeCoTaskMemHandle(sz * StringHelper.GetCharSize());
		Win32Error.ThrowLastErrorIfFalse(GetVolumePathNamesForVolumeName(volumeName, mem, sz, out _));
		return mem.ToStringEnum().ToArray();
	}

	private static SafeHFILE OpenDrive(string fn) => CreateFile(fn, 0, FileShare.ReadWrite, default, FileMode.Open, 0);

	private static async Task<bool> RunAsync(VIRTUAL_DISK_HANDLE hVhd, RunAsyncMethod method, CancellationToken cancellationToken, IProgress<int>? progress) =>
		await Task.Run(() =>
		{
			NativeOverlapped vhdOverlap = new();
			method(in vhdOverlap).ThrowUnless(Win32Error.ERROR_IO_PENDING);
			return GetProgress(hVhd, vhdOverlap, cancellationToken, progress);
		});

	private T GetInformation<T>(GET_VIRTUAL_DISK_INFO_VERSION info, long offset = 0)
	{
		using SafeCoTaskMemStruct<GET_VIRTUAL_DISK_INFO> mem = GetInformation(info);

		offset += 8; // Add size of version
		if (typeof(T) == typeof(string[]))
		{
			if (mem.DangerousGetHandle().Offset(offset).ToStructure<ushort>() == 0)
			{
				return (T)(object)new string[0];
			}

			return (T)(object)mem.DangerousGetHandle().ToStringEnum(CharSet.Unicode, (int)offset).ToArray();
		}

		return mem.DangerousGetHandle().Offset(offset).Convert<T>((uint)(mem.Size - offset), CharSet.Unicode)!;
	}

	private SafeCoTaskMemStruct<GET_VIRTUAL_DISK_INFO> GetInformation(GET_VIRTUAL_DISK_INFO_VERSION info)
	{
		SafeCoTaskMemStruct<GET_VIRTUAL_DISK_INFO> mem = new(new GET_VIRTUAL_DISK_INFO { Version = info });
		uint sz = mem.Size;
		Win32Error err = GetVirtualDiskInformation(Handle, ref sz, mem, out var req);
		if (err == Win32Error.ERROR_INSUFFICIENT_BUFFER)
		{
			mem.Size = sz;
			err = GetVirtualDiskInformation(Handle, ref sz, mem, out req);
		}
		Debug.WriteLineIf(err.Succeeded, $"GetVirtualDiskInformation: Id={info.ToString().Remove(0, 22)}; Unk={Marshal.ReadInt32(mem, 4)}; Sz={req}; Bytes={string.Join(" ", mem.DangerousGetHandle().ToIEnum<uint>((int)req / 4).Select(b => b.ToString("X8")).ToArray())}");
		err.ThrowIfFailed();
		return mem;
	}

	/// <summary>Supports getting and setting metadata on a virtual disk.</summary>
	/// <seealso cref="IDictionary{Guid, SafeCoTaskMemHandle}"/>
	public class VirtualDiskMetadata : Vanara.Collections.VirtualDictionary<Guid, SafeCoTaskMemHandle>
	{
		private readonly VirtualDisk parent;
		private readonly bool supported;

		/// <summary>Initializes a new instance of the <see cref="VirtualDiskMetadata"/> class.</summary>
		/// <param name="vhd">The VHD.</param>
		internal VirtualDiskMetadata(VirtualDisk vhd) : base(false)
		{
			parent = vhd;
			supported = vhd.DiskType == DeviceType.Vhdx;
		}

		/// <inheritdoc/>
		public override ICollection<Guid> Keys
		{
			get
			{
				var ret = new Guid[0];
				if (supported)
				{
					if (parent.Handle.IsClosed)
					{
						throw new InvalidOperationException("Virtual disk not valid.");
					}

					uint count = 0;
					Win32Error err = EnumerateVirtualDiskMetadata(parent.Handle, ref count, null);
					if (err != Win32Error.ERROR_MORE_DATA && err != Win32Error.ERROR_INSUFFICIENT_BUFFER)
					{
						err.ThrowIfFailed();
					}

					if (count != 0)
					{
						ret = new Guid[count];
						EnumerateVirtualDiskMetadata(parent.Handle, ref count, ret).ThrowIfFailed();
						return ret;
					}
				}
				return ret;
			}
		}

		/// <inheritdoc/>
		public override bool Remove(Guid key)
		{
			ThrowIfInvalid();

			return DeleteVirtualDiskMetadata(parent.Handle, key).Succeeded;
		}

		/// <inheritdoc/>
		public override bool TryGetValue(Guid key, out SafeCoTaskMemHandle value)
		{
			ThrowIfInvalid();

			uint sz = 0;
			value = SafeCoTaskMemHandle.Null;
			Win32Error err = GetVirtualDiskMetadata(parent.Handle, key, ref sz, default);
			if (err != Win32Error.ERROR_MORE_DATA && err != Win32Error.ERROR_INSUFFICIENT_BUFFER)
				return false;

			SafeCoTaskMemHandle ret = new((int)sz);
			if (GetVirtualDiskMetadata(parent.Handle, key, ref sz, ret).Failed)
				return false;
			value = ret;
			return true;
		}

		/// <inheritdoc/>
		protected override void SetValue(Guid key, SafeCoTaskMemHandle value)
		{
			ThrowIfInvalid();

			SetVirtualDiskMetadata(parent.Handle, key, value.Size, value).ThrowIfFailed();
		}

		private void ThrowIfInvalid()
		{
			if (!supported)
				throw new PlatformNotSupportedException();

			if (parent.Handle.IsClosed)
				throw new InvalidOperationException("Virtual disk not valid.");
		}
	}
}