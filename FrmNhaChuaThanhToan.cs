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
    public partial class FrmNhaChuaThanhToan : Form
    {
        public FrmNhaChuaThanhToan()
        {
            InitializeComponent();
        }

        private void FrmNhaChuaThanhToan_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            

            DAO.CloseConnection();

        }
        private void loadDataGridView()
        {
            string sql = "select a.Manha,c.Tenchunha,b.Tenkhach,a.Masothue from tblThueNha as a join tblKhachThue as b on a.Makhach=b.Makhach join tblDanhMucNha as c on a.Manha=c.Manha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewBaocaochuathanhtoan.DataSource = table;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string str = DateTime.Now.ToString().Trim();
            str = str.Substring(3, 2);      
            string sql;
            sql = "select distinct a.Manha,c.Tenchunha,b.Tenkhach,a.Masothue from tblThueNha as a join tblKhachThue as b on a.Makhach=b.Makhach join tblDanhMucNha as c on a.Manha=c.Manha" +
                "join tblThuTienNha as d on a.Masothue=d.Masothue where d.Nam = 2020  and d.Thang not like '%" + str.ToString() + "%' ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewKetqua.DataSource = table;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}