using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using TYPEDESC = System.Runtime.InteropServices.ComTypes.TYPEDESC;

namespace Vanara.PInvoke
{
	public static partial class OleAut32
	{
		/// <summary>Identifies the calling convention used by a member function described in the METHODDATA structure.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/ne-oaidl-callconv typedef enum tagCALLCONV { CC_FASTCALL, CC_CDECL,
		// CC_MSCPASCAL, CC_PASCAL, CC_MACPASCAL, CC_STDCALL, CC_FPFASTCALL, CC_SYSCALL, CC_MPWCDECL, CC_MPWPASCAL, CC_MAX } CALLCONV;
		[PInvokeData("oaidl.h", MSDNShortId = "1dadd0e2-5b99-49ea-965f-9bdfd3b904fb")]
		public enum CALLCONV
		{
			/// <summary>Indicates that the Cdecl calling convention is used for a method.</summary>
			CC_CDECL = 1,

			/// <summary>Indicates that the Fastcall calling convention is used for a method.</summary>
			CC_FASTCALL = 0,

			/// <summary>Indicates that the FPFastcall calling convention is used for a method.</summary>
			CC_FPFASTCALL = 5,

			/// <summary>Indicates that the Macpascal calling convention is used for a method.</summary>
			CC_MACPASCAL = 3,

			/// <summary>Indicates the end of the CALLCONV enumeration.</summary>
			CC_MAX = 9,

			/// <summary>Indicates that the Mpwcdecl calling convention is used for a method.</summary>
			CC_MPWCDECL = 7,

			/// <summary>Indicates that the Mpwpascal calling convention is used for a method.</summary>
			CC_MPWPASCAL = 8,

			/// <summary>Indicates that the Mscpascal calling convention is used for a method.</summary>
			CC_MSCPASCAL = 2,

			/// <summary>Indicates that the Pascal calling convention is used for a method.</summary>
			CC_PASCAL = 2,

			/// <summary>Indicates that the Stdcall calling convention is used for a method.</summary>
			CC_STDCALL = 4,

			/// <summary>Indicates that the Syscall calling convention is used for a method.</summary>
			CC_SYSCALL = 6,
		}

		/// <summary>Used by <see cref="ITypeChangeEvents"/> functions.</summary>
		public enum CHANGEKIND
		{
			/// <summary/>
			CHANGEKIND_ADDMEMBER,

			/// <summary/>
			CHANGEKIND_DELETEMEMBER,

			/// <summary/>
			CHANGEKIND_SETNAMES,

			/// <summary/>
			CHANGEKIND_SETDOCUMENTATION,

			/// <summary/>
			CHANGEKIND_GENERAL,

			/// <summary/>
			CHANGEKIND_INVALIDATE,

			/// <summary/>
			CHANGEKIND_CHANGEFAILED,

			/// <summary/>
			CHANGEKIND_MAX
		}

		/// <summary>Identifies the type of data contained in a <c>PROPBAG2</c> structure.</summary>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa751953(v=vs.85) typedef
		// enum _tagPROPBAG2_TYPE { PROPBAG2_TYPE_UNDEFINED = 0, PROPBAG2_TYPE_DATA = 1, PROPBAG2_TYPE_URL = 2, PROPBAG2_TYPE_OBJECT = 3,
		// PROPBAG2_TYPE_STREAM = 4, PROPBAG2_TYPE_STORAGE = 5, PROPBAG2_TYPE_MONIKER = 6 } PROPBAG2_TYPE;
		[PInvokeData("Ocidl.h")]
		public enum PROPBAG2_TYPE
		{
			/// <summary>Value type is unknown or undefined.</summary>
			PROPBAG2_TYPE_UNDEFINED,

			/// <summary>Value type is simple data.</summary>
			PROPBAG2_TYPE_DATA,

			/// <summary>Value type is a URL reference.</summary>
			PROPBAG2_TYPE_URL,

			/// <summary>Value type is an object.</summary>
			PROPBAG2_TYPE_OBJECT,

			/// <summary>Value type is a stream.</summary>
			PROPBAG2_TYPE_STREAM,

			/// <summary>Value type is storage.</summary>
			PROPBAG2_TYPE_STORAGE,

