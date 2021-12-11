using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Vanara.Extensions;
using static Vanara.PInvoke.BITS;

namespace Vanara.IO
{
	/// <summary>
	/// Provides job-related progress information, such as the number of bytes and files transferred. For upload jobs, the progress applies
	/// to the upload file, not the reply file.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct BackgroundCopyJobProgress
	{
		internal BG_JOB_PROGRESS prog;

		/// <summary>
		/// <para>
		/// Total number of bytes to transfer for all files in the job. If the value UInt64.MaxValue, the total size of all files in the job
		/// has not been determined. BITS does not set this value if it cannot determine the size of one of the files. For example, if the
		/// specified file or server does not exist, BITS cannot determine the size of the file.
		/// </para>
		/// <para>
		/// If you are downloading ranges from the file, <c>BytesTotal</c> includes the total number of bytes you want to download from the file.
		/// </para>
		/// </summary>
		public ulong BytesTotal { get => prog.BytesTotal; set => prog.BytesTotal = value; }

		/// <summary>Number of bytes transferred.</summary>
		public ulong BytesTransferred { get => prog.BytesTransferred; set => prog.BytesTransferred = value; }

		/// <summary>Total number of files to transfer for this job.</summary>
		public uint FilesTotal { get => prog.FilesTotal; set => prog.FilesTotal = value; }

		/// <summary>Number of files transferred.</summary>
		public uint FilesTransferred { get => prog.FilesTransferred; set => prog.FilesTransferred = value; }

		/// <summary>Gets the percent of total bytes transferred represented as a number between 0 and 100.</summary>
		public byte PercentComplete => (byte)(BytesTotal == 0 ? 0f : BytesTransferred * 100f / BytesTotal);

		internal BackgroundCopyJobProgress(BG_JOB_PROGRESS p) => prog = p;

		/// <summary>Performs an implicit conversion from <see cref="BG_JOB_PROGRESS"/> to <see cref="BackgroundCopyJobProgress"/>.</summary>
		/// <param name="p">The BG_JOB_PROGRESS instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator BackgroundCopyJobProgress(BG_JOB_PROGRESS p) => new(p);
	}

	/// <summary>Provides progress information related to the reply portion of an upload-reply job.</summary>
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct BackgroundCopyJobReplyProgress
	{
		internal BG_JOB_REPLY_PROGRESS prog;

		/// <summary>Size of the file in bytes. The value is <c>UInt64.MaxValue</c> if the reply has not begun.</summary>
		public ulong BytesTotal { get => prog.BytesTotal; set => prog.BytesTotal = value; }

		/// <summary>Number of bytes transferred.</summary>
		public ulong BytesTransferred { get => prog.BytesTransferred; set => prog.BytesTransferred = value; }

		internal BackgroundCopyJobReplyProgress(BG_JOB_REPLY_PROGRESS p) => prog = p;

		/// <summary>Performs an implicit conversion from <see cref="BG_JOB_REPLY_PROGRESS"/> to <see cref="BackgroundCopyJobReplyProgress"/>.</summary>
		/// <param name="p">The BG_JOB_REPLY_PROGRESS instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator BackgroundCopyJobReplyProgress(BG_JOB_REPLY_PROGRESS p) => new(p);
	}

	/// <summary>Used by <see cref="BackgroundCopyJob.FileRangesTransferred"/> events.</summary>
	public class BackgroundCopyFileRangesTransferredEventArgs : BackgroundCopyFileTransferredEventArgs
	{
		internal BackgroundCopyFileRangesTransferredEventArgs(BackgroundCopyJob job, IBackgroundCopyFile file, BG_FILE_RANGE[] ranges) : base(job, file) => Ranges = Array.ConvertAll(ranges, r => (BackgroundCopyFileRange)r);

		/// <summary>
		/// An array of the files ranges that have transferred since the last call to FileRangesTransferred or the last call to the
		/// RequestFileRanges method.
		/// </summary>
		public BackgroundCopyFileRange[] Ranges { get; private set; }
	}

	/// <summary>Used by <see cref="BackgroundCopyJob.FileTransferred"/> events.</summary>
	public class BackgroundCopyFileTransferredEventArgs : BackgroundCopyJobEventArgs
	{
		internal BackgroundCopyFileTransferredEventArgs(BackgroundCopyJob job, IBackgroundCopyFile pFile) : base(job) => FileInfo = new BackgroundCopyFileInfo(pFile);

		/// <summary>A BackgroundCopyFileInfo object that contains information about the file.</summary>
		public BackgroundCopyFileInfo FileInfo { get; private set; }
	}

	/// <summary>A job in the Background Copy Service (BITS)</summary>
	/// <example>
	/// Below is an example of how to use a job to copy multiple files in the background with progress reporting:
	/// <code title="Using BITS jobs">// ===== Create a download job (default) =================
	/// using var job = BackgroundCopyManager.Jobs.Add("Download directory");
	/// // Create an event to signal completion
	/// var evt = new AutoResetEvent(false);
	/// // Set properties on the job
	/// job.Credentials.Add(BackgroundCopyJobCredentialScheme.Digest, BackgroundCopyJobCredentialTarget.Proxy, "user", "mypwd");
	/// job.CustomHeaders = new System.Net.WebHeaderCollection() { "A1:Test", "A2:Prova" };
	/// job.MinimumNotificationInterval = TimeSpan.FromSeconds(1);
	/// // Set event handlers for job
	/// job.Completed += (s, e) =&gt; { System.Diagnostics.Debug.WriteLine("Job completed."); job.Complete(); evt.Set(); };
	/// job.Error += (s, e) =&gt; throw job.LastError;
	/// job.FileTransferred += (s, e) =&gt; System.Diagnostics.Debug.WriteLine($"{e.FileInfo.LocalFilePath} of size {e.FileInfo.BytesTransferred} bytes was transferred.");
	/// // Add download file information
	/// // You can optionally add files individually using job.Files.Add()
	/// job.Files.AddRange(@"https://server/temp/", @"D:\", new[] { "file.mp4", "file.exe", "file.txt" });
	/// // Start (resume) the job.
	/// job.Resume();
	/// // Wait for the completion event for an appropriate amount of time
	/// if (!evt.WaitOne(20000))
	///     throw new InvalidOperationException();</code></example>
	public class BackgroundCopyJob : IDisposable
	{
		internal static readonly TimeSpan DEFAULT_RETRY_DELAY = TimeSpan.FromSeconds(600); //10 minutes (600 seconds)
		internal static readonly TimeSpan DEFAULT_RETRY_PERIOD = TimeSpan.FromSeconds(1209600); //20160 minutes (1209600 seconds)
		internal static readonly TimeSpan DEFAULT_TIMEOUT = TimeSpan.FromSeconds(7776000); // 7776000 seconds
		internal static readonly Version CopyCallback2 = new(3, 0);
		internal static readonly Version CopyCallback3 = new(10, 1);

