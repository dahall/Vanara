using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Macros;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.WinMm;

namespace Vanara.PInvoke;

public static partial class SpeechApi
{
	/*** CSpDynamicString helper class **/
	public class CSpDynamicString(string? src = null)
	{
		public StringBuilder m_psz = new(src);

		public CSpDynamicString(in CSpDynamicString src) : this(src.m_psz.ToString())
		{
		}

		public CSpDynamicString(uint capacity) : this() => m_psz = new StringBuilder((int)capacity);

		public CSpDynamicString(in Guid rguid) : this(rguid.ToString("B"))
		{
		}

		public static implicit operator CSpDynamicString(string? src) => new(src);

		public static implicit operator string(CSpDynamicString src) => src.m_psz.ToString() ?? "";

		// Original versions of Append that do not return HRESULTs
		public string Append(string pszSrc) => m_psz.Append(pszSrc).ToString();

		public string Append(string pszSrc, uint lenSrc)
		{ AppendHR(pszSrc, (int)lenSrc); return m_psz.ToString(); }

		// Original version of Append2 that does not return HRESULT
		public string Append2(string pszSrc1, string pszSrc2) => Append(string.Concat(pszSrc1, pszSrc2));

		// Version of Append2 that returns HRESULT
		public HRESULT Append2HR(string pszSrc1, string pszSrc2) => AppendHR(string.Concat(pszSrc1, pszSrc2));

		// Versions of Append that return HRESULT
		public HRESULT AppendHR(string pszSrc, int lenSrc)
		{
			m_psz.Capacity += lenSrc + 1;
			m_psz.Append(pszSrc);
			return HRESULT.S_OK;
		}

		public HRESULT AppendHR(string pszSrc) => AppendHR(pszSrc, pszSrc.Length);

		public void Attach(StringBuilder pszSrc) => m_psz = pszSrc;

		public void Clear() => m_psz.Clear();

		public string ClearAndGrowTo(uint cch) => (m_psz = new((int)cch)).ToString();

		public string Compact()
		{ m_psz.Capacity = m_psz.Length + 1; return m_psz.ToString(); }

		public string Copy() => m_psz.ToString();

		public HRESULT CopyToBSTR(out IntPtr pbstr)
		{ pbstr = Marshal.StringToBSTR(this); return 0; }

		public ReadOnlySpan<char> CopyToChar() => Copy().AsSpan();

		public string Detach()
		{
			string s = Copy();
			m_psz = new();
			return s;
		}

		public int Length() => m_psz.Length;

		public string LTrim() => (m_psz = new(m_psz.ToString().TrimStart())).ToString();

		public string RTrim() => (m_psz = new(m_psz.ToString().TrimEnd())).ToString();

		public string TrimBoth() => (m_psz = new(m_psz.ToString().Trim())).ToString();

		public void TrimToSize(uint ulNumChars) => m_psz.Capacity = (int)ulNumChars;
	}

	/*** CSpEvent helper class **/
	public class CSpEvent : IDisposable
	{
		public SPEVENT spEvent = default;

		public CSpEvent() => SpInitEvent(ref spEvent);

		public CSpEvent(ISpEventSource pEventSrc) => pEventSrc.GetEvents(1, [spEvent], out _);

		public void Dispose()
		{
			SpClearEvent(ref spEvent);
			GC.SuppressFinalize(this);
		}

		public static HRESULT CheckStringSizeBytes(PWSTR psz, SIZE_T cbMax, out SIZE_T pcb)
		{
			pcb = 0;
			if (!psz.IsNull)
			{
				var s = Marshal.PtrToStringUni((IntPtr)psz);
				pcb = s.GetByteCount(true, CharSet.Unicode);
				if (pcb > cbMax)
					return HRESULT.E_INVALIDARG;
			}
			return HRESULT.S_OK;
		}

		public ref SPEVENT AddrOf() =>
			// Note: This method does not ASSERT since we assume the caller knows what they are doing.
			ref spEvent;

