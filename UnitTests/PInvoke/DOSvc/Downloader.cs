using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Vanara.PInvoke;
using static Vanara.PInvoke.DOSvc;
using static Vanara.PInvoke.Ole32;

namespace Vanara.Utilities
{
	public static class Downloader
	{
		/// <summary>Downloads the asynchronous.</summary>
		/// <param name="url">The remote URI path of the resource to download.</param>
		/// <param name="destPath">The local path name to save the download file. If the path does not exist, Delivery Optimization will attempt to create it under
		/// the caller's privileges.</param>
		/// <param name="computeHash">if set to <see langword="true" /> [compute hash].</param>
		/// <param name="displayName">Optional. Use this property to set the download display name.</param>
		/// <param name="foregroundPriority">Optional. Use this property to set or get the current download priority. <see langword="true" /> value will bring the download to
		/// the foreground with higher priority. The default is background priority.</param>
		/// <param name="ranges">Optional. An array of <c>DO_DOWNLOAD_RANGE</c> structures (to download only specific ranges of the file). Pass <see langword="null" /> to download the entire file.</param>
		/// <param name="progress">Optional. A <see cref="IProgress{T}" /> instance to receive status information.</param>
		/// <param name="timeout">Optional. A timeout for the download. If the timeout expires, the download will be aborted.</param>
		/// <param name="cancellationToken">Optional. A cancellation token.</param>
		/// <returns>
		/// If <paramref name="computeHash" /> is <see langword="true" />, a <see cref="byte" /> array with a SHA256 hash of the resulting file.
		/// </returns>
		public static Task<byte[]> DownloadAsync(string url, string destPath, bool computeHash = true, string? displayName = null,
			bool foregroundPriority = false, DO_DOWNLOAD_RANGE[]? ranges = null, IProgress<DO_DOWNLOAD_STATUS>? progress = null,
			TimeSpan? timeout = null, CancellationToken cancellationToken = default)
		{
			// Get interfaces and set security
			CoInitializeSecurity(PSECURITY_DESCRIPTOR.NULL, -1, null, default, Rpc.RPC_C_AUTHN_LEVEL.RPC_C_AUTHN_LEVEL_DEFAULT,
				Rpc.RPC_C_IMP_LEVEL.RPC_C_IMP_LEVEL_IMPERSONATE, dwCapabilities: EOLE_AUTHENTICATION_CAPABILITIES.EOAC_STATIC_CLOAKING);
			IDOManager mgr = new();
			IDODownload dnld = mgr.CreateDownload();
			CoSetProxyBlanket(dnld, dwImpLevel: Rpc.RPC_C_IMP_LEVEL.RPC_C_IMP_LEVEL_IMPERSONATE).ThrowIfFailed();

			// Create a task completion source
			TaskCompletionSource<byte[]> tcs = new();

			// Set properties
			DownloadStatusCallback callback = new(Callback_StatusChange);
			dnld.SetProperty(DODownloadProperty.DODownloadProperty_CallbackInterface, callback);
			if (!string.IsNullOrEmpty(displayName))
				dnld.SetProperty(DODownloadProperty.DODownloadProperty_DisplayName, displayName!);
			if (foregroundPriority)
				dnld.SetProperty(DODownloadProperty.DODownloadProperty_ForegroundPriority, true);
			if (timeout.HasValue)
				dnld.SetProperty(DODownloadProperty.DODownloadProperty_NoProgressTimeoutSeconds, (uint)timeout.Value.TotalSeconds);
			dnld.SetProperty(DODownloadProperty.DODownloadProperty_Uri, url);
			dnld.SetProperty(DODownloadProperty.DODownloadProperty_LocalPath, destPath);

			// Start download
			cancellationToken.Register(() => { dnld.Abort(); tcs.TrySetCanceled(cancellationToken); }, false);
			dnld.Start(ranges);

			// Wait for completion or failure
			return tcs.Task;

			// Process status change
			void Callback_StatusChange(DO_DOWNLOAD_STATUS currentStatus)
			{
				if (currentStatus.Error.Failed)
				{
					tcs.TrySetException(currentStatus.Error.GetException()!);
					return;
				}
				Report();
				switch (currentStatus.State)
				{
					case DODownloadState.DODownloadState_Transferred:
						dnld.Finalize();
						tcs.TrySetResult(computeHash && File.Exists(destPath) ? SHA256.Create().ComputeHash(File.ReadAllBytes(destPath)) : []);
						break;

					case DODownloadState.DODownloadState_Aborted:
					case DODownloadState.DODownloadState_Transferring:
					case DODownloadState.DODownloadState_Created:
					case DODownloadState.DODownloadState_Paused:
					case DODownloadState.DODownloadState_Finalized:
						break;
				}

				void Report() { if (currentStatus.BytesTransferred > 0 || currentStatus.BytesTotal > 0) progress?.Report(currentStatus); } 
			}
		}

		/// <summary>Enumerates the existing downloads.</summary>
		/// <param name="category">The property name to be used as a category to enumerate. Passing <see langword="null"/> will retrieve all existing downloads</param>
		/// <returns>An enumeration of the existing downloads.</returns>
		public static IEnumerable<IDODownload> EnumDownloads(DODownloadProperty? category = null) => new IDOManager().EnumDownloads(category);

		[ComVisible(true), Guid("90AFD61C-C21C-4627-8A9A-E3268BC89051")]
		internal class DownloadStatusCallback(Action<DO_DOWNLOAD_STATUS>? StatusChange) : IDODownloadStatusCallback
		{
			HRESULT IDODownloadStatusCallback.OnStatusChange(IDODownload download, in DO_DOWNLOAD_STATUS status)
			{
				StatusChange?.Invoke(status);
				return HRESULT.S_OK;
			}
		}
	}
}