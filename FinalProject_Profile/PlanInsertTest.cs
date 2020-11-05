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
        public DataTable SelectItem()
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
                    CommandText = "SELECT trim(TBL_SAPORDER.PLANT_CODE) PLANT_CODE, trim(TBL_SAPORDER.ORDER_NO) ORDER_NO, trim(TBL_SAPORDER.ORDER_SEQ) ORDER_SEQ, trim(TBL_SAPORDER.PROD_CODE) PROD_CODE, trim(TBL_SAPORDER.PROD_UNIT) PROD_UNIT, trim(TBL_SAPORDER.WC_CODE) WC_CODE, TBL_SAPORDER.ORDER_QTY, trim(TBL_SAPORDER.MRP_MGR) MRP_MGR, trim(TBL_SAPORDER.CUST_NAME) CUST_NAME, trim(TBL_SAPORDER.DISTRB_CHL) AS GUBUN, TBL_SAPORDER.REMARK FROM TBL_SAPORDER , TBL_WORKCENTER WHERE TBL_SAPORDER.PLANT_CODE = TBL_WORKCENTER.PLANT_CODE AND TBL_SAPORDER.WC_CODE = TBL_WORKCENTER.WC_CODE AND TBL_SAPORDER.PLANT_CODE = :ARG_PLANT AND ( TBL_SAPORDER.MRP_MGR  = :ARG_MRP1 OR TBL_SAPORDER.MRP_MGR  = :ARG_MRP2 ) AND TBL_SAPORDER.WC_CODE LIKE :ARG_WC AND TBL_SAPORDER.COMPLETE_FLAG = 'N' AND TBL_SAPORDER.ORDER_QTY - TBL_SAPORDER.PLAN_QTY > 0 AND TBL_SAPORDER.ORDER_DATE BETWEEN :ARG_O_DATE AND :ARG_E_DATE ORDER BY TBL_WORKCENTER.GONGBU_DIV, TBL_SAPORDER.WC_CODE, TBL_SAPORDER.PROD_CODE"
                };
                

                cmd.Parameters.Add("ARG_PLANT", "2020");
                cmd.Parameters.Add("ARG_MRP1", "F63");
                cmd.Parameters.Add("ARG_MRP2", "F63");
                cmd.Parameters.Add("ARG_WC", "AT02");
                //todo 날짜
                cmd.Parameters.Add("ARG_O_DATE", "20201105");
                cmd.Parameters.Add("ARG_E_DATE", "20201105");


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
                if(dataGridView1.DataSource == null)
                {
                    dataGridView1.DataSource = dt;
                }
                return dt;

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
            DataTable dt = SelectItem();
            OracleConnection connection = null;
            int rowCount = dt.Rows.Count;
            try
            {
                connection = new OracleConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();

                for(int i = 0; i < rowCount; i++)
                {
                    OracleCommand cmd = new OracleCommand
                    {
                        CommandType = CommandType.Text,
                        Connection = connection,
                        CommandText = "INSERT INTO TBL_PRODUCTPLAN ( JOB_NO, PROD_CODE, SA_SABUN, PLANT_CODE, MRP_MGR, ORDER_NO, ORDER_SEQ, ORDER_M, WC_CODE, PROD_UNIT, ADD_GOOD_QTY, START_DATE, END_DATE, JOB_DATE, NOTE_FLAG, NOTE0, WORK_GUBUN, GUBUN, DEL_FLAG, PROC_STATUS, ROLL_METER, SAP_IPGO_QTY, INSERT_DATE, CUST_NAME) VALUES ( :LS_JOB_NO, :LS_PROD_CODE, :LS_SA_SABUN, :LS_PLANT_CODE, :LS_MRP_MGR, :LS_ORDER_NO, :LS_ORDER_SEQ, :LDC_JOB_QTY_MODI, :LS_WC_CODE, :LS_PROD_UNIT, 0, :LDT_START_DATE, :LDT_END_DATE, :LS_JOB_DATE, :LS_NOTE_FLAG, :LS_NOTE0, :LS_WORK_GUBUN, :LS_GUBUN, 'A', 'N', 0, 0, :LDT_INSERT_DATE, :LS_CUSTNAME)"
                    };
                    
                    cmd.Parameters.Add("LS_JOB_NO", dt.Rows[i]["WC_CODE"].ToString() + DateTime.Now.ToString("yyyyMMdd") + (i+1).ToString("000"));
                    cmd.Parameters.Add("LS_PROD_CODE", dt.Rows[i]["PROD_CODE"].ToString());
                    cmd.Parameters.Add("LS_SA_SABUN", "DBA");
                    cmd.Parameters.Add("LS_PLANT_CODE", dt.Rows[i]["PLANT_CODE"].ToString());
                    cmd.Parameters.Add("LS_MRP_MGR", dt.Rows[i]["MRP_MGR"].ToString());
                    cmd.Parameters.Add("LS_ORDER_NO", dt.Rows[i]["ORDER_NO"].ToString());
                    cmd.Parameters.Add("LS_ORDER_SEQ", dt.Rows[i]["ORDER_SEQ"].ToString());
                    cmd.Parameters.Add("LDC_JOB_QTY_MODI", dt.Rows[i]["ORDER_QTY"].ToString());
                    cmd.Parameters.Add("LS_WC_CODE", dt.Rows[i]["WC_CODE"].ToString());
                    cmd.Parameters.Add("LS_PROD_UNIT", dt.Rows[i]["PROD_UNIT"].ToString());
                    cmd.Parameters.Add("LDT_START_DATE", DateTime.Now);
                    cmd.Parameters.Add("LDT_END_DATE", DateTime.Now);
                    cmd.Parameters.Add("LS_JOB_DATE", DateTime.Now.ToString("yyyyMMdd"));
                    cmd.Parameters.Add("LS_NOTE_FLAG", "n");
                    cmd.Parameters.Add("LS_NOTE0", dt.Rows[i]["REMARK"].ToString());
                    cmd.Parameters.Add("LS_WORK_GUBUN", "A");
                    cmd.Parameters.Add("LS_GUBUN", dt.Rows[i]["GUBUN"].ToString());
                    cmd.Parameters.Add("LDT_INSERT_DATE", DateTime.Now);
                    cmd.Parameters.Add("LS_ORDER_NO", dt.Rows[i]["CUST_NAME"].ToString());

                    cmd.ExecuteNonQuery();
                }

                

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

        private void button3_Click(object sender, EventArgs e)
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
                    CommandText = "Select * From TBL_PRODUCTPLAN"
                };

                OracleDataReader reader = cmd.ExecuteReader();

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView2.DataSource = dt;

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

        private void button4_Click(object sender, EventArgs e)
        {
            OracleConnection connection = null;
            string in_Order_No = "0";
            try
            {
                int rowIndex = dataGridView1.CurrentRow.Index;
                in_Order_No = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                connection = new OracleConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();

                OracleCommand cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = "Update tbl_productplan set PROC_STATUS = 'Y' where ORDER_NO = :IN_ORDER_NO"
                };
                if(in_Order_No.Equals("0"))
                {
                    throw new ArgumentNullException("in_Order_No");
                }
                cmd.Parameters.Add("IN_ORDER_NO", in_Order_No.ToString());

                cmd.ExecuteNonQuery();

                in_Order_No = "0";


                MessageBox.Show("확정되었습니다.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
