using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.BITS;

namespace Vanara.IO
{
	/// <summary>Manages the set of files for a background copy job.</summary>
	public class BackgroundCopyFileCollection : ICollection<BackgroundCopyFileInfo>, IDisposable
	{
		private IBackgroundCopyJob m_ijob;

		internal BackgroundCopyFileCollection(IBackgroundCopyJob ijob)
		{
			m_ijob = ijob;
		}

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
		/// Contains the name of the file on the server (for example, http://[server]/[path]/file.ext). The format of the name must conform to the transfer
		/// protocol you use. You cannot use wildcards in the path or file name. The URL must contain only legal URL characters; no escape processing is
		/// performed. The URL is limited to 2,200 characters, not including the null terminator. You can use SMB to express the remote name of the file to
		/// download or upload; there is no SMB support for upload-reply jobs. You can specify the remote name as a UNC path, full path with a network drive, or
		/// use the "file://" prefix.
		/// </param>
		/// <param name="localFilePath">
		/// Contains the name of the file on the client. The file name must include the full path (for example, d:\myapp\updates\file.ext). You cannot use
		/// wildcards in the path or file name, and directories in the path must exist. The user must have permission to write to the local directory for
		/// downloads and the reply portion of an upload-reply job. BITS does not support NTFS streams. Instead of using network drives, which are session
		/// specific, use UNC paths.
		/// </param>
		public void Add(string remoteFilePath, string localFilePath)
		{
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
		/// Contains the name of the file on the server (for example, http://[server]/[path]/file.ext). The format of the name must conform to the transfer
		/// protocol you use. You cannot use wildcards in the path or file name. The URL must contain only legal URL characters; no escape processing is
		/// performed. The URL is limited to 2,200 characters, not including the null terminator. You can use SMB to express the remote name of the file to
		/// download or upload; there is no SMB support for upload-reply jobs. You can specify the remote name as a UNC path, full path with a network drive, or
		/// use the "file://" prefix.
		/// </param>
		/// <param name="localFilePath">
		/// Contains the name of the file on the client. The file name must include the full path (for example, d:\myapp\updates\file.ext). You cannot use
		/// wildcards in the path or file name, and directories in the path must exist. The user must have permission to write to the local directory for
		/// downloads and the reply portion of an upload-reply job. BITS does not support NTFS streams. Instead of using network drives, which are session
		/// specific, use UNC paths.
		/// </param>
		/// <param name="initialOffset">Zero-based offset to the beginning of the range of bytes to download from a file.</param>
		/// <param name="length">Number of bytes in the range.</param>
		public void Add(string remoteFilePath, string localFilePath, long initialOffset, long length = -1)
		{
			IBackgroundCopyJob3 ijob3 = null;
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
		/// Contains the name of the directory on the server (for example, http://[server]/[path]/). The format of the name must conform to the transfer protocol
		/// you use. You cannot use wildcards in the path or file name. The URL must contain only legal URL characters; no escape processing is performed. The
		/// URL is limited to 2,200 characters, not including the null terminator. You can use SMB to express the remote name of the file to download or upload;
		/// there is no SMB support for upload-reply jobs. You can specify the remote name as a UNC path, full path with a network drive, or use the "file://" prefix.
		/// </param>
		/// <param name="localDirectory">
		/// Contains the name of the directory on the client. The directory must exist. The user must have permission to write to the directory for downloads.
		/// BITS does not support NTFS streams. Instead of using network drives, which are session specific, use UNC paths.
		/// </param>
		/// <param name="files">List of file names to retrieve. Filename will be appended to both the remoteUrlRoot and the localDirectory.</param>
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

		/// <summary>Disposes of the BackgroundCopyFileSet object.</summary>
		void IDisposable.Dispose()
		{
			m_ijob = null;
		}

		/// <summary>
		/// Returns an object that implements the <see cref="IEnumerator"/> interface and that can iterate through the <see cref="BackgroundCopyFileInfo"/>
		/// objects within the <see cref="BackgroundCopyFileCollection"/> collection.
		/// </summary>
		/// <returns>
		/// Returns an object that implements the <see cref="IEnumerator"/> interface and that can iterate through the <see cref="BackgroundCopyFileInfo"/>
		/// objects within the <see cref="BackgroundCopyFileCollection"/> collection.
		/// </returns>
		public IEnumerator<BackgroundCopyFileInfo> GetEnumerator()
		{
			var ienum = m_ijob.EnumFiles();
			return new Enumerator(ienum);
		}

		/// <summary>Adds an item to the <see cref="ICollection{T}"/>.</summary>
		/// <param name="item">The object to add to the <see cref="ICollection{T}"/>.</param>
		/// <exception cref="NotImplementedException"></exception>
		void ICollection<BackgroundCopyFileInfo>.Add(BackgroundCopyFileInfo item)
		{
		}

		/// <summary>Removes all items from the <see cref="ICollection{T}"/>.</summary>
		/// <exception cref="NotImplementedException"></exception>
		void ICollection<BackgroundCopyFileInfo>.Clear()
		{
			throw new NotSupportedException();
		}

		/// <summary>Determines whether the <see cref="ICollection{T}"/> contains a specific value.</summary>
		/// <param name="item">The object to locate in the <see cref="ICollection{T}"/>.</param>
		/// <returns>true if <paramref name="item"/> is found in the <see cref="ICollection{T}"/>; otherwise, false.</returns>
		/// <exception cref="NotImplementedException"></exception>
		bool ICollection<BackgroundCopyFileInfo>.Contains(BackgroundCopyFileInfo item)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Copies the elements of the <see cref="ICollection{T}"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
		/// </summary>
		/// <param name="array">
		/// The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="ICollection{T}"/>. The
		/// <see cref="T:System.Array"/> must have zero-based indexing.
		/// </param>
		/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
		/// <exception cref="NotImplementedException"></exception>
		void ICollection<BackgroundCopyFileInfo>.CopyTo(BackgroundCopyFileInfo[] array, int arrayIndex)
		{
			throw new NotSupportedException();
		}

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>Removes the first occurrence of a specific object from the <see cref="ICollection{T}"/>.</summary>
		/// <param name="item">The object to remove from the <see cref="ICollection{T}"/>.</param>
		/// <returns>
		/// true if <paramref name="item"/> was successfully removed from the <see cref="ICollection{T}"/>; otherwise, false. This method also returns false if
		/// <paramref name="item"/> is not found in the original <see cref="ICollection{T}"/>.
		/// </returns>
		/// <exception cref="NotImplementedException"></exception>
		bool ICollection<BackgroundCopyFileInfo>.Remove(BackgroundCopyFileInfo item)
		{
			throw new NotSupportedException();
		}

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
		/// An implementation the <see cref="IEnumerator"/> interface that can iterate through the <see cref="BackgroundCopyFileInfo"/> objects within the
		/// <see cref="BackgroundCopyFileCollection"/> collection.
		/// </summary>
		private sealed class Enumerator : IEnumerator<BackgroundCopyFileInfo>
		{
			private IBackgroundCopyFile icurrentfile;
			private IEnumBackgroundCopyFiles ienum;

			internal Enumerator(IEnumBackgroundCopyFiles enumfiles)
			{
				ienum = enumfiles;
				ienum.Reset();
			}

			/// <summary>
			/// Gets the <see cref="BackgroundCopyFileInfo"/> object in the <see cref="BackgroundCopyFileCollection"/> collection to which the enumerator is pointing.
			/// </summary>
			public BackgroundCopyFileInfo Current => icurrentfile != null ? new BackgroundCopyFileInfo(icurrentfile) : throw new InvalidOperationException();

			/// <summary>
			/// Gets the <see cref="BackgroundCopyFileInfo"/> object in the <see cref="BackgroundCopyFileCollection"/> collection to which the enumerator is pointing.
			/// </summary>
			object IEnumerator.Current => Current;

			/// <summary>Disposes of the Enumerator object.</summary>
			public void Dispose()
			{
				ienum = null;
				icurrentfile = null;
			}

			/// <summary>Moves the enumerator index to the next object in the collection.</summary>
			/// <returns></returns>
			public bool MoveNext()
			{
				try
				{
					icurrentfile = ienum.Next(1)?.FirstOrDefault();
					return icurrentfile != null;
				}
				catch { return false; }
			}

			/// <summary>Resets the enumerator index to the beginning of the <see cref="BackgroundCopyFileCollection"/> collection.</summary>
			public void Reset()
			{
				icurrentfile = null;
				ienum.Reset();
			}
		}
	}
}