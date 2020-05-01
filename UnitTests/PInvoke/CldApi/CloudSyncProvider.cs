using ICSharpCode.Decompiler.IL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Vanara.Extensions;
using Vanara.InteropServices;
using Windows.Security.Cryptography;
using Windows.Storage;
using Windows.Storage.Provider;
using static Vanara.PInvoke.CldApi;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.SearchApi;

namespace Vanara.PInvoke.Tests
{
	public class CloudSyncCallbackArgs<T> : EventArgs where T : struct
	{
		public CloudSyncCallbackArgs(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters)
		{
			//System.Diagnostics.Debug.WriteLine($"CloudSyncCallbackArgs<{typeof(T).Name}> : {string.Join(" ", CallbackParameters.Content.Select(b => b.ToString("X2")))}");
			ConnectionKey = CallbackInfo.ConnectionKey;
			CallbackContext = CallbackInfo.CallbackContext;
			VolumeGuidName = CallbackInfo.VolumeGuidName;
			VolumeDosName = CallbackInfo.VolumeDosName;
			VolumeSerialNumber = CallbackInfo.VolumeSerialNumber;
			SyncRootFileId = CallbackInfo.SyncRootFileId;
			SyncRootIdentity = new SafeHGlobalHandle(CallbackInfo.SyncRootIdentity, CallbackInfo.SyncRootIdentityLength, false);
			FileId = CallbackInfo.FileId;
			FileSize = CallbackInfo.FileSize;
			FileIdentity = new SafeHGlobalHandle(CallbackInfo.FileIdentity, CallbackInfo.FileIdentityLength, false);
			NormalizedPath = CallbackInfo.NormalizedPath;
			TransferKey = CallbackInfo.TransferKey;
			PriorityHint = CallbackInfo.PriorityHint;
			pCorrelationVector = CallbackInfo.CorrelationVector;
			ProcessInfo = CallbackInfo.ProcessInfo.ToNullableStructure<CF_PROCESS_INFO>();
			RequestKey = CallbackInfo.RequestKey;
			try { ParamData = CallbackParameters.GetParam<T>(); } catch { }
			//catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"{ex.Message}"); }
		}

		/// <summary>points to an opaque blob that the sync provider provides at the sync root connect time.</summary>
		public IntPtr CallbackContext { get; }

		/// <summary>An opaque handle created by CfConnectSyncRoot for a sync root managed by the sync provider.</summary>
		public CF_CONNECTION_KEY ConnectionKey { get; }

		/// <summary>An optional correlation vector.</summary>
		public IntPtr pCorrelationVector { get; }

		/// <summary>An optional correlation vector.</summary>
		public CORRELATION_VECTOR? CorrelationVector => pCorrelationVector.ToNullableStructure<CORRELATION_VECTOR>();

		/// <summary>A 64 bit file system maintained, volume-wide unique ID of the placeholder file/directory to be serviced.</summary>
		public long FileId { get; }

		/// <summary>Points to the opaque blob that the sync provider provides at the placeholder creation/conversion/update time.</summary>
		public SafeAllocatedMemoryHandle FileIdentity { get; }

		/// <summary>The logical size of the placeholder file to be serviced. It is always 0 if the subject of the callback is a directory.</summary>
		public long FileSize { get; }

		/// <summary>
		/// The absolute path of the placeholder file/directory to be serviced on the volume identified by VolumeGuidName/VolumeDosName. It
		/// starts from the root directory of the volume. See the Remarks section for more details.
		/// </summary>
		public string NormalizedPath { get; }

		/// <summary>Contains callback specific parameters for this action.</summary>
		public T ParamData { get; }

		/// <summary>Parameters of an operation on a placeholder file or folder.</summary>
		public CF_OPERATION_PARAMETERS? OpParam { get; set; }

		/// <summary>
		/// A numeric scale given to the sync provider to describe the relative priority of one fetch compared to another fetch, in order to
		/// provide the most responsive experience to the user. The values range from 0 (lowest possible priority) to 15 (highest possible priority).
		/// </summary>
		public byte PriorityHint { get; }

		/// <summary>Points to a structure that contains the information about the user process that triggers this callback.</summary>
		public CF_PROCESS_INFO? ProcessInfo { get; }

