namespace ShopCakeManager
{
    partial class SanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SanPham));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.img_sp = new Bunifu.Framework.UI.BunifuImageButton();
            this.lb_ten = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_gia = new System.Windows.Forms.Label();
            this.lb_giamgia = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_sp)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 18;
            this.bunifuElipse1.TargetControl = this;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.img_sp, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_ten, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.80488F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.37037F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.28395F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(145, 162);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // img_sp
            // 
            this.img_sp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.img_sp.BackColor = System.Drawing.Color.White;
            this.img_sp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_sp.Image = ((System.Drawing.Image)(resources.GetObject("img_sp.Image")));
            this.img_sp.ImageActive = null;
            this.img_sp.Location = new System.Drawing.Point(14, 8);
            this.img_sp.Margin = new System.Windows.Forms.Padding(3, 8, 3, 5);
            this.img_sp.Name = "img_sp";
            this.img_sp.Size = new System.Drawing.Size(116, 88);
            this.img_sp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img_sp.TabIndex = 1;
            this.img_sp.TabStop = false;
            this.img_sp.Zoom = 10;
            this.img_sp.Click += new System.EventHandler(this.img_sp_Click);
            // 
            // lb_ten
            // 
            this.lb_ten.AutoSize = true;
            this.lb_ten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_ten.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ten.Location = new System.Drawing.Point(3, 101);
            this.lb_ten.Name = "lb_ten";
            this.lb_ten.Size = new System.Drawing.Size(139, 32);
            this.lb_ten.TabIndex = 2;
            this.lb_ten.Text = "Bánh socola aaaaaaaaaaaaaaaa";
            this.lb_ten.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.72662F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.27338F));
            this.tableLayoutPanel2.Controls.Add(this.lb_gia, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lb_giamgia, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 136);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(139, 23);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // lb_gia
            // 
            this.lb_gia.AutoSize = true;
            this.lb_gia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_gia.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_gia.Location = new System.Drawing.Point(61, 0);
            this.lb_gia.Name = "lb_gia";
            this.lb_gia.Size = new System.Drawing.Size(75, 23);
            this.lb_gia.TabIndex = 4;
            this.lb_gia.Text = "100000";
            this.lb_gia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_giamgia
            // 
            this.lb_giamgia.AutoSize = true;
            this.lb_giamgia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_giamgia.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_giamgia.Location = new System.Drawing.Point(3, 0);
            this.lb_giamgia.Name = "lb_giamgia";
            this.lb_giamgia.Size = new System.Drawing.Size(52, 23);
            this.lb_giamgia.TabIndex = 5;
            this.lb_giamgia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SanPham";
            this.Size = new System.Drawing.Size(145, 162);
            this.Load += new System.EventHandler(this.SanPham_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_sp)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Bunifu.Framework.UI.BunifuImageButton img_sp;
        private System.Windows.Forms.Label lb_ten;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lb_gia;
        private System.Windows.Forms.Label lb_giamgia;
    }
}
