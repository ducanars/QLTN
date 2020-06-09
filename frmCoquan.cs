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
    public partial class frmCoquan : Form
    {
        public frmCoquan()
        {
            InitializeComponent();
        }

        private void frmCoquan_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            DAO.CloseConnection();
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblCoQuan";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewCoquan.DataSource = table;
        }

        private void gridviewCoquan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMacoquan.Text = gridviewCoquan.CurrentRow.Cells["MaCQ"].Value.ToString();
            txtTencoquan.Text = gridviewCoquan.CurrentRow.Cells["TenCQ"].Value.ToString();
            txtMacoquan.Enabled = false;
        }

        private void ResetValue()
        {
            txtMacoquan.Text = "";
            txtTencoquan.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtMacoquan.Enabled = true;
            txtMacoquan.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMacoquan.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã cơ quan", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMacoquan.Focus();
                return;
            }
            if (txtTencoquan.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên cơ quan", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTencoquan.Focus();
                return;
            }
            sql = "Select MaCQ from tblCoQuan where MaCQ ='" + txtMacoquan.Text.Trim() + "'";
            DAO.OpenConnection();
            if (DAO.CheckKeyExit(sql))
            {
                MessageBox.Show("Mã cơ quan đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.CloseConnection();
                txtMacoquan.Focus();
                return;
            }
            else
            {
                sql = "insert into tblCoQuan (MaCQ,TenCQ) " +
                    " values ('" + txtMacoquan.Text.Trim() + "',N'" + txtTencoquan.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                loadDataGridView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMacoquan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã cơ quan", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMacoquan.Focus();
            }
            if (txtTencoquan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên cơ quan", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTencoquan.Focus();
            }
            sql = "update tblCoQuan set TenCQ=N'" + txtTencoquan.Text.Trim() + "' where MaCQ ='" + txtMacoquan.Text.Trim() + "'";
            DAO.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = DAO.con;
            cmd.ExecuteNonQuery();
            DAO.CloseConnection();
            loadDataGridView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sql = "delete from tblCoQuan where MaCQ = '" + txtMacoquan.Text + "'";
                DAO.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = DAO.con;
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                loadDataGridView();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
