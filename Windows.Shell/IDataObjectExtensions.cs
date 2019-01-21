using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;
using Vanara.Extensions;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;
using IComDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;

namespace Vanara.Windows.Shell
{
	// TODO
	public static class DataObjectExtensions
	{
		public static IReadOnlyList<string> GetFileNameMap(this DataObject dobj)
		{
			var l = new List<string>();
			if (dobj.GetDataPresent(ShellDataFormat.FileNameMap.Id()))
			{
				if (dobj.GetData(ShellDataFormat.FileNameMap.Id(), true) is string[] data)
					l.AddRange(data);
			}
			return (IReadOnlyList<string>)l;
		}

		public static DROPEFFECT GetPreferredDropEffect(this DataObject dobj)
		{
			dobj.GetData(typeof(uint));
			var eff = DROPEFFECT.DROPEFFECT_NONE;
			if (dobj is IComDataObject cdo)
			{
				var fc = MakeFORMATETC(ShellClipboardFormat.CFSTR_PREFERREDDROPEFFECT);
				try
				{
					cdo.GetData(ref fc, out var medium);
					if (medium.unionmember != default)
						eff = (DROPEFFECT)medium.unionmember.ToStructure<uint>();
					ReleaseStgMedium(medium);
				}
				catch { }
			}
			return eff;
		}

		public static IReadOnlyCollection<PIDL> GetShellIdList(this DataObject dobj)
		{
			var l = new List<PIDL>();
			if (dobj is IComDataObject cdo)
			{
				var fc = MakeFORMATETC(ShellClipboardFormat.CFSTR_SHELLIDLIST);
				try
				{
					cdo.GetData(ref fc, out var medium);
					if (medium.unionmember != default)
					{
						var cnt = (int)medium.unionmember.ToStructure<uint>() + 1;
						foreach (var offset in medium.unionmember.Offset(sizeof(uint)).ToArray<uint>(cnt))
							l.Add(new PIDL(medium.unionmember.Offset(offset), true));
					}
					ReleaseStgMedium(medium);
				}
				catch { }
			}
			return (IReadOnlyList<PIDL>)l;
		}

		public static void SetTargetClsid(this DataObject dobj, in Guid clsid) => dobj.SetData(ShellClipboardFormat.CFSTR_TARGETCLSID, clsid);

		internal static FORMATETC MakeFORMATETC(string fmt, TYMED tymed = TYMED.TYMED_HGLOBAL) => new FORMATETC
		{
			cfFormat = (short)GetFormat(fmt).Id,
			dwAspect = DVASPECT.DVASPECT_CONTENT,
			lindex = -1,
			tymed = tymed
		};

		private static DataFormats.Format GetFormat(string format) => DataFormats.GetFormat(format);
	}
}
