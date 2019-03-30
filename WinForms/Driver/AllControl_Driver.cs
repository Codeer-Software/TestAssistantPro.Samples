using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;

namespace Driver
{
    [UserControlDriver(TypeFullName = "DemoApp.AllControl")]
    public class AllControl_Driver
    {
        public WindowControl Core { get; }
        public FormsToolStrip toolStrip => new FormsToolStrip(Core.Dynamic().toolStrip);
        public FormsToolStrip contextMenuStrip => new FormsToolStrip(Core.Dynamic().contextMenuStrip);
        public FormsToolStrip menuStrip => new FormsToolStrip(Core.Dynamic().menuStrip);
        public FormsButton button => new FormsButton(Core.Dynamic().button);
        public FormsCheckBox checkBox => new FormsCheckBox(Core.Dynamic().checkBox);
        public FormsTreeView treeView => new FormsTreeView(Core.Dynamic().treeView);
        public FormsComboBox comboBox => new FormsComboBox(Core.Dynamic().comboBox);
        public FormsListBox listBox => new FormsListBox(Core.Dynamic().listBox);
        public FormsRadioButton radioButton1 => new FormsRadioButton(Core.Dynamic().radioButton1);
        public FormsRadioButton radioButton2 => new FormsRadioButton(Core.Dynamic().radioButton2);
        public FormsTextBox textBox => new FormsTextBox(Core.Dynamic().textBox);
        public FormsRichTextBox richTextBox => new FormsRichTextBox(Core.Dynamic().richTextBox);
        public FormsCheckedListBox checkedListBox => new FormsCheckedListBox(Core.Dynamic().checkedListBox);
        public FormsListView listView => new FormsListView(Core.Dynamic().listView);
        public FormsTabControl tabControl => new FormsTabControl(Core.Dynamic().tabControl);
        public FormsNumericUpDown numericUpDown => new FormsNumericUpDown(Core.Dynamic().numericUpDown);
        public FormsDataGridView dataGridView => new FormsDataGridView(Core.Dynamic().dataGridView);
        public FormsLinkLabel linkLabel => new FormsLinkLabel(Core.Dynamic().linkLabel);
        public FormsProgressBar progressBar => new FormsProgressBar(Core.Dynamic().progressBar);
        public FormsMonthCalendar monthCalendar => new FormsMonthCalendar(Core.Dynamic().monthCalendar);
        public FormsDateTimePicker dateTimePicker => new FormsDateTimePicker(Core.Dynamic().dateTimePicker);
        public FormsMaskedTextBox maskedTextBox => new FormsMaskedTextBox(Core.Dynamic().maskedTextBox);
        public FormsTrackBar trackBar => new FormsTrackBar(Core.Dynamic().trackBar);

        public AllControl_Driver(WindowControl core)
        {
            Core = core;
        }
    }

    public static class AllControl_Driver_Extensions
    {
        [UserControlDriverIdentify]
        public static AllControl_Driver Attach_AllControl(this Demo_Driver window)
            => new AllControl_Driver(new WindowControl(window.Core.IdentifyFromTypeFullName("DemoApp.AllControl")));
    }
}