using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>An interface matching most COM enumerator interfaces. This should be specified as a base for any IEnumXX interfaces.</summary>
	/// <typeparam name="T">The type of the value enumeratored by the <c>Next</c> function.</typeparam>
	public interface IComEnumerator<T>
	{
	}

	/// <summary>Extension methods to get generic enumerations from COM interfaces.</summary>
	public static class ComEnumeratorExtentions
	{
		/// <summary>Gets an <see cref="IEnumerator{T}"/> instance from an interface or class deriving from <see cref="IComEnumerator{T}"/>.</summary>
		/// <typeparam name="T">The type of the enumerated value.</typeparam>
		/// <param name="cenum">The instance of an interface or class deriving from <see cref="IComEnumerator{T}"/>.</param>
		/// <returns>An <see cref="IEnumerator{T}"/> instance that will iterate over <paramref name="cenum"/>.</returns>
		public static IEnumerator<T> GetEnumerator<T>(this IComEnumerator<T> cenum) where T : struct => new ComEnumeratorStruct<T>(cenum);
	}

	internal class ComEnumeratorStruct<T> : IEnumerator<T> where T : struct
	{
		private T? cur;
		private IComEnumerator<T> instance;
		private IComEnumerator_Next next;
		private MethodInfo resetMethod;

		public ComEnumeratorStruct(IComEnumerator<T> cenum)
		{
			instance = cenum;

			//var mi = cenum.GetType().GetMethod("Next");
			//if (!IsMethodCompatibleWithDelegate<IComEnumerator_Next>(mi))
			//	throw new ArgumentException("The instance does not support the correct 'Next' method format.");
			next = (IComEnumerator_Next)Delegate.CreateDelegate(typeof(IComEnumerator_Next), instance, "Next", false, false) ?? throw new ArgumentException("The instance does not support the correct 'Next' method format.");

			resetMethod = cenum.GetType().GetMethod("Reset", Type.EmptyTypes) ?? throw new ArgumentException("The instance does not support the correct 'Reset' method format.");
			resetMethod.Invoke(instance, null);
		}

		/// <summary>Retrieves the specified number of items in the enumeration sequence.</summary>
		/// <param name="celt">
		/// The number of items to be retrieved. If there are fewer than the requested number of items left in the sequence, this method
		/// retrieves the remaining elements.
		/// </param>
		/// <param name="rgelt">An array of enumerated items.</param>
		/// <param name="pceltFetched">
		/// The number of items that were retrieved. This parameter is always less than or equal to the number of items requested.
		/// </param>
		/// <returns>If the method retrieves the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
		public delegate HRESULT IComEnumerator_Next(uint celt, T[] rgelt, out uint pceltFetched);

		public T Current => cur.HasValue ? cur.Value : throw new InvalidOperationException("The index is invalid.");

		object IEnumerator.Current => Current;

		public static bool IsMethodCompatibleWithDelegate<TDel>(MethodInfo method) where TDel : Delegate
		{
			var delegateSignature = typeof(TDel).GetMethod("Invoke");
			return delegateSignature.ReturnType == method.ReturnType && delegateSignature.GetParameters().Select(x => x.ParameterType).SequenceEqual(method.GetParameters().Select(x => x.ParameterType));
		}

		public void Dispose()
		{
			if (!(instance is null))
			{
				if (instance.GetType().IsCOMObject)
					Marshal.ReleaseComObject(instance);
				instance = null;
			}
		}

		public bool MoveNext()
		{
			if (instance is null) return false;
			var i = new T[] { default };
			var hr = next.Invoke(1, i, out var cnt);
			cur = hr == HRESULT.S_OK && cnt == 1 ? i[0] : (T?)null;
			return cur.HasValue;
		}

		public void Reset() => resetMethod.Invoke(instance, null);
	}
}