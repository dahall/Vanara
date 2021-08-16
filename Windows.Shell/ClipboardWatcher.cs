using System;
using System.ComponentModel;
using Vanara.PInvoke;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Shell
{
	/// <summary>Component that raises an event when the contents of the Windows Clipboard change.</summary>
	/// <seealso cref="System.ComponentModel.Component"/>
	/// <seealso cref="System.ComponentModel.ISupportInitialize"/>
	public class ClipboardWatcher : Component, ISupportInitialize
	{
		private readonly WatcherNativeWindow hPump;
		private bool enabled;
		private bool initializing;

		/// <summary>Initializes a new instance of the <see cref="ClipboardWatcher"/> class.</summary>
		public ClipboardWatcher() => hPump = new WatcherNativeWindow(this);

		/// <summary>Occurs when the clipboard is changed.</summary>
		[Category("Behavior"), Description("Occurs when the clipboard is changed.")]
		public event EventHandler Changed;

		/// <summary>Gets or sets a value indicating whether the component is enabled.</summary>
		/// <value><see langword="true"/> if the component is enabled; otherwise, <see langword="false"/>. The default is <see langword="false"/>.</value>
		[DefaultValue(false), Category("Behavior"), Description("Indicates whether the component is enabled.")]
		public bool EnableRaisingEvents
		{
			get => enabled;
			set
			{
				if (value == enabled) return;
				enabled = value;
				if (IsSuspended) return;
				if (enabled)
					StartWatching();
				else
					StopWatching();
			}
		}

		private bool IsSuspended => initializing || DesignMode;

		/// <summary>
		/// Begins the initialization of a <see cref="ClipboardWatcher"/> used on a form or used by another component. The initialization
		/// occurs at run time.
		/// </summary>
		/// <remarks>
		/// The Visual Studio design environment uses this method to start the initialization of a component used on a form or used by
		/// another component. The <see cref="EndInit"/> method ends the initialization. Using the <see cref="BeginInit"/> and <see
		/// cref="EndInit"/> methods prevents the control from being used before it is fully initialized.
		/// </remarks>
		public void BeginInit()
		{
			var oldEnabled = enabled;
			StopWatching();
			enabled = oldEnabled;
			initializing = true;
		}

		/// <summary>
		/// Ends the initialization of a <see cref="ClipboardWatcher"/> used on a form or used by another component. The initialization
		/// occurs at run time.
		/// </summary>
		/// <remarks>
		/// The Visual Studio design environment uses this method to start the initialization of a component used on a form or used by
		/// another component. The <see cref="EndInit"/> method ends the initialization. Using the <see cref="BeginInit"/> and <see
		/// cref="EndInit"/> methods prevents the control from being used before it is fully initialized.
		/// </remarks>
		public void EndInit()
		{
			initializing = false;
			if (enabled)
				StartWatching();
		}

		/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
		/// <param name="disposing">
		/// <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
		/// </param>
		protected override void Dispose(bool disposing)
		{
			try
			{
				StopWatching();
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		/// <summary>Raises the <see cref="Changed"/> event.</summary>
		protected virtual void OnChanged() => Changed?.Invoke(this, EventArgs.Empty);

		private void Restart()
		{
			if (IsSuspended || !enabled) return;
			StopWatching();
			StartWatching();
		}

		private void StartWatching()
		{
			enabled = true;
			if (IsSuspended) return;

			Win32Error.ThrowLastErrorIfFalse(AddClipboardFormatListener(hPump.MessageWindowHandle));
		}

		private void StopWatching()
		{
			enabled = false;
			if (IsSuspended) return;

			Win32Error.ThrowLastErrorIfFalse(RemoveClipboardFormatListener(hPump.MessageWindowHandle));
		}

		private class WatcherNativeWindow : SystemEventHandler
		{
			private readonly ClipboardWatcher p;

			public WatcherNativeWindow(ClipboardWatcher parent) : base() => p = parent;

			protected override bool MessageFilter(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam, out IntPtr lReturn)
			{
				lReturn = default;
				if (msg == (uint)WindowMessage.WM_CLIPBOARDUPDATE && p.enabled && !p.IsSuspended)
				{
					p.OnChanged();
					return true;
				}
				return false;
			}
		}
	}
}