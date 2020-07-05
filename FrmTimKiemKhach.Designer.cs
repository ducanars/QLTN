namespace QLTN
{
    partial class FrmTimKiemKhach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTimKiemKhach));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbkhach = new System.Windows.Forms.ComboBox();
            this.cmbdiachi = new System.Windows.Forms.ComboBox();
            this.cmbnghe = new System.Windows.Forms.ComboBox();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.gridviewTimkiemkhach = new System.Windows.Forms.DataGridView();
            this.Makhach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tenkhach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaysinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gioitinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoCMND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diachithuongtru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manghe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTimlai = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewTimkiemkhach)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên khách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(328, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(607, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nghề nghiệp";
            // 
            // cmbkhach
            // 
            this.cmbkhach.FormattingEnabled = true;
            this.cmbkhach.Location = new System.Drawing.Point(83, 83);
            this.cmbkhach.Name = "cmbkhach";
            this.cmbkhach.Size = new System.Drawing.Size(185, 28);
            this.cmbkhach.TabIndex = 1;
            // 
            // cmbdiachi
            // 
            this.cmbdiachi.FormattingEnabled = true;
            this.cmbdiachi.Location = new System.Drawing.Point(381, 83);
            this.cmbdiachi.Name = "cmbdiachi";
            this.cmbdiachi.Size = new System.Drawing.Size(201, 28);
            this.cmbdiachi.TabIndex = 1;
            // 
            // cmbnghe
            // 
            this.cmbnghe.FormattingEnabled = true;
            this.cmbnghe.Location = new System.Drawing.Point(699, 83);
            this.cmbnghe.Name = "cmbnghe";
            this.cmbnghe.Size = new System.Drawing.Size(201, 28);
            this.cmbnghe.TabIndex = 1;
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTimkiem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTimkiem.BackgroundImage")));
            this.btnTimkiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTimkiem.Location = new System.Drawing.Point(101, 37);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(127, 42);
            this.btnTimkiem.TabIndex = 2;
            this.btnTimkiem.Text = "     Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = false;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // gridviewTimkiemkhach
            // 
            this.gridviewTimkiemkhach.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridviewTimkiemkhach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewTimkiemkhach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Makhach,
            this.Tenkhach,
            this.Ngaysinh,
            this.Gioitinh,
            this.SoCMND,
            this.Diachithuongtru,
            this.Manghe,
            this.MaCQ});
            this.gridviewTimkiemkhach.Location = new System.Drawing.Point(64, 286);
            this.gridviewTimkiemkhach.Name = "gridviewTimkiemkhach";
            this.gridviewTimkiemkhach.Size = new System.Drawing.Size(865, 208);
            this.gridviewTimkiemkhach.TabIndex = 3;
            // 
            // Makhach
            // 
            this.Makhach.DataPropertyName = "Makhach";
            this.Makhach.HeaderText = "Mã khách";
            this.Makhach.Name = "Makhach";
            this.Makhach.Width = 70;
            // 
            // Tenkhach
            // 
            this.Tenkhach.DataPropertyName = "Tenkhach";
            this.Tenkhach.HeaderText = "Tên khách";
            this.Tenkhach.Name = "Tenkhach";
            this.Tenkhach.Width = 170;
            // 
            // Ngaysinh
            // 
            this.Ngaysinh.DataPropertyName = "Ngaysinh";
            this.Ngaysinh.HeaderText = "Ngày sinh";
            this.Ngaysinh.Name = "Ngaysinh";
            this.Ngaysinh.Width = 110;
            // 
            // Gioitinh
            // 
            this.Gioitinh.DataPropertyName = "Gioitinh";
            this.Gioitinh.HeaderText = "Giới tính";
            this.Gioitinh.Name = "Gioitinh";
            this.Gioitinh.Width = 70;
            // 
            // SoCMND
            // 
            this.SoCMND.DataPropertyName = "SoCMND";
            this.SoCMND.HeaderText = "Số CMND";
            this.SoCMND.Name = "SoCMND";
            // 
            // Diachithuongtru
            // 
            this.Diachithuongtru.DataPropertyName = "Diachithuongtru";
            this.Diachithuongtru.HeaderText = "Địa chỉ";
            this.Diachithuongtru.Name = "Diachithuongtru";
            this.Diachithuongtru.Width = 120;
            // 
            // Manghe
            // 
            this.Manghe.DataPropertyName = "Manghe";
            this.Manghe.HeaderText = "Nghề nghiệp";
            this.Manghe.Name = "Manghe";
            // 
            // MaCQ
            // 
            this.MaCQ.DataPropertyName = "MaCQ";
            this.MaCQ.HeaderText = "Cơ quan";
            this.MaCQ.Name = "MaCQ";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.BackgroundImage")));
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThoat.Location = new System.Drawing.Point(699, 37);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(127, 42);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "     Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbnghe);
            this.groupBox1.Controls.Add(this.cmbdiachi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbkhach);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(29, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(922, 136);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thực hiện nhập";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Controls.Add(this.btnTimlai);
            this.groupBox2.Controls.Add(this.btnTimkiem);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(29, 533);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(922, 116);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thao tác";
            // 
            // btnTimlai
            // 
            this.btnTimlai.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTimlai.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTimlai.BackgroundImage")));
            this.btnTimlai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTimlai.Location = new System.Drawing.Point(408, 37);
            this.btnTimlai.Name = "btnTimlai";
            this.btnTimlai.Size = new System.Drawing.Size(127, 42);
            this.btnTimlai.TabIndex = 2;
            this.btnTimlai.Text = "     Tìm lại";
            this.btnTimlai.UseVisualStyleBackColor = false;
            this.btnTimlai.Click += new System.EventHandler(this.btnTimlai_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(369, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(279, 46);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tìm kiếm khách";
            // 
            // FrmTimKiemKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridviewTimkiemkhach);
            this.Controls.Add(this.label4);
            this.Name = "FrmTimKiemKhach";
            this.Text = "FrmTimKiemKhach";
            this.Load += new System.EventHandler(this.FrmTimKiemKhach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewTimkiemkhach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbkhach;
        private System.Windows.Forms.ComboBox cmbdiachi;
        private System.Windows.Forms.ComboBox cmbnghe;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.DataGridView gridviewTimkiemkhach;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTimlai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Makhach;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tenkhach;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaysinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gioitinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoCMND;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diachithuongtru;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manghe;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCQ;
    }
}