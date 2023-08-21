using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;
using IComDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;

namespace Vanara.Windows.Shell;

/// <summary>Shell extended <see cref="DataObject"/>.</summary>
public class ShellDataObject : DataObject
{
	/// <summary>Initializes a new instance of the <see cref="ShellDataObject"/> class.</summary>
	public ShellDataObject() : base()
	{
	}

	/// <summary>Initializes a new instance of the <see cref="ShellDataObject"/> class and adds the specified object to it.</summary>
	/// <param name="data">The data to store.</param>
	public ShellDataObject(object data) : base(data)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="ShellDataObject"/> class and adds the specified object in the specified format.
	/// </summary>
	/// <param name="format">The format of the specified data. See <see cref="T:System.Windows.Forms.DataFormats"/> for predefined formats.</param>
	/// <param name="data">The data to store.</param>
	public ShellDataObject(string format, object data) : base() => SetData(format, data);

	/// <summary>Initializes a new instance of the <see cref="ShellDataObject"/> class.</summary>
	/// <param name="items">A list of ShellItem instances.</param>
	public ShellDataObject(IEnumerable<ShellItem> items) : base((items as ShellItemArray ?? new ShellItemArray(items)).ToDataObject())
	{
	}

	/// <summary>
	/// The locale associated with text in the clipboard. When you close the clipboard, if it contains CF_TEXT data but no CF_LOCALE
	/// data, the system automatically sets the CF_LOCALE format to the current input language. You can use the CF_LOCALE format to
	/// associate a different locale with the clipboard text.
	/// <para>
	/// An application that pastes text from the clipboard can retrieve this format to determine which character set was used to generate
	/// the text.
	/// </para>
	/// <para>
	/// Note that the clipboard does not support plain text in multiple character sets. To achieve this, use a formatted text data type
	/// such as RTF instead.
	/// </para>
	/// <para>
	/// The system uses the code page associated with CF_LOCALE to implicitly convert from CF_TEXT to CF_UNICODETEXT. Therefore, the
	/// correct code page table is used for the conversion.
	/// </para>
	/// </summary>
	public System.Globalization.CultureInfo Culture
	{
		get => base.GetDataPresent(DataFormats.Locale) ? new((int)base.GetData(DataFormats.Locale, false)) : System.Globalization.CultureInfo.CurrentCulture;
		set => base.SetData(DataFormats.Locale, false, value.LCID);
	}

	/// <summary>This format identifier is used by a data object to indicate whether it is in a drag-and-drop loop.</summary>
	/// <remarks>
	/// Some drop targets might call IDataObject::GetData and attempt to extract data while the object is still within the drag-and-drop
	/// loop. Fully rendering the object for each such occurrence might cause the drag cursor to stall. If the data object supports
	/// CFSTR_INDRAGLOOP, the target can instead use that format to check the status of the drag-and-drop loop and avoid memory intensive
	/// rendering of the object until it is actually dropped. The formats that are memory intensive to render should still be included in
	/// the FORMATETC enumerator and in calls to IDataObject::QueryGetData. If the data object does not set CFSTR_INDRAGLOOP, it should
	/// act as if the value is set to zero.
	/// </remarks>
	/// <value><see langword="true"/> if the data object is within a drag-and-drop loop; otherwise, <see langword="false"/>.</value>
	public bool InDragLoop
	{
		get => base.GetDataPresent(ShellClipboardFormat.CFSTR_INDRAGLOOP) && (int)base.GetData(ShellClipboardFormat.CFSTR_INDRAGLOOP, false) != 0;
		set => base.SetData(ShellClipboardFormat.CFSTR_INDRAGLOOP, false, value ? 1 : 0);
	}

