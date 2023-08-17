using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.ComTypes;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell;

/// <summary>Constants used to indicate how a file in use is being used.</summary>
/// <remarks>
/// The interpretation of "playing" or "editing" is left to the application's implementation. Generally, "playing" would refer to a
/// media file while "editing" can refer to any file being altered in an application. However, the application itself best knows how to
/// map these terms to its actions.
/// </remarks>
public enum FileUsageType
{
	/// <summary>The file is being played by the process that has it open.</summary>
	Playing = FILE_USAGE_TYPE.FUT_PLAYING,

	/// <summary>The file is being edited by the process that has it open.</summary>
	Editing = FILE_USAGE_TYPE.FUT_EDITING,

	/// <summary>
	/// The file is open in the process for an unspecified action or an action that does not readily fit into the other two categories.
	/// </summary>
	Generic = FILE_USAGE_TYPE.FUT_GENERIC,
}

/// <summary>
/// A handler for applications that open file types that can be opened by other applications. An application's use of this object
/// enables Windows Explorer to discover the source of sharing errors, which enables users to address and retry operations that fail due
/// to those errors. This object handles registering the file with the Running Object Table (see <see cref="Ole32.IRunningObjectTable" />). It will revoke
/// that registration on disposal or when the <see cref="Registered" /> property is set to <see langword="false"/>.
/// </summary>
/// <remarks>This object should be created for the duration of use of any file that can be opened by other applications. It's scope should follow
/// that of the file handle or file stream.</remarks>
/// <example>
///   <code title="Example use of FileInUseHandler"><![CDATA[// The following should be taken as example methods within the application that handle opening and closing files.
///private Dictionary<string, (FileStream fileStream, FileInUseHandler inUseHandler)> openFiles =
///   new Dictionary<string, (FileStream, FileInUseHandler)>();
///
///private void OpenFile(string filePath)
///{
///	// Create the in-use handler tied to the 'mainForm' of this application.
///	var inUseHandler = new FileInUseHandler(filePath, mainForm, FileUsageType.Editing);
///	// Assign event handler to close this file if requested and allowed.
///	inUseHandler.CloseFile += (s, e) => CloseFile(((FileInUseHandler)s).FilePath);
///	// Assign event handler to prompt the user if another app requests control of this file.
///	inUseHandler.CloseRequested += (s, e) =>
///	   e.Cancel = MessageBox.Show($"Another application has requested that {Path.GetFileName(((FileInUseHandler)s).FilePath)} be closed to allow it to edit. Allow?",
///	   "Close file request", MessageBoxButtons.YesNo) == DialogResult.No;
///	// Capture file name, open file stream and in-use handler.
///	openFiles.Add(filePath, (File.OpenWrite(filePath), inUseHandler));
///}
///
///private void CloseFile(string filePath)
///{
///	// If the file is open, close the stream via disposal, and revoke in-use registration via disposal
///	if (openFiles.TryGetValue(filePath, out var info))
///	{
///		info.fileStream.Dispose();
///		info.inUseHandler.Dispose();
///		openFiles.Remove(filePath);
///	}
///}]]></code>
/// </example>
/// <seealso cref="IFileIsInUse" />
/// <seealso cref="IDisposable" />
public class FileInUseHandler : IFileIsInUse, IDisposable
{
	private bool disposedValue;
	private string appName;
	private string filePath;
	private IMoniker? moniker;
	private uint regId;

	/// <summary>Initializes a new instance of the <see cref="FileInUseHandler"/> class.</summary>
	/// <param name="filePath">The file path.</param>
	/// <param name="parent">The parent.</param>
	/// <param name="usageType">Type of the usage.</param>
	public FileInUseHandler(string filePath, HWND parent = default, FileUsageType usageType = FileUsageType.Generic)
	{
		ActivationWindow = parent;
		FileUsageType = usageType;
		FilePath = filePath;
		appName = DefAppName;
	}

	/// <summary>Finalizes an instance of the <see cref="FileInUseHandler"/> class.</summary>
	~FileInUseHandler()
	{
		Dispose(disposing: false);
	}

	/// <summary>Occurs after permission has been given to close the file and the file must now be closed.</summary>
	public event EventHandler? CloseFile;

	/// <summary>
	/// Occurs when another application is requesting that the file be closed. If this event is not registered or if in response to this
	/// event, you set the <see cref="CancelEventArgs.Cancel"/> property to <see langword="true"/>, then the requesting application will
	/// be informed that it cannot take control.
	/// </summary>
	public event CancelEventHandler? CloseRequested;

