using System.IO;
using System.Net;
using System.Threading;

namespace Vanara.PInvoke.Tests;

internal partial class BackgroundCopyTests
{
	[Test]
	public void DownloadJobTest()
	{
		using var tempRoot = new TemporaryDirectory();
		DirectoryInfo remoteRoot; remoteRoot = tempRoot.CreateSubDirectory(nameof(remoteRoot));
		DirectoryInfo localDirectory; localDirectory = tempRoot.CreateSubDirectory(nameof(localDirectory));

		var allFileInfos = new[]
		{
			tempRoot.CreateSubDirectoryFile(remoteRoot, fileSize: 1 * TemporaryDirectory.OneMebibyte),
			tempRoot.CreateSubDirectoryFile(remoteRoot, fileSize: 2 * TemporaryDirectory.OneMebibyte),
			tempRoot.CreateSubDirectoryFile(remoteRoot, fileSize: 3 * TemporaryDirectory.OneMebibyte),
			tempRoot.CreateSubDirectoryFile(remoteRoot, fileSize: 4 * TemporaryDirectory.OneMebibyte),
			tempRoot.CreateSubDirectoryFile(remoteRoot, fileSize: 5 * TemporaryDirectory.OneMebibyte)
		};

		var allFilesTotalSize = allFileInfos.Select(fi => fi.Length).Sum();
		var allFilesToDownload = allFileInfos.Select(fi => fi.Name).ToArray();

		var raiseException = false;
		AutoResetEvent autoReset;

		// Local method because of local vars.
		void OnDownloadCompleted(object? s, BackgroundCopyJobEventArgs e) => DownloadCompleted(e, autoReset, allFilesToDownload.Length, allFilesTotalSize);

		// Create a download job.
		using var downloadJob = BackgroundCopyManager.Jobs.Add($"{nameof(remoteRoot)} download");

		using (autoReset = new AutoResetEvent(false))
		{
			// Set job properties.
			downloadJob.Credentials.Add(BackgroundCopyJobCredentialScheme.Digest, BackgroundCopyJobCredentialTarget.Proxy, "user", "mypwd");
			downloadJob.CustomHeaders = new WebHeaderCollection() { "A1:Test", "A2:Prova" };
			Assert.That(downloadJob.CustomHeaders, Is.Not.Empty);
			downloadJob.MinimumNotificationInterval = TimeSpan.FromSeconds(1);

			// Set event handlers for job, these are weak references.
			downloadJob.Error += OnDownloadError;
			downloadJob.FileTransferred += OnDownloadFileTransferred;
			downloadJob.Completed += OnDownloadCompleted;

			// Add download file information.
			downloadJob.Files.AddRange(remoteRoot.FullName, localDirectory.FullName, allFilesToDownload);
			Assert.That(downloadJob.Files, Is.Not.Empty);
			Assert.That(() => downloadJob.Files.Any(f => f.LocalFilePath.Contains(allFilesToDownload[0])), Throws.Nothing);

			// Start (resume) the job.
			downloadJob.Resume();

			// Block thread and wait.
			raiseException = !autoReset.WaitOne(TimeSpan.FromSeconds(10));
		}

		// Remove weak references to prevent memory leak.
		downloadJob.Completed -= OnDownloadCompleted;
		downloadJob.FileTransferred -= OnDownloadFileTransferred;
		downloadJob.Error -= OnDownloadError;

		if (raiseException)
			throw new InvalidOperationException();

		// Better performance when event methods are defined seperately, preferably static.

		static void DownloadCompleted(BackgroundCopyJobEventArgs e, AutoResetEvent autoResetEvent, long totalFiles, long totalBytes)
		{
			var job = e.Job;

			job.Complete();

			Assert.That(totalFiles, Is.EqualTo(job.Progress.FilesTotal));
			Assert.That(totalBytes, Is.EqualTo(job.Progress.BytesTransferred));

			// Enable: Debug > Options > Debugging > General: Redirect all Output Window text to the Immediate Window
			Debug.WriteLine($"Completed job: {job.DisplayName} | Total files: {job.Progress.FilesTotal:N0} | Bytes: {job.Progress.BytesTotal:N0}");

			autoResetEvent.Set();
		}

		static void OnDownloadError(object? s, BackgroundCopyJobEventArgs e) => throw e.Job.LastError ?? new Exception();

		static void OnDownloadFileTransferred(object? s, BackgroundCopyFileTransferredEventArgs e)
		{
			var fileInfo = e.FileInfo;

			// Enable: Debug > Options > Debugging > General: Redirect all Output Window text to the Immediate Window
			Debug.WriteLine($"Transferred {fileInfo.BytesTransferred:N0} bytes | File: {fileInfo.LocalFilePath}");
		}
	}
}