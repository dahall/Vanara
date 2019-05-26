using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;

namespace Vanara.PInvoke
{
	public static partial class SearchApi
	{
		/// <summary><para>Provides a set of flags to be used with the following interfaces to indicate the type of condition tree node: ICondition, ICondition2, IConditionFactory, IConditionFactory2, and IConditionGenerator.</para></summary><remarks><para>&gt;Only one of following flags should be set simultaneously:</para><list type="bullet"><item><term>CONDITION_CREATION_VECTOR_AND</term></item><item><term>CONDITION_CREATION_VECTOR_OR</term></item><item><term>CONDITION_CREATION_VECTOR_LEAF</term></item></list><para>However, if none of these flags is set, then attempting to create a leaf condition with VT_VECTOR set in the PROPVARIANT results in failure.</para></remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/ne-structuredquery-condition_creation_options
		// typedef enum CONDITION_CREATION_OPTIONS { CONDITION_CREATION_DEFAULT, CONDITION_CREATION_NONE, CONDITION_CREATION_SIMPLIFY, CONDITION_CREATION_VECTOR_AND, CONDITION_CREATION_VECTOR_OR, CONDITION_CREATION_VECTOR_LEAF, CONDITION_CREATION_USE_CONTENT_LOCALE } ;
		[PInvokeData("structuredquery.h")]
		[Flags]
		public enum CONDITION_CREATION_OPTIONS
		{
			/// <summary>Indicates that the condition is set to the default value.</summary>
			CONDITION_CREATION_DEFAULT = 0,
			/// <summary>Indicates that the condition is set to NULL.</summary>
			CONDITION_CREATION_NONE = 0,
			/// <summary>Indicates that you should simplify the returned condition as much as possible. In some cases this flag indicates that the returned condition is not newly created but refers to an existing object.</summary>
			CONDITION_CREATION_SIMPLIFY = 0x01,
			/// <summary>Indicates that you should create an AND condition of leaves with vector elements as values, instead of attempting to create a leaf condition with VT_VECTOR set in the PROPVARIANT.</summary>
			CONDITION_CREATION_VECTOR_AND = 0x02,
			/// <summary>Indicates that you should create an OR condition of leaves with vector elements as values, instead of attempting to create a leaf condition with VT_VECTOR set in the PROPVARIANT.</summary>
			CONDITION_CREATION_VECTOR_OR = 0x04,
			/// <summary>Indicates that you should allow the creation of a leaf condition with VT_VECTOR set in the PROPVARIANT.</summary>
			CONDITION_CREATION_VECTOR_LEAF = 0x08,
			/// <summary>Indicates that you should ignore any specified locale and use the currently selected content locale IConditionFactory2::CreateStringLeaf and IConditionFactory2::CreateLeaf.</summary>
			CONDITION_CREATION_USE_CONTENT_LOCALE = 0x10,
		}

		/// <summary>
		/// Used by IQueryParserManager::SetOption to set parsing options. This can be used to specify schemas and localization options.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/ne-structuredquery-query_parser_manager_option typedef enum
		// tagQUERY_PARSER_MANAGER_OPTION { QPMO_SCHEMA_BINARY_NAME, QPMO_PRELOCALIZED_SCHEMA_BINARY_PATH,
		// QPMO_UNLOCALIZED_SCHEMA_BINARY_PATH, QPMO_LOCALIZED_SCHEMA_BINARY_PATH, QPMO_APPEND_LCID_TO_LOCALIZED_PATH, QPMO_LOCALIZER_SUPPORT
		// } QUERY_PARSER_MANAGER_OPTION;
		[PInvokeData("structuredquery.h")]
		public enum QUERY_PARSER_MANAGER_OPTION
		{
			/// <summary>
			/// A VT_LPWSTR containing the name of the file that contains the schema binary. The default value is StructuredQuerySchema.bin
			/// for the SystemIndex catalog and StructuredQuerySchemaTrivial.bin for the trivial catalog.
			/// </summary>
			QPMO_SCHEMA_BINARY_NAME,

			/// <summary>
			/// Either a VT_BOOL or a VT_LPWSTR. If the value is a VT_BOOL and is FALSE, a pre-localized schema will not be used. If the
			/// value is a VT_BOOL and is TRUE, IQueryParserManager will use the pre-localized schema binary in "". If the value is a
			/// VT_LPWSTR, the value should contain the full path of the folder in which the pre-localized schema binary can be found. The
			/// default value is VT_BOOL with TRUE.
			/// </summary>
			QPMO_PRELOCALIZED_SCHEMA_BINARY_PATH,

			/// <summary>
			/// A VT_LPWSTR containing the full path to the folder that contains the unlocalized schema binary. The default value is "".
			/// </summary>
			QPMO_UNLOCALIZED_SCHEMA_BINARY_PATH,

			/// <summary>
			/// A VT_LPWSTR containing the full path to the folder that contains the localized schema binary that can be read and written to
			/// as needed. The default value is "".
			/// </summary>
			QPMO_LOCALIZED_SCHEMA_BINARY_PATH,

			/// <summary>
			/// A VT_BOOL. If TRUE, then the paths for pre-localized and localized binaries have "" appended to them, where LCID is the
			/// decimal locale ID for the localized language. The default is TRUE.
			/// </summary>
			QPMO_APPEND_LCID_TO_LOCALIZED_PATH,

			/// <summary>
			/// A VT_UNKNOWN with an object supporting ISchemaLocalizerSupport. This object will be used instead of the default localizer
			/// support object.
			/// </summary>
			QPMO_LOCALIZER_SUPPORT,
		}

		/// <summary>
		/// <para>A set of flags used by IQueryParser::SetMultiOption to indicate individual options.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/ne-structuredquery-structured_query_multioption typedef enum
		// tagSTRUCTURED_QUERY_MULTIOPTION { SQMO_VIRTUAL_PROPERTY, SQMO_DEFAULT_PROPERTY, SQMO_GENERATOR_FOR_TYPE, SQMO_MAP_PROPERTY } STRUCTURED_QUERY_MULTIOPTION;
		[PInvokeData("structuredquery.h")]
		public enum STRUCTURED_QUERY_MULTIOPTION
		{
			/// <summary>
			/// To indicate that a leaf node with property name P and constant C should be replaced with a leaf node with property name Q,
			/// operation op, and constant C by IConditionFactory::Resolve, do the following: call IQueryParser::SetMultiOption with
			/// SQMO_VIRTUAL_PROPERTY as option, P as pszOptionKey, and for pOptionValue provide a VT_UNKNOWN with an IEnumVARIANT interface
			/// that enumerates exactly two values: a VT_BSTR with value Q, and a VT_I4 that is a CONDITION_OPERATION operation.
			/// </summary>
			SQMO_VIRTUAL_PROPERTY,

			/// <summary>
			/// To indicate that a leaf node with no property name and a semantic type T (or one that is a subtype of T) should be replaced
			/// with one having property name P by IConditionFactory::Resolve, do the following: call IQueryParser::SetMultiOption with
			/// SQMO_DEFAULT_PROPERTY as option, T as pszOptionKey, and for pOptionValue provide a VT_LPWSTR with value P.
			/// </summary>
			SQMO_DEFAULT_PROPERTY,

			/// <summary>
			/// To indicate that an IConditionGenerator G should be used to recognize named entities of the semantic type named T, and that
			/// IConditionFactory::Resolve should generate condition trees for those named entities, call IQueryParser::SetMultiOption with
			/// SQMO_GENERATOR_FOR_TYPE as option, T as pszOptionKey and for pOptionValue provide a VT_UNKNOWN with value G.
			/// </summary>
			SQMO_GENERATOR_FOR_TYPE,

			/// <summary>
			/// Windows 7, and later. To indicate that a node with property P should map to one or more other properties, call
			/// IQueryParser::SetMultiOption with SQMO_MAP_PROPERTY as option, P as pszOptionKey, and for pOptionValue provide a VT_VECTOR or
			/// VT_LPWSTR, where each string is a property name. During resolution, this map is added to those of the loaded schema. Calling
			/// IQueryParser::SetMultiOption with pOptionValue as VT_NULL removes the mapping.
			/// </summary>
			SQMO_MAP_PROPERTY,
		}

		/// <summary>Options for resolving data into a condition tree.</summary>
		/// <remarks>The <c>STRUCTURED_QUERY_RESOLVE_OPTION</c> type is defined in StructuredQuery.h as shown here.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/ne-structuredquery-structured_query_resolve_option typedef
		// enum STRUCTURED_QUERY_RESOLVE_OPTION { SQRO_DEFAULT, SQRO_DONT_RESOLVE_DATETIME, SQRO_ALWAYS_ONE_INTERVAL,
		// SQRO_DONT_SIMPLIFY_CONDITION_TREES, SQRO_DONT_MAP_RELATIONS, SQRO_DONT_RESOLVE_RANGES, SQRO_DONT_REMOVE_UNRESTRICTED_KEYWORDS,
		// SQRO_DONT_SPLIT_WORDS, SQRO_IGNORE_PHRASE_ORDER, SQRO_ADD_VALUE_TYPE_FOR_PLAIN_VALUES, SQRO_ADD_ROBUST_ITEM_NAME } ;
		[PInvokeData("structuredquery.h")]
		[Flags]
		public enum STRUCTURED_QUERY_RESOLVE_OPTION
		{
			/// <summary>Windows 7 and later. The default flag.</summary>
			SQRO_DEFAULT = 0x00000000,

			/// <summary>
			/// Unless this flag is set, any relative date/time expression in pConditionTree is replaced with an absolute date/time range
			/// that has been resolved against the reference date/time pointed to by pstReferenceTime. For example, if an AQS query contained
			/// the relative date/time expression "date:this month" and the reference date/time was 9/19/2006 10:28:33, the resolved
			/// condition tree would contain a date/time range beginning at 9/1/2006 00:00:00 and ending at 10/1/2006 00:00:00 (in the UTC
			/// time zone).
			/// </summary>
			SQRO_DONT_RESOLVE_DATETIME = 0x00000001,

			/// <summary>
			/// Unless this flag is set, resolving a relative date/time expression may result in an OR of several intervals. For example, if
			/// an AQS query contained "date:Monday" and the reference date/time was 9/19/2006 10:28:33 (a Tuesday), the resolved condition
			/// tree would contain an OR of three 24 hour ranges corresponding to the Mondays of 9/11/2006, 9/18/2006 and 9/25/2006, because
			/// it is not clear which Monday was referenced. If this flag is set, the result will always be a single date/time range (for
			/// this example, it would be a date/time range beginning at 9/18/2006 00:00:00 and ending at 9/19/2006 00:00:00).
			/// </summary>
			SQRO_ALWAYS_ONE_INTERVAL = 0x00000002,

			/// <summary>Unless this flag is set, the resulting condition tree will have any possible simplifications applied to it.</summary>
			SQRO_DONT_SIMPLIFY_CONDITION_TREES = 0x00000004,

			/// <summary>
			/// Unless this flag is true, a leaf node with a virtual property that maps to several properties will be replaced by an OR of
			/// leaf nodes containing the actual properties. For example, the AQS query "to:Bill" may result in a leaf node where the
			/// property named actually maps to the two properties and , so the resolved condition tree would have an OR that looks for
			/// "Bill" in those two properties.
			/// </summary>
			SQRO_DONT_MAP_RELATIONS = 0x00000008,

			/// <summary>
			/// A range resulting from a date/time expression, an expression such as "20..40", is first resolved to a leaf node that has a
			/// VT_UNKNOWN value where the punkVal member implements the IInterval interface. Unless this flag is set, the returned condition
			/// tree will have been further resolved to an AND of simple comparisons such as COP_GREATERTHANOREQUAL and COP_LESSTHAN. For
			/// example, for an AQS query "date:this month" resolved against 9/19/2006 10:28:33, if this flag is not set, the resulting
			/// condition tree is an AND of System.ItemDate COP_GREATERTHANOREQUAL 9/1/2006 00:00:00 and System.ItemDate COP_LESSTHAN
			/// 10/1/2006 00:00:00. If this flag is set, the resulting condition tree will relate System.ItemDate to an IInterval such that
			/// its IInterval::GetLimits method returns ILK_EXPLICIT_INCLUDED, 9/1/2006 00:00:00, ILK_EXPLICIT_EXCLUDED and 10/1/2006 00:00:00.
			/// </summary>
			SQRO_DONT_RESOLVE_RANGES = 0x00000010,

			/// <summary>
			/// An unrestricted keyword is a keyword that is not associated with a value that completes the condition. For example, in the
			/// following AQS query, the property denoted by "From" is considered an unrestricted keyword: "Kind:email Subject:"My Resume"
			/// From:". If this flag is set, such a property will be present in the resulting condition tree as a leaf node having a
			/// COP_IMPLICIT operation, an empty string value, and a semantic type of System.StructuredQueryType.Value. Otherwise, it will be
			/// removed entirely.
			/// </summary>
			SQRO_DONT_REMOVE_UNRESTRICTED_KEYWORDS = 0x00000020,

			/// <summary>
			/// If this flag is set, a group of words not separated by white space will be kept together in a single leaf node. If this flag
			/// is not set, the group will be broken up into separate leaf nodes. An application may want to set this flag when resolving a
			/// condition tree if the resulting tree will be further processed by code that should do any additional word breaking.
			/// </summary>
			SQRO_DONT_SPLIT_WORDS = 0x00000040,

