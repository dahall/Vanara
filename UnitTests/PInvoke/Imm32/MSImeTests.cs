using NUnit.Framework;
using NUnit.Framework.Internal;
using static Vanara.PInvoke.Imm32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class MSImmTests
{
#if ILANG
	IFELanguage ilang = null;

	[OneTimeSetUp]
	public void _Setup()
	{
		CLSIDFromString("MSIME.Japan", out var clsid).ThrowIfFailed();
		CoCreateInstance(clsid, default, 5, typeof(IFELanguage).GUID, out var olang).ThrowIfFailed();
		ilang = Marshal.GetTypedObjectForIUnknown(olang, typeof(IFELanguage)) as IFELanguage;
		ilang.Open();
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
		ilang?.Close();
		ilang = null;
	}

	[Test]
	public void LangTest()
	{
		Assert.That(() => ilang.GetConversionModeCaps(out var caps), Throws.Nothing);
	}

	[DllImport("ole32.dll", SetLastError = false, ExactSpelling = true)]
	private static extern HRESULT CLSIDFromString([MarshalAs(UnmanagedType.LPWStr)] string lpsz, out Guid pclsid);

	[DllImport("ole32.dll", SetLastError = false, ExactSpelling = true)]
	private static extern HRESULT CoCreateInstance(in Guid rclsid, IntPtr pUnkOuter, uint dwClsContext, in Guid riid, out IntPtr ppv);
#endif

	[Test]
	public void PlugInDictDictionaryListTest()
	{
		var idlist = (IImePlugInDictDictionaryList)new ImePlugInDictDictionaryList1041();
		Assert.That(() => idlist.GetDictionariesInUse(out var guids, out var dt, out var enc), Throws.Nothing);
	}

	const string module = @"C:\Windows\System32\IME\IMEJP\IMJPAPI.DLL";

	//[Test]
	public void CommonTest()
	{
		Assert.That(CreateIFECommonInstance(module, out var iCommon), ResultIs.Successful);
		Assert.That(iCommon!.InvokeWordRegDialog(new(User32.GetDesktopWindow(), "Testing")), ResultIs.Successful);
	}

	//[Test]
	public void LanguageTest()
	{
		Assert.That(CreateIFELanguageInstance(module, out var iLang), ResultIs.Successful);
		const string hiragana = "晩ご飯を食べます";
		Assert.That(iLang!.GetJMorphResult(FELANG_REQ.FELANG_REQ_CONV, FELANG_CMODE.FELANG_CMODE_HIRAGANAOUT, hiragana,
			null, out MORRSLT result), ResultIs.Successful);
		Assert.That(result.pwchOutput, Is.Not.Null);
		result.WriteValues();
	}

	//[Test]
	public void DictTest()
	{
		//IFEDictionary dict = GetIFECommon() as IFEDictionary;
		//Assert.That(dict, Is.Not.Null);
		//var sb = new StringBuilder(@"%APPDATA%\Microsoft\IME\15.0\IMEJP\UserDict\imjp15cu.dic");
		//Assert.That(() => dict.GetHeader(sb, out var shf, out var fmt, out var typ), Throws.Nothing);
	}
}