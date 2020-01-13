using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>The <c>IsApiSetImplemented</c> function tests if a specified API set is present on the computer.</summary>
		/// <param name="Contract">Specifies the name of the API set to query. For more info, see the Remarks section.</param>
		/// <returns>
		/// <para>
		/// <c>IsApiSetImplemented</c> returns <c>TRUE</c> if the specified API set is present. In this case, APIs in the target API set
		/// have valid implementations on the current platform.
		/// </para>
		/// <para>Otherwise, this function returns <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// On OneCore, APIs are organized into functional groups called API sets. Depending on applicability, a given API set may be
		/// unavailable on the target platform.
		/// </para>
		/// <para>
		/// When writing code that targets OneCore and Desktop platforms, you may see ApiValidator errors during compilation if your code
		/// calls APIs from API sets not present on the computer.
		/// </para>
		/// <para>
		/// To fix this problem, wrap the API call in <c>IsApiSetImplemented</c>. This function tests at runtime if the specified API set is
		/// present on the target platform.
		/// </para>
		/// <para>
		/// To determine the API set for a given API, find the API name on the OneCoreUap umbrella library page and remove the suffix from
		/// the requirements entry.
		/// </para>
		/// <para>By making use of <c>IsApiSetImplemented</c>, you can target OneCore and Desktop systems with a single binary.</para>
		/// <para>
		/// You don't need to call <c>IsApiSetImplemented</c> for universal APIs because they are by definition present on both OneCore and
		/// Desktop versions of Windows.
		/// </para>
		/// <para>
		/// See the corresponding API reference documentation pages to determine if a given API is universally available. Look for the
		/// <c>Target Platform</c> line in the requirements block of the documentation page.
		/// </para>
		/// <para>For more information and examples of usage, see Building for OneCore.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/apiquery2/nf-apiquery2-isapisetimplemented APICONTRACT BOOL
		// IsApiSetImplemented( PCSTR Contract );
		[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("apiquery2.h", MSDNShortId = "DF177716-9F33-4E39-BD63-D1B8E39CD67C")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsApiSetImplemented([MarshalAs(UnmanagedType.LPStr)] string Contract);
	}
}