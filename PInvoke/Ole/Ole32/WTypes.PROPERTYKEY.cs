using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public static partial class Ole32
	{
		/// <summary>Specifies the FMTID/PID identifier that programmatically identifies a property. Replaces SHCOLUMNID.</summary>
		[PInvokeData("Wtypes.h", MSDNShortId = "bb773381")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public partial struct PROPERTYKEY : IComparable<PROPERTYKEY>, IEquatable<PROPERTYKEY>
		{
			private static Dictionary<PROPERTYKEY, string> revIndex;

			public Guid fmtid;
			public uint pid;

			public PROPERTYKEY(Guid key, uint id)
			{
				fmtid = key;
				pid = id;
			}

			public Guid Key => fmtid;

			public uint Id => pid;

			public override string ToString() => GetCononicalName() ?? ReverseLookup(this) ?? $"{Key:B} {Id}";

			public override bool Equals(object obj) => obj is PROPERTYKEY other && Equals(other);

			public bool Equals(PROPERTYKEY other) => Equals(Key, other.Key) && Id == other.Id;

			public static bool operator ==(PROPERTYKEY pk1, PROPERTYKEY pk2) => pk1.Equals(pk2);

			public static bool operator !=(PROPERTYKEY pk1, PROPERTYKEY pk2) => !pk1.Equals(pk2);

			public override int GetHashCode() => new { Key, Id }.GetHashCode();

			int IComparable<PROPERTYKEY>.CompareTo(PROPERTYKEY other)
			{
				var ret = Key.GetHashCode() - other.Key.GetHashCode();
				if (ret == 0)
					ret = (int)(Id - other.Id);
				return ret;
			}

			public string GetCononicalName()
			{
				try
				{
					var pk = this;
					PropSys.PSGetNameFromPropertyKey(pk, out var str);
					return str;
				}
				catch { }
				return null;
			}

			public static string ReverseLookup(PROPERTYKEY key)
			{
				if (revIndex == null)
				{
					revIndex = new Dictionary<PROPERTYKEY, string>();
					AddMembersToIndex(typeof(System));
				}
				revIndex.TryGetValue(key, out var ret);
				return ret;

				void AddMembersToIndex(Type type, int level = 0)
				{
					foreach (var pi in type.GetProperties(BindingFlags.Public | BindingFlags.Static))
					{
						if (pi.PropertyType == typeof(PROPERTYKEY))
						{
							var pType = type;
							var name = new StringBuilder(pi.Name);
							for (var i = 0; i < level; i++)
							{
								name.Insert(0, pType.Name + ".");
								pType = pType.DeclaringType;
							}
							try
							{
								revIndex.Add((PROPERTYKEY)pi.GetValue(null, null), name.ToString());
							}
							catch { }
						}
					}
					foreach (var ti in type.GetNestedTypes(BindingFlags.Public))
						AddMembersToIndex(ti, level + 1);
				}
			}

			[PInvokeData("Propkey.h", MSDNShortId = "dd561977")]
			public static class System
			{
				/// <summary>
				/// <para>Name:     System.Thumbnail -- PKEY_Thumbnail</para>
				/// <para>Description: A data that represents the thumbnail in VT_CF format.</para>
				/// <para>Type:     Clipboard -- VT_CF</para>
				/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 17 (PIDSI_THUMBNAIL)</para>
				/// </summary>
				public static PROPERTYKEY Thumbnail
					= new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 17);

				/// <summary>
				/// <para>Name:     System.AcquisitionID -- PKEY_AcquisitionID</para>
				/// <para>Description: Hash to determine acquisition session.</para>
				/// <para>Type:     Int32 -- VT_I4</para>
				/// <para>FormatID: {65A98875-3C80-40AB-ABBC-EFDAF77DBEE2}, 100</para>
				/// </summary>
				public static PROPERTYKEY AcquisitionID
					=> new PROPERTYKEY(new Guid("{65A98875-3C80-40AB-ABBC-EFDAF77DBEE2}"), 100);

				/// <summary>
				/// <para>Name:     System.ApplicationName -- PKEY_ApplicationName</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR) Legacy code may treat this as VT_LPSTR.</para>
				/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 18 (PIDSI_APPNAME)</para>
				/// </summary>
				public static PROPERTYKEY ApplicationName
					=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 18);

				/// <summary>
				/// <para>Name:     System.Author -- PKEY_Author</para>
				/// <para>Description:</para>
				/// <para>
				/// Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR) Legacy code may treat this as VT_LPSTR.
				/// </para>
				/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 4 (PIDSI_AUTHOR)</para>
				/// </summary>
				public static PROPERTYKEY Author
					=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 4);

				/// <summary>
				/// <para>Name:     System.Capacity -- PKEY_Capacity</para>
				/// <para>Description: The amount of total space in bytes.</para>
				/// <para>Type:     UInt64 -- VT_UI8</para>
				/// <para>
				/// FormatID: (FMTID_Volume) {9B174B35-40FF-11D2-A27E-00C04FC30871}, 3 (PID_VOLUME_CAPACITY) (Filesystem Volume Properties)
				/// </para>
				/// </summary>
				public static PROPERTYKEY Capacity
					=> new PROPERTYKEY(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 3);

				/// <summary>
				/// <para>Name:     System.Category -- PKEY_Category</para>
				/// <para>Description: Legacy code treats this as VT_LPSTR.</para>
				/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
				/// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 2 (PIDDSI_CATEGORY)</para>
				/// </summary>
				public static PROPERTYKEY Category
					=> new PROPERTYKEY(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 2);

				/// <summary>
				/// <para>Name:     System.Comment -- PKEY_Comment</para>
				/// <para>Description: Comments.</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR) Legacy code may treat this as VT_LPSTR.</para>
				/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 6 (PIDSI_COMMENTS)</para>
				/// </summary>
				public static PROPERTYKEY Comment
					=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 6);

				/// <summary>
				/// <para>Name:     System.Company -- PKEY_Company</para>
				/// <para>Description: The company or publisher.</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 15 (PIDDSI_COMPANY)</para>
				/// </summary>
				public static PROPERTYKEY Company
					=> new PROPERTYKEY(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 15);

				/// <summary>
				/// <para>Name:     System.ComputerName -- PKEY_ComputerName</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 5 (PID_COMPUTERNAME)</para>
				/// </summary>
				public static PROPERTYKEY ComputerName
					=> new PROPERTYKEY(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 5);

				/// <summary>
				/// <para>Name:     System.ContainedItems -- PKEY_ContainedItems</para>
				/// <para>
				/// Description: The list of type of items, this item contains. For example, this item contains urls, attachments etc. This
				/// is represented as a vector array of GUIDs where each GUID represents certain type.
				/// </para>
				/// <para>Type:     Multivalue Guid -- VT_VECTOR | VT_CLSID (For variants: VT_ARRAY | VT_CLSID)</para>
				/// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 29</para>
				/// </summary>
				public static PROPERTYKEY ContainedItems
					=> new PROPERTYKEY(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 29);

				/// <summary>
				/// <para>Name:     System.ContentStatus -- PKEY_ContentStatus</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 27</para>
				/// </summary>
				public static PROPERTYKEY ContentStatus
					=> new PROPERTYKEY(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 27);

				/// <summary>
				/// <para>Name:     System.ContentType -- PKEY_ContentType</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 26</para>
				/// </summary>
				public static PROPERTYKEY ContentType
					=> new PROPERTYKEY(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 26);

				/// <summary>
				/// <para>Name:     System.Copyright -- PKEY_Copyright</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 11 (PIDMSI_COPYRIGHT)</para>
				/// </summary>
				public static PROPERTYKEY Copyright
					=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 11);

				/// <summary>
				/// <para>Name:     System.DateAccessed -- PKEY_DateAccessed</para>
				/// <para>Description: The time of the last access to the item. The Indexing Service friendly name is 'access'.</para>
				/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
				/// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 16 (PID_STG_ACCESSTIME)</para>
				/// </summary>
				public static PROPERTYKEY DateAccessed
					=> new PROPERTYKEY(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 16);

				/// <summary>
				/// <para>Name:     System.DateAcquired -- PKEY_DateAcquired</para>
				/// <para>
				/// Description: The time the file entered the system via acquisition. This is not the same as System.DateImported. Examples
				/// are when pictures are acquired from a camera, or when music is purchased online.
				/// </para>
				/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
				/// <para>FormatID: {2CBAA8F5-D81F-47CA-B17A-F8D822300131}, 100</para>
				/// </summary>
				public static PROPERTYKEY DateAcquired
					=> new PROPERTYKEY(new Guid("{2CBAA8F5-D81F-47CA-B17A-F8D822300131}"), 100);

				/// <summary>
				/// <para>Name:     System.DateArchived -- PKEY_DateArchived</para>
				/// <para>Description:</para>
				/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
				/// <para>FormatID: {43F8D7B7-A444-4F87-9383-52271C9B915C}, 100</para>
				/// </summary>
				public static PROPERTYKEY DateArchived
					=> new PROPERTYKEY(new Guid("{43F8D7B7-A444-4F87-9383-52271C9B915C}"), 100);

				/// <summary>
				/// <para>Name:     System.DateCompleted -- PKEY_DateCompleted</para>
				/// <para>Description:</para>
				/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
				/// <para>FormatID: {72FAB781-ACDA-43E5-B155-B2434F85E678}, 100</para>
				/// </summary>
				public static PROPERTYKEY DateCompleted
					=> new PROPERTYKEY(new Guid("{72FAB781-ACDA-43E5-B155-B2434F85E678}"), 100);

				/// <summary>
				/// <para>Name:     System.DateCreated -- PKEY_DateCreated</para>
				/// <para>Description: The date and time the item was created. The Indexing Service friendly name is 'create'.</para>
				/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
				/// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 15 (PID_STG_CREATETIME)</para>
				/// </summary>
				public static PROPERTYKEY DateCreated
					=> new PROPERTYKEY(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 15);

				/// <summary>
				/// <para>Name:     System.DateImported -- PKEY_DateImported</para>
				/// <para>
				/// Description: The time the file is imported into a separate database. This is not the same as System.DateAcquired. (Eg,
				/// 2003:05:22 13:55:04)
				/// </para>
				/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
				/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 18258</para>
				/// </summary>
				public static PROPERTYKEY DateImported
					=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 18258);

				/// <summary>
				/// <para>Name:     System.DateModified -- PKEY_DateModified</para>
				/// <para>Description: The date and time of the last write to the item. The Indexing Service friendly name is 'write'.</para>
				/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
				/// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 14 (PID_STG_WRITETIME)</para>
				/// </summary>
				public static PROPERTYKEY DateModified
					=> new PROPERTYKEY(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 14);

				/// <summary>
				/// <para>Name:     System.DescriptionID -- PKEY_DescriptionID</para>
				/// <para>Description: The contents of a SHDESCRIPTIONID structure as a buffer of bytes.</para>
				/// <para>Type:     Buffer -- VT_VECTOR | VT_UI1 (For variants: VT_ARRAY | VT_UI1)</para>
				/// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 2 (PID_DESCRIPTIONID)</para>
				/// </summary>
				public static PROPERTYKEY DescriptionID
					=> new PROPERTYKEY(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 2);

				/// <summary>
				/// <para>Name:     System.DueDate -- PKEY_DueDate</para>
				/// <para>Description:</para>
				/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
				/// <para>FormatID: {3F8472B5-E0AF-4DB2-8071-C53FE76AE7CE}, 100</para>
				/// </summary>
				public static PROPERTYKEY DueDate
					=> new PROPERTYKEY(new Guid("{3F8472B5-E0AF-4DB2-8071-C53FE76AE7CE}"), 100);

				/// <summary>
				/// <para>Name:     System.EndDate -- PKEY_EndDate</para>
				/// <para>Description:</para>
				/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
				/// <para>FormatID: {C75FAA05-96FD-49E7-9CB4-9F601082D553}, 100</para>
				/// </summary>
				public static PROPERTYKEY EndDate
					=> new PROPERTYKEY(new Guid("{C75FAA05-96FD-49E7-9CB4-9F601082D553}"), 100);

				/// <summary>
				/// <para>Name:     System.FileAllocationSize -- PKEY_FileAllocationSize</para>
				/// <para>Description:</para>
				/// <para>Type:     UInt64 -- VT_UI8</para>
				/// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 18 (PID_STG_ALLOCSIZE)</para>
				/// </summary>
				public static PROPERTYKEY FileAllocationSize
					=> new PROPERTYKEY(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 18);

				/// <summary>
				/// <para>Name:     System.FileAttributes -- PKEY_FileAttributes</para>
				/// <para>Description: This is the WIN32_FIND_DATA dwFileAttributes for the file-based item.</para>
				/// <para>Type:     UInt32 -- VT_UI4</para>
				/// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 13 (PID_STG_ATTRIBUTES)</para>
				/// </summary>
				public static PROPERTYKEY FileAttributes
					=> new PROPERTYKEY(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 13);

				/// <summary>
				/// <para>Name:     System.FileCount -- PKEY_FileCount</para>
				/// <para>Description:</para>
				/// <para>Type:     UInt64 -- VT_UI8</para>
				/// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 12</para>
				/// </summary>
				public static PROPERTYKEY FileCount
					=> new PROPERTYKEY(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 12);

				/// <summary>
				/// <para>Name:     System.FileDescription -- PKEY_FileDescription</para>
				/// <para>Description: This is a user-friendly description of the file.</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (PSFMTID_VERSION) {0CEF7D53-FA64-11D1-A203-0000F81FEDEE}, 3 (PIDVSI_FileDescription)</para>
				/// </summary>
				public static PROPERTYKEY FileDescription
					=> new PROPERTYKEY(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 3);

				/// <summary>
				/// <para>Name:     System.FileExtension -- PKEY_FileExtension</para>
				/// <para>
				/// Description: This is the file extension of the file based item, including the leading period. If System.FileName is
				/// VT_EMPTY, then this property should be too. Otherwise, it should be derived appropriately by the data source from
				/// System.FileName. If System.FileName does not have a file extension, this value should be VT_EMPTY. To obtain the type of
				/// any item (including an item that is not a file), use System.ItemType. Example values: If the path is... The property
				/// value is...
				/// -----------------                     ------------------------ "c:\foo\bar\hello.txt" ".txt"
				/// "\\server\share\mydir\goodnews.doc" ".doc" "\\server\share\numbers.xls" ".xls" "\\server\share\folder" VT_EMPTY
				/// "c:\foo\MyFolder" VT_EMPTY [desktop] VT_EMPTY
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {E4F10A3C-49E6-405D-8288-A23BD4EEAA6C}, 100</para>
				/// </summary>
				public static PROPERTYKEY FileExtension
					=> new PROPERTYKEY(new Guid("{E4F10A3C-49E6-405D-8288-A23BD4EEAA6C}"), 100);

				/// <summary>
				/// <para>Name:     System.FileFRN -- PKEY_FileFRN</para>
				/// <para>
				/// Description: This is the unique file ID, also known as the File Reference Number. For a given file, this is the same
				/// value as is found in the structure variable FILE_ID_BOTH_DIR_INFO.FileId, via GetFileInformationByHandleEx().
				/// </para>
				/// <para>Type:     UInt64 -- VT_UI8</para>
				/// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 21 (PID_STG_FRN)</para>
				/// </summary>
				public static PROPERTYKEY FileFRN
					=> new PROPERTYKEY(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 21);

				/// <summary>
				/// <para>Name:     System.FileName -- PKEY_FileName</para>
				/// <para>
				/// Description: This is the file name (including extension) of the file. It is possible that the item might not exist on a
				/// filesystem (ie, it may not be opened using CreateFile). Nonetheless, if the item is represented as a file from the
				/// logical sense (and its name follows standard Win32 file-naming syntax), then the data source should emit this property.
				/// If an item is not a file, then the value for this property is VT_EMPTY. See System.ItemNameDisplay. This has the same
				/// value as System.ParsingName for items that are provided by the Shell's file folder. Example values: If the path is... The
				/// property value is...
				/// -----------------                     ------------------------ "c:\foo\bar\hello.txt" "hello.txt"
				/// "\\server\share\mydir\goodnews.doc" "goodnews.doc" "\\server\share\numbers.xls" "numbers.xls" "c:\foo\MyFolder"
				/// "MyFolder" (email message) VT_EMPTY (song on portable device) "song.wma"
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {41CF5AE0-F75A-4806-BD87-59C7D9248EB9}, 100</para>
				/// </summary>
				public static PROPERTYKEY FileName
					=> new PROPERTYKEY(new Guid("{41CF5AE0-F75A-4806-BD87-59C7D9248EB9}"), 100);

				/// <summary>
				/// <para>Name:     System.FileOwner -- PKEY_FileOwner</para>
				/// <para>Description: This is the owner of the file, according to the file system.</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (FMTID_Misc) {9B174B34-40FF-11D2-A27E-00C04FC30871}, 4 (PID_MISC_OWNER)</para>
				/// </summary>
				public static PROPERTYKEY FileOwner
					=> new PROPERTYKEY(new Guid("{9B174B34-40FF-11D2-A27E-00C04FC30871}"), 4);

				/// <summary>
				/// <para>Name:     System.FileVersion -- PKEY_FileVersion</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (PSFMTID_VERSION) {0CEF7D53-FA64-11D1-A203-0000F81FEDEE}, 4 (PIDVSI_FileVersion)</para>
				/// </summary>
				public static PROPERTYKEY FileVersion
					=> new PROPERTYKEY(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 4);

				/// <summary>
				/// <para>Name:     System.FindData -- PKEY_FindData</para>
				/// <para>Description: WIN32_FIND_DATAW in buffer of bytes.</para>
				/// <para>Type:     Buffer -- VT_VECTOR | VT_UI1 (For variants: VT_ARRAY | VT_UI1)</para>
				/// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 0 (PID_FINDDATA)</para>
				/// </summary>
				public static PROPERTYKEY FindData
					=> new PROPERTYKEY(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 0);

				/// <summary>
				/// <para>Name:     System.FlagColor -- PKEY_FlagColor</para>
				/// <para>Description:</para>
				/// <para>Type:     UInt16 -- VT_UI2</para>
				/// <para>FormatID: {67DF94DE-0CA7-4D6F-B792-053A3E4F03CF}, 100</para>
				/// </summary>
				public static PROPERTYKEY FlagColor
					=> new PROPERTYKEY(new Guid("{67DF94DE-0CA7-4D6F-B792-053A3E4F03CF}"), 100);

				/// <summary>
				/// <para>Name:     System.FlagColorText -- PKEY_FlagColorText</para>
				/// <para>
				/// Description: This is the user-friendly form of System.FlagColor. Not intended to be parsed programmatically.
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {45EAE747-8E2A-40AE-8CBF-CA52ABA6152A}, 100</para>
				/// </summary>
				public static PROPERTYKEY FlagColorText
					=> new PROPERTYKEY(new Guid("{45EAE747-8E2A-40AE-8CBF-CA52ABA6152A}"), 100);

				/// <summary>
				/// <para>Name:     System.FlagStatus -- PKEY_FlagStatus</para>
				/// <para>Description: Status of Flag. Values: (0=none 1=white 2=Red). cdoPR_FLAG_STATUS</para>
				/// <para>Type:     Int32 -- VT_I4</para>
				/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 12</para>
				/// </summary>
				public static PROPERTYKEY FlagStatus
					=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 12);

				/// <summary>
				/// <para>Name:     System.FlagStatusText -- PKEY_FlagStatusText</para>
				/// <para>
				/// Description: This is the user-friendly form of System.FlagStatus. Not intended to be parsed programmatically.
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {DC54FD2E-189D-4871-AA01-08C2F57A4ABC}, 100</para>
				/// </summary>
				public static PROPERTYKEY FlagStatusText
					=> new PROPERTYKEY(new Guid("{DC54FD2E-189D-4871-AA01-08C2F57A4ABC}"), 100);

				/// <summary>
				/// <para>Name:     System.FreeSpace -- PKEY_FreeSpace</para>
				/// <para>Description: The amount of free space in bytes.</para>
				/// <para>Type:     UInt64 -- VT_UI8</para>
				/// <para>
				/// FormatID: (FMTID_Volume) {9B174B35-40FF-11D2-A27E-00C04FC30871}, 2 (PID_VOLUME_FREE) (Filesystem Volume Properties)
				/// </para>
				/// </summary>
				public static PROPERTYKEY FreeSpace
					=> new PROPERTYKEY(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 2);

				/// <summary>
				/// <para>Name:     System.FullText -- PKEY_FullText</para>
				/// <para>
				/// Description: This PKEY is used to specify search terms that should be applied as broadly as possible, across all valid
				/// properties for the data source(s) being searched. It should not be emitted from a data source.
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {1E3EE840-BC2B-476C-8237-2ACD1A839B22}, 6</para>
				/// </summary>
				public static PROPERTYKEY FullText
					=> new PROPERTYKEY(new Guid("{1E3EE840-BC2B-476C-8237-2ACD1A839B22}"), 6);

				/// <summary>
				/// <para>Name:     System.Identity -- PKEY_Identity</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {A26F4AFC-7346-4299-BE47-EB1AE613139F}, 100</para>
				/// </summary>
				public static PROPERTYKEY IdentityProperty
					=> new PROPERTYKEY(new Guid("{A26F4AFC-7346-4299-BE47-EB1AE613139F}"), 100);

				/// <summary>
				/// <para>Name:     System.ImageParsingName -- PKEY_ImageParsingName</para>
				/// <para>Description:</para>
				/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
				/// <para>FormatID: {D7750EE0-C6A4-48EC-B53E-B87B52E6D073}, 100</para>
				/// </summary>
				public static PROPERTYKEY ImageParsingName
					=> new PROPERTYKEY(new Guid("{D7750EE0-C6A4-48EC-B53E-B87B52E6D073}"), 100);

				/// <summary>
				/// <para>Name:     System.Importance -- PKEY_Importance</para>
				/// <para>Description:</para>
				/// <para>Type:     Int32 -- VT_I4</para>
				/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 11</para>
				/// </summary>
				public static PROPERTYKEY Importance
					=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 11);

				/// <summary>
				/// <para>Name:     System.ImportanceText -- PKEY_ImportanceText</para>
				/// <para>
				/// Description: This is the user-friendly form of System.Importance. Not intended to be parsed programmatically.
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {A3B29791-7713-4E1D-BB40-17DB85F01831}, 100</para>
				/// </summary>
				public static PROPERTYKEY ImportanceText
					=> new PROPERTYKEY(new Guid("{A3B29791-7713-4E1D-BB40-17DB85F01831}"), 100);

				/// <summary>
				/// <para>Name:     System.InfoTipText -- PKEY_InfoTipText</para>
				/// <para>Description: The text (with formatted property values) to show in the infotip.</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 17</para>
				/// </summary>
				public static PROPERTYKEY InfoTipText
					=> new PROPERTYKEY(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 17);

				/// <summary>
				/// <para>Name:     System.InternalName -- PKEY_InternalName</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (PSFMTID_VERSION) {0CEF7D53-FA64-11D1-A203-0000F81FEDEE}, 5 (PIDVSI_InternalName)</para>
				/// </summary>
				public static PROPERTYKEY InternalName
					=> new PROPERTYKEY(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 5);

				/// <summary>
				/// <para>Name:     System.IsAttachment -- PKEY_IsAttachment</para>
				/// <para>Description: Identifies if this item is an attachment.</para>
				/// <para>Type:     Boolean -- VT_BOOL</para>
				/// <para>FormatID: {F23F425C-71A1-4FA8-922F-678EA4A60408}, 100</para>
				/// </summary>
				public static PROPERTYKEY IsAttachment
					=> new PROPERTYKEY(new Guid("{F23F425C-71A1-4FA8-922F-678EA4A60408}"), 100);

				/// <summary>
				/// <para>Name:     System.IsDefaultNonOwnerSaveLocation -- PKEY_IsDefaultNonOwnerSaveLocation</para>
				/// <para>Description: Identifies the default save location for a library for non-owners of the library</para>
				/// <para>Type:     Boolean -- VT_BOOL</para>
				/// <para>FormatID: {5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}, 5</para>
				/// </summary>
				public static PROPERTYKEY IsDefaultNonOwnerSaveLocation
					=> new PROPERTYKEY(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 5);

				/// <summary>
				/// <para>Name:     System.IsDefaultSaveLocation -- PKEY_IsDefaultSaveLocation</para>
				/// <para>Description: Identifies the default save location for a library for the owner of the library</para>
				/// <para>Type:     Boolean -- VT_BOOL</para>
				/// <para>FormatID: {5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}, 3</para>
				/// </summary>
				public static PROPERTYKEY IsDefaultSaveLocation
					=> new PROPERTYKEY(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 3);

				/// <summary>
				/// <para>Name:     System.IsDeleted -- PKEY_IsDeleted</para>
				/// <para>Description:</para>
				/// <para>Type:     Boolean -- VT_BOOL</para>
				/// <para>FormatID: {5CDA5FC8-33EE-4FF3-9094-AE7BD8868C4D}, 100</para>
				/// </summary>
				public static PROPERTYKEY IsDeleted
					=> new PROPERTYKEY(new Guid("{5CDA5FC8-33EE-4FF3-9094-AE7BD8868C4D}"), 100);

				/// <summary>
				/// <para>Name:     System.IsEncrypted -- PKEY_IsEncrypted</para>
				/// <para>Description: Is the item encrypted?</para>
				/// <para>Type:     Boolean -- VT_BOOL</para>
				/// <para>FormatID: {90E5E14E-648B-4826-B2AA-ACAF790E3513}, 10</para>
				/// </summary>
				public static PROPERTYKEY IsEncrypted
					=> new PROPERTYKEY(new Guid("{90E5E14E-648B-4826-B2AA-ACAF790E3513}"), 10);

				/// <summary>
				/// <para>Name:     System.IsFlagged -- PKEY_IsFlagged</para>
				/// <para>Description:</para>
				/// <para>Type:     Boolean -- VT_BOOL</para>
				/// <para>FormatID: {5DA84765-E3FF-4278-86B0-A27967FBDD03}, 100</para>
				/// </summary>
				public static PROPERTYKEY IsFlagged
					=> new PROPERTYKEY(new Guid("{5DA84765-E3FF-4278-86B0-A27967FBDD03}"), 100);

				/// <summary>
				/// <para>Name:     System.IsFlaggedComplete -- PKEY_IsFlaggedComplete</para>
				/// <para>Description:</para>
				/// <para>Type:     Boolean -- VT_BOOL</para>
				/// <para>FormatID: {A6F360D2-55F9-48DE-B909-620E090A647C}, 100</para>
				/// </summary>
				public static PROPERTYKEY IsFlaggedComplete
					=> new PROPERTYKEY(new Guid("{A6F360D2-55F9-48DE-B909-620E090A647C}"), 100);

				/// <summary>
				/// <para>Name:     System.IsIncomplete -- PKEY_IsIncomplete</para>
				/// <para>Description: Identifies if the message was not completely received for some error condition.</para>
				/// <para>Type:     Boolean -- VT_BOOL</para>
				/// <para>FormatID: {346C8BD1-2E6A-4C45-89A4-61B78E8E700F}, 100</para>
				/// </summary>
				public static PROPERTYKEY IsIncomplete
					=> new PROPERTYKEY(new Guid("{346C8BD1-2E6A-4C45-89A4-61B78E8E700F}"), 100);

				/// <summary>
				/// <para>Name:     System.IsLocationSupported -- PKEY_IsLocationSupported</para>
				/// <para>Description: A bool value to know if a location is supported (locally indexable, or remotely indexed).</para>
				/// <para>Type:     Boolean -- VT_BOOL</para>
				/// <para>FormatID: {5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}, 8</para>
				/// </summary>
				public static PROPERTYKEY IsLocationSupported
					=> new PROPERTYKEY(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 8);

				/// <summary>
				/// <para>Name:     System.IsPinnedToNameSpaceTree -- PKEY_IsPinnedToNameSpaceTree</para>
				/// <para>Description: A bool value to know if a shell folder is pinned to the navigation pane</para>
				/// <para>Type:     Boolean -- VT_BOOL</para>
				/// <para>FormatID: {5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}, 2</para>
				/// </summary>
				public static PROPERTYKEY IsPinnedToNameSpaceTree
					=> new PROPERTYKEY(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 2);

				/// <summary>
				/// <para>Name:     System.IsRead -- PKEY_IsRead</para>
				/// <para>Description: Has the item been read?</para>
				/// <para>Type:     Boolean -- VT_BOOL</para>
				/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 10</para>
				/// </summary>
				public static PROPERTYKEY IsRead
					=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 10);

				/// <summary>
				/// <para>Name:     System.IsSearchOnlyItem -- PKEY_IsSearchOnlyItem</para>
				/// <para>Description: Identifies if a location or a library is search only</para>
				/// <para>Type:     Boolean -- VT_BOOL</para>
				/// <para>FormatID: {5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}, 4</para>
				/// </summary>
				public static PROPERTYKEY IsSearchOnlyItem
					=> new PROPERTYKEY(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 4);

				/// <summary>
				/// <para>Name:     System.IsSendToTarget -- PKEY_IsSendToTarget</para>
				/// <para>Description: Provided by certain shell folders. Return TRUE if the folder is a valid Send To target.</para>
				/// <para>Type:     Boolean -- VT_BOOL</para>
				/// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 33</para>
				/// </summary>
				public static PROPERTYKEY IsSendToTarget
					=> new PROPERTYKEY(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 33);

				/// <summary>
				/// <para>Name:     System.IsShared -- PKEY_IsShared</para>
				/// <para>Description: Is this item shared? This only checks for ACLs that are not inherited.</para>
				/// <para>Type:     Boolean -- VT_BOOL</para>
				/// <para>FormatID: {EF884C5B-2BFE-41BB-AAE5-76EEDF4F9902}, 100</para>
				/// </summary>
				public static PROPERTYKEY IsShared
					=> new PROPERTYKEY(new Guid("{EF884C5B-2BFE-41BB-AAE5-76EEDF4F9902}"), 100);

				/// <summary>
				/// <para>Name:     System.ItemAuthors -- PKEY_ItemAuthors</para>
				/// <para>
				/// Description: This is the generic list of authors associated with an item. For example, the artist name for a track is the
				/// item author.
				/// </para>
				/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
				/// <para>FormatID: {D0A04F0A-462A-48A4-BB2F-3706E88DBD7D}, 100</para>
				/// </summary>
				public static PROPERTYKEY ItemAuthors
					=> new PROPERTYKEY(new Guid("{D0A04F0A-462A-48A4-BB2F-3706E88DBD7D}"), 100);

				/// <summary>
				/// <para>Name:     System.ItemClassType -- PKEY_ItemClassType</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {048658AD-2DB8-41A4-BBB6-AC1EF1207EB1}, 100</para>
				/// </summary>
				public static PROPERTYKEY ItemClassType
					=> new PROPERTYKEY(new Guid("{048658AD-2DB8-41A4-BBB6-AC1EF1207EB1}"), 100);

				/// <summary>
				/// <para>Name:     System.ItemDate -- PKEY_ItemDate</para>
				/// <para>
				/// Description: This is the main date for an item. The date of interest. For example, for photos this maps to System.Photo.DateTaken.
				/// </para>
				/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
				/// <para>FormatID: {F7DB74B4-4287-4103-AFBA-F1B13DCD75CF}, 100</para>
				/// </summary>
				public static PROPERTYKEY ItemDate
					=> new PROPERTYKEY(new Guid("{F7DB74B4-4287-4103-AFBA-F1B13DCD75CF}"), 100);

				/// <summary>
				/// <para>Name:     System.ItemFolderNameDisplay -- PKEY_ItemFolderNameDisplay</para>
				/// <para>
				/// Description: This is the user-friendly display name of the parent folder of an item. If System.ItemFolderPathDisplay is
				/// VT_EMPTY, then this property should be too. Otherwise, it should be derived appropriately by the data source from
				/// System.ItemFolderPathDisplay. If the folder is a file folder, the value will be localized if a localized name is
				/// available. Example values: If the path is... The property value is...
				/// -----------------                     ------------------------ "c:\foo\bar\hello.txt" "bar"
				/// "\\server\share\mydir\goodnews.doc" "mydir" "\\server\share\numbers.xls" "share" "c:\foo\MyFolder" "foo" "/Mailbox
				/// Account/Inbox/'Re: Hello!'" "Inbox"
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 2 (PID_STG_DIRECTORY)</para>
				/// </summary>
				public static PROPERTYKEY ItemFolderNameDisplay
					=> new PROPERTYKEY(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 2);

				/// <summary>
				/// <para>Name:     System.ItemFolderPathDisplay -- PKEY_ItemFolderPathDisplay</para>
				/// <para>
				/// Description: This is the user-friendly display path of the parent folder of an item. If System.ItemPathDisplay is
				/// VT_EMPTY, then this property should be too. Otherwise, it should be derived appropriately by the data source from
				/// System.ItemPathDisplay. Example values: If the path is... The property value is...
				/// -----------------                     ------------------------ "c:\foo\bar\hello.txt" "c:\foo\bar"
				/// "\\server\share\mydir\goodnews.doc" "\\server\share\mydir" "\\server\share\numbers.xls" "\\server\share"
				/// "c:\foo\MyFolder" "c:\foo" "/Mailbox Account/Inbox/'Re: Hello!'" "/Mailbox Account/Inbox"
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 6</para>
				/// </summary>
				public static PROPERTYKEY ItemFolderPathDisplay
					=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 6);

				/// <summary>
				/// <para>Name:     System.ItemFolderPathDisplayNarrow -- PKEY_ItemFolderPathDisplayNarrow</para>
				/// <para>
				/// Description: This is the user-friendly display path of the parent folder of an item. The format of the string should be
				/// tailored such that the folder name comes first, to optimize for a narrow viewing column. If the folder is a file folder,
				/// the value includes localized names if they are present. If System.ItemFolderPathDisplay is VT_EMPTY, then this property
				/// should be too. Otherwise, it should be derived appropriately by the data source from System.ItemFolderPathDisplay.
				/// Example values: If the path is... The property value is...
				/// -----------------                     ------------------------ "c:\foo\bar\hello.txt" "bar (c:\foo)"
				/// "\\server\share\mydir\goodnews.doc" "mydir (\\server\share)" "\\server\share\numbers.xls" "share (\\server)"
				/// "c:\foo\MyFolder" "foo (c:\)" "/Mailbox Account/Inbox/'Re: Hello!'" "Inbox (/Mailbox Account)"
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {DABD30ED-0043-4789-A7F8-D013A4736622}, 100</para>
				/// </summary>
				public static PROPERTYKEY ItemFolderPathDisplayNarrow
					=> new PROPERTYKEY(new Guid("{DABD30ED-0043-4789-A7F8-D013A4736622}"), 100);

				/// <summary>
				/// <para>Name:     System.ItemName -- PKEY_ItemName</para>
				/// <para>
				/// Description: This is the base-name of the System.ItemNameDisplay. If the item is a file this property includes the
				/// extension in all cases, and will be localized if a localized name is available. If the item is a message, then the value
				/// of this property does not include the forwarding or reply prefixes (see System.ItemNamePrefix).
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {6B8DA074-3B5C-43BC-886F-0A2CDCE00B6F}, 100</para>
				/// </summary>
				public static PROPERTYKEY ItemName
					=> new PROPERTYKEY(new Guid("{6B8DA074-3B5C-43BC-886F-0A2CDCE00B6F}"), 100);

				/// <summary>
				/// <para>Name:     System.ItemNameDisplay -- PKEY_ItemNameDisplay</para>
				/// <para>
				/// Description: This is the display name in "most complete" form. This is the best effort unique representation of the name
				/// of an item that makes sense for end users to read. It is the concatentation of System.ItemNamePrefix and System.ItemName.
				/// If the item is a file this property includes the extension in all cases, and will be localized if a localized name is
				/// available. There are acceptable cases when System.FileName is not VT_EMPTY, yet the value of this property is completely
				/// different. Email messages are a key example. If the item is an email message, the item name is likely the subject. In
				/// that case, the value must be the concatenation of the System.ItemNamePrefix and System.ItemName. Since the value of
				/// System.ItemNamePrefix excludes any trailing whitespace, the concatenation must include a whitespace when generating
				/// System.ItemNameDisplay. Note that this property is not guaranteed to be unique, but the idea is to promote the most
				/// likely candidate that can be unique and also makes sense for end users. For example, for documents, you might think about
				/// using System.Title as the System.ItemNameDisplay, but in practice the title of the documents may not be useful or unique
				/// enough to be of value as the sole System.ItemNameDisplay. Instead, providing the value of System.FileName as the value of
				/// System.ItemNameDisplay is a better candidate. In Windows Mail, the emails are stored in the file system as .eml files and
				/// the System.FileName for those files are not human-friendly as they contain GUIDs. In this example, promoting
				/// System.Subject as System.ItemNameDisplay makes more sense. Compatibility notes: Shell folder implementations on Vista:
				/// use PKEY_ItemNameDisplay for the name column when you want Explorer to call ISF::GetDisplayNameOf(SHGDN_NORMAL) to get
				/// the value of the name. Use another PKEY (like PKEY_ItemName) when you want Explorer to call either the folder's property
				/// store or ISF2::GetDetailsEx in order to get the value of the name. Shell folder implementations on XP: the first column
				/// needs to be the name column, and Explorer will call ISF::GetDisplayNameOf to get the value of the name. The PKEY/SCID
				/// does not matter. Example values:
				/// File:          "hello.txt"
				/// Message:       "Re: Let's talk about Tom's argyle socks!" Device folder: "song.wma"
				/// Folder:        "Documents"
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 10 (PID_STG_NAME)</para>
				/// </summary>
				public static PROPERTYKEY ItemNameDisplay
					=> new PROPERTYKEY(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 10);

				/// <summary>
				/// <para>Name:     System.ItemNamePrefix -- PKEY_ItemNamePrefix</para>
				/// <para>
				/// Description: This is the prefix of an item, used for email messages. where the subject begins with "Re:" which is the
				/// prefix. If the item is a file, then the value of this property is VT_EMPTY. If the item is a message, then the value of
				/// this property is the forwarding or reply prefixes (including delimiting colon, but no whitespace), or VT_EMPTY if there
				/// is no prefix. Example values: System.ItemNamePrefix System.ItemName System.ItemNameDisplay
				/// ---------------------    ------------------- ---------------------- VT_EMPTY "Great day" "Great day" "Re:" "Great day"
				/// "Re: Great day" "Fwd: " "Monthly budget" "Fwd: Monthly budget" VT_EMPTY "accounts.xls" "accounts.xls"
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {D7313FF1-A77A-401C-8C99-3DBDD68ADD36}, 100</para>
				/// </summary>
				public static PROPERTYKEY ItemNamePrefix
					=> new PROPERTYKEY(new Guid("{D7313FF1-A77A-401C-8C99-3DBDD68ADD36}"), 100);

				/// <summary>
				/// <para>Name:     System.ItemParticipants -- PKEY_ItemParticipants</para>
				/// <para>
				/// Description: This is the generic list of people associated with an item and who contributed to the item. For example,
				/// this is the combination of people in the To list, Cc list and sender of an email message.
				/// </para>
				/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
				/// <para>FormatID: {D4D0AA16-9948-41A4-AA85-D97FF9646993}, 100</para>
				/// </summary>
				public static PROPERTYKEY ItemParticipants
					=> new PROPERTYKEY(new Guid("{D4D0AA16-9948-41A4-AA85-D97FF9646993}"), 100);

				/// <summary>
				/// <para>Name:     System.ItemPathDisplay -- PKEY_ItemPathDisplay</para>
				/// <para>
				/// Description: This is the user-friendly display path to the item. If the item is a file or folder this property includes
				/// the extension in all cases, and will be localized if a localized name is available. For other items,this is the
				/// user-friendly equivalent, assuming the item exists in hierarchical storage. Unlike System.ItemUrl, this property value
				/// does not include the URL scheme. To parse an item path, use System.ItemUrl or System.ParsingPath. To reference shell
				/// namespace items using shell APIs, use System.ParsingPath. Example values: If the path is... The property value is...
				/// -----------------                     ------------------------ "c:\foo\bar\hello.txt" "c:\foo\bar\hello.txt"
				/// "\\server\share\mydir\goodnews.doc" "\\server\share\mydir\goodnews.doc" "\\server\share\numbers.xls"
				/// "\\server\share\numbers.xls" "c:\foo\MyFolder" "c:\foo\MyFolder" "/Mailbox Account/Inbox/'Re: Hello!'" "/Mailbox
				/// Account/Inbox/'Re: Hello!'"
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 7</para>
				/// </summary>
				public static PROPERTYKEY ItemPathDisplay
					=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 7);

				/// <summary>
				/// <para>Name:     System.ItemPathDisplayNarrow -- PKEY_ItemPathDisplayNarrow</para>
				/// <para>
				/// Description: This is the user-friendly display path to the item. The format of the string should be tailored such that
				/// the name comes first, to optimize for a narrow viewing column. If the item is a file, the value excludes the file
				/// extension, and includes localized names if they are present. If the item is a message, the value includes the
				/// System.ItemNamePrefix. To parse an item path, use System.ItemUrl or System.ParsingPath. Example values: If the path is...
				/// The property value is...
				/// -----------------                     ------------------------ "c:\foo\bar\hello.txt" "hello (c:\foo\bar)"
				/// "\\server\share\mydir\goodnews.doc" "goodnews (\\server\share\mydir)" "\\server\share\folder" "folder (\\server\share)"
				/// "c:\foo\MyFolder" "MyFolder (c:\foo)" "/Mailbox Account/Inbox/'Re: Hello!'" "Re: Hello! (/Mailbox Account/Inbox)"
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 8</para>
				/// </summary>
				public static PROPERTYKEY ItemPathDisplayNarrow
					=> new PROPERTYKEY(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 8);

				/// <summary>
				/// <para>Name:     System.ItemType -- PKEY_ItemType</para>
				/// <para>
				/// Description: This is the canonical type of the item and is intended to be programmatically parsed. If there is no
				/// canonical type, the value is VT_EMPTY. If the item is a file (ie, System.FileName is not VT_EMPTY), the value is the same
				/// as System.FileExtension. Use System.ItemTypeText when you want to display the type to end users in a view. (If the item
				/// is a file, passing the System.ItemType value to PSFormatForDisplay will result in the same value as System.ItemTypeText.)
				/// Example values: If the path is... The property value is...
				/// -----------------                     ------------------------ "c:\foo\bar\hello.txt" ".txt"
				/// "\\server\share\mydir\goodnews.doc" ".doc" "\\server\share\folder" "Directory" "c:\foo\MyFolder" "Directory" [desktop]
				/// "Folder" "/Mailbox Account/Inbox/'Re: Hello!'" "MAPI/IPM.Message"
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 11</para>
				/// </summary>
				public static PROPERTYKEY ItemType
					=> new PROPERTYKEY(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 11);

				/// <summary>
				/// <para>Name:     System.ItemTypeText -- PKEY_ItemTypeText</para>
				/// <para>
				/// Description: This is the user friendly type name of the item. This is not intended to be programmatically parsed. If
				/// System.ItemType is VT_EMPTY, the value of this property is also VT_EMPTY. If the item is a file, the value of this
				/// property is the same as if you passed the file's System.ItemType value to PSFormatForDisplay. This property should not be
				/// confused with System.Kind, where System.Kind is a high-level user friendly kind name. For example, for a document,
				/// System.Kind = "Document" and System.Item.Type = ".doc" and System.Item.TypeText = "Microsoft Word Document" Example
				/// values: If the path is... The property value is...
				/// -----------------                     ------------------------ "c:\foo\bar\hello.txt" "Text File"
				/// "\\server\share\mydir\goodnews.doc" "Microsoft Word Document" "\\server\share\folder" "File Folder" "c:\foo\MyFolder"
				/// "File Folder" "/Mailbox Account/Inbox/'Re: Hello!'" "Outlook E-Mail Message"
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 4 (PID_STG_STORAGETYPE)</para>
				/// </summary>
				public static PROPERTYKEY ItemTypeText
					=> new PROPERTYKEY(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 4);

				/// <summary>
				/// <para>Name:     System.ItemUrl -- PKEY_ItemUrl</para>
				/// <para>
				/// Description: This always represents a well formed URL that points to the item. To reference shell namespace items using
				/// shell APIs, use System.ParsingPath. Example values:
				/// Files:    "file:///c:/foo/bar/hello.txt" "csc://{GUID}/..."
				/// Messages: "mapi://..."
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (FMTID_Query) {49691C90-7E17-101A-A91C-08002B2ECDA9}, 9 (DISPID_QUERY_VIRTUALPATH)</para>
				/// </summary>
				public static PROPERTYKEY ItemUrl
					=> new PROPERTYKEY(new Guid("{49691C90-7E17-101A-A91C-08002B2ECDA9}"), 9);

				/// <summary>
				/// <para>Name:     System.Keywords -- PKEY_Keywords</para>
				/// <para>Description: The keywords for the item. Also referred to as tags.</para>
				/// <para>
				/// Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR) Legacy code may treat this as VT_LPSTR.
				/// </para>
				/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 5 (PIDSI_KEYWORDS)</para>
				/// </summary>
				public static PROPERTYKEY Keywords
					=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 5);

				/// <summary>
				/// <para>Name:     System.Kind -- PKEY_Kind</para>
				/// <para>
				/// Description: System.Kind is used to map extensions to various .Search folders. Extensions are mapped to Kinds at
				/// HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Explorer\KindMap The list of kinds is not extensible.
				/// </para>
				/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
				/// <para>FormatID: {1E3EE840-BC2B-476C-8237-2ACD1A839B22}, 3</para>
				/// </summary>
				public static PROPERTYKEY Kind
					=> new PROPERTYKEY(new Guid("{1E3EE840-BC2B-476C-8237-2ACD1A839B22}"), 3);

				/// <summary>
				/// <para>Name:     System.KindText -- PKEY_KindText</para>
				/// <para>
				/// Description: This is the user-friendly form of System.Kind. Not intended to be parsed programmatically.
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {F04BEF95-C585-4197-A2B7-DF46FDC9EE6D}, 100</para>
				/// </summary>
				public static PROPERTYKEY KindText
					=> new PROPERTYKEY(new Guid("{F04BEF95-C585-4197-A2B7-DF46FDC9EE6D}"), 100);

				/// <summary>
				/// <para>Name:     System.Language -- PKEY_Language</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 28</para>
				/// </summary>
				public static PROPERTYKEY Language
					=> new PROPERTYKEY(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 28);

				/// <summary>
				/// <para>Name:     System.MileageInformation -- PKEY_MileageInformation</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {FDF84370-031A-4ADD-9E91-0D775F1C6605}, 100</para>
				/// </summary>
				public static PROPERTYKEY MileageInformation
					=> new PROPERTYKEY(new Guid("{FDF84370-031A-4ADD-9E91-0D775F1C6605}"), 100);

				/// <summary>
				/// <para>Name:     System.MIMEType -- PKEY_MIMEType</para>
				/// <para>Description: The MIME type. Eg, for EML files: 'message/rfc822'.</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {0B63E350-9CCC-11D0-BCDB-00805FCCCE04}, 5</para>
				/// </summary>
				public static PROPERTYKEY MIMEType
					=> new PROPERTYKEY(new Guid("{0B63E350-9CCC-11D0-BCDB-00805FCCCE04}"), 5);

				/// <summary>
				/// <para>Name:     System.NamespaceCLSID -- PKEY_NamespaceCLSID</para>
				/// <para>
				/// Description: The CLSID of the name space extension for an item, the object that implements IShellFolder for this item
				/// </para>
				/// <para>Type:     Guid -- VT_CLSID</para>
				/// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 6</para>
				/// </summary>
				public static PROPERTYKEY NamespaceCLSID
					=> new PROPERTYKEY(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 6);

				/// <summary>
				/// <para>Name:     System.Null -- PKEY_Null</para>
				/// <para>Description:</para>
				/// <para>Type:     Null -- VT_NULL</para>
				/// <para>FormatID: {00000000-0000-0000-0000-000000000000}, 0</para>
				/// </summary>
				public static PROPERTYKEY Null
					=> new PROPERTYKEY(new Guid("{00000000-0000-0000-0000-000000000000}"), 0);

				/// <summary>
				/// <para>Name:     System.OfflineAvailability -- PKEY_OfflineAvailability</para>
				/// <para>Description:</para>
				/// <para>Type:     UInt32 -- VT_UI4</para>
				/// <para>FormatID: {A94688B6-7D9F-4570-A648-E3DFC0AB2B3F}, 100</para>
				/// </summary>
				public static PROPERTYKEY OfflineAvailability
					=> new PROPERTYKEY(new Guid("{A94688B6-7D9F-4570-A648-E3DFC0AB2B3F}"), 100);

				/// <summary>
				/// <para>Name:     System.OfflineStatus -- PKEY_OfflineStatus</para>
				/// <para>Description:</para>
				/// <para>Type:     UInt32 -- VT_UI4</para>
				/// <para>FormatID: {6D24888F-4718-4BDA-AFED-EA0FB4386CD8}, 100</para>
				/// </summary>
				public static PROPERTYKEY OfflineStatus
					=> new PROPERTYKEY(new Guid("{6D24888F-4718-4BDA-AFED-EA0FB4386CD8}"), 100);

				/// <summary>
				/// <para>Name:     System.OriginalFileName -- PKEY_OriginalFileName</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (PSFMTID_VERSION) {0CEF7D53-FA64-11D1-A203-0000F81FEDEE}, 6</para>
				/// </summary>
				public static PROPERTYKEY OriginalFileName
					=> new PROPERTYKEY(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 6);

				/// <summary>
				/// <para>Name:     System.OwnerSID -- PKEY_OwnerSID</para>
				/// <para>Description: SID of the user that owns the library.</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}, 6</para>
				/// </summary>
				public static PROPERTYKEY OwnerSID
					=> new PROPERTYKEY(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 6);

				/// <summary>
				/// <para>Name:     System.ParentalRating -- PKEY_ParentalRating</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>
				/// FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 21 (PIDMSI_PARENTAL_RATING)
				/// </para>
				/// </summary>
				public static PROPERTYKEY ParentalRating
					=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 21);

				/// <summary>
				/// <para>Name:     System.ParentalRatingReason -- PKEY_ParentalRatingReason</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {10984E0A-F9F2-4321-B7EF-BAF195AF4319}, 100</para>
				/// </summary>
				public static PROPERTYKEY ParentalRatingReason
					=> new PROPERTYKEY(new Guid("{10984E0A-F9F2-4321-B7EF-BAF195AF4319}"), 100);

				/// <summary>
				/// <para>Name:     System.ParentalRatingsOrganization -- PKEY_ParentalRatingsOrganization</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {A7FE0840-1344-46F0-8D37-52ED712A4BF9}, 100</para>
				/// </summary>
				public static PROPERTYKEY ParentalRatingsOrganization
					=> new PROPERTYKEY(new Guid("{A7FE0840-1344-46F0-8D37-52ED712A4BF9}"), 100);

				/// <summary>
				/// <para>Name:     System.ParsingBindContext -- PKEY_ParsingBindContext</para>
				/// <para>Description: used to get the IBindCtx for an item for parsing</para>
				/// <para>Type:     Any -- VT_NULL Legacy code may treat this as VT_UNKNOWN.</para>
				/// <para>FormatID: {DFB9A04D-362F-4CA3-B30B-0254B17B5B84}, 100</para>
				/// </summary>
				public static PROPERTYKEY ParsingBindContext
					=> new PROPERTYKEY(new Guid("{DFB9A04D-362F-4CA3-B30B-0254B17B5B84}"), 100);

				/// <summary>
				/// <para>Name:     System.ParsingName -- PKEY_ParsingName</para>
				/// <para>
				/// Description: The shell namespace name of an item relative to a parent folder. This name may be passed to
				/// IShellFolder::ParseDisplayName() of the parent shell folder.
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 24</para>
				/// </summary>
				public static PROPERTYKEY ParsingName
					=> new PROPERTYKEY(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 24);

				/// <summary>
				/// <para>Name:     System.ParsingPath -- PKEY_ParsingPath</para>
				/// <para>
				/// Description: This is the shell namespace path to the item. This path may be passed to SHParseDisplayName to parse the
				/// path to the correct shell folder. If the item is a file, the value is identical to System.ItemPathDisplay. If the item
				/// cannot be accessed through the shell namespace, this value is VT_EMPTY.
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 30</para>
				/// </summary>
				public static PROPERTYKEY ParsingPath
					=> new PROPERTYKEY(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 30);

				/// <summary>
				/// <para>Name:     System.PerceivedType -- PKEY_PerceivedType</para>
				/// <para>Description: The perceived type of a shell item, based upon its canonical type.</para>
				/// <para>Type:     Int32 -- VT_I4</para>
				/// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 9</para>
				/// </summary>
				public static PROPERTYKEY PerceivedType
					=> new PROPERTYKEY(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 9);

				/// <summary>
				/// <para>Name:     System.PercentFull -- PKEY_PercentFull</para>
				/// <para>Description: The amount filled as a percentage, multiplied by 100 (ie, the valid range is 0 through 100).</para>
				/// <para>Type:     UInt32 -- VT_UI4</para>
				/// <para>FormatID: (FMTID_Volume) {9B174B35-40FF-11D2-A27E-00C04FC30871}, 5 (Filesystem Volume Properties)</para>
				/// </summary>
				public static PROPERTYKEY PercentFull
					=> new PROPERTYKEY(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 5);

				/// <summary>
				/// <para>Name:     System.Priority -- PKEY_Priority</para>
				/// <para>Description:</para>
				/// <para>Type:     UInt16 -- VT_UI2</para>
				/// <para>FormatID: {9C1FCF74-2D97-41BA-B4AE-CB2E3661A6E4}, 5</para>
				/// </summary>
				public static PROPERTYKEY Priority
					=> new PROPERTYKEY(new Guid("{9C1FCF74-2D97-41BA-B4AE-CB2E3661A6E4}"), 5);

				/// <summary>
				/// <para>Name:     System.PriorityText -- PKEY_PriorityText</para>
				/// <para>
				/// Description: This is the user-friendly form of System.Priority. Not intended to be parsed programmatically.
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {D98BE98B-B86B-4095-BF52-9D23B2E0A752}, 100</para>
				/// </summary>
				public static PROPERTYKEY PriorityText
					=> new PROPERTYKEY(new Guid("{D98BE98B-B86B-4095-BF52-9D23B2E0A752}"), 100);

				/// <summary>
				/// <para>Name:     System.Project -- PKEY_Project</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {39A7F922-477C-48DE-8BC8-B28441E342E3}, 100</para>
				/// </summary>
				public static PROPERTYKEY Project
					=> new PROPERTYKEY(new Guid("{39A7F922-477C-48DE-8BC8-B28441E342E3}"), 100);

				/// <summary>
				/// <para>Name:     System.ProviderItemID -- PKEY_ProviderItemID</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {F21D9941-81F0-471A-ADEE-4E74B49217ED}, 100</para>
				/// </summary>
				public static PROPERTYKEY ProviderItemID
					=> new PROPERTYKEY(new Guid("{F21D9941-81F0-471A-ADEE-4E74B49217ED}"), 100);

				/// <summary>
				/// <para>Name:     System.Rating -- PKEY_Rating</para>
				/// <para>
				/// Description: Indicates the users preference rating of an item on a scale of 1-99 (1-12 = One Star, 13-37 = Two Stars,
				/// 38-62 = Three Stars, 63-87 = Four Stars, 88-99 = Five Stars).
				/// </para>
				/// <para>Type:     UInt32 -- VT_UI4</para>
				/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 9 (PIDMSI_RATING)</para>
				/// </summary>
				public static PROPERTYKEY Rating
					=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 9);

				/// <summary>
				/// <para>Name:     System.RatingText -- PKEY_RatingText</para>
				/// <para>
				/// Description: This is the user-friendly form of System.Rating. Not intended to be parsed programmatically.
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {90197CA7-FD8F-4E8C-9DA3-B57E1E609295}, 100</para>
				/// </summary>
				public static PROPERTYKEY RatingText
					=> new PROPERTYKEY(new Guid("{90197CA7-FD8F-4E8C-9DA3-B57E1E609295}"), 100);

				/// <summary>
				/// <para>Name:     System.Sensitivity -- PKEY_Sensitivity</para>
				/// <para>Description:</para>
				/// <para>Type:     UInt16 -- VT_UI2</para>
				/// <para>FormatID: {F8D3F6AC-4874-42CB-BE59-AB454B30716A}, 100</para>
				/// </summary>
				public static PROPERTYKEY Sensitivity
					=> new PROPERTYKEY(new Guid("{F8D3F6AC-4874-42CB-BE59-AB454B30716A}"), 100);

				/// <summary>
				/// <para>Name:     System.SensitivityText -- PKEY_SensitivityText</para>
				/// <para>
				/// Description: This is the user-friendly form of System.Sensitivity. Not intended to be parsed programmatically.
				/// </para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {D0C7F054-3F72-4725-8527-129A577CB269}, 100</para>
				/// </summary>
				public static PROPERTYKEY SensitivityText
					=> new PROPERTYKEY(new Guid("{D0C7F054-3F72-4725-8527-129A577CB269}"), 100);

				/// <summary>
				/// <para>Name:     System.SFGAOFlags -- PKEY_SFGAOFlags</para>
				/// <para>Description: IShellFolder::GetAttributesOf flags, with SFGAO_PKEYSFGAOMASK attributes masked out.</para>
				/// <para>Type:     UInt32 -- VT_UI4</para>
				/// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 25</para>
				/// </summary>
				public static PROPERTYKEY SFGAOFlags
					=> new PROPERTYKEY(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 25);

				/// <summary>
				/// <para>Name:     System.SharedWith -- PKEY_SharedWith</para>
				/// <para>Description: Who is the item shared with?</para>
				/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
				/// <para>FormatID: {EF884C5B-2BFE-41BB-AAE5-76EEDF4F9902}, 200</para>
				/// </summary>
				public static PROPERTYKEY SharedWith
					=> new PROPERTYKEY(new Guid("{EF884C5B-2BFE-41BB-AAE5-76EEDF4F9902}"), 200);

				/// <summary>
				/// <para>Name:     System.ShareUserRating -- PKEY_ShareUserRating</para>
				/// <para>Description:</para>
				/// <para>Type:     UInt32 -- VT_UI4</para>
				/// <para>
				/// FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 12 (PIDMSI_SHARE_USER_RATING)
				/// </para>
				/// </summary>
				public static PROPERTYKEY ShareUserRating
					=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 12);

				/// <summary>
				/// <para>Name:     System.SharingStatus -- PKEY_SharingStatus</para>
				/// <para>Description: What is the item's sharing status (not shared, shared, everyone (homegroup or everyone), or private)?</para>
				/// <para>Type:     UInt32 -- VT_UI4</para>
				/// <para>FormatID: {EF884C5B-2BFE-41BB-AAE5-76EEDF4F9902}, 300</para>
				/// </summary>
				public static PROPERTYKEY SharingStatus
					=> new PROPERTYKEY(new Guid("{EF884C5B-2BFE-41BB-AAE5-76EEDF4F9902}"), 300);

				/// <summary>
				/// <para>Name:     System.SimpleRating -- PKEY_SimpleRating</para>
				/// <para>
				/// Description: Indicates the users preference rating of an item on a scale of 0-5 (0=unrated, 1=One Star, 2=Two Stars,
				/// 3=Three Stars, 4=Four Stars, 5=Five Stars)
				/// </para>
				/// <para>Type:     UInt32 -- VT_UI4</para>
				/// <para>FormatID: {A09F084E-AD41-489F-8076-AA5BE3082BCA}, 100</para>
				/// </summary>
				public static PROPERTYKEY SimpleRating
					=> new PROPERTYKEY(new Guid("{A09F084E-AD41-489F-8076-AA5BE3082BCA}"), 100);

				/// <summary>
				/// <para>Name:     System.Size -- PKEY_Size</para>
				/// <para>Description:</para>
				/// <para>Type:     UInt64 -- VT_UI8</para>
				/// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 12 (PID_STG_SIZE)</para>
				/// </summary>
				public static PROPERTYKEY Size
					=> new PROPERTYKEY(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 12);

				/// <summary>
				/// <para>Name:     System.SoftwareUsed -- PKEY_SoftwareUsed</para>
				/// <para>Description: PropertyTagSoftwareUsed</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 305</para>
				/// </summary>
				public static PROPERTYKEY SoftwareUsed
					=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 305);

				/// <summary>
				/// <para>Name:     System.SourceItem -- PKEY_SourceItem</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: {668CDFA5-7A1B-4323-AE4B-E527393A1D81}, 100</para>
				/// </summary>
				public static PROPERTYKEY SourceItem
					=> new PROPERTYKEY(new Guid("{668CDFA5-7A1B-4323-AE4B-E527393A1D81}"), 100);

				/// <summary>
				/// <para>Name:     System.StartDate -- PKEY_StartDate</para>
				/// <para>Description:</para>
				/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
				/// <para>FormatID: {48FD6EC8-8A12-4CDF-A03E-4EC5A511EDDE}, 100</para>
				/// </summary>
				public static PROPERTYKEY StartDate
					=> new PROPERTYKEY(new Guid("{48FD6EC8-8A12-4CDF-A03E-4EC5A511EDDE}"), 100);

				/// <summary>
				/// <para>Name:     System.Status -- PKEY_Status</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (FMTID_IntSite) {000214A1-0000-0000-C000-000000000046}, 9</para>
				/// </summary>
				public static PROPERTYKEY Status
					=> new PROPERTYKEY(new Guid("{000214A1-0000-0000-C000-000000000046}"), 9);

				/// <summary>
				/// <para>Name:     System.Subject -- PKEY_Subject</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 3 (PIDSI_SUBJECT)</para>
				/// </summary>
				public static PROPERTYKEY Subject
					=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 3);

				/// <summary>
				/// <para>Name:     System.ThumbnailCacheId -- PKEY_ThumbnailCacheId</para>
				/// <para>
				/// Description: Unique value that can be used as a key to cache thumbnails. The value changes when the name, volume, or data
				/// modified of an item changes.
				/// </para>
				/// <para>Type:     UInt64 -- VT_UI8</para>
				/// <para>FormatID: {446D16B1-8DAD-4870-A748-402EA43D788C}, 100</para>
				/// </summary>
				public static PROPERTYKEY ThumbnailCacheId
					=> new PROPERTYKEY(new Guid("{446D16B1-8DAD-4870-A748-402EA43D788C}"), 100);

				/// <summary>
				/// <para>Name:     System.ThumbnailStream -- PKEY_ThumbnailStream</para>
				/// <para>
				/// Description: Data that represents the thumbnail in VT_STREAM format that GDI+/WindowsCodecs supports (jpg, png, etc).
				/// </para>
				/// <para>Type:     Stream -- VT_STREAM</para>
				/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 27</para>
				/// </summary>
				public static PROPERTYKEY ThumbnailStream
					=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 27);

				/// <summary>
				/// <para>Name:     System.Title -- PKEY_Title</para>
				/// <para>Description: Title of item.</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR) Legacy code may treat this as VT_LPSTR.</para>
				/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 2 (PIDSI_TITLE)</para>
				/// </summary>
				public static PROPERTYKEY Title
					=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 2);

				/// <summary>
				/// <para>Name:     System.TotalFileSize -- PKEY_TotalFileSize</para>
				/// <para>Description:</para>
				/// <para>Type:     UInt64 -- VT_UI8</para>
				/// <para>FormatID: (FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 14</para>
				/// </summary>
				public static PROPERTYKEY TotalFileSize
					=> new PROPERTYKEY(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 14);

				/// <summary>
				/// <para>Name:     System.Trademarks -- PKEY_Trademarks</para>
				/// <para>Description:</para>
				/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
				/// <para>FormatID: (PSFMTID_VERSION) {0CEF7D53-FA64-11D1-A203-0000F81FEDEE}, 9 (PIDVSI_Trademarks)</para>
				/// </summary>
				public static PROPERTYKEY Trademarks
					=> new PROPERTYKEY(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 9);

				/// <summary>AppUserModel Properties</summary>
				public static class AppUserModel
				{
					/// <summary>
					/// <para>Name:     System.AppUserModel.ExcludeFromShowInNewInstall -- PKEY_AppUserModel_ExcludeFromShowInNewInstall</para>
					/// <para>Description:</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 8</para>
					/// </summary>
					public static PROPERTYKEY ExcludeFromShowInNewInstall
						=> new PROPERTYKEY(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 8);

					/// <summary>
					/// <para>Name:     System.AppUserModel.ID -- PKEY_AppUserModel_ID</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 5</para>
					/// </summary>
					public static PROPERTYKEY ID
						=> new PROPERTYKEY(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 5);

					/// <summary>
					/// <para>Name:     System.AppUserModel.IsDestListSeparator -- PKEY_AppUserModel_IsDestListSeparator</para>
					/// <para>Description:</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 6</para>
					/// </summary>
					public static PROPERTYKEY IsDestListSeparator
						=> new PROPERTYKEY(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 6);

					/// <summary>
					/// <para>Name:     System.AppUserModel.PreventPinning -- PKEY_AppUserModel_PreventPinning</para>
					/// <para>Description:</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 9</para>
					/// </summary>
					public static PROPERTYKEY PreventPinning
						=> new PROPERTYKEY(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 9);

					/// <summary>
					/// <para>Name:     System.AppUserModel.RelaunchCommand -- PKEY_AppUserModel_RelaunchCommand</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 2</para>
					/// </summary>
					public static PROPERTYKEY RelaunchCommand
						=> new PROPERTYKEY(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 2);

					/// <summary>
					/// <para>Name:     System.AppUserModel.RelaunchDisplayNameResource -- PKEY_AppUserModel_RelaunchDisplayNameResource</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 4</para>
					/// </summary>
					public static PROPERTYKEY RelaunchDisplayNameResource
						=> new PROPERTYKEY(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 4);

					/// <summary>
					/// <para>Name:     System.AppUserModel.RelaunchIconResource -- PKEY_AppUserModel_RelaunchIconResource</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 3</para>
					/// </summary>
					public static PROPERTYKEY RelaunchIconResource
						=> new PROPERTYKEY(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 3);
				}

				/// <summary>Audio Properties</summary>
				public static class Audio
				{
					/// <summary>
					/// <para>Name:     System.Audio.ChannelCount -- PKEY_Audio_ChannelCount</para>
					/// <para>Description: Indicates the channel count for the audio file. Values: 1 (mono), 2 (stereo).</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 7 (PIDASI_CHANNEL_COUNT)</para>
					/// </summary>
					public static PROPERTYKEY ChannelCount
						=> new PROPERTYKEY(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 7);

					/// <summary>
					/// <para>Name:     System.Audio.Compression -- PKEY_Audio_Compression</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 10 (PIDASI_COMPRESSION)</para>
					/// </summary>
					public static PROPERTYKEY Compression
						=> new PROPERTYKEY(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 10);

					/// <summary>
					/// <para>Name:     System.Audio.EncodingBitrate -- PKEY_Audio_EncodingBitrate</para>
					/// <para>Description: Indicates the average data rate in Hz for the audio file in "bits per second".</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 4 (PIDASI_AVG_DATA_RATE)</para>
					/// </summary>
					public static PROPERTYKEY EncodingBitrate
						=> new PROPERTYKEY(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 4);

					/// <summary>
					/// <para>Name:     System.Audio.Format -- PKEY_Audio_Format</para>
					/// <para>Description: Indicates the format of the audio file.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR) Legacy code may treat this as VT_BSTR.</para>
					/// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 2 (PIDASI_FORMAT)</para>
					/// </summary>
					public static PROPERTYKEY Format
						=> new PROPERTYKEY(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 2);

					/// <summary>
					/// <para>Name:     System.Audio.IsVariableBitRate -- PKEY_Audio_IsVariableBitRate</para>
					/// <para>Description:</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {E6822FEE-8C17-4D62-823C-8E9CFCBD1D5C}, 100</para>
					/// </summary>
					public static PROPERTYKEY IsVariableBitRate
						=> new PROPERTYKEY(new Guid("{E6822FEE-8C17-4D62-823C-8E9CFCBD1D5C}"), 100);

					/// <summary>
					/// <para>Name:     System.Audio.PeakValue -- PKEY_Audio_PeakValue</para>
					/// <para>Description:</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {2579E5D0-1116-4084-BD9A-9B4F7CB4DF5E}, 100</para>
					/// </summary>
					public static PROPERTYKEY PeakValue
						=> new PROPERTYKEY(new Guid("{2579E5D0-1116-4084-BD9A-9B4F7CB4DF5E}"), 100);

					/// <summary>
					/// <para>Name:     System.Audio.SampleRate -- PKEY_Audio_SampleRate</para>
					/// <para>Description: Indicates the audio sample rate for the audio file in "samples per second".</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 5 (PIDASI_SAMPLE_RATE)</para>
					/// </summary>
					public static PROPERTYKEY SampleRate
						=> new PROPERTYKEY(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 5);

					/// <summary>
					/// <para>Name:     System.Audio.SampleSize -- PKEY_Audio_SampleSize</para>
					/// <para>Description: Indicates the audio sample size for the audio file in "bits per sample".</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 6 (PIDASI_SAMPLE_SIZE)</para>
					/// </summary>
					public static PROPERTYKEY SampleSize
						=> new PROPERTYKEY(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 6);

					/// <summary>
					/// <para>Name:     System.Audio.StreamName -- PKEY_Audio_StreamName</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 9 (PIDASI_STREAM_NAME)</para>
					/// </summary>
					public static PROPERTYKEY StreamName
						=> new PROPERTYKEY(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 9);

					/// <summary>
					/// <para>Name:     System.Audio.StreamNumber -- PKEY_Audio_StreamNumber</para>
					/// <para>Description:</para>
					/// <para>Type:     UInt16 -- VT_UI2</para>
					/// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 8 (PIDASI_STREAM_NUMBER)</para>
					/// </summary>
					public static PROPERTYKEY StreamNumber
						=> new PROPERTYKEY(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 8);
				}

				/// <summary>Calendar Properties</summary>
				public static class Calendar
				{
					/// <summary>
					/// <para>Name:     System.Calendar.Duration -- PKEY_Calendar_Duration</para>
					/// <para>Description: The duration as specified in a string.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {293CA35A-09AA-4DD2-B180-1FE245728A52}, 100</para>
					/// </summary>
					public static PROPERTYKEY Duration
						=> new PROPERTYKEY(new Guid("{293CA35A-09AA-4DD2-B180-1FE245728A52}"), 100);

					/// <summary>
					/// <para>Name:     System.Calendar.IsOnline -- PKEY_Calendar_IsOnline</para>
					/// <para>Description: Identifies if the event is an online event.</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {BFEE9149-E3E2-49A7-A862-C05988145CEC}, 100</para>
					/// </summary>
					public static PROPERTYKEY IsOnline
						=> new PROPERTYKEY(new Guid("{BFEE9149-E3E2-49A7-A862-C05988145CEC}"), 100);

					/// <summary>
					/// <para>Name:     System.Calendar.IsRecurring -- PKEY_Calendar_IsRecurring</para>
					/// <para>Description:</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {315B9C8D-80A9-4EF9-AE16-8E746DA51D70}, 100</para>
					/// </summary>
					public static PROPERTYKEY IsRecurring
						=> new PROPERTYKEY(new Guid("{315B9C8D-80A9-4EF9-AE16-8E746DA51D70}"), 100);

					/// <summary>
					/// <para>Name:     System.Calendar.Location -- PKEY_Calendar_Location</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {F6272D18-CECC-40B1-B26A-3911717AA7BD}, 100</para>
					/// </summary>
					public static PROPERTYKEY Location
						=> new PROPERTYKEY(new Guid("{F6272D18-CECC-40B1-B26A-3911717AA7BD}"), 100);

					/// <summary>
					/// <para>Name:     System.Calendar.OptionalAttendeeAddresses -- PKEY_Calendar_OptionalAttendeeAddresses</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {D55BAE5A-3892-417A-A649-C6AC5AAAEAB3}, 100</para>
					/// </summary>
					public static PROPERTYKEY OptionalAttendeeAddresses
						=> new PROPERTYKEY(new Guid("{D55BAE5A-3892-417A-A649-C6AC5AAAEAB3}"), 100);

					/// <summary>
					/// <para>Name:     System.Calendar.OptionalAttendeeNames -- PKEY_Calendar_OptionalAttendeeNames</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {09429607-582D-437F-84C3-DE93A2B24C3C}, 100</para>
					/// </summary>
					public static PROPERTYKEY OptionalAttendeeNames
						=> new PROPERTYKEY(new Guid("{09429607-582D-437F-84C3-DE93A2B24C3C}"), 100);

					/// <summary>
					/// <para>Name:     System.Calendar.OrganizerAddress -- PKEY_Calendar_OrganizerAddress</para>
					/// <para>Description: Address of the organizer organizing the event.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {744C8242-4DF5-456C-AB9E-014EFB9021E3}, 100</para>
					/// </summary>
					public static PROPERTYKEY OrganizerAddress
						=> new PROPERTYKEY(new Guid("{744C8242-4DF5-456C-AB9E-014EFB9021E3}"), 100);

					/// <summary>
					/// <para>Name:     System.Calendar.OrganizerName -- PKEY_Calendar_OrganizerName</para>
					/// <para>Description: Name of the organizer organizing the event.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {AAA660F9-9865-458E-B484-01BC7FE3973E}, 100</para>
					/// </summary>
					public static PROPERTYKEY OrganizerName
						=> new PROPERTYKEY(new Guid("{AAA660F9-9865-458E-B484-01BC7FE3973E}"), 100);

					/// <summary>
					/// <para>Name:     System.Calendar.ReminderTime -- PKEY_Calendar_ReminderTime</para>
					/// <para>Description:</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: {72FC5BA4-24F9-4011-9F3F-ADD27AFAD818}, 100</para>
					/// </summary>
					public static PROPERTYKEY ReminderTime
						=> new PROPERTYKEY(new Guid("{72FC5BA4-24F9-4011-9F3F-ADD27AFAD818}"), 100);

					/// <summary>
					/// <para>Name:     System.Calendar.RequiredAttendeeAddresses -- PKEY_Calendar_RequiredAttendeeAddresses</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {0BA7D6C3-568D-4159-AB91-781A91FB71E5}, 100</para>
					/// </summary>
					public static PROPERTYKEY RequiredAttendeeAddresses
						=> new PROPERTYKEY(new Guid("{0BA7D6C3-568D-4159-AB91-781A91FB71E5}"), 100);

					/// <summary>
					/// <para>Name:     System.Calendar.RequiredAttendeeNames -- PKEY_Calendar_RequiredAttendeeNames</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {B33AF30B-F552-4584-936C-CB93E5CDA29F}, 100</para>
					/// </summary>
					public static PROPERTYKEY RequiredAttendeeNames
						=> new PROPERTYKEY(new Guid("{B33AF30B-F552-4584-936C-CB93E5CDA29F}"), 100);

					/// <summary>
					/// <para>Name:     System.Calendar.Resources -- PKEY_Calendar_Resources</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {00F58A38-C54B-4C40-8696-97235980EAE1}, 100</para>
					/// </summary>
					public static PROPERTYKEY Resources
						=> new PROPERTYKEY(new Guid("{00F58A38-C54B-4C40-8696-97235980EAE1}"), 100);

					/// <summary>
					/// <para>Name:     System.Calendar.ResponseStatus -- PKEY_Calendar_ResponseStatus</para>
					/// <para>Description: This property stores the status of the user responses to meetings in her calendar.</para>
					/// <para>Type:     UInt16 -- VT_UI2</para>
					/// <para>FormatID: {188C1F91-3C40-4132-9EC5-D8B03B72A8A2}, 100</para>
					/// </summary>
					public static PROPERTYKEY ResponseStatus
						=> new PROPERTYKEY(new Guid("{188C1F91-3C40-4132-9EC5-D8B03B72A8A2}"), 100);

					/// <summary>
					/// <para>Name:     System.Calendar.ShowTimeAs -- PKEY_Calendar_ShowTimeAs</para>
					/// <para>Description:</para>
					/// <para>Type:     UInt16 -- VT_UI2</para>
					/// <para>FormatID: {5BF396D4-5EB2-466F-BDE9-2FB3F2361D6E}, 100</para>
					/// </summary>
					public static PROPERTYKEY ShowTimeAs
						=> new PROPERTYKEY(new Guid("{5BF396D4-5EB2-466F-BDE9-2FB3F2361D6E}"), 100);

					/// <summary>
					/// <para>Name:     System.Calendar.ShowTimeAsText -- PKEY_Calendar_ShowTimeAsText</para>
					/// <para>
					/// Description: This is the user-friendly form of System.Calendar.ShowTimeAs. Not intended to be parsed programmatically.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {53DA57CF-62C0-45C4-81DE-7610BCEFD7F5}, 100</para>
					/// </summary>
					public static PROPERTYKEY ShowTimeAsText
						=> new PROPERTYKEY(new Guid("{53DA57CF-62C0-45C4-81DE-7610BCEFD7F5}"), 100);
				}

				/// <summary>Communication Properties</summary>
				public static class Communication
				{
					/// <summary>
					/// <para>Name:     System.Communication.AccountName -- PKEY_Communication_AccountName</para>
					/// <para>Description: Account Name</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 9</para>
					/// </summary>
					public static PROPERTYKEY AccountName
						=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 9);

					/// <summary>
					/// <para>Name:     System.Communication.DateItemExpires -- PKEY_Communication_DateItemExpires</para>
					/// <para>Description: Date the item expires due to the retention policy.</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: {428040AC-A177-4C8A-9760-F6F761227F9A}, 100</para>
					/// </summary>
					public static PROPERTYKEY DateItemExpires
						=> new PROPERTYKEY(new Guid("{428040AC-A177-4C8A-9760-F6F761227F9A}"), 100);

					/// <summary>
					/// <para>Name:     System.Communication.FollowupIconIndex -- PKEY_Communication_FollowupIconIndex</para>
					/// <para>Description: This is the icon index used on messages marked for followup.</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: {83A6347E-6FE4-4F40-BA9C-C4865240D1F4}, 100</para>
					/// </summary>
					public static PROPERTYKEY FollowupIconIndex
						=> new PROPERTYKEY(new Guid("{83A6347E-6FE4-4F40-BA9C-C4865240D1F4}"), 100);

					/// <summary>
					/// <para>Name:     System.Communication.HeaderItem -- PKEY_Communication_HeaderItem</para>
					/// <para>
					/// Description: This property will be true if the item is a header item which means the item hasn't been fully downloaded.
					/// </para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {C9C34F84-2241-4401-B607-BD20ED75AE7F}, 100</para>
					/// </summary>
					public static PROPERTYKEY HeaderItem
						=> new PROPERTYKEY(new Guid("{C9C34F84-2241-4401-B607-BD20ED75AE7F}"), 100);

					/// <summary>
					/// <para>Name:     System.Communication.PolicyTag -- PKEY_Communication_PolicyTag</para>
					/// <para>Description: This a string used to identify the retention policy applied to the item.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {EC0B4191-AB0B-4C66-90B6-C6637CDEBBAB}, 100</para>
					/// </summary>
					public static PROPERTYKEY PolicyTag
						=> new PROPERTYKEY(new Guid("{EC0B4191-AB0B-4C66-90B6-C6637CDEBBAB}"), 100);

					/// <summary>
					/// <para>Name:     System.Communication.SecurityFlags -- PKEY_Communication_SecurityFlags</para>
					/// <para>Description: Security flags associated with the item to know if the item is encrypted, signed or DRM enabled.</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: {8619A4B6-9F4D-4429-8C0F-B996CA59E335}, 100</para>
					/// </summary>
					public static PROPERTYKEY SecurityFlags
						=> new PROPERTYKEY(new Guid("{8619A4B6-9F4D-4429-8C0F-B996CA59E335}"), 100);

					/// <summary>
					/// <para>Name:     System.Communication.Suffix -- PKEY_Communication_Suffix</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {807B653A-9E91-43EF-8F97-11CE04EE20C5}, 100</para>
					/// </summary>
					public static PROPERTYKEY Suffix
						=> new PROPERTYKEY(new Guid("{807B653A-9E91-43EF-8F97-11CE04EE20C5}"), 100);

					/// <summary>
					/// <para>Name:     System.Communication.TaskStatus -- PKEY_Communication_TaskStatus</para>
					/// <para>Description:</para>
					/// <para>Type:     UInt16 -- VT_UI2</para>
					/// <para>FormatID: {BE1A72C6-9A1D-46B7-AFE7-AFAF8CEF4999}, 100</para>
					/// </summary>
					public static PROPERTYKEY TaskStatus
						=> new PROPERTYKEY(new Guid("{BE1A72C6-9A1D-46B7-AFE7-AFAF8CEF4999}"), 100);

					/// <summary>
					/// <para>Name:     System.Communication.TaskStatusText -- PKEY_Communication_TaskStatusText</para>
					/// <para>
					/// Description: This is the user-friendly form of System.Communication.TaskStatus. Not intended to be parsed programmatically.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {A6744477-C237-475B-A075-54F34498292A}, 100</para>
					/// </summary>
					public static PROPERTYKEY TaskStatusText
						=> new PROPERTYKEY(new Guid("{A6744477-C237-475B-A075-54F34498292A}"), 100);
				}

				/// <summary>Computer Properties</summary>
				public static class Computer
				{
					/// <summary>
					/// <para>Name:     System.Computer.DecoratedFreeSpace -- PKEY_Computer_DecoratedFreeSpace</para>
					/// <para>Description: Free space and total space: "%s free of %s"</para>
					/// <para>Type:     Multivalue UInt64 -- VT_VECTOR | VT_UI8 (For variants: VT_ARRAY | VT_UI8)</para>
					/// <para>FormatID: (FMTID_Volume) {9B174B35-40FF-11D2-A27E-00C04FC30871}, 7 (Filesystem Volume Properties)</para>
					/// </summary>
					public static PROPERTYKEY DecoratedFreeSpace
						=> new PROPERTYKEY(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 7);
				}

				/// <summary>Contact Properties</summary>
				public static class Contact
				{
					/// <summary>
					/// <para>Name:     System.Contact.Anniversary -- PKEY_Contact_Anniversary</para>
					/// <para>Description:</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: {9AD5BADB-CEA7-4470-A03D-B84E51B9949E}, 100</para>
					/// </summary>
					public static PROPERTYKEY Anniversary
						=> new PROPERTYKEY(new Guid("{9AD5BADB-CEA7-4470-A03D-B84E51B9949E}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.AssistantName -- PKEY_Contact_AssistantName</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {CD102C9C-5540-4A88-A6F6-64E4981C8CD1}, 100</para>
					/// </summary>
					public static PROPERTYKEY AssistantName
						=> new PROPERTYKEY(new Guid("{CD102C9C-5540-4A88-A6F6-64E4981C8CD1}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.AssistantTelephone -- PKEY_Contact_AssistantTelephone</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {9A93244D-A7AD-4FF8-9B99-45EE4CC09AF6}, 100</para>
					/// </summary>
					public static PROPERTYKEY AssistantTelephone
						=> new PROPERTYKEY(new Guid("{9A93244D-A7AD-4FF8-9B99-45EE4CC09AF6}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.Birthday -- PKEY_Contact_Birthday</para>
					/// <para>Description:</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 47</para>
					/// </summary>
					public static PROPERTYKEY Birthday
						=> new PROPERTYKEY(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 47);

					/// <summary>
					/// <para>Name:     System.Contact.BusinessAddress -- PKEY_Contact_BusinessAddress</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {730FB6DD-CF7C-426B-A03F-BD166CC9EE24}, 100</para>
					/// </summary>
					public static PROPERTYKEY BusinessAddress
						=> new PROPERTYKEY(new Guid("{730FB6DD-CF7C-426B-A03F-BD166CC9EE24}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.BusinessAddressCity -- PKEY_Contact_BusinessAddressCity</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {402B5934-EC5A-48C3-93E6-85E86A2D934E}, 100</para>
					/// </summary>
					public static PROPERTYKEY BusinessAddressCity
						=> new PROPERTYKEY(new Guid("{402B5934-EC5A-48C3-93E6-85E86A2D934E}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.BusinessAddressCountry -- PKEY_Contact_BusinessAddressCountry</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {B0B87314-FCF6-4FEB-8DFF-A50DA6AF561C}, 100</para>
					/// </summary>
					public static PROPERTYKEY BusinessAddressCountry
						=> new PROPERTYKEY(new Guid("{B0B87314-FCF6-4FEB-8DFF-A50DA6AF561C}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.BusinessAddressPostalCode -- PKEY_Contact_BusinessAddressPostalCode</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {E1D4A09E-D758-4CD1-B6EC-34A8B5A73F80}, 100</para>
					/// </summary>
					public static PROPERTYKEY BusinessAddressPostalCode
						=> new PROPERTYKEY(new Guid("{E1D4A09E-D758-4CD1-B6EC-34A8B5A73F80}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.BusinessAddressPostOfficeBox -- PKEY_Contact_BusinessAddressPostOfficeBox</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {BC4E71CE-17F9-48D5-BEE9-021DF0EA5409}, 100</para>
					/// </summary>
					public static PROPERTYKEY BusinessAddressPostOfficeBox
						=> new PROPERTYKEY(new Guid("{BC4E71CE-17F9-48D5-BEE9-021DF0EA5409}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.BusinessAddressState -- PKEY_Contact_BusinessAddressState</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {446F787F-10C4-41CB-A6C4-4D0343551597}, 100</para>
					/// </summary>
					public static PROPERTYKEY BusinessAddressState
						=> new PROPERTYKEY(new Guid("{446F787F-10C4-41CB-A6C4-4D0343551597}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.BusinessAddressStreet -- PKEY_Contact_BusinessAddressStreet</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {DDD1460F-C0BF-4553-8CE4-10433C908FB0}, 100</para>
					/// </summary>
					public static PROPERTYKEY BusinessAddressStreet
						=> new PROPERTYKEY(new Guid("{DDD1460F-C0BF-4553-8CE4-10433C908FB0}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.BusinessFaxNumber -- PKEY_Contact_BusinessFaxNumber</para>
					/// <para>Description: Business fax number of the contact.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {91EFF6F3-2E27-42CA-933E-7C999FBE310B}, 100</para>
					/// </summary>
					public static PROPERTYKEY BusinessFaxNumber
						=> new PROPERTYKEY(new Guid("{91EFF6F3-2E27-42CA-933E-7C999FBE310B}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.BusinessHomePage -- PKEY_Contact_BusinessHomePage</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {56310920-2491-4919-99CE-EADB06FAFDB2}, 100</para>
					/// </summary>
					public static PROPERTYKEY BusinessHomePage
						=> new PROPERTYKEY(new Guid("{56310920-2491-4919-99CE-EADB06FAFDB2}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.BusinessTelephone -- PKEY_Contact_BusinessTelephone</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {6A15E5A0-0A1E-4CD7-BB8C-D2F1B0C929BC}, 100</para>
					/// </summary>
					public static PROPERTYKEY BusinessTelephone
						=> new PROPERTYKEY(new Guid("{6A15E5A0-0A1E-4CD7-BB8C-D2F1B0C929BC}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.CallbackTelephone -- PKEY_Contact_CallbackTelephone</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {BF53D1C3-49E0-4F7F-8567-5A821D8AC542}, 100</para>
					/// </summary>
					public static PROPERTYKEY CallbackTelephone
						=> new PROPERTYKEY(new Guid("{BF53D1C3-49E0-4F7F-8567-5A821D8AC542}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.CarTelephone -- PKEY_Contact_CarTelephone</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {8FDC6DEA-B929-412B-BA90-397A257465FE}, 100</para>
					/// </summary>
					public static PROPERTYKEY CarTelephone
						=> new PROPERTYKEY(new Guid("{8FDC6DEA-B929-412B-BA90-397A257465FE}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.Children -- PKEY_Contact_Children</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {D4729704-8EF1-43EF-9024-2BD381187FD5}, 100</para>
					/// </summary>
					public static PROPERTYKEY Children
						=> new PROPERTYKEY(new Guid("{D4729704-8EF1-43EF-9024-2BD381187FD5}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.CompanyMainTelephone -- PKEY_Contact_CompanyMainTelephone</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {8589E481-6040-473D-B171-7FA89C2708ED}, 100</para>
					/// </summary>
					public static PROPERTYKEY CompanyMainTelephone
						=> new PROPERTYKEY(new Guid("{8589E481-6040-473D-B171-7FA89C2708ED}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.Department -- PKEY_Contact_Department</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {FC9F7306-FF8F-4D49-9FB6-3FFE5C0951EC}, 100</para>
					/// </summary>
					public static PROPERTYKEY Department
						=> new PROPERTYKEY(new Guid("{FC9F7306-FF8F-4D49-9FB6-3FFE5C0951EC}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.EmailAddress -- PKEY_Contact_EmailAddress</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {F8FA7FA3-D12B-4785-8A4E-691A94F7A3E7}, 100</para>
					/// </summary>
					public static PROPERTYKEY EmailAddress
						=> new PROPERTYKEY(new Guid("{F8FA7FA3-D12B-4785-8A4E-691A94F7A3E7}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.EmailAddress2 -- PKEY_Contact_EmailAddress2</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {38965063-EDC8-4268-8491-B7723172CF29}, 100</para>
					/// </summary>
					public static PROPERTYKEY EmailAddress2
						=> new PROPERTYKEY(new Guid("{38965063-EDC8-4268-8491-B7723172CF29}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.EmailAddress3 -- PKEY_Contact_EmailAddress3</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {644D37B4-E1B3-4BAD-B099-7E7C04966ACA}, 100</para>
					/// </summary>
					public static PROPERTYKEY EmailAddress3
						=> new PROPERTYKEY(new Guid("{644D37B4-E1B3-4BAD-B099-7E7C04966ACA}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.EmailAddresses -- PKEY_Contact_EmailAddresses</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {84D8F337-981D-44B3-9615-C7596DBA17E3}, 100</para>
					/// </summary>
					public static PROPERTYKEY EmailAddresses
						=> new PROPERTYKEY(new Guid("{84D8F337-981D-44B3-9615-C7596DBA17E3}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.EmailName -- PKEY_Contact_EmailName</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {CC6F4F24-6083-4BD4-8754-674D0DE87AB8}, 100</para>
					/// </summary>
					public static PROPERTYKEY EmailName
						=> new PROPERTYKEY(new Guid("{CC6F4F24-6083-4BD4-8754-674D0DE87AB8}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.FileAsName -- PKEY_Contact_FileAsName</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {F1A24AA7-9CA7-40F6-89EC-97DEF9FFE8DB}, 100</para>
					/// </summary>
					public static PROPERTYKEY FileAsName
						=> new PROPERTYKEY(new Guid("{F1A24AA7-9CA7-40F6-89EC-97DEF9FFE8DB}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.FirstName -- PKEY_Contact_FirstName</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {14977844-6B49-4AAD-A714-A4513BF60460}, 100</para>
					/// </summary>
					public static PROPERTYKEY FirstName
						=> new PROPERTYKEY(new Guid("{14977844-6B49-4AAD-A714-A4513BF60460}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.FullName -- PKEY_Contact_FullName</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {635E9051-50A5-4BA2-B9DB-4ED056C77296}, 100</para>
					/// </summary>
					public static PROPERTYKEY FullName
						=> new PROPERTYKEY(new Guid("{635E9051-50A5-4BA2-B9DB-4ED056C77296}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.Gender -- PKEY_Contact_Gender</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {3C8CEE58-D4F0-4CF9-B756-4E5D24447BCD}, 100</para>
					/// </summary>
					public static PROPERTYKEY Gender
						=> new PROPERTYKEY(new Guid("{3C8CEE58-D4F0-4CF9-B756-4E5D24447BCD}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.GenderValue -- PKEY_Contact_GenderValue</para>
					/// <para>Description:</para>
					/// <para>Type:     UInt16 -- VT_UI2</para>
					/// <para>FormatID: {3C8CEE58-D4F0-4CF9-B756-4E5D24447BCD}, 101</para>
					/// </summary>
					public static PROPERTYKEY GenderValue
						=> new PROPERTYKEY(new Guid("{3C8CEE58-D4F0-4CF9-B756-4E5D24447BCD}"), 101);

					/// <summary>
					/// <para>Name:     System.Contact.Hobbies -- PKEY_Contact_Hobbies</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {5DC2253F-5E11-4ADF-9CFE-910DD01E3E70}, 100</para>
					/// </summary>
					public static PROPERTYKEY Hobbies
						=> new PROPERTYKEY(new Guid("{5DC2253F-5E11-4ADF-9CFE-910DD01E3E70}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.HomeAddress -- PKEY_Contact_HomeAddress</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {98F98354-617A-46B8-8560-5B1B64BF1F89}, 100</para>
					/// </summary>
					public static PROPERTYKEY HomeAddress
						=> new PROPERTYKEY(new Guid("{98F98354-617A-46B8-8560-5B1B64BF1F89}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.HomeAddressCity -- PKEY_Contact_HomeAddressCity</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 65</para>
					/// </summary>
					public static PROPERTYKEY HomeAddressCity
						=> new PROPERTYKEY(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 65);

					/// <summary>
					/// <para>Name:     System.Contact.HomeAddressCountry -- PKEY_Contact_HomeAddressCountry</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {08A65AA1-F4C9-43DD-9DDF-A33D8E7EAD85}, 100</para>
					/// </summary>
					public static PROPERTYKEY HomeAddressCountry
						=> new PROPERTYKEY(new Guid("{08A65AA1-F4C9-43DD-9DDF-A33D8E7EAD85}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.HomeAddressPostalCode -- PKEY_Contact_HomeAddressPostalCode</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {8AFCC170-8A46-4B53-9EEE-90BAE7151E62}, 100</para>
					/// </summary>
					public static PROPERTYKEY HomeAddressPostalCode
						=> new PROPERTYKEY(new Guid("{8AFCC170-8A46-4B53-9EEE-90BAE7151E62}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.HomeAddressPostOfficeBox -- PKEY_Contact_HomeAddressPostOfficeBox</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {7B9F6399-0A3F-4B12-89BD-4ADC51C918AF}, 100</para>
					/// </summary>
					public static PROPERTYKEY HomeAddressPostOfficeBox
						=> new PROPERTYKEY(new Guid("{7B9F6399-0A3F-4B12-89BD-4ADC51C918AF}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.HomeAddressState -- PKEY_Contact_HomeAddressState</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C89A23D0-7D6D-4EB8-87D4-776A82D493E5}, 100</para>
					/// </summary>
					public static PROPERTYKEY HomeAddressState
						=> new PROPERTYKEY(new Guid("{C89A23D0-7D6D-4EB8-87D4-776A82D493E5}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.HomeAddressStreet -- PKEY_Contact_HomeAddressStreet</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {0ADEF160-DB3F-4308-9A21-06237B16FA2A}, 100</para>
					/// </summary>
					public static PROPERTYKEY HomeAddressStreet
						=> new PROPERTYKEY(new Guid("{0ADEF160-DB3F-4308-9A21-06237B16FA2A}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.HomeFaxNumber -- PKEY_Contact_HomeFaxNumber</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {660E04D6-81AB-4977-A09F-82313113AB26}, 100</para>
					/// </summary>
					public static PROPERTYKEY HomeFaxNumber
						=> new PROPERTYKEY(new Guid("{660E04D6-81AB-4977-A09F-82313113AB26}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.HomeTelephone -- PKEY_Contact_HomeTelephone</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 20</para>
					/// </summary>
					public static PROPERTYKEY HomeTelephone
						=> new PROPERTYKEY(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 20);

					/// <summary>
					/// <para>Name:     System.Contact.IMAddress -- PKEY_Contact_IMAddress</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {D68DBD8A-3374-4B81-9972-3EC30682DB3D}, 100</para>
					/// </summary>
					public static PROPERTYKEY IMAddress
						=> new PROPERTYKEY(new Guid("{D68DBD8A-3374-4B81-9972-3EC30682DB3D}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.Initials -- PKEY_Contact_Initials</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {F3D8F40D-50CB-44A2-9718-40CB9119495D}, 100</para>
					/// </summary>
					public static PROPERTYKEY Initials
						=> new PROPERTYKEY(new Guid("{F3D8F40D-50CB-44A2-9718-40CB9119495D}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.JobTitle -- PKEY_Contact_JobTitle</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 6</para>
					/// </summary>
					public static PROPERTYKEY JobTitle
						=> new PROPERTYKEY(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 6);

					/// <summary>
					/// <para>Name:     System.Contact.Label -- PKEY_Contact_Label</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {97B0AD89-DF49-49CC-834E-660974FD755B}, 100</para>
					/// </summary>
					public static PROPERTYKEY Label
						=> new PROPERTYKEY(new Guid("{97B0AD89-DF49-49CC-834E-660974FD755B}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.LastName -- PKEY_Contact_LastName</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {8F367200-C270-457C-B1D4-E07C5BCD90C7}, 100</para>
					/// </summary>
					public static PROPERTYKEY LastName
						=> new PROPERTYKEY(new Guid("{8F367200-C270-457C-B1D4-E07C5BCD90C7}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.MailingAddress -- PKEY_Contact_MailingAddress</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C0AC206A-827E-4650-95AE-77E2BB74FCC9}, 100</para>
					/// </summary>
					public static PROPERTYKEY MailingAddress
						=> new PROPERTYKEY(new Guid("{C0AC206A-827E-4650-95AE-77E2BB74FCC9}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.MiddleName -- PKEY_Contact_MiddleName</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 71</para>
					/// </summary>
					public static PROPERTYKEY MiddleName
						=> new PROPERTYKEY(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 71);

					/// <summary>
					/// <para>Name:     System.Contact.MobileTelephone -- PKEY_Contact_MobileTelephone</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 35</para>
					/// </summary>
					public static PROPERTYKEY MobileTelephone
						=> new PROPERTYKEY(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 35);

					/// <summary>
					/// <para>Name:     System.Contact.NickName -- PKEY_Contact_NickName</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 74</para>
					/// </summary>
					public static PROPERTYKEY NickName
						=> new PROPERTYKEY(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 74);

					/// <summary>
					/// <para>Name:     System.Contact.OfficeLocation -- PKEY_Contact_OfficeLocation</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 7</para>
					/// </summary>
					public static PROPERTYKEY OfficeLocation
						=> new PROPERTYKEY(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 7);

					/// <summary>
					/// <para>Name:     System.Contact.OtherAddress -- PKEY_Contact_OtherAddress</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {508161FA-313B-43D5-83A1-C1ACCF68622C}, 100</para>
					/// </summary>
					public static PROPERTYKEY OtherAddress
						=> new PROPERTYKEY(new Guid("{508161FA-313B-43D5-83A1-C1ACCF68622C}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.OtherAddressCity -- PKEY_Contact_OtherAddressCity</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {6E682923-7F7B-4F0C-A337-CFCA296687BF}, 100</para>
					/// </summary>
					public static PROPERTYKEY OtherAddressCity
						=> new PROPERTYKEY(new Guid("{6E682923-7F7B-4F0C-A337-CFCA296687BF}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.OtherAddressCountry -- PKEY_Contact_OtherAddressCountry</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {8F167568-0AAE-4322-8ED9-6055B7B0E398}, 100</para>
					/// </summary>
					public static PROPERTYKEY OtherAddressCountry
						=> new PROPERTYKEY(new Guid("{8F167568-0AAE-4322-8ED9-6055B7B0E398}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.OtherAddressPostalCode -- PKEY_Contact_OtherAddressPostalCode</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {95C656C1-2ABF-4148-9ED3-9EC602E3B7CD}, 100</para>
					/// </summary>
					public static PROPERTYKEY OtherAddressPostalCode
						=> new PROPERTYKEY(new Guid("{95C656C1-2ABF-4148-9ED3-9EC602E3B7CD}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.OtherAddressPostOfficeBox -- PKEY_Contact_OtherAddressPostOfficeBox</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {8B26EA41-058F-43F6-AECC-4035681CE977}, 100</para>
					/// </summary>
					public static PROPERTYKEY OtherAddressPostOfficeBox
						=> new PROPERTYKEY(new Guid("{8B26EA41-058F-43F6-AECC-4035681CE977}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.OtherAddressState -- PKEY_Contact_OtherAddressState</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {71B377D6-E570-425F-A170-809FAE73E54E}, 100</para>
					/// </summary>
					public static PROPERTYKEY OtherAddressState
						=> new PROPERTYKEY(new Guid("{71B377D6-E570-425F-A170-809FAE73E54E}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.OtherAddressStreet -- PKEY_Contact_OtherAddressStreet</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {FF962609-B7D6-4999-862D-95180D529AEA}, 100</para>
					/// </summary>
					public static PROPERTYKEY OtherAddressStreet
						=> new PROPERTYKEY(new Guid("{FF962609-B7D6-4999-862D-95180D529AEA}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.PagerTelephone -- PKEY_Contact_PagerTelephone</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {D6304E01-F8F5-4F45-8B15-D024A6296789}, 100</para>
					/// </summary>
					public static PROPERTYKEY PagerTelephone
						=> new PROPERTYKEY(new Guid("{D6304E01-F8F5-4F45-8B15-D024A6296789}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.PersonalTitle -- PKEY_Contact_PersonalTitle</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 69</para>
					/// </summary>
					public static PROPERTYKEY PersonalTitle
						=> new PROPERTYKEY(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 69);

					/// <summary>
					/// <para>Name:     System.Contact.PrimaryAddressCity -- PKEY_Contact_PrimaryAddressCity</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C8EA94F0-A9E3-4969-A94B-9C62A95324E0}, 100</para>
					/// </summary>
					public static PROPERTYKEY PrimaryAddressCity
						=> new PROPERTYKEY(new Guid("{C8EA94F0-A9E3-4969-A94B-9C62A95324E0}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.PrimaryAddressCountry -- PKEY_Contact_PrimaryAddressCountry</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {E53D799D-0F3F-466E-B2FF-74634A3CB7A4}, 100</para>
					/// </summary>
					public static PROPERTYKEY PrimaryAddressCountry
						=> new PROPERTYKEY(new Guid("{E53D799D-0F3F-466E-B2FF-74634A3CB7A4}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.PrimaryAddressPostalCode -- PKEY_Contact_PrimaryAddressPostalCode</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {18BBD425-ECFD-46EF-B612-7B4A6034EDA0}, 100</para>
					/// </summary>
					public static PROPERTYKEY PrimaryAddressPostalCode
						=> new PROPERTYKEY(new Guid("{18BBD425-ECFD-46EF-B612-7B4A6034EDA0}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.PrimaryAddressPostOfficeBox -- PKEY_Contact_PrimaryAddressPostOfficeBox</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {DE5EF3C7-46E1-484E-9999-62C5308394C1}, 100</para>
					/// </summary>
					public static PROPERTYKEY PrimaryAddressPostOfficeBox
						=> new PROPERTYKEY(new Guid("{DE5EF3C7-46E1-484E-9999-62C5308394C1}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.PrimaryAddressState -- PKEY_Contact_PrimaryAddressState</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {F1176DFE-7138-4640-8B4C-AE375DC70A6D}, 100</para>
					/// </summary>
					public static PROPERTYKEY PrimaryAddressState
						=> new PROPERTYKEY(new Guid("{F1176DFE-7138-4640-8B4C-AE375DC70A6D}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.PrimaryAddressStreet -- PKEY_Contact_PrimaryAddressStreet</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {63C25B20-96BE-488F-8788-C09C407AD812}, 100</para>
					/// </summary>
					public static PROPERTYKEY PrimaryAddressStreet
						=> new PROPERTYKEY(new Guid("{63C25B20-96BE-488F-8788-C09C407AD812}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.PrimaryEmailAddress -- PKEY_Contact_PrimaryEmailAddress</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 48</para>
					/// </summary>
					public static PROPERTYKEY PrimaryEmailAddress
						=> new PROPERTYKEY(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 48);

					/// <summary>
					/// <para>Name:     System.Contact.PrimaryTelephone -- PKEY_Contact_PrimaryTelephone</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 25</para>
					/// </summary>
					public static PROPERTYKEY PrimaryTelephone
						=> new PROPERTYKEY(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 25);

					/// <summary>
					/// <para>Name:     System.Contact.Profession -- PKEY_Contact_Profession</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {7268AF55-1CE4-4F6E-A41F-B6E4EF10E4A9}, 100</para>
					/// </summary>
					public static PROPERTYKEY Profession
						=> new PROPERTYKEY(new Guid("{7268AF55-1CE4-4F6E-A41F-B6E4EF10E4A9}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.SpouseName -- PKEY_Contact_SpouseName</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {9D2408B6-3167-422B-82B0-F583B7A7CFE3}, 100</para>
					/// </summary>
					public static PROPERTYKEY SpouseName
						=> new PROPERTYKEY(new Guid("{9D2408B6-3167-422B-82B0-F583B7A7CFE3}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.Suffix -- PKEY_Contact_Suffix</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {176DC63C-2688-4E89-8143-A347800F25E9}, 73</para>
					/// </summary>
					public static PROPERTYKEY Suffix
						=> new PROPERTYKEY(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 73);

					/// <summary>
					/// <para>Name:     System.Contact.TelexNumber -- PKEY_Contact_TelexNumber</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C554493C-C1F7-40C1-A76C-EF8C0614003E}, 100</para>
					/// </summary>
					public static PROPERTYKEY TelexNumber
						=> new PROPERTYKEY(new Guid("{C554493C-C1F7-40C1-A76C-EF8C0614003E}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.TTYTDDTelephone -- PKEY_Contact_TTYTDDTelephone</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {AAF16BAC-2B55-45E6-9F6D-415EB94910DF}, 100</para>
					/// </summary>
					public static PROPERTYKEY TTYTDDTelephone
						=> new PROPERTYKEY(new Guid("{AAF16BAC-2B55-45E6-9F6D-415EB94910DF}"), 100);

					/// <summary>
					/// <para>Name:     System.Contact.WebPage -- PKEY_Contact_WebPage</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 18</para>
					/// </summary>
					public static PROPERTYKEY WebPage
						=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 18);

					/// <summary>JA Properties</summary>
					public static class JA
					{
						/// <summary>
						/// <para>Name:     System.Contact.JA.CompanyNamePhonetic -- PKEY_Contact_JA_CompanyNamePhonetic</para>
						/// <para>Description:</para>
						/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
						/// <para>FormatID: {897B3694-FE9E-43E6-8066-260F590C0100}, 2</para>
						/// </summary>
						public static PROPERTYKEY CompanyNamePhonetic
							=> new PROPERTYKEY(new Guid("{897B3694-FE9E-43E6-8066-260F590C0100}"), 2);

						/// <summary>
						/// <para>Name:     System.Contact.JA.FirstNamePhonetic -- PKEY_Contact_JA_FirstNamePhonetic</para>
						/// <para>Description:</para>
						/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
						/// <para>FormatID: {897B3694-FE9E-43E6-8066-260F590C0100}, 3</para>
						/// </summary>
						public static PROPERTYKEY FirstNamePhonetic
							=> new PROPERTYKEY(new Guid("{897B3694-FE9E-43E6-8066-260F590C0100}"), 3);

						/// <summary>
						/// <para>Name:     System.Contact.JA.LastNamePhonetic -- PKEY_Contact_JA_LastNamePhonetic</para>
						/// <para>Description:</para>
						/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
						/// <para>FormatID: {897B3694-FE9E-43E6-8066-260F590C0100}, 4</para>
						/// </summary>
						public static PROPERTYKEY LastNamePhonetic
							=> new PROPERTYKEY(new Guid("{897B3694-FE9E-43E6-8066-260F590C0100}"), 4);
					}
				}

				/// <summary>Device Properties</summary>
				public static class Device
				{
					/// <summary>
					/// <para>Name:     System.Device.PrinterURL -- PKEY_Device_PrinterURL</para>
					/// <para>Description: Printer information Printer URL.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {0B48F35A-BE6E-4F17-B108-3C4073D1669A}, 15</para>
					/// </summary>
					public static PROPERTYKEY PrinterURL
						=> new PROPERTYKEY(new Guid("{0B48F35A-BE6E-4F17-B108-3C4073D1669A}"), 15);
				}

				/// <summary>DeviceInterface Properties</summary>
				public static class DeviceInterface
				{
					/// <summary>
					/// <para>Name:     System.DeviceInterface.PrinterDriverDirectory -- PKEY_DeviceInterface_PrinterDriverDirectory</para>
					/// <para>Description: Printer information Printer Driver Directory.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {847C66DE-B8D6-4AF9-ABC3-6F4F926BC039}, 14</para>
					/// </summary>
					public static PROPERTYKEY PrinterDriverDirectory
						=> new PROPERTYKEY(new Guid("{847C66DE-B8D6-4AF9-ABC3-6F4F926BC039}"), 14);

					/// <summary>
					/// <para>Name:     System.DeviceInterface.PrinterDriverName -- PKEY_DeviceInterface_PrinterDriverName</para>
					/// <para>Description: Printer information Driver Name.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {AFC47170-14F5-498C-8F30-B0D19BE449C6}, 11</para>
					/// </summary>
					public static PROPERTYKEY PrinterDriverName
						=> new PROPERTYKEY(new Guid("{AFC47170-14F5-498C-8F30-B0D19BE449C6}"), 11);

					/// <summary>
					/// <para>Name:     System.DeviceInterface.PrinterName -- PKEY_DeviceInterface_PrinterName</para>
					/// <para>Description: Printer information Printer Name.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {0A7B84EF-0C27-463F-84EF-06C5070001BE}, 10</para>
					/// </summary>
					public static PROPERTYKEY PrinterName
						=> new PROPERTYKEY(new Guid("{0A7B84EF-0C27-463F-84EF-06C5070001BE}"), 10);

					/// <summary>
					/// <para>Name:     System.DeviceInterface.PrinterPortName -- PKEY_DeviceInterface_PrinterPortName</para>
					/// <para>Description: Printer information Port Name.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {EEC7B761-6F94-41B1-949F-C729720DD13C}, 12</para>
					/// </summary>
					public static PROPERTYKEY PrinterPortName
						=> new PROPERTYKEY(new Guid("{EEC7B761-6F94-41B1-949F-C729720DD13C}"), 12);
				}

				/// <summary>Devices Properties</summary>
				public static class Devices
				{
					/// <summary>
					/// <para>Name:     System.Devices.BatteryLife -- PKEY_Devices_BatteryLife</para>
					/// <para>Description: Remaining battery life of the device as an integer between 0 and 100 percent.</para>
					/// <para>Type:     Byte -- VT_UI1</para>
					/// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 10</para>
					/// </summary>
					public static PROPERTYKEY BatteryLife
						=> new PROPERTYKEY(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 10);

					/// <summary>
					/// <para>Name:     System.Devices.BatteryPlusCharging -- PKEY_Devices_BatteryPlusCharging</para>
					/// <para>
					/// Description: Remaining battery life of the device as an integer between 0 and 100 percent and the device's charging state.
					/// </para>
					/// <para>Type:     Byte -- VT_UI1</para>
					/// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 22</para>
					/// </summary>
					public static PROPERTYKEY BatteryPlusCharging
						=> new PROPERTYKEY(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 22);

					/// <summary>
					/// <para>Name:     System.Devices.BatteryPlusChargingText -- PKEY_Devices_BatteryPlusChargingText</para>
					/// <para>Description: Remaining battery life of the device and the device's charging state as a string.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 23</para>
					/// </summary>
					public static PROPERTYKEY BatteryPlusChargingText
						=> new PROPERTYKEY(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 23);

					/// <summary>
					/// <para>Name:     System.Devices.Category -- PKEY_Devices_Category_Desc_Singular</para>
					/// <para>Description: Singular form of device category.</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 91</para>
					/// </summary>
					public static PROPERTYKEY Category
						=> new PROPERTYKEY(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 91);

					/// <summary>
					/// <para>Name:     System.Devices.CategoryGroup -- PKEY_Devices_CategoryGroup_Desc</para>
					/// <para>Description: Plural form of device category.</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 94</para>
					/// </summary>
					public static PROPERTYKEY CategoryGroup
						=> new PROPERTYKEY(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 94);

					/// <summary>
					/// <para>Name:     System.Devices.CategoryPlural -- PKEY_Devices_Category_Desc_Plural</para>
					/// <para>Description: Plural form of device category.</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 92</para>
					/// </summary>
					public static PROPERTYKEY CategoryPlural
						=> new PROPERTYKEY(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 92);

					/// <summary>
					/// <para>Name:     System.Devices.ChargingState -- PKEY_Devices_ChargingState</para>
					/// <para>Description: Boolean value representing if the device is currently charging.</para>
					/// <para>Type:     Byte -- VT_UI1</para>
					/// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 11</para>
					/// </summary>
					public static PROPERTYKEY ChargingState
						=> new PROPERTYKEY(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 11);

					/// <summary>
					/// <para>Name:     System.Devices.Connected -- PKEY_Devices_IsConnected</para>
					/// <para>
					/// Description: Device connection state. If VARIANT_TRUE, indicates the device is currently connected to the computer.
					/// </para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 55</para>
					/// </summary>
					public static PROPERTYKEY Connected
						=> new PROPERTYKEY(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 55);

					/// <summary>
					/// <para>Name:     System.Devices.ContainerId -- PKEY_Devices_ContainerId</para>
					/// <para>Description: Device container ID.</para>
					/// <para>Type:     Guid -- VT_CLSID</para>
					/// <para>FormatID: {8C7ED206-3F8A-4827-B3AB-AE9E1FAEFC6C}, 2</para>
					/// </summary>
					public static PROPERTYKEY ContainerId
						=> new PROPERTYKEY(new Guid("{8C7ED206-3F8A-4827-B3AB-AE9E1FAEFC6C}"), 2);

					/// <summary>
					/// <para>Name:     System.Devices.DefaultTooltip -- PKEY_Devices_DefaultTooltip</para>
					/// <para>Description: Tooltip for default state</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {880F70A2-6082-47AC-8AAB-A739D1A300C3}, 153</para>
					/// </summary>
					public static PROPERTYKEY DefaultTooltip
						=> new PROPERTYKEY(new Guid("{880F70A2-6082-47AC-8AAB-A739D1A300C3}"), 153);

					/// <summary>
					/// <para>Name:     System.Devices.DeviceDescription1 -- PKEY_Devices_DeviceDescription1</para>
					/// <para>Description: First line of descriptive text about the device.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 81</para>
					/// </summary>
					public static PROPERTYKEY DeviceDescription1
						=> new PROPERTYKEY(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 81);

					/// <summary>
					/// <para>Name:     System.Devices.DeviceDescription2 -- PKEY_Devices_DeviceDescription2</para>
					/// <para>Description: Second line of descriptive text about the device.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 82</para>
					/// </summary>
					public static PROPERTYKEY DeviceDescription2
						=> new PROPERTYKEY(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 82);

					/// <summary>
					/// <para>Name:     System.Devices.DiscoveryMethod -- PKEY_Devices_DiscoveryMethod</para>
					/// <para>
					/// Description: Device discovery method. This indicates on what transport or physical connection the device is discovered.
					/// </para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 52</para>
					/// </summary>
					public static PROPERTYKEY DiscoveryMethod
						=> new PROPERTYKEY(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 52);

					/// <summary>
					/// <para>Name:     System.Devices.FriendlyName -- PKEY_Devices_FriendlyName</para>
					/// <para>Description: Device friendly name.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {656A3BB3-ECC0-43FD-8477-4AE0404A96CD}, 12288</para>
					/// </summary>
					public static PROPERTYKEY FriendlyName
						=> new PROPERTYKEY(new Guid("{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}"), 12288);

					/// <summary>
					/// <para>Name:     System.Devices.FunctionPaths -- PKEY_Devices_FunctionPaths</para>
					/// <para>Description: Available functions for this device.</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {D08DD4C0-3A9E-462E-8290-7B636B2576B9}, 3</para>
					/// </summary>
					public static PROPERTYKEY FunctionPaths
						=> new PROPERTYKEY(new Guid("{D08DD4C0-3A9E-462E-8290-7B636B2576B9}"), 3);

					/// <summary>
					/// <para>Name:     System.Devices.InterfacePaths -- PKEY_Devices_InterfacePaths</para>
					/// <para>Description: Available interfaces for this device.</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {D08DD4C0-3A9E-462E-8290-7B636B2576B9}, 2</para>
					/// </summary>
					public static PROPERTYKEY InterfacePaths
						=> new PROPERTYKEY(new Guid("{D08DD4C0-3A9E-462E-8290-7B636B2576B9}"), 2);

					/// <summary>
					/// <para>Name:     System.Devices.IsDefault -- PKEY_Devices_IsDefaultDevice</para>
					/// <para>Description: If VARIANT_TRUE, the device is not working properly.</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 86</para>
					/// </summary>
					public static PROPERTYKEY IsDefault
						=> new PROPERTYKEY(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 86);

					/// <summary>
					/// <para>Name:     System.Devices.IsNetworkConnected -- PKEY_Devices_IsNetworkDevice</para>
					/// <para>Description: If VARIANT_TRUE, the device is not working properly.</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 85</para>
					/// </summary>
					public static PROPERTYKEY IsNetworkConnected
						=> new PROPERTYKEY(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 85);

					/// <summary>
					/// <para>Name:     System.Devices.IsShared -- PKEY_Devices_IsSharedDevice</para>
					/// <para>Description: If VARIANT_TRUE, the device is not working properly.</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 84</para>
					/// </summary>
					public static PROPERTYKEY IsShared
						=> new PROPERTYKEY(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 84);

					/// <summary>
					/// <para>Name:     System.Devices.IsSoftwareInstalling -- PKEY_Devices_IsSoftwareInstalling</para>
					/// <para>Description: If VARIANT_TRUE, the device installer is currently installing software.</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {83DA6326-97A6-4088-9453-A1923F573B29}, 9</para>
					/// </summary>
					public static PROPERTYKEY IsSoftwareInstalling
						=> new PROPERTYKEY(new Guid("{83DA6326-97A6-4088-9453-A1923F573B29}"), 9);

					/// <summary>
					/// <para>Name:     System.Devices.LaunchDeviceStageFromExplorer -- PKEY_Devices_LaunchDeviceStageFromExplorer</para>
					/// <para>Description: Indicates whether to launch Device Stage or not</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 77</para>
					/// </summary>
					public static PROPERTYKEY LaunchDeviceStageFromExplorer
						=> new PROPERTYKEY(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 77);

					/// <summary>
					/// <para>Name:     System.Devices.LocalMachine -- PKEY_Devices_IsLocalMachine</para>
					/// <para>Description: If VARIANT_TRUE, the device in question is actually the computer.</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 70</para>
					/// </summary>
					public static PROPERTYKEY LocalMachine
						=> new PROPERTYKEY(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 70);

					/// <summary>
					/// <para>Name:     System.Devices.Manufacturer -- PKEY_Devices_Manufacturer</para>
					/// <para>Description: Device manufacturer.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {656A3BB3-ECC0-43FD-8477-4AE0404A96CD}, 8192</para>
					/// </summary>
					public static PROPERTYKEY Manufacturer
						=> new PROPERTYKEY(new Guid("{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}"), 8192);

					/// <summary>
					/// <para>Name:     System.Devices.MissedCalls -- PKEY_Devices_MissedCalls</para>
					/// <para>Description: Number of missed calls on the device.</para>
					/// <para>Type:     Byte -- VT_UI1</para>
					/// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 5</para>
					/// </summary>
					public static PROPERTYKEY MissedCalls
						=> new PROPERTYKEY(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 5);

					/// <summary>
					/// <para>Name:     System.Devices.ModelName -- PKEY_Devices_ModelName</para>
					/// <para>Description: Model name of the device.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {656A3BB3-ECC0-43FD-8477-4AE0404A96CD}, 8194</para>
					/// </summary>
					public static PROPERTYKEY ModelName
						=> new PROPERTYKEY(new Guid("{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}"), 8194);

					/// <summary>
					/// <para>Name:     System.Devices.ModelNumber -- PKEY_Devices_ModelNumber</para>
					/// <para>Description: Model number of the device.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {656A3BB3-ECC0-43FD-8477-4AE0404A96CD}, 8195</para>
					/// </summary>
					public static PROPERTYKEY ModelNumber
						=> new PROPERTYKEY(new Guid("{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}"), 8195);

					/// <summary>
					/// <para>Name:     System.Devices.NetworkedTooltip -- PKEY_Devices_NetworkedTooltip</para>
					/// <para>Description: Tooltip for connection state</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {880F70A2-6082-47AC-8AAB-A739D1A300C3}, 152</para>
					/// </summary>
					public static PROPERTYKEY NetworkedTooltip
						=> new PROPERTYKEY(new Guid("{880F70A2-6082-47AC-8AAB-A739D1A300C3}"), 152);

					/// <summary>
					/// <para>Name:     System.Devices.NetworkName -- PKEY_Devices_NetworkName</para>
					/// <para>Description: Name of the device's network.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 7</para>
					/// </summary>
					public static PROPERTYKEY NetworkName
						=> new PROPERTYKEY(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 7);

					/// <summary>
					/// <para>Name:     System.Devices.NetworkType -- PKEY_Devices_NetworkType</para>
					/// <para>Description: String representing the type of the device's network.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 8</para>
					/// </summary>
					public static PROPERTYKEY NetworkType
						=> new PROPERTYKEY(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 8);

					/// <summary>
					/// <para>Name:     System.Devices.NewPictures -- PKEY_Devices_NewPictures</para>
					/// <para>Description: Number of new pictures on the device.</para>
					/// <para>Type:     UInt16 -- VT_UI2</para>
					/// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 4</para>
					/// </summary>
					public static PROPERTYKEY NewPictures
						=> new PROPERTYKEY(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 4);

					/// <summary>
					/// <para>Name:     System.Devices.Notification -- PKEY_Devices_Notification</para>
					/// <para>Description: Device Notification Property.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {06704B0C-E830-4C81-9178-91E4E95A80A0}, 3</para>
					/// </summary>
					public static PROPERTYKEY Notification
						=> new PROPERTYKEY(new Guid("{06704B0C-E830-4C81-9178-91E4E95A80A0}"), 3);

					/// <summary>
					/// <para>Name:     System.Devices.NotificationStore -- PKEY_Devices_NotificationStore</para>
					/// <para>Description: Device Notification Store.</para>
					/// <para>Type:     Object -- VT_UNKNOWN</para>
					/// <para>FormatID: {06704B0C-E830-4C81-9178-91E4E95A80A0}, 2</para>
					/// </summary>
					public static PROPERTYKEY NotificationStore
						=> new PROPERTYKEY(new Guid("{06704B0C-E830-4C81-9178-91E4E95A80A0}"), 2);

					/// <summary>
					/// <para>Name:     System.Devices.NotWorkingProperly -- PKEY_Devices_IsNotWorkingProperly</para>
					/// <para>Description: If VARIANT_TRUE, the device is not working properly.</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 83</para>
					/// </summary>
					public static PROPERTYKEY NotWorkingProperly
						=> new PROPERTYKEY(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 83);

					/// <summary>
					/// <para>Name:     System.Devices.Paired -- PKEY_Devices_IsPaired</para>
					/// <para>Description: Device paired state. If VARIANT_TRUE, indicates the device is not paired with the computer.</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {78C34FC8-104A-4ACA-9EA4-524D52996E57}, 56</para>
					/// </summary>
					public static PROPERTYKEY Paired
						=> new PROPERTYKEY(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 56);

					/// <summary>
					/// <para>Name:     System.Devices.PrimaryCategory -- PKEY_Devices_PrimaryCategory</para>
					/// <para>Description: Primary category group for this device.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {D08DD4C0-3A9E-462E-8290-7B636B2576B9}, 10</para>
					/// </summary>
					public static PROPERTYKEY PrimaryCategory
						=> new PROPERTYKEY(new Guid("{D08DD4C0-3A9E-462E-8290-7B636B2576B9}"), 10);

					/// <summary>
					/// <para>Name:     System.Devices.Roaming -- PKEY_Devices_Roaming</para>
					/// <para>Description: Status indicator used to indicate if the device is roaming.</para>
					/// <para>Type:     Byte -- VT_UI1</para>
					/// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 9</para>
					/// </summary>
					public static PROPERTYKEY Roaming
						=> new PROPERTYKEY(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 9);

					/// <summary>
					/// <para>Name:     System.Devices.SafeRemovalRequired -- PKEY_Devices_SafeRemovalRequired</para>
					/// <para>Description: Indicates if a device requires safe removal or not</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {AFD97640-86A3-4210-B67C-289C41AABE55}, 2</para>
					/// </summary>
					public static PROPERTYKEY SafeRemovalRequired
						=> new PROPERTYKEY(new Guid("{AFD97640-86A3-4210-B67C-289C41AABE55}"), 2);

					/// <summary>
					/// <para>Name:     System.Devices.SharedTooltip -- PKEY_Devices_SharedTooltip</para>
					/// <para>Description: Tooltip for sharing state</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {880F70A2-6082-47AC-8AAB-A739D1A300C3}, 151</para>
					/// </summary>
					public static PROPERTYKEY SharedTooltip
						=> new PROPERTYKEY(new Guid("{880F70A2-6082-47AC-8AAB-A739D1A300C3}"), 151);

					/// <summary>
					/// <para>Name:     System.Devices.SignalStrength -- PKEY_Devices_SignalStrength</para>
					/// <para>Description: Device signal strength.</para>
					/// <para>Type:     Byte -- VT_UI1</para>
					/// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 2</para>
					/// </summary>
					public static PROPERTYKEY SignalStrength
						=> new PROPERTYKEY(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 2);

					/// <summary>
					/// <para>Name:     System.Devices.Status1 -- PKEY_Devices_Status1</para>
					/// <para>Description: 1st line of device status.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {D08DD4C0-3A9E-462E-8290-7B636B2576B9}, 257</para>
					/// </summary>
					public static PROPERTYKEY Status1
						=> new PROPERTYKEY(new Guid("{D08DD4C0-3A9E-462E-8290-7B636B2576B9}"), 257);

					/// <summary>
					/// <para>Name:     System.Devices.Status2 -- PKEY_Devices_Status2</para>
					/// <para>Description: 2nd line of device status.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {D08DD4C0-3A9E-462E-8290-7B636B2576B9}, 258</para>
					/// </summary>
					public static PROPERTYKEY Status2
						=> new PROPERTYKEY(new Guid("{D08DD4C0-3A9E-462E-8290-7B636B2576B9}"), 258);

					/// <summary>
					/// <para>Name:     System.Devices.StorageCapacity -- PKEY_Devices_StorageCapacity</para>
					/// <para>Description: Total storage capacity of the device.</para>
					/// <para>Type:     UInt64 -- VT_UI8</para>
					/// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 12</para>
					/// </summary>
					public static PROPERTYKEY StorageCapacity
						=> new PROPERTYKEY(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 12);

					/// <summary>
					/// <para>Name:     System.Devices.StorageFreeSpace -- PKEY_Devices_StorageFreeSpace</para>
					/// <para>Description: Total free space of the storage of the device.</para>
					/// <para>Type:     UInt64 -- VT_UI8</para>
					/// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 13</para>
					/// </summary>
					public static PROPERTYKEY StorageFreeSpace
						=> new PROPERTYKEY(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 13);

					/// <summary>
					/// <para>Name:     System.Devices.StorageFreeSpacePercent -- PKEY_Devices_StorageFreeSpacePercent</para>
					/// <para>Description: Total free space of the storage of the device as a percentage.</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 14</para>
					/// </summary>
					public static PROPERTYKEY StorageFreeSpacePercent
						=> new PROPERTYKEY(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 14);

					/// <summary>
					/// <para>Name:     System.Devices.TextMessages -- PKEY_Devices_TextMessages</para>
					/// <para>Description: Number of unread text messages on the device.</para>
					/// <para>Type:     Byte -- VT_UI1</para>
					/// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 3</para>
					/// </summary>
					public static PROPERTYKEY TextMessages
						=> new PROPERTYKEY(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 3);

					/// <summary>
					/// <para>Name:     System.Devices.Voicemail -- PKEY_Devices_Voicemail</para>
					/// <para>Description: Status indicator used to indicate if the device has voicemail.</para>
					/// <para>Type:     Byte -- VT_UI1</para>
					/// <para>FormatID: {49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 6</para>
					/// </summary>
					public static PROPERTYKEY Voicemail
						=> new PROPERTYKEY(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 6);

					/// <summary>Notifications Properties</summary>
					public static class Notifications
					{
						/// <summary>
						/// <para>Name:     System.Devices.Notifications.LowBattery -- PKEY_Devices_Notification_LowBattery</para>
						/// <para>Description: Device Low Battery Notification.</para>
						/// <para>Type:     Byte -- VT_UI1</para>
						/// <para>FormatID: {C4C07F2B-8524-4E66-AE3A-A6235F103BEB}, 2</para>
						/// </summary>
						public static PROPERTYKEY LowBattery
							=> new PROPERTYKEY(new Guid("{C4C07F2B-8524-4E66-AE3A-A6235F103BEB}"), 2);

						/// <summary>
						/// <para>Name:     System.Devices.Notifications.MissedCall -- PKEY_Devices_Notification_MissedCall</para>
						/// <para>Description: Device Missed Call Notification.</para>
						/// <para>Type:     Byte -- VT_UI1</para>
						/// <para>FormatID: {6614EF48-4EFE-4424-9EDA-C79F404EDF3E}, 2</para>
						/// </summary>
						public static PROPERTYKEY MissedCall
							=> new PROPERTYKEY(new Guid("{6614EF48-4EFE-4424-9EDA-C79F404EDF3E}"), 2);

						/// <summary>
						/// <para>Name:     System.Devices.Notifications.NewMessage -- PKEY_Devices_Notification_NewMessage</para>
						/// <para>Description: Device New Message Notification.</para>
						/// <para>Type:     Byte -- VT_UI1</para>
						/// <para>FormatID: {2BE9260A-2012-4742-A555-F41B638B7DCB}, 2</para>
						/// </summary>
						public static PROPERTYKEY NewMessage
							=> new PROPERTYKEY(new Guid("{2BE9260A-2012-4742-A555-F41B638B7DCB}"), 2);

						/// <summary>
						/// <para>Name:     System.Devices.Notifications.NewVoicemail -- PKEY_Devices_Notification_NewVoicemail</para>
						/// <para>Description: Device Voicemail Notification.</para>
						/// <para>Type:     Byte -- VT_UI1</para>
						/// <para>FormatID: {59569556-0A08-4212-95B9-FAE2AD6413DB}, 2</para>
						/// </summary>
						public static PROPERTYKEY NewVoicemail
							=> new PROPERTYKEY(new Guid("{59569556-0A08-4212-95B9-FAE2AD6413DB}"), 2);

						/// <summary>
						/// <para>Name:     System.Devices.Notifications.StorageFull -- PKEY_Devices_Notification_StorageFull</para>
						/// <para>Description: Device Storage Full Notification.</para>
						/// <para>Type:     UInt64 -- VT_UI8</para>
						/// <para>FormatID: {A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}, 2</para>
						/// </summary>
						public static PROPERTYKEY StorageFull
							=> new PROPERTYKEY(new Guid("{A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}"), 2);

						/// <summary>
						/// <para>Name:     System.Devices.Notifications.StorageFullLinkText -- PKEY_Devices_Notification_StorageFullLinkText</para>
						/// <para>Description: Link Text for the Device Storage Full Notification.</para>
						/// <para>Type:     UInt64 -- VT_UI8</para>
						/// <para>FormatID: {A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}, 3</para>
						/// </summary>
						public static PROPERTYKEY StorageFullLinkText
							=> new PROPERTYKEY(new Guid("{A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}"), 3);
					}
				}

				/// <summary>Document Properties</summary>
				public static class Document
				{
					/// <summary>
					/// <para>Name:     System.Document.ByteCount -- PKEY_Document_ByteCount</para>
					/// <para>Description:</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 4 (PIDDSI_BYTECOUNT)</para>
					/// </summary>
					public static PROPERTYKEY ByteCount
						=> new PROPERTYKEY(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 4);

					/// <summary>
					/// <para>Name:     System.Document.CharacterCount -- PKEY_Document_CharacterCount</para>
					/// <para>Description:</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 16 (PIDSI_CHARCOUNT)</para>
					/// </summary>
					public static PROPERTYKEY CharacterCount
						=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 16);

					/// <summary>
					/// <para>Name:     System.Document.ClientID -- PKEY_Document_ClientID</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {276D7BB0-5B34-4FB0-AA4B-158ED12A1809}, 100</para>
					/// </summary>
					public static PROPERTYKEY ClientID
						=> new PROPERTYKEY(new Guid("{276D7BB0-5B34-4FB0-AA4B-158ED12A1809}"), 100);

					/// <summary>
					/// <para>Name:     System.Document.Contributor -- PKEY_Document_Contributor</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {F334115E-DA1B-4509-9B3D-119504DC7ABB}, 100</para>
					/// </summary>
					public static PROPERTYKEY Contributor
						=> new PROPERTYKEY(new Guid("{F334115E-DA1B-4509-9B3D-119504DC7ABB}"), 100);

					/// <summary>
					/// <para>Name:     System.Document.DateCreated -- PKEY_Document_DateCreated</para>
					/// <para>Description: This property is stored in the document, not obtained from the file system.</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 12 (PIDSI_CREATE_DTM)</para>
					/// </summary>
					public static PROPERTYKEY DateCreated
						=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 12);

					/// <summary>
					/// <para>Name:     System.Document.DatePrinted -- PKEY_Document_DatePrinted</para>
					/// <para>Description: Legacy name: "DocLastPrinted".</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 11 (PIDSI_LASTPRINTED)</para>
					/// </summary>
					public static PROPERTYKEY DatePrinted
						=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 11);

					/// <summary>
					/// <para>Name:     System.Document.DateSaved -- PKEY_Document_DateSaved</para>
					/// <para>Description: Legacy name: "DocLastSavedTm".</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 13 (PIDSI_LASTSAVE_DTM)</para>
					/// </summary>
					public static PROPERTYKEY DateSaved
						=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 13);

					/// <summary>
					/// <para>Name:     System.Document.Division -- PKEY_Document_Division</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {1E005EE6-BF27-428B-B01C-79676ACD2870}, 100</para>
					/// </summary>
					public static PROPERTYKEY Division
						=> new PROPERTYKEY(new Guid("{1E005EE6-BF27-428B-B01C-79676ACD2870}"), 100);

					/// <summary>
					/// <para>Name:     System.Document.DocumentID -- PKEY_Document_DocumentID</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {E08805C8-E395-40DF-80D2-54F0D6C43154}, 100</para>
					/// </summary>
					public static PROPERTYKEY DocumentID
						=> new PROPERTYKEY(new Guid("{E08805C8-E395-40DF-80D2-54F0D6C43154}"), 100);

					/// <summary>
					/// <para>Name:     System.Document.HiddenSlideCount -- PKEY_Document_HiddenSlideCount</para>
					/// <para>Description:</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 9 (PIDDSI_HIDDENCOUNT)</para>
					/// </summary>
					public static PROPERTYKEY HiddenSlideCount
						=> new PROPERTYKEY(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 9);

					/// <summary>
					/// <para>Name:     System.Document.LastAuthor -- PKEY_Document_LastAuthor</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 8 (PIDSI_LASTAUTHOR)</para>
					/// </summary>
					public static PROPERTYKEY LastAuthor
						=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 8);

					/// <summary>
					/// <para>Name:     System.Document.LineCount -- PKEY_Document_LineCount</para>
					/// <para>Description:</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 5 (PIDDSI_LINECOUNT)</para>
					/// </summary>
					public static PROPERTYKEY LineCount
						=> new PROPERTYKEY(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 5);

					/// <summary>
					/// <para>Name:     System.Document.Manager -- PKEY_Document_Manager</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 14 (PIDDSI_MANAGER)</para>
					/// </summary>
					public static PROPERTYKEY Manager
						=> new PROPERTYKEY(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 14);

					/// <summary>
					/// <para>Name:     System.Document.MultimediaClipCount -- PKEY_Document_MultimediaClipCount</para>
					/// <para>Description:</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 10 (PIDDSI_MMCLIPCOUNT)</para>
					/// </summary>
					public static PROPERTYKEY MultimediaClipCount
						=> new PROPERTYKEY(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 10);

					/// <summary>
					/// <para>Name:     System.Document.NoteCount -- PKEY_Document_NoteCount</para>
					/// <para>Description:</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 8 (PIDDSI_NOTECOUNT)</para>
					/// </summary>
					public static PROPERTYKEY NoteCount
						=> new PROPERTYKEY(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 8);

					/// <summary>
					/// <para>Name:     System.Document.PageCount -- PKEY_Document_PageCount</para>
					/// <para>Description:</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 14 (PIDSI_PAGECOUNT)</para>
					/// </summary>
					public static PROPERTYKEY PageCount
						=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 14);

					/// <summary>
					/// <para>Name:     System.Document.ParagraphCount -- PKEY_Document_ParagraphCount</para>
					/// <para>Description:</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 6 (PIDDSI_PARCOUNT)</para>
					/// </summary>
					public static PROPERTYKEY ParagraphCount
						=> new PROPERTYKEY(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 6);

					/// <summary>
					/// <para>Name:     System.Document.PresentationFormat -- PKEY_Document_PresentationFormat</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 3 (PIDDSI_PRESFORMAT)</para>
					/// </summary>
					public static PROPERTYKEY PresentationFormat
						=> new PROPERTYKEY(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 3);

					/// <summary>
					/// <para>Name:     System.Document.RevisionNumber -- PKEY_Document_RevisionNumber</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 9 (PIDSI_REVNUMBER)</para>
					/// </summary>
					public static PROPERTYKEY RevisionNumber
						=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 9);

					/// <summary>
					/// <para>Name:     System.Document.Security -- PKEY_Document_Security</para>
					/// <para>Description: Access control information, from SummaryInfo propset</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 19</para>
					/// </summary>
					public static PROPERTYKEY Security
						=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 19);

					/// <summary>
					/// <para>Name:     System.Document.SlideCount -- PKEY_Document_SlideCount</para>
					/// <para>Description:</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 7 (PIDDSI_SLIDECOUNT)</para>
					/// </summary>
					public static PROPERTYKEY SlideCount
						=> new PROPERTYKEY(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 7);

					/// <summary>
					/// <para>Name:     System.Document.Template -- PKEY_Document_Template</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 7 (PIDSI_TEMPLATE)</para>
					/// </summary>
					public static PROPERTYKEY Template
						=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 7);

					/// <summary>
					/// <para>Name:     System.Document.TotalEditingTime -- PKEY_Document_TotalEditingTime</para>
					/// <para>Description: 100ns units, not milliseconds. VT_FILETIME for IPropertySetStorage handlers (legacy)</para>
					/// <para>Type:     UInt64 -- VT_UI8</para>
					/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 10 (PIDSI_EDITTIME)</para>
					/// </summary>
					public static PROPERTYKEY TotalEditingTime
						=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 10);

					/// <summary>
					/// <para>Name:     System.Document.Version -- PKEY_Document_Version</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_DocumentSummaryInformation) {D5CDD502-2E9C-101B-9397-08002B2CF9AE}, 29</para>
					/// </summary>
					public static PROPERTYKEY Version
						=> new PROPERTYKEY(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 29);

					/// <summary>
					/// <para>Name:     System.Document.WordCount -- PKEY_Document_WordCount</para>
					/// <para>Description:</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: (FMTID_SummaryInformation) {F29F85E0-4FF9-1068-AB91-08002B27B3D9}, 15 (PIDSI_WORDCOUNT)</para>
					/// </summary>
					public static PROPERTYKEY WordCount
						=> new PROPERTYKEY(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 15);
				}

				/// <summary>DRM Properties</summary>
				public static class DRM
				{
					/// <summary>
					/// <para>Name:     System.DRM.DatePlayExpires -- PKEY_DRM_DatePlayExpires</para>
					/// <para>Description: Indicates when play expires for digital rights management.</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: (FMTID_DRM) {AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}, 6 (PIDDRSI_PLAYEXPIRES)</para>
					/// </summary>
					public static PROPERTYKEY DatePlayExpires
						=> new PROPERTYKEY(new Guid("{AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}"), 6);

					/// <summary>
					/// <para>Name:     System.DRM.DatePlayStarts -- PKEY_DRM_DatePlayStarts</para>
					/// <para>Description: Indicates when play starts for digital rights management.</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: (FMTID_DRM) {AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}, 5 (PIDDRSI_PLAYSTARTS)</para>
					/// </summary>
					public static PROPERTYKEY DatePlayStarts
						=> new PROPERTYKEY(new Guid("{AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}"), 5);

					/// <summary>
					/// <para>Name:     System.DRM.Description -- PKEY_DRM_Description</para>
					/// <para>Description: Displays the description for digital rights management.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_DRM) {AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}, 3 (PIDDRSI_DESCRIPTION)</para>
					/// </summary>
					public static PROPERTYKEY Description
						=> new PROPERTYKEY(new Guid("{AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}"), 3);

					/// <summary>
					/// <para>Name:     System.DRM.IsProtected -- PKEY_DRM_IsProtected</para>
					/// <para>Description:</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: (FMTID_DRM) {AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}, 2 (PIDDRSI_PROTECTED)</para>
					/// </summary>
					public static PROPERTYKEY IsProtected
						=> new PROPERTYKEY(new Guid("{AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}"), 2);

					/// <summary>
					/// <para>Name:     System.DRM.PlayCount -- PKEY_DRM_PlayCount</para>
					/// <para>Description: Indicates the play count for digital rights management.</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_DRM) {AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}, 4 (PIDDRSI_PLAYCOUNT)</para>
					/// </summary>
					public static PROPERTYKEY PlayCount
						=> new PROPERTYKEY(new Guid("{AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}"), 4);
				}

				/// <summary>GPS Properties</summary>
				public static class GPS
				{
					/// <summary>
					/// <para>Name:     System.GPS.Altitude -- PKEY_GPS_Altitude</para>
					/// <para>
					/// Description: Indicates the altitude based on the reference in PKEY_GPS_AltitudeRef. Calculated from
					/// PKEY_GPS_AltitudeNumerator and PKEY_GPS_AltitudeDenominator
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: {827EDB4F-5B73-44A7-891D-FDFFABEA35CA}, 100</para>
					/// </summary>
					public static PROPERTYKEY Altitude
						=> new PROPERTYKEY(new Guid("{827EDB4F-5B73-44A7-891D-FDFFABEA35CA}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.AltitudeDenominator -- PKEY_GPS_AltitudeDenominator</para>
					/// <para>Description: Denominator of PKEY_GPS_Altitude</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {78342DCB-E358-4145-AE9A-6BFE4E0F9F51}, 100</para>
					/// </summary>
					public static PROPERTYKEY AltitudeDenominator
						=> new PROPERTYKEY(new Guid("{78342DCB-E358-4145-AE9A-6BFE4E0F9F51}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.AltitudeNumerator -- PKEY_GPS_AltitudeNumerator</para>
					/// <para>Description: Numerator of PKEY_GPS_Altitude</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {2DAD1EB7-816D-40D3-9EC3-C9773BE2AADE}, 100</para>
					/// </summary>
					public static PROPERTYKEY AltitudeNumerator
						=> new PROPERTYKEY(new Guid("{2DAD1EB7-816D-40D3-9EC3-C9773BE2AADE}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.AltitudeRef -- PKEY_GPS_AltitudeRef</para>
					/// <para>
					/// Description: Indicates the reference for the altitude property. (eg: above sea level, below sea level, absolute value)
					/// </para>
					/// <para>Type:     Byte -- VT_UI1</para>
					/// <para>FormatID: {46AC629D-75EA-4515-867F-6DC4321C5844}, 100</para>
					/// </summary>
					public static PROPERTYKEY AltitudeRef
						=> new PROPERTYKEY(new Guid("{46AC629D-75EA-4515-867F-6DC4321C5844}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.AreaInformation -- PKEY_GPS_AreaInformation</para>
					/// <para>Description: Represents the name of the GPS area</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {972E333E-AC7E-49F1-8ADF-A70D07A9BCAB}, 100</para>
					/// </summary>
					public static PROPERTYKEY AreaInformation
						=> new PROPERTYKEY(new Guid("{972E333E-AC7E-49F1-8ADF-A70D07A9BCAB}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.Date -- PKEY_GPS_Date</para>
					/// <para>Description: Date and time of the GPS record</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: {3602C812-0F3B-45F0-85AD-603468D69423}, 100</para>
					/// </summary>
					public static PROPERTYKEY Date
						=> new PROPERTYKEY(new Guid("{3602C812-0F3B-45F0-85AD-603468D69423}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DestBearing -- PKEY_GPS_DestBearing</para>
					/// <para>
					/// Description: Indicates the bearing to the destination point. Calculated from PKEY_GPS_DestBearingNumerator and PKEY_GPS_DestBearingDenominator.
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: {C66D4B3C-E888-47CC-B99F-9DCA3EE34DEA}, 100</para>
					/// </summary>
					public static PROPERTYKEY DestBearing
						=> new PROPERTYKEY(new Guid("{C66D4B3C-E888-47CC-B99F-9DCA3EE34DEA}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DestBearingDenominator -- PKEY_GPS_DestBearingDenominator</para>
					/// <para>Description: Denominator of PKEY_GPS_DestBearing</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {7ABCF4F8-7C3F-4988-AC91-8D2C2E97ECA5}, 100</para>
					/// </summary>
					public static PROPERTYKEY DestBearingDenominator
						=> new PROPERTYKEY(new Guid("{7ABCF4F8-7C3F-4988-AC91-8D2C2E97ECA5}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DestBearingNumerator -- PKEY_GPS_DestBearingNumerator</para>
					/// <para>Description: Numerator of PKEY_GPS_DestBearing</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {BA3B1DA9-86EE-4B5D-A2A4-A271A429F0CF}, 100</para>
					/// </summary>
					public static PROPERTYKEY DestBearingNumerator
						=> new PROPERTYKEY(new Guid("{BA3B1DA9-86EE-4B5D-A2A4-A271A429F0CF}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DestBearingRef -- PKEY_GPS_DestBearingRef</para>
					/// <para>
					/// Description: Indicates the reference used for the giving the bearing to the destination point. (eg: true direction,
					/// magnetic direction)
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {9AB84393-2A0F-4B75-BB22-7279786977CB}, 100</para>
					/// </summary>
					public static PROPERTYKEY DestBearingRef
						=> new PROPERTYKEY(new Guid("{9AB84393-2A0F-4B75-BB22-7279786977CB}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DestDistance -- PKEY_GPS_DestDistance</para>
					/// <para>
					/// Description: Indicates the distance to the destination point. Calculated from PKEY_GPS_DestDistanceNumerator and PKEY_GPS_DestDistanceDenominator.
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: {A93EAE04-6804-4F24-AC81-09B266452118}, 100</para>
					/// </summary>
					public static PROPERTYKEY DestDistance
						=> new PROPERTYKEY(new Guid("{A93EAE04-6804-4F24-AC81-09B266452118}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DestDistanceDenominator -- PKEY_GPS_DestDistanceDenominator</para>
					/// <para>Description: Denominator of PKEY_GPS_DestDistance</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {9BC2C99B-AC71-4127-9D1C-2596D0D7DCB7}, 100</para>
					/// </summary>
					public static PROPERTYKEY DestDistanceDenominator
						=> new PROPERTYKEY(new Guid("{9BC2C99B-AC71-4127-9D1C-2596D0D7DCB7}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DestDistanceNumerator -- PKEY_GPS_DestDistanceNumerator</para>
					/// <para>Description: Numerator of PKEY_GPS_DestDistance</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {2BDA47DA-08C6-4FE1-80BC-A72FC517C5D0}, 100</para>
					/// </summary>
					public static PROPERTYKEY DestDistanceNumerator
						=> new PROPERTYKEY(new Guid("{2BDA47DA-08C6-4FE1-80BC-A72FC517C5D0}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DestDistanceRef -- PKEY_GPS_DestDistanceRef</para>
					/// <para>
					/// Description: Indicates the unit used to express the distance to the destination. (eg: kilometers, miles, knots)
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {ED4DF2D3-8695-450B-856F-F5C1C53ACB66}, 100</para>
					/// </summary>
					public static PROPERTYKEY DestDistanceRef
						=> new PROPERTYKEY(new Guid("{ED4DF2D3-8695-450B-856F-F5C1C53ACB66}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DestLatitude -- PKEY_GPS_DestLatitude</para>
					/// <para>
					/// Description: Indicates the latitude of the destination point. This is an array of three values. Index 0 is the
					/// degrees, index 1 is the minutes, index 2 is the seconds. Each is calculated from the values in
					/// PKEY_GPS_DestLatitudeNumerator and PKEY_GPS_DestLatitudeDenominator.
					/// </para>
					/// <para>Type:     Multivalue Double -- VT_VECTOR | VT_R8 (For variants: VT_ARRAY | VT_R8)</para>
					/// <para>FormatID: {9D1D7CC5-5C39-451C-86B3-928E2D18CC47}, 100</para>
					/// </summary>
					public static PROPERTYKEY DestLatitude
						=> new PROPERTYKEY(new Guid("{9D1D7CC5-5C39-451C-86B3-928E2D18CC47}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DestLatitudeDenominator -- PKEY_GPS_DestLatitudeDenominator</para>
					/// <para>Description: Denominator of PKEY_GPS_DestLatitude</para>
					/// <para>Type:     Multivalue UInt32 -- VT_VECTOR | VT_UI4 (For variants: VT_ARRAY | VT_UI4)</para>
					/// <para>FormatID: {3A372292-7FCA-49A7-99D5-E47BB2D4E7AB}, 100</para>
					/// </summary>
					public static PROPERTYKEY DestLatitudeDenominator
						=> new PROPERTYKEY(new Guid("{3A372292-7FCA-49A7-99D5-E47BB2D4E7AB}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DestLatitudeNumerator -- PKEY_GPS_DestLatitudeNumerator</para>
					/// <para>Description: Numerator of PKEY_GPS_DestLatitude</para>
					/// <para>Type:     Multivalue UInt32 -- VT_VECTOR | VT_UI4 (For variants: VT_ARRAY | VT_UI4)</para>
					/// <para>FormatID: {ECF4B6F6-D5A6-433C-BB92-4076650FC890}, 100</para>
					/// </summary>
					public static PROPERTYKEY DestLatitudeNumerator
						=> new PROPERTYKEY(new Guid("{ECF4B6F6-D5A6-433C-BB92-4076650FC890}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DestLatitudeRef -- PKEY_GPS_DestLatitudeRef</para>
					/// <para>Description: Indicates whether the latitude destination point is north or south latitude</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {CEA820B9-CE61-4885-A128-005D9087C192}, 100</para>
					/// </summary>
					public static PROPERTYKEY DestLatitudeRef
						=> new PROPERTYKEY(new Guid("{CEA820B9-CE61-4885-A128-005D9087C192}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DestLongitude -- PKEY_GPS_DestLongitude</para>
					/// <para>
					/// Description: Indicates the latitude of the destination point. This is an array of three values. Index 0 is the
					/// degrees, index 1 is the minutes, index 2 is the seconds. Each is calculated from the values in
					/// PKEY_GPS_DestLongitudeNumerator and PKEY_GPS_DestLongitudeDenominator.
					/// </para>
					/// <para>Type:     Multivalue Double -- VT_VECTOR | VT_R8 (For variants: VT_ARRAY | VT_R8)</para>
					/// <para>FormatID: {47A96261-CB4C-4807-8AD3-40B9D9DBC6BC}, 100</para>
					/// </summary>
					public static PROPERTYKEY DestLongitude
						=> new PROPERTYKEY(new Guid("{47A96261-CB4C-4807-8AD3-40B9D9DBC6BC}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DestLongitudeDenominator -- PKEY_GPS_DestLongitudeDenominator</para>
					/// <para>Description: Denominator of PKEY_GPS_DestLongitude</para>
					/// <para>Type:     Multivalue UInt32 -- VT_VECTOR | VT_UI4 (For variants: VT_ARRAY | VT_UI4)</para>
					/// <para>FormatID: {425D69E5-48AD-4900-8D80-6EB6B8D0AC86}, 100</para>
					/// </summary>
					public static PROPERTYKEY DestLongitudeDenominator
						=> new PROPERTYKEY(new Guid("{425D69E5-48AD-4900-8D80-6EB6B8D0AC86}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DestLongitudeNumerator -- PKEY_GPS_DestLongitudeNumerator</para>
					/// <para>Description: Numerator of PKEY_GPS_DestLongitude</para>
					/// <para>Type:     Multivalue UInt32 -- VT_VECTOR | VT_UI4 (For variants: VT_ARRAY | VT_UI4)</para>
					/// <para>FormatID: {A3250282-FB6D-48D5-9A89-DBCACE75CCCF}, 100</para>
					/// </summary>
					public static PROPERTYKEY DestLongitudeNumerator
						=> new PROPERTYKEY(new Guid("{A3250282-FB6D-48D5-9A89-DBCACE75CCCF}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DestLongitudeRef -- PKEY_GPS_DestLongitudeRef</para>
					/// <para>Description: Indicates whether the longitude destination point is east or west longitude</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {182C1EA6-7C1C-4083-AB4B-AC6C9F4ED128}, 100</para>
					/// </summary>
					public static PROPERTYKEY DestLongitudeRef
						=> new PROPERTYKEY(new Guid("{182C1EA6-7C1C-4083-AB4B-AC6C9F4ED128}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.Differential -- PKEY_GPS_Differential</para>
					/// <para>Description: Indicates whether differential correction was applied to the GPS receiver</para>
					/// <para>Type:     UInt16 -- VT_UI2</para>
					/// <para>FormatID: {AAF4EE25-BD3B-4DD7-BFC4-47F77BB00F6D}, 100</para>
					/// </summary>
					public static PROPERTYKEY Differential
						=> new PROPERTYKEY(new Guid("{AAF4EE25-BD3B-4DD7-BFC4-47F77BB00F6D}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DOP -- PKEY_GPS_DOP</para>
					/// <para>
					/// Description: Indicates the GPS DOP (data degree of precision). Calculated from PKEY_GPS_DOPNumerator and PKEY_GPS_DOPDenominator
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: {0CF8FB02-1837-42F1-A697-A7017AA289B9}, 100</para>
					/// </summary>
					public static PROPERTYKEY DOP
						=> new PROPERTYKEY(new Guid("{0CF8FB02-1837-42F1-A697-A7017AA289B9}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DOPDenominator -- PKEY_GPS_DOPDenominator</para>
					/// <para>Description: Denominator of PKEY_GPS_DOP</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {A0BE94C5-50BA-487B-BD35-0654BE8881ED}, 100</para>
					/// </summary>
					public static PROPERTYKEY DOPDenominator
						=> new PROPERTYKEY(new Guid("{A0BE94C5-50BA-487B-BD35-0654BE8881ED}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.DOPNumerator -- PKEY_GPS_DOPNumerator</para>
					/// <para>Description: Numerator of PKEY_GPS_DOP</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {47166B16-364F-4AA0-9F31-E2AB3DF449C3}, 100</para>
					/// </summary>
					public static PROPERTYKEY DOPNumerator
						=> new PROPERTYKEY(new Guid("{47166B16-364F-4AA0-9F31-E2AB3DF449C3}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.ImgDirection -- PKEY_GPS_ImgDirection</para>
					/// <para>
					/// Description: Indicates direction of the image when it was captured. Calculated from PKEY_GPS_ImgDirectionNumerator
					/// and PKEY_GPS_ImgDirectionDenominator.
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: {16473C91-D017-4ED9-BA4D-B6BAA55DBCF8}, 100</para>
					/// </summary>
					public static PROPERTYKEY ImgDirection
						=> new PROPERTYKEY(new Guid("{16473C91-D017-4ED9-BA4D-B6BAA55DBCF8}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.ImgDirectionDenominator -- PKEY_GPS_ImgDirectionDenominator</para>
					/// <para>Description: Denominator of PKEY_GPS_ImgDirection</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {10B24595-41A2-4E20-93C2-5761C1395F32}, 100</para>
					/// </summary>
					public static PROPERTYKEY ImgDirectionDenominator
						=> new PROPERTYKEY(new Guid("{10B24595-41A2-4E20-93C2-5761C1395F32}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.ImgDirectionNumerator -- PKEY_GPS_ImgDirectionNumerator</para>
					/// <para>Description: Numerator of PKEY_GPS_ImgDirection</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {DC5877C7-225F-45F7-BAC7-E81334B6130A}, 100</para>
					/// </summary>
					public static PROPERTYKEY ImgDirectionNumerator
						=> new PROPERTYKEY(new Guid("{DC5877C7-225F-45F7-BAC7-E81334B6130A}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.ImgDirectionRef -- PKEY_GPS_ImgDirectionRef</para>
					/// <para>
					/// Description: Indicates reference for giving the direction of the image when it was captured. (eg: true direction,
					/// magnetic direction)
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {A4AAA5B7-1AD0-445F-811A-0F8F6E67F6B5}, 100</para>
					/// </summary>
					public static PROPERTYKEY ImgDirectionRef
						=> new PROPERTYKEY(new Guid("{A4AAA5B7-1AD0-445F-811A-0F8F6E67F6B5}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.Latitude -- PKEY_GPS_Latitude</para>
					/// <para>
					/// Description: Indicates the latitude. This is an array of three values. Index 0 is the degrees, index 1 is the
					/// minutes, index 2 is the seconds. Each is calculated from the values in PKEY_GPS_LatitudeNumerator and PKEY_GPS_LatitudeDenominator.
					/// </para>
					/// <para>Type:     Multivalue Double -- VT_VECTOR | VT_R8 (For variants: VT_ARRAY | VT_R8)</para>
					/// <para>FormatID: {8727CFFF-4868-4EC6-AD5B-81B98521D1AB}, 100</para>
					/// </summary>
					public static PROPERTYKEY Latitude
						=> new PROPERTYKEY(new Guid("{8727CFFF-4868-4EC6-AD5B-81B98521D1AB}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.LatitudeDenominator -- PKEY_GPS_LatitudeDenominator</para>
					/// <para>Description: Denominator of PKEY_GPS_Latitude</para>
					/// <para>Type:     Multivalue UInt32 -- VT_VECTOR | VT_UI4 (For variants: VT_ARRAY | VT_UI4)</para>
					/// <para>FormatID: {16E634EE-2BFF-497B-BD8A-4341AD39EEB9}, 100</para>
					/// </summary>
					public static PROPERTYKEY LatitudeDenominator
						=> new PROPERTYKEY(new Guid("{16E634EE-2BFF-497B-BD8A-4341AD39EEB9}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.LatitudeNumerator -- PKEY_GPS_LatitudeNumerator</para>
					/// <para>Description: Numerator of PKEY_GPS_Latitude</para>
					/// <para>Type:     Multivalue UInt32 -- VT_VECTOR | VT_UI4 (For variants: VT_ARRAY | VT_UI4)</para>
					/// <para>FormatID: {7DDAAAD1-CCC8-41AE-B750-B2CB8031AEA2}, 100</para>
					/// </summary>
					public static PROPERTYKEY LatitudeNumerator
						=> new PROPERTYKEY(new Guid("{7DDAAAD1-CCC8-41AE-B750-B2CB8031AEA2}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.LatitudeRef -- PKEY_GPS_LatitudeRef</para>
					/// <para>Description: Indicates whether latitude is north or south latitude</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {029C0252-5B86-46C7-ACA0-2769FFC8E3D4}, 100</para>
					/// </summary>
					public static PROPERTYKEY LatitudeRef
						=> new PROPERTYKEY(new Guid("{029C0252-5B86-46C7-ACA0-2769FFC8E3D4}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.Longitude -- PKEY_GPS_Longitude</para>
					/// <para>
					/// Description: Indicates the longitude. This is an array of three values. Index 0 is the degrees, index 1 is the
					/// minutes, index 2 is the seconds. Each is calculated from the values in PKEY_GPS_LongitudeNumerator and PKEY_GPS_LongitudeDenominator.
					/// </para>
					/// <para>Type:     Multivalue Double -- VT_VECTOR | VT_R8 (For variants: VT_ARRAY | VT_R8)</para>
					/// <para>FormatID: {C4C4DBB2-B593-466B-BBDA-D03D27D5E43A}, 100</para>
					/// </summary>
					public static PROPERTYKEY Longitude
						=> new PROPERTYKEY(new Guid("{C4C4DBB2-B593-466B-BBDA-D03D27D5E43A}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.LongitudeDenominator -- PKEY_GPS_LongitudeDenominator</para>
					/// <para>Description: Denominator of PKEY_GPS_Longitude</para>
					/// <para>Type:     Multivalue UInt32 -- VT_VECTOR | VT_UI4 (For variants: VT_ARRAY | VT_UI4)</para>
					/// <para>FormatID: {BE6E176C-4534-4D2C-ACE5-31DEDAC1606B}, 100</para>
					/// </summary>
					public static PROPERTYKEY LongitudeDenominator
						=> new PROPERTYKEY(new Guid("{BE6E176C-4534-4D2C-ACE5-31DEDAC1606B}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.LongitudeNumerator -- PKEY_GPS_LongitudeNumerator</para>
					/// <para>Description: Numerator of PKEY_GPS_Longitude</para>
					/// <para>Type:     Multivalue UInt32 -- VT_VECTOR | VT_UI4 (For variants: VT_ARRAY | VT_UI4)</para>
					/// <para>FormatID: {02B0F689-A914-4E45-821D-1DDA452ED2C4}, 100</para>
					/// </summary>
					public static PROPERTYKEY LongitudeNumerator
						=> new PROPERTYKEY(new Guid("{02B0F689-A914-4E45-821D-1DDA452ED2C4}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.LongitudeRef -- PKEY_GPS_LongitudeRef</para>
					/// <para>Description: Indicates whether longitude is east or west longitude</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {33DCF22B-28D5-464C-8035-1EE9EFD25278}, 100</para>
					/// </summary>
					public static PROPERTYKEY LongitudeRef
						=> new PROPERTYKEY(new Guid("{33DCF22B-28D5-464C-8035-1EE9EFD25278}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.MapDatum -- PKEY_GPS_MapDatum</para>
					/// <para>Description: Indicates the geodetic survey data used by the GPS receiver</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {2CA2DAE6-EDDC-407D-BEF1-773942ABFA95}, 100</para>
					/// </summary>
					public static PROPERTYKEY MapDatum
						=> new PROPERTYKEY(new Guid("{2CA2DAE6-EDDC-407D-BEF1-773942ABFA95}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.MeasureMode -- PKEY_GPS_MeasureMode</para>
					/// <para>Description: Indicates the GPS measurement mode. (eg: 2-dimensional, 3-dimensional)</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {A015ED5D-AAEA-4D58-8A86-3C586920EA0B}, 100</para>
					/// </summary>
					public static PROPERTYKEY MeasureMode
						=> new PROPERTYKEY(new Guid("{A015ED5D-AAEA-4D58-8A86-3C586920EA0B}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.ProcessingMethod -- PKEY_GPS_ProcessingMethod</para>
					/// <para>Description: Indicates the name of the method used for location finding</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {59D49E61-840F-4AA9-A939-E2099B7F6399}, 100</para>
					/// </summary>
					public static PROPERTYKEY ProcessingMethod
						=> new PROPERTYKEY(new Guid("{59D49E61-840F-4AA9-A939-E2099B7F6399}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.Satellites -- PKEY_GPS_Satellites</para>
					/// <para>Description: Indicates the GPS satellites used for measurements</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {467EE575-1F25-4557-AD4E-B8B58B0D9C15}, 100</para>
					/// </summary>
					public static PROPERTYKEY Satellites
						=> new PROPERTYKEY(new Guid("{467EE575-1F25-4557-AD4E-B8B58B0D9C15}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.Speed -- PKEY_GPS_Speed</para>
					/// <para>
					/// Description: Indicates the speed of the GPS receiver movement. Calculated from PKEY_GPS_SpeedNumerator and PKEY_GPS_SpeedDenominator.
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: {DA5D0862-6E76-4E1B-BABD-70021BD25494}, 100</para>
					/// </summary>
					public static PROPERTYKEY Speed
						=> new PROPERTYKEY(new Guid("{DA5D0862-6E76-4E1B-BABD-70021BD25494}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.SpeedDenominator -- PKEY_GPS_SpeedDenominator</para>
					/// <para>Description: Denominator of PKEY_GPS_Speed</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {7D122D5A-AE5E-4335-8841-D71E7CE72F53}, 100</para>
					/// </summary>
					public static PROPERTYKEY SpeedDenominator
						=> new PROPERTYKEY(new Guid("{7D122D5A-AE5E-4335-8841-D71E7CE72F53}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.SpeedNumerator -- PKEY_GPS_SpeedNumerator</para>
					/// <para>Description: Numerator of PKEY_GPS_Speed</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {ACC9CE3D-C213-4942-8B48-6D0820F21C6D}, 100</para>
					/// </summary>
					public static PROPERTYKEY SpeedNumerator
						=> new PROPERTYKEY(new Guid("{ACC9CE3D-C213-4942-8B48-6D0820F21C6D}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.SpeedRef -- PKEY_GPS_SpeedRef</para>
					/// <para>
					/// Description: Indicates the unit used to express the speed of the GPS receiver movement. (eg: kilometers per hour,
					/// miles per hour, knots).
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {ECF7F4C9-544F-4D6D-9D98-8AD79ADAF453}, 100</para>
					/// </summary>
					public static PROPERTYKEY SpeedRef
						=> new PROPERTYKEY(new Guid("{ECF7F4C9-544F-4D6D-9D98-8AD79ADAF453}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.Status -- PKEY_GPS_Status</para>
					/// <para>
					/// Description: Indicates the status of the GPS receiver when the image was recorded. (eg: measurement in progress,
					/// measurement interoperability).
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {125491F4-818F-46B2-91B5-D537753617B2}, 100</para>
					/// </summary>
					public static PROPERTYKEY Status
						=> new PROPERTYKEY(new Guid("{125491F4-818F-46B2-91B5-D537753617B2}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.Track -- PKEY_GPS_Track</para>
					/// <para>
					/// Description: Indicates the direction of the GPS receiver movement. Calculated from PKEY_GPS_TrackNumerator and PKEY_GPS_TrackDenominator.
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: {76C09943-7C33-49E3-9E7E-CDBA872CFADA}, 100</para>
					/// </summary>
					public static PROPERTYKEY Track
						=> new PROPERTYKEY(new Guid("{76C09943-7C33-49E3-9E7E-CDBA872CFADA}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.TrackDenominator -- PKEY_GPS_TrackDenominator</para>
					/// <para>Description: Denominator of PKEY_GPS_Track</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {C8D1920C-01F6-40C0-AC86-2F3A4AD00770}, 100</para>
					/// </summary>
					public static PROPERTYKEY TrackDenominator
						=> new PROPERTYKEY(new Guid("{C8D1920C-01F6-40C0-AC86-2F3A4AD00770}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.TrackNumerator -- PKEY_GPS_TrackNumerator</para>
					/// <para>Description: Numerator of PKEY_GPS_Track</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {702926F4-44A6-43E1-AE71-45627116893B}, 100</para>
					/// </summary>
					public static PROPERTYKEY TrackNumerator
						=> new PROPERTYKEY(new Guid("{702926F4-44A6-43E1-AE71-45627116893B}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.TrackRef -- PKEY_GPS_TrackRef</para>
					/// <para>
					/// Description: Indicates reference for the direction of the GPS receiver movement. (eg: true direction, magnetic direction)
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {35DBE6FE-44C3-4400-AAAE-D2C799C407E8}, 100</para>
					/// </summary>
					public static PROPERTYKEY TrackRef
						=> new PROPERTYKEY(new Guid("{35DBE6FE-44C3-4400-AAAE-D2C799C407E8}"), 100);

					/// <summary>
					/// <para>Name:     System.GPS.VersionID -- PKEY_GPS_VersionID</para>
					/// <para>Description: Indicates the version of the GPS information</para>
					/// <para>Type:     Buffer -- VT_VECTOR | VT_UI1 (For variants: VT_ARRAY | VT_UI1)</para>
					/// <para>FormatID: {22704DA4-C6B2-4A99-8E56-F16DF8C92599}, 100</para>
					/// </summary>
					public static PROPERTYKEY VersionID
						=> new PROPERTYKEY(new Guid("{22704DA4-C6B2-4A99-8E56-F16DF8C92599}"), 100);
				}

				/// <summary>Identity Properties</summary>
				public static class Identity
				{
					/// <summary>
					/// <para>Name:     System.Identity.Blob -- PKEY_Identity_Blob</para>
					/// <para>Description: Blob used to import/export identities</para>
					/// <para>Type:     Blob -- VT_BLOB</para>
					/// <para>FormatID: {8C3B93A4-BAED-1A83-9A32-102EE313F6EB}, 100</para>
					/// </summary>
					public static PROPERTYKEY Blob
						=> new PROPERTYKEY(new Guid("{8C3B93A4-BAED-1A83-9A32-102EE313F6EB}"), 100);

					/// <summary>
					/// <para>Name:     System.Identity.DisplayName -- PKEY_Identity_DisplayName</para>
					/// <para>Description: Display Name</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {7D683FC9-D155-45A8-BB1F-89D19BCB792F}, 100</para>
					/// </summary>
					public static PROPERTYKEY DisplayName
						=> new PROPERTYKEY(new Guid("{7D683FC9-D155-45A8-BB1F-89D19BCB792F}"), 100);

					/// <summary>
					/// <para>Name:     System.Identity.IsMeIdentity -- PKEY_Identity_IsMeIdentity</para>
					/// <para>Description: Is it Me Identity</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {A4108708-09DF-4377-9DFC-6D99986D5A67}, 100</para>
					/// </summary>
					public static PROPERTYKEY IsMeIdentity
						=> new PROPERTYKEY(new Guid("{A4108708-09DF-4377-9DFC-6D99986D5A67}"), 100);

					/// <summary>
					/// <para>Name:     System.Identity.PrimaryEmailAddress -- PKEY_Identity_PrimaryEmailAddress</para>
					/// <para>Description: Primary Email Address</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {FCC16823-BAED-4F24-9B32-A0982117F7FA}, 100</para>
					/// </summary>
					public static PROPERTYKEY PrimaryEmailAddress
						=> new PROPERTYKEY(new Guid("{FCC16823-BAED-4F24-9B32-A0982117F7FA}"), 100);

					/// <summary>
					/// <para>Name:     System.Identity.ProviderID -- PKEY_Identity_ProviderID</para>
					/// <para>Description: Provider ID</para>
					/// <para>Type:     Guid -- VT_CLSID</para>
					/// <para>FormatID: {74A7DE49-FA11-4D3D-A006-DB7E08675916}, 100</para>
					/// </summary>
					public static PROPERTYKEY ProviderID
						=> new PROPERTYKEY(new Guid("{74A7DE49-FA11-4D3D-A006-DB7E08675916}"), 100);

					/// <summary>
					/// <para>Name:     System.Identity.UniqueID -- PKEY_Identity_UniqueID</para>
					/// <para>Description: Unique ID</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {E55FC3B0-2B60-4220-918E-B21E8BF16016}, 100</para>
					/// </summary>
					public static PROPERTYKEY UniqueID
						=> new PROPERTYKEY(new Guid("{E55FC3B0-2B60-4220-918E-B21E8BF16016}"), 100);

					/// <summary>
					/// <para>Name:     System.Identity.UserName -- PKEY_Identity_UserName</para>
					/// <para>Description: Identity User Name</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C4322503-78CA-49C6-9ACC-A68E2AFD7B6B}, 100</para>
					/// </summary>
					public static PROPERTYKEY UserName
						=> new PROPERTYKEY(new Guid("{C4322503-78CA-49C6-9ACC-A68E2AFD7B6B}"), 100);
				}

				/// <summary>IdentityProvider Properties</summary>
				public static class IdentityProvider
				{
					/// <summary>
					/// <para>Name:     System.IdentityProvider.Name -- PKEY_IdentityProvider_Name</para>
					/// <para>Description: Identity Provider Name</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {B96EFF7B-35CA-4A35-8607-29E3A54C46EA}, 100</para>
					/// </summary>
					public static PROPERTYKEY Name
						=> new PROPERTYKEY(new Guid("{B96EFF7B-35CA-4A35-8607-29E3A54C46EA}"), 100);

					/// <summary>
					/// <para>Name:     System.IdentityProvider.Picture -- PKEY_IdentityProvider_Picture</para>
					/// <para>Description: Picture for the Identity Provider</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {2425166F-5642-4864-992F-98FD98F294C3}, 100</para>
					/// </summary>
					public static PROPERTYKEY Picture
						=> new PROPERTYKEY(new Guid("{2425166F-5642-4864-992F-98FD98F294C3}"), 100);
				}

				/// <summary>Image Properties</summary>
				public static class Image
				{
					/// <summary>
					/// <para>Name:     System.Image.BitDepth -- PKEY_Image_BitDepth</para>
					/// <para>Description:</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (PSGUID_IMAGESUMMARYINFORMATION) {6444048F-4C8B-11D1-8B70-080036B11A03}, 7 (PIDISI_BITDEPTH)</para>
					/// </summary>
					public static PROPERTYKEY BitDepth
						=> new PROPERTYKEY(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 7);

					/// <summary>
					/// <para>Name:     System.Image.ColorSpace -- PKEY_Image_ColorSpace</para>
					/// <para>Description: PropertyTagExifColorSpace</para>
					/// <para>Type:     UInt16 -- VT_UI2</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 40961</para>
					/// </summary>
					public static PROPERTYKEY ColorSpace
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 40961);

					/// <summary>
					/// <para>Name:     System.Image.CompressedBitsPerPixel -- PKEY_Image_CompressedBitsPerPixel</para>
					/// <para>
					/// Description: Calculated from PKEY_Image_CompressedBitsPerPixelNumerator and PKEY_Image_CompressedBitsPerPixelDenominator.
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: {364B6FA9-37AB-482A-BE2B-AE02F60D4318}, 100</para>
					/// </summary>
					public static PROPERTYKEY CompressedBitsPerPixel
						=> new PROPERTYKEY(new Guid("{364B6FA9-37AB-482A-BE2B-AE02F60D4318}"), 100);

					/// <summary>
					/// <para>Name:     System.Image.CompressedBitsPerPixelDenominator -- PKEY_Image_CompressedBitsPerPixelDenominator</para>
					/// <para>Description: Denominator of PKEY_Image_CompressedBitsPerPixel.</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {1F8844E1-24AD-4508-9DFD-5326A415CE02}, 100</para>
					/// </summary>
					public static PROPERTYKEY CompressedBitsPerPixelDenominator
						=> new PROPERTYKEY(new Guid("{1F8844E1-24AD-4508-9DFD-5326A415CE02}"), 100);

					/// <summary>
					/// <para>Name:     System.Image.CompressedBitsPerPixelNumerator -- PKEY_Image_CompressedBitsPerPixelNumerator</para>
					/// <para>Description: Numerator of PKEY_Image_CompressedBitsPerPixel.</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {D21A7148-D32C-4624-8900-277210F79C0F}, 100</para>
					/// </summary>
					public static PROPERTYKEY CompressedBitsPerPixelNumerator
						=> new PROPERTYKEY(new Guid("{D21A7148-D32C-4624-8900-277210F79C0F}"), 100);

					/// <summary>
					/// <para>Name:     System.Image.Compression -- PKEY_Image_Compression</para>
					/// <para>Description: Indicates the image compression level. PropertyTagCompression.</para>
					/// <para>Type:     UInt16 -- VT_UI2</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 259</para>
					/// </summary>
					public static PROPERTYKEY Compression
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 259);

					/// <summary>
					/// <para>Name:     System.Image.CompressionText -- PKEY_Image_CompressionText</para>
					/// <para>
					/// Description: This is the user-friendly form of System.Image.Compression. Not intended to be parsed programmatically.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {3F08E66F-2F44-4BB9-A682-AC35D2562322}, 100</para>
					/// </summary>
					public static PROPERTYKEY CompressionText
						=> new PROPERTYKEY(new Guid("{3F08E66F-2F44-4BB9-A682-AC35D2562322}"), 100);

					/// <summary>
					/// <para>Name:     System.Image.Dimensions -- PKEY_Image_Dimensions</para>
					/// <para>Description: Indicates the dimensions of the image.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_IMAGESUMMARYINFORMATION) {6444048F-4C8B-11D1-8B70-080036B11A03}, 13 (PIDISI_DIMENSIONS)</para>
					/// </summary>
					public static PROPERTYKEY Dimensions
						=> new PROPERTYKEY(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 13);

					/// <summary>
					/// <para>Name:     System.Image.HorizontalResolution -- PKEY_Image_HorizontalResolution</para>
					/// <para>Description:</para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: (PSGUID_IMAGESUMMARYINFORMATION) {6444048F-4C8B-11D1-8B70-080036B11A03}, 5 (PIDISI_RESOLUTIONX)</para>
					/// </summary>
					public static PROPERTYKEY HorizontalResolution
						=> new PROPERTYKEY(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 5);

					/// <summary>
					/// <para>Name:     System.Image.HorizontalSize -- PKEY_Image_HorizontalSize</para>
					/// <para>Description:</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (PSGUID_IMAGESUMMARYINFORMATION) {6444048F-4C8B-11D1-8B70-080036B11A03}, 3 (PIDISI_CX)</para>
					/// </summary>
					public static PROPERTYKEY HorizontalSize
						=> new PROPERTYKEY(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 3);

					/// <summary>
					/// <para>Name:     System.Image.ImageID -- PKEY_Image_ImageID</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {10DABE05-32AA-4C29-BF1A-63E2D220587F}, 100</para>
					/// </summary>
					public static PROPERTYKEY ImageID
						=> new PROPERTYKEY(new Guid("{10DABE05-32AA-4C29-BF1A-63E2D220587F}"), 100);

					/// <summary>
					/// <para>Name:     System.Image.ResolutionUnit -- PKEY_Image_ResolutionUnit</para>
					/// <para>Description:</para>
					/// <para>Type:     Int16 -- VT_I2</para>
					/// <para>FormatID: {19B51FA6-1F92-4A5C-AB48-7DF0ABD67444}, 100</para>
					/// </summary>
					public static PROPERTYKEY ResolutionUnit
						=> new PROPERTYKEY(new Guid("{19B51FA6-1F92-4A5C-AB48-7DF0ABD67444}"), 100);

					/// <summary>
					/// <para>Name:     System.Image.VerticalResolution -- PKEY_Image_VerticalResolution</para>
					/// <para>Description:</para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: (PSGUID_IMAGESUMMARYINFORMATION) {6444048F-4C8B-11D1-8B70-080036B11A03}, 6 (PIDISI_RESOLUTIONY)</para>
					/// </summary>
					public static PROPERTYKEY VerticalResolution
						=> new PROPERTYKEY(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 6);

					/// <summary>
					/// <para>Name:     System.Image.VerticalSize -- PKEY_Image_VerticalSize</para>
					/// <para>Description:</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (PSGUID_IMAGESUMMARYINFORMATION) {6444048F-4C8B-11D1-8B70-080036B11A03}, 4 (PIDISI_CY)</para>
					/// </summary>
					public static PROPERTYKEY VerticalSize
						=> new PROPERTYKEY(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 4);
				}

				/// <summary>Journal Properties</summary>
				public static class Journal
				{
					/// <summary>
					/// <para>Name:     System.Journal.Contacts -- PKEY_Journal_Contacts</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {DEA7C82C-1D89-4A66-9427-A4E3DEBABCB1}, 100</para>
					/// </summary>
					public static PROPERTYKEY Contacts
						=> new PROPERTYKEY(new Guid("{DEA7C82C-1D89-4A66-9427-A4E3DEBABCB1}"), 100);

					/// <summary>
					/// <para>Name:     System.Journal.EntryType -- PKEY_Journal_EntryType</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {95BEB1FC-326D-4644-B396-CD3ED90E6DDF}, 100</para>
					/// </summary>
					public static PROPERTYKEY EntryType
						=> new PROPERTYKEY(new Guid("{95BEB1FC-326D-4644-B396-CD3ED90E6DDF}"), 100);
				}

				/// <summary>LayoutPattern Properties</summary>
				public static class LayoutPattern
				{
					/// <summary>
					/// <para>Name:     System.LayoutPattern.ContentViewModeForBrowse -- PKEY_LayoutPattern_ContentViewModeForBrowse</para>
					/// <para>
					/// Description: Specifies the layout pattern that the content view mode should apply for this item in the context of
					/// browsing. Register the regvalue under the name of "ContentViewModeLayoutPatternForBrowse".
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 500</para>
					/// </summary>
					public static PROPERTYKEY ContentViewModeForBrowse
						=> new PROPERTYKEY(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 500);

					/// <summary>
					/// <para>Name:     System.LayoutPattern.ContentViewModeForSearch -- PKEY_LayoutPattern_ContentViewModeForSearch</para>
					/// <para>
					/// Description: Specifies the layout pattern that the content view mode should apply for this item in the context of
					/// searching. Register the regvalue under the name of "ContentViewModeLayoutPatternForSearch".
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 501</para>
					/// </summary>
					public static PROPERTYKEY ContentViewModeForSearch
						=> new PROPERTYKEY(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 501);
				}

				/// <summary>Link Properties</summary>
				public static class Link
				{
					/// <summary>
					/// <para>Name:     System.Link.Arguments -- PKEY_Link_Arguments</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {436F2667-14E2-4FEB-B30A-146C53B5B674}, 100</para>
					/// </summary>
					public static PROPERTYKEY Arguments
						=> new PROPERTYKEY(new Guid("{436F2667-14E2-4FEB-B30A-146C53B5B674}"), 100);

					/// <summary>
					/// <para>Name:     System.Link.Comment -- PKEY_Link_Comment</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_LINK) {B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}, 5</para>
					/// </summary>
					public static PROPERTYKEY Comment
						=> new PROPERTYKEY(new Guid("{B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}"), 5);

					/// <summary>
					/// <para>Name:     System.Link.DateVisited -- PKEY_Link_DateVisited</para>
					/// <para>Description:</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: {5CBF2787-48CF-4208-B90E-EE5E5D420294}, 23 (PKEYs relating to URLs. Used by IE History.)</para>
					/// </summary>
					public static PROPERTYKEY DateVisited
						=> new PROPERTYKEY(new Guid("{5CBF2787-48CF-4208-B90E-EE5E5D420294}"), 23);

					/// <summary>
					/// <para>Name:     System.Link.Description -- PKEY_Link_Description</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {5CBF2787-48CF-4208-B90E-EE5E5D420294}, 21 (PKEYs relating to URLs. Used by IE History.)</para>
					/// </summary>
					public static PROPERTYKEY Description
						=> new PROPERTYKEY(new Guid("{5CBF2787-48CF-4208-B90E-EE5E5D420294}"), 21);

					/// <summary>
					/// <para>Name:     System.Link.Status -- PKEY_Link_Status</para>
					/// <para>Description:</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: (PSGUID_LINK) {B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}, 3 (PID_LINK_TARGET_TYPE)</para>
					/// </summary>
					public static PROPERTYKEY Status
						=> new PROPERTYKEY(new Guid("{B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}"), 3);

					/// <summary>
					/// <para>Name:     System.Link.TargetExtension -- PKEY_Link_TargetExtension</para>
					/// <para>Description: The file extension of the link target. See System.File.Extension</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {7A7D76F4-B630-4BD7-95FF-37CC51A975C9}, 2</para>
					/// </summary>
					public static PROPERTYKEY TargetExtension
						=> new PROPERTYKEY(new Guid("{7A7D76F4-B630-4BD7-95FF-37CC51A975C9}"), 2);

					/// <summary>
					/// <para>Name:     System.Link.TargetParsingPath -- PKEY_Link_TargetParsingPath</para>
					/// <para>
					/// Description: This is the shell namespace path to the target of the link item. This path may be passed to
					/// SHParseDisplayName to parse the path to the correct shell folder. If the target item is a file, the value is
					/// identical to System.ItemPathDisplay. If the target item cannot be accessed through the shell namespace, this value is VT_EMPTY.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_LINK) {B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}, 2 (PID_LINK_TARGET)</para>
					/// </summary>
					public static PROPERTYKEY TargetParsingPath
						=> new PROPERTYKEY(new Guid("{B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}"), 2);

					/// <summary>
					/// <para>Name:     System.Link.TargetSFGAOFlags -- PKEY_Link_TargetSFGAOFlags</para>
					/// <para>
					/// Description: IShellFolder::GetAttributesOf flags for the target of a link, with SFGAO_PKEYSFGAOMASK attributes masked out.
					/// </para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (PSGUID_LINK) {B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}, 8</para>
					/// </summary>
					public static PROPERTYKEY TargetSFGAOFlags
						=> new PROPERTYKEY(new Guid("{B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}"), 8);

					/// <summary>
					/// <para>Name:     System.Link.TargetSFGAOFlagsStrings -- PKEY_Link_TargetSFGAOFlagsStrings</para>
					/// <para>
					/// Description: Expresses the SFGAO flags of a link as string values and is used as a query optimization. See
					/// PKEY_Shell_SFGAOFlagsStrings for possible values of this.
					/// </para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {D6942081-D53B-443D-AD47-5E059D9CD27A}, 3</para>
					/// </summary>
					public static PROPERTYKEY TargetSFGAOFlagsStrings
						=> new PROPERTYKEY(new Guid("{D6942081-D53B-443D-AD47-5E059D9CD27A}"), 3);

					/// <summary>
					/// <para>Name:     System.Link.TargetUrl -- PKEY_Link_TargetUrl</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {5CBF2787-48CF-4208-B90E-EE5E5D420294}, 2 (PKEYs relating to URLs. Used by IE History.)</para>
					/// </summary>
					public static PROPERTYKEY TargetUrl
						=> new PROPERTYKEY(new Guid("{5CBF2787-48CF-4208-B90E-EE5E5D420294}"), 2);
				}

				/// <summary>Media Properties</summary>
				public static class Media
				{
					/// <summary>
					/// <para>Name:     System.Media.AuthorUrl -- PKEY_Media_AuthorUrl</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 32 (PIDMSI_AUTHOR_URL)</para>
					/// </summary>
					public static PROPERTYKEY AuthorUrl
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 32);

					/// <summary>
					/// <para>Name:     System.Media.AverageLevel -- PKEY_Media_AverageLevel</para>
					/// <para>Description:</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {09EDD5B6-B301-43C5-9990-D00302EFFD46}, 100</para>
					/// </summary>
					public static PROPERTYKEY AverageLevel
						=> new PROPERTYKEY(new Guid("{09EDD5B6-B301-43C5-9990-D00302EFFD46}"), 100);

					/// <summary>
					/// <para>Name:     System.Media.ClassPrimaryID -- PKEY_Media_ClassPrimaryID</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>
					/// FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 13 (PIDMSI_CLASS_PRIMARY_ID)
					/// </para>
					/// </summary>
					public static PROPERTYKEY ClassPrimaryID
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 13);

					/// <summary>
					/// <para>Name:     System.Media.ClassSecondaryID -- PKEY_Media_ClassSecondaryID</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>
					/// FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 14 (PIDMSI_CLASS_SECONDARY_ID)
					/// </para>
					/// </summary>
					public static PROPERTYKEY ClassSecondaryID
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 14);

					/// <summary>
					/// <para>Name:     System.Media.CollectionGroupID -- PKEY_Media_CollectionGroupID</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>
					/// FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 24 (PIDMSI_COLLECTION_GROUP_ID)
					/// </para>
					/// </summary>
					public static PROPERTYKEY CollectionGroupID
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 24);

					/// <summary>
					/// <para>Name:     System.Media.CollectionID -- PKEY_Media_CollectionID</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>
					/// FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 25 (PIDMSI_COLLECTION_ID)
					/// </para>
					/// </summary>
					public static PROPERTYKEY CollectionID
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 25);

					/// <summary>
					/// <para>Name:     System.Media.ContentDistributor -- PKEY_Media_ContentDistributor</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>
					/// FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 18 (PIDMSI_CONTENTDISTRIBUTOR)
					/// </para>
					/// </summary>
					public static PROPERTYKEY ContentDistributor
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 18);

					/// <summary>
					/// <para>Name:     System.Media.ContentID -- PKEY_Media_ContentID</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 26 (PIDMSI_CONTENT_ID)</para>
					/// </summary>
					public static PROPERTYKEY ContentID
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 26);

					/// <summary>
					/// <para>Name:     System.Media.CreatorApplication -- PKEY_Media_CreatorApplication</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 27 (PIDMSI_TOOL_NAME)</para>
					/// </summary>
					public static PROPERTYKEY CreatorApplication
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 27);

					/// <summary>
					/// <para>Name:     System.Media.CreatorApplicationVersion -- PKEY_Media_CreatorApplicationVersion</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>
					/// FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 28 (PIDMSI_TOOL_VERSION)
					/// </para>
					/// </summary>
					public static PROPERTYKEY CreatorApplicationVersion
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 28);

					/// <summary>
					/// <para>Name:     System.Media.DateEncoded -- PKEY_Media_DateEncoded</para>
					/// <para>Description: DateTime is in UTC (in the doc, not file system).</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: {2E4B640D-5019-46D8-8881-55414CC5CAA0}, 100</para>
					/// </summary>
					public static PROPERTYKEY DateEncoded
						=> new PROPERTYKEY(new Guid("{2E4B640D-5019-46D8-8881-55414CC5CAA0}"), 100);

					/// <summary>
					/// <para>Name:     System.Media.DateReleased -- PKEY_Media_DateReleased</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {DE41CC29-6971-4290-B472-F59F2E2F31E2}, 100</para>
					/// </summary>
					public static PROPERTYKEY DateReleased
						=> new PROPERTYKEY(new Guid("{DE41CC29-6971-4290-B472-F59F2E2F31E2}"), 100);

					/// <summary>
					/// <para>Name:     System.Media.Duration -- PKEY_Media_Duration</para>
					/// <para>Description: 100ns units, not milliseconds</para>
					/// <para>Type:     UInt64 -- VT_UI8</para>
					/// <para>FormatID: (FMTID_AudioSummaryInformation) {64440490-4C8B-11D1-8B70-080036B11A03}, 3 (PIDASI_TIMELENGTH)</para>
					/// </summary>
					public static PROPERTYKEY Duration
						=> new PROPERTYKEY(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 3);

					/// <summary>
					/// <para>Name:     System.Media.DVDID -- PKEY_Media_DVDID</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 15 (PIDMSI_DVDID)</para>
					/// </summary>
					public static PROPERTYKEY DVDID
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 15);

					/// <summary>
					/// <para>Name:     System.Media.EncodedBy -- PKEY_Media_EncodedBy</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 36 (PIDMSI_ENCODED_BY)</para>
					/// </summary>
					public static PROPERTYKEY EncodedBy
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 36);

					/// <summary>
					/// <para>Name:     System.Media.EncodingSettings -- PKEY_Media_EncodingSettings</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>
					/// FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 37 (PIDMSI_ENCODING_SETTINGS)
					/// </para>
					/// </summary>
					public static PROPERTYKEY EncodingSettings
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 37);

					/// <summary>
					/// <para>Name:     System.Media.FrameCount -- PKEY_Media_FrameCount</para>
					/// <para>Description: Indicates the frame count for the image.</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (PSGUID_IMAGESUMMARYINFORMATION) {6444048F-4C8B-11D1-8B70-080036B11A03}, 12 (PIDISI_FRAMECOUNT)</para>
					/// </summary>
					public static PROPERTYKEY FrameCount
						=> new PROPERTYKEY(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 12);

					/// <summary>
					/// <para>Name:     System.Media.MCDI -- PKEY_Media_MCDI</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 16 (PIDMSI_MCDI)</para>
					/// </summary>
					public static PROPERTYKEY MCDI
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 16);

					/// <summary>
					/// <para>Name:     System.Media.MetadataContentProvider -- PKEY_Media_MetadataContentProvider</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 17 (PIDMSI_PROVIDER)</para>
					/// </summary>
					public static PROPERTYKEY MetadataContentProvider
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 17);

					/// <summary>
					/// <para>Name:     System.Media.Producer -- PKEY_Media_Producer</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 22 (PIDMSI_PRODUCER)</para>
					/// </summary>
					public static PROPERTYKEY Producer
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 22);

					/// <summary>
					/// <para>Name:     System.Media.PromotionUrl -- PKEY_Media_PromotionUrl</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>
					/// FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 33 (PIDMSI_PROMOTION_URL)
					/// </para>
					/// </summary>
					public static PROPERTYKEY PromotionUrl
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 33);

					/// <summary>
					/// <para>Name:     System.Media.ProtectionType -- PKEY_Media_ProtectionType</para>
					/// <para>Description: If media is protected, how is it protected?</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 38</para>
					/// </summary>
					public static PROPERTYKEY ProtectionType
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 38);

					/// <summary>
					/// <para>Name:     System.Media.ProviderRating -- PKEY_Media_ProviderRating</para>
					/// <para>Description: Rating (0 - 99) supplied by metadata provider</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 39</para>
					/// </summary>
					public static PROPERTYKEY ProviderRating
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 39);

					/// <summary>
					/// <para>Name:     System.Media.ProviderStyle -- PKEY_Media_ProviderStyle</para>
					/// <para>Description: Style of music or video, supplied by metadata provider</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 40</para>
					/// </summary>
					public static PROPERTYKEY ProviderStyle
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 40);

					/// <summary>
					/// <para>Name:     System.Media.Publisher -- PKEY_Media_Publisher</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 30 (PIDMSI_PUBLISHER)</para>
					/// </summary>
					public static PROPERTYKEY Publisher
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 30);

					/// <summary>
					/// <para>Name:     System.Media.SubscriptionContentId -- PKEY_Media_SubscriptionContentId</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {9AEBAE7A-9644-487D-A92C-657585ED751A}, 100</para>
					/// </summary>
					public static PROPERTYKEY SubscriptionContentId
						=> new PROPERTYKEY(new Guid("{9AEBAE7A-9644-487D-A92C-657585ED751A}"), 100);

					/// <summary>
					/// <para>Name:     System.Media.SubTitle -- PKEY_Media_SubTitle</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 38 (PIDSI_MUSIC_SUB_TITLE)</para>
					/// </summary>
					public static PROPERTYKEY SubTitle
						=> new PROPERTYKEY(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 38);

					/// <summary>
					/// <para>Name:     System.Media.UniqueFileIdentifier -- PKEY_Media_UniqueFileIdentifier</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>
					/// FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 35 (PIDMSI_UNIQUE_FILE_IDENTIFIER)
					/// </para>
					/// </summary>
					public static PROPERTYKEY UniqueFileIdentifier
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 35);

					/// <summary>
					/// <para>Name:     System.Media.UserNoAutoInfo -- PKEY_Media_UserNoAutoInfo</para>
					/// <para>Description: If true, do NOT alter this file's metadata. Set by user.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 41</para>
					/// </summary>
					public static PROPERTYKEY UserNoAutoInfo
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 41);

					/// <summary>
					/// <para>Name:     System.Media.UserWebUrl -- PKEY_Media_UserWebUrl</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>
					/// FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 34 (PIDMSI_USER_WEB_URL)
					/// </para>
					/// </summary>
					public static PROPERTYKEY UserWebUrl
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 34);

					/// <summary>
					/// <para>Name:     System.Media.Writer -- PKEY_Media_Writer</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 23 (PIDMSI_WRITER)</para>
					/// </summary>
					public static PROPERTYKEY Writer
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 23);

					/// <summary>
					/// <para>Name:     System.Media.Year -- PKEY_Media_Year</para>
					/// <para>Description:</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 5 (PIDSI_MUSIC_YEAR)</para>
					/// </summary>
					public static PROPERTYKEY Year
						=> new PROPERTYKEY(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 5);
				}

				/// <summary>Message Properties</summary>
				public static class Message
				{
					/// <summary>
					/// <para>Name:     System.Message.AttachmentContents -- PKEY_Message_AttachmentContents</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {3143BF7C-80A8-4854-8880-E2E40189BDD0}, 100</para>
					/// </summary>
					public static PROPERTYKEY AttachmentContents
						=> new PROPERTYKEY(new Guid("{3143BF7C-80A8-4854-8880-E2E40189BDD0}"), 100);

					/// <summary>
					/// <para>Name:     System.Message.AttachmentNames -- PKEY_Message_AttachmentNames</para>
					/// <para>Description: The names of the attachments in a message</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 21</para>
					/// </summary>
					public static PROPERTYKEY AttachmentNames
						=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 21);

					/// <summary>
					/// <para>Name:     System.Message.BccAddress -- PKEY_Message_BccAddress</para>
					/// <para>Description: Addresses in Bcc: field</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 2</para>
					/// </summary>
					public static PROPERTYKEY BccAddress
						=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 2);

					/// <summary>
					/// <para>Name:     System.Message.BccName -- PKEY_Message_BccName</para>
					/// <para>Description: person names in Bcc: field</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 3</para>
					/// </summary>
					public static PROPERTYKEY BccName
						=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 3);

					/// <summary>
					/// <para>Name:     System.Message.CcAddress -- PKEY_Message_CcAddress</para>
					/// <para>Description: Addresses in Cc: field</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 4</para>
					/// </summary>
					public static PROPERTYKEY CcAddress
						=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 4);

					/// <summary>
					/// <para>Name:     System.Message.CcName -- PKEY_Message_CcName</para>
					/// <para>Description: person names in Cc: field</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 5</para>
					/// </summary>
					public static PROPERTYKEY CcName
						=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 5);

					/// <summary>
					/// <para>Name:     System.Message.ConversationID -- PKEY_Message_ConversationID</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {DC8F80BD-AF1E-4289-85B6-3DFC1B493992}, 100</para>
					/// </summary>
					public static PROPERTYKEY ConversationID
						=> new PROPERTYKEY(new Guid("{DC8F80BD-AF1E-4289-85B6-3DFC1B493992}"), 100);

					/// <summary>
					/// <para>Name:     System.Message.ConversationIndex -- PKEY_Message_ConversationIndex</para>
					/// <para>Description:</para>
					/// <para>Type:     Buffer -- VT_VECTOR | VT_UI1 (For variants: VT_ARRAY | VT_UI1)</para>
					/// <para>FormatID: {DC8F80BD-AF1E-4289-85B6-3DFC1B493992}, 101</para>
					/// </summary>
					public static PROPERTYKEY ConversationIndex
						=> new PROPERTYKEY(new Guid("{DC8F80BD-AF1E-4289-85B6-3DFC1B493992}"), 101);

					/// <summary>
					/// <para>Name:     System.Message.DateReceived -- PKEY_Message_DateReceived</para>
					/// <para>Description: Date and Time communication was received</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 20</para>
					/// </summary>
					public static PROPERTYKEY DateReceived
						=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 20);

					/// <summary>
					/// <para>Name:     System.Message.DateSent -- PKEY_Message_DateSent</para>
					/// <para>Description: Date and Time communication was sent</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 19</para>
					/// </summary>
					public static PROPERTYKEY DateSent
						=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 19);

					/// <summary>
					/// <para>Name:     System.Message.Flags -- PKEY_Message_Flags</para>
					/// <para>
					/// Description: These are flags associated with email messages to know if a read receipt is pending, etc. The values
					/// stored here by Outlook are defined for PR_MESSAGE_FLAGS on MSDN.
					/// </para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: {A82D9EE7-CA67-4312-965E-226BCEA85023}, 100</para>
					/// </summary>
					public static PROPERTYKEY Flags
						=> new PROPERTYKEY(new Guid("{A82D9EE7-CA67-4312-965E-226BCEA85023}"), 100);

					/// <summary>
					/// <para>Name:     System.Message.FromAddress -- PKEY_Message_FromAddress</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 13</para>
					/// </summary>
					public static PROPERTYKEY FromAddress
						=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 13);

					/// <summary>
					/// <para>Name:     System.Message.FromName -- PKEY_Message_FromName</para>
					/// <para>Description: Address in from field as person name</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 14</para>
					/// </summary>
					public static PROPERTYKEY FromName
						=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 14);

					/// <summary>
					/// <para>Name:     System.Message.HasAttachments -- PKEY_Message_HasAttachments</para>
					/// <para>Description:</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {9C1FCF74-2D97-41BA-B4AE-CB2E3661A6E4}, 8</para>
					/// </summary>
					public static PROPERTYKEY HasAttachments
						=> new PROPERTYKEY(new Guid("{9C1FCF74-2D97-41BA-B4AE-CB2E3661A6E4}"), 8);

					/// <summary>
					/// <para>Name:     System.Message.IsFwdOrReply -- PKEY_Message_IsFwdOrReply</para>
					/// <para>Description:</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: {9A9BC088-4F6D-469E-9919-E705412040F9}, 100</para>
					/// </summary>
					public static PROPERTYKEY IsFwdOrReply
						=> new PROPERTYKEY(new Guid("{9A9BC088-4F6D-469E-9919-E705412040F9}"), 100);

					/// <summary>
					/// <para>Name:     System.Message.MessageClass -- PKEY_Message_MessageClass</para>
					/// <para>Description: What type of outlook msg this is (meeting, task, mail, etc.)</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {CD9ED458-08CE-418F-A70E-F912C7BB9C5C}, 103</para>
					/// </summary>
					public static PROPERTYKEY MessageClass
						=> new PROPERTYKEY(new Guid("{CD9ED458-08CE-418F-A70E-F912C7BB9C5C}"), 103);

					/// <summary>
					/// <para>Name:     System.Message.ProofInProgress -- PKEY_Message_ProofInProgress</para>
					/// <para>Description: This property will be true if the message junk email proofing is still in progress.</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {9098F33C-9A7D-48A8-8DE5-2E1227A64E91}, 100</para>
					/// </summary>
					public static PROPERTYKEY ProofInProgress
						=> new PROPERTYKEY(new Guid("{9098F33C-9A7D-48A8-8DE5-2E1227A64E91}"), 100);

					/// <summary>
					/// <para>Name:     System.Message.SenderAddress -- PKEY_Message_SenderAddress</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {0BE1C8E7-1981-4676-AE14-FDD78F05A6E7}, 100</para>
					/// </summary>
					public static PROPERTYKEY SenderAddress
						=> new PROPERTYKEY(new Guid("{0BE1C8E7-1981-4676-AE14-FDD78F05A6E7}"), 100);

					/// <summary>
					/// <para>Name:     System.Message.SenderName -- PKEY_Message_SenderName</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {0DA41CFA-D224-4A18-AE2F-596158DB4B3A}, 100</para>
					/// </summary>
					public static PROPERTYKEY SenderName
						=> new PROPERTYKEY(new Guid("{0DA41CFA-D224-4A18-AE2F-596158DB4B3A}"), 100);

					/// <summary>
					/// <para>Name:     System.Message.Store -- PKEY_Message_Store</para>
					/// <para>Description: The store (aka protocol handler) FILE, MAIL, OUTLOOKEXPRESS</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 15</para>
					/// </summary>
					public static PROPERTYKEY Store
						=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 15);

					/// <summary>
					/// <para>Name:     System.Message.ToAddress -- PKEY_Message_ToAddress</para>
					/// <para>Description: Addresses in To: field</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 16</para>
					/// </summary>
					public static PROPERTYKEY ToAddress
						=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 16);

					/// <summary>
					/// <para>Name:     System.Message.ToDoFlags -- PKEY_Message_ToDoFlags</para>
					/// <para>
					/// Description: Flags associated with a message flagged to know if it's still active, if it was custom flagged, etc.
					/// </para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: {1F856A9F-6900-4ABA-9505-2D5F1B4D66CB}, 100</para>
					/// </summary>
					public static PROPERTYKEY ToDoFlags
						=> new PROPERTYKEY(new Guid("{1F856A9F-6900-4ABA-9505-2D5F1B4D66CB}"), 100);

					/// <summary>
					/// <para>Name:     System.Message.ToDoTitle -- PKEY_Message_ToDoTitle</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {BCCC8A3C-8CEF-42E5-9B1C-C69079398BC7}, 100</para>
					/// </summary>
					public static PROPERTYKEY ToDoTitle
						=> new PROPERTYKEY(new Guid("{BCCC8A3C-8CEF-42E5-9B1C-C69079398BC7}"), 100);

					/// <summary>
					/// <para>Name:     System.Message.ToName -- PKEY_Message_ToName</para>
					/// <para>Description: Person names in To: field</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}, 17</para>
					/// </summary>
					public static PROPERTYKEY ToName
						=> new PROPERTYKEY(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 17);
				}

				/// <summary>Music Properties</summary>
				public static class Music
				{
					/// <summary>
					/// <para>Name:     System.Music.AlbumArtist -- PKEY_Music_AlbumArtist</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 13 (PIDSI_MUSIC_ALBUM_ARTIST)</para>
					/// </summary>
					public static PROPERTYKEY AlbumArtist
						=> new PROPERTYKEY(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 13);

					/// <summary>
					/// <para>Name:     System.Music.AlbumID -- PKEY_Music_AlbumID</para>
					/// <para>
					/// Description: Concatenation of System.Music.AlbumArtist and System.Music.AlbumTitle, suitable for indexing and
					/// display. Used to differentiate albums with the same title from different artists.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 100</para>
					/// </summary>
					public static PROPERTYKEY AlbumID
						=> new PROPERTYKEY(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 100);

					/// <summary>
					/// <para>Name:     System.Music.AlbumTitle -- PKEY_Music_AlbumTitle</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 4 (PIDSI_MUSIC_ALBUM)</para>
					/// </summary>
					public static PROPERTYKEY AlbumTitle
						=> new PROPERTYKEY(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 4);

					/// <summary>
					/// <para>Name:     System.Music.Artist -- PKEY_Music_Artist</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 2 (PIDSI_MUSIC_ARTIST)</para>
					/// </summary>
					public static PROPERTYKEY Artist
						=> new PROPERTYKEY(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 2);

					/// <summary>
					/// <para>Name:     System.Music.BeatsPerMinute -- PKEY_Music_BeatsPerMinute</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 35 (PIDSI_MUSIC_BEATS_PER_MINUTE)</para>
					/// </summary>
					public static PROPERTYKEY BeatsPerMinute
						=> new PROPERTYKEY(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 35);

					/// <summary>
					/// <para>Name:     System.Music.Composer -- PKEY_Music_Composer</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 19 (PIDMSI_COMPOSER)</para>
					/// </summary>
					public static PROPERTYKEY Composer
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 19);

					/// <summary>
					/// <para>Name:     System.Music.Conductor -- PKEY_Music_Conductor</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 36 (PIDSI_MUSIC_CONDUCTOR)</para>
					/// </summary>
					public static PROPERTYKEY Conductor
						=> new PROPERTYKEY(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 36);

					/// <summary>
					/// <para>Name:     System.Music.ContentGroupDescription -- PKEY_Music_ContentGroupDescription</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 33 (PIDSI_MUSIC_CONTENT_GROUP_DESCRIPTION)</para>
					/// </summary>
					public static PROPERTYKEY ContentGroupDescription
						=> new PROPERTYKEY(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 33);

					/// <summary>
					/// <para>Name:     System.Music.DisplayArtist -- PKEY_Music_DisplayArtist</para>
					/// <para>
					/// Description: This property returns the best representation of Album Artist for a given music file based upon
					/// AlbumArtist, ContributingArtist and compilation info.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {FD122953-FA93-4EF7-92C3-04C946B2F7C8}, 100</para>
					/// </summary>
					public static PROPERTYKEY DisplayArtist
						=> new PROPERTYKEY(new Guid("{FD122953-FA93-4EF7-92C3-04C946B2F7C8}"), 100);

					/// <summary>
					/// <para>Name:     System.Music.Genre -- PKEY_Music_Genre</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 11 (PIDSI_MUSIC_GENRE)</para>
					/// </summary>
					public static PROPERTYKEY Genre
						=> new PROPERTYKEY(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 11);

					/// <summary>
					/// <para>Name:     System.Music.InitialKey -- PKEY_Music_InitialKey</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 34 (PIDSI_MUSIC_INITIAL_KEY)</para>
					/// </summary>
					public static PROPERTYKEY InitialKey
						=> new PROPERTYKEY(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 34);

					/// <summary>
					/// <para>Name:     System.Music.IsCompilation -- PKEY_Music_IsCompilation</para>
					/// <para>Description: Indicates whether the file is part of a compilation.</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {C449D5CB-9EA4-4809-82E8-AF9D59DED6D1}, 100</para>
					/// </summary>
					public static PROPERTYKEY IsCompilation
						=> new PROPERTYKEY(new Guid("{C449D5CB-9EA4-4809-82E8-AF9D59DED6D1}"), 100);

					/// <summary>
					/// <para>Name:     System.Music.Lyrics -- PKEY_Music_Lyrics</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 12 (PIDSI_MUSIC_LYRICS)</para>
					/// </summary>
					public static PROPERTYKEY Lyrics
						=> new PROPERTYKEY(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 12);

					/// <summary>
					/// <para>Name:     System.Music.Mood -- PKEY_Music_Mood</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 39 (PIDSI_MUSIC_MOOD)</para>
					/// </summary>
					public static PROPERTYKEY Mood
						=> new PROPERTYKEY(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 39);

					/// <summary>
					/// <para>Name:     System.Music.PartOfSet -- PKEY_Music_PartOfSet</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 37 (PIDSI_MUSIC_PART_OF_SET)</para>
					/// </summary>
					public static PROPERTYKEY PartOfSet
						=> new PROPERTYKEY(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 37);

					/// <summary>
					/// <para>Name:     System.Music.Period -- PKEY_Music_Period</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 31 (PIDMSI_PERIOD)</para>
					/// </summary>
					public static PROPERTYKEY Period
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 31);

					/// <summary>
					/// <para>Name:     System.Music.SynchronizedLyrics -- PKEY_Music_SynchronizedLyrics</para>
					/// <para>Description:</para>
					/// <para>Type:     Blob -- VT_BLOB</para>
					/// <para>FormatID: {6B223B6A-162E-4AA9-B39F-05D678FC6D77}, 100</para>
					/// </summary>
					public static PROPERTYKEY SynchronizedLyrics
						=> new PROPERTYKEY(new Guid("{6B223B6A-162E-4AA9-B39F-05D678FC6D77}"), 100);

					/// <summary>
					/// <para>Name:     System.Music.TrackNumber -- PKEY_Music_TrackNumber</para>
					/// <para>Description:</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 7 (PIDSI_MUSIC_TRACK)</para>
					/// </summary>
					public static PROPERTYKEY TrackNumber
						=> new PROPERTYKEY(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 7);
				}

				/// <summary>Note Properties</summary>
				public static class Note
				{
					/// <summary>
					/// <para>Name:     System.Note.Color -- PKEY_Note_Color</para>
					/// <para>Description:</para>
					/// <para>Type:     UInt16 -- VT_UI2</para>
					/// <para>FormatID: {4776CAFA-BCE4-4CB1-A23E-265E76D8EB11}, 100</para>
					/// </summary>
					public static PROPERTYKEY Color
						=> new PROPERTYKEY(new Guid("{4776CAFA-BCE4-4CB1-A23E-265E76D8EB11}"), 100);

					/// <summary>
					/// <para>Name:     System.Note.ColorText -- PKEY_Note_ColorText</para>
					/// <para>
					/// Description: This is the user-friendly form of System.Note.Color. Not intended to be parsed programmatically.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {46B4E8DE-CDB2-440D-885C-1658EB65B914}, 100</para>
					/// </summary>
					public static PROPERTYKEY ColorText
						=> new PROPERTYKEY(new Guid("{46B4E8DE-CDB2-440D-885C-1658EB65B914}"), 100);
				}

				/// <summary>Photo Properties</summary>
				public static class Photo
				{
					/// <summary>
					/// <para>Name:     System.Photo.Aperture -- PKEY_Photo_Aperture</para>
					/// <para>
					/// Description: PropertyTagExifAperture. Calculated from PKEY_Photo_ApertureNumerator and PKEY_Photo_ApertureDenominator
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 37378</para>
					/// </summary>
					public static PROPERTYKEY Aperture
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37378);

					/// <summary>
					/// <para>Name:     System.Photo.ApertureDenominator -- PKEY_Photo_ApertureDenominator</para>
					/// <para>Description: Denominator of PKEY_Photo_Aperture</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {E1A9A38B-6685-46BD-875E-570DC7AD7320}, 100</para>
					/// </summary>
					public static PROPERTYKEY ApertureDenominator
						=> new PROPERTYKEY(new Guid("{E1A9A38B-6685-46BD-875E-570DC7AD7320}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.ApertureNumerator -- PKEY_Photo_ApertureNumerator</para>
					/// <para>Description: Numerator of PKEY_Photo_Aperture</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {0337ECEC-39FB-4581-A0BD-4C4CC51E9914}, 100</para>
					/// </summary>
					public static PROPERTYKEY ApertureNumerator
						=> new PROPERTYKEY(new Guid("{0337ECEC-39FB-4581-A0BD-4C4CC51E9914}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.Brightness -- PKEY_Photo_Brightness</para>
					/// <para>
					/// Description: This is the brightness of the photo. Calculated from PKEY_Photo_BrightnessNumerator and
					/// PKEY_Photo_BrightnessDenominator. The units are "APEX", normally in the range of -99.99 to 99.99. If the numerator of
					/// the recorded value is FFFFFFFF.H, "Unknown" should be indicated.
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: {1A701BF6-478C-4361-83AB-3701BB053C58}, 100 (PropertyTagExifBrightness)</para>
					/// </summary>
					public static PROPERTYKEY Brightness
						=> new PROPERTYKEY(new Guid("{1A701BF6-478C-4361-83AB-3701BB053C58}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.BrightnessDenominator -- PKEY_Photo_BrightnessDenominator</para>
					/// <para>Description: Denominator of PKEY_Photo_Brightness</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {6EBE6946-2321-440A-90F0-C043EFD32476}, 100</para>
					/// </summary>
					public static PROPERTYKEY BrightnessDenominator
						=> new PROPERTYKEY(new Guid("{6EBE6946-2321-440A-90F0-C043EFD32476}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.BrightnessNumerator -- PKEY_Photo_BrightnessNumerator</para>
					/// <para>Description: Numerator of PKEY_Photo_Brightness</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {9E7D118F-B314-45A0-8CFB-D654B917C9E9}, 100</para>
					/// </summary>
					public static PROPERTYKEY BrightnessNumerator
						=> new PROPERTYKEY(new Guid("{9E7D118F-B314-45A0-8CFB-D654B917C9E9}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.CameraManufacturer -- PKEY_Photo_CameraManufacturer</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 271 (PropertyTagEquipMake)</para>
					/// </summary>
					public static PROPERTYKEY CameraManufacturer
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 271);

					/// <summary>
					/// <para>Name:     System.Photo.CameraModel -- PKEY_Photo_CameraModel</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 272 (PropertyTagEquipModel)</para>
					/// </summary>
					public static PROPERTYKEY CameraModel
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 272);

					/// <summary>
					/// <para>Name:     System.Photo.CameraSerialNumber -- PKEY_Photo_CameraSerialNumber</para>
					/// <para>Description: Serial number of camera that produced this photo</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 273</para>
					/// </summary>
					public static PROPERTYKEY CameraSerialNumber
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 273);

					/// <summary>
					/// <para>Name:     System.Photo.Contrast -- PKEY_Photo_Contrast</para>
					/// <para>
					/// Description: This indicates the direction of contrast processing applied by the camera when the image was shot.
					/// </para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {2A785BA9-8D23-4DED-82E6-60A350C86A10}, 100</para>
					/// </summary>
					public static PROPERTYKEY Contrast
						=> new PROPERTYKEY(new Guid("{2A785BA9-8D23-4DED-82E6-60A350C86A10}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.ContrastText -- PKEY_Photo_ContrastText</para>
					/// <para>
					/// Description: This is the user-friendly form of System.Photo.Contrast. Not intended to be parsed programmatically.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {59DDE9F2-5253-40EA-9A8B-479E96C6249A}, 100</para>
					/// </summary>
					public static PROPERTYKEY ContrastText
						=> new PROPERTYKEY(new Guid("{59DDE9F2-5253-40EA-9A8B-479E96C6249A}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.DateTaken -- PKEY_Photo_DateTaken</para>
					/// <para>Description: PropertyTagExifDTOrig</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 36867</para>
					/// </summary>
					public static PROPERTYKEY DateTaken
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 36867);

					/// <summary>
					/// <para>Name:     System.Photo.DigitalZoom -- PKEY_Photo_DigitalZoom</para>
					/// <para>
					/// Description: PropertyTagExifDigitalZoom. Calculated from PKEY_Photo_DigitalZoomNumerator and PKEY_Photo_DigitalZoomDenominator
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: {F85BF840-A925-4BC2-B0C4-8E36B598679E}, 100</para>
					/// </summary>
					public static PROPERTYKEY DigitalZoom
						=> new PROPERTYKEY(new Guid("{F85BF840-A925-4BC2-B0C4-8E36B598679E}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.DigitalZoomDenominator -- PKEY_Photo_DigitalZoomDenominator</para>
					/// <para>Description: Denominator of PKEY_Photo_DigitalZoom</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {745BAF0E-E5C1-4CFB-8A1B-D031A0A52393}, 100</para>
					/// </summary>
					public static PROPERTYKEY DigitalZoomDenominator
						=> new PROPERTYKEY(new Guid("{745BAF0E-E5C1-4CFB-8A1B-D031A0A52393}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.DigitalZoomNumerator -- PKEY_Photo_DigitalZoomNumerator</para>
					/// <para>Description: Numerator of PKEY_Photo_DigitalZoom</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {16CBB924-6500-473B-A5BE-F1599BCBE413}, 100</para>
					/// </summary>
					public static PROPERTYKEY DigitalZoomNumerator
						=> new PROPERTYKEY(new Guid("{16CBB924-6500-473B-A5BE-F1599BCBE413}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.Event -- PKEY_Photo_Event</para>
					/// <para>Description: The event at which the photo was taken</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 18248</para>
					/// </summary>
					public static PROPERTYKEY Event
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 18248);

					/// <summary>
					/// <para>Name:     System.Photo.EXIFVersion -- PKEY_Photo_EXIFVersion</para>
					/// <para>Description: The EXIF version.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {D35F743A-EB2E-47F2-A286-844132CB1427}, 100</para>
					/// </summary>
					public static PROPERTYKEY EXIFVersion
						=> new PROPERTYKEY(new Guid("{D35F743A-EB2E-47F2-A286-844132CB1427}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.ExposureBias -- PKEY_Photo_ExposureBias</para>
					/// <para>
					/// Description: PropertyTagExifExposureBias. Calculated from PKEY_Photo_ExposureBiasNumerator and PKEY_Photo_ExposureBiasDenominator
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 37380</para>
					/// </summary>
					public static PROPERTYKEY ExposureBias
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37380);

					/// <summary>
					/// <para>Name:     System.Photo.ExposureBiasDenominator -- PKEY_Photo_ExposureBiasDenominator</para>
					/// <para>Description: Denominator of PKEY_Photo_ExposureBias</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: {AB205E50-04B7-461C-A18C-2F233836E627}, 100</para>
					/// </summary>
					public static PROPERTYKEY ExposureBiasDenominator
						=> new PROPERTYKEY(new Guid("{AB205E50-04B7-461C-A18C-2F233836E627}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.ExposureBiasNumerator -- PKEY_Photo_ExposureBiasNumerator</para>
					/// <para>Description: Numerator of PKEY_Photo_ExposureBias</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: {738BF284-1D87-420B-92CF-5834BF6EF9ED}, 100</para>
					/// </summary>
					public static PROPERTYKEY ExposureBiasNumerator
						=> new PROPERTYKEY(new Guid("{738BF284-1D87-420B-92CF-5834BF6EF9ED}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.ExposureIndex -- PKEY_Photo_ExposureIndex</para>
					/// <para>
					/// Description: PropertyTagExifExposureIndex. Calculated from PKEY_Photo_ExposureIndexNumerator and PKEY_Photo_ExposureIndexDenominator
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: {967B5AF8-995A-46ED-9E11-35B3C5B9782D}, 100</para>
					/// </summary>
					public static PROPERTYKEY ExposureIndex
						=> new PROPERTYKEY(new Guid("{967B5AF8-995A-46ED-9E11-35B3C5B9782D}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.ExposureIndexDenominator -- PKEY_Photo_ExposureIndexDenominator</para>
					/// <para>Description: Denominator of PKEY_Photo_ExposureIndex</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {93112F89-C28B-492F-8A9D-4BE2062CEE8A}, 100</para>
					/// </summary>
					public static PROPERTYKEY ExposureIndexDenominator
						=> new PROPERTYKEY(new Guid("{93112F89-C28B-492F-8A9D-4BE2062CEE8A}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.ExposureIndexNumerator -- PKEY_Photo_ExposureIndexNumerator</para>
					/// <para>Description: Numerator of PKEY_Photo_ExposureIndex</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {CDEDCF30-8919-44DF-8F4C-4EB2FFDB8D89}, 100</para>
					/// </summary>
					public static PROPERTYKEY ExposureIndexNumerator
						=> new PROPERTYKEY(new Guid("{CDEDCF30-8919-44DF-8F4C-4EB2FFDB8D89}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.ExposureProgram -- PKEY_Photo_ExposureProgram</para>
					/// <para>Description:</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 34850 (PropertyTagExifExposureProg)</para>
					/// </summary>
					public static PROPERTYKEY ExposureProgram
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 34850);

					/// <summary>
					/// <para>Name:     System.Photo.ExposureProgramText -- PKEY_Photo_ExposureProgramText</para>
					/// <para>
					/// Description: This is the user-friendly form of System.Photo.ExposureProgram. Not intended to be parsed programmatically.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {FEC690B7-5F30-4646-AE47-4CAAFBA884A3}, 100</para>
					/// </summary>
					public static PROPERTYKEY ExposureProgramText
						=> new PROPERTYKEY(new Guid("{FEC690B7-5F30-4646-AE47-4CAAFBA884A3}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.ExposureTime -- PKEY_Photo_ExposureTime</para>
					/// <para>
					/// Description: PropertyTagExifExposureTime. Calculated from PKEY_Photo_ExposureTimeNumerator and PKEY_Photo_ExposureTimeDenominator
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 33434</para>
					/// </summary>
					public static PROPERTYKEY ExposureTime
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 33434);

					/// <summary>
					/// <para>Name:     System.Photo.ExposureTimeDenominator -- PKEY_Photo_ExposureTimeDenominator</para>
					/// <para>Description: Denominator of PKEY_Photo_ExposureTime</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {55E98597-AD16-42E0-B624-21599A199838}, 100</para>
					/// </summary>
					public static PROPERTYKEY ExposureTimeDenominator
						=> new PROPERTYKEY(new Guid("{55E98597-AD16-42E0-B624-21599A199838}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.ExposureTimeNumerator -- PKEY_Photo_ExposureTimeNumerator</para>
					/// <para>Description: Numerator of PKEY_Photo_ExposureTime</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {257E44E2-9031-4323-AC38-85C552871B2E}, 100</para>
					/// </summary>
					public static PROPERTYKEY ExposureTimeNumerator
						=> new PROPERTYKEY(new Guid("{257E44E2-9031-4323-AC38-85C552871B2E}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.Flash -- PKEY_Photo_Flash</para>
					/// <para>Description: PropertyTagExifFlash</para>
					/// <para>Type:     Byte -- VT_UI1</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 37385</para>
					/// </summary>
					public static PROPERTYKEY Flash
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37385);

					/// <summary>
					/// <para>Name:     System.Photo.FlashEnergy -- PKEY_Photo_FlashEnergy</para>
					/// <para>
					/// Description: PropertyTagExifFlashEnergy. Calculated from PKEY_Photo_FlashEnergyNumerator and PKEY_Photo_FlashEnergyDenominator
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 41483</para>
					/// </summary>
					public static PROPERTYKEY FlashEnergy
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 41483);

					/// <summary>
					/// <para>Name:     System.Photo.FlashEnergyDenominator -- PKEY_Photo_FlashEnergyDenominator</para>
					/// <para>Description: Denominator of PKEY_Photo_FlashEnergy</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {D7B61C70-6323-49CD-A5FC-C84277162C97}, 100</para>
					/// </summary>
					public static PROPERTYKEY FlashEnergyDenominator
						=> new PROPERTYKEY(new Guid("{D7B61C70-6323-49CD-A5FC-C84277162C97}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.FlashEnergyNumerator -- PKEY_Photo_FlashEnergyNumerator</para>
					/// <para>Description: Numerator of PKEY_Photo_FlashEnergy</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {FCAD3D3D-0858-400F-AAA3-2F66CCE2A6BC}, 100</para>
					/// </summary>
					public static PROPERTYKEY FlashEnergyNumerator
						=> new PROPERTYKEY(new Guid("{FCAD3D3D-0858-400F-AAA3-2F66CCE2A6BC}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.FlashManufacturer -- PKEY_Photo_FlashManufacturer</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {AABAF6C9-E0C5-4719-8585-57B103E584FE}, 100</para>
					/// </summary>
					public static PROPERTYKEY FlashManufacturer
						=> new PROPERTYKEY(new Guid("{AABAF6C9-E0C5-4719-8585-57B103E584FE}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.FlashModel -- PKEY_Photo_FlashModel</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {FE83BB35-4D1A-42E2-916B-06F3E1AF719E}, 100</para>
					/// </summary>
					public static PROPERTYKEY FlashModel
						=> new PROPERTYKEY(new Guid("{FE83BB35-4D1A-42E2-916B-06F3E1AF719E}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.FlashText -- PKEY_Photo_FlashText</para>
					/// <para>
					/// Description: This is the user-friendly form of System.Photo.Flash. Not intended to be parsed programmatically.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {6B8B68F6-200B-47EA-8D25-D8050F57339F}, 100</para>
					/// </summary>
					public static PROPERTYKEY FlashText
						=> new PROPERTYKEY(new Guid("{6B8B68F6-200B-47EA-8D25-D8050F57339F}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.FNumber -- PKEY_Photo_FNumber</para>
					/// <para>Description: PropertyTagExifFNumber. Calculated from PKEY_Photo_FNumberNumerator and PKEY_Photo_FNumberDenominator</para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 33437</para>
					/// </summary>
					public static PROPERTYKEY FNumber
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 33437);

					/// <summary>
					/// <para>Name:     System.Photo.FNumberDenominator -- PKEY_Photo_FNumberDenominator</para>
					/// <para>Description: Denominator of PKEY_Photo_FNumber</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {E92A2496-223B-4463-A4E3-30EABBA79D80}, 100</para>
					/// </summary>
					public static PROPERTYKEY FNumberDenominator
						=> new PROPERTYKEY(new Guid("{E92A2496-223B-4463-A4E3-30EABBA79D80}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.FNumberNumerator -- PKEY_Photo_FNumberNumerator</para>
					/// <para>Description: Numerator of PKEY_Photo_FNumber</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {1B97738A-FDFC-462F-9D93-1957E08BE90C}, 100</para>
					/// </summary>
					public static PROPERTYKEY FNumberNumerator
						=> new PROPERTYKEY(new Guid("{1B97738A-FDFC-462F-9D93-1957E08BE90C}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.FocalLength -- PKEY_Photo_FocalLength</para>
					/// <para>
					/// Description: PropertyTagExifFocalLength. Calculated from PKEY_Photo_FocalLengthNumerator and PKEY_Photo_FocalLengthDenominator
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 37386</para>
					/// </summary>
					public static PROPERTYKEY FocalLength
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37386);

					/// <summary>
					/// <para>Name:     System.Photo.FocalLengthDenominator -- PKEY_Photo_FocalLengthDenominator</para>
					/// <para>Description: Denominator of PKEY_Photo_FocalLength</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {305BC615-DCA1-44A5-9FD4-10C0BA79412E}, 100</para>
					/// </summary>
					public static PROPERTYKEY FocalLengthDenominator
						=> new PROPERTYKEY(new Guid("{305BC615-DCA1-44A5-9FD4-10C0BA79412E}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.FocalLengthInFilm -- PKEY_Photo_FocalLengthInFilm</para>
					/// <para>Description:</para>
					/// <para>Type:     UInt16 -- VT_UI2</para>
					/// <para>FormatID: {A0E74609-B84D-4F49-B860-462BD9971F98}, 100</para>
					/// </summary>
					public static PROPERTYKEY FocalLengthInFilm
						=> new PROPERTYKEY(new Guid("{A0E74609-B84D-4F49-B860-462BD9971F98}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.FocalLengthNumerator -- PKEY_Photo_FocalLengthNumerator</para>
					/// <para>Description: Numerator of PKEY_Photo_FocalLength</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {776B6B3B-1E3D-4B0C-9A0E-8FBAF2A8492A}, 100</para>
					/// </summary>
					public static PROPERTYKEY FocalLengthNumerator
						=> new PROPERTYKEY(new Guid("{776B6B3B-1E3D-4B0C-9A0E-8FBAF2A8492A}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.FocalPlaneXResolution -- PKEY_Photo_FocalPlaneXResolution</para>
					/// <para>
					/// Description: PropertyTagExifFocalXRes. Calculated from PKEY_Photo_FocalPlaneXResolutionNumerator and PKEY_Photo_FocalPlaneXResolutionDenominator.
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: {CFC08D97-C6F7-4484-89DD-EBEF4356FE76}, 100</para>
					/// </summary>
					public static PROPERTYKEY FocalPlaneXResolution
						=> new PROPERTYKEY(new Guid("{CFC08D97-C6F7-4484-89DD-EBEF4356FE76}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.FocalPlaneXResolutionDenominator -- PKEY_Photo_FocalPlaneXResolutionDenominator</para>
					/// <para>Description: Denominator of PKEY_Photo_FocalPlaneXResolution</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {0933F3F5-4786-4F46-A8E8-D64DD37FA521}, 100</para>
					/// </summary>
					public static PROPERTYKEY FocalPlaneXResolutionDenominator
						=> new PROPERTYKEY(new Guid("{0933F3F5-4786-4F46-A8E8-D64DD37FA521}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.FocalPlaneXResolutionNumerator -- PKEY_Photo_FocalPlaneXResolutionNumerator</para>
					/// <para>Description: Numerator of PKEY_Photo_FocalPlaneXResolution</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {DCCB10AF-B4E2-4B88-95F9-031B4D5AB490}, 100</para>
					/// </summary>
					public static PROPERTYKEY FocalPlaneXResolutionNumerator
						=> new PROPERTYKEY(new Guid("{DCCB10AF-B4E2-4B88-95F9-031B4D5AB490}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.FocalPlaneYResolution -- PKEY_Photo_FocalPlaneYResolution</para>
					/// <para>
					/// Description: PropertyTagExifFocalYRes. Calculated from PKEY_Photo_FocalPlaneYResolutionNumerator and PKEY_Photo_FocalPlaneYResolutionDenominator.
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: {4FFFE4D0-914F-4AC4-8D6F-C9C61DE169B1}, 100</para>
					/// </summary>
					public static PROPERTYKEY FocalPlaneYResolution
						=> new PROPERTYKEY(new Guid("{4FFFE4D0-914F-4AC4-8D6F-C9C61DE169B1}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.FocalPlaneYResolutionDenominator -- PKEY_Photo_FocalPlaneYResolutionDenominator</para>
					/// <para>Description: Denominator of PKEY_Photo_FocalPlaneYResolution</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {1D6179A6-A876-4031-B013-3347B2B64DC8}, 100</para>
					/// </summary>
					public static PROPERTYKEY FocalPlaneYResolutionDenominator
						=> new PROPERTYKEY(new Guid("{1D6179A6-A876-4031-B013-3347B2B64DC8}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.FocalPlaneYResolutionNumerator -- PKEY_Photo_FocalPlaneYResolutionNumerator</para>
					/// <para>Description: Numerator of PKEY_Photo_FocalPlaneYResolution</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {A2E541C5-4440-4BA8-867E-75CFC06828CD}, 100</para>
					/// </summary>
					public static PROPERTYKEY FocalPlaneYResolutionNumerator
						=> new PROPERTYKEY(new Guid("{A2E541C5-4440-4BA8-867E-75CFC06828CD}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.GainControl -- PKEY_Photo_GainControl</para>
					/// <para>
					/// Description: This indicates the degree of overall image gain adjustment. Calculated from
					/// PKEY_Photo_GainControlNumerator and PKEY_Photo_GainControlDenominator.
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: {FA304789-00C7-4D80-904A-1E4DCC7265AA}, 100 (PropertyTagExifGainControl)</para>
					/// </summary>
					public static PROPERTYKEY GainControl
						=> new PROPERTYKEY(new Guid("{FA304789-00C7-4D80-904A-1E4DCC7265AA}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.GainControlDenominator -- PKEY_Photo_GainControlDenominator</para>
					/// <para>Description: Denominator of PKEY_Photo_GainControl</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {42864DFD-9DA4-4F77-BDED-4AAD7B256735}, 100</para>
					/// </summary>
					public static PROPERTYKEY GainControlDenominator
						=> new PROPERTYKEY(new Guid("{42864DFD-9DA4-4F77-BDED-4AAD7B256735}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.GainControlNumerator -- PKEY_Photo_GainControlNumerator</para>
					/// <para>Description: Numerator of PKEY_Photo_GainControl</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {8E8ECF7C-B7B8-4EB8-A63F-0EE715C96F9E}, 100</para>
					/// </summary>
					public static PROPERTYKEY GainControlNumerator
						=> new PROPERTYKEY(new Guid("{8E8ECF7C-B7B8-4EB8-A63F-0EE715C96F9E}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.GainControlText -- PKEY_Photo_GainControlText</para>
					/// <para>
					/// Description: This is the user-friendly form of System.Photo.GainControl. Not intended to be parsed programmatically.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C06238B2-0BF9-4279-A723-25856715CB9D}, 100</para>
					/// </summary>
					public static PROPERTYKEY GainControlText
						=> new PROPERTYKEY(new Guid("{C06238B2-0BF9-4279-A723-25856715CB9D}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.ISOSpeed -- PKEY_Photo_ISOSpeed</para>
					/// <para>Description: PropertyTagExifISOSpeed</para>
					/// <para>Type:     UInt16 -- VT_UI2</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 34855</para>
					/// </summary>
					public static PROPERTYKEY ISOSpeed
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 34855);

					/// <summary>
					/// <para>Name:     System.Photo.LensManufacturer -- PKEY_Photo_LensManufacturer</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {E6DDCAF7-29C5-4F0A-9A68-D19412EC7090}, 100</para>
					/// </summary>
					public static PROPERTYKEY LensManufacturer
						=> new PROPERTYKEY(new Guid("{E6DDCAF7-29C5-4F0A-9A68-D19412EC7090}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.LensModel -- PKEY_Photo_LensModel</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {E1277516-2B5F-4869-89B1-2E585BD38B7A}, 100</para>
					/// </summary>
					public static PROPERTYKEY LensModel
						=> new PROPERTYKEY(new Guid("{E1277516-2B5F-4869-89B1-2E585BD38B7A}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.LightSource -- PKEY_Photo_LightSource</para>
					/// <para>Description: PropertyTagExifLightSource</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 37384</para>
					/// </summary>
					public static PROPERTYKEY LightSource
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37384);

					/// <summary>
					/// <para>Name:     System.Photo.MakerNote -- PKEY_Photo_MakerNote</para>
					/// <para>Description:</para>
					/// <para>Type:     Buffer -- VT_VECTOR | VT_UI1 (For variants: VT_ARRAY | VT_UI1)</para>
					/// <para>FormatID: {FA303353-B659-4052-85E9-BCAC79549B84}, 100</para>
					/// </summary>
					public static PROPERTYKEY MakerNote
						=> new PROPERTYKEY(new Guid("{FA303353-B659-4052-85E9-BCAC79549B84}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.MakerNoteOffset -- PKEY_Photo_MakerNoteOffset</para>
					/// <para>Description:</para>
					/// <para>Type:     UInt64 -- VT_UI8</para>
					/// <para>FormatID: {813F4124-34E6-4D17-AB3E-6B1F3C2247A1}, 100</para>
					/// </summary>
					public static PROPERTYKEY MakerNoteOffset
						=> new PROPERTYKEY(new Guid("{813F4124-34E6-4D17-AB3E-6B1F3C2247A1}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.MaxAperture -- PKEY_Photo_MaxAperture</para>
					/// <para>Description: Calculated from PKEY_Photo_MaxApertureNumerator and PKEY_Photo_MaxApertureDenominator</para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: {08F6D7C2-E3F2-44FC-AF1E-5AA5C81A2D3E}, 100</para>
					/// </summary>
					public static PROPERTYKEY MaxAperture
						=> new PROPERTYKEY(new Guid("{08F6D7C2-E3F2-44FC-AF1E-5AA5C81A2D3E}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.MaxApertureDenominator -- PKEY_Photo_MaxApertureDenominator</para>
					/// <para>Description: Denominator of PKEY_Photo_MaxAperture</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {C77724D4-601F-46C5-9B89-C53F93BCEB77}, 100</para>
					/// </summary>
					public static PROPERTYKEY MaxApertureDenominator
						=> new PROPERTYKEY(new Guid("{C77724D4-601F-46C5-9B89-C53F93BCEB77}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.MaxApertureNumerator -- PKEY_Photo_MaxApertureNumerator</para>
					/// <para>Description: Numerator of PKEY_Photo_MaxAperture</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {C107E191-A459-44C5-9AE6-B952AD4B906D}, 100</para>
					/// </summary>
					public static PROPERTYKEY MaxApertureNumerator
						=> new PROPERTYKEY(new Guid("{C107E191-A459-44C5-9AE6-B952AD4B906D}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.MeteringMode -- PKEY_Photo_MeteringMode</para>
					/// <para>Description: PropertyTagExifMeteringMode</para>
					/// <para>Type:     UInt16 -- VT_UI2</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 37383</para>
					/// </summary>
					public static PROPERTYKEY MeteringMode
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37383);

					/// <summary>
					/// <para>Name:     System.Photo.MeteringModeText -- PKEY_Photo_MeteringModeText</para>
					/// <para>
					/// Description: This is the user-friendly form of System.Photo.MeteringMode. Not intended to be parsed programmatically.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {F628FD8C-7BA8-465A-A65B-C5AA79263A9E}, 100</para>
					/// </summary>
					public static PROPERTYKEY MeteringModeText
						=> new PROPERTYKEY(new Guid("{F628FD8C-7BA8-465A-A65B-C5AA79263A9E}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.Orientation -- PKEY_Photo_Orientation</para>
					/// <para>Description: This is the image orientation viewed in terms of rows and columns.</para>
					/// <para>Type:     UInt16 -- VT_UI2</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 274 (PropertyTagOrientation)</para>
					/// </summary>
					public static PROPERTYKEY Orientation
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 274);

					/// <summary>
					/// <para>Name:     System.Photo.OrientationText -- PKEY_Photo_OrientationText</para>
					/// <para>
					/// Description: This is the user-friendly form of System.Photo.Orientation. Not intended to be parsed programmatically.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {A9EA193C-C511-498A-A06B-58E2776DCC28}, 100</para>
					/// </summary>
					public static PROPERTYKEY OrientationText
						=> new PROPERTYKEY(new Guid("{A9EA193C-C511-498A-A06B-58E2776DCC28}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.PeopleNames -- PKEY_Photo_PeopleNames</para>
					/// <para>Description: The people tags on an image.</para>
					/// <para>
					/// Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR) Legacy code may treat this as VT_LPSTR.
					/// </para>
					/// <para>FormatID: {E8309B6E-084C-49B4-B1FC-90A80331B638}, 100</para>
					/// </summary>
					public static PROPERTYKEY PeopleNames
						=> new PROPERTYKEY(new Guid("{E8309B6E-084C-49B4-B1FC-90A80331B638}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.PhotometricInterpretation -- PKEY_Photo_PhotometricInterpretation</para>
					/// <para>
					/// Description: This is the pixel composition. In JPEG compressed data, a JPEG marker is used instead of this property.
					/// </para>
					/// <para>Type:     UInt16 -- VT_UI2</para>
					/// <para>FormatID: {341796F1-1DF9-4B1C-A564-91BDEFA43877}, 100</para>
					/// </summary>
					public static PROPERTYKEY PhotometricInterpretation
						=> new PROPERTYKEY(new Guid("{341796F1-1DF9-4B1C-A564-91BDEFA43877}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.PhotometricInterpretationText -- PKEY_Photo_PhotometricInterpretationText</para>
					/// <para>
					/// Description: This is the user-friendly form of System.Photo.PhotometricInterpretation. Not intended to be parsed programmatically.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {821437D6-9EAB-4765-A589-3B1CBBD22A61}, 100</para>
					/// </summary>
					public static PROPERTYKEY PhotometricInterpretationText
						=> new PROPERTYKEY(new Guid("{821437D6-9EAB-4765-A589-3B1CBBD22A61}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.ProgramMode -- PKEY_Photo_ProgramMode</para>
					/// <para>
					/// Description: This is the class of the program used by the camera to set exposure when the picture is taken.
					/// </para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {6D217F6D-3F6A-4825-B470-5F03CA2FBE9B}, 100</para>
					/// </summary>
					public static PROPERTYKEY ProgramMode
						=> new PROPERTYKEY(new Guid("{6D217F6D-3F6A-4825-B470-5F03CA2FBE9B}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.ProgramModeText -- PKEY_Photo_ProgramModeText</para>
					/// <para>
					/// Description: This is the user-friendly form of System.Photo.ProgramMode. Not intended to be parsed programmatically.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {7FE3AA27-2648-42F3-89B0-454E5CB150C3}, 100</para>
					/// </summary>
					public static PROPERTYKEY ProgramModeText
						=> new PROPERTYKEY(new Guid("{7FE3AA27-2648-42F3-89B0-454E5CB150C3}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.RelatedSoundFile -- PKEY_Photo_RelatedSoundFile</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {318A6B45-087F-4DC2-B8CC-05359551FC9E}, 100</para>
					/// </summary>
					public static PROPERTYKEY RelatedSoundFile
						=> new PROPERTYKEY(new Guid("{318A6B45-087F-4DC2-B8CC-05359551FC9E}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.Saturation -- PKEY_Photo_Saturation</para>
					/// <para>
					/// Description: This indicates the direction of saturation processing applied by the camera when the image was shot.
					/// </para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {49237325-A95A-4F67-B211-816B2D45D2E0}, 100</para>
					/// </summary>
					public static PROPERTYKEY Saturation
						=> new PROPERTYKEY(new Guid("{49237325-A95A-4F67-B211-816B2D45D2E0}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.SaturationText -- PKEY_Photo_SaturationText</para>
					/// <para>
					/// Description: This is the user-friendly form of System.Photo.Saturation. Not intended to be parsed programmatically.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {61478C08-B600-4A84-BBE4-E99C45F0A072}, 100</para>
					/// </summary>
					public static PROPERTYKEY SaturationText
						=> new PROPERTYKEY(new Guid("{61478C08-B600-4A84-BBE4-E99C45F0A072}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.Sharpness -- PKEY_Photo_Sharpness</para>
					/// <para>
					/// Description: This indicates the direction of sharpness processing applied by the camera when the image was shot.
					/// </para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {FC6976DB-8349-4970-AE97-B3C5316A08F0}, 100</para>
					/// </summary>
					public static PROPERTYKEY Sharpness
						=> new PROPERTYKEY(new Guid("{FC6976DB-8349-4970-AE97-B3C5316A08F0}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.SharpnessText -- PKEY_Photo_SharpnessText</para>
					/// <para>
					/// Description: This is the user-friendly form of System.Photo.Sharpness. Not intended to be parsed programmatically.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {51EC3F47-DD50-421D-8769-334F50424B1E}, 100</para>
					/// </summary>
					public static PROPERTYKEY SharpnessText
						=> new PROPERTYKEY(new Guid("{51EC3F47-DD50-421D-8769-334F50424B1E}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.ShutterSpeed -- PKEY_Photo_ShutterSpeed</para>
					/// <para>
					/// Description: PropertyTagExifShutterSpeed. Calculated from PKEY_Photo_ShutterSpeedNumerator and PKEY_Photo_ShutterSpeedDenominator
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 37377</para>
					/// </summary>
					public static PROPERTYKEY ShutterSpeed
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37377);

					/// <summary>
					/// <para>Name:     System.Photo.ShutterSpeedDenominator -- PKEY_Photo_ShutterSpeedDenominator</para>
					/// <para>Description: Denominator of PKEY_Photo_ShutterSpeed</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: {E13D8975-81C7-4948-AE3F-37CAE11E8FF7}, 100</para>
					/// </summary>
					public static PROPERTYKEY ShutterSpeedDenominator
						=> new PROPERTYKEY(new Guid("{E13D8975-81C7-4948-AE3F-37CAE11E8FF7}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.ShutterSpeedNumerator -- PKEY_Photo_ShutterSpeedNumerator</para>
					/// <para>Description: Numerator of PKEY_Photo_ShutterSpeed</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: {16EA4042-D6F4-4BCA-8349-7C78D30FB333}, 100</para>
					/// </summary>
					public static PROPERTYKEY ShutterSpeedNumerator
						=> new PROPERTYKEY(new Guid("{16EA4042-D6F4-4BCA-8349-7C78D30FB333}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.SubjectDistance -- PKEY_Photo_SubjectDistance</para>
					/// <para>
					/// Description: PropertyTagExifSubjectDist. Calculated from PKEY_Photo_SubjectDistanceNumerator and PKEY_Photo_SubjectDistanceDenominator
					/// </para>
					/// <para>Type:     Double -- VT_R8</para>
					/// <para>FormatID: (FMTID_ImageProperties) {14B81DA1-0135-4D31-96D9-6CBFC9671A99}, 37382</para>
					/// </summary>
					public static PROPERTYKEY SubjectDistance
						=> new PROPERTYKEY(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37382);

					/// <summary>
					/// <para>Name:     System.Photo.SubjectDistanceDenominator -- PKEY_Photo_SubjectDistanceDenominator</para>
					/// <para>Description: Denominator of PKEY_Photo_SubjectDistance</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {0C840A88-B043-466D-9766-D4B26DA3FA77}, 100</para>
					/// </summary>
					public static PROPERTYKEY SubjectDistanceDenominator
						=> new PROPERTYKEY(new Guid("{0C840A88-B043-466D-9766-D4B26DA3FA77}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.SubjectDistanceNumerator -- PKEY_Photo_SubjectDistanceNumerator</para>
					/// <para>Description: Numerator of PKEY_Photo_SubjectDistance</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {8AF4961C-F526-43E5-AA81-DB768219178D}, 100</para>
					/// </summary>
					public static PROPERTYKEY SubjectDistanceNumerator
						=> new PROPERTYKEY(new Guid("{8AF4961C-F526-43E5-AA81-DB768219178D}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.TagViewAggregate -- PKEY_Photo_TagViewAggregate</para>
					/// <para>Description: A read-only aggregation of tag-like properties for use in building views.</para>
					/// <para>
					/// Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR) Legacy code may treat this as VT_LPSTR.
					/// </para>
					/// <para>FormatID: {B812F15D-C2D8-4BBF-BACD-79744346113F}, 100</para>
					/// </summary>
					public static PROPERTYKEY TagViewAggregate
						=> new PROPERTYKEY(new Guid("{B812F15D-C2D8-4BBF-BACD-79744346113F}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.TranscodedForSync -- PKEY_Photo_TranscodedForSync</para>
					/// <para>Description:</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {9A8EBB75-6458-4E82-BACB-35C0095B03BB}, 100</para>
					/// </summary>
					public static PROPERTYKEY TranscodedForSync
						=> new PROPERTYKEY(new Guid("{9A8EBB75-6458-4E82-BACB-35C0095B03BB}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.WhiteBalance -- PKEY_Photo_WhiteBalance</para>
					/// <para>Description: This indicates the white balance mode set when the image was shot.</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {EE3D3D8A-5381-4CFA-B13B-AAF66B5F4EC9}, 100</para>
					/// </summary>
					public static PROPERTYKEY WhiteBalance
						=> new PROPERTYKEY(new Guid("{EE3D3D8A-5381-4CFA-B13B-AAF66B5F4EC9}"), 100);

					/// <summary>
					/// <para>Name:     System.Photo.WhiteBalanceText -- PKEY_Photo_WhiteBalanceText</para>
					/// <para>
					/// Description: This is the user-friendly form of System.Photo.WhiteBalance. Not intended to be parsed programmatically.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {6336B95E-C7A7-426D-86FD-7AE3D39C84B4}, 100</para>
					/// </summary>
					public static PROPERTYKEY WhiteBalanceText
						=> new PROPERTYKEY(new Guid("{6336B95E-C7A7-426D-86FD-7AE3D39C84B4}"), 100);
				}

				/// <summary>PropGroup Properties</summary>
				public static class PropGroup
				{
					/// <summary>
					/// <para>Name:     System.PropGroup.Advanced -- PKEY_PropGroup_Advanced</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {900A403B-097B-4B95-8AE2-071FDAEEB118}, 100</para>
					/// </summary>
					public static PROPERTYKEY Advanced
						=> new PROPERTYKEY(new Guid("{900A403B-097B-4B95-8AE2-071FDAEEB118}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.Audio -- PKEY_PropGroup_Audio</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {2804D469-788F-48AA-8570-71B9C187E138}, 100</para>
					/// </summary>
					public static PROPERTYKEY Audio
						=> new PROPERTYKEY(new Guid("{2804D469-788F-48AA-8570-71B9C187E138}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.Calendar -- PKEY_PropGroup_Calendar</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {9973D2B5-BFD8-438A-BA94-5349B293181A}, 100</para>
					/// </summary>
					public static PROPERTYKEY Calendar
						=> new PROPERTYKEY(new Guid("{9973D2B5-BFD8-438A-BA94-5349B293181A}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.Camera -- PKEY_PropGroup_Camera</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {DE00DE32-547E-4981-AD4B-542F2E9007D8}, 100</para>
					/// </summary>
					public static PROPERTYKEY Camera
						=> new PROPERTYKEY(new Guid("{DE00DE32-547E-4981-AD4B-542F2E9007D8}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.Contact -- PKEY_PropGroup_Contact</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {DF975FD3-250A-4004-858F-34E29A3E37AA}, 100</para>
					/// </summary>
					public static PROPERTYKEY Contact
						=> new PROPERTYKEY(new Guid("{DF975FD3-250A-4004-858F-34E29A3E37AA}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.Content -- PKEY_PropGroup_Content</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {D0DAB0BA-368A-4050-A882-6C010FD19A4F}, 100</para>
					/// </summary>
					public static PROPERTYKEY Content
						=> new PROPERTYKEY(new Guid("{D0DAB0BA-368A-4050-A882-6C010FD19A4F}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.Description -- PKEY_PropGroup_Description</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {8969B275-9475-4E00-A887-FF93B8B41E44}, 100</para>
					/// </summary>
					public static PROPERTYKEY Description
						=> new PROPERTYKEY(new Guid("{8969B275-9475-4E00-A887-FF93B8B41E44}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.FileSystem -- PKEY_PropGroup_FileSystem</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {E3A7D2C1-80FC-4B40-8F34-30EA111BDC2E}, 100</para>
					/// </summary>
					public static PROPERTYKEY FileSystem
						=> new PROPERTYKEY(new Guid("{E3A7D2C1-80FC-4B40-8F34-30EA111BDC2E}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.General -- PKEY_PropGroup_General</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {CC301630-B192-4C22-B372-9F4C6D338E07}, 100</para>
					/// </summary>
					public static PROPERTYKEY General
						=> new PROPERTYKEY(new Guid("{CC301630-B192-4C22-B372-9F4C6D338E07}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.GPS -- PKEY_PropGroup_GPS</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {F3713ADA-90E3-4E11-AAE5-FDC17685B9BE}, 100</para>
					/// </summary>
					public static PROPERTYKEY GPS
						=> new PROPERTYKEY(new Guid("{F3713ADA-90E3-4E11-AAE5-FDC17685B9BE}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.Image -- PKEY_PropGroup_Image</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {E3690A87-0FA8-4A2A-9A9F-FCE8827055AC}, 100</para>
					/// </summary>
					public static PROPERTYKEY Image
						=> new PROPERTYKEY(new Guid("{E3690A87-0FA8-4A2A-9A9F-FCE8827055AC}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.Media -- PKEY_PropGroup_Media</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {61872CF7-6B5E-4B4B-AC2D-59DA84459248}, 100</para>
					/// </summary>
					public static PROPERTYKEY Media
						=> new PROPERTYKEY(new Guid("{61872CF7-6B5E-4B4B-AC2D-59DA84459248}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.MediaAdvanced -- PKEY_PropGroup_MediaAdvanced</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {8859A284-DE7E-4642-99BA-D431D044B1EC}, 100</para>
					/// </summary>
					public static PROPERTYKEY MediaAdvanced
						=> new PROPERTYKEY(new Guid("{8859A284-DE7E-4642-99BA-D431D044B1EC}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.Message -- PKEY_PropGroup_Message</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {7FD7259D-16B4-4135-9F97-7C96ECD2FA9E}, 100</para>
					/// </summary>
					public static PROPERTYKEY Message
						=> new PROPERTYKEY(new Guid("{7FD7259D-16B4-4135-9F97-7C96ECD2FA9E}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.Music -- PKEY_PropGroup_Music</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {68DD6094-7216-40F1-A029-43FE7127043F}, 100</para>
					/// </summary>
					public static PROPERTYKEY Music
						=> new PROPERTYKEY(new Guid("{68DD6094-7216-40F1-A029-43FE7127043F}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.Origin -- PKEY_PropGroup_Origin</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {2598D2FB-5569-4367-95DF-5CD3A177E1A5}, 100</para>
					/// </summary>
					public static PROPERTYKEY Origin
						=> new PROPERTYKEY(new Guid("{2598D2FB-5569-4367-95DF-5CD3A177E1A5}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.PhotoAdvanced -- PKEY_PropGroup_PhotoAdvanced</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {0CB2BF5A-9EE7-4A86-8222-F01E07FDADAF}, 100</para>
					/// </summary>
					public static PROPERTYKEY PhotoAdvanced
						=> new PROPERTYKEY(new Guid("{0CB2BF5A-9EE7-4A86-8222-F01E07FDADAF}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.RecordedTV -- PKEY_PropGroup_RecordedTV</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {E7B33238-6584-4170-A5C0-AC25EFD9DA56}, 100</para>
					/// </summary>
					public static PROPERTYKEY RecordedTV
						=> new PROPERTYKEY(new Guid("{E7B33238-6584-4170-A5C0-AC25EFD9DA56}"), 100);

					/// <summary>
					/// <para>Name:     System.PropGroup.Video -- PKEY_PropGroup_Video</para>
					/// <para>Description:</para>
					/// <para>Type:     Null -- VT_NULL</para>
					/// <para>FormatID: {BEBE0920-7671-4C54-A3EB-49FDDFC191EE}, 100</para>
					/// </summary>
					public static PROPERTYKEY Video
						=> new PROPERTYKEY(new Guid("{BEBE0920-7671-4C54-A3EB-49FDDFC191EE}"), 100);
				}

				/// <summary>PropList Properties</summary>
				public static class PropList
				{
					/// <summary>
					/// <para>Name:     System.PropList.ConflictPrompt -- PKEY_PropList_ConflictPrompt</para>
					/// <para>
					/// Description: The list of properties to show in the file operation conflict resolution dialog. Properties with empty
					/// values will not be displayed. Register under the regvalue of "ConflictPrompt".
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 11</para>
					/// </summary>
					public static PROPERTYKEY ConflictPrompt
						=> new PROPERTYKEY(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 11);

					/// <summary>
					/// <para>Name:     System.PropList.ContentViewModeForBrowse -- PKEY_PropList_ContentViewModeForBrowse</para>
					/// <para>
					/// Description: The list of properties to show in the content view mode of an item in the context of browsing. Register
					/// the regvalue under the name of "ContentViewModeForBrowse".
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 13</para>
					/// </summary>
					public static PROPERTYKEY ContentViewModeForBrowse
						=> new PROPERTYKEY(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 13);

					/// <summary>
					/// <para>Name:     System.PropList.ContentViewModeForSearch -- PKEY_PropList_ContentViewModeForSearch</para>
					/// <para>
					/// Description: The list of properties to show in the content view mode of an item in the context of searching. Register
					/// the regvalue under the name of "ContentViewModeForSearch".
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 14</para>
					/// </summary>
					public static PROPERTYKEY ContentViewModeForSearch
						=> new PROPERTYKEY(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 14);

					/// <summary>
					/// <para>Name:     System.PropList.ExtendedTileInfo -- PKEY_PropList_ExtendedTileInfo</para>
					/// <para>
					/// Description: The list of properties to show in the listview on extended tiles. Register under the regvalue of "ExtendedTileInfo".
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 9</para>
					/// </summary>
					public static PROPERTYKEY ExtendedTileInfo
						=> new PROPERTYKEY(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 9);

					/// <summary>
					/// <para>Name:     System.PropList.FileOperationPrompt -- PKEY_PropList_FileOperationPrompt</para>
					/// <para>
					/// Description: The list of properties to show in the file operation confirmation dialog. Properties with empty values
					/// will not be displayed. If this list is not specified, then the InfoTip property list is used instead. Register under
					/// the regvalue of "FileOperationPrompt".
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 10</para>
					/// </summary>
					public static PROPERTYKEY FileOperationPrompt
						=> new PROPERTYKEY(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 10);

					/// <summary>
					/// <para>Name:     System.PropList.FullDetails -- PKEY_PropList_FullDetails</para>
					/// <para>
					/// Description: The list of all the properties to show in the details page. Property groups can be included in this list
					/// in order to more easily organize the UI. Register under the regvalue of "FullDetails".
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 2</para>
					/// </summary>
					public static PROPERTYKEY FullDetails
						=> new PROPERTYKEY(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 2);

					/// <summary>
					/// <para>Name:     System.PropList.InfoTip -- PKEY_PropList_InfoTip</para>
					/// <para>
					/// Description: The list of properties to show in the infotip. Properties with empty values will not be displayed.
					/// Register under the regvalue of "InfoTip".
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 4 (PID_PROPLIST_INFOTIP)</para>
					/// </summary>
					public static PROPERTYKEY InfoTip
						=> new PROPERTYKEY(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 4);

					/// <summary>
					/// <para>Name:     System.PropList.NonPersonal -- PKEY_PropList_NonPersonal</para>
					/// <para>
					/// Description: The list of properties that are considered 'non-personal'. When told to remove all non-personal
					/// properties from a given file, the system will leave these particular properties untouched. Register under the
					/// regvalue of "NonPersonal".
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {49D1091F-082E-493F-B23F-D2308AA9668C}, 100</para>
					/// </summary>
					public static PROPERTYKEY NonPersonal
						=> new PROPERTYKEY(new Guid("{49D1091F-082E-493F-B23F-D2308AA9668C}"), 100);

					/// <summary>
					/// <para>Name:     System.PropList.PreviewDetails -- PKEY_PropList_PreviewDetails</para>
					/// <para>
					/// Description: The list of properties to display in the preview pane. Register under the regvalue of "PreviewDetails".
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 8</para>
					/// </summary>
					public static PROPERTYKEY PreviewDetails
						=> new PROPERTYKEY(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 8);

					/// <summary>
					/// <para>Name:     System.PropList.PreviewTitle -- PKEY_PropList_PreviewTitle</para>
					/// <para>
					/// Description: The one or two properties to display in the preview pane title section. The optional second property is
					/// displayed as a subtitle. Register under the regvalue of "PreviewTitle".
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 6</para>
					/// </summary>
					public static PROPERTYKEY PreviewTitle
						=> new PROPERTYKEY(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 6);

					/// <summary>
					/// <para>Name:     System.PropList.QuickTip -- PKEY_PropList_QuickTip</para>
					/// <para>
					/// Description: The list of properties to show in the infotip when the item is on a slow network. Properties with empty
					/// values will not be displayed. Register under the regvalue of "QuickTip".
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 5 (PID_PROPLIST_QUICKTIP)</para>
					/// </summary>
					public static PROPERTYKEY QuickTip
						=> new PROPERTYKEY(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 5);

					/// <summary>
					/// <para>Name:     System.PropList.TileInfo -- PKEY_PropList_TileInfo</para>
					/// <para>Description: The list of properties to show in the listview on tiles. Register under the regvalue of "TileInfo".</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {C9944A21-A406-48FE-8225-AEC7E24C211B}, 3 (PID_PROPLIST_TILEINFO)</para>
					/// </summary>
					public static PROPERTYKEY TileInfo
						=> new PROPERTYKEY(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 3);

					/// <summary>
					/// <para>Name:     System.PropList.XPDetailsPanel -- PKEY_PropList_XPDetailsPanel</para>
					/// <para>Description: The list of properties to display in the XP webview details panel. Obsolete.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_WebView) {F2275480-F782-4291-BD94-F13693513AEC}, 0 (PID_DISPLAY_PROPERTIES)</para>
					/// </summary>
					public static PROPERTYKEY XPDetailsPanel
						=> new PROPERTYKEY(new Guid("{F2275480-F782-4291-BD94-F13693513AEC}"), 0);
				}

				/// <summary>RecordedTV Properties</summary>
				public static class RecordedTV
				{
					/// <summary>
					/// <para>Name:     System.RecordedTV.ChannelNumber -- PKEY_RecordedTV_ChannelNumber</para>
					/// <para>Description: Example: 42</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 7</para>
					/// </summary>
					public static PROPERTYKEY ChannelNumber
						=> new PROPERTYKEY(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 7);

					/// <summary>
					/// <para>Name:     System.RecordedTV.Credits -- PKEY_RecordedTV_Credits</para>
					/// <para>Description: Example: "Don Messick/Frank Welker/Casey Kasem/Heather North/Nicole Jaffe;;;"</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 4</para>
					/// </summary>
					public static PROPERTYKEY Credits
						=> new PROPERTYKEY(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 4);

					/// <summary>
					/// <para>Name:     System.RecordedTV.DateContentExpires -- PKEY_RecordedTV_DateContentExpires</para>
					/// <para>Description:</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 15</para>
					/// </summary>
					public static PROPERTYKEY DateContentExpires
						=> new PROPERTYKEY(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 15);

					/// <summary>
					/// <para>Name:     System.RecordedTV.EpisodeName -- PKEY_RecordedTV_EpisodeName</para>
					/// <para>Description: Example: "Nowhere to Hyde"</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 2</para>
					/// </summary>
					public static PROPERTYKEY EpisodeName
						=> new PROPERTYKEY(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 2);

					/// <summary>
					/// <para>Name:     System.RecordedTV.IsATSCContent -- PKEY_RecordedTV_IsATSCContent</para>
					/// <para>Description:</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 16</para>
					/// </summary>
					public static PROPERTYKEY IsATSCContent
						=> new PROPERTYKEY(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 16);

					/// <summary>
					/// <para>Name:     System.RecordedTV.IsClosedCaptioningAvailable -- PKEY_RecordedTV_IsClosedCaptioningAvailable</para>
					/// <para>Description:</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 12</para>
					/// </summary>
					public static PROPERTYKEY IsClosedCaptioningAvailable
						=> new PROPERTYKEY(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 12);

					/// <summary>
					/// <para>Name:     System.RecordedTV.IsDTVContent -- PKEY_RecordedTV_IsDTVContent</para>
					/// <para>Description:</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 17</para>
					/// </summary>
					public static PROPERTYKEY IsDTVContent
						=> new PROPERTYKEY(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 17);

					/// <summary>
					/// <para>Name:     System.RecordedTV.IsHDContent -- PKEY_RecordedTV_IsHDContent</para>
					/// <para>Description:</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 18</para>
					/// </summary>
					public static PROPERTYKEY IsHDContent
						=> new PROPERTYKEY(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 18);

					/// <summary>
					/// <para>Name:     System.RecordedTV.IsRepeatBroadcast -- PKEY_RecordedTV_IsRepeatBroadcast</para>
					/// <para>Description:</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 13</para>
					/// </summary>
					public static PROPERTYKEY IsRepeatBroadcast
						=> new PROPERTYKEY(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 13);

					/// <summary>
					/// <para>Name:     System.RecordedTV.IsSAP -- PKEY_RecordedTV_IsSAP</para>
					/// <para>Description:</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 14</para>
					/// </summary>
					public static PROPERTYKEY IsSAP
						=> new PROPERTYKEY(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 14);

					/// <summary>
					/// <para>Name:     System.RecordedTV.NetworkAffiliation -- PKEY_RecordedTV_NetworkAffiliation</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {2C53C813-FB63-4E22-A1AB-0B331CA1E273}, 100</para>
					/// </summary>
					public static PROPERTYKEY NetworkAffiliation
						=> new PROPERTYKEY(new Guid("{2C53C813-FB63-4E22-A1AB-0B331CA1E273}"), 100);

					/// <summary>
					/// <para>Name:     System.RecordedTV.OriginalBroadcastDate -- PKEY_RecordedTV_OriginalBroadcastDate</para>
					/// <para>Description:</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: {4684FE97-8765-4842-9C13-F006447B178C}, 100</para>
					/// </summary>
					public static PROPERTYKEY OriginalBroadcastDate
						=> new PROPERTYKEY(new Guid("{4684FE97-8765-4842-9C13-F006447B178C}"), 100);

					/// <summary>
					/// <para>Name:     System.RecordedTV.ProgramDescription -- PKEY_RecordedTV_ProgramDescription</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 3</para>
					/// </summary>
					public static PROPERTYKEY ProgramDescription
						=> new PROPERTYKEY(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 3);

					/// <summary>
					/// <para>Name:     System.RecordedTV.RecordingTime -- PKEY_RecordedTV_RecordingTime</para>
					/// <para>Description:</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: {A5477F61-7A82-4ECA-9DDE-98B69B2479B3}, 100</para>
					/// </summary>
					public static PROPERTYKEY RecordingTime
						=> new PROPERTYKEY(new Guid("{A5477F61-7A82-4ECA-9DDE-98B69B2479B3}"), 100);

					/// <summary>
					/// <para>Name:     System.RecordedTV.StationCallSign -- PKEY_RecordedTV_StationCallSign</para>
					/// <para>Description: Example: "TOONP"</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {6D748DE2-8D38-4CC3-AC60-F009B057C557}, 5</para>
					/// </summary>
					public static PROPERTYKEY StationCallSign
						=> new PROPERTYKEY(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 5);

					/// <summary>
					/// <para>Name:     System.RecordedTV.StationName -- PKEY_RecordedTV_StationName</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {1B5439E7-EBA1-4AF8-BDD7-7AF1D4549493}, 100</para>
					/// </summary>
					public static PROPERTYKEY StationName
						=> new PROPERTYKEY(new Guid("{1B5439E7-EBA1-4AF8-BDD7-7AF1D4549493}"), 100);
				}

				/// <summary>Search Properties</summary>
				public static class Search
				{
					/// <summary>
					/// <para>Name:     System.Search.AutoSummary -- PKEY_Search_AutoSummary</para>
					/// <para>Description: General Summary of the document.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {560C36C0-503A-11CF-BAA1-00004C752A9A}, 2</para>
					/// </summary>
					public static PROPERTYKEY AutoSummary
						=> new PROPERTYKEY(new Guid("{560C36C0-503A-11CF-BAA1-00004C752A9A}"), 2);

					/// <summary>
					/// <para>Name:     System.Search.ContainerHash -- PKEY_Search_ContainerHash</para>
					/// <para>Description: Hash code used to identify attachments to be deleted based on a common container url</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {BCEEE283-35DF-4D53-826A-F36A3EEFC6BE}, 100</para>
					/// </summary>
					public static PROPERTYKEY ContainerHash
						=> new PROPERTYKEY(new Guid("{BCEEE283-35DF-4D53-826A-F36A3EEFC6BE}"), 100);

					/// <summary>
					/// <para>Name:     System.Search.Contents -- PKEY_Search_Contents</para>
					/// <para>
					/// Description: The contents of the item. This property is for query restrictions only; it cannot be retrieved in a
					/// query result. The Indexing Service friendly name is 'contents'.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_Storage) {B725F130-47EF-101A-A5F1-02608C9EEBAC}, 19 (PID_STG_CONTENTS)</para>
					/// </summary>
					public static PROPERTYKEY Contents
						=> new PROPERTYKEY(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 19);

					/// <summary>
					/// <para>Name:     System.Search.EntryID -- PKEY_Search_EntryID</para>
					/// <para>
					/// Description: The entry ID for an item within a given catalog in the Windows Search Index. This value may be recycled,
					/// and therefore is not considered unique over time.
					/// </para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: (FMTID_Query) {49691C90-7E17-101A-A91C-08002B2ECDA9}, 5 (PROPID_QUERY_WORKID)</para>
					/// </summary>
					public static PROPERTYKEY EntryID
						=> new PROPERTYKEY(new Guid("{49691C90-7E17-101A-A91C-08002B2ECDA9}"), 5);

					/// <summary>
					/// <para>Name:     System.Search.ExtendedProperties -- PKEY_Search_ExtendedProperties</para>
					/// <para>Description:</para>
					/// <para>Type:     Blob -- VT_BLOB</para>
					/// <para>FormatID: {7B03B546-FA4F-4A52-A2FE-03D5311E5865}, 100</para>
					/// </summary>
					public static PROPERTYKEY ExtendedProperties
						=> new PROPERTYKEY(new Guid("{7B03B546-FA4F-4A52-A2FE-03D5311E5865}"), 100);

					/// <summary>
					/// <para>Name:     System.Search.GatherTime -- PKEY_Search_GatherTime</para>
					/// <para>
					/// Description: The Datetime that the Windows Search Gatherer process last pushed properties of this document to the
					/// Windows Search Gatherer Plugins.
					/// </para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: {0B63E350-9CCC-11D0-BCDB-00805FCCCE04}, 8</para>
					/// </summary>
					public static PROPERTYKEY GatherTime
						=> new PROPERTYKEY(new Guid("{0B63E350-9CCC-11D0-BCDB-00805FCCCE04}"), 8);

					/// <summary>
					/// <para>Name:     System.Search.HitCount -- PKEY_Search_HitCount</para>
					/// <para>
					/// Description: When using CONTAINS over the Windows Search Index, this is the number of matches of the term. If there
					/// are multiple CONTAINS, an AND computes the min number of hits and an OR the max number of hits.
					/// </para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: (FMTID_Query) {49691C90-7E17-101A-A91C-08002B2ECDA9}, 4 (PROPID_QUERY_HITCOUNT)</para>
					/// </summary>
					public static PROPERTYKEY HitCount
						=> new PROPERTYKEY(new Guid("{49691C90-7E17-101A-A91C-08002B2ECDA9}"), 4);

					/// <summary>
					/// <para>Name:     System.Search.IsClosedDirectory -- PKEY_Search_IsClosedDirectory</para>
					/// <para>
					/// Description: If this property is emitted with a value of TRUE, then it indicates that this URL's last modified time
					/// applies to all of it's children, and if this URL is deleted then all of it's children are deleted as well. For
					/// example, this would be emitted as TRUE when emitting the URL of an email so that all attachments are tied to the last
					/// modified time of that email.
					/// </para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {0B63E343-9CCC-11D0-BCDB-00805FCCCE04}, 23</para>
					/// </summary>
					public static PROPERTYKEY IsClosedDirectory
						=> new PROPERTYKEY(new Guid("{0B63E343-9CCC-11D0-BCDB-00805FCCCE04}"), 23);

					/// <summary>
					/// <para>Name:     System.Search.IsFullyContained -- PKEY_Search_IsFullyContained</para>
					/// <para>
					/// Description: Any child URL of a URL which has System.Search.IsClosedDirectory=TRUE must emit
					/// System.Search.IsFullyContained=TRUE. This ensures that the URL is not deleted at the end of a crawl because it hasn't
					/// been visited (which is the normal mechanism for detecting deletes). For example an email attachment would emit this property
					/// </para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {0B63E343-9CCC-11D0-BCDB-00805FCCCE04}, 24</para>
					/// </summary>
					public static PROPERTYKEY IsFullyContained
						=> new PROPERTYKEY(new Guid("{0B63E343-9CCC-11D0-BCDB-00805FCCCE04}"), 24);

					/// <summary>
					/// <para>Name:     System.Search.QueryFocusedSummary -- PKEY_Search_QueryFocusedSummary</para>
					/// <para>Description: Query Focused Summary of the document.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {560C36C0-503A-11CF-BAA1-00004C752A9A}, 3</para>
					/// </summary>
					public static PROPERTYKEY QueryFocusedSummary
						=> new PROPERTYKEY(new Guid("{560C36C0-503A-11CF-BAA1-00004C752A9A}"), 3);

					/// <summary>
					/// <para>Name:     System.Search.QueryFocusedSummaryWithFallback -- PKEY_Search_QueryFocusedSummaryWithFallback</para>
					/// <para>Description: Query Focused Summary of the document, if none is available it returns the AutoSummary.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {560C36C0-503A-11CF-BAA1-00004C752A9A}, 4</para>
					/// </summary>
					public static PROPERTYKEY QueryFocusedSummaryWithFallback
						=> new PROPERTYKEY(new Guid("{560C36C0-503A-11CF-BAA1-00004C752A9A}"), 4);

					/// <summary>
					/// <para>Name:     System.Search.Rank -- PKEY_Search_Rank</para>
					/// <para>Description: Relevance rank of row. Ranges from 0-1000. Larger numbers = better matches. Query-time only.</para>
					/// <para>Type:     Int32 -- VT_I4</para>
					/// <para>FormatID: (FMTID_Query) {49691C90-7E17-101A-A91C-08002B2ECDA9}, 3 (PROPID_QUERY_RANK)</para>
					/// </summary>
					public static PROPERTYKEY Rank
						=> new PROPERTYKEY(new Guid("{49691C90-7E17-101A-A91C-08002B2ECDA9}"), 3);

					/// <summary>
					/// <para>Name:     System.Search.Store -- PKEY_Search_Store</para>
					/// <para>Description: The identifier for the protocol handler that produced this item. (E.g. MAPI, CSC, FILE etc.)</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {A06992B3-8CAF-4ED7-A547-B259E32AC9FC}, 100</para>
					/// </summary>
					public static PROPERTYKEY Store
						=> new PROPERTYKEY(new Guid("{A06992B3-8CAF-4ED7-A547-B259E32AC9FC}"), 100);

					/// <summary>
					/// <para>Name:     System.Search.UrlToIndex -- PKEY_Search_UrlToIndex</para>
					/// <para>
					/// Description: This property should be emitted by a container IFilter for each child URL within the container. The
					/// children will eventually be crawled by the indexer if they are within scope.
					/// </para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {0B63E343-9CCC-11D0-BCDB-00805FCCCE04}, 2</para>
					/// </summary>
					public static PROPERTYKEY UrlToIndex
						=> new PROPERTYKEY(new Guid("{0B63E343-9CCC-11D0-BCDB-00805FCCCE04}"), 2);

					/// <summary>
					/// <para>Name:     System.Search.UrlToIndexWithModificationTime -- PKEY_Search_UrlToIndexWithModificationTime</para>
					/// <para>
					/// Description: This property is the same as System.Search.UrlToIndex except that it includes the time the URL was last
					/// modified. This is an optimization for the indexer as it doesn't have to call back into the protocol handler to ask
					/// for this information to determine if the content needs to be indexed again. The property is a vector with two
					/// elements, a VT_LPWSTR with the URL and a VT_FILETIME for the last modified time.
					/// </para>
					/// <para>Type:     Multivalue Any -- VT_VECTOR | VT_NULL (For variants: VT_ARRAY | VT_NULL)</para>
					/// <para>FormatID: {0B63E343-9CCC-11D0-BCDB-00805FCCCE04}, 12</para>
					/// </summary>
					public static PROPERTYKEY UrlToIndexWithModificationTime
						=> new PROPERTYKEY(new Guid("{0B63E343-9CCC-11D0-BCDB-00805FCCCE04}"), 12);
				}

				/// <summary>Shell Properties</summary>
				public static class Shell
				{
					/// <summary>
					/// <para>Name:     System.Shell.OmitFromView -- PKEY_Shell_OmitFromView</para>
					/// <para>Description: Set this to a string value of 'True' to omit this item from shell views</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {DE35258C-C695-4CBC-B982-38B0AD24CED0}, 2</para>
					/// </summary>
					public static PROPERTYKEY OmitFromView
						=> new PROPERTYKEY(new Guid("{DE35258C-C695-4CBC-B982-38B0AD24CED0}"), 2);

					/// <summary>
					/// <para>Name:     System.Shell.SFGAOFlagsStrings -- PKEY_Shell_SFGAOFlagsStrings</para>
					/// <para>Description: Expresses the SFGAO flags as string values and is used as a query optimization.</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: {D6942081-D53B-443D-AD47-5E059D9CD27A}, 2</para>
					/// </summary>
					public static PROPERTYKEY SFGAOFlagsStrings
						=> new PROPERTYKEY(new Guid("{D6942081-D53B-443D-AD47-5E059D9CD27A}"), 2);
				}

				/// <summary>Software Properties</summary>
				public static class Software
				{
					/// <summary>
					/// <para>Name:     System.Software.DateLastUsed -- PKEY_Software_DateLastUsed</para>
					/// <para>Description:</para>
					/// <para>Type:     DateTime -- VT_FILETIME (For variants: VT_DATE)</para>
					/// <para>FormatID: {841E4F90-FF59-4D16-8947-E81BBFFAB36D}, 16</para>
					/// </summary>
					public static PROPERTYKEY DateLastUsed
						=> new PROPERTYKEY(new Guid("{841E4F90-FF59-4D16-8947-E81BBFFAB36D}"), 16);

					/// <summary>
					/// <para>Name:     System.Software.ProductName -- PKEY_Software_ProductName</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (PSFMTID_VERSION) {0CEF7D53-FA64-11D1-A203-0000F81FEDEE}, 7</para>
					/// </summary>
					public static PROPERTYKEY ProductName
						=> new PROPERTYKEY(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 7);
				}

				/// <summary>Sync Properties</summary>
				public static class Sync
				{
					/// <summary>
					/// <para>Name:     System.Sync.Comments -- PKEY_Sync_Comments</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 13</para>
					/// </summary>
					public static PROPERTYKEY Comments
						=> new PROPERTYKEY(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 13);

					/// <summary>
					/// <para>Name:     System.Sync.ConflictDescription -- PKEY_Sync_ConflictDescription</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {CE50C159-2FB8-41FD-BE68-D3E042E274BC}, 4</para>
					/// </summary>
					public static PROPERTYKEY ConflictDescription
						=> new PROPERTYKEY(new Guid("{CE50C159-2FB8-41FD-BE68-D3E042E274BC}"), 4);

					/// <summary>
					/// <para>Name:     System.Sync.ConflictFirstLocation -- PKEY_Sync_ConflictFirstLocation</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {CE50C159-2FB8-41FD-BE68-D3E042E274BC}, 6</para>
					/// </summary>
					public static PROPERTYKEY ConflictFirstLocation
						=> new PROPERTYKEY(new Guid("{CE50C159-2FB8-41FD-BE68-D3E042E274BC}"), 6);

					/// <summary>
					/// <para>Name:     System.Sync.ConflictSecondLocation -- PKEY_Sync_ConflictSecondLocation</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {CE50C159-2FB8-41FD-BE68-D3E042E274BC}, 7</para>
					/// </summary>
					public static PROPERTYKEY ConflictSecondLocation
						=> new PROPERTYKEY(new Guid("{CE50C159-2FB8-41FD-BE68-D3E042E274BC}"), 7);

					/// <summary>
					/// <para>Name:     System.Sync.HandlerCollectionID -- PKEY_Sync_HandlerCollectionID</para>
					/// <para>Description:</para>
					/// <para>Type:     Guid -- VT_CLSID</para>
					/// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 2</para>
					/// </summary>
					public static PROPERTYKEY HandlerCollectionID
						=> new PROPERTYKEY(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 2);

					/// <summary>
					/// <para>Name:     System.Sync.HandlerID -- PKEY_Sync_HandlerID</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 3</para>
					/// </summary>
					public static PROPERTYKEY HandlerID
						=> new PROPERTYKEY(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 3);

					/// <summary>
					/// <para>Name:     System.Sync.HandlerName -- PKEY_Sync_HandlerName</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {CE50C159-2FB8-41FD-BE68-D3E042E274BC}, 2</para>
					/// </summary>
					public static PROPERTYKEY HandlerName
						=> new PROPERTYKEY(new Guid("{CE50C159-2FB8-41FD-BE68-D3E042E274BC}"), 2);

					/// <summary>
					/// <para>Name:     System.Sync.HandlerType -- PKEY_Sync_HandlerType</para>
					/// <para>Description:</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 8</para>
					/// </summary>
					public static PROPERTYKEY HandlerType
						=> new PROPERTYKEY(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 8);

					/// <summary>
					/// <para>Name:     System.Sync.HandlerTypeLabel -- PKEY_Sync_HandlerTypeLabel</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 9</para>
					/// </summary>
					public static PROPERTYKEY HandlerTypeLabel
						=> new PROPERTYKEY(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 9);

					/// <summary>
					/// <para>Name:     System.Sync.ItemID -- PKEY_Sync_ItemID</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 6</para>
					/// </summary>
					public static PROPERTYKEY ItemID
						=> new PROPERTYKEY(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 6);

					/// <summary>
					/// <para>Name:     System.Sync.ItemName -- PKEY_Sync_ItemName</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {CE50C159-2FB8-41FD-BE68-D3E042E274BC}, 3</para>
					/// </summary>
					public static PROPERTYKEY ItemName
						=> new PROPERTYKEY(new Guid("{CE50C159-2FB8-41FD-BE68-D3E042E274BC}"), 3);

					/// <summary>
					/// <para>Name:     System.Sync.ProgressPercentage -- PKEY_Sync_ProgressPercentage</para>
					/// <para>Description: An integer value between 0 and 100 representing the percentage completed.</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 23</para>
					/// </summary>
					public static PROPERTYKEY ProgressPercentage
						=> new PROPERTYKEY(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 23);

					/// <summary>
					/// <para>Name:     System.Sync.State -- PKEY_Sync_State</para>
					/// <para>Description: Sync state.</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 24</para>
					/// </summary>
					public static PROPERTYKEY State
						=> new PROPERTYKEY(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 24);

					/// <summary>
					/// <para>Name:     System.Sync.Status -- PKEY_Sync_Status</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {7BD5533E-AF15-44DB-B8C8-BD6624E1D032}, 10</para>
					/// </summary>
					public static PROPERTYKEY Status
						=> new PROPERTYKEY(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 10);
				}

				/// <summary>Task Properties</summary>
				public static class Task
				{
					/// <summary>
					/// <para>Name:     System.Task.BillingInformation -- PKEY_Task_BillingInformation</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {D37D52C6-261C-4303-82B3-08B926AC6F12}, 100</para>
					/// </summary>
					public static PROPERTYKEY BillingInformation
						=> new PROPERTYKEY(new Guid("{D37D52C6-261C-4303-82B3-08B926AC6F12}"), 100);

					/// <summary>
					/// <para>Name:     System.Task.CompletionStatus -- PKEY_Task_CompletionStatus</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {084D8A0A-E6D5-40DE-BF1F-C8820E7C877C}, 100</para>
					/// </summary>
					public static PROPERTYKEY CompletionStatus
						=> new PROPERTYKEY(new Guid("{084D8A0A-E6D5-40DE-BF1F-C8820E7C877C}"), 100);

					/// <summary>
					/// <para>Name:     System.Task.Owner -- PKEY_Task_Owner</para>
					/// <para>Description:</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: {08C7CC5F-60F2-4494-AD75-55E3E0B5ADD0}, 100</para>
					/// </summary>
					public static PROPERTYKEY Owner
						=> new PROPERTYKEY(new Guid("{08C7CC5F-60F2-4494-AD75-55E3E0B5ADD0}"), 100);
				}

				/// <summary>Video Properties</summary>
				public static class Video
				{
					/// <summary>
					/// <para>Name:     System.Video.Compression -- PKEY_Video_Compression</para>
					/// <para>Description: Indicates the level of compression for the video stream. "Compression".</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 10 (PIDVSI_COMPRESSION)</para>
					/// </summary>
					public static PROPERTYKEY Compression
						=> new PROPERTYKEY(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 10);

					/// <summary>
					/// <para>Name:     System.Video.Director -- PKEY_Video_Director</para>
					/// <para>Description:</para>
					/// <para>Type:     Multivalue String -- VT_VECTOR | VT_LPWSTR (For variants: VT_ARRAY | VT_BSTR)</para>
					/// <para>FormatID: (PSGUID_MEDIAFILESUMMARYINFORMATION) {64440492-4C8B-11D1-8B70-080036B11A03}, 20 (PIDMSI_DIRECTOR)</para>
					/// </summary>
					public static PROPERTYKEY Director
						=> new PROPERTYKEY(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 20);

					/// <summary>
					/// <para>Name:     System.Video.EncodingBitrate -- PKEY_Video_EncodingBitrate</para>
					/// <para>Description: Indicates the data rate in "bits per second" for the video stream. "DataRate".</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 8 (PIDVSI_DATA_RATE)</para>
					/// </summary>
					public static PROPERTYKEY EncodingBitrate
						=> new PROPERTYKEY(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 8);

					/// <summary>
					/// <para>Name:     System.Video.FourCC -- PKEY_Video_FourCC</para>
					/// <para>Description: Indicates the 4CC for the video stream.</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 44</para>
					/// </summary>
					public static PROPERTYKEY FourCC
						=> new PROPERTYKEY(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 44);

					/// <summary>
					/// <para>Name:     System.Video.FrameHeight -- PKEY_Video_FrameHeight</para>
					/// <para>Description: Indicates the frame height for the video stream.</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 4</para>
					/// </summary>
					public static PROPERTYKEY FrameHeight
						=> new PROPERTYKEY(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 4);

					/// <summary>
					/// <para>Name:     System.Video.FrameRate -- PKEY_Video_FrameRate</para>
					/// <para>Description: Indicates the frame rate in "frames per millisecond" for the video stream. "FrameRate".</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 6 (PIDVSI_FRAME_RATE)</para>
					/// </summary>
					public static PROPERTYKEY FrameRate
						=> new PROPERTYKEY(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 6);

					/// <summary>
					/// <para>Name:     System.Video.FrameWidth -- PKEY_Video_FrameWidth</para>
					/// <para>Description: Indicates the frame width for the video stream.</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 3</para>
					/// </summary>
					public static PROPERTYKEY FrameWidth
						=> new PROPERTYKEY(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 3);

					/// <summary>
					/// <para>Name:     System.Video.HorizontalAspectRatio -- PKEY_Video_HorizontalAspectRatio</para>
					/// <para>
					/// Description: Indicates the horizontal portion of the aspect ratio. The X portion of XX:YY, like 16:9.
					/// </para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 42</para>
					/// </summary>
					public static PROPERTYKEY HorizontalAspectRatio
						=> new PROPERTYKEY(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 42);

					/// <summary>
					/// <para>Name:     System.Video.SampleSize -- PKEY_Video_SampleSize</para>
					/// <para>Description: Indicates the sample size in bits for the video stream. "SampleSize".</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 9 (PIDVSI_SAMPLE_SIZE)</para>
					/// </summary>
					public static PROPERTYKEY SampleSize
						=> new PROPERTYKEY(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 9);

					/// <summary>
					/// <para>Name:     System.Video.StreamName -- PKEY_Video_StreamName</para>
					/// <para>Description: Indicates the name for the video stream. "StreamName".</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 2 (PIDVSI_STREAM_NAME)</para>
					/// </summary>
					public static PROPERTYKEY StreamName
						=> new PROPERTYKEY(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 2);

					/// <summary>
					/// <para>Name:     System.Video.StreamNumber -- PKEY_Video_StreamNumber</para>
					/// <para>Description: "Stream Number".</para>
					/// <para>Type:     UInt16 -- VT_UI2</para>
					/// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 11 (PIDVSI_STREAM_NUMBER)</para>
					/// </summary>
					public static PROPERTYKEY StreamNumber
						=> new PROPERTYKEY(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 11);

					/// <summary>
					/// <para>Name:     System.Video.TotalBitrate -- PKEY_Video_TotalBitrate</para>
					/// <para>Description: Indicates the total data rate in "bits per second" for all video and audio streams.</para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 43 (PIDVSI_TOTAL_BITRATE)</para>
					/// </summary>
					public static PROPERTYKEY TotalBitrate
						=> new PROPERTYKEY(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 43);

					/// <summary>
					/// <para>Name:     System.Video.TranscodedForSync -- PKEY_Video_TranscodedForSync</para>
					/// <para>Description:</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 46</para>
					/// </summary>
					public static PROPERTYKEY TranscodedForSync
						=> new PROPERTYKEY(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 46);

					/// <summary>
					/// <para>Name:     System.Video.VerticalAspectRatio -- PKEY_Video_VerticalAspectRatio</para>
					/// <para>
					/// Description: Indicates the vertical portion of the aspect ratio. The Y portion of XX:YY, like 16:9.
					/// </para>
					/// <para>Type:     UInt32 -- VT_UI4</para>
					/// <para>FormatID: (FMTID_VideoSummaryInformation) {64440491-4C8B-11D1-8B70-080036B11A03}, 45</para>
					/// </summary>
					public static PROPERTYKEY VerticalAspectRatio
						=> new PROPERTYKEY(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 45);
				}

				/// <summary>Volume Properties</summary>
				public static class Volume
				{
					/// <summary>
					/// <para>Name:     System.Volume.FileSystem -- PKEY_Volume_FileSystem</para>
					/// <para>Description: Indicates the filesystem of the volume.</para>
					/// <para>Type:     String -- VT_LPWSTR (For variants: VT_BSTR)</para>
					/// <para>
					/// FormatID: (FMTID_Volume) {9B174B35-40FF-11D2-A27E-00C04FC30871}, 4 (PID_VOLUME_FILESYSTEM) (Filesystem Volume Properties)
					/// </para>
					/// </summary>
					public static PROPERTYKEY FileSystem
						=> new PROPERTYKEY(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 4);

					/// <summary>
					/// <para>Name:     System.Volume.IsMappedDrive -- PKEY_Volume_IsMappedDrive</para>
					/// <para>Description:</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: {149C0B69-2C2D-48FC-808F-D318D78C4636}, 2</para>
					/// </summary>
					public static PROPERTYKEY IsMappedDrive
						=> new PROPERTYKEY(new Guid("{149C0B69-2C2D-48FC-808F-D318D78C4636}"), 2);

					/// <summary>
					/// <para>Name:     System.Volume.IsRoot -- PKEY_Volume_IsRoot</para>
					/// <para>Description:</para>
					/// <para>Type:     Boolean -- VT_BOOL</para>
					/// <para>FormatID: (FMTID_Volume) {9B174B35-40FF-11D2-A27E-00C04FC30871}, 10 (Filesystem Volume Properties)</para>
					/// </summary>
					public static PROPERTYKEY IsRoot
						=> new PROPERTYKEY(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 10);
				}
			}
		}
	}
}