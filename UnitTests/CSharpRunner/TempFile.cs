using System.IO;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

/// <summary>Creates a unique temporary file in the %APPDATA%\Temp folder and deletes it when disposed.</summary>
/// <seealso cref="IDisposable"/>
public class TempFile : IDisposable
{
	/// <summary>The default value inserted into the file if not overridden by constructor parameter.</summary>
	public const string tmpstr = @"Temporary";

	/// <summary>Initializes a new instance of the <see cref="TempFile"/> class and retrieves a handle to the file.</summary>
	/// <param name="dwDesiredAccess">The desired access.</param>
	/// <param name="dwShareMode">The share mode.</param>
	/// <param name="dwCreationDisposition">The creation disposition.</param>
	/// <param name="dwFlagsAndAttributes">The flags and attributes.</param>
	public TempFile(Kernel32.FileAccess dwDesiredAccess, FileShare dwShareMode, FileMode dwCreationDisposition = FileMode.OpenOrCreate,
		FileFlagsAndAttributes dwFlagsAndAttributes = FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL) : this(string.Empty) =>
		hFile = CreateFile(FullName, dwDesiredAccess, dwShareMode, null, dwCreationDisposition, dwFlagsAndAttributes, IntPtr.Zero);

	/// <summary>Initializes a new instance of the <see cref="TempFile"/> class with the specified contents.</summary>
	/// <param name="contents">
	/// The text inserted into the file. If this value is <see langword="null"/>, the file is not created on disk.
	/// </param>
	public TempFile(string contents = tmpstr)
	{
		FullName = Path.GetTempFileName();
		if (contents is null)
			File.Delete(FullName);
		else if (contents != string.Empty)
			File.WriteAllText(FullName, contents);
	}

	/// <summary>Initializes a new instance of the <see cref="TempFile"/> class with the specified extension and contents.</summary>
	/// <param name="ext">The file extension.</param>
	/// <param name="contents">
	/// The text inserted into the file. If this value is <see langword="null"/>, the file is not created on disk.
	/// </param>
	public TempFile(string ext, string? contents = tmpstr)
	{
		FullName = Path.Combine(Path.GetTempPath(), $"tmp{Guid.NewGuid():N}.{ext.TrimStart('.')}");
		if (contents is not null)
			File.WriteAllText(FullName, contents);
	}

	/// <summary>Gets the full path of the temporary file.</summary>
	/// <value>The full path of the temporary file.</value>
	public string FullName { get; }

	/// <summary>
	/// Gets the file handle if created with the <see cref="TempFile(Kernel32.FileAccess, FileShare, FileMode,
	/// FileFlagsAndAttributes)"/> constructor.
	/// </summary>
	/// <value>The file handle.</value>
	public SafeHFILE? hFile { get; }

	/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
	/// <returns></returns>
	void IDisposable.Dispose()
	{
		hFile?.Dispose();
		if (File.Exists(FullName))
			File.Delete(FullName);
	}
}