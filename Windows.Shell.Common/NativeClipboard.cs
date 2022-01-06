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
		private static int HdrLen = 0;
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
			if (!OpenClipboard(hWndNewOwner))
				Win32Error.ThrowLastError();
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

		/// <summary>Retrieves the first available clipboard format in the specified list.</summary>
		/// <param name="idList">The clipboard formats, in priority order.</param>
		/// <returns>
		/// If the function succeeds, the return value is the first clipboard format in the list for which data is available. If the
		/// clipboard is empty, the return value is 0. If the clipboard contains data, but not in any of the specified formats, the return
		/// value is –1.
		/// </returns>
		public static int GetFirstFormatAvailable(params int[] idList) => GetPriorityClipboardFormat(Array.ConvertAll(idList, i => (uint)i), idList.Length);

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
			TextDataFormat.Text => StringHelper.GetString(GetClipboardData(CLIPFORMAT.CF_TEXT), CharSet.Ansi),
			TextDataFormat.UnicodeText => StringHelper.GetString(GetClipboardData(CLIPFORMAT.CF_UNICODETEXT), CharSet.Unicode),
			TextDataFormat.Rtf => StringHelper.GetString(DanagerousGetData(RegisterFormat(ShellClipboardFormat.CF_RTF)), CharSet.Ansi),
			TextDataFormat.Html => GetHtml(DanagerousGetData(RegisterFormat(ShellClipboardFormat.CF_HTML))),
			TextDataFormat.CommaSeparatedValue => StringHelper.GetString(DanagerousGetData(RegisterFormat(ShellClipboardFormat.CF_CSV)), CharSet.Ansi),
			_ => null,
		};

		/// <summary>Places data on the clipboard in a specified clipboard format.</summary>
		/// <param name="formatId">The clipboard format. This parameter can be a registered format or any of the standard clipboard formats.</param>
		/// <param name="data">The binary data in the specified format.</param>
		/// <exception cref="System.ArgumentNullException">data</exception>
		public void SetBinaryData(uint formatId, byte[] data)
		{
			using var pMem = new SafeMoveableHGlobalHandle(data);
			Win32Error.ThrowLastErrorIfInvalid(pMem);
			Win32Error.ThrowLastErrorIfNull(SetClipboardData((uint)formatId, pMem.DangerousGetHandle()));
		}

		/// <summary>Places data on the clipboard in a specified clipboard format.</summary>
		/// <param name="formatId">The clipboard format. This parameter can be a registered format or any of the standard clipboard formats.</param>
		/// <param name="data">The data in the format dictated by <paramref name="formatId"/>.</param>
		public void SetData<T>(uint formatId, T data)
		{
			using var pMem = SafeMoveableHGlobalHandle.CreateFromStructure(data);
			Win32Error.ThrowLastErrorIfInvalid(pMem);
			Win32Error.ThrowLastErrorIfNull(SetClipboardData((uint)formatId, pMem.DangerousGetHandle()));
		}

		/// <summary>Places data on the clipboard in a specified clipboard format.</summary>
		/// <param name="formatId">The clipboard format. This parameter can be a registered format or any of the standard clipboard formats.</param>
		/// <param name="values">The data in the format dictated by <paramref name="formatId"/>.</param>
		public void SetData<T>(uint formatId, IEnumerable<T> values) where T : struct
		{
			using var pMem = SafeMoveableHGlobalHandle.CreateFromList(values);
			Win32Error.ThrowLastErrorIfInvalid(pMem);
			Win32Error.ThrowLastErrorIfNull(SetClipboardData((uint)formatId, pMem.DangerousGetHandle()));
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
			Win32Error.ThrowLastErrorIfNull(SetClipboardData((uint)formatId, pMem.DangerousGetHandle()));
		}

		/// <summary>Sets multiple text types to the Clipboard.</summary>
		/// <param name="text">The Unicode Text value.</param>
		/// <param name="htmlText">The HTML text value. If <see langword="null"/>, this format will not be set.</param>
		/// <param name="rtfText">The Rich Text Format value. If <see langword="null"/>, this format will not be set.</param>
		public void SetText(string text, string htmlText = null, string rtfText = null)
		{
			if (text is null && htmlText is null && rtfText is null) return;
			SetText(text, TextDataFormat.Text);
			SetText(text, TextDataFormat.UnicodeText);
			SetBinaryData(RegisterFormat("Locale"), BitConverter.GetBytes(CultureInfo.CurrentCulture.LCID));
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
				TextDataFormat.Text => (Encoding.ASCII.GetBytes(value + '\0'), (uint)CLIPFORMAT.CF_TEXT),
				TextDataFormat.UnicodeText => (Encoding.Unicode.GetBytes(value + '\0'), (uint)CLIPFORMAT.CF_UNICODETEXT),
				TextDataFormat.Rtf => (Encoding.ASCII.GetBytes(value + '\0'), RegisterFormat(ShellClipboardFormat.CF_RTF)),
				TextDataFormat.Html => (MakeClipHtml(value), RegisterFormat(ShellClipboardFormat.CF_HTML)),
				TextDataFormat.CommaSeparatedValue => (Encoding.ASCII.GetBytes(value + '\0'), RegisterFormat(ShellClipboardFormat.CF_CSV)),
				_ => default,
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

		internal static string GetHtml(IntPtr ptr)
		{
			const string HdrRegEx = @"Version:\d\.\d\s+StartHTML:(\d+)\s+EndHTML:(\d+)\s+StartFragment:(\d+)\s+EndFragment:(\d+)\s+(?:StartSelection:(\d+)\s+EndSelection:(\d+)\s+)?";

			if (ptr == IntPtr.Zero) return null;

			// Find length of data by looking for a '\0' byte.
			var byteCount = 0;
			unsafe
			{
				for (byte* bp = (byte*)ptr.ToPointer(); byteCount < 4 * 1024 * 1024 && *bp != 0; byteCount++, bp++) ;
			}
			var bytes = ptr.ToArray<byte>(byteCount);
			// Get UTF8 encoded string
			var utf8String = Encoding.UTF8.GetString(bytes);
			// Find markers
			var match = Regex.Match(utf8String, HdrRegEx);
			if (!match.Success) throw new InvalidOperationException("HTML format header cannot be processed.");
			var startHtml = int.Parse(match.Groups[1].Value.TrimStart('0'));
			var endHtml = int.Parse(match.Groups[2].Value.TrimStart('0'));
			var startFrag = int.Parse(match.Groups[3].Value.TrimStart('0'));
			var endFrag = int.Parse(match.Groups[4].Value.TrimStart('0'));
			var startSel = int.Parse(match.Groups[5].Value.TrimStart('0'));
			var endSel = int.Parse(match.Groups[6].Value.TrimStart('0'));

			return Encoding.UTF8.GetString(bytes, startFrag, endFrag - startFrag);
		}

		internal static StringCollection ToSC(IEnumerable<string> e)
		{
			var sc = new StringCollection();
			if (e != null)
				sc.AddRange(e.ToArray());
			return sc;
		}

		private static void EnsureKnownIds()
		{
			if (knownIds is not null)
				return;
			var type = typeof(CLIPFORMAT);
			knownIds = type.GetFields(BindingFlags.Static | BindingFlags.Public).Where(f => f.FieldType == type && f.IsInitOnly).ToDictionary(f => (uint)f.GetValue(null), f => f.Name);
		}

		private static T GetComData<T>(IComDataObject cdo, uint fmt, Func<IntPtr, T> convert, T defValue = default)
		{
			T ret = defValue;
			var fc = new FORMATETC { cfFormat = (short)fmt, dwAspect = DVASPECT.DVASPECT_CONTENT, lindex = -1, tymed = TYMED.TYMED_HGLOBAL };
			try
			{
				cdo.GetData(ref fc, out var medium);
				if (medium.unionmember != default)
					ret = convert(medium.unionmember);
				ReleaseStgMedium(medium);
			}
			catch { }
			return ret;
		}

		private static byte[] MakeClipHtml(string value)
		{
			const string Header = "Version:0.9\r\nStartHTML:{0:0000000000}\r\nEndHTML:{1:0000000000}\r\nStartFragment:{2:0000000000}\r\nEndFragment:{3:0000000000}\r\nStartSelection:{4:0000000000}\r\nEndSelection:{5:0000000000}\r\n";
			const string htmlDocType = "<!DOCTYPE html>";
			const string htmlBodyStart = "<HTML><HEAD><meta charset=\"UTF-8\"><TITLE>Snippet</TITLE></HEAD><BODY>";
			const string htmlBodyEnd = "</BODY></HTML>";
			const string fragmentStart = "<!--StartFragment-->";
			const string fragmentEnd = "<!--EndFragment-->";

			var sb = new StringBuilder();
			if (value.IndexOf("<!DOCTYPE", StringComparison.OrdinalIgnoreCase) < 0)
				sb.Append(htmlDocType);
			if (value.IndexOf("<HTML>", StringComparison.OrdinalIgnoreCase) < 0)
				sb.Append(htmlBodyStart);

			var fragStartIdx = value.IndexOf(fragmentStart, StringComparison.OrdinalIgnoreCase);
			if (fragStartIdx < 0)
				sb.Append(fragmentStart);
			else
			{
				sb.Append(value.Substring(0, fragStartIdx + fragmentStart.Length));
				value = value.Remove(0, fragStartIdx + fragmentStart.Length);
			}
			fragStartIdx = Encoding.UTF8.GetByteCount(sb.ToString());

			var fragEndIdx = value.IndexOf(fragmentEnd, StringComparison.OrdinalIgnoreCase);
			if (fragEndIdx < 0)
			{
				sb.Append(value);
				fragEndIdx = Encoding.UTF8.GetByteCount(sb.ToString());
				sb.Append(fragmentEnd);
			}
			else
			{
				var preFrag = value.Substring(0, fragEndIdx);
				value = value.Remove(0, fragEndIdx);
				sb.Append(preFrag);
				fragEndIdx = Encoding.UTF8.GetByteCount(sb.ToString());
				sb.Append(value);
			}
			if (value.IndexOf("</HTML>", StringComparison.OrdinalIgnoreCase) < 0)
				sb.Append(htmlBodyEnd);

			if (HdrLen == 0)
				HdrLen = string.Format(Header, 0, 0, 0, 0, 0, 0).Length;

			var startHtml = HdrLen;
			var endHtml = HdrLen + Encoding.UTF8.GetByteCount(sb.ToString());
			var startFrag = HdrLen + fragStartIdx;
			var endFrag = HdrLen + fragEndIdx;
			var startSel = startFrag;
			var endSel = endFrag;
			sb.Insert(0, string.Format(Header, startHtml, endHtml, startFrag, endFrag, startSel, endSel));
			sb.Append('\0');

			return Encoding.UTF8.GetBytes(sb.ToString());
		}

		private static void RunAsSTAThread(ThreadStart threadStart)
		{
			var thread = new Thread(threadStart);
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			thread.Join();
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

		private class SafeMoveableHGlobalHandle : SafeHandle
		{
			private static readonly IMemoryMethods mm = Kernel32.MoveableHGlobalMemoryMethods.Instance;
			private SizeT sz;

			/// <summary>Initializes a new instance of the <see cref="SafeMoveableHGlobalHandle"/> class.</summary>
			/// <param name="handle">The handle.</param>
			/// <param name="size">The size of memory allocated to the handle, in bytes.</param>
			/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
			public SafeMoveableHGlobalHandle(IntPtr handle, SizeT size, bool ownsHandle = true) : base(IntPtr.Zero, ownsHandle)
			{
				SetHandle(handle);
				sz = size;
			}

			/// <summary>Initializes a new instance of the <see cref="SafeMoveableHGlobalHandle"/> class.</summary>
			/// <param name="size">The size of memory to allocate, in bytes.</param>
			/// <exception cref="System.ArgumentOutOfRangeException">size - The value of this argument must be non-negative</exception>
			public SafeMoveableHGlobalHandle(SizeT size) : base(IntPtr.Zero, true)
			{
				if (size == 0) return;
				RuntimeHelpers.PrepareConstrainedRegions();
				SetHandle(mm.AllocMem(sz = size));
			}

			/// <summary>
			/// Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native
			/// array equivalent.
			/// </summary>
			/// <param name="bytes">Array of unmanaged pointers</param>
			/// <returns>SafeMoveableHGlobalHandle object to an native (unmanaged) array of pointers</returns>
			public SafeMoveableHGlobalHandle(byte[] bytes) : this(bytes?.Length ?? 0)
			{
				if (sz == 0) return;
				CallLocked(p => Marshal.Copy(bytes, 0, p, sz));
			}

			/// <summary>Represents a NULL memory pointer.</summary>
			public static SafeMoveableHGlobalHandle Null { get; } = new SafeMoveableHGlobalHandle(IntPtr.Zero, 0, false);

			public override bool IsInvalid => handle == IntPtr.Zero;

			/// <summary>Gets or sets the size in bytes of the allocated memory block.</summary>
			/// <value>The size in bytes of the allocated memory block.</value>
			public SizeT Size
			{
				get => sz;
				set
				{
					if (value == 0)
					{
						ReleaseHandle();
					}
					else
					{
						RuntimeHelpers.PrepareConstrainedRegions();
						handle = IsInvalid ? mm.AllocMem(value) : mm.ReAllocMem(handle, value);
						sz = value;
					}
				}
			}

			/// <summary>
			/// Allocates from unmanaged memory to represent a structure with a variable length array at the end and marshal these structure
			/// elements. It is the callers responsibility to marshal what precedes the trailing array into the unmanaged memory. ONLY
			/// structures with attribute StructLayout of LayoutKind.Sequential are supported.
			/// </summary>
			/// <typeparam name="T">Type of the trailing array of structures</typeparam>
			/// <param name="values">Collection of structure objects</param>
			/// <param name="prefixBytes">Number of bytes preceding the trailing array of structures</param>
			/// <returns><see cref="SafeMoveableHGlobalHandle"/> object to an native (unmanaged) structure with a trail array of structures</returns>
			public static SafeMoveableHGlobalHandle CreateFromList<T>(IEnumerable<T> values, int prefixBytes = 0) =>
				new(InteropExtensions.MarshalToPtr(values, mm.AllocMem, out int s, prefixBytes, mm.LockMem, mm.UnlockMem), s);

			/// <summary>Allocates from unmanaged memory sufficient memory to hold an array of strings.</summary>
			/// <param name="values">The list of strings.</param>
			/// <param name="packing">The packing type for the strings.</param>
			/// <param name="charSet">The character set to use for the strings.</param>
			/// <param name="prefixBytes">Number of bytes preceding the trailing strings.</param>
			/// <returns>
			/// <see cref="SafeMoveableHGlobalHandle"/> object to an native (unmanaged) array of strings stored using the <paramref
			/// name="packing"/> model and the character set defined by <paramref name="charSet"/>.
			/// </returns>
			public static SafeMoveableHGlobalHandle CreateFromStringList(IEnumerable<string> values, StringListPackMethod packing = StringListPackMethod.Concatenated, CharSet charSet = CharSet.Auto, int prefixBytes = 0) =>
				new(InteropExtensions.MarshalToPtr(values, packing, mm.AllocMem, out int s, charSet, prefixBytes, mm.LockMem, mm.UnlockMem), s);

			/// <summary>Allocates from unmanaged memory sufficient memory to hold an object of type T.</summary>
			/// <typeparam name="T">Native type</typeparam>
			/// <param name="value">The value.</param>
			/// <returns><see cref="SafeMoveableHGlobalHandle"/> object to an native (unmanaged) memory block the size of T.</returns>
			public static SafeMoveableHGlobalHandle CreateFromStructure<T>(in T value = default) =>
				new(InteropExtensions.MarshalToPtr(value, mm.AllocMem, out int s, 0, mm.LockMem, mm.UnlockMem), s);

			/// <summary>Converts an <see cref="IntPtr"/> to a <see cref="SafeMoveableHGlobalHandle"/> where it owns the reference.</summary>
			/// <param name="ptr">The <see cref="IntPtr"/>.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SafeMoveableHGlobalHandle(IntPtr ptr) => new(ptr, 0, true);

			protected void CallLocked(Action<IntPtr> action)
			{
				try { action.Invoke(mm.LockMem(handle)); }
				finally { mm.UnlockMem(handle); }
			}

			protected override bool ReleaseHandle()
			{
				mm.FreeMem(handle);
				sz = 0;
				handle = IntPtr.Zero;
				return true;
			}
		}
	}
}