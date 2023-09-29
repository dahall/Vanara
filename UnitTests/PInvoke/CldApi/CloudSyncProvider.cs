using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Storage;
using Windows.Storage.Provider;
using static Vanara.PInvoke.CldApi;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.SearchApi;
using USN = System.Int64;

namespace Vanara.PInvoke.Tests;

/// <summary>Event arguments for a cloud file callback.</summary>
/// <typeparam name="T">The type of data handled by the callback.</typeparam>
/// <seealso cref="System.EventArgs"/>
public class CloudSyncCallbackArgs<T> : EventArgs where T : struct
{
	private readonly CF_CALLBACK_INFO info;

	/// <summary>Initializes a new instance of the <see cref="CloudSyncCallbackArgs{T}"/> class.</summary>
	/// <param name="CallbackInfo">The callback information.</param>
	/// <param name="CallbackParameters">The callback parameters.</param>
	public CloudSyncCallbackArgs(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters)
	{
		//System.Diagnostics.Debug.WriteLine($"CloudSyncCallbackArgs<{typeof(T).Name}> : {string.Join(" ", CallbackParameters.Content.Select(b => b.ToString("X2")))}");
		info = CallbackInfo;
		SyncRootIdentity = new SafeHGlobalHandle(CallbackInfo.SyncRootIdentity, CallbackInfo.SyncRootIdentityLength, false);
		FileIdentity = new SafeHGlobalHandle(CallbackInfo.FileIdentity, CallbackInfo.FileIdentityLength, false);
		ProcessInfo = CallbackInfo.ProcessInfo.ToNullableStructure<CF_PROCESS_INFO>();
		try { ParamData = CallbackParameters.GetParam<T>(); } catch { }
		//catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"{ex.Message}"); }
	}

	/// <summary>points to an opaque blob that the sync provider provides at the sync root connect time.</summary>
	public IntPtr CallbackContext => info.CallbackContext;

	/// <summary>An opaque handle created by CfConnectSyncRoot for a sync root managed by the sync provider.</summary>
	public CF_CONNECTION_KEY ConnectionKey => info.ConnectionKey;

	/// <summary>An optional correlation vector.</summary>
	public CORRELATION_VECTOR? CorrelationVector => pCorrelationVector.ToNullableStructure<CORRELATION_VECTOR>();

	/// <summary>A 64 bit file system maintained, volume-wide unique ID of the placeholder file/directory to be serviced.</summary>
	public long FileId => info.FileId;

	/// <summary>Points to the opaque blob that the sync provider provides at the placeholder creation/conversion/update time.</summary>
	public SafeAllocatedMemoryHandle FileIdentity { get; }

	/// <summary>The logical size of the placeholder file to be serviced. It is always 0 if the subject of the callback is a directory.</summary>
	public long FileSize => info.FileSize;

	/// <summary>
	/// The absolute path of the placeholder file/directory to be serviced on the volume identified by VolumeGuidName/VolumeDosName. It
	/// starts from the root directory of the volume. See the Remarks section for more details.
	/// </summary>
	public string NormalizedPath => info.NormalizedPath;

	/// <summary>The type of operation performed.</summary>
	public CF_OPERATION_TYPE OperationType { get; internal set; }

	/// <summary>Parameters of an operation on a placeholder file or folder.</summary>
	public CF_OPERATION_PARAMETERS? OpParam { get; internal set; }

	/// <summary>Contains callback specific parameters for this action.</summary>
	public T ParamData { get; }

	/// <summary>An optional correlation vector.</summary>
	public IntPtr pCorrelationVector => info.CorrelationVector;

	/// <summary>
	/// A numeric scale given to the sync provider to describe the relative priority of one fetch compared to another fetch, in order to
	/// provide the most responsive experience to the user. The values range from 0 (lowest possible priority) to 15 (highest possible priority).
	/// </summary>
	public byte PriorityHint => info.PriorityHint;

	/// <summary>Points to a structure that contains the information about the user process that triggers this callback.</summary>
	public CF_PROCESS_INFO? ProcessInfo { get; }

	/// <summary/>
	public CF_REQUEST_KEY RequestKey => info.RequestKey;

	/// <summary>
	/// A 64 bit file system maintained volume-wide unique ID of the sync root under which the placeholder file/directory to be serviced resides.
	/// </summary>
	public long SyncRootFileId => info.SyncRootFileId;

