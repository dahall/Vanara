using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Vanara.Extensions.Reflection;

namespace Vanara.PInvoke;

/// <summary>
/// Use this attribute to specify the types of the wParam and lParam values of a message. If not specified, the default is IntPtr for both.
/// </summary>
/// <seealso cref="Attribute"/>
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

/// <summary>Extension methods to help process window message enum values into their identified values in <see cref="MsgParamsAttribute"/>.</summary>
public static class MsgExtensions
{
	/// <summary>Gets the parameters for a message using the <see cref="MsgParamsAttribute"/> associated with the message.</summary>
	/// <typeparam name="TEnum">The type of the message enum.</typeparam>
	/// <param name="msg">The MSG value.</param>
	/// <returns>The wParam and lParam in a tuple tied to their assigned value types.</returns>
	public static (object? wParam, object? lParam) GetParams<TEnum>(this MSG msg) where TEnum : unmanaged, Enum
	{
		TEnum value = msg.message.ToEnum<TEnum>();
		FieldInfo? fieldInfo = value.GetType().GetField(value.ToString());
		MsgParamsAttribute? attr = fieldInfo?.GetCustomAttributes<MsgParamsAttribute>(false).FirstOrDefault();
		if (attr is null || attr.WParamType == typeof(IntPtr) && attr.LParamType == typeof(IntPtr))
		{
			return (msg.wParam, msg.lParam);
		}
		else
		{
			return (GetParam(attr.WParamType, msg.wParam), GetParam(attr.LParamType, msg.lParam));
		}

		static object? GetParam(Type? t, IntPtr p)
		{
			if (t is null || p == IntPtr.Zero)
				return null;
			if (typeof(MulticastDelegate).IsAssignableFrom(t.BaseType))
				return Marshal.GetDelegateForFunctionPointer(p, t);
			if (t.IsArray)
				throw new Exception("Array types are not supported.");
			if (t == typeof(string))
				return StringHelper.GetString(p);
			if (t.IsClass)
				return p.ToStructure(t);
			if (t.IsNullable())
				return p.ToStructure(t.GetGenericArguments()[0]);
			return p.CastTo(t);
		}
	}
}