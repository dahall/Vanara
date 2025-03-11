namespace Vanara.PInvoke;

public static partial class Dcomp
{
	/// <summary>Maximum number of targets kept per frame</summary>
	public const int COMPOSITION_STATS_MAX_TARGETS = 256;

	/// <summary>The maximum nubmer of objects we allow users to wait on the compositor clock</summary>
	public const int DCOMPOSITION_MAX_WAITFORCOMPOSITORCLOCK_OBJECTS = 32;

	/// <summary>Defines constants that specify the status of a compositor frame.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomptypes/ne-dcomptypes-composition_frame_id_type typedef enum
	// COMPOSITION_FRAME_ID_TYPE { COMPOSITION_FRAME_ID_CREATED, COMPOSITION_FRAME_ID_CONFIRMED, COMPOSITION_FRAME_ID_COMPLETED } ;
	[PInvokeData("dcomptypes.h", MSDNShortId = "NE:dcomptypes.COMPOSITION_FRAME_ID_TYPE")]
	public enum COMPOSITION_FRAME_ID_TYPE
	{
		/// <summary>The compositor has started working on the frame.</summary>
		COMPOSITION_FRAME_ID_CREATED,

		/// <summary>CPU work is completed and any presents have taken place.</summary>
		COMPOSITION_FRAME_ID_CONFIRMED,

		/// <summary>GPU work is completed for all render targets associated with the frame.</summary>
		COMPOSITION_FRAME_ID_COMPLETED,
	}

	/// <summary>The requested access to the composition surface object.</summary>
	[PInvokeData("dcomptypes.h")]
	[Flags]
	public enum COMPOSITIONOBJECT_ACCESS : uint
	{
		/// <summary>Read access. For internal use only.</summary>
		COMPOSITIONOBJECT_READ = 0x1,

		/// <summary>Write access. For internal use only.</summary>
		COMPOSITIONOBJECT_WRITE = 0x2,

		/// <summary>
		/// Read/write access. Always specify this flag except when duplicating a surface in another process, in which case set
		/// <i>desiredAccess</i> to 0.
		/// </summary>
		COMPOSITIONOBJECT_ALL_ACCESS = 0x3,
	}

