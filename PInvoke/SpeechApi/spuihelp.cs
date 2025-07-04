using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

public static partial class SpeechApi
{
	private const int CB_ERR = (int)ListBoxReturnValue.LB_ERR;
	private const int CB_ERRSPACE = (int)ListBoxReturnValue.LB_ERRSPACE;

	public static HRESULT SpAddTokenToComboBox(HWND hwnd, ISpObjectToken pToken) => SpAddTokenToList(ComboBoxMessage.CB_ADDSTRING, ComboBoxMessage.CB_SETITEMDATA, ComboBoxMessage.CB_SETCURSEL, hwnd, pToken);

	public static HRESULT SpAddTokenToList<T>(T MsgAddString, T MsgSetItemData, T MsgSetCurSel, HWND hwnd, ISpObjectToken pToken) where T : struct, IConvertible
	{
		HRESULT hr = SpGetDescription(pToken, out var dstrDesc);
		if (hr.Succeeded)
		{
			IntPtr i = SendMessage(hwnd, MsgAddString, 0, dstrDesc);
			if (i.ToInt32() is CB_ERR or CB_ERRSPACE) // Note: ComboBoxMessage.CB_ and ListBoxMessage.LB_ errors are identical values...
			{
				hr = HRESULT.E_OUTOFMEMORY;
			}
			else
			{
				SendMessage(hwnd, MsgSetItemData, i, Marshal.GetIUnknownForObject(pToken));

				SendMessage(hwnd, MsgSetCurSel, i, 0);
			}
		}
		return hr;
	}

	public static HRESULT SpAddTokenToListBox(HWND hwnd, ISpObjectToken pToken) => SpAddTokenToList(ListBoxMessage.LB_ADDSTRING, ListBoxMessage.LB_SETITEMDATA, ListBoxMessage.LB_SETCURSEL, hwnd, pToken);

	public static HRESULT SpDeleteCurSelComboBoxToken(HWND hwnd) => SpDeleteCurSelToken(ComboBoxMessage.CB_GETCURSEL, ComboBoxMessage.CB_SETCURSEL, ComboBoxMessage.CB_GETITEMDATA, ComboBoxMessage.CB_DELETESTRING, hwnd);

	public static HRESULT SpDeleteCurSelListBoxToken(HWND hwnd) => SpDeleteCurSelToken(ListBoxMessage.LB_GETCURSEL, ListBoxMessage.LB_SETCURSEL, ListBoxMessage.LB_GETITEMDATA, ListBoxMessage.LB_DELETESTRING, hwnd);

	public static HRESULT SpDeleteCurSelToken<T>(T MsgGetCurSel, T MsgSetCurSel, T MsgGetItemData, T MsgDeleteString, HWND hwnd) where T : struct, IConvertible
	{
		HRESULT hr = HRESULT.S_OK;
		IntPtr i = SendMessage(hwnd, MsgGetCurSel);
		if (i.ToInt32() == CB_ERR)
		{
			hr = HRESULT.S_FALSE;
		}
		else
		{
			ISpObjectToken pToken = (ISpObjectToken)Marshal.GetObjectForIUnknown(SendMessage(hwnd, MsgGetItemData, i, 0));
			if (pToken is not null)
			{
				pToken = null!;
			}

			SendMessage(hwnd, MsgDeleteString, i, 0);

			SendMessage(hwnd, MsgSetCurSel, i, 0);
		}
		return hr;
	}

	public static void SpDestroyTokenComboBox(HWND hwnd) => SpDestroyTokenList(ComboBoxMessage.CB_GETCOUNT, ComboBoxMessage.CB_GETITEMDATA, hwnd);

	public static void SpDestroyTokenListBox(HWND hwnd) => SpDestroyTokenList(ListBoxMessage.LB_GETCOUNT, ListBoxMessage.LB_GETITEMDATA, hwnd);

	public static ISpObjectToken SpGetComboBoxToken(HWND hwnd, IntPtr Index) => (ISpObjectToken)Marshal.GetObjectForIUnknown(SendMessage(hwnd, ComboBoxMessage.CB_GETITEMDATA, Index));

	public static ISpObjectToken? SpGetCurSelComboBoxToken(HWND hwnd)
	{
		IntPtr i = SendMessage(hwnd, ComboBoxMessage.CB_GETCURSEL);
		return (i.ToInt32() == CB_ERR) ? default : SpGetComboBoxToken(hwnd, i);
	}

	public static ISpObjectToken? SpGetCurSelListBoxToken(HWND hwnd)
	{
		IntPtr i = SendMessage(hwnd, ListBoxMessage.LB_GETCURSEL);
		return (i.ToInt32() == CB_ERR) ? default : SpGetListBoxToken(hwnd, i);
	}

	public static ISpObjectToken SpGetListBoxToken(HWND hwnd, IntPtr Index) => (ISpObjectToken)Marshal.GetObjectForIUnknown(SendMessage(hwnd, ListBoxMessage.LB_GETITEMDATA, Index));

