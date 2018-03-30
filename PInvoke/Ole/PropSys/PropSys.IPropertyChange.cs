using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke
{
	public static partial class PropSys
	{
		[ComImport, Guid("fc0ca0a7-c316-4fd2-9031-3e628e6d4f23"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IObjectWithPropertyKey
		{
			void SetPropertyKey(ref PROPERTYKEY key);
			PROPERTYKEY GetPropertyKey();
		}

		[ComImport, Guid("f917bc8a-1bba-4478-a245-1bde03eb9431"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IPropertyChange : IObjectWithPropertyKey
		{
			new void SetPropertyKey(ref PROPERTYKEY key);
			new PROPERTYKEY GetPropertyKey();
			void ApplyToPropVariant([In] PROPVARIANT propvarIn, out PROPVARIANT ppropvarOut);
		}

		[ComImport, Guid("380f5cad-1b5e-42f2-805d-637fd392d31e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IPropertyChangeArray
		{
			uint GetCount();
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetAt([In] uint iIndex, [MarshalAs(UnmanagedType.LPStruct)] Guid riid);
			void InsertAt([In] uint iIndex, [In] IPropertyChange ppropChange);
			void Append([In] IPropertyChange ppropChange);
			void AppendOrReplace([In] IPropertyChange ppropChange);
			void RemoveAt([In] uint iIndex);
			void IsKeyInArray([In] ref PROPERTYKEY key);
		}
	}
}
