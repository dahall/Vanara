using NUnit.Framework;
using System.Linq;
using System.Reflection;
using static Vanara.PInvoke.Shell32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class BlitTests
{
	[Test]
	public void StructMarshalTest()
	{
		bool allGood = true;
		using (var mem = new SafeHGlobalHandle(4096))
		{
			foreach (var asm in Assembly.GetExecutingAssembly().GetReferencedAssemblies().Where(n => n.Name is not null && n.Name.StartsWith("Vanara")).Select(n => Assembly.Load(n)))
			{
				foreach (var tstr in asm.GetTypes().Where(t => t.IsValueType && !t.IsPrimitive && !t.IsEnum && !t.IsGenericType))
				{
					if (tstr.Name.StartsWith("<>")) continue;
					try
					{
						Marshal.PtrToStructure(mem.DangerousGetHandle(), tstr);
					}
					catch (Exception e)
					{
						TestContext.WriteLine(e);
						allGood = false;
					}
				}
			}
		}
		Assert.That(allGood);
	}

	[Test]
	public void StrRetTest()
	{
		var s1 = new string('c', 300);
		var sr = new STRRET(s1);
		Assert.That(sr.uType, Is.EqualTo(STRRET_TYPE.STRRET_WSTR));
		Assert.That(sr.ToString(), Is.EqualTo(s1));
		Assert.That((string?)sr.pOleStr, Is.EqualTo(s1));
		Assert.That(() => sr.Free(), Throws.Nothing);
		Assert.That((IntPtr)sr.pOleStr, Is.EqualTo(IntPtr.Zero));

		sr = new STRRET(s1);
		ShlwApi.StrRetToBSTR(new PinnedObject(sr), default, out var ret).ThrowIfFailed();
		Assert.That(ret, Is.EqualTo(s1));
		//Assert.That((IntPtr)sr.pOleStr, Is.EqualTo(IntPtr.Zero));
	}
}