		private IBackgroundCopyJob m_ijob;
		private Notifier m_notifier;

		internal BackgroundCopyJob(IBackgroundCopyJob ijob)
		{
			m_ijob = ijob ?? throw new ArgumentNullException(nameof(ijob));
			m_notifier = new Notifier(this);
			m_ijob.SetNotifyInterface(m_notifier);
			var bitsVer = BackgroundCopyManager.Version;
			NotifyFlags = bitsVer switch
			{
				var v when v >= CopyCallback3 => BG_NOTIFY.BG_NOTIFY_FILE_RANGES_TRANSFERRED | BG_NOTIFY.BG_NOTIFY_FILE_TRANSFERRED | BG_NOTIFY.BG_NOTIFY_JOB_ERROR | BG_NOTIFY.BG_NOTIFY_JOB_MODIFICATION | BG_NOTIFY.BG_NOTIFY_JOB_TRANSFERRED,
				var v when v >= CopyCallback2 => BG_NOTIFY.BG_NOTIFY_FILE_TRANSFERRED | BG_NOTIFY.BG_NOTIFY_JOB_ERROR | BG_NOTIFY.BG_NOTIFY_JOB_MODIFICATION | BG_NOTIFY.BG_NOTIFY_JOB_TRANSFERRED,
				_ => BG_NOTIFY.BG_NOTIFY_JOB_ERROR | BG_NOTIFY.BG_NOTIFY_JOB_MODIFICATION | BG_NOTIFY.BG_NOTIFY_JOB_TRANSFERRED,
			};
			Files = new BackgroundCopyFileCollection(m_ijob);
			Credentials = new BackgroundCopyJobCredentials(IJob2);
		}

		/// <summary>Occurs when all of the files in the job have been transferred.</summary>
		public event EventHandler<BackgroundCopyJobEventArgs> Completed;

		/// <summary>Fires when an error occurs.</summary>
		public event EventHandler<BackgroundCopyJobEventArgs> Error;

		/// <summary>Occurs when file ranges have been transferred.</summary>
		public event EventHandler<BackgroundCopyFileRangesTransferredEventArgs> FileRangesTransferred;

		/// <summary>Occurs when a file has been transferred.</summary>
		public event EventHandler<BackgroundCopyFileTransferredEventArgs> FileTransferred;

		/// <summary>
		/// Occurs when the job has been modified. For example, a property value changed, the state of the job changed, or progress is made
		/// transferring the files.
		/// </summary>
		public event EventHandler<BackgroundCopyJobEventArgs> Modified;

		/// <summary>Gets or sets the flags that identify the owner and ACL information to maintain when transferring a file using SMB.</summary>
		public BackgroundCopyACLFlags ACLFlags
		{
			get => RunAction(() => (BackgroundCopyACLFlags)IJob3.GetFileACLFlags(), BackgroundCopyACLFlags.None);
			set => RunAction(() => IJob3.SetFileACLFlags((BG_COPY_FILE)value));
		}

		/// <summary>Retrieves the client certificate from the job.</summary>
		public X509Certificate2 Certificate
		{
			get
			{
				IHttpOp.GetClientCertificate(out var loc, out var mstore, out var blob, out var subj);
				if (blob.IsInvalid) return null;
				var store = mstore switch
				{
					"MY" => "My",
					"ROOT" => "Root",
					"SPC" => "TrustedPublisher",
					_ => mstore,
				};
				var xstore = new X509Store(store, (StoreLocation)(loc + 1));
				xstore.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
				return xstore.Certificates.Find(X509FindType.FindBySubjectName, subj, false).OfType<X509Certificate2>().FirstOrDefault() ??
					new X509Certificate2(blob.ToArray<byte>(20));
			}
		}

		/// <summary>The credentials to use for a proxy or remote server user authentication request.</summary>
		public BackgroundCopyJobCredentials Credentials { get; private set; }