		public string? BookmarkName()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_TTS_BOOKMARK);
			return String();
		}

		public void Clear() => SpClearEvent(ref spEvent);

		public void CopyFrom(in SPEVENT pSrcEvent)
		{
			SpClearEvent(ref spEvent);
			spEvent = pSrcEvent.Clone();
		}

		public void CopyTo(out SPEVENT pDestEvent) => pDestEvent = spEvent.Clone();

		public HRESULT Deserialize(StructPointer<SPEVENT> pSerEvent, out uint pcbUsed, uint cbMaxLength = 0xFFFF)
		{
			Clear();
			if (cbMaxLength < (pcbUsed = (uint)Marshal.SizeOf(typeof(SPEVENT))))
				return HRESULT.E_INVALIDARG;

			SIZE_T cbExtraSize = cbMaxLength - pcbUsed;

			unsafe
			{
				SPEVENT* pTemp = pSerEvent;
				spEvent.eEventId = pTemp->eEventId;
				spEvent.elParamType = pTemp->elParamType;
				spEvent.ulStreamNum = pTemp->ulStreamNum;
				spEvent.ullAudioStreamOffset = pTemp->ullAudioStreamOffset;
				spEvent.wParam = pTemp->wParam;
				spEvent.lParam = pTemp->lParam;

				HRESULT hr = HRESULT.S_OK;
				if (spEvent.lParam != IntPtr.Zero)
				{
					SIZE_T cbAlloc = 0;
					switch (spEvent.elParamType)
					{
						case SPEVENTLPARAMTYPE.SPET_LPARAM_IS_POINTER:
							cbAlloc = (int)spEvent.wParam;
							if (cbAlloc > cbExtraSize)
								hr = HRESULT.E_INVALIDARG;
							break;

						case SPEVENTLPARAMTYPE.SPET_LPARAM_IS_STRING:
							hr = CheckStringSizeBytes((char*)(pTemp + 1), cbExtraSize, out cbAlloc);
							break;

						case SPEVENTLPARAMTYPE.SPET_LPARAM_IS_TOKEN:
							hr = CheckStringSizeBytes((char*)(pTemp + 1), cbExtraSize, out _);
							if (hr.Succeeded)
							{
								hr = SpGetTokenFromId(new((char*)(pTemp + 1)), out ISpObjectToken lp);
								spEvent.lParam = Marshal.GetIUnknownForObject(lp);
								spEvent.wParam = IntPtr.Zero;
							}
							break;

						case SPEVENTLPARAMTYPE.SPET_LPARAM_IS_UNDEFINED:
							break;

						case SPEVENTLPARAMTYPE.SPET_LPARAM_IS_OBJECT:
							hr = HRESULT.E_INVALIDARG;
							break;

						default:
							hr = HRESULT.E_INVALIDARG;
							break;
					}

					if (hr.Succeeded && cbAlloc != 0)
					{
						IntPtr pvBuff = Marshal.AllocCoTaskMem(cbAlloc);
						spEvent.lParam = (IntPtr)pvBuff;
						if (pvBuff != IntPtr.Zero)
						{
							((IntPtr)(pTemp + 1)).CopyTo(pvBuff, cbAlloc);
						}
						else
						{
							hr = HRESULT.E_OUTOFMEMORY;
						}
					}
				}
				else
				{
					// pTemp.SerializedlParam is 0 lParam can't be a Token
					if (pTemp->elParamType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_TOKEN)
					{
						hr = HRESULT.E_INVALIDARG;
					}
				}

				if (hr.Succeeded && pcbUsed != 0)
				{
					pcbUsed = (uint)SerializeSize();
					if (pcbUsed == 0)
					{
						hr = HRESULT.E_FAIL;
					}
				}

				// Reset the data structure on failure. Otherwise, the destructor may AV.
				if (hr.Failed)
				{
					Clear();
				}

				return hr;
			}
		}

		public void Detach(out SPEVENT pDestEvent)
		{
			pDestEvent = spEvent;
			spEvent = new();
		}

		public HRESULT EndStreamResult()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_END_SR_STREAM);
			return (HRESULT)(int)spEvent.lParam;
		}

		public HRESULT GetFrom(ISpEventSource pEventSrc)
		{
			SpClearEvent(ref spEvent);
			SPEVENT[] evts = new SPEVENT[1];
			var hr = pEventSrc.GetEvents(1, evts, out var c);
			if (hr.Succeeded && c == 1) spEvent = evts[0];
			return hr;
		}

		public uint InputSentLen()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_SENTENCE_BOUNDARY);
			return (uint)(int)spEvent.wParam;
		}

		public uint InputSentPos()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_SENTENCE_BOUNDARY);
			return (uint)(int)spEvent.lParam;
		}

		public bool InputStreamReleased()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_END_SR_STREAM);
			return ((int)spEvent.wParam & (int)SPENDSRSTREAMFLAGS.SPESF_STREAM_RELEASED) != 0;
		}

		public uint InputWordLen()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_WORD_BOUNDARY);
			return (uint)(int)spEvent.wParam;
		}

		public uint InputWordPos()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_WORD_BOUNDARY);
			return (uint)(int)spEvent.lParam;
		}

		public SPINTERFERENCE Interference()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_INTERFERENCE);
			return (SPINTERFERENCE)(int)spEvent.lParam;
		}

		public bool IsEmulated() => (BOOL)((int)spEvent.wParam & (int)SPRECOEVENTFLAGS.SPREF_Emulated);

		public bool IsPaused() => (BOOL)((int)spEvent.wParam & (int)SPRECOEVENTFLAGS.SPREF_AutoPause);

		public bool IsSMLTimeout() => (BOOL)((int)spEvent.wParam & (int)SPRECOEVENTFLAGS.SPREF_SMLTimeout);

		public object Object()
		{
			Debug.Assert(spEvent.elParamType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_OBJECT);
			return Marshal.GetObjectForIUnknown(spEvent.lParam);
		}

		public ISpObjectToken ObjectToken()
		{
			Debug.Assert(spEvent.elParamType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_TOKEN);
			return (ISpObjectToken)Marshal.GetObjectForIUnknown(spEvent.lParam);
		}

		public bool PersistVoiceChange()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_VOICE_CHANGE);
			return (BOOL)spEvent.wParam;
		}

		// Helpers for access to events. Performs run-time checks in debug and casts data to the appropriate types
		public char Phoneme()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_PHONEME);
			return (char)LOWORD(spEvent.lParam);
		}

		public string? PropertyName()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_PROPERTY_NUM_CHANGE && spEvent.elParamType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_STRING ||
			spEvent.eEventId == SPEVENTENUM.SPEI_PROPERTY_STRING_CHANGE && spEvent.elParamType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_POINTER);
			// Note: Don't use String() method here since in the case of string attributes, the elParamType field specifies LPARAM_IS_POINTER,
			// but the attribute name IS the first string in this buffer
			return String();
		}

		public int PropertyNumValue()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_PROPERTY_NUM_CHANGE);
			return (int)spEvent.wParam;
		}

		public string? PropertyStringValue()
		{
			// Search for the first default and return pointer to the byte past it.
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_PROPERTY_STRING_CHANGE);
			string? psz = String();
			return Marshal.PtrToStringUni(spEvent.lParam.Offset(psz.GetByteCount(true, CharSet.Unicode)));
		}

		public ISpRecoResult RecoResult() => (ISpRecoResult)Object();

		public SPRECOSTATE RecoState()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_RECO_STATE_CHANGE);
			return (SPRECOSTATE)spEvent.wParam;
		}

		public string? RequestTypeOfUI()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_REQUEST_UI);
			return String();
		}

		public uint RetainedAudioSize()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_SR_RETAINEDAUDIO);
			return (uint)(int)spEvent.wParam;
		}

		public ISpStreamFormat RetainedAudioStream()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_SR_RETAINEDAUDIO);
			return (ISpStreamFormat)Object();
		}

		// Call spEvent method with either SPSERIALIZEDEVENT or SPSERIALIZEDEVENT64
		public void Serialize(out SafeCoTaskMemStruct<SPEVENT> pSerEvent)
		{
			if (spEvent.elParamType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_OBJECT)
				throw Marshal.GetExceptionForHR(HRESULT.E_UNEXPECTED)!;
			pSerEvent = new(spEvent);

			if (spEvent.lParam != IntPtr.Zero)
			{
				byte[] pExtra = spEvent.elParamType switch
				{
					SPEVENTLPARAMTYPE.SPET_LPARAM_IS_POINTER => spEvent.lParam.ToByteArray(spEvent.wParam.ToInt32())!,
					SPEVENTLPARAMTYPE.SPET_LPARAM_IS_STRING => StringHelper.GetString(spEvent.lParam, CharSet.Unicode)?.GetBytes(true, CharSet.Unicode)! ?? [],
					SPEVENTLPARAMTYPE.SPET_LPARAM_IS_TOKEN => ((ISpObjectToken)Marshal.GetObjectForIUnknown(spEvent.lParam)).GetId(out string dstrObjectId).Succeeded
						? dstrObjectId.GetBytes(true, CharSet.Unicode)! : [],
					_ => []
				};
				pSerEvent.Append(spEvent.lParam.ToByteArray(spEvent.wParam.ToInt32())!);
				ref SPEVENT serEvent = ref pSerEvent.AsRef();
				serEvent.lParam = pSerEvent.DangerousGetHandle().Offset(Marshal.SizeOf(typeof(SPEVENT)));
				if (spEvent.elParamType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_TOKEN)
					serEvent.wParam = (IntPtr)pExtra.Length;
			}
		}

		public int SerializeSize() => SpEventSerializeSize(spEvent);

		public string? String()
		{
			Debug.Assert(spEvent.elParamType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_STRING);
			return Marshal.PtrToStringUni(spEvent.lParam);
		}

		public SPVISEMES Viseme()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_VISEME);
			return (SPVISEMES)LOWORD(spEvent.lParam);
		}

		public ISpObjectToken VoiceToken() // More explicit check than ObjectToken()
		{
			Debug.Assert(spEvent.eEventId == SPEVENTENUM.SPEI_VOICE_CHANGE);
			return ObjectToken();
		}
	}

	public class CSpPhrasePtr
	{
		public SafeCoTaskMemStruct<SPPHRASE> m_pPhrase;

		public CSpPhrasePtr(ISpPhrase pPhraseObj) => pPhraseObj.GetPhrase(out m_pPhrase);

		public ref SPPHRASE AsRef() => ref m_pPhrase.AsRef();

		//The Debug.Assert on operator& usually indicates a bug. If this is really
		//what is needed, however, take the address of the m_pPhrase member explicitly.
		public void Clear()
		{
			if (!m_pPhrase.IsInvalid)
			{
				m_pPhrase.Dispose();
				m_pPhrase = SafeCoTaskMemStruct<SPPHRASE>.Null;
			}
		}

		public void GetFrom(ISpPhrase pPhraseObj)
		{
			Clear();
			pPhraseObj.GetPhrase(out m_pPhrase);
		}
	}

	public class CSpStreamFormat() : IEquatable<CSpStreamFormat>
	{
		public Guid m_guidFormatId = Guid.Empty;
		public SafeCoTaskMemStruct<WAVEFORMATEX> m_pCoMemWaveFormatEx = SafeCoTaskMemStruct<WAVEFORMATEX>.Null;

		public CSpStreamFormat(SPSTREAMFORMAT eFormat, out HRESULT phr) : this() => phr = SpConvertStreamFormatEnum(eFormat, out m_guidFormatId, out m_pCoMemWaveFormatEx);

		public unsafe CSpStreamFormat([In] WAVEFORMATEX* pWaveFormatEx, out HRESULT phr) : this() => phr = AssignFormat(pWaveFormatEx);

		public static bool operator !=(CSpStreamFormat? left, CSpStreamFormat? right) => !(left == right);

		public static bool operator ==(CSpStreamFormat? left, CSpStreamFormat? right) => left?.Equals(right) ?? right is null;

		public HRESULT AssignFormat(SPSTREAMFORMAT eFormat) => SpConvertStreamFormatEnum(eFormat, out m_guidFormatId, out m_pCoMemWaveFormatEx);

		public HRESULT AssignFormat(ISpStreamFormat pStream)
		{
			m_pCoMemWaveFormatEx.Dispose();
			try
			{
				pStream.GetFormat(m_guidFormatId, out m_pCoMemWaveFormatEx);
				ref WAVEFORMATEX wfex = ref m_pCoMemWaveFormatEx.AsRef();
				if (wfex.wFormatTag == WAVE_FORMAT.WAVE_FORMAT_PCM)
				{
					wfex.cbSize = 0; // Always set cbSize to zero for WAVE_FORMAT_PCM.
				}
				if (wfex.nAvgBytesPerSec == 0 || wfex.nBlockAlign == 0 || wfex.nChannels == 0)
				{
					Clear();
					throw new ArgumentException();
				}
				return HRESULT.S_OK;
			}
			catch (Exception ex)
			{
				return ex.HResult;
			}
		}

		public unsafe HRESULT AssignFormat([In] WAVEFORMATEX* pWaveFormatEx)
		{
			if (pWaveFormatEx->nBlockAlign == 0)
				return HRESULT.E_INVALIDARG;

			m_pCoMemWaveFormatEx.Dispose();
			HRESULT hr = CoMemCopyWFEX(pWaveFormatEx, out m_pCoMemWaveFormatEx);
			m_guidFormatId = hr.Succeeded ? SPDFID_WaveFormatEx : Guid.Empty;
			return hr;
		}

		public unsafe HRESULT AssignFormat(in Guid rguidFormatId, [In] WAVEFORMATEX* pWaveFormatEx)
		{
			HRESULT hr = HRESULT.S_OK;

			m_guidFormatId = rguidFormatId;
			m_pCoMemWaveFormatEx.Dispose();

			if (rguidFormatId == SPDFID_WaveFormatEx)
			{
				hr = CoMemCopyWFEX(pWaveFormatEx, out m_pCoMemWaveFormatEx);
				if (hr.Failed)
				{
					m_guidFormatId = Guid.Empty;
				}
			}

			return hr;
		}

		public HRESULT AssignFormat(in CSpStreamFormat Src)
		{
			Clear();
			return Src.CopyTo(out m_guidFormatId, out m_pCoMemWaveFormatEx);
		}

		public void Clear()
		{
			m_pCoMemWaveFormatEx.Dispose();
			m_pCoMemWaveFormatEx = SafeCoTaskMemStruct<WAVEFORMATEX>.Null;
			m_guidFormatId = Guid.Empty;
		}

		public SPSTREAMFORMAT ComputeFormatEnum()
		{
			if (m_guidFormatId == Guid.Empty)
			{
				return SPSTREAMFORMAT.SPSF_NoAssignedFormat;
			}
			if (m_guidFormatId == SPDFID_Text)
			{
				return SPSTREAMFORMAT.SPSF_Text;
			}
			if (m_guidFormatId != SPDFID_WaveFormatEx || m_pCoMemWaveFormatEx.IsInvalid)
			{
				return SPSTREAMFORMAT.SPSF_NonStandardFormat;
			}
			// It is a WAVEFORMATEX. Now determine which type it is and convert.
			uint dwIndex = 0;
			ref WAVEFORMATEX wfex = ref m_pCoMemWaveFormatEx.AsRef();
			switch (wfex.wFormatTag)
			{
				case WAVE_FORMAT.WAVE_FORMAT_PCM:
					{
						switch (wfex.nChannels)
						{
							case 1:
								break;

							case 2:
								dwIndex |= 1;
								break;

							default:
								return SPSTREAMFORMAT.SPSF_ExtendedAudioFormat;
						}

						switch (wfex.wBitsPerSample)
						{
							case 8:
								break;

							case 16:
								dwIndex |= 2;
								break;

							default:
								return SPSTREAMFORMAT.SPSF_ExtendedAudioFormat;
						}

						switch (wfex.nSamplesPerSec)
						{
							case 48000:
								dwIndex += 4; goto case 44100; // Fall through
							case 44100:
								dwIndex += 4; goto case 32000; // Fall through
							case 32000:
								dwIndex += 4; goto case 24000; // Fall through
							case 24000:
								dwIndex += 4; goto case 22050; // Fall through
							case 22050:
								dwIndex += 4; goto case 16000; // Fall through
							case 16000:
								dwIndex += 4; goto case 12000; // Fall through
							case 12000:
								dwIndex += 4; goto case 11025; // Fall through
							case 11025:
								dwIndex += 4; goto case 8000; // Fall through
							case 8000:
								break;

							default:
								return SPSTREAMFORMAT.SPSF_ExtendedAudioFormat;
						}

						return (SPSTREAMFORMAT)((uint)SPSTREAMFORMAT.SPSF_8kHz8BitMono + dwIndex);
					}

				case WAVE_FORMAT.WAVE_FORMAT_DSPGROUP_TRUESPEECH:
					{
						return SPSTREAMFORMAT.SPSF_TrueSpeech_8kHz1BitMono;
					}

				case WAVE_FORMAT.WAVE_FORMAT_ALAW: // fall through
				case WAVE_FORMAT.WAVE_FORMAT_MULAW:
				case WAVE_FORMAT.WAVE_FORMAT_ADPCM:
					{
						switch (wfex.nChannels)
						{
							case 1:
								break;

							case 2:
								dwIndex |= 1;
								break;

							default:
								return SPSTREAMFORMAT.SPSF_ExtendedAudioFormat;
						}

						if (wfex.wFormatTag == WAVE_FORMAT.WAVE_FORMAT_ADPCM)
						{
							if (wfex.wBitsPerSample != 4)
							{
								return SPSTREAMFORMAT.SPSF_ExtendedAudioFormat;
							}
						}
						else if (wfex.wBitsPerSample != 8)
						{
							return SPSTREAMFORMAT.SPSF_ExtendedAudioFormat;
						}

						switch (wfex.nSamplesPerSec)
						{
							case 44100:
								dwIndex += 2; goto case 22050; // Fall through
							case 22050:
								dwIndex += 2; goto case 11025; // Fall through
							case 11025:
								dwIndex += 2; goto case 8000; // Fall through
							case 8000:
								break;

							default:
								return SPSTREAMFORMAT.SPSF_ExtendedAudioFormat;
						}

						switch (wfex.wFormatTag)
						{
							case WAVE_FORMAT.WAVE_FORMAT_ALAW:
								return (SPSTREAMFORMAT)((uint)SPSTREAMFORMAT.SPSF_CCITT_ALaw_8kHzMono + dwIndex);

							case WAVE_FORMAT.WAVE_FORMAT_MULAW:
								return (SPSTREAMFORMAT)((uint)SPSTREAMFORMAT.SPSF_CCITT_uLaw_8kHzMono + dwIndex);

							case WAVE_FORMAT.WAVE_FORMAT_ADPCM:
								return (SPSTREAMFORMAT)((uint)SPSTREAMFORMAT.SPSF_ADPCM_8kHzMono + dwIndex);
						}
					}
					goto case WAVE_FORMAT.WAVE_FORMAT_GSM610; // Fall through to handle GSM610

				case WAVE_FORMAT.WAVE_FORMAT_GSM610:
					{
						if (wfex.nChannels != 1)
						{
							return SPSTREAMFORMAT.SPSF_ExtendedAudioFormat;
						}

						switch (wfex.nSamplesPerSec)
						{
							case 44100:
								dwIndex = 3;
								break;

							case 22050:
								dwIndex = 2;
								break;

							case 11025:
								dwIndex = 1;
								break;

							case 8000:
								dwIndex = 0;
								break;

							default:
								return SPSTREAMFORMAT.SPSF_ExtendedAudioFormat;
						}

						return (SPSTREAMFORMAT)((uint)SPSTREAMFORMAT.SPSF_GSM610_8kHzMono + dwIndex);
					}

				default:
					return SPSTREAMFORMAT.SPSF_ExtendedAudioFormat;
			}
		}

		public HRESULT CopyTo(out Guid pFormatId, out SafeCoTaskMemStruct<WAVEFORMATEX> ppCoMemWFEX)
		{
			HRESULT hr = HRESULT.S_OK;
			pFormatId = m_guidFormatId;
			if (!m_pCoMemWaveFormatEx.IsInvalid)
			{
				ppCoMemWFEX = new(m_pCoMemWaveFormatEx.Size);
				m_pCoMemWaveFormatEx.CopyTo(ppCoMemWFEX);
			}
			else
			{
				ppCoMemWFEX = SafeCoTaskMemStruct<WAVEFORMATEX>.Null;
			}
			return hr;
		}

		public HRESULT CopyTo(ref CSpStreamFormat Other)
		{
			Other.Clear();
			return CopyTo(out Other.m_guidFormatId, out Other.m_pCoMemWaveFormatEx);
		}

		public HRESULT Deserialize([In] IntPtr pBuffer, out uint pcbUsed)
		{
			pcbUsed = 0;

			// check pointer to pBuffer for size value
			if (pBuffer == IntPtr.Zero)
				return HRESULT.E_INVALIDARG;

			pcbUsed = pBuffer.ToStructure<uint>();

			// check complete pBuffer from start
			var wfoff = Marshal.SizeOf<Guid>() + sizeof(uint);
			if (pcbUsed < wfoff)
			{
				return HRESULT.E_INVALIDARG;
			}

			Clear();

			m_guidFormatId = pBuffer.ToStructure<Guid>(pcbUsed, sizeof(uint));
			m_pCoMemWaveFormatEx = new(pcbUsed - wfoff);
			if (pcbUsed > wfoff)
			{
				unsafe
				{
					var hr = CoMemCopyWFEX((WAVEFORMATEX*)pBuffer.Offset(wfoff).ToPointer(), out m_pCoMemWaveFormatEx);
					if (hr.Failed)
						m_guidFormatId = Guid.Empty;
					return hr;
				}
			}
			return HRESULT.S_OK;
		}

		public void DetachTo(ref CSpStreamFormat Other)
		{
			Other.Clear();
			DetachTo(out Other.m_guidFormatId, out Other.m_pCoMemWaveFormatEx);
		}

		public void DetachTo(out Guid pFormatId, out SafeCoTaskMemStruct<WAVEFORMATEX> ppCoMemWaveFormatEx)
		{
			pFormatId = m_guidFormatId;
			ppCoMemWaveFormatEx = m_pCoMemWaveFormatEx;
			m_pCoMemWaveFormatEx = SafeCoTaskMemStruct<WAVEFORMATEX>.Null;
			m_guidFormatId = Guid.Empty;
		}

		public bool Equals(CSpStreamFormat? Other) => Other is not null && IsEqual(Other.m_guidFormatId, Other.m_pCoMemWaveFormatEx);

		public override bool Equals(object? other) => other is CSpStreamFormat Other && Equals(Other);

		public Guid FormatId() => m_guidFormatId;

		public override int GetHashCode() => (m_guidFormatId, m_pCoMemWaveFormatEx.DangerousGetHandle()).GetHashCode();

		public unsafe bool IsEqual(in Guid rguidFormatId, [In] WAVEFORMATEX* pwfex) =>
			IsEqual(rguidFormatId, new SafeCoTaskMemStruct<WAVEFORMATEX>((IntPtr)pwfex, false, sizeof(WAVEFORMATEX) + pwfex->cbSize));

		public bool IsEqual(in Guid rguidFormatId, [In] SafeCoTaskMemStruct<WAVEFORMATEX> pwfex) =>
			rguidFormatId == m_guidFormatId && (pwfex.IsInvalid ? m_pCoMemWaveFormatEx.IsInvalid : pwfex.CompareTo(m_pCoMemWaveFormatEx) == 0);

		public unsafe HRESULT ParamValidateAssignFormat(in Guid rguidFormatId, [In] WAVEFORMATEX* pWaveFormatEx, bool fRequireWaveFormat = false)
		{
			if (rguidFormatId != SPDFID_WaveFormatEx || fRequireWaveFormat && pWaveFormatEx is null)
			{
				return HRESULT.E_INVALIDARG;
			}
			return AssignFormat(rguidFormatId, pWaveFormatEx);
		}

		public uint Serialize(ISafeMemoryHandle hMem) => Serialize(hMem.DangerousGetHandle(), hMem.Size);

		public uint Serialize([Out] IntPtr pBuffer, uint cbBuffer)
		{
			uint cb = SerializeSize();
			if (cbBuffer < cb)
			{
				Debug.WriteLine("Insufficient buffer size");
				SetLastError(Win32Error.ERROR_INSUFFICIENT_BUFFER);
				return 0;
			}

			var pos = pBuffer.Write(cb);
			pos += pBuffer.Write(m_guidFormatId, pos);
			if (!m_pCoMemWaveFormatEx.IsInvalid)
				m_pCoMemWaveFormatEx.CopyTo(pBuffer.Offset(pos), m_pCoMemWaveFormatEx.Size);
			return cb;
		}

		public uint SerializeSize()
		{
			uint cb = sizeof(uint) + (uint)Marshal.SizeOf<Guid>();
			if (!m_pCoMemWaveFormatEx.IsInvalid)
			{
				ref WAVEFORMATEX wfex = ref m_pCoMemWaveFormatEx.AsRef();
				if (wfex.cbSize != 0 && wfex.wFormatTag == WAVE_FORMAT.WAVE_FORMAT_PCM)
				{
					Debug.WriteLine("PCM wave format");
					SetLastError(Win32Error.ERROR_INVALID_STATE);
					return 0;
				}
				cb += (uint)Marshal.SizeOf(typeof(WAVEFORMATEX)) + wfex.cbSize + 3; // Add 3 to round up
				cb -= cb % 4; // Round to uint
			}
			return cb;
		}

		public ref WAVEFORMATEX WaveFormatExAsRef() => ref m_pCoMemWaveFormatEx.AsRef();

		public unsafe WAVEFORMATEX* WaveFormatExPtr() => (WAVEFORMATEX*)(void*)m_pCoMemWaveFormatEx;

		private static unsafe HRESULT CoMemCopyWFEX([In] WAVEFORMATEX* pSrc, out SafeCoTaskMemStruct<WAVEFORMATEX> ppCoMemWFEX)
		{
			ppCoMemWFEX = SafeCoTaskMemStruct<WAVEFORMATEX>.Null;
			if (pSrc is null || pSrc->nAvgBytesPerSec == 0 || pSrc->nBlockAlign == 0 || pSrc->nChannels == 0) // There are other fields like wBitsPerSample but these can be zero in some formats.
			{
				return HRESULT.E_INVALIDARG;
			}

			uint cb = (uint)Marshal.SizeOf(typeof(WAVEFORMATEX));
			if (pSrc->wFormatTag != WAVE_FORMAT.WAVE_FORMAT_PCM)
			{
				// Add the extra data size in but ignore for WAVE_FORMAT_PCM {accoring to MSDN this should be ignored}.
				cb += pSrc->cbSize;
				if (cb < pSrc->cbSize)
					return HRESULT.E_INVALIDARG;
			}

			ppCoMemWFEX = new(*pSrc, cb);
			if (pSrc->wFormatTag == WAVE_FORMAT.WAVE_FORMAT_PCM)
				ppCoMemWFEX.AsRef().cbSize = 0; // Always set cbSize to zero for WAVE_FORMAT_PCM.
			return HRESULT.S_OK;
		}
	}

	/**** Helper function used to create a new phrase object from a
		test string. Each word in the string is converted to a phrase element.
		This is useful to create a phrase to pass to the EmulateRecognition method.
		The method can convert standard words as well as words with the
		"/display_text/lexical_form/pronounciation;" word format.
		If the emulation needs to match word sequence data (textbuffer) then
		the corresponding words need to be bracketed with '[' and ']' so they
		can be put into a single phrase element
		****/
	public static HRESULT CreatePhraseFromText(string pszOriginalText, out ISpPhraseBuilder ppResultPhrase, LANGID LangId = default,
		ISpPhoneConverter? cpPhoneConv = null, bool fNoSpecialCharacters = false)
	{
		HRESULT hr = HRESULT.S_OK;

		//We first trim the input text
		StringBuilder dsText = new(pszOriginalText.Trim());

		var matches = Regex.Matches(pszOriginalText, @"/(.*?)/(.*?)/(.*?);");
		List<string> pStringPtrArray = [];
		foreach (var m in matches.Cast<Match>())
		{
			pStringPtrArray.Add(m.Value);
			dsText.Replace(m.Value, string.Empty);
		}
		pStringPtrArray.AddRange(Regex.Replace(dsText.ToString(), @"\s+", " ").Split(' '));

		return CreatePhraseFromWordArray(pStringPtrArray.ToArray(), default, out ppResultPhrase, LangId, cpPhoneConv, fNoSpecialCharacters);
	}

	/**** Helper function used to create a new phrase object from an array of
		test words. Each word in the string is converted to a phrase element.
		This is useful to create a phrase to pass to the EmulateRecognition method.
		The method can convert standard words as well as words with the
		"/display_text/lexical_form/pronounciation;" word format.
		You can also specify the DisplayAttributes for each element if desired.
		If prgDispAttribs is NULL then the DisplayAttribs for each element default to
		SPAF_ONE_TRAILING_SPACE. ****/
	public static HRESULT CreatePhraseFromWordArray(string[] ppWords, SPDISPLAYATTRIBUTES[]? prgDispAttribs, out ISpPhraseBuilder ppResultPhrase,
		LANGID LangId = default, ISpPhoneConverter? cpPhoneConv = default, bool fNoSpecialCharacters = false)
	{
		ppResultPhrase = default!;

		if (ppWords is null || ppWords.Length == 0 || (prgDispAttribs is not null && prgDispAttribs.Length != ppWords.Length))
			return HRESULT.E_INVALIDARG;

		SIZE_T cTotalChars = ppWords.Sum(w => w.Length + 1);

		SPPHONEID[] pphoneId = new SPPHONEID[cTotalChars];

		SPPHRASE Phrase = new() { cbSize = (uint)Marshal.SizeOf(typeof(SPPHRASE)) };

		if (LangId == default)
			LangId = SpGetUserDefaultUILanguage();

		SPPHRASEELEMENT_M[] pPhraseElement = new SPPHRASEELEMENT_M[ppWords.Length];
		HRESULT hr = HRESULT.S_OK;
		for (int i = 0; hr.Succeeded && i < ppWords.Length; i++)
		{
			Match m = Regex.Match(ppWords[i], @"/(.*?)/(.*?)/(.*?);");
			if (m.Success)
			{
				string pszFirstPart = m.Groups[1].Value;
				string pszSecondPart = m.Groups[2].Value;
				string pszThirdPart = m.Groups[3].Value;

				pPhraseElement[i].pszDisplayText = pszFirstPart;
				pPhraseElement[i].pszLexicalForm = pszSecondPart != string.Empty ? pszSecondPart : pszFirstPart;

				if (pszThirdPart != string.Empty)
				{
					if (cpPhoneConv is null)
					{
						hr = SpCreatePhoneConverter(LangId, default, default, out cpPhoneConv);
						if (hr.Failed)
							break;
					}

					Array.Clear(pphoneId, 0, pphoneId.Length);
					cpPhoneConv.PhoneToId(pszThirdPart, pphoneId);
					pPhraseElement[i].pszPronunciation = pphoneId;
				}
			}
			else
			{
				//It is the simple format, only have one form, use it for everything.
				pPhraseElement[i].pszDisplayText = default;
				pPhraseElement[i].pszLexicalForm = ppWords[i];
				pPhraseElement[i].pszPronunciation = default;
			}

			pPhraseElement[i].bDisplayAttributes = prgDispAttribs is not null ? prgDispAttribs[i] : SPDISPLAYATTRIBUTES.SPAF_ONE_TRAILING_SPACE;
			pPhraseElement[i].RequiredConfidence = SP_CONFIDENCE.SP_NORMAL_CONFIDENCE;
			pPhraseElement[i].ActualConfidence = SP_CONFIDENCE.SP_NORMAL_CONFIDENCE;
			pPhraseElement[i].SREngineConfidence = 1.0f; // Emulated results give confidence of 1.0
		}

		Phrase.Rule.ulCountOfElements = (uint)ppWords.Length;
		Phrase.Rule.SREngineConfidence = 1.0f;
		using var pPhraseArray = SafeCoTaskMemHandle.CreateFromList(pPhraseElement);
		Phrase.pElements = pPhraseArray;
		Phrase.LangID = LangId;

		ISpPhraseBuilder cpPhrase = new();
		hr = cpPhrase.InitFromPhrase(SafeCoTaskMemHandle.CreateFromStructure(Phrase));
		ppResultPhrase = cpPhrase;

		return hr;
	}

	public static unsafe HRESULT SPBindToFile(string pFileName, SPFILEMODE eMode, out ISpStream ppStream, Guid? pFormatId = default,
		[In] WAVEFORMATEX* pWaveFormatEx = default, SPEVENTENUM ullEventInterest = SPEVENTENUM.SPFEI_ALL_EVENTS)
	{
		try
		{
			ppStream = new();
			ppStream.BindToFile(pFileName, eMode, new(pFormatId, out _), pWaveFormatEx, ullEventInterest);
			return HRESULT.S_OK;
		}
		catch (Exception ex)
		{
			ppStream = default!;
			return ex.HResult;
		}
	}

	/****************************************************************************
	* SpClearEvent *
	*--------------*
	*   Description:
	*       Helper function that can be used by clients that do not use the CSpEvent
	*   class.
	*
	*   Returns:
	*
	*****************************************************************************/
	public static void SpClearEvent(ref SPEVENT pe) => pe.Dispose();

	public static HRESULT SPCoCreateGuid(out Guid pGuid) => CoCreateGuid(out pGuid);

	// Return the default codepage given a LCID. Note some of the newer locales do not have associated Windows codepages. For these, we
	// return UTF-8.
	public static uint SpCodePageFromLcid(LCID lcid)
	{
		StringBuilder achCodePage = new(6);
		return 0 != GetLocaleInfo(lcid, LCTYPE.LOCALE_IDEFAULTANSICODEPAGE, achCodePage, achCodePage.Capacity) ? uint.Parse(achCodePage.ToString()) : 65001;
	}

	/****************************************************************************
	* SpConvertStreamFormatEnum *
	*---------------------------*
	*   Description:
	*       This method converts the specified stream format into a wave format
	*   structure.
	*
	*****************************************************************************/
	public static HRESULT SpConvertStreamFormatEnum(SPSTREAMFORMAT eFormat, out Guid pFormatId, out SafeCoTaskMemStruct<WAVEFORMATEX> ppCoMemWaveFormatEx)
	{
		HRESULT hr = HRESULT.S_OK;

		Guid pFmtGuid = Guid.Empty; // Assume failure case
		ppCoMemWaveFormatEx = SafeCoTaskMemStruct<WAVEFORMATEX>.Null;
		WAVEFORMATEX pwfex = new();
		byte[] pExtra = [];

		if (eFormat is >= SPSTREAMFORMAT.SPSF_8kHz8BitMono and <= SPSTREAMFORMAT.SPSF_48kHz16BitStereo)
		{
			uint dwIndex = (uint)(eFormat - SPSTREAMFORMAT.SPSF_8kHz8BitMono);
			bool bIsStereo = (dwIndex & 0x1) != 0;
			bool bIs16 = (dwIndex & 0x2) != 0;
			uint dwKHZ = (dwIndex & 0x3c) >> 2;
			uint[] adwKHZ = { 8000, 11025, 12000, 16000, 22050, 24000, 32000, 44100, 48000 };

			pwfex.wFormatTag = WAVE_FORMAT.WAVE_FORMAT_PCM;
			pwfex.nSamplesPerSec = dwKHZ < adwKHZ.Length ? adwKHZ[dwKHZ] : adwKHZ[0];
			pwfex.wBitsPerSample = 8;
			pwfex.nChannels = pwfex.nBlockAlign = (ushort)(bIsStereo ? 2 : 1);
			pwfex.nAvgBytesPerSec = pwfex.nSamplesPerSec * pwfex.nBlockAlign;
			if (bIs16)
			{
				pwfex.wBitsPerSample *= 2;
				pwfex.nBlockAlign *= 2;
			}
			ppCoMemWaveFormatEx = pwfex;

			pFmtGuid = SPDFID_WaveFormatEx;
		}
		else if (eFormat == SPSTREAMFORMAT.SPSF_TrueSpeech_8kHz1BitMono)
		{
			pwfex.wFormatTag = WAVE_FORMAT.WAVE_FORMAT_DSPGROUP_TRUESPEECH;
			pwfex.nChannels = 1;
			pwfex.nSamplesPerSec = 8000;
			pwfex.nAvgBytesPerSec = 1067;
			pwfex.nBlockAlign = 32;
			pwfex.wBitsPerSample = 1;
			pwfex.cbSize = 32;

			pExtra = new byte[32];
			pExtra[0] = 1;
			pExtra[2] = 0xF0;

			pFmtGuid = SPDFID_WaveFormatEx;
		}
		else if (eFormat is >= SPSTREAMFORMAT.SPSF_CCITT_ALaw_8kHzMono and <= SPSTREAMFORMAT.SPSF_CCITT_ALaw_44kHzStereo)
		{
			uint dwIndex = (uint)(eFormat - SPSTREAMFORMAT.SPSF_CCITT_ALaw_8kHzMono);
			uint dwKHZ = dwIndex / 2;
			uint[] adwKHZ = { 8000, 11025, 22050, 44100 };
			bool bIsStereo = (dwIndex & 0x1) != 0;

			pwfex.wFormatTag = WAVE_FORMAT.WAVE_FORMAT_ALAW;
			pwfex.nChannels = pwfex.nBlockAlign = (ushort)(bIsStereo ? 2 : 1);
			pwfex.nSamplesPerSec = dwKHZ < adwKHZ.Length ? adwKHZ[dwKHZ] : adwKHZ[0];
			pwfex.wBitsPerSample = 8;
			pwfex.nAvgBytesPerSec = pwfex.nSamplesPerSec * pwfex.nBlockAlign;
			pwfex.cbSize = 0;

			pFmtGuid = SPDFID_WaveFormatEx;
		}
		else if (eFormat is >= SPSTREAMFORMAT.SPSF_CCITT_uLaw_8kHzMono and <= SPSTREAMFORMAT.SPSF_CCITT_uLaw_44kHzStereo)
		{
			uint dwIndex = (uint)(eFormat - SPSTREAMFORMAT.SPSF_CCITT_uLaw_8kHzMono);
			uint dwKHZ = dwIndex / 2;
			uint[] adwKHZ = { 8000, 11025, 22050, 44100 };
			bool bIsStereo = (dwIndex & 0x1) != 0;

			pwfex.wFormatTag = WAVE_FORMAT.WAVE_FORMAT_MULAW;
			pwfex.nChannels = pwfex.nBlockAlign = (ushort)(bIsStereo ? 2 : 1);
			pwfex.nSamplesPerSec = (dwKHZ < adwKHZ.Length) ? adwKHZ[dwKHZ] : adwKHZ[0];
			pwfex.wBitsPerSample = 8;
			pwfex.nAvgBytesPerSec = pwfex.nSamplesPerSec * pwfex.nBlockAlign;
			pwfex.cbSize = 0;

			pFmtGuid = SPDFID_WaveFormatEx;
		}
		else if (eFormat is >= SPSTREAMFORMAT.SPSF_ADPCM_8kHzMono and <= SPSTREAMFORMAT.SPSF_ADPCM_44kHzStereo)
		{
			//--- Some of these values seem odd. We used what the codec told us.
			uint[] adwKHZ = { 8000, 11025, 22050, 44100 };
			uint[] BytesPerSec = { 4096, 8192, 5644, 11289, 11155, 22311, 22179, 44359 };
			uint[] BlockAlign = { 256, 256, 512, 1024 };
			byte[] Extra811 = {
				0xF4, 0x01, 0x07, 0x00, 0x00, 0x01, 0x00, 0x00,
				0x00, 0x02, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00,
				0xC0, 0x00, 0x40, 0x00, 0xF0, 0x00, 0x00, 0x00,
				0xCC, 0x01, 0x30, 0xFF, 0x88, 0x01, 0x18, 0xFF
			};
			byte[] Extra22 = {
				0xF4, 0x03, 0x07, 0x00, 0x00, 0x01, 0x00, 0x00,
				0x00, 0x02, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00,
				0xC0, 0x00, 0x40, 0x00, 0xF0, 0x00, 0x00, 0x00,
				0xCC, 0x01, 0x30, 0xFF, 0x88, 0x01, 0x18, 0xFF
			};
			byte[] Extra44 = {
				0xF4, 0x07, 0x07, 0x00, 0x00, 0x01, 0x00, 0x00,
				0x00, 0x02, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00,
				0xC0, 0x00, 0x40, 0x00, 0xF0, 0x00, 0x00, 0x00,
				0xCC, 0x01, 0x30, 0xFF, 0x88, 0x01, 0x18, 0xFF
			};
			byte[][] Extra = { Extra811, Extra811, Extra22, Extra44 };
			uint dwIndex = (uint)(eFormat - SPSTREAMFORMAT.SPSF_ADPCM_8kHzMono);
			uint dwKHZ = dwIndex / 2;
			bool bIsStereo = (dwIndex & 0x1) != 0;
			pwfex.wFormatTag = WAVE_FORMAT.WAVE_FORMAT_ADPCM;
			pwfex.nChannels = (ushort)(bIsStereo ? 2 : 1);
			pwfex.nSamplesPerSec = (dwKHZ < adwKHZ.Length) ? adwKHZ[dwKHZ] : adwKHZ[0];
			pwfex.nAvgBytesPerSec = (dwIndex < BytesPerSec.Length) ? BytesPerSec[dwIndex] : BytesPerSec[0];
			pwfex.nBlockAlign = (ushort)(((dwKHZ < BlockAlign.Length) ? BlockAlign[dwKHZ] : BlockAlign[0]) * pwfex.nChannels);
			pwfex.wBitsPerSample = 4;
			pwfex.cbSize = 32;

			pExtra = new byte[32];
			Array.Copy((dwKHZ < Extra.Length) ? Extra[dwKHZ] : Extra[0], pExtra, 32);

			pFmtGuid = SPDFID_WaveFormatEx;
		}
		else if (eFormat is >= SPSTREAMFORMAT.SPSF_GSM610_8kHzMono and <= SPSTREAMFORMAT.SPSF_GSM610_44kHzMono)
		{
			//--- Some of these values seem odd. We used what the codec told us.
			uint[] adwKHZ = { 8000, 11025, 22050, 44100 };
			uint[] BytesPerSec = { 1625, 2239, 4478, 8957 };
			uint dwIndex = (uint)(eFormat - SPSTREAMFORMAT.SPSF_GSM610_8kHzMono);
			pwfex.wFormatTag = WAVE_FORMAT.WAVE_FORMAT_GSM610;
			pwfex.nChannels = 1;
			pwfex.nSamplesPerSec = (dwIndex < adwKHZ.Length) ? adwKHZ[dwIndex] : adwKHZ[0];
			pwfex.nAvgBytesPerSec = BytesPerSec[dwIndex];
			pwfex.nBlockAlign = 65;
			pwfex.wBitsPerSample = 0;
			pwfex.cbSize = 2;

			pExtra = [0x40, 0x01];

			pFmtGuid = SPDFID_WaveFormatEx;
		}
		else
		{
			switch (eFormat)
			{
				case SPSTREAMFORMAT.SPSF_NoAssignedFormat:
					break;

				case SPSTREAMFORMAT.SPSF_Text:
					pFmtGuid = SPDFID_Text;
					break;

				default:
					hr = HRESULT.E_INVALIDARG;
					break;
			}
		}

		if (pwfex.nChannels > 0)
		{
			ppCoMemWaveFormatEx = pwfex;
			if (pExtra.Length > 0)
				ppCoMemWaveFormatEx.Append(pExtra);
		}
		pFormatId = pFmtGuid;
		return hr;
	}

	public static HRESULT SpCreateBestObject<T>(string pszCategoryId, string pszReqAttribs, string? pszOptAttribs, out T ppObject, object? pUnkOuter = default,
		CLSCTX dwClsCtxt = CLSCTX.CLSCTX_ALL) where T : class
	{
		ppObject = default!;
		var hr = SpFindBestToken(pszCategoryId, pszReqAttribs, pszOptAttribs, out var cpToken);
		if (hr.Succeeded)
			hr = SpCreateObjectFromToken(cpToken, out ppObject, pUnkOuter, dwClsCtxt);
		return hr;
	}

	public static HRESULT SpCreateDefaultObjectFromCategoryId<T>(string pszCategoryId, out T ppObject, object? pUnkOuter = default, CLSCTX dwClsCtxt = CLSCTX.CLSCTX_ALL) where T : class
	{
		ppObject = default!;
		HRESULT hr = SpGetDefaultTokenFromCategoryId(pszCategoryId, out var pToken);
		if (hr.Succeeded)
			hr = SpCreateObjectFromToken(pToken, out ppObject, pUnkOuter, dwClsCtxt);
		return hr;
	}

	public static HRESULT SpCreateNewToken(string pszTokenId, out ISpObjectToken ppToken) =>
		// Forcefully create the token
		SpGetTokenFromId(pszTokenId, out ppToken, true);

	public static HRESULT SpCreateNewToken(string pszCategoryId, string pszTokenKeyName, out ISpObjectToken ppToken)
	{
		ppToken = default!;

		// Forcefully create the category
		var hr = SpGetCategoryFromId(pszCategoryId, out var cpCategory, true);

		// Come up with a token key name if one wasn't specified
		if (hr.Succeeded)
			pszTokenKeyName ??= Guid.NewGuid().ToString("B");

		// Build the token id
		CSpDynamicString dstrTokenId = new();
		if (hr.Succeeded)
		{
			dstrTokenId = pszCategoryId;
			dstrTokenId.Append2("\\Tokens\\", pszTokenKeyName);
		}

		// Forcefully create the token
		if (hr.Succeeded)
			hr = SpGetTokenFromId(dstrTokenId!, out ppToken, true);

		return hr;
	}

	public static HRESULT SpCreateNewTokenEx(string pszCategoryId, string pszTokenKeyName, in Guid pclsid, string pszLangIndependentName, LANGID langid,
		string pszLangDependentName, out ISpObjectToken ppToken, out ISpDataKey ppDataKeyAttribs)
	{
		ppDataKeyAttribs = default!;

		// Create the new token
		var hr = SpCreateNewToken(pszCategoryId, pszTokenKeyName, out ppToken);

		// Now set the extra data
		if (hr.Succeeded)
			hr = SpSetCommonTokenData(ppToken, pclsid, pszLangIndependentName, langid, pszLangDependentName, out ppDataKeyAttribs);

		return hr;
	}

	public static HRESULT SpCreateNewTokenEx(string pszTokenId, in Guid pclsid, string pszLangIndependentName, LANGID langid, string pszLangDependentName,
		out ISpObjectToken ppToken, out ISpDataKey ppDataKeyAttribs)
	{
		ppDataKeyAttribs = default!;

		// Create the new token
		var hr = SpCreateNewToken(pszTokenId, out ppToken);
		if (hr.Succeeded)
		{
			HRESULT hr2 = SpIsRunningInAppContainer(out var isAppContainer).ToHRESULT();
			// only set the extra data when not running in app chamber, if we failed the call to check if in chamber default to old sapi behavior.
			if (hr2.Failed || !isAppContainer)
			{
				// Now set the extra data
				hr = SpSetCommonTokenData(ppToken, pclsid, pszLangIndependentName, langid, pszLangDependentName,
					out ppDataKeyAttribs);
			}
		}

		return hr;
	}

	public static HRESULT SpCreateObjectFromToken<T>(ISpObjectToken pToken, out T ppObject, object? pUnkOuter = default, CLSCTX dwClsCtxt = CLSCTX.CLSCTX_ALL) where T : class
	{
		var hr = pToken.CreateInstance(pUnkOuter, dwClsCtxt, typeof(T).GUID, out var ppv);
		ppObject = hr.Succeeded ? (T)ppv! : default!;
		return hr;
	}

	public static HRESULT SpCreateObjectFromTokenId<T>(string pszTokenId, out T ppObject, object? pUnkOuter = default, CLSCTX dwClsCtxt = CLSCTX.CLSCTX_ALL) where T : class
	{
		ppObject = default!;
		HRESULT hr = SpGetTokenFromId(pszTokenId, out var pToken);
		if (hr.Succeeded)
			hr = SpCreateObjectFromToken(pToken, out ppObject, pUnkOuter, dwClsCtxt);
		return hr;
	}

	public static HRESULT SpCreatePhoneConverter(LANGID LangID, string? pszReqAttribs, string? pszOptAttribs, out ISpPhoneConverter ppPhoneConverter)
	{
		HRESULT hr = (int)SPERR.SPERR_NOT_FOUND;
		ppPhoneConverter = default!;

		// If not IPA or UPS
		if (LangID != 0)
		{
			CSpDynamicString dstrReqAttribs = new();
			if (pszReqAttribs is not null)
			{
				dstrReqAttribs = pszReqAttribs;
				dstrReqAttribs.Append(";");
			}

			string szLang = SpHexFromUlong(LangID);
			string szLangCondition = $"Language={szLang}";

			dstrReqAttribs.Append(szLangCondition);

			hr = SpCreateBestObject(SPCAT_PHONECONVERTERS, dstrReqAttribs, pszOptAttribs, out ppPhoneConverter);
		}

		// If we cannot find a phone converter, use the Universal Phone Converter as default
		if (hr == (int)SPERR.SPERR_NOT_FOUND)
		{
			ppPhoneConverter = new();

			if (hr.Succeeded)
			{
				ISpPhoneticAlphabetSelection pAlphabetSelection = (ISpPhoneticAlphabetSelection)ppPhoneConverter;

				pAlphabetSelection.SetAlphabetToUPS(true);
			}
		}
		return hr;
	}

	public static HRESULT SpEnumTokens(string pszCategoryId, string? pszReqAttribs, string? pszOptAttribs, out IEnumSpObjectTokens ppEnum)
	{
		ppEnum = default!;

		var hr = SpGetCategoryFromId(pszCategoryId, out var cpCategory);
		if (hr.Succeeded)
			hr = cpCategory.EnumTokens(pszReqAttribs, pszOptAttribs, out ppEnum);

		return hr;
	}

	/****************************************************************************
	* SpEventSerializeSize *
	*----------------------*
	*   Description:
	*       Computes the required size of a buffer to serialize an event.  The caller
	*   must specify which type of serialized event is desired -- either SPSERIALIZEDEVENT
	*   or SPSERIALIZEDEVENT64.
	*
	*   Returns:
	*       Size in bytes required to seriailze the event.
	*
	****************************************************************************/
	public static int SpEventSerializeSize(in SPEVENT pEvent)
	{
		int ulSize = Marshal.SizeOf(typeof(SPEVENT));

		if (pEvent.elParamType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_POINTER && pEvent.lParam != default)
		{
			ulSize += pEvent.wParam.ToInt32();
		}
		else if (pEvent.elParamType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_STRING && pEvent.lParam != IntPtr.Zero)
		{
			// Would be better to check for overflow of string length.
			ulSize += StringHelper.GetString(pEvent.lParam, CharSet.Unicode).GetByteCount(true, CharSet.Unicode);
		}
		else if (pEvent.elParamType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_TOKEN)
		{
			if (((ISpObjectToken)Marshal.GetObjectForIUnknown(pEvent.lParam)).GetId(out var dstrObjectId) == HRESULT.S_OK)
			{
				ulSize += dstrObjectId.GetByteCount(true, CharSet.Unicode);
			}
			else
			{
				return 0;
			}
		}
		// Round up to nearest uint
		ulSize += 3;
		ulSize -= ulSize % 4;
		return ulSize;
	}

	public static HRESULT SpFindBestToken(string pszCategoryId, string pszReqAttribs, string? pszOptAttribs, out ISpObjectToken ppObjectToken)
	{
		ppObjectToken = default!;

		const string pszVendorPreferred = "VendorPreferred";
		uint ulLenVendorPreferred = (uint)pszVendorPreferred.Length;

		// append VendorPreferred to the end of pszOptAttribs to force this preference
		uint ulLen;
		if (pszOptAttribs is not null)
		{
			ulLen = (uint)pszOptAttribs.Length + ulLenVendorPreferred;
			ulLen += 1 + 1; // including 1 byte here for default terminator
		}
		else
		{
			ulLen = ulLenVendorPreferred + 1; // including 1 byte here for default terminator
		}

		string pszOptAttribsVendorPref = pszOptAttribs is not null ? $"{pszOptAttribs};{pszVendorPreferred}" : pszVendorPreferred;

		var hr = SpEnumTokens(pszCategoryId, pszReqAttribs, pszOptAttribsVendorPref, out var cpEnum);

		if (hr.Succeeded)
		{
			hr = cpEnum.Next(1, [ppObjectToken], out _);
			if (hr == HRESULT.S_FALSE)
			{
				ppObjectToken = default!;
				hr = (int)SPERR.SPERR_NOT_FOUND;
			}
		}

		return hr;
	}

	public static HRESULT SpGetCategoryFromId(string pszCategoryId, out ISpObjectTokenCategory ppCategory, bool fCreateIfNotExist = false)
	{
		ppCategory = new();
		return ppCategory.SetId(pszCategoryId, fCreateIfNotExist);
	}

	public static HRESULT SpGetDefaultTokenFromCategoryId(string pszCategoryId, out ISpObjectToken ppToken, bool fCreateCategoryIfNotExist = true)
	{
		ppToken = default!;
		var hr = SpGetCategoryFromId(pszCategoryId, out var cpCategory, fCreateCategoryIfNotExist);
		if (hr.Succeeded)
		{
			hr = cpCategory.GetDefaultTokenId(out var pszTokenId);
			if (hr.Succeeded)
			{
				hr = SpGetTokenFromId(pszTokenId, out ppToken);
			}
		}
		return hr;
	}

	public static HRESULT SpGetDefaultTokenIdFromCategoryId(string pszCategoryId, out string ppszTokenId)
	{
		ppszTokenId = default!;
		HRESULT hr = SpGetCategoryFromId(pszCategoryId, out var cpCategory);
		if (hr.Succeeded)
			hr = cpCategory.GetDefaultTokenId(out ppszTokenId);
		return hr;
	}

	public static HRESULT SpGetDescription([In] ISpObjectToken pObjToken, out string ppszDescription, LANGID? Language = null)
	{
		Language ??= SpGetUserDefaultUILanguage(); // Use the default UI language if not specified
		ppszDescription = "";
		if (pObjToken is null)
			return HRESULT.E_POINTER;

		// Windows Vista does not encourage localized strings in the registry When running on Windows Vista query the localized engine name
		// from a resource dll
		HRESULT hr = HRESULT.S_OK;
		var ver = OSVERSIONINFOEX.Default;
		if (GetVersionEx(ref ver) == true && ver.dwPlatformId == PlatformID.Win32NT && ver.dwMajorVersion >= 6)
		{
			hr = pObjToken.GetId(out var pszTemp);
			if (hr.Succeeded)
			{
				Win32Error lErrorCode = Win32Error.ERROR_SUCCESS;
				var idx = pszTemp.IndexOf('\\');
				if (idx >= 0)
				{
					var pRegKeyPath = pszTemp.Substring(idx + 1);
					pszTemp = pszTemp.Substring(0, idx);

					SafeRegistryHandle Handle = new(IntPtr.Zero, false);
					// Open the registry key for read and get the handle
					if (string.Equals(pszTemp, "HKEY_LOCAL_MACHINE", StringComparison.OrdinalIgnoreCase))
					{
						lErrorCode = RegOpenKeyEx(HKEY.HKEY_LOCAL_MACHINE, pRegKeyPath, 0, REGSAM.KEY_QUERY_VALUE, out Handle);
					}
					else if (string.Equals(pszTemp, "HKEY_CURRENT_USER", StringComparison.OrdinalIgnoreCase))
					{
						lErrorCode = RegOpenKeyEx(HKEY.HKEY_CURRENT_USER, pRegKeyPath, 0, REGSAM.KEY_QUERY_VALUE, out Handle);
					}
					else
					{
						lErrorCode = Win32Error.ERROR_BAD_ARGUMENTS;
					}

					// Use MUI RegLoadMUIStringW API to load the localized string
					if (Win32Error.ERROR_SUCCESS == lErrorCode)
					{
						StringBuilder desc = new(MAX_PATH); // This should be enough memory to allocate the localized Engine Name
						lErrorCode = RegLoadMUIString(Handle, SR_LOCALIZED_DESCRIPTION, desc, MAX_PATH * sizeof(char),
							out _, REG_MUI_STRING.REG_MUI_STRING_TRUNCATE, default);
						ppszDescription = desc.ToString();
					}
				}
				else
				{
					// pRegKeyPath should never be 0 if we are querying for relative hkey path
					lErrorCode = Win32Error.ERROR_BAD_ARGUMENTS;
				}

				hr = lErrorCode.ToHRESULT();
			}
		}
		else
		{
			hr = HRESULT.HRESULT_FROM_WIN32(Win32Error.ERROR_NOT_SUPPORTED);
		}

		Debug.Assert(hr.Failed || !string.IsNullOrEmpty(ppszDescription));

		// If running on OSes released before Windows Vista query the localized string from the registry If RegLoadMUIStringW failed to
		// retrieved the localized Engine name retrieve the localized string from the fallback (Default) attribute
		if (hr.Failed)
		{
			var szLangId = SpHexFromUlong((ushort)Language);
			hr = pObjToken.GetStringValue(szLangId, out ppszDescription);
			if (hr == (int)SPERR.SPERR_NOT_FOUND)
				hr = pObjToken.GetStringValue(default, out ppszDescription);
		}

		return hr;
	}

	public static HRESULT SpGetLanguageFromToken(ISpObjectToken pToken, out LANGID plangid)
	{
		plangid = default; // Default to LANGID_NULL
		var hr = pToken.OpenKey(SPTOKENKEY_ATTRIBUTES, out var cpDataKeyAttribs);

		string dstrLanguage = "";
		if (hr.Succeeded)
			hr = cpDataKeyAttribs.GetStringValue("Language", out dstrLanguage);

		if (hr.Succeeded)
		{
			// check if the langid is in the format "409;9" - extract the "409" in this case
			var match = System.Text.RegularExpressions.Regex.Match(dstrLanguage, @"([0-9A-Za-z]+)");
			string pszLangId = match.Success ? match.Groups[1].Value : dstrLanguage;
			if (SpULongFromHex(pszLangId, out var langid).Failed)
			{
				hr = (int)SPERR.SPERR_INVALID_TOKEN_ID;
			}
			else
			{
				plangid = (LANGID)langid;
			}
		}
		return hr;
	}

	public static HRESULT SpGetLanguageFromVoiceToken(ISpObjectToken pToken, out LANGID plangid) =>
		SpGetLanguageFromToken(pToken, out plangid);

	public static HRESULT SpGetTokenFromId(string pszTokenId, out ISpObjectToken ppToken, bool fCreateIfNotExist = false)
	{
		ppToken = new();
		return ppToken.SetId(default, pszTokenId, fCreateIfNotExist);
	}

	/****************************************************************************
	* SpGetUserDefaultUILanguage *
	*----------------------------*
	*   Description:
	*       Now that we only support XP & Above, this is a straight call to
	*       GetUserDefaultUILanguage
	*
	*   Returns:
	*       Default UI language
	*
	*****************************************************************************/
	public static LANGID SpGetUserDefaultUILanguage() => GetUserDefaultUILanguage();

	// Simple function converts a ulong to a hex string.
	public static string SpHexFromUlong(uint ul) => ul.ToString("X");

	/****************************************************************************
	* SpHrFromLastWin32Error *
	*------------------------*
	*   Description:
	*       This simple inline function is used to return a converted HRESULT
	*   from the Win32 function ::GetLastError.  Note that using HRESULT_FROM_WIN32
	*   will evaluate the error code twice so we don't want to use:
	*
	*       HRESULT_FROM_WIN32(::GetLastError())
	*
	*   since that will call GetLastError twice.
	*
	*   Returns:
	*       HRESULT for ::GetLastError(). If the HRESULT is a success code, this
	*       function will return E_FAIL to guarantee an error return code.
	*
	*****************************************************************************/
	public static HRESULT SpHrFromLastWin32Error()
	{
		var hr = Win32Error.GetLastError().ToHRESULT();
		return hr.Failed ? hr : HRESULT.E_FAIL;
	}

	/****************************************************************************
	* SpHrFromWin32 *
	*---------------*
	*   Description:
	*       This inline function works around a basic problem with the macro
	*   HRESULT_FROM_WIN32.  The macro forces the expresion in ( ) to be evaluated
	*   two times.  By using this inline function, the expression will only be
	*   evaluated once.
	*
	*   Returns:
	*       HRESULT of converted Win32 error code
	*
	*****************************************************************************/
	public static HRESULT SpHrFromWin32(Win32Error dwErr) => dwErr.ToHRESULT();

	/****************************************************************************
	* SpInitEvent *
	*-------------*
	*   Description:
	*
	*   Returns:
	*
	*****************************************************************************/
	public static void SpInitEvent(ref SPEVENT pe) => pe = new();

	public static Win32Error SpIsRunningInAppContainer([Out] out bool IsAppContainer)
	{
		// The logic for this function is as follows: Attempt to open the thread token, if that fails then open the process token. Query the
		// token for TokenIsAppContainer, if that succeeds then determine if the value returned indicated that this is an AppContainer.
		//
		// All failure paths will result in IsAppContainer being false and return an appropriate error code.

		IsAppContainer = false;

		// First try to open the thread token (if we're impersonating).

		if (!OpenThreadToken(GetCurrentThread(), TokenAccess.TOKEN_QUERY,
			true, //Needs to be true if the token has only the SecurityIdentify impersonation level, see http://msdn.microsoft.com/en-us/library/aa379296(VS.85).aspx
			out var EffectiveToken))
		{
			// If the token is anonymous or there is a error other than Win32Error.ERROR_NO_TOKEN, then fail here as we can't determine the caller.

			var Error = GetLastError();
			if (Error != Win32Error.ERROR_NO_TOKEN)
				return Error;

			// Since we could not open the thread token (not impersonating), attempt to open the process token.

			if (!OpenProcessToken(GetCurrentProcess(), TokenAccess.TOKEN_QUERY, out EffectiveToken))
				return GetLastError();
		}

		// Query the token to determine if this is an AppContainer.

		try
		{
			uint AppContainer = GetTokenInformation<uint>(EffectiveToken, TOKEN_INFORMATION_CLASS.TokenIsAppContainer);
			IsAppContainer = AppContainer != 0;
			return Win32Error.ERROR_SUCCESS;
		}
		catch (Exception e)
		{
			IsAppContainer = false;
			return Win32Error.FromException(e);
		}
	}

	/****************************************************************************
	* SpSerializedEventSize *
	*-----------------------*
	*   Description:
	*       Returns the size, in bytes, used by a serialized event.  The caller can
	*   pass a pointer to either a SPSERIAILZEDEVENT or SPSERIALIZEDEVENT64 structure.
	*
	*   Returns:
	*       Number of bytes used by serizlied event
	*
	*****************************************************************************/
	public static int SpSerializedEventSize(in SPEVENT pSerEvent) => SpEventSerializeSize(pSerEvent);

	/*++
	Routine Description:
	This routine determines if the currently executing context is running as an
	AppContainer.

	Arguments:
	[Out] IsAppContainer - Set to true if this is an AppContainer, false
	otherwise.

	Return Value:
	Win32Error.ERROR_SUCCESS or an appropriate error code.
	--*/

	public static HRESULT SpSetCommonTokenData(ISpObjectToken pToken, in Guid pclsid, string pszLangIndependentName, LANGID langid,
		string pszLangDependentName, out ISpDataKey ppDataKeyAttribs)
	{
		ppDataKeyAttribs = default!;

		// Set the new token's Guid (if specified)
		var hr = pToken.SetStringValue(SPTOKENVALUE_CLSID, pclsid.ToString("B"));

		// Set the token's lang independent name
		if (hr.Succeeded && !string.IsNullOrEmpty(pszLangIndependentName))
			hr = pToken.SetStringValue(default, pszLangIndependentName);

		// Set the token's lang dependent name
		if (hr.Succeeded && !string.IsNullOrEmpty(pszLangDependentName))
			hr = pToken.SetStringValue($"{(ushort)langid:X}", pszLangDependentName);

		// Open the attributes key if requested
		if (hr.Succeeded)
			hr = pToken.CreateKey("Attributes", out ppDataKeyAttribs);

		return hr;
	}

	public static HRESULT SpSetDefaultTokenForCategoryId(string pszCategoryId, ISpObjectToken pToken)
	{
		var hr = pToken.GetId(out var pszTokenId);
		if (hr.Succeeded)
			hr = SpSetDefaultTokenIdForCategoryId(pszCategoryId, pszTokenId);
		return hr;
	}

	//=== Token helpers
	public static HRESULT SpSetDefaultTokenIdForCategoryId(string pszCategoryId, string pszTokenId)
	{
		var hr = SpGetCategoryFromId(pszCategoryId, out var cpCategory);
		if (hr.Succeeded)
			hr = cpCategory.SetDefaultTokenId(pszTokenId);
		return hr;
	}

	public static HRESULT SpSetDescription(ISpObjectToken pObjToken, string pszDescription, LANGID? Language = null, bool fSetLangIndependentId = true)
	{
		Language ??= SpGetUserDefaultUILanguage(); // Use the default UI language if not specified
		string szLangId = SpHexFromUlong((ushort)Language);
		HRESULT hr = pObjToken.SetStringValue(szLangId, pszDescription);
		if (hr.Succeeded && fSetLangIndependentId)
			hr = pObjToken.SetStringValue(default, pszDescription);
		return hr;
	}

	public static HRESULT SpULongFromHex(string psz, out uint pResult) => uint.TryParse(psz, System.Globalization.NumberStyles.HexNumber, null, out pResult) ? HRESULT.S_OK : HRESULT.E_FAIL;
}