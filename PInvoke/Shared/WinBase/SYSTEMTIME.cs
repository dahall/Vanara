using System.Diagnostics.CodeAnalysis;

namespace Vanara.PInvoke;

/// <summary>
/// Specifies a date and time, using individual members for the month, day, year, weekday, hour, minute, second, and millisecond. The
/// time is either in coordinated universal time (UTC) or local time, depending on the function that is being called.
/// </summary>
[PInvokeData("winbase.h")]
[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct SYSTEMTIME : IEquatable<SYSTEMTIME>, IComparable<SYSTEMTIME>
{
	/// <summary>The year. The valid values for this member are 1601 through 30827.</summary>
	public ushort wYear;

	/// <summary>
	/// The month. This member can be one of the following values.
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>January</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>February</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>March</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>April</term>
	/// </item>
	/// <item>
	/// <term>5</term>
	/// <term>May</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>June</term>
	/// </item>
	/// <item>
	/// <term>7</term>
	/// <term>July</term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>August</term>
	/// </item>
	/// <item>
	/// <term>9</term>
	/// <term>September</term>
	/// </item>
	/// <item>
	/// <term>10</term>
	/// <term>October</term>
	/// </item>
	/// <item>
	/// <term>11</term>
	/// <term>November</term>
	/// </item>
	/// <item>
	/// <term>12</term>
	/// <term>December</term>
	/// </item>
	/// </list>
	/// </summary>
	public ushort wMonth;

	/// <summary>
	/// The day of the week. This member can be one of the following values.
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Sunday</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>Monday</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Tuesday</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>Wednesday</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>Thursday</term>
	/// </item>
	/// <item>
	/// <term>5</term>
	/// <term>Friday</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>Saturday</term>
	/// </item>
	/// </list>
	/// </summary>
	public ushort wDayOfWeek;

	/// <summary>The day of the month. The valid values for this member are 1 through 31.</summary>
	public ushort wDay;

	/// <summary>The hour. The valid values for this member are 0 through 23.</summary>
	public ushort wHour;

	/// <summary>The minute. The valid values for this member are 0 through 59.</summary>
	public ushort wMinute;

	/// <summary>The second. The valid values for this member are 0 through 59.</summary>
	public ushort wSecond;

	/// <summary>The millisecond. The valid values for this member are 0 through 999.</summary>
	public ushort wMilliseconds;

	private static readonly int[] DaysToMonth365 = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };
	private static readonly int[] DaysToMonth366 = { 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366 };

	/// <summary>Initializes a new instance of the <see cref="SYSTEMTIME"/> struct with a <see cref="DateTime"/>.</summary>
	/// <param name="dt">The <see cref="DateTime"/> value.</param>
	/// <param name="toKind">Indicates whether the <see cref="SYSTEMTIME"/> should represent the local, universal or unknown time.</param>
	/// <exception cref="ArgumentOutOfRangeException">dt - Year value must be 1601 through 30827</exception>
	public SYSTEMTIME(DateTime dt, DateTimeKind toKind = DateTimeKind.Unspecified)
	{
		dt = toKind == DateTimeKind.Local ? dt.ToLocalTime() : (toKind == DateTimeKind.Utc ? dt.ToUniversalTime() : dt);
		wYear = Convert.ToUInt16(dt.Year);
		if (wYear < 1601) throw new ArgumentOutOfRangeException(nameof(dt), @"Year value must be 1601 through 30827");
		wMonth = Convert.ToUInt16(dt.Month);
		wDayOfWeek = Convert.ToUInt16(dt.DayOfWeek);
		wDay = Convert.ToUInt16(dt.Day);
		wHour = Convert.ToUInt16(dt.Hour);
		wMinute = Convert.ToUInt16(dt.Minute);
		wSecond = Convert.ToUInt16(dt.Second);
		wMilliseconds = Convert.ToUInt16(dt.Millisecond);
	}

	/// <summary>Initializes a new instance of the <see cref="SYSTEMTIME"/> struct.</summary>
	/// <param name="year">The year. The valid values for this member are 1601 through 30827.</param>
	/// <param name="month">
	/// The month. This member can be one of the following values.
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>January</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>February</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>March</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>April</term>
	/// </item>
	/// <item>
	/// <term>5</term>
	/// <term>May</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>June</term>
	/// </item>
	/// <item>
	/// <term>7</term>
	/// <term>July</term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>August</term>
	/// </item>
	/// <item>
	/// <term>9</term>
	/// <term>September</term>
	/// </item>
	/// <item>
	/// <term>10</term>
	/// <term>October</term>
	/// </item>
	/// <item>
	/// <term>11</term>
	/// <term>November</term>
	/// </item>
	/// <item>
	/// <term>12</term>
	/// <term>December</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="day">The day of the month. The valid values for this member are 1 through 31.</param>
	/// <param name="hour">The hour. The valid values for this member are 0 through 23.</param>
	/// <param name="minute">The minute. The valid values for this member are 0 through 59.</param>
	/// <param name="second">The second. The valid values for this member are 0 through 59.</param>
	/// <param name="millisecond">The millisecond. The valid values for this member are 0 through 999.</param>
	public SYSTEMTIME(ushort year, ushort month, ushort day, ushort hour = 0, ushort minute = 0, ushort second = 0,
		ushort millisecond = 0)
	{
		if (year is < 1601 and not 0) throw new ArgumentOutOfRangeException(nameof(year), @"year value must be 1601 through 30827 or 0");
		wYear = year;
		if (month is < 1 or > 12)
			throw new ArgumentOutOfRangeException(nameof(month), @"month value must be 1 through 12");
		wMonth = month;
		if (day is < 1 or > 31) throw new ArgumentOutOfRangeException(nameof(day), @"day value must be 1 through 31");
		wDay = day;
		if (hour > 23) throw new ArgumentOutOfRangeException(nameof(hour), @"hour value must be 0 through 23");
		wHour = hour;
		if (minute > 59) throw new ArgumentOutOfRangeException(nameof(minute), @"minute value must be 0 through 59");
		wMinute = minute;
		if (second > 59) throw new ArgumentOutOfRangeException(nameof(second), @"second value must be 0 through 59");
		wSecond = second;
		if (millisecond > 999)
			throw new ArgumentOutOfRangeException(nameof(millisecond), @"millisecond value must be 0 through 999");
		wMilliseconds = millisecond;
		wDayOfWeek = 0;
		//wDayOfWeek = (ushort)ComputedDayOfWeek;
	}

	/// <summary>Gets or sets the day of the week.</summary>
	/// <value>The day of the week.</value>
	[ExcludeFromCodeCoverage]
	public DayOfWeek DayOfWeek
	{
		get => (DayOfWeek)wDayOfWeek;
		set => wDayOfWeek = (ushort)value;
	}

	/// <summary>Gets the number of ticks that represent the date and time of this instance.</summary>
	public long Ticks
	{
		get
		{
			if (!CheckBounds(wYear, wMonth, wDay, wHour, wMinute, wSecond, wMilliseconds) || ToUInt64 == 0) return 0;
			var days = IsLeapYear(wYear) ? DaysToMonth366 : DaysToMonth365;
			var y = wYear - 1;
			var n = y * 365 + y / 4 - y / 100 + y / 400 + days[wMonth - 1] + wDay - 1;
			return new TimeSpan(n, wHour, wMinute, wSecond, wMilliseconds).Ticks;
		}
	}

	/// <summary>Indicates if two <see cref="SYSTEMTIME"/> values are equal.</summary>
	/// <param name="s1">The first <see cref="SYSTEMTIME"/> value.</param>
	/// <param name="s2">The second <see cref="SYSTEMTIME"/> value.</param>
	/// <returns><c>true</c> if both values are equal; otherwise <c>false</c>.</returns>
	public static bool operator ==(SYSTEMTIME s1, SYSTEMTIME s2) => s1.wYear == s2.wYear && s1.wMonth == s2.wMonth &&
																	s1.wDay == s2.wDay &&
																	s1.wHour == s2.wHour && s1.wMinute == s2.wMinute &&
																	s1.wSecond == s2.wSecond && s1.wMilliseconds ==
																	s2.wMilliseconds;

	/// <summary>Indicates if two <see cref="SYSTEMTIME"/> values are not equal.</summary>
	/// <param name="s1">The first <see cref="SYSTEMTIME"/> value.</param>
	/// <param name="s2">The second <see cref="SYSTEMTIME"/> value.</param>
	/// <returns><c>true</c> if both values are not equal; otherwise <c>false</c>.</returns>
	public static bool operator !=(SYSTEMTIME s1, SYSTEMTIME s2) => !(s1 == s2);

	/// <summary>Determines whether one specified <see cref="SYSTEMTIME"/> is greater than another specified <see cref="SYSTEMTIME"/>.</summary>
	/// <param name="s1">The first <see cref="SYSTEMTIME"/> value.</param>
	/// <param name="s2">The second <see cref="SYSTEMTIME"/> value.</param>
	/// <returns><c>true</c> if <paramref name="s1"/> is greater than <paramref name="s2"/>; otherwise, <c>false</c>.</returns>
	public static bool operator >(SYSTEMTIME s1, SYSTEMTIME s2) => s1.ToUInt64 > s2.ToUInt64;

	/// <summary>Determines whether one specified <see cref="SYSTEMTIME"/> is greater than or equal to another specified <see cref="SYSTEMTIME"/>.</summary>
	/// <param name="s1">The first <see cref="SYSTEMTIME"/> value.</param>
	/// <param name="s2">The second <see cref="SYSTEMTIME"/> value.</param>
	/// <returns><c>true</c> if <paramref name="s1"/> is greater than or equal to <paramref name="s2"/>; otherwise, <c>false</c>.</returns>
	public static bool operator >=(SYSTEMTIME s1, SYSTEMTIME s2) => s1.ToUInt64 >= s2.ToUInt64;

	/// <summary>Determines whether one specified <see cref="SYSTEMTIME"/> is less than another specified <see cref="SYSTEMTIME"/>.</summary>
	/// <param name="s1">The first <see cref="SYSTEMTIME"/> value.</param>
	/// <param name="s2">The second <see cref="SYSTEMTIME"/> value.</param>
	/// <returns><c>true</c> if <paramref name="s1"/> is less than <paramref name="s2"/>; otherwise, <c>false</c>.</returns>
	public static bool operator <(SYSTEMTIME s1, SYSTEMTIME s2) => s1.ToUInt64 < s2.ToUInt64;

	/// <summary>Determines whether one specified <see cref="SYSTEMTIME"/> is less than or equal to another specified <see cref="SYSTEMTIME"/>.</summary>
	/// <param name="s1">The first <see cref="SYSTEMTIME"/> value.</param>
	/// <param name="s2">The second <see cref="SYSTEMTIME"/> value.</param>
	/// <returns><c>true</c> if <paramref name="s1"/> is less than or equal to <paramref name="s2"/>; otherwise, <c>false</c>.</returns>
	public static bool operator <=(SYSTEMTIME s1, SYSTEMTIME s2) => s1.ToUInt64 <= s2.ToUInt64;

	/// <summary>The minimum value supported by <see cref="SYSTEMTIME"/>.</summary>
	public static readonly SYSTEMTIME MinValue = new(1601, 1, 1);

	/// <summary>The maximum value supported by <see cref="SYSTEMTIME"/>.</summary>
	public static readonly SYSTEMTIME MaxValue = new(30827, 12, 31, 23, 59, 59, 999);

	/// <summary>Compares two instances of <see cref="SYSTEMTIME"/> and returns an integer that indicates whether the first instance is earlier than, the same as, or later than the second instance.</summary>
	/// <param name="t1">The first object to compare. </param>
	/// <param name="t2">The second object to compare. </param>
	/// <returns>A signed number indicating the relative values of t1 and t2.
	/// <list type="table">
	/// <listheader><term>Value Type</term><term>Condition</term></listheader>
	/// <item><term>Less than zero</term><term>t1 is earlier than t2.</term></item>
	/// <item><term>Zero</term><term>t1 is the same as t2.</term></item>
	/// <item><term>Greater than zero</term><term>t1 is later than t2.</term></item>
	/// </list>
	///</returns>
	public static int Compare(SYSTEMTIME t1, SYSTEMTIME t2)
	{
		var ticks1 = t1.ToUInt64;
		var ticks2 = t2.ToUInt64;
		return ticks1 > ticks2 ? 1 : ticks1 < ticks2 ? -1 : 0;
	}

	/// <summary>Compares the current object with another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>
	/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value
	/// Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref
	/// name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.
	/// </returns>
	public int CompareTo(SYSTEMTIME other) => Compare(this, other);

	/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	public bool Equals(SYSTEMTIME other) => this == other;

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override bool Equals(object? obj) => base.Equals(obj);

	/// <summary>Returns a hash code for this instance.</summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	public override int GetHashCode()
	{
		var u = ToUInt64;
		return unchecked((int)u) ^ (int)(u >> 32);
	}

	/// <summary>Converts this <see cref="SYSTEMTIME"/> instance to a <see cref="DateTime"/> instance.</summary>
	/// <param name="kind">Indicates whether this <see cref="SYSTEMTIME"/> instance is local, universal or neither.</param>
	/// <returns>An equivalent <see cref="DateTime"/> value.</returns>
	public DateTime ToDateTime(DateTimeKind kind)
	{
		if (wYear == 0 || this == MinValue)
			return DateTime.MinValue;
		return this == MaxValue ? DateTime.MaxValue : new DateTime(wYear, wMonth, wDay, wHour, wMinute, wSecond, wMilliseconds, kind);
	}

	/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
	/// <returns>A <see cref="string"/> that represents this instance.</returns>
	public override string ToString() => ToString(DateTimeKind.Unspecified, null, null);

	/// <summary>Returns a <see cref="string" /> that represents this instance.</summary>
	/// <param name="kind">One of the enumeration values that indicates whether the new object represents local time, UTC, or neither.</param>
	/// <param name="format">A standard or custom date and time format string.</param>
	/// <param name="provider">An object that supplies culture-specific formatting information.</param>
	/// <returns>A <see cref="string" /> that represents this instance.</returns>
	public string ToString(DateTimeKind kind, string? format, IFormatProvider? provider) => ToDateTime(kind).ToString(format, provider);

	private static bool CheckBounds(ushort year, ushort month, ushort day, ushort hour, ushort minute, ushort second, ushort miillisecond) =>
		year is not < 1601 and not > 30827 && month is not < 1 and not > 12 && day is not < 1 and not > 31 &&
		hour is not < 0 and not > 23 && minute is not < 0 and not > 59 && second is not < 0 and not > 59 &&
		miillisecond is not < 0 and not > 999;

	[ExcludeFromCodeCoverage]
	private DayOfWeek ComputedDayOfWeek => (DayOfWeek)((Ticks / 864000000000 + 1) % 7);

	private readonly ulong ToUInt64 => ((ulong)wYear << 36) | (((ulong)wMonth & 0x000f) << 32) |
								(((ulong)wDay & 0x001f) << 27) | (((ulong)wHour & 0x000f) << 22) |
								(((ulong)wMinute & 0x003f) << 16) | (((ulong)wSecond & 0x003f) << 10) |
								((ulong)wMilliseconds & 0x3ff);

	private static bool IsLeapYear(ushort year) => year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
}

