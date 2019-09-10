using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>Provides a mechanism to intercept and modify calls when the COM engine processes the calls.</summary>
		[PInvokeData("objidlbase.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("1008c4a0-7613-11cf-9af1-0020af6e72f4")]
		public interface IChannelHook
		{
			/// <summary/>
			[PreserveSig]
			void ClientGetSize(in Guid uExtent, in Guid riid, out uint pDataSize);

			/// <summary/>
			[PreserveSig]
			void ClientFillBuffer(in Guid uExtent, in Guid riid, ref uint pDataSize, IntPtr pDataBuffer);

			/// <summary/>
			[PreserveSig]
			void ClientNotify(in Guid uExtent, in Guid riid, uint cbDataSize, IntPtr pDataBuffer, uint lDataRep, HRESULT hrFault);

			/// <summary/>
			[PreserveSig]
			void ServerNotify(in Guid uExtent, in Guid riid, uint cbDataSize, IntPtr pDataBuffer, uint lDataRep);

			/// <summary/>
			[PreserveSig]
			void ServerGetSize(in Guid uExtent, in Guid riid, HRESULT hrFault, out uint pDataSize);

			/// <summary/>
			[PreserveSig]
			void ServerFillBuffer(in Guid uExtent, in Guid riid, ref uint pDataSize, IntPtr pDataBuffer, HRESULT hrFault);
		};
	}
}