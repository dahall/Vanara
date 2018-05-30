using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class ShlwApi
	{
		/// <summary>Searches for a file.</summary>
		/// <param name="pszFile">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string of length MAX_PATH that contains the file name for which to search. If the search is successful, this parameter
		/// is used to return the fully qualified path name.
		/// </para>
		/// </param>
		/// <param name="ppszOtherDirs">
		/// <para>Type: <c>LPCTSTR*</c></para>
		/// <para>An optional, null-terminated array of directories to be searched first. This value can be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </returns>
		// BOOL PathFindOnPath( _Inout_ LPTSTR pszFile, _In_opt_ LPCTSTR *ppszOtherDirs);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb773594(v=vs.85).aspx
		[PInvokeData("Shlwapi.h", MSDNShortId = "bb773594")]
		[DllImport(Lib.Shlwapi, CharSet = CharSet.Auto, SetLastError = false)]
		public static extern bool PathFindOnPath(StringBuilder pszFile, [In] string[] ppszOtherDirs);

		/// <summary>Opens or creates a file and retrieves a stream to read or write to that file.</summary>
		/// <param name="pszFile">A pointer to a null-terminated string that specifies the file name.</param>
		/// <param name="grfMode">One or more STGM values that are used to specify the file access mode and how the object that exposes the stream is created and deleted.</param>
		/// <param name="dwAttributes">One or more flag values that specify file attributes in the case that a new file is created. For a complete list of possible values, see the dwFlagsAndAttributes parameter of the CreateFile function.</param>
		/// <param name="fCreate">A BOOL value that helps specify, in conjunction with grfMode, how existing files should be treated when creating the stream. See Remarks for details.</param>
		/// <param name="pstmTemplate">Reserved.</param>
		/// <param name="ppstm">Receives an IStream interface pointer for the stream associated with the file.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.Shlwapi, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[PInvokeData("Shlwapi.h", MSDNShortId = "bb759866")]
		public static extern HRESULT SHCreateStreamOnFileEx(string pszFile, STGM grfMode, FileFlagsAndAttributes dwAttributes,
			[MarshalAs(UnmanagedType.Bool)] bool fCreate, [Optional] IStream pstmTemplate, out IStream ppstm);
	}
}