	/// <summary>Points to the opaque blob provided by the sync provider at the sync root registration time.</summary>
	public SafeAllocatedMemoryHandle SyncRootIdentity { get; }

	/// <summary>
	/// An opaque handle to the placeholder file/directory to be serviced. The sync provider must pass it back to the CfExecute call in
	/// order to perform the desired operation on the file/directory.
	/// </summary>
	public CF_TRANSFER_KEY TransferKey => info.TransferKey;

	/// <summary>DOS drive letter of the volume in the form of “X:” where X is the drive letter.</summary>
	public string VolumeDosName => info.VolumeDosName;

	/// <summary>GUID name of the volume on which the placeholder file/directory to be serviced resides. It is in the form: "\?\Volume{GUID}".</summary>
	public string VolumeGuidName => info.VolumeGuidName;

	/// <summary>The serial number of the volume.</summary>
	public uint VolumeSerialNumber => info.VolumeSerialNumber;

	/// <summary>Makes a CF_OPERATION_INFO instance from the properties.</summary>
	/// <param name="opType">Type of the operation to set.</param>
	/// <returns>A CF_OPERATION_INFO instance.</returns>
	public CF_OPERATION_INFO MakeOpInfo(CF_OPERATION_TYPE opType, IntPtr syncStatus = default) => new()
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

/// <summary>Information for a placeholder representing a directory.</summary>
/// <seealso cref="Vanara.PInvoke.Tests.PlaceholderInfo"/>
public class PlaceHolderDirectoryInfo : PlaceholderInfo
{
	/// <summary>The newly created child placeholder directory is considered to have all of its children present locally.</summary>
	public bool DisableOnDemandPopulation;
}

/// <summary>Information for a placeholder representing a file.</summary>
/// <seealso cref="Vanara.PInvoke.Tests.PlaceholderInfo"/>
public class PlaceHolderFileInfo : PlaceholderInfo
{
	/// <summary>The size of the file, in bytes.</summary>
	public long FileSize;

	/// <summary>The newly created placeholder is marked as in-sync. Applicable to both placeholder files and directories.</summary>
	public bool InSync;

	/// <summary>Creates a placeholder from a file.</summary>
	/// <param name="fileInfo">The file information.</param>
	/// <param name="inSync">if set to <see langword="true"/>, information is synchronized.</param>
	/// <param name="relativeFilePath">The relative file path.</param>
	/// <returns>A platholder for the file.</returns>
	public static PlaceHolderFileInfo CreateFromFile(FileInfo fileInfo, bool inSync = true, string? relativeFilePath = null) => new()
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

/// <summary>Information about a placeholder.</summary>
public abstract class PlaceholderInfo
{
	protected CF_PLACEHOLDER_CREATE_INFO info;

	/// <summary>The time the file was changed in FILETIME format.</summary>
	public DateTime ChangeTime;

	/// <summary>The final USN value after create actions are performed.</summary>
	public USN CreateUsn;

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
	public string? RelativePath;

	/// <summary>The result of placeholder creation. On successful creation, the value is: STATUS_OK.</summary>
	public HRESULT Result;
}

/// <summary>Represents a provider (server) of a cloud file system.</summary>
/// <seealso cref="System.IDisposable"/>
internal class CloudSyncProvider : IDisposable
{
	private const string MSSEARCH_INDEX = "SystemIndex";
	private CF_CALLBACK_REGISTRATION[]? callbackTable;
	private bool disposed = false;
	private CF_CONNECTION_KEY? key = null;

