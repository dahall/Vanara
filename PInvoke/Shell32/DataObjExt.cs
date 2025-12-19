using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Vanara.PInvoke;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;

namespace Vanara.Extensions;

/// <summary>Extension methods for <see cref="IDataObject"/>.</summary>
public static partial class DataObjectExtensions
{
	private static readonly Lazy<TYMED> AllTymed = new(() => Enum.GetValues(typeof(TYMED)).Cast<TYMED>().Aggregate((a, b) => a | b));

	/// <summary>Enumerates the <see cref="FORMATETC"/> structures that define the formats and media supported by a given data object.</summary>
	/// <param name="dataObj">The data object.</param>
	/// <returns>A sequence of <see cref="FORMATETC"/> structures.</returns>
	public static IEnumerable<FORMATETC> EnumFormats(this IDataObject dataObj)
	{
		IEnumFORMATETC? e = null;
		try { e = dataObj.EnumFormatEtc(DATADIR.DATADIR_GET); e.Reset(); }
		catch { }
		if (e is null) yield break;

		FORMATETC[] etc = new FORMATETC[1];
		int[] f = [1];
		while (((HRESULT)e.Next(1, etc, f)).Succeeded && f[0] > 0)
			yield return etc[0];
	}

	/// <summary>Obtains data from a source data object.</summary>
	/// <param name="dataObj">The data object.</param>
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
	/// <returns>The object associated with the request. If no object can be determined, a <see cref="byte"/>[] is returned.</returns>
	/// <exception cref="InvalidOperationException">Unrecognized TYMED value.</exception>
	public static object? GetData(this IDataObject dataObj, string format, DVASPECT aspect = DVASPECT.DVASPECT_CONTENT, int index = -1) =>
		GetData(dataObj, RegisterClipboardFormat(format), aspect, index);

	/// <summary>Obtains data from a source data object.</summary>
	/// <param name="dataObj">The data object.</param>
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
	/// <description><see cref="IShellItemArray"/>
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
	/// <exception cref="InvalidOperationException">Unrecognized TYMED value.</exception>
	public static object? GetData(this IDataObject dataObj, uint formatId, DVASPECT aspect = DVASPECT.DVASPECT_CONTENT, int index = -1)
	{
		ClipCorrespondingTypeAttribute? attr = ShellClipboardFormat.clipFmtIds.Value.TryGetValue(formatId, out (string name, ClipCorrespondingTypeAttribute? attr) data) ? data.attr : null;
		TYMED tymed = attr?.Medium ?? AllTymed.Value;
		FORMATETC formatetc = new()
		{
			cfFormat = unchecked((short)(ushort)formatId),
			dwAspect = aspect,
			lindex = index,
			tymed = tymed
		};
		if (!dataObj.EnumFormats().Contains(formatetc, FORMATETCComparer.Default))
			throw new InvalidOperationException("The specified format is not available from the data object.");
		dataObj.GetData(ref formatetc, out var medium);

		// Handle TYMED values, passing through HGLOBAL
		bool userFree = medium.pUnkForRelease is null;
		if (medium.tymed != TYMED.TYMED_HGLOBAL)
			return medium.tymed switch
			{
				TYMED.TYMED_FILE => Marshal.PtrToStringBSTR(medium.unionmember),
				TYMED.TYMED_ISTREAM => Marshal.GetObjectForIUnknown(medium.unionmember) as IStream,
				TYMED.TYMED_ISTORAGE => Marshal.GetObjectForIUnknown(medium.unionmember) as IStorage,
				TYMED.TYMED_GDI when userFree => new SafeHBITMAP(medium.unionmember),
				TYMED.TYMED_GDI when !userFree => (HBITMAP)medium.unionmember,
				TYMED.TYMED_MFPICT when userFree => new SafeHMETAFILE(medium.unionmember),
				TYMED.TYMED_MFPICT when !userFree => (HMETAFILE)medium.unionmember,
				TYMED.TYMED_ENHMF when userFree => new SafeHENHMETAFILE(medium.unionmember),
				TYMED.TYMED_ENHMF when !userFree => (HENHMETAFILE)medium.unionmember,
				TYMED.TYMED_NULL => null,
				_ => throw new InvalidOperationException(),
			};

		// Handle list of shell items
		if (formatId == ShellClipboardFormat.Register(ShellClipboardFormat.CFSTR_SHELLIDLIST))
		{
			return SHCreateShellItemArrayFromDataObject(dataObj);
		}

