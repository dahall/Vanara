using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Managed instance of the SIZE_T type.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct SizeT
	{
		private UIntPtr val;

		/// <summary>Initializes a new instance of the <see cref="SizeT"/> struct.</summary>
		/// <param name="value">The value.</param>
		public SizeT(uint value) { val = (UIntPtr)value; }

		/// <summary>Initializes a new instance of the <see cref="SizeT"/> struct.</summary>
		/// <param name="value">The value.</param>
		public SizeT(ulong value) { val = new UIntPtr(value); }

		/// <summary>Gets the value.</summary>
		/// <value>The value.</value>
		public ulong Value => val.ToUInt64();

		/// <summary>Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="SizeT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SizeT(uint value) => new SizeT(value);

		/// <summary>Performs an implicit conversion from <see cref="System.UInt64"/> to <see cref="SizeT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SizeT(ulong value) => new SizeT(value);
	}
}