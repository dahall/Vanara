namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Exposes a method which is called when the picture that represents a user account is changed.</summary>
	/// <remarks>
	/// <para>
	/// Applications that want to notify users through this interface can add their class identifier (CLSID) strings as values under
	/// this key:
	/// </para>
	/// <para><c>SOFTWARE</c><c>Microsoft</c><c>Windows</c><c>CurrentVersion</c><c>UserPictureChange</c></para>
	/// <para>The values under this key are enumerated to create this callback object.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-iuseraccountchangecallback
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IUserAccountChangeCallback")]
	[ComImport, Guid("a561e69a-b4b8-4113-91a5-64c6bcca3430"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUserAccountChangeCallback
	{
		/// <summary>Called to send notifications when the picture that represents a user account is changed.</summary>
		/// <param name="pszUserName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>Pointer to a string that contains the user name. Set this parameter to <c>NULL</c> to specify the current user.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When the picture that represents a user account changes, the callback object notifies all applications that are registered
		/// under this registry subkey:
		/// </para>
		/// <para><c>SOFTWARE</c><c>Microsoft</c><c>Windows</c><c>CurrentVersion</c><c>UserPictureChange</c></para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iuseraccountchangecallback-onpicturechange HRESULT
		// OnPictureChange( LPCWSTR pszUserName );
		[PreserveSig]
		HRESULT OnPictureChange([MarshalAs(UnmanagedType.LPWStr)] string? pszUserName);
	}
}