	/// <summary>
	/// <para>
	/// This value is used by a drop source to specify whether its preferred method of data transfer is move or copy. A drop target
	/// requests this format by calling the data object's IDataObject::GetData method. This value is set to <see
	/// cref="DragDropEffects.Move"/> if a move operation is preferred or <see cref="DragDropEffects.Copy"/> if a copy operation is preferred.
	/// </para>
	/// <para>
	/// This feature is used when a source can support either a move or copy operation. It uses the CFSTR_PREFERREDDROPEFFECT format to
	/// communicate its preference to the target. Because the target is not obligated to honor the request, the target must call the
	/// source's IDataObject::SetData method with a CFSTR_PERFORMEDDROPEFFECT format to tell the data object which operation was actually performed.
	/// </para>
	/// <para>
	/// With a delete-on-paste operation, the CFSTR_PREFERREDDROPFORMAT format is used to tell the target whether the source did a cut or
	/// copy. With a drag-and-drop operation, you can use CFSTR_PREFERREDDROPFORMAT to specify the Shell's action. If this format is not
	/// present, the Shell performs a default action, based on context. For instance, if a user drags a file from one volume and drops it
	/// on another volume, the Shell's default action is to copy the file. By including a CFSTR_PREFERREDDROPFORMAT format in the data
	/// object, you can override the default action and explicitly tell the Shell to copy, move, or link the file. If the user chooses to
	/// drag with the right button, CFSTR_PREFERREDDROPFORMAT specifies the default command on the drag-and-drop shortcut menu. The user
	/// is still free to choose other commands on the menu.
	/// </para>
	/// <para>
	/// Before Microsoft Internet Explorer 4.0, an application indicated that it was transferring shortcut file types by setting
	/// FD_LINKUI in the dwFlags member of the FILEDESCRIPTOR structure. Targets then had to use a potentially time-consuming call to
	/// IDataObject::GetData to find out if the FD_LINKUI flag was set. Now, the preferred way to indicate that shortcuts are being
	/// transferred is to use the CFSTR_PREFERREDDROPEFFECT format set to DROPEFFECT_LINK. However, for backward compatibility with older
	/// systems, sources should still set the FD_LINKUI flag.
	/// </para>
	/// </summary>
	/// <value>Specifies whether its preferred method of data transfer is move or copy.</value>
	public DragDropEffects PreferredDropEffect
	{
		get => base.GetDataPresent(ShellClipboardFormat.CFSTR_PREFERREDDROPEFFECT) ? (DragDropEffects)(int)base.GetData(ShellClipboardFormat.CFSTR_PREFERREDDROPEFFECT, false) : 0;
		set => base.SetData(ShellClipboardFormat.CFSTR_PREFERREDDROPEFFECT, false, (int)value);
	}

	/// <summary>
	/// <para>This format identifier is used by a target to provide its CLSID to the source.</para>
	/// <para>
	/// This format is used primarily to allow objects to be deleted by dragging them to the Recycle Bin. When an object is dropped in
	/// the Recycle Bin, the source's IDataObject::SetData method is called with a CFSTR_TARGETCLSID format set to the Recycle Bin's
	/// CLSID (CLSID_RecycleBin). The source can then delete the original object.
	/// </para>
	/// </summary>
	/// <value>The CLSID.</value>
	public Guid TargetClsid
	{
		get => base.GetDataPresent(ShellClipboardFormat.CFSTR_TARGETCLSID) ? (Guid)base.GetData(ShellClipboardFormat.CFSTR_TARGETCLSID, false) : default;
		set => base.SetData(ShellClipboardFormat.CFSTR_TARGETCLSID, false, value);
	}

	/// <summary>Queries a data object for the presence of data in the FileNameMap data format.</summary>
	/// <returns><see langword="true"/> if the data object contains data in the FileNameMap data format; otherwise, <see langword="false"/>.</returns>
	public bool ContainsFileNameMap() => GetDataPresent(ShellClipboardFormat.CFSTR_FILENAMEMAPW) || GetDataPresent(ShellClipboardFormat.CFSTR_FILENAMEMAPA);

