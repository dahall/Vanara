using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Linq;
using NUnit.Framework;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.OleAut32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class VarTests
{
	static readonly Dictionary<Type, string> funcPart = new Dictionary<Type, string>()
	{
		{ typeof(sbyte), "I1" },
		{ typeof(byte), "UI1" },
		{ typeof(short), "I2" },
		{ typeof(ushort), "UI2" },
		{ typeof(int), "I4" },
		{ typeof(uint), "UI4" },
		{ typeof(ulong), "UI8" },
		{ typeof(long), "I8" },
		{ typeof(float), "R4" },
		{ typeof(double), "R8" },
		{ typeof(bool), "Bool" },
		{ typeof(CY), "Cy" },
		{ typeof(string), "Str" },
		{ typeof(DECIMAL), "Dec" },
		{ typeof(DateTime), "Date" },
	};

	static readonly LCID curLoc = Kernel32.GetUserDefaultLCID();

	[Test, TestCaseSource(nameof(NumericTests))]
	public void VarConvTest(object toVal, object fromVal, string fn)
	{
		var mi = typeof(OleAut32).GetMethod(fn, System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
		if (mi == null)
			Assert.Fail($"Function {fn} missing.");
		var hasStr = fromVal is string || toVal is string;
		var p = hasStr ? new[] { fromVal, curLoc, Activator.CreateInstance(mi.GetParameters()[2].ParameterType), null } : new[] { fromVal, null };
		//try {
		Assert.That((HRESULT)mi.Invoke(null, p), ResultIs.Successful);
		//} catch { }
		Assert.That(p[hasStr ? 3 : 1], Is.EqualTo(toVal));
	}

	public static IEnumerable<TestCaseData> NumericTests
	{
		get
		{
			const int noNegCnt = 4;
			var vals = new object[] { (byte)1, (ushort)1, 1u, 1ul, (sbyte)1, (short)1, 1, 1L, 1f, 1d, true, "1", new CY(1m), new DECIMAL(1m) };
			for (var i = 0; i < vals.Length; i++)
			{
				var t1 = vals[i].GetType();
				for (var j = 0; j < vals.Length; j++)
				{
					var t2 = vals[j].GetType();
					if (t1 == t2)
						continue;

					var fn = $"Var{(t1 == typeof(string) ? "Bstr" : funcPart[t1])}From{funcPart[t2]}";
					yield return new TestCaseData(GetVal(i, j), GetVal(j, i), fn).SetName(fn);
				}
			}

			object GetVal(int item, int opp)
			{
				var oi = vals[item];
				return vals[opp] switch
				{
					bool _ when item >= noNegCnt => oi switch
					{
						CY _ => new CY(-1m),
						DECIMAL _ => new DECIMAL(-1m),
						string _ => "True",
						_ => Convert.ChangeType(-1, oi.GetType())
					},
					_ => oi
				};
			}
		}
	}
}