			/// <summary>Value type is a moniker.</summary>
			PROPBAG2_TYPE_MONIKER,
		}

		/// <summary>Frees resources on the server side when called by RPC stub files.</summary>
		/// <param name="arg1">The data used by RPC.</param>
		/// <param name="arg2">The object.</param>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-bstr_userfree void BSTR_UserFree( unsigned long *, BSTR * );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oaidl.h", MSDNShortId = "d15c2f80-abbd-4564-b962-a88a3bb7acb7")]
		public static unsafe extern void BSTR_UserFree(uint* arg1, byte* arg2);

		/// <summary>Frees resources on the server side when called by RPC stub files.</summary>
		/// <param name="arg1">The data used by RPC.</param>
		/// <param name="arg2">The object.</param>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-bstr_userfree64 void BSTR_UserFree64( unsigned long *, BSTR * );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oaidl.h", MSDNShortId = "40ef9c34-243d-49f1-a51f-db9c9f887b55")]
		public static unsafe extern void BSTR_UserFree64(uint* arg1, byte* arg2);

		/// <summary>Marshals a BSTR object into the RPC buffer.</summary>
		/// <param name="arg1">The data used by RPC.</param>
		/// <param name="arg2">The current buffer. This pointer may or may not be aligned on entry.</param>
		/// <param name="arg3">The object.</param>
		/// <returns>The value obtained from the returned <c>HRESULT</c> value is <c>S_OK</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-bstr_usermarshal unsigned char * BSTR_UserMarshal( unsigned
		// long *, unsigned char *, BSTR * );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oaidl.h", MSDNShortId = "98825155-1dd3-47c0-928d-484d5bc70927")]
		public static unsafe extern byte* BSTR_UserMarshal(uint* arg1, byte* arg2, byte* arg3);

		/// <summary>Marshals a BSTR object into the RPC buffer.</summary>
		/// <param name="arg1">The data used by RPC.</param>
		/// <param name="arg2">The current buffer. This pointer may or may not be aligned on entry.</param>
		/// <param name="arg3">The object.</param>
		/// <returns>The value obtained from the returned <c>HRESULT</c> value is <c>S_OK</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-bstr_usermarshal64 unsigned char * BSTR_UserMarshal64( unsigned
		// long *, unsigned char *, BSTR * );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oaidl.h", MSDNShortId = "f61b9e6b-14f1-4171-97c7-169547286626")]
		public static unsafe extern byte* BSTR_UserMarshal64(uint* arg1, byte* arg2, byte* arg3);

		/// <summary>Calculates the wire size of the BSTR object, and gets its handle and data.</summary>
		/// <param name="arg1">The data used by RPC.</param>
		/// <param name="arg2">
		/// The current buffer offset where the object will be marshaled. The method has to account for any padding needed for the BSTR
		/// object to be properly aligned when it will be marshaled to the buffer.
		/// </param>
		/// <param name="arg3">The object.</param>
		/// <returns>The value obtained from the returned <c>HRESULT</c> value is <c>S_OK</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-bstr_usersize unsigned long BSTR_UserSize( unsigned long *,
		// unsigned long , BSTR * );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oaidl.h", MSDNShortId = "16c349b4-21e1-45bb-8b24-d299adb36e14")]
		public static unsafe extern uint BSTR_UserSize(uint* arg1, uint arg2, byte* arg3);

		/// <summary>Calculates the wire size of the BSTR object, and gets its handle and data.</summary>
		/// <param name="arg1">The data used by RPC.</param>
		/// <param name="arg2">
		/// The current buffer offset where the object will be marshaled. The method has to account for any padding needed for the BSTR
		/// object to be properly aligned when it will be marshaled to the buffer.
		/// </param>
		/// <param name="arg3">The object.</param>
		/// <returns>The value obtained from the returned <c>HRESULT</c> value is <c>S_OK</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-bstr_usersize64 unsigned long BSTR_UserSize64( unsigned long *,
		// unsigned long , BSTR * );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oaidl.h", MSDNShortId = "56ba0992-b5df-419d-b531-ea974413a7b0")]
		public static unsafe extern uint BSTR_UserSize64(uint* arg1, uint arg2, byte* arg3);

