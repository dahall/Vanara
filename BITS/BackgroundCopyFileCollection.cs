using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.BITS;

namespace Vanara.IO;

/// <summary>Manages the set of files for a background copy job.</summary>
public class BackgroundCopyFileCollection : ICollection<BackgroundCopyFileInfo>, IDisposable
{
	private IBackgroundCopyJob m_ijob;

	internal BackgroundCopyFileCollection(IBackgroundCopyJob ijob) => m_ijob = ijob;

	internal BackgroundCopyFileCollection()
	{
	}

	/// <summary>Gets the number of files in the current job.</summary>
	public int Count
	{
		get
		{
			try
			{
				return (int)m_ijob.EnumFiles().GetCount();
			}
			catch (COMException cex)
			{
				HandleCOMException(cex);
			}
			return 0;
		}
	}

	/// <summary>Gets a value indicating whether the <see cref="ICollection{T}"/> is read-only.</summary>
	bool ICollection<BackgroundCopyFileInfo>.IsReadOnly => false;

	/// <summary>Add a file to a download or an upload job. Only one file can be added to upload jobs.</summary>
	/// <param name="remoteFilePath">
	/// Contains the name of the file on the server (for example, http://[server]/[path]/file.ext). The format of the name must conform
	/// to the transfer protocol you use. You cannot use wildcards in the path or file name. The URL must contain only legal URL
	/// characters; no escape processing is performed. The URL is limited to 2,200 characters, not including the null terminator. You can
	/// use SMB to express the remote name of the file to download or upload; there is no SMB support for upload-reply jobs. You can
	/// specify the remote name as a UNC path, full path with a network drive, or use the "file://" prefix.
	/// </param>
	/// <param name="localFilePath">
	/// Contains the name of the file on the client. The file name must include the full path (for example, d:\myapp\updates\file.ext).
	/// You cannot use wildcards in the path or file name, and directories in the path must exist. The user must have permission to write
	/// to the local directory for downloads and the reply portion of an upload-reply job. BITS does not support NTFS streams. Instead of
	/// using network drives, which are session specific, use UNC paths.
	/// </param>
	/// <remarks>
	/// <para>
	/// To add more than one file at a time to a job, call the <see cref="AddRange(Uri, DirectoryInfo, IEnumerable{string})"/> method. It
	/// is more efficient to call the <c>AddRange</c> method when adding multiple files to a job than to call the <c>Add</c> method in a loop.
	/// </para>
	/// <para>
	/// To add a file to a job from which BITS downloads ranges of data from the file, call the
	/// <see cref="Add(string, string, long, long)"/> method.
	/// </para>
	/// <para>Upload jobs can only contain one file. If you add a second file, the method returns BG_E_TOO_MANY_FILES.</para>
	/// <para>
	/// For downloads, BITS guarantees that the version of a file (based on file size and date, not content) that it transfers will be
	/// consistent; however, it does not guarantee that a set of files will be consistent. For example, if BITS is in the middle of
	/// downloading the second of two files in the job at the time that the files are updated on the server, BITS restarts the download
	/// of the second file; however, the first file is not downloaded again.
	/// </para>
	/// <para>
	/// Note that if you own the file being downloaded from the server, you should create a new URL for each new version of the file. If
	/// you use the same URL for new versions of the file, some proxy servers may serve stale data from their cache because they do not
	/// verify with the original server if the file is stale.
	/// </para>
	/// <para>
	/// For uploads, BITS generates an error if the local file changes while the file is transferring. The error code is
	/// BG_E_FILE_CHANGED and the context is BG_ERROR_CONTEXT_LOCAL_FILE.
	/// </para>
	/// <para>
	/// BITS transfers the files within a job sequentially. If an error occurs while transferring a file, the job moves to an error state
	/// and no more files within the job are processed until the error is resolved.
	/// </para>
	/// <para>
	/// By default, a user can add up to 200 files to a job. This limit does not apply to administrators or service accounts. To change
	/// the default, set the <c>MaxFilesPerJob</c> group policies.
	/// </para>
	/// <para><c>Prior to Windows Vista:</c> There is no limit on the number of files that a user can add to a job.</para>
	/// </remarks>
	public void Add(string remoteFilePath, string localFilePath)
	{
		// remoteFilePath must not have a trailing backslash.
		if (!string.IsNullOrEmpty(remoteFilePath))
			remoteFilePath.TrimEnd('/');


		try
		{
			m_ijob.AddFile(remoteFilePath, localFilePath);
		}
		catch (COMException cex)
		{
			HandleCOMException(cex);
		}
	}

