namespace QLTN
{
    partial class FrmTimKiemNha
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTimKiemNha));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLoainha = new System.Windows.Forms.ComboBox();
            this.cmbDiachi = new System.Windows.Forms.ComboBox();
            this.cmbDoituongsudung = new System.Windows.Forms.ComboBox();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.gridviewTimkiemnha = new System.Windows.Forms.DataGridView();
            this.Manha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tenchunha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diachi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dienthoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Maloai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dongiathue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDTSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tinhtrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dathue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnthoat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTimlai = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewTimkiemnha)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại nhà";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(548, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Đối tượng sử dụng";
            // 
            // cmbLoainha
            // 
            this.cmbLoainha.FormattingEnabled = true;
            this.cmbLoainha.Location = new System.Drawing.Point(70, 71);
            this.cmbLoainha.Name = "cmbLoainha";
            this.cmbLoainha.Size = new System.Drawing.Size(177, 28);
            this.cmbLoainha.TabIndex = 1;
            // 
            // cmbDiachi
            // 
            this.cmbDiachi.FormattingEnabled = true;
            this.cmbDiachi.Location = new System.Drawing.Point(342, 71);
            this.cmbDiachi.Name = "cmbDiachi";
            this.cmbDiachi.Size = new System.Drawing.Size(188, 28);
            this.cmbDiachi.TabIndex = 1;
            // 
            // cmbDoituongsudung
            // 
            this.cmbDoituongsudung.FormattingEnabled = true;
            this.cmbDoituongsudung.Location = new System.Drawing.Point(691, 71);
            this.cmbDoituongsudung.Name = "cmbDoituongsudung";
            this.cmbDoituongsudung.Size = new System.Drawing.Size(203, 28);
            this.cmbDoituongsudung.TabIndex = 1;
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTimkiem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTimkiem.BackgroundImage")));
            this.btnTimkiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTimkiem.Location = new System.Drawing.Point(101, 41);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(127, 42);
            this.btnTimkiem.TabIndex = 2;
            this.btnTimkiem.Text = "     Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = false;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // gridviewTimkiemnha
            // 
            this.gridviewTimkiemnha.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridviewTimkiemnha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewTimkiemnha.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Manha,
            this.Tenchunha,
            this.Diachi,
            this.Dienthoai,
            this.Maloai,
            this.Dongiathue,
            this.MaDTSD,
            this.Tinhtrang,
            this.Dathue});
            this.gridviewTimkiemnha.Location = new System.Drawing.Point(33, 255);
            this.gridviewTimkiemnha.Name = "gridviewTimkiemnha";
            this.gridviewTimkiemnha.Size = new System.Drawing.Size(914, 234);
            this.gridviewTimkiemnha.TabIndex = 3;
            // 
            // Manha
            // 
            this.Manha.DataPropertyName = "Manha";
            this.Manha.FillWeight = 30F;
            this.Manha.HeaderText = "Mã nhà";
            this.Manha.Name = "Manha";
            this.Manha.Width = 70;
            // 
            // Tenchunha
            // 
            this.Tenchunha.DataPropertyName = "Tenchunha";
            this.Tenchunha.FillWeight = 30F;
            this.Tenchunha.HeaderText = "Tên chủ nhà";
            this.Tenchunha.Name = "Tenchunha";
            this.Tenchunha.Width = 150;
            // 
            // Diachi
            // 
            this.Diachi.DataPropertyName = "Diachi";
            this.Diachi.FillWeight = 30F;
            this.Diachi.HeaderText = "Địa chỉ";
            this.Diachi.Name = "Diachi";
            this.Diachi.Width = 200;
            // 
            // Dienthoai
            // 
            this.Dienthoai.DataPropertyName = "Dienthoai";
            this.Dienthoai.FillWeight = 30F;
            this.Dienthoai.HeaderText = "Số điện thoại";
            this.Dienthoai.Name = "Dienthoai";
            this.Dienthoai.Width = 70;
            // 
            // Maloai
            // 
            this.Maloai.DataPropertyName = "Maloai";
            this.Maloai.FillWeight = 30F;
            this.Maloai.HeaderText = "Mã loại";
            this.Maloai.Name = "Maloai";
            this.Maloai.Width = 70;
            // 
            // Dongiathue
            // 
            this.Dongiathue.DataPropertyName = "Dongiathue";
            this.Dongiathue.FillWeight = 30F;
            this.Dongiathue.HeaderText = "Đơn giá thuê";
            this.Dongiathue.Name = "Dongiathue";
            this.Dongiathue.Width = 70;
            // 
            // MaDTSD
            // 
            this.MaDTSD.DataPropertyName = "MaDTSD";
            this.MaDTSD.FillWeight = 30F;
            this.MaDTSD.HeaderText = "Đối tượng sử dụng";
            this.MaDTSD.Name = "MaDTSD";
            this.MaDTSD.Width = 70;
            // 
            // Tinhtrang
            // 
            this.Tinhtrang.DataPropertyName = "Tinhtrang";
            this.Tinhtrang.FillWeight = 30F;
            this.Tinhtrang.HeaderText = "Tình trạng";
            this.Tinhtrang.Name = "Tinhtrang";
            this.Tinhtrang.Width = 150;
            // 
            // Dathue
            // 
            this.Dathue.DataPropertyName = "Dathue";
            this.Dathue.FillWeight = 30F;
            this.Dathue.HeaderText = "Đã thuê";
            this.Dathue.Name = "Dathue";
            // 
            // btnthoat
            // 
            this.btnthoat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnthoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnthoat.BackgroundImage")));
            this.btnthoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnthoat.Location = new System.Drawing.Point(691, 41);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(127, 42);
            this.btnthoat.TabIndex = 2;
            this.btnthoat.Text = "       Thoát";
            this.btnthoat.UseVisualStyleBackColor = false;
            this.btnthoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimlai);
            this.groupBox1.Controls.Add(this.btnTimkiem);
            this.groupBox1.Controls.Add(this.btnthoat);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(33, 529);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(914, 120);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thao tác";
            // 
            // btnTimlai
            // 
            this.btnTimlai.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTimlai.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTimlai.BackgroundImage")));
            this.btnTimlai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTimlai.Location = new System.Drawing.Point(403, 41);
            this.btnTimlai.Name = "btnTimlai";
            this.btnTimlai.Size = new System.Drawing.Size(127, 42);
            this.btnTimlai.TabIndex = 2;
            this.btnTimlai.Text = "      Tìm lại";
            this.btnTimlai.UseVisualStyleBackColor = false;
            this.btnTimlai.Click += new System.EventHandler(this.btnTimlai_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbLoainha);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbDiachi);
            this.groupBox2.Controls.Add(this.cmbDoituongsudung);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(33, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(914, 138);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thực hiện nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(367, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 46);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tìm kiếm nhà";
            // 
            // FrmTimKiemNha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridviewTimkiemnha);
            this.Controls.Add(this.label4);
            this.Name = "FrmTimKiemNha";
            this.Text = "FrmTimKiemNha";
            this.Load += new System.EventHandler(this.FrmTimKiemNha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewTimkiemnha)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLoainha;
        private System.Windows.Forms.ComboBox cmbDiachi;
        private System.Windows.Forms.ComboBox cmbDoituongsudung;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.DataGridView gridviewTimkiemnha;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTimlai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tenchunha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diachi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dienthoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Maloai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dongiathue;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDTSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tinhtrang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dathue;
    }
}