using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Items from BITS</summary>
	public static class BITS
	{
		[StructLayout(LayoutKind.Sequential, Pack=4)]
		public struct __MIDL___MIDL_itf_bits5_0_0005_0001_0001
		{
			public uint Data1;
			public ushort Data2;
			public ushort Data3;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
			public byte[] Data4;
		}

		public enum __MIDL_IBackgroundCopyError_0001
		{
			BG_ERROR_CONTEXT_NONE,
			BG_ERROR_CONTEXT_UNKNOWN,
			BG_ERROR_CONTEXT_GENERAL_QUEUE_MANAGER,
			BG_ERROR_CONTEXT_QUEUE_MANAGER_NOTIFICATION,
			BG_ERROR_CONTEXT_LOCAL_FILE,
			BG_ERROR_CONTEXT_REMOTE_FILE,
			BG_ERROR_CONTEXT_GENERAL_TRANSPORT,
			BG_ERROR_CONTEXT_REMOTE_APPLICATION
		}

		public enum __MIDL_IBackgroundCopyJob_0001
		{
			BG_JOB_PRIORITY_FOREGROUND,
			BG_JOB_PRIORITY_HIGH,
			BG_JOB_PRIORITY_NORMAL,
			BG_JOB_PRIORITY_LOW
		}

		public enum __MIDL_IBackgroundCopyJob_0002
		{
			BG_JOB_STATE_QUEUED,
			BG_JOB_STATE_CONNECTING,
			BG_JOB_STATE_TRANSFERRING,
			BG_JOB_STATE_SUSPENDED,
			BG_JOB_STATE_ERROR,
			BG_JOB_STATE_TRANSIENT_ERROR,
			BG_JOB_STATE_TRANSFERRED,
			BG_JOB_STATE_ACKNOWLEDGED,
			BG_JOB_STATE_CANCELLED
		}

		public enum __MIDL_IBackgroundCopyJob_0003
		{
			BG_JOB_TYPE_DOWNLOAD,
			BG_JOB_TYPE_UPLOAD,
			BG_JOB_TYPE_UPLOAD_REPLY
		}

		public enum __MIDL_IBackgroundCopyJob_0004
		{
			BG_JOB_PROXY_USAGE_PRECONFIG,
			BG_JOB_PROXY_USAGE_NO_PROXY,
			BG_JOB_PROXY_USAGE_OVERRIDE,
			BG_JOB_PROXY_USAGE_AUTODETECT
		}

		[StructLayout(LayoutKind.Sequential, Pack=4)]
		public struct _BG_FILE_INFO
		{
			[MarshalAs(UnmanagedType.LPWStr)]
			public string RemoteName;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string LocalName;
		}

		[StructLayout(LayoutKind.Sequential, Pack=8)]
		public struct _BG_FILE_PROGRESS
		{
			public ulong BytesTotal;
			public ulong BytesTransferred;
			public int Completed;
		}

		[StructLayout(LayoutKind.Sequential, Pack=8)]
		public struct _BG_JOB_PROGRESS
		{
			public ulong BytesTotal;
			public ulong BytesTransferred;
			public uint FilesTotal;
			public uint FilesTransferred;
		}

		[StructLayout(LayoutKind.Sequential, Pack=4)]
		public struct _BG_JOB_TIMES
		{
			public _FILETIME CreationTime;
			public _FILETIME ModificationTime;
			public _FILETIME TransferCompletionTime;
		}

		[ComImport, Guid("5CE34C0D-0DC9-4C1F-897C-DAA1B78CEE7C"), CoClass(typeof(BackgroundCopyManager5_0Class))]
		public interface BackgroundCopyManager5_0 : IBackgroundCopyManager
		{
		}

		[ComImport, TypeLibType(TypeLibTypeFlags.FCanCreate), ClassInterface(ClassInterfaceType.None), Guid("1ECCA34C-E88A-44E3-8D6A-8921BDE9E452")]
		public class BackgroundCopyManager5_0Class : IBackgroundCopyManager, BackgroundCopyManager5_0
		{
			// Methods
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			public virtual extern void CreateJob([In, MarshalAs(UnmanagedType.LPWStr)] string DisplayName, [In, ComAliasName("BackgroundCopyManager5_0.BG_JOB_TYPE")] BG_JOB_TYPE Type, [ComAliasName("BackgroundCopyManager5_0.GUID")] out GUID pJobId, [MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyJob ppJob);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			public virtual extern void EnumJobs([In] uint dwFlags, [MarshalAs(UnmanagedType.Interface)] out IEnumBackgroundCopyJobs ppenum);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			public virtual extern void GetErrorDescription([In, MarshalAs(UnmanagedType.Error)] int hResult, [In] uint LanguageId, [MarshalAs(UnmanagedType.LPWStr)] out string pErrorDescription);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			public virtual extern void GetJob([In, ComAliasName("BackgroundCopyManager5_0.GUID")] ref GUID jobID, [MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyJob ppJob);
		}

		public enum BG_ERROR_CONTEXT
		{
			BG_ERROR_CONTEXT_NONE,
			BG_ERROR_CONTEXT_UNKNOWN,
			BG_ERROR_CONTEXT_GENERAL_QUEUE_MANAGER,
			BG_ERROR_CONTEXT_QUEUE_MANAGER_NOTIFICATION,
			BG_ERROR_CONTEXT_LOCAL_FILE,
			BG_ERROR_CONTEXT_REMOTE_FILE,
			BG_ERROR_CONTEXT_GENERAL_TRANSPORT,
			BG_ERROR_CONTEXT_REMOTE_APPLICATION
		}

		public enum BG_JOB_PRIORITY
		{
			BG_JOB_PRIORITY_FOREGROUND,
			BG_JOB_PRIORITY_HIGH,
			BG_JOB_PRIORITY_NORMAL,
			BG_JOB_PRIORITY_LOW
		}

		public enum BG_JOB_PROXY_USAGE
		{
			BG_JOB_PROXY_USAGE_PRECONFIG,
			BG_JOB_PROXY_USAGE_NO_PROXY,
			BG_JOB_PROXY_USAGE_OVERRIDE,
			BG_JOB_PROXY_USAGE_AUTODETECT
		}

		public enum BG_JOB_STATE
		{
			BG_JOB_STATE_QUEUED,
			BG_JOB_STATE_CONNECTING,
			BG_JOB_STATE_TRANSFERRING,
			BG_JOB_STATE_SUSPENDED,
			BG_JOB_STATE_ERROR,
			BG_JOB_STATE_TRANSIENT_ERROR,
			BG_JOB_STATE_TRANSFERRED,
			BG_JOB_STATE_ACKNOWLEDGED,
			BG_JOB_STATE_CANCELLED
		}

		public enum BG_JOB_TYPE
		{
			BG_JOB_TYPE_DOWNLOAD,
			BG_JOB_TYPE_UPLOAD,
			BG_JOB_TYPE_UPLOAD_REPLY
		}

		[ComImport, Guid("19C613A0-FCB8-4F28-81AE-897C3D078F81"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IBackgroundCopyError
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetError([ComAliasName("BackgroundCopyManager5_0.BG_ERROR_CONTEXT")] out BG_ERROR_CONTEXT pContext, [MarshalAs(UnmanagedType.Error)] out int pCode);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetFile([MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyFile pVal);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetErrorDescription([In] uint LanguageId, [MarshalAs(UnmanagedType.LPWStr)] out string pErrorDescription);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetErrorContextDescription([In] uint LanguageId, [MarshalAs(UnmanagedType.LPWStr)] out string pContextDescription);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetProtocol([MarshalAs(UnmanagedType.LPWStr)] out string pProtocol);
		}

		[ComImport, Guid("01B7BD23-FB88-4A77-8490-5891D3E4653A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IBackgroundCopyFile
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetRemoteName([MarshalAs(UnmanagedType.LPWStr)] out string pVal);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetLocalName([MarshalAs(UnmanagedType.LPWStr)] out string pVal);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetProgress(out _BG_FILE_PROGRESS pVal);
		}

		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("37668D37-507E-4160-9316-26306D150B12")]
		public interface IBackgroundCopyJob
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void AddFileSet([In] uint cFileCount, [In] ref _BG_FILE_INFO pFileSet);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void AddFile([In, MarshalAs(UnmanagedType.LPWStr)] string RemoteUrl, [In, MarshalAs(UnmanagedType.LPWStr)] string LocalName);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void EnumFiles([MarshalAs(UnmanagedType.Interface)] out IEnumBackgroundCopyFiles pEnum);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void Suspend();
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void Resume();
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void Cancel();
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void Complete();
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetId([ComAliasName("BackgroundCopyManager5_0.GUID")] out GUID pVal);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetType([ComAliasName("BackgroundCopyManager5_0.BG_JOB_TYPE")] out BG_JOB_TYPE pVal);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetProgress(out _BG_JOB_PROGRESS pVal);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetTimes(out _BG_JOB_TIMES pVal);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetState([ComAliasName("BackgroundCopyManager5_0.BG_JOB_STATE")] out BG_JOB_STATE pVal);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetError([MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyError ppError);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetOwner([MarshalAs(UnmanagedType.LPWStr)] out string pVal);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void SetDisplayName([In, MarshalAs(UnmanagedType.LPWStr)] string Val);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetDisplayName([MarshalAs(UnmanagedType.LPWStr)] out string pVal);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string Val);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetDescription([MarshalAs(UnmanagedType.LPWStr)] out string pVal);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void SetPriority([In, ComAliasName("BackgroundCopyManager5_0.BG_JOB_PRIORITY")] BG_JOB_PRIORITY Val);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetPriority([ComAliasName("BackgroundCopyManager5_0.BG_JOB_PRIORITY")] out BG_JOB_PRIORITY pVal);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void SetNotifyFlags([In] uint Val);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetNotifyFlags(out uint pVal);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void SetNotifyInterface([In, MarshalAs(UnmanagedType.IUnknown)] object Val);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetNotifyInterface([MarshalAs(UnmanagedType.IUnknown)] out object pVal);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void SetMinimumRetryDelay([In] uint Seconds);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetMinimumRetryDelay(out uint Seconds);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void SetNoProgressTimeout([In] uint Seconds);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetNoProgressTimeout(out uint Seconds);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetErrorCount(out uint Errors);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void SetProxySettings([In, ComAliasName("BackgroundCopyManager5_0.BG_JOB_PROXY_USAGE")] BG_JOB_PROXY_USAGE ProxyUsage, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyList, [In, MarshalAs(UnmanagedType.LPWStr)] string ProxyBypassList);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetProxySettings([ComAliasName("BackgroundCopyManager5_0.BG_JOB_PROXY_USAGE")] out BG_JOB_PROXY_USAGE pProxyUsage, [MarshalAs(UnmanagedType.LPWStr)] out string pProxyList, [MarshalAs(UnmanagedType.LPWStr)] out string pProxyBypassList);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void TakeOwnership();
		}

		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5CE34C0D-0DC9-4C1F-897C-DAA1B78CEE7C")]
		public interface IBackgroundCopyManager
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void CreateJob([In, MarshalAs(UnmanagedType.LPWStr)] string DisplayName, [In, ComAliasName("BackgroundCopyManager5_0.BG_JOB_TYPE")] BG_JOB_TYPE Type, [ComAliasName("BackgroundCopyManager5_0.GUID")] out GUID pJobId, [MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyJob ppJob);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetJob([In, ComAliasName("BackgroundCopyManager5_0.GUID")] ref GUID jobID, [MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyJob ppJob);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void EnumJobs([In] uint dwFlags, [MarshalAs(UnmanagedType.Interface)] out IEnumBackgroundCopyJobs ppenum);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetErrorDescription([In, MarshalAs(UnmanagedType.Error)] int hResult, [In] uint LanguageId, [MarshalAs(UnmanagedType.LPWStr)] out string pErrorDescription);
		}

		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("CA51E165-C365-424C-8D41-24AAA4FF3C40")]
		public interface IEnumBackgroundCopyFiles
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void Next([In] uint celt, [MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyFile rgelt, [In, Out] ref uint pceltFetched);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void Skip([In] uint celt);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void Reset();
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void Clone([MarshalAs(UnmanagedType.Interface)] out IEnumBackgroundCopyFiles ppenum);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetCount(out uint puCount);
		}

		[ComImport, Guid("1AF4F612-3B71-466F-8F58-7B6F73AC57AD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IEnumBackgroundCopyJobs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void Next([In] uint celt, [MarshalAs(UnmanagedType.Interface)] out IBackgroundCopyJob rgelt, [In, Out] ref uint pceltFetched);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void Skip([In] uint celt);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void Reset();
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void Clone([MarshalAs(UnmanagedType.Interface)] out IEnumBackgroundCopyJobs ppenum);
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
			void GetCount(out uint puCount);
		}
	}
}