using NUnit.Framework;
using System;
using System.Security.Principal;

namespace Vanara.PInvoke.Tests;

partial class BackgroundCopyTests
{
	[Test]
	public void JobPropTest()
	{
		var currentMethodName = GetCurrentMethodName();

		
		using var job = BackgroundCopyManager.Jobs.Add(currentMethodName);

		Assert.That(job.DisplayName, Is.EqualTo(currentMethodName));


		Assert.That(() => job.ACLFlags = BackgroundCopyACLFlags.All, Throws.Nothing);
		Assert.That(job.ACLFlags, Is.EqualTo(BackgroundCopyACLFlags.All));


		Assert.That(job.Credentials.Count, Is.EqualTo(0));
		Assert.That(() => job.Credentials.Add(BackgroundCopyJobCredentialScheme.Digest, BackgroundCopyJobCredentialTarget.Proxy, "user", "mypwd"), Throws.Nothing);

		Assert.That(job.Credentials[BackgroundCopyJobCredentialScheme.Digest, BackgroundCopyJobCredentialTarget.Proxy].UserName, Is.EqualTo("user"));


		var ch = new System.Net.WebHeaderCollection() { "A1:Test", "A2:Prova" };

		Assert.That(() => job.CustomHeaders = ch, Throws.Nothing);
		Assert.That(job.CustomHeaders, Has.Count.EqualTo(2));
		
		Assert.That(job.Description, Is.EqualTo(job.GetDefVal<string>(nameof(job.Description))));
		Assert.That(() => job.Description = currentMethodName, Throws.Nothing);
		Assert.That(job.Description, Is.EqualTo(currentMethodName));
		
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

		Assert.That(job.HttpMethod, Is.EqualTo(job.GetDefVal<string>(nameof(job.HttpMethod))));
		Assert.That(() => job.MakeCustomHeadersWriteOnly(), Throws.Nothing);

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

		using var identity = WindowsIdentity.GetCurrent();
		Assert.That(job.Owner, Is.EqualTo(identity.User));

		Assert.That(job.OwnerIntegrityLevel, Is.EqualTo(8192));

		Assert.That(job.OwnerIsElevated, Is.EqualTo(false));

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
