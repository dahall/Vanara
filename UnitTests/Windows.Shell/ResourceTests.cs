using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.Tests;

[TestFixture]
public class ResourceTests
{
	[Test]
	public void IndirectStringTest()
	{
		Assert.IsTrue(IndirectString.TryParse(@"@%SystemRoot%\system32\shell32.dll,-21810", out var ids));
		Assert.That(ids.ResourceId, Is.EqualTo(-21810));
		Assert.NotNull(ids.Value);
	}
}