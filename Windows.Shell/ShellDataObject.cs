using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;
using IComDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;

namespace Vanara.Windows.Shell
{
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
		public Point? ScreenPosition { get; set; }

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
			pointl = ScreenPosition ?? Point.Empty
		};
	}

	/// <summary>Shell extended <see cref="DataObject"/>.</summary>
	// TODO: Finish adding ShellClipboardFormat handling, tests and release
	internal class ShellDataObject : DataObject
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
		/// <param name="format">
		/// The format of the specified data. See <see cref="T:System.Windows.Forms.DataFormats"/> for predefined formats.
		/// </param>
		/// <param name="data">The data to store.</param>
		public ShellDataObject(string format, object data) : base()
		{
			SetData(format, data);
		}

		/// <summary>Initializes a new instance of the <see cref="ShellDataObject"/> class.</summary>
		/// <param name="items">A list of ShellItem instances.</param>
		public ShellDataObject(IEnumerable<ShellItem> items) : base()
		{
			if ((items?.Count() ?? 0) == 0)
				throw new ArgumentNullException(nameof(items));

			// Set the drop effect
			PreferredDropEffect = DragDropEffects.Copy | DragDropEffects.Link;

			// Set data for Vista+ that includes IDList, file descriptors, and content stream.
			if (items is not ShellItemArray litems)
				litems = new ShellItemArray(items);
			SetData(ShellClipboardFormat.CFSTR_SHELLIDLIST, GetPIDLArrayStream(litems));
			SetData(ShellClipboardFormat.CFSTR_FILEDESCRIPTORW, GetFileDescriptor(litems));
			for (var idx = 0; idx < litems.Count; idx++)
			{
				SetOleStreamData(ShellClipboardFormat.CFSTR_FILECONTENTS, litems[idx].GetStream(STGM.STGM_READ), idx);
			}

			// For all file system objects, provide CF_HDROP and CFSTR_FILENAMEx values for first file
			var files = items.Where(i => i.IsFileSystem).Select(i => i.FileSystemPath).ToArray();
			if (files.Length > 0)
			{
				SetData(DataFormats.FileDrop, true, files);
				FunctionHelper.CallMethodWithStrBuf((sb, sz) => Kernel32.GetShortPathName(files[0], sb, sz), 1024U, out var dosfn);
				SetData(ShellClipboardFormat.CFSTR_FILENAMEA, Encoding.ASCII.GetBytes(dosfn));
				SetData(ShellClipboardFormat.CFSTR_FILENAMEW, Encoding.Unicode.GetBytes(files[0]));
			}

			// Writes a FILEGROUPDESCRIPTOR structure to memory populated with shell items
			static Stream GetFileDescriptor(IEnumerable<ShellItem> items)
			{
				var mem = new NativeMemoryStream();
				// Write out the FILEGROUPDESCRIPTOR.cItems value
				mem.Write((uint)items.Count());
				// Write out the FILEGROUPDESCRIPTOR.fgd array
				mem.Write(items.Select(i => MakeFD(i)));
				return mem;

				static FILEDESCRIPTOR MakeFD(ShellItem si)
				{
					var fi = si.FileInfo;
					return new()
					{
						dwFlags = FD_FLAGS.FD_WRITESTIME | FD_FLAGS.FD_FILESIZE | FD_FLAGS.FD_ATTRIBUTES | FD_FLAGS.FD_PROGRESSUI,
						dwFileAttributes = (FileFlagsAndAttributes)fi.Attributes,
						ftLastWriteTime = fi.LastWriteTimeUtc.ToFileTimeStruct(),
						nFileSize = unchecked((ulong)fi.Length),
						cFileName = si.ParsingName,
					};
				}
			}
		}

		/// <summary>This format identifier is used by a data object to indicate whether it is in a drag-and-drop loop.</summary>
		/// <remarks>
		/// Some drop targets might call IDataObject::GetData and attempt to extract data while the object is still within the drag-and-drop
		/// loop. Fully rendering the object for each such occurrence might cause the drag cursor to stall. If the data object supports
		/// CFSTR_INDRAGLOOP, the target can instead use that format to check the status of the drag-and-drop loop and avoid memory
		/// intensive rendering of the object until it is actually dropped. The formats that are memory intensive to render should still be
		/// included in the FORMATETC enumerator and in calls to IDataObject::QueryGetData. If the data object does not set
		/// CFSTR_INDRAGLOOP, it should act as if the value is set to zero.
		/// </remarks>
		/// <value><see langword="true"/> if the data object is within a drag-and-drop loop; otherwise, <see langword="false"/>.</value>
		public bool InDragLoop
		{
			get => base.GetData(ShellClipboardFormat.CFSTR_INDRAGLOOP) is int i && i != 0;
			set => base.SetData(ShellClipboardFormat.CFSTR_INDRAGLOOP, value ? 1 : 0);
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
		/// source's IDataObject::SetData method with a CFSTR_PERFORMEDDROPEFFECT format to tell the data object which operation was
		/// actually performed.
		/// </para>
		/// <para>
		/// With a delete-on-paste operation, the CFSTR_PREFERREDDROPFORMAT format is used to tell the target whether the source did a cut
		/// or copy. With a drag-and-drop operation, you can use CFSTR_PREFERREDDROPFORMAT to specify the Shell's action. If this format is
		/// not present, the Shell performs a default action, based on context. For instance, if a user drags a file from one volume and
		/// drops it on another volume, the Shell's default action is to copy the file. By including a CFSTR_PREFERREDDROPFORMAT format in
		/// the data object, you can override the default action and explicitly tell the Shell to copy, move, or link the file. If the user
		/// chooses to drag with the right button, CFSTR_PREFERREDDROPFORMAT specifies the default command on the drag-and-drop shortcut
		/// menu. The user is still free to choose other commands on the menu.
		/// </para>
		/// <para>
		/// Before Microsoft Internet Explorer 4.0, an application indicated that it was transferring shortcut file types by setting
		/// FD_LINKUI in the dwFlags member of the FILEDESCRIPTOR structure. Targets then had to use a potentially time-consuming call to
		/// IDataObject::GetData to find out if the FD_LINKUI flag was set. Now, the preferred way to indicate that shortcuts are being
		/// transferred is to use the CFSTR_PREFERREDDROPEFFECT format set to DROPEFFECT_LINK. However, for backward compatibility with
		/// older systems, sources should still set the FD_LINKUI flag.
		/// </para>
		/// </summary>
		/// <value>Specifies whether its preferred method of data transfer is move or copy.</value>
		public DragDropEffects PreferredDropEffect
		{
			get => base.GetData(ShellClipboardFormat.CFSTR_PREFERREDDROPEFFECT) is int i ? (DragDropEffects)i : 0;
			set => base.SetData(ShellClipboardFormat.CFSTR_PREFERREDDROPEFFECT, (int)value);
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
			get => base.GetData(ShellClipboardFormat.CFSTR_TARGETCLSID) is Guid g ? g : default;
			set => base.SetData(ShellClipboardFormat.CFSTR_TARGETCLSID, value);
		}

		/// <inheritdoc/>
		public override object GetData(string format, bool autoConvert)
		{
			var obj = base.GetData(format);
			switch (format)
			{
				case ShellClipboardFormat.CFSTR_FILEDESCRIPTORA:
				case ShellClipboardFormat.CFSTR_FILEDESCRIPTORW:
					// override the default handling of FileGroupDescriptor which returns a MemoryStream and instead return a string array
					// of file names

					// Pick format based on CharSet.Auto size
					format = StringHelper.GetCharSize() == 1 ? ShellClipboardFormat.CFSTR_FILEDESCRIPTORA : ShellClipboardFormat.CFSTR_FILEDESCRIPTORW;

					// Get the FileGroupDescriptor as a MemoryStream
					var fileGroupDescriptorStream = (MemoryStream)base.GetData(format, autoConvert);
					var fileGroupDescriptorBytes = new byte[fileGroupDescriptorStream.Length];
					fileGroupDescriptorStream.Read(fileGroupDescriptorBytes, 0, fileGroupDescriptorBytes.Length);
					fileGroupDescriptorStream.Close();

					// copy the file group descriptor into unmanaged memory
					using (var fileGroupDescriptorAPointer = new SafeHGlobalHandle(fileGroupDescriptorBytes))
					{
						Marshal.Copy(fileGroupDescriptorBytes, 0, fileGroupDescriptorAPointer, fileGroupDescriptorBytes.Length);

						// marshal the unmanaged memory to to FILEGROUPDESCRIPTOR struct
						FILEGROUPDESCRIPTOR fileGroupDescriptor = fileGroupDescriptorAPointer.ToStructure<FILEGROUPDESCRIPTOR>();

						// Extract and return filenames from each FILEDESCRIPTOR
						return fileGroupDescriptor.Select(fd => new ShellFileDescriptor(fd)).ToArray();
					}

				case ShellClipboardFormat.CFSTR_FILECONTENTS:
					// override the default handling of FileContents which returns the contents of the first file as a memory stream and
					// instead return a array of MemoryStreams containing the data to each file dropped

					// get the array of filenames which lets us know how many file contents exist
					var fileContentNames = (string[])GetData(ShellClipboardFormat.CFSTR_FILEDESCRIPTORA);

					// create a MemoryStream array to store the file contents
					var fileContents = new MemoryStream[fileContentNames.Length];

					// loop for the number of files acording to the file names
					for (var fileIndex = 0; fileIndex < fileContentNames.Length; fileIndex++)
					{
						// get the data at the file index and store in array
						fileContents[fileIndex] = GetData(format, fileIndex) as MemoryStream;
					}

					// return array of MemoryStreams containing file contents
					return fileContents;

				case ShellClipboardFormat.CFSTR_INETURLW:
					return base.GetText(TextDataFormat.UnicodeText);

				case ShellClipboardFormat.CFSTR_INETURLA:
					return base.GetText(TextDataFormat.Text);
			}
			// if (format == DataFormats.FileDrop && (int)base.GetData(ShellClipboardFormat.CFSTR_INDRAGLOOP) != 0 && obj is StringCollection s)
			//{
			//}
			return obj;
		}

		/// <summary>Retrieves the data associated with the specified data format at the specified index.</summary>
		/// <param name="format">
		/// The format of the data to retrieve. See <see cref="T:System.Windows.Forms.DataFormats"></see> for predefined formats.
		/// </param>
		/// <param name="index">The index of the data to retrieve.</param>
		/// <returns>An object containing the raw data for the specified data format at the specified index.</returns>
		public object GetData(string format, int index)
		{
			// create a FORMATETC struct to request the data with
			var formatetc = new FORMATETC
			{
				cfFormat = (short)DataFormats.GetFormat(format).Id,
				dwAspect = DVASPECT.DVASPECT_CONTENT,
				lindex = index,
				ptd = new IntPtr(0),
				tymed = TYMED.TYMED_ISTREAM | TYMED.TYMED_ISTORAGE | TYMED.TYMED_HGLOBAL
			};

			// using the Com IDataObject interface get the data using the defined FORMATETC
			((IComDataObject)this).GetData(ref formatetc, out STGMEDIUM medium);

			// retrieve the data depending on the returned store type
			switch (medium.tymed)
			{
				case TYMED.TYMED_ISTORAGE:
					// to handle a IStorage it needs to be written into a second unmanaged memory mapped storage and then the data can be
					// read from memory into a managed byte and returned as a MemoryStream
					{
						// marshal the returned pointer to a IStorage object
						using ComReleaser<IStorage> pStorage = ComReleaserFactory.Create((IStorage)Marshal.GetObjectForIUnknown(medium.unionmember));
						Marshal.Release(medium.unionmember);

						// create a ILockBytes (unmanaged byte array) and then create a IStorage using the byte array as a backing store
						CreateILockBytesOnHGlobal(IntPtr.Zero, true, out ILockBytes iLockBytes).ThrowIfFailed();
						using ComReleaser<ILockBytes> pLockBytes = ComReleaserFactory.Create(iLockBytes);
						StgCreateDocfileOnILockBytes(iLockBytes, STGM.STGM_CREATE | STGM.STGM_WRITE | STGM.STGM_READWRITE, default, out IStorage iStorage2).ThrowIfFailed();
						using ComReleaser<IStorage> pStorage2 = ComReleaserFactory.Create(iStorage2);

						// copy the returned IStorage into the new IStorage
						pStorage.Item.CopyTo(0, null, IntPtr.Zero, iStorage2);
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

				case TYMED.TYMED_ISTREAM:
					// to handle a IStream it needs to be read into a managed byte and returned as a MemoryStream
					{
						// marshal the returned pointer to a IStream object
						using ComReleaser<IStream> pStream = ComReleaserFactory.Create((IStream)Marshal.GetObjectForIUnknown(medium.unionmember));
						Marshal.Release(medium.unionmember);

						// get the STATSTG of the IStream to determine how many bytes are in it
						pStream.Item.Stat(out System.Runtime.InteropServices.ComTypes.STATSTG iStreamStat, 0);

						// read the data from the IStream into a managed byte array
						var iStreamContent = new byte[((int)iStreamStat.cbSize)];
						pStream.Item.Read(iStreamContent, iStreamContent.Length, IntPtr.Zero);

						// wrapped the managed byte array into a memory stream and return it
						return new MemoryStream(iStreamContent);
					}

				case TYMED.TYMED_HGLOBAL:
					// to handle a HGlobal the exisitng "GetDataFromHGLOBLAL" method is invoked via reflection
					return GetObjectFromHGlobal(DataFormats.GetFormat(formatetc.cfFormat).Name, medium.unionmember);
			}

			return null;
		}

		/// <summary>
		/// This is used when a group of files in CF_HDROP format is being renamed as well as transferred. The data consists of an STGMEDIUM
		/// structure that contains a global memory object. The structure's hGlobal member points to a double null-terminated character
		/// array. This array contains a new name for each file, in the same order that the files are listed in the accompanying CF_HDROP
		/// format. The format of the character array is the same as that used by CF_HDROP to list the transferred files.
		/// </summary>
		/// <returns>A list of strings containing a name for each file.</returns>
		public string[] GetFileNameMap()
		{
			if (GetDataPresent(ShellClipboardFormat.CFSTR_FILENAMEMAPW) && GetData(ShellClipboardFormat.CFSTR_FILENAMEMAPW, true) is StringCollection dataw)
				return dataw.Cast<string>().ToArray();
			else if (GetDataPresent(ShellClipboardFormat.CFSTR_FILENAMEMAPA) && GetData(ShellClipboardFormat.CFSTR_FILENAMEMAPA, true) is StringCollection data)
				return data.Cast<string>().ToArray();
			return new string[0];
		}

		/// <summary>
		/// <para>
		/// This format identifier is used when transferring the locations of one or more existing namespace objects. It is used in much the
		/// same way as CF_HDROP, but it contains PIDLs instead of file system paths. Using PIDLs allows the CFSTR_SHELLIDLIST format to
		/// handle virtual objects as well as file system objects. The data is an STGMEDIUM structure that contains a global memory object.
		/// The structure's hGlobal member points to a CIDA structure.
		/// </para>
		/// <para>
		/// The aoffset member of the CIDA structure is an array containing offsets to the beginning of the ITEMIDLIST structure for each
		/// PIDL that is being transferred. To extract a particular PIDL, first determine its index. Then, add the aoffset value that
		/// corresponds to that index to the address of the CIDA structure.
		/// </para>
		/// <para>
		/// The first element of aoffset contains an offset to the fully qualified PIDL of a parent folder. If this PIDL is empty, the
		/// parent folder is the desktop. Each of the remaining elements of the array contains an offset to one of the PIDLs to be
		/// transferred. All of these PIDLs are relative to the PIDL of the parent folder.
		/// </para>
		/// <para>
		/// The following two macros can be used to retrieve PIDLs from a CIDA structure. The first takes a pointer to the structure and
		/// retrieves the PIDL of the parent folder. The second takes a pointer to the structure and retrieves one of the other PIDLs,
		/// identified by its zero-based index.
		/// </para>
		/// <code lang="cpp">#define GetPIDLFolder(pida) (LPCITEMIDLIST)(((LPBYTE)pida)+(pida)-&gt;aoffset[0])
		///#define GetPIDLItem(pida, i) (LPCITEMIDLIST)(((LPBYTE)pida)+(pida)-&gt;aoffset[i+1])</code>
		/// <note type="note">The value that is returned by these macros is a pointer to the PIDL's ITEMIDLIST structure. Since these
		/// structures vary in length, you must determine the end of the structure by walking through each of the ITEMIDLIST structure's
		/// SHITEMID structures until you reach the two-byte NULL that marks the end.</note>
		/// </summary>
		/// <returns>A list of strings containing a name for each file.</returns>
		public PIDL[] GetShellIdList() => GetComData(ShellClipboardFormat.CFSTR_SHELLIDLIST,
			p => Array.ConvertAll(p.Offset(sizeof(uint)).ToArray<uint>((int)p.ToStructure<uint>() + 1), u => new PIDL(p.Offset(u), true)), new PIDL[0]);

		public override void SetData(string format, object data)
		{
			if (format == ShellClipboardFormat.CFSTR_DROPDESCRIPTION)
			{
				if (data is not DROPDESCRIPTION dd)
					throw new ArgumentException("Data value must be of type DROPDESCRIPTION.", nameof(data));
				base.SetData(format, GetMemoryStream(dd));
				return;
			}
			base.SetData(format, data);
		}

		/// <summary>Sets the data value for a format and index to a <see cref="IStream"/>.</summary>
		/// <param name="format">
		/// The format of the specified data. See <see cref="T:System.Windows.Forms.DataFormats"/> for predefined formats.
		/// </param>
		/// <param name="stream">The stream interface instance to set for the format.</param>
		/// <param name="index">Specifies part of the aspect when the data must be split across page boundaries.</param>
		/// <param name="aspect">
		/// Specifies one of the DVASPECT enumeration constants that indicates how much detail should be contained in the rendering.
		/// </param>
		public void SetOleStreamData(string format, IStream stream, int index = -1, DVASPECT aspect = DVASPECT.DVASPECT_CONTENT)
		{
			FORMATETC formatetc = new()
			{
				cfFormat = unchecked((short)(ushort)(DataFormats.GetFormat(format).Id)),
				dwAspect = aspect,
				lindex = index,
				tymed = TYMED.TYMED_ISTREAM
			};
			STGMEDIUM medium = new() { tymed = TYMED.TYMED_ISTREAM, unionmember = Marshal.GetIUnknownForObject(stream) };
			((System.Runtime.InteropServices.ComTypes.IDataObject)this).SetData(ref formatetc, ref medium, true);
		}

		private static DataFormats.Format GetFormat(string format) => DataFormats.GetFormat(format);

		private static Stream GetPIDLArrayStream(IEnumerable<ShellItem> items)
		{
			var str = new MemoryStream();
			var pidlBytes = items.Select(i => i.PIDL.GetBytes()).ToArray();
			var offset = 0;
			str.Write(BitConverter.GetBytes((uint)pidlBytes.Length), offset, sizeof(uint));
			offset += sizeof(uint);
			for (var i = 0; i < pidlBytes.Length; i++, offset += sizeof(uint))
				str.Write(BitConverter.GetBytes((uint)pidlBytes[i].Length), offset, sizeof(uint));
			for (var i = 0; i < pidlBytes.Length; i++)
			{
				str.Write(pidlBytes[i], offset, pidlBytes[i].Length);
				offset += pidlBytes[i].Length;
			}
			return str;
		}

		private T GetComData<T>(string fmt, Func<IntPtr, T> convert, T defValue = default)
		{
			T ret = defValue;
			var fc = new FORMATETC { cfFormat = (short)GetFormat(fmt).Id, dwAspect = DVASPECT.DVASPECT_CONTENT, lindex = -1, tymed = TYMED.TYMED_HGLOBAL };
			try
			{
				((IComDataObject)this).GetData(ref fc, out STGMEDIUM medium);
				if (medium.unionmember != default)
					ret = convert(medium.unionmember);
				ReleaseStgMedium(medium);
			}
			catch { }
			return ret;
		}

		private Stream GetMemoryStream<T>(T value) where T : struct
		{
			var mem = new NativeMemoryStream(InteropExtensions.SizeOf(value));
			mem.Write(value);
			return mem;
		}

		private object GetObjectFromHGlobal(string format, IntPtr hGlobal)
		{
			IntPtr ptr = Win32Error.ThrowLastErrorIfNull(Kernel32.GlobalLock(hGlobal));
			try
			{
				if (format == DataFormats.Text || format == DataFormats.Rtf || format == DataFormats.CommaSeparatedValue || format == DataFormats.OemText)
					return StringHelper.GetString(ptr, CharSet.Ansi);
				else if (format == DataFormats.UnicodeText)
					return StringHelper.GetString(ptr, CharSet.Unicode);
				else if (format == DataFormats.Html)
					return NativeClipboard.GetHtml(ptr);
				else if (format == ShellClipboardFormat.CFSTR_FILENAMEA)
					return new[] { StringHelper.GetString(ptr, CharSet.Ansi) };
				else if (format == ShellClipboardFormat.CFSTR_FILENAMEW)
					return new[] { StringHelper.GetString(ptr, CharSet.Unicode) };
				else if (format == ShellClipboardFormat.CFSTR_DROPDESCRIPTION)
					return ptr.ToStructure<DROPDESCRIPTION>();
				else if (format == DataFormats.FileDrop)
					// TODO
					return new MemoryStream();
				else
					// TODO
					return new MemoryStream();
			}
			finally
			{
				Kernel32.GlobalUnlock(hGlobal);
			}
		}
	}
}