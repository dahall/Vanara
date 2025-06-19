namespace Vanara.PInvoke;

public static partial class SpeechApi
{
	[AutoHandle]
	public partial struct SPPHRASERULEHANDLE { }

	[AutoHandle]
	public partial struct SPPHRASEPROPERTYHANDLE { }

	[ComImport, Guid("88A3342A-0BED-4834-922B-88D43173162F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SpPhraseBuilder))]
	public interface ISpPhraseBuilder : ISpPhrase
	{
		[PreserveSig]
		HRESULT InitFromPhrase([In, Optional] ManagedStructPointer<SPPHRASE> pPhrase);

		[PreserveSig]
		HRESULT InitFromSerializedPhrase(in SPSERIALIZEDPHRASE pPhrase);

		[PreserveSig]
		HRESULT AddElements(uint cElements, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SPPHRASEELEMENT[] pElement);

		[PreserveSig]
		HRESULT AddRules(SPPHRASERULEHANDLE hParent, in SPPHRASERULE pRule, out SPPHRASERULEHANDLE phNewRule);

		[PreserveSig]
		HRESULT AddProperties(SPPHRASEPROPERTYHANDLE hParent, in SPPHRASEPROPERTY pProperty, out SPPHRASEPROPERTYHANDLE phNewProperty);

		[PreserveSig]
		HRESULT AddReplacements(uint cReplacements, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SPPHRASEREPLACEMENT[] pReplacements);
	}

	[ComImport, Guid("777B6BBD-2FF2-11D3-88FE-00C04F8EF9B5"), ClassInterface(ClassInterfaceType.None)]
	public class SpPhraseBuilder { }
}
