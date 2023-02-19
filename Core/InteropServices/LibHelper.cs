using System;
using System.Runtime.InteropServices;

namespace Vanara.InteropServices;

/// <summary>General functions to support library calls.</summary>
public static class LibHelper
{
	private const string KERNEL32 = "kernel32.dll";

	/// <summary>Determines whether the current process is a 64-bit process.</summary>
	/// <value><see langword="true"/> if the process is 64-bit; otherwise, <see langword="false"/>.</value>
	public static bool Is64BitProcess
	{
		get
		{
			if (IntPtr.Size == 8) return true;
			var env = Environment.GetEnvironmentVariable(nameof(Is64BitProcess));
			if (env is null)
			{
				var is64 = DoesWin32MethodExist(KERNEL32, nameof(IsWow64Process)) && IsWow64Process(GetCurrentProcess(), out var isWow64) && isWow64;
				Environment.SetEnvironmentVariable(nameof(Is64BitProcess), is64.ToString());
				return is64;
			}
			return env == "true";
		}
	}

	/// <summary>Determines if the specified function name is exported from a module.</summary>
	/// <param name="moduleName">Name of the module.</param>
	/// <param name="methodName">Name of the method.</param>
	/// <returns><see langword="true"/> if the function is exported; otherwise <see langword="false"/>.</returns>
	public static bool DoesWin32MethodExist(string moduleName, string methodName)
	{
		var hModule = GetModuleHandle(moduleName);
		return hModule != IntPtr.Zero && GetProcAddress(hModule, methodName) != IntPtr.Zero;
	}

	[DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr GetCurrentProcess();

	[DllImport(KERNEL32, CharSet = CharSet.Auto, BestFitMapping = false, SetLastError = true)]
	private static extern IntPtr GetModuleHandle(string moduleName);

	[DllImport(KERNEL32, CharSet = CharSet.Ansi, BestFitMapping = false, SetLastError = true, ExactSpelling = true)]
	private static extern IntPtr GetProcAddress(IntPtr hModule, string methodName);

	[DllImport(KERNEL32, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool IsWow64Process([In] IntPtr hSourceProcessHandle, [Out, MarshalAs(UnmanagedType.Bool)] out bool isWow64);
}