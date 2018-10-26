using System;
using System.Security;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.Windows.Forms
{
	/// <summary>
	/// Activation context that forces the loading of the v6 COMCTL32.DLL. <note type="note">This is not needed if the application has a
	/// manifest including COMCTL32 or if Application.RenderWithVisualStyles is set.</note>
	/// </summary>
	/// <remarks>
	/// <para>Use as follows for all items that require the 6.0 or later version of COMCTL32:</para>
	/// <code lang="cs">
	/// using (new ComCtl32v6Context())
	/// {
	/// // Code that needs the right lib
	/// TaskDialog.Show(...)
	/// }
	/// </code>
	/// </remarks>
	/// <seealso cref="System.IDisposable"/>
	[SuppressUnmanagedCodeSecurity]
	public class ComCtl32v6Context : IDisposable
	{
		private SafeHACTCTX hActCtx;
		private IntPtr localCookie;

		/// <summary>Initializes a new instance of the <see cref="ComCtl32v6Context"/> class.</summary>
		public ComCtl32v6Context()
		{
			if (Environment.OSVersion.Version.Major < 6) return;
			var actctx = new ACTCTX(GetType().Assembly.Location)
			{
				dwFlags = ActCtxFlags.ACTCTX_FLAG_RESOURCE_NAME_VALID,
				lpResourceName = "#2"
			};
			Create(actctx);
			Activate();
		}

		void IDisposable.Dispose()
		{
			try
			{
				if ((localCookie != IntPtr.Zero) && DeactivateActCtx(0, localCookie))
					localCookie = IntPtr.Zero;
				hActCtx.Dispose();
			}
			catch { }
		}

		private void Activate()
		{
			if (hActCtx != null && !ActivateActCtx(hActCtx, out localCookie))
				localCookie = IntPtr.Zero;
		}

		private void Create(in ACTCTX context) => hActCtx = CreateActCtx(context);
	}
}