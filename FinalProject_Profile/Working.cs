using MetroFramework.Forms;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace FinalProject_Profile
{
    public partial class Working : MetroForm
    {

        int box_pcs, plt_box, cut_pcs;
        string prod_code, order_no, job_no, prod_name, prod_unit, order_m, work_gbn, gubun, wc_code;
        int good_qty = 0, good_box = 0, good_plt = 0;
        int total_qty = 0, total_box = 0, total_plt = 0;
        int now_seq = 1, plt_seq = 1,punching = 0;
        int bad_qty = 0;
        int btn_flag = 0;
        int _good_qty = 0, _bad_qty = 0;

        private void btn_WorkPlan_Click(object sender, EventArgs e)
        {
            main.CallWorkPlan();
        }

        private void btn_Inspection_Click(object sender, EventArgs e)
        {
            main.CallInspection();
        }

        private void btn_Defect_Click(object sender, EventArgs e)
        {
            main.CallStartingMenu();
        }

        private void btn_SAPOrder_Click(object sender, EventArgs e)
        {
            main.CallSAPOrder();
        }

        Main main;

        private void Working_Activated(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void btn_SAPOrder_MouseUp(object sender, MouseEventArgs e)
        {
            btn_SAPOrder.BackgroundImage = FinalProject_Profile.Properties.Resources.생산계획접수;
        }

        private void btn_SAPOrder_MouseDown(object sender, MouseEventArgs e)
        {
            btn_SAPOrder.BackgroundImage = FinalProject_Profile.Properties.Resources.생산계획접수클릭;
        }

        private void btn_WorkPlan_MouseUp(object sender, MouseEventArgs e)
        {
            btn_WorkPlan.BackgroundImage = FinalProject_Profile.Properties.Resources.작업계획;
        }

        private void btn_WorkPlan_MouseDown(object sender, MouseEventArgs e)
        {
            btn_WorkPlan.BackgroundImage = FinalProject_Profile.Properties.Resources.작업계획클릭;
        }

        private void btn_Working_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Working.BackgroundImage = FinalProject_Profile.Properties.Resources.작업진행;
        }

        private void btn_Working_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Working.BackgroundImage = FinalProject_Profile.Properties.Resources.작업진행클릭;
        }

        private void btn_Inspection_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Inspection.BackgroundImage = FinalProject_Profile.Properties.Resources.검사성적서;
        }

        private void btn_Inspection_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Inspection.BackgroundImage = FinalProject_Profile.Properties.Resources.검사성적서클릭;
        }

        private void btn_Defect_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Defect.BackgroundImage = FinalProject_Profile.Properties.Resources.생산현황;
        }

        private void btn_Defect_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Defect.BackgroundImage = FinalProject_Profile.Properties.Resources.생산현황클릭;
        }

        System.Timers.Timer timer = new System.Timers.Timer
        {
            Interval = 500,
            AutoReset = false
        };
        public Working()
        {
            InitializeComponent();
        }

        public Working(Main mainForm)
        {
            InitializeComponent();
            main = mainForm;
        }

        private void btn_InspectionStart_Click(object sender, EventArgs e)
        {           
            if (btn_flag == 0)
            {
                //멈추는 이미지로 바꾸기
                timer.Start();
                btn_flag = 1;
            }
                
            else if (btn_flag == 1)
            {
                //시작 이미지로 바꾸기
                timer.Stop();
                btn_flag = 0;
                
            }
            else if (btn_flag == 2)
            {
                //작업 순위에서 삭제 후 작업 순위 랭크 -1 후 Plan에 완료처리 하는 쿼리
                ChangePlan();
                //불량등록
                InsertDefect();
                //다음 데이터 조회
                btn_flag = 0;
            }
        }

        private void Working2_Load(object sender, EventArgs e)
        {
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";
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
            if (btn_flag == 0)
            {
                btn_InspectionStart.BackgroundImage = FinalProject_Profile.Properties.Resources.작업시작;
            }

            else if (btn_flag == 1)
            {
                btn_InspectionStart.BackgroundImage = FinalProject_Profile.Properties.Resources.작업중지;
            }
            else if (btn_flag == 2)
            {
                btn_InspectionStart.BackgroundImage = FinalProject_Profile.Properties.Resources.불량등록;
            }
            
        }

        private void btn_InspectionStart_MouseDown(object sender, MouseEventArgs e)
        {
            if (btn_flag == 0)
            {
                btn_InspectionStart.BackgroundImage = FinalProject_Profile.Properties.Resources.작업시작클릭;
            }

            else if (btn_flag == 1)
            {
                btn_InspectionStart.BackgroundImage = FinalProject_Profile.Properties.Resources.작업중지클릭;
            }
            else if (btn_flag == 2)
            {
                btn_InspectionStart.BackgroundImage = FinalProject_Profile.Properties.Resources.불량등록클릭;
            }
            
        }

        public void SelectItem()
        {
            good_qty = 0; good_box = 0; good_plt = 0;
            total_qty = 0; total_box = 0; total_plt = 0;
            plt_seq = 1; punching = 0; bad_qty = 0;
            _good_qty = 0; _bad_qty = 0;
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
                    CommandText = "SELECT * FROM (select A.JOB_NO JOB_NO, RESERVE_RANK, A.PLANT_CODE PLANT_CODE, trim(A.ORDER_NO||' - '||A.ORDER_SEQ) ORDER_NO, A.ORDER_M ORDER_M, A.ADD_GOOD_QTY ADD_GOOD_QTY, DECODE(A.GUBUN, 20, '내수', 40, '수출', 10, '특판') GUBUN, DECODE(A.WORK_GUBUN, 'A', '정상작업', 'U', '재작업', 'R', '연구개발', 'T', '기술테스트', 'S', 'S/BOOK', 'C', 'C/MATCH') WORK_GBN, DECODE(A.NOTE_FLAG, 'Y', '★') NOTE_FLAG, A.WORK_GUBUN WORK_GUBUN, A.WC_CODE WC_CODE, trim(A.PROD_CODE) PROD_CODE, PROD_NAME, A.PROD_UNIT PROD_UNIT, A.MRP_MGR MRP_MGR, NOTE0, NOTE1, TO_CHAR(START_DATE, 'HH24:MI') SDATE, TO_CHAR(END_DATE, 'HH24:MI') EDATE FROM TBL_PRODUCTPLAN A, TBL_PRODUCTMASTER B, TBL_PRODRESERVE C WHERE A.PROD_CODE  = B.PROD_CODE AND A.WC_CODE = C.WC_CODE AND A.JOB_NO = C.JOB_NO AND A.PLANT_CODE = '2020' AND A.PROC_STATUS IN('A','B') AND A.DEL_FLAG = 'A' ORDER BY RESERVE_RANK) WHERE ROWNUM = 1"
                };


                cmd.Parameters.Add("IN_PLANT_CODE", "2020");


                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    prod_code = reader["PROD_CODE"].ToString();
                    order_no = reader["ORDER_NO"].ToString();
                    job_no = reader["JOB_NO"].ToString();
                    prod_name = reader["PROD_NAME"].ToString();
                    prod_unit = reader["PROD_UNIT"].ToString();
                    order_m = reader["ORDER_M"].ToString();
                    work_gbn = reader["WORK_GBN"].ToString();
                    gubun = reader["GUBUN"].ToString();
                    wc_code = reader["WC_CODE"].ToString();
                }
                else
                {
                    MessageBox.Show("예약된 작업이 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


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

                UpdateDefaultData();

                //작업이 진행되었다가 중단되었는지 확인하는 쿼리
                cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = "select count(*) from tbl_prodrslt where JOB_NO = :IN_JOB_NO"
                };

                cmd.Parameters.Add("IN_JOB_NO", job_no);

                int check_Flag = Int32.Parse(cmd.ExecuteScalar().ToString());

                //작업이 진행중이였다가 중단되었으면 작업의 진행 정도를 불러움
                if(check_Flag == 1)
                {
                    cmd = new OracleCommand
                    {
                        CommandType = CommandType.Text,
                        Connection = connection,
                        CommandText = "select GOOD_QTY,BAD_QTY from tbl_prodrslt where JOB_NO = :IN_JOB_NO"
                    };

                    cmd.Parameters.Add("IN_JOB_NO", job_no);

                    reader = cmd.ExecuteReader();

                    reader.Read();

                    good_qty = Int32.Parse(reader["GOOD_QTY"].ToString());
                    bad_qty = Int32.Parse(reader["BAD_QTY"].ToString());

                    reader.Close();

                    //받아온 데이터 설정

                    total_qty = good_qty + bad_qty; 
                    total_box = total_qty / box_pcs; total_plt = total_box / plt_box;
                    good_box = good_qty / box_pcs; good_plt = good_box / plt_box;
                    punching = total_qty / cut_pcs;

                    _good_qty = good_qty % (box_pcs * plt_box - 40);
                    _bad_qty = bad_qty % 40;
                    plt_seq = total_plt + 1;
                }

                //now_seq 설정값 받아오기
                cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = "select count(*) from tbl_prodrslt where roll_no like '%' || :IN_SYSDATE || '%'"
                };

                cmd.Parameters.Add("IN_SYSDATE", DateTime.Now.ToString("yyyyMMdd"));

                if (check_Flag == 1)
                    now_seq = Int32.Parse(cmd.ExecuteScalar().ToString());
                else
                    now_seq = Int32.Parse(cmd.ExecuteScalar().ToString()) + 1;

                UpdateData();

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

        public void UpdateDefaultData()
        {
            if (lbl_PROD_CODE.InvokeRequired || lbl_ORDER_NO.InvokeRequired || lbl_PROD_NAME.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () {
                    UpdateDefaultData();
                });
            }
            else
            {
                lbl_PROD_CODE.Text = prod_code;
                lbl_ORDER_NO.Text = order_no;
                lbl_PROD_NAME.Text = prod_name;
                lbl_PROD_UNIT.Text = prod_unit;
                lbl_ORDER_M.Text = order_m;
                lbl_WORK_GBN.Text = work_gbn;
                lbl_GUBUN.Text = gubun;
                lbl_BOX_PCS.Text = box_pcs.ToString();
                lbl_PLT_BOX.Text = plt_box.ToString();
                lbl_CUT_PCS.Text = cut_pcs.ToString();
            }
        }

        public void InsertRSLT()
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
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection,
                    CommandText = "PRODRSLT_UPSERT"
                };

                cmd.Parameters.Add("IN_ROLL_NO", DateTime.Now.ToString("yyyyMMdd") + wc_code + now_seq.ToString("000"));
                cmd.Parameters.Add("IN_S_SEQ", 1);
                cmd.Parameters.Add("IN_JOB_NO", job_no);
                cmd.Parameters.Add("IN_WC_CODE", wc_code);
                cmd.Parameters.Add("IN_SHIFT_CODE", wc_code.Equals("AT01") ? "A" : "B");
                cmd.Parameters.Add("IN_PROD_DATE", DateTime.Now.ToString("yyyyMMdd"));
                cmd.Parameters.Add("IN_IPGO_QTY", good_qty);
                cmd.Parameters.Add("IN_INSU_QTY", total_qty);
                cmd.Parameters.Add("IN_TUIP_QTY", total_qty);
                cmd.Parameters.Add("IN_GOOD_QTY", good_qty);
                cmd.Parameters.Add("IN_STD_QTY", good_qty);
                cmd.Parameters.Add("IN_BAD_QTY", bad_qty);
                cmd.Parameters.Add("IN_ETC_QTY", plt_seq);
                cmd.Parameters.Add("IN_EXT1_QTY", box_pcs);
                cmd.Parameters.Add("IN_EXT2_QTY", plt_box);

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

        public void InsertRSLT_DTL()
        {
            OracleConnection connection = null;
            try
            {
                connection = new OracleConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();

                //DTL에 값을 넣는 쿼리
                OracleCommand cmd = new OracleCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection,
                    CommandText = "PRODRSLT_DTL_UPSERT"
                };

                cmd.Parameters.Add("IN_ROLL_NO", DateTime.Now.ToString("yyyyMMdd") + wc_code + now_seq.ToString("000"));
                cmd.Parameters.Add("IN_S_SEQ", 1);
                cmd.Parameters.Add("IN_U_SEQ", plt_seq);
                cmd.Parameters.Add("IN_UNIT_ROLL_NO", plt_seq);
                cmd.Parameters.Add("IN_IPGO_QTY", _good_qty);
                cmd.Parameters.Add("IN_GOOD_QTY", _good_qty);
                cmd.Parameters.Add("IN_STD_QTY", _good_qty);
                cmd.Parameters.Add("IN_GOOD_QTY2", _good_qty);
                cmd.Parameters.Add("IN_GOOD_QTY3", _good_qty);
                cmd.Parameters.Add("IN_BAD_QTY", _bad_qty);
                cmd.Parameters.Add("IN_SHIFT_CODE", wc_code.Equals("AT01") ? "A" : "B");

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

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    if (i == 4)
                    {
                        good_qty += cut_pcs - 1;
                        _good_qty += cut_pcs - 1;
                        bad_qty += 1;
                        _bad_qty += 1;
                        total_qty = good_qty + bad_qty;
                    }

                    else
                    {
                        good_qty += cut_pcs;
                        _good_qty += cut_pcs;
                        total_qty = good_qty + bad_qty;
                    }


                    total_box = total_qty / box_pcs;
                    total_plt = total_box / plt_box;
                    good_box = good_qty / box_pcs;
                    good_plt = good_box / plt_box;
                    punching++;

                    UpdateData();
                    InsertRSLT();
                    UpdataProc_Status();
                    InsertRSLT_DTL();

                    if (total_qty % (box_pcs * plt_box) == 0)
                    {
                        _good_qty = 0; _bad_qty = 0;
                        plt_seq = total_plt + 1;
                    }

                    timer.Enabled = true;

                    if (Int32.Parse(order_m) <= total_qty)
                    {
                        timer.Enabled = false;
                        MessageBox.Show("작업이 완료되었습니다. 불량 요인을 등록해 주세요.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        btn_flag = 2;

                        //불량등록 이미지로 바꾸기
                        btn_InspectionStart.BackgroundImage = FinalProject_Profile.Properties.Resources.불량등록;

                        timer.Stop();

                        return;
                    }
                        
                }
            }
            catch
            {
                timer.Enabled = false;
            }
            
        }

        public void UpdataProc_Status()
        {
            OracleConnection connection = null;
            try
            {
                connection = new OracleConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();

                //현재 진행중인 작업을 생산진행중 으로 바꾸는 쿼리
                OracleCommand cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = "UPDATE TBL_PRODUCTPLAN SET PROC_STATUS = 'B' WHERE JOB_NO = :IN_JOB_NO"
                };

                cmd.Parameters.Add("IN_JOB_NO", job_no);

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

        private void InsertDefect()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            result.Add("PROD_CODE", prod_code);
            result.Add("ORDER_NO", order_no);
            result.Add("JOB_NO", job_no);
            result.Add("PROD_NAME", prod_name);
            result.Add("PROD_UNIT", prod_unit);
            result.Add("ORDER_M", order_m);
            result.Add("WORK_GBN", work_gbn);
            result.Add("GUBUN", gubun);
            result.Add("WC_CODE", wc_code);
            result.Add("TOTAL_QTY", total_qty.ToString());
            result.Add("GOOD_QTY", good_qty.ToString());
            result.Add("BAD_QTY", bad_qty.ToString());
            result.Add("BOX_PCS", box_pcs.ToString());
            result.Add("PLT_BOX", plt_box.ToString());
            result.Add("ROLL_NO", DateTime.Now.ToString("yyyyMMdd") + wc_code + now_seq.ToString("000"));
            result.Add("U_SEQ", plt_seq.ToString());

            Defect defect = new Defect(result, this);
            defect.Show();
        }

        public void ChangePlan()
        {
            OracleConnection connection = null;
            try
            {
                connection = new OracleConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();

                //작업 완료 후 Plan의 PROD
                OracleCommand cmd = new OracleCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection,
                    CommandText = "PRODRLST_END"
                };

                cmd.Parameters.Add("IN_JOB_NO", job_no);

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

        public void UpdateData()
        {
            if (lbl_Punching.InvokeRequired || lbl_Total_BOX.InvokeRequired || lbl_Total_PLT.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () {
                    UpdateData();
                });
            }
            else
            {
                lbl_Punching.Text = punching.ToString();
                lbl_Punching2.Text = punching.ToString();

                lbl_Total_PCS.Text = total_qty.ToString();
                lbl_Total_BOX.Text = total_box.ToString();
                lbl_Total_PLT.Text = total_plt.ToString();

                lbl_Total_PCS2.Text = total_qty.ToString();
                lbl_Total_BOX2.Text = total_box.ToString();
                lbl_Total_PLT2.Text = total_plt.ToString();

                lbl_Good_PCS.Text = good_qty.ToString();
                lbl_Good_BOX.Text = good_box.ToString();
                lbl_Good_PLT.Text = good_plt.ToString();

                lbl_Good_PCS2.Text = good_qty.ToString();
                lbl_Good_BOX2.Text = good_box.ToString();
                lbl_Good_PLT2.Text = good_plt.ToString();

                lbl_Top_PCS.Text = total_qty.ToString();
            }
        }
    }
}
