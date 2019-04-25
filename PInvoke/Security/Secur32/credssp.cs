using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Secur32
	{
		/// <summary>The <c>CREDSPP_SUBMIT_TYPE</c> enumeration specifies the type of credentials specified by a CREDSSP_CRED structure.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/credssp/ne-credssp-_credssp_submit_type typedef enum _CREDSSP_SUBMIT_TYPE {
		// CredsspPasswordCreds, CredsspSchannelCreds, CredsspCertificateCreds, CredsspSubmitBufferBoth, CredsspSubmitBufferBothOld,
		// CredsspCredEx } CREDSPP_SUBMIT_TYPE;
		[PInvokeData("credssp.h", MSDNShortId = "d30e219b-ea39-41da-b714-3ceb13a5614d")]
		public enum CREDSSP_SUBMIT_TYPE
		{
			/// <summary>The credentials are a user name and password.</summary>
			CredsspPasswordCreds = 2,

			/// <summary>The credentials are Schannel credentials.</summary>
			CredsspSchannelCreds = 4,

			/// <summary>The credentials are in a certificate.</summary>
			CredsspCertificateCreds = 13,

			/// <summary>The credentials contain both certificate and Schannel credentials.</summary>
			CredsspSubmitBufferBoth = 50,

			/// <summary/>
			CredsspSubmitBufferBothOld = 51,

			/// <summary/>
			CredsspCredEx = 100,
		}

		/// <summary>The <c>CREDSSP_CRED</c> structure specifies authentication data for both Schannel and Negotiate security packages.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/credssp/ns-credssp-_credssp_cred typedef struct _CREDSSP_CRED {
		// CREDSPP_SUBMIT_TYPE Type; PVOID pSchannelCred; PVOID pSpnegoCred; } CREDSSP_CRED, *PCREDSSP_CRED;
		[PInvokeData("credssp.h", MSDNShortId = "b22bd22c-e6e1-4817-b5cf-ab49f574e75f")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct CREDSSP_CRED
		{
			/// <summary>The CREDSPP_SUBMIT_TYPE enumeration value that specifies the type of credentials contained in this structure.</summary>
			public CREDSSP_SUBMIT_TYPE Type;

			/// <summary>A pointer to a set of Schannel credentials.</summary>
			public IntPtr pSchannelCred;

			/// <summary>A pointer to a set of Negotiate credentials.</summary>
			public IntPtr pSpnegoCred;
		}

		/// <summary>The <c>CREDSSP_CRED_EX</c> structure specifies authentication data for both Schannel and Negotiate security packages.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/credssp/ns-credssp-_credssp_cred typedef struct _CREDSSP_CRED {
		[PInvokeData("credssp.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct CREDSSP_CRED_EX
		{
			/// <summary>The CREDSPP_SUBMIT_TYPE enumeration value that specifies the type of credentials contained in this structure.</summary>
			public CREDSSP_SUBMIT_TYPE Type;

			public uint Version;

			public uint Flags;

			public uint Reserved;

			public CREDSSP_CRED Cred;
		}
	}
}