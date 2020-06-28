using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTN
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void khachThueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachthue DM_KT = new frmKhachthue();
            DM_KT.ShowDialog();
        }

        private void DanhMucNhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhmucnha DM_Nha = new frmDanhmucnha();
            DM_Nha.ShowDialog();
        }

        private void Nha_TaiSanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNha_Taisan Nha_TS = new frmNha_Taisan();
            Nha_TS.ShowDialog();
        }

        private void CoQuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCoquan DM_CQ = new frmCoquan();
            DM_CQ.ShowDialog();
        }

        private void NgheNghiepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNghenghiep DM_NN = new frmNghenghiep();
            DM_NN.ShowDialog();
        }

        private void DoiTuongSuDungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoituongsudung DTSD = new frmDoituongsudung();
            DTSD.ShowDialog();
        }

        private void ThuTienNhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThutiennha TTN = new frmThutiennha();
            TTN.ShowDialog();
        }

        private void HinhThucThanhToanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHinhthucthanhtoan HTTT = new frmHinhthucthanhtoan();
            HTTT.ShowDialog();
        }

        private void TaiSanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaisan DM_TS = new frmTaisan();
            DM_TS.ShowDialog();
        }

        private void ThueNhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThuenha TN = new frmThuenha();
            TN.ShowDialog();
        }

        private void MucDichSuDungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMucdichsudung MDSD = new frmMucdichsudung();
            MDSD.ShowDialog();
        }

        private void TraNhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTranha TraN = new frmTranha();
            TraN.ShowDialog();
        }

        private void LoaiNhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoaiNha DM_LN = new frmLoaiNha();
            DM_LN.ShowDialog();
        }

        private void TraNhaMatTaiSanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTranha_Mattaisan TN_MTS = new frmTranha_Mattaisan();
            TN_MTS.ShowDialog();
        }

        private void TimkiemnhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTimKiemNha TKN = new FrmTimKiemNha();
            TKN.ShowDialog();
        }

        private void TimkiemkhachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTimKiemKhach TKK = new FrmTimKiemKhach();
            TKK.ShowDialog();
        }

        private void hợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHopdong HD = new frmHopdong();
            HD.ShowDialog();

        }
    }
}
