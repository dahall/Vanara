using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using Vanara.PInvoke.Tests;

namespace NUnit.Framework;

[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class TestWhenElevatedAttribute : TestAttribute, ITestBuilder
{
	private static readonly bool isElevated = TestHelper.IsElevated;

	IEnumerable<TestMethod> ITestBuilder.BuildFrom(IMethodInfo method, Test? suite)
	{
		if (isElevated)
		{
			yield return base.BuildFrom(method, suite);
		}
		else
		{
			TestMethod test = new(method, suite) { RunState = RunState.Ignored };
			test.Properties.Set(PropertyNames.SkipReason, "Test requires elevated privileges.");
			yield return test;
		}
	}
}