﻿namespace QLTN
{
    partial class FrmNhaChuaThanhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNhaChuaThanhToan));
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.gridviewBaocaochuathanhtoan = new System.Windows.Forms.DataGridView();
            this.Manha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tenkhach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Masothue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tenchunha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridviewKetqua = new System.Windows.Forms.DataGridView();
            this.Tenkhach1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manha1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Masothue1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tenchunha1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewBaocaochuathanhtoan)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewKetqua)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.BackgroundImage")));
            this.btnTimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTimKiem.Location = new System.Drawing.Point(240, 38);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(119, 42);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "    Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.BackgroundImage")));
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThoat.Location = new System.Drawing.Point(541, 38);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(119, 42);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "    Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // gridviewBaocaochuathanhtoan
            // 
            this.gridviewBaocaochuathanhtoan.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridviewBaocaochuathanhtoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewBaocaochuathanhtoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Manha,
            this.Tenkhach,
            this.Masothue,
            this.Tenchunha});
            this.gridviewBaocaochuathanhtoan.Location = new System.Drawing.Point(177, 102);
            this.gridviewBaocaochuathanhtoan.Name = "gridviewBaocaochuathanhtoan";
            this.gridviewBaocaochuathanhtoan.Size = new System.Drawing.Size(642, 217);
            this.gridviewBaocaochuathanhtoan.TabIndex = 3;
            // 
            // Manha
            // 
            this.Manha.DataPropertyName = "Manha";
            this.Manha.HeaderText = "Mã nhà";
            this.Manha.Name = "Manha";
            // 
            // Tenkhach
            // 
            this.Tenkhach.DataPropertyName = "Tenkhach";
            this.Tenkhach.HeaderText = "Tên khách";
            this.Tenkhach.Name = "Tenkhach";
            this.Tenkhach.Width = 200;
            // 
            // Masothue
            // 
            this.Masothue.DataPropertyName = "Masothue";
            this.Masothue.HeaderText = "Mã số thuê";
            this.Masothue.Name = "Masothue";
            // 
            // Tenchunha
            // 
            this.Tenchunha.DataPropertyName = "Tenchunha";
            this.Tenchunha.HeaderText = "Tên chủ nhà";
            this.Tenchunha.Name = "Tenchunha";
            this.Tenchunha.Width = 200;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(63, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(881, 46);
            this.label2.TabIndex = 0;
            this.label2.Text = "Báo cáo các nhà chưa thanh toán tiền thuê trong tháng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(41, 325);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(903, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thao tác";
            // 
            // gridviewKetqua
            // 
            this.gridviewKetqua.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridviewKetqua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewKetqua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tenkhach1,
            this.Manha1,
            this.Masothue1,
            this.Tenchunha1});
            this.gridviewKetqua.Location = new System.Drawing.Point(177, 467);
            this.gridviewKetqua.Name = "gridviewKetqua";
            this.gridviewKetqua.Size = new System.Drawing.Size(642, 150);
            this.gridviewKetqua.TabIndex = 5;
            // 
            // Tenkhach1
            // 
            this.Tenkhach1.DataPropertyName = "Tenkhach";
            this.Tenkhach1.HeaderText = "Tên khách";
            this.Tenkhach1.Name = "Tenkhach1";
            this.Tenkhach1.Width = 200;
            // 
            // Manha1
            // 
            this.Manha1.DataPropertyName = "Manha";
            this.Manha1.HeaderText = "Mã nhà";
            this.Manha1.Name = "Manha1";
            // 
            // Masothue1
            // 
            this.Masothue1.DataPropertyName = "Masothue";
            this.Masothue1.HeaderText = "Mã số thuê";
            this.Masothue1.Name = "Masothue1";
            // 
            // Tenchunha1
            // 
            this.Tenchunha1.DataPropertyName = "Tenchunha";
            this.Tenchunha1.HeaderText = "Tên chủ nhà";
            this.Tenchunha1.Name = "Tenchunha1";
            this.Tenchunha1.Width = 200;
            // 
            // FrmNhaChuaThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.gridviewKetqua);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridviewBaocaochuathanhtoan);
            this.Controls.Add(this.label2);
            this.Name = "FrmNhaChuaThanhToan";
            this.Text = "FrmNhaChuaThanhToan";
            this.Load += new System.EventHandler(this.FrmNhaChuaThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewBaocaochuathanhtoan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewKetqua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView gridviewBaocaochuathanhtoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridviewKetqua;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tenkhach;
        private System.Windows.Forms.DataGridViewTextBoxColumn Masothue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tenchunha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tenkhach1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manha1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Masothue1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tenchunha1;
    }
}