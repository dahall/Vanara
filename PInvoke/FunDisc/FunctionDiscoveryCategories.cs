namespace Vanara.PInvoke;

public static partial class FunDisc
{
#pragma warning disable CS1591
	public const string FD_SUBKEY = "SOFTWARE\\Microsoft\\Function Discovery\\";
	public const string FD_SUBKEY_CATEGORIES = FD_SUBKEY + "Categories\\";

	// *****************************************************************************
	// Function Discovery Categories
	// *****************************************************************************
	// Important:  Anything added here should also be added to FunctionDiscoveryManagedKeys.h
	// *****************************************************************************

	// Provider Categories
	// Windows Vista
	public const string FCTN_CATEGORY_PNP = "Provider\\Microsoft.Base.PnP";
	public const string FCTN_CATEGORY_REGISTRY = "Provider\\Microsoft.Base.Registry";
	public const string FCTN_CATEGORY_SSDP = "Provider\\Microsoft.Networking.SSDP";
	public const string FCTN_CATEGORY_WSDISCOVERY = "Provider\\Microsoft.Networking.WSD";
	public const string FCTN_CATEGORY_NETBIOS = "Provider\\Microsoft.Networking.Netbios";
	public const string FCTN_CATEGORY_WCN = "Provider\\Microsoft.Networking.WCN";
	public const string FCTN_CATEGORY_PUBLICATION = "Provider\\Microsoft.Base.Publication";
	public const string FCTN_CATEGORY_PNPXASSOCIATION = "Provider\\Microsoft.PnPX.Association";
	// Wireless Update Release
	public const string FCTN_CATEGORY_BT = "Provider\\Microsoft.Devices.Bluetooth";
	public const string FCTN_CATEGORY_WUSB = "Provider\\Microsoft.Devices.WirelessUSB";
	public const string FCTN_CATEGORY_DEVICEDISPLAYOBJECTS = "Provider\\Microsoft.Base.DeviceDisplayObjects";
	public const string FCTN_CATEGORY_DEVQUERYOBJECTS = "Provider\\Microsoft.Base.DevQueryObjects";

	// Layered Categories
	// Windows Vista
	public const string FCTN_CATEGORY_NETWORKDEVICES = "Layered\\Microsoft.Networking.Devices";
	public const string FCTN_CATEGORY_DEVICES = "Layered\\Microsoft.Base.Devices";
	public const string FCTN_CATEGORY_DEVICEFUNCTIONENUMERATORS = "Layered\\Microsoft.Devices.FunctionEnumerators";
	public const string FCTN_CATEGORY_DEVICEPAIRING = "Layered\\Microsoft.Base.DevicePairing";

	// *****************************************************************************
	// Function Discovery SubCategories
	// *****************************************************************************
	// Important:  Anything added here should also be added to FunctionDiscoveryManagedKeys.h
	// *****************************************************************************

	// Subcategories of Devices FCTN_CATEGORY_DEVICES
	public const string FCTN_SUBCAT_DEVICES_WSDPRINTERS = "WSDPrinters";

	// Subcategories of Devices FCTN_CATEGORY_NETWORKDEVICES
	public const string FCTN_SUBCAT_NETWORKDEVICES_SSDP = "SSDP";
	public const string FCTN_SUBCAT_NETWORKDEVICES_WSD = "WSD";

	// Subcategories of Registry
	public const string FCTN_SUBCAT_REG_PUBLICATION = "Publication";
	public const string FCTN_SUBCAT_REG_DIRECTED = "Directed";
}