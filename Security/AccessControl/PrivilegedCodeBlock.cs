using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.Security.AccessControl;

/// <summary>Elevate user privileges for a code block similar to a <c>lock</c> or <c>using</c> statement.</summary>
public sealed class PrivilegedCodeBlock : IDisposable
{
	private bool disposed;
	private readonly TOKEN_PRIVILEGES prev;
	private readonly SafeHTOKEN hObj = new(IntPtr.Zero, false);

	/// <summary>Initializes a new instance of the <see cref="PrivilegedCodeBlock"/> class.</summary>
	/// <param name="systemPrivileges">The privileges.</param>
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), SecurityCritical]
	public PrivilegedCodeBlock(params SystemPrivilege[] systemPrivileges) : this(Process.GetCurrentProcess(), systemPrivileges)
	{
	}

	/// <summary>Initializes a new instance of the <see cref="PrivilegedCodeBlock"/> class.</summary>
	/// <param name="process">Process on which to enable the <see cref="SystemPrivilege"/>.</param>
	/// <param name="systemPrivileges">The privileges.</param>
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), SecurityCritical]
	public PrivilegedCodeBlock(Process process, params SystemPrivilege[] systemPrivileges)
	{
		if (systemPrivileges == null || systemPrivileges.Length == 0) return;
		RuntimeHelpers.PrepareConstrainedRegions();
		hObj = SafeHTOKEN.FromProcess(process, TokenAccess.TOKEN_ADJUST_PRIVILEGES | TokenAccess.TOKEN_QUERY);
		if (systemPrivileges.Length == 1)
			prev = hObj.AdjustPrivilege(systemPrivileges[0], PrivilegeAttributes.SE_PRIVILEGE_ENABLED);
		else
			prev = hObj.AdjustPrivileges(systemPrivileges.Select(p => new PrivilegeAndAttributes(p, PrivilegeAttributes.SE_PRIVILEGE_ENABLED)).ToArray());
	}

	/// <summary>Finalizes an instance of the PrivilegedCodeBlock class.</summary>
	[SecuritySafeCritical]
	~PrivilegedCodeBlock()
	{
		Revert();
	}

	/// <summary>Disposes of an instance of the PrivilegedCodeBlock class.</summary>
	/// <exception cref="System.ComponentModel.Win32Exception">Thrown when an underlying Win32 function call does not succeed.</exception>
	[SecurityCritical]
	public void Dispose()
	{
		Revert();
		GC.SuppressFinalize(this);
	}

	internal static string? EnvironmentGetResourceString(string key, params object[] values)
	{
		string? str = new System.Resources.ResourceManager(typeof(Environment)).GetString(key);
		return values.Length == 0 || str == null ? str : string.Format(CultureInfo.CurrentCulture, str, values);
	}

	/// <summary>Revert back to prior privileges.</summary>
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), SecurityCritical]
	private void Revert()
	{
		if (disposed) return;
		lock (hObj)
		{
			RuntimeHelpers.PrepareConstrainedRegions();
			hObj.AdjustPrivileges(prev);
		}
		hObj.Dispose();
		disposed = true;
	}
}