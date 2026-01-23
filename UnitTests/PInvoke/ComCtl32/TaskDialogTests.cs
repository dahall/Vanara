using NUnit.Framework;
using System.Security.Permissions;
using System.Security;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class TaskDialogTests
{
	[Test]
	public void TestIndirect()
	{
		using Vanara.Windows.Forms.ComCtl32v6Context ccc = new();
		Assert.That(ThemeEnablement.SupportsVisualStyles, Is.True);

		TASKDIALOG_BUTTON[] buttons = [
			new() { nButtonID = 101, pszButtonText = new SafeLPTSTR("Basic File Open") },
			new() { nButtonID = 102, pszButtonText = new SafeLPTSTR("Add Items to Common Places") },
			new() { nButtonID = 103, pszButtonText = new SafeLPTSTR("Add Custom Controls") },
			new() { nButtonID = 104, pszButtonText = new SafeLPTSTR("Change Property Order") },
			new() { nButtonID = 105, pszButtonText = new SafeLPTSTR("Write Properties Using Handlers") },
			new() { nButtonID = 106, pszButtonText = new SafeLPTSTR("Write Properties without Using Handlers") },
		];

		TASKDIALOGCONFIG taskDialogParams = new()
		{
			dwFlags = TASKDIALOG_FLAGS.TDF_USE_COMMAND_LINKS | TASKDIALOG_FLAGS.TDF_ALLOW_DIALOG_CANCELLATION,
			pButtons = new SafeNativeArray<TASKDIALOG_BUTTON>(buttons),
			cButtons = (uint)buttons.Length,
			MainInstruction = "Pick the file dialog sample you want to try",
			WindowTitle = "Common File Dialog",
		};

		Assert.That(TaskDialogIndirect(taskDialogParams, out _, out _, out _), ResultIs.Successful);
	}
}

/// <summary>Class that exposes support for visual styles (ComCtl32 6.0).</summary>
public static class ThemeEnablement
{
	//private static SafeHACTCTX? hActCtx;
	private static bool comCtlSupported = false, comCtlInitialized = false;

	///// <summary>Enables visual styles for this app session.</summary>
	//public static void EnableVisualStyles()
	//{
	//	string assemblyLoc = typeof(Vanara.PInvoke.ComCtl32).Assembly.Location;
	//	// Pull manifest from known assembly
	//	if (assemblyLoc != null)
	//	{
	//		CreateActivationContext(assemblyLoc, 101 /* Manifest resource ID */);
	//	}
	//}

	/// <summary>Gets a value that indicates if this application and system can support visual styles.</summary>
	public static bool SupportsVisualStyles
	{
		get
		{
			if (!comCtlInitialized)
			{
				if (IsAppThemed())
					comCtlSupported = true;
				else
				{
					var hmod = GetModuleHandle(Lib.ComCtl32);
					if (hmod.IsNull)
						hmod = LoadLibraryEx(Lib.ComCtl32, LoadLibraryExFlags.LOAD_LIBRARY_SEARCH_SYSTEM32);
					comCtlSupported = !hmod.IsNull && GetProcAddress(hmod, "ImageList_WriteEx") != IntPtr.Zero;
				}
				comCtlInitialized = true;
			}
			return comCtlSupported;
		}
	}

	///// <summary>Gets a value indicating whether this the context activation is valid.</summary>
	///// <value><see langword="true"/> if this context activation is valid; otherwise, <see langword="false"/>.</value>
	//public static bool IsContextActive => hActCtx is not null && GetCurrentActCtx(out var hctx) && hctx.Equals((HACTCTX)hActCtx);

	//private static bool CreateActivationContext(string dllPath, int id)
	//{
	//	lock(typeof(ThemeEnablement))
	//	{
	//		if (hActCtx is null && !IsAppThemed())
	//		{
	//			ACTCTX ctx = new(dllPath) { lpResourceName = id, dwFlags = ActCtxFlags.ACTCTX_FLAG_RESOURCE_NAME_VALID };
	//			hActCtx = CreateActCtx(ctx);
	//			if (hActCtx.IsInvalid) hActCtx = null;
	//		}
	//		return hActCtx is not null;
	//	}
	//}

	[DllImport("uxtheme.dll", SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool IsAppThemed();
}