		using SafeMoveableHGlobalHandle hmem = new(medium.unionmember, userFree);
		try
		{
			hmem.Lock();

			// Handle CF_HDROP since it can't indicate specialty
			if (CLIPFORMAT.CF_HDROP.Equals(formatId))
			{
				return new ClipboardHDROPFormatter().Read(hmem);
			}

			// If there's no hint, return bytes or ISerialized value
			if (attr is null)
			{
				return ClipboardSerializedFormatter.IsSerialized(hmem) ? new ClipboardSerializedFormatter().Read(hmem) : hmem.GetBytes();
			}

			// Use clipboard formatter if available
			if (attr.Formatter is not null)
			{
				return ((IClipboardFormatter)Activator.CreateInstance(attr.Formatter)!).Read(hmem);
			}

			CharSet charSet = GetCharSet(attr);
			return attr.TypeRef switch
			{
				// Handle strings
				Type t when t == typeof(string) => GetEncoding(attr).GetString(hmem.GetBytes()).TrimEnd('\0'),
				// Handle string[]
				Type t when t == typeof(string[]) => hmem.ToStringEnum(charSet).ToArray(),
				// Handle IStream on memory
				Type t when t == typeof(IStream) => hmem.CallLocked(p => { CreateStreamOnHGlobal(p, false, out var s).ThrowIfFailed(); return s; }),
				// Handle other defined types
				_ when attr.TypeRef is not null => hmem.CallLocked(p => p.Convert(hmem.Size, attr.TypeRef, charSet)),
				// Handle unknown types
				_ => hmem.GetBytes(),
			};
		}
		finally
		{
			hmem.Unlock();
		}
	}

	/// <summary>Obtains data from a source data object.</summary>
	/// <typeparam name="T">The type of the object being retrieved.</typeparam>
	/// <param name="dataObj">The data object.</param>
	/// <param name="format">Specifies the particular clipboard format of interest.</param>
	/// <param name="index">
	/// Part of the aspect when the data must be split across page boundaries. The most common value is -1, which identifies all of the
	/// data. For the aspects DVASPECT_THUMBNAIL and DVASPECT_ICON, lindex is ignored.
	/// </param>
	/// <param name="charSet">The character set to use for string types.</param>
	/// <returns>The object associated with the request. If no object can be determined, <c>default(T)</c> is returned.</returns>
	/// <exception cref="ArgumentException">This format does not support direct type access. - formatId</exception>
	public static T? GetData<T>(this IDataObject dataObj, string format, int index = -1, CharSet charSet = CharSet.Auto) =>
		GetData<T>(dataObj, RegisterClipboardFormat(format), index, charSet);

	/// <summary>Obtains data from a source data object.</summary>
	/// <typeparam name="T">The type of the object being retrieved.</typeparam>
	/// <param name="dataObj">The data object.</param>
	/// <param name="formatId">Specifies the particular clipboard format of interest.</param>
	/// <param name="index">
	/// Part of the aspect when the data must be split across page boundaries. The most common value is -1, which identifies all of the
	/// data. For the aspects DVASPECT_THUMBNAIL and DVASPECT_ICON, lindex is ignored.
	/// </param>
	/// <param name="charSet">The character set to use for string types.</param>
	/// <returns>The object associated with the request. If no object can be determined, <c>default(T)</c> is returned.</returns>
	/// <exception cref="ArgumentException">This format does not support direct type access. - formatId</exception>
	public static T? GetData<T>(this IDataObject dataObj, uint formatId, int index = -1, CharSet charSet = CharSet.Auto)
	{
		FORMATETC formatetc = new()
		{
			cfFormat = unchecked((short)(ushort)formatId),
			dwAspect = DVASPECT.DVASPECT_CONTENT,
			lindex = index,
			tymed = TYMED.TYMED_HGLOBAL
		};
		dataObj.GetData(ref formatetc, out var medium);
		if (medium.tymed != TYMED.TYMED_HGLOBAL)
			throw new ArgumentException("This format does not support direct type access.", nameof(formatId));
		if (medium.unionmember == default)
			return default;
		using SafeMoveableHGlobalHandle hmem = new(medium.unionmember, medium.pUnkForRelease is null);
		return hmem.ToType<T>(charSet == CharSet.Auto ? (StringHelper.GetCharSize(charSet) == 1 ? CharSet.Ansi : CharSet.Unicode) : charSet);
	}

