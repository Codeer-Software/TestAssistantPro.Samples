using Codeer.TestAssistant.GeneratorToolKit;
using DemoApp.Views;
using System;
using System.Collections.Generic;

namespace Driver.InTarget
{
	[CaptureCodeGenerator("Driver.CustomDrivers.WPFNumericUpDownDriver")]
	public class WPFNumericUpDownDriverGenerator : CaptureCodeGeneratorBase
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
		{
			if (_control.ValueTextBox.IsFocused || _control.UpButton.IsFocused || _control.DownButton.IsFocused)
				AddSentence(new TokenName(), ".EmulateChangeValue(" + _control.Value, new TokenAsync(CommaType.Before), ");");
		}

		public override void Optimize(List<Sentence> code)
		{
			bool findChangeText = false;
			for (int i = code.Count - 1; 0 <= i; i--)
			{
				if (IsDuplicatedFunction(code[i], "EmulateChangeValue"))
				{
					if (findChangeText)
					{
						code.RemoveAt(i);
					}
					findChangeText = true;
				}
				else
				{
					findChangeText = false;
				}
			}
		}

		private bool IsDuplicatedFunction(Sentence sentence, string function)
		{
			if (!ReferenceEquals(this, sentence.Owner))
			{
				return false;
			}
			if (sentence.Tokens.Length <= 2)
			{
				return false;
			}
			if (!(sentence.Tokens[0] is TokenName) ||
				(sentence.Tokens[1] == null))
			{
				return false;
			}
			return sentence.Tokens[1].ToString().IndexOf("." + function) == 0;
		}
	}
}
