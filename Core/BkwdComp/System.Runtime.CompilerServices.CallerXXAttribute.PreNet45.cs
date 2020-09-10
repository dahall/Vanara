#if (NET20 || NET35 || NET40)
namespace System.Runtime.CompilerServices
{
	/// <summary>
	/// Allows you to obtain the full path of the source file that contains the caller. This is the file path at the time of compile.
	/// </summary>
	/// <seealso cref="System.Attribute"/>
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
	public class CallerFilePathAttribute : Attribute
	{
	}

	/// <summary>Allows you to obtain the line number in the source file at which the method is called.</summary>
	/// <seealso cref="System.Attribute"/>
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
	public class CallerLineNumberAttribute : Attribute
	{
	}

	/// <summary>Allows you to obtain the method or property name of the caller to the method.</summary>
	/// <seealso cref="System.Attribute"/>
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
	public class CallerMemberNameAttribute : Attribute
	{
	}
}
#endif