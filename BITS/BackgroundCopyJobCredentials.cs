using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static Vanara.PInvoke.BITS;

namespace Vanara.IO
{
	/// <summary>Represents a single BITS job credential.</summary>
	/// <seealso cref="System.IComparable{T}"/>
	public class BackgroundCopyJobCredential : IComparable<BackgroundCopyJobCredential>
	{
		/// <summary>Initializes a new instance of the <see cref="BackgroundCopyJobCredential"/> class.</summary>
		/// <param name="scheme">The scheme.</param>
		/// <param name="target">The target.</param>
		/// <param name="username">The user name.</param>
		/// <param name="password">The password.</param>
		public BackgroundCopyJobCredential(BackgroundCopyJobCredentialScheme scheme, BackgroundCopyJobCredentialTarget target, string username, string password)
		{
			Scheme = scheme;
			Target = target;
			UserName = username;
			Password = password;
		}

		/// <summary>Gets the password.</summary>
		/// <value>The password.</value>
		public string Password { get; }

		/// <summary>Gets the scheme.</summary>
		/// <value>The scheme.</value>
		public BackgroundCopyJobCredentialScheme Scheme { get; }

		/// <summary>Gets the target.</summary>
		/// <value>The target.</value>
		public BackgroundCopyJobCredentialTarget Target { get; }

		/// <summary>Gets the name of the user.</summary>
		/// <value>The name of the user.</value>
		public string UserName { get; }

		internal uint Key => BackgroundCopyJobCredentials.MakeKey(Scheme, Target);

		int IComparable<BackgroundCopyJobCredential>.CompareTo(BackgroundCopyJobCredential other) => Comparer<uint>.Default.Compare(Key, other.Key);

		internal BG_AUTH_CREDENTIALS GetNative()
		{
			var cr = new BG_AUTH_CREDENTIALS { Scheme = (BG_AUTH_SCHEME)Scheme, Target = (BG_AUTH_TARGET)Target };
			cr.Credentials.Basic.UserName = UserName;
			cr.Credentials.Basic.Password = Password;
			return cr;
		}
	}

	/// <summary>The list of credentials for a job.</summary>
	/// <seealso cref="System.IDisposable"/>
	/// <seealso cref="System.Collections.Generic.ICollection{T}"/>
	public class BackgroundCopyJobCredentials : IDisposable, ICollection<BackgroundCopyJobCredential>
	{
		private Dictionary<uint, BackgroundCopyJobCredential> dict;
		private IBackgroundCopyJob2 ijob2;

		internal BackgroundCopyJobCredentials(IBackgroundCopyJob2 job)
		{
			ijob2 = job;
		}

		/// <summary>Gets the number of elements contained in the <see cref="ICollection{T}"/>.</summary>
		public int Count => dict?.Count ?? 0;

		/// <summary>Gets a value indicating whether the <see cref="ICollection{T}"/> is read-only.</summary>
		bool ICollection<BackgroundCopyJobCredential>.IsReadOnly => false;

		private Dictionary<uint, BackgroundCopyJobCredential> Values => dict ??= new Dictionary<uint, BackgroundCopyJobCredential>();

		/// <summary>Gets the <see cref="BackgroundCopyJobCredential"/> with the specified scheme and target.</summary>
		/// <param name="scheme">The credential scheme.</param>
		/// <param name="target">The credential target.</param>
		/// <returns>The <see cref="BackgroundCopyJobCredential"/>.</returns>
		public BackgroundCopyJobCredential this[BackgroundCopyJobCredentialScheme scheme, BackgroundCopyJobCredentialTarget target] =>
					Values[MakeKey(scheme, target)];

		/// <summary>Adds the specified credential.</summary>
		/// <param name="cred">The credential.</param>
		public void Add(BackgroundCopyJobCredential cred)
		{
			var cr = cred.GetNative();
			ijob2.SetCredentials(ref cr);
			Values.Add(cred.Key, cred);
		}

		/// <summary>Adds the specified credential.</summary>
		/// <param name="scheme">The credential scheme.</param>
		/// <param name="target">The credential target.</param>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		public void Add(BackgroundCopyJobCredentialScheme scheme, BackgroundCopyJobCredentialTarget target, string username, string password)
		{
			Add(new BackgroundCopyJobCredential(scheme, target, username, password));
		}

		/// <summary>Removes all items from the <see cref="ICollection{T}"/>.</summary>
		public void Clear()
		{
			if (dict is null) return;
			foreach (var key in Values.Keys)
				Remove(Values[key]);
		}

		/// <summary>Determines whether the <see cref="ICollection{T}"/> contains a specific value.</summary>
		/// <param name="item">The object to locate in the <see cref="ICollection{T}"/>.</param>
		/// <returns>true if <paramref name="item"/> is found in the <see cref="ICollection{T}"/>; otherwise, false.</returns>
		public bool Contains(BackgroundCopyJobCredential item) => dict is not null && Values.ContainsKey(item.Key);

		/// <summary>
		/// Copies the elements of the <see cref="ICollection{T}"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
		/// </summary>
		/// <param name="array">
		/// The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="ICollection{T}"/>. The
		/// <see cref="T:System.Array"/> must have zero-based indexing.
		/// </param>
		/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
		public void CopyTo(BackgroundCopyJobCredential[] array, int arrayIndex)
		{
			if (dict is null) return;
			Array.Copy(Values.Values.ToArray(), 0, array, arrayIndex, Count);
		}

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<BackgroundCopyJobCredential> GetEnumerator() => Values.Values.GetEnumerator();

		/// <summary>Removes the specified scheme.</summary>
		/// <param name="scheme">The scheme.</param>
		/// <param name="target">The target.</param>
		/// <returns></returns>
		public bool Remove(BackgroundCopyJobCredentialScheme scheme, BackgroundCopyJobCredentialTarget target)
		{
			try
			{
				ijob2.RemoveCredentials((BG_AUTH_TARGET)target, (BG_AUTH_SCHEME)scheme);
				if (dict is not null)
					Values.Remove(MakeKey(scheme, target));
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>Removes the first occurrence of a specific object from the <see cref="ICollection{T}"/>.</summary>
		/// <param name="item">The object to remove from the <see cref="ICollection{T}"/>.</param>
		/// <returns>
		/// true if <paramref name="item"/> was successfully removed from the <see cref="ICollection{T}"/>; otherwise, false. This method also returns false if
		/// <paramref name="item"/> is not found in the original <see cref="ICollection{T}"/>.
		/// </returns>
		public bool Remove(BackgroundCopyJobCredential item) => Remove(item.Scheme, item.Target);

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		void IDisposable.Dispose()
		{
			ijob2 = null;
		}

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		internal static uint MakeKey(BackgroundCopyJobCredentialScheme scheme, BackgroundCopyJobCredentialTarget target) => PInvoke.Macros.MAKELONG((ushort)scheme, (ushort)target);
	}
}