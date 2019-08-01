using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class WinNlsTests
	{
		[Test]
		public void ConvertDefaultLocaleTest()
		{
			Assert.That(ConvertDefaultLocale(LOCALE_USER_DEFAULT), ResultIs.Not.Value(LOCALE_USER_DEFAULT));
		}

		[Test]
		public void ConvertTest()
		{
			GetSystemTime(out var st);
			Assert.That(ConvertSystemTimeToCalDateTime(st, CALID.CAL_HEBREW, out var cdt), ResultIs.Successful);
			Assert.That(AdjustCalendarDate(ref cdt, CALDATETIME_DATEUNIT.DayUnit, 1), ResultIs.Successful);
			Assert.That(ConvertCalDateTimeToSystemTime(cdt, out var st2), ResultIs.Successful);
			Assert.That(st.ToDateTime(DateTimeKind.Utc).AddDays(1), Is.EqualTo(st2.ToDateTime(DateTimeKind.Utc)));
		}

		[Test]
		public void EnumCalendarInfoExExTest()
		{
			var res = EnumCalendarInfoExEx(LOCALE_NAME_USER_DEFAULT, ENUM_ALL_CALENDARS, CALTYPE.CAL_SLONGDATE).ToList();
			Assert.That(res, Is.Not.Empty);
			TestContext.WriteLine(string.Join(";", res));
		}

		[Test]
		public void EnumCalendarInfoExTest()
		{
			var res = EnumCalendarInfoEx(LOCALE_USER_DEFAULT, ENUM_ALL_CALENDARS, CALTYPE.CAL_SLONGDATE).ToList();
			Assert.That(res, Is.Not.Empty);
			TestContext.WriteLine(string.Join(";", res));
		}

		[Test]
		public void EnumCalendarInfoTest()
		{
			var res = EnumCalendarInfo(LOCALE_USER_DEFAULT, ENUM_ALL_CALENDARS, CALTYPE.CAL_SLONGDATE).ToList();
			Assert.That(res, Is.Not.Empty);
			TestContext.WriteLine(string.Join(";", res));
		}

		[Test]
		public void EnumDateFormatsExExTest()
		{
			var res = EnumDateFormatsExEx(LOCALE_NAME_USER_DEFAULT, DATE_FORMAT.DATE_LONGDATE).ToList();
			Assert.That(res, Is.Not.Empty);
			TestContext.WriteLine(string.Join(";", res));
		}

		[Test]
		public void EnumDateFormatsExTest()
		{
			var res = EnumDateFormatsEx(LOCALE_USER_DEFAULT, DATE_FORMAT.DATE_LONGDATE).ToList();
			Assert.That(res, Is.Not.Empty);
			TestContext.WriteLine(string.Join(";", res));
		}

		[Test]
		public void EnumDateFormatsTest()
		{
			var res = EnumDateFormats(LOCALE_USER_DEFAULT, DATE_FORMAT.DATE_LONGDATE).ToList();
			Assert.That(res, Is.Not.Empty);
			TestContext.WriteLine(string.Join(";", res));
		}

		[Test]
		public void EnumLanguageGroupLocalesTest()
		{
			var res = EnumLanguageGroupLocales(LGRPID.LGRPID_GEORGIAN).ToList();
			Assert.That(res, Is.Not.Empty);
			TestContext.WriteLine(string.Join(";", res));
		}

		[Test]
		public void EnumSystemCodePagesTest()
		{
			var res = EnumSystemCodePages(0).ToList();
			Assert.That(res, Is.Not.Empty);
			TestContext.WriteLine(string.Join(";", res));
		}

		[Test]
		public void EnumSystemGeoIDTest()
		{
			var res = EnumSystemGeoID(SYSGEOCLASS.GEOCLASS_ALL).ToList();
			Assert.That(res, Is.Not.Empty);
			TestContext.WriteLine(string.Join(";", res));
		}

		[Test]
		public void EnumSystemGeoNamesTest()
		{
			var res = EnumSystemGeoNames(SYSGEOCLASS.GEOCLASS_ALL).ToList();
			Assert.That(res, Is.Not.Empty);
			TestContext.WriteLine(string.Join(";", res));
		}

		[Test]
		public void EnumSystemLanguageGroupsTest()
		{
			var res = EnumSystemLanguageGroups().ToList();
			Assert.That(res, Is.Not.Empty);
			TestContext.WriteLine(string.Join(";", res));
		}

		[Test]
		public void EnumSystemLocalesExTest()
		{
			var res = EnumSystemLocalesEx(0).ToList();
			Assert.That(res, Is.Not.Empty);
			TestContext.WriteLine(string.Join(";", res));
		}

		[Test]
		public void EnumSystemLocalesTest()
		{
			var res = EnumSystemLocales(0).ToList();
			Assert.That(res, Is.Not.Empty);
			TestContext.WriteLine(string.Join(";", res));
		}

		[Test]
		public void EnumTimeFormatsExTest()
		{
			var res = EnumTimeFormatsEx(LOCALE_NAME_USER_DEFAULT, 0).ToList();
			Assert.That(res, Is.Not.Empty);
			TestContext.WriteLine(string.Join(";", res));
		}

		[Test]
		public void EnumTimeFormatsTest()
		{
			var res = EnumTimeFormats(LOCALE_USER_DEFAULT, 0).ToList();
			Assert.That(res, Is.Not.Empty);
			TestContext.WriteLine(string.Join(";", res));
		}

		[Test]
		public void EnumUILanguagesTest()
		{
			var res = EnumUILanguages(0).ToList();
			Assert.That(res, Is.Not.Empty);
			TestContext.WriteLine(string.Join(";", res));
		}

		[Test]
		public void FindNLSStringExTest()
		{
			Assert.That(FindNLSStringEx(LOCALE_NAME_USER_DEFAULT, COMPARE_STRING.LINGUISTIC_IGNORECASE, "Fred", 4, "fred", 4, out var found), ResultIs.Not.Value(-1));
		}

		[Test]
		public void FindNLSStringTest()
		{
			Assert.That(FindNLSString(LOCALE_USER_DEFAULT, COMPARE_STRING.LINGUISTIC_IGNORECASE, "Fred", 4, "fred", 4, out var found), ResultIs.Not.Value(-1));
		}

		[Test]
		public void GetACPTest()
		{
			Assert.That(GetACP(), ResultIs.Not.Value(0));
		}

		[Test]
		public void GetCalendarDateFormatExTest()
		{
			GetSystemTime(out var st);
			ConvertSystemTimeToCalDateTime(st, CALID.CAL_GREGORIAN, out var cdt);
			var sb = new StringBuilder(256);
			Assert.That(GetCalendarDateFormatEx(LOCALE_NAME_USER_DEFAULT, 0, cdt, "d MMMM", sb, sb.Capacity), ResultIs.Successful);
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetCalendarInfoExTest()
		{
			Assert.That(GetCalendarInfoEx(LOCALE_NAME_USER_DEFAULT, CALID.CAL_GREGORIAN_US, null, CALTYPE.CAL_ITWODIGITYEARMAX | CALTYPE.CAL_RETURN_NUMBER, default, 0, out var val), ResultIs.Not.Value(0));
			var sb = new StringBuilder(256);
			Assert.That(GetCalendarInfoEx(LOCALE_NAME_USER_DEFAULT, CALID.CAL_GREGORIAN_US, null, CALTYPE.CAL_SCALNAME, sb, sb.Capacity), ResultIs.Not.Value(0));
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetCalendarSupportedDateRangeTest()
		{
			Assert.That(GetCalendarSupportedDateRange(CALID.CAL_GREGORIAN, out var cdt1, out var cdt2), ResultIs.Successful);
			cdt1.WriteValues();
			cdt2.WriteValues();
		}

		[Test]
		public void GetCPInfoExTest()
		{
			Assert.That(GetCPInfoEx(CP_ACP, 0, out var cpi), ResultIs.Successful);
			Assert.That(cpi.MaxCharSize, Is.GreaterThan(0));
			Assert.That((char)cpi.UnicodeDefaultChar, Is.EqualTo('?'));
			cpi.WriteValues();
		}

		[Test]
		public void GetCPInfoTest()
		{
			Assert.That(GetCPInfo(CP_ACP, out var cpi), ResultIs.Successful);
			Assert.That(cpi.MaxCharSize, Is.GreaterThan(0));
			cpi.WriteValues();
		}

		[Test]
		public void GetCurrencyFormatExTest()
		{
			var sb = new StringBuilder(256);
			Assert.That(GetCurrencyFormatEx(LOCALE_NAME_USER_DEFAULT, LOCALE_FORMAT_FLAG.LOCALE_NOUSEROVERRIDE, null, IntPtr.Zero, sb, sb.Capacity), ResultIs.Successful);
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetCurrencyFormatTest()
		{
			var sb = new StringBuilder(256);
			Assert.That(GetCurrencyFormat(LOCALE_USER_DEFAULT, LOCALE_FORMAT_FLAG.LOCALE_NOUSEROVERRIDE, null, IntPtr.Zero, sb, sb.Capacity), ResultIs.Successful);
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetDurationFormatExTest()
		{
			var sb = new StringBuilder(256);
			Assert.That(GetDurationFormatEx(LOCALE_NAME_USER_DEFAULT, LOCALE_FORMAT_FLAG.LOCALE_NOUSEROVERRIDE, IntPtr.Zero, 1500UL, null, sb, sb.Capacity), ResultIs.Successful);
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetDurationFormatTest()
		{
			var sb = new StringBuilder(256);
			Assert.That(GetDurationFormat(LOCALE_USER_DEFAULT, LOCALE_FORMAT_FLAG.LOCALE_NOUSEROVERRIDE, IntPtr.Zero, 1500UL, null, sb, sb.Capacity), ResultIs.Successful);
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetFileMUIInfoTest()
		{
			var sz = 0U;
			Assert.That(GetFileMUIInfo(MUI_QUERY.MUI_QUERY_CHECKSUM | MUI_QUERY.MUI_QUERY_LANGUAGE_NAME | MUI_QUERY.MUI_QUERY_RESOURCE_TYPES | MUI_QUERY.MUI_QUERY_TYPE,
				@"C:\Windows\RegEdit.exe", IntPtr.Zero, ref sz), ResultIs.Failure);
			var fmi = FILEMUIINFO.Default;
			using (var mem = SafeHGlobalHandle.CreateFromStructure(fmi))
			{
				var success = false;
				do
				{
					mem.Size = sz;
					Marshal.WriteInt32(mem, mem.Size);
					success = GetFileMUIInfo(MUI_QUERY.MUI_QUERY_CHECKSUM | MUI_QUERY.MUI_QUERY_LANGUAGE_NAME | MUI_QUERY.MUI_QUERY_RESOURCE_TYPES | MUI_QUERY.MUI_QUERY_TYPE,
						@"C:\Windows\RegEdit.exe", mem, ref sz);
				} while (!success && Win32Error.GetLastError() == Win32Error.ERROR_INSUFFICIENT_BUFFER);
				Assert.That(success);
				fmi = mem.ToStructure<FILEMUIINFO>();
				fmi.WriteValues();
			}
		}

		[Test]
		public void GetFileMUIInfoTest2()
		{
			var fmi = GetFileMUIInfo(MUI_QUERY.MUI_QUERY_CHECKSUM | MUI_QUERY.MUI_QUERY_LANGUAGE_NAME | MUI_QUERY.MUI_QUERY_RESOURCE_TYPES | MUI_QUERY.MUI_QUERY_TYPE,
				@"C:\Windows\explorer.exe");
			fmi.WriteValues();
		}

		[Test]
		public void GetFileMUIPathTest()
		{
			const string path = @"C:\Windows\RegEdit.exe";
			uint ll = 0, lp = 0;
			ulong en = 0;
			Assert.That(GetFileMUIPath(MUI_LANGUAGE_PATH.MUI_LANGUAGE_NAME, path, null, ref ll, null, ref lp, ref en), ResultIs.FailureCode(Win32Error.ERROR_INSUFFICIENT_BUFFER));
			StringBuilder sbl = new StringBuilder((int)ll), sbp = new StringBuilder((int)lp);
			while (GetFileMUIPath(MUI_LANGUAGE_PATH.MUI_LANGUAGE_NAME, path, sbl, ref ll, sbp, ref lp, ref en))
			{
				TestContext.WriteLine($"{sbl}; {sbp}");
			}
			Assert.That(Win32Error.GetLastError(), ResultIs.FailureCode(Win32Error.ERROR_NO_MORE_FILES));
		}

		[Test]
		public void GetGeoInfoExTest()
		{
			var sb = new StringBuilder(256);
			foreach (SYSGEOTYPE ev in Enum.GetValues(typeof(SYSGEOTYPE)))
			{
				if (GetGeoInfoEx("US", ev, sb, sb.Capacity) > 0)
					TestContext.WriteLine($"{ev}={sb}");
			}
		}

		[Test]
		public void GetGeoInfoTest()
		{
			var sb = new StringBuilder(256);
			foreach (SYSGEOTYPE ev in Enum.GetValues(typeof(SYSGEOTYPE)))
			{
				if (GetGeoInfo(0xf4, ev, sb, sb.Capacity, 0) > 0)
					TestContext.WriteLine($"{ev}={sb}");
			}
		}

		[Test]
		public void GetLocaleInfoExTest()
		{
			var sb = new StringBuilder(256);
			Assert.That(GetLocaleInfoEx(LOCALE_NAME_USER_DEFAULT, LCTYPE.LOCALE_SDAYNAME3, sb, sb.Capacity), ResultIs.Not.Value(0));
			Assert.That(sb.ToString(), Is.EqualTo("Wednesday"));

			using (var pVal = SafeHGlobalHandle.CreateFromStructure(16U))
			{
				Assert.That(GetLocaleInfoEx(LOCALE_NAME_USER_DEFAULT, LCTYPE.LOCALE_ITIME | LCTYPE.LOCALE_RETURN_NUMBER, pVal, 4 / StringHelper.GetCharSize()), ResultIs.Not.Value(0));
				Assert.That(pVal.ToStructure<uint>(), Is.Not.EqualTo(16));
			}
		}

		[Test]
		public void GetNLSVersionExTest()
		{
			var vi = NLSVERSIONINFOEX.Default;
			Assert.That(GetNLSVersionEx(SYSNLS_FUNCTION.COMPARE_STRING, LOCALE_NAME_USER_DEFAULT, ref vi), ResultIs.Successful);
			vi.WriteValues();
		}

		[Test]
		public void GetNLSVersionTest()
		{
			var vi = NLSVERSIONINFO.Default;
			Assert.That(GetNLSVersion(SYSNLS_FUNCTION.COMPARE_STRING, LOCALE_USER_DEFAULT, ref vi), ResultIs.Successful);
			vi.WriteValues();
		}

		[Test]
		public void GetNumberFormatExTest()
		{
			var sb = new StringBuilder(256);
			Assert.That(GetNumberFormatEx(LOCALE_NAME_USER_DEFAULT, LOCALE_FORMAT_FLAG.LOCALE_NOUSEROVERRIDE, null, IntPtr.Zero, sb, sb.Capacity), ResultIs.Successful);
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetNumberFormatTest()
		{
			var sb = new StringBuilder(256);
			Assert.That(GetNumberFormat(LOCALE_USER_DEFAULT, LOCALE_FORMAT_FLAG.LOCALE_NOUSEROVERRIDE, null, IntPtr.Zero, sb, sb.Capacity), ResultIs.Successful);
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetOEMCPTest()
		{
			Assert.That(GetOEMCP(), ResultIs.Not.Value(0));
		}

		[Test]
		public void GetSetCalendarInfoTest()
		{
			Assert.That(GetCalendarInfo(LOCALE_USER_DEFAULT, CALID.CAL_GREGORIAN_US, CALTYPE.CAL_ITWODIGITYEARMAX | CALTYPE.CAL_RETURN_NUMBER, default, 0, out var val), ResultIs.Not.Value(0));
			Assert.That(SetCalendarInfo(LOCALE_USER_DEFAULT, CALID.CAL_GREGORIAN_US, CALTYPE.CAL_ITWODIGITYEARMAX, $"{val}"), ResultIs.Successful);

			var sb = new StringBuilder(256);
			Assert.That(GetCalendarInfo(LOCALE_USER_DEFAULT, CALID.CAL_GREGORIAN_US, CALTYPE.CAL_SCALNAME, sb, sb.Capacity), ResultIs.Not.Value(0));
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetSetLocaleInfoTest()
		{
			var sb = new StringBuilder(256);
			Assert.That(GetLocaleInfo(LOCALE_USER_DEFAULT, LCTYPE.LOCALE_SDAYNAME3, sb, sb.Capacity), ResultIs.Not.Value(0));
			Assert.That(sb.ToString(), Is.EqualTo("Wednesday"));

			Assert.That(GetLocaleInfo(LOCALE_USER_DEFAULT, LCTYPE.LOCALE_STIMEFORMAT, sb, sb.Capacity), ResultIs.Not.Value(0));
			Assert.That(SetLocaleInfo(LOCALE_USER_DEFAULT, LCTYPE.LOCALE_STIMEFORMAT, sb.ToString()), ResultIs.Successful);

			using (var pVal = SafeHGlobalHandle.CreateFromStructure(16U))
			{
				Assert.That(GetLocaleInfo(LOCALE_USER_DEFAULT, LCTYPE.LOCALE_ITIME | LCTYPE.LOCALE_RETURN_NUMBER, pVal, 4 / StringHelper.GetCharSize()), ResultIs.Not.Value(0));
				Assert.That(pVal.ToStructure<uint>(), Is.Not.EqualTo(16));
			}
		}

		[Test]
		public void GetSetProcessPreferredUILanguagesTest()
		{
			Assert.That(() =>
			{
				var langs = GetProcessPreferredUILanguages(MUI_LANGUAGE_ENUM.MUI_LANGUAGE_ID).ToList();
				langs.WriteValues();
				langs.Add("en-UK");
				Assert.That(SetProcessPreferredUILanguages(MUI_LANGUAGE_ENUM.MUI_LANGUAGE_ID, langs.ToArray(), out var num), ResultIs.Successful);
			}, Throws.Nothing);
		}

		[Test]
		public void GetSetThreadLocaleTest()
		{
			Assert.That((uint)GetThreadLocale(), ResultIs.Not.Value(0));
			Assert.That(SetThreadLocale(GetThreadLocale()), ResultIs.Successful);
		}

		[Test]
		public void GetSetThreadPreferredUILanguagesTest()
		{
			Assert.That(() =>
			{
				var langs = GetThreadPreferredUILanguages(MUI_LANGUAGE_FILTER.MUI_LANGUAGE_NAME).ToList();
				langs.WriteValues();
				Assert.That(SetThreadPreferredUILanguages(0, null, out _), ResultIs.Successful);
				Assert.That(SetThreadPreferredUILanguages(MUI_LANGUAGE_FLAGS.MUI_LANGUAGE_NAME, langs.ToArray(), out var num), ResultIs.Successful);
			}, Throws.Nothing);
		}

		[Test]
		public void GetSetThreadUILanguageTest()
		{
			Assert.That(GetThreadUILanguage(), ResultIs.Not.Value(0U));
			Assert.That(() => SetThreadUILanguage(0), Throws.Nothing);
		}

		[Test]
		public void GetSetUserDefaultGeoNameTest()
		{
			var sb = new StringBuilder(256);
			Assert.That(GetUserDefaultGeoName(sb, sb.Capacity), ResultIs.Not.Value(0));
			TestContext.WriteLine(sb);
			Assert.That(SetUserGeoName(sb.ToString()), ResultIs.Successful);
		}

		[Test]
		public void GetSetUserGeoIDTest()
		{
			Assert.That(GetUserGeoID(SYSGEOCLASS.GEOCLASS_ALL), ResultIs.Value(GEOID_NOT_AVAILABLE));
			Assert.That(SetUserGeoID(0x9a55d40), ResultIs.Successful);
			//Assert.That(GetUserGeoID(SYSGEOCLASS.GEOCLASS_ALL), ResultIs.Value(0x9a55d40));
			Assert.That(SetUserGeoID(0xf4), ResultIs.Successful);
		}

		[Test]
		public void GetStringScriptsTest()
		{
			var l = GetStringScripts(GetStringScriptsFlag.GSS_ALLOW_INHERITED_COMMON, "Hello", -1, null, 0);
			Assert.That(l, ResultIs.Not.Value(0));
			var sb = new StringBuilder(l);
			Assert.That(GetStringScripts(GetStringScriptsFlag.GSS_ALLOW_INHERITED_COMMON, "Hello", -1, sb, sb.Capacity), ResultIs.Not.Value(0));
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetSystemDefaultLangIDTest()
		{
			Assert.That(GetSystemDefaultLangID(), ResultIs.Not.Value(0));
		}

		[Test]
		public void GetSystemDefaultLCIDTest()
		{
			Assert.That((uint)GetSystemDefaultLCID(), ResultIs.Not.Value(0U));
		}

		[Test]
		public void GetSystemDefaultLocaleNameTest()
		{
			var sb = new StringBuilder(256);
			Assert.That(GetSystemDefaultLocaleName(sb, sb.Capacity), ResultIs.Not.Value(0U));
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetSystemDefaultUILanguageTest()
		{
			Assert.That(GetSystemDefaultUILanguage(), ResultIs.Not.Value(0));
		}

		[Test]
		public void GetSystemPreferredUILanguagesTest()
		{
			Assert.That(() =>
			{
				GetSystemPreferredUILanguages(MUI_LANGUAGE_ENUM.MUI_LANGUAGE_NAME).WriteValues();
			}, Throws.Nothing);
		}

		[Test]
		public void GetUILanguageInfoTest()
		{
			var sz = 0U;
			var langs = new[] { "en-US" };
			Assert.That(GetUILanguageInfo(MUI_LANGUAGE_ENUM.MUI_LANGUAGE_NAME, langs, default, ref sz, out var attr), ResultIs.FailureCode(Win32Error.ERROR_INSUFFICIENT_BUFFER));
			using (var mem = new SafeHGlobalHandle(sz))
			{
				Assert.That(GetUILanguageInfo(MUI_LANGUAGE_ENUM.MUI_LANGUAGE_NAME, langs, mem, ref sz, out attr), ResultIs.Successful);
				TestContext.WriteLine(attr);
				TestContext.Write(string.Join("\n", mem.ToStringEnum(CharSet.Unicode)));
			}
		}

		[Test]
		public void GetUserDefaultLangIDTest()
		{
			Assert.That(GetUserDefaultLangID(), ResultIs.Not.Value(0));
		}

		[Test]
		public void GetUserDefaultLCIDTest()
		{
			Assert.That((uint)GetUserDefaultLCID(), ResultIs.Not.Value(0));
		}

		[Test]
		public void GetUserDefaultLocaleNameTest()
		{
			var sb = new StringBuilder(256);
			Assert.That(GetUserDefaultLocaleName(sb, sb.Capacity), ResultIs.Not.Value(0));
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetUserDefaultUILanguageTest()
		{
			Assert.That(GetUserDefaultUILanguage(), ResultIs.Not.Value(0));
		}

		[Test]
		public void GetUserPreferredUILanguagesTest()
		{
			Assert.That(() =>
			{
				GetUserPreferredUILanguages(MUI_LANGUAGE_ENUM.MUI_LANGUAGE_ID).WriteValues();
			}, Throws.Nothing);
		}

		[Test]
		public void IdnTest()
		{
			const string str = "&#1088;&#1091;&#1089;&#1089;&#1082;&#1080;&#1081;.ExAmPlE.cOm";

			var sb = new StringBuilder(256);
			Assert.That(IdnToAscii(0, str, -1, sb, sb.Capacity), ResultIs.Not.Value(0));
			TestContext.WriteLine(sb);
			Assert.That(IdnToNameprepUnicode(0, str, -1, sb, sb.Capacity), ResultIs.Not.Value(0));
			TestContext.WriteLine(sb);
			Assert.That(IdnToUnicode(0, str, -1, sb, sb.Capacity), ResultIs.Not.Value(0));
			TestContext.WriteLine(sb);
		}

		[Test]
		public void IsDBCSLeadByteExTest()
		{
			for (byte i = byte.MinValue; i < byte.MaxValue; i++)
			{
				IsDBCSLeadByteEx(CP_ACP, i);
				Assert.That(Win32Error.GetLastError(), ResultIs.Successful);
			}
		}

		[Test]
		public void IsDBCSLeadByteTest()
		{
			for (byte i = byte.MinValue; i < byte.MaxValue; i++)
			{
				IsDBCSLeadByte(i);
				Assert.That(Win32Error.GetLastError, ResultIs.Successful);
			}
		}

		[Test]
		public void IsNLSDefinedStringTest()
		{
			IsNLSDefinedString(SYSNLS_FUNCTION.COMPARE_STRING, 0, IntPtr.Zero, "1\xffff3", -1);
			Assert.That(Win32Error.GetLastError(), ResultIs.Successful);

			var vi = NLSVERSIONINFO.Default;
			GetNLSVersion(SYSNLS_FUNCTION.COMPARE_STRING, LOCALE_USER_DEFAULT, ref vi);
			IsNLSDefinedString(SYSNLS_FUNCTION.COMPARE_STRING, 0, ref vi, "1\xffff3", -1);
			Assert.That(Win32Error.GetLastError(), ResultIs.Successful);
		}

		[Test]
		public void IsNormalizedStringTest()
		{
			const string str = "T\u00e8st string \uFF54\uFF4F n\u00f8rm\u00e4lize";
			foreach (NORM_FORM nf in Enum.GetValues(typeof(NORM_FORM)))
			{
				if (nf == 0) continue;
				if (!IsNormalizedString(nf, str))
				{
					var sb = new StringBuilder(256);
					Assert.That(NormalizeString(nf, str, -1, sb, sb.Capacity), ResultIs.Not.Value(0));
					TestContext.WriteLine($"{nf}: {sb}");
				}
			}
		}

		[Test]
		public void IsValidCodePageTest()
		{
			Assert.That(IsValidCodePage(GetACP()), Is.True);
		}

		[Test]
		public void IsValidLanguageGroupTest()
		{
			Assert.That(IsValidLanguageGroup(EnumSystemLanguageGroups().First().LanguageGroup), Is.True);
		}

		[Test]
		public void IsValidLocaleNameTest()
		{
			var sb = new StringBuilder(256);
			GetUserDefaultLocaleName(sb, sb.Capacity);
			Assert.That(IsValidLocaleName(sb.ToString()), Is.True);
		}

		[Test]
		public void IsValidLocaleTest()
		{
			Assert.That(IsValidLocale(GetThreadLocale(), LCID_FLAGS.LCID_INSTALLED), Is.True);
		}

		[Test]
		public void IsValidNLSVersionTest()
		{
			var sb = new StringBuilder(256);
			GetUserDefaultLocaleName(sb, sb.Capacity);

			var vi = NLSVERSIONINFOEX.Default;
			GetNLSVersionEx(SYSNLS_FUNCTION.COMPARE_STRING, sb.ToString(), ref vi);

			Assert.That(IsValidNLSVersion(SYSNLS_FUNCTION.COMPARE_STRING, sb.ToString(), ref vi), Is.True);
		}

		[Test]
		public void LCIDToLocaleNameTest()
		{
			var sb = new StringBuilder(256);
			Assert.That(LCIDToLocaleName(LOCALE_USER_DEFAULT, sb, sb.Capacity, 0), ResultIs.Not.Value(0));
			TestContext.WriteLine(sb);
		}

		[Test]
		public void LCMapStringExTest()
		{
			const string str = "T\u00e8st string \uFF54\uFF4F n\u00f8rm\u00e4lize";
			var sb = new StringBuilder(256);
			Assert.That(LCMapStringEx(LOCALE_NAME_USER_DEFAULT, (uint)LCMAP.LCMAP_UPPERCASE, str, -1, sb, sb.Capacity), ResultIs.Not.Value(0));
			TestContext.WriteLine(sb);
		}

		[Test]
		public void LCMapStringTest()
		{
			const string str = "T\u00e8st string \uFF54\uFF4F n\u00f8rm\u00e4lize";
			var sb = new StringBuilder(256);
			Assert.That(LCMapString(LOCALE_USER_DEFAULT, (uint)LCMAP.LCMAP_UPPERCASE, str, -1, sb, sb.Capacity), ResultIs.Not.Value(0));
			TestContext.WriteLine(sb);
		}

		[Test]
		public void LocaleNameToLCIDTest()
		{
			Assert.That((uint)LocaleNameToLCID(LOCALE_NAME_USER_DEFAULT, 0), ResultIs.Not.Value(0));
		}

		[Test]
		public void ResolveLocaleNameTest()
		{
			var sb = new StringBuilder(256);
			Assert.That(ResolveLocaleName("en-FJ", sb, sb.Capacity), ResultIs.Successful);
			TestContext.WriteLine(sb);
		}

		[Test]
		public void UpdateCalendarDayOfWeekTest()
		{
			var dt = DateTime.Today;
			var cdt = new CALDATETIME { CalId = CALID.CAL_GREGORIAN, Year = (uint)dt.Year, Month = (uint)dt.Month, Day = (uint)dt.Day };
			Assert.That(UpdateCalendarDayOfWeek(ref cdt), ResultIs.Failure);
			//Assert.That(cdt.DayOfWeek, Is.EqualTo((uint)dt.DayOfWeek));
		}

		[Test]
		public void VerifyScriptsTest()
		{
			// Get the expected scripts
			StringBuilder localeScripts = new StringBuilder(256), stringScripts = new StringBuilder(256);
			Assert.That(GetLocaleInfoEx(LOCALE_NAME_USER_DEFAULT, LCTYPE.LOCALE_SSCRIPTS, localeScripts, localeScripts.Capacity), ResultIs.Not.Value(0));

			// Get the actual scripts. We're expecting inherited and common characters (like ,:, etc.)
			const string strTest = "This string has &#1057;&#1091;&#1075;&#1110;&#1472;&#1472;&#1110;&#1089;, Hebrew, and GR&#917;&#917;&#922; &#21313; Chinese &#24037;&#21475; and PUA &#63705; characters.  Depending on font it may look like Latin";
			Assert.That(GetStringScripts(0, strTest, -1, stringScripts, stringScripts.Capacity), ResultIs.Not.Value(0));

			// Test the output
			Assert.That(VerifyScripts(0, localeScripts.ToString(), -1, stringScripts.ToString(), -1), ResultIs.Successful);
		}
	}
}