		/// <summary/>
		public CF_REQUEST_KEY RequestKey { get; }

		/// <summary>
		/// A 64 bit file system maintained volume-wide unique ID of the sync root under which the placeholder file/directory to be serviced resides.
		/// </summary>
		public long SyncRootFileId { get; }

		/// <summary>Points to the opaque blob provided by the sync provider at the sync root registration time.</summary>
		public SafeAllocatedMemoryHandle SyncRootIdentity { get; }

		/// <summary>
		/// An opaque handle to the placeholder file/directory to be serviced. The sync provider must pass it back to the CfExecute call in
		/// order to perform the desired operation on the file/directory.
		/// </summary>
		public CF_TRANSFER_KEY TransferKey { get; }

		/// <summary>DOS drive letter of the volume in the form of “X:” where X is the drive letter.</summary>
		public string VolumeDosName { get; }

		/// <summary>GUID name of the volume on which the placeholder file/directory to be serviced resides. It is in the form: "\?\Volume{GUID}".</summary>
		public string VolumeGuidName { get; }

		/// <summary>The serial number of the volume.</summary>
		public uint VolumeSerialNumber { get; }

		/// <summary>The type of operation performed.</summary>
		public CF_OPERATION_TYPE OperationType { get; set; }

		/// <summary>
		/// <note>This member is new for Windows 10, version 1803.</note>
		/// <para>The current sync status of the platform.</para>
		/// <para>
		/// The platform queries this information upon any failed operations on a cloud file placeholder. If a structure is available, the
		/// platform will use the information provided to construct a more meaningful and actionable message to the user. The platform will
		/// keep this information on the file until the last handle on it goes away. If <see langword="null"/>, the platform will clear the
		/// previously set sync status, if there is one.
		/// </para>
		/// </summary>
		public IntPtr SyncStatus { get; set; }

		/// <summary>Makes a CF_OPERATION_INFO instance from the properties.</summary>
		/// <param name="opType">Type of the operation to set.</param>
		/// <returns>A CF_OPERATION_INFO instance.</returns>
		public CF_OPERATION_INFO MakeOpInfo(CF_OPERATION_TYPE opType, IntPtr syncStatus = default) => new CF_OPERATION_INFO
		{
			StructSize = (uint)Marshal.SizeOf<CF_OPERATION_INFO>(),
			Type = opType,
			ConnectionKey = ConnectionKey,
			TransferKey = TransferKey,
			CorrelationVector = pCorrelationVector,
			RequestKey = RequestKey,
			SyncStatus = syncStatus
		};
	}

	public class PlaceHolderDirectoryInfo : PlaceholderInfo
	{
		/// <summary>The newly created child placeholder directory is considered to have all of its children present locally.</summary>
		public bool DisableOnDemandPopulation;
	}

	public class PlaceHolderFileInfo : PlaceholderInfo
	{
		/// <summary>The size of the file, in bytes.</summary>
		public long FileSize;

		/// <summary>The newly created placeholder is marked as in-sync. Applicable to both placeholder files and directories.</summary>
		public bool InSync;

		public static PlaceHolderFileInfo CreateFromFile(FileInfo fileInfo, bool inSync = true, string relativeFilePath = null)
		{
			return new PlaceHolderFileInfo
			{
				ChangeTime = fileInfo.LastWriteTime,
				CreationTime = fileInfo.CreationTime,
				FileAttributes = fileInfo.Attributes,
				FileSize = fileInfo.Length,
				LastAccessTime = fileInfo.LastAccessTime,
				LastWriteTime = fileInfo.LastWriteTime,
				RelativePath = relativeFilePath ?? fileInfo.FullName,
				InSync = inSync,
			};
		}
	}

	public abstract class PlaceholderInfo
	{
		/// <summary>The time the file was changed in FILETIME format.</summary>
		public DateTime ChangeTime;

		/// <summary>The final USN value after create actions are performed.</summary>
		public int CreateUsn;

		/// <summary>
		/// The time the file was created in FILETIME format, which is a 64-bit value representing the number of 100-nanosecond intervals
		/// since January 1, 1601 (UTC).
		/// </summary>
		public DateTime CreationTime;

