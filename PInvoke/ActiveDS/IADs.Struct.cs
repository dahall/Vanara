using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace Vanara.PInvoke;

public static partial class ActiveDS
{
	/// <summary>
	/// <para>The <c>ADS_ATTR_DEF</c> structure is used only as a part of <c>IDirectorySchemaMgmt</c>, which is an obsolete interface. The following information is provided for legacy purposes only.</para>
	/// <para>The <c>ADS_ATTR_DEF</c> structure describes schema data for an attribute. It is used to manage attribute definitions in the schema.</para>
	/// </summary>
	/// <remarks>In ADSI, attributes and properties are used interchangeably.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_attr_def
	// typedef struct _ads_attr_def { LPWSTR pszAttrName; ADSTYPE dwADsType; DWORD dwMinRange; DWORD dwMaxRange; BOOL fMultiValued; } ADS_ATTR_DEF, *PADS_ATTR_DEF;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._ads_attr_def")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_ATTR_DEF
	{
		/// <summary>The null-terminated Unicode string that contains the name of the attribute.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszAttrName;

		/// <summary>Data type of the attribute as defined by ADSTYPEENUM.</summary>
		public ADSTYPE dwADsType;

		/// <summary>Minimum legal range for this attribute.</summary>
		public uint dwMinRange;

		/// <summary>Maximum legal range for this attribute.</summary>
		public uint dwMaxRange;

		/// <summary>Whether or not this attribute takes more than one value.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fMultiValued;
	}

	/// <summary>The <c>ADS_ATTR_INFO</c> structure is used to contain one or more attribute values for use with the IDirectoryObject::CreateDSObject, IDirectoryObject::GetObjectAttributes, or IDirectoryObject::SetObjectAttributes method.</summary>
	/// <remarks>
	/// <para>In ADSI, attributes and properties are used interchangeably. Set attributes, when creating a directory service object, using the IDirectoryObject::CreateDSObject method. The IDirectoryObject interface also supports the IDirectoryObject::GetObjectAttributes and IDirectoryObject::SetObjectAttributes methods for retrieving and modifying the attributes of the object in a directory.</para>
	/// <para>Memory for the array of ADSVALUE structures is not allocated with this structure.</para>
	/// <para>The value of the <c>dwControlCode</c> member is ignored when the structure is used as an OUT parameter.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_attr_info
	// typedef struct _ads_attr_info { LPWSTR pszAttrName; DWORD dwControlCode; ADSTYPE dwADsType; PADSVALUE pADsValues; DWORD dwNumValues; } ADS_ATTR_INFO, *PADS_ATTR_INFO;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._ads_attr_info")]
	[VanaraMarshaler(typeof(ADS_ATTR_INFO_UNMGD))]
	public struct ADS_ATTR_INFO
	{
		/// <summary>The null-terminated Unicode string that contains the attribute name.</summary>
		public string pszAttrName;

		/// <summary>Contains one of the ADSI Attribute Modification Types values that determines the type of operation to be performed on the attribute value.</summary>
		public ADS_ATTR dwControlCode;

		/// <summary>A value from the ADSTYPEENUM enumeration that indicates the data type of the attribute.</summary>
		public ADSTYPE dwADsType;

		/// <summary>Pointer to an array of ADSVALUE structures that contain values for the attribute.</summary>
		public (ADSTYPE type, object? value)[] pADsValues;

		[StructLayout(LayoutKind.Sequential)]
		internal struct ADS_ATTR_INFO_UNMGD : IVanaraMarshaler
		{
			public StrPtrUni pszAttrName;
			public ADS_ATTR dwControlCode;
			public ADSTYPE dwADsType;
			public IntPtr pADsValues;
			public uint dwNumValues;

			SizeT IVanaraMarshaler.GetNativeSize() => Marshal.SizeOf(this);

			SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject)
			{
				if (managedObject is not ADS_ATTR_INFO i)
					throw new ArgumentException("Invalid object", nameof(managedObject));

				var ret = SafeCoTaskMemHandle.CreateFromStructure<ADS_ATTR_INFO_UNMGD>();
				List<ADSVALUE> vals = i.pADsValues?.Select(t =>
				{
					ADSVALUE av = new();
					av.SetValue(t.type, t.value, out var m);
					ret.AddSubReference(m);
					return av;
				}).ToList() ?? [];
				var sz = Marshal.SizeOf(typeof(ADS_ATTR_INFO_UNMGD));
				var vsz = Marshal.SizeOf(typeof(ADSVALUE));
				SizeT ext = vsz * vals.Count + (i.pszAttrName?.GetByteCount(true, CharSet.Unicode) ?? 0);
				ret.Size += ext;

				ADS_ATTR_INFO_UNMGD ii = new()
				{
					dwControlCode = i.dwControlCode,
					dwADsType = i.dwADsType,
					dwNumValues = (uint?)i.pADsValues?.Length ?? 0,
					pszAttrName = ret.DangerousGetHandle().Offset(sz)
				};
				StringHelper.Write(i.pszAttrName, (IntPtr)ii.pszAttrName, out var l, true, CharSet.Unicode);
				ii.pADsValues = ret.DangerousGetHandle().Offset(sz + l);
				ii.pADsValues.Write(vals, sz + l);
				return ret;
			}

