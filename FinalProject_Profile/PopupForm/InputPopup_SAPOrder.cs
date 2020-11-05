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

namespace FinalProject_Profile.PopupForm
{
    public partial class InputPopup_SAPOrder : MetroForm
    {
        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";

        public InputPopup_SAPOrder()
        {
            InitializeComponent();
        }

        /*
        public InputPopup_SAPOrder(List<string> list)
        {
            InitializeComponent();
            txt_PLANT_CODE.Text = list[1];
            txt_MRP_MGR.Text = list[2];
            txt_ORDER_NO.Text = list[3];
            txt_ORDER_SEQ.Text = list[4];
            txt_ORDER_DATE.Text = list[5];
            txt_PROD_CODE.Text = list[6];
            txt_PROD_UNIT.Text = list[7];
            txt_P_VERSION.Text = list[8];
            txt_WC_CODE.Text = list[9];
            txt_DUE_DATE_A.Text = list[10];
            txt_DUE_DATE_B.Text = list[11];
            txt_ORDER_QTY.Text = list[12];
            txt_ROLL_METER.Text = list[13];
            txt_ORDER_UNIT_PRICE.Text = list[14];
            txt_S_LOCATION.Text = list[15];
            txt_EXCHG_RATE.Text = list[16];
            txt_CURRENCY_UNIT.Text = list[17];
            txt_PROD_TYPE.Text = list[18];
            txt_CUST_CODE.Text = list[19];
            txt_CUST_NAME.Text = list[20];
            txt_DISTRB_CHL.Text = list[21];
            txt_ORDER_TYPE.Text = list[22];
            txt_CONFIRM_FLAG.Text = list[23];
            txt_REMARK.Text = list[24];
            txt_COMPLETE_FLAG.Text = list[25];
            txt_PLAN_QTY.Text = list[26];
            txt_INPUT_QTY.Text = list[27];
            txt_WORK_TIME.Text = list[28];
            txt_INSERT_DATE.Text = list[29];
        }
        */

        private void btn_Save_Click(object sender, EventArgs e)
        {
            OracleConnection connection = null;
            try
            {
                connection = new OracleConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();

                OracleCommand cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = "insert into tbl_saporder values(:IN_PLANT_CODE, :IN_MRP_MGR, :IN_ORDER_NO, :IN_ORDER_SEQ, :IN_ORDER_DATE, :IN_PROD_CODE, :IN_PROD_UNIT, :IN_P_VERSION, :IN_WC_CODE, :IN_DUE_DATE_A, :IN_DUE_DATE_B, :IN_ORDER_QTY, :IN_ROLL_METER, :IN_ORDER_UNIT_PRICE, :IN_S_LOCATION, :IN_EXCHG_RATE, :IN_CURRENCY_UNIT, :IN_PROD_TYPE, :IN_CUST_CODE, :IN_CUST_NAME, :IN_DISTRB_CHL, :IN_ORDER_TYPE, :IN_CONFIRM_FLAG, :IN_REMARK, :IN_COMPLETE_FLAG, :IN_PLAN_QTY, :IN_INPUT_QTY, :IN_WORK_TIME, :IN_INSERT_DATE)",
                    BindByName =true
                };

                cmd.Parameters.Add("IN_PLANT_CODE", txt_PLANT_CODE.Text);
                cmd.Parameters.Add("IN_MRP_MGR", txt_MRP_MGR.Text);
                cmd.Parameters.Add("IN_ORDER_NO", txt_ORDER_NO.Text);
                cmd.Parameters.Add("IN_ORDER_SEQ", txt_ORDER_SEQ.Text);
                cmd.Parameters.Add("IN_ORDER_DATE", txt_ORDER_DATE.Text);
                cmd.Parameters.Add("IN_PROD_CODE", txt_PROD_CODE.Text);
                cmd.Parameters.Add("IN_PROD_UNIT", txt_PROD_UNIT.Text);
                cmd.Parameters.Add("IN_P_VERSION", txt_P_VERSION.Text);
                cmd.Parameters.Add("IN_WC_CODE", txt_WC_CODE.Text);
                cmd.Parameters.Add("IN_DUE_DATE_A", txt_DUE_DATE_A.Text);
                cmd.Parameters.Add("IN_DUE_DATE_B", txt_DUE_DATE_B.Text);
                cmd.Parameters.Add("IN_ORDER_QTY", txt_ORDER_QTY.Text);
                cmd.Parameters.Add("IN_ROLL_METER", txt_ROLL_METER.Text);
                cmd.Parameters.Add("IN_ORDER_UNIT_PRICE", txt_ORDER_UNIT_PRICE.Text);
                cmd.Parameters.Add("IN_S_LOCATION", txt_S_LOCATION.Text);
                cmd.Parameters.Add("IN_EXCHG_RATE", txt_EXCHG_RATE.Text);
                cmd.Parameters.Add("IN_CURRENCY_UNIT", txt_CURRENCY_UNIT.Text);
                cmd.Parameters.Add("IN_PROD_TYPE", txt_PROD_TYPE.Text);
                cmd.Parameters.Add("IN_CUST_CODE", txt_CUST_CODE.Text);
                cmd.Parameters.Add("IN_CUST_NAME", txt_CUST_NAME.Text);
                cmd.Parameters.Add("IN_DISTRB_CHL", txt_DISTRB_CHL.Text);
                cmd.Parameters.Add("IN_ORDER_TYPE", txt_ORDER_TYPE.Text);
                cmd.Parameters.Add("IN_CONFIRM_FLAG", txt_CONFIRM_FLAG.Text);
                cmd.Parameters.Add("IN_REMARK", txt_REMARK.Text);
                cmd.Parameters.Add("IN_COMPLETE_FLAG", txt_COMPLETE_FLAG.Text);
                cmd.Parameters.Add("IN_PLAN_QTY", txt_PLAN_QTY.Text);
                cmd.Parameters.Add("IN_INPUT_QTY", txt_INPUT_QTY.Text);
                cmd.Parameters.Add("IN_WORK_TIME", txt_WORK_TIME.Text);
                //cmd.Parameters.Add("IN_INSERT_DATE", DateTime.Now);
                
                cmd.ExecuteNonQuery();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            
        }

        private void btn_Save_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Save.BackgroundImage = FinalProject_Profile.Properties.Resources.저장;
        }

        private void btn_Save_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Save.BackgroundImage = FinalProject_Profile.Properties.Resources.저장클릭;
        }

        private void btn_Close_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Close.BackgroundImage = FinalProject_Profile.Properties.Resources.닫기;
        }

        private void btn_Close_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Close.BackgroundImage = FinalProject_Profile.Properties.Resources.닫기클릭;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