			/// <summary>
			/// If a phrase in an AQS query is enclosed in double quotes, the words in that phrase go into a single leaf node (regardless of
			/// whether SQRO_DONT_SPLIT_WORDS is set) unless this flag is set, in which case they end up in separate leaf nodes and their
			/// order no longer matters. An application can set this flag if it is not able to handle leaf nodes with multiple words correctly.
			/// </summary>
			SQRO_IGNORE_PHRASE_ORDER = 0x00000080,

			/// <summary/>
			SQRO_ADD_VALUE_TYPE_FOR_PLAIN_VALUES = 0x00001000,

			/// <summary>Work around known issues in word breakers, adding conditions on PKEY_ItemNameDisplay as needed.</summary>
			SQRO_ADD_ROBUST_ITEM_NAME = 0x00000200,
		}

		/// <summary>
		/// <para>A set of flags to be used with IQueryParser::SetOption and IQueryParser::GetOption to indicate individual options.</para>
		/// </summary>
		/// <remarks>
		/// <para>Windows 7 adds new constants that help refine query condition trees parsed by the IQueryParser interface.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/ne-structuredquery-structured_query_single_option typedef
		// enum tagSTRUCTURED_QUERY_SINGLE_OPTION { SQSO_SCHEMA, SQSO_LOCALE_WORD_BREAKING, SQSO_WORD_BREAKER, SQSO_NATURAL_SYNTAX,
		// SQSO_AUTOMATIC_WILDCARD, SQSO_TRACE_LEVEL, SQSO_LANGUAGE_KEYWORDS, SQSO_SYNTAX, SQSO_TIME_ZONE, SQSO_IMPLICIT_CONNECTOR,
		// SQSO_CONNECTOR_CASE } STRUCTURED_QUERY_SINGLE_OPTION;
		[PInvokeData("structuredquery.h")]
		public enum STRUCTURED_QUERY_SINGLE_OPTION
		{
			/// <summary>
			/// The option value should be a VT_LPWSTR that is the path to a file containing a schema binary. It is set automatically when
			/// obtaining a query parser through IQueryParserManager::CreateLoadedParser.
			/// </summary>
			SQSO_SCHEMA,

			/// <summary>
			/// The option value must be VT_EMPTY to use the default word breaker (current keyboard locale) or a VT_UI4 that is a valid LCID.
			/// The LCID indicates the expected locale of content words in queries to be parsed and is used to choose a suitable word breaker
			/// for the query. IQueryParser::Parse will return an error unless you set either this option or SQSO_WORD_BREAKER before calling it.
			/// </summary>
			SQSO_LOCALE_WORD_BREAKING,

			/// <summary>
			/// When setting this option, the value should be a VT_EMPTY for using the default word breaker for the chosen locale, or a
			/// VT_UNKNOWN with an object supporting the IWordBreaker interface. Retrieving the option always returns a VT_UNKNOWN with an
			/// object supporting the IWordBreaker interface, unless there is no suitable word breaker for the chosen locale, in which case
			/// VT_EMPTY is returned.
			/// </summary>
			SQSO_WORD_BREAKER,

			/// <summary>
			/// The option value should be a VT_EMPTY or a VT_BOOL with VARIANT_TRUE to allow both natural query syntax and advanced query
			/// syntax (the default) or a VT_BOOL with VARIANT_FALSE to allow only advanced query syntax. Retrieving the option always
			/// returns a VT_BOOL.
			/// </summary>
			SQSO_NATURAL_SYNTAX,

			/// <summary>
			/// The option value should be a VT_BOOL with VARIANT_TRUE to generate query expressions as if each word in the query had the
			/// wildcard character * appended to it (unless followed by punctuation other than a parenthesis), a VT_BOOL with VARIANT_FALSE
			/// to use the words as they are (the default), or a VT_EMPTY. In most cases, a word-wheeling application should set this option
			/// to VARIANT_TRUE. Retrieving the option always returns a VT_BOOL.
			/// </summary>
			SQSO_AUTOMATIC_WILDCARD,

			/// <summary>Reserved. The value should be VT_EMPTY (the default) or a VT_I4. Retrieving the option always returns a VT_I4.</summary>
			SQSO_TRACE_LEVEL,

			/// <summary>
			/// The option value must be a VT_I4 that is a valid LANGID. The LANGID indicates the expected language of Structured Query
			/// keywords in queries to be parsed. It is set automatically when obtaining a query parser through IQueryParserManager::CreateLoadedParser.
			/// </summary>
			SQSO_LANGUAGE_KEYWORDS,

			/// <summary>Windows 7 and later. The option value must be a VT_UI4 that is a SEARCH_QUERY_SYNTAX value. The default is SQS_NATURAL_QUERY_SYNTAX.</summary>
			SQSO_SYNTAX,

			/// <summary>
			/// Windows 7 and later. The value must be a VT_BLOB that is a copy of a TIME_ZONE_INFORMATION structure. The default is the
			/// current time zone.
			/// </summary>
			SQSO_TIME_ZONE,

			/// <summary>
			/// Windows 7 and later. This setting decides what connector should be assumed between conditions when none is specified. The
			/// value must be a VT_UI4 that is a CONDITION_TYPE. Only CT_AND_CONDITION and CT_OR_CONDITION are valid. It defaults to CT_AND_CONDITION.
			/// </summary>
			SQSO_IMPLICIT_CONNECTOR,

			/// <summary>
			/// Windows 7 and later. This setting decides whether there are special requirements on the case of connector keywords (such as
			/// AND or OR). The value must be a VT_UI4 that is a CASE_REQUIREMENT value. It defaults to CASE_REQUIREMENT_UPPER_IF_AQS.
			/// </summary>
			SQSO_CONNECTOR_CASE,
		}

		/// <summary>Provides methods for creating or resolving a condition tree that was obtained by parsing a query string.</summary>
		/// <remarks>
		/// The StructuredQuerySample code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to read lines from the
		/// console, parse them using the system schema, and display the resulting condition trees.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nn-structuredquery-iconditionfactory
		[PInvokeData("structuredquery.h")]
		[ComImport, Guid("A5EFE073-B16F-474f-9F3E-9F8B497A3E08"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(ConditionFactory))]
		public interface IConditionFactory
		{
			/// <summary>Creates a condition node that is a logical negation (NOT) of another condition (a subnode of this node).</summary>
			/// <param name="pcSub">
			/// <para>Type: <c>ICondition*</c></para>
			/// <para>Pointer to the ICondition subnode to be negated.</para>
			/// </param>
			/// <param name="fSimplify">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// <c>TRUE</c> to logically simplify the result if possible; <c>FALSE</c> otherwise. In a query builder scenario, fSimplify
			/// should typically be set to VARIANT_FALSE.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ICondition**</c></para>
			/// <para>Receives a pointer to the new ICondition node.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Logically simplifying a condition node usually results in a smaller, more easily traversed and processed condition tree. For
			/// example, if pcSub is itself a negation condition with a subcondition C, then the double negation is logically resolved, and
			/// ppcResult is set to C. Without simplification, the resulting tree would look like NOT — NOT — C.
			/// </para>
			/// <para>
			/// Applications that need to execute queries based on the condition tree would typically benefit from setting this parameter to <c>TRUE</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory-makenot HRESULT
			// MakeNot( ICondition *pcSub, BOOL fSimplify, ICondition **ppcResult );
			ICondition MakeNot([In] ICondition pcSub, [In, MarshalAs(UnmanagedType.Bool)] bool fSimplify);

			/// <summary>Creates a condition node that is a logical conjunction (AND) or disjunction (OR) of a collection of subconditions.</summary>
			/// <param name="ct">
			/// <para>Type: <c>CONDITION_TYPE</c></para>
			/// <para>The CONDITION_TYPE of the condition node. The <c>CONDITION_TYPE</c> must be either <c>CT_AND_CONDITION</c> or <c>CT_OR_CONDITION</c>.</para>
			/// </param>
			/// <param name="peuSubs">
			/// <para>Type: <c>IEnumUnknown*</c></para>
			/// <para>A pointer to an enumeration of ICondition objects, or <c>NULL</c> for an empty enumeration.</para>
			/// </param>
			/// <param name="fSimplify">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// <c>TRUE</c> to logically simplify the result, if possible; then the result will not necessarily to be of the specified kind.
			/// <c>FALSE</c> if the result should have exactly the prescribed structure.
			/// </para>
			/// <para>
			/// An application that plans to execute a query based on the condition tree would typically benefit from setting this parameter
			/// to <c>TRUE</c>.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ICondition**</c></para>
			/// <para>Receives the address of a pointer to the new ICondition node.</para>
			/// </returns>
			/// <remarks>
			/// There are no special condition trees for <c>TRUE</c> and <c>FALSE</c>. However, a condition tree consisting of an AND node
			/// with no subconditions is always <c>TRUE</c>, and a condition tree consisting of an OR node with no subconditions is always <c>FALSE</c>.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory-makeandor HRESULT
			// MakeAndOr( CONDITION_TYPE ct, IEnumUnknown *peuSubs, BOOL fSimplify, ICondition **ppcResult );
			ICondition MakeAndOr([In] CONDITION_TYPE ct, [In] IEnumUnknown peuSubs, [In, MarshalAs(UnmanagedType.Bool)] bool fSimplify);

			/// <summary>Creates a leaf condition node that represents a comparison of property value and constant value.</summary>
			/// <param name="pszPropertyName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// The name of a property to be compared, or <c>NULL</c> for an unspecified property. The locale name of the leaf node is LOCALE_NAME_USER_DEFAULT.
			/// </para>
			/// </param>
			/// <param name="cop">
			/// <para>Type: <c>CONDITION_OPERATION</c></para>
			/// <para>A CONDITION_OPERATION enumeration.</para>
			/// </param>
			/// <param name="pszValueType">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The name of a semantic type of the value, or <c>NULL</c> for a plain string.</para>
			/// </param>
			/// <param name="ppropvar">
			/// <para>Type: <c>PROPVARIANT const*</c></para>
			/// <para>The constant value against which the property value should be compared.</para>
			/// </param>
			/// <param name="richChunk1">The rich chunk1.</param>
			/// <param name="richChunk2">The rich chunk2.</param>
			/// <param name="richChunk3">The rich chunk3.</param>
			/// <param name="fExpand">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// If <c>TRUE</c> and pszPropertyName identifies a virtual property, the resulting node is not a leaf node; instead, it is a
			/// disjunction of leaf condition nodes, each of which corresponds to one expansion of the virtual property.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ICondition**</c></para>
			/// <para>Receives a pointer to the new ICondition leaf node.</para>
			/// </returns>
			/// <remarks>
			/// <para>For more information about leaf node terms (property, value, and operation), see ICondition::GetInputTerms.</para>
			/// <para>
			/// A virtual property has one or more metadata items in which the key is "MapsToRelation" and the value is a property name
			/// (which is one expansion of the property). For more information about metadata, see MetaData.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory-makeleaf HRESULT
			// MakeLeaf( LPCWSTR pszPropertyName, CONDITION_OPERATION cop, LPCWSTR pszValueType, const PROPVARIANT *ppropvar, IRichChunk
			// *pPropertyNameTerm, IRichChunk *pOperationTerm, IRichChunk *pValueTerm, BOOL fExpand, ICondition **ppcResult );
			ICondition MakeLeaf([In, MarshalAs(UnmanagedType.LPWStr)] string pszPropertyName, [In] CONDITION_OPERATION cop, [In, MarshalAs(UnmanagedType.LPWStr)] string pszValueType,
				[In] PROPVARIANT ppropvar, IRichChunk richChunk1, IRichChunk richChunk2, IRichChunk richChunk3, [In, MarshalAs(UnmanagedType.Bool)] bool fExpand);

			/// <summary>
			/// Performs a variety of transformations on a condition tree, including the following: resolves conditions with relative
			/// date/time expressions to conditions with absolute date/time (as a VT_FILETIME); turns other recognized named entities into
			/// condition trees with actual values; simplifies condition trees; replaces virtual or compound properties with OR trees of
			/// other properties; removes condition trees resulting from queries with property keywords that had no condition applied.
			/// </summary>
			/// <param name="pc">
			/// <para>Type: <c>ICondition*</c></para>
			/// <para>A pointer to an ICondition object to be resolved.</para>
			/// </param>
			/// <param name="sqro">
			/// <para>Type: <c>STRUCTURED_QUERY_RESOLVE_OPTION</c></para>
			/// <para>
			/// Specifies zero or more of the STRUCTURED_QUERY_RESOLVE_OPTION flags. For <c>Windows 7 and later</c>, the
			/// SQRO_ADD_VALUE_TYPE_FOR_PLAIN_VALUES flag is automatically added to <paramref name="sqro"/>.
			/// </para>
			/// </param>
			/// <param name="pstReferenceTime">
			/// <para>Type: <c>SYSTEMTIME const*</c></para>
			/// <para>
			/// A pointer to a <c>SYSTEMTIME</c> value to use as the reference date and time. A null pointer can be passed if <paramref
			/// name="sqro"/> is set to SQRO_DONT_RESOLVE_DATETIME.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ICondition**</c></para>
			/// <para>
			/// Receives a pointer to the new ICondition in which all time fields have been resolved to have values of type VT_FILETIME. This
			/// new condition tree is the resolved version of <paramref name="pc"/>.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// In a condition tree produced by the Parse method and returned by GetQuery, the leaves pair up properties with restrictions on
			/// these properties, and result in a condition tree that is partially finished. The <c>IConditionFactory::Resolve</c> method
			/// finishes such a condition tree by a process known as resolution. The input condition tree is not modified in any way. The
			/// output condition tree may share parts of the input condition that contained no leaf nodes with unresolved date/time values.
			/// </para>
			/// <para><c>Note</c> Resolving a leaf node often produces a non-leaf node.</para>
			/// <para>
			/// For example, Structured Query supports relative date/time expressions, which remain unresolved until they are applied to some
			/// reference time. In a leaf node with semantic type <c>System.StructuredQueryType.DateTime</c>, the value can be either a
			/// VT_FILETIME or a VT_LPWSTR. VT_FILETIME is an absolute date/time so it is already resolved. VT_LPWSTR is a string
			/// representation of a relative date/time expression. The specified reference time should be a local time, but the resolved
			/// times in the resulting query expression will be in Coordinated Universal Time (UTC).
			/// </para>
			/// <para>
			/// The StructuredQuerySample code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to read lines from
			/// the console, parse them using the system schema, and display the resulting condition trees.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory-resolve HRESULT
			// Resolve( ICondition *pc, STRUCTURED_QUERY_RESOLVE_OPTION sqro, const SYSTEMTIME *pstReferenceTime, ICondition **ppcResolved );
			ICondition Resolve([In] ICondition pc, STRUCTURED_QUERY_RESOLVE_OPTION sqro, in SYSTEMTIME pstReferenceTime);
		}