	/// <summary>Initializes a new instance of the <see cref="CloudSyncProvider"/> class.</summary>
	/// <param name="syncRootPath">The path to the sync root.</param>
	/// <param name="name">An optional display name that maps to the existing sync root registration.</param>
	/// <param name="iconResource">A path to an icon resource for the custom state of a file or folder.</param>
	/// <param name="version">The version number of the sync root.</param>
	/// <param name="customProperties">The custom properties.</param>
	/// <exception cref="System.ArgumentException">Name cannot have spaces. - name</exception>
	public CloudSyncProvider(string syncRootPath, string name, string iconResource = ",0", Version? version = null, IEnumerable<(string name, int id)>? customProperties = null)
	{
		if (name.Contains(' '))
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

	public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.CANCEL>>? CancelFetchData;

	public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.CANCEL>>? CancelFetchPlaceholders;

	public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.FETCHDATA>>? FetchData;

	public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.FETCHPLACEHOLDERS>>? FetchPlaceholders;

	public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.DEHYDRATE>>? NotifyDehydrate;

	public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.DEHYDRATECOMPLETION>>? NotifyDehydrateCompletion;

	public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.DELETE>>? NotifyDelete;

	public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.DELETECOMPLETION>>? NotifyDeleteCompletion;

	public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.CLOSECOMPLETION>>? NotifyFileCloseCompletion;

	public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.OPENCOMPLETION>>? NotifyFileOpenCompletion;

	public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.RENAME>>? NotifyRename;

	public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.RENAMECOMPLETION>>? NotifyRenameCompletion;

	public event EventHandler<CloudSyncCallbackArgs<CF_CALLBACK_PARAMETERS.VALIDATEDATA>>? ValidateData;

	/// <summary>Gets an optional display name that maps to the existing sync root registration.</summary>
	public string DisplayName { get; }

	/// <summary>Gets a path to an icon resource for the custom state of a file or folder.</summary>
	public string IconResource { get; }

	public IEnumerable<StorageProviderItemPropertyDefinition>? PropertyDefinitions { get; }

	/// <summary>Gets a Uri to a cloud storage recycle bin.</summary>
	public Uri RecycleBinUri { get; }

	/// <summary>Gets or sets the current status of the sync provider.</summary>
	public CF_SYNC_PROVIDER_STATUS Status
	{
		get => key is not null && CfQuerySyncProviderStatus(key.Value, out var stat).Succeeded ? stat : CF_SYNC_PROVIDER_STATUS.CF_PROVIDER_STATUS_ERROR;
		set { if (key is not null) CfUpdateSyncProviderStatus(key.Value, value); else throw new InvalidOperationException(); }
	}

	/// <summary>Gets an identifier for the sync root.</summary>
	public string SyncRootId { get; }

	/// <summary>Gets the path to the sync root.</summary>
	public string SyncRootPath { get; }

	/// <summary>Gets the version number of the sync root.</summary>
	public Version Version { get; }

	public static bool IsSyncRoot(string syncRootPath)
	{
		using var mem = SafeHGlobalHandle.CreateFromStructure<CF_SYNC_ROOT_BASIC_INFO>();
		return CfGetSyncRootInfoByPath(syncRootPath, CF_SYNC_ROOT_INFO_CLASS.CF_SYNC_ROOT_INFO_BASIC, mem, mem.Size, out var len).Succeeded;
	}

	/// <summary>Converts a normal file/directory to a placeholder file/directory using oplocks.</summary>
	/// <param name="fileHandle">Handle to the file or directory to be converted.</param>
	/// <param name="inSync">
	/// if set to <see langword="true"/>, the platform marks the converted placeholder as in sync with cloud upon a successful
	/// conversion of the file.
	/// </param>
	/// <param name="dehydrate">
	/// if set to <see langword="true"/> the platform dehydrates the file after converting it to a placeholder successfully. The caller
	/// must acquire an exclusive handle when specifying this flag or data corruptions can occur.
	/// </param>
	/// <param name="fileIdentity">
	/// A user mode buffer that contains the opaque file or directory information supplied by the caller. Optional if the caller is not
	/// dehydrating the file at the same time, or if the caller is converting a directory. Cannot exceed 4KB in size.
	/// </param>
	/// <param name="fileIdentityLength">Length, in bytes, of the FileIdentity.</param>
	/// <returns>The final USN value after convert actions are performed.</returns>
	/// <remarks>
	/// <para>To convert a placeholder:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The file or directory to be converted must be contained in a registered sync root tree; it can be the sync root directory
	/// itself, or any descendant directory; otherwise, the call with be failed with HRESULT(ERROR_CLOUD_FILE_NOT_UNDER_SYNC_ROOT).
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If dehydration is requested, the sync root must be registered with a valid hydration policy that is not
	/// CF_HYDRATION_POLICY_ALWAYS_FULL; otherwise the call will be failed with HRESULT(ERROR_CLOUD_FILE_NOT_SUPPORTED).
	/// </term>
	/// </item>
	/// <item>
	/// <term>If dehydration is requested, the placeholder must not be pinned locally or the call with be failed with HRESULT(ERROR_CLOUD_FILE_PINNED).</term>
	/// </item>
	/// <item>
	/// <term>If dehydration is requested, the placeholder must be in sync or the call with be failed with HRESULT(ERROR_CLOUD_FILE_NOT_IN_SYNC).</term>
	/// </item>
	/// <item>
	/// <term>
	/// The caller must have WRITE_DATA or WRITE_DAC access to the file or directory to be converted. Otherwise the operation will be
	/// failed with HRESULT(ERROR_CLOUD_FILE_ACCESS_DENIED).
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	public USN ConvertToPlaceholder(string relativeFilePath, bool inSync = true, bool dehydrate = false, IntPtr fileIdentity = default, uint fileIdentityLength = 0)
	{
		CfOpenFileWithOplock(relativeFilePath, CF_OPEN_FILE_FLAGS.CF_OPEN_FILE_FLAG_EXCLUSIVE, out var hCfFile).ThrowIfFailed();
		using (hCfFile)
		{
			CfReferenceProtectedHandle(hCfFile);
			try
			{
				var hFile = CfGetWin32HandleFromProtectedHandle(hCfFile);
				return ConvertToPlaceholder(hFile, inSync, dehydrate, fileIdentity, fileIdentityLength);
			}
			finally
			{
				CfReleaseProtectedHandle(hCfFile);
			}
		}
	}

	/// <summary>Converts a normal file/directory to a placeholder file/directory.</summary>
	/// <param name="fileHandle">Handle to the file or directory to be converted.</param>
	/// <param name="inSync">
	/// if set to <see langword="true"/>, the platform marks the converted placeholder as in sync with cloud upon a successful
	/// conversion of the file.
	/// </param>
	/// <param name="dehydrate">
	/// if set to <see langword="true"/> the platform dehydrates the file after converting it to a placeholder successfully. The caller
	/// must acquire an exclusive handle when specifying this flag or data corruptions can occur.
	/// </param>
	/// <param name="fileIdentity">
	/// A user mode buffer that contains the opaque file or directory information supplied by the caller. Optional if the caller is not
	/// dehydrating the file at the same time, or if the caller is converting a directory. Cannot exceed 4KB in size.
	/// </param>
	/// <param name="fileIdentityLength">Length, in bytes, of the FileIdentity.</param>
	/// <returns>The final USN value after convert actions are performed.</returns>
	/// <remarks>
	/// <para>
	/// In the file case, the caller must acquire an exclusive handle to the file if it also intends to dehydrate the file at the same
	/// time or data corruption can occur. To minimize the impact on user applications it is highly recommended that the caller obtain
	/// the exclusiveness using proper oplocks (via CfOpenFileWithOplock) as opposed to using a share-nothing handle.
	/// </para>
	/// <para>To convert a placeholder:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The file or directory to be converted must be contained in a registered sync root tree; it can be the sync root directory
	/// itself, or any descendant directory; otherwise, the call with be failed with HRESULT(ERROR_CLOUD_FILE_NOT_UNDER_SYNC_ROOT).
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If dehydration is requested, the sync root must be registered with a valid hydration policy that is not
	/// CF_HYDRATION_POLICY_ALWAYS_FULL; otherwise the call will be failed with HRESULT(ERROR_CLOUD_FILE_NOT_SUPPORTED).
	/// </term>
	/// </item>
	/// <item>
	/// <term>If dehydration is requested, the placeholder must not be pinned locally or the call with be failed with HRESULT(ERROR_CLOUD_FILE_PINNED).</term>
	/// </item>
	/// <item>
	/// <term>If dehydration is requested, the placeholder must be in sync or the call with be failed with HRESULT(ERROR_CLOUD_FILE_NOT_IN_SYNC).</term>
	/// </item>
	/// <item>
	/// <term>
	/// The caller must have WRITE_DATA or WRITE_DAC access to the file or directory to be converted. Otherwise the operation will be
	/// failed with HRESULT(ERROR_CLOUD_FILE_ACCESS_DENIED).
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	public USN ConvertToPlaceholder(HFILE fileHandle, bool inSync = true, bool dehydrate = false, IntPtr fileIdentity = default, uint fileIdentityLength = 0)
	{
		var flags = (inSync ? CF_CONVERT_FLAGS.CF_CONVERT_FLAG_MARK_IN_SYNC : 0) | (dehydrate ? CF_CONVERT_FLAGS.CF_CONVERT_FLAG_DEHYDRATE : 0);
		CfConvertToPlaceholder(fileHandle, fileIdentity, fileIdentityLength, flags, out var usn).ThrowIfFailed();
		return usn;
	}

	/// <summary>Creates a new placeholder files under a sync root tree.</summary>
	/// <param name="relativeFilePath">The relative file path of the file.</param>
	/// <param name="fileInfo">The file information of the file.</param>
	/// <param name="inSync">if set to <see langword="true"/>, the file is synchronized.</param>
	/// <returns>The final USN value for the file.</returns>
	public USN CreatePlaceholderFromFile(string relativeFilePath, FileInfo fileInfo, bool inSync = true)
	{
		using var pRelativeName = new SafeCoTaskMemString(relativeFilePath);
		var ph = new PlaceholderInfo[] { PlaceHolderFileInfo.CreateFromFile(fileInfo, inSync, relativeFilePath) };
		ph[0].FileIdentity = pRelativeName;
		ph[0].FileIdentityLength = pRelativeName.Size;
		if (CreatePlaceholders(ph) != 1)
			throw ph[0].Result.GetException()!;
		return ph[0].CreateUsn;
	}

	/// <summary>Creates one or more new placeholder files or directories under a sync root tree.</summary>
	/// <param name="placeholders">
	/// On successful creation, the PlaceholderArray contains the final USN value and a STATUS_OK message. On return, this array
	/// contains an HRESULT value describing whether the placeholder was created or not.
	/// </param>
	/// <returns>The number of entries processed, including failed entries.</returns>
	/// <remarks>
	/// <para>
	/// Creating a placeholder with this function is preferred compared to creating a new file with CreateFile and then converting it to
	/// a placeholder with CfConvertToPlaceholder; both for efficiency and because it eliminates the time window where the file is not a
	/// placeholder. The function can also create multiple files or directories in a batch, which can also be more efficient.
	/// </para>
	/// <para>
	/// This function is useful when performing an initial sync of files or directories from the cloud down to the client, or when
	/// syncing down a newly created single file or directory from the cloud.
	/// </para>
	/// </remarks>
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
				RelativeFileName = ph.RelativePath!,
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

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		disposed = true;
		if (!key.HasValue) return;
		CfDisconnectSyncRoot(key.Value).ThrowIfFailed();
		key = null;
		UnregisterWithShell();
	}