	/// <summary>
	/// This is used when a group of files in CF_HDROP (FileDrop) format is being renamed as well as transferred. The data consists of an
	/// array that contains a new name for each file, in the same order that the files are listed in the accompanying CF_HDROP format.
	/// The format of the character array is the same as that used by CF_HDROP to list the transferred files.
	/// </summary>
	/// <returns>A list of strings containing a new name for each file.</returns>
	public static string[] GetFileNameMap(this IDataObject dataObj)
	{
		string[]? ret = null;
		if (dataObj.IsFormatAvailable(RegisterClipboardFormat(ShellClipboardFormat.CFSTR_FILENAMEMAPW)))
			ret = dataObj.GetData(ShellClipboardFormat.CFSTR_FILENAMEMAPW) as string[];
		else if (dataObj.IsFormatAvailable(RegisterClipboardFormat(ShellClipboardFormat.CFSTR_FILENAMEMAPA)))
			ret = dataObj.GetData(ShellClipboardFormat.CFSTR_FILENAMEMAPA) as string[];
		return ret ?? [];
	}

	/// <summary>Gets the text from the native Clipboard in the specified format.</summary>
	/// <param name="dataObj">The data object.</param>
	/// <param name="formatId">A clipboard format. For a description of the standard clipboard formats, see Standard Clipboard Formats.</param>
	/// <returns>The string value or <see langword="null"/> if the format is not available.</returns>
	public static string? GetText(this IDataObject dataObj, uint formatId) => GetData(dataObj, formatId)?.ToString();

	/// <summary>Gets the text from the native Clipboard in the specified format.</summary>
	/// <param name="dataObj">The data object.</param>
	/// <param name="format">A clipboard format. For a description of the standard clipboard formats, see Standard Clipboard Formats.</param>
	/// <returns>The string value or <see langword="null"/> if the format is not available.</returns>
	public static string? GetText(this IDataObject dataObj, string format) => GetData(dataObj, format)?.ToString();

	/// <summary>
	/// Determines whether the data object is capable of rendering the data described in the parameters. Objects attempting a paste or
	/// drop operation can call this method before calling GetData to get an indication of whether the operation may be successful.
	/// </summary>
	/// <param name="dataObj">The data object.</param>
	/// <param name="formatId">Specifies the particular clipboard format of interest.</param>
	/// <returns><see langword="true"/> if <paramref name="formatId"/> is available; otherwise, <see langword="false"/>.</returns>
	public static bool IsFormatAvailable(this IDataObject dataObj, uint formatId)
	{
		FORMATETC formatetc = new()
		{
			cfFormat = unchecked((short)(ushort)formatId),
			dwAspect = DVASPECT.DVASPECT_CONTENT,
			lindex = -1,
			tymed = AllTymed.Value
		};

		return dataObj.QueryGetData(ref formatetc) == HRESULT.S_OK;
	}

	/// <summary>Transfer a data stream to an object that contains a data source.</summary>
	/// <param name="dataObj">The data object.</param>
	/// <param name="format">Specifies the particular clipboard format of interest.</param>
	/// <param name="obj">The object to add.</param>
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
	public static void SetData(this IDataObject dataObj, string format, object obj, DVASPECT aspect = DVASPECT.DVASPECT_CONTENT, int index = -1) =>
		SetData(dataObj, RegisterClipboardFormat(format), obj, aspect, index);

