using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.Extensions;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using BIND_OPTS = System.Runtime.InteropServices.ComTypes.BIND_OPTS;
using IRunningObjectTable = System.Runtime.InteropServices.ComTypes.IRunningObjectTable;

namespace Vanara.Windows.Shell
{
	// TODO: Implement Get/Set options with properties.
	/// <summary>Wraps the <see cref="IBindCtx"/> COM type.</summary>
	/// <seealso cref="System.IDisposable"/>
	public class BindContext : IDisposable, IBindCtx
	{
		private readonly IBindCtx iBindCtx;

		/// <summary>Initializes a new instance of the <see cref="BindContext"/> class.</summary>
		public BindContext() => CreateBindCtx(0, out iBindCtx).ThrowIfFailed();

		/// <summary>Initializes a new instance of the <see cref="BindContext"/> class.</summary>
		/// <param name="mode">Represents flags that should be used when opening the file that contains the object identified by the moniker.</param>
		/// <param name="timeout">
		/// Indicates the amount of time (clock time in milliseconds) that the caller specified to complete the binding operation.
		/// </param>
		/// <param name="flags">Flags that control aspects of moniker binding operations.</param>
		public BindContext(STGM mode = STGM.STGM_READWRITE | STGM.STGM_SHARE_DENY_NONE, TimeSpan timeout = default, BIND_FLAGS flags = 0)
		{
			CreateBindCtx(0, out iBindCtx).ThrowIfFailed();
			var opts = new System.Runtime.InteropServices.ComTypes.BIND_OPTS
			{
				cbStruct = Marshal.SizeOf(typeof(System.Runtime.InteropServices.ComTypes.BIND_OPTS)),
				dwTickCountDeadline = (int)timeout.TotalMilliseconds,
				grfMode = (int)mode,
				grfFlags = (int)flags,
			};
			iBindCtx.SetBindOptions(ref opts);
		}

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose() => Marshal.FinalReleaseComObject(iBindCtx);

		/// <summary>Enumerates the strings that are the keys of the internally maintained table of contextual object parameters.</summary>
		/// <returns>When this method returns, contains a reference to the object parameter enumerator. This parameter is passed uninitialized.</returns>
		public IEnumerable<string> EnumObjectParam() { iBindCtx.EnumObjectParam(out var ppenum); return ppenum.Enum(); }

		/// <summary>
		/// Looks up the given key in the internally maintained table of contextual object parameters and returns the corresponding object,
		/// if one exists.
		/// </summary>
		/// <param name="pszKey">The name of the object to search for.</param>
		/// <returns>When this method returns, contains the object interface pointer. This parameter is passed uninitialized.</returns>
		public object GetObjectParam(string pszKey) { iBindCtx.GetObjectParam(pszKey, out var ppunk); return ppunk; }

		/// <summary>Returns access to the Running Object Table (ROT) relevant to this binding process.</summary>
		/// <returns>When this method returns, contains a reference to the Running Object Table (ROT). This parameter is passed uninitialized.</returns>
		public IRunningObjectTable GetRunningObjectTable() { iBindCtx.GetRunningObjectTable(out var pprot); return pprot; }

		/// <summary>
		/// Registers the passed object as one of the objects that has been bound during a moniker operation and that should be released when
		/// the operation is complete.
		/// </summary>
		/// <param name="punk">The object to register for release.</param>
		public void RegisterObjectBound(object punk) => iBindCtx.RegisterObjectBound(punk);

		/// <summary>Registers the specified object pointer under the specified name in the internally maintained table of object pointers.</summary>
		/// <param name="pszKey">The name to register <paramref name="punk"/> with.</param>
		/// <param name="punk">The object to register.</param>
		public void RegisterObjectParam(string pszKey, object punk) => iBindCtx.RegisterObjectParam(pszKey, punk);

		/// <summary>
		/// Releases all the objects currently registered with the bind context by using the
		/// <see cref="M:System.Runtime.InteropServices.ComTypes.IBindCtx.RegisterObjectBound(System.Object)"/> method.
		/// </summary>
		public void ReleaseBoundObjects() => iBindCtx.ReleaseBoundObjects();

		/// <summary>Removes the object from the set of registered objects that need to be released.</summary>
		/// <param name="punk">The object to unregister for release.</param>
		public void RevokeObjectBound(object punk) => iBindCtx.RevokeObjectBound(punk);

		/// <summary>
		/// Revokes the registration of the object currently found under the specified key in the internally maintained table of contextual
		/// object parameters, if that key is currently registered.
		/// </summary>
		/// <param name="pszKey">The key to unregister.</param>
		/// <returns>
		/// An S_OKHRESULT value if the specified key was successfully removed from the table; otherwise, an S_FALSEHRESULT value.
		/// </returns>
		public int RevokeObjectParam(string pszKey) => iBindCtx.RevokeObjectParam(pszKey);

		/// <summary>Enumerates the strings that are the keys of the internally maintained table of contextual object parameters.</summary>
		/// <param name="ppenum">
		/// When this method returns, contains a reference to the object parameter enumerator. This parameter is passed uninitialized.
		/// </param>
		void IBindCtx.EnumObjectParam(out IEnumString ppenum) => iBindCtx.EnumObjectParam(out ppenum);

		/// <summary>Returns the current binding options stored in the current bind context.</summary>
		/// <param name="pbindopts">A pointer to the structure to receive the binding options.</param>
		void IBindCtx.GetBindOptions(ref BIND_OPTS pbindopts) => iBindCtx.GetBindOptions(ref pbindopts);

		/// <summary>
		/// Looks up the given key in the internally maintained table of contextual object parameters and returns the corresponding object,
		/// if one exists.
		/// </summary>
		/// <param name="pszKey">The name of the object to search for.</param>
		/// <param name="ppunk">When this method returns, contains the object interface pointer. This parameter is passed uninitialized.</param>
		void IBindCtx.GetObjectParam(string pszKey, out object ppunk) => iBindCtx.GetObjectParam(pszKey, out ppunk);

		/// <summary>Returns access to the Running Object Table (ROT) relevant to this binding process.</summary>
		/// <param name="pprot">
		/// When this method returns, contains a reference to the Running Object Table (ROT). This parameter is passed uninitialized.
		/// </param>
		void IBindCtx.GetRunningObjectTable(out IRunningObjectTable pprot) => iBindCtx.GetRunningObjectTable(out pprot);

		/// <summary>
		/// Stores a block of parameters in the bind context. These parameters will apply to later UCOMIMoniker operations that use this bind context.
		/// </summary>
		/// <param name="pbindopts">The structure containing the binding options to set.</param>
		void IBindCtx.SetBindOptions(ref BIND_OPTS pbindopts) => iBindCtx.SetBindOptions(ref pbindopts);
	}
}