	public static HRESULT SpInitTokenComboBox(HWND hwnd, string pszCatName, string? pszRequiredAttrib = default, string? pszOptionalAttrib = default) => SpInitTokenList(ComboBoxMessage.CB_ADDSTRING, ComboBoxMessage.CB_SETITEMDATA, ComboBoxMessage.CB_SETCURSEL, hwnd, pszCatName, pszRequiredAttrib, pszOptionalAttrib);

	public static HRESULT SpInitTokenListBox(HWND hwnd, string pszCatName, string? pszRequiredAttrib = default, string? pszOptionalAttrib = default) => SpInitTokenList(ListBoxMessage.LB_ADDSTRING, ListBoxMessage.LB_SETITEMDATA, ListBoxMessage.LB_SETCURSEL, hwnd, pszCatName, pszRequiredAttrib, pszOptionalAttrib);

	public static HRESULT SpUpdateCurSelComboBoxToken(HWND hwnd) => SpUpdateCurSelToken(ComboBoxMessage.CB_DELETESTRING, ComboBoxMessage.CB_INSERTSTRING, ComboBoxMessage.CB_GETITEMDATA, ComboBoxMessage.CB_SETITEMDATA, ComboBoxMessage.CB_GETCURSEL, ComboBoxMessage.CB_SETCURSEL, hwnd);

	public static HRESULT SpUpdateCurSelListBoxToken(HWND hwnd) => SpUpdateCurSelToken(ListBoxMessage.LB_DELETESTRING, ListBoxMessage.LB_INSERTSTRING, ListBoxMessage.LB_GETITEMDATA, ListBoxMessage.LB_SETITEMDATA, ListBoxMessage.LB_GETCURSEL, ListBoxMessage.LB_SETCURSEL, hwnd);

	private static void SpDestroyTokenList<T>(T MsgGetCount, T MsgGetItemData, HWND hwnd) where T : struct, IConvertible
	{
		int c = SendMessage(hwnd, MsgGetCount).ToInt32();
		for (int i = 0; i < c; i++)
		{
			object pUnkObj = Marshal.GetObjectForIUnknown(SendMessage(hwnd, MsgGetItemData, i));
			if (pUnkObj is not null)
				Marshal.ReleaseComObject(pUnkObj);
		}
	}

	private static HRESULT SpInitTokenList<T>(T MsgAddString, T MsgSetItemData, T MsgSetCurSel, HWND hwnd, string pszCatName, string? pszRequiredAttrib, string? pszOptionalAttrib) where T : struct, IConvertible
	{
		var hr = SpEnumTokens(pszCatName, pszRequiredAttrib, pszOptionalAttrib, out var cpEnum);
		if (hr == HRESULT.S_OK)
		{
			ISpObjectToken[] pToken = new ISpObjectToken[1]; // NOTE: Not a CComPtr! Be Careful.
			bool fSetDefault = false;
			while (cpEnum.Next(1, pToken, out _) == HRESULT.S_OK)
			{
				hr = SpGetDescription(pToken[0], out var dstrDesc);
				if (hr.Succeeded)
				{
					IntPtr i = SendMessage(hwnd, MsgAddString, 0, dstrDesc);
					if (i.ToInt32() is CB_ERR or CB_ERRSPACE) // Note: ComboBoxMessage.CB_ and ListBoxMessage.LB_ errors are identical values...
					{
						hr = HRESULT.E_OUTOFMEMORY;
					}
					else
					{
						SendMessage(hwnd, MsgSetItemData, i, Marshal.GetIUnknownForObject(pToken[0]));
						if (!fSetDefault)
						{
							SendMessage(hwnd, MsgSetCurSel, i, 0);
							fSetDefault = true;
						}
					}
				}
				if (hr.Failed)
				{
					pToken[0] = null!;
				}
			}
		}
		else
		{
			hr = (HRESULT)(int)SPERR.SPERR_NO_MORE_ITEMS;
		}
		return hr;
	}

	private static HRESULT SpUpdateCurSelToken<T>(T MsgDelString, T MsgInsertString, T MsgGetItemData, T MsgSetItemData, T MsgGetCurSel, T MsgSetCurSel, HWND hwnd) where T : struct, IConvertible
	{
		HRESULT hr = HRESULT.S_OK;
		IntPtr i = SendMessage(hwnd, MsgGetCurSel);
		if (i.ToInt32() != CB_ERR)
		{
			ISpObjectToken pToken = (ISpObjectToken)Marshal.GetObjectForIUnknown(SendMessage(hwnd, MsgGetItemData, i, 0));
			hr = SpGetDescription(pToken, out var dstrDesc);
			if (hr.Succeeded)
			{
				SendMessage(hwnd, MsgDelString, i, 0);

				SendMessage(hwnd, MsgInsertString, i, dstrDesc);

				SendMessage(hwnd, MsgSetItemData, i, Marshal.GetIUnknownForObject(pToken));

				SendMessage(hwnd, MsgSetCurSel, i, 0);
			}
		}
		return hr;
	}
}