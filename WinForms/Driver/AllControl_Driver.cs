using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;

namespace Driver
{
	public class AllControl_Driver
	{
		public WindowControl Core { get; }
		public FormsTrackBar trackBar => new FormsTrackBar(Core.Dynamic().trackBar);
		public FormsMaskedTextBox maskedTextBox => new FormsMaskedTextBox(Core.Dynamic().maskedTextBox);
		public FormsNumericUpDown numericUpDown => new FormsNumericUpDown(Core.Dynamic().numericUpDown);
		public FormsCheckedListBox checkedListBox => new FormsCheckedListBox(Core.Dynamic().checkedListBox);
		public FormsDateTimePicker dateTimePicker => new FormsDateTimePicker(Core.Dynamic().dateTimePicker);
		public FormsMonthCalendar monthCalendar => new FormsMonthCalendar(Core.Dynamic().monthCalendar);
		public FormsProgressBar progressBar => new FormsProgressBar(Core.Dynamic().progressBar);
		public FormsLinkLabel linkLabel => new FormsLinkLabel(Core.Dynamic().linkLabel);
		public FormsListView listView => new FormsListView(Core.Dynamic().listView);
		public FormsTabControl tabControl => new FormsTabControl(Core.Dynamic().tabControl);
		public FormsDataGridView dataGridView => new FormsDataGridView(Core.Dynamic().dataGridView);
		public FormsRichTextBox richTextBox => new FormsRichTextBox(Core.Dynamic().richTextBox);
		public FormsTextBox textBox => new FormsTextBox(Core.Dynamic().textBox);
		public FormsRadioButton radioButton2 => new FormsRadioButton(Core.Dynamic().radioButton2);
		public FormsRadioButton radioButton1 => new FormsRadioButton(Core.Dynamic().radioButton1);
		public FormsListBox listBox => new FormsListBox(Core.Dynamic().listBox);
		public FormsComboBox comboBox => new FormsComboBox(Core.Dynamic().comboBox);
		public FormsTreeView treeView => new FormsTreeView(Core.Dynamic().treeView);
		public FormsCheckBox checkBox => new FormsCheckBox(Core.Dynamic().checkBox);
		public FormsButton button => new FormsButton(Core.Dynamic().button);
		public FormsToolStrip toolStrip => new FormsToolStrip(Core.Dynamic().toolStrip);

		public AllControl_Driver(WindowControl core)
		{
			Core = core;
		}
	}
}