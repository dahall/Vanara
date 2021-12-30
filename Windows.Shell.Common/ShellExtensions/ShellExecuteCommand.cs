using System;
using System.Drawing;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell
{
	/// <summary>
	/// Wraps the functionality of IExecuteCommand. To implement, derive from this class and override the <see cref="OnExecute"/> method. All Shell items
	/// passed to the command are available through the <see cref="SelectedItems"/> property.
	/// </summary>
	/// <remarks>
	/// This class provides an easy means of creating a COM based out-of-process DropTarget.
	/// <list type="number">
	/// <item>Create a .NET application project.</item>
	/// <item>Delete the Program.cs file that includes the Main method.</item>
	/// <item>Create a new class and derive it from <see cref="ShellExecuteCommand"/> with the attributes in the example below.</item>
	/// <item>Ensure the project is built as "X86".</item>
	/// </list>
	/// <code title="Example" lang="cs">// Full implementation of a shell context menu handler using IExecuteCommand. 
	///[ComVisible(true), Guid("&lt;Your GUID here&gt;"), ClassInterface(ClassInterfaceType.None)]
	///public class MyExecCmd : ShellExecuteCommand
	///{
	///	  // *** Replace with your ProgID, verb name and display name ***
	///   const string progID = "txtfile";
	///   const string verbName = "ExecuteCommandVerb";
	///   const string verbDisplayName = "ExecuteCommand Verb Sample";
	///
	///   // Overridden method performs all the functionality of your verb handler. The properties from ShellExecuteCommand should all be set
	///   // and can be used for your implementation. Once you have completed all work required of this command, you must call the
	///   // QuitMessageLoop method to finish processing all messages and then exit. If you fail to call QuitMessageLoop, this process will run
	///   // indefinitely and future context menu requests will not be handled.
	///   public override void OnExecute()
	///   {
	///      var szMsg = $"Found {SelectedItems.Count} item(s) called with '{CommandName}' verb: " + string.Join(", ", SelectedItems.Select(i =&gt; i.Name));
	///      if (!UIDisplayBlocked)
	///         MessageBox.Show(szMsg, verbDisplayName);
	///      // Don't fail to call QuitMessageLoop once you're done processing the Shell call.
	///      QuitMessageLoop();
	///   }
	///
	///   // This is the main thread of the application. When called from the Shell, it will append the -embedding argument to indicate that a
	///   // message loop needs to start running and the COM server registered. All that is accomplished by calling the 'Run' method on your
	///   // new class. You may choose to register or unregister based on alternate command-line arguments. It is highly recommended that you
	///   // supply a timeout to the Run method to prevent a failure from leaving this process running indefinitely. The timeout is automatically
	///   // canceled once the OnExecute method is called so as to prevent long-running code from being terminated. You must specify the
	///   // [STAThread] attribute on this method for the handler to function.
	///   [STAThread]
	///   private static void Main(string[] args)
	///   {
	///      if (args.Length &gt; 0 &amp;&amp; args[0] == "-embedding")
	///         new MyExecCmd().Run(TimeSpan.FromSeconds(30));
	///   }
	///
	///   // This method registers this out-of-proc server to handle the DelegateExecute. This can be omitted if done by an installer.
	///   private static void Register()
	///   {
	///      ShellRegistrar.RegisterLocalServer&lt;MyExecCmd&gt;(verbDisplayName, systemWide: false);
	///      using (var progid = new ProgId(progID, false))
	///      using (var verb = progid.Verbs.Add(verbName, verbDisplayName))
	///         verb.DelegateExecute = Marshal.GenerateGuidForType(typeof(MyExecCmd));
	///   }
	///
	///   // This method unregisters this out-of-proc server from handling the DelegateExecute. This can be omitted if done by an uninstaller.
	///   private static void Unregister()
	///   {
	///      using (var progid = new ProgId(progID, false))
	///         progid.Verbs.Remove(verbName);
	///      ShellRegistrar.UnregisterLocalServer&lt;MyExecCmd&gt;(false);
	///   }
	///}</code></remarks>
	/// <seealso cref="Vanara.PInvoke.Shell32.IExecuteCommand" />
	/// <seealso cref="Vanara.PInvoke.Shell32.IObjectWithSelection" />
	public abstract class ShellExecuteCommand : ShellCommand, IExecuteCommand, IObjectWithSelection
	{
		/// <summary>Initializes a new instance of the <see cref="ShellExecuteCommand"/> class.</summary>
		protected ShellExecuteCommand() : base()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="ShellExecuteCommand"/> class.</summary>
		/// <param name="classContext">The context within which the COM object is to be run.</param>
		/// <param name="classUse">Indicates how connections are made to the class object.</param>
		protected ShellExecuteCommand(CLSCTX classContext, REGCLS classUse) : base(classContext, classUse)
		{
		}

		/// <summary>Gets a value based on the current state of the keys CTRL and SHIFT.</summary>
		/// <value>The value based on the current state of the keys CTRL and SHIFT.</value>
		public MouseButtonState KeyState { get; private set; }

		/// <summary>Gets a new working directory. This value is <see langword="null"/> if the current working directory is to be used.</summary>
		/// <value>Returns a <see cref="string"/> value.</value>
		public string NewWorkingDirectory { get; private set; }

		/// <summary>Gets the parameter values for the verb.</summary>
		/// <value>Returns a <see cref="string"/> value.</value>
		public string Parameters { get; private set; }

		/// <summary>
		/// Gets the screen coordinates at which the user right-clicked to invoke the shortcut menu from which a command was chosen.
		/// Applications can use this information to present any UI. This is particularly useful in a multi-monitor situation. The default
		/// position is the center of the default monitor.
		/// </summary>
		/// <value>Returns a <see cref="Point"/> value.</value>
		public Point Position { get; private set; }

		/// <summary>Gets or sets the selected shell items.</summary>
		/// <value>The selected shell items.</value>
		public ShellItemArray SelectedItems { get; private set; }

		/// <summary>Gets a value indicating whether any UI associated with the selected Shell item should be displayed.</summary>
		/// <value><see langword="true"/> if display of any associated UI is blocked; otherwise, <see langword="false"/>.</value>
		public bool UIDisplayBlocked { get; private set; }

		/// <summary>Gets the specified window's visual state.</summary>
		/// <value>Returns a <see cref="ShowWindowCommand"/> value.</value>
		public ShowWindowCommand WindowState { get; private set; }

		/// <summary>Called in response to <c>IExecuteCommand.Execute()</c>.</summary>
		public abstract void OnExecute();

		/// <inheritdoc/>
		HRESULT IExecuteCommand.Execute()
		{
			QueueNonBlockingCallback(o => OnExecute());
			CancelTimeout();
			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		HRESULT IObjectWithSelection.GetSelection(in Guid riid, out object ppv)
		{
			if (SelectedItems is null)
			{
				ppv = null;
				return HRESULT.E_NOINTERFACE;
			}
			ppv = ShellUtil.QueryInterface(SelectedItems, riid);
			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		HRESULT IExecuteCommand.SetDirectory(string pszDirectory)
		{
			NewWorkingDirectory = pszDirectory;
			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		HRESULT IExecuteCommand.SetKeyState(MouseButtonState grfKeyState)
		{
			KeyState = grfKeyState;
			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		HRESULT IExecuteCommand.SetNoShowUI(bool fNoShowUI)
		{
			UIDisplayBlocked = fNoShowUI;
			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		HRESULT IExecuteCommand.SetParameters(string pszParameters)
		{
			Parameters = pszParameters;
			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		HRESULT IExecuteCommand.SetPosition(Point pt)
		{
			Position = pt;
			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		HRESULT IObjectWithSelection.SetSelection(IShellItemArray psia)
		{
			SelectedItems = new ShellItemArray(psia);
			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		HRESULT IExecuteCommand.SetShowWindow(ShowWindowCommand nShow)
		{
			WindowState = nShow;
			return HRESULT.S_OK;
		}
	}
}