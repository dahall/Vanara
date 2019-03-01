using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Vanara.PInvoke.PowrProf;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class PowrProfTests
	{
		[Test]
		public void EnumPwrSchemesTest()
		{
			Assert.That(EnumPwrSchemes(p), Is.True);

			bool p(uint uiIndex, uint dwName, string sName, uint dwDesc, string sDesc, in POWER_POLICY pp, IntPtr lParam)
			{
				TestContext.WriteLine($"Idx:{uiIndex}; Name:{sName}; Desc:{sDesc}");
				return true;
			}
		}

		[Test]
		public void PowerEnumerateTest()
		{
			var sb = new StringBuilder(1024, 1024);

			Guid? scheme = null;
			Guid? subgroup = null;
			TestContext.WriteLine("========================= null, null");
			foreach (var value in PowerEnumerate<Guid>(scheme, subgroup))
				WriteName(value);

			PowerGetActiveScheme(out var gScheme).ThrowIfFailed();
			scheme = gScheme;
			subgroup = GUID_SYSTEM_BUTTON_SUBGROUP;
			TestContext.WriteLine("========================= Active, GUID_SYSTEM_BUTTON_SUBGROUP");
			foreach (var value in PowerEnumerate<Guid>(scheme, subgroup))
				WriteName(value);

			subgroup = null;
			TestContext.WriteLine("========================= Active, null");
			foreach (var value in PowerEnumerate<Guid>(scheme, subgroup))
				WriteName(value);

			subgroup = NO_SUBGROUP_GUID;
			TestContext.WriteLine("========================= Active, NO_SUBGROUP_GUID");
			foreach (var value in PowerEnumerate<Guid>(scheme, subgroup))
				WriteName(value);

			void WriteName(in Guid setting)
			{
				sb.Clear();
				var sbSz = (uint)sb.Capacity;
				if (PowerReadFriendlyName(default, scheme.GetValueOrDefault(), subgroup.GetValueOrDefault(), setting, sb, ref sbSz).Succeeded)
					TestContext.WriteLine($"{sb.ToString()} : {setting}");
			}
		}

		[Test]
		public void PowerReadSettingAttributesTest()
		{
			var attr = PowerReadSettingAttributes(default(Guid), default(Guid));
			TestContext.WriteLine($"DefGuid={attr}");
			attr = PowerReadSettingAttributes(GUID_SYSTEM_BUTTON_SUBGROUP, default);
			TestContext.WriteLine($"GUID_SYSTEM_BUTTON_SUBGROUP={attr}");
		}
	}
}
