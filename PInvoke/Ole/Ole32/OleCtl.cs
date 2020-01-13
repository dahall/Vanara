using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>Instructs an in-process server to create its registry entries for all classes supported in this server module.</summary>
		/// <returns>
		/// <para>This function can return the standard return values E_OUTOFMEMORY and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The registry entries were created successfully.</term>
		/// </item>
		/// <item>
		/// <term>SELFREG_E_TYPELIB</term>
		/// <term>The server was unable to complete the registration of all the type libraries used by its classes.</term>
		/// </item>
		/// <item>
		/// <term>SELFREG_E_CLASS</term>
		/// <term>The server was unable to complete the registration of all the object classes.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>E_NOTIMPL is not a valid return code.</para>
		/// <para>If this function fails, the state of the registry for all its classes is undefined.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/olectl/nf-olectl-dllregisterserver HRESULT DllRegisterServer();
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("olectl.h", MSDNShortId = "4442206b-b2ad-47d7-8add-18002c44c5a2")]
		public static extern HRESULT DllRegisterServer();

		/// <summary>Instructs an in-process server to remove only those entries created through DllRegisterServer.</summary>
		/// <returns>
		/// <para>This function can return the standard return values E_OUTOFMEMORY and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The registry entries were deleted successfully.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>Unregistration of this server's known entries was successful, but other entries still exist for this server's classes.</term>
		/// </item>
		/// <item>
		/// <term>SELFREG_E_TYPELIB</term>
		/// <term>The server was unable to remove the entries of all the type libraries used by its classes.</term>
		/// </item>
		/// <item>
		/// <term>SELFREG_E_CLASS</term>
		/// <term>The server was unable to remove the entries of all the object classes.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The server must not disturb any entries that it did not create which currently exist for its object classes. For example,
		/// between registration and unregistration, the user may have specified a Treat As relationship between this class and another. In
		/// that case, unregistration can remove all entries except the <c>TreatAs</c> key and any others that were not explicitly created
		/// in DllRegisterServer. The registry functions specifically disallow the deletion of an entire populated tree in the registry. The
		/// server can attempt, as the last step, to remove the CLSID key, but if other entries still exist, the key will remain.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/olectl/nf-olectl-dllunregisterserver HRESULT DllUnregisterServer();
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("olectl.h", MSDNShortId = "b71137a7-284e-4521-a3b2-9dad9c9d3c54")]
		public static extern HRESULT DllUnregisterServer();
	}
}