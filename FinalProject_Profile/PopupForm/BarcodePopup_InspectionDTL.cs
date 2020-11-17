using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;


namespace FinalProject_Profile.PopupForm
{
    public partial class BarcodePopup_InspectionDTL : MetroForm
    {
        string bar_no;

        public BarcodePopup_InspectionDTL()
        {
            InitializeComponent();
        }

        public BarcodePopup_InspectionDTL(string _bar_no)
        {
            InitializeComponent();
            bar_no = _bar_no;
        }

        private void BarcodePopup_InspectionDTL_Load(object sender, EventArgs e)
        {
            // 바코드 읽어오기
            /*
            BarcodeReader barcodeReader = new BarcodeReader();
            var result = barcodeReader.Decode(new Bitmap(폼.Image));
            if (result != null)
                result.Text = "test";
            */
        }
    }
}
