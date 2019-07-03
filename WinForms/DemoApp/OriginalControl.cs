using System;
using System.Drawing;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class OriginalControl : UserControl
    {
        public OriginalControl()
        {
            InitializeComponent();
        }

        private void _buttonAdd_Click(object sender, EventArgs e)
            => _blockControl.AddBlock(new Rectangle(10, 10, 100, 100));
    }
}
