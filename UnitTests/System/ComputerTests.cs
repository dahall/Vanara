using System;
using Vanara.Diagnostics;
using NUnit.Framework;
using System.Text;
using System.Linq;
using Vanara.PInvoke.Tests;
using Vanara.InteropServices;

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
		public void EnumLocalGroupsTest()
		{
			const string name = "TestUser123";
			const string newcomment = "new testing user";

			var lg = Computer.Local.LocalGroups.Add(name);
			try
			{
				Assert.That(Computer.Local.LocalGroups.Count, Is.GreaterThanOrEqualTo(1));
				Assert.That(lg.Name, Is.EqualTo(name));
				Assert.That(lg.Target, Is.EqualTo(Computer.Local.Target));
				Assert.That(lg.Comment, Is.Empty);
				Assert.IsTrue(Computer.Local.LocalGroups.Contains(lg));
				Assert.That(() => lg.Comment = newcomment, Throws.Nothing);
				Assert.That(lg.Comment, Is.EqualTo(newcomment));
			}
			finally
			{
				Computer.Local.LocalGroups.Remove(lg);
			}
		}

		[Test]
		public void EnumSessionsTest()
		{
			try
			{
				var sessions = Computer.Local.Sessions.ToList();
				foreach (var session in sessions)
				{
					TestContext.WriteLine("=============================");
					session.WriteValues();
				}
			}
			finally
			{

			}
		}

		[Test]
		public void EnumUsersTest()
		{
			const string user = "TestUser123";
			const string comment = "testing user";
			const string newcomment = "new testing user";
			string hmfld = TestCaseSources.TempDir;
			var pwd = Guid.NewGuid().ToString("B");

			var acct = Computer.Local.UserAccounts.Add(user, pwd, null, comment, null, PInvoke.NetApi32.UserAcctCtrlFlags.UF_ACCOUNTDISABLE);
			try
			{
				Assert.That(Computer.Local.UserAccounts.Count, Is.GreaterThanOrEqualTo(1));
				Assert.That(acct.UserName, Is.EqualTo(user));
				Assert.That(acct.Target, Is.EqualTo(Computer.Local.Target));
				Assert.That(acct.Comment, Is.EqualTo(comment));
				Assert.IsTrue(Computer.Local.UserAccounts.Contains(acct));
				Assert.That(() => acct.Comment = newcomment, Throws.Nothing);
				Assert.That(acct.Comment, Is.EqualTo(newcomment));
				Assert.That(acct.HomeFolder, Is.Empty);
				Assert.That(() => acct.HomeFolder = hmfld, Throws.Nothing);
				Assert.That(acct.HomeFolder, Is.EqualTo(hmfld));
			}
			finally
			{
				Computer.Local.UserAccounts.Remove(acct);
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