	/// <summary>Queries a data object for the presence of data in the "Shell IDList Array" (CFSTR_SHELLIDLIST) data format.</summary>
	/// <returns>
	/// <see langword="true"/> if the data object contains data in the "Shell IDList Array" (CFSTR_SHELLIDLIST) data format; otherwise,
	/// <see langword="false"/>.
	/// </returns>
	public bool ContainsShellIdList() => GetDataPresent(ShellClipboardFormat.CFSTR_SHELLIDLIST);

	/// <inheritdoc/>
	public override object GetData(string format, bool autoConvert)
	{
		switch (format)
		{
			case ShellClipboardFormat.CFSTR_FILEDESCRIPTORA:
			case ShellClipboardFormat.CFSTR_FILEDESCRIPTORW:
				// override the default handling of FileGroupDescriptor which returns a MemoryStream and instead return an array of ShellFileDescriptor

				var fileGroupDescriptor = ((IComDataObject)this).GetData<FILEGROUPDESCRIPTOR>(GetFormatId(format));

				// Extract a ShellFileDescriptor from each FILEDESCRIPTOR
				return fileGroupDescriptor.Select(fd => new ShellFileDescriptor(fd)).ToArray();

			case ShellClipboardFormat.CFSTR_FILECONTENTS:
				// override the default handling of FileContents which returns the contents of the first file as a memory stream and
				// instead return a array of Streams containing the data to each file dropped

				// get the array of filenames which lets us know how many file contents exist
				var cnt = ((IComDataObject)this).TryGetData<FILEGROUPDESCRIPTOR>(GetFormatId(ShellClipboardFormat.CFSTR_FILEDESCRIPTORW), out var fgd) ? (int)fgd.cItems :
					((IComDataObject)this).TryGetData<FILEGROUPDESCRIPTOR>(GetFormatId(ShellClipboardFormat.CFSTR_FILEDESCRIPTORA), out var fgda) ? (int)fgda.cItems : 0;

				// create a Stream array to store the file contents
				var fileContents = new Stream[cnt];

				// loop for the number of files acording to the file names
				for (var fileIndex = 0; fileIndex < cnt; fileIndex++)
				{
					// get the data at the file index and store in array
					fileContents[fileIndex] = (Stream)(GetData(format, fileIndex) ?? throw new InvalidOperationException("Invalid stream or index"));
				}

				// return array of MemoryStreams containing file contents
				return fileContents;

			case ShellClipboardFormat.CFSTR_FILENAMEMAPA:
			case ShellClipboardFormat.CFSTR_FILENAMEMAPW:
				return GetFileNameMap();

			case ShellClipboardFormat.CFSTR_INETURLW:
				return base.GetText(TextDataFormat.UnicodeText);

			case ShellClipboardFormat.CFSTR_INETURLA:
				return base.GetText(TextDataFormat.Text);

			case ShellClipboardFormat.CFSTR_SHELLIDLIST:
				return GetShellIdList() ?? new ShellItemArray();
		}
		return base.GetData(format, autoConvert);
	}

