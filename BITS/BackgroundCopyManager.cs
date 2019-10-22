using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.BITS;

namespace Vanara.IO
{
	/// <summary>
	/// Use the BackgroundCopyManager to create transfer jobs, retrieve an enumerator object that contains the jobs in the queue, and to
	/// retrieve individual jobs from the queue.
	/// </summary>
	public static partial class BackgroundCopyManager
	{
		private static readonly ComReleaser<IBackgroundCopyManager> ciMgr = ComReleaserFactory.Create(new IBackgroundCopyManager());
		private static Version ver;

		/// <summary>Gets the list of currently queued jobs for all users.</summary>
		public static BackgroundCopyJobCollection Jobs { get; } = new BackgroundCopyJobCollection();

		/// <summary>Retrieves the running version of BITS.</summary>
		public static Version Version
		{
			get
			{
				try { return ver ?? (ver = GetVer()); }
				catch { return new Version(); }

				static Version GetVer()
				{
					var fi = System.Diagnostics.FileVersionInfo.GetVersionInfo(Environment.ExpandEnvironmentVariables(@"%WinDir%\Sysnative\qmgr.dll"));
					return $"{fi.FileMajorPart}.{fi.FileMinorPart}" switch
					{
						"7.8" => new Version(10, 1),
						"7.7" => new Version(5, 0),
						"7.5" => new Version(4, 0),
						"7.0" => new Version(3, 0),
						"6.7" => new Version(2, 5),
						"6.6" => new Version(2, 0),
						"6.5" => new Version(1, 5),
						"6.2" => new Version(1, 2),
						_ => new Version(1, 0),
					};
				}
			}
		}

		private static IBackgroundCopyManager IMgr => ciMgr.Item;

		/// <summary>Copies an existing file to a new file using BITS. Overwriting a file of the same name is not allowed.</summary>
		/// <param name="sourceFileName">The file to copy.</param>
		/// <param name="destFileName">The name of the destination file.</param>
		public static void Copy(string sourceFileName, string destFileName) => CopyTemplate(destFileName, new CancellationToken(false), null, f => f.Add(sourceFileName, destFileName));

		/// <summary>Copies an existing file to a new file using BITS. Overwriting a file of the same name is not allowed.</summary>
		/// <param name="sourceFileName">The file to copy.</param>
		/// <param name="destFileName">The name of the destination file.</param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
		/// <param name="progress">An optional delegate that can be used to track the progress of the operation asynchronously.</param>
		/// <returns>A task that represents the asynchronous copy operation.</returns>
		/// <example>
		/// Below is an example of how to use this function with cancellation support and a progress delegate:
		/// <code title="Async background file copy">
		/// // Using a cancellation token allows the UI to respond to a cancellation request
		/// var cts = new CancellationTokenSource();
		/// // This progress delegate writes the status to the console, but it could also up the UI
		/// var prog = new Progress&lt;Tuple&lt;BackgroundCopyJobState, byte&gt;&gt;(t =&gt; Console.WriteLine($"{t.Item2}% : {t.Item1}"));
		/// // This optionally tells the copy routine to cancel if it takes longer than 2 seconds.
		/// // You don't need this and can rely on other user cancellation methods.
		/// cts.CancelAfter(2000);
		/// // This is the copy routine.
		/// // 'src' is the source file path.
		/// // 'dest' is the destination file path.
		/// BackgroundCopyManager.CopyAsync(src, dest, cts.Token, prog);
		/// </code>
		/// </example>
		public static async Task CopyAsync(string sourceFileName, string destFileName, CancellationToken cancellationToken, IProgress<Tuple<BackgroundCopyJobState, byte>> progress)
		{
#if NET40
			await TaskEx.Run(() => CopyTemplate(destFileName, cancellationToken, (s, p) => progress?.Report(new Tuple<BackgroundCopyJobState, byte>(s,p)), f => f.Add(sourceFileName, destFileName)), cancellationToken);
#else
			await Task.Run(() => CopyTemplate(destFileName, cancellationToken, (s, p) => progress?.Report(new Tuple<BackgroundCopyJobState, byte>(s, p)), f => f.Add(sourceFileName, destFileName)), cancellationToken);
#endif
			cancellationToken.ThrowIfCancellationRequested();
		}

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

		private static void CopyTemplate(string destFileName, CancellationToken ct, Action<BackgroundCopyJobState, byte> report, Action<BackgroundCopyFileCollection> add)
		{
			var type = (Uri.TryCreate(destFileName, UriKind.Absolute, out var uri) && !uri.IsFile) ? BackgroundCopyJobType.Upload : BackgroundCopyJobType.Download;
			using var job = Jobs.Add("Temp" + Guid.NewGuid().ToString(), "", type);
			using var evt = new ManualResetEventSlim(false);
			BackgroundCopyException err = null;
			job.Completed += (s, e) => { ReportProgress(BackgroundCopyJobState.Transferred); job.Complete(); evt.Set(); };
			job.Error += (s, e) => { err = job.LastError; job.Cancel(); evt.Set(); };
			job.FileTransferred += (s, e) => ReportProgress(job.State);
			job.FileRangesTransferred += (s, e) => ReportProgress(job.State);
			add(job.Files);
			job.Resume();
			evt.Wait(ct);
			if (ct.IsCancellationRequested)
			{
				job.Cancel();
				throw new OperationCanceledException();
			}
			if (err != null)
				throw err;

			void ReportProgress(BackgroundCopyJobState state)
			{
				report?.Invoke(state, job.Progress.PercentComplete);
			}
		}
	}
}