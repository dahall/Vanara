using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class SecurityTests
	{
		[Test]
		public void StructMarshalTest()
		{
			bool allGood = true;
			using (var mem = new SafeHGlobalHandle(4096))
			{
				//foreach (var asm in Assembly.GetExecutingAssembly().GetReferencedAssemblies().Where(n => n.Name.StartsWith("Vanara")).Select(n => Assembly.Load(n)))
				//{
				var asm = typeof(Vanara.PInvoke.AdvApi32).Assembly;
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
				//}
			}
			Assert.That(allGood);
		}
	}
}