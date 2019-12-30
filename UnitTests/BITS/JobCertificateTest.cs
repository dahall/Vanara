using NUnit.Framework;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Vanara.IO.Tests
{
	partial class BackgroundCopyTests
	{
		[Test]
		public void JobCertificateTest()
		{
			using var job = BackgroundCopyManager.Jobs.Add(GetCurrentMethodName());

			Assert.That(job.Certificate, Is.Null);


			using var store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);

			store.Open(OpenFlags.ReadOnly);

			var c = store.Certificates.Cast<X509Certificate2>().FirstOrDefault();

			job.SetCertificate(store, c);

			Assert.That(job.Certificate, Is.EqualTo(c));
		}
	}
}
