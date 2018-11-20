using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>Frees the specified storage medium.</summary>
		/// <param name="pMedium">Pointer to the storage medium that is to be freed.</param>
		[DllImport(Lib.Ole32, ExactSpelling = true)]
		[PInvokeData("Ole2.h", MSDNShortId = "ms693491")]
		public static extern void ReleaseStgMedium(in STGMEDIUM pMedium);

		/// <summary>Closes the COM library on the apartment, releases any class factories, other COM objects, or servers held by the apartment, disables RPC on the apartment, and frees any resources the apartment maintains.</summary>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Ole2.h", MSDNShortId = "ms691326")]
		public static extern void OleUninitialize();

		/// <summary>
		/// Initializes the COM library on the current apartment, identifies the concurrency model as single-thread apartment (STA), and enables additional
		/// functionality described in the Remarks section below. Applications must initialize the COM library before they can call COM library functions other
		/// than CoGetMalloc and memory allocation functions.
		/// </summary>
		/// <param name="pvReserved">This parameter is reserved and must be NULL.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader><term>Return code</term><term>Description</term></listheader>
		/// <item><term>S_FALSE</term><defintion>The COM library is already initialized on this thread.</defintion></item>
		/// <item><term>OLE_E_WRONGCOMPOBJ</term><defintion>The versions of COMPOBJ.DLL and OLE2.DLL on your machine are incompatible with each other.</defintion></item>
		/// <item><term>RPC_E_CHANGED_MODE</term><defintion>A previous call to CoInitializeEx specified the concurrency model for this thread as multithreaded apartment (MTA). This could also indicate that a change from neutral-threaded apartment to single-threaded apartment has occurred.</defintion></item>
		/// </list>
		/// </returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Ole2.h", MSDNShortId = "ms690134")]
		public static extern HRESULT OleInitialize([Optional] IntPtr pvReserved);
	}
}