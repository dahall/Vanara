using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class VarTests
{
	private static readonly LCID curLoc = Kernel32.GetUserDefaultLCID();

	private static readonly Dictionary<Type, string> funcPart = new()
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

	public static IEnumerable<object[]> NumericTests
	{
		get
		{
			const int noNegCnt = 4;
			object[] vals = [(byte)1, (ushort)1, 1u, 1ul, (sbyte)1, (short)1, 1, 1L, 1f, 1d, true, "1", new CY(1m), new DECIMAL(1m)];
			for (int i = 0; i < vals.Length; i++)
			{
				Type t1 = vals[i].GetType();
				for (int j = 0; j < vals.Length; j++)
				{
					Type t2 = vals[j].GetType();
					if (t1 == t2)
						continue;

					string fn = $"Var{(t1 == typeof(string) ? "Bstr" : funcPart[t1])}From{funcPart[t2]}";
					MethodInfo? mi = typeof(OleAut32).GetMethod(fn, BindingFlags.Static | BindingFlags.Public);
					if (mi is not null)
						yield return new object[] { GetVal(i, j), GetVal(j, i), mi! };
				}
			}

			object GetVal(int item, int opp)
			{
				object oi = vals[item];
				return vals[opp] switch
				{
					bool _ when item < noNegCnt => oi switch
					{
						byte _ => byte.MaxValue,
						ushort _ => ushort.MaxValue,
						uint _ => uint.MaxValue,
						ulong _ => ulong.MaxValue,
						_ => throw new ArgumentOutOfRangeException(nameof(item), "Invalid type."),
					},
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

	//[Test]
	public void ShowOther()
	{
		List<object[]> cases = [.. NumericTests];
		List<string>? tested = [.. cases.Select(t => ((MethodInfo)t[2]!).Name)];
		Assert.That(tested, Is.Not.Null);
		List<string> all = [.. typeof(OleAut32).GetMethods(BindingFlags.Static | BindingFlags.Public).Where(mi => mi.Name.StartsWith("Var")).Select(mi => mi.Name)];
		all.Except(tested!).OrderBy(s => s.ToLowerInvariant()).ToList().WriteValues();
	}

	[TestCaseSource(nameof(NumericTests))]
	public void VarConvTest(object toVal, object fromVal, MethodInfo mi)
	{
		bool hasStr = fromVal is string || toVal is string;
		object?[] p = hasStr ? [fromVal, curLoc, Activator.CreateInstance(mi.GetParameters()[2].ParameterType), null] : [fromVal, null];
		HRESULT hr = 0;
		try { hr = (HRESULT)mi.Invoke(null, p)!; }
		catch { Assert.Ignore($"Function {mi.Name} fails Invoke."); }
		Assert.That(hr, ResultIs.Successful);
		Assert.That(p[hasStr ? 3 : 1], Is.EqualTo(toVal));
	}
}