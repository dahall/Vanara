using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.InteropServices
{
	/// <summary>Marshals strings that are allocated by native code and must be freed using CoTaskMemFree after use.</summary>
	/// <seealso cref="System.Runtime.InteropServices.ICustomMarshaler"/>
	public class CoTaskMemStringMarshaler : ICustomMarshaler
	{
		private CharSet charSet = CharSet.Unicode;

		private CoTaskMemStringMarshaler(string cookie)
		{
			if (string.IsNullOrEmpty(cookie)) return;
			try { charSet = (CharSet)Enum.Parse(typeof(CharSet), cookie, true); } catch { }
		}

		/// <summary>Gets the instance.</summary>
		/// <param name="cookie">The cookie.</param>
		/// <returns>A new instance of this class.</returns>
		public static ICustomMarshaler GetInstance(string cookie) => new CoTaskMemStringMarshaler(cookie);

		/// <summary>Performs necessary cleanup of the managed data when it is no longer needed.</summary>
		/// <param name="ManagedObj">The managed object to be destroyed.</param>
		public void CleanUpManagedData(object ManagedObj)
		{
		}

		/// <summary>Performs necessary cleanup of the unmanaged data when it is no longer needed.</summary>
		/// <param name="pNativeData">A pointer to the unmanaged data to be destroyed.</param>
		public void CleanUpNativeData(IntPtr pNativeData)
		{
			StringHelper.FreeString(pNativeData, charSet);
		}

		/// <summary>Returns the size of the native data to be marshaled.</summary>
		/// <returns>The size in bytes of the native data.</returns>
		public int GetNativeDataSize() => IntPtr.Size;

		/// <summary>Converts the managed data to unmanaged data.</summary>
		/// <param name="ManagedObj">The managed object to be converted.</param>
		/// <returns>Returns the COM view of the managed object.</returns>
		public IntPtr MarshalManagedToNative(object ManagedObj) => StringHelper.AllocString(ManagedObj as string, charSet);

		/// <summary>Converts the unmanaged data to managed data.</summary>
		/// <param name="pNativeData">A pointer to the unmanaged data to be wrapped.</param>
		/// <returns>Returns the managed view of the COM data.</returns>
		public object MarshalNativeToManaged(IntPtr pNativeData) => StringHelper.GetString(pNativeData, charSet);
	}
}