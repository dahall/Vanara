using System;
using System.Security;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.Windows.Forms
{
	/// <summary>Provides an activation context for a manifest file or PE image. On disposal, the context is deactivated.</summary>
	/// <seealso cref="System.IDisposable"/>
	[SuppressUnmanagedCodeSecurity]
	public class ActivationContext : IDisposable
	{
		private SafeHACTCTX hActCtx;
		private IntPtr localCookie;

		/// <summary>Initializes a new instance of the <see cref="ActivationContext"/> class.</summary>
		/// <exception cref="InvalidOperationException">No current activation context exists.</exception>
		public ActivationContext() => hActCtx = SafeHACTCTX.GetCurrent();

		/// <summary>Initializes a new instance of the <see cref="ActivationContext"/> class.</summary>
		/// <param name="source">The path of a manifest file. Do not use this constructor if specifying a PE image.</param>
		/// <param name="assemblyDirectory">
		/// The base directory in which to perform private assembly probing if assemblies in the activation context are not present in the
		/// system-wide store.
		/// </param>
		public ActivationContext(string source, string assemblyDirectory = null)
		{
			var actctx = new ACTCTX(source);
			CreateAndAttach(ref actctx, assemblyDirectory: assemblyDirectory);
		}

		/// <summary>Initializes a new instance of the <see cref="ActivationContext"/> class.</summary>
		/// <param name="peImagePath">Specifies the path of PE image (EXE or DLL file) to be used to create the activation context.</param>
		/// <param name="resourceName">
		/// The resource name to be loaded from the PE. If the resource name is an integer, set this member using MAKEINTRESOURCE.
		/// </param>
		/// <param name="assemblyDirectory">
		/// The base directory in which to perform private assembly probing if assemblies in the activation context are not present in the
		/// system-wide store.
		/// </param>
		/// <param name="appName">
		/// The name of the current application. If the value of this member is set to null, the name of the executable that launched the
		/// current process is used.
		/// </param>
		/// <param name="langId">Specifies the language manifest that should be used. The default is the current user's current UI language.</param>
		/// <param name="processor">Identifies the type of processor used. Specifies the system's processor architecture.</param>
		/// <param name="setAsProcessDefault">if set to <c>true</c> [set as process default].</param>
		public ActivationContext(string peImagePath, string resourceName, string assemblyDirectory = null, string appName = null, ushort langId = 0, ProcessorArchitecture processor = 0, bool setAsProcessDefault = false)
		{
			var actctx = new ACTCTX(peImagePath ?? throw new ArgumentNullException(nameof(peImagePath)));
			if (resourceName == null) throw new ArgumentNullException(nameof(resourceName));
			CreateAndAttach(ref actctx, resourceName, assemblyDirectory, appName, langId, processor, setAsProcessDefault);
		}

		/// <summary>Initializes a new instance of the <see cref="ActivationContext"/> class.</summary>
		/// <param name="hInst">
		/// Specifies the handle to an already opened module (EXE or DLL file) to be used to create the activation context.
		/// </param>
		/// <param name="resourceName">
		/// The resource name to be loaded from the PE. If the resource name is an integer, set this member using MAKEINTRESOURCE.
		/// </param>
		/// <param name="assemblyDirectory">
		/// The base directory in which to perform private assembly probing if assemblies in the activation context are not present in the
		/// system-wide store.
		/// </param>
		/// <param name="appName">
		/// The name of the current application. If the value of this member is set to null, the name of the executable that launched the
		/// current process is used.
		/// </param>
		/// <param name="langId">Specifies the language manifest that should be used. The default is the current user's current UI language.</param>
		/// <param name="processor">Identifies the type of processor used. Specifies the system's processor architecture.</param>
		/// <param name="setAsProcessDefault">if set to <c>true</c> [set as process default].</param>
		public ActivationContext(HINSTANCE hInst, string resourceName, string assemblyDirectory = null, string appName = null, ushort langId = 0, ProcessorArchitecture processor = 0, bool setAsProcessDefault = false)
		{
			if (hInst.IsNull) throw new ArgumentNullException(nameof(hInst));
			if (resourceName == null) throw new ArgumentNullException(nameof(resourceName));
			var actctx = ACTCTX.Empty;
			actctx.hModule = hInst;
			CreateAndAttach(ref actctx, resourceName, assemblyDirectory, appName, langId, processor, setAsProcessDefault);
		}

		/// <summary>Initializes a new instance of the <see cref="ActivationContext"/> class.</summary>
		/// <param name="context">An activation context structure.</param>
		public ActivationContext(in ACTCTX context)
		{
			Create(context);
			Activate();
		}

		/// <summary>Gets the local cookie associated with the activation.</summary>
		public IntPtr Cookie => localCookie;

		/// <summary>Gets a value indicating if the context is invalid.</summary>
		public bool IsInvalid => hActCtx.IsNull;

		/// <inheritdoc/>
		public void Dispose()
		{
			if (localCookie != IntPtr.Zero && DeactivateActCtx(0, localCookie))
				localCookie = IntPtr.Zero;
			hActCtx.Dispose();
		}

		private void Activate()
		{
			if (!ActivateActCtx(hActCtx, out localCookie)) Win32Error.ThrowLastError();
		}

		private void Create(in ACTCTX context)
		{
			hActCtx = CreateActCtx(context);
			if (hActCtx.IsInvalid) Win32Error.ThrowLastError();
		}

		private void CreateAndAttach(ref ACTCTX actctx, string resourceName = null, string assemblyDirectory = null, string appName = null, ushort langId = 0, ProcessorArchitecture processor = 0, bool setAsProcessDefault = false)
		{
			if (resourceName != null)
			{
				actctx.lpResourceName = resourceName;
				actctx.dwFlags |= ActCtxFlags.ACTCTX_FLAG_RESOURCE_NAME_VALID;
			}
			if (assemblyDirectory != null)
			{
				actctx.lpAssemblyDirectory = assemblyDirectory;
				actctx.dwFlags |= ActCtxFlags.ACTCTX_FLAG_ASSEMBLY_DIRECTORY_VALID;
			}
			if (appName != null)
			{
				actctx.lpApplicationName = appName;
				actctx.dwFlags |= ActCtxFlags.ACTCTX_FLAG_APPLICATION_NAME_VALID;
			}
			if (langId != 0)
			{
				actctx.wLangId = langId;
				actctx.dwFlags |= ActCtxFlags.ACTCTX_FLAG_LANGID_VALID;
			}
			if (processor != 0)
			{
				actctx.wProcessorArchitecture = processor;
				actctx.dwFlags |= ActCtxFlags.ACTCTX_FLAG_PROCESSOR_ARCHITECTURE_VALID;
			}
			if (setAsProcessDefault)
			{
				actctx.dwFlags |= ActCtxFlags.ACTCTX_FLAG_SET_PROCESS_DEFAULT;
			}
			Create(actctx);
			Activate();
		}
	}
}