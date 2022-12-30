using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;
using IComDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;

namespace Vanara.Windows.Shell
{
	/// <summary>Specifies the text data formats that can be used to query, get and set text data format with Clipboard.</summary>
	public enum TextDataFormat
	{
		/// <summary>Specifies the standard ANSI text format.</summary>
		Text,

		/// <summary>Specifies the standard Windows Unicode text format.</summary>
		UnicodeText,

		/// <summary>Specifies text consisting of Rich Text Format (RTF) data.</summary>
		Rtf,

		/// <summary>Specifies text consisting of HTML data.</summary>
		Html,

		/// <summary>Specifies a comma-separated value (CSV) format, which is a common interchange format used by spreadsheets.</summary>
		CommaSeparatedValue,
	}

	/// <summary>
	/// Initializes and closes a session using the Clipboard calling <see cref="OpenClipboard"/> and then <see cref="CloseClipboard"/> on
	/// disposal. This can be called multiple times in nested calls and will ensure the Clipboard is only opened and closed at the highest scope.
	/// </summary>
	/// <seealso cref="System.IDisposable"/>
	public class NativeClipboard : IDisposable
	{
		private static readonly object objectLock = new();
		private static Dictionary<uint, string> knownIds;
		private static ListenerWindow listener;

		[ThreadStatic]
		private static bool open = false;

		private readonly bool dontClose = false;

		/// <summary>Initializes a new instance of the <see cref="NativeClipboard"/> class.</summary>
		/// <param name="empty">If set to <see langword="true"/>, <see cref="EmptyClipboard"/> is called to clear the Clipboard.</param>
		/// <param name="hWndNewOwner">
		/// A handle to the window to be associated with the open clipboard. If this parameter is <c>HWND.NULL</c>, the open clipboard is
		/// associated with the current task.
		/// </param>
		public NativeClipboard(bool empty = false, HWND hWndNewOwner = default)
		{
			if (open)
			{
				dontClose = true;
				return;
			}
			if (hWndNewOwner == default)
				hWndNewOwner = GetDesktopWindow();
			Win32Error.ThrowLastErrorIfFalse(OpenClipboard(hWndNewOwner));
			open = true;
			if (empty)
				Empty();
		}

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

		private static event EventHandler InternalClipboardUpdate;

		/// <summary>Retrieves the currently supported clipboard formats.</summary>
		/// <value>A sequence of the currently supported formats.</value>
		public static IEnumerable<uint> CurrentlySupportedFormats
		{
			get
			{
				GetUpdatedClipboardFormats(null, 0, out var cnt);
				var fmts = new uint[cnt];
				Win32Error.ThrowLastErrorIfFalse(GetUpdatedClipboardFormats(fmts, (uint)fmts.Length, out cnt));
				return fmts.Take((int)cnt).ToArray();
			}
		}

