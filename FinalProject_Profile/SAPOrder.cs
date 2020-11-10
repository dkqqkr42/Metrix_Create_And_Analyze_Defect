using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject_Profile.PopupForm;
using MetroFramework.Forms;
using Oracle.ManagedDataAccess.Client;

namespace FinalProject_Profile
{
    public partial class SAPOrder : MetroForm
    {
        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";
        InputPopup_SAPOrder popup;
        List<string> list = new List<string>();

        public SAPOrder()
        {
            InitializeComponent();
            cbo_TEAM.SelectedIndex = 0;                     // 콤보박스의 기본값을 0번째(첫번째)에 있는 항목으로 설정
            cbo_WORKCENTER.SelectedIndex = 0;
            cbo_ORDER_TYPE.SelectedIndex = 0;
        }

        public void FillGrid(DataSet ds)  // 데이터 조회 결과를 adapter로 받아 DataSet을 반환 받은 경우 사용되는 메서드
        {
            grd_Result.DataSource = ds.Tables[0];
        }

        public int SelectItem()
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
                    CommandText = "SELECT trim(TBL_SAPORDER.PLANT_CODE), trim(TBL_SAPORDER.ORDER_NO), trim(TBL_SAPORDER.ORDER_SEQ), trim(TBL_SAPORDER.ORDER_DATE), trim(TBL_SAPORDER.PROD_CODE), trim(TBL_SAPORDER.PROD_UNIT), trim(TBL_SAPORDER.P_VERSION), trim(TBL_SAPORDER.WC_CODE), trim(TBL_SAPORDER.DUE_DATE_A), trim(TBL_SAPORDER.DUE_DATE_B), trim(TBL_SAPORDER.ORDER_QTY), trim(TBL_SAPORDER.ROLL_METER), trim(TBL_SAPORDER.ORDER_UNIT_PRICE), trim(TBL_SAPORDER.S_LOCATION), trim(TBL_SAPORDER.EXCHG_RATE), trim(TBL_SAPORDER.CURRENCY_UNIT), trim(TBL_SAPORDER.PROD_TYPE), trim(TBL_SAPORDER.MRP_MGR), trim(TBL_SAPORDER.CUST_CODE), trim(TBL_SAPORDER.CUST_NAME), trim(TBL_SAPORDER.DISTRB_CHL), trim(TBL_SAPORDER.ORDER_TYPE), trim(TBL_SAPORDER.CONFIRM_FLAG), trim(TBL_SAPORDER.REMARK), trim(TBL_SAPORDER.PLAN_QTY), trim(TBL_SAPORDER.INPUT_QTY), trim(TBL_SAPORDER.WORK_TIME), trim(TBL_PRODUCTMASTER.PROD_NAME), trim(TBL_WORKCENTER.WC_NAME), trim(TBL_WORKCENTER.REQ_MP_MAN), trim(TBL_SAPORDER.COMPLETE_FLAG), trim(TBL_WORKCENTER.GONGBU_DIV) FROM TBL_SAPORDER, TBL_PRODUCTMASTER, TBL_WORKCENTER WHERE TBL_SAPORDER.PLANT_CODE = TBL_WORKCENTER.PLANT_CODE AND  TBL_SAPORDER.WC_CODE = TBL_WORKCENTER.WC_CODE AND  TBL_SAPORDER.MRP_MGR = 'F63' AND  TBL_SAPORDER.PROD_CODE = TBL_PRODUCTMASTER.PROD_CODE"
                };

                
                // 생산팀 콤보박스 값에 따른 조회 (코드번호를 이용하여 조회하기)
                if (cbo_TEAM.Text.Equals("전체"))
                {
                    if (cbo_WORKCENTER.Text.Equals("전체"))
                        cmd.CommandText = "SELECT trim(TBL_SAPORDER.PLANT_CODE), trim(TBL_SAPORDER.ORDER_NO), trim(TBL_SAPORDER.ORDER_SEQ), trim(TBL_SAPORDER.ORDER_DATE), trim(TBL_SAPORDER.PROD_CODE), trim(TBL_SAPORDER.PROD_UNIT), trim(TBL_SAPORDER.P_VERSION), trim(TBL_SAPORDER.WC_CODE), trim(TBL_SAPORDER.DUE_DATE_A), trim(TBL_SAPORDER.DUE_DATE_B), trim(TBL_SAPORDER.ORDER_QTY), trim(TBL_SAPORDER.ROLL_METER), trim(TBL_SAPORDER.ORDER_UNIT_PRICE), trim(TBL_SAPORDER.S_LOCATION), trim(TBL_SAPORDER.EXCHG_RATE), trim(TBL_SAPORDER.CURRENCY_UNIT), trim(TBL_SAPORDER.PROD_TYPE), trim(TBL_SAPORDER.MRP_MGR), trim(TBL_SAPORDER.CUST_CODE), trim(TBL_SAPORDER.CUST_NAME), trim(TBL_SAPORDER.DISTRB_CHL), trim(TBL_SAPORDER.ORDER_TYPE), trim(TBL_SAPORDER.CONFIRM_FLAG), trim(TBL_SAPORDER.REMARK), trim(TBL_SAPORDER.PLAN_QTY), trim(TBL_SAPORDER.INPUT_QTY), trim(TBL_SAPORDER.WORK_TIME), trim(TBL_PRODUCTMASTER.PROD_NAME), trim(TBL_WORKCENTER.WC_NAME), trim(TBL_WORKCENTER.REQ_MP_MAN), trim(TBL_SAPORDER.COMPLETE_FLAG), trim(TBL_WORKCENTER.GONGBU_DIV) FROM TBL_SAPORDER, TBL_PRODUCTMASTER, TBL_WORKCENTER WHERE TBL_SAPORDER.PLANT_CODE = TBL_WORKCENTER.PLANT_CODE AND  TBL_SAPORDER.WC_CODE = TBL_WORKCENTER.WC_CODE AND  TBL_SAPORDER.MRP_MGR = 'F63' AND  TBL_SAPORDER.PROD_CODE = TBL_PRODUCTMASTER.PROD_CODE";

                    else if (cbo_WORKCENTER.Text.Equals("1호카매트"))
                        cmd.CommandText = "SELECT trim(TBL_SAPORDER.PLANT_CODE), trim(TBL_SAPORDER.ORDER_NO), trim(TBL_SAPORDER.ORDER_SEQ), trim(TBL_SAPORDER.ORDER_DATE), trim(TBL_SAPORDER.PROD_CODE), trim(TBL_SAPORDER.PROD_UNIT), trim(TBL_SAPORDER.P_VERSION), trim(TBL_SAPORDER.WC_CODE), trim(TBL_SAPORDER.DUE_DATE_A), trim(TBL_SAPORDER.DUE_DATE_B), trim(TBL_SAPORDER.ORDER_QTY), trim(TBL_SAPORDER.ROLL_METER), trim(TBL_SAPORDER.ORDER_UNIT_PRICE), trim(TBL_SAPORDER.S_LOCATION), trim(TBL_SAPORDER.EXCHG_RATE), trim(TBL_SAPORDER.CURRENCY_UNIT), trim(TBL_SAPORDER.PROD_TYPE), trim(TBL_SAPORDER.MRP_MGR), trim(TBL_SAPORDER.CUST_CODE), trim(TBL_SAPORDER.CUST_NAME), trim(TBL_SAPORDER.DISTRB_CHL), trim(TBL_SAPORDER.ORDER_TYPE), trim(TBL_SAPORDER.CONFIRM_FLAG), trim(TBL_SAPORDER.REMARK), trim(TBL_SAPORDER.PLAN_QTY), trim(TBL_SAPORDER.INPUT_QTY), trim(TBL_SAPORDER.WORK_TIME), trim(TBL_PRODUCTMASTER.PROD_NAME), trim(TBL_WORKCENTER.WC_NAME), trim(TBL_WORKCENTER.REQ_MP_MAN), trim(TBL_SAPORDER.COMPLETE_FLAG), trim(TBL_WORKCENTER.GONGBU_DIV) FROM TBL_SAPORDER, TBL_PRODUCTMASTER, TBL_WORKCENTER WHERE TBL_SAPORDER.PLANT_CODE = TBL_WORKCENTER.PLANT_CODE AND  TBL_SAPORDER.WC_CODE = TBL_WORKCENTER.WC_CODE AND  TBL_SAPORDER.MRP_MGR = 'F63' AND  TBL_SAPORDER.PROD_CODE = TBL_PRODUCTMASTER.PROD_CODE AND TBL_WORKCENTER.WC_NAME = '1호카매트'";

                    else if (cbo_WORKCENTER.Text.Equals("2호카매트"))
                        cmd.CommandText = "SELECT trim(TBL_SAPORDER.PLANT_CODE), trim(TBL_SAPORDER.ORDER_NO), trim(TBL_SAPORDER.ORDER_SEQ), trim(TBL_SAPORDER.ORDER_DATE), trim(TBL_SAPORDER.PROD_CODE), trim(TBL_SAPORDER.PROD_UNIT), trim(TBL_SAPORDER.P_VERSION), trim(TBL_SAPORDER.WC_CODE), trim(TBL_SAPORDER.DUE_DATE_A), trim(TBL_SAPORDER.DUE_DATE_B), trim(TBL_SAPORDER.ORDER_QTY), trim(TBL_SAPORDER.ROLL_METER), trim(TBL_SAPORDER.ORDER_UNIT_PRICE), trim(TBL_SAPORDER.S_LOCATION), trim(TBL_SAPORDER.EXCHG_RATE), trim(TBL_SAPORDER.CURRENCY_UNIT), trim(TBL_SAPORDER.PROD_TYPE), trim(TBL_SAPORDER.MRP_MGR), trim(TBL_SAPORDER.CUST_CODE), trim(TBL_SAPORDER.CUST_NAME), trim(TBL_SAPORDER.DISTRB_CHL), trim(TBL_SAPORDER.ORDER_TYPE), trim(TBL_SAPORDER.CONFIRM_FLAG), trim(TBL_SAPORDER.REMARK), trim(TBL_SAPORDER.PLAN_QTY), trim(TBL_SAPORDER.INPUT_QTY), trim(TBL_SAPORDER.WORK_TIME), trim(TBL_PRODUCTMASTER.PROD_NAME), trim(TBL_WORKCENTER.WC_NAME), trim(TBL_WORKCENTER.REQ_MP_MAN), trim(TBL_SAPORDER.COMPLETE_FLAG), trim(TBL_WORKCENTER.GONGBU_DIV) FROM TBL_SAPORDER, TBL_PRODUCTMASTER, TBL_WORKCENTER WHERE TBL_SAPORDER.PLANT_CODE = TBL_WORKCENTER.PLANT_CODE AND  TBL_SAPORDER.WC_CODE = TBL_WORKCENTER.WC_CODE AND  TBL_SAPORDER.MRP_MGR = 'F63' AND  TBL_SAPORDER.PROD_CODE = TBL_PRODUCTMASTER.PROD_CODE AND TBL_WORKCENTER.WC_NAME = '2호카매트'";
                }

