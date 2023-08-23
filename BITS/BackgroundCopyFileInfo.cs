using System.Collections.Generic;
using static Vanara.PInvoke.BITS;

namespace Vanara.IO;

/// <summary>Information about a file in a background copy job.</summary>
public class BackgroundCopyFileInfo
{
	internal BG_FILE_INFO fi;

	private readonly IBackgroundCopyFile? iFile;

	internal BackgroundCopyFileInfo(IBackgroundCopyFile ibgfile) => iFile = ibgfile;

	internal BackgroundCopyFileInfo(BG_FILE_INFO bgfi) => fi = bgfi;

	/// <summary>Retrieves the ranges that you want to download from the remote file.</summary>
	/// <value>The file copy ranges.</value>
	public IEnumerable<BackgroundCopyFileRange> FileRanges
	{
		get
		{
			IFile2.GetFileRanges(out var cnt, out var rng);
			return rng.ToEnumerable<BackgroundCopyFileRange>((int)cnt);
		}
	}

	/// <summary>Returns the set of file ranges that have been downloaded.</summary>
	/// <value>The file copy ranges that have been downloaded. Ranges will be merged together as much as possible. The ranges are ordered by offset.</value>
	public IEnumerable<BackgroundCopyFileRange> FilledFileRanges
	{
		get
		{
			IFile6.GetFilledFileRanges(out var cnt, out var rng);
			return rng.ToEnumerable<BackgroundCopyFileRange>((int)cnt);
		}
	}

	/// <summary>Gets or sets a value indicating whether the contents of the file are valid.</summary>
	/// <value><c>true</c> if the file content is valid; otherwise, <c>false</c>.</value>
	public bool IsFileContentValid { get => IFile3.GetValidationState(); set => IFile3.SetValidationState(value); }

	/// <summary>
	/// Size of the file in bytes. If the value is -1, the total size of the file has not been determined. BITS does not set this value if it cannot
	/// determine the size of the file. For example, if the specified file or server does not exist, BITS cannot determine the size of the file. If you are
	/// downloading ranges from a file, BytesTotal reflects the total number of bytes you want to download from the file.
	/// </summary>
	public long Length => (long)CopyProgress.BytesTotal;

	/// <summary>Retrieves the local name of the file.</summary>
	public string LocalFilePath
	{
		get => iFile is null ? fi.LocalName : iFile.GetLocalName();
		set
		{
			if (iFile is not null)
				throw new InvalidOperationException("You cannot change the LocalFilePath property on CurrentFileSet results.");
			fi.LocalName = value;
		}
	}

	/// <summary>Gets the amount of file data downloaded from the originating server.</summary>
	public ulong OriginServerDownloadBytes { get { IFile4.GetPeerDownloadStats(out var o, out var _); return o; } }

	/// <summary>Gets the amount of file data downloaded from a peer-to-peer source.</summary>
	public ulong PeerDownloadBytes { get { IFile4.GetPeerDownloadStats(out var _, out var p); return p; } }

	/// <summary>Gets the percentage of the transfer that has completed.</summary>
	public float PercentComplete
	{
		get
		{
			var p = CopyProgress;
			return p.Completed || p.BytesTotal == 0 ? 100.0F : p.BytesTransferred * 100.0F / p.BytesTotal;
		}
	}

	/// <summary>Retrieves the remote name of the file.</summary>
	public string RemoteFilePath
	{
		get => iFile is null ? fi.RemoteName : iFile.GetRemoteName();
		set
		{
			fi.RemoteName = value;
			(iFile as IBackgroundCopyFile2)?.SetRemoteName(value);
		}
	}

	/// <summary>Gets or sets the full set of HTTP response headers from the server's last HTTP response packet.</summary>
	/// <value>The response headers.</value>
	public string ResponseHeaders
	{
		get
		{
			var hdr = IFile5.GetProperty(BITS_FILE_PROPERTY_ID.BITS_FILE_PROPERTY_ID_HTTP_RESPONSE_HEADERS);
			return hdr.String;
		}
		set
		{
			var hdr = new BITS_FILE_PROPERTY_VALUE { String = value };
			IFile5.SetProperty(BITS_FILE_PROPERTY_ID.BITS_FILE_PROPERTY_ID_HTTP_RESPONSE_HEADERS, hdr);
		}
	}