		/// <summary>Gets or sets a <see cref="IComDataObject"/> instance from the Windows Clipboard.</summary>
		/// <value>A <see cref="IComDataObject"/> instance.</value>
		public static IComDataObject DataObject
		{
			get
			{
				OleGetClipboard(out var idata).ThrowIfFailed();
				return idata;
			}
			set => OleSetClipboard(value).ThrowIfFailed();
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

		/// <summary>Carries out the clipboard shutdown sequence. It also releases any IDataObject instances that were placed on the clipboard.</summary>
		public static void Flush() => OleFlushClipboard().ThrowIfFailed();

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

		/// <summary>Obtains data from the clipboard.</summary>
		/// <param name="formatId">Specifies the particular clipboard format of interest.</param>
		/// <param name="aspect">
		/// Indicates how much detail should be contained in the rendering. This parameter should be one of the DVASPECT enumeration values.
		/// A single clipboard format can support multiple aspects or views of the object. Most data and presentation transfer and caching
		/// methods pass aspect information. For example, a caller might request an object's iconic picture, using the metafile clipboard
		/// format to retrieve it. Note that only one DVASPECT value can be used in dwAspect. That is, dwAspect cannot be the result of a
		/// Boolean OR operation on several DVASPECT values.
		/// </param>
		/// <param name="index">
		/// Part of the aspect when the data must be split across page boundaries. The most common value is -1, which identifies all of the
		/// data. For the aspects DVASPECT_THUMBNAIL and DVASPECT_ICON, lindex is ignored.
		/// </param>
		/// <returns>The object associated with the request. If no object can be determined, a <see cref="byte"/>[] is returned.</returns>
		/// <exception cref="System.InvalidOperationException">Unrecognized TYMED value.</exception>
		public static object GetData(uint formatId, DVASPECT aspect = DVASPECT.DVASPECT_CONTENT, int index = -1) =>
			DataObject.GetData(formatId, aspect, index);

		/// <summary>Obtains data from the clipboard.</summary>
		/// <typeparam name="T">The type of the object being retrieved.</typeparam>
		/// <param name="formatId">Specifies the particular clipboard format of interest.</param>
		/// <param name="index">
		/// Part of the aspect when the data must be split across page boundaries. The most common value is -1, which identifies all of the
		/// data. For the aspects DVASPECT_THUMBNAIL and DVASPECT_ICON, lindex is ignored.
		/// </param>
		/// <returns>The object associated with the request. If no object can be determined, <c>default(T)</c> is returned.</returns>
		public static T GetData<T>(uint formatId, int index = -1) => DataObject.GetData<T>(formatId, index);

		/// <summary>
		/// This is used when a group of files in CF_HDROP (FileDrop) format is being renamed as well as transferred. The data consists of an
		/// array that contains a new name for each file, in the same order that the files are listed in the accompanying CF_HDROP format.
		/// The format of the character array is the same as that used by CF_HDROP to list the transferred files.
		/// </summary>
		/// <returns>A list of strings containing a new name for each file.</returns>
		public static string[] GetFileNameMap()
		{
			if (IsFormatAvailable(ShellClipboardFormat.CFSTR_FILENAMEMAPW))
				return DataObject.GetData(RegisterFormat(ShellClipboardFormat.CFSTR_FILENAMEMAPW)) as string[];
			else if (IsFormatAvailable(ShellClipboardFormat.CFSTR_FILENAMEMAPA))
				return DataObject.GetData(RegisterFormat(ShellClipboardFormat.CFSTR_FILENAMEMAPA)) as string[];
			return new string[0];
		}

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
		public static string GetFormatName(uint formatId)
		{
			EnsureKnownIds();
			if (knownIds.TryGetValue(formatId, out var value))
				return value;

			// Ask sysetm for the registered name
			StringBuilder sb = new(80);
			int ret;
			while (0 != (ret = GetClipboardFormatName(formatId, sb, sb.Capacity)))
			{
				if (ret < sb.Capacity - 1)
				{
					knownIds.Add(formatId, sb.ToString());
					return sb.ToString();
				}
				sb.Capacity *= 2;
			}

			// Failing all elsewhere, return value as hex string
			return string.Format(CultureInfo.InvariantCulture, "0x{0:X4}", formatId);
		}

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

		/// <summary>Gets the shell item array associated with the data object, if possible.</summary>
		/// <returns>The <see cref="ShellItemArray"/> associated with the data object, if set. Otherwise, <see langword="null"/>.</returns>
		public static ShellItemArray GetShellItemArray() => IsFormatAvailable(ShellClipboardFormat.CFSTR_SHELLIDLIST) ? ShellItemArray.FromDataObject(DataObject) : null;

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

		/// <summary>Registers a new clipboard format. This format can then be used as a valid clipboard format.</summary>
		/// <param name="format">The name of the new format.</param>
		/// <returns>The registered clipboard format identifier.</returns>
		/// <exception cref="System.ArgumentNullException">format</exception>
		/// <remarks>
		/// If a registered format with the specified name already exists, a new format is not registered and the return value identifies the
		/// existing format. This enables more than one application to copy and paste data using the same registered clipboard format. Note
		/// that the format name comparison is case-insensitive.
		/// </remarks>
		public static uint RegisterFormat(string format)
		{
			if (format is null) throw new ArgumentNullException(nameof(format));

			EnsureKnownIds();
			var id = knownIds.FirstOrDefault(p => p.Value == format).Key;
			if (id != 0)
				return id;

			id = Win32Error.ThrowLastErrorIf(RegisterClipboardFormat(format), v => v == 0);
			knownIds.Add(id, format);
			return id;
		}

		/// <summary>Puts a list of shell items onto the clipboard.</summary>
		/// <param name="shellItems">The sequence of shell items. The PIDL of each shell item must be absolute.</param>
		public static void SetShellItems(IEnumerable<ShellItem> shellItems)
		{
			DataObject = (shellItems is ShellItemArray shia ? shia : new ShellItemArray(shellItems)).ToDataObject();
		}

		/// <summary>Puts a list of shell items onto the clipboard.</summary>
		/// <param name="parent">The parent folder instance.</param>
		/// <param name="relativeShellItems">The sequence of shell items relative to <paramref name="parent"/>.</param>
		public static void SetShellItems(ShellFolder parent, IEnumerable<ShellItem> relativeShellItems)
		{
			if (parent is null) throw new ArgumentNullException(nameof(parent));
			if (relativeShellItems is null) throw new ArgumentNullException(nameof(relativeShellItems));
			var pidls = relativeShellItems.Select(i => i.PIDL.DangerousGetHandle()).ToArray();
			SHCreateDataObject(parent.PIDL, (uint)pidls.Length, pidls, default, typeof(IComDataObject).GUID, out var dataObj).ThrowIfFailed();
			OleSetClipboard(dataObj).ThrowIfFailed();

			//DataObject = dataObj = shellItems is ShellItemArray shia ? shia.ToDataObject() : new ShellItemArray(shellItems).ToDataObject();
			//if (!setAllFormats) return;
			//var files = shellItems.Where(i => i.IsFileSystem).Select(i => i.FileSystemPath).ToArray();
			//if (files.Length == 0) return;
			//dataObj.SetData(CLIPFORMAT.CF_HDROP, files);
			//dataObj.SetData(RegisterFormat(ShellClipboardFormat.CFSTR_FILENAMEA), files[0]);
			//dataObj.SetData(RegisterFormat(ShellClipboardFormat.CFSTR_FILENAMEW), files[0]);
			//dataObj.SetData(RegisterFormat(ShellClipboardFormat.CFSTR_FILEDESCRIPTORA));
		}

		/// <summary>Obtains data from a source data object.</summary>
		/// <typeparam name="T">The type of the object being retrieved.</typeparam>
		/// <param name="formatId">Specifies the particular clipboard format of interest.</param>
		/// <param name="obj">The object associated with the request. If no object can be determined, <c>default(T)</c> is returned.</param>
		/// <param name="index">
		/// Part of the aspect when the data must be split across page boundaries. The most common value is -1, which identifies all of the
		/// data. For the aspects DVASPECT_THUMBNAIL and DVASPECT_ICON, lindex is ignored.
		/// </param>
		/// <returns><see langword="true"/> if data is available and retrieved; otherwise <see langword="false"/>.</returns>
		public static bool TryGetData<T>(uint formatId, out T obj, int index = -1) => DataObject.TryGetData(formatId, out obj, index);

		/// <summary>
		/// Retrieves data from the clipboard in a specified format. The clipboard must have been opened previously and this pointer cannot
		/// be used once <see cref="NativeClipboard"/> goes out of scope.
		/// </summary>
		/// <param name="formatId">A clipboard format. For a description of the standard clipboard formats, see Standard Clipboard Formats.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the handle to a clipboard object in the specified format.</para>
		/// <para>If the function fails, the return value is <c>IntPtr.Zero</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>Caution</c> Clipboard data is not trusted. Parse the data carefully before using it in your application.</para>
		/// <para>An application can enumerate the available formats in advance by using the EnumClipboardFormats function.</para>
		/// <para>
		/// The clipboard controls the handle that the <c>GetClipboardData</c> function returns, not the application. The application should
		/// copy the data immediately. The application must not free the handle nor leave it locked. The application must not use the handle
		/// after the <see cref="Empty"/> method is called, after <see cref="NativeClipboard"/> is disposed, or after any of the
		/// <c>Set...</c> methods are called with the same clipboard format.
		/// </para>
		/// <para>
		/// The system performs implicit data format conversions between certain clipboard formats when an application calls the
		/// <c>GetClipboardData</c> function. For example, if the CF_OEMTEXT format is on the clipboard, a window can retrieve data in the
		/// CF_TEXT format. The format on the clipboard is converted to the requested format on demand. For more information, see Synthesized
		/// Clipboard Formats.
		/// </para>
		/// </remarks>
		public IntPtr DanagerousGetData(uint formatId) => GetClipboardData(formatId);

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			if (dontClose) return;
			CloseClipboard();
			open = false;
		}