		/// <summary>
		/// Extends the functionality of IConditionFactory. <c>IConditionFactory2</c> provides methods for creating or resolving a condition tree that was obtained by parsing a query string.
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.Shell32.IConditionFactory" />
		/// <remarks>
		/// The StructuredQuerySample code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to read lines from the console, parse them using the system schema, and display the resulting condition trees.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nn-structuredquery-iconditionfactory2
		[PInvokeData("structuredquery.h")]
		[ComImport, Guid("71D222E1-432F-429e-8C13-B6DAFDE5077A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(ConditionFactory))]
		public interface IConditionFactory2 : IConditionFactory
		{
			/// <summary>Creates a condition node that is a logical negation (NOT) of another condition (a subnode of this node).</summary>
			/// <param name="pcSub">
			/// <para>Type: <c>ICondition*</c></para>
			/// <para>Pointer to the ICondition subnode to be negated.</para>
			/// </param>
			/// <param name="fSimplify">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// <c>TRUE</c> to logically simplify the result if possible; <c>FALSE</c> otherwise. In a query builder scenario, fSimplify
			/// should typically be set to VARIANT_FALSE.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ICondition**</c></para>
			/// <para>Receives a pointer to the new ICondition node.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Logically simplifying a condition node usually results in a smaller, more easily traversed and processed condition tree. For
			/// example, if pcSub is itself a negation condition with a subcondition C, then the double negation is logically resolved, and
			/// ppcResult is set to C. Without simplification, the resulting tree would look like NOT — NOT — C.
			/// </para>
			/// <para>
			/// Applications that need to execute queries based on the condition tree would typically benefit from setting this parameter to <c>TRUE</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory-makenot HRESULT
			// MakeNot( ICondition *pcSub, BOOL fSimplify, ICondition **ppcResult );
			new ICondition MakeNot([In] ICondition pcSub, [In, MarshalAs(UnmanagedType.Bool)] bool fSimplify);

			/// <summary>Creates a condition node that is a logical conjunction (AND) or disjunction (OR) of a collection of subconditions.</summary>
			/// <param name="ct">
			/// <para>Type: <c>CONDITION_TYPE</c></para>
			/// <para>The CONDITION_TYPE of the condition node. The <c>CONDITION_TYPE</c> must be either <c>CT_AND_CONDITION</c> or <c>CT_OR_CONDITION</c>.</para>
			/// </param>
			/// <param name="peuSubs">
			/// <para>Type: <c>IEnumUnknown*</c></para>
			/// <para>A pointer to an enumeration of ICondition objects, or <c>NULL</c> for an empty enumeration.</para>
			/// </param>
			/// <param name="fSimplify">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// <c>TRUE</c> to logically simplify the result, if possible; then the result will not necessarily to be of the specified kind.
			/// <c>FALSE</c> if the result should have exactly the prescribed structure.
			/// </para>
			/// <para>
			/// An application that plans to execute a query based on the condition tree would typically benefit from setting this parameter
			/// to <c>TRUE</c>.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ICondition**</c></para>
			/// <para>Receives the address of a pointer to the new ICondition node.</para>
			/// </returns>
			/// <remarks>
			/// There are no special condition trees for <c>TRUE</c> and <c>FALSE</c>. However, a condition tree consisting of an AND node
			/// with no subconditions is always <c>TRUE</c>, and a condition tree consisting of an OR node with no subconditions is always <c>FALSE</c>.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory-makeandor HRESULT
			// MakeAndOr( CONDITION_TYPE ct, IEnumUnknown *peuSubs, BOOL fSimplify, ICondition **ppcResult );
			new ICondition MakeAndOr([In] CONDITION_TYPE ct, [In] IEnumUnknown peuSubs, [In, MarshalAs(UnmanagedType.Bool)] bool fSimplify);

			/// <summary>Creates a leaf condition node that represents a comparison of property value and constant value.</summary>
			/// <param name="pszPropertyName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// The name of a property to be compared, or <c>NULL</c> for an unspecified property. The locale name of the leaf node is LOCALE_NAME_USER_DEFAULT.
			/// </para>
			/// </param>
			/// <param name="cop">
			/// <para>Type: <c>CONDITION_OPERATION</c></para>
			/// <para>A CONDITION_OPERATION enumeration.</para>
			/// </param>
			/// <param name="pszValueType">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The name of a semantic type of the value, or <c>NULL</c> for a plain string.</para>
			/// </param>
			/// <param name="ppropvar">
			/// <para>Type: <c>PROPVARIANT const*</c></para>
			/// <para>The constant value against which the property value should be compared.</para>
			/// </param>
			/// <param name="richChunk1">The rich chunk1.</param>
			/// <param name="richChunk2">The rich chunk2.</param>
			/// <param name="richChunk3">The rich chunk3.</param>
			/// <param name="fExpand">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// If <c>TRUE</c> and pszPropertyName identifies a virtual property, the resulting node is not a leaf node; instead, it is a
			/// disjunction of leaf condition nodes, each of which corresponds to one expansion of the virtual property.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ICondition**</c></para>
			/// <para>Receives a pointer to the new ICondition leaf node.</para>
			/// </returns>
			/// <remarks>
			/// <para>For more information about leaf node terms (property, value, and operation), see ICondition::GetInputTerms.</para>
			/// <para>
			/// A virtual property has one or more metadata items in which the key is "MapsToRelation" and the value is a property name
			/// (which is one expansion of the property). For more information about metadata, see MetaData.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory-makeleaf HRESULT
			// MakeLeaf( LPCWSTR pszPropertyName, CONDITION_OPERATION cop, LPCWSTR pszValueType, const PROPVARIANT *ppropvar, IRichChunk
			// *pPropertyNameTerm, IRichChunk *pOperationTerm, IRichChunk *pValueTerm, BOOL fExpand, ICondition **ppcResult );
			new ICondition MakeLeaf([In, MarshalAs(UnmanagedType.LPWStr)] string pszPropertyName, [In] CONDITION_OPERATION cop, [In, MarshalAs(UnmanagedType.LPWStr)] string pszValueType,
				[In] PROPVARIANT ppropvar, IRichChunk richChunk1, IRichChunk richChunk2, IRichChunk richChunk3, [In, MarshalAs(UnmanagedType.Bool)] bool fExpand);

			/// <summary>
			/// Performs a variety of transformations on a condition tree, including the following: resolves conditions with relative
			/// date/time expressions to conditions with absolute date/time (as a VT_FILETIME); turns other recognized named entities into
			/// condition trees with actual values; simplifies condition trees; replaces virtual or compound properties with OR trees of
			/// other properties; removes condition trees resulting from queries with property keywords that had no condition applied.
			/// </summary>
			/// <param name="pc">
			/// <para>Type: <c>ICondition*</c></para>
			/// <para>A pointer to an ICondition object to be resolved.</para>
			/// </param>
			/// <param name="sqro">
			/// <para>Type: <c>STRUCTURED_QUERY_RESOLVE_OPTION</c></para>
			/// <para>
			/// Specifies zero or more of the STRUCTURED_QUERY_RESOLVE_OPTION flags. For <c>Windows 7 and later</c>, the
			/// SQRO_ADD_VALUE_TYPE_FOR_PLAIN_VALUES flag is automatically added to <paramref name="sqro"/>.
			/// </para>
			/// </param>
			/// <param name="pstReferenceTime">
			/// <para>Type: <c>SYSTEMTIME const*</c></para>
			/// <para>
			/// A pointer to a <c>SYSTEMTIME</c> value to use as the reference date and time. A null pointer can be passed if
			/// <paramref name="sqro"/> is set to SQRO_DONT_RESOLVE_DATETIME.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ICondition**</c></para>
			/// <para>
			/// Receives a pointer to the new ICondition in which all time fields have been resolved to have values of type VT_FILETIME. This
			/// new condition tree is the resolved version of <paramref name="pc"/>.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// In a condition tree produced by the Parse method and returned by GetQuery, the leaves pair up properties with restrictions on
			/// these properties, and result in a condition tree that is partially finished. The <c>IConditionFactory::Resolve</c> method
			/// finishes such a condition tree by a process known as resolution. The input condition tree is not modified in any way. The
			/// output condition tree may share parts of the input condition that contained no leaf nodes with unresolved date/time values.
			/// </para>
			/// <para><c>Note</c> Resolving a leaf node often produces a non-leaf node.</para>
			/// <para>
			/// For example, Structured Query supports relative date/time expressions, which remain unresolved until they are applied to some
			/// reference time. In a leaf node with semantic type <c>System.StructuredQueryType.DateTime</c>, the value can be either a
			/// VT_FILETIME or a VT_LPWSTR. VT_FILETIME is an absolute date/time so it is already resolved. VT_LPWSTR is a string
			/// representation of a relative date/time expression. The specified reference time should be a local time, but the resolved
			/// times in the resulting query expression will be in Coordinated Universal Time (UTC).
			/// </para>
			/// <para>
			/// The StructuredQuerySample code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to read lines from
			/// the console, parse them using the system schema, and display the resulting condition trees.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory-resolve HRESULT
			// Resolve( ICondition *pc, STRUCTURED_QUERY_RESOLVE_OPTION sqro, const SYSTEMTIME *pstReferenceTime, ICondition **ppcResolved );
			new ICondition Resolve([In] ICondition pc, STRUCTURED_QUERY_RESOLVE_OPTION sqro, in SYSTEMTIME pstReferenceTime);

			/// <summary>
			/// Creates a search condition that is either <c>TRUE</c> or <c>FALSE</c>. The returned object supports ICondition and ICondition2
			/// </summary>
			/// <param name="fVal">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>The value of the search condition to use. fValue should typically be set to VARIANT_FALSE.</para>
			/// </param>
			/// <param name="cco">
			/// <para>Type: <c>CONDITION_CREATION_OPTIONS</c></para>
			/// <para>The condition creation operation of the leaf condition as the CONDITION_CREATION_OPTIONS enumeration.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>The desired IID of the enumerating interface: either IEnumUnknown, IEnumVARIANT, or (for a negation condition) IID_ICondition.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>Receives a pointer to zero or more ICondition and ICondition2 objects.</para>
			/// </param>
			/// <returns>Receives a pointer to zero or more ICondition and ICondition2 objects.</returns>
			/// <remarks>For default options, use the CONDITION_CREATION_DEFAULT flag.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory2-createtruefalse
			// HRESULT CreateTrueFalse( BOOL fVal, CONDITION_CREATION_OPTIONS cco, REFIID riid, void **ppv );
			[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)]
			object CreateTrueFalse([MarshalAs(UnmanagedType.Bool)] bool fVal, CONDITION_CREATION_OPTIONS cco, in Guid riid);

			/// <summary>
			/// Creates a condition node that is a logical negation (NOT) of another condition (a subnode of this node).
			/// </summary>
			/// <param name="pcSub"><para>Type: <c>ICondition*</c></para>
			/// <para>A pointer to the ICondition subnode to be negated. For default options, use the CONDITION_CREATION_DEFAULT flag.</para></param>
			/// <param name="cco"><para>Type: <c>CONDITION_CREATION_OPTIONS</c></para>
			/// <para>The condition creation operation of the leaf condition as the CONDITION_CREATION_OPTIONS enumeration.</para></param>
			/// <param name="riid"><para>Type: <c>REFIID</c></para>
			/// <para>The desired IID of the enumerating interface: either IEnumUnknown, IEnumVARIANT, or (for a negation condition) IID_ICondition.</para></param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>Receives a pointer to zero or more ICondition and ICondition2 objects.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Logically simplifying a condition node usually results in a smaller, more easily traversed and processed condition tree. For
			/// example, if pcSub is itself a negation condition with a subcondition C, then the double negation is logically resolved, and
			/// ppcResult is set to C. Without simplification, the resulting tree would look like NOT — NOT — C.
			/// </para>
			/// <para>
			/// Applications that need to execute queries based on the condition tree would typically benefit from setting this parameter to <c>TRUE</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory2-createnegation
			// HRESULT CreateNegation( ICondition *pcSub, CONDITION_CREATION_OPTIONS cco, REFIID riid, void **ppv );
			[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)]
			object CreateNegation([In] ICondition pcSub, CONDITION_CREATION_OPTIONS cco, in Guid riid);

			/// <summary>
			/// Creates a leaf condition node that is a conjunction (AND) or a disjunction (OR) of a collection of subconditions. The
			/// returned object supports ICondition and ICondition2.
			/// </summary>
			/// <param name="ct"><para>Type: <c>CONDITION_TYPE</c></para>
			/// <para>A CONDITION_TYPE enumeration that must be set to either the CT_AND_CONDITION or CT_OR_CONDITION flag.</para></param>
			/// <param name="poaSubs"><para>Type: <c>IObjectArray*</c></para>
			/// <para>
			/// Each element of the poaSubs parameter must implement ICondition. This parameter may also be <c>NULL</c>, which is equivalent
			/// to being empty.
			/// </para></param>
			/// <param name="cco"><para>Type: <c>CONDITION_CREATION_OPTIONS</c></para>
			/// <para>The condition creation operation of the leaf condition as the CONDITION_CREATION_OPTIONS enumeration.</para></param>
			/// <param name="riid"><para>Type: <c>REFIID</c></para>
			/// <para>
			/// The desired IID of the enumerating interface: either IEnumUnknown, IID_IEnumVARIANT, or (for a negation condition) IID_ICondition.
			/// </para></param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>A collection of zero or more ICondition and ICondition2 objects.</para>
			/// </returns>
			/// <remarks>For default options, use the CONDITION_CREATION_DEFAULT flag.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory2-createcompoundfromobjectarray
			// HRESULT CreateCompoundFromObjectArray( CONDITION_TYPE ct, IObjectArray *poaSubs, CONDITION_CREATION_OPTIONS cco, REFIID riid, void **ppv );
			[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)]
			object CreateCompoundFromObjectArray(CONDITION_TYPE ct, [In, Optional] IObjectArray poaSubs, CONDITION_CREATION_OPTIONS cco, in Guid riid);

