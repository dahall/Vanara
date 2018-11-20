#if (NET20 || NET35)

namespace Microsoft.Win32.SafeHandles
{
	using System;
	using System.Runtime.InteropServices;
	using System.Security;

	/// <summary>Represents a safe handle to the Windows registry.</summary>
	[SecurityCritical]
	public sealed class SafeRegistryHandle : SafeHandleZeroOrMinusOneIsInvalid
	{
		/// <summary>Initializes a new instance of the <see cref="SafeRegistryHandle"/> class.</summary>
		/// <param name="preexistingHandle">An object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; <see langword="false"/> to prevent reliable release.
		/// </param>
		[SecurityCritical]
		public SafeRegistryHandle(IntPtr preexistingHandle, bool ownsHandle) : base(ownsHandle) => SetHandle(preexistingHandle);

		[SecurityCritical]
		internal SafeRegistryHandle() : base(true) { }

		/// <inheritdoc/>
		[SecurityCritical]
		protected override bool ReleaseHandle() => RegCloseKey(handle).Succeeded;

		[DllImport(Vanara.PInvoke.Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		private static extern Vanara.PInvoke.Win32Error RegCloseKey(IntPtr hKey);
	}
}

#endif