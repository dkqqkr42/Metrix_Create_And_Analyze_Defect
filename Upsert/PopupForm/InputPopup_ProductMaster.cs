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
    public partial class InputPopup_ProductMaster : MetroForm
    {
        public delegate void FormSendDataHandler(List<string> list);
        //이벤트 생성
        public event FormSendDataHandler FormSendEvent;
        public InputPopup_ProductMaster()
        {
            InitializeComponent();
        }
        public InputPopup_ProductMaster(List<string> list)
        {
            InitializeComponent();
            txt_PROD_CODE.Text = list[1];
            txt_PLANT_CODE.Text = list[2];
            txt_MRP_MGR.Text = list[3];
            txt_PROD_NAME.Text = list[4];
            txt_PROD_TYPE.Text = list[5];
            txt_PROD_UNIT.Text = list[6];
            txt_PROD_SIZE.Text = list[7];
            txt_PROD_THICK.Text = list[8];
            txt_PROD_WIDTH.Text = list[9];
            txt_PROD_LENGTH.Text = list[10];
            txt_PROD_HYRACH.Text = list[11];
            txt_WEIGHT_UNIT.Text = list[12];
            txt_BASE_QTY.Text = list[13];
            txt_TOT_WEIGHT.Text = list[14];
            txt_PI_MEMO.Text = list[15];
            txt_MAT_TYPE.Text = list[16];
            txt_MAT_GROUP.Text = list[17];
            txt_BATCH_GUBUN.Text = list[18];
            txt_S_LOCATION.Text = list[19];
            txt_DEL_FLAG.Text = list[20];
            txt_CHECK_FLAG.Text = list[21];
            txt_MULU_CODE.Text = list[22];
            txt_INSERT_DATE.Text = list[23];
            txt_INSERT_USER.Text = list[24];
            txt_UPDATE_DATE.Text = list[25];
            txt_UPDATE_USER.Text = list[26];
            txt_IPS_YN.Text = list[27];
            txt_PLT_QTY.Text = list[28];
            txt_PROC_MSG.Text = list[29];
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add(txt_PROD_CODE.Text);
            list.Add(txt_PLANT_CODE.Text);
            list.Add(txt_MRP_MGR.Text);
            list.Add(txt_PROD_NAME.Text);
            list.Add(txt_PROD_TYPE.Text);
            list.Add(txt_PROD_UNIT.Text);
            list.Add(txt_PROD_SIZE.Text);
            list.Add(txt_PROD_THICK.Text);
            list.Add(txt_PROD_WIDTH.Text);
            list.Add(txt_PROD_LENGTH.Text);
            list.Add(txt_PROD_HYRACH.Text);
            list.Add(txt_WEIGHT_UNIT.Text);
            list.Add(txt_BASE_QTY.Text);
            list.Add(txt_TOT_WEIGHT.Text);
            list.Add(txt_PI_MEMO.Text);
            list.Add(txt_MAT_TYPE.Text);
            list.Add(txt_MAT_GROUP.Text);
            list.Add(txt_BATCH_GUBUN.Text);
            list.Add(txt_S_LOCATION.Text);
            list.Add(txt_DEL_FLAG.Text);
            list.Add(txt_CHECK_FLAG.Text);
            list.Add(txt_MULU_CODE.Text);
            list.Add(txt_INSERT_DATE.Text);
            list.Add(txt_INSERT_USER.Text);
            list.Add(txt_UPDATE_DATE.Text);
            list.Add(txt_UPDATE_USER.Text);
            list.Add(txt_IPS_YN.Text);
            list.Add(txt_PLT_QTY.Text);
            list.Add(txt_PROC_MSG.Text);
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
