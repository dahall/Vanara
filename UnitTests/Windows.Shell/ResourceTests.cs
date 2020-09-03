using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.Tests
{
	[TestFixture]
	public class ResourceTests
	{
		[Test]
		public void IndirectStringTest()
		{
			Assert.IsTrue(IndirectString.TryParse(@"@%SystemRoot%\system32\shell32.dll,-21810", out var ids));
			Assert.That(ids.ResourceId, Is.EqualTo(-21810));
			Assert.NotNull(ids.Value);
		}

		private static Dictionary<Guid, string> kflookup = new Dictionary<Guid, string>() {
			{ new Guid("{D20BEEC4-5CA8-4905-AE3B-BF251EA09B53}"), "FOLDERID_NetworkFolder" },
			{ new Guid("{0AC0837C-BBF8-452A-850D-79D08E667CA7}"), "FOLDERID_ComputerFolder" },
			{ new Guid("{4D9F7874-4E0C-4904-967B-40B0D20C3E4B}"), "FOLDERID_InternetFolder" },
			{ new Guid("{82A74AEB-AEB4-465C-A014-D097EE346D63}"), "FOLDERID_ControlPanelFolder" },
			{ new Guid("{76FC4E2D-D6AD-4519-A663-37BD56068185}"), "FOLDERID_PrintersFolder" },
			{ new Guid("{43668BF8-C14E-49B2-97C9-747784D784B7}"), "FOLDERID_SyncManagerFolder" },
			{ new Guid("{0F214138-B1D3-4a90-BBA9-27CBC0C5389A}"), "FOLDERID_SyncSetupFolder" },
			{ new Guid("{4bfefb45-347d-4006-a5be-ac0cb0567192}"), "FOLDERID_ConflictFolder" },
			{ new Guid("{289a9a43-be44-4057-a41b-587a76d7e7f9}"), "FOLDERID_SyncResultsFolder" },
			{ new Guid("{B7534046-3ECB-4C18-BE4E-64CD4CB7D6AC}"), "FOLDERID_RecycleBinFolder" },
			{ new Guid("{6F0CD92B-2E97-45D1-88FF-B0D186B8DEDD}"), "FOLDERID_ConnectionsFolder" },
			{ new Guid("{FD228CB7-AE11-4AE3-864C-16F3910AB8FE}"), "FOLDERID_Fonts" },
			{ new Guid("{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}"), "FOLDERID_Desktop" },
			{ new Guid("{B97D20BB-F46A-4C97-BA10-5E3608430854}"), "FOLDERID_Startup" },
			{ new Guid("{A77F5D77-2E2B-44C3-A6A2-ABA601054A51}"), "FOLDERID_Programs" },
			{ new Guid("{625B53C3-AB48-4EC1-BA1F-A1EF4146FC19}"), "FOLDERID_StartMenu" },
			{ new Guid("{AE50C081-EBD2-438A-8655-8A092E34987A}"), "FOLDERID_Recent" },
			{ new Guid("{8983036C-27C0-404B-8F08-102D10DCFD74}"), "FOLDERID_SendTo" },
			{ new Guid("{FDD39AD0-238F-46AF-ADB4-6C85480369C7}"), "FOLDERID_Documents" },
			{ new Guid("{1777F761-68AD-4D8A-87BD-30B759FA33DD}"), "FOLDERID_Favorites" },
			{ new Guid("{C5ABBF53-E17F-4121-8900-86626FC2C973}"), "FOLDERID_NetHood" },
			{ new Guid("{9274BD8D-CFD1-41C3-B35E-B13F55A758F4}"), "FOLDERID_PrintHood" },
			{ new Guid("{A63293E8-664E-48DB-A079-DF759E0509F7}"), "FOLDERID_Templates" },
			{ new Guid("{82A5EA35-D9CD-47C5-9629-E15D2F714E6E}"), "FOLDERID_CommonStartup" },
			{ new Guid("{0139D44E-6AFE-49F2-8690-3DAFCAE6FFB8}"), "FOLDERID_CommonPrograms" },
			{ new Guid("{A4115719-D62E-491D-AA7C-E74B8BE3B067}"), "FOLDERID_CommonStartMenu" },
			{ new Guid("{C4AA340D-F20F-4863-AFEF-F87EF2E6BA25}"), "FOLDERID_PublicDesktop" },
			{ new Guid("{62AB5D82-FDC1-4DC3-A9DD-070D1D495D97}"), "FOLDERID_ProgramData" },
			{ new Guid("{B94237E7-57AC-4347-9151-B08C6C32D1F7}"), "FOLDERID_CommonTemplates" },
			{ new Guid("{ED4824AF-DCE4-45A8-81E2-FC7965083634}"), "FOLDERID_PublicDocuments" },
			{ new Guid("{3EB685DB-65F9-4CF6-A03A-E3EF65729F3D}"), "FOLDERID_RoamingAppData" },
			{ new Guid("{F1B32785-6FBA-4FCF-9D55-7B8E7F157091}"), "FOLDERID_LocalAppData" },
			{ new Guid("{A520A1A4-1780-4FF6-BD18-167343C5AF16}"), "FOLDERID_LocalAppDataLow" },
			{ new Guid("{352481E8-33BE-4251-BA85-6007CAEDCF9D}"), "FOLDERID_InternetCache" },
			{ new Guid("{2B0F765D-C0E9-4171-908E-08A611B84FF6}"), "FOLDERID_Cookies" },
			{ new Guid("{D9DC8A3B-B784-432E-A781-5A1130A75963}"), "FOLDERID_History" },
			{ new Guid("{1AC14E77-02E7-4E5D-B744-2EB1AE5198B7}"), "FOLDERID_System" },
			{ new Guid("{D65231B0-B2F1-4857-A4CE-A8E7C6EA7D27}"), "FOLDERID_SystemX86" },
			{ new Guid("{F38BF404-1D43-42F2-9305-67DE0B28FC23}"), "FOLDERID_Windows" },
			{ new Guid("{5E6C858F-0E22-4760-9AFE-EA3317B67173}"), "FOLDERID_Profile" },
			{ new Guid("{33E28130-4E1E-4676-835A-98395C3BC3BB}"), "FOLDERID_Pictures" },
			{ new Guid("{7C5A40EF-A0FB-4BFC-874A-C0F2E0B9FA8E}"), "FOLDERID_ProgramFilesX86" },
			{ new Guid("{DE974D24-D9C6-4D3E-BF91-F4455120B917}"), "FOLDERID_ProgramFilesCommonX86" },
			{ new Guid("{6D809377-6AF0-444b-8957-A3773F02200E}"), "FOLDERID_ProgramFilesX64" },
			{ new Guid("{6365D5A7-0F0D-45e5-87F6-0DA56B6A4F7D}"), "FOLDERID_ProgramFilesCommonX64" },
			{ new Guid("{905e63b6-c1bf-494e-b29c-65b732d3d21a}"), "FOLDERID_ProgramFiles" },
			{ new Guid("{F7F1ED05-9F6D-47A2-AAAE-29D317C6F066}"), "FOLDERID_ProgramFilesCommon" },
			{ new Guid("{5cd7aee2-2219-4a67-b85d-6c9ce15660cb}"), "FOLDERID_UserProgramFiles" },
			{ new Guid("{bcbd3057-ca5c-4622-b42d-bc56db0ae516}"), "FOLDERID_UserProgramFilesCommon" },
			{ new Guid("{724EF170-A42D-4FEF-9F26-B60E846FBA4F}"), "FOLDERID_AdminTools" },
			{ new Guid("{D0384E7D-BAC3-4797-8F14-CBA229B392B5}"), "FOLDERID_CommonAdminTools" },
			{ new Guid("{4BD8D571-6D19-48D3-BE97-422220080E43}"), "FOLDERID_Music" },
			{ new Guid("{18989B1D-99B5-455B-841C-AB7C74E4DDFC}"), "FOLDERID_Videos" },
			{ new Guid("{C870044B-F49E-4126-A9C3-B52A1FF411E8}"), "FOLDERID_Ringtones" },
			{ new Guid("{B6EBFB86-6907-413C-9AF7-4FC2ABF07CC5}"), "FOLDERID_PublicPictures" },
			{ new Guid("{3214FAB5-9757-4298-BB61-92A9DEAA44FF}"), "FOLDERID_PublicMusic" },
			{ new Guid("{2400183A-6185-49FB-A2D8-4A392A602BA3}"), "FOLDERID_PublicVideos" },
			{ new Guid("{E555AB60-153B-4D17-9F04-A5FE99FC15EC}"), "FOLDERID_PublicRingtones" },
			{ new Guid("{8AD10C31-2ADB-4296-A8F7-E4701232C972}"), "FOLDERID_ResourceDir" },
			{ new Guid("{2A00375E-224C-49DE-B8D1-440DF7EF3DDC}"), "FOLDERID_LocalizedResourcesDir" },
			{ new Guid("{C1BAE2D0-10DF-4334-BEDD-7AA20B227A9D}"), "FOLDERID_CommonOEMLinks" },
			{ new Guid("{9E52AB10-F80D-49DF-ACB8-4330F5687855}"), "FOLDERID_CDBurning" },
			{ new Guid("{0762D272-C50A-4BB0-A382-697DCD729B80}"), "FOLDERID_UserProfiles" },
			{ new Guid("{DE92C1C7-837F-4F69-A3BB-86E631204A23}"), "FOLDERID_Playlists" },
			{ new Guid("{15CA69B3-30EE-49C1-ACE1-6B5EC372AFB5}"), "FOLDERID_SamplePlaylists" },
			{ new Guid("{B250C668-F57D-4EE1-A63C-290EE7D1AA1F}"), "FOLDERID_SampleMusic" },
			{ new Guid("{C4900540-2379-4C75-844B-64E6FAF8716B}"), "FOLDERID_SamplePictures" },
			{ new Guid("{859EAD94-2E85-48AD-A71A-0969CB56A6CD}"), "FOLDERID_SampleVideos" },
			{ new Guid("{69D2CF90-FC33-4FB7-9A0C-EBB0F0FCB43C}"), "FOLDERID_PhotoAlbums" },
			{ new Guid("{DFDF76A2-C82A-4D63-906A-5644AC457385}"), "FOLDERID_Public" },
			{ new Guid("{df7266ac-9274-4867-8d55-3bd661de872d}"), "FOLDERID_ChangeRemovePrograms" },
			{ new Guid("{a305ce99-f527-492b-8b1a-7e76fa98d6e4}"), "FOLDERID_AppUpdates" },
			{ new Guid("{de61d971-5ebc-4f02-a3a9-6c82895e5c04}"), "FOLDERID_AddNewPrograms" },
			{ new Guid("{374DE290-123F-4565-9164-39C4925E467B}"), "FOLDERID_Downloads" },
			{ new Guid("{3D644C9B-1FB8-4f30-9B45-F670235F79C0}"), "FOLDERID_PublicDownloads" },
			{ new Guid("{7d1d3a04-debb-4115-95cf-2f29da2920da}"), "FOLDERID_SavedSearches" },
			{ new Guid("{52a4f021-7b75-48a9-9f6b-4b87a210bc8f}"), "FOLDERID_QuickLaunch" },
			{ new Guid("{56784854-C6CB-462b-8169-88E350ACB882}"), "FOLDERID_Contacts" },
			{ new Guid("{A75D362E-50FC-4fb7-AC2C-A8BEAA314493}"), "FOLDERID_SidebarParts" },
			{ new Guid("{7B396E54-9EC5-4300-BE0A-2482EBAE1A26}"), "FOLDERID_SidebarDefaultParts" },
			{ new Guid("{DEBF2536-E1A8-4c59-B6A2-414586476AEA}"), "FOLDERID_PublicGameTasks" },
			{ new Guid("{054FAE61-4DD8-4787-80B6-090220C4B700}"), "FOLDERID_GameTasks" },
			{ new Guid("{4C5C32FF-BB9D-43b0-B5B4-2D72E54EAAA4}"), "FOLDERID_SavedGames" },
			{ new Guid("{CAC52C1A-B53D-4edc-92D7-6B2E8AC19434}"), "FOLDERID_Games" },
			{ new Guid("{98ec0e18-2098-4d44-8644-66979315a281}"), "FOLDERID_SEARCH_MAPI" },
			{ new Guid("{ee32e446-31ca-4aba-814f-a5ebd2fd6d5e}"), "FOLDERID_SEARCH_CSC" },
			{ new Guid("{bfb9d5e0-c6a9-404c-b2b2-ae6db6af4968}"), "FOLDERID_Links" },
			{ new Guid("{f3ce0f7c-4901-4acc-8648-d5d44b04ef8f}"), "FOLDERID_UsersFiles" },
			{ new Guid("{A302545D-DEFF-464b-ABE8-61C8648D939B}"), "FOLDERID_UsersLibraries" },
			{ new Guid("{190337d1-b8ca-4121-a639-6d472d16972a}"), "FOLDERID_SearchHome" },
			{ new Guid("{2C36C0AA-5812-4b87-BFD0-4CD0DFB19B39}"), "FOLDERID_OriginalImages" },
			{ new Guid("{7b0db17d-9cd2-4a93-9733-46cc89022e7c}"), "FOLDERID_DocumentsLibrary" },
			{ new Guid("{2112AB0A-C86A-4ffe-A368-0DE96E47012E}"), "FOLDERID_MusicLibrary" },
			{ new Guid("{A990AE9F-A03B-4e80-94BC-9912D7504104}"), "FOLDERID_PicturesLibrary" },
			{ new Guid("{491E922F-5643-4af4-A7EB-4E7A138D8174}"), "FOLDERID_VideosLibrary" },
			{ new Guid("{1A6FDBA2-F42D-4358-A798-B74D745926C5}"), "FOLDERID_RecordedTVLibrary" },
			{ new Guid("{52528A6B-B9E3-4add-B60D-588C2DBA842D}"), "FOLDERID_HomeGroup" },
			{ new Guid("{9B74B6A3-0DFD-4f11-9E78-5F7800F2E772}"), "FOLDERID_HomeGroupCurrentUser" },
			{ new Guid("{5CE4A5E9-E4EB-479D-B89F-130C02886155}"), "FOLDERID_DeviceMetadataStore" },
			{ new Guid("{1B3EA5DC-B587-4786-B4EF-BD1DC332AEAE}"), "FOLDERID_Libraries" },
			{ new Guid("{48daf80b-e6cf-4f4e-b800-0e69d84ee384}"), "FOLDERID_PublicLibraries" },
			{ new Guid("{9e3995ab-1f9c-4f13-b827-48b24b6c7174}"), "FOLDERID_UserPinned" },
			{ new Guid("{bcb5256f-79f6-4cee-b725-dc34e402fd46}"), "FOLDERID_ImplicitAppShortcuts" },
			{ new Guid("{008ca0b1-55b4-4c56-b8a8-4de4b299d3be}"), "FOLDERID_AccountPictures" },
			{ new Guid("{0482af6c-08f1-4c34-8c90-e17ec98b1e17}"), "FOLDERID_PublicUserTiles" },
			{ new Guid("{1e87508d-89c2-42f0-8a7e-645a0f50ca58}"), "FOLDERID_AppsFolder" },
			{ new Guid("{F26305EF-6948-40B9-B255-81453D09C785}"), "FOLDERID_StartMenuAllPrograms" },
			{ new Guid("{A440879F-87A0-4F7D-B700-0207B966194A}"), "FOLDERID_CommonStartMenuPlaces" },
			{ new Guid("{A3918781-E5F2-4890-B3D9-A7E54332328C}"), "FOLDERID_ApplicationShortcuts" },
			{ new Guid("{00BCFC5A-ED94-4e48-96A1-3F6217F21990}"), "FOLDERID_RoamingTiles" },
			{ new Guid("{AAA8D5A5-F1D6-4259-BAA8-78E7EF60835E}"), "FOLDERID_RoamedTileImages" },
			{ new Guid("{b7bede81-df94-4682-a7d8-57a52620b86f}"), "FOLDERID_Screenshots" },
			{ new Guid("{AB5FB87B-7CE2-4F83-915D-550846C9537B}"), "FOLDERID_CameraRoll" },
			{ new Guid("{A52BBA46-E9E1-435f-B3D9-28DAA648C0F6}"), "FOLDERID_OneDrive" },
			{ new Guid("{24D89E24-2F19-4534-9DDE-6A6671FBB8FE}"), "FOLDERID_SkyDriveDocuments" },
			{ new Guid("{339719B5-8C47-4894-94C2-D8F77ADD44A6}"), "FOLDERID_SkyDrivePictures" },
			{ new Guid("{C3F2459E-80D6-45DC-BFEF-1F769F2BE730}"), "FOLDERID_SkyDriveMusic" },
			{ new Guid("{767E6811-49CB-4273-87C2-20F355E1085B}"), "FOLDERID_SkyDriveCameraRoll" },
			{ new Guid("{0D4C3DB6-03A3-462F-A0E6-08924C41B5D4}"), "FOLDERID_SearchHistory" },
			{ new Guid("{7E636BFE-DFA9-4D5E-B456-D7B39851D8A9}"), "FOLDERID_SearchTemplates" },
			{ new Guid("{2B20DF75-1EDA-4039-8097-38798227D5B7}"), "FOLDERID_CameraRollLibrary" },
			{ new Guid("{3B193882-D3AD-4eab-965A-69829D1FB59F}"), "FOLDERID_SavedPictures" },
			{ new Guid("{E25B5812-BE88-4bd9-94B0-29233477B6C3}"), "FOLDERID_SavedPicturesLibrary" },
			{ new Guid("{12D4C69E-24AD-4923-BE19-31321C43A767}"), "FOLDERID_RetailDemo" },
			{ new Guid("{1C2AC1DC-4358-4B6C-9733-AF21156576F0}"), "FOLDERID_Device" },
			{ new Guid("{DBE8E08E-3053-4BBC-B183-2A7B2B191E59}"), "FOLDERID_DevelopmentFiles" },
			{ new Guid("{31C0DD25-9439-4F12-BF41-7FF4EDA38722}"), "FOLDERID_Objects3D" },
			{ new Guid("{EDC0FE71-98D8-4F4A-B920-C8DC133CB165}"), "FOLDERID_AppCaptures" },
			{ new Guid("{f42ee2d3-909f-4907-8871-4c22fc0bf756}"), "FOLDERID_LocalDocuments" },
			{ new Guid("{0ddd015d-b06c-45d5-8c4c-f59713854639}"), "FOLDERID_LocalPictures" },
			{ new Guid("{35286a68-3c57-41a1-bbb1-0eae73d76c95}"), "FOLDERID_LocalVideos" },
			{ new Guid("{a0c69a99-21c8-4671-8703-7934162fcf1d}"), "FOLDERID_LocalMusic" },
			{ new Guid("{7d83ee9b-2244-4e70-b1f5-5393042af1e4}"), "FOLDERID_LocalDownloads" },
			{ new Guid("{2f8b40c2-83ed-48ee-b383-a1f157ec6f9a}"), "FOLDERID_RecordedCalls" },
			{ new Guid("{7ad67899-66af-43ba-9156-6aad42e6c596}"), "FOLDERID_AllAppMods" },
			{ new Guid("{3db40b20-2a30-4dbe-917e-771dd21dd099}"), "FOLDERID_CurrentAppMods" },
			{ new Guid("{B2C5E279-7ADD-439F-B28C-C41FE1BBF672}"), "FOLDERID_AppDataDesktop" },
			{ new Guid("{7BE16610-1F7F-44AC-BFF0-83E15F2FFCA1}"), "FOLDERID_AppDataDocuments" },
			{ new Guid("{7CFBEFBC-DE1F-45AA-B843-A542AC536CC9}"), "FOLDERID_AppDataFavorites" },
			{ new Guid("{559D40A3-A036-40FA-AF61-84CB430A4D34}"), "FOLDERID_AppDataProgramData" },
		};

		private static List<(string, string)> envrepl = new List<(string, string)>
		{
			(@"C:\Users\dahall\AppData\Roaming", "APPDATA"),
			(@"C:\Users\dahall\AppData\Local\Temp", "TEMP"),
			(@"C:\Users\dahall\AppData\Local", "LOCALAPPDATA"),
			(@"C:\Users\dahall", "USERPROFILE"),
			(@"C:\Users\Public", "PUBLIC"),
			(@"C:\ProgramData", "ALLUSERSPROFILE"),
			(@"C:\Program Files\Common Files", "CommonProgramFiles"),
			(@"C:\Program Files", "ProgramFiles"),
			(@"C:\Program Files (x86)\Common Files", "CommonProgramFiles(x86)"),
			(@"C:\Program Files (x86)", "ProgramFiles(x86)"),
			(@"C:\Windows\System32\Drivers\DriverData", "DriverData"),
			(@"C:\WINDOWS", "SystemRoot"),
			(@"C:", "HOMEDRIVE"),
		};

		private void BuildFOLDERIDList()
		{
			using var m = ComReleaserFactory.Create(new IKnownFolderManager());
			var list = new SortedList<string, string>();
			foreach (var id in m.Item.GetFolderIds())
			{
				CSIDL? csidl = null;
				try { csidl = m.Item.FolderIdToCsidl(id); } catch { }
				using var fld = ComReleaserFactory.Create(m.Item.GetFolder(id));
				var kd = fld.Item.GetFolderDefinition();
				try
				{
					var name = kd.pszName.ToString();
					if (!kflookup.TryGetValue(id, out var fid))
						fid = "FOLDERID_" + name.Replace(" ", "") + " /* NEW */";
					var ln = GetIS(kd.pszLocalizedName) ?? name;
					var sb = new StringBuilder();
					sb.AppendLine($"/// <summary>{ln}");
					WriteGood(sb, "Category:      ", kd.category.ToString());
					WriteGood(sb, "Description:   ", (string)kd.pszDescription);
					WriteGood(sb, "Path:          ", FixPath(GetPath(fld.Item) ?? (string)kd.pszRelativePath));
					WriteGood(sb, "Parsing Name:  ", (string)kd.pszParsingName);
					WriteGood(sb, "Tooltip:       ", GetIS(kd.pszTooltip));
					WriteGood(sb, "Localized Name:", GetIS(kd.pszLocalizedName));
					WriteGood(sb, "Icon:          ", GetIS(kd.pszIcon));
					WriteGood(sb, "SDDL:          ", (string)kd.pszSecurity);
					WriteGood(sb, "Attributes:    ", kd.dwAttributes.ToString());
					WriteGood(sb, "Flags:         ", kd.kfdFlags.ToString());
					sb.AppendLine("/// </summary>");
					sb.Append($"[KnownFolderDetail(\"{id}\"");
					if (csidl.HasValue)
					{
						if (Enum.IsDefined(typeof(Environment.SpecialFolder), (int)csidl.Value))
							sb.Append($", Equivalent = Environment.SpecialFolder.{(Environment.SpecialFolder)(int)csidl.Value} /* CSIDL.{csidl.Value} */");
						else
							sb.Append($", Equivalent = (Environment.SpecialFolder)CSIDL.{csidl.Value}");
					}
					sb.AppendLine(")]");
					sb.AppendLine(fid + ",");
					list.Add(fid, sb.ToString());
				}
				finally
				{
					kd.FreeKnownFolderDefinitionFields();
				}
			}
			var output = string.Join("\r\n", list.Values);
			TestContext.Write(output);

			static string FixPath(string path)
			{
				if (path is null) return null;
				foreach (var (p, r) in envrepl)
					path = path.Replace(p, string.Concat("%", r, "%"));
				return path;
			}

			static string GetPath(IKnownFolder fld)
			{
				try { return fld.GetPath(KNOWN_FOLDER_FLAG.KF_FLAG_DONT_VERIFY).ToString(); } catch { return null; }
			}

			static string GetIS(StrPtrUni p)
			{
				try { if (!p.IsNull && IndirectString.TryParse(p.ToString(), out var ids) && ids.IsValid) return ids.Value; } catch { }
				return null;
			}

			static void WriteGood(StringBuilder sb, string hdr, string value)
			{
				if (!string.IsNullOrEmpty(value) && value != "0")
					sb.AppendLine($"/// <para>{hdr} {value}</para>");
			}
		}
	}
}