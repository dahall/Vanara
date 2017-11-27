// ReSharper disable InconsistentNaming

using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Platform invokable enumerated types, constants and functions from oleaut.h</summary>
	public static partial class OleAut32
	{
		/// <summary>Clears a variant.</summary>
		/// <param name="pvarg">The variant to clear.</param>
		/// <returns>S_OK on success.</returns>
		[DllImport(Lib.OleAut32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("OleAuto.h", MSDNShortId = "ms221165")]
		public static extern HRESULT VariantClear(IntPtr pvarg);
	}
}