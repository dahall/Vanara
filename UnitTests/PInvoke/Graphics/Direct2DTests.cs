using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.D2d1;

namespace Vanara.PInvoke.Tests;

public class Direct2DTests
{
	[Test]
	public void DXGITest()
	{
		using var pFactory = ComReleaserFactory.Create(D2D1CreateFactory<ID2D1Factory>());

		using var form = new System.Windows.Forms.Form { Text = "Sample App" };
	}
}