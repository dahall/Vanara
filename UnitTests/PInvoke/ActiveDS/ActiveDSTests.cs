using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Vanara.DirectoryServices;
using static Vanara.PInvoke.ActiveDS;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class ActiveDSTests
{
	private readonly string adsFs = $"WinNT://{Environment.MachineName}/LanmanServer";
	private readonly string adsGroup = $"WinNT://WORKGROUP/{Environment.MachineName}/Administrators";
	private readonly string adsMachine = "WinNT://" + Environment.MachineName;
	private readonly string adsPrintQ = $"WinNT://WORKGROUP/{Environment.MachineName}/HP Color LaserJet Pro M478f-9f PCL-6 (V4)";
	private readonly string adsShare = $"WinNT://{Environment.MachineName}/LanmanServer/Users";
	private readonly string adsUser = $"WinNT://WORKGROUP/{Environment.MachineName}/Administrator";

	[Test]
	public void ADsLastErrorTest()
	{
		ADsSetLastError(Win32Error.ERROR_WRONG_PASSWORD, "Wrong", "WinNT");
		StringBuilder sb = new(256), sbP = new(256);
		Assert.That(ADsGetLastError(out var err, sb, sb.Capacity, sbP, sbP.Capacity), ResultIs.Successful);
		Assert.That((uint)err, Is.EqualTo(Win32Error.ERROR_WRONG_PASSWORD));
		Assert.That(sb.ToString(), Is.EqualTo("Wrong"));
		Assert.That(sbP.ToString(), Is.EqualTo("WinNT"));
	}

	[Test]
	public void AllocADsMemTest()
	{
		var p = AllocADsMem(512);
		Assert.That(p, Is.Not.EqualTo(IntPtr.Zero));
		p = ReallocADsMem(p, 512, 256);
		Assert.That(p, Is.Not.EqualTo(IntPtr.Zero));
		Assert.That(FreeADsMem(p));
	}

	[Test]
	public void AllocADsStrTest()
	{
		StrPtrUni p = AllocADsStr("test");
		Assert.That((IntPtr)p, Is.Not.EqualTo(IntPtr.Zero));
		Assert.That(p.ToString(), Is.EqualTo("test"));
		Assert.That(ReallocADsStr(ref p, "newval"));
		Assert.That((IntPtr)p, Is.Not.EqualTo(IntPtr.Zero));
		Assert.That(p.ToString(), Is.EqualTo("newval"));
		Assert.That(FreeADsStr(p));
	}

	[Test]
	public void IADsClassTest()
	{
		Assert.That(ADsGetObject(adsMachine, out IADs? pObj), ResultIs.Successful);
		Assert.That(ADsGetObject(pObj!.Schema, out IADsClass? pClass), ResultIs.Successful);
		TestContext.WriteLine($"{pClass?.Name}, {pClass?.Class}, {pClass?.ADsPath}");
		Write("PrimaryInterface", () => pClass!.PrimaryInterface);
		Write("CLSID", () => pClass!.CLSID);
		Write("OID", () => pClass!.OID);
		Write("Abstract", () => pClass!.Abstract);
		Write("Auxiliary", () => pClass!.Auxiliary);
		Write("MandatoryProperties", () => pClass!.MandatoryProperties);
		Write("OptionalProperties", () => pClass!.OptionalProperties);
		Write("NamingProperties", () => pClass!.NamingProperties);
		Write("DerivedFrom", () => pClass!.DerivedFrom);
		Write("AuxDerivedFrom", () => pClass!.AuxDerivedFrom);
		Write("PossibleSuperiors", () => pClass!.PossibleSuperiors);
		Write("Containment", () => pClass!.Containment);
		Write("Container", () => pClass!.Container);
		Write("HelpFileName", () => pClass!.HelpFileName);
		Write("HelpFileContext", () => pClass!.HelpFileContext);
	}

	[Test]
	public void IADsComputerTest()
	{
		Assert.That(ADsGetObject(adsMachine, out IADsComputer? pComp), ResultIs.Successful);
		TestContext.WriteLine($"{pComp?.Name}, {pComp?.Class}, {pComp?.ADsPath}, {pComp?.Schema}");
		Write("ComputerID", () => pComp!.ComputerID);
		Write("Site", () => pComp!.Site);
		Write("Description", () => pComp!.Description);
		Write("Location", () => pComp!.Location);
		Write("PrimaryUser", () => pComp!.PrimaryUser);
		Write("Owner", () => pComp!.Owner);
		Write("Division", () => pComp!.Division);
		Write("Department", () => pComp!.Department);
		Write("Role", () => pComp!.Role);
		Write("OperatingSystem", () => pComp!.OperatingSystem);
		Write("OperatingSystemVersion", () => pComp!.OperatingSystemVersion);
		Write("Model", () => pComp!.Model);
		Write("Processor", () => pComp!.Processor);
		Write("ProcessorCount", () => pComp!.ProcessorCount);
		Write("MemorySize", () => pComp!.MemorySize);
		Write("StorageCapacity", () => pComp!.StorageCapacity);
		Write("NetAddresses", () => pComp!.NetAddresses);

		IADsComputerOperations ops = (IADsComputerOperations)pComp!;
		Write("Status", () => ops.Status());
	}

	[Test]
	public void IADsComputerTest2()
	{
		ADsComputer o = (ADsComputer)ADsObject.GetObject(adsMachine);
		TestContext.WriteLine($"{o?.Name}, {o?.Class}, {o?.Path}");

		TestContext.WriteLine("Properties:");
		foreach (var key in o!.PropertyCache.Keys)
			Write("  " + key, () => o!.PropertyCache[key]);
		Write("  Status", () => o!.Operations.Status);

		TestContext.WriteLine("Children:");
		foreach (var child in o!.Children.Where(c => c.Class == "User").Take(3))
		{
			TestContext.WriteLine($"  {child.Name} ({child.Class})");
			foreach (var kv in child!.PropertyCache)
				Write("    " + kv.Key, () => kv.Value);
		}

		TestContext.WriteLine("Schema:");
		Write("  Name", () => o!.Schema.Name);
		Write("  PrimaryInterface", () => o!.Schema.PrimaryInterface);
		Write("  CLSID", () => o!.Schema.CLSID);
		Write("  OID", () => o!.Schema.OID);
		Write("  Abstract", () => o!.Schema.Abstract);
		Write("  Auxiliary", () => o!.Schema.Auxiliary);
		Write("  MandatoryProperties", () => o!.Schema.MandatoryProperties);
		Write("  OptionalProperties", () => o!.Schema.OptionalProperties);
		Write("  NamingProperties", () => o!.Schema.NamingProperties);
		Write("  DerivedFrom", () => o!.Schema.DerivedFrom);
		Write("  AuxDerivedFrom", () => o!.Schema.AuxDerivedFrom);
		Write("  PossibleSuperiors", () => o!.Schema.PossibleSuperiors);
		Write("  Containment", () => o!.Schema.Containment);
		Write("  Container", () => o!.Schema.Container);
		Write("  HelpFileName", () => o!.Schema.HelpFileName);
		Write("  HelpFileContext", () => o!.Schema.HelpFileContext);
		Write("  Qualifiers", () => o!.Schema.Qualifiers);
		TestContext.WriteLine("  Properties:");
		foreach (var child in o!.Schema.Children)
		{
			var pName = child.Name;
			Write("    ============", () => pName);
			Write("    OID", () => child.OID);
			Write("    MaxRange", () => child.MaxRange);
			Write("    MinRange", () => child.MinRange);
			Write("    MultiValued", () => child.MultiValued);
			Write("    OleAutoDataType", () => child.Syntax.OleAutoDataType);
		}

		var uo = o!.Children.Add("User", "fred");
		TestContext.WriteLine($"Added: {uo.Path} ({uo.Class})");
		//Assert.That(() => o!.Children["User", "CN=fred"], Throws.Nothing);
		//Assert.That(() => o!.Children["CN=fred"], Throws.Nothing);
		//Assert.That(o!.Children.Remove(uo));

		var parent = o.Parent;
		while (parent is not null)
		{
			TestContext.WriteLine(parent.Path);
			parent = parent.Parent;
		}
	}

	[Test]
	public void IADsContainerTest()
	{
		string?[] lppClsNames = ["User", "Group"];

		Assert.That(ADsGetObject<IADsContainer>(adsMachine, out var pADsContainer), ResultIs.Successful);
		pADsContainer!.Filter = lppClsNames; // varFilter;

		Assert.That(ADsBuildEnumerator(pADsContainer, out IEnumVARIANT? pEnumVar), ResultIs.Successful);
		try
		{
			object?[] varArray = new object?[50];
			Assert.That(ADsEnumerateNext(pEnumVar, (uint)varArray.Length, varArray, out var ulFetched), ResultIs.Successful);
			for (var i = 0; i < ulFetched; i++)
			{
				IADs? pObject = (IADs?)varArray[i];
				TestContext.WriteLine($"{pObject?.Name}, {pObject?.Class}, {pObject?.ADsPath}, {pObject?.Parent}, {pObject?.Schema}");
			}
		}
		finally
		{
			ADsFreeEnumerator(pEnumVar);
		}
	}

	[Test]
	public void IADsContainerTest2()
	{
		Assert.That(ADsGetObject<IADsContainer>(adsMachine, out var pADsContainer), ResultIs.Successful);
		//pADsContainer!.Filter = new string?[] { "User" };
		//Assert.That(pADsContainer!.Cast<IADs>().All(i => i.Class == "User"));
		foreach (var iads in pADsContainer!.Cast<IADs>())
			TestContext.WriteLine($"{iads.Class}\t{iads.ADsPath}");
	}

	[Test]
	public void IADsFileShareTest()
	{
		Assert.That(ADsOpenObject(adsFs, out IADsFileService? fs), ResultIs.Successful);
		Write("Description", () => fs!.Description);
		Write("MaxUserCount", () => fs!.MaxUserCount);

		IADsFileServiceOperations ops = (IADsFileServiceOperations)fs!;
		TestContext.WriteLine("Sessions: " + string.Join(", ", ops.Sessions().Cast<IADsSession>().Select(s => s.Name)));
		TestContext.WriteLine("Resources:");
		foreach (var r in ops.Resources().Cast<IADsResource>())
			TestContext.WriteLine($"{r.UserPath} = {r.Path} ({r.LockCount})");

		Assert.That(ADsOpenObject(adsShare, ppObject: out IADsFileShare? o), ResultIs.Successful);
		o!.GetInfo();
		Write("CurrentUserCount", () => o!.CurrentUserCount);
		Write("Description", () => o!.Description);
		Write("HostComputer", () => o!.HostComputer);
		Write("Path", () => o!.Path);
		Write("MaxUserCount", () => o!.MaxUserCount);
	}

	[Test]
	public void IADsGroupTest()
	{
		Assert.That(ADsGetObject(adsGroup, out IADsGroup? pGroup), ResultIs.Successful);
		TestContext.WriteLine($"{pGroup?.Name}, {pGroup?.Class}, {pGroup?.ADsPath}");
		Assert.That(() => pGroup!.GetInfo(), Throws.Nothing);
		Write("Description", () => pGroup!.Description);
		IADsMembers mbrs = pGroup!.Members();
		foreach (var mbr in mbrs.Cast<IADs>())
			TestContext.WriteLine($"{mbr.ADsPath}");
	}

	[Test]
	public void IADsNamespacesTest()
	{
		Assert.That(ADsGetObject("ADs:", out IADsNamespaces? o), ResultIs.Successful);
		Write("DefaultContainer", () => o!.DefaultContainer);
	}

	[Test]
	public void IADsPathnameTest()
	{
		IADsPathname o = new();
		Assert.That(() => o.Set(adsUser, ADS_SETTYPE.ADS_SETTYPE_FULL), Throws.Nothing);
		int cnt = 0;
		Write("GetNumElements", () => cnt = o!.GetNumElements());
		for (int i = 0; i < cnt; i++)
			Write($"GetElement({i})", () => o!.GetElement(i));
		Write("EscapedMode", () => o!.EscapedMode);
		for (int i = 1; i <= 11; i++)
			Write(Enum.GetName((ADS_FORMAT)i) ?? "", () => o!.Retrieve((ADS_FORMAT)i));
	}

	[Test]
	public void IADsPrintQueueTest()
	{
		Assert.That(ADsGetObject(adsPrintQ, out IADsPrintQueue? o), ResultIs.Successful);
		TestContext.WriteLine($"{o?.Name}, {o?.Class}, {o?.ADsPath}");
		Write("PrinterPath", () => o!.PrinterPath);
		Write("Model", () => o!.Model);
		Write("Datatype", () => o!.Datatype);
		Write("PrintProcessor", () => o!.PrintProcessor);
		Write("Description", () => o!.Description);
		Write("Location", () => o!.Location);
		Write("StartTime", () => o!.StartTime);
		Write("UntilTime", () => o!.UntilTime);
		Write("DefaultJobPriority", () => o!.DefaultJobPriority);
		Write("Priority", () => o!.Priority);
		Write("BannerPage", () => o!.BannerPage);
		Write("PrintDevices", () => o!.PrintDevices);
		Write("NetAddresses", () => o!.NetAddresses);

		var ops = (IADsPrintQueueOperations)o!;
		Write("Status", () => ops!.Status);

		TestContext.WriteLine("Jobs:");
		foreach (var j in ops.PrintJobs().ToDictionary<IADsPrintJob>().Values)
		{
			Write("HostPrintQueue", () => j!.HostPrintQueue);
			Write("User", () => j!.User);
			Write("UserPath", () => j!.UserPath);
			Write("TimeSubmitted", () => j!.TimeSubmitted);
			Write("TotalPages", () => j!.TotalPages);
			Write("Size", () => j!.Size);
			Write("Description", () => j!.Description);
			Write("Priority", () => j!.Priority);
			Write("StartTime", () => j!.StartTime);
			Write("UntilTime", () => j!.UntilTime);
			Write("Notify", () => j!.Notify);
			Write("NotifyPath", () => j!.NotifyPath);
		}
	}

	[Test]
	public void IADsPropertyTest()
	{
		Assert.That(ADsGetObject(adsMachine, out IADs? pObj), ResultIs.Successful);
		Assert.That(ADsGetObject(pObj!.Schema, out IADsClass? pClass), ResultIs.Successful);
		Assert.That(ADsGetObject(pClass!.Parent, out IADsContainer? pCont), ResultIs.Successful);
		IADsProperty? pProp = null;
		Assert.That(() => pProp = (IADsProperty?)pCont!.GetObject("Property", "OperatingSystemVersion"), Throws.Nothing);
		Write("OID", () => pProp!.OID);
		Write("Syntax", () => pProp!.Syntax);
		Write("MaxRange", () => pProp!.MaxRange);
		Write("MinRange", () => pProp!.MinRange);
		Write("MultiValued", () => pProp!.MultiValued);

		string spath = ((IADs)pCont!).ADsPath + '/' + pProp!.Syntax;
		Assert.That(ADsGetObject(spath, out IADsSyntax? pSyn), ResultIs.Successful);
		Write($"OleAutoDataType ({spath})", () => (Ole32.VARTYPE)pSyn!.OleAutoDataType);

		pObj.GetInfo();
		var pPropList = (IADsPropertyList?)pObj;
		TestContext.WriteLine($"Properties for {pObj.Name} ({pPropList!.PropertyCount}):");
		for (int i = 0; i < pPropList!.PropertyCount; i++)
		{
			var pe = (IADsPropertyEntry)pPropList.Item(i);
			TestContext.Write($"{pe.Name} ({pe.ADsType}) = ");
			var vals = Array.ConvertAll((object[])pe.Values, o => (IADsPropertyValue)o);
			foreach (var val in vals)
			{
				var s = val.ADsType switch
				{
					ADSTYPE.ADSTYPE_INVALID => "Invalid",
					ADSTYPE.ADSTYPE_DN_STRING => val.DNString,
					ADSTYPE.ADSTYPE_CASE_EXACT_STRING => val.CaseExactString,
					ADSTYPE.ADSTYPE_CASE_IGNORE_STRING => val.CaseIgnoreString,
					ADSTYPE.ADSTYPE_PRINTABLE_STRING => val.PrintableString,
					ADSTYPE.ADSTYPE_NUMERIC_STRING => val.NumericString,
					ADSTYPE.ADSTYPE_BOOLEAN => val.Boolean.ToString(),
					ADSTYPE.ADSTYPE_INTEGER => val.Integer.ToString(),
					ADSTYPE.ADSTYPE_OCTET_STRING => string.Join(' ', (byte[])val.OctetString),
					ADSTYPE.ADSTYPE_UTC_TIME => val.UTCTime.ToString(),
					ADSTYPE.ADSTYPE_LARGE_INTEGER => ((IADsLargeInteger)val.LargeInteger).ToInt64().ToString(),
					_ => "Some fetched value",
				};
				TestContext.WriteLine(s);
			}
		}
	}

	[Test]
	public void IADsSchemaTest()
	{
		ADsComputer o = (ADsComputer)ADsObject.GetObject(adsMachine);
		WriteClass(o.Parent!.Schema);

		static void WriteClass(ADsSchemaClass c, int indent = 0)
		{
			string spc = new(' ', indent);
			TestContext.WriteLine($"{spc}Class: {c.Name} =====================");
			TestContext.WriteLine($"{spc}>Properties:");
			foreach (var prop in c.Children)
				TestContext.WriteLine($"{spc} {prop.Name} ({prop.Syntax.Name}={prop.Syntax.OleAutoDataType})");
			if (c.Container)
			{
				TestContext.WriteLine($"{spc}>Subclasses:");
				foreach (ADsSchemaClass sub in c.Containment)
					WriteClass(sub, indent + 1);
			}
		}
	}

	[Test]
	public void IADsUserTest()
	{
		Assert.That(ADsOpenObject(adsUser, out IADsUser? pUser), ResultIs.Successful);
		//Assert.That(ADsOpenObject("LDAP://ldap.forumsys.com:389/CN=guass,CN=users,DC=example,DC=com", out IADsUser? pUser,
		//	ADS_AUTHENTICATION.ADS_READONLY_SERVER | ADS_AUTHENTICATION.ADS_SERVER_BIND, "read-only-admin", "password"), ResultIs.Successful);
		TestContext.WriteLine($"{pUser?.Name}, {pUser?.Class}, {pUser?.ADsPath}");
		Assert.That(() => pUser!.GetInfo(), Throws.Nothing);
		Write("Description", () => pUser!.Description);
		Write("FullName", () => pUser!.FullName);
		Write("HomeDirectory", () => pUser!.HomeDirectory);
		Write("Profile", () => pUser!.Profile);
		Write("LoginScript", () => pUser!.LoginScript);
		Write("LastLogin", () => pUser!.LastLogin);
		Write("AccountDisabled", () => pUser!.AccountDisabled);
		Write("IsAccountLocked", () => pUser!.IsAccountLocked);
		Write("MaxStorage", () => pUser!.MaxStorage);
		Write("PasswordExpirationDate", () => pUser!.PasswordExpirationDate);
		Write("PasswordMinimumLength", () => pUser!.PasswordMinimumLength);
		Write("PasswordRequired", () => pUser!.PasswordRequired);
		Write("LoginHours", () => pUser!.LoginHours);

		Write("MaxLogins", () => pUser!.MaxLogins);

		Write("BadLoginAddress", () => pUser!.BadLoginAddress);
		Write("Division", () => pUser!.Division);
		Write("Department", () => pUser!.Department);
		Write("EmployeeID", () => pUser!.EmployeeID);
		Write("FirstName", () => pUser!.FirstName);
		Write("LastName", () => pUser!.LastName);
		Write("OtherName", () => pUser!.OtherName);
		Write("NamePrefix", () => pUser!.NamePrefix);
		Write("NameSuffix", () => pUser!.NameSuffix);
		Write("Title", () => pUser!.Title);
		Write("Manager", () => pUser!.Manager);
		Write("EmailAddress", () => pUser!.EmailAddress);
		Write("BadLoginCount", () => pUser!.BadLoginCount);
		Write("LastLogoff", () => pUser!.LastLogoff);
		Write("LastFailedLogin", () => pUser!.LastFailedLogin);
		Write("PasswordLastChanged", () => pUser!.PasswordLastChanged);
		Write("TelephoneHome", () => pUser!.TelephoneHome);
		Write("TelephoneMobile", () => pUser!.TelephoneMobile);
		Write("TelephoneNumber", () => pUser!.TelephoneNumber);
		Write("TelephonePager", () => pUser!.TelephonePager);
		Write("FaxNumber", () => pUser!.FaxNumber);
		Write("OfficeLocations", () => pUser!.OfficeLocations);
		Write("PostalAddresses", () => pUser!.PostalAddresses);
		Write("PostalCodes", () => pUser!.PostalCodes);
		Write("SeeAlso", () => pUser!.SeeAlso);
		Write("AccountExpirationDate", () => pUser!.AccountExpirationDate);
		Write("GraceLoginsAllowed", () => pUser!.GraceLoginsAllowed);
		Write("GraceLoginsRemaining", () => pUser!.GraceLoginsRemaining);
		Write("LoginWorkstations", () => pUser!.LoginWorkstations);
		Write("RequireUniquePassword", () => pUser!.RequireUniquePassword);
		Write("Languages", () => pUser!.Languages);
		Write("Picture", () => pUser!.Picture);
	}

	[Test]
	public void IADsWinNTSystemInfoTest()
	{
		IADsWinNTSystemInfo si = new();
		TestContext.WriteLine(si.UserName);
		TestContext.WriteLine(si.ComputerName);
		TestContext.WriteLine(si.DomainName);
		TestContext.WriteLine(si.PDC ?? "null");
	}

	[Test]
	public void SecurityInterfacesTest()
	{
		IADsSecurityUtility util = new();
		var psd = (IADsSecurityDescriptor)util.GetSecurityDescriptor(TestCaseSources.WordDoc, ADS_PATHTYPE.ADS_PATH_FILE, ADS_SD_FORMAT.ADS_SD_FORMAT_IID);
		TestContext.WriteLine($"{psd!.Owner}, {psd!.Group}");

		var pDacl = (IADsAccessControlList)psd.DiscretionaryAcl;
		TestContext.WriteLine($"Ace count: {pDacl.AceCount}, Defaulted: {psd.DaclDefaulted}");

		foreach (var ace in pDacl.Cast<IADsAccessControlEntry>())
			TestContext.WriteLine($"{ace.Trustee}, 0x{ace.AccessMask:X}, {ace.AceFlags}, {ace.AceType}");
	}

	[Test]
	public void SecurityMethodsTest()
	{
		Assert.That(AdvApi32.GetNamedSecurityInfo(TestCaseSources.WordDoc, AdvApi32.SE_OBJECT_TYPE.SE_FILE_OBJECT,
			SECURITY_INFORMATION.DACL_SECURITY_INFORMATION | SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION | SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION,
			out _, out _, out _, out _, out var pSD), ResultIs.Successful);

		Assert.That(BinarySDToSecurityDescriptor(pSD, out var varSec), ResultIs.Successful);
		var psd = (IADsSecurityDescriptor)varSec;
		TestContext.WriteLine($"{psd!.Owner}, {psd!.Group}");

		Assert.That(SecurityDescriptorToBinarySD(psd, out var pSDbin, out _), ResultIs.Successful);
		try { Assert.That(pSD.Equals(pSDbin)); }
		finally { FreeADsMem((IntPtr)pSDbin); }
	}

	internal static void Write(string pName, Func<object?> f)
	{
		TestContext.Write(pName + ": ");
		object? o = null;
		try { o = f(); } catch (Exception ex) { o = "Err: " + ex.Message.TrimEnd('\n', '\r'); }
		switch (o)
		{
			case null: TestContext.WriteLine("null"); break;
			case var s when s is string: TestContext.WriteLine($"\"{s}\""); break;
			case var sa when sa is byte[] v: TestContext.WriteLine(Convert.ToHexString(v)); break;
			case var sa when sa is object[] v:
				foreach (var si in v)
					TestContext.Write(si is null ? "null, " : $"\"{si}\", ");
				TestContext.WriteLine();
				break;

			default: TestContext.WriteLine(o); break;
		}
	}
}