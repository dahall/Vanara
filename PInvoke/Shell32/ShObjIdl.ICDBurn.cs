namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>One of the following values indicating the supported type.</summary>
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.ICDBurnExt")]
	[Flags]
	public enum CDBE_ACTIONS : uint
	{
		/// <summary>
		/// 0x00000001. Music files are supported. The CD writing extension is invoked for the <c>Copy to audio CD</c> task in the My
		/// Music folder.
		/// </summary>
		CDBE_TYPE_MUSIC = 0x1,

		/// <summary>0x00000002. Data files are supported. The CD writing extension is excluded from <c>Copy to audio CD</c>.</summary>
		CDBE_TYPE_DATA = 0x2,

		/// <summary>
		/// (int)0xFFFFFFFF. All files are supported. The CD writing extension is invoked for the <c>Copy to audio CD</c> task in the My
		/// Music folder.
		/// </summary>
		CDBE_TYPE_ALL = 0xffffffff
	}

	/// <summary>
	/// Exposes methods that determine whether a system has hardware for writing to CD, the drive letter of a CD writer device, and
	/// programmatically initiate a CD writing session.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-icdburn
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.ICDBurn")]
	[ComImport, Guid("3d73a659-e5d0-4d42-afc0-5121ba425c8d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(CDBurn))]
	public interface ICDBurn
	{
		/// <summary>Gets the drive letter of a CD drive that has been marked as write-enabled.</summary>
		/// <param name="pszDrive">
		/// <para>Type: <c>LPWSTR</c></para>
		/// <para>A pointer to a string containing the drive letter, for example "F:".</para>
		/// </param>
		/// <param name="cch">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The size of the string, in characters, pointed to by pszDrive. This value will normally be 4. Values larger than 4 are
		/// allowed, but the extra characters will be ignored by this method. Values less than 4 will generate an E_INVALIDARG error.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The drive whose letter designation is returned by this method is the drive that has the <c>Enable cd writing on this
		/// drive</c> option selected. This option is found on the drive's property sheet. Only one drive on a system can have this
		/// option selected.
		/// </para>
		/// <para>If a recordable CD drive is present but that option has been deselected, the method will return an error code.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-icdburn-getrecorderdriveletter HRESULT
		// GetRecorderDriveLetter( LPWSTR pszDrive, UINT cch );
		void GetRecorderDriveLetter([MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDrive, uint cch);

		/// <summary>Instructs data to be copied from the staging area to a writable CD.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle of the parent window of the UI.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// The staging area has a default location of %userprofile%\Local Settings\Application Data\Microsoft\CD Burning. Its actual
		/// path can be retrieved through SHGetFolderPath, SHGetSpecialFolderPath, SHGetFolderLocation, SHGetSpecialFolderLocation, or
		/// SHGetFolderPathAndSubDir by using the CSIDL_CDBURN_AREA value.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-icdburn-burn HRESULT Burn( HWND hwnd );
		void Burn(HWND hwnd);

		/// <summary>Scans the system for a CD drive with write-capability, returning <c>TRUE</c> if one is found.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>A pointer to a Boolean value containing <c>TRUE</c> if a suitable device is located, <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// This search does not rely on the state of the <c>Enable cd writing on this drive</c> option found on the drive's property
		/// sheet. Instead, the determination is based on IMAPI.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-icdburn-hasrecordabledrive HRESULT
		// HasRecordableDrive( BOOL *pfHasRecorder );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool HasRecordableDrive();
	}

	/// <summary>
	/// <para>
	/// [ <c>ICDBurnExt</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Exposes a single method that determines content types supported by a CD writing extension.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-icdburnext
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.ICDBurnExt")]
	[ComImport, Guid("2271dcca-74fc-4414-8fb7-c56b05ace2d7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ICDBurnExt
	{
		/// <summary>Determines the supported data type for a CD writing extension.</summary>
		/// <returns>
		/// <para>Type: <c>CDBE_ACTIONS*</c></para>
		/// <para>One of the following values indicating the supported type.</para>
		/// <para>CDBE_TYPE_MUSIC (0x00000001)</para>
		/// <para>
		/// 0x00000001. Music files are supported. The CD writing extension is invoked for the <c>Copy to audio CD</c> task in the My
		/// Music folder.
		/// </para>
		/// <para>CDBE_TYPE_DATA (0x00000002)</para>
		/// <para>0x00000002. Data files are supported. The CD writing extension is excluded from <c>Copy to audio CD</c>.</para>
		/// <para>CDBE_TYPE_ALL ((int)0xFFFFFFFF)</para>
		/// <para>
		/// (int)0xFFFFFFFF. All files are supported. The CD writing extension is invoked for the <c>Copy to audio CD</c> task in the My
		/// Music folder.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-icdburnext-getsupportedactiontypes HRESULT
		// GetSupportedActionTypes( CDBE_ACTIONS *pdwActions );
		CDBE_ACTIONS GetSupportedActionTypes();
	}

	/// <summary>CoClass for ICDBurn</summary>
	[PInvokeData("shobjidl.h")]
	[ComImport, Guid("fbeb8a05-beee-4442-804e-409d6c4515e9"), ClassInterface(ClassInterfaceType.None)]
	public class CDBurn { }
}