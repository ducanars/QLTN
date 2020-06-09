namespace QLTN
{
    partial class frmDoituongsudung
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTenDTSD = new System.Windows.Forms.TextBox();
            this.txtMaDTSD = new System.Windows.Forms.TextBox();
            this.gridviewDoituongsudung = new System.Windows.Forms.DataGridView();
            this.MaDTSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDTSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewDoituongsudung)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã đối tượng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(380, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên đối tượng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(258, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 39);
            this.label3.TabIndex = 0;
            this.label3.Text = "Đối tượng sử dụng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTenDTSD);
            this.groupBox1.Controls.Add(this.txtMaDTSD);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(28, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 116);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thực hiện nhập";
            // 
            // txtTenDTSD
            // 
            this.txtTenDTSD.Location = new System.Drawing.Point(507, 36);
            this.txtTenDTSD.Name = "txtTenDTSD";
            this.txtTenDTSD.Size = new System.Drawing.Size(231, 27);
            this.txtTenDTSD.TabIndex = 1;
            // 
            // txtMaDTSD
            // 
            this.txtMaDTSD.Location = new System.Drawing.Point(125, 36);
            this.txtMaDTSD.Name = "txtMaDTSD";
            this.txtMaDTSD.Size = new System.Drawing.Size(222, 27);
            this.txtMaDTSD.TabIndex = 1;
            // 
            // gridviewDoituongsudung
            // 
            this.gridviewDoituongsudung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewDoituongsudung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDTSD,
            this.TenDTSD});
            this.gridviewDoituongsudung.Location = new System.Drawing.Point(128, 199);
            this.gridviewDoituongsudung.Name = "gridviewDoituongsudung";
            this.gridviewDoituongsudung.Size = new System.Drawing.Size(533, 127);
            this.gridviewDoituongsudung.TabIndex = 2;
            this.gridviewDoituongsudung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridviewDoituongsudung_CellClick);
            // 
            // MaDTSD
            // 
            this.MaDTSD.DataPropertyName = "MaDTSD";
            this.MaDTSD.HeaderText = "Mã đối tượng";
            this.MaDTSD.Name = "MaDTSD";
            // 
            // TenDTSD
            // 
            this.TenDTSD.DataPropertyName = "TenDTSD";
            this.TenDTSD.HeaderText = "Tên đối tượng";
            this.TenDTSD.Name = "TenDTSD";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnThem.Location = new System.Drawing.Point(30, 41);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(89, 48);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Controls.Add(this.btnLuu);
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.btnSua);
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(28, 364);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(744, 117);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thao tác";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnThoat.Location = new System.Drawing.Point(629, 41);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(89, 48);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLuu.Location = new System.Drawing.Point(481, 41);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(89, 48);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnXoa.Location = new System.Drawing.Point(332, 41);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(89, 48);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSua.Location = new System.Drawing.Point(178, 41);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(89, 48);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // frmDoituongsudung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 493);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gridviewDoituongsudung);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Name = "frmDoituongsudung";
            this.Text = "frmDoituongsudung";
            this.Load += new System.EventHandler(this.frmDoituongsudung_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewDoituongsudung)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTenDTSD;
        private System.Windows.Forms.TextBox txtMaDTSD;
        private System.Windows.Forms.DataGridView gridviewDoituongsudung;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDTSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDTSD;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
    }
}