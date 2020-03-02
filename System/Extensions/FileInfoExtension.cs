using System;
using System.ComponentModel;
using System.IO;

#if !(NET20 || NET35)
using System.Threading.Tasks;
#endif

using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.Extensions
{
	/// <summary>Extension methods for <see cref="FileSystemInfo"/> and derived classes to facilitate retrieval of extended properties.</summary>
	public static class FileInfoExtension
	{
		/// <summary>Gets the file handle of the <see cref="FileSystemInfo"/> reference.</summary>
		/// <param name="fi">The file information.</param>
		/// <param name="readOnly">if set to <see langword="true"/> retrieve the handle as read-only.</param>
		/// <param name="overlapped">if set to <see langword="true"/> retrieve the handle as overlapped.</param>
		/// <returns>A safe handle to the file.</returns>
		public static SafeHFILE GetFileHandle(this FileSystemInfo fi, bool readOnly = true, bool overlapped = false)
		{
			var fa = readOnly ? System.IO.FileAccess.Read : System.IO.FileAccess.ReadWrite;
			var fs = readOnly ? FileShare.Read : FileShare.None;
			var ff = FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL;
			if (overlapped) ff |= FileFlagsAndAttributes.FILE_FLAG_OVERLAPPED;
			if (fi is DirectoryInfo) ff |= FileFlagsAndAttributes.FILE_FLAG_BACKUP_SEMANTICS;
			return CreateFile(fi.FullName, (Kernel32.FileAccess)fa, fs, null, FileMode.Open, ff, HFILE.NULL);
		}

		/// <summary>Gets the file system flags for a drive.</summary>
		/// <param name="di">The <see cref="DriveInfo"/> reference.</param>
		/// <returns>The associated system file flags.</returns>
		public static FileSystemFlags GetFileSystemFlags(this DriveInfo di) =>
			GetVolumeInformation(di.Name, out _, out _, out _, out var fsFlags, out _) ? fsFlags : throw new Win32Exception();

		/// <summary>Gets the maximum length of a file name on the specified drive.</summary>
		/// <param name="di">The <see cref="DriveInfo"/> reference.</param>
		/// <returns>The maximum length of a file name on the specified drive.</returns>
		public static uint GetMaxFileNameLength(this DriveInfo di) =>
			GetVolumeInformation(di.Name, out _, out _, out var compLen, out _, out _) ? compLen : throw new Win32Exception();

		/// <summary>Gets whether NTFS compression is enabled for this file.</summary>
		/// <param name="fi">The file information.</param>
		/// <returns><see langword="true"/> if the specified files is compressed under NTFS; otherwise <see langword="false"/>.</returns>
		public static bool GetNtfsCompression(this FileSystemInfo fi)
		{
			using var fs = GetFileHandle(fi);
			return DeviceIoControl(fs, IOControlCode.FSCTL_GET_COMPRESSION, out ushort outVal) ? outVal != 0 : throw new Win32Exception();
			//return (fi.Attributes & FileAttributes.Compressed) == FileAttributes.Compressed;
		}

		/// <summary>Gets the length of the file on the disk. If the file is compressed, this will return the compressed size.</summary>
		/// <param name="fi">The <see cref="FileInfo"/> instance.</param>
		/// <returns>The actual size of the file on the disk in bytes, compressed or uncompressed.</returns>
		public static ulong GetPhysicalLength(this FileInfo fi)
		{
			GetCompressedFileSize(fi.FullName, out ulong sz).ThrowIfFailed();
			return sz;
		}

		/// <summary>Sets whether NTFS compression is enabled for this file.</summary>
		/// <param name="fi">The file information.</param>
		/// <param name="compressed">if set to <see langword="true"/> compress the file under NTFS; <see langword="false"/> to decompress.</param>
		public static void SetNtfsCompression(this FileSystemInfo fi, bool compressed)
		{
			using var fs = GetFileHandle(fi, false);
			if (!DeviceIoControl(fs, IOControlCode.FSCTL_SET_COMPRESSION, (ushort)(compressed ? 1 : 0)))
				throw new Win32Exception();
		}

#if !(NET20 || NET35)
		/// <summary>Asynchronously gets whether NTFS compression is enabled for this file.</summary>
		/// <param name="fi">The file information.</param>
		/// <returns><see langword="true"/> if the specified files is compressed under NTFS; otherwise <see langword="false"/>.</returns>
		public static Task<bool> GetNtfsCompressionAsync(this FileSystemInfo fi)
		{
			using var fs = GetFileHandle(fi, true, true);
			return ConvertTask(DeviceIoControlAsync<uint>(fs, IOControlCode.FSCTL_GET_COMPRESSION), u => u.GetValueOrDefault() > 0);
		}

		/// <summary>Asynchronously sets whether NTFS compression is enabled for this file.</summary>
		/// <param name="fi">The file information.</param>
		/// <param name="compressed">if set to <see langword="true"/> compress the file under NTFS; <see langword="false"/> to decompress.</param>
		public static Task SetNtfsCompressionAsync(this FileSystemInfo fi, bool compressed)
		{
			using var fs = GetFileHandle(fi, false, true);
			return DeviceIoControlAsync(fs, IOControlCode.FSCTL_SET_COMPRESSION, (ushort)(compressed ? 1 : 0));
		}

		private static Task<TNew> ConvertTask<TCurrent, TNew>(Task<TCurrent> task, Converter<TCurrent, TNew> converter = null)
		{
			var tret = new TaskCompletionSource<TNew>();
			if (task.IsCanceled) tret.TrySetCanceled();
			else if (task.IsFaulted && task.Exception != null) tret.TrySetException(task.Exception);
			else
			{
				if (converter == null)
					tret.TrySetResult((TNew)Convert.ChangeType(task.Result, typeof(TNew)));
				else
					tret.TrySetResult(converter(task.Result));
			}
			return tret.Task;
		}
#endif
	}
}