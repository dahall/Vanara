using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell
{
	/// <summary>The Shell's progress dialog.</summary>
	/// <seealso cref="System.ComponentModel.Component"/>
	public class ShellFileOperationDialog : Component
	{
		internal IOperationsProgressDialog iProgressDialog;

		private ShellItem currentItem;
		private long currentItems;
		private long currentProgress;
		private long currentSize;
		private ShellItem destItem;
		private OperationMode mode;
		private OperationType operation;
		private ShellItem sourceItem;
		private long totalItems = 100;
		private long totalProgress = 100;
		private long totalSize = 100;

		/// <summary>Initializes a new instance of the <see cref="ShellFileOperationDialog"/> class.</summary>
		public ShellFileOperationDialog()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="ShellFileOperationDialog"/> class.</summary>
		/// <param name="container">The container.</param>
		public ShellFileOperationDialog(IContainer container) : this()
		{
			container.Add(this);
		}

		/// <summary>Provides operation status flags for ShellFileOperationDialog.</summary>
		public enum DialogStatus
		{
			/// <summary>The dialog has not been started.</summary>
			NotStarted = 0,

			/// <summary>Operation is running, no user intervention.</summary>
			Running = PDOPSTATUS.PDOPS_RUNNING,

			/// <summary>Operation has been paused by the user.</summary>
			Paused = PDOPSTATUS.PDOPS_PAUSED,

			/// <summary>Operation has been canceled by the user - now go undo.</summary>
			Cancelled = PDOPSTATUS.PDOPS_CANCELLED,

			/// <summary>Operation has been stopped by the user - terminate completely.</summary>
			Stopped = PDOPSTATUS.PDOPS_STOPPED,

			/// <summary>Operation has gone as far as it can go without throwing error dialogs.</summary>
			Errors = PDOPSTATUS.PDOPS_ERRORS,
		}

		/// <summary>Flags used in Mode</summary>
		[Flags]
		public enum OperationMode
		{
			/// <summary>Use the default progress dialog operations mode.</summary>
			Default = PDMODE.PDM_DEFAULT,

			/// <summary>The operation is running.</summary>
			Running = PDMODE.PDM_RUN,

			/// <summary>The operation is gathering data before it begins, such as calculating the predicted operation time.</summary>
			Starting = PDMODE.PDM_PREFLIGHT,

			/// <summary>The operation is rolling back due to an Undo command from the user.</summary>
			Undoing = PDMODE.PDM_UNDOING,

			/// <summary>Error dialogs are blocking progress from continuing.</summary>
			BlockedByErrors = PDMODE.PDM_ERRORSBLOCKING,

			/// <summary>The length of the operation is indeterminate. Do not show a timer and display the progress bar in marquee mode.</summary>
			Indeterminate = PDMODE.PDM_INDETERMINATE,
		}

		/// <summary>Describes an action being performed that requires progress to be shown to the user using progress dialog.</summary>
		public enum OperationType
		{
			/// <summary>No action is being performed.</summary>
			None = SPACTION.SPACTION_NONE,

			/// <summary>Files are being moved.</summary>
			Moving = SPACTION.SPACTION_MOVING,

			/// <summary>Files are being copied.</summary>
			Copying = SPACTION.SPACTION_COPYING,

			/// <summary>Files are being deleted.</summary>
			Recycling = SPACTION.SPACTION_RECYCLING,

			/// <summary>A set of attributes are being applied to files.</summary>
			ApplyingAttributes = SPACTION.SPACTION_APPLYINGATTRIBS,

			/// <summary>A file is being downloaded from a remote source.</summary>
			Downloading = SPACTION.SPACTION_DOWNLOADING,

			/// <summary>An Internet search is being performed.</summary>
			SearchingInternet = SPACTION.SPACTION_SEARCHING_INTERNET,

			/// <summary>A calculation is being performed.</summary>
			Calculating = SPACTION.SPACTION_CALCULATING,

			/// <summary>A file is being uploaded to a remote source.</summary>
			Uploading = SPACTION.SPACTION_UPLOADING,

			/// <summary>A local search is being performed.</summary>
			SearchingFiles = SPACTION.SPACTION_SEARCHING_FILES,

			/// <summary>Windows Vista and later. A deletion is being performed.</summary>
			Deleting = SPACTION.SPACTION_DELETING,

			/// <summary>Windows Vista and later. A renaming action is being performed.</summary>
			Renaming = SPACTION.SPACTION_RENAMING,

			/// <summary>Windows Vista and later. A formatting action is being performed.</summary>
			Formatting = SPACTION.SPACTION_FORMATTING,

			/// <summary>Windows 7 and later. A copy or move action is being performed.</summary>
			CopyMoving = SPACTION.SPACTION_COPY_MOVING,
		}

		/// <summary>The operation can be undone in the dialog. (The Stop button becomes Undo)</summary>
		[DefaultValue(false)]
		public bool AllowUndo { get; set; }

		/// <summary>
		/// A ShellItem that represents the item currently being operated on by the operation engine. This property is only used in Windows
		/// 7 and later. In earlier versions, this property should be <see langword="null"/>
		/// </summary>
		public ShellItem CurrentItem { get => currentItem; set { currentItem = value; UpdateLocations(); } }

		/// <summary>A ShellItem that represents the target Shell item.</summary>
		public ShellItem Destination { get => destItem; set { destItem = value ?? throw new ArgumentNullException(nameof(Source)); UpdateLocations(); } }

		/// <summary>Gets the elapsed time.</summary>
		/// <value>The elapsed time, accurate to milliseconds.</value>
		public TimeSpan ElapsedTime
		{
			get
			{
				ulong t = 0;
				if (CanProcess)
					try { iProgressDialog.GetMilliseconds(out t, out _); } catch { }
				return TimeSpan.FromMilliseconds(t);
			}
		}

		/// <summary>Don't display the path of destination file in progress dialog</summary>
		[DefaultValue(false)]
		public bool HideDestinationPath { get; set; }

		/// <summary>Don't display the location line in the progress dialog</summary>
		[DefaultValue(false)]
		public bool HideLocations { get; set; }

		/// <summary>Don't display the path of source file in progress dialog</summary>
		[DefaultValue(false)]
		public bool HideSourcePath { get; set; }

		/// <summary>Gets or sets progress dialog operations mode.</summary>
		/// <value>The mode.</value>
		public OperationMode Mode
		{
			get => mode;
			set
			{
				if (mode == value) return;
				mode = value;
				if (CanProcess)
					iProgressDialog.SetMode((PDMODE)mode);
			}
		}

		/// <summary>Sets which progress dialog operation is occurring, and whether we are in pre-flight or undo mode.</summary>
		/// <value>Specifies operation. See <see cref="OperationType"/>.</value>
		public OperationType Operation
		{
			get => operation;
			set
			{
				if (operation == value) return;
				operation = value;
				if (CanProcess)
					iProgressDialog.SetOperation((SPACTION)operation);
			}
		}

		/// <summary>Total points, used for showing progress in points.</summary>
		[DefaultValue(100)]
		public long ProgressBarMaxValue
		{
			get => totalProgress;
			set { totalProgress = value; UpdateProgress(); }
		}

		/// <summary>Current points, used for showing progress in points.</summary>
		[DefaultValue(0)]
		public long ProgressBarValue
		{
			get => currentProgress;
			set { currentProgress = value; UpdateProgress(); }
		}

		/// <summary>Specifies total items, used for showing progress in items.</summary>
		[DefaultValue(100)]
		public long ProgressDialogItemsMaxValue
		{
			get => totalItems;
			set { totalItems = value; UpdateProgress(); }
		}

		/// <summary>Current items, used for showing progress in items.</summary>
		[DefaultValue(0)]
		public long ProgressDialogItemsValue
		{
			get => currentItems;
			set { currentItems = value; UpdateProgress(); }
		}

		/// <summary>Total size in bytes, used for showing progress in bytes.</summary>
		[DefaultValue(100)]
		public long ProgressDialogSizeMaxValue
		{
			get => totalSize;
			set { totalSize = value; UpdateProgress(); }
		}

		/// <summary>Current size in bytes, used for showing progress in bytes.</summary>
		[DefaultValue(0)]
		public long ProgressDialogSizeValue
		{
			get => currentSize;
			set { currentSize = value; UpdateProgress(); }
		}

		/// <summary>Gets the remaining time.</summary>
		/// <value>The remaining time, accurate to milliseconds.</value>
		public TimeSpan RemainingTime
		{
			get
			{
				ulong t = 0;
				if (CanProcess)
					try { iProgressDialog.GetMilliseconds(out _, out t); } catch { }
				return TimeSpan.FromMilliseconds(t);
			}
		}

		/// <summary>Add a pause button (operation can be paused)</summary>
		[DefaultValue(false)]
		public bool ShowPauseButton { get; set; }

		/// <summary>A ShellItem that represents the source Shell item.</summary>
		public ShellItem Source { get => sourceItem; set { sourceItem = value ?? throw new ArgumentNullException(nameof(Source)); UpdateLocations(); } }

		/// <summary>Gets operation status for progress dialog.</summary>
		/// <value>The operation status. See <see cref="DialogStatus"/>.</value>
		public DialogStatus Status => (DialogStatus)(CanProcess ? iProgressDialog.GetOperationStatus() : 0);

		private bool CanProcess => iProgressDialog != null;

		private OPPROGDLGF DialogFlags => (ShowPauseButton ? OPPROGDLGF.OPPROGDLG_ENABLEPAUSE : 0) |
							(AllowUndo ? OPPROGDLGF.OPPROGDLG_ALLOWUNDO : 0) |
							(HideSourcePath ? OPPROGDLGF.OPPROGDLG_DONTDISPLAYSOURCEPATH : 0) |
							(HideDestinationPath ? OPPROGDLGF.OPPROGDLG_DONTDISPLAYDESTPATH : 0) |
							(HideLocations ? OPPROGDLGF.OPPROGDLG_DONTDISPLAYLOCATIONS : 0);

		/// <summary>Pauses progress dialog timer.</summary>
		public void PauseTimer() { if (CanProcess) iProgressDialog.PauseTimer(); }

		/// <summary>Resets progress dialog timer to 0.</summary>
		public void ResetTimer() { if (CanProcess) iProgressDialog.ResetTimer(); }

		/// <summary>Resumes progress dialog timer.</summary>
		public void ResumeTimer() { if (CanProcess) iProgressDialog.ResumeTimer(); }

		/// <summary>Starts the specified progress dialog.</summary>
		/// <param name="owner">
		/// A value that represents the window of the owner window for the common dialog box. This value can be <see langword="null"/>.
		/// </param>
		public void Start(IWin32Window owner)
		{
			if (owner is null) owner = Form.ActiveForm;
			iProgressDialog = new IOperationsProgressDialog();
			iProgressDialog.StartProgressDialog(owner?.Handle ?? default, DialogFlags);
			iProgressDialog.SetOperation((SPACTION)operation);
			iProgressDialog.SetMode((PDMODE)mode);
			UpdateLocations();
			UpdateProgress();
		}

		/// <summary>Stops current progress dialog.</summary>
		public void Stop()
		{
			if (!CanProcess)
				return;

			iProgressDialog.StopProgressDialog();
			Thread.Sleep(500);
			iProgressDialog = null;
		}

		/// <summary>
		/// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component"/> and optionally releases the managed resources.
		/// </summary>
		/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			Stop();
			base.Dispose(disposing);
		}

		private void UpdateLocations()
		{
			if (CanProcess)
				iProgressDialog.UpdateLocations(sourceItem.IShellItem, destItem.IShellItem, currentItem?.IShellItem);
		}

		private void UpdateProgress()
		{
			if (CanProcess)
				iProgressDialog.UpdateProgress((ulong)currentProgress, (ulong)totalProgress, (ulong)currentSize, (ulong)totalSize, (ulong)currentItems, (ulong)totalItems);
		}
	}
}