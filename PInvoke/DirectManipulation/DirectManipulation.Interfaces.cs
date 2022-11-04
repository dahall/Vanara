using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

/// <summary>Items from the DirectManipulation.dll.</summary>
public static partial class DirectManipulation
{
	/// <summary>Represents the auto-scroll animation behavior of content as it approaches the boundary of a given axis or axes.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationautoscrollbehavior
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationAutoScrollBehavior")]
	[ComImport, Guid("6D5954D4-2003-4356-9B31-D051C9FF0AF7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDirectManipulationAutoScrollBehavior
	{
		/// <summary>Performs the auto-scroll animation for the viewport this behavior is attached to.</summary>
		/// <param name="motionTypes">
		/// A combination of <c>DIRECTMANIPULATION_MOTION_TRANSLATEX</c> and <c>DIRECTMANIPULATION_MOTION_TRANSLATEY</c> from
		/// DIRECTMANIPULATION_MOTION_TYPES. <c>DIRECTMANIPULATION_MOTION_NONE</c> cannot be specified.
		/// </param>
		/// <param name="scrollMotion">One of the values from DIRECTMANIPULATION_AUTOSCROLL_CONFIGURATION.</param>
		/// <remarks>
		/// <para>
		/// <c>SetConfiguration</c> takes effect immediately. If the content is not in inertia, and
		/// <c>DIRECTMANIPULATION_AUTOSCROLL_CONFIGURATION_STOP</c> is specified for <c>scrollMotion</c>, then this method returns S_FALSE.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationautoscrollbehavior-setconfiguration
		// HRESULT SetConfiguration( [in] DIRECTMANIPULATION_MOTION_TYPES motionTypes, [in] DIRECTMANIPULATION_AUTOSCROLL_CONFIGURATION
		// scrollMotion );
		void SetConfiguration(DIRECTMANIPULATION_MOTION_TYPES motionTypes, DIRECTMANIPULATION_AUTOSCROLL_CONFIGURATION scrollMotion);
	}

	/// <summary>
	/// Represents a compositor object that associates manipulated content with a drawing surface, such as canvas (Windows app using
	/// JavaScript) or Canvas (Windows Store app using C++, C#, or Visual Basic).
	/// </summary>
	/// <remarks>
	/// <para>
	/// The content of a Direct Manipulation viewport must be manually updated during an input event for custom implementations of
	/// <c>IDirectManipulationCompositor</c>. Call Update to redraw the content within the viewport.
	/// </para>
	/// <para>You specify manual mode on a viewport by calling either of these functions:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>SetViewportOptions, with DIRECTMANIPULATION_VIEWPORT_OPTIONS_MANUALUPDATE specified.</term>
	/// </item>
	/// <item>
	/// <term>SetUpdateMode, with DIRECTMANIPULATION_INPUT_MODE_MANUAL specified.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationcompositor
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationCompositor")]
	[ComImport, Guid("537A0825-0387-4EFA-B62F-71EB1F085A7E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(DCompManipulationCompositor))]
	public interface IDirectManipulationCompositor
	{
		/// <summary>
		/// Associates content (owned by the caller) with the compositor, assigns a composition device to the content, and specifies the
		/// position of the content in the composition tree relative to other composition visuals.
		/// </summary>
		/// <param name="content">
		/// <para>The content to add to the composition tree.</para>
		/// <para><c>content</c> is placed between <c>parentVisual</c> and <c>childVisual</c> in the composition tree.</para>
		/// </param>
		/// <param name="device">
		/// <para>The device used to compose the content.</para>
		/// <para><c>Note</c><c>device</c> is created by the application.</para>
		/// </param>
		/// <param name="parentVisual">
		/// <para>The parent visuals in the composition tree of the content being added.</para>
		/// <para><c>parentVisual</c> must also be a parent of <c>childVisual</c> in the composition tree.</para>
		/// </param>
		/// <param name="childVisual">
		/// <para>The child visuals in the composition tree of the content being added.</para>
		/// <para><c>parentVisual</c> must also be a parent of <c>childVisual</c> in the composition tree.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method inserts a small visual tree (owned by the Direct Manipulation device) between the <c>parentVisual</c> and the
		/// <c>childVisual</c>. Transforms can then be applied to the inserted content.
		/// </para>
		/// <para>
		/// All content, regardless of type, must be added to the compositor. This can be primary content, obtained from the viewport by
		/// calling GetPrimaryContent, or secondary content, such as a panning indicator, created by calling CreateContent.
		/// </para>
		/// <para>If the application uses a system-provided IDirectManipulationCompositor:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>device</c> must be an IDCompositionDevice object, and parent and child visuals must be IDCompositionVisual objects.</term>
		/// </item>
		/// <item>
		/// <term><c>device</c>, <c>parentVisual</c>, and <c>childVisual</c> cannot be NULL.</term>
		/// </item>
		/// <item>
		/// <term><c>device</c>, <c>parentVisual</c>, and <c>childVisual</c> objects are created and owned by the application.</term>
		/// </item>
		/// <item>
		/// <term>
		/// When content is added to the composition tree using this method, the new composition visuals are inserted between
		/// <c>parentVisual</c> and <c>childVisual</c>. The new visuals should not be destroyed until they are disassociated from the
		/// compositor with RemoveContent.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If the application uses a custom implementation of IDirectManipulationCompositor:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <c>device</c>, <c>parentVisual</c>, and <c>childVisual</c> must be a valid type for the compositor. They do not have to be
		/// IDCompositionDevice or IDCompositionVisual objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>device</c>, <c>parentVisual</c>, and <c>childVisual</c> can be NULL, depending on the compositor.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationcompositor-addcontent
		// HRESULT AddContent( [in] IDirectManipulationContent *content, [in, optional] IUnknown *device, [in] IUnknown *parentVisual, [in]
		// IUnknown *childVisual );
		void AddContent([In] IDirectManipulationContent content, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object device,
			[In, Optional, MarshalAs(UnmanagedType.IUnknown)] object parentVisual, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object childVisual);

		/// <summary>Removes content from the compositor.</summary>
		/// <param name="content">The content to remove from the composition tree.</param>
		/// <remarks>
		/// This method removes content added with AddContent and restores the original relationships between parent visuals and child
		/// visuals in the composition tree. In other words, <c>RemoveContent</c> undoes <c>AddContent</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationcompositor-removecontent
		// HRESULT RemoveContent( [in] IDirectManipulationContent *content );
		void RemoveContent([In] IDirectManipulationContent content);

		/// <summary>Sets the update manager used to send compositor updates to Direct Manipulation.</summary>
		/// <param name="updateManager">The update manager.</param>
		/// <remarks>
		/// <para>Retrieve <c>updateManager</c> by calling GetUpdateManager.</para>
		/// <para>Call this method during Direct Manipulation initialization to connect the compositor to the <c>update manager</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationcompositor-setupdatemanager
		// HRESULT SetUpdateManager( [in] IDirectManipulationUpdateManager *updateManager );
		void SetUpdateManager([In] IDirectManipulationUpdateManager updateManager);

		/// <summary>Commits all pending updates in the compositor to the system for rendering.</summary>
		/// <remarks>
		/// This method enables Direct Manipulation to flush any pending changes to its visuals before a system event, such as a process suspension.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationcompositor-flush
		// HRESULT Flush();
		void Flush();
	}

	/// <summary>Represents a compositor object that associates manipulated content with drawing surfaces across multiple processes.</summary>
	/// <remarks>
	/// <para>
	/// The content of a Direct Manipulation viewport must be manually updated during an input event for custom implementations of
	/// <c>IDirectManipulationCompositor2</c>. Call Update to redraw the content within the viewport.
	/// </para>
	/// <para>You specify manual mode on a viewport by calling either of these functions:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>SetViewportOptions, with DIRECTMANIPULATION_VIEWPORT_OPTIONS_MANUALUPDATE specified.</term>
	/// </item>
	/// <item>
	/// <term>SetUpdateMode, with DIRECTMANIPULATION_INPUT_MODE_MANUAL specified.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationcompositor2
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationCompositor2")]
	[ComImport, Guid("D38C7822-F1CB-43CB-B4B9-AC0C767A412E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(DCompManipulationCompositor))]
	public interface IDirectManipulationCompositor2 : IDirectManipulationCompositor
	{
		/// <summary>
		/// Associates content (owned by the caller) with the compositor, assigns a composition device to the content, and specifies the
		/// position of the content in the composition tree relative to other composition visuals.
		/// </summary>
		/// <param name="content">
		/// <para>The content to add to the composition tree.</para>
		/// <para><c>content</c> is placed between <c>parentVisual</c> and <c>childVisual</c> in the composition tree.</para>
		/// </param>
		/// <param name="device">
		/// <para>The device used to compose the content.</para>
		/// <para><c>Note</c><c>device</c> is created by the application.</para>
		/// </param>
		/// <param name="parentVisual">
		/// <para>The parent visuals in the composition tree of the content being added.</para>
		/// <para><c>parentVisual</c> must also be a parent of <c>childVisual</c> in the composition tree.</para>
		/// </param>
		/// <param name="childVisual">
		/// <para>The child visuals in the composition tree of the content being added.</para>
		/// <para><c>parentVisual</c> must also be a parent of <c>childVisual</c> in the composition tree.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method inserts a small visual tree (owned by the Direct Manipulation device) between the <c>parentVisual</c> and the
		/// <c>childVisual</c>. Transforms can then be applied to the inserted content.
		/// </para>
		/// <para>
		/// All content, regardless of type, must be added to the compositor. This can be primary content, obtained from the viewport by
		/// calling GetPrimaryContent, or secondary content, such as a panning indicator, created by calling CreateContent.
		/// </para>
		/// <para>If the application uses a system-provided IDirectManipulationCompositor:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>device</c> must be an IDCompositionDevice object, and parent and child visuals must be IDCompositionVisual objects.</term>
		/// </item>
		/// <item>
		/// <term><c>device</c>, <c>parentVisual</c>, and <c>childVisual</c> cannot be NULL.</term>
		/// </item>
		/// <item>
		/// <term><c>device</c>, <c>parentVisual</c>, and <c>childVisual</c> objects are created and owned by the application.</term>
		/// </item>
		/// <item>
		/// <term>
		/// When content is added to the composition tree using this method, the new composition visuals are inserted between
		/// <c>parentVisual</c> and <c>childVisual</c>. The new visuals should not be destroyed until they are disassociated from the
		/// compositor with RemoveContent.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If the application uses a custom implementation of IDirectManipulationCompositor:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <c>device</c>, <c>parentVisual</c>, and <c>childVisual</c> must be a valid type for the compositor. They do not have to be
		/// IDCompositionDevice or IDCompositionVisual objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>device</c>, <c>parentVisual</c>, and <c>childVisual</c> can be NULL, depending on the compositor.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationcompositor-addcontent
		// HRESULT AddContent( [in] IDirectManipulationContent *content, [in, optional] IUnknown *device, [in] IUnknown *parentVisual, [in]
		// IUnknown *childVisual );
		new void AddContent([In] IDirectManipulationContent content, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object device,
			[In, Optional, MarshalAs(UnmanagedType.IUnknown)] object parentVisual, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object childVisual);

		/// <summary>Removes content from the compositor.</summary>
		/// <param name="content">The content to remove from the composition tree.</param>
		/// <remarks>
		/// This method removes content added with AddContent and restores the original relationships between parent visuals and child
		/// visuals in the composition tree. In other words, <c>RemoveContent</c> undoes <c>AddContent</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationcompositor-removecontent
		// HRESULT RemoveContent( [in] IDirectManipulationContent *content );
		new void RemoveContent([In] IDirectManipulationContent content);

		/// <summary>Sets the update manager used to send compositor updates to Direct Manipulation.</summary>
		/// <param name="updateManager">The update manager.</param>
		/// <remarks>
		/// <para>Retrieve <c>updateManager</c> by calling GetUpdateManager.</para>
		/// <para>Call this method during Direct Manipulation initialization to connect the compositor to the <c>update manager</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationcompositor-setupdatemanager
		// HRESULT SetUpdateManager( [in] IDirectManipulationUpdateManager *updateManager );
		new void SetUpdateManager([In] IDirectManipulationUpdateManager updateManager);

		/// <summary>Commits all pending updates in the compositor to the system for rendering.</summary>
		/// <remarks>
		/// This method enables Direct Manipulation to flush any pending changes to its visuals before a system event, such as a process suspension.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationcompositor-flush
		// HRESULT Flush();
		new void Flush();

		/// <summary>
		/// Associates content (owned by the component host) with the compositor, assigns a composition device to the content, and specifies
		/// the position of the content in the composition tree relative to other composition visuals. Represents a compositor object that
		/// associates manipulated content with drawing surfaces across multiple processes.
		/// </summary>
		/// <param name="content">
		/// <para>The content to add to the composition tree.</para>
		/// <para><c>content</c> is placed between <c>parentVisual</c> and <c>childVisual</c> in the composition tree.</para>
		/// <para>Only primary content, created at the same time as the viewport, is valid.</para>
		/// </param>
		/// <param name="device">
		/// <para>The device used to compose the content.</para>
		/// <para><c>Note</c><c>device</c> is created by the application.</para>
		/// </param>
		/// <param name="parentVisual">
		/// <para>The parent visuals in the composition tree of the content being added.</para>
		/// <para><c>parentVisual</c> must also be a parent of <c>childVisual</c> in the composition tree.</para>
		/// </param>
		/// <param name="childVisual">
		/// <para>The child visuals in the composition tree of the content being added.</para>
		/// <para><c>parentVisual</c> must also be a parent of <c>childVisual</c> in the composition tree.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method inserts a small visual tree (owned by the Direct Manipulation device) between the <c>parentVisual</c> and the
		/// <c>childVisual</c>. Transforms can then be applied to the inserted content.
		/// </para>
		/// <para>All content, regardless of type, must be added to the compositor.</para>
		/// <para>If the application uses a system-provided IDirectManipulationCompositor:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>device</c> must be an IDCompositionDevice object, and parent and child visuals must be IDCompositionVisual objects.</term>
		/// </item>
		/// <item>
		/// <term><c>device</c>, <c>parentVisual</c>, and <c>childVisual</c> cannot be NULL.</term>
		/// </item>
		/// <item>
		/// <term><c>device</c>, <c>parentVisual</c>, and <c>childVisual</c> objects are created and owned by the application.</term>
		/// </item>
		/// <item>
		/// <term>
		/// When content is added to the composition tree using this method, the new composition visuals are inserted between
		/// <c>parentVisual</c> and <c>childVisual</c>. The new visuals should not be destroyed until they are disassociated from the
		/// compositor with RemoveContent.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If the application uses a custom implementation of IDirectManipulationCompositor:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <c>device</c>, <c>parentVisual</c>, and <c>childVisual</c> must be a valid type for the compositor. They do not have to be
		/// IDCompositionDevice or IDCompositionVisual objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>device</c>, <c>parentVisual</c>, and <c>childVisual</c> can be NULL, depending on the compositor.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The cross-process pointer events (WM_POINTERROUTEDAWAY, WM_POINTERROUTEDRELEASED, and WM_POINTERROUTEDTO) should be handled appropriately.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationcompositor2-addcontentwithcrossprocesschaining
		// HRESULT AddContentWithCrossProcessChaining( [in] IDirectManipulationPrimaryContent *content, [in] IUnknown *device, [in] IUnknown
		// *parentVisual, [in] IUnknown *childVisual );
		void AddContentWithCrossProcessChaining([In] IDirectManipulationPrimaryContent content, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object device,
			[In, Optional, MarshalAs(UnmanagedType.IUnknown)] object parentVisual, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object childVisual);
	}

	/// <summary>
	/// <para>Encapsulates content inside a viewport, where content represents a visual surface clipped inside the viewport.</para>
	/// <para>The content has a set of transforms that controls the visual movement of the surface during manipulation and inertia.</para>
	/// <para>
	/// <c>Note</c> When implementing a Direct Manipulation object, ensure that the IUnknown implementation supports multithreading through
	/// thread-safe reference counting. For more information, see InterlockedIncrement and InterlockedDecrement.
	/// </para>
	/// </summary>
	/// <remarks>The system provides an implementation of <c>IDirectManipulationContent</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationcontent
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationContent")]
	[ComImport, Guid("B89962CB-3D89-442B-BB58-5098FA0F9F16"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDirectManipulationContent
	{
		/// <summary>Retrieves the bounding rectangle of the content, relative to the bounding rectangle of the viewport (if defined).</summary>
		/// <returns>The bounding rectangle of the content.</returns>
		/// <remarks>
		/// If the bounding rectangle has not been set using SetContentRect, then UI_E_VALUE_NOT_SET is returned. However, the actual content
		/// rectangle is (-FLT_MAX, -FLT_MAX, FLT_MAX, FLT_MAX).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationcontent-getcontentrect
		// HRESULT GetContentRect( [out] RECT *contentSize );
		RECT GetContentRect();

		/// <summary>Specifies the bounding rectangle of the content, relative to its viewport.</summary>
		/// <param name="contentSize">The bounding rectangle of the content.</param>
		/// <remarks>The default bounding rectangle is (-FLT_MAX, -FLT_MAX, FLT_MAX, FLT_MAX).</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationcontent-setcontentrect
		// HRESULT SetContentRect( [in] const RECT *contentSize );
		void SetContentRect(in RECT contentSize);

		/// <summary>Retrieves the viewport that contains the content.</summary>
		/// <param name="riid">A reference to the identifier of the interface to use.</param>
		/// <returns>The viewport object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationcontent-getviewport
		// HRESULT GetViewport( [in] REFIID riid, [out, retval] void **object );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object GetViewport(in Guid riid);

		/// <summary>Retrieves the tag object set on this content.</summary>
		/// <param name="riid">A reference to the identifier of the interface to use. The tag object typically implements this interface.</param>
		/// <param name="object">The tag object.</param>
		/// <param name="id">The ID portion of the tag.</param>
		/// <remarks>
		/// <para>
		/// <c>GetTag</c> and SetTag are useful for associating an external COM object with the content without an external mapping between
		/// the two. They can also be used to pass information to callbacks generated for the content.
		/// </para>
		/// <para><c>GetTag</c> queries the tag value for the specified interface and returns a pointer to that interface.</para>
		/// <para>
		/// A tag is a pairing of an integer ID ( <c>id</c>) with a Component Object Model (COM) object ( <c>object</c>). It can be used by
		/// an app to identify a motion. The parameters are optional, so that the method can return both parts of the tag, the identifier
		/// portion, or the tag object.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example shows the syntax for this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationcontent-gettag
		// HRESULT GetTag( [in] REFIID riid, [out, optional] void **object, [out, optional] UINT32 *id );
		void GetTag(in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object @object, out uint id);

		/// <summary>Specifies the tag object for the content.</summary>
		/// <param name="object">The object portion of the tag.</param>
		/// <param name="id">The ID portion of the tag.</param>
		/// <remarks>
		/// <para>
		/// GetTag and <c>SetTag</c> are useful for associating an external COM object with the content without an external mapping between
		/// the two. They can also be used to pass information to callbacks generated for the content.
		/// </para>
		/// <para>
		/// A tag is a pairing of an integer ID ( <c>id</c>) with a Component Object Model (COM) object ( <c>object</c>). It can be used by
		/// an app to store and retrieve an arbitrary object associated with the content.
		/// </para>
		/// <para>The <c>object</c> parameter is optional, so that the method can set just the identifier portion.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationcontent-settag
		// HRESULT SetTag( [in] IUnknown *object, [in] UINT32 id );
		void SetTag([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object @object, uint id);

		/// <summary>Gets the final transform applied to the content.</summary>
		/// <param name="matrix">The transform matrix.</param>
		/// <param name="pointCount">
		/// The size of the transform matrix. This value is always 6, because a 3x2 matrix is used for all direct manipulation transforms.
		/// </param>
		/// <remarks>
		/// <para>This transform might contain the other custom curves applied during manipulation and inertia.</para>
		/// <para>This transform contains both the content transform and the sync transform set with SyncContentTransform.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationcontent-getoutputtransform
		// HRESULT GetOutputTransform( [out] float *matrix, [in] DWORD pointCount );
		void GetOutputTransform([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] matrix, uint pointCount = 6);

		/// <summary>Retrieves the transform applied to the content.</summary>
		/// <param name="matrix">The transform matrix.</param>
		/// <param name="pointCount">
		/// The size of the transform matrix. This value is always 6, because a 3x2 matrix is used for all direct manipulation transforms.
		/// </param>
		/// <remarks>
		/// <para>This transform contains the default overpan and bounce curves during manipulation and inertia.</para>
		/// <para>This transform does not contain the sync transform set with SyncContentTransform.</para>
		/// <para>When this method returns, the format of <c>matrix</c> is:</para>
		/// <para><c>matrix</c><c>matrix</c><c>matrix</c><c>matrix</c><c>matrix</c><c>matrix</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationcontent-getcontenttransform
		// HRESULT GetContentTransform( [out] float *matrix, [in] DWORD pointCount );
		void GetContentTransform([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] matrix, uint pointCount = 6);

		/// <summary>Modifies the content transform while maintaining the output transform.</summary>
		/// <param name="matrix">The transform matrix.</param>
		/// <param name="pointCount">
		/// The size of the transform matrix. This value is always 6, because a 3x2 matrix is used for all direct manipulation transforms.
		/// </param>
		/// <remarks>
		/// <para>This method will fail if the viewport state is DIRECTMANIPULATION_RUNNING, <c>DIRECTMANIPULATION_INERTIA</c> or <c>DIRECTMANIPULATION_SUSPENDED</c>.</para>
		/// <para>
		/// This method is useful when the application wants to apply transforms on top of the content transforms at the end of a
		/// manipulation, while preserving the visual output transform of the content.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationcontent-synccontenttransform
		// HRESULT SyncContentTransform( [in] const float *matrix, [in] DWORD pointCount );
		void SyncContentTransform([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] matrix, uint pointCount = 6);
	}

	/// <summary>
	/// <para>Represents a service for managing associations between a contact and a viewport.</para>
	/// <para>
	/// SetContact is called when a WM_POINTERDOWN message is received. Upon receiving a <c>WM_POINTERDOWN</c>, the application can use the
	/// coordinates of the input to hit-test and determine the viewports to which the contact is associated.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationdefercontactservice
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationDeferContactService")]
	[ComImport, Guid("652D5C71-FE60-4A98-BE70-E5F21291E7F1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDirectManipulationDeferContactService
	{
		/// <summary>
		/// <para>Specifies the amount of time to defer the execution of a call to SetContact for this <c>pointerId</c>.</para>
		/// <para><c>DeferContact</c> must be called before SetContact.</para>
		/// </summary>
		/// <param name="pointerId">The ID of the pointer.</param>
		/// <param name="timeout">The duration of the deferral, in milliseconds. The maximum value is 500.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationdefercontactservice-defercontact
		// HRESULT DeferContact( [in] UINT32 pointerId, [in] UINT32 timeout );
		void DeferContact(uint pointerId, uint timeout);

		/// <summary>Cancel all scheduled calls to SetContact for this <c>pointerId</c>.</summary>
		/// <param name="pointerId">The ID of the pointer.</param>
		/// <remarks>This function fails if the timeout specified in DeferContact has already been reached.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationdefercontactservice-cancelcontact
		// HRESULT CancelContact( [in] UINT32 pointerId );
		void CancelContact(uint pointerId);

		/// <summary>Cancel the deferral set in DeferContact and process the scheduled SetContact call for this <c>pointerId</c>.</summary>
		/// <param name="pointerId">The ID of the pointer.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationdefercontactservice-canceldeferral
		// HRESULT CancelDeferral( [in] UINT32 pointerId );
		void CancelDeferral(uint pointerId);
	}

	/// <summary>
	/// <para>Represents behaviors for drag and drop interactions, which are triggered by cross-slide or press-and-hold gestures.</para>
	/// <para>Call AddBehavior to apply the behavior on a viewport and RemoveBehavior to remove it.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// If AddConfiguration, RemoveConfiguration, ActivateConfiguration, or SetManualGesture has been called successfully on a viewport,
	/// AddBehavior fails for the remaining lifetime of the viewport.
	/// </para>
	/// <para>
	/// Once the behavior is added to the viewport, calls to AddConfiguration, RemoveConfiguration, ActivateConfiguration, or
	/// SetManualGesture will fail until RemoveBehavior is called.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationdragdropbehavior
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationDragDropBehavior")]
	[ComImport, Guid("814B5AF5-C2C8-4270-A9B7-A198CE8D02FA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDirectManipulationDragDropBehavior
	{
		/// <summary>Sets the configuration of the drag-drop interaction for the viewport this behavior is attached to.</summary>
		/// <param name="configuration">
		/// <para>Combination of values from DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION.</para>
		/// <para>For the configuration to be valid, <c>configuration</c> must contain exactly one of the following three values:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_SELECT_ONLY</c></term>
		/// </item>
		/// <item>
		/// <term><c>DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_SELECT_DRAG</c></term>
		/// </item>
		/// <item>
		/// <term><c>DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_HOLD_DRAG</c></term>
		/// </item>
		/// </list>
		/// <para>
		/// If <c>DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_SELECT_ONLY</c> or <c>DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_SELECT_DRAG</c>
		/// is specified, one of <c>DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_VERTICAL</c> or
		/// <c>DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_HORIZONTAL</c> is required.
		/// </para>
		/// <para>
		/// If <c>DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_HOLD_DRAG</c> is specified, both
		/// <c>DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_VERTICAL</c> and <c>DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION_HORIZONTAL</c> are required.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The configuration of the behavior can be set before or after it has been added to a viewport. If a configuration change is made
		/// while an interaction is occurring, the new configuration takes effect on the next interaction.
		/// </para>
		/// <para>
		/// IDirectManipulationViewport::ActivateConfiguration should not be called prior to calling
		/// <c>IDirectManipulationDragDropBehavior::SetConfiguration</c>. This will result in unexpected behavior.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationdragdropbehavior-setconfiguration
		// HRESULT SetConfiguration( [in] DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION configuration );
		void SetConfiguration([In] DIRECTMANIPULATION_DRAG_DROP_CONFIGURATION configuration);

		/// <summary>Gets the status of the drag-drop interaction for the viewport this behavior is attached to.</summary>
		/// <returns>One of the values from DIRECTMANIPULATION_DRAG_DROP_STATUS.</returns>
		/// <remarks>This method returns the drag-drop status at the time of the call and not at the time when the return value is read.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationdragdropbehavior-getstatus
		// HRESULT GetStatus( [out, retval] DIRECTMANIPULATION_DRAG_DROP_STATUS *status );
		DIRECTMANIPULATION_DRAG_DROP_STATUS GetStatus();
	}

	/// <summary>
	/// <para>Defines methods to handle drag-drop behavior events.</para>
	/// <para>
	/// <c>Note</c> When implementing this interface, ensure that the IUnknown implementation supports multithreading through thread-safe
	/// reference counting. For more information, see InterlockedIncrement and InterlockedDecrement.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationdragdropeventhandler
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationDragDropEventHandler")]
	[ComImport, Guid("1FA11B10-701B-41AE-B5F2-49E36BD595AA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDirectManipulationDragDropEventHandler
	{
		/// <summary>Called when a status change happens in the viewport that the drag-and-drop behavior is attached to.</summary>
		/// <param name="viewport">The updated viewport.</param>
		/// <param name="current">The current state of the drag-drop interaction from DIRECTMANIPULATION_DRAG_DROP_STATUS.</param>
		/// <param name="previous">The previous state of the drag-drop interaction from DIRECTMANIPULATION_DRAG_DROP_STATUS.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// If a class is implementing IDirectManipulationViewportEventHandler it should also implement
		/// IDirectManipulationDragDropEventHandler if that viewport will use drag and drop. Direct Manipulation will query the
		/// <c>IDirectManipulationViewportEventHandler</c> instances to verify that they also implement <c>IDirectManipulationDragDropEventHandler</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationdragdropeventhandler-ondragdropstatuschange
		// HRESULT OnDragDropStatusChange( [in] IDirectManipulationViewport2 *viewport, [in] DIRECTMANIPULATION_DRAG_DROP_STATUS current,
		// [in] DIRECTMANIPULATION_DRAG_DROP_STATUS previous );
		[PreserveSig]
		HRESULT OnDragDropStatusChange([In] IDirectManipulationViewport2 viewport,
			[In] DIRECTMANIPULATION_DRAG_DROP_STATUS current, [In] DIRECTMANIPULATION_DRAG_DROP_STATUS previous);
	}

	/// <summary>
	/// Represents a time-keeping object that measures the latency of the composition infrastructure used by the application and provides
	/// this data to Direct Manipulation.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationframeinfoprovider
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationFrameInfoProvider")]
	[ComImport, Guid("fb759dba-6f4c-4c01-874e-19c8a05907f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDirectManipulationFrameInfoProvider
	{
		/// <summary>Retrieves the composition timing information from the compositor.</summary>
		/// <param name="time">The current time, in milliseconds.</param>
		/// <param name="processTime">The time, in milliseconds, when the compositor begins constructing the next frame.</param>
		/// <param name="compositionTime">
		/// The time, in milliseconds, when the compositor finishes composing and drawing the next frame on the screen.
		/// </param>
		/// <remarks>
		/// The system implementation of IDirectManipulationFrameInfoProvider uses DirectComposition. GetFrameStatistics is used to calculate
		/// the parameter values for <c>GetNextFrameInfo</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationframeinfoprovider-getnextframeinfo
		// HRESULT GetNextFrameInfo( [out] ULONGLONG *time, [out] ULONGLONG *processTime, [out] ULONGLONG *compositionTime );
		void GetNextFrameInfo(out ulong time, out ulong processTime, out ulong compositionTime);
	}

	/// <summary>
	/// <para>Defines methods to handle interactions when they are detected.</para>
	/// <para>
	/// <c>Note</c> When implementing this interface, ensure that the IUnknown implementation supports multithreading through thread-safe
	/// reference counting. For more information, see InterlockedIncrement and InterlockedDecrement.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationinteractioneventhandler
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationInteractionEventHandler")]
	[ComImport, Guid("E43F45B8-42B4-403E-B1F2-273B8F510830"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDirectManipulationInteractionEventHandler
	{
		/// <summary>Called when an interaction is detected.</summary>
		/// <param name="viewport">The viewport on which the interaction was detected.</param>
		/// <param name="interaction">One of the values from DIRECTMANIPULATION_INTERACTION_TYPE.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationinteractioneventhandler-oninteraction
		// HRESULT OnInteraction( [in] IDirectManipulationViewport2 *viewport, [in] DIRECTMANIPULATION_INTERACTION_TYPE interaction );
		[PreserveSig]
		HRESULT OnInteraction([In] IDirectManipulationViewport2 viewport, [In] DIRECTMANIPULATION_INTERACTION_TYPE interaction);
	}

	/// <summary>
	/// <para>Provides access to all the Direct Manipulation features and APIs available to the client application.</para>
	/// <para>
	/// This is the first COM object (the object factory) created by the application to retrieve other COM objects in the Direct Manipulation
	/// API surface. It also serves to activate and deactivate Direct Manipulation functionality on a per-HWND basis.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationmanager
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationManager")]
	[ComImport, Guid("FBF5D3B4-70C7-4163-9322-5A6F660D6FBC"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(DirectManipulationManager))]
	public interface IDirectManipulationManager
	{
		/// <summary>Activates Direct Manipulation for processing input and handling callbacks on the specified window.</summary>
		/// <param name="window">The window in which to activate Direct Manipulation.</param>
		/// <remarks>
		/// <para>
		/// The manipulation manager is deactivated, by default. The manager does not receive or respond to input and callbacks until
		/// <c>Activate</c> is called for the window.
		/// </para>
		/// <para>Calls to <c>Activate</c> and Deactivate are reference counted.</para>
		/// <para>Examples</para>
		/// <para>The following example shows how to activate and deactivate input processing.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-activate
		// HRESULT Activate( [in] HWND window );
		void Activate([In] HWND window);

		/// <summary>Deactivates Direct Manipulation for processing input and handling callbacks on the specified window.</summary>
		/// <param name="window">The window in which to deactivate input.</param>
		/// <remarks>
		/// <para>
		/// The manipulation manager is deactivated by default. The manager does not receive or respond to input until Activate is called.
		/// The manipulation manager should be deactivated when the app does not receive or respond to input. For example, when the app is minimized.
		/// </para>
		/// <para>Calls to Activate and <c>Deactivate</c> are reference counted.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-deactivate
		// HRESULT Deactivate( [in] HWND window );
		void Deactivate([In] HWND window);

		/// <summary>Registers a dedicated thread for hit testing.</summary>
		/// <param name="window">The handle of the main app window (typically created from the UI thread).</param>
		/// <param name="hitTestWindow">
		/// The handle of the window in which hit testing is registered (should be created from the hit testing thread). Pass in nullptr to
		/// unregister a previously registered hit-test target.
		/// </param>
		/// <param name="type">
		/// One of the values from DIRECTMANIPULATION_HITTEST_TYPE. Specifies whether the UI window or the hit testing window (or both)
		/// receives the hit testing WM_POINTERDOWN message , and in what order.
		/// </param>
		/// <remarks>
		/// <para>
		/// Hit testing is typically performed on the application UI thread. The application receives a WM_POINTERDOWN message on which
		/// hit-testing is performed. If a manipulation is required, SetContact is called on one or more viewports. An application can use
		/// the <c>RegisterHitTestTarget</c> method to delegate this hit-testing responsibility to a separate hit-testing thread.
		/// </para>
		/// <para>
		/// Once a dedicated hit-test target is successfully registered, WM_POINTERDOWN messages are processed on the hit-testing thread. If
		/// a manipulation, such as pan or zoom, is required, SetContact is called from this thread.
		/// </para>
		/// <para>
		/// If SetContact is not called from the hit-testing thread, WM_POINTERDOWN messages may be processed on the UI thread, depending on
		/// the DIRECTMANIPULATION_HITTEST_TYPE specified during registration.
		/// </para>
		/// <para>
		/// If SetContact is not called by either the hit-test thread or the UI thread, Direct Manipulation ignores the input which is then
		/// handled on the UI thread.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-registerhittesttarget
		// HRESULT RegisterHitTestTarget( [in] HWND window, [in, optional] HWND hitTestWindow, [in] DIRECTMANIPULATION_HITTEST_TYPE type );
		void RegisterHitTestTarget([In] HWND window, [In, Optional] HWND hitTestWindow, [In] DIRECTMANIPULATION_HITTEST_TYPE type);

		/// <summary>Passes keyboard and mouse messages to the manipulation manager on the app's UI thread.</summary>
		/// <param name="message">The input message to process.</param>
		/// <returns><c>TRUE</c> if no further processing should be done with this message; otherwise, <c>FALSE</c>.</returns>
		/// <remarks>
		/// <para>Call this method for mouse and keyboard input.</para>
		/// <para>Examples</para>
		/// <para>The following example shows how to pass messages to the manipulation manager.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-processinput
		// HRESULT ProcessInput( [in] const MSG *message, [out, retval] BOOL *handled );
		bool ProcessInput(in MSG message);

		/// <summary>Gets a pointer to an IDirectManipulationUpdateManager object that receives compositor updates.</summary>
		/// <param name="riid">IID to the interface.</param>
		/// <returns>Pointer to the new IDirectManipulationUpdateManager object.</returns>
		/// <remarks>
		/// For the compositor to respond to update events from Direct Manipulation, you must associate IDirectManipulationUpdateManager to
		/// an IDirectManipulationCompositor object during initialization. Use <c>GetUpdateManager</c> to obtain a pointer to a
		/// <c>IDirectManipulationUpdateManager</c> object. Pass this pointer to the compositor using the SetUpdateManager method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-getupdatemanager
		// HRESULT GetUpdateManager( [in] REFIID riid, [out, retval] void **object );
		IDirectManipulationUpdateManager GetUpdateManager(in Guid riid);

		/// <summary>
		/// <para>The factory method that is used to create a new IDirectManipulationViewport object.</para>
		/// <para>The viewport manages the interaction state and mapping of input to output actions.</para>
		/// </summary>
		/// <param name="frameInfo">The frame info provider for the viewport.</param>
		/// <param name="window">The handle of the main app window to associate with the viewport.</param>
		/// <param name="riid">IID to the interface.</param>
		/// <returns>The new IDirectManipulationViewport object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-createviewport
		// HRESULT CreateViewport( [in, optional] IDirectManipulationFrameInfoProvider *frameInfo, [in] HWND window, [in] REFIID riid, [out,
		// retval] void **object );
		IDirectManipulationViewport CreateViewport([In, Optional] IDirectManipulationFrameInfoProvider frameInfo, [In] HWND window, in Guid riid);

		/// <summary>
		/// The factory method that is used to create an instance of secondary content (such as a panning indicator) inside a viewport.
		/// </summary>
		/// <param name="frameInfo">
		/// The frame info provider for the secondary content. This should match the frame info provider used to create the viewport.
		/// </param>
		/// <param name="clsid">Class identifier (CLSID) of the secondary content. This ID specifies the content type.</param>
		/// <param name="riid">IID of the interface.</param>
		/// <returns>The secondary content object that implements the specified interface.</returns>
		/// <remarks>
		/// <para>
		/// Primary content is automatically created at the same time as the viewport and has a one-to-one relationship to a viewport.
		/// Therefore, it is not possible to create, add, or remove primary content.
		/// </para>
		/// <para>
		/// Secondary content is created independently from the viewport. There is no limit to how much secondary content can be added or
		/// removed from a viewport. All secondary content transforms are derived from those supported by the primary content with specific
		/// rules applied based on the intended purpose of the element (identified by its Class identifier (CLSID)).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-createcontent
		// HRESULT CreateContent( [in, optional] IDirectManipulationFrameInfoProvider *frameInfo, [in] REFCLSID clsid, [in] REFIID riid,
		// [out, retval] void **object );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object CreateContent([In, Optional] IDirectManipulationFrameInfoProvider frameInfo, in Guid clsid, in Guid riid);
	}

	/// <summary>
	/// <para>
	/// Extends the IDirectManipulationManager interface that provides access to all the Direct Manipulation features and APIs available to
	/// the client application.
	/// </para>
	/// <para>The <c>IDirectManipulationManager2</c> interface adds support for configuration behaviors that can be attached to a viewport.</para>
	/// <para>
	/// <c>Note</c> To obtain an <c>IDirectManipulationManager2</c> interface pointer, QueryInterface on an existing
	/// IDirectManipulationManager interface pointer.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationmanager2
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationManager2")]
	[ComImport, Guid("FA1005E9-3D16-484C-BFC9-62B61E56EC4E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(DirectManipulationManager))]
	public interface IDirectManipulationManager2 : IDirectManipulationManager
	{
		/// <summary>Activates Direct Manipulation for processing input and handling callbacks on the specified window.</summary>
		/// <param name="window">The window in which to activate Direct Manipulation.</param>
		/// <remarks>
		/// <para>
		/// The manipulation manager is deactivated, by default. The manager does not receive or respond to input and callbacks until
		/// <c>Activate</c> is called for the window.
		/// </para>
		/// <para>Calls to <c>Activate</c> and Deactivate are reference counted.</para>
		/// <para>Examples</para>
		/// <para>The following example shows how to activate and deactivate input processing.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-activate
		// HRESULT Activate( [in] HWND window );
		new void Activate([In] HWND window);

		/// <summary>Deactivates Direct Manipulation for processing input and handling callbacks on the specified window.</summary>
		/// <param name="window">The window in which to deactivate input.</param>
		/// <remarks>
		/// <para>
		/// The manipulation manager is deactivated by default. The manager does not receive or respond to input until Activate is called.
		/// The manipulation manager should be deactivated when the app does not receive or respond to input. For example, when the app is minimized.
		/// </para>
		/// <para>Calls to Activate and <c>Deactivate</c> are reference counted.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-deactivate
		// HRESULT Deactivate( [in] HWND window );
		new void Deactivate([In] HWND window);

		/// <summary>Registers a dedicated thread for hit testing.</summary>
		/// <param name="window">The handle of the main app window (typically created from the UI thread).</param>
		/// <param name="hitTestWindow">
		/// The handle of the window in which hit testing is registered (should be created from the hit testing thread). Pass in nullptr to
		/// unregister a previously registered hit-test target.
		/// </param>
		/// <param name="type">
		/// One of the values from DIRECTMANIPULATION_HITTEST_TYPE. Specifies whether the UI window or the hit testing window (or both)
		/// receives the hit testing WM_POINTERDOWN message , and in what order.
		/// </param>
		/// <remarks>
		/// <para>
		/// Hit testing is typically performed on the application UI thread. The application receives a WM_POINTERDOWN message on which
		/// hit-testing is performed. If a manipulation is required, SetContact is called on one or more viewports. An application can use
		/// the <c>RegisterHitTestTarget</c> method to delegate this hit-testing responsibility to a separate hit-testing thread.
		/// </para>
		/// <para>
		/// Once a dedicated hit-test target is successfully registered, WM_POINTERDOWN messages are processed on the hit-testing thread. If
		/// a manipulation, such as pan or zoom, is required, SetContact is called from this thread.
		/// </para>
		/// <para>
		/// If SetContact is not called from the hit-testing thread, WM_POINTERDOWN messages may be processed on the UI thread, depending on
		/// the DIRECTMANIPULATION_HITTEST_TYPE specified during registration.
		/// </para>
		/// <para>
		/// If SetContact is not called by either the hit-test thread or the UI thread, Direct Manipulation ignores the input which is then
		/// handled on the UI thread.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-registerhittesttarget
		// HRESULT RegisterHitTestTarget( [in] HWND window, [in, optional] HWND hitTestWindow, [in] DIRECTMANIPULATION_HITTEST_TYPE type );
		new void RegisterHitTestTarget([In] HWND window, [In, Optional] HWND hitTestWindow, [In] DIRECTMANIPULATION_HITTEST_TYPE type);

		/// <summary>Passes keyboard and mouse messages to the manipulation manager on the app's UI thread.</summary>
		/// <param name="message">The input message to process.</param>
		/// <returns><c>TRUE</c> if no further processing should be done with this message; otherwise, <c>FALSE</c>.</returns>
		/// <remarks>
		/// <para>Call this method for mouse and keyboard input.</para>
		/// <para>Examples</para>
		/// <para>The following example shows how to pass messages to the manipulation manager.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-processinput
		// HRESULT ProcessInput( [in] const MSG *message, [out, retval] BOOL *handled );
		new bool ProcessInput(in MSG message);

		/// <summary>Gets a pointer to an IDirectManipulationUpdateManager object that receives compositor updates.</summary>
		/// <param name="riid">IID to the interface.</param>
		/// <returns>Pointer to the new IDirectManipulationUpdateManager object.</returns>
		/// <remarks>
		/// For the compositor to respond to update events from Direct Manipulation, you must associate IDirectManipulationUpdateManager to
		/// an IDirectManipulationCompositor object during initialization. Use <c>GetUpdateManager</c> to obtain a pointer to a
		/// <c>IDirectManipulationUpdateManager</c> object. Pass this pointer to the compositor using the SetUpdateManager method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-getupdatemanager
		// HRESULT GetUpdateManager( [in] REFIID riid, [out, retval] void **object );
		new IDirectManipulationUpdateManager GetUpdateManager(in Guid riid);

		/// <summary>
		/// <para>The factory method that is used to create a new IDirectManipulationViewport object.</para>
		/// <para>The viewport manages the interaction state and mapping of input to output actions.</para>
		/// </summary>
		/// <param name="frameInfo">The frame info provider for the viewport.</param>
		/// <param name="window">The handle of the main app window to associate with the viewport.</param>
		/// <param name="riid">IID to the interface.</param>
		/// <returns>The new IDirectManipulationViewport object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-createviewport
		// HRESULT CreateViewport( [in, optional] IDirectManipulationFrameInfoProvider *frameInfo, [in] HWND window, [in] REFIID riid, [out,
		// retval] void **object );
		new IDirectManipulationViewport CreateViewport([In, Optional] IDirectManipulationFrameInfoProvider frameInfo, [In] HWND window, in Guid riid);

		/// <summary>
		/// The factory method that is used to create an instance of secondary content (such as a panning indicator) inside a viewport.
		/// </summary>
		/// <param name="frameInfo">
		/// The frame info provider for the secondary content. This should match the frame info provider used to create the viewport.
		/// </param>
		/// <param name="clsid">Class identifier (CLSID) of the secondary content. This ID specifies the content type.</param>
		/// <param name="riid">IID of the interface.</param>
		/// <returns>The secondary content object that implements the specified interface.</returns>
		/// <remarks>
		/// <para>
		/// Primary content is automatically created at the same time as the viewport and has a one-to-one relationship to a viewport.
		/// Therefore, it is not possible to create, add, or remove primary content.
		/// </para>
		/// <para>
		/// Secondary content is created independently from the viewport. There is no limit to how much secondary content can be added or
		/// removed from a viewport. All secondary content transforms are derived from those supported by the primary content with specific
		/// rules applied based on the intended purpose of the element (identified by its Class identifier (CLSID)).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-createcontent
		// HRESULT CreateContent( [in, optional] IDirectManipulationFrameInfoProvider *frameInfo, [in] REFCLSID clsid, [in] REFIID riid,
		// [out, retval] void **object );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		new object CreateContent([In, Optional] IDirectManipulationFrameInfoProvider frameInfo, in Guid clsid, in Guid riid);

		/// <summary>Factory method to create a behavior.</summary>
		/// <param name="clsid">CLSID of the behavior. The CLSID specifies the type of behavior.</param>
		/// <param name="riid">The IID of the behavior interface to create.</param>
		/// <returns>The new behavior object that implements the specified interface.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager2-createbehavior
		// HRESULT CreateBehavior( [in] REFCLSID clsid, [in] REFIID riid, [out, retval] void **object );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object CreateBehavior(in Guid clsid, in Guid riid);
	}

	/// <summary>
	/// <para>
	/// Extends the IDirectManipulationManager2 interface that provides access to all the Direct Manipulation features and APIs available to
	/// the client application.
	/// </para>
	/// <para>The <c>IDirectManipulationManager3</c> interface adds support for retrieving an IDirectManipulationDeferContactService object.</para>
	/// <para>
	/// <c>Note</c> To obtain an <c>IDirectManipulationManager3</c> interface pointer, QueryInterface on an existing
	/// IDirectManipulationManager interface pointer.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationmanager3
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationManager3")]
	[ComImport, Guid("2CB6B33D-FFE8-488C-B750-FBDFE88DCA8C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(DirectManipulationManager))]
	public interface IDirectManipulationManager3 : IDirectManipulationManager2
	{
		/// <summary>Activates Direct Manipulation for processing input and handling callbacks on the specified window.</summary>
		/// <param name="window">The window in which to activate Direct Manipulation.</param>
		/// <remarks>
		/// <para>
		/// The manipulation manager is deactivated, by default. The manager does not receive or respond to input and callbacks until
		/// <c>Activate</c> is called for the window.
		/// </para>
		/// <para>Calls to <c>Activate</c> and Deactivate are reference counted.</para>
		/// <para>Examples</para>
		/// <para>The following example shows how to activate and deactivate input processing.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-activate
		// HRESULT Activate( [in] HWND window );
		new void Activate([In] HWND window);

		/// <summary>Deactivates Direct Manipulation for processing input and handling callbacks on the specified window.</summary>
		/// <param name="window">The window in which to deactivate input.</param>
		/// <remarks>
		/// <para>
		/// The manipulation manager is deactivated by default. The manager does not receive or respond to input until Activate is called.
		/// The manipulation manager should be deactivated when the app does not receive or respond to input. For example, when the app is minimized.
		/// </para>
		/// <para>Calls to Activate and <c>Deactivate</c> are reference counted.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-deactivate
		// HRESULT Deactivate( [in] HWND window );
		new void Deactivate([In] HWND window);

		/// <summary>Registers a dedicated thread for hit testing.</summary>
		/// <param name="window">The handle of the main app window (typically created from the UI thread).</param>
		/// <param name="hitTestWindow">
		/// The handle of the window in which hit testing is registered (should be created from the hit testing thread). Pass in nullptr to
		/// unregister a previously registered hit-test target.
		/// </param>
		/// <param name="type">
		/// One of the values from DIRECTMANIPULATION_HITTEST_TYPE. Specifies whether the UI window or the hit testing window (or both)
		/// receives the hit testing WM_POINTERDOWN message , and in what order.
		/// </param>
		/// <remarks>
		/// <para>
		/// Hit testing is typically performed on the application UI thread. The application receives a WM_POINTERDOWN message on which
		/// hit-testing is performed. If a manipulation is required, SetContact is called on one or more viewports. An application can use
		/// the <c>RegisterHitTestTarget</c> method to delegate this hit-testing responsibility to a separate hit-testing thread.
		/// </para>
		/// <para>
		/// Once a dedicated hit-test target is successfully registered, WM_POINTERDOWN messages are processed on the hit-testing thread. If
		/// a manipulation, such as pan or zoom, is required, SetContact is called from this thread.
		/// </para>
		/// <para>
		/// If SetContact is not called from the hit-testing thread, WM_POINTERDOWN messages may be processed on the UI thread, depending on
		/// the DIRECTMANIPULATION_HITTEST_TYPE specified during registration.
		/// </para>
		/// <para>
		/// If SetContact is not called by either the hit-test thread or the UI thread, Direct Manipulation ignores the input which is then
		/// handled on the UI thread.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-registerhittesttarget
		// HRESULT RegisterHitTestTarget( [in] HWND window, [in, optional] HWND hitTestWindow, [in] DIRECTMANIPULATION_HITTEST_TYPE type );
		new void RegisterHitTestTarget([In] HWND window, [In, Optional] HWND hitTestWindow, [In] DIRECTMANIPULATION_HITTEST_TYPE type);

		/// <summary>Passes keyboard and mouse messages to the manipulation manager on the app's UI thread.</summary>
		/// <param name="message">The input message to process.</param>
		/// <returns><c>TRUE</c> if no further processing should be done with this message; otherwise, <c>FALSE</c>.</returns>
		/// <remarks>
		/// <para>Call this method for mouse and keyboard input.</para>
		/// <para>Examples</para>
		/// <para>The following example shows how to pass messages to the manipulation manager.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-processinput
		// HRESULT ProcessInput( [in] const MSG *message, [out, retval] BOOL *handled );
		new bool ProcessInput(in MSG message);

		/// <summary>Gets a pointer to an IDirectManipulationUpdateManager object that receives compositor updates.</summary>
		/// <param name="riid">IID to the interface.</param>
		/// <returns>Pointer to the new IDirectManipulationUpdateManager object.</returns>
		/// <remarks>
		/// For the compositor to respond to update events from Direct Manipulation, you must associate IDirectManipulationUpdateManager to
		/// an IDirectManipulationCompositor object during initialization. Use <c>GetUpdateManager</c> to obtain a pointer to a
		/// <c>IDirectManipulationUpdateManager</c> object. Pass this pointer to the compositor using the SetUpdateManager method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-getupdatemanager
		// HRESULT GetUpdateManager( [in] REFIID riid, [out, retval] void **object );
		new IDirectManipulationUpdateManager GetUpdateManager(in Guid riid);

		/// <summary>
		/// <para>The factory method that is used to create a new IDirectManipulationViewport object.</para>
		/// <para>The viewport manages the interaction state and mapping of input to output actions.</para>
		/// </summary>
		/// <param name="frameInfo">The frame info provider for the viewport.</param>
		/// <param name="window">The handle of the main app window to associate with the viewport.</param>
		/// <param name="riid">IID to the interface.</param>
		/// <returns>The new IDirectManipulationViewport object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-createviewport
		// HRESULT CreateViewport( [in, optional] IDirectManipulationFrameInfoProvider *frameInfo, [in] HWND window, [in] REFIID riid, [out,
		// retval] void **object );
		new IDirectManipulationViewport CreateViewport([In, Optional] IDirectManipulationFrameInfoProvider frameInfo, [In] HWND window, in Guid riid);

		/// <summary>
		/// The factory method that is used to create an instance of secondary content (such as a panning indicator) inside a viewport.
		/// </summary>
		/// <param name="frameInfo">
		/// The frame info provider for the secondary content. This should match the frame info provider used to create the viewport.
		/// </param>
		/// <param name="clsid">Class identifier (CLSID) of the secondary content. This ID specifies the content type.</param>
		/// <param name="riid">IID of the interface.</param>
		/// <returns>The secondary content object that implements the specified interface.</returns>
		/// <remarks>
		/// <para>
		/// Primary content is automatically created at the same time as the viewport and has a one-to-one relationship to a viewport.
		/// Therefore, it is not possible to create, add, or remove primary content.
		/// </para>
		/// <para>
		/// Secondary content is created independently from the viewport. There is no limit to how much secondary content can be added or
		/// removed from a viewport. All secondary content transforms are derived from those supported by the primary content with specific
		/// rules applied based on the intended purpose of the element (identified by its Class identifier (CLSID)).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager-createcontent
		// HRESULT CreateContent( [in, optional] IDirectManipulationFrameInfoProvider *frameInfo, [in] REFCLSID clsid, [in] REFIID riid,
		// [out, retval] void **object );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		new object CreateContent([In, Optional] IDirectManipulationFrameInfoProvider frameInfo, in Guid clsid, in Guid riid);

		/// <summary>Factory method to create a behavior.</summary>
		/// <param name="clsid">CLSID of the behavior. The CLSID specifies the type of behavior.</param>
		/// <param name="riid">The IID of the behavior interface to create.</param>
		/// <returns>The new behavior object that implements the specified interface.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager2-createbehavior
		// HRESULT CreateBehavior( [in] REFCLSID clsid, [in] REFIID riid, [out, retval] void **object );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		new object CreateBehavior(in Guid clsid, in Guid riid);

		/// <summary>Retrieves an IDirectManipulationDeferContactService object.</summary>
		/// <param name="clsid">The IDirectManipulationDeferContactService CLSID.</param>
		/// <param name="riid">The IID of the IDirectManipulationDeferContactService to retrieve.</param>
		/// <returns>The IDirectManipulationDeferContactService object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationmanager3-getservice
		// HRESULT GetService( [in] REFCLSID clsid, [in] REFIID riid, [out, retval] void **object );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object GetService(in Guid clsid, in Guid riid);
	}

	/// <summary>
	/// Encapsulates the primary content inside a viewport. Primary content is the content specified during the creation of a viewport.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationprimarycontent
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationPrimaryContent")]
	[ComImport, Guid("C12851E4-1698-4625-B9B1-7CA3EC18630B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(DirectManipulationPrimaryContent))]
	public interface IDirectManipulationPrimaryContent
	{
		/// <summary>Specifies snap points for the inertia end position at uniform intervals.</summary>
		/// <param name="motion">One of the DIRECTMANIPULATION_MOTION_TYPES enumeration values.</param>
		/// <param name="interval">The interval between each snap point.</param>
		/// <param name="offset">The offset from the coordinate specified in SetSnapCoordinate.</param>
		/// <remarks>
		/// <para>Snap point locations are in content coordinate units.</para>
		/// <para>Specify snap points through SetSnapPoints or <c>SetSnapInterval</c>.</para>
		/// <para>
		/// If snap points are invalid (for example, outside of the content boundaries), they are ignored and the content is always within
		/// the content boundaries.
		/// </para>
		/// <para>
		/// Snap points are not at boundaries by default. If you wish for content to stop at a boundary, a snap point must be set at the boundary.
		/// </para>
		/// <para>Snap points set by <c>SetSnapInterval</c> can be cleared by calling <c>SetSnapInterval</c> with an interval of 0.0f.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example shows how to set the coordinate system for X translation snap points to the origin. Snap points are set
		/// every 45 pixels, beginning at the origin along the X-axis.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationprimarycontent-setsnapinterval
		// HRESULT SetSnapInterval( [in] DIRECTMANIPULATION_MOTION_TYPES motion, [in] float interval, [in] float offset );
		void SetSnapInterval([In] DIRECTMANIPULATION_MOTION_TYPES motion, [In] float interval, [In] float offset);

		/// <summary>Specifies the snap points for the inertia rest position.</summary>
		/// <param name="motion">
		/// One or more of the DIRECTMANIPULATION_MOTION_TYPES enumeration values. Only <c>DIRECTMANIPULATION_MOTION_TRANSLATE_X</c>,
		/// <c>DIRECTMANIPULATION_MOTION_TRANSLATE_Y</c>, or <c>DIRECTMANIPULATION_MOTION_ZOOM</c> are allowed.
		/// </param>
		/// <param name="points">
		/// An array of snap points within the boundaries of the content to snap to. Should be specified in increasing order relative to the
		/// origin set in SetSnapCoordinate.
		/// </param>
		/// <param name="pointCount">The size of the array of snap points. Should be greater than 0.</param>
		/// <remarks>
		/// If snap points are invalid (for example, outside of the content boundaries), they are ignored and the content is always within
		/// the content boundaries.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationprimarycontent-setsnappoints
		// HRESULT SetSnapPoints( [in] DIRECTMANIPULATION_MOTION_TYPES motion, [in] const float *points, [in] DWORD pointCount );
		void SetSnapPoints([In] DIRECTMANIPULATION_MOTION_TYPES motion, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[] points,
			uint pointCount);

		/// <summary>Specifies the type of snap point.</summary>
		/// <param name="motion">One or more of the DIRECTMANIPULATION_MOTION_TYPES enumeration values.</param>
		/// <param name="type">
		/// <para>One of the DIRECTMANIPULATION_SNAPPOINT_TYPE enumeration values.</para>
		/// <para>
		/// If set to <c>DIRECTMANIPULATION_SNAPPOINT_TYPE_NONE</c>, snap points specified through SetSnapPoints or SetSnapInterval are cleared.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationprimarycontent-setsnaptype
		// HRESULT SetSnapType( [in] DIRECTMANIPULATION_MOTION_TYPES motion, [in] DIRECTMANIPULATION_SNAPPOINT_TYPE type );
		void SetSnapType([In] DIRECTMANIPULATION_MOTION_TYPES motion, [In] DIRECTMANIPULATION_SNAPPOINT_TYPE type);

		/// <summary>Specifies the coordinate system for snap points or snap intervals.</summary>
		/// <param name="motion">One of the values from DIRECTMANIPULATION_MOTION_TYPES.</param>
		/// <param name="coordinate">
		/// <para>One of the values from DIRECTMANIPULATION_SNAPPOINT_COORDINATE.</para>
		/// <para>
		/// If <c>motion</c> is set to translation ( <c>DIRECTMANIPULATION_MOTION_TRANSLATEX</c> or
		/// <c>DIRECTMANIPULATION_MOTION_TRANSLATEY</c>), all values of DIRECTMANIPULATION_SNAPPOINT_COORDINATE are valid.
		/// </para>
		/// <para>
		/// If <c>motion</c> is set to <c>DIRECTMANIPULATION_MOTION_ZOOM</c>, only <c>DIRECTMANIPULATION_COORDINATE_ORIGIN</c> of
		/// DIRECTMANIPULATION_SNAPPOINT_COORDINATE is valid ( <c>origin</c> must be set to 0.0f).
		/// </para>
		/// </param>
		/// <param name="origin">
		/// <para>
		/// The initial, or starting, snap point. All snap points are relative to this one. Only used when
		/// DIRECTMANIPULATION_COORDINATE_ORIGIN is set.
		/// </para>
		/// <para>If <c>motion</c> is set to <c>DIRECTMANIPULATION_MOTION_ZOOM</c>, then <c>origin</c> must be set to 0.0f.</para>
		/// </param>
		/// <remarks>
		/// The origin is relative to the content boundaries. If no boundary has been set (SetContentRect is never called) the default
		/// boundaries are (-FLT_MAX, FLT_MAX).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationprimarycontent-setsnapcoordinate
		// HRESULT SetSnapCoordinate( [in] DIRECTMANIPULATION_MOTION_TYPES motion, [in] DIRECTMANIPULATION_SNAPPOINT_COORDINATE coordinate,
		// [in] float origin );
		void SetSnapCoordinate([In] DIRECTMANIPULATION_MOTION_TYPES motion, [In] DIRECTMANIPULATION_SNAPPOINT_COORDINATE coordinate, [In] float origin);

		/// <summary>Specifies the minimum and maximum boundaries for zoom.</summary>
		/// <param name="zoomMinimum">The minimum zoom level allowed. Must be greater than or equal to 0.1f, which corresponds to 100% zoom.</param>
		/// <param name="zoomMaximum">The maximum zoom allowed. Must be greater than <c>zoomMinimum</c> and less than FLT_MAX.</param>
		/// <remarks>
		/// If the content is outside the new boundaries, and the viewport is ENABLED or READY, then the content is reset to be within the
		/// new boundaries. If inertia configuration is enabled, the reset operation uses an inertia animation.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationprimarycontent-setzoomboundaries
		// HRESULT SetZoomBoundaries( [in] float zoomMinimum, [in] float zoomMaximum );
		void SetZoomBoundaries([In] float zoomMinimum, [In] float zoomMaximum);

		/// <summary>Sets the horizontal alignment of the primary content relative to the viewport.</summary>
		/// <param name="alignment">
		/// <para>One or more values from DIRECTMANIPULATION_HORIZONTALALIGNMENT. The default is <c>DIRECTMANIPULATION_HORIZONTALALIGNMENT_NONE</c>.</para>
		/// <note>You cannot combine the following options: DIRECTMANIPULATION_HORIZONTALALIGNMENT_LEFT,
		/// DIRECTMANIPULATION-HORIZONTALALIGNMENT_CENTER, DIRECTMANIPULATION_HORIZONTALALIGNMENT_RIGHT.
		/// DIRECTMANIPULATION_HORIZONTALALIGNMENT_UNLOCKCENTER can be combined with any option but cannot be configured by itself.</note>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you have activated a configuration consisting only of zoom or zoom inertia, specify
		/// DIRECTMANIPULATION_HORIZONTALALIGNMENT_UNLOCKCENTER to respect the zoom center point.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationprimarycontent-sethorizontalalignment
		// HRESULT SetHorizontalAlignment( [in] DIRECTMANIPULATION_HORIZONTALALIGNMENT alignment );
		void SetHorizontalAlignment([In] DIRECTMANIPULATION_HORIZONTALALIGNMENT alignment);

		/// <summary>Specifies the vertical alignment of the primary content in the viewport.</summary>
		/// <param name="alignment">
		/// <para>One or more values from DIRECTMANIPULATION_VERTICALALIGNMENT.</para>
		/// <note>You cannot combine <c>DIRECTMANIPULATION_VERTICALALIGNMENT_TOP</c>, <c>DIRECTMANIPULATION_VERTICALALIGNMENT_CENTER</c>, or
		/// <c>DIRECTMANIPULATION_VERTICALALIGNMENT_BOTTOM</c>. <c>DIRECTMANIPULATION_VERTICALALIGNMENT_UNLOCKCENTER</c> can be combined with
		/// any option but cannot be configured by itself.</note>
		/// </param>
		/// <remarks>
		/// <para>
		/// If you have activated a configuration consisting only of zoom or zoom inertia, specify
		/// <c>DIRECTMANIPULATION_VERTICALALIGNMENT_UNLOCKCENTER</c> to respect the zoom center point.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationprimarycontent-setverticalalignment
		// HRESULT SetVerticalAlignment( [in] DIRECTMANIPULATION_VERTICALALIGNMENT alignment );
		void SetVerticalAlignment([In] DIRECTMANIPULATION_VERTICALALIGNMENT alignment);

		/// <summary>Gets the final transform, including inertia, of the primary content.</summary>
		/// <param name="matrix">The transformed matrix that represents the inertia ending position.</param>
		/// <param name="pointCount">
		/// <para>The size of the matrix.</para>
		/// <para>This value is always 6, because a 3x2 matrix is used for all direct manipulation transforms.</para>
		/// </param>
		/// <remarks>
		/// <c>Warning</c> Calling this method can cause a race condition if inertia has ended or been interrupted. This can also occur
		/// during the OnViewportStatusChanged callback.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationprimarycontent-getinertiaendtransform
		// HRESULT GetInertiaEndTransform( [out] float *matrix, [in] DWORD pointCount );
		void GetInertiaEndTransform([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] matrix, uint pointCount = 6);

		/// <summary>
		/// Retrieves the center point of the manipulation in content coordinates. If there is no manipulation in progress, retrieves the
		/// center point of the viewport.
		/// </summary>
		/// <param name="centerX">The center on the horizontal axis.</param>
		/// <param name="centerY">The center on the vertical axis.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationprimarycontent-getcenterpoint
		// HRESULT GetCenterPoint( [out] float *centerX, [out] float *centerY );
		void GetCenterPoint(out float centerX, out float centerY);
	}

	/// <summary>
	/// <para>Defines methods for handling manipulation update events.</para>
	/// <para>
	/// <c>Note</c> When implementing a Direct Manipulation object, ensure that the IUnknown implementation supports multithreading through
	/// thread-safe reference counting. For more information, see InterlockedIncrement and InterlockedDecrement.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationupdatehandler
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationUpdateHandler")]
	[ComImport, Guid("790B6337-64F8-4FF5-A269-B32BC2AF27A7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDirectManipulationUpdateHandler
	{
		/// <summary>Notifies the compositor when to update inertia animation.</summary>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationupdatehandler-update
		// HRESULT Update();
		[PreserveSig]
		HRESULT Update();
	}

	/// <summary>
	/// <para>Manages how compositor updates are sent to Direct Manipulation.</para>
	/// <para>
	/// This interface enables the compositor to trigger an update on Direct Manipulation whenever there is a compositor update. The
	/// application should not call the methods of this interface directly.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationupdatemanager
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationUpdateManager")]
	[ComImport, Guid("B0AE62FD-BE34-46E7-9CAA-D361FACBB9CC"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(DirectManipulationUpdateManager))]
	public interface IDirectManipulationUpdateManager
	{
		/// <summary>Registers a callback that is triggered by a handle.</summary>
		/// <param name="handle">The event handle that triggers the callback.</param>
		/// <param name="eventHandler">The event handler to call when the event is fired.</param>
		/// <param name="cookie">The unique ID of the event callback instance.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationupdatemanager-registerwaithandlecallback
		// HRESULT RegisterWaitHandleCallback( [in] HANDLE handle, [in] IDirectManipulationUpdateHandler *eventHandler, [out] DWORD *cookie );
		void RegisterWaitHandleCallback([In] HANDLE handle, [In] IDirectManipulationUpdateHandler eventHandler, out uint cookie);

		/// <summary>Deregisters a callback.</summary>
		/// <param name="cookie">The unique ID of the event callback instance.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationupdatemanager-unregisterwaithandlecallback
		// HRESULT UnregisterWaitHandleCallback( [in] DWORD cookie );
		void UnregisterWaitHandleCallback(uint cookie);

		/// <summary>Updates Direct Manipulation at the current time.</summary>
		/// <param name="frameInfo">
		/// The frame info provider used to predict the position of the content and compensate for latency during composition.
		/// </param>
		/// <remarks>
		/// If the application provides its own implementation of IDirectManipulationCompositor, this implementation should call
		/// <c>Update</c> whenever there is a compositor update. Frame timing information can be provided to Direct Manipulation through the
		/// IDirectManipulationFrameInfoProvider interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationupdatemanager-update
		// HRESULT Update( [in, optional] IDirectManipulationFrameInfoProvider *frameInfo );
		void Update([In, Optional] IDirectManipulationFrameInfoProvider frameInfo);
	}

	/// <summary>
	/// Defines a region within a window (referred to as a viewport) that is able to receive and process input from user interactions. The
	/// viewport contains content that moves in response to a user interaction.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationviewport
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationViewport")]
	[ComImport, Guid("28b85a3d-60a0-48bd-9ba1-5ce8d9ea3a6d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(DirectManipulationViewport))]
	public interface IDirectManipulationViewport
	{
		/// <summary>Starts or resumes input processing by the viewport.</summary>
		/// <returns>
		/// If the method succeeds, it returns <c>S_OK</c>, or <c>S_FALSE</c> if there is no work to do (for example, the viewport is already
		/// enabled). Otherwise, it returns an <c>HRESULT</c> error code.
		/// </returns>
		/// <remarks>
		/// <para>This method directs a viewport to attempt to respond to input.</para>
		/// <para>Call this method if the <c>AUTODISABLE</c> option is set.</para>
		/// <para>Examples</para>
		/// <para>The following example shows how to use this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-enable
		// HRESULT Enable();
		[PreserveSig]
		HRESULT Enable();

		/// <summary>Stops input processing by the viewport.</summary>
		/// <remarks>
		/// <para>When a viewport is disabled, it immediately stops all transforms and moves the content to the final location.</para>
		/// <para>Call this method when you want to modify multiple attributes atomically. This method can be called at any time.</para>
		/// <para>The viewport will not resume processing input until Enable is called.</para>
		/// <para>Examples</para>
		/// <para>The following example shows how to use this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-disable
		// HRESULT Disable();
		void Disable();

		/// <summary>Specifies an association between a contact and the viewport.</summary>
		/// <param name="pointerId">The ID of the pointer.</param>
		/// <remarks>
		/// <para>
		/// Call this method when a WM_POINTERDOWN message is received. Upon receiving a <c>WM_POINTERDOWN</c>, the application can use the
		/// coordinates of the input to hit-test and determine the viewports to which the contact is associated.
		/// </para>
		/// <para>DeferContact must be called before <c>SetContact</c>.</para>
		/// <para>
		/// After initialization, Direct Manipulation is not aware of viewport z-order or parent-child relations between viewports. The order
		/// of <c>SetContact</c> calls defines the viewport tree. To establish the correct viewport hierarchy, <c>SetContact</c> should be
		/// called first on the child-most viewport, followed by the parent, grand-parent, and so on.
		/// </para>
		/// <para>
		/// Use GET_POINTERID_WPARAM to get the pointer identifier from a pointer message. The contact is removed automatically when
		/// WM_POINTERUP is received.
		/// </para>
		/// <para>
		/// If a contact is associated with one or more viewports using the <c>SetContact</c> method, Direct Manipulation will examine
		/// further input from that contact and attempt to identify an appropriate manipulation based on the configuration of the associated
		/// viewports. If a manipulation is recognized, the application will then receive a WM_POINTERCAPTURECHANGED message for this
		/// contact. In this context, the <c>WM_POINTERCAPTURECHANGED</c> message indicates that Direct Manipulation has captured the contact
		/// and the application will not receive input from this contact that is consumed for this manipulation.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-setcontact
		// HRESULT SetContact( [in] UINT32 pointerId );
		void SetContact(uint pointerId);

		/// <summary>Removes a contact that is associated with a viewport.</summary>
		/// <param name="pointerId">The ID of the pointer.</param>
		/// <remarks>
		/// <para>This method releases a contact from a specific Direct Manipulation viewport (equivalent to the user removing a touch point).</para>
		/// <para>
		/// The viewport state is not affected unless the last remaining contact on the viewport is removed, in which case the viewport will
		/// transition to inertia, if supported.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-releasecontact
		// HRESULT ReleaseContact( [in] UINT32 pointerId );
		void ReleaseContact(uint pointerId);

		/// <summary>Removes all contacts that are associated with the viewport. Inertia is started if the viewport supports inertia.</summary>
		/// <remarks>
		/// <para>
		/// This is equivalent to calling ReleaseContact on every contact associated with the viewport. The outcome is equivalent to the user
		/// removing all touch points from the viewport.
		/// </para>
		/// <para>If supported, inertia will be started after calling this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-releaseallcontacts
		// HRESULT ReleaseAllContacts();
		void ReleaseAllContacts();

		/// <summary>Gets the state of the viewport.</summary>
		/// <returns>One of the values from DIRECTMANIPULATION_STATUS.</returns>
		/// <remarks>
		/// <para>This method returns the viewport state at the time of the call and not at the time when the return value is read.</para>
		/// <para>This method will fail if called after Abandon.</para>
		/// <para>Examples</para>
		/// <para>The following example shows how to use this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-getstatus
		// HRESULT GetStatus( [out, retval] DIRECTMANIPULATION_STATUS *status );
		DIRECTMANIPULATION_STATUS GetStatus();

		/// <summary>Gets the tag value of a viewport.</summary>
		/// <param name="riid">IID to the interface.</param>
		/// <param name="object">The object portion of the tag.</param>
		/// <param name="id">The identifier portion of the tag.</param>
		/// <remarks>
		/// <para>
		/// A tag is a pairing of an integer ID with a Component Object Model (COM) object. It can be used by an app to identify the viewport.
		/// </para>
		/// <para>The out parameters are optional, so the method can return an ID, the viewport object, or both.</para>
		/// <para>Examples</para>
		/// <para>The following example show how to use this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-gettag
		// HRESULT GetTag( [in] REFIID riid, [out, optional] void **object, [out, optional] UINT32 *id );
		void GetTag(in Guid riid, [Optional, MarshalAs(UnmanagedType.IUnknown)] out object @object, out uint id);

		/// <summary>Sets a viewport tag.</summary>
		/// <param name="object">The object portion of the tag.</param>
		/// <param name="id">The ID portion of the tag.</param>
		/// <remarks>
		/// <para>
		/// A tag is a pairing of an integer ID with a Component Object Model (COM) object. It can be used by an app to identify the viewport.
		/// </para>
		/// <para>The object parameter is optional, so that the method can set just an ID.</para>
		/// <para>Examples</para>
		/// <para>The following example shows the syntax for this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-settag
		// HRESULT SetTag( [in, optional] IUnknown *object, [in] UINT32 id );
		void SetTag([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object @object, uint id);

		/// <summary>Retrieves the rectangle for the viewport relative to the origin of the viewport coordinate system specified by SetViewportRect.</summary>
		/// <returns>The bounding rectangle relative to the viewport coordinate system.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-getviewportrect
		// HRESULT GetViewportRect( [out, retval] RECT *viewport );
		RECT GetViewportRect();

		/// <summary>Sets the bounding rectangle for the viewport, relative to the origin of the viewport coordinate system.</summary>
		/// <param name="viewport">The bounding rectangle.</param>
		/// <remarks>
		/// The viewport rectangle specifies the region of content that is visible to the user. In conjunction with the primary content
		/// rectangle, the viewport rectangle is used to determine chaining behaviors.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-setviewportrect
		// HRESULT SetViewportRect( [in] const RECT *viewport );
		void SetViewportRect(in RECT viewport);

		/// <summary>Moves the viewport to a specific area of the primary content and specifies whether to animate the transition.</summary>
		/// <param name="left">The leftmost coordinate of the rectangle in the primary content coordinate space.</param>
		/// <param name="top">The topmost coordinate of the rectangle in the primary content coordinate space.</param>
		/// <param name="right">The rightmost coordinate of the rectangle in the primary content coordinate space.</param>
		/// <param name="bottom">The bottommost coordinate of the rectangle in the primary content coordinate space.</param>
		/// <param name="animate">Specifies whether to animate the zoom behavior.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-zoomtorect
		// HRESULT ZoomToRect( [in] const float left, [in] const float top, [in] const float right, [in] const float bottom, [in] BOOL
		// animate );
		void ZoomToRect([In] float left, [In] float top, [In] float right, [In] float bottom, bool animate);

		/// <summary>Specifies the transform from the viewport coordinate system to the window client coordinate system.</summary>
		/// <param name="matrix">The transform matrix, in row-wise order: _11, _12, _21, _22, _31, _32.</param>
		/// <param name="pointCount">
		/// The size of the transform matrix. This value is always 6, because a 3x2 matrix is used for all direct manipulation transforms.
		/// </param>
		/// <remarks>
		/// <para>
		/// Call this function to specify the viewport position, scaling and orientation on the screen. Viewport position, scaling,
		/// orientation and size are uniquely determined by the viewport transform and the viewport rectangle. The application can specify
		/// the viewport transform using this method, and the viewport rectangle using SetViewportRect.
		/// </para>
		/// <para>
		/// The viewport rectangle (the rectangular area inside the content that is visible to the user) is specified in viewport
		/// coordinates. If the viewport rectangle top-left point is (0,0), the viewport rectangle is positioned exactly at the viewport
		/// coordinate system origin. Viewports offset from the viewport coordinate system origin can be specified in two ways:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Through the viewport rectangle top-left point</term>
		/// </item>
		/// <item>
		/// <term>Through the viewport transform translation component (_31, _32)</term>
		/// </item>
		/// </list>
		/// <para>
		/// The viewport transform converts from the viewport coordinate system to the window client coordinate system. Direct Manipulation
		/// ignores the window RTL property, so the client area origin is always the top-left point. The transforms are applied in the
		/// following order:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Viewport rectangle offset</term>
		/// </item>
		/// <item>
		/// <term>Viewport transform (from viewport to client coordinate system)</term>
		/// </item>
		/// <item>
		/// <term>Client to screen mapping (from client to screen coordinate system)</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-setviewporttransform
		// HRESULT SetViewportTransform( [in] const float *matrix, [in] DWORD pointCount );
		void SetViewportTransform([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] matrix, uint pointCount);

		/// <summary>
		/// Specifies a display transform for the viewport, and synchronizes the output transform with the new value of the display transform.
		/// </summary>
		/// <param name="matrix">The transform matrix, in row-wise order: _11, _12, _21, _22, _31, _32.</param>
		/// <param name="pointCount">
		/// The size of the transform matrix. This value is always 6, because a 3x2 matrix is used for all direct manipulation transforms.
		/// </param>
		/// <remarks>
		/// <para>
		/// If the application performs special output processing of the content outside of the compositor (content not fully captured in the
		/// viewport transform), it should call this method to specify the display transform for the special processing.
		/// </para>
		/// <para>
		/// The display transform affects how manipulation updates are applied to the output transform. For example, if the display transform
		/// is set to scale 3x, panning will move the content 3x the original distance.
		/// </para>
		/// <para>
		/// When a display transform is changed using this method, the output transform will be synchronized to the new value of the display transform.
		/// </para>
		/// <para>This method cannot be called if the viewport status is <c>DIRECTMANIPULATION_RUNNING</c> or <c>DIRECTMANIPULATION_INERTIA</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-syncdisplaytransform
		// HRESULT SyncDisplayTransform( [in] const float *matrix, [in] DWORD pointCount );
		void SyncDisplayTransform([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] matrix, uint pointCount);

		/// <summary>
		/// <para>***BAD FORMATTING - Params***</para>
		/// <para>Gets the primary content of a viewport that implements IDirectManipulationContent and IDirectManipulationPrimaryContent.</para>
		/// <para>
		/// Primary content is an element that gets transformed (e.g. moved, scaled, rotated) in response to a user interaction. Primary
		/// content is created at the same time as the viewport and cannot be added or removed.
		/// </para>
		/// </summary>
		/// <param name="riid">IID to the interface.</param>
		/// <param name="object">The primary content object.</param>
		/// <remarks>
		/// <para>This method gets the content of the viewport that implements IDirectManipulationContent and IDirectManipulationPrimaryContent.</para>
		/// <para>Examples</para>
		/// <para>The following example shows how to use this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-getprimarycontent
		// HRESULT GetPrimaryContent( [in] REFIID riid, [out, retval] void **object );
		void GetPrimaryContent(in Guid riid, out IDirectManipulationPrimaryContent @object);

		/// <summary>Adds secondary content, such as a panning indicator, to a viewport.</summary>
		/// <param name="content">The content to add to the viewport.</param>
		/// <remarks>
		/// Secondary content is created by calling CreateContent. Once added, the secondary content will move relative to the primary
		/// content in response to a manipulation. Its motion is determined by rules associated with each type of secondary content.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-addcontent
		// HRESULT AddContent( [in] IDirectManipulationContent *content );
		void AddContent([In] IDirectManipulationContent content);

		/// <summary>Removes secondary content from a viewport.</summary>
		/// <param name="content">The content object to remove.</param>
		/// <remarks>Secondary content can be removed from the viewport at any time.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-removecontent
		// HRESULT RemoveContent( [in] IDirectManipulationContent *content );
		void RemoveContent([In] IDirectManipulationContent content);

		/// <summary>
		/// <para>Sets how the viewport handles input and output.</para>
		/// <para>Calling this method overrides all settings previously specified with SetUpdateMode or SetInputMode.</para>
		/// </summary>
		/// <param name="options">One or more of the values from DIRECTMANIPULATION_VIEWPORT_OPTIONS.</param>
		/// <remarks>Calling this method with DIRECTMANIPULATION_INPUT_MODE_MANUAL set is similar to calling <c>SetViewportOptions(DIRECTMANIPULATION_VIEWPORT_OPTIONS_INPUT)</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-setviewportoptions
		// HRESULT SetViewportOptions( [in] DIRECTMANIPULATION_VIEWPORT_OPTIONS options );
		void SetViewportOptions([In] DIRECTMANIPULATION_VIEWPORT_OPTIONS options);

		/// <summary>Adds an interaction configuration for the viewport.</summary>
		/// <param name="configuration">
		/// One of the values from DIRECTMANIPULATION_CONFIGURATION that specifies the interaction configuration for the viewport.
		/// </param>
		/// <remarks>
		/// <para>
		/// An interaction configuration specifies how the manipulation engine responds to input and which manipulations are supported. Any
		/// number of possible configurations can be added to the viewport using <c>AddConfiguration</c> before processing input.
		/// </para>
		/// <para>Configurations can be switched by the application at runtime using ActivateConfiguration.</para>
		/// <para>When a configuration is no longer required (and is not currently active), it can be removed using RemoveConfiguration.</para>
		/// <para>
		/// If a configuration has not been added using <c>AddConfiguration</c>, it can be automatically added and then activated by calling ActivateConfiguration.
		/// </para>
		/// <para><c>Note</c> If input processing is occurring, this call will fail.</para>
		/// <para>This method fails if a drag and drop behavior has been specified.</para>
		/// <para>A drag and drop behavior object cannot be attached after successfully calling this method.</para>
		/// <para>You cannot add another drag and drop behavior after an existing one has already been added.</para>
		/// <para>
		/// This method is designed to allow an application to switch pre-added configurations, as a configuration cannot be changed while a
		/// manipulation is occurring. Under most circumstances it is better to update the configuration using ActivateConfiguration.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-addconfiguration
		// HRESULT AddConfiguration( [in] DIRECTMANIPULATION_CONFIGURATION configuration );
		void AddConfiguration([In] DIRECTMANIPULATION_CONFIGURATION configuration);

		/// <summary>Removes an interaction configuration for the viewport.</summary>
		/// <param name="configuration">
		/// One of the values from DIRECTMANIPULATION_CONFIGURATION that specifies the interaction configuration for the viewport.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method removes a possible configuration that was added by using AddConfiguration. This method can be called only if the
		/// configuration is not active.
		/// </para>
		/// <para>
		/// An interaction configuration specifies how the manipulation engine responds to input and which gestures are supported. Any number
		/// of configurations can be added to the viewport using AddConfiguration. Configurations can be switched by the application at
		/// runtime using ActivateConfiguration. When a configuration is no longer required (and is not currently active), it can be removed
		/// using <c>RemoveConfiguration</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example shows how to use this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-removeconfiguration
		// HRESULT RemoveConfiguration( [in] DIRECTMANIPULATION_CONFIGURATION configuration );
		void RemoveConfiguration([In] DIRECTMANIPULATION_CONFIGURATION configuration);

		/// <summary>Sets the configuration for input interaction.</summary>
		/// <param name="configuration">
		/// One or more values from DIRECTMANIPULATION_CONFIGURATION that specify the interaction configuration for the viewport.
		/// </param>
		/// <remarks>
		/// <para>
		/// An interaction configuration specifies how the manipulation engine responds to input and which manipulations are supported. Any
		/// number of possible configurations can be added to the viewport using AddConfiguration before processing input.
		/// </para>
		/// <para>Configurations can be switched by the application at runtime using <c>ActivateConfiguration</c>.</para>
		/// <para>When a configuration is no longer required (and is not currently active), it can be removed using RemoveConfiguration.</para>
		/// <para>
		/// If a configuration has not been added using AddConfiguration, it can be automatically added and then activated by calling <c>ActivateConfiguration</c>.
		/// </para>
		/// <para><c>Note</c> If input processing is occurring, this call will fail.</para>
		/// <para>This method fails if a drag and drop behavior has been specified.</para>
		/// <para>A drag and drop behavior object cannot be attached after successfully calling this method.</para>
		/// <para>Examples</para>
		/// <para>The following example shows how to configure a viewport for horizontal panning.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-activateconfiguration
		// HRESULT ActivateConfiguration( [in] DIRECTMANIPULATION_CONFIGURATION configuration );
		void ActivateConfiguration([In] DIRECTMANIPULATION_CONFIGURATION configuration);

		/// <summary>Sets which gestures are ignored by Direct Manipulation.</summary>
		/// <param name="configuration">One of the values from DIRECTMANIPULATION_GESTURE_CONFIGURATION.</param>
		/// <remarks>
		/// <para>
		/// Use this method to specify which gestures the application processes on the UI thread. If a gesture is recognized, it will be
		/// passed to the application for processing and ignored by Direct Manipulation.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example shows how zoom gestures can be ignored by Direct Manipulation and handled by the application, which may
		/// have custom zoom behavior implementation.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-setmanualgesture
		// HRESULT SetManualGesture( [in] DIRECTMANIPULATION_GESTURE_CONFIGURATION configuration );
		void SetManualGesture([In] DIRECTMANIPULATION_GESTURE_CONFIGURATION configuration);

		/// <summary>Specifies the motion types supported in a viewport that can be chained to a parent viewport.</summary>
		/// <param name="enabledTypes">
		/// One of the values from DIRECTMANIPULATION_MOTION_TYPES that specifies the motion types that are enabled for this viewport.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-setchaining
		// HRESULT SetChaining( [in] DIRECTMANIPULATION_MOTION_TYPES enabledTypes );
		void SetChaining([In] DIRECTMANIPULATION_MOTION_TYPES enabledTypes);

		/// <summary>Adds a new event handler to listen for viewport events.</summary>
		/// <param name="window">The handle of a window owned by the thread for the event callback.</param>
		/// <param name="eventHandler">
		/// The handler that is called when viewport status and update events occur. The specified object must implement the
		/// IDirectManipulationViewportEventHandler interface.
		/// </param>
		/// <param name="cookie">The handle that represents this event handler callback.</param>
		/// <remarks>
		/// <para>
		/// The event callback is fired from the thread that owns the specified window. Consecutive events of the same callback method may be coalesced.
		/// </para>
		/// <para><c>Note</c> If the viewport has a drag-drop behavior attached, the event handler should implement IDirectManipulationDragDropEventHandler.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-addeventhandler
		// HRESULT AddEventHandler( [in] HWND window, [in] IDirectManipulationViewportEventHandler *eventHandler, [out, retval] DWORD *cookie );
		void AddEventHandler([In, Optional] HWND window, [In] IDirectManipulationViewportEventHandler eventHandler, out uint cookie);

		/// <summary>Removes an existing event handler from the viewport.</summary>
		/// <param name="cookie">A value that was returned by a previous call to AddEventHandler.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-removeeventhandler
		// HRESULT RemoveEventHandler( [in] DWORD cookie );
		void RemoveEventHandler(uint cookie);

		/// <summary>Specifies if input is visible to the UI thread.</summary>
		/// <param name="mode">One of the values from DIRECTMANIPULATION_INPUT_MODE.</param>
		/// <remarks>
		/// <para>DIRECTMANIPULATION_INPUT_MODE_AUTOMATIC is the default mode for Direct Manipulation.</para>
		/// <para>
		/// Direct Manipulation consumes all the input that drives the manipulation and the application receives WM_POINTERCAPTURECHANGED messages.
		/// </para>
		/// <para>
		/// In some situations an application may want to receive input that is driving a manipulation. Set
		/// DIRECTMANIPULATION_INPUT_MODE_MANUAL in this case. The application will receive all input messages, even input used by Direct
		/// Manipulation to drive a manipulation.
		/// </para>
		/// <para><c>Note</c> The application will not receive WM_POINTERCAPTURECHANGED messages.</para>
		/// <para>
		/// Calling this method with DIRECTMANIPULATION_INPUT_MODE_MANUAL set is similar to calling
		/// SetViewportOptions(DIRECTMANIPULATION_VIEWPORT_OPTIONS_INPUT). However, calling <c>SetViewportOptions</c> also overrides all
		/// other settings.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example shows how to use this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-setinputmode
		// HRESULT SetInputMode( [in] DIRECTMANIPULATION_INPUT_MODE mode );
		void SetInputMode([In] DIRECTMANIPULATION_INPUT_MODE mode);

		/// <summary>Specifies whether a viewport updates content manually instead of during an input event.</summary>
		/// <param name="mode">One of the values from DIRECTMANIPULATION_INPUT_MODE.</param>
		/// <remarks>
		/// <para>
		/// DIRECTMANIPULATION_INPUT_MODE_AUTOMATIC is the default mode for Direct Manipulation. In this mode, visual updates are pushed to
		/// compositor driven by input. This is the expected mode of operation if the application is using system-provided implementation of IDirectManipulationCompositor.
		/// </para>
		/// <para>
		/// If the application provides its own implementation of IDirectManipulationCompositor, it should switch viewport update mode to
		/// manual by setting DIRECTMANIPULATION_INPUT_MODE_MANUAL. When in manual mode, the compositor pulls visual updates whenever it
		/// calls Update on Direct Manipulation.
		/// </para>
		/// <para>
		/// Calling this method with DIRECTMANIPULATION_INPUT_MODE_MANUAL set is similar to calling
		/// SetViewportOptions(DIRECTMANIPULATION_VIEWPORT_OPTIONS_INPUT). However, calling <c>SetViewportOptions</c> also overrides all
		/// other settings.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-setupdatemode
		// HRESULT SetUpdateMode( [in] DIRECTMANIPULATION_INPUT_MODE mode );
		void SetUpdateMode([In] DIRECTMANIPULATION_INPUT_MODE mode);

		/// <summary>Stops the manipulation and returns the viewport to a ready state.</summary>
		/// <remarks>If a mandatory snap point has been configured, the content may animate to the nearest snap point.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-stop
		// HRESULT Stop();
		void Stop();

		/// <summary>Releases all resources that are used by the viewport and prepares it for destruction from memory.</summary>
		/// <remarks>
		/// Once <c>Abandon</c> has been called, do not make subsequent function calls on the viewport. If a function is called after
		/// <c>Abandon</c>, <c>E_INVALID_STATE</c> will be returned.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-abandon
		// HRESULT Abandon();
		void Abandon();
	}

	/// <summary>
	/// Provides management of behaviors on a viewport. A behavior affects the functionality of a particular part of the Direct Manipulation workflow.
	/// </summary>
	/// <remarks>
	/// <para><c>IDirectManipulationViewport2</c> can be used in place of IDirectManipulationViewport.</para>
	/// <para>Behaviors are created using IDirectManipulationManager2 and an appropriate class ID.</para>
	/// <para>
	/// A behavior can be attached or removed at any time and takes effect immediately (even during an active manipulation or inertia animation).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationviewport2
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationViewport2")]
	[ComImport, Guid("923CCAAC-61E1-4385-B726-017AF189882A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDirectManipulationViewport2 : IDirectManipulationViewport
	{
		/// <summary>Starts or resumes input processing by the viewport.</summary>
		/// <returns>
		/// If the method succeeds, it returns <c>S_OK</c>, or <c>S_FALSE</c> if there is no work to do (for example, the viewport is already
		/// enabled). Otherwise, it returns an <c>HRESULT</c> error code.
		/// </returns>
		/// <remarks>
		/// <para>This method directs a viewport to attempt to respond to input.</para>
		/// <para>Call this method if the <c>AUTODISABLE</c> option is set.</para>
		/// <para>Examples</para>
		/// <para>The following example shows how to use this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-enable
		// HRESULT Enable();
		[PreserveSig]
		new HRESULT Enable();

		/// <summary>Stops input processing by the viewport.</summary>
		/// <remarks>
		/// <para>When a viewport is disabled, it immediately stops all transforms and moves the content to the final location.</para>
		/// <para>Call this method when you want to modify multiple attributes atomically. This method can be called at any time.</para>
		/// <para>The viewport will not resume processing input until Enable is called.</para>
		/// <para>Examples</para>
		/// <para>The following example shows how to use this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-disable
		// HRESULT Disable();
		new void Disable();

		/// <summary>Specifies an association between a contact and the viewport.</summary>
		/// <param name="pointerId">The ID of the pointer.</param>
		/// <remarks>
		/// <para>
		/// Call this method when a WM_POINTERDOWN message is received. Upon receiving a <c>WM_POINTERDOWN</c>, the application can use the
		/// coordinates of the input to hit-test and determine the viewports to which the contact is associated.
		/// </para>
		/// <para>DeferContact must be called before <c>SetContact</c>.</para>
		/// <para>
		/// After initialization, Direct Manipulation is not aware of viewport z-order or parent-child relations between viewports. The order
		/// of <c>SetContact</c> calls defines the viewport tree. To establish the correct viewport hierarchy, <c>SetContact</c> should be
		/// called first on the child-most viewport, followed by the parent, grand-parent, and so on.
		/// </para>
		/// <para>
		/// Use GET_POINTERID_WPARAM to get the pointer identifier from a pointer message. The contact is removed automatically when
		/// WM_POINTERUP is received.
		/// </para>
		/// <para>
		/// If a contact is associated with one or more viewports using the <c>SetContact</c> method, Direct Manipulation will examine
		/// further input from that contact and attempt to identify an appropriate manipulation based on the configuration of the associated
		/// viewports. If a manipulation is recognized, the application will then receive a WM_POINTERCAPTURECHANGED message for this
		/// contact. In this context, the <c>WM_POINTERCAPTURECHANGED</c> message indicates that Direct Manipulation has captured the contact
		/// and the application will not receive input from this contact that is consumed for this manipulation.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-setcontact
		// HRESULT SetContact( [in] UINT32 pointerId );
		new void SetContact(uint pointerId);

		/// <summary>Removes a contact that is associated with a viewport.</summary>
		/// <param name="pointerId">The ID of the pointer.</param>
		/// <remarks>
		/// <para>This method releases a contact from a specific Direct Manipulation viewport (equivalent to the user removing a touch point).</para>
		/// <para>
		/// The viewport state is not affected unless the last remaining contact on the viewport is removed, in which case the viewport will
		/// transition to inertia, if supported.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-releasecontact
		// HRESULT ReleaseContact( [in] UINT32 pointerId );
		new void ReleaseContact(uint pointerId);

		/// <summary>Removes all contacts that are associated with the viewport. Inertia is started if the viewport supports inertia.</summary>
		/// <remarks>
		/// <para>
		/// This is equivalent to calling ReleaseContact on every contact associated with the viewport. The outcome is equivalent to the user
		/// removing all touch points from the viewport.
		/// </para>
		/// <para>If supported, inertia will be started after calling this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-releaseallcontacts
		// HRESULT ReleaseAllContacts();
		new void ReleaseAllContacts();

		/// <summary>Gets the state of the viewport.</summary>
		/// <returns>One of the values from DIRECTMANIPULATION_STATUS.</returns>
		/// <remarks>
		/// <para>This method returns the viewport state at the time of the call and not at the time when the return value is read.</para>
		/// <para>This method will fail if called after Abandon.</para>
		/// <para>Examples</para>
		/// <para>The following example shows how to use this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-getstatus
		// HRESULT GetStatus( [out, retval] DIRECTMANIPULATION_STATUS *status );
		new DIRECTMANIPULATION_STATUS GetStatus();

		/// <summary>Gets the tag value of a viewport.</summary>
		/// <param name="riid">IID to the interface.</param>
		/// <param name="object">The object portion of the tag.</param>
		/// <param name="id">The identifier portion of the tag.</param>
		/// <remarks>
		/// <para>
		/// A tag is a pairing of an integer ID with a Component Object Model (COM) object. It can be used by an app to identify the viewport.
		/// </para>
		/// <para>The out parameters are optional, so the method can return an ID, the viewport object, or both.</para>
		/// <para>Examples</para>
		/// <para>The following example show how to use this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-gettag
		// HRESULT GetTag( [in] REFIID riid, [out, optional] void **object, [out, optional] UINT32 *id );
		new void GetTag(in Guid riid, [Optional, MarshalAs(UnmanagedType.IUnknown)] out object @object, out uint id);

		/// <summary>Sets a viewport tag.</summary>
		/// <param name="object">The object portion of the tag.</param>
		/// <param name="id">The ID portion of the tag.</param>
		/// <remarks>
		/// <para>
		/// A tag is a pairing of an integer ID with a Component Object Model (COM) object. It can be used by an app to identify the viewport.
		/// </para>
		/// <para>The object parameter is optional, so that the method can set just an ID.</para>
		/// <para>Examples</para>
		/// <para>The following example shows the syntax for this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-settag
		// HRESULT SetTag( [in, optional] IUnknown *object, [in] UINT32 id );
		new void SetTag([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object @object, uint id);

		/// <summary>Retrieves the rectangle for the viewport relative to the origin of the viewport coordinate system specified by SetViewportRect.</summary>
		/// <returns>The bounding rectangle relative to the viewport coordinate system.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-getviewportrect
		// HRESULT GetViewportRect( [out, retval] RECT *viewport );
		new RECT GetViewportRect();

		/// <summary>Sets the bounding rectangle for the viewport, relative to the origin of the viewport coordinate system.</summary>
		/// <param name="viewport">The bounding rectangle.</param>
		/// <remarks>
		/// The viewport rectangle specifies the region of content that is visible to the user. In conjunction with the primary content
		/// rectangle, the viewport rectangle is used to determine chaining behaviors.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-setviewportrect
		// HRESULT SetViewportRect( [in] const RECT *viewport );
		new void SetViewportRect(in RECT viewport);

		/// <summary>Moves the viewport to a specific area of the primary content and specifies whether to animate the transition.</summary>
		/// <param name="left">The leftmost coordinate of the rectangle in the primary content coordinate space.</param>
		/// <param name="top">The topmost coordinate of the rectangle in the primary content coordinate space.</param>
		/// <param name="right">The rightmost coordinate of the rectangle in the primary content coordinate space.</param>
		/// <param name="bottom">The bottommost coordinate of the rectangle in the primary content coordinate space.</param>
		/// <param name="animate">Specifies whether to animate the zoom behavior.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-zoomtorect
		// HRESULT ZoomToRect( [in] const float left, [in] const float top, [in] const float right, [in] const float bottom, [in] BOOL
		// animate );
		new void ZoomToRect([In] float left, [In] float top, [In] float right, [In] float bottom, bool animate);

		/// <summary>Specifies the transform from the viewport coordinate system to the window client coordinate system.</summary>
		/// <param name="matrix">The transform matrix, in row-wise order: _11, _12, _21, _22, _31, _32.</param>
		/// <param name="pointCount">
		/// The size of the transform matrix. This value is always 6, because a 3x2 matrix is used for all direct manipulation transforms.
		/// </param>
		/// <remarks>
		/// <para>
		/// Call this function to specify the viewport position, scaling and orientation on the screen. Viewport position, scaling,
		/// orientation and size are uniquely determined by the viewport transform and the viewport rectangle. The application can specify
		/// the viewport transform using this method, and the viewport rectangle using SetViewportRect.
		/// </para>
		/// <para>
		/// The viewport rectangle (the rectangular area inside the content that is visible to the user) is specified in viewport
		/// coordinates. If the viewport rectangle top-left point is (0,0), the viewport rectangle is positioned exactly at the viewport
		/// coordinate system origin. Viewports offset from the viewport coordinate system origin can be specified in two ways:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Through the viewport rectangle top-left point</term>
		/// </item>
		/// <item>
		/// <term>Through the viewport transform translation component (_31, _32)</term>
		/// </item>
		/// </list>
		/// <para>
		/// The viewport transform converts from the viewport coordinate system to the window client coordinate system. Direct Manipulation
		/// ignores the window RTL property, so the client area origin is always the top-left point. The transforms are applied in the
		/// following order:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Viewport rectangle offset</term>
		/// </item>
		/// <item>
		/// <term>Viewport transform (from viewport to client coordinate system)</term>
		/// </item>
		/// <item>
		/// <term>Client to screen mapping (from client to screen coordinate system)</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-setviewporttransform
		// HRESULT SetViewportTransform( [in] const float *matrix, [in] DWORD pointCount );
		new void SetViewportTransform([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] matrix, uint pointCount);

		/// <summary>
		/// Specifies a display transform for the viewport, and synchronizes the output transform with the new value of the display transform.
		/// </summary>
		/// <param name="matrix">The transform matrix, in row-wise order: _11, _12, _21, _22, _31, _32.</param>
		/// <param name="pointCount">
		/// The size of the transform matrix. This value is always 6, because a 3x2 matrix is used for all direct manipulation transforms.
		/// </param>
		/// <remarks>
		/// <para>
		/// If the application performs special output processing of the content outside of the compositor (content not fully captured in the
		/// viewport transform), it should call this method to specify the display transform for the special processing.
		/// </para>
		/// <para>
		/// The display transform affects how manipulation updates are applied to the output transform. For example, if the display transform
		/// is set to scale 3x, panning will move the content 3x the original distance.
		/// </para>
		/// <para>
		/// When a display transform is changed using this method, the output transform will be synchronized to the new value of the display transform.
		/// </para>
		/// <para>This method cannot be called if the viewport status is <c>DIRECTMANIPULATION_RUNNING</c> or <c>DIRECTMANIPULATION_INERTIA</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-syncdisplaytransform
		// HRESULT SyncDisplayTransform( [in] const float *matrix, [in] DWORD pointCount );
		new void SyncDisplayTransform([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] matrix, uint pointCount);

		/// <summary>
		/// <para>***BAD FORMATTING - Params***</para>
		/// <para>Gets the primary content of a viewport that implements IDirectManipulationContent and IDirectManipulationPrimaryContent.</para>
		/// <para>
		/// Primary content is an element that gets transformed (e.g. moved, scaled, rotated) in response to a user interaction. Primary
		/// content is created at the same time as the viewport and cannot be added or removed.
		/// </para>
		/// </summary>
		/// <param name="riid">IID to the interface.</param>
		/// <param name="object">The primary content object.</param>
		/// <remarks>
		/// <para>This method gets the content of the viewport that implements IDirectManipulationContent and IDirectManipulationPrimaryContent.</para>
		/// <para>Examples</para>
		/// <para>The following example shows how to use this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-getprimarycontent
		// HRESULT GetPrimaryContent( [in] REFIID riid, [out, retval] void **object );
		new void GetPrimaryContent(in Guid riid, out IDirectManipulationPrimaryContent @object);

		/// <summary>Adds secondary content, such as a panning indicator, to a viewport.</summary>
		/// <param name="content">The content to add to the viewport.</param>
		/// <remarks>
		/// Secondary content is created by calling CreateContent. Once added, the secondary content will move relative to the primary
		/// content in response to a manipulation. Its motion is determined by rules associated with each type of secondary content.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-addcontent
		// HRESULT AddContent( [in] IDirectManipulationContent *content );
		new void AddContent([In] IDirectManipulationContent content);

		/// <summary>Removes secondary content from a viewport.</summary>
		/// <param name="content">The content object to remove.</param>
		/// <remarks>Secondary content can be removed from the viewport at any time.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-removecontent
		// HRESULT RemoveContent( [in] IDirectManipulationContent *content );
		new void RemoveContent([In] IDirectManipulationContent content);

		/// <summary>
		/// <para>Sets how the viewport handles input and output.</para>
		/// <para>Calling this method overrides all settings previously specified with SetUpdateMode or SetInputMode.</para>
		/// </summary>
		/// <param name="options">One or more of the values from DIRECTMANIPULATION_VIEWPORT_OPTIONS.</param>
		/// <remarks>Calling this method with DIRECTMANIPULATION_INPUT_MODE_MANUAL set is similar to calling <c>SetViewportOptions(DIRECTMANIPULATION_VIEWPORT_OPTIONS_INPUT)</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-setviewportoptions
		// HRESULT SetViewportOptions( [in] DIRECTMANIPULATION_VIEWPORT_OPTIONS options );
		new void SetViewportOptions([In] DIRECTMANIPULATION_VIEWPORT_OPTIONS options);

		/// <summary>Adds an interaction configuration for the viewport.</summary>
		/// <param name="configuration">
		/// One of the values from DIRECTMANIPULATION_CONFIGURATION that specifies the interaction configuration for the viewport.
		/// </param>
		/// <remarks>
		/// <para>
		/// An interaction configuration specifies how the manipulation engine responds to input and which manipulations are supported. Any
		/// number of possible configurations can be added to the viewport using <c>AddConfiguration</c> before processing input.
		/// </para>
		/// <para>Configurations can be switched by the application at runtime using ActivateConfiguration.</para>
		/// <para>When a configuration is no longer required (and is not currently active), it can be removed using RemoveConfiguration.</para>
		/// <para>
		/// If a configuration has not been added using <c>AddConfiguration</c>, it can be automatically added and then activated by calling ActivateConfiguration.
		/// </para>
		/// <para><c>Note</c> If input processing is occurring, this call will fail.</para>
		/// <para>This method fails if a drag and drop behavior has been specified.</para>
		/// <para>A drag and drop behavior object cannot be attached after successfully calling this method.</para>
		/// <para>You cannot add another drag and drop behavior after an existing one has already been added.</para>
		/// <para>
		/// This method is designed to allow an application to switch pre-added configurations, as a configuration cannot be changed while a
		/// manipulation is occurring. Under most circumstances it is better to update the configuration using ActivateConfiguration.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-addconfiguration
		// HRESULT AddConfiguration( [in] DIRECTMANIPULATION_CONFIGURATION configuration );
		new void AddConfiguration([In] DIRECTMANIPULATION_CONFIGURATION configuration);

		/// <summary>Removes an interaction configuration for the viewport.</summary>
		/// <param name="configuration">
		/// One of the values from DIRECTMANIPULATION_CONFIGURATION that specifies the interaction configuration for the viewport.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method removes a possible configuration that was added by using AddConfiguration. This method can be called only if the
		/// configuration is not active.
		/// </para>
		/// <para>
		/// An interaction configuration specifies how the manipulation engine responds to input and which gestures are supported. Any number
		/// of configurations can be added to the viewport using AddConfiguration. Configurations can be switched by the application at
		/// runtime using ActivateConfiguration. When a configuration is no longer required (and is not currently active), it can be removed
		/// using <c>RemoveConfiguration</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example shows how to use this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-removeconfiguration
		// HRESULT RemoveConfiguration( [in] DIRECTMANIPULATION_CONFIGURATION configuration );
		new void RemoveConfiguration([In] DIRECTMANIPULATION_CONFIGURATION configuration);

		/// <summary>Sets the configuration for input interaction.</summary>
		/// <param name="configuration">
		/// One or more values from DIRECTMANIPULATION_CONFIGURATION that specify the interaction configuration for the viewport.
		/// </param>
		/// <remarks>
		/// <para>
		/// An interaction configuration specifies how the manipulation engine responds to input and which manipulations are supported. Any
		/// number of possible configurations can be added to the viewport using AddConfiguration before processing input.
		/// </para>
		/// <para>Configurations can be switched by the application at runtime using <c>ActivateConfiguration</c>.</para>
		/// <para>When a configuration is no longer required (and is not currently active), it can be removed using RemoveConfiguration.</para>
		/// <para>
		/// If a configuration has not been added using AddConfiguration, it can be automatically added and then activated by calling <c>ActivateConfiguration</c>.
		/// </para>
		/// <para><c>Note</c> If input processing is occurring, this call will fail.</para>
		/// <para>This method fails if a drag and drop behavior has been specified.</para>
		/// <para>A drag and drop behavior object cannot be attached after successfully calling this method.</para>
		/// <para>Examples</para>
		/// <para>The following example shows how to configure a viewport for horizontal panning.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-activateconfiguration
		// HRESULT ActivateConfiguration( [in] DIRECTMANIPULATION_CONFIGURATION configuration );
		new void ActivateConfiguration([In] DIRECTMANIPULATION_CONFIGURATION configuration);

		/// <summary>Sets which gestures are ignored by Direct Manipulation.</summary>
		/// <param name="configuration">One of the values from DIRECTMANIPULATION_GESTURE_CONFIGURATION.</param>
		/// <remarks>
		/// <para>
		/// Use this method to specify which gestures the application processes on the UI thread. If a gesture is recognized, it will be
		/// passed to the application for processing and ignored by Direct Manipulation.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example shows how zoom gestures can be ignored by Direct Manipulation and handled by the application, which may
		/// have custom zoom behavior implementation.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-setmanualgesture
		// HRESULT SetManualGesture( [in] DIRECTMANIPULATION_GESTURE_CONFIGURATION configuration );
		new void SetManualGesture([In] DIRECTMANIPULATION_GESTURE_CONFIGURATION configuration);

		/// <summary>Specifies the motion types supported in a viewport that can be chained to a parent viewport.</summary>
		/// <param name="enabledTypes">
		/// One of the values from DIRECTMANIPULATION_MOTION_TYPES that specifies the motion types that are enabled for this viewport.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-setchaining
		// HRESULT SetChaining( [in] DIRECTMANIPULATION_MOTION_TYPES enabledTypes );
		new void SetChaining([In] DIRECTMANIPULATION_MOTION_TYPES enabledTypes);

		/// <summary>Adds a new event handler to listen for viewport events.</summary>
		/// <param name="window">The handle of a window owned by the thread for the event callback.</param>
		/// <param name="eventHandler">
		/// The handler that is called when viewport status and update events occur. The specified object must implement the
		/// IDirectManipulationViewportEventHandler interface.
		/// </param>
		/// <param name="cookie">The handle that represents this event handler callback.</param>
		/// <remarks>
		/// <para>
		/// The event callback is fired from the thread that owns the specified window. Consecutive events of the same callback method may be coalesced.
		/// </para>
		/// <para><c>Note</c> If the viewport has a drag-drop behavior attached, the event handler should implement IDirectManipulationDragDropEventHandler.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-addeventhandler
		// HRESULT AddEventHandler( [in] HWND window, [in] IDirectManipulationViewportEventHandler *eventHandler, [out, retval] DWORD *cookie );
		new void AddEventHandler([In, Optional] HWND window, [In] IDirectManipulationViewportEventHandler eventHandler, out uint cookie);

		/// <summary>Removes an existing event handler from the viewport.</summary>
		/// <param name="cookie">A value that was returned by a previous call to AddEventHandler.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-removeeventhandler
		// HRESULT RemoveEventHandler( [in] DWORD cookie );
		new void RemoveEventHandler(uint cookie);

		/// <summary>Specifies if input is visible to the UI thread.</summary>
		/// <param name="mode">One of the values from DIRECTMANIPULATION_INPUT_MODE.</param>
		/// <remarks>
		/// <para>DIRECTMANIPULATION_INPUT_MODE_AUTOMATIC is the default mode for Direct Manipulation.</para>
		/// <para>
		/// Direct Manipulation consumes all the input that drives the manipulation and the application receives WM_POINTERCAPTURECHANGED messages.
		/// </para>
		/// <para>
		/// In some situations an application may want to receive input that is driving a manipulation. Set
		/// DIRECTMANIPULATION_INPUT_MODE_MANUAL in this case. The application will receive all input messages, even input used by Direct
		/// Manipulation to drive a manipulation.
		/// </para>
		/// <para><c>Note</c> The application will not receive WM_POINTERCAPTURECHANGED messages.</para>
		/// <para>
		/// Calling this method with DIRECTMANIPULATION_INPUT_MODE_MANUAL set is similar to calling
		/// SetViewportOptions(DIRECTMANIPULATION_VIEWPORT_OPTIONS_INPUT). However, calling <c>SetViewportOptions</c> also overrides all
		/// other settings.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example shows how to use this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-setinputmode
		// HRESULT SetInputMode( [in] DIRECTMANIPULATION_INPUT_MODE mode );
		new void SetInputMode([In] DIRECTMANIPULATION_INPUT_MODE mode);

		/// <summary>Specifies whether a viewport updates content manually instead of during an input event.</summary>
		/// <param name="mode">One of the values from DIRECTMANIPULATION_INPUT_MODE.</param>
		/// <remarks>
		/// <para>
		/// DIRECTMANIPULATION_INPUT_MODE_AUTOMATIC is the default mode for Direct Manipulation. In this mode, visual updates are pushed to
		/// compositor driven by input. This is the expected mode of operation if the application is using system-provided implementation of IDirectManipulationCompositor.
		/// </para>
		/// <para>
		/// If the application provides its own implementation of IDirectManipulationCompositor, it should switch viewport update mode to
		/// manual by setting DIRECTMANIPULATION_INPUT_MODE_MANUAL. When in manual mode, the compositor pulls visual updates whenever it
		/// calls Update on Direct Manipulation.
		/// </para>
		/// <para>
		/// Calling this method with DIRECTMANIPULATION_INPUT_MODE_MANUAL set is similar to calling
		/// SetViewportOptions(DIRECTMANIPULATION_VIEWPORT_OPTIONS_INPUT). However, calling <c>SetViewportOptions</c> also overrides all
		/// other settings.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-setupdatemode
		// HRESULT SetUpdateMode( [in] DIRECTMANIPULATION_INPUT_MODE mode );
		new void SetUpdateMode([In] DIRECTMANIPULATION_INPUT_MODE mode);

		/// <summary>Stops the manipulation and returns the viewport to a ready state.</summary>
		/// <remarks>If a mandatory snap point has been configured, the content may animate to the nearest snap point.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-stop
		// HRESULT Stop();
		new void Stop();

		/// <summary>Releases all resources that are used by the viewport and prepares it for destruction from memory.</summary>
		/// <remarks>
		/// Once <c>Abandon</c> has been called, do not make subsequent function calls on the viewport. If a function is called after
		/// <c>Abandon</c>, <c>E_INVALID_STATE</c> will be returned.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport-abandon
		// HRESULT Abandon();
		new void Abandon();

		/// <summary>Adds a behavior to the viewport and returns a cookie to the caller.</summary>
		/// <param name="behavior">A behavior created using the CreateBehavior method.</param>
		/// <param name="cookie">
		/// A cookie is returned so the caller can remove this behavior later. This allows the caller to release any reference on the
		/// behavior and let Direct Manipulation maintain an appropriate lifetime, similar to event handlers.
		/// </param>
		/// <remarks>
		/// A behavior takes effect immediately after <c>AddBehavior</c> is called. This must be considered when adding a behavior during an
		/// active manipulation or inertia phase.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport2-addbehavior
		// HRESULT AddBehavior( [in] IUnknown *behavior, [out, retval] DWORD *cookie );
		void AddBehavior([In, MarshalAs(UnmanagedType.IUnknown)] object behavior, out uint cookie);

		/// <summary>Removes a behavior from the viewport that matches the given cookie.</summary>
		/// <param name="cookie">A valid cookie returned from the AddBehavior call on the same viewport.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport2-removebehavior
		// HRESULT RemoveBehavior( [in] DWORD cookie );
		void RemoveBehavior(uint cookie);

		/// <summary>Removes all behaviors added to the viewport.</summary>
		/// <remarks>
		/// <c>RemoveAllBehaviors</c> only returns an error if the removal of a behavior from the viewport was unsuccessful. In the event
		/// that a specific behavior is not removed successfully, <c>RemoveAllBehaviors</c> removes all remaining behaviors.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewport2-removeallbehaviors
		// HRESULT RemoveAllBehaviors();
		void RemoveAllBehaviors();
	}

	/// <summary>
	/// <para>Defines methods for handling status and update events for the viewport.</para>
	/// <para>
	/// <c>Note</c> When implementing a Direct Manipulation object, ensure that the IUnknown implementation supports multithreading through
	/// thread-safe reference counting. For more information, see InterlockedIncrement and InterlockedDecrement.
	/// </para>
	/// </summary>
	/// <remarks>
	/// Client apps implement this handler to receive status and update events for viewports. Use AddEventHandler to set the handler for a
	/// viewport. Each viewport can have more than one handler.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nn-directmanipulation-idirectmanipulationviewporteventhandler
	[PInvokeData("directmanipulation.h", MSDNShortId = "NN:directmanipulation.IDirectManipulationViewportEventHandler")]
	[ComImport, Guid("952121DA-D69F-45F9-B0F9-F23944321A6D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDirectManipulationViewportEventHandler
	{
		/// <summary>Called when the status of a viewport changes.</summary>
		/// <param name="viewport">The viewport for which status has changed.</param>
		/// <param name="current">The new status of the viewport.</param>
		/// <param name="previous">The previous status of the viewport.</param>
		/// <returns>If the method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// If you call GetStatus from within this handler, the status returned is not guaranteed to be the same as at the time of the call.
		/// This is because of the asynchronous nature of the notification.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewporteventhandler-onviewportstatuschanged
		// HRESULT OnViewportStatusChanged( [in] IDirectManipulationViewport *viewport, [in] DIRECTMANIPULATION_STATUS current, [in]
		// DIRECTMANIPULATION_STATUS previous );
		[PreserveSig]
		HRESULT OnViewportStatusChanged([In] IDirectManipulationViewport viewport, [In] DIRECTMANIPULATION_STATUS current, [In] DIRECTMANIPULATION_STATUS previous);

		/// <summary>Called after all content in the viewport has been updated.</summary>
		/// <param name="viewport">The viewport that has been updated.</param>
		/// <returns>If the method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// If you have actions that need to be executed once for a viewport update, implement <c>OnViewportUpdated</c>. OnContentUpdated is
		/// called once for each content change in the viewport. This can result in multiple <c>OnContentUpdated</c> calls.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewporteventhandler-onviewportupdated
		// HRESULT OnViewportUpdated( [in] IDirectManipulationViewport *viewport );
		[PreserveSig]
		HRESULT OnViewportUpdated([In] IDirectManipulationViewport viewport);

		/// <summary>Called when content inside a viewport is updated.</summary>
		/// <param name="viewport">The viewport that is updated.</param>
		/// <param name="content">The content in the viewport that has changed.</param>
		/// <returns>If the method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// This method is called once for each content change in the viewport. This can result in multiple <c>OnContentUpdated</c> calls.
		/// For instance, when the position of the content is changed, you can use IDirectManipualtionContent::GetContentTransform to
		/// retrieve the new value.
		/// </para>
		/// <para>If you have actions that need to be executed once for a viewport update, implement OnViewportUpdated.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/directmanipulation/nf-directmanipulation-idirectmanipulationviewporteventhandler-oncontentupdated
		// HRESULT OnContentUpdated( [in] IDirectManipulationViewport *viewport, [in] IDirectManipulationContent *content );
		[PreserveSig]
		HRESULT OnContentUpdated([In] IDirectManipulationViewport viewport, [In] IDirectManipulationContent content);
	}

	/// <summary>Retrieves the transform applied to the content.</summary>
	/// <param name="obj">A IDirectManipulationContent instance.</param>
	/// <returns>The transform matrix.</returns>
	/// <remarks>
	/// <para>This transform contains the default overpan and bounce curves during manipulation and inertia.</para>
	/// <para>This transform does not contain the sync transform set with SyncContentTransform.</para>
	/// </remarks>
	public static float[] GetContentTransform(this IDirectManipulationContent obj)
	{
		float[] f = new float[6];
		obj.GetContentTransform(f);
		return f;
	}

	/// <summary>Gets the final transform, including inertia, of the primary content.</summary>
	/// <param name="obj">The IDirectManipulationPrimaryContent object.</param>
	/// <returns>The transformed matrix that represents the inertia ending position.</returns>
	/// <remarks>
	/// <c>Warning</c> Calling this method can cause a race condition if inertia has ended or been interrupted. This can also occur during
	/// the OnViewportStatusChanged callback.
	/// </remarks>
	public static float[] GetInertiaEndTransform(this IDirectManipulationPrimaryContent obj)
	{
		float[] f = new float[6];
		obj.GetInertiaEndTransform(f);
		return f;
	}

	/// <summary>Gets the final transform applied to the content.</summary>
	/// <param name="obj">A IDirectManipulationContent instance.</param>
	/// <returns>The transform matrix.</returns>
	/// <remarks>
	/// <para>This transform might contain the other custom curves applied during manipulation and inertia.</para>
	/// <para>This transform contains both the content transform and the sync transform set with SyncContentTransform.</para>
	/// </remarks>
	public static float[] GetOutputTransform(this IDirectManipulationContent obj)
	{
		float[] f = new float[6];
		obj.GetOutputTransform(f);
		return f;
	}

	/// <summary>Retrieves the tag object set on this content.</summary>
	/// <typeparam name="T">A reference to the identifier of the interface to use. The tag object typically implements this interface.</typeparam>
	/// <param name="obj">A IDirectManipulationContent instance.</param>
	/// <param name="object">The tag object.</param>
	/// <param name="id">The ID portion of the tag.</param>
	/// <remarks>
	/// <para>
	/// <c>GetTag</c> and SetTag are useful for associating an external COM object with the content without an external mapping between the
	/// two. They can also be used to pass information to callbacks generated for the content.
	/// </para>
	/// <para><c>GetTag</c> queries the tag value for the specified interface and returns a pointer to that interface.</para>
	/// <para>
	/// A tag is a pairing of an integer ID ( <c>id</c>) with a Component Object Model (COM) object ( <c>object</c>). It can be used by an
	/// app to identify a motion. The parameters are optional, so that the method can return both parts of the tag, the identifier portion,
	/// or the tag object.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows the syntax for this method.</para>
	/// </remarks>
	public static void GetTag<T>(this IDirectManipulationContent obj, out T @object, out uint id) where T : class
	{
		obj.GetTag(typeof(T).GUID, out object o, out id);
		@object = (T)o;
	}

	/// <summary>Retrieves the viewport that contains the content.</summary>
	/// <typeparam name="T">A reference to the identifier of the interface to use.</typeparam>
	/// <param name="obj">A IDirectManipulationContent instance.</param>
	/// <returns>The viewport object.</returns>
	public static T GetViewport<T>(this IDirectManipulationContent obj) where T : class => (T)obj.GetViewport(typeof(T).GUID);

	/// <summary>CLSID_DCompManipulationCompositor</summary>
	[ComImport, Guid("79DEA627-A08A-43AC-8EF5-6900B9299126"), ClassInterface(ClassInterfaceType.None)]
	public class DCompManipulationCompositor { }

	/// <summary>CLSID_DirectManipulationManager</summary>
	[ComImport, Guid("54E211B6-3650-4F75-8334-FA359598E1C5"), ClassInterface(ClassInterfaceType.None)]
	public class DirectManipulationManager { }

	/// <summary>CLSID_DirectManipulationPrimaryContent</summary>
	[ComImport, Guid("CAA02661-D59E-41C7-8393-3BA3BACB6B57"), ClassInterface(ClassInterfaceType.None)]
	public class DirectManipulationPrimaryContent { }

	/// <summary>CLSID_DirectManipulationSharedManager</summary>
	[ComImport, Guid("99793286-77CC-4B57-96DB-3B354F6F9FB5"), ClassInterface(ClassInterfaceType.None)]
	public class DirectManipulationSharedManager { }

	/// <summary>CLSID_DirectManipulationUpdateManager</summary>
	[ComImport, Guid("9FC1BFD5-1835-441A-B3B1-B6CC74B727D0"), ClassInterface(ClassInterfaceType.None)]
	public class DirectManipulationUpdateManager { }

	/// <summary>CLSID_DirectManipulationViewport</summary>
	[ComImport, Guid("34E211B6-3650-4F75-8334-FA359598E1C5"), ClassInterface(ClassInterfaceType.None)]
	public class DirectManipulationViewport { }
}