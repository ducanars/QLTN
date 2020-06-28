using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace QLTN
{
    public partial class frmHopdong : Form
    {
        public frmHopdong()
        {
            InitializeComponent();
        }

        private void frmHopdong_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            cmbManha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMakhach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbManha.SelectedIndex = -1;
            cmbMakhach.SelectedIndex = -1;
            cmbManha.SelectedIndexChanged += cmbManha_SelectedIndexChanged;
            cmbMakhach.SelectedIndexChanged += cmbMakhach_SelectedIndexChanged;
            txtMahopdong.Text = DAO.CreateKey("HDTN");
            DAO.CloseConnection();
            fillDataToComboMakhach();
            fillDataToComboManha();
        }
        public void fillDataToComboManha()
        {
            string sql = "Select * from tblDanhMucNha";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbManha.DataSource = table;
            cmbManha.ValueMember = "Manha";
            cmbManha.DisplayMember = "Manha";
        }
        public void fillDataToComboMakhach()
        {
            string sql = "Select * from tblKhachThue";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbMakhach.DataSource = table;
            cmbMakhach.ValueMember = "Makhach";
            cmbMakhach.DisplayMember = "Makhach";
        }

        private void cmbManha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbManha.SelectedIndex != -1)
            {
                string str;
                str = "select distinct Makhach from tblThueNha where Manha = '" + cmbManha.SelectedValue + "' ";
                // MessageBox.Show(str);
                DAO.FillDataToCombo(str, cmbMakhach, "MaKhach", "MaKhach");
                txtDienthoai.Text = DAO.GetFieldValues("select Dienthoai from tblDanhMucNha where Manha = '" + cmbManha.SelectedValue + "'");
                txtTenchunha.Text = DAO.GetFieldValues("select Tenchunha from tblDanhMucNha where Manha = '" + cmbManha.SelectedValue + "'");
                txtDiachinha.Text = DAO.GetFieldValues("select Diachi from tblDanhMucNha where Manha = '" + cmbManha.SelectedValue + "'");
                txtLoainha.Text = DAO.GetFieldValues("select b.Tenloai from tblDanhMucNha as a join tblLoainha as b on a.Maloai=b.Maloai where a.Manha = '" + cmbManha.SelectedValue + "'");
                txtDongiathue.Text = DAO.GetFieldValues("select Dongiathue from tblDanhMucNha where Manha = '" + cmbManha.SelectedValue + "'");
                txtDoituongsudung.Text = DAO.GetFieldValues("select b.TenDTSD from tblDanhMucNha as a join tblDoiTuongSuDung as b on a.MaDTSD=b.MaDTSD where a.Manha = '" + cmbManha.SelectedValue + "'");
                txtTinhtrang.Text = DAO.GetFieldValues("select Tinhtrang from tblDanhMucNha where Manha = '" + cmbManha.SelectedValue + "'");
                txtGhichu.Text = DAO.GetFieldValues("select Ghichu from tblDanhMucNha where Manha = '" + cmbManha.SelectedValue + "'");
            }

        }

        private void cmbMakhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMakhach.SelectedIndex != -1)
            {
                txtSoCMND.Text = DAO.GetFieldValues("select b.SoCMND from tblThueNha as a join tblKhachThue as b on a.Makhach=b.Makhach where a.Makhach = '" + cmbMakhach.SelectedValue.ToString() + "'");
                txtTenkhach.Text = DAO.GetFieldValues("select b.Tenkhach from tblThueNha as a join tblKhachThue as b on a.Makhach=b.Makhach where a.Makhach = '" + cmbMakhach.SelectedValue.ToString() + "'");
                txtDiachithuongtru.Text = DAO.GetFieldValues("select b.Diachithuongtru from tblThueNha as a join tblKhachThue as b on a.Makhach=b.Makhach where a.Makhach = '" + cmbMakhach.SelectedValue.ToString() + "'");
                txtMucdichsudung.Text = DAO.GetFieldValues("select b.TenmucdichSD from tblThueNha as a join tblMucDichSuDung as b on a.MamucdichSD=b.MamucdichSD where Makhach = '" + cmbMakhach.SelectedValue.ToString() + "'");
                txtNgayBD.Text = DAO.GetFieldValues("select NgayBD from tblThueNha  where Makhach = '" + cmbMakhach.SelectedValue.ToString() + "'");
                txtNgayKT.Text = DAO.GetFieldValues("select NgayKT from tblThueNha  where Makhach = '" + cmbMakhach.SelectedValue.ToString() + "'");
                txtHinhthucthanhtoan.Text = DAO.GetFieldValues("select a.TenhinhthucTT from tblThueNha as b join tblHinhThucThanhToan as a on a.MahinhthucTT=b.MahinhthucTT where b.Makhach = '" + cmbMakhach.SelectedValue.ToString() + "'");
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["I1:T1"].Font.Size = 20;
            exRange.Range["I1:T1"].Font.Name = "Times new roman";
            exRange.Range["I1:T1"].Font.Bold = true;
            exRange.Range["I1:T1"].MergeCells = true;
            exRange.Range["I1:T1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["I1:T1"].Value = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
            exRange.Range["K2:Q2"].Font.Size = 16;
            exRange.Range["K2:Q2"].Font.Name = "Times new roman";
            exRange.Range["K2:Q2"].MergeCells = true;
            exRange.Range["K2:Q2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["K2:Q2"].Value = "Độc lập - Tự do - Hạnh phúc";
            exRange.Range["R4:X4"].Font.Size = 13;
            exRange.Range["R4:X4"].Font.Name = "Times new roman";
            exRange.Range["R4:X4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["R4:R4"].Value = "..........";
            exRange.Range["S4:S4"].Value = "ngày";
            exRange.Range["T4:T4"].Value = "......";
            exRange.Range["U4:U4"].Value = "tháng";
            exRange.Range["V4:V4"].Value = "......";
            exRange.Range["W4:W4"].Value = "năm";
            exRange.Range["X4:X4"].Value = "......";
            exRange.Range["K7:R8"].Font.Size = 26;
            exRange.Range["K7:R8"].Font.Name = "Times new roman";
            exRange.Range["K7:R8"].Font.Bold = true;
            exRange.Range["K7:R8"].MergeCells = true;
            exRange.Range["K7:R8"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["K7:R8"].Value = "HỢP ĐỒNG THUÊ NHÀ";
            exRange.Range["F11:H11"].Font.Size = 13;
            exRange.Range["F11:H11"].Font.Name = "Times new roman";
            exRange.Range["F11:H11"].MergeCells = true;
            exRange.Range["F11:H11"].Value = "Hợp đồng thuê nhà số: ";
            exRange.Range["F13:I13"].Font.Size = 16;
            exRange.Range["F13:I13"].Font.Name = "Times new roman";
            exRange.Range["F13:I13"].MergeCells = true;
            exRange.Range["F13:I13"].Font.Bold = true;
            exRange.Range["F13:I13"].Value = "BÊN CHO THUÊ (BÊN A) ";
            exRange.Range["F15:G15"].Font.Size = 13;
            exRange.Range["F15:G15"].Font.Name = "Times new roman";
            exRange.Range["F15:G15"].MergeCells = true;
            exRange.Range["F15:G15"].Value = "Họ và tên: ";
            exRange.Range["F16:G16"].Font.Size = 13;
            exRange.Range["F16:G16"].Font.Name = "Times new roman";
            exRange.Range["F16:G16"].MergeCells = true;
            exRange.Range["F16:G16"].Value = "Số điện thoại: ";
            exRange.Range["F19:I19"].Font.Size = 16;
            exRange.Range["F19:I19"].Font.Name = "Times new roman";
            exRange.Range["F19:I19"].MergeCells = true;
            exRange.Range["F19:I19"].Font.Bold = true;
            exRange.Range["F19:I19"].Value = "BÊN THUÊ NHÀ (BÊN B) ";
            exRange.Range["F21:H21"].Font.Size = 13;
            exRange.Range["F21:H21"].Font.Name = "Times new roman";
            exRange.Range["F21:H21"].MergeCells = true;
            exRange.Range["F21:H21"].Value = "Họ và tên: ";
            exRange.Range["F22:H22"].Font.Size = 13;
            exRange.Range["F22:H22"].Font.Name = "Times new roman";
            exRange.Range["F22:H22"].MergeCells = true;
            exRange.Range["F22:H22"].Value = "Địa chỉ thường trú: ";
            exRange.Range["F23:H23"].Font.Size = 13;
            exRange.Range["F23:H23"].Font.Name = "Times new roman";
            exRange.Range["F23:H23"].MergeCells = true;
            exRange.Range["F23:H23"].Value = "Số CMND: ";
            exRange.Range["F26:I26"].Font.Size = 16;
            exRange.Range["F26:I26"].Font.Name = "Times new roman";
            exRange.Range["F26:I26"].MergeCells = true;
            exRange.Range["F26:I26"].Font.Bold = true;
            exRange.Range["F26:I26"].Value = "THÔNG TIN THUÊ NHÀ ";
            exRange.Range["F28:H28"].Font.Size = 13;
            exRange.Range["F28:H28"].Font.Name = "Times new roman";
            exRange.Range["F28:H28"].MergeCells = true;
            exRange.Range["F28:H28"].Value = "Địa chỉ nhà: ";
            exRange.Range["F29:H29"].Font.Size = 13;
            exRange.Range["F29:H29"].Font.Name = "Times new roman";
            exRange.Range["F29:H29"].MergeCells = true;
            exRange.Range["F29:H29"].Value = "Loại nhà: ";
            exRange.Range["F30:H30"].Font.Size = 13;
            exRange.Range["F30:H30"].Font.Name = "Times new roman";
            exRange.Range["F30:H30"].MergeCells = true;
            exRange.Range["F30:H30"].Value = "Đơn giá thuê: ";
            exRange.Range["F31:H31"].Font.Size = 13;
            exRange.Range["F31:H31"].Font.Name = "Times new roman";
            exRange.Range["F31:H31"].MergeCells = true;
            exRange.Range["F31:H31"].Value = "Đối tượng sử dụng: ";
            exRange.Range["F32:H32"].Font.Size = 13;
            exRange.Range["F32:H32"].Font.Name = "Times new roman";
            exRange.Range["F32:H32"].MergeCells = true;
            exRange.Range["F32:H32"].Value = "Mục đích sử dụng: ";
            exRange.Range["F33:H33"].Font.Size = 13;
            exRange.Range["F33:H33"].Font.Name = "Times new roman";
            exRange.Range["F33:H33"].MergeCells = true;
            exRange.Range["F33:H33"].Value = "Ngày bắt đầu: ";
            exRange.Range["F34:H34"].Font.Size = 13;
            exRange.Range["F34:H34"].Font.Name = "Times new roman";
            exRange.Range["F34:H34"].MergeCells = true;
            exRange.Range["F34:H34"].Value = "Ngày kết thúc: ";
            exRange.Range["F35:H35"].Font.Size = 13;
            exRange.Range["F35:H35"].Font.Name = "Times new roman";
            exRange.Range["F35:H35"].MergeCells = true;
            exRange.Range["F35:H35"].Value = "Hình thức thanh toán: ";
            exRange.Range["F36:H36"].Font.Size = 13;
            exRange.Range["F36:H36"].Font.Name = "Times new roman";
            exRange.Range["F36:H36"].MergeCells = true;
            exRange.Range["F36:H36"].Value = "Tình trạng: ";
            exRange.Range["F37:H37"].Font.Size = 13;
            exRange.Range["F37:H37"].Font.Name = "Times new roman";
            exRange.Range["F37:H37"].MergeCells = true;
            exRange.Range["F37:H37"].Value = "Ghi chú: ";
            exRange.Range["F40:X40"].Font.Size = 13;
            exRange.Range["F40:X40"].Font.Name = "Times new roman";
            exRange.Range["F40:X40"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["F40:X40"].MergeCells = true;
            exRange.Range["F40:X40"].Font.Italic = true;
            exRange.Range["F40:X40"].Value = "Nay hai bên thỏa thuận và cùng nhau thống nhất những điều khoản sau đây trong văn bản hợp đồng thuê nhà. ";
            exRange.Range["F42:F42"].Font.Size = 14;
            exRange.Range["F42:F42"].Font.Name = "Times new roman";
            exRange.Range["F42:F42"].MergeCells = true;
            exRange.Range["F42:F42"].Font.Bold = true;
            exRange.Range["F42:F42"].Value = "ĐIỀU 1: ";
            exRange.Range["H42:X42"].Font.Size = 13;
            exRange.Range["H42:X42"].Font.Name = "Times new roman";
            exRange.Range["H42:X42"].MergeCells = true;
            exRange.Range["H42:X42"].Value = "Bên B có trách nhiệm thanh toán tiền nhà đủ theo đúng hợp đồng cho bên A vào mỗi kì thuê nhà. ";
            exRange.Range["F44:F44"].Font.Size = 14;
            exRange.Range["F44:F44"].Font.Name = "Times new roman";
            exRange.Range["F44:F44"].MergeCells = true;
            exRange.Range["F44:F44"].Font.Bold = true;
            exRange.Range["F44:F44"].Value = "ĐIỀU 2: ";
            exRange.Range["H44:X44"].Font.Size = 13;
            exRange.Range["H44:X44"].Font.Name = "Times new roman";
            exRange.Range["H44:X44"].MergeCells = true;
            exRange.Range["H44:X44"].Value = "Khi bàn giao nhà và tài sản, nếu tài sản bị hư hại thì bên B phải có trách nhiệm bồi thường thiệt hại cho bên A. ";
            exRange.Range["F46:F46"].Font.Size = 14;
            exRange.Range["F46:F46"].Font.Name = "Times new roman";
            exRange.Range["F46:F46"].MergeCells = true;
            exRange.Range["F46:F46"].Font.Bold = true;
            exRange.Range["F46:F46"].Value = "ĐIỀU 3: ";
            exRange.Range["H46:X46"].Font.Size = 13;
            exRange.Range["H46:X46"].Font.Name = "Times new roman";
            exRange.Range["H46:X46"].MergeCells = true;
            exRange.Range["H46:X46"].Value = "Nếu bên B đơn phương chấm dứt hợp đồng trước thời hạn thì bên A sẽ được hưởng toàn bộ số tiền cọc mà bên B đã đóng. ";
            exRange.Range["F48:F48"].Font.Size = 14;
            exRange.Range["F48:F48"].Font.Name = "Times new roman";
            exRange.Range["F48:F48"].MergeCells = true;
            exRange.Range["F48:F48"].Font.Bold = true;
            exRange.Range["F48:F48"].Value = "ĐIỀU 4: ";
            exRange.Range["H48:X48"].Font.Size = 13;
            exRange.Range["H48:X48"].Font.Name = "Times new roman";
            exRange.Range["H48:X48"].MergeCells = true;
            exRange.Range["H48:X48"].Value = "Nếu bên A đơn phương chấm dứt hợp đồng trước thời hạn thì bên B sẽ được bồi thường với số tiền bằng 2 lần số tiền cọc mà bên B đã đóng.  ";
            exRange.Range["F50:F50"].Font.Size = 14;
            exRange.Range["F50:F50"].Font.Name = "Times new roman";
            exRange.Range["F50:F50"].MergeCells = true;
            exRange.Range["F50:F50"].Font.Bold = true;
            exRange.Range["F50:F50"].Value = "ĐIỀU 5: ";
            exRange.Range["H50:X50"].Font.Size = 13;
            exRange.Range["H50:X50"].Font.Name = "Times new roman";
            exRange.Range["H50:X50"].MergeCells = true;
            exRange.Range["H50:X50"].Value = "Hai bên cam kết không tranh chấp hay khiếu nại gì về sau.  ";
            exRange.Range["I54:K54"].Font.Size = 14;
            exRange.Range["I54:K54"].Font.Name = "Times new roman";
            exRange.Range["I54:K54"].MergeCells = true;
            exRange.Range["I54:K54"].Font.Bold = true;
            exRange.Range["I54:K54"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["I54:K54"].Value = "BÊN CHO THUÊ: ";
            exRange.Range["S54:U54"].Font.Size = 14;
            exRange.Range["S54:U54"].Font.Name = "Times new roman";
            exRange.Range["S54:U54"].MergeCells = true;
            exRange.Range["S54:U54"].Font.Bold = true;
            exRange.Range["S54:U54"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["S54:U54"].Value = "BÊN THUÊ NHÀ: ";
            exRange.Range["I55:K55"].Font.Size = 13;
            exRange.Range["I55:K55"].Font.Name = "Times new roman";
            exRange.Range["I55:K55"].MergeCells = true;
            exRange.Range["I55:K55"].Font.Italic= true;
            exRange.Range["I55:K55"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["I55:K55"].Value = "(Ký và ghi rõ họ tên) ";
            exRange.Range["S55:U55"].Font.Size = 13;
            exRange.Range["S55:U55"].Font.Name = "Times new roman";
            exRange.Range["S55:U55"].MergeCells = true;
            exRange.Range["S55:U55"].Font.Italic = true;
            exRange.Range["S55:U55"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["S55:U55"].Value = "(Ký và ghi rõ họ tên) ";
            exRange.Range["J15:J15"].Value = txtTenchunha.Text;
           
            exRange.Range["J16:J16"].Value ="'"+ txtDienthoai.Text.ToString();
            
            exRange.Range["J21:J21"].Value = txtTenkhach.Text.ToString();
            
            exRange.Range["J22:J22"].Value = txtDiachithuongtru.Text.ToString();
            
            exRange.Range["J23:J23"].Value = "'" + txtSoCMND.Text.ToString();
           
            exRange.Range["J28:J28"].Value = txtDiachinha.Text.ToString();
            
            exRange.Range["J29:J29"].Value = txtLoainha.Text.ToString();
           
            exRange.Range["J30:J30"].Value = "'" + txtDongiathue.Text.ToString();
            
            exRange.Range["J31:J31"].Value = txtDoituongsudung.Text.ToString();
           
            exRange.Range["J32:J32"].Value = txtMucdichsudung.Text.ToString();
            
            exRange.Range["J33:J33"].Value = "'" + txtNgayBD.Text.ToString();
            
            exRange.Range["J34:J34"].Value = "'" + txtNgayKT.Text.ToString();
           
            exRange.Range["J35:J35"].Value = "'" + txtHinhthucthanhtoan.Text.ToString();
            
            exRange.Range["J36:J36"].Value = txtTinhtrang.Text.ToString();
            
            exRange.Range["J37:J37"].Value = txtGhichu.Text.ToString();
            
            exRange.Range["J11:J11"].Value = txtMahopdong.Text.ToString();
            







            // Biểu diễn thông tin TKB
            //Tạo dòng tiêu đề bảng

            exApp.Visible = true;


        }

        private void btnTaomoi_Click(object sender, EventArgs e)
        {
            txtMahopdong.Text = DAO.CreateKey("HDTN");
            cmbManha.SelectedIndex = -1;
            cmbMakhach.SelectedIndex = -1;
            txtTenchunha.Text = "";
            txtDienthoai.Text = "";
            txtTenkhach.Text = "";
            txtDiachithuongtru.Text = "";
            txtSoCMND.Text = "";
            txtDiachinha.Text = "";
            txtDongiathue.Text = "";
            txtLoainha.Text = "";
            txtDoituongsudung.Text = "";
            txtMucdichsudung.Text = "";
            txtNgayBD.Text = "";
            txtNgayKT.Text = "";
            txtTinhtrang.Text = "";
            txtGhichu.Text = "";
            txtHinhthucthanhtoan.Text = "";
        }
    }
}
