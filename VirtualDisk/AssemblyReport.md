## Assembly report for Vanara.VirtualDisk.dll
.NET classes to manage Windows Virtual Storage (VHD and VHDX) using P/Invoke functions from VirtDisk.dll.
### Enumerations
Enum | Description | Values
---- | ---- | ----
[Vanara.IO.VirtualDisk.CompactionMode](https://github.com/dahall/Vanara/search?l=C%23&q=CompactionMode) | Compaction options for `Vanara.IO.VirtualDisk.CompactAsync(Vanara.IO.VirtualDisk.CompactionMode,System.Threading.CancellationToken,System.IProgress{System.Int32})`. | Full, Quick, Retrim, Pretrimmed, Prezeroed
[Vanara.IO.VirtualDisk.DeviceType](https://github.com/dahall/Vanara/search?l=C%23&q=DeviceType) | Represents the format of the virtual disk. | Unknown, Iso, Vhd, Vhdx, VhdSet
[Vanara.IO.VirtualDisk.Subtype](https://github.com/dahall/Vanara/search?l=C%23&q=Subtype) | Represents the subtype of a virtual disk. | Fixed, Dynamic, Differencing
### Classes
Class | Description
---- | ----
[Vanara.IO.VirtualDisk](https://github.com/dahall/Vanara/search?l=C%23&q=VirtualDisk) | Class that represents a virtual disk and allows for performing actions on it. This wraps most of the methods found in virtdisk.h.
[Vanara.IO.VirtualDisk.VirtualDiskMetadata](https://github.com/dahall/Vanara/search?l=C%23&q=VirtualDiskMetadata) | Supports getting and setting metadata on a virtual disk.
[Vanara.IO.VirtualDiskSetInformation](https://github.com/dahall/Vanara/search?l=C%23&q=VirtualDiskSetInformation) | Provides information about a VHD Set file.
[Vanara.IO.VirtualDiskSettingData](https://github.com/dahall/Vanara/search?l=C%23&q=VirtualDiskSettingData) | Contains information about a virtual hard disk file.
[Vanara.IO.VirtualDiskSnapshotInformation](https://github.com/dahall/Vanara/search?l=C%23&q=VirtualDiskSnapshotInformation) | Provides information about a snapshot within a VHD Set file.
