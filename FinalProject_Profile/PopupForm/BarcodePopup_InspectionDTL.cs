using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using ZXing;

namespace FinalProject_Profile.PopupForm
{
    public partial class BarcodePopup_InspectionDTL : MetroForm
    {
        string in_Date;
        string in_Prod_Code;
        string in_U_Seq;
        string in_Tuip_Qty;
        string in_WC_CODE;

        public BarcodePopup_InspectionDTL()
        {
            InitializeComponent();
        }

        public BarcodePopup_InspectionDTL(string _in_Date, string _in_Prod_Code, string _in_U_Seq, string _in_Tuip_Qty, string _in_WC_CODE)
        {
            InitializeComponent();
            in_Date = _in_Date;
            in_Prod_Code = _in_Prod_Code;
            in_U_Seq = _in_U_Seq;
            in_Tuip_Qty = _in_Tuip_Qty;
            in_WC_CODE = _in_WC_CODE;
        }

        private void BarcodePopup_InspectionDTL_Load(object sender, EventArgs e)
        {
            try
            {
                    // 바코드 읽어오기
                    BarcodeReader barcodeReader = new BarcodeReader();

                    string deskPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                    string strQRCode = $"{in_Date}-{in_WC_CODE}-{in_Prod_Code}-{Int32.Parse(in_U_Seq).ToString("000")}-{in_Tuip_Qty}";
                    var barcodeBitmap = (Bitmap)Image.FromFile(deskPath + @"\BARCODE\" + strQRCode + ".jpg");
                    var result = barcodeReader.Decode(barcodeBitmap);

                    this.ptb_Barcode.Image = barcodeBitmap;
                    this.lbl_BAR_NO.Text = result.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Close_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Close.BackgroundImage = FinalProject_Profile.Properties.Resources.닫기5;
        }

        private void btn_Close_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Close.BackgroundImage = FinalProject_Profile.Properties.Resources.닫기클릭5;
        }
    }
}
