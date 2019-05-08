using System;
using System.Runtime.InteropServices;

namespace Vanara.InteropServices
{
	/// <summary>Factory for creating <see cref="ComReleaser{T}"/> objects.</summary>
	public static class ComReleaserFactory
	{
		/// <summary>Factory method to create a <see cref="ComReleaser{TObj}"/> using type inference.</summary>
		/// <typeparam name="TObj">The type of the object.</typeparam>
		/// <param name="obj">The object.</param>
		/// <returns>A <see cref="ComReleaser{TObj}"/> instance.</returns>
		public static ComReleaser<TObj> Create<TObj>(TObj obj) where TObj : class => new ComReleaser<TObj>(obj);
	}

	/// <summary>
	/// A safe variable to hold an instance of a COM class that automatically calls <see cref="Marshal.ReleaseComObject(object)"/> on disposal.
	/// </summary>
	/// <typeparam name="T">The type of the COM object.</typeparam>
	/// <seealso cref="System.IDisposable"/>
	public class ComReleaser<T> : IDisposable where T : class
	{
		/// <summary>Initializes a new instance of the <see cref="ComReleaser{T}"/> class.</summary>
		/// <param name="obj">The COM object instance.</param>
		/// <exception cref="ArgumentNullException">obj</exception>
		/// <exception cref="ArgumentException">Argument value must be a COM object. - obj</exception>
		public ComReleaser(T obj)
		{
			if (obj == null) throw new ArgumentNullException(nameof(obj));
			if (!obj.GetType().IsCOMObject) throw new ArgumentException("Argument value must be a COM object.", nameof(obj));
			Item = obj;
		}

		/// <summary>Initializes a new instance of the <see cref="ComReleaser{T}"/> class.</summary>
		/// <param name="obj">The COM object instance.</param>
		/// <exception cref="ArgumentNullException">obj</exception>
		/// <exception cref="ArgumentException">Argument value must be a COM object and expose <typeparamref name="T"/>.</exception>
		public ComReleaser(object obj)
		{
			if (obj == null) throw new ArgumentNullException(nameof(obj));
			if (!obj.GetType().IsCOMObject) throw new ArgumentException("Argument value must be a COM object.", nameof(obj));
			Item = obj is T t ? t : throw new ArgumentException($"Object must expose the {typeof(T).Name} interface.");
		}

		/// <summary>Gets the COM object.</summary>
		/// <value>The COM object.</value>
		public T Item { get; private set; }

		/// <summary>Performs an implicit conversion from <typeparamref name="T"/> to <see cref="ComReleaser{T}"/>.</summary>
		/// <param name="obj">The COM object.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator ComReleaser<T>(T obj) => new ComReleaser<T>(obj);

		/// <summary>Performs an implicit conversion from <see cref="ComReleaser{T}"/> to <typeparamref name="T"/>.</summary>
		/// <param name="co">The <see cref="ComReleaser{T}"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator T(ComReleaser<T> co) => co.Item;

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			if (Item == null) return;
			Marshal.FinalReleaseComObject(Item);
			Item = null;
		}
	}
}