using System;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class ScheduleControl : UserControl
    {
        public ScheduleControl()
            => InitializeComponent();

        private void _buttonAdd_Click(object sender, EventArgs e)
        {
            using (var form = new ReserveForm())
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;
                _lsit.Items.Add(form.GuestName);
            } 
        }
    }
}
