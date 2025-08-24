﻿using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class ErrHandlingApiTests
{
	private StringBuilder sb = new(4096, 4096);

	[OneTimeSetUp]
	public void _Setup()
	{
	}

	[SetUp]
	public void _TestSetup() => sb.Clear();

	//[Test]
	public void AddVectoredContinueHandlerTest()
	{
		using SafeContinueHandlerHandle h = AddVectoredContinueHandler(0, VectoredHandler);
		Assert.That(h.IsInvalid, Is.False);
	}

	public static uint VectoredHandler(ref EXCEPTION_POINTERS _) => 0xffffffff;

	//[Test]
	public void AddVectoredExceptionHandlerTest()
	{
		using SafeExceptionHandlerHandle h = AddVectoredExceptionHandler(0, VectoredHandler);
		Assert.That(h.IsInvalid, Is.False);
	}

	[Test]
	public void FormatMessageStringTest()
	{
		string[] objs = ["Alan", "Bob", "Chuck", "Dave", "Ed", "Frank", "Gary", "Harry"];
		Assert.That(FormatMessage(null, objs), Is.Null);
		Assert.That(FormatMessage("X", null), Is.EqualTo("X"));
		Assert.That(FormatMessage("X", objs), Is.EqualTo("X"));
		Assert.That(FormatMessage("X %1", new[] { "YZ" }), Is.EqualTo("X YZ"));
		string? s = FormatMessage("%1 %2 %3 %4 %5 %6 %7 %8", objs);
		Assert.That(s, Is.EqualTo(string.Join(" ", objs)));
		s = FormatMessage("%1 %2", [4, "Alan"], FormatMessageFlags.FORMAT_MESSAGE_IGNORE_INSERTS);
		Assert.That(s, Is.EqualTo("%1 %2"));
		//s = FormatMessage("%1!*.*s! %4 %5!*s!", new object[] { 4, 2, "Bill", "Bob", 6, "Bill" });
		//Assert.That(s, Is.EqualTo("  Bi Bob   Bill"));
		s = FormatMessage("%1 %2 %3 %4 %5 %6", [4, 2, "Bill", "Bob", 6, "Bill"]);
		Assert.That(s, Is.EqualTo("\u0004 \u0002 Bill Bob \u0006 Bill"));
	}

	[Test]
	public void FormatMessageWinErrTest()
	{
		string s = FormatMessage(Win32Error.ERROR_INVALID_PARAMETER);
		Assert.That(s, Is.Not.Null);
		TestContext.WriteLine(s);
	}

	[Test]
	public void FormatMessageWinErrTest2()
	{
		string s = FormatMessage(Win32Error.ERROR_BAD_EXE_FORMAT, ["Test.exe"]);
		Assert.That(s, Contains.Substring("Test.exe"));
		TestContext.WriteLine(s);
	}

	[Test]
	public void FormatMessageLibStrTest()
	{
		using SafeHINSTANCE hLib = LoadLibraryEx(@"aadWamExtension.dll", dwFlags: LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE);
		string s = FormatMessage(0xb00003f7, new[] { "Fred", "Alice" }, hLib);
		Assert.That(s, Contains.Substring("Alice"));
		TestContext.WriteLine(s);
	}

	[Test]
	public void GetSetErrorModeTest()
	{
		SEM sem = 0;
		Assert.That(() => sem = GetErrorMode(), Throws.Nothing);
		Assert.That(SetErrorMode(SEM.SEM_FAILCRITICALERRORS), Is.EqualTo(sem));
		SetErrorMode(sem);
	}

	[Test]
	public void GetSetLastErrorTest()
	{
		SetLastError(Win32Error.ERROR_INVALID_PARAMETER);
		Assert.That(GetLastError(), Is.EqualTo(Win32Error.ERROR_INVALID_PARAMETER));
		RestoreLastError(Win32Error.ERROR_SUCCESS);
		Assert.That(GetLastError(), Is.EqualTo(Win32Error.ERROR_SUCCESS));
	}

	[Test]
	public void GetSetThreadErrorModeTest()
	{
		SEM sem = 0;
		Assert.That(() => sem = GetThreadErrorMode(), Throws.Nothing);
		Assert.That(SetThreadErrorMode(SEM.SEM_FAILCRITICALERRORS, out SEM old), Is.True);
		Assert.That(sem, Is.EqualTo(old));
		SetThreadErrorMode(sem, out _);
	}
}