/// <summary>
/// Specifies a date and time, using individual members for the month, day, year, weekday, hour, minute, second, and millisecond. The
/// time is either in coordinated universal time (UTC) or local time, depending on the function that is being called.
/// </summary>
[PInvokeData("winbase.h")]
[StructLayout(LayoutKind.Sequential, Pack = 2)]
public class PSYSTEMTIME : IEquatable<SYSTEMTIME>, IComparable<SYSTEMTIME>, IEquatable<PSYSTEMTIME>, IComparable<PSYSTEMTIME>
{
	private SYSTEMTIME st;

	/// <summary>The year. The valid values for this member are 1601 through 30827.</summary>
	public ushort wYear { get => st.wYear; set => st.wYear = value; }

	/// <summary>
	/// The month. This member can be one of the following values.
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>January</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>February</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>March</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>April</term>
	/// </item>
	/// <item>
	/// <term>5</term>
	/// <term>May</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>June</term>
	/// </item>
	/// <item>
	/// <term>7</term>
	/// <term>July</term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>August</term>
	/// </item>
	/// <item>
	/// <term>9</term>
	/// <term>September</term>
	/// </item>
	/// <item>
	/// <term>10</term>
	/// <term>October</term>
	/// </item>
	/// <item>
	/// <term>11</term>
	/// <term>November</term>
	/// </item>
	/// <item>
	/// <term>12</term>
	/// <term>December</term>
	/// </item>
	/// </list>
	/// </summary>
	public ushort wMonth { get => st.wMonth; set => st.wMonth = value; }