		/// <summary>Gets or sets one or more custom HTTP headers to include in HTTP requests.</summary>
		public System.Net.WebHeaderCollection CustomHeaders
		{
			get
			{
				var hdr = new System.Net.WebHeaderCollection();
				var str = RunAction(() => IHttpOp.GetCustomHeaders().ToString(), null);
				if (str is not null)
				{
					foreach (var s in str.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
						hdr.Add(s);
				}
				return hdr;
			}
			set => RunAction(() => IHttpOp.SetCustomHeaders(value.Count == 0 ? null : string.Join("\n", value.AllKeys.Select(k => $"{k}:{value[k]}").ToArray())));
		}

		/// <summary>Gets or sets the description of the job.</summary>
		[DefaultValue("")]
		public string Description
		{
			get => RunAction(() => m_ijob.GetDescription(), string.Empty);
			set => RunAction(() => m_ijob.SetDescription(value));
		}

		/// <summary>Gets or sets a value indicating whether notifications are disabled.</summary>
		/// <value><c>true</c> if notifications are disabled; otherwise, <c>false</c>.</value>
		[DefaultValue(false)]
		public bool DisableNotifications
		{
			get => NotifyFlags.IsFlagSet(BG_NOTIFY.BG_NOTIFY_DISABLE);
			set => NotifyFlags = NotifyFlags.SetFlags(BG_NOTIFY.BG_NOTIFY_DISABLE, value);
		}

		/// <summary>Gets or sets the display name of the job.</summary>
		public string DisplayName
		{
			get => RunAction(() => m_ijob.GetDisplayName(), string.Empty);
			set => RunAction(() => m_ijob.SetDisplayName(value));
		}

		/// <summary>
		/// Marks a BITS job as being willing to download content which does not support the normal HTTP requirements for BITS downloads:
		/// HEAD requests, the Content-Length header, and the Content-Range header. Downloading this type of content is opt-in, because BITS
		/// cannot pause and resume downloads jobs without that support. If a job with this property enabled is interrupted for any reason,
		/// such as a temporary loss of network connectivity or the system rebooting, BITS will restart the download from the beginning
		/// instead of resuming where it left off. BITS also cannot throttle bandwidth usage for dynamic downloads; BITS will not perform
		/// unthrottled transfers for any job that does not have BG_JOB_PRIORITY_FOREGROUND assigned, so you should typically set that
		/// priority every time you use set a job as allowing dynamic content.
		/// <para>
		/// This property is only supported for BG_JOB_TYPE_DOWNLOAD jobs. It is not supported for downloads that use FILE_RANGES. This
		/// property may only be set prior to the first time Resume is called on a job.
		/// </para>
		/// </summary>
		[DefaultValue(false)]
		public bool DynamicContent
		{
			get => (bool)GetProperty(BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_DYNAMIC_CONTENT);
			set => SetProperty(BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_DYNAMIC_CONTENT, value);
		}

		/// <summary>Gets the number of errors that have occurred in this job.</summary>
		public int ErrorCount => RunAction(() => (int)m_ijob.GetErrorCount());

		/// <summary>Manages the files that are a part of this job.</summary>
		public BackgroundCopyFileCollection Files { get; private set; }

		/// <summary>
		/// Marks a BITS job as not requiring strong reliability guarantees. Enabling this property will cause BITS to avoid persisting
		/// information about normal job progress, which BITS normally does periodically. In the event of an unexpected shutdown, such as a
		/// power loss, during a transfer, this will cause BITS to lose progress and restart the job from the beginning instead of resuming
		/// from where it left off as usual. However, it will also reduce the number of disk writes BITS makes over the course of a job’s
		/// lifetime, which can improve performance for smaller jobs.
		/// <para>
		/// This property also causes BITS to download directly into the destination file, instead of downloading to a temporary file and
		/// moving the temporary file to the final destination once the transfer is complete.This means that BITS will not clean up any
		/// partially downloaded content if a job is canceled or encounters a fatal error condition; the BITS caller is responsible for
		/// cleaning up the destination file, if it gets created.However, it will also slightly reduce disk overhead.
		/// </para>
		/// <para>
		/// This property is only recommended for scenarios which involve high numbers of small jobs(under 1MB) and which do not require
		/// reliability to power loss or other unexpected shutdown events.The performance savings are not generally significant for small
		/// numbers of jobs or for larger jobs.
		/// </para>
		/// <para>
		/// This property is only supported for BG_JOB_TYPE_DOWNLOAD jobs. This property may only be set prior to adding any files to a job.
		/// </para>
		/// </summary>
		[DefaultValue(false)]
		public bool HighPerformance
		{
			get => (bool)GetProperty(BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_HIGH_PERFORMANCE);
			set => SetProperty(BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_HIGH_PERFORMANCE, value);
		}

		/// <summary>Gets or sets the default HTTP method used for a BITS transfer.</summary>
		/// <value>The HTTP method name.</value>
		/// <remarks>
		/// <para>
		/// BITS allows you, as the developer, to choose an HTTP method other than the default method. This increases BITS' ability to
		/// interact with servers that don't adhere to the normal BITS requirements for HTTP servers. Bear the following in mind when you
		/// choose a different HTTP method from the default one.
		/// </para>
		/// <list type="bullet">
		/// <item>BITS automatically changes the job priority to BG_JOB_PRIORITY_FOREGROUND, and prevents that priority from being changed.</item>
		/// <item>
		/// An error that would ordinarily be resumable (such as loss of connectivity) transitions the job to an ERROR state. You, as the
		/// developer, can restart the job by calling IBackgroundCopyJob::Resume, and the job will be restarted from the beginning. See Life
		/// Cycle of a BITS Job for more information on BITS job states.
		/// </item>
		/// <item>BITS doesn’t allow DYNAMIC_CONTENT nor ON_DEMAND_MODE jobs with <c>SetHttpMethod</c>.</item>
		/// </list>
		/// <para>
		/// <c>SetHttpMethod</c> does nothing if the method name that you pass matches the default HTTP method for the transfer type. For
		/// example, if you set a download job method to "GET" (the default), then the job priority won't be changed. The HTTP method must
		/// be set before the first call to IBackgroundCopyJob::Resume that starts the job.
		/// </para>
		/// </remarks>
		[DefaultValue("GET")]
		public string HttpMethod
		{
			get => RunAction(() => IHttpOp2.GetHttpMethod());
			set => RunAction(() => IHttpOp2.SetHttpMethod(value));
		}

		/// <summary>Gets the job identifier.</summary>
		public Guid ID => RunAction(() => m_ijob.GetId(), Guid.Empty);

		/// <summary>Gets the type of job, such as download.</summary>
		public BackgroundCopyJobType JobType => RunAction(() => (BackgroundCopyJobType)m_ijob.GetType(), BackgroundCopyJobType.Download);

		/// <summary>Gets the last exception that occurred in the job.</summary>
		public BackgroundCopyException LastError
		{
			get
			{
				var state = State;
				if (state != BackgroundCopyJobState.Error && state != BackgroundCopyJobState.TransientError)
					return null;
				var err = RunAction(() => m_ijob.GetError());
				return err is null ? null : new BackgroundCopyException(err);
			}
		}

		/// <summary>
		/// The ID for marking the maximum number of bytes a BITS job will be allowed to download in total. This property is intended for use
		/// with BITS_JOB_PROPERTY_DYNAMIC_CONTENT, where you may not be able to determine the size of the file to be downloaded ahead of
		/// time but would like to cap the total possible download size.
		/// <para>
		/// This property is only supported for BG_JOB_TYPE_DOWNLOAD jobs. This property may only be set prior to the first time Resume is
		/// called on a job.
		/// </para>
		/// </summary>
		[DefaultValue(0)]
		public ulong MaxDownloadSize
		{
			get => (ulong)GetProperty(BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_MAX_DOWNLOAD_SIZE);
			set => SetProperty(BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_MAX_DOWNLOAD_SIZE, value);
		}

		/// <summary>Sets the maximum time that BITS will spend transferring the files in the job.</summary>
		/// <value>
		/// Maximum time, in seconds, that BITS will spend transferring the files in the job. The default is 7,776,000 seconds (90 days).
		/// </value>
		[DefaultValue(typeof(TimeSpan), "90.00:00:00")]
		public TimeSpan MaximumDownloadTime
		{
			get => RunAction(() => TimeSpan.FromSeconds((int)IJob4.GetMaximumDownloadTime()), DEFAULT_TIMEOUT);
			set => RunAction(() => IJob4.SetMaximumDownloadTime((uint)value.TotalSeconds));
		}

		/// <summary>
		/// Used to control the timing of BITS JobNotification and FileRangesTransferred notifications. Enabling this property lets a user be
		/// notified at a different rate. This property may be changed while a transfer is ongoing; however, the new rate may not be applied
		/// immediately. The default value is 500 milliseconds.
		/// </summary>
		[DefaultValue(typeof(TimeSpan), "00:00:00")]
		public TimeSpan MinimumNotificationInterval
		{
			get => TimeSpan.FromMilliseconds((uint)GetProperty(BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_MINIMUM_NOTIFICATION_INTERVAL_MS));
			set => SetProperty(BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_MINIMUM_NOTIFICATION_INTERVAL_MS, (uint)value.TotalMilliseconds);
		}

		/// <summary>
		/// Gets or sets the minimum length of time, in seconds, that BITS waits after encountering a transient error before trying to
		/// transfer the file. The default retry delay is 600 seconds (10 minutes). The minimum retry delay that you can specify is 60
		/// seconds. If you specify a value less than 60 seconds, BITS changes the value to 60 seconds.
		/// </summary>
		[DefaultValue(typeof(TimeSpan), "00:10:00")]
		public TimeSpan MinimumRetryDelay
		{
			get => RunAction(() => TimeSpan.FromSeconds((int)m_ijob.GetMinimumRetryDelay()), DEFAULT_RETRY_DELAY);
			set => RunAction(() => m_ijob.SetMinimumRetryDelay((uint)value.TotalSeconds));
		}

		/// <summary>
		/// Gets or sets the length of time, in seconds, that BITS tries to transfer the file after the first transient error occurs. The
		/// default retry period is 1,209,600 seconds (14 days). Set the retry period to 0 to prevent retries and to force the job into the
		/// Error state for all errors.
		/// </summary>
		[DefaultValue(typeof(TimeSpan), "14.00:00:00")]
		public TimeSpan NoProgressTimeout
		{
			get => RunAction(() => TimeSpan.FromSeconds((int)m_ijob.GetNoProgressTimeout()), DEFAULT_RETRY_PERIOD);
			set => RunAction(() => m_ijob.SetNoProgressTimeout((uint)value.TotalSeconds));
		}

		/// <summary>
		/// Used to register a COM callback by CLSID to receive notifications about the progress and completion of a BITS job. The CLSID must
		/// refer to a class associated with a registered out-of-process COM server. It may also be set to GUID_NULL to clear a previously
		/// set notification CLSID.
		/// </summary>
		[DefaultValue(typeof(Guid), "00000000000000000000000000000000")]
		public Guid NotificationCLSID
		{
			get => (Guid)GetProperty(BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_NOTIFICATION_CLSID);
			set => SetProperty(BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_NOTIFICATION_CLSID, value);
		}

		/// <summary>
		/// Gets or sets the program to execute if the job enters the Error or Transferred state. BITS executes the program in the context of
		/// the user who called this method.
		/// </summary>
		[DefaultValue(null)]
		public string NotifyProgram
		{
			get
			{
				string p, a;
				try
				{
					IJob2.GetNotifyCmdLine(out p, out a);
				}
				catch
				{
					return string.Empty;
				}
				if (string.IsNullOrEmpty(a))
				{
					if (p is null)
						return string.Empty;
					else
						return p;
				}
				return string.Format("\"{0}\" {1}", p, a);
			}
			set
			{
				string p = value, a = string.Empty;
				if (string.IsNullOrEmpty(value))
					p = a = null;
				else
				{
					if (value[0] == '"')
					{
						var i = p.IndexOf('"', 1);
						if (i + 3 <= p.Length)
							a = p.Substring(i + 2);
						p = p.Substring(1, i - 1);
					}
					else
					{
						var i = p.IndexOf(' ');
						if (i + 2 <= p.Length)
							a = p.Substring(i + 1);
						p = p.Substring(0, i);
					}
				}
				RunAction(() => IJob2.SetNotifyCmdLine(p, a));
			}
		}

		/// <summary>
		/// The ID that is used to control whether a job is in On Demand mode. On Demand jobs allow the app to request particular ranges for
		/// a file download instead of downloading from the start to the end. The default value is FALSE; the job is not on-demand. Ranges
		/// are requested using the IBackgroundCopyFile6::RequestFileRanges method.
		/// <para>
		/// The requirements for a BITS_JOB_PROPERTY_ON_DEMAND_MODE job is that the transfer must be a BG_JOB_TYPE_DOWNLOAD job. The job must
		/// not be DYNAMIC and the server must be an HTTP or HTTPS server and the server requirements for range support must all be met.
		/// </para>
		/// </summary>
		[DefaultValue(false)]
		public bool OnDemand
		{
			get => (bool)GetProperty(BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_ON_DEMAND_MODE);
			set => SetProperty(BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_ON_DEMAND_MODE, value);
		}

		/// <summary>Retrieve the identity of the job's owner.</summary>
		public System.Security.Principal.SecurityIdentifier Owner => RunAction(() => new System.Security.Principal.SecurityIdentifier((string)m_ijob.GetOwner()));

		/// <summary>Gets the integrity level of the token of the owner that created or took ownership of the job.</summary>
		/// <value>Integrity level of the token of the owner that created or took ownership of the job.</value>
		[DefaultValue(8192)]
		public uint OwnerIntegrityLevel => RunAction(() => IJob4.GetOwnerIntegrityLevel());

		/// <summary>
		/// Gets a value that determines if the token of the owner was elevated at the time they created or took ownership of the job.
		/// </summary>
		/// <value>Is TRUE if the token of the owner was elevated at the time they created or took ownership of the job; otherwise, FALSE.</value>
		[DefaultValue(false)]
		public bool OwnerIsElevated => RunAction(() => IJob4.GetOwnerElevationState());

		/// <summary>
		/// Gets or sets the priority level for the job. The priority level determines when the job is processed relative to other jobs in
		/// the transfer queue.
		/// </summary>
		[DefaultValue(BackgroundCopyJobPriority.Normal)]
		public BackgroundCopyJobPriority Priority
		{
			get => RunAction(() => (BackgroundCopyJobPriority)m_ijob.GetPriority(), BackgroundCopyJobPriority.Normal);
			set => RunAction(() => m_ijob.SetPriority((BG_JOB_PRIORITY)value));
		}

		/// <summary>Gets the job-related progress information, such as the number of bytes and files transferred.</summary>
		public BackgroundCopyJobProgress Progress => RunAction(() => new BackgroundCopyJobProgress(m_ijob.GetProgress()), new BackgroundCopyJobProgress());

		/// <summary>
		/// Gets or sets the proxy information that the job uses to transfer the files. A <c>null</c> value represents the system default
		/// proxy settings.
		/// </summary>
		/// <exception cref="ArgumentException">
		/// The WebProxy.Credentials property value contains a value. Use the SetCredentials method instead.
		/// </exception>
		[DefaultValue(null)]
		public System.Net.WebProxy Proxy
		{
			get => RunAction(() =>
			{
				m_ijob.GetProxySettings(out var pUse, out var pList, out var byList);
				if (pUse == BG_JOB_PROXY_USAGE.BG_JOB_PROXY_USAGE_OVERRIDE)
					return new System.Net.WebProxy(pList.ToString()?.Split(' ').FirstOrDefault(), true, byList.ToString()?.Split(' '));
				else if (pUse == BG_JOB_PROXY_USAGE.BG_JOB_PROXY_USAGE_NO_PROXY)
					return new System.Net.WebProxy();
				return null;
			});
			set => RunAction(() =>
			{
				if (value is null)
					m_ijob.SetProxySettings(BG_JOB_PROXY_USAGE.BG_JOB_PROXY_USAGE_PRECONFIG, null, null);
				else if (string.IsNullOrEmpty(value.Address.AbsoluteUri))
					m_ijob.SetProxySettings(BG_JOB_PROXY_USAGE.BG_JOB_PROXY_USAGE_NO_PROXY, null, null);
				else
					m_ijob.SetProxySettings(BG_JOB_PROXY_USAGE.BG_JOB_PROXY_USAGE_OVERRIDE, value.Address.AbsoluteUri, string.Join(" ", value.BypassList));
				if (value.Credentials is not null)
					throw new ArgumentException("The set Proxy property does not support proxy credentials. Please use the SetCredentials method.");
			});
		}

		/// <summary>Gets an in-memory copy of the reply data from the server application.</summary>
		public byte[] ReplyData => RunAction(() =>
		{
			IJob2.GetReplyData(out var pdata, out var cRet);
			return (cRet > 0) ? pdata.ToArray<byte>((int)cRet) : new byte[0];
		}, new byte[0]);

		/// <summary>Gets or sets the name of the file that contains the reply data from the server application.</summary>
		[DefaultValue(null)]
		public string ReplyFileName
		{
			get => RunAction(() => IJob2.GetReplyFileName(), string.Empty);
			set => RunAction(() => IJob2.SetReplyFileName(value));
		}

		/// <summary>Gets progress information related to the transfer of the reply data from an upload-reply job.</summary>
		public BackgroundCopyJobReplyProgress ReplyProgress => RunAction(() => new BackgroundCopyJobReplyProgress(IJob2.GetReplyProgress()), new BackgroundCopyJobReplyProgress());

		/// <summary>
		/// Gets or sets the flags for HTTP that determine whether the certificate revocation list is checked and certain certificate errors
		/// are ignored, and the policy to use when a server redirects the HTTP request.
		/// </summary>
		[DefaultValue(BackgroundCopyJobSecurity.AllowSilentRedirect)]
		public BackgroundCopyJobSecurity SecurityOptions
		{
			get => RunAction(() => (BackgroundCopyJobSecurity)IHttpOp.GetSecurityFlags(), BackgroundCopyJobSecurity.AllowSilentRedirect);
			set => RunAction(() => IHttpOp.SetSecurityFlags((BG_HTTP_SECURITY)value));
		}

		/// <summary>Gets the current state of the job.</summary>
		public BackgroundCopyJobState State => RunAction(() => (BackgroundCopyJobState)m_ijob.GetState(), BackgroundCopyJobState.Error);

		/// <summary>
		/// Used to control transfer behavior over cellular and/or similar networks. This property may be changed while a transfer is ongoing
		/// – the new cost flags will take effect immediately.
		/// </summary>
		[DefaultValue(BackgroundCopyCost.TransferUnrestricted)]
		public BackgroundCopyCost TransferBehavior
		{
			get => (BackgroundCopyCost)GetProperty(BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_ID_COST_FLAGS);
			set => SetProperty(BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_ID_COST_FLAGS, value);
		}

		/// <summary>
		/// Marks a BITS job as being willing to include default credentials in requests to proxy servers. Enabling this property is
		/// equivalent to setting a WinHTTP security level of WINHTTP_AUTOLOGON_SECURITY_LEVEL_MEDIUM on the requests that BITS makes on the
		/// user’s behalf. The user BITS retrieves stored credentials from the is the same as the one it makes network requests on behalf of:
		/// BITS will normally use the job owner’s credentials, unless you have explicitly provided a network helper token, in which case
		/// BITS will use the network helper token’s credentials.
		/// <para>Only the BG_AUTH_TARGET_PROXY target is supported.</para>
		/// </summary>
		[DefaultValue(BackgroundCopyJobCredentialTarget.Undefined)]
		public BackgroundCopyJobCredentialTarget UseStoredCredentials
		{
			get => (BackgroundCopyJobCredentialTarget)(BG_AUTH_TARGET)GetProperty(BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_USE_STORED_CREDENTIALS);
			set => SetProperty(BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_USE_STORED_CREDENTIALS, value);
		}

		/// <summary>Gets the time the job was created.</summary>
		public DateTime CreationTime => Times.CreationTime.ToDateTime();

		/// <summary>Gets the time the job was last modified or bytes were transferred.</summary>
		public DateTime ModificationTime => Times.ModificationTime.ToDateTime();

		/// <summary>Gets the time the job entered the Transferred state.</summary>
		public DateTime TransferCompletionTime => Times.TransferCompletionTime.ToDateTime();

		private IBackgroundCopyJobHttpOptions IHttpOp => GetDerived<IBackgroundCopyJobHttpOptions>();

		private IBackgroundCopyJobHttpOptions2 IHttpOp2 => GetDerived<IBackgroundCopyJobHttpOptions2>();

		private IBackgroundCopyJobHttpOptions3 IHttpOp3 => GetDerived<IBackgroundCopyJobHttpOptions3>();

		private IBackgroundCopyJob2 IJob2 => GetDerived<IBackgroundCopyJob2>();

		private IBackgroundCopyJob3 IJob3 => GetDerived<IBackgroundCopyJob3>();

		private IBackgroundCopyJob4 IJob4 => GetDerived<IBackgroundCopyJob4>();

		private IBackgroundCopyJob5 IJob5 => GetDerived<IBackgroundCopyJob5>();

		private BG_NOTIFY NotifyFlags
		{
			get => RunAction(() => m_ijob.GetNotifyFlags(), (BG_NOTIFY)0);
			set => RunAction(() =>
			{
				var st = State;
				if (st != BackgroundCopyJobState.Acknowledged && st != BackgroundCopyJobState.Cancelled)
					m_ijob.SetNotifyFlags(value);
			});
		}

		private BG_JOB_TIMES Times => RunAction(() => m_ijob.GetTimes(), new BG_JOB_TIMES());

		/// <summary>
		/// Use the Cancel method to delete the job from the transfer queue and to remove related temporary files from the client (downloads)
		/// and server (uploads). You can cancel a job at any time; however, the job cannot be recovered after it is canceled.
		/// </summary>
		public void Cancel() => RunAction(() => m_ijob.Cancel());

		/// <summary>
		/// Use the RemoveCredentials method to remove credentials from use. The credentials must match an existing target and scheme pair
		/// that you specified using the IBackgroundCopyJob2::SetCredentials method. There is no method to retrieve the credentials you have set.
		/// </summary>
		public void ClearCredentials()
		{
			try { IJob2.RemoveCredentials(BG_AUTH_TARGET.BG_AUTH_TARGET_SERVER, BG_AUTH_SCHEME.BG_AUTH_SCHEME_BASIC); }
			catch (COMException) { }
			try { IJob2.RemoveCredentials(BG_AUTH_TARGET.BG_AUTH_TARGET_SERVER, BG_AUTH_SCHEME.BG_AUTH_SCHEME_NTLM); }
			catch (COMException) { }
		}

		/// <summary>Use the Complete method to end the job and save the transferred files on the client.</summary>
		public void Complete() => RunAction(() => m_ijob.Complete());

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => ID.GetHashCode();

		/// <summary>
		/// Sets the HTTP custom headers for this job to be write-only. Write-only headers cannot be read by BITS methods such as the <see
		/// cref="CustomHeaders"/> property.
		/// </summary>
		/// <remarks>
		/// Use this API when your BITS custom headers must include security information (such as an API token) that you don't want to be
		/// readable by other programs running on the same computer. The BITS process, of course, can still read these headers, and send
		/// them over the HTTP connection. Once the headers are set to write-only, that cannot be unset.
		/// </remarks>
		public void MakeCustomHeadersWriteOnly() => RunAction(() => IHttpOp3.MakeCustomHeadersWriteOnly());

		/// <summary>
		/// Use the ReplaceRemotePrefix method to replace the beginning text of all remote names in the download job with the given string.
		/// </summary>
		/// <param name="oldPrefix">
		/// String that identifies the text to replace in the remote name. The text must start at the beginning of the remote name.
		/// </param>
		/// <param name="newPrefix">String that contains the replacement text.</param>
		public void ReplaceRemotePrefix(string oldPrefix, string newPrefix) => RunAction(() => IJob3.ReplaceRemotePrefix(oldPrefix, newPrefix));

		/// <summary>Use the Resume method to activate a new job or restart a job that has been suspended.</summary>
		public void Resume() => RunAction(() => m_ijob.Resume());

		/// <summary>Specifies the identifier of the client certificate to use for client authentication in an HTTPS (SSL) request.</summary>
		/// <param name="store">The certificate store.</param>
		/// <param name="cert">The certificate.</param>
		public void SetCertificate(X509Store store, X509Certificate2 cert)
		{
			var loc = BG_CERT_STORE_LOCATION.BG_CERT_STORE_LOCATION_CURRENT_USER;
			switch (store.Location)
			{
				case StoreLocation.LocalMachine:
					loc = BG_CERT_STORE_LOCATION.BG_CERT_STORE_LOCATION_LOCAL_MACHINE;
					break;

				case StoreLocation.CurrentUser:
				default:
					break;
			}
			IHttpOp.SetClientCertificateByID(loc, store.Name, cert.GetCertHash());
		}

		/// <summary>
		/// Use the SetCredentials method to specify the credentials to use for a proxy or remote server user authentication request.
		/// </summary>
		/// <param name="cred">Identifies the user's credentials to use for user authentication.</param>
		/// <param name="target">Identifies the target for these credentials.</param>
		public void SetCredentials(System.Net.NetworkCredential cred, BackgroundCopyJobCredentialTarget target = BackgroundCopyJobCredentialTarget.Server)
		{
			var ac = new BG_AUTH_CREDENTIALS { Target = (BG_AUTH_TARGET)target };
			if (string.IsNullOrEmpty(cred.Domain))
			{
				if (!string.IsNullOrEmpty(cred.UserName))
				{
					ac.Scheme = BG_AUTH_SCHEME.BG_AUTH_SCHEME_BASIC;
					ac.Credentials.Basic.UserName = cred.UserName;
					ac.Credentials.Basic.Password = cred.Password;
				}
				else
					ac.Scheme = BG_AUTH_SCHEME.BG_AUTH_SCHEME_NTLM;
			}
			else
			{
				ac.Scheme = BG_AUTH_SCHEME.BG_AUTH_SCHEME_NTLM;
				ac.Credentials.Basic.UserName = string.Concat(cred.Domain, '\\', cred.UserName);
				ac.Credentials.Basic.Password = cred.Password;
			}
			RunAction(() => IJob2.SetCredentials(ref ac));
		}

		/// <summary>
		/// Server certificates are sent when an HTTPS connection is opened. Use this method to set a callback to be called to validate
		/// those server certificates.
		/// </summary>
		/// <param name="callback">
		/// An object that implements <see cref="IBackgroundCopyServerCertificateValidationCallback"/>. To remove the current callback
		/// interface pointer, set this parameter to <see langword="null"/>.
		/// </param>
		/// <remarks>
		/// <para>Use this method when you want to perform your own checks on the server certificate.</para>
		/// <para>Call this method only if you implement the <see cref="IBackgroundCopyServerCertificateValidationCallback"/> interface.</para>
		/// <para>
		/// The validation interface becomes invalid when your application terminates; BITS does not maintain a record of the validation
		/// interface. As a result, your application's initialization process should call <c>SetServerCertificateValidationInterface</c> on
		/// those existing jobs for which you want to receive certificate validation requests.
		/// </para>
		/// <para>
		/// If more than one application calls <c>SetServerCertificateValidationInterface</c> to set the notification interface for the job,
		/// the last application to call it is the one that will receive notifications. The other applications will not receive notifications.
		/// </para>
		/// <para>
		/// If any certificate errors are found during the OS validation of the certificate, then the connection is aborted, and the custom
		/// callback is never called. You can customize the OS validation logic with a call to
		/// IBackgroundCopyJobHttpOptions::SetSecurityFlags. For example, you can ignore expected certificate validation errors.
		/// </para>
		/// <para>
		/// If OS validation passes, then the <see cref="IBackgroundCopyServerCertificateValidationCallback.ValidateServerCertificate"/>
		/// method is called before completing the TLS handshake and before the HTTP request is sent.
		/// </para>
		/// <para>
		/// If your validation method declines the certificate, the job will transition to <c>BG_JOB_STATE_TRANSIENT_ERROR</c> with a job
		/// error context of <c>BG_ERROR_CONTEXT_SERVER_CERTIFICATE_CALLBACK</c> and the error <c>HRESULT</c> from your callback. If your
		/// callback couldn't be called (for example, because BITS needed to validate a server certificate after your program exited), then
		/// the job error code will be <c>BG_E_SERVER_CERT_VALIDATION_INTERFACE_REQUIRED</c>. When your application is next run, it can fix
		/// this error by setting the validation callback again and resuming the job.
		/// </para>
		/// </remarks>
		public void SetServerCertificateValidationInterface(IBackgroundCopyServerCertificateValidationCallback callback) =>
			RunAction(() => IHttpOp3.SetServerCertificateValidationInterface(callback));

		/// <summary>
		/// Use the Suspend method to suspend a job. New jobs, jobs that are in error, and jobs that have finished transferring files are
		/// automatically suspended.
		/// </summary>
		public void Suspend() => RunAction(() => m_ijob.Suspend());

		/// <summary>
		/// Use the TakeOwnership method to change ownership of the job to the current user. To take ownership of the job, the user must have
		/// administrator privileges on the client.
		/// </summary>
		public void TakeOwnership() => RunAction(() => m_ijob.TakeOwnership());

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => string.Concat($"Job: {DisplayName}", string.IsNullOrEmpty(Description) ? "" : $" - {Description}", $" ({ID})");

		/// <summary>Disposes of the BackgroundCopyJob object.</summary>
		void IDisposable.Dispose()
		{
			try
			{
				NotifyFlags = 0;
				m_ijob.SetNotifyInterface(null);
				if (State == BackgroundCopyJobState.Transferred)
					Complete();
				if (State != BackgroundCopyJobState.Acknowledged)
					Cancel();
			}
			catch { }
			Files = null;
			m_ijob = null;
			m_notifier = null;
		}

		/// <summary>Called when the job has completed.</summary>
		protected virtual void OnCompleted() => Completed?.Invoke(this, new BackgroundCopyJobEventArgs(this));

		/// <summary>Called when an error occurs.</summary>
		/// <param name="err">The error.</param>
		protected virtual void OnError(IBackgroundCopyError err) => Error?.Invoke(this, new BackgroundCopyJobEventArgs(this));

		/// <summary>Called when a file range has been transferred.</summary>
		/// <param name="file">The file being transferred.</param>
		/// <param name="ranges">The ranges transferred.</param>
		protected virtual void OnFileRangesTransferred(IBackgroundCopyFile file, BG_FILE_RANGE[] ranges) => FileRangesTransferred?.Invoke(this, new BackgroundCopyFileRangesTransferredEventArgs(this, file, ranges));

		/// <summary>Called when a file transfer is completed.</summary>
		/// <param name="pFile">The transferred file.</param>
		protected virtual void OnFileTransferred(IBackgroundCopyFile pFile) => FileTransferred?.Invoke(this, new BackgroundCopyFileTransferredEventArgs(this, pFile));

		/// <summary>Called when the job has been modified.</summary>
		protected virtual void OnModified() => Modified?.Invoke(this, new BackgroundCopyJobEventArgs(this));

		private T GetDerived<T>() where T : class
		{
			var ret = m_ijob as T;
			return ret ?? throw new PlatformNotSupportedException();
		}

		private object GetProperty(BITS_JOB_PROPERTY_ID id)
		{
			var value = RunAction(() => IJob5.GetProperty(id));
			return id switch
			{
				BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_MAX_DOWNLOAD_SIZE => value.Uint64,
				BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_ID_COST_FLAGS or BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_MINIMUM_NOTIFICATION_INTERVAL_MS => value.Dword,
				BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_NOTIFICATION_CLSID => value.ClsID,
				BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_DYNAMIC_CONTENT or BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_HIGH_PERFORMANCE or BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_ON_DEMAND_MODE => value.Enable,
				BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_USE_STORED_CREDENTIALS => value.Target,
				_ => throw new ArgumentOutOfRangeException(nameof(id)),
			};
		}

		private void HandleCOMException(COMException cex)
		{
			if (State == BackgroundCopyJobState.Error || State == BackgroundCopyJobState.TransientError)
			{
				OnError(m_ijob.GetError());
			}
			else
				throw new BackgroundCopyException(cex);
		}

		private void RunAction(Action action)
		{
			try { action(); }
			catch (COMException cex) { HandleCOMException(cex); }
		}

		private T RunAction<T>(Func<T> action, T def = default)
		{
			try { return action(); }
			catch (COMException cex) { HandleCOMException(cex); }
			return def;
		}

		private void SetProperty(BITS_JOB_PROPERTY_ID id, object value)
		{
			var str = new BITS_JOB_PROPERTY_VALUE();
			switch (id)
			{
				case BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_MAX_DOWNLOAD_SIZE:
					str.Uint64 = (ulong)value;
					break;

				case BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_ID_COST_FLAGS:
				case BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_MINIMUM_NOTIFICATION_INTERVAL_MS:
				case BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_USE_STORED_CREDENTIALS:
					str.Dword = (uint)value;
					break;

				case BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_NOTIFICATION_CLSID:
					str.ClsID = (Guid)value;
					break;

				case BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_DYNAMIC_CONTENT:
				case BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_HIGH_PERFORMANCE:
				case BITS_JOB_PROPERTY_ID.BITS_JOB_PROPERTY_ON_DEMAND_MODE:
					str.Enable = (bool)value;
					break;

				default:
					throw new ArgumentOutOfRangeException(nameof(id));
			}
			RunAction(() => IJob5.SetProperty(id, str));
		}

		[ComVisible(true)]
		internal class Notifier : IBackgroundCopyCallback, IBackgroundCopyCallback2, IBackgroundCopyCallback3
		{
			private readonly BackgroundCopyJob parent;

			public Notifier(BackgroundCopyJob job) => parent = job;

			private Notifier()
			{
			}

			public void FileRangesTransferred(IBackgroundCopyJob job, IBackgroundCopyFile file, uint rangeCount, BG_FILE_RANGE[] ranges) => parent.OnFileRangesTransferred(file, ranges);

			public void FileTransferred(IBackgroundCopyJob pJob, IBackgroundCopyFile pFile) => parent.OnFileTransferred(pFile);

			public void JobError(IBackgroundCopyJob pJob, IBackgroundCopyError pError) => parent.OnError(pError);

			public void JobModification(IBackgroundCopyJob pJob, uint dwReserved) => parent.OnModified();

			public void JobTransferred(IBackgroundCopyJob pJob) => parent.OnCompleted();
		}
	}

	/// <summary>Event argument for background copy job.</summary>
	public class BackgroundCopyJobEventArgs : EventArgs
	{
		internal BackgroundCopyJobEventArgs(BackgroundCopyJob j) => Job = j;

		/// <summary>Gets the job being processed.</summary>
		/// <value>The job.</value>
		public BackgroundCopyJob Job { get; private set; }
	}
}