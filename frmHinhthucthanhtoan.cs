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
    public partial class frmHinhthucthanhtoan : Form
    {
        public frmHinhthucthanhtoan()
        {
            InitializeComponent();
        }

        private void frmHinhthucthanhtoan_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            DAO.CloseConnection();
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblHinhThucThanhToan";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewHinhthucthanhtoan.DataSource = table;
        }

        private void gridviewHinhthucthanhtoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMahinhthuc.Text = gridviewHinhthucthanhtoan.CurrentRow.Cells["MahinhthucTT"].Value.ToString();
            txtTenhinhthuc.Text = gridviewHinhthucthanhtoan.CurrentRow.Cells["TenhinhthucTT"].Value.ToString();
            txtMahinhthuc.Enabled = false;
        }

        private void ResetValue()
        {
            txtMahinhthuc.Text = "";
            txtTenhinhthuc.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtMahinhthuc.Enabled = true;
            txtTenhinhthuc.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMahinhthuc.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã hình thức thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMahinhthuc.Focus();
                return;
            }
            if (txtTenhinhthuc.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên hình thức thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenhinhthuc.Focus();
                return;
            }
            sql = "Select MahinhthucTT from tblHinhThucThanhToan where MahinhthucTT ='" + txtMahinhthuc.Text.Trim() + "'";
            DAO.OpenConnection();
            if (DAO.CheckKeyExit(sql))
            {
                MessageBox.Show("Mã hình thức thanh toán đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.CloseConnection();
                txtMahinhthuc.Focus();
                return;
            }
            else
            {
                sql = "insert into tblHinhThucThanhToan (MahinhthucTT,TenhinhthucTT) " +
                    " values ('" + txtMahinhthuc.Text.Trim() + "',N'" + txtTenhinhthuc.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                loadDataGridView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMahinhthuc.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã hình thức thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMahinhthuc.Focus();
            }
            if (txtTenhinhthuc.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên hình thức thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenhinhthuc.Focus();
            }
            sql = "update tblHinhThucThanhToan set TenhinhthucTT=N'" + txtTenhinhthuc.Text.Trim() + "' where MahinhthucTT ='" + txtMahinhthuc.Text.Trim() + "'";
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
                string sql = "delete from tblHinhThucThanhToan where MahinhthucTT = '" + txtMahinhthuc.Text + "'";
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