	/// <summary>
	/// Gets or sets the top-level window of the application that is using the file that should be activated when requested. If this
	/// value is <see langword="null"/>, then the calling application will be told that it cannot activate the file's owning application.
	/// </summary>
	/// <value>The activation window.</value>
	public HWND ActivationWindow { get; set; }

	/// <summary>Gets or sets the name of the application using the file.</summary>
	/// <value>
	/// The name of the application that can be passed to the user in a dialog box so that the user knows the source of the conflict and
	/// can act accordingly. For instance "File.txt is in use by Litware.".
	/// </value>
	public string AppName { get => appName; set => appName = value; }

	/// <summary>
	/// Gets or sets the full path to the file that is in use by this application. Setting this value will revoke any prior file's
	/// registration in the ROT and register this file there.
	/// </summary>
	/// <value>The full path to the file that is in use by this application. This value cannot be <see langword="null"/>.</value>
	/// <exception cref="ArgumentNullException">FilePath</exception>
	[MemberNotNull(nameof(filePath))]
	public string FilePath
	{
		get => filePath ?? throw new InvalidOperationException();
		set
		{
			if (!System.IO.File.Exists(filePath)) throw new System.IO.FileNotFoundException(null, filePath);
			RevokeFromROT();
			filePath = value;
			RegisterInROT();
		}
	}

	/// <summary>Gets or sets a value that indicates how the file in use is being used.</summary>
	/// <value>The type of the file use.</value>
	public FileUsageType FileUsageType { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the file specified in <see cref="FilePath"/> is registered in the Running Object Table.
	/// </summary>
	/// <value><see langword="true"/> if registered; otherwise, <see langword="false"/>.</value>
	public bool Registered
	{
		get => regId != 0;
		set
		{
			if (!value)
				RevokeFromROT();
			else if (regId == 0)
				RegisterInROT();
		}
	}

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	HRESULT IFileIsInUse.CloseFile()
	{
		if (CloseFile is null) return HRESULT.E_NOTIMPL;
		CloseFile.Invoke(this, EventArgs.Empty);
		RevokeFromROT();
		return HRESULT.S_OK;
	}

	HRESULT IFileIsInUse.GetAppName(out string ppszName)
	{
		ppszName = appName;
		return HRESULT.S_OK;
	}

	HRESULT IFileIsInUse.GetCapabilities(out OF_CAP pdwCapFlags)
	{
		var cancelArgs = new CancelEventArgs(false);
		CloseRequested?.Invoke(this, cancelArgs);
		pdwCapFlags = (!cancelArgs.Cancel ? OF_CAP.OF_CAP_CANCLOSE : 0) | (ActivationWindow.IsNull ? 0 : OF_CAP.OF_CAP_CANSWITCHTO);
		return HRESULT.S_OK;
	}

	HRESULT IFileIsInUse.GetSwitchToHWND(out HWND phwnd)
	{
		phwnd = ActivationWindow;
		return HRESULT.S_OK;
	}

	HRESULT IFileIsInUse.GetUsage(out FILE_USAGE_TYPE pfut)
	{
		pfut = (FILE_USAGE_TYPE)FileUsageType;
		return HRESULT.S_OK;
	}

	/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
	/// <param name="disposing">
	/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
	/// </param>
	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				RevokeFromROT();
			}

			disposedValue = true;
		}
	}

	private static string DefAppName
	{
		get
		{
			var asm = System.Reflection.Assembly.GetEntryAssembly();
			if (asm is not null)
			{
				object[] attrs = asm.GetCustomAttributes(typeof(System.Reflection.AssemblyProductAttribute), false);
				if (attrs != null && attrs.Length > 0)
					return ((System.Reflection.AssemblyProductAttribute)attrs[0]).Product;
				return System.IO.Path.GetFileNameWithoutExtension(asm.Location);
			}
			return "Unknown";
		}
	}

#pragma warning disable IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
	private void RegisterInROT()
	{
		GetRunningObjectTable(0, out var rot).ThrowIfFailed();
		using var prot = ComReleaserFactory.Create(rot);
		CreateFileMoniker(FilePath, out moniker).ThrowIfFailed();
		regId = rot.Register(ROTFLAGS.ROTFLAGS_REGISTRATIONKEEPSALIVE | ROTFLAGS.ROTFLAGS_ALLOWANYCLIENT, this, moniker!);
	}

	private void RevokeFromROT()
	{
		if (regId == 0) return;
		GetRunningObjectTable(0, out var rot).ThrowIfFailed();
		using var prot = ComReleaserFactory.Create(rot);
		try { rot.Revoke(regId); } catch { }
		regId = 0;
		moniker = null;
	}
#pragma warning restore IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
}