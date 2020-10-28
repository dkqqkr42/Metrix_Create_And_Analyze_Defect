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

namespace Upsert
{
    public partial class InputPopup_Employee : MetroForm
    {
        public delegate void FormSendDataHandler(List<string> list);
        //이벤트 생성
        public event FormSendDataHandler FormSendEvent;
        public InputPopup_Employee()
        {
            InitializeComponent();
        }
        public InputPopup_Employee(string sasabun, string deptnew)
        {
            InitializeComponent();
            txt_SA_SABUN.Text = sasabun;
            txt_SA_DEPT_NEW.Text = deptnew;
            this.ActiveControl = txt_SA_PASSWORD;
        }
        public InputPopup_Employee(List<string> list)
        {
            InitializeComponent();
            txt_SA_SABUN.Text = list[1];
            txt_SA_PASSWORD.Text = list[2];
            txt_SA_USER.Text = list[3];
            txt_SA_NAME.Text = list[4];
            txt_SA_AUTHORITY1.Text = list[5];
            txt_SA_AUTHORITY2.Text = list[6];
            txt_DIVISION_CODE.Text = list[7];
            txt_SA_JOBX.Text = list[8];
            txt_SA_JOBX_NAME.Text = list[9];
            txt_SA_DEPT_NEW.Text = list[10];
            txt_SA_DEPT.Text = list[11];
            txt_SA_DEPT_NAME.Text = list[12];
            txt_SA_JUMIN.Text = list[13];
            txt_SA_BORN.Text = list[14];
            txt_SA_HAND.Text = list[15];
            txt_DEL_FLAG.Text = list[16];
            txt_INSERT_DATE.Text = list[17];
            txt_INSERT_USER.Text = list[18];
            txt_UPDATE_DATE.Text = list[19];
            txt_UPDATE_USER.Text = list[20];
            txt_SA_AUTHORITY3.Text = list[21];
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add(txt_SA_SABUN.Text);
            list.Add(txt_SA_PASSWORD.Text);
            list.Add(txt_SA_USER.Text);
            list.Add(txt_SA_NAME.Text);
            list.Add(txt_SA_AUTHORITY1.Text);
            list.Add(txt_SA_AUTHORITY2.Text);
            list.Add(txt_DIVISION_CODE.Text);
            list.Add(txt_SA_JOBX.Text);
            list.Add(txt_SA_JOBX_NAME.Text);
            list.Add(txt_SA_DEPT_NEW.Text);
            list.Add(txt_SA_DEPT.Text);
            list.Add(txt_SA_DEPT_NAME.Text);
            list.Add(txt_SA_JUMIN.Text);
            list.Add(txt_SA_BORN.Text);
            list.Add(txt_SA_HAND.Text);
            list.Add(txt_DEL_FLAG.Text);
            list.Add(txt_INSERT_DATE.Text);
            list.Add(txt_INSERT_USER.Text);
            list.Add(txt_UPDATE_DATE.Text);
            list.Add(txt_UPDATE_USER.Text);
            list.Add(txt_SA_AUTHORITY3.Text);
            FormSendEvent(list);
            this.Close();
        }

        private void btn_Save_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Save.BackgroundImage = Upsert.Properties.Resources.저장1;
        }

        private void btn_Save_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Save.BackgroundImage = Upsert.Properties.Resources.저장클릭1;
        }

        private void btn_Close_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Close.BackgroundImage = Upsert.Properties.Resources.닫기;
        }

        private void btn_Close_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Close.BackgroundImage = Upsert.Properties.Resources.닫기클릭;
        }
    }
}
