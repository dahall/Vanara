using System.Runtime.Serialization;
using Vanara.Management;

namespace Vanara.IO;

/// <summary>Provides information about a VHD Set file.</summary>
[DataContract(Name = "Msvm_VHDSetInformation", Namespace = @"root\virtualization\v2")]
public class VirtualDiskSetInformation
{
	/// <summary>
	/// A list of all files encompassed by the VHD Set file, including any unreferenced files and any parents of the root virtual hard
	/// disk. All files listed after the root virtual hard disk are unmanaged by this VHD Set file. This field may be empty if this
	/// information was not specifically requested.
	/// </summary>
	public string[]? AllPaths { get; internal set; }

	/// <summary>The path of the VHD Set file.</summary>
	public string? Path { get; internal set; }

	/// <summary>A list of GUIDs representing all of the snapshots contained by this VHD Set file.</summary>
	[IgnoreDataMember]
	public Guid[] SnapshotIdList => Ids is null ? new Guid[0] : Array.ConvertAll(Ids, s => Guid.Parse(s));

	[DataMember(Name = "SnapshotIdList")]
	internal string[]? Ids { get; set; }

	internal static VirtualDiskSetInformation Parse(string? embeddedInstance) => ManagementExtensions.Parse<VirtualDiskSetInformation>(embeddedInstance);
}