		/// <summary>
		/// The file attributes. For a list of attributes, see File Attribute Constants. If this is set to 0 in a <c>FILE_BASIC_INFO</c>
		/// structure passed to SetFileInformationByHandle then none of the attributes are changed.
		/// </summary>
		public System.IO.FileAttributes FileAttributes;

		/// <summary>
		/// A user mode buffer containing file information supplied by the sync provider. This is required for files (not for directories).
		/// </summary>
		public IntPtr FileIdentity;

		/// <summary>Length, in bytes, of the <c>FileIdentity</c>.</summary>
		public uint FileIdentityLength;

		/// <summary>The time the file was last accessed in FILETIME format.</summary>
		public DateTime LastAccessTime;

		/// <summary>The time the file was last written to in FILETIME format.</summary>
		public DateTime LastWriteTime;

		/// <summary>The name of the child placeholder file or directory to be created.</summary>
		public string RelativePath;

		/// <summary>The result of placeholder creation. On successful creation, the value is: STATUS_OK.</summary>
		public HRESULT Result;
	}

	internal class CloudSyncProvider : IDisposable
	{
		private const string MSSEARCH_INDEX = "SystemIndex";

		private CF_CONNECTION_KEY? key = null;

		public CloudSyncProvider(string syncRootPath, string name, string iconResource = ",0", Version version = null, IEnumerable<(string name, int id)> customProperties = null)
		{
			if (name.Contains(" "))
				throw new ArgumentException("Name cannot have spaces.", nameof(name));
			if (!Directory.Exists(syncRootPath))
				Directory.CreateDirectory(syncRootPath);
			SyncRootPath = syncRootPath;
			DisplayName = name;
			IconResource = iconResource;
			RecycleBinUri = new Uri($"http://{name.ToLower()}.test.com/recyclebin");
			SyncRootId = $"{name}!{WindowsIdentity.GetCurrent().User}!{Environment.UserName}";
			Version = version ?? new Version(1, 0);
			PropertyDefinitions = customProperties?.Select(t => new StorageProviderItemPropertyDefinition { DisplayNameResource = t.name, Id = t.id }).ToList();
			if (!IsSyncRoot(syncRootPath))
				Mount();
			ConnectSyncRootTransferCallbacks();
		}

		public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.CANCEL>> CancelFetchData;

		public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.CANCEL>> CancelFetchPlaceholders;

		public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.FETCHDATA>> FetchData;

		public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.FETCHPLACEHOLDERS>> FetchPlaceholders;

		public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.DEHYDRATE>> NotifyDehydrate;

		public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.DEHYDRATECOMPLETION>> NotifyDehydrateCompletion;

		public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.DELETE>> NotifyDelete;

		public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.DELETECOMPLETION>> NotifyDeleteCompletion;

		public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.CLOSECOMPLETION>> NotifyFileCloseCompletion;

		public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.OPENCOMPLETION>> NotifyFileOpenCompletion;

		public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.RENAME>> NotifyRename;

		public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.RENAMECOMPLETION>> NotifyRenameCompletion;

		public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.VALIDATEDATA>> ValidateData;

		public string DisplayName { get; }

		public string IconResource { get; }

		public IEnumerable<StorageProviderItemPropertyDefinition> PropertyDefinitions { get; }

		public Uri RecycleBinUri { get; }

		public CF_SYNC_PROVIDER_STATUS Status
		{
			get => CfQuerySyncProviderStatus(key.Value, out var stat).Succeeded ? stat : CF_SYNC_PROVIDER_STATUS.CF_PROVIDER_STATUS_ERROR;
			set => CfUpdateSyncProviderStatus(key.Value, value);
		}

		public string SyncRootId { get; }

		public string SyncRootPath { get; }

		public Version Version { get; }

		public static bool IsSyncRoot(string syncRootPath)
		{
			using var mem = SafeHGlobalHandle.CreateFromStructure<CF_SYNC_ROOT_BASIC_INFO>();
			return CfGetSyncRootInfoByPath(syncRootPath, CF_SYNC_ROOT_INFO_CLASS.CF_SYNC_ROOT_INFO_BASIC, mem, mem.Size, out var len).Succeeded;
		}

