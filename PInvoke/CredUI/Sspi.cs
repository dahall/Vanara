using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;

// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Global

namespace Vanara.PInvoke
{
	public static partial class CredUI
	{
		/*[DllImport(Lib.CredUI, CharSet = CharSet.Auto)]
		[PInvokeData("wincred.h", MSDNShortId = "aa375181")]
		public static extern SECURITY_STATUS SspiGetCredUIContext(IntPtr ContextHandle, [MarshalAs(UnmanagedType.LPStruct)] Guid CredType, [MarshalAs(UnmanagedType.LPStruct)] Guid LogonId,
			out PSEC_WINNT_CREDUI_CONTEXT_VECTOR CredUIContexts, out IntPtr TokenHandle);*/
	}
}