	/// <summary>Retrieves the data associated with the specified data format at the specified index.</summary>
	/// <param name="format">
	/// The format of the data to retrieve. See <see cref="T:System.Windows.Forms.DataFormats"></see> for predefined formats.
	/// </param>
	/// <param name="index">The index of the data to retrieve.</param>
	/// <returns>An object containing the raw data for the specified data format at the specified index.</returns>
	[DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(ILockBytes))]
	[DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(IStorage))]
	public object? GetData(string format, int index)
	{
		var data = ((IComDataObject)this).GetData(GetFormatId(format), DVASPECT.DVASPECT_CONTENT, index);

		// retrieve the data depending on the returned store type
		switch (data)
		{
			case IStorage pStorage:
				// to handle a IStorage it needs to be written into a second unmanaged memory mapped storage and then the data can be
				// read from memory into a managed byte and returned as a MemoryStream

#pragma warning disable IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
				// create a ILockBytes (unmanaged byte array) and then create a IStorage using the byte array as a backing store
				CreateILockBytesOnHGlobal(IntPtr.Zero, true, out ILockBytes iLockBytes).ThrowIfFailed();
				using (ComReleaser<ILockBytes> pLockBytes = ComReleaserFactory.Create(iLockBytes))
				{
					StgCreateDocfileOnILockBytes(iLockBytes, STGM.STGM_CREATE | STGM.STGM_WRITE | STGM.STGM_READWRITE, default, out IStorage iStorage2).ThrowIfFailed();
					using ComReleaser<IStorage> pStorage2 = ComReleaserFactory.Create(iStorage2);

					// copy the returned IStorage into the new IStorage
					pStorage.CopyTo(0, null, IntPtr.Zero, iStorage2);
					iLockBytes.Flush();
					iStorage2.Commit(0);

					// get the STATSTG of the ILockBytes to determine how many bytes were written to it
					iLockBytes.Stat(out System.Runtime.InteropServices.ComTypes.STATSTG iLockBytesStat, STATFLAG.STATFLAG_NONAME);

					// read the data from the ILockBytes (unmanaged byte array) into a managed byte array
					using var iLockBytesContent = new SafeHGlobalHandle(iLockBytesStat.cbSize);
					iLockBytes.ReadAt(0, iLockBytesContent, iLockBytesContent.Size, out _);

					// wrapped the managed byte array into a memory stream and return it
					return new MemoryStream(iLockBytesContent.GetBytes(0, iLockBytesContent.Size));
				}
#pragma warning restore IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.

			case IStream pStream:
				// Wrap in ComStream and return
				return new ComStream(pStream);

			default:
				return data;
		}
	}

	/// <summary>
	/// This is used when a group of files in CF_HDROP (FileDrop) format is being renamed as well as transferred. The data consists of an
	/// array that contains a new name for each file, in the same order that the files are listed in the accompanying CF_HDROP format.
	/// The format of the character array is the same as that used by CF_HDROP to list the transferred files.
	/// </summary>
	/// <returns>A list of strings containing a new name for each file.</returns>
	public string[] GetFileNameMap()
	{
		string[]? ret = null;
		if (GetDataPresent(ShellClipboardFormat.CFSTR_FILENAMEMAPW))
			ret = ((IComDataObject)this).GetData(GetFormatId(ShellClipboardFormat.CFSTR_FILENAMEMAPW)) as string[];
		else if (GetDataPresent(ShellClipboardFormat.CFSTR_FILENAMEMAPA))
			ret = ((IComDataObject)this).GetData(GetFormatId(ShellClipboardFormat.CFSTR_FILENAMEMAPA)) as string[];
		return ret ?? new string[0];
	}

	/// <summary>Gets a <see cref="ShellItemArray"/> from the data object. Returns <see langword="null"/> if data is not present.</summary>
	/// <returns>An array of shell items or <see langword="null"/> if data is not present.</returns>
	public ShellItemArray? GetShellIdList()
	{
		if (!ContainsShellIdList())
			return null;
#pragma warning disable IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
		SHCreateShellItemArrayFromDataObject(this, typeof(IShellItemArray).GUID, out var isha).ThrowIfFailed();
#pragma warning restore IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
		return new ShellItemArray(isha);
	}

	/// <summary>Sets the data for the object.</summary>
	/// <param name="format">The format of the specified data. See <see cref="T:System.Windows.Forms.DataFormats"/> for predefined formats.</param>
	/// <param name="data">The data.</param>
	/// <returns></returns>
	/// <exception cref="ArgumentException">Data value must be of type DROPDESCRIPTION., nameof(data)</exception>
	public override void SetData(string format, object data)
	{
		if (format == ShellClipboardFormat.CFSTR_DROPDESCRIPTION)
		{
			if (data is not DROPDESCRIPTION dd)
				throw new ArgumentException("Data value must be of type DROPDESCRIPTION.", nameof(data));
			((IComDataObject)this).SetData(GetFormatId(format), dd);
			return;
		}
		base.SetData(format, true, data);
	}

	/// <summary>Sets the data value for a format and index to a <see cref="IStream"/>.</summary>
	/// <param name="format">The format of the specified data. See <see cref="T:System.Windows.Forms.DataFormats"/> for predefined formats.</param>
	/// <param name="stream">The stream interface instance to set for the format.</param>
	/// <param name="index">Specifies part of the aspect when the data must be split across page boundaries.</param>
	/// <param name="aspect">
	/// Specifies one of the DVASPECT enumeration constants that indicates how much detail should be contained in the rendering.
	/// </param>
	public void SetOleStreamData(string format, IStream stream, int index = -1, DVASPECT aspect = DVASPECT.DVASPECT_CONTENT) =>
		((IComDataObject)this).SetData(GetFormatId(format), stream, aspect, index);

	private static uint GetFormatId(string format) => (uint)DataFormats.GetFormat(format).Id;
}

