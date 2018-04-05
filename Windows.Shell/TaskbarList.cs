using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.User32_Gdi;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell
{
	/// <summary>Methods that control the Windows taskbar. It allows you to dynamically add, remove, and activate items on the taskbar. This wraps all of the ITaskbarListX interfaces.</summary>
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

		/// <summary>Gets the taskbar button created MSG identifier.</summary>
		/// <value>The taskbar button created MSG identifier.</value>
		public static uint TaskbarButtonCreatedWinMsgId => RegisterWindowMessage("TaskbarButtonCreated");

		/// <summary>Activates an item on the taskbar. The window is not actually activated; the window's item on the taskbar is merely displayed as active.</summary>
		/// <param name="parent">The window on the taskbar to be displayed as active.</param>
		/// <exception cref="ArgumentNullException">parent</exception>
		public static void ActivateTaskbarItem(IWin32Window parent)
		{
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			taskbar2?.ActivateTab(parent.Handle);
		}

		/// <summary>Marks a window as full-screen.</summary>
		/// <param name="parent">The window to be marked.</param>
		/// <param name="fullscreen">A Boolean value marking the desired full-screen status of the window.</param>
		/// <exception cref="ArgumentNullException">parent</exception>
		public static void MarkFullscreenWindow(IWin32Window parent, bool fullscreen)
		{
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			taskbar2?.MarkFullscreenWindow(parent.Handle, fullscreen);
		}

		/// <summary>Marks a taskbar item as active but does not visually activate it.</summary>
		/// <param name="parent">The window to be marked as active.</param>
		/// <exception cref="ArgumentNullException">parent</exception>
		public static void SetActiveAlt(IWin32Window parent)
		{
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			taskbar2?.SetActiveAlt(parent.Handle);
		}

		// Thumbnail Toolbars ============================================

		/// <summary>Adds a thumbnail toolbar with a specified set of buttons to the thumbnail image of a window in a taskbar button flyout.</summary>
		/// <param name="parent">The window whose thumbnail representation will receive the toolbar. This window must belong to the calling process.</param>
		/// <param name="buttons">
		/// An array of THUMBBUTTON structures. Each THUMBBUTTON defines an individual button to be added to the toolbar. Buttons cannot be added or deleted
		/// later, so this must be the full defined set. Buttons also cannot be reordered, so their order in the array, which is the order in which they are
		/// displayed left to right, will be their permanent order.
		/// </param>
		public static void ThumbBarAddButtons(IWin32Window parent, THUMBBUTTON[] buttons)
		{
			Validate7OrLater();
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			if (buttons == null)
				throw new ArgumentNullException(nameof(buttons));
			taskbar4?.ThumbBarAddButtons(parent.Handle, (uint)buttons.Length, buttons);
		}

		/// <summary>Specifies an image list that contains button images for a toolbar embedded in a thumbnail image of a window in a taskbar button flyout.</summary>
		/// <param name="parent">The window whose thumbnail representation contains the toolbar to be updated. This window must belong to the calling process.</param>
		/// <param name="imageList">The image list that contains all button images to be used in the toolbar.</param>
		public static void ThumbBarSetImageList(IWin32Window parent, ImageList imageList)
		{
			Validate7OrLater();
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			if (imageList == null)
				throw new ArgumentNullException(nameof(imageList));
			taskbar4?.ThumbBarSetImageList(parent.Handle, imageList.Handle);
		}

		/// <summary>
		/// Shows, enables, disables, or hides buttons in a thumbnail toolbar as required by the window's current state. A thumbnail toolbar is a toolbar
		/// embedded in a thumbnail image of a window in a taskbar button flyout.
		/// </summary>
		/// <param name="parent">The window whose thumbnail representation contains the toolbar.</param>
		/// <param name="buttons">
		/// An array of THUMBBUTTON structures. Each THUMBBUTTON defines an individual button. If the button already exists (the iId value is already defined),
		/// then that existing button is updated with the information provided in the structure.
		/// </param>
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

		/// <summary>Applies an overlay to a taskbar button to indicate application status or a notification to the user.</summary>
		/// <param name="parent">
		/// The window whose associated taskbar button receives the overlay. This window must belong to a calling process associated with the button's application.
		/// </param>
		/// <param name="icon">
		/// The icon to use as the overlay. This should be a small icon, measuring 16x16 pixels at 96 dpi. If an overlay icon is already applied to the taskbar
		/// button, that existing overlay is replaced.
		/// <para>
		/// This value can be <see langword="null"/>. How a <see langword="null"/> value is handled depends on whether the taskbar button represents a single
		/// window or a group of windows.
		/// </para>
		/// <list type="bullet">
		/// <item><term>If the taskbar button represents a single window, the overlay icon is removed from the display.</term></item>
		/// <item><term>If the taskbar button represents a group of windows and a previous overlay is still available (received earlier than the current overlay, but not yet
		/// freed by a NULL value), then that previous overlay is displayed in place of the current overlay.</term></item>
		/// </list>
		/// </param>
		/// <param name="description">A string that provides an alt text version of the information conveyed by the overlay, for accessibility purposes.</param>
		public static void SetOverlayIcon(IWin32Window parent, Icon icon, string description)
		{
			Validate7OrLater();
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			taskbar4?.SetOverlayIcon(parent.Handle, icon == null ? IntPtr.Zero : icon.Handle, description);
		}

		// Progress Bars ============================================

		/// <summary>Sets the type and state of the progress indicator displayed on a taskbar button.</summary>
		/// <param name="parent">
		/// The window in which the progress of an operation is being shown. This window's associated taskbar button will display the progress bar.
		/// </param>
		/// <param name="status">The current state of the progress button. Specify only one of the enum values.</param>
		public static void SetProgressState(IWin32Window parent, TBPFLAG status)
		{
			Validate7OrLater();
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			taskbar4?.SetProgressState(parent.Handle, status);
		}

		/// <summary>Displays or updates a progress bar hosted in a taskbar button to show the specific percentage completed of the full operation.</summary>
		/// <param name="parent">The window whose associated taskbar button is being used as a progress indicator.</param>
		/// <param name="completed">
		/// An application-defined value that indicates the proportion of the operation that has been completed at the time the method is called.
		/// </param>
		/// <param name="total">An application-defined value that specifies the value ullCompleted will have when the operation is complete.</param>
		public static void SetProgressValue(IWin32Window parent, ulong completed, ulong total)
		{
			Validate7OrLater();
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			taskbar4?.SetProgressValue(parent.Handle, completed, total);
		}

		// Thumbnails ============================================

		/// <summary>Informs the taskbar that a new tab or document thumbnail has been provided for display in an application's taskbar group flyout.</summary>
		/// <param name="parent">The tab or document window. This value is required and cannot be NULL.</param>
		/// <param name="childWindow">
		/// The application's main window. This value tells the taskbar which application's preview group to attach the new thumbnail to. This value is required
		/// and cannot be NULL.
		/// </param>
		/// <remarks>
		/// By itself, registering a tab thumbnail alone will not result in its being displayed. You must also call SetTabOrder to instruct the group where to
		/// display it.
		/// </remarks>
		public static void RegisterTab(IWin32Window parent, IWin32Window childWindow)
		{
			Validate7OrLater();
			if (childWindow == null)
				throw new ArgumentNullException(nameof(childWindow));
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			taskbar4?.RegisterTab(childWindow.Handle, parent.Handle);
		}

		/// <summary>Informs the taskbar that a tab or document window has been made the active window.</summary>
		/// <param name="parent">The active tab window. This window must already be registered through RegisterTab. This value can be NULL if no tab is active.</param>
		/// <param name="childWindow">
		/// The application's main window. This value tells the taskbar which group the thumbnail is a member of. This value is required and cannot be NULL.
		/// </param>
		public static void SetTabActive(IWin32Window parent, IWin32Window childWindow)
		{
			Validate7OrLater();
			if (childWindow == null)
				throw new ArgumentNullException(nameof(childWindow));
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			taskbar4?.SetTabActive(childWindow.Handle, parent.Handle, 0);
		}

		/// <summary>
		/// Inserts a new thumbnail into a tabbed-document interface (TDI) or multiple-document interface (MDI) application's group flyout or moves an existing
		/// thumbnail to a new position in the application's group.
		/// </summary>
		/// <param name="childWindow">
		/// The tab window whose thumbnail is being placed. This value is required, must already be registered through RegisterTab, and cannot be NULL.
		/// </param>
		/// <param name="insertBeforeChildWindow">
		/// The tab window whose thumbnail that hwndTab is inserted to the left of. This window must already be registered through RegisterTab. If this value is
		/// NULL, the new thumbnail is added to the end of the list.
		/// </param>
		/// <remarks>This method must be called for the thumbnail to be shown in the group. Call it after you have called RegisterTab.</remarks>
		public static void SetTabOrder(IWin32Window childWindow, IWin32Window insertBeforeChildWindow = null)
		{
			Validate7OrLater();
			if (childWindow == null)
				throw new ArgumentNullException(nameof(childWindow));
			taskbar4?.SetTabOrder(childWindow.Handle,
				insertBeforeChildWindow?.Handle ?? IntPtr.Zero);
		}

		/// <summary>
		/// Allows a tab to specify whether the main application frame window or the tab window should be used as a thumbnail or in the peek feature under
		/// certain circumstances.
		/// </summary>
		/// <param name="childWindow">The tab window that is to have properties set. This windows must already be registered through RegisterTab.</param>
		/// <param name="properties">One or more members of the STPFLAG enumeration that specify the displayed thumbnail and peek image source of the tab thumbnail.</param>
		public static void SetTabProperties(IWin32Window childWindow, STPFLAG properties)
		{
			Validate7OrLater();
			if (childWindow == null)
				throw new ArgumentNullException(nameof(childWindow));
			taskbar4?.SetTabProperties(childWindow.Handle, properties);
		}

		/// <summary>Removes a thumbnail from an application's preview group when that tab or document is closed in the application.</summary>
		/// <param name="childWindow">
		/// The tab window whose thumbnail is being removed. This is the same value with which the thumbnail was registered as part the group
		/// through RegisterTab. This value is required and cannot be NULL.
		/// </param>
		public static void UnregisterTab(IWin32Window childWindow)
		{
			Validate7OrLater();
			if (childWindow == null)
				throw new ArgumentNullException(nameof(childWindow));
			taskbar4?.UnregisterTab(childWindow.Handle);
		}

		/// <summary>Selects a portion of a window's client area to display as that window's thumbnail in the taskbar.</summary>
		/// <param name="parent">The window represented in the taskbar.</param>
		/// <param name="windowClipRect">
		/// A <see cref="Rectangle"/> that specifies a selection within the window's client area, relative to the upper-left corner of that client area. To clear
		/// a clip that is already in place and return to the default display of the thumbnail, set this parameter to NULL.
		/// </param>
		public static void SetThumbnailClip(IWin32Window parent, Rectangle windowClipRect)
		{
			Validate7OrLater();
			if (parent == null)
				throw new ArgumentNullException(nameof(parent));
			RECT cr = windowClipRect;
			taskbar4?.SetThumbnailClip(parent.Handle, ref cr);
		}

		/// <summary>
		/// Specifies or updates the text of the tooltip that is displayed when the mouse pointer rests on an individual preview thumbnail in a taskbar button flyout.
		/// </summary>
		/// <param name="parent">The window whose thumbnail displays the tooltip. This window must belong to the calling process.</param>
		/// <param name="tip">The text to be displayed in the tooltip. This value can be NULL, in which case the title of the window is used as the tooltip.</param>
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