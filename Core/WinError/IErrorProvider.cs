namespace Vanara.PInvoke;

/// <summary>Common properties and methods for errors.</summary>
public interface IErrorProvider
{
	/// <summary>Gets a value indicating whether this error represents a failure.</summary>
	/// <value><see langword="true" /> if failed; otherwise, <see langword="false" />.</value>
	bool Failed { get; }

	/// <summary>Gets a value indicating whether this error represents a success.</summary>
	/// <value><see langword="true" /> if succeeded; otherwise, <see langword="false" />.</value>
	bool Succeeded { get; }

	/// <summary>Gets an <see cref="Exception"/> from this error.</summary>
	/// <param name="message">An optional message to add to the exception.</param>
	/// <returns>
	/// A correlated <see cref="Exception"/> for this error if <see cref="Failed"/> is <see langword="true"/>; otherwise the method returns
	/// <see langword="null"/>.
	/// </returns>
	Exception? GetException(string? message = null);

	/// <summary>Throws an equivalent <c>Exception</c> for this error if it is a failure.</summary>
	/// <param name="message">An optional message to add to the exception.</param>
	void ThrowIfFailed(string? message = null);

	/// <summary>Converts this error to an <see cref="HRESULT"/>.</summary>
	/// <returns>An equivalent <see cref="HRESULT"/>.</returns>
	HRESULT ToHRESULT();
}

/// <summary>Common properties and methods for errors with comparitors.</summary>
public interface IErrorProvider2<TSelf> : IErrorProvider, IComparable, IComparable<TSelf>, IConvertible, IEquatable<TSelf> where TSelf : IErrorProvider2<TSelf>
{
}