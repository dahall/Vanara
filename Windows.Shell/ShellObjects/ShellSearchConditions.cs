using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.SearchApi;

namespace Vanara.Windows.Shell
{
	/// <summary>Provides properties and methods for retrieving information about a search condition.</summary>
	/// <seealso cref="System.ICloneable"/>
	public class SearchCondition : ICloneable, IDisposable
	{
		internal ICondition condition;
		private const string systemCatalog = "SystemIndex";

		internal SearchCondition(ICondition c) => condition = c;

		/// <summary>Gets the CLSID for the search condition.</summary>
		/// <value>The CLSID.</value>
		public Guid CLSID => condition.GetClassID();

		/// <summary>Retrieves the property name, operation, and value from a leaf search condition node.</summary>
		/// <value>The comparison information.</value>
		public (string propName, CONDITION_OPERATION op, object propValue) ComparisonInfo
		{
			get
			{
				var pv = new PROPVARIANT();
				condition.GetComparisonInfo(out var n, out var o, pv);
				return (n, o, pv.Value);
			}
		}

		/// <summary>
		/// Retrieves the condition type for this search condition node, identifying it as a logical AND, OR, or NOT, or as a leaf node.
		/// </summary>
		public CONDITION_TYPE ConditionType => condition.GetConditionType();

		/// <summary>Retrieves the property name, operation, and value from a leaf search condition node.</summary>
		/// <value>The leaf condition information.</value>
		public (PROPERTYKEY propKey, CONDITION_OPERATION op, object propValue) LeafConditionInfo
		{
			get
			{
				var pv = new PROPVARIANT();
				((ICondition2)condition).GetLeafConditionInfo(out var n, out var o, pv);
				return (n, o, pv.Value);
			}
		}

		/// <summary>Retrieves the size of the stream needed to save the object.</summary>
		/// <value>The size in bytes of the stream needed to save this object, in bytes.</value>
		public long MaxSize => (long)condition.GetSizeMax();

		/// <summary>
		/// Retrieves a collection of the subconditions of the search condition node and the IID of the interface for enumerating the collection.
		/// </summary>
		/// <value>
		/// A collection of zero or more SearchCondition objects. Each object is a subcondition of this condition node. If this is a negation
		/// condition, this parameter receives the single subcondition.
		/// </value>
		public IEnumerable<SearchCondition> SubConditions => condition.GetSubConditions<IEnumUnknown>().Enumerate<ICondition>().Select(ic => new SearchCondition(ic));

		/// <summary>Retrieves the character-normalized value of the search condition node.</summary>
		/// <value>The normalized value of the condition.</value>
		public string ValueNormalization => condition.GetValueNormalization();

		/// <summary>Retrieves the semantic type of the value of the search condition node.</summary>
		/// <value>The semantic type of the value.</value>
		public string ValueType => condition.GetValueType();

		/// <summary>Creates a condition node that is a logical conjunction (AND) or disjunction (OR) of a collection of subconditions.</summary>
		/// <param name="conditionType">
		/// The CONDITION_TYPE of the condition node. The CONDITION_TYPE must be either CT_AND_CONDITION or CT_OR_CONDITION.
		/// </param>
		/// <param name="simplify">
		/// <see langword="true"/> to logically simplify the result, if possible; then the result will not necessarily to be of the specified
		/// kind. <see langword="false"/> if the result should have exactly the prescribed structure.
		/// <para>
		/// An application that plans to execute a query based on the condition tree would typically benefit from setting this parameter to <see langword="true"/>.
		/// </para>
		/// </param>
		/// <param name="subconditions">The SearchCondition sub-objects. This list can be left empty.</param>
		/// <returns>The new <see cref="SearchCondition"/> node.</returns>
		public static SearchCondition CreateAndOrCondition(CONDITION_TYPE conditionType, bool simplify, params SearchCondition[] subconditions)
		{
			using var ifactory = ComReleaserFactory.Create(new IConditionFactory());
			var ienumunk = new IEnumUnknownImpl<ICondition>(subconditions.Select(c => c.condition));
			var icond = ifactory.Item.MakeAndOr(conditionType, ienumunk, simplify);
			return new SearchCondition(icond);
		}

		/// <summary>Creates a condition node from a structured query.</summary>
		/// <param name="query">An input string to be parsed.</param>
		/// <param name="cultureInfo">Used to select the localized language for keywords. By default, the current UI culture is used.</param>
		/// <returns>The new <see cref="SearchCondition"/> node.</returns>
		public static SearchCondition CreateFromStructuredQuery(string query, CultureInfo cultureInfo = null)
		{
			if (cultureInfo is null) cultureInfo = CultureInfo.CurrentUICulture;
			using var qm = ComReleaserFactory.Create(new IQueryParserManager());
			using var qp = ComReleaserFactory.Create(qm.Item.CreateLoadedParser<IQueryParser>(systemCatalog, (uint)cultureInfo.LCID));
			qm.Item.InitializeOptions(false, true, qp.Item);
			using var qs = ComReleaserFactory.Create(qp.Item.Parse(query));
			qs.Item.GetQuery(out var pc, out _);
			using var rpc = ComReleaserFactory.Create(pc);
			if (Environment.OSVersion.Version >= new Version(6, 1))
			{
				using var pcf = ComReleaserFactory.Create((IConditionFactory2)qs.Item);
				return new SearchCondition(pcf.Item.ResolveCondition<ICondition>(pc));
			}
			else
			{
				Kernel32.GetLocalTime(out var st);
				return new SearchCondition(qs.Item.Resolve(pc, STRUCTURED_QUERY_RESOLVE_OPTION.SQRO_DONT_SPLIT_WORDS, st));
			}
		}

