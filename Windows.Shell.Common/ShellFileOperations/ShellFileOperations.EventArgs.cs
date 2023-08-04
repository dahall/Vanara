using Vanara.PInvoke;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell;

public partial class ShellFileOperations
{
	/// <summary>Arguments supplied to the <see cref="PostNewItem"/> event.</summary>
	/// <seealso cref="ShellFileOpEventArgs"/>
	public class ShellFileNewOpEventArgs : ShellFileOpEventArgs
	{
		internal ShellFileNewOpEventArgs(TRANSFER_SOURCE_FLAGS flags, IShellItem source, IShellItem folder, IShellItem dest, string name, HRESULT hr, string templ, uint attr) :
			base(flags, source, folder, dest, name, hr)
		{
			TemplateName = templ;
			FileAttributes = (System.IO.FileAttributes)attr;
		}

		/// <summary>Gets the name of the template.</summary>
		/// <value>The name of the template.</value>
		public string TemplateName { get; protected set; }

		/// <summary>Gets the file attributes.</summary>
		/// <value>The file attributes.</value>
		public System.IO.FileAttributes FileAttributes { get; protected set; }
	}

	/// <summary>
	/// Arguments supplied to events from <see cref="ShellFileOperations"/>. Depending on the event, some properties may not be set.
	/// </summary>
	/// <seealso cref="EventArgs"/>
	public class ShellFileOpEventArgs : EventArgs
	{
		internal ShellFileOpEventArgs(TRANSFER_SOURCE_FLAGS flags, IShellItem source, IShellItem folder = null, IShellItem dest = null, string name = null, HRESULT hr = default)
		{
			Flags = (TransferFlags)flags;
			if (source != null) try { SourceItem = ShellItem.Open(source); } catch { }
			if (folder != null) try { DestFolder = ShellItem.Open(folder); } catch { }
			if (dest != null) try { DestItem = ShellItem.Open(dest); } catch { }
			Name = name;
			Result = hr;
		}

		/// <summary>Gets the destination folder.</summary>
		/// <value>The destination folder.</value>
		public ShellItem DestFolder { get; protected set; }

		/// <summary>Gets the destination item.</summary>
		/// <value>The destination item.</value>
		public ShellItem DestItem { get; protected set; }

		/// <summary>Gets the tranfer flag values.</summary>
		/// <value>The flags.</value>
		public TransferFlags Flags { get; protected set; }

		/// <summary>Gets the name of the item.</summary>
		/// <value>The item name.</value>
		public string Name { get; protected set; }

		/// <summary>Gets the result of the operation.</summary>
		/// <value>The result.</value>
		public HRESULT Result { get; protected set; }

		/// <summary>Gets the source item.</summary>
		/// <value>The source item.</value>
		public ShellItem SourceItem { get; protected set; }

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => $"HR:{Result};Src:{SourceItem};DFld:{DestFolder};Dst:{DestItem};Name:{Name}";
	}
}