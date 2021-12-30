using System;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.OleAut32;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell
{
	/// <summary>
	/// Wraps the functionality of IInitializeCommand. When deriving, handling the <see cref="InitializeCommand"/> event is optional.
	/// </summary>
	/// <seealso cref="Vanara.Windows.Shell.ComObject"/>
	/// <seealso cref="Vanara.PInvoke.Shell32.IInitializeCommand"/>
	public abstract class ShellCommand : ComObject, IInitializeCommand
	{
		/// <summary>Initializes a new instance of the <see cref="ShellCommand"/> class.</summary>
		protected ShellCommand() : base()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="ShellCommand"/> class.</summary>
		/// <param name="classContext">The context within which the COM object is to be run.</param>
		/// <param name="classUse">Indicates how connections are made to the class object.</param>
		protected ShellCommand(CLSCTX classContext, REGCLS classUse) : base(classContext, classUse)
		{
		}

		/// <summary>Occurs when the shell command is initialized.</summary>
		public event EventHandler InitializeCommand;

		/// <summary>Gets the name of the command returned by <c>IInitializeCommand.Initialize</c>.</summary>
		/// <value>
		/// The name of the command as found in the registry. This value is <see langword="null"/> until <c>IInitializeCommand.Initialize</c>
		/// is called by the host.
		/// </value>
		public string CommandName { get; private set; }

		/// <summary>Gets the properties exposed through <c>IInitializeCommand.Initialize</c>.</summary>
		/// <value>
		/// Gets a <see cref="PropertyBag"/> instance. This value is <see langword="null"/> until <c>IInitializeCommand.Initialize</c> is
		/// called by the host.
		/// </value>
		public PropertyBag Properties { get; private set; }

		/// <inheritdoc/>
		HRESULT IInitializeCommand.Initialize(string pszCommandName, IPropertyBag ppb)
		{
			CommandName = pszCommandName;
			Properties = new PropertyBag(ppb);
			InitializeCommand?.Invoke(this, EventArgs.Empty);
			return HRESULT.S_OK;
		}
	}
}