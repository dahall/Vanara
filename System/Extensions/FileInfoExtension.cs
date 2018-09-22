using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
#if !(NET20 || NET35)
using System.Threading.Tasks;
#endif
using Microsoft.Win32.SafeHandles;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.Extensions
{
	/// <summary>Extension methods for <see cref="FileSystemInfo"/> and derived classes to facilitate retrieval of extended properties.</summary>
	public static class FileInfoExtension
	{
		public static SafeHFILE GetFileHandle(this FileSystemInfo fi, bool readOnly = true, bool overlapped = false)
		{
			var fa = readOnly ? System.IO.FileAccess.Read : System.IO.FileAccess.ReadWrite;
			var fs = readOnly ? FileShare.Read : FileShare.None;
			var ff = FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL;
			if (overlapped) ff |= FileFlagsAndAttributes.FILE_FLAG_OVERLAPPED;
			if (fi is DirectoryInfo) ff |= FileFlagsAndAttributes.FILE_FLAG_BACKUP_SEMANTICS;
			return CreateFile(fi.FullName, (Kernel32.FileAccess)fa, fs, null, FileMode.Open, ff, HFILE.NULL);
		}

		public static FileSystemFlags GetFileSystemFlags(this DriveInfo di)
		{
			GetVolumeInformation(di.Name, out string volName, out uint volSn, out uint compLen, out FileSystemFlags fsFlags, out string fsName);
			return fsFlags;
		}

		public static uint GetMaxFileNameLength(this DriveInfo di)
		{
			GetVolumeInformation(di.Name, out string volName, out uint volSn, out uint compLen, out FileSystemFlags fsFlags, out string fsName);
			return compLen;
		}

		public static bool GetNtfsCompression(this FileSystemInfo fi)
		{
			using (var fs = GetFileHandle(fi))
			{
				ushort outVal;
				if (!DeviceIoControl(fs, IOControlCode.FSCTL_GET_COMPRESSION, out outVal))
					throw new Win32Exception();
				return outVal != 0;
			}
			//return (fi.Attributes & FileAttributes.Compressed) == FileAttributes.Compressed;
		}

		/// <summary>
		/// Gets the length of the file on the disk. If the file is compressed, this will return the compressed size.
		/// </summary>
		/// <param name="fi">The <see cref="FileInfo"/> instance.</param>
		/// <returns>The actual size of the file on the disk in bytes, compressed or uncompressed.</returns>
		public static ulong GetPhysicalLength(this FileInfo fi)
		{
			var high = 0U;
			var low = GetCompressedFileSize(fi.FullName, ref high);
			var error = Marshal.GetLastWin32Error();
			if (error == Win32Error.ERROR_SHARING_VIOLATION)
				return (ulong)fi.Length;
			if (high == 0 && low == INVALID_FILE_SIZE && error != 0)
				throw new Win32Exception(error);
			return ((ulong)high << 32) | (uint)low;
		}

		public static void SetNtfsCompression(this FileSystemInfo fi, bool compressed)
		{
			using (var fs = GetFileHandle(fi, false))
			{
				if (!DeviceIoControl(fs, IOControlCode.FSCTL_SET_COMPRESSION, (ushort)(compressed ? 1 : 0)))
					throw new Win32Exception();
			}
		}

#if !(NET20 || NET35)
		public static Task<bool> GetNtfsCompressionAsync(this FileSystemInfo fi)
		{
			using (var fs = GetFileHandle(fi, true, true))
				return ConvertTask(DeviceIoControlAsync<uint>(fs, IOControlCode.FSCTL_GET_COMPRESSION), u => u.GetValueOrDefault() > 0);
		}

		public static Task SetNtfsCompressionAsync(this FileSystemInfo fi, bool compressed)
		{
			using (var fs = GetFileHandle(fi, false, true))
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
