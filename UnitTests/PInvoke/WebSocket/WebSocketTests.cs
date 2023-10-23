using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using static Vanara.PInvoke.WebSocket;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class WebSocketTests
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
	public void WebSocketBeginServerHandshakeTest()
	{
		Assert.That(WebSocketCreateClientHandle(null, 0, out SafeWEB_SOCKET_HANDLE? ch), ResultIs.Successful);
		Assert.That(ch, ResultIs.ValidHandle);

		var hdrs = new[] { new WEB_SOCKET_HTTP_HEADER { pcName = "Connection", ulNameLength = 10, pcValue = "Upgrade", ulValueLength = 7 }, new WEB_SOCKET_HTTP_HEADER { pcName = "Upgrade", ulNameLength = 7, pcValue = "websocket", ulValueLength = 9 } };
		Assert.That(WebSocketBeginClientHandshake(ch, null, 0, null, 0, hdrs, (uint)hdrs.Length, out var ah), ResultIs.Successful);
		Assert.That(ah, Has.Length.GreaterThan(0));
		ah!.WriteValues();

		Assert.That(WebSocketCreateServerHandle(null, 0, out SafeWEB_SOCKET_HANDLE? sh), ResultIs.Successful);
		Assert.That(sh, ResultIs.ValidHandle);

		List<WEB_SOCKET_HTTP_HEADER> hdrl = new(ah!) { new() { pcName = "Host", ulNameLength = 4, pcValue = "localhost", ulValueLength = 9 } };
		Assert.That(WebSocketBeginServerHandshake(sh, null, null, 0, hdrl.ToArray(), (uint)hdrl.Count, out WEB_SOCKET_HTTP_HEADER[]? rh), ResultIs.Successful);
		Assert.That(rh, Has.Length.GreaterThan(0));
		rh!.WriteValues();

		Assert.That(WebSocketEndClientHandshake(ch, rh!, (uint)rh!.Length), ResultIs.Successful);

		Assert.That(WebSocketEndServerHandshake(sh), ResultIs.Successful);
	}
}