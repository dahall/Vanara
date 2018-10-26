using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Principal;
using Microsoft.Win32;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.Security
{
	/// <summary>
	/// Provides information about the state of User Access Control for the system.
	/// </summary>
	public static partial class UAC
	{
		private static bool? enabled;

		/// <summary>
		/// Determines whether the provided process can be elevated. Effectively, this checks that UAC is available and that the process is running under an
		/// account that belongs to the Administrators group.
		/// </summary>
		/// <param name="process">The process. If this value is <c>null</c>, then the current process is used.</param>
		/// <returns><c>true</c> if this process can be elevated; otherwise, <c>false</c>.</returns>
		public static bool CanElevate(Process process = null) => IsEnabled() && IsRunningAsAdmin(process);

		/// <summary>Determines whether the specified process is elevated.</summary>
		/// <param name="process">The process. If this value is <c>null</c>, then the current process is used.</param>
		/// <returns><c>true</c> if the specified process is elevated; otherwise, <c>false</c>.</returns>
		public static bool IsElevated(Process process = null)
		{
			try
			{
				// Open the access token of the current process with TOKEN_QUERY. 
				using (var hObject = SafeHTOKEN.FromProcess(process ?? Process.GetCurrentProcess(), TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_DUPLICATE))
					return hObject.IsElevated;
			}
			catch { }
			return false;
		}

		/// <summary>Determines whether UAC is enabled on this system.</summary>
		/// <returns><c>true</c> if UAC is enabled; otherwise, <c>false</c>.</returns>
		public static bool IsEnabled()
		{
			if (!enabled.HasValue)
			{
				if (Environment.OSVersion.Version.Major < 6)
					enabled = true;
				else
					enabled = Registry.GetValue(
						@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Policies\System", "EnableLUA", 0).Equals(1);
			}
			return enabled.Value;
		}

		/// <summary>
		/// The function checks whether the primary access token of the process belongs to user account that is a member of the local Administrators group,
		/// even if it currently is not elevated.
		/// </summary>
		/// <param name="proc">The process to check.</param>
		/// <returns>
		/// Returns true if the primary access token of the process belongs to user account that is a member of the local Administrators group. Returns false
		/// if the token does not.
		/// </returns>
		public static bool IsRunningAsAdmin(Process proc = null)
		{
			SafeHTOKEN hObjectToCheck = null;

			// Open the access token of the current process for query and duplicate.
			using (var hObject = SafeHTOKEN.FromProcess(proc, TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_DUPLICATE))
			{
				// Determine whether system is running Windows Vista or later operating systems (major version >= 6) because they support linked tokens, but
				// previous versions (major version < 6) do not.
				if (Environment.OSVersion.Version.Major >= 6)
				{
					// Marshal the TOKEN_ELEVATION_TYPE enum from native to .NET.
					var elevType = hObject.GetInfo<TOKEN_ELEVATION_TYPE>(TOKEN_INFORMATION_CLASS.TokenElevationType);

					// If limited, get the linked elevated token for further check.
					if (elevType == TOKEN_ELEVATION_TYPE.TokenElevationTypeLimited)
					{
						// Marshal the linked token value from native to .NET.
						hObjectToCheck = new SafeHTOKEN(hObject.GetInfo<IntPtr>(TOKEN_INFORMATION_CLASS.TokenLinkedToken));
					}
				}

				// CheckTokenMembership requires an impersonation token. If we just got a linked token, it already is an impersonation token. If we did not get a
				// linked token, duplicate the original into an impersonation token for CheckTokenMembership.
				if (hObjectToCheck == null)
				{
					if (!DuplicateToken(hObject, SECURITY_IMPERSONATION_LEVEL.SecurityIdentification, out hObjectToCheck))
						throw new Win32Exception();
				}
			}

			if (hObjectToCheck == null || hObjectToCheck.IsInvalid) return false;

			// Check if the token to be checked contains admin SID.
			var id = new WindowsIdentity(hObjectToCheck.DangerousGetHandle());
			return id.IsAdmin();
		}

		/*/// <summary>Runs the current application elevated if it isn't already. <note>This will close the current running instance.</note></summary>
		public static void RunCurrentApplicationElevated()
		{
			if (!WindowsIdentity.GetCurrent().IsAdmin())
			{
				// Launch itself as administrator
				var proc = new ProcessStartInfo(System.Windows.Forms.Application.ExecutablePath)
				{
					UseShellExecute = true,
					WorkingDirectory = Environment.CurrentDirectory,
					Verb = "runas"
				};
				try
				{
					Process.Start(proc);
					System.Windows.Forms.Application.Exit();
				}
				catch { }
			}
		}*/
	}
}