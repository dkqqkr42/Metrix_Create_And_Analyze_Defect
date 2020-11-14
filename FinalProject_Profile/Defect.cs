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

namespace FinalProject_Profile
{
    public partial class Defect : MetroForm
    {
        Main main;
        Dictionary<string, string> result;

        int box_pcs, plt_box;
        string prod_code, order_no, job_no, prod_name, prod_unit, order_m, work_gbn, gubun;
        int good_qty = 0, good_box = 0, good_plt = 0;
        int total_qty = 0, total_box = 0, total_plt = 0;
        int bad_qty = 0, bad_box = 0;

        public Defect()
        {
            InitializeComponent();
        }
        public Defect(Main mainForm)
        {
            InitializeComponent();
            main = mainForm;
        }

        public Defect(Dictionary<string, string> _result)
        {
            InitializeComponent();
            result = _result;

            prod_code = result["PROD_CODE"];
            order_no = result["ORDER_NO"]; ;
            prod_name = result["PROD_NAME"];
            prod_unit = result["PROD_UNIT"];
            order_m = result["ORDER_M"]; ;
            work_gbn = result["WORK_GBN"];
            gubun = result["GUBUN"];

            good_qty = Int32.Parse(result["GOOD_QTY"]);
            bad_qty = Int32.Parse(result["BAD_QTY"]);
            total_qty = Int32.Parse(result["TOTAL_QTY"]);

            box_pcs = Int32.Parse(result["BOX_PCS"]);
            plt_box = Int32.Parse(result["PLT_BOX"]);

            UpdateData();
            UpdateControl();
        }
        
        public void UpdateData()
        {
            total_box = total_qty / box_pcs;
            total_plt = total_box / plt_box;
            
            good_box = good_qty / box_pcs;
            good_plt = good_box / plt_box;

            bad_box = bad_qty / box_pcs;

        }

        public void UpdateControl()
        {
            lbl_Total_QTY.Text = total_qty.ToString();
            lbl_Total_BOX.Text = total_box.ToString();
            lbl_Total_PLT.Text = total_plt.ToString();

            lbl_Total_QTY2.Text = total_qty.ToString();
            lbl_Total_BOX2.Text = total_box.ToString();

            lbl_Good_QTY.Text = good_qty.ToString();
            lbl_Good_BOX.Text = good_box.ToString();
            lbl_Good_PLT.Text = good_plt.ToString();

            lbl_Bad_QTY.Text = bad_qty.ToString();
            lbl_Bad_BOX.Text = bad_box.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            SelectDefect child8 = new SelectDefect();
            child8.Show();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }
}
