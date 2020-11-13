using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Timers;
using System.Threading;

namespace FinalProject_Profile
{
    public partial class Inspection : MetroForm
    {
        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";

        public Inspection()
        {
            InitializeComponent();
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

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            InspectionDTL child6 = new InspectionDTL();
            child6.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Child5_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        public void FillGrid()  // Filling data 
        {
            string ct2;
            OracleConnection connection = null;
            try
            {
                ct2 = "SELECT A.PROD_CODE PROD_CODE" + Environment.NewLine;
                ct2 += ", B.PROD_NAME PROD_NAME, " +
                    "A.PROD_UNIT PROD_UNIT, " +
                    "A.ORDER_M ORDER_M, " +
                    "A.JOB_NO JOB_NO, " +
                    "A.PROC_STATUS PROC_STATUS, " +
                    "A.ORDER_NO||'-'||A.ORDER_SEQ " +
                    "ORDER_NO, C.ROLL_NO ROLL_NO, " +
                    "C.S_SEQ  S_SEQ, C.SHIFT_CODE  SHIFT_CODE" +
                    ", C.GOOD_QTY + C.BAD_QTY  TUIP_QTY, " +
                    "C.GOOD_QTY GOOD_QTY , C.BAD_QTY BAD_QTY, " +
                    "TO_CHAR(C.START_TIME,'HH24:MI') SDATE," +
                    "TO_CHAR(C.END_TIME,'HH24:MI') EDATE ," +
                    "C.CONFIRM_FLAG CONFIRM_FLAG, " +
                    "D.OKBAD_QTY OKBAD_QTY, " +
                    "C.ETC_QTY CUTPCS, " +
                    "C.EXT1_QTY PCSBOX, " +
                    "C.EXT2_QTY BOXPLT, " +
                    "C.DEL_FLAG DEL_FLAG  " +
                    // From TBL
                    "FROM TBL_ProductPlan A," + 
                    "TBL_ProductMaster B, " +
                    "TBL_PRODRSLT C," +
                    "(SELECT ROLL_NO, S_SEQ, SUM(STD_QTY) OKBAD_QTY " +
                    "FROM TBL_WCDEFECT " +
                    // Where
                    "WHERE (ROLL_NO, S_SEQ) IN (SELECT ROLL_NO, S_SEQ FROM TBL_PRODRSLT WHERE PROD_DATE= :IN_DATE) " + 
                    "AND FACTOR_CODE <>'XXX' AND DEL_FLAG = 'A' GROUP BY ROLL_NO, S_SEQ) D " +
                    "WHERE A.JOB_NO=C.JOB_NO AND A.PROD_CODE = B.PROD_CODE AND (C.ROLL_NO = D.ROLL_NO(+) AND C.S_SEQ = D.S_SEQ(+))" +
                    "AND C.PROD_DATE = :IN_DATE AND A.PLANT_CODE = '2020' " +
                    "AND A.DEL_FLAG = 'A' ORDER BY C.START_TIME";

                connection = new OracleConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();

                OracleCommand cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = ct2
                };

                cmd.Parameters.Add("IN_DATE", dateTimePicker2.Value.ToString("yyyyMMdd"));

                OracleDataReader reader = cmd.ExecuteReader();

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
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

        private void Confirmation1_button_Click(object sender, EventArgs e) // 1차 확정 버튼
        {
            OracleConnection connection = null;
            try
            {
                int rowIndex = dataGridView1.CurrentRow.Index;  // 현재 선택된 Row 
                connection = new OracleConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();

                OracleCommand cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = "update TBL_PRODRSLT set CONFIRM_FLAG = 'Y' where ROLL_NO = :IN_ROLL_NO"
                };
                cmd.Parameters.Add("IN_ROLL_NO", dataGridView1.Rows[rowIndex].Cells[7].Value.ToString());
                cmd.ExecuteNonQuery();
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}

