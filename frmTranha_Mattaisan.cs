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
    public partial class frmTranha_Mattaisan : Form
    {
        public frmTranha_Mattaisan()
        {
            InitializeComponent();
        }

        private void frmTranha_Mattaisan_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            fillDataToComboThuenha();
            fillDataToComboTaisan();
            DAO.CloseConnection();
            cmbTaisan.Text = "";
            cmbMasothue.Text = "";
            cmbMasothue.SelectedIndexChanged += cmbMasothue_SelectedIndexChanged;
            txtSoluong.TextChanged += txtSoluong_TextChanged;
            txtGiatri.TextChanged += txtGiatri_TextChanged;
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblTraNha_MatTaiSan";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewTranha_Mattaisan.DataSource = table;
        }

        public void fillDataToComboThuenha()
        {
            string sql = "Select * from tblThueNha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbMasothue.DataSource = table;
            cmbMasothue.ValueMember = "Masothue";
            cmbMasothue.DisplayMember = "Masothue";
        }

        public void fillDataToComboTaisan()
        {
            string sql = "Select * from tblTaiSan";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbTaisan.DataSource = table;
            cmbTaisan.ValueMember = "Mataisan";
            cmbTaisan.DisplayMember = "Tentaisan";
        }
        private void ResetValue()
        {
            txtGiatri.Text = "";
            txtSoluong.Text = "";
            txtThanhtien.Text = "";
            cmbTaisan.SelectedIndex = -1;
        }
        private void EnableValue()
        {
            cmbTaisan.Enabled = true;
            txtThanhtien.Enabled = true;
            txtSoluong.Enabled = true;
            txtGiatri.Enabled = true;
            cmbTaisan.SelectedIndex = -1;
        }

        private void gridviewTranha_Mattaisan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbMasothue.Text = gridviewTranha_Mattaisan.CurrentRow.Cells["Masothue"].Value.ToString();
            cmbTaisan.Text = gridviewTranha_Mattaisan.CurrentRow.Cells["Mataisan"].Value.ToString();
            txtSoluong.Text = gridviewTranha_Mattaisan.CurrentRow.Cells["Soluong"].Value.ToString();
            txtGiatri.Text = gridviewTranha_Mattaisan.CurrentRow.Cells["Giatri"].Value.ToString();
            txtThanhtien.Text = gridviewTranha_Mattaisan.CurrentRow.Cells["Thanhtien"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            EnableValue();
            cmbTaisan.Enabled = true;
            cmbTaisan.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cmbMasothue.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn mã thuê nhà!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbTaisan.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn tài sản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSoluong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }
            //
            string sql = "select * from tblTraNha_MatTaiSan where Masothue='" + cmbMasothue.SelectedValue.ToString() + "' and Mataisan='" + cmbTaisan.SelectedValue.ToString() + "'";
            DAO.OpenConnection();
            if (DAO.CheckKeyExit(sql))
            {
                MessageBox.Show("Tài sản này đã được kê khai trong nhà bạn chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.CloseConnection();
                cmbMasothue.Focus();
                return;
            }
            else
            {
                sql = "insert into tblTraNha_MatTaiSan (Masothue,Mataisan,Soluong,Giatri,Thanhtien) " +
                    " values ('" + cmbMasothue.SelectedValue.ToString() + "','" + cmbTaisan.SelectedValue.ToString() + "',"
                    + txtSoluong.Text.Trim() + "," + txtGiatri.Text.Trim() + ",N'" + txtThanhtien.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                loadDataGridView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cmbMasothue.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn mã số thuê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbTaisan.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn tài sản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtSoluong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }

            string sql = "update tblTraNha_MatTaiSan set Soluong = " + txtSoluong.Text.Trim() + ", Giatri=" + txtGiatri.Text.Trim()
                + ", Thanhtien=N'" + txtThanhtien.Text.Trim() + " ' where Masothue = '" + cmbMasothue.SelectedValue.ToString()
                + "' and Mataisan='" + cmbTaisan.SelectedValue.ToString() + "'";
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
                string sql = "delete from tblTraNha_MatTaiSan where Masothue = '" + cmbMasothue.SelectedValue.ToString() + "' and Mataisan='" + cmbTaisan.SelectedValue.ToString() + "'";
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

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, gt;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtGiatri.Text == "")
                gt = 0;
            else
               gt = Convert.ToDouble(txtGiatri.Text);
            tt = sl * gt;
            txtThanhtien.Text = tt.ToString();

        }

        private void txtGiatri_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, gt;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtGiatri.Text == "")
                gt = 0;
            else
                gt = Convert.ToDouble(txtGiatri.Text);
            tt = sl * gt;
            txtThanhtien.Text = tt.ToString();
        }

        private void cmbMasothue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMasothue.SelectedIndex != -1)
            {
                string str;
                str = "select  d.Mataisan,d.Tentaisan from  tblThueNha as b  join tblNha_TaiSan as c on b.Manha=c.MaNha " +
                      "join tblTaiSan as d on c.Mataisan=d.Mataisan where b.Masothue='" + cmbMasothue.SelectedValue + "'" ;
                DAO.FillDataToCombo(str, cmbTaisan, "Mataisan", "Tentaisan");
            }

            cmbTaisan.Text = "";
        }

        
    }
}
