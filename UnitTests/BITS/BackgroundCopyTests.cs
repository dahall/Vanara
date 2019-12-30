using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;

namespace Vanara.IO.Tests
{
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
			var attr = (System.ComponentModel.DefaultValueAttribute)pi.GetCustomAttributes(typeof(System.ComponentModel.DefaultValueAttribute), false).FirstOrDefault();
			if (attr?.Value == null) return default;
			if (attr.Value is T) return (T)attr.Value;
			var cval = (attr.Value as IConvertible)?.ToType(typeof(T), null);
			return cval != null ? (T)cval : throw new InvalidCastException();
		}
	}
}