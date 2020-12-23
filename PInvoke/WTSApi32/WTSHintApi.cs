using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Items from the WTSApi32.dll</summary>
	public static partial class WTSApi32
	{
		/// <summary>Specifies the type of hint represented by a call to <see cref="WTSSetRenderHint"/>.</summary>
		[PInvokeData("wtshintapi.h", MSDNShortId = "NF:wtshintapi.WTSSetRenderHint")]
		public enum RENDER_HINT
		{
			/// <summary>
			/// The previous hint is cleared.
			/// <para>pHintData must be <c>NULL</c>.</para>
			/// </summary>
			RENDER_HINT_CLEAR = 0x0,

			/// <summary>
			/// Indicates the presence of moving video.
			/// <para>
			/// pHintData contains a RECT structure which specifies the coordinates and size of the rendering area. These per-monitor
			/// DPI-aware coordinates are relative to the client coordinates of the window represented by the hwndOwner parameter.
			/// </para>
			/// </summary>
			RENDER_HINT_VIDEO = 0x1,

			/// <summary>
			/// Indicates the presence of a window mapping.
			/// <para>
			/// pHintData contains a RECT structure which specifies the coordinates and size of the rendering area. These per-monitor
			/// DPI-aware coordinates are relative to the client coordinates of the window represented by the hwndOwner parameter.
			/// </para>
			/// <para>
			/// <c>Windows 8 and Windows Server 2012:</c> The coordinates are not DPI-aware before Windows 8.1 and Windows Server 2012 R2.
			/// </para>
			/// </summary>
			RENDER_HINT_MAPPEDWINDOW = 0x2,
		}

		/// <summary>
		/// <para>
		/// Used by an application that is displaying content that can be optimized for displaying in a remote session to identify the
		/// region of a window that is the actual content.
		/// </para>
		/// <para>In the remote session, this content will be encoded, sent to the client, then decoded and displayed.</para>
		/// </summary>
		/// <param name="pRenderHintID">
		/// The address of a value that identifies the rendering hint affected by this call. If a new hint is being created, this value must
		/// contain zero. This function will return a unique rendering hint identifier which is used for subsequent calls, such as clearing
		/// the hint.
		/// </param>
		/// <param name="hwndOwner">
		/// The handle of window linked to lifetime of the rendering hint. This window is used in situations where a hint target is removed
		/// without the hint being explicitly cleared.
		/// </param>
		/// <param name="renderHintType">
		/// <para>Specifies the type of hint represented by this call.</para>
		/// <para>RENDER_HINT_CLEAR (0)</para>
		/// <para>The previous hint is cleared.</para>
		/// <para>pHintData must be <c>NULL</c>.</para>
		/// <para>RENDER_HINT_VIDEO (1)</para>
		/// <para>Indicates the presence of moving video.</para>
		/// <para>
		/// pHintData contains a RECT structure which specifies the coordinates and size of the rendering area. These per-monitor DPI-aware
		/// coordinates are relative to the client coordinates of the window represented by the hwndOwner parameter.
		/// </para>
		/// <para>
		/// <c>Windows 8 and Windows Server 2012:</c> The coordinates are not DPI-aware before Windows 8.1 and Windows Server 2012 R2.
		/// </para>
		/// <para>RENDER_HINT_MAPPEDWINDOW (2)</para>
		/// <para>Indicates the presence of a window mapping.</para>
		/// <para>
		/// pHintData contains a RECT structure which specifies the coordinates and size of the rendering area. These per-monitor DPI-aware
		/// coordinates are relative to the client coordinates of the window represented by the hwndOwner parameter.
		/// </para>
		/// <para>
		/// <c>Windows 8 and Windows Server 2012:</c> The coordinates are not DPI-aware before Windows 8.1 and Windows Server 2012 R2.
		/// </para>
		/// </param>
		/// <param name="cbHintDataLength">The size, in <c>BYTE</c> s, of the pHintData buffer.</param>
		/// <param name="pHintData">
		/// <para>Additional data for the hint.</para>
		/// <para>The format of this data is dependent upon the value passed in the renderHintType parameter.</para>
		/// </param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wtshintapi/nf-wtshintapi-wtssetrenderhint HRESULT WTSSetRenderHint( UINT64
		// *pRenderHintID, HWND hwndOwner, DWORD renderHintType, DWORD cbHintDataLength, BYTE *pHintData );
		[DllImport(Lib_WTSApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wtshintapi.h", MSDNShortId = "NF:wtshintapi.WTSSetRenderHint")]
		public static extern HRESULT WTSSetRenderHint(ref ulong pRenderHintID, HWND hwndOwner, RENDER_HINT renderHintType, uint cbHintDataLength, [In, Optional] IntPtr pHintData);
	}
}