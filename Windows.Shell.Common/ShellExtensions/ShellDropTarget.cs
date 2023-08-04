using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;
using IDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;
using IDropTarget = Vanara.PInvoke.Ole32.IDropTarget;

namespace Vanara.Windows.Shell;

/// <summary>
/// Provides data for the <see cref="ShellDropTarget.DragDrop"/>, <see cref="ShellDropTarget.DragEnter"/>, or <see
/// cref="ShellDropTarget.DragOver"/> event.
/// </summary>
/// <remarks>
/// A DragEventArgs object specifies any data associated with drag/drop events; the current state of the SHIFT, CTRL, and ALT keys; the
/// location of the mouse pointer; and the drag-and-drop effects allowed by the source and target of the drag event.
/// </remarks>
public class DragEventArgs : EventArgs
{
	/// <summary>Initializes a new instance of the <see cref="DragEventArgs"/> class.</summary>
	/// <param name="data">The data associated with this event.</param>
	/// <param name="keyState">The current state of the SHIFT, CTRL, and ALT keys.</param>
	/// <param name="x">The x-coordinate of the mouse cursor in pixels.</param>
	/// <param name="y">The y-coordinate of the mouse cursor in pixels.</param>
	/// <param name="allowedEffect">One of the DROPEFFECT values.</param>
	/// <param name="lastEffect">One of the DROPEFFECT values.</param>
	public DragEventArgs(IDataObject data, MouseButtonState keyState, int x, int y, DROPEFFECT allowedEffect, DROPEFFECT lastEffect)
	{
		Data = data;
		KeyState = keyState;
		X = x;
		Y = y;
		AllowedEffect = allowedEffect;
		Effect = lastEffect;
	}

	/// <summary>Gets which drag-and-drop operations are allowed by the originator (or source) of the drag event.</summary>
	public DROPEFFECT AllowedEffect { get; }

	/// <summary>Gets the IDataObject that contains the data associated with this event.</summary>
	public IDataObject Data { get; }

	/// <summary>Gets or sets the target drop effect in a drag-and-drop operation.</summary>
	public DROPEFFECT Effect { get; set; }

	/// <summary>Gets the current state of the SHIFT, CTRL, and ALT keys, as well as the state of the mouse buttons.</summary>
	public MouseButtonState KeyState { get; }

	/// <summary>Gets the x-coordinate of the mouse pointer, in screen coordinates.</summary>
	public int X { get; }

	/// <summary>Gets the y-coordinate of the mouse pointer, in screen coordinates.</summary>
	public int Y { get; }
}

/// <summary>
/// COM object that implements IDropTarget. Solves race problem on drop and simplifies interface calls. All IDropTarget methods call
/// their equivalent On[MethodName] equivalents. To specialize their handling, simply override the On[MethodName] method or hook an event
/// to the corresponding event.
/// </summary>
/// <remarks>
/// This class provides an easy means of creating a COM based out-of-process DropTarget.
/// <list type="number">
/// <item>Create a .NET application project.</item>
/// <item>Delete the Program.cs file that includes the Main method.</item>
/// <item>Create a new class and derive it from <see cref="ShellDropTarget"/> with the attributes in the example below.</item>
/// <item>Ensure the project is built as "X86".</item>
/// </list>
/// <code title="Example" lang="cs">[Guid("&lt;Your GUID here&gt;"), ClassInterface(ClassInterfaceType.None)]
///public class MyDropTarget : ShellDropTarget
///{
///   // In your constructor, be sure to override the DragEnter and DragDrop events and set the effect you desire.
///   public MyDropTarget() : base()
///   {
///      // Setting the effect to Copy here ensure we continue to get drag/drop messages
///      DragEnter += (s, e) =&gt; e.Effect = DragDropEffects.Copy;
///
///      DragDrop += MyDragDrop;
///   }
///
///   // This event handler for DragDrop should never hold up the shell. To accommodate a non-blocking response,
///   // use the 'QueueNonBlockingCallback' method which uses PostThreadMessage to run a delegate as shown below.
///   private void MyDragDrop(object sender, DragEventArgs e)
///   {
///      // Setting the effect to None here ends drag/drop messages
///      e.Effect = DragDropEffects.None;
///      // Notice we're passing in the DragEventArgs.Data property that contains the shell item array from the Shell.
///      QueueNonBlockingCallback(DisplayData, e.Data);
///   }
///
///   // This delegate will get run outside of the Shell's calling path and can display a UI or perform any other
///   // function on the list of shell items passed to it.
///   private void DisplayData(object ido)
///   {
///      // *** Replace with your functionality ***
///      using (var shia = ShellItemArray.FromDataObject(ido as DataObject))
///      {
///         var szMsg = $"Found {shia.Count} item(s): " + string.Join(", ", shia.Select(i =&gt; i.Name));
///         MessageBox.Show(szMsg, "MyDropTarget");
///      }
///      // Don't fail to call QuitMessageLoop once you're done processing the Shell call.
///      QuitMessageLoop();
///   }
///
///   // This is the main thread of the application. When called from the Shell, it will append the -embedding argument to indicate that
///   // a message loop needs to start running and the COM server registered. All that is accomplished by calling the 'Run' method
///   // on your new class.
///   [STAThread]
///   private static void Main(string[] args)
///   {
///      // *** Replace with your ProgID, name and display name ***
///      const string progID = "txtfile";
///      const string verbDisplayName = "DropTarget Verb Sample";
///      const string verbName = "DropTargetVerb";
///
///      var arg = args.Length &gt; 0 ? args[0].TrimStart('-', '/').ToLowerInvariant() : null;
///      switch (arg)
///      {
///         // Handle a call from the Shell launching this out-of-proc server
///         case "embedding":
///            new MyDropTarget().Run(TimeSpan.FromSeconds(30));
///            break;
///
///         // Unregister this out-of-proc server from handling the DropTarget. This can be omitted if done by an installer.
///         case "unregister":
///            using (var progid = new ProgId(progID, false))
///               progid.Verbs.Remove(verbName);
///            ShellRegistrar.UnregisterLocalServer&lt;MyDropTarget&gt;(false);
///            break;
///
///         // Register this out-of-proc server to handle the DropTarget. This can be omitted if done by an installer.
///         default:
///            ShellRegistrar.RegisterLocalServer&lt;MyDropTarget&gt;("MyTestDropTarget", systemWide: false);
///            using (var progid = new ProgId(progID, false))
///            using (var verb = progid.Verbs.Add(verbName, verbDisplayName))
///            {
///               verb.DropTarget = Marshal.GenerateGuidForType(typeof(MyDropTarget));
///               verb.NeverDefault = true;
///            }
///            break;
///      }
///   }
///}</code></remarks>
/// <seealso cref="ComObject"/>
/// <seealso cref="IDropTarget"/>
public abstract class ShellDropTarget : ShellCommand, IDropTarget, IInitializeCommand
{
	private IDataObject lastDataObject;
	private DROPEFFECT lastEffect = DROPEFFECT.DROPEFFECT_NONE;

