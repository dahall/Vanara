using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Vanara.Extensions
{
	/// <summary>Extensions related to <c>System.Reflection</c></summary>
	public static class ReflectionExtensions
	{
		/// <summary>Gets all loaded types in the <see cref="AppDomain"/>.</summary>
		/// <param name="appDomain">The application domain.</param>
		/// <returns>All loaded types.</returns>
		public static IEnumerable<Type> GetAllTypes(this AppDomain appDomain) => appDomain.GetAssemblies().SelectMany(a => a.GetTypes());

		/// <summary>Returns an array of custom attributes applied to this member and identified by <typeparamref name="TAttr"/>.</summary>
		/// <typeparam name="TAttr">The type of attribute to search for. Only attributes that are assignable to this type are returned.</typeparam>
		/// <param name="element">An object derived from the MemberInfo class that describes a constructor, event, field, method, or property member of a class.</param>
		/// <param name="inherit"><c>true</c> to search this member's inheritance chain to find the attributes; otherwise, <c>false</c>. This parameter is ignored for properties and events.</param>
		/// <param name="predicate">An optional predicate to refine the results.</param>
		/// <returns></returns>
		public static IEnumerable<TAttr> GetCustomAttributes<TAttr>(this MemberInfo element, bool inherit = false, Func<TAttr, bool> predicate = null) where TAttr : Attribute =>
			element.GetCustomAttributes(typeof(TAttr), inherit).Cast<TAttr>().Where(predicate ?? (a => true));

		/// <summary>Returns an array of custom attributes applied to this member and identified by <typeparamref name="TAttr"/>.</summary>
		/// <typeparam name="TAttr">The type of attribute to search for. Only attributes that are assignable to this type are returned.</typeparam>
		/// <param name="type">The type of the <see cref="Type"/> to examine.</param>
		/// <param name="inherit"><c>true</c> to search this member's inheritance chain to find the attributes; otherwise, <c>false</c>. This parameter is ignored for properties and events.</param>
		/// <param name="predicate">An optional predicate to refine the results.</param>
		/// <returns></returns>
		public static IEnumerable<TAttr> GetCustomAttributes<TAttr>(this Type type, bool inherit = false, Func<TAttr, bool> predicate = null) where TAttr : Attribute =>
			type.GetCustomAttributes(typeof(TAttr), inherit).Cast<TAttr>().Where(predicate ?? (a => true));

		/// <summary>Gets a named property value from an object.</summary>
		/// <typeparam name="T">The expected type of the property to be returned.</typeparam>
		/// <param name="obj">The object from which to retrieve the property.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="defaultValue">The default value to return in the instance that the property is not found.</param>
		/// <returns>The property value, if found, or the <paramref name="defaultValue"/> if not.</returns>
		public static T GetPropertyValue<T>(this object obj, string propertyName, T defaultValue = default)
		{
			var prop = obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, typeof(T), Type.EmptyTypes, null);
			if (prop == null) return defaultValue;
			var val = prop.GetValue(obj, null);
			if (val == null) return defaultValue;
			return (T)val;
		}

		/// <summary>
		/// Invokes a generic named method on an object with parameters and no return value.
		/// </summary>
		/// <param name="obj">The object on which to invoke the method or constructor. If a method is static, this argument is ignored. If a constructor is static, this argument must be null or an instance of the class that defines the constructor.</param>
		/// <param name="methodName">The string containing the name of the public method to get.</param>
		/// <param name="typeArguments">An array of types to be substituted for the type parameters of the current generic method definition.</param>
		/// <param name="argTypes">An array of Type objects representing the number, order, and type of the parameters for the method to get.
		/// <para>-or-</para>
		/// <para>An empty array of Type objects(as provided by the EmptyTypes field) to get a method that takes no parameters.</para></param>
		/// <param name="args">An argument list for the invoked method or constructor. This is an array of objects with the same number, order, and type as the parameters of the method or constructor to be invoked. If there are no parameters, this should be null.</param>
		/// <returns>An Object containing the return value of the invoked method, or null in the case of a constructor, or null if the method's return type is void. Before calling the method or constructor, Invoke checks to see if the user has access permission and verifies that the parameters are valid.</returns>
		/// <exception cref="ArgumentException">Method not found - methodName</exception>
		public static object InvokeGenericMethod(this object obj, string methodName, Type[] typeArguments, Type[] argTypes, object[] args)
		{
			var mi = obj?.GetType().GetMethod(methodName, argTypes);
			if (mi == null) throw new ArgumentException(@"Method not found", nameof(methodName));
			var gmi = mi.MakeGenericMethod(typeArguments);
			return gmi.Invoke(obj, args);
		}

		/// <summary>Invokes a named method on a created instance of a type with parameters.</summary>
		/// <typeparam name="T">The expected type of the method's return value.</typeparam>
		/// <param name="type">The type to be instantiated and then used to invoke the method. This method assumes the type has a default public constructor.</param>
		/// <param name="methodName">Name of the method.</param>
		/// <param name="args">The arguments to provide to the method invocation.</param>
		/// <returns>The value returned from the method.</returns>
		public static T InvokeMethod<T>(this Type type, string methodName, params object[] args)
		{
			var o = Activator.CreateInstance(type);
			return InvokeMethod<T>(o, methodName, args);
		}

		/// <summary>Invokes a named method on a created instance of a type with parameters.</summary>
		/// <typeparam name="T">The expected type of the method's return value.</typeparam>
		/// <param name="type">The type to be instantiated and then used to invoke the method.</param>
		/// <param name="instArgs">The arguments to supply to the constructor.</param>
		/// <param name="methodName">Name of the method.</param>
		/// <param name="args">The arguments to provide to the method invocation.</param>
		/// <returns>The value returned from the method.</returns>
		public static T InvokeMethod<T>(this Type type, object[] instArgs, string methodName, params object[] args)
		{
			var o = Activator.CreateInstance(type, instArgs);
			return InvokeMethod<T>(o, methodName, args);
		}

		/// <summary>Invokes a named method on an object with parameters and no return value.</summary>
		/// <param name="obj">The object on which to invoke the method.</param>
		/// <param name="methodName">Name of the method.</param>
		/// <param name="args">The arguments to provide to the method invocation.</param>
		public static void InvokeMethod(this object obj, string methodName, params object[] args)
		{
			var argTypes = args == null || args.Length == 0 ? Type.EmptyTypes : Array.ConvertAll(args,
				o => o?.GetType() ?? typeof(object));
			InvokeMethod(obj, methodName, argTypes, args);
		}

		/// <summary>Invokes a named method on an object with parameters and no return value.</summary>
		/// <typeparam name="T">The expected type of the method's return value.</typeparam>
		/// <param name="obj">The object on which to invoke the method.</param>
		/// <param name="methodName">Name of the method.</param>
		/// <param name="args">The arguments to provide to the method invocation.</param>
		/// <returns>The value returned from the method.</returns>
		public static T InvokeMethod<T>(this object obj, string methodName, params object[] args)
		{
			var argTypes = args == null || args.Length == 0 ? Type.EmptyTypes : Array.ConvertAll(args,
				o => o?.GetType() ?? typeof(object));
			return InvokeMethod<T>(obj, methodName, argTypes, args);
		}

		/// <summary>Invokes a named method on an object with parameters and no return value.</summary>
		/// <param name="obj">The object on which to invoke the method.</param>
		/// <param name="methodName">Name of the method.</param>
		/// <param name="argTypes">The argument types.</param>
		/// <param name="args">The arguments to provide to the method invocation.</param>
		public static void InvokeMethod(this object obj, string methodName, Type[] argTypes, object[] args)
		{
			var mi = obj?.GetType().GetMethod(methodName, argTypes);
			if (mi == null) throw new ArgumentException(@"Method not found", nameof(methodName));
			mi.Invoke(obj, args);
		}

		/// <summary>Invokes a named method on an object with parameters and no return value.</summary>
		/// <typeparam name="T">The expected type of the method's return value.</typeparam>
		/// <param name="obj">The object on which to invoke the method.</param>
		/// <param name="methodName">Name of the method.</param>
		/// <param name="argTypes">The argument types.</param>
		/// <param name="args">The arguments to provide to the method invocation.</param>
		/// <returns>The value returned from the method.</returns>
		public static T InvokeMethod<T>(this object obj, string methodName, Type[] argTypes, object[] args)
		{
			var mi = obj?.GetType().GetMethod(methodName, argTypes);
			if (mi == null) throw new ArgumentException(@"Method not found", nameof(methodName));
			var tt = typeof(T);
			if (tt != typeof(object) && mi.ReturnType != tt && !mi.ReturnType.IsSubclassOf(tt))
				throw new ArgumentException(@"Return type mismatch", nameof(T));
			return (T)mi.Invoke(obj, args);
		}

#if !(NETSTANDARD2_0)
		/// <summary>Invokes a method from a derived base class.</summary>
		/// <param name="methodInfo">The <see cref="MethodInfo"/> instance from the derived class for the method to invoke.</param>
		/// <param name="targetObject">The target object.</param>
		/// <param name="arguments">The arguments.</param>
		/// <returns>The value returned from the method.</returns>
		public static object InvokeNotOverride(this MethodInfo methodInfo, object targetObject, params object[] arguments)
		{
			var parameters = methodInfo.GetParameters();
			if (parameters.Length != arguments.Length)
				throw new Exception("Arguments count doesn't match");

			Type returnType = null;
			if (methodInfo.ReturnType != typeof(void))
				returnType = methodInfo.ReturnType;

			var type = targetObject.GetType();
			var dynamicMethod = new DynamicMethod("", returnType, new [] { type, typeof(object) }, type);
			var iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(OpCodes.Ldarg_0); // this

			for (var i = 0; i < parameters.Length; i++)
			{
				var parameter = parameters[i];

				iLGenerator.Emit(OpCodes.Ldarg_1); // load array argument

				// get element at index
				iLGenerator.Emit(OpCodes.Ldc_I4_S, i); // specify index
				iLGenerator.Emit(OpCodes.Ldelem_Ref); // get element

				var parameterType = parameter.ParameterType;
				iLGenerator.Emit(OpCodes.Unbox_Any, parameterType);
			}

			iLGenerator.Emit(OpCodes.Call, methodInfo);
			iLGenerator.Emit(OpCodes.Ret);

			return dynamicMethod.Invoke(null, new [] { targetObject, arguments });
		}
#endif

		/// <summary>Loads a type from a named assembly.</summary>
		/// <param name="typeName">Name of the type.</param>
		/// <param name="asmRef">The name or path of the file that contains the manifest of the assembly.</param>
		/// <returns>The <see cref="Type"/> reference, or <c>null</c> if type or assembly not found.</returns>
		public static Type LoadType(string typeName, string asmRef = null)
		{
			Type ret = null;
			Assembly asm = null;
			try { asm = Assembly.LoadFrom(asmRef); } catch { }
			if (!TryGetType(asm, typeName, ref ret))
			{
				foreach (var asm2 in AppDomain.CurrentDomain.GetAssemblies())
					if (TryGetType(asm2, typeName, ref ret)) break;
			}
			return ret;
		}

		/// <summary>Tries the retrieve a <see cref="Type"/> reference from an assembly.</summary>
		/// <param name="typeName">Name of the type.</param>
		/// <param name="asm">The assembly from which to load the type.</param>
		/// <param name="type">The <see cref="Type"/> reference, if found.</param>
		/// <returns><c>true</c> if the type was found in the assembly; otherwise, <c>false</c>.</returns>
		private static bool TryGetType(Assembly asm, string typeName, ref Type type)
		{
			if (asm == null) return false;
			return (type = asm.GetType(typeName, false, false)) != null;
		}
	}
}