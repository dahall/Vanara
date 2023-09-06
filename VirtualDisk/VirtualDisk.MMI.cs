using Vanara.Management;

namespace Vanara.IO;

public partial class VirtualDisk
{
	private static readonly System.Management.ManagementScope scope = new(@"root\virtualization\v2");

	/// <summary>Compaction options for <see cref="CompactAsync(CompactionMode, CancellationToken, IProgress{int})"/>.</summary>
	public enum CompactionMode : ushort
	{
		/// <summary>Full.</summary>
		Full = 0,

		/// <summary>Quick.</summary>
		Quick,

		/// <summary>Retrimmed</summary>
		Retrim,

		/// <summary>Pretrimmed</summary>
		Pretrimmed,

		/// <summary>Prezeroed</summary>
		Prezeroed
	}

	/// <summary>
	/// Converts an existing virtual hard disk to a different type or format. This method creates a new virtual hard disk and does not
	/// convert the source virtual hard disk in place.
	/// </summary>
	/// <param name="path">
	/// The fully qualified path of the source virtual hard disk file to convert. This file will not be modified as a result of this operation.
	/// </param>
	/// <param name="targetType">The format for the target virtual hard disk.</param>
	/// <param name="cancellationToken">
	/// A cancellation token that can be used to cancel the operation. This value can be <see cref="CancellationToken.None"/> to disable cancellation.
	/// </param>
	/// <param name="progress">
	/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable
	/// progress reporting.
	/// </param>
	public static async Task ConvertAsync(string path, DeviceType targetType, CancellationToken cancellationToken = default, IProgress<int>? progress = default)
	{
		var dest = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(path) ?? throw new ArgumentException("A full path to a virtual disk is required.", nameof(path)), $"{System.IO.Path.GetFileNameWithoutExtension(path)}.{targetType.ToString().ToLower()}");
		if (string.Equals(path, dest, StringComparison.InvariantCultureIgnoreCase))
			return;
		VirtualDisk vhd = Open(path, true, true);
		Subtype subType = vhd.ProviderSubtype;
		vhd.Close();
		var data = new VirtualDiskSettingData(subType, targetType, dest);
		await ConvertAsync(path, data, cancellationToken, progress);
	}

	/// <summary>
	/// Converts an existing virtual hard disk to a different type or format. This method creates a new virtual hard disk and does not
	/// convert the source virtual hard disk in place.
	/// </summary>
	/// <param name="sourcePath">
	/// The fully qualified path of the source virtual hard disk file to convert. This file will not be modified as a result of this operation.
	/// </param>
	/// <param name="destinationSettings">The settings, including path, for the target virtual hard disk.</param>
	/// <param name="cancellationToken">
	/// A cancellation token that can be used to cancel the operation. This value can be <see cref="CancellationToken.None"/> to disable cancellation.
	/// </param>
	/// <param name="progress">
	/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable
	/// progress reporting.
	/// </param>
	public static async Task ConvertAsync(string sourcePath, VirtualDiskSettingData destinationSettings, CancellationToken cancellationToken = default, IProgress<int>? progress = default)
	{
		try
		{
			System.Management.ManagementBaseObject output = await scope.CallJobMethodAsync(cancellationToken, progress, "Msvm_ImageManagementService", "ConvertVirtualHardDisk", ("SourcePath", sourcePath), ("VirtualDiskSettingData", destinationSettings.GetInstanceText()));
			output.GetResultOrThrow(true);
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Failed to convert virtual disk.", ex);
		}
	}

	/// <summary>Converts a virtual hard disk file by creating a new VHD Set file alongside the existing virtual hard disk.</summary>
	/// <param name="path">The path to the virtual hard disk file. The new VHD Set file will have the same filename but with the .VHDS extension.</param>
	/// <param name="cancellationToken">
	/// A cancellation token that can be used to cancel the operation. This value can be <see cref="CancellationToken.None"/> to disable cancellation.
	/// </param>
	/// <param name="progress">
	/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable
	/// progress reporting.
	/// </param>
	/// <exception cref="System.InvalidOperationException">Failed to create virtual disk set file.</exception>
	public static async Task ConvertToVHDSetAsync(string path, CancellationToken cancellationToken = default, IProgress<int>? progress = default)
	{
		try
		{
			System.Management.ManagementBaseObject output = await scope.CallJobMethodAsync(cancellationToken, progress, "Msvm_ImageManagementService", "ConvertVirtualHardDiskToVHDSet", ("VirtualHardDiskPath", path));
			output.GetResultOrThrow(true);
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Failed to create virtual disk set file.", ex);
		}
	}

	/// <summary>
	/// Merges a child virtual hard disk in a differencing chain with one or more parent virtual hard disks in the chain. See Remarks for
	/// usage restrictions for this method.
	/// <para>If the user executing this function does not have permission to update the virtual machines, then this function will fail.</para>
	/// </summary>
	/// <param name="sourcePath">A fully qualified path that specifies the location of the virtual hard disk file to merge.</param>
	/// <param name="destPath">
	/// A fully qualified path that specifies the location of the parent virtual hard disk file into which data is to be merged. This could
	/// be the immediate parent virtual hard disk of the merging file or the parent disk image a few levels up the differencing chain.
	/// </param>
	/// <param name="cancellationToken">
	/// A cancellation token that can be used to cancel the operation. This value can be <see cref="CancellationToken.None"/> to disable cancellation.
	/// </param>
	/// <param name="progress">
	/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable
	/// progress reporting.
	/// </param>
	public static async Task MergeAsync(string sourcePath, string destPath, CancellationToken cancellationToken = default, IProgress<int>? progress = default)
	{
		try
		{
			System.Management.ManagementBaseObject output = await scope.CallJobMethodAsync(cancellationToken, progress, "Msvm_ImageManagementService", "MergeVirtualHardDisk", ("SourcePath", sourcePath), ("DestinationPath", destPath));
			output.GetResultOrThrow(true);
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Failed to merge virtual disks.", ex);
		}
	}

	/// <summary>Optimizes a VHD Set file to use less disk space.</summary>
	/// <param name="path">A fully-qualified path that specifies the location of the VHD Set file.</param>
	/// <param name="cancellationToken">
	/// A cancellation token that can be used to cancel the operation. This value can be <see cref="CancellationToken.None"/> to disable cancellation.
	/// </param>
	/// <param name="progress">
	/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable
	/// progress reporting.
	/// </param>
	/// <exception cref="System.InvalidOperationException">Failed to create virtual disk set file.</exception>
	public static async Task OptimizeVHDSetAsync(string path, CancellationToken cancellationToken = default, IProgress<int>? progress = default)
	{
		try
		{
			System.Management.ManagementBaseObject output = await scope.CallJobMethodAsync(cancellationToken, progress, "Msvm_ImageManagementService", "OptimizeVHDSet", ("VHDSetPath", path));
			output.GetResultOrThrow(true);
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Failed to optimize virtual disk set file.", ex);
		}
	}

	/// <summary>Determines whether a virtual hard disk file is valid.</summary>
	/// <param name="path">
	/// The fully qualified path of the virtual hard disk file to validate. This file will not be modified as a result of this operation.
	/// </param>
	/// <param name="cancellationToken">
	/// A cancellation token that can be used to cancel the operation. This value can be <see cref="CancellationToken.None"/> to disable cancellation.
	/// </param>
	/// <param name="progress">
	/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable
	/// progress reporting.
	/// </param>
	/// <returns><c>true</c> if operation completed without error or cancellation; <c>false</c> otherwise.</returns>
	public static async Task<bool> ValidateAsync(string path, CancellationToken cancellationToken = default, IProgress<int>? progress = default)
	{
		try
		{
			System.Management.ManagementBaseObject output = await scope.CallJobMethodAsync(cancellationToken, progress, "Msvm_ImageManagementService", "ValidateVirtualHardDisk", ("Path", path));
			return output.GetResultOrThrow(true);
		}
		catch
		{
			return false;
		}
	}

	/// <summary>Validates whether a file system can support a virtual hard disk with persistent reservations enabled.</summary>
	/// <param name="path">
	/// A fully-qualified path that specifies the location of a disk image file or a directory in which a disk image file might be placed.
	/// </param>
	/// <returns><see langword="true"/> if the file system can support a virtual hard disk with persistent reservations enabled.</returns>
	public static bool ValidatePersistentReservationSupport(string path)
	{
		try
		{
			return scope.CallJobMethodAsync(default, default, "Msvm_ImageManagementService", "ValidatePersistentReservationSupport", ("Path", path)).Result.GetResultOrThrow(true);
		}
		catch
		{
			return false;
		}
	}

	/// <summary>Reduces the size of a virtual hard disk (VHD) backing store file.</summary>
	/// <param name="mode">The mode.</param>
	/// <param name="cancellationToken">
	/// A cancellation token that can be used to cancel the operation. This value can be <see cref="CancellationToken.None"/> to disable cancellation.
	/// </param>
	/// <param name="progress">
	/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to disable
	/// progress reporting.
	/// </param>
	public async Task CompactAsync(CompactionMode mode, CancellationToken cancellationToken = default, IProgress<int>? progress = default)
	{
		try
		{
			System.Management.ManagementBaseObject output = await scope.CallJobMethodAsync(cancellationToken, progress, "Msvm_ImageManagementService", "CompactVirtualHardDisk", ("Path", ImagePath), ("Mode", (ushort)mode));
			output.GetResultOrThrow(true);
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Failed to compact virtual disk.", ex);
		}
	}

	/// <summary>Retrieves information about a VHD Set file.</summary>
	/// <returns>The information for the requested VHD Set file as an <see cref="VirtualDiskSetInformation"/> instance.</returns>
	/// <exception cref="System.InvalidOperationException">Failed to get virtual disk set information.</exception>
	public VirtualDiskSetInformation GetVHDSetInformation()
	{
		try
		{
			var info = new uint[] { 0, 1, 2 };
			System.Management.ManagementBaseObject output = scope.CallJobMethodAsync(default, default, "Msvm_ImageManagementService", "GetVHDSetInformation", ("VHDSetPath", ImagePath), ("AdditionalInformation", info)).Result;
			output.GetResultOrThrow(true);
			return VirtualDiskSetInformation.Parse(Convert.ToString(output.Properties["Information"].Value));
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Failed to get virtual disk set information.", ex);
		}
	}

	/// <summary>Retrieves information about a VHD Snapshot within a VHD Set file.</summary>
	/// <param name="path">A fully-qualified path that specifies the location of the VHD Set file.</param>
	/// <param name="snapshotId">The snapshot identifier.</param>
	/// <returns>The information for the requested VHD Set file as an <see cref="VirtualDiskSnapshotInformation"/> instance.</returns>
	/// <exception cref="System.InvalidOperationException">Failed to get virtual disk set information.</exception>
	// TODO: Fix problem with it failing regardless of what parameters are supplied
	internal static VirtualDiskSnapshotInformation GetSnapshotInformation(string path, Guid snapshotId)
	{
		try
		{
			var info = new uint[] { 2 };
			System.Management.ManagementBaseObject output = scope.CallJobMethodAsync(default, default, "Msvm_ImageManagementService", "GetVHDSnapshotInformation",
				("VHDSetPath", path), ("AdditionalInformation", info), ("SnapshotIds", new[] { snapshotId.ToString("D") })).Result;
			output.GetResultOrThrow(true);
			return VirtualDiskSnapshotInformation.Parse(Convert.ToString(output.Properties["SnapshotInformation"].Value));
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Failed to get virtual disk snapshot information.", ex);
		}
	}

	/// <summary>Sets the snapshot information asynchronous.</summary>
	/// <param name="info">The information.</param>
	/// <exception cref="System.InvalidOperationException">Failed to set virtual disk snapshot information.</exception>
	// TODO: Fix problem with it failing regardless of what parameters are supplied
	internal static async Task SetSnapshotInformationAsync(VirtualDiskSnapshotInformation info)
	{
		try
		{
			System.Management.ManagementBaseObject output = await scope.CallJobMethodAsync(default, default, "Msvm_ImageManagementService", "SetVHDSnapshotInformation",
				("Information", info.GetInstanceText()));
			output.GetResultOrThrow(true);
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Failed to set virtual disk snapshot information.", ex);
		}
	}

	// TODO: Create listener events for states in RequestStateChange
}