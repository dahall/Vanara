using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using Vanara.Extensions;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.Shell32;
using System.Linq;
using IComDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.Windows.Shell
{
	internal static class ClipboardEx
	{
		public static void Clear() => Clipboard.Clear();
		public static bool ContainsAudio() => Clipboard.ContainsAudio();
		public static bool ContainsData(string format) => Clipboard.ContainsData(format);
		public static bool ContainsFileDropList() => Clipboard.ContainsFileDropList();
		public static bool ContainsImage() => Clipboard.ContainsImage();
		public static bool ContainsText() => Clipboard.ContainsText();
		public static bool ContainsText(TextDataFormat format) => Clipboard.ContainsText(format);
		public static Stream GetAudioStream() => Clipboard.GetAudioStream();
		public static object GetData(string format) => Clipboard.GetData(format);
		public static System.Windows.Forms.IDataObject GetDataObject() => Clipboard.GetDataObject();
		public static IList<string> GetFileDropList() => new List<string>(Clipboard.GetFileDropList().Cast<string>());
		public static Image GetImage() => Clipboard.GetImage();
		public static string GetText() => Clipboard.GetText();
		public static string GetText(TextDataFormat format) => Clipboard.GetText(format);
		public static void SetAudio(byte[] audioBytes) => Clipboard.SetAudio(audioBytes);
		public static void SetAudio(Stream audioStream) => Clipboard.SetAudio(audioStream);
		public static void SetData(string format, object data) => Clipboard.SetData(format, data);
		public static void SetDataObject(object data) => Clipboard.SetDataObject(data);
		public static void SetDataObject(object data, bool copy) => Clipboard.SetDataObject(data, copy);
		[UIPermission(SecurityAction.Demand, Clipboard = UIPermissionClipboard.OwnClipboard)]
		public static void SetDataObject(object data, bool copy, int retryTimes, int retryDelay) => Clipboard.SetDataObject(data, copy, retryTimes, retryDelay);
		public static void SetFileDropList(IEnumerable<string> filePaths) => Clipboard.SetFileDropList(ToSC(filePaths));
		public static void SetImage(Image image) => Clipboard.SetImage(image);
		public static void SetText(string text) => Clipboard.SetText(text);
		public static void SetText(string text, TextDataFormat format) => Clipboard.SetText(text, format);

		internal static StringCollection ToSC(IEnumerable<string> e) { var sc = new StringCollection(); if (e != null) sc.AddRange(e.ToArray()); return sc; }

		internal static string Id(this ShellDataFormat fmt)
		{
			var ansi = System.Text.Encoding.Default.IsSingleByte;
			string cfval = null;
			switch (fmt)
			{
				case ShellDataFormat.FileDescriptor:
					cfval = ansi ? ShellClipboardFormat.CFSTR_FILEDESCRIPTORA : ShellClipboardFormat.CFSTR_FILEDESCRIPTORW;
					break;
				case ShellDataFormat.FileName:
					cfval = ansi ? ShellClipboardFormat.CFSTR_FILENAMEA : ShellClipboardFormat.CFSTR_FILENAMEW;
					break;
				case ShellDataFormat.FileNameMap:
					cfval = ansi ? ShellClipboardFormat.CFSTR_FILENAMEMAPA : ShellClipboardFormat.CFSTR_FILENAMEMAPW;
					break;
				case ShellDataFormat.InetUrl:
					cfval = ansi ? ShellClipboardFormat.CFSTR_INETURLA: ShellClipboardFormat.CFSTR_INETURLW;
					break;
				case ShellDataFormat.AutoPlayLists:
					cfval = ShellClipboardFormat.CFSTR_AUTOPLAY_SHELLIDLISTS;
					break;
				case ShellDataFormat.FileAttributes:
					cfval = ShellClipboardFormat.CFSTR_FILE_ATTRIBUTES_ARRAY;
					break;
				case ShellDataFormat.InvokeCommandDropParam:
					cfval = ShellClipboardFormat.CFSTR_INVOKECOMMAND_DROPPARAM;
					break;
				default:
					cfval = GetSCFField("CFSTR_" + fmt.ToString().ToUpper());
					break;
			}
			return cfval ?? throw new ArgumentOutOfRangeException(nameof(fmt));

			string GetSCFField(string fName)
			{
				var fi = typeof(ShellClipboardFormat).GetField(fName, BindingFlags.Public | BindingFlags.Static);
				if (fi != null && fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
					return (string)fi.GetRawConstantValue();
				return null;
			}
		}
	}

	internal enum ShellDataFormat
	{
		ShellIdList,
		ShellIdListOffset,
		NetResources,
		FileDescriptor,
		FileContents,
		FileName,
		PrinterGroup,
		FileNameMap,
		ShellUrl,
		InetUrl,
		PreferredDropEffect,
		PerformedDropEffect,
		PasteSucceeded,
		InDragLoop,
		MountedVolume,
		PersistedDataObject,
		TargetClsid,
		LogicalPerformedDropEffect,
		AutoPlayLists,
		UntrustedDragDrop,
		FileAttributes,
		InvokeCommandDropParam,
		ShellDropHandler,
		DropDescription,
		ZoneIdentifier,
	}
}