using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;

namespace Driver
{
	public class EmployeeControl_Driver
	{
		public WindowControl Core { get; }
		public FormsDataGridView _grid => new FormsDataGridView(Core.Dynamic()._grid);

		public EmployeeControl_Driver(WindowControl core)
		{
			Core = core;
		}
	}
}