		/// <summary>
		/// Empties the clipboard and frees handles to data in the clipboard. The function then assigns ownership of the clipboard to the
		/// window that currently has the clipboard open.
		/// </summary>
		public void Empty() => Win32Error.ThrowLastErrorIfFalse(EmptyClipboard());

		/// <summary>Enumerates the data formats currently available on the clipboard.</summary>
		/// <returns>An enumeration of the data formats currently available on the clipboard.</returns>
		/// <remarks>
		/// <para>
		/// The <c>EnumFormats</c> function enumerates formats in the order that they were placed on the clipboard. If you are copying
		/// information to the clipboard, add clipboard objects in order from the most descriptive clipboard format to the least descriptive
		/// clipboard format. If you are pasting information from the clipboard, retrieve the first clipboard format that you can handle.
		/// That will be the most descriptive clipboard format that you can handle.
		/// </para>
		/// <para>
		/// The system provides automatic type conversions for certain clipboard formats. In the case of such a format, this function
		/// enumerates the specified format, then enumerates the formats to which it can be converted.
		/// </para>
		/// </remarks>
		public IEnumerable<uint> EnumAvailableFormats() => EnumClipboardFormats();

		/// <summary>Gets the text from the native Clipboard in the specified format.</summary>
		/// <param name="formatId">A clipboard format. For a description of the standard clipboard formats, see Standard Clipboard Formats.</param>
		/// <returns>The string value or <see langword="null"/> if the format is not available.</returns>
		public string GetText(TextDataFormat formatId) => formatId switch
		{
			TextDataFormat.Text => Marshal.PtrToStringAnsi(GetClipboardData(CLIPFORMAT.CF_TEXT)),
			TextDataFormat.UnicodeText => Marshal.PtrToStringUni(GetClipboardData(CLIPFORMAT.CF_UNICODETEXT)),
			TextDataFormat.Rtf => StringHelper.GetString(GetClipboardData(RegisterFormat(ShellClipboardFormat.CF_RTF)), CharSet.Ansi),
			TextDataFormat.Html => Utils.GetHtml(GetClipboardData(RegisterFormat(ShellClipboardFormat.CF_HTML))),
			TextDataFormat.CommaSeparatedValue => StringHelper.GetString(GetClipboardData(RegisterFormat(ShellClipboardFormat.CF_CSV)), CharSet.Ansi),
			_ => throw new ArgumentOutOfRangeException(nameof(formatId)),
		};

