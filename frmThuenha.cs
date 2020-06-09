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
    public partial class frmThuenha : Form
    {
        public frmThuenha()
        {
            InitializeComponent();
        }

        private void frmThuenha_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            fillDataToComboKhachthue();
            fillDataToComboDanhmucnha();
            fillDataToComboMucdich();
            fillDataToComboHinhthuc();
            DAO.CloseConnection();
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblThueNha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewThuenha.DataSource = table;
        }

        public void fillDataToComboKhachthue()
        {
            string sql = "Select * from tblKhachThue";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbKhach.DataSource = table;
            cmbKhach.ValueMember = "Makhach";
            cmbKhach.DisplayMember = "Tenkhach";
        }

        public void fillDataToComboDanhmucnha()
        {
            string sql = "Select * from tblDanhMucNha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbNha.DataSource = table;
            cmbNha.ValueMember = "Manha";
            cmbNha.DisplayMember = "Tenchunha";
        }

        public void fillDataToComboMucdich()
        {
            string sql = "Select * from tblMucDichSuDung";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbMucdich.DataSource = table;
            cmbMucdich.ValueMember = "MamucdichSD";
            cmbMucdich.DisplayMember = "TenmucdichSD";
        }

        public void fillDataToComboHinhthuc()
        {
            string sql = "Select * from tblHinhThucThanhToan";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbHinhthucthanhtoan.DataSource = table;
            cmbHinhthucthanhtoan.ValueMember = "MahinhthucTT";
            cmbHinhthucthanhtoan.DisplayMember = "TenhinhthucTT";
        }

        private void ResetValue()
        {
            txtMasothue.Text = "";
            cmbKhach.SelectedIndex = -1;
            cmbNha.SelectedIndex = -1;
            cmbMucdich.SelectedIndex = -1;
            dtpNgaybatdau.Text = "";
            dtpNgayketthuc.Text = "";
            txtTiendatcoc.Text = "";
            cmbHinhthucthanhtoan.SelectedIndex = -1;
        }

        private void gridviewThuenha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMasothue.Text = gridviewThuenha.CurrentRow.Cells["Masothue"].Value.ToString();
            cmbKhach.Text = gridviewThuenha.CurrentRow.Cells["Makhach"].Value.ToString();
            cmbNha.Text = gridviewThuenha.CurrentRow.Cells["Manha"].Value.ToString();
            cmbMucdich.Text = gridviewThuenha.CurrentRow.Cells["MamucdichSD"].Value.ToString();
            dtpNgaybatdau.Text = gridviewThuenha.CurrentRow.Cells["NgayBD"].Value.ToString();
            dtpNgayketthuc.Text = gridviewThuenha.CurrentRow.Cells["NgayKT"].Value.ToString();
            cmbHinhthucthanhtoan.Text = gridviewThuenha.CurrentRow.Cells["MahinhthucTT"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtMasothue.Enabled = true;
            txtMasothue.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMasothue.Text == "")
            {
                MessageBox.Show("Bạn không được để trống mã số thuê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasothue.Focus();
                return;
            }
            if (cmbKhach.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn khách thuê ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbNha.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn nhà", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbMucdich.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn mục đích sử dụng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpNgaybatdau.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaybatdau.Focus();
                return;
            }
            if (dtpNgayketthuc.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayketthuc.Focus();
                return;
            }
            if (txtTiendatcoc.Text == "")
            {
                MessageBox.Show("Bạn không được để trống số tiền đặt cọc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTiendatcoc.Focus();
                return;
            }
            if (cmbHinhthucthanhtoan.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn hình thức thanh toán ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sql = "select * from tblThueNha where Masothue = '" +
            txtMasothue.Text.Trim() + "'";
            DAO.OpenConnection();
            if (DAO.CheckKeyExit(sql))
            {
                MessageBox.Show("Mã số thuê đã tồn tại");
                txtMasothue.Focus();
                DAO.CloseConnection();
                return;
            }
            else
            {
                sql = "insert into  tblThueNha (Masothue, Makhach,Manha,MamucdichSD,NgayBD,NgayKT,Tiendatcoc,MahinhthucTT)" +
                    " values ('" + txtMasothue.Text.Trim() + "','"
                    + cmbKhach.SelectedValue.ToString() + "', '" + cmbNha.SelectedValue.ToString() + "','" +
                    cmbMucdich.SelectedValue.ToString() + "',N'" + DAO.ConvertDateTime(dtpNgaybatdau.Text.ToString()) 
                    + "',N'" + DAO.ConvertDateTime(dtpNgayketthuc.Text.ToString()) +
                    "','" + txtTiendatcoc.Text.Trim() + "','" + cmbHinhthucthanhtoan.SelectedValue.ToString() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                MessageBox.Show(sql);
                cmd.ExecuteNonQuery();
                loadDataGridView();
                fillDataToComboKhachthue();
                fillDataToComboDanhmucnha();
                fillDataToComboMucdich();
                fillDataToComboHinhthuc();
                DAO.CloseConnection();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMasothue.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã số thuê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasothue.Focus();
                return;
            }
            if (cmbKhach.Text == "")
            {
                MessageBox.Show("Bạn phải chọn khách thuê ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbNha.Text == "")
            {
                MessageBox.Show("Bạn phải chọn nhà", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbNha.Focus();
                return;
            }
            if (cmbMucdich.Text == "")
            {
                MessageBox.Show("Bạn phải chọn mục đích sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMucdich.Focus();
                return;
            }
            if (dtpNgaybatdau.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaybatdau.Focus();
                return;
            }
            if (dtpNgayketthuc.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayketthuc.Focus();
                return;
            }
            if (txtTiendatcoc.Text == "")
            {
                MessageBox.Show("Bạn phải nhập số tiền đặt cọc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTiendatcoc.Focus();
                return;
            }
            if (cmbHinhthucthanhtoan.Text == "")
            {
                MessageBox.Show("Bạn phải chọn hình thức thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHinhthucthanhtoan.Focus();
                return;
            }
            sql = "UPDATE tblThueNha SET  Makhach='" + cmbKhach.Text.Trim() + "',Manha =N'" + cmbNha.Text.Trim() + "',MamucdichSD='" 
                + cmbMucdich.Text.Trim() + "',NgayBD=N'" + DAO.ConvertDateTime(dtpNgaybatdau.Value.ToString("dd/MM/yyyy")) + 
                "',NgayKT=N'" + DAO.ConvertDateTime(dtpNgayketthuc.Value.ToString("dd/MM/yyyy")) + "',Tiendatcoc='" 
                + txtTiendatcoc.Text.Trim() + "',MahinhthucTT='" + cmbHinhthucthanhtoan.Text.Trim() + "' WHERE Masothue='" + txtMasothue.Text + "'";
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
                string sql = "delete from tblThueNha where Makhach = '" + txtMasothue.Text + "'";
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

