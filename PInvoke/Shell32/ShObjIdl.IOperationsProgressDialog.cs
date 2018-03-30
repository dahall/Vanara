using System;
using System.Runtime.InteropServices;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable UnusedMethodReturnValue.Global

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		public enum OPPROGDLGF
		{
			// The flag space includes OPPROGDLG_ and PROGDLG_ values
			// please guarantee they don't conflict. See shlobj.w for PROGDLG_*
			OPPROGDLG_DEFAULT = 0x00000000,
			OPPROGDLG_ENABLEPAUSE = 0x00000080,   // Add a pause button (operation can be paused)
			OPPROGDLG_ALLOWUNDO = 0x00000100,   // The operation can be undone in the dialog.  (The Stop button becomes Undo)
			OPPROGDLG_DONTDISPLAYSOURCEPATH = 0x00000200,   // Don't display the path of source file in progress dialog
			OPPROGDLG_DONTDISPLAYDESTPATH = 0x00000400,   // Don't display the path of destination file in progress dialog
			OPPROGDLG_NOMULTIDAYESTIMATES = 0x00000800,   // deprecated - progress dialog no longer displays > 1 day estimates
			OPPROGDLG_DONTDISPLAYLOCATIONS = 0x00001000,   // Don't display the location line in the progress dialog
		}

		public enum PDMODE
		{
			PDM_DEFAULT = 0x00000000,
			PDM_RUN = 0x00000001,       // Operation is running
			PDM_PREFLIGHT = 0x00000002,       // Pre-flight mode, calculating operation time, etc
			PDM_UNDOING = 0x00000004,       // Operation is rolling back, undo has been selected
			PDM_ERRORSBLOCKING = 0x00000008,       // Only errors remain, error dialogs are blocking progress from completing
			PDM_INDETERMINATE = 0x00000010,       // The length of the operation is indeterminate, don't show a timer, progressbar is in marquee mode
		}

		public enum PDOPSTATUS
		{
			PDOPS_RUNNING = 1,       // Operation is running, no user intervention
			PDOPS_PAUSED = 2,       // Operation has been paused by the user
			PDOPS_CANCELLED = 3,       // Operation has been cancelled by the user - now go undo
			PDOPS_STOPPED = 4,       // Operation has been stopped by the user - terminate completely
			PDOPS_ERRORS = 5,       // Operation has gone as far as it can without throwing error dialogs
		}

		public enum SPACTION
		{
			SPACTION_NONE = 0,
			SPACTION_MOVING,
			SPACTION_COPYING,
			SPACTION_RECYCLING,
			SPACTION_APPLYINGATTRIBS,
			SPACTION_DOWNLOADING,
			SPACTION_SEARCHING_INTERNET,
			SPACTION_CALCULATING,
			SPACTION_UPLOADING,
			SPACTION_SEARCHING_FILES,
			SPACTION_DELETING,
			SPACTION_RENAMING,
			SPACTION_FORMATTING,
			SPACTION_COPY_MOVING
		}

		[ComImport, Guid("0C9FB851-E5C9-43EB-A370-F0677B13874C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOperationsProgressDialog
		{
			void StartProgressDialog([In] IntPtr hwndOwner, [In] OPPROGDLGF flags);

			void StopProgressDialog();

			// Sets which operation is occuring, and whether we are In pre-flight or undo mode - sets animations, text, etc.
			void SetOperation([In] SPACTION action);

			void SetMode([In] PDMODE mode);

			void UpdateProgress(
			   [In] ulong ullPointsCurrent,
			   [In] ulong ullPointsTotal,  
			   [In] ulong ullSizeCurrent,  
			   [In] ulong ullSizeTotal,    
			   [In] ulong ullItemsCurrent, 
			   [In] ulong ullItemsTotal);  

			// Used to generate display for "from <item (path)> to <item (path)>", etc.
			void UpdateLocations(
				[In] IShellItem psiSource,
				[In] IShellItem psiTarget,
				[In] IShellItem psiItem);

			void ResetTimer();

			void PauseTimer();

			void ResumeTimer();

			void GetMilliseconds(out ulong pullElapsed, out ulong pullRemaining);

			// Returns running/paused/cancelled, etc.
			PDOPSTATUS GetOperationStatus();
		}
	}
}