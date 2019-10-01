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
		CryptCATAdminAcquireContext	Acquires a handle to a catalog administrator context.
		CryptCATAdminAcquireContext2	Acquires a handle to a catalog administrator context for a given hash algorithm and hash policy.
		CryptCATAdminAddCatalog	Adds a catalog to the catalog database.
		CryptCATAdminCalcHashFromFileHandle	Calculates the hash for a file.
		CryptCATAdminCalcHashFromFileHandle2	Calculates the hash for a file by using the specified algorithm.
		CryptCATAdminEnumCatalogFromHash	Enumerates the catalogs that contain a specified hash.
		CryptCATAdminReleaseCatalogContext	Releases a handle to a catalog context previously returned by the CryptCATAdminAddCatalog function.
		CryptCATAdminReleaseContext	Releases the handle previously assigned by the CryptCATAdminAcquireContext function.
		CryptCATAdminRemoveCatalog	Deletes a catalog file and removes that catalog's entry from the Windows catalog database.
		CryptCATAdminResolveCatalogPath	Retrieves the fully qualified path of the specified catalog.
		CryptCATCatalogInfoFromContext	Retrieves catalog information from a specified catalog context.
		CryptCATCDFClose	Closes a catalog definition file (CDF) and frees the memory for the corresponding CRYPTCATCDF structure.
		CryptCATCDFEnumCatAttributes	Enumerates catalog-level attributes within the CatalogHeader section of a catalog definition file (CDF).
		CryptCATCDFOpen	Opens an existing catalog definition file (CDF) for reading and initializes a CRYPTCATCDF structure.
		CryptCATClose	Closes a catalog handle opened previously by the CryptCATOpen function.
		CryptCATEnumerateAttr	Enumerates the attributes associated with a member of a catalog. This function has no associated import library.
		CryptCATEnumerateCatAttr	Enumerates the attributes associated with a catalog. This function has no associated import library.
		CryptCATEnumerateMember	Enumerates the members of a catalog.
		CryptCATGetAttrInfo	Retrieves information about an attribute of a member of a catalog.
		CryptCATGetMemberInfo	Retrieves member information from the catalog's PKCS #7.
		CryptCATHandleFromStore	Retrieves a catalog handle from memory.
		CryptCATOpen	Opens a catalog and returns a context handle to the open catalog.
		CryptCATPersistStore	Saves the information in the specified catalog store to an unsigned catalog file.
		CryptCATPutAttrInfo	Allocates memory for an attribute and adds it to a catalog member.
		CryptCATPutCatAttrInfo	Allocates memory for a catalog file attribute and adds it to the catalog.
		CryptCATPutMemberInfo	Allocates memory for a catalog member and adds it to the catalog.
		CryptCATStoreFromHandle	Retrieves a CRYPTCATSTORE structure from a catalog handle.
		IsCatalogFile	Retrieves a Boolean value that indicates whether the specified file is a catalog file.

		PFN_CDF_PARSE_ERROR_CALLBACK	Called for Catalog Definition Function errors while parsing a catalog definition file (CDF).

		CATALOG_INFO	The CATALOG_INFO structure contains the name of a catalog file. This structure is used by the CryptCATCatalogInfoFromContext function.
		CRYPTCATATTRIBUTE	The CRYPTCATATTRIBUTE structure defines a catalog attribute. This structure is used by the CryptCATEnumerateAttr and CryptCATEnumerateCatAttr functions.
		CRYPTCATCDF	Contains information used to create a signed catalog file (.cat) from a catalog definition file (CDF).
		CRYPTCATMEMBER	The CRYPTCATMEMBER structure provides information about a catalog member. This structure is used by the CryptCATGetMemberInfo and CryptCATEnumerateAttr functions.
		CRYPTCATSTORE	Represents a catalog file.
		*/
	}
}