namespace Vanara;

/// <summary>Interface representing a class that holds an indexer.</summary>
/// <typeparam name="TVal">The type of the indexer's value.</typeparam>
/// <typeparam name="TRet">The type of the indexer's return value.</typeparam>
public interface ISupportIndexer<TVal, TRet>
{
	/// <summary>Gets or sets the <typeparamref name="TRet"/> with the specified <typeparamref name="TVal"/>.</summary>
	/// <value>The <typeparamref name="TRet"/>.</value>
	/// <returns>The <typeparamref name="TVal"/>.</returns>
	TRet this[TVal index] { get; set; }
}