		/// <summary>Creates a leaf condition node that represents a comparison of property value and constant value.</summary>
		/// <typeparam name="T">The type of the property value.</typeparam>
		/// <param name="propertyName">
		/// The name of a property to be compared, or <see langword="null"/> for an unspecified property. The locale name of the leaf node is LOCALE_NAME_USER_DEFAULT.
		/// </param>
		/// <param name="value">The constant value against which the property value should be compared.</param>
		/// <param name="operation">A CONDITION_OPERATION enumeration.</param>
		/// <returns>The new <see cref="SearchCondition"/> node.</returns>
		public static SearchCondition CreateLeafCondition<T>(string propertyName, T value, CONDITION_OPERATION operation)
		{
			using var ifactory = ComReleaserFactory.Create(new IConditionFactory());
			if (string.IsNullOrEmpty(propertyName) || propertyName.ToUpperInvariant() == "SYSTEM.NULL")
				propertyName = null;
			var pv = new PROPVARIANT(value);
			var valType = pv.VarType switch
			{
				VarEnum.VT_I4 => "System.StructuredQuery.CustomProperty.Integer",
				VarEnum.VT_R8 => "System.StructuredQuery.CustomProperty.FloatingPoint",
				VarEnum.VT_DATE => "System.StructuredQuery.CustomProperty.DateTime",
				VarEnum.VT_BOOL => "System.StructuredQuery.CustomProperty.Boolean",
				VarEnum.VT_LPWSTR => null,
				_ => throw new ArgumentException("Type cannot be used as a condition.", nameof(value)),
			};
			var icond = ifactory.Item.MakeLeaf(propertyName, operation, valType, pv);
			return new SearchCondition(icond);
		}

		/// <summary>Creates a condition node that is a logical negation (NOT) of another condition (a subnode of this node).</summary>
		/// <param name="conditionToNegate">The condition to negate.</param>
		/// <param name="simplify">
		/// <see langword="true"/> to logically simplify the result if possible; <see langword="false"/> otherwise. In a query builder
		/// scenario, <paramref name="simplify"/> should typically be set to <see langword="false"/>.
		/// </param>
		/// <returns>The new <see cref="SearchCondition"/> node.</returns>
		/// <exception cref="ArgumentNullException">conditionToNegate</exception>
		public static SearchCondition CreateNotCondition(SearchCondition conditionToNegate, bool simplify)
		{
			using var ifactory = ComReleaserFactory.Create(new IConditionFactory());
			var icond = ifactory.Item.MakeNot(conditionToNegate?.condition ?? throw new ArgumentNullException(nameof(conditionToNegate)), simplify);
			return new SearchCondition(icond);
		}

		/// <summary>Creates a deep copy of this instance.</summary>
		/// <returns>A copy of this search condition.</returns>
		public SearchCondition Clone() => new SearchCondition(condition.Clone());

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			condition = null;
		}

		/// <summary>Gets the results of the condition by level.</summary>
		/// <returns>An enumeration of the leaf nodes with their level and data.</returns>
		public IEnumerable<(int level, string propName, string semanticType, object propVar)> GetLeveledResults() => GetResults(condition);

		private static IEnumerable<(int level, string propName, string semanticType, object propVar)> GetResults(ICondition pc, int l = 0)
		{
			switch (pc.GetConditionType())
			{
				case CONDITION_TYPE.CT_AND_CONDITION:
				case CONDITION_TYPE.CT_OR_CONDITION:
					foreach (var pcsub in pc.GetSubConditions<IEnumUnknown>().Enumerate<ICondition>().Where(i => i != null))
						foreach (var r in GetResults(pcsub, l + 1))
							yield return r;
					break;

				case CONDITION_TYPE.CT_NOT_CONDITION:
					foreach (var r in GetResults(pc.GetSubConditions<ICondition>(), l + 1))
						yield return r;
					break;

				case CONDITION_TYPE.CT_LEAF_CONDITION:
					var propvar = new PROPVARIANT();
					((ICondition2)pc).GetLeafConditionInfo(out var propkey, out _, propvar);
					yield return (l, propkey.GetCanonicalName(), pc.GetValueType() ?? "", propvar.Value);
					break;

				default:
					break;
			}

		}

		object ICloneable.Clone() => Clone();
	}
}