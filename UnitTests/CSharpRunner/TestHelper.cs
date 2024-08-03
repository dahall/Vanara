﻿using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using Vanara.Windows.Shell;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests;

public static class TestHelper
{
	private const string testApp = @"C:\Users\dahal\OneDrive\Documents\Visual Studio 2017\Projects\TestSysConsumption\bin\Debug\net6.0\TestSysConsumption.exe";

	private static readonly Lazy<JsonSerializerSettings> jsonSet = new(() =>
		new JsonSerializerSettings()
		{
			Converters = new JsonConverter[] { new Newtonsoft.Json.Converters.StringEnumConverter(),
				new Newtonsoft.Json.Converters.BinaryConverter(),
				new GenJsonConverter<ulong, SizeT>(i => new SizeT(i), o => o.Value),
				new GenJsonConverter<DateTime, FILETIME>(dt => dt.ToFileTimeStruct(), ft => ft.ToDateTime()),
				new GenJsonConverter<string, IPAddress>(i => IPAddress.Parse(i), o => o.ToString()),
				new GenJsonConverter<string, GenericSecurityDescriptor>(i => new RawSecurityDescriptor(i), o => o.GetSddlForm(AccessControlSections.All)),
				new GenJsonConverter<string, IndirectString>(i => new(i), o => o.ToString()),
				new GenJsonConverter<string, SecurityIdentifier>(i => new(i), o => o.ToString()),
			},
			ReferenceLoopHandling = ReferenceLoopHandling.Serialize
		});

	/// <summary>Gets a value indicating whether the current process is elevated.</summary>
	/// <value><see langword="true"/> if the current process is elevated; otherwise, <see langword="false"/>.</value>
	public static bool IsElevated
	{
		get
		{
			try
			{
				// Open the access token of the current process with TOKEN_QUERY.
				using var hObject = SafeHTOKEN.FromProcess(Process.GetCurrentProcess(), TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_DUPLICATE);
				return hObject.IsElevated;
			}
			catch { }
			return false;
		}
	}

	public static void DumpStructSizeAndOffsets<T>() where T : struct
	{
		TestContext.WriteLine($"{typeof(T).Name} : {Marshal.SizeOf<T>()} ({IntPtr.Size * 8}b/{(Marshal.SystemDefaultCharSize == 1 ? "A" : "W")})");
		foreach (FieldInfo fi in typeof(T).GetOrderedFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
			TestContext.WriteLine($"  {fi.Name} : {Marshal.OffsetOf<T>(fi.Name)}");
	}

	public static IList<string> GetNestedStructSizes(this Type type, params string[] filters) =>
		type.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic).GetStructSizes(false, filters);

	public static string GetStringVal(this object value, bool showDefVals = true, bool bypassMemDump = false)
	{
		switch (value)
		{
			case null:
				return "(null)";

			case FILETIME ft:
				value = ft.ToDateTime();
				goto Simple;

			case SYSTEMTIME st:
				value = st.ToDateTime(DateTimeKind.Local);
				goto Simple;

			case DateTime:
			case decimal:
			case var v when v.GetType().IsPrimitive || v.GetType().IsEnum:
Simple:
				return $"{value.GetType().Name} : [{value}]";

			case string s:
				return string.Concat("\"", s, "\"");

			case byte[] bytes:
				return string.Join(" ", Array.ConvertAll(bytes, b => $"{b:X2}"));

			case SafeAllocatedMemoryHandleBase mem:
				if (bypassMemDump) goto default;
				return mem.Dump;

			case GenericSecurityDescriptor sd:
				return sd.GetSddlForm(AccessControlSections.All);

			default:
				try
				{
					jsonSet.Value.DefaultValueHandling = showDefVals ? DefaultValueHandling.Include : DefaultValueHandling.Ignore;
					return JsonConvert.SerializeObject(value, Formatting.Indented, jsonSet.Value);
				}
				catch (Exception e) { return e.ToString(); }
		}
	}

	public static IList<string> GetStructSizes(this Type[] types, bool fullName = false, params string[] filters)
	{
		TypeAttributes attr = TypeAttributes.SequentialLayout | TypeAttributes.ExplicitLayout;
		return types.Where(t => t.IsValueType && !t.IsEnum && !t.IsGenericType && (t.Attributes & attr) != 0 && (filters.Length == 0 || filters.Any(s => t.Name.Contains(s)))).
			OrderBy(t => fullName ? t.FullName : t.Name).Select(t => $"{(fullName ? t.FullName : t.Name)} = {GetTypeSize(t)}").ToList();

		static long GetTypeSize(Type t) { try { return (long)InteropExtensions.SizeOf(t); } catch { return -1; } }
	}

	public static void RunForEach<TEnum>(Type lib, string name, Func<TEnum, object?[]> makeParam, Action<TEnum, object?, object?[]>? action = null, Action<Exception?>? error = null) where TEnum : Enum =>
		RunForEach(lib, name, makeParam, (e, ex) => error?.Invoke(ex), action);

	public static void RunForEach<TEnum>(Type lib, string name, Func<TEnum, object?[]> makeParam, Action<TEnum, Exception?>? error = null, Action<TEnum, object?, object?[]>? action = null, CorrespondingAction? filter = null) where TEnum : Enum
	{
		MethodInfo mi = lib.GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.IsGenericMethod && m.Name == name).First() ?? throw new ArgumentException("Unable to find method.");
		foreach (TEnum e in Enum.GetValues(typeof(TEnum)).Cast<TEnum>())
		{
			Type? type = (filter.HasValue ? CorrespondingTypeAttribute.GetCorrespondingTypes(e, filter.Value) : CorrespondingTypeAttribute.GetCorrespondingTypes(e)).FirstOrDefault();
			if (type is null)
			{
				TestContext.WriteLine($"No corresponding type found for {e}.");
				continue;
			}
			MethodInfo gmi = mi.MakeGenericMethod(type);
			var param = makeParam(e);
			try
			{
				var ret = gmi.Invoke(null, param);
				action?.Invoke(e, ret, param);
			}
			catch (Exception ex)
			{
				error?.Invoke(e, ex.InnerException);
			}
		}
	}

	public static Process RunThrottleApp() => Process.Start(testApp);

	public static void SetThrottle(string type, bool on)
	{
		using var evt = new EventWaitHandle(false, EventResetMode.AutoReset, (on ? "" : "End") + type);
		evt.Set();
	}

	public static void WriteValues(this object value, bool showDefVals = true) => TestContext.WriteLine(GetStringVal(value, showDefVals));

	private class GenJsonConverter<TIn, TOut> : JsonConverter<TOut>
	{
		private readonly Func<TIn, TOut> rdr;
		private readonly Func<TOut, TIn> wtr;

		public GenJsonConverter(Func<TIn, TOut> r, Func<TOut, TIn> w)
		{
			rdr = r;
			wtr = w;
		}

		public override TOut? ReadJson(JsonReader reader, Type objectType, TOut? existingValue, bool hasExistingValue, JsonSerializer serializer) =>
			reader.Value is TIn t ? rdr(t) : default;

		public override void WriteJson(JsonWriter writer, TOut? value, JsonSerializer serializer)
		{
			if (value is not null)
				writer.WriteValue(wtr(value));
		}
	}
}