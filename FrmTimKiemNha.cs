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
using System.Data.Sql;

namespace QLTN
{
    public partial class FrmTimKiemNha : Form
    {
        DataTable tblNha;
        public FrmTimKiemNha()
        {
            InitializeComponent();
        }

        private void FrmTimKiemNha_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            fillDataToComboLoainha();
            fillDataToComboDoituongsudung();
            fillDataToComboDiachi();
            DAO.CloseConnection();
            cmbLoainha.Text = "";
            cmbDoituongsudung.Text = "";
            cmbDiachi.Text = "";
        }
        private void loadDataGridView()
        {
            gridviewTimkiemnha.AllowUserToAddRows = false;
            gridviewTimkiemnha.EditMode = DataGridViewEditMode.EditProgrammatically;
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
        public void fillDataToComboDiachi()
        {
            string sql = "Select * from tblDanhMucNha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbDiachi.DataSource = table;
            cmbDiachi.ValueMember = "Diachi";
            cmbDiachi.DisplayMember = "Diachi";
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cmbLoainha.Text == "") && (cmbDoituongsudung.Text == "") && (cmbDiachi.Text == ""))
            {
                MessageBox.Show("Hãy chọn một điều kiện tìm kiếm!!!", "Yêu cầu chọn Loại nhà, Đối tượng sử dụng , Địa chỉ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "select  Manha,Tenchunha,Dienthoai,Maloai,MaDTSD,Diachi,Dongiathue,Tinhtrang,Dathue from tblDanhMucNha where 1=1";
            if (cmbLoainha.Text != "")
            {
                sql = sql + " AND Maloai Like '%" + cmbLoainha.SelectedValue + "%'";
            }
            if (cmbDoituongsudung.Text != "")
            {
                sql = sql + " AND MaDTSD Like '%" + cmbDoituongsudung.SelectedValue + "%'";
            }
            if (cmbDiachi.Text != "")
            {
                sql = sql + " AND Diachi Like '%" + cmbDiachi.SelectedValue + "%'";
            }

            tblNha = DAO.GetDataToTable(sql);
            if (tblNha.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi nào thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblNha.Rows.Count + " Bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridviewTimkiemnha.DataSource = tblNha;
            cmbLoainha.Enabled = false;
            cmbDoituongsudung.Enabled = false;
            cmbDiachi.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            cmbLoainha.Enabled = true;
            cmbDoituongsudung.Enabled = true;
            cmbDiachi.Enabled = true;
            cmbLoainha.SelectedIndex = -1;
            cmbDoituongsudung.SelectedIndex = -1;
            cmbDiachi.SelectedIndex = -1;
            gridviewTimkiemnha.DataSource = null;
        }

    }
}
