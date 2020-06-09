using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTN
{
    public partial class frmTranha : Form
    {
        public frmTranha()
        {
            InitializeComponent();
        }

        private void frmTranha_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            fillDataToCombo();
            DAO.CloseConnection();
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblTraNha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewTranha.DataSource = table;
        }

        public void fillDataToCombo()
        {
            string sql = "Select * from tblThueNha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbMasothue.DataSource = table;
            cmbMasothue.ValueMember = "Masothue";
            cmbMasothue.DisplayMember = "Masothue";
        }
    }
}
