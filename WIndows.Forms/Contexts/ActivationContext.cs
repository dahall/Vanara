using System;
using System.Security;
using System.Windows.Forms;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.Windows.Forms
{
	[SuppressUnmanagedCodeSecurity]
	public class ActivationContext : IDisposable
	{
		private ActCtxSafeHandle hActCtx;
		private IntPtr localCookie;

		public ActivationContext(string source = null, string assemblyDirectory = null)
		{
			if (source == null)
				GetCurrentActCtx(out hActCtx);
			else
			{
				var actctx = new ACTCTX(source);
				if (assemblyDirectory != null)
				{
					actctx.lpAssemblyDirectory = assemblyDirectory;
					actctx.dwFlags |= ActCtxFlags.ACTCTX_FLAG_ASSEMBLY_DIRECTORY_VALID;
				}
				Create(ref actctx);
			}
			Activate();
		}

		public ActivationContext(ref ACTCTX context) { Create(ref context); Activate(); }

		public IntPtr Cookie => localCookie;

		public void Dispose()
		{
			if ((localCookie != IntPtr.Zero) && OSFeature.Feature.IsPresent(OSFeature.Themes) && DeactivateActCtx(0, localCookie))
				localCookie = IntPtr.Zero;
			hActCtx.Dispose();
		}

		private void Activate()
		{
			if (Application.RenderWithVisualStyles && hActCtx != null && OSFeature.Feature.IsPresent(OSFeature.Themes) && !ActivateActCtx(hActCtx, out localCookie))
				localCookie = IntPtr.Zero;
		}

		private void Create(ref ACTCTX context) { hActCtx = CreateActCtx(ref context); }
	}
}
