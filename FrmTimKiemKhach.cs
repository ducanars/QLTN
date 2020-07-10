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
    public partial class FrmTimKiemKhach : Form
    {
        DataTable tblKhach;
        public FrmTimKiemKhach()
        {
            InitializeComponent();
        }

        private void FrmTimKiemKhach_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            fillDataToComboDiachi();
            fillDataToComboKhachThue();
            fillDataToComboNghenghiep();
            DAO.CloseConnection();
            cmbdiachi.Text = "";
            cmbkhach.Text = "";
            cmbnghe.Text = "";
        }

        private void loadDataGridView()
        {
            gridviewTimkiemkhach.AllowUserToAddRows = false;
            gridviewTimkiemkhach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void fillDataToComboKhachThue()
        {
            string sql = "Select * from tblKhachThue";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbkhach.DataSource = table;
            cmbkhach.ValueMember = "Makhach";
            cmbkhach.DisplayMember = "Tenkhach";
        }

        public void fillDataToComboDiachi()
        {
            string sql = "Select * from tblKhachThue";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbdiachi.DataSource = table;
            cmbdiachi.ValueMember = "Diachithuongtru";
            cmbdiachi.DisplayMember = "Diachithuongtru";
        }
        public void fillDataToComboNghenghiep()
        {
            string sql = "Select * from tblNgheNghiep";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbnghe.DataSource = table;
            cmbnghe.ValueMember = "Manghe";
            cmbnghe.DisplayMember = "Tennghe";
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cmbkhach.Text == "") && (cmbnghe.Text == "") && (cmbdiachi.Text == ""))
            {
                MessageBox.Show("Hãy chọn một điều kiện tìm kiếm!!!", "Yêu cầu chọn Tên khách, Nghề nghiệp , Địa chỉ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "select  Makhach,Tenkhach,Ngaysinh,Gioitinh,SoCMND,Diachithuongtru,Manghe,MaCQ from tblKhachThue where 1=1";
            if (cmbkhach.Text != "")
            {
                sql = sql + " AND Makhach Like '%" + cmbkhach.SelectedValue + "%'";
            }
            if (cmbnghe.Text != "")
            {
                sql = sql + " AND Manghe Like '%" + cmbnghe.SelectedValue + "%'";
            }
            if (cmbdiachi.Text != "")
            {
                sql = sql + " AND Diachithuongtru Like '%" + cmbdiachi.SelectedValue + "%'";
            }

            tblKhach = DAO.GetDataToTable(sql);
            if (tblKhach.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi nào thỏa mãn điều kiện!!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblKhach.Rows.Count + " Bản ghi thỏa mãn điều kiện!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridviewTimkiemkhach.DataSource = tblKhach;
            cmbnghe.Enabled = false;
            cmbkhach.Enabled = false;
            cmbdiachi.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            cmbnghe.Enabled = true;
            cmbkhach.Enabled = true;
            cmbdiachi.Enabled = true;
            cmbnghe.SelectedIndex = -1;
            cmbkhach.SelectedIndex = -1;
            cmbdiachi.SelectedIndex = -1;
            gridviewTimkiemkhach.DataSource = null;
        }
    }
}
