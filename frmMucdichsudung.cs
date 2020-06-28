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
    public partial class frmMucdichsudung : Form
    {
        public frmMucdichsudung()
        {
            InitializeComponent();
        }

        private void frmMucdichsudung_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            DAO.CloseConnection();
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblMucDichSuDung";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewMucdichsudung.DataSource = table;
        }

        private void gridviewMucdichsudung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMamucdichSD.Text = gridviewMucdichsudung.CurrentRow.Cells["MamucdichSD"].Value.ToString();
            txtTenmucdichSD.Text = gridviewMucdichsudung.CurrentRow.Cells["TenmucdichSD"].Value.ToString();
            txtMamucdichSD.Enabled = false;
        }

        private void ResetValue()
        {
            txtMamucdichSD.Text = "";
            txtTenmucdichSD.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtMamucdichSD.Enabled = true;
            txtMamucdichSD.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMamucdichSD.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã mục đích sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMamucdichSD.Focus();
                return;
            }
            if (txtTenmucdichSD.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên mục đích sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenmucdichSD.Focus();
                return;
            }
            sql = "Select MamucdichSD from tblMucDichSuDung where MamucdichSD ='" + txtMamucdichSD.Text.Trim() + "'";
            DAO.OpenConnection();
            if (DAO.CheckKeyExit(sql))
            {
                MessageBox.Show("Mã mục đích sử dụng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.CloseConnection();
                txtMamucdichSD.Focus();
                return;
            }
            else
            {
                sql = "insert into tblMucDichSuDung (MamucdichSD,TenmucdichSD) " +
                    " values ('" + txtMamucdichSD.Text.Trim() + "',N'" + txtTenmucdichSD.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                loadDataGridView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMamucdichSD.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã đối tượng sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMamucdichSD.Focus();
            }
            if (txtTenmucdichSD.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đối tượng sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenmucdichSD.Focus();
            }
            sql = "update tblDoiTuongSuDung set TenDTSD=N'" + txtTenmucdichSD.Text.Trim() + "' where MaDTSD ='" + txtMamucdichSD.Text.Trim() + "'";
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
                string sql = "delete from tblMucDichSuDung where MamucdichSD = '" + txtMamucdichSD.Text + "'";
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
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }


}
