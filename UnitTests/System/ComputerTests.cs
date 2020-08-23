using System;
using Vanara.Diagnostics;
using NUnit.Framework;
using System.Text;
using System.Linq;
using Vanara.PInvoke.Tests;

namespace Vanara.Diagnostics.Tests
{
	[TestFixture]
	public class ComputerTests
	{
		[Test]
		public void EnumSharesTest()
		{
			const string shareName = "Test123123123123";
			try
			{
				Computer.Local.SharedDevices.Add(shareName, "Cmt", TestCaseSources.TempDir);
				var shares = Computer.Local.SharedDevices.Values.ToList();
				TestContext.Write(string.Join("\n", shares.Select(s => $"{s.Name}={s.Path} ({s.Description})")));
				Assert.That(shares, Has.One.Property("Name").EqualTo(shareName));
			}
			finally
			{
				Computer.Local.SharedDevices.Remove(shareName);
			}
			//var remote = new Computer(@"\\COMPUTER", "user@domain.net", "pwd");
			//TestContext.WriteLine(string.Join(", ", remote.SharedDevices.Values.Select(d => d.Name)));
		}

		[Test]
		public void MapUnmapDriveTest()
		{
			var remoteShare = TestCaseSources.Lookup["RemoteShare"];
			string local = null;
			try
			{
				local = Computer.Local.NetworkDeviceConnections.Add(remoteShare, "*");
				var conns = Computer.Local.NetworkDeviceConnections.SelectMany(r => r.Children).Concat(Computer.Local.NetworkDeviceConnections).ToList();
				Assert.That(conns.Select(r => r.LocalName), Has.One.EqualTo(local));
				conns.WriteValues();
			}
			finally
			{
				if (local != null)
					Computer.Local.NetworkDeviceConnections.Remove(local, true);
			}
		}

		[Test]
		public void OpenFilesTests()
		{
			var files = Computer.Local.OpenFiles.ToList();
			Assert.That(files, Is.Not.Null);
			files.WriteValues();
		}
	}
}