		public int ConvertToPlaceholder(string relativeFilePath, bool inSync = true, bool dehydrate = false, IntPtr fileIdentity = default, uint fileIdentityLength = 0)
		{
			using var hFile = CreateFile(Path.Combine(SyncRootPath, relativeFilePath), Kernel32.FileAccess.FILE_READ_ATTRIBUTES, FileShare.Read, null, FileMode.Open, 0);
			return ConvertToPlaceholder(hFile, inSync, dehydrate, fileIdentity, fileIdentityLength);
		}

		public int ConvertToPlaceholder(HFILE fileHandle, bool inSync = true, bool dehydrate = false, IntPtr fileIdentity = default, uint fileIdentityLength = 0)
		{
			var flags = (inSync ? CF_CONVERT_FLAGS.CF_CONVERT_FLAG_MARK_IN_SYNC : 0) | (dehydrate ? CF_CONVERT_FLAGS.CF_CONVERT_FLAG_DEHYDRATE : 0);
			CfConvertToPlaceholder(fileHandle, fileIdentity, fileIdentityLength, flags, out var usn).ThrowIfFailed();
			return usn;
		}

		public int CreatePlaceholderFromFile(string relativeFilePath, FileInfo fileInfo, bool inSync = true)
		{
			using var pRelativeName = new SafeCoTaskMemString(relativeFilePath);
			var ph = new PlaceholderInfo[] { PlaceHolderFileInfo.CreateFromFile(fileInfo, inSync, relativeFilePath) };
			ph[0].FileIdentity = pRelativeName;
			ph[0].FileIdentityLength = pRelativeName.Size;
			if (CreatePlaceholders(ph) != 1)
				throw ph[0].Result.GetException();
			return ph[0].CreateUsn;
		}

		public uint CreatePlaceholders(IList<PlaceholderInfo> placeholders)
		{
			var entries = new CF_PLACEHOLDER_CREATE_INFO[placeholders.Count];
			for (int i = 0; i < placeholders.Count; i++)
			{
				var ph = placeholders[i];
				var flags = ph is PlaceHolderFileInfo phf && phf.InSync ? CF_PLACEHOLDER_CREATE_FLAGS.CF_PLACEHOLDER_CREATE_FLAG_MARK_IN_SYNC : CF_PLACEHOLDER_CREATE_FLAGS.CF_PLACEHOLDER_CREATE_FLAG_NONE;
				if (ph is PlaceHolderDirectoryInfo phd && phd.DisableOnDemandPopulation)
					flags |= CF_PLACEHOLDER_CREATE_FLAGS.CF_PLACEHOLDER_CREATE_FLAG_DISABLE_ON_DEMAND_POPULATION;
				entries[i] = new CF_PLACEHOLDER_CREATE_INFO
				{
					FileIdentity = ph.FileIdentity,
					FileIdentityLength = ph.FileIdentityLength,
					RelativeFileName = ph.RelativePath,
					Flags = flags,
					FsMetadata = new CF_FS_METADATA
					{
						FileSize = (ph as PlaceHolderFileInfo)?.FileSize ?? 0,
						BasicInfo = new FILE_BASIC_INFO
						{
							FileAttributes = (FileFlagsAndAttributes)ph.FileAttributes,
							CreationTime = ph.CreationTime.ToFileTimeStruct(),
							LastWriteTime = ph.LastWriteTime.ToFileTimeStruct(),
							LastAccessTime = ph.LastAccessTime.ToFileTimeStruct(),
							ChangeTime = ph.LastWriteTime.ToFileTimeStruct(),
						}
					}
				};
			}

			CfCreatePlaceholders(SyncRootPath, entries, (uint)entries.Length, CF_CREATE_FLAGS.CF_CREATE_FLAG_NONE, out var done);
			for (int i = 0; i < entries.Length; i++)
			{
				placeholders[i].CreateUsn = entries[i].CreateUsn;
				placeholders[i].Result = entries[i].Result;
			}
			return done;

			//try
			//{
			//	var prop = new StorageProviderItemProperty
			//	{
			//		Id = 1,
			//		Value = "Value1",
			//		// This icon is just for the sample. You should provide your own branded icon here
			//		IconResource = "shell32.dll,-44"
			//	};

			// Console.Write("Applying custom state for {0}\n", relativeFilePath); Utilities.ApplyCustomStateToPlaceholderFile(destPath,
			// relativeFilePath, prop);

			//	if ((findData.dwFileAttributes & FileAttributes.Directory) != 0)
			//	{
			//		Create(syncRootPath, relativeFilePath, destPath);
			//	}
			//}
			//catch (Exception ex)
			//{
			//	// to_hresult() will eat the exception if it is a result of check_hresult, otherwise the exception will get rethrown and
			//	// this method will crash out as it should
			//	Console.Write("Failed to set custom state on {0} with {1:X8}\n", relativeFilePath, ex.HResult);
			//	// Eating it here lets other files still get a chance. Not worth crashing the sample, but certainly noteworthy for
			//	// production code
			//}
		}

