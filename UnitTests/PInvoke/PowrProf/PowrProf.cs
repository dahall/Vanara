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
			foreach (var scheme in PowerEnumerate<Guid>(null, null))
			{
				PowerGetActiveScheme(out var active);
				TestContext.WriteLine($"Scheme: {scheme} {(scheme == active ? "(Active)" : "")}");
				foreach (var subgroup in PowerEnumerate<Guid>(scheme, null).Concat(new[] { NO_SUBGROUP_GUID }))
				{
					TestContext.Write("  ");
					WriteName(scheme, subgroup, null);
					foreach (var value in PowerEnumerate<Guid>(scheme, subgroup))
					{
						TestContext.Write("    ");
						WriteName(scheme, subgroup, value);
					}
				}
			}

			void WriteName(Guid? sch, Guid? grp, Guid? setting) { TestContext.WriteLine($"{PowerReadFriendlyName(sch, grp, setting)} : {PowerReadDescription(sch, grp, setting)} : {setting}"); }
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