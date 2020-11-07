using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System.Timers;
using Oracle.ManagedDataAccess.Client;

namespace FinalProject_Profile
{
    public partial class Working : MetroForm
    {
        int box_pcs, plt_box, cut_pcs;
        string prod_code, job_no, prod_name, prod_unit, order_m, work_gbn, gubun;
        int pcs=0, box=0, plt=0;

        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";
        public Working()
        {
            InitializeComponent();
            for (int i = 0; i < 1; i++)
            {
                metroGrid1.Rows.Add("1", "1234", "2020/09/20", "2020/09/20", "내수");
            }
            metroTile6.Font = new Font(metroTile6.Font.FontFamily, 50);
        }

        private void Wokring_Load(object sender, EventArgs e)
        {
            SelectItem();
            StartTimer();
        }
        public void SelectItem()
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
                    CommandText = "SELECT A.JOB_NO JOB_NO, RESERVE_RANK, A.PLANT_CODE PLANT_CODE, A.ORDER_NO||' - '||A.ORDER_SEQ ORDER_NO, A.ORDER_M ORDER_M, A.ADD_GOOD_QTY ADD_GOOD_QTY, DECODE(A.GUBUN, 20, '내수', 40, '수출', 10, '특판') GUBUN, DECODE(A.WORK_GUBUN, 'A', '정상작업', 'U', '재작업', 'R', '연구개발', 'T', '기술테스트', 'S', 'S/BOOK', 'C', 'C/MATCH') WORK_GBN, DECODE(A.NOTE_FLAG, 'Y', '★') NOTE_FLAG, A.WORK_GUBUN WORK_GUBUN, A.WC_CODE WC_CODE, trim(A.PROD_CODE) PROD_CODE, PROD_NAME, A.PROD_UNIT PROD_UNIT, A.MRP_MGR MRP_MGR, NOTE0, NOTE1, TO_CHAR(START_DATE, 'HH24:MI') SDATE, TO_CHAR(END_DATE, 'HH24:MI') EDATE FROM TBL_PRODUCTPLAN A, TBL_PRODUCTMASTER B, TBL_PRODRESERVE C WHERE A.PROD_CODE  = B.PROD_CODE AND A.WC_CODE = C.WC_CODE AND A.JOB_NO = C.JOB_NO AND A.PLANT_CODE = '2020' AND A.PROC_STATUS = 'A' AND A.DEL_FLAG = 'A' ORDER BY RESERVE_RANK"
                };


                cmd.Parameters.Add("IN_PLANT_CODE", "2020");


                OracleDataReader reader = cmd.ExecuteReader();

                reader.Read();

                prod_code = reader["PROD_CODE"].ToString();
                job_no = reader["JOB_NO"].ToString();
                prod_name = reader["PROD_NAME"].ToString();
                prod_unit = reader["PROD_UNIT"].ToString();
                order_m = reader["ORDER_M"].ToString();
                work_gbn = reader["WORK_GBN"].ToString();
                gubun = reader["GUBUN"].ToString();

                reader.Close();

                cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = "SELECT C.JUST_ROLL PCSBOX, C.JSTR_MIN  PLTBOX, C.LAY2_MIN  CUTPCS FROM TBL_PRODUCTPLAN A, TBL_WINDINGBASIC C WHERE A.PROD_CODE  = C.PROD_CODE AND (A.JOB_NO) IN (SELECT JOB_NO FROM TBL_PRODRESERVE WHERE RESERVE_RANK = 1 ) AND A.PLANT_CODE = '2020' AND C.DEL_FLAG   = 'A'"
                };

                reader = cmd.ExecuteReader();

                reader.Read();

                box_pcs = Int32.Parse(reader["PCSBOX"].ToString());
                plt_box = Int32.Parse(reader["PLTBOX"].ToString());
                cut_pcs = Int32.Parse(reader["CUTPCS"].ToString());

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

        public void StartTimer()
        {
            System.Timers.Timer timer = new System.Timers.Timer
            {
                Interval = 100,
            };
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            pcs += cut_pcs;

            if (pcs % box_pcs == 0)
            {
                box++;
                if (box % plt_box == 0)
                {
                    plt++;
                }
            }
            UpdateData();
        }
        public void UpdateData()
        {
            if (label1.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () {
                    UpdateData();
                });
            }
            else
            {
                label1.Text = pcs.ToString();
                label3.Text = box.ToString();
                label5.Text = plt.ToString();
            }

            
        }
    }
}
