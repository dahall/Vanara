using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using static Vanara.PInvoke.UIAnimation;

namespace Vanara.PInvoke.Tests;
[TestFixture]
public class UIAnimationTests
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
	public void Test()
	{
		var evt = new VarEvent(TestContext.Out);

		// Manager
		IUIAnimationManager mgr = new();
		Assert.That(mgr.GetStatus(), Is.EqualTo(UI_ANIMATION_MANAGER_STATUS.UI_ANIMATION_MANAGER_IDLE));
		mgr.SetManagerEventHandler(evt);

		// Variable
		var aniVar = mgr.CreateAnimationVariable(5.0);
		Assert.That(aniVar.GetValue(), Is.EqualTo(5.0));
		Assert.That(aniVar.GetIntegerValue(), Is.EqualTo(5));

		aniVar.SetVariableChangeHandler(evt);
		aniVar.SetVariableIntegerChangeHandler(evt);
		aniVar.SetLowerBound(0.0);
		aniVar.SetUpperBound(10.0);
		aniVar.SetRoundingMode(UI_ANIMATION_ROUNDING_MODE.UI_ANIMATION_ROUNDING_FLOOR);
		aniVar.SetTag(null, 55);
		aniVar.GetTag(out uint? tag);
		Assert.That(tag, Is.EqualTo(55));
		aniVar.GetTag(out object? otag);
		Assert.That(otag, Is.Null);

		var aniVarFetch = mgr.GetVariableFromTag(null, 55);
		Assert.That(aniVarFetch, Is.Not.Null);

		// Timer
		IUIAnimationTimer timer = new();
		timer.SetTimerEventHandler(evt);
		timer.SetTimerUpdateHandler(evt, UI_ANIMATION_IDLE_BEHAVIOR.UI_ANIMATION_IDLE_BEHAVIOR_CONTINUE);
		Assert.That((int)timer.IsEnabled(), Is.EqualTo(HRESULT.S_FALSE));
		timer.Enable();
		Assert.That((int)timer.IsEnabled(), Is.EqualTo(HRESULT.S_OK));

		// Storyboard
		var sb = mgr.CreateStoryboard();
		var trans = new IUIAnimationTransitionLibrary().CreateConstantTransition(0.1);
		sb.AddTransition(aniVar, trans);
		sb.Schedule(timer.GetTime());

		Thread.SpinWait(10);

		mgr.Shutdown();
	}

	public class VarEvent(System.IO.TextWriter output) : IUIAnimationVariableChangeHandler, IUIAnimationVariableIntegerChangeHandler,
		IUIAnimationManagerEventHandler, IUIAnimationTimerEventHandler, IUIAnimationTimerUpdateHandler
	{
		public HRESULT OnManagerStatusChanged(UI_ANIMATION_MANAGER_STATUS newStatus, UI_ANIMATION_MANAGER_STATUS previousStatus)
		{
			output.WriteLine($"Manager status changed from {previousStatus} to {newStatus}");
			return HRESULT.S_OK;
		}

		public HRESULT OnValueChanged(IUIAnimationStoryboard storyboard, IUIAnimationVariable variable, double newValue, double previousValue)
		{
			output.WriteLine($"Value changed from {previousValue} to {newValue}");
			return HRESULT.S_OK;
		}

		public HRESULT OnIntegerValueChanged(IUIAnimationStoryboard storyboard, IUIAnimationVariable variable, int newValue, int previousValue)
		{
			output.WriteLine($"Int value changed from {previousValue} to {newValue}");
			return HRESULT.S_OK;
		}

		public HRESULT OnPreUpdate()
		{
			output.WriteLine("PreUpdate");
			return HRESULT.S_OK;
		}

		public HRESULT OnPostUpdate()
		{
			output.WriteLine("PostUpdate");
			return HRESULT.S_OK;
		}

		public HRESULT OnRenderingTooSlow(uint framesPerSecond)
		{
			output.WriteLine($"Rendering too slow: {framesPerSecond} fps");
			return HRESULT.S_OK;
		}

		public HRESULT OnUpdate(double timeNow, out UI_ANIMATION_UPDATE_RESULT result)
		{
			output.WriteLine($"Update at {timeNow}");
			result = UI_ANIMATION_UPDATE_RESULT.UI_ANIMATION_UPDATE_NO_CHANGE;
			return HRESULT.S_OK;
		}

		public HRESULT SetTimerClientEventHandler(IUIAnimationTimerClientEventHandler handler)
		{
			output.WriteLine($"Set timer client event handler");
			return HRESULT.S_OK;
		}

		public HRESULT ClearTimerClientEventHandler()
		{
			output.WriteLine($"Clear timer client event handler");
			return HRESULT.S_OK;
		}
	}
}