#if (NET20 || NET35)
namespace System.Diagnostics.CodeAnalysis
{
	/// <summary>Compensates for missing attribute in .NET 2.0</summary>
	/// <seealso cref="System.Attribute"/>
	public class ExcludeFromCodeCoverageAttribute : Attribute
	{
	}
}
#endif