	/// <summary>
	/// The day of the week. This member can be one of the following values.
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Sunday</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>Monday</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Tuesday</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>Wednesday</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>Thursday</term>
	/// </item>
	/// <item>
	/// <term>5</term>
	/// <term>Friday</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>Saturday</term>
	/// </item>
	/// </list>
	/// </summary>
	public ushort wDayOfWeek { get => st.wDayOfWeek; set => st.wDayOfWeek = value; }

	/// <summary>The day of the month. The valid values for this member are 1 through 31.</summary>
	public ushort wDay { get => st.wDay; set => st.wDay = value; }

	/// <summary>The hour. The valid values for this member are 0 through 23.</summary>
	public ushort wHour { get => st.wHour; set => st.wHour = value; }

	/// <summary>The minute. The valid values for this member are 0 through 59.</summary>
	public ushort wMinute { get => st.wMinute; set => st.wMinute = value; }

	/// <summary>The second. The valid values for this member are 0 through 59.</summary>
	public ushort wSecond { get => st.wSecond; set => st.wSecond = value; }

	/// <summary>The millisecond. The valid values for this member are 0 through 999.</summary>
	public ushort wMilliseconds { get => st.wMilliseconds; set => st.wMilliseconds = value; }

	/// <summary>Initializes a new instance of the <see cref="SYSTEMTIME"/> struct with a <see cref="DateTime"/>.</summary>
	/// <param name="dt">The <see cref="DateTime"/> value.</param>
	/// <param name="toKind">Indicates whether the <see cref="SYSTEMTIME"/> should represent the local, universal or unknown time.</param>
	/// <exception cref="ArgumentOutOfRangeException">dt - Year value must be 1601 through 30827</exception>
	public PSYSTEMTIME(DateTime dt, DateTimeKind toKind = DateTimeKind.Unspecified) => st = new SYSTEMTIME(dt, toKind);