			/// <summary>
			/// Creates a leaf condition node that is a conjunction (AND) or a disjunction (OR) from an array of condition nodes. The
			/// returned object supports ICondition and ICondition2.
			/// </summary>
			/// <param name="ct"><para>Type: <c>CONDITION_TYPE</c></para>
			/// <para>A CONDITION_TYPE enumeration that must be set to either the CT_AND_CONDITION or CT_OR_CONDITION flag.</para></param>
			/// <param name="ppcondSubs"><para>Type: <c>ICondition**</c></para>
			/// <para>Each element of the ppCondSubs parameter must implement ICondition.</para></param>
			/// <param name="cSubs"><para>Type: <c>ULONG</c></para>
			/// <para>The leaf subcondition as an unsigned 64-bit integer value.</para></param>
			/// <param name="cco"><para>Type: <c>CONDITION_CREATION_OPTIONS</c></para>
			/// <para>The condition creation operation of the leaf condition as the CONDITION_CREATION_OPTIONS enumeration.</para></param>
			/// <param name="riid"><para>Type: <c>REFIID</c></para>
			/// <para>
			/// The desired IID of the enumerating interface: either IEnumUnknown, IID_IEnumVARIANT, or (for a negation condition) IID_ICondition.
			/// </para></param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>A collection of zero or more ICondition and ICondition2 objects.</para>
			/// </returns>
			/// <remarks>For default options, use the CONDITION_CREATION_DEFAULT flag.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory2-createcompoundfromarray
			// HRESULT CreateCompoundFromArray( CONDITION_TYPE ct, ICondition **ppcondSubs, ULONG cSubs, CONDITION_CREATION_OPTIONS cco, REFIID riid, void **ppv );
			[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)]
			object CreateCompoundFromArray(CONDITION_TYPE ct, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] ICondition[] ppcondSubs, uint cSubs, CONDITION_CREATION_OPTIONS cco, in Guid riid);

			/// <summary>
			/// Creates a leaf condition node for a string value that represents a comparison of property value and constant value. The
			/// returned object supports ICondition and ICondition2.
			/// </summary>
			/// <param name="propkey"><para>Type: <c>REFPROPERTYKEY</c></para>
			/// <para>The name of the property of the leaf condition as a REFPROPERTYKEY. If the leaf has no particular property, use PKEY_Null.</para></param>
			/// <param name="cop"><para>Type: <c>CONDITION_OPERATION</c></para>
			/// <para>A CONDITION_OPERATION enumeration. If the leaf has no particular operation, then use COP_IMPLICIT.</para></param>
			/// <param name="pszValue"><para>Type: <c>LPCWSTR</c></para>
			/// <para>The value to be compared, or <c>NULL</c> for an unspecified property. The locale name of the leaf node is LOCALE_NAME_USER_DEFAULT.</para></param>
			/// <param name="pszLocaleName"><para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// The name of the locale of the lead condition, or <c>NULL</c> for a plain string. The locale name of the leaf node is LOCALE_NAME_USER_DEFAULT.
			/// </para></param>
			/// <param name="cco"><para>Type: <c>CONDITION_CREATION_OPTIONS</c></para>
			/// <para>The condition creation operation of the leaf condition as the CONDITION_CREATION_OPTIONS enumeration.</para></param>
			/// <param name="riid"><para>Type: <c>REFIID</c></para>
			/// <para>
			/// The desired IID of the enumerating interface: either IEnumUnknown, IID_IEnumVARIANT, or (for a negation condition) IID_ICondition.
			/// </para></param>
			/// <param name="ppv">The PPV.</param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>Receives a pointer to zero or more ICondition and ICondition2 objects.</para>
			/// </returns>
			/// <remarks>For default options, use the CONDITION_CREATION_DEFAULT flag.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory2-createstringleaf
			// HRESULT CreateStringLeaf( REFPROPERTYKEY propkey, CONDITION_OPERATION cop, LPCWSTR pszValue, LPCWSTR pszLocaleName, CONDITION_CREATION_OPTIONS cco, REFIID riid, void **ppv );
			[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 5)]
			object CreateStringLeaf(in PROPERTYKEY propkey, CONDITION_OPERATION cop, [MarshalAs(UnmanagedType.LPWStr), Optional] string pszValue,
				[MarshalAs(UnmanagedType.LPWStr), Optional] string pszLocaleName, CONDITION_CREATION_OPTIONS cco, in Guid riid);

			/// <summary>
			/// Creates a leaf condition node for an integer value. The returned object supports ICondition and ICondition2.
			/// </summary>
			/// <param name="propkey"><para>Type: <c>REFPROPERTYKEY</c></para>
			/// <para>The name of the property of the leaf condition as a REFPROPERTYKEY. If the leaf has no particular property, use PKEY_Null.</para></param>
			/// <param name="cop"><para>Type: <c>CONDITION_OPERATION</c></para>
			/// <para>A CONDITION_OPERATION enumeration. If the leaf has no particular operation, then use COP_IMPLICIT.</para></param>
			/// <param name="lValue"><para>Type: <c>INT32</c></para>
			/// <para>The value of a leaf condition node as a 32-bit integer.</para></param>
			/// <param name="cco"><para>Type: <c>CONDITION_CREATION_OPTIONS</c></para>
			/// <para>The condition creation operation of the leaf condition as the CONDITION_CREATION_OPTIONS enumeration.</para></param>
			/// <param name="riid"><para>Type: <c>REFIID</c></para>
			/// <para>
			/// The desired IID of the enumerating interface: either IEnumUnknown, IID_IEnumVARIANT, or (for a negation condition) IID_ICondition.
			/// </para></param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>Receives a pointer to zero or more ICondition and ICondition2 objects.</para>
			/// </returns>
			/// <remarks>For default options, use the CONDITION_CREATION_DEFAULT flag.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory2-createintegerleaf
			// HRESULT CreateIntegerLeaf( REFPROPERTYKEY propkey, CONDITION_OPERATION cop, INT32 lValue, CONDITION_CREATION_OPTIONS cco, REFIID riid, void **ppv );
			[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)]
			object CreateIntegerLeaf(in PROPERTYKEY propkey, CONDITION_OPERATION cop, int lValue, CONDITION_CREATION_OPTIONS cco, in Guid riid);

			/// <summary>
			/// Creates a search condition that is either <c>TRUE</c> or <c>FALSE</c>. The returned object supports ICondition and ICondition2
			/// </summary>
			/// <param name="propkey"><para>Type: <c>REFPROPERTYKEY</c></para>
			/// <para>The name of the property of the leaf condition as a REFPROPERTYKEY. If the leaf has no particular property, use PKEY_Null.</para></param>
			/// <param name="cop"><para>Type: <c>CONDITION_OPERATION</c></para>
			/// <para>A CONDITION_OPERATION enumeration. If the leaf has no particular operation, then use COP_IMPLICIT.</para></param>
			/// <param name="fValue"><para>Type: <c>BOOL</c></para>
			/// <para>The value of the search condition to use. fValue should typically be set to VARIANT_FALSE.</para></param>
			/// <param name="cco"><para>Type: <c>CONDITION_CREATION_OPTIONS</c></para>
			/// <para>The condition creation operation of the leaf condition as the CONDITION_CREATION_OPTIONS enumeration.</para></param>
			/// <param name="riid"><para>Type: <c>REFIID</c></para>
			/// <para>The desired IID of the enumerating interface: either IEnumUnknown, IEnumVARIANT, or (for a negation condition) IID_ICondition.</para></param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>Receives a pointer to zero or more ICondition and ICondition2 objects.</para>
			/// </returns>
			/// <remarks>For default options, use the CONDITION_CREATION_DEFAULT flag.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory2-createbooleanleaf
			// HRESULT CreateBooleanLeaf( REFPROPERTYKEY propkey, CONDITION_OPERATION cop, BOOL fValue, CONDITION_CREATION_OPTIONS cco, REFIID riid, void **ppv );
			[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)]
			object CreateBooleanLeaf(in PROPERTYKEY propkey, CONDITION_OPERATION cop, [MarshalAs(UnmanagedType.Bool)] bool fValue, CONDITION_CREATION_OPTIONS cco, in Guid riid);

			/// <summary>Creates a leaf condition node for any value. The returned object supports ICondition and ICondition2.</summary>
			/// <param name="propkey"><para>Type: <c>REFPROPERTYKEY</c></para>
			/// <para>The name of the property of the leaf condition as a REFPROPERTYKEY. If the leaf has no particular property, use PKEY_Null.</para></param>
			/// <param name="cop"><para>Type: <c>CONDITION_OPERATION</c></para>
			/// <para>A CONDITION_OPERATION enumeration. If the leaf has no particular operation, then use COP_IMPLICIT.</para></param>
			/// <param name="propvar"><para>Type: <c>REFPROPERTYKEY</c></para>
			/// <para>The property value of the leaf condition as a REFPROPERTYKEY.</para></param>
			/// <param name="pszSemanticType"><para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// The name of a semantic type of the value, or <c>NULL</c> for a plain string. If the newly created leaf is an unresolved named
			/// entity, pszSemanticType should be the name of a semantic type, otherwise <c>NULL</c>.
			/// </para></param>
			/// <param name="pszLocaleName"><para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// The name of the locale to be compared, or <c>NULL</c> for an unspecified locale. If propvar does not contain a string value,
			/// then pszLocaleName should be LOCALE_NAME_USER_DEFAULT; otherwise, pszLocaleName should reflect the language the string.
			/// Alternatively, pszLocaleName could be LOCALE_NAME_INVARIANT.
			/// </para></param>
			/// <param name="pPropertyNameTerm"><para>Type: <c>IRichChunk*</c></para>
			/// <para>A pointer to an IRichChunk that identifies the range of the input string that repesents the property. It can be <c>NULL</c>.</para></param>
			/// <param name="pOperationTerm"><para>Type: <c>IRichChunk*</c></para>
			/// <para>A pointer to an IRichChunk that identifies the range of the input string that repesents the operation. It can be <c>NULL</c>.</para></param>
			/// <param name="pValueTerm"><para>Type: <c>IRichChunk*</c></para>
			/// <para>A pointer to an IRichChunk that identifies the range of the input string that repesents the value. It can be <c>NULL</c>.</para></param>
			/// <param name="cco"><para>Type: <c>CONDITION_CREATION_OPTIONS</c></para>
			/// <para>The condition creation operation of the leaf condition as the CONDITION_CREATION_OPTIONS enumeration.</para></param>
			/// <param name="riid"><para>Type: <c>REFIID</c></para>
			/// <para>The desired IID of the enumerating interface: either IEnumUnknown, IEnumVARIANT, or (for a negation condition) IID_ICondition.</para></param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>Receives a pointer to zero or more ICondition and ICondition2 objects.</para>
			/// </returns>
			/// <remarks>
			/// <para>For default options, use the CONDITION_CREATION_DEFAULT flag.</para>
			/// <para>
			/// If the leaf condition was obtained by parsing a string, one or more of the parameters pPropertyNameTerm, pOperationTerm and
			/// pValueTerm may be represented by an IRichChunk interface (obtained through the ICondition::GetInputTerms method). Otherwise
			/// all three parameters can be <c>NULL</c>.
			/// </para>
			/// <para>For more information about leaf node terms (property, value, and operation), see ICondition::GetInputTerms.</para>
			/// <para>
			/// A virtual property has one or more metadata items in which the key is "MapsToRelation" and the value is a property name
			/// (which is one expansion of the property). For more information about metadata, see MetaData.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory2-createleaf
			// HRESULT CreateLeaf( REFPROPERTYKEY propkey, CONDITION_OPERATION cop, REFPROPVARIANT propvar, LPCWSTR pszSemanticType, LPCWSTR pszLocaleName, IRichChunk *pPropertyNameTerm, IRichChunk *pOperationTerm, IRichChunk *pValueTerm, CONDITION_CREATION_OPTIONS cco, REFIID riid, void **ppv );
			[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 9)]
			object CreateLeaf(in PROPERTYKEY propkey, CONDITION_OPERATION cop, [In] PROPVARIANT propvar, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pszSemanticType,
				[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pszLocaleName, [In, Optional] IRichChunk pPropertyNameTerm, [In, Optional] IRichChunk pOperationTerm,
				[In, Optional] IRichChunk pValueTerm, CONDITION_CREATION_OPTIONS cco, in Guid riid);

			/// <summary>
			/// Performs a variety of transformations on a condition tree, and thereby the resolved condition for evaluation. The returned
			/// object supports ICondition and ICondition2.
			/// </summary>
			/// <param name="pc"><para>Type: <c>ICondition*</c></para>
			/// <para>Pointer to an ICondition object to be resolved.</para></param>
			/// <param name="sqro"><para>Type: <c>STRUCTURED_QUERY_RESOLVE_OPTION</c></para>
			/// <para>
			/// Specifies zero or more of the STRUCTURED_QUERY_RESOLVE_OPTION flags. The SQRO_NULL_VALUE_TYPE_FOR_PLAIN_VALUES flag is
			/// automatically added to sqro.
			/// </para></param>
			/// <param name="pstReferenceTime"><para>Type: <c>SYSTEMTIME const*</c></para>
			/// <para>
			/// Pointer to a <c>SYSTEMTIME</c> value to use as the reference date and time. A null pointer can be passed if sqro is set to
			/// the SQRO_DONT_RESOLVE_DATETIME flag.
			/// </para></param>
			/// <param name="riid"><para>Type: <c>REFIID</c></para>
			/// <para>The desired IID of the enumerating interface: either IEnumUnknown, IEnumVARIANT, or (for a negation condition) IID_ICondition.</para></param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>Receives a pointer to zero or more ICondition and ICondition2 objects.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The StructuredQuerySample code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to read lines from
			/// the console, parse them using the system schema, and display the resulting condition trees.
			/// </para>
			/// <para>Refer to the Resolve method for additional detail.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory2-resolvecondition
			// HRESULT ResolveCondition( ICondition *pc, STRUCTURED_QUERY_RESOLVE_OPTION sqro, const SYSTEMTIME *pstReferenceTime, REFIID riid, void **ppv );
			[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)]
			object ResolveCondition([In] ICondition pc, STRUCTURED_QUERY_RESOLVE_OPTION sqro, in SYSTEMTIME pstReferenceTime, in Guid riid);
		}

		/// <summary>Provides methods for retrieving information about an entity type in the schema.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nn-structuredquery-ientity
		[PInvokeData("structuredquery.h")]
		[ComImport, Guid("24264891-E80B-4fd3-B7CE-4FF2FAE8931F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IEntity
		{
			/// <summary>Retrieves the name of this entity.</summary>
			/// <returns>
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>
			/// Receives a pointer to the name of this entity as a Unicode string. The calling application must free the returned string by
			/// calling CoTaskMemFree.
			/// </para>
			/// </returns>
			/// <remarks>Each name must be unique.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-ientity-name HRESULT Name( LPWSTR
			// *ppszName );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string Name();

			/// <summary>Retrieves the parent entity of this entity.</summary>
			/// <param name="pBaseEntity">
			/// <para>Type: <c>IEntity**</c></para>
			/// <para>Receives a pointer to the parent IEntity object, or <c>NULL</c> if there is no parent entity.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns one of the following, or an error value otherwise.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>pBaseEntity successfully set.</term>
			/// </item>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>The entity has no parent; pBaseEntity successfully set to NULL.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// Each entity derives from some other entity, except the entity named Entity, for which this method returns S_FALSE. The
			/// derived entity inherits all relationships from the base entity.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-ientity-base HRESULT Base( IEntity
			// **pBaseEntity );
			HRESULT Base(out IEntity pBaseEntity);

			/// <summary>Retrieves an enumeration of IRelationship objects, one for each relationship this entity has.</summary>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>The desired IID of the result, either IID_IEnumUnknown or IID_IEnumVARIANT.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>Receives the address of a pointer to the enumeration of the IRelationship objects.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-ientity-relationships HRESULT
			// Relationships( REFIID riid, void **pRelationships );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object Relationships(in Guid riid);

			/// <summary>Retrieves the IRelationship object for this entity as requested by name.</summary>
			/// <param name="pszRelationName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The name of the relationship to find.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>IRelationship**</c></para>
			/// <para>
			/// Receives the address of a pointer to the requested IRelationship object, or <c>NULL</c> if this entity has no relationship
			/// with the name specified.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-ientity-getrelationship HRESULT
			// GetRelationship( LPCWSTR pszRelationName, IRelationship **pRelationship );
			IRelationship GetRelationship([In, MarshalAs(UnmanagedType.LPWStr)] string pszRelationName);

			/// <summary>
			/// <para>Retrieves an enumeration of IMetaData objects for this entity.</para>
			/// </summary>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>The desired IID of the result, either IID_IEnumUnknown or IID_IEnumVARIANT.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>Receives the address of a pointer to an enumeration of IMetaData objects.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-ientity-metadata HRESULT MetaData(
			// REFIID riid, void **pMetaData );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object MetaData(in Guid riid);

			/// <summary>Retrieves an enumeration of INamedEntity objects, one for each known named entity of this type.</summary>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>The desired IID of the result, either IID_IEnumUnknown or IID_IEnumVARIANT.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>
			/// Receives the address of a pointer to an enumeration of INamedEntity objects, one for each known named entity of this type.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-ientity-namedentities HRESULT
			// NamedEntities( REFIID riid, void **pNamedEntities );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object NamedEntities(in Guid riid);

			/// <summary>Retrieves an INamedEntity object based on an entity name.</summary>
			/// <param name="pszValue">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The name of an entity to be found.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>INamedEntity**</c></para>
			/// <para>Receives a pointer to the INamedEntity object that was named in pszValue. <c>NULL</c> if no named entity was found.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-ientity-getnamedentity HRESULT
			// GetNamedEntity( LPCWSTR pszValue, INamedEntity **ppNamedEntity );
			INamedEntity GetNamedEntity([In, MarshalAs(UnmanagedType.LPWStr)] string pszValue);

			/// <summary>Retrieves a default phrase to use for this entity in restatements.</summary>
			/// <returns>
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>
			/// Receives a pointer to the default phrase as a Unicode string. The calling application must free the returned string by
			/// calling CoTaskMemFree.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-ientity-defaultphrase HRESULT
			// DefaultPhrase( LPWSTR *ppszPhrase );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string DefaultPhrase();
		}

		/// <summary>Provides methods to get the value of, or a default phrase for the value of, a named entity.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nn-structuredquery-inamedentity
		[PInvokeData("structuredquery.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("ABDBD0B1-7D54-49fb-AB5C-BFF4130004CD"), CoClass(typeof(QueryParser))]
		public interface INamedEntity
		{
			/// <summary>Retrieves the value of this named entity as a string.</summary>
			/// <returns>
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>
			/// Receives a pointer to the value of the named entity as a Unicode string. The calling application must free the returned
			/// string by calling CoTaskMemFree.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-inamedentity-getvalue HRESULT
			// GetValue( LPWSTR *ppszValue );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetValue();

			/// <summary>Retrieves a default phrase to use for this named entity in restatements.</summary>
			/// <returns>
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>
			/// Receives a pointer to the default phrase as a Unicode string. The calling application must free the returned string by
			/// calling CoTaskMemFree.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-inamedentity-defaultphrase HRESULT
			// DefaultPhrase( LPWSTR *ppszPhrase );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string DefaultPhrase();
		}

		/// <summary>Provides methods to parse an input string into an IQuerySolution object.</summary>
		/// <remarks>
		/// The StructuredQuerySample code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to read lines from the
		/// console, parse them using the system schema, and display the resulting condition trees.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nn-structuredquery-iqueryparser
		[PInvokeData("structuredquery.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("2EBDEE67-3505-43f8-9946-EA44ABC8E5B0"), CoClass(typeof(QueryParser))]
		public interface IQueryParser
		{
			/// <summary>
			/// Parses an input string that contains Structured Query keywords and/or contents to produce an IQuerySolution object.
			/// </summary>
			/// <param name="pszInputString">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to the Unicode input string to be parsed.</para>
			/// </param>
			/// <param name="pCustomProperties">
			/// <para>Type: <c>IEnumUnknown*</c></para>
			/// <para>
			/// An enumeration of IRichChunk objects, one for each custom property the application has recognized. This parameter can be
			/// <c>NULL</c>, which is equivalent to an empty enumeration.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>IQuerySolution**</c></para>
			/// <para>Receives an IQuerySolution object. The caller must release it by calling its IUnknown::Release method.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// For each IRichChunk object, the position information identifies the character span of the custom property, the string value
			/// is the name of an actual property, and the PROPVARIANT is unused. Although any property could be used, these generic
			/// properties are included specifically for this purpose:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>System.StructuredQuery.CustomProperty.Boolean</term>
			/// </item>
			/// <item>
			/// <term>System.StructuredQuery.CustomProperty.DateTime</term>
			/// </item>
			/// <item>
			/// <term>System.StructuredQuery.CustomProperty.Integer</term>
			/// </item>
			/// <item>
			/// <term>System.StructuredQuery.CustomProperty.FloatingPoint</term>
			/// </item>
			/// <item>
			/// <term>System.StructuredQuery.CustomProperty.String</term>
			/// </item>
			/// </list>
			/// <para>
			/// An application can use them in the enumeration passed in the pCustomProperties parameter and look for them in the resulting
			/// condition tree.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iqueryparser-parse HRESULT Parse(
			// LPCWSTR pszInputString, IEnumUnknown *pCustomProperties, IQuerySolution **ppSolution );
			IQuerySolution Parse([In, MarshalAs(UnmanagedType.LPWStr)] string pszInputString, [In, Optional] IEnumUnknown pCustomProperties);

			/// <summary>Sets a single option, such as a specified word-breaker, for parsing an input string.</summary>
			/// <param name="option">
			/// <para>Type: <c>STRUCTURED_QUERY_SINGLE_OPTION</c></para>
			/// <para>Identifies the type of option to be set.</para>
			/// </param>
			/// <param name="pOptionValue">
			/// <para>Type: <c>PROPVARIANT*</c></para>
			/// <para>
			/// Pointer to a PROPVARIANT specifying the value to set for the option parameter. This value is interpreted differently
			/// depending on the value of the option parameter.
			/// </para>
			/// </param>
			/// <remarks>For more information, see STRUCTURED_QUERY_SINGLE_OPTION.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iqueryparser-setoption HRESULT
			// SetOption( STRUCTURED_QUERY_SINGLE_OPTION option, const PROPVARIANT *pOptionValue );
			void SetOption([In] STRUCTURED_QUERY_SINGLE_OPTION option, [In] PROPVARIANT pOptionValue);

			/// <summary>Retrieves a specified simple option value for this query parser.</summary>
			/// <param name="option">
			/// <para>Type: <c>STRUCTURED_QUERY_SINGLE_OPTION</c></para>
			/// <para>The STRUCTURED_QUERY_SINGLE_OPTION enumerated type that specifies the option to be retrieved.</para>
			/// </param>
			/// <param name="pOptionValue">
			/// <para>Type: <c>PROPVARIANT*</c></para>
			/// <para>Receives a pointer to the specified option value. For more information, see STRUCTURED_QUERY_SINGLE_OPTION.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iqueryparser-getoption HRESULT
			// GetOption( STRUCTURED_QUERY_SINGLE_OPTION option, PROPVARIANT *pOptionValue );
			void GetOption([In] STRUCTURED_QUERY_SINGLE_OPTION option, [Out] PROPVARIANT pOptionValue);

			/// <summary>Sets a complex option, such as a specified condition generator, to use when parsing an input string.</summary>
			/// <param name="option">
			/// <para>Type: <c>STRUCTURED_QUERY_MULTIOPTION</c></para>
			/// <para>The complex option to be set.</para>
			/// </param>
			/// <param name="pszOptionKey">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// A Unicode string that is interpreted differently for each value of the option parameter. For more information, see STRUCTURED_QUERY_MULTIOPTION.
			/// </para>
			/// </param>
			/// <param name="pOptionValue">
			/// <para>Type: <c>PROPVARIANT*</c></para>
			/// <para>
			/// Pointer to a PROPVARIANT that is interpreted differently for each value of the option parameter. For more information, see STRUCTURED_QUERY_MULTIOPTION.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iqueryparser-setmultioption HRESULT
			// SetMultiOption( STRUCTURED_QUERY_MULTIOPTION option, LPCWSTR pszOptionKey, const PROPVARIANT *pOptionValue );
			void SetMultiOption([In] STRUCTURED_QUERY_MULTIOPTION option, [In, MarshalAs(UnmanagedType.LPWStr)] string pszOptionKey, [In] PROPVARIANT pOptionValue);

			/// <summary>Retrieves a schema provider for browsing the currently loaded schema.</summary>
			/// <returns>
			/// <para>Type: <c>ISchemaProvider**</c></para>
			/// <para>
			/// Receives the address of a pointer to an ISchemaProvider object. The calling application must release it by invoking its
			/// IUnknown::Release method.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iqueryparser-getschemaprovider HRESULT
			// GetSchemaProvider( ISchemaProvider **ppSchemaProvider );
			ISchemaProvider GetSchemaProvider();

			/// <summary>
			/// Restates a condition as a structured query string. If the condition was the result of parsing an original query string, the
			/// keywords of that query string are used to a great extent. If not, default keywords are used.
			/// </summary>
			/// <param name="pCondition">
			/// <para>Type: <c>ICondition*</c></para>
			/// <para>The condition to be restated.</para>
			/// </param>
			/// <param name="fUseEnglish">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved. Must be <c>FALSE</c>.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>Receives the restated query string. The caller must free the string by calling CoTaskMemFree.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iqueryparser-restatetostring HRESULT
			// RestateToString( ICondition *pCondition, BOOL fUseEnglish, LPWSTR *ppszQueryString );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string RestateToString([In] ICondition pCondition, [In, MarshalAs(UnmanagedType.Bool)] bool fUseEnglish);

			/// <summary>Parses a condition for a specified property.</summary>
			/// <param name="pszPropertyName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Property name.</para>
			/// </param>
			/// <param name="pszInputString">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Query string to be parsed, relative to that property.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>IQuerySolution**</c></para>
			/// <para>Receives an IQuerySolution object. The calling application must release it by calling its IUnknown::Release method.</para>
			/// </returns>
			/// <remarks>
			/// The input string can be anything that could have been written immediately after a property in a structured query. For
			/// example, "from:(bill OR alex)" would be a valid structured query, so passing System.StructuredQuery.Virtual.From (for which
			/// From is a keyword) in the pszPropertyName parameter and "(bill OR alex)" or "bill OR alex" in the pszInputString parameter
			/// would be valid. This would result in an <c>OR</c> of leaf nodes that relate the System.StructuredQuery.Virtual.From property
			/// with the strings "bill" and "alex".
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iqueryparser-parsepropertyvalue
			// HRESULT ParsePropertyValue( LPCWSTR pszPropertyName, LPCWSTR pszInputString, IQuerySolution **ppSolution );
			IQuerySolution ParsePropertyValue([In, MarshalAs(UnmanagedType.LPWStr)] string pszPropertyName, [In, MarshalAs(UnmanagedType.LPWStr)] string pszInputString);

			/// <summary>Restates a specified property for a condition as a query string.</summary>
			/// <param name="pCondition">
			/// <para>Type: <c>ICondition*</c></para>
			/// <para>A condition to be restated as a query string.</para>
			/// </param>
			/// <param name="fUseEnglish">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved. Must be <c>FALSE</c>.</para>
			/// </param>
			/// <param name="ppszPropertyName">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>
			/// Receives a pointer to the property name as a Unicode string. The calling application must free the string by calling CoTaskMemFree.
			/// </para>
			/// </param>
			/// <param name="ppszQueryString">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>Receives a pointer to a query string for that property. The calling application must free the string by calling CoTaskMemFree.</para>
			/// </param>
			/// <remarks>
			/// If the leaf nodes of the condition contain more than one property name, or no property name at all, E_INVALIDARG is returned.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iqueryparser-restatepropertyvaluetostring
			// HRESULT RestatePropertyValueToString( ICondition *pCondition, BOOL fUseEnglish, LPWSTR *ppszPropertyName, LPWSTR
			// *ppszQueryString );
			void RestatePropertyValueToString([In] ICondition pCondition, [In, MarshalAs(UnmanagedType.Bool)] bool fUseEnglish, [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszPropertyName, [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszQueryString);
		}

		/// <summary>Provides methods to create, initialize, and change options for an IQueryParser object.</summary>
		/// <remarks>
		/// The StructuredQuerySample code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to read lines from the
		/// console, parse them using the system schema, and display the resulting condition trees.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nn-structuredquery-iqueryparsermanager
		[PInvokeData("structuredquery.h")]
		[ComImport, Guid("A879E3C4-AF77-44fb-8F37-EBD1487CF920"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(QueryParserManager))]
		public interface IQueryParserManager
		{
			/// <summary>
			/// Creates a new instance of a IQueryParser interface implementation. This instance of the query parser is loaded with the
			/// schema for the specified catalog and is localized to a specified language. All other settings are initialized to default settings.
			/// </summary>
			/// <param name="pszCatalog">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The name of the catalog to use. Permitted values are and an empty string (for a trivial schema with no properties).</para>
			/// </param>
			/// <param name="langidForKeywords">
			/// <para>Type: <c>LANGID</c></para>
			/// <para>The LANGID used to select the localized language for keywords.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>The IID of the IQueryParser interface implementation.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>
			/// Receives a pointer to the newly created parser. The calling application must release it by calling its IUnknown::Release method.
			/// </para>
			/// </returns>
			/// <remarks>
			/// If %LOCALAPPDATA% is not available, then this method fails. You should call IQueryParserManager::SetOption to point to a
			/// different folder like %ProgramData%.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iqueryparsermanager-createloadedparser
			// HRESULT CreateLoadedParser( LPCWSTR pszCatalog, LANGID langidForKeywords, REFIID riid, void **ppQueryParser );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object CreateLoadedParser([In, MarshalAs(UnmanagedType.LPWStr)] string pszCatalog, uint langidForKeywords, in Guid riid);

			/// <summary>
			/// Sets the flags for Natural Query Syntax (NQS) and automatic wildcard characters for the specified query parser. If the query
			/// parser was created for the catalog, this method also sets up standard condition generators to be used later by the query
			/// parser object for recognizing named entities.
			/// </summary>
			/// <param name="fUnderstandNQS">
			/// <para>Type: <c>BOOL</c></para>
			/// <para><c>BOOL</c> flag that controls whether NQS is supported by this instance of the query parser.</para>
			/// </param>
			/// <param name="fAutoWildCard">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// <c>BOOL</c> flag that controls whether a wildcard character (*) is to be assumed after each word in the query (unless
			/// followed by punctuation other than a parenthesis).
			/// </para>
			/// </param>
			/// <param name="pQueryParser">
			/// <para>Type: <c>IQueryParser*</c></para>
			/// <para>Pointer to the query parser object.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iqueryparsermanager-initializeoptions
			// HRESULT InitializeOptions( BOOL fUnderstandNQS, BOOL fAutoWildCard, IQueryParser *pQueryParser );
			void InitializeOptions([MarshalAs(UnmanagedType.Bool)] bool fUnderstandNQS, [MarshalAs(UnmanagedType.Bool)] bool fAutoWildCard, [In] IQueryParser pQueryParser);

			/// <summary>
			/// Changes a single option in this IQueryParserManager object. For example, this method could change the name of the schema
			/// binary to load or the location of localized schema binaries.
			/// </summary>
			/// <param name="option">
			/// <para>Type: <c>QUERY_PARSER_MANAGER_OPTION</c></para>
			/// <para>The QUERY_PARSER_MANAGER_OPTION to be changed.</para>
			/// </param>
			/// <param name="pOptionValue">
			/// <para>Type: <c>PROPVARIANT const*</c></para>
			/// <para>A pointer to the value to use for the option selected.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iqueryparsermanager-setoption HRESULT
			// SetOption( QUERY_PARSER_MANAGER_OPTION option, const PROPVARIANT *pOptionValue );
			void SetOption(QUERY_PARSER_MANAGER_OPTION option, [In] PROPVARIANT pOptionValue);
		}

		/// <summary>
		/// <para>Provides methods that retrieve information about the interpretation of a parsed query.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The StructuredQuerySample code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to read lines from the
		/// console, parse them using the system schema, and display the resulting condition trees.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nn-structuredquery-iquerysolution
		[PInvokeData("structuredquery.h")]
		[ComImport, Guid("D6EBC66B-8921-4193-AFDD-A1789FB7FF57"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IQuerySolution : IConditionFactory
		{
			/// <summary>Creates a condition node that is a logical negation (NOT) of another condition (a subnode of this node).</summary>
			/// <param name="pcSub">
			/// <para>Type: <c>ICondition*</c></para>
			/// <para>Pointer to the ICondition subnode to be negated.</para>
			/// </param>
			/// <param name="fSimplify">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// <c>TRUE</c> to logically simplify the result if possible; <c>FALSE</c> otherwise. In a query builder scenario, fSimplify
			/// should typically be set to VARIANT_FALSE.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ICondition**</c></para>
			/// <para>Receives a pointer to the new ICondition node.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Logically simplifying a condition node usually results in a smaller, more easily traversed and processed condition tree. For
			/// example, if pcSub is itself a negation condition with a subcondition C, then the double negation is logically resolved, and
			/// ppcResult is set to C. Without simplification, the resulting tree would look like NOT — NOT — C.
			/// </para>
			/// <para>
			/// Applications that need to execute queries based on the condition tree would typically benefit from setting this parameter to <c>TRUE</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory-makenot HRESULT
			// MakeNot( ICondition *pcSub, BOOL fSimplify, ICondition **ppcResult );
			new ICondition MakeNot([In] ICondition pcSub, [In, MarshalAs(UnmanagedType.Bool)] bool fSimplify);

			/// <summary>Creates a condition node that is a logical conjunction (AND) or disjunction (OR) of a collection of subconditions.</summary>
			/// <param name="ct">
			/// <para>Type: <c>CONDITION_TYPE</c></para>
			/// <para>The CONDITION_TYPE of the condition node. The <c>CONDITION_TYPE</c> must be either <c>CT_AND_CONDITION</c> or <c>CT_OR_CONDITION</c>.</para>
			/// </param>
			/// <param name="peuSubs">
			/// <para>Type: <c>IEnumUnknown*</c></para>
			/// <para>A pointer to an enumeration of ICondition objects, or <c>NULL</c> for an empty enumeration.</para>
			/// </param>
			/// <param name="fSimplify">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// <c>TRUE</c> to logically simplify the result, if possible; then the result will not necessarily to be of the specified kind.
			/// <c>FALSE</c> if the result should have exactly the prescribed structure.
			/// </para>
			/// <para>
			/// An application that plans to execute a query based on the condition tree would typically benefit from setting this parameter
			/// to <c>TRUE</c>.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ICondition**</c></para>
			/// <para>Receives the address of a pointer to the new ICondition node.</para>
			/// </returns>
			/// <remarks>
			/// There are no special condition trees for <c>TRUE</c> and <c>FALSE</c>. However, a condition tree consisting of an AND node
			/// with no subconditions is always <c>TRUE</c>, and a condition tree consisting of an OR node with no subconditions is always <c>FALSE</c>.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory-makeandor HRESULT
			// MakeAndOr( CONDITION_TYPE ct, IEnumUnknown *peuSubs, BOOL fSimplify, ICondition **ppcResult );
			new ICondition MakeAndOr([In] CONDITION_TYPE ct, [In] IEnumUnknown peuSubs, [In, MarshalAs(UnmanagedType.Bool)] bool fSimplify);

			/// <summary>Creates a leaf condition node that represents a comparison of property value and constant value.</summary>
			/// <param name="pszPropertyName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// The name of a property to be compared, or <c>NULL</c> for an unspecified property. The locale name of the leaf node is LOCALE_NAME_USER_DEFAULT.
			/// </para>
			/// </param>
			/// <param name="cop">
			/// <para>Type: <c>CONDITION_OPERATION</c></para>
			/// <para>A CONDITION_OPERATION enumeration.</para>
			/// </param>
			/// <param name="pszValueType">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The name of a semantic type of the value, or <c>NULL</c> for a plain string.</para>
			/// </param>
			/// <param name="ppropvar">
			/// <para>Type: <c>PROPVARIANT const*</c></para>
			/// <para>The constant value against which the property value should be compared.</para>
			/// </param>
			/// <param name="richChunk1">The rich chunk1.</param>
			/// <param name="richChunk2">The rich chunk2.</param>
			/// <param name="richChunk3">The rich chunk3.</param>
			/// <param name="fExpand">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>
			/// If <c>TRUE</c> and pszPropertyName identifies a virtual property, the resulting node is not a leaf node; instead, it is a
			/// disjunction of leaf condition nodes, each of which corresponds to one expansion of the virtual property.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ICondition**</c></para>
			/// <para>Receives a pointer to the new ICondition leaf node.</para>
			/// </returns>
			/// <remarks>
			/// <para>For more information about leaf node terms (property, value, and operation), see ICondition::GetInputTerms.</para>
			/// <para>
			/// A virtual property has one or more metadata items in which the key is "MapsToRelation" and the value is a property name
			/// (which is one expansion of the property). For more information about metadata, see MetaData.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory-makeleaf HRESULT
			// MakeLeaf( LPCWSTR pszPropertyName, CONDITION_OPERATION cop, LPCWSTR pszValueType, const PROPVARIANT *ppropvar, IRichChunk
			// *pPropertyNameTerm, IRichChunk *pOperationTerm, IRichChunk *pValueTerm, BOOL fExpand, ICondition **ppcResult );
			new ICondition MakeLeaf([In, MarshalAs(UnmanagedType.LPWStr)] string pszPropertyName, [In] CONDITION_OPERATION cop, [In, MarshalAs(UnmanagedType.LPWStr)] string pszValueType,
				[In] PROPVARIANT ppropvar, IRichChunk richChunk1, IRichChunk richChunk2, IRichChunk richChunk3, [In, MarshalAs(UnmanagedType.Bool)] bool fExpand);

			/// <summary>
			/// Performs a variety of transformations on a condition tree, including the following: resolves conditions with relative
			/// date/time expressions to conditions with absolute date/time (as a VT_FILETIME); turns other recognized named entities into
			/// condition trees with actual values; simplifies condition trees; replaces virtual or compound properties with OR trees of
			/// other properties; removes condition trees resulting from queries with property keywords that had no condition applied.
			/// </summary>
			/// <param name="pc">
			/// <para>Type: <c>ICondition*</c></para>
			/// <para>A pointer to an ICondition object to be resolved.</para>
			/// </param>
			/// <param name="sqro">
			/// <para>Type: <c>STRUCTURED_QUERY_RESOLVE_OPTION</c></para>
			/// <para>
			/// Specifies zero or more of the STRUCTURED_QUERY_RESOLVE_OPTION flags. For <c>Windows 7 and later</c>, the
			/// SQRO_ADD_VALUE_TYPE_FOR_PLAIN_VALUES flag is automatically added to <paramref name="sqro"/>.
			/// </para>
			/// </param>
			/// <param name="pstReferenceTime">
			/// <para>Type: <c>SYSTEMTIME const*</c></para>
			/// <para>
			/// A pointer to a <c>SYSTEMTIME</c> value to use as the reference date and time. A null pointer can be passed if <paramref
			/// name="sqro"/> is set to SQRO_DONT_RESOLVE_DATETIME.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ICondition**</c></para>
			/// <para>
			/// Receives a pointer to the new ICondition in which all time fields have been resolved to have values of type VT_FILETIME. This
			/// new condition tree is the resolved version of <paramref name="pc"/>.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// In a condition tree produced by the Parse method and returned by GetQuery, the leaves pair up properties with restrictions on
			/// these properties, and result in a condition tree that is partially finished. The <c>IConditionFactory::Resolve</c> method
			/// finishes such a condition tree by a process known as resolution. The input condition tree is not modified in any way. The
			/// output condition tree may share parts of the input condition that contained no leaf nodes with unresolved date/time values.
			/// </para>
			/// <para><c>Note</c> Resolving a leaf node often produces a non-leaf node.</para>
			/// <para>
			/// For example, Structured Query supports relative date/time expressions, which remain unresolved until they are applied to some
			/// reference time. In a leaf node with semantic type <c>System.StructuredQueryType.DateTime</c>, the value can be either a
			/// VT_FILETIME or a VT_LPWSTR. VT_FILETIME is an absolute date/time so it is already resolved. VT_LPWSTR is a string
			/// representation of a relative date/time expression. The specified reference time should be a local time, but the resolved
			/// times in the resulting query expression will be in Coordinated Universal Time (UTC).
			/// </para>
			/// <para>
			/// The StructuredQuerySample code sample, available on Code Gallery and the Windows 7 SDK, demonstrates how to read lines from
			/// the console, parse them using the system schema, and display the resulting condition trees.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iconditionfactory-resolve HRESULT
			// Resolve( ICondition *pc, STRUCTURED_QUERY_RESOLVE_OPTION sqro, const SYSTEMTIME *pstReferenceTime, ICondition **ppcResolved );
			new ICondition Resolve([In] ICondition pc, STRUCTURED_QUERY_RESOLVE_OPTION sqro, in SYSTEMTIME pstReferenceTime);

			/// <summary>Retrieves the condition tree and the semantic type of the solution.</summary>
			/// <param name="ppQueryNode">
			/// <para>Type: <c>ICondition**</c></para>
			/// <para>
			/// Receives a pointer to an ICondition condition tree that is the interpretation of the query string. This parameter can be <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="ppMainType">
			/// <para>Type: <c>IEntity**</c></para>
			/// <para>
			/// Receives a pointer to an IEntity object that identifies the semantic type of the interpretation. This parameter can be <c>NULL</c>.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iquerysolution-getquery HRESULT
			// GetQuery( ICondition **ppQueryNode, IEntity **ppMainType );
			void GetQuery(out ICondition ppQueryNode, out IEntity ppMainType);

			/// <summary>
			/// Identifies parts of the input string that the parser did not recognize or did not use when constructing the IQuerySolution
			/// condition tree.
			/// </summary>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>The desired IID of the result, either IID_IEnumUnknown or IID_IEnumVARIANT.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>Receives a pointer to an enumeration of zero or more IRichChunk objects, each describing one parsing error.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Each parsing error is represented by an IRichChunk object in which the position information reflects token counts. The
			/// <c>IRichChunk</c> object <c>ppsz</c> string is <c>NULL</c>, and the pValue is a PROPVARIANT that contains a <c>lVal</c>
			/// identifying the STRUCTURED_QUERY_PARSE_ERROR enumeration.
			/// </para>
			/// <para>The valid values for <paramref name="riid"/> are __uuidof(IEnumUnknown) and __uuidof(IEnumVARIANT).</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iquerysolution-geterrors HRESULT
			// GetErrors( REFIID riid, void **ppParseErrors );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object GetErrors(in Guid riid);

			/// <summary>
			/// Reports the query string, how it was tokenized, and what language code identifier (LCID) and word breaker were used to parse it.
			/// </summary>
			/// <param name="ppszInputString">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>Receives the query string. This parameter can be <c>NULL</c>.</para>
			/// </param>
			/// <param name="ppTokens">
			/// <para>Type: <c>ITokenCollection**</c></para>
			/// <para>
			/// Receives a pointer to an ITokenCollection object that describes how the query was tokenized. This parameter can be <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="plcid">
			/// <para>Type: <c>LCID*</c></para>
			/// <para>Receives a LCID for the word breaker used for this query. This parameter can be <c>NULL</c>.</para>
			/// </param>
			/// <param name="ppWordBreaker">
			/// <para>Type: <c>IUnknown**</c></para>
			/// <para>Receives a pointer to the word breaker used for this query. This parameter can be <c>NULL</c>.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-iquerysolution-getlexicaldata HRESULT
			// GetLexicalData( LPWSTR *ppszInputString, ITokenCollection **ppTokens, LCID *plcid, IUnknown **ppWordBreaker );
			void GetLexicalData([MarshalAs(UnmanagedType.LPWStr)] out string ppszInputString, [Out] out ITokenCollection ppTokens, [Out] out uint plcid,
				[Out, MarshalAs(UnmanagedType.IUnknown)] out object ppWordBreaker);
		}

		/// <summary>Provides methods for retrieving information about a schema property.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nn-structuredquery-irelationship
		[PInvokeData("structuredquery.h")]
		[ComImport, Guid("2769280B-5108-498c-9C7F-A51239B63147"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IRelationship
		{
			/// <summary>Retrieves the name of the relationship.</summary>
			/// <returns>
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>
			/// Receives a pointer to the name of the relationship as a Unicode string. The calling application must free the returned string
			/// by calling CoTaskMemFree.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-irelationship-name HRESULT Name(
			// LPWSTR *ppszName );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string Name();

			/// <summary>Reports whether a relationship is real.</summary>
			/// <returns>
			/// <para>Type: <c>BOOL*</c></para>
			/// <para>Receives <c>TRUE</c> for a real relationship; otherwise, <c>FALSE</c>.</para>
			/// </returns>
			/// <remarks>
			/// A relationship is not considered real if its source entity derives from an entity that has a relationship of the same name.
			/// The purpose of such a "shadow" relationship is to store metadata specific to the inherited relationship.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-irelationship-isreal HRESULT IsReal(
			// BOOL *pIsReal );
			[return: MarshalAs(UnmanagedType.Bool)]
			bool IsReal();

			/// <summary>
			/// Retrieves the destination IEntity object of the relationship. The destination of a relationship corresponds to the type of a property.
			/// </summary>
			/// <returns>
			/// <para>Type: <c>IEntity**</c></para>
			/// <para>
			/// Receives the address of a pointer to an IEntity object, or <c>NULL</c> if the relationship is not real. For more information,
			/// see IRelationship::IsReal.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-irelationship-destination HRESULT
			// Destination( IEntity **pDestinationEntity );
			IEntity Destination();

			/// <summary>Retrieves an enumeration of IMetaData objects for this relationship.</summary>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>The desired IID of the result, either IID_IEnumUnknown or IID_IEnumVARIANT.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>
			/// Receives a pointer to the enumeration of IMetaData objects. There may be multiple pairs with the same key (or the same value).
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-irelationship-metadata HRESULT
			// MetaData( REFIID riid, void **pMetaData );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object MetaData(in Guid riid);

			/// <summary>Retrieves the default phrase to use for this relationship in restatements.</summary>
			/// <returns>
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>Receives the default phrase as a Unicode string. The calling application must free the string by calling CoTaskMemFree.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-irelationship-defaultphrase HRESULT
			// DefaultPhrase( LPWSTR *ppszPhrase );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string DefaultPhrase();
		}

		/// <summary>Provides a method for localizing keywords in a specified string.</summary>
		// https://docs.microsoft.com/en-us/previous-versions//aa965593(v=vs.85)
		[ComImport, Guid("CA3FDCA2-BFBE-4eed-90D7-0CAEF0A1BDA1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISchemaLocalizerSupport
		{
			/// <summary>Localizes keywords from an input string.</summary>
			/// <param name="pszGlobalString">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// Pointer to a null-terminated Unicode string to be localized. It may be in one of two forms: (1) a set of keywords separated
			/// by the vertical bar character (Unicode character code 007C) (for example "date modified|modified|modification date"), or (2)
			/// a string of the form "@some.dll,-12345". This example refers to resource ID 12345 of the some.dll binary. That resource must
			/// be a string of the previous (1) form.
			/// </para>
			/// </param>
			/// <param name="ppszLocalString">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>
			/// Returns a null-terminated Unicode string that is the localized string. The calling application must free the returned string
			/// by calling CoTaskMemFree. If the method does not succeed, this parameter is set to <c>NULL</c>.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if successful, or S_FALSE otherwise.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-ischemalocalizersupport-localize
			// HRESULT Localize( LPCWSTR pszGlobalString, LPWSTR *ppszLocalString );
			[PreserveSig]
			HRESULT Localize([MarshalAs(UnmanagedType.LPWStr)] string pszGlobalString, [MarshalAs(UnmanagedType.LPWStr)] out string ppszLocalString);
		}

		/// <summary>Provides a schema repository that can be browsed.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nn-structuredquery-ischemaprovider
		[PInvokeData("structuredquery.h")]
		[ComImport, Guid("8CF89BCB-394C-49b2-AE28-A59DD4ED7F68"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISchemaProvider
		{
			/// <summary>Retrieves an enumeration of IEntity objects with one entry for each entity in the loaded schema.</summary>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>The desired IID of the result, either IID_IEnumUnknown or IID_IEnumVARIANT.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>
			/// Receives a pointer to an enumeration of entities. The calling application must release it by calling its IUnknown::Release method.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-ischemaprovider-entities HRESULT
			// Entities( REFIID riid, void **pEntities );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object Entities(in Guid riid);

			/// <summary>Retrieves the root entity of the loaded schema.</summary>
			/// <returns>
			/// <para>Type: <c>IEntity**</c></para>
			/// <para>Receives a pointer to the root entity. The calling application must release it by invoking its IUnknown::Release method.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-ischemaprovider-rootentity HRESULT
			// RootEntity( IEntity **pRootEntity );
			IEntity RootEntity();

			/// <summary>Retrieves an entity by name from the loaded schema.</summary>
			/// <param name="pszEntityName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The name of the entity being requested.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>IEntity**</c></para>
			/// <para>
			/// Receives the address of a pointer to the requested entity. The calling application must release the entity by calling its
			/// IUnknown::Release method. If there is no entity with the specified name, this parameter is set to <c>NULL</c>.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-ischemaprovider-getentity HRESULT
			// GetEntity( LPCWSTR pszEntityName, IEntity **pEntity );
			IEntity GetEntity([In, MarshalAs(UnmanagedType.LPWStr)] string pszEntityName);

			/// <summary>Retrieves an enumeration of global IMetaData objects for the loaded schema.</summary>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>The desired IID of the result, either IID_IEnumUnknown or IID_IEnumVARIANT.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>
			/// Receives a pointer to an enumeration of the IMetaData objects. The calling application must release it by calling its
			/// IUnknown::Release method.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-ischemaprovider-metadata HRESULT
			// MetaData( REFIID riid, void **pMetaData );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object MetaData(in Guid riid);

			/// <summary>Localizes the currently loaded schema for a specified locale.</summary>
			/// <param name="lcid">
			/// <para>Type: <c>LCID</c></para>
			/// <para>The locale to localize for.</para>
			/// </param>
			/// <param name="pSchemaLocalizerSupport">The p schema localizer support.</param>
			/// <remarks>
			/// <para>
			/// Before this method is called, the loaded schema should typically be a schema that is not localized, such as the one in
			/// %SYSTEMROOT%\System32\StructuredQuerySchema.bin. This method makes the loaded schema suitable for parsing queries in the
			/// specified locale, using the object specified in the pSchemaLocalizerSupport parameter. The localized schema can then be saved
			/// into a schema binary by calling the ISchemaProvider::SaveBinary method.
			/// </para>
			/// <para>
			/// Most applications should use CreateLoadedParser to obtain a query parser loaded with a localized schema, instead of using
			/// this method explicitly.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-ischemaprovider-localize HRESULT
			// Localize( LCID lcid, ISchemaLocalizerSupport *pSchemaLocalizerSupport );
			void Localize([In] uint lcid, [In] ISchemaLocalizerSupport pSchemaLocalizerSupport);

			/// <summary>Saves the loaded schema as a schema binary at a specified path.</summary>
			/// <param name="pszSchemaBinaryPath">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Pointer to a null-terminated Unicode string that contains the fully qualified path at which to save the schema binary.</para>
			/// </param>
			/// <remarks>Any existing file at the location specified by pszSchemaBinaryPath is overwritten.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-ischemaprovider-savebinary HRESULT
			// SaveBinary( LPCWSTR pszSchemaBinaryPath );
			void SaveBinary([In, MarshalAs(UnmanagedType.LPWStr)] string pszSchemaBinaryPath);

			/// <summary>
			/// Finds named entities of a specified type in a tokenized string, and returns the value of the entity and the number of tokens
			/// the entity value occupies.
			/// </summary>
			/// <param name="pEntity">
			/// <para>Type: <c>IEntity*</c></para>
			/// <para>A pointer to an IEntity object identifying the type of named entity to locate.</para>
			/// </param>
			/// <param name="pszInputString">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>An input string in which to search for named entity keywords.</para>
			/// </param>
			/// <param name="pTokenCollection">
			/// <para>Type: <c>ITokenCollection*</c></para>
			/// <para>A pointer to the tokenization of the string in the pszInputString parameter.</para>
			/// </param>
			/// <param name="cTokensBegin">
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The zero-based position of a token in the pTokenCollection from which to start searching.</para>
			/// </param>
			/// <param name="pcTokensLength">
			/// <para>Type: <c>ULONG*</c></para>
			/// <para>Receives a pointer to the number of tokens covered by the named entity keyword that was found.</para>
			/// </param>
			/// <param name="ppszValue">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>
			/// Receives a pointer to the value of the named entity that was found, as a Unicode string. The caller must free the string by
			/// calling CoTaskMemFree. An INamedEntity object can be obtained by calling the GetNamedEntity method of pEntity and passing the
			/// string that was received in this parameter.
			/// </para>
			/// </param>
			/// <remarks>
			/// The method finds only named entities authored with keywords in the schema, not named entities recognized by an
			/// IConditionGenerator object.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-ischemaprovider-lookupauthorednamedentity
			// HRESULT LookupAuthoredNamedEntity( IEntity *pEntity, LPCWSTR pszInputString, ITokenCollection *pTokenCollection, ULONG
			// cTokensBegin, ULONG *pcTokensLength, LPWSTR *ppszValue );
			void LookupAuthoredNamedEntity([In] IEntity pEntity, [In, MarshalAs(UnmanagedType.LPWStr)] string pszInputString, [In] ITokenCollection pTokenCollection,
				[In] uint cTokensBegin, out uint pcTokensLength, [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszValue);
		}

		/// <summary>Gets the tokens that result from using a word breaker.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nn-structuredquery-itokencollection
		[PInvokeData("structuredquery.h")]
		[ComImport, Guid("22D8B4F2-F577-4adb-A335-C2AE88416FAB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ITokenCollection
		{
			/// <summary>Retrieves the number of tokens in the collection.</summary>
			/// <returns>
			/// <para>Type: <c>ULONG*</c></para>
			/// <para>Receives the number of tokens within the collection.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-itokencollection-numberoftokens
			// HRESULT NumberOfTokens( ULONG *pCount );
			uint NumberOfTokens();

			/// <summary>Retrieves the position, length, and any overriding string of an individual token.</summary>
			/// <param name="i">
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The zero-based index of the desired token within the collection.</para>
			/// </param>
			/// <param name="pBegin">
			/// <para>Type: <c>ULONG*</c></para>
			/// <para>Receives the zero-based starting position of the specified token, in characters. This parameter can be <c>NULL</c>.</para>
			/// </param>
			/// <param name="pLength">
			/// <para>Type: <c>ULONG*</c></para>
			/// <para>Receives the number of characters spanned by the token. This parameter can be <c>NULL</c>.</para>
			/// </param>
			/// <param name="ppsz">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>Receives the overriding text for this token if available, or <c>NULL</c> if there is none.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/structuredquery/nf-structuredquery-itokencollection-gettoken HRESULT
			// GetToken( ULONG i, ULONG *pBegin, ULONG *pLength, LPWSTR *ppsz );
			void GetToken(uint i, out uint pBegin, out uint pLength, [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppsz);
		}

		/// <summary>
		/// Creates a new instance of a IQueryParser interface implementation. This instance of the query parser is loaded with the schema
		/// for the specified catalog and is localized to a specified language. All other settings are initialized to default settings.
		/// </summary>
		/// <typeparam name="T">The type of the IQueryParser interface implementation.</typeparam>
		/// <param name="qpmgr">The <see cref="IQueryParserManager"/> instance.</param>
		/// <param name="pszCatalog">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The name of the catalog to use. Permitted values are and an empty string (for a trivial schema with no properties).</para>
		/// </param>
		/// <param name="langidForKeywords">
		/// <para>Type: <c>LANGID</c></para>
		/// <para>The LANGID used to select the localized language for keywords.</para>
		/// </param>
		/// <returns>
		/// Receives a pointer to the newly created parser. The calling application must release it by calling its IUnknown::Release method.
		/// </returns>
		/// <remarks>
		/// If %LOCALAPPDATA% is not available, then this method fails. You should call IQueryParserManager::SetOption to point to a
		/// different folder like %ProgramData%.
		/// </remarks>
		public static T CreateLoadedParser<T>(this IQueryParserManager qpmgr, string pszCatalog, uint langidForKeywords) where T : class => (T)qpmgr.CreateLoadedParser(pszCatalog, langidForKeywords, typeof(T).GUID);

		/// <summary>Retrieves an enumeration of IEntity objects with one entry for each entity in the loaded schema.</summary>
		/// <typeparam name="T">The desired type of the result, either IID_IEnumUnknown or IID_IEnumVARIANT.</typeparam>
		/// <param name="sp">The <see cref="ISchemaProvider"/> instance.</param>
		/// <returns>
		/// Receives a pointer to an enumeration of entities. The calling application must release it by calling its IUnknown::Release method.
		/// </returns>
		public static T Entities<T>(this ISchemaProvider sp) => (T)sp.Entities(typeof(T).GUID);

		/// <summary>
		/// Identifies parts of the input string that the parser did not recognize or did not use when constructing the IQuerySolution
		/// condition tree.
		/// </summary>
		/// <typeparam name="T">The desired type of the result, either IID_IEnumUnknown or IID_IEnumVARIANT.</typeparam>
		/// <param name="qs">The <see cref="IQuerySolution"/> instance.</param>
		/// <returns>
		/// <para>Type: <c>void**</c></para>
		/// <para>Receives a pointer to an enumeration of zero or more IRichChunk objects, each describing one parsing error.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Each parsing error is represented by an IRichChunk object in which the position information reflects token counts. The
		/// <c>IRichChunk</c> object <c>ppsz</c> string is <c>NULL</c>, and the pValue is a PROPVARIANT that contains a <c>lVal</c>
		/// identifying the STRUCTURED_QUERY_PARSE_ERROR enumeration.
		/// </para>
		/// <para>The valid values for <paramref name="riid"/> are __uuidof(IEnumUnknown) and __uuidof(IEnumVARIANT).</para>
		/// </remarks>
		public static IEnumerable<IRichChunk> GetErrors(this IQuerySolution qs) => ((IEnumUnknown)qs.GetErrors(typeof(IEnumUnknown).GUID)).Enumerate<IRichChunk>();

		/// <summary>Retrieves an enumeration of IMetaData objects for this entity.</summary>
		/// <typeparam name="T">The desired type of the result, either IID_IEnumUnknown or IID_IEnumVARIANT.</typeparam>
		/// <param name="e">The <see cref="IEntity"/> instance.</param>
		/// <returns>Receives the address of a pointer to an enumeration of IMetaData objects.</returns>
		public static T MetaData<T>(this IEntity e) where T : class => (T)e.MetaData(typeof(T).GUID);

		/// <summary>Retrieves an enumeration of IMetaData objects for this relationship.</summary>
		/// <typeparam name="T">The desired type of the result, either IID_IEnumUnknown or IID_IEnumVARIANT.</typeparam>
		/// <param name="r">The <see cref="IRelationship"/> instance.</param>
		/// <returns>
		/// Receives a pointer to the enumeration of IMetaData objects. There may be multiple pairs with the same key (or the same value).
		/// </returns>
		public static T MetaData<T>(this IRelationship r) where T : class => (T)r.MetaData(typeof(T).GUID);

		/// <summary>Retrieves an enumeration of global IMetaData objects for the loaded schema.</summary>
		/// <typeparam name="T">The desired type of the result, either IID_IEnumUnknown or IID_IEnumVARIANT.</typeparam>
		/// <param name="sp">The <see cref="ISchemaProvider"/> instance.</param>
		/// <returns>
		/// Receives a pointer to an enumeration of the IMetaData objects. The calling application must release it by calling its
		/// IUnknown::Release method.
		/// </returns>
		public static T MetaData<T>(this ISchemaProvider sp) => (T)sp.MetaData(typeof(T).GUID);

		/// <summary>Retrieves an enumeration of INamedEntity objects, one for each known named entity of this type.</summary>
		/// <typeparam name="T">The desired type of the result, either IID_IEnumUnknown or IID_IEnumVARIANT.</typeparam>
		/// <param name="e">The <see cref="IEntity"/> instance.</param>
		/// <returns>
		/// Receives the address of a pointer to an enumeration of INamedEntity objects, one for each known named entity of this type.
		/// </returns>
		public static T NamedEntities<T>(this IEntity e) where T : class => (T)e.NamedEntities(typeof(T).GUID);

		/// <summary>Retrieves an enumeration of IRelationship objects, one for each relationship this entity has.</summary>
		/// <typeparam name="T">The desired type of the result, either IID_IEnumUnknown or IID_IEnumVARIANT.</typeparam>
		/// <param name="e">The <see cref="IEntity"/> instance.</param>
		/// <returns>Receives the address of a pointer to the enumeration of the IRelationship objects.</returns>
		public static T Relationships<T>(this IEntity e) where T : class => (T)e.Relationships(typeof(T).GUID);

		/// <summary>
		/// Performs a variety of transformations on a condition tree, and thereby the resolved condition for evaluation. The returned
		/// object supports ICondition and ICondition2.
		/// </summary>
		/// <typeparam name="T">The desired type of the result, either ICondition or ICondition2.</typeparam>
		/// <param name="f2">The IConditionFactory2 instance.</param>
		/// <param name="pc"><para>Type: <c>ICondition*</c></para>
		/// <para>Pointer to an ICondition object to be resolved.</para></param>
		/// <param name="sqro"><para>Type: <c>STRUCTURED_QUERY_RESOLVE_OPTION</c></para>
		/// <para>
		/// Specifies zero or more of the STRUCTURED_QUERY_RESOLVE_OPTION flags. The SQRO_NULL_VALUE_TYPE_FOR_PLAIN_VALUES flag is
		/// automatically added to sqro.
		/// </para></param>
		/// <returns></returns>
		public static T ResolveCondition<T>(this IConditionFactory2 f2, ICondition pc, STRUCTURED_QUERY_RESOLVE_OPTION sqro = 0) where T : class
		{
			Kernel32.GetLocalTime(out var st);
			return (T)f2.ResolveCondition(pc, sqro, st, typeof(T).GUID);
		}

		/// <summary>Class interface for ICondition</summary>
		[ComImport, Guid("116F8D13-101E-4fa5-84D4-FF8279381935"), ClassInterface(ClassInterfaceType.None)]
		public class CompoundCondition { }

		/// <summary>Class interface for IConditionFactory</summary>
		[ComImport, Guid("E03E85B0-7BE3-4000-BA98-6C13DE9FA486"), ClassInterface(ClassInterfaceType.None)]
		public class ConditionFactory { }

		/// <summary>Class interface for ICondition</summary>
		[ComImport, Guid("52F15C89-5A17-48e1-BBCD-46A3F89C7CC2"), ClassInterface(ClassInterfaceType.None)]
		public class LeafCondition { }

		/// <summary>Class interface for ICondition</summary>
		[ComImport, Guid("8DE9C74C-605A-4acd-BEE3-2B222AA2D23D"), ClassInterface(ClassInterfaceType.None)]
		public class NegationCondition { }

		/// <summary>Class interface for IQueryParser</summary>
		[ComImport, Guid("B72F8FD8-0FAB-4dd9-BDBF-245A6CE1485B"), ClassInterface(ClassInterfaceType.None)]
		public class QueryParser { }

		/// <summary>Class interface for IQueryParserManager</summary>
		[ComImport, Guid("5088B39A-29B4-4d9d-8245-4EE289222F66"), ClassInterface(ClassInterfaceType.None)]
		public class QueryParserManager { }
	}
}