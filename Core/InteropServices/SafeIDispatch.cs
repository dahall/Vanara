using System;
using System.Runtime.InteropServices;

namespace Vanara.InteropServices
{
	/// <summary>Provide a IDispatch-based (e.g. late-bound) access to a COM object. Use <see cref="Invoke"/> to work with the object.</summary>
	public class SafeIDispatch : ComReleaser<dynamic>
	{
		/// <summary>Initializes a new instance of the <see cref="SafeIDispatch"/> class.</summary>
		/// <param name="target">The target object which must be a raw COM object.</param>
		public SafeIDispatch(object target) : base(target)
		{
			if (!Marshal.IsComObject(target))
				throw new ArgumentException("The target object must be a COM object");
			RawPointer = GetRawPointer(target);
		}

		/// <summary>Gets the pointer to the IDispatch instance.</summary>
		/// <value>A pointer to the IDispatch instance.</value>
		public IntPtr RawPointer { get; }

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="other">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns><see langword="true"/> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <see langword="false"/>.</returns>
		public bool Equals(ComReleaser<dynamic> other) => other?.Item is null || Item is null ? false : (bool)(RawPointer == GetRawPointer(other.Item));

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns><see langword="true"/> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <see langword="false"/>.</returns>
		public override bool Equals(object obj) => obj is ComReleaser<dynamic> o ? Equals(o) : base.Equals(obj);

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => RawPointer.ToInt32();

		/// <summary>
		/// Method to encapsulate operations against the late-bound COM object. The caller must handle any exceptions that may result as part
		/// of the operation.
		/// </summary>
		/// <param name="action">A method that performs work against the late-bound COM object.</param>
		public void Invoke(Action<dynamic> action) => action.Invoke(Item);

		private static IntPtr GetRawPointer(object target)
		{
			var result = IntPtr.Zero;
			try
			{
				result = Marshal.GetIDispatchForObject(target);
			}
			finally
			{
				// Decrement reference count added by call to GetIDispatchForObject
				if (result != IntPtr.Zero)
					Marshal.Release(result);
			}
			return result;
		}
	}
}