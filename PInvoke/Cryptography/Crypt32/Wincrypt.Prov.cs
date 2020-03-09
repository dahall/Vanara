using System;
using System.Runtime.InteropServices;
using System.Security;
using Vanara.Extensions;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	/// <summary>Methods and data types found in Crypt32.dll.</summary>
	public static partial class Crypt32
	{
		/*
		CryptAcquireContext	
		[!Important]
		This API is deprecated. New and existing software should start using Cryptography Next Generation APIs. Microsoft may remove this API in future releases.

		Acquires a handle to the current user's key container within a particular CSP.
		CryptContextAddRef	
		[!Important]
		This API is deprecated. New and existing software should start using Cryptography Next Generation APIs. Microsoft may remove this API in future releases.

		Increments the reference count on an HCRYPTPROV handle.
		CryptEnumProviders	
		[!Important]
		This API is deprecated. New and existing software should start using Cryptography Next Generation APIs. Microsoft may remove this API in future releases.

		Enumerates the providers on a computer.
		CryptEnumProviderTypes	
		[!Important]
		This API is deprecated. New and existing software should start using Cryptography Next Generation APIs. Microsoft may remove this API in future releases.

		Enumerates the types of providers supported on the computer.
		CryptGetDefaultProvider	
		[!Important]
		This API is deprecated. New and existing software should start using Cryptography Next Generation APIs. Microsoft may remove this API in future releases.

		Determines the default CSP either for the current user or for the computer for a specified provider type.
		CryptGetProvParam	
		[!Important]
		This API is deprecated. New and existing software should start using Cryptography Next Generation APIs. Microsoft may remove this API in future releases.

		Retrieves the parameters that govern the operations of a CSP.
		CryptInstallDefaultContext	
		[!Important]
		This API is deprecated. New and existing software should start using Cryptography Next Generation APIs. Microsoft may remove this API in future releases.

		Installs a previously acquired HCRYPTPROV context to be used as a default context.
		CryptReleaseContext	
		[!Important]
		This API is deprecated. New and existing software should start using Cryptography Next Generation APIs. Microsoft may remove this API in future releases.

		Releases the handle acquired by the CryptAcquireContext function.
		CryptSetProvider and CryptSetProviderEx	
		[!Important]
		This API is deprecated. New and existing software should start using Cryptography Next Generation APIs. Microsoft may remove this API in future releases.

		Specifies the user default CSP for a particular CSP type.
		CryptSetProvParam	
		[!Important]
		This API is deprecated. New and existing software should start using Cryptography Next Generation APIs. Microsoft may remove this API in future releases.

		Specifies attributes of a CSP.
		CryptUninstallDefaultContext	
		[!Important]
		This API is deprecated. New and existing software should start using Cryptography Next Generation APIs. Microsoft may remove this API in future releases.

		Removes a default context previously installed by CryptInstallDefaultContext.
		FreeCryptProvFromCertEx	Releases the handle either to a cryptographic service provider (CSP) or to a Cryptography API: Next Generation (CNG) key.
		*/
	}
}
