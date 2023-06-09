using NUnit.Framework;
using System;
using System.IO;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Kernel32;
using FileAccess = Vanara.PInvoke.Kernel32.FileAccess;

namespace Kernel32;

[TestFixture]
public class IoApiSetTests
{
	private const string vol = @"\\.\PhysicalDrive0";

	[Test]
	public void DeviceIoControlNoInOutTest()
	{
		using SafeHFILE hFile = CreateFile(vol, FileAccess.GENERIC_READ, FileShare.Read,
			default, FileMode.Open, 0);
		Assert.That(hFile, ResultIs.ValidHandle);
		Assert.False(DeviceIoControl(hFile, IOControlCode.FSCTL_IS_VOLUME_MOUNTED));
	}

	[Test]
	public void DeviceIoControlOutAndInTest()
	{
		using SafeHFILE hFile = CreateFile(TestCaseSources.WordDoc, FileAccess.GENERIC_READ | FileAccess.GENERIC_WRITE,
			FileShare.None, default, FileMode.Open, 0);
		Assert.That(hFile, ResultIs.ValidHandle);

		Assert.That(DeviceIoControl(hFile, IOControlCode.FSCTL_GET_COMPRESSION, out COMPRESSION_FORMAT compr), ResultIs.Successful);
		Assert.That(DeviceIoControl(hFile, IOControlCode.FSCTL_SET_COMPRESSION, compr == COMPRESSION_FORMAT.COMPRESSION_FORMAT_NONE ? COMPRESSION_FORMAT.COMPRESSION_FORMAT_DEFAULT : COMPRESSION_FORMAT.COMPRESSION_FORMAT_NONE), ResultIs.Successful);
		Assert.That(DeviceIoControl(hFile, IOControlCode.FSCTL_GET_COMPRESSION, out COMPRESSION_FORMAT newcompr), ResultIs.Successful);
		Assert.That(compr, Is.Not.EqualTo(newcompr));
		Assert.That(DeviceIoControl(hFile, IOControlCode.FSCTL_SET_COMPRESSION, compr), ResultIs.Successful);
	}

	[Test]
	public void StorageAdapterSerialNumberPropertyTest()
	{
		TestContext.WriteLine(vol + ":");
		using SafeHFILE hdisk = CreateFile(vol.TrimEnd('\\'), 0, FileShare.ReadWrite, null, FileMode.Open, 0);
		Assert.IsFalse(hdisk.IsInvalid);

		STORAGE_PROPERTY_QUERY query = new(STORAGE_PROPERTY_ID.StorageAdapterSerialNumberProperty);
		Assert.That(DeviceIoControl(hdisk, IOControlCode.IOCTL_STORAGE_QUERY_PROPERTY, query, out STORAGE_ADAPTER_SERIAL_NUMBER outVar),
			ResultIs.Successful);
		outVar.WriteValues();

		TestContext.WriteLine(new string('=', 20));
	}

	[Test]
	public void StorageDeviceManagementStatusTest()
	{
		TestContext.WriteLine(vol + ":");
		using SafeHFILE hdisk = CreateFile(vol.TrimEnd('\\'), 0, FileShare.ReadWrite, null, FileMode.Open, 0);
		Assert.IsFalse(hdisk.IsInvalid);

		STORAGE_PROPERTY_QUERY query = new(STORAGE_PROPERTY_ID.StorageDeviceManagementStatus);
		Assert.That(DeviceIoControl(hdisk, IOControlCode.IOCTL_STORAGE_QUERY_PROPERTY, query, out STORAGE_DEVICE_MANAGEMENT_STATUS outVar),
			ResultIs.Successful);
		Assert.IsTrue(outVar.Health.HasFlag(STORAGE_DISK_HEALTH_STATUS.DiskHealthHealthy));
		Assert.That(outVar.NumberOfOperationalStatus, Is.GreaterThan(0));
		for (int i = 0; i < outVar.NumberOfOperationalStatus; i++)
			Assert.IsTrue(outVar.OperationalStatus[i].HasFlag(STORAGE_DISK_OPERATIONAL_STATUS.DiskOpStatusOk));
		outVar.WriteValues();

		TestContext.WriteLine(new string('=', 20));
	}

	// Courtesy of @elf2k00
	[Test]
	public void StorageDevicePropertyTest()
	{
		TestContext.WriteLine(vol + ":");
		using SafeHFILE hdisk = CreateFile(vol.TrimEnd('\\'), 0, FileShare.ReadWrite, null, FileMode.Open, 0);
		Assert.IsFalse(hdisk.IsInvalid);

		STORAGE_PROPERTY_QUERY query = new(STORAGE_PROPERTY_ID.StorageDeviceProperty);
		Assert.That(DeviceIoControl(hdisk, IOControlCode.IOCTL_STORAGE_QUERY_PROPERTY, query, out STORAGE_DESCRIPTOR_HEADER sdh),
			ResultIs.Successful);
		Assert.That(DeviceIoControl(hdisk, IOControlCode.IOCTL_STORAGE_QUERY_PROPERTY, query, out STORAGE_DEVICE_DESCRIPTOR_MGD outVar, sdh.Size),
			ResultIs.Successful);
		Assert.IsTrue(Enum.IsDefined(typeof(STORAGE_BUS_TYPE), outVar.BusType));
		outVar.WriteValues();

		TestContext.WriteLine(new string('=', 20));
	}

	[Test]
	public void StorageDeviceUniqueIdPropertyTest()
	{
		TestContext.WriteLine(vol + ":");
		using SafeHFILE hdisk = CreateFile(vol.TrimEnd('\\'), 0, FileShare.ReadWrite, null, FileMode.Open, 0);
		Assert.IsFalse(hdisk.IsInvalid);

		STORAGE_PROPERTY_QUERY query = new(STORAGE_PROPERTY_ID.StorageDeviceUniqueIdProperty);
		Assert.That(DeviceIoControl(hdisk, IOControlCode.IOCTL_STORAGE_QUERY_PROPERTY, query, out STORAGE_DESCRIPTOR_HEADER sdh),
		ResultIs.Successful);
		Assert.That(DeviceIoControl(hdisk, IOControlCode.IOCTL_STORAGE_QUERY_PROPERTY, query, out STORAGE_DEVICE_UNIQUE_IDENTIFIER_MGD outVar, sdh.Size),
			ResultIs.Successful);
		outVar.WriteValues();

		TestContext.WriteLine(new string('=', 20));
	}

	[Test]
	public void StructSizeTest() => typeof(Vanara.PInvoke.Kernel32).GetNestedStructSizes().WriteValues();
}