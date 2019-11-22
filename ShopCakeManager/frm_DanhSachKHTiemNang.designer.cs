namespace ShopCakeManager
{
    partial class frm_DanhSachKHTiemNang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DanhSachKHTiemNang));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgv_KHTiemNang = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_In = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_Dong = new Bunifu.Framework.UI.BunifuFlatButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_KHTiemNang)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.bunifuImageButton1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtgv_KHTiemNang, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.78032F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.58581F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.25172F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.153318F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(888, 453);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(202)))), ((int)(((byte)(242)))));
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(851, 4);
            this.bunifuImageButton1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(33, 27);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 18;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 20;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(882, 57);
            this.label1.TabIndex = 19;
            this.label1.Text = "Danh Sách Khách Hàng Tiềm Năng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgv_KHTiemNang
            // 
            this.dtgv_KHTiemNang.AllowUserToAddRows = false;
            this.dtgv_KHTiemNang.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgv_KHTiemNang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_KHTiemNang.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dtgv_KHTiemNang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgv_KHTiemNang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(139)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_KHTiemNang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgv_KHTiemNang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_KHTiemNang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKH,
            this.TenKH,
            this.SDT,
            this.DiaChi});
            this.dtgv_KHTiemNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgv_KHTiemNang.DoubleBuffered = true;
            this.dtgv_KHTiemNang.EnableHeadersVisualStyles = false;
            this.dtgv_KHTiemNang.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(139)))), ((int)(((byte)(222)))));
            this.dtgv_KHTiemNang.HeaderForeColor = System.Drawing.Color.White;
            this.dtgv_KHTiemNang.Location = new System.Drawing.Point(3, 95);
            this.dtgv_KHTiemNang.Name = "dtgv_KHTiemNang";
            this.dtgv_KHTiemNang.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgv_KHTiemNang.RowTemplate.Height = 24;
            this.dtgv_KHTiemNang.Size = new System.Drawing.Size(882, 312);
            this.dtgv_KHTiemNang.TabIndex = 20;
            // 
            // MaKH
            // 
            this.MaKH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaKH.DataPropertyName = "maKH";
            this.MaKH.HeaderText = "Mã KH";
            this.MaKH.Name = "MaKH";
            // 
            // TenKH
            // 
            this.TenKH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenKH.DataPropertyName = "tenKH";
            this.TenKH.HeaderText = "Tên KH";
            this.TenKH.Name = "TenKH";
            // 
            // SDT
            // 
            this.SDT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SDT.DataPropertyName = "sdt";
            this.SDT.HeaderText = "SDT";
            this.SDT.Name = "SDT";
            // 
            // DiaChi
            // 
            this.DiaChi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DiaChi.DataPropertyName = "diaChi";
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.81179F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.82086F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.25397F));
            this.tableLayoutPanel2.Controls.Add(this.btn_In, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Dong, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 413);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(882, 37);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // btn_In
            // 
            this.btn_In.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_In.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_In.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_In.BorderRadius = 7;
            this.btn_In.ButtonText = "In Danh sách";
            this.btn_In.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_In.DisabledColor = System.Drawing.Color.Gray;
            this.btn_In.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_In.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_In.Iconimage")));
            this.btn_In.Iconimage_right = null;
            this.btn_In.Iconimage_right_Selected = null;
            this.btn_In.Iconimage_Selected = null;
            this.btn_In.IconMarginLeft = 0;
            this.btn_In.IconMarginRight = 0;
            this.btn_In.IconRightVisible = true;
            this.btn_In.IconRightZoom = 0D;
            this.btn_In.IconVisible = true;
            this.btn_In.IconZoom = 90D;
            this.btn_In.IsTab = false;
            this.btn_In.Location = new System.Drawing.Point(558, 4);
            this.btn_In.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_In.Name = "btn_In";
            this.btn_In.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_In.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btn_In.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_In.selected = false;
            this.btn_In.Size = new System.Drawing.Size(158, 29);
            this.btn_In.TabIndex = 0;
            this.btn_In.Text = "In Danh sách";
            this.btn_In.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_In.Textcolor = System.Drawing.Color.White;
            this.btn_In.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btn_Dong
            // 
            this.btn_Dong.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_Dong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_Dong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Dong.BorderRadius = 7;
            this.btn_Dong.ButtonText = "Đóng";
            this.btn_Dong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Dong.DisabledColor = System.Drawing.Color.Gray;
            this.btn_Dong.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_Dong.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_Dong.Iconimage")));
            this.btn_Dong.Iconimage_right = null;
            this.btn_Dong.Iconimage_right_Selected = null;
            this.btn_Dong.Iconimage_Selected = null;
            this.btn_Dong.IconMarginLeft = 0;
            this.btn_Dong.IconMarginRight = 0;
            this.btn_Dong.IconRightVisible = true;
            this.btn_Dong.IconRightZoom = 0D;
            this.btn_Dong.IconVisible = true;
            this.btn_Dong.IconZoom = 90D;
            this.btn_Dong.IsTab = false;
            this.btn_Dong.Location = new System.Drawing.Point(724, 4);
            this.btn_Dong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Dong.Name = "btn_Dong";
            this.btn_Dong.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_Dong.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btn_Dong.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_Dong.selected = false;
            this.btn_Dong.Size = new System.Drawing.Size(154, 29);
            this.btn_Dong.TabIndex = 1;
            this.btn_Dong.Text = "Đóng";
            this.btn_Dong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Dong.Textcolor = System.Drawing.Color.White;
            this.btn_Dong.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dong.Click += new System.EventHandler(this.btn_Dong_Click);
            // 
            // frm_DanhSachKHTiemNang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(222)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(888, 453);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_DanhSachKHTiemNang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_DanhSachKHTiemNang";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_KHTiemNang)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dtgv_KHTiemNang;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Bunifu.Framework.UI.BunifuFlatButton btn_In;
        private Bunifu.Framework.UI.BunifuFlatButton btn_Dong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
    }
}