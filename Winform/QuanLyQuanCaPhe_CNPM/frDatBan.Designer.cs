namespace QuanLyQuanCaPhe_CNPM
{
    partial class frDatBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frDatBan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTen = new JTextBox.JTextBox();
            this.txtSdt = new JTextBox.JTextBox();
            this.txtGio = new JTextBox.JTextBox();
            this.btnHuy = new FlatButton.JFlatButton();
            this.btnDatBan = new FlatButton.JFlatButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-15, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 57);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(58, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông Tin Đặt Bàn";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtTen
            // 
            this.txtTen.AutoSize = true;
            this.txtTen.BorderColor = System.Drawing.Color.Black;
            this.txtTen.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTen.Hint = "Tên";
            this.txtTen.IsPassword = false;
            this.txtTen.Length = 0;
            this.txtTen.Location = new System.Drawing.Point(12, 62);
            this.txtTen.Name = "txtTen";
            this.txtTen.OnFocus = System.Drawing.Color.Black;
            this.txtTen.OnlyChar = false;
            this.txtTen.OnlyNumber = false;
            this.txtTen.Size = new System.Drawing.Size(252, 39);
            this.txtTen.TabIndex = 0;
            this.txtTen.TextValue = "Tên";
            this.txtTen.Load += new System.EventHandler(this.txtTen_Load);
            // 
            // txtSdt
            // 
            this.txtSdt.AutoSize = true;
            this.txtSdt.BorderColor = System.Drawing.Color.Black;
            this.txtSdt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSdt.Hint = "Số Điện Thoại";
            this.txtSdt.IsPassword = false;
            this.txtSdt.Length = 0;
            this.txtSdt.Location = new System.Drawing.Point(12, 107);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.OnFocus = System.Drawing.Color.Black;
            this.txtSdt.OnlyChar = false;
            this.txtSdt.OnlyNumber = false;
            this.txtSdt.Size = new System.Drawing.Size(252, 39);
            this.txtSdt.TabIndex = 0;
            this.txtSdt.TextValue = "Số Điện Thoại";
            this.txtSdt.Load += new System.EventHandler(this.txtSdt_Load);
            // 
            // txtGio
            // 
            this.txtGio.AutoSize = true;
            this.txtGio.BorderColor = System.Drawing.Color.Black;
            this.txtGio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtGio.Hint = "Giờ";
            this.txtGio.IsPassword = false;
            this.txtGio.Length = 0;
            this.txtGio.Location = new System.Drawing.Point(12, 152);
            this.txtGio.Name = "txtGio";
            this.txtGio.OnFocus = System.Drawing.Color.Black;
            this.txtGio.OnlyChar = false;
            this.txtGio.OnlyNumber = false;
            this.txtGio.Size = new System.Drawing.Size(252, 39);
            this.txtGio.TabIndex = 0;
            this.txtGio.TextValue = "Giờ";
            this.txtGio.Load += new System.EventHandler(this.txtGio_Load);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Red;
            this.btnHuy.BackgroundColor = System.Drawing.Color.Red;
            this.btnHuy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnHuy.ButtonText = "Hủy";
            this.btnHuy.CausesValidation = false;
            this.btnHuy.ErrorImageLeft = ((System.Drawing.Image)(resources.GetObject("btnHuy.ErrorImageLeft")));
            this.btnHuy.ErrorImageRight = ((System.Drawing.Image)(resources.GetObject("btnHuy.ErrorImageRight")));
            this.btnHuy.FocusBackground = System.Drawing.Color.Empty;
            this.btnHuy.FocusFontColor = System.Drawing.Color.Empty;
            this.btnHuy.ForeColors = System.Drawing.Color.White;
            this.btnHuy.HoverBackground = System.Drawing.Color.Empty;
            this.btnHuy.HoverFontColor = System.Drawing.Color.Empty;
            this.btnHuy.ImageLeft = null;
            this.btnHuy.ImageRight = null;
            this.btnHuy.LeftPictureColor = System.Drawing.Color.Transparent;
            this.btnHuy.Location = new System.Drawing.Point(147, 197);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.PaddingLeftPicture = new System.Windows.Forms.Padding(0);
            this.btnHuy.PaddingRightPicture = new System.Windows.Forms.Padding(0);
            this.btnHuy.RightPictureColor = System.Drawing.Color.Transparent;
            this.btnHuy.Size = new System.Drawing.Size(117, 29);
            this.btnHuy.SizeModeLeft = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnHuy.SizeModeRight = System.Windows.Forms.PictureBoxSizeMode.Normal;
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Click += new System.EventHandler(this.jFlatButton1_Click);
            // 
            // btnDatBan
            // 
            this.btnDatBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDatBan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDatBan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnDatBan.ButtonText = "Đặt";
            this.btnDatBan.CausesValidation = false;
            this.btnDatBan.ErrorImageLeft = ((System.Drawing.Image)(resources.GetObject("btnDatBan.ErrorImageLeft")));
            this.btnDatBan.ErrorImageRight = ((System.Drawing.Image)(resources.GetObject("btnDatBan.ErrorImageRight")));
            this.btnDatBan.FocusBackground = System.Drawing.Color.Empty;
            this.btnDatBan.FocusFontColor = System.Drawing.Color.Empty;
            this.btnDatBan.ForeColors = System.Drawing.Color.White;
            this.btnDatBan.HoverBackground = System.Drawing.Color.Empty;
            this.btnDatBan.HoverFontColor = System.Drawing.Color.Empty;
            this.btnDatBan.ImageLeft = null;
            this.btnDatBan.ImageRight = null;
            this.btnDatBan.LeftPictureColor = System.Drawing.Color.Transparent;
            this.btnDatBan.Location = new System.Drawing.Point(14, 197);
            this.btnDatBan.Name = "btnDatBan";
            this.btnDatBan.PaddingLeftPicture = new System.Windows.Forms.Padding(0);
            this.btnDatBan.PaddingRightPicture = new System.Windows.Forms.Padding(0);
            this.btnDatBan.RightPictureColor = System.Drawing.Color.Transparent;
            this.btnDatBan.Size = new System.Drawing.Size(117, 29);
            this.btnDatBan.SizeModeLeft = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnDatBan.SizeModeRight = System.Windows.Forms.PictureBoxSizeMode.Normal;
            this.btnDatBan.TabIndex = 0;
            this.btnDatBan.Click += new System.EventHandler(this.btnDatBan_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(-2, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 258);
            this.label2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(274, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 258);
            this.label3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(-18, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(376, 53);
            this.label4.TabIndex = 6;
            // 
            // frDatBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 247);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnDatBan);
            this.Controls.Add(this.txtGio);
            this.Controls.Add(this.txtSdt);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frDatBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormOrder";
            this.Load += new System.EventHandler(this.FormOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FlatButton.JFlatButton btnDatBan;
        private JTextBox.JTextBox txtTen;
        private JTextBox.JTextBox txtSdt;
        private JTextBox.JTextBox txtGio;
        private FlatButton.JFlatButton btnHuy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}