namespace QuanLyQuanCaPhe_CNPM
{
    partial class frQLCongThuc
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
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.cmbTenNL = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dgvCongThuc = new System.Windows.Forms.DataGridView();
            this.lblTenMonDangChon = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbHamLuong = new DevExpress.XtraEditors.TextEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.lblDVT = new DevExpress.XtraEditors.LabelControl();
            this.cmbTenMon = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTenNL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHamLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTenMon.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.Location = new System.Drawing.Point(315, 49);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(91, 23);
            this.simpleButton2.TabIndex = 26;
            this.simpleButton2.Text = "Xóa Khỏi";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(315, 21);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(91, 23);
            this.simpleButton1.TabIndex = 26;
            this.simpleButton1.Text = "Thêm Vào";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // cmbTenNL
            // 
            this.cmbTenNL.Location = new System.Drawing.Point(112, 23);
            this.cmbTenNL.Name = "cmbTenNL";
            this.cmbTenNL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.cmbTenNL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTenNL.Size = new System.Drawing.Size(176, 22);
            this.cmbTenNL.TabIndex = 0;
            this.cmbTenNL.SelectedIndexChanged += new System.EventHandler(this.cmbTenNL_SelectedIndexChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgvCongThuc);
            this.groupControl2.Location = new System.Drawing.Point(2, 200);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(425, 236);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Danh Sách";
            // 
            // dgvCongThuc
            // 
            this.dgvCongThuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCongThuc.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCongThuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongThuc.Location = new System.Drawing.Point(8, 23);
            this.dgvCongThuc.Name = "dgvCongThuc";
            this.dgvCongThuc.Size = new System.Drawing.Size(409, 208);
            this.dgvCongThuc.TabIndex = 0;
            this.dgvCongThuc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCongThuc_CellClick);
            // 
            // lblTenMonDangChon
            // 
            this.lblTenMonDangChon.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTenMonDangChon.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenMonDangChon.ForeColor = System.Drawing.Color.White;
            this.lblTenMonDangChon.Location = new System.Drawing.Point(3, 3);
            this.lblTenMonDangChon.Name = "lblTenMonDangChon";
            this.lblTenMonDangChon.Size = new System.Drawing.Size(424, 44);
            this.lblTenMonDangChon.TabIndex = 1;
            this.lblTenMonDangChon.Text = "Món Ăn";
            this.lblTenMonDangChon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(11, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 13);
            this.labelControl1.TabIndex = 27;
            this.labelControl1.Text = "Tên Nguyên Liệu";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(11, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 27;
            this.labelControl2.Text = "Hàm Lượng";
            // 
            // cmbHamLuong
            // 
            this.cmbHamLuong.Location = new System.Drawing.Point(112, 49);
            this.cmbHamLuong.Name = "cmbHamLuong";
            this.cmbHamLuong.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.cmbHamLuong.Properties.Mask.EditMask = "N0";
            this.cmbHamLuong.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.cmbHamLuong.Size = new System.Drawing.Size(81, 22);
            this.cmbHamLuong.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.groupControl4);
            this.groupControl3.Controls.Add(this.cmbTenMon);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Location = new System.Drawing.Point(2, 50);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(425, 144);
            this.groupControl3.TabIndex = 29;
            this.groupControl3.Text = "Chọn Món Ăn";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.lblDVT);
            this.groupControl4.Controls.Add(this.cmbTenNL);
            this.groupControl4.Controls.Add(this.simpleButton2);
            this.groupControl4.Controls.Add(this.labelControl2);
            this.groupControl4.Controls.Add(this.simpleButton1);
            this.groupControl4.Controls.Add(this.labelControl1);
            this.groupControl4.Controls.Add(this.cmbHamLuong);
            this.groupControl4.Location = new System.Drawing.Point(6, 57);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(411, 75);
            this.groupControl4.TabIndex = 28;
            this.groupControl4.Text = "Chọn Nguyên Liệu";
            // 
            // lblDVT
            // 
            this.lblDVT.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblDVT.Appearance.Options.UseForeColor = true;
            this.lblDVT.Location = new System.Drawing.Point(212, 52);
            this.lblDVT.Name = "lblDVT";
            this.lblDVT.Size = new System.Drawing.Size(54, 13);
            this.lblDVT.TabIndex = 28;
            this.lblDVT.Text = "Đơn Vị Tính";
            // 
            // cmbTenMon
            // 
            this.cmbTenMon.Location = new System.Drawing.Point(117, 24);
            this.cmbTenMon.Name = "cmbTenMon";
            this.cmbTenMon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.cmbTenMon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTenMon.Size = new System.Drawing.Size(251, 22);
            this.cmbTenMon.TabIndex = 0;
            this.cmbTenMon.SelectedIndexChanged += new System.EventHandler(this.cmbTenMon_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(58, 27);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(53, 14);
            this.labelControl3.TabIndex = 27;
            this.labelControl3.Text = "Tên Món";
            // 
            // frQLCongThuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 439);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.lblTenMonDangChon);
            this.Controls.Add(this.groupControl2);
            this.Name = "frQLCongThuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Công Thức";
            this.Load += new System.EventHandler(this.FormCongThuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbTenNL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHamLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTenMon.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.ComboBoxEdit cmbTenNL;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.DataGridView dgvCongThuc;
        private System.Windows.Forms.Label lblTenMonDangChon;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit cmbHamLuong;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTenMon;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.LabelControl lblDVT;
    }
}