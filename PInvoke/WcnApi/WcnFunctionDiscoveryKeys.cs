using System;
using System.Runtime.InteropServices;
using System.Text;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

public static partial class WcnApi
{
	/// <summary/>
	public static readonly Guid SID_WcnProvider = new Guid(0xC100BECA, 0xD33A, 0x4A4B, 0xBF, 0x23, 0xBB, 0xEF, 0x46, 0x63, 0xD0, 0x17);

	/// <summary>The major device category of a WCN device.</summary>
	public static readonly PROPERTYKEY PKEY_WCN_DeviceType_Category = new PROPERTYKEY(new Guid(0x88190b8b, 0x4684, 0x11da, 0xa2, 0x6a, 0x00, 0x02, 0xb3, 0x98, 0x8e, 0x81), 0x00000010);

	/// <summary>The unique manufacturer OUI associated with the device.</summary>
	public static readonly PROPERTYKEY PKEY_WCN_DeviceType_SubCategoryOUI = new PROPERTYKEY(new Guid(0x88190b8b, 0x4684, 0x11da, 0xa2, 0x6a, 0x00, 0x02, 0xb3, 0x98, 0x8e, 0x81), 0x00000011);

	/// <summary>The device subcategory of a WCN device. The subcategory must be interpreted along with the OUI from PKEY_WCN_DeviceType_SubCategoryOUI.</summary>
	public static readonly PROPERTYKEY PKEY_WCN_DeviceType_SubCategory = new PROPERTYKEY(new Guid(0x88190b8b, 0x4684, 0x11da, 0xa2, 0x6a, 0x00, 0x02, 0xb3, 0x98, 0x8e, 0x81), 0x00000012);

	/// <summary/>
	public static readonly PROPERTYKEY PKEY_WCN_SSID = new PROPERTYKEY(new Guid(0x88190b8b, 0x4684, 0x11da, 0xa2, 0x6a, 0x00, 0x02, 0xb3, 0x98, 0x8e, 0x81), 0x00000020);
}