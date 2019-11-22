namespace ShopCakeManager
{
    partial class TheLoaiSP
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TheLoaiSP));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.img_theloai = new Bunifu.Framework.UI.BunifuImageButton();
            this.lb_tentheloai = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.img_theloai)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 18;
            this.bunifuElipse1.TargetControl = this;
            // 
            // img_theloai
            // 
            this.img_theloai.BackColor = System.Drawing.Color.White;
            this.img_theloai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_theloai.Image = ((System.Drawing.Image)(resources.GetObject("img_theloai.Image")));
            this.img_theloai.ImageActive = null;
            this.img_theloai.Location = new System.Drawing.Point(11, 5);
            this.img_theloai.Name = "img_theloai";
            this.img_theloai.Size = new System.Drawing.Size(121, 103);
            this.img_theloai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img_theloai.TabIndex = 0;
            this.img_theloai.TabStop = false;
            this.img_theloai.Zoom = 5;
            this.img_theloai.Click += new System.EventHandler(this.img_theloai_Click);
            // 
            // lb_tentheloai
            // 
            this.lb_tentheloai.AutoSize = true;
            this.lb_tentheloai.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tentheloai.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lb_tentheloai.Location = new System.Drawing.Point(9, 114);
            this.lb_tentheloai.Name = "lb_tentheloai";
            this.lb_tentheloai.Size = new System.Drawing.Size(82, 16);
            this.lb_tentheloai.TabIndex = 1;
            this.lb_tentheloai.Text = "Bánh Socola";
            // 
            // TheLoaiSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lb_tentheloai);
            this.Controls.Add(this.img_theloai);
            this.Name = "TheLoaiSP";
            this.Size = new System.Drawing.Size(145, 142);
            this.Load += new System.EventHandler(this.TheLoaiSP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.img_theloai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label lb_tentheloai;
        private Bunifu.Framework.UI.BunifuImageButton img_theloai;

    }
}
