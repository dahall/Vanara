using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.Configuration;

/// <summary>Provides access to an initialization (.ini) file and values.</summary>
public class InitializationFile
{
	/// <summary>Initializes a new instance of the <see cref="InitializationFile"/> class.</summary>
	/// <param name="fullName">
	/// The name of the initialization file. If this parameter does not contain a full path for the file, the function searches the
	/// Windows directory for the file. If the file does not exist and lpFileName does not contain a full path, the function creates the
	/// file in the Windows directory.
	/// </param>
	public InitializationFile(string fullName)
	{
		FullName = fullName;
		Sections = new(this);
	}

	/// <summary>Gets the name of the initialization file.</summary>
	/// <value>The name of the initialization file.</value>
	public string FullName { get; }

	/// <summary>Gets the sections of the initialization file.</summary>
	/// <value>The sections.</value>
	public InitializationFileSections Sections { get; }

	/// <summary>Provides access to the key/value pairs within an initialization file's section.</summary>
	/// <seealso cref="IDictionary{TKey, TValue}"/>
	public class InitializationFileSection : IDictionary<string, string>
	{
		private static readonly uint AutoChSz = (uint)Extensions.StringHelper.GetCharSize();
		private static readonly string UnqVal = Guid.NewGuid().ToString();

		private readonly InitializationFile file;

		internal InitializationFileSection(InitializationFile privateProfileFile, string name)
		{
			file = privateProfileFile;
			Name = name;
		}

		/// <summary>Gets the number of elements contained in the <see cref="ICollection{T}"/>.</summary>
		public int Count => KeyNames.Length;

		/// <summary>Gets an <see cref="ICollection{T}"/> containing the keys of the <see cref="IDictionary{TKey, TValue}"/>.</summary>
		public ICollection<string> Keys => KeyNames;

		/// <summary>Gets the name of the section.</summary>
		/// <value>The section name.</value>
		public string Name { get; }

		/// <summary>Gets an <see cref="ICollection{T}"/> containing the values in the <see cref="IDictionary{TKey, TValue}"/>.</summary>
		public ICollection<string> Values => GetSection().Select(kv => kv.Value).ToList();

		/// <summary>Gets a value indicating whether the <see cref="ICollection{T}"/> is read-only.</summary>
		bool ICollection<KeyValuePair<string, string>>.IsReadOnly => false;

		private string[] KeyNames => GetPrivateProfileString(Name, null, file.FullName);

		/// <summary>Gets or sets the <see cref="string"/> with the specified key.</summary>
		/// <value>The <see cref="string"/>.</value>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">key not found or unable to return key value - key</exception>
		public string this[string key]
		{
			get => TryGetValue(key, out var value) ? value : throw new ArgumentException("key not found or unable to return key value", nameof(key));
			set => Add(key, value);
		}

		/// <summary>Adds an element with the provided key and value to the <see cref="IDictionary{TKey, TValue}"/>.</summary>
		/// <param name="key">The object to use as the key of the element to add.</param>
		/// <param name="value">The object to use as the value of the element to add.</param>
		public void Add(string key, string value) => Win32Error.ThrowLastErrorIfFalse(WritePrivateProfileString(Name, key, value, file.FullName));

		/// <summary>Adds an item to the <see cref="ICollection{T}"/>.</summary>
		/// <param name="item">The object to add to the <see cref="ICollection{T}"/>.</param>
		public void Add(KeyValuePair<string, string> item) => Add(item.Key, item.Value);

		/// <summary>Adds the range.</summary>
		/// <param name="items">The items.</param>
		public void AddRange(IEnumerable<KeyValuePair<string, string>> items)
		{
			foreach (KeyValuePair<string, string> item in items)
				Add(item.Key, item.Value);
		}

		/// <summary>Removes all items from the <see cref="ICollection{T}"/>.</summary>
		public void Clear() => Win32Error.ThrowLastErrorIfFalse(WritePrivateProfileSection(Name, new string[0], file.FullName));

		/// <summary>Determines whether this instance contains the object.</summary>
		/// <param name="item">The object to locate in the <see cref="ICollection{T}"/>.</param>
		/// <returns>
		/// <see langword="true"/> if <paramref name="item"/> is found in the <see cref="ICollection{T}"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public bool Contains(KeyValuePair<string, string> item) => TryGetValue(item.Key, out var value) && value == item.Value;

		/// <summary>Determines whether the <see cref="IDictionary{TKey, TValue}"/> contains an element with the specified key.</summary>
		/// <param name="key">The key to locate in the <see cref="IDictionary{TKey, TValue}"/>.</param>
		/// <returns>
		/// <see langword="true"/> if the <see cref="IDictionary{TKey, TValue}"/> contains an element with the key; otherwise, <see langword="false"/>.
		/// </returns>
		public bool ContainsKey(string key) => TryGetValue(key, out _);