	/// <summary>Allows a sync provider to notify the platform of its status.</summary>
	/// <param name="description">
	/// A localized string that is expected to contain more meaningful and actionable information about the file in question. Sync
	/// providers are expected to balance the requirement of providing more actionable information and maintaining an as small as
	/// possible memory footprint.
	/// </param>
	/// <param name="code">
	/// <para>The use of this parameter is completely up to the sync provider that supports this rich sync status construct.</para>
	/// <para>For a particular sync provider, it is expected that there is a 1:1 mapping between the code and the description string.</para>
	/// <para>
	/// It is recommended that you use the highest bit order to describe the type of error code: 1 for an error-level code, and 0
	/// for an information-level code.
	/// </para>
	/// <para><c>Note</c><c>Code</c> is opaque to the platform, and is used only for tracking purposes.</para>
	/// </param>
	public void ReportSyncStatus(string description, uint code)
	{
		var ssLen = (uint)Marshal.SizeOf<CF_SYNC_STATUS>();
		uint descLen = (uint)(description.Length + 1) * 2;
		var ss = new CF_SYNC_STATUS { StructSize = ssLen + descLen, Code = code, DescriptionLength = descLen, DescriptionOffset = ssLen };
		using var mem = new SafeCoTaskMemStruct<CF_SYNC_STATUS>(ss, ss.StructSize);
		StringHelper.Write(description, ((IntPtr)mem).Offset(Marshal.SizeOf<CF_SYNC_STATUS>()), out _, true, CharSet.Unicode, descLen);
		CfReportSyncStatus(SyncRootPath, mem).ThrowIfFailed();
	}

