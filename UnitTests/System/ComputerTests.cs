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
		public void AuthMapUnmapDriveTest()
		{
			var remoteShare = TestCaseSources.Lookup["RemoteShare"];
			string local = null;
			using var authLocal = new Computer(null, Environment.MachineName + "\\" + TestCaseSources.Lookup["LocalUser"], TestCaseSources.Lookup["LocalUserPassword"]);
			try
			{
				local = authLocal.NetworkDeviceConnections.Add(remoteShare, "*", TestCaseSources.Lookup["LocalAdmin"], TestCaseSources.Lookup["LocalAdminPassword"]);
				var conns = authLocal.NetworkDeviceConnections.SelectMany(r => r.Children).Concat(Computer.Local.NetworkDeviceConnections).ToList();
				Assert.That(conns.Select(r => r.LocalName), Has.One.EqualTo(local));
				conns.WriteValues();
			}
			finally
			{
				if (local != null)
					authLocal.NetworkDeviceConnections.Remove(local, true);
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