using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
#if (NET20 || NET35 || NET40 || NET45)
using System.Management;
#endif
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions.Reflection;
using Vanara.InteropServices;
using Vanara.IO;
using Vanara.PInvoke;
using Vanara.Security;
using Vanara.Security.AccessControl;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.Extensions
{
	/// <summary>Values which define a processes integrity level.</summary>
	public enum ProcessIntegrityLevel
	{
		/// <summary>Untrusted.</summary>
		Untrusted,

		/// <summary>Undefined.</summary>
		Undefined,

		/// <summary>Low.</summary>
		Low,

		/// <summary>Medium.</summary>
		Medium,

		/// <summary>High.</summary>
		High,

		/// <summary>System.</summary>
		System
	}

	/// <summary>Extension methods for <see cref="Process"/> for privileges, status, elevation and relationships.</summary>
	public static partial class ProcessExtension
	{
		/// <summary>Disables a specified system privilege on a process.</summary>
		/// <param name="process">The process on which to disable the privilege.</param>
		/// <param name="privilege">The privilege to disable.</param>
		public static void DisablePrivilege(this Process process, SystemPrivilege privilege)
		{
			using var hObj = SafeHTOKEN.FromProcess(process, TokenAccess.TOKEN_ADJUST_PRIVILEGES | TokenAccess.TOKEN_QUERY);
			hObj.AdjustPrivilege(privilege, PrivilegeAttributes.SE_PRIVILEGE_DISABLED);
		}

		/// <summary>Enables a specified system privilege on a process.</summary>
		/// <param name="process">The process on which to enable the privilege.</param>
		/// <param name="privilege">The privilege to enable.</param>
		public static void EnablePrivilege(this Process process, SystemPrivilege privilege)
		{
			using var hObj = SafeHTOKEN.FromProcess(process, TokenAccess.TOKEN_ADJUST_PRIVILEGES | TokenAccess.TOKEN_QUERY);
			hObj.AdjustPrivilege(privilege, PrivilegeAttributes.SE_PRIVILEGE_ENABLED);
		}

#if (NET35 || NET40 || NET45)
		/// <summary>Gets the child processes.</summary>
		/// <param name="p">The process.</param>
		/// <param name="includeDescendants">if set to <c>true</c> include descendants of child processes as well.</param>
		/// <returns>A <see cref="IEnumerable{Process}"/> reference for enumerating child processes.</returns>
		public static IEnumerable<Process> GetChildProcesses(this Process p, bool includeDescendants = false)
		{
			if (p == null) throw new ArgumentNullException(nameof(p));

			var l = new List<Tuple<int, int>>();
			var scope = p.MachineName == "." ? new ManagementScope() : new ManagementScope($"\\\\{p.MachineName}\\root\\cimv2");
			using (var mos = new ManagementObjectSearcher(scope, new ObjectQuery("select ProcessId, ParentProcessId from win32_process")))
			{
				foreach (var obj in mos.Get().Cast<ManagementObject>())
					l.Add(new Tuple<int, int>(Convert.ToInt32(obj["ProcessId"]), Convert.ToInt32(obj["ParentProcessId"])));
			}
			return GetChildProcesses(p.Id, l.GroupBy(i => i.Item2).ToDictionary(g => g.Key, g => g.ToList()), p.MachineName, includeDescendants);
		}
#endif

		/// <summary>
		/// The function gets the integrity level of the current process. Integrity level is only available on Windows Vista and newer operating systems, thus
		/// GetProcessIntegrityLevel throws an exception if it is called on systems prior to Windows Vista.
		/// </summary>
		/// <returns>Returns the integrity level of the current process.</returns>
		/// <exception cref="System.ComponentModel.Win32Exception">
		/// When any native Windows API call fails, the function throws a Win32Exception with the last error code.
		/// </exception>
		/// <exception cref="System.ArgumentNullException"><paramref name="p"/> must be a valid <see cref="Process"/>.</exception>
		public static ProcessIntegrityLevel GetIntegrityLevel(this Process p)
		{
			if (p == null)
				throw new ArgumentNullException(nameof(p));

			// Open the access token of the current process with TOKEN_QUERY. 
			var hObject = SafeHTOKEN.FromProcess(p, TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_DUPLICATE);

			// Marshal the TOKEN_MANDATORY_LABEL struct from native to .NET object. 
			var tokenIL = hObject.GetInfo<TOKEN_MANDATORY_LABEL>(TOKEN_INFORMATION_CLASS.TokenIntegrityLevel);

			// Integrity Level SIDs are in the form of S-1-16-0xXXXX. (e.g. S-1-16-0x1000 stands for low integrity level SID). There is one and only one subauthority.
			return (GetSidSubAuthority(tokenIL.Label.Sid, 0)) switch
			{
				0 => ProcessIntegrityLevel.Untrusted,
				0x1000 => ProcessIntegrityLevel.Low,
				var iVal when iVal >= 0x2000 && iVal < 0x3000 => ProcessIntegrityLevel.Medium,
				var iVal when iVal >= 0x4000 => ProcessIntegrityLevel.System,
				var iVal when iVal >= 0x3000 => ProcessIntegrityLevel.High,
				_ => ProcessIntegrityLevel.Undefined,
			};
		}

#if (NET20 || NET35 || NET40 || NET45)
		/// <summary>
		/// Gets the parent process.
		/// </summary>
		/// <returns>A <see cref="Process"/> object for the process that called the specified process. <c>null</c> if no parent can be established.</returns>
		/// <exception cref="System.ArgumentNullException"><paramref name="p"/> must be a valid <see cref="Process"/>.</exception>
		public static Process GetParentProcess(this Process p)
		{
			if (p == null)
				throw new ArgumentNullException(nameof(p));
			try
			{
				using var mo = new ManagementObject($"win32_process.handle='{p.Id}'");
				mo.Get();
				return Process.GetProcessById(Convert.ToInt32(mo["ParentProcessId"]), p.MachineName);
			}
			catch { }
			return null;
		}
#endif

		/// <summary>Gets the privileges for this process.</summary>
		/// <param name="process">The process.</param>
		/// <returns>
		/// An enumeration of <see cref="PrivilegeAndAttributes"/> instances that include the process privileges and their associated attributes (enabled,
		/// disabled, removed, etc.).
		/// </returns>
		public static IEnumerable<PrivilegeAndAttributes> GetPrivileges(this Process process)
		{
			using var hObj = SafeHTOKEN.FromProcess(process, TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_DUPLICATE);
			return hObj.GetPrivileges().Select(la => new PrivilegeAndAttributes(la.Luid.GetPrivilege(process.MachineName), la.Attributes));
		}

		/// <summary>Determines whether the specified privilege is had by the process.</summary>
		/// <param name="process">The process.</param>
		/// <param name="priv">The privilege.</param>
		/// <returns><c>true</c> if the process has the specified privilege; otherwise, <c>false</c>.</returns>
		public static bool HasPrivilege(this Process process, SystemPrivilege priv) => HasPrivileges(process, true, priv);

		/// <summary>Determines whether the specified privileges are had by the process.</summary>
		/// <param name="process">The process.</param>
		/// <param name="requireAll">if set to <c>true</c> require all privileges to be enabled in order to return <c>true</c>.</param>
		/// <param name="privs">The privileges to check.</param>
		/// <returns><c>true</c> if the process has the specified privilege; otherwise, <c>false</c>.</returns>
		public static bool HasPrivileges(this Process process, bool requireAll, params SystemPrivilege[] privs)
		{
			using var hObj = SafeHTOKEN.FromProcess(process, TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_DUPLICATE);
			return hObj.HasPrivileges(requireAll, privs);
		}

		/// <summary>
		/// The function gets the elevation information of the current process. It dictates whether the process is elevated or not. Token elevation is only
		/// available on Windows Vista and newer operating systems, thus IsProcessElevated throws a C++ exception if it is called on systems prior to Windows
		/// Vista. It is not appropriate to use this function to determine whether a process is run as administrator.
		/// </summary>
		/// <returns>Returns true if the process is elevated. Returns false if it is not.</returns>
		/// <exception cref="System.ComponentModel.Win32Exception">
		/// When any native Windows API call fails, the function throws a Win32Exception with the last error code.
		/// </exception>
		/// <exception cref="System.ArgumentNullException"><paramref name="p"/> must be a valid <see cref="Process"/>.</exception>
		/// <remarks>
		/// TOKEN_INFORMATION_CLASS provides TokenElevationType to check the elevation type (TokenElevationTypeDefault / TokenElevationTypeLimited /
		/// TokenElevationTypeFull) of the process. It is different from TokenElevation in that, when UAC is turned off, elevation type always returns
		/// TokenElevationTypeDefault even though the process is elevated (Integrity Level == High). In other words, it is not safe to say if the process is
		/// elevated based on elevation type. Instead, we should use TokenElevation.
		/// </remarks>
		public static bool IsElevated(this Process p)
		{
			if (p == null)
				throw new ArgumentNullException(nameof(p));

			try
			{
				// Open the access token of the current process with TOKEN_QUERY. 
				using var hObject = SafeHTOKEN.FromProcess(p, TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_DUPLICATE);
				return hObject.IsElevated;
			}
			catch { }
			return false;
		}

		/// <summary>Determines whether the process is running within a job object.</summary>
		/// <param name="p">
		/// <para>
		/// The process to be tested. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the PROCESS_QUERY_INFORMATION access right.</para>
		/// </param>
		/// <returns><see langword="true"/> if the process is running in a job, and <see langword="false"/> otherwise.</returns>
		public static bool IsInJob(this Process p) => IsProcessInJob(p, HJOB.NULL, out var res) ? res : throw Win32Error.GetLastError().GetException();

		/// <summary>
		/// The function checks whether the primary access token of the process belongs to user account that is a member of the local Administrators group,
		/// even if it currently is not elevated.
		/// </summary>
		/// <param name="proc">The process to check.</param>
		/// <returns>
		/// Returns true if the primary access token of the process belongs to user account that is a member of the local Administrators group. Returns false
		/// if the token does not.
		/// </returns>
		public static bool IsRunningAsAdmin(this Process proc) => UAC.IsRunningAsAdmin(proc);

		/// <summary>Removes a specified system privilege from a process.</summary>
		/// <param name="process">The process from which to remove the privilege.</param>
		/// <param name="privilege">The privilege to remove.</param>
		public static void RemovePrivilege(this Process process, SystemPrivilege privilege)
		{
			using var hObj = SafeHTOKEN.FromProcess(process, TokenAccess.TOKEN_ADJUST_PRIVILEGES | TokenAccess.TOKEN_QUERY);
			hObj.AdjustPrivilege(privilege, PrivilegeAttributes.SE_PRIVILEGE_REMOVED);
		}

		/// <summary>Resumes the primary thread on the process.</summary>
		/// <param name="process">The running process.</param>
		public static void ResumePrimaryThread(this Process process)
		{
			using var hTh = OpenThread((uint)ThreadAccess.THREAD_RESUME, true, (uint)process.Threads[0].Id);
			ResumeThread(hTh);
		}

		/// <summary>Extension method to start a process with extra flags.</summary>
		/// <param name="process">The process to start.</param>
		/// <param name="flags">The process flags.</param>
		/// <returns><see langword="true"/> if successful.</returns>
		/// <exception cref="InvalidOperationException">
		/// Process.StartEx cannot be used when StartInfo.UseShellExecute is true. or File name is missing. or StandardOutputEncoding not
		/// allowed or StandardErrorEncoding not allowed
		/// </exception>
		/// <exception cref="ArgumentException">Can't set duplicate password</exception>
		public static bool StartEx(this Process process, CREATE_PROCESS flags)
		{
			var startInfo = process.StartInfo;
			if (startInfo.UseShellExecute)
				throw new InvalidOperationException("Process.StartEx cannot be used when StartInfo.UseShellExecute is true.");
			if (startInfo.FileName.Length == 0)
				throw new InvalidOperationException("File name is missing.");

			process.Close();

			if (startInfo.StandardOutputEncoding != null && !startInfo.RedirectStandardOutput)
				throw new InvalidOperationException("StandardOutputEncoding not allowed");

			if (startInfo.StandardErrorEncoding != null && !startInfo.RedirectStandardError)
				throw new InvalidOperationException("StandardErrorEncoding not allowed");

			// TODO: Cannot start a new process and store its handle if the object has been disposed, since finalization has been suppressed.            
			// if (process.disposed) throw new ObjectDisposedException(GetType().Name);

			var commandLine = new StringBuilder(string.Concat(PathEx.QuoteIfHasSpaces(startInfo.FileName), string.IsNullOrEmpty(startInfo.Arguments) ? "" : " " + startInfo.Arguments));

			var startupInfo = STARTUPINFO.Default;
			bool retVal;
			Win32Error errorCode = 0;
			// handles used in parent process
			SafeHPIPE standardInputWritePipeHandle = null, standardOutputReadPipeHandle = null, standardErrorReadPipeHandle = null, hStdInput = null, hStdOutput = null, hStdError = null;

			// set up the streams
			if (startInfo.RedirectStandardInput || startInfo.RedirectStandardOutput || startInfo.RedirectStandardError)
			{
				if (startInfo.RedirectStandardInput)
				{
					CreatePipe(out standardInputWritePipeHandle, out hStdInput, new SECURITY_ATTRIBUTES(), 0);
					startupInfo.hStdInput = hStdInput;
				}
				else
				{
					startupInfo.hStdInput = (IntPtr)GetStdHandle(StdHandleType.STD_INPUT_HANDLE);
				}

				if (startInfo.RedirectStandardOutput)
				{
					CreatePipe(out standardOutputReadPipeHandle, out hStdOutput, new SECURITY_ATTRIBUTES(), 0);
					startupInfo.hStdOutput = hStdOutput;
				}
				else
				{
					startupInfo.hStdOutput = (IntPtr)GetStdHandle(StdHandleType.STD_OUTPUT_HANDLE);
				}

				if (startInfo.RedirectStandardError)
				{
					CreatePipe(out standardErrorReadPipeHandle, out hStdError, new SECURITY_ATTRIBUTES(), 0);
					startupInfo.hStdError = hStdError;
				}
				else
				{
					startupInfo.hStdError = (IntPtr)GetStdHandle(StdHandleType.STD_ERROR_HANDLE);
				}

				startupInfo.dwFlags = STARTF.STARTF_USESTDHANDLES;
			}

			// set up the creation flags paramater
			var creationFlags = flags;
			if (startInfo.CreateNoWindow) creationFlags |= CREATE_PROCESS.CREATE_NO_WINDOW;

			var workingDirectory = startInfo.WorkingDirectory;
			if (workingDirectory == string.Empty)
				workingDirectory = Environment.CurrentDirectory;

			SafePROCESS_INFORMATION processInfo;
			if (startInfo.UserName.Length != 0)
			{
				if (startInfo.Password != null)
					throw new ArgumentException("Can't set duplicate password");

				ProcessLogonFlags logonFlags = 0;
				if (startInfo.LoadUserProfile)
					logonFlags = ProcessLogonFlags.LOGON_WITH_PROFILE;

				using var password = startInfo.Password != null ? new SafeCoTaskMemString(startInfo.Password) : new SafeCoTaskMemString(string.Empty);
				System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions();
				try { }
				finally
				{
					retVal = CreateProcessWithLogonW(
							startInfo.UserName,
							startInfo.Domain,
							password,
							logonFlags,
							null,               // we don't need this since all the info is in commandLine
							commandLine,
							creationFlags,
							startInfo.EnvironmentVariables?.Cast<DictionaryEntry>().Select(e => $"{e.Key}={e.Value}").ToArray(),
							workingDirectory,
							startupInfo,        // pointer to STARTUPINFO
							out processInfo);   // pointer to PROCESS_INFORMATION
					if (!retVal)
						errorCode = Win32Error.GetLastError();
				}
				if (!retVal)
				{
					if (errorCode == Win32Error.ERROR_BAD_EXE_FORMAT || errorCode == Win32Error.ERROR_EXE_MACHINE_TYPE_MISMATCH)
						throw errorCode.GetException("Invalid application");
					throw errorCode.GetException();
				}
			}
			else
			{
				System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions();
				try { }
				finally
				{
					retVal = CreateProcess(
							null,               // we don't need this since all the info is in commandLine
							commandLine,        // pointer to the command line string
							null,               // pointer to process security attributes, we don't need to inheriat the handle
							null,               // pointer to thread security attributes
							true,               // handle inheritance flag
							creationFlags,      // creation flags
							startInfo.EnvironmentVariables?.Cast<DictionaryEntry>().Select(e => $"{e.Key}={e.Value}").ToArray(),
							workingDirectory,   // pointer to current directory name
							startupInfo,        // pointer to STARTUPINFO
							out processInfo);   // pointer to PROCESS_INFORMATION
					if (!retVal)
						errorCode = Win32Error.GetLastError();
				}
				if (!retVal)
				{
					if (errorCode == Win32Error.ERROR_BAD_EXE_FORMAT || errorCode == Win32Error.ERROR_EXE_MACHINE_TYPE_MISMATCH)
						throw errorCode.GetException("Invalid application");
					throw errorCode.GetException();
				}
			}

#pragma warning disable CS0618 // Type or member is obsolete
			if (startInfo.RedirectStandardInput)
			{
				var stdIn = new StreamWriter(new FileStream(standardInputWritePipeHandle.DangerousGetHandle(), System.IO.FileAccess.Write, false, 4096), Console.InputEncoding, 4096);
				stdIn.AutoFlush = true;
				process.SetFieldValue("standardInput", stdIn);
			}
			if (startInfo.RedirectStandardOutput)
			{
				var enc = (startInfo.StandardOutputEncoding != null) ? startInfo.StandardOutputEncoding : Console.OutputEncoding;
				var stdOut = new StreamReader(new FileStream(standardOutputReadPipeHandle.DangerousGetHandle(), System.IO.FileAccess.Read, false, 4096), enc, true, 4096);
				process.SetFieldValue("standardOutput", stdOut);
			}
			if (startInfo.RedirectStandardError)
			{
				var enc = (startInfo.StandardErrorEncoding != null) ? startInfo.StandardErrorEncoding : Console.OutputEncoding;
				var stdErr = new StreamReader(new FileStream(standardErrorReadPipeHandle.DangerousGetHandle(), System.IO.FileAccess.Read, false, 4096), enc, true, 4096);
				process.SetFieldValue("standardError", stdErr);
			}
#pragma warning restore CS0618 // Type or member is obsolete

			if (!processInfo.hProcess.IsInvalid)
			{
				//process.InvokeMethod("SetProcessHandle", new Microsoft.Win32.SafeHandles.SafeProcessHandle(processInfo.hProcess.Duplicate(), true));
				process.InvokeMethod("SetProcessId", (int)processInfo.dwProcessId);
				var h = process.Handle;
				return true;
			}
			return false;
		}

		private static IEnumerable<Process> GetChildProcesses(int pid, Dictionary<int, List<Tuple<int, int>>> allProcs, string machineName, bool allChildren = true)
		{
			if (allProcs == null) throw new ArgumentNullException(nameof(allProcs));
			foreach (var val in allProcs[pid])
			{
				var cpid = val.Item1;
				if (allChildren && allProcs.ContainsKey(cpid))
					foreach (var cval in GetChildProcesses(cpid, allProcs, machineName))
						yield return cval;
				Process retProc = null;
				try { retProc = Process.GetProcessById(cpid, machineName); } catch { }
				if (retProc != null) yield return retProc;
			}
		}
	}
}
