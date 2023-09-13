using NUnit.Framework;
using NUnit.Framework.Internal;
using dSPACE.Runtime.InteropServices;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.NdfApi;
using dSPACE.Runtime.InteropServices.ComTypes;

namespace NdfApi;

[TestFixture]
public class NdfApiTests
{
	[OneTimeSetUp]
	public void _Setup() => SimpleFileHelperClass.Register();

	[OneTimeTearDown]
	public void _TearDown() => SimpleFileHelperClass.Unregister();

	[Test]
	public void ConnectivtyTest()
	{
		Assert.That(NdfCreateConnectivityIncident(out SafeNDFHANDLE hNDF), ResultIs.Successful);
		Assert.That(hNDF, ResultIs.ValidHandle);
		Assert.That(NdfExecuteDiagnosis(hNDF), ResultIs.Successful);
		Assert.That(hNDF.Dispose, Throws.Nothing);
	}

	[Test]
	public void DNSTest()
	{
		Assert.That(NdfCreateDNSIncident("microsoft.com", 0, out SafeNDFHANDLE hNDF), ResultIs.Successful);
		Assert.That(hNDF, ResultIs.ValidHandle);
		Assert.That(NdfExecuteDiagnosis(hNDF), ResultIs.Successful);
		Assert.That(hNDF.Dispose, Throws.Nothing);
	}

	[Test]
	public void NetConnectionTest()
	{
		Assert.That(NdfCreateNetConnectionIncident(out SafeNDFHANDLE hNDF), ResultIs.Successful);
		Assert.That(hNDF, ResultIs.ValidHandle);
		Assert.That(NdfExecuteDiagnosis(hNDF), ResultIs.Successful);
		Assert.That(hNDF.Dispose, Throws.Nothing);
	}

	[Test]
	public void WebTest()
	{
		Assert.That(NdfCreateWebIncident("https://www.microsoft.com", out SafeNDFHANDLE hNDF), ResultIs.Successful);
		Assert.That(hNDF, ResultIs.ValidHandle);
		Assert.That(NdfExecuteDiagnosis(hNDF), ResultIs.Successful);
		Assert.That(hNDF.Dispose, Throws.Nothing);
	}
}

[ComVisible(true)]
[Guid("6A331432-4B34-41C5-BFB9-C6FFD2EE4E00")]
public class SimpleFileHelperClass : INetDiagHelper
{
	public static readonly Guid ID_LowHealthRepair = new("A9DF3AF6-6729-40E1-85CC-494F258E21A2");
	private string? m_pwszTestFile;
	private static int cookie;
	private const string coRegKey = @"CurrentControlSet\Control\NetDiagFx\VanaraTest";
	private const string regKey = $@"{coRegKey}\HostDLLs\{nameof(SimpleFileHelperClass)}\HelperClasses\{nameof(SimpleFileHelperClass)}";

	public SimpleFileHelperClass() { }

	public static void Register()
	{
		var svc = new RegistrationServices();
		cookie = svc.RegisterTypeForComClients(typeof(SimpleFileHelperClass), RegistrationClassContext.InProcessServer, RegistrationConnectionType.MultipleUse);

		using var regkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(regKey);
		regkey.SetValue("CLSID", typeof(SimpleFileHelperClass).GUID.ToString("B"));
		regkey.SetValue("Published", 1U);
		regkey.SetValue("Version", "1.0");
		//regkey.SetValue("Parent", "");
	}

	public static void Unregister()
	{
		try { Microsoft.Win32.Registry.LocalMachine.DeleteSubKeyTree(coRegKey); } catch { }
		var svc = new RegistrationServices();
		svc.UnregisterTypeForComClients(cookie);
	}

	HRESULT INetDiagHelper.Cancel() => HRESULT.E_NOTIMPL;

	HRESULT INetDiagHelper.Cleanup() => HRESULT.E_NOTIMPL;

	HRESULT INetDiagHelper.GetAttributes(out uint pcelt, out HELPER_ATTRIBUTE[]? pprgAttributes)
	{
		pcelt = default; pprgAttributes = default; return HRESULT.E_NOTIMPL;
	}

	HRESULT INetDiagHelper.GetCacheTime(out FILETIME pCacheTime)
	{
		pCacheTime = default; return HRESULT.E_NOTIMPL;
	}

	unsafe HRESULT INetDiagHelper.GetDiagnosticsInfo(out DiagnosticsInfo* ppInfo)
	{
		ppInfo = default; return HRESULT.E_NOTIMPL;
	}

	HRESULT INetDiagHelper.GetDownStreamHypotheses(out uint pcelt, out HYPOTHESIS[]? pprgHypotheses)
	{
		pcelt = default; pprgHypotheses = default; return HRESULT.E_NOTIMPL;
	}

	HRESULT INetDiagHelper.GetHigherHypotheses(out uint pcelt, out HYPOTHESIS[]? pprgHypotheses)
	{
		pcelt = default; pprgHypotheses = default; return HRESULT.E_NOTIMPL;
	}

