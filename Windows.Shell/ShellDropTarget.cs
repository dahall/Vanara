using System;
using System.Drawing;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using IDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;
using IDropTarget = Vanara.PInvoke.Ole32.IDropTarget;

namespace Vanara.Windows.Shell
{
	/// <summary>
	/// COM object that implements IDropTarget. Solves race problem on drop and simplifies interface calls. All IDropTarget methods call
	/// their equivalent On[MethodName] equivalents. To specialize their handling, simply override the On[MethodName] method or hook an event
	/// to the corresponding event.
	/// </summary>
	/// <seealso cref="Vanara.Windows.Shell.ComObject"/>
	/// <seealso cref="Vanara.PInvoke.Ole32.IDropTarget"/>
	public abstract class ShellDropTarget : ComObject, IDropTarget
	{
		private DataObject lastDataObject;
		private DROPEFFECT lastEffect;

		/// <summary>Initializes a new instance of the <see cref="ShellDropTarget"/> class.</summary>
		protected ShellDropTarget() : base() { }

		/// <summary>Occurs when a drag-and-drop operation is started. All calls from this event must be non-blocking.</summary>
		public event DragEventHandler DragDrop;

		/// <summary>Occurs when a drag-and-drop operation is completed.</summary>
		public event DragEventHandler DragDropComplete;

		/// <summary>Occurs to request whether a drop can be accepted, and, if so, the effect of the drop.</summary>
		public event DragEventHandler DragEnter;

		/// <summary>Occurs when the object is told to remove target feedback and releases the data object.</summary>
		public event EventHandler DragLeave;

		/// <summary>
		/// Occurs so target can provide feedback to the user and communicate the drop's effect to the DoDragDrop function so it can
		/// communicate the effect of the drop back to the source.
		/// </summary>
		public event DragEventHandler DragOver;

		/// <inheritdoc/>
		HRESULT IDropTarget.DragEnter(IDataObject pDataObj, uint grfKeyState, Point pt, ref DROPEFFECT pdwEffect)
		{
			var arg = CreateDragEventArgs(pDataObj, grfKeyState, pt, pdwEffect);
			OnDragEnter(arg);
			lastEffect = pdwEffect = (DROPEFFECT)arg.Effect;
			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		HRESULT IDropTarget.DragLeave()
		{
			OnDragLeave(EventArgs.Empty);
			lastDataObject = null;
			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		HRESULT IDropTarget.DragOver(uint grfKeyState, Point pt, ref DROPEFFECT pdwEffect)
		{
			var arg = CreateDragEventArgs(null, grfKeyState, pt, pdwEffect);
			OnDragOver(arg);
			lastEffect = pdwEffect = (DROPEFFECT)arg.Effect;
			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		HRESULT IDropTarget.Drop(IDataObject pDataObj, uint grfKeyState, Point pt, ref DROPEFFECT pdwEffect)
		{
			var arg = CreateDragEventArgs(pDataObj, grfKeyState, pt, pdwEffect);
			OnDragDrop(arg);
			lastEffect = pdwEffect = (DROPEFFECT)arg.Effect;
			QueueNonBlockingCallback(o => OnDragDropComplete((DragEventArgs)o), arg);
			return HRESULT.S_OK;
		}

		/// <summary>Raises the <see cref="E:DragDrop"/> event.</summary>
		/// <param name="drgevent">The <see cref="DragEventArgs"/> instance containing the event data.</param>
		protected virtual void OnDragDrop(DragEventArgs drgevent) => DragDrop?.Invoke(this, drgevent);

		/// <summary>Raises the <see cref="E:DragDropComplete"/> event.</summary>
		/// <param name="drgevent">The <see cref="DragEventArgs"/> instance containing the event data.</param>
		protected virtual void OnDragDropComplete(DragEventArgs drgevent) => DragDropComplete?.Invoke(this, drgevent);

		/// <summary>Raises the <see cref="E:DragEnter"/> event.</summary>
		/// <param name="drgevent">The <see cref="DragEventArgs"/> instance containing the event data.</param>
		protected virtual void OnDragEnter(DragEventArgs drgevent) => DragEnter?.Invoke(this, drgevent);

		/// <summary>Raises the <see cref="E:DragLeave"/> event.</summary>
		/// <param name="ev">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected virtual void OnDragLeave(EventArgs ev) => DragLeave?.Invoke(this, ev);

		/// <summary>Raises the <see cref="E:DragOver"/> event.</summary>
		/// <param name="drgevent">The <see cref="DragEventArgs"/> instance containing the event data.</param>
		protected virtual void OnDragOver(DragEventArgs drgevent) => DragOver?.Invoke(this, drgevent);

		private DragEventArgs CreateDragEventArgs(IDataObject pDataObj, uint grfKeyState, Point pt, DROPEFFECT pdwEffect)
		{
			var data = pDataObj == null ? lastDataObject : new DataObject(pDataObj);
			var drgevent = new DragEventArgs(data, (int)grfKeyState, pt.X, pt.Y, (DragDropEffects)pdwEffect, (DragDropEffects)lastEffect);
			lastDataObject = data;
			return drgevent;
		}
	}
}