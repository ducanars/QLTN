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
    public partial class frmNha_Taisan : Form
    {
        public frmNha_Taisan()
        {
            InitializeComponent();
        }

        private void frmNha_Taisan_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            fillDataToComboNha();
            fillDataToComboTaisan();
            DAO.CloseConnection();
            cmbTaisan.Text = "";
            cmbManha.Text = "";
            txtTenchunha.Text = "";
            txtTenchunha.Enabled = false;
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblNha_TaiSan";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewNha_taisan.DataSource = table;
        }

        public void fillDataToComboNha()
        {
            string sql = "Select * from tblDanhMucNha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbManha.DataSource = table;
            cmbManha.ValueMember = "Manha";
            cmbManha.DisplayMember = "Manha";
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
            txtTinhtrang.Text = "";
            cmbTaisan.SelectedIndex = -1;
        }
        private void EnableValue()
        {
            cmbTaisan.Enabled = true;
            txtTinhtrang.Enabled = true;
            txtSoluong.Enabled = true;
            txtGiatri.Enabled = true;
            cmbTaisan.SelectedIndex = -1;
        }

        private void gridviewNha_taisan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql1;
            cmbManha.Text = gridviewNha_taisan.CurrentRow.Cells["Manha"].Value.ToString();
            sql1 = "Select Tentaisan From tblTaiSan Where Mataisan = N'" + gridviewNha_taisan.CurrentRow.Cells["Mataisan"].Value.ToString() + "'";
            cmbTaisan.Text = DAO.GetFieldValues(sql1);
            txtSoluong.Text = gridviewNha_taisan.CurrentRow.Cells["Soluong"].Value.ToString();
            txtGiatri.Text = gridviewNha_taisan.CurrentRow.Cells["Giatri"].Value.ToString();
            txtTinhtrang.Text = gridviewNha_taisan.CurrentRow.Cells["Tinhtrang"].Value.ToString();
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
            //Kiem tra DL
            //Các trường không được trống
            if (cmbManha.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn nhà!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbTaisan.SelectedIndex == -1)
            {
                    MessageBox.Show("Bạn chưa chọn tài sản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }
            if (txtGiatri.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiatri.Focus();
                return;
            }
            if (txtSoluong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }
            if (txtTinhtrang.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tình trạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTinhtrang.Focus();
                return;
            }
            //
            string sql = "select * from tblNha_TaiSan where Manha='" + cmbManha.SelectedValue.ToString() + "' and Mataisan='" + cmbTaisan.SelectedValue.ToString() + "'";
            DAO.OpenConnection();
            if (DAO.CheckKeyExit(sql))
            {
                MessageBox.Show("Tài sản này đã tồn tại trong nhà bạn chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.CloseConnection();
                cmbManha.Focus();
                return;
            }
            else
            {
                sql = "insert into tblNha_TaiSan (Manha,Mataisan,Soluong,Giatri,Tinhtrang) " +
                    " values ('" + cmbManha.SelectedValue.ToString() + "','" + cmbTaisan.SelectedValue.ToString() + "',"
                    + txtSoluong.Text.Trim() + "," + txtGiatri.Text.Trim() + ",N'" + txtTinhtrang.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sql = "delete from tblNha_TaiSan where Manha = '" + cmbManha.SelectedValue.ToString() + "' and Mataisan='" + cmbTaisan.SelectedValue.ToString() + "'";
                DAO.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = DAO.con;
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                loadDataGridView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cmbManha.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn nhà!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbTaisan.SelectedIndex == -1)
            {
                    MessageBox.Show("Bạn chưa chọn tài sản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }
            if (txtGiatri.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá trị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiatri.Focus();
                return;
            }
            if (txtSoluong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }
            if (txtTinhtrang.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tình trạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTinhtrang.Focus();
                return;
            }
            string sql = "update tblNha_TaiSan set Soluong = " + txtSoluong.Text.Trim() + ", Giatri=" + txtGiatri.Text.Trim()
                + ", Tinhtrang=N'" + txtTinhtrang.Text.Trim() + " ' where Manha = '" + cmbManha.SelectedValue.ToString() 
                + "' and Mataisan='" + cmbTaisan.SelectedValue.ToString() + "'";
            DAO.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = DAO.con;
            cmd.ExecuteNonQuery();
            loadDataGridView();
            DAO.CloseConnection();
        }

        private void cmbManha_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            if (cmbManha.Text == "")
            {
                txtTenchunha.Text = "";
                return;
            }
            sql = "SELECT Tenchunha FROM tblDanhMucNha WHERE Manha = '" + cmbManha.Text + "'";
            DataTable table = DAO.DocBang(sql);
            if (table.Rows.Count > 0)
            {
                txtTenchunha.Text = table.Rows[0][0].ToString();
            }
        }
    }
}
