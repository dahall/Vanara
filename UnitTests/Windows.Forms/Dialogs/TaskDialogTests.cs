using NUnit.Framework;
using System.Windows.Forms;

namespace Vanara.Windows.Forms.Tests
{
	[TestFixture()]
	public class TaskDialogTests
	{
		[OneTimeSetUp]
		public void SetupFixture() => Application.EnableVisualStyles();

		[Test()]
		public void TaskDialogTest()
		{
			var td = new TaskDialog
			{
				ButtonDisplay = TaskDialogButtonDisplay.CommandLink,
				Content = "Content text, Content text, Content text, Content text, Content text, Content text, Content text, Content text, Content text, Content text, Content text, Content text",
				MainInstruction = "Main Instruction",
				WindowTitle = "Title"
			};
			td.Buttons.Add(new TaskDialogButton("Try this"));
			td.Buttons.Add(new TaskDialogButton("Try that"));
			td.ShowDialog();
			Assert.That(MessageBox.Show("Confirm UI strings and command link buttons", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes);

			td.Reset();
			Assert.That(td.MainInstruction, Is.Null);
			Assert.That(td.Buttons.Count, Is.Zero);

			td.RadioButtons.Add(new TaskDialogRadioButton("Radio 1", 20));
			td.RadioButtons.Add(new TaskDialogRadioButton("Radio 2", 21) { Enabled = false });
			td.DefaultRadioButton = 20;
			td.MainInstruction = "Radio Instruction";
			td.CommonButtons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel;
			td.ShowDialog();
			Assert.That(td.Result.SelectedRadioButton, Is.EqualTo(20));
			Assert.That(MessageBox.Show("Confirm new dlg and radio buttons.", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes);
		}

		[Test()]
		public void SimpleShowTest()
		{
			new TaskDialog().ShowDialog();
		}

		[Test()]
		public void ShowTest1()
		{
			var i = TaskDialog.Show("Main instruct", "Caption", new[] { "Test1", "Test2" }, TaskDialogIcon.Shield);
			Assert.That(i, Is.InRange(101, 102));
		}
	}
}