namespace Vanara.PInvoke;

//static partial class SizeDefTestMethods
//{
//	static partial void Func1([SizeDef("len", SizingMethod.Count /* default */)] StringBuilder? sb, [Range(0, 50)] int len);
//	static partial void Func2([SizeDef("len", SizingMethod.Count | SizingMethod.Bytes)] StringBuilder? sb, [Range(0, 50)] int len);
//	static partial void Func3([SizeDef("len", SizingMethod.Count | SizingMethod.Bytes | SizingMethod.InclNullTerm)] StringBuilder? sb, [Range(0, 50)] int len);
//	static partial void Func4([SizeDef("len", SizingMethod.Query)] StringBuilder? sb, [Range(0, 50)] ref int len);
//	static partial void Func5([SizeDef("len", SizingMethod.Query | SizingMethod.Bytes)] StringBuilder? sb, [Range(0, 50)] ref int len);
//	static partial void Func6([SizeDef("len", SizingMethod.Query, OutVarName = "lenReq")] StringBuilder? sb, [Range(0, 50)] int len, out int lenReq);

//	static partial void Func7([SizeDef("len", SizingMethod.Count /* default */)] int[]? arr, [Range(0, 50)] int len);
//	static partial void Func8([SizeDef("len", SizingMethod.Count | SizingMethod.Bytes)] int[]? arr, [Range(0, 50)] int len);
//	static partial void Func11([SizeDef("len", SizingMethod.Query)] int[]? arr, [Range(0, 50)] ref int len);
//	static partial void Func12([SizeDef("len", SizingMethod.Query | SizingMethod.Bytes)] int[]? arr, [Range(0, 50)] ref int len);
//	static partial void Func13([SizeDef("len", SizingMethod.Query, OutVarName = "lenReq")] int[]? arr, [Range(0, 50)] int len, out int lenReq);
//}

/// <summary>Specifies the method used to determine the size of a field or array.</summary>
[Flags]
public enum SizingMethod
{
	/// <summary>Size is determined by the size of the field.</summary>
	Count = 0x0,

	/// <summary>Size is determined by the size of the array.</summary>
	Bytes = 0x1,

	/// <summary>Size includes the null terminator.</summary>
	InclNullTerm = 0x2,

	/// <summary>Size is determined by a query to the field.</summary>
	Query = 0x4,

	/// <summary>Size is returned as the result of the method.</summary>
	QueryResultInReturn = 0x8,

	/// <summary>Size is determined by checking the last error after a query for ERROR_INSUFFICIENT_BUFFER.</summary>
	CheckLastError = 0x10,
}

/// <summary>
/// <note type="implement">This attribute does not yet have an implemented generator.</note>
/// Attribute to indicate the size of a string or array field or parameter.</summary>
[System.AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
public sealed class SizeDefAttribute(string refVarName, SizingMethod method = SizingMethod.Count) : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="SizeDefAttribute"/> class using a fixed size.</summary>
	public SizeDefAttribute(int count) : this(count.ToString()) { }

	/// <summary>
	/// Gets or sets the name of a variable that receives the buffer size. This should only be used when the <see cref="RefVarName"/> value
	/// holds the field or parameter with the count of elements and another variable holds the size of the buffer for all of the array in bytes.
	/// </summary>
	public string? BufferVarName { get; set; } = null;

	/// <summary>Gets the sizing method used to determine the size of an element.</summary>
	public SizingMethod Method { get; } = method;

	/// <summary>
	/// Gets or sets the name of the variable that receives the required size of the field or parameter after a query. This value is
	/// initialized to the value of <see cref="RefVarName"/>.
	/// </summary>
	public string OutVarName { get; set; } = refVarName;

	/// <summary>Gets the name of the reference variable.</summary>
	public string RefVarName { get; } = refVarName;
}

/// <summary>Attribute to indicate that a field or parameter should be ignored when generating code.</summary>
[System.AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
public sealed class IgnoreAttribute() : Attribute
{
}