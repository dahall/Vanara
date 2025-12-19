using System.Collections.Generic;
using System.Linq;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;
using IComDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;

namespace Vanara.Windows.Shell;

/// <summary>Static class with methods to interact with the Clipboard.</summary>
/// <example>
/// <code title="Indirect manipulation">// This model let's you place multiple formats at once on the clipboard
/// IDataObject ido = NativeClipboard.CreateEmptyDataObject();
/// ido.SetData(CLIPFORMAT.CF_UNICODETEXT, txt);
/// ido.SetData(Shell32.ShellClipboardFormat.CF_HTML, htmlFragment);
/// ido.SetData("MyRectFormat", new RECT(1, 2, 3, 4));
/// NativeClipboard.SetDataObject(ido);</code></example>
public static class NativeClipboard
{
	private const int stdRetryCnt = 5;
	private const int stdRetryDelay = 100;
	private static readonly object objectLock = new();
	private static ListenerWindow? listener;
	[ThreadStatic]
	private static bool oleInit;

	/// <summary>Occurs when whenever the contents of the Clipboard have changed.</summary>
	public static event EventHandler ClipboardUpdate
	{
		add
		{
			lock (objectLock)
			{
				listener ??= new ListenerWindow();
				InternalClipboardUpdate += value;
			}
		}
		remove
		{
			lock (objectLock)
			{
				InternalClipboardUpdate -= value;
				if (InternalClipboardUpdate is null || InternalClipboardUpdate.GetInvocationList().Length == 0)
					listener = null;
			}
		}
	}

	private static event EventHandler? InternalClipboardUpdate;

	/// <summary>Gets the <see cref="IComDataObject"/> instance from the Windows Clipboard.</summary>
	/// <value>A <see cref="IComDataObject"/> instance.</value>
	public static IComDataObject CurrentDataObject
	{
		get
		{
			Init();
			int n = stdRetryCnt;
			HRESULT hr = HRESULT.S_OK;
			for (int i = 1; i <= n; i++)
			{
				hr = OleGetClipboard(out var idata);
				if (hr.Succeeded)
					return idata;
				if (i < n)
					System.Threading.Thread.Sleep(stdRetryDelay);
			}
			throw hr.GetException()!;
		}
	}

	/// <summary>Retrieves the currently supported clipboard formats.</summary>
	/// <value>A sequence of the currently supported formats.</value>
	public static IEnumerable<uint> CurrentlySupportedFormats
	{
		get
		{
			GetUpdatedClipboardFormats(null, 0, out var cnt);
			var fmts = new uint[cnt];
			Win32Error.ThrowLastErrorIfFalse(GetUpdatedClipboardFormats(fmts, (uint)fmts.Length, out cnt));
			return [.. fmts.Take((int)cnt)];
		}
	}

	/// <summary>Retrieves the clipboard sequence number for the current window station.</summary>
	/// <returns>
	/// The clipboard sequence number. If you do not have <c>WINSTA_ACCESSCLIPBOARD</c> access to the window station, the function
	/// returns zero.
	/// </returns>
	/// <remarks>
	/// The system keeps a serial number for the clipboard for each window station. This number is incremented whenever the contents of
	/// the clipboard change or the clipboard is emptied. You can track this value to determine whether the clipboard contents have
	/// changed and optimize creating DataObjects. If clipboard rendering is delayed, the sequence number is not incremented until the
	/// changes are rendered.
	/// </remarks>
	public static uint SequenceNumber => GetClipboardSequenceNumber();

	/// <summary>Clears the clipboard of any data or formatting.</summary>
	public static void Clear() => SetDataObject(null);

	/// <summary>Puts a list of shell items onto the clipboard.</summary>
	/// <param name="shellItems">The sequence of shell items. The PIDL of each shell item must be absolute.</param>
	public static IComDataObject CreateDataObjectFromShellItems(params ShellItem[] shellItems) => shellItems.Length == 0 ? CreateEmptyDataObject() : new ShellItemArray(shellItems).ToDataObject()!;

	/// <summary>Puts a list of shell items onto the clipboard.</summary>
	/// <param name="parent">The parent folder instance.</param>
	/// <param name="relativeShellItems">The sequence of shell items relative to <paramref name="parent"/>.</param>
	public static IComDataObject CreateDataObjectFromShellItems(ShellFolder parent, params ShellItem[] relativeShellItems)
	{
		if (parent is null) throw new ArgumentNullException(nameof(parent));
		if (relativeShellItems.Length == 0) return CreateEmptyDataObject();
		SHCreateDataObject(parent.PIDL, relativeShellItems.Select(i => i.PIDL), default, out var dataObj).ThrowIfFailed();
		return dataObj!;
	}

	/// <summary>Creates an empty, writable data object.</summary>
	/// <value>The data object.</value>
	public static IComDataObject CreateEmptyDataObject()
	{
		SHCreateDataObject(ppv: out var writableDataObj).ThrowIfFailed();
		return writableDataObj!;
	}

	/// <summary>Carries out the clipboard shutdown sequence. It also releases any IDataObject instances that were placed on the clipboard.</summary>
	public static void Flush() { Init(); TryMultThenThrowIfFailed(OleFlushClipboard); }

	/// <summary>Retrieves the window handle of the current owner of the clipboard.</summary>
	/// <returns>
	/// <para>If the function succeeds, the return value is the handle to the window that owns the clipboard.</para>
	/// <para>If the clipboard is not owned, the return value is <c>IntPtr.Zero</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>The clipboard can still contain data even if the clipboard is not currently owned.</para>
	/// <para>In general, the clipboard owner is the window that last placed data in clipboard.</para>
	/// </remarks>
	public static HWND GetClipboardOwner() => User32.GetClipboardOwner();

