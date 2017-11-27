#if (NET20)
namespace System
{
	/// <summary>Encapsulates a method that returns a value of the type specified by the TResult parameter.</summary>
	/// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
	/// <returns>The return value of the method that this delegate encapsulates.</returns>
	public delegate TResult Func<out TResult>();

	/// <summary>Encapsulates a method that has one parameter and returns a value of the type specified by the TResult parameter.</summary>
	/// <typeparam name="T">The type of the parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg">The parameter of the method that this delegate encapsulates.</param>
	/// <returns>The return value of the method that this delegate encapsulates.</returns>
	public delegate TResult Func<in T, out TResult>(T arg);

	/// <summary>Encapsulates a method that has two parameters and returns a value of the type specified by the TResult parameter.</summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <returns>The return value of the method that this delegate encapsulates.</returns>
	public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);

	/// <summary>Encapsulates a method that has no parameters and does not return a value.</summary>
	public delegate void Action();

	/// <summary>Encapsulates a method that has two parameters and does not return a value.</summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);
}
#endif