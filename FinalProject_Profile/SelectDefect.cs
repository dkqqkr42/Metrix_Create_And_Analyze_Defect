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
using Oracle.ManagedDataAccess.Client;

namespace FinalProject_Profile
{
    public partial class SelectDefect : MetroForm
    {
        Defect defect;
        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";
        int check_flag = 0;
        public SelectDefect()
        {
            InitializeComponent();
        }

        public SelectDefect(Defect _defect)
        {
            InitializeComponent();
            defect = _defect;
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

        public void InsertData()
        {
            
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            this.Close();
            defect.Activate();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            check_flag = 0;
            metroButton6.Text = "가소제";
            metroButton7.Text = "광택";
            metroButton8.Text = "기포";
            metroButton9.Text = "도료면불량";
            metroButton10.Text = "면혹";
            metroButton11.Text = "면홈";
            metroButton12.Text = "밀링";
            metroButton13.Text = "박리";
            metroButton14.Text = "수포";
            metroButton15.Text = "얼룩";
            metroButton16.Text = "원료줄(SKIN)";
            metroButton17.Text = "이면밀림";
            metroButton18.Text = "칼줄(선)";
            metroButton19.Text = "표면";
            metroButton20.Text = "핀홀";
            metroButton21.Text = "흰반점";
            metroButton22.Text = "기타";
            metroButton23.Text = "";
            metroButton24.Text = "";
            metroButton25.Text = "";


        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            check_flag = 1;
            metroButton6.Text = "워밍탄화";
            metroButton7.Text = "원료잡물";
            metroButton8.Text = "인쇄압(억제)";
            metroButton9.Text = "잡물";
            metroButton10.Text = "탄화물";
            metroButton11.Text = "기타이물";
            metroButton12.Text = "";
            metroButton13.Text = "";
            metroButton14.Text = "";
            metroButton15.Text = "";
            metroButton16.Text = "";
            metroButton17.Text = "";
            metroButton18.Text = "";
            metroButton19.Text = "";
            metroButton20.Text = "";
            metroButton21.Text = "";
            metroButton22.Text = "";
            metroButton23.Text = "";
            metroButton24.Text = "";
            metroButton25.Text = "";
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            check_flag = 2;
            metroButton6.Text = "겹침";
            metroButton7.Text = "면뜯김";
            metroButton8.Text = "시작불량";
            metroButton9.Text = "연결";
            metroButton10.Text = "찍힘";
            metroButton11.Text = "후공정 부족";
            metroButton12.Text = "겔링";
            metroButton13.Text = "구멍";
            metroButton14.Text = "";
            metroButton15.Text = "";
            metroButton16.Text = "";
            metroButton17.Text = "";
            metroButton18.Text = "";
            metroButton19.Text = "";
            metroButton20.Text = "";
            metroButton21.Text = "";
            metroButton22.Text = "";
            metroButton23.Text = "";
            metroButton24.Text = "";
            metroButton25.Text = "";
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            check_flag = 3;
            metroButton6.Text = "무늬";
            metroButton7.Text = "색상";
            metroButton8.Text = "색상교환";
            metroButton9.Text = "이색CHIP";
            metroButton10.Text = "좌우이색";
            metroButton11.Text = "SP#무늬불량";
            metroButton12.Text = "TYPE교환";
            metroButton13.Text = "";
            metroButton14.Text = "";
            metroButton15.Text = "";
            metroButton16.Text = "";
            metroButton17.Text = "";
            metroButton18.Text = "";
            metroButton19.Text = "";
            metroButton20.Text = "";
            metroButton21.Text = "";
            metroButton22.Text = "";
            metroButton23.Text = "";
            metroButton24.Text = "";
            metroButton25.Text = "";
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            if (check_flag == 0)
                defect.InsertData("A01");
            else if (check_flag == 1)
                defect.InsertData("B01");
            else if (check_flag == 2)
                defect.InsertData("C01");
            else if (check_flag == 3)
                defect.InsertData("D01");

            this.Close();
            defect.Activate();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            if (check_flag == 0)
                defect.InsertData("A02");
            else if (check_flag == 1)
                defect.InsertData("B02");
            else if (check_flag == 2)
                defect.InsertData("C02");
            else if (check_flag == 3)
                defect.InsertData("D02");

            this.Close();
            defect.Activate();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            if (check_flag == 0)
                defect.InsertData("A03");
            else if (check_flag == 1)
                defect.InsertData("B03");
            else if (check_flag == 2)
                defect.InsertData("C03");
            else if (check_flag == 3)
                defect.InsertData("D03");

            this.Close();
            defect.Activate();
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            if (check_flag == 0)
                defect.InsertData("A04");
            else if (check_flag == 1)
                defect.InsertData("B04");
            else if (check_flag == 2)
                defect.InsertData("C04");
            else if (check_flag == 3)
                defect.InsertData("D04");

            this.Close();
            defect.Activate();
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            if (check_flag == 0)
                defect.InsertData("A05");
            else if (check_flag == 1)
                defect.InsertData("B05");
            else if (check_flag == 2)
                defect.InsertData("C05");
            else if (check_flag == 3)
                defect.InsertData("D05");

            this.Close();
            defect.Activate();
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            if (check_flag == 0)
                defect.InsertData("A06");
            else if (check_flag == 1)
                defect.InsertData("B06");
            else if (check_flag == 2)
                defect.InsertData("C06");
            else if (check_flag == 3)
                defect.InsertData("D06");

            this.Close();
            defect.Activate();
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            if (check_flag == 0)
                defect.InsertData("A07");
            else if (check_flag == 1)
                return;
            else if (check_flag == 2)
                defect.InsertData("C07");
            else if (check_flag == 3)
                defect.InsertData("D07");

            this.Close();
            defect.Activate();
        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            if (check_flag == 0)
                defect.InsertData("A08");
            else if (check_flag == 1)
                return;
            else if (check_flag == 2)
                defect.InsertData("C08");
            else if (check_flag == 3)
                return;

            this.Close();
            defect.Activate();
        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            if (check_flag == 0)
                defect.InsertData("A09");
            else if (check_flag == 1)
                return;
            else if (check_flag == 2)
                defect.InsertData("C09");
            else if (check_flag == 3)
                return;

            this.Close();
            defect.Activate();
        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            if (check_flag == 0)
                defect.InsertData("A10");
            else if (check_flag == 1)
                return;
            else if (check_flag == 2)
                return;
            else if (check_flag == 3)
                return;

            this.Close();
            defect.Activate();
        }

        private void metroButton16_Click(object sender, EventArgs e)
        {
            if (check_flag == 0)
                defect.InsertData("A11");
            else if (check_flag == 1)
                return;
            else if (check_flag == 2)
                return;
            else if (check_flag == 3)
                return;

            this.Close();
            defect.Activate();
        }

        private void metroButton17_Click(object sender, EventArgs e)
        {
            if (check_flag == 0)
                defect.InsertData("A12");
            else if (check_flag == 1)
                return;
            else if (check_flag == 2)
                return;
            else if (check_flag == 3)
                return;

            this.Close();
            defect.Activate();
        }

        private void metroButton18_Click(object sender, EventArgs e)
        {
            if (check_flag == 0)
                defect.InsertData("A13");
            else if (check_flag == 1)
                return;
            else if (check_flag == 2)
                return;
            else if (check_flag == 3)
                return;

            this.Close();
            defect.Activate();
        }

        private void metroButton19_Click(object sender, EventArgs e)
        {
            if (check_flag == 0)
                defect.InsertData("A14");
            else if (check_flag == 1)
                return;
            else if (check_flag == 2)
                return;
            else if (check_flag == 3)
                return;

            this.Close();
            defect.Activate();
        }

        private void metroButton20_Click(object sender, EventArgs e)
        {
            if (check_flag == 0)
                defect.InsertData("A15");
            else if (check_flag == 1)
                return;
            else if (check_flag == 2)
                return;
            else if (check_flag == 3)
                return;

            this.Close();
            defect.Activate();
        }

        private void metroButton21_Click(object sender, EventArgs e)
        {
            if (check_flag == 0)
                defect.InsertData("A16");
            else if (check_flag == 1)
                return;
            else if (check_flag == 2)
                return;
            else if (check_flag == 3)
                return;

            this.Close();
            defect.Activate();
        }

        private void metroButton22_Click(object sender, EventArgs e)
        {
            if (check_flag == 0)
                defect.InsertData("A17");
            else if (check_flag == 1)
                return;
            else if (check_flag == 2)
                return;
            else if (check_flag == 3)
                return;

            this.Close();
            defect.Activate();
        }
    }
}