		/// <summary>Places data on the clipboard in a specified clipboard format.</summary>
		/// <param name="formatId">The clipboard format. This parameter can be a registered format or any of the standard clipboard formats.</param>
		/// <param name="data">The binary data in the specified format.</param>
		/// <exception cref="System.ArgumentNullException">data</exception>
		public void SetBinaryData(uint formatId, byte[] data)
		{
			using var pMem = new SafeMoveableHGlobalHandle(data);
			Win32Error.ThrowLastErrorIfInvalid(pMem);
			pMem.Unlock();
			Win32Error.ThrowLastErrorIfNull(SetClipboardData(formatId, pMem.DangerousGetHandle()));
		}

		/// <summary>Places data on the clipboard in a specified clipboard format.</summary>
		/// <param name="formatId">The clipboard format. This parameter can be a registered format or any of the standard clipboard formats.</param>
		/// <param name="data">The data in the format dictated by <paramref name="formatId"/>.</param>
		public void SetData<T>(uint formatId, T data)
		{
			using var pMem = SafeMoveableHGlobalHandle.CreateFromStructure(data);
			Win32Error.ThrowLastErrorIfInvalid(pMem);
			pMem.Unlock();
			Win32Error.ThrowLastErrorIfNull(SetClipboardData(formatId, pMem.DangerousGetHandle()));
		}

		/// <summary>Places data on the clipboard in a specified clipboard format.</summary>
		/// <param name="formatId">The clipboard format. This parameter can be a registered format or any of the standard clipboard formats.</param>
		/// <param name="values">The data in the format dictated by <paramref name="formatId"/>.</param>
		public void SetData<T>(uint formatId, IEnumerable<T> values) where T : struct
		{
			using var pMem = SafeMoveableHGlobalHandle.CreateFromList(values);
			Win32Error.ThrowLastErrorIfInvalid(pMem);
			pMem.Unlock();
			Win32Error.ThrowLastErrorIfNull(SetClipboardData(formatId, pMem.DangerousGetHandle()));
		}

