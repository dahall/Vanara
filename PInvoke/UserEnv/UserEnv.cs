using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.PInvoke
{
	/// <summary>Functions and interfaces from UserEnv.dll.</summary>
	public static partial class UserEnv
	{
		/// <summary>
		/// Retrieves the environment variables for the specified user. This block can then be passed to the CreateProcessAsUser function.
		/// </summary>
		/// <param name="lpEnvironment">
		/// <para>Type: <c>LPVOID*</c></para>
		/// <para>
		/// When this function returns, receives a pointer to the new environment block. The environment block is an array of
		/// null-terminated Unicode strings. The list ends with two nulls (\0\0).
		/// </para>
		/// </param>
		/// <param name="hToken">
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>
		/// Token for the user, returned from the LogonUser function. If this is a primary token, the token must have <c>TOKEN_QUERY</c> and
		/// <c>TOKEN_DUPLICATE</c> access. If the token is an impersonation token, it must have <c>TOKEN_QUERY</c> access. For more
		/// information, see Access Rights for Access-Token Objects.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, the returned environment block contains system variables only.</para>
		/// </param>
		/// <param name="bInherit">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Specifies whether to inherit from the current process' environment. If this value is <c>TRUE</c>, the process inherits the
		/// current process' environment. If this value is <c>FALSE</c>, the process does not inherit the current process' environment.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if successful; otherwise, <c>FALSE</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>To free the buffer when you have finished with the environment block, call the DestroyEnvironmentBlock function.</para>
		/// <para>
		/// If the environment block is passed to CreateProcessAsUser, you must also specify the <c>CREATE_UNICODE_ENVIRONMENT</c> flag.
		/// After <c>CreateProcessAsUser</c> has returned, the new process has a copy of the environment block, and DestroyEnvironmentBlock
		/// can be safely called.
		/// </para>
		/// <para>
		/// User-specific environment variables such as %USERPROFILE% are set only when the user's profile is loaded. To load a user's
		/// profile, call the LoadUserProfile function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-createenvironmentblock BOOL CreateEnvironmentBlock( LPVOID
		// *lpEnvironment, HANDLE hToken, BOOL bInherit );
		[DllImport(Lib.Userenv, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("userenv.h", MSDNShortId = "bda8879d-d33a-48f4-8b08-e3a279126a07")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateEnvironmentBlock([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(EnvBlockMarshaler))] out string[] lpEnvironment, HTOKEN hToken, [MarshalAs(UnmanagedType.Bool)] bool bInherit);

		/// <summary>Frees environment variables created by the CreateEnvironmentBlock function.</summary>
		/// <param name="lpEnvironment">
		/// <para>Type: <c>LPVOID</c></para>
		/// <para>
		/// Pointer to the environment block created by CreateEnvironmentBlock. The environment block is an array of null-terminated Unicode
		/// strings. The list ends with two nulls (\0\0).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if successful; otherwise, <c>FALSE</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-destroyenvironmentblock BOOL DestroyEnvironmentBlock(
		// LPVOID lpEnvironment );
		[DllImport(Lib.Userenv, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("userenv.h", MSDNShortId = "8d03e102-3f8a-4aa7-b175-0a6781eedea7")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DestroyEnvironmentBlock(IntPtr lpEnvironment);

		private class EnvBlockMarshaler : ICustomMarshaler
		{
			private EnvBlockMarshaler(string _)
			{
			}

			/// <summary>Gets the instance.</summary>
			/// <param name="cookie">The cookie.</param>
			/// <returns>A new instance of this class.</returns>
			public static ICustomMarshaler GetInstance(string cookie) => new EnvBlockMarshaler(cookie);

			/// <inheritdoc/>
			void ICustomMarshaler.CleanUpManagedData(object ManagedObj) { }

			/// <inheritdoc/>
			void ICustomMarshaler.CleanUpNativeData(IntPtr pNativeData) { }

			/// <inheritdoc/>
			int ICustomMarshaler.GetNativeDataSize() => -1;

			/// <inheritdoc/>
			IntPtr ICustomMarshaler.MarshalManagedToNative(object ManagedObj) => throw new NotImplementedException();

			/// <inheritdoc/>
			object ICustomMarshaler.MarshalNativeToManaged(IntPtr pNativeData)
			{
				try
				{
					return pNativeData.ToStringEnum(CharSet.Unicode).ToArray();
				}
				finally
				{
					DestroyEnvironmentBlock(pNativeData);
				}
			}
		}
	}
}