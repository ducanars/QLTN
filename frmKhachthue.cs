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
    public partial class frmKhachthue : Form
    {
        public frmKhachthue()
        {
            InitializeComponent();
        }

        private void frmKhachthue_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            fillDataToComboNghenghiep();
            fillDataToComboCoquan();
            DAO.CloseConnection();
            cmbManghe.Text = "";
            cmbMaCQ.Text = "";
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblKhachThue";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewKhachthue.DataSource = table;
        }

        public void fillDataToComboNghenghiep()
        {
            string sql = "Select * from tblNgheNghiep";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbManghe.DataSource = table;
            cmbManghe.ValueMember = "Manghe";
            cmbManghe.DisplayMember = "Tennghe";
        }

        public void fillDataToComboCoquan()
        {
            string sql = "Select * from tblCoquan";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbMaCQ.DataSource = table;
            cmbMaCQ.ValueMember = "MaCQ";
            cmbMaCQ.DisplayMember = "TenCQ";
        }
        private void ResetValue()
        {
            txtMakhach.Text = "";
            txtTenkhach.Text = "";
            dtpNgaysinh.Text = "";
            txtSoCMND.Text = "";
            chkGioitinh.Checked = false;
            txtDiachithuongtru.Text = "";
            cmbManghe.SelectedIndex = -1;
            cmbMaCQ.SelectedIndex = -1;   
        }

        private void gridviewKhachthue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMakhach.Text = gridviewKhachthue.CurrentRow.Cells["Makhach"].Value.ToString();
            txtTenkhach.Text = gridviewKhachthue.CurrentRow.Cells["Tenkhach"].Value.ToString();
            dtpNgaysinh.Text = gridviewKhachthue.CurrentRow.Cells["Ngaysinh"].Value.ToString();
            if (gridviewKhachthue.CurrentRow.Cells["Gioitinh"].Value.ToString() == "Nam") chkGioitinh.Checked = true;
            else chkGioitinh.Checked = false;
            txtSoCMND.Text = gridviewKhachthue.CurrentRow.Cells["SoCMND"].Value.ToString();
            txtDiachithuongtru.Text = gridviewKhachthue.CurrentRow.Cells["Diachithuongtru"].Value.ToString();
            string sql,sq;
            sql = "Select Tennghe From tblNgheNghiep Where Manghe = N'" + gridviewKhachthue.CurrentRow.Cells["Manghe"].Value.ToString() + "'";
            cmbManghe.Text = DAO.GetFieldValues(sql);
            sq = "Select TenCQ From tblCoQuan Where MaCQ = N'" + gridviewKhachthue.CurrentRow.Cells["MaCQ"].Value.ToString() + "'";
            cmbMaCQ.Text = DAO.GetFieldValues(sq);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtMakhach.Enabled = true;
            txtMakhach.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string gt;
            if (txtMakhach.Text == "")
            {
                MessageBox.Show("Bạn không được để trống mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMakhach.Focus();
                return;
            }
            if (txtTenkhach.Text == "")
            {
                MessageBox.Show("Bạn không được để trống tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenkhach.Focus();
                return;
            }
            if (chkGioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            if (dtpNgaysinh.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaysinh.Focus();
                return;
            }
            if (txtSoCMND.Text == "")
            {
                MessageBox.Show("Bạn không được để trống số CMND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoCMND.Focus();
                return;
            }
            if (txtDiachithuongtru.Text == "")
            {
                MessageBox.Show("Bạn không được để trống địa chỉ thường trú", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachithuongtru.Focus();
                return;
            }
            if (cmbManghe.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn nghề nghiệp ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbMaCQ.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn cơ quan", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sql = "select * from tblKhachThue where Makhach = '" +
            txtMakhach.Text.Trim() + "'";
            string sq = "select * from tblKhachThue where SoCMND = '" +
            txtSoCMND.Text.Trim() + "'";
            DAO.OpenConnection();
            if (DAO.CheckKeyExit(sql))
            {
                MessageBox.Show("Mã khách này đã tồn tại, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMakhach.Focus();
                DAO.CloseConnection();
                return;
            }
            if (DAO.CheckKeyExit(sq))
            {
                MessageBox.Show("Số CMND đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMakhach.Focus();
                DAO.CloseConnection();
                return;
            }
            else
            {
                sql = "insert into  tblKhachThue (Makhach, Tenkhach, Ngaysinh,Gioitinh, " +
                    "SoCMND, Diachithuongtru, Manghe, MaCQ)" +
                    " values ('" + txtMakhach.Text.Trim() + "',N'"
                    + txtTenkhach.Text.Trim() + "', N'" + DAO.ConvertDateTime(dtpNgaysinh.Text.ToString())+ "',N'" +
                    gt + "',N'" + txtSoCMND.Text.Trim() + "',N'" + txtDiachithuongtru.Text.Trim() + 
                    "','" + cmbManghe.SelectedValue.ToString() + "','" + cmbMaCQ.SelectedValue.ToString() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                loadDataGridView();
                fillDataToComboNghenghiep();
                fillDataToComboCoquan();
                DAO.CloseConnection();

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtMakhach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMakhach.Focus();
                return;
            }
            if (txtTenkhach.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenkhach.Focus();
                return;
            }
            if (dtpNgaysinh.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaysinh.Focus();
                return;
            }
            if (txtSoCMND.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số CMND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoCMND.Focus();
                return;
            }
            if (txtDiachithuongtru.Text == "")
            {
                MessageBox.Show("Bạn phải nhập địa chỉ thường trú", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachithuongtru.Focus();
                return;
            }
            if (cmbManghe.Text == "")
            {
                MessageBox.Show("Bạn phải chọn nghề", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbManghe.Focus();
                return;
            }
            if (cmbMaCQ.Text == "")
            {
                MessageBox.Show("Bạn phải chọn cơ quan", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaCQ.Focus();
                return;
            }
            if (chkGioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "UPDATE tblKhachThue SET  Tenkhach=N'" + txtTenkhach.Text.Trim().ToString() +
                    "',Ngaysinh =N'" + DAO.ConvertDateTime(dtpNgaysinh.Value.ToString("MM/dd/yyyy")) + "',Gioitinh=N'" + gt +
                    "',SoCMND='" + txtSoCMND.Text.Trim() + "',Diachithuongtru=N'" + txtDiachithuongtru.Text.Trim() +
                    "',Manghe='" + cmbManghe.SelectedValue.ToString() + "',MaCQ='" + cmbMaCQ.SelectedValue.ToString() +
                    "' WHERE Makhach=N'" + txtMakhach.Text.Trim() + "'";
            DAO.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = DAO.con;
            cmd.ExecuteNonQuery();
            loadDataGridView();
            DAO.CloseConnection();           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sql = "delete from tblKhachThue where Makhach = '" + txtMakhach.Text + "'";
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
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Hỏi Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
