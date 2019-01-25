using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.Windows;

namespace DemoApp.Views
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Update()
        {

        }

        void ShowVersion(object sender, RoutedEventArgs e)
            => new VersionWindow().ShowDialog();

        public string ShowSaveFileDialog()
        {
            var dlg = new SaveFileDialog();
            return (dlg.ShowDialog() == true) ? dlg.FileName : string.Empty;
        }

        public string ShowOpenFileDialog()
        {
            var dlg = new OpenFileDialog();
            return (dlg.ShowDialog() == true) ? dlg.FileName : string.Empty;
        }
    }
}
