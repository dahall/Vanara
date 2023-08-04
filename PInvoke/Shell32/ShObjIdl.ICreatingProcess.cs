using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Used by the ICreatingProcess interface to alter some parameters of the process that is being created.</summary>
	/// <remarks>
	/// <para>Applications do not implement this interface.</para>
	/// <para>A pointer to this interface is passed to ICreatingProcess::OnCreating.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-icreateprocessinputs
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.ICreateProcessInputs")]
	[ComImport, Guid("F6EF6140-E26F-4D82-bAC4-E9BA5FD239A8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ICreateProcessInputs
	{
		/// <summary>Gets the additional flags that will be passed to CreateProcess.</summary>
		/// <returns>
		/// A pointer to a <c>DWORD</c> which receives the flags that will be passed as the dwCreationFlags parameter to CreateProcess.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icreateprocessinputs-getcreateflags HRESULT
		// GetCreateFlags( DWORD *pdwCreationFlags );
		CREATE_PROCESS GetCreateFlags();

		/// <summary>Set the flags that will be included in the call to CreateProcess.</summary>
		/// <param name="dwCreationFlags">The flags that will be passed to the dwCreationFlags parameter to CreateProcess.</param>
		/// <remarks>
		/// Any flags set by a previous call to AddCreateFlags or <c>SetCreateFlags</c> will be replaced by the values specified by
		/// dwCreationFlags. Use <c>AddCreateFlags</c> to set flags without clearing flags that are already set.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icreateprocessinputs-setcreateflags HRESULT
		// SetCreateFlags( DWORD dwCreationFlags );
		void SetCreateFlags(CREATE_PROCESS dwCreationFlags);

		/// <summary>Set additional flags that will be included in the call to CreateProcess.</summary>
		/// <param name="dwCreationFlags">The flags that will be included in the dwCreationFlags parameter passed to CreateProcess.</param>
		/// <remarks>Any creation flags that were previously set will remain set. This method does not clear any creation flags.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icreateprocessinputs-addcreateflags HRESULT
		// AddCreateFlags( DWORD dwCreationFlags );
		void AddCreateFlags(CREATE_PROCESS dwCreationFlags);

		/// <summary>Sets the hot key for the application.</summary>
		/// <param name="wHotKey">
		/// The hotkey to assign to the application. See the documentation of the <c>hStdIn</c> member of the <see cref="STARTUPINFO"/>
		/// structure for more information.
		/// </param>
		/// <remarks>
		/// This method also sets the <c>STARTF_USEHOTKEY</c> flag in the <c>dwFlags</c> member of the STARTUPINFO structure passed to CreateProcess.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icreateprocessinputs-sethotkey HRESULT
		// SetHotKey( WORD wHotKey );
		void SetHotKey(ushort wHotKey);

		/// <summary>Additional flags that will be included in the <see cref="STARTUPINFO"/> structure passed to CreateProcess.</summary>
		/// <param name="dwStartupInfoFlags">
		/// The flags that will be included in the <see cref="STARTUPINFO.dwFlags"/> member passed to CreateProcess.
		/// </param>
		/// <remarks>Any creation flags that were previously set will remain set. This method does not clear any creation flags.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icreateprocessinputs-addstartupflags
		// HRESULT AddStartupFlags( DWORD dwStartupInfoFlags );
		void AddStartupFlags(STARTF dwStartupInfoFlags);

		/// <summary>Sets the title that will be passed CreateProcess.</summary>
		/// <param name="pszTitle">
		/// A null-terminated string specifying the title that will be passed in the <c>lpTitle</c> member of the STARTUPINFO structure
		/// passed to CreateProcess. This parameter may not be <c>NULL</c>.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icreateprocessinputs-settitle HRESULT
		// SetTitle( LPCWSTR pszTitle );
		void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

		/// <summary>Sets a variable in the environment of the created process.</summary>
		/// <param name="pszName">
		/// A null-terminated string specifying the name of a variable to be set in the environment of the process to be created. This
		/// parameter may not be <c>NULL</c>.
		/// </param>
		/// <param name="pszValue">
		/// A null-terminated string specifying the value of the variable to be set in the environment of the process to be created. his
		/// parameter may not be <c>NULL</c>.
		/// </param>
		/// <remarks>If a variable with the same name already exists in the environment of the created process, it is replaced.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icreateprocessinputs-setenvironmentvariable
		// HRESULT SetEnvironmentVariable( LPCWSTR pszName, LPCWSTR pszValue );
		void SetEnvironmentVariable([MarshalAs(UnmanagedType.LPWStr)] string pszName, [MarshalAs(UnmanagedType.LPWStr)] string pszValue);
	}

	/// <summary>Used by ShellExecuteEx and IContextMenu to allow the caller to alter some parameters of the process being created.</summary>
	/// <remarks>
	/// <para>
	/// The caller should install an object into the site chain which implements IServiceProvider::QueryService and responds to the
	/// <c>SID_ExecuteCreatingProcess</c> service ID with an object that implements the <c>ICreatingProcess</c> interface.
	/// </para>
	/// <para>
	/// After performing the desired operations, the object should forward the ICreatingProcess::OnCreating call up the site chain to
	/// allow other members of the site chain to participate.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-icreatingprocess
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.ICreatingProcess")]
	[ComImport, Guid("c2b937a9-3110-4398-8a56-f34c6342d244"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ICreatingProcess
	{
		/// <summary>Allows you to modify the parameters of the process being created.</summary>
		/// <param name="pcpi">
		/// A pointer to an ICreateProcessInputs interface which allows you to set some parameters for the process that is being created.
		/// </param>
		/// <returns><c>S_OK</c> if the method succeeds. Otherwise, an <c>HRESULT</c> error code, and the process is not created.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-icreatingprocess-oncreating HRESULT
		// OnCreating( ICreateProcessInputs *pcpi );
		[PreserveSig]
		HRESULT OnCreating([In] ICreateProcessInputs pcpi);
	}
}