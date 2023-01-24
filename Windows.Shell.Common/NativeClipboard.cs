using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
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
	/// Static class with methods to interact with the Clipboard. This implementation relies exclusively on COM clipboard methods and does not use those from USER32.
	/// </summary>
	/// <example>
	/// Below are two examples of a direct and indirect way to manipulate the clipboard.
	/// <code title="Using the NativeClipboard class to set single items.">// Set/get simple text
	/// NativeClipboard.SetText(txt, Vanara.Windows.Shell.TextDataFormat.UnicodeText);
	/// string getText = NativeClipboard.GetText(Vanara.Windows.Shell.TextDataFormat.UnicodeText);
	///
	/// // Set/get format as text
	/// NativeClipboard.SetData(Shell32.ShellClipboardFormat.CFSTR_FILENAMEW, @"C:\file1.txt");
	/// string getFile = (string)NativeClipboard.GetData(Shell32.ShellClipboardFormat.CFSTR_FILENAMEW);
	///
	/// // Set/get text, html and rtf formats
	/// NativeClipboard.SetText("Test", htmlFragment, rtfText); // sets text, html and rtf formats
	/// string html = NativeClipboard.GetText(Vanara.Windows.Shell.TextDataFormat.Html);
	///
	/// // Set/get text, url and html formats for a url
	/// NativeClipboard.SetUrl("https://microsoft.com", "Microsoft Home"); // sets text, url and html formats
	/// string url = (string)NativeClipboard.GetData(Shell32.ShellClipboardFormat.CFSTR_INETURLW);
	///
	/// // Set/get string arrays
	/// NativeClipboard.SetData(CLIPFORMAT.CF_HDROP, new[] { @"C:\file1.txt", @"C:\file2.txt" });
	/// string[] getFiles = (string[])NativeClipboard.GetData(CLIPFORMAT.CF_HDROP);
	///
	/// // Set/get structures
	/// NativeClipboard.SetData("MyRect", new RECT(1, 2, 3, 4));
	/// var rect = NativeClipboard.GetData&lt;RECT&gt;("MyRect");
	///
	/// // Set/get shell items
	/// NativeClipboard.SetShellItems(new[] { @"C:\file1.txt", @"C:\file2.txt" }.Select(ShellItem.Open));
	/// ShellItemArray getArray = NativeClipboard.GetShellItemArray();</code>
	/// <code title="Indirect manipulation">// This model let's you place multiple formats at once on the clipboard
	/// IDataObject ido = NativeClipboard.CreateEmptyDataObject();
	/// ido.SetData(CLIPFORMAT.CF_UNICODETEXT, txt);
	/// ido.SetData(Shell32.ShellClipboardFormat.CF_HTML, htmlFragment);
	/// ido.SetData("MyRectFormat", new RECT(1, 2, 3, 4));
	/// NativeClipboard.SetDataObject(ido);</code></example>
	/// <seealso cref="System.IDisposable" />
	public static class NativeClipboard
	{
		private const int stdRetryCnt = 5;
		private const int stdRetryDelay = 100;
		private static readonly object objectLock = new();
		private static ListenerWindow listener;
		[ThreadStatic]
		private static bool oleInit = false;

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

		/// <summary>Gets or sets a <see cref="IComDataObject"/> instance from the Windows Clipboard.</summary>
		/// <value>A <see cref="IComDataObject"/> instance.</value>
		static IComDataObject ReadOnlyDataObject
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
				throw hr.GetException();
			}
		}

		static IComDataObject WritableDataObj
		{
			get
			{
				SHCreateDataObject(ppv: out var writableDataObj).ThrowIfFailed();
				return writableDataObj;
			}
			set
			{
				Init();
				TryMultThenThrowIfFailed(OleSetClipboard, value);
				Marshal.ReleaseComObject(value);
				Flush();
			}
		}

		/// <summary>Clears the clipboard of any data or formatting.</summary>
		public static void Clear() => WritableDataObj = null;

		/// <summary>Creates an empty, writable data object.</summary>
		/// <value>The data object.</value>
		public static IComDataObject CreateEmptyDataObject() => WritableDataObj;

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
		public static IEnumerable<uint> EnumAvailableFormats() => ReadOnlyDataObject.EnumFormats().Select(f => unchecked((uint)f.cfFormat));

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
		/// <returns>
		/// <para>The object associated with the request. If no object can be determined, a <see cref="byte"/>[] is returned.</para>
		/// <para>Conversion for different clipboard formats is as follows:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Format</term>
		/// <term>Return Type</term>
		/// </listheader>
		/// <item>
		/// <description><see cref="CLIPFORMAT.CF_HDROP"/>, <see cref="ShellClipboardFormat.CFSTR_FILENAMEMAPA"/>, <see cref="ShellClipboardFormat.CFSTR_FILENAMEMAPW"/></description>
		/// <description><see cref="string"/>[]</description>
		/// </item>
		/// <item>
		/// <description><see cref="CLIPFORMAT.CF_BITMAP"/></description>
		/// <description><see cref="HBITMAP"/></description>
		/// </item>
		/// <item>
		/// <description><see cref="CLIPFORMAT.CF_LOCALE"/></description>
		/// <description><see cref="LCID"/></description>
		/// </item>
		/// <item>
		/// <description>
		/// <see cref="CLIPFORMAT.CF_OEMTEXT"/>, <see cref="CLIPFORMAT.CF_TEXT"/>, <see cref="CLIPFORMAT.CF_UNICODETEXT"/>, <see
		/// cref="ShellClipboardFormat.CF_CSV"/>, <see cref="ShellClipboardFormat.CF_HTML"/>, <see cref="ShellClipboardFormat.CF_RTF"/>, <see
		/// cref="ShellClipboardFormat.CF_RTFNOOBJS"/>, <see cref="ShellClipboardFormat.CFSTR_FILENAMEA"/>, <see
		/// cref="ShellClipboardFormat.CFSTR_FILENAMEW"/>, <see cref="ShellClipboardFormat.CFSTR_INETURLA"/>, <see
		/// cref="ShellClipboardFormat.CFSTR_INETURLW"/>, <see cref="ShellClipboardFormat.CFSTR_INVOKECOMMAND_DROPPARAM"/>, <see
		/// cref="ShellClipboardFormat.CFSTR_MOUNTEDVOLUME"/>, <see cref="ShellClipboardFormat.CFSTR_PRINTERGROUP"/>, <see cref="ShellClipboardFormat.CFSTR_SHELLURL"/>
		/// </description>
		/// <description><see cref="string"/></description>
		/// </item>
		/// <item>
		/// <description><see cref="ShellClipboardFormat.CFSTR_DROPDESCRIPTION"/></description>
		/// <description><see cref="DROPDESCRIPTION"/></description>
		/// </item>
		/// <item>
		/// <description><see cref="ShellClipboardFormat.CFSTR_FILE_ATTRIBUTES_ARRAY"/></description>
		/// <description><see cref="FILE_ATTRIBUTES_ARRAY"/></description>
		/// </item>
		/// <item>
		/// <description><see cref="ShellClipboardFormat.CFSTR_FILECONTENTS"/></description>
		/// <description><see cref="IStream"/></description>
		/// </item>
		/// <item>
		/// <description><see cref="ShellClipboardFormat.CFSTR_FILEDESCRIPTORA"/>, <see cref="ShellClipboardFormat.CFSTR_FILEDESCRIPTORW"/></description>
		/// <description><see cref="FILEGROUPDESCRIPTOR"/></description>
		/// </item>
		/// <item>
		/// <description><see cref="ShellClipboardFormat.CFSTR_INDRAGLOOP"/></description>
		/// <description><see cref="BOOL"/></description>
		/// </item>
		/// <item>
		/// <description>
		/// <see cref="ShellClipboardFormat.CFSTR_LOGICALPERFORMEDDROPEFFECT"/>, <see cref="ShellClipboardFormat.CFSTR_PASTESUCCEEDED"/>,
		/// <see cref="ShellClipboardFormat.CFSTR_PERFORMEDDROPEFFECT"/>, <see cref="ShellClipboardFormat.CFSTR_PREFERREDDROPEFFECT"/>
		/// </description>
		/// <description><see cref="DROPEFFECT"/></description>
		/// </item>
		/// <item>
		/// <description><see cref="ShellClipboardFormat.CFSTR_NETRESOURCES"/></description>
		/// <description><see cref="NRESARRAY"/></description>
		/// </item>
		/// <item>
		/// <description><see cref="ShellClipboardFormat.CFSTR_SHELLDROPHANDLER"/>, <see cref="ShellClipboardFormat.CFSTR_TARGETCLSID"/></description>
		/// <description><see cref="Guid"/></description>
		/// </item>
		/// <item>
		/// <description><see cref="ShellClipboardFormat.CFSTR_SHELLIDLIST"/></description>
		/// <description><see cref="CIDA"/>
		/// <para>
		/// <note type="note">It is prefered to use the <see cref="SHCreateShellItemArrayFromDataObject(IDataObject)"/> method to get a list
		/// of shell items from an <see cref="IDataObject"/>.</note>
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description><see cref="ShellClipboardFormat.CFSTR_SHELLIDLISTOFFSET"/></description>
		/// <description><see cref="POINT"/>[]</description>
		/// </item>
		/// <item>
		/// <description><see cref="ShellClipboardFormat.CFSTR_UNTRUSTEDDRAGDROP"/>, <see cref="ShellClipboardFormat.CFSTR_ZONEIDENTIFIER"/></description>
		/// <description><see cref="uint"/></description>
		/// </item>
		/// </list>
		/// </returns>
		/// <exception cref="System.InvalidOperationException">Unrecognized TYMED value.</exception>
		public static object GetData(uint formatId, DVASPECT aspect = DVASPECT.DVASPECT_CONTENT, int index = -1) =>
			ReadOnlyDataObject.GetData(formatId, aspect, index);

		/// <summary>Obtains data from the clipboard.</summary>
		/// <param name="format">Specifies the particular clipboard format of interest.</param>
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
		/// <returns>
		/// The object associated with the request. If no object can be determined, a <see cref="byte"/>[] is returned. See the return
		/// section of <see cref="NativeClipboard.GetData(uint, DVASPECT, int)"/> for more details.
		/// </returns>
		/// <exception cref="System.InvalidOperationException">Unrecognized TYMED value.</exception>
		public static object GetData(string format, DVASPECT aspect = DVASPECT.DVASPECT_CONTENT, int index = -1) =>
			ReadOnlyDataObject.GetData(format, aspect, index);

		/// <summary>Obtains data from the clipboard.</summary>
		/// <typeparam name="T">The type of the object being retrieved.</typeparam>
		/// <param name="formatId">Specifies the particular clipboard format of interest.</param>
		/// <param name="index">
		/// Part of the aspect when the data must be split across page boundaries. The most common value is -1, which identifies all of the
		/// data. For the aspects DVASPECT_THUMBNAIL and DVASPECT_ICON, lindex is ignored.
		/// </param>
		/// <returns>The object associated with the request. If no object can be determined, <c>default(T)</c> is returned.</returns>
		public static T GetData<T>(uint formatId, int index = -1) => ReadOnlyDataObject.GetData<T>(formatId, index);

		/// <summary>Obtains data from the clipboard.</summary>
		/// <typeparam name="T">The type of the object being retrieved.</typeparam>
		/// <param name="format">Specifies the particular clipboard format of interest.</param>
		/// <param name="index">
		/// Part of the aspect when the data must be split across page boundaries. The most common value is -1, which identifies all of the
		/// data. For the aspects DVASPECT_THUMBNAIL and DVASPECT_ICON, lindex is ignored.
		/// </param>
		/// <returns>The object associated with the request. If no object can be determined, <c>default(T)</c> is returned.</returns>
		public static T GetData<T>(string format, int index = -1) => ReadOnlyDataObject.GetData<T>(format, index);

		/// <summary>
		/// This is used when a group of files in CF_HDROP (FileDrop) format is being renamed as well as transferred. The data consists of an
		/// array that contains a new name for each file, in the same order that the files are listed in the accompanying CF_HDROP format.
		/// The format of the character array is the same as that used by CF_HDROP to list the transferred files.
		/// </summary>
		/// <returns>A list of strings containing a new name for each file.</returns>
		public static string[] GetFileNameMap()
		{
			if (IsFormatAvailable(ShellClipboardFormat.CFSTR_FILENAMEMAPW))
				return ReadOnlyDataObject.GetData(ShellClipboardFormat.CFSTR_FILENAMEMAPW) as string[];
			else if (IsFormatAvailable(ShellClipboardFormat.CFSTR_FILENAMEMAPA))
				return ReadOnlyDataObject.GetData(ShellClipboardFormat.CFSTR_FILENAMEMAPA) as string[];
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

		/// <summary>Gets the shell item array associated with the data object, if possible.</summary>
		/// <returns>The <see cref="ShellItemArray"/> associated with the data object, if set. Otherwise, <see langword="null"/>.</returns>
		public static ShellItemArray GetShellItemArray() => IsFormatAvailable(ShellClipboardFormat.CFSTR_SHELLIDLIST) ? ShellItemArray.FromDataObject(ReadOnlyDataObject) : null;

		/// <summary>Gets the text from the native Clipboard in the specified format.</summary>
		/// <param name="formatId">A clipboard format. For a description of the standard clipboard formats, see Standard Clipboard Formats.</param>
		/// <returns>The string value or <see langword="null"/> if the format is not available.</returns>
		public static string GetText(TextDataFormat formatId = TextDataFormat.UnicodeText) => GetData(Txt2Id(formatId)) as string;

		/// <summary>Determines whether the data object pointer previously placed on the clipboard is still on the clipboard.</summary>
		/// <param name="dataObject">
		/// The IDataObject interface on the data object containing clipboard data of interest, which the caller previously placed on the clipboard.
		/// </param>
		/// <returns><see langword="true"/> on success; otherwise, <see langword="false"/>.</returns>
		public static bool IsCurrentDataObject(IComDataObject dataObject) => OleIsCurrentClipboard(dataObject) == HRESULT.S_OK;

		/// <summary>Determines whether the clipboard contains data in the specified format.</summary>
		/// <param name="id">A standard or registered clipboard format.</param>
		/// <returns>If the clipboard format is available, the return value is <see langword="true"/>; otherwise <see langword="false"/>.</returns>
		public static bool IsFormatAvailable(uint id) => ReadOnlyDataObject.IsFormatAvailable(id);

		/// <summary>Determines whether the clipboard contains data in the specified format.</summary>
		/// <param name="id">A clipboard format string.</param>
		/// <returns>If the clipboard format is available, the return value is <see langword="true"/>; otherwise <see langword="false"/>.</returns>
		public static bool IsFormatAvailable(string id) => IsClipboardFormatAvailable(RegisterFormat(id));

		// EnumAvailableFormats().Contains(id);
		/// <summary>Registers a new clipboard format. This format can then be used as a valid clipboard format.</summary>
		/// <param name="format">The name of the new format.</param>
		/// <returns>The registered clipboard format identifier.</returns>
		/// <exception cref="System.ArgumentNullException">format</exception>
		/// <remarks>
		/// If a registered format with the specified name already exists, a new format is not registered and the return value identifies the
		/// existing format. This enables more than one application to copy and paste data using the same registered clipboard format. Note
		/// that the format name comparison is case-insensitive.
		/// </remarks>
		public static uint RegisterFormat(string format) => ShellClipboardFormat.Register(format);

		/// <summary>Places data on the clipboard in a specified clipboard format.</summary>
		/// <param name="formatId">The clipboard format. This parameter can be a registered format or any of the standard clipboard formats.</param>
		/// <param name="data">The binary data in the specified format.</param>
		/// <exception cref="System.ArgumentNullException">data</exception>
		public static void SetBinaryData(uint formatId, byte[] data) => Setter(i => i.SetData(formatId, data));

		/// <summary>Places data on the clipboard in a specified clipboard format.</summary>
		/// <param name="formatId">The clipboard format. This parameter can be a registered format or any of the standard clipboard formats.</param>
		/// <param name="data">The data in the format dictated by <paramref name="formatId"/>.</param>
		/// <param name="index">
		/// Part of the aspect when the data must be split across page boundaries. The most common value is -1, which identifies all of the
		/// data. For the aspects DVASPECT_THUMBNAIL and DVASPECT_ICON, lindex is ignored.
		/// </param>
		/// <param name="aspect">
		/// Indicates how much detail should be contained in the rendering. This parameter should be one of the DVASPECT enumeration values.
		/// A single clipboard format can support multiple aspects or views of the object. Most data and presentation transfer and caching
		/// methods pass aspect information. For example, a caller might request an object's iconic picture, using the metafile clipboard
		/// format to retrieve it. Note that only one DVASPECT value can be used in dwAspect. That is, dwAspect cannot be the result of a
		/// Boolean OR operation on several DVASPECT values.
		/// </param>
		public static void SetData(uint formatId, object data, int index = -1, DVASPECT aspect = DVASPECT.DVASPECT_CONTENT) => Setter(i => i.SetData(formatId, data, aspect, index));

		/// <summary>Places data on the clipboard in a specified clipboard format.</summary>
		/// <param name="format">The clipboard format.</param>
		/// <param name="data">The data in the format dictated by <paramref name="format"/>.</param>
		/// <param name="index">
		/// Part of the aspect when the data must be split across page boundaries. The most common value is -1, which identifies all of the
		/// data. For the aspects DVASPECT_THUMBNAIL and DVASPECT_ICON, lindex is ignored.
		/// </param>
		/// <param name="aspect">
		/// Indicates how much detail should be contained in the rendering. This parameter should be one of the DVASPECT enumeration values.
		/// A single clipboard format can support multiple aspects or views of the object. Most data and presentation transfer and caching
		/// methods pass aspect information. For example, a caller might request an object's iconic picture, using the metafile clipboard
		/// format to retrieve it. Note that only one DVASPECT value can be used in dwAspect. That is, dwAspect cannot be the result of a
		/// Boolean OR operation on several DVASPECT values.
		/// </param>
		public static void SetData(string format, object data, int index = -1, DVASPECT aspect = DVASPECT.DVASPECT_CONTENT) => SetData(RegisterFormat(format), data, index, aspect);

		/// <summary>Places data on the clipboard in a specified clipboard format.</summary>
		/// <param name="formatId">The clipboard format. This parameter can be a registered format or any of the standard clipboard formats.</param>
		/// <param name="data">The data in the format dictated by <paramref name="formatId"/>.</param>
		public static void SetData<T>(uint formatId, T data) where T : struct => Setter(i => i.SetData(formatId, data));

		/// <summary>Places data on the clipboard in a specified clipboard format.</summary>
		/// <param name="format">The clipboard format.</param>
		/// <param name="data">The data in the format dictated by <paramref name="format"/>.</param>
		public static void SetData<T>(string format, T data) where T : struct => SetData(RegisterFormat(format), data);

		/// <summary>Places data on the clipboard in a specified clipboard format.</summary>
		/// <param name="formatId">The clipboard format. This parameter can be a registered format or any of the standard clipboard formats.</param>
		/// <param name="values">The data in the format dictated by <paramref name="formatId"/>.</param>
		public static void SetData<T>(uint formatId, IEnumerable<T> values) where T : struct
		{
			var pMem = SafeMoveableHGlobalHandle.CreateFromList(values);
			Win32Error.ThrowLastErrorIfInvalid(pMem);
			Setter(i => i.SetData(formatId, pMem));
		}

		/// <summary>Places data on the clipboard in a specified clipboard format.</summary>
		/// <param name="format">The clipboard format.</param>
		/// <param name="values">The data in the format dictated by <paramref name="format"/>.</param>
		public static void SetData<T>(string format, IEnumerable<T> values) where T : struct => SetData(RegisterFormat(format), values);

		/// <summary>Places data on the clipboard in a specified clipboard format.</summary>
		/// <param name="formatId">The clipboard format. This parameter can be a registered format or any of the standard clipboard formats.</param>
		/// <param name="values">The list of strings.</param>
		/// <param name="packing">The packing type for the strings.</param>
		/// <param name="charSet">The character set to use for the strings.</param>
		public static void SetData(uint formatId, IEnumerable<string> values, StringListPackMethod packing = StringListPackMethod.Concatenated, CharSet charSet = CharSet.Auto)
		{
			var pMem = SafeMoveableHGlobalHandle.CreateFromStringList(values, packing, charSet);
			Win32Error.ThrowLastErrorIfInvalid(pMem);
			Setter(i => i.SetData(formatId, pMem));
		}

		/// <summary>Places data on the clipboard in a specified clipboard format.</summary>
		/// <param name="format">The clipboard format.</param>
		/// <param name="values">The data in the format dictated by <paramref name="format"/>.</param>
		/// <param name="packing">The packing type for the strings.</param>
		/// <param name="charSet">The character set to use for the strings.</param>
		public static void SetData(string format, IEnumerable<string> values, StringListPackMethod packing = StringListPackMethod.Concatenated, CharSet charSet = CharSet.Auto) =>
			SetData(RegisterFormat(format), values, packing, charSet);

		/// <summary>
		/// Places a specific data object onto the clipboard. This makes the data object accessible to the OleGetClipboard function.
		/// </summary>
		/// <param name="dataObj">
		/// The IDataObject interface on the data object from which the data to be placed on the clipboard can be obtained.
		/// </param>
		public static void SetDataObject(IComDataObject dataObj) => WritableDataObj = dataObj ?? throw new ArgumentNullException(nameof(dataObj));

		/// <summary>Puts a list of shell items onto the clipboard.</summary>
		/// <param name="shellItems">The sequence of shell items. The PIDL of each shell item must be absolute.</param>
		public static void SetShellItems(IEnumerable<ShellItem> shellItems) => WritableDataObj = (shellItems is ShellItemArray shia ? shia : new ShellItemArray(shellItems)).ToDataObject();

		/// <summary>Puts a list of shell items onto the clipboard.</summary>
		/// <param name="parent">The parent folder instance.</param>
		/// <param name="relativeShellItems">The sequence of shell items relative to <paramref name="parent"/>.</param>
		public static void SetShellItems(ShellFolder parent, IEnumerable<ShellItem> relativeShellItems)
		{
			if (parent is null) throw new ArgumentNullException(nameof(parent));
			if (relativeShellItems is null) throw new ArgumentNullException(nameof(relativeShellItems));
			SHCreateDataObject(parent.PIDL, relativeShellItems.Select(i => i.PIDL), default, out var dataObj).ThrowIfFailed();
			WritableDataObj = dataObj;
		}

		/// <summary>Sets multiple text types to the Clipboard.</summary>
		/// <param name="text">The Unicode Text value.</param>
		/// <param name="htmlText">The HTML text value. If <see langword="null"/>, this format will not be set.</param>
		/// <param name="rtfText">The Rich Text Format value. If <see langword="null"/>, this format will not be set.</param>
		public static void SetText(string text, string htmlText = null, string rtfText = null) => Setter(ido =>
		{
			if (text is not null) ido.SetData(CLIPFORMAT.CF_UNICODETEXT, text);
			if (htmlText is not null) ido.SetData(ShellClipboardFormat.CF_HTML, htmlText);
			if (rtfText is not null) ido.SetData(ShellClipboardFormat.CF_RTF, rtfText);
		});

		/// <summary>Sets a specific text type to the Clipboard.</summary>
		/// <param name="value">The text value.</param>
		/// <param name="format">The clipboard text format to set.</param>
		public static void SetText(string value, TextDataFormat format) => Setter(i => i.SetData(Txt2Id(format), value));

		/// <summary>Sets a URL with optional title to the clipboard.</summary>
		/// <param name="url">The URL.</param>
		/// <param name="title">The title. This value can be <see langword="null"/>.</param>
		/// <exception cref="ArgumentNullException">url</exception>
		public static void SetUrl(string url, string title = null) => Setter(i => i.SetUrl(url, title));

		/// <summary>Obtains data from a source data object.</summary>
		/// <typeparam name="T">The type of the object being retrieved.</typeparam>
		/// <param name="formatId">Specifies the particular clipboard format of interest.</param>
		/// <param name="obj">The object associated with the request. If no object can be determined, <c>default(T)</c> is returned.</param>
		/// <param name="index">
		/// Part of the aspect when the data must be split across page boundaries. The most common value is -1, which identifies all of the
		/// data. For the aspects DVASPECT_THUMBNAIL and DVASPECT_ICON, lindex is ignored.
		/// </param>
		/// <returns><see langword="true"/> if data is available and retrieved; otherwise <see langword="false"/>.</returns>
		public static bool TryGetData<T>(uint formatId, out T obj, int index = -1) => ReadOnlyDataObject.TryGetData(formatId, out obj, index);

		private static void Init() { if (!oleInit) { oleInit = CoInitialize().Succeeded; } }

		private static void Setter(Action<IComDataObject> action)
		{
			var ido = WritableDataObj;
			action(ido);
			WritableDataObj = ido;
		}

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
			throw hr.GetException();
		}

		private static bool TryMultThenThrowIfFailed(Func<IComDataObject, HRESULT> func, IComDataObject o, int n = stdRetryCnt)
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
			throw hr.GetException();
		}

		private static uint Txt2Id(TextDataFormat tf) => tf switch
		{
			TextDataFormat.Text => CLIPFORMAT.CF_TEXT,
			TextDataFormat.UnicodeText => CLIPFORMAT.CF_UNICODETEXT,
			TextDataFormat.Rtf => ShellClipboardFormat.Register(ShellClipboardFormat.CF_RTF),
			TextDataFormat.Html => ShellClipboardFormat.Register(ShellClipboardFormat.CF_HTML),
			TextDataFormat.CommaSeparatedValue => ShellClipboardFormat.Register(ShellClipboardFormat.CF_CSV),
			_ => throw new ArgumentOutOfRangeException(nameof(tf)),
		};

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