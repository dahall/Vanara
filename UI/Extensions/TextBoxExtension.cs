using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Windows.Forms;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.User32;

namespace Vanara.Extensions
{
	public static partial class TextBoxExtension
	{
		[Flags]
		public enum AutoCompleteOptions
		{
			None = 0,
			AutoSuggest = 0x1,
			AutoAppend = 0x2,
			Search = 0x4,
			FilterPreFixes = 0x8,
			UseTab = 0x10,
			UpDownKeyDropsList = 0x20,
			RtlReading = 0x40,
			WordFilter = 0x80,
			NoPrefixFiltering = 0x100
		}

		public static void SetCueBanner(this TextBox textBox, string cueBannerText, bool retainOnFocus = false)
		{
			if (Environment.OSVersion.Version.Major >= 6)
			{
				SendMessage(new HandleRef(textBox, textBox.Handle), (int)EditMessage.EM_SETCUEBANNER, new IntPtr(retainOnFocus ? 1 : 0), cueBannerText);
				textBox.Invalidate();
			}
			else
				throw new PlatformNotSupportedException();
		}

		public static void SetCustomAutoCompleteList(this TextBox textBox, IList<string> items, AutoCompleteOptions options = AutoCompleteOptions.AutoSuggest)
		{
			var ac = (IAutoComplete2)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("{00BB2763-6A77-11D0-A535-00C04FD7D062}")));
			ac.Init(new HandleRef(textBox, textBox.Handle), new ComEnumStringImpl(items), null, null);
			ac.SetOptions((int)options);
			Marshal.ReleaseComObject(ac);
		}

		[ComImport, SuppressUnmanagedCodeSecurity, Guid("EAC04BC0-3791-11D2-BB95-0060977B464C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		private interface IAutoComplete2
		{
			void Init(HandleRef hwndEdit, IEnumString punkAcl, [MarshalAs(UnmanagedType.LPWStr)] string pwszRegKeyPath, [MarshalAs(UnmanagedType.LPWStr)] string pwszQuickComplete);
			void Enable(bool fEnable);
			void SetOptions(int dwFlag);
			void GetOptions(out int dwFlag);
		}

		private class ComEnumStringImpl : IEnumString
		{
			private readonly IList<string> list;
			private int cur;

			public ComEnumStringImpl(IList<string> items)
			{
				list = items;
			}

			void IEnumString.Clone(out IEnumString ppenum) { ppenum = new ComEnumStringImpl(list) { cur = cur }; }

			int IEnumString.Next(int celt, string[] rgelt, IntPtr pceltFetched)
			{
				if (celt < 0) return -2147024809;
				var idx = 0;
				while (cur < list.Count && celt > 0)
				{
					rgelt[idx] = list[cur];
					idx++;
					cur++;
					celt--;
				}
				if (pceltFetched != IntPtr.Zero)
					Marshal.WriteInt32(pceltFetched, idx);
				return celt == 0 ? 0 : 1;
			}

			void IEnumString.Reset() { cur = 0; }

			int IEnumString.Skip(int celt) => (cur += celt) >= list.Count ? 1 : 0;
		}
	}
}