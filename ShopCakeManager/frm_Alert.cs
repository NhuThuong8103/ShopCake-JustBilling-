using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopCakeManager
{
    public partial class frm_Alert : Form
    {
        public frm_Alert( string _massage, AlertType type )
        {
            InitializeComponent();

            message.Text = _massage;

            switch (type)
            {
                case AlertType.success:
                    this.BackColor = Color.SeaGreen;
                    btnClose.BackColor = Color.SeaGreen;
                    icon.Image = imageList1.Images[3];
                    break;
                case AlertType.info:
                    this.BackColor = Color.Gray;
                    btnClose.BackColor = Color.Gray;
                    icon.Image = imageList1.Images[2];
                    break;
                case AlertType.warning:
                    this.BackColor = Color.Crimson;
                    btnClose.BackColor = Color.Crimson;
                    icon.Image = imageList1.Images[1];
                    break;
                case AlertType.error:
                    this.BackColor = Color.FromArgb(255,128,0);
                    btnClose.BackColor = Color.FromArgb(255, 128, 0);
                    icon.Image = imageList1.Images[0];
                    break;
            }
        }

        public static void Alert(string message, AlertType type)
        {
            new ShopCakeManager.frm_Alert(message, type).Show();
        }
        public enum AlertType
        {
            success, info, warning, error
        }


        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Alert_Load(object sender, EventArgs e)
        {
            this.Top = -1 * (this.Height);

            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 60;

            show.Start();
        }

        private void timeout_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        int interval = 0;
        private void show_Tick(object sender, EventArgs e)
        {
            if (this.Top < 40)// chiều cao của message
            {
                this.Top += interval;
                interval += 2;
            }
            else
            {
                show.Stop(); closeAlert.Start();
                // this.Close();
            }
        }

        private void close_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity-=0.002;
            }
            else
            {
                this.Close();
            }
        }
    }
}
