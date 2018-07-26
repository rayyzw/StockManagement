
using System.Data;
using System.Windows.Forms;

namespace StockManagement
{
    public partial class FormOrderList : Form
    {
        public FormOrderList()
        {
            InitializeComponent();
        }
        public FormOrderList(DataTable dataTable)
        {
            InitializeComponent();
            dataGridView1.DataSource = dataTable;
        }
    }
}
