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
    public partial class frmDanhmucnha : Form
    {
        public frmDanhmucnha()
        {
            InitializeComponent();
        }

        private void frmDanhmucnha_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            fillDataToComboLoainha();
            fillDataToComboDoituongsudung();
            DAO.CloseConnection();
            cmbLoainha.Text = "";
            cmbDoituongsudung.Text = "";
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblDanhMucNha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewDanhmucnha.DataSource = table;
        }

        public void fillDataToComboLoainha()
        {
            string sql = "Select * from tblLoaiNha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbLoainha.DataSource = table;
            cmbLoainha.ValueMember = "Maloai";
            cmbLoainha.DisplayMember = "Tenloai";
        }

        public void fillDataToComboDoituongsudung()
        {
            string sql = "Select * from tblDoiTuongSuDung";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbDoituongsudung.DataSource = table;
            cmbDoituongsudung.ValueMember = "MaDTSD";
            cmbDoituongsudung.DisplayMember = "TenDTSD";
        }

        private void ResetValue()
        {
            txtManha.Text = "";
            txtTenchunha.Text = "";
            txtDienthoai.Text = "";
            cmbLoainha.SelectedIndex = -1;
            cmbDoituongsudung.SelectedIndex = -1;
            txtDiachi.Text = "";
            txtDongiathue.Text = "";
            txtTinhtrang.Text = "";
            chkDathue.Checked = false;
            txtGhichu.Text = "";       
        }

        private void gridviewDanhmucnha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtManha.Text = gridviewDanhmucnha.CurrentRow.Cells["Manha"].Value.ToString();
            txtTenchunha.Text = gridviewDanhmucnha.CurrentRow.Cells["Tenchunha"].Value.ToString();
            txtDienthoai.Text = gridviewDanhmucnha.CurrentRow.Cells["Dienthoai"].Value.ToString();
            string sql1,sql2;
            sql1 = "Select Tenloai From tblLoaiNha Where Maloai = N'" + gridviewDanhmucnha.CurrentRow.Cells["Maloai"].Value.ToString() + "'";
            cmbLoainha.Text = DAO.GetFieldValues(sql1);
            sql2 = "Select TenDTSD From tblDoiTuongSudung Where MaDTSD = N'" + gridviewDanhmucnha.CurrentRow.Cells["MaDTSD"].Value.ToString() + "'";
            cmbDoituongsudung.Text = DAO.GetFieldValues(sql2);
            txtDiachi.Text = gridviewDanhmucnha.CurrentRow.Cells["Diachi"].Value.ToString();
            txtDongiathue.Text = gridviewDanhmucnha.CurrentRow.Cells["Dongiathue"].Value.ToString();
            txtTinhtrang.Text = gridviewDanhmucnha.CurrentRow.Cells["Tinhtrang"].Value.ToString();
            if (gridviewDanhmucnha.CurrentRow.Cells["Dathue"].Value.ToString() == "Chưa cho thuê") chkDathue.Checked = true;
            else chkDathue.Checked = false;
            txtGhichu.Text = gridviewDanhmucnha.CurrentRow.Cells["Ghichu"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtManha.Enabled = true;
            txtManha.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string dt;
/*            if (txtManha.Text == "")
            {
                MessageBox.Show("Bạn không được để trống mã nhà");
                txtManha.Focus();
                return;
            }*/
            if (txtTenchunha.Text == "")
            {
                MessageBox.Show("Bạn không được để trống tên chủ nhà", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenchunha.Focus();
                return;
            }
            if (txtDienthoai.Text == "")
            {
                MessageBox.Show("Bạn không được để trống số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienthoai.Focus();
                return;
            }
            if (cmbLoainha.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn loại nhà ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbDoituongsudung.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn đối tượng sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Bạn không được để trống địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (txtDongiathue.Text == "")
            {
                MessageBox.Show("Bạn không được để trống đơn giá thuê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongiathue.Focus();
                return;
            }
            if (txtTinhtrang.Text == "")
            {
                MessageBox.Show("Bạn không được để trống tình trạng phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTinhtrang.Focus();
                return;
            }
            if (chkDathue.Checked == true)
                dt = "Chưa cho thuê";
            else
                dt = "Đã cho thuê";
            if (txtGhichu.Text == "")
            {
                MessageBox.Show("Bạn không được để trống ghi chú", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGhichu.Focus();
                return;
            }
            
            
            string sql = "select * from tblDanhMucNha where Manha = '" +
            txtManha.Text.Trim() + "'";
            string sq = "select * from tblDanhMucNha where Dienthoai = '" +
            txtManha.Text.Trim() + "'";
            DAO.OpenConnection();
            if (DAO.CheckKeyExit(sql))
            {
                MessageBox.Show("Mã nhà đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManha.Focus();
                DAO.CloseConnection();
                return;
            }
            if (DAO.CheckKeyExit(sq))
            {
                MessageBox.Show("Số điện thoại đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManha.Focus();
                DAO.CloseConnection();
                return;
            }
            else
            {
                sql = "insert into  tblDanhMucNha (Manha, Tenchunha, Dienthoai,Maloai, " +
                    "MaDTSD, Diachi, Dongiathue, Tinhtrang,Dathue,Ghichu)" +
                    " values (N'" + txtManha.Text.Trim() + "',N'"
                    + txtTenchunha.Text.Trim() + "', '" + txtDienthoai.Text.Trim()  + "','" +
                    cmbLoainha.SelectedValue.ToString() + "','" + cmbDoituongsudung.SelectedValue.ToString() 
                    + "',N'" + txtDiachi.Text.Trim() + "','" + txtDongiathue.Text.Trim() + "',N'" + txtTinhtrang.Text.Trim() 
                    + "',N'" + dt + "',N'"+ txtGhichu.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                loadDataGridView();
                fillDataToComboLoainha();
                fillDataToComboDoituongsudung();
                DAO.CloseConnection();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, dt;
            if (txtManha.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã nhà", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManha.Focus();
                return;
            }
            if (txtTenchunha.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập tên chủ nhà", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenchunha.Focus();
                return;
            }
            if (txtDienthoai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienthoai.Focus();
                return;
            }
            if (cmbLoainha.Text == "")
            {
                MessageBox.Show("Bạn phải chọn loại nhà", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbLoainha.Focus();
                return;
            }
            if (cmbDoituongsudung.Text == "")
            {
                MessageBox.Show("Bạn phải chọn đối tượng sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDoituongsudung.Focus();
                return;
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (txtDongiathue.Text == "")
            {
                MessageBox.Show("Bạn phải nhập đơn giá thuê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongiathue.Focus();
                return;
            }
            if (txtTinhtrang.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tình trạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTinhtrang.Focus();
                return;
            }
            if (chkDathue.Checked == true)
                dt = "Chưa cho thuê";
            else
                dt = "Đã cho thuê";
            if (txtGhichu.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ghi chú", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGhichu.Focus();
                return;
            }
            sql = "UPDATE tblDanhMucNha SET  Tenchunha=N'" + txtTenchunha.Text.Trim().ToString() +
                    "',Dienthoai ='" + txtDienthoai.Text.Trim() + "',Maloai='" + cmbLoainha.SelectedValue.ToString() + "',MaDTSD='" 
                    + cmbDoituongsudung.SelectedValue.ToString() +  "',Diachi=N'" + txtDiachi.Text.Trim() + "',Dongiathue='" 
                    + txtDongiathue.Text.Trim() + "',Tinhtrang=N'" + txtTinhtrang.Text.Trim() + "',Dathue=N'" + 
                    dt + "',Ghichu='" + txtGhichu.Text.Trim() + "' WHERE Manha='" + txtManha.Text.Trim() + "'";
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
                string sql = "delete from tblDanhMucNha where Manha = '" + txtManha.Text + "'";
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
