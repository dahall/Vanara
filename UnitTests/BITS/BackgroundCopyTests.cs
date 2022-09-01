global using NUnit.Framework;
global using System;
global using System.Diagnostics;
global using System.Linq;
global using Vanara.IO;
using System.Reflection;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public partial class BackgroundCopyTests
{
	public string GetCurrentMethodName()
	{
		var st = new StackTrace();
		var sf = st.GetFrame(1);

		return sf.GetMethod().Name;
	}
}

public static class Ext
{
	public static T GetDefVal<T>(this object obj, string prop)
	{
		var pi = obj.GetType().GetProperty(prop, typeof(T));
		var attr = pi.GetCustomAttribute<System.ComponentModel.DefaultValueAttribute>(false);
		if (attr?.Value == null) return default;
		if (attr.Value is T val) return val;
		return (T)(attr.Value as IConvertible)?.ToType(typeof(T), null) ?? throw new InvalidCastException();
	}
}