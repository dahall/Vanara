using System;
using System.ComponentModel;
using System.Security;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.CredUI;

namespace Vanara.Security
{
	/// <summary>
	/// Safe container for an authentication buffer. Allows for creation using native <c>CredPackAuthenticationBuffer</c> method or
	/// assignment from an existing <c>IntPtr</c>. Can unpack to <see cref="string"/> or <see cref="SecureString"/> values.
	/// </summary>
	public class AuthenticationBuffer : IDisposable
	{
		private SafeCoTaskMemHandle buffer;

		public AuthenticationBuffer(string userName, string password)
		{
			var pUserName = new SafeCoTaskMemString(userName ?? "");
			var pPassword = new SafeCoTaskMemString(password ?? "");
			Init(0, pUserName, pPassword);
		}

		public AuthenticationBuffer(SecureString userName, SecureString password)
		{
			var pUserName = new SafeCoTaskMemString(userName);
			var pPassword = new SafeCoTaskMemString(password);
			Init(0, pUserName, pPassword);
		}

		public AuthenticationBuffer(IntPtr authBuffer, int authBufferSize) => buffer = new SafeCoTaskMemHandle(authBuffer, authBufferSize);

		public IntPtr DangerousHandle => buffer?.DangerousGetHandle() ?? IntPtr.Zero;

		public int Size => buffer?.Size ?? 0;

		public static implicit operator IntPtr(AuthenticationBuffer b) => b.DangerousHandle;

		public void Dispose()
		{
			if (buffer is null) return;
			buffer.Zero();
			buffer = null;
		}

		public void UnPack(bool decryptProtectedCredentials, out string userName, out string domainName, out string password)
		{
			var pUserName = new StringBuilder(CRED_MAX_USERNAME_LENGTH);
			var pDomainName = new StringBuilder(CRED_MAX_USERNAME_LENGTH);
			var pPassword = new StringBuilder(CREDUI_MAX_PASSWORD_LENGTH);
			var userNameSize = pUserName.Capacity;
			var domainNameSize = pDomainName.Capacity;
			var passwordSize = pPassword.Capacity;

			if (!CredUnPackAuthenticationBuffer(decryptProtectedCredentials ? CredPackFlags.CRED_PACK_PROTECTED_CREDENTIALS : 0x0, DangerousHandle, Size,
				pUserName, ref userNameSize, pDomainName, ref domainNameSize, pPassword, ref passwordSize))
				throw new Win32Exception();

			userName = pUserName.ToString();
			domainName = pDomainName.ToString();
			password = pPassword.ToString();
		}

		public void UnPack(bool decryptProtectedCredentials, out SecureString userName, out SecureString domainName, out SecureString password)
		{
			var pUserName = new SafeCoTaskMemString(CRED_MAX_USERNAME_LENGTH);
			var pDomainName = new SafeCoTaskMemString(CRED_MAX_USERNAME_LENGTH);
			var pPassword = new SafeCoTaskMemString(CREDUI_MAX_PASSWORD_LENGTH);
			var userNameSize = pUserName.CharCapacity;
			var domainNameSize = pDomainName.CharCapacity;
			var passwordSize = pPassword.CharCapacity;

			if (!CredUnPackAuthenticationBuffer(decryptProtectedCredentials ? CredPackFlags.CRED_PACK_PROTECTED_CREDENTIALS : 0x0, DangerousHandle, Size,
				(IntPtr)pUserName, ref userNameSize, (IntPtr)pDomainName, ref domainNameSize, (IntPtr)pPassword, ref passwordSize))
				throw new Win32Exception();

			userName = pUserName.DangerousGetHandle().ToSecureString();
			domainName = pDomainName.DangerousGetHandle().ToSecureString();
			password = pPassword.DangerousGetHandle().ToSecureString();
		}

		private void Init(CredPackFlags flags, string pUserName, string pPassword)
		{
			var bufferSize = 0;
			if (!CredPackAuthenticationBuffer(flags, pUserName, pPassword, IntPtr.Zero, ref bufferSize) && Win32Error.GetLastError() == Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				buffer = new SafeCoTaskMemHandle(bufferSize);
				if (!CredPackAuthenticationBuffer(flags, pUserName, pPassword, DangerousHandle, ref bufferSize))
					throw new Win32Exception();
			}
			else
				throw new Win32Exception();
		}
	}
}