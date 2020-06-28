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
            cmbKhach.Text = "";
            cmbNha.Text = "";
            cmbMucdich.Text = "";
            cmbHinhthucthanhtoan.Text = "";
           // cmbNha.SelectedIndexChanged += cmbNha_SelectedIndexChanged;
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblThueNha ";
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
            string sql = "Select * from tblDanhMucNha where Dathue=N'Chưa cho thuê'" ;
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbNha.DataSource = table;
            cmbNha.ValueMember = "Manha";
            cmbNha.DisplayMember = "Manha";
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
            string sql, sql1,sql2;
            sql = "Select Tenkhach From tblKhachThue Where Makhach = N'" + gridviewThuenha.CurrentRow.Cells["Makhach"].Value.ToString() + "'";
            cmbKhach.Text = DAO.GetFieldValues(sql);           
            cmbNha.Text = gridviewThuenha.CurrentRow.Cells["Manha"].Value.ToString();
            sql1 = "Select TenmucdichSD From tblMucDichSuDung Where MamucdichSD = N'" + gridviewThuenha.CurrentRow.Cells["MamucdichSD"].Value.ToString() + "'";
            cmbMucdich.Text = DAO.GetFieldValues(sql1);
            dtpNgaybatdau.Text = gridviewThuenha.CurrentRow.Cells["NgayBD"].Value.ToString();
            dtpNgayketthuc.Text = gridviewThuenha.CurrentRow.Cells["NgayKT"].Value.ToString();
            txtTiendatcoc.Text = gridviewThuenha.CurrentRow.Cells["Tiendatcoc"].Value.ToString();
            sql2 = "Select TenhinhthucTT From tblHinhThucThanhToan Where MahinhthucTT = N'" + gridviewThuenha.CurrentRow.Cells["MahinhthucTT"].Value.ToString() + "'";
            cmbHinhthucthanhtoan.Text = DAO.GetFieldValues(sql2);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
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
                    " values ('" + txtMasothue.Text.Trim() + "','" + cmbKhach.SelectedValue.ToString() + "', '" 
                    + cmbNha.SelectedValue.ToString() + "','" + cmbMucdich.SelectedValue.ToString() + "',N'" 
                    + DAO.ConvertDateTime(dtpNgaybatdau.Text.ToString()) + "',N'" + DAO.ConvertDateTime(dtpNgayketthuc.Text.ToString()) +
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
            sql = "UPDATE tblThueNha SET  Makhach='" + cmbKhach.SelectedValue.ToString() + "',Manha =N'" + cmbNha.SelectedValue.ToString() + "',MamucdichSD='" 
                + cmbMucdich.SelectedValue.ToString() + "',NgayBD=N'" + DAO.ConvertDateTime(dtpNgaybatdau.Value.ToString("MMt/dd/yyyy")) + 
                "',NgayKT=N'" + DAO.ConvertDateTime(dtpNgayketthuc.Value.ToString("MM/dd/yyyy")) + "',Tiendatcoc='" 
                + txtTiendatcoc.Text.Trim() + "',MahinhthucTT='" + cmbHinhthucthanhtoan.SelectedValue.ToString() + "' WHERE Masothue='" + txtMasothue.Text + "'";
            DAO.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = DAO.con;
            cmd.ExecuteNonQuery();
            loadDataGridView();
            DAO.CloseConnection();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void cmbNha_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if (cmbNha.SelectedIndex != -1)
            {
                double dg;
                string str;
                str = "select a.Dongiathue from tblDanhMucNha as a join tblThueNha as b  on a.Manha=b.Manha where b.Manha='" + cmbNha.SelectedValue.ToString() + "' ";
                DAO.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = str;
                cmd.Connection = DAO.con;
                 dg = Convert.ToDouble(DAO.GetFieldValues(str));
                txtTiendatcoc.Text = dg.ToString();
            }
        }
    }
}

