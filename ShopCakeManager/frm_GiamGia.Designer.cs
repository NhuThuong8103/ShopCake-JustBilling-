namespace ShopCakeManager
{
    partial class frm_GiamGia
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_GiamGia));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btn_Xoa = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_ThemSP = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_CapNhat = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenGG = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.bunifuMetroTextbox2 = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.MaGG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenGG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(202)))), ((int)(((byte)(242)))));
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(963, 4);
            this.bunifuImageButton1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(33, 31);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 18;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 20;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(222)))), ((int)(((byte)(242)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.bunifuImageButton1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 600);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 20;
            this.bunifuElipse2.TargetControl = this;
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_Xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(139)))), ((int)(((byte)(222)))));
            this.btn_Xoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Xoa.BorderRadius = 7;
            this.btn_Xoa.ButtonText = "Xóa";
            this.btn_Xoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Xoa.DisabledColor = System.Drawing.Color.Gray;
            this.btn_Xoa.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_Xoa.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_Xoa.Iconimage")));
            this.btn_Xoa.Iconimage_right = null;
            this.btn_Xoa.Iconimage_right_Selected = null;
            this.btn_Xoa.Iconimage_Selected = null;
            this.btn_Xoa.IconMarginLeft = 0;
            this.btn_Xoa.IconMarginRight = 0;
            this.btn_Xoa.IconRightVisible = true;
            this.btn_Xoa.IconRightZoom = 0D;
            this.btn_Xoa.IconVisible = true;
            this.btn_Xoa.IconZoom = 70D;
            this.btn_Xoa.IsTab = false;
            this.btn_Xoa.Location = new System.Drawing.Point(784, 480);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(139)))), ((int)(((byte)(222)))));
            this.btn_Xoa.OnHovercolor = System.Drawing.Color.Blue;
            this.btn_Xoa.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_Xoa.selected = false;
            this.btn_Xoa.Size = new System.Drawing.Size(200, 65);
            this.btn_Xoa.TabIndex = 6;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Xoa.Textcolor = System.Drawing.Color.White;
            this.btn_Xoa.TextFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_ThemSP
            // 
            this.btn_ThemSP.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_ThemSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(139)))), ((int)(((byte)(222)))));
            this.btn_ThemSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ThemSP.BorderRadius = 7;
            this.btn_ThemSP.ButtonText = "Thêm";
            this.btn_ThemSP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ThemSP.DisabledColor = System.Drawing.Color.Gray;
            this.btn_ThemSP.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_ThemSP.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_ThemSP.Iconimage")));
            this.btn_ThemSP.Iconimage_right = null;
            this.btn_ThemSP.Iconimage_right_Selected = null;
            this.btn_ThemSP.Iconimage_Selected = null;
            this.btn_ThemSP.IconMarginLeft = 0;
            this.btn_ThemSP.IconMarginRight = 0;
            this.btn_ThemSP.IconRightVisible = true;
            this.btn_ThemSP.IconRightZoom = 0D;
            this.btn_ThemSP.IconVisible = true;
            this.btn_ThemSP.IconZoom = 70D;
            this.btn_ThemSP.IsTab = false;
            this.btn_ThemSP.Location = new System.Drawing.Point(338, 480);
            this.btn_ThemSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ThemSP.Name = "btn_ThemSP";
            this.btn_ThemSP.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(139)))), ((int)(((byte)(222)))));
            this.btn_ThemSP.OnHovercolor = System.Drawing.Color.Blue;
            this.btn_ThemSP.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_ThemSP.selected = false;
            this.btn_ThemSP.Size = new System.Drawing.Size(186, 65);
            this.btn_ThemSP.TabIndex = 4;
            this.btn_ThemSP.Text = "Thêm";
            this.btn_ThemSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_ThemSP.Textcolor = System.Drawing.Color.White;
            this.btn_ThemSP.TextFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemSP.Click += new System.EventHandler(this.btn_ThemSP_Click);
            // 
            // btn_CapNhat
            // 
            this.btn_CapNhat.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_CapNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(139)))), ((int)(((byte)(222)))));
            this.btn_CapNhat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_CapNhat.BorderRadius = 7;
            this.btn_CapNhat.ButtonText = "Cập nhật";
            this.btn_CapNhat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CapNhat.DisabledColor = System.Drawing.Color.Gray;
            this.btn_CapNhat.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_CapNhat.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_CapNhat.Iconimage")));
            this.btn_CapNhat.Iconimage_right = null;
            this.btn_CapNhat.Iconimage_right_Selected = null;
            this.btn_CapNhat.Iconimage_Selected = null;
            this.btn_CapNhat.IconMarginLeft = 0;
            this.btn_CapNhat.IconMarginRight = 0;
            this.btn_CapNhat.IconRightVisible = true;
            this.btn_CapNhat.IconRightZoom = 0D;
            this.btn_CapNhat.IconVisible = true;
            this.btn_CapNhat.IconZoom = 70D;
            this.btn_CapNhat.IsTab = false;
            this.btn_CapNhat.Location = new System.Drawing.Point(562, 480);
            this.btn_CapNhat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_CapNhat.Name = "btn_CapNhat";
            this.btn_CapNhat.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(139)))), ((int)(((byte)(222)))));
            this.btn_CapNhat.OnHovercolor = System.Drawing.Color.Blue;
            this.btn_CapNhat.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_CapNhat.selected = false;
            this.btn_CapNhat.Size = new System.Drawing.Size(195, 65);
            this.btn_CapNhat.TabIndex = 5;
            this.btn_CapNhat.Text = "Cập nhật";
            this.btn_CapNhat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_CapNhat.Textcolor = System.Drawing.Color.White;
            this.btn_CapNhat.TextFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CapNhat.Click += new System.EventHandler(this.btn_CapNhat_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bunifuMetroTextbox2);
            this.panel1.Controls.Add(this.txtTenGG);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.btn_Xoa);
            this.panel1.Controls.Add(this.btn_ThemSP);
            this.panel1.Controls.Add(this.btn_CapNhat);
            this.panel1.Location = new System.Drawing.Point(3, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 555);
            this.panel1.TabIndex = 19;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(222)))), ((int)(((byte)(242)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaGG,
            this.TenGG});
            this.dataGridView1.Location = new System.Drawing.Point(338, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(646, 381);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(545, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "Danh sách giảm giá";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 28);
            this.label2.TabIndex = 9;
            this.label2.Text = "Thông tin chi tiết ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tên giảm giá:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Số giảm giá:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtTenGG
            // 
            this.txtTenGG.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtTenGG.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTenGG.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtTenGG.BorderThickness = 3;
            this.txtTenGG.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenGG.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtTenGG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTenGG.isPassword = false;
            this.txtTenGG.Location = new System.Drawing.Point(10, 137);
            this.txtTenGG.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenGG.Name = "txtTenGG";
            this.txtTenGG.Size = new System.Drawing.Size(286, 44);
            this.txtTenGG.TabIndex = 10;
            this.txtTenGG.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTenGG.OnValueChanged += new System.EventHandler(this.txtTenGG_OnValueChanged);
            // 
            // bunifuMetroTextbox2
            // 
            this.bunifuMetroTextbox2.BorderColorFocused = System.Drawing.Color.Blue;
            this.bunifuMetroTextbox2.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuMetroTextbox2.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.bunifuMetroTextbox2.BorderThickness = 3;
            this.bunifuMetroTextbox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuMetroTextbox2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.bunifuMetroTextbox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuMetroTextbox2.isPassword = false;
            this.bunifuMetroTextbox2.Location = new System.Drawing.Point(10, 247);
            this.bunifuMetroTextbox2.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuMetroTextbox2.Name = "bunifuMetroTextbox2";
            this.bunifuMetroTextbox2.Size = new System.Drawing.Size(286, 44);
            this.bunifuMetroTextbox2.TabIndex = 10;
            this.bunifuMetroTextbox2.Text = "bunifuMetroTextbox1";
            this.bunifuMetroTextbox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuMetroTextbox2.OnValueChanged += new System.EventHandler(this.bunifuMetroTextbox2_OnValueChanged);
            // 
            // MaGG
            // 
            this.MaGG.DataPropertyName = "MaGiamGia";
            this.MaGG.HeaderText = "Mã Giảm Giá";
            this.MaGG.Name = "MaGG";
            // 
            // TenGG
            // 
            this.TenGG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenGG.DataPropertyName = "TenGiamGia";
            this.TenGG.HeaderText = "Tên Giảm Giá";
            this.TenGG.Name = "TenGG";
            // 
            // frm_GiamGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_GiamGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_GiamGia";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_GiamGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuMetroTextbox bunifuMetroTextbox2;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtTenGG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Bunifu.Framework.UI.BunifuFlatButton btn_Xoa;
        private Bunifu.Framework.UI.BunifuFlatButton btn_ThemSP;
        private Bunifu.Framework.UI.BunifuFlatButton btn_CapNhat;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaGG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenGG;
    }
}