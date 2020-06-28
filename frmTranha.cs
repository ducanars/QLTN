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
    public partial class frmTranha : Form
    {
        public frmTranha()
        {
            InitializeComponent();
        }

        private void frmTranha_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            fillDataToCombo();
            DAO.CloseConnection();
            cmbMasothue.Text = "";
            dtpNgaytra.ValueChanged += dtpNgaytra_ValueChanged;
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblTraNha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewTranha.DataSource = table;
        }

        public void fillDataToCombo()
        {
            string sql = "Select * from tblThueNha as a join tblDanhMucNha as b on a.Manha=b.Manha where b.Dathue=N'Đã cho thuê'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbMasothue.DataSource = table;
            cmbMasothue.ValueMember = "Masothue";
            cmbMasothue.DisplayMember = "Masothue";
        }

        private void ResetValue()
        {
            cmbMasothue.SelectedIndex = -1;
            dtpNgaytra.Text = "";
            txtTongtien.Text = "";
        }

        private void gridviewTranha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbMasothue.Text = gridviewTranha.CurrentRow.Cells["Masothue"].Value.ToString();
            dtpNgaytra.Text = gridviewTranha.CurrentRow.Cells["Ngaytra"].Value.ToString();
            txtTongtien.Text = gridviewTranha.CurrentRow.Cells["Tongtien"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            cmbMasothue.Enabled = true;
            cmbMasothue.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cmbMasothue.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn mã nhà thuê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpNgaytra.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ngày trả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaytra.Focus();
                return;
            }
            if (txtTongtien.Text == "")
            {
                MessageBox.Show("Bạn không được để trống tổng tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTongtien.Focus();
                return;
            }
            string sql = "select * from tblTraNha where Masothue = '" +
            cmbMasothue.SelectedValue.ToString() + "'";
            DAO.OpenConnection();
            if (DAO.CheckKeyExit(sql))
            {
                MessageBox.Show("Mã số thuê đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMasothue.Focus();
                DAO.CloseConnection();
                return;
            }
            else
            {
                sql = "insert into  tblTraNha (Masothue, Ngaytra, Tongtien) " +
                    " values ('" + cmbMasothue.SelectedValue.ToString() + "',N'"
                    + DAO.ConvertDateTime(dtpNgaytra.Text.ToString()) + "',N'" +
                     txtTongtien.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                MessageBox.Show(sql);
                cmd.ExecuteNonQuery();
                loadDataGridView();
                fillDataToCombo();
                DAO.CloseConnection();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cmbMasothue.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn mã nhà thuê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpNgaytra.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ngày trả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaytra.Focus();
                return;
            }
            if (txtTongtien.Text == "")
            {
                MessageBox.Show("Bạn không được để trống tổng tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTongtien.Focus();
                return;
            }
            string sql = "UPDATE tblTraNha SET  Ngaytra=N'" + DAO.ConvertDateTime(dtpNgaytra.Value.ToString("dd/MM/yyyy")) +
                    "',Tongtien =" + txtTongtien.Text.Trim() + " WHERE Masothue='" + cmbMasothue.SelectedValue.ToString() + "'";
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
                string sql = "delete from tblTraNha where Masothue = '" + cmbMasothue.SelectedValue.ToString() + "'";
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

        private void dtpNgaytra_ValueChanged(object sender, EventArgs e)
        {

            DateTime Ngay = DateTime.Parse(dtpNgaytra.Text);
            DateTime Ngay2 = DateTime.Parse(txtNgayketthuc.Text);
            double tt,bt,dc;
            string sql = "select sum(Thanhtien) from tblTraNha_MatTaiSan where Masothue='" + cmbMasothue.SelectedValue + "'";
            DAO.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = DAO.con;
            bt = Convert.ToDouble(sql);
            string sql1 = "select Tiendatcoc from tblThueNha where Masothue='" + cmbMasothue.SelectedValue + "' ";
            SqlCommand cmd1 = new SqlCommand();
            cmd.CommandText = sql1;
            cmd.Connection = DAO.con;
            dc = Convert.ToDouble(sql1);
            if (Ngay < Ngay2)
                tt = bt;
            else
                tt = bt - dc;
            txtTongtien.Text = tt.ToString();
        }

        private void cmbMasothue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMasothue.SelectedIndex != -1)
            {
                txtNgayketthuc.Text = DAO.GetFieldValues("select NgayKT from tblThueNha where Masothue = '" + cmbMasothue.SelectedValue.ToString() + "'");

            }
        }
    }
}
