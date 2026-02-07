#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

public static partial class PortableDeviceApi
{
	/*****************************************************************************
	Service Info
	******************************************************************************/

	/*  Service Info Version */
	public const int DEVSVC_SERVICEINFO_VERSION = 0x00000064;

	/*  Service Flags */
	public const int DEVSVCTYPE_DEFAULT = 0x00000000;
	public const int DEVSVCTYPE_ABSTRACT = 0x00000001;


	/*****************************************************************************
		Common Service Properties
	******************************************************************************/

	public static Guid NAMESPACE_Services = new(0x14fa7268, 0x0b6c, 0x4214, 0x94, 0x87, 0x43, 0x5b, 0x48, 0x0a, 0x8c, 0x4f);

	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_Services_ServiceDisplayName = new(new(0x14fa7268, 0x0b6c, 0x4214, 0x94, 0x87, 0x43, 0x5b, 0x48, 0x0a, 0x8c, 0x4), 2);

	public const string NAME_Services_ServiceDisplayName = "ServiceDisplayName";

	/*  PKEY_Services_ServiceIcon
	 *
	 *  Type: AUInt8
	 *  Form: ByteArray
	 */

	[CorrespondingType(typeof(byte))]
	public static PROPERTYKEY PKEY_Services_ServiceIcon = new(new(0x14fa7268, 0x0b6c, 0x4214, 0x94, 0x87, 0x43, 0x5b, 0x48, 0x0a, 0x8c, 0x4f), 3);

	public const string NAME_Services_ServiceIcon = "ServiceIcon";


	/*  PKEY_Services_ServiceLocale
	 *
	 *  Contains the RFC4646 compliant language string for data in this service
	 *  
	 *  Type: String
	 *  Form: None
	 */
	[CorrespondingType(typeof(string))]
	public static PROPERTYKEY PKEY_Services_ServiceLocale = new(new(0x14fa7268, 0x0b6c, 0x4214, 0x94, 0x87, 0x43, 0x5b, 0x48, 0x0a, 0x8c, 0x4f), 4);

	public const string NAME_Services_ServiceLocale = "ServiceLocale";
}