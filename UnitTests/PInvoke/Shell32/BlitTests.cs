using NUnit.Framework;
using System.Linq;
using System.Reflection;

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
}