	/// <summary>Transfer a data stream to an object that contains a data source.</summary>
	/// <param name="dataObj">The data object.</param>
	/// <param name="formatId">Specifies the particular clipboard format of interest.</param>
	/// <param name="obj">The object to add.</param>
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
	public static void SetData(this IDataObject dataObj, uint formatId, object obj, DVASPECT aspect = DVASPECT.DVASPECT_CONTENT, int index = -1)
	{
		ClipCorrespondingTypeAttribute? attr = ShellClipboardFormat.clipFmtIds.Value.TryGetValue(formatId, out (string name, ClipCorrespondingTypeAttribute? attr) data) ? data.attr : null;

		TYMED tymed = attr?.Medium ?? TYMED.TYMED_HGLOBAL;
		CharSet charSet = GetCharSet(attr);
		IntPtr mbr = attr?.Formatter is null ? default : ((IClipboardFormatter)Activator.CreateInstance(attr.Formatter)!).Write(obj);
		if (mbr == default)
		{
			switch (obj)
			{
				case null:
					tymed = TYMED.TYMED_NULL;
					break;

				case byte[] bytes:
					mbr = ClipboardBytesFormatter.Instance.Write(bytes);
					break;

				// TODO
				//case MemoryStream mstream:
				//	mbr = ClipboardBytesFormatter.Instance.Write(mstream.GetBuffer());
				//	break;

				// TODO
				//case Stream stream:
				//	ComStream cstream = new(stream);
				//	tymed = TYMED.TYMED_ISTREAM;
				//	mbr = Marshal.GetIUnknownForObject((IStream)cstream);
				//	break;

				case string str:
					//if (CLIPFORMAT.CF_TEXT.Equals(formatId))
					//	mbr = ClipboardBytesFormatter.Instance.Write(UnicodeToAnsiBytes(str));
					//else
					mbr = ClipboardBytesFormatter.Instance.Write(StringHelper.GetBytes(str, attr is null ? Encoding.Unicode : GetEncoding(attr), true));
					break;

				case IEnumerable<string> strlist:
					// Handle HDROP specifically since its formatter cannot be specified.
					if (CLIPFORMAT.CF_HDROP.Equals(formatId))
						mbr = ClipboardHDROPFormatter.Write(strlist, charSet == CharSet.Unicode || (charSet == CharSet.Auto && Marshal.SystemDefaultCharSize == 2));
					else
						mbr = strlist.MarshalToPtr(StringListPackMethod.Concatenated, MoveableHGlobalMemoryMethods.Instance.AllocMem, out _, charSet, 0,
							MoveableHGlobalMemoryMethods.Instance.LockMem, MoveableHGlobalMemoryMethods.Instance.UnlockMem);
					break;

				case IStream str:
					tymed = TYMED.TYMED_ISTREAM;
					mbr = Marshal.GetIUnknownForObject(str);
					break;

				case IStorage store:
					tymed = TYMED.TYMED_ISTORAGE;
					mbr = Marshal.GetIUnknownForObject(store);
					break;

				// TODO
				//case FileInfo fileInfo:
				//	tymed = TYMED.TYMED_FILE;
				//	mbr = Marshal.StringToBSTR(fileInfo.FullName);
				//	break;

				case System.Runtime.Serialization.ISerializable ser:
					mbr = new ClipboardSerializedFormatter().Write(ser);
					break;

				case SafeMoveableHGlobalHandle hg:
					mbr = hg.TakeOwnership();
					break;

				// TODO
				//case SafeAllocatedMemoryHandle h:
				//	mbr = new SafeMoveableHGlobalHandle(h).TakeOwnership();
				//	break;

				case HBITMAP:
				case SafeHBITMAP:
					tymed = TYMED.TYMED_GDI;
					mbr = ((IHandle)obj).DangerousGetHandle();
					break;

				case HMETAFILE:
				case SafeHMETAFILE:
					tymed = TYMED.TYMED_MFPICT;
					mbr = ((IHandle)obj).DangerousGetHandle();
					break;

				case HENHMETAFILE:
				case SafeHENHMETAFILE:
					tymed = TYMED.TYMED_ENHMF;
					mbr = ((IHandle)obj).DangerousGetHandle();
					break;
			}
		}
		FORMATETC formatetc = new()
		{
			cfFormat = unchecked((short)(ushort)formatId),
			dwAspect = aspect,
			lindex = index,
			tymed = tymed
		};
		STGMEDIUM medium = new() { tymed = tymed, unionmember = mbr };
		dataObj.SetData(ref formatetc, ref medium, true);
	}

	/// <summary>Transfer a data stream to an object that contains a data source.</summary>
	/// <typeparam name="T">The type of the object being passed.</typeparam>
	/// <param name="dataObj">The data object.</param>
	/// <param name="format">Specifies the particular clipboard format of interest.</param>
	/// <param name="obj">The object to add.</param>
	/// <param name="index">
	/// Part of the aspect when the data must be split across page boundaries. The most common value is -1, which identifies all of the
	/// data. For the aspects DVASPECT_THUMBNAIL and DVASPECT_ICON, lindex is ignored.
	/// </param>
	public static void SetData<T>(this IDataObject dataObj, string format, T obj, int index = -1) where T : struct =>
		SetData(dataObj, RegisterClipboardFormat(format), SafeMoveableHGlobalHandle.CreateFromStructure(obj), DVASPECT.DVASPECT_CONTENT, index);

	/// <summary>Transfer a data stream to an object that contains a data source.</summary>
	/// <typeparam name="T">The type of the object being passed.</typeparam>
	/// <param name="dataObj">The data object.</param>
	/// <param name="formatId">Specifies the particular clipboard format of interest.</param>
	/// <param name="obj">The object to add.</param>
	/// <param name="index">
	/// Part of the aspect when the data must be split across page boundaries. The most common value is -1, which identifies all of the
	/// data. For the aspects DVASPECT_THUMBNAIL and DVASPECT_ICON, lindex is ignored.
	/// </param>
	public static void SetData<T>(this IDataObject dataObj, uint formatId, T obj, int index = -1) where T : struct =>
		SetData(dataObj, formatId, SafeMoveableHGlobalHandle.CreateFromStructure(obj), DVASPECT.DVASPECT_CONTENT, index);

