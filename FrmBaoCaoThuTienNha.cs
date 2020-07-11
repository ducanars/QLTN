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
    public partial class FrmBaoCaoThuTienNha : Form
    {
        public FrmBaoCaoThuTienNha()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoThuTienNha_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            fillDataToComboNha();
            DAO.CloseConnection();
            cmbMasothue.SelectedIndex = -1;
            txtTongtienthu.Enabled = true;
            txtManha.Enabled = false;
            txtTenkhach.Enabled = false;
            txtDiachi.Enabled = false;
            txtManha.Text = "";
            txtTenkhach.Text = "";
            txtDiachi.Text = "";

        }
        public void fillDataToComboNha()
        {
            string sql = "Select * from tblThueNha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbMasothue.DataSource = table;
            cmbMasothue.ValueMember = "Masothue";
            cmbMasothue.DisplayMember = "Masothue";
        }


        private void cmbMasothue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMasothue.SelectedIndex != -1)
            {

                string sql, sql1,sql2;
                if (cmbMasothue.Text == "")
                {
                    txtManha.Text = "";
                    return;
                }
                sql = "SELECT Manha FROM tblThueNha WHERE Masothue = '" + cmbMasothue.Text + "'";
                DataTable table = DAO.DocBang(sql);
                if (table.Rows.Count > 0)
                {
                    txtManha.Text = table.Rows[0][0].ToString();
                }
                if (cmbMasothue.Text == "")
                {
                    txtTenkhach.Text = "";
                    return;
                }
                sql1 = "SELECT b.Tenkhach FROM tblThueNha as a join tblKhachThue as b on a.Makhach=b.Makhach WHERE a.Masothue = '" + cmbMasothue.Text + "'";
                DataTable table1 = DAO.DocBang(sql1);
                if (table1.Rows.Count > 0)
                {
                    txtTenkhach.Text = table1.Rows[0][0].ToString();
                }
                if (cmbMasothue.Text == "")
                {
                    txtDiachi.Text = "";
                    return;
                }
                sql2 = "SELECT b.Diachi FROM tblThueNha as a join tblDanhMucNha as b on a.Manha=b.Manha WHERE Masothue = '" + cmbMasothue.Text + "'";
                DataTable table2 = DAO.DocBang(sql2);
                if (table2.Rows.Count > 0)
                {
                    txtDiachi.Text = table2.Rows[0][0].ToString();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }


        private void btnTim_Click(object sender, EventArgs e)
        {
            if (cmbMasothue.Text == "")
            {
                txtTongtienthu.Text = "";
                return;
            }
            string sql = "select Sum(a.TongTien) from tblThuTienNha as a join tblThueNha as b on a.Masothue=b.Masothue where b.Masothue='"
                         + cmbMasothue.SelectedValue.ToString() + "'";
            DataTable table = DAO.DocBang(sql);
            if (table.Rows.Count > 0)
            {
                txtTongtienthu.Text = table.Rows[0][0].ToString();
            }
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            cmbMasothue.SelectedIndex = -1;
            txtTongtienthu.Text = "";
            txtManha.Text = "";
            txtTenkhach.Text = "";
            txtDiachi.Text = "";
        }
    }
}

