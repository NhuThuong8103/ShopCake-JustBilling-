namespace ShopCakeManager.UC
{
    partial class UC_ListSanPham
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
            this.lb_Loai = new System.Windows.Forms.Label();
            this.anhsp = new System.Windows.Forms.PictureBox();
            this.lb_TenBanhKem = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.anhsp)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_Loai
            // 
            this.lb_Loai.AutoSize = true;
            this.lb_Loai.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Loai.Location = new System.Drawing.Point(112, 65);
            this.lb_Loai.Name = "lb_Loai";
            this.lb_Loai.Size = new System.Drawing.Size(74, 19);
            this.lb_Loai.TabIndex = 10;
            this.lb_Loai.Text = "Tên Size";
            // 
            // anhsp
            // 
            this.anhsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.anhsp.Location = new System.Drawing.Point(0, 0);
            this.anhsp.Name = "anhsp";
            this.anhsp.Size = new System.Drawing.Size(101, 102);
            this.anhsp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.anhsp.TabIndex = 2;
            this.anhsp.TabStop = false;
            // 
            // lb_TenBanhKem
            // 
            this.lb_TenBanhKem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_TenBanhKem.AutoSize = true;
            this.lb_TenBanhKem.BackColor = System.Drawing.Color.Transparent;
            this.lb_TenBanhKem.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TenBanhKem.Location = new System.Drawing.Point(112, 21);
            this.lb_TenBanhKem.Name = "lb_TenBanhKem";
            this.lb_TenBanhKem.Size = new System.Drawing.Size(126, 19);
            this.lb_TenBanhKem.TabIndex = 7;
            this.lb_TenBanhKem.Text = "Tên bánh kem";
            this.lb_TenBanhKem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.anhsp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(101, 102);
            this.panel1.TabIndex = 6;
            // 
            // UC_ListSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lb_Loai);
            this.Controls.Add(this.lb_TenBanhKem);
            this.Controls.Add(this.panel1);
            this.Name = "UC_ListSanPham";
            this.Size = new System.Drawing.Size(411, 102);
            this.Load += new System.EventHandler(this.UC_ListSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.anhsp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Loai;
        private System.Windows.Forms.PictureBox anhsp;
        private System.Windows.Forms.Label lb_TenBanhKem;
        private System.Windows.Forms.Panel panel1;

    }
}
