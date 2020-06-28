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
    public partial class frmThutiennha : Form
    {
        public frmThutiennha()
        {
            InitializeComponent();
        }

        private void frmThutiennha_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            loadDataGridView();
            fillDataToCombo();
            DAO.CloseConnection();
            cmbMasothue.Text = "";
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblThuTienNha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridviewThutiennha.DataSource = table;
        }

        public void fillDataToCombo()
        {
            string sql = "Select * from tblThueNha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbMasothue.DataSource = table;
            cmbMasothue.ValueMember = "Masothue";
            cmbMasothue.DisplayMember = "Masothue ";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMasothu.Text = "";
            cmbMasothue.SelectedIndex = -1;
            chk1.Checked = false;
            chk2.Checked = false;
            chk3.Checked = false;
            chk4.Checked = false;
            chk5.Checked = false;
            chk6.Checked = false;
            chk7.Checked = false;
            chk8.Checked = false;
            chk9.Checked = false;
            chk10.Checked = false;
            chk11.Checked = false;
            chk12.Checked = false;
            txtNam.Text = "";
            txtTongtien.Text = "";
            txtNguoithu.Text = "";
            dtpNgaythu.Text = "";
            txtGhichu.Text = "";
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;
            btnThem.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMasothu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã số thu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasothu.Focus();
                return;
            }
            if (cmbMasothue.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn mã thuê nhà!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNam.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập năm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNam.Focus();
                return;
            }

            string strThang = "";
            if (chk1.Checked == true)
                strThang += chk1.Text + "_";
            if (chk2.Checked == true)
                strThang += chk2.Text + "_";
            if (chk3.Checked == true)
                strThang += chk3.Text + "_";
            if (chk4.Checked == true)
                strThang += chk4.Text + "_";
            if (chk5.Checked == true)
                strThang += chk5.Text + "_";
            if (chk6.Checked == true)
                strThang += chk6.Text + "_";
            if (chk7.Checked == true)
                strThang += chk7.Text + "_";
            if (chk8.Checked == true)
                strThang += chk8.Text + "_";
            if (chk9.Checked == true)
                strThang += chk9.Text + "_";
            if (chk10.Checked == true)
                strThang += chk10.Text + "_";
            if (chk11.Checked == true)
                strThang += chk11.Text + "_";
            if (chk12.Checked == true)
                strThang += chk12.Text + "_";
            if (strThang == "")
            {
                MessageBox.Show("Bạn chưa chọn tháng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTongtien.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tổng tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTongtien.Focus();
                return;
            }
            if (txtNguoithu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập người thu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNguoithu.Focus();
                return;
            }
            if (dtpNgaythu.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ngày thu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaythu.Focus();
                return;
            }
            if (txtGhichu.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ghi chú", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGhichu.Focus();
                return;
            }
            string sql = "select * from tblThuTienNha where Masothu = '" + txtMasothu.Text.Trim() + "'";
            DAO.OpenConnection();
            if (DAO.CheckKeyExit(sql))
            {
                MessageBox.Show("Mã số thu đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.CloseConnection();
                txtMasothu.Focus();
                return;
            }
            else
            {
                sql = "insert into tblThuTienNha (Masothu,Masothue,Thang,Nam,Tongtien,Nguoithu,Ngaythu,Ghichu) " +
                    " values ('" + txtMasothu.Text.Trim() + "','" + cmbMasothue.SelectedValue.ToString() + "',N'"
                    + strThang.ToString() + "'," + txtNam.Text.Trim() + "," + txtTongtien.Text.Trim() + ",N'" + txtNguoithu.Text.Trim() 
                    + "',N'" + DAO.ConvertDateTime(dtpNgaythu.Text.ToString()) + "',N'" + txtGhichu.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                loadDataGridView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMasothu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã số thu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasothu.Focus();
                return;
            }
            if (cmbMasothue.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn mã thuê nhà!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string strThang = "";
            if (chk1.Checked == true)
                strThang += chk1.Text + "_";
            if (chk2.Checked == true)
                strThang += chk2.Text + "_";
            if (chk3.Checked == true)
                strThang += chk3.Text + "_";
            if (chk4.Checked == true)
                strThang += chk4.Text + "_";
            if (chk5.Checked == true)
                strThang += chk5.Text + "_";
            if (chk6.Checked == true)
                strThang += chk6.Text + "_";
            if (chk7.Checked == true)
                strThang += chk7.Text + "_";
            if (chk8.Checked == true)
                strThang += chk8.Text + "_";
            if (chk9.Checked == true)
                strThang += chk9.Text + "_";
            if (chk10.Checked == true)
                strThang += chk10.Text + "_";
            if (chk11.Checked == true)
                strThang += chk11.Text + "_";
            if (chk12.Checked == true)
                strThang += chk12.Text + "_";
            if (strThang == "")
            {
                MessageBox.Show("Bạn chưa chọn tháng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNam.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập năm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNam.Focus();
                return;
            }
            if (txtTongtien.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tổng tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTongtien.Focus();
                return;
            }
            if (txtNguoithu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập người thu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNguoithu.Focus();
                return;
            }
            if (dtpNgaythu.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ngày thu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaythu.Focus();
                return;
            }
            if (txtGhichu.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ghi chú", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGhichu.Focus();
                return;
            }

            string sql = "UPDATE tblThuTienNha SET  Masothue='" + cmbMasothue.SelectedValue.ToString() +
                    "',Thang =N'" + strThang + "',Nam=" + txtNam.Text.Trim() + ",Tongtien=" + 
                    txtTongtien.Text.Trim() + ",Nguoithu=N'" + txtNguoithu.Text.Trim() +
                    "',Ngaythu=N'" + DAO.ConvertDateTime(dtpNgaythu.Value.ToString("MM/dd/yyyy")) +
                    "',Ghichu=N'" + txtGhichu.Text.Trim() + "' WHERE Masothu=N'" + txtMasothu.Text.Trim() + "'";
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
                string sql = "delete from tblThuTienNha where Masothu = '" + txtMasothu.Text + "'";
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

        private void gridviewThutiennha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMasothu.Text = gridviewThutiennha.CurrentRow.Cells["Masothu"].Value.ToString();
            txtNam.Text = gridviewThutiennha.CurrentRow.Cells["Nam"].Value.ToString();
            txtTongtien.Text = gridviewThutiennha.CurrentRow.Cells["Tongtien"].Value.ToString();
            txtNguoithu.Text = gridviewThutiennha.CurrentRow.Cells["Nguoithu"].Value.ToString();
            txtGhichu.Text = gridviewThutiennha.CurrentRow.Cells["Ghichu"].Value.ToString();
            string ma = gridviewThutiennha.CurrentRow.Cells["Masothue"].Value.ToString();
            cmbMasothue.Text = DAO.GetFieldValues("select Masothue from tblThuTienNha where Masothue = '" + ma + "'");

            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "1_")
            {
                chk1.Checked = true;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;
                chk7.Checked = false;
                chk8.Checked = false;
                chk9.Checked = false;
                chk10.Checked = false;
                chk11.Checked = false;
                chk12.Checked = false;
            };
            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "2_")
            {
                chk2.Checked = true;
                chk1.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;
                chk7.Checked = false;
                chk8.Checked = false;
                chk9.Checked = false;
                chk10.Checked = false;
                chk11.Checked = false;
                chk12.Checked = false;
            };
            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "3_")
            {
                chk3.Checked = true;
                chk2.Checked = false;
                chk1.Checked = false;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;
                chk7.Checked = false;
                chk8.Checked = false;
                chk9.Checked = false;
                chk10.Checked = false;
                chk11.Checked = false;
                chk12.Checked = false;
            };
            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "4_")
            {
                chk4.Checked = true;
                chk2.Checked = false;
                chk3.Checked = false;
                chk1.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;
                chk7.Checked = false;
                chk8.Checked = false;
                chk9.Checked = false;
                chk10.Checked = false;
                chk11.Checked = false;
                chk12.Checked = false;
            };
            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "5_")
            {
                chk5.Checked = true;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk1.Checked = false;
                chk6.Checked = false;
                chk7.Checked = false;
                chk8.Checked = false;
                chk9.Checked = false;
                chk10.Checked = false;
                chk11.Checked = false;
                chk12.Checked = false;
            };
            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "6_")
            {
                chk6.Checked = true;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk5.Checked = false;
                chk1.Checked = false;
                chk7.Checked = false;
                chk8.Checked = false;
                chk9.Checked = false;
                chk10.Checked = false;
                chk11.Checked = false;
                chk12.Checked = false;
            };
            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "7_")
            {
                chk7.Checked = true;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;
                chk1.Checked = false;
                chk8.Checked = false;
                chk9.Checked = false;
                chk10.Checked = false;
                chk11.Checked = false;
                chk12.Checked = false;
            };
            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "8_")
            {
                chk8.Checked = true;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;
                chk7.Checked = false;
                chk1.Checked = false;
                chk9.Checked = false;
                chk10.Checked = false;
                chk11.Checked = false;
                chk12.Checked = false;
            };
            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "9_")
            {
                chk9.Checked = true;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;
                chk7.Checked = false;
                chk1.Checked = false;
                chk9.Checked = false;
                chk10.Checked = false;
                chk11.Checked = false;
                chk12.Checked = false;
            };
            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "10_")
            {
                chk10.Checked = true;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;
                chk7.Checked = false;
                chk1.Checked = false;
                chk9.Checked = false;
                chk8.Checked = false;
                chk11.Checked = false;
                chk12.Checked = false;
            };
            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "11_")
            {
                chk11.Checked = true;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;
                chk7.Checked = false;
                chk1.Checked = false;
                chk9.Checked = false;
                chk10.Checked = false;
                chk8.Checked = false;
                chk12.Checked = false;
            };
            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "12_")
            {
                chk12.Checked = true;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;
                chk7.Checked = false;
                chk1.Checked = false;
                chk9.Checked = false;
                chk10.Checked = false;
                chk11.Checked = false;
                chk8.Checked = false;
            };

            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "1_2_3_")
            {
                chk1.Checked = true;
                chk2.Checked = true;
                chk3.Checked = true;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;
                chk7.Checked = false;
                chk8.Checked = false;
                chk9.Checked = false;
                chk10.Checked = false;
                chk11.Checked = false;
                chk12.Checked = false;
            };
            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "4_5_6_")
            {
                chk4.Checked = true;
                chk5.Checked = true;
                chk6.Checked = true;
                chk1.Checked = false;
                chk2.Checked = false;
                chk3.Checked = false;
                chk7.Checked = false;
                chk8.Checked = false;
                chk9.Checked = false;
                chk10.Checked = false;
                chk11.Checked = false;
                chk12.Checked = false;
            };
            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "7_8_9_")
            {
                chk7.Checked = true;
                chk8.Checked = true;
                chk9.Checked = true;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;
                chk1.Checked = false;
                chk2.Checked = false;
                chk3.Checked = false;
                chk10.Checked = false;
                chk11.Checked = false;
                chk12.Checked = false;
            };
            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "10_11_12_")
            {
                chk10.Checked = true;
                chk11.Checked = true;
                chk12.Checked = true;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;
                chk7.Checked = false;
                chk8.Checked = false;
                chk9.Checked = false;
                chk1.Checked = false;
                chk2.Checked = false;
                chk3.Checked = false;
            };
            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "1_2_3_4_5_6_")
            {
                chk1.Checked = true;
                chk2.Checked = true;
                chk3.Checked = true;
                chk4.Checked = true;
                chk5.Checked = true;
                chk6.Checked = true;
                chk7.Checked = false;
                chk8.Checked = false;
                chk9.Checked = false;
                chk10.Checked = false;
                chk11.Checked = false;
                chk12.Checked = false;
            };
            if (gridviewThutiennha.CurrentRow.Cells["Thang"].Value.ToString() == "7_8_9_10_11_12_")
            {
                chk1.Checked = false;
                chk2.Checked = false;
                chk3.Checked = false;
                chk4.Checked = false;
                chk5.Checked = false;
                chk6.Checked = false;
                chk7.Checked = true;
                chk8.Checked = true;
                chk9.Checked = true;
                chk10.Checked = true;
                chk11.Checked = true;
                chk12.Checked = true;
            };

        }
        
        private void cmbMasothue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMasothue.SelectedIndex != -1)
            {

                string sql, sql1;
                sql = "select a.Dongiathue from tblDanhMucNha as a join tblThueNha as b  on a.Manha=b.Manha where b.Masothue='mst1'";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = DAO.con;
                txtDongiathue.Text = DAO.GetFieldValues(sql);
                txtDongiathue.Enabled = false;
                sql1 = "select c.TenhinhthucTT from tblThueNha as a join tblThuTienNha as b on a.Masothue=b.Masothue join tblHinhThucThanhToan as c on a.MahinhthucTT=c.MahinhthucTT where b.Masothue='mst1'";
                SqlCommand cmdd = new SqlCommand();
                cmdd.CommandText = sql1;
                cmdd.Connection = DAO.con;
                txtHinhThuc.Text = DAO.GetFieldValues(sql1);
                txtHinhThuc.Enabled = false;
            }
        }
    }
}
