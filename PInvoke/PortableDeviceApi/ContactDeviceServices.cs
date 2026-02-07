#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

public static partial class PortableDeviceApi
{
	/*****************************************************************************
		Contacts Service Info
	******************************************************************************/

	public static Guid SERVICE_Contacts => new(0xDD04D5FC, 0x9D6E, 0x4F76, 0x9D, 0xCF, 0xEC, 0xA6, 0x33, 0x9B, 0x73, 0x89);

	public const string NAME_ContactsSvc = "Contacts";
	public const int TYPE_ContactsSvc = 0;


	/*****************************************************************************
		Contacts Service Properties
	******************************************************************************/


	/// <summary> PKEY_ContactSvc_SyncWithPhoneOnly
	/// Type: UInt8
	/// Form: None
	/// </summary> 
	[CorrespondingType(typeof(byte))]
	public static PROPERTYKEY PKEY_ContactSvc_SyncWithPhoneOnly => PKEY_SyncSvc_FilterType;
	public const string NAME_ContactSvc_SyncWithPhoneOnly = NAME_SyncSvc_FilterType;

	/*****************************************************************************
		Contacts Service Object Formats
	******************************************************************************/

	/// <summary> FORMAT_AbstractContact
	/// </summary> 

	public static Guid FORMAT_AbstractContact => new(0xBB810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AbstractContact = "AbstractContact";


	/// <summary> FORMAT_VCard2Contact
	/// </summary> 

	public static Guid FORMAT_VCard2Contact => new(0xBB820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_VCard2Contact = "VCard2Contact";


	/// <summary> FORMAT_VCard3Contact
	/// </summary> 

	public static Guid FORMAT_VCard3Contact => new(0xBB830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_VCard3Contact = "VCard3Contact";


	/// <summary> FORMAT_AbstractContactGroup
	/// </summary> 

	public static Guid FORMAT_AbstractContactGroup => new(0xBA060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

	public const string NAME_AbstractContactGroup = "AbstractContactGroup";



	/*****************************************************************************
		Contacts Service Object Property Keys
	******************************************************************************/

	public static Guid NAMESPACE_ContactObj => new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B);


	/// <summary> ContactObj.GivenName
	/// MTP Property: Given Name (0xDD00)
	/// Type: String/AUInt16
	/// Form: None/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_GivenName => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 3);

	public const string NAME_ContactObj_GivenName = "GivenName";


	/// <summary> ContactObj.MiddleNames
	/// MTP Property: Middle Names (0xDD01)
	/// Type: String/AUInt16
	/// Form: None/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_MiddleNames => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 4);

	public const string NAME_ContactObj_MiddleNames = "MiddleNames";


	/// <summary> ContactObj.FamilyName
	/// MTP Property: Family Name (0xDD02)
	/// Type: String/AUInt16
	/// Form: None/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_FamilyName => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 5);

	public const string NAME_ContactObj_FamilyName = "FamilyName";


	/// <summary> ContactObj.Title
	/// MTP Property: Prefix (0xDD03)
	/// Type: String/AUInt16
	/// Form: None/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_Title => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 6);

	public const string NAME_ContactObj_Title = "Title";


	/// <summary> ContactObj.Suffix
	/// MTP Property: Suffix (0xDD04)
	/// Type: String/AUInt16
	/// Form: None/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_Suffix => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 7);

	public const string NAME_ContactObj_Suffix = "Suffix";


	/// <summary> ContactObj.PhoneticGivenName
	/// MTP Property: Phonetic Given Name (0xDD05)
	/// Type: String/AUInt16
	/// Form: None/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_PhoneticGivenName => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 8);

	public const string NAME_ContactObj_PhoneticGivenName = "PhoneticGivenName";


	/// <summary> ContactObj.PhoneticFamilyName
	/// MTP Property: Phonetic Family Name (0xDD06)
	/// Type: String/AUInt16
	/// Form: None/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_PhoneticFamilyName => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 9);

	public const string NAME_ContactObj_PhoneticFamilyName = "PhoneticFamilyName";


	/// <summary> ContactObj.PersonalAddressFull
	/// MTP Property: Postal Address Personal Full (0xDD1F)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_PersonalAddressFull => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 10);

	public const string NAME_ContactObj_PersonalAddressFull = "PersonalAddressFull";


	/// <summary> ContactObj.PersonalAddressStreet
	/// MTP Property: Postal Address Line 1 (0xDD20)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_PersonalAddressStreet => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 11);

	public const string NAME_ContactObj_PersonalAddressStreet = "PersonalAddressStreet";


	/// <summary> ContactObj.PersonalAddressLine2
	/// MTP Property: Postal Address Line 2 (0xDD21)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_PersonalAddressLine2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 12);

	public const string NAME_ContactObj_PersonalAddressLine2 = "PersonalAddressLine2";


	/// <summary> ContactObj.PersonalAddressCity
	/// MTP Property: Postal Address Personal City (0xDD22)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_PersonalAddressCity => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 13);

	public const string NAME_ContactObj_PersonalAddressCity = "PersonalAddressCity";


	/// <summary> ContactObj.PersonalAddressRegion
	/// MTP Property: Postal Address Personal Region (0xDD23)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_PersonalAddressRegion => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 14);

	public const string NAME_ContactObj_PersonalAddressRegion = "PersonalAddressRegion";


	/// <summary> ContactObj.PersonalAddressPostalCode
	/// MTP Property: Postal Address Personal Postal Code (0xDD24)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_PersonalAddressPostalCode => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 15);

	public const string NAME_ContactObj_PersonalAddressPostalCode = "PersonalAddressPostalCode";


	/// <summary> ContactObj.PersonalAddressCountry
	/// MTP Property: Postal Address Personal Country (0xDD25)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_PersonalAddressCountry => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 16);

	public const string NAME_ContactObj_PersonalAddressCountry = "PersonalAddressCountry";


	/// <summary> ContactObj.BusinessAddressFull
	/// MTP Property: Postal Address Business Full (0xDD26)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_BusinessAddressFull => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 17);

	public const string NAME_ContactObj_BusinessAddressFull = "BusinessAddressFull";


	/// <summary> ContactObj.BusinessAddressStreet
	/// MTP Property: Postal Address Business Line 1 (0xDD27)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_BusinessAddressStreet => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 18);

	public const string NAME_ContactObj_BusinessAddressStreet = "BusinessAddressStreet";


	/// <summary> ContactObj.BusinessAddressLine2
	/// MTP Property: Postal Address Business Line 2 (0xDD28)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_BusinessAddressLine2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 19);

	public const string NAME_ContactObj_BusinessAddressLine2 = "BusinessAddressLine2";


	/// <summary> ContactObj.BusinessAddressCity
	/// MTP Property: Postal Address Business City (0xDD29)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_BusinessAddressCity => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 20);

	public const string NAME_ContactObj_BusinessAddressCity = "BusinessAddressCity";


	/// <summary> ContactObj.BusinessAddressRegion
	/// MTP Property: Postal Address Business Region (0xDD2A)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_BusinessAddressRegion => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 21);

	public const string NAME_ContactObj_BusinessAddressRegion = "BusinessAddressRegion";


	/// <summary> ContactObj.BusinessAddressPostalCode
	/// MTP Property: Postal Address Business Postal Code (0xDD2B)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_BusinessAddressPostalCode => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 22);

	public const string NAME_ContactObj_BusinessAddressPostalCode = "BusinessAddressPostalCode";


	/// <summary> ContactObj.BusinessAddressCountry
	/// MTP Property: Postal Address Business Country (0xDD2C)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_BusinessAddressCountry => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 23);

	public const string NAME_ContactObj_BusinessAddressCountry = "BusinessAddressCountry";


	/// <summary> ContactObj.OtherAddressFull
	/// MTP Property: Postal Address Other Full (0xDD2D)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_OtherAddressFull => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 24);

	public const string NAME_ContactObj_OtherAddressFull = "OtherAddressFull";


	/// <summary> ContactObj.OtherAddressStreet
	/// MTP Property: Postal Address Other Line 1 (0xDD2E)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary>
	[CorrespondingType(typeof(string))]

	public static PROPERTYKEY PKEY_ContactObj_OtherAddressStreet => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 25);

	public const string NAME_ContactObj_OtherAddressStreet = "OtherAddressStreet";


	/// <summary> ContactObj.OtherAddressLine2
	/// MTP Property: Postal Address Other Line 2 (0xDD2F)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_OtherAddressLine2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 26);

	public const string NAME_ContactObj_OtherAddressLine2 = "OtherAddressLine2";


	/// <summary> ContactObj.OtherAddressCity
	/// MTP Property: Postal Address Other City (0xDD30)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_OtherAddressCity => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 27);

	public const string NAME_ContactObj_OtherAddressCity = "OtherAddressCity";


	/// <summary> ContactObj.OtherAddressRegion
	/// MTP Property: Postal Address Other Region (0xDD31)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_OtherAddressRegion => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 28);

	public const string NAME_ContactObj_OtherAddressRegion = "OtherAddressRegion";


	/// <summary> ContactObj.OtherAddressPostalCode
	/// MTP Property: Postal Address Other Postal Code (0xDD32)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_OtherAddressPostalCode => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 29);

	public const string NAME_ContactObj_OtherAddressPostalCode = "OtherAddressPostalCode";


	/// <summary> ContactObj.OtherAddressCountry
	/// MTP Property: Postal Address Other Country (0xDD33)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_OtherAddressCountry => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 30);

	public const string NAME_ContactObj_OtherAddressCountry = "OtherAddressCountry";


	/// <summary> ContactObj.Email
	/// MTP Property: Email Primary (0xDD07)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_Email => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 31);

	public const string NAME_ContactObj_Email = "Email";


	/// <summary> ContactObj.PersonalEmail
	/// MTP Property: Email Personal 1 (0xDD08)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_PersonalEmail => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 32);

	public const string NAME_ContactObj_PersonalEmail = "PersonalEmail";


	/// <summary> ContactObj.PersonalEmail2
	/// MTP Property: Email Personal 2 (0xDD09)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_PersonalEmail2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 33);

	public const string NAME_ContactObj_PersonalEmail2 = "PersonalEmail2";


	/// <summary> ContactObj.BusinessEmail
	/// MTP Property: Email Business 1 (0xDD0A)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_BusinessEmail => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 34);

	public const string NAME_ContactObj_BusinessEmail = "BusinessEmail";


	/// <summary> ContactObj.BusinessEmail2
	/// MTP Property: Email Business 2 (0xDD0B)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_BusinessEmail2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 35);

	public const string NAME_ContactObj_BusinessEmail2 = "BusinessEmail2";


	/// <summary> ContactObj.OtherEmail
	/// MTP Property: Email Others (0xDD0C)
	/// Type: AUInt16
	/// Form: LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_OtherEmail => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 36);

	public const string NAME_ContactObj_OtherEmail = "OtherEmail";


	/// <summary> ContactObj.Phone
	/// MTP Property: Phone Primary (0xDD0D)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_Phone => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 37);

	public const string NAME_ContactObj_Phone = "Phone";


	/// <summary> ContactObj.PersonalPhone
	/// MTP Property: Phone Number Personal 1 (0xDD0E)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_PersonalPhone => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 38);

	public const string NAME_ContactObj_PersonalPhone = "PersonalPhone";


	/// <summary> ContactObj.PersonalPhone2
	/// MTP Property: Phone Number Personal 2 (0xDD0F)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_PersonalPhone2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 39);

	public const string NAME_ContactObj_PersonalPhone2 = "PersonalPhone2";


	/// <summary> ContactObj.BusinessPhone
	/// MTP Property: Phone Number Business 1 (0xDD10)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_BusinessPhone => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 40);

	public const string NAME_ContactObj_BusinessPhone = "BusinessPhone";


	/// <summary> ContactObj.BusinessPhone2
	/// MTP Property: Phone Number Business 2 (0xDD11)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_BusinessPhone2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 41);

	public const string NAME_ContactObj_BusinessPhone2 = "BusinessPhone2";


	/// <summary> ContactObj.MobilePhone
	/// MTP Property: Phone Number Mobile 1 (0xDD12)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_MobilePhone => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 42);

	public const string NAME_ContactObj_MobilePhone = "MobilePhone";


	/// <summary> ContactObj.MobilePhone2
	/// MTP Property: Phone Number Mobile 2 (0xDD13)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_MobilePhone2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 43);

	public const string NAME_ContactObj_MobilePhone2 = "MobilePhone2";


	/// <summary> ContactObj.PersonalFax
	/// MTP Property: Fax Number Personal (0xDD15)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_PersonalFax => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 44);

	public const string NAME_ContactObj_PersonalFax = "PersonalFax";


	/// <summary> ContactObj.BusinessFax
	/// MTP Property: Fax Number Business (0xDD16)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_BusinessFax => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 45);

	public const string NAME_ContactObj_BusinessFax = "BusinessFax";


	/// <summary> ContactObj.Pager
	/// MTP Property: Pager Number (0xDD17)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_Pager => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 46);

	public const string NAME_ContactObj_Pager = "Pager";


	/// <summary> ContactObj.OtherPhone
	/// MTP Property: Phone Number Others (0xDD18)
	/// Type: AUInt16
	/// Form: LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_OtherPhone => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 47);

	public const string NAME_ContactObj_OtherPhone = "OtherPhone";


	/// <summary> ContactObj.WebAddress
	/// MTP Property: Primary Web Address (0xDD19)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_WebAddress => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 48);

	public const string NAME_ContactObj_WebAddress = "WebAddress";


	/// <summary> ContactObj.PersonalWebAddress
	/// MTP Property: Personal Web Address (0xDD1A)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_PersonalWebAddress => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 49);

	public const string NAME_ContactObj_PersonalWebAddress = "PersonalWebAddress";


	/// <summary> ContactObj.BusinessWebAddress
	/// MTP Property: Business Web Address (0xDD1B)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_BusinessWebAddress => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 50);

	public const string NAME_ContactObj_BusinessWebAddress = "BusinessWebAddress";


	/// <summary> ContactObj.IMAddress
	/// MTP Property: Instant Messanger Address (0xDD1C)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_IMAddress => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 51);

	public const string NAME_ContactObj_IMAddress = "IMAddress";


	/// <summary> ContactObj.IMAddress2
	/// MTP Property: Instant Messanger Address 2 (0xDD1D)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_IMAddress2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 52);

	public const string NAME_ContactObj_IMAddress2 = "IMAddress2";


	/// <summary> ContactObj.IMAddress3
	/// MTP Property: Instant Messanger Address 3 (0xDD1E)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_IMAddress3 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 53);

	public const string NAME_ContactObj_IMAddress3 = "IMAddress3";


	/// <summary> ContactObj.Organization
	/// MTP Property: Organization Name (0xDD34)
	/// Type: String/AUInt16
	/// Form: None/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_Organization => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 54);

	public const string NAME_ContactObj_Organization = "Organization";


	/// <summary> ContactObj.PhoneticOrganization
	/// MTP Property: Phonetic Organization Name (0xDD35)
	/// Type: String/AUInt16
	/// Form: None/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_PhoneticOrganization => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 55);

	public const string NAME_ContactObj_PhoneticOrganization = "PhoneticOrganization";


	/// <summary> ContactObj.Role
	/// MTP Property: Role (0xDD36)
	/// Type: String/AUInt16
	/// Form: None/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_Role => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 56);

	public const string NAME_ContactObj_Role = "Role";


	/// <summary> ContactObj.Fax
	/// MTP Property: Fax Number Primary (0xDD14)
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_Fax => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 58);

	public const string NAME_ContactObj_Fax = "Fax";


	/// <summary> ContactObj.Spouse
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_Spouse => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 59);

	public const string NAME_ContactObj_Spouse = "Spouse";


	/// <summary> ContactObj.Children
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_Children => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 60);

	public const string NAME_ContactObj_Children = "Children";


	/// <summary> ContactObj.Assistant
	/// Type: String/AUInt16
	/// Form: None/RegEx/LongString
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_Assistant => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 61);

	public const string NAME_ContactObj_Assistant = "Assistant";


	/// <summary> ContactObj.Ringtone
	/// Type: UInt32
	/// Form: ObjectID
	/// </summary> 
	[CorrespondingType(typeof(uint))]
	public static PROPERTYKEY PKEY_ContactObj_Ringtone => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 63);

	public const string NAME_ContactObj_Ringtone = "Ringtone";


	/// <summary> ContactObj.Birthdate
	/// MTP Property: Birthdate (0xDD37)
	/// Type: String
	/// Form: DateTime
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_Birthdate => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 65);

	public const string NAME_ContactObj_Birthdate = "Birthdate";


	/// <summary> ContactObj.AnniversaryDate
	/// Type: String
	/// Form: DateTime
	/// </summary> 
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_ContactObj_AnniversaryDate => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 66);

	public const string NAME_ContactObj_AnniversaryDate = "AnniversaryDate";
}