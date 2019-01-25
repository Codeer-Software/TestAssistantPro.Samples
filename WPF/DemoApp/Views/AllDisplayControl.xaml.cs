using System.Windows.Controls;

namespace DemoApp.Views
{
    public partial class AllDisplayControl : UserControl
    {
        public AllDisplayControl() => InitializeComponent();

        public bool GetVisible() => IsVisible;
    }
}
