using static Vanara.PInvoke.DocumentTarget;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

/// <summary>Items defined in DocumentSource.idl.</summary>
// https://docs.microsoft.com/en-us/windows/win32/api/documentsource/
public static partial class DocumentSource
{
	/// <summary>Implemented by the app to provide access to the content to be printed.</summary>
	[ComImport, Guid("a96bb1db-172e-4667-82b5-ad97a252318f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPrintDocumentPageSource
	{
		/// <summary>Requests that the document source creates a preview page collection for the document being printed.</summary>
		/// <param name="docPackageTarget">A pointer to the package target.</param>
		/// <param name="docPageCollection">A pointer to the destination for the preview images.</param>
		/// <returns>
		/// If the GetPreviewPageCollection method completes successfully, it returns an S_OK. Otherwise it returns an appropriate
		/// HRESULT error code.
		/// </returns>
		/// <remarks>For details on how to extract and use GetPreviewPageCollection, see IPrintPreviewDxgiPackageTarget.</remarks>
		[PreserveSig]
		HRESULT GetPreviewPageCollection(IPrintDocumentPackageTarget docPackageTarget, out IPrintPreviewPageCollection docPageCollection);

		/// <summary>Informs the app to create the document.</summary>
		/// <param name="printTaskOptions">The print options.</param>
		/// <param name="docPackageTarget">The packaged target types.</param>
		/// <returns>
		/// If the MakeDocument method completes successfully, it returns an S_OK. Otherwise it returns an appropriate HRESULT error code.
		/// </returns>
		[PreserveSig]
		HRESULT MakeDocument(IInspectable printTaskOptions, IPrintDocumentPackageTarget docPackageTarget);
	}

	/// <summary>Implemented by the app to provide access to print preview pages.</summary>
	[ComImport, Guid("0b31cc62-d7ec-4747-9d6e-f2537d870f2b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPrintPreviewPageCollection
	{
		/// <summary>
		/// This method is called whenever the system detects that the physical dimensions of the page has changed or when the app has
		/// requested pagination via a call to IPrintPreviewDxgiPreviewTarget::InvalidatePreview.
		/// </summary>
		/// <param name="currentJobPage">The current page being displayed to the user.</param>
		/// <param name="printTaskOptions">The print options.</param>
		/// <returns>
		/// If the Paginate method completes successfully, it returns an S_OK. Otherwise it returns an appropriate HRESULT error code.
		/// </returns>
		/// <remarks>
		/// For standard options which result in changes to the physical layout of the page, the system will automatically generate a
		/// Paginate call. The app does not need to call IPrintPreviewDxgiPackageTarget::InvalidatePreview in these scenarios; e.g.
		/// portrait changed to landscape. For custom options such as handling greyscale and color, apps should call InvalidatePreview
		/// to trigger a pagination.
		/// <para><c>Note</c> A Pagination request does not have to require a new pagination to occur.</para>
		/// <para>
		/// Apps should examine the state of the provided printTaskOptions and determine if the changes warrant a repagination.For
		/// example, if the imageable area changes and the content already fits within the new imageable area there is no need to
		/// perform a new pagination.
		/// </para>
		/// <para>
		/// An app may use the currentJobPage parameter to determine what page is visible if it wants to maintain user context when the
		/// layout changes.For example, keeping the same content on the screen when orientation switches from portrait to landscape.
		/// </para>
		/// </remarks>
		[PreserveSig]
		HRESULT Paginate(uint currentJobPage, IInspectable printTaskOptions);

		/// <summary>Provides the system with a new page to present in print preview.</summary>
		/// <param name="desiredJobPage">The page number.</param>
		/// <param name="width">The width of the page.</param>
		/// <param name="height">The height of the page.</param>
		/// <returns>
		/// If the MakePage method completes successfully, it returns an S_OK. Otherwise it returns an appropriate HRESULT error code.
		/// </returns>
		/// <remarks>
		/// Apps should not assume that the system will cache all retrieved pages. For example, the system may ask for page 1 again
		/// without making a call to Paginate first. When the desiredJobPage is JOB_PAGE_APPLICATION_DEFINED the app may return the page
		/// to be presented as the next preview page. The page number provided in the next call to
		/// IPrintPreviewDxgiPackageTarget::MakePage will be used as the next page to show the user. When a specific page is requested
		/// this is the page that is being requested by the preview experience and the app should respond with this page. Page counts
		/// are 1-based and desiredJobPage is 1 when requesting the first page of the document.
		/// </remarks>
		[PreserveSig]
		HRESULT MakePage(uint desiredJobPage, float width, float height);
	}
}