	/// <summary>Retrieves the first available clipboard format in the specified list.</summary>
	/// <param name="idList">The clipboard formats, in priority order.</param>
	/// <returns>
	/// If the function succeeds, the return value is the first clipboard format in the list for which data is available. If the
	/// clipboard is empty, the return value is 0. If the clipboard contains data, but not in any of the specified formats, the return
	/// value is –1.
	/// </returns>
	public static int GetFirstFormatAvailable(params uint[] idList) => GetPriorityClipboardFormat(idList, idList.Length);

	/// <summary>Retrieves from the clipboard the name of the specified registered format.</summary>
	/// <param name="formatId">The type of format to be retrieved.</param>
	/// <returns>The format name.</returns>
	public static string GetFormatName(uint formatId) => ShellClipboardFormat.GetName(formatId);

	/// <summary>Retrieves the handle to the window that currently has the clipboard open.</summary>
	/// <returns>
	/// If the function succeeds, the return value is the handle to the window that has the clipboard open. If no window has the
	/// clipboard open, the return value is <c>IntPtr.Zero</c>.
	/// </returns>
	/// <remarks>
	/// If an application or DLL specifies a <c>NULL</c> window handle when calling the OpenClipboard function, the clipboard is opened
	/// but is not associated with a window. In such a case, <c>GetOpenClipboardWindow</c> returns <c>IntPtr.Zero</c>.
	/// </remarks>
	public static HWND GetOpenClipboardWindow() => User32.GetOpenClipboardWindow();

	/// <summary>Determines whether the data object pointer previously placed on the clipboard is still on the clipboard.</summary>
	/// <param name="dataObject">
	/// The IDataObject interface on the data object containing clipboard data of interest, which the caller previously placed on the clipboard.
	/// </param>
	/// <returns><see langword="true"/> on success; otherwise, <see langword="false"/>.</returns>
	public static bool IsCurrentDataObject(IComDataObject dataObject) => OleIsCurrentClipboard(dataObject) == HRESULT.S_OK;

	/// <summary>Determines whether the clipboard contains data in the specified format.</summary>
	/// <param name="id">A standard or registered clipboard format.</param>
	/// <returns>If the clipboard format is available, the return value is <see langword="true"/>; otherwise <see langword="false"/>.</returns>
	public static bool IsFormatAvailable(uint id) => IsClipboardFormatAvailable(id);

	/// <summary>Determines whether the clipboard contains data in the specified format.</summary>
	/// <param name="id">A clipboard format string.</param>
	/// <returns>If the clipboard format is available, the return value is <see langword="true"/>; otherwise <see langword="false"/>.</returns>
	public static bool IsFormatAvailable(string id) => IsClipboardFormatAvailable(RegisterFormat(id));

	// EnumAvailableFormats().Contains(id);
	/// <summary>Registers a new clipboard format. This format can then be used as a valid clipboard format.</summary>
	/// <param name="format">The name of the new format.</param>
	/// <returns>The registered clipboard format identifier.</returns>
	/// <exception cref="ArgumentNullException">format</exception>
	/// <remarks>
	/// If a registered format with the specified name already exists, a new format is not registered and the return value identifies the
	/// existing format. This enables more than one application to copy and paste data using the same registered clipboard format. Note
	/// that the format name comparison is case-insensitive.
	/// </remarks>
	public static uint RegisterFormat(string format) => ShellClipboardFormat.Register(format);

	/// <summary>
	/// Places a specific data object onto the clipboard. This makes the data object accessible to the OleGetClipboard function.
	/// </summary>
	/// <param name="dataObj">
	/// The IDataObject interface on the data object from which the data to be placed on the clipboard can be obtained.
	/// </param>
	public static void SetDataObject(IComDataObject? dataObj)
	{
		Init();
		TryMultThenThrowIfFailed(OleSetClipboard, dataObj);
		if (dataObj is not null)
			Marshal.ReleaseComObject(dataObj);
		Flush();
	}

	private static void Init() { if (!oleInit) { oleInit = OleInitialize().Succeeded; } }

	private static bool TryMultThenThrowIfFailed(Func<HRESULT> func, int n = stdRetryCnt)
	{
		HRESULT hr = HRESULT.S_OK;
		for (int i = 1; i <= n; i++)
		{
			hr = func();
			if (hr.Succeeded)
				return hr == HRESULT.S_OK;
			if (i < n)
				System.Threading.Thread.Sleep(stdRetryDelay);
		}
		throw hr.GetException()!;
	}

	private static bool TryMultThenThrowIfFailed(Func<IComDataObject?, HRESULT> func, IComDataObject? o, int n = stdRetryCnt)
	{
		HRESULT hr = HRESULT.S_OK;
		for (int i = 1; i <= n; i++)
		{
			hr = func(o);
			if (hr.Succeeded)
				return hr == HRESULT.S_OK;
			if (i < n)
				System.Threading.Thread.Sleep(stdRetryDelay);
		}
		throw hr.GetException()!;
	}

	private class ListenerWindow : SystemEventHandler
	{
		protected override bool MessageFilter(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam, out IntPtr lReturn)
		{
			lReturn = default;
			switch (msg)
			{
				case (uint)WindowMessage.WM_DESTROY:
					RemoveClipboardFormatListener(MessageWindowHandle);
					break;

				case (uint)ClipboardNotificationMessage.WM_CLIPBOARDUPDATE:
					InternalClipboardUpdate?.Invoke(this, EventArgs.Empty);
					break;
			}
			return false;
		}

		protected override void OnMessageWindowHandleCreated()
		{
			base.OnMessageWindowHandleCreated();
			AddClipboardFormatListener(MessageWindowHandle);
		}
	}
}