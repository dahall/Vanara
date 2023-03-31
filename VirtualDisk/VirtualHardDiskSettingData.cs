using System.Runtime.Serialization;

namespace Vanara.IO;

/// <summary>Contains information about a virtual hard disk file.</summary>
[DataContract(Name = "Msvm_VirtualHardDiskSettingData", Namespace = @"root\virtualization\v2")]
public class VirtualDiskSettingData
{
	/// <summary>Initializes a new <see cref="VirtualDiskSettingData"/> class.</summary>
	public VirtualDiskSettingData() { }

	/// <summary>Initializes a new <see cref="VirtualDiskSettingData"/> class.</summary>
	/// <param name="diskType">The type of the disk.</param>
	/// <param name="diskFormat">The format of the disk.</param>
	/// <param name="path">The disk's path.</param>
	public VirtualDiskSettingData(VirtualDisk.Subtype diskType, VirtualDisk.DeviceType diskFormat, string path)
	{
		DiskType = diskType;
		DiskFormat = diskFormat;
		Path = path;
	}

	/// <summary>Gets the block size of the virtual hard disk</summary>
	public uint BlockSize { get; set; }

	/// <summary>Gets the format of this disk.</summary>
	[DataMember(Name = "Format", IsRequired = true)]
	public VirtualDisk.DeviceType DiskFormat { get; set; }

	/// <summary>Gets the type of this disk.</summary>
	[DataMember(Name = "Type", IsRequired = true)]
	public VirtualDisk.Subtype DiskType { get; set; }

	/// <summary>Gets the logical sector size of the virtual hard disk</summary>
	public uint LogicalSectorSize { get; set; }

	/// <summary>Gets the disk's maximum size as viewable by the virtual machine.</summary>
	public ulong MaxInternalSize { get; set; }

	/// <summary>Gets the parent of the disk. If the disk does not have a parent this property is null.</summary>
	public string ParentPath { get; set; }

	/// <summary>Gets the path of the disk.</summary>
	[DataMember(Name = "Path", IsRequired = true)]
	public string Path { get; set; }

	/// <summary>Gets the physical sector size of the virtual hard disk</summary>
	public uint PhysicalSectorSize { get; set; }

	/// <summary>
	/// Parses the hard disk SettingData embedded instance returned from the server and creates a new VirtualHardDiskSettingData with
	/// that information.
	/// </summary>
	/// <param name="embeddedInstance">The disk SettingData embedded instance.</param>
	/// <returns>A <see cref="VirtualDiskSettingData"/> object with the data contained in the embedded instance.</returns>
	/// <exception cref="ArgumentNullException">If either param is null.</exception>
	/// <exception cref="FormatException">If there was a problem parsing the embedded instance.</exception>
	internal static VirtualDiskSettingData Parse(string embeddedInstance) => Vanara.Management.ManagementExtensions.Parse<VirtualDiskSettingData>(embeddedInstance);

	/// <summary>Gets the embedded instance string usable by WMI</summary>
	/// <returns>Embedded instance string usable by WMI.</returns>
	internal string GetInstanceText(string serverName = ".") => Vanara.Management.ManagementExtensions.GetInstanceText(this, serverName);
}