                else if (cbo_TEAM.Text.Equals("카매트생산팀"))
                {
                    if (cbo_WORKCENTER.Text.Equals("전체"))
                        cmd.CommandText = "SELECT trim(TBL_SAPORDER.PLANT_CODE), trim(TBL_SAPORDER.ORDER_NO), trim(TBL_SAPORDER.ORDER_SEQ), trim(TBL_SAPORDER.ORDER_DATE), trim(TBL_SAPORDER.PROD_CODE), trim(TBL_SAPORDER.PROD_UNIT), trim(TBL_SAPORDER.P_VERSION), trim(TBL_SAPORDER.WC_CODE), trim(TBL_SAPORDER.DUE_DATE_A), trim(TBL_SAPORDER.DUE_DATE_B), trim(TBL_SAPORDER.ORDER_QTY), trim(TBL_SAPORDER.ROLL_METER), trim(TBL_SAPORDER.ORDER_UNIT_PRICE), trim(TBL_SAPORDER.S_LOCATION), trim(TBL_SAPORDER.EXCHG_RATE), trim(TBL_SAPORDER.CURRENCY_UNIT), trim(TBL_SAPORDER.PROD_TYPE), trim(TBL_SAPORDER.MRP_MGR), trim(TBL_SAPORDER.CUST_CODE), trim(TBL_SAPORDER.CUST_NAME), trim(TBL_SAPORDER.DISTRB_CHL), trim(TBL_SAPORDER.ORDER_TYPE), trim(TBL_SAPORDER.CONFIRM_FLAG), trim(TBL_SAPORDER.REMARK), trim(TBL_SAPORDER.PLAN_QTY), trim(TBL_SAPORDER.INPUT_QTY), trim(TBL_SAPORDER.WORK_TIME), trim(TBL_PRODUCTMASTER.PROD_NAME), trim(TBL_WORKCENTER.WC_NAME), trim(TBL_WORKCENTER.REQ_MP_MAN), trim(TBL_SAPORDER.COMPLETE_FLAG), trim(TBL_WORKCENTER.GONGBU_DIV) FROM TBL_SAPORDER, TBL_PRODUCTMASTER, TBL_WORKCENTER WHERE TBL_SAPORDER.PLANT_CODE = TBL_WORKCENTER.PLANT_CODE AND  TBL_SAPORDER.WC_CODE = TBL_WORKCENTER.WC_CODE AND  TBL_SAPORDER.MRP_MGR = 'F63' AND  TBL_SAPORDER.PROD_CODE = TBL_PRODUCTMASTER.PROD_CODE";

                    else if (cbo_WORKCENTER.Text.Equals("1호카매트"))
                        cmd.CommandText = "SELECT trim(TBL_SAPORDER.PLANT_CODE), trim(TBL_SAPORDER.ORDER_NO), trim(TBL_SAPORDER.ORDER_SEQ), trim(TBL_SAPORDER.ORDER_DATE), trim(TBL_SAPORDER.PROD_CODE), trim(TBL_SAPORDER.PROD_UNIT), trim(TBL_SAPORDER.P_VERSION), trim(TBL_SAPORDER.WC_CODE), trim(TBL_SAPORDER.DUE_DATE_A), trim(TBL_SAPORDER.DUE_DATE_B), trim(TBL_SAPORDER.ORDER_QTY), trim(TBL_SAPORDER.ROLL_METER), trim(TBL_SAPORDER.ORDER_UNIT_PRICE), trim(TBL_SAPORDER.S_LOCATION), trim(TBL_SAPORDER.EXCHG_RATE), trim(TBL_SAPORDER.CURRENCY_UNIT), trim(TBL_SAPORDER.PROD_TYPE), trim(TBL_SAPORDER.MRP_MGR), trim(TBL_SAPORDER.CUST_CODE), trim(TBL_SAPORDER.CUST_NAME), trim(TBL_SAPORDER.DISTRB_CHL), trim(TBL_SAPORDER.ORDER_TYPE), trim(TBL_SAPORDER.CONFIRM_FLAG), trim(TBL_SAPORDER.REMARK), trim(TBL_SAPORDER.PLAN_QTY), trim(TBL_SAPORDER.INPUT_QTY), trim(TBL_SAPORDER.WORK_TIME), trim(TBL_PRODUCTMASTER.PROD_NAME), trim(TBL_WORKCENTER.WC_NAME), trim(TBL_WORKCENTER.REQ_MP_MAN), trim(TBL_SAPORDER.COMPLETE_FLAG), trim(TBL_WORKCENTER.GONGBU_DIV) FROM TBL_SAPORDER, TBL_PRODUCTMASTER, TBL_WORKCENTER WHERE TBL_SAPORDER.PLANT_CODE = TBL_WORKCENTER.PLANT_CODE AND  TBL_SAPORDER.WC_CODE = TBL_WORKCENTER.WC_CODE AND  TBL_SAPORDER.MRP_MGR = 'F63' AND  TBL_SAPORDER.PROD_CODE = TBL_PRODUCTMASTER.PROD_CODE AND TBL_WORKCENTER.WC_NAME = '1호카매트'";

                    else if (cbo_WORKCENTER.Text.Equals("2호카매트"))
                        cmd.CommandText = "SELECT trim(TBL_SAPORDER.PLANT_CODE), trim(TBL_SAPORDER.ORDER_NO), trim(TBL_SAPORDER.ORDER_SEQ), trim(TBL_SAPORDER.ORDER_DATE), trim(TBL_SAPORDER.PROD_CODE), trim(TBL_SAPORDER.PROD_UNIT), trim(TBL_SAPORDER.P_VERSION), trim(TBL_SAPORDER.WC_CODE), trim(TBL_SAPORDER.DUE_DATE_A), trim(TBL_SAPORDER.DUE_DATE_B), trim(TBL_SAPORDER.ORDER_QTY), trim(TBL_SAPORDER.ROLL_METER), trim(TBL_SAPORDER.ORDER_UNIT_PRICE), trim(TBL_SAPORDER.S_LOCATION), trim(TBL_SAPORDER.EXCHG_RATE), trim(TBL_SAPORDER.CURRENCY_UNIT), trim(TBL_SAPORDER.PROD_TYPE), trim(TBL_SAPORDER.MRP_MGR), trim(TBL_SAPORDER.CUST_CODE), trim(TBL_SAPORDER.CUST_NAME), trim(TBL_SAPORDER.DISTRB_CHL), trim(TBL_SAPORDER.ORDER_TYPE), trim(TBL_SAPORDER.CONFIRM_FLAG), trim(TBL_SAPORDER.REMARK), trim(TBL_SAPORDER.PLAN_QTY), trim(TBL_SAPORDER.INPUT_QTY), trim(TBL_SAPORDER.WORK_TIME), trim(TBL_PRODUCTMASTER.PROD_NAME), trim(TBL_WORKCENTER.WC_NAME), trim(TBL_WORKCENTER.REQ_MP_MAN), trim(TBL_SAPORDER.COMPLETE_FLAG), trim(TBL_WORKCENTER.GONGBU_DIV) FROM TBL_SAPORDER, TBL_PRODUCTMASTER, TBL_WORKCENTER WHERE TBL_SAPORDER.PLANT_CODE = TBL_WORKCENTER.PLANT_CODE AND  TBL_SAPORDER.WC_CODE = TBL_WORKCENTER.WC_CODE AND  TBL_SAPORDER.MRP_MGR = 'F63' AND  TBL_SAPORDER.PROD_CODE = TBL_PRODUCTMASTER.PROD_CODE AND TBL_WORKCENTER.WC_NAME = '2호카매트'";
                }
                

