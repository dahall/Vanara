using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodePlexArchiveManager
{
	/// <summary>
	/// Multi-level, auto-sizing, progress dialog supporting asyncronous tasks. The background activities are provided as asyncronous methods who have a
	/// <see cref="CancellationToken"/> and an <see cref="IProgress{ProgresEventArgs}"/> instance passed as parameters. The method uses the
	/// <see cref="CancellationToken"/> instance to determine if the user has pressed the "Cancel" button and the
	/// <see cref="IProgress{ProgresEventArgs}.Report"/> method to report progress.
	/// </summary>
	/// <example lang="cs">
	/// public async Task ShowProgress()
	/// {
	///    var progressDialog = new ProgressDialog { Title = "Progress" };
	///    await progressDialog.ShowDialog(null, (cancellationToken, progressReporter) => SomeTask(listOfItemsToProcess, cancellationToken, progressReporter));
	/// }
	/// 
	/// private Task SomeTask(List&lt;Item&gt; items, CancellationToken token, IProgress&lt;ProgresEventArgs&gt; reporter)
	/// {
	///    return Task.Run(() => {
	///       for (var i = 0; i &lt; items.Count; i++)
	///       {
	///          if (token.IsCancellationRequested) break;
	///          SomeLongJob(items[i]);
	///          reporter.Report(new ProgresEventArgs(items[i].ToString(), ProgressDialog.Percent(i, items.Count)));
	///       }
	///    });
	/// }
	/// </example>
	public class ProgressDialog : CommonDialog
	{
		private const string defaultCancelText = "&Cancel";
		private readonly InternalProgressDialog progressDlg;
		private readonly Progress<ProgressEventArgs> update;
		private CancellationTokenSource cancelToken;
		private IWin32Window parent;
		private bool running;

		/// <summary>Initializes a new instance of the <see cref="ProgressDialog"/> class.</summary>
		public ProgressDialog()
		{
			progressDlg = new InternalProgressDialog();
			progressDlg.Cancelled += (o, a) => cancelToken?.Cancel();
			update = new Progress<ProgressEventArgs>(UpdateProgress);
		}

		/// <summary>Background task to run when calling <see cref="CommonDialog.ShowDialog()"/> without any specified action.</summary>
		/// <value>The background task.</value>
		[Browsable(false)]
		public Func<CancellationToken, IProgress<ProgressEventArgs>, Task> BackgroundTask { get; set; }

		/// <summary>Gets or sets the cancel button text.</summary>
		/// <value>The cancel button text.</value>
		[DefaultValue(defaultCancelText), Category("Appearance"), Description("The text on the Cancel button.")]
		[Localizable(true), Bindable(true)]
		public string CancelButtonText
		{
			get => progressDlg.cancelBtn.Text;
			set => progressDlg.cancelBtn.Text = value;
		}

		/// <summary>Gets or sets the progress dialog box title.</summary>
		/// <value>The progress dialog box title. The default value is an empty string ("").</value>
		[DefaultValue(""), Category("Window"), Description("The progress dialog box title.")]
		[Localizable(true), Bindable(true)]
		public string Title
		{
			get => progressDlg.Text;
			set => progressDlg.Text = value;
		}

		/// <summary>Builds an integer percent value.</summary>
		/// <param name="idx">The index of the item being processed.</param>
		/// <param name="count">The total count of the items being processed</param>
		/// <param name="start">A value with which to pad the starting value.</param>
		/// <returns>The percentage of the way through the count.</returns>
		public static int Percent(int idx, int count, int start = 0) => start + (int)Math.Floor(idx * (float)(100 - start) / count);

		/// <summary>When overridden in a derived class, resets the properties of a common dialog box to their default values.</summary>
		public override void Reset()
		{
			if (cancelToken != null && !cancelToken.IsCancellationRequested)
				cancelToken.Cancel();
			if (progressDlg.Visible)
				progressDlg.Hide();
			cancelToken = null;
			parent = null;
			running = false;
		}

		/// <summary>Shows the progress dialog as a modal dialog box with the specified owner while executing the supplied function.</summary>
		/// <param name="owner">Any object that implements <see cref="IWin32Window"/> that represents the top-level window that will own the model dialog box.</param>
		/// <param name="function">The function whose execution is run in the background of the progress dialog.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		/// <exception cref="ArgumentNullException">The <paramref name="function"/> value cannot be <c>null</c>.</exception>
		/// <exception cref="InvalidOperationException">Another instance is already running.</exception>
		public async Task ShowDialog(IWin32Window owner, Func<CancellationToken, IProgress<ProgressEventArgs>, Task> function)
		{
			if (function == null) throw new ArgumentNullException();
			if (running) throw new InvalidOperationException("Another instance is already running.");
			try
			{
				parent = owner;
				cancelToken = new CancellationTokenSource();
				running = true;
				await function(cancelToken.Token, update);
			}
			finally
			{
				Reset();
			}
		}

		/// <summary>Shows the progress dialog as a modal dialog box with the specified owner while executing the supplied function.</summary>
		/// <typeparam name="T">The type of the value returned by <paramref name="function"/>.</typeparam>
		/// <param name="owner">Any object that implements <see cref="IWin32Window"/> that represents the top-level window that will own the model dialog box.</param>
		/// <param name="function">The function whose execution is run in the background of the progress dialog.</param>
		/// <returns>The task object representing the asynchronous operation. The <see cref="Task{TResult}.Result"/> property on the task object returns the value returned by <paramref name="function"/>.</returns>
		/// <exception cref="ArgumentNullException">The <paramref name="function"/> value cannot be <c>null</c>.</exception>
		/// <exception cref="InvalidOperationException">Another instance is already running.</exception>
		public async Task<T> ShowDialog<T>(IWin32Window owner, Func<CancellationToken, IProgress<ProgressEventArgs>, Task<T>> function)
		{
			if (function == null) throw new ArgumentNullException();
			if (running) throw new InvalidOperationException("Another instance is already running.");
			try
			{
				parent = owner;
				cancelToken = new CancellationTokenSource();
				running = true;
				return await function(cancelToken.Token, update);
			}
			finally
			{
				Reset();
			}
		}

		/// <summary>When overridden in a derived class, specifies a common dialog box.</summary>
		/// <param name="hwndOwner">A value that represents the window handle of the owner window for the common dialog box.</param>
		/// <returns><see langword="true" /> if the dialog box was successfully run; otherwise, <see langword="false" />.</returns>
		protected override bool RunDialog(IntPtr hwndOwner)
		{
			try
			{
				ShowDialog(NativeWindow.FromHandle(hwndOwner), BackgroundTask).Wait();
				return true;
			}
			catch
			{
				return false;
			}
		}

		private void UpdateProgress(ProgressEventArgs p)
		{
			if (p.PercentComplete == 100)
			{
				if (progressDlg.Visible)
					progressDlg.Hide();
			}
			else
			{
				if (!progressDlg.Visible)
					progressDlg.ShowDialog(parent);
				progressDlg.PercentComplete = p.PercentComplete;
				progressDlg.StatusText = p.StatusText;
				progressDlg.MacroPercentComplete = p.MacroPercentComplete;
				progressDlg.MacroStatusText = p.MacroStatusText;
			}
		}

		internal class InternalProgressDialog : Form
		{
			internal Button cancelBtn;
			private TableLayoutPanel commandPanel;
			private TableLayoutPanel contentPanel;
			private Panel dividerPanel;
			private ProgressBar macroProgressBar;
			private Label macroStatusLabel;
			private ProgressBar progressBar;
			private Label statusLabel;

			/// <summary>Initializes a new instance of the <see cref="InternalProgressDialog"/> class.</summary>
			public InternalProgressDialog()
			{
				InitializeComponent();
				MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
			}

			/// <summary>Occurs when the Cancel button is pressed.</summary>
			public event CancelEventHandler Cancelled;

			/// <summary>
			/// Gets or sets the value of the macro progress bar. Valid values are 0 to 100. If this value is 0 and <see cref="MacroStatusText"/> is null or
			/// empty, the macro items will be hidden.
			/// </summary>
			/// <value>The macro percent complete.</value>
			[DefaultValue(0)]
			public int MacroPercentComplete
			{
				get => macroProgressBar.Value;
				set
				{
					macroProgressBar.Value = value;
					MacroItemsVisible = macroProgressBar.Value != 0 && !string.IsNullOrEmpty(macroStatusLabel.Text);
				}
			}

			/// <summary>
			/// Gets or sets the status text displayed above the macro progress bar. If this value is null or empty and <see cref="MacroPercentComplete"/> is 0,
			/// the macro items will be hidden.
			/// </summary>
			/// <value>The macro status text.</value>
			[DefaultValue("")]
			public string MacroStatusText
			{
				get => macroStatusLabel.Text;
				set
				{
					macroStatusLabel.Text = value;
					MacroItemsVisible = macroProgressBar.Value != 0 && !string.IsNullOrEmpty(macroStatusLabel.Text);
				}
			}

			/// <summary>Gets or sets the value of the standard progress bar. Valid values are 0 to 100.</summary>
			/// <value>The percent complete.</value>
			[DefaultValue(0)]
			public int PercentComplete
			{
				get => progressBar.Value;
				set => progressBar.Value = value;
			}

			/// <summary>Gets or sets the status text displayed above the standard progress bar.</summary>
			/// <value>The status text.</value>
			[DefaultValue("")]
			public string StatusText
			{
				get => statusLabel.Text;
				set => statusLabel.Text = value;
			}

			/// <summary>Gets or sets a value indicating whether [task visible].</summary>
			/// <value><c>true</c> if [task visible]; otherwise, <c>false</c>.</value>
			private bool MacroItemsVisible
			{
				get => macroProgressBar.Visible;
				set => macroProgressBar.Visible = macroStatusLabel.Visible = value;
			}

			/// <summary>Raises the <see cref="E:Cancelled"/> event.</summary>
			/// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
			protected virtual void OnCancelled(CancelEventArgs e)
			{
				Cancelled?.Invoke(this, e);
			}

			/// <summary>Raises the <see cref="E:System.Windows.Forms.Form.FormClosed"/> event.</summary>
			/// <param name="e">A <see cref="T:System.Windows.Forms.FormClosedEventArgs"/> that contains the event data.</param>
			protected override void OnFormClosed(FormClosedEventArgs e)
			{
				base.OnFormClosed(e);
				MacroItemsVisible = false;
			}

			/// <summary>Handles the Click event of the cancelBtn control.</summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
			private void CancelBtn_Click(object sender, EventArgs e)
			{
				OnCancelled(new CancelEventArgs(true));
			}

			private void InitializeComponent()
			{
				progressBar = new ProgressBar();
				statusLabel = new Label();
				commandPanel = new TableLayoutPanel();
				cancelBtn = new Button();
				dividerPanel = new Panel();
				contentPanel = new TableLayoutPanel();
				macroStatusLabel = new Label();
				macroProgressBar = new ProgressBar();
				commandPanel.SuspendLayout();
				contentPanel.SuspendLayout();
				SuspendLayout();
				// progressBar
				progressBar.Dock = DockStyle.Top;
				progressBar.Location = new Point(11, 75);
				progressBar.Margin = new Padding(0, 7, 0, 0);
				progressBar.Size = new Size(346, 9);
				progressBar.TabIndex = 0;
				// statusLabel
				statusLabel.AutoSize = true;
				statusLabel.Dock = DockStyle.Top;
				statusLabel.Location = new Point(11, 53);
				statusLabel.Margin = new Padding(0);
				statusLabel.Size = new Size(346, 15);
				statusLabel.TabIndex = 1;
				// commandPanel
				commandPanel.AutoSize = true;
				commandPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
				commandPanel.BackColor = SystemColors.Control;
				commandPanel.ColumnCount = 2;
				commandPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
				commandPanel.ColumnStyles.Add(new ColumnStyle());
				commandPanel.Controls.Add(cancelBtn, 1, 1);
				commandPanel.Controls.Add(dividerPanel, 0, 0);
				commandPanel.Dock = DockStyle.Top;
				commandPanel.Location = new Point(0, 95);
				commandPanel.Margin = new Padding(0);
				commandPanel.RowCount = 2;
				commandPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
				commandPanel.RowStyles.Add(new RowStyle());
				commandPanel.Size = new Size(368, 46);
				commandPanel.TabIndex = 6;
				// cancelBtn
				cancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
				cancelBtn.DialogResult = DialogResult.Cancel;
				cancelBtn.Location = new Point(282, 12);
				cancelBtn.Margin = new Padding(0, 11, 11, 11);
				cancelBtn.Size = new Size(75, 23);
				cancelBtn.TabIndex = 2;
				cancelBtn.Text = defaultCancelText;
				cancelBtn.UseVisualStyleBackColor = true;
				cancelBtn.Click += CancelBtn_Click;
				// dividerPanel
				dividerPanel.BackColor = Color.FromArgb(223, 223, 223);
				commandPanel.SetColumnSpan(dividerPanel, 2);
				dividerPanel.Dock = DockStyle.Fill;
				dividerPanel.Location = new Point(0, 0);
				dividerPanel.Margin = new Padding(0);
				dividerPanel.Size = new Size(368, 1);
				dividerPanel.TabIndex = 3;
				// contentPanel
				contentPanel.AutoSize = true;
				contentPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
				contentPanel.ColumnCount = 1;
				contentPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
				contentPanel.Controls.Add(macroStatusLabel, 0, 0);
				contentPanel.Controls.Add(macroProgressBar, 0, 1);
				contentPanel.Controls.Add(statusLabel, 0, 2);
				contentPanel.Controls.Add(progressBar, 0, 3);
				contentPanel.Dock = DockStyle.Top;
				contentPanel.Location = new Point(0, 0);
				contentPanel.Margin = new Padding(0);
				contentPanel.Padding = new Padding(11);
				contentPanel.RowCount = 4;
				contentPanel.RowStyles.Add(new RowStyle());
				contentPanel.RowStyles.Add(new RowStyle());
				contentPanel.RowStyles.Add(new RowStyle());
				contentPanel.RowStyles.Add(new RowStyle());
				contentPanel.Size = new Size(368, 95);
				contentPanel.TabIndex = 7;
				// macroStatusLabel
				macroStatusLabel.AutoSize = true;
				macroStatusLabel.Dock = DockStyle.Top;
				macroStatusLabel.Location = new Point(11, 11);
				macroStatusLabel.Margin = new Padding(0);
				macroStatusLabel.Size = new Size(346, 15);
				macroStatusLabel.TabIndex = 3;
				macroStatusLabel.Visible = false;
				// macroProgressBar
				macroProgressBar.Dock = DockStyle.Top;
				macroProgressBar.Location = new Point(11, 33);
				macroProgressBar.Margin = new Padding(0, 7, 0, 11);
				macroProgressBar.Size = new Size(346, 9);
				macroProgressBar.TabIndex = 2;
				macroProgressBar.Visible = false;
				// ProgressDialog
				AutoSize = true;
				AutoSizeMode = AutoSizeMode.GrowAndShrink;
				BackColor = SystemColors.Window;
				CancelButton = cancelBtn;
				ClientSize = new Size(368, 141);
				ControlBox = false;
				Controls.Add(commandPanel);
				Controls.Add(contentPanel);
				Font = new Font("Segoe UI", 9F);
				FormBorderStyle = FormBorderStyle.FixedSingle;
				Margin = new Padding(3, 4, 3, 4);
				MaximizeBox = false;
				MinimizeBox = false;
				MinimumSize = new Size(320, 132);
				ShowIcon = false;
				ShowInTaskbar = false;
				StartPosition = FormStartPosition.CenterParent;
				commandPanel.ResumeLayout(false);
				contentPanel.ResumeLayout(false);
				contentPanel.PerformLayout();
				ResumeLayout(false);
				PerformLayout();
			}
		}
	}

	/// <summary>Updates progress on a <see cref="ProgressDialog"/>.</summary>
	public class ProgressEventArgs : EventArgs
	{
		/// <summary>Initializes a new instance of the <see cref="ProgressEventArgs"/> class.</summary>
		/// <param name="statusText">The status text.</param>
		/// <param name="percentComplete">The percent complete.</param>
		public ProgressEventArgs(string statusText, int percentComplete)
		{
			StatusText = statusText;
			PercentComplete = percentComplete;
		}

		/// <summary>Initializes a new instance of the <see cref="ProgressEventArgs"/> class.</summary>
		/// <param name="macroStatusText">The macro status text.</param>
		/// <param name="macroPercentComplete">The macro percent complete.</param>
		/// <param name="statusText">The status text.</param>
		/// <param name="percentComplete">The percent complete.</param>
		public ProgressEventArgs(string macroStatusText, int macroPercentComplete, string statusText, int percentComplete) :
			this(statusText, percentComplete)
		{
			MacroStatusText = macroStatusText;
			MacroPercentComplete = macroPercentComplete;
		}

		/// <summary>
		/// Gets or sets the value of the macro progress bar. Valid values are 0 to 100. If this value is 0 and <see cref="MacroStatusText"/> is null or empty,
		/// the macro items will be hidden.
		/// </summary>
		/// <value>The macro percent complete.</value>
		[DefaultValue(0)]
		public int MacroPercentComplete { get; set; }

		/// <summary>
		/// Gets or sets the status text displayed above the macro progress bar. If this value is null or empty and <see cref="MacroPercentComplete"/> is 0, the
		/// macro items will be hidden.
		/// </summary>
		/// <value>The macro status text.</value>
		[DefaultValue("")]
		public string MacroStatusText { get; set; }

		/// <summary>Gets or sets the value of the standard progress bar. Valid values are 0 to 100.</summary>
		/// <value>The percent complete.</value>
		[DefaultValue(0)]
		public int PercentComplete { get; set; }

		/// <summary>Gets or sets the status text displayed above the standard progress bar.</summary>
		/// <value>The status text.</value>
		[DefaultValue("")]
		public string StatusText { get; set; }
	}
}