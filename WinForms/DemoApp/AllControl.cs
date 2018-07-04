using System.Windows.Forms;

namespace DemoApp
{
    public partial class AllControl : UserControl
    {
        public AllControl()
        {
            InitializeComponent();
            InitTreeView();
            InitListView();
        }

        void InitTreeView()
        {
            treeView.Nodes.Add("Parent");
            treeView.Nodes[0].Nodes.Add("Child 1");
            treeView.Nodes[0].Nodes.Add("Child 2");
            treeView.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            treeView.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
            TreeNode tn = treeView.Nodes[0].Nodes[0];
            treeView.SelectedNode = tn;
        }
        
        private void InitListView()
        {
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.Sorting = SortOrder.Ascending;
            listView.View = View.Details;
            
            ColumnHeader columnName = new ColumnHeader();
            ColumnHeader columnType = new ColumnHeader();
            ColumnHeader columnData = new ColumnHeader();
            columnName.Text = "name";
            columnName.Width = 100;
            columnType.Text = "kind";
            columnType.Width = 60;
            columnData.Text = "color";
            columnData.Width = 150;
            ColumnHeader[] colHeaderRegValue =
            { columnName, columnType, columnData };
            listView.Columns.AddRange(colHeaderRegValue);
            
            listView.Items.Clear();
            string[] item1 = { "apple", "fruit", "red" };
            listView.Items.Add(new ListViewItem(item1));
            string[] item2 = { "melon", "fruit", "green" };
            listView.Items.Add(new ListViewItem(item2));
            string[] item3 = { "green pepper", "vegetables", "green" };
            listView.Items.Add(new ListViewItem(item3));
            string[] item4 = { "tomato", "vegetables", "red" };
            listView.Items.Add(new ListViewItem(item4));
        }

        private void maskedTextBox_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
