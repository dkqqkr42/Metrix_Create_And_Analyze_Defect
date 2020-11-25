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
        int seq = 0;

        public InputPopup_SAPOrder()
        {
            InitializeComponent();
            cbo_PLANT_CODE.SelectedIndex = 0;
            cbo_MRP_MGR.SelectedIndex = 0;
            cbo_PROD_CODE.SelectedIndex = 0;
            cbo_PROD_UNIT.SelectedIndex = 0;
            cbo_WC_CODE.SelectedIndex = 0;
            cbo_CURRENCY_UNIT.SelectedIndex = 0;
            cbo_DISTRB_CHL.SelectedIndex = 1;
            cbo_ORDER_TYPE.SelectedIndex = 0;
            cbo_COMPLETE_FLAG.SelectedIndex = 0;
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

                cmd.Parameters.Add("IN_PLANT_CODE", cbo_PLANT_CODE.Text);
                cmd.Parameters.Add("IN_MRP_MGR", cbo_MRP_MGR.Text);
                cmd.Parameters.Add("IN_ORDER_NO", txt_ORDER_NO.Text);
                cmd.Parameters.Add("IN_ORDER_SEQ", txt_ORDER_SEQ.Text);
                cmd.Parameters.Add("IN_ORDER_DATE", dtp_ORDER_DATE.Text);
                cmd.Parameters.Add("IN_PROD_CODE", cbo_PROD_CODE.Text);
                cmd.Parameters.Add("IN_PROD_UNIT", cbo_PROD_UNIT.Text);
                cmd.Parameters.Add("IN_P_VERSION", txt_P_VERSION.Text);
                cmd.Parameters.Add("IN_WC_CODE", cbo_WC_CODE.Text);
                cmd.Parameters.Add("IN_DUE_DATE_A", dtp_DUE_DATE_A.Text);
                cmd.Parameters.Add("IN_DUE_DATE_B", dtp_DUE_DATE_B.Text);
                cmd.Parameters.Add("IN_ORDER_QTY", txt_ORDER_QTY.Text);
                cmd.Parameters.Add("IN_ROLL_METER", txt_ROLL_METER.Text);
                cmd.Parameters.Add("IN_ORDER_UNIT_PRICE", txt_ORDER_UNIT_PRICE.Text);
                cmd.Parameters.Add("IN_S_LOCATION", txt_S_LOCATION.Text);
                cmd.Parameters.Add("IN_EXCHG_RATE", txt_EXCHG_RATE.Text);
                cmd.Parameters.Add("IN_CURRENCY_UNIT", cbo_CURRENCY_UNIT.Text);
                cmd.Parameters.Add("IN_PROD_TYPE", txt_PROD_TYPE.Text);
                cmd.Parameters.Add("IN_CUST_CODE", txt_CUST_CODE.Text);
                cmd.Parameters.Add("IN_CUST_NAME", txt_CUST_NAME.Text);

                // 유통채널
                if(cbo_DISTRB_CHL.Text == "특판")
                    cmd.Parameters.Add("IN_DISTRB_CHL", "10");
                else if(cbo_DISTRB_CHL.Text == "내수")
                    cmd.Parameters.Add("IN_DISTRB_CHL", "20");
                else if(cbo_DISTRB_CHL.Text == "수출")
                    cmd.Parameters.Add("IN_DISTRB_CHL", "40");

                // 주문구분
                if(cbo_ORDER_TYPE.Text == "계획")
                    cmd.Parameters.Add("IN_ORDER_TYPE", "P");
                else if(cbo_ORDER_TYPE.Text == "주문")
                    cmd.Parameters.Add("IN_ORDER_TYPE", "S");

                cmd.Parameters.Add("IN_CONFIRM_FLAG", txt_CONFIRM_FLAG.Text.Equals("")? "N" : txt_CONFIRM_FLAG.Text);
                cmd.Parameters.Add("IN_REMARK", txt_REMARK.Text);

                // 완료여부
                if(cbo_COMPLETE_FLAG.Text == "생산가능")
                    cmd.Parameters.Add("IN_COMPLETE_FLAG", "N");
                else if(cbo_COMPLETE_FLAG.Text == "주문취소")
                    cmd.Parameters.Add("IN_COMPLETE_FLAG", "Y");
                else if (cbo_COMPLETE_FLAG.Text == "생산완료")
                    cmd.Parameters.Add("IN_COMPLETE_FLAG", "C");

                cmd.Parameters.Add("IN_PLAN_QTY", txt_PLAN_QTY.Text);
                cmd.Parameters.Add("IN_INPUT_QTY", txt_INPUT_QTY.Text);
                cmd.Parameters.Add("IN_WORK_TIME", txt_WORK_TIME.Text);
                cmd.Parameters.Add("IN_INSERT_DATE", DateTime.Now);
                
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
            btn_Save.BackgroundImage = FinalProject_Profile.Properties.Resources.저장1;
        }

        private void btn_Save_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Save.BackgroundImage = FinalProject_Profile.Properties.Resources.저장클릭1;
        }

        private void btn_Close_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Close.BackgroundImage = FinalProject_Profile.Properties.Resources.닫기1;
        }

        private void btn_Close_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Close.BackgroundImage = FinalProject_Profile.Properties.Resources.닫기클릭1;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputPopup_SAPOrder_Load(object sender, EventArgs e)
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
                    CommandText = "SELECT COUNT(*) FROM TBL_SAPORDER WHERE ORDER_DATE = TO_CHAR(SYSDATE,'yyyymmdd')"
                };

                seq = Int32.Parse(cmd.ExecuteScalar().ToString());

                txt_ORDER_NO.Text = DateTime.Now.ToString("yyyyMMdd") + seq.ToString("00");

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
    }
}
