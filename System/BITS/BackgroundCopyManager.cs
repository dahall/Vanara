using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
#if !(NET20 || NET35 || NET40)
using System.Threading;
using System.Threading.Tasks;
#endif
using Vanara.PInvoke;
using static Vanara.PInvoke.BITS;

namespace Vanara.IO
{
	/// <summary>
	/// Use the BackgroundCopyManager to create transfer jobs, retrieve an enumerator object that contains the jobs in the queue, and to retrieve individual jobs
	/// from the queue.
	/// </summary>
	public static partial class BackgroundCopyManager
	{
		private static Version ver;

		/// <summary>Initializes a new instance of the <see cref="BackgroundCopyManager"/> class.</summary>
		static BackgroundCopyManager()
		{
			IMgr = new IBackgroundCopyManager();
			Jobs = new BackgroundCopyJobCollection();
		}

		/// <summary>Gets the list of currently queued jobs for all users.</summary>
		public static BackgroundCopyJobCollection Jobs { get; private set; }

		/// <summary>Retrieves the running version of BITS.</summary>
		public static Version Version
		{
			get
			{
				try { return ver ?? (ver = GetVer()); }
				catch { return new Version(); }

				Version GetVer()
				{
					var fi = System.Diagnostics.FileVersionInfo.GetVersionInfo(Environment.ExpandEnvironmentVariables(@"%WinDir%\Sysnative\qmgr.dll"));
					switch ($"{fi.FileMajorPart}.{fi.FileMinorPart}")
					{
						case "7.8": return new Version(10, 1);
						case "7.7": return new Version(5, 0);
						case "7.5": return new Version(4, 0);
						case "7.0": return new Version(3, 0);
						case "6.7": return new Version(2, 5);
						case "6.6": return new Version(2, 0);
						case "6.5": return new Version(1, 5);
						case "6.2": return new Version(1, 2);
						default: return new Version(1, 0);
					}
				}
			}
		}

		/// <summary>Copies an existing file to a new file using BITS. Overwriting a file of the same name is not allowed.</summary>
		/// <param name="sourceFileName">The file to copy.</param>
		/// <param name="destFileName">The name of the destination file.</param>
		public static void Copy(string sourceFileName, string destFileName)
		{
			CopyTemplate(sourceFileName, destFileName, () => false, System.Threading.Thread.Sleep, null, f => f.Add(sourceFileName, destFileName));
		}

#if !(NET20 || NET35 || NET40)

		/// <summary>Copies an existing file to a new file using BITS. Overwriting a file of the same name is not allowed.</summary>
		/// <param name="sourceFileName">The file to copy.</param>
		/// <param name="destFileName">The name of the destination file.</param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
		/// <param name="progress">An optional delegate that can be used to track the progress of the operation asynchronously.</param>
		/// <returns>A task that represents the asynchronous copy operation.</returns>
		public static async Task CopyAsync(string sourceFileName, string destFileName, CancellationToken cancellationToken, IProgress<Tuple<BackgroundCopyJobState, byte>> progress)
		{
			await Task.Run(() => CopyTemplate(sourceFileName, destFileName, () => cancellationToken.IsCancellationRequested,
				Thread.Sleep, (s, p) => progress?.Report(new Tuple<BackgroundCopyJobState, byte>(s,p)), f => f.Add(sourceFileName, destFileName)), cancellationToken);
			cancellationToken.ThrowIfCancellationRequested();
		}

#endif

		private static IBackgroundCopyManager IMgr { get; set; }

		internal static IBackgroundCopyJob CreateJob(string displayName, BG_JOB_TYPE jobType = BG_JOB_TYPE.BG_JOB_TYPE_DOWNLOAD)
		{
			try
			{
				IMgr.CreateJob(displayName, jobType, out var newJobID, out var newJob);
				return newJob;
			}
			catch (COMException cex)
			{
				HandleCOMException(cex);
			}
			return null;
		}

		internal static IEnumBackgroundCopyJobs EnumJobs(BG_JOB_ENUM type = BG_JOB_ENUM.BG_JOB_ENUM_ALL_USERS) => IMgr.EnumJobs(type);

		internal static string GetErrorMessage(HRESULT hResult)
		{
			try
			{
				return IMgr.GetErrorDescription(hResult, (uint)((short)System.Globalization.CultureInfo.CurrentCulture.LCID));
			}
			catch (COMException)
			{
				return null;
			}
		}

		internal static IBackgroundCopyJob GetJob(Guid jobId)
		{
			try
			{
				return IMgr.GetJob(jobId);
			}
			catch (COMException cex)
			{
				if ((uint)cex.ErrorCode != 0x80200001)
					throw new BackgroundCopyException(cex);
			}
			return null;
		}

		internal static void HandleCOMException(COMException cex) => throw new BackgroundCopyException(cex);

		/// <summary>Checks if the current user has administrator rights.</summary>
		internal static bool IsCurrentUserAdministrator()
		{
			var wp = new WindowsPrincipal(WindowsIdentity.GetCurrent());
			return wp.IsInRole(WindowsBuiltInRole.Administrator);
		}

		private static void CopyTemplate(string sourceFileName, string destFileName, Func<bool> shouldCancel, Action<int> delay, Action<BackgroundCopyJobState, byte> report, Action<BackgroundCopyFileCollection> add)
		{
			var type = (Uri.TryCreate(destFileName, UriKind.Absolute, out var uri) && !uri.IsFile) ? BackgroundCopyJobType.Upload : BackgroundCopyJobType.Download;
			using (var job = Jobs.Add("Temp" + Guid.NewGuid().ToString(), "", type))
			{
				job.DisableNotifications = true;
				add(job.Files);
				BackgroundCopyJobState state = BackgroundCopyJobState.Connecting;
				job.Resume();
				do
				{
					switch (state = job.State)
					{
						case BackgroundCopyJobState.Queued:
						case BackgroundCopyJobState.Connecting:
						case BackgroundCopyJobState.Transferring:
						case BackgroundCopyJobState.Suspended:
							ReportProgress();
							break;
						case BackgroundCopyJobState.Error:
						case BackgroundCopyJobState.TransientError:
							throw job.LastError;
						case BackgroundCopyJobState.Transferred:
							ReportProgress();
							job.Complete();
							return;
						case BackgroundCopyJobState.Acknowledged:
						case BackgroundCopyJobState.Cancelled:
							return;
						default:
							throw new InvalidOperationException("Unknown job state");
					}
					if (shouldCancel())
					{
						job.Cancel();
						break;
					}
					delay(1000);

					void ReportProgress()
					{
						report?.Invoke(state, job.Progress.PercentComplete);
					}

				} while (state != BackgroundCopyJobState.Transferred && state != BackgroundCopyJobState.Error && state != BackgroundCopyJobState.TransientError);
			}
		}
	}
}