                OracleDataReader reader = cmd.ExecuteReader();

                grd_Result.Rows.Clear();

                int i_cnt = 0;

                while (reader.Read())
                {
                    grd_Result.Rows.Add(++i_cnt, reader[28], reader[1], reader[3], reader[8], reader[20], reader[4], reader[27], reader[5], reader[10], reader[30]);
                }

                return i_cnt;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                connection.Close();
            }

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
            PlanInsert plantinsert = new PlanInsert();
            plantinsert.ShowDialog();
        }

        private void metroButton3_Click(object sender, EventArgs e)  // 조회버튼 누를 경우 실행
        {
            SelectItem();
        }

        private void metroButton3_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Select.BackgroundImage = FinalProject_Profile.Properties.Resources.조회;
        }

        private void metroButton3_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Select.BackgroundImage = FinalProject_Profile.Properties.Resources.조회클릭;
        }

        private void metroButton2_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Insert.BackgroundImage = FinalProject_Profile.Properties.Resources.입력;
        }

        private void metroButton2_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Insert.BackgroundImage = FinalProject_Profile.Properties.Resources.입력클릭;
        }

        private void btn_Decide_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Decide.BackgroundImage = FinalProject_Profile.Properties.Resources.확정;
        }

        private void btn_Decide_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Decide.BackgroundImage = FinalProject_Profile.Properties.Resources.확정클릭;
        }

        private void grd_Result_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)  // 그리드에서 선택된 셀의 폰트는 굵게, 선택되지 않은 셀의 폰트는 보통으로 설정
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
            grd_Result.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
            {
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            }
            else
            {
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Regular);
            }
        }
    }
}
