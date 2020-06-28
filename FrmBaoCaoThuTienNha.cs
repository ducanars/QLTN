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

        }
        public void fillDataToComboNha()
        {
            string sql = "Select * from tblThueNha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbManha.DataSource = table;
            cmbManha.ValueMember = "Manha";
            cmbManha.DisplayMember = "Manha";
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            int tt;
            string sql = "select Sum(a.TongTien)  from tblThuTienNha as a join tblThueNha as b on a.Masothue=b.Masothue where Manha='"+cmbManha.SelectedValue.ToString()+"'";
            DAO.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = DAO.con;
            tt = Convert.ToInt32(sql);
            txtTongtienthu.Text = tt.ToString();
        }

        /*private void cmbManha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbManha.SelectedIndex != -1)
            {
                string str;
                int tt;
                str = "select Sum(a.TongTien)  from tblThuTienNha as a join tblThueNha as b on a.Masothue=b.Masothue where Manha='" + cmbManha.SelectedValue.ToString() + "'";
                DAO.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = str;
                cmd.Connection = DAO.con;


                tt = Convert.ToInt32(DAO.GetFieldValues(str));



                txtTongtienthu.Text = tt.ToString();
            }
        }*/
    }
}