	/// <summary>Initializes a new instance of the <see cref="ShellDropTarget"/> class.</summary>
	protected ShellDropTarget() : base() { }

	/// <summary>Initializes a new instance of the <see cref="ShellDropTarget"/> class.</summary>
	/// <param name="classContext">The context within which the COM object is to be run.</param>
	/// <param name="classUse">Indicates how connections are made to the class object.</param>
	protected ShellDropTarget(CLSCTX classContext, REGCLS classUse) : base(classContext, classUse) { }

	/// <summary>Occurs when a drag-and-drop operation is started. All calls from this event must be non-blocking.</summary>
	public event EventHandler<DragEventArgs> DragDrop;

	/// <summary>Occurs to request whether a drop can be accepted, and, if so, the effect of the drop.</summary>
	public event EventHandler<DragEventArgs> DragEnter;

	/// <summary>Occurs when the object is told to remove target feedback and releases the data object.</summary>
	public event EventHandler DragLeave;

	/// <summary>
	/// Occurs so target can provide feedback to the user and communicate the drop's effect to the DoDragDrop function so it can
	/// communicate the effect of the drop back to the source.
	/// </summary>
	public event EventHandler<DragEventArgs> DragOver;

	/// <inheritdoc/>
	HRESULT IDropTarget.DragEnter(IDataObject pDataObj, MouseButtonState grfKeyState, POINT pt, ref DROPEFFECT pdwEffect)
	{
		System.Diagnostics.Debug.WriteLine($"IDropTarget.DragEnter: effect={pdwEffect}");
		var drgevent = CreateDragEventArgs(pDataObj, grfKeyState, pt, pdwEffect);
		DragEnter?.Invoke(this, drgevent);
		lastEffect = pdwEffect = drgevent.Effect;
		return HRESULT.S_OK;
	}

	/// <inheritdoc/>
	HRESULT IDropTarget.DragLeave()
	{
		System.Diagnostics.Debug.WriteLine("IDropTarget.DragLeave");
		DragLeave?.Invoke(this, EventArgs.Empty);
		lastDataObject = null;
		return HRESULT.S_OK;
	}

	/// <inheritdoc/>
	HRESULT IDropTarget.DragOver(MouseButtonState grfKeyState, POINT pt, ref DROPEFFECT pdwEffect)
	{
		System.Diagnostics.Debug.WriteLine($"IDropTarget.DragOver: effect={pdwEffect}");
		var drgevent = CreateDragEventArgs(null, grfKeyState, pt, pdwEffect);
		DragOver?.Invoke(this, drgevent);
		lastEffect = pdwEffect = drgevent.Effect;
		return HRESULT.S_OK;
	}

	/// <inheritdoc/>
	HRESULT IDropTarget.Drop(IDataObject pDataObj, MouseButtonState grfKeyState, POINT pt, ref DROPEFFECT pdwEffect)
	{
		System.Diagnostics.Debug.WriteLine($"IDropTarget.Drop: effect={pdwEffect}");
		var drgevent = CreateDragEventArgs(pDataObj, grfKeyState, pt, pdwEffect);
		DragDrop?.Invoke(this, drgevent);
		pdwEffect = drgevent.Effect;
		CancelTimeout();
		return HRESULT.S_OK;
	}

	private DragEventArgs CreateDragEventArgs(IDataObject pDataObj, MouseButtonState grfKeyState, POINT pt, DROPEFFECT pdwEffect)
	{
		var data = pDataObj ?? lastDataObject;
		var drgevent = new DragEventArgs(data, grfKeyState, pt.X, pt.Y, pdwEffect, lastEffect);
		lastDataObject = data;
		return drgevent;
	}
}