		/// <summary>
		/// Copies the elements of the <see cref="ICollection{T}"/> to an <see cref="Array"/>, starting at a particular <see
		/// cref="Array"/> index.
		/// </summary>
		/// <param name="array">
		/// The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see cref="ICollection{T}"/>.
		/// The <see cref="Array"/> must have zero-based indexing.
		/// </param>
		/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
		public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
		{
			KeyValuePair<string, string>[] s = GetSection();
			Array.Copy(s, 0, array, arrayIndex, s.Length);
		}

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => GetSection().Cast<KeyValuePair<string, string>>().GetEnumerator();

		/// <summary>Removes the element with the specified key from the <see cref="IDictionary{TKey, TValue}"/>.</summary>
		/// <param name="key">The key of the element to remove.</param>
		/// <returns>
		/// <see langword="true"/> if the element is successfully removed; otherwise, <see langword="false"/>. This method also returns
		/// <see langword="false"/> if <paramref name="key"/> was not found in the original <see cref="IDictionary{TKey, TValue}"/>.
		/// </returns>
		public bool Remove(string key) => WritePrivateProfileString(Name, key, null, file.FullName);

		/// <summary>Removes the first occurrence of a specific object from the <see cref="ICollection{T}"/>.</summary>
		/// <param name="item">The object to remove from the <see cref="ICollection{T}"/>.</param>
		/// <returns>
		/// <see langword="true"/> if <paramref name="item"/> was successfully removed from the <see cref="ICollection{T}"/>; otherwise,
		/// <see langword="false"/>. This method also returns <see langword="false"/> if <paramref name="item"/> is not found in the
		/// original <see cref="ICollection{T}"/>.
		/// </returns>
		public bool Remove(KeyValuePair<string, string> item) => Contains(item) && Remove(item.Key);

		/// <summary>Sets the value of an element with the provided key.</summary>
		/// <param name="key">The key of the element to set.</param>
		/// <param name="value">The value of the element to set.</param>
		public void SetValue(string key, string value) => Add(key, value);

		/// <summary>Sets the value of an element with the provided key.</summary>
		/// <typeparam name="T">
		/// If <typeparamref name="T"/> is <see cref="uint"/> or <see cref="int"/>, the value is written as text using
		/// <c>WritePrivateProfileString</c>. If any other type, the value is written using <c>WritePrivateProfileStruct</c> resulting
		/// in a byte array string.
		/// </typeparam>
		/// <param name="key">The key of the element to set.</param>
		/// <param name="value">The value of the element to set.</param>
		public void SetValue<T>(string key, in T value) where T : unmanaged
		{
			if (value is int or uint)
				Win32Error.ThrowLastErrorIfFalse(WritePrivateProfileString(Name, key, value.ToString(), file.FullName));
			else
				Win32Error.ThrowLastErrorIfFalse(WritePrivateProfileStruct(Name, key, value, file.FullName));
		}

		/// <summary>Gets the value associated with the specified key.</summary>
		/// <typeparam name="T">
		/// If <typeparamref name="T"/> is <see cref="uint"/> or <see cref="int"/>, the text value is retrieved using
		/// <c>GetPrivateProfileInt</c>. If any other type, the byte array value is read into the structure using <c>GetPrivateProfileStruct</c>.
		/// </typeparam>
		/// <param name="key">The key whose value to get.</param>
		/// <param name="value">
		/// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for
		/// the type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.
		/// </param>
		/// <returns>
		/// <see langword="true"/> if the object that implements <see cref="IDictionary{TKey, TValue}"/> contains an element with the
		/// specified key; otherwise, <see langword="false"/>.
		/// </returns>
		public bool TryGetValue<T>(string key, out T value) where T : unmanaged
		{
			value = default;
			if (value is int or uint)
			{
				if (TryGetValue(key, out var s) && int.TryParse(s, out var i))
				{
					value = (T)Convert.ChangeType(i, typeof(T));
					return true;
				}
				return false;
			}
			return TryGetValue(key, out _) && GetPrivateProfileStruct(Name, key, out value, file.FullName);
		}

		/// <summary>Gets the value associated with the specified key.</summary>
		/// <param name="key">The key whose value to get.</param>
		/// <param name="value">
		/// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for
		/// the type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.
		/// </param>
		/// <returns>
		/// <see langword="true"/> if the object that implements <see cref="IDictionary{TKey, TValue}"/> contains an element with the
		/// specified key; otherwise, <see langword="false"/>.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">key</exception>
		public bool TryGetValue(string key, out string value)
		{
			if (key is null) throw new ArgumentNullException(nameof(key));
			var chars = 1024U;
			using SafeHeapBlock mem = new(chars * AutoChSz);
			while (true)
			{
				var ret = GetPrivateProfileString(Name, key, UnqVal, mem, chars, file.FullName);
				if (ret == UnqVal.Length && mem.ToString(-1) == UnqVal) break;
				if (ret != chars - 1) { value = mem.ToString(-1)!; return true; }
				if (chars == short.MaxValue) break;
				mem.Size = (chars = Math.Min(chars * 2, (uint)short.MaxValue)) * AutoChSz;
			}
			value = "";
			return false;
		}

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		private KeyValuePair<string, string>[] GetSection() => Array.ConvertAll(GetPrivateProfileSection(Name, file.FullName), Parse);

