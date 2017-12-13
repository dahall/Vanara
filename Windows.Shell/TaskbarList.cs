using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell
{
	public static class TaskbarList
	{
		static readonly Finalizer finalizer = new Finalizer();
		static ITaskbarList2 taskbar2;
		static ITaskbarList4 taskbar4;

		static TaskbarList()
		{
			var tb = new CTaskbarList();
			taskbar2 = (ITaskbarList2)tb;
			try
			{
				taskbar4 = (ITaskbarList4)tb;
			}
			catch
			{
				taskbar4 = null;
			}
			taskbar2?.HrInit();
		}

		sealed class Finalizer
		{
			~Finalizer()
			{
				if (taskbar2 != null)
					Marshal.ReleaseComObject(taskbar2);
				if (taskbar4 != null)
					Marshal.ReleaseComObject(taskbar4);
			}
		}

		public static uint TaskbarButtonCreatedWinMsgId => RegisterWindowMessage("TaskbarButtonCreated");

		public static void ActivateTaskbarItem(IWin32Window parent)
		{
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			taskbar2?.ActivateTab(parent.Handle);
		}

		public static void MarkFullscreenWindow(IWin32Window parent, bool fullscreen)
		{
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			taskbar2?.MarkFullscreenWindow(parent.Handle, fullscreen);
		}

		public static void SetActiveAlt(IWin32Window parent)
		{
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			taskbar2?.SetActiveAlt(parent.Handle);
		}

		// Thumbnail Toolbars ============================================

		public static void ThumbBarAddButtons(IWin32Window parent, THUMBBUTTON[] buttons)
		{
			Validate7OrLater();
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			if (buttons == null)
				throw new ArgumentNullException(nameof(buttons));
			taskbar4?.ThumbBarAddButtons(parent.Handle, (uint)buttons.Length, buttons);
		}

		public static void ThumbBarSetImageList(IWin32Window parent, ImageList imageList)
		{
			Validate7OrLater();
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			if (imageList == null)
				throw new ArgumentNullException(nameof(imageList));
			taskbar4?.ThumbBarSetImageList(parent.Handle, imageList.Handle);
		}

		public static void ThumbBarUpdateButtons(IWin32Window parent, THUMBBUTTON[] buttons)
		{
			Validate7OrLater();
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			if (buttons == null)
				throw new ArgumentNullException(nameof(buttons));
			taskbar4?.ThumbBarUpdateButtons(parent.Handle, (uint)buttons.Length, buttons);
		}

		// Overlays ============================================

		public static void SetOverlayIcon(IWin32Window parent, Icon icon, string description)
		{
			Validate7OrLater();
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			taskbar4?.SetOverlayIcon(parent.Handle, icon == null ? IntPtr.Zero : icon.Handle, description);
		}

		// Progress Bars ============================================

		public static void SetProgressState(IWin32Window parent, TBPFLAG status)
		{
			Validate7OrLater();
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			taskbar4?.SetProgressState(parent.Handle, status);
		}

		public static void SetProgressValue(IWin32Window parent, ulong completed, ulong total)
		{
			Validate7OrLater();
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			taskbar4?.SetProgressValue(parent.Handle, completed, total);
		}

		// Thumbnails ============================================

		public static void RegisterTab(IWin32Window parent, IWin32Window childWindow)
		{
			Validate7OrLater();
			if (childWindow == null)
				throw new ArgumentNullException(nameof(childWindow));
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			taskbar4?.RegisterTab(childWindow.Handle, parent.Handle);
		}

		public static void SetTabActive(IWin32Window parent, IWin32Window childWindow)
		{
			Validate7OrLater();
			if (childWindow == null)
				throw new ArgumentNullException(nameof(childWindow));
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			taskbar4?.SetTabActive(childWindow.Handle, parent.Handle, 0);
		}

		public static void SetTabOrder(IWin32Window childWindow, IWin32Window insertBeforeChildWindow = null)
		{
			Validate7OrLater();
			if (childWindow == null)
				throw new ArgumentNullException(nameof(childWindow));
			taskbar4?.SetTabOrder(childWindow.Handle,
				insertBeforeChildWindow?.Handle ?? IntPtr.Zero);
		}

		public static void SetTabProperties(IWin32Window childWindow, STPFLAG properties)
		{
			Validate7OrLater();
			if (childWindow == null)
				throw new ArgumentNullException(nameof(childWindow));
			taskbar4?.SetTabProperties(childWindow.Handle, properties);
		}

		public static void UnregisterTab(IWin32Window childWindow)
		{
			Validate7OrLater();
			if (childWindow == null)
				throw new ArgumentNullException(nameof(childWindow));
			taskbar4?.UnregisterTab(childWindow.Handle);
		}

		public static void SetThumbnailClip(IWin32Window parent, Rectangle windowClipRect)
		{
			Validate7OrLater();
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			RECT cr = windowClipRect;
			taskbar4?.SetThumbnailClip(parent.Handle, ref cr);
		}

		public static void SetThumbnailTooltip(IWin32Window parent, string tip)
		{
			Validate7OrLater();
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			taskbar4?.SetThumbnailTooltip(parent.Handle, tip);
		}

		static readonly Version Win7Ver = new Version(6, 1);

		private static void Validate7OrLater()
		{
			if (Environment.OSVersion.Version < Win7Ver)
				throw new InvalidOperationException("This method is only available on Windows 7 and later.");
		}
	}
}