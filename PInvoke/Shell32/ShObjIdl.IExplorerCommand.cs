using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Windows Explorer command states.</summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "61e94e50-9e12-4a2c-a6c7-64a9181f80b8")]
		[Flags]
		public enum EXPCMDFLAGS
		{
			/// <summary>Windows 7 and later. No command flags are set.</summary>
			ECF_DEFAULT = 0x000,

			/// <summary>The command has subcommands.</summary>
			ECF_HASSUBCOMMANDS = 0x001,

			/// <summary>A split button is displayed.</summary>
			ECF_HASSPLITBUTTON = 0x002,

			/// <summary>The label is hidden.</summary>
			ECF_HIDELABEL = 0x004,

			/// <summary>The command is a separator.</summary>
			ECF_ISSEPARATOR = 0x008,

			/// <summary>A UAC shield is displayed.</summary>
			ECF_HASLUASHIELD = 0x010,

			/// <summary>Introduced in Windows 7. The command is located in the menu immediately below a separator.</summary>
			ECF_SEPARATORBEFORE = 0x020,

			/// <summary>Introduced in Windows 7. The command is located in the menu immediately above a separator.</summary>
			ECF_SEPARATORAFTER = 0x040,

			/// <summary>Introduced in Windows 7. Selecting the command opens a drop-down submenu (for example, Include in library).</summary>
			ECF_ISDROPDOWN = 0x080,

			/// <summary>Introduced in Windows 8.</summary>
			ECF_TOGGLEABLE = 0x100,

			/// <summary>Introduced in Windows 8.</summary>
			ECF_AUTOMENUICONS = 0x200,
		}

		/// <summary><c>EXPCMDSTATE</c> values represent the command state of a Shell item.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-_expcmdstate typedef enum _EXPCMDSTATE {
		// ECS_ENABLED, ECS_DISABLED, ECS_HIDDEN, ECS_CHECKBOX, ECS_CHECKED, ECS_RADIOCHECK } ;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "41e76b6e-9294-40b3-bb8b-bbfe487fd023")]
		[Flags]
		public enum EXPCMDSTATE
		{
			/// <summary>The item is enabled.</summary>
			ECS_ENABLED = 0x00,

			/// <summary>The item is unavailable. It might be displayed to the user as a dimmed, inaccessible item.</summary>
			ECS_DISABLED = 0x01,

			/// <summary>The item is hidden.</summary>
			ECS_HIDDEN = 0x02,

			/// <summary>The item is displayed with a check box and that check box is not checked.</summary>
			ECS_CHECKBOX = 0x04,

			/// <summary>The item is displayed with a check box and that check box is checked. ECS_CHECKED is always returned with ECS_CHECKBOX.</summary>
			ECS_CHECKED = 0x08,

			/// <summary>
			/// Windows 7 and later. The item is one of a group of mutually exclusive options selected through a radio button.
			/// ECS_RADIOCHECK does not imply that the item is the selected option, though it might be.
			/// </summary>
			ECS_RADIOCHECK = 0x10,
		}

		/// <summary>
		/// Provided by an IExplorerCommandProvider. This interface contains the enumeration of commands to be put into the command bar.
		/// </summary>
		/// <remarks>
		/// None of the methods of this interface should talk to network resources. They are called on the UI thread; communicating with
		/// network resources would cause the UI to stop responding.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ienumexplorercommand
		[PInvokeData("shobjidl_core.h", MSDNShortId = "c9a21e84-dd95-413a-b9db-e02008185bef")]
		[ComImport, Guid("a88826f8-186f-4987-aade-ea0cef8fbfe8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IEnumExplorerCommand : Vanara.Collections.ICOMEnum<IExplorerCommand>
		{
			/// <summary>Retrieves a specified number of elements that directly follow the current element.</summary>
			/// <param name="celt">
			/// <para>Type: <c>ULONG</c></para>
			/// <para>Specifies the number of elements to fetch.</para>
			/// </param>
			/// <param name="pUICommand">
			/// <para>Type: <c>IExplorerCommand**</c></para>
			/// <para>
			/// Address of an IExplorerCommand interface pointer array of celt elements that, when this method returns, is an array of
			/// pointers to the retrieved elements.
			/// </para>
			/// </param>
			/// <param name="pceltFetched">
			/// <para>Type: <c>ULONG*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to the number of elements actually retrieved. This pointer can be <c>NULL</c>
			/// if this information is not needed.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ienumexplorercommand-next HRESULT Next(
			// ULONG celt, IExplorerCommand **pUICommand, ULONG *pceltFetched );
			[PreserveSig]
			HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IExplorerCommand[] pUICommand, out uint pceltFetched);

			/// <summary>Not currently implemented.</summary>
			/// <param name="celt">
			/// <para>Type: <c>ULONG</c></para>
			/// <para>Currently unused.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ienumexplorercommand-skip HRESULT Skip(
			// ULONG celt );
			[PreserveSig]
			HRESULT Skip([In] uint celt);

			/// <summary>Resets the enumeration to 0.</summary>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ienumexplorercommand-reset HRESULT Reset();
			void Reset();

			/// <summary>Not currently implemented.</summary>
			/// <returns>
			/// <para>Type: <c>IEnumExplorerCommand*</c></para>
			/// <para>Currently unused.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ienumexplorercommand-clone HRESULT Clone(
			// IEnumExplorerCommand **ppenum );
			[return: MarshalAs(UnmanagedType.Interface)]
			IEnumExplorerCommand Clone();
		}

		/// <summary>Exposes methods that get the command appearance, enumerate subcommands, or invoke the command.</summary>
		/// <remarks>
		/// None of the methods of this interface should communicate with network resources. These methods are called on the UI thread, so
		/// communication with network resources could cause the UI to stop responding.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iexplorercommand
		[PInvokeData("shobjidl_core.h", MSDNShortId = "61e94e50-9e12-4a2c-a6c7-64a9181f80b8")]
		[ComImport, Guid("a08ce4d0-fa25-44ab-b57c-c7b1c323e0b9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IExplorerCommand
		{
			/// <summary>Gets the title text of the button or menu item that launches a specified Windows Explorer command item.</summary>
			/// <param name="psiItemArray">
			/// <para>Type: <c>IShellItemArray*</c></para>
			/// <para>A pointer to an IShellItemArray.</para>
			/// </param>
			/// <param name="ppszName">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>Pointer to a buffer that, when this method returns successfully, receives the title string.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iexplorercommand-gettitle HRESULT GetTitle(
			// IShellItemArray *psiItemArray, LPWSTR *ppszName );
			[PreserveSig]
			HRESULT GetTitle(IShellItemArray psiItemArray, [MarshalAs(UnmanagedType.LPWStr)] out string ppszName);

			/// <summary>Gets an icon resource string of the icon associated with the specified Windows Explorer command item.</summary>
			/// <param name="psiItemArray">
			/// <para>Type: <c>IShellItemArray*</c></para>
			/// <para>A pointer to an IShellItemArray.</para>
			/// </param>
			/// <param name="ppszIcon">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>
			/// Pointer to a buffer that, when this method returns successfully, receives the resource string that identifies the icon source.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>The retrieved icon resource string is in the standard format, for instance "shell32.dll,-249".</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iexplorercommand-geticon HRESULT GetIcon(
			// IShellItemArray *psiItemArray, LPWSTR *ppszIcon );
			[PreserveSig]
			HRESULT GetIcon(IShellItemArray psiItemArray, [MarshalAs(UnmanagedType.LPWStr)] out string ppszIcon);

			/// <summary>Gets the tooltip string associated with a specified Windows Explorer command item.</summary>
			/// <param name="psiItemArray">
			/// <para>Type: <c>IShellItemArray*</c></para>
			/// <para>A pointer to an IShellItemArray.</para>
			/// </param>
			/// <param name="ppszInfotip">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>Pointer to a buffer that, when this method returns successfully, receives the tooltip string.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iexplorercommand-gettooltip HRESULT
			// GetToolTip( IShellItemArray *psiItemArray, LPWSTR *ppszInfotip );
			[PreserveSig]
			HRESULT GetToolTip(IShellItemArray psiItemArray, [MarshalAs(UnmanagedType.LPWStr)] out string ppszInfotip);

			/// <summary>Gets the GUID of an Windows Explorer command.</summary>
			/// <param name="pguidCommandName">
			/// <para>Type: <c>GUID*</c></para>
			/// <para>
			/// A pointer to a value that, when this method returns successfully, receives the command's GUID, under which it is declared in
			/// the registry.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// This method is somewhat misnamed, given that it retrieves a GUID. To retrieve the command's canonical name, you must take
			/// the additional step to pull it from the command's subkey. The GUID is the name of the subkey. where that information is stored.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iexplorercommand-getcanonicalname HRESULT
			// GetCanonicalName( GUID *pguidCommandName );
			[PreserveSig]
			HRESULT GetCanonicalName(out Guid pguidCommandName);

			/// <summary>Gets state information associated with a specified Windows Explorer command item.</summary>
			/// <param name="psiItemArray">
			/// <para>Type: <c>IShellItemArray*</c></para>
			/// <para>A pointer to an IShellItemArray.</para>
			/// </param>
			/// <param name="fOkToBeSlow">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// <c>FALSE</c> if a verb object should not perform any memory intensive computations that could cause the UI thread to stop
			/// responding. The verb object should return E_PENDING in that case. If <c>TRUE</c>, those computations can be completed.
			/// </para>
			/// </param>
			/// <param name="pCmdState">
			/// <para>Type: <c>EXPCMDSTATE*</c></para>
			/// <para>
			/// A pointer to a value that, when this method returns successfully, receives one or more Windows Explorer command states
			/// indicated by the EXPCMDSTATE constants.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iexplorercommand-getstate HRESULT GetState(
			// IShellItemArray *psiItemArray, BOOL fOkToBeSlow, EXPCMDSTATE *pCmdState );
			[PreserveSig]
			HRESULT GetState(IShellItemArray psiItemArray, [MarshalAs(UnmanagedType.Bool)] bool fOkToBeSlow, out EXPCMDSTATE pCmdState);

			/// <summary>Invokes a Windows Explorer command.</summary>
			/// <param name="psiItemArray">
			/// <para>Type: <c>IShellItemArray*</c></para>
			/// <para>A pointer to an IShellItemArray.</para>
			/// </param>
			/// <param name="pbc">
			/// <para>Type: <c>IBindCtx*</c></para>
			/// <para>
			/// A pointer to an IBindCtx interface, which provides access to a bind context. This value can be <c>NULL</c> if no bind
			/// context is needed.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iexplorercommand-invoke HRESULT Invoke(
			// IShellItemArray *psiItemArray, IBindCtx *pbc );
			[PreserveSig]
			HRESULT Invoke(IShellItemArray psiItemArray, IBindCtx pbc);

			/// <summary>Gets the flags associated with a Windows Explorer command.</summary>
			/// <param name="pFlags">
			/// <para>Type: <c>EXPCMDFLAGS*</c></para>
			/// <para>When this method returns, this value points to the current command flags. One of more of the following values:</para>
			/// <para>ECF_DEFAULT (0x000)</para>
			/// <para><c>Windows 7 and later</c>. No command flags are set.</para>
			/// <para>ECF_HASSUBCOMMANDS (0x001)</para>
			/// <para>The command has subcommands.</para>
			/// <para>ECF_HASSPLITBUTTON (0x002)</para>
			/// <para>A split button is displayed.</para>
			/// <para>ECF_HIDELABEL (0x004)</para>
			/// <para>The label is hidden.</para>
			/// <para>ECF_ISSEPARATOR (0x008)</para>
			/// <para>The command is a separator.</para>
			/// <para>ECF_HASLUASHIELD (0x010)</para>
			/// <para>A UAC shield is displayed.</para>
			/// <para>ECF_SEPARATORBEFORE (0x020)</para>
			/// <para><c>Introduced in Windows 7</c>. The command is located in the menu immediately below a separator.</para>
			/// <para>ECF_SEPARATORAFTER (0x040)</para>
			/// <para><c>Introduced in Windows 7</c>. The command is located in the menu immediately above a separator.</para>
			/// <para>ECF_ISDROPDOWN (0x080)</para>
			/// <para><c>Introduced in Windows 7</c>. Selecting the command opens a drop-down submenu (for example, <c>Include in library</c>).</para>
			/// <para>ECF_TOGGLEABLE (0x100)</para>
			/// <para><c>Introduced in Windows 8</c>.</para>
			/// <para>ECF_AUTOMENUICONS (0x200)</para>
			/// <para><c>Introduced in Windows 8</c>.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iexplorercommand-getflags HRESULT GetFlags(
			// EXPCMDFLAGS *pFlags );
			[PreserveSig]
			HRESULT GetFlags(out EXPCMDFLAGS pFlags);

			/// <summary>Retrieves an enemerator for a command's subcommands.</summary>
			/// <param name="ppEnum">
			/// <para>Type: <c>IEnumExplorerCommand**</c></para>
			/// <para>
			/// When this method returns successfully, contains an IEnumExplorerCommand interface pointer that can be used to walk the set
			/// of subcommands.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Subcommands are displayed as menu drop-down items through the use of a Split button when commands are exposed at the top of
			/// a Windows Explorer window. In that position, only the default command button is given an icon. In a normal menu, the icons
			/// for all commands are shown.
			/// </para>
			/// <para>
			/// Subcommands which themselves have subcommands are not supported by Windows Explorer. When a command has its own subcommands,
			/// it must designate this status by specifying ECF_HASSUBCOMMANDS in the IExplorerCommand::GetFlags call.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iexplorercommand-enumsubcommands HRESULT
			// EnumSubCommands( IEnumExplorerCommand **ppEnum );
			[PreserveSig]
			HRESULT EnumSubCommands(out IEnumExplorerCommand ppEnum);
		}

		/// <summary>Exposes methods to create Explorer commands and command enumerators.</summary>
		/// <remarks>
		/// <para>
		/// None of the methods of this interface should communicate with network resources; they are called on the UI thread and doing so
		/// would cause the UI to stop responding.
		/// </para>
		/// <para>
		/// Each command should have its own unique GUID; the command provider is expected to create a command instance on a per-GUID basis.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iexplorercommandprovider
		[PInvokeData("shobjidl_core.h", MSDNShortId = "f39ea1f7-28ba-4a5e-ac19-bcfc6052fdeb")]
		[ComImport, Guid("64961751-0835-43c0-8ffe-d57686530e64"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IExplorerCommandProvider
		{
			/// <summary>Gets a specified Explorer command enumerator instance.</summary>
			/// <param name="punkSite">
			/// <para>Type: <c>IUnknown*</c></para>
			/// <para>A pointer to an interface used to set a site.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to the IID of the requested interface.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>When this function returns, contains the interface pointer requested in riid. This will typically be IEnumExplorerCommand.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iexplorercommandprovider-getcommands
			// HRESULT GetCommands( IUnknown *punkSite, REFIID riid, void **ppv );
			[PreserveSig]
			HRESULT GetCommands([MarshalAs(UnmanagedType.IUnknown)] object punkSite, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

			// IExplorerCommand
			/// <summary>Gets a specified Explorer command instance.</summary>
			/// <param name="rguidCommandId">
			/// <para>Type: <c>REFGUID</c></para>
			/// <para>A reference to a command ID as a <c>GUID</c>. Used to obtain a command definition.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to the IID of the requested interface.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>When this function returns, contains the interface pointer requested in riid. This will typically be IExplorerCommand.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iexplorercommandprovider-getcommand HRESULT
			// GetCommand( REFGUID rguidCommandId, REFIID riid, void **ppv );
			[PreserveSig]
			HRESULT GetCommand(in Guid rguidCommandId, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);
		}

		/// <summary>Exposes a single method that allows retrieval of the command state.</summary>
		/// <remarks>
		/// <para>When to Implement</para>
		/// <para>
		/// Implement this interface when you need to determine the command state dynamically (for instance, based on an item's properties).
		/// This interface provides the same functionality as IExplorerCommand::GetState, without the overhead of that interface's
		/// additional methods. Implement <c>IExplorerCommandState</c> when you only need to compute the command state.
		/// </para>
		/// <para>When to Use</para>
		/// <para>
		/// Do not call the method of <c>IExplorerCommandState</c> directly. Windows Explorer calls your IExplorerCommandState::GetState
		/// implementation when the user wants to perform an action on the item.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iexplorercommandstate
		[PInvokeData("shobjidl_core.h", MSDNShortId = "020a6f6f-1d45-44bd-a57f-ef8000976b5b")]
		[ComImport, Guid("bddacb60-7657-47ae-8445-d23e1acf82ae"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IExplorerCommandState
		{
			/// <summary>Gets the command state associated with a specified Shell item.</summary>
			/// <param name="psiItemArray">
			/// <para>Type: <c>IShellItemArray*</c></para>
			/// <para>A pointer to an IShellItemArray with a single element that represents the Shell item.</para>
			/// </param>
			/// <param name="fOkToBeSlow">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// <c>FALSE</c> if a verb object should not perform any memory intensive computations that could cause the UI thread to stop
			/// responding. The verb object should return E_PENDING in that case. If <c>TRUE</c>, those computations can be completed.
			/// </para>
			/// </param>
			/// <param name="pCmdState">
			/// <para>Type: <c>EXPCMDSTATE*</c></para>
			/// <para>
			/// A pointer to a value that, when this method returns successfully, receives one or more Windows Explorer command states
			/// indicated by the EXPCMDSTATE constants.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// This method provides the same functionality as GetState. Use IExplorerCommandState when you only need to know the command state.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iexplorercommandstate-getstate HRESULT
			// GetState( IShellItemArray *psiItemArray, BOOL fOkToBeSlow, EXPCMDSTATE *pCmdState );
			[PreserveSig]
			HRESULT GetState(IShellItemArray psiItemArray, [MarshalAs(UnmanagedType.Bool)] bool fOkToBeSlow, out EXPCMDSTATE pCmdState);
		}
	}
}