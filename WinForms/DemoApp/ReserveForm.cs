using System.Windows.Forms;

namespace DemoApp
{
    public partial class ReserveForm : Form
    {
        public ReserveForm()
        {
            InitializeComponent();
        }

        public string GuestName => _textBoxName.Text;
    }
}