	/// <summary>Gets the full path of the temporary file that contains the content of the download.</summary>
	public string TemporaryName => IFile3.GetTemporaryName();

	/// <summary>
	/// For downloads, the value is TRUE if the file is available to the user; otherwise, the value is FALSE. Files are available to the user after calling
	/// the <see cref="BackgroundCopyJob.Complete"/> method. If the <see cref="BackgroundCopyJob.Complete"/> method generates a transient error, those files
	/// processed before the error occurred are available to the user; the others are not. Use the Completed property to determine if the file is available
	/// to the user when Complete fails. For uploads, the value is TRUE when the file upload is complete; otherwise, the value is FALSE.
	/// </summary>
	public bool TransferCompleted => CopyProgress.Completed;

	/// <summary>Gets the number of bytes transferred.</summary>
	public long BytesTransferred => (long)CopyProgress.BytesTransferred;

	/// <summary>Gets a value that determines if any part of the file was downloaded from a peer.</summary>
	/// <value>Is TRUE if any part of the file was downloaded from a peer; otherwise, FALSE.</value>
	public bool IsDownloadedFromPeer => IFile3.IsDownloadedFromPeer();

	/// <summary>Retrieves the progress of the file transfer.</summary>
	internal BG_FILE_PROGRESS CopyProgress => iFile?.GetProgress() ?? throw new InvalidOperationException("You can only get the CopyProgress on CurrentFileSet results.");

	private IBackgroundCopyFile2 IFile2 => GetDerived<IBackgroundCopyFile2>();

	private IBackgroundCopyFile3 IFile3 => GetDerived<IBackgroundCopyFile3>();

	private IBackgroundCopyFile4 IFile4 => GetDerived<IBackgroundCopyFile4>();

	private IBackgroundCopyFile5 IFile5 => GetDerived<IBackgroundCopyFile5>();

	private IBackgroundCopyFile6 IFile6 => GetDerived<IBackgroundCopyFile6>();

	/// <summary>Adds a new set of file ranges to be prioritized for download.</summary>
	/// <param name="ranges">
	/// An array of file ranges to be downloaded. Requested ranges are allowed to overlap previously downloaded (or pending) ranges. Ranges are automatically
	/// split into non-overlapping ranges.
	/// </param>
	public void RequestFileRanges(BackgroundCopyFileRange[] ranges) => IFile6.RequestFileRanges((uint)ranges.Length, Array.ConvertAll(ranges, r => r.fr));

	/// <summary>Returns a <see cref="System.String" /> that represents this instance.</summary>
	/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
	public override string ToString() => $"{LocalFilePath} => {RemoteFilePath}";

	/// <summary>Specifies a position to prioritize downloading missing data from.</summary>
	/// <param name="offset">Specifies the new position to prioritize downloading missing data from.</param>
	public void UpdateDownloadPosition(ulong offset) => IFile6.UpdateDownloadPosition(offset);

	private T GetDerived<T>() where T : class => iFile as T ?? throw new PlatformNotSupportedException();
}

/// <summary>Identifies a range of bytes to download from a file.</summary>
[StructLayout(LayoutKind.Sequential)]
public class BackgroundCopyFileRange
{
	internal BG_FILE_RANGE fr;

	/// <summary>Zero-based offset to the beginning of the range of bytes to download from a file.</summary>
	public ulong InitialOffset { get => fr.InitialOffset; set => fr.InitialOffset = value; }

	/// <summary>
	/// The length of the range, in bytes. Do not specify a zero byte length. To indicate that the range extends to the end of the file, specify <c>BG_LENGTH_TO_EOF</c>.
	/// </summary>
	public ulong Length { get => fr.Length; set => fr.Length = value; }

	/// <summary>Performs an implicit conversion from <see cref="BG_FILE_RANGE"/> to <see cref="BackgroundCopyFileRange"/>.</summary>
	/// <param name="p">The BG_FILE_RANGE instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator BackgroundCopyFileRange(BG_FILE_RANGE p) => new() { fr = p };
}