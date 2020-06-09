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
    public partial class frmNghenghiep : Form
    {
        public frmNghenghiep()
        {
            InitializeComponent();
        }

        private void frmNghenghiep_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            DAO.CloseConnection();
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblNgheNghiep";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewNghenghiep.DataSource = table;
        }

        private void gridviewNghenghiep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtManghe.Text = gridviewNghenghiep.CurrentRow.Cells["Manghe"].Value.ToString();
            txtTennghe.Text = gridviewNghenghiep.CurrentRow.Cells["Tennghe"].Value.ToString();
            txtManghe.Enabled = false;
        }

        private void ResetValue()
        {
            txtManghe.Text = "";
            txtTennghe.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtManghe.Enabled = true;
            txtManghe.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtManghe.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nghề nghiệp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManghe.Focus();
                return;
            }
            if (txtTennghe.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nghề nghiệp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennghe.Focus();
                return;
            }
            sql = "Select Manghe from tblNgheNghiep where Manghe ='" + txtManghe.Text.Trim() + "'";
            DAO.OpenConnection();
            if (DAO.CheckKeyExit(sql))
            {
                MessageBox.Show("Mã nghề nghiệp đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.CloseConnection();
                txtManghe.Focus();
                return;
            }
            else
            {
                sql = "insert into tblNgheNghiep (Manghe,Tennghe) " +
                    " values ('" + txtManghe.Text.Trim() + "',N'" + txtTennghe.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                loadDataGridView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtManghe.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nghề nghiệp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManghe.Focus();
            }
            if (txtTennghe.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nghề nghiệp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennghe.Focus();
            }
            sql = "update tblNgheNghiep set Tennghe=N'" + txtTennghe.Text.Trim() + "' where Manghe ='" + txtManghe.Text.Trim() + "'";
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
                string sql = "delete from tblNgheNghiep where Manghe = '" + txtManghe.Text + "'";
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