	/// <summary>Specifies the backface visibility to be applied to a visual.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomptypes/ne-dcomptypes-dcomposition_backface_visibility typedef enum
	// DCOMPOSITION_BACKFACE_VISIBILITY { DCOMPOSITION_BACKFACE_VISIBILITY_VISIBLE = 0, DCOMPOSITION_BACKFACE_VISIBILITY_HIDDEN = 1,
	// DCOMPOSITION_BACKFACE_VISIBILITY_INHERIT = 0xffffffff } ;
	[PInvokeData("dcomptypes.h", MSDNShortId = "NE:dcomptypes.DCOMPOSITION_BACKFACE_VISIBILITY")]
	[SupportedOSPlatform("windows8.1")]
	public enum DCOMPOSITION_BACKFACE_VISIBILITY : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Surfaces in this visual's sub-tree are visible regardless of transformation.</para>
		/// </summary>
		DCOMPOSITION_BACKFACE_VISIBILITY_VISIBLE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Surfaces in this visual's sub-tree are only visible when facing the observer.</para>
		/// </summary>
		DCOMPOSITION_BACKFACE_VISIBILITY_HIDDEN,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xffffffff</para>
		/// <para>The back face visibility is the same as that of the target visual's parent visual.</para>
		/// </summary>
		DCOMPOSITION_BACKFACE_VISIBILITY_INHERIT = 0xffffffff,
	}

	/// <summary>
	/// Specifies the interpolation mode to be used when a bitmap is composed with any transform where the pixels in the bitmap don't line up
	/// exactly one-to-one with pixels on screen.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The default interpolation mode for a visual is <b>DCOMPOSITION_BITMAP_INTERPOLATION_MODE_INHERIT</b>. If all visuals in a visual tree
	/// specify this mode, the default for all visuals is nearest neighbor sampling, which is the fastest mode.
	/// </para>
	/// <para>
	/// A single visual can have any combination of visual properties. However, if a visual has the following combination of properties, the
	/// borders of the visual will default to <c>DCOMPOSITION_BORDER_MODE_HARD</c>.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>SetCompositeMode(DCOMPOSITION_COMPOSITE_MODE_DESTINATION_INVERT)</c></description>
	/// </item>
	/// <item>
	/// <description><c>SetBorderMode(DCOMPOSITION_BORDER_MODE_SOFT)</c></description>
	/// </item>
	/// <item>
	/// <description><c>SetBitmapInterpolationMode(DCOMPOSITION_BITMAP_INTERPOLATION_MODE_NEAREST_NEIGHBOR)</c></description>
	/// </item>
	/// </list>
	/// <para>
	/// If you want a visual to be drawn with antialiasing, use <b>DCOMPOSITION_BITMAP_INTERPOLATION_MODE_LINEAR</b> for the content of the
	/// visual, and <c>DCOMPOSITION_BORDER_MODE_SOFT</c> for the edges.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomptypes/ne-dcomptypes-dcomposition_bitmap_interpolation_mode typedef enum
	// DCOMPOSITION_BITMAP_INTERPOLATION_MODE { DCOMPOSITION_BITMAP_INTERPOLATION_MODE_NEAREST_NEIGHBOR = 0,
	// DCOMPOSITION_BITMAP_INTERPOLATION_MODE_LINEAR = 1, DCOMPOSITION_BITMAP_INTERPOLATION_MODE_INHERIT = 0xffffffff } ;
	[PInvokeData("dcomptypes.h", MSDNShortId = "NE:dcomptypes.DCOMPOSITION_BITMAP_INTERPOLATION_MODE")]
	public enum DCOMPOSITION_BITMAP_INTERPOLATION_MODE : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Bitmaps are interpolated by using nearest-neighbor sampling.</para>
		/// </summary>
		DCOMPOSITION_BITMAP_INTERPOLATION_MODE_NEAREST_NEIGHBOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Bitmaps are interpolated by using linear sampling.</para>
		/// </summary>
		DCOMPOSITION_BITMAP_INTERPOLATION_MODE_LINEAR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xffffffff</para>
		/// <para>Bitmaps are interpolated according to the mode established by the parent visual.</para>
		/// </summary>
		DCOMPOSITION_BITMAP_INTERPOLATION_MODE_INHERIT = 0xffffffff,
	}

	/// <summary>
	/// Specifies the border mode to use when composing a bitmap or applying a clip with any transform such that the edges of the bitmap or
	/// clip are not axis-aligned with integer coordinates.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The default border mode for any given visual is <b>DCOMPOSITION_BORDER_MODE_INHERIT</b>, which delegates the determination of the
	/// border mode to the parent visual. If all visuals in a visual tree specify this mode, the default for all visuals is aliased
	/// rendering, which is the fastest mode.
	/// </para>
	/// <para>
	/// A single visual can have any combination of visual properties. However, if a visual has the following combination of properties, the
	/// borders of the visual will default to <b>DCOMPOSITION_BORDER_MODE_HARD</b>.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>SetCompositeMode(DCOMPOSITION_COMPOSITE_MODE_DESTINATION_INVERT)</c></description>
	/// </item>
	/// <item>
	/// <description><c>SetBorderMode(DCOMPOSITION_BORDER_MODE_SOFT)</c></description>
	/// </item>
	/// <item>
	/// <description><c>SetBitmapInterpolationMode(DCOMPOSITION_BITMAP_INTERPOLATION_MODE_NEAREST_NEIGHBOR)</c></description>
	/// </item>
	/// </list>
	/// <para>
	/// If you want a visual to be drawn with antialiasing, use <c>DCOMPOSITION_BITMAP_INTERPOLATION_MODE_LINEAR</c> for the content of the
	/// visual, and <b>DCOMPOSITION_BORDER_MODE_SOFT</b> for the edges.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomptypes/ne-dcomptypes-dcomposition_border_mode typedef enum
	// DCOMPOSITION_BORDER_MODE { DCOMPOSITION_BORDER_MODE_SOFT = 0, DCOMPOSITION_BORDER_MODE_HARD = 1, DCOMPOSITION_BORDER_MODE_INHERIT =
	// 0xffffffff } ;
	[PInvokeData("dcomptypes.h", MSDNShortId = "NE:dcomptypes.DCOMPOSITION_BORDER_MODE")]
	public enum DCOMPOSITION_BORDER_MODE : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Bitmap and clip edges are antialiased.</para>
		/// </summary>
		DCOMPOSITION_BORDER_MODE_SOFT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Bitmap and clip edges are aliased. See Remarks.</para>
		/// </summary>
		DCOMPOSITION_BORDER_MODE_HARD,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xffffffff</para>
		/// <para>Bitmap and clip edges are drawn according to the mode established by the parent visual.</para>
		/// </summary>
		DCOMPOSITION_BORDER_MODE_INHERIT = 0xffffffff,
	}

	/// <summary>The mode to use to blend the bitmap content of a visual with the render target.</summary>
	/// <remarks>
	/// <para>
	/// A single visual can have any combination of visual properties. However, if a visual has the following combination of properties, the
	/// borders of the visual will default to <c>DCOMPOSITION_BORDER_MODE_HARD</c>.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>SetCompositeMode(DCOMPOSITION_COMPOSITE_MODE_DESTINATION_INVERT)</c></description>
	/// </item>
	/// <item>
	/// <description><c>SetBorderMode(DCOMPOSITION_BORDER_MODE_SOFT)</c></description>
	/// </item>
	/// <item>
	/// <description><c>SetBitmapInterpolationMode(DCOMPOSITION_BITMAP_INTERPOLATION_MODE_NEAREST_NEIGHBOR)</c></description>
	/// </item>
	/// </list>
	/// <para>
	/// If you want a visual to be drawn with antialiasing, use <c>DCOMPOSITION_BITMAP_INTERPOLATION_MODE_LINEAR</c> for the content of the
	/// visual, and <c>DCOMPOSITION_BORDER_MODE_SOFT</c> for the edges.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomptypes/ne-dcomptypes-dcomposition_composite_mode typedef enum
	// DCOMPOSITION_COMPOSITE_MODE { DCOMPOSITION_COMPOSITE_MODE_SOURCE_OVER = 0, DCOMPOSITION_COMPOSITE_MODE_DESTINATION_INVERT = 1,
	// DCOMPOSITION_COMPOSITE_MODE_MIN_BLEND = 2, DCOMPOSITION_COMPOSITE_MODE_INHERIT = 0xffffffff } ;
	[PInvokeData("dcomptypes.h", MSDNShortId = "NE:dcomptypes.DCOMPOSITION_COMPOSITE_MODE")]
	public enum DCOMPOSITION_COMPOSITE_MODE : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The standard source-over-destination blend mode.</para>
		/// </summary>
		DCOMPOSITION_COMPOSITE_MODE_SOURCE_OVER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The bitmap colors are inverted.</para>
		/// </summary>
		DCOMPOSITION_COMPOSITE_MODE_DESTINATION_INVERT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Bitmap colors subtract for color channels in the background.</para>
		/// </summary>
		[SupportedOSPlatform("windows8.1")]
		DCOMPOSITION_COMPOSITE_MODE_MIN_BLEND,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xffffffff</para>
		/// <para>Bitmaps are blended according to the mode established by the parent visual.</para>
		/// </summary>
		DCOMPOSITION_COMPOSITE_MODE_INHERIT = 0xffffffff,
	}

	/// <summary/>
	[PInvokeData("dcomptypes.h")]
	[SupportedOSPlatform("windows10.0")]
	public enum DCOMPOSITION_DEPTH_MODE : uint
	{
		/// <summary/>
		DCOMPOSITION_DEPTH_MODE_TREE = 0,

		/// <summary/>
		DCOMPOSITION_DEPTH_MODE_SPATIAL = 1,

		/// <summary/>
		DCOMPOSITION_DEPTH_MODE_SORTED = 3,

		/// <summary/>
		DCOMPOSITION_DEPTH_MODE_INHERIT = 0xffffffff
	}

	/// <summary>Specifies how the effective opacity value of a visual is applied to that visual’s content and children.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomptypes/ne-dcomptypes-dcomposition_opacity_mode typedef enum
	// DCOMPOSITION_OPACITY_MODE { DCOMPOSITION_OPACITY_MODE_LAYER = 0, DCOMPOSITION_OPACITY_MODE_MULTIPLY = 1,
	// DCOMPOSITION_OPACITY_MODE_INHERIT = 0xffffffff } ;
	[PInvokeData("dcomptypes.h", MSDNShortId = "NE:dcomptypes.DCOMPOSITION_OPACITY_MODE")]
	[SupportedOSPlatform("windows8.1")]
	public enum DCOMPOSITION_OPACITY_MODE : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// The target visual defines a logical layer into which its entire sub-tree is composed with a starting effective opacity of 1.0.
		/// The original opacity value is then used to blend the layer onto the visual’s background.
		/// </para>
		/// </summary>
		DCOMPOSITION_OPACITY_MODE_LAYER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// The opacity value is multiplied with the effective opacity of the parent visual and the result is then individually applied to
		/// each piece of content in this visual’s sub-tree.
		/// </para>
		/// </summary>
		DCOMPOSITION_OPACITY_MODE_MULTIPLY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xffffffff</para>
		/// <para>The opacity mode is the same as that of the target visual’s parent visual.</para>
		/// </summary>
		DCOMPOSITION_OPACITY_MODE_INHERIT = 0xffffffff,
	}

	/// <summary>Describes timing and composition statistics for a compositor frame.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomptypes/ns-dcomptypes-composition_frame_stats typedef struct
	// tagCOMPOSITION_FRAME_STATS { UINT64 startTime; UINT64 targetTime; UINT64 framePeriod; } COMPOSITION_FRAME_STATS;
	[PInvokeData("dcomptypes.h", MSDNShortId = "NS:dcomptypes.tagCOMPOSITION_FRAME_STATS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct COMPOSITION_FRAME_STATS
	{
		/// <summary>
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>The time the frame started.</para>
		/// </summary>
		public ulong startTime;

		/// <summary>
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>The frame's target time.</para>
		/// </summary>
		public ulong targetTime;

		/// <summary>
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>The amount of time the frame took.</para>
		/// </summary>
		public ulong framePeriod;
	}

	/// <summary>Describes timing and composition information.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomptypes/ns-dcomptypes-composition_stats typedef struct tagCOMPOSITION_STATS {
	// UINT presentCount; UINT refreshCount; UINT virtualRefreshCount; UINT64 time; } COMPOSITION_STATS;
	[PInvokeData("dcomptypes.h", MSDNShortId = "NS:dcomptypes.tagCOMPOSITION_STATS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct COMPOSITION_STATS
	{
		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The running total count of times that a frame was presented to the target.</para>
		/// </summary>
		public uint presentCount;

		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The running total count of v-blanks at which the last frame was presented to the target.</para>
		/// </summary>
		public uint refreshCount;

		/// <summary>Type: <b><c>UINT</c></b></summary>
		public uint virtualRefreshCount;

		/// <summary>Type: <b><c>UINT64</c></b></summary>
		public ulong time;
	}

	/// <summary>Contains information about a composition render target.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomptypes/ns-dcomptypes-composition_target_id typedef struct
	// tagCOMPOSITION_TARGET_ID { bool operator==( const tagCOMPOSITION_TARGET_ID &amp; rhs ); bool operator!=( const
	// tagCOMPOSITION_TARGET_ID &amp; rhs ); LUID displayAdapterLuid; LUID renderAdapterLuid; UINT vidPnSourceId; UINT vidPnTargetId; UINT
	// uniqueId; } COMPOSITION_TARGET_ID;
	[PInvokeData("dcomptypes.h", MSDNShortId = "NS:dcomptypes.tagCOMPOSITION_TARGET_ID")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct COMPOSITION_TARGET_ID : IEquatable<COMPOSITION_TARGET_ID>
	{
		/// <summary>
		/// <para>Type: <b><c>LUID</c></b></para>
		/// <para>The locally unique identifier (LUID) of the display adapter to which the monitor is connected.</para>
		/// </summary>
		public LUID displayAdapterLuid;

		/// <summary>
		/// <para>Type: <b><c>LUID</c></b></para>
		/// <para>The locally unique identifier (LUID) of the render adapter.</para>
		/// </summary>
		public LUID renderAdapterLuid;

		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The unique ID of the video present source.</para>
		/// </summary>
		public uint vidPnSourceId;

		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The unique ID of the video present target.</para>
		/// </summary>
		public uint vidPnTargetId;

		/// <summary>A unique identifier for this <c>COMPOSITION_TARGET_ID</c>.</summary>
		public uint uniqueId;

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is COMPOSITION_TARGET_ID iD && Equals(iD);

		/// <inheritdoc/>
		public readonly bool Equals(COMPOSITION_TARGET_ID iD) => displayAdapterLuid == iD.displayAdapterLuid &&
			renderAdapterLuid == iD.renderAdapterLuid && vidPnSourceId == iD.vidPnSourceId && vidPnTargetId == iD.vidPnTargetId &&
			(uniqueId == iD.uniqueId || uniqueId == 0 || iD.uniqueId == 0);

		/// <inheritdoc/>
		public override int GetHashCode() => HashCode.Combine(displayAdapterLuid, renderAdapterLuid, vidPnSourceId, vidPnTargetId, uniqueId);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(COMPOSITION_TARGET_ID left, COMPOSITION_TARGET_ID right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(COMPOSITION_TARGET_ID left, COMPOSITION_TARGET_ID right) => !(left == right);
	}

	/// <summary>Contains per-target information for a composition frame and render target.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomptypes/ns-dcomptypes-composition_target_stats typedef struct
	// tagCOMPOSITION_TARGET_STATS { UINT outstandingPresents; UINT64 presentTime; UINT64 vblankDuration; COMPOSITION_STATS presentedStats;
	// COMPOSITION_STATS completedStats; } COMPOSITION_TARGET_STATS;
	[PInvokeData("dcomptypes.h", MSDNShortId = "NS:dcomptypes.tagCOMPOSITION_TARGET_STATS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct COMPOSITION_TARGET_STATS
	{
		/// <summary>Type: <b><c>UINT</c></b></summary>
		public uint outstandingPresents;

		/// <summary>Type: <b><c>UINT64</c></b></summary>
		public ulong presentTime;

		/// <summary>Type: <b><c>UINT64</c></b></summary>
		public ulong vblankDuration;

		/// <summary>Type: <b><c>COMPOSITION_STATS</c></b></summary>
		public COMPOSITION_STATS presentedStats;

		/// <summary>Type: <b><c>COMPOSITION_STATS</c></b></summary>
		public COMPOSITION_STATS completedStats;
	}

	/// <summary>Describes timing and composition statistics for a frame.</summary>
	/// <remarks>
	/// The <c>IDCompositionDevice::GetFrameStatistics</c> method fills this structure. An application can use the information in this
	/// structure to estimate the timestamp of the next few frames that will be started by the composition engine. Note that this is only an
	/// estimate because the composition engine may or may not compose the next frame, depending on whether any active animations or other
	/// work are pending for that frame. In addition, the composition engine may change frame rates according to the cost of composing
	/// individual frames.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomptypes/ns-dcomptypes-dcomposition_frame_statistics typedef struct {
	// LARGE_INTEGER lastFrameTime; DXGI_RATIONAL currentCompositionRate; LARGE_INTEGER currentTime; LARGE_INTEGER timeFrequency;
	// LARGE_INTEGER nextEstimatedFrameTime; } DCOMPOSITION_FRAME_STATISTICS;
	[PInvokeData("dcomptypes.h", MSDNShortId = "NS:dcomptypes.DCOMPOSITION_FRAME_STATISTICS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DCOMPOSITION_FRAME_STATISTICS
	{
		/// <summary>
		/// <para>Type: <b><c>LARGE_INTEGER</c></b></para>
		/// <para>The time stamp of the last batch of commands to be processed by the composition engine.</para>
		/// </summary>
		public long lastFrameTime;

		/// <summary>
		/// <para>Type: <b><c>DXGI_RATIONAL</c></b></para>
		/// <para>The rate at which the composition engine is producing frames, in frames per second.</para>
		/// </summary>
		public DXGI_RATIONAL currentCompositionRate;

		/// <summary>
		/// <para>Type: <b><c>LARGE_INTEGER</c></b></para>
		/// <para>The current time as computed by the <c>QueryPerformanceCounter</c> function.</para>
		/// </summary>
		public long currentTime;

		/// <summary>
		/// <para>Type: <b><c>LARGE_INTEGER</c></b></para>
		/// <para>The units in which the <b>lastFrameTime</b> and <b>currentTime</b> members are specified, in Hertz.</para>
		/// </summary>
		public long timeFrequency;

		/// <summary>
		/// <para>Type: <b><c>LARGE_INTEGER</c></b></para>
		/// <para>The estimated time when the next frame will be displayed.</para>
		/// </summary>
		public long nextEstimatedFrameTime;
	}
}