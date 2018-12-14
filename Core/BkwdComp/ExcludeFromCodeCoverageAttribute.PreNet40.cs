#if (NET20 || NET35 || NETCOREAPP1_0 || NETCOREAPP1_1)
namespace System.Diagnostics.CodeAnalysis
{
	/// <summary>Compensates for missing attribute in .NET 2.0</summary>
	/// <seealso cref="System.Attribute"/>
	public class ExcludeFromCodeCoverageAttribute : Attribute
	{
	}
}
#endif