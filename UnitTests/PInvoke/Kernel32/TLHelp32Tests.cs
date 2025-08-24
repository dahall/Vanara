﻿using NUnit.Framework;
using System.Linq;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class TLHelp32Tests
{
	private static readonly SafeHSNAPSHOT hsnap = CreateToolhelp32Snapshot(TH32CS.TH32CS_SNAPALL | TH32CS.TH32CS_SNAPMODULE32);

	[Test]
	public void Heap32ListFirstTest() => Assert.That(() =>
											  {
												  HEAPLIST32[] heaplists = hsnap.EnumHeap32List().ToArray();
												  Assert.That(heaplists, Is.Not.Empty);
												  foreach (HEAPLIST32 h in heaplists)
													  Assert.That(h.EnumHeapEntries().ToArray(), Is.Not.Empty);
											  }, Throws.Nothing);

	[Test]
	public void Module32FirstTest() => Assert.That(() =>
											{
												Assert.That(hsnap.EnumModule32().ToArray(), Is.Not.Empty);
											}, Throws.Nothing);

	[Test]
	public void Process32FirstTest() => Assert.That(() =>
											 {
												 Assert.That(hsnap.EnumProcess32().ToArray(), Is.Not.Empty);
											 }, Throws.Nothing);

	[Test]
	public void Thread32FirstTest() => Assert.That(() =>
											{
												Assert.That(hsnap.EnumThread32().ToArray(), Is.Not.Empty);
											}, Throws.Nothing);

	[Test]
	public void Toolhelp32ReadProcessMemoryTest() => throw new NotImplementedException("No documentation on how.");//Assert.That(Toolhelp32ReadProcessMemory(), Is.True);
}