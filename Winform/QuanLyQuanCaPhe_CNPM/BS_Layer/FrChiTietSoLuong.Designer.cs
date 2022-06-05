namespace QuanLyQuanCaPhe_CNPM.BS_Layer
{
    partial class FrChiTietSoLuong
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
            this.dgvChiTietSoLuong = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChiTietSoLuong
            // 
            this.dgvChiTietSoLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietSoLuong.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvChiTietSoLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietSoLuong.Location = new System.Drawing.Point(0, 0);
            this.dgvChiTietSoLuong.Name = "dgvChiTietSoLuong";
            this.dgvChiTietSoLuong.Size = new System.Drawing.Size(752, 239);
            this.dgvChiTietSoLuong.TabIndex = 0;
            // 
            // FrChiTietSoLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 239);
            this.Controls.Add(this.dgvChiTietSoLuong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrChiTietSoLuong";
            this.Text = "Chi Tiết Số Lượng Nguyên Liệu";
            this.Load += new System.EventHandler(this.ChiTietSoLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietSoLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChiTietSoLuong;
    }
}