		/// <summary>Places data on the clipboard in a specified clipboard format.</summary>
		/// <param name="formatId">The clipboard format. This parameter can be a registered format or any of the standard clipboard formats.</param>
		/// <param name="values">The list of strings.</param>
		/// <param name="packing">The packing type for the strings.</param>
		/// <param name="charSet">The character set to use for the strings.</param>
		public void SetData(uint formatId, IEnumerable<string> values, StringListPackMethod packing = StringListPackMethod.Concatenated, CharSet charSet = CharSet.Auto)
		{
			using var pMem = SafeMoveableHGlobalHandle.CreateFromStringList(values, packing, charSet);
			Win32Error.ThrowLastErrorIfInvalid(pMem);
			pMem.Unlock();
			Win32Error.ThrowLastErrorIfNull(SetClipboardData(formatId, pMem.DangerousGetHandle()));
		}

		/// <summary>Sets multiple text types to the Clipboard.</summary>
		/// <param name="text">The Unicode Text value.</param>
		/// <param name="htmlText">The HTML text value. If <see langword="null"/>, this format will not be set.</param>
		/// <param name="rtfText">The Rich Text Format value. If <see langword="null"/>, this format will not be set.</param>
		public void SetText(string text, string htmlText = null, string rtfText = null)
		{
			if (text is null && htmlText is null && rtfText is null) return;
			SetText(text, TextDataFormat.UnicodeText);
			if (htmlText != null) SetText(htmlText, TextDataFormat.Html);
			if (rtfText != null) SetText(rtfText, TextDataFormat.Rtf);
		}

		/// <summary>Sets a specific text type to the Clipboard.</summary>
		/// <param name="value">The text value.</param>
		/// <param name="format">The clipboard text format to set.</param>
		public void SetText(string value, TextDataFormat format)
		{
			(byte[] bytes, uint fmt) = format switch
			{
				TextDataFormat.Text => (UnicodeToAnsiBytes(value), (uint)CLIPFORMAT.CF_TEXT),
				TextDataFormat.UnicodeText => (Encoding.Unicode.GetBytes(value + '\0'), (uint)CLIPFORMAT.CF_UNICODETEXT),
				TextDataFormat.Rtf => (Encoding.ASCII.GetBytes(value + '\0'), RegisterFormat(ShellClipboardFormat.CF_RTF)),
				TextDataFormat.Html => (FormatHtmlForClipboard(value), RegisterFormat(ShellClipboardFormat.CF_HTML)),
				TextDataFormat.CommaSeparatedValue => (Encoding.ASCII.GetBytes(value + '\0'), RegisterFormat(ShellClipboardFormat.CF_CSV)),
				_ => throw new ArgumentOutOfRangeException(nameof(format)),
			};
			SetBinaryData(fmt, bytes);
		}

		/// <summary>Sets a URL with optional title to the clipboard.</summary>
		/// <param name="url">The URL.</param>
		/// <param name="title">The title. This value can be <see langword="null"/>.</param>
		/// <exception cref="ArgumentNullException">url</exception>
		public void SetUrl(string url, string title = null)
		{
			if (url is null) throw new ArgumentNullException(nameof(url));
			SetText(url, $"<a href=\"{url}\">{title ?? url}</a>", null);
			var textUrl = url + (title is null ? "" : ('\n' + title)) + '\0';
			SetBinaryData(RegisterFormat(ShellClipboardFormat.CFSTR_INETURLA), Encoding.ASCII.GetBytes(textUrl));
			SetBinaryData(RegisterFormat(ShellClipboardFormat.CFSTR_INETURLW), Encoding.Unicode.GetBytes(textUrl));
		}

		private static void EnsureKnownIds()
		{
			if (knownIds is not null)
				return;
			var type = typeof(CLIPFORMAT);
			knownIds = type.GetFields(BindingFlags.Static | BindingFlags.Public).Where(f => f.FieldType == type && f.IsInitOnly).ToDictionary(f => (uint)(CLIPFORMAT)f.GetValue(null), f => f.Name);
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
}