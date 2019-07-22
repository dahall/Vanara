using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public partial class WinBaseTests
	{
		[Test]
		public void AtomTest()
		{
			const string name = "Test";
			Assert.That(InitAtomTable(7), ResultIs.Successful);
			var atom = AddAtom(name);
			Assert.That(atom, Is.Not.Zero);
			Assert.That(FindAtom(name), Is.EqualTo(atom));
			Assert.That(GetAtomName(atom), Is.EqualTo(name));
			Assert.That(DeleteAtom(atom), ResultIs.Value(ATOM.INVALID_ATOM));
		}

		[Test]
		public void GlobalAtomTest()
		{
			const string name = "Test";
			var atom = GlobalAddAtom(name);
			Assert.That(atom, Is.Not.Zero);
			Assert.That(GlobalFindAtom(name), Is.EqualTo(atom));
			Assert.That(GlobalGetAtomName(atom), Is.EqualTo(name));
			Assert.That(GlobalDeleteAtom(atom), ResultIs.Value(ATOM.INVALID_ATOM));
		}
	}
}