		/// <summary>Unmarshals a BSTR object from the RPC buffer.</summary>
		/// <param name="arg1">The data used by RPC.</param>
		/// <param name="arg2">The current buffer. This pointer may or may not be aligned on entry.</param>
		/// <param name="arg3">The object.</param>
		/// <returns>
		/// <para>The value obtained from the returned <c>HRESULT</c> value is one of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory for this function to perform.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-bstr_userunmarshal unsigned char * BSTR_UserUnmarshal( unsigned
		// long *, unsigned char *, BSTR * );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oaidl.h", MSDNShortId = "d0a6229e-7091-4859-b539-d1e29044171a")]
		public static unsafe extern byte* BSTR_UserUnmarshal(uint* arg1, byte* arg2, byte* arg3);

		/// <summary>Unmarshals a BSTR object from the RPC buffer.</summary>
		/// <param name="arg1">The data used by RPC.</param>
		/// <param name="arg2">The current buffer. This pointer may or may not be aligned on entry.</param>
		/// <param name="arg3">The object.</param>
		/// <returns>
		/// <para>The value obtained from the returned <c>HRESULT</c> value is one of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory for this function to perform.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-bstr_userunmarshal64 unsigned char * BSTR_UserUnmarshal64(
		// unsigned long *, unsigned char *, BSTR * );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oaidl.h", MSDNShortId = "5d0bb71f-f8a2-4af7-b7e4-177997af2c9b")]
		public static unsafe extern byte* BSTR_UserUnmarshal64(uint* arg1, byte* arg2, byte* arg3);

		/// <summary>Frees resources on the server side when called by RPC stub files.</summary>
		/// <param name="arg1">The data used by RPC.</param>
		/// <param name="arg2">The object.</param>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-variant_userfree void VARIANT_UserFree( unsigned long *,
		// VARIANT * );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oaidl.h", MSDNShortId = "0432892b-af22-43d1-be3c-a98af950f0a7")]
		public static unsafe extern void VARIANT_UserFree(uint* arg1, VARIANT* arg2);

		/// <summary>Frees resources on the server side when called by RPC stub files.</summary>
		/// <param name="arg1">The data used by RPC.</param>
		/// <param name="arg2">The object.</param>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-variant_userfree64 void VARIANT_UserFree64( unsigned long *,
		// VARIANT * );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oaidl.h", MSDNShortId = "d36c9c17-13b1-4f68-9406-f17ed4c39062")]
		public static unsafe extern void VARIANT_UserFree64(uint* arg1, VARIANT* arg2);

		/// <summary>Marshals a VARIANT object into the RPC buffer.</summary>
		/// <param name="arg1">The data used by RPC.</param>
		/// <param name="arg2">The current buffer. This pointer may or may not be aligned on entry.</param>
		/// <param name="arg3">The object.</param>
		/// <returns>
		/// <para>The value obtained from the returned <c>HRESULT</c> value is one of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pVariant parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>RPC_X_NULL_REF_POINTER</term>
		/// <term>The pVariant parameter is null.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_BADVARTYPE</term>
		/// <term>The input parameter is not a valid type of variant.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-variant_usermarshal unsigned char * VARIANT_UserMarshal(
		// unsigned long *, unsigned char *, VARIANT * );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oaidl.h", MSDNShortId = "1c273053-9a9e-4a04-af35-995378bc0142")]
		public static unsafe extern byte* VARIANT_UserMarshal(uint* arg1, byte* arg2, VARIANT* arg3);

		/// <summary>Marshals a VARIANT object into the RPC buffer.</summary>
		/// <param name="arg1">The data used by RPC.</param>
		/// <param name="arg2">The current buffer. This pointer may or may not be aligned on entry.</param>
		/// <param name="arg3">The object.</param>
		/// <returns>
		/// <para>The value obtained from the returned <c>HRESULT</c> value is one of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pVariant parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>RPC_X_NULL_REF_POINTER</term>
		/// <term>The pVariant parameter is null.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_BADVARTYPE</term>
		/// <term>The input parameter is not a valid type of variant.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-variant_usermarshal64 unsigned char * VARIANT_UserMarshal64(
		// unsigned long *, unsigned char *, VARIANT * );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oaidl.h", MSDNShortId = "af9f85fa-b123-49da-99c7-552cd03197c0")]
		public static unsafe extern byte* VARIANT_UserMarshal64(uint* arg1, byte* arg2, VARIANT* arg3);