	/// <summary>Initializes a new instance of the <see cref="SYSTEMTIME"/> struct.</summary>
	/// <param name="year">The year. The valid values for this member are 1601 through 30827.</param>
	/// <param name="month">
	/// The month. This member can be one of the following values.
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>January</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>February</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>March</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>April</term>
	/// </item>
	/// <item>
	/// <term>5</term>
	/// <term>May</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>June</term>
	/// </item>
	/// <item>
	/// <term>7</term>
	/// <term>July</term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>August</term>
	/// </item>
	/// <item>
	/// <term>9</term>
	/// <term>September</term>
	/// </item>
	/// <item>
	/// <term>10</term>
	/// <term>October</term>
	/// </item>
	/// <item>
	/// <term>11</term>
	/// <term>November</term>
	/// </item>
	/// <item>
	/// <term>12</term>
	/// <term>December</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="day">The day of the month. The valid values for this member are 1 through 31.</param>
	/// <param name="hour">The hour. The valid values for this member are 0 through 23.</param>
	/// <param name="minute">The minute. The valid values for this member are 0 through 59.</param>
	/// <param name="second">The second. The valid values for this member are 0 through 59.</param>
	/// <param name="millisecond">The millisecond. The valid values for this member are 0 through 999.</param>
	public PSYSTEMTIME(ushort year, ushort month, ushort day, ushort hour = 0, ushort minute = 0, ushort second = 0,
		ushort millisecond = 0) => st = new SYSTEMTIME(year, month, day, hour, minute, second, millisecond);