/// <summary>
/// Describes the properties of a file that is being copied by means of the clipboard during a Microsoft ActiveX drag-and-drop operation.
/// </summary>
public class ShellFileDescriptor
{
	/// <summary>Initializes a new instance of the <see cref="ShellFileDescriptor"/> class.</summary>
	/// <param name="fileInfo">The file information.</param>
	public ShellFileDescriptor(FileInfo fileInfo) => Info = fileInfo;

	internal ShellFileDescriptor(in FILEDESCRIPTOR fd)
	{
		Info = new FileInfo(fd.cFileName);
		if (fd.dwFlags.IsFlagSet(FD_FLAGS.FD_CLSID))
			TypeIdClsid = fd.clsid;
		if (fd.dwFlags.IsFlagSet(FD_FLAGS.FD_SIZEPOINT))
		{
			IconSize = fd.sizel;
			ScreenPosition = fd.pointl;
		}
		ShowProgressUI = fd.dwFlags.IsFlagSet(FD_FLAGS.FD_PROGRESSUI);
		IsShortcut = fd.dwFlags.IsFlagSet(FD_FLAGS.FD_LINKUI);
	}

	/// <summary>The width and height of the file icon.</summary>
	public Size? IconSize { get; set; }

	/// <summary>Gets the file information.</summary>
	/// <value>The file information.</value>
	public FileInfo Info { get; }

	/// <summary>Treat the operation as a shortcut.</summary>
	public bool IsShortcut { get; set; }

	/// <summary>The screen coordinates of the file object.</summary>
	public POINT? ScreenPosition { get; set; }

	/// <summary>progress indicator is shown with drag-and-drop operations.</summary>
	public bool ShowProgressUI { get; set; }

	/// <summary>The file type identifier.</summary>
	public Guid? TypeIdClsid { get; set; }

	internal FILEDESCRIPTOR ToFileDesc() => new()
	{
		dwFlags = FD_FLAGS.FD_ATTRIBUTES | FD_FLAGS.FD_WRITESTIME | FD_FLAGS.FD_FILESIZE | FD_FLAGS.FD_ACCESSTIME | FD_FLAGS.FD_CREATETIME |
				(ShowProgressUI ? FD_FLAGS.FD_PROGRESSUI : 0) | (IsShortcut ? FD_FLAGS.FD_LINKUI : 0) | (TypeIdClsid.HasValue ? FD_FLAGS.FD_CLSID : 0) |
				(IconSize.HasValue ? FD_FLAGS.FD_SIZEPOINT : 0),
		clsid = TypeIdClsid ?? Guid.Empty,
		cFileName = Info.FullName,
		dwFileAttributes = (FileFlagsAndAttributes)Info.Attributes,
		nFileSize = unchecked((ulong)Info.Length),
		ftCreationTime = Info.CreationTimeUtc.ToFileTimeStruct(),
		ftLastAccessTime = Info.LastAccessTimeUtc.ToFileTimeStruct(),
		ftLastWriteTime = Info.LastWriteTimeUtc.ToFileTimeStruct(),
		sizel = IconSize ?? SIZE.Empty,
		pointl = ScreenPosition ?? POINT.Empty
	};
}