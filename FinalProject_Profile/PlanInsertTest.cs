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
    public partial class PlanInsertTest : MetroForm
    {
        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";
        public PlanInsertTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectItem();
        }
        public Dictionary<string, string> SelectItem()
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
                    CommandText = "SELECT TBL_SAPORDER.PLANT_CODE, TBL_SAPORDER.ORDER_NO, TBL_SAPORDER.ORDER_SEQ, TBL_SAPORDER.PROD_CODE, TBL_SAPORDER.PROD_UNIT, TBL_SAPORDER.WC_CODE, TBL_SAPORDER.ORDER_QTY, TBL_SAPORDER.MRP_MGR, TBL_SAPORDER.CUST_NAME, TBL_SAPORDER.DISTRB_CHL AS GUBUN, TBL_SAPORDER.REMARK FROM TBL_SAPORDER , TBL_WORKCENTER WHERE TBL_SAPORDER.PLANT_CODE = TBL_WORKCENTER.PLANT_CODE AND TBL_SAPORDER.WC_CODE = TBL_WORKCENTER.WC_CODE AND TBL_SAPORDER.PLANT_CODE = :ARG_PLANT AND ( TBL_SAPORDER.MRP_MGR  = :ARG_MRP1 OR TBL_SAPORDER.MRP_MGR  = :ARG_MRP2 ) AND TBL_SAPORDER.WC_CODE LIKE :ARG_WC AND TBL_SAPORDER.COMPLETE_FLAG = 'N' AND TBL_SAPORDER.ORDER_QTY - TBL_SAPORDER.PLAN_QTY > 0 AND TBL_SAPORDER.ORDER_DATE BETWEEN :ARG_O_DATE AND :ARG_E_DATE ORDER BY TBL_WORKCENTER.GONGBU_DIV, TBL_SAPORDER.WC_CODE, TBL_SAPORDER.PROD_CODE"
                };
                

                cmd.Parameters.Add("ARG_PLANT", "2020");
                cmd.Parameters.Add("ARG_MRP1", "F63");
                cmd.Parameters.Add("ARG_MRP2", "F63");
                cmd.Parameters.Add("ARG_WC", "AT02");
                //todo 날짜
                cmd.Parameters.Add("ARG_O_DATE", "20201010");
                cmd.Parameters.Add("ARG_E_DATE", "20201129");


                OracleDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> dic = new Dictionary<string, string>();

                /*int i_cnt = 0;
                
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(++i_cnt, reader["PLANT_CODE"], reader["ORDER_NO"], reader["ORDER_SEQ"], reader["PROD_CODE"], reader["PROD_UNIT"], reader["WC_CODE"], reader["ORDER_QTY"], reader["MRP_MGR"], reader["CUST_NAME"], reader["GUBUN"], reader["REMARK"]);
                    dic = new Dictionary<string, string>
                    {
                    {"PLANT_CODE", reader["PLANT_CODE"].ToString()},
                    {"ORDER_NO", reader["ORDER_NO"].ToString()},
                    {"ORDER_SEQ", reader["ORDER_SEQ"].ToString()},
                    {"PROD_CODE", reader["PROD_CODE"].ToString()},
                    {"PROD_UNIT", reader["PROD_UNIT"].ToString()},
                    {"WC_CODE", reader["WC_CODE"].ToString()},
                    {"ORDER_QTY", reader["ORDER_QTY"].ToString()},
                    {"MRP_MGR", reader["MRP_MGR"].ToString()},
                    {"CUST_NAME", reader["CUST_NAME"].ToString()},
                    {"GUBUN", reader["GUBUN"].ToString()},
                    {"REMARK", reader["REMARK"].ToString()},
                    };
                }*/

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                for(int i = 0; i < dt.Columns.Count; i++)
                {
                    dic.Add(dt.Columns[i].ColumnName, dt.Rows[0][i].ToString());
                }

                return dic;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                connection.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dic = SelectItem();
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
                    CommandText = "INSERT INTO TBL_PRODUCTPLAN ( JOB_NO, PROD_CODE, SA_SABUN, PLANT_CODE, MRP_MGR, ORDER_NO, ORDER_SEQ, ORDER_M, WC_CODE, PROD_UNIT, ADD_GOOD_QTY, START_DATE, END_DATE, JOB_DATE, NOTE_FLAG, NOTE0, WORK_GUBUN, GUBUN, DEL_FLAG, PROC_STATUS, ROLL_METER, SAP_IPGO_QTY, INSERT_DATE, CUST_NAME) VALUES ( :LS_JOB_NO, :LS_PROD_CODE, :LS_SA_SABUN, :LS_PLANT_CODE, :LS_MRP_MGR, :LS_ORDER_NO, :LS_ORDER_SEQ, :LDC_JOB_QTY_MODI, :LS_WC_CODE, :LS_PROD_UNIT, 0, :LDT_START_DATE, :LDT_END_DATE, :LS_JOB_DATE, :LS_NOTE_FLAG, :LS_NOTE0, :LS_WORK_GUBUN, :LS_GUBUN, 'A', 'N', 0, 0, :LDT_INSERT_DATE, :LS_CUSTNAME)"
                };


                cmd.Parameters.Add("LS_JOB_NO", dic["WC_CODE"].ToString() + DateTime.Now.ToString("yyyyMMdd") + "001");
                cmd.Parameters.Add("LS_PROD_CODE", dic["PROD_CODE"].ToString());
                cmd.Parameters.Add("LS_SA_SABUN", "DBA");
                cmd.Parameters.Add("LS_PLANT_CODE", dic["PLANT_CODE"].ToString());
                cmd.Parameters.Add("LS_MRP_MGR", dic["MRP_MGR"].ToString());
                cmd.Parameters.Add("LS_ORDER_NO", dic["ORDER_NO"].ToString());
                cmd.Parameters.Add("LS_ORDER_SEQ", dic["ORDER_SEQ"].ToString());
                cmd.Parameters.Add("LDC_JOB_QTY_MODI", dic["ORDER_QTY"].ToString());
                cmd.Parameters.Add("LS_WC_CODE", dic["WC_CODE"].ToString());
                cmd.Parameters.Add("LS_PROD_UNIT", dic["PROD_UNIT"].ToString());
                cmd.Parameters.Add("LDT_START_DATE", DateTime.Now);
                cmd.Parameters.Add("LDT_END_DATE", DateTime.Now);
                cmd.Parameters.Add("LS_JOB_DATE", DateTime.Now.ToString("yyyyMMdd"));
                cmd.Parameters.Add("LS_NOTE_FLAG", "n");
                cmd.Parameters.Add("LS_NOTE0", dic["REMARK"].ToString());
                cmd.Parameters.Add("LS_WORK_GUBUN", "A");
                cmd.Parameters.Add("LS_GUBUN", dic["GUBUN"].ToString());
                cmd.Parameters.Add("LDT_INSERT_DATE", DateTime.Now);
                cmd.Parameters.Add("LS_ORDER_NO", dic["CUST_NAME"].ToString());

                cmd.ExecuteNonQuery();

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