	/// <summary>Initializes a new instance of the <see cref="PSYSTEMTIME"/> class.</summary>
	/// <param name="st">The <see cref="SYSTEMTIME"/> instance.</param>
	public PSYSTEMTIME(SYSTEMTIME st) => this.st = st;

	/// <summary>Gets or sets the day of the week.</summary>
	/// <value>The day of the week.</value>
	[ExcludeFromCodeCoverage]
	public DayOfWeek DayOfWeek
	{
		get => st.DayOfWeek;
		set => st.DayOfWeek = value;
	}

	/// <summary>Gets the number of ticks that represent the date and time of this instance.</summary>
	public long Ticks => st.Ticks;

	/// <summary>Indicates if two <see cref="PSYSTEMTIME"/> values are equal.</summary>
	/// <param name="s1">The first <see cref="PSYSTEMTIME"/> value.</param>
	/// <param name="s2">The second <see cref="PSYSTEMTIME"/> value.</param>
	/// <returns><c>true</c> if both values are equal; otherwise <c>false</c>.</returns>
	public static bool operator ==(PSYSTEMTIME? s1, PSYSTEMTIME? s2) => s1 is null ? s2 is null : s1.Equals(s2);

	/// <summary>Indicates if two <see cref="PSYSTEMTIME"/> values are not equal.</summary>
	/// <param name="s1">The first <see cref="PSYSTEMTIME"/> value.</param>
	/// <param name="s2">The second <see cref="PSYSTEMTIME"/> value.</param>
	/// <returns><c>true</c> if both values are not equal; otherwise <c>false</c>.</returns>
	public static bool operator !=(PSYSTEMTIME? s1, PSYSTEMTIME? s2) => !(s1 == s2);

