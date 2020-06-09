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
    public partial class frmDoituongsudung : Form
    {
        public frmDoituongsudung()
        {
            InitializeComponent();
        }

        private void frmDoituongsudung_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            DAO.CloseConnection();
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblDoiTuongSuDung";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewDoituongsudung.DataSource = table;
        }

        private void gridviewDoituongsudung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDTSD.Text = gridviewDoituongsudung.CurrentRow.Cells["MaDTSD"].Value.ToString();
            txtTenDTSD.Text = gridviewDoituongsudung.CurrentRow.Cells["TenDTSD"].Value.ToString();
            txtMaDTSD.Enabled = false;
        }

        private void ResetValue()
        {
            txtMaDTSD.Text = "";
            txtTenDTSD.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtMaDTSD.Enabled = true;
            txtMaDTSD.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaDTSD.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã đối tượng sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDTSD.Focus();
                return;
            }
            if (txtTenDTSD.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đối tượng sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDTSD.Focus();
                return;
            }
            sql = "Select MaDTSD from tblDoiTuongSuDung where MaDTSD ='" + txtMaDTSD.Text.Trim() + "'";
            DAO.OpenConnection();
            if (DAO.CheckKeyExit(sql))
            {
                MessageBox.Show("Mã đối tượng sử dụng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.CloseConnection();
                txtMaDTSD.Focus();
                return;
            }
            else
            {
                sql = "insert into tblDoiTuongSuDung (MaDTSD,TenDTSD) " +
                    " values ('" + txtMaDTSD.Text.Trim() + "',N'" + txtTenDTSD.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                loadDataGridView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaDTSD.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã đối tượng sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDTSD.Focus();
            }
            if (txtTenDTSD.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đối tượng sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDTSD.Focus();
            }
            sql = "update tblDoiTuongSuDung set TenDTSD=N'" + txtTenDTSD.Text.Trim() + "' where MaDTSD ='" + txtMaDTSD.Text.Trim() + "'";
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
                string sql = "delete from tblDoiTuongSuDung where MaDTSD = '" + txtMaDTSD.Text + "'";
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
