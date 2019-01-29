using Codeer.TestAssistant.GeneratorToolKit;
using DemoApp.Views;
using System;

namespace Driver.InTarget
{
	[CaptureCodeGenerator("Driver.CustomDrivers.WPFNumericUpDown")]
	public class WPFNumericUpDownGenerator : CaptureCodeGeneratorBase
	{
		NumericUpDownControl _control;
		protected override void Attach()
		{
			_control = (NumericUpDownControl)ControlObject;
			_control.ValueChanged += ValueChanged;
		}

		protected override void Detach()
		{
			_control.ValueChanged -= ValueChanged;
		}

		void ValueChanged(object sender, EventArgs e)
			=> AddSentence(new TokenName(), ".EmulateChangeValue(" + _control.Value, new TokenAsync(CommaType.Before), ");");
	}
}
