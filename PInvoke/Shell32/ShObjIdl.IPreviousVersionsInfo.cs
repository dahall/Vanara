using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>
	/// Exposes a method that checks for previous versions of server files or folders, stored for the purpose of reversion by the shadow
	/// copies technology provided with Windows Server 2003.
	/// </summary>
	/// <remarks>
	/// <para>The CLSID, IID, and definition for this interface are shown in the following example.</para>
	/// <para>
	/// Note that the shadow copies technology does not store entire copies of older versions unless they are deleted; only the changed
	/// bits are stored.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-ipreviousversionsinfo
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IPreviousVersionsInfo")]
	[ComImport, Guid("76e54780-ad74-48e3-a695-3ba9a0aff10d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(PreviousVersionsInfo))]
	public interface IPreviousVersionsInfo
	{
		/// <summary>Queries for the availablilty of a Windows Server 2003 volume image recorded by the system at an earlier time.</summary>
		/// <param name="pszPath">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated Unicode string containing the fully qualified path to a file or folder on the volume in question.</para>
		/// <para><c>Note</c> Only paths to files and folders stored on a Windows Server 2003 volume are currently supported.</para>
		/// </param>
		/// <param name="fOkToBeSlow">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A boolean value specifying whether a server should be contacted to determine the availability of stored volume images. For
		/// more details, see the Remarks section.
		/// </para>
		/// <para>TRUE</para>
		/// <para>Contact the server if the results are not already cached.</para>
		/// <para>FALSE</para>
		/// <para>Do not contact the server. Use cached results instead.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// A pointer to a boolean variable containing the result. This value is valid only if the method call succeeds; otherwise, it
		/// is undefined.
		/// </para>
		/// <para>TRUE</para>
		/// <para>At least one stored image of the volume where the file or folder named in pszPath resides is available.</para>
		/// <para>FALSE</para>
		/// <para>No volume images are stored.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If <c>IPreviousVersionsInfo::AreSnapshotsAvailable</c> is called on a file or folder, the result does not indicate that
		/// rollback information is available for that specific file or folder, merely that a snapshot of the entire volume is
		/// available. This result is cached and subsequent calls inquiring about anything stored on that same volume access the cached
		/// results—with little performance overhead—instead of recontacting the server.
		/// </para>
		/// <para>
		/// Once the server's response is cached in memory, subsequent calls do not contact the server even if fOkToBeSlow is
		/// <c>TRUE</c>. If fOkToBeSlow is <c>FALSE</c> and the server's response is not already cached from a previous call, the method
		/// returns E_PENDING. In that case, set fOkToBeSlow to <c>TRUE</c> and call <c>IPreviousVersionsInfo::AreSnapshotsAvailable</c>
		/// again to contact the server.
		/// </para>
		/// <para>
		/// For better performance, a UI thread calling this method should always set fOkToBeSlow to <c>FALSE</c>. If the method returns
		/// E_PENDING, follow these steps.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Create another instance of IPreviousVersionsInfo on a background thread.</term>
		/// </item>
		/// <item>
		/// <term>Call <c>IPreviousVersionsInfo::AreSnapshotsAvailable</c> with fOkToBeSlow set to <c>TRUE</c>.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Signal the original UI thread to call <c>IPreviousVersionsInfo::AreSnapshotsAvailable</c> again. The results are then pulled
		/// from the cache.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ipreviousversionsinfo-aresnapshotsavailable HRESULT
		// AreSnapshotsAvailable( LPCWSTR pszPath, BOOL fOkToBeSlow, BOOL *pfAvailable );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool AreSnapshotsAvailable([MarshalAs(UnmanagedType.LPWStr)] string pszPath, [MarshalAs(UnmanagedType.Bool)] bool fOkToBeSlow);
	}

	/// <summary>CoClass for IPreviousVersionsInfo</summary>
	[PInvokeData("shobjidl.h")]
	[ComImport, Guid("596AB062-B4D2-4215-9F74-E9109B0A8153"), ClassInterface(ClassInterfaceType.None)]
	public class PreviousVersionsInfo { }
}