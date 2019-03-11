using System;
using Vanara.Diagnostics;
using NUnit.Framework;
using System.Text;
using System.Linq;

namespace Vanara.Diagnostics.Tests
{
	[TestFixture]
	public class ComputerTests
	{
		[Test]
		public void EnumSharesTest()
		{
			TestContext.WriteLine(string.Join(", ", Computer.Local.SharedDevices.Values.Select(d => d.Name)));
			//var remote = new Computer(@"\\HALLAN-SVR", "dahall@byu.net", "msitsdav1d");
			//TestContext.WriteLine(string.Join(", ", remote.SharedDevices.Values.Select(d => d.Name)));
		}
	}
}