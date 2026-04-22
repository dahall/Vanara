using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static Vanara.PInvoke.Ole32;

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

	private static readonly HashSet<VARTYPE> byRefVt = [VARTYPE.VT_I1, VARTYPE.VT_UI1, VARTYPE.VT_I2, VARTYPE.VT_UI2, VARTYPE.VT_I4, VARTYPE.VT_UI4, VARTYPE.VT_I8, VARTYPE.VT_UI8,
		VARTYPE.VT_INT, VARTYPE.VT_UINT, VARTYPE.VT_R4, VARTYPE.VT_R8, VARTYPE.VT_BOOL, VARTYPE.VT_CY, VARTYPE.VT_DATE, VARTYPE.VT_DECIMAL, VARTYPE.VT_ERROR, VARTYPE.VT_BSTR,
		VARTYPE.VT_UNKNOWN, VARTYPE.VT_DISPATCH, VARTYPE.VT_VARIANT];

	private static readonly HashSet<VARTYPE> vectorVt = [VARTYPE.VT_I1, VARTYPE.VT_UI1, VARTYPE.VT_I2, VARTYPE.VT_UI2, VARTYPE.VT_I4, VARTYPE.VT_UI4, VARTYPE.VT_I8, VARTYPE.VT_UI8,
		VARTYPE.VT_R4, VARTYPE.VT_R8, VARTYPE.VT_BOOL, VARTYPE.VT_CY, VARTYPE.VT_DATE, VARTYPE.VT_FILETIME, VARTYPE.VT_CLSID, VARTYPE.VT_CF, VARTYPE.VT_BSTR, VARTYPE.VT_LPSTR,
		VARTYPE.VT_LPWSTR, VARTYPE.VT_VARIANT];

	private static readonly Dictionary<VARTYPE, VARTYPE> Equivalents = new() {
		{ VARTYPE.VT_INT, VARTYPE.VT_I4 },
		{ VARTYPE.VT_UINT, VARTYPE.VT_UI4 },
		{ VARTYPE.VT_BSTR, VARTYPE.VT_LPWSTR },
		{ VARTYPE.VT_LPSTR, VARTYPE.VT_LPWSTR },
		{ VARTYPE.VT_VOID, VARTYPE.VT_PTR },
		{ VARTYPE.VT_CARRAY, VARTYPE.VT_PTR },
		{ VARTYPE.VT_RECORD, VARTYPE.VT_PTR },
		{ VARTYPE.VT_SAFEARRAY, VARTYPE.VT_PTR },
		{ VARTYPE.VT_CY, VARTYPE.VT_DECIMAL },
		{ VARTYPE.VT_USERDEFINED, VARTYPE.VT_PTR },
		{ VARTYPE.VT_STREAMED_OBJECT, VARTYPE.VT_STREAM },
		{ VARTYPE.VT_STORED_OBJECT, VARTYPE.VT_STORAGE },
		{ VARTYPE.VT_EMPTY, VARTYPE.VT_NULL },
	};

	[ComImport, Guid("00000100-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IDummy { }

	private static IEnumerable<object?[]> GetVarTypes(Func<VARTYPE, bool>? predicate = null)
	{
		foreach (var vt in Enum.GetValues<VARTYPE>().Where(predicate ?? (v => true)))
		{
			if (vt == VARTYPE.VT_EMPTY)
				yield return [vt, null];
			if (vt == VARTYPE.VT_NULL)
				yield return [vt, typeof(DBNull)];
			if (vt is >= VARTYPE.VT_TYPEMASK or <= VARTYPE.VT_NULL)
				continue;
			Type? t = vt switch
			{
				VARTYPE.VT_UNKNOWN => typeof(IAccessControl),
				VARTYPE.VT_DISPATCH => typeof(IDummy),
				//VARTYPE.VT_STREAM => typeof(object),
				//VARTYPE.VT_STREAMED_OBJECT => typeof(object),
				//VARTYPE.VT_STORAGE => typeof(object),
				//VARTYPE.VT_STORED_OBJECT => typeof(object),
				_ => CorrespondingTypeAttribute.GetCorrespondingTypes(vt).FirstOrDefault()
			};
			if (t is not null)
			{
				yield return [vt, t];
				if (vectorVt.Contains(vt))
					yield return [vt | VARTYPE.VT_VECTOR, t.MakeArrayType()];
				if (byRefVt.Contains(vt))
				{
					yield return [vt | VARTYPE.VT_BYREF, t.MakeByRefType() ];
					yield return [vt | VARTYPE.VT_ARRAY, t.MakeArrayType()];
				}
			}
		}
	}

	private static IEnumerable<object?[]> VarTypeDedupTests => GetVarTypes(vt => !Equivalents.TryGetValue(vt, out _));
	private static IEnumerable<object?[]> VarTypeTests => GetVarTypes();

	[TestCaseSource(nameof(VarTypeDedupTests))]
	public void GetVarTypeTest(VARTYPE vt, Type type)
	{
		VARTYPE v = type.GetVarType();
		if (v.IsFlagSet(VARTYPE.VT_VECTOR) && vt.IsFlagSet(VARTYPE.VT_ARRAY))
			v = (v | VARTYPE.VT_ARRAY).ClearFlags(VARTYPE.VT_VECTOR);
		Assert.That(v, Is.EqualTo(vt));
	}

	[TestCaseSource(nameof(VarTypeTests))]

	public void GetCorrespondingTypeTest(VARTYPE vt, Type? type)
	{
		Type? t = vt.GetCorrespondingType();
		Assert.That(t, Is.EqualTo(type));
	}
}