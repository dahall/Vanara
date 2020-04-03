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

		/// <summary>Initializes a new instance of the <see cref="AuthenticationBuffer"/> class.</summary>
		/// <param name="userName">Name of the user.</param>
		/// <param name="password">The password.</param>
		public AuthenticationBuffer(string userName, string password)
		{
			var pUserName = new SafeCoTaskMemString(userName ?? "");
			var pPassword = new SafeCoTaskMemString(password ?? "");
			Init(0, pUserName, pPassword);
		}

		/// <summary>Initializes a new instance of the <see cref="AuthenticationBuffer"/> class.</summary>
		/// <param name="userName">Name of the user.</param>
		/// <param name="password">The password.</param>
		public AuthenticationBuffer(SecureString userName, SecureString password)
		{
			var pUserName = new SafeCoTaskMemString(userName);
			var pPassword = new SafeCoTaskMemString(password);
			Init(0, pUserName, pPassword);
		}

		/// <summary>Initializes a new instance of the <see cref="AuthenticationBuffer"/> class.</summary>
		/// <param name="authBuffer">The authentication buffer.</param>
		/// <param name="authBufferSize">Size of the authentication buffer.</param>
		public AuthenticationBuffer(IntPtr authBuffer, int authBufferSize) => buffer = new SafeCoTaskMemHandle(authBuffer, authBufferSize);

		/// <summary>Gets the dangerous handle.</summary>
		/// <value>The dangerous handle.</value>
		public IntPtr DangerousHandle => buffer?.DangerousGetHandle() ?? IntPtr.Zero;

		/// <summary>Gets the size.</summary>
		/// <value>The size.</value>
		public int Size => buffer?.Size ?? 0;

		/// <summary>Performs an implicit conversion from <see cref="AuthenticationBuffer"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="b">The b.</param>
		/// <returns>The resulting <see cref="IntPtr"/> instance from the conversion.</returns>
		public static implicit operator IntPtr(AuthenticationBuffer b) => b.DangerousHandle;

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			if (buffer is null) return;
			buffer.Zero();
			buffer = null;
		}

		/// <summary>Unpacks the credentials.</summary>
		/// <param name="decryptProtectedCredentials">if set to <see langword="true"/> decrypt protected credentials.</param>
		/// <param name="userName">Name of the user.</param>
		/// <param name="domainName">Name of the domain.</param>
		/// <param name="password">The password.</param>
		/// <exception cref="Win32Exception"></exception>
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

		/// <summary>Unpacks the credentials.</summary>
		/// <param name="decryptProtectedCredentials">if set to <see langword="true"/> decrypt protected credentials.</param>
		/// <param name="userName">Name of the user.</param>
		/// <param name="domainName">Name of the domain.</param>
		/// <param name="password">The password.</param>
		/// <exception cref="Win32Exception"></exception>
		public void UnPack(bool decryptProtectedCredentials, out SecureString userName, out SecureString domainName, out SecureString password)
		{
			var pUserName = new SafeCoTaskMemString(CRED_MAX_USERNAME_LENGTH);
			var pDomainName = new SafeCoTaskMemString(CRED_MAX_USERNAME_LENGTH);
			var pPassword = new SafeCoTaskMemString(CREDUI_MAX_PASSWORD_LENGTH);
			var userNameSize = pUserName.Capacity;
			var domainNameSize = pDomainName.Capacity;
			var passwordSize = pPassword.Capacity;

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