		private KeyValuePair<string, string> Parse(string value)
		{
			if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));
			var eq = value.IndexOf('=');
			if (eq < 0) throw new ArgumentException("Invalid key/value pair value.");
			return new KeyValuePair<string, string>(value.Substring(0, eq), value.Length > eq ? value.Substring(eq + 1) : string.Empty);
		}
	}

	/// <summary>Provides a collection of sections within an initialization file.</summary>
	/// <seealso cref="ICollection{T}"/>
	public class InitializationFileSections : ICollection<InitializationFileSection>
	{
		private readonly InitializationFile file;

		/// <summary>Initializes a new instance of the <see cref="InitializationFileSections"/> class.</summary>
		/// <param name="privateProfileFile">The private profile file.</param>
		public InitializationFileSections(InitializationFile privateProfileFile) => file = privateProfileFile;

		/// <summary>Gets the number of elements contained in the <see cref="ICollection{T}"/>.</summary>
		public int Count => SectionNames.Length;

		/// <summary>Gets a value indicating whether the <see cref="ICollection{T}"/> is read-only.</summary>
		public bool IsReadOnly => false;

		private string[] SectionNames => GetPrivateProfileSectionNames(file.FullName);

		/// <summary>Gets the <see cref="InitializationFileSection"/> with the specified section name.</summary>
		/// <value>The <see cref="InitializationFileSection"/>.</value>
		/// <param name="sectionName">Name of the section.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public InitializationFileSection this[string sectionName] => new(file, sectionName);

		/// <summary>Adds the specified section name.</summary>
		/// <param name="sectionName">Name of the section.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">Duplicate name. - sectionName</exception>
		public InitializationFileSection Add(string sectionName)
		{
			if (Contains(sectionName))
				throw new ArgumentException("Duplicate name.", nameof(sectionName));
			var ret = new InitializationFileSection(file, sectionName);
			Win32Error.ThrowLastErrorIfFalse(WritePrivateProfileSection(sectionName, new string[0], file.FullName));
			return ret;
		}

		/// <summary>Removes all items from the <see cref="ICollection{T}"/>.</summary>
		public void Clear()
		{
			foreach (var s in SectionNames)
				Remove(s);
		}

		/// <summary>Determines whether this instance contains the object.</summary>
		/// <param name="sectionName">Name of the section.</param>
		/// <returns><see langword="true"/> if [contains] [the specified section name]; otherwise, <see langword="false"/>.</returns>
		public bool Contains(string sectionName) => SectionNames.Contains(sectionName, StringComparer.InvariantCultureIgnoreCase);

		/// <summary>
		/// Copies the elements of the <see cref="ICollection{T}"/> to an <see cref="Array"/>, starting at a particular <see
		/// cref="Array"/> index.
		/// </summary>
		/// <param name="array">
		/// The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see cref="ICollection{T}"/>.
		/// The <see cref="Array"/> must have zero-based indexing.
		/// </param>
		/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
		public void CopyTo(InitializationFileSection[] array, int arrayIndex) => Array.Copy(Array.ConvertAll(SectionNames, n => new InitializationFileSection(file, n)), 0, array, arrayIndex, Count);

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		public IEnumerator<InitializationFileSection> GetEnumerator() => SectionNames.Select(n => new InitializationFileSection(file, n)).GetEnumerator();

		/// <summary>Removes the specified section name.</summary>
		/// <param name="sectionName">Name of the section.</param>
		/// <returns></returns>
		public bool Remove(string sectionName) => WritePrivateProfileString(sectionName, null, null, file.FullName);

		/// <summary>Removes the first occurrence of a specific object from the <see cref="ICollection{T}"/>.</summary>
		/// <param name="item">The object to remove from the <see cref="ICollection{T}"/>.</param>
		/// <returns>
		/// <see langword="true"/> if <paramref name="item"/> was successfully removed from the <see cref="ICollection{T}"/>; otherwise,
		/// <see langword="false"/>. This method also returns <see langword="false"/> if <paramref name="item"/> is not found in the
		/// original <see cref="ICollection{T}"/>.
		/// </returns>
		public bool Remove(InitializationFileSection item) => Remove(item.Name);

		/// <summary>Adds an item to the <see cref="ICollection{T}"/>.</summary>
		/// <param name="item">The object to add to the <see cref="ICollection{T}"/>.</param>
		void ICollection<InitializationFileSection>.Add(InitializationFileSection item) => Add(item.Name);

		/// <summary>Determines whether this instance contains the object.</summary>
		/// <param name="item">The object to locate in the <see cref="ICollection{T}"/>.</param>
		/// <returns>
		/// <see langword="true"/> if <paramref name="item"/> is found in the <see cref="ICollection{T}"/>; otherwise, <see langword="false"/>.
		/// </returns>
		bool ICollection<InitializationFileSection>.Contains(InitializationFileSection item) => Contains(item.Name);

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