	/// <summary>Sets multiple text types to the data object.</summary>
	/// <param name="dataObj">The data object.</param>
	/// <param name="text">The Unicode Text value.</param>
	/// <param name="htmlText">The HTML text value. If <see langword="null"/>, this format will not be set.</param>
	/// <param name="rtfText">The Rich Text Format value. If <see langword="null"/>, this format will not be set.</param>
	public static void SetText(this IDataObject dataObj, string text, string? htmlText = null, string? rtfText = null)
	{
		if (text is not null) { dataObj.SetData(CLIPFORMAT.CF_UNICODETEXT, text); dataObj.SetData(CLIPFORMAT.CF_TEXT, StringHelper.GetBytes(text, true, CharSet.Ansi)); }
		if (htmlText is not null) dataObj.SetData(ShellClipboardFormat.CF_HTML, htmlText);
		if (rtfText is not null) dataObj.SetData(ShellClipboardFormat.CF_RTF, rtfText);
	}

	/// <summary>Sets a URL with optional title to a data object.</summary>
	/// <param name="dataObj">The data object.</param>
	/// <param name="url">The URL.</param>
	/// <param name="title">The title. This value can be <see langword="null"/>.</param>
	/// <exception cref="ArgumentNullException">url</exception>
	public static void SetUrl(this IDataObject dataObj, string url, string? title = null)
	{
		if (url is null) throw new ArgumentNullException(nameof(url));
		dataObj.SetData(CLIPFORMAT.CF_UNICODETEXT, url);
		dataObj.SetData(ShellClipboardFormat.CF_HTML, $"<a href=\"{System.Net.WebUtility.UrlEncode(url)}\">{System.Net.WebUtility.HtmlEncode(title ?? url)}</a>");
		dataObj.SetData(ShellClipboardFormat.CFSTR_INETURLA, url);
		dataObj.SetData(ShellClipboardFormat.CFSTR_INETURLW, url);
	}

	/// <summary>Obtains data from a source data object.</summary>
	/// <typeparam name="T">The type of the object being retrieved.</typeparam>
	/// <param name="dataObj">The data object.</param>
	/// <param name="format">Specifies the particular clipboard format of interest.</param>
	/// <param name="obj">The object associated with the request. If no object can be determined, <c>default(T)</c> is returned.</param>
	/// <param name="index">
	/// Part of the aspect when the data must be split across page boundaries. The most common value is -1, which identifies all of the
	/// data. For the aspects DVASPECT_THUMBNAIL and DVASPECT_ICON, lindex is ignored.
	/// </param>
	/// <returns><see langword="true"/> if data is available and retrieved; otherwise <see langword="false"/>.</returns>
	public static bool TryGetData<T>(this IDataObject dataObj, string format, out T? obj, int index = -1) =>
		TryGetData(dataObj, RegisterClipboardFormat(format), out obj, index);

	/// <summary>Obtains data from a source data object.</summary>
	/// <typeparam name="T">The type of the object being retrieved.</typeparam>
	/// <param name="dataObj">The data object.</param>
	/// <param name="formatId">Specifies the particular clipboard format of interest.</param>
	/// <param name="obj">The object associated with the request. If no object can be determined, <c>default(T)</c> is returned.</param>
	/// <param name="index">
	/// Part of the aspect when the data must be split across page boundaries. The most common value is -1, which identifies all of the
	/// data. For the aspects DVASPECT_THUMBNAIL and DVASPECT_ICON, lindex is ignored.
	/// </param>
	/// <returns><see langword="true"/> if data is available and retrieved; otherwise <see langword="false"/>.</returns>
	public static bool TryGetData<T>(this IDataObject dataObj, uint formatId, out T? obj, int index = -1)
	{
		if (IsFormatAvailable(dataObj, formatId))
			try
			{
				var charSet = GetCharSet(ShellClipboardFormat.clipFmtIds.Value.TryGetValue(formatId, out (string name, ClipCorrespondingTypeAttribute? attr) data) ? data.attr : null);
				obj = GetData<T>(dataObj, formatId, index, charSet);
				return true;
			}
			catch { }
		obj = default;
		return false;
	}
}