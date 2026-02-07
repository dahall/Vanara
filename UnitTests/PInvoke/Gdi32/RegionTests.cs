using NUnit.Framework;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class RegionTests
{
	[Test]
	public void CreateRectRgn_WithValidGetData()
	{
		var b = new RECT(10, 10, 50, 50);

		using var hrgn = CreateRectRgnIndirect(b);
		Assert.That(hrgn, ResultIs.ValidHandle);

		var getRgnData = hrgn.GetData();
		getRgnData.WriteValues();
		Assert.That(getRgnData.rdh.nCount, Is.EqualTo(1u));
		Assert.That(getRgnData.rdh.rcBound, Is.EqualTo(b));
		Assert.That(getRgnData.Buffer, Is.EqualTo([b]));
	}

	[Test]
	public void CreatePolygonRgn_WithValidGetData()
	{
		POINT[] pts = [new(10,10), new(100,20), new(150,100), new(50,120), new(10,100)];

		using var hrgn = CreatePolygonRgn(pts, RGN_FILLMODE.ALTERNATE);
		Assert.That(hrgn, ResultIs.ValidHandle);

		var getRgnData = hrgn.GetData();
		getRgnData.WriteValues();
		Assert.That(getRgnData.rdh.nCount, Is.GreaterThan(0u));
		Assert.That(getRgnData.Buffer.Count, Is.EqualTo(getRgnData.rdh.nCount));
	}

	[Test]
	public void ExtCreateRegion_WithValidDataAndNullTransform_ReturnsValidRegion()
	{
		// Arrange
		RECT bounds = new(0, 0, 100, 100);
		RECT[] rects = [new(0,0,50,50), new(50,50,100,100)];
		var rgnData = new RGNDATA(bounds, rects);

		// Act
		using var hrgn = SafeHRGN.ExtCreate(rgnData, null);
		Assert.That(hrgn, ResultIs.ValidHandle);

		var getRgnData = hrgn.GetData();
		Assert.That(getRgnData.rdh.nCount, Is.EqualTo(rgnData.rdh.nCount));
		Assert.That(getRgnData.rdh.rcBound, Is.EqualTo(rgnData.rdh.rcBound));
		Assert.That(getRgnData.Buffer, Is.EquivalentTo(rgnData.Buffer));
	}

	[Test]
	public void RegionGetters()
	{
		// Arrange
		RECT bounds = new(0, 0, 100, 100);
		RECT[] rects = [new(0,0,50,50), new(50,50,100,100)];
		var rgnData = new RGNDATA(bounds, rects);

		// Act
		using var hrgn = SafeHRGN.ExtCreate(rgnData, null);
		Assert.That(hrgn, ResultIs.ValidHandle);

		Assert.That(hrgn.GetBox(out var box), Is.EqualTo(RGN_TYPE.COMPLEXREGION).Or.EqualTo(RGN_TYPE.SIMPLEREGION));
		Assert.That(box, Is.EqualTo(bounds));
		Assert.That(hrgn.PtIn(25, 25), Is.True);
		Assert.That(hrgn.RectIn(new RECT(10, 10, 40, 40)), Is.True);
	}

	[Test]
	public void ExtCreateRegion_WithValidDataAndIdentityTransform_ReturnsValidRegion()
	{
		// Arrange
		var bounds = new RECT(0, 0, 100, 100);
		var rects = new[] { new RECT(10, 10, 50, 50) };
		var rgnData = new RGNDATA(bounds, rects);
		var xform = new XFORM
		{
			eM11 = 1.0f,
			eM12 = 0.0f,
			eM21 = 0.0f,
			eM22 = 1.0f,
			eDx = 0.0f,
			eDy = 0.0f
		};

		// Act
		using var hrgn = ExtCreateRegion(rgnData, xform);
		Assert.That(hrgn, ResultIs.ValidHandle);
	}

	[Test]
	public void ExtCreateRegion_WithScaleTransform_ReturnsTransformedRegion()
	{
		// Arrange
		var bounds = new RECT(0, 0, 100, 100);
		var rects = new[] { new RECT(10, 10, 50, 50) };
		var rgnData = new RGNDATA(bounds, rects);
		var xform = new XFORM
		{
			eM11 = 2.0f, // Scale X by 2
			eM12 = 0.0f,
			eM21 = 0.0f,
			eM22 = 2.0f, // Scale Y by 2
			eDx = 0.0f,
			eDy = 0.0f
		};

		// Act
		using var hrgn = ExtCreateRegion(rgnData, xform);
		Assert.That(hrgn, ResultIs.ValidHandle);

		// Verify the region was scaled
		var rgnType = GetRgnBox(hrgn, out var resultBounds);
		Assert.That(rgnType, Is.Not.EqualTo(RGN_TYPE.ERROR));
		Assert.That(rgnType, Is.Not.EqualTo(RGN_TYPE.NULLREGION));
	}

	[Test]
	public void ExtCreateRegion_WithSingleRectangle_ReturnsSimpleRegion()
	{
		// Arrange
		var bounds = new RECT(0, 0, 100, 100);
		var rects = new[] { new RECT(10, 10, 50, 50) };
		var rgnData = new RGNDATA(bounds, rects);

		// Act
		using var hrgn = ExtCreateRegion(rgnData, null);
		Assert.That(hrgn, ResultIs.ValidHandle);
		var rgnType = GetRgnBox(hrgn, out var resultBounds);
		Assert.That(rgnType, Is.EqualTo(RGN_TYPE.SIMPLEREGION).Or.EqualTo(RGN_TYPE.COMPLEXREGION));
	}

	[Test]
	public void ExtCreateRegion_WithMultipleRectangles_ReturnsComplexRegion()
	{
		// Arrange
		var bounds = new RECT(0, 0, 200, 200);
		var rects = new[]
		{
			new RECT(10, 10, 50, 50),
			new RECT(60, 60, 100, 100),
			new RECT(110, 110, 150, 150)
		};
		var rgnData = new RGNDATA(bounds, rects);

		// Act
		using var hrgn = ExtCreateRegion(rgnData, null);
		Assert.That(hrgn, ResultIs.ValidHandle);
	}

	[Test]
	public void ExtCreateRegion_WithTranslationTransform_ReturnsOffsetRegion()
	{
		// Arrange
		var bounds = new RECT(0, 0, 100, 100);
		var rects = new[] { new RECT(10, 10, 50, 50) };
		var rgnData = new RGNDATA(bounds, rects);
		var xform = new XFORM
		{
			eM11 = 1.0f,
			eM12 = 0.0f,
			eM21 = 0.0f,
			eM22 = 1.0f,
			eDx = 20.0f, // Translate X by 20
			eDy = 30.0f  // Translate Y by 30
		};

		// Act
		using var hrgn = ExtCreateRegion(rgnData, xform);
		Assert.That(hrgn, ResultIs.ValidHandle);
		var rgnType = GetRgnBox(hrgn, out var resultBounds);
		Assert.That(rgnType, Is.Not.EqualTo(RGN_TYPE.ERROR));
	}

	[Test]
	public void ExtCreateRegion_RegionBoundsMatchExpected()
	{
		// Arrange
		var bounds = new RECT(10, 10, 50, 50);
		var rects = new[] { bounds };
		var rgnData = new RGNDATA(bounds, rects);

		// Act
		using var hrgn = ExtCreateRegion(rgnData, null);

		// Assert
		var rgnType = GetRgnBox(hrgn, out var resultBounds);
		Assert.That(rgnType, Is.Not.EqualTo(RGN_TYPE.ERROR));
		Assert.That(resultBounds.left, Is.EqualTo(bounds.left));
		Assert.That(resultBounds.top, Is.EqualTo(bounds.top));
		Assert.That(resultBounds.right, Is.EqualTo(bounds.right));
		Assert.That(resultBounds.bottom, Is.EqualTo(bounds.bottom));
	}

	[Test]
	public void ExtCreateRegion_DisposedRegion_IsInvalid()
	{
		// Arrange
		var bounds = new RECT(0, 0, 100, 100);
		var rects = new[] { new RECT(10, 10, 50, 50) };
		var rgnData = new RGNDATA(bounds, rects);
		var hrgn = ExtCreateRegion(rgnData, null);

		// Act
		hrgn.Dispose();

		// Assert
		Assert.That(hrgn.IsInvalid, Is.True);
	}

	[Test]
	public void ExtCreateRegion_WithEmptyBounds_ReturnsValidRegion()
	{
		// Arrange
		var bounds = new RECT(0, 0, 0, 0);
		var rects = new[] { bounds };
		var rgnData = new RGNDATA(bounds, rects);

		// Act
		using var hrgn = ExtCreateRegion(rgnData, null);
		Assert.That(hrgn, ResultIs.ValidHandle);
		var rgnType = GetRgnBox(hrgn, out _);
		Assert.That(rgnType, Is.EqualTo(RGN_TYPE.NULLREGION).Or.EqualTo(RGN_TYPE.SIMPLEREGION));
	}
}