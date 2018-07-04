using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;

namespace Driver
{
	public class ScheduleControl_Driver
	{
		public WindowControl Core { get; }
		public FormsListBox _lsit => new FormsListBox(Core.Dynamic()._lsit);
		public FormsButton _buttonAdd => new FormsButton(Core.Dynamic()._buttonAdd);

		public ScheduleControl_Driver(WindowControl core)
		{
			Core = core;
		}
	}
}