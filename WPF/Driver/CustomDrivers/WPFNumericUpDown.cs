using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.TestAssistant.GeneratorToolKit;
using DemoApp.Views;
using Driver.InTarget;
using RM.Friendly.WPFStandardControls;
using System;
using System.Windows.Controls;

namespace Driver.CustomDrivers
{
	[ControlDriver(TypeFullName = "DemoApp.Views.NumericUpDownControl")]
	public class WPFNumericUpDown : WPFControlBase<NumericUpDownControl>
	{
		public WPFNumericUpDown(AppVar src) : base(src) { }

		public int Value => Getter<int>("Value");

		public void EmulateChangeValue(int value)
		{
			var textBox = this.Dynamic().valueTextBox;
			if (textBox != null)
			{
				textBox.Focus();
				textBox.Text = value.ToString();
			}
		}
	}
}
