using System.Collections.Generic;

namespace Vanara.PInvoke;

/// <summary>Helper methods for dealing with failure results.</summary>
public static class FailedHelper
{
	private static readonly List<HRESULT> errors = FunctionHelper.buffErrs.ConvertAll(e => (HRESULT)e);

	/// <summary>Determines whether the specified result indicates a failure.</summary>
	/// <remarks>
	/// This method evaluates the specified result by converting it to a boolean value using the <see
	/// cref="IConvertible.ToBoolean(IFormatProvider)"/> method. The interpretation of the result depends on the implementation of the <see
	/// cref="IConvertible"/> interface for the type <typeparamref name="T"/>.
	/// </remarks>
	/// <typeparam name="T">The type of the result, which must be an unmanaged type and implement <see cref="IConvertible"/>.</typeparam>
	/// <param name="r">The result to evaluate. The result is converted to a boolean value to determine success or failure.</param>
	/// <param name="ignoreBufErr">
	/// A boolean value indicating whether buffer-related errors should be ignored. If <see langword="true"/>, buffer-related errors are not
	/// considered failures; otherwise, they are.
	/// </param>
	/// <returns><see langword="true"/> if the result indicates a failure; otherwise, <see langword="false"/>.</returns>
	public static bool FAILED<T>(T r, bool ignoreBufErr = false)
	{
		return r switch
		{
			bool b => !b && IErrFail(Win32Error.GetLastError()),
			IErrorProvider hr => IErrFail(hr),
			IHandle h => h.IsInvalid && IErrFail(Win32Error.GetLastError()),
			IConvertible c => !c.ToBoolean(null) && IErrFail(Win32Error.GetLastError()),
			_ => throw new ArgumentException("Type must be bool, IHandle, or IConvertible.", nameof(r)),
		};
		bool IErrFail(IErrorProvider hr) => hr.Failed && (!ignoreBufErr || !errors.Contains(hr.ToHRESULT()));
	}
}
