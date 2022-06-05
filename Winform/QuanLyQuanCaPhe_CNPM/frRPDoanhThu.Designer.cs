namespace QuanLyQuanCaPhe_CNPM
{
    partial class frRPDoanhThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frRPDoanhThu));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cmbLuaChon = new DevExpress.XtraEditors.ComboBoxEdit();
            this.grKhoangThoiGian = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateeditTo = new DevExpress.XtraEditors.DateEdit();
            this.dateeditFr = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.lblTongSoHD = new DevExpress.XtraEditors.LabelControl();
            this.lblTongDoanhThu = new DevExpress.XtraEditors.LabelControl();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHD = new DevExpress.XtraEditors.LabelControl();
            this.btnXemLai = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLuaChon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grKhoangThoiGian)).BeginInit();
            this.grKhoangThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateeditTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateeditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateeditFr.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateeditFr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImageOptions.Image")));
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Controls.Add(this.grKhoangThoiGian);
            this.groupControl1.Location = new System.Drawing.Point(3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(637, 106);
            this.groupControl1.TabIndex = 26;
            this.groupControl1.Text = "Thông Tin";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.cmbLuaChon);
            this.groupControl2.Location = new System.Drawing.Point(8, 42);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(308, 52);
            this.groupControl2.TabIndex = 32;
            this.groupControl2.Text = "Thời Gian";
            // 
            // cmbLuaChon
            // 
            this.cmbLuaChon.Location = new System.Drawing.Point(84, 23);
            this.cmbLuaChon.Name = "cmbLuaChon";
            this.cmbLuaChon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLuaChon.Properties.Items.AddRange(new object[] {
            "Hôm Nay",
            "Tuần Này",
            "Tháng Này",
            "Khoảng Thời Gian"});
            this.cmbLuaChon.Size = new System.Drawing.Size(155, 20);
            this.cmbLuaChon.TabIndex = 29;
            this.cmbLuaChon.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // grKhoangThoiGian
            // 
            this.grKhoangThoiGian.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grKhoangThoiGian.AppearanceCaption.Options.UseFont = true;
            this.grKhoangThoiGian.Controls.Add(this.labelControl1);
            this.grKhoangThoiGian.Controls.Add(this.dateeditTo);
            this.grKhoangThoiGian.Controls.Add(this.dateeditFr);
            this.grKhoangThoiGian.Controls.Add(this.labelControl2);
            this.grKhoangThoiGian.Enabled = false;
            this.grKhoangThoiGian.Location = new System.Drawing.Point(322, 42);
            this.grKhoangThoiGian.Name = "grKhoangThoiGian";
            this.grKhoangThoiGian.Size = new System.Drawing.Size(310, 52);
            this.grKhoangThoiGian.TabIndex = 31;
            this.grKhoangThoiGian.Text = "Khoảng Thời Gian";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(2, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(15, 13);
            this.labelControl1.TabIndex = 28;
            this.labelControl1.Text = "Từ";
            // 
            // dateeditTo
            // 
            this.dateeditTo.EditValue = new System.DateTime(2020, 7, 16, 0, 0, 0, 0);
            this.dateeditTo.Location = new System.Drawing.Point(181, 23);
            this.dateeditTo.Name = "dateeditTo";
            this.dateeditTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateeditTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateeditTo.Size = new System.Drawing.Size(123, 20);
            this.dateeditTo.TabIndex = 30;
            this.dateeditTo.EditValueChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // dateeditFr
            // 
            this.dateeditFr.EditValue = new System.DateTime(2020, 7, 16, 0, 0, 0, 0);
            this.dateeditFr.Location = new System.Drawing.Point(23, 23);
            this.dateeditFr.Name = "dateeditFr";
            this.dateeditFr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateeditFr.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateeditFr.Size = new System.Drawing.Size(123, 20);
            this.dateeditFr.TabIndex = 30;
            this.dateeditFr.EditValueChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(152, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 28;
            this.labelControl2.Text = "Đến";
            // 
            // simpleButton1
            // 
            this.simpleButton1.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.simpleButton1.AppearanceHovered.Options.UseBackColor = true;
            this.simpleButton1.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.simpleButton1.AppearancePressed.Options.UseBackColor = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(599, 187);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(41, 35);
            this.simpleButton1.TabIndex = 27;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.Location = new System.Drawing.Point(3, 235);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.Size = new System.Drawing.Size(637, 332);
            this.dgvDoanhThu.TabIndex = 27;
            this.dgvDoanhThu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDoanhThu_CellClick);
            // 
            // lblTongSoHD
            // 
            this.lblTongSoHD.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSoHD.Appearance.Options.UseFont = true;
            this.lblTongSoHD.Location = new System.Drawing.Point(347, 187);
            this.lblTongSoHD.Name = "lblTongSoHD";
            this.lblTongSoHD.Size = new System.Drawing.Size(115, 16);
            this.lblTongSoHD.TabIndex = 29;
            this.lblTongSoHD.Text = "Tổng Số Hóa Đơn:";
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongDoanhThu.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblTongDoanhThu.Appearance.Options.UseFont = true;
            this.lblTongDoanhThu.Appearance.Options.UseForeColor = true;
            this.lblTongDoanhThu.Location = new System.Drawing.Point(347, 206);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(108, 16);
            this.lblTongDoanhThu.TabIndex = 29;
            this.lblTongDoanhThu.Text = "Tổng Doanh Thu:";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.SystemColors.Control;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(0, -11);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(637, 71);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Chọn Thời Gian Thống Kê";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblTieuDe);
            this.panel1.Location = new System.Drawing.Point(3, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 60);
            this.panel1.TabIndex = 28;
            // 
            // lblHD
            // 
            this.lblHD.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHD.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblHD.Appearance.Options.UseFont = true;
            this.lblHD.Appearance.Options.UseForeColor = true;
            this.lblHD.Location = new System.Drawing.Point(138, 198);
            this.lblHD.Name = "lblHD";
            this.lblHD.Size = new System.Drawing.Size(16, 13);
            this.lblHD.TabIndex = 33;
            this.lblHD.Text = "HD";
            // 
            // btnXemLai
            // 
            this.btnXemLai.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemLai.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.btnXemLai.Appearance.Options.UseFont = true;
            this.btnXemLai.Appearance.Options.UseForeColor = true;
            this.btnXemLai.Enabled = false;
            this.btnXemLai.Location = new System.Drawing.Point(3, 193);
            this.btnXemLai.Name = "btnXemLai";
            this.btnXemLai.Size = new System.Drawing.Size(129, 23);
            this.btnXemLai.TabIndex = 32;
            this.btnXemLai.Text = "Xem Lại Hóa Đơn";
            this.btnXemLai.Click += new System.EventHandler(this.btnXemLai_Click);
            // 
            // frRPDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 569);
            this.Controls.Add(this.lblHD);
            this.Controls.Add(this.btnXemLai);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.lblTongDoanhThu);
            this.Controls.Add(this.lblTongSoHD);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDoanhThu);
            this.Controls.Add(this.groupControl1);
            this.Name = "frRPDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doanh Thu";
            this.Load += new System.EventHandler(this.FormDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbLuaChon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grKhoangThoiGian)).EndInit();
            this.grKhoangThoiGian.ResumeLayout(false);
            this.grKhoangThoiGian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateeditTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateeditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateeditFr.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateeditFr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private DevExpress.XtraEditors.ComboBoxEdit cmbLuaChon;
        private DevExpress.XtraEditors.DateEdit dateeditTo;
        private DevExpress.XtraEditors.DateEdit dateeditFr;
        private DevExpress.XtraEditors.LabelControl lblTongSoHD;
        private DevExpress.XtraEditors.LabelControl lblTongDoanhThu;
        private DevExpress.XtraEditors.GroupControl grKhoangThoiGian;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl lblHD;
        private DevExpress.XtraEditors.SimpleButton btnXemLai;
    }
}