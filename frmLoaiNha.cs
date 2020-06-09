using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLTN
{
    public partial class frmLoaiNha : Form
    {
        public frmLoaiNha()
        {
            InitializeComponent();
        }

        private void frmLoaiNha_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            DAO.CloseConnection();
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblLoaiNha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewLoainha.DataSource = table;
        }

        private void gridviewLoainha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaloai.Text = gridviewLoainha.CurrentRow.Cells["Maloai"].Value.ToString();
            txtTenloai.Text = gridviewLoainha.CurrentRow.Cells["Tenloai"].Value.ToString();
            txtMaloai.Enabled = false;
        }

        private void ResetValue()
        {
            txtMaloai.Text = "";
            txtTenloai.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = true;
                btnThem.Enabled = false;
                ResetValue();
                txtMaloai.Enabled = true;
                txtMaloai.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaloai.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã loại nhà", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaloai.Focus();
                return;
            }
            if (txtTenloai.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên loại nhà", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenloai.Focus();
                return;
            }
            sql = "Select Maloai from tblLoaiNha where Maloai ='" + txtMaloai.Text.Trim() + "'";
            DAO.OpenConnection();
            if (DAO.CheckKeyExit(sql))
            {
                MessageBox.Show("Mã loại nhà đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.CloseConnection();
                txtMaloai.Focus();
                return;
            }
            else
            {
                sql = "insert into tblLoaiNha (Maloai,Tenloai) " +
                    " values ('" + txtMaloai.Text.Trim() + "',N'" + txtTenloai.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                loadDataGridView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaloai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã loại nhà", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaloai.Focus();
            }
            if (txtTenloai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên loại nhà", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenloai.Focus();
            }
             sql = "update tblLoaiNha set Tenloai=N'" + txtTenloai.Text.Trim() + "' where Maloai ='" + txtMaloai.Text.Trim() + "'";
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
                string sql = "delete from tblLoaiNha where Maloai = '" + txtMaloai.Text + "'";
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