	/// <summary>Add a file to a download job and specify the ranges of the file you want to download.</summary>
	/// <param name="remoteFilePath">
	/// Contains the name of the file on the server (for example, http://[server]/[path]/file.ext). The format of the name must conform
	/// to the transfer protocol you use. You cannot use wildcards in the path or file name. The URL must contain only legal URL
	/// characters; no escape processing is performed. The URL is limited to 2,200 characters, not including the null terminator. You can
	/// use SMB to express the remote name of the file to download or upload; there is no SMB support for upload-reply jobs. You can
	/// specify the remote name as a UNC path, full path with a network drive, or use the "file://" prefix.
	/// </param>
	/// <param name="localFilePath">
	/// Contains the name of the file on the client. The file name must include the full path (for example, d:\myapp\updates\file.ext).
	/// You cannot use wildcards in the path or file name, and directories in the path must exist. The user must have permission to write
	/// to the local directory for downloads and the reply portion of an upload-reply job. BITS does not support NTFS streams. Instead of
	/// using network drives, which are session specific, use UNC paths.
	/// </param>
	/// <param name="initialOffset">Zero-based offset to the beginning of the range of bytes to download from a file.</param>
	/// <param name="length">Number of bytes in the range.</param>
	public void Add(string remoteFilePath, string localFilePath, long initialOffset, long length = -1)
	{
		IBackgroundCopyJob3 ijob3;
		try { ijob3 = (IBackgroundCopyJob3)m_ijob; }
		catch { throw new NotSupportedException(); }
		var rng = new[] { new BG_FILE_RANGE { InitialOffset = (ulong)initialOffset, Length = length == -1 ? ulong.MaxValue : (ulong)length } };
		try
		{
			ijob3.AddFileWithRanges(remoteFilePath, localFilePath, 1, rng);
		}
		catch (COMException cex)
		{
			HandleCOMException(cex);
		}
	}

	/// <summary>Add a list of files to download from a URL.</summary>
	/// <param name="remoteUrlRoot">
	/// Contains the name of the directory on the server (for example, http://[server]/[path]/). The format of the name must conform to
	/// the transfer protocol you use. You cannot use wildcards in the path or file name. The URL must contain only legal URL characters;
	/// no escape processing is performed. The URL is limited to 2,200 characters, not including the null terminator. You can use SMB to
	/// express the remote name of the file to download or upload; there is no SMB support for upload-reply jobs. You can specify the
	/// remote name as a UNC path, full path with a network drive, or use the "file://" prefix.
	/// </param>
	/// <param name="localDirectory">
	/// Contains the name of the directory on the client. The directory must exist. The user must have permission to write to the
	/// directory for downloads. BITS does not support NTFS streams. Instead of using network drives, which are session specific, use UNC paths.
	/// </param>
	/// <param name="files">
	/// List of relative file names to retrieve from the remote directory. Filename will be appended to both the remoteUrlRoot and the localDirectory.
	/// </param>
	public void AddRange(Uri remoteUrlRoot, DirectoryInfo localDirectory, IEnumerable<string> files)
	{
		var array = files.Select(s => new BG_FILE_INFO(new Uri(remoteUrlRoot, s).AbsoluteUri, Path.Combine(localDirectory.FullName, s))).ToArray();
		try
		{
			m_ijob.AddFileSet((uint)array.Length, array);
		}
		catch (COMException cex)
		{
			HandleCOMException(cex);
		}
	}


	/// <summary>Add a list of files to download from a URL.</summary>
	/// <param name="remoteUrlRoot">
	/// Contains the name of the directory on the server (for example, http://[server]/[path]/). The format of the name must conform to
	/// the transfer protocol you use. You cannot use wildcards in the path or file name. The URL must contain only legal URL characters;
	/// no escape processing is performed. The URL is limited to 2,200 characters, not including the null terminator. You can use SMB to
	/// express the remote name of the file to download or upload; there is no SMB support for upload-reply jobs. You can specify the
	/// remote name as a UNC path, full path with a network drive, or use the "file://" prefix.
	/// </param>
	/// <param name="localDirectory">
	/// Contains the name of the directory on the client. The directory must exist. The user must have permission to write to the
	/// directory for downloads. BITS does not support NTFS streams. Instead of using network drives, which are session specific, use UNC paths.
	/// </param>
	/// <param name="files">
	/// List of relative file names to retrieve from the remote directory. Filename will be appended to both the remoteUrlRoot and the localDirectory.
	/// </param>
	public void AddRange(string remoteUrlRoot, string localDirectory, IEnumerable<string> files)
	{
		// remoteUrlRoot must have a trailing backslash.
		if (!string.IsNullOrEmpty(remoteUrlRoot) && !remoteUrlRoot.EndsWith("/", StringComparison.Ordinal))
			remoteUrlRoot += "/";

		AddRange(new Uri(remoteUrlRoot), new DirectoryInfo(localDirectory), files);
	}


