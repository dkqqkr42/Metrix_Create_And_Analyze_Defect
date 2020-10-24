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
    public partial class InputPopup_Worker : MetroForm
    {
        public delegate void FormSendDataHandler(List<string> list);
        //이벤트 생성
        public event FormSendDataHandler FormSendEvent;
        public InputPopup_Worker()
        {
            InitializeComponent();
        }
        public InputPopup_Worker(List<string> list)
        {
            InitializeComponent();
            txt_PLANT_CODE.Text = list[1];
            txt_WC_CODE.Text = list[2];
            txt_SHIFT_CODE.Text = list[3];
            txt_SHIFT_NAME.Text = list[4];
            txt_SA_SABUN.Text = list[5];
            txt_REQ_MP_MAN.Text = list[6];
            txt_REQ_MP_WOMAN.Text = list[7];
            txt_REQ_MP_OUT.Text = list[8];
            txt_START_TIME.Text = list[9];
            txt_END_TIME.Text = list[10];
            txt_WORKING_TIME.Text = list[11];
            txt_BIGO.Text = list[12];
            txt_USE_FLAG.Text = list[13];
            txt_DEL_FLAG.Text = list[14];
            txt_INSERT_DATE.Text = list[15];
            txt_INSERT_USER.Text = list[16];
            txt_UPDATE_DATE.Text = list[17];
            txt_UPDATE_USER.Text = list[18];
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
            list.Add(txt_SHIFT_CODE.Text);
            list.Add(txt_SHIFT_NAME.Text);
            list.Add(txt_SA_SABUN.Text);
            list.Add(txt_REQ_MP_MAN.Text);
            list.Add(txt_REQ_MP_WOMAN.Text);
            list.Add(txt_REQ_MP_OUT.Text);
            list.Add(txt_START_TIME.Text);
            list.Add(txt_END_TIME.Text);
            list.Add(txt_WORKING_TIME.Text);
            list.Add(txt_BIGO.Text);
            list.Add(txt_USE_FLAG.Text);
            list.Add(txt_DEL_FLAG.Text);
            list.Add(txt_INSERT_DATE.Text);
            list.Add(txt_INSERT_USER.Text);
            list.Add(txt_UPDATE_DATE.Text);
            list.Add(txt_UPDATE_USER.Text);
            list.Add(txt_UPDATE_DATE2.Text);
            list.Add(txt_UPDATE_USER2.Text);
            list.Add(txt_DEPT_CD.Text);
            list.Add(txt_ORDER_SEQ.Text);
            FormSendEvent(list);
            this.Close();
        }
    }
}
