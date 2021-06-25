using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using static Vanara.PInvoke.WinBio;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class WinBioTests
	{
		[OneTimeSetUp]
		public void _Setup()
		{
		}

		[OneTimeTearDown]
		public void _TearDown()
		{
		}

		[Test]
		public void StructTest() => TestHelper.GetNestedStructSizes(typeof(Vanara.PInvoke.WinBio)).WriteValues();

		[Test]
		public void WinBioCaptureSampleTest()
		{
			// Connect to the system pool. 
			var hr = WinBioOpenSession(WINBIO_BIOMETRIC_TYPE.WINBIO_TYPE_FINGERPRINT, // Service provider
				WINBIO_POOL_TYPE.WINBIO_POOL_SYSTEM, // Pool type
				WINBIO_SESSION_FLAGS.WINBIO_FLAG_RAW, // Access: Capture raw data
				default, // Array of biometric unit IDs
				0, // Count of biometric unit IDs
				WINBIO_DB_DEFAULT, // Default database
				out var sessionHandle); // [out] Session handle
			Assert.That(hr, ResultIs.Successful);

			// Capture a biometric sample.
			hr = WinBioCaptureSample(sessionHandle,
				WINBIO_BIR_PURPOSE.WINBIO_NO_PURPOSE_AVAILABLE,
				WINBIO_BIR_DATA_FLAGS.WINBIO_DATA_FLAG_RAW,
				out var unitId,
				out var sample,
				out var sampleSize,
				out var rejectDetail);
			Assert.That(hr, ResultIs.Successful);
			Assert.IsFalse(sample.IsInvalid);

			var value = sample.ToStructure<WINBIO_BIR>(sampleSize);
			WINBIO_BIR_HEADER BirHeader = sample.ToStructure<WINBIO_BIR_HEADER>(sampleSize, value.HeaderBlock.Offset);
			BirHeader.WriteValues();
			WINBIO_BDB_ANSI_381_HEADER AnsiBdbHeader = sample.ToStructure<WINBIO_BDB_ANSI_381_HEADER>(sampleSize, value.StandardDataBlock.Offset);
			AnsiBdbHeader.WriteValues();
			WINBIO_BDB_ANSI_381_RECORD AnsiBdbRecord = sample.ToStructure<WINBIO_BDB_ANSI_381_RECORD>(sampleSize, value.StandardDataBlock.Offset + (uint)Marshal.SizeOf(typeof(WINBIO_BDB_ANSI_381_HEADER)));
			AnsiBdbRecord.WriteValues();

			//int width = AnsiBdbRecord.HorizontalLineLength; // Width of image in pixels
			//int height = AnsiBdbRecord.VerticalLineLength; // Height of image in pixels

			//IntPtr firstPixel = ((IntPtr)sample).Offset(sample.Value.StandardDataBlock.Offset + Marshal.SizeOf(typeof(WINBIO_BDB_ANSI_381_HEADER)) + Marshal.SizeOf(typeof(WINBIO_BDB_ANSI_381_RECORD)));

			//Bitmap bmp = new Bitmap(width, height, 3 * width, System.Drawing.Imaging.PixelFormat.Format24bppRgb, firstPixel);
			//using var tmp = new TempFile(null);
			//bmp.Save(tmp.FullName);
		}

		[Test]
		public void WinBioGetPropertyTest()
		{
			var hr = WinBioOpenSession(WINBIO_BIOMETRIC_TYPE.WINBIO_TYPE_FINGERPRINT, // Service provider
				WINBIO_POOL_TYPE.WINBIO_POOL_SYSTEM, // Pool type
				WINBIO_SESSION_FLAGS.WINBIO_FLAG_RAW, // Access: Capture raw data
				default, // Array of biometric unit IDs
				0, // Count of biometric unit IDs
				WINBIO_DB_DEFAULT, // Default database
				out var sessionHandle); // [out] Session handle
			Assert.That(hr, ResultIs.Successful);

			Assert.That(WinBioLocateSensor(sessionHandle, out var unitId), ResultIs.Successful);

			Assert.That(WinBioGetProperty(sessionHandle, WINBIO_PROPERTY_TYPE.WINBIO_PROPERTY_TYPE_UNIT, WINBIO_PROPERTY_ID.WINBIO_PROPERTY_EXTENDED_SENSOR_INFO,
				unitId, default, WINBIO_BIOMETRIC_SUBTYPE.WINBIO_SUBTYPE_NO_INFORMATION, out var propBuf, out var propSize), ResultIs.Successful);

			Assert.That((long)propSize, Is.GreaterThan(0L));
		}
	}
}