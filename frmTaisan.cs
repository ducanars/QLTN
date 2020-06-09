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
    public partial class frmTaisan : Form
    {
        public frmTaisan()
        {
            InitializeComponent();
        }

        private void frmTaisan_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            DAO.CloseConnection();
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblTaiSan";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewTaisan.DataSource = table;
        }

        private void gridviewTaisan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMataisan.Text = gridviewTaisan.CurrentRow.Cells["Mataisan"].Value.ToString();
            txtTentaisan.Text = gridviewTaisan.CurrentRow.Cells["Tentaisan"].Value.ToString();
            txtMataisan.Enabled = false;
        }
        private void ResetValue()
        {
            txtMataisan.Text = "";
            txtTentaisan.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtMataisan.Enabled = true;
            txtMataisan.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMataisan.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã tài sản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMataisan.Focus();
                return;
            }
            if (txtTentaisan.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tài sản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTentaisan.Focus();
                return;
            }
            sql = "Select Mataisan from tblTaiSan where Mataisan ='" + txtMataisan.Text.Trim() + "'";
            DAO.OpenConnection();
            if (DAO.CheckKeyExit(sql))
            {
                MessageBox.Show("Mã tài sản đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.CloseConnection();
                txtMataisan.Focus();
                return;
            }
            else
            {
                sql = "insert into tblTaiSan (Mataisan,Tentaisan) " +
                    " values ('" + txtMataisan.Text.Trim() + "',N'" + txtTentaisan.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                loadDataGridView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMataisan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã tài sản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMataisan.Focus();
            }
            if (txtTentaisan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tài sản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTentaisan.Focus();
            }
            sql = "update tblTaiSan set Tentaisan=N'" + txtTentaisan.Text.Trim() + "' where Mataisan ='" + txtMataisan.Text.Trim() + "'";
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
                string sql = "delete from tblTaiSan where Mataisan = '" + txtMataisan.Text + "'";
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
