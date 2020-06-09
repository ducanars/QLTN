namespace QLTN
{
    partial class frmTranha
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbMasothue = new System.Windows.Forms.ComboBox();
            this.dtpNgaytra = new System.Windows.Forms.DateTimePicker();
            this.txtTongtien = new System.Windows.Forms.TextBox();
            this.gridviewTranha = new System.Windows.Forms.DataGridView();
            this.Masothue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaytra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tongtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewTranha)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(305, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày trả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(399, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "Trả nhà";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(620, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tổng tiền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã số thuê";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbMasothue);
            this.groupBox1.Controls.Add(this.dtpNgaytra);
            this.groupBox1.Controls.Add(this.txtTongtien);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 117);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thực hiện nhập";
            // 
            // cmbMasothue
            // 
            this.cmbMasothue.FormattingEnabled = true;
            this.cmbMasothue.Location = new System.Drawing.Point(110, 44);
            this.cmbMasothue.Name = "cmbMasothue";
            this.cmbMasothue.Size = new System.Drawing.Size(160, 28);
            this.cmbMasothue.TabIndex = 3;
            // 
            // dtpNgaytra
            // 
            this.dtpNgaytra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaytra.Location = new System.Drawing.Point(383, 46);
            this.dtpNgaytra.Name = "dtpNgaytra";
            this.dtpNgaytra.Size = new System.Drawing.Size(175, 27);
            this.dtpNgaytra.TabIndex = 2;
            // 
            // txtTongtien
            // 
            this.txtTongtien.Location = new System.Drawing.Point(712, 45);
            this.txtTongtien.Name = "txtTongtien";
            this.txtTongtien.Size = new System.Drawing.Size(171, 27);
            this.txtTongtien.TabIndex = 1;
            // 
            // gridviewTranha
            // 
            this.gridviewTranha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewTranha.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Masothue,
            this.Ngaytra,
            this.Tongtien});
            this.gridviewTranha.Location = new System.Drawing.Point(163, 175);
            this.gridviewTranha.Name = "gridviewTranha";
            this.gridviewTranha.Size = new System.Drawing.Size(581, 150);
            this.gridviewTranha.TabIndex = 2;
            // 
            // Masothue
            // 
            this.Masothue.DataPropertyName = "Masothue";
            this.Masothue.HeaderText = "Mã số thuê";
            this.Masothue.Name = "Masothue";
            // 
            // Ngaytra
            // 
            this.Ngaytra.DataPropertyName = "Ngaytra";
            this.Ngaytra.HeaderText = "Ngày trả";
            this.Ngaytra.Name = "Ngaytra";
            // 
            // Tongtien
            // 
            this.Tongtien.DataPropertyName = "Tongtien";
            this.Tongtien.HeaderText = "Tông tiển";
            this.Tongtien.Name = "Tongtien";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Controls.Add(this.btnLuu);
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.btnSua);
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 331);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(889, 117);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thao tác";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnThem.Location = new System.Drawing.Point(27, 26);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(105, 80);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSua.Location = new System.Drawing.Point(203, 26);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(105, 80);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnXoa.Location = new System.Drawing.Point(383, 26);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(105, 80);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLuu.Location = new System.Drawing.Point(567, 27);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(105, 80);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnThoat.Location = new System.Drawing.Point(746, 27);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(105, 80);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // frmTranha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 450);
            this.Controls.Add(this.gridviewTranha);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Name = "frmTranha";
            this.Text = "frmTranha";
            this.Load += new System.EventHandler(this.frmTranha_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewTranha)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbMasothue;
        private System.Windows.Forms.DateTimePicker dtpNgaytra;
        private System.Windows.Forms.TextBox txtTongtien;
        private System.Windows.Forms.DataGridView gridviewTranha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Masothue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaytra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tongtien;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
    }
}