	/// <summary>Clears the previously-saved sync status.</summary>
	public void ClearSyncStatus() => CfReportSyncStatus(SyncRootPath).ThrowIfFailed();

	/// <summary>Handles the registered event.</summary>
	/// <typeparam name="T">The type contained with CF_CALLBACK_PARAMETERS.</typeparam>
	/// <param name="handler">The handler method.</param>
	/// <param name="CallbackInfo">The callback information.</param>
	/// <param name="CallbackParameters">The callback parameters.</param>
	protected virtual void HandleEvent<T>(EventHandler<CloudSyncCallbackArgs<T>>? handler, in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) where T : struct
	{
		if (handler != null && !disposed)
		{
			var args = new CloudSyncCallbackArgs<T>(CallbackInfo, CallbackParameters);
			handler.Invoke(this, args);
			if (args.OperationType != 0 && args.OpParam.HasValue)
			{
				var opInfo = args.MakeOpInfo(args.OperationType);
				var opParam = args.OpParam.Value;
				CfExecute(opInfo, ref opParam).ThrowIfFailed();
			}
		}
	}

	/// <summary>Callback to cancel an ongoing placeholder hydration.</summary>
	protected virtual void OnCancelFetchData(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(CancelFetchData, CallbackInfo, CallbackParameters);

	/// <summary>Callback to cancel a request for the contents of placeholder files.</summary>
	protected virtual void OnCancelFetchPlaceholders(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(CancelFetchPlaceholders, CallbackInfo, CallbackParameters);

	/// <summary>Callback to satisfy an I/O request, or a placeholder hydration request.</summary>
	protected virtual void OnFetchData(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(FetchData, CallbackInfo, CallbackParameters);

	/// <summary>Callback to request information about the contents of placeholder files.</summary>
	protected virtual void OnFetchPlaceholders(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(FetchPlaceholders, CallbackInfo, CallbackParameters);

	/// <summary>Callback to inform the sync provider that a placeholder under one of its sync roots is about to be dehydrated.</summary>
	protected virtual void OnNotifyDehydrate(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(NotifyDehydrate, CallbackInfo, CallbackParameters);

	/// <summary>Callback to inform the sync provider that a placeholder under one of its sync roots has been successfully dehydrated.</summary>
	protected virtual void OnNotifyDehydrateCompletion(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(NotifyDehydrateCompletion, CallbackInfo, CallbackParameters);

	/// <summary>Callback to inform the sync provider that a placeholder under one of its sync roots is about to be deleted.</summary>
	protected virtual void OnNotifyDelete(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(NotifyDelete, CallbackInfo, CallbackParameters);

	/// <summary>Callback to inform the sync provider that a placeholder under one of its sync roots has been successfully deleted.</summary>
	protected virtual void OnNotifyDeleteCompletion(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(NotifyDeleteCompletion, CallbackInfo, CallbackParameters);

	/// <summary>
	/// Callback to inform the sync provider that a placeholder under one of its sync roots that has been previously opened for
	/// read/write/delete access is now closed.
	/// </summary>
	protected virtual void OnNotifyFileCloseCompletion(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(NotifyFileCloseCompletion, CallbackInfo, CallbackParameters);

	/// <summary>
	/// Callback to inform the sync provider that a placeholder under one of its sync roots has been successfully opened for
	/// read/write/delete access.
	/// </summary>
	protected virtual void OnNotifyFileOpenCompletion(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(NotifyFileOpenCompletion, CallbackInfo, CallbackParameters);

	/// <summary>
	/// Callback to inform the sync provider that a placeholder under one of its sync roots is about to be renamed or moved.
	/// </summary>
	protected virtual void OnNotifyRename(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(NotifyRename, CallbackInfo, CallbackParameters);

	/// <summary>
	/// Callback to inform the sync provider that a placeholder under one of its sync roots has been successfully renamed or moved.
	/// </summary>
	protected virtual void OnNotifyRenameCompletion(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(NotifyRenameCompletion, CallbackInfo, CallbackParameters);

	/// <summary>Callback to validate placeholder data.</summary>
	protected virtual void OnValidateData(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters) => HandleEvent(ValidateData, CallbackInfo, CallbackParameters);

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
		callbackTable ??= new CF_CALLBACK_REGISTRATION[]
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

	private void UnregisterWithShell() => StorageProviderSyncRootManager.Unregister(SyncRootId);
}