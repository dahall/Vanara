﻿namespace Vanara.PInvoke;

/// <summary>
/// An LUID is a 64-bit value guaranteed to be unique only on the system on which it was generated. The uniqueness of a locally
/// unique identifier (LUID) is guaranteed only until the system is restarted.
/// <para>Applications must use functions and structures to manipulate LUID values.</para>
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LUID
{
	/// <summary>Low order bits.</summary>
	public uint LowPart;

	/// <summary>High order bits.</summary>
	public int HighPart;

	/// <summary>Gets the privilege name for this LUID.</summary>
	/// <param name="systemName">
	/// Name of the system on which to perform the lookup. Specifying <c>null</c> will query the local system.
	/// </param>
	/// <returns>The name retrieved for the LUID.</returns>
	public string GetName(string? systemName = null)
	{
		var sb = new StringBuilder(1024);
		var sz = (uint)sb.Capacity;
		if (!LookupPrivilegeName(systemName, in this, sb, ref sz))
			Win32Error.ThrowLastError();
		return sb.ToString();
	}

	/// <summary>Creates a new LUID instance from a privilege name.</summary>
	/// <param name="name">The privilege name.</param>
	/// <param name="systemName">
	/// Name of the system on which to perform the lookup. Specifying <c>null</c> will query the local system.
	/// </param>
	/// <returns>The LUID instance corresponding to the <paramref name="name"/>.</returns>
	public static LUID FromName(string name, string? systemName = null) =>
		LookupPrivilegeValue(systemName, name, out var val) ? val : throw Win32Error.GetLastError().GetException()!;

	/// <summary>
	/// Creates a new LUID that is unique to the local system only, and uniqueness is guaranteed only until the system is next restarted.
	/// </summary>
	/// <returns>A new LUID.</returns>
	public static LUID NewLUID()
	{
		if (!AllocateLocallyUniqueId(out var ret))
			Win32Error.ThrowLastError();
		return ret;
	}

	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool AllocateLocallyUniqueId(out LUID Luid);

	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool LookupPrivilegeName([MarshalAs(UnmanagedType.LPTStr)] string? lpSystemName,
		in LUID lpLuid, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpName, ref uint cchName);

	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool LookupPrivilegeValue([MarshalAs(UnmanagedType.LPTStr)] string? lpSystemName,
		[MarshalAs(UnmanagedType.LPTStr)] string lpName, out LUID lpLuid);

	/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
	/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
	public override string ToString()
	{
		try { return GetName(); } catch { return $"0x{Macros.MAKELONG64(LowPart, (uint)HighPart):X}"; }
	}
}