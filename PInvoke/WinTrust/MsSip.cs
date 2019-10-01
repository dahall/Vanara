using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Crypt32;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class WinTrust
	{
		/*
		CryptSIPAddProvider	The CryptSIPAddProvider function registers functions that are exported by a given DLL file that implements a Subject Interface Package (SIP).
		CryptSIPCreateIndirectData	Returns a SIP_INDIRECT_DATA structure that contains a hash of the supplied SIP_SUBJECTINFO structure, the digest algorithm, and an encoding attribute. The hash can be used as an indirect reference to the data.
		CryptSIPGetCaps	Retrieves the capabilities of a subject interface package (SIP).
		CryptSIPGetSignedDataMsg	Retrieves an Authenticode signature from the file.
		CryptSIPLoad	Loads the dynamic-link library (DLL) that implements a subject interface package (SIP) and assigns appropriate library export functions to a SIP_DISPATCH_INFO structure.
		CryptSIPPutSignedDataMsg	Stores an Authenticode signature in the target file.
		CryptSIPRemoveProvider	Removes registry details of a Subject Interface Package (SIP) DLL file added by a previous call to the CryptSIPAddProvider function.
		CryptSIPRemoveSignedDataMsg	Removes a specified Authenticode signature.
		CryptSIPRetrieveSubjectGuid	Retrieves a GUID based on the header information in a specified file.
		CryptSIPRetrieveSubjectGuidForCatalogFile	Retrieves the subject GUID associated with the specified file.
		CryptSIPVerifyIndirectData	Validates the indirect hashed data against the supplied subject.

		pCryptSIPGetCaps	Is implemented by an subject interface package (SIP) to report capabilities.
		pfnIsFileSupported	Queries the subject interface packages (SIPs) listed in the registry to determine which SIP handles the file type.
		pfnIsFileSupportedName	Queries the subject interface packages (SIPs) listed in the registry to determine which SIP handles the file type.

		MS_ADDINFO_BLOB	Provides additional information for in-memory BLOB subject types.
		MS_ADDINFO_CATALOGMEMBER	Provides additional information for catalog member subject types.
		MS_ADDINFO_FLAT	Provides additional information about flat or end-to-end subject types.
		SIP_ADD_NEWPROVIDER	Defines a subject interface package (SIP). This structure is used by the CryptSIPAddProvider function.
		SIP_CAP_SET_V2	Defines the capabilities of a subject interface package (SIP).
		SIP_CAP_SET_V3	Defines the capabilities of a subject interface package (SIP).
		SIP_DISPATCH_INFO	Contains a set of function pointers assigned by the CryptSIPLoad function that your application uses to perform subject interface package (SIP) operations.
		SIP_INDIRECT_DATA	Contains the digest of the hashed subject information.
		SIP_SUBJECTINFO	Specifies subject information data to the subject interface package (SIP) APIs.
		*/
	}
}