		/// <summary>Calculates the wire size of the VARIANT object, and gets its handle and data.</summary>
		/// <param name="arg1">The data used by RPC.</param>
		/// <param name="arg2">
		/// The current buffer offset where the object will be marshaled. The method has to account for any padding needed for the object to
		/// be properly aligned when it will be marshaled to the buffer.
		/// </param>
		/// <param name="arg3">The object.</param>
		/// <returns>The value obtained from the returned <c>HRESULT</c> value is <c>S_OK</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-variant_usersize unsigned long VARIANT_UserSize( unsigned long
		// *, unsigned long , VARIANT * );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oaidl.h", MSDNShortId = "64dc64e5-3de3-4133-835c-b832f5bb20ae")]
		public static unsafe extern uint VARIANT_UserSize(uint* arg1, uint arg2, VARIANT* arg3);

		/// <summary>Calculates the wire size of the VARIANT object, and gets its handle and data.</summary>
		/// <param name="arg1">The data used by RPC.</param>
		/// <param name="arg2">
		/// The current buffer offset where the object will be marshaled. The method has to account for any padding needed for the object to
		/// be properly aligned when it will be marshaled to the buffer.
		/// </param>
		/// <param name="arg3">The object.</param>
		/// <returns>The value obtained from the returned <c>HRESULT</c> value is <c>S_OK</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-variant_usersize64 unsigned long VARIANT_UserSize64( unsigned
		// long *, unsigned long , VARIANT * );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oaidl.h", MSDNShortId = "a6ae00a6-f126-4550-ae46-96c5ba1aee35")]
		public static unsafe extern uint VARIANT_UserSize64(uint* arg1, uint arg2, VARIANT* arg3);

		/// <summary>Unmarshals a VARIANT object from the RPC buffer.</summary>
		/// <param name="arg1">The data used by RPC.</param>
		/// <param name="arg2">The current buffer. This pointer may or may not be aligned on entry.</param>
		/// <param name="arg3">The object.</param>
		/// <returns>
		/// <para>The value obtained from the returned <c>HRESULT</c> value is one of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pVariant parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>RPC_X_BAD_STUB_DATA</term>
		/// <term>The stub data for the buffer size is incorrect.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_BADVARTYPE</term>
		/// <term>The input parameter is not a valid type of variant.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory for this function to perform.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-variant_userunmarshal unsigned char * VARIANT_UserUnmarshal(
		// unsigned long *, unsigned char *, VARIANT * );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oaidl.h", MSDNShortId = "ec7de7f3-f64a-4ec5-9b92-450bb7d6b37b")]
		public static unsafe extern byte* VARIANT_UserUnmarshal(uint* arg1, byte* arg2, VARIANT* arg3);

		/// <summary>Unmarshals a VARIANT object from the RPC buffer.</summary>
		/// <param name="arg1">The data used by RPC.</param>
		/// <param name="arg2">The current buffer. This pointer may or may not be aligned on entry.</param>
		/// <param name="arg3">The object.</param>
		/// <returns>
		/// <para>The value obtained from the returned <c>HRESULT</c> value is one of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pVariant parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>RPC_X_BAD_STUB_DATA</term>
		/// <term>The stub data for the buffer size is incorrect.</term>
		/// </item>
		/// <item>
		/// <term>DISP_E_BADVARTYPE</term>
		/// <term>The input parameter is not a valid type of variant.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory for this function to perform.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-variant_userunmarshal64 unsigned char *
		// VARIANT_UserUnmarshal64( unsigned long *, unsigned char *, VARIANT * );
		[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oaidl.h", MSDNShortId = "c4539285-20c2-4eda-acbc-1f1a80cad07b")]
		public static unsafe extern byte* VARIANT_UserUnmarshal64(uint* arg1, byte* arg2, VARIANT* arg3);

		/// <summary>Describes an array, its element type, and its dimension.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/ns-oaidl-arraydesc
		// typedef struct tagARRAYDESC { TYPEDESC tdescElem; USHORT cDims; SAFEARRAYBOUND rgbounds[1]; } ARRAYDESC;
		[PInvokeData("oaidl.h", MSDNShortId = "NS:oaidl.tagARRAYDESC")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<ARRAYDESC>), nameof(cDims))]
		[StructLayout(LayoutKind.Sequential)]
		public struct ARRAYDESC
		{
			/// <summary>The element type.</summary>
			public TYPEDESC tdescElem;

