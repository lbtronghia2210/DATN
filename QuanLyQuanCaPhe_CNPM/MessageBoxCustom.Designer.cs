namespace QuanLyQuanCaPhe_CNPM
{
    partial class MessageBoxCustom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBoxCustom));
            this.label1 = new System.Windows.Forms.Label();
            this.btnDatBan = new FlatButton.JFlatButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(-3, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông Báo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnDatBan
            // 
            this.btnDatBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDatBan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDatBan.ButtonText = "OK";
            this.btnDatBan.CausesValidation = false;
            this.btnDatBan.ErrorImageLeft = ((System.Drawing.Image)(resources.GetObject("btnDatBan.ErrorImageLeft")));
            this.btnDatBan.ErrorImageRight = ((System.Drawing.Image)(resources.GetObject("btnDatBan.ErrorImageRight")));
            this.btnDatBan.FocusBackground = System.Drawing.Color.Empty;
            this.btnDatBan.FocusFontColor = System.Drawing.Color.Blue;
            this.btnDatBan.ForeColors = System.Drawing.Color.White;
            this.btnDatBan.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDatBan.HoverFontColor = System.Drawing.Color.Empty;
            this.btnDatBan.ImageLeft = null;
            this.btnDatBan.ImageRight = null;
            this.btnDatBan.LeftPictureColor = System.Drawing.Color.Transparent;
            this.btnDatBan.Location = new System.Drawing.Point(194, 138);
            this.btnDatBan.Name = "btnDatBan";
            this.btnDatBan.PaddingLeftPicture = new System.Windows.Forms.Padding(0);
            this.btnDatBan.PaddingRightPicture = new System.Windows.Forms.Padding(0);
            this.btnDatBan.RightPictureColor = System.Drawing.Color.Transparent;
            this.btnDatBan.Size = new System.Drawing.Size(76, 33);
            this.btnDatBan.SizeModeLeft = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnDatBan.SizeModeRight = System.Windows.Forms.PictureBoxSizeMode.Normal;
            this.btnDatBan.TabIndex = 10;
            this.btnDatBan.Click += new System.EventHandler(this.btnDatBan_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(-9, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(492, 15);
            this.label2.TabIndex = 11;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblThongBao
            // 
            this.lblThongBao.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.Location = new System.Drawing.Point(13, 49);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(448, 80);
            this.lblThongBao.TabIndex = 12;
            this.lblThongBao.Text = "Thông Báo Sẽ Xuất Hiện Sớm Thôi!";
            this.lblThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(-5, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 151);
            this.label3.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(467, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 164);
            this.label4.TabIndex = 14;
            // 
            // MessageBoxCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 196);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDatBan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageBoxCustom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageBox";
            this.Load += new System.EventHandler(this.MessageBoxCustom_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FlatButton.JFlatButton btnDatBan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}