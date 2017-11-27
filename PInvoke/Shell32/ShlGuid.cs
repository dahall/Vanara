using System;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Restricts usage to BindToObject.</summary>
		/// <value>{3981e224-f559-11d3-8e3a-00c04f6837d5}</value>
		public static Guid BHID_SFObject { get; } = new Guid("{3981e224-f559-11d3-8e3a-00c04f6837d5}");
		/// <summary>Restricts usage to GetUIObjectOf.</summary>
		/// <value>{3981e225-f559-11d3-8e3a-00c04f6837d5}</value>
		public static Guid BHID_SFUIObject { get; } = new Guid("{3981e225-f559-11d3-8e3a-00c04f6837d5}");
		/// <summary>Restricts usage to CreateViewObject.</summary>
		/// <value>{3981e226-f559-11d3-8e3a-00c04f6837d5}</value>
		public static Guid BHID_SFViewObject { get; } = new Guid("{3981e226-f559-11d3-8e3a-00c04f6837d5}");
		/// <summary>Attempts to retrieve the storage RIID, but defaults to Shell implementation on failure.</summary>
		/// <value>{3981e227-f559-11d3-8e3a-00c04f6837d5}</value>
		public static Guid BHID_Storage { get; } = new Guid("{3981e227-f559-11d3-8e3a-00c04f6837d5}");
		/// <summary>Restricts usage to IStream.</summary>
		/// <value>{1CEBB3AB-7C10-499a-A417-92CA16C4CB83}</value>
		public static Guid BHID_Stream { get; } = new Guid("{1CEBB3AB-7C10-499a-A417-92CA16C4CB83}");
		/// <summary>Introduced in Windows 8: Gets an IRandomAccessStream object for the item.</summary>
		/// <value>{f16fc93b-77ae-4cfe-bda7-a866eea6878d}</value>
		public static Guid BHID_RandomAccessStream { get; } = new Guid("{f16fc93b-77ae-4cfe-bda7-a866eea6878d}");
		/// <summary>CLSID_ShellItem is initialized with the target of this item (can only be SFGAO_LINK). See GetAttributesOf for a description of SFGAO_LINK.</summary>
		/// <value>{3981e228-f559-11d3-8e3a-00c04f6837d5}</value>
		public static Guid BHID_LinkTargetItem { get; } = new Guid("{3981e228-f559-11d3-8e3a-00c04f6837d5}");
		/// <summary>If the item is a folder, gets an IEnumShellItems object with which to enumerate the storage contents.</summary>
		/// <value>{4621A4E3-F0D6-4773-8A9C-46E77B174840}</value>
		public static Guid BHID_StorageEnum { get; } = new Guid("{4621A4E3-F0D6-4773-8A9C-46E77B174840}");
		/// <summary>Introduced in Windows Vista: If the item is a folder, gets an ITransferSource or ITransferDestination object.</summary>
		/// <value>{5D080304-FE2C-48fc-84CE-CF620B0F3C53}</value>
		public static Guid BHID_Transfer { get; } = new Guid("{5D080304-FE2C-48fc-84CE-CF620B0F3C53}");
		/// <summary>Introduced in Windows Vista: Restricts usage to IPropertyStore or IPropertyStoreFactory.</summary>
		/// <value>{0384e1a4-1523-439c-a4c8-ab911052f586}</value>
		public static Guid BHID_PropertyStore { get; } = new Guid("{0384e1a4-1523-439c-a4c8-ab911052f586}");
		/// <summary>Introduced in Windows Vista: Restricts usage to IExtractImage or IThumbnailProvider.</summary>
		/// <value>{7b2e650a-8e20-4f4a-b09e-6597afc72fb0}</value>
		public static Guid BHID_ThumbnailHandler { get; } = new Guid("{7b2e650a-8e20-4f4a-b09e-6597afc72fb0}");
		/// <summary>Introduced in Windows Vista: If the item is a folder, gets an IEnumShellItems object that enumerates all items in the folder. This includes folders, nonfolders, and hidden items.</summary>
		/// <value>{94f60519-2850-4924-aa5a-d15e84868039}</value>
		public static Guid BHID_EnumItems { get; } = new Guid("{94f60519-2850-4924-aa5a-d15e84868039}");
		/// <summary>Introduced in Windows Vista: Gets an IDataObject object for use with an item or an array of items.</summary>
		/// <value>{B8C0BD9F-ED24-455c-83E6-D5390C4FE8C4}</value>
		public static Guid BHID_DataObject { get; } = new Guid("{B8C0BD9F-ED24-455c-83E6-D5390C4FE8C4}");
		/// <summary>Introduced in Windows Vista: Gets an IQueryAssociations object for use with an item or an array of items.</summary>
		/// <value>{bea9ef17-82f1-4f60-9284-4f8db75c3be9}</value>
		public static Guid BHID_AssociationArray { get; } = new Guid("{bea9ef17-82f1-4f60-9284-4f8db75c3be9}");
		/// <summary>Introduced in Windows Vista: Restricts usage to IFilter.</summary>
		/// <value>{38d08778-f557-4690-9ebf-ba54706ad8f7}</value>
		public static Guid BHID_Filter { get; } = new Guid("{38d08778-f557-4690-9ebf-ba54706ad8f7}");
		/// <summary>Introduced in Windows 7: Gets an IEnumAssocHandlers object used to enumerate the recommended association handlers for the given item.</summary>
		/// <value>{b8ab0b9c-c2ec-4f7a-918d-314900e6280a}</value>
		public static Guid BHID_EnumAssocHandlers { get; } = new Guid("{b8ab0b9c-c2ec-4f7a-918d-314900e6280a}");
		/// <summary>Introduced in Windows 8.1: Gets an object used to provide placeholder file functionality.</summary>
		/// <value>{8677DCEB-AAE0-4005-8D3D-547FA852F825}</value>
		public static Guid BHID_FilePlaceholder { get; } = new Guid("{8677DCEB-AAE0-4005-8D3D-547FA852F825}");
	}
}
