namespace ShopCakeManager.UC
{
    partial class UC_LoaiSP
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.anhsp = new System.Windows.Forms.PictureBox();
            this.lb_TenLoai = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_maloai = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.anhsp)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // anhsp
            // 
            this.anhsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.anhsp.Location = new System.Drawing.Point(0, 0);
            this.anhsp.Name = "anhsp";
            this.anhsp.Size = new System.Drawing.Size(101, 100);
            this.anhsp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.anhsp.TabIndex = 2;
            this.anhsp.TabStop = false;
            // 
            // lb_TenLoai
            // 
            this.lb_TenLoai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_TenLoai.AutoSize = true;
            this.lb_TenLoai.BackColor = System.Drawing.Color.Transparent;
            this.lb_TenLoai.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TenLoai.Location = new System.Drawing.Point(176, 21);
            this.lb_TenLoai.Name = "lb_TenLoai";
            this.lb_TenLoai.Size = new System.Drawing.Size(70, 19);
            this.lb_TenLoai.TabIndex = 12;
            this.lb_TenLoai.Text = "Tên loại";
            this.lb_TenLoai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.anhsp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(101, 100);
            this.panel1.TabIndex = 11;
            // 
            // lb_maloai
            // 
            this.lb_maloai.AutoSize = true;
            this.lb_maloai.Location = new System.Drawing.Point(137, 58);
            this.lb_maloai.Name = "lb_maloai";
            this.lb_maloai.Size = new System.Drawing.Size(53, 17);
            this.lb_maloai.TabIndex = 13;
            this.lb_maloai.Text = "ma loại";
            this.lb_maloai.Visible = false;
            // 
            // UC_LoaiSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lb_maloai);
            this.Controls.Add(this.lb_TenLoai);
            this.Controls.Add(this.panel1);
            this.Name = "UC_LoaiSP";
            this.Size = new System.Drawing.Size(383, 100);
            ((System.ComponentModel.ISupportInitialize)(this.anhsp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox anhsp;
        private System.Windows.Forms.Label lb_TenLoai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_maloai;
    }
}
