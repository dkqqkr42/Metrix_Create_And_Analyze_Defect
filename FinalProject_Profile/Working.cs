using MetroFramework.Forms;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace FinalProject_Profile
{
    public partial class Working : MetroForm
    {
        int box_pcs, plt_box, cut_pcs;
        string prod_code, order_no, job_no, prod_name, prod_unit, order_m, work_gbn, gubun;
        int pcs = 0, box = 0, plt = 0;

        private void btn_InspectionStart_Click(object sender, EventArgs e)
        {
            StartTimer();
        }

        private void Working2_Load(object sender, EventArgs e)
        {
            SelectItem();
        }

        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";
        public Working()
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

        private void btn_InspectionStart_MouseUp(object sender, MouseEventArgs e)
        {
            btn_InspectionStart.BackgroundImage = FinalProject_Profile.Properties.Resources.검사시작;
        }

        private void btn_InspectionStart_MouseDown(object sender, MouseEventArgs e)
        {
            btn_InspectionStart.BackgroundImage = FinalProject_Profile.Properties.Resources.검사시작클릭;
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

                //RESERVE RANK의 우선순위가 가장 높은 작업의 데이터를 가져오는 쿼리
                OracleCommand cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = "SELECT * FROM (select A.JOB_NO JOB_NO, RESERVE_RANK, A.PLANT_CODE PLANT_CODE, trim(A.ORDER_NO||' - '||A.ORDER_SEQ) ORDER_NO, A.ORDER_M ORDER_M, A.ADD_GOOD_QTY ADD_GOOD_QTY, DECODE(A.GUBUN, 20, '내수', 40, '수출', 10, '특판') GUBUN, DECODE(A.WORK_GUBUN, 'A', '정상작업', 'U', '재작업', 'R', '연구개발', 'T', '기술테스트', 'S', 'S/BOOK', 'C', 'C/MATCH') WORK_GBN, DECODE(A.NOTE_FLAG, 'Y', '★') NOTE_FLAG, A.WORK_GUBUN WORK_GUBUN, A.WC_CODE WC_CODE, trim(A.PROD_CODE) PROD_CODE, PROD_NAME, A.PROD_UNIT PROD_UNIT, A.MRP_MGR MRP_MGR, NOTE0, NOTE1, TO_CHAR(START_DATE, 'HH24:MI') SDATE, TO_CHAR(END_DATE, 'HH24:MI') EDATE FROM TBL_PRODUCTPLAN A, TBL_PRODUCTMASTER B, TBL_PRODRESERVE C WHERE A.PROD_CODE  = B.PROD_CODE AND A.WC_CODE = C.WC_CODE AND A.JOB_NO = C.JOB_NO AND A.PLANT_CODE = '2020' AND A.PROC_STATUS = 'A' AND A.DEL_FLAG = 'A' ORDER BY RESERVE_RANK) WHERE ROWNUM = 1"
                };


                cmd.Parameters.Add("IN_PLANT_CODE", "2020");


                OracleDataReader reader = cmd.ExecuteReader();

                reader.Read();

                prod_code = reader["PROD_CODE"].ToString();
                order_no = reader["ORDER_NO"].ToString();
                job_no = reader["JOB_NO"].ToString();
                prod_name = reader["PROD_NAME"].ToString();
                prod_unit = reader["PROD_UNIT"].ToString();
                order_m = reader["ORDER_M"].ToString();
                work_gbn = reader["WORK_GBN"].ToString();
                gubun = reader["GUBUN"].ToString();

                reader.Close();

                //진행중인 작업의 박스당 피스 수, 팔레트당 박스 수, 한번에 생산되는 피스 수를 가져오는 쿼리
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

                //생산테이블에서 데이터 조회 후 데이터를 컨트롤에 집어 넣는 작업
                lbl_PROD_CODE.Text = prod_code;
                lbl_ORDER_NO.Text = order_no;
                lbl_PROD_NAME.Text = prod_name;
                lbl_PROD_UNIT.Text = prod_unit;
                lbl_ORDER_M.Text = order_m;
                lbl_WORK_GBN.Text = work_gbn;
                lbl_GUBUN.Text = gubun;



                //현재 진행중인 작업을 생산진행중 으로 바꾸는 쿼리
                cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = "UPDATE TBL_PRODUCTPLAN SET PROC_STATUS = 'B' WHERE JOB_NO = :IN_JOB_NO"
                };

                cmd.Parameters.Add("IN_JOB_NO", job_no);

                cmd.ExecuteNonQuery();

                //todo 진행 시작한 작업을 PRODRESERVE 테이블에서 지우고 RESERVE_RANK 값을 1씩 낮추는 쿼리(프로시저로 구현 예정)
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
                Interval = 1000,
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
            if (lbl_Prodution.InvokeRequired || lbl_BOX.InvokeRequired || lbl_PLT.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () {
                    UpdateData();
                });
            }
            else
            {
                lbl_Prodution.Text = pcs.ToString();
                lbl_BOX.Text = box.ToString();
                lbl_PLT.Text = plt.ToString();
            }
        }
    }
}