		public void Dispose()
		{
			if (!key.HasValue) return;
			CfDisconnectSyncRoot(key.Value).ThrowIfFailed();
			key = null;
			UnregisterWithShell();
		}

		protected virtual void OnCancelFetchData(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(CancelFetchData, CallbackInfo, CallbackParameters);

		protected virtual void OnCancelFetchPlaceholders(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(CancelFetchPlaceholders, CallbackInfo, CallbackParameters);

		protected virtual void OnFetchData(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(FetchData, CallbackInfo, CallbackParameters);

		protected virtual void OnFetchPlaceholders(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(FetchPlaceholders, CallbackInfo, CallbackParameters);

		protected virtual void OnNotifyDehydrate(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(NotifyDehydrate, CallbackInfo, CallbackParameters);

		protected virtual void OnNotifyDehydrateCompletion(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(NotifyDehydrateCompletion, CallbackInfo, CallbackParameters);

		protected virtual void OnNotifyDelete(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(NotifyDelete, CallbackInfo, CallbackParameters);

		protected virtual void OnNotifyDeleteCompletion(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(NotifyDeleteCompletion, CallbackInfo, CallbackParameters);

		protected virtual void OnNotifyFileCloseCompletion(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(NotifyFileCloseCompletion, CallbackInfo, CallbackParameters);

		protected virtual void OnNotifyFileOpenCompletion(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(NotifyFileOpenCompletion, CallbackInfo, CallbackParameters);

		protected virtual void OnNotifyRename(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(NotifyRename, CallbackInfo, CallbackParameters);

		protected virtual void OnNotifyRenameCompletion(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(NotifyRenameCompletion, CallbackInfo, CallbackParameters);

		protected virtual void OnValidateData(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(ValidateData, CallbackInfo, CallbackParameters);

		protected virtual void HandleEvent<T>(EventHandler<CloudSyncCallbackArgs<T>> handler, in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) where T : struct
		{
			if (handler != null)
			{
				var args = new CloudSyncCallbackArgs<T>(CallbackInfo, CallbackParameters);
				handler.Invoke(this, args);
				if (args.OperationType != 0 && args.OpParam.HasValue)
				{
					var opInfo = args.MakeOpInfo(args.OperationType, args.SyncStatus);
					var opParam = args.OpParam.Value;
					CfExecute(opInfo, ref opParam).ThrowIfFailed();
				}
			}
		}

		private static void AddFolderToSearchIndexer(string folder)
		{
			var url = "file:///" + folder;

			using var searchManager = ComReleaserFactory.Create(new ISearchManager());
			using var searchCatalogManager = ComReleaserFactory.Create(searchManager.Item.GetCatalog(MSSEARCH_INDEX));
			using var searchCrawlScopeManager = ComReleaserFactory.Create(searchCatalogManager.Item.GetCrawlScopeManager());
			searchCrawlScopeManager.Item.AddDefaultScopeRule(url, true, FOLLOW_FLAGS.FF_INDEXCOMPLEXURLS);
			searchCrawlScopeManager.Item.SaveAll();
		}

		private void ConnectSyncRootTransferCallbacks()
		{
			CF_CALLBACK_REGISTRATION[] callbackTable =
			{
				new CF_CALLBACK_REGISTRATION { Type = CF_CALLBACK_TYPE.CF_CALLBACK_TYPE_CANCEL_FETCH_DATA, Callback = OnCancelFetchData },
				new CF_CALLBACK_REGISTRATION { Type = CF_CALLBACK_TYPE.CF_CALLBACK_TYPE_CANCEL_FETCH_PLACEHOLDERS, Callback = OnCancelFetchPlaceholders },
				new CF_CALLBACK_REGISTRATION { Type = CF_CALLBACK_TYPE.CF_CALLBACK_TYPE_FETCH_DATA, Callback = OnFetchData },
				new CF_CALLBACK_REGISTRATION { Type = CF_CALLBACK_TYPE.CF_CALLBACK_TYPE_FETCH_PLACEHOLDERS, Callback = OnFetchPlaceholders },
				new CF_CALLBACK_REGISTRATION { Type = CF_CALLBACK_TYPE.CF_CALLBACK_TYPE_NOTIFY_DEHYDRATE, Callback = OnNotifyDehydrate },
				new CF_CALLBACK_REGISTRATION { Type = CF_CALLBACK_TYPE.CF_CALLBACK_TYPE_NOTIFY_DEHYDRATE_COMPLETION, Callback = OnNotifyDehydrateCompletion },
				new CF_CALLBACK_REGISTRATION { Type = CF_CALLBACK_TYPE.CF_CALLBACK_TYPE_NOTIFY_DELETE, Callback = OnNotifyDelete },
				new CF_CALLBACK_REGISTRATION { Type = CF_CALLBACK_TYPE.CF_CALLBACK_TYPE_NOTIFY_DELETE_COMPLETION, Callback = OnNotifyDeleteCompletion },
				new CF_CALLBACK_REGISTRATION { Type = CF_CALLBACK_TYPE.CF_CALLBACK_TYPE_NOTIFY_FILE_CLOSE_COMPLETION, Callback = OnNotifyFileCloseCompletion },
				new CF_CALLBACK_REGISTRATION { Type = CF_CALLBACK_TYPE.CF_CALLBACK_TYPE_NOTIFY_FILE_OPEN_COMPLETION, Callback = OnNotifyFileOpenCompletion },
				new CF_CALLBACK_REGISTRATION { Type = CF_CALLBACK_TYPE.CF_CALLBACK_TYPE_NOTIFY_RENAME, Callback = OnNotifyRename },
				new CF_CALLBACK_REGISTRATION { Type = CF_CALLBACK_TYPE.CF_CALLBACK_TYPE_NOTIFY_RENAME_COMPLETION, Callback = OnNotifyRenameCompletion },
				new CF_CALLBACK_REGISTRATION { Type = CF_CALLBACK_TYPE.CF_CALLBACK_TYPE_VALIDATE_DATA, Callback = OnValidateData },
				CF_CALLBACK_REGISTRATION.CF_CALLBACK_REGISTRATION_END
			};

			CfConnectSyncRoot(SyncRootPath, callbackTable, default, CF_CONNECT_FLAGS.CF_CONNECT_FLAG_NONE, out var ckey).ThrowIfFailed();
			key = ckey;
		}

		private void Mount()
		{
			AddFolderToSearchIndexer(SyncRootPath);
			RegisterWithShell().Wait();
		}

		private async Task RegisterWithShell()
		{
			var info = new StorageProviderSyncRootInfo
			{
				Context = CryptographicBuffer.ConvertStringToBinary(SyncRootId, BinaryStringEncoding.Utf8),
				DisplayNameResource = DisplayName,
				HardlinkPolicy = StorageProviderHardlinkPolicy.None,
				HydrationPolicy = StorageProviderHydrationPolicy.Full,
				HydrationPolicyModifier = StorageProviderHydrationPolicyModifier.None,
				IconResource = IconResource,
				Id = SyncRootId,
				InSyncPolicy = StorageProviderInSyncPolicy.FileCreationTime | StorageProviderInSyncPolicy.DirectoryCreationTime,
				Path = await StorageFolder.GetFolderFromPathAsync(SyncRootPath),
				PopulationPolicy = StorageProviderPopulationPolicy.AlwaysFull,
				RecycleBinUri = RecycleBinUri,
				ShowSiblingsAsGroup = false,
				Version = Version.ToString(),
			};

			if (PropertyDefinitions != null)
				foreach (var pd in PropertyDefinitions)
					info.StorageProviderItemPropertyDefinitions.Add(pd);

			StorageProviderSyncRootManager.Register(info);

			// Give the cache some time to invalidate
			Thread.Sleep(1000);
		}

		private void UnregisterWithShell()
		{
			StorageProviderSyncRootManager.Unregister(SyncRootId);
		}
	}
}