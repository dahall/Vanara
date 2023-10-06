using Microsoft.Win32.SafeHandles;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class WinRegTests
{
	private const string regKey = "Software";

	private const string tmpRegKey = "____TmpRegKey____";

	[Test]
	public void InitAndAbortSystemShutdownTest()
	{
		using (new ElevPriv("SeShutdownPrivilege"))
		{
			Assert.That(InitiateShutdown(null, "InitiateShutdown test", 60, ShutdownFlags.SHUTDOWN_RESTART | ShutdownFlags.SHUTDOWN_HYBRID,
				SystemShutDownReason.SHTDN_REASON_MAJOR_APPLICATION | SystemShutDownReason.SHTDN_REASON_MINOR_MAINTENANCE |
				SystemShutDownReason.SHTDN_REASON_FLAG_PLANNED), ResultIs.Successful);
			Thread.Sleep(1000);
			Assert.That(AbortSystemShutdown(null), ResultIs.Successful);
		}
	}

	[Test]
	public void InitiateSystemShutdownExTest()
	{
		using (new ElevPriv("SeShutdownPrivilege"))
		{
			Assert.That(InitiateSystemShutdownEx(null, "InitiateSystemShutdownEx test", 60, false, true,
			SystemShutDownReason.SHTDN_REASON_MAJOR_APPLICATION | SystemShutDownReason.SHTDN_REASON_MINOR_MAINTENANCE |
			SystemShutDownReason.SHTDN_REASON_FLAG_PLANNED), ResultIs.Successful);
			Thread.Sleep(1000);
			Assert.That(AbortSystemShutdown(null), ResultIs.Successful);
		}
	}

	[Test]
	public void RegConnectRegistryTest()
	{
		Assert.That(RegConnectRegistry(null, HKEY.HKEY_USERS, out var hReg), ResultIs.Successful);
		hReg.Dispose();
	}

	[Test]
	public void RegCopyDeleteTreeTest()
	{
		var path = $"{regKey}\\{tmpRegKey}";
		Assert.That(CreateTree(path, out var hKey), ResultIs.Successful);
		hKey.Dispose();
		try
		{
			Assert.That(RegOpenKeyEx(HKEY.HKEY_CURRENT_USER, regKey, 0, REGSAM.KEY_ALL_ACCESS, out hKey), ResultIs.Successful);
			using (hKey)
			{
				Assert.That(RegCreateKey(HKEY.HKEY_CURRENT_USER, path + "2", out var hKey2), ResultIs.Successful);
				using (hKey2)
				{
					Assert.That(RegCopyTree(hKey, tmpRegKey, hKey2), ResultIs.Successful);
				}
				Assert.That(RegDeleteTree(hKey, tmpRegKey + "2"), ResultIs.Successful);
			}
		}
		finally
		{
			Assert.That(RegDeleteKeyEx(HKEY.HKEY_CURRENT_USER, path), ResultIs.Successful);
		}
	}

	[Test]
	public void RegCreateDeleteOpenKeyExTest()
	{
		const string regKey = "Software";
		Assert.That(RegOpenKeyEx(HKEY.HKEY_CURRENT_USER, regKey, RegOpenOptions.REG_OPTION_NON_VOLATILE, REGSAM.KEY_ALL_ACCESS,
			out var hPKey), ResultIs.Successful);
		using (hPKey)
		{
			Assert.That(RegCreateKeyEx(hPKey, tmpRegKey, samDesired: REGSAM.KEY_ALL_ACCESS, phkResult: out var hKey, lpdwDisposition: out _), ResultIs.Successful);
			try
			{
				using (hKey)
				{
					using (var pSD = new SafePSECURITY_DESCRIPTOR(256))
					{
						Assert.That(SetSecurityDescriptorOwner(pSD, SafePSID.Current, false), ResultIs.Successful);
						Assert.That(RegSetKeySecurity(hKey, SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION, pSD), ResultIs.Successful);
						using var pSD2 = new SafePSECURITY_DESCRIPTOR(256);
						var sdsz = (uint)pSD2.Size;
						Assert.That(RegGetKeySecurity(hKey, SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION, pSD2, ref sdsz), ResultIs.Successful);
					}

					using var mem = new SafeHGlobalHandle(1024);
					var memSz = (uint)mem.Size;
					const int val = 255;
					ulong ulongVal = val;
					var byteVal = BitConverter.GetBytes((uint)val);
					var strVal = val.ToString();

					Assert.That(RegSetKeyValue(hPKey, tmpRegKey, "V1", REG_VALUE_TYPE.REG_QWORD, new PinnedObject(ulongVal), 8), ResultIs.Successful);
					Assert.That(RegGetValue(hPKey, tmpRegKey, "V1", RRF.RRF_RT_QWORD, out _, mem, ref memSz), ResultIs.Successful);
					Assert.That(mem.ToStructure<ulong>(), Is.EqualTo(ulongVal));

					Assert.That(RegSetKeyValue(hPKey, tmpRegKey, "V2", REG_VALUE_TYPE.REG_DWORD, byteVal, (uint)byteVal.Length), ResultIs.Successful);
					memSz = mem.Size;
					Assert.That(RegGetValue(hPKey, tmpRegKey, "V2", RRF.RRF_RT_DWORD, out _, mem, ref memSz), ResultIs.Successful);
					Assert.That(mem.ToStructure<uint>(), Is.EqualTo((uint)val));

					Assert.That(RegSetKeyValue(hPKey, tmpRegKey, "V3", REG_VALUE_TYPE.REG_SZ, strVal, (uint)StringHelper.GetByteCount(strVal)), ResultIs.Successful);
					memSz = mem.Size;
					Assert.That(RegGetValue(hPKey, tmpRegKey, "V3", RRF.RRF_RT_REG_SZ, out _, mem, ref memSz), ResultIs.Successful);
					Assert.That(mem.ToString(-1, CharSet.Auto), Is.EqualTo(strVal));

					memSz = mem.Size;
					Assert.That(RegQueryMultipleValues(hKey, new[] { new VALENT("V1"), new VALENT("V2"), new VALENT("V3") }, 3, mem, ref memSz), ResultIs.Successful);

					Assert.That(RegDeleteKeyValue(hPKey, tmpRegKey, "V1"), ResultIs.Successful);
					Assert.That(RegDeleteKeyValue(hPKey, tmpRegKey, "V2"), ResultIs.Successful);
					Assert.That(RegDeleteKeyValue(hPKey, tmpRegKey, "V3"), ResultIs.Successful);

					Assert.That(RegSetValue(hKey, null, REG_VALUE_TYPE.REG_SZ, strVal), ResultIs.Successful);
					var imemSz = (int)mem.Size;
					Assert.That(RegQueryValue(hKey, null, mem, ref imemSz), ResultIs.Successful);
					Assert.That(mem.ToString(-1, CharSet.Auto), Is.EqualTo(strVal));
					Assert.That(RegDeleteValue(hKey, null), ResultIs.Successful);

					Assert.That(RegSetValueEx(hKey, "V1", 0, REG_VALUE_TYPE.REG_QWORD, new PinnedObject(ulongVal), 8), ResultIs.Successful);
					memSz = mem.Size;
					Assert.That(RegQueryValueEx(hKey, "V1", default, out _, mem, ref memSz), ResultIs.Successful);
					Assert.That(mem.ToStructure<ulong>(), Is.EqualTo(ulongVal));
					Assert.That(RegDeleteValue(hKey, "V1"), ResultIs.Successful);

					Assert.That(RegSetValueEx(hKey, "V2", 0, REG_VALUE_TYPE.REG_DWORD, byteVal, (uint)byteVal.Length), ResultIs.Successful);
					memSz = mem.Size;
					Assert.That((uint)RegQueryValueEx(hKey, "V2")!, Is.EqualTo((uint)val));
					Assert.That(RegDeleteValue(hKey, "V2"), ResultIs.Successful);

					Assert.That(RegSetValueEx(hKey, "V3", 0, REG_VALUE_TYPE.REG_SZ, strVal, (uint)StringHelper.GetByteCount(strVal)), ResultIs.Successful);
					memSz = mem.Size;
					Assert.That((string)RegQueryValueEx(hKey, "V3")!, Is.EqualTo(strVal));
					Assert.That(RegDeleteValue(hKey, "V3"), ResultIs.Successful);
				}
			}
			finally
			{
				Assert.That(RegDeleteKeyEx(hPKey, tmpRegKey), ResultIs.Successful);
			}
		}
	}

	[Test]
	public void RegCreateKeyTransactedTest()
	{
		HTRXN hTrxn;
		Assert.That(hTrxn = CreateTransaction(CreateOptions: 0, Timeout: INFINITE), ResultIs.ValidHandle);
		try
		{
			Assert.That(RegOpenKeyTransacted(HKEY.HKEY_CURRENT_USER, regKey, 0, REGSAM.KEY_NOTIFY, out var hk, hTrxn), ResultIs.Successful);
			using (hk)
			{
				Assert.That(RegCreateKeyTransacted(hk, tmpRegKey, phkResult: out var hTmpKey, lpdwDisposition: out _, hTransaction: hTrxn), ResultIs.Successful);
				hTmpKey.Dispose();
				Assert.That(RegDeleteKeyTransacted(hk, tmpRegKey, hTransaction: hTrxn), ResultIs.Successful);
			}
		}
		finally
		{
			CloseHandle((IntPtr)hTrxn);
		}
	}

	[Test]
	public void RegDisablePredefinedCacheTest()
	{
		Assert.That(RegDisablePredefinedCache(), ResultIs.Successful);
		Assert.That(RegDisablePredefinedCacheEx(), ResultIs.Successful);
	}

	[Test]
	public void RegEnableReflectionKeyTest()
	{
		var path = $"{regKey}\\{tmpRegKey}";
		Assert.That(CreateTree(path, out var hKey), ResultIs.Successful);
		try
		{
			using (hKey)
			{
				Assert.That(RegEnableReflectionKey(hKey), ResultIs.Successful);
				Assert.That(RegQueryReflectionKey(hKey, out var dis), ResultIs.Successful);
				Assert.That(dis, Is.True);
				Assert.That(RegDisableReflectionKey(hKey), ResultIs.Successful);
			}
		}
		finally
		{
			Assert.That(RegDeleteKeyEx(HKEY.HKEY_CURRENT_USER, path), ResultIs.Successful);
		}
	}

	[Test]
	public void RegEnumKeyExTest()
	{
		Assert.That(RegOpenKeyEx(HKEY.HKEY_CURRENT_USER, "Software\\Microsoft", 0, REGSAM.KEY_ALL_ACCESS, out var hKey), ResultIs.Successful);
		using (hKey)
		{
			var keyInfoList = RegEnumKeyEx(hKey).ToArray();
			unsafe
			{
				uint cSubKeys = 0;
				RegQueryInfoKey(hKey, lpcSubKeys: &cSubKeys);
				Assert.That((int)cSubKeys, Is.EqualTo(keyInfoList.Length));
			}
			Assert.That(keyInfoList, Is.Not.Empty);
			Assert.That(keyInfoList[0].name, Is.Not.Null);
			Assert.That(keyInfoList[0].@class, Is.Not.Null);
			Assert.That(keyInfoList[0].lastWrite.dwLowDateTime, Is.Not.Zero);
			keyInfoList.WriteValues();
		}
	}

	[Test]
	public void RegEnumValueTest()
	{
		Assert.That(RegOpenKeyEx(HKEY.HKEY_CURRENT_USER, @"Software\Microsoft\OneDrive", 0, REGSAM.KEY_ALL_ACCESS, out var hKey), ResultIs.Successful);
		using (hKey)
		{
			uint cVals = 0;
			unsafe
			{
				RegQueryInfoKey(hKey, lpcValues: &cVals);
			}

			var valueList = RegEnumValue(hKey).ToArray();
			Assert.That((int)cVals, Is.EqualTo(valueList.Length));
			Assert.That(valueList, Is.Not.Empty);
			Assert.That(valueList[0].valueName, Is.Not.Null);
			Assert.That(valueList[0].data, Is.Null);

			valueList = RegEnumValue(hKey, true).ToArray();
			Assert.That((int)cVals, Is.EqualTo(valueList.Length));
			Assert.That(valueList, Is.Not.Empty);
			Assert.That(valueList[cVals - 1].valueName, Is.Not.Null);
			Assert.That(valueList[cVals - 1].data, Is.Not.Null);

			valueList.WriteValues();
		}
	}

	[Test]
	public void RegLoadAppKeyTest()
	{
		using var tmp = new TempFile(null);
		Assert.That(RegLoadAppKey(tmp.FullName, out var hKey, REGSAM.KEY_READ | REGSAM.KEY_WRITE), ResultIs.Successful);
		hKey.Dispose();
	}

	[Test]
	public void RegLoadMUIStringTest()
	{
		const string path = @"SYSTEM\CurrentControlSet\Services\WinSock2\Parameters\Protocol_Catalog9\Catalog_Entries\000000000002";
		Assert.That(RegOpenKey(HKEY.HKEY_LOCAL_MACHINE, path, out var hKey), ResultIs.Successful);
		using (hKey)
		{
			var sz = 1024U;
			var sb = new StringBuilder((int)sz);
			Assert.That(RegLoadMUIString(hKey, "ProtocolName", sb, sz, out sz, 0), ResultIs.Successful);
			TestContext.Write(sb);
		}
	}

	[Test]
	public void RegLoadUnloadKeyTest()
	{
		using (new ElevPriv(new[] { "SeBackupPrivilege", "SeRestorePrivilege" }))
		using (var tmp = new TempFile(null))
		{
			Assert.That(RegLoadKey(HKEY.HKEY_USERS, tmpRegKey, tmp.FullName), ResultIs.Successful);
			Assert.That(RegUnLoadKey(HKEY.HKEY_USERS, tmpRegKey), ResultIs.Successful);
		}
	}

	[Test]
	public void RegNotifyChangeKeyValueTest()
	{
		Assert.That(RegOpenKeyEx(HKEY.HKEY_CURRENT_USER, "Software", RegOpenOptions.REG_OPTION_NON_VOLATILE, REGSAM.KEY_NOTIFY,
			out var h), ResultIs.Successful);
		using (h)
		{
			var hEvent = CreateEvent(null, true, false);
			Assert.That(RegNotifyChangeKeyValue(h, false, RegNotifyChangeFilter.REG_NOTIFY_CHANGE_NAME, hEvent, true), ResultIs.Successful);
			new Thread(o =>
			{
				Thread.Sleep(100);
				if (RegCreateKey((HKEY)o, tmpRegKey, out var hTmpKey).Succeeded)
				{
					hTmpKey.Dispose();
					RegDeleteKey((HKEY)o, tmpRegKey);
				}
			}).Start((HKEY)h);
			Assert.That(WaitForSingleObject(hEvent, 5000), ResultIs.Value(WAIT_STATUS.WAIT_OBJECT_0));
		}
	}

	[Test]
	public void RegOpenCurrentUserTest()
	{
		Assert.That(RegOpenCurrentUser(REGSAM.KEY_QUERY_VALUE | REGSAM.KEY_READ, out var hKey), ResultIs.Successful);
		hKey.Dispose();
	}

	[Test]
	public void RegOpenUserClassesRootTest()
	{
		using var hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_QUERY);
		Assert.That(RegOpenUserClassesRoot(hTok, 0, REGSAM.KEY_READ, out var hReg), ResultIs.Successful);
		hReg.Dispose();
	}

	[Test]
	public void RegOverridePredefKeyTest()
	{
		var path = $"{regKey}\\{tmpRegKey}";
		Assert.That(RegCreateKeyEx(HKEY.HKEY_CURRENT_USER, path, samDesired: REGSAM.KEY_ALL_ACCESS, phkResult: out var hKey, lpdwDisposition: out _), ResultIs.Successful);
		try
		{
			using (hKey)
				Assert.That(RegOverridePredefKey(HKEY.HKEY_CLASSES_ROOT, hKey), ResultIs.Successful);
			Assert.That(RegOverridePredefKey(HKEY.HKEY_CLASSES_ROOT, HKEY.NULL), ResultIs.Successful);
		}
		finally
		{
			Assert.That(RegDeleteKeyEx(HKEY.HKEY_CURRENT_USER, path), ResultIs.Successful);
		}
	}

	[Test]
	public unsafe void RegQueryInfoKeyTest()
	{
		var path = $"{regKey}\\{tmpRegKey}";
		Assert.That(RegCreateKeyEx(HKEY.HKEY_CURRENT_USER, path, 0, "MyClass", 0, REGSAM.KEY_READ | REGSAM.KEY_QUERY_VALUE, null, out var hKey, out _), ResultIs.Successful);
		try
		{
			var sz = 1024U;
			var sb = new StringBuilder((int)sz);
			using (hKey)
			{
				Assert.That(RegQueryInfoKey(hKey, sb, ref sz, default, out var subKeys, out var maxSubKeyLen, out var maxClsLen, out var vals, out var maxValNameLen, out var maxValLen, out var szSD, out var ft), ResultIs.Successful);
				uint maxValNameLen2 = 0;
				Assert.That(RegQueryInfoKey(hKey, lpcbMaxValueNameLen: &maxValNameLen2), ResultIs.Successful);
				Assert.That(maxValNameLen, Is.EqualTo(maxValNameLen2));
				TestContext.Write($"{sb}, {subKeys}, {maxSubKeyLen}, {maxClsLen}, {vals}, {maxValNameLen}, {maxValLen}, {szSD}, {ft.ToDateTime()}");
			}
		}
		finally
		{
			Assert.That(RegDeleteKeyEx(HKEY.HKEY_CURRENT_USER, path), ResultIs.Successful);
		}
	}

	[Test]
	public void RegQueryMultipleValuesTest()
	{
		Assert.That(RegOpenKeyEx(HKEY.HKEY_CURRENT_USER, @"Software\Microsoft\OneDrive", 0, REGSAM.KEY_READ | REGSAM.KEY_QUERY_VALUE, out var hKey), ResultIs.Successful);
		using (hKey)
		{
			var values = RegEnumValue(hKey).Where((x, i) => i % 4 == 0).Select(v => v.valueName).ToArray();
			IReadOnlyDictionary<string, object?>? results = null;
			Assert.That(() => results = RegQueryMultipleValues(hKey, values), Throws.Nothing);
			Assert.That(results!, Has.Count.EqualTo(values.Length));
			results.WriteValues();
		}
	}

	[Test]
	public void RegReplaceKeyTest()
	{
		var path = $"{regKey}\\{tmpRegKey}";
		using (new ElevPriv(new[] { "SeBackupPrivilege", "SeRestorePrivilege" }))
		{
			Assert.That(CreateTree(path, out var hKey), ResultIs.Successful);
			try
			{
				using var tmp = new TempFile(null);
				using var tmp2 = new TempFile(null);
				using (hKey)
				{
					Assert.That(RegSaveKey(hKey, tmp.FullName, null), ResultIs.Successful);
					Assert.That(RegDeleteValue(hKey, "V3"), ResultIs.Successful);
					Assert.That(RegKeyHasValue(hKey, "V3"), Is.False);
					// TODO: This only returns ERROR_ACCESS_DENIED
					Assert.That(RegReplaceKey(hKey, null, tmp.FullName, tmp2.FullName), ResultIs.Successful);
					Assert.That(RegKeyHasValue(hKey, "V3"), Is.True);
				}
			}
			finally
			{
				Assert.That(RegDeleteKeyEx(HKEY.HKEY_CURRENT_USER, path), ResultIs.Successful);
			}
		}
	}

	[Test]
	public void RegSaveRestoreKeyTest()
	{
		var path = $"{regKey}\\{tmpRegKey}";
		using (new ElevPriv(new[] { "SeBackupPrivilege", "SeRestorePrivilege" }))
		{
			Assert.That(CreateTree(path, out var hKey), ResultIs.Successful);
			try
			{
				using (hKey)
				using (var tmp = new TempFile(null))
				{
					Assert.That(RegSaveKeyEx(hKey, tmp.FullName, null, REG_SAVE.REG_LATEST_FORMAT), ResultIs.Successful);
					Assert.That(RegDeleteTree(hKey), ResultIs.Successful);
					Assert.That(RegKeyIsEmpty(hKey), Is.True);
					Assert.That(RegRestoreKey(hKey, tmp.FullName, 0), ResultIs.Successful);
					Assert.That(RegKeyIsEmpty(hKey), Is.False);
				}
			}
			finally
			{
				Assert.That(RegDeleteKeyEx(HKEY.HKEY_CURRENT_USER, path), ResultIs.Successful);
			}
		}
	}

	/// <summary>Creates a new transaction object.</summary>
	/// <param name="lpTransactionAttributes">
	/// <para>
	/// A pointer to a SECURITY_ATTRIBUTES structure that determines whether the returned handle can be inherited by child processes. If
	/// this parameter is <c>NULL</c>, the handle cannot be inherited.
	/// </para>
	/// <para>
	/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new event. If
	/// lpTransactionAttributes is <c>NULL</c>, the object gets a default security descriptor. The access control lists (ACL) in the
	/// default security descriptor for a transaction come from the primary or impersonation token of the creator.
	/// </para>
	/// </param>
	/// <param name="UOW">Reserved. Must be zero (0).</param>
	/// <param name="CreateOptions">
	/// <para>Any optional transaction instructions.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TRANSACTION_DO_NOT_PROMOTE</term>
	/// <term>The transaction cannot be distributed.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="IsolationLevel">Reserved; specify zero (0).</param>
	/// <param name="IsolationFlags">Reserved; specify zero (0).</param>
	/// <param name="Timeout">
	/// <para>
	/// The time-out interval, in milliseconds. If a nonzero value is specified, the transaction will be aborted when the interval
	/// elapses if it has not already reached the prepared state.
	/// </para>
	/// <para>Specify zero (0) or INFINITE to provide an infinite time-out.</para>
	/// </param>
	/// <param name="Description">A user-readable description of the transaction.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the transaction.</para>
	/// <para>
	/// If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call the GetLastError function.
	/// </para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use the CloseHandle function to close the transaction handle. If the last transaction handle is closed before a client calls the
	/// CommitTransaction function with the transaction handle, then KTM rolls back the transaction.
	/// </para>
	/// <para>
	/// If the transaction might need to be promotable to a distributed transaction, then you must grant the Distributed Transaction
	/// Coordinator (DTC) access rights to enlist in the transaction. To do this, the lpTransactionAttributes parameter needs to contain
	/// an access control entry with the DTC’s SID (S-1-5-80-2818357584-3387065753-4000393942-342927828-138088443) and the
	/// TRANSACTION_ENLIST right. For more information, see Distributed Transaction Coordinator and Access Control Components.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-createtransaction HANDLE CreateTransaction( IN
	// LPSECURITY_ATTRIBUTES lpTransactionAttributes, IN LPGUID UOW, IN DWORD CreateOptions, IN DWORD IsolationLevel, IN DWORD
	// IsolationFlags, IN DWORD Timeout, LPWSTR Description );
	[DllImport("KtmW32.dll", SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "578bda35-bd35-4f6d-8366-a4bfb4dbfe42")]
	private static extern HTRXN CreateTransaction([In, Optional] SECURITY_ATTRIBUTES? lpTransactionAttributes, [Optional] IntPtr UOW, uint CreateOptions, [Optional] uint IsolationLevel, [Optional] uint IsolationFlags, [In] uint Timeout, [MarshalAs(UnmanagedType.LPWStr), Optional] string? Description);

	private static Win32Error CreateTree(string keyPath, out SafeRegistryHandle hKey)
	{
		var err = RegCreateKeyEx(HKEY.HKEY_CURRENT_USER, keyPath, samDesired: REGSAM.KEY_ALL_ACCESS, phkResult: out hKey, lpdwDisposition: out _);
		if (err.Failed) return err;
		const int val = 255;
		ulong ulongVal = val;
		var byteVal = BitConverter.GetBytes((uint)val);
		var strVal = val.ToString();
		err = RegSetValue(hKey, null, REG_VALUE_TYPE.REG_SZ, tmpRegKey);
		if (err.Failed) return err;
		err = RegSetValueEx(hKey, "V1", 0, REG_VALUE_TYPE.REG_QWORD, new PinnedObject(ulongVal), 8);
		if (err.Failed) return err;
		err = RegSetValueEx(hKey, "V2", 0, REG_VALUE_TYPE.REG_DWORD, byteVal, (uint)byteVal.Length);
		if (err.Failed) return err;
		err = RegSetValueEx(hKey, "V3", 0, REG_VALUE_TYPE.REG_SZ, strVal, (uint)StringHelper.GetByteCount(strVal));
		if (err.Failed) return err;
		err = RegFlushKey(hKey);
		if (err.Failed) return err;
		return Win32Error.ERROR_SUCCESS;
	}

	private static bool RegKeyHasValue(SafeRegistryHandle hKey, string valueName)
	{
		var sz = 0U;
		return RegGetValue(hKey, null, valueName, RRF.RRF_RT_ANY, out var type, default, ref sz).Succeeded && type != REG_VALUE_TYPE.REG_NONE;
	}

	private static bool RegKeyIsEmpty(SafeRegistryHandle hKey)
	{
		var sz = 255U;
		var sb = new StringBuilder((int)sz);
		var err = RegEnumValue(hKey, 0, sb, ref sz);
		return err == Win32Error.ERROR_NO_MORE_ITEMS ? true : (err.Succeeded || err == Win32Error.ERROR_MORE_DATA ? false : throw err.GetException()!);
	}
}