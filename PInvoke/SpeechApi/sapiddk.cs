namespace Vanara.PInvoke;

public static partial class SpeechApi
{
	/// <summary>
	/// Provides methods for constructing and modifying speech recognition phrases, including initializing, adding elements, rules,
	/// properties, and replacements.
	/// </summary>
	/// <remarks>
	/// This interface is primarily used in speech recognition applications to build and manipulate phrases programmatically. It allows for
	/// initialization from existing phrases or serialized data, and provides functionality to add elements, rules, properties, and
	/// replacements to a phrase.
	/// </remarks>
	[ComImport, Guid("88A3342A-0BED-4834-922B-88D43173162F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SpPhraseBuilder))]
	public interface ISpPhraseBuilder : ISpPhrase
	{
		/// <summary><b>ISpPhraseBuilder::InitFromPhrase</b> initializes from a phrase.</summary>
		/// <param name="pPhrase">
		/// Address of a <c>SPPHRASE</c> data structure containing the phrase information. If pSrcPhrase is NULL, the object is reset to its
		/// initial state.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// </item>
		/// <item>
		/// <description>FAILED(hr)</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <example>
		/// The following code snippet demonstrates creating and initializing from a phrase.
		/// <code language="cpp">Declare local identifiers:
		///HRESULT hr = S_OK;
		///CComPtr&lt;ISpPhraseBuilder&gt;  cpPhraseBuilder;
		///CComPtr&lt;ISpPhrase&gt;         cpPhrase;
		///SPPHRASE                   Phrase;
		///hr = cpPhraseBuilder.CoCreateInstance(CLSID_SpPhraseBuilder);
		///if (SUCCEEDED(hr))
		///{
		///   // Initialize the Phrase data structure.
		///   hr = cpPhraseBuilder-&gt;InitFromPhrase(&amp;Phrase;);
		///}</code>
		/// </example>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718425(v=vs.85)
		[PreserveSig]
		HRESULT InitFromPhrase([In, Optional] ManagedStructPointer<SPPHRASE> pPhrase);

		/// <summary>ISpPhraseBuilder::InitFromSerializedPhrase initializes a phrase from a serialized phrase.</summary>
		/// <param name="pPhrase">Address of the SPSERIALIZEDPHRASE structure that contains the phrase information.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// </item>
		/// <item>
		/// <description>FAILED(hr)</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Before passing a serialized phrase into this function, first make certain that the size of the buffer being passed is equal to pPhrase-&gt;ulSerializedSize.
		/// </remarks>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ee450912(v=vs.85)
		[PreserveSig]
		HRESULT InitFromSerializedPhrase(in SPSERIALIZEDPHRASE pPhrase);

		/// <summary>ISpPhraseBuilder::AddElements adds a copy of the given element to the end of this object's element list.</summary>
		/// <param name="cElements">Specifies the number of phrase elements to add.</param>
		/// <param name="pElement">Address of the array of SPPHRASEELEMENT data structures containing the phrase elements to add.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// </item>
		/// <item>
		/// <description>FAILED(hr)</description>
		/// </item>
		/// </list>
		/// </returns>
		[PreserveSig]
		HRESULT AddElements(uint cElements, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SPPHRASEELEMENT[] pElement);

		/// <summary>ISpPhraseBuilder::AddRules adds phrase rules to the phrase object.</summary>
		/// <param name="hParent">[in] Handle to the parent phrase rule.</param>
		/// <param name="pRule">[in] Address of the SPPHRASERULE structure that contains the phrase rule information.</param>
		/// <param name="phNewRule">[out] Address of the handle of SPPHRASERULEHANDLE that contains the new phrase rule information.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// </item>
		/// <item>
		/// <description>FAILED(hr)</description>
		/// </item>
		/// </list>
		/// </returns>
		[PreserveSig]
		HRESULT AddRules(SPPHRASERULEHANDLE hParent, in SPPHRASERULE pRule, out SPPHRASERULEHANDLE phNewRule);

		/// <summary>ISpPhraseBuilder::AddProperties adds property entries to the phrase object.</summary>
		/// <param name="hParent">[in] Handle to the parent phrase element.</param>
		/// <param name="pProperty">[in] Address of the SPPHRASEPROPERTY structure that contains the property information.</param>
		/// <param name="phNewProperty">[out] Address of the handle of SPPHRASEPROPERTY that contains the new property information.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// </item>
		/// <item>
		/// <description>FAILED(hr)</description>
		/// </item>
		/// </list>
		/// </returns>
		[PreserveSig]
		HRESULT AddProperties(SPPHRASEPROPERTYHANDLE hParent, in SPPHRASEPROPERTY pProperty, out SPPHRASEPROPERTYHANDLE phNewProperty);

		/// <summary>ISpPhraseBuilder::AddReplacements adds one or more text replacements to the phrase.</summary>
		/// <param name="cReplacements">The number of replacement phrase elements.</param>
		/// <param name="pReplacements">
		/// Address of the array of SPPHRASEREPLACEMENT structures containing the phrase element replacement information.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// </item>
		/// <item>
		/// <description>FAILED(hr)</description>
		/// </item>
		/// </list>
		/// </returns>
		[PreserveSig]
		HRESULT AddReplacements(uint cReplacements, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SPPHRASEREPLACEMENT[] pReplacements);
	}

	/// <summary><b>ISpPhraseBuilder::InitFromPhrase</b> initializes from a phrase.</summary>
	/// <param name="b">A <see cref="ISpPhraseBuilder"/> instance.</param>
	/// <param name="pPhrase">
	/// Address of a <c>SPPHRASE</c> data structure containing the phrase information.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// </listheader>
	/// <item>
	/// <description>S_OK</description>
	/// </item>
	/// <item>
	/// <description>E_INVALIDARG</description>
	/// </item>
	/// <item>
	/// <description>FAILED(hr)</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <example>
	/// The following code snippet demonstrates creating and initializing from a phrase.
	/// <code language="cpp">Declare local identifiers:
	///HRESULT hr = S_OK;
	///CComPtr&lt;ISpPhraseBuilder&gt;  cpPhraseBuilder;
	///CComPtr&lt;ISpPhrase&gt;         cpPhrase;
	///SPPHRASE                   Phrase;
	///hr = cpPhraseBuilder.CoCreateInstance(CLSID_SpPhraseBuilder);
	///if (SUCCEEDED(hr))
	///{
	///   // Initialize the Phrase data structure.
	///   hr = cpPhraseBuilder-&gt;InitFromPhrase(&amp;Phrase;);
	///}</code>
	/// </example>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718425(v=vs.85)
	public static HRESULT InitFromPhrase(this ISpPhraseBuilder b, in SPPHRASE pPhrase)
	{
		using var mem = SafeCoTaskMemHandle.CreateFromStructure(pPhrase);
		return b.InitFromPhrase(mem);
	}

	/// <summary><b>ISpPhraseBuilder::InitFromPhrase</b> initializes from a phrase.</summary>
	/// <param name="b">A <see cref="ISpPhraseBuilder"/> instance.</param>
	/// <param name="pPhrase">
	/// Address of a <c>SPPHRASE</c> data structure containing the phrase information.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// </listheader>
	/// <item>
	/// <description>S_OK</description>
	/// </item>
	/// <item>
	/// <description>E_INVALIDARG</description>
	/// </item>
	/// <item>
	/// <description>FAILED(hr)</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <example>
	/// The following code snippet demonstrates creating and initializing from a phrase.
	/// <code language="cpp">Declare local identifiers:
	///HRESULT hr = S_OK;
	///CComPtr&lt;ISpPhraseBuilder&gt;  cpPhraseBuilder;
	///CComPtr&lt;ISpPhrase&gt;         cpPhrase;
	///SPPHRASE                   Phrase;
	///hr = cpPhraseBuilder.CoCreateInstance(CLSID_SpPhraseBuilder);
	///if (SUCCEEDED(hr))
	///{
	///   // Initialize the Phrase data structure.
	///   hr = cpPhraseBuilder-&gt;InitFromPhrase(&amp;Phrase;);
	///}</code>
	/// </example>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718425(v=vs.85)
	public static HRESULT InitFromPhrase(this ISpPhraseBuilder b, in SPPHRASE_M pPhrase)
	{
		using var mem = Marshaler.Marshaler.ValueToPtr(pPhrase, new(Marshaler.StringEncoding.Unicode));
		return b.InitFromPhrase(mem.DangerousGetHandle());
	}

	/// <summary>Represents a handle to a phrase property in speech recognition or synthesis operations.</summary>
	[AutoHandle]
	public partial struct SPPHRASEPROPERTYHANDLE { }

	/// <summary>Represents a handle to a phrase rule in the speech recognition system.</summary>
	[AutoHandle]
	public partial struct SPPHRASERULEHANDLE { }

	/// <summary>CLSID_SpPhraseBuilder is the class identifier for the SpPhraseBuilder class, which implements the ISpPhraseBuilder interface.</summary>
	[ComImport, Guid("777B6BBD-2FF2-11D3-88FE-00C04F8EF9B5"), ClassInterface(ClassInterfaceType.None)]
	public class SpPhraseBuilder { }
}