using System;
using System.Net.Sockets;
using System.Security;

namespace Vanara.PInvoke
{
	public static partial class Ws2_32
	{
		/// <summary>
		/// Throws an appropriate exception if <paramref name="err"/> is a failure. If the value of <paramref name="err"/> equals <see
		/// cref="SocketError.SocketError"/> (-1 or SOCKET_ERROR), then <see cref="WSAGetLastError"/> is called to retrive the actual error.
		/// </summary>
		/// <param name="err">The <see cref="SocketError"/> value to process.</param>
		public static void ThrowIfFailed(this SocketError err) { var ex = err.GetException(); if (ex is not null) throw ex; }

		/// <summary>Throws the last error if the function returns <see langword="false"/>.</summary>
		/// <param name="value">The value to check.</param>
		public static void ThrowLastErrorIfFalse(bool value) { if (!value) throw WSAGetLastError().GetException(); }

		/// <summary>
		/// Gets the .NET <see cref="Exception"/> associated with the <see cref="SocketError"/> value and optionally adds the supplied message.
		/// </summary>
		/// <param name="err">The <see cref="SocketError"/> value to process.</param>
		/// <returns>The associated <see cref="Exception"/> or <see langword="null"/> if this <see cref="SocketError"/> is not a failure.</returns>
		[SecurityCritical, SecuritySafeCritical]
		public static Exception GetException(this SocketError err) => err switch
		{
			0 => null,
			SocketError.SocketError => new SocketException((int)WSAGetLastError()),
			_ => new SocketException((int)err)
		};
	}
}