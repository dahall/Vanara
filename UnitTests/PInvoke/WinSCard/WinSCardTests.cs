using NUnit.Framework;
using NUnit.Framework.Internal;
using static Vanara.PInvoke.WinSCard;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class WinSCardTests
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
	public void ListTest()
	{
		SCardEstablishContext(SCARD_SCOPE.SCARD_SCOPE_SYSTEM, phContext: out var ctx).ThrowIfFailed();

		SCardListReaders(ctx, null, out var readers).ThrowIfFailed();
		TestContext.WriteLine("Registerd Readers(s)\n======================\n" + (readers is null ? "None" : string.Join("\n", readers)));

		SCardListCards(ctx, null, null, out var cards).ThrowIfFailed();
		TestContext.WriteLine("Registerd Card(s)\n======================\n" + (cards is null ? "None" : string.Join("\n", cards)));

		SCardListReaderGroups(ctx, out var groups).ThrowIfFailed();
		TestContext.WriteLine("Registerd Group(s)\n======================\n" + (groups is null ? "None" : string.Join("\n", groups)));

		if (cards?.Length > 0)
		{
			SCardListInterfaces(ctx, cards[0], out var itfs).ThrowIfFailed();
			TestContext.WriteLine($"Registerd Interface(s) for {cards[0]}\n======================\n{(itfs is null ? "None" : string.Join("\n", itfs))}");
		}
	}
}