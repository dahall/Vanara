using System;
using System.IO;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	public class TempFile : IDisposable
	{
		public const string tmpstr = @"Temporary";

		public TempFile(Kernel32.FileAccess dwDesiredAccess, FileShare dwShareMode, FileMode dwCreationDisposition = FileMode.OpenOrCreate, FileFlagsAndAttributes dwFlagsAndAttributes = FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL) : this()
		{
			hFile = CreateFile(FullName, dwDesiredAccess, dwShareMode, null, dwCreationDisposition, dwFlagsAndAttributes, IntPtr.Zero);
		}

		public TempFile(string contents = tmpstr)
		{
			FullName = Path.GetTempFileName();
			if (contents is null)
				File.Delete(FullName);
			else
				File.WriteAllText(FullName, contents);
		}

		public string FullName { get; }
		public SafeHFILE hFile { get; }

		void IDisposable.Dispose()
		{
			hFile?.Dispose();
			if (File.Exists(FullName))
				File.Delete(FullName);
		}
	}
}