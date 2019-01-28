using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace DemoApp.Views
{
    public class NumericUpDownControl : Control
    {
        static NumericUpDownControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDownControl), new FrameworkPropertyMetadata(typeof(NumericUpDownControl)));
        }

        // Properties.
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Value",
                typeof(int),
                typeof(NumericUpDownControl),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Fields.
        private TextBox valueTextBox;
        private RepeatButton upButton;
        private RepeatButton downButton;

        // Apply Template.
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // Dettach.
            if (valueTextBox != null)
            {
                valueTextBox.PreviewTextInput -= ValueTextBox_PreviewTextInput;
                valueTextBox.TextChanged -= ValueTextBox_TextChanged;
                CommandManager.RemoveExecutedHandler(valueTextBox, ValueTextBox_PreviewExecuted);
            }
            if (upButton != null) upButton.Click -= UpButton_Click;
            if (downButton != null) downButton.Click -= DownButton_Click;

            // Get current controls.
            valueTextBox = GetTemplateChild("PART_ValueTextBox") as TextBox;
            upButton = GetTemplateChild("PART_UpButton") as RepeatButton;
            downButton = GetTemplateChild("PART_DownButton") as RepeatButton;

            // Attach.
            if (valueTextBox != null)
            {
                valueTextBox.PreviewTextInput += ValueTextBox_PreviewTextInput;
                valueTextBox.TextChanged += ValueTextBox_TextChanged;
                CommandManager.AddPreviewExecutedHandler(valueTextBox, ValueTextBox_PreviewExecuted);
            }
            if (upButton != null) upButton.Click += UpButton_Click;
            if (downButton != null) downButton.Click += DownButton_Click;
        }

        // TextBox Events.
        void ValueTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!int.TryParse(textBox.Text, out var _))
            {
                textBox.Text = Regex.Replace(textBox.Text, "[^0-9]", "");
                return;
            }
            if (int.TryParse(textBox.Text, out var val)) Value = val;
        }
        void ValueTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = !new Regex("[0-9]").IsMatch(e.Text);
        void ValueTextBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e) => e.Handled = e.Command == ApplicationCommands.Paste;

        // Button Events.
        void UpButton_Click(object sender, RoutedEventArgs e) { if (Value < 1000) Value++; }
        void DownButton_Click(object sender, RoutedEventArgs e) { if (Value > 0) Value--; }
    }
}