	HRESULT INetDiagHelper.GetKeyAttributes(out uint pcelt, out HELPER_ATTRIBUTE[]? pprgAttributes)
	{
		pcelt = default; pprgAttributes = default; return HRESULT.E_NOTIMPL;
	}

	HRESULT INetDiagHelper.GetLifeTime(out LIFE_TIME pLifeTime)
	{
		pLifeTime = default; return HRESULT.E_NOTIMPL;
	}

	HRESULT INetDiagHelper.GetLowerHypotheses(out uint pcelt, out HYPOTHESIS[]? pprgHypotheses)
	{
		pcelt = default; pprgHypotheses = default; return HRESULT.E_NOTIMPL;
	}

	HRESULT INetDiagHelper.GetRepairInfo(PROBLEM_TYPE problem, out uint pcelt, out RepairInfo[]? ppInfo)
	{
		RepairInfo pRepair = default;

		// set the repair description and class name
		pRepair.pwszClassName = nameof(SimpleFileHelperClass);
		pRepair.pwszDescription = "Low Health Repair";

		// set the resolution Guid and cost
		pRepair.guid = ID_LowHealthRepair;
		pRepair.cost = 0;
		// set repair status flags
		pRepair.sidType = WELL_KNOWN_SID_TYPE.WinWorldSid;
		pRepair.scope = REPAIR_SCOPE.RS_SYSTEM;
		pRepair.risk = REPAIR_RISK.RR_NORISK;
		pRepair.flags |= REPAIR_FLAG.DF_IMPERSONATION; //impersonate the user when repairing
		pRepair.UiInfo.type = UI_INFO_TYPE.UIT_NONE;

		ppInfo = new[] { pRepair };
		pcelt = 1; //number of repairs

		return HRESULT.S_OK;
	}

	HRESULT INetDiagHelper.GetUpStreamHypotheses(out uint pcelt, out HYPOTHESIS[]? pprgHypotheses)
	{
		pcelt = default; pprgHypotheses = default; return HRESULT.E_NOTIMPL;
	}

	HRESULT INetDiagHelper.HighUtilization(string? pwszInstanceDescription, out string? ppwszDescription, out long pDeferredTime, out DIAGNOSIS_STATUS pStatus)
	{ ppwszDescription = default; pDeferredTime = default; pStatus = default; return HRESULT.E_NOTIMPL; }

	HRESULT INetDiagHelper.Initialize(uint celt, HELPER_ATTRIBUTE[] rgAttributes)
	{
		if (celt < 1 || rgAttributes is null)
		{
			return HRESULT.E_INVALIDARG;
		}
		else
		{
			//verify the attribute is named as expected
			if (string.Compare(rgAttributes[0].pwszName, "filename", true)==0)
			{
				//copy the attribute to member variable
				m_pwszTestFile = rgAttributes[0].PWStr;
				return 0;
			}
			else
			{
				//the attribute isn't named as expected
				return HRESULT.E_INVALIDARG;
			}
		}
	}

	HRESULT INetDiagHelper.LowHealth(string? pwszInstanceDescription, out string? ppwszDescription,
		out long pDeferredTime, out DIAGNOSIS_STATUS pStatus)
	{
		// does the file already exist?
		using SafeHFILE hFile = CreateFile(m_pwszTestFile!,
			FileAccess.GENERIC_READ,
			0,
			default,
			System.IO.FileMode.Open,
			FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL,
			default);

		ppwszDescription = null;
		pDeferredTime = 0;
		pStatus = DIAGNOSIS_STATUS.DS_REJECTED;

		if (hFile.IsInvalid)
		{
			ppwszDescription = "The file was deleted.";
			pStatus = DIAGNOSIS_STATUS.DS_CONFIRMED;
		}

		return HRESULT.S_OK;
	}

	HRESULT INetDiagHelper.Repair(in RepairInfo pInfo, out long pDeferredTime, out REPAIR_STATUS pStatus)
	{
		pDeferredTime = 0;
		pStatus = REPAIR_STATUS.RS_UNREPAIRED;

		//verify expected repair was requested
		if (ID_LowHealthRepair == pInfo.guid)
		{
			using SafeHFILE hFile = CreateFile(m_pwszTestFile!,
									FileAccess.GENERIC_WRITE,
									0,
									default,
									System.IO.FileMode.Create,
									FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL,
									default);
			if (hFile.IsInvalid)
				// repair ref failed pStatus = RS_UNREPAIRED;
				return Win32Error.GetLastError().ToHRESULT();

			pStatus = REPAIR_STATUS.RS_REPAIRED;
		}
		else
		{
			return HRESULT.E_INVALIDARG; //unkown repair passed in
		}
		return HRESULT.S_OK;
	}

	HRESULT INetDiagHelper.SetLifeTime(LIFE_TIME lifeTime) => HRESULT.E_NOTIMPL;

	HRESULT INetDiagHelper.Validate(PROBLEM_TYPE problem, out long pDeferredTime, out REPAIR_STATUS pStatus)
	{ pDeferredTime = default; pStatus = default; return HRESULT.E_NOTIMPL; }
}