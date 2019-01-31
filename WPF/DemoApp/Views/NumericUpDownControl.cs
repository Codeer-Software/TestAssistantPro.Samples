using System;
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
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    (d, e) => 
                    {
                        (d as NumericUpDownControl)?.ValueChanged?.Invoke(d, null);
                    }));

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Events.
        public event EventHandler ValueChanged;

        // Fields.
        public TextBox ValueTextBox { get; set; }
        public RepeatButton UpButton { get; set; }
        public RepeatButton DownButton { get; set; }

        // Apply Template.
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // Dettach.
            if (ValueTextBox != null)
            {
                ValueTextBox.PreviewTextInput -= ValueTextBox_PreviewTextInput;
                ValueTextBox.TextChanged -= ValueTextBox_TextChanged;
                CommandManager.RemoveExecutedHandler(ValueTextBox, ValueTextBox_PreviewExecuted);
            }
            if (UpButton != null) UpButton.Click -= UpButton_Click;
            if (DownButton != null) DownButton.Click -= DownButton_Click;

            // Get current controls.
            ValueTextBox = GetTemplateChild("PART_ValueTextBox") as TextBox;
            UpButton = GetTemplateChild("PART_UpButton") as RepeatButton;
            DownButton = GetTemplateChild("PART_DownButton") as RepeatButton;

            // Attach.
            if (ValueTextBox != null)
            {
                ValueTextBox.PreviewTextInput += ValueTextBox_PreviewTextInput;
                ValueTextBox.TextChanged += ValueTextBox_TextChanged;
                CommandManager.AddPreviewExecutedHandler(ValueTextBox, ValueTextBox_PreviewExecuted);
            }
            if (UpButton != null) UpButton.Click += UpButton_Click;
            if (DownButton != null) DownButton.Click += DownButton_Click;
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
