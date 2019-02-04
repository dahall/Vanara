using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Gdi32
	{
		/// <summary>
		/// <para>
		/// The <c>CreateEnhMetaFile</c> function creates a device context for an enhanced-format metafile. This device context can be used
		/// to store a device-independent picture.
		/// </para>
		/// </summary>
		/// <param name="hdc">
		/// <para>
		/// A handle to a reference device for the enhanced metafile. This parameter can be <c>NULL</c>; for more information, see Remarks.
		/// </para>
		/// </param>
		/// <param name="lpFilename">
		/// <para>
		/// A pointer to the file name for the enhanced metafile to be created. If this parameter is <c>NULL</c>, the enhanced metafile is
		/// memory based and its contents are lost when it is deleted by using the DeleteEnhMetaFile function.
		/// </para>
		/// </param>
		/// <param name="lprc">
		/// <para>
		/// A pointer to a RECT structure that specifies the dimensions (in .01-millimeter units) of the picture to be stored in the enhanced metafile.
		/// </para>
		/// </param>
		/// <param name="lpDesc">
		/// <para>
		/// A pointer to a string that specifies the name of the application that created the picture, as well as the picture's title. This
		/// parameter can be <c>NULL</c>; for more information, see Remarks.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the device context for the enhanced metafile.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Where text arguments must use Unicode characters, use the <c>CreateEnhMetaFile</c> function as a wide-character function. Where
		/// text arguments must use characters from the Windows character set, use this function as an ANSI function.
		/// </para>
		/// <para>
		/// The system uses the reference device identified by the hdcRef parameter to record the resolution and units of the device on which
		/// a picture originally appeared. If the hdcRef parameter is <c>NULL</c>, it uses the current display device for reference.
		/// </para>
		/// <para>
		/// The <c>left</c> and <c>top</c> members of the RECT structure pointed to by the lpRect parameter must be less than the
		/// <c>right</c> and <c>bottom</c> members, respectively. Points along the edges of the rectangle are included in the picture. If
		/// lpRect is <c>NULL</c>, the graphics device interface (GDI) computes the dimensions of the smallest rectangle that surrounds the
		/// picture drawn by the application. The lpRect parameter should be provided where possible.
		/// </para>
		/// <para>
		/// The string pointed to by the lpDescription parameter must contain a null character between the application name and the picture
		/// name and must terminate with two null charactersfor example, "XYZ Graphics Editor\0Bald Eagle\0\0", where \0 represents the null
		/// character. If lpDescription is <c>NULL</c>, there is no corresponding entry in the enhanced-metafile header.
		/// </para>
		/// <para>
		/// Applications use the device context created by this function to store a graphics picture in an enhanced metafile. The handle
		/// identifying this device context can be passed to any GDI function.
		/// </para>
		/// <para>
		/// After an application stores a picture in an enhanced metafile, it can display the picture on any output device by calling the
		/// PlayEnhMetaFile function. When displaying the picture, the system uses the rectangle pointed to by the lpRect parameter and the
		/// resolution data from the reference device to position and scale the picture.
		/// </para>
		/// <para>The device context returned by this function contains the same default attributes associated with any new device context.</para>
		/// <para>Applications must use the GetWinMetaFileBits function to convert an enhanced metafile to the older Windows metafile format.</para>
		/// <para>The file name for the enhanced metafile should use the .emf extension.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating an Enhanced Metafile.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createenhmetafilea HDC CreateEnhMetaFileA( HDC hdc, LPCSTR
		// lpFilename, const RECT *lprc, LPCSTR lpDesc );
		[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("wingdi.h", MSDNShortId = "647f83ca-dca3-44af-a594-5f9ba2bd7607")]
		public static extern HDC CreateEnhMetaFile(HDC hdc, string lpFilename, ref RECT lprc, string lpDesc);

		/// <summary>
		/// <para>The <c>DeleteEnhMetaFile</c> function deletes an enhanced-format metafile or an enhanced-format metafile handle.</para>
		/// </summary>
		/// <param name="hmf">
		/// <para>A handle to an enhanced metafile.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the hemf parameter identifies an enhanced metafile stored in memory, the <c>DeleteEnhMetaFile</c> function deletes the
		/// metafile. If hemf identifies a metafile stored on a disk, the function deletes the metafile handle but does not destroy the
		/// actual metafile. An application can retrieve the file by calling the GetEnhMetaFile function.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Opening an Enhanced Metafile and Displaying Its Contents.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-deleteenhmetafile BOOL DeleteEnhMetaFile( HENHMETAFILE hmf );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "d3b93b3b-fa0b-4480-8348-19919c9e904d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteEnhMetaFile(HENHMETAFILE hmf);

		/// <summary>
		/// <para>
		/// The <c>GetEnhMetaFile</c> function creates a handle that identifies the enhanced-format metafile stored in the specified file.
		/// </para>
		/// </summary>
		/// <param name="lpName">
		/// <para>A pointer to a null-terminated string that specifies the name of an enhanced metafile.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the enhanced metafile.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When the application no longer needs an enhanced-metafile handle, it should delete the handle by calling the DeleteEnhMetaFile function.
		/// </para>
		/// <para>
		/// A Windows-format metafile must be converted to the enhanced format before it can be processed by the <c>GetEnhMetaFile</c>
		/// function. To convert the file, use the SetWinMetaFileBits function.
		/// </para>
		/// <para>
		/// Where text arguments must use Unicode characters, use this function as a wide-character function. Where text arguments must use
		/// characters from the Windows character set, use this function as an ANSI function.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Opening an Enhanced Metafile and Displaying Its Contents.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-getenhmetafilea HENHMETAFILE GetEnhMetaFileA( LPCSTR lpName );
		[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("wingdi.h", MSDNShortId = "bcb9611e-8e4e-4f87-8a1e-dedbe0042821")]
		public static extern SafeHENHMETAFILE GetEnhMetaFile(string lpName);

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HENHMETAFILE"/> that is disposed using <see cref="DeleteEnhMetaFile"/>.</summary>
		public class SafeHENHMETAFILE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHENHMETAFILE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHENHMETAFILE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHENHMETAFILE"/> class.</summary>
			private SafeHENHMETAFILE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHENHMETAFILE"/> to <see cref="HENHMETAFILE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HENHMETAFILE(SafeHENHMETAFILE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => DeleteEnhMetaFile(this);
		}

		/*
		CloseMetaFile
		CopyMetaFile
		CreateMetaFile
		DeleteMetaFile
		EnumMetaFile
		GetMetaFile
		GetMetaFileBitsEx
		PlayMetaFile
		PlayMetaFileRecord
		SetMetaFileBitsEx

		CloseEnhMetaFile
		CopyEnhMetaFile
		ENHMFENUMPROC
		EnumEnhMetaFile
		MFENUMPROC
		GdiComment
		GetEnhMetaFileBits
		GetEnhMetaFileDescription
		GetEnhMetaFileHeader
		GetEnhMetaFilePaletteEntries
		GetWinMetaFileBits
		PlayEnhMetaFile
		PlayEnhMetaFileRecord
		SetEnhMetaFileBits
		SetWinMetaFileBits
		*/
	}
}