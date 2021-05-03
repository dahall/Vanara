using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class SetupAPI
	{
		/// <summary>
		/// In Windows Vista and later versions of Windows, the DEVPROPKEY structure represents a device property key for a device property
		/// in the unified device property model.
		/// </summary>
		/// <remarks>
		/// <para>The DEVPROPKEY structure is part of the unified device property model.</para>
		/// <para>The basic set of system-supplied device property keys are defined in Devpkey.h.</para>
		/// <para>The <c>DEFINE_DEVPROPKEY</c> macro creates an instance of a DEVPROPKEY structure that represents a device property key.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpropkey struct DEVPROPKEY { DEVPROPGUID fmtid; DEVPROPID
		// pid; };
		[PInvokeData("Devpropdef.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DEVPROPKEY : IEquatable<DEVPROPKEY>
		{
			/// <summary>
			/// <para>A DEVPROPGUID-typed value that specifies a property category.</para>
			/// <para>The DEVPROPGUID data type is defined as:</para>
			/// </summary>
			public Guid fmtid;

			/// <summary>
			/// <para>
			/// <c>pid</c> A DEVPROPID-typed value that uniquely identifies the property within the property category. For internal system
			/// reasons, a property identifier must be greater than or equal to two.
			/// </para>
			/// <para>The DEVPROPID data type is defined as:</para>
			/// </summary>
			public uint pid;

			/// <summary>Initializes a new instance of the <see cref="DEVPROPKEY"/> struct.</summary>
			/// <param name="a">Guid value.</param>
			/// <param name="b">Guid value.</param>
			/// <param name="c">Guid value.</param>
			/// <param name="d">Guid value.</param>
			/// <param name="e">Guid value.</param>
			/// <param name="f">Guid value.</param>
			/// <param name="g">Guid value.</param>
			/// <param name="h">Guid value.</param>
			/// <param name="i">Guid value.</param>
			/// <param name="j">Guid value.</param>
			/// <param name="k">Guid value.</param>
			/// <param name="pid">The pid.</param>
			public DEVPROPKEY(uint a, ushort b, ushort c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k, uint pid)
			{
				fmtid = new Guid(a, b, c, d, e, f, g, h, i, j, k);
				this.pid = pid;
			}

			/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
			/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
			/// <returns>
			/// <see langword="true"/> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <see langword="false"/>.
			/// </returns>
			public override bool Equals(object obj) => obj is DEVPROPKEY pk && Equals(pk);

			/// <summary>Determines whether the specified <see cref="DEVPROPKEY"/>, is equal to this instance.</summary>
			/// <param name="pk">The property key.</param>
			/// <returns>
			/// <see langword="true"/> if the specified <see cref="DEVPROPKEY"/> is equal to this instance; otherwise, <see langword="false"/>.
			/// </returns>
			public bool Equals(DEVPROPKEY pk) => pk.pid == pid && pk.fmtid == fmtid;

			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			public override int GetHashCode() => (pid, fmtid).GetHashCode();

			/// <summary>Performs a lookup of this <see cref="DEVPROPKEY"/> against defined values in this assembly to find a name.</summary>
			/// <returns>The name, if found, otherwise <see langword="null"/>.</returns>
			public string LookupName()
			{
				var dpkType = GetType();
				var lthis = this;
				return dpkType.DeclaringType.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).
					Where(fi => fi.FieldType == dpkType && lthis.Equals(fi.GetValue(null))).Select(fi => fi.Name).FirstOrDefault();
			}

			/// <inheritdoc/>
			public override string ToString() => LookupName() ?? $"{fmtid}:{pid}";
		}
	}
}