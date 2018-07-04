using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Driver;
using Ong.Friendly.FormsStandardControls;

namespace Driver
{
	public class OriginalControl_Driver
	{
		public WindowControl Core { get; }
		public BlockControlDriver _blockControl => new BlockControlDriver(Core.Dynamic()._blockControl);
		public FormsButton _buttonAdd => new FormsButton(Core.Dynamic()._buttonAdd);

		public OriginalControl_Driver(WindowControl core)
		{
			Core = core;
		}
	}
}