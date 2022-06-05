namespace QuanLyQuanCaPhe_CNPM
{
    partial class frChamCong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.dgvChamCong = new System.Windows.Forms.DataGridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblThongTin = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCa = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtNgay = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtThang = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtNam = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtTenNV = new DevExpress.XtraEditors.TextEdit();
            this.txtMaNV = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNhanVien.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNhanVien.Location = new System.Drawing.Point(5, 23);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.Size = new System.Drawing.Size(457, 353);
            this.dgvNhanVien.TabIndex = 0;
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);
            this.dgvNhanVien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellContentClick);
            // 
            // dgvChamCong
            // 
            this.dgvChamCong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChamCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChamCong.Location = new System.Drawing.Point(8, 132);
            this.dgvChamCong.Name = "dgvChamCong";
            this.dgvChamCong.Size = new System.Drawing.Size(550, 310);
            this.dgvChamCong.TabIndex = 0;
            this.dgvChamCong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChamCong_CellClick);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblThongTin);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.dgvChamCong);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.cmbCa);
            this.groupControl1.Controls.Add(this.txtNgay);
            this.groupControl1.Controls.Add(this.txtThang);
            this.groupControl1.Controls.Add(this.txtNam);
            this.groupControl1.Location = new System.Drawing.Point(648, 72);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(566, 450);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Thông Tin Ngày Làm";
            // 
            // lblThongTin
            // 
            this.lblThongTin.BackColor = System.Drawing.SystemColors.Control;
            this.lblThongTin.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTin.Location = new System.Drawing.Point(8, 77);
            this.lblThongTin.Name = "lblThongTin";
            this.lblThongTin.Size = new System.Drawing.Size(550, 52);
            this.lblThongTin.TabIndex = 42;
            this.lblThongTin.Text = "Danh Sách Nhân Viên Làm";
            this.lblThongTin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(412, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ca";
            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(270, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Năm";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(134, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tháng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ngày";
            // 
            // cmbCa
            // 
            this.cmbCa.EditValue = "C1";
            this.cmbCa.Location = new System.Drawing.Point(451, 41);
            this.cmbCa.Name = "cmbCa";
            this.cmbCa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCa.Properties.Items.AddRange(new object[] {
            "C1",
            "C2",
            "C3"});
            this.cmbCa.Size = new System.Drawing.Size(107, 20);
            this.cmbCa.TabIndex = 0;
            this.cmbCa.SelectedIndexChanged += new System.EventHandler(this.cmbCa_SelectedIndexChanged);
            this.cmbCa.TextChanged += new System.EventHandler(this.cmbCa_TextChanged);
            // 
            // txtNgay
            // 
            this.txtNgay.EditValue = "23";
            this.txtNgay.Location = new System.Drawing.Point(47, 41);
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNgay.Size = new System.Drawing.Size(61, 20);
            this.txtNgay.TabIndex = 0;
            this.txtNgay.SelectedIndexChanged += new System.EventHandler(this.txtNgay_SelectedIndexChanged);
            this.txtNgay.EditValueChanged += new System.EventHandler(this.txtNgay_EditValueChanged);
            this.txtNgay.TextChanged += new System.EventHandler(this.txtNgay_TextChanged);
            // 
            // txtThang
            // 
            this.txtThang.EditValue = "9";
            this.txtThang.Location = new System.Drawing.Point(182, 41);
            this.txtThang.Name = "txtThang";
            this.txtThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtThang.Size = new System.Drawing.Size(61, 20);
            this.txtThang.TabIndex = 0;
            this.txtThang.SelectedIndexChanged += new System.EventHandler(this.txtThang_SelectedIndexChanged);
            this.txtThang.TextChanged += new System.EventHandler(this.txtThang_TextChanged);
            // 
            // txtNam
            // 
            this.txtNam.EditValue = "2019";
            this.txtNam.Location = new System.Drawing.Point(308, 41);
            this.txtNam.Name = "txtNam";
            this.txtNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNam.Size = new System.Drawing.Size(61, 20);
            this.txtNam.TabIndex = 0;
            this.txtNam.SelectedIndexChanged += new System.EventHandler(this.txtNam_SelectedIndexChanged);
            this.txtNam.TextChanged += new System.EventHandler(this.txtNam_TextChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgvNhanVien);
            this.groupControl2.Location = new System.Drawing.Point(96, 138);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(467, 384);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Danh Sách Nhân Viên";
            // 
            // btnThem
            // 
            this.btnThem.AppearanceHovered.BackColor = System.Drawing.Color.SkyBlue;
            this.btnThem.AppearanceHovered.Options.UseBackColor = true;
            this.btnThem.AppearancePressed.BackColor = System.Drawing.Color.Red;
            this.btnThem.AppearancePressed.Options.UseBackColor = true;
            this.btnThem.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnThem.Enabled = false;
            this.btnThem.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.forward_media_step;
            this.btnThem.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnThem.Location = new System.Drawing.Point(569, 282);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(73, 35);
            this.btnThem.TabIndex = 40;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AppearanceHovered.BackColor = System.Drawing.Color.SkyBlue;
            this.btnXoa.AppearanceHovered.Options.UseBackColor = true;
            this.btnXoa.AppearancePressed.BackColor = System.Drawing.Color.Red;
            this.btnXoa.AppearancePressed.Options.UseBackColor = true;
            this.btnXoa.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnXoa.Enabled = false;
            this.btnXoa.ImageOptions.Image = global::QuanLyQuanCaPhe_CNPM.Properties.Resources.media_step_back_arrow;
            this.btnXoa.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnXoa.Location = new System.Drawing.Point(569, 367);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(73, 35);
            this.btnXoa.TabIndex = 41;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.txtTenNV);
            this.groupControl3.Controls.Add(this.txtMaNV);
            this.groupControl3.Controls.Add(this.label6);
            this.groupControl3.Controls.Add(this.label7);
            this.groupControl3.Location = new System.Drawing.Point(96, 71);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(467, 61);
            this.groupControl3.TabIndex = 28;
            this.groupControl3.Text = "Thông Tin Nhân Viên Đang Chọn";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(194, 31);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Properties.ReadOnly = true;
            this.txtTenNV.Size = new System.Drawing.Size(237, 20);
            this.txtTenNV.TabIndex = 0;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(50, 30);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Properties.ReadOnly = true;
            this.txtMaNV.Size = new System.Drawing.Size(76, 20);
            this.txtMaNV.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 14);
            this.label6.TabIndex = 1;
            this.label6.Text = "Mã";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(158, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "Tên";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label11.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(90, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1133, 59);
            this.label11.TabIndex = 42;
            this.label11.Text = "     Chấm Công";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(92, 526);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1131, 5);
            this.label5.TabIndex = 42;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(87, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(5, 522);
            this.label8.TabIndex = 43;
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(1218, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(5, 522);
            this.label9.TabIndex = 43;
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 537);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frChamCong";
            this.Text = "Chấm Công";
            this.Load += new System.EventHandler(this.FormChamCong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.DataGridView dgvChamCong;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbCa;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label lblThongTin;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.TextEdit txtTenNV;
        private DevExpress.XtraEditors.TextEdit txtMaNV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.ComboBoxEdit txtNgay;
        private DevExpress.XtraEditors.ComboBoxEdit txtThang;
        private DevExpress.XtraEditors.ComboBoxEdit txtNam;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}