using System.IO;
using System.Threading;

namespace Vanara.PInvoke.Tests;

internal partial class BackgroundCopyTests
{
	[Test]
	public void UploadJobTest()
	{
		using var tempRoot = new TemporaryDirectory();
		DirectoryInfo remoteRoot; remoteRoot = tempRoot.CreateSubDirectory(nameof(remoteRoot));
		DirectoryInfo localDirectory; localDirectory = tempRoot.CreateSubDirectory(nameof(localDirectory));

		var allFileInfos = new[]
		{
			tempRoot.CreateSubDirectoryFile(localDirectory, fileSize: 5 * TemporaryDirectory.OneMebibyte)
		};

		var allFilesTotalSize = allFileInfos.Select(fi => fi.Length).Sum();
		var allFilesToUpload = allFileInfos.Select(fi => fi.Name).ToArray();

		var raiseException = false;
		AutoResetEvent autoReset;

		// Local method because of local vars.
		void OnUploadCompleted(object? s, BackgroundCopyJobEventArgs e) => UploadCompleted(e, autoReset, allFilesToUpload.Length, allFilesTotalSize);

		// Create an upload job.
		using var uploadJob = BackgroundCopyManager.Jobs.Add($"{nameof(remoteRoot)} upload", jobType: BackgroundCopyJobType.Upload);

		using (autoReset = new AutoResetEvent(false))
		{
			// Set event handlers for job, these are weak references.
			uploadJob.Error += OnUploadError;
			uploadJob.FileTransferred += OnUploadFileTransferred;
			uploadJob.Completed += OnUploadCompleted;

			// Add upload file information.
			var fileToUpload = Path.Combine(remoteRoot.FullName, allFileInfos[0].Name);

			uploadJob.Files.Add(fileToUpload, allFileInfos[0].FullName);

			// Start (resume) the job.
			uploadJob.Resume();

			// Block thread and wait.
			raiseException = !autoReset.WaitOne(TimeSpan.FromSeconds(10));
		}

		// Remove weak references to prevent memory leak.
		uploadJob.Completed -= OnUploadCompleted;
		uploadJob.FileTransferred -= OnUploadFileTransferred;
		uploadJob.Error -= OnUploadError;

		if (raiseException)
			throw new InvalidOperationException();

		// Better performance when event methods are defined seperately, preferably static.

		static void OnUploadError(object? s, BackgroundCopyJobEventArgs e) => throw e.Job.LastError!;

		static void OnUploadFileTransferred(object? s, BackgroundCopyFileTransferredEventArgs e)
		{
			var fileInfo = e.FileInfo;

			// Enable: Debug > Options > Debugging > General: Redirect all Output Window text to the Immediate Window
			Debug.WriteLine($"Transferred {fileInfo.BytesTransferred:N0} bytes | File: {fileInfo.LocalFilePath}");
		}

		static void UploadCompleted(BackgroundCopyJobEventArgs e, AutoResetEvent autoResetEvent, long totalFiles, long totalBytes)
		{
			var job = e.Job;

			job.Complete();

			Assert.That(totalFiles, Is.EqualTo(job.Progress.FilesTotal));
			Assert.That(totalBytes, Is.EqualTo(job.Progress.BytesTransferred));

			// Enable: Debug > Options > Debugging > General: Redirect all Output Window text to the Immediate Window
			Debug.WriteLine($"Completed job: {job.DisplayName} | Total files: {job.Progress.FilesTotal:N0} | Bytes: {job.Progress.BytesTotal:N0}");

			autoResetEvent.Set();
		}
	}
}