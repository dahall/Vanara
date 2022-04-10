using System;
using System.Threading;
using System.Threading.Tasks;
using Vanara.Management;

namespace Vanara.IO
{
	public partial class VirtualDisk
	{
		private static readonly System.Management.ManagementScope scope = new(@"root\virtualization\v2", null);

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
		/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to
		/// disable progress reporting.
		/// </param>
		public static async Task ConvertAsync(string path, DeviceType targetType, CancellationToken cancellationToken = default, IProgress<int> progress = default)
		{
			var dest = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(path), $"{System.IO.Path.GetFileNameWithoutExtension(path)}.{targetType.ToString().ToLower()}");
			if (string.Equals(path, dest, StringComparison.InvariantCultureIgnoreCase))
				return;
			var vhd = Open(path, true, true);
			var subType = vhd.ProviderSubtype;
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
		/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to
		/// disable progress reporting.
		/// </param>
		public static async Task ConvertAsync(string sourcePath, VirtualDiskSettingData destinationSettings, CancellationToken cancellationToken = default, IProgress<int> progress = default)
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

		/// <summary>Determines whether a virtual hard disk file is valid.</summary>
		/// <param name="path">
		/// The fully qualified path of the virtual hard disk file to validate. This file will not be modified as a result of this operation.
		/// </param>
		/// <param name="cancellationToken">
		/// A cancellation token that can be used to cancel the operation. This value can be <see cref="CancellationToken.None"/> to disable cancellation.
		/// </param>
		/// <param name="progress">
		/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to
		/// disable progress reporting.
		/// </param>
		/// <returns><c>true</c> if operation completed without error or cancellation; <c>false</c> otherwise.</returns>
		public static async Task<bool> ValidateAsync(string path, CancellationToken cancellationToken = default, IProgress<int> progress = default)
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

		/// <summary>Reduces the size of a virtual hard disk (VHD) backing store file.</summary>
		/// <param name="mode">The mode.</param>
		/// <param name="cancellationToken">
		/// A cancellation token that can be used to cancel the operation. This value can be <see cref="CancellationToken.None"/> to disable cancellation.
		/// </param>
		/// <param name="progress">
		/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to
		/// disable progress reporting.
		/// </param>
		public async Task CompactAsync(CompactionMode mode, CancellationToken cancellationToken = default, IProgress<int> progress = default)
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

		/// <summary>Creates a new VHD Set file alongside the existing virtual hard disk.</summary>
		/// <param name="cancellationToken">
		/// A cancellation token that can be used to cancel the operation. This value can be <see cref="CancellationToken.None"/> to disable cancellation.
		/// </param>
		/// <param name="progress">
		/// A class that implements <see cref="IProgress{T}"/> that can be used to report on progress. This value can be <c>null</c> to
		/// disable progress reporting.
		/// </param>
		public async Task ConvertToVHDSetAsync(CancellationToken cancellationToken = default, IProgress<int> progress = default)
		{
			try
			{
				System.Management.ManagementBaseObject output = await scope.CallJobMethodAsync(cancellationToken, progress, "Msvm_ImageManagementService", "ConvertVirtualHardDiskToVHDSet", ("VirtualHardDiskPath", ImagePath));
				output.GetResultOrThrow(true);
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException("Failed to create virtual disk set file.", ex);
			}
		}
	}
}