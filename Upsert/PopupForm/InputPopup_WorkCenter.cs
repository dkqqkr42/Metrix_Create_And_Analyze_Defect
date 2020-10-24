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
    public partial class InputPopup_WorkCenter : MetroForm
    {
        public delegate void FormSendDataHandler(List<string> list);
        //이벤트 생성
        public event FormSendDataHandler FormSendEvent;
        public InputPopup_WorkCenter()
        {
            InitializeComponent();
        }
        public InputPopup_WorkCenter(string plantcode, string wccode, string teamcode)
        {
            InitializeComponent();
            txt_PLANT_CODE.Text = plantcode;
            txt_WC_CODE.Text = wccode;
            txt_TEAM_CODE.Text = teamcode;
        }
        public InputPopup_WorkCenter(List<string> list)
        {
            InitializeComponent();
            txt_PLANT_CODE.Text = list[1];
            txt_WC_CODE.Text = list[2];
            txt_TEAM_CODE.Text = list[3];
            txt_MRP_MGR.Text = list[4];
            txt_COST_WC_CODE.Text = list[5];
            txt_WC_NAME.Text = list[6];
            txt_ESTI_OPR_RATE.Text = list[7];
            txt_ESTI_IO_RATE.Text = list[8];
            txt_REQ_MP_MAN.Text = list[9];
            txt_REQ_MP_WOMAN.Text = list[10];
            txt_REQ_MP_OUT.Text = list[11];
            txt_OPT_MACHINE_DIV.Text = list[12];
            txt_ORDER_USE_YB.Text = list[13];
            txt_WC_NO.Text = list[14];
            txt_DEL_FLAG.Text = list[15];
            txt_SAP_WC_FLAG.Text = list[16];
            txt_INSERT_DATE.Text = list[17];
            txt_INSERT_USER.Text = list[18];
            txt_UPDATE_DATE.Text = list[19];
            txt_UPDATE_USER.Text = list[20];
            txt_DEPT_CD.Text = list[21];
            txt_ORDER_SEQ.Text = list[22];
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add(txt_PLANT_CODE.Text);
            list.Add(txt_WC_CODE.Text);
            list.Add(txt_TEAM_CODE.Text);
            list.Add(txt_MRP_MGR.Text);
            list.Add(txt_COST_WC_CODE.Text);
            list.Add(txt_WC_NAME.Text);
            list.Add(txt_ESTI_OPR_RATE.Text);
            list.Add(txt_ESTI_IO_RATE.Text);
            list.Add(txt_REQ_MP_MAN.Text);
            list.Add(txt_REQ_MP_WOMAN.Text);
            list.Add(txt_REQ_MP_OUT.Text);
            list.Add(txt_OPT_MACHINE_DIV.Text);
            list.Add(txt_ORDER_USE_YB.Text);
            list.Add(txt_WC_NO.Text);
            list.Add(txt_DEL_FLAG.Text);
            list.Add(txt_SAP_WC_FLAG.Text);
            list.Add(txt_INSERT_DATE.Text);
            list.Add(txt_INSERT_USER.Text);
            list.Add(txt_UPDATE_DATE.Text);
            list.Add(txt_UPDATE_USER.Text);
            list.Add(txt_DEPT_CD.Text);
            list.Add(txt_ORDER_SEQ.Text);
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
