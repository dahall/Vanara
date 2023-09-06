using System.Runtime.Serialization;
using Vanara.Management;

namespace Vanara.IO;

/// <summary>Provides information about a snapshot within a VHD Set file.</summary>
[DataContract(Name = "Msvm_VHDSnapshotInformation", Namespace = @"root\virtualization\v2")]
public class VirtualDiskSnapshotInformation
{
	/// <summary>Initializes a new instance of the <see cref="VirtualDiskSnapshotInformation"/> class.</summary>
	/// <param name="vhdsFilePath">The path of the VHD Set file.</param>
	/// <param name="snapshotId">
	/// A GUID that uniquely identifies this snapshot within the VHD Set file.
	/// <para>
	/// If the supplied Snapshot Id already exists, the existing Snapshot entry will be overwritten with the new entry. Otherwise, the new
	/// entry will be added to the VHD Set file.
	/// </para>
	/// </param>
	/// <param name="resilientChangeTrackingId">The optional resilient change tracking ID associated with this snapshot.</param>
	public VirtualDiskSnapshotInformation(string vhdsFilePath, Guid snapshotId, string? resilientChangeTrackingId = null)
	{
		FilePath = vhdsFilePath;
		SnapshotId = snapshotId;
		ResilientChangeTrackingId = resilientChangeTrackingId;
	}

	/// <summary>Initializes a new instance of the <see cref="VirtualDiskSnapshotInformation"/> class.</summary>
	public VirtualDiskSnapshotInformation() { }

	/// <summary>Gets or sets the date and time of this snapshot's creation.</summary>
	[IgnoreDataMember]
	public DateTime? CreationTime
	{
		get => ManagementExtensions.CimToDateTime(CreationTimeString);
		// set => CreationTimeString = value.HasValue ? value.Value.DateTimeToCim() : null;
	}

	/// <summary>The path of the VHD Set file.</summary>
	public string? FilePath { get; set; }

	/// <summary>
	/// A list of file paths representing all of the files on which this snapshot depends. This field will be empty unless specifically
	/// requested. The first entry is the file's immediate parent, with the last entry being the root.
	/// </summary>
	public string[]? ParentPathsList { get; internal set; }

	/// <summary>Gets or sets the resilient change tracking ID, if any, associated with this snapshot.</summary>
	public string? ResilientChangeTrackingId { get; set; }

	/// <summary>A GUID that uniquely identifies this snapshot within the VHD Set file.</summary>
	[IgnoreDataMember]
	public Guid? SnapshotId
	{
		get => Guid.TryParse(Id, out var id) ? id : null;
		set => Id = value?.ToString("D");
	}

	/// <summary>The path of the file represented by this snapshot. This field may be empty if there is no file associated with this snapshot.</summary>
	public string? SnapshotPath { get; set; }

	[DataMember(Name = "CreationTime")]
	internal string? CreationTimeString { get; set; }

	[DataMember(Name = "SnapshotId")]
	internal string? Id { get; set; }

	internal static VirtualDiskSnapshotInformation Parse(string? embeddedInstance) => ManagementExtensions.Parse<VirtualDiskSnapshotInformation>(embeddedInstance);

	/// <summary>Gets the embedded instance string usable by WMI</summary>
	/// <returns>Embedded instance string usable by WMI.</returns>
	internal string GetInstanceText(string serverName = ".") => ManagementExtensions.GetInstanceText(this, serverName);
}