	/// <summary>Determines whether one specified <see cref="PSYSTEMTIME"/> is greater than another specified <see cref="PSYSTEMTIME"/>.</summary>
	/// <param name="s1">The first <see cref="PSYSTEMTIME"/> value.</param>
	/// <param name="s2">The second <see cref="PSYSTEMTIME"/> value.</param>
	/// <returns><c>true</c> if <paramref name="s1"/> is greater than <paramref name="s2"/>; otherwise, <c>false</c>.</returns>
	public static bool operator >(PSYSTEMTIME? s1, PSYSTEMTIME? s2) => Compare(s1, s2) > 0;

	/// <summary>Determines whether one specified <see cref="PSYSTEMTIME"/> is greater than or equal to another specified <see cref="PSYSTEMTIME"/>.</summary>
	/// <param name="s1">The first <see cref="PSYSTEMTIME"/> value.</param>
	/// <param name="s2">The second <see cref="PSYSTEMTIME"/> value.</param>
	/// <returns><c>true</c> if <paramref name="s1"/> is greater than or equal to <paramref name="s2"/>; otherwise, <c>false</c>.</returns>
	public static bool operator >=(PSYSTEMTIME? s1, PSYSTEMTIME? s2) => Compare(s1, s2) >= 0;

	/// <summary>Determines whether one specified <see cref="PSYSTEMTIME"/> is less than another specified <see cref="PSYSTEMTIME"/>.</summary>
	/// <param name="s1">The first <see cref="PSYSTEMTIME"/> value.</param>
	/// <param name="s2">The second <see cref="PSYSTEMTIME"/> value.</param>
	/// <returns><c>true</c> if <paramref name="s1"/> is less than <paramref name="s2"/>; otherwise, <c>false</c>.</returns>
	public static bool operator <(PSYSTEMTIME? s1, PSYSTEMTIME? s2) => Compare(s1, s2) < 0;

	/// <summary>Determines whether one specified <see cref="PSYSTEMTIME"/> is less than or equal to another specified <see cref="PSYSTEMTIME"/>.</summary>
	/// <param name="s1">The first <see cref="PSYSTEMTIME"/> value.</param>
	/// <param name="s2">The second <see cref="PSYSTEMTIME"/> value.</param>
	/// <returns><c>true</c> if <paramref name="s1"/> is less than or equal to <paramref name="s2"/>; otherwise, <c>false</c>.</returns>
	public static bool operator <=(PSYSTEMTIME? s1, PSYSTEMTIME? s2) => Compare(s1, s2) <= 0;

