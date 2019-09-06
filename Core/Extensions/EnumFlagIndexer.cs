using System;
using System.Collections;
using System.Collections.Generic;

namespace Vanara.Extensions
{
	/// <summary>Structure to use in place of a enumerated type with the <see cref="FlagsAttribute"/> set. Allows for indexer access to flags and simplifies boolean logic.</summary>
	/// <typeparam name="TEnum">An enumerated type.</typeparam>
	/// <example>
	///   <para>Use this structure by replacing an enumerated type field for simpler access. See old and new way examples below:</para>
	///   <code title="Old way">var fileInfo = new FileInfo(@"C:\MyFile.txt");
	/// FileAttributes fileAttr = fileInfo.Attributes;
	/// if ((fileAttr &amp; FileAttributes.Hidden) != FileAttributes.Hidden)
	/// {
	///    Console.WriteLine("The file is hidden. Trying to unhide now.");
	///    fileInfo.Attributes = (fileAttr &amp; ~FileAttributes.Hidden);
	/// }</code>
	///   <code title="New way">var fileInfo = new FileInfo(@"C:\MyFile.txt");
	/// EnumFlagIndexer&lt;FileAttributes&gt; fileAttr = fileInfo.Attributes;
	/// if (fileAttr[FileAttributes.Hidden])
	/// {
	///    Console.WriteLine("The file is hidden. Trying to unhide now.");
	///    fileAttr[FileAttributes.Hidden] = false;
	///    fileInfo.Attributes = fileAttr;
	/// }</code>
	/// </example>
	public struct EnumFlagIndexer<TEnum> : IEquatable<TEnum>, IEquatable<EnumFlagIndexer<TEnum>>, IEnumerable<TEnum> where TEnum : System.Enum
	{
		private TEnum flags;

		/// <summary>Initializes a new instance of the <see cref="EnumFlagIndexer{TEnum}"/> struct.</summary>
		/// <param name="initialValue">The initial value. Defaults to <c>default(E)</c>.</param>
		public EnumFlagIndexer(TEnum initialValue)
		{
			if (!typeof(TEnum).IsEnum)
				throw new ArgumentException($"Type '{typeof(TEnum).FullName}' is not an enum");
			if (!Attribute.IsDefined(typeof(TEnum), typeof(FlagsAttribute)))
				throw new ArgumentException($"Type '{typeof(TEnum).FullName}' doesn't have the 'Flags' attribute");
			flags = initialValue;
		}

		/// <summary>Gets or sets the specified flag.</summary>
		/// <value>A boolean value representing the presence of the specified enumerated flag.</value>
		/// <param name="flag">A value in the enumerated type to check.</param>
		/// <returns><c>true</c> if the flag is set; <c>false</c> otherwise.</returns>
		public bool this[TEnum flag]
		{
			get => (Convert.ToInt64(flags) & Convert.ToInt64(flag)) != 0;
			set
			{
				var flagsValue = Convert.ToInt64(flags);
				var flagValue = Convert.ToInt64(flag);
				if (value)
					flagsValue |= flagValue;
				else
					flagsValue &= ~flagValue;
				flags = (TEnum)Enum.ToObject(typeof(TEnum), flagsValue);
			}
		}

		/// <summary>Implements the operator !=.</summary>
		/// <param name="a">An instance of <see cref="EnumFlagIndexer{TEnum}"/>.</param>
		/// <param name="b">An instance of the <typeparamref name="TEnum"/> enumerated type.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(EnumFlagIndexer<TEnum> a, TEnum b) => !a.Equals(b);

		/// <summary>Implements the operator &amp;.</summary>
		/// <param name="a">An instance of <see cref="EnumFlagIndexer{TEnum}"/>.</param>
		/// <param name="b">An instance of the <typeparamref name="TEnum"/> enumerated type.</param>
		/// <returns>The result of the operator.</returns>
		public static TEnum operator &(EnumFlagIndexer<TEnum> a, TEnum b) => (TEnum)Enum.ToObject(typeof(TEnum), Convert.ToInt64(a.flags) & Convert.ToInt64(b));

		/// <summary>Implements the operator |.</summary>
		/// <param name="a">An instance of <see cref="EnumFlagIndexer{TEnum}"/>.</param>
		/// <param name="b">An instance of the <typeparamref name="TEnum"/> enumerated type.</param>
		/// <returns>The result of the operator.</returns>
		public static TEnum operator |(EnumFlagIndexer<TEnum> a, TEnum b) => (TEnum)Enum.ToObject(typeof(TEnum), Convert.ToInt64(a.flags) | Convert.ToInt64(b));

		/// <summary>Implements the operator ==.</summary>
		/// <param name="a">An instance of <see cref="EnumFlagIndexer{TEnum}"/>.</param>
		/// <param name="b">An instance of the <typeparamref name="TEnum"/> enumerated type.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(EnumFlagIndexer<TEnum> a, TEnum b) => a.Equals(b);

		/// <summary>Implicitly converts an instance of <see cref="EnumFlagIndexer{TEnum}"/> to the value of enumerated type E.</summary>
		/// <param name="f">The f.</param>
		/// <returns>The result of the operator.</returns>
		public static implicit operator TEnum(EnumFlagIndexer<TEnum> f) => f.flags;

		/// <summary>Implicitly converts a value of E to an instance of <see cref="EnumFlagIndexer{TEnum}"/>.</summary>
		/// <param name="e">The e.</param>
		/// <returns>The result of the operator.</returns>
		public static implicit operator EnumFlagIndexer<TEnum>(TEnum e) => new EnumFlagIndexer<TEnum>(e);

		/// <summary>Clears and sets to <c>default(E)</c>.</summary>
		public void Clear()
		{
			flags = default;
		}

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
		public bool Equals(TEnum other) => Convert.ToInt64(flags) == Convert.ToInt64(other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
		public bool Equals(EnumFlagIndexer<TEnum> other) => Convert.ToInt64(flags) == Convert.ToInt64(other.flags);

		/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) => Equals(obj, flags);

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => flags.GetHashCode();

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="T:System.Collections.Generic.IEnumerator{TEnum}"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<TEnum> GetEnumerator()
		{
			long t = 0;
			foreach (TEnum e in Enum.GetValues(typeof(TEnum)))
				if (this[e]) { t |= Convert.ToInt64(e); yield return e; }
			var rem = Convert.ToInt64(flags) ^ t;
			if (rem != 0) yield return (TEnum)Enum.ToObject(typeof(TEnum), rem);
		}

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => flags.ToString();

		/// <summary>Unions the specified flags.</summary>
		/// <param name="enumVal">The flags.</param>
		public void Union(TEnum enumVal)
		{
			this[enumVal] = true;
		}

		/// <summary>Unions the specified flags.</summary>
		/// <param name="enumValues">The flags.</param>
		public void Union(IEnumerable<TEnum> enumValues)
		{
			foreach (var e in enumValues) this[e] = true;
		}
	}
}
