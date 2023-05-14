using System;
using System.Reflection;
using Vanara.Extensions;
using Vanara.Extensions.Reflection;

namespace Vanara.PInvoke;

/// <summary>
/// Use this attribute to specify the types of the wParam and lParam values of a message. If not specified, the default is IntPtr for both.
/// </summary>
/// <seealso cref="System.Attribute"/>
public class MsgParamsAttribute : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="MsgParamsAttribute"/> class.</summary>
	/// <param name="wParamType">Type of the wParam.</param>
	/// <param name="lParamType">Type of the lParam.</param>
	public MsgParamsAttribute(Type? wParamType, Type? lParamType)
	{
		WParamType = wParamType;
		LParamType = lParamType;
	}

	/// <summary>Initializes a new instance of the <see cref="MsgParamsAttribute"/> class.</summary>
	public MsgParamsAttribute() => WParamType = LParamType = null;

	/// <summary>Gets or sets the type of the lParam.</summary>
	/// <value>The type of the lParam.</value>
	public Type? LParamType { get; set; }

	/// <summary>Gets or sets the type of the LRESULT.</summary>
	/// <value>The type of the LRESULT.</value>
	public Type? LResultType { get; set; } = typeof(int);

	/// <summary>Gets or sets the type of the wParam.</summary>
	/// <value>The type of the wParam.</value>
	public Type? WParamType { get; set; }
}

/// <summary></summary>
public static class MsgExtensions
{
	/// <summary>Gets the parameters for a message using the <see cref="MsgParamsAttribute"/> associated with the message.</summary>
	/// <typeparam name="TEnum">The type of the message enum.</typeparam>
	/// <param name="msg">The MSG value.</param>
	/// <returns>The wParam and lParam in a tuple tied to their assigned value types.</returns>
	public static (object? wParam, object? lParam) GetParams<TEnum>(this MSG msg) where TEnum : Enum
	{
		MsgParamsAttribute? attr = typeof(TEnum).GetCustomAttribute<MsgParamsAttribute>();
		if (attr is null || attr.WParamType == typeof(IntPtr) && attr.LParamType == typeof(IntPtr))
		{
			return (msg.wParam, msg.lParam);
		}
		else
		{
			object? wParam = attr.WParamType is null ? null : attr.WParamType.IsNullable() ? msg.wParam.ToStructure(attr.WParamType) : msg.wParam.ToInt32().CastTo(attr.WParamType);
			object? lParam = attr.LParamType is null ? null : attr.LParamType.IsNullable() ? msg.lParam.ToStructure(attr.LParamType) : msg.lParam.ToInt32().CastTo(attr.LParamType);
			return (wParam, lParam);
		}
	}
}