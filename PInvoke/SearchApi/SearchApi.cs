using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using static Vanara.PInvoke.Ole32;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class SearchApi
	{
		/// <summary>Describes authentication types for content access.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ne-searchapi-auth_type typedef enum _AUTH_TYPE {
		// eAUTH_TYPE_ANONYMOUS, eAUTH_TYPE_NTLM, eAUTH_TYPE_BASIC } AUTH_TYPE;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		public enum AUTH_TYPE
		{
			/// <summary>Anonymous.</summary>
			eAUTH_TYPE_ANONYMOUS,

			/// <summary>NTLM challenge/response.</summary>
			eAUTH_TYPE_NTLM,

			/// <summary>Basic authentication.</summary>
			eAUTH_TYPE_BASIC,
		}

		/// <summary>Used by ISearchCatalogManager::GetCatalogStatus to determine the reason the catalog is paused.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ne-searchapi-catalogpausedreason typedef enum _CatalogPausedReason
		// { CATALOG_PAUSED_REASON_NONE, CATALOG_PAUSED_REASON_HIGH_IO, CATALOG_PAUSED_REASON_HIGH_CPU, CATALOG_PAUSED_REASON_HIGH_NTF_RATE,
		// CATALOG_PAUSED_REASON_LOW_BATTERY, CATALOG_PAUSED_REASON_LOW_MEMORY, CATALOG_PAUSED_REASON_LOW_DISK,
		// CATALOG_PAUSED_REASON_DELAYED_RECOVERY, CATALOG_PAUSED_REASON_USER_ACTIVE, CATALOG_PAUSED_REASON_EXTERNAL,
		// CATALOG_PAUSED_REASON_UPGRADING } CatalogPausedReason;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		public enum CatalogPausedReason
		{
			/// <summary>Not paused.</summary>
			CATALOG_PAUSED_REASON_NONE,

			/// <summary>Paused due to high I/O.</summary>
			CATALOG_PAUSED_REASON_HIGH_IO,

			/// <summary>Paused due to high CPU usage.</summary>
			CATALOG_PAUSED_REASON_HIGH_CPU,

			/// <summary>Paused due to high NTF rate.</summary>
			CATALOG_PAUSED_REASON_HIGH_NTF_RATE,

			/// <summary>Paused due to low battery.</summary>
			CATALOG_PAUSED_REASON_LOW_BATTERY,

			/// <summary>Paused due to low memory.</summary>
			CATALOG_PAUSED_REASON_LOW_MEMORY,

			/// <summary>Paused due to low disk space.</summary>
			CATALOG_PAUSED_REASON_LOW_DISK,

			/// <summary>Paused due to need for delayed recovery.</summary>
			CATALOG_PAUSED_REASON_DELAYED_RECOVERY,

			/// <summary>Paused due to user activity.</summary>
			CATALOG_PAUSED_REASON_USER_ACTIVE,

			/// <summary>Paused by external request.</summary>
			CATALOG_PAUSED_REASON_EXTERNAL,

			/// <summary>Paused by upgrading.</summary>
			CATALOG_PAUSED_REASON_UPGRADING,
		}

		/// <summary>Used by ISearchCatalogManager::GetCatalogStatus to determine the current state of the catalog.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ne-searchapi-_catalogstatus typedef enum _CatalogStatus {
		// CATALOG_STATUS_IDLE, CATALOG_STATUS_PAUSED, CATALOG_STATUS_RECOVERING, CATALOG_STATUS_FULL_CRAWL,
		// CATALOG_STATUS_INCREMENTAL_CRAWL, CATALOG_STATUS_PROCESSING_NOTIFICATIONS, CATALOG_STATUS_SHUTTING_DOWN } CatalogStatus;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		public enum CatalogStatus
		{
			/// <summary>Index is current; no indexing needed. Queries can be processed.</summary>
			CATALOG_STATUS_IDLE,

			/// <summary>
			/// Indexer is paused. This can happen either because the user paused indexing or the indexer back-off criteria have been met.
			/// Queries can be processed.
			/// </summary>
			CATALOG_STATUS_PAUSED,

			/// <summary>Index is recovering; queries and indexing are processed while in this state.</summary>
			CATALOG_STATUS_RECOVERING,

			/// <summary>
			/// Indexer is currently executing a full crawl and will index everything it is configured to index. Queries can be processed
			/// while indexing.
			/// </summary>
			CATALOG_STATUS_FULL_CRAWL,

			/// <summary>
			/// Indexer is preforming a crawl to see if anything has changed or requires indexing. Queries can be processed while indexing.
			/// </summary>
			CATALOG_STATUS_INCREMENTAL_CRAWL,

			/// <summary>Indexer is processing the notification queue. This is done before resuming any crawl.</summary>
			CATALOG_STATUS_PROCESSING_NOTIFICATIONS,

			/// <summary>Indexer is shutting down and is not indexing. Indexer can't be queried.</summary>
			CATALOG_STATUS_SHUTTING_DOWN,
		}

		/// <summary>Describes the type of break that separates the current chunk from the previous chunk.</summary>
		// typedef enum tagCHUNK_BREAKTYPE { CHUNK_NO_BREAK = 0, CHUNK_EOW = 1, CHUNK_EOS = 2, CHUNK_EOP = 3, CHUNK_EOC = 4} CHUNK_BREAKTYPE; https://msdn.microsoft.com/en-us/library/windows/desktop/bb266509(v=vs.85).aspx
		[PInvokeData("Filter.h", MSDNShortId = "bb266509")]
		public enum CHUNK_BREAKTYPE
		{
			/// <summary>No break is placed between the current chunk and the previous chunk. The chunks are glued together.</summary>
			CHUNK_NO_BREAK,

			/// <summary>
			/// A word break is placed between this chunk and the previous chunk having the same attribute. Use of CHUNK_EOW should be
			/// minimized because the choice of word breaks is language-dependent, so determining word breaks is best left to the search engine.
			/// </summary>
			CHUNK_EOW,

			/// <summary>A sentence break is placed between this chunk and the previous chunk having the same attribute.</summary>
			CHUNK_EOS,

			/// <summary>A paragraph break is placed between this chunk and the previous chunk having the same attribute.</summary>
			CHUNK_EOP,

			/// <summary>A chapter break is placed between this chunk and the previous chunk having the same attribute.</summary>
			CHUNK_EOC,
		}

		/// <summary>Specifies whether the current chunk is a text-type property or a value-type property.</summary>
		// typedef enum tagCHUNKSTATE { CHUNK_TEXT = 0x1, CHUNK_VALUE = 0x2, CHUNK_FILTER_OWNED_VALUE = 0x4} CHUNKSTATE; https://msdn.microsoft.com/en-us/library/windows/desktop/bb266508(v=vs.85).aspx
		[PInvokeData("Filter.h", MSDNShortId = "bb266508")]
		public enum CHUNKSTATE
		{
			/// <summary>The current chunk is a text-type property.</summary>
			CHUNK_TEXT = 0x1,

			/// <summary>The current chunk is a value-type property.</summary>
			CHUNK_VALUE = 0x2,

			/// <summary>Reserved.</summary>
			CHUNK_FILTER_OWNED_VALUE = 0x4
		}

		/// <summary>
		/// These flags enumerate reasons why URLs are included or excluded from the current crawl scope. The
		/// ISearchCrawlScopeManager::IncludedInCrawlScopeEx method returns a pointer to this enumeration to explain why a specified URL is
		/// either included or excluded from the current crawl scope.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ne-searchapi-clusion_reason typedef enum
		// __MIDL___MIDL_itf_searchapi_0000_0013_0001 { CLUSIONREASON_UNKNOWNSCOPE, CLUSIONREASON_DEFAULT, CLUSIONREASON_USER,
		// CLUSIONREASON_GROUPPOLICY } CLUSION_REASON;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		public enum CLUSION_REASON
		{
			/// <summary>
			/// The URL has been excluded because its scope in unknown. There is no scope that would include or exclude this URL so it is
			/// excluded by default.
			/// </summary>
			CLUSIONREASON_UNKNOWNSCOPE,

			/// <summary>The URL has been included or excluded by a default rule. Default rules are set during setup or first run.</summary>
			CLUSIONREASON_DEFAULT,

			/// <summary>
			/// The URL has been included or excluded by a user rule. User rules are set either by the user through Control Panel or by a
			/// calling application through the ISearchCrawlScopeManager interface.
			/// </summary>
			CLUSIONREASON_USER,

			/// <summary>Not Supported.</summary>
			CLUSIONREASON_GROUPPOLICY,
		}

		/// <summary>
		/// Used to help define behavior when crawling or indexing. These flags are used by the ISearchCrawlScopeManager::AddDefaultScopeRule
		/// and ISearchCrawlScopeManager::AddUserScopeRule methods.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ne-searchapi-_follow_flags typedef enum _FOLLOW_FLAGS {
		// FF_INDEXCOMPLEXURLS, FF_SUPPRESSINDEXING } FOLLOW_FLAGS;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		[Flags]
		public enum FOLLOW_FLAGS
		{
			/// <summary>Specifies whether complex URLs (those containing a '?') should be indexed.</summary>
			FF_INDEXCOMPLEXURLS = 1,

			/// <summary>Follow but do not index this URL.</summary>
			FF_SUPPRESSINDEXING = 2,
		}

		/// <summary>
		/// Indicates whether the caller should use the IPropertySetStorage and IPropertyStorage interfaces to locate additional properties.
		/// </summary>
		// typedef enum tagIFILTER_FLAGS { IFILTER_FLAGS_OLE_PROPERTIES = 1} IFILTER_FLAGS; https://msdn.microsoft.com/en-us/library/windows/desktop/bb266510(v=vs.85).aspx
		[PInvokeData("Filter.h", MSDNShortId = "bb266510")]
		public enum IFILTER_FLAGS
		{
			/// <summary>
			/// The caller should use the IPropertySetStorage and IPropertyStorage interfaces to locate additional properties. When this flag
			/// is set, properties available through COM enumerators should not be returned from <c>IFilter</c>.
			/// </summary>
			IFILTER_FLAGS_OLE_PROPERTIES = 1
		}

		/// <summary>
		/// <para>Contains flags that control:</para>
		/// <para>The <c>Init</c> method uses these flags to control the filtering process.</para>
		/// </summary>
		// typedef enum tagIFILTER_INIT { IFILTER_INIT_CANON_PARAGRAPHS = 1, IFILTER_INIT_HARD_LINE_BREAKS = 2, IFILTER_INIT_CANON_HYPHENS =
		// 4, IFILTER_INIT_CANON_SPACES = 8, IFILTER_INIT_APPLY_INDEX_ATTRIBUTES = 16, IFILTER_INIT_APPLY_CRAWL_ATTRIBUTES = 256,
		// IFILTER_INIT_APPLY_OTHER_ATTRIBUTES = 32, IFILTER_INIT_INDEXING_ONLY = 64, IFILTER_INIT_SEARCH_LINKS = 128,
		// IFILTER_INIT_FILTER_OWNED_VALUE_OK = 512, IFILTER_INIT_FILTER_AGGRESSIVE_BREAK = 1024, IFILTER_INIT_DISABLED_EMBEDDED = 2048,
		// IFILTER_INIT_EMIT_FORMATTING = 4096} IFILTER_INIT; https://msdn.microsoft.com/en-us/library/windows/desktop/bb266511(v=vs.85).aspx
		[PInvokeData("Filter.h", MSDNShortId = "bb266511")]
		[Flags]
		public enum IFILTER_INIT
		{
			/// <summary>Paragraph breaks should be marked with the Unicode PARAGRAPH SEPARATOR (0x2029).</summary>
			IFILTER_INIT_CANON_PARAGRAPHS = 1,

			/// <summary>
			/// Soft returns, such as the newline character in Word, should be replaced by hard returns?LINE SEPARATOR (0x2028). Existing
			/// hard returns can be doubled. A carriage return (0x000D), line feed (0x000A), or the carriage return and line feed in
			/// combination should be considered a hard return. The intent is to enable pattern-expression matching against observed line breaks.
			/// </summary>
			IFILTER_INIT_HARD_LINE_BREAKS = 2,

			/// <summary>
			/// Various word-processing programs have forms of hyphens that are not represented in the host character set, such as optional
			/// hyphens (appearing only at the end of a line) and nonbreaking hyphens. This flag indicates that optional hyphens are to be
			/// converted to nulls, and non-breaking hyphens are to be converted to normal hyphens (0x2010), or HYPHEN-MINUSES (0x002D).
			/// </summary>
			IFILTER_INIT_CANON_HYPHENS = 4,

			/// <summary>All special space characters, such as nonbreaking spaces, are converted to the standard space character (0x0020).</summary>
			IFILTER_INIT_CANON_SPACES = 8,

			/// <summary>The client requires that text is split into chunks that represent internal value-type properties.</summary>
			IFILTER_INIT_APPLY_INDEX_ATTRIBUTES = 16,

			/// <summary>The client wants text split into chunks representing properties determined during the indexing process.</summary>
			IFILTER_INIT_APPLY_CRAWL_ATTRIBUTES = 256,

			/// <summary>
			/// Any properties not covered by the IFILTER_INIT_APPLY_INDEX_ATTRIBUTES and IFILTER_INIT_APPLY_CRAWL_ATTRIBUTES flags should be emitted.
			/// </summary>
			IFILTER_INIT_APPLY_OTHER_ATTRIBUTES = 32,

			/// <summary>The client calls the <c>Init</c> method only once, optimizing <c>IFilter</c> for indexing.</summary>
			IFILTER_INIT_INDEXING_ONLY = 64,

			/// <summary>
			/// The text extraction process must recursively search all linked objects within the document. If a link is unavailable, the
			/// <c>GetChunk</c> call that would have obtained the first chunk of the link should return FILTER_E_LINK_UNAVAILABLE.
			/// </summary>
			IFILTER_INIT_SEARCH_LINKS = 128,

			/// <summary>The content indexing process can return property values set by the filter.</summary>
			IFILTER_INIT_FILTER_OWNED_VALUE_OK = 512,

			/// <summary>Text should be broken in chunks more aggressively than normal.</summary>
			IFILTER_INIT_FILTER_AGGRESSIVE_BREAK = 1024,

			/// <summary>The <c>IFilter</c> should not return chunks from embedded content.</summary>
			IFILTER_INIT_DISABLED_EMBEDDED = 2048,

			/// <summary>The <c>IFilter</c> should emit formatting info.</summary>
			IFILTER_INIT_EMIT_FORMATTING = 4096,
		}

		/// <summary>Used by PrioritizeMatchingURLs to specify how to process items the indexer has previously failed to index.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ne-searchapi-tagprioritize_flags typedef enum tagPRIORITIZE_FLAGS {
		// PRIORITIZE_FLAG_RETRYFAILEDITEMS, PRIORITIZE_FLAG_IGNOREFAILURECOUNT } ;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		[Flags]
		public enum PRIORITIZE_FLAGS
		{
			/// <summary>Indicates that the indexer should reattempt to index items that it failed to index previously.</summary>
			PRIORITIZE_FLAG_RETRYFAILEDITEMS = 1,

			/// <summary>
			/// Indicates that the indexer should continue to reattempt indexing items regardless of the number of times the indexer has
			/// failed to index them previously.
			/// </summary>
			PRIORITIZE_FLAG_IGNOREFAILURECOUNT = 2,
		}

		/// <summary>
		/// Used by the IRowsetPrioritization interface to sets or retrieve the current indexer prioritization level for the scope specified
		/// by a query.
		/// </summary>
		/// <remarks>
		/// The SearchEvents code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to prioritize indexing events.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ne-searchapi-priority_level typedef enum
		// __MIDL___MIDL_itf_searchapi_0000_0022_0001 { PRIORITY_LEVEL_FOREGROUND, PRIORITY_LEVEL_HIGH, PRIORITY_LEVEL_LOW,
		// PRIORITY_LEVEL_DEFAULT } PRIORITY_LEVEL;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		public enum PRIORITY_LEVEL
		{
			/// <summary>Indicates that the indexer should process items as fast as the machine allows.</summary>
			PRIORITY_LEVEL_FOREGROUND,

			/// <summary>Indicates that the indexer should process items in this scope first, and as quickly as possible.</summary>
			PRIORITY_LEVEL_HIGH,

			/// <summary>
			/// Indicates that the indexer should process items in this scope before those at the normal rate, but after any other
			/// prioritization requests.
			/// </summary>
			PRIORITY_LEVEL_LOW,

			/// <summary>Indicates that the indexer should process items at the normal indexer rate.</summary>
			PRIORITY_LEVEL_DEFAULT,
		}

		/// <summary>Used by ISearchManager to state proxy use.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ne-searchapi-_proxy_access typedef enum _PROXY_ACCESS {
		// PROXY_ACCESS_PRECONFIG, PROXY_ACCESS_DIRECT, PROXY_ACCESS_PROXY } PROXY_ACCESS;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		public enum PROXY_ACCESS
		{
			/// <summary>Use proxy as set by Internet settings.</summary>
			PROXY_ACCESS_PRECONFIG,

			/// <summary>Do not use a proxy.</summary>
			PROXY_ACCESS_DIRECT,

			/// <summary>Use the specified proxy.</summary>
			PROXY_ACCESS_PROXY,
		}

		/// <summary>Describes whether an item that matches the search criteria of a rowset is currently in that rowset.</summary>
		/// <remarks>
		/// <para>This enumeration is used by IRowsetEvents to describe the state of rows in a rowset held by a client.</para>
		/// <para>
		/// The SearchEvents code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to prioritize indexing events.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/ja-jp/windows/desktop/api/searchapi/ne-searchapi-rowsetevent_itemstate typedef enum
		// __MIDL___MIDL_itf_searchapi_0000_0023_0001 { ROWSETEVENT_ITEMSTATE_NOTINROWSET, ROWSETEVENT_ITEMSTATE_INROWSET,
		// ROWSETEVENT_ITEMSTATE_UNKNOWN } ROWSETEVENT_ITEMSTATE;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		public enum ROWSETEVENT_ITEMSTATE
		{
			/// <summary>The item is definitely not in the rowset.</summary>
			ROWSETEVENT_ITEMSTATE_NOTINROWSET,

			/// <summary>The item is definitely contained within the rowset.</summary>
			ROWSETEVENT_ITEMSTATE_INROWSET,

			/// <summary>The item may be in the rowset.</summary>
			ROWSETEVENT_ITEMSTATE_UNKNOWN,
		}

		/// <summary>Describes the type of change to the rowset's data.</summary>
		/// <remarks>
		/// <para>This enumeration is used in the IRowsetEvents::OnRowsetEvent method to describe the type of event that affects a rowset.</para>
		/// <para>
		/// The <c>ROWSETEVENT_TYPE_SCOPESTATISTICS</c> event gives you the same information available from the
		/// IRowsetPrioritization::GetScopeStatistics method call, but through a push mechanic, as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// The event arises if the prioritization API has been used to request a non-default prioritization level, and a non-zero statistics
		/// event frequency.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The event arises only when statistics actually change, and the interval specified in the IRowsetPrioritization has elapsed (the
		/// interval does not guarantee the frequency of the event).
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// This event is guaranteed to raise a "bounce zero" state (zero items remaining to be added, zero modifies remaining), provided
		/// that a non-zero event has been raised.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The indexer may process items without sending this event, if the queue empties before the statistics event frequency.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The SearchEvents code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to prioritize indexing events.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ne-searchapi-rowsetevent_type typedef enum
		// __MIDL___MIDL_itf_searchapi_0000_0023_0002 { ROWSETEVENT_TYPE_DATAEXPIRED, ROWSETEVENT_TYPE_FOREGROUNDLOST,
		// ROWSETEVENT_TYPE_SCOPESTATISTICS } ROWSETEVENT_TYPE;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		public enum ROWSETEVENT_TYPE
		{
			/// <summary>Indicates that data backing the rowset has expired, and that a new rowset should be requested.</summary>
			ROWSETEVENT_TYPE_DATAEXPIRED,

			/// <summary>
			/// Indicates that an item that did have foreground priority in the prioritization stack has been demoted, because someone else
			/// prioritized themselves ahead of this query.
			/// </summary>
			ROWSETEVENT_TYPE_FOREGROUNDLOST,

			/// <summary>Indicates that the scope statistics are to be obtained.</summary>
			ROWSETEVENT_TYPE_SCOPESTATISTICS,
		}

		/// <summary>Specifies the status of the current search indexing phase.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ne-searchapi-_search_indexing_phase typedef enum
		// _SEARCH_INDEXING_PHASE { SEARCH_INDEXING_PHASE_GATHERER, SEARCH_INDEXING_PHASE_QUERYABLE, SEARCH_INDEXING_PHASE_PERSISTED } SEARCH_INDEXING_PHASE;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		public enum SEARCH_INDEXING_PHASE
		{
			/// <summary>
			/// Sent in the event that an error occurs while a notification is in the gatherer. For instance, if the notification fails the
			/// exclusion-rule tests, a status update will be sent with the error.
			/// </summary>
			SEARCH_INDEXING_PHASE_GATHERER,

			/// <summary>The document will be returned in queries. It is currently only in the volatile indexes.</summary>
			SEARCH_INDEXING_PHASE_QUERYABLE,

			/// <summary>The document has moved from the volatile index to the persisted-file-based index.</summary>
			SEARCH_INDEXING_PHASE_PERSISTED,
		}

		/// <summary>Indicates the kind of change affecting an item when a source sink notifies a client that an item has been changed.</summary>
		/// <remarks>
		/// SEARCH_CHANGE_ADD, SEARCH_CHANGE_DELETE, and SEARCH_CHANGE_MODIFY are mutually exclusive. Only one of them can be used at a time.
		/// However, any one of them can be combined with the remaining flags.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ne-searchapi-_search_kind_of_change typedef enum
		// _SEARCH_KIND_OF_CHANGE { SEARCH_CHANGE_ADD, SEARCH_CHANGE_DELETE, SEARCH_CHANGE_MODIFY, SEARCH_CHANGE_MOVE_RENAME,
		// SEARCH_CHANGE_SEMANTICS_DIRECTORY, SEARCH_CHANGE_SEMANTICS_SHALLOW, SEARCH_CHANGE_SEMANTICS_UPDATE_SECURITY } SEARCH_KIND_OF_CHANGE;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		[Flags]
		public enum SEARCH_KIND_OF_CHANGE
		{
			/// <summary>An item was added.</summary>
			SEARCH_CHANGE_ADD,

			/// <summary>An item was deleted.</summary>
			SEARCH_CHANGE_DELETE,

			/// <summary>An item was modified.</summary>
			SEARCH_CHANGE_MODIFY,

			/// <summary>An item was moved or renamed. Not currently supported for use with ISearchPersistentItemsChangedSink::OnItemsChanged.</summary>
			SEARCH_CHANGE_MOVE_RENAME,

			/// <summary>An item is a directory. The item needs to be crawled rather than just reindexed as a document would be.</summary>
			SEARCH_CHANGE_SEMANTICS_DIRECTORY = 0x40000,

			/// <summary>Index directory properties were changed for an item.</summary>
			SEARCH_CHANGE_SEMANTICS_SHALLOW = 0x80000,

			/// <summary>Security on an item was changed.</summary>
			SEARCH_CHANGE_SEMANTICS_UPDATE_SECURITY = 0x400000,
		}

		/// <summary>Indicates the priority of processing an item that has changed.</summary>
		/// <remarks>
		/// <para>Set the <c>priority</c> member of the SEARCH_ITEM_CHANGE structure to one of these flags.</para>
		/// <para>
		/// As the indexer crawls, it builds a list of items that need to be indexed. These flags indicate the placement of changed items in
		/// the indexer's queue. Higher priority items are placed at the front of the queue.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ne-searchapi-search_notification_priority typedef enum
		// _SEARCH_NOTIFICATION_PRIORITY { SEARCH_NORMAL_PRIORITY, SEARCH_HIGH_PRIORITY } SEARCH_NOTIFICATION_PRIORITY;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		public enum SEARCH_NOTIFICATION_PRIORITY
		{
			/// <summary>The changed item is added to the end of the indexer's queue.</summary>
			SEARCH_NORMAL_PRIORITY,

			/// <summary>The changed item is placed ahead of other queued items in the indexer's queue, to be processed as soon as possible.</summary>
			SEARCH_HIGH_PRIORITY,
		}

		/// <summary>Specifies the type of query syntax.</summary>
		/// <remarks>
		/// <para>This enumerated type is used by the ISearchQueryHelper::get_QuerySyntax and ISearchQueryHelper::put_QuerySyntax methods.</para>
		/// <para><c>Note</c> In Windows 7, the names are prefixed with SQS_ instead of SEARCH_.</para>
		/// </remarks>
		// https://docs.microsoft.com/ja-jp/windows/desktop/api/searchapi/ne-searchapi-search_query_syntax typedef enum _SEARCH_QUERY_SYNTAX
		// { SEARCH_NO_QUERY_SYNTAX, SEARCH_ADVANCED_QUERY_SYNTAX, SEARCH_NATURAL_QUERY_SYNTAX } SEARCH_QUERY_SYNTAX;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		public enum SEARCH_QUERY_SYNTAX
		{
			/// <summary>No syntax.</summary>
			SEARCH_NO_QUERY_SYNTAX,

			/// <summary>Specifies the Advanced Query Syntax. For example, "kind:email to:david to:bill".</summary>
			SEARCH_ADVANCED_QUERY_SYNTAX,

			/// <summary>
			/// Specifies the Natural Query Syntax. This syntax removes the requirement for a colon between properties and values, for
			/// example, "email from david to bill".
			/// </summary>
			SEARCH_NATURAL_QUERY_SYNTAX,
		}

		/// <summary>
		/// Indicates wildcard options on search terms. Used by ISearchQueryHelper::get_QueryTermExpansion and
		/// ISearchQueryHelper::put_QueryTermExpansion methods.
		/// </summary>
		/// <remarks>
		/// While the <c>SEARCH_TERM_EXPANSION</c> enumerated type lets you specify stem expansion, Windows Search does not currently support
		/// its use with the ISearchQueryHelper interface.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ne-searchapi-_search_term_expansion typedef enum
		// _SEARCH_TERM_EXPANSION { SEARCH_TERM_NO_EXPANSION, SEARCH_TERM_PREFIX_ALL, SEARCH_TERM_STEM_ALL } SEARCH_TERM_EXPANSION;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		public enum SEARCH_TERM_EXPANSION
		{
			/// <summary>No expansion is applied to search terms.</summary>
			SEARCH_TERM_NO_EXPANSION,

			/// <summary>All search terms are expanded.</summary>
			SEARCH_TERM_PREFIX_ALL,

			/// <summary>Stem expansion is applied to all terms.</summary>
			SEARCH_TERM_STEM_ALL,
		}

		/// <summary>Provides methods to enumerate the search roots of a catalog, for example, SystemIndex.</summary>
		/// <remarks>
		/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK, demonstrates
		/// how to define command line options for Crawl Scope Manager (CSM) indexing operations.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-ienumsearchroots
		[PInvokeData("searchapi.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("AB310581-AC80-11D1-8DF3-00C04FB6EF52")]
		public interface IEnumSearchRoots
		{
			/// <summary>Retrieves the specified number of ISearchRoot elements.</summary>
			/// <param name="celt">
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of elements to retrieve.</para>
			/// </param>
			/// <param name="rgelt">
			/// <para>Type: <c>ISearchRoot**</c></para>
			/// <para>Retrieves a pointer to an array of ISearchRoot elements.</para>
			/// </param>
			/// <param name="pceltFetched">
			/// <para>Type: <c>ULONG*</c></para>
			/// <para>
			/// Retrieves a pointer to the actual number of elements retrieved. Can be <c>NULL</c> if celt == 1; otherwise it must not be <c>NULL</c>.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>
			/// Returns S_OK if successful, S_FALSE if there were not enough items left in the enumeration to be returned, or an error value otherwise.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-ienumsearchroots-next HRESULT Next( ULONG celt,
			// ISearchRoot **rgelt, ULONG *pceltFetched );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			HRESULT Next([In] uint celt, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISearchRoot[] rgelt, out uint pceltFetched);

			/// <summary>Skips the specified number of elements.</summary>
			/// <param name="celt">
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of elements to skip.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if successful, S_FALSE if there were not enough items left in the enumeration to skip, or an error value.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>IEnumSearchRoots::Skip</c> moves the internal counter forward a specified number of elements so that a subsequent call to
			/// IEnumSearchRoots::Next starts from that point.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-ienumsearchroots-skip HRESULT Skip( ULONG celt );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			HRESULT Skip([In] uint celt);

			/// <summary>
			/// Moves the internal counter to the beginning of the list so a subsequent call to IEnumSearchRoots::Next retrieves from the beginning.
			/// </summary>
			/// <remarks>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-ienumsearchroots-reset HRESULT Reset( );
			[PInvokeData("searchapi.h")]
			void Reset();

			/// <summary>Creates a copy of the IEnumSearchRoots object with the same contents and state as the current one.</summary>
			/// <returns>
			/// <para>Type: <c>IEnumSearchRoots**</c></para>
			/// <para>
			/// Returns a pointer to the new IEnumSearchRoots object. The calling application must free the new object by calling its
			/// IUnknown::Release method.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-ienumsearchroots-clone HRESULT Clone(
			// IEnumSearchRoots **ppenum );
			[PInvokeData("searchapi.h")]
			IEnumSearchRoots Clone();
		}

		/// <summary>Enumerates scope rules.</summary>
		/// <remarks>
		/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK, demonstrates
		/// how to define command line options for Crawl Scope Manager (CSM) indexing operations.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-ienumsearchscoperules
		[PInvokeData("searchapi.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("AB310581-AC80-11D1-8DF3-00C04FB6EF54")]
		public interface IEnumSearchScopeRules
		{
			/// <summary>Retrieves the specified number of ISearchScopeRule elements.</summary>
			/// <remarks>
			/// <para>
			/// Internally, this method updates a counter to move forward the number of elements actually retrieved; subsequent calls to
			/// <c>IEnumSearchScopeRules::Next</c> will start from that number.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-ienumsearchscoperules-next HRESULT Next( ULONG
			// celt, ISearchScopeRule **pprgelt, ULONG *pceltFetched );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			HRESULT Next([In] uint celt, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISearchScopeRule[] pprgelt, ref uint pceltFetched);

			/// <summary>Skips the specified number of elements.</summary>
			/// <remarks>
			/// <para>
			/// Moves the internal counter a specified number of elements forward so that a subsequent call to IEnumSearchScopeRules::Next
			/// starts from that number.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-ienumsearchscoperules-skip HRESULT Skip( ULONG
			// celt );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			HRESULT Skip([In] uint celt);

			/// <summary>
			/// Moves the internal counter to the beginning of the list so that a subsequent call to IEnumSearchScopeRules::Next retrieves
			/// from the beginning.
			/// </summary>
			/// <remarks>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-ienumsearchscoperules-reset HRESULT Reset( );
			[PInvokeData("searchapi.h")]
			void Reset();

			/// <summary>Creates a copy of this IEnumSearchScopeRules object with the same contents and state as the current one.</summary>
			/// <remarks>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-ienumsearchscoperules-clone HRESULT Clone(
			// IEnumSearchScopeRules **ppenum );
			[PInvokeData("searchapi.h")]
			IEnumSearchScopeRules Clone();
		}

		/// <summary>
		/// <para>
		/// [Indexing Service is no longer supported as of Windows XP and is unavailable for use as of Windows 8. Instead, use Windows Search
		/// for client side search and Microsoft Search Server Express for server side search.]
		/// </para>
		/// <para>
		/// Scans documents for text and properties (also called attributes). It extracts chunks of text from these documents, filtering out
		/// embedded formatting and retaining information about the position of the text. It also extracts chunks of values, which are
		/// properties of an entire document or of well-defined parts of a document. <c>IFilter</c> provides the foundation for building
		/// higher-level applications such as document indexers and application-independent viewers.
		/// </para>
		/// <para>
		/// For introductory information about how the <c>IFilter</c> interface works with documents and document properties, see Properties
		/// of Documents. For a synopsis and an example of how the <c>IFilter</c> interface processes a document, see Property Filtering and
		/// Property Indexing.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <c>IFilter</c> components for Indexing Service run in the Local Security context and should be written to manage buffers and to
		/// stack correctly. All string copies must have explicit checks to guard against buffer overruns. You should always verify the
		/// allocated size of the buffer and test the size of the data against the size of the buffer.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/filter/nn-filter-ifilter
		[PInvokeData("filter.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("89BCB740-6119-101A-BCB7-00DD010655AF")]
		public interface IFilter
		{
			/// <summary>
			/// <para>
			/// [Indexing Service is no longer supported as of Windows XP and is unavailable for use as of Windows 8. Instead, use Windows
			/// Search for client side search and Microsoft Search Server Express for server side search.]
			/// </para>
			/// <para>Initializes a filtering session.</para>
			/// </summary>
			/// <param name="grfFlags">
			/// Values from the IFILTER_INIT enumeration for controlling text standardization, property output, embedding scope, and IFilter
			/// access patterns.
			/// </param>
			/// <param name="cAttributes">
			/// The size of the attributes array. When nonzero, cAttributes takes precedence over attributes specified in grfFlags. If no
			/// attribute flags are specified and cAttributes is zero, the default is given by the PSGUID_STORAGE storage property set, which
			/// contains the date and time of the last write to the file, size, and so on; and by the PID_STG_CONTENTS 'contents' property,
			/// which maps to the main contents of the file. For more information about properties and property sets, see Property Sets.
			/// </param>
			/// <param name="aAttributes">
			/// Pointer to an array of FULLPROPSPEC structures for the requested properties. When cAttributes is nonzero, only the properties
			/// in aAttributes are returned.
			/// </param>
			/// <param name="pFlags">Information about additional properties available to the caller; from the IFILTER_FLAGS enumeration.</param>
			/// <returns>This method can return one of these values.</returns>
			/// <remarks>
			/// <para>
			/// The <c>Init</c> method sets the state of the filter object. The content filter positions at the beginning of the object and
			/// the object state is frozen until the object is released. You can pass the filter object the set of properties you would like
			/// returned by setting up their property set and property identifier (ID) descriptions in the aAttributes array. For more
			/// information, see Filtering File Properties.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>Call the <c>Init</c> method before calling all other IFilter methods.</para>
			/// <para>Notes to Implementers</para>
			/// <para>Chunk IDs must remain consistent across multiple calls to the <c>Init</c> method with the same parameters.</para>
			/// <para>
			/// For some implementations of the IFilter interface, detection of failure to access a document may not be possible (or may be
			/// computationally expensive) until the <c>Init</c> method has been called, or possibly even later.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/filter/nf-filter-ifilter-init SCODE Init( ULONG grfFlags, ULONG
			// cAttributes, const FULLPROPSPEC *aAttributes, ULONG *pFlags );
			[PInvokeData("filter.h")]
			[PreserveSig]
			HRESULT Init([In] IFILTER_INIT grfFlags, [In] uint cAttributes, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] FULLPROPSPEC[] aAttributes, out IFILTER_FLAGS pFlags);

			/// <summary>
			/// <para>
			/// [Indexing Service is no longer supported as of Windows XP and is unavailable for use as of Windows 8. Instead, use Windows
			/// Search for client side search and Microsoft Search Server Express for server side search.]
			/// </para>
			/// <para>
			/// Positions the filter at the beginning of the next chunk, or at the first chunk if this is the first call to the
			/// <c>GetChunk</c> method, and returns a description of the current chunk.
			/// </para>
			/// </summary>
			/// <param name="pStat">A pointer to a STAT_CHUNK structure containing a description of the current chunk.</param>
			/// <returns>This method can return one of these values.</returns>
			/// <remarks>
			/// <para>
			/// If upon return pStat points to a STAT_CHUNK structure with the <c>breakType</c> member equal to CHUNK_NO_BREAK, only the
			/// <c>idChunk</c> member will be updated with the new chunk identifier (ID) value. The other members of the <c>STAT_CHUNK</c>
			/// structure remain unchanged.
			/// </para>
			/// <para>
			/// Internal value-type properties (chunks with a CHUNKSTATE enumeration value of CHUNK_VALUE) cannot be concatenated using
			/// CHUNK_NO_BREAK. A single word cannot span more than two glued chunks.
			/// </para>
			/// <para>Chunk ID zero is invalid.</para>
			/// <para>
			/// Before the <c>GetChunk</c> method is called for the first time, there is no current chunk. After an error return code of
			/// anything other than FILTER_E_END_OF_CHUNKS the next call to the <c>GetChunk</c> method nevertheless retrieves the next chunk
			/// after the unavailable one.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// When the <c>GetChunk</c> method finishes, the chunk described in *pStat is the current chunk. The chunk descriptor is owned
			/// by the routine calling the <c>GetChunk</c> method, but the property name pointer, which can be set in the property
			/// specification, is owned by the <c>GetChunk</c> method and should not be freed.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// If a call to the <c>GetChunk</c> method of the content filter of a linked or embedded object returns FILTER_E_END_OF_CHUNKS,
			/// the implementation should return the next chunk of the linking or embedding object. For example, if a document has two
			/// embedded objects and the first has returned FILTER_E_END_OF_CHUNKS, then the outer content filter must call the
			/// <c>GetChunk</c> method of the content filter for the embedded object.
			/// </para>
			/// <para>
			/// Before returning the results of a call to the <c>GetChunk</c> method on an embedded or linked object, check to make sure that
			/// the chunk ID is unique. If not, the implementer must renumber the chunk and keep a mapping of the new chunk ID.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/filter/nf-filter-ifilter-getchunk SCODE GetChunk( STAT_CHUNK *pStat );
			[PInvokeData("filter.h")]
			[PreserveSig]
			HRESULT GetChunk(out STAT_CHUNK pStat);

			/// <summary>
			/// <para>
			/// [Indexing Service is no longer supported as of Windows XP and is unavailable for use as of Windows 8. Instead, use Windows
			/// Search for client side search and Microsoft Search Server Express for server side search.]
			/// </para>
			/// <para>Retrieves text (text-type properties) from the current chunk, which must have a CHUNKSTATE enumeration value of CHUNK_TEXT.</para>
			/// </summary>
			/// <param name="pcwcBuffer">
			/// On entry, the size of awcBuffer array in wide/Unicode characters. On exit, the number of Unicode characters written to awcBuffer.
			/// </param>
			/// <param name="awcBuffer">
			/// Text retrieved from the current chunk. Do not terminate the buffer with a character. Use a null-terminated string. The
			/// null-terminated string should not exceed the size of the destination buffer.
			/// </param>
			/// <returns>This method can return one of these values.</returns>
			/// <remarks>
			/// If the current chunk is too large for the awcBuffer array, more than one call to the <c>GetText</c> method can be required to
			/// retrieve all the text in the current chunk. Each call to the <c>GetText</c> method retrieves text that immediately follows
			/// the text from the last call to the <c>GetText</c> method. The last character from one call can be in the middle of a word,
			/// and the first character in the next call would continue that word. Search engines must handle this situation.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/filter/nf-filter-ifilter-gettext SCODE GetText( ULONG *pcwcBuffer, WCHAR
			// *awcBuffer );
			[PInvokeData("filter.h")]
			[PreserveSig]
			HRESULT GetText([In, Out] ref uint pcwcBuffer, [Out] StringBuilder awcBuffer);

			/// <summary>
			/// <para>
			/// [Indexing Service is no longer supported as of Windows XP and is unavailable for use as of Windows 8. Instead, use Windows
			/// Search for client side search and Microsoft Search Server Express for server side search.]
			/// </para>
			/// <para>Retrieves a value (internal value-type property) from a chunk, which must have a CHUNKSTATE enumeration value of CHUNK_VALUE.</para>
			/// </summary>
			/// <param name="ppPropValue">
			/// A pointer to an output variable that receives a pointer to the PROPVARIANT structure that contains the value-type property.
			/// </param>
			/// <returns>This method can return one of these values.</returns>
			/// <remarks>
			/// <para>Call the <c>GetValue</c> method only once per chunk.</para>
			/// <para>
			/// Note that the effect of producing the same value from more than one chunk is undefined. Only the last setting of the value is valid.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// Allocate the PROPVARIANT structure with CoTaskMemAlloc. Some <c>PROPVARIANT</c> structures contain pointers, which can be
			/// freed by calling the PropVariantClear function. It is up to the caller of the <c>GetValue</c> method to call <c>PropVariantClear</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/filter/nf-filter-ifilter-getvalue SCODE GetValue( PROPVARIANT
			// **ppPropValue );
			[PInvokeData("filter.h")]
			[PreserveSig]
			HRESULT GetValue(ref PROPVARIANT ppPropValue);

			/// <summary>
			/// <para>
			/// [Indexing Service is no longer supported as of Windows XP and is unavailable for use as of Windows 8. Instead, use Windows
			/// Search for client side search and Microsoft Search Server Express for server side search.]
			/// </para>
			/// <para>Retrieves an interface representing the specified portion of object. Currently reserved for future use.</para>
			/// </summary>
			/// <param name="origPos">A FILTERREGION structure that contains the position of the text.</param>
			/// <param name="riid">A reference to the requested interface identifier.</param>
			/// <param name="ppunk">
			/// A pointer to a variable that receives the interface pointer requested in riid. Upon successful return, *ppunk contains the
			/// requested interface pointer.
			/// </param>
			/// <returns>This method can return one of these values.</returns>
			/// <remarks>
			/// <para>
			/// If it is impossible for the <c>BindRegion</c> method to bind an interface to the specified region, return
			/// FILTER_W_REGION_CLIPPED. This situation can occur when the next such chunk is in a linked object or an embedded object.
			/// </para>
			/// <para>
			/// Not all filters are capable of supporting the <c>BindRegion</c> method in a rational way. Filters that are implemented by
			/// viewing applications will benefit the most from this method. The method is intended to be a way to pass cookies through the
			/// search engine and back to the IFilter interface implementation.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>This method is currently reserved for future use. Always return E_NOTIMPL.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/filter/nf-filter-ifilter-bindregion SCODE BindRegion( FILTERREGION
			// origPos, REFIID riid, void **ppunk );
			[PInvokeData("filter.h")]
			[PreserveSig]
			HRESULT BindRegion([In] FILTERREGION origPos, [In] in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppunk);
		}

		/// <summary>
		/// Defines methods and properties that are implemented by the FilterRegistration object, which provides methods for loading a filter.
		/// </summary>
		/// <remarks>A filter, also known as a filter handler, is an implementation of the IFilter interface.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/filtereg/nn-filtereg-iloadfilter
		[PInvokeData("filtereg.h", MSDNShortId = "7ac51909-fa0e-4f97-8da0-0ab4c5de7d60")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("c7310722-ac80-11d1-8df3-00c04fb6ef4f"), CoClass(typeof(FilterRegistration))]
		public interface ILoadFilter
		{
			/// <summary>Retrieves and loads the most appropriate filter that is mapped to a Shell data source.</summary>
			/// <param name="pwcsPath">
			/// Pointer to a comma-delimited null-terminated Unicode string buffer that specifies the path of the file to be filtered. This
			/// parameter can be null.
			/// </param>
			/// <param name="pFilteredSources">
			/// Pointer to the FILTERED_DATA_SOURCES structure that specifies parameters for a Shell data source for which a filter is
			/// loaded. This parameter cannot be null.
			/// </param>
			/// <param name="pUnkOuter">
			/// If the object is being created as part of an aggregate, specify a pointer to the controlling IUnknown interface of the aggregate.
			/// </param>
			/// <param name="fUseDefault">
			/// If <c>TRUE</c>, use the default filter; if <c>FALSE</c>, proceed with the most appropriate filter that is available.
			/// </param>
			/// <param name="pFilterClsid">
			/// Pointer to the CLSID (CLSID_FilterRegistration) that receives the class identifier of the returned filter.
			/// </param>
			/// <param name="SearchDecSize">Not implemented.</param>
			/// <param name="pwcsSearchDesc">Not implemented.</param>
			/// <param name="ppIFilt">The address of a pointer to an implementation of an IFilter interface that <c>LoadIFilter</c> selects.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			/// <remarks>
			/// <para>A filter, also known as a filter handler, is an implementation of the IFilter interface.</para>
			/// <para>
			/// <c>ILoadFilter</c> attempts to load a filter that can process a Shell data source of the type specified in the
			/// pFilteredSources parameter through the pwcsPath parameter.If an appropriate filter for the data source is not found, and
			/// fUseDefault is <c>false</c>, this method returns null in the ppIFilt parameter. If an appropriate filter for the data source
			/// is not found, and fUseDefault is <c>true</c>, the IFilter interface on the default <c>IFilter</c> is returned in the ppIFilt parameter.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/filtereg/nf-filtereg-iloadfilter-loadifilter HRESULT LoadIFilter( LPCWSTR
			// pwcsPath, FILTERED_DATA_SOURCES *pFilteredSources, IUnknown *pUnkOuter, BOOL fUseDefault, CLSID *pFilterClsid, int
			// *SearchDecSize, WCHAR **pwcsSearchDesc, IFilter **ppIFilt );
			[PInvokeData("filtereg.h", MSDNShortId = "920c976e-4dde-4e53-85b7-7547291736a0")]
			[PreserveSig]
			HRESULT LoadIFilter([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pwcsPath, in FILTERED_DATA_SOURCES pFilteredSources, [In, MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter,
				[In, MarshalAs(UnmanagedType.Bool)] bool fUseDefault, out Guid pFilterClsid, [Optional] IntPtr SearchDecSize, [Optional] IntPtr pwcsSearchDesc, out IFilter ppIFilt);

			/// <summary>
			/// <para>Not implemented.</para>
			/// <para>Do not use: this method is not implemented.</para>
			/// </summary>
			/// <param name="pStg"/>
			/// <param name="pUnkOuter"/>
			/// <param name="pwcsOverride"/>
			/// <param name="fUseDefault"/>
			/// <param name="pFilterClsid"/>
			/// <param name="SearchDecSize"/>
			/// <param name="pwcsSearchDesc"/>
			/// <param name="ppIFilt"/>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/filtereg/nf-filtereg-iloadfilter-loadifilterfromstorage HRESULT
			// LoadIFilterFromStorage( IStorage *pStg, IUnknown *pUnkOuter, LPCWSTR pwcsOverride, BOOL fUseDefault, CLSID *pFilterClsid, int
			// *SearchDecSize, WCHAR **pwcsSearchDesc, IFilter **ppIFilt );
			[PInvokeData("filtereg.h", MSDNShortId = "b4eff132-9022-4091-a2a3-1d8e11a35b39")]
			[Obsolete, PreserveSig]
			HRESULT LoadIFilterFromStorage([In] IStorage pStg, [In, MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter, [In, MarshalAs(UnmanagedType.LPWStr)] string pwcsOverride,
				[In, MarshalAs(UnmanagedType.Bool)] bool fUseDefault, out Guid pFilterClsid, [Optional] IntPtr SearchDecSize, [Optional] IntPtr pwcsSearchDesc, out IFilter ppIFilt);

			/// <summary>
			/// <para>Not implemented.</para>
			/// <para>Do not use: this method is not implemented.</para>
			/// </summary>
			/// <param name="pStm"/>
			/// <param name="pFilteredSources"/>
			/// <param name="pUnkOuter"/>
			/// <param name="fUseDefault"/>
			/// <param name="pFilterClsid"/>
			/// <param name="SearchDecSize"/>
			/// <param name="pwcsSearchDesc"/>
			/// <param name="ppIFilt"/>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/filtereg/nf-filtereg-iloadfilter-loadifilterfromstream HRESULT
			// LoadIFilterFromStream( IStream *pStm, FILTERED_DATA_SOURCES *pFilteredSources, IUnknown *pUnkOuter, BOOL fUseDefault, CLSID
			// *pFilterClsid, int *SearchDecSize, WCHAR **pwcsSearchDesc, IFilter **ppIFilt );
			[PInvokeData("filtereg.h", MSDNShortId = "6a577306-d5ff-43c1-ab9f-3a7437661d2a")]
			[Obsolete, PreserveSig]
			HRESULT LoadIFilterFromStream([In] IStream pStm, in FILTERED_DATA_SOURCES pFilteredSources, [In, MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter,
				[In, MarshalAs(UnmanagedType.Bool)] bool fUseDefault, out Guid pFilterClsid, [Optional] IntPtr SearchDecSize, [Optional] IntPtr pwcsSearchDesc, out IFilter ppIFilt);
		}

		/// <summary>
		/// <para>
		/// Provides methods to check the opportunistic lock that is used by Microsoft Windows Desktop Search (WDS) on items while indexing.
		/// If another process locks the file in an incompatible manner, WDS will lose its lock and allow the other process to have the file.
		/// This mechanism allows WDS to run in the background. Consequently, WDS needs to check its locks to ensure another process has not
		/// taken precedence while WDS indexes the item.
		/// </para>
		/// <para>
		/// A third-party IUrlAccessor object can implement this interface if the underlying data store provides a mechanism to track
		/// concurrent access to items. If this interface is exposed by <c>IUrlAccessor</c>, WDS will check the <c>IOpLockStatus</c> while
		/// indexing items from that store.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-ioplockstatus
		[PInvokeData("searchapi.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("c731065d-ac80-11d1-8df3-00c04fb6ef4f")]
		public interface IOpLockStatus
		{
			/// <summary>Checks the status of the opportunistic lock (OpLock) on the item being indexed.</summary>
			/// <returns>
			/// <para>Type: <c>BOOL*</c></para>
			/// <para>Receives a pointer to a <c>BOOL</c> value that indicates whether the OpLock is successfully taken.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// An OpLock is an opportunistic lock that allows the indexer to lock the item when another process is not accessing it. The
			/// indexer releases the item, invalidating or breaking the lock, when another process requests an incompatible access mode. This
			/// enables the indexer to run in the background and not impede access to these items by other processes.
			/// </para>
			/// <para>
			/// An OpLock is never taken after the underlying IUrlAccessor object is initialized, and any call to this method yields the same
			/// output value on the same object.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-ioplockstatus-isoplockvalid HRESULT IsOplockValid(
			// BOOL *pfIsOplockValid );
			[PInvokeData("searchapi.h")]
			[return: MarshalAs(UnmanagedType.Bool)]
			bool IsOplockValid();

			/// <summary>Checks the status of the opportunistic lock (OpLock) on the item being indexed.</summary>
			/// <returns>
			/// <para>Type: <c>BOOL*</c></para>
			/// <para>
			/// Receives a pointer to a <c>BOOL</c> value that indicates whether the OpLock is broken: <c>TRUE</c> if OpLock was taken and
			/// then broken, <c>FALSE</c> otherwise (including the case when OpLock was not taken).
			/// </para>
			/// </returns>
			/// <remarks>
			/// An OpLock is an opportunistic lock that allows the indexer to lock the item when another process isn't accessing it. The
			/// indexer releases the item, invalidating or breaking the lock, when another process requests an incompatible access mode. This
			/// enables the indexer to run in the background and not impede access to these items by other processes.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-ioplockstatus-isoplockbroken HRESULT
			// IsOplockBroken( BOOL *pfIsOplockBroken );
			[PInvokeData("searchapi.h")]
			[return: MarshalAs(UnmanagedType.Bool)]
			bool IsOplockBroken();

			/// <summary>
			/// Gets the event handle of the opportunistic lock (OpLock). The event object is set to the signaled state when the OpLock is
			/// broken, enabling the indexer to stop all operations on the underlying IUrlAccessor object.
			/// </summary>
			/// <returns>
			/// <para>Type: <c>HANDLE*</c></para>
			/// <para>Receives a pointer to the handle of the event associated with the OpLock, or <c>NULL</c> if no OpLock was taken.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-ioplockstatus-getoplockeventhandle HRESULT
			// GetOplockEventHandle( HANDLE *phOplockEv );
			[PInvokeData("searchapi.h")]
			HANDLE GetOplockEventHandle();
		}

		/// <summary>
		/// Provides methods for a protocol handler's IUrlAccessor object to query the Filter Daemon for the appropriate filter for the URL item.
		/// </summary>
		/// <remarks>
		/// When a protocol handler encounters items with embedded documents, the protocol handler requests additional filters from the
		/// Filter Daemon by calling the IProtocolHandlerSite::GetFilter method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-iprotocolhandlersite
		[PInvokeData("searchapi.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0b63e385-9ccc-11d0-bcdb-00805fccce04")]
		public interface IProtocolHandlerSite
		{
			/// <summary>Retrieves the appropriate IFilteraccording to the supplied parameters.</summary>
			/// <param name="pclsidObj">
			/// <para>Type: <c>CLSID*</c></para>
			/// <para>
			/// Pointer to the CLSID of the document type from the registry. This is used for items with embedded documents to indicate the
			/// appropriate IFilterto use for that embedded document.
			/// </para>
			/// </param>
			/// <param name="pcwszContentType">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// Pointer to a null-terminated Unicode string that contains the type of the document. This is used to retrieve IFilter <c>s</c>
			/// that are mapped according to MIME type.
			/// </para>
			/// </param>
			/// <param name="pcwszExtension">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// Pointer to a null-terminated Unicode string that contains the file name extension, without the preceding period. This is used
			/// to retrieve IFilterobjects that are mapped according to the file name extension.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>IFilter**</c></para>
			/// <para>Receives the address of a pointer to the IFilterthat the protocol handler uses.</para>
			/// </returns>
			/// <remarks>
			/// <para>This method queries the Filter Host to identify the appropriate IFilterobject to use for the URL item.</para>
			/// <para>
			/// The choice of filter is based on the file name extension, a CLSID that identifies the file's content type in the registry, or
			/// on the MIME content type. You need to provide only one of the three parameters to this method. If you provide multiple
			/// parameters, they are tested in the following order: pcwszContentType, pclsidObj, pcwszExtension. The first valid parameter is
			/// used to select the appropriate IFilter; the others are ignored.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iprotocolhandlersite-getfilter HRESULT GetFilter(
			// CLSID *pclsidObj, LPCWSTR pcwszContentType, LPCWSTR pcwszExtension, IFilter **ppFilter );
			[PInvokeData("searchapi.h")]
			IFilter GetFilter(in Guid pclsidObj, [In, MarshalAs(UnmanagedType.LPWStr)] string pcwszContentType, [In, MarshalAs(UnmanagedType.LPWStr)] string pcwszExtension);
		}

		/// <summary>
		/// Exposes methods for receiving event notifications. When clients implement this interface, the indexer can notify the clients of
		/// changes to items in their rowsets: including the addition of new items, the deletion of items, and the modifcation to item data.
		/// </summary>
		/// <remarks>
		/// <para>When to Implement</para>
		/// <para>
		/// Implement <c>IRowsetEvents</c> if your provider needs to receive notifications of rowset events. <c>IRowsetEvents</c> exposes
		/// methods for receiving event notifications, and must be implemented to receive the following notifications on events:
		/// OnChangedItem, OnDeletedItem, OnNewItem and OnRowsetEvent. The ROWSETEVENT_ITEMSTATE and ROWSETEVENT_TYPE enumeratiors capture
		/// the item state and rowset event, respectively.
		/// </para>
		/// <para>
		/// Indexer eventing is a new feature for Windows 7 that allows providers to receive notifications on their rowsets. Providers can
		/// use eventing to maintain their rowsets in such a way that they behave akin to actual file system locations.
		/// </para>
		/// <para>The <c>IRowsetEvents</c> interface is registered by connection point with an open indexer rowset.</para>
		/// <para>
		/// <c>DBPROP_ENABLEROWSETEVENTS</c> must be set to <c>TRUE</c> with the OLE DB ICommandProperties::SetProperties method prior to
		/// executing the query in order to use rowset eventing.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-irowsetevents
		[PInvokeData("searchapi.h")]
		[ComImport, Guid("1551AEA5-5D66-4B11-86F5-D5634CB211B9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IRowsetEvents
		{
			/// <summary>
			/// Called by the indexer to notify clients of a new item that may match some (or all) of the criteria for the client rowset.
			/// </summary>
			/// <param name="itemID">
			/// <para>Type: <c>REFPROPVARIANT</c></para>
			/// <para>The new item that may match the original search criteria of the rowset.</para>
			/// </param>
			/// <param name="newItemState">
			/// <para>Type: <c>ROWSETEVENT_ITEMSTATE</c></para>
			/// <para>Specifies whether the new item matches all or some of the criteria for your rowset, as a ROWSETEVENT_ITEMSTATE enumeration.</para>
			/// </param>
			/// <remarks>
			/// The ROWSETEVENT_ITEMSTATE indicates the degree to which the new item may match the original search criteria of a rowset:
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-irowsetevents-onnewitem HRESULT OnNewItem(
			// REFPROPVARIANT itemID, ROWSETEVENT_ITEMSTATE newItemState );
			[PInvokeData("searchapi.h")]
			void OnNewItem([In] PROPVARIANT itemID, [In] ROWSETEVENT_ITEMSTATE newItemState);

			/// <summary>
			/// Called by the indexer to notify clients that an item has been modified. This item may have matched some (or all) of the
			/// criteria for the client rowset.
			/// </summary>
			/// <param name="itemID">
			/// <para>Type: <c>REFPROPVARIANT</c></para>
			/// <para>Specifies the item in the rowset that has changed.</para>
			/// </param>
			/// <param name="rowsetItemState">
			/// <para>Type: <c>ROWSETEVENT_ITEMSTATE</c></para>
			/// <para>Specifies whether the changed item was originally in the rowset.</para>
			/// </param>
			/// <param name="changedItemState">
			/// <para>Type: <c>ROWSETEVENT_ITEMSTATE</c></para>
			/// <para>Specifies whether the changed item is currently in the rowset, as a result of the change.</para>
			/// </param>
			/// <remarks>
			/// <para>The ROWSETEVENT_ITEMSTATE for rowsetItemState indicates whether the item was contained in the original rowset:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>ROWSETEVENT_ITEMSTATE_INROWSET indicates that the item is definitely contained within your rowset.</term>
			/// </item>
			/// <item>
			/// <term>
			/// ROWSETEVENT_ITEMSTATE_UNKNOWN indicates that the item may be contained within your rowset. The containment status is not
			/// known because your rowset is not fully evaluated.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ROWSETEVENT_ITEMSTATE_NOTINROWSET indicates indicates that the item was not originally in your rowset</term>
			/// </item>
			/// </list>
			/// <para>
			/// The ROWSETEVENT_ITEMSTATE for changedItemState indicates whether the newly modified item now matches the degree to which the
			/// new item may match the original search criteria of a rowset:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>ROWSETEVENT_ITEMSTATE_INROWSET indicates that the item definitely belongs in your rowset.</term>
			/// </item>
			/// <item>
			/// <term>ROWSETEVENT_ITEMSTATE_UNKNOWN indicates that the item may now belong in your rowset.</term>
			/// </item>
			/// <item>
			/// <term>ROWSETEVENT_ITEMSTATE_NOTINROWSET indicates that the item does not belong in your rowset.</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-irowsetevents-onchangeditem HRESULT OnChangedItem(
			// REFPROPVARIANT itemID, ROWSETEVENT_ITEMSTATE rowsetItemState, ROWSETEVENT_ITEMSTATE changedItemState );
			[PInvokeData("searchapi.h")]
			void OnChangedItem([In] PROPVARIANT itemID, [In] ROWSETEVENT_ITEMSTATE rowsetItemState, [In] ROWSETEVENT_ITEMSTATE changedItemState);

			/// <summary>
			/// Called by the indexer to notify clients that an item has been deleted. This item may have matched some (or all) of the search
			/// criteria for the client rowset.
			/// </summary>
			/// <param name="itemID">
			/// <para>Type: <c>REFPROPVARIANT</c></para>
			/// <para>Specifies the item in the rowset that has been deleted.</para>
			/// </param>
			/// <param name="deletedItemState">
			/// <para>Type: <c>ROWSETEVENT_ITEMSTATE</c></para>
			/// <para>Specifies whether the deleted item is currently in the rowset, as a ROWSETEVENT_ITEMSTATE enumeration.</para>
			/// </param>
			/// <remarks>The ROWSETEVENT_ITEMSTATE indicates whether or not the item was contained in the original rowset:</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-irowsetevents-ondeleteditem HRESULT OnDeletedItem(
			// REFPROPVARIANT itemID, ROWSETEVENT_ITEMSTATE deletedItemState );
			[PInvokeData("searchapi.h")]
			void OnDeletedItem([In] PROPVARIANT itemID, [In] ROWSETEVENT_ITEMSTATE deletedItemState);

			/// <summary>Called by the indexer to notify clients of an event related to the client rowset.</summary>
			/// <param name="eventType">
			/// <para>Type: <c>ROWSETEVENT_TYPE</c></para>
			/// <para>The event triggering the notification as the ROWSETEVENT_TYPE enumeration.</para>
			/// </param>
			/// <param name="eventData">
			/// <para>Type: <c>REFPROPVARIANT</c></para>
			/// <para>The expected value of the event data for the event type.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-irowsetevents-onrowsetevent HRESULT OnRowsetEvent(
			// ROWSETEVENT_TYPE eventType, REFPROPVARIANT eventData );
			[PInvokeData("searchapi.h")]
			void OnRowsetEvent([In] ROWSETEVENT_TYPE eventType, [In] PROPVARIANT eventData);
		}

		/// <summary>Sets or retrieves the current indexer prioritization level for the scope specified by this query.</summary>
		/// <remarks>
		/// <para>
		/// This interface is acquired with IUnknown::QueryInterface Method on an indexer rowset. <c>DBPROP_ENABLEROWSETEVENTS</c> must be
		/// set to <c>TRUE</c> with the OLE DB ICommandProperties::SetProperties method prior to executing the query in order to use rowset prioritization.
		/// </para>
		/// <para>
		/// IRowsetPrioritization::SetScopePriority sets the prioritization for the scopes belonging to the query, and the interval the scope
		/// statistics event is raised when there are outstanding documents to be indexed within the query scopes. This event is raised if
		/// the priority level is set to default.
		/// </para>
		/// <para>
		/// IRowsetPrioritization::GetScopeStatistics can be used to get the number of indexed items in the scope, the number of outstanding
		/// documents to be added in the scope, and the number of documents that need to be re-indexed within this scope.
		/// </para>
		/// <para>
		/// The SearchEvents code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to prioritize indexing events.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-irowsetprioritization
		[PInvokeData("searchapi.h")]
		[ComImport, Guid("42811652-079D-481B-87A2-09A69ECC5F44"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IRowsetPrioritization
		{
			/// <summary>Sets the current indexer prioritization level for the scope specified by this query.</summary>
			/// <param name="priority">
			/// <para>Type: <c>PRIORITY_LEVEL</c></para>
			/// <para>Specifies the new indexer prioritization level to be set as the PRIORITY_LEVEL enumeration.</para>
			/// </param>
			/// <param name="scopeStatisticsEventFrequency">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// Specifies the occurrence interval of the scope statistics event when there are outstanding documents to be indexed within the
			/// query scopes.
			/// </para>
			/// </param>
			/// <remarks>
			/// The SearchEvents code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to prioritize indexing events.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-irowsetprioritization-setscopepriority HRESULT
			// SetScopePriority( PRIORITY_LEVEL priority, DWORD scopeStatisticsEventFrequency );
			[PInvokeData("searchapi.h")]
			void SetScopePriority([In] PRIORITY_LEVEL priority, [In] uint scopeStatisticsEventFrequency);

			/// <summary>Retrieves the current indexer prioritization level for the scope specified by this query.</summary>
			/// <param name="priority">
			/// <para>Type: <c>PRIORITY_LEVEL*</c></para>
			/// <para>The current indexer prioritization level as the PRIORITY_LEVEL enumeration.</para>
			/// </param>
			/// <param name="scopeStatisticsEventFrequency">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>
			/// The occurrence interval of the scope statistics event when there are outstanding documents to be indexed within the query scopes.
			/// </para>
			/// </param>
			/// <remarks>
			/// The SearchEvents code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to prioritize indexing events.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-irowsetprioritization-getscopepriority HRESULT
			// GetScopePriority( PRIORITY_LEVEL *priority, DWORD *scopeStatisticsEventFrequency );
			[PInvokeData("searchapi.h")]
			void GetScopePriority(out PRIORITY_LEVEL priority, out uint scopeStatisticsEventFrequency);

			/// <summary>Gets information describing the scope specified by this query.</summary>
			/// <param name="indexedDocumentCount">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>The total number of documents currently indexed in the scope.</para>
			/// </param>
			/// <param name="oustandingAddCount">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>The total number of documents yet to be indexed in the scope. These documents are not yet included in indexedDocumentCount.</para>
			/// </param>
			/// <param name="oustandingModifyCount">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>The total number of documents indexed in the scope that need to be re-indexed. These documents are included in indexedDocumentCount.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// Returns S_OK if successful, <c>HRESULT_FROM_WIN32(ERROR_PATH_NOT_FOUND)</c> if there are no indexed documents in the scope,
			/// or an error value otherwise.
			/// </para>
			/// <para>
			/// The <c>GetScopeStatistics</c> event can be used to get the number of indexed items in the scope, the number of outstanding
			/// docs to be added in the scope, and the number of docs that need to be re-indexed within this scope.
			/// </para>
			/// <para>
			/// The SearchEvents code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to prioritize indexing events.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-irowsetprioritization-getscopestatistics HRESULT
			// GetScopeStatistics( DWORD *indexedDocumentCount, DWORD *oustandingAddCount, DWORD *oustandingModifyCount );
			[PInvokeData("searchapi.h")]
			void GetScopeStatistics(out uint indexedDocumentCount, out uint oustandingAddCount, out uint oustandingModifyCount);
		}

		/// <summary>Provides methods to manage a search catalog for purposes such as re-indexing or setting timeouts.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-isearchcatalogmanager
		[PInvokeData("searchapi.h")]
		[ComImport, Guid("AB310581-AC80-11D1-8DF3-00C04FB6EF50"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISearchCatalogManager
		{
			/// <summary>Gets the name of the current catalog.</summary>
			/// <value>
			/// <para>Receives the name of the current catalog.</para>
			/// </value>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-get_name HRESULT get_Name(
			// LPWSTR *pszName );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010000)]
			string Name { [return: MarshalAs(UnmanagedType.LPWStr)]  get; }

			/// <summary>Not implemented.</summary>
			/// <param name="pszName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The name of the parameter to be retrieved.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>PROPVARIANT**</c></para>
			/// <para>Receives a pointer to the value of the parameter.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-getparameter HRESULT
			// GetParameter( LPCWSTR pszName, PROPVARIANT **ppValue );
			[PInvokeData("searchapi.h")]
			PROPVARIANT GetParameter([In, MarshalAs(UnmanagedType.LPWStr)] string pszName);

			/// <summary>Sets a name/value parameter for the catalog.</summary>
			/// <param name="pszName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The name of the parameter to change.</para>
			/// </param>
			/// <param name="pValue">
			/// <para>Type: <c>PROPVARIANT*</c></para>
			/// <para>A pointer to the new value for the parameter.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-setparameter HRESULT
			// SetParameter( LPCWSTR pszName, PROPVARIANT *pValue );
			[PInvokeData("searchapi.h")]
			void SetParameter([In, MarshalAs(UnmanagedType.LPWStr)] string pszName, [In] PROPVARIANT pValue);

			/// <summary>Gets the status of the catalog.</summary>
			/// <param name="pStatus">
			/// <para>Type: <c>CatalogStatus*</c></para>
			/// <para>
			/// Receives a pointer to a value from the CatalogStatus enumeration. If pStatus is CATALOG_STATUS_PAUSED, further information
			/// can be obtained from the pPausedReason parameter.
			/// </para>
			/// </param>
			/// <param name="pPausedReason">
			/// <para>Type: <c>CatalogPausedReason*</c></para>
			/// <para>
			/// Receives a pointer to a value from the CatalogPausedReason enumeration describing why the catalog is paused. If the catalog
			/// status is not CATALOG_STATUS_PAUSED, this parameter receives the value CATALOG_PAUSED_REASON_NONE.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-getcatalogstatus HRESULT
			// GetCatalogStatus( CatalogStatus *pStatus, CatalogPausedReason *pPausedReason );
			[PInvokeData("searchapi.h")]
			void GetCatalogStatus(out CatalogStatus pStatus, out CatalogPausedReason pPausedReason);

			/// <summary>Resets the underlying catalog by rebuilding the databases and performing a full indexing.</summary>
			/// <remarks>Resetting can take a very long time, during which little or no information is available to be searched.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-reset HRESULT Reset( );
			[PInvokeData("searchapi.h")]
			void Reset();

			/// <summary>Re-indexes all URLs in the catalog.</summary>
			/// <remarks>Old information remains in the catalog until replaced by new information during re-indexing.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-reindex HRESULT Reindex( );
			[PInvokeData("searchapi.h")]
			void Reindex();

			/// <summary>Reindexes all items that match the provided pattern. This method was not implemented prior to Windows 7.</summary>
			/// <param name="pszPattern">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// A pointer to the pattern to be matched for reindexing. The pattern can be a standard pattern such as or a pattern in the form
			/// of a URL such as .
			/// </para>
			/// </param>
			/// <remarks>This method is fully implemented for Windows 7.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-reindexmatchingurls HRESULT
			// ReindexMatchingURLs( LPCWSTR pszPattern );
			[PInvokeData("searchapi.h")]
			void ReindexMatchingURLs([In, MarshalAs(UnmanagedType.LPWStr)] string pszPattern);

			/// <summary>Re-indexes all URLs from a specified root.</summary>
			/// <param name="pszRootURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// Pointer to a null-terminated, Unicode buffer that contains the URL on which the search is rooted. This URL must be a search
			/// root previously registered with ISearchCrawlScopeManager::AddRoot.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para>The indexer begins an incremental crawl of all start pages under pszRootURL upon successful return of method.</para>
			/// <para>Old information remains in the catalog until replaced by new information during the re-indexing.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-reindexsearchroot HRESULT
			// ReindexSearchRoot( LPCWSTR pszRootURL );
			[PInvokeData("searchapi.h")]
			void ReindexSearchRoot([In, MarshalAs(UnmanagedType.LPWStr)] string pszRootURL);

			/// <summary>Gets or sets the connection time-out value in the TIMEOUT_INFO structure, in seconds.</summary>
			/// <value>
			/// <para>The number of seconds to wait for a connection response.</para>
			/// </value>
			/// <remarks>
			/// The indexer expects the first chunk of the document to be received within the connection time-out interval and any subsequent
			/// chunks to be received within the data time-out interval. These time-out values help prevent filters and protocol handlers
			/// from failing or causing performance issues.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-put_connecttimeout HRESULT
			// put_ConnectTimeout( DWORD dwConnectTimeout );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010008)]
			uint ConnectTimeout { get; [param: In]  set; }

			/// <summary>
			/// Sets the time-out value for data transactions between the indexer and the search filter host. This information is stored in
			/// the TIMEOUT_INFO structure and is measured in seconds.
			/// </summary>
			/// <value>
			/// <para>The number of seconds that the indexer will wait between chunks of data.</para>
			/// </value>
			/// <remarks>
			/// The indexer expects the first chunk of the document to be received within the connection time-out interval and any subsequent
			/// chunks to be received within the data time-out interval. These time-out values help prevent filters and protocol handlers
			/// from failing or causing performance issues.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-put_datatimeout HRESULT
			// put_DataTimeout( DWORD dwDataTimeout );
			[PInvokeData("searchapi.h")]
			[DispId(0x6001000a)]
			uint DataTimeout { get; [param: In]  set; }

			/// <summary>Gets the number of items in the catalog.</summary>
			/// <returns>
			/// <para>The number of items in the catalog.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-numberofitems HRESULT
			// NumberOfItems( LONG *plCount );
			[PInvokeData("searchapi.h")]
			int NumberOfItems();

			/// <summary>Gets the number of items to be indexed within the catalog.</summary>
			/// <param name="plIncrementalCount">
			/// <para>Type: <c>LONG*</c></para>
			/// <para>Receives a pointer to the number of items to be indexed in the next incremental index.</para>
			/// </param>
			/// <param name="plNotificationQueue">
			/// <para>Type: <c>LONG*</c></para>
			/// <para>Receives a pointer to the number of items in the notification queue.</para>
			/// </param>
			/// <param name="plHighPriorityQueue">
			/// <para>Type: <c>LONG*</c></para>
			/// <para>
			/// Receives a pointer to the number of items in the high-priority queue. Items in the plHighPriorityQueue are indexed first.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-numberofitemstoindex HRESULT
			// NumberOfItemsToIndex( LONG *plIncrementalCount, LONG *plNotificationQueue, LONG *plHighPriorityQueue );
			[PInvokeData("searchapi.h")]
			void NumberOfItemsToIndex(out int plIncrementalCount, out int plNotificationQueue, out int plHighPriorityQueue);

			/// <summary>Gets the URL that is currently being indexed. If no indexing is currently in process, pszUrl is set to <c>NULL</c>.</summary>
			/// <returns>
			/// <para>The URL that is currently being indexed.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-urlbeingindexed HRESULT
			// URLBeingIndexed( LPWSTR *pszUrl );
			[PInvokeData("searchapi.h")]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string URLBeingIndexed();

			/// <summary>Not implemented.</summary>
			/// <param name="pszUrl">The URL.</param>
			/// <returns>The state.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-geturlindexingstate HRESULT
			// GetURLIndexingState( LPCWSTR pszURL, DWORD *pdwState );
			[PInvokeData("searchapi.h")]
			[Obsolete]
			uint GetURLIndexingState([In, MarshalAs(UnmanagedType.LPWStr)] string pszUrl);

			/// <summary>
			/// Gets the change notification event sink interface for a client. This method is used by client applications and protocol
			/// handlers to notify the indexer of changes.
			/// </summary>
			/// <returns>
			/// <para>Receives the address of a pointer to a new ISearchPersistentItemsChangedSink interface for this catalog.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-getpersistentitemschangedsink
			// HRESULT GetPersistentItemsChangedSink( ISearchPersistentItemsChangedSink **ppISearchPersistentItemsChangedSink );
			[PInvokeData("searchapi.h")]
			ISearchPersistentItemsChangedSink GetPersistentItemsChangedSink();

			/// <summary>Not implemented.</summary>
			/// <param name="pszView">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to the name of the view.</para>
			/// </param>
			/// <param name="pViewChangedSink">
			/// <para>Type: <c>ISearchViewChangedSink*</c></para>
			/// <para>Pointer to the ISearchViewChangedSink object to receive notifications.</para>
			/// </param>
			/// <param name="pdwCookie">Type: <c>DWORD*</c></param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-registerviewfornotification
			// HRESULT RegisterViewForNotification( LPCWSTR pszView, ISearchViewChangedSink *pViewChangedSink, DWORD *pdwCookie );
			[PInvokeData("searchapi.h")]
			[Obsolete]
			void RegisterViewForNotification([In, MarshalAs(UnmanagedType.LPWStr)] string pszView, [In, MarshalAs(UnmanagedType.Interface)] ISearchViewChangedSink pViewChangedSink, out uint pdwCookie);

			/// <summary>Gets the change notification sink interface.</summary>
			/// <param name="pISearchNotifyInlineSite">
			/// <para>Type: <c>ISearchNotifyInlineSite*</c></para>
			/// <para>A pointer to your ISearchNotifyInlineSite interface.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>The UUID of the ISearchItemsChangedSink interface.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void*</c></para>
			/// <para>Receives a pointer to the ISearchItemsChangedSink interface.</para>
			/// </param>
			/// <param name="pGUIDCatalogResetSignature">
			/// <para>Type: <c>GUID*</c></para>
			/// <para>Receives a pointer to the GUID representing the catalog reset. If this GUID changes, all notifications must be resent.</para>
			/// </param>
			/// <param name="pGUIDCheckPointSignature">
			/// <para>Type: <c>GUID*</c></para>
			/// <para>Receives a pointer to the GUID representing a checkpoint.</para>
			/// </param>
			/// <param name="pdwLastCheckPointNumber">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number indicating the last checkpoint to be saved.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-getitemschangedsink HRESULT
			// GetItemsChangedSink( ISearchNotifyInlineSite *pISearchNotifyInlineSite, REFIID riid, void **ppv, GUID
			// *pGUIDCatalogResetSignature, GUID *pGUIDCheckPointSignature, DWORD *pdwLastCheckPointNumber );
			[PInvokeData("searchapi.h")]
			void GetItemsChangedSink([In, MarshalAs(UnmanagedType.Interface)] ISearchNotifyInlineSite pISearchNotifyInlineSite, [In] in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppv, out Guid pGUIDCatalogResetSignature, out Guid pGUIDCheckPointSignature, out uint pdwLastCheckPointNumber);

			/// <summary>Not implemented.</summary>
			/// <param name="dwCookie">Type: <c>DWORD</c></param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-unregisterviewfornotification
			// HRESULT UnregisterViewForNotification( DWORD dwCookie );
			[PInvokeData("searchapi.h")]
			[Obsolete]
			void UnregisterViewForNotification([In] uint dwCookie);

			/// <summary>Not implemented.</summary>
			/// <param name="pszExtension">Type: <c>LPCWSTR</c></param>
			/// <param name="fExclude">Type: <c>BOOL</c></param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-setextensionclusion HRESULT
			// SetExtensionClusion( LPCWSTR pszExtension, BOOL fExclude );
			[PInvokeData("searchapi.h")]
			[Obsolete]
			void SetExtensionClusion([In, MarshalAs(UnmanagedType.LPWStr)] string pszExtension, [MarshalAs(UnmanagedType.Bool)] bool fExclude);

			/// <summary>Not implemented.</summary>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-enumerateexcludedextensions
			[PInvokeData("searchapi.h")]
			[Obsolete]
			IEnumString EnumerateExcludedExtensions();

			/// <summary>Gets the ISearchQueryHelper interface for the current catalog.</summary>
			/// <returns>
			/// <para>Type: <c>ISearchQueryHelper**</c></para>
			/// <para>Receives the address of a pointer to a new instance of the ISearchQueryHelper interface with default settings.</para>
			/// </returns>
			/// <remarks>
			/// After the ISearchQueryHelper interface is created, use the put... methods for this interface to change settings. Settings for
			/// the <c>ISearchQueryHelper</c> object are relevant only until the settings are changed again or the item is released. When the
			/// item is next created, settings are set to default values.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-getqueryhelper HRESULT
			// GetQueryHelper( ISearchQueryHelper **ppSearchQueryHelper );
			[PInvokeData("searchapi.h")]
			ISearchQueryHelper GetQueryHelper();

			/// <summary>
			/// Gets or sets a value that determines whether the catalog is sensitive to diacritics. A diacritic is a mark added to a letter
			/// to indicate a special phonetic value or pronunciation.
			/// </summary>
			/// <value>
			/// <para>
			/// A Boolean value that determines whether the catalog is sensitive to diacritics. <c>TRUE</c> if the catalog is sensitive to
			/// and recognizes diacritics; otherwise, <c>FALSE</c>.
			/// </para>
			/// </value>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-put_diacriticsensitivity
			// HRESULT put_DiacriticSensitivity( BOOL fDiacriticSensitive );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010017)]
			int DiacriticSensitivity { get; [param: In]  set; }

			/// <summary>Gets an ISearchCrawlScopeManager interface for this search catalog.</summary>
			/// <returns>
			/// <para>Receives a pointer to a new ISearchCrawlScopeManager interface.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-getcrawlscopemanager HRESULT
			// GetCrawlScopeManager( ISearchCrawlScopeManager **ppCrawlScopeManager );
			[PInvokeData("searchapi.h")]
			ISearchCrawlScopeManager GetCrawlScopeManager();
		}

		/// <summary>
		/// Extends the ISearchCatalogManager interface to manage a search catalog, for purposes such as re-indexing or setting timeouts.
		/// Applications can use this interface to attempt to reindex items that failed to be indexed previously, using the PrioritizeMatchingURLs.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-isearchcatalogmanager2
		[PInvokeData("searchapi.h")]
		[ComImport, Guid("7AC3286D-4D1D-4817-84FC-C1C85E3AF0D9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISearchCatalogManager2 : ISearchCatalogManager
		{
			/// <summary>Gets the name of the current catalog.</summary>
			/// <value>
			/// <para>Receives the name of the current catalog.</para>
			/// </value>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-get_name HRESULT get_Name(
			// LPWSTR *pszName );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010000)]
			new string Name { [return: MarshalAs(UnmanagedType.LPWStr)]  get; }

			/// <summary>Not implemented.</summary>
			/// <param name="pszName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The name of the parameter to be retrieved.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>PROPVARIANT**</c></para>
			/// <para>Receives a pointer to the value of the parameter.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-getparameter HRESULT
			// GetParameter( LPCWSTR pszName, PROPVARIANT **ppValue );
			[PInvokeData("searchapi.h")]
			new PROPVARIANT GetParameter([In, MarshalAs(UnmanagedType.LPWStr)] string pszName);

			/// <summary>Sets a name/value parameter for the catalog.</summary>
			/// <param name="pszName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The name of the parameter to change.</para>
			/// </param>
			/// <param name="pValue">
			/// <para>Type: <c>PROPVARIANT*</c></para>
			/// <para>A pointer to the new value for the parameter.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-setparameter HRESULT
			// SetParameter( LPCWSTR pszName, PROPVARIANT *pValue );
			[PInvokeData("searchapi.h")]
			new void SetParameter([In, MarshalAs(UnmanagedType.LPWStr)] string pszName, [In] PROPVARIANT pValue);

			/// <summary>Gets the status of the catalog.</summary>
			/// <param name="pStatus">
			/// <para>Type: <c>CatalogStatus*</c></para>
			/// <para>
			/// Receives a pointer to a value from the CatalogStatus enumeration. If pStatus is CATALOG_STATUS_PAUSED, further information
			/// can be obtained from the pPausedReason parameter.
			/// </para>
			/// </param>
			/// <param name="pPausedReason">
			/// <para>Type: <c>CatalogPausedReason*</c></para>
			/// <para>
			/// Receives a pointer to a value from the CatalogPausedReason enumeration describing why the catalog is paused. If the catalog
			/// status is not CATALOG_STATUS_PAUSED, this parameter receives the value CATALOG_PAUSED_REASON_NONE.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-getcatalogstatus HRESULT
			// GetCatalogStatus( CatalogStatus *pStatus, CatalogPausedReason *pPausedReason );
			[PInvokeData("searchapi.h")]
			new void GetCatalogStatus(out CatalogStatus pStatus, out CatalogPausedReason pPausedReason);

			/// <summary>Resets the underlying catalog by rebuilding the databases and performing a full indexing.</summary>
			/// <remarks>Resetting can take a very long time, during which little or no information is available to be searched.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-reset HRESULT Reset( );
			[PInvokeData("searchapi.h")]
			new void Reset();

			/// <summary>Re-indexes all URLs in the catalog.</summary>
			/// <remarks>Old information remains in the catalog until replaced by new information during re-indexing.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-reindex HRESULT Reindex( );
			[PInvokeData("searchapi.h")]
			new void Reindex();

			/// <summary>Reindexes all items that match the provided pattern. This method was not implemented prior to Windows 7.</summary>
			/// <param name="pszPattern">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// A pointer to the pattern to be matched for reindexing. The pattern can be a standard pattern such as or a pattern in the form
			/// of a URL such as .
			/// </para>
			/// </param>
			/// <remarks>This method is fully implemented for Windows 7.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-reindexmatchingurls HRESULT
			// ReindexMatchingURLs( LPCWSTR pszPattern );
			[PInvokeData("searchapi.h")]
			new void ReindexMatchingURLs([In, MarshalAs(UnmanagedType.LPWStr)] string pszPattern);

			/// <summary>Re-indexes all URLs from a specified root.</summary>
			/// <param name="pszRootURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// Pointer to a null-terminated, Unicode buffer that contains the URL on which the search is rooted. This URL must be a search
			/// root previously registered with ISearchCrawlScopeManager::AddRoot.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para>The indexer begins an incremental crawl of all start pages under pszRootURL upon successful return of method.</para>
			/// <para>Old information remains in the catalog until replaced by new information during the re-indexing.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-reindexsearchroot HRESULT
			// ReindexSearchRoot( LPCWSTR pszRootURL );
			[PInvokeData("searchapi.h")]
			new void ReindexSearchRoot([In, MarshalAs(UnmanagedType.LPWStr)] string pszRootURL);

			/// <summary>Gets or sets the connection time-out value in the TIMEOUT_INFO structure, in seconds.</summary>
			/// <value>
			/// <para>The number of seconds to wait for a connection response.</para>
			/// </value>
			/// <remarks>
			/// The indexer expects the first chunk of the document to be received within the connection time-out interval and any subsequent
			/// chunks to be received within the data time-out interval. These time-out values help prevent filters and protocol handlers
			/// from failing or causing performance issues.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-put_connecttimeout HRESULT
			// put_ConnectTimeout( DWORD dwConnectTimeout );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010008)]
			new uint ConnectTimeout { get; [param: In]  set; }

			/// <summary>
			/// Sets the time-out value for data transactions between the indexer and the search filter host. This information is stored in
			/// the TIMEOUT_INFO structure and is measured in seconds.
			/// </summary>
			/// <value>
			/// <para>The number of seconds that the indexer will wait between chunks of data.</para>
			/// </value>
			/// <remarks>
			/// The indexer expects the first chunk of the document to be received within the connection time-out interval and any subsequent
			/// chunks to be received within the data time-out interval. These time-out values help prevent filters and protocol handlers
			/// from failing or causing performance issues.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-put_datatimeout HRESULT
			// put_DataTimeout( DWORD dwDataTimeout );
			[PInvokeData("searchapi.h")]
			[DispId(0x6001000a)]
			new uint DataTimeout { get; [param: In]  set; }

			/// <summary>Gets the number of items in the catalog.</summary>
			/// <returns>
			/// <para>The number of items in the catalog.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-numberofitems HRESULT
			// NumberOfItems( LONG *plCount );
			[PInvokeData("searchapi.h")]
			new int NumberOfItems();

			/// <summary>Gets the number of items to be indexed within the catalog.</summary>
			/// <param name="plIncrementalCount">
			/// <para>Type: <c>LONG*</c></para>
			/// <para>Receives a pointer to the number of items to be indexed in the next incremental index.</para>
			/// </param>
			/// <param name="plNotificationQueue">
			/// <para>Type: <c>LONG*</c></para>
			/// <para>Receives a pointer to the number of items in the notification queue.</para>
			/// </param>
			/// <param name="plHighPriorityQueue">
			/// <para>Type: <c>LONG*</c></para>
			/// <para>
			/// Receives a pointer to the number of items in the high-priority queue. Items in the plHighPriorityQueue are indexed first.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-numberofitemstoindex HRESULT
			// NumberOfItemsToIndex( LONG *plIncrementalCount, LONG *plNotificationQueue, LONG *plHighPriorityQueue );
			[PInvokeData("searchapi.h")]
			new void NumberOfItemsToIndex(out int plIncrementalCount, out int plNotificationQueue, out int plHighPriorityQueue);

			/// <summary>Gets the URL that is currently being indexed. If no indexing is currently in process, pszUrl is set to <c>NULL</c>.</summary>
			/// <returns>
			/// <para>The URL that is currently being indexed.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-urlbeingindexed HRESULT
			// URLBeingIndexed( LPWSTR *pszUrl );
			[PInvokeData("searchapi.h")]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string URLBeingIndexed();

			/// <summary>Not implemented.</summary>
			/// <param name="pszUrl">The URL.</param>
			/// <returns>The state.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-geturlindexingstate HRESULT
			// GetURLIndexingState( LPCWSTR pszURL, DWORD *pdwState );
			[PInvokeData("searchapi.h")]
			[Obsolete]
			new uint GetURLIndexingState([In, MarshalAs(UnmanagedType.LPWStr)] string pszUrl);

			/// <summary>
			/// Gets the change notification event sink interface for a client. This method is used by client applications and protocol
			/// handlers to notify the indexer of changes.
			/// </summary>
			/// <returns>
			/// <para>Receives the address of a pointer to a new ISearchPersistentItemsChangedSink interface for this catalog.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-getpersistentitemschangedsink
			// HRESULT GetPersistentItemsChangedSink( ISearchPersistentItemsChangedSink **ppISearchPersistentItemsChangedSink );
			[PInvokeData("searchapi.h")]
			new ISearchPersistentItemsChangedSink GetPersistentItemsChangedSink();

			/// <summary>Not implemented.</summary>
			/// <param name="pszView">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to the name of the view.</para>
			/// </param>
			/// <param name="pViewChangedSink">
			/// <para>Type: <c>ISearchViewChangedSink*</c></para>
			/// <para>Pointer to the ISearchViewChangedSink object to receive notifications.</para>
			/// </param>
			/// <param name="pdwCookie">Type: <c>DWORD*</c></param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-registerviewfornotification
			// HRESULT RegisterViewForNotification( LPCWSTR pszView, ISearchViewChangedSink *pViewChangedSink, DWORD *pdwCookie );
			[PInvokeData("searchapi.h")]
			[Obsolete]
			new void RegisterViewForNotification([In, MarshalAs(UnmanagedType.LPWStr)] string pszView, [In, MarshalAs(UnmanagedType.Interface)] ISearchViewChangedSink pViewChangedSink, out uint pdwCookie);

			/// <summary>Gets the change notification sink interface.</summary>
			/// <param name="pISearchNotifyInlineSite">
			/// <para>Type: <c>ISearchNotifyInlineSite*</c></para>
			/// <para>A pointer to your ISearchNotifyInlineSite interface.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>The UUID of the ISearchItemsChangedSink interface.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void*</c></para>
			/// <para>Receives a pointer to the ISearchItemsChangedSink interface.</para>
			/// </param>
			/// <param name="pGUIDCatalogResetSignature">
			/// <para>Type: <c>GUID*</c></para>
			/// <para>Receives a pointer to the GUID representing the catalog reset. If this GUID changes, all notifications must be resent.</para>
			/// </param>
			/// <param name="pGUIDCheckPointSignature">
			/// <para>Type: <c>GUID*</c></para>
			/// <para>Receives a pointer to the GUID representing a checkpoint.</para>
			/// </param>
			/// <param name="pdwLastCheckPointNumber">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number indicating the last checkpoint to be saved.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-getitemschangedsink HRESULT
			// GetItemsChangedSink( ISearchNotifyInlineSite *pISearchNotifyInlineSite, REFIID riid, void **ppv, GUID
			// *pGUIDCatalogResetSignature, GUID *pGUIDCheckPointSignature, DWORD *pdwLastCheckPointNumber );
			[PInvokeData("searchapi.h")]
			new void GetItemsChangedSink([In, MarshalAs(UnmanagedType.Interface)] ISearchNotifyInlineSite pISearchNotifyInlineSite, [In] in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppv, out Guid pGUIDCatalogResetSignature, out Guid pGUIDCheckPointSignature, out uint pdwLastCheckPointNumber);

			/// <summary>Not implemented.</summary>
			/// <param name="dwCookie">Type: <c>DWORD</c></param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-unregisterviewfornotification
			// HRESULT UnregisterViewForNotification( DWORD dwCookie );
			[PInvokeData("searchapi.h")]
			[Obsolete]
			new void UnregisterViewForNotification([In] uint dwCookie);

			/// <summary>Not implemented.</summary>
			/// <param name="pszExtension">Type: <c>LPCWSTR</c></param>
			/// <param name="fExclude">Type: <c>BOOL</c></param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-setextensionclusion HRESULT
			// SetExtensionClusion( LPCWSTR pszExtension, BOOL fExclude );
			[PInvokeData("searchapi.h")]
			[Obsolete]
			new void SetExtensionClusion([In, MarshalAs(UnmanagedType.LPWStr)] string pszExtension, [MarshalAs(UnmanagedType.Bool)] bool fExclude);

			/// <summary>Not implemented.</summary>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-enumerateexcludedextensions
			[PInvokeData("searchapi.h")]
			[Obsolete]
			new IEnumString EnumerateExcludedExtensions();

			/// <summary>Gets the ISearchQueryHelper interface for the current catalog.</summary>
			/// <returns>
			/// <para>Type: <c>ISearchQueryHelper**</c></para>
			/// <para>Receives the address of a pointer to a new instance of the ISearchQueryHelper interface with default settings.</para>
			/// </returns>
			/// <remarks>
			/// After the ISearchQueryHelper interface is created, use the put... methods for this interface to change settings. Settings for
			/// the <c>ISearchQueryHelper</c> object are relevant only until the settings are changed again or the item is released. When the
			/// item is next created, settings are set to default values.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-getqueryhelper HRESULT
			// GetQueryHelper( ISearchQueryHelper **ppSearchQueryHelper );
			[PInvokeData("searchapi.h")]
			new ISearchQueryHelper GetQueryHelper();

			/// <summary>
			/// Gets or sets a value that determines whether the catalog is sensitive to diacritics. A diacritic is a mark added to a letter
			/// to indicate a special phonetic value or pronunciation.
			/// </summary>
			/// <value>
			/// <para>
			/// A Boolean value that determines whether the catalog is sensitive to diacritics. <c>TRUE</c> if the catalog is sensitive to
			/// and recognizes diacritics; otherwise, <c>FALSE</c>.
			/// </para>
			/// </value>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-put_diacriticsensitivity
			// HRESULT put_DiacriticSensitivity( BOOL fDiacriticSensitive );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010017)]
			new int DiacriticSensitivity { get; [param: In]  set; }

			/// <summary>Gets an ISearchCrawlScopeManager interface for this search catalog.</summary>
			/// <returns>
			/// <para>Receives a pointer to a new ISearchCrawlScopeManager interface.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager-getcrawlscopemanager HRESULT
			// GetCrawlScopeManager( ISearchCrawlScopeManager **ppCrawlScopeManager );
			[PInvokeData("searchapi.h")]
			new ISearchCrawlScopeManager GetCrawlScopeManager();

			/// <summary>
			/// Instructs the indexer to give a higher priority to indexing items that have URLs that match a specified pattern. These items
			/// will then have a higher priority than other indexing tasks.
			/// </summary>
			/// <param name="pszPattern">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A string specifying the URL pattern that defines items that failed indexing and need re-indexing.</para>
			/// </param>
			/// <param name="dwPrioritizeFlags">
			/// <para>Type: <c>PRIORITIZE_FLAGS</c></para>
			/// <para>A value from the PRIORITIZE_FLAGS enumeration that specifies how to process items that the indexer has failed to index.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// The pszPattern string must specify a pattern than matches the entire item URL. You can use the asterisk wildcard character to
			/// create your pattern string.
			/// </para>
			/// <para>
			/// The PRIORITIZE_FLAG_IGNOREFAILURECOUNT flag is valid only in combination with the PRIORITIZE_FLAG_RETRYFAILEDITEMS flag.
			/// </para>
			/// <para>Examples</para>
			/// <para>The following examples show the use of the asterisk wildcard character and of the PRIORITIZE_FLAG_IGNOREFAILURECOUNT.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcatalogmanager2-prioritizematchingurls
			// HRESULT PrioritizeMatchingURLs( LPCWSTR pszPattern, PRIORITIZE_FLAGS dwPrioritizeFlags );
			[PInvokeData("searchapi.h")]
			void PrioritizeMatchingURLs([In, MarshalAs(UnmanagedType.LPWStr)] string pszPattern, [In] PRIORITIZE_FLAGS dwPrioritizeFlags);
		}

		/// <summary>
		/// Provides methods that notify the search engine of containers to crawl and/or watch, and items under those containers to include
		/// or exclude when crawling or watching.
		/// </summary>
		/// <remarks>
		/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK, demonstrates
		/// how to define command line options for Crawl Scope Manager (CSM) indexing operations.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-isearchcrawlscopemanager
		[PInvokeData("searchapi.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("AB310581-AC80-11D1-8DF3-00C04FB6EF55")]
		public interface ISearchCrawlScopeManager
		{
			/// <summary>Adds a URL as the default scope for this rule.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Pointer to a null-terminated, Unicode buffer that contains the URL to use as a default scope.</para>
			/// </param>
			/// <param name="fInclude">
			/// <para>Type: <c>BOOL</c></para>
			/// <para><c>TRUE</c> if pszUrl should be included in indexing; <c>FALSE</c> if it should be excluded.</para>
			/// </param>
			/// <param name="fFollowFlags">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Sets the FOLLOW_FLAGS to specify whether to follow complex URLs and whether a URL is to be indexed or just followed.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// Default scope rules provide an initial set of scope rules. User scope rules always take precedence over default scope rules,
			/// unless user-defined rules are reverted in which case the default scope rules are reinstated.
			/// </para>
			/// <para>
			/// URLs passed in as parameters to <c>ISearchCrawlScopeManager::AddDefaultScopeRule</c> are expected to be fully URL-decoded and
			/// without URL control codes. For example, file:c:\My Documents is fully URL-decoded, whereas file:c:\My%20Documents is not.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-adddefaultscoperule
			// HRESULT AddDefaultScopeRule( LPCWSTR pszURL, BOOL fInclude, DWORD fFollowFlags );
			[PInvokeData("searchapi.h")]
			void AddDefaultScopeRule([MarshalAs(UnmanagedType.LPWStr)] string pszURL, [MarshalAs(UnmanagedType.Bool)] bool fInclude, FOLLOW_FLAGS fFollowFlags);

			/// <summary>Adds a new search root to the search engine.</summary>
			/// <param name="pSearchRoot">
			/// <para>Type: <c>ISearchRoot*</c></para>
			/// <para>An ISearchRoot describing the new search root to add.</para>
			/// </param>
			/// <remarks>
			/// <para>Overrides any existing root definition for the URL.</para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-addroot HRESULT AddRoot(
			// ISearchRoot *pSearchRoot );
			[PInvokeData("searchapi.h")]
			void AddRoot([In] ISearchRoot pSearchRoot);

			/// <summary>Removes a search root from the search engine.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The URL of a search root to be removed.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if successful; S_FALSE if the root is not found.</para>
			/// </returns>
			/// <remarks>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-removeroot HRESULT
			// RemoveRoot( LPCWSTR pszURL );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			HRESULT RemoveRoot([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL);

			/// <summary>Returns an enumeration of all the roots of which this instance of the ISearchCrawlScopeManager is aware.</summary>
			/// <remarks>
			/// <para>ppSearchRoots is set to <c>NULL</c> if there are no roots to enumerate.</para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-enumerateroots HRESULT
			// EnumerateRoots( IEnumSearchRoots **ppSearchRoots );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			HRESULT EnumerateRoots(out IEnumSearchRoots ppSearchRoots);

			/// <summary>Adds a hierarchical scope to the search engine.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The URL of the scope to be added.</para>
			/// </param>
			/// <param name="fInclude">
			/// <para>Type: <c>BOOL</c></para>
			/// <para><c>TRUE</c> if this is an inclusion scope, <c>FALSE</c> if this is an exclusion scope.</para>
			/// </param>
			/// <param name="fDefault">
			/// <para>Type: <c>BOOL</c></para>
			/// <para><c>TRUE</c> if this is to be the default scope, <c>FALSE</c> if this is not a default scope.</para>
			/// </param>
			/// <param name="fOverrideChildren">
			/// <para>Type: <c>BOOL</c></para>
			/// <para><c>TRUE</c> if this scope overrides all of the child URL rules, <c>FALSE</c> otherwise.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// This method overrides existing scope rules for the URL.The preferred methods for such functionality are
			/// ISearchCrawlScopeManager::AddDefaultScopeRule and ISearchCrawlScopeManager::AddUserScopeRule.
			/// </para>
			/// <para>
			/// URLs passed in as parameters to <c>ISearchCrawlScopeManager::AddHierarchicalScope</c> are expected to be fully URL-decoded
			/// and without URL control codes. For example, file:c:\My Documents is fully URL-decoded, whereas file:c:\My%20Documents is not.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-addhierarchicalscope
			// HRESULT AddHierarchicalScope( LPCWSTR pszURL, BOOL fInclude, BOOL fDefault, BOOL fOverrideChildren );
			[PInvokeData("searchapi.h")]
			void AddHierarchicalScope([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL, [MarshalAs(UnmanagedType.Bool)] bool fInclude,
				[MarshalAs(UnmanagedType.Bool)] bool fDefault, [MarshalAs(UnmanagedType.Bool)] bool fOverrideChildren);

			/// <summary>Adds a new crawl scope rule when the user creates a new rule or adds a URL to be indexed.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The URL to be indexed.</para>
			/// </param>
			/// <param name="fInclude">
			/// <para>Type: <c>BOOL</c></para>
			/// <para><c>TRUE</c> if this should be included in all pszUrl searches; otherwise, <c>FALSE</c>.</para>
			/// </param>
			/// <param name="fOverrideChildren">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// A <c>BOOL</c> value specifying whether child rules should be overridden. If set to <c>TRUE</c>, this essentially removes all
			/// child rules.
			/// </para>
			/// </param>
			/// <param name="fFollowFlags">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Sets the FOLLOW_FLAGS to specify whether to follow complex URLs and whether a URL is to be indexed or just followed.</para>
			/// </param>
			/// <remarks>
			/// <para>A scope rule can be a fully qualified URL or a rule with a pattern.</para>
			/// <para><c>ISearchCrawlScopeManager::AddUserScopeRule</c> overrides any existing scope rule for the URL or pattern.</para>
			/// <para>
			/// URLs passed in as parameters to <c>ISearchCrawlScopeManager::AddUserScopeRule</c> are expected to be fully URL-decoded and
			/// without URL control codes. For example, file:c:\My Documents is fully URL-decoded, whereas file:c:\My%20Documents is not.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-adduserscoperule HRESULT
			// AddUserScopeRule( LPCWSTR pszURL, BOOL fInclude, BOOL fOverrideChildren, DWORD fFollowFlags );
			[PInvokeData("searchapi.h")]
			void AddUserScopeRule([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL, [MarshalAs(UnmanagedType.Bool)] bool fInclude,
				[MarshalAs(UnmanagedType.Bool)] bool fOverrideChildren, FOLLOW_FLAGS fFollowFlags);

			/// <summary>Removes a scope rule from the search engine.</summary>
			/// <param name="pszRule">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The URL or pattern of a scope rule to be removed.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if successful; returns S_FALSE if the scope rule is not found.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// URLs passed in as parameters to <c>ISearchCrawlScopeManager::RemoveScopeRule</c> are expected to be fully URL-decoded and
			/// without URL control codes. For example, file:///c:\My Documents is fully URL-decoded, whereas file:///c:\My%20Documents is not.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-removescoperule HRESULT
			// RemoveScopeRule( LPCWSTR pszRule );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			HRESULT RemoveScopeRule([In, MarshalAs(UnmanagedType.LPWStr)] string pszRule);

			/// <summary>
			/// Returns an enumeration of all the scope rules of which this instance of the ISearchCrawlScopeManager interface is aware.
			/// </summary>
			/// <param name="ppSearchScopeRules">Returns a pointer to an IEnumSearchScopeRules interface.</param>
			/// <returns>Returns S_OK if successful, S_FALSE if there are no rules to enumerate, or an error value otherwise.</returns>
			/// <remarks>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-enumeratescoperules
			// HRESULT EnumerateScopeRules( IEnumSearchScopeRules **ppSearchScopeRules );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			HRESULT EnumerateScopeRules(out IEnumSearchScopeRules ppSearchScopeRules);

			/// <summary>Identifies whether a given URL has a parent rule in scope.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// A string containing the URL to check for a parent rule. The string can contain wildcard characters, such as asterisks (*).
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>BOOL*</c></para>
			/// <para><c>TRUE</c> if pszURL has a parent rule; otherwise, <c>FALSE</c>.</para>
			/// </returns>
			/// <remarks>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-hasparentscoperule
			// HRESULT HasParentScopeRule( LPCWSTR pszURL, BOOL *pfHasParentRule );
			[PInvokeData("searchapi.h")]
			[return: MarshalAs(UnmanagedType.Bool)]
			bool HasParentScopeRule([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL);

			/// <summary>Identifies whether a given URL has a child rule in scope.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// A string containing the URL to check for a child rule. The string can contain wildcard characters, such as asterisks (*).
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>BOOL*</c></para>
			/// <para><c>TRUE</c> if pszURL has a child rule; otherwise, <c>FALSE</c>.</para>
			/// </returns>
			/// <remarks>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-haschildscoperule HRESULT
			// HasChildScopeRule( LPCWSTR pszURL, BOOL *pfHasChildRule );
			[PInvokeData("searchapi.h")]
			[return: MarshalAs(UnmanagedType.Bool)]
			bool HasChildScopeRule([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL);

			/// <summary>Retrieves an indicator of whether the specified URL is included in the crawl scope.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A string containing the URL to check for inclusion in the crawl scope.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>BOOL*</c></para>
			/// <para>A pointer to a <c>BOOL</c> value: <c>TRUE</c> if pszURL is included in the crawl scope; otherwise, <c>FALSE</c>.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// For hierarchical sources, the most immediate parent is included. For non-hierarchical sources like URLs, this will be only
			/// the URL rule itself. Other URLs that might be indexed will cause this method to retrieve <c>FALSE</c> because there is no way
			/// to tell whether they are in the scope.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-includedincrawlscope
			// HRESULT IncludedInCrawlScope( LPCWSTR pszURL, BOOL *pfIsIncluded );
			[PInvokeData("searchapi.h")]
			[return: MarshalAs(UnmanagedType.Bool)]
			bool IncludedInCrawlScope([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL);

			/// <summary>Retrieves an indicator of whether and why the specified URL is included in the crawl scope.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A string value indicating the URL to check for inclusion in the crawl scope.</para>
			/// </param>
			/// <param name="pfIsIncluded">
			/// <para>Type: <c>BOOL*</c></para>
			/// <para>A pointer to a <c>BOOL</c> value: <c>TRUE</c> if pszURL is included in the crawl scope; otherwise, <c>FALSE</c>.</para>
			/// </param>
			/// <param name="pReason">
			/// <para>Type: <c>CLUSION_REASON*</c></para>
			/// <para>
			/// Retrieves a pointer to a value from the CLUSION_REASON enumeration that indicates the reason that the specified URL was
			/// included in or excluded from the crawl scope.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para>
			/// For hierarchical sources, the most immediate parent is included. For non-hierarchical sources like URLs, this will be only
			/// the URL rule itself. Other URLs that might be indexed will cause this method to retrieve <c>FALSE</c> because there is no way
			/// to tell whether they are in the scope.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-includedincrawlscopeex
			// HRESULT IncludedInCrawlScopeEx( LPCWSTR pszURL, BOOL *pfIsIncluded, CLUSION_REASON *pReason );
			[PInvokeData("searchapi.h")]
			void ISearchCrawlScopeManager([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL, [MarshalAs(UnmanagedType.Bool)] out bool pfIsIncluded, out CLUSION_REASON pReason);

			/// <summary>Reverts to the default scopes.</summary>
			/// <remarks>
			/// <para>This method removes all user-defined rules and reverts the working set of crawls scope rules to the default rules.</para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-reverttodefaultscopes
			// HRESULT RevertToDefaultScopes( );
			[PInvokeData("searchapi.h")]
			void RevertToDefaultScopes();

			/// <summary>Commits all changes to the search engine.</summary>
			/// <remarks>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-saveall HRESULT SaveAll( );
			[PInvokeData("searchapi.h")]
			void SaveAll();

			/// <summary>Gets the version ID of the parent inclusion URL.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A string containing the current URL.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>LONG*</c></para>
			/// <para>On return, contains a pointer to the version ID of the parent inclusion URL for <c>pszUrl</c>.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Use this method to determine whether the indexer is aware of a change in a data store or scope (for example, a data store is
			/// removed and then re-added to the index), potentially requiring a new push of the hierarchical parent of the store's URL.
			/// </para>
			/// <para>
			/// This ID can change if a scope rule is removed and then added again. This method returns <c>S_FALSE</c> if no parent inclusion
			/// URL was found.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-getparentscopeversionid
			// HRESULT GetParentScopeVersionId( LPCWSTR pszURL, LONG *plScopeId );
			[PInvokeData("searchapi.h")]
			int GetParentScopeVersionId([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL);

			/// <summary>Removes a default scope rule from the search engine.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A string identifying the URL or pattern of the default rule to be removed.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// URLs passed in as parameters to <c>ISearchCrawlScopeManager::RemoveDefaultScopeRule</c> are expected to be fully URL-decoded
			/// and without URL control codes. For example, file:c:\My Documents is fully URL-decoded, whereas file:c:\My%20Documents is not.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-removedefaultscoperule
			// HRESULT RemoveDefaultScopeRule( LPCWSTR pszURL );
			[PInvokeData("searchapi.h")]
			void RemoveDefaultScopeRule([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL);
		}

		/// <summary>
		/// Extends the ISearchCatalogManager interface to manage a search catalog, for purposes such as re-indexing or setting timeouts.
		/// Applications can use this interface to attempt to reindex items that failed to be indexed previously, using the PrioritizeMatchingURLs.
		/// </summary>
		/// <seealso cref="ISearchCrawlScopeManager"/>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("6292F7AD-4E19-4717-A534-8FC22BCD5CCD")]
		public interface ISearchCrawlScopeManager2 : ISearchCrawlScopeManager
		{
			/// <summary>Adds a URL as the default scope for this rule.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Pointer to a null-terminated, Unicode buffer that contains the URL to use as a default scope.</para>
			/// </param>
			/// <param name="fInclude">
			/// <para>Type: <c>BOOL</c></para>
			/// <para><c>TRUE</c> if pszUrl should be included in indexing; <c>FALSE</c> if it should be excluded.</para>
			/// </param>
			/// <param name="fFollowFlags">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Sets the FOLLOW_FLAGS to specify whether to follow complex URLs and whether a URL is to be indexed or just followed.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// Default scope rules provide an initial set of scope rules. User scope rules always take precedence over default scope rules,
			/// unless user-defined rules are reverted in which case the default scope rules are reinstated.
			/// </para>
			/// <para>
			/// URLs passed in as parameters to <c>ISearchCrawlScopeManager::AddDefaultScopeRule</c> are expected to be fully URL-decoded and
			/// without URL control codes. For example, file:c:\My Documents is fully URL-decoded, whereas file:c:\My%20Documents is not.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-adddefaultscoperule
			// HRESULT AddDefaultScopeRule( LPCWSTR pszURL, BOOL fInclude, DWORD fFollowFlags );
			[PInvokeData("searchapi.h")]
			new void AddDefaultScopeRule([MarshalAs(UnmanagedType.LPWStr)] string pszURL, [MarshalAs(UnmanagedType.Bool)] bool fInclude, FOLLOW_FLAGS fFollowFlags);

			/// <summary>Adds a new search root to the search engine.</summary>
			/// <param name="pSearchRoot">
			/// <para>Type: <c>ISearchRoot*</c></para>
			/// <para>An ISearchRoot describing the new search root to add.</para>
			/// </param>
			/// <remarks>
			/// <para>Overrides any existing root definition for the URL.</para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-addroot HRESULT AddRoot(
			// ISearchRoot *pSearchRoot );
			[PInvokeData("searchapi.h")]
			new void AddRoot([In] ISearchRoot pSearchRoot);

			/// <summary>Removes a search root from the search engine.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The URL of a search root to be removed.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if successful; S_FALSE if the root is not found.</para>
			/// </returns>
			/// <remarks>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-removeroot HRESULT
			// RemoveRoot( LPCWSTR pszURL );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			new HRESULT RemoveRoot([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL);

			/// <summary>Returns an enumeration of all the roots of which this instance of the ISearchCrawlScopeManager is aware.</summary>
			/// <remarks>
			/// <para>ppSearchRoots is set to <c>NULL</c> if there are no roots to enumerate.</para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-enumerateroots HRESULT
			// EnumerateRoots( IEnumSearchRoots **ppSearchRoots );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			new HRESULT EnumerateRoots(out IEnumSearchRoots ppSearchRoots);

			/// <summary>Adds a hierarchical scope to the search engine.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The URL of the scope to be added.</para>
			/// </param>
			/// <param name="fInclude">
			/// <para>Type: <c>BOOL</c></para>
			/// <para><c>TRUE</c> if this is an inclusion scope, <c>FALSE</c> if this is an exclusion scope.</para>
			/// </param>
			/// <param name="fDefault">
			/// <para>Type: <c>BOOL</c></para>
			/// <para><c>TRUE</c> if this is to be the default scope, <c>FALSE</c> if this is not a default scope.</para>
			/// </param>
			/// <param name="fOverrideChildren">
			/// <para>Type: <c>BOOL</c></para>
			/// <para><c>TRUE</c> if this scope overrides all of the child URL rules, <c>FALSE</c> otherwise.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// This method overrides existing scope rules for the URL.The preferred methods for such functionality are
			/// ISearchCrawlScopeManager::AddDefaultScopeRule and ISearchCrawlScopeManager::AddUserScopeRule.
			/// </para>
			/// <para>
			/// URLs passed in as parameters to <c>ISearchCrawlScopeManager::AddHierarchicalScope</c> are expected to be fully URL-decoded
			/// and without URL control codes. For example, file:c:\My Documents is fully URL-decoded, whereas file:c:\My%20Documents is not.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-addhierarchicalscope
			// HRESULT AddHierarchicalScope( LPCWSTR pszURL, BOOL fInclude, BOOL fDefault, BOOL fOverrideChildren );
			[PInvokeData("searchapi.h")]
			new void AddHierarchicalScope([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL, [MarshalAs(UnmanagedType.Bool)] bool fInclude,
				[MarshalAs(UnmanagedType.Bool)] bool fDefault, [MarshalAs(UnmanagedType.Bool)] bool fOverrideChildren);

			/// <summary>Adds a new crawl scope rule when the user creates a new rule or adds a URL to be indexed.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The URL to be indexed.</para>
			/// </param>
			/// <param name="fInclude">
			/// <para>Type: <c>BOOL</c></para>
			/// <para><c>TRUE</c> if this should be included in all pszUrl searches; otherwise, <c>FALSE</c>.</para>
			/// </param>
			/// <param name="fOverrideChildren">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// A <c>BOOL</c> value specifying whether child rules should be overridden. If set to <c>TRUE</c>, this essentially removes all
			/// child rules.
			/// </para>
			/// </param>
			/// <param name="fFollowFlags">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Sets the FOLLOW_FLAGS to specify whether to follow complex URLs and whether a URL is to be indexed or just followed.</para>
			/// </param>
			/// <remarks>
			/// <para>A scope rule can be a fully qualified URL or a rule with a pattern.</para>
			/// <para><c>ISearchCrawlScopeManager::AddUserScopeRule</c> overrides any existing scope rule for the URL or pattern.</para>
			/// <para>
			/// URLs passed in as parameters to <c>ISearchCrawlScopeManager::AddUserScopeRule</c> are expected to be fully URL-decoded and
			/// without URL control codes. For example, file:c:\My Documents is fully URL-decoded, whereas file:c:\My%20Documents is not.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-adduserscoperule HRESULT
			// AddUserScopeRule( LPCWSTR pszURL, BOOL fInclude, BOOL fOverrideChildren, DWORD fFollowFlags );
			[PInvokeData("searchapi.h")]
			new void AddUserScopeRule([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL, [MarshalAs(UnmanagedType.Bool)] bool fInclude,
				[MarshalAs(UnmanagedType.Bool)] bool fOverrideChildren, FOLLOW_FLAGS fFollowFlags);

			/// <summary>Removes a scope rule from the search engine.</summary>
			/// <param name="pszRule">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The URL or pattern of a scope rule to be removed.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if successful; returns S_FALSE if the scope rule is not found.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// URLs passed in as parameters to <c>ISearchCrawlScopeManager::RemoveScopeRule</c> are expected to be fully URL-decoded and
			/// without URL control codes. For example, file:///c:\My Documents is fully URL-decoded, whereas file:///c:\My%20Documents is not.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-removescoperule HRESULT
			// RemoveScopeRule( LPCWSTR pszRule );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			new HRESULT RemoveScopeRule([In, MarshalAs(UnmanagedType.LPWStr)] string pszRule);

			/// <summary>
			/// Returns an enumeration of all the scope rules of which this instance of the ISearchCrawlScopeManager interface is aware.
			/// </summary>
			/// <param name="ppSearchScopeRules">Returns a pointer to an IEnumSearchScopeRules interface.</param>
			/// <returns>Returns S_OK if successful, S_FALSE if there are no rules to enumerate, or an error value otherwise.</returns>
			/// <remarks>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-enumeratescoperules
			// HRESULT EnumerateScopeRules( IEnumSearchScopeRules **ppSearchScopeRules );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			new HRESULT EnumerateScopeRules(out IEnumSearchScopeRules ppSearchScopeRules);

			/// <summary>Identifies whether a given URL has a parent rule in scope.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// A string containing the URL to check for a parent rule. The string can contain wildcard characters, such as asterisks (*).
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>BOOL*</c></para>
			/// <para><c>TRUE</c> if pszURL has a parent rule; otherwise, <c>FALSE</c>.</para>
			/// </returns>
			/// <remarks>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-hasparentscoperule
			// HRESULT HasParentScopeRule( LPCWSTR pszURL, BOOL *pfHasParentRule );
			[PInvokeData("searchapi.h")]
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool HasParentScopeRule([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL);

			/// <summary>Identifies whether a given URL has a child rule in scope.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// A string containing the URL to check for a child rule. The string can contain wildcard characters, such as asterisks (*).
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>BOOL*</c></para>
			/// <para><c>TRUE</c> if pszURL has a child rule; otherwise, <c>FALSE</c>.</para>
			/// </returns>
			/// <remarks>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-haschildscoperule HRESULT
			// HasChildScopeRule( LPCWSTR pszURL, BOOL *pfHasChildRule );
			[PInvokeData("searchapi.h")]
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool HasChildScopeRule([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL);

			/// <summary>Retrieves an indicator of whether the specified URL is included in the crawl scope.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A string containing the URL to check for inclusion in the crawl scope.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>BOOL*</c></para>
			/// <para>A pointer to a <c>BOOL</c> value: <c>TRUE</c> if pszURL is included in the crawl scope; otherwise, <c>FALSE</c>.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// For hierarchical sources, the most immediate parent is included. For non-hierarchical sources like URLs, this will be only
			/// the URL rule itself. Other URLs that might be indexed will cause this method to retrieve <c>FALSE</c> because there is no way
			/// to tell whether they are in the scope.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-includedincrawlscope
			// HRESULT IncludedInCrawlScope( LPCWSTR pszURL, BOOL *pfIsIncluded );
			[PInvokeData("searchapi.h")]
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool IncludedInCrawlScope([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL);

			/// <summary>Retrieves an indicator of whether and why the specified URL is included in the crawl scope.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A string value indicating the URL to check for inclusion in the crawl scope.</para>
			/// </param>
			/// <param name="pfIsIncluded">
			/// <para>Type: <c>BOOL*</c></para>
			/// <para>A pointer to a <c>BOOL</c> value: <c>TRUE</c> if pszURL is included in the crawl scope; otherwise, <c>FALSE</c>.</para>
			/// </param>
			/// <param name="pReason">
			/// <para>Type: <c>CLUSION_REASON*</c></para>
			/// <para>
			/// Retrieves a pointer to a value from the CLUSION_REASON enumeration that indicates the reason that the specified URL was
			/// included in or excluded from the crawl scope.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para>
			/// For hierarchical sources, the most immediate parent is included. For non-hierarchical sources like URLs, this will be only
			/// the URL rule itself. Other URLs that might be indexed will cause this method to retrieve <c>FALSE</c> because there is no way
			/// to tell whether they are in the scope.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-includedincrawlscopeex
			// HRESULT IncludedInCrawlScopeEx( LPCWSTR pszURL, BOOL *pfIsIncluded, CLUSION_REASON *pReason );
			[PInvokeData("searchapi.h")]
			new void ISearchCrawlScopeManager([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL, [MarshalAs(UnmanagedType.Bool)] out bool pfIsIncluded, out CLUSION_REASON pReason);

			/// <summary>Reverts to the default scopes.</summary>
			/// <remarks>
			/// <para>This method removes all user-defined rules and reverts the working set of crawls scope rules to the default rules.</para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-reverttodefaultscopes
			// HRESULT RevertToDefaultScopes( );
			[PInvokeData("searchapi.h")]
			new void RevertToDefaultScopes();

			/// <summary>Commits all changes to the search engine.</summary>
			/// <remarks>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-saveall HRESULT SaveAll( );
			[PInvokeData("searchapi.h")]
			new void SaveAll();

			/// <summary>Gets the version ID of the parent inclusion URL.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A string containing the current URL.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>LONG*</c></para>
			/// <para>On return, contains a pointer to the version ID of the parent inclusion URL for <c>pszUrl</c>.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Use this method to determine whether the indexer is aware of a change in a data store or scope (for example, a data store is
			/// removed and then re-added to the index), potentially requiring a new push of the hierarchical parent of the store's URL.
			/// </para>
			/// <para>
			/// This ID can change if a scope rule is removed and then added again. This method returns <c>S_FALSE</c> if no parent inclusion
			/// URL was found.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-getparentscopeversionid
			// HRESULT GetParentScopeVersionId( LPCWSTR pszURL, LONG *plScopeId );
			[PInvokeData("searchapi.h")]
			new int GetParentScopeVersionId([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL);

			/// <summary>Removes a default scope rule from the search engine.</summary>
			/// <param name="pszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A string identifying the URL or pattern of the default rule to be removed.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// URLs passed in as parameters to <c>ISearchCrawlScopeManager::RemoveDefaultScopeRule</c> are expected to be fully URL-decoded
			/// and without URL control codes. For example, file:c:\My Documents is fully URL-decoded, whereas file:c:\My%20Documents is not.
			/// </para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager-removedefaultscoperule
			// HRESULT RemoveDefaultScopeRule( LPCWSTR pszURL );
			[PInvokeData("searchapi.h")]
			new void RemoveDefaultScopeRule([In, MarshalAs(UnmanagedType.LPWStr)] string pszURL);

			/// <summary>
			/// Causes file mapping to be mapped into the address space of the calling process, and informs clients if the state of the Crawl
			/// Scope Manager (CSM) has changed.
			/// </summary>
			/// <param name="plVersion">
			/// <para>Type: <c>LONG**</c></para>
			/// <para>Receives a pointer to the address of a memory mapped file that contains the crawl scope version.</para>
			/// </param>
			/// <param name="phFileMapping">
			/// <para>Type: <c>HANDLE*</c></para>
			/// <para>
			/// Receives a pointer to the handle of the file mapping object, with read-only access, that was used to create the memory mapped
			/// file that contains the crawl scope version.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para>
			/// The version number that is retrieved is always current, and changes as the state of the CSM, such as whether additions or
			/// removals were made to the crawl scope, for example. Hence, <c>ISearchCrawlScopeManager2::GetVersion</c> needs to be called
			/// only once, because the current version always remains available through the retrieved pointer.
			/// </para>
			/// <para>
			/// <c>ISearchCrawlScopeManager2::GetVersion</c> does not result in a cross-process call. If the method succeeds, then the client
			/// must perform the following actions to destroy all file views in its address space, and then close the file mapping object's
			/// handle and the file on disk:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>Call <c>UnmapViewOfFile</c> using the pointer of the memory-mapped file provided by plVersion</term>
			/// </item>
			/// <item>
			/// <term>Call <c>CloseHandle</c> using the handle of the file mapping object</term>
			/// </item>
			/// </list>
			/// <para>The client must perform these steps when finished using the memory mapped file, to prevent memory leaks.</para>
			/// <para>
			/// The CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to define command
			/// line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchcrawlscopemanager2-getversion HRESULT
			// GetVersion( long **plVersion, HANDLE *phFileMapping );
			[PInvokeData("searchapi.h")]
			void GetVersion(out int plVersion, out HFILE phFileMapping);
		}

		/// <summary>
		/// Provides notifications for changes to indexed items. Also provides notification of the hierarchical scope that is being monitored
		/// for changed items.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-isearchitemschangedsink
		[PInvokeData("searchapi.h")]
		[ComImport, Guid("AB310581-AC80-11D1-8DF3-00C04FB6EF58"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISearchItemsChangedSink
		{
			/// <summary>Permits an index-managed notification source to add itself to a list of "monitored scopes".</summary>
			/// <param name="pszUrl">The PSZ URL.</param>
			/// <remarks>
			/// When a notification agent comes online it calls StartedMonitoringScope which adds the scope to the list of sources. If the
			/// source is new (removed previously by StoppedMonitoringScope, or never created in the first place) the indexer starts an
			/// incremental crawl of the corresponding document store. This is designed to pick up any changes in the store that occurred
			/// while the notification agent was offline.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchitemschangedsink-startedmonitoringscope
			// HRESULT StartedMonitoringScope( LPCWSTR pszURL );
			[PInvokeData("searchapi.h")]
			void StartedMonitoringScope([In, MarshalAs(UnmanagedType.LPWStr)] string pszUrl);

			/// <summary>Not implemented.</summary>
			/// <param name="pszUrl">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The pointer to a null-terminated, Unicode string containing the start address for the scope of monitoring.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchitemschangedsink-stoppedmonitoringscope
			// HRESULT StoppedMonitoringScope( LPCWSTR pszURL );
			[PInvokeData("searchapi.h")]
			[Obsolete]
			void StoppedMonitoringScope([In, MarshalAs(UnmanagedType.LPWStr)] string pszUrl);

			/// <summary>Call this method to notify an indexer to re-index some changed items.</summary>
			/// <param name="dwNumberOfChanges">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of items that have changed.</para>
			/// </param>
			/// <param name="rgDataChangeEntries">
			/// <para>Type: <c>SEARCH_ITEM_CHANGE[]</c></para>
			/// <para>An array of SEARCH_ITEM_CHANGE structures, describing the type of changes to and the paths or URLs of each item.</para>
			/// </param>
			/// <param name="rgdwDocIds">
			/// <para>Type: <c>DWORD[]</c></para>
			/// <para>Receives a pointer to an array of document identifiers for the items that changed.</para>
			/// </param>
			/// <param name="rghrCompletionCodes">
			/// <para>Type: <c>HRESULT[]</c></para>
			/// <para>Receives a pointer to an array of completion codes for rgdwDocIds indicating whether each item was accepted for indexing.</para>
			/// </param>
			/// <remarks>
			/// When there are multiple change notifications, the <c>priority</c> member of the SEARCH_ITEM_CHANGE structure indicates the
			/// priority of processing.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchitemschangedsink-onitemschanged HRESULT
			// OnItemsChanged( DWORD dwNumberOfChanges, SEARCH_ITEM_CHANGE [] rgDataChangeEntries, DWORD [] rgdwDocIds, HRESULT []
			// rghrCompletionCodes );
			[PInvokeData("searchapi.h")]
			void OnItemsChanged(uint dwNumberOfChanges, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SEARCH_ITEM_CHANGE[] rgDataChangeEntries, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] rgdwDocIds, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] HRESULT[] rghrCompletionCodes);
		}

		/// <summary>Provides methods for accessing thesaurus information.</summary>
		/// <remarks>
		/// A thesaurus file contains a word and a list of words to substitute when querying. It is specific to a catalog and can be defined
		/// in more than one file.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-isearchlanguagesupport
		[PInvokeData("searchapi.h")]
		[ComImport, Guid("24C3CBAA-EBC1-491a-9EF1-9F6D8DEB1B8F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISearchLanguageSupport
		{
			/// <summary>
			/// Sets a value that indicates whether an implemented ISearchLanguageSupport interface is sensitive to diacritics. A diacritic
			/// is an accent mark added to a letter to indicate a special phonetic value or pronunciation.
			/// </summary>
			/// <param name="fDiacriticSensitive">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// A Boolean value that indicates whether the interface is sensitive to diacritics. The default setting is <c>FALSE</c>,
			/// indicating that the interface ignores diacritical characters.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchlanguagesupport-setdiacriticsensitivity
			// HRESULT SetDiacriticSensitivity( BOOL fDiacriticSensitive );
			[PInvokeData("searchapi.h")]
			void SetDiacriticSensitivity([MarshalAs(UnmanagedType.Bool)] bool fDiacriticSensitive);

			/// <summary>
			/// Gets the sensitivity of an implemented ISearchLanguageSupport interface to diacritics. A diacritic is an accent mark added to
			/// a letter to indicate a special phonetic value or pronunciation.
			/// </summary>
			/// <returns>
			/// <para>Type: <c>BOOL*</c></para>
			/// <para>
			/// On return, contains a pointer to the sensitivity setting. <c>FALSE</c> indicates that the interface ignores diacritics;
			/// <c>TRUE</c> indicates the interface recognizes diacritics.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchlanguagesupport-getdiacriticsensitivity
			// HRESULT GetDiacriticSensitivity( BOOL *pfDiacriticSensitive );
			[PInvokeData("searchapi.h")]
			[return: MarshalAs(UnmanagedType.Bool)]
			bool GetDiacriticSensitivity();

			/// <summary>Retrieves an interface to the word breaker registered for the specified language code identifier (LCID).</summary>
			/// <param name="lcid">
			/// <para>Type: <c>LCID</c></para>
			/// <para>The LCID requested.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>IID of the interface to be queried.</para>
			/// </param>
			/// <param name="ppWordBreaker">
			/// <para>Type: <c>void**</c></para>
			/// <para>On return, contains the address of a pointer to the interface of the LCID contained in pLcidUsed.</para>
			/// </param>
			/// <param name="pLcidUsed">
			/// <para>Type: <c>LCID*</c></para>
			/// <para>On return, contains a pointer to the actual LCID used.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchlanguagesupport-loadwordbreaker HRESULT
			// LoadWordBreaker( LCID lcid, REFIID riid, void **ppWordBreaker, LCID *pLcidUsed );
			[PInvokeData("searchapi.h")]
			void LoadWordBreaker(uint lcid, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppWordBreaker, out uint pLcidUsed);

			/// <summary>Retrieves an interface to the word stemmer registered for the specified language code identifier (LCID).</summary>
			/// <param name="lcid">
			/// <para>Type: <c>LCID</c></para>
			/// <para>The LCID requested.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>IID of the interface to be queried.</para>
			/// </param>
			/// <param name="ppStemmer">
			/// <para>Type: <c>void**</c></para>
			/// <para>On return, contains the address of a pointer to the interface of the LCID contained in pLcidUsed.</para>
			/// </param>
			/// <param name="pLcidUsed">
			/// <para>Type: <c>LCID*</c></para>
			/// <para>On return, contains a pointer to the actual LCID used.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchlanguagesupport-loadstemmer HRESULT
			// LoadStemmer( LCID lcid, REFIID riid, void **ppStemmer, LCID *pLcidUsed );
			[PInvokeData("searchapi.h")]
			void LoadStemmer(uint lcid, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppStemmer, out uint pLcidUsed);

			/// <summary>
			/// Determines whether the query token is a prefix of the document token, disregarding case, width, and (optionally) diacritics.
			/// </summary>
			/// <param name="pwcsQueryToken">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Pointer to the prefix to search for.</para>
			/// </param>
			/// <param name="cwcQueryToken">
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The size of pwcsQueryToken.</para>
			/// </param>
			/// <param name="pwcsDocumentToken">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Pointer to the document to be searched.</para>
			/// </param>
			/// <param name="cwcDocumentToken">
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The size of pwcsDocumentToken.</para>
			/// </param>
			/// <param name="pulPrefixLength">
			/// <para>Type: <c>ULONG*</c></para>
			/// <para>
			/// Returns a pointer to the number of characters matched in pwcsDocumentToken. Typically, but not necessarily, the number of
			/// characters in pwcsQueryToken.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>
			/// If pwcsQueryToken is a prefix of pwcsDocumentToken, returns S_OK; otherwise returns S_FALSE, and pulPrefixLength is set to zero.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchlanguagesupport-isprefixnormalized HRESULT
			// IsPrefixNormalized( LPCWSTR pwcsQueryToken, ULONG cwcQueryToken, LPCWSTR pwcsDocumentToken, ULONG cwcDocumentToken, ULONG
			// *pulPrefixLength );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			HRESULT IsPrefixNormalized([MarshalAs(UnmanagedType.LPWStr)] string pwcsQueryToken, uint cwcQueryToken, [MarshalAs(UnmanagedType.LPWStr)] string pwcsDocumentToken, uint cwcDocumentToken, out uint pulPrefixLength);
		}

		/// <summary>
		/// Provides methods for controlling the Search service. This interface manages settings and objects that affect the search engine
		/// across catalogs.
		/// </summary>
		/// <remarks>
		/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which files to
		/// re-index and how.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-isearchmanager
		[PInvokeData("searchapi.h")]
		[ComImport, Guid("AB310581-AC80-11D1-8DF3-00C04FB6EF69"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(CSearchManager))]
		public interface ISearchManager
		{
			/// <summary>Retrieves the version of the current indexer as a single string.</summary>
			/// <returns>The version of the current indexer.</returns>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-getindexerversionstr HRESULT
			// GetIndexerVersionStr( LPWSTR *ppszVersionString );
			[PInvokeData("searchapi.h")]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetIndexerVersionStr();

			/// <summary>
			/// Retrieves the version of the current indexer in two chunks: the major version signifier and the minor version signifier.
			/// </summary>
			/// <param name="pdwMajor">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives the major version signifier (the number to the left of the dot).</para>
			/// </param>
			/// <param name="pdwMinor">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives the minor version signifier (the number to the right of the dot).</para>
			/// </param>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-getindexerversion HRESULT
			// GetIndexerVersion( DWORD *pdwMajor, DWORD *pdwMinor );
			[PInvokeData("searchapi.h")]
			void GetIndexerVersion(out uint pdwMajor, out uint pdwMinor);

			/// <summary>
			/// <para>Not supported.</para>
			/// <para>This method returns E_INVALIDARG when called.</para>
			/// </summary>
			/// <param name="pszName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>There are currently no valid parameters in this version of search (WDS 3.0).</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>PROPVARIANT**</c></para>
			/// <para>Returns a value in an undefined state as there are no properties currently defined to retrieve values from.</para>
			/// </returns>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-getparameter HRESULT GetParameter(
			// LPCWSTR pszName, PROPVARIANT **ppValue );
			[PInvokeData("searchapi.h")]
			[Obsolete]
			PROPVARIANT GetParameter([MarshalAs(UnmanagedType.LPWStr)] string pszName);

			/// <summary>
			/// <para>Not supported.</para>
			/// <para>This method returns E_INVALIDARG when called.</para>
			/// </summary>
			/// <param name="pszName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>There are currently no valid parameters to pass or retrieve.</para>
			/// </param>
			/// <param name="pValue">
			/// <para>Type: <c>PROPVARIANT*</c></para>
			/// <para>As there are no valid parameters currently configured, there are no valid parameters to pass to this method.</para>
			/// </param>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-setparameter HRESULT SetParameter(
			// LPCWSTR pszName, const PROPVARIANT *pValue );
			[PInvokeData("searchapi.h")]
			[Obsolete]
			void SetParameter([MarshalAs(UnmanagedType.LPWStr)] string pszName, [In] PROPVARIANT pValue);

			/// <summary>Retrieves the proxy name to be used by the protocol handler.</summary>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-get_proxyname HRESULT
			// get_ProxyName( LPWSTR *ppszProxyName );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010004)]
			string ProxyName { [return: MarshalAs(UnmanagedType.LPWStr)] get; }

			/// <summary>
			/// Gets a proxy bypass list from the indexer. This list is used to determine which items or URLs are local and do not need to go
			/// through the proxy server. This list is set by calling ISearchManager::SetProxy.
			/// </summary>
			/// <returns>
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>Receives a pointer to the proxy bypass list that is stored in the indexer.</para>
			/// </returns>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-get_bypasslist HRESULT
			// get_BypassList( LPWSTR *ppszBypassList );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010005)]
			string BypassList { [return: MarshalAs(UnmanagedType.LPWStr)] get; }

			/// <summary>Stores information in the indexer that determines how the indexer will work and communicate with a proxy server.</summary>
			/// <param name="sUseProxy">
			/// <para>Type: <c>PROXY_ACCESS</c></para>
			/// <para>Sets whether and how to use a proxy, using one of the values enumerated in PROXY_ACCESS.</para>
			/// </param>
			/// <param name="fLocalByPassProxy">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Sets whether the proxy server should be bypassed for local items and URLs.</para>
			/// </param>
			/// <param name="dwPortNumber">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Sets the port number that the index will use to talk to the proxy server.</para>
			/// </param>
			/// <param name="pszProxyName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A null-terminated Unicode string containing the name of the proxy server to use.</para>
			/// </param>
			/// <param name="pszByPassList">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// A null-terminated Unicode string containing a comma-delimited list of items that are considered local by the indexer and are
			/// not to be accessed through a proxy server.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-setproxy HRESULT SetProxy(
			// PROXY_ACCESS sUseProxy, BOOL fLocalByPassProxy, DWORD dwPortNumber, LPCWSTR pszProxyName, LPCWSTR pszByPassList );
			[PInvokeData("searchapi.h")]
			void SetProxy(PROXY_ACCESS sUseProxy, [MarshalAs(UnmanagedType.Bool)] bool fLocalByPassProxy, uint dwPortNumber, [MarshalAs(UnmanagedType.LPWStr)] string pszProxyName, [MarshalAs(UnmanagedType.LPWStr)] string pszByPassList);

			/// <summary>Retrieves a catalog by name and creates a new ISearchCatalogManager object for that catalog.</summary>
			/// <param name="pszCatalog">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The name of the catalog to be retrieved.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ISearchCatalogManager**</c></para>
			/// <para>Receives the address of a pointer to the ISearchCatalogManager object that is named in pszCatalog.</para>
			/// </returns>
			/// <remarks>
			/// <para>Currently Microsoft Windows Desktop Search (WDS) 3.0 supports only one catalog and it is named SystemIndex.</para>
			/// <para>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-getcatalog HRESULT GetCatalog(
			// LPCWSTR pszCatalog, ISearchCatalogManager **ppCatalogManager );
			[PInvokeData("searchapi.h")]
			ISearchCatalogManager GetCatalog([MarshalAs(UnmanagedType.LPWStr)] string pszCatalog);

			/// <summary>Gets or sets the user agent string.</summary>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-get_useragent
			[PInvokeData("searchapi.h")]
			[DispId(0x60010008)]
			string UserAgent { [return: MarshalAs(UnmanagedType.LPWStr)] get; [param: In, MarshalAs(UnmanagedType.LPWStr)] set; }

			/// <summary>Retrieves the proxy server to be used.</summary>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-get_useproxy HRESULT get_UseProxy(
			// PROXY_ACCESS *pUseProxy );
			[PInvokeData("searchapi.h")]
			[DispId(0x6001000a)]
			PROXY_ACCESS UseProxy { get; }

			/// <summary>Retrieves a value that determines whether the proxy server should be bypassed to find the item or URL.</summary>
			/// <remarks>
			/// <para>
			/// Proxy servers are used as a gateway between the local area network (LAN) and the Internet, primarily for security. A proxy
			/// server accepts requests for information (on other networks or the Internet) from internal systems such as servers or work
			/// stations. The proxy server then forwards the request to the Internet resource, which keeps the address of the requesting
			/// system anonymous. When the information returns from the Internet resource, the proxy server routes the information back to
			/// the requesting system. For content on the LAN, it is not necessary to go through the proxy server to access your content;
			/// this potentially saves time and extra steps.
			/// </para>
			/// <para>
			/// The value retrieved by this method helps the indexer identify how to work with content that is on a local domain or network.
			/// For nonlocal content, going through the proxy server may be appropriate, if not necessary.
			/// </para>
			/// <para>
			/// The setting to bypass the proxy for local domains is stored in the indexer and is set by calling the ISearchManager::SetProxy method.
			/// </para>
			/// <para>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-get_localbypass HRESULT
			// get_LocalBypass( BOOL *pfLocalBypass );
			[PInvokeData("searchapi.h")]
			[DispId(0x6001000b)]
			bool LocalBypass { [return: MarshalAs(UnmanagedType.Bool)] get; }

			/// <summary>
			/// Retrieves the port number used to communicate with the proxy server. This port number is stored in the indexer and is set by
			/// the ISearchManager::SetProxy method.
			/// </summary>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-get_portnumber HRESULT
			// get_PortNumber( DWORD *pdwPortNumber );
			[PInvokeData("searchapi.h")]
			[DispId(0x6001000c)]
			uint PortNumber { get; }
		}

		/// <summary>Enabled applications to create and delete custom catalogs in the Windows Search indexer</summary>
		/// <remarks>
		/// <para>ISearchManager interface ref: http://msdn.microsoft.com/en-us/library/bb231485(VS.85).aspx Managing the Index ref: http://msdn.microsoft.com/en-us/library/bb266516(VS.85).aspx</para>
		/// <para>The new functionality is exposed through the new ISearchManager2 interface. Apps can call QueryInterface on the existing ISearchManager interface to get the new interface. On older versions of Windows where this functionality does not exist the QueryInterface call will fail, and not return the new interface. The existing ISearchManager interface can be used unchanged.</para>
		/// <para>Errors are returned through HRESULTs returned on each method in the standard way COM. ISupportErrorInfo / IErrorInfo are not supported. No exceptions are thrown.</para>
		/// <para>These methods can be called in any COM apartment, and the behavior will not be impacted by the type of apartment. These APIs is safe to call on a UI thread but this is not recommended practice as the APIs involve cross-process IO and other potentially long-running operations.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/searchapi/nn-searchapi-isearchmanager2
		[PInvokeData("searchapi.h", MSDNShortId = "EE08AC43-D2E9-4B70-BBA5-52E36DD7F9A1")]
		[ComImport, Guid("DBAB3F73-DB19-4A79-BFC0-A61A93886DDF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(CSearchManager))]
		public interface ISearchManager2 : ISearchManager
		{
			/// <summary>Retrieves the version of the current indexer as a single string.</summary>
			/// <returns>The version of the current indexer.</returns>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-getindexerversionstr HRESULT
			// GetIndexerVersionStr( LPWSTR *ppszVersionString );
			[PInvokeData("searchapi.h")]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			new string GetIndexerVersionStr();

			/// <summary>
			/// Retrieves the version of the current indexer in two chunks: the major version signifier and the minor version signifier.
			/// </summary>
			/// <param name="pdwMajor">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives the major version signifier (the number to the left of the dot).</para>
			/// </param>
			/// <param name="pdwMinor">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives the minor version signifier (the number to the right of the dot).</para>
			/// </param>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-getindexerversion HRESULT
			// GetIndexerVersion( DWORD *pdwMajor, DWORD *pdwMinor );
			[PInvokeData("searchapi.h")]
			new void GetIndexerVersion(out uint pdwMajor, out uint pdwMinor);

			/// <summary>
			/// <para>Not supported.</para>
			/// <para>This method returns E_INVALIDARG when called.</para>
			/// </summary>
			/// <param name="pszName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>There are currently no valid parameters in this version of search (WDS 3.0).</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>PROPVARIANT**</c></para>
			/// <para>Returns a value in an undefined state as there are no properties currently defined to retrieve values from.</para>
			/// </returns>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-getparameter HRESULT GetParameter(
			// LPCWSTR pszName, PROPVARIANT **ppValue );
			[PInvokeData("searchapi.h")]
			[Obsolete]
			new PROPVARIANT GetParameter([MarshalAs(UnmanagedType.LPWStr)] string pszName);

			/// <summary>
			/// <para>Not supported.</para>
			/// <para>This method returns E_INVALIDARG when called.</para>
			/// </summary>
			/// <param name="pszName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>There are currently no valid parameters to pass or retrieve.</para>
			/// </param>
			/// <param name="pValue">
			/// <para>Type: <c>PROPVARIANT*</c></para>
			/// <para>As there are no valid parameters currently configured, there are no valid parameters to pass to this method.</para>
			/// </param>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-setparameter HRESULT SetParameter(
			// LPCWSTR pszName, const PROPVARIANT *pValue );
			[PInvokeData("searchapi.h")]
			[Obsolete]
			new void SetParameter([MarshalAs(UnmanagedType.LPWStr)] string pszName, [In] PROPVARIANT pValue);

			/// <summary>Retrieves the proxy name to be used by the protocol handler.</summary>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-get_proxyname HRESULT
			// get_ProxyName( LPWSTR *ppszProxyName );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010004)]
			new string ProxyName { [return: MarshalAs(UnmanagedType.LPWStr)] get; }

			/// <summary>
			/// Gets a proxy bypass list from the indexer. This list is used to determine which items or URLs are local and do not need to go
			/// through the proxy server. This list is set by calling ISearchManager::SetProxy.
			/// </summary>
			/// <returns>
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>Receives a pointer to the proxy bypass list that is stored in the indexer.</para>
			/// </returns>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-get_bypasslist HRESULT
			// get_BypassList( LPWSTR *ppszBypassList );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010005)]
			new string BypassList { [return: MarshalAs(UnmanagedType.LPWStr)] get; }

			/// <summary>Stores information in the indexer that determines how the indexer will work and communicate with a proxy server.</summary>
			/// <param name="sUseProxy">
			/// <para>Type: <c>PROXY_ACCESS</c></para>
			/// <para>Sets whether and how to use a proxy, using one of the values enumerated in PROXY_ACCESS.</para>
			/// </param>
			/// <param name="fLocalByPassProxy">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Sets whether the proxy server should be bypassed for local items and URLs.</para>
			/// </param>
			/// <param name="dwPortNumber">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Sets the port number that the index will use to talk to the proxy server.</para>
			/// </param>
			/// <param name="pszProxyName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A null-terminated Unicode string containing the name of the proxy server to use.</para>
			/// </param>
			/// <param name="pszByPassList">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// A null-terminated Unicode string containing a comma-delimited list of items that are considered local by the indexer and are
			/// not to be accessed through a proxy server.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-setproxy HRESULT SetProxy(
			// PROXY_ACCESS sUseProxy, BOOL fLocalByPassProxy, DWORD dwPortNumber, LPCWSTR pszProxyName, LPCWSTR pszByPassList );
			[PInvokeData("searchapi.h")]
			new void SetProxy(PROXY_ACCESS sUseProxy, [MarshalAs(UnmanagedType.Bool)] bool fLocalByPassProxy, uint dwPortNumber, [MarshalAs(UnmanagedType.LPWStr)] string pszProxyName, [MarshalAs(UnmanagedType.LPWStr)] string pszByPassList);

			/// <summary>Retrieves a catalog by name and creates a new ISearchCatalogManager object for that catalog.</summary>
			/// <param name="pszCatalog">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The name of the catalog to be retrieved.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ISearchCatalogManager**</c></para>
			/// <para>Receives the address of a pointer to the ISearchCatalogManager object that is named in pszCatalog.</para>
			/// </returns>
			/// <remarks>
			/// <para>Currently Microsoft Windows Desktop Search (WDS) 3.0 supports only one catalog and it is named SystemIndex.</para>
			/// <para>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-getcatalog HRESULT GetCatalog(
			// LPCWSTR pszCatalog, ISearchCatalogManager **ppCatalogManager );
			[PInvokeData("searchapi.h")]
			new ISearchCatalogManager GetCatalog([MarshalAs(UnmanagedType.LPWStr)] string pszCatalog);

			/// <summary>Gets or sets the user agent string.</summary>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-get_useragent
			[PInvokeData("searchapi.h")]
			[DispId(0x60010008)]
			new string UserAgent { [return: MarshalAs(UnmanagedType.LPWStr)] get; [param: In, MarshalAs(UnmanagedType.LPWStr)] set; }

			/// <summary>Retrieves the proxy server to be used.</summary>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-get_useproxy HRESULT get_UseProxy(
			// PROXY_ACCESS *pUseProxy );
			[PInvokeData("searchapi.h")]
			[DispId(0x6001000a)]
			new PROXY_ACCESS UseProxy { get; }

			/// <summary>Retrieves a value that determines whether the proxy server should be bypassed to find the item or URL.</summary>
			/// <remarks>
			/// <para>
			/// Proxy servers are used as a gateway between the local area network (LAN) and the Internet, primarily for security. A proxy
			/// server accepts requests for information (on other networks or the Internet) from internal systems such as servers or work
			/// stations. The proxy server then forwards the request to the Internet resource, which keeps the address of the requesting
			/// system anonymous. When the information returns from the Internet resource, the proxy server routes the information back to
			/// the requesting system. For content on the LAN, it is not necessary to go through the proxy server to access your content;
			/// this potentially saves time and extra steps.
			/// </para>
			/// <para>
			/// The value retrieved by this method helps the indexer identify how to work with content that is on a local domain or network.
			/// For nonlocal content, going through the proxy server may be appropriate, if not necessary.
			/// </para>
			/// <para>
			/// The setting to bypass the proxy for local domains is stored in the indexer and is set by calling the ISearchManager::SetProxy method.
			/// </para>
			/// <para>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-get_localbypass HRESULT
			// get_LocalBypass( BOOL *pfLocalBypass );
			[PInvokeData("searchapi.h")]
			[DispId(0x6001000b)]
			new bool LocalBypass { [return: MarshalAs(UnmanagedType.Bool)] get; }

			/// <summary>
			/// Retrieves the port number used to communicate with the proxy server. This port number is stored in the indexer and is set by
			/// the ISearchManager::SetProxy method.
			/// </summary>
			/// <remarks>
			/// The ReindexMatchingUrls code sample, available on Code Gallery and the Windows 7 SDK, demonstrates ways to specify which
			/// files to re-index and how.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager-get_portnumber HRESULT
			// get_PortNumber( DWORD *pdwPortNumber );
			[PInvokeData("searchapi.h")]
			[DispId(0x6001000c)]
			new uint PortNumber { get; }

			/// <summary>Creates a new custom catalog in the Windows Search indexer and returns a reference to it.</summary>
			/// <param name="pszCatalog">
			/// Name of catalog to create. Can be any name selected by the caller, must contain only standard alphanumeric characters and underscore.
			/// </param>
			/// <param name="ppCatalogManager">
			/// On success a reference to the created catalog is returned as an ISearchCatalogManager interface pointer. The Release() must
			/// be called on this interface after the calling application has finished using it.
			/// </param>
			/// <returns>
			/// HRESULT indicating status of operation: S_OK - Catalog did not previously exist and was created.Reference to catalog
			/// returned. S_FALSE - Catalog previously existed, reference to catalog returned.
			/// </returns>
			/// <remarks>
			/// Called to create a new catalog in the Windows Search indexer. After creation, the methods on the returned
			/// <c>ISearchCatalog</c> manager can be used to add locations to be indexed, monitor indexing process, and construct queries to
			/// send to the indexer and get results. See the “Managing the Index” documentation for more info: https://msdn.microsoft.com/en-us/library/bb266516(VS.85).aspx
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/search/isearchmanager2-createcatalog HRESULT CreateCatalog( [in] LPCWSTR
			// pszCatalog, [out] ISearchCatalogManager **ppCatalogManager );
			[PInvokeData("", MSDNShortId = "2ADC48B8-87A2-4527-9AA8-9B0BA3A12462")]
			[PreserveSig]
			HRESULT CreateCatalog([MarshalAs(UnmanagedType.LPWStr)] string pszCatalog, out ISearchCatalogManager ppCatalogManager);

			/// <summary>Deletes an existing catalog and all associated indexed data from the Windows Search indexer.</summary>
			/// <param name="pszCatalog">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Name of catalog to delete. The catalog must at some prior time have been created with a call to CreateCatalog().</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>HRESULT indicating status of operation:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Catalog previously existed and has now been successfully deleted.</term>
			/// </item>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>Catalog did not previously existed, no change.</term>
			/// </item>
			/// </list>
			/// <para>FAILED HRESULT: Failure deleting catalog or invalid arguments passed.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchmanager2-deletecatalog HRESULT
			// DeleteCatalog( LPCWSTR pszCatalog );
			[PInvokeData("searchapi.h", MSDNShortId = "E9515AEE-6854-4FF8-9A83-10E6BC247D4D")]
			[PreserveSig]
			HRESULT DeleteCatalog([MarshalAs(UnmanagedType.LPWStr)] string pszCatalog);
		}

		/// <summary>Provides methods the Search service uses to send updates on catalog and index status to notification providers.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-isearchnotifyinlinesite
		[PInvokeData("searchapi.h")]
		[ComImport, Guid("B5702E61-E75C-4B64-82A1-6CB4F832FCCF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISearchNotifyInlineSite
		{
			/// <summary>Called by the search service to notify the client when the status of a particular document or item changes.</summary>
			/// <param name="sipStatus">
			/// <para>Type: <c>SEARCH_INDEXING_PHASE</c></para>
			/// <para>The SEARCH_INDEXING_PHASE status of each document in the array being sent.</para>
			/// </param>
			/// <param name="dwNumEntries">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of entries in rgItemStatusEntries.</para>
			/// </param>
			/// <param name="rgItemStatusEntries">
			/// <para>Type: <c>SEARCH_ITEM_INDEXING_STATUS[]</c></para>
			/// <para>An array of SEARCH_ITEM_INDEXING_STATUS structures containing status update information.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchnotifyinlinesite-onitemindexedstatuschange
			// HRESULT OnItemIndexedStatusChange( SEARCH_INDEXING_PHASE sipStatus, DWORD dwNumEntries, SEARCH_ITEM_INDEXING_STATUS []
			// rgItemStatusEntries );
			[PInvokeData("searchapi.h")]
			void OnItemIndexedStatusChange([In] SEARCH_INDEXING_PHASE sipStatus, [In] uint dwNumEntries, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SEARCH_ITEM_INDEXING_STATUS[] rgItemStatusEntries);

			/// <summary>Called by the search service to notify a client when the status of the catalog changes.</summary>
			/// <param name="guidCatalogResetSignature">
			/// <para>Type: <c>REFGUID</c></para>
			/// <para>A GUID representing the catalog reset. If this GUID changes, all notifications must be resent.</para>
			/// </param>
			/// <param name="guidCheckPointSignature">
			/// <para>Type: <c>REFGUID</c></para>
			/// <para>
			/// A GUID representing the last checkpoint restored. If this GUID changes, all notifications accumulated since the last saved
			/// checkpoint must be resent.
			/// </para>
			/// </param>
			/// <param name="dwLastCheckPointNumber">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>A number indicating the last checkpoint saved.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// When a catalog checkpoint occurs, the search service updates the dwLastCheckPointNumber, and all notifications sent prior to
			/// that checkpoint are safe and recoverable in the event of a service failure. Notification providers need to track only those
			/// notifications sent between checkpoints and must resend them if the catalog is restored or reset.
			/// </para>
			/// <para>
			/// If a catalog restore occurs, the search service rolls back the catalog to the last saved checkpoint and updates the
			/// guidCheckPointSignature. In this situation, notification providers must resend all notifications accumulated since the most
			/// recent saved checkpoint, as identified by the dwLastCheckPointNumber parameter.
			/// </para>
			/// <para>
			/// If a catalog reset occurs, the search service resets the entire catalog and updates the guidCatalogResetSignature. The
			/// notification provider must resend its entire crawl scope.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchnotifyinlinesite-oncatalogstatuschange
			// HRESULT OnCatalogStatusChange( REFGUID guidCatalogResetSignature, REFGUID guidCheckPointSignature, DWORD
			// dwLastCheckPointNumber );
			[PInvokeData("searchapi.h")]
			void OnCatalogStatusChange(in Guid guidCatalogResetSignature, in Guid guidCheckPointSignature, uint dwLastCheckPointNumber);
		}

		/// <summary>Provides methods for passing change notifications to alert the indexer that items need to be updated.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-isearchpersistentitemschangedsink
		[PInvokeData("searchapi.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("A2FFDF9B-4758-4F84-B729-DF81A1A0612F")]
		public interface ISearchPersistentItemsChangedSink
		{
			/// <summary>
			/// Called by a notifications provider to notify the indexer to monitor changes to items within a specified hierarchical scope.
			/// </summary>
			/// <param name="pszUrl">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Pointer to a null-terminated Unicode string that is the start address for the scope to be monitored.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// When notification loss occurs, a notification agent comes online and calls StartedMonitoringScope, which permits an
			/// index-managed notification source to add itself to a list of "monitored scopes". The indexer starts an incremental crawl of
			/// the corresponding document store. The indexer crawls these scopes incrementally until the extreme conditions that caused the
			/// loss of notifications are no longer present. This method ensures that any changes in the store that occur during a period of
			/// notification loss are detected.
			/// </para>
			/// <para>
			/// Under normal circumstances, the list of monitored scopes is not used. Notification loss is rare, and usually occurs only when
			/// disk space is extremely low.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchpersistentitemschangedsink-startedmonitoringscope
			// HRESULT StartedMonitoringScope( LPCWSTR pszURL );
			[PInvokeData("searchapi.h")]
			void StartedMonitoringScope([In, MarshalAs(UnmanagedType.LPWStr)] string pszUrl);

			/// <summary>
			/// Called by a notifications provider to notify the indexer to stop monitoring changes to items within a specified hierarchical scope.
			/// </summary>
			/// <param name="pszUrl">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Pointer to a null-terminated Unicode string that is the address for the scope to stop monitoring.</para>
			/// </param>
			/// <remarks>
			/// When the notifications provider responsible for monitoring changes in the document store goes offline, it calls
			/// <c>ISearchPersistentItemsChangedSink::StoppedMonitoringScope</c> to remove the scope from the list of notification sources.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchpersistentitemschangedsink-stoppedmonitoringscope
			// HRESULT StoppedMonitoringScope( LPCWSTR pszURL );
			[PInvokeData("searchapi.h")]
			void StoppedMonitoringScope([In, MarshalAs(UnmanagedType.LPWStr)] string pszUrl);

			/// <summary>Notifies the indexer to index changed items.</summary>
			/// <param name="dwNumberOfChanges">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of changes being reported.</para>
			/// </param>
			/// <param name="DataChangeEntries">
			/// <para>Type: <c>SEARCH_ITEM_PERSISTENT_CHANGE[]</c></para>
			/// <para>An array of structures of type SEARCH_ITEM_PERSISTENT_CHANGE identifying the details for each change.</para>
			/// </param>
			/// <param name="hrCompletionCodes">
			/// <para>Type: <c>HRESULT[]</c></para>
			/// <para>Indicates whether each URL was accepted for indexing.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchpersistentitemschangedsink-onitemschanged
			// HRESULT OnItemsChanged( DWORD dwNumberOfChanges, SEARCH_ITEM_PERSISTENT_CHANGE [] DataChangeEntries, HRESULT []
			// hrCompletionCodes );
			[PInvokeData("searchapi.h")]
			void OnItemsChanged([In] uint dwNumberOfChanges, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SEARCH_ITEM_PERSISTENT_CHANGE[] DataChangeEntries, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] HRESULT[] hrCompletionCodes);
		}

		/// <summary>
		/// <para>
		/// Provides methods for invoking, initializing, and managing IUrlAccessor objects. Methods in this interface are called by the
		/// protocol host when processing URLs from the gatherer.
		/// </para>
		/// <para>
		/// The protocol handler implements the protocol for accessing a content source in its native format. Use this interface to implement
		/// a custom protocol handler to expand the data sources that can be indexed.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-isearchprotocol
		[PInvokeData("searchapi.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("c73106ba-ac80-11d1-8df3-00c04fb6ef4f")]
		public interface ISearchProtocol
		{
			/// <summary>Initializes a protocol handler.</summary>
			/// <param name="pTimeoutInfo">
			/// <para>Type: <c>TIMEOUT_INFO*</c></para>
			/// <para>Pointer to a TIMEOUT_INFO structure that contains information about connection time-outs.</para>
			/// </param>
			/// <param name="pProtocolHandlerSite">
			/// <para>Type: <c>IProtocolHandlerSite*</c></para>
			/// <para>Pointer to an IProtocolHandlerSite interface that enables protocol handlers to access IFiltearwithin the filter host.</para>
			/// </param>
			/// <param name="pProxyInfo">
			/// <para>Type: <c>PROXY_INFO*</c></para>
			/// <para>
			/// Pointer to a PROXY_INFO structure that contains information about the proxy settings necessary for accessing items in the
			/// content source.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para>
			/// After the protocol handler is created, this method is called to perform any initialization specific to the protocol handler.
			/// This method is not called again.
			/// </para>
			/// <para>
			/// Because the protocol host may unexpectedly terminate before calling ISearchProtocol::ShutDown, protocol handlers with
			/// persistent information, such as temporary files and registry entries, should do an initial clean-up of resources previously
			/// opened in this method before starting the current instance.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchprotocol-init HRESULT Init( TIMEOUT_INFO
			// *pTimeoutInfo, IProtocolHandlerSite *pProtocolHandlerSite, PROXY_INFO *pProxyInfo );
			[PInvokeData("searchapi.h")]
			void Init(in TIMEOUT_INFO pTimeoutInfo, [In] IProtocolHandlerSite pProtocolHandlerSite, in PROXY_INFO pProxyInfo);

			/// <summary>Creates and initializes an IUrlAccessor object.</summary>
			/// <param name="pcwszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Pointer to a null-terminated Unicode string containing the URL of the item being accessed.</para>
			/// </param>
			/// <param name="pAuthenticationInfo">
			/// <para>Type: <c>AUTHENTICATION_INFO*</c></para>
			/// <para>
			/// Pointer to an AUTHENTICATION_INFO structure that contains authentication information necessary for accessing this item in the
			/// content source.
			/// </para>
			/// </param>
			/// <param name="pIncrementalAccessInfo">
			/// <para>Type: <c>INCREMENTAL_ACCESS_INFO*</c></para>
			/// <para>
			/// Pointer to an INCREMENTAL_ACCESS_INFO structure that contains incremental access information, such as the last time the file
			/// was accessed by the gatherer.
			/// </para>
			/// </param>
			/// <param name="pItemInfo">
			/// <para>Type: <c>ITEM_INFO*</c></para>
			/// <para>
			/// Pointer to an ITEM_INFO structure that contains information about the URL item, such as the name of the item's workspace catalog.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>IUrlAccessor**</c></para>
			/// <para>
			/// Receives the address of a pointer to the IUrlAccessor object created by this method. This object contains information about
			/// the URL item, such as the item's file name.
			/// </para>
			/// </returns>
			/// <remarks>
			/// The protocol host calls this method on the protocol handler once for every URL processed by the gatherer and retrieves a
			/// pointer to the IUrlAccessor object. This method creates and initializes an <c>IUrlAccessor</c> object to process an item
			/// currently being accessed by the gatherer.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchprotocol-createaccessor HRESULT
			// CreateAccessor( LPCWSTR pcwszURL, AUTHENTICATION_INFO *pAuthenticationInfo, INCREMENTAL_ACCESS_INFO *pIncrementalAccessInfo,
			// ITEM_INFO *pItemInfo, IUrlAccessor **ppAccessor );
			[PInvokeData("searchapi.h")]
			IUrlAccessor CreateAccessor([In, MarshalAs(UnmanagedType.LPWStr)] string pcwszURL, in AUTHENTICATION_INFO pAuthenticationInfo, in INCREMENTAL_ACCESS_INFO pIncrementalAccessInfo, in ITEM_INFO pItemInfo);

			/// <summary>Closes a previously created IUrlAccessor object.</summary>
			/// <param name="pAccessor">
			/// <para>Type: <c>IUrlAccessor*</c></para>
			/// <para>Pointer to the IUrlAccessor object that was used to process the current URL item.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// The protocol host will release the pAccessor pointer passed to this method when this method returns. Use this method to
			/// release any resources associated with the IUrlAccessor object, freeing it for reuse by the protocol handler.
			/// </para>
			/// <para>
			/// Accessors can be created and maintained in a pool, as resources to be used by protocol handlers when needed, and this might
			/// improve performance. If you are implementing a pool of IUrlAccessor objects, use IUnknown::AddRef to add an
			/// <c>IUrlAccessor</c> to your pool.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchprotocol-closeaccessor HRESULT
			// CloseAccessor( IUrlAccessor *pAccessor );
			[PInvokeData("searchapi.h")]
			void CloseAccessor([In] IUrlAccessor pAccessor);

			/// <summary>Shuts down the protocol handler.</summary>
			/// <remarks>
			/// <para>This method is called by the protocol host to enable the protocol handler to clean up and release any associated resources.</para>
			/// <para>
			/// The protocol host makes one call to this method before it exits. After this method is called, this instance will not be used
			/// any more. However, it is also possible for the protocol host process to terminate abruptly without calling this method.
			/// Protocol handlers that have persisted global states, such as registry entries and temporary files, should verify that those
			/// resources are cleaned up in the ISearchProtocol::Init method before initialization.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchprotocol-shutdown HRESULT ShutDown( );
			[PInvokeData("searchapi.h")]
			void ShutDown();
		}

		/// <summary>
		/// Provides methods for invoking, initializing, and managing IUrlAccessor objects. Methods in this interface are called by the
		/// protocol host when processing URLs from the gatherer.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-isearchprotocol2
		[PInvokeData("searchapi.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("7789F0B2-B5B2-4722-8B65-5DBD150697A9")]
		public interface ISearchProtocol2 : ISearchProtocol
		{
			/// <summary>Initializes a protocol handler.</summary>
			/// <param name="pTimeoutInfo">
			/// <para>Type: <c>TIMEOUT_INFO*</c></para>
			/// <para>Pointer to a TIMEOUT_INFO structure that contains information about connection time-outs.</para>
			/// </param>
			/// <param name="pProtocolHandlerSite">
			/// <para>Type: <c>IProtocolHandlerSite*</c></para>
			/// <para>Pointer to an IProtocolHandlerSite interface that enables protocol handlers to access IFiltearwithin the filter host.</para>
			/// </param>
			/// <param name="pProxyInfo">
			/// <para>Type: <c>PROXY_INFO*</c></para>
			/// <para>
			/// Pointer to a PROXY_INFO structure that contains information about the proxy settings necessary for accessing items in the
			/// content source.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para>
			/// After the protocol handler is created, this method is called to perform any initialization specific to the protocol handler.
			/// This method is not called again.
			/// </para>
			/// <para>
			/// Because the protocol host may unexpectedly terminate before calling ISearchProtocol::ShutDown, protocol handlers with
			/// persistent information, such as temporary files and registry entries, should do an initial clean-up of resources previously
			/// opened in this method before starting the current instance.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchprotocol-init HRESULT Init( TIMEOUT_INFO
			// *pTimeoutInfo, IProtocolHandlerSite *pProtocolHandlerSite, PROXY_INFO *pProxyInfo );
			[PInvokeData("searchapi.h")]
			new void Init(in TIMEOUT_INFO pTimeoutInfo, [In] IProtocolHandlerSite pProtocolHandlerSite, in PROXY_INFO pProxyInfo);

			/// <summary>Creates and initializes an IUrlAccessor object.</summary>
			/// <param name="pcwszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Pointer to a null-terminated Unicode string containing the URL of the item being accessed.</para>
			/// </param>
			/// <param name="pAuthenticationInfo">
			/// <para>Type: <c>AUTHENTICATION_INFO*</c></para>
			/// <para>
			/// Pointer to an AUTHENTICATION_INFO structure that contains authentication information necessary for accessing this item in the
			/// content source.
			/// </para>
			/// </param>
			/// <param name="pIncrementalAccessInfo">
			/// <para>Type: <c>INCREMENTAL_ACCESS_INFO*</c></para>
			/// <para>
			/// Pointer to an INCREMENTAL_ACCESS_INFO structure that contains incremental access information, such as the last time the file
			/// was accessed by the gatherer.
			/// </para>
			/// </param>
			/// <param name="pItemInfo">
			/// <para>Type: <c>ITEM_INFO*</c></para>
			/// <para>
			/// Pointer to an ITEM_INFO structure that contains information about the URL item, such as the name of the item's workspace catalog.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>IUrlAccessor**</c></para>
			/// <para>
			/// Receives the address of a pointer to the IUrlAccessor object created by this method. This object contains information about
			/// the URL item, such as the item's file name.
			/// </para>
			/// </returns>
			/// <remarks>
			/// The protocol host calls this method on the protocol handler once for every URL processed by the gatherer and retrieves a
			/// pointer to the IUrlAccessor object. This method creates and initializes an <c>IUrlAccessor</c> object to process an item
			/// currently being accessed by the gatherer.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchprotocol-createaccessor HRESULT
			// CreateAccessor( LPCWSTR pcwszURL, AUTHENTICATION_INFO *pAuthenticationInfo, INCREMENTAL_ACCESS_INFO *pIncrementalAccessInfo,
			// ITEM_INFO *pItemInfo, IUrlAccessor **ppAccessor );
			[PInvokeData("searchapi.h")]
			new IUrlAccessor CreateAccessor([In, MarshalAs(UnmanagedType.LPWStr)] string pcwszURL, in AUTHENTICATION_INFO pAuthenticationInfo, in INCREMENTAL_ACCESS_INFO pIncrementalAccessInfo, in ITEM_INFO pItemInfo);

			/// <summary>Closes a previously created IUrlAccessor object.</summary>
			/// <param name="pAccessor">
			/// <para>Type: <c>IUrlAccessor*</c></para>
			/// <para>Pointer to the IUrlAccessor object that was used to process the current URL item.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// The protocol host will release the pAccessor pointer passed to this method when this method returns. Use this method to
			/// release any resources associated with the IUrlAccessor object, freeing it for reuse by the protocol handler.
			/// </para>
			/// <para>
			/// Accessors can be created and maintained in a pool, as resources to be used by protocol handlers when needed, and this might
			/// improve performance. If you are implementing a pool of IUrlAccessor objects, use IUnknown::AddRef to add an
			/// <c>IUrlAccessor</c> to your pool.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchprotocol-closeaccessor HRESULT
			// CloseAccessor( IUrlAccessor *pAccessor );
			[PInvokeData("searchapi.h")]
			new void CloseAccessor([In] IUrlAccessor pAccessor);

			/// <summary>Shuts down the protocol handler.</summary>
			/// <remarks>
			/// <para>This method is called by the protocol host to enable the protocol handler to clean up and release any associated resources.</para>
			/// <para>
			/// The protocol host makes one call to this method before it exits. After this method is called, this instance will not be used
			/// any more. However, it is also possible for the protocol host process to terminate abruptly without calling this method.
			/// Protocol handlers that have persisted global states, such as registry entries and temporary files, should verify that those
			/// resources are cleaned up in the ISearchProtocol::Init method before initialization.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchprotocol-shutdown HRESULT ShutDown( );
			[PInvokeData("searchapi.h")]
			new void ShutDown();

			/// <summary>
			/// Creates and initializes an IUrlAccessor object. This method has the same basic functionality as the
			/// ISearchProtocol::CreateAccessor method, but it includes an additional <c>pUserData</c> parameter to supply additional data to
			/// the protocol handler.
			/// </summary>
			/// <param name="pcwszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Pointer to a null-terminated Unicode string containing the URL of the item being accessed.</para>
			/// </param>
			/// <param name="pAuthenticationInfo">
			/// <para>Type: <c>AUTHENTICATION_INFO*</c></para>
			/// <para>
			/// Pointer to an AUTHENTICATION_INFO structure that contains authentication information necessary for accessing this item in the
			/// content source.
			/// </para>
			/// </param>
			/// <param name="pIncrementalAccessInfo">
			/// <para>Type: <c>INCREMENTAL_ACCESS_INFO*</c></para>
			/// <para>
			/// Pointer to an INCREMENTAL_ACCESS_INFO structure that contains incremental access information, such as the last time the file
			/// was accessed by the gatherer.
			/// </para>
			/// </param>
			/// <param name="pItemInfo">
			/// <para>Type: <c>ITEM_INFO*</c></para>
			/// <para>
			/// Pointer to an ITEM_INFO structure that contains information about the URL item, such as the name of the item's workspace catalog.
			/// </para>
			/// </param>
			/// <param name="pUserData">
			/// <para>Type: <c>const BLOB*</c></para>
			/// <para>
			/// Pointer to user information. This data can be whatever the notification originator decides. If the protocol handler
			/// implements this interface, it will receive this data. Not all notifications have this blob set.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>IUrlAccessor**</c></para>
			/// <para>
			/// Receives the address of a pointer to the IUrlAccessor object created by this method. This object contains information about
			/// the URL item, such as the item's file name.
			/// </para>
			/// </returns>
			/// <remarks>
			/// This method creates and initializes an IUrlAccessor object to process an item currently being accessed by the gatherer. The
			/// protocol host calls this method on the protocol handler. This method is called once for every URL processed by the gatherer
			/// and retrieves a pointer to the <c>IUrlAccessor</c> object.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchprotocol2-createaccessorex HRESULT
			// CreateAccessorEx( LPCWSTR pcwszURL, AUTHENTICATION_INFO *pAuthenticationInfo, INCREMENTAL_ACCESS_INFO *pIncrementalAccessInfo,
			// ITEM_INFO *pItemInfo, const BLOB *pUserData, IUrlAccessor **ppAccessor );
			[PInvokeData("searchapi.h")]
			IUrlAccessor CreateAccessorEx([In, MarshalAs(UnmanagedType.LPWStr)] string pcwszURL, in AUTHENTICATION_INFO pAuthenticationInfo,
				in INCREMENTAL_ACCESS_INFO pIncrementalAccessInfo, in ITEM_INFO pItemInfo, in BLOB pUserData);
		}

		/// <summary>
		/// This optional interface enables the protocol handler to perform an action on the thread used for filtering in the protocol host.
		/// When the protocol host starts, it first initializes all the protocol handlers, and then it creates the filtering thread(s). The
		/// methods on this interface enable protocol handlers to manage their resources that are used by a filtering thread.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-isearchprotocolthreadcontext
		[PInvokeData("searchapi.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("c73106e1-ac80-11d1-8df3-00c04fb6ef4f")]
		public interface ISearchProtocolThreadContext
		{
			/// <summary>Initializes communication between the protocol handler and the protocol host.</summary>
			/// <remarks>
			/// After being created by the protocol host, a thread calls this method on the protocol handler to initialize communication
			/// between the protocol handler and its host. Depending on the protocol handler, the host might need to provide some per-thread
			/// context (for example, a logon session).
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchprotocolthreadcontext-threadinit HRESULT
			// ThreadInit( );
			[PInvokeData("searchapi.h")]
			void ThreadInit();

			/// <summary>Notifies the protocol handler that the thread is being shut down.</summary>
			/// <remarks>
			/// When the protocol host is shut down, it calls this method as the last operation before terminating the filtering thread.
			/// Depending on the protocol handler, there might be some per-thread context, such as a logon session, that the protocol handler
			/// needs to clean up.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchprotocolthreadcontext-threadshutdown
			// HRESULT ThreadShutdown( );
			[PInvokeData("searchapi.h")]
			void ThreadShutdown();

			/// <summary>
			/// Notifies the protocol handler that the filtering thread is idle, so that the protocol handler can clean up any cache it might
			/// have built up.
			/// </summary>
			/// <param name="dwTimeElaspedSinceLastCallInMS">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Passes the idle time, in milliseconds, to the protocol handler.</para>
			/// </param>
			/// <remarks>
			/// This method is called when the filtering thread is waiting for new requests from the indexer service so the protocol handler
			/// can use this idle time to clean up.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchprotocolthreadcontext-threadidle HRESULT
			// ThreadIdle( DWORD dwTimeElaspedSinceLastCallInMS );
			[PInvokeData("searchapi.h")]
			void ThreadIdle(uint dwTimeElaspedSinceLastCallInMS);
		}

		/// <summary>
		/// Provides methods for building a query from user input, converting a query to Windows Search SQL, and obtaining a connection
		/// string to initialize a connection to the Window Search index.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This interface is obtained by calling ISearchCatalogManager::GetQueryHelper. Implement this interface as a helper class to ISearchCatalogManager.
		/// </para>
		/// <para>
		/// This interface facilitates the generation of SQL queries using Advanced Query Syntax (AQS) or Natural Query Syntax (NQS). Clients
		/// can submit the SQL query to the Window Search engine by using OLE DB or Microsoft ActiveX Data Objects (ADO).
		/// </para>
		/// <para>
		/// ISearchQueryHelper::GenerateSQLFromUserQuery uses regional locale settings. However, <c>ISearchQueryHelper</c> does not use the
		/// regional locale settings. As a result, there are inconsistencies in the SQL returned from
		/// <c>ISearchQueryHelper::GenerateSQLFromUserQuery</c> and <c>ISearchQueryHelper</c> for region specific settings such as date
		/// formats, for example.
		/// </para>
		/// <para>
		/// The DSearch code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to create a class for a static console
		/// application to query Windows Search using the Microsoft.Search.Interop assembly for <c>ISearchQueryHelper</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/Searchapi/nn-searchapi-isearchqueryhelper
		[PInvokeData("searchapi.h")]
		[ComImport, Guid("AB310581-AC80-11D1-8DF3-00C04FB6EF63"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISearchQueryHelper
		{
			/// <summary>Returns the OLE DB connection string for the Window Search index.</summary>
			/// <value>
			/// A string that is a valid OLE DB connection string. This connection string can be used to initialize a connection to the
			/// Windows Search index and submit the SQL query returned by ISearchQueryHelper::GenerateSQLFromUserQuery.
			/// </value>
			/// <remarks>
			/// <para>
			/// A connection string is a string version of the initialization properties needed to connect to a data store. The string can
			/// include such things as a data source, data source name, or user ID and password.
			/// </para>
			/// <para>
			/// The DSearch code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to create a class for a static
			/// console application to query Windows Search using the Microsoft.Search.Interop assembly for ISearchQueryHelper.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/Searchapi/nf-searchapi-isearchqueryhelper-get_connectionstring HRESULT
			// get_ConnectionString( LPWSTR *pszConnectionString );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010000)]
			string ConnectionString { [return: MarshalAs(UnmanagedType.LPWStr)]  get; }

			/// <summary>Gets or sets the language code identifier (LCID) of the query.</summary>
			/// <value>
			/// <para>The LCID of the query.</para>
			/// </value>
			/// <remarks>
			/// <para>
			/// The locale identifier has the components necessary to uniquely identify one of the installed system-defined locales. The LCID
			/// controls a number of settings including numeric format, date format, currency format, uppercase and lowercase mapping,
			/// dictionary sort ordering, tokenization, and others. Although these settings help Windows operating system and Windows Search
			/// API provide excellent localized support, unexpected results can occur when documents from one locale are searched by a system
			/// set for another locale.
			/// </para>
			/// <para>
			/// When the IFilter object processes a document's text properties and content, it reports the language of that document to the
			/// content indexer. Using this information, the Search API can apply the appropriate word breaker and noise-words list.
			/// </para>
			/// <para>
			/// The locale is used for word breaking, normalizing, and stemming the string values that are extracted from the query string.
			/// If this method is not used (so the content locale is not set), ISearchQueryHelper::get_QueryContentLocale returns the active
			/// input locale.
			/// </para>
			/// <para>
			/// The DSearch code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to create a class for a static
			/// console application to query Windows Search using the Microsoft.Search.Interop assembly for ISearchQueryHelper.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchqueryhelper-put_querycontentlocale HRESULT
			// put_QueryContentLocale( LCID lcid );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010001)]
			uint QueryContentLocale { get; [param: In]  set; }

			/// <summary>
			/// Gets or sets the language code identifier (LCID) for the locale to use when parsing Advanced Query Syntax (AQS) keywords.
			/// </summary>
			/// <value>The LCID for the locale to use when parsing Advanced Query Syntax (AQS) keywords.</value>
			/// <remarks>
			/// The DSearch code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to create a class for a static
			/// console application to query Windows Search using the Microsoft.Search.Interop assembly for ISearchQueryHelper.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchqueryhelper-put_querykeywordlocale HRESULT
			// put_QueryKeywordLocale( LCID lcid );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010003)]
			uint QueryKeywordLocale { get; [param: In]  set; }

			/// <summary>Gets or sets a value that specifies how query terms are to be expanded.</summary>
			/// <value>
			/// <para>Value from the SEARCH_TERM_EXPANSION enumeration that specifies the search term expansion. The default value is SEARCH_TERM_PREFIX_ALL.</para>
			/// </value>
			/// <remarks>
			/// <para>
			/// The <c>ISearchQueryHelper::put_QueryTermExpansion</c> method allows for expansion of some query terms with wildcard
			/// characters, similar to regular expression expansion.
			/// </para>
			/// <para>
			/// While the SEARCH_TERM_EXPANSION enumerated type lets you specify stem expansion, Windows Search does not currently support
			/// its use with the ISearchQueryHelper interface.
			/// </para>
			/// <para>
			/// The DSearch code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to create a class for a static
			/// console application to query Windows Search using the Microsoft.Search.Interop assembly for ISearchQueryHelper.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchqueryhelper-put_querytermexpansion HRESULT
			// put_QueryTermExpansion( SEARCH_TERM_EXPANSION expandTerms );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010005)]
			SEARCH_TERM_EXPANSION QueryTermExpansion { get; [param: In]  set; }

			/// <summary>Gets or sets the syntax of the query.</summary>
			/// <value>
			/// <para>
			/// Flag that specifies the search query syntax. For a list of possible values, see the description of the SEARCH_QUERY_SYNTAX
			/// enumerated type.
			/// </para>
			/// </value>
			/// <remarks>
			/// <para>
			/// The allowed syntaxes are Simple, Natural Query Syntax (NQS), and Advanced Query Syntax (AQS). If not set, the default query
			/// syntax is SEARCH_ADVANCED_QUERY_SYNTAX.
			/// </para>
			/// <para>
			/// The DSearch code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to create a class for a static
			/// console application to query Windows Search using the Microsoft.Search.Interop assembly for ISearchQueryHelper.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchqueryhelper-put_querysyntax HRESULT
			// put_QuerySyntax( SEARCH_QUERY_SYNTAX querySyntax );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010007)]
			SEARCH_QUERY_SYNTAX QuerySyntax { get; [param: In]  set; }

			/// <summary>Gets or sets the properties to include in the query if search terms do not explicitly specify properties.</summary>
			/// <value>
			/// <para>
			/// Pointer to a comma-delimited, null-terminated Unicode string of one or more properties. Separate column specifiers with
			/// commas: "Content,DocAuthor".
			/// </para>
			/// <para>Set ppszContentProperties to <c>NULL</c> to use all properties.</para>
			/// </value>
			/// <remarks>
			/// <para>
			/// Search terms may or may not be explicitly prefixed by a property ("author:Irina" or just "Irina"). If
			/// SEARCH_ADVANCED_QUERY_SYNTAX or NO_QUERY_SYNTAX is set in ISearchQueryHelper::put_QuerySyntax, all search terms not prefixed
			/// by a property keyword are matched against the list of properties in ppszContentProperties.
			/// </para>
			/// <para>
			/// The DSearch code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to create a class for a static
			/// console application to query Windows Search using the Microsoft.Search.Interop assembly for ISearchQueryHelper.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchqueryhelper-put_querycontentproperties
			// HRESULT put_QueryContentProperties( LPCWSTR pszContentProperties );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010009)]
			string QueryContentProperties { [return: MarshalAs(UnmanagedType.LPWStr)]  get; [param: In, MarshalAs(UnmanagedType.LPWStr)]  set; }

			/// <summary>Gets or sets the columns (or properties) requested in the select statement.</summary>
			/// <value>
			/// <para>
			/// A comma-delimited, null-terminated string that specifies one or more columns in the property store. Separate multiple column
			/// specifiers with commas: "System.Document.Author,System.Document.Title".
			/// </para>
			/// </value>
			/// <remarks>
			/// <para>
			/// No defined and fixed set of properties applies to all documents. For this reason, the SQL asterisk is not permitted in the
			/// &lt;columns&gt; setting. For a list of valis Shell system properties, refer to System Properties.
			/// </para>
			/// <para>
			/// The DSearch code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to create a class for a static
			/// console application to query Windows Search using the Microsoft.Search.Interop assembly for ISearchQueryHelper.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchqueryhelper-put_queryselectcolumns HRESULT
			// put_QuerySelectColumns( LPCWSTR pszSelectColumns );
			[PInvokeData("searchapi.h")]
			[DispId(0x6001000b)]
			string QuerySelectColumns { [return: MarshalAs(UnmanagedType.LPWStr)]  get; [param: In, MarshalAs(UnmanagedType.LPWStr)]  set; }

			/// <summary>Gets or sets the restrictions appended to a query in WHERE clauses.</summary>
			/// <value>
			/// <para>
			/// A comma-delimited null-terminated string that specifies one or more query restrictions appended to the query in generated
			/// WHERE clause.
			/// </para>
			/// </value>
			/// <remarks>
			/// <para>pszRestrictions must be a valid WHERE clause for Windows Search SQL (without the WHERE keyword).</para>
			/// <para>
			/// When you create pszRestrictions with multiple restrictions, additional "WHERE" clauses concatenated to the first must start
			/// with "AND" or "OR". For example: "and contains(*, 'qqq')"
			/// </para>
			/// <para>
			/// The DSearch code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to create a class for a static
			/// console application to query Windows Search using the Microsoft.Search.Interop assembly for ISearchQueryHelper.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchqueryhelper-put_querywhererestrictions
			// HRESULT put_QueryWhereRestrictions( LPCWSTR pszRestrictions );
			[PInvokeData("searchapi.h")]
			[DispId(0x6001000d)]
			string QueryWhereRestrictions { [return: MarshalAs(UnmanagedType.LPWStr)]  get; [param: In, MarshalAs(UnmanagedType.LPWStr)]  set; }

			/// <summary>Sets the sort order for the query result set.</summary>
			/// <value>
			/// <para>A comma-delimited, null-terminated Unicode string that specifies the sort order.</para>
			/// </value>
			/// <remarks>
			/// <para>
			/// ppszSorting must be a valid ORDER BY clause (without the ORDER BY keyword). Windows Search SQL supports sorting on multiple
			/// properties, in either ascending (ASC) or descending (DESC) order on each property. For example, ppszSorting might contain the following:
			/// </para>
			/// <para>
			/// The DSearch code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to create a class for a static
			/// console application to query Windows Search using the Microsoft.Search.Interop assembly for ISearchQueryHelper.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchqueryhelper-put_querysorting HRESULT
			// put_QuerySorting( LPCWSTR pszSorting );
			[PInvokeData("searchapi.h")]
			[DispId(0x6001000f)]
			string QuerySorting { [return: MarshalAs(UnmanagedType.LPWStr)]  get; [param: In, MarshalAs(UnmanagedType.LPWStr)]  set; }

			/// <summary>
			/// Generates a Structured Query Language (SQL) query based on a client-supplied query string expressed in either Advanced Query
			/// Syntax (AQS) or Natural Query Syntax (NQS).
			/// </summary>
			/// <param name="pszQuery">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a null-terminated Unicode string containing a query in AQS or NQS.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>Receives the address of a pointer to a SQL query string based on the query in the pszQuery parameter.</para>
			/// </returns>
			/// <remarks>
			/// <para>This method generates SQL in the following form:</para>
			/// <para>
			/// The SQL generation uses the settings specified in ISearchQueryHelper::put_QueryTermExpansion,
			/// ISearchQueryHelper::put_QueryContentProperties, and ISearchQueryHelper::put_QueryContentLocale.
			/// </para>
			/// <para>
			/// <c>ISearchQueryHelper::GenerateSQLFromUserQuery</c> uses regional locale settings. However, ISearchQueryHelper does not use
			/// the regional locale settings. As a result, there are inconsistencies in the SQL returned from
			/// <c>ISearchQueryHelper::GenerateSQLFromUserQuery</c> and <c>ISearchQueryHelper</c> for region specific settings such as date
			/// formats. For example, if you set the locale for date/time to something other than the system locale, such as en-CA if the
			/// system locale is en-US, and enter , the SQL returned will differ. The SQL from
			/// <c>ISearchQueryHelper::GenerateSQLFromUserQuery</c> will have parsed 3/7/2008 according to en-CA (seeking items dated 3rd of
			/// July, 2008) while the SQL from <c>ISearchQueryHelper</c> will have parsed 3/7/2008 according to en-US (seeking items dated
			/// 7th of March, 2008).
			/// </para>
			/// <para>
			/// The DSearch code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to create a class for a static
			/// console application to query Windows Search using the Microsoft.Search.Interop assembly for ISearchQueryHelper.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchqueryhelper-generatesqlfromuserquery
			// HRESULT GenerateSQLFromUserQuery( LPCWSTR pszQuery, LPWSTR *ppszSQL );
			[PInvokeData("searchapi.h")]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GenerateSQLFromUserQuery([In, MarshalAs(UnmanagedType.LPWStr)] string pszQuery);

			/// <summary>Not implemented.</summary>
			/// <param name="itemID">
			/// <para>Type: <c>int</c></para>
			/// <para>The ItemID that is to be affected. The ItemID is used to store the items unique identifier, such as a DocID.</para>
			/// </param>
			/// <param name="dwNumberOfColumns">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of properties being written.</para>
			/// </param>
			/// <param name="pColumns">
			/// Type: <c>PROPERTYKEY*</c>
			/// <para>An array of <c>PROPERTYKEY</c> structures that represent the properties.</para>
			/// </param>
			/// <param name="pValues">
			/// <para>Type: <c>SEARCH_COLUMN_PROPERTIES*</c></para>
			/// <para>Pointer to an array of SEARCH_COLUMN_PROPERTIES structures that hold the property values.</para>
			/// </param>
			/// <param name="pftGatherModifiedTime">
			/// <para>Type: <c>FILETIME*</c></para>
			/// <para>
			/// A pointer to the last modified time for the item being written. This time stamp is used later to see if an item has been
			/// changed and requires updating.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchqueryhelper-writeproperties HRESULT
			// WriteProperties( ITEMID itemID, DWORD dwNumberOfColumns, PROPERTYKEY *pColumns, SEARCH_COLUMN_PROPERTIES *pValues, FILETIME
			// *pftGatherModifiedTime );
			[PInvokeData("searchapi.h")]
			[Obsolete]
			void WriteProperties([In] int itemID, [In] uint dwNumberOfColumns, [In] PROPERTYKEY[] pColumns, [In] SEARCH_COLUMN_PROPERTIES[] pValues, in FILETIME pftGatherModifiedTime);

			/// <summary>Sets the maximum number of results to be returned by a query.</summary>
			/// <value>
			/// <para>The maximum number of results to be returned. Negative numbers return all results.</para>
			/// </value>
			/// <remarks>
			/// The DSearch code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to create a class for a static
			/// console application to query Windows Search using the Microsoft.Search.Interop assembly for ISearchQueryHelper.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchqueryhelper-put_querymaxresults HRESULT
			// put_QueryMaxResults( LONG cMaxResults );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010013)]
			int QueryMaxResults { get; [param: In]  set; }
		}

		/// <summary>
		/// Provides methods for manipulating a search root. Changes to property members are applied to any URL that falls under the search
		/// root. A URL falls under a search root if it matches the search root URL or is a hierarchical child of that URL.
		/// </summary>
		/// <remarks>
		/// The CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to define command line
		/// options for Crawl Scope Manager (CSM) indexing operations.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-isearchroot
		[PInvokeData("searchapi.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("04C18CCF-1F57-4CBD-88CC-3900F5195CE3"), CoClass(typeof(CSearchRoot))]
		public interface ISearchRoot
		{
			/// <summary>The name of the task to be inserted.</summary>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchroot-put_schedule HRESULT put_Schedule(
			// LPCWSTR pszTaskArg );
			[PInvokeData("searchapi.h", MSDNShortId = "")]
			[DispId(0x60010000)]
			string Schedule { [return: MarshalAs(UnmanagedType.LPWStr)] get; [param: In, MarshalAs(UnmanagedType.LPWStr)] set; }

			/// <summary>Sets the URL of the current search root.</summary>
			/// <remarks>
			/// The CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to define command
			/// line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchroot-put_rooturl HRESULT put_RootURL(
			// LPCWSTR pszURL );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010002)]
			string RootURL { [return: MarshalAs(UnmanagedType.LPWStr)] get; [param: In, MarshalAs(UnmanagedType.LPWStr)] set; }

			/// <summary>Sets a value that indicates whether the search is rooted on a hierarchical tree structure.</summary>
			/// <remarks>
			/// The CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to define command
			/// line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchroot-put_ishierarchical HRESULT
			// put_IsHierarchical( BOOL fIsHierarchical );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010004)]
			bool IsHierarchical { [return: MarshalAs(UnmanagedType.Bool)] get; [param: In, MarshalAs(UnmanagedType.Bool)] set; }

			/// <summary>
			/// Sets a value that indicates whether the search engine is notified (by protocol handlers or other applications) about changes
			/// to the URLs under the search root.
			/// </summary>
			/// <remarks>
			/// <para>That value that <c>ISearchRoot::put_ProvidesNotifications</c> sets is not protocol specific.</para>
			/// <para>
			/// The CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to define command
			/// line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchroot-put_providesnotifications HRESULT
			// put_ProvidesNotifications( BOOL fProvidesNotifications );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010006)]
			bool ProvidesNotifications { [return: MarshalAs(UnmanagedType.Bool)] get; [param: In, MarshalAs(UnmanagedType.Bool)] set; }

			/// <summary>Sets a value that indicates whether this search root should be indexed only by notification and not crawled.</summary>
			/// <remarks>
			/// <para>
			/// For search root URLs in a custom data store or on a remote system, it can be useful to limit the search engine to indexing
			/// the URLs only if the store or system has sent notifications that something has changed. This might help to reduce traffic in
			/// the store or across the network by avoiding the incremental crawls when the store is unchanged.
			/// </para>
			/// <para>
			/// The CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to define command
			/// line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchroot-put_usenotificationsonly HRESULT
			// put_UseNotificationsOnly( BOOL fUseNotificationsOnly );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010008)]
			bool UseNotificationsOnly { [return: MarshalAs(UnmanagedType.Bool)] get; [param: In, MarshalAs(UnmanagedType.Bool)] set; }

			/// <summary>Sets the enumeration depth for this search root.</summary>
			/// <remarks>
			/// The CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to define command
			/// line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchroot-put_enumerationdepth HRESULT
			// put_EnumerationDepth( DWORD dwDepth );
			[PInvokeData("searchapi.h")]
			[DispId(0x6001000a)]
			uint EnumerationDepth { get; [param: In] set; }

			/// <summary>
			/// <para>[ <c>put_HostDepth</c> may be altered or unavailable in subsequent versions of the operating system or product.]</para>
			/// <para>Sets a value that indicates how far into a host tree to crawl when indexing.</para>
			/// </summary>
			/// <remarks>
			/// The CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to define command
			/// line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchroot-put_hostdepth HRESULT put_HostDepth(
			// DWORD dwDepth );
			[PInvokeData("searchapi.h")]
			[DispId(0x6001000c)]
			uint HostDepth { get; [param: In] set; }

			/// <summary>
			/// Sets a <c>BOOL</c> value that indicates whether the search engine should follow subdirectories and hierarchical scopes for
			/// this search root.
			/// </summary>
			/// <remarks>
			/// The CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to define command
			/// line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchroot-put_followdirectories HRESULT
			// put_FollowDirectories( BOOL fFollowDirectories );
			[PInvokeData("searchapi.h")]
			[DispId(0x6001000e)]
			bool FollowDirectories { [return: MarshalAs(UnmanagedType.Bool)] get; [param: In, MarshalAs(UnmanagedType.Bool)] set; }

			/// <summary>Sets the type of authentication required to access the URLs under this search root.</summary>
			/// <remarks>
			/// The CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to define command
			/// line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchroot-put_authenticationtype HRESULT
			// put_AuthenticationType( AUTH_TYPE authType );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010010)]
			AUTH_TYPE AuthenticationType { get; [param: In] set; }

			/// <summary>Not implemented.</summary>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchroot-put_user HRESULT put_User( LPCWSTR
			// pszUser );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010012)]
			string User { [return: MarshalAs(UnmanagedType.LPWStr)] get; [param: In, MarshalAs(UnmanagedType.LPWStr)] set; }

			/// <summary>Not implemented.</summary>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchroot-put_password HRESULT put_Password(
			// LPCWSTR pszPassword );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010014)]
			string Password { [return: MarshalAs(UnmanagedType.LPWStr)] get; [param: In, MarshalAs(UnmanagedType.LPWStr)] set; }
		}

		/// <summary>Provides methods to define scope rules for crawling and indexing.</summary>
		/// <remarks>
		/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK, demonstrates
		/// how to define command line options for Crawl Scope Manager (CSM) indexing operations.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-isearchscoperule
		[PInvokeData("searchapi.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("AB310581-AC80-11D1-8DF3-00C04FB6EF53"), CoClass(typeof(CSearchScopeRule))]
		public interface ISearchScopeRule
		{
			/// <summary>Gets the pattern or URL for the rule. The scope rules determine what URLs or paths to include or exclude.</summary>
			/// <returns>
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>
			/// On return, contains the address of a pointer to a null-terminated, Unicode buffer that contains the pattern or URL string.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>A standard URL might look like this:</para>
			/// <para>A pattern might look like this:</para>
			/// <para>Only exclusion rules use patterns.</para>
			/// <para>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchscoperule-get_patternorurl HRESULT
			// get_PatternOrURL( LPWSTR *ppszPatternOrURL );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010000)]
			string PatternOrURL { [return: MarshalAs(UnmanagedType.LPWStr)] get; }

			/// <summary>
			/// Gets a value identifying whether this rule is an inclusion rule. Inclusion rules identify scopes that should be included in
			/// the crawl scope.
			/// </summary>
			/// <returns>
			/// <para>Type: <c>BOOL*</c></para>
			/// <para>On return, points to <c>TRUE</c> if this rule is an inclusion rule, <c>FALSE</c> otherwise.</para>
			/// </returns>
			/// <remarks>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchscoperule-get_isincluded HRESULT
			// get_IsIncluded( BOOL *pfIsIncluded );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010001)]
			bool IsIncluded { [return: MarshalAs(UnmanagedType.Bool)] get; }

			/// <summary>Gets a value that identifies whether this is a default rule.</summary>
			/// <returns>
			/// <para>Type: <c>BOOL*</c></para>
			/// <para>On return, points to the <c>TRUE</c> for default rules and <c>FALSE</c> otherwise.</para>
			/// </returns>
			/// <remarks>
			/// <c>Windows 7 and later</c>: the CrawlScopeCommandLine code sample, available on Code Gallery and the Windows 7 SDK,
			/// demonstrates how to define command line options for Crawl Scope Manager (CSM) indexing operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchscoperule-get_isdefault HRESULT
			// get_IsDefault( BOOL *pfIsDefault );
			[PInvokeData("searchapi.h")]
			[DispId(0x60010002)]
			bool IsDefault { [return: MarshalAs(UnmanagedType.Bool)] get; }

			/// <summary>
			/// <para>Not supported.</para>
			/// <para>This method returns E_InvalidArg when called.</para>
			/// </summary>
			/// <returns>
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Returns a pointer to a value that contains the follow flags.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchscoperule-get_followflags HRESULT
			// get_FollowFlags( DWORD *pFollowFlags );
			[PInvokeData("searchapi.h")]
			[Obsolete]
			[DispId(0x60010003)]
			uint FollowFlags { get; }
		}

		/// <summary>Not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-isearchviewchangedsink
		[PInvokeData("searchapi.h")]
		[ComImport, Guid("AB310581-AC80-11D1-8DF3-00C04FB6EF65"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISearchViewChangedSink
		{
			/// <summary>Not implemented.</summary>
			/// <param name="pdwDocID">TBD</param>
			/// <param name="pChange">TBD</param>
			/// <param name="pfInView">TBD</param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-isearchviewchangedsink-onchange HRESULT OnChange(
			// ITEMID *pdwDocID, SEARCH_ITEM_CHANGE *pChange, BOOL *pfInView );
			[PInvokeData("searchapi.h")]
			void OnChange(in Guid pdwDocID, in SEARCH_ITEM_CHANGE pChange, [MarshalAs(UnmanagedType.Bool)] ref bool pfInView);
		}

		/// <summary>
		/// Provides methods for processing an individual item in a content source whose URL is provided by the gatherer to the filter host.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This is the main interface for pulling data from the content source. The Get... methods are for properties that are required by
		/// or useful to the filter host. Not all data sources have these properties. If the property returned by one of these methods is not
		/// meaningful for your data source, your protocol handler should return E_NOTIMPL.
		/// </para>
		/// <para>The Bind... methods provide access to the data.</para>
		/// <para>
		/// Although the protocol handler runs in the protocol host's multithreaded environment, each protocol handler runs in its own
		/// thread, employing one <c>IUrlAccessor</c> object at a time.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-iurlaccessor
		[PInvokeData("searchapi.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0b63e318-9ccc-11d0-bcdb-00805fccce04")]
		public interface IUrlAccessor
		{
			/// <summary>Requests a property-value set.</summary>
			/// <param name="pSpec">
			/// <para>Type: <c>PROPSPEC*</c></para>
			/// <para>Pointer to a PROPSPEC structure containing the requested property.</para>
			/// </param>
			/// <param name="pVar">
			/// <para>Type: <c>PROPVARIANT*</c></para>
			/// <para>Pointer to a PROPVARIANT structure containing the value for the property specified by pSpec.</para>
			/// </param>
			/// <remarks>
			/// Implement this method to obtain additional information from the content source (for instance, the If-Modified-Since header in
			/// an HTTP request).
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-addrequestparameter HRESULT
			// AddRequestParameter( PROPSPEC *pSpec, PROPVARIANT *pVar );
			[PInvokeData("searchapi.h")]
			void AddRequestParameter(in PROPSPEC pSpec, [In] PROPVARIANT pVar);

			/// <summary>Gets the document format, represented as a Multipurpose Internet Mail Extensions (MIME) string.</summary>
			/// <param name="wszDocFormat">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives a pointer to a null-terminated Unicode string containing the MIME type for the current item.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size of wszDocFormatin <c>TCHAR</c><c>s</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszDocFormat, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// The wszDocFormat is used to identify the correct IFilter for the stream returned by IUrlAccessor::BindToStream. Implement
			/// this method when the URL item is supposed to have a different association than is indicated by the file name extension or
			/// content type. For example, if .doc items are not associated with Microsoft Word, this method should return the CLSID Key key
			/// of the appropriate document source.
			/// </para>
			/// <para>
			/// If you do not provide an implementation of this method or the IUrlAccessor::GetCLSID method, the filter host uses the out
			/// parameters from IUrlAccessor::GetFileName to determine the Multipurpose Internet Mail Extensions (MIME) content type.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getdocformat HRESULT GetDocFormat(
			// WCHAR [] wszDocFormat, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			void GetDocFormat([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszDocFormat, uint dwSize, out uint pdwLength);

			/// <summary>Gets the CLSID for the document type of the URL item being processed.</summary>
			/// <returns>
			/// <para>Type: <c>CLSID*</c></para>
			/// <para>Receives a pointer to the CLSID for the document type of the URL item being processed.</para>
			/// </returns>
			/// <remarks>If this information is not available, you can return E_NOTIMPL or E_FAIL.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getclsid HRESULT GetCLSID( CLSID
			// *pClsid );
			[PInvokeData("searchapi.h")]
			Guid GetCLSID();

			/// <summary>Gets the host name for the content source, if applicable.</summary>
			/// <param name="wszHost">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the name of the host that the content source file resides on, as a null-terminated Unicode string.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of wszHost, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszHost, not including the terminating <c>NULL</c>.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-gethost HRESULT GetHost( WCHAR []
			// wszHost, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			void GetHost([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszHost, uint dwSize, out uint pdwLength);

			/// <summary>Ascertains whether the item URL points to a directory.</summary>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if the URL is a directory, otherwise S_FALSE.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-isdirectory HRESULT IsDirectory( );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			HRESULT IsDirectory();

			/// <summary>Gets the size of the content designated by the URL.</summary>
			/// <returns>
			/// <para>Type: <c>ULONGLONG*</c></para>
			/// <para>Receives a pointer to the number of bytes of data contained in the URL.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The value calculated in this method is a factor in determining limitations on IFilteroutput size. This method should return 0
			/// for containers if the protocol implementation is for a hierarchical content source.
			/// </para>
			/// <para>
			/// Implement this method for non-files by returning the size of the document to be indexed. For example, to index a database
			/// where each row is a document, return the best estimate of the size of the row.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getsize HRESULT GetSize( ULONGLONG
			// *pllSize );
			[PInvokeData("searchapi.h")]
			ulong GetSize();

			/// <summary>Gets the time stamp identifying when the URL was last modified.</summary>
			/// <returns>
			/// <para>Type: <c>FILETIME*</c></para>
			/// <para>Receives a pointer to a variable of type FILETIME identifying the time stamp when the URL was last modified.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method is used to determine whether a URL has changed since the last time it was indexed. If the last modified time has
			/// not changed, the indexer does not process the URL's content.
			/// </para>
			/// <para>Directory URLs are always processed regardless of the time stamp returned by this method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getlastmodified HRESULT
			// GetLastModified( FILETIME *pftLastModified );
			[PInvokeData("searchapi.h")]
			FILETIME GetLastModified();

			/// <summary>
			/// Retrieves the file name of the item, which the filter host uses for indexing. If the item does not exist in a file system and
			/// the IUrlAccessor::BindToStream method is implemented, this method returns the shell's System.ParsingPath property for the item.
			/// </summary>
			/// <param name="wszFileName">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the file name as a null-terminated Unicode string.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of wszFileName, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to <c>wszFileName</c>, not including <c>NULL</c>.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// If this method is implemented, the filter host uses the file name to determine the correct IFilter to use to parse the
			/// content of the stream returned by IUrlAccessor::BindToStream.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getfilename HRESULT GetFileName(
			// WCHAR [] wszFileName, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			void GetFileName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszFileName, uint dwSize, out uint pdwLength);

			/// <summary>
			/// Gets the security descriptor for the URL item. Security is applied at query time, so this descriptor identifies security for
			/// read access.
			/// </summary>
			/// <param name="pSD">
			/// <para>Type: <c>BYTE*</c></para>
			/// <para>Receives a pointer to the security descriptor.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of the pSD array.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to pSD, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method allows custom mappings between users registered to a content source and those users registered on the domain, if
			/// they are different. Security descriptors created in this method must be self-relative.
			/// </para>
			/// <para>
			/// If the URL contains a user security identifier (SID), then the protocol handler is invoked in the security context of that
			/// user, and this method must return E_NOTIMPL.
			/// </para>
			/// <para>
			/// If the URL does not contain a user SID, then the protocol handler is invoked in the security context of the system service.
			/// In that case, this method can return either an access control list (ACL) to restrict read access, or
			/// PRTH_S_ACL_IS_READ_EVERYONE to allow anyone read access during querying.
			/// </para>
			/// <para>
			/// <c>Note</c> If this method returns E_NOTIMPL and the URL does NOT contain a user SID, then the item is retrievable by all
			/// user queries.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getsecuritydescriptor HRESULT
			// GetSecurityDescriptor( BYTE *pSD, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			void GetSecurityDescriptor([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pSD, uint dwSize, out uint pdwLength);

			/// <summary>Gets the redirected URL for the current item.</summary>
			/// <param name="wszRedirectedURL">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the redirected URL as a Unicode string, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of wszRedirectedURL, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>
			/// Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszRedirectedURL, not including the terminating <c>NULL</c>.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>File URLs are not redirected. This method applies only to a content source of HTTP.</para>
			/// <para>
			/// If this method is implemented, the URL that is passed to ISearchProtocol::CreateAccessor will be redirected to the value
			/// returned by this method. All subsequent relative URL links will be processed based on the redirected URL.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getredirectedurl HRESULT
			// GetRedirectedURL( WCHAR [] wszRedirectedURL, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			void GetRedirectedURL([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszRedirectedURL, uint dwSize, out uint pdwLength);

			/// <summary>Gets the security provider for the URL.</summary>
			/// <returns>
			/// <para>Type: <c>CLSID*</c></para>
			/// <para>Receives a pointer to a security provider's CLSID.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getsecurityprovider HRESULT
			// GetSecurityProvider( CLSID *pSPClsid );
			[PInvokeData("searchapi.h")]
			Guid GetSecurityProvider();

			/// <summary>
			/// Binds the item being processed to an IStream interface [Structured Storage] data stream and retrieves a pointer to that stream.
			/// </summary>
			/// <returns>
			/// <para>Type: <c>IStream**</c></para>
			/// <para>Receives the address of a pointer to the IStream that contains the item represented by the URL.</para>
			/// </returns>
			/// <remarks>
			/// Using the information returned by the IUrlAccessor::GetFileName, IUrlAccessor::GetCLSID, and IUrlAccessor::GetDocFormat
			/// methods, the appropriate content IFilterobject is created and passed to this stream by the IPersistStream interface.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-bindtostream HRESULT BindToStream(
			// IStream **ppStream );
			[PInvokeData("searchapi.h")]
			IStream BindToStream();

			/// <summary>Binds the item being processed to the appropriate IFilterand retrieves a pointer to the <c>IFilter</c>.</summary>
			/// <returns>
			/// <para>Type: <c>IFilter**</c></para>
			/// <para>Receives the address of a pointer to the IFilter that can return metadata about the item being processed.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method retrieves an IFilter to enumerate the properties of the item associated with the specified URL, based on the
			/// protocol's information about that URL.
			/// </para>
			/// <para>
			/// If the URL's content is also accessible from the IStream returned by IUrlAccessor::BindToStream, then a separate IFilteris
			/// invoked on the IStream to retrieve additional properties.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-bindtofilter HRESULT BindToFilter(
			// IFilter **ppFilter );
			[PInvokeData("searchapi.h")]
			IFilter BindToFilter();
		}

		/// <summary>Extends functionality of the IUrlAccessor interface.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-iurlaccessor2
		[PInvokeData("searchapi.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("c7310734-ac80-11d1-8df3-00c04fb6ef4f")]
		public interface IUrlAccessor2 : IUrlAccessor
		{
			/// <summary>Requests a property-value set.</summary>
			/// <param name="pSpec">
			/// <para>Type: <c>PROPSPEC*</c></para>
			/// <para>Pointer to a PROPSPEC structure containing the requested property.</para>
			/// </param>
			/// <param name="pVar">
			/// <para>Type: <c>PROPVARIANT*</c></para>
			/// <para>Pointer to a PROPVARIANT structure containing the value for the property specified by pSpec.</para>
			/// </param>
			/// <remarks>
			/// Implement this method to obtain additional information from the content source (for instance, the If-Modified-Since header in
			/// an HTTP request).
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-addrequestparameter HRESULT
			// AddRequestParameter( PROPSPEC *pSpec, PROPVARIANT *pVar );
			[PInvokeData("searchapi.h")]
			new void AddRequestParameter(in PROPSPEC pSpec, [In] PROPVARIANT pVar);

			/// <summary>Gets the document format, represented as a Multipurpose Internet Mail Extensions (MIME) string.</summary>
			/// <param name="wszDocFormat">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives a pointer to a null-terminated Unicode string containing the MIME type for the current item.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size of wszDocFormatin <c>TCHAR</c><c>s</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszDocFormat, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// The wszDocFormat is used to identify the correct IFilter for the stream returned by IUrlAccessor::BindToStream. Implement
			/// this method when the URL item is supposed to have a different association than is indicated by the file name extension or
			/// content type. For example, if .doc items are not associated with Microsoft Word, this method should return the CLSID Key key
			/// of the appropriate document source.
			/// </para>
			/// <para>
			/// If you do not provide an implementation of this method or the IUrlAccessor::GetCLSID method, the filter host uses the out
			/// parameters from IUrlAccessor::GetFileName to determine the Multipurpose Internet Mail Extensions (MIME) content type.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getdocformat HRESULT GetDocFormat(
			// WCHAR [] wszDocFormat, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetDocFormat([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszDocFormat, uint dwSize, out uint pdwLength);

			/// <summary>Gets the CLSID for the document type of the URL item being processed.</summary>
			/// <returns>
			/// <para>Type: <c>CLSID*</c></para>
			/// <para>Receives a pointer to the CLSID for the document type of the URL item being processed.</para>
			/// </returns>
			/// <remarks>If this information is not available, you can return E_NOTIMPL or E_FAIL.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getclsid HRESULT GetCLSID( CLSID
			// *pClsid );
			[PInvokeData("searchapi.h")]
			new Guid GetCLSID();

			/// <summary>Gets the host name for the content source, if applicable.</summary>
			/// <param name="wszHost">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the name of the host that the content source file resides on, as a null-terminated Unicode string.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of wszHost, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszHost, not including the terminating <c>NULL</c>.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-gethost HRESULT GetHost( WCHAR []
			// wszHost, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetHost([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszHost, uint dwSize, out uint pdwLength);

			/// <summary>Ascertains whether the item URL points to a directory.</summary>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if the URL is a directory, otherwise S_FALSE.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-isdirectory HRESULT IsDirectory( );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			new HRESULT IsDirectory();

			/// <summary>Gets the size of the content designated by the URL.</summary>
			/// <returns>
			/// <para>Type: <c>ULONGLONG*</c></para>
			/// <para>Receives a pointer to the number of bytes of data contained in the URL.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The value calculated in this method is a factor in determining limitations on IFilteroutput size. This method should return 0
			/// for containers if the protocol implementation is for a hierarchical content source.
			/// </para>
			/// <para>
			/// Implement this method for non-files by returning the size of the document to be indexed. For example, to index a database
			/// where each row is a document, return the best estimate of the size of the row.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getsize HRESULT GetSize( ULONGLONG
			// *pllSize );
			[PInvokeData("searchapi.h")]
			new ulong GetSize();

			/// <summary>Gets the time stamp identifying when the URL was last modified.</summary>
			/// <returns>
			/// <para>Type: <c>FILETIME*</c></para>
			/// <para>Receives a pointer to a variable of type FILETIME identifying the time stamp when the URL was last modified.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method is used to determine whether a URL has changed since the last time it was indexed. If the last modified time has
			/// not changed, the indexer does not process the URL's content.
			/// </para>
			/// <para>Directory URLs are always processed regardless of the time stamp returned by this method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getlastmodified HRESULT
			// GetLastModified( FILETIME *pftLastModified );
			[PInvokeData("searchapi.h")]
			new FILETIME GetLastModified();

			/// <summary>
			/// Retrieves the file name of the item, which the filter host uses for indexing. If the item does not exist in a file system and
			/// the IUrlAccessor::BindToStream method is implemented, this method returns the shell's System.ParsingPath property for the item.
			/// </summary>
			/// <param name="wszFileName">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the file name as a null-terminated Unicode string.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of wszFileName, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to <c>wszFileName</c>, not including <c>NULL</c>.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// If this method is implemented, the filter host uses the file name to determine the correct IFilter to use to parse the
			/// content of the stream returned by IUrlAccessor::BindToStream.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getfilename HRESULT GetFileName(
			// WCHAR [] wszFileName, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetFileName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszFileName, uint dwSize, out uint pdwLength);

			/// <summary>
			/// Gets the security descriptor for the URL item. Security is applied at query time, so this descriptor identifies security for
			/// read access.
			/// </summary>
			/// <param name="pSD">
			/// <para>Type: <c>BYTE*</c></para>
			/// <para>Receives a pointer to the security descriptor.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of the pSD array.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to pSD, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method allows custom mappings between users registered to a content source and those users registered on the domain, if
			/// they are different. Security descriptors created in this method must be self-relative.
			/// </para>
			/// <para>
			/// If the URL contains a user security identifier (SID), then the protocol handler is invoked in the security context of that
			/// user, and this method must return E_NOTIMPL.
			/// </para>
			/// <para>
			/// If the URL does not contain a user SID, then the protocol handler is invoked in the security context of the system service.
			/// In that case, this method can return either an access control list (ACL) to restrict read access, or
			/// PRTH_S_ACL_IS_READ_EVERYONE to allow anyone read access during querying.
			/// </para>
			/// <para>
			/// <c>Note</c> If this method returns E_NOTIMPL and the URL does NOT contain a user SID, then the item is retrievable by all
			/// user queries.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getsecuritydescriptor HRESULT
			// GetSecurityDescriptor( BYTE *pSD, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetSecurityDescriptor([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pSD, uint dwSize, out uint pdwLength);

			/// <summary>Gets the redirected URL for the current item.</summary>
			/// <param name="wszRedirectedURL">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the redirected URL as a Unicode string, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of wszRedirectedURL, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>
			/// Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszRedirectedURL, not including the terminating <c>NULL</c>.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>File URLs are not redirected. This method applies only to a content source of HTTP.</para>
			/// <para>
			/// If this method is implemented, the URL that is passed to ISearchProtocol::CreateAccessor will be redirected to the value
			/// returned by this method. All subsequent relative URL links will be processed based on the redirected URL.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getredirectedurl HRESULT
			// GetRedirectedURL( WCHAR [] wszRedirectedURL, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetRedirectedURL([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszRedirectedURL, uint dwSize, out uint pdwLength);

			/// <summary>Gets the security provider for the URL.</summary>
			/// <returns>
			/// <para>Type: <c>CLSID*</c></para>
			/// <para>Receives a pointer to a security provider's CLSID.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getsecurityprovider HRESULT
			// GetSecurityProvider( CLSID *pSPClsid );
			[PInvokeData("searchapi.h")]
			new Guid GetSecurityProvider();

			/// <summary>
			/// Binds the item being processed to an IStream interface [Structured Storage] data stream and retrieves a pointer to that stream.
			/// </summary>
			/// <returns>
			/// <para>Type: <c>IStream**</c></para>
			/// <para>Receives the address of a pointer to the IStream that contains the item represented by the URL.</para>
			/// </returns>
			/// <remarks>
			/// Using the information returned by the IUrlAccessor::GetFileName, IUrlAccessor::GetCLSID, and IUrlAccessor::GetDocFormat
			/// methods, the appropriate content IFilterobject is created and passed to this stream by the IPersistStream interface.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-bindtostream HRESULT BindToStream(
			// IStream **ppStream );
			[PInvokeData("searchapi.h")]
			new IStream BindToStream();

			/// <summary>Binds the item being processed to the appropriate IFilterand retrieves a pointer to the <c>IFilter</c>.</summary>
			/// <returns>
			/// <para>Type: <c>IFilter**</c></para>
			/// <para>Receives the address of a pointer to the IFilter that can return metadata about the item being processed.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method retrieves an IFilter to enumerate the properties of the item associated with the specified URL, based on the
			/// protocol's information about that URL.
			/// </para>
			/// <para>
			/// If the URL's content is also accessible from the IStream returned by IUrlAccessor::BindToStream, then a separate IFilteris
			/// invoked on the IStream to retrieve additional properties.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-bindtofilter HRESULT BindToFilter(
			// IFilter **ppFilter );
			[PInvokeData("searchapi.h")]
			new IFilter BindToFilter();

			/// <summary>Gets the user-friendly path for the URL item.</summary>
			/// <param name="wszDocUrl">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the display URL as a null-terminated Unicode string.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of wszDocUrl.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszDocUrl, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <remarks>
			/// Protocol handlers can reveal hierarchical or non-hierarchical stores. If the data store is organized hierarchically, users
			/// can scope their searches to a specified container object like a directory or folder.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor2-getdisplayurl HRESULT GetDisplayUrl(
			// WCHAR [] wszDocUrl, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			void GetDisplayUrl([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszDocUrl, uint dwSize, out uint pdwLength);

			/// <summary>Ascertains whether an item URL is a document or directory.</summary>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_FALSE if the item is a directory; otherwise, it returns S_OK.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor2-isdocument HRESULT IsDocument( );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			HRESULT IsDocument();

			/// <summary>Gets the code page for properties of the URL item.</summary>
			/// <param name="wszCodePage">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the code page as a null-terminated Unicode string.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size of wszCodePage in <c>TCHAR</c><c>s</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>
			/// Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszCodePage, not including the terminating <c>NULL</c> character.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor2-getcodepage HRESULT GetCodePage(
			// WCHAR [] wszCodePage, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			void GetCodePage([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszCodePage, uint dwSize, out uint pdwLength);
		}

		/// <summary>
		/// Extends the functionality of the IUrlAccessor2 interface with the IUrlAccessor3::GetImpersonationSidBlobs method to identify user
		/// security identifiers (SIDs) for a specified URL.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-iurlaccessor3
		[PInvokeData("searchapi.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("6FBC7005-0455-4874-B8FF-7439450241A3")]
		public interface IUrlAccessor3 : IUrlAccessor2
		{
			/// <summary>Requests a property-value set.</summary>
			/// <param name="pSpec">
			/// <para>Type: <c>PROPSPEC*</c></para>
			/// <para>Pointer to a PROPSPEC structure containing the requested property.</para>
			/// </param>
			/// <param name="pVar">
			/// <para>Type: <c>PROPVARIANT*</c></para>
			/// <para>Pointer to a PROPVARIANT structure containing the value for the property specified by pSpec.</para>
			/// </param>
			/// <remarks>
			/// Implement this method to obtain additional information from the content source (for instance, the If-Modified-Since header in
			/// an HTTP request).
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-addrequestparameter HRESULT
			// AddRequestParameter( PROPSPEC *pSpec, PROPVARIANT *pVar );
			[PInvokeData("searchapi.h")]
			new void AddRequestParameter(in PROPSPEC pSpec, [In] PROPVARIANT pVar);

			/// <summary>Gets the document format, represented as a Multipurpose Internet Mail Extensions (MIME) string.</summary>
			/// <param name="wszDocFormat">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives a pointer to a null-terminated Unicode string containing the MIME type for the current item.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size of wszDocFormatin <c>TCHAR</c><c>s</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszDocFormat, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// The wszDocFormat is used to identify the correct IFilter for the stream returned by IUrlAccessor::BindToStream. Implement
			/// this method when the URL item is supposed to have a different association than is indicated by the file name extension or
			/// content type. For example, if .doc items are not associated with Microsoft Word, this method should return the CLSID Key key
			/// of the appropriate document source.
			/// </para>
			/// <para>
			/// If you do not provide an implementation of this method or the IUrlAccessor::GetCLSID method, the filter host uses the out
			/// parameters from IUrlAccessor::GetFileName to determine the Multipurpose Internet Mail Extensions (MIME) content type.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getdocformat HRESULT GetDocFormat(
			// WCHAR [] wszDocFormat, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetDocFormat([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszDocFormat, uint dwSize, out uint pdwLength);

			/// <summary>Gets the CLSID for the document type of the URL item being processed.</summary>
			/// <returns>
			/// <para>Type: <c>CLSID*</c></para>
			/// <para>Receives a pointer to the CLSID for the document type of the URL item being processed.</para>
			/// </returns>
			/// <remarks>If this information is not available, you can return E_NOTIMPL or E_FAIL.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getclsid HRESULT GetCLSID( CLSID
			// *pClsid );
			[PInvokeData("searchapi.h")]
			new Guid GetCLSID();

			/// <summary>Gets the host name for the content source, if applicable.</summary>
			/// <param name="wszHost">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the name of the host that the content source file resides on, as a null-terminated Unicode string.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of wszHost, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszHost, not including the terminating <c>NULL</c>.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-gethost HRESULT GetHost( WCHAR []
			// wszHost, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetHost([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszHost, uint dwSize, out uint pdwLength);

			/// <summary>Ascertains whether the item URL points to a directory.</summary>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if the URL is a directory, otherwise S_FALSE.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-isdirectory HRESULT IsDirectory( );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			new HRESULT IsDirectory();

			/// <summary>Gets the size of the content designated by the URL.</summary>
			/// <returns>
			/// <para>Type: <c>ULONGLONG*</c></para>
			/// <para>Receives a pointer to the number of bytes of data contained in the URL.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The value calculated in this method is a factor in determining limitations on IFilteroutput size. This method should return 0
			/// for containers if the protocol implementation is for a hierarchical content source.
			/// </para>
			/// <para>
			/// Implement this method for non-files by returning the size of the document to be indexed. For example, to index a database
			/// where each row is a document, return the best estimate of the size of the row.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getsize HRESULT GetSize( ULONGLONG
			// *pllSize );
			[PInvokeData("searchapi.h")]
			new ulong GetSize();

			/// <summary>Gets the time stamp identifying when the URL was last modified.</summary>
			/// <returns>
			/// <para>Type: <c>FILETIME*</c></para>
			/// <para>Receives a pointer to a variable of type FILETIME identifying the time stamp when the URL was last modified.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method is used to determine whether a URL has changed since the last time it was indexed. If the last modified time has
			/// not changed, the indexer does not process the URL's content.
			/// </para>
			/// <para>Directory URLs are always processed regardless of the time stamp returned by this method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getlastmodified HRESULT
			// GetLastModified( FILETIME *pftLastModified );
			[PInvokeData("searchapi.h")]
			new FILETIME GetLastModified();

			/// <summary>
			/// Retrieves the file name of the item, which the filter host uses for indexing. If the item does not exist in a file system and
			/// the IUrlAccessor::BindToStream method is implemented, this method returns the shell's System.ParsingPath property for the item.
			/// </summary>
			/// <param name="wszFileName">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the file name as a null-terminated Unicode string.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of wszFileName, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to <c>wszFileName</c>, not including <c>NULL</c>.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// If this method is implemented, the filter host uses the file name to determine the correct IFilter to use to parse the
			/// content of the stream returned by IUrlAccessor::BindToStream.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getfilename HRESULT GetFileName(
			// WCHAR [] wszFileName, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetFileName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszFileName, uint dwSize, out uint pdwLength);

			/// <summary>
			/// Gets the security descriptor for the URL item. Security is applied at query time, so this descriptor identifies security for
			/// read access.
			/// </summary>
			/// <param name="pSD">
			/// <para>Type: <c>BYTE*</c></para>
			/// <para>Receives a pointer to the security descriptor.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of the pSD array.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to pSD, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method allows custom mappings between users registered to a content source and those users registered on the domain, if
			/// they are different. Security descriptors created in this method must be self-relative.
			/// </para>
			/// <para>
			/// If the URL contains a user security identifier (SID), then the protocol handler is invoked in the security context of that
			/// user, and this method must return E_NOTIMPL.
			/// </para>
			/// <para>
			/// If the URL does not contain a user SID, then the protocol handler is invoked in the security context of the system service.
			/// In that case, this method can return either an access control list (ACL) to restrict read access, or
			/// PRTH_S_ACL_IS_READ_EVERYONE to allow anyone read access during querying.
			/// </para>
			/// <para>
			/// <c>Note</c> If this method returns E_NOTIMPL and the URL does NOT contain a user SID, then the item is retrievable by all
			/// user queries.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getsecuritydescriptor HRESULT
			// GetSecurityDescriptor( BYTE *pSD, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetSecurityDescriptor([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pSD, uint dwSize, out uint pdwLength);

			/// <summary>Gets the redirected URL for the current item.</summary>
			/// <param name="wszRedirectedURL">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the redirected URL as a Unicode string, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of wszRedirectedURL, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>
			/// Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszRedirectedURL, not including the terminating <c>NULL</c>.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>File URLs are not redirected. This method applies only to a content source of HTTP.</para>
			/// <para>
			/// If this method is implemented, the URL that is passed to ISearchProtocol::CreateAccessor will be redirected to the value
			/// returned by this method. All subsequent relative URL links will be processed based on the redirected URL.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getredirectedurl HRESULT
			// GetRedirectedURL( WCHAR [] wszRedirectedURL, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetRedirectedURL([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszRedirectedURL, uint dwSize, out uint pdwLength);

			/// <summary>Gets the security provider for the URL.</summary>
			/// <returns>
			/// <para>Type: <c>CLSID*</c></para>
			/// <para>Receives a pointer to a security provider's CLSID.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getsecurityprovider HRESULT
			// GetSecurityProvider( CLSID *pSPClsid );
			[PInvokeData("searchapi.h")]
			new Guid GetSecurityProvider();

			/// <summary>
			/// Binds the item being processed to an IStream interface [Structured Storage] data stream and retrieves a pointer to that stream.
			/// </summary>
			/// <returns>
			/// <para>Type: <c>IStream**</c></para>
			/// <para>Receives the address of a pointer to the IStream that contains the item represented by the URL.</para>
			/// </returns>
			/// <remarks>
			/// Using the information returned by the IUrlAccessor::GetFileName, IUrlAccessor::GetCLSID, and IUrlAccessor::GetDocFormat
			/// methods, the appropriate content IFilterobject is created and passed to this stream by the IPersistStream interface.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-bindtostream HRESULT BindToStream(
			// IStream **ppStream );
			[PInvokeData("searchapi.h")]
			new IStream BindToStream();

			/// <summary>Binds the item being processed to the appropriate IFilterand retrieves a pointer to the <c>IFilter</c>.</summary>
			/// <returns>
			/// <para>Type: <c>IFilter**</c></para>
			/// <para>Receives the address of a pointer to the IFilter that can return metadata about the item being processed.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method retrieves an IFilter to enumerate the properties of the item associated with the specified URL, based on the
			/// protocol's information about that URL.
			/// </para>
			/// <para>
			/// If the URL's content is also accessible from the IStream returned by IUrlAccessor::BindToStream, then a separate IFilteris
			/// invoked on the IStream to retrieve additional properties.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-bindtofilter HRESULT BindToFilter(
			// IFilter **ppFilter );
			[PInvokeData("searchapi.h")]
			new IFilter BindToFilter();

			/// <summary>Gets the user-friendly path for the URL item.</summary>
			/// <param name="wszDocUrl">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the display URL as a null-terminated Unicode string.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of wszDocUrl.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszDocUrl, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <remarks>
			/// Protocol handlers can reveal hierarchical or non-hierarchical stores. If the data store is organized hierarchically, users
			/// can scope their searches to a specified container object like a directory or folder.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor2-getdisplayurl HRESULT GetDisplayUrl(
			// WCHAR [] wszDocUrl, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetDisplayUrl([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszDocUrl, uint dwSize, out uint pdwLength);

			/// <summary>Ascertains whether an item URL is a document or directory.</summary>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_FALSE if the item is a directory; otherwise, it returns S_OK.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor2-isdocument HRESULT IsDocument( );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			new HRESULT IsDocument();

			/// <summary>Gets the code page for properties of the URL item.</summary>
			/// <param name="wszCodePage">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the code page as a null-terminated Unicode string.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size of wszCodePage in <c>TCHAR</c><c>s</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>
			/// Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszCodePage, not including the terminating <c>NULL</c> character.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor2-getcodepage HRESULT GetCodePage(
			// WCHAR [] wszCodePage, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetCodePage([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszCodePage, uint dwSize, out uint pdwLength);

			/// <summary>
			/// Retrieves an array of user security identifiers (SIDs) for a specified URL. This method enables protocol handlers to specify
			/// which users can access the file and the search protocol host to impersonate a user in order to index the file.
			/// </summary>
			/// <param name="pcwszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The URL to access on behalf of an impersonated user.</para>
			/// </param>
			/// <param name="pcSidCount">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of user SIDs returned in ppSidBlobs.</para>
			/// </param>
			/// <param name="ppSidBlobs">
			/// <para>Type: <c>BLOB**</c></para>
			/// <para>Receives the address of a pointer to the array of candidate impersonation user SIDs.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// If the file is encrypted, this method identifies who can both decrypt and access it. If the method cannot identify this
			/// information, it fails with error code E_ACCESSDENIED.
			/// </para>
			/// <para>
			/// This method assumes that the IUrlAccessor2 object failed to initialize and returned the code PRTH_S_TRY_IMPERSONATING. Then,
			/// the search protocol host calls this method to retrieve a list of SIDs to use for impersonation and reverts to using
			/// <c>IUrlAccessor2</c>, impersonating one of the allowed users when opening the item.
			/// </para>
			/// <para>
			/// Impersonating a user does not elevate the caller's privileges. If the caller cannot directly retrieve the list of users
			/// authorized to access a resource, the caller won't be able to do that with this method, either. Only the search protocol host
			/// and the indexer have adequate privileges to impersonate users currently logged on.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor3-getimpersonationsidblobs HRESULT
			// GetImpersonationSidBlobs( LPCWSTR pcwszURL, DWORD *pcSidCount, BLOB **ppSidBlobs );
			[PInvokeData("searchapi.h")]
			void GetImpersonationSidBlobs([In, MarshalAs(UnmanagedType.LPWStr)] string pcwszURL, out uint pcSidCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] out BLOB[] ppSidBlobs);
		}

		/// <summary>
		/// Extends the functionality of the IUrlAccessor3 interface with the IUrlAccessor4::ShouldIndexItemContent method that identifies
		/// whether the content of the item should be indexed.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nn-searchapi-iurlaccessor4
		[PInvokeData("searchapi.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5CC51041-C8D2-41d7-BCA3-9E9E286297DC")]
		public interface IUrlAccessor4 : IUrlAccessor3
		{
			/// <summary>Requests a property-value set.</summary>
			/// <param name="pSpec">
			/// <para>Type: <c>PROPSPEC*</c></para>
			/// <para>Pointer to a PROPSPEC structure containing the requested property.</para>
			/// </param>
			/// <param name="pVar">
			/// <para>Type: <c>PROPVARIANT*</c></para>
			/// <para>Pointer to a PROPVARIANT structure containing the value for the property specified by pSpec.</para>
			/// </param>
			/// <remarks>
			/// Implement this method to obtain additional information from the content source (for instance, the If-Modified-Since header in
			/// an HTTP request).
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-addrequestparameter HRESULT
			// AddRequestParameter( PROPSPEC *pSpec, PROPVARIANT *pVar );
			[PInvokeData("searchapi.h")]
			new void AddRequestParameter(in PROPSPEC pSpec, [In] PROPVARIANT pVar);

			/// <summary>Gets the document format, represented as a Multipurpose Internet Mail Extensions (MIME) string.</summary>
			/// <param name="wszDocFormat">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives a pointer to a null-terminated Unicode string containing the MIME type for the current item.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size of wszDocFormatin <c>TCHAR</c><c>s</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszDocFormat, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// The wszDocFormat is used to identify the correct IFilter for the stream returned by IUrlAccessor::BindToStream. Implement
			/// this method when the URL item is supposed to have a different association than is indicated by the file name extension or
			/// content type. For example, if .doc items are not associated with Microsoft Word, this method should return the CLSID Key key
			/// of the appropriate document source.
			/// </para>
			/// <para>
			/// If you do not provide an implementation of this method or the IUrlAccessor::GetCLSID method, the filter host uses the out
			/// parameters from IUrlAccessor::GetFileName to determine the Multipurpose Internet Mail Extensions (MIME) content type.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getdocformat HRESULT GetDocFormat(
			// WCHAR [] wszDocFormat, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetDocFormat([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszDocFormat, uint dwSize, out uint pdwLength);

			/// <summary>Gets the CLSID for the document type of the URL item being processed.</summary>
			/// <returns>
			/// <para>Type: <c>CLSID*</c></para>
			/// <para>Receives a pointer to the CLSID for the document type of the URL item being processed.</para>
			/// </returns>
			/// <remarks>If this information is not available, you can return E_NOTIMPL or E_FAIL.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getclsid HRESULT GetCLSID( CLSID
			// *pClsid );
			[PInvokeData("searchapi.h")]
			new Guid GetCLSID();

			/// <summary>Gets the host name for the content source, if applicable.</summary>
			/// <param name="wszHost">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the name of the host that the content source file resides on, as a null-terminated Unicode string.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of wszHost, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszHost, not including the terminating <c>NULL</c>.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-gethost HRESULT GetHost( WCHAR []
			// wszHost, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetHost([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszHost, uint dwSize, out uint pdwLength);

			/// <summary>Ascertains whether the item URL points to a directory.</summary>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if the URL is a directory, otherwise S_FALSE.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-isdirectory HRESULT IsDirectory( );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			new HRESULT IsDirectory();

			/// <summary>Gets the size of the content designated by the URL.</summary>
			/// <returns>
			/// <para>Type: <c>ULONGLONG*</c></para>
			/// <para>Receives a pointer to the number of bytes of data contained in the URL.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The value calculated in this method is a factor in determining limitations on IFilteroutput size. This method should return 0
			/// for containers if the protocol implementation is for a hierarchical content source.
			/// </para>
			/// <para>
			/// Implement this method for non-files by returning the size of the document to be indexed. For example, to index a database
			/// where each row is a document, return the best estimate of the size of the row.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getsize HRESULT GetSize( ULONGLONG
			// *pllSize );
			[PInvokeData("searchapi.h")]
			new ulong GetSize();

			/// <summary>Gets the time stamp identifying when the URL was last modified.</summary>
			/// <returns>
			/// <para>Type: <c>FILETIME*</c></para>
			/// <para>Receives a pointer to a variable of type FILETIME identifying the time stamp when the URL was last modified.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method is used to determine whether a URL has changed since the last time it was indexed. If the last modified time has
			/// not changed, the indexer does not process the URL's content.
			/// </para>
			/// <para>Directory URLs are always processed regardless of the time stamp returned by this method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getlastmodified HRESULT
			// GetLastModified( FILETIME *pftLastModified );
			[PInvokeData("searchapi.h")]
			new FILETIME GetLastModified();

			/// <summary>
			/// Retrieves the file name of the item, which the filter host uses for indexing. If the item does not exist in a file system and
			/// the IUrlAccessor::BindToStream method is implemented, this method returns the shell's System.ParsingPath property for the item.
			/// </summary>
			/// <param name="wszFileName">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the file name as a null-terminated Unicode string.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of wszFileName, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to <c>wszFileName</c>, not including <c>NULL</c>.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// If this method is implemented, the filter host uses the file name to determine the correct IFilter to use to parse the
			/// content of the stream returned by IUrlAccessor::BindToStream.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getfilename HRESULT GetFileName(
			// WCHAR [] wszFileName, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetFileName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszFileName, uint dwSize, out uint pdwLength);

			/// <summary>
			/// Gets the security descriptor for the URL item. Security is applied at query time, so this descriptor identifies security for
			/// read access.
			/// </summary>
			/// <param name="pSD">
			/// <para>Type: <c>BYTE*</c></para>
			/// <para>Receives a pointer to the security descriptor.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of the pSD array.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to pSD, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method allows custom mappings between users registered to a content source and those users registered on the domain, if
			/// they are different. Security descriptors created in this method must be self-relative.
			/// </para>
			/// <para>
			/// If the URL contains a user security identifier (SID), then the protocol handler is invoked in the security context of that
			/// user, and this method must return E_NOTIMPL.
			/// </para>
			/// <para>
			/// If the URL does not contain a user SID, then the protocol handler is invoked in the security context of the system service.
			/// In that case, this method can return either an access control list (ACL) to restrict read access, or
			/// PRTH_S_ACL_IS_READ_EVERYONE to allow anyone read access during querying.
			/// </para>
			/// <para>
			/// <c>Note</c> If this method returns E_NOTIMPL and the URL does NOT contain a user SID, then the item is retrievable by all
			/// user queries.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getsecuritydescriptor HRESULT
			// GetSecurityDescriptor( BYTE *pSD, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetSecurityDescriptor([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pSD, uint dwSize, out uint pdwLength);

			/// <summary>Gets the redirected URL for the current item.</summary>
			/// <param name="wszRedirectedURL">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the redirected URL as a Unicode string, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of wszRedirectedURL, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>
			/// Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszRedirectedURL, not including the terminating <c>NULL</c>.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>File URLs are not redirected. This method applies only to a content source of HTTP.</para>
			/// <para>
			/// If this method is implemented, the URL that is passed to ISearchProtocol::CreateAccessor will be redirected to the value
			/// returned by this method. All subsequent relative URL links will be processed based on the redirected URL.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getredirectedurl HRESULT
			// GetRedirectedURL( WCHAR [] wszRedirectedURL, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetRedirectedURL([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszRedirectedURL, uint dwSize, out uint pdwLength);

			/// <summary>Gets the security provider for the URL.</summary>
			/// <returns>
			/// <para>Type: <c>CLSID*</c></para>
			/// <para>Receives a pointer to a security provider's CLSID.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-getsecurityprovider HRESULT
			// GetSecurityProvider( CLSID *pSPClsid );
			[PInvokeData("searchapi.h")]
			new Guid GetSecurityProvider();

			/// <summary>
			/// Binds the item being processed to an IStream interface [Structured Storage] data stream and retrieves a pointer to that stream.
			/// </summary>
			/// <returns>
			/// <para>Type: <c>IStream**</c></para>
			/// <para>Receives the address of a pointer to the IStream that contains the item represented by the URL.</para>
			/// </returns>
			/// <remarks>
			/// Using the information returned by the IUrlAccessor::GetFileName, IUrlAccessor::GetCLSID, and IUrlAccessor::GetDocFormat
			/// methods, the appropriate content IFilterobject is created and passed to this stream by the IPersistStream interface.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-bindtostream HRESULT BindToStream(
			// IStream **ppStream );
			[PInvokeData("searchapi.h")]
			new IStream BindToStream();

			/// <summary>Binds the item being processed to the appropriate IFilterand retrieves a pointer to the <c>IFilter</c>.</summary>
			/// <returns>
			/// <para>Type: <c>IFilter**</c></para>
			/// <para>Receives the address of a pointer to the IFilter that can return metadata about the item being processed.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method retrieves an IFilter to enumerate the properties of the item associated with the specified URL, based on the
			/// protocol's information about that URL.
			/// </para>
			/// <para>
			/// If the URL's content is also accessible from the IStream returned by IUrlAccessor::BindToStream, then a separate IFilteris
			/// invoked on the IStream to retrieve additional properties.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor-bindtofilter HRESULT BindToFilter(
			// IFilter **ppFilter );
			[PInvokeData("searchapi.h")]
			new IFilter BindToFilter();

			/// <summary>Gets the user-friendly path for the URL item.</summary>
			/// <param name="wszDocUrl">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the display URL as a null-terminated Unicode string.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size in <c>TCHAR</c><c>s</c> of wszDocUrl.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszDocUrl, not including the terminating <c>NULL</c>.</para>
			/// </param>
			/// <remarks>
			/// Protocol handlers can reveal hierarchical or non-hierarchical stores. If the data store is organized hierarchically, users
			/// can scope their searches to a specified container object like a directory or folder.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor2-getdisplayurl HRESULT GetDisplayUrl(
			// WCHAR [] wszDocUrl, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetDisplayUrl([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszDocUrl, uint dwSize, out uint pdwLength);

			/// <summary>Ascertains whether an item URL is a document or directory.</summary>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_FALSE if the item is a directory; otherwise, it returns S_OK.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor2-isdocument HRESULT IsDocument( );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			new HRESULT IsDocument();

			/// <summary>Gets the code page for properties of the URL item.</summary>
			/// <param name="wszCodePage">
			/// <para>Type: <c>WCHAR[]</c></para>
			/// <para>Receives the code page as a null-terminated Unicode string.</para>
			/// </param>
			/// <param name="dwSize">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size of wszCodePage in <c>TCHAR</c><c>s</c>.</para>
			/// </param>
			/// <param name="pdwLength">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>
			/// Receives a pointer to the number of <c>TCHAR</c><c>s</c> written to wszCodePage, not including the terminating <c>NULL</c> character.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor2-getcodepage HRESULT GetCodePage(
			// WCHAR [] wszCodePage, DWORD dwSize, DWORD *pdwLength );
			[PInvokeData("searchapi.h")]
			new void GetCodePage([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszCodePage, uint dwSize, out uint pdwLength);

			/// <summary>
			/// Retrieves an array of user security identifiers (SIDs) for a specified URL. This method enables protocol handlers to specify
			/// which users can access the file and the search protocol host to impersonate a user in order to index the file.
			/// </summary>
			/// <param name="pcwszURL">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The URL to access on behalf of an impersonated user.</para>
			/// </param>
			/// <param name="pcSidCount">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>Receives a pointer to the number of user SIDs returned in ppSidBlobs.</para>
			/// </param>
			/// <param name="ppSidBlobs">
			/// <para>Type: <c>BLOB**</c></para>
			/// <para>Receives the address of a pointer to the array of candidate impersonation user SIDs.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// If the file is encrypted, this method identifies who can both decrypt and access it. If the method cannot identify this
			/// information, it fails with error code E_ACCESSDENIED.
			/// </para>
			/// <para>
			/// This method assumes that the IUrlAccessor2 object failed to initialize and returned the code PRTH_S_TRY_IMPERSONATING. Then,
			/// the search protocol host calls this method to retrieve a list of SIDs to use for impersonation and reverts to using
			/// <c>IUrlAccessor2</c>, impersonating one of the allowed users when opening the item.
			/// </para>
			/// <para>
			/// Impersonating a user does not elevate the caller's privileges. If the caller cannot directly retrieve the list of users
			/// authorized to access a resource, the caller won't be able to do that with this method, either. Only the search protocol host
			/// and the indexer have adequate privileges to impersonate users currently logged on.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor3-getimpersonationsidblobs HRESULT
			// GetImpersonationSidBlobs( LPCWSTR pcwszURL, DWORD *pcSidCount, BLOB **ppSidBlobs );
			[PInvokeData("searchapi.h")]
			new void GetImpersonationSidBlobs([In, MarshalAs(UnmanagedType.LPWStr)] string pcwszURL, out uint pcSidCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] out BLOB[] ppSidBlobs);

			/// <summary>Identifies whether the item's content should be indexed.</summary>
			/// <param name="pfIndexContent">
			/// <para>Type: <c>BOOL*</c></para>
			/// <para>A pointer to a <c>BOOL</c> value that indicates whether the item's content should be indexed.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_FALSE if the item's content should not be indexed.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor4-shouldindexitemcontent HRESULT
			// ShouldIndexItemContent( BOOL *pfIndexContent );
			[PInvokeData("searchapi.h")]
			[PreserveSig]
			HRESULT ShouldIndexItemContent([MarshalAs(UnmanagedType.Bool)] out bool pfIndexContent);

			/// <summary>Identifies whether a property should be indexed.</summary>
			/// <param name="key">The property to index.</param>
			/// <param name="pfIndexProperty">A pointer to a value that indicates whether a property should be indexed.</param>
			/// <returns>Returns S_FALSE if the property should not be indexed.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/nf-searchapi-iurlaccessor4-shouldindexproperty HRESULT
			// ShouldIndexProperty( REFPROPERTYKEY key, BOOL *pfIndexProperty );
			[PInvokeData("searchapi.h", MSDNShortId = "44F10BD2-0CE5-4462-A50B-CBD63EE3B802")]
			[PreserveSig]
			HRESULT ShouldIndexProperty(in PROPERTYKEY key, [MarshalAs(UnmanagedType.Bool)] out bool pfIndexProperty);
		}

		/// <summary>Undocumented.</summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("40BDBD34-780B-48D3-9BB6-12EBD4AD2E75"), CoClass(typeof(FilterRegistration))]
		private interface ILoadFilterWithPrivateComActivation : ILoadFilter
		{
			/// <summary>Retrieves and loads the most appropriate filter that is mapped to a Shell data source.</summary>
			/// <param name="pwcsPath">
			/// Pointer to a comma-delimited null-terminated Unicode string buffer that specifies the path of the file to be filtered. This
			/// parameter can be null.
			/// </param>
			/// <param name="pFilteredSources">
			/// Pointer to the FILTERED_DATA_SOURCES structure that specifies parameters for a Shell data source for which a filter is
			/// loaded. This parameter cannot be null.
			/// </param>
			/// <param name="pUnkOuter">
			/// If the object is being created as part of an aggregate, specify a pointer to the controlling IUnknown interface of the aggregate.
			/// </param>
			/// <param name="fUseDefault">
			/// If <c>TRUE</c>, use the default filter; if <c>FALSE</c>, proceed with the most appropriate filter that is available.
			/// </param>
			/// <param name="pFilterClsid">
			/// Pointer to the CLSID (CLSID_FilterRegistration) that receives the class identifier of the returned filter.
			/// </param>
			/// <param name="SearchDecSize">Not implemented.</param>
			/// <param name="pwcsSearchDesc">Not implemented.</param>
			/// <param name="ppIFilt">The address of a pointer to an implementation of an IFilter interface that <c>LoadIFilter</c> selects.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			/// <remarks>
			/// <para>A filter, also known as a filter handler, is an implementation of the IFilter interface.</para>
			/// <para>
			/// <c>ILoadFilter</c> attempts to load a filter that can process a Shell data source of the type specified in the
			/// pFilteredSources parameter through the pwcsPath parameter.If an appropriate filter for the data source is not found, and
			/// fUseDefault is <c>false</c>, this method returns null in the ppIFilt parameter. If an appropriate filter for the data source
			/// is not found, and fUseDefault is <c>true</c>, the IFilter interface on the default <c>IFilter</c> is returned in the ppIFilt parameter.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/filtereg/nf-filtereg-iloadfilter-loadifilter HRESULT LoadIFilter( LPCWSTR
			// pwcsPath, FILTERED_DATA_SOURCES *pFilteredSources, IUnknown *pUnkOuter, BOOL fUseDefault, CLSID *pFilterClsid, int
			// *SearchDecSize, WCHAR **pwcsSearchDesc, IFilter **ppIFilt );
			[PInvokeData("filtereg.h", MSDNShortId = "920c976e-4dde-4e53-85b7-7547291736a0")]
			[PreserveSig]
			new HRESULT LoadIFilter([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pwcsPath, in FILTERED_DATA_SOURCES pFilteredSources, [In, MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter,
				[In, MarshalAs(UnmanagedType.Bool)] bool fUseDefault, out Guid pFilterClsid, [Optional] IntPtr SearchDecSize, [Optional] IntPtr pwcsSearchDesc, out IFilter ppIFilt);

			/// <summary>
			/// <para>Not implemented.</para>
			/// <para>Do not use: this method is not implemented.</para>
			/// </summary>
			/// <param name="pStg"/>
			/// <param name="pUnkOuter"/>
			/// <param name="pwcsOverride"/>
			/// <param name="fUseDefault"/>
			/// <param name="pFilterClsid"/>
			/// <param name="SearchDecSize"/>
			/// <param name="pwcsSearchDesc"/>
			/// <param name="ppIFilt"/>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/filtereg/nf-filtereg-iloadfilter-loadifilterfromstorage HRESULT
			// LoadIFilterFromStorage( IStorage *pStg, IUnknown *pUnkOuter, LPCWSTR pwcsOverride, BOOL fUseDefault, CLSID *pFilterClsid, int
			// *SearchDecSize, WCHAR **pwcsSearchDesc, IFilter **ppIFilt );
			[PInvokeData("filtereg.h", MSDNShortId = "b4eff132-9022-4091-a2a3-1d8e11a35b39")]
			[Obsolete, PreserveSig]
			new HRESULT LoadIFilterFromStorage([In] IStorage pStg, [In, MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter, [In, MarshalAs(UnmanagedType.LPWStr)] string pwcsOverride,
				[In, MarshalAs(UnmanagedType.Bool)] bool fUseDefault, out Guid pFilterClsid, [Optional] IntPtr SearchDecSize, [Optional] IntPtr pwcsSearchDesc, out IFilter ppIFilt);

			/// <summary>
			/// <para>Not implemented.</para>
			/// <para>Do not use: this method is not implemented.</para>
			/// </summary>
			/// <param name="pStm"/>
			/// <param name="pFilteredSources"/>
			/// <param name="pUnkOuter"/>
			/// <param name="fUseDefault"/>
			/// <param name="pFilterClsid"/>
			/// <param name="SearchDecSize"/>
			/// <param name="pwcsSearchDesc"/>
			/// <param name="ppIFilt"/>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/filtereg/nf-filtereg-iloadfilter-loadifilterfromstream HRESULT
			// LoadIFilterFromStream( IStream *pStm, FILTERED_DATA_SOURCES *pFilteredSources, IUnknown *pUnkOuter, BOOL fUseDefault, CLSID
			// *pFilterClsid, int *SearchDecSize, WCHAR **pwcsSearchDesc, IFilter **ppIFilt );
			[PInvokeData("filtereg.h", MSDNShortId = "6a577306-d5ff-43c1-ab9f-3a7437661d2a")]
			[Obsolete, PreserveSig]
			new HRESULT LoadIFilterFromStream([In] IStream pStm, in FILTERED_DATA_SOURCES pFilteredSources, [In, MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter,
				[In, MarshalAs(UnmanagedType.Bool)] bool fUseDefault, out Guid pFilterClsid, [Optional] IntPtr SearchDecSize, [Optional] IntPtr pwcsSearchDesc, out IFilter ppIFilt);

			/// <summary>Undocumented.</summary>
			/// <param name="filteredSources"/>
			/// <param name="useDefault"/>
			/// <param name="filterClsid"/>
			/// <param name="isFilterPrivateComActivated"/>
			/// <param name="filterObj"/>
			/// <returns/>
			[PInvokeData("filtereg.h")]
			[PreserveSig]
			HRESULT LoadIFilterWithPrivateComActivation(in FILTERED_DATA_SOURCES filteredSources, [In, MarshalAs(UnmanagedType.Bool)] bool useDefault, out Guid filterClsid, [MarshalAs(UnmanagedType.Bool)] out bool isFilterPrivateComActivated, out IFilter filterObj);
		}

		/// <summary>Describes security authentication information for content access.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ns-searchapi-authentication_info typedef struct
		// _AUTHENTICATION_INFO { DWORD dwSize; AUTH_TYPE atAuthenticationType; LPCWSTR pcwszUser; LPCWSTR pcwszPassword; } AUTHENTICATION_INFO;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct AUTHENTICATION_INFO
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size of the structure, in bytes.</para>
			/// </summary>
			public uint dwSize;

			/// <summary>
			/// <para>Type: <c>AUTH_TYPE</c></para>
			/// <para>Flag to describe the type of authentication. For a list of possible values, see the AUTH_TYPE enumerated type.</para>
			/// </summary>
			public AUTH_TYPE atAuthenticationType;

			/// <summary>
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Pointer to a null-terminated Unicode string containing the user name.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pcwszUser;

			/// <summary>
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Pointer to a null-terminated Unicode string containing the password for <c>pcwszUser</c>.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pcwszPassword;
		}

		/// <summary>Specifies parameters for a Shell data source for which a filter is loaded.</summary>
		/// <remarks>
		/// <para>A filter, also known as a filter handler, is an implementation of the IFilter interface.</para>
		/// <para>
		/// <c>FILTERED_DATA_SOURCES</c> can hold one file content identifier of each type. CLSIDs are always searched first, followed by the
		/// file name extension, then MIME type, and finally the path.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/filtereg/ns-filtereg-_filtered_data_sources typedef struct
		// _FILTERED_DATA_SOURCES { const WCHAR *pwcsExtension; const WCHAR *pwcsMime; const CLSID *pClsid; const WCHAR *pwcsOverride; } FILTERED_DATA_SOURCES;
		[PInvokeData("filtereg.h", MSDNShortId = "5baae290-aead-4986-a7d4-0302931e0104")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILTERED_DATA_SOURCES
		{
			/// <summary>Pointer to a buffer that contains a file name extension.</summary>
			public IntPtr pwcsExtension;

			/// <summary>Pointer to a buffer that contains the name of a MIME type.</summary>
			public IntPtr pwcsMime;

			/// <summary>Pointer to a CLSID that identifies the content type.</summary>
			public IntPtr pClsid;

			/// <summary>Not implemented.</summary>
			public IntPtr pwcsOverride;
		}

		/// <summary>
		/// <para>
		/// [Indexing Service is no longer supported as of Windows XP and is unavailable for use as of Windows 8. Instead, use Windows Search
		/// for client side search and Microsoft Search Server Express for server side search.]
		/// </para>
		/// <para>Describes the position and extent of a specified portion of text within an object.</para>
		/// </summary>
		/// <remarks>
		/// The <c>cwcExtent</c> member might specify a number of characters (starting from a position the <c>cwcStart</c> member specifies)
		/// that extends beyond the end of the chunk. In that case, the region should be continued into the next chunk, which should have the
		/// same attribute as the current region.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/filter/ns-filter-tagfilterregion typedef struct tagFILTERREGION { ULONG
		// idChunk; ULONG cwcStart; ULONG cwcExtent; } FILTERREGION;
		[PInvokeData("filter.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILTERREGION
		{
			/// <summary>The chunk identifier.</summary>
			public uint idChunk;

			/// <summary>The beginning of the region, specified as an offset from the beginning of the chunk.</summary>
			public uint cwcStart;

			/// <summary>The extent of the region, specified as the number of Unicode characters.</summary>
			public uint cwcExtent;
		}

		/// <summary>
		/// <para>
		/// [Indexing Service is no longer supported as of Windows XP and is unavailable for use as of Windows 8. Instead, use Windows Search
		/// for client side search and Microsoft Search Server Express for server side search.]
		/// </para>
		/// <para>Specifies a property set and a property within the property set.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/filter/ns-filter-tagfullpropspec typedef struct tagFULLPROPSPEC { GUID
		// guidPropSet; PROPSPEC psProperty; } FULLPROPSPEC;
		[PInvokeData("filter.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FULLPROPSPEC
		{
			/// <summary>The globally unique identifier (GUID) that identifies the property set.</summary>
			public Guid guidPropSet;

			/// <summary>
			/// A pointer to the PROPSPEC structure that specifies a property either by its property identifier (propid) or by the associated
			/// string name ( <c>lpwstr</c>).
			/// </summary>
			public PROPSPEC psProperty;
		}

		/// <summary>Contains access information used by an incremental crawl, such as the last access date and modification time.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ns-searchapi-incremental_access_info typedef struct
		// _INCREMENTAL_ACCESS_INFO { DWORD dwSize; FILETIME ftLastModifiedTime; } INCREMENTAL_ACCESS_INFO;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		[StructLayout(LayoutKind.Sequential)]
		public struct INCREMENTAL_ACCESS_INFO
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size of the file in bytes.</para>
			/// </summary>
			public uint dwSize;

			/// <summary>
			/// <para>Type: <c>FILETIME</c></para>
			/// <para>Last time the file was modified.</para>
			/// </summary>
			public FILETIME ftLastModifiedTime;
		}

		/// <summary>
		/// Contains information passed to the IUrlAccessor object about the current item; for example, the application name and catalog name.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ns-searchapi-_item_info typedef struct _ITEM_INFO { DWORD dwSize;
		// LPCWSTR pcwszFromEMail; LPCWSTR pcwszApplicationName; LPCWSTR pcwszCatalogName; LPCWSTR pcwszContentClass; } ITEM_INFO;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct ITEM_INFO
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Size of the structure in bytes.</para>
			/// </summary>
			public uint dwSize;

			/// <summary>
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Pointer to a null-terminated Unicode string containing an email address that is notified in case of error.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pcwszFromEMail;

			/// <summary>
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Pointer to a null-terminated Unicode string containing the application name.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pcwszApplicationName;

			/// <summary>
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// Pointer to a null-terminated Unicode string containing the workspace name from which the crawl to this content source was initiated.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pcwszCatalogName;

			/// <summary>
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Not used by protocol handlers.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pcwszContentClass;
		}

		/// <summary>Stores information about a proxy. Used by ISearchProtocol.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ns-searchapi-proxy_info typedef struct _PROXY_INFO { DWORD dwSize;
		// LPCWSTR pcwszUserAgent; PROXY_ACCESS paUseProxy; BOOL fLocalBypass; DWORD dwPortNumber; LPCWSTR pcwszProxyName; LPCWSTR
		// pcwszBypassList; } PROXY_INFO;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct PROXY_INFO
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The size of the structure in bytes.</para>
			/// </summary>
			public uint dwSize;

			/// <summary>
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a Unicode string buffer containing the user agent string.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pcwszUserAgent;

			/// <summary>
			/// <para>Type: <c>PROXY_ACCESS</c></para>
			/// <para>The proxy type to use.</para>
			/// </summary>
			public PROXY_ACCESS paUseProxy;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>The bypass proxy for local addresses.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fLocalBypass;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The port number to use.</para>
			/// </summary>
			public uint dwPortNumber;

			/// <summary>
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a Unicode string buffer that contains the name of the proxy server.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pcwszProxyName;

			/// <summary>
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The list of sites that will bypass the proxy.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pcwszBypassList;
		}

		/// <summary>This structure is not implemented.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ns-searchapi-search_column_properties typedef struct
		// _SEARCH_COLUMN_PROPERTIES { PROPVARIANT Value; LCID lcid; } SEARCH_COLUMN_PROPERTIES;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SEARCH_COLUMN_PROPERTIES
		{
			/// <summary>
			/// <para>Type: <c>PROPVARIANT</c></para>
			/// <para>The name of the column referenced in the ISearchQueryHelper::WriteProperties methods pColumns property array.</para>
			/// </summary>
			public PROPVARIANT Value;

			/// <summary>
			/// <para>Type: <c>LCID</c></para>
			/// <para>The LCID of the column.</para>
			/// </summary>
			public uint lcid;
		}

		/// <summary>Specifies the changes to an indexed item.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ns-searchapi-_search_item_change typedef struct _SEARCH_ITEM_CHANGE
		// { SEARCH_KIND_OF_CHANGE Change; SEARCH_NOTIFICATION_PRIORITY Priority; BLOB *pUserData; LPWSTR lpwszURL; LPWSTR lpwszOldURL; } SEARCH_ITEM_CHANGE;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct SEARCH_ITEM_CHANGE
		{
			/// <summary>
			/// <para>Type: <c>SEARCH_KIND_OF_CHANGE</c></para>
			/// <para>Flag that specifies the kind of change as a value from the SEARCH_KIND_OF_CHANGE enumerated type.</para>
			/// </summary>
			public SEARCH_KIND_OF_CHANGE Change;

			/// <summary>
			/// <para>Type: <c>SEARCH_NOTIFICATION_PRIORITY</c></para>
			/// <para>
			/// Flag that specifies the priority of processing this change as a value from the SEARCH_NOTIFICATION_PRIORITY enumerated type.
			/// </para>
			/// </summary>
			public SEARCH_NOTIFICATION_PRIORITY Priority;

			/// <summary>
			/// <para>Type: <c>BLOB*</c></para>
			/// <para>Pointer to user information.</para>
			/// </summary>
			public IntPtr pUserData;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// Pointer to a null-terminated Unicode string containing the URL of the item in a SEARCH_CHANGE_MOVE_RENAME, SEARCH_CHANGE_ADD,
			/// or SEARCH_CHANGE_MODIFY notification. In the case of a move, this member contains the new URL of the item.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string lpwszURL;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// Pointer to a null-terminated Unicode string containing the old URL of the item in a SEARCH_CHANGE_MOVE_RENAME or
			/// SEARCH_CHANGE_DELETE notification.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string lpwszOldURL;
		}

		/// <summary>Describes the status of a document to be indexed.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ns-searchapi-search_item_indexing_status typedef struct
		// _SEARCH_ITEM_INDEXING_STATUS { DWORD dwDocID; HRESULT hrIndexingStatus; } SEARCH_ITEM_INDEXING_STATUS;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SEARCH_ITEM_INDEXING_STATUS
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Document identifier.</para>
			/// </summary>
			public uint dwDocID;

			/// <summary>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>
			/// An <c>HRESULT</c> value that corresponds to a system error code or a Component Object Model (COM) error code. S_OK if
			/// successful, or an error value otherwise.
			/// </para>
			/// </summary>
			public HRESULT hrIndexingStatus;
		}

		/// <summary>
		/// Contains information about the kind of change that has occurred in an item to be indexed. This structure is used with the
		/// ISearchPersistentItemsChangedSink::OnItemsChanged method to pass information to the indexer about what has changed.
		/// </summary>
		/// <remarks>SEARCH_CHANGE_MOVE_RENAME is not supported for use with ISearchPersistentItemsChangedSink::OnItemsChanged.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ns-searchapi-_search_item_persistent_change typedef struct
		// _SEARCH_ITEM_PERSISTENT_CHANGE { SEARCH_KIND_OF_CHANGE Change; LPWSTR URL; LPWSTR OldURL; SEARCH_NOTIFICATION_PRIORITY Priority; } SEARCH_ITEM_PERSISTENT_CHANGE;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct SEARCH_ITEM_PERSISTENT_CHANGE
		{
			/// <summary>
			/// <para>Type: <c>SEARCH_KIND_OF_CHANGE</c></para>
			/// <para>A value from the SEARCH_KIND_OF_CHANGE enumerated type that indicates the kind of change.</para>
			/// </summary>
			public SEARCH_KIND_OF_CHANGE Change;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// Pointer to a null-terminated Unicode string containing the URL of the item in a SEARCH_CHANGE_ADD, SEARCH_CHANGE_MODIFY, or
			/// SEARCH_CHANGE_DELETE notification. In the case of a move, this member contains the new URL of the item.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string URL;

			/// <summary>The old URL</summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string OldURL;

			/// <summary>
			/// <para>Type: <c>SEARCH_NOTIFICATION_PRIORITY</c></para>
			/// <para>A value from the SEARCH_NOTIFICATION_PRIORITY enumerated type that indicates the priority of the change.</para>
			/// </summary>
			public SEARCH_NOTIFICATION_PRIORITY Priority;
		}

		/// <summary>
		/// <para>
		/// [Indexing Service is no longer supported as of Windows XP and is unavailable for use as of Windows 8. Instead, use Windows Search
		/// for client side search and Microsoft Search Server Express for server side search.]
		/// </para>
		/// <para>Describes the characteristics of a chunk.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The final three members ( <c>idChunkSource</c>, <c>cwcStartSource</c>, and <c>cwcLenSource</c>) are used to describe the source
		/// of a derived chunk; that is, one that can be mapped back to a section of text. For example, the heading of a chapter can be both
		/// a text-type property and an internal value-type property ? a heading. The value-type property "heading" would be a derived chunk.
		/// If the text of the current value-type chunk (from an internal value-type property) is derived from some text-type chunk, then it
		/// must be emitted more than once.
		/// </para>
		/// <para>The following segment is an example of how this might happen in a book.</para>
		/// <para>The small detective exclaimed, "C'est fini!"</para>
		/// <para><c>Confessions</c></para>
		/// <para>The room was silent for several minutes. After thinking very hard about it, the young woman asked, "But how did you know?"</para>
		/// <para>This segment might be broken into chunks in the following way.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>ID</term>
		/// <term>Text</term>
		/// <term>BreakType</term>
		/// <term>Flags</term>
		/// <term>Locale</term>
		/// <term>Attribute</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>The small dete</term>
		/// <term>N/A</term>
		/// <term>CHUNK_TEXT</term>
		/// <term>ENGLISH_UK</term>
		/// <term>CONTENT</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>ctive exclaimed,</term>
		/// <term>CHUNK_NO_BREAK</term>
		/// <term>N/A</term>
		/// <term>N/A</term>
		/// <term>N/A</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>"C'est fini!"</term>
		/// <term>CHUNK_EOW</term>
		/// <term>CHUNK_TEXT</term>
		/// <term>FRENCH_BELGIAN</term>
		/// <term>CONTENT</term>
		/// </item>
		/// <item>
		/// <term>4</term>
		/// <term>Confessions</term>
		/// <term>CHUNK_EOC</term>
		/// <term>CHUNK_TEXT</term>
		/// <term>ENGLISH_UK</term>
		/// <term>CHAPTER_NAMES</term>
		/// </item>
		/// <item>
		/// <term>5</term>
		/// <term>Confessions</term>
		/// <term>CHUNK_EOP</term>
		/// <term>CHUNK_TEXT</term>
		/// <term>ENGLISH_UK</term>
		/// <term>CONTENT</term>
		/// </item>
		/// <item>
		/// <term>6</term>
		/// <term>The room was silent for several minutes.</term>
		/// <term>CHUNK_EOP</term>
		/// <term>CHUNK_TEXT</term>
		/// <term>ENGLISH_UK</term>
		/// <term>CONTENT</term>
		/// </item>
		/// <item>
		/// <term>7</term>
		/// <term>After thinking very hard about it, the young woman asked, "But how did you know?"</term>
		/// <term>CHUNK_EOS</term>
		/// <term>CHUNK_TEXT</term>
		/// <term>ENGLISH_UK</term>
		/// <term>CONTENT</term>
		/// </item>
		/// </list>
		/// <para>
		/// Information provided by <c>idChunkSource</c>, <c>cwcStartSource</c>, and <c>cwcLenSource</c> is useful for a search engine that
		/// highlights hits. If the query is done for an internal value-type property, the search engine will highlight the original text
		/// from which the text of the internal value-type property has been derived. For instance, in a C++ code filter, the browser, when
		/// searching for MyFunction in internal value-type property "function definitions," will highlight the function header in the file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/filter/ns-filter-tagstat_chunk typedef struct tagSTAT_CHUNK { ULONG idChunk;
		// CHUNK_BREAKTYPE breakType; CHUNKSTATE flags; LCID locale; FULLPROPSPEC attribute; ULONG idChunkSource; ULONG cwcStartSource; ULONG
		// cwcLenSource; } STAT_CHUNK;
		[PInvokeData("filter.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct STAT_CHUNK
		{
			/// <summary>
			/// The chunk identifier. Chunk identifiers must be unique for the current instance of the IFilter interface. Chunk identifiers
			/// must be in ascending order. The order in which chunks are numbered should correspond to the order in which they appear in the
			/// source document. Some search engines can take advantage of the proximity of chunks of various properties. If so, the order in
			/// which chunks with different properties are emitted will be important to the search engine.
			/// </summary>
			public uint idChunk;

			/// <summary>
			/// The type of break that separates the previous chunk from the current chunk. Values are from the CHUNK_BREAKTYPE enumeration.
			/// </summary>
			public CHUNK_BREAKTYPE breakType;

			/// <summary>
			/// Indicates whether this chunk contains a text-type or a value-type property. Flag values are taken from the CHUNKSTATE
			/// enumeration. If the CHUNK_TEXT flag is set, IFilter::GetText should be used to retrieve the contents of the chunk as a series
			/// of words. If the CHUNK_VALUE flag is set, IFilter::GetValue should be used to retrieve the value and treat it as a single
			/// property value. If the filter dictates that the same content be treated as both text and as a value, the chunk should be
			/// emitted twice in two different chunks, each with one flag set.
			/// </summary>
			public CHUNKSTATE flags;

			/// <summary>
			/// The language and sublanguage associated with a chunk of text. Chunk locale is used by document indexers to perform proper
			/// word breaking of text. If the chunk is neither text-type nor a value-type with data type VT_LPWSTR, VT_LPSTR or VT_BSTR, this
			/// field is ignored.
			/// </summary>
			public uint locale;

			/// <summary>
			/// The property to be applied to the chunk. See FULLPROPSPEC. If a filter requires that the same text have more than one
			/// property, it needs to emit the text once for each property in separate chunks.
			/// </summary>
			public FULLPROPSPEC attribute;

			/// <summary>The ID of the source of a chunk. The value of the <c>idChunkSource</c> member depends on the nature of the chunk:</summary>
			public uint idChunkSource;

			/// <summary>The offset from which the source text for a derived chunk starts in the source chunk.</summary>
			public uint cwcStartSource;

			/// <summary>
			/// The length in characters of the source text from which the current chunk was derived. A zero value signifies
			/// character-by-character correspondence between the source text and the derived text. A nonzero value means that no such direct
			/// correspondence exists.
			/// </summary>
			public uint cwcLenSource;
		}

		/// <summary>Stores time-out values for connections and data.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/searchapi/ns-searchapi-_timeout_info typedef struct _TIMEOUT_INFO { DWORD
		// dwSize; DWORD dwConnectTimeout; DWORD dwDataTimeout; } TIMEOUT_INFO;
		[PInvokeData("searchapi.h", MSDNShortId = "")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct TIMEOUT_INFO
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The size of the structure, in bytes.</para>
			/// </summary>
			public uint dwSize;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The time-out value for a connection, in seconds.</para>
			/// </summary>
			public uint dwConnectTimeout;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The time-out value for data, in seconds.</para>
			/// </summary>
			public uint dwDataTimeout;
		}

		[ComImport, ClassInterface(ClassInterfaceType.None), Guid("7D096C5F-AC08-4F1F-BEB7-5C22C517CE39")]
		public class CSearchManager { }

		[ComImport, ClassInterface(ClassInterfaceType.None), Guid("30766BD2-EA1C-4F28-BF27-0B44E2F68DB7")]
		public class CSearchRoot { }

		[ComImport, ClassInterface(ClassInterfaceType.None), Guid("E63DE750-3BD7-4BE5-9C84-6B4281988C44")]
		public class CSearchScopeRule { }

		[ComImport, ClassInterface(ClassInterfaceType.None), Guid("9E175B8D-F52A-11D8-B9A5-505054503030")]
		public class FilterRegistration { }
	}
}