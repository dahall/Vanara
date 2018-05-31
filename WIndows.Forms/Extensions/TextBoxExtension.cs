using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.Extensions
{
	/// <summary>Extension methods for <see cref="TextBox"/>.</summary>
	public static partial class TextBoxExtension
	{
		/// <summary>Sets the textual cue, or tip, that is displayed by the edit control to prompt the user for information.</summary>
		/// <param name="textBox">The text box.</param>
		/// <param name="cueBannerText">A string that contains the text to display as the textual cue.</param>
		/// <param name="retainOnFocus">if set to <c>true</c> the cue banner should show even when the edit control has focus.</param>
		/// <exception cref="PlatformNotSupportedException">Must be Windows Vista or later.</exception>
		public static void SetCueBanner(this TextBox textBox, string cueBannerText, bool retainOnFocus = false)
		{
			if (Environment.OSVersion.Version.Major >= 6)
			{
				SendMessage(new HandleRef(textBox, textBox.Handle), (uint)EditMessage.EM_SETCUEBANNER, new IntPtr(retainOnFocus ? 1 : 0), cueBannerText);
				textBox.Invalidate();
			}
			else
				throw new PlatformNotSupportedException();
		}

		/// <summary>Sets a custom automatic complete list.</summary>
		/// <param name="textBox">The text box.</param>
		/// <param name="items">The autocomplete strings.</param>
		/// <param name="options">The autocomplete options.</param>
		public static void SetCustomAutoCompleteList(this TextBox textBox, IList<string> items, AUTOCOMPLETEOPTIONS options = AUTOCOMPLETEOPTIONS.ACO_AUTOSUGGEST)
		{
			var ac = new IAutoComplete2();
			ac.Init(new HandleRef(textBox, textBox.Handle), new ComEnumStringImpl(items), null, null);
			ac.SetOptions(options);
			Marshal.ReleaseComObject(ac);
		}

		/// <summary>Sets the tab stops in a multiline edit control. When text is copied to the control, any tab character in the text causes space to be generated up to the next tab stop.</summary>
		/// <param name="textBox">The text box.</param>
		/// <param name="tabs">An array of unsigned integers specifying the tab stops, in dialog template units. If this parameter is not supplied, default tab stops are set at every 32 dialog template units. If a single value is provided, this value is the distance between all tab stops, in dialog template units. If two or more values are provided, each value represents a tab stop in dialog template units.</param>
		public static void SetTabStops(this TextBox textBox, params uint[] tabs)
		{
			if (tabs == null) tabs = new uint[0];
			using (var ptr = SafeCoTaskMemHandle.CreateFromList(tabs))
				SendMessage(new HandleRef(textBox, textBox.Handle), (uint)EditMessage.EM_SETTABSTOPS, (IntPtr)tabs.Length, (IntPtr)ptr);
			textBox.Invalidate();
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