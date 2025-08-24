namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>
	/// The <c>GetAppContainerNamedObjectPath</c> function retrieves the named object path for the app container. Each app container has
	/// its own named object path.
	/// </summary>
	/// <param name="Token">
	/// A handle pertaining to the token. If <c>NULL</c> is passed in and no AppContainerSid parameter is passed in, the caller's current
	/// process token is used, or the thread token if impersonating.
	/// </param>
	/// <param name="AppContainerSid">The SID of the app container.</param>
	/// <param name="ObjectPathLength">The length of the buffer.</param>
	/// <param name="ObjectPath">Buffer that is filled with the named object path.</param>
	/// <param name="ReturnLength">Returns the length required to accommodate the length of the named object path.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns a value of <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns a value of <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For assistive technology tools that work across Windows Store apps and desktop applications and have features that get loaded in
	/// the context of Windows Store apps, at times it may be necessary for the in-context feature to synchronize with the tool.
	/// Typically such synchronization is accomplished by establishing a named object in the user's session. Windows Store apps pose a
	/// challenge for this mechanism because, by default, named objects in the user's or global session are not accessible to Windows
	/// Store apps. We recommend that you update assistive technology tools to use UI Automation APIs or Magnification APIs to avoid such
	/// pitfalls. In the interim, it may be necessary to continue using named objects.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following sample established a named object so that it is accessible from a Windows Store app.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/securityappcontainer/nf-securityappcontainer-getappcontainernamedobjectpath
	// BOOL GetAppContainerNamedObjectPath( HANDLE Token, PSID AppContainerSid, ULONG ObjectPathLength, LPWSTR ObjectPath, PULONG
	// ReturnLength );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("securityappcontainer.h", MSDNShortId = "466CE2DA-332E-4AA7-A0EB-868A646C0979")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetAppContainerNamedObjectPath([Optional] HTOKEN Token, [Optional] PSID AppContainerSid, uint ObjectPathLength,
		[MarshalAs(UnmanagedType.LPWStr), SizeDef(nameof(ObjectPathLength), SizingMethod.Query, OutVarName = nameof(ReturnLength))] StringBuilder? ObjectPath, out uint ReturnLength);
}