			/// <summary>The dimension count.</summary>
			public ushort cDims;

			/// <summary>A variable-length array containing one element for each dimension.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public SAFEARRAYBOUND[] rgbounds;
		}

		/// <summary>Represents custom data.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/ns-oaidl-custdata typedef struct tagCUSTDATA { DWORD cCustData;
		// LPCUSTDATAITEM prgCustData; } CUSTDATA, *LPCUSTDATA;
		[PInvokeData("oaidl.h", MSDNShortId = "992199f2-1bac-428e-9699-0740654e1922")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CUSTDATA
		{
			/// <summary>The number of custom data items in the <c>prgCustData</c> array.</summary>
			public uint cCustData;

			/// <summary>The array of custom data items.</summary>
			public IntPtr prgCustData;

			/// <summary>Gets the array of <see cref="CUSTDATAITEM"/> structures.</summary>
			public CUSTDATAITEM[] Items => prgCustData.ToArray<CUSTDATAITEM>((int)cCustData);
		}

		/// <summary>Represents a custom data item.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/ns-oaidl-custdataitem typedef struct tagCUSTDATAITEM { GUID guid;
		// VARIANTARG varValue; } CUSTDATAITEM, *LPCUSTDATAITEM;
		[PInvokeData("oaidl.h", MSDNShortId = "dae0f1be-0b77-4af6-9983-d8cb313e5276")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CUSTDATAITEM
		{
			/// <summary>The unique identifier of the data item.</summary>
			public Guid guid;

			/// <summary>The value of the data item.</summary>
			public VARIANT varValue;
		}

		/// <summary>Contains information about the default value of a parameter.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/ns-oaidl-paramdescex
		// typedef struct tagPARAMDESCEX { ULONG cBytes; VARIANTARG varDefaultValue; } PARAMDESCEX, *LPPARAMDESCEX;
		[PInvokeData("oaidl.h", MSDNShortId = "NS:oaidl.tagPARAMDESCEX")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PARAMDESCEX
		{
			/// <summary>The size of the structure.</summary>
			public uint cBytes;

			/// <summary>The default value of the parameter.</summary>
			public VARIANT varDefaultValue;
		}

		/// <summary>Contains or receives property information.</summary>
		/// <remarks>
		/// The <c>PROPBAG2</c> structure is used with the <c>IPropertyBag2::GetPropertyInfo</c>, <c>IPropertyBag2::Read</c>, and
		/// <c>IPropertyBag2::Write</c> methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa768188(v=vs.85) typedef
		// struct _tagPROPBAG2 { DWORD dwType; VARTYPE vt; CLIPFORMAT cfType; DWORD dwHint; LPOLESTR pstrName; CLSID clsid; } PROPBAG2;
		[PInvokeData("Ocidl.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROPBAG2
		{
			/// <summary>Type of property. This will be one of the PROPBAG2_TYPE values.</summary>
			public PROPBAG2_TYPE dwType;

			/// <summary>VARIANT type of the property.</summary>
			public Ole32.VARTYPE vt;

			/// <summary>Clipboard format or MIME type of the property.</summary>
			public CLIPFORMAT cfType;

			/// <summary>
			/// Property name integer. If possible, this member will be filled by IPropertyBag2::GetPropertyInfo and can be used with
			/// IPropertyBag2::Read and IPropertyBag2::Write to accelerate the read or write operation. These values are not valid outside
			/// the property bag that created them.
			/// </summary>
			public uint dwHint;

			/// <summary>Pointer to a string that specifies the property name.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pstrName;

			/// <summary>CLSID of the object. This member is valid only if dwType is PROPBAG2_TYPE_OBJECT.</summary>
			public Guid clsid;
		}
	}
}