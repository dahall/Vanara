#if (NET20 || NET35)
namespace Microsoft.Win32.SafeHandles
{
	using System;
	using System.Security;
	using Vanara.InteropServices;

	/// <summary>
	/// Represents a safe handle to the Windows registry.
	/// </summary>
	[SecurityCritical]
	public sealed class SafeRegistryHandle : GenericSafeHandle
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SafeRegistryHandle"/> class.
		/// </summary>
		[SecurityCritical]
		internal SafeRegistryHandle() : this(IntPtr.Zero) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="SafeRegistryHandle"/> class.
		/// </summary>
		/// <param name="preexistingHandle">An object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle"><c>true</c> to reliably release the handle during the finalization phase; <c>false</c> to prevent reliable release.</param>
		[SecurityCritical]
		public SafeRegistryHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, h => Vanara.PInvoke.AdvApi32.RegCloseKey(h) == 0, ownsHandle)
		{
			SetHandle(preexistingHandle);
		}
	}
}
#endif