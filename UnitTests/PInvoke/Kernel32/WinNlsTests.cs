using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class WinNlsTests
	{
		[Test]
		public void EnumCalendarInfoTest()
		{
			if (!EnumCalendarInfo(Proc, LOCALE_USER_DEFAULT, ENUM_ALL_CALENDARS, CALTYPE.CAL_RETURN_NUMBER | CALTYPE.CAL_ITWODIGITYEARMAX))
				Win32Error.ThrowLastError();

			bool Proc(string lpCalendarInfoString) => true;
		}
	}
}