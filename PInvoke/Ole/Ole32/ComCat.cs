using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>
		/// Obtains information about the categories implemented or required by a certain class, as well as information about the categories
		/// registered on the specified computer.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nn-comcat-icatinformation
		[PInvokeData("comcat.h", MSDNShortId = "NN:comcat.ICatInformation")]
		[ComImport, Guid("0002E013-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ICatInformation
		{
			/// <summary>Retrieves an enumerator for the component categories registered on the system.</summary>
			/// <param name="lcid">
			/// The requested locale for any return szDescription of the enumerated categories. Typically, the caller specifies the value
			/// returned from the GetUserDefaultLCID function.
			/// </param>
			/// <returns>
			/// A pointer to a pointer to an IEnumCATEGORYINFO interface. This can be used to enumerate the CATIDs and localized description
			/// strings of the component categories registered with the system.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-icatinformation-enumcategories HRESULT EnumCategories(
			// LCID lcid, IEnumCATEGORYINFO **ppenumCategoryInfo );
			IEnumCATEGORYINFO EnumCategories(LCID lcid);

			/// <summary>Retrieves the localized description string for a specific category ID.</summary>
			/// <param name="rcatid">The category identifier.</param>
			/// <param name="lcid">The locale.</param>
			/// <param name="pszDesc">
			/// A pointer to the string pointer for the description. This string must be released by the caller using the CoTaskMemFree function.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-icatinformation-getcategorydesc HRESULT GetCategoryDesc(
			// REFCATID rcatid, LCID lcid, LPWSTR *pszDesc );
			void GetCategoryDesc(in Guid rcatid, LCID lcid, [MarshalAs(UnmanagedType.LPWStr)] out string pszDesc);

			/// <summary>Retrieves an enumerator for the classes that implement one or more specified category identifiers.</summary>
			/// <param name="cImplemented">
			/// The number of category IDs in the rgcatidImpl array. This value cannot be zero. If this value is -1, classes are included in
			/// the enumeration, regardless of the categories they implement.
			/// </param>
			/// <param name="rgcatidImpl">
			/// <para>An array of category identifiers.</para>
			/// <para>If a class requires a category identifier that is not specified, it is not included in the enumeration.</para>
			/// </param>
			/// <param name="cRequired">
			/// The number of category IDs in the rgcatidReq array. This value can be zero. If this value is -1, classes are included in the
			/// enumeration, regardless of the categories they require.
			/// </param>
			/// <param name="rgcatidReq">An array of category identifiers.</param>
			/// <returns>
			/// A pointer to an IEnumCLSID interface pointer that can be used to enumerate the CLSIDs of the classes that implement the
			/// specified category.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-icatinformation-enumclassesofcategories HRESULT
			// EnumClassesOfCategories( ULONG cImplemented, const CATID [] rgcatidImpl, ULONG cRequired, const CATID [] rgcatidReq,
			// IEnumGUID **ppenumClsid );
			IEnumGUID EnumClassesOfCategories(uint cImplemented, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] Guid[] rgcatidImpl, uint cRequired, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] Guid[] rgcatidReq);

			/// <summary>Determines whether a class implements one or more categories.</summary>
			/// <param name="rclsid">The class identifier.</param>
			/// <param name="cImplemented">
			/// The number of category IDs in the rgcatidImpl array. This value cannot be zero. If this value is -1, the implemented
			/// categories are not tested.
			/// </param>
			/// <param name="rgcatidImpl">
			/// <para>An array of category identifiers.</para>
			/// <para>If the class requires a category not listed in rgcatidReq, it is not included in the enumeration.</para>
			/// </param>
			/// <param name="cRequired">
			/// The number of category IDs in the rgcatidReq array. This value can be zero. If this value is -1, the required categories are
			/// not tested.
			/// </param>
			/// <param name="rgcatidReq">An array of category identifiers.</param>
			/// <returns>If the class ID is of one of the specified categories, the return value is S_OK. Otherwise, is it S_FALSE.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-icatinformation-isclassofcategories HRESULT
			// IsClassOfCategories( REFCLSID rclsid, ULONG cImplemented, const CATID [] rgcatidImpl, ULONG cRequired, const CATID []
			// rgcatidReq );
			[PreserveSig]
			HRESULT IsClassOfCategories(in Guid rclsid, uint cImplemented, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Guid[] rgcatidImpl, uint cRequired, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] Guid[] rgcatidReq);

			/// <summary>Retrieves an enumerator for the CATIDs implemented by the specified class.</summary>
			/// <param name="rclsid">The class ID.</param>
			/// <returns>
			/// A pointer to an IEnumCATID interface pointer. This can be used to enumerate the CATIDs that are implemented by rclsid.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-icatinformation-enumimplcategoriesofclass HRESULT
			// EnumImplCategoriesOfClass( REFCLSID rclsid, IEnumGUID **ppenumCatid );
			IEnumGUID EnumImplCategoriesOfClass(in Guid rclsid);

			/// <summary>Retrieves an enumerator for the CATIDs required by the specified class.</summary>
			/// <param name="rclsid">The class identifier.</param>
			/// <returns>
			/// A pointer to an IEnumCATID interface pointer. This can be used to enumerate the CATIDs that are required by rclsid.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-icatinformation-enumreqcategoriesofclass HRESULT
			// EnumReqCategoriesOfClass( REFCLSID rclsid, IEnumGUID **ppenumCatid );
			IEnumGUID EnumReqCategoriesOfClass(in Guid rclsid);
		}

		/// <summary>
		/// Provides methods for registering and unregistering component category information in the registry. This includes both the
		/// human-readable names of categories and the categories implemented/required by a given component or class.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nn-comcat-icatregister
		[ComImport, Guid("0002E012-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ICatRegister
		{
			/// <summary>
			/// Registers one or more component categories. Each component category consists of a CATID and a list of locale-dependent
			/// description strings.
			/// </summary>
			/// <param name="cCategories">The number of component categories to be registered.</param>
			/// <param name="rgCategoryInfo">
			/// An array of CATEGORYINFO structures, one for each category to be registered. By providing the same CATID for multiple
			/// <c>CATEGORYINFO</c> structures, multiple locales can be registered for the same component category.
			/// </param>
			/// <remarks>
			/// This method can only be called by the owner of a category, usually as part of the installation or de-installation of the
			/// operating system or application.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-icatregister-registercategories HRESULT
			// RegisterCategories( ULONG cCategories, CATEGORYINFO [] rgCategoryInfo );
			void RegisterCategories(uint cCategories, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] CATEGORYINFO[] rgCategoryInfo);

			/// <summary>
			/// Removes the registration of one or more component categories. Each component category consists of a CATID and a list of
			/// locale-dependent description strings.
			/// </summary>
			/// <param name="cCategories">The number of categories to be removed.</param>
			/// <param name="rgcatid">The CATIDs of the categories to be removed.</param>
			/// <remarks>
			/// <para>
			/// This method will be successful even if one or more of the category IDs specified are not registered. This method can only be
			/// called by the owner of a category, usually as part of the installation or de-installation of the operating system or application.
			/// </para>
			/// <para>
			/// This method does not remove the component category tags from individual classes. To do this, use the
			/// ICatRegister::UnRegisterClassReqCategories method.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-icatregister-unregistercategories HRESULT
			// UnRegisterCategories( ULONG cCategories, CATID [] rgcatid );
			void UnRegisterCategories(uint cCategories, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] Guid[] rgcatid);

			/// <summary>Registers the class as implementing one or more component categories.</summary>
			/// <param name="rclsid">The class identifier.</param>
			/// <param name="cCategories">The number of categories to be associated as category identifiers for the class.</param>
			/// <param name="rgcatid">An array of CATIDs to associate as category identifiers for the class.</param>
			/// <remarks>
			/// In case of an error, this method does not ensure that the registry is restored to the state prior to the call. This method
			/// can only be called by the owner of a class, usually as part of the installation of the component.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-icatregister-registerclassimplcategories HRESULT
			// RegisterClassImplCategories( REFCLSID rclsid, ULONG cCategories, CATID [] rgcatid );
			void RegisterClassImplCategories(in Guid rclsid, uint cCategories, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Guid[] rgcatid);

			/// <summary>Removes one or more implemented category identifiers from a class.</summary>
			/// <param name="rclsid">The class identifier.</param>
			/// <param name="cCategories">The number of category CATIDs to be removed.</param>
			/// <param name="rgcatid">An array of CATIDs that are to be removed. Only the category IDs specified in this array are removed.</param>
			/// <remarks>
			/// In case of an error, this method does not ensure that the registry is restored to the state prior to the call. This method
			/// will be successful even if one or more of the category IDs specified are not registered for the class. This method can only
			/// be called by the owner of a class, usually as part of the de-installation of the component.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-icatregister-unregisterclassimplcategories HRESULT
			// UnRegisterClassImplCategories( REFCLSID rclsid, ULONG cCategories, CATID [] rgcatid );
			void UnRegisterClassImplCategories(in Guid rclsid, uint cCategories, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Guid[] rgcatid);

			/// <summary>Registers the class as requiring one or more component categories.</summary>
			/// <param name="rclsid">The class identifier.</param>
			/// <param name="cCategories">The number of category CATIDs to be associated as category identifiers for the class.</param>
			/// <param name="rgcatid">An array of CATIDs to be associated as category identifiers for the class.</param>
			/// <remarks>
			/// In case of an error, this method does not ensure that the registry is restored to the state prior to the call. This method
			/// can only be called by the owner of a class, usually as part of the installation of the component.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-icatregister-registerclassreqcategories HRESULT
			// RegisterClassReqCategories( REFCLSID rclsid, ULONG cCategories, CATID [] rgcatid );
			void RegisterClassReqCategories(in Guid rclsid, uint cCategories, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Guid[] rgcatid);

			/// <summary>Removes one or more required category identifiers from a class.</summary>
			/// <param name="rclsid">The class identifier.</param>
			/// <param name="cCategories">The number of category CATIDs to be removed.</param>
			/// <param name="rgcatid">An array of CATIDs that are to be removed. Only the category IDs specified in this array are removed.</param>
			/// <remarks>
			/// In case of an error, this method does not ensure that the registry is restored to the state prior to the call. This method
			/// will be successful even if one or more of the category IDs specified are not registered for the class.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-icatregister-unregisterclassreqcategories HRESULT
			// UnRegisterClassReqCategories( REFCLSID rclsid, ULONG cCategories, CATID [] rgcatid );
			void UnRegisterClassReqCategories(in Guid rclsid, uint cCategories, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Guid[] rgcatid);
		}

		/// <summary>Enumerates component categories registered in the system.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nn-comcat-ienumcategoryinfo
		[ComImport, Guid("0002E011-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IEnumCATEGORYINFO
		{
			/// <summary>Retrieves the specified number of items in the enumeration sequence.</summary>
			/// <param name="celt">
			/// The number of items to be retrieved. If there are fewer than the requested number of items left in the sequence, this method
			/// retrieves the remaining elements.
			/// </param>
			/// <param name="rgelt">
			/// <para>An array of enumerated items.</para>
			/// <para>
			/// The enumerator is responsible for allocating any memory, and the caller is responsible for freeing it. If celt is greater
			/// than 1, the caller must also pass a non-NULL pointer passed to pceltFetched to know how many pointers to release.
			/// </para>
			/// </param>
			/// <param name="pceltFetched">
			/// The number of items that were retrieved. This parameter is always less than or equal to the number of items requested.
			/// </param>
			/// <returns>If the method retrieves the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-ienumcategoryinfo-next HRESULT Next( ULONG celt,
			// CATEGORYINFO *rgelt, ULONG *pceltFetched );
			[PreserveSig]
			HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] CATEGORYINFO[] rgelt, out uint pceltFetched);

			/// <summary>Skips over the specified number of items in the enumeration sequence.</summary>
			/// <param name="celt">The number of items to be skipped.</param>
			/// <returns>If the method skips the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-ienumcategoryinfo-skip HRESULT Skip( ULONG celt );
			[PreserveSig]
			HRESULT Skip(uint celt);

			/// <summary>Resets the enumeration sequence to the beginning.</summary>
			/// <remarks>
			/// There is no guarantee that the same set of objects will be enumerated after the reset operation has completed. A static
			/// collection is reset to the beginning, but it can be too expensive for some collections, such as files in a directory, to
			/// guarantee this condition.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-ienumcategoryinfo-reset HRESULT Reset();
			void Reset();

			/// <summary>
			/// <para>Creates a new enumerator that contains the same enumeration state as the current one.</para>
			/// <para>
			/// This method makes it possible to record a point in the enumeration sequence in order to return to that point at a later
			/// time. The caller must release this new enumerator separately from the first enumerator.
			/// </para>
			/// </summary>
			/// <returns>A pointer to the cloned enumerator object.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-ienumcategoryinfo-clone HRESULT Clone( IEnumCATEGORYINFO
			// **ppenum );
			IEnumCATEGORYINFO Clone();
		}

		/// <summary>Enables clients to enumerate through a collection of class IDs for COM classes.</summary>
		/// <remarks>Alternate names for this interface are IEnumCLSID and IEnumCATID.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nn-comcat-ienumguid
		[PInvokeData("comcat.h", MSDNShortId = "NN:comcat.IEnumGUID")]
		[ComImport, Guid("0002E000-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IEnumGUID
		{
			/// <summary>Retrieves the specified number of items in the enumeration sequence.</summary>
			/// <param name="celt">
			/// The number of items to be retrieved. If there are fewer than the requested number of items left in the sequence, this method
			/// retrieves the remaining elements.
			/// </param>
			/// <param name="rgelt">
			/// <para>An array of enumerated items.</para>
			/// <para>
			/// The enumerator is responsible for allocating any memory, and the caller is responsible for freeing it. If celt is greater
			/// than 1, the caller must also pass a non-NULL pointer passed to pceltFetched to know how many pointers to release.
			/// </para>
			/// </param>
			/// <param name="pceltFetched">
			/// The number of items that were retrieved. This parameter is always less than or equal to the number of items requested.
			/// </param>
			/// <returns>If the method retrieves the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-ienumguid-next HRESULT Next( ULONG celt, GUID *rgelt,
			// ULONG *pceltFetched );
			[PreserveSig]
			HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] Guid[] rgelt, out uint pceltFetched);

			/// <summary>Skips over the specified number of items in the enumeration sequence.</summary>
			/// <param name="celt">The number of items to be skipped.</param>
			/// <returns>If the method skips the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-ienumguid-skip HRESULT Skip( ULONG celt );
			[PreserveSig]
			HRESULT Skip(uint celt);

			/// <summary>Resets the enumeration sequence to the beginning.</summary>
			/// <remarks>
			/// There is no guarantee that the same set of objects will be enumerated after the reset operation has completed. A static
			/// collection is reset to the beginning, but it can be too expensive for some collections, such as files in a directory, to
			/// guarantee this condition.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-ienumguid-reset HRESULT Reset();
			void Reset();

			/// <summary>
			/// <para>Creates a new enumerator that contains the same enumeration state as the current one.</para>
			/// <para>
			/// This method makes it possible to record a point in the enumeration sequence in order to return to that point at a later
			/// time. The caller must release this new enumerator separately from the first enumerator.
			/// </para>
			/// </summary>
			/// <returns>A pointer to the cloned enumerator object.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/comcat/nf-comcat-ienumguid-clone HRESULT Clone( IEnumGUID **ppenum );
			IEnumGUID Clone();
		}

		/// <summary>Describes a component category.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/comcat/ns-comcat-categoryinfo typedef struct tagCATEGORYINFO { Guid catid;
		// LCID lcid; OLECHAR szDescription[128]; } CATEGORYINFO, *LPCATEGORYINFO;
		[PInvokeData("comcat.h", MSDNShortId = "NS:comcat.tagCATEGORYINFO")]
		[StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
		public struct CATEGORYINFO
		{
			/// <summary>The category identifier for the component.</summary>
			public Guid catid;

			/// <summary>The locale identifier. See Language Identifier Constants and Strings.</summary>
			public LCID lcid;

			/// <summary>The description of the category (cannot exceed 128 characters).</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string szDescription;
		}
	}
}