	/// <summary>
	/// Returns an object that implements the <see cref="IEnumerator"/> interface and that can iterate through the
	/// <see cref="BackgroundCopyFileInfo"/> objects within the <see cref="BackgroundCopyFileCollection"/> collection.
	/// </summary>
	/// <returns>
	/// Returns an object that implements the <see cref="IEnumerator"/> interface and that can iterate through the
	/// <see cref="BackgroundCopyFileInfo"/> objects within the <see cref="BackgroundCopyFileCollection"/> collection.
	/// </returns>
	public IEnumerator<BackgroundCopyFileInfo> GetEnumerator() => new Enumerator(m_ijob.EnumFiles());

	/// <summary>Adds an item to the <see cref="ICollection{T}"/>.</summary>
	/// <param name="item">The object to add to the <see cref="ICollection{T}"/>.</param>
	/// <exception cref="NotImplementedException"></exception>
	void ICollection<BackgroundCopyFileInfo>.Add(BackgroundCopyFileInfo item)
	{
	}

	/// <summary>Removes all items from the <see cref="ICollection{T}"/>.</summary>
	/// <exception cref="NotImplementedException"></exception>
	void ICollection<BackgroundCopyFileInfo>.Clear() => throw new NotSupportedException();

	/// <summary>Determines whether the <see cref="ICollection{T}"/> contains a specific value.</summary>
	/// <param name="item">The object to locate in the <see cref="ICollection{T}"/>.</param>
	/// <returns>true if <paramref name="item"/> is found in the <see cref="ICollection{T}"/>; otherwise, false.</returns>
	/// <exception cref="NotImplementedException"></exception>
	bool ICollection<BackgroundCopyFileInfo>.Contains(BackgroundCopyFileInfo item)
	{
		var e = GetEnumerator();
		while (e.MoveNext())
			if (ReferenceEquals(e.Current, item))
				return true;
		return false;
	}

	/// <summary>
	/// Copies the elements of the <see cref="ICollection{T}"/> to an <see cref="T:System.Array"/>, starting at a particular
	/// <see cref="T:System.Array"/> index.
	/// </summary>
	/// <param name="array">
	/// The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from
	/// <see cref="ICollection{T}"/>. The <see cref="T:System.Array"/> must have zero-based indexing.
	/// </param>
	/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
	/// <exception cref="NotImplementedException"></exception>
	void ICollection<BackgroundCopyFileInfo>.CopyTo(BackgroundCopyFileInfo[] array, int arrayIndex)
	{
		var e = GetEnumerator();
		while (array.Length > arrayIndex && e.MoveNext())
		{
			array[arrayIndex] = e.Current;
			arrayIndex++;
		}
	}

	/// <summary>Disposes of the BackgroundCopyFileSet object.</summary>
	void IDisposable.Dispose() => m_ijob = null;

	/// <summary>Returns an enumerator that iterates through a collection.</summary>
	/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	/// <summary>Removes the first occurrence of a specific object from the <see cref="ICollection{T}"/>.</summary>
	/// <param name="item">The object to remove from the <see cref="ICollection{T}"/>.</param>
	/// <returns>
	/// true if <paramref name="item"/> was successfully removed from the <see cref="ICollection{T}"/>; otherwise, false. This method
	/// also returns false if <paramref name="item"/> is not found in the original <see cref="ICollection{T}"/>.
	/// </returns>
	/// <exception cref="NotImplementedException"></exception>
	bool ICollection<BackgroundCopyFileInfo>.Remove(BackgroundCopyFileInfo item) => throw new NotSupportedException();

	internal BackgroundCopyFileInfo[] GetBCFIArray() => this.ToArray();

	private void HandleCOMException(COMException cex)
	{
		var state = m_ijob.GetState();
		if (state == BG_JOB_STATE.BG_JOB_STATE_ERROR || state == BG_JOB_STATE.BG_JOB_STATE_TRANSIENT_ERROR)
		{
			var pErr = m_ijob.GetError();
			throw new BackgroundCopyException(pErr);
		}
		else
			throw new BackgroundCopyException(cex);
	}

	/// <summary>
	/// An implementation the <see cref="IEnumerator"/> interface that can iterate through the <see cref="BackgroundCopyFileInfo"/>
	/// objects within the <see cref="BackgroundCopyFileCollection"/> collection.
	/// </summary>
	private sealed class Enumerator : Vanara.Collections.IEnumeratorFromNext<IEnumBackgroundCopyFiles, BackgroundCopyFileInfo>
	{
		internal Enumerator(IEnumBackgroundCopyFiles enumfiles) : base(enumfiles, TryGetNext, e => e.Reset())
		{
		}

		private static bool TryGetNext(IEnumBackgroundCopyFiles e, out BackgroundCopyFileInfo i)
		{
			var ifi = e.Next(1)?.FirstOrDefault();
			i = ifi is not null ? new BackgroundCopyFileInfo(ifi) : null;
			return i is not null;
		}
	}
}