using static Vanara.PInvoke.DOSvc;
using static Vanara.PInvoke.Ole32;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System;
using Vanara.PInvoke;
using System.IO;
using System.Threading.Tasks;

#nullable enable
namespace Vanara.Utilities
{
	public static class Downloader
	{
		public static async Task<byte[]> DownloadAsync(string url, string destPath, IProgress<DO_DOWNLOAD_STATUS>? progress = null, CancellationToken cancellationToken = default, bool computeHash = true, string? displayName = null, string? contentId = null)
		{
			File.Delete(destPath);

			IDOManager mgr = new();
			IDODownload dnld = mgr.CreateDownload();
			CoSetProxyBlanket(dnld, dwImpLevel: Rpc.RPC_C_IMP_LEVEL.RPC_C_IMP_LEVEL_IMPERSONATE).ThrowIfFailed();

			dnld.SetProperty(DODownloadProperty.DODownloadProperty_Uri, url);
			dnld.SetProperty(DODownloadProperty.DODownloadProperty_LocalPath, destPath);
			dnld.SetProperty(DODownloadProperty.DODownloadProperty_ForegroundPriority, true);
			DownloadStatusCallback callback = new(progress, cancellationToken);
			dnld.SetProperty(DODownloadProperty.DODownloadProperty_CallbackInterface, callback);
			if (!string.IsNullOrEmpty(displayName))
				dnld.SetProperty(DODownloadProperty.DODownloadProperty_DisplayName, displayName!);
			if (!string.IsNullOrEmpty(contentId))
				dnld.SetProperty(DODownloadProperty.DODownloadProperty_ContentId, contentId!);

			return await Task.Factory.StartNew(() =>
			{
				dnld.Start();
				cancellationToken.Register(dnld.Abort);
				if (cancellationToken.IsCancellationRequested)
				{
					dnld.Abort();
					return new byte[0];
				}
				if (callback.Wait())
				{
					dnld.Finalize();
					if (computeHash)
						return SHA256.Create().ComputeHash(File.ReadAllBytes(destPath));
				}
				return new byte[0];
			}, cancellationToken);
		}

		public static IEnumerable<IDODownload> EnumDownloads(DODownloadProperty? category = null) => new IDOManager().EnumDownloads(category);
	}

	[ComVisible(true), Guid("90AFD61C-C21C-4627-8A9A-E3268BC89051"), ClassInterface(ClassInterfaceType.None)]
	public class DownloadStatusCallback : IDODownloadStatusCallback
	{
		private readonly CancellationToken cancel;
		private readonly object lockObj = new();
		private readonly IProgress<DO_DOWNLOAD_STATUS>? progress;
		private DO_DOWNLOAD_STATUS currentStatus = default;

		public DownloadStatusCallback(IProgress<DO_DOWNLOAD_STATUS>? progress, CancellationToken cancellationToken)
		{
			this.progress = progress;
			cancel = cancellationToken;
		}

		public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(5);

		public bool Wait()
		{
			lock (lockObj)
			{
				bool transferChange = false;
				ulong? initialTransferAmount = null;
				while (!cancel.IsCancellationRequested)
				{
					if (!transferChange)
					{
						if (cancel.WaitHandle.WaitOne(Timeout) == false)
							throw new TimeoutException();
					}
					else
					{
						cancel.WaitHandle.WaitOne();
					}

					if (cancel.IsCancellationRequested)
						return false;

					if (currentStatus.Error.Failed)
						throw currentStatus.Error.GetException()!;

					switch (currentStatus.State)
					{
						case DODownloadState.DODownloadState_Created:
						case DODownloadState.DODownloadState_Paused:
							break;

						case DODownloadState.DODownloadState_Transferring:
							if (currentStatus.BytesTransferred > 0 || currentStatus.BytesTotal > 0)
								progress?.Report(currentStatus);
							if (!initialTransferAmount.HasValue)
								initialTransferAmount = currentStatus.BytesTransferred;
							else if (currentStatus.BytesTransferred != initialTransferAmount.Value)
								transferChange = true;
							break;

						case DODownloadState.DODownloadState_Transferred:
						case DODownloadState.DODownloadState_Finalized:
							if (currentStatus.BytesTransferred > 0 || currentStatus.BytesTotal > 0)
								progress?.Report(currentStatus);
							return true;

						case DODownloadState.DODownloadState_Aborted:
							return false;
					}
				}

				return false;
			}
		}

		HRESULT IDODownloadStatusCallback.OnStatusChange(IDODownload download, in DO_DOWNLOAD_STATUS status)
		{
			lock (lockObj)
				currentStatus = status;
			progress?.Report(currentStatus);
			return HRESULT.S_OK;
		}
	}
}