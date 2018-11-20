using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Vanara.IO.Tests
{
	[TestFixture()]
	public class BackgroundCopyTests
	{
		const string jname = "TestJob";
		const string src = @"file:///C:/Temp/Holes.mp4";
		const string dest = @"D:\dest.bin";

		[Test]
		public void EnumJobTest()
		{
			var cnt = 0;
			Assert.That(() => BackgroundCopyManager.Jobs.Count, Throws.Nothing);
			Assert.That(cnt = BackgroundCopyManager.Jobs.Count, Is.GreaterThanOrEqualTo(0));
			Assert.That(BackgroundCopyManager.Jobs.Count(), Is.EqualTo(cnt));
		}

		[Test]
		public void VerTest()
		{
			Assert.That(BackgroundCopyManager.Version, Is.GreaterThanOrEqualTo(new Version(10, 0)));
		}

		[Test]
		public void JobCollTest()
		{
			var guid = Guid.Empty;
			BackgroundCopyJob job = null;

			Assert.That(() => { var j = BackgroundCopyManager.Jobs.Add(jname); guid = j.ID; }, Throws.Nothing);
			Assert.That(BackgroundCopyManager.Jobs.Count, Is.GreaterThanOrEqualTo(1));
			Assert.That(BackgroundCopyManager.Jobs.Contains(guid), Is.True);
			Assert.That(() => job = BackgroundCopyManager.Jobs[guid], Throws.Nothing);
			Assert.That(job, Is.Not.Null);
			Assert.That(BackgroundCopyManager.Jobs.Count(j => j.ID == guid), Is.EqualTo(1));
			var array = new BackgroundCopyJob[BackgroundCopyManager.Jobs.Count];
			Assert.That(() => ((ICollection<BackgroundCopyJob>)BackgroundCopyManager.Jobs).CopyTo(array, 0), Throws.Nothing);
			Assert.That(array[0], Is.Not.Null);
			Assert.That(() => BackgroundCopyManager.Jobs.Remove(job), Throws.Nothing);
			Assert.That(BackgroundCopyManager.Jobs.Contains(guid), Is.False);
		}

		[Test]
		public void FileCollTest()
		{
			var job = BackgroundCopyManager.Jobs.Add(jname);
			System.IO.File.Delete(dest);
			Assert.That(() => job.Files.Add(src, dest), Throws.Nothing);
			Assert.That(job.Files.Count, Is.EqualTo(1));
			Assert.That(job.Files.Count(), Is.EqualTo(1));
			Assert.That(job.Files.First().LocalFilePath, Is.EqualTo(dest));
			Assert.That(() => job.Cancel(), Throws.Nothing);
		}

		[Test]
		public void CopyTest()
		{
			System.IO.File.Delete(dest);
			Assert.That(() => BackgroundCopyManager.Copy(src, dest), Throws.Nothing);
			Assert.That(System.IO.File.Exists(dest));
			System.IO.File.Delete(dest);
		}

		[Test]
		public void CopyAsyncCancelReportTest()
		{
			System.IO.File.Delete(dest);
			var cts = new CancellationTokenSource();
			var l = new List<string>();
			var prog = new Progress<Tuple<BackgroundCopyJobState, byte>>(t => l.Add($"{t.Item2}% : {t.Item1}"));
			cts.CancelAfter(2000);
			Assert.That(() => BackgroundCopyManager.CopyAsync(src, dest, cts.Token, prog), Throws.TypeOf<OperationCanceledException>());
			Assert.That(System.IO.File.Exists(dest), Is.False);
			Assert.That(l.Count, Is.GreaterThanOrEqualTo(0));
			TestContext.Write(string.Join("\r\n", l));
		}

		[Test]
		public void CopyAsyncReportTest()
		{
			System.IO.File.Delete(dest);
			var cts = new CancellationTokenSource();
			var l = new List<string>();
			var prog = new Progress<Tuple<BackgroundCopyJobState, byte>>(t => l.Add($"{t.Item2}% : {t.Item1}"));
			Assert.That(() => BackgroundCopyManager.CopyAsync(src, dest, cts.Token, prog), Throws.Nothing);
			Assert.That(System.IO.File.Exists(dest), Is.True);
			Assert.That(l.Count, Is.GreaterThan(0));
			TestContext.Write(string.Join("\r\n", l));
		}

		[Test]
		public void CopyAsyncTest()
		{
			System.IO.File.Delete(dest);
			var cts = new CancellationTokenSource();
			Assert.That(() => BackgroundCopyManager.CopyAsync(src, dest, cts.Token, null), Throws.Nothing);
			Assert.That(System.IO.File.Exists(dest), Is.True);
			System.IO.File.Delete(dest);
		}

		[Test]
		public void JobCertTest()
		{
			var job = BackgroundCopyManager.Jobs.Add(jname);
			Assert.That(job.Certificate, Is.Null);
			var store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
			store.Open(OpenFlags.ReadOnly);
			var c = store.Certificates.Cast<X509Certificate2>().FirstOrDefault();
			job.SetCertificate(store, c);
			Assert.That(job.Certificate, Is.EqualTo(c));
			store.Close();
		}

		[Test]
		public void JobPropTest()
		{
			var job = BackgroundCopyManager.Jobs.Add(jname);
			Assert.That(job.DisplayName, Is.EqualTo(jname));

			Assert.That(() => job.ACLFlags = BackgroundCopyACLFlags.All, Throws.Nothing);
			Assert.That(job.ACLFlags, Is.EqualTo(BackgroundCopyACLFlags.All));

			Assert.That(job.Credentials.Count, Is.EqualTo(0));
			Assert.That(() => job.Credentials.Add(BackgroundCopyJobCredentialScheme.Digest, BackgroundCopyJobCredentialTarget.Proxy, "user", "mypwd"), Throws.Nothing);
			Assert.That(job.Credentials.Count, Is.EqualTo(1));
			Assert.That(job.Credentials[BackgroundCopyJobCredentialScheme.Digest, BackgroundCopyJobCredentialTarget.Proxy].UserName, Is.EqualTo("user"));

			var ch = new System.Net.WebHeaderCollection() { "A1:Test", "A2:Prova" };
			Assert.That(() => job.CustomHeaders = ch, Throws.Nothing);
			Assert.That(job.CustomHeaders, Has.Count.EqualTo(2));

			Assert.That(job.Description, Is.EqualTo(job.GetDefVal<string>(nameof(job.Description))));
			Assert.That(() => job.Description = jname, Throws.Nothing);
			Assert.That(job.Description, Is.EqualTo(jname));

			Assert.That(job.DisableNotifications, Is.EqualTo(job.GetDefVal<bool>(nameof(job.DisableNotifications))));
			Assert.That(() => job.DisableNotifications = true, Throws.Nothing);
			Assert.That(job.DisableNotifications, Is.EqualTo(true));

			Assert.That(job.DynamicContent, Is.EqualTo(job.GetDefVal<bool>(nameof(job.DynamicContent))));
			Assert.That(() => job.DynamicContent = true, Throws.Nothing);
			Assert.That(job.DynamicContent, Is.EqualTo(true));

			Assert.That(job.ErrorCount, Is.EqualTo(job.GetDefVal<int>(nameof(job.ErrorCount))));

			Assert.That(job.HighPerformance, Is.EqualTo(job.GetDefVal<bool>(nameof(job.HighPerformance))));
			Assert.That(() => job.HighPerformance = true, Throws.Nothing);
			Assert.That(job.HighPerformance, Is.EqualTo(true));

			Assert.That(job.ID, Is.Not.EqualTo(Guid.Empty));

			Assert.That(job.JobType, Is.EqualTo(BackgroundCopyJobType.Download));

			Assert.That(job.LastError, Is.Null);

			Assert.That(job.MaxDownloadSize, Is.EqualTo(job.GetDefVal<ulong>(nameof(job.MaxDownloadSize))));
			Assert.That(() => job.MaxDownloadSize = 1000, Throws.Nothing);
			Assert.That(job.MaxDownloadSize, Is.EqualTo(1000));

			Assert.That(job.MaximumDownloadTime, Is.EqualTo(job.GetDefVal<TimeSpan>(nameof(job.MaximumDownloadTime))));
			Assert.That(() => job.MaximumDownloadTime = TimeSpan.FromDays(1), Throws.Nothing);
			Assert.That(job.MaximumDownloadTime, Is.EqualTo(TimeSpan.FromDays(1)));

			Assert.That(job.MinimumNotificationInterval, Is.EqualTo(job.GetDefVal<TimeSpan>(nameof(job.MinimumNotificationInterval))));
			Assert.That(() => job.MinimumNotificationInterval = TimeSpan.FromSeconds(10), Throws.Nothing);
			Assert.That(job.MinimumNotificationInterval, Is.EqualTo(TimeSpan.FromSeconds(10)));

			Assert.That(job.MinimumRetryDelay, Is.EqualTo(job.GetDefVal<TimeSpan>(nameof(job.MinimumRetryDelay))));
			Assert.That(() => job.MinimumRetryDelay = TimeSpan.FromSeconds(1000), Throws.Nothing);
			Assert.That(job.MinimumRetryDelay, Is.EqualTo(TimeSpan.FromSeconds(1000)));

			Assert.That(job.NoProgressTimeout, Is.EqualTo(job.GetDefVal<TimeSpan>(nameof(job.NoProgressTimeout))));
			Assert.That(() => job.NoProgressTimeout = TimeSpan.FromDays(10), Throws.Nothing);
			Assert.That(job.NoProgressTimeout, Is.EqualTo(TimeSpan.FromDays(10)));

			Assert.That(job.NotificationCLSID, Is.EqualTo(job.GetDefVal<Guid>(nameof(job.NotificationCLSID))));
			var guid = Guid.NewGuid();
			Assert.That(() => job.NotificationCLSID = guid, Throws.Nothing);
			Assert.That(job.NotificationCLSID, Is.EqualTo(guid));

			Assert.That(job.NotifyProgram, Is.EqualTo(job.GetDefVal<string>(nameof(job.NotifyProgram))).Or.EqualTo(""));
			var str = "\"cmd.exe\" echo Bob";
			Assert.That(() => job.NotifyProgram = str, Throws.Nothing);
			Assert.That(job.NotifyProgram, Is.EqualTo(str));

			Assert.That(job.OnDemand, Is.EqualTo(job.GetDefVal<bool>(nameof(job.OnDemand))));
			Assert.That(() => job.OnDemand = true, Throws.Nothing);
			Assert.That(job.OnDemand, Is.EqualTo(true));

			Assert.That(job.Owner, Is.EqualTo(System.Security.Principal.WindowsIdentity.GetCurrent().User));

			Assert.That(job.OwnerIntegrityLevel, Is.EqualTo(12288));

			Assert.That(job.OwnerIsElevated, Is.EqualTo(true));

			Assert.That(job.Priority, Is.EqualTo(job.GetDefVal<BackgroundCopyJobPriority>(nameof(job.Priority))));
			Assert.That(() => job.Priority = BackgroundCopyJobPriority.Low, Throws.Nothing);
			Assert.That(job.Priority, Is.EqualTo(BackgroundCopyJobPriority.Low));

			Assert.That(job.Progress.BytesTransferred, Is.EqualTo(0));

			Assert.That(job.Proxy, Is.EqualTo(job.GetDefVal<System.Net.WebProxy>(nameof(job.Proxy))));
			Assert.That(() => job.Proxy = new System.Net.WebProxy("http://1.1.1.1"), Throws.Nothing);
			Assert.That(job.Proxy.Address, Is.EqualTo(new Uri("http://1.1.1.1")));

			Assert.That(job.State, Is.EqualTo(BackgroundCopyJobState.Suspended));

			Assert.That(job.SecurityOptions, Is.EqualTo(job.GetDefVal<BackgroundCopyJobSecurity>(nameof(job.SecurityOptions))));
			Assert.That(() => job.SecurityOptions = BackgroundCopyJobSecurity.CheckCRL, Throws.Nothing);
			Assert.That(job.SecurityOptions, Is.EqualTo(BackgroundCopyJobSecurity.CheckCRL));

			Assert.That(job.TransferBehavior, Is.EqualTo(job.GetDefVal<BackgroundCopyCost>(nameof(job.TransferBehavior))));
			Assert.That(() => job.TransferBehavior = BackgroundCopyCost.Unrestricted, Throws.Nothing);
			Assert.That(job.TransferBehavior, Is.EqualTo(BackgroundCopyCost.Unrestricted));

			Assert.That(job.UseStoredCredentials, Is.EqualTo(job.GetDefVal<BackgroundCopyJobCredentialTarget>(nameof(job.UseStoredCredentials))));
			Assert.That(() => job.UseStoredCredentials = BackgroundCopyJobCredentialTarget.Proxy, Throws.Nothing);
			Assert.That(job.UseStoredCredentials, Is.EqualTo(BackgroundCopyJobCredentialTarget.Proxy));

			Assert.That(job.Credentials.Remove(BackgroundCopyJobCredentialScheme.Digest, BackgroundCopyJobCredentialTarget.Proxy), Is.True);
			Assert.That(job.Credentials.Count, Is.EqualTo(0));

			Assert.That(job.CreationTime, Is.LessThan(DateTime.Now));
			Assert.That(job.ModificationTime, Is.LessThan(DateTime.Now));
			Assert.That(job.TransferCompletionTime, Has.Property("Year").EqualTo(1600));
		}
	}

	public static class Ext
	{
		public static T GetDefVal<T>(this object obj, string prop)
		{
			var pi = obj.GetType().GetProperty(prop, typeof(T));
			var attr = (System.ComponentModel.DefaultValueAttribute)pi.GetCustomAttributes(typeof(System.ComponentModel.DefaultValueAttribute), false).FirstOrDefault();
			if (attr?.Value == null) return default;
			if (attr.Value is T) return (T)attr.Value;
			var cval = (attr.Value as IConvertible)?.ToType(typeof(T), null);
			return cval != null ? (T)cval : throw new InvalidCastException();
		}
	}
}