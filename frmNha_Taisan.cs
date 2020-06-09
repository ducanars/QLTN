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
    public partial class frmNha_Taisan : Form
    {
        public frmNha_Taisan()
        {
            InitializeComponent();
        }

        private void frmNha_Taisan_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            fillDataToComboNha();
            fillDataToComboTaisan();
            DAO.CloseConnection();
            cmbTaisan.Text = "";
            cmbTaisan.Enabled = false;
            txtTinhtrang.Enabled = false;
            txtSoluong.Enabled = false;
            txtGiatri.Enabled = false;
            cmbManha.Text = "";
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblNha_TaiSan";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewNha_taisan.DataSource = table;
        }

        public void fillDataToComboNha()
        {
            string sql = "Select * from tblDanhMucNha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbManha.DataSource = table;
            cmbManha.ValueMember = "Manha";
            cmbManha.DisplayMember = "Tenchunha";
        }

        public void fillDataToComboTaisan()
        {
            string sql = "Select * from tblTaiSan";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbTaisan.DataSource = table;
            cmbTaisan.ValueMember = "Mataisan";
            cmbTaisan.DisplayMember = "Tentaisan";
        }
        private void ResetValue()
        {
            txtGiatri.Text = "";
            txtSoluong.Text = "";
            txtTinhtrang.Text = "";
            cmbTaisan.SelectedIndex = -1;
        }
        private void EnableValue()
        {
            cmbTaisan.Enabled = true;
            txtTinhtrang.Enabled = true;
            txtSoluong.Enabled = true;
            txtGiatri.Enabled = true;
            cmbTaisan.SelectedIndex = -1;
        }

        private void gridviewNha_taisan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql;
            sql = "Select Tenchunha From tblDanhMucNha Where Manha = N'" + gridviewNha_taisan.CurrentRow.Cells["Manha"].Value.ToString() + "'";
            cmbManha.Text = DAO.GetFieldValues(sql); 
            cmbTaisan.Text = gridviewNha_taisan.CurrentRow.Cells["Mataisan"].Value.ToString();
            txtSoluong.Text = gridviewNha_taisan.CurrentRow.Cells["Soluong"].Value.ToString();
            txtGiatri.Text = gridviewNha_taisan.CurrentRow.Cells["Giatri"].Value.ToString();
            txtTinhtrang.Text = gridviewNha_taisan.CurrentRow.Cells["Tinhtrang"].Value.ToString();
        }

        private void btnThemmoinha_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            cmbTaisan.Enabled = true;
            txtTinhtrang.Enabled = true;
            txtSoluong.Enabled = true;
            txtGiatri.Enabled = true;
            ResetValue();
            cmbManha.SelectedIndex = -1;
            cmbManha.Enabled = true;
            cmbTaisan.Focus();
        }

        private void btnThemmoiTS_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            EnableValue();
            cmbTaisan.Enabled = true;
            cmbTaisan.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