			object? IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
			{
				if (pNativeData == IntPtr.Zero || allocatedBytes == 0) return null;
				var ii = (ADS_ATTR_INFO_UNMGD)Marshal.PtrToStructure(pNativeData, typeof(ADS_ATTR_INFO_UNMGD))!;
				return new ADS_ATTR_INFO()
				{
					dwControlCode = ii.dwControlCode,
					dwADsType = ii.dwADsType,
					pszAttrName = ii.pszAttrName.ToString(),
					pADsValues = ii.pADsValues.ToIEnum<ADSVALUE>((int)ii.dwNumValues)?.Select(v => (v.dwType, v.Value)).ToArray() ?? []
				};
			}
		}
	}

	/// <summary>The <c>ADS_BACKLINK</c> structure is an ADSI representation of the <c>Back Link</c> attribute syntax.</summary>
	/// <remarks>A <c>Back Link</c> attribute contains one or more servers that hold an external reference to the attached object.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_backlink
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0008 { DWORD RemoteID; LPWSTR ObjectName; } ADS_BACKLINK, *PADS_BACKLINK;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0008")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_BACKLINK
	{
		/// <summary>Identifier of the remote server that requires an external reference to the object specified by <c>ObjectName</c>. See below.</summary>
		public uint RemoteID;

		/// <summary>The null-terminated Unicode string that specifies the name of an object to which the <c>Back Link</c> attribute is attached.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? ObjectName;
	}

	/// <summary>The <c>ADS_CASEIGNORE_LIST</c> structure is an ADSI representation of the <c>Case Ignore List</c> attribute syntax.</summary>
	/// <remarks>A <c>Case Ignore List</c> attribute represents an ordered sequence of case insensitive strings.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_caseignore_list
	// typedef struct _ADS_CASEIGNORE_LIST { struct _ADS_CASEIGNORE_LIST *Next; LPWSTR String; } ADS_CASEIGNORE_LIST, *PADS_CASEIGNORE_LIST;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._ADS_CASEIGNORE_LIST")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_CASEIGNORE_LIST
	{
		/// <summary>Pointer to the next <c>ADS_CASEIGNORE_LIST</c> in the list of case-insensitive strings.</summary>
		public IntPtr Next;

		/// <summary>The null-terminated Unicode string value of the current entry of the list.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string String;
	}

	/// <summary>
	/// <para>The <c>ADS_CLASS_DEF</c> structure is used only as a part of <c>IDirectorySchemaMgmt</c>, which is an obsolete interface. The information that follows is provided for legacy purposes only.</para>
	/// <para>The <c>ADS_CLASS_DEF</c> structure holds the definitions of an object class.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_class_def
	// typedef struct _ads_class_def { LPWSTR pszClassName; DWORD dwMandatoryAttrs; LPWSTR *ppszMandatoryAttrs; DWORD optionalAttrs; LPWSTR **ppszOptionalAttrs; DWORD dwNamingAttrs; LPWSTR **ppszNamingAttrs; DWORD dwSuperClasses; LPWSTR **ppszSuperClasses; BOOL fIsContainer; } ADS_CLASS_DEF, *PADS_CLASS_DEF;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._ads_class_def")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_CLASS_DEF
	{
		/// <summary>The null-terminated Unicode string that specifies the class name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszClassName;

		/// <summary>The number of mandatory class attributes.</summary>
		public uint dwMandatoryAttrs;

		/// <summary>Pointer to an array of null-terminated Unicode strings that contain the names of the mandatory attributes.</summary>
		public LPCWSTRArrayPointer ppszMandatoryAttrs;

		/// <summary>Number of optional attributes of the class.</summary>
		public uint optionalAttrs;

		/// <summary>Pointer to an array of null-terminated Unicode strings that contain the names of the optional attributes.</summary>
		public LPCWSTRArrayPointer ppszOptionalAttrs;

		/// <summary>Number of naming attributes.</summary>
		public uint dwNamingAttrs;

		/// <summary>Pointer to an array of null-terminated Unicode strings that contain the names of the naming attributes.</summary>
		public LPCWSTRArrayPointer ppszNamingAttrs;

		/// <summary>Number of super classes of an object of this class.</summary>
		public uint dwSuperClasses;

		/// <summary>Pointer to an array of null-terminated Unicode strings that contain the names of the super classes.</summary>
		public LPCWSTRArrayPointer ppszSuperClasses;

		/// <summary>Flags that indicate the object of the class is a container when it is <c>TRUE</c> and not a container when <c>FALSE</c>.</summary>
		public bool fIsContainer;
	}

	/// <summary>The <c>ADS_DN_WITH_BINARY</c> structure is used with the ADSVALUE structure to contain a distinguished name attribute value that also contains binary data.</summary>
	/// <remarks>When extending the active directory schema to add <c>ADS_DN_WITH_BINARY</c>, you must also specify the otherWellKnownGuid attribute definition. Add the following to the ldf file attribute definition: omObjectClass:: KoZIhvcUAQEBCw==</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_dn_with_binary
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0015 { DWORD dwLength; LPBYTE lpBinaryValue; LPWSTR pszDNString; } ADS_DN_WITH_BINARY, *PADS_DN_WITH_BINARY;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0015")]
	[StructLayout(LayoutKind.Sequential), VanaraMarshaler(typeof(ADS_DN_WITH_BINARY_UNMGD))]
	public struct ADS_DN_WITH_BINARY
	{
		/// <summary>Pointer to an array of bytes that contains the binary data for the attribute. The <c>dwLength</c> member contains the number of bytes in this array.</summary>
		public byte[] lpBinaryValue;

		/// <summary>Pointer to a null-terminated Unicode string that contains the distinguished name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszDNString;

		[StructLayout(LayoutKind.Sequential)]
		internal struct ADS_DN_WITH_BINARY_UNMGD : IVanaraMarshaler
		{
			public uint dwLength;
			public IntPtr lpBinaryValue;
			public StrPtrUni pszDNString;

			SizeT IVanaraMarshaler.GetNativeSize() => Marshal.SizeOf(this);

			SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject)
			{
				if (managedObject is not ADS_DN_WITH_BINARY v)
					throw new ArgumentException("A value of ADS_DN_WITH_BINARY is required for this type.", nameof(managedObject));
				SafeCoTaskMemStruct<ADS_DN_WITH_BINARY_UNMGD> pv = new();
				var of1 = pv.Size;
				var of2 = of1 + v.lpBinaryValue?.Length ?? 0;
				var str = v.pszDNString?.GetBytes(true, CharSet.Unicode);
				pv.Size = of2 + str?.Length ?? 0;
				if (v.lpBinaryValue is not null && v.lpBinaryValue!.Length > 0)
					((IntPtr)pv).Write(v.lpBinaryValue!, of1);
				if (str is not null && str!.Length > 0)
					((IntPtr)pv).Write(str!, of2);
				pv.Value = new ADS_DN_WITH_BINARY_UNMGD
				{
					pszDNString = str is null ? IntPtr.Zero : ((IntPtr)pv).Offset(of2),
					dwLength = v.lpBinaryValue is null || v.lpBinaryValue.Length == 0 ? 0 : (uint)v.lpBinaryValue.Length,
					lpBinaryValue = v.lpBinaryValue is null ? IntPtr.Zero : ((IntPtr)pv).Offset(of1)
				};
				return pv;
			}

			object? IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
			{
				if (pNativeData == IntPtr.Zero || allocatedBytes == 0) return null;
				var u = (ADS_DN_WITH_BINARY_UNMGD)Marshal.PtrToStructure(pNativeData, typeof(ADS_DN_WITH_BINARY_UNMGD))!;
				return new ADS_DN_WITH_BINARY() { pszDNString = u.pszDNString.ToString(), lpBinaryValue = u.lpBinaryValue.ToByteArray((int)u.dwLength) ?? [] };
			}
		}
	}

	/// <summary>The <c>ADS_DN_WITH_STRING</c> structure is used with the ADSVALUE structure to contain a distinguished name attribute value that also contains string data.</summary>
	/// <remarks>When extending the active directory schema to add <c>ADS_DN_WITH_STRING</c>, you must also specify the otherWellKnownGuid attribute definition. Add the following to the ldf file attribute definition: omObjectClass:: KoZIhvcUAQEBDA==</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_dn_with_string
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0016 { LPWSTR pszStringValue; LPWSTR pszDNString; } ADS_DN_WITH_STRING, *PADS_DN_WITH_STRING;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0016")]
	[StructLayout(LayoutKind.Sequential), VanaraMarshaler(typeof(ADS_DN_WITH_STRING_UNMGD))]
	public struct ADS_DN_WITH_STRING
	{
		/// <summary>Pointer to a null-terminated Unicode string that contains the string value of the attribute.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszStringValue;

		/// <summary>Pointer to a null-terminated Unicode string that contains the distinguished name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pszDNString;

		[StructLayout(LayoutKind.Sequential)]
		internal struct ADS_DN_WITH_STRING_UNMGD : IVanaraMarshaler
		{
			public StrPtrUni pszStringValue;
			public StrPtrUni pszDNString;

			SizeT IVanaraMarshaler.GetNativeSize() => Marshal.SizeOf(this);

			SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject)
			{
				if (managedObject is not ADS_DN_WITH_STRING v)
					throw new ArgumentException("A value of ADS_DN_WITH_STRING is required for this type.", nameof(managedObject));
				SafeCoTaskMemStruct<ADS_DN_WITH_STRING_UNMGD> pv = new();
				var of1 = pv.Size;
				var str0 = v.pszStringValue?.GetBytes(true, CharSet.Unicode);
				var of2 = of1 + str0?.Length ?? 0;
				var str = v.pszDNString?.GetBytes(true, CharSet.Unicode);
				pv.Size = of2 + str?.Length ?? 0;
				if (str0 is not null && str0!.Length > 0)
					((IntPtr)pv).Write(str0!, of1);
				if (str is not null && str!.Length > 0)
					((IntPtr)pv).Write(str!, of2);
				pv.Value = new ADS_DN_WITH_STRING_UNMGD
				{
					pszDNString = str is null ? IntPtr.Zero : ((IntPtr)pv).Offset(of2),
					pszStringValue = str0 is null ? IntPtr.Zero : ((IntPtr)pv).Offset(of1),
				};
				return pv;
			}

			object? IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
			{
				if (pNativeData == IntPtr.Zero || allocatedBytes == 0) return null;
				var u = (ADS_DN_WITH_STRING_UNMGD)Marshal.PtrToStructure(pNativeData, typeof(ADS_DN_WITH_STRING_UNMGD))!;
				return new ADS_DN_WITH_STRING() { pszStringValue = u.pszStringValue.ToString(), pszDNString = u.pszDNString.ToString() };
			}
		}
	}

	/// <summary>The <c>ADS_EMAIL</c> structure is an ADSI representation of the <c>EMail Address</c> attribute syntax.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_email
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0014 { LPWSTR Address; DWORD Type; } ADS_EMAIL, *PADS_EMAIL;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0014")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_EMAIL
	{
		/// <summary>The null-terminated Unicode string that contains the user address.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? Address;

		/// <summary>Type of the email message.</summary>
		public uint Type;

		/// <summary>Performs an implicit conversion from <see cref="ADS_EMAIL_UNMGD"/> to <see cref="ADS_EMAIL"/>.</summary>
		/// <param name="u">The <see cref="ADS_EMAIL_UNMGD"/> value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ADS_EMAIL(ADS_EMAIL_UNMGD u) => new() { Address = u.Address.ToString(), Type = u.Type };
	}

	/// <summary>The <c>ADS_EMAIL</c> structure is an ADSI representation of the <c>EMail Address</c> attribute syntax.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_email
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0014 { LPWSTR Address; DWORD Type; } ADS_EMAIL, *PADS_EMAIL;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0014")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_EMAIL_UNMGD
	{
		/// <summary>The null-terminated Unicode string that contains the user address.</summary>
		public StrPtrUni Address;

		/// <summary>Type of the email message.</summary>
		public uint Type;
	}

	/// <summary>The <c>ADS_FAXNUMBER</c> structure is an ADSI representation of the <c>Facsimile Telephone Number</c> attribute syntax.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_faxnumber
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0013 { LPWSTR TelephoneNumber; DWORD NumberOfBits; LPBYTE Parameters; } ADS_FAXNUMBER, *PADS_FAXNUMBER;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0013")]
	[StructLayout(LayoutKind.Sequential), VanaraMarshaler(typeof(ADS_FAXNUMBER_UNMGD))]
	public struct ADS_FAXNUMBER
	{
		/// <summary>The null-terminated Unicode string value that contains the telephone number of the facsimile (fax) machine.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? TelephoneNumber;

		/// <summary>Optional parameters for the fax machine.</summary>
		public byte[] Parameters;

		[StructLayout(LayoutKind.Sequential)]
		internal struct ADS_FAXNUMBER_UNMGD : IVanaraMarshaler
		{
			public StrPtrUni TelephoneNumber;
			public uint NumberOfBits;
			public IntPtr Parameters;

			SizeT IVanaraMarshaler.GetNativeSize() => Marshal.SizeOf(this);

			SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject)
			{
				if (managedObject is not ADS_FAXNUMBER v)
					throw new ArgumentException("A value of ADS_FAXNUMBER is required for this type.", nameof(managedObject));
				SafeCoTaskMemStruct<ADS_FAXNUMBER_UNMGD> pv = new();
				var of1 = pv.Size;
				var of2 = of1 + v.Parameters?.Length ?? 0;
				var str = v.TelephoneNumber?.GetBytes(true, CharSet.Unicode);
				pv.Size = of2 + str?.Length ?? 0;
				if (v.Parameters is not null && v.Parameters!.Length > 0)
					((IntPtr)pv).Write(v.Parameters!, of1);
				if (str is not null && str!.Length > 0)
					((IntPtr)pv).Write(str!, of2);
				pv.Value = new ADS_FAXNUMBER_UNMGD
				{
					TelephoneNumber = str is null ? IntPtr.Zero : ((IntPtr)pv).Offset(of2),
					NumberOfBits = v.Parameters is null || v.Parameters.Length == 0 ? 0 : (uint)v.Parameters.Length,
					Parameters = v.Parameters is null ? IntPtr.Zero : ((IntPtr)pv).Offset(of1)
				};
				return pv;
			}

			object? IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
			{
				if (pNativeData == IntPtr.Zero || allocatedBytes == 0)
					return null;
				var u = (ADS_FAXNUMBER_UNMGD)Marshal.PtrToStructure(pNativeData, typeof(ADS_FAXNUMBER_UNMGD))!;
				return new ADS_FAXNUMBER() { TelephoneNumber = u.TelephoneNumber.ToString(), Parameters = u.Parameters.ToByteArray((int)u.NumberOfBits) ?? [] };
			}
		}
	}

	/// <summary>The <c>ADS_HOLD</c> structure is an ADSI representation of the <c>Hold</c> attribute syntax.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_hold
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0010 { LPWSTR ObjectName; DWORD Amount; } ADS_HOLD, *PADS_HOLD;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0010")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_HOLD
	{
		/// <summary>The null-terminated Unicode string that contains the name of an object put on hold.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? ObjectName;

		/// <summary>Number of charges that a server places against the user on hold while it verifies the user account balance.</summary>
		public uint Amount;

		/// <summary>Performs an implicit conversion from <see cref="ADS_HOLD_UNMGD"/> to <see cref="ADS_HOLD"/>.</summary>
		/// <param name="u">The <see cref="ADS_HOLD_UNMGD"/> value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ADS_HOLD(ADS_HOLD_UNMGD u) => new() { ObjectName = u.ObjectName.ToString(), Amount = u.Amount };
	}

	/// <summary>The <c>ADS_HOLD</c> structure is an ADSI representation of the <c>Hold</c> attribute syntax.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_hold
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0010 { LPWSTR ObjectName; DWORD Amount; } ADS_HOLD, *PADS_HOLD;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0010")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_HOLD_UNMGD
	{
		/// <summary>The null-terminated Unicode string that contains the name of an object put on hold.</summary>
		public StrPtrUni ObjectName;

		/// <summary>Number of charges that a server places against the user on hold while it verifies the user account balance.</summary>
		public uint Amount;
	}

	/// <summary>The <c>ADS_NETADDRESS</c> structure is an ADSI representation of the <c>Net Address</c> attribute syntax.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_netaddress
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0011 { DWORD AddressType; DWORD AddressLength; BYTE *Address; } ADS_NETADDRESS, *PADS_NETADDRESS;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0011")]
	[VanaraMarshaler(typeof(ADS_NETADDRESS_UNMGD))]
	public struct ADS_NETADDRESS
	{
		/// <summary>Types of communication protocols.</summary>
		public uint AddressType;

		/// <summary>A network address.</summary>
		public byte[] Address;

		[StructLayout(LayoutKind.Sequential)]
		internal struct ADS_NETADDRESS_UNMGD : IVanaraMarshaler
		{
			public uint AddressType;
			public uint AddressLength;
			public IntPtr Address;

			SizeT IVanaraMarshaler.GetNativeSize() => Marshal.SizeOf(this);

			SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject)
			{
				if (managedObject is not ADS_NETADDRESS na)
					throw new ArgumentException("A value of ADS_NETADDRESS is required for this type.", nameof(managedObject));
				SafeCoTaskMemStruct<ADS_NETADDRESS_UNMGD> pu = new();
				pu.Value = new() { AddressType = na.AddressType, AddressLength = (uint)na.Address.Length, Address = pu.Append(na.Address) };
				return pu;
			}

			object? IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
			{
				if (pNativeData == IntPtr.Zero || allocatedBytes == 0)
					return null;
				var u = (ADS_NETADDRESS_UNMGD)Marshal.PtrToStructure(pNativeData, typeof(ADS_NETADDRESS_UNMGD))!;
				return new ADS_NETADDRESS()
				{
					AddressType = u.AddressType,
					Address = u.Address.ToByteArray((int)u.AddressLength) ?? []
				};
			}
		}
	}

	/// <summary>The <c>ADS_NT_SECURITY_DESCRIPTOR</c> structure defines the data type of the security descriptor for Windows.</summary>
	/// <remarks>The <c>ADS_NT_SECURITY_DESCRIPTOR</c> structure is normally used as a member of the ADSVALUE structure definition.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_nt_security_descriptor
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0003 { DWORD dwLength; LPBYTE lpValue; } ADS_NT_SECURITY_DESCRIPTOR, *PADS_NT_SECURITY_DESCRIPTOR;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0003")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_NT_SECURITY_DESCRIPTOR
	{
		/// <summary>The length data, in bytes.</summary>
		public uint dwLength;

		/// <summary>Pointer to the security descriptor, represented as a byte array.</summary>
		public IntPtr lpValue;

		/// <summary>
		/// Gets or sets the values of this structure using a native security descriptor.
		/// </summary>
		/// <value>
		/// <para>The native security descriptor.</para>
		/// <para>When getting this value, all associated data is copied and returned in the resulting value.</para>
		/// <para>
		/// When setting this value, only the pointer to the data and its length are taken, so the the supplied value's memory must not be
		/// disposed before the <see cref="ADS_NT_SECURITY_DESCRIPTOR"/> value is used.
		/// </para>
		/// </value>
		public AdvApi32.SafePSECURITY_DESCRIPTOR NativeSecurityDescriptor
		{
			readonly get => new AdvApi32.SafePSECURITY_DESCRIPTOR(lpValue, false).MakePackedAbsolute();
			set
			{
				dwLength = value.Length;
				lpValue = value.DangerousGetHandle();
			}
		}
	}

	/// <summary>The <c>ADS_OBJECT_INFO</c> structure specifies the data, including the identity and location, of a directory service object.</summary>
	/// <remarks>To obtain the object data, non-Automation clients call the IDirectoryObject::GetObjectInformation method, which takes an out parameter, a pointer to an <c>ADS_OBJECT_INFO</c> structure allocated in the heap. Automation clients can accomplish the same task by calling IADs::GetInfo.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_object_info
	// typedef struct _ads_object_info { LPWSTR pszRDN; LPWSTR pszObjectDN; LPWSTR pszParentDN; LPWSTR pszSchemaDN; LPWSTR pszClassName; } ADS_OBJECT_INFO, *PADS_OBJECT_INFO;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._ads_object_info")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_OBJECT_INFO
	{
		/// <summary>The null-terminated Unicode string that contains the relative distinguished name of the directory service object.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszRDN;

		/// <summary>The null-terminated Unicode string that contains the distinguished name of the directory service object.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszObjectDN;

		/// <summary>The null-terminated Unicode string that contains the distinguished name of the parent object.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszParentDN;

		/// <summary>The null-terminated Unicode string that contains the distinguished name of the schema class of the object.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszSchemaDN;

		/// <summary>The null-terminated Unicode string that contains the name of the class of which this object is an instance.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszClassName;
	}

	/// <summary>The <c>ADS_OCTET_LIST</c> structure is an ADSI representation of an ordered sequence of single-byte strings.</summary>
	/// <remarks>For more information, see Novell NetWare Directory Services Schema Specification, version 1.1.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_octet_list
	// typedef struct _ADS_OCTET_LIST { struct _ADS_OCTET_LIST *Next; DWORD Length; BYTE *Data; } ADS_OCTET_LIST, *PADS_OCTET_LIST;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._ADS_OCTET_LIST")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_OCTET_LIST
	{
		/// <summary>Pointer to the next <c>ADS_OCTET_LIST</c> entry in the list.</summary>
		public IntPtr Next;

		/// <summary>Contains the length, in bytes, of the list.</summary>
		public uint Length;

		/// <summary>Pointer to an array of BYTEs that contains the list. The <c>Length</c> member of this structure contains the number of BYTEs in this array.</summary>
		public IntPtr Data;
	}

	/// <summary>The <c>ADS_OCTET_STRING</c> structure is an ADSI representation of the <c>Octet String</c> attribute syntax used in Active Directory.</summary>
	/// <remarks>Memory for the byte array must be allocated separately.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_octet_string
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0002 { DWORD dwLength; LPBYTE lpValue; } ADS_OCTET_STRING, *PADS_OCTET_STRING;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0002")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_OCTET_STRING
	{
		/// <summary>The size, in bytes, of the character array.</summary>
		public uint dwLength;

		/// <summary>Pointer to an array of single byte characters not interpreted by the underlying directory.</summary>
		public IntPtr lpValue;
	}

	/// <summary>The <c>ADS_PATH</c> structure is an ADSI representation of the <c>Path</c> attribute syntax.</summary>
	/// <remarks>The <c>Path</c> attribute in represents a file system path.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_path
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0005 { DWORD Type; LPWSTR VolumeName; LPWSTR Path; } ADS_PATH, *PADS_PATH;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0005")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_PATH
	{
		/// <summary>Type of file in the file system.</summary>
		public ADS_PATHTYPE Type;

		/// <summary>The null-terminated Unicode string that contains the name of an existing volume in the file system.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string VolumeName;

		/// <summary>The null-terminated Unicode string that contains the path of a directory in the file system.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Path;
	}

	/// <summary>The <c>ADS_POSTALADDRESS</c> structure is an ADSI representation of the <c>Postal Address</c> attribute.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_postaladdress
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0006 { LPWSTR PostalAddress[6]; } ADS_POSTALADDRESS, *PADS_POSTALADDRESS;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0006")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ADS_POSTALADDRESS
	{
		/// <summary>An array of six null-terminated Unicode strings that represent the postal address.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
		public string PostalAddress;
	}

	/// <summary>The <c>ADS_PROV_SPECIFIC</c> structure contains provider-specific data represented as a binary large object (BLOB).</summary>
	/// <remarks>
	/// <para>The <c>ADS_PROV_SPECIFIC</c> structure is one of the data types used as a member of the ADSVALUE structure definition. The data is represented as a BLOB here, although the actual data can be packed in any format, such as a C structure. The provider writer must publish the specific data format under the BLOB.</para>
	/// <para>ADSI may also return attributes as <c>ADS_PROV_SPECIFIC</c> if unable to determine the correct attribute syntax type as would occur if, for example, the schema was unavailable.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_prov_specific
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0004 { DWORD dwLength; LPBYTE lpValue; } ADS_PROV_SPECIFIC, *PADS_PROV_SPECIFIC;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0004")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_PROV_SPECIFIC
	{
		/// <summary>The size of the character array.</summary>
		public uint dwLength;

		/// <summary>A pointer to an array of bytes.</summary>
		public IntPtr lpValue;
	}

	/// <summary>The <c>ADS_REPLICAPOINTER</c> structure represents an ADSI representation of the Replica Pointer attribute syntax.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_replicapointer typedef struct
	// __MIDL___MIDL_itf_ads_0000_0000_0012 { LPWSTR ServerName; DWORD ReplicaType; DWORD ReplicaNumber; DWORD Count; PADS_NETADDRESS
	// ReplicaAddressHints; } ADS_REPLICAPOINTER, *PADS_REPLICAPOINTER;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0012")]
	[VanaraMarshaler(typeof(ADS_REPLICAPOINTER_UNMGD))]
	public struct ADS_REPLICAPOINTER
	{
		/// <summary>The null-terminated Unicode string that contains the name of the name server that holds the replica.</summary>
		public string ServerName;

		/// <summary>Type of replica: master, secondary, or read-only.</summary>
		public uint ReplicaType;

		/// <summary>Replica identification number.</summary>
		public uint ReplicaNumber;

		/// <summary>The number of existing replicas.</summary>
		public uint Count;

		/// <summary>A network address that is a likely reference to a node leading to the name server.</summary>
		public ADS_NETADDRESS? ReplicaAddressHints;

		[StructLayout(LayoutKind.Sequential)]
		internal struct ADS_REPLICAPOINTER_UNMGD : IVanaraMarshaler
		{
			/// <summary>The null-terminated Unicode string that contains the name of the name server that holds the replica.</summary>
			public StrPtrUni ServerName;

			/// <summary>Type of replica: master, secondary, or read-only.</summary>
			public uint ReplicaType;

			/// <summary>Replica identification number.</summary>
			public uint ReplicaNumber;

			/// <summary>The number of existing replicas.</summary>
			public uint Count;

			/// <summary>A network address that is a likely reference to a node leading to the name server.</summary>
			public IntPtr ReplicaAddressHints;

			SizeT IVanaraMarshaler.GetNativeSize() => Marshal.SizeOf(this);

			SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject)
			{
				if (managedObject is not ADS_REPLICAPOINTER i)
					throw new ArgumentException("Invalid object", nameof(managedObject));
				ADS_REPLICAPOINTER_UNMGD ii = new() { ReplicaType = i.ReplicaType, ReplicaNumber = i.ReplicaNumber, Count = i.Count };
				SizeT ext = (i.ServerName?.GetByteCount(true, CharSet.Unicode) ?? 0) + Marshal.SizeOf(typeof(ADS_NETADDRESS.ADS_NETADDRESS_UNMGD)) + (i.ReplicaAddressHints?.Address?.Length ?? 0);
				var sz = Marshal.SizeOf(typeof(ADS_REPLICAPOINTER_UNMGD));
				var ret = new SafeCoTaskMemStruct<ADS_REPLICAPOINTER_UNMGD>(ext + sz);
				ii.ServerName = ret.DangerousGetHandle().Offset(sz);
				StringHelper.Write(i.ServerName, (IntPtr)ii.ServerName, out var l, true, CharSet.Unicode);
				ii.ReplicaAddressHints = i.ReplicaAddressHints.MarshalToPtr(i => ret.DangerousGetHandle().Offset(sz + l), out _);
				return ret;
			}

			object? IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
			{
				if (pNativeData == IntPtr.Zero || allocatedBytes == 0)
					return null;
				var u = (ADS_REPLICAPOINTER_UNMGD)Marshal.PtrToStructure(pNativeData, typeof(ADS_REPLICAPOINTER_UNMGD))!;
				return new ADS_REPLICAPOINTER()
				{
					ServerName = u.ServerName.ToString(),
					ReplicaType = u.ReplicaType,
					ReplicaNumber = u.ReplicaNumber,
					Count = u.Count,
					ReplicaAddressHints = u.ReplicaAddressHints.ToNullableStructure<ADS_NETADDRESS>()
				};
			}
		}
	}

	/// <summary>The <c>ADS_SEARCH_COLUMN</c> structure specifies the contents of a search column in the query returned from the directory service database.</summary>
	/// <remarks>
	/// <para>The <c>ADS_SEARCH_COLUMN</c> structure only contains a pointer to the array of ADSVALUE structures. Memory for the structure must be allocated separately.</para>
	/// <para>For more information about <c>ADS_SEARCH_COLUMN</c>, see IDirectorySearch::GetColumn.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_search_column
	// typedef struct ads_search_column { LPWSTR pszAttrName; ADSTYPE dwADsType; PADSVALUE pADsValues; DWORD dwNumValues; HANDLE hReserved; } ADS_SEARCH_COLUMN, *PADS_SEARCH_COLUMN;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.ads_search_column")]
	[VanaraMarshaler(typeof(ADS_SEARCH_COLUMN_UNMGD))]
	public struct ADS_SEARCH_COLUMN
	{
		/// <summary>A null-terminated Unicode string that contains the name of the attribute whose values are contained in the current search column.</summary>
		public string pszAttrName;

		/// <summary>Value from the ADSTYPEENUM enumeration that indicates how the attribute values are interpreted.</summary>
		public ADSTYPE dwADsType;

		/// <summary>Array of ADSVALUE structures that contain values of the attribute in the current search column for the current row.</summary>
		public ADSVALUE[] pADsValues;

		/// <summary>Reserved for internal use by providers.</summary>
		public HANDLE hReserved;

		[StructLayout(LayoutKind.Sequential)]
		internal struct ADS_SEARCH_COLUMN_UNMGD : IVanaraMarshaler
		{
			/// <summary>A null-terminated Unicode string that contains the name of the attribute whose values are contained in the current search column.</summary>
			public StrPtrUni pszAttrName;

			/// <summary>Value from the ADSTYPEENUM enumeration that indicates how the attribute values are interpreted.</summary>
			public ADSTYPE dwADsType;

			/// <summary>Array of ADSVALUE structures that contain values of the attribute in the current search column for the current row.</summary>
			public IntPtr pADsValues;

			/// <summary>Size of the <c>pADsValues</c> array.</summary>
			public uint dwNumValues;

			/// <summary>Reserved for internal use by providers.</summary>
			public HANDLE hReserved;

			SizeT IVanaraMarshaler.GetNativeSize() => Marshal.SizeOf(this);

			SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject)
			{
				if (managedObject is not ADS_SEARCH_COLUMN i)
					throw new ArgumentException("Invalid object", nameof(managedObject));
				ADS_SEARCH_COLUMN_UNMGD ii = new() { dwADsType = i.dwADsType, hReserved = i.hReserved, dwNumValues = (uint?)i.pADsValues?.Length ?? 0 };
				SizeT ext = ii.dwNumValues * Marshal.SizeOf(typeof(ADSVALUE)) + (i.pszAttrName?.GetByteCount(true, CharSet.Unicode) ?? 0);
				var sz = Marshal.SizeOf(typeof(ADS_SEARCH_COLUMN_UNMGD));
				var ret = new SafeCoTaskMemStruct<ADS_SEARCH_COLUMN_UNMGD>(ext + sz);
				ii.pszAttrName = ret.DangerousGetHandle().Offset(sz);
				StringHelper.Write(i.pszAttrName, (IntPtr)ii.pszAttrName, out var l, true, CharSet.Unicode);
				ii.pADsValues = ret.DangerousGetHandle().Offset(sz + l);
				ii.pADsValues.Write(i.pADsValues ?? [], sz + l);
				return ret;
			}

			object? IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
			{
				if (pNativeData == IntPtr.Zero || allocatedBytes == 0)
					return null;
				var ii = (ADS_SEARCH_COLUMN_UNMGD)Marshal.PtrToStructure(pNativeData, typeof(ADS_SEARCH_COLUMN_UNMGD))!;
				return new ADS_SEARCH_COLUMN()
				{
					pszAttrName = ii.pszAttrName.ToString(),
					dwADsType = ii.dwADsType,
					pADsValues = ii.pADsValues.ToArray<ADSVALUE>(ii.dwNumValues) ?? [],
					hReserved = ii.hReserved,
				};
			}
		}
	}

	/// <summary>The <c>ADS_SEARCHPREF_INFO</c> structure specifies the query preferences.</summary>
	/// <remarks>
	/// <para>To setup a search preference, assign appropriate values to the fields of an <c>ADS_SEARCHPREF_INFO</c> structure passed to the server. The <c>vValue</c> member of the <c>ADS_SEARCHPREF_INFO</c> structure is an ADSVALUE structure. The following table lists the ADS_SEARCHPREF_ENUM values, the corresponding values for the <c>dwType</c> member of the <c>ADSVALUE</c> structure, and the <c>ADSVALUE</c> member that is used for the specified type.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>ADS_SEARCHPREF_ENUM Value</description>
	/// <description><c>dwType</c> member of ADSVALUE</description>
	/// <description>ADSVALUE member</description>
	/// </listheader>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_ASYNCHRONOUS</c></description>
	/// <description><c>ADSTYPE_BOOLEAN</c></description>
	/// <description><c>Boolean</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_DEREF_ALIASES</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_SIZE_LIMIT</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_TIME_LIMIT</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_ATTRIBTYPES_ONLY</c></description>
	/// <description><c>ADSTYPE_BOOLEAN</c></description>
	/// <description><c>Boolean</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_SEARCH_SCOPE</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_TIMEOUT</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_PAGESIZE</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_PAGED_TIME_LIMIT</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_CHASE_REFERRALS</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_SORT_ON</c></description>
	/// <description><c>ADSTYPE_PROV_SPECIFIC</c></description>
	/// <description><c>ProviderSpecific</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_CACHE_RESULTS</c></description>
	/// <description><c>ADSTYPE_BOOLEAN</c></description>
	/// <description><c>Boolean</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_DIRSYNC</c></description>
	/// <description><c>ADSTYPE_PROV_SPECIFIC</c></description>
	/// <description><c>ProviderSpecific</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_TOMBSTONE</c></description>
	/// <description><c>ADSTYPE_BOOLEAN</c></description>
	/// <description><c>Boolean</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_VLV</c></description>
	/// <description><c>ADSTYPE_PROV_SPECIFIC</c></description>
	/// <description><c>ProviderSpecific</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_ATTRIBUTE_QUERY</c></description>
	/// <description><c>ADSTYPE_CASE_IGNORE_STRING</c></description>
	/// <description><c>CaseIgnoreString</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_SECURITY_MASK</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_DIRSYNC_FLAG</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADS_SEARCHPREF_EXTENDED_DN</c></description>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>Integer</c></description>
	/// </item>
	/// </list>
	/// <para> </para>
	/// <para>For more information and examples of how to use the <c>ADS_SEARCHPREF_INFO</c> structure, see the discussions of the IDirectorySearch::SetSearchPreference method and the ADS_SEARCHPREF_ENUM enumeration.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_searchpref_info
	// typedef struct ads_searchpref_info { ADS_SEARCHPREF dwSearchPref; ADSVALUE vValue; ADS_STATUS dwStatus; } ADS_SEARCHPREF_INFO, *PADS_SEARCHPREF_INFO, *LPADS_SEARCHPREF_INFO;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.ads_searchpref_info")]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct ADS_SEARCHPREF_INFO
	{
		/// <summary>Contains one of the ADS_SEARCHPREF_ENUM enumeration values that specifies the search option to set.</summary>
		public ADS_SEARCHPREF dwSearchPref;

		private int pad1;

		/// <summary>Contains a ADSVALUE structure that specifies the data type and value of the search preference.</summary>
		public ADSVALUE vValue;

		/// <summary>Receives one of the ADS_STATUSENUM enumeration values that indicates the status of the search preference. The IDirectorySearch::SetSearchPreference method will fill in this member when it is called.</summary>
		public ADS_STATUS dwStatus;

		private int pad2;

		/// <summary>Initializes a new instance of the <see cref="ADS_SEARCHPREF_INFO"/> struct.</summary>
		/// <param name="pref">The search option to set.</param>
		/// <param name="value">The search preference value.</param>
		public ADS_SEARCHPREF_INFO(ADS_SEARCHPREF pref, object? value) : this()
		{
			dwSearchPref = pref;
			ADSTYPE t = Type.GetTypeCode(value?.GetType()) switch
			{
				TypeCode.Boolean => ADSTYPE.ADSTYPE_BOOLEAN,
				TypeCode.Int32 => ADSTYPE.ADSTYPE_INTEGER,
				TypeCode.String => ADSTYPE.ADSTYPE_CASE_IGNORE_STRING,
				TypeCode.Object when value!.GetType().IsEnum => ADSTYPE.ADSTYPE_INTEGER,
				//TypeCode.Object when value is byte[] b => ADSTYPE.ADSTYPE_PROV_SPECIFIC,
				_ => throw new ArgumentException("Invalid value", nameof(value)),
			};
			vValue.SetValue(t, value, out _);
		}
	}

	/// <summary>The <c>ADS_SORTKEY</c> structure specifies how to sort a query.</summary>
	/// <remarks>
	/// <para>In Active Directory, if <c>TRUE</c>, the <c>fReverseorder</c> member specifies that the sort results be ordered from the lowest to the highest.</para>
	/// <para>When using the LDAP system provider, the <c>pszReserved</c> member corresponds to the <c>sk_matchruleoid</c> of the LDAPSortKey structure and may be set to a NULL-terminated string that specifies the object identifier (OID) of the matching rule for the sort. For more information, see <c>LDAPSortKey</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_sortkey
	// typedef struct _ads_sortkey { LPWSTR pszAttrType; LPWSTR pszReserved; BOOLEAN fReverseorder; } ADS_SORTKEY, *PADS_SORTKEY;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._ads_sortkey")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_SORTKEY
	{
		/// <summary>The null-terminated Unicode string that contains the attribute type.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszAttrType;

		/// <summary>Reserved.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszReserved;

		/// <summary>Reverse the order of the sorted results.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool fReverseorder;
	}

	/// <summary>The <c>ADS_TIMESTAMP</c> structure is an ADSI representation of the <c>Timestamp</c> attribute syntax.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_timestamp
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0007 { DWORD WholeSeconds; DWORD EventID; } ADS_TIMESTAMP, *PADS_TIMESTAMP;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0007")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_TIMESTAMP
	{
		/// <summary>Number of seconds, with zero value being equal to 12:00 AM, January, 1970, UTC.</summary>
		public uint WholeSeconds;

		/// <summary>An event identifier, in the order of occurrence, within the period specified by <c>WholeSeconds</c>.</summary>
		public uint EventID;

		/// <summary>
		/// Gets or sets the UTC time of this timestamp by converting the value to the number of seconds and placing result in <see cref="WholeSeconds"/>.
		/// </summary>
		/// <value>The UTC time.</value>
		public DateTime UTCTime
		{
			get => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc) + TimeSpan.FromSeconds(WholeSeconds);
			set => WholeSeconds = (uint)((value - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
		}
	}

	/// <summary>The <c>ADS_TYPEDNAME</c> structure represents an ADSI representation of <c>Typed Name</c> attribute syntax.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_typedname
	// typedef struct __MIDL___MIDL_itf_ads_0000_0000_0009 { LPWSTR ObjectName; DWORD Level; DWORD Interval; } ADS_TYPEDNAME, *PADS_TYPEDNAME;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads.__MIDL___MIDL_itf_ads_0000_0000_0009")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_TYPEDNAME
	{
		/// <summary>The null-terminated Unicode string that contains an object name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ObjectName;

		/// <summary>The priority associated with the object.</summary>
		public uint Level;

		/// <summary>The frequency of reference of the object.</summary>
		public uint Interval;
	}

	/// <summary>
	/// <para>The <c>ADSVALUE</c> structure contains a value specified as an ADSI data type. These data types can be ADSI Simple Data Types or ADSI-defined custom data types that include C-style structures.</para>
	/// <para>The ADS_ATTR_INFO structure contains an array of <c>ADSVALUE</c> structures. Each <c>ADSVALUE</c> structure contains a single attribute value.</para>
	/// </summary>
	/// <remarks>Members of the <c>ADSVALUE</c> structure specify the data type of attributes. For more information and a code example, see ADS_ATTR_INFO.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-adsvalue
	// typedef struct _adsvalue { ADSTYPE dwType; union { ADS_DN_STRING DNString; ADS_CASE_EXACT_STRING CaseExactString; ADS_CASE_IGNORE_STRING CaseIgnoreString; ADS_PRINTABLE_STRING PrintableString; ADS_NUMERIC_STRING NumericString; ADS_BOOLEAN Boolean; ADS_INTEGER Integer; ADS_OCTET_STRING OctetString; ADS_UTC_TIME UTCTime; ADS_LARGE_INTEGER LargeInteger; ADS_OBJECT_CLASS ClassName; ADS_PROV_SPECIFIC ProviderSpecific; PADS_CASEIGNORE_LIST pCaseIgnoreList; PADS_OCTET_LIST pOctetList; PADS_PATH pPath; PADS_POSTALADDRESS pPostalAddress; ADS_TIMESTAMP Timestamp; ADS_BACKLINK BackLink; PADS_TYPEDNAME pTypedName; ADS_HOLD Hold; PADS_NETADDRESS pNetAddress; PADS_REPLICAPOINTER pReplicaPointer; PADS_FAXNUMBER pFaxNumber; ADS_EMAIL Email; ADS_NT_SECURITY_DESCRIPTOR SecurityDescriptor; PADS_DN_WITH_BINARY pDNWithBinary; PADS_DN_WITH_STRING pDNWithString; }; } ADSVALUE, *PADSVALUE, *LPADSVALUE;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._adsvalue")]
	[StructLayout(LayoutKind.Sequential), DebuggerDisplay("Type = {dwType}, Value = {Value}")]
	public struct ADSVALUE
	{
		/// <summary>Data type used to interpret the union member of the structure. Values of this member are taken from the ADSTYPEENUM enumeration.</summary>
		public ADSTYPE dwType;

		private UNION union;

		/// <summary>The null-terminated Unicode string that identifies the distinguished name (path) of a directory service object, as defined by <c>ADS_DN_STRING</c>, an ADSI simple data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public StrPtrUni DNString { readonly get => union.String; set => union.String = value; }

		/// <summary>The null-terminated Unicode string to be interpreted case-sensitively, as defined by <c>ADS_CASE_EXACT_STRING</c>, an ADSI simple data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public StrPtrUni CaseExactString { readonly get => union.String; set => union.String = value; }

		/// <summary>The null-terminated Unicode string to be interpreted without regard to case, as defined by <c>ADS_CASE_IGNORE_STRING</c>, an ADSI simple data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public StrPtrUni CaseIgnoreString { readonly get => union.String; set => union.String = value; }

		/// <summary>The null-terminated Unicode string that can be displayed or printed, as defined by <c>ADS_PRINTABLE_STRING</c>, an ADSI simple data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public StrPtrUni PrintableString { readonly get => union.String; set => union.String = value; }

		/// <summary>The null-terminated Unicode string that contains numerals to be interpreted as text, as defined by <c>ADS_NUMERIC_STRING</c>, an ADSI simple data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public StrPtrUni NumericString { readonly get => union.String; set => union.String = value; }

		/// <summary>Boolean value, as defined by <c>ADS_BOOLEAN</c>, an ADSI simple data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Boolean { readonly get => union.Boolean; set => union.Boolean = value; }

		/// <summary>Integer value, as defined by <c>ADS_INTEGER</c>, an ADSI simple data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int Integer { readonly get => union.Integer; set => union.Integer = value; }

		/// <summary>An octet string, as defined by ADS_OCTET_STRING, an ADSI-defined data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ADS_OCTET_STRING OctetString { readonly get => union.OctetString; set => union.OctetString = value; }

		/// <summary>Time specified as Coordinated Universal Time (UTC), as defined by <c>ADS_UTC_TIME</c>, an ADSI simple data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SYSTEMTIME UTCTime { readonly get => union.UTCTime; set => union.UTCTime = value; }

		/// <summary>Long integer value, as defined by <c>ADS_LARGE_INTEGER</c>, an ADSI simple data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public long LargeInteger { readonly get => union.LargeInteger; set => union.LargeInteger = value; }

		/// <summary>Class name string, as defined by <c>ADS_OBJECT_CLASS</c>, an ADSI simple data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public StrPtrUni ClassName { readonly get => union.String; set => union.String = value; }

		/// <summary>Provider-specific structure, as defined by ADS_PROV_SPECIFIC, an ADSI-defined data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ADS_PROV_SPECIFIC ProviderSpecific { readonly get => union.ProviderSpecific; set => union.ProviderSpecific = value; }

		/// <summary>Pointer to a list of ADS_OCTET_LIST, an ADSI-defined data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IntPtr pOctetList { readonly get => union.Ptr; set => union.Ptr = value; }

		/// <summary>Time stamp of the ADS_TIMESTAMP type, an ADSI-defined data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ADS_TIMESTAMP Timestamp { readonly get => union.Timestamp; set => union.Timestamp = value; }

		/// <summary>A link of the ADS_BACKLINK type, an ADSI-defined data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ADS_PROV_SPECIFIC BackLink { readonly get => union.BackLink; set => union.BackLink = value; }

		/// <summary>A data structure of the ADS_HOLD type, an ADSI-defined data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ADS_HOLD_UNMGD Hold { readonly get => union.Hold; set => union.Hold = value; }

		/// <summary>Pointer to the ADS_NETADDRESS data, an ADSI-defined data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IntPtr pNetAddress { readonly get => union.Ptr; set => union.Ptr = value; }

		/// <summary>Email address of a user of ADS_EMAIL, an ADSI-defined data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ADS_EMAIL_UNMGD Email { readonly get => union.Email; set => union.Email = value; }

		/// <summary>Windows security descriptor, as defined by ADS_NT_SECURITY_DESCRIPTOR, an ADSI-defined data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AdvApi32.SafePSECURITY_DESCRIPTOR SecurityDescriptor { readonly get => dwType == ADSTYPE.ADSTYPE_NT_SECURITY_DESCRIPTOR ? union.SecurityDescriptor.NativeSecurityDescriptor : AdvApi32.SafePSECURITY_DESCRIPTOR.Null; set => union.SecurityDescriptor.NativeSecurityDescriptor = value; }

		/// <summary>Pointer to a ADS_CASEIGNORE_LIST, an ADSI-defined data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IntPtr pCaseIgnoreList { readonly get => union.Ptr; set => union.Ptr = value; }

		/// <summary>Pointer to the ADS_PATH name, an ADSI-defined data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IntPtr pPath { readonly get => union.Ptr; set => union.Ptr = value; }

		/// <summary>Pointer to the ADS_POSTALADDRESS data, an ADSI-defined data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IntPtr pPostalAddress { readonly get => union.Ptr; set => union.Ptr = value; }

		/// <summary>Pointer to the ADS_TYPEDNAME name, an ADSI-defined data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IntPtr pTypedName { readonly get => union.Ptr; set => union.Ptr = value; }

		/// <summary>Pointer to a replica pointer of ADS_REPLICAPOINTER, an ADSI-defined data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IntPtr pReplicaPointer { readonly get => union.Ptr; set => union.Ptr = value; }

		/// <summary>Pointer to a facsimile number of ADS_FAXNUMBER, an ADSI-defined data type.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IntPtr pFaxNumber { readonly get => union.Ptr; set => union.Ptr = value; }

		/// <summary>Pointer to an <see cref="ADS_DN_WITH_BINARY"/> structure that maps a distinguished name of an object to its GUID value.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IntPtr pDNWithBinary { readonly get => union.Ptr; set => union.Ptr = value; }

		/// <summary>Pointer to an <see cref="ADS_DN_WITH_STRING"/> structure that maps a distinguished name of an object to a nonvarying string value.</summary>
		[IgnoreDataMember, DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IntPtr pDNWithString { readonly get => union.Ptr; set => union.Ptr = value; }

		[StructLayout(LayoutKind.Explicit)]
		private struct UNION
		{
			[FieldOffset(0)]
			public StrPtrUni String;

			[FieldOffset(0)]
			public BOOL Boolean;

			[FieldOffset(0)]
			public int Integer;

			[FieldOffset(0)]
			public ADS_OCTET_STRING OctetString;

			[FieldOffset(0)]
			public SYSTEMTIME UTCTime;

			[FieldOffset(0)]
			public long LargeInteger;

			[FieldOffset(0)]
			public ADS_PROV_SPECIFIC ProviderSpecific;

			[FieldOffset(0)]
			public IntPtr Ptr;

			[FieldOffset(0)]
			public ADS_TIMESTAMP Timestamp;

			[FieldOffset(0)]
			public ADS_PROV_SPECIFIC BackLink;

			[FieldOffset(0)]
			public ADS_HOLD_UNMGD Hold;

			[FieldOffset(0)]
			public ADS_EMAIL_UNMGD Email;

			[FieldOffset(0)]
			public ADS_NT_SECURITY_DESCRIPTOR SecurityDescriptor;
		}

		/// <summary>Gets the value as a tuple with the type and converted data value.</summary>
		public object? Value => dwType switch
		{
			ADSTYPE.ADSTYPE_DN_STRING or
			ADSTYPE.ADSTYPE_CASE_EXACT_STRING or
			ADSTYPE.ADSTYPE_CASE_IGNORE_STRING or
			ADSTYPE.ADSTYPE_PRINTABLE_STRING or
			ADSTYPE.ADSTYPE_NUMERIC_STRING or
			ADSTYPE.ADSTYPE_OBJECT_CLASS => DNString.ToString(),
			ADSTYPE.ADSTYPE_BOOLEAN => Boolean,
			ADSTYPE.ADSTYPE_INTEGER => Integer,
			ADSTYPE.ADSTYPE_OCTET_STRING => OctetString.lpValue.ToByteArray((int)OctetString.dwLength),
			ADSTYPE.ADSTYPE_UTC_TIME => UTCTime.ToDateTime(DateTimeKind.Utc),
			ADSTYPE.ADSTYPE_LARGE_INTEGER => LargeInteger,
			ADSTYPE.ADSTYPE_PROV_SPECIFIC => ProviderSpecific.lpValue.ToByteArray((int)ProviderSpecific.dwLength),
			ADSTYPE.ADSTYPE_CASEIGNORE_LIST => pCaseIgnoreList.LinkedListToIEnum<ADS_CASEIGNORE_LIST>(l => l.Next).Select(i => i.String).ToArray(),
			ADSTYPE.ADSTYPE_OCTET_LIST => pOctetList.LinkedListToIEnum<ADS_OCTET_LIST>(l => l.Next).Select(i => i.Data.ToByteArray((int)i.Length)).ToArray(),
			ADSTYPE.ADSTYPE_PATH => pPath.ToNullableStructure<ADS_PATH>(),
			ADSTYPE.ADSTYPE_POSTALADDRESS => pPostalAddress.ToNullableStructure<ADS_POSTALADDRESS>()?.PostalAddress,
			ADSTYPE.ADSTYPE_TIMESTAMP => Timestamp,
			ADSTYPE.ADSTYPE_BACKLINK => new ADS_BACKLINK() { RemoteID = BackLink.dwLength, ObjectName = StringHelper.GetString(BackLink.lpValue, CharSet.Unicode) },
			ADSTYPE.ADSTYPE_TYPEDNAME => pTypedName.ToNullableStructure<ADS_TYPEDNAME>(),
			ADSTYPE.ADSTYPE_HOLD => (ADS_HOLD)Hold,
			ADSTYPE.ADSTYPE_NETADDRESS => pNetAddress.ToNullableStructure<ADS_NETADDRESS>(),
			ADSTYPE.ADSTYPE_REPLICAPOINTER => pReplicaPointer.ToNullableStructure<ADS_REPLICAPOINTER>(),
			ADSTYPE.ADSTYPE_FAXNUMBER => pFaxNumber.ToNullableStructure<ADS_FAXNUMBER>(),
			ADSTYPE.ADSTYPE_EMAIL => (ADS_EMAIL)Email,
			ADSTYPE.ADSTYPE_NT_SECURITY_DESCRIPTOR => SecurityDescriptor,
			ADSTYPE.ADSTYPE_DN_WITH_BINARY => pDNWithBinary.ToNullableStructure<ADS_DN_WITH_BINARY>(),
			ADSTYPE.ADSTYPE_DN_WITH_STRING => pDNWithString.ToNullableStructure<ADS_DN_WITH_STRING>(),
			_ => null,
		};

		/// <summary>Sets the value type and value and gets any allocated memory.</summary>
		/// <param name="type">The type.</param>
		/// <param name="value">The value.</param>
		/// <param name="mem">The memory allocated during the set.</param>
		public void SetValue(ADSTYPE type, object? value, out SafeAllocatedMemoryHandle mem)
		{
			mem = SafeCoTaskMemHandle.Null;
			dwType = type;
			if (value is null) return;
			switch (type)
			{
				case ADSTYPE.ADSTYPE_DN_STRING:
				case ADSTYPE.ADSTYPE_CASE_EXACT_STRING:
				case ADSTYPE.ADSTYPE_CASE_IGNORE_STRING:
				case ADSTYPE.ADSTYPE_PRINTABLE_STRING:
				case ADSTYPE.ADSTYPE_NUMERIC_STRING:
				case ADSTYPE.ADSTYPE_OBJECT_CLASS:
					if (value is not string s)
						throw new ArgumentException("A string is required for this type.", nameof(value));
					DNString = (mem = new SafeLPWSTR(s)).DangerousGetHandle();
					break;

				case ADSTYPE.ADSTYPE_BOOLEAN:
					Boolean = value is bool b ? b : throw new ArgumentException("A bool is required for this type.", nameof(value));
					break;

				case ADSTYPE.ADSTYPE_INTEGER:
					if (value.GetType().IsEnum)
						Integer = Convert.ToInt32(value);
					else
						Integer = value is int i ? i : throw new ArgumentException("An integer is required for this type.", nameof(value));
					break;

				case ADSTYPE.ADSTYPE_OCTET_STRING:
					OctetString = PutBytes<ADS_OCTET_STRING>(value, m => new() { lpValue = m }, out mem);
					break;

				case ADSTYPE.ADSTYPE_UTC_TIME:
					if (value is SYSTEMTIME st)
						UTCTime = st;
					else if (value is DateTime dt)
						UTCTime = new(dt);
					else
						throw new ArgumentException("A DateTime or SYSTEMTIME value is required for this type.", nameof(value));
					break;

				case ADSTYPE.ADSTYPE_LARGE_INTEGER:
					LargeInteger = value is long l ? l : throw new ArgumentException("A 64-bit integer is required for this type.", nameof(value));
					break;

				case ADSTYPE.ADSTYPE_PROV_SPECIFIC:
					ProviderSpecific = PutBytes<ADS_PROV_SPECIFIC>(value, m => new() { lpValue = m }, out mem);
					break;

				case ADSTYPE.ADSTYPE_CASEIGNORE_LIST:
					{
						if (value is not IEnumerable<string> cil)
							throw new ArgumentException("A list of strings is required for this type.", nameof(value));
						var cila = cil.ToArray();
						var ssz = cil.Sum(s => StringHelper.GetByteCount(s, true, CharSet.Unicode));
						SafeCoTaskMemHandle pcila = new(cila.Length * IntPtr.Size * 2 + ssz);
						IntPtr iptr = pcila.DangerousGetHandle(), sptr = pcila.DangerousGetHandle().Offset(cila.Length * IntPtr.Size * 2);
						for (int idx = 0; idx < cila.Length; idx++)
						{
							iptr = iptr.Offset(iptr.Write(iptr.Offset(IntPtr.Size * 2)));
							iptr = iptr.Offset(iptr.Write(sptr));
							StringHelper.Write(cila[idx], sptr, out var sc, true, CharSet.Unicode);
							sptr = sptr.Offset(sc);
						}
						pCaseIgnoreList = mem = pcila;
					}
					break;

				case ADSTYPE.ADSTYPE_OCTET_LIST:
					{
						if (value is not IEnumerable<byte[]> ol)
							throw new ArgumentException("A sequence of byte arrays is required for this type.", nameof(value));
						var ola = ol.ToArray();
						var ssz = Marshal.SizeOf(typeof(ADS_OCTET_LIST));
						var pola = new SafeCoTaskMemHandle(ssz * ola.Length);
						var eos = pola.Size;
						pola.Size += ol.Sum(b => b.Length);
						IntPtr iptr = pola.DangerousGetHandle(), xptr = pola.DangerousGetHandle().Offset(eos);
						for (int idx = 0; idx < ola.Length; idx++)
						{
							ADS_OCTET_LIST oli = new() { Data = xptr, Length = (uint)ola[idx].Length, Next = iptr.Offset(ssz) };
							iptr.Write(oli);
							iptr = oli.Next;
							xptr = xptr.Offset(xptr.Write(ola[idx]));
						}
						pOctetList = mem = pola;
					}
					break;

				case ADSTYPE.ADSTYPE_PATH:
					pPath = mem = PutStructPtr<ADS_PATH>(value);
					break;

				case ADSTYPE.ADSTYPE_POSTALADDRESS:
					pPostalAddress = mem = PutStructPtr<ADS_POSTALADDRESS>(value);
					break;

				case ADSTYPE.ADSTYPE_TIMESTAMP:
					Timestamp = value is ADS_TIMESTAMP ts ? ts : throw new ArgumentException("A value of ADS_TIMESTAMP is required for this type.", nameof(value));
					break;

				case ADSTYPE.ADSTYPE_BACKLINK:
					BackLink = value is ADS_BACKLINK bl ? new ADS_PROV_SPECIFIC() { dwLength = bl.RemoteID, lpValue = mem = new SafeLPWSTR(bl.ObjectName) } : throw new ArgumentException("A value of ADS_BACKLINK is required for this type.", nameof(value));
					break;

				case ADSTYPE.ADSTYPE_TYPEDNAME:
					pTypedName = mem = PutStructPtr<ADS_TYPEDNAME>(value);
					break;

				case ADSTYPE.ADSTYPE_HOLD:
					Hold = value is ADS_HOLD hld ? new() { Amount = hld.Amount, ObjectName = (IntPtr)(mem = new SafeLPWSTR(hld.ObjectName)) } : throw new ArgumentException("A value of ADS_HOLD is required for this type.", nameof(value));
					break;

				case ADSTYPE.ADSTYPE_NETADDRESS:
					pNetAddress = mem = PutStructPtr<ADS_NETADDRESS>(value);
					break;

				case ADSTYPE.ADSTYPE_REPLICAPOINTER:
					pReplicaPointer = mem = PutStructPtr<ADS_REPLICAPOINTER>(value);
					break;

				case ADSTYPE.ADSTYPE_FAXNUMBER:
					pFaxNumber = mem = PutStructPtr<ADS_FAXNUMBER>(value);
					break;

				case ADSTYPE.ADSTYPE_EMAIL:
					Email = value is ADS_EMAIL em ? new ADS_EMAIL_UNMGD() { Type = em.Type, Address = (IntPtr)(mem = new SafeLPWSTR(em.Address)) } : throw new ArgumentException("A value of ADS_EMAIL is required for this type.", nameof(value));
					break;

				case ADSTYPE.ADSTYPE_NT_SECURITY_DESCRIPTOR:
					if (value is ADS_NT_SECURITY_DESCRIPTOR sd)
						union.SecurityDescriptor = sd;
					else if (value is AdvApi32.SafePSECURITY_DESCRIPTOR psd)
						SecurityDescriptor = psd;
					else
						throw new ArgumentException($"A value of {typeof(AdvApi32.SafePSECURITY_DESCRIPTOR).Name} or {typeof(ADS_NT_SECURITY_DESCRIPTOR).Name} is required for this type.", nameof(value));
					break;

				case ADSTYPE.ADSTYPE_DN_WITH_BINARY:
					pDNWithBinary = mem = PutStructPtr<ADS_DN_WITH_BINARY>(value);
					break;

				case ADSTYPE.ADSTYPE_DN_WITH_STRING:
					pDNWithString = mem = PutStructPtr<ADS_DN_WITH_STRING>(value);
					break;
			}

			T PutBytes<T>(object value, Func<SafeAllocatedMemoryHandle, T> a, out SafeAllocatedMemoryHandle m) where T : struct
			{
				if (value is not byte[] ba)
					throw new ArgumentException("A byte array is required for this type.", nameof(value));
				m = new SafeCoTaskMemHandle(ba);
				return a(m);
			}

			SafeAllocatedMemoryHandle PutStructPtr<T>(object value) where T : struct
			{
				if (value is not T t)
					throw new ArgumentException($"A value of {typeof(T).Name} is required for this type.", nameof(value));
				return SafeCoTaskMemHandle.CreateFromStructure(t);
			}
		}

		/// <inheritdoc/>
		public override string ToString() => $"{(Value is string s ? $"\"{s}\"" : Value?.ToString())} ({dwType})";
	}

	/// <summary>The <c>ADS_VLV</c> structure contains metadata used to conduct virtual list view (VLV) searches. This structure serves two roles. First, it specifies the search preferences sent to the server. Second, it returns the VLV metadata from the server.</summary>
	/// <remarks>
	/// <para>To set the VLV by <c>dwContentCount</c> and <c>dwOffset</c>, you must also set the <c>pszTarget</c> to a <c>NULL</c> value. If <c>pszTarget</c> contains a non-<c>NULL</c> value, then it is used as the offset, otherwise, <c>lOffset</c> is used as the offset. It is recommended that you initialize the structure to zero.</para>
	/// <para>Examples</para>
	/// <para>The following code example shows how to retrieve the first 30 entries in a result set.</para>
	/// <para>The following code example shows how to retrieve the first 50 entries in a result set that start with the letters "Ha".</para>
	/// <para>The following code example shows how to retrieve the first 100 entries at the 60% approximate target, assuming that the server previously returned <c>dwContentCount</c> as 4294.</para>
	/// <para><c>Note</c>  vlvResp represents an <c>ADS_VLV</c> structure previously returned by the server.</para>
	/// <para> </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/ns-iads-ads_vlv
	// typedef struct _ads_vlv { DWORD dwBeforeCount; DWORD dwAfterCount; DWORD dwOffset; DWORD dwContentCount; LPWSTR pszTarget; DWORD dwContextIDLength; LPBYTE lpContextID; } ADS_VLV, *PADS_VLV;
	[PInvokeData("iads.h", MSDNShortId = "NS:iads._ads_vlv")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADS_VLV
	{
		/// <summary>Indicates the number of entries, before the target entry, that the client requests from the server.</summary>
		public uint dwBeforeCount;

		/// <summary>Indicates the number of entries, after the target entry, that the client requests from the server.</summary>
		public uint dwAfterCount;

		/// <summary>On input, indicates the target entry's requested offset within the list. If the client specifies an offset which equals the client's assumed content count, then the target is the last entry in the list. On output, indicates the server's best estimate as to the actual offset of the returned target entry's position in the list.</summary>
		public uint dwOffset;

		/// <summary>The input value represents the client's estimated value for the content count. The output value is the server's estimate of the content count. If the client sends a content count of zero, this means that the server must use its estimate of the content count in place of the client's.</summary>
		public uint dwContentCount;

		/// <summary>Optional. Null-terminated Unicode string that indicates the desired target entry requested by the client. If this parameter contains a non-<c>NULL</c> value, the server ignores the value specified in <c>dwOffset</c> and search for the first target entry whose value for the primary sort key is greater than or equal to the specified string, based on the sort order of the list.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszTarget;

		/// <summary>Optional. Parameter that indicates the length of the context identifier. On input, if passing a context identifier in <c>lpContextID</c>, this must be set to the size of the identifier in bytes. Otherwise, it must be set equal to zero. On output, if <c>lpContextID</c> contains a non-<c>NULL</c> value, this indicates the length, in bytes, of the context ID returned by the server.</summary>
		public uint dwContextIDLength;

		/// <summary>Optional. Indicates the server-generated context identifier. This parameter may be sent to clients. If a client receives this parameter, it should return it unchanged in a subsequent request which relates to the same list. This interaction may enhance the performance and effectiveness of the servers. If not passing a context identifier to the server, this member must be set to <c>NULL</c> value. On output, if this member contains a non-<c>NULL</c> value, this points to the context ID returned by the server.</summary>
		public IntPtr lpContextID;
	}
}