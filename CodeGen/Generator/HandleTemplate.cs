using Microsoft.Win32.SafeHandles;
using System.ComponentModel;
using System.Diagnostics;

namespace Namespace;

#1#public static partial class ParentClassName
{
#1#	SummaryText	[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}"), TypeConverter(typeof(HANDLEConverter))]
#3#	[global::Vanara.PInvoke.DeferAutoMethodTo(typeof(ClassName))]
#3#	public readonly partial struct HandleName : InterfaceName
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HandleName"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HandleName(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HandleName"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HandleName NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether the handle is invalid.</summary>
		/// <value><see langword="true"/> if the handle is invalid; otherwise, <see langword="false"/>.</value>
		public readonly bool IsInvalid => handle == IntPtr.Zero || handle == new IntPtr(-1);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public readonly bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HandleName"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HandleName h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HandleName"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HandleName(IntPtr h) => new(h);

#2#		/// <summary>Performs an implicit conversion from <see cref="HandleName"/> to <see cref="InheritedHandleName"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator InheritedHandleName(HandleName h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="HandleName"/> to <see cref="InheritedHandleName"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HandleName(InheritedHandleName h) => h.DangerousGetHandle();

#2#		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HandleName h1, HandleName h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HandleName h1, HandleName h2) => h1.Equals(h2);

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HandleName h1) => h1.IsNull;

#if !NETSTANDARD
		/// <summary>Implements the operator <see langword="true"/>.</summary>
		/// <param name="h">The value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator true(HandleName h) => !h.IsInvalid;

		/// <summary>Implements the operator <see langword="false"/>.</summary>
		/// <param name="h">The value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator false(HandleName h) => h.IsInvalid;
#endif

		/// <inheritdoc/>
		public readonly override bool Equals(object obj) => obj switch
		{
			IntPtr p => handle == p,
			IHandle i => handle == i.DangerousGetHandle(),
			SafeHandle h => handle == h.DangerousGetHandle(),
			_ => false
		};

		/// <inheritdoc/>
		public readonly override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public readonly IntPtr DangerousGetHandle() => handle;
	}#1#
}#1#