using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_Profile.PopupForm;
using MetroFramework.Forms;
using Oracle.ManagedDataAccess.Client;

namespace FinalProject_Profile
{
    public partial class SAPOrder : MetroForm
    {
        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";

        public SAPOrder()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void metroButton2_Click(object sender, EventArgs e)  // 입력버튼 누를 경우 실행
        {
            InputPopup_SAPOrder inputPopup_SAPOrder = new InputPopup_SAPOrder();
            inputPopup_SAPOrder.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)  // 확정버튼 누를 경우 실행
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)  // 조회버튼 누를 경우 실행
        {

        }
    }
}
