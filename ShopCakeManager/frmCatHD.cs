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
    public partial class frmCatHD : Form
    {
        public delegate void loadLaiCTHD_ChuaThanhToan(List<Tuple<string, int>> CTHDLists);

        public static event loadLaiCTHD_ChuaThanhToan loadLaiCTHD_ChuaThanhToanEvent;

        ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();

        ConvertDataTable cv = new ConvertDataTable();

        List<Tuple<string, int>> CTHDLists = new List<Tuple<string, int>>();

        DataTable dt;
        private static frmCatHD inst;
        public frmCatHD()
        {
            InitializeComponent();
        }

        public static frmCatHD getForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                {
                    inst = new frmCatHD();
                }
                return inst;
            }
        }
        public void loadHDChuaThanhToan()
        {
            dtgv_hd.AutoGenerateColumns = false;
            
            dtgv_hd.DataSource = cv.ToDataTable(webservice.get_hoaDonChuaThanhToan());
        }

        public void loadPDChuaThanhToan()
        {
            dtgv_pd.AutoGenerateColumns = false;

            dtgv_pd.DataSource = cv.ToDataTable(webservice.get_phieuDatChuaThanhToan());
        }
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {   
            this.Hide();
        }

        private void frmCatHD_Load(object sender, EventArgs e)
        {
            loadHDChuaThanhToan();

            loadPDChuaThanhToan();
        }

        private void dtgv_hd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CTHDLists.Clear();

            get_chiTiet(Int32.Parse(dtgv_hd.CurrentRow.Cells[0].Value.ToString()));

            loadLaiCTHD_ChuaThanhToanEvent(CTHDLists);

            this.Hide();
        }

        public void get_chiTiet(int maHD)
        {
            dt = new DataTable();

            dt = cv.ToDataTable(webservice.get_CTHDChuaThanhToan(maHD));

            foreach (DataRow item in dt.Rows)
            {
                CTHDLists.Add(Tuple.Create(item["maBanhTrongNgay"].ToString(),Int32.Parse(item["soLuong"].ToString())));
            }
        }
       
    }
}
