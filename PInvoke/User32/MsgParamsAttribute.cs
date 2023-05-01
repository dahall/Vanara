using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vanara.Extensions;
using Vanara.Extensions.Reflection;

namespace Vanara.PInvoke;

public class MsgParamsAttribute : Attribute
{
	public MsgParamsAttribute(Type? wParamType, Type? lParamType)
	{
		WParamType = wParamType;
		LParamType = lParamType;
		WParamByRef = wParamType?.IsClass ?? false;
		LParamByRef = lParamType?.IsClass ?? false;
	}

	public MsgParamsAttribute()
	{
		WParamType = LParamType = null;
		WParamByRef = LParamByRef = false;
	}

	public Type? WParamType { get; }
	public bool WParamByRef { get; set; }
	public Type? LParamType { get; }
	public bool LParamByRef { get; set; }
}

public static class MsgExtensions
{
	public static (object? wParam, object? lParam) GetParams<TEnum>(this MSG msg) where TEnum : Enum
	{
		MsgParamsAttribute? attr = typeof(TEnum).GetCustomAttribute<MsgParamsAttribute>();
		if (attr is null || (attr.WParamType == typeof(IntPtr) && attr.LParamType == typeof(IntPtr)))
			return (msg.wParam, msg.lParam);
		else
		{
			object? wParam = attr.WParamType is null ? null : attr.WParamByRef ? msg.wParam.ToStructure(attr.WParamType) : msg.wParam.ToInt32().ConvertTo(attr.WParamType);
			object? lParam = attr.LParamType is null ? null : attr.LParamByRef ? msg.lParam.ToStructure(attr.LParamType) : msg.lParam.ToInt32().ConvertTo(attr.LParamType);
			return (wParam, lParam);
		}
	}
}