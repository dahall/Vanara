using NUnit.Framework;
using Vanara.PInvoke;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class NTStatusTests
	{
		[Test()]
		public void NTStatusTest()
		{
			var nts = new NTStatus();
			Assert.That(nts.Succeeded);
			nts = new NTStatus(0);
			Assert.That((int)nts, Is.Zero);
			nts = new NTStatus(NTStatus.STATUS_CANCELLED);
			Assert.That((int)nts, Is.EqualTo(0xC0000120));
			Assert.That(nts.Failed);
			Assert.That(nts.CustomerDefined, Is.False);
			Assert.That(nts.Code, Is.EqualTo(0x120));
			Assert.That(nts.Facility, Is.EqualTo(NTStatus.FacilityCode.FACILITY_NULL));
			Assert.That(nts.Severity, Is.EqualTo(NTStatus.SeverityLevel.STATUS_SEVERITY_ERROR));
		}

		[TestCase(NTStatus.STATUS_ACCESS_DENIED, 0xC0000022, ExpectedResult = 0)]
		[TestCase(NTStatus.STATUS_ACCESS_DENIED, 0, ExpectedResult = 1)]
		[TestCase(NTStatus.STATUS_ACCESS_DENIED, 0x22U, ExpectedResult = 1)]
		[TestCase(NTStatus.STATUS_ACCESS_DENIED, NTStatus.STATUS_ACPI_INVALID_ARGUMENT, ExpectedResult = -1)]
		[TestCase(NTStatus.STATUS_ACPI_INVALID_ARGUMENT, NTStatus.STATUS_ACCESS_DENIED, ExpectedResult = 1)]
		public int CompareToTest(int c, object obj) => new NTStatus(c).CompareTo(obj);

		[TestCase(NTStatus.STATUS_ACCESS_DENIED, NTStatus.STATUS_ACPI_INVALID_ARGUMENT, ExpectedResult = -1)]
		[TestCase(NTStatus.STATUS_ACPI_INVALID_ARGUMENT, NTStatus.STATUS_ACCESS_DENIED, ExpectedResult = 1)]
		[TestCase(NTStatus.STATUS_ACPI_INVALID_ARGUMENT, NTStatus.STATUS_ACPI_INVALID_ARGUMENT, ExpectedResult = 0)]
		public int CompareToTest1(int c1, int c2) => new NTStatus(c1).CompareTo(new NTStatus(c2));

		[Test]
		public void ComparisonTest()
		{
			NTStatus nts = NTStatus.STATUS_ACCESS_DENIED;
			Assert.That(() => nts.CompareTo(null), Throws.ArgumentException);
			Assert.That(() => nts.CompareTo("A"), Throws.Exception);
			Assert.That(() => nts.CompareTo(DateTime.Today), Throws.Exception);
		}

		[TestCase(NTStatus.STATUS_ACCESS_DENIED, 0xC0000022, ExpectedResult = true)]
		[TestCase(NTStatus.STATUS_ACCESS_DENIED, 0, ExpectedResult = false)]
		[TestCase(NTStatus.STATUS_ACCESS_DENIED, 0x22U, ExpectedResult = false)]
		[TestCase(NTStatus.STATUS_ACCESS_DENIED, NTStatus.STATUS_ACPI_INVALID_ARGUMENT, ExpectedResult = false)]
		[TestCase(NTStatus.STATUS_ACPI_INVALID_ARGUMENT, NTStatus.STATUS_ACCESS_DENIED, ExpectedResult = false)]
		[TestCase(NTStatus.STATUS_ACCESS_DENIED, "A", ExpectedResult = false)]
		[TestCase(NTStatus.STATUS_ACCESS_DENIED, int.MaxValue, ExpectedResult = false)]
		public bool EqualsTest(int c, object obj) => new NTStatus(c).Equals(obj);

		[TestCase(NTStatus.STATUS_ACCESS_DENIED, NTStatus.STATUS_ACPI_INVALID_ARGUMENT, ExpectedResult = false)]
		[TestCase(NTStatus.STATUS_ACPI_INVALID_ARGUMENT, NTStatus.STATUS_ACCESS_DENIED, ExpectedResult = false)]
		[TestCase(NTStatus.STATUS_ACPI_INVALID_ARGUMENT, NTStatus.STATUS_ACPI_INVALID_ARGUMENT, ExpectedResult = true)]
		public bool EqualsTest1(int c1, int c2) => new NTStatus(c1).Equals(new NTStatus(c2));

		[Test]
		public void GetExceptionTest()
		{
			Assert.That(new NTStatus().GetException(), Is.Null);
			Assert.That(new NTStatus(NTStatus.STATUS_ACCESS_DENIED).GetException(), Is.TypeOf<UnauthorizedAccessException>());
			Assert.That(new NTStatus(NTStatus.STATUS_ACPI_INVALID_ARGUMENT).GetException(), Is.TypeOf<Win32Exception>());
			Assert.That(new NTStatus(NTStatus.STATUS_ACPI_INVALID_ARGUMENT).GetException("Bad"), Has.Message.EqualTo("Bad"));
			Assert.That(new NTStatus(NTStatus.DBG_CONTROL_C).GetException(), Is.Null);
			Assert.That(NTStatus.Make(NTStatus.SeverityLevel.STATUS_SEVERITY_ERROR, true, 0U, 0x22).GetException(), Is.InstanceOf<Exception>());
		}

		[Test()]
		public void IConvTest()
		{
			NTStatus nts = NTStatus.STATUS_ACCESS_DENIED;
			var c = (IConvertible)nts;
			var cv = (IConvertible)NTStatus.STATUS_ACCESS_DENIED;
			var f = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
			Assert.That(c.GetTypeCode(), Is.EqualTo(cv.GetTypeCode()));
			Assert.That(() => c.ToChar(f), Throws.Exception);
			Assert.That(() => c.ToSByte(f), Throws.Exception);
			Assert.That(() => c.ToByte(f), Throws.Exception);
			Assert.That(() => c.ToInt16(f), Throws.Exception);
			Assert.That(() => c.ToUInt16(f), Throws.Exception);
			Assert.That(() => c.ToInt32(f), Throws.Exception);
			Assert.That(c.ToUInt32(f), Is.EqualTo(cv.ToUInt32(f)));
			Assert.That(c.ToInt64(f), Is.EqualTo(cv.ToInt64(f)));
			Assert.That(c.ToUInt64(f), Is.EqualTo(cv.ToUInt64(f)));
			Assert.That(c.ToSingle(f), Is.EqualTo(cv.ToSingle(f)));
			Assert.That(c.ToDouble(f), Is.EqualTo(cv.ToDouble(f)));
			Assert.That(c.ToDecimal(f), Is.EqualTo(cv.ToDecimal(f)));
			Assert.That(c.ToBoolean(f), Is.EqualTo(nts.Succeeded));
			Assert.That(() => c.ToDateTime(f), Throws.Exception);
			Assert.That(c.ToString(f), Is.EqualTo("STATUS_ACCESS_DENIED"));
			Assert.That(c.ToType(typeof(int), f), Is.EqualTo(cv.ToType(typeof(int), f)));
		}

		[Test]
		public void MakeTest()
		{
			NTStatus nts = NTStatus.STATUS_ACCESS_DENIED;
			Assert.That(NTStatus.Make(NTStatus.SeverityLevel.STATUS_SEVERITY_ERROR, false, NTStatus.FacilityCode.FACILITY_NULL, 0x22), Is.EqualTo(nts));
			Assert.That(NTStatus.Make(NTStatus.SeverityLevel.STATUS_SEVERITY_ERROR, false, 0U, 0x22), Is.EqualTo(nts));
		}

		[Test()]
		public void OpTest()
		{
			NTStatus nts = NTStatus.STATUS_ACCESS_DENIED;
			Assert.That((int)nts, Is.EqualTo(unchecked((int)0xC0000022)));
			Assert.That((NTStatus)unchecked((int)0xC0000022), Is.EqualTo(nts));
			Assert.That(nts != (NTStatus)unchecked((int)0xC0000021));
			Assert.That(nts != 0x22);
			Assert.That(nts == unchecked((int)0xC0000022));
			Assert.That(nts.GetHashCode(), Is.Not.Zero);
			Assert.That(new NTStatus(NTStatus.STATUS_SUCCESS).GetHashCode(), Is.Zero);
		}

		[Test]
		public void ThrowIfFailedTest()
		{
			NTStatus nts = NTStatus.STATUS_ACCESS_DENIED;
			Assert.That(() => nts.ThrowIfFailed(), Throws.Exception);
			Assert.That(() => nts.ThrowIfFailed("Bad"), Throws.TypeOf<UnauthorizedAccessException>().With.Message.EqualTo("Bad"));
			Assert.That(() => NTStatus.ThrowIfFailed(0), Throws.Nothing);
		}

		[TestCase(NTStatus.STATUS_ACPI_INVALID_ARGUMENT, ExpectedResult = "STATUS_ACPI_INVALID_ARGUMENT")]
		[TestCase(NTStatus.STATUS_ACCESS_DENIED, ExpectedResult = "STATUS_ACCESS_DENIED")]
		[TestCase(0xC0000022, ExpectedResult = "STATUS_ACCESS_DENIED")]
		[TestCase(0x80990003, ExpectedResult = "0x80990003")]
		[TestCase(0x80079254, ExpectedResult = "0x80079254")]
		public string ToStringTest(int c) => new NTStatus(c).ToString();
	}
}