	/// <summary>The minimum value supported by <see cref="PSYSTEMTIME"/>.</summary>
	public static readonly PSYSTEMTIME MinValue = new(SYSTEMTIME.MinValue);

	/// <summary>The maximum value supported by <see cref="PSYSTEMTIME"/>.</summary>
	public static readonly PSYSTEMTIME MaxValue = new(SYSTEMTIME.MaxValue);

	/// <summary>Performs an implicit conversion from <see cref="PSYSTEMTIME"/> to <see cref="SYSTEMTIME"/>.</summary>
	/// <param name="st">The <see cref="PSYSTEMTIME"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator SYSTEMTIME(PSYSTEMTIME? st) => st?.st ?? default;

	/// <summary>Performs an implicit conversion from <see cref="SYSTEMTIME"/> to <see cref="PSYSTEMTIME"/>.</summary>
	/// <param name="st">The <see cref="SYSTEMTIME"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator PSYSTEMTIME(SYSTEMTIME st) => new(st);

	/// <summary>Compares two instances of <see cref="PSYSTEMTIME"/> and returns an integer that indicates whether the first instance is earlier than, the same as, or later than the second instance.</summary>
	/// <param name="s1">The first object to compare. </param>
	/// <param name="s2">The second object to compare. </param>
	/// <returns>A signed number indicating the relative values of t1 and t2.
	/// <list type="table">
	/// <listheader><term>Value Type</term><term>Condition</term></listheader>
	/// <item><term>Less than zero</term><term>t1 is earlier than t2.</term></item>
	/// <item><term>Zero</term><term>t1 is the same as t2.</term></item>
	/// <item><term>Greater than zero</term><term>t1 is later than t2.</term></item>
	/// </list>
	///</returns>
	public static int Compare(PSYSTEMTIME? s1, PSYSTEMTIME? s2) => s1 is null ? s2 is null ? 0 : -1 : s1.CompareTo(s2);

	/// <summary>Compares the current object with another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>
	/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value
	/// Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref
	/// name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.
	/// </returns>
	public int CompareTo(PSYSTEMTIME? other) => other is null ? 1 : st.CompareTo(other.st);

	/// <summary>Compares the current object with another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>
	/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value
	/// Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref
	/// name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.
	/// </returns>
	public int CompareTo(SYSTEMTIME other) => st.CompareTo(other);

	/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	public bool Equals(PSYSTEMTIME? other) => other is not null && (ReferenceEquals(this, other) || st.Equals(other.st));

	/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	public bool Equals(SYSTEMTIME other) => st.Equals(other);

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override bool Equals(object? obj) => Equals(obj as PSYSTEMTIME);

	/// <summary>Returns a hash code for this instance.</summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	public override int GetHashCode() => st.GetHashCode();

	/// <summary>Converts this <see cref="SYSTEMTIME"/> instance to a <see cref="DateTime"/> instance.</summary>
	/// <param name="kind">Indicates whether this <see cref="SYSTEMTIME"/> instance is local, universal or neither.</param>
	/// <returns>An equivalent <see cref="DateTime"/> value.</returns>
	public DateTime ToDateTime(DateTimeKind kind) => st.ToDateTime(kind);

	/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
	/// <returns>A <see cref="string"/> that represents this instance.</returns>
	public override string ToString() => st.ToString();

	/// <summary>Returns a <see cref="string" /> that represents this instance.</summary>
	/// <param name="kind">One of the enumeration values that indicates whether the new object represents local time, UTC, or neither.</param>
	/// <param name="format">A standard or custom date and time format string.</param>
	/// <param name="provider">An object that supplies culture-specific formatting information.</param>
	/// <returns>A <see cref="string" /> that represents this instance.</returns>
	public string ToString(DateTimeKind kind, string? format, IFormatProvider? provider) => st.ToString(kind, format, provider);
}