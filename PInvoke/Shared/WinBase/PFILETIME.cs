using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static Vanara.Extensions.FileTimeExtensions;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke;

/// <summary>
/// Represents a pointer to a <see cref="FILETIME"/> structure which holds the number of 100-nanosecond intervals since January 1, 1601. This
/// structure is a 64-bit value.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class PFILETIME : IEquatable<PFILETIME>, IEquatable<FILETIME>, IEquatable<DateTime>, IComparable<FILETIME>, IComparable<PFILETIME>
{
	/// <summary>The maximum value supported by <see cref="FILETIME"/>.</summary>
	public static readonly PFILETIME MaxValue = new(ulong.MaxValue);

	/// <summary>The minimum value supported by <see cref="FILETIME"/>.</summary>
	public static readonly PFILETIME MinValue = new(1601, 1, 1);

	internal FILETIME ft;

	/// <summary>Initializes a new instance of the <see cref="PFILETIME"/> class.</summary>
	public PFILETIME() { }

	/// <summary>Initializes a new instance of the <see cref="PFILETIME"/> class.</summary>
	/// <param name="dt">The <see cref="DateTime"/> value used to set this instance.</param>
	public PFILETIME(in DateTime dt) : this(unchecked((ulong)dt.ToFileTimeUtc()))
	{
	}

	/// <summary>Initializes a new instance of the <see cref="PFILETIME"/> class.</summary>
	/// <param name="ft">The <see cref="FILETIME"/> value used to set this instance.</param>
	public PFILETIME(in FILETIME ft) => this.ft = ft;

	/// <summary>Initializes a new instance of the <see cref="PFILETIME"/> class.</summary>
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
	/// <param name="microsecond">The microsecond. The valid values for this member are 0 through 999.</param>
	public PFILETIME(ushort year, ushort month, ushort day, ushort hour = 0, ushort minute = 0, ushort second = 0,
		ushort millisecond = 0, ushort microsecond = 0)
	{
		if (microsecond > 999)
			throw new ArgumentOutOfRangeException(nameof(microsecond), @"microsecond value must be 0 through 999");
		DateTime dt = new(year, month, day, hour, minute, second, millisecond);
		ft = MakeFILETIME((ulong)(dt.ToFileTimeUtc() + microsecond * 10));
	}

	/// <summary>Initializes a new instance of the <see cref="PFILETIME"/> class.</summary>
	/// <param name="ticks">The number of 100-nanosecond intervals since January 1, 1601.</param>
	public PFILETIME(ulong ticks) => ft = MakeFILETIME(ticks);

	private ulong ToUInt64 => ft.ToUInt64();

	/// <summary>Performs an implicit conversion from <see cref="PFILETIME"/> to <see cref="System.Nullable{FILETIME}"/>.</summary>
	/// <param name="pft">The <see cref="PFILETIME"/> value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator FILETIME?(PFILETIME? pft) => pft?.ft;

	/// <summary>Performs an implicit conversion from <see cref="System.Nullable{FILETIME}"/> to <see cref="PFILETIME"/>.</summary>
	/// <param name="ft">The <see cref="FILETIME"/> value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator PFILETIME?(FILETIME? ft) => ft.HasValue ? new(ft.Value) : null;

	/// <summary>Performs an explicit conversion from <see cref="IntPtr"/> to <see cref="System.Nullable{PFILETIME}"/>.</summary>
	/// <param name="p">The pointer to memory that has a 16 byte FILETIME instance.</param>
	/// <returns>The result of the conversion.</returns>
	/// <exception cref="ArgumentException">Pointer must be to a FILETIME structure.</exception>
	public static explicit operator PFILETIME?(IntPtr p)
	{
		if (p == IntPtr.Zero) return null;
		try { return new(unchecked((ulong)Marshal.ReadInt64(p))); }
		catch { throw new ArgumentException(@"Pointer must be to a FILETIME structure.", nameof(p)); }
	}

	/// <summary>Performs an explicit conversion from <see cref="FILETIME"/>* to <see cref="System.Nullable{PFILETIME}"/>.</summary>
	/// <param name="p">The pointer to FILETIME instance.</param>
	/// <returns>The result of the conversion.</returns>
	/// <exception cref="ArgumentException">Pointer must be to a FILETIME structure.</exception>
	public static unsafe explicit operator PFILETIME?(FILETIME* p)
	{
		if (p is null) return null;
		return new(*p);
	}

	/// <inheritdoc/>
	public int CompareTo(FILETIME other) => ft.CompareTo(other);

	/// <inheritdoc/>
	public int CompareTo(PFILETIME other) => ft.CompareTo(other.ft);

	/// <inheritdoc/>
	public override bool Equals(object? obj) => obj is PFILETIME pFILETIME && Equals(pFILETIME.ft);

	/// <inheritdoc/>
	public bool Equals(PFILETIME other) => Equals(other.ft);

	/// <inheritdoc/>
	public bool Equals(FILETIME other) => ft.CompareTo(other) == 0;

	/// <inheritdoc/>
	public bool Equals(DateTime other) => other.Equals(ToDateTime(DateTimeKind.Local));

	/// <inheritdoc/>
	public override int GetHashCode()
	{
		ulong u = ToUInt64;
		return unchecked((int)u) ^ (int)(u >> 32);
	}

	/// <summary>Converts this <see cref="FILETIME"/> instance to a <see cref="DateTime"/> instance.</summary>
	/// <param name="kind">Indicates whether this <see cref="FILETIME"/> instance is local, universal or neither.</param>
	/// <returns>An equivalent <see cref="DateTime"/> value.</returns>
	public DateTime ToDateTime(DateTimeKind kind) => ft.ToDateTime(kind);

	/// <inheritdoc/>
	public override string ToString() => ToString(DateTimeKind.Unspecified, null, null);

	/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
	/// <param name="kind">One of the enumeration values that indicates whether the new object represents local time, UTC, or neither.</param>
	/// <param name="format">A standard or custom date and time format string.</param>
	/// <param name="provider">An object that supplies culture-specific formatting information.</param>
	/// <returns>A <see cref="string"/> that represents this instance.</returns>
	public string ToString(DateTimeKind kind, string? format, IFormatProvider? provider) =>
		ft.ToInt64() < 0 ? ft.ToTimeSpan().ToString() : ft.ToDateTime().ToString(format